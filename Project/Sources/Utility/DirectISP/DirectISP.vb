Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Public Class DirectISP
    Public Shared SharedUI As DirectISP
    Public RichTextBox2 As New RichTextBox()

    Public Sub New()
        InitializeComponent()
        SharedUI = Me
        Watch = New Stopwatch()
        AddHandler DataView.MouseWheel, AddressOf DataView_Mousewheel
        AddHandler DataView.RowPrePaint, AddressOf DataView_RowPrePaint
        AddHandler MyBase.Load, AddressOf Me.Main_Load
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs)
        EMMCISP.ListBox1 = New ListBox()
        EMMCISP.ListBox2 = New ListBox()
        EMMCISP.ListBox3 = New ListBox()
        EMMCISP.ListBox4 = New ListBox()
        EMMCISP.ListBox5 = New ListBox()
        EMMCISP.ListBox6 = New ListBox()
        EMMCISP.ListBox7 = New ListBox()
        ComboBoxSizeDump.Properties.Items.Add("Auto Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("8 MB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("16 MB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("32 MB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("64 MB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("128 MB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("256 MB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("512 MB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("1 GB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("2 GB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("4 GB Size Dump")
        ComboBoxSizeDump.Properties.Items.Add("Without Userdata Dump")
        ComboBoxSizeDump.SelectedItem = "Auto Size Dump"

        AddHandler DirectISPWorker.DoWork, AddressOf EMMCISP.DirectISPWorker_DoWork
        AddHandler DirectISPWorker.RunWorkerCompleted, AddressOf EMMCISP.DirectISPWorker_RunWorkerComplete

        AddHandler eMMCISPWorker.DoWork, AddressOf EMMCISP.EMMCISPWorker_DoWork
        AddHandler eMMCISPWorker.RunWorkerCompleted, AddressOf EMMCISP.EMMCISPWorker_RunWorkerComplete

    End Sub

    Public Sub DGV_C()
        DataView.Invoke(CType(Sub() DataView.Rows.Clear(), Action))
    End Sub
    Public Sub Logs1(msg As String)
        If Main.SharedUI.RichTextBoxLogs.InvokeRequired Then
            Main.SharedUI.RichTextBoxLogs.Invoke(Sub()
                                                     Main.SharedUI.RichTextBoxLogs.SelectionColor = Color.WhiteSmoke
                                                     Main.SharedUI.RichTextBoxLogs.SelectionStart = Main.SharedUI.RichTextBoxLogs.Text.Length
                                                     Main.SharedUI.RichTextBoxLogs.AppendText(msg)
                                                     Main.SharedUI.RichTextBoxLogs.AppendText(Environment.NewLine)
                                                 End Sub)
        Else
            Main.SharedUI.RichTextBoxLogs.SelectionColor = Color.WhiteSmoke
            Main.SharedUI.RichTextBoxLogs.SelectionStart = Main.SharedUI.RichTextBoxLogs.Text.Length
            Main.SharedUI.RichTextBoxLogs.AppendText(msg)
            Main.SharedUI.RichTextBoxLogs.AppendText(Environment.NewLine)
        End If
    End Sub
    Public Sub Logs2(msg As String)
        If Main.SharedUI.RichTextBoxOutput.InvokeRequired Then
            Main.SharedUI.RichTextBoxOutput.Invoke(Sub()
                                                       Main.SharedUI.RichTextBoxOutput.SelectionStart = Main.SharedUI.RichTextBoxOutput.Text.Length
                                                       Main.SharedUI.RichTextBoxOutput.AppendText(msg)
                                                       Main.SharedUI.RichTextBoxOutput.AppendText(Environment.NewLine)
                                                   End Sub)
        Else
            Main.SharedUI.RichTextBoxOutput.SelectionStart = Main.SharedUI.RichTextBoxOutput.Text.Length
            Main.SharedUI.RichTextBoxOutput.AppendText(msg)
            Main.SharedUI.RichTextBoxOutput.AppendText(Environment.NewLine)
        End If
    End Sub
    Public Sub Logs1Clear()
        If Main.SharedUI.RichTextBoxLogs.InvokeRequired Then
            Main.SharedUI.RichTextBoxLogs.Invoke(CType(Sub() Main.SharedUI.RichTextBoxLogs.Clear(), Action))
        Else
            Main.SharedUI.RichTextBoxLogs.Clear()
        End If
    End Sub
    Public Sub Logs2Clear()
        If Main.SharedUI.RichTextBoxOutput.InvokeRequired Then
            Main.SharedUI.RichTextBoxOutput.Invoke(CType(Sub() Main.SharedUI.RichTextBoxOutput.Clear(), Action))
        Else
            Main.SharedUI.RichTextBoxOutput.Clear()
        End If
    End Sub
    Public Sub PB1(val As Long)
        If Main.SharedUI.Progressbar1.InvokeRequired Then
            Main.SharedUI.Progressbar1.Invoke(CType(Sub() Main.SharedUI.Progressbar1.EditValue = val, Action))
        Else
            Main.SharedUI.Progressbar1.EditValue = val
        End If
    End Sub
    Public Sub PB1OK()
        If Main.SharedUI.Progressbar1.InvokeRequired Then
            Main.SharedUI.Progressbar1.Invoke(Sub()
                                                  For i As Integer = 0 To 10
                                                      Main.SharedUI.Progressbar1.EditValue = i + 90
                                                  Next
                                              End Sub)
        Else
            For i As Integer = 1 To 10
                Main.SharedUI.Progressbar1.EditValue = i + 90
            Next
        End If
    End Sub
    Public Sub PB2(val As Long)
        If Main.SharedUI.Progressbar2.InvokeRequired Then
            Main.SharedUI.Progressbar2.Invoke(CType(Sub() Main.SharedUI.Progressbar2.EditValue = val, Action))
        Else
            Main.SharedUI.Progressbar2.EditValue = val
        End If
    End Sub
    Public Sub PB2OK()
        If Main.SharedUI.Progressbar2.InvokeRequired Then
            Main.SharedUI.Progressbar2.Invoke(Sub()
                                                  For i As Integer = 1 To 10
                                                      Main.SharedUI.Progressbar2.EditValue = i + 90
                                                  Next
                                              End Sub)
        Else
            For i As Integer = 1 To 10
                Main.SharedUI.Progressbar2.EditValue = i + 90
            Next
        End If
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
    Private Sub CkboxSelectpartitionDataView_CheckedChanged(sender As Object, e As EventArgs) Handles CkboxSelectpartitionDataView.CheckedChanged
        If DataView.Rows.Count > 0 Then
            If CkboxSelectpartitionDataView.Checked Then
                For Each item As DataGridViewRow In DataView.Rows
                    item.Cells(0).Value = True
                Next
            Else
                For Each item As DataGridViewRow In DataView.Rows
                    item.Cells(0).Value = False
                Next
            End If
        End If
    End Sub
    Private Sub DataView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataView.CellDoubleClick
        If DataView.Rows.Count > 0 Then
            If e.ColumnIndex = 2 Then
                Dim openFileDialog As New OpenFileDialog With {
                    .Title = "Select File Partition " + DataView.CurrentRow.Cells(1).Value,
                    .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                    .FileName = "*.*",
                    .Filter = "ALL FILE  (*.*)|*.*",
                    .FilterIndex = 2,
                    .RestoreDirectory = True
                }
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    DataView.CurrentRow.Cells(5).Value = openFileDialog.FileName
                    DataView.CurrentRow.Cells(0).Value = True
                End If
            End If
        End If
    End Sub
    Private Sub VScrollBarDirectISPFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBarDirectISPFlashDataView.Scroll
        If DataView.Rows.Count > 0 Then
            VScrollBarDirectISPFlashDataView.LargeChange = DataView.Rows.Count
            VScrollBarDirectISPFlashDataView.Maximum = DataView.Rows.Count - 1 + VScrollBarDirectISPFlashDataView.LargeChange - 1
            DataView.FirstDisplayedScrollingRowIndex = e.NewValue
        End If
    End Sub

    Private Sub HScrollBarDirectISPFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBarDirectISPFlashDataView.Scroll
        DataView.FirstDisplayedScrollingColumnIndex = e.NewValue
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            EMMCISP.Watch.Start()
            Logs1Clear()
            Logs2Clear()
            DGV_C()
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs("REFRESH DISK", Color.Orange, True, True)
            RichLogs(" Connect   : ", Color.White, True, False)
            RichLogs("Direct ISP", Color.DeepSkyBlue, True, True)
            EMMCISP.SelectedCommand = "Refresh_Disk"
            eMMCISPWorker.RunWorkerAsync()
            eMMCISPWorker.Dispose()
        Else
            RichLogs(" ", Color.Yellow, True, True)
            RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub

    Private Sub ButtonScan_Click(sender As Object, e As EventArgs) Handles ButtonScan.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            EMMCISP.Watch.Start()
            Logs1Clear()
            Logs2Clear()
            DGV_C()
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs("SCAN DISK", Color.Orange, True, True)
            RichLogs(" Connect   : ", Color.White, True, False)
            RichLogs("Direct ISP", Color.DeepSkyBlue, True, True)
            RichLogs(" Disk      : ", Color.White, True, False)
            RichLogs(Main.SharedUI.comboUSB.Text, Color.DeepSkyBlue, True, True)
            RichLogs(" ", Color.DeepSkyBlue, True, True)
            RichLogs(" ", Color.DeepSkyBlue, True, True)

            EMMCISP.SelectedCommand = "Scan_Partition"
            eMMCISPWorker.RunWorkerAsync()
            eMMCISPWorker.Dispose()
        Else
            RichLogs(" ", Color.Yellow, True, True)
            RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub

    Private Sub Btn_RawXML_Click(sender As Object, e As EventArgs) Handles Btn_RawXML.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            DataView.Rows.Clear()
            TxtFlashRawXML.Text = ""
            TxtRawDump.Text = ""
            TxtScatterFile.Text = ""
            Dim openFileDialog As New System.Windows.Forms.OpenFileDialog() With
            {
                .Title = "Select RAW Programer XML",
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                .FileName = "*xml",
                .FilterIndex = 2,
                .RestoreDirectory = True
            }
            If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                Logs1Clear()
                Logs2Clear()
                EMMCISP.ListView1.Clear()
                EMMCISP.ListView2.Clear()
                EMMCISP.ListView1.Items.Clear()
                EMMCISP.ListView2.Items.Clear()
                EMMCISP.ListBox1.Items.Clear()
                EMMCISP.ListBox2.Items.Clear()
                EMMCISP.ListBox3.Items.Clear()
                EMMCISP.TodoCommand = ""
                TxtFlashRawXML.Text = openFileDialog.FileName
                EMMCISP.Open_RAWXML()
            End If
        Else
            RichLogs(" ", Color.Yellow, True, True)
            RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub

    Private Sub Btn_ScatterTXT_Click(sender As Object, e As EventArgs) Handles Btn_ScatterTXT.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            DataView.Rows.Clear()
            TxtFlashRawXML.Text = ""
            TxtRawDump.Text = ""
            TxtScatterFile.Text = ""
            Dim openFileDialog As New System.Windows.Forms.OpenFileDialog() With
            {
                .Title = "Select Scatter TEXT",
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                .FileName = "*txt",
                .FilterIndex = 2,
                .RestoreDirectory = True
            }
            If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                Logs1Clear()
                Logs2Clear()
                EMMCISP.ListView1.Clear()
                EMMCISP.ListView2.Clear()
                EMMCISP.ListView1.Items.Clear()
                EMMCISP.ListView2.Items.Clear()
                EMMCISP.ListBox1.Items.Clear()
                EMMCISP.ListBox2.Items.Clear()
                EMMCISP.ListBox3.Items.Clear()
                EMMCISP.TodoCommand = ""
                TxtScatterFile.Text = openFileDialog.FileName
                EMMCISP.Open_ScatterTXT()
            End If
        Else
            RichLogs(" ", Color.Yellow, True, True)
            RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub

    Private Sub ButtonOpenDump_Click(sender As Object, e As EventArgs) Handles ButtonOpenDump.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            DataView.Rows.Clear()
            TxtFlashRawXML.Text = ""
            TxtRawDump.Text = ""
            TxtScatterFile.Text = ""
            Dim openFileDialog As New System.Windows.Forms.OpenFileDialog() With
            {
                .Title = "Select RAW Dump file",
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                .FileName = "*bin",
                .FilterIndex = 2,
                .RestoreDirectory = True
            }
            If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                EMMCISP.Watch.Start()
                DGV_C()
                Logs1Clear()
                Logs2Clear()
                RichLogs("Operation  : ", Color.White, True, False)
                RichLogs("SCAN DUMP", Color.Orange, True, True)
                RichLogs(" Connect   : ", Color.White, True, False)
                RichLogs("Direct ISP", Color.DeepSkyBlue, True, True)
                RichLogs(" Disk      : ", Color.White, True, False)
                RichLogs(Main.SharedUI.comboUSB.Text, Color.DeepSkyBlue, True, True)
                RichLogs(" ", Color.DeepSkyBlue, True, True)
                RichLogs(" ", Color.DeepSkyBlue, True, True)
                EMMCISP.ListView1.Clear()
                EMMCISP.ListView2.Clear()
                EMMCISP.ListView1.Items.Clear()
                EMMCISP.ListView2.Items.Clear()
                EMMCISP.ListBox1.Items.Clear()
                EMMCISP.ListBox2.Items.Clear()
                EMMCISP.ListBox3.Items.Clear()
                EMMCISP.TodoCommand = ""
                TxtRawDump.Text = openFileDialog.FileName
                EMMCISP.openfile = TxtRawDump.Text
                EMMCISP.filesize = (New FileInfo(EMMCISP.openfile)).Length

                EMMCISP.SelectedCommand = "Scan_Dump"
                eMMCISPWorker.RunWorkerAsync()
                eMMCISPWorker.Dispose()
            End If
        Else
            RichLogs(" ", Color.Yellow, True, True)
            RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub

    Private Sub Button_ReadP_Click(sender As Object, e As EventArgs) Handles Button_ReadP.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            Dim flag As Boolean = False
            If DataView.Rows.Count > 0 Then
                For Each item As DataGridViewRow In DataView.Rows
                    If (item.Cells(0).Value = True) Then
                        Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                        flag = True
                    End If
                Next
            Else
                XtraMessageBox.Show("Please select partition", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
            If flag Then
                If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
                    XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    EMMCISP.cekerror = False
                    Logs1Clear()
                    Logs2Clear()
                    EMMCISP.ListView1.Clear()
                    EMMCISP.ListView2.Clear()
                    EMMCISP.ListView1.Items.Clear()
                    EMMCISP.ListView2.Items.Clear()
                    EMMCISP.ListBox1.Items.Clear()
                    EMMCISP.ListBox2.Items.Clear()
                    EMMCISP.ListBox3.Items.Clear()
                    EMMCISP.TodoCommand = ""
                    EMMCISP.Totaltodo = 0
                    Dim folderBrowserDialog As New System.Windows.Forms.FolderBrowserDialog() With
                    {
                        .ShowNewFolderButton = True
                    }
                    If (folderBrowserDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                        EMMCISP.folderdersave = folderBrowserDialog.SelectedPath
                        Dim rootFolder As Environment.SpecialFolder = folderBrowserDialog.RootFolder

                        RichLogs("Operation  : ", Color.White, True, False)
                        RichLogs("READ PARTITION", Color.Orange, True, True)
                        RichLogs(" Connect   : ", Color.White, True, False)
                        RichLogs("Direct ISP", Color.DeepSkyBlue, True, True)
                        RichLogs(" Disk      : ", Color.White, True, False)
                        RichLogs(Main.SharedUI.comboUSB.Text, Color.DeepSkyBlue, True, True)
                        RichLogs(" ", Color.DeepSkyBlue, True, True)
                        RichLogs(" ", Color.DeepSkyBlue, True, True)


                        For Each item As DataGridViewRow In DataView.Rows

                            If item.Cells(0).Value = True Then
                                ' 0 bool
                                ' 1 custom
                                ' 2 partition
                                ' 3 size bytes
                                ' 4 offset
                                ' 5 location

                                EMMCISP.Totaltodo += 1
                                EMMCISP.TodoCommand = String.Concat(EMMCISP.TodoCommand, item.Cells(0).Value, "|", item.Cells(1).Value, "|", item.Cells(3).Value, "|", item.Cells(4).Value, "|", item.Cells(5).Value & Environment.NewLine & "")
                                Console.WriteLine("Checked " & item.Cells(0).Value & " " & item.Cells(1).Value & " " & item.Cells(3).Value & " " & item.Cells(4).Value & " " & item.Cells(5).Value & " ")

                            End If
                        Next
                        EMMCISP.SelectedCommand = "read"
                        eMMCISPWorker.RunWorkerAsync()
                        eMMCISPWorker.Dispose()
                    End If
                End If
            End If
        Else
            RichLogs(" ", Color.Yellow, True, True)
            RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub

    Private Sub Button_WriteP_Click(sender As Object, e As EventArgs) Handles Button_WriteP.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            Dim flag As Boolean = False
            If DataView.Rows.Count > 0 Then
                For Each item As DataGridViewRow In DataView.Rows
                    If (item.Cells(0).Value = True) Then
                        Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                        flag = True
                    End If
                Next
            Else
                XtraMessageBox.Show("Please select partition", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
            If flag Then
                If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
                    XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    EMMCISP.asu = ""
                    EMMCISP.cekerror = False
                    Logs1Clear()
                    Logs2Clear()
                    EMMCISP.ListView1.Clear()
                    EMMCISP.ListView2.Clear()
                    EMMCISP.ListView1.Items.Clear()
                    EMMCISP.ListView2.Items.Clear()
                    EMMCISP.ListBox1.Items.Clear()
                    EMMCISP.ListBox2.Items.Clear()
                    EMMCISP.ListBox3.Items.Clear()
                    EMMCISP.TodoCommand = ""
                    EMMCISP.Totaltodo = 0

                    RichLogs("Operation  : ", Color.White, True, False)
                    RichLogs("WRITE PARTITION", Color.Orange, True, True)
                    RichLogs(" Connect   : ", Color.White, True, False)
                    RichLogs("Direct ISP", Color.DeepSkyBlue, True, True)
                    RichLogs(" Disk      : ", Color.White, True, False)
                    RichLogs(Main.SharedUI.comboUSB.Text, Color.DeepSkyBlue, True, True)
                    RichLogs(" ", Color.DeepSkyBlue, True, True)
                    RichLogs(" ", Color.DeepSkyBlue, True, True)


                    Dim location As String = ""
                    For Each item As DataGridViewRow In DataView.Rows

                        If item.Cells(0).Value = True Then
                            ' 0 bool
                            ' 1 custom
                            ' 2 partition
                            ' 3 size bytes
                            ' 4 offset
                            ' 5 location
                            If String.IsNullOrEmpty(item.Cells(5).Value) Then
                                location = "none"
                            Else
                                location = item.Cells(5).Value
                            End If
                            EMMCISP.Totaltodo += 1
                            EMMCISP.TodoCommand = String.Concat(EMMCISP.TodoCommand, item.Cells(0).Value, "|", item.Cells(1).Value, "|", item.Cells(3).Value, "|", item.Cells(4).Value, "|", location & Environment.NewLine & "")
                            Console.WriteLine("Checked " & item.Cells(0).Value & " " & item.Cells(1).Value & " " & item.Cells(3).Value & " " & item.Cells(4).Value & " " & location & " ")

                        End If
                    Next
                    If File.Exists("unsparse.img") Then
                        File.Delete("unsparse.img")
                    End If
                    EMMCISP.m = "wp"

                    EMMCISP.SelectedCommand = "writeselected"
                    eMMCISPWorker.RunWorkerAsync()
                    eMMCISPWorker.Dispose()
                End If
            End If
        Else
            RichLogs(" ", Color.Yellow, True, True)
            RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub

    Private Sub Button_EraseP_Click(sender As Object, e As EventArgs) Handles Button_EraseP.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            Dim flag As Boolean = False
            If DataView.Rows.Count > 0 Then
                For Each item As DataGridViewRow In DataView.Rows
                    If (item.Cells(0).Value = True) Then
                        Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                        flag = True
                    End If
                Next
            Else
                XtraMessageBox.Show("Please select partition", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
            If flag Then
                If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
                    XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    EMMCISP.asu = ""
                    EMMCISP.cekerror = False
                    Logs1Clear()
                    Logs2Clear()
                    EMMCISP.ListView1.Clear()
                    EMMCISP.ListView2.Clear()
                    EMMCISP.ListView1.Items.Clear()
                    EMMCISP.ListView2.Items.Clear()
                    EMMCISP.ListBox1.Items.Clear()
                    EMMCISP.ListBox2.Items.Clear()
                    EMMCISP.ListBox3.Items.Clear()
                    EMMCISP.TodoCommand = ""
                    EMMCISP.Totaltodo = 0

                    RichLogs("Operation  : ", Color.White, True, False)
                    RichLogs("ERASE PARTITION", Color.Orange, True, True)
                    RichLogs(" Connect   : ", Color.White, True, False)
                    RichLogs("Direct ISP", Color.DeepSkyBlue, True, True)
                    RichLogs(" Disk      : ", Color.White, True, False)
                    RichLogs(Main.SharedUI.comboUSB.Text, Color.DeepSkyBlue, True, True)
                    RichLogs(" ", Color.DeepSkyBlue, True, True)
                    RichLogs(" ", Color.DeepSkyBlue, True, True)


                    For Each item As DataGridViewRow In DataView.Rows

                        If item.Cells(0).Value = True Then
                            ' 0 bool
                            ' 1 custom
                            ' 2 partition
                            ' 3 size bytes
                            ' 4 offset
                            ' 5 location
                            EMMCISP.Totaltodo += 1
                            EMMCISP.TodoCommand = String.Concat(EMMCISP.TodoCommand, item.Cells(0).Value, "|", item.Cells(1).Value, "|", item.Cells(3).Value, "|", item.Cells(4).Value, "|", item.Cells(5).Value & Environment.NewLine & "")
                            Console.WriteLine("Checked " & item.Cells(0).Value & " " & item.Cells(1).Value & " " & item.Cells(3).Value & " " & item.Cells(4).Value & " " & item.Cells(5).Value & " ")

                        End If
                    Next
                    EMMCISP.m = "erase"
                    EMMCISP.openfile = "Tools/process/file/zero.img"
                    If File.Exists("unsparse.img") Then
                        File.Delete("unsparse.img")
                    End If

                    EMMCISP.SelectedCommand = "erases"
                    eMMCISPWorker.RunWorkerAsync()
                    eMMCISPWorker.Dispose()

                End If
            End If
        Else
            RichLogs(" ", Color.Yellow, True, True)
            RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub

    Private Sub Button_ReadD_Click(sender As Object, e As EventArgs) Handles Button_ReadD.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            EMMCISP.cekerror = False
            If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
                XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                Dim folderBrowserDialog As New System.Windows.Forms.FolderBrowserDialog() With
                        {
                            .ShowNewFolderButton = True
                        }
                If (folderBrowserDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                    Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                    Logs1Clear()
                    Logs2Clear()
                    EMMCISP.folderdersave = folderBrowserDialog.SelectedPath
                    Dim rootFolder As Environment.SpecialFolder = folderBrowserDialog.RootFolder

                    RichLogs("Operation  : ", Color.White, True, False)
                    RichLogs("READ DUMP", Color.Orange, True, True)
                    RichLogs(" Connect   : ", Color.White, True, False)
                    RichLogs("Direct ISP", Color.DeepSkyBlue, True, True)
                    RichLogs(" Disk      : ", Color.White, True, False)
                    RichLogs(Main.SharedUI.comboUSB.Text, Color.DeepSkyBlue, True, True)
                    RichLogs(" ", Color.DeepSkyBlue, True, True)
                    RichLogs(" ", Color.DeepSkyBlue, True, True)


                    EMMCISP.SelectedCommand = "readfull"
                    eMMCISPWorker.RunWorkerAsync()
                    eMMCISPWorker.Dispose()

                End If
            End If
        Else
            RichLogs(" ", Color.Yellow, True, True)
            RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub

    Private Sub Button_WriteD_Click(sender As Object, e As EventArgs) Handles Button_WriteD.Click
        If Not DirectISPWorker.IsBusy AndAlso Not eMMCISPWorker.IsBusy Then
            EMMCISP.cekerror = False
            If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
                XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                If (Equals(TxtRawDump.Text, "")) Then
                    XtraMessageBox.Show("Please select dump file", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                    Logs1Clear()
                    Logs2Clear()
                    EMMCISP.m = "f"

                    RichLogs("Operation  : ", Color.White, True, False)
                    RichLogs("WRITE DUMP", Color.Orange, True, True)
                    RichLogs(" Connect   : ", Color.White, True, False)
                    RichLogs("Direct ISP", Color.DeepSkyBlue, True, True)
                    RichLogs(" Disk      : ", Color.White, True, False)
                    RichLogs(Main.SharedUI.comboUSB.Text, Color.DeepSkyBlue, True, True)
                    RichLogs(" ", Color.DeepSkyBlue, True, True)
                    RichLogs(" ", Color.DeepSkyBlue, True, True)


                    If File.Exists("unsparse.img") Then
                        File.Delete("unsparse.img")
                    End If

                    EMMCISP.SelectedCommand = "writedump"
                    eMMCISPWorker.RunWorkerAsync()
                    eMMCISPWorker.Dispose()

                End If
            End If
        Else
            RichLogs(" ", Color.Yellow, True, True)
        RichLogs("Direct ISP Worker Is Running..", Color.Yellow, True, True)
        End If
    End Sub
End Class

