Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32.SafeHandles
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Public Class clsDiskInfoEx
	Public Class clsDiskInfoEx
		Private Const GenericRead As Integer = -2147483648

		Private Const FileShareRead As Integer = 1

		Private Const Filesharewrite As Integer = 2

		Private Const OpenExisting As Integer = 3

		Private Const IoctlVolumeGetVolumeDiskExtents As Integer = 5636096

		Private Const IncorrectFunction As Integer = 1

		Private Const ErrorInsufficientBuffer As Integer = 122

		Private Const MoreDataIsAvailable As Integer = 234

		Private currentDriveMappings As List(Of String)

		Private errorMessage As String

		Public Sub New()
			MyBase.New()
			Me.Refresh()
		End Sub

		Public Function GetPhysicalDiskParentFor(ByVal logicalDisk As String) As String
			Dim str As String
			Dim enumerator As List(Of String).Enumerator = New List(Of String).Enumerator()
			Dim strArrays As String() = Nothing
			If (logicalDisk.Length > 0) Then
				Try
					enumerator = Me.currentDriveMappings.GetEnumerator()
					While enumerator.MoveNext()
						Dim current As String = enumerator.Current
						If (Operators.CompareString(logicalDisk.Substring(0, 2).ToUpper(), current.Substring(0, 2).ToUpper(), False) = 0) Then
							strArrays = Strings.Split(current, "=", -1, CompareMethod.Binary)
							str = strArrays(CInt(strArrays.Length) - 1)
							Return str
						End If
					End While
				Finally
					DirectCast(enumerator, IDisposable).Dispose()
				End Try
			End If
			str = ""
			Return str
		End Function

		Public Function GetPhysicalDisks(ByRef theList As List(Of String)) As Boolean
			Dim flag As Boolean
			Dim enumerator As List(Of String).Enumerator = New List(Of String).Enumerator()
			Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
			Dim drives As System.IO.DriveInfo() = System.IO.DriveInfo.GetDrives()
			Dim num As Integer = 0
			While num < CInt(drives.Length)
				Dim driveInfo As System.IO.DriveInfo = drives(num)
				Try
					stringBuilder.Remove(0, stringBuilder.Length)
					stringBuilder.Append(driveInfo.RootDirectory.ToString())
					stringBuilder.Append("=")
					Dim physicalDriveStrings As List(Of String) = Me.GetPhysicalDriveStrings(driveInfo)
					If (physicalDriveStrings.Count <= 0) Then
						stringBuilder.Append("n/a")
					Else
						Try
							enumerator = physicalDriveStrings.GetEnumerator()
							While enumerator.MoveNext()
								Dim current As String = enumerator.Current
								current = current.Replace("\\.\", "")
								stringBuilder.Append(current.Replace("PhysicalDrive", "Physical Drive "))
								stringBuilder.Append(", ")
							End While
						Finally
							DirectCast(enumerator, IDisposable).Dispose()
						End Try
						stringBuilder.Remove(stringBuilder.Length - 2, 2)
					End If
					theList.Add(stringBuilder.ToString())
				Catch exception1 As System.Exception
					ProjectData.SetProjectError(exception1)
					Dim exception As System.Exception = exception1
					Me.errorMessage = exception.Message
					Interaction.MsgBox(String.Concat(exception.Message, "" & VbCrLf & "" & VbCrLf & "", stringBuilder.ToString()), MsgBoxStyle.OkOnly, Nothing)
					ProjectData.ClearProjectError()
				End Try
				num = num + 1
			End While
			flag = If(Operators.CompareString(Me.errorMessage, "", False) = 0, True, False)
			Return flag
		End Function

		Private Function GetPhysicalDriveStrings(ByVal driveInfo As System.IO.DriveInfo) As List(Of String)
			Dim strs As List(Of String)
			Dim num As Integer = 0
			Dim safeFileHandle As Microsoft.Win32.SafeHandles.SafeFileHandle = Nothing
			Dim strs1 As List(Of String) = New List(Of String)(1)
			Dim str As String = String.Concat("\\.\", driveInfo.RootDirectory.ToString().TrimEnd(New Char() {"\"c}))
			Try
				safeFileHandle = clsDiskInfoEx.NativeMethods.CreateFile(str, 0, 3, System.IntPtr.Zero, 3, 0, System.IntPtr.Zero)
				Dim diskExtent As clsDiskInfoEx.DiskExtents = New clsDiskInfoEx.DiskExtents()
				If (clsDiskInfoEx.NativeMethods.DeviceIoControl(safeFileHandle, 5636096, System.IntPtr.Zero, 0, diskExtent, Marshal.SizeOf(Of clsDiskInfoEx.DiskExtents)(diskExtent), num, System.IntPtr.Zero)) Then
					strs1.Add(String.Concat("\\.\PhysicalDrive", diskExtent.first.DiskNumber.ToString()))
					strs = strs1
				ElseIf (Marshal.GetLastWin32Error() <> 1) Then
					If (Marshal.GetLastWin32Error() <> 234) Then
						If (Marshal.GetLastWin32Error() <> 122) Then
							Throw New Win32Exception()
						End If
					End If
					Dim num1 As Integer = Marshal.SizeOf(GetType(clsDiskInfoEx.DiskExtents)) + (diskExtent.numberOfExtents - 1) * Marshal.SizeOf(GetType(clsDiskInfoEx.DiskExtent))
					Dim intPtr As System.IntPtr = Marshal.AllocHGlobal(num1)
					If (Not clsDiskInfoEx.NativeMethods.DeviceIoControl(safeFileHandle, 5636096, System.IntPtr.Zero, 0, intPtr, num1, num, System.IntPtr.Zero)) Then
						Throw New Win32Exception()
					End If
					Dim intPtr1 As System.IntPtr = New System.IntPtr(intPtr.ToInt64() + CLng(8))
					Dim num2 As Integer = diskExtent.numberOfExtents - 1
					Dim num3 As Integer = 0
					Do
						Dim [structure] As clsDiskInfoEx.DiskExtent = DirectCast(Marshal.PtrToStructure(intPtr1, GetType(clsDiskInfoEx.DiskExtent)), clsDiskInfoEx.DiskExtent)
						strs1.Add(String.Concat("\\.\PhysicalDrive", [structure].DiskNumber.ToString()))
						intPtr1 = New System.IntPtr(intPtr1.ToInt32() + Marshal.SizeOf(GetType(clsDiskInfoEx.DiskExtent)))
						num3 = num3 + 1
					Loop While num3 <= num2
					strs = strs1
				Else
					strs = strs1
				End If
			Finally
				If (safeFileHandle IsNot Nothing) Then
					If (Not safeFileHandle.IsInvalid) Then
						safeFileHandle.Close()
					End If
					safeFileHandle.Dispose()
				End If
			End Try
			Return strs
		End Function

		<DllImport("kernel32.dll", CharSet:=CharSet.Auto, ExactSpelling:=False, SetLastError:=True)>
		Private Shared Function QueryDosDevice(ByRef lpDeviceName As String, ByVal lpTargetPath As IntPtr, ByVal ucchMax As UInteger) As UInteger
		End Function

		Private Function QueryDosDevice(ByVal device As String) As List(Of String)
			Dim num As Integer = 0
			Dim num1 As UInteger = 65536
			Dim stringAuto As String = Nothing
			Dim strArrays As String() = Nothing
			Dim strs As List(Of String) = New List(Of String)()
			If (Operators.CompareString(device.Trim(), "", False) = 0) Then
				device = Nothing
			End If
			While num = 0
				Dim intPtr As IntPtr = Marshal.AllocHGlobal(CInt(num1))
				If (intPtr = System.IntPtr.Zero) Then
					Throw New OutOfMemoryException()
				End If
				Try
					num = CInt(clsDiskInfoEx.QueryDosDevice(device, intPtr, num1))
					If (num = 0) Then
						num = -1
					Else
						stringAuto = Marshal.PtrToStringAuto(intPtr, num)
						strArrays = stringAuto.Split(New Char(0) {})
					End If
				Finally
					Marshal.FreeHGlobal(intPtr)
				End Try
			End While
			If (strArrays IsNot Nothing) Then
				Dim strArrays1 As String() = strArrays
				Dim num2 As Integer = 0
				While num2 < CInt(strArrays1.Length)
					Dim str As String = strArrays1(num2)
					If (Operators.CompareString(str.Trim(), "", False) <> 0) Then
						strs.Add(str)
					End If
					num2 = num2 + 1
				End While
			End If
			Return strs
		End Function

		Public Sub Refresh()
			Me.errorMessage = ""
			Me.currentDriveMappings = Nothing
			Me.currentDriveMappings = New List(Of String)()
			Me.GetPhysicalDisks(Me.currentDriveMappings)
		End Sub

		Private Structure DiskExtent
			Public DiskNumber As Integer

			Public StartingOffset As Long

			Public ExtentLength As Long
		End Structure

		Private Structure DiskExtents
			Public numberOfExtents As Integer

			Public first As clsDiskInfoEx.DiskExtent
		End Structure

		Private Class NativeMethods
			Public Sub New()
				MyBase.New()
			End Sub

			<DllImport("kernel32", CharSet:=CharSet.Unicode, ExactSpelling:=False, SetLastError:=True)>
			Public Shared Function CreateFile(ByVal fileName As String, ByVal desiredAccess As Integer, ByVal shareMode As Integer, ByVal securityAttributes As IntPtr, ByVal creationDisposition As Integer, ByVal flagsAndAttributes As Integer, ByVal hTemplateFile As IntPtr) As SafeFileHandle
			End Function

			<DllImport("kernel32", CharSet:=CharSet.None, ExactSpelling:=False, SetLastError:=True)>
			Public Shared Function DeviceIoControl(ByVal hVol As SafeFileHandle, ByVal controlCode As Integer, ByVal inBuffer As IntPtr, ByVal inBufferSize As Integer, ByRef outBuffer As clsDiskInfoEx.DiskExtents, ByVal outBufferSize As Integer, ByRef bytesReturned As Integer, ByVal overlapped As IntPtr) As Boolean
			End Function

			<DllImport("kernel32", CharSet:=CharSet.None, ExactSpelling:=False, SetLastError:=True)>
			Public Shared Function DeviceIoControl(ByVal hVol As SafeFileHandle, ByVal controlCode As Integer, ByVal inBuffer As IntPtr, ByVal inBufferSize As Integer, ByVal outBuffer As IntPtr, ByVal outBufferSize As Integer, ByRef bytesReturned As Integer, ByVal overlapped As IntPtr) As Boolean
			End Function

			<DllImport("mpr.dll", CharSet:=CharSet.Auto, ExactSpelling:=False)>
			Public Shared Function WNetCloseEnum(ByVal hEnum As IntPtr) As Integer
			End Function

			<DllImport("mpr.dll", CharSet:=CharSet.Auto, ExactSpelling:=False)>
			Public Shared Function WNetEnumResource(ByVal hEnum As IntPtr, ByRef lpcCount As Integer, ByVal lpBuffer As IntPtr, ByRef lpBufferSize As Integer) As Integer
			End Function

			<DllImport("mpr.dll", CharSet:=CharSet.Auto, ExactSpelling:=False)>
			Public Shared Function WNetOpenEnum(ByVal dwScope As clsDiskInfoEx.RESOURCE_SCOPE, ByVal dwType As clsDiskInfoEx.RESOURCE_TYPE, ByVal dwUsage As clsDiskInfoEx.RESOURCE_USAGE, ByRef lphEnum As IntPtr) As Integer
			End Function
		End Class

		Public Enum NERR
			NERR_Success = 0
			ERROR_ACCESS_DENIED = 5
			ERROR_NOT_ENOUGH_MEMORY = 8
			ERROR_BAD_NETPATH = 53
			ERROR_NETWORK_BUSY = 54
			ERROR_INVALID_PARAMETER = 87
			ERROR_INVALID_LEVEL = 124
			ERROR_MORE_DATA = 234
			ERROR_EXTENDED_ERROR = 1208
			ERROR_NO_NETWORK = 1222
			ERROR_INVALID_HANDLE_STATE = 1609
			ERROR_NO_BROWSER_SERVERS_FOUND = 6118
		End Enum

		Public Enum RESOURCE_DISPLAYTYPE
			RESOURCEDISPLAYTYPE_GENERIC
			RESOURCEDISPLAYTYPE_DOMAIN
			RESOURCEDISPLAYTYPE_SERVER
			RESOURCEDISPLAYTYPE_SHARE
			RESOURCEDISPLAYTYPE_FILE
			RESOURCEDISPLAYTYPE_GROUP
			RESOURCEDISPLAYTYPE_NETWORK
			RESOURCEDISPLAYTYPE_ROOT
			RESOURCEDISPLAYTYPE_SHAREADMIN
			RESOURCEDISPLAYTYPE_DIRECTORY
			RESOURCEDISPLAYTYPE_TREE
			RESOURCEDISPLAYTYPE_NDSCONTAINER
		End Enum

		Public Enum RESOURCE_SCOPE
			RESOURCE_CONNECTED = 1
			RESOURCE_GLOBALNET = 2
			RESOURCE_REMEMBERED = 3
			RESOURCE_RECENT = 4
			RESOURCE_CONTEXT = 5
		End Enum

		Public Enum RESOURCE_TYPE
			RESOURCETYPE_ANY = 0
			RESOURCETYPE_DISK = 1
			RESOURCETYPE_PRINT = 2
			RESOURCETYPE_RESERVED = 8
		End Enum

		Public Enum RESOURCE_USAGE
			RESOURCEUSAGE_CONNECTABLE = 1
			RESOURCEUSAGE_CONTAINER = 2
			RESOURCEUSAGE_NOLOCALDEVICE = 4
			RESOURCEUSAGE_SIBLING = 8
			RESOURCEUSAGE_ATTACHED = 16
			RESOURCEUSAGE_ALL = 19
		End Enum
	End Class
End Class
