Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Module RichLog
    Public Enum MessageType
        Incoming
        Outgoing
        ok
        Warning
        [Error]
    End Enum
    Public Merah = MessageType.Error
    Public Kuning = MessageType.Warning
    Public Biru = MessageType.Outgoing
    Public putih = MessageType.Incoming
    Private MessageColor() As Color = {Color.WhiteSmoke, Color.AliceBlue, Color.Green, Color.Yellow, Color.Red}
    <STAThread>
    Public Sub DisplayData(ByVal type As MessageType, ByVal msg As String, ByVal bold As Boolean)
        Main.SharedUI.RichTextBoxLogs.Invoke(New EventHandler(Sub()
                                                              Main.SharedUI.RichTextBoxLogs.SelectionStart = Main.SharedUI.RichTextBoxLogs.TextLength
                                                              Main.SharedUI.RichTextBoxLogs.SelectionLength = 0
                                                              Main.SharedUI.RichTextBoxLogs.SelectionColor = MessageColor(CInt(type))
                                                              If bold Then
                                                                  Main.SharedUI.RichTextBoxLogs.SelectionFont = New Font(Main.SharedUI.RichTextBoxLogs.SelectionFont, FontStyle.Italic)
                                                              Else
                                                                  Main.SharedUI.RichTextBoxLogs.SelectionFont = New Font(Main.SharedUI.RichTextBoxLogs.SelectionFont, FontStyle.Italic)
                                                              End If
                                                              Main.SharedUI.RichTextBoxLogs.AppendText(msg)
                                                              Main.SharedUI.RichTextBoxLogs.ScrollToCaret()
                                                          End Sub))
    End Sub
    Public Sub logs(ByVal Textlogs As String, ByVal newline As Boolean, ByVal warna As MessageType)
        If newline = True Then
            DisplayData(warna, Textlogs & ControlChars.Lf, True)
        Else
            DisplayData(warna, Textlogs, True)
        End If

    End Sub

    Public Sub RichLogs(msg As String, colour As Color, isBold As Boolean, Optional NextLine As Boolean = False)
        Main.SharedUI.RichTextBoxLogs.Invoke(Sub()
                                             Main.SharedUI.RichTextBoxLogs.SelectionStart = Main.SharedUI.RichTextBoxLogs.Text.Length
                                             Dim selectionColor As Color = Main.SharedUI.RichTextBoxLogs.SelectionColor
                                             Main.SharedUI.RichTextBoxLogs.SelectionColor = colour
                                             If isBold Then
                                                 Main.SharedUI.RichTextBoxLogs.SelectionFont = New Font(Main.SharedUI.RichTextBoxLogs.Font, FontStyle.Bold)
                                             Else
                                                 Main.SharedUI.RichTextBoxLogs.SelectionFont = New Font(Main.SharedUI.RichTextBoxLogs.Font, FontStyle.Regular)
                                             End If
                                             Main.SharedUI.RichTextBoxLogs.AppendText(msg)
                                             Main.SharedUI.RichTextBoxLogs.SelectionColor = selectionColor
                                             If NextLine Then
                                                 If Main.SharedUI.RichTextBoxLogs.TextLength > 0 Then
                                                     Main.SharedUI.RichTextBoxLogs.AppendText(vbCrLf)
                                                 End If
                                             End If
                                         End Sub)
    End Sub

    Public Sub RtbClear()
        Main.SharedUI.RichTextBoxLogs.Invoke(Sub()
                                                 Main.SharedUI.RichTextBoxLogs.Clear()
                                             End Sub)
    End Sub
End Module

Public Class TimeSpanElapsed
    Public Shared Sub ElapsedTime(Watch As Stopwatch)
        Dim elapsed = Watch.Elapsed
        RichLogs(Environment.NewLine, Color.Transparent, False, False)
        RichLogs(" __________________________________________________________________", Color.White, True, True)
        RichLogs(Environment.NewLine, Color.Transparent, False, False)
        RichLogs(" iREVERSE DROID ULTIMATE ", Color.Transparent, True, False)
        RichLogs(Date.Now.ToString("ddd, dd MMM yyyy HH:mm:ss"), Color.Transparent, True, True)
        Dim str = String.Format("{0:00m}: {1:00s}", elapsed.Minutes, elapsed.Seconds)
        RichLogs(" Elapsed Time : " & str, Color.FromArgb(255, 160, 66), True, True)

        Main.SharedUI.LabelTimer.Invoke(Sub()
                                            Main.SharedUI.LabelTimer.Visible = False
                                        End Sub)

        Main.SharedUI.ButtonSTOP.Invoke(Sub()
                                            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop_30
                                        End Sub)

    End Sub

    Public Shared Sub ElapsedPending(Watch As Stopwatch)
        Dim elapsed = Watch.Elapsed
        RichLogs(Environment.NewLine, Color.Transparent, False, False)
        RichLogs(" __________________________________________________________________", Color.White, True, True)
        RichLogs(Environment.NewLine, Color.Transparent, False, False)
        RichLogs(" iREVERSE DROID ULTIMATE ", Color.Transparent, True, False)
        RichLogs(Date.Now.ToString("ddd, dd MMM yyyy HH:mm:ss"), Color.Transparent, True, True)
        Dim str = String.Format("{0:00m}: {1:00s}", elapsed.Minutes, elapsed.Seconds)
        RichLogs(" Elapsed Time : " & str, Color.FromArgb(255, 160, 66), True, True)

        Main.SharedUI.LabelTimer.Invoke(Sub()
                                            Main.SharedUI.LabelTimer.Visible = False
                                        End Sub)

        Main.SharedUI.ButtonSTOP.Invoke(Sub()
                                            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop_30
                                        End Sub)

    End Sub
End Class
Public Class WaitingStart
    Public Shared Sub WaitingDevices(TextBox As RichTextBox)
        Main.SharedUI.RichTextBoxLogs.Clear()
        RichLogs(" Turn Off Phone, Hold ", Color.GhostWhite, True)
        RichLogs("VOL", Color.Chartreuse, True)
        RichLogs(" + And ", Color.GhostWhite, True)
        RichLogs("VOL", Color.Chartreuse, True)
        RichLogs(" - Then Insert Usb Cable", Color.GhostWhite, True, True)
        RichLogs(" Phone must have battery inside!", Color.DarkOrange, True, True)
        RichLogs(" Waiting For Device", Color.GhostWhite, True)
        RichLogs(" 20s ... ", Color.GhostWhite, True)
        Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30

        Main.SharedUI.LabelTimer.Invoke(Sub()
                                            Main.SharedUI.LabelTimer.Visible = True
                                        End Sub)
    End Sub

    Public Shared Sub WaitingUniversaDevices(TextBox As RichTextBox)
        Main.SharedUI.RichTextBoxLogs.Clear()
        RichLogs(" Turn Off Phone, Hold ", Color.GhostWhite, True)
        RichLogs("VOL", Color.Chartreuse, True)
        RichLogs(" + And ", Color.GhostWhite, True)
        RichLogs("VOL", Color.Chartreuse, True)
        RichLogs(" - Then Insert Usb Cable", Color.GhostWhite, True, True)
        RichLogs(" Phone must have battery inside!", Color.DarkOrange, True, True)
        RichLogs(" Waiting For Device", Color.GhostWhite, True)
        RichLogs(" ... ", Color.GhostWhite, True, True)

        Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30

        Main.SharedUI.LabelTimer.Invoke(Sub()
                                            Main.SharedUI.LabelTimer.Visible = True
                                        End Sub)
    End Sub
End Class