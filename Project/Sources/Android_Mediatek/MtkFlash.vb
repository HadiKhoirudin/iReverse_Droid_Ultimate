Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Microsoft.VisualBasic
Imports Reverse_Tool.DXApplication.Mtkxml

Public Class MtkFlash


    Friend Shared SharedUI As MtkFlash
    Public Shared RichtextBox As RichTextBox


    Public Shared Firmware As New List(Of Firmware)()
    Public SearchTime As String
    Public EndTime As String

    Public RichtextBox1 As RichTextBox
    Public Shared WorkerMethod As String = "FLASH"

    Public Sub New()
        InitializeComponent()

        SharedUI = Me

        AddHandler Load, AddressOf MtkFlash_Load
        AddHandler QlMGPTGrid.MouseWheel, AddressOf QlMGPTGrid_Mousewheel
        AddHandler DataView.MouseWheel, AddressOf DataView_Mousewheel
        EndTime = 3.ToString() & 0.ToString()
        Watch = New Stopwatch()
    End Sub
    Private Sub QlMGPTGrid_Mousewheel(sender As Object, e As MouseEventArgs)
        If QlMGPTGrid.Rows.Count > 0 Then

            If e.Delta > 0 AndAlso QlMGPTGrid.FirstDisplayedScrollingRowIndex > 0 Then
                QlMGPTGrid.FirstDisplayedScrollingRowIndex -= 1
            ElseIf e.Delta < 0 Then
                QlMGPTGrid.FirstDisplayedScrollingRowIndex += 1
            End If
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


    Private Sub MtkFlash_Load(sender As Object, e As EventArgs)
        RichtextBox1 = Main.SharedUI.RichTextBoxLogs
        Console.WriteLine(Mediatek.Mediatek_tool.Flashpath.Flashtoolexe)
        Mediatek.Mediatek_tool.Mediatek.Connection = "BromUSB"
        If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
            Dim directory As New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)

            For Each file As FileInfo In directory.EnumerateFiles()

                If file.Name.Contains("MTK_AllInOne_DA.bin") Then
                    Mediatek.Mediatek_tool.Mediatek.DA = file.FullName
                    TxtFlashDA.Text = file.Name
                End If
            Next
        End If

        'ScrollBar1.LargeChange = DataView.Rows.Count
    End Sub


    Private Sub DataView_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DataView.RowPrePaint
        If e.RowIndex Mod 2 = 0 Then
            DataView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        Else
            DataView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(96, 94, 92)
        End If
    End Sub

    Private Sub QlMGPTGrid_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles QlMGPTGrid.RowPrePaint
        If e.RowIndex Mod 2 = 0 Then
            QlMGPTGrid.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        Else
            QlMGPTGrid.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(96, 94, 92)
        End If
    End Sub

    Private Sub CkboxSelectpartitionDataView_CheckedChanged(sender As Object, e As EventArgs) Handles CkboxSelectpartitionDataView.CheckedChanged
        If CkboxSelectpartitionDataView.CheckState = CheckState.Checked Then

            For Each item As DataGridViewRow In DataView.Rows
                For i As Integer = 0 To item.Cells.Count - 1
                    If item.Cells(2).Value.ToString() <> String.Empty Then
                        item.Cells(0).Value = True
                    End If
                    If item.Cells(2).Value.ToString() = String.Empty Then
                        item.Cells(0).Value = False
                    End If
                Next
            Next
            Return

            For Each item2 As DataGridViewRow In DataView.Rows
                For i As Integer = 0 To item2.Cells.Count - 1
                    item2.Cells(0).Value = False
                Next
            Next

        Else

            For Each item As DataGridViewRow In DataView.Rows
                For i As Integer = 0 To item.Cells.Count - 1
                    item.Cells(0).Value = False
                Next
            Next
            Return
        End If
    End Sub

    Private Sub CkboxSelectpartitionQlMGPTGrid_CheckedChanged(sender As Object, e As EventArgs) Handles CkboxSelectpartitionQlMGPTGrid.CheckedChanged
        If CkboxSelectpartitionQlMGPTGrid.CheckState = CheckState.Checked Then

            For Each item As DataGridViewRow In QlMGPTGrid.Rows
                For i As Integer = 0 To item.Cells.Count - 1
                    If item.Cells(2).Value.ToString() <> String.Empty Then
                        item.Cells(0).Value = True
                    End If

                    If item.Cells(2).Value.ToString() = String.Empty Then
                        item.Cells(0).Value = False
                    End If
                Next
            Next
            Return

            For Each item2 As DataGridViewRow In QlMGPTGrid.Rows
                For i As Integer = 0 To item2.Cells.Count - 1
                    item2.Cells(0).Value = False
                Next
            Next

        Else

            For Each item As DataGridViewRow In QlMGPTGrid.Rows
                For i As Integer = 0 To item.Cells.Count - 1
                    item.Cells(0).Value = False
                Next
            Next
            Return

        End If
    End Sub


    Private Sub ComboSp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSp.SelectedIndexChanged
        If ComboSp.SelectedIndex = 0 Then
            Mediatek.Mediatek_tool.Mediatek.Connection = "BromUSB"
        ElseIf ComboSp.SelectedIndex = 1 Then
            Mediatek.Mediatek_tool.Mediatek.Connection = "BromUART"
        End If
    End Sub

    Private Sub PythonAdbCommand(i As Integer)
        If Not PythonAdb.IsBusy Then
            PythonAdb.RunWorkerAsync()
        End If
    End Sub

    Private Sub ButtonScatter_Click(sender As Object, e As EventArgs) Handles ButtonScatter.Click
        CkboxSelectpartitionDataView.Checked = False

        Try
            Dim openFileDialog As New OpenFileDialog With {
                    .Title = "Choice Scatter Or OFP File !",
                    .Filter = "Scatter or OFP file  |*.txt;*.ofp"
                }

            If openFileDialog.ShowDialog() <> DialogResult.OK Then
                Return
            End If
            If (openFileDialog.FileName.Contains(".ofp")) Then
                OFPExtractor.fname = openFileDialog.FileName
                Dim folderBrowserDialog As New FolderBrowserDialog() With
                                {
                                .ShowNewFolderButton = True
                                }

                If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                    DataView.Rows.Clear()
                    Watch.Restart()
                    RtbClear()
                    Watch.Start()
                    foldersave = folderBrowserDialog.SelectedPath
                    OFPExtractor.LoadTabelKeyOFP()
                    OFPExtractor.OPFWorkerMTK.RunWorkerAsync()
                    OFPExtractor.OPFWorkerMTK.Dispose()
                End If
            Else

                Mediatek.Mediatek_tool.Mediatek.Scatterfile = openFileDialog.FileName
                Dim directory As New DirectoryInfo(openFileDialog.FileName.Replace("\" & openFileDialog.SafeFileName, ""))

                For Each file As FileInfo In directory.EnumerateFiles()

                    If file.Name.Contains("preloader") Then
                        Mediatek.Mediatek_tool.Mediatek.Preloader = file.FullName
                    End If
                Next

                If IsSupport(Mediatek.Mediatek_tool.Mediatek.Scatterfile) Then
                    Dim path As String = openFileDialog.FileName.Replace("\" & openFileDialog.SafeFileName, "")
                    Dim list As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)

                    If list.Count > 0 Then
                        TxtFlashScatter.Text = openFileDialog.SafeFileName
                        DataView.Rows.Clear()
                        DataView.BackgroundColor = Color.FromArgb(96, 94, 92)
                        DataView.ForeColor = ForeColor

                        For Each item As mtk In list

                            If item.Is_download.ToLower() = "true" Then
                                Dim text As String = IO.Path.Combine(path, item.File_name)

                                If File.Exists(text) Then
                                    DataView.Rows.Add(False, item.Partition_name, item.File_name, "double click ...", item.Linear_start_addr, item.Partition_size, item.Partition_index, text)
                                Else
                                    DataView.Rows.Add(False, item.Partition_name, String.Empty, "double click ...", item.Linear_start_addr, item.Partition_size, item.Partition_index, String.Empty)
                                End If
                            End If
                        Next

                        For Each item As DataGridViewRow In DataView.Rows

                            If item.Cells(1).Value.ToString().Contains("preloader") Then
                                Mediatek.Mediatek_tool.Mediatek.Preloader = item.Cells(7).Value.ToString()
                            End If
                        Next

                        If CPUType.ToLower() = "emmc" Then
                            ComboChip.SelectedIndex = 0
                        ElseIf CPUType.ToLower() = "ufs" Then
                            ComboChip.SelectedIndex = 1
                        End If
                    End If
                End If
            End If

        Catch
        End Try

        CkboxSelectpartitionDataView.Checked = True
    End Sub


    Private Sub Btn_DA_Click(sender As Object, e As EventArgs) Handles Btn_DA.Click
        Try
            Dim openFileDialog As New OpenFileDialog With {
                    .Title = "Choice DA File !",
                    .Filter = "MTK_AllInOne_DA.bin  |*.bin"
                }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                TxtFlashDA.Text = openFileDialog.SafeFileName
                Mediatek.Mediatek_tool.Mediatek.DA = openFileDialog.FileName
            End If

        Catch
        End Try
    End Sub

    Private Sub Btn_Auth_Click(sender As Object, e As EventArgs) Handles Btn_Auth.Click
        Try
            Dim openFileDialog As New OpenFileDialog With {
                    .Title = "Choice Auth File !",
                    .Filter = "Auth  |*.auth"
                }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                TxtFlashAuth.Text = openFileDialog.SafeFileName
                Mediatek.Mediatek_tool.Mediatek.Auth = openFileDialog.FileName
            End If

        Catch
        End Try
    End Sub

    Private Sub ButtonFlashSP_Click(sender As Object, e As EventArgs) Handles ButtonFlashSP.Click
        If BoxCustomFlash.Checked Then
            If TxtpreloderEMIFLash.Text <> "" Then

                If String.IsNullOrEmpty(Mediatek.Mediatek_tool.Mediatek.PreloaderEmi) Then
                    XtraMessageBox.Show("Preloader doesn't exist", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            Mediatek.Mediatek_list.Addresformat.Format.Clear()

            For Each item As DataGridViewRow In DataView.Rows
                Dim CheckBoxCell As DataGridViewCheckBoxCell = TryCast(item.Cells(0), DataGridViewCheckBoxCell)

                If CBool(CheckBoxCell.Value) = True Then
                    Mediatek.Mediatek_list.Addresformat.Format.Add(New Mediatek.Mediatek_list.Addresformat.Addres(item.Cells(DataView.Columns(1).Index).Value.ToString(), item.Cells(DataView.Columns(7).Index).Value.ToString()))
                End If
            Next

            If Mediatek.Mediatek_list.Addresformat.Format.Count <= 0 Then
                XtraMessageBox.Show(" Not Item Partition Select !!!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If Not BgwFlashfirmware.IsBusy Then
                KillCommand.ProcessKill()

                Mediatek.Mediatek_tool.Flashcommand.Customflash = True
                Mediatek.Mediatek_tool.MediatekInt.PathEditor = 20
                Mediatek.Mediatek_tool.FlashOption.Method = "Customflash"
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                WaitingStart.WaitingUniversaDevices(RichtextBox)
                BgwFlashfirmware.RunWorkerAsync()
                TimerSmart.Start()
            End If
        Else

            Firmware.Clear()

            For Each item As DataGridViewRow In DataView.Rows

                If Convert.ToBoolean(item.Cells(0).Value) Then
                    Firmware.Add(New Firmware(item.Cells(6).Value.ToString(), item.Cells(7).Value.ToString()))
                End If
            Next

            If Firmware.Count <= 0 Then
                XtraMessageBox.Show("Please choice correct Scatter firmware and select write partition ", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return
            End If

            If String.IsNullOrEmpty(TxtFlashDA.Text) Then
                XtraMessageBox.Show("Please fill correct MTK_ALLinOne.DA or ETC ", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return
            End If

            If Not BgwFlashfirmware.IsBusy Then
                KillCommand.ProcessKill()

                Mediatek.Mediatek_tool.Flashcommand.Flasfirmware = True
                Mediatek.Mediatek_tool.MediatekInt.PathEditor = 20

                If Main.SharedUI.CheckAuth.Checked Then
                    WaitingStart.WaitingDevices(RichtextBox)
                    BgwFlashfirmware.RunWorkerAsync()
                    PythonAdbCommand(2000)
                Else
                    WaitingStart.WaitingUniversaDevices(RichtextBox)
                    Thread.Sleep(1800)
                    BgwFlashfirmware.RunWorkerAsync()
                    PythonAdbCommand(1000)
                End If
            Else
                Console.WriteLine("BgwFlashfirmware Busy...")
                Return
            End If

        End If
    End Sub

    Public Shared Sub BgwFlashfirmware_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwFlashfirmware.DoWork
        Watch.Restart()
        Watch.Start()

        If WorkerMethod = "FLASH" Then

            If Mediatek.Mediatek_tool.Flashcommand.Flasfirmware Then

                If Not Main.SharedUI.CheckAuth.Checked Then

                    For i As Integer = 0 To Mediatek.Mediatek_tool.MediatekInt.PathEditor
                        Thread.Sleep(1000)
                        Dim parse As Double = Convert.ToDouble("20") - i
                        Console.WriteLine(parse)
                        Dim timeout As String = 20 - i

                        Main.SharedUI.LabelTimer.Invoke(Sub()
                                                            Main.SharedUI.LabelTimer.Visible = True
                                                            Main.SharedUI.LabelTimer.Text = timeout
                                                        End Sub)

                        Dim listport As List(Of Mediatek.Mediatek_list.Listport.Info) = Mediatek.Mediatek_list.Listport.Devicelists()

                        If listport.Count > 0 Then

                            For Each info As Mediatek.Mediatek_list.Listport.Info In listport

                                If info.Mediatekport.Contains("MediaTek USB") Then
                                    RichLogs(" ", Color.Lime, True, True)
                                    Mediatek.Mediatek_list.Listport.MtkUsbport = info.Mediatekport
                                    Mediatek.Mediatek_list.Listport.MtkComport = info.Comport
                                    Mediatek.Mediatek_list.Listport.Manufacturer = info.Manufacturer
                                    Mediatek.Mediatek_list.Listport.DeviceID = info.DeviceID
                                    Mediatek.Mediatek_list.Listport.ClassGuid = info.ClassGuid
                                    Main.SharedUI.ComboPort.Invoke(Sub()
                                                                       Main.SharedUI.ComboPort.Text = Mediatek.Mediatek_list.Listport.MtkUsbport
                                                                       Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                                                                   End Sub)
                                    RichLogs(" Found devices : ", Color.GhostWhite, False, False)
                                    RichLogs(info.Mediatekport, Color.Yellow, False, True)
                                    RichLogs(" Manufacturer  : ", Color.GhostWhite, False, False)
                                    RichLogs(info.Manufacturer, Color.Yellow, False, True)
                                    RichLogs(" Usb HadwareID : ", Color.GhostWhite, False, False)
                                    RichLogs(info.DeviceID, Color.Yellow, False, True)
                                    RichLogs(" Class GUID    : ", Color.GhostWhite, False, False)
                                    RichLogs(info.ClassGuid, Color.Yellow, False, True)

                                    If SharedUI.Radio_Download.Checked Then
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = DownloadOnly(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport, Firmware)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)
                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf SharedUI.Radio_Upgrade.Checked Then
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = FirmwareUpgrade(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport, Firmware)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf SharedUI.Radio_Format.Checked Then
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = FormatAllDownload(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport, Firmware)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    End If

                                Else
                                    Main.SharedUI.ComboPort.Invoke(Sub()
                                                                       Main.SharedUI.ComboPort.Properties.Items.AddRange(New Object() {info.Mediatekport})
                                                                       Main.SharedUI.ComboPort.EditValue = Main.SharedUI.ComboPort.Properties.Items(0)
                                                                   End Sub)
                                End If
                            Next
                        Else
                            Main.SharedUI.ComboPort.Invoke(Sub()
                                                               Main.SharedUI.ComboPort.Properties.Items.Clear()
                                                               Main.SharedUI.ComboPort.EditValue = String.Empty
                                                           End Sub)
                        End If

                        If parse = 0 Then

                            RichLogs(" Not Found", Color.Crimson, True, True)
                            TimeSpanElapsed.ElapsedTime(Watch)

                        End If

                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                            Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                            TimeSpanElapsed.ElapsedPending(Watch)
                            e.Cancel = True
                            Return
                        End If
                    Next

                Else

                    For i As Integer = 0 To Mediatek.Mediatek_tool.MediatekInt.PathEditor
                        Thread.Sleep(1000)
                        Dim parse As Double = Convert.ToDouble("20") - i
                        Console.WriteLine(parse)
                        Dim timeout As String = 20 - i

                        Main.SharedUI.LabelTimer.Invoke(Sub()
                                                            Main.SharedUI.LabelTimer.Visible = True
                                                            Main.SharedUI.LabelTimer.Text = timeout
                                                        End Sub)

                        Dim listport As List(Of Mediatek.Mediatek_list.Listport.Info) = Mediatek.Mediatek_list.Listport.Devicelists()

                        If listport.Count > 0 Then

                            For Each info As Mediatek.Mediatek_list.Listport.Info In listport

                                If info.Mediatekport.Contains("MediaTek USB") Then
                                    RichLogs(" ", Color.Lime, True, True)
                                    Mediatek.Mediatek_list.Listport.MtkUsbport = info.Mediatekport
                                    Mediatek.Mediatek_list.Listport.MtkComport = info.Comport
                                    Mediatek.Mediatek_list.Listport.Manufacturer = info.Manufacturer
                                    Mediatek.Mediatek_list.Listport.DeviceID = info.DeviceID
                                    Mediatek.Mediatek_list.Listport.ClassGuid = info.ClassGuid
                                    Main.SharedUI.ComboPort.Invoke(Sub()
                                                                       Main.SharedUI.ComboPort.Text = Mediatek.Mediatek_list.Listport.MtkUsbport
                                                                       Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                                                                   End Sub)

                                    If Mediatek.Authentication.Python.Authentication = "auto" Then
                                        Mediatek.Authentication.Python.Exploits("windows.xsd", SharedUI.BgwFlashfirmware, e)
                                    ElseIf Mediatek.Authentication.Python.Authentication = "usbdk" Then
                                        Mediatek.Authentication.Python.Command("payload", SharedUI.BgwFlashfirmware, e)
                                    End If

                                    If SharedUI.Radio_Download.Checked Then
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = DownloadOnly(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport, Firmware)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf SharedUI.Radio_Upgrade.Checked Then
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = FirmwareUpgrade(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport, Firmware)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            Console.WriteLine("Flash tool upgrade download Started...")
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf SharedUI.Radio_Format.Checked Then
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = FormatAllDownload(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport, Firmware)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    End If
                                Else
                                    Main.SharedUI.ComboPort.Invoke(Sub()
                                                                       Main.SharedUI.ComboPort.Properties.Items.AddRange(New Object() {info.Mediatekport})
                                                                       Main.SharedUI.ComboPort.EditValue = Main.SharedUI.ComboPort.Properties.Items(0)
                                                                   End Sub)
                                End If
                            Next
                        Else
                            Main.SharedUI.ComboPort.Invoke(Sub()
                                                               Main.SharedUI.ComboPort.Properties.Items.Clear()
                                                               Main.SharedUI.ComboPort.EditValue = String.Empty
                                                           End Sub)
                        End If

                        If parse = 0 Then

                            RichLogs(" Not Found", Color.Crimson, True, True)
                            TimeSpanElapsed.ElapsedTime(Watch)

                        End If

                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                            Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                            TimeSpanElapsed.ElapsedPending(Watch)
                            e.Cancel = True
                            Return
                        End If
                    Next
                End If

            ElseIf Mediatek.Mediatek_tool.Flashcommand.Formatdata Then

                If Not Main.SharedUI.CheckAuth.Checked Then

                    For i As Integer = 0 To Mediatek.Mediatek_tool.MediatekInt.PathEditor
                        Thread.Sleep(1000)
                        Dim parse As Double = Convert.ToDouble("20") - i
                        Console.WriteLine(parse)
                        Dim timeout As String = 20 - i

                        Main.SharedUI.LabelTimer.Invoke(Sub()
                                                            Main.SharedUI.LabelTimer.Visible = True
                                                            Main.SharedUI.LabelTimer.Text = timeout
                                                        End Sub)

                        Dim listport As List(Of Mediatek.Mediatek_list.Listport.Info) = Mediatek.Mediatek_list.Listport.Devicelists()

                        If listport.Count > 0 Then

                            For Each info As Mediatek.Mediatek_list.Listport.Info In listport

                                If info.Mediatekport.Contains("MediaTek USB") Then
                                    RichLogs(" ", Color.Lime, True, True)
                                    Mediatek.Mediatek_list.Listport.MtkUsbport = info.Mediatekport
                                    Mediatek.Mediatek_list.Listport.MtkComport = info.Comport
                                    Mediatek.Mediatek_list.Listport.Manufacturer = info.Manufacturer
                                    Mediatek.Mediatek_list.Listport.DeviceID = info.DeviceID
                                    Mediatek.Mediatek_list.Listport.ClassGuid = info.ClassGuid
                                    Main.SharedUI.ComboPort.Invoke(Sub()
                                                                       Main.SharedUI.ComboPort.Text = Mediatek.Mediatek_list.Listport.MtkUsbport
                                                                       Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                                                                   End Sub)
                                    RichLogs(" Found devices : ", Color.GhostWhite, False, False)
                                    RichLogs(info.Mediatekport, Color.Yellow, False, True)
                                    RichLogs(" Manufacturer  : ", Color.GhostWhite, False, False)
                                    RichLogs(info.Manufacturer, Color.Yellow, False, True)
                                    RichLogs(" Usb HadwareID : ", Color.GhostWhite, False, False)
                                    RichLogs(info.DeviceID, Color.Yellow, False, True)
                                    RichLogs(" Class GUID    : ", Color.GhostWhite, False, False)
                                    RichLogs(info.ClassGuid, Color.Yellow, False, True)

                                    If Mediatek.Mediatek_tool.FlashOption.Method = "FormatData" Then
                                        Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)

                                        For Each Addres As mtk In partaddres

                                            If Addres.Partition_name.Contains("userdata") Then
                                                RichLogs(Environment.NewLine & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs("Data", Color.DarkOrange, True, True)
                                                RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                                RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                                Exit For
                                            End If
                                        Next

                                        RichLogs(Environment.NewLine & " Formating Format Data ... ", Color.WhiteSmoke, True, False)
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "userdata", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "FormatMicloud" Then
                                        Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)

                                        For Each Addres As mtk In partaddres

                                            If Addres.Partition_name.Contains("persist") Then
                                                RichLogs(Environment.NewLine & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs("MI Account", Color.DarkOrange, True, True)
                                                RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                                RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                                Exit For
                                            Else
                                                RichLogs(Environment.NewLine & " Formating Partiton not Suport ...", Color.Yellow, True, True)
                                                Watch.[Stop]()
                                                Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                                fileInfo.Delete()
                                                TimeSpanElapsed.ElapsedTime(Watch)
                                                e.Cancel = True
                                                KillCommand.ProcessKill()
                                                Return
                                            End If
                                        Next

                                        RichLogs(Environment.NewLine & " Formating MI Account ... ", Color.WhiteSmoke, True, False)
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "persist", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "FormatFrp" Then
                                        Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)

                                        For Each Addres As mtk In partaddres

                                            If Addres.Partition_name.Contains("frp") Then
                                                RichLogs(Environment.NewLine & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs("FRP", Color.DarkOrange, True, True)
                                                RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                                RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                                Exit For
                                            End If
                                        Next

                                        RichLogs(Environment.NewLine & " Formating FRP Protection ... ", Color.WhiteSmoke, True, False)
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "frp", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "FormatSamfrp" Then
                                        Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)

                                        For Each Addres As mtk In partaddres

                                            If Addres.Partition_name.Contains("persistent") Then
                                                RichLogs(Environment.NewLine & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs("FRP", Color.DarkOrange, True, True)
                                                RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                                RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                                Exit For
                                            Else
                                                RichLogs(Environment.NewLine & " Formating Partiton not Suport ...", Color.Yellow, True, True)
                                                Watch.[Stop]()
                                                Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                                fileInfo.Delete()
                                                TimeSpanElapsed.ElapsedTime(Watch)
                                                e.Cancel = True
                                                KillCommand.ProcessKill()
                                                Return
                                            End If
                                        Next

                                        RichLogs(Environment.NewLine & " Formating FRP Protection ... ", Color.WhiteSmoke, True, False)
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "persistent", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    End If
                                Else
                                    Main.SharedUI.ComboPort.Invoke(Sub()
                                                                       Main.SharedUI.ComboPort.Properties.Items.AddRange(New Object() {info.Mediatekport})
                                                                       Main.SharedUI.ComboPort.EditValue = Main.SharedUI.ComboPort.Properties.Items(0)
                                                                   End Sub)
                                End If
                            Next
                        Else
                            Main.SharedUI.ComboPort.Invoke(Sub()
                                                               Main.SharedUI.ComboPort.Properties.Items.Clear()
                                                               Main.SharedUI.ComboPort.EditValue = String.Empty
                                                           End Sub)
                        End If

                        If parse = 0 Then
                            RichLogs(" Not Found", Color.Crimson, True, True)
                            TimeSpanElapsed.ElapsedTime(Watch)
                        End If

                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                            Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                            TimeSpanElapsed.ElapsedPending(Watch)
                            e.Cancel = True
                            Return
                        End If
                    Next
                Else

                    For i As Integer = 0 To Mediatek.Mediatek_tool.MediatekInt.PathEditor
                        Thread.Sleep(1000)
                        Dim parse As Double = Convert.ToDouble("20") - i
                        Console.WriteLine(parse)
                        Dim timeout As String = 20 - i

                        Main.SharedUI.LabelTimer.Invoke(Sub()
                                                            Main.SharedUI.LabelTimer.Visible = True
                                                            Main.SharedUI.LabelTimer.Text = timeout
                                                        End Sub)

                        Dim listport As List(Of Mediatek.Mediatek_list.Listport.Info) = Mediatek.Mediatek_list.Listport.Devicelists()

                        If listport.Count > 0 Then

                            For Each info As Mediatek.Mediatek_list.Listport.Info In listport

                                If info.Mediatekport.Contains("MediaTek USB") Then
                                    RichLogs("  ", Color.Lime, True, True)
                                    Mediatek.Mediatek_list.Listport.MtkUsbport = info.Mediatekport
                                    Mediatek.Mediatek_list.Listport.MtkComport = info.Comport
                                    Mediatek.Mediatek_list.Listport.Manufacturer = info.Manufacturer
                                    Mediatek.Mediatek_list.Listport.DeviceID = info.DeviceID
                                    Mediatek.Mediatek_list.Listport.ClassGuid = info.ClassGuid

                                    Main.SharedUI.ComboPort.Invoke(Sub()
                                                                       Main.SharedUI.ComboPort.Text = Mediatek.Mediatek_list.Listport.MtkUsbport
                                                                       Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                                                                   End Sub)

                                    If Mediatek.Authentication.Python.Authentication = "auto" Then
                                        Mediatek.Authentication.Python.Exploits("windows.xsd", SharedUI.BgwFlashfirmware, e)
                                    ElseIf Mediatek.Authentication.Python.Authentication = "usbdk" Then
                                        Mediatek.Authentication.Python.Command("payload", SharedUI.BgwFlashfirmware, e)
                                    End If

                                    If Mediatek.Mediatek_tool.FlashOption.Method = "FormatData" Then
                                        Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)

                                        For Each Addres As mtk In partaddres

                                            If Addres.Partition_name.Contains("userdata") Then
                                                RichLogs(Environment.NewLine & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs("Data", Color.DarkOrange, True, True)
                                                RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                                RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                                Exit For
                                            End If
                                        Next

                                        RichLogs(Environment.NewLine & " Formating Format Data ... ", Color.WhiteSmoke, True, False)
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "userdata", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else

                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "FormatMicloud" Then
                                        Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)

                                        For Each Addres As mtk In partaddres

                                            If Addres.Partition_name.Contains("persist") Then
                                                RichLogs(Environment.NewLine & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs("MI Account", Color.DarkOrange, True, True)
                                                RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                                RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                                Exit For
                                            Else
                                                RichLogs(Environment.NewLine & " Formating Partiton not Suport ...", Color.Yellow, True, True)
                                                Watch.[Stop]()
                                                Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                                fileInfo.Delete()
                                                TimeSpanElapsed.ElapsedTime(Watch)
                                                e.Cancel = True
                                                KillCommand.ProcessKill()
                                                Return
                                            End If
                                        Next

                                        RichLogs(Environment.NewLine & " Formating MI Account ... ", Color.WhiteSmoke, True, False)
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "persist", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else

                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "FormatFrp" Then
                                        Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)

                                        For Each Addres As mtk In partaddres

                                            If Addres.Partition_name.Contains("frp") Then
                                                RichLogs(Environment.NewLine & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs("FRP", Color.DarkOrange, True, True)
                                                RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                                RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                                Exit For
                                            End If
                                        Next

                                        RichLogs(Environment.NewLine & " Formating FRP Protection ... ", Color.WhiteSmoke, True, False)
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "frp", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else

                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "FormatSamfrp" Then
                                        Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)

                                        For Each Addres As mtk In partaddres

                                            If Addres.Partition_name.Contains("persistent") Then
                                                RichLogs(Environment.NewLine & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs("FRP", Color.DarkOrange, True, True)
                                                RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                                RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                                RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                            Else
                                                RichLogs(Environment.NewLine & " Formating Partiton not Suport ...", Color.Yellow, True, True)
                                                Watch.[Stop]()
                                                Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                                fileInfo.Delete()
                                                TimeSpanElapsed.ElapsedTime(Watch)
                                                e.Cancel = True
                                                KillCommand.ProcessKill()
                                                Return
                                            End If
                                        Next

                                        RichLogs(Environment.NewLine & " Formating FRP Protection ... ", Color.WhiteSmoke, True, False)
                                        Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "persistent", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkComport)
                                        Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwFlashfirmware, e)

                                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            TimeSpanElapsed.ElapsedPending(Watch)
                                            e.Cancel = True
                                            Return
                                        Else
                                            Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                            fileInfo.Delete()
                                            Watch.[Stop]()
                                            TimeSpanElapsed.ElapsedTime(Watch)
                                        End If
                                    End If
                                Else
                                    Main.SharedUI.ComboPort.Invoke(Sub()
                                                                       Main.SharedUI.ComboPort.Properties.Items.AddRange(New Object() {info.Mediatekport})
                                                                       Main.SharedUI.ComboPort.EditValue = Main.SharedUI.ComboPort.Properties.Items(0)
                                                                   End Sub)
                                End If
                            Next
                        Else
                            Main.SharedUI.ComboPort.Invoke(Sub()
                                                               Main.SharedUI.ComboPort.Properties.Items.Clear()
                                                               Main.SharedUI.ComboPort.EditValue = String.Empty
                                                           End Sub)
                        End If

                        If parse = 0 Then
                            RichLogs(" Not Found", Color.Crimson, True, True)
                            TimeSpanElapsed.ElapsedTime(Watch)
                        End If

                        If SharedUI.BgwFlashfirmware.CancellationPending Then
                            Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                            TimeSpanElapsed.ElapsedPending(Watch)
                            e.Cancel = True
                            Return
                        End If
                    Next
                End If


            ElseIf Mediatek.Mediatek_tool.Flashcommand.Customflash Then


                If Mediatek.Mediatek_tool.FlashOption.Method = "Customflash" Then

                    For Each addres As Mediatek.Mediatek_list.Addresformat.Addres In Mediatek.Mediatek_list.Addresformat.Format
                        File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.format, addres.Filename & ",")
                        File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.formatpath, addres.Filename & " " & "=""" + addres.Filepath & """" & "," & vbLf)
                    Next

                    Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.format)
                        Dim text As String

                        'While text IsNot Nothing
                        'Mediatek.Mediatek_tool.FlashOption.Textpartition = text
                        'text = streamReader.ReadLine()
                        'End While


                        While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                            Mediatek.Mediatek_tool.FlashOption.Textpartition = text
                        End While
                    End Using

                    If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.format) Then
                        File.Delete(Mediatek.Mediatek_tool.Unifersalformat.format)
                    End If

                    Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.formatpath)
                        Dim text As String

                        'While text IsNot Nothing
                        'If text.Contains(text.Replace(text.Substring(text.IndexOf("=") - 1), "")) Then
                        'Dim text2 As String = text.Substring(text.IndexOf("=") + 1)
                        'File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.format, text2)
                        'End If
                        'text = streamReader.ReadLine()
                        'End While


                        While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                            If text.Contains(text.Replace(text.Substring(text.IndexOf("=") - 1), "")) Then
                                Dim text2 As String = text.Substring(text.IndexOf("=") + 1)
                                File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.format, text2)
                            End If
                        End While
                    End Using

                    If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.formatpath) Then
                        File.Delete(Mediatek.Mediatek_tool.Unifersalformat.formatpath)
                    End If

                    Dim text3 As String = ""

                    Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.format)
                        Dim text As String

                        'While text IsNot Nothing
                        'text3 = text
                        'text = streamReader.ReadLine()
                        'End While


                        While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                            text3 = text
                        End While
                    End Using

                    If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.format) Then
                        File.Delete(Mediatek.Mediatek_tool.Unifersalformat.format)
                    End If

                    If SharedUI.CheckboxEMI.Checked Then
                        Mediatek.Authentication.Python.Command(String.Concat(New String() {"w", " ", Mediatek.Mediatek_tool.FlashOption.Textpartition.Remove(Mediatek.Mediatek_tool.FlashOption.Textpartition.Length - 1), " ", text3.Remove(text3.Length - 1), " ", "--preloader=", Mediatek.Mediatek_tool.Mediatek.PreloaderEmi}), SharedUI.BgwFlashfirmware, e)
                    Else
                        Mediatek.Authentication.Python.Command(String.Concat(New String() {"w", " ", Mediatek.Mediatek_tool.FlashOption.Textpartition.Remove(Mediatek.Mediatek_tool.FlashOption.Textpartition.Length - 1), " ", text3.Remove(text3.Length - 1)}), SharedUI.BgwFlashfirmware, e)
                    End If

                    If SharedUI.BgwFlashfirmware.CancellationPending Then

                        If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                            File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                        End If

                        TimeSpanElapsed.ElapsedPending(Watch)
                        e.Cancel = True
                        Return
                    Else

                        If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                            File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                        End If

                        Watch.[Stop]()
                        TimeSpanElapsed.ElapsedTime(Watch)
                    End If


                End If
            End If

        ElseIf WorkerMethod = "UNIFERSAL" Then

            If Mediatek.Mediatek_tool.FlashOption.Method = "Readgpttable" Then

                If SharedUI.CheckboxEMI.Checked Then
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"printgpt", " ", "--preloader=", Mediatek.Mediatek_tool.Mediatek.PreloaderEmi}), SharedUI.BgwFlashfirmware, e)
                Else
                    Mediatek.Authentication.Python.Command("printgpt", SharedUI.BgwFlashfirmware, e)
                End If

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Rebootstage" Then
                Mediatek.Authentication.Python.Command("reset", SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Erasegpttable" Then
                Dim text2 As String = ""

                For Each addres As Mediatek.Mediatek_list.Addresformat.Addres In Mediatek.Mediatek_list.Addresformat.Format
                    File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.format, addres.Filename & ",")
                Next

                Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.format)
                    Dim text As String

                    'While text IsNot Nothing
                    'text2 = text.Remove(text.Length - 1)
                    'text = streamReader.ReadLine()
                    'End While


                    While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                        text2 = text.Remove(text.Length - 1)
                    End While
                End Using

                If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.format) Then
                    File.Delete(Mediatek.Mediatek_tool.Unifersalformat.format)
                End If

                If SharedUI.CheckboxEMI.Checked Then
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"e", " ", text2, " ", "--preloader=", Mediatek.Mediatek_tool.Mediatek.PreloaderEmi}), SharedUI.BgwFlashfirmware, e)
                Else
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"e", " ", text2}), SharedUI.BgwFlashfirmware, e)
                End If

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Readpartitiontable" Then
                Dim arr As String = " " & Mediatek.Mediatek_tool.Mediatek.Savepartition & "=" & "," & vbLf
                Dim str As String = Mediatek.Mediatek_tool.FlashOption.Textpartition.Replace(",", arr)
                File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.format, str)

                Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.format)
                    Dim text As String

                    'While text IsNot Nothing
                    'If text.Contains(text.Replace(text.Substring(text.IndexOf("""") - 1), "")) Then
                    'Dim text2 As String = text.Replace(text, Mediatek.Mediatek_tool.Mediatek.Savepartition & "\" & text.Replace(text.Substring(text.IndexOf("""") - 1), ","))
                    'File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.formatpath, text2)
                    'End If
                    'text = streamReader.ReadLine()
                    'End While


                    While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                        If text.Contains(text.Replace(text.Substring(text.IndexOf("""") - 1), "")) Then
                            Dim text2 As String = text.Replace(text, Mediatek.Mediatek_tool.Mediatek.Savepartition & "\" & text.Replace(text.Substring(text.IndexOf("""") - 1), ","))
                            File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.formatpath, text2)
                        End If
                    End While
                End Using

                If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.format) Then
                    File.Delete(Mediatek.Mediatek_tool.Unifersalformat.format)
                End If

                Dim text3 As String = ""

                Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.formatpath)
                    Dim text As String

                    'While text IsNot Nothing
                    'text3 = text
                    'text = streamReader.ReadLine()
                    'End While


                    While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                        text3 = text
                    End While
                End Using

                If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.formatpath) Then
                    File.Delete(Mediatek.Mediatek_tool.Unifersalformat.formatpath)
                End If

                If SharedUI.CheckboxEMI.Checked Then
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"r", " ", Mediatek.Mediatek_tool.FlashOption.Textpartition.Remove(Mediatek.Mediatek_tool.FlashOption.Textpartition.Length - 1), " ", text3.Remove(text3.Length - 1), " ", "--preloader=", Mediatek.Mediatek_tool.Mediatek.PreloaderEmi}), SharedUI.BgwFlashfirmware, e)
                Else
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"r", " ", Mediatek.Mediatek_tool.FlashOption.Textpartition.Remove(Mediatek.Mediatek_tool.FlashOption.Textpartition.Length - 1), " ", text3.Remove(text3.Length - 1)}), SharedUI.BgwFlashfirmware, e)
                End If

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Writepartitiontable" Then

                For Each addres As Mediatek.Mediatek_list.Addresformat.Addres In Mediatek.Mediatek_list.Addresformat.Format
                    File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.format, addres.Filename & ",")
                    File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.formatpath, addres.Filename & " " & "=""" + addres.Filepath & """" & "," & vbLf)
                Next

                Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.format)
                    Dim text As String

                    'While text IsNot Nothing
                    'Mediatek.Mediatek_tool.FlashOption.Textpartition = text
                    'text = streamReader.ReadLine()
                    'End While


                    While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                        Mediatek.Mediatek_tool.FlashOption.Textpartition = text
                    End While
                End Using

                If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.format) Then
                    File.Delete(Mediatek.Mediatek_tool.Unifersalformat.format)
                End If

                Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.formatpath)
                    Dim text As String

                    'While text IsNot Nothing
                    'If text.Contains(text.Replace(text.Substring(text.IndexOf("=") - 1), "")) Then
                    'Dim text2 As String = text.Substring(text.IndexOf("=") + 1)
                    'File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.format, text2)
                    'End If
                    'text = streamReader.ReadLine()
                    'End While


                    While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                        If text.Contains(text.Replace(text.Substring(text.IndexOf("=") - 1), "")) Then
                            Dim text2 As String = text.Substring(text.IndexOf("=") + 1)
                            File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.format, text2)
                        End If
                    End While
                End Using

                If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.formatpath) Then
                    File.Delete(Mediatek.Mediatek_tool.Unifersalformat.formatpath)
                End If

                Dim text3 As String = ""

                Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.format)
                    Dim text As String

                    'While text IsNot Nothing
                    'text3 = text
                    'text = streamReader.ReadLine()
                    'End While


                    While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                        text3 = text
                    End While
                End Using

                If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.format) Then
                    File.Delete(Mediatek.Mediatek_tool.Unifersalformat.format)
                End If

                If SharedUI.CheckboxEMI.Checked Then
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"w", " ", Mediatek.Mediatek_tool.FlashOption.Textpartition.Remove(Mediatek.Mediatek_tool.FlashOption.Textpartition.Length - 1), " ", text3.Remove(text3.Length - 1), " ", "--preloader=", Mediatek.Mediatek_tool.Mediatek.PreloaderEmi}), SharedUI.BgwFlashfirmware, e)
                Else
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"w", " ", Mediatek.Mediatek_tool.FlashOption.Textpartition.Remove(Mediatek.Mediatek_tool.FlashOption.Textpartition.Length - 1), " ", text3.Remove(text3.Length - 1)}), SharedUI.BgwFlashfirmware, e)
                End If

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Readinfogpt" Then

                If SharedUI.CheckboxEMI.Checked Then
                    Dim text As String = """" & Mediatek.Mediatek_tool.Sourcefile.Dumped & """"
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"r", " ", "recovery", " ", text, " ", "--preloader=", Mediatek.Mediatek_tool.Mediatek.PreloaderEmi}), SharedUI.BgwFlashfirmware, e)
                Else
                    Dim text As String = """" & Mediatek.Mediatek_tool.Sourcefile.Dumped & """"
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"r", " ", "recovery", " ", text}), SharedUI.BgwFlashfirmware, e)
                End If

                If Mediatek.Mediatek_tool.FlashOption.progres <> 100 AndAlso Mediatek.Mediatek_tool.FlashOption.progres <> 0 Then
                    RichLogs("failed", Color.Red, True, True)
                    File.Delete(Mediatek.Mediatek_tool.Sourcefile.Andoidpath)
                    File.Delete(Mediatek.Mediatek_tool.Sourcefile.Dumped)
                    e.Cancel = True
                End If

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Dim directory As New DirectoryInfo(Path.GetDirectoryName(Mediatek.Mediatek_tool.Sourcefile.Andoidpath))

                    For Each file As FileInfo In directory.EnumerateFiles()
                        file.Delete()
                    Next

                    For Each subDirectory As DirectoryInfo In directory.EnumerateDirectories()
                        subDirectory.Delete(True)
                    Next

                    directory.Delete(True)
                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Dim directory As New DirectoryInfo(Path.GetDirectoryName(Mediatek.Mediatek_tool.Sourcefile.Andoidpath))

                    For Each file As FileInfo In directory.EnumerateFiles()
                        file.Delete()
                    Next

                    For Each subDirectory As DirectoryInfo In directory.EnumerateDirectories()
                        subDirectory.Delete(True)
                    Next

                    directory.Delete(True)
                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Bacupnvram" Then
                Dim str As String = Mediatek.Mediatek_tool.Mediatek.Savepartition & "\" + Mediatek.Mediatek_tool.FlashOption.NV_save.Replace(",", "," & Mediatek.Mediatek_tool.Mediatek.Savepartition & "\")
                Console.WriteLine(str)

                If SharedUI.CheckboxEMI.Checked Then
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"r", " ", Mediatek.Mediatek_tool.FlashOption.NV_save.Replace(".img", ""), " ", str, " ", "--preloader=", Mediatek.Mediatek_tool.Mediatek.PreloaderEmi}), SharedUI.BgwFlashfirmware, e)
                Else
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"r", " ", Mediatek.Mediatek_tool.FlashOption.NV_save.Replace(".img", ""), " ", str}), SharedUI.BgwFlashfirmware, e)
                End If

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Erasenvram" Then

                If SharedUI.CheckboxEMI.Checked Then
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"e", " ", Mediatek.Mediatek_tool.FlashOption.NV_save.Replace(".img", ""), " ", "--preloader=", Mediatek.Mediatek_tool.Mediatek.PreloaderEmi}), SharedUI.BgwFlashfirmware, e)
                Else
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"e", " ", Mediatek.Mediatek_tool.FlashOption.NV_save.Replace(".img", "")}), SharedUI.BgwFlashfirmware, e)
                End If

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Restorenvram" Then
                Dim directoryInfo As New DirectoryInfo(Mediatek.Mediatek_tool.Mediatek.Savepartition)
                Dim name As New List(Of String)()

                For Each fileInfo As FileInfo In directoryInfo.EnumerateFiles()
                    name.Add(fileInfo.Name & ",")
                Next

                Dim stringBuilder As New StringBuilder()

                For Each Build As String In name
                    stringBuilder.Append(Build)
                Next

                Dim text As String = stringBuilder.ToString().Remove(stringBuilder.ToString().Length - 1)
                Console.WriteLine(text)
                Dim text2 As String = """" & Path.GetDirectoryName(Mediatek.Mediatek_tool.Mediatek.Savepartition) & """\" & text.Replace(",", "," & """" & Path.GetDirectoryName(Mediatek.Mediatek_tool.Mediatek.Savepartition) & """\")
                Console.WriteLine(text2)

                If SharedUI.CheckboxEMI.Checked Then
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"w", " ", text.Replace(".img", ""), " ", text2, " ", "--preloader=", Mediatek.Mediatek_tool.Mediatek.PreloaderEmi}), SharedUI.BgwFlashfirmware, e)
                Else
                    Mediatek.Authentication.Python.Command(String.Concat(New String() {"w", " ", text.Replace(".img", ""), " ", text2}), SharedUI.BgwFlashfirmware, e)
                End If

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "BypassAuth" Then
                Mediatek.Authentication.Python.Command("payload", SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then
                    e.Cancel = True
                Else
                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "ReadRPMB" Then
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"da", " ", "rpmb", " ", "r"}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists("rpmb.bin") Then
                        File.Move("rpmb.bin", Mediatek.Mediatek_tool.FlashOption.RPMB)
                    End If

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "WriteRPMB" Then
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"da", " ", "rpmb", " ", "w", " ", Mediatek.Mediatek_tool.FlashOption.RPMB}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "EraseRPMB" Then
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"da", " ", "rpmb", " ", "e"}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "UniversalUnlock" Then
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"da", " ", "seccfg", " ", "unlock"}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Universalrelock" Then
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"da", " ", "seccfg", " ", "lock"}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Universalfrp" Then
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"e", " ", "frp"}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "EraseSAMfrp" Then
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"e", " ", "persistent"}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "ErasefrpOEM" Then
                Dim str As String = """" & Mediatek.Mediatek_tool.ExSamsung.persistent & """"
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"w", " ", "persistent", " ", str}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "ErasefrpLOST" Then
                Dim str As String = """" & Mediatek.Mediatek_tool.ExSamsung.param & """"
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"w", " ", "param", " ", str}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Universalformat" Then
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"e", " ", "userdata"}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            ElseIf Mediatek.Mediatek_tool.FlashOption.Method = "Universalmierse" Then
                Mediatek.Authentication.Python.Command(String.Concat(New String() {"e", " ", "persist"}), SharedUI.BgwFlashfirmware, e)

                If SharedUI.BgwFlashfirmware.CancellationPending Then

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    TimeSpanElapsed.ElapsedPending(Watch)
                    e.Cancel = True
                    Return
                Else

                    If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                        File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                    End If

                    Watch.[Stop]()
                    TimeSpanElapsed.ElapsedTime(Watch)
                End If
            End If
        End If
    End Sub

    Public Shared Sub BgwFlashfirmware_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwFlashfirmware.RunWorkerCompleted
        Mediatek.Mediatek_tool.FlashOption.Method = String.Empty
        Mediatek.Mediatek_tool.Flashcommand.Config(Mediatek.Mediatek_tool.Flashcommand.Formatdisable)

        Main.SharedUI.Progressbar1.EditValue = 100
        Main.SharedUI.Progressbar2.EditValue = 100
        Mediatek.Mediatek_list.Listport.MtkComport = String.Empty
        SharedUI.TimerSmart.[Stop]()
    End Sub
    Private Sub MainTab_SelectedPageChanged(sender As Object, e As EventArgs) Handles MainTab.SelectedPageChanged
        If MainTab.SelectedTabPageIndex = 0 Then
            WorkerMethod = "FLASH"
            DataView.Visible = True
            CkboxSelectpartitionDataView.Visible = True
            HScrollBarMtkFlashDataView.Visible = True
            VScrollBarMtkFlashDataView.Visible = True
            QlMGPTGrid.Visible = False
            CkboxSelectpartitionQlMGPTGrid.Visible = False
            HScrollBarMtkFlashQlMGPTGrid.Visible = False
            VScrollBarMtkFlashQlMGPTGrid.Visible = False
        Else
            WorkerMethod = "UNIFERSAL"
            DataView.Visible = False
            CkboxSelectpartitionDataView.Visible = False
            HScrollBarMtkFlashDataView.Visible = False
            VScrollBarMtkFlashDataView.Visible = False
            QlMGPTGrid.Visible = True
            CkboxSelectpartitionQlMGPTGrid.Visible = True
            HScrollBarMtkFlashQlMGPTGrid.Visible = True
            VScrollBarMtkFlashQlMGPTGrid.Visible = True
        End If
        Console.WriteLine(WorkerMethod)
    End Sub
    Private Sub VScrollBarMtkFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBarMtkFlashDataView.Scroll
        If DataView.Rows.Count > 0 Then
            VScrollBarMtkFlashDataView.LargeChange = DataView.Rows.Count
            VScrollBarMtkFlashDataView.Maximum = DataView.Rows.Count - 1 + VScrollBarMtkFlashDataView.LargeChange - 1
            DataView.FirstDisplayedScrollingRowIndex = e.NewValue
        End If
    End Sub

    Private Sub HScrollBarMtkFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBarMtkFlashDataView.Scroll
        DataView.FirstDisplayedScrollingColumnIndex = e.NewValue
    End Sub

    Private Sub VScrollBarMtkFlashQlMGPTGrid_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBarMtkFlashQlMGPTGrid.Scroll
        If QlMGPTGrid.Rows.Count > 0 Then
            VScrollBarMtkFlashQlMGPTGrid.LargeChange = QlMGPTGrid.Rows.Count
            VScrollBarMtkFlashQlMGPTGrid.Maximum = QlMGPTGrid.Rows.Count - 1 + VScrollBarMtkFlashQlMGPTGrid.LargeChange - 1
            QlMGPTGrid.FirstDisplayedScrollingRowIndex = e.NewValue
        End If
    End Sub

    Private Sub HScrollBarMtkFlashQlMGPTGrid_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBarMtkFlashQlMGPTGrid.Scroll
        QlMGPTGrid.FirstDisplayedScrollingColumnIndex = e.NewValue
    End Sub

    Public Shared Sub PythonAdb_DoWork(sender As Object, e As DoWorkEventArgs) Handles PythonAdb.DoWork
        Mediatek.Authentication.Python.Adbpython("", SharedUI.PythonAdb, e)
        Thread.Sleep(1000)
    End Sub

    Public Shared Sub PythonAdb_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles PythonAdb.RunWorkerCompleted
        KillCommand.ProcessKill()
    End Sub

    Private Sub CheckboxEMI_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxEMI.CheckedChanged
        If CheckboxEMI.Checked Then
            ButtonEMI.Enabled = True
        Else
            ButtonEMI.Enabled = False
            Mediatek.Mediatek_tool.Mediatek.PreloaderEmi = String.Empty
            TxtpreloderEMI.Text = ""
        End If
    End Sub
    Private Sub ButtonEMI_Click(sender As Object, e As EventArgs) Handles ButtonEMI.Click
        If Not BgwFlashfirmware.IsBusy Then
            Dim openFileDialog As New OpenFileDialog With {
                .Title = "Choice file !",
                .Filter = "  |*.bin*|Other|*.*"
            }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Mediatek.Mediatek_tool.Mediatek.PreloaderEmi = openFileDialog.FileName
                TxtpreloderEMI.Text = openFileDialog.FileName
            End If

        End If
    End Sub

    Private Sub BtnGPTread_Click(sender As Object, e As EventArgs) Handles BtnGPTread.Click
        If CheckboxEMI.Checked Then

            If String.IsNullOrEmpty(Mediatek.Mediatek_tool.Mediatek.PreloaderEmi) Then
                XtraMessageBox.Show("Preloader doesn't exist", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Readgpttable"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            QlMGPTGrid.Rows.Clear()
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        Else
            Return
        End If
    End Sub

    Private Sub TimerSmart_Tick(sender As Object, e As EventArgs) Handles TimerSmart.Tick
        If Not WorkerAtoport.IsBusy Then
            WorkerAtoport.RunWorkerAsync()
        End If
    End Sub

    Private Sub WorkerAtoport_DoWork(sender As Object, e As DoWorkEventArgs) Handles WorkerAtoport.DoWork
        Dim listport As List(Of Mediatek.Mediatek_list.Listport.Info) = Mediatek.Mediatek_list.Listport.Devicelists()

        If listport.Count > 0 Then

            For Each info As Mediatek.Mediatek_list.Listport.Info In listport
                Mediatek.Mediatek_list.Listport.MtkUsbport = info.Mediatekport
                Mediatek.Mediatek_list.Listport.MtkComport = info.Comport
                Mediatek.Mediatek_list.Listport.Manufacturer = info.Manufacturer
                Mediatek.Mediatek_list.Listport.DeviceID = info.DeviceID
                Mediatek.Mediatek_list.Listport.ClassGuid = info.ClassGuid
                Main.SharedUI.ComboPort.Invoke(Sub()
                                                   Main.SharedUI.ComboPort.Properties.Items.AddRange(New Object() {info.Mediatekport})
                                                   Main.SharedUI.ComboPort.EditValue = Main.SharedUI.ComboPort.Properties.Items(0)
                                               End Sub)
            Next
        Else
            listport.Clear()
            Main.SharedUI.ComboPort.Invoke(Sub()
                                               Main.SharedUI.ComboPort.Properties.Items.Clear()
                                               Main.SharedUI.ComboPort.EditValue = String.Empty
                                           End Sub)
        End If
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
    Private Sub ButtonRebbot_Click(sender As Object, e As EventArgs) Handles ButtonRebbot.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Rebootstage"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            QlMGPTGrid.Rows.Clear()
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        Else
            Return
        End If
    End Sub

    Private Sub ButtonEraseGPT_Click(sender As Object, e As EventArgs) Handles ButtonEraseGPT.Click
        If CheckboxEMI.Checked Then

            If String.IsNullOrEmpty(Mediatek.Mediatek_tool.Mediatek.PreloaderEmi) Then
                XtraMessageBox.Show("Preloader doesn't exist", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If


        Mediatek.Mediatek_list.Addresformat.Format.Clear()

        For Each row As DataGridViewRow In QlMGPTGrid.Rows
            Dim CheckBoxCell As DataGridViewCheckBoxCell = TryCast(row.Cells(0), DataGridViewCheckBoxCell)

            If CBool(CheckBoxCell.Value) = True Then
                Mediatek.Mediatek_list.Addresformat.Format.Add(New Mediatek.Mediatek_list.Addresformat.Addres(row.Cells(QlMGPTGrid.Columns(1).Index).Value.ToString(), row.Cells(QlMGPTGrid.Columns(4).Index).Value.ToString()))
            End If
        Next

        If Mediatek.Mediatek_list.Addresformat.Format.Count <= 0 Then
            XtraMessageBox.Show(" Not Item Partition Select !!!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Erasegpttable"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        Else
            Return
        End If
    End Sub

    Private Sub DataView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataView.CellDoubleClick
        If e.ColumnIndex = 3 Then
            Dim openFileDialog As New OpenFileDialog With {
                .Title = String.Format("Choice {0}  file !", DataView.CurrentRow.Cells(1).Value),
                .Filter = String.Format("{0}  |*.*|Other|*.*", DataView.CurrentRow.Cells(1).Value)
            }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                DataView.CurrentRow.Cells(2).Value = openFileDialog.SafeFileName.Replace(".img", "").Replace(".bin", "")
                DataView.CurrentRow.Cells(2).Style.SelectionForeColor = Color.Chocolate
                DataView.CurrentRow.Cells(7).Value = openFileDialog.FileName
                DataView.CurrentRow.Cells(0).Value = True
            End If

        End If
    End Sub

    Private Sub QlMGPTGrid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles QlMGPTGrid.CellDoubleClick
        If e.ColumnIndex = 4 Then
            Dim openFileDialog As New OpenFileDialog With {
                .Title = String.Format("Choice {0}  file !", QlMGPTGrid.CurrentRow.Cells(1).Value),
                .Filter = String.Format("{0}  |*.*|Other|*.*", QlMGPTGrid.CurrentRow.Cells(1).Value)
            }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                QlMGPTGrid.CurrentRow.Cells(4).Value = openFileDialog.FileName
                QlMGPTGrid.CurrentRow.Cells(0).Value = True
            End If

        End If
    End Sub

    Private Sub ButtonReadGPT_Click(sender As Object, e As EventArgs) Handles ButtonReadGPT.Click

        If CheckboxEMI.Checked Then

            If String.IsNullOrEmpty(Mediatek.Mediatek_tool.Mediatek.PreloaderEmi) Then
                XtraMessageBox.Show("Preloader doesn't exist", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Mediatek.Mediatek_list.Addresformat.Format.Clear()

        For Each row As DataGridViewRow In QlMGPTGrid.Rows
            Dim CheckBoxCell As DataGridViewCheckBoxCell = TryCast(row.Cells(0), DataGridViewCheckBoxCell)

            If CBool(CheckBoxCell.Value) = True Then
                Mediatek.Mediatek_list.Addresformat.Format.Add(New Mediatek.Mediatek_list.Addresformat.Addres(row.Cells(QlMGPTGrid.Columns(1).Index).Value.ToString(), row.Cells(QlMGPTGrid.Columns(4).Index).Value.ToString()))
            End If
        Next

        If Mediatek.Mediatek_list.Addresformat.Format.Count <= 0 Then
            XtraMessageBox.Show(" Not Item Partition Select !!!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Not BgwFlashfirmware.IsBusy Then

            For Each addres As Mediatek.Mediatek_list.Addresformat.Addres In Mediatek.Mediatek_list.Addresformat.Format
                File.AppendAllText(Mediatek.Mediatek_tool.Unifersalformat.format, addres.Filename & ",")
            Next

            Using streamReader As New StreamReader(Mediatek.Mediatek_tool.Unifersalformat.format)
                Dim text As String

                'While text IsNot Nothing
                'Mediatek.Mediatek_tool.FlashOption.Textpartition = text
                'text = streamReader.ReadLine()
                'End While


                While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                    Mediatek.Mediatek_tool.FlashOption.Textpartition = text
                End While
            End Using

            If File.Exists(Mediatek.Mediatek_tool.Unifersalformat.format) Then
                File.Delete(Mediatek.Mediatek_tool.Unifersalformat.format)
            End If

            Dim saveFileDialog1 As New SaveFileDialog With {
            .FileName = "Save Here"
            }

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim str As String = Path.Combine(New String() {Path.GetDirectoryName(saveFileDialog1.FileName)})
                Mediatek.Mediatek_tool.Mediatek.Savepartition = """" & str & """"
                KillCommand.ProcessKill()
                Mediatek.Mediatek_tool.FlashOption.Method = "Readpartitiontable"
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                WaitingStart.WaitingUniversaDevices(RichtextBox1)
                BgwFlashfirmware.RunWorkerAsync()
                TimerSmart.Start()
            End If
        Else
            Return
        End If
    End Sub

    Private Sub ButtonGptWrite_Click(sender As Object, e As EventArgs) Handles ButtonGptWrite.Click
        If CheckboxEMI.Checked Then

            If String.IsNullOrEmpty(Mediatek.Mediatek_tool.Mediatek.PreloaderEmi) Then
                XtraMessageBox.Show("Preloader doesn't exist", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Mediatek.Mediatek_list.Addresformat.Format.Clear()

        For Each row As DataGridViewRow In QlMGPTGrid.Rows
            Dim CheckBoxCell As DataGridViewCheckBoxCell = TryCast(row.Cells(0), DataGridViewCheckBoxCell)

            If CBool(CheckBoxCell.Value) = True Then
                Mediatek.Mediatek_list.Addresformat.Format.Add(New Mediatek.Mediatek_list.Addresformat.Addres(row.Cells(QlMGPTGrid.Columns(1).Index).Value.ToString(), row.Cells(QlMGPTGrid.Columns(4).Index).Value.ToString()))
            End If
        Next

        If Mediatek.Mediatek_list.Addresformat.Format.Count <= 0 Then
            XtraMessageBox.Show(" Not Item Partition Select !!!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Writepartitiontable"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonReadInfo_Click(sender As Object, e As EventArgs) Handles ButtonReadInfo.Click
        If CheckboxEMI.Checked Then

            If String.IsNullOrEmpty(Mediatek.Mediatek_tool.Mediatek.PreloaderEmi) Then
                XtraMessageBox.Show("Preloader doesn't exist", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        If Not BgwFlashfirmware.IsBusy Then

            If Not File.Exists(Mediatek.Mediatek_tool.Sourcefile.Andoidpath) Then
                Directory.CreateDirectory(Path.GetDirectoryName(Mediatek.Mediatek_tool.Sourcefile.Andoidpath))
                File.WriteAllBytes(Mediatek.Mediatek_tool.Sourcefile.Andoidpath, My.Resources.C4)
            End If

            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Readinfogpt"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonUniNvBackup_Click(sender As Object, e As EventArgs) Handles ButtonUniNvBackup.Click
        If CheckboxEMI.Checked Then

            If String.IsNullOrEmpty(Mediatek.Mediatek_tool.Mediatek.PreloaderEmi) Then
                XtraMessageBox.Show("Preloader doesn't exist", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        If Not BgwFlashfirmware.IsBusy Then
            Dim saveFileDialog As New SaveFileDialog With {
                .FileName = Mediatek.Mediatek_tool.FlashOption.NV_save
            }

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim str As String = Path.Combine(New String() {Path.GetDirectoryName(saveFileDialog.FileName)})
                Mediatek.Mediatek_tool.Mediatek.Savepartition = """" & str & """"
                KillCommand.ProcessKill()
                Mediatek.Mediatek_tool.FlashOption.Method = "Bacupnvram"
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                WaitingStart.WaitingUniversaDevices(RichtextBox1)
                BgwFlashfirmware.RunWorkerAsync()
                TimerSmart.Start()
            End If
        End If
    End Sub

    Private Sub ButtonNvErase_Click(sender As Object, e As EventArgs) Handles ButtonNvErase.Click
        If CheckboxEMI.Checked Then

            If String.IsNullOrEmpty(Mediatek.Mediatek_tool.Mediatek.PreloaderEmi) Then
                XtraMessageBox.Show("Preloader doesn't exist", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Erasenvram"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonWrNvram_Click(sender As Object, e As EventArgs) Handles ButtonWrNvram.Click
        If CheckboxEMI.Checked Then

            If String.IsNullOrEmpty(Mediatek.Mediatek_tool.Mediatek.PreloaderEmi) Then
                XtraMessageBox.Show("Preloader doesn't exist", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        If Not BgwFlashfirmware.IsBusy Then
            Dim folderBrowserDialog As New FolderBrowserDialog()

            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Mediatek.Mediatek_tool.Mediatek.Savepartition = folderBrowserDialog.SelectedPath & "\"
                KillCommand.ProcessKill()
                Mediatek.Mediatek_tool.FlashOption.Method = "Restorenvram"
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                WaitingStart.WaitingUniversaDevices(RichtextBox1)
                BgwFlashfirmware.RunWorkerAsync()
                TimerSmart.Start()
            End If
        End If
    End Sub

    Private Sub ButtonAuth_Click(sender As Object, e As EventArgs) Handles ButtonAuth.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "BypassAuth"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonRDrpmb_Click(sender As Object, e As EventArgs) Handles ButtonRDrpmb.Click
        If Not BgwFlashfirmware.IsBusy Then
            Dim saveFileDialog As New SaveFileDialog With {
                .FileName = "rpmb.bin"
            }

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Mediatek.Mediatek_tool.FlashOption.RPMB = saveFileDialog.FileName
                Dim fileInfo As New FileInfo(Mediatek.Mediatek_tool.FlashOption.RPMB)
                fileInfo.Delete()
                KillCommand.ProcessKill()
                Mediatek.Mediatek_tool.FlashOption.Method = "ReadRPMB"
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                WaitingStart.WaitingUniversaDevices(RichtextBox1)
                BgwFlashfirmware.RunWorkerAsync()
                TimerSmart.Start()
            End If
        End If
    End Sub

    Private Sub ButtonRPMBwrite_Click(sender As Object, e As EventArgs) Handles ButtonRPMBwrite.Click
        If Not BgwFlashfirmware.IsBusy Then
            Dim openFileDialog As New OpenFileDialog With {
                .Title = "Choice file !",
                .Filter = "  |*.bin*|Other|*.*"
            }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Mediatek.Mediatek_tool.FlashOption.RPMB = """" & openFileDialog.FileName & """"
                KillCommand.ProcessKill()
                Mediatek.Mediatek_tool.FlashOption.Method = "WriteRPMB"
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                WaitingStart.WaitingUniversaDevices(RichtextBox1)
                BgwFlashfirmware.RunWorkerAsync()
                TimerSmart.Start()
            End If
        End If
    End Sub

    Private Sub ButtonRpmbErase_Click(sender As Object, e As EventArgs) Handles ButtonRpmbErase.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "EraseRPMB"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonUBL_Click(sender As Object, e As EventArgs) Handles ButtonUBL.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "UniversalUnlock"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonRelockUBL_Click(sender As Object, e As EventArgs) Handles ButtonRelockUBL.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Universalrelock"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonAllFRP_Click(sender As Object, e As EventArgs) Handles ButtonAllFRP.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Universalfrp"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonFRP_SAM_Click(sender As Object, e As EventArgs) Handles ButtonFRP_SAM.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "EraseSAMfrp"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub BtnSAM_FRP_Oem_Click(sender As Object, e As EventArgs) Handles BtnSAM_FRP_Oem.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "ErasefrpOEM"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub BtnEraseSAM_LOST_Click(sender As Object, e As EventArgs) Handles BtnEraseSAM_LOST.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "ErasefrpLOST"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonFormatUser_Click(sender As Object, e As EventArgs) Handles ButtonFormatUser.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Universalformat"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub ButtonMiReset_Click(sender As Object, e As EventArgs) Handles ButtonMiReset.Click
        If Not BgwFlashfirmware.IsBusy Then
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.FlashOption.Method = "Universalmierse"
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox1)
            BgwFlashfirmware.RunWorkerAsync()
            TimerSmart.Start()
        End If
    End Sub

    Private Sub BoxCustomFlash_CheckedChanged(sender As Object, e As EventArgs) Handles BoxCustomFlash.CheckedChanged
        If BoxCustomFlash.Checked Then
            Radio_Upgrade.Enabled = False
            Radio_Format.Enabled = False
            Btn_Auth.Enabled = False
            TxtFlashAuth.Enabled = False
            Btn_DA.Enabled = False
            TxtFlashDA.Enabled = False
            TxtpreloderEMIFLash.Enabled = True
            Btn_EMIFlash.Enabled = True
            ComboSp.SelectedIndex = 1
        Else
            Radio_Upgrade.Enabled = True
            Radio_Format.Enabled = True
            Btn_Auth.Enabled = True
            TxtFlashAuth.Enabled = True
            Btn_DA.Enabled = True
            TxtFlashDA.Enabled = True
            TxtpreloderEMIFLash.Enabled = False
            Btn_EMIFlash.Enabled = False
            ComboSp.SelectedIndex = 0
        End If
    End Sub

End Class

