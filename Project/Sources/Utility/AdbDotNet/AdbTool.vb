Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.IO.Ports
Imports System.Linq
Imports System.Net.Sockets
Imports System.Threading
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Reverse_Tool.BismillahAdb

Public Class AdbTool
        Private WaktuCari As Integer = 30
        Friend Shared SharedUI As AdbTool
        Public Shared SnAdb As String
        Dim AdbDevices As Object

        Public adbclients As AdbClient = New AdbClient
        Public Sub New()
            SharedUI = Me
        End Sub

        Public Sub OpenPorts()
            Try
                Main.SharedUI.Ports.BaudRate = 115200
                Main.SharedUI.Ports.Handshake = Handshake.None
                Main.SharedUI.Ports.DataBits = 8
                Main.SharedUI.Ports.StopBits = StopBits.One
                Main.SharedUI.Ports.Parity = Parity.None
                Main.SharedUI.Ports.DtrEnable = True
                Main.SharedUI.Ports.NewLine = Environment.NewLine
                Main.SharedUI.Ports.PortName = String.Concat("COM", Conversions.ToString(Main.PortQcom))
                Main.SharedUI.Ports.Open()

            Catch exception As Exception
                ProjectData.SetProjectError(exception)
                MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Public Sub adbcmd(AdbDotNetcmd As String, worker As BackgroundWorker, e As DoWorkEventArgs)
            adbstart(AdbDotNetcmd)
        End Sub

        Public Sub adbstart(AdbDotNetcmd As String)


            'adbclients.InstallApplication(NamaFileApk, False) 'install File
            'adbclients.InstallData(bytes, False) 'install dari BytesApk 
            'adbclients.PushCustomFile("filenameLocal",FilenameRemote,chmod ) 'push File
            'adbclients.PushCustomData(Bytes,FilenameRemote, ) ' push databytes


            If Not CheckRun() Then
                RichLogs("Server Not Running ", Color.Lime, True, True)
                RichLogs("Starting server : ", Color.Lime, True, True)
                AdbStartServer()

                If Not AdbStartServer() Then
                    RichLogs("Starting Server Failed", Color.Lime, True, True)
                    Return
                Else
                    RichLogs("Okay", Color.Lime, True, True)
                End If
            End If

            RichLogs("List Connected devices ", Color.Lime, True, True)

            Try
                For i As Integer = 0 To 30

                    Dim timeout As String = 30 - i

                    Console.WriteLine(timeout)

                    Main.SharedUI.LabelTimer.Invoke(Sub()
                                                        Main.SharedUI.LabelTimer.Text = timeout
                                                    End Sub)

                    If CariAdbDevice() Then

                        Exit For
                    End If

                    Thread.Sleep(1000)
                    If i = 30 Then
                        Exit Sub
                    End If

                Next

                RichLogs("", Color.Lime, True, True)
                RichLogs("Device Selected  : ", Color.Lime, True, False)
                RichLogs(SnAdb, Color.Lime, True, True)

                adbclients.SetDevice(SnAdb)




                AdbGetInfo()

                RichLogs("Execute Commands : ", Color.Lime, True, False)
                RichLogs(AdbDotNetcmd, Color.Lime, True, True)


                AdbShell(AdbDotNetcmd)

                RichLogs("All IS Done", Color.Lime, True, True)
            Catch ex As Exception
                If ex.ToString.Take(100).ToArray.Contains("device unauthorized") Then
                    RichLogs("Device : UnAuthorized", Color.Lime, True, True)
                ElseIf ex.ToString.Take(100).ToArray.Contains("device offline") Then
                    RichLogs("Device Offline", Color.Lime, True, True)
                Else
                    RichLogs(ex.ToString, Color.Lime, True, True)
                End If


            End Try





        End Sub
        Public Function AdbFileInstall(fileapk As String, temporerfolder As String, Chmod As Int32) As Boolean
            Try
                '/data/local/tmp/

                RichLogs("Push File :  ", Color.Lime, False, True)

                adbclients.PushCustomFile(fileapk, temporerfolder, Chmod)
                RichLogs("Okay", Color.Lime, True, True)

                RichLogs("Installing :  ", Color.Lime, False, True)
                adbclients.ExecuteCommand("pm install " & temporerfolder & fileapk)
                RichLogs("Okay", Color.Lime, True, True)
                RichLogs("Cleaning Cache :  ", Color.Lime, False, True)
                adbclients.DeleteFile(temporerfolder & fileapk)
                RichLogs("Okay", Color.Lime, True, True)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function AdbBytesInstall(data() As Byte, temporerfolder As String, Chmod As Int32) As Boolean
            Try


                RichLogs("Push File :  ", Color.Lime, False, True)

                adbclients.PushCustomData(data, temporerfolder, Chmod)
                RichLogs("Okay", Color.Lime, True, True)

                RichLogs("Installing :  ", Color.Lime, False, True)
                adbclients.ExecuteCommand("pm install " & temporerfolder)
                RichLogs("Okay", Color.Lime, True, True)
                RichLogs("Cleaning Cache :  ", Color.Lime, False, True)
                adbclients.DeleteFile(temporerfolder)
                RichLogs("Okay", Color.Lime, True, True)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Sub frp2(cmd As String)




            If Not CheckRun() Then
                RichLogs("Server Not Running ", Color.Lime, True, True)
                RichLogs("Starting server : ", Color.Lime, True, True)
                AdbStartServer()

                If Not AdbStartServer() Then
                    RichLogs("Starting Server Failed", Color.Lime, True, True)
                    Return
                Else
                    RichLogs("Okay", Color.Lime, True, True)
                End If
            End If

            RichLogs("List Connected devices ", Color.Lime, True, True)

            Try

                For i As Integer = 0 To 30
                    If CariAdbDevice() Then

                        Exit For
                    End If

                    Thread.Sleep(1000)
                    If i = 30 Then
                        Exit Sub
                    End If
                    WaktuCari -= 1
                    Main.SharedUI.LabelTimer.Invoke(CType(Sub() Main.SharedUI.LabelTimer.Text = WaktuCari, Action))
                Next


                RichLogs("", Color.Lime, True, True)
                RichLogs("Device Selected :  " & SnAdb, Color.Lime, True, False)

                adbclients.SetDevice(SnAdb)

                AdbGetInfo()

                RichLogs("Execute Commands", Color.Lime, True, True)

                Dim s = File.ReadAllBytes("me.apk")
                adbclients.InstallFromBytes(s, False)


                AdbFileInstall("me.apk", "/storage/emulated/0/", &H666)



                AdbBytesInstall(s, "/storage/emulated/0/me.apk", &H666)

                RichLogs("All Done", Color.Lime, True, True)
            Catch ex As Exception
                If ex.ToString.Take(100).ToArray.Contains("device unauthorized") Then
                    RichLogs("DEvice : UnAuthorized", Color.Lime, True, True)
                ElseIf ex.ToString.Take(100).ToArray.Contains("device offline") Then
                    RichLogs("Device Offline", Color.Lime, True, True)
                Else
                    RichLogs(ex.ToString, Color.Lime, True, True)
                End If


            End Try

        End Sub
        Public Function CariAdbDevice() As Boolean
            Try
                AdbDevices = adbclients.GetDevices()
                For Each device As Object In AdbDevices
                    RichLogs($"SN : {device.SerialNumber.ToUpper()} => Model : {device.Model} {device.Product}", Color.Lime, True, True)

                    Main.SharedUI.comboUSB.Invoke(Sub()
                                                      Main.SharedUI.comboUSB.Text = $"ADB  [ SN : {device.SerialNumber.ToUpper()} => Model : {device.Model} {device.Product} ]"
                                                  End Sub)

                Next
                SnAdb = AdbDevices(0).SerialNumber
                Return True
            Catch ex As Exception
                Return False
            End Try


            Return False
        End Function
        Public Function CheckRun() As Boolean
            Dim Client As TcpClient = Nothing
            Try
                Client = New TcpClient("127.0.0.1", 5037)
                Return True
            Catch ex As SocketException
                Return False

            End Try


        End Function

        Public Function AdbStartServer() As Boolean
            Try
                Dim MyProcess As New Process

                With MyProcess.StartInfo
                .FileName = Windows.Forms.Application.StartupPath & "/Tools/process/adb.exe"
                .Arguments = "start-server"
                    .UseShellExecute = False
                    .CreateNoWindow = True
                    .RedirectStandardInput = True
                    .RedirectStandardOutput = True
                    .RedirectStandardError = True
                    .StandardOutputEncoding = Text.Encoding.ASCII

                End With
                MyProcess.Start()
                MyProcess.WaitForExit()
                Return True
            Catch ex As Exception
                Return False
            End Try


        End Function
        Public Sub AdbShell(cmd As String)
            If cmd.Contains("=") Then
                Dim cmdlist() = cmd.Split("=")
                For i As Integer = 0 To cmdlist.Length - 1
                    adbclients.ExecuteCommand(cmdlist(i))
                    Thread.Sleep(100)

                Next
            Else
                adbclients.ExecuteCommand(cmd)
            End If
        End Sub

        Public Sub AdbGetInfo()
            Dim props = adbclients.GetDeviceProperties()
            RichLogs("Manufactures     : ", Color.Lime, True, False)
            RichLogs($"{props("ro.product.manufacturer")}", Color.Lime, True, True)

            RichLogs("Model            : ", Color.Lime, True, False)
            RichLogs($"{props("ro.product.model")}", Color.Lime, True, True)
        End Sub

        Private Sub resetsamsung(sender As Object, e As DoWorkEventArgs)
            OpenPorts()

            RichLogs("Sending Command : ", Color.Lime, False, True)
            Main.SharedUI.Ports.Write("AT+DEVCONINFO" & vbCrLf)
            Thread.Sleep(200)
            Main.SharedUI.Ports.Write("AT%FRST" & vbCrLf)
            Thread.Sleep(200)
            Main.SharedUI.Ports.Write("AT^RESET" & vbCrLf)
            Thread.Sleep(200)
            Main.SharedUI.Ports.Write("AT+FACTORST=0,0" & vbCrLf)
            Thread.Sleep(200)
            Main.SharedUI.Ports.Write("AT+CRST=FS" & vbCrLf)
            Thread.Sleep(200)

            Thread.Sleep(200)
            RichLogs("Done  ✓", Color.Lime, True, True)
            Main.SharedUI.Ports.Close()
            Main.SharedUI.LabelTimer.Invoke(CType(Sub() Main.SharedUI.LabelTimer.Text = 60, Action))
            WaktuCari = 60
        End Sub

    End Class
