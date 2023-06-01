Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports Microsoft.VisualBasic

Namespace Mediatek.Authentication
    Public Class Python
        Public Shared Property Authentication As String
        Public Shared Property Emmcid As String
        Private Shared Property Result As Object
        Public Shared DataTable As DataTable = New DataTable()

        Public Shared Sub Exploits(cmd As String, worker As BackgroundWorker, ee As DoWorkEventArgs)
            Dim startInfo As ProcessStartInfo = New ProcessStartInfo(Pythonfile.Python, cmd) With {
                .CreateNoWindow = True,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = False,
                .Verb = "runas",
                .WorkingDirectory = Pythonfile.Broomwork,
                .RedirectStandardError = True,
                .RedirectStandardOutput = True
            }

            Using process As Process = Process.Start(startInfo)
                Console.WriteLine(cmd)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                If worker.CancellationPending Then
                    process.Dispose()
                    ee.Cancel = True
                    Return
                Else
                    AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                               Dim args As String = If(e.Data, String.Empty)

                                                               If args <> String.Empty Then

                                                                   If args.Contains("Found device:") Then
                                                                       RichLogs(" Found devices : ", Color.WhiteSmoke, True, False)
                                                                       RichLogs(Mediatek_list.Listport.MtkComport, Color.Yellow, False, True)
                                                                   End If

                                                                   If args.Contains("Device hw code:") Then
                                                                       RichLogs(" hw code : ", Color.WhiteSmoke, True, False)
                                                                       Dim text As String = args.Substring(args.IndexOf("]") + 2)
                                                                       RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                   End If

                                                                   If args.Contains("Device hw sub code:") Then
                                                                       RichLogs(" hw sub code : ", Color.WhiteSmoke, True, False)
                                                                       Dim text As String = args.Substring(args.IndexOf("]") + 2)
                                                                       RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                   End If

                                                                   If args.Contains("Device hw version:") Then
                                                                       RichLogs(" hw version : ", Color.WhiteSmoke, True, False)
                                                                       Dim text As String = args.Substring(args.IndexOf("]") + 2)
                                                                       RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                   End If

                                                                   If args.Contains("Device sw version:") Then
                                                                       RichLogs(" sw version : ", Color.WhiteSmoke, True, False)
                                                                       Dim text As String = args.Substring(args.IndexOf("]") + 2)
                                                                       RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                   End If

                                                                   If args.Contains("Device secure boot:") Then
                                                                       RichLogs(" scb enable : ", Color.WhiteSmoke, True, False)
                                                                       Dim text As String = args.Substring(args.IndexOf("]") + 2)
                                                                       RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                   End If

                                                                   If args.Contains("Device serial link authorization:") Then
                                                                       RichLogs(" sla enable : ", Color.WhiteSmoke, True, False)
                                                                       Dim text As String = args.Substring(args.IndexOf("]") + 2)
                                                                       RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                   End If

                                                                   If args.Contains("Device download agent authorization:") Then
                                                                       RichLogs(" DAA enable : ", Color.WhiteSmoke, True, False)
                                                                       Dim text As String = args.Substring(args.IndexOf("]") + 2)
                                                                       RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                   End If

                                                                   If args.Contains("Disabling watchdog timer") Then
                                                                       RichLogs(" Disabling watchdog timer ...", Color.WhiteSmoke, False, True)
                                                                   End If

                                                                   If args.Contains("Disabling protection") Then
                                                                       RichLogs(" Disabling protection ... ", Color.WhiteSmoke, True, False)
                                                                   End If

                                                                   If args.Contains("Protection disabled") Then
                                                                       RichLogs("done ✓", Color.Lime, True, True)
                                                                   End If

                                                                   If args.Contains("Insecure device") Then
                                                                       RichLogs(" Disabling protection ... ", Color.WhiteSmoke, True, False)
                                                                       RichLogs(" Error", Color.Red, True, True)
                                                                   End If

                                                                   If args.Contains("Found send_dword") Then
                                                                       RichLogs(vbLf & " please reconect device ...", Color.Yellow, False, True)
                                                                   End If

                                                                   If args.Contains("Payload did not reply") Then
                                                                       RichLogs("failed", Color.Red, False, True)
                                                                       worker.CancelAsync()
                                                                       ee.Cancel = True
                                                                       Return
                                                                   End If
                                                               End If
                                                           End Sub

                    process.WaitForExit()
                End If
            End Using
        End Sub

        Public Shared Sub Command(cmd As String, worker As BackgroundWorker, ee As DoWorkEventArgs)
            Dim str As String = String.Format("{0}/{1}", Path.GetDirectoryName(Pythonfile.mtk), Pythonfile.arg)
            Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo(Pythonfile.Python, str & " " & cmd) With {
                .CreateNoWindow = True,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = False,
                .Verb = "runas",
                .RedirectStandardError = True,
                .RedirectStandardOutput = True
            }

            Using process As Process = Process.Start(processStartInfo)
                Console.WriteLine(str & " " & cmd)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                If worker.CancellationPending Then
                    process.Dispose()
                    ee.Cancel = True
                    Return
                Else
                    AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                               Dim text As String = If(e.Data, String.Empty)

                                                               If text <> String.Empty Then
                                                                   Console.WriteLine(text)

                                                                   If text.Contains("Preloader") Then

                                                                       If text.Contains("CPU") Then

                                                                           If Mediatek_list.Listport.MtkComport = "" Then
                                                                               RichLogs(" Found devices: ", Color.WhiteSmoke, True, False)
                                                                               RichLogs("Found", Color.Yellow, False, True)
                                                                           Else
                                                                               RichLogs(" Found devices: ", Color.WhiteSmoke, True, False)
                                                                               RichLogs(Mediatek_list.Listport.MtkComport, Color.Yellow, False, True)
                                                                           End If

                                                                           RichLogs(" Hardware Information ... ", Color.WhiteSmoke, False, True)
                                                                           RichLogs(" Hardware: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("WDT") Then
                                                                           RichLogs(" WDT: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.Aqua, False, False)
                                                                       End If

                                                                       If text.Contains("Uart:") Then
                                                                           RichLogs(" Uart: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.Yellow, False, True)
                                                                       End If

                                                                       If text.Contains("Brom payload") Then
                                                                           RichLogs(" Brom Addr: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.Orange, False, False)
                                                                       End If

                                                                       If text.Contains("DA payload") Then
                                                                           RichLogs(" DA Addr: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.MediumSpringGreen, False, True)
                                                                       End If

                                                                       If text.Contains("CQ_DMA") Then
                                                                           RichLogs(" CQDMA Addr: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.Cyan, False, False)
                                                                       End If

                                                                       If text.Contains("Var1") Then
                                                                           RichLogs(" Var Addr: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.Fuchsia, False, True)
                                                                       End If

                                                                       If text.Contains("Disabling Watchdog") Then
                                                                           RichLogs(" Disabling watchdog timer ... ", Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("ME_ID") Then
                                                                           RichLogs(" MEID: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("SOC_ID") Then
                                                                           RichLogs(" SOCID: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Handshake failed") Then
                                                                           ee.Cancel = True
                                                                       End If
                                                                   End If

                                                                   If text.Contains("PLTools") Then

                                                                       If text.Contains("Loading payload") Then
                                                                           RichLogs(" Loading payload: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2).Replace(text.Substring(text.LastIndexOf(",")), ""), Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Successfully sent payload:") Then
                                                                           RichLogs(" done ✓", Color.Lime, True, True)
                                                                       End If
                                                                   End If

                                                                   If text.Contains("Kamakiri") Then

                                                                       If text.Contains("Trying kamakiri2") Then
                                                                           RichLogs(" Disabling protection ... ", Color.WhiteSmoke, True)
                                                                       End If
                                                                   End If

                                                                   If text.Contains("DAXFlash") Then

                                                                       If text.Contains("Uploading xflash") Then
                                                                           RichLogs(" Sending DA: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2) & " ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Successfully received DA") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Error jumping to DA") Or text.Contains("Error on jumping to DA") Or text.Contains("Error on sending DA") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Sending emi data ...") Then
                                                                           RichLogs(" Sending EMI data ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Sending emi data succeeded") Then
                                                                           RichLogs("  done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Error on sending emi") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Uploading stage 2") Then
                                                                           RichLogs(" Uploading stage II ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Successfully uploaded stage 2") Then
                                                                           RichLogs("succes ✓✓", Color.Aqua, False, True)
                                                                       End If

                                                                       If text.Contains("Error on sending data") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("EMMC ID") Then
                                                                           RichLogs(" EMMCID" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("EMMC CID") Then
                                                                           Emmcid = text.Substring(text.IndexOf(":") + 2)
                                                                       End If

                                                                       If text.Contains("EMMC Boot1") Then
                                                                           RichLogs(" Boot1  : ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf(":") + 2)) / 1024.0), Color.Yellow, False, False)
                                                                       End If

                                                                       If text.Contains("EMMC Boot2") Then
                                                                           RichLogs(" Boot2 : ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf(":") + 2)) / 1024.0), Color.Fuchsia, False, False)
                                                                       End If

                                                                       If text.Contains("EMMC RPMB") Then
                                                                           RichLogs(" RPMB : ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf(":") + 2)) / 1024.0), Color.Cyan, False, True)
                                                                       End If

                                                                       If text.Contains("EMMC USER") Then
                                                                           RichLogs(" Userarea: ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf(":") + 2)) / 1024.0), Color.WhiteSmoke, False, True)
                                                                           RichLogs(" EMMC CID: ", Color.WhiteSmoke, True)
                                                                           RichLogs(Emmcid, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("UFS ID") Then
                                                                           RichLogs(" UFSID" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("UFS CID") Then
                                                                           Emmcid = text.Substring(text.IndexOf(":") + 2)
                                                                       End If

                                                                       If text.Contains("UFS LU2 Size") Then
                                                                           RichLogs(" Boot1" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf(":") + 2)) / 1024.0), Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("UFS LU1 Size") Then
                                                                           RichLogs(" Boot2" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf(":") + 2)) / 1024.0), Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("UFS LU0 Size") Then
                                                                           RichLogs(" Userarea: ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf(":") + 2)) / 1024.0), Color.WhiteSmoke, False, True)
                                                                           RichLogs(" UFS CID : ", Color.WhiteSmoke, True)
                                                                           RichLogs(Emmcid, Color.WhiteSmoke, False, True)
                                                                       End If
                                                                   End If

                                                                   If text.Contains("DA_handler") Then

                                                                       If text.Contains("Device in BROM mode") Then
                                                                           RichLogs(" Device connected in BROM mode ...", Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Trying to dump preloader") Then
                                                                           RichLogs(" Waiting dump preloader ...", Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("No preloader given") Then
                                                                           RichLogs(" No preloader given form brom ...", Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("trying dump preloader from ram") Then
                                                                           RichLogs(" trying dump preloader from ram ...", Color.WhiteSmoke, False, True)
                                                                       End If
                                                                   End If

                                                                   If text.Contains("Successfully extracted preloader") Then
                                                                       RichLogs(" successfully dump : ", Color.WhiteSmoke, True, False)
                                                                       Mediatek_tool.Mediatek.Preloaderunlock = text.Substring(text.IndexOf(":") + 2)
                                                                       RichLogs(Mediatek_tool.Mediatek.Preloaderunlock, Color.WhiteSmoke, False, True)
                                                                   End If

                                                                   If text.Contains("DALegacy") Then

                                                                       If text.Contains("Uploading da") Then
                                                                           RichLogs(" Sending DA : ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Uploading legacy da") Then
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2) & " ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Got loader sync !") Then
                                                                           RichLogs(" done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Reading dram nand info") Then
                                                                           RichLogs(" Reading dram nand info ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Error on sending brom") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Successfully uploaded stage 2") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Connected to preloader step1") Then
                                                                           RichLogs(" Connected to preloader ... ", Color.WhiteSmoke, True, False)
                                                                       End If

                                                                       If text.Contains("Connected to preloader step2") Then
                                                                           RichLogs("success ✓✓", Color.Aqua, False, True)
                                                                       End If
                                                                   End If

                                                                   If text.Contains("m_ext_ram_size =") Then
                                                                       RichLogs(" Ram : ", Color.WhiteSmoke, True)
                                                                       RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf("=") + 2)) / 1024.0), Color.Orange, False, False)
                                                                   End If

                                                                   If text.Contains("m_emmc_") Then

                                                                       If text.Contains("m_emmc_boot1_size =") Then
                                                                           RichLogs(" Boot1 : ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf("=") + 2)) / 1024.0), Color.Yellow, False, False)
                                                                       End If

                                                                       If text.Contains("m_emmc_boot2_size =") Then
                                                                           RichLogs(" Boot2 : ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf("=") + 2)) / 1024.0), Color.Fuchsia, False, False)
                                                                       End If

                                                                       If text.Contains("m_emmc_rpmb_size =") Then
                                                                           RichLogs(" RPMB : ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf("=") + 2)) / 1024.0), Color.Cyan, False, True)
                                                                       End If

                                                                       If text.Contains("m_emmc_ua_size =") Then
                                                                           RichLogs(" Userarea: ", Color.WhiteSmoke, True)
                                                                           RichLogs(GetFileCalc(ParseHexString(text.Substring(text.IndexOf("=") + 2)) / 1024.0), Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("m_emmc_cid =") Then
                                                                           RichLogs(" EMMC CID: ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf("=") + 2), Color.WhiteSmoke, False, True)
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Universalreadinfo" Then

                                                                       If text.Contains("Requesting available partitions") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Dumping partition") Then
                                                                           RichLogs(" Reading Device info ... ", Color.WhiteSmoke, False, False)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                           Return
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                           Mediatek_tool.FlashOption.progres = Integer.Parse(array2(0))
                                                                       End If

                                                                       If text.Contains("Dumped sector") Then
                                                                           Mediatek_tool.Android.AndroidUnpact(Path.GetFileName(Mediatek_tool.Sourcefile.Dumped), Path.GetDirectoryName(Mediatek_tool.Sourcefile.Andoidpath) & "\initrd\", worker, ee)
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "UniversalUnlock" Then

                                                                       If text.Contains("DA Extensions successfully added") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " Unlocked Bootloader ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Done") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Successfully wrote seccfg") Then
                                                                           RichLogs("done ✓", Color.Chartreuse, True, True)
                                                                       End If

                                                                       If text.Contains("Error on writing seccfg") Or text.Contains("Couldn't detect existing seccfg") Or text.Contains("Unknown seccfg partition header") Then
                                                                           RichLogs(Environment.NewLine & " Unlocked Bootloader ... ", Color.WhiteSmoke, True, False)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                           Return
                                                                       End If

                                                                       If text.Contains("Device has is either already unlocked") Then
                                                                           RichLogs(Environment.NewLine & " Devices already unlocked ...!  ", Color.Gold, True, False)
                                                                           RichLogs(" [Process auto aborted !!!]", Color.Orange, True, False)
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                           Return
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Universalrelock" Then

                                                                       If text.Contains("DA Extensions successfully added") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " locked Bootloader ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Done") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Successfully wrote seccfg") Then
                                                                           RichLogs("done ✓", Color.Chartreuse, True, True)
                                                                       End If

                                                                       If text.Contains("Error on writing seccfg") Or text.Contains("Couldn't detect existing seccfg") Or text.Contains("Unknown seccfg partition header") Then
                                                                           RichLogs(Environment.NewLine & " locked Bootloader ... ", Color.WhiteSmoke, True, False)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                           Return
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Universalformat" Then

                                                                       If text.Contains("check partition") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " Formatted" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs("Data", Color.DarkOrange, False, True)
                                                                       End If

                                                                       If text.Contains("done") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Formatting addr:") Then
                                                                           RichLogs(" Addres_hex" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2).Replace(text.Substring(text.LastIndexOf("w")), "").Replace(" ", ""), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("with length:") Then
                                                                           RichLogs(" Lenght_hex" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.LastIndexOf(":") + 2), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("Format done") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar1.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " Formatted data ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Couldn't detect partition") Then
                                                                           RichLogs(Environment.NewLine & " Formatted data ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                           Return
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Universalfrp" Then

                                                                       If text.Contains("check partition") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " Errasing" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs("FRP", Color.DarkOrange, False, True)
                                                                       End If

                                                                       If text.Contains("done") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Formatting addr:") Then
                                                                           RichLogs(" Addres_hex" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2).Replace(text.Substring(text.LastIndexOf("w")), "").Replace(" ", ""), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("with length:") Then
                                                                           RichLogs(" Lenght_hex" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.LastIndexOf(":") + 2), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("Format done") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar1.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " Errasing FRP protection ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Couldn't detect partition") Then
                                                                           RichLogs(Environment.NewLine & " Errasing FRP protection ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                           Return
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Universalmierse" Then

                                                                       If text.Contains("check partition") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " Errasing" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs("Mi Account", Color.DarkOrange, False, True)
                                                                       End If

                                                                       If text.Contains("done") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Formatting addr:") Then
                                                                           RichLogs(" Addres_hex" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2).Replace(text.Substring(text.LastIndexOf("w")), "").Replace(" ", ""), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("with length:") Then
                                                                           RichLogs(" Lenght_hex" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.LastIndexOf(":") + 2), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("Format done") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar1.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " Erase Mi Account ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Couldn't detect partition") Then
                                                                           RichLogs(Environment.NewLine & " Erase Mi Account ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                           Return
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Readgpttable" Then
                                                                       DataTable = New DataTable()
                                                                       DataTable.Rows.Clear()
                                                                       DataTable.Columns.Add("Partition")
                                                                       DataTable.Columns.Add("Offset")
                                                                       DataTable.Columns.Add("Length")
                                                                       DataTable.Columns.Add("Flags")
                                                                       DataTable.Columns.Add("UUID")
                                                                       DataTable.Columns.Add("Type")
                                                                       Dim dataRow As DataRow = DataTable.NewRow()
                                                                       DataTable.Rows.Clear()

                                                                       If text.Contains("GPT Table:") Then
                                                                           Mediatek_list.Datarows.MtkDataview.Clear()
                                                                           RichLogs(Environment.NewLine & " Reading gpt table ... ", Color.Gold, True)
                                                                       End If

                                                                       If text.Contains("PartName") Then
                                                                           Dim array As String() = text.Split(New Char() {":"c})

                                                                           For i As Integer = 0 To array.Length - 1
                                                                               Dim text2 As String = GetFirstFromSplit(array(i), ","c).Replace("PartName", "").Replace("Flags", ",").Replace("UUID", "").Replace("Type", "").Replace(" ", "").Trim().TrimStart(Nothing).TrimEnd(Nothing)
                                                                               dataRow(i) = text2.Replace("Offset", "").Replace("Length", "").Replace(",0x", "0x")
                                                                               Console.WriteLine(text2.Replace("Offset", "").Replace("Length", "").Replace(",0x", "0x"))
                                                                           Next

                                                                           DataTable.Rows.Add(dataRow)

                                                                           If DataTable.Rows.Count > 0 Then

                                                                               For i As Integer = 0 To DataTable.Rows.Count - 1
                                                                                   MtkFlash.SharedUI.QlMGPTGrid.Invoke(Sub()
                                                                                                                           MtkFlash.SharedUI.QlMGPTGrid.Rows.Add(False, DataTable.Rows(i)("Partition").ToString(), DataTable.Rows(i)("Offset").ToString(), DataTable.Rows(i)("Length").ToString(), "double click ...", DataTable.Rows(i)("Flags").ToString(), DataTable.Rows(i)("UUID").ToString())
                                                                                                                       End Sub)
                                                                               Next
                                                                           End If
                                                                       End If

                                                                       If text.Contains("Total disk size") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Readinfogpt" OrElse Mediatek_tool.FlashOption.Method = "READ INFO" Then

                                                                       If text.Contains("Requesting available partitions") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Dumping partition") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                           RichLogs(" Reading Device info ... ", Color.WhiteSmoke, False, False)
                                                                           Return
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                           Mediatek_tool.FlashOption.progres = Integer.Parse(array2(0))
                                                                       End If

                                                                       If text.Contains("Dumped sector") Then
                                                                           Dim texts As String = Path.GetDirectoryName(Mediatek_tool.Sourcefile.Andoidpath) & "\initrd\"
                                                                           Mediatek_tool.Android.AndroidUnpact(Path.GetFileName(Mediatek_tool.Sourcefile.Dumped), texts, worker, ee)
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Erasegpttable" Then

                                                                       If text.Contains("check partition") Then
                                                                           RichLogs(vbLf & " Formated partition Sector count ... " & Environment.NewLine, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Formatted sector:") Then
                                                                           RichLogs(" Addres_hex : ", Color.WhiteSmoke, True)
                                                                           RichLogs("0x" & text.Substring(text.IndexOf(":") + 2).Replace(text.Substring(text.LastIndexOf("w")), "").Replace(" ", ""), Color.Gold, True)
                                                                           RichLogs(" Lenght_hex : ", Color.WhiteSmoke, True)
                                                                           RichLogs("0x" & text.Substring(text.LastIndexOf(":") + 2).Replace(".", ""), Color.Gold, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Format done") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("All partitions formatted") Then
                                                                           RichLogs(vbLf & " Formated all partition success ...!", Color.FromArgb(255, 160, 66), False, True)
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Readpartitiontable" Then

                                                                       If text.Contains("Requesting available partitions") Then
                                                                           RichLogs(vbLf & " Requesting  partitions ... " & Environment.NewLine, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Dumping partition") Then
                                                                           RichLogs(" Read partition : ", Color.WhiteSmoke, True)
                                                                           text = text.Substring(text.IndexOf("""") - 1).Replace("""", "")
                                                                           RichLogs(text, Color.DarkOrange, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Dumped sector:") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("All partitions were dumped") Then
                                                                           RichLogs(vbLf & " Read all partition success ...!", Color.FromArgb(255, 160, 66), False, True)
                                                                       End If

                                                                       If text.Contains("Done |") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If
                                                                   End If



                                                                   If Mediatek_tool.FlashOption.Method = "Customflash" Then

                                                                       If text.Contains("Checking available partitions") Then
                                                                           RichLogs(vbLf & " Checking partitions ..." & Environment.NewLine, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Writing partition") Then
                                                                           Dim text2 As String = text.Substring(text.IndexOf(":") + 2)
                                                                           RichLogs(" Writing partition : ", Color.WhiteSmoke, True)
                                                                           RichLogs(Path.GetFileName(text2), Color.Gold, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Wrote") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Data ack failed for sdmmc_write_data") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Done |") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If
                                                                   End If






                                                                   If Mediatek_tool.FlashOption.Method = "Writepartitiontable" Then

                                                                       If text.Contains("Checking available partitions") Then
                                                                           RichLogs(vbLf & " Checking partitions ..." & Environment.NewLine, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Writing partition") Then
                                                                           Dim text2 As String = text.Substring(text.IndexOf(":") + 2)
                                                                           RichLogs(" Writing partition : ", Color.WhiteSmoke, True)
                                                                           RichLogs(Path.GetFileName(text2), Color.Gold, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Wrote") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Data ack failed for sdmmc_write_data") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Done |") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Bacupnvram" Then

                                                                       If text.Contains("Requesting available partitions") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(vbLf & " Requesting  partitions ... " & Environment.NewLine, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Dumping partition") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                           RichLogs(" Read partition : ", Color.WhiteSmoke, True)
                                                                           text = text.Substring(text.IndexOf("""") - 1).Replace("""", "")
                                                                           RichLogs(text, Color.DarkOrange, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Couldn't detect partition:") Then
                                                                           RichLogs(" Read partition : ", Color.WhiteSmoke, True)
                                                                           text = text.Substring(text.IndexOf("n:") + 2).Replace("""", "")
                                                                           RichLogs(text, Color.DarkOrange, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                           RichLogs(" out suport ", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Dumped sector:") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Erasenvram" Then

                                                                       If text.Contains("check partition") Then
                                                                           RichLogs(vbLf & " Formated partition Sector count ... " & Environment.NewLine, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Formatted sector") Then
                                                                           RichLogs(" Addres_hex : ", Color.WhiteSmoke, True)
                                                                           RichLogs("0x" & text.Substring(text.IndexOf(":") + 2).Replace(text.Substring(text.LastIndexOf("w")), "").Replace(" ", ""), Color.Gold, True)
                                                                           RichLogs(" Lenght_hex : ", Color.WhiteSmoke, True)
                                                                           RichLogs("0x" & text.Substring(text.LastIndexOf(":") + 2), Color.Gold, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Couldn't detect partition:") Then
                                                                           RichLogs(" Addres partition : ", Color.WhiteSmoke, True)
                                                                           text = text.Substring(text.IndexOf("n:") + 2).Replace("""", "")
                                                                           RichLogs(text, Color.DarkOrange, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                           RichLogs(" not found ", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Format done") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("All partitions formatted") Then
                                                                           RichLogs(vbLf & " Formated all partition success ...!", Color.FromArgb(255, 160, 66), False, True)
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "Restorenvram" Then

                                                                       If text.Contains("Checking available partitions") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(vbLf & " Checking partitions ..." & Environment.NewLine, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Writing partition") Then
                                                                           Dim text2 As String = text.Substring(text.IndexOf(":") + 2)
                                                                           RichLogs(" Writing partition : ", Color.WhiteSmoke, True)
                                                                           RichLogs(Path.GetFileName(text2), Color.Gold, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Wrote") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Data ack failed for sdmmc_write_data") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Done |") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "ReadRPMB" Then

                                                                       If text.Contains("DA Extensions successfully added") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(vbLf & " Reading rpmbkey ... ", Color.WhiteSmoke, True, False)
                                                                       End If

                                                                       If text.Contains("Done |") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Done reading rpmb") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Couldn't read rpmb") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           process.Close()
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                       End If

                                                                       If text.Contains("cannot run read rpmb") Then
                                                                           RichLogs(vbLf & " Reading rpmbkey ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           process.Close()
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "WriteRPMB" Then

                                                                       If text.Contains("Generating sej rpmbkey") Then
                                                                           RichLogs(vbLf & " Getting writen rpmbkey ... ", Color.WhiteSmoke, True, False)
                                                                       End If

                                                                       If text.Contains("Done reading writing") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Couldn't write rpmb") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           process.Close()
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                       End If

                                                                       If text.Contains("cannot run write rpmb cmd") Then
                                                                           RichLogs(vbLf & " Getting writen rpmbkey ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           process.Close()
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "EraseRPMB" Then

                                                                       If text.Contains("Generating sej rpmbkey") Then
                                                                           RichLogs(vbLf & " Getting erase rpmbkey ... ", Color.WhiteSmoke, True, False)
                                                                       End If

                                                                       If text.Contains("Done erasing rpmb") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Couldn't erase rpmb") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           process.Close()
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                       End If

                                                                       If text.Contains("cannot run erase rpmb") Then
                                                                           RichLogs(vbLf & " Getting erase rpmbkey ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           process.Close()
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "EraseSAMfrp" Then

                                                                       If text.Contains("check partition") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " Errasing" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs("FRP", Color.DarkOrange, False, True)
                                                                       End If

                                                                       If text.Contains("done") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Formatting addr:") Then
                                                                           RichLogs(" Addres_hex" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.IndexOf(":") + 2).Replace(text.Substring(text.LastIndexOf("w")), "").Replace(" ", ""), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("with length:") Then
                                                                           RichLogs(" Lenght_hex" & vbTab & ": ", Color.WhiteSmoke, True)
                                                                           RichLogs(text.Substring(text.LastIndexOf(":") + 2), Color.Gold, False, True)
                                                                       End If

                                                                       If text.Contains("Format done") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar1.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                           RichLogs(Environment.NewLine & " Errasing FRP protection ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Couldn't detect partition") Then
                                                                           RichLogs(Environment.NewLine & " Errasing FRP protection ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                           Return
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "ErasefrpOEM" Then

                                                                       If text.Contains("Checking available partitions") Then
                                                                           RichLogs(vbLf & " Checking partitions ..." & Environment.NewLine, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Writing partition") Then
                                                                           RichLogs(" Erase partition : ", Color.WhiteSmoke, True)
                                                                           RichLogs("FRP [OEM]", Color.Gold, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Wrote") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Data ack failed for sdmmc_write_data") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Done |") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Couldn't detect partition") Then
                                                                           RichLogs(" Erase partition : ", Color.WhiteSmoke, True)
                                                                           RichLogs("FRP [OEM]", Color.Gold, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           process.Close()
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "ErasefrpLOST" Then

                                                                       If text.Contains("Checking available partitions") Then
                                                                           RichLogs(vbLf & " Checking partitions ..." & Environment.NewLine, Color.WhiteSmoke, False, True)
                                                                       End If

                                                                       If text.Contains("Writing partition") Then
                                                                           RichLogs(" Erase partition : ", Color.WhiteSmoke, True)
                                                                           RichLogs("FRP LOST DATA", Color.Gold, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("Wrote") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Data ack failed for sdmmc_write_data") Then
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                       End If

                                                                       If text.Contains("Done |") Then
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Couldn't detect partition") Then
                                                                           RichLogs(" Erase partition : ", Color.WhiteSmoke, True)
                                                                           RichLogs("FRP LOST DATA", Color.Gold, True)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, False, True)
                                                                           process.Close()
                                                                           worker.CancelAsync()
                                                                           ee.Cancel = True
                                                                       End If
                                                                   End If

                                                                   If Mediatek_tool.FlashOption.Method = "readfirmware" Then

                                                                       If text.Contains(" DA Extensions successfully added") Then
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = 0
                                                                                                             End Sub)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0
                                                                                                             End Sub)
                                                                           RichLogs(" Getting read data  ... ", Color.WhiteSmoke, False, True)
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = 0

                                                                                                                 For i As Integer = 1 To 10
                                                                                                                     Main.SharedUI.Progressbar2.EditValue = i + 90
                                                                                                                 Next
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Dumping partition") Then
                                                                           RichLogs(" read partition : ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(text.Substring(text.LastIndexOf("\") + 1), Color.Orange, True, False)
                                                                           RichLogs(" ... ", Color.WhiteSmoke, True, False)
                                                                       End If

                                                                       If text.Contains("Dumped partition") Then
                                                                           RichLogs("done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Progress: |") Then
                                                                           Dim msg As String = text.Remove(0, text.IndexOf("| ")).Replace("| ", "").Replace(".", vbTab)
                                                                           Dim array2 As String() = msg.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If
                                                                   End If
                                                               End If
                                                           End Sub

                    AddHandler process.ErrorDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                              Console.WriteLine(e.Data)
                                                              Dim text As String = If(e.Data, String.Empty)

                                                              If text <> String.Empty Then

                                                                  If e.Data.Contains("struct.error:") Then
                                                                      RichLogs(Environment.NewLine & vbLf & " | USB Connection Failed ...! | ", Color.Red, False, True)
                                                                      ee.Cancel = True
                                                                  End If
                                                              End If
                                                          End Sub
                End If

                process.WaitForExit()
            End Using
        End Sub

        Public Shared Function ParseHexString(hexNumber As String) As Double
            hexNumber = hexNumber.Replace("x", String.Empty)
            Dim result As Long = Nothing
            Long.TryParse(hexNumber, NumberStyles.HexNumber, Nothing, result)
            Return result
        End Function

        Public Shared Function GetFileCalc(byteCount As Double) As String
            Dim size As String = "0 Bytes"

            If byteCount >= 1073741824.0 Then
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) & " TB"
            ElseIf byteCount >= 1048576.0 Then
                size = String.Format("{0:##.##}", byteCount / 1048576.0) & " GB"
            ElseIf byteCount >= 1024.0 Then
                size = String.Format("{0:##.##}", byteCount / 1024.0) & " MB"
            ElseIf byteCount > 0.0 AndAlso byteCount < 1024.0 Then
                size = byteCount.ToString() & " KB"
            End If

            Return size
        End Function

        Private Shared Function GetFirstFromSplit(input As String, delimiter As Char) As String
            Dim num As Integer = input.IndexOf(delimiter)
            Return If(num = -1, input, input.Substring(0, num))
        End Function

        Public Shared Sub Adbpython(cmd As String, worker As BackgroundWorker, e As DoWorkEventArgs)
            Dim process As Process = New Process With {
                .StartInfo = New ProcessStartInfo With {
                    .FileName = Pythonfile.Python,
                    .Arguments = cmd,
                    .Verb = "runas",
                    .UseShellExecute = False,
                    .CreateNoWindow = True,
                    .RedirectStandardOutput = True,
                    .RedirectStandardError = True
                }
            }

            If worker.CancellationPending Then
                e.Cancel = True
            Else
                process.Start()
            End If
        End Sub

        Public Shared Sub UpgradePython(cmd As String)
            Dim startInfo As ProcessStartInfo = New ProcessStartInfo(Pythonfile.Python, cmd) With {
                .CreateNoWindow = True,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = False,
                .Verb = "runas",
                .RedirectStandardError = True,
                .RedirectStandardOutput = True
            }

            Using process As Process = Process.Start(startInfo)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()
                AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                           Dim text As String = If(e.Data, String.Empty)

                                                           If text <> String.Empty Then
                                                               Console.WriteLine(text)
                                                           End If
                                                       End Sub

                AddHandler process.ErrorDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                          Dim text As String = If(e.Data, String.Empty)

                                                          If text <> String.Empty Then
                                                              Console.WriteLine(text)
                                                          End If
                                                      End Sub

                process.WaitForExit()
            End Using
        End Sub
    End Class
End Namespace
