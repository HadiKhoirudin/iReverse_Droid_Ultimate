Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Namespace BismillahAdb
    Public Class AdbClient
        Public Property DeviceSerialNumber As String

        Public Property ServerHost As String

        Public Property ServerPort As Integer

        Public Sub New(Optional adbServerPort As Integer = -1, Optional adbServerHost As String = Nothing)
            MyBase.New()
            If adbServerPort >= 0 Then
                ServerPort = adbServerPort
            Else
                Dim serverPortString As String = Environment.GetEnvironmentVariable("ANDROID_ADB_SERVER_PORT")
                Dim serverPort As Integer = 0
                Me.ServerPort = If(String.IsNullOrEmpty(serverPortString) OrElse Not Integer.TryParse(serverPortString, serverPort), 5037, serverPort)
            End If
            ServerHost = If(String.IsNullOrEmpty(adbServerHost), "127.0.0.1", adbServerHost)
        End Sub

        Public Sub DeleteFile(remoteFileName As String)
            ExecuteCommand(String.Concat("rm -f ", remoteFileName))
        End Sub

        Public Sub DownloadFile(remoteFileName As String, localFileName As String)
            Using adbSocket As AdbSocket = GetSocket()
                Dim response As String = SendSyncCommand(adbSocket, "RECV", remoteFileName, True)
                Dim total As Integer = 0
                Using stream As FileStream = File.Open(localFileName, FileMode.Create)
                    Dim bytes(65535) As Byte
                    While True
                        If response.Equals("DONE") Then
                            Return
                        End If
                        If Not response.Equals("DATA") Then
                            Exit While
                        End If
                        Dim size As Integer = adbSocket.ReadInt32()
                        adbSocket.Read(bytes, size)
                        stream.Write(bytes, 0, size)
                        total += size
                        response = adbSocket.ReadString(4)
                    End While
                    Throw New AdbInvalidResponseException(response)
                End Using
            End Using
        End Sub

        Public Function Exec(command As String) As String()
            Dim strArrays As String()
            Using adbSocket As AdbSocket = GetSocket()
                SetDevice(adbSocket)
                Trace(String.Concat("Executing '", command, "' remote command"))
                adbSocket.SendCommand(If(command, ""))
                Dim response As String() = adbSocket.ReadAllLines()
                Trace(String.Format("{0} response lines read", response.Length))
                strArrays = response
            End Using
            Return strArrays
        End Function

        Public Function ExecuteCommand(command As String) As String()
            Dim strArrays As String()
            Using adbSocket As AdbSocket = GetSocket()
                SetDevice(adbSocket)
                Trace(String.Concat("Executing '", command, "' remote command"))
                adbSocket.SendCommand(String.Concat("shell:", command))
                Dim response As String() = adbSocket.ReadAllLines()
                Trace(String.Format("{0} response lines read", response.Length))
                strArrays = response
            End Using
            Return strArrays
        End Function

        Private Sub ExecutePm(commandLine As String)
            Dim response As String() = ExecuteCommand(String.Concat("pm ", commandLine))
            If response Is Nothing OrElse response.Length = 0 Then
                Throw New Exception("Wrong pm output")
            End If
            Dim line As String = response(response.Length - 1)
            If Not line.Equals("Success") Then
                Dim match As Match = Regex.Match(line, "\[(.+?)]")
                Throw New Exception(If(2 = match.Groups.Count, match.Groups(1).Value, line))
            End If
        End Sub

        Public Function GetDeviceProperties() As Dictionary(Of String, String)
            Dim props As New Dictionary(Of String, String)()
            Dim strArrays As String() = ExecuteCommand("/system/bin/getprop")
            Dim num As Integer = 0
            Do
                Dim line As String = strArrays(num)
                Dim match As Match = Regex.Match(line, "\[(.*)]: \[(.*)]")
                If match.Success AndAlso match.Groups.Count = 3 Then
                    props.Add(match.Groups(1).Value, match.Groups(2).Value)
                Else
                    Trace(String.Concat("Invalid prop line: '", line, "'"))
                End If
                num += 1
            Loop While num < strArrays.Length
            Return props
        End Function

        Public Function GetDevices() As AdbDevice()
            Dim response As String = ""
            Using adbSocket As AdbSocket = GetSocket()
                adbSocket.SendCommand("host:devices-l")
                response = adbSocket.ReadHexString()
            End Using
            If Not response = "" Then
                Dim lines As String() = response.Split(New Char() {ChrW(13), ChrW(10)}, StringSplitOptions.RemoveEmptyEntries)
                Dim devices As New List(Of AdbDevice)(lines.Length)
                Dim strArrays As String() = lines
                Dim num As Integer = 0
                Do
                    Dim line As String = strArrays(num)
                    Dim parts As String() = line.Split(New Char() {ChrW(32)}, StringSplitOptions.RemoveEmptyEntries)
                    Dim product As String = ""
                    Dim model As String = ""
                    Dim device As String = ""
                    Dim i As Integer = 2
                    While i < parts.Length
                        Dim halves As String() = parts(i).Split((New Char() {":"c}), StringSplitOptions.RemoveEmptyEntries)
                        If 2 = halves.Length Then
                            Dim str As String = halves(0)
                            If str = "product" Then
                                product = halves(1)
                            ElseIf str = "model" Then
                                model = halves(1)
                            ElseIf str = "device" Then
                                device = halves(1)
                            End If
                        End If
                        i += 1
                    End While
                    devices.Add(New AdbDevice(parts(0), product, model, device))
                    num += 1
                Loop While num < strArrays.Length
                Return devices.ToArray()
            End If
            Return Nothing
        End Function

        Public Function GetDirectoryListing(directoryName As String) As AdbFileInfo()
            Dim array As AdbFileInfo()
            Using adbSocket As AdbSocket = GetSocket()
                Dim response As String = SendSyncCommand(adbSocket, "LIST", directoryName, True)
                Dim fileInfos As New List(Of AdbFileInfo)()
                Dim realDirectory As Boolean = False
                While True
                    If response.Equals("DONE") Then
                        If Not realDirectory Then
                            Throw New DirectoryNotFoundException()
                        End If
                        array = fileInfos.ToArray()
                        Return array
                    End If
                    If Not response.Equals("DENT") Then
                        Exit While
                    End If
                    Dim adbFileInfo As AdbFileInfo = GetFileInfo(adbSocket, Nothing, directoryName)
                    If adbFileInfo IsNot Nothing Then
                        fileInfos.Add(adbFileInfo)
                    Else
                        realDirectory = True
                    End If
                    response = adbSocket.ReadString(4)
                End While
                Throw New AdbInvalidResponseException(response)
            End Using
            Return array
        End Function

        Public Function GetFileInfo(fileName As String) As AdbFileInfo
            Dim fileInfo As AdbFileInfo
            Using adbSocket As AdbSocket = GetSocket()
                Dim response As String = SendSyncCommand(adbSocket, "STAT", fileName, True)
                If Not response.Equals("STAT") Then
                    Throw New AdbInvalidResponseException(response)
                End If
                fileInfo = GetFileInfo(adbSocket, fileName, Nothing)
            End Using
            Return fileInfo
        End Function

        Private Function GetFileInfo(adbSocket As AdbSocket, fullName As String, directoryName As String) As AdbFileInfo
            Dim adbFileInfo As AdbFileInfo
            Dim mode As Integer = adbSocket.ReadInt32()
            Dim size As Integer = adbSocket.ReadInt32()
            Dim time As DateTime = FromUnixTime(adbSocket.ReadInt32())
            Dim name As String

            If Not String.IsNullOrEmpty(fullName) Then
                name = Path.GetFileName(fullName)
            Else
                name = adbSocket.ReadSyncString()
                If name.Equals(".") OrElse name.Equals("..") Then
                    adbFileInfo = Nothing
                    Return adbFileInfo
                End If
                fullName = CombinePath(directoryName, name)
            End If
            adbFileInfo = New AdbFileInfo(fullName, name, size, mode, time)
            Return adbFileInfo
        End Function

        Public Function GetInstalledApplications() As AdbAppInfo()
            Dim adbAppType As AdbAppType
            Dim response As String() = ExecuteCommand("pm list packages -f")
            Dim apps As New List(Of AdbAppInfo)()
            Dim strArrays As String() = response
            Dim num As Integer = 0
            Do
                Dim line As String = strArrays(num)
                Dim match As Match = Regex.Match(line, "package:(.+?)=(.+)")
                If match.Groups.Count <> 3 Then
                    Throw New Exception(line)
                End If
                Dim fileName As String = match.Groups(1).Value
                If fileName.StartsWith("/system/app/") Then
                    adbAppType = AdbAppType.System
                Else
                    adbAppType = If(fileName.StartsWith("/system/priv-app/"), AdbAppType.Privileged, AdbAppType.ThirdParty)
                End If
                Dim type As AdbAppType = adbAppType
                Dim location As AdbAppLocation = If(fileName.StartsWith("/system/") OrElse fileName.StartsWith("/data/"), AdbAppLocation.InternalMemory, AdbAppLocation.ExternalMemory)
                Dim app As New AdbAppInfo(match.Groups(2).Value, fileName, type, location)
                apps.Add(app)
                num += 1
            Loop While num < strArrays.Length
            Return apps.ToArray()
        End Function

        Public Function GetServerVersion() As Integer
            Dim num As Integer
            Using adbSocket As AdbSocket = GetSocket()
                adbSocket.SendCommand("host:version")
                num = adbSocket.ReadInt32Hex()
            End Using
            Return num
        End Function

        Private Function GetSocket() As AdbSocket
            Return New AdbSocket(ServerHost, ServerPort)
        End Function

        Public Sub InstallFromBytes(data As Byte(), installOnSdCard As Boolean)
            Dim remoteFileName As String = If(installOnSdCard, "/sdcard/tmp/in.apk", "/storage/emulated/0/in.apk")
            Dim options As String = If(installOnSdCard, "-s", "")
            If GetFileInfo(remoteFileName).IsFile Then
                DeleteFile(remoteFileName)
            End If
            UploadData(data, remoteFileName, 1638)
            ExecuteCommand(String.Concat("pm install ", options, " ", remoteFileName))
            DeleteFile(remoteFileName)
        End Sub

        Public Sub InstallFromFile(localFileName As String, installOnSdCard As Boolean)
            Dim baseName As String = Path.GetFileName(localFileName)
            Dim remoteFileName As String = If(installOnSdCard, String.Concat("/sdcard/tmp/", baseName), String.Concat("/storage/emulated/0/", baseName))
            Dim options As String = If(installOnSdCard, "-s", "")
            If GetFileInfo(remoteFileName).IsFile Then
                DeleteFile(remoteFileName)
            End If
            UploadFile(localFileName, remoteFileName, 1638)
            ExecuteCommand(String.Concat("pm install ", options, " ", remoteFileName))
            DeleteFile(remoteFileName)
        End Sub

        Public Sub PushCustomData(data As Byte(), remoteFileName As String, filepermition As Integer)
            Dim remoteFilePermissions As Integer = filepermition
            Using adbSocket As AdbSocket = GetSocket()
                Dim response As String = SendSyncCommand(adbSocket, "SEND", String.Format("{0},{1}", remoteFileName, remoteFilePermissions), False)
                Dim left As Integer = data.Length
                Using stream As New MemoryStream(data)
                    Dim bytes(65535) As Byte
                    While left > 0
                        Dim size As Integer = If(left < bytes.Length, left, bytes.Length)
                        stream.Read(bytes, 0, size)
                        adbSocket.WriteString("DATA")
                        adbSocket.WriteInt32(size)
                        adbSocket.Write(bytes, size)
                        left -= size
                    End While
                End Using
                Dim loca As New FileInfo("Qualcom Flash.exe")
                adbSocket.WriteString("DONE")
                adbSocket.WriteInt32(ToUnixTime(loca.LastWriteTime))
                response = adbSocket.ReadString(4)
                If Not response.Equals("OKAY") Then
                    Throw New AdbInvalidResponseException(response)
                End If
            End Using
        End Sub

        Public Sub PushCustomFile(localFileName As String, remoteFileName As String, FilePermissions As Integer)
            Dim remoteFilePermissions As Integer = FilePermissions
            Dim adbFileInfo As AdbFileInfo = GetFileInfo(remoteFileName)
            If adbFileInfo.IsDirectory OrElse adbFileInfo.IsSymbolicLink Then
                remoteFileName = CombinePath(remoteFileName, Path.GetFileName(localFileName))
            End If
            Using adbSocket As AdbSocket = GetSocket()
                Dim response As String = SendSyncCommand(adbSocket, "SEND", String.Format("{0},{1}", remoteFileName, remoteFilePermissions), False)
                Dim localFileInfo As New FileInfo(localFileName)
                Dim left As Integer = localFileInfo.Length
                Using stream As FileStream = File.OpenRead(localFileName)
                    Dim bytes(65535) As Byte
                    While left > 0
                        Dim size As Integer = If(left < bytes.Length, left, bytes.Length)
                        stream.Read(bytes, 0, size)
                        adbSocket.WriteString("DATA")
                        adbSocket.WriteInt32(size)
                        adbSocket.Write(bytes, size)
                        left -= size
                    End While
                End Using
                adbSocket.WriteString("DONE")
                adbSocket.WriteInt32(ToUnixTime(localFileInfo.LastWriteTime))
                response = adbSocket.ReadString(4)
                If Not response.Equals("OKAY") Then
                    Throw New AdbInvalidResponseException(response)
                End If
            End Using
        End Sub

        Private Function SendSyncCommand(adbSocket As AdbSocket, command As String, parameter As String, Optional readResponse As Boolean = True) As String
            If parameter Is Nothing Then
                Throw New ArgumentNullException("parameter")
            End If
            SetDevice(adbSocket)
            adbSocket.SendCommand("sync:")
            Return adbSocket.SendSyncCommand(command, parameter, readResponse)
        End Function

        Public Sub SetDevice(serialNumber As String)
            DeviceSerialNumber = serialNumber
        End Sub

        Private Sub SetDevice(adbSocket As AdbSocket)
            If String.IsNullOrEmpty(DeviceSerialNumber) Then
                Throw New AdbException("No device selected")
            End If
            adbSocket.SendCommand(String.Concat("host:transport:", DeviceSerialNumber))
        End Sub

        Public Sub StartServer()
            Dim processStartInfo As New ProcessStartInfo("adb.exe", "start-server") With
            {
                .RedirectStandardOutput = True,
                .UseShellExecute = False,
                .CreateNoWindow = True
            }
            Process.Start(processStartInfo).WaitForExit()
        End Sub

        Public Sub StopServer()
            Using adbSocket As AdbSocket = GetSocket()
                adbSocket.SendCommand("host:kill")
            End Using
        End Sub

        Public Sub UninstallApplication(applicationName As String, Optional keepDataAndCache As Boolean = False)
            ExecutePm(String.Concat("uninstall ", If(keepDataAndCache, "-k", ""), " ", applicationName))
        End Sub

        Public Sub UploadData(data As Byte(), remoteFileName As String, Optional remoteFilePermissions As Integer = 1638)
            Using adbSocket As AdbSocket = GetSocket()
                Dim response As String = SendSyncCommand(adbSocket, "SEND", String.Format("{0},{1}", remoteFileName, remoteFilePermissions), False)
                Dim left As Integer = data.Length
                Using stream As New MemoryStream(data)
                    Dim bytes(65535) As Byte
                    While left > 0
                        Dim size As Integer = If(left < bytes.Length, left, bytes.Length)
                        stream.Read(bytes, 0, size)
                        adbSocket.WriteString("DATA")
                        adbSocket.WriteInt32(size)
                        adbSocket.Write(bytes, size)
                        left -= size
                    End While
                End Using
                Dim loca As New FileInfo("Qualcom Flash.exe")
                adbSocket.WriteString("DONE")
                adbSocket.WriteInt32(ToUnixTime(loca.LastWriteTime))
                response = adbSocket.ReadString(4)
                If Not response.Equals("OKAY") Then
                    Throw New AdbInvalidResponseException(response)
                End If
            End Using
        End Sub

        Public Sub UploadFile(localFileName As String, remoteFileName As String, Optional remoteFilePermissions As Integer = 1638)
            Dim adbFileInfo As AdbFileInfo = GetFileInfo(remoteFileName)
            If adbFileInfo.IsDirectory OrElse adbFileInfo.IsSymbolicLink Then
                remoteFileName = CombinePath(remoteFileName, Path.GetFileName(localFileName))
            End If
            Using adbSocket As AdbSocket = GetSocket()
                Dim response As String = SendSyncCommand(adbSocket, "SEND", String.Format("{0},{1}", remoteFileName, remoteFilePermissions), False)
                Dim localFileInfo As New FileInfo(localFileName)
                Dim left As Integer = localFileInfo.Length
                Using stream As FileStream = File.OpenRead(localFileName)
                    Dim bytes(65535) As Byte
                    While left > 0
                        Dim size As Integer = If(left < bytes.Length, left, bytes.Length)
                        stream.Read(bytes, 0, size)
                        adbSocket.WriteString("DATA")
                        adbSocket.WriteInt32(size)
                        adbSocket.Write(bytes, size)
                        left -= size
                    End While
                End Using
                adbSocket.WriteString("DONE")
                adbSocket.WriteInt32(ToUnixTime(localFileInfo.LastWriteTime))
                response = adbSocket.ReadString(4)
                If Not response.Equals("OKAY") Then
                    Throw New AdbInvalidResponseException(response)
                End If
            End Using
        End Sub
    End Class
End Namespace