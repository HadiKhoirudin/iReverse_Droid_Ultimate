Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Management
Imports System.Windows.Forms.Application
Imports Microsoft.VisualBasic

Public Class Consoles
    Public Shared PackDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts)) & "\" & "PackDir"
    Public Shared PackDirX64 As String = PackDir & "\" & "amd64"
    Public Shared PackDirX86 As String = PackDir & "\" & "x86"
    Public Shared url As String = ""
    Public Shared DeviceName As String = ""
    Public Shared Drivers As String = ""
    Public Shared Manufacturer As String = ""
    Public Shared DeviceID As String = ""
    Public Shared ClassGuid As String = ""
    Public Shared VID As String = ""
    Public Shared PID As String = ""
    Public Shared VID_PID As String = ""

    Public Shared Function FindUSBMTP() As Boolean
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher("root\cimv2", "SELECT * FROM Win32_PnPEntity WHERE PNPClass LIKE '%WPD%' ")

        For Each queryObj As ManagementObject In searcher.[Get]()

            If Not String.IsNullOrEmpty(queryObj("Name").ToString()) Then
                DeviceName = Convert.ToString(queryObj("Name"))
                Manufacturer = Convert.ToString(queryObj("Manufacturer"))
                DeviceID = Convert.ToString(queryObj("DeviceID"))
                ClassGuid = Convert.ToString(queryObj("ClassGuid")).ToUpper()
                Dim _strArrays As String() = DeviceID.Split(New Char() {"\"c})
                Dim __strArrays As String() = _strArrays(1).Split(New Char() {"&"c})

                If __strArrays(0) <> "WPDBUSENUM" Then
                    VID = __strArrays(0)
                    PID = __strArrays(1)
                    VID_PID = VID & "&" & PID
                    RichLogs("--------------------------------------------------------------------", Color.WhiteSmoke, False, True)
                    RichLogs("                        FOUND MTP USB DEVICE                        ", Color.Lime, True, True)
                    RichLogs("--------------------------------------------------------------------", Color.WhiteSmoke, False, True)
                    RichLogs("Device Name  : " & DeviceName, Color.WhiteSmoke, False, True)
                    RichLogs("Vendor Name  : " & Manufacturer, Color.WhiteSmoke, False, True)
                    RichLogs("Device ID    : " & DeviceID, Color.WhiteSmoke, False, True)
                    RichLogs("Device GUID  : " & ClassGuid, Color.WhiteSmoke, False, True)
                    RichLogs(" ", Color.WhiteSmoke, False, True)
                    Return True
                End If
            End If
        Next

        RichLogs("--------------------------------------------------------------------", Color.WhiteSmoke, False, True)
        RichLogs("                     CAN'T FOUND MTP USB DEVICE                     ", Color.Crimson, True, True)
        RichLogs("--------------------------------------------------------------------", Color.WhiteSmoke, False, True)
        Return False
    End Function

    Public Shared Sub MTPFiles(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)
        If worker.CancellationPending Then
            e.Cancel = True
            Return
        End If

        If Not Directory.Exists(PackDir) Then
            Directory.CreateDirectory(PackDir)
            File.WriteAllBytes(PackDir & "\cyggcc_s-1.dll", My.Resources.cyggcc_s_1)
            File.WriteAllBytes(PackDir & "\cygusb-1.0.dll", My.Resources.cygusb_1_0)
            File.WriteAllBytes(PackDir & "\cygwin1.dll", My.Resources.cygwin1)
            File.WriteAllBytes(PackDir & "\install_x64.exe", My.Resources.install_x64)
            File.WriteAllBytes(PackDir & "\install_x86.exe", My.Resources.install_x86)
            File.WriteAllBytes(PackDir & "\linux-adk.exe", My.Resources.linux_adk)
            File.WriteAllBytes(PackDir & "\libusb-1.0.dll", My.Resources.adk_libusb_1_0)
        End If

        If Not Directory.Exists(PackDirX64) Then
            Directory.CreateDirectory(PackDirX64)
            File.WriteAllBytes(PackDirX64 & "\libusb-1.0_x86.dll", My.Resources.amd64_libusb_1_0_x86)
            File.WriteAllBytes(PackDirX64 & "\libusb0.dll", My.Resources.amd64_libusb0)
            File.WriteAllBytes(PackDirX64 & "\libusb0.sys", My.Resources.amd64_libusb0_sys)
            File.WriteAllBytes(PackDirX64 & "\libusb0_x86.dll", My.Resources.amd64_libusb0_x86)
            File.WriteAllBytes(PackDirX64 & "\libusbK.dll", My.Resources.amd64_libusbK)
            File.WriteAllBytes(PackDirX64 & "\libusbK.sys", My.Resources.amd64_libusbK_sys)
            File.WriteAllBytes(PackDirX64 & "\WdfCoInstaller01009.dll", My.Resources.amd64_WdfCoInstaller01009)
            File.WriteAllBytes(PackDirX64 & "\winusbcoinstaller2.dll", My.Resources.amd64_winusbcoinstaller2)
        End If

        If Not Directory.Exists(PackDirX86) Then
            Directory.CreateDirectory(PackDirX86)
            File.WriteAllBytes(PackDirX86 & "\libusb0.dll", My.Resources.x86_libusb0)
            File.WriteAllBytes(PackDirX86 & "\libusb0.sys", My.Resources.x86_libusb0_sys)
            File.WriteAllBytes(PackDirX86 & "\libusb0_x86.dll", My.Resources.x86_libusb0_x86)
            File.WriteAllBytes(PackDirX86 & "\libusbK.dll", My.Resources.x86_libusbk)
            File.WriteAllBytes(PackDirX86 & "\libusbK.sys", My.Resources.x86_libusbk_sys)
            File.WriteAllBytes(PackDirX86 & "\WdfCoInstaller01009.dll", My.Resources.x86_wdfcoinstaller01009)
            File.WriteAllBytes(PackDirX86 & "\winusbcoinstaller2.dll", My.Resources.x86_winusbcoinstaller2)
        End If

        If File.Exists(PackDir & "\SAMSUNG_Android.inf") Then
            File.Delete(PackDir & "\SAMSUNG_Android.inf")
        End If

        If File.Exists(PackDir & "\SAMSUNG_Android.cat") Then
            File.Delete(PackDir & "\SAMSUNG_Android.cat")
            File.WriteAllBytes(PackDir & "\SAMSUNG_Android.cat", My.Resources.cat_SAMSUNG_Android)
        End If

        Console.WriteLine(";")
        Console.WriteLine(";++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
        Dim Inf As String
        Inf = My.Resources.SAMSUNG_Android.Replace("#DeviceName#", DeviceName).Replace("#Manufacturer#", Manufacturer).Replace("#DeviceID#", VID_PID).Replace("#ClassGuid#", ClassGuid)
        Console.WriteLine(Inf)
        Console.WriteLine(";")
        Console.WriteLine(";++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++")

        Using writer As TextWriter = New StreamWriter(PackDir & "\SAMSUNG_Android.inf", False, System.Text.Encoding.UTF8)
            writer.NewLine = vbLf
            writer.Write(Inf.ToString())
        End Using
    End Sub

    Public Shared Function LinuxAdk(ByVal cmd As String, ByVal worker As BackgroundWorker, ByVal ee As DoWorkEventArgs) As Boolean
        Dim flag As Boolean = True
        Console.WriteLine("")
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("Linux-adk Command : " & PackDir & "\linux-adk.exe" & cmd)
        Dim LinuxAdkExe As ProcessStartInfo = New ProcessStartInfo(PackDir & "\linux-adk.exe", cmd) With {
                .CreateNoWindow = True,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = False,
                .Verb = "runas",
                .WorkingDirectory = PackDir,
                .RedirectStandardError = True,
                .RedirectStandardOutput = True
            }

        Using process As Process = Process.Start(LinuxAdkExe)
            process.BeginOutputReadLine()
            process.BeginErrorReadLine()

            If worker.CancellationPending Then
                process.Dispose()
                ee.Cancel = True
            Else
                AddHandler process.OutputDataReceived, Sub(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
                                                           Dim args As String = If(e.Data, String.Empty)

                                                           If Not String.IsNullOrEmpty(args) Then
                                                               Console.WriteLine(args)

                                                               If args.Contains("Unable to open device...") Then
                                                                   flag = False
                                                               ElseIf args.Contains("Error getting protocol") Then
                                                                   flag = False
                                                               End If
                                                           End If
                                                       End Sub

                process.WaitForExit()
            End If
        End Using

        Console.WriteLine("")
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
        Return flag
    End Function

    Public Shared Function Driver(ByVal cmd As String, ByVal worker As BackgroundWorker, ByVal ee As DoWorkEventArgs) As Boolean
        Dim flag As Boolean = True
        Dim installler As String = Nothing

        If Environment.Is64BitOperatingSystem Then
            installler = "\install_x64.exe "
        Else
            installler = "\install_x86.exe "
        End If

        Console.WriteLine("")
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("Driver Command : " & PackDir & installler & cmd)
        Dim DriverExe As ProcessStartInfo = New ProcessStartInfo(PackDir & installler, cmd) With {
                .CreateNoWindow = True,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = False,
                .Verb = "runas",
                .WorkingDirectory = PackDir,
                .RedirectStandardError = True,
                .RedirectStandardOutput = True
            }

        Using process As Process = Process.Start(DriverExe)
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine(cmd)
            process.BeginOutputReadLine()
            process.BeginErrorReadLine()

            If worker.CancellationPending Then
                process.Dispose()
                ee.Cancel = True
            Else
                AddHandler process.OutputDataReceived, Sub(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
                                                           Dim args As String = If(e.Data, String.Empty)

                                                           If Not String.IsNullOrEmpty(args) Then
                                                               Console.WriteLine(args)
                                                           End If
                                                       End Sub

                process.WaitForExit()
            End If
        End Using

        Console.WriteLine("")
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
        Return flag
    End Function

    Public Shared Sub Cleaner()
        If File.Exists(PackDir & "\linux-adk.exe") Then
            Dim directory As DirectoryInfo = New DirectoryInfo(Path.GetDirectoryName(PackDir & "\linux-adk.exe"))

            For Each File As FileInfo In directory.EnumerateFiles()
                File.Delete()
            Next

            For Each subDirectory As DirectoryInfo In directory.EnumerateDirectories()
                subDirectory.Delete(True)
            Next

            directory.Delete(True)
        End If
    End Sub









    Public Shared Function AdbClass(ByVal cmd As String) As String
        Dim process As New Process With {.StartInfo = New ProcessStartInfo()}
        If True Then
            Dim withBlock = process.StartInfo
            withBlock.UseShellExecute = False
            withBlock.CreateNoWindow = True
            withBlock.FileName = System.Windows.Forms.Application.StartupPath & "\Tools\process\adb.exe"
            withBlock.Arguments = cmd
            withBlock.RedirectStandardOutput = True
        End If
        Dim adb As Process = process
        adb.Start()
        adb.WaitForExit()
        Dim output As String = adb.StandardOutput.ReadToEnd()
        Return output
    End Function

    Public Shared Function Fastboot(cmd As String, worker As BackgroundWorker, ee As DoWorkEventArgs) As String
        Dim output As String = ""
        Dim fastBootExe As New Process()
        fastBootExe.StartInfo.FileName = StartupPath & "\Tools\process\fastboot.exe"
        fastBootExe.StartInfo.Arguments = $"{cmd}"
        fastBootExe.StartInfo.CreateNoWindow = True
        fastBootExe.StartInfo.UseShellExecute = False
        fastBootExe.StartInfo.RedirectStandardOutput = True
        fastBootExe.StartInfo.RedirectStandardError = True

        If worker.CancellationPending Then
            fastBootExe.Dispose()
            ee.Cancel = True
            Return output
        Else
            fastBootExe.Start()
            Dim readerStdError = fastBootExe.StandardError
            Dim readerStdOutput = fastBootExe.StandardError
            output = readerStdError.ReadToEnd() & readerStdOutput.ReadToEnd()
            fastBootExe.WaitForExit()
        End If
        Console.WriteLine(output)
        Return output
    End Function

End Class
