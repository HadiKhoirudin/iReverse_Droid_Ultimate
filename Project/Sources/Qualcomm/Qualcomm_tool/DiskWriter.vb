Imports System
Imports System.Linq
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Imports Microsoft.Win32.SafeHandles

Namespace Bismillah.DISK
    Public Class DiskWriter
        Public Shared WithEvents OpenWritePort As New SafeFileHandle(IntPtr.Zero, False)
        Private Const INVALID_HANDLE = -1
        Private Const GENERIC_READ = &H80000000
        Private Const GENERIC_WRITE = &H40000000
        Private Const FILE_SHARE_READ = 1
        Private Const FILE_SHARE_WRITE = 2
        Private Const FILE_SHARE_DELETE = 3
        Private Const FILE_ATTRIBUTE_NORMAL = &H80
        Private Const CREATE_ALWAYS = 2
        Private Const OPEN_EXISTING = 3
        Private Const OPEN_ALWAYS = 4 'Create if doesn't exist
        Private Const INIT_SUCCESS = 0
        Private Const WRITE_ERROR = 0
        Private Const READ_ERROR = 0
        Private Const LOCK_TIMEOUT As Integer = 3000       ' 3 Seconds
        Private Const LOCK_RETRIES As Integer = 5
        Private Const INVALID_HANDLE_VALUE As Integer = -1
        Private Const FSCTL_LOCK_VOLUME As Integer = &H90018
        Private Const FSCTL_DISMOUNT_VOLUME As Integer = &H90020
        Private Const FSCTL_UNLOCK_VOLUME = &H9001C
        Private Const IOCTL_STORAGE_MEDIA_REMOVAL As Integer = &H2D4804
        Private Const IOCTL_STORAGE_EJECT_MEDIA As Integer = &H2D4808
        Private Const IOCTL_STORAGE_LOAD_MEDIA As Integer = &H2D480C


        Public Shared Function OpenDisk(ByVal devices As String) As Boolean

            OpenWritePort = New SafeFileHandle(IntPtr.Zero, True)
            OpenWritePort = CreateFile(devices, GENERIC_READ Or GENERIC_WRITE,
                FILE_SHARE_READ Or FILE_SHARE_WRITE Or FILE_SHARE_DELETE,
                IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero)

            If OpenWritePort.IsInvalid Then
                Return False
            Else
                Return True
            End If
        End Function

        <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Public Shared Function DeviceIoControl(
            ByVal hVol As SafeFileHandle,
            <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)>
            ByVal inBuffer() As Byte,
            ByVal numberOfBytesToWrite As Integer,
            ByRef numberOfBytesWritten As Integer,
            ByVal overlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        Public Shared Sub DiskWrite(ByVal data() As Byte)
            Try
                Dim writen As Integer
                WriteFile(OpenWritePort, data, data.Length, writen, IntPtr.Zero)

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Sub
        Public Class timeouts
            Public ReadIntervalTimeout As UInt32 = 0
            Public ReadTotalTimeoutMultiplier As UInt32 = 0
            Public ReadTotalTimeoutConstant As UInt32 = 0
            Public WriteTotalTimeoutMultiplier As UInt32 = 0
            Public WriteTotalTimeoutConstant As UInt32 = 0
        End Class

        Public Shared Function DiskRead(Optional delay As String = "0") As Byte()
            Try
                Dim hu() As Byte = New Byte(524288 - 1) {}
                Dim z As Integer = New Integer

                ReadFile(OpenWritePort, hu, hu.Length, z, IntPtr.Zero)

                Return hu.Take(z).ToArray
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
                Return {}
            End Try

        End Function

        Public Shared Function ReadDisk(v1 As Long, v2 As Integer) As Byte()
            Try
                Dim hu() As Byte = New Byte(v2 - 1) {}
                Dim z As Integer = New Integer

                ReadFile(OpenWritePort, hu, hu.Length, z, IntPtr.Zero)

                Return hu.Take(z).ToArray
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
                Return {}
            End Try

        End Function

        Public Shared Sub DiskClose()
            Try
                OpenWritePort.Close()
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
            End Try
        End Sub

        <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Public Shared Function CreateFile(
            ByVal fileName As String,
            ByVal desiredAccess As Integer,
            ByVal shareMode As UInteger,
            ByVal securityAttributes As IntPtr,
            ByVal creationDisposition As UInteger,
            ByVal flagsAndAttributes As UInteger,
            ByVal hTemplateFile As IntPtr) As SafeFileHandle
        End Function
        <DllImport("kernel32.dll", ExactSpelling:=True, SetLastError:=True)>
        Public Shared Function CloseHandle(ByVal handle As SafeFileHandle) As Boolean
        End Function
        <DllImport("kernel32", CharSet:=CharSet.Auto, SetLastError:=True)>
        Friend Shared Function ReadFile(ByVal handle As SafeFileHandle, <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> ByVal bytes() As Byte, ByVal numBytesToRead As Integer, ByRef numBytesRead As Integer, ByVal overlapped_MustBeZero As IntPtr) As Integer
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)>
        Friend Shared Function WriteFile(ByVal handle As SafeFileHandle, ByVal bytes As Byte(), ByVal numBytesToWrite As Integer, <Out> ByRef numBytesWritten As Integer, ByVal overlapped_MustBeZero As IntPtr) As Integer
        End Function
        <DllImport("kernel32", CharSet:=CharSet.Auto, SetLastError:=True)>
        Friend Shared Function GetFileSize(ByVal handle As SafeFileHandle, ByRef len As Long) As Integer
        End Function
        <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Friend Shared Function SetCommTimeouts(ByVal handle As SafeFileHandle, ByRef len As timeouts) As Integer
        End Function
        <DllImport("kernel32", CharSet:=CharSet.Auto, SetLastError:=True)>
        Friend Shared Function ReadFile(ByVal handle As SafeFileHandle, ByVal bytesintptr As IntPtr, ByVal numBytesToRead As Integer, ByRef numBytesRead As Integer, ByVal overlapped_MustBeZero As IntPtr) As Integer
        End Function
        <DllImport("kernel32", CharSet:=CharSet.Auto, SetLastError:=True)>
        Friend Shared Function GetCommState(ByVal handle As SafeFileHandle, ByRef len As DCB) As Integer
        End Function
        <DllImport("kernel32", CharSet:=CharSet.Auto, SetLastError:=True)>
        Friend Shared Function SetCommState(ByVal handle As SafeFileHandle, ByVal len As DCB) As Integer
        End Function

        <DllImport("Kernel32.dll", CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.StdCall)>
        Public Shared Function FlushFileBuffers(hFile As SafeFileHandle) As Integer
        End Function
        Public Structure DCB
            Public DCBlength As UInt32 ' // sizeof(DCB)
            Public BaudRate As UInt32 '  // Baudrate at which running
            Public uiFlagBits As UInt32 '  // Defined separately
            Public wReserved As UInt16 ' // Not currently used
            Public XonLim As UInt16  ' // Transmit X-On threshold
            Public XoffLim As UInt16  ' // Transmit X-OFF threshold
            Public ByteSize As Byte     ' // Number Of bits/Byte, 4-8
            Public Parity As Byte      ' // 0-4=None,Odd,Even,Mark,Space
            Public StopBits As Byte  '  // 0,1,2 = 1, 1.5, 2
            Public XonChar As String       ' // Tx And Rx X-On character
            Public XoffChar As String   ' // Tx And Rx X-OFF character
            Public ErrorChar As String  ' // Error replacement Char
            Public EofChar As String ' // End Of Input character
            Public EvtChar As String    ' // Received Event character
            Public wReserved1 As UInt16 ' // Fill For now.
        End Structure
    End Class
End Namespace