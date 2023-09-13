Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports Microsoft.VisualBasic

Namespace Mediatek.Mediatek_tool
    Public Class Flash_Tool
        Public Shared logs As String = My.Resources.logs
        Public Shared stringlist As String() = logs.Split(New Char(1) {ChrW(13), ChrW(10)}, StringSplitOptions.RemoveEmptyEntries)
        Public Shared logs2 As String = My.Resources.logs1
        Public Shared logs1 As String() = logs2.Split(New Char(1) {ChrW(13), ChrW(10)}, StringSplitOptions.RemoveEmptyEntries)

        Public Shared Sub Command(cmd As String, worker As BackgroundWorker, ee As DoWorkEventArgs)
            Main.SharedUI.Progressbar1.Invoke(Sub()
                                                  Main.SharedUI.Progressbar1.EditValue = 0
                                              End Sub)
            Main.SharedUI.Progressbar2.Invoke(Sub()
                                                  Main.SharedUI.Progressbar2.EditValue = 0
                                              End Sub)
            Dim startInfo As New ProcessStartInfo(Flashpath.Flashtoolexe, cmd) With {
                .CreateNoWindow = True,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = False,
                .Verb = "runas",
                .RedirectStandardError = True,
                .RedirectStandardOutput = True
            }

            Using process As Process = Process.Start(startInfo)
                process.BeginOutputReadLine()

                If worker.CancellationPending Then
                    process.Dispose()
                    worker.CancelAsync()
                    ee.Cancel = True
                Else

                    If Flashcommand.Flasfirmware Then
                        AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                                   Dim text As String = If(e.Data, String.Empty)

                                                                   If text <> String.Empty Then
                                                                       Console.WriteLine(text)

                                                                       If text.Contains("General settings create command") Then
                                                                           RichLogs(" General create command ... ", Color.GhostWhite, False, False)
                                                                       End If

                                                                       If text.Contains("General command exec done") Then
                                                                           RichLogs("", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Connecting to BROM") Then
                                                                           RichLogs(" Connecting to BROM ... ", Color.GhostWhite, False, False)
                                                                       End If

                                                                       If text.Contains("BROM connected") Then
                                                                           RichLogs("OK", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Connect BROM failed") Then
                                                                           RichLogs("failed", Color.Crimson, False, True)
                                                                       End If

                                                                       If text.Contains("Download DA now") Then
                                                                           RichLogs(" Download DA ... ", Color.WhiteSmoke, True, False)
                                                                       End If

                                                                       If text.Contains("DA Connected") Then
                                                                           RichLogs("Done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("executing DADownloadAll") Then
                                                                           RichLogs(" Executing DA Download All ... ", Color.GhostWhite, False, False)
                                                                       End If

                                                                       If text.Contains("Stage:") Then
                                                                           RichLogs("OK ", Color.Lime, False, False)
                                                                       End If

                                                                       If text.Contains("Download Succeeded.") Then
                                                                           RichLogs("Done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("of DA has been sent.") Then
                                                                           Dim parse As String = text.Replace("% of DA has been sent.", "")
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = Integer.Parse(parse)
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("of image data has been sent") Then
                                                                           Dim text2 As String = text.Substring(0, text.IndexOf("of image data has been sent"))
                                                                           text2 = text2.Replace("%", "")
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(text2)
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("of image data has been sent") Then
                                                                           Dim text3 As String = text.Replace("% of image data has been sent", "").Replace("of", "").Replace("(", "").Replace(")", "")
                                                                           Dim array2 As String() = text3.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If

                                                                       For Each value As String In logs1

                                                                           If text.Contains(value) Then
                                                                               Console.WriteLine(e.Data)
                                                                               RichLogs(" Write Partition ... ", Color.WhiteSmoke, False, False)
                                                                               RichLogs(text.Substring(text.LastIndexOf("[") + 1).Replace(text.Substring(text.LastIndexOf("]")), ""), Color.Gold, False, False)
                                                                               RichLogs(" ... ", Color.WhiteSmoke, False, False)
                                                                               Exit For
                                                                           End If
                                                                       Next

                                                                       If text.Contains("err_msg") Then
                                                                           RichLogs(Environment.NewLine & text.Substring(text.IndexOf("g") + 2).Replace(";", "").Replace(".", ""), Color.Orange, True, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If

                                                                       If text.Contains("Please select the authentication") Then
                                                                           RichLogs(" Please select the authentication file first !!!", Color.Orange, False, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If

                                                                       If text.Contains("S_DL_GET_DRAM_SETTING_FAIL(5054)") Then
                                                                           RichLogs(vbLf & " NEED INCLUDE PRELOADER !!! ", Color.Gold, True, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If

                                                                       If text.Contains("Error: lib DA NOT match!") Then
                                                                           RichLogs(vbLf & " " & text.Substring(text.IndexOf(":") + 2), Color.Gold, True, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If

                                                                       If text.Contains("All command exec done") Then
                                                                           RichLogs("Done ✓", Color.Lime, True, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If
                                                                   End If
                                                               End Sub
                    ElseIf Flashcommand.Formatdata Then
                        AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                                   Dim text As String = If(e.Data, String.Empty)

                                                                   If text <> String.Empty Then
                                                                       Console.WriteLine(text)

                                                                       If text.Contains("Scanning USB port...") Then
                                                                           Dim listport As List(Of Mediatek_list.Listport.Info) = Mediatek_list.Listport.Devicelists()

                                                                           For Each info As Mediatek_list.Listport.Info In listport
                                                                               Main.SharedUI.ComboPort.Invoke(Sub()
                                                                                                                  Main.SharedUI.ComboPort.Properties.Items.Clear()
                                                                                                                  Main.SharedUI.ComboPort.EditValue = String.Empty
                                                                                                                  Main.SharedUI.ComboPort.Properties.Items.AddRange(New Object() {info.Mediatekport})
                                                                                                                  Main.SharedUI.ComboPort.EditValue = Main.SharedUI.ComboPort.Properties.Items(0)
                                                                                                              End Sub)
                                                                           Next
                                                                       End If

                                                                       If text.Contains("of DA has been sent.") Then
                                                                           Dim ss As String = text.Replace("% of DA has been sent.", "")
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = Integer.Parse(ss)
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("of image data has been sent") Then
                                                                           Dim text2 As String = text.Substring(0, text.IndexOf("of image data has been sent"))
                                                                           text2 = text2.Replace("%", "")
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(text2)
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("of image data has been sent") Then
                                                                           Dim text3 As String = text.Replace("% of image data has been sent", "").Replace("of", "").Replace("(", "").Replace(")", "")
                                                                           Dim array2 As String() = text3.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("of flash has been formatted") Then
                                                                           Dim text3 As String = text.Replace("% of flash has been formatted.", "").Replace("of", "").Replace("(", "").Replace(")", "")
                                                                           Dim array2 As String() = text3.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("Format Succeeded.") Then
                                                                           RichLogs("Done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Connect BROM failed") OrElse text.Contains("One of the download blocks has invalid range") OrElse text.Contains("Scatter file which is loaded is not be supported") OrElse text.Contains("ERROR : S_AUTH_HANDLE_IS_NOT_READY") Then
                                                                           RichLogs("failed", Color.Red, True, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If

                                                                       If text.Contains("All command exec done") Then
                                                                           RichLogs("Done ✓", Color.Lime, True, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If
                                                                   End If
                                                               End Sub
                    ElseIf Flashcommand.Writememory Then
                        AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                                   Dim text As String = If(e.Data, String.Empty)

                                                                   If text <> String.Empty Then
                                                                       Console.WriteLine(text)

                                                                       If text.Contains("General settings create command") Then
                                                                           RichLogs(Environment.NewLine & " Starting progres ... ", Color.GhostWhite, False, False)
                                                                       End If

                                                                       If text.Contains("General command exec done") Then
                                                                           RichLogs("", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Connecting to BROM") Then
                                                                           RichLogs(" Connecting to", Color.GhostWhite, False, False)
                                                                           RichLogs(" BROM mode", Color.Orange, True, False)
                                                                           RichLogs(" ... ", Color.GhostWhite, False, False)
                                                                       End If

                                                                       If text.Contains("BROM connected") Then
                                                                           RichLogs("Done ✓", Color.Lime, True, True)
                                                                       End If

                                                                       If text.Contains("Connect BROM failed") Then
                                                                           RichLogs("failed", Color.Crimson, True, True)
                                                                       End If

                                                                       If text.Contains("Write Memory Initial") Then
                                                                           RichLogs(vbLf & " Save format data ... ", Color.WhiteSmoke, True)
                                                                       End If

                                                                       If text.Contains("of DA has been sent.") Then
                                                                           Dim ss As String = text.Replace("% of DA has been sent.", "")
                                                                           Main.SharedUI.Progressbar2.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar2.EditValue = Integer.Parse(ss)
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("of image data has been sent") Then
                                                                           Dim text2 As String = text.Substring(0, text.IndexOf("of image data has been sent"))
                                                                           text2 = text2.Replace("%", "")
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(text2)
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("of data write to memory") Then
                                                                           Dim text3 As String = text.Replace("% of data write to memory", "").Replace(text.Substring(text.IndexOf(",")), "")
                                                                           Dim array2 As String() = text3.Split(CType(Nothing, String()), StringSplitOptions.RemoveEmptyEntries)
                                                                           Main.SharedUI.Progressbar1.Invoke(Sub()
                                                                                                                 Main.SharedUI.Progressbar1.EditValue = Integer.Parse(array2(0))
                                                                                                             End Sub)
                                                                       End If

                                                                       If text.Contains("All command exec done") Then
                                                                           RichLogs("Done ✓", Color.Lime, True, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If

                                                                       If text.Contains("ERROR") Then
                                                                           RichLogs(vbLf & " Save format data ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("failed", Color.Red, True, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If

                                                                       If text.Contains("Invalid xml file") Then
                                                                           RichLogs(vbLf & " Save format data ... ", Color.WhiteSmoke, True)
                                                                           RichLogs("Not Supported", Color.Red, True, True)
                                                                           Main.ButtonSTOP_Click(sender, e)
                                                                       End If
                                                                   End If
                                                               End Sub
                    End If
                    process.WaitForExit()
                End If
            End Using
        End Sub
    End Class
End Namespace
