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
        eMMCISP.ListBox1 = New ListBox()
        eMMCISP.ListBox2 = New ListBox()
        eMMCISP.ListBox3 = New ListBox()
        eMMCISP.ListBox4 = New ListBox()
        eMMCISP.ListBox5 = New ListBox()
        eMMCISP.ListBox6 = New ListBox()
        eMMCISP.ListBox7 = New ListBox()
        ComboBox1.Properties.Items.Add("8mb")
        ComboBox1.Properties.Items.Add("16mb")
        ComboBox1.Properties.Items.Add("32mb")
        ComboBox1.Properties.Items.Add("64mb")
        ComboBox1.Properties.Items.Add("128mb")
        ComboBox1.Properties.Items.Add("256mb")
        ComboBox1.Properties.Items.Add("512mb")
        ComboBox1.Properties.Items.Add("1gb")
        ComboBox1.Properties.Items.Add("2gb")
        ComboBox1.Properties.Items.Add("4gb")
        ComboBox1.Properties.Items.Add("ExcludeUserdata")
        ComboBox1.Properties.Items.Add("auto")
        ComboBox1.SelectedItem = "auto"

        AddHandler DirectISPWorker.DoWork, AddressOf eMMCISP.DirectISPWorker_DoWork
    End Sub

    Public Sub DGV_C()
        DataView.Invoke(CType(Sub() DataView.Rows.Clear(), Action))
    End Sub
    Public Sub Logs1(msg As String)
        If Main.SharedUI.RichTextBox.InvokeRequired Then
            Main.SharedUI.RichTextBox.Invoke(Sub()
                                                 Main.SharedUI.RichTextBox.SelectionColor = Color.WhiteSmoke
                                                 Main.SharedUI.RichTextBox.SelectionStart = Main.SharedUI.RichTextBox.Text.Length
                                                 Main.SharedUI.RichTextBox.AppendText(msg)
                                                 Main.SharedUI.RichTextBox.AppendText(Environment.NewLine)
                                             End Sub)
        Else
            Main.SharedUI.RichTextBox.SelectionColor = Color.WhiteSmoke
            Main.SharedUI.RichTextBox.SelectionStart = Main.SharedUI.RichTextBox.Text.Length
            Main.SharedUI.RichTextBox.AppendText(msg)
            Main.SharedUI.RichTextBox.AppendText(Environment.NewLine)
        End If
    End Sub
    Public Sub Logs2(msg As String)
        If RichTextBox2.InvokeRequired Then
            RichTextBox2.Invoke(Sub()
                                    RichTextBox2.SelectionStart = RichTextBox2.Text.Length
                                    RichTextBox2.AppendText(msg)
                                    RichTextBox2.AppendText(Environment.NewLine)
                                End Sub)
        Else
            RichTextBox2.SelectionStart = Main.SharedUI.RichTextBox.Text.Length
            RichTextBox2.AppendText(msg)
            RichTextBox2.AppendText(Environment.NewLine)
        End If
    End Sub
    Public Sub lb1(txt As String)
        'If Label1.InvokeRequired Then
        'Label1.Invoke(CType(Sub() 'Label1.Text = txt, Action))
        'Else
        'Label1.Text = txt
        'End If
    End Sub
    Public Sub lb2(txt As String)
        If Main.SharedUI.label_writensize.InvokeRequired Then
            Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = txt, Action))
        Else
            Main.SharedUI.label_writensize.Text = txt
        End If
    End Sub
    Public Sub lb3(txt As String)
        'If Label3.InvokeRequired Then
        'Label3.Invoke(CType(Sub() 'Label3.Text = txt, Action))
        'Else
        'Label3.Text = txt
        'End If
    End Sub
    Public Sub lb4(txt As String)
        'If Label4.InvokeRequired Then
        'Label4.Invoke(CType(Sub() 'Label4.Text = txt, Action))
        'Else
        'Label4.Text = txt
        'End If
    End Sub
    Public Sub lb5(txt As String)
        If Main.SharedUI.label_totalsize.InvokeRequired Then
            Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = txt, Action))
        Else
            Main.SharedUI.label_totalsize.Text = txt
        End If
    End Sub
    Public Sub Logs1Clear()
        If Main.SharedUI.RichTextBox.InvokeRequired Then
            Main.SharedUI.RichTextBox.Invoke(CType(Sub() Main.SharedUI.RichTextBox.Clear(), Action))
        Else
            Main.SharedUI.RichTextBox.Clear()
        End If
    End Sub
    Public Sub Logs2Clear()
        If RichTextBox2.InvokeRequired Then
            RichTextBox2.Invoke(CType(Sub() RichTextBox2.Clear(), Action))
        Else
            RichTextBox2.Clear()
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
                Dim openFileDialog As New OpenFileDialog()
                openFileDialog.Title = "Select File Partition " + DataView.CurrentRow.Cells(1).Value
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
                openFileDialog.FileName = "*.*"
                openFileDialog.Filter = "ALL FILE  (*.*)|*.*"
                openFileDialog.FilterIndex = 2
                openFileDialog.RestoreDirectory = True
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    DataView.CurrentRow.Cells(5).Value = openFileDialog.FileName
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
        eMMCISP.Refresh_Disk()
    End Sub

    Private Sub ButtonScan_Click(sender As Object, e As EventArgs) Handles ButtonScan.Click
        eMMCISP.Scan_Partition()
    End Sub

    Private Sub Btn_RawXML_Click(sender As Object, e As EventArgs) Handles Btn_RawXML.Click
        DataView.Rows.Clear()
        TxtFlashRawXML.Text = ""
        TxtRawDump.Text = ""
        TxtScatterFile.Text = ""
        Dim openFileDialog As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog() With
        {
            .Title = "Select RAW Programer XML",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
            .FileName = "*xml",
            .FilterIndex = 2,
            .RestoreDirectory = True
        }
        If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            Logs1Clear()
            RichTextBox2.Clear()
            eMMCISP.ListView1.Clear()
            eMMCISP.ListView2.Clear()
            eMMCISP.ListView1.Items.Clear()
            eMMCISP.ListView2.Items.Clear()
            eMMCISP.ListBox1.Items.Clear()
            eMMCISP.ListBox2.Items.Clear()
            eMMCISP.ListBox3.Items.Clear()
            eMMCISP.TodoCommand = ""
            TxtFlashRawXML.Text = openFileDialog.FileName
            eMMCISP.Open_RAWXML()
        End If
    End Sub

    Private Sub Btn_ScatterTXT_Click(sender As Object, e As EventArgs) Handles Btn_ScatterTXT.Click
        DataView.Rows.Clear()
        TxtFlashRawXML.Text = ""
        TxtRawDump.Text = ""
        TxtScatterFile.Text = ""
        Dim openFileDialog As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog() With
        {
            .Title = "Select Scatter TEXT",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
            .FileName = "*txt",
            .FilterIndex = 2,
            .RestoreDirectory = True
        }
        If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            Logs1Clear()
            RichTextBox2.Clear()
            eMMCISP.ListView1.Clear()
            eMMCISP.ListView2.Clear()
            eMMCISP.ListView1.Items.Clear()
            eMMCISP.ListView2.Items.Clear()
            eMMCISP.ListBox1.Items.Clear()
            eMMCISP.ListBox2.Items.Clear()
            eMMCISP.ListBox3.Items.Clear()
            eMMCISP.TodoCommand = ""
            TxtScatterFile.Text = openFileDialog.FileName
            eMMCISP.Open_ScatterTXT()
        End If
    End Sub

    Private Sub ButtonOpenDump_Click(sender As Object, e As EventArgs) Handles ButtonOpenDump.Click
        DataView.Rows.Clear()
        TxtFlashRawXML.Text = ""
        TxtRawDump.Text = ""
        TxtScatterFile.Text = ""
        Dim openFileDialog As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog() With
        {
            .Title = "Select RAW Dump file",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
            .FileName = "*bin",
            .FilterIndex = 2,
            .RestoreDirectory = True
        }
        If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            Logs1Clear()
            RichTextBox2.Clear()
            eMMCISP.ListView1.Clear()
            eMMCISP.ListView2.Clear()
            eMMCISP.ListView1.Items.Clear()
            eMMCISP.ListView2.Items.Clear()
            eMMCISP.ListBox1.Items.Clear()
            eMMCISP.ListBox2.Items.Clear()
            eMMCISP.ListBox3.Items.Clear()
            eMMCISP.TodoCommand = ""
            TxtRawDump.Text = openFileDialog.FileName
            eMMCISP.openfile = TxtRawDump.Text
            eMMCISP.filesize = (New FileInfo(eMMCISP.openfile)).Length
            eMMCISP.Scan_Dump()
        End If
    End Sub

    Private Sub Button_ReadP_Click(sender As Object, e As EventArgs) Handles Button_ReadP.Click
        eMMCISP.cekerror = False
        If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
            XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            Logs1Clear()
            RichTextBox2.Clear()
            eMMCISP.ListView1.Clear()
            eMMCISP.ListView2.Clear()
            eMMCISP.ListView1.Items.Clear()
            eMMCISP.ListView2.Items.Clear()
            eMMCISP.ListBox1.Items.Clear()
            eMMCISP.ListBox2.Items.Clear()
            eMMCISP.ListBox3.Items.Clear()
            eMMCISP.TodoCommand = ""
            eMMCISP.Totaltodo = 0
            Dim folderBrowserDialog As System.Windows.Forms.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog() With
            {
                .ShowNewFolderButton = True
            }
            If (folderBrowserDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                eMMCISP.folderdersave = folderBrowserDialog.SelectedPath
                Dim rootFolder As Environment.SpecialFolder = folderBrowserDialog.RootFolder

                For Each item As DataGridViewRow In DataView.Rows

                    If item.Cells(0).Value = True Then
                        ' 0 bool
                        ' 1 custom
                        ' 2 partition
                        ' 3 size bytes
                        ' 4 offset
                        ' 5 location
                        eMMCISP.Totaltodo += 1
                        eMMCISP.TodoCommand = String.Concat(eMMCISP.TodoCommand, item.Cells(0).Value, "|", item.Cells(1).Value, "|", item.Cells(3).Value, "|", item.Cells(4).Value, "|", item.Cells(5).Value & Environment.NewLine & "")
                        Console.WriteLine("Checked " & item.Cells(0).Value & " " & item.Cells(1).Value & " " & item.Cells(3).Value & " " & item.Cells(4).Value & " " & item.Cells(5).Value & " ")

                    End If
                Next
                Dim thread As System.Threading.Thread = New System.Threading.Thread(AddressOf eMMCISP.read)
                thread.Start()
            End If
        End If
    End Sub

    Private Sub Button_WriteP_Click(sender As Object, e As EventArgs) Handles Button_WriteP.Click
        eMMCISP.asu = ""
        eMMCISP.cekerror = False
        If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
            XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            Dim flag As Boolean = False
            If DataView.Rows.Count > 0 Then
                For Each item As DataGridViewRow In DataView.Rows
                    If (item.Cells(0).Value = True) Then
                        flag = True
                    End If
                Next
            End If
            If flag Then

                Logs1Clear()
                RichTextBox2.Clear()
                eMMCISP.ListView1.Clear()
                eMMCISP.ListView2.Clear()
                eMMCISP.ListView1.Items.Clear()
                eMMCISP.ListView2.Items.Clear()
                eMMCISP.ListBox1.Items.Clear()
                eMMCISP.ListBox2.Items.Clear()
                eMMCISP.ListBox3.Items.Clear()
                eMMCISP.TodoCommand = ""
                eMMCISP.Totaltodo = 0


                For Each item As DataGridViewRow In DataView.Rows

                    If item.Cells(0).Value = True Then
                        ' 0 bool
                        ' 1 custom
                        ' 2 partition
                        ' 3 size bytes
                        ' 4 offset
                        ' 5 location
                        eMMCISP.Totaltodo += 1
                        eMMCISP.TodoCommand = String.Concat(eMMCISP.TodoCommand, item.Cells(0).Value, "|", item.Cells(1).Value, "|", item.Cells(3).Value, "|", item.Cells(4).Value, "|", item.Cells(5).Value & Environment.NewLine & "")
                        Console.WriteLine("Checked " & item.Cells(0).Value & " " & item.Cells(1).Value & " " & item.Cells(3).Value & " " & item.Cells(4).Value & " " & item.Cells(5).Value & " ")

                    End If
                Next
                eMMCISP.m = "wp"
                Dim thread As System.Threading.Thread = New System.Threading.Thread(AddressOf eMMCISP.writeselected)
                thread.Start()
            Else
                XtraMessageBox.Show("Please select partition", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        End If
    End Sub

    Private Sub Button_EraseP_Click(sender As Object, e As EventArgs) Handles Button_EraseP.Click
        eMMCISP.asu = ""
        eMMCISP.cekerror = False
        If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
            XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            Logs1Clear()
            RichTextBox2.Clear()
            eMMCISP.ListView1.Clear()
            eMMCISP.ListView2.Clear()
            eMMCISP.ListView1.Items.Clear()
            eMMCISP.ListView2.Items.Clear()
            eMMCISP.ListBox1.Items.Clear()
            eMMCISP.ListBox2.Items.Clear()
            eMMCISP.ListBox3.Items.Clear()
            eMMCISP.TodoCommand = ""
            eMMCISP.Totaltodo = 0

            For Each item As DataGridViewRow In DataView.Rows

                    If item.Cells(0).Value = True Then
                        ' 0 bool
                        ' 1 custom
                        ' 2 partition
                        ' 3 size bytes
                        ' 4 offset
                        ' 5 location
                        eMMCISP.Totaltodo += 1
                        eMMCISP.TodoCommand = String.Concat(eMMCISP.TodoCommand, item.Cells(0).Value, "|", item.Cells(1).Value, "|", item.Cells(3).Value, "|", item.Cells(4).Value, "|", item.Cells(5).Value & Environment.NewLine & "")
                        Console.WriteLine("Checked " & item.Cells(0).Value & " " & item.Cells(1).Value & " " & item.Cells(3).Value & " " & item.Cells(4).Value & " " & item.Cells(5).Value & " ")

                    End If
                Next
                eMMCISP.m = "erase"
                eMMCISP.openfile = "Tools/process/file/zero.img"
                Dim thread As System.Threading.Thread = New System.Threading.Thread(AddressOf eMMCISP.erases)
                thread.Start()
            End If
    End Sub

    Private Sub Button_ReadD_Click(sender As Object, e As EventArgs) Handles Button_ReadD.Click
        eMMCISP.cekerror = False
        If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
            XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            Dim folderBrowserDialog As System.Windows.Forms.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog() With
                {
                    .ShowNewFolderButton = True
                }
            If (folderBrowserDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                Logs1Clear()
                RichTextBox2.Clear()
                eMMCISP.folderdersave = folderBrowserDialog.SelectedPath
                Dim rootFolder As Environment.SpecialFolder = folderBrowserDialog.RootFolder
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New ThreadStart(AddressOf eMMCISP.readfull))
                thread.Start()
            End If
        End If
    End Sub

    Private Sub Button_WriteD_Click(sender As Object, e As EventArgs) Handles Button_WriteD.Click
        eMMCISP.cekerror = False
        If (Equals(Main.SharedUI.comboUSB.Text, "")) Then
            XtraMessageBox.Show("Please select disk", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            Logs1Clear()
            RichTextBox2.Clear()
            eMMCISP.m = "f"
            Dim thread As System.Threading.Thread = New System.Threading.Thread(AddressOf eMMCISP.writedump)
            thread.Start()
        End If
    End Sub
End Class

