Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports System.Collections.Generic
Imports Reverse_Tool.Potato.Fastboot

Public Class FastbootUI

    Public WorkerTodo As String
    Public IsConnected As Boolean
    Public TodoCommand As String
    Public totalchecked As String
    Public totaldo As String
    Public totallength As Long = 0
    Public textbox As New TextBox()
    Public DevicesName As String = ""
    Public serial As String = ""
    Friend Shared SharedUI As FastbootUI

    Public Sub New()
        InitializeComponent()
        SharedUI = Me
        Watch = New Stopwatch()
        AddHandler DataView.MouseWheel, AddressOf DataView_Mousewheel
        AddHandler DataView.RowPrePaint, AddressOf DataView_RowPrePaint

        AddHandler FastbootWorker.DoWork, AddressOf Worker
        AddHandler FastbootWorker.RunWorkerCompleted, AddressOf AllIsDone
    End Sub

    Private Sub DataView_Mousewheel(sender As Object, e As MouseEventArgs)
        If DataView.Rows.Count > 0 Then

            If e.Delta > 0 AndAlso DataView.FirstDisplayedScrollingRowIndex > 0 Then
                DataView.FirstDisplayedScrollingRowIndex -= 1
            ElseIf e.Delta < 0 Then
                DataView.FirstDisplayedScrollingRowIndex += 1
            End If

        End If
    End Sub

    Private Sub DataView_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs)
        If e.RowIndex Mod 2 = 0 Then
            DataView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        Else
            DataView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(96, 94, 92)
        End If
    End Sub
    Private Sub DataView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataView.CellDoubleClick
        If DataView.Rows.Count > 0 Then
            If e.ColumnIndex = 3 Then
                If DataView.CurrentRow.Cells(1).Value = "flash" OrElse DataView.CurrentRow.Cells(1).Value = "boot" Then
                    Dim openFileDialog As New OpenFileDialog With {
                        .Title = "Select File Partition " + DataView.CurrentRow.Cells(2).Value,
                        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                        .FileName = "*.*",
                        .Filter = "ALL FILE  (*.*)|*.*",
                        .FilterIndex = 2,
                        .RestoreDirectory = True
                    }
                    If openFileDialog.ShowDialog() = DialogResult.OK Then
                        DataView.CurrentRow.Cells(4).Value = openFileDialog.SafeFileName
                        DataView.CurrentRow.Cells(5).Value = Path.Combine(New String() {Path.GetDirectoryName(openFileDialog.FileName)})
                    End If
                Else
                    XtraMessageBox.Show("Custom file available for flash and boot command!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            End If
        End If
    End Sub
    Private Sub MainTab_MouseClick(sender As Object, e As MouseEventArgs) Handles MainTab.MouseClick
        If MainTab.SelectedTabPage.Name = MainTab.TabPages(0).Name Then
        End If

        If MainTab.SelectedTabPage.Name = MainTab.TabPages(1).Name Then
        End If
    End Sub
    Private Sub VScrollBarFbFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBarFbFlashDataView.Scroll
        If DataView.Rows.Count > 0 Then
            VScrollBarFbFlashDataView.LargeChange = DataView.Rows.Count
            VScrollBarFbFlashDataView.Maximum = DataView.Rows.Count - 1 + VScrollBarFbFlashDataView.LargeChange - 1
            DataView.FirstDisplayedScrollingRowIndex = e.NewValue
        End If
    End Sub

    Private Sub HScrollBarFbFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBarFbFlashDataView.Scroll
        DataView.FirstDisplayedScrollingColumnIndex = e.NewValue
    End Sub
    Public Function FastbootConnect(worker As BackgroundWorker, ee As DoWorkEventArgs) As Boolean
        Watch.Restart()
        Watch.Start()
        IsConnected = False
        RichLogs("Waiting devices to connect... ", Color.White, False, False)
        Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Text = "", Action))
        LabelProductName.Invoke(CType(Sub() LabelProductName.Text = "-", Action))
        Dim status As Boolean = Consoles.Fastboot("getvar product", worker, ee).Contains("product")
        If status Then
            IsConnected = True
            textbox.Clear()
            textbox.Text = Consoles.Fastboot("getvar product", worker, ee).Replace("product: ", "")
            LabelProductName.Invoke(CType(Sub() LabelProductName.Text = textbox.Lines(0), Action))

            textbox.Clear()
            textbox.Text = Consoles.Fastboot("getvar serialno", worker, ee).Replace("serialno: ", "")
            serial = textbox.Lines(0)
            Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Text = "Fastboot Device - " & serial, Action))
            Return True
        Else
            Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Text = "", Action))
            RichLogs("Devices Not Found!", Color.Red, False, True)
        End If
        Return False
    End Function
    Public Sub Delay(ByVal dblSecs As Double)
        Now.AddSeconds(0.0000115740740740741)
        Dim dateTime As DateTime = Now.AddSeconds(0.0000115740740740741)
        Dim dateTime1 As DateTime = dateTime.AddSeconds(dblSecs)
        While DateTime.Compare(Now, dateTime1) <= 0
            Application.DoEvents()
        End While
    End Sub
    Private Sub ButtonBrowse_Click(sender As Object, e As EventArgs) Handles ButtonBrowse.Click
        Dim openFileDialog As New OpenFileDialog() With
        {
        .Title = "File",
        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
        .FileName = "*.bat*",
        .Filter = "bat file |*.bat* ",
        .FilterIndex = 2,
        .RestoreDirectory = True
        }
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            TextBoxLocation.Text = Path.Combine(New String() {Path.GetDirectoryName(openFileDialog.FileName)})

            DataView.Rows.Clear()

            Dim str As String = String.Concat(New String() {File.ReadAllText(openFileDialog.FileName)})

            Dim product As String = str.Substring(str.LastIndexOf("^product: *") + 1)
            product = product.Replace("product: *", "").Replace("""", "").Replace(" || exit /B 1", "")

            Dim resultproduct As New TextBox With {
                .Text = product
            }

            Dim strs As New List(Of String)()
            Dim lines As String() = resultproduct.Lines
            Dim num As Integer = 0

            While num < CInt(lines.Length)
                Dim textlines As String = lines(num)
                strs.Add(textlines)
                num += 1
            End While

            product = strs(0)

            LabelProductName.Text = product
            DevicesName = product
            If str.Contains(")") Then
                str = str.Substring(str.LastIndexOf(")") + 1)
            End If

            Using stringReader As New StringReader(str)
                While stringReader.Peek() <> -1
                    Dim str1 As String = stringReader.ReadLine()
                    Dim command As String = ""
                    Dim partition As String = ""
                    Dim filename As String = ""
                    Dim custom As String = ""
                    Dim path As String = TextBoxLocation.Text & "\images"

                    If str1.Contains("||") Then
                        Dim l As Integer
                        Dim p As Integer
                        l = str1.Length
                        p = str1.IndexOf("||") - 1
                        str1 = str1.Remove(p, l - p)
                        str1 = str1.Replace("fastboot %* ", "").Replace("%~dp0images\", "").Replace("%~dp0\images\", "").Replace("pause", "").Replace("::", "").Replace("""", "")
                    Else
                        str1 = str1.Replace("fastboot %* ", "").Replace("%~dp0images\", "").Replace("%~dp0\images\", "").Replace("pause", "").Replace("::", "").Replace("""", "")
                    End If

                    If Not String.IsNullOrEmpty(str1) Then
                        Dim strArrays As String() = str1.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        command = strArrays(0)

                        If command <> "getvar" AndAlso command <> "echo" Then
                            If strArrays.Length = 1 Then
                                custom = ""
                                path = ""
                            End If

                            If strArrays.Length = 2 Then
                                partition = strArrays(1)
                                custom = ""
                                path = ""
                            End If

                            If strArrays.Length = 3 Then
                                partition = strArrays(1)
                                filename = strArrays(2)
                                custom = "double click..."
                            End If

                            DataView.Invoke(New Action(Sub() DataView.Rows.Add(True, command, partition, custom, filename, path)))
                            Console.WriteLine("true " & command & " " & partition & " " & filename & " " & path)
                        End If
                    End If
                End While
                CkboxSelectpartitionDataView.Checked = True
            End Using
        End If

    End Sub

    Public Sub AllIsDone(sender As Object, e As RunWorkerCompletedEventArgs)
        'RichLogs(vbCrLf & "All Progress Completed", Color.White, True, True)
        TimeSpanElapsed.ElapsedTime(Watch)
        Watch.Stop()
    End Sub

    Private Sub ButtonFlash_Click(sender As Object, e As EventArgs) Handles ButtonFlash.Click
        If Not FastbootWorker.IsBusy Then
            Dim flag As Boolean
            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(0).Value = True Then
                    flag = True
                End If
            Next

            If flag Then
                Main.SharedUI.RichTextBoxLogs.Invoke(CType(Sub() Main.SharedUI.RichTextBoxLogs.Clear(), Action))
                WorkerTodo = "flash"

                TodoCommand = ""
                totalchecked = 0
                Dim commands As String = ""
                Dim args As String = ""
                Dim name As String = ""
                Dim path As String = ""
                Dim filename As String = ""
                For Each item As DataGridViewRow In DataView.Rows
                    If item.Cells(DataView.Columns(0).Index).Value = True Then

                        totalchecked += 1

                        commands = item.Cells(DataView.Columns(1).Index).Value
                        args = item.Cells(DataView.Columns(2).Index).Value
                        name = item.Cells(DataView.Columns(4).Index).Value
                        path = item.Cells(DataView.Columns(5).Index).Value & "\"

                        If name <> String.Empty Then
                            filename = path & name
                        Else
                            filename = ""
                        End If

                        If args = "" Then

                            TodoCommand = String.Concat(TodoCommand, commands & vbCrLf & "")

                        ElseIf filename = "" Then

                            TodoCommand = String.Concat(TodoCommand, commands & " " & args & vbCrLf & "")

                        Else

                            TodoCommand = String.Concat(TodoCommand, commands & " " & args & " " & filename & vbCrLf & "")

                        End If

                    End If
                Next

                FastbootWorker.RunWorkerAsync()
                FastbootWorker.Dispose()
            End If
        Else
            RichLogs(" ", Color.White, True, True)
            RichLogs("Fastboot Is Running", Color.WhiteSmoke, False, True)
        End If
    End Sub
    Private Sub ButtonRebootSYS_Click(sender As Object, e As EventArgs) Handles ButtonRebootSYS.Click
        If Not FastbootWorker.IsBusy Then
            Main.SharedUI.RichTextBoxLogs.Invoke(CType(Sub() Main.SharedUI.RichTextBoxLogs.Clear(), Action))
            WorkerTodo = "reboot"
            FastbootWorker.RunWorkerAsync()
            FastbootWorker.Dispose()
        Else
            RichLogs(" ", Color.White, True, True)
            RichLogs("Fastboot Is Running", Color.WhiteSmoke, False, True)
        End If
    End Sub
    Private Sub ButtonRebootEDLold_Click(sender As Object, e As EventArgs) Handles ButtonRebootEDLold.Click
        If Not FastbootWorker.IsBusy Then
            Main.SharedUI.RichTextBoxLogs.Invoke(CType(Sub() Main.SharedUI.RichTextBoxLogs.Clear(), Action))
            WorkerTodo = "EDLold"
            FastbootWorker.RunWorkerAsync()
            FastbootWorker.Dispose()
        Else
            RichLogs(" ", Color.White, True, True)
            RichLogs("Fastboot Is Running", Color.WhiteSmoke, False, True)
        End If
    End Sub
    Private Sub ButtonRebootEDLnew_Click(sender As Object, e As EventArgs) Handles ButtonRebootEDLnew.Click
        If Not FastbootWorker.IsBusy Then
            Main.SharedUI.RichTextBoxLogs.Invoke(CType(Sub() Main.SharedUI.RichTextBoxLogs.Clear(), Action))
            WorkerTodo = "EDLold"
            FastbootWorker.RunWorkerAsync()
            FastbootWorker.Dispose()
        Else
            RichLogs(" ", Color.White, True, True)
            RichLogs("Fastboot Is Running", Color.WhiteSmoke, False, True)
        End If
    End Sub
    Private Sub ButtonReadInfo_Click(sender As Object, e As EventArgs) Handles ButtonReadInfo.Click

        If Not FastbootWorker.IsBusy Then
            Main.SharedUI.RichTextBoxLogs.Invoke(CType(Sub() Main.SharedUI.RichTextBoxLogs.Clear(), Action))
            WorkerTodo = "info"
            FastbootWorker.RunWorkerAsync()
            FastbootWorker.Dispose()
        Else
            RichLogs(" ", Color.White, True, True)
            RichLogs("Fastboot Is Running", Color.WhiteSmoke, False, True)
        End If
    End Sub
    Public Sub Worker(sender As Object, e As DoWorkEventArgs)
        Dim Connect As Boolean = FastbootConnect(DirectCast(sender, BackgroundWorker), e)
        If Connect Then
            RichLogs("Device Connected! ", Color.Lime, False, True)
            Delay(0.5R)

            If WorkerTodo = "flash" Then
                textbox.Clear()
                textbox.Text = Consoles.Fastboot("getvar product", DirectCast(sender, BackgroundWorker), e).Replace("product: ", "")
                Dim product As String = textbox.Lines(0)
                If product.Contains(DevicesName) Then
                    totaldo = 0
                    Using stringReader As New StringReader(TodoCommand)
                        While stringReader.Peek() <> -1
                            Dim cmd As String = stringReader.ReadLine()

                            If Not String.IsNullOrEmpty(cmd) Then
                                Dim arg As String() = cmd.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

                                Console.WriteLine(cmd)

                                totaldo += 1
                                Delay(0.5R)

                                If cmd.Substring(0, 4).Contains("boot") Then
                                    RichLogs("Booting >> " & Path.GetFileName(cmd.Replace("boot ", "").Replace("""", "")) & " ", Color.WhiteSmoke, False, False)
                                ElseIf cmd.Substring(0, 5).Contains("erase") Then
                                    RichLogs("Erasing  >> Partition " & arg(1) & " ", Color.WhiteSmoke, False, False)
                                ElseIf cmd.Substring(0, 5).Contains("flash") Then
                                    RichLogs("Flashing >> Partition " & arg(1) & " " & Path.GetFileName(cmd.Replace("flash ", "").Replace(arg(1), "").Replace("""", "")) & " ", Color.WhiteSmoke, False, False)
                                ElseIf cmd.Substring(0, 3).Contains("oem") Then
                                    RichLogs("OEM >> Command " & arg(1) & " ", Color.WhiteSmoke, False, False)
                                ElseIf cmd.Substring(0, 6).Contains("reboot") Then
                                    RichLogs("Rebooting >> Into System ", Color.WhiteSmoke, False, False)
                                ElseIf cmd.Substring(0, 10).Contains("reboot-edl") Then
                                    RichLogs("Rebooting >> Into Emergency Download Mode ", Color.WhiteSmoke, False, False)
                                End If

                                Dim exec As String = Consoles.Fastboot(cmd, DirectCast(sender, BackgroundWorker), e)
                                If exec.ToLower().Contains("okay") OrElse exec.ToLower().Contains("finished") AndAlso Not exec.ToLower().Contains("failed") Then
                                    RichLogs("[OK]", Color.Lime, False, True)
                                Else
                                    RichLogs("[Failed]", Color.Red, False, True)
                                End If
                            End If

                            If FastbootWorker.CancellationPending Then
                                Exit While
                            End If

                            ProcessBar2(Convert.ToInt64(totaldo), Convert.ToInt64(totalchecked))
                        End While
                    End Using
                Else
                    RichLogs("Error! Missmatching image" & vbCrLf & vbTab & "This for [ " & DevicesName & " ] " & "but target device is [ " & product & " ].", Color.Red, True, True)
                End If
            ElseIf WorkerTodo = "info" Then
                RichLogs("Reading Device Info : ... ", Color.WhiteSmoke, False, False)

                DataView.Invoke(New Action(Sub() DataView.Rows.Clear()))
                Dim Result As String = Consoles.Fastboot("getvar all", DirectCast(sender, BackgroundWorker), e)
                Dim BlockSize As String = ""
                Dim Ends As String = ""
                If Result.ToLower().Contains("okay") OrElse Result.ToLower().Contains("finished") AndAlso Not Result.ToLower().Contains("failed") Then
                    RichLogs("[OK]", Color.Lime, False, True)
                    Using stringReader As New StringReader(Result)
                        Dim partition As String = ""
                        Dim partitionType As String = ""
                        Dim partitionSize As String = ""

                        While stringReader.Peek() <> -1
                            Dim output As String = stringReader.ReadLine().Replace("(bootloader) ", "")

                            If Not String.IsNullOrEmpty(output) Then
                                If output.Contains("block-size: 0x200") OrElse output.Contains("block-size:0x200") OrElse output.Contains("block-size: 512") OrElse output.Contains("block-size:512") Then
                                    BlockSize = 512
                                ElseIf output.Contains("block-size: 0x1000") OrElse output.Contains("block-size:0x1000") OrElse output.Contains("block-size: 4096") OrElse output.Contains("block-size:4096") Then
                                    BlockSize = 4096
                                End If
                                If output.Contains("partition") Then
                                    Dim parts() As String = output.Split(":"c)
                                    If parts.Length = 3 Then
                                        If parts(2).Trim().Contains("0x") OrElse IsNumeric(parts(2).Trim()) Then
                                            partition = parts(1).Trim()
                                            If parts(2).Contains("0x") Then
                                                Dim decimalValue As Long = Convert.ToInt64(parts(2).Trim, 16)
                                                partitionSize = decimalValue
                                            Else
                                                partitionSize = parts(2).Trim()
                                            End If
                                        Else
                                            partition = parts(1).Trim()
                                            partitionType = parts(2).Trim().Replace(" data", "")
                                        End If
                                        If Not String.IsNullOrEmpty(partitionSize) Then
                                            If IsNumeric(partitionSize) Then
                                                RichLogs("partition: " & partition & " " & partitionType & " " & Bismillah.FIREHOSE.FIREHOSE_MANAGER.GetFileSize(partitionSize * BlockSize), Color.WhiteSmoke, False, True)
                                            End If
                                            DataView.Invoke(New Action(Sub() DataView.Rows.Add(False, "flash", partition, "double click...", "", "")))
                                            partitionSize = ""
                                        End If
                                    End If
                                Else
                                    RichLogs(output, Color.WhiteSmoke, False, True)
                                End If
                            End If
                        End While
                    End Using

                Else
                    RichLogs("[Failed]", Color.Red, False, True)
                End If
            ElseIf WorkerTodo = "reboot" Then
                RichLogs("Rebooting into Android : ... ", Color.WhiteSmoke, False, False)
                Dim exec As String = Consoles.Fastboot("reboot", DirectCast(sender, BackgroundWorker), e)
                If exec.ToLower().Contains("okay") OrElse exec.ToLower().Contains("finished") AndAlso Not exec.ToLower().Contains("failed") Then
                    RichLogs("[OK]", Color.Lime, False, True)
                Else
                    RichLogs("[Failed]", Color.Red, False, True)
                End If
            ElseIf WorkerTodo = "EDLold" Then
                RichLogs("Rebooting into EDL Mode : ... ", Color.WhiteSmoke, False, False)
                Dim exec As String = Consoles.Fastboot("reboot-edl", DirectCast(sender, BackgroundWorker), e)
                If exec.ToLower().Contains("okay") OrElse exec.ToLower().Contains("finished") AndAlso Not exec.ToLower().Contains("failed") Then
                    RichLogs("[OK]", Color.Lime, False, True)
                Else
                    RichLogs("[Failed]", Color.Red, False, True)
                End If
            ElseIf WorkerTodo = "EDLnew" Then
                RichLogs("Rebooting into EDL Mode : ... ", Color.WhiteSmoke, False, False)
                Console.WriteLine("fastboot -s " & serial & " oem edl")
                Dim exec As String = Consoles.Fastboot("-s " & serial & " oem edl", DirectCast(sender, BackgroundWorker), e)
                If exec.ToLower().Contains("okay") OrElse exec.ToLower().Contains("finished") AndAlso Not exec.ToLower().Contains("failed") Then
                    RichLogs("[OK]", Color.Lime, False, True)
                Else
                    RichLogs("[Failed]", Color.Red, False, True)
                End If
            End If
        Else
            e.Cancel = True
            FastbootWorker.CancelAsync()
            Return
        End If
    End Sub

    Public WithEvents ButtonBrowse As Button
    Public WithEvents Btn_RawXML As Button
    Friend WithEvents LabelProductName As Label
    Friend WithEvents Column4 As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewComboBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn

    Private Sub CkboxSelectpartitionDataView_CheckedChanged(sender As Object, e As EventArgs) Handles CkboxSelectpartitionDataView.CheckedChanged
        If CkboxSelectpartitionDataView.CheckState = CheckState.Checked Then

            For Each item As DataGridViewRow In DataView.Rows
                For i As Integer = 0 To item.Cells.Count - 1
                    item.Cells(0).Value = True
                Next
            Next
            Return

        Else

            For Each item As DataGridViewRow In DataView.Rows
                For i As Integer = 0 To item.Cells.Count - 1
                    item.Cells(0).Value = False
                Next
            Next
            Return
        End If
    End Sub

End Class