Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class EjectUSB
    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function CreateFile(ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal SecurityAttributes As IntPtr, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As IntPtr) As IntPtr
    End Function
    <DllImport("kernel32.dll", ExactSpelling:=True, SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function DeviceIoControl(ByVal hDevice As IntPtr, ByVal dwIoControlCode As Integer, ByVal lpInBuffer As IntPtr, ByVal nInBufferSize As Integer, ByVal lpOutBuffer As IntPtr, ByVal nOutBufferSize As Integer, <Out> ByRef lpBytesReturned As Integer, ByVal lpOverlapped As IntPtr) As Boolean
    End Function
    <DllImport("kernel32.dll", ExactSpelling:=True, SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function DeviceIoControl(ByVal hDevice As IntPtr, ByVal dwIoControlCode As Integer, ByVal lpInBuffer As Byte(), ByVal nInBufferSize As Integer, ByVal lpOutBuffer As IntPtr, ByVal nOutBufferSize As Integer, <Out> ByRef lpBytesReturned As Integer, ByVal lpOverlapped As IntPtr) As Boolean
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function CloseHandle(ByVal hObject As IntPtr) As Boolean
    End Function
    <MarshalAs(UnmanagedType.Bool)>
    Public handle As IntPtr = IntPtr.Zero
    Const GENERIC_READ As Integer = &H80000000
    Const GENERIC_WRITE As Integer = &H40000000
    Const FILE_SHARE_READ As Integer = &H1
    Const FILE_SHARE_WRITE As Integer = &H2
    Const FSCTL_LOCK_VOLUME As Integer = &H90018
    Const FSCTL_DISMOUNT_VOLUME As Integer = &H90020
    Const IOCTL_STORAGE_EJECT_MEDIA As Integer = &H2D4808
    Const IOCTL_STORAGE_MEDIA_REMOVAL As Integer = &H2D4804

    Public Shared Function USBEject(ByVal drive As String) As IntPtr
        Dim filename As String = "\\.\PHYSICALDRIVE" & drive
        Return CreateFile(filename, GENERIC_READ Or GENERIC_WRITE, FILE_SHARE_READ Or FILE_SHARE_WRITE, IntPtr.Zero, &H3, 0, IntPtr.Zero)
    End Function

    Public Shared Function Eject(ByVal handle As IntPtr) As Boolean
        Dim LockResult As Boolean = LockVolume(handle)
        If LockResult Then
            RichLogs("Prepairing Disk For R/W Access :", Color.WhiteSmoke, True, False)
        End If

        Dim DismountResult As Boolean = DismountVolume(handle)
        If DismountResult Then
            RichLogs(" Done  ✓", Color.FromArgb(97, 197, 84), True, True)
        Else
            RichLogs("Failed!", Color.Red, True, True)
        End If

        Dim result As Boolean
        If LockResult AndAlso DismountResult Then
            RichLogs("Get R/W Access From Disk       :", Color.WhiteSmoke, True, False)
            If PreventRemovalOfVolume(handle, False) Then
                RichLogs(" Done  ✓", Color.FromArgb(97, 197, 84), True, True)
                RichLogs(" ", Color.FromArgb(97, 197, 84), True, True)
                result = True
            Else
                RichLogs("Failed!", Color.Red, True, True)
                RichLogs(" ", Color.FromArgb(97, 197, 84), True, True)
                result = False
            End If
            'result = AutoEjectVolume(handle)
        Else
            result = False
        End If

        CloseHandle(handle)
        Return result
    End Function

    Public Shared Function LockVolume(ByVal handle As IntPtr) As Boolean
        Dim byteReturned As Integer
        RichLogs(Environment.NewLine & "Waiting Lock & Dismount Disk   :", Color.WhiteSmoke, True, False)
        For i As Integer = 1 To 10
            If DeviceIoControl(handle, FSCTL_LOCK_VOLUME, IntPtr.Zero, 0, IntPtr.Zero, 0, byteReturned, IntPtr.Zero) Then
                RichLogs(" Done  ✓", Color.FromArgb(97, 197, 84), True, True)
                Return True
            Else
                RichLogs(" " & i, Color.Crimson, True, False)
            End If
            Thread.Sleep(500)
        Next
        RichLogs("Failed!", Color.Red, True, True)
        Return False
    End Function

    Public Shared Function DismountVolume(ByVal handle As IntPtr) As Boolean
        Dim byteReturned As Integer
        Dim flag As Boolean = DeviceIoControl(handle, FSCTL_DISMOUNT_VOLUME, IntPtr.Zero, 0, IntPtr.Zero, 0, byteReturned, IntPtr.Zero)
        Return flag
    End Function

    Public Shared Function PreventRemovalOfVolume(ByVal handle As IntPtr, ByVal prevent As Boolean) As Boolean
        Dim buf As Byte() = New Byte(0) {}
        Dim retVal As Integer
        buf(0) = If((prevent), CByte(1), CByte(0))
        Return DeviceIoControl(handle, IOCTL_STORAGE_MEDIA_REMOVAL, buf, 1, IntPtr.Zero, 0, retVal, IntPtr.Zero)
    End Function


    Public Shared Function AutoEjectVolume(ByVal handle As IntPtr) As Boolean
        Dim byteReturned As Integer
        Return DeviceIoControl(handle, IOCTL_STORAGE_EJECT_MEDIA, IntPtr.Zero, 0, IntPtr.Zero, 0, byteReturned, IntPtr.Zero)
    End Function

    Public Shared Function CloseVolume(ByVal handle As IntPtr) As Boolean
        Return CloseHandle(handle)
    End Function
End Class
