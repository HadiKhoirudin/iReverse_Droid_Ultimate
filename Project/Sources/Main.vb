Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.IO.Ports
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Newtonsoft.Json.Linq
Imports Reverse_Tool.Bismillah.FIREHOSE.FIREHOSE_MANAGER

Public Class Main


    Private ReadOnly server As String



    Public Shared IsAutoLoader As Boolean = False
    Public Shared username As String
    Public Shared password As String
    Public Shared MainSelected As String = "flash"
    Public Shared MainSelectedChip As String = "Qualcomm"
    Public Shared QcMerkTerpilih As String = "Xiaomi"
    Public Shared StopMe As String = "QcFlash"

    Public Shared AdbDotNetcmd As String

    Friend Shared SharedUI As Main

    Public WithEvents AdbDotNet As BackgroundWorker

    Public Ports As SerialPort
    Public Shared PortQcom As Integer = 0

    Public AdbToolCtrl = New AdbTool
    Public DirectISPCtrl = New DirectISP
    Public FastbootUICtrl = New FastbootUI
    Public MtkFlashCtrl = New MtkFlash
    Public MtkUnlockCtrl = New MtkUnlock
    Public QcFlashCtrl = New QcFlash
    Public QcUnlockCtrl = New QcUnlock
    Public SettingsCtrl = New Settings
    <DXCategory("Appearance")>
    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Property StartColor As Color

    Public Sub New()
        AddHandler Load, AddressOf LoadMenu
        AddHandler Load, AddressOf Main_Shown
        server = "http://localhost/iReverseWebsite/datatool/"
        Ports = New SerialPort()
        InitializeComponent()
        SharedUI = Me

        lblusername.Text = Login.username

        Dim input As String = Login.hwidPC.Substring(0, 20)
        Dim chunkSize As Integer = 4
        Dim result As String = ""

        For i As Integer = 0 To input.Length - 1 Step chunkSize
            If i + chunkSize <= input.Length Then
                result += input.Substring(i, chunkSize) + "-"
            Else
                result += input.Substring(i)
            End If
        Next

        result = result.TrimEnd("-"c)

        Console.WriteLine(result)
        lblhwid.Text = result

        CariportQC.WorkerSupportsCancellation = True
        CariportQC.WorkerReportsProgress = True
        AddHandler CariportQC.DoWork, AddressOf WorkerFlashRun
        AddHandler CariportQC.RunWorkerCompleted, AddressOf CariPortsDone

        SaharaWorker.WorkerSupportsCancellation = True
        SaharaWorker.WorkerReportsProgress = True
        AddHandler SaharaWorker.DoWork, AddressOf sendingLoader
        AddHandler SaharaWorker.RunWorkerCompleted, AddressOf sendingloaderDone
        AddHandler SaharaWorker.ProgressChanged, AddressOf ProcessSendingLoader

        FirehoseWorker.WorkerSupportsCancellation = True
        FirehoseWorker.WorkerReportsProgress = True
        AddHandler FirehoseWorker.DoWork, AddressOf ConnectToFlshLoader
        AddHandler FirehoseWorker.RunWorkerCompleted, AddressOf AllDone
        AddHandler FirehoseWorker.ProgressChanged, AddressOf ProcessSendingLoader

        OFPExtractor.OPFWorkerQC.WorkerSupportsCancellation = True
        OFPExtractor.OPFWorkerQC.WorkerReportsProgress = True
        AddHandler OFPExtractor.OPFWorkerQC.DoWork, AddressOf OFPExtractor.BruteKeyQcom
        AddHandler OFPExtractor.OPFWorkerQC.RunWorkerCompleted, AddressOf OFPExtractor.AllDone


    End Sub


    Shared Sub New()
        ReDim loader(-1)
        ReDim OutDecripted(-1)
        PortQcom = 0
        sendingloaderStatus = False
        TypeMemory = "emmc"
        SectorSize = "512"
    End Sub

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function SetThreadExecutionState(ByVal esFlags As EXECUTION_STATE) As EXECUTION_STATE
    End Function

    ' Constants for EXECUTION_STATE
    Public Enum EXECUTION_STATE As UInteger
        ES_SYSTEM_REQUIRED = &H1
        ES_DISPLAY_REQUIRED = &H2
        ES_CONTINUOUS = &H80000000UI
    End Enum

    ' Method to prevent Windows from entering sleep mode
    Public Shared Sub PreventSleep()
        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS Or EXECUTION_STATE.ES_SYSTEM_REQUIRED Or EXECUTION_STATE.ES_DISPLAY_REQUIRED)
    End Sub

    ' Method to allow Windows to enter sleep mode
    Public Shared Sub AllowSleep()
        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS)
    End Sub

    Private Sub XtraMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichLogs("<+++++++++++++++++++  iREVERSE DROID ULTIMATE  ++++++++++++++++++++>", Color.White, True, True)
        RichLogs("► Software       : ", Color.White, True, False)
        RichLogs("Qualcomm & Mediatek Tool", Color.White, True, True)
        RichLogs("► Version Tool   : ", Color.White, True, False)
        RichLogs("20-06-2023", Color.White, True, True)
        RichLogs("► License        : ", Color.White, True, False)
        RichLogs("Developer", Color.White, True, True)
        RichLogs("► Version Update : ", Color.White, True, False)
        RichLogs("Beta I based [ 22-12-2022 ] Version", Color.White, True, True)
        RichLogs("  ==================================================================", Color.White, True, True)
        RichLogs("► Websites       : https://hadikhoirudin.github.io/ireverse", Color.White, True, True)
        RichLogs("  ==================================================================", Color.White, True, True)
        RichLogs("", Color.White, True, True)
        PreventSleep() ' Call this method when your program starts to prevent sleep mode
    End Sub

    Private Sub XtraMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        AllowSleep() ' Call this method when your program is closing to allow sleep mode
        KillCommand.ProcessKill()
        Thread.Sleep(100)

        If Directory.Exists(Path.GetDirectoryName(Mediatek.Authentication.Pythonfile.DElet)) Then
        End If

        Thread.Sleep(100)

        If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont)) Then
            ClearDirectory.DeleteDirrectory(Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont))
        End If

        Thread.Sleep(100)

        If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Flashtoolexe)) Then
        End If

        Thread.Sleep(100)

        SystemIsExit = True
        Windows.Forms.Application.[Exit]()
    End Sub

    Public Sub LoadMenu(sender As Object, e As EventArgs)
        LabelTime.Text = DateTime.Now.ToLongTimeString()
        FormCtrl.Controls.Clear()
        FormCtrl.Controls.Add(QcFlashCtrl)
        QcFlashCtrl.BringToFront()
        QcFlashCtrl.Dock = DockStyle.Fill
        ButtonFlashQc.Enabled = False
        ButtonFlashMtk.Enabled = True
        PictureEditSelectedChip.EditValue = Global.Reverse_Tool.My.Resources.logochipqualcomm
        If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
            Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
            For Each File As FileInfo In directory.EnumerateFiles()
                If File.Name.Contains("MTK_AllInOne_DA.bin") Then
                    Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                    MtkFlash.SharedUI.SharedUI.TxtFlashDA.Text = File.Name
                End If
            Next
        End If
        Mediatek.Mediatek_tool.Mediatek.Connection = "BromUSB"
        Mediatek.Authentication.Python.Authentication = ComboAuth.SelectedItem.ToString().ToLower()
        Mediatek.Mediatek_list.Modellist.Brand = "ASUS"
        Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False
        Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\ASUS.json")
        MtkUnlock.SharedUI.ListBoxview.DataSource = Models
        MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
        Mediatek.Authentication.Pythonfile.Python = Path.Combine(Windows.Forms.Application.StartupPath & "/Tools/process/process")
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs)
        Dim list As String = My.Resources.Spdata
        Dim stringlist As String() = list.Split(New Char(1) {Microsoft.VisualBasic.vbCr, Microsoft.VisualBasic.vbLf}, StringSplitOptions.RemoveEmptyEntries)

        For Each value As String In stringlist

            If Not File.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Flashtoolexe) & "\" & value) Then

                If Not Flashtool_Doworker.IsBusy Then
                    ClearDirectory.DeleteDirrectory(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Flashtoolexe))
                    Flashtool_Doworker.RunWorkerAsync()
                End If
            End If
        Next

        If File.Exists(Mediatek.Mediatek_tool.Flashpath.Flashtoolexe) Then
            Dim directory2 As DirectoryInfo = New DirectoryInfo(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Flashtoolexe) & "/")

            For Each file As FileInfo In directory2.EnumerateFiles()

                If file.Name.Contains("QMSL_MSVC10R.dll") Then
                    Mediatek.Mediatek_tool.Flashpath.Flashtoolexe = file.FullName
                End If
            Next
        End If

        Dim directory As DirectoryInfo = New DirectoryInfo(Path.GetDirectoryName(Mediatek.Authentication.Pythonfile.Python))
        Dim a As New DirectoryInfo(directory.FullName) With {
            .Attributes = FileAttributes.Hidden Or FileAttributes.System
        }

        For Each file As FileInfo In directory.EnumerateFiles()
            Dim b As New FileInfo(file.FullName) With {
                .Attributes = FileAttributes.Hidden Or FileAttributes.System
            }
        Next

        For Each subDirectory As DirectoryInfo In directory.EnumerateDirectories()
            Dim c As New DirectoryInfo(subDirectory.FullName) With {
                .Attributes = FileAttributes.Hidden Or FileAttributes.System
            }
        Next
    End Sub
    Private Sub MenuOneClick(merk As String)
        ReDim loader(-1)
        ReDim OutDecripted(-1)
        datafile = ""
        QcMerkTerpilih = merk
        Try
            Dim webRequest As WebRequest = WebRequest.Create(String.Concat(server, merk.ToString().ToUpper(), ".txt"))
            webRequest.Method = "POST"
            webRequest.ContentType = "application/x-www-form-urlencoded"
            webRequest.Timeout = 10000
            webRequest.GetRequestStream().Close()
            Dim streamReader As StreamReader = New StreamReader(webRequest.GetResponse().GetResponseStream())
            Dim str As String = ""
            Dim num As Integer = 20
            Dim response As HttpWebResponse = DirectCast(webRequest.GetResponse(), HttpWebResponse)
            Dim ListDevices = New JObject()
            Dim DataDevices As ArrayList = New ArrayList()
            Dim DataModels As ArrayList = New ArrayList()
            Dim number As Integer = 0
            If response.StatusCode = HttpStatusCode.OK Then
                Dim RichTextBoxJSON As New RichTextBox
                While Not streamReader.EndOfStream
                    str = streamReader.ReadLine()
                    Dim str1 As String = ""
                    Dim str2 As String = ""
                    Dim str3 As String = "Qualcomm"
                    Dim str4 As String = "Auth"
                    Dim str5 As String = "EDL"
                    Dim strArrays As String() = str.Split(New Char() {","c})
                    str1 = strArrays(0)
                    str2 = strArrays(1)
                    num = num + 30
                    ListDevices.Devices = merk & " " & str1
                    ListDevices.Models = str2
                    ListDevices.Platform = str3
                    ListDevices.Conn = str4
                    ListDevices.Broom = str5
                    RichTextBoxJSON.AppendText(ListDevices.ToString & ",")
                    number += 1
                End While
                Console.WriteLine("[" & RichTextBoxJSON.Text & "]")
                Dim Models As List(Of Qualcomm.Qualcomm_list.ListDevice.Info) = Qualcomm.Qualcomm_list.ListDevice.DataSource("[" & RichTextBoxJSON.Text & "]")
                QcUnlock.SharedUI.ListBoxview.DataSource = Models
                QcUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
            Else
                XtraMessageBox.Show(String.Concat("server error ", response.StatusCode.ToString), "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch exception As Exception
            XtraMessageBox.Show(exception.ToString(), "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub

    Public Shared Sub Flashtool_Doworker_DoWork(sender As Object, e As DoWorkEventArgs) Handles Flashtool_Doworker.DoWork
        Dim sevenZipPath As String = Path.Combine(Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().Location), If(Environment.Is64BitProcess, "x64", "x86"), "7z.dll")
        SevenZip.SevenZipBase.SetLibraryPath(sevenZipPath)
        Dim sevenZipExtractor As SevenZip.SevenZipExtractor = New SevenZip.SevenZipExtractor(Mediatek.Mediatek_tool.Flashtoolpath.DevExpres, "collabs0#0#")
        sevenZipExtractor.ExtractArchive(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Flashtoolexe))
        Dim list As String = My.Resources.Spdata
        Dim stringlist As String() = list.Split(New Char(1) {Microsoft.VisualBasic.vbCr, Microsoft.VisualBasic.vbLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim directory2 As DirectoryInfo = New DirectoryInfo(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Flashtoolexe) & "/")

        For Each file As FileInfo In directory2.EnumerateFiles()

            If file.Name.Contains("QMSL_MSVC10R.dll") Then
                Mediatek.Mediatek_tool.Flashpath.Flashtoolexe = file.FullName
            End If

            For Each value As String In stringlist
                If file.Name.Contains(value) Then
                    Dim a As New FileInfo(file.FullName) With {
                    .Attributes = FileAttributes.Hidden Or FileAttributes.System
            }
                End If
            Next

        Next
    End Sub

    Private Sub Combo_AllInOne_DA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_AllInOne_DA.SelectedIndexChanged
        If Combo_AllInOne_DA.SelectedIndex = 0 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DA.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 1 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DA.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 2 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DA_.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 3 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DA_4-19_-signed.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 4 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DA_5.1420.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 5 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DA_5.1824.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 6 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DA_5.2136.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 7 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DA_5.2152.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 8 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DA_sig.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 9 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_AllInOne_DAA.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 10 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_OPPO_DA.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
        If Combo_AllInOne_DA.SelectedIndex = 11 Then
            If Directory.Exists(Path.GetDirectoryName(Mediatek.Mediatek_tool.Flashpath.Download_DA)) Then
                Dim directory As DirectoryInfo = New DirectoryInfo(Mediatek.Mediatek_tool.Flashpath.Download_DA)
                For Each File As FileInfo In directory.EnumerateFiles()
                    If File.Name.Contains("MTK_XIAOMI_DA_6765_6785_6768_6873_6885_6853.bin") Then
                        Mediatek.Mediatek_tool.Mediatek.DA = File.FullName
                        MtkFlash.SharedUI.TxtFlashDA.Text = File.Name
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ComboAuth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAuth.SelectedIndexChanged
        Mediatek.Authentication.Python.Authentication = ComboAuth.SelectedItem.ToString().ToLower()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox.TextChanged
        RichTextBox.Invoke(Sub()
                               RichTextBox.SelectionStart = RichTextBox.Text.Length
                               RichTextBox.ScrollToCaret()
                           End Sub)
    End Sub

    Private Sub TimerTime_Tick(sender As Object, e As EventArgs) Handles TimerTime.Tick
        LabelTime.Text = DateTime.Now.ToLongTimeString()
        TimerTime.Start()
    End Sub

    Public Shared Sub ButtonSTOP_Click(sender As Object, e As EventArgs) Handles ButtonSTOP.Click
        Console.WriteLine("STOP")
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.SharedUI.BgwFlashfirmware.IsBusy OrElse MtkUnlock.SharedUI.SharedUI.BgwUnlocked.IsBusy Then
                RichLogs(" ", Color.Red, True, True)
                RichLogs("Button STOP clicked process will end! ", Color.Yellow, True, False)
                Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                MtkFlash.SharedUI.SharedUI.BgwFlashfirmware.CancelAsync()
                MtkUnlock.SharedUI.SharedUI.BgwUnlocked.CancelAsync()
                KillCommand.ProcessKill()
            End If
        Else
            If FirehoseWorker.IsBusy Then
                RichLogs(" ", Color.Red, True, True)
                RichLogs("Button STOP clicked process will end! ", Color.Yellow, True, False)
                FirehoseWorker.CancelAsync()
                FirehoseWorker.Dispose()
            End If
            If OFPExtractor.OPFWorkerQC.IsBusy Then
                RichLogs(" ", Color.Red, True, True)
                RichLogs("Button STOP clicked process will end! ", Color.Yellow, True, False)
                OFPExtractor.OPFWorkerQC.CancelAsync()
                OFPExtractor.OPFWorkerQC.Dispose()
            End If
            If CariportQC.IsBusy Then
                WaktuCari = 1
            End If
            If FastbootUI.SharedUI.FastbootWorker.IsBusy Then
                RichLogs(" ", Color.Red, True, True)
                RichLogs("Button STOP clicked process will end! ", Color.Yellow, True, False)
                FastbootUI.SharedUI.FastbootWorker.CancelAsync()
                FastbootUI.SharedUI.FastbootWorker.Dispose()
                KillCommand.ProcessKill()
            End If
        End If
    End Sub

    Private Sub ButtonMiModel_Click(sender As Object, e As EventArgs) Handles ButtonMiModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "XIAOMI"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\XIAOMI.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\XIAOMI.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            StopMe = "QcUnlock"
            MenuOneClick("XIAOMI")
            FormCtrl.Controls.Clear()
            FormCtrl.Controls.Add(QcUnlockCtrl)
            QcUnlockCtrl.BringToFront()
            QcUnlockCtrl.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonVivoModel_Click(sender As Object, e As EventArgs) Handles ButtonVivoModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "VIVO"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\VIVO.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\VIVO.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            StopMe = "QcUnlock"
            MenuOneClick("VIVO")
            FormCtrl.Controls.Clear()
            FormCtrl.Controls.Add(QcUnlockCtrl)
            QcUnlockCtrl.BringToFront()
            QcUnlockCtrl.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonOppoModel_Click(sender As Object, e As EventArgs) Handles ButtonOppoModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "OPPO"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\OPPO.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\OPPO.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            StopMe = "QcUnlock"
            MenuOneClick("OPPO")
            FormCtrl.Controls.Clear()
            FormCtrl.Controls.Add(QcUnlockCtrl)
            QcUnlockCtrl.BringToFront()
            QcUnlockCtrl.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonRealmeModel_Click(sender As Object, e As EventArgs) Handles ButtonRealmeModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "REALME"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\REALME.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\REALME.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            StopMe = "QcUnlock"
            MenuOneClick("REALME")
            FormCtrl.Controls.Clear()
            FormCtrl.Controls.Add(QcUnlockCtrl)
            QcUnlockCtrl.BringToFront()
            QcUnlockCtrl.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonAssusModel_Click(sender As Object, e As EventArgs) Handles ButtonAssusModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "ASUS"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\ASUS.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\ASUS.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            StopMe = "QcUnlock"
            MenuOneClick("ASUS")
            FormCtrl.Controls.Clear()
            FormCtrl.Controls.Add(QcUnlockCtrl)
            QcUnlockCtrl.BringToFront()
            QcUnlockCtrl.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonSamsungModel_Click(sender As Object, e As EventArgs) Handles ButtonSamsungModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "SAMSUNG"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\SAMSUNG.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\SAMSUNG.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            XtraMessageBox.Show("Saat Ini Untuk SAMSUNG Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'Me.MenuOneClick("SAMSUNG")
            'FormCtrl.Controls.Clear()
            'FormCtrl.Controls.Add(QcUnlock)
            'QcUnlock.SharedUI.BringToFront()
            'QcUnlock.SharedUI.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonMeizuModel_Click(sender As Object, e As EventArgs) Handles ButtonMeizuModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "MEIZU"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\MEIZU.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\MEIZU.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            XtraMessageBox.Show("Saat Ini Untuk MEIZU Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'Me.MenuOneClick("MEIZU")
            'FormCtrl.Controls.Clear()
            'FormCtrl.Controls.Add(QcUnlock)
            'QcUnlock.SharedUI.BringToFront()
            'QcUnlock.SharedUI.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonHuaweiModel_Click(sender As Object, e As EventArgs) Handles ButtonHuaweiModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "HUAWEI"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\HUAWEI.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\HUAWEI.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            XtraMessageBox.Show("Saat Ini Untuk HUAWEI Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'Me.MenuOneClick("HUAWEI")
            'FormCtrl.Controls.Clear()
            'FormCtrl.Controls.Add(QcUnlock)
            'QcUnlock.SharedUI.BringToFront()
            'QcUnlock.SharedUI.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonNokiaModel_Click(sender As Object, e As EventArgs) Handles ButtonNokiaModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "NOKIA"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\NOKIA.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\NOKIA.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            XtraMessageBox.Show("Saat Ini Untuk NOKIA Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'Me.MenuOneClick("NOKIA")
            'FormCtrl.Controls.Clear()
            'FormCtrl.Controls.Add(QcUnlock)
            'QcUnlock.SharedUI.BringToFront()
            'QcUnlock.SharedUI.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonInfinixModel_Click(sender As Object, e As EventArgs) Handles ButtonInfinixModel.Click
        If MainSelectedChip = "Mediatek" Then
            If MtkFlash.SharedUI.BgwFlashfirmware.IsBusy Then
                Return
            End If

            Mediatek.Mediatek_list.Modellist.Brand = "INFINIX"
            Mediatek.Mediatek_tool.MediatekInt.ListAllredy = False

            If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

                If Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = False Then
                    FormCtrl.Controls.Clear()
                    FormCtrl.Controls.Add(MtkUnlockCtrl)
                    MtkUnlockCtrl.BringToFront()
                    MtkUnlockCtrl.Dock = DockStyle.Fill
                    Mediatek.Mediatek_tool.MediatekInt.Mtk_Unlock = True
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\INFINIX.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                Else
                    Dim Models As List(Of Mediatek.Mediatek_list.ListDevice.Info) = Mediatek.Mediatek_list.ListDevice.DataSource(Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\Model\INFINIX.json")
                    MtkUnlock.SharedUI.ListBoxview.DataSource = Models
                    MtkUnlock.SharedUI.labelTotal.Text = Models.Count.ToString() & " " & "Models"
                End If
            End If
        Else
            XtraMessageBox.Show("Saat Ini Untuk INFINIX Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'Me.MenuOneClick("INFINIX")
            'FormCtrl.Controls.Clear()
            'FormCtrl.Controls.Add(QcUnlock)
            'QcUnlock.SharedUI.BringToFront()
            'QcUnlock.SharedUI.Dock = DockStyle.Fill
        End If
    End Sub

    Public Sub TimerPython()
        If Not AdbPython.IsBusy Then
            KillCommand.ProcessKill()
            AdbPython.RunWorkerAsync()
        End If
    End Sub

    Private Sub ButtonFlashMtk_Click(sender As Object, e As EventArgs) Handles ButtonFlashMtk.Click, SimpleButton2.Click
        PictureEditSelectedChip.EditValue = Global.Reverse_Tool.My.Resources.logochipmediatek
        MainSelectedChip = "Mediatek"
        CheckAuth.Visible = True
        labelControl3.Visible = True
        ComboBroom.Visible = True
        labelControl4.Visible = True
        Combo_AllInOne_DA.Visible = True
        labelControl5.Visible = True
        ComboAuth.Visible = True
        FormCtrl.Controls.Clear()
        ButtonFlashQc.Enabled = True
        ButtonFlashMtk.Enabled = False
        If MainSelected = "flash" Then
            FormCtrl.Controls.Add(MtkFlashCtrl)
            MtkFlashCtrl.BringToFront()
            MtkFlashCtrl.Dock = DockStyle.Fill
        Else
            FormCtrl.Controls.Add(MtkUnlockCtrl)
            MtkUnlockCtrl.BringToFront()
            MtkUnlockCtrl.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub ButtonFlashQc_Click(sender As Object, e As EventArgs) Handles ButtonFlashQc.Click, ButtonFlashApple.Click
        PictureEditSelectedChip.EditValue = Global.Reverse_Tool.My.Resources.logochipqualcomm
        MainSelectedChip = "Qualcomm"
        FormCtrl.Controls.Clear()
        FormCtrl.Controls.Add(QcFlashCtrl)
        QcFlashCtrl.BringToFront()
        QcFlashCtrl.Dock = DockStyle.Fill
        ButtonFlashQc.Enabled = False
        ButtonFlashMtk.Enabled = True
    End Sub

    Private Sub labelControl1_Click(sender As Object, e As EventArgs) Handles labelControlFlash.Click
        MainSelected = "flash"
        FormCtrl.Controls.Clear()
        If MainSelectedChip = "Qualcomm" Then
            MenuEx = MenuEksekusi.manual
            FormCtrl.Controls.Add(QcFlashCtrl)
            QcFlashCtrl.BringToFront()
            QcFlashCtrl.Dock = DockStyle.Fill
        Else
            FormCtrl.Controls.Add(MtkFlashCtrl)
            MtkFlashCtrl.BringToFront()
            MtkFlashCtrl.Dock = DockStyle.Fill
        End If
    End Sub
    Private Sub labelControl2_Click(sender As Object, e As EventArgs) Handles labelControl2.Click
        MainSelected = "unlock"
        FormCtrl.Controls.Clear()
        If MainSelectedChip = "Mediatek" Then
            FormCtrl.Controls.Add(MtkUnlockCtrl)
            MtkUnlockCtrl.BringToFront()
            MtkUnlockCtrl.Dock = DockStyle.Fill
        Else
            MenuEx = MenuEksekusi.oneclick
            MenuOneClick("ASUS")
            FormCtrl.Controls.Add(QcUnlockCtrl)
            QcUnlockCtrl.BringToFront()
            QcUnlockCtrl.Dock = DockStyle.Fill
        End If
    End Sub

    Public Sub ProcessBar1(Process As Long, total As Long)
        Progressbar1.Invoke(New Action(Sub()
                                           Progressbar1.EditValue = CInt(Math.Round(Process * 100L / total))
                                       End Sub))
    End Sub

    Public Sub ProcessBar2(Process As Long, total As Long)
        Progressbar2.Invoke(New Action(Sub()
                                           Progressbar2.EditValue = CInt(Math.Round(Process * 100L / total))
                                       End Sub))
    End Sub

    Public Sub labelControlADBIdent_Click(sender As Object, e As EventArgs) Handles labelControlADBIdent.Click
        RichTextBox.Clear()
        If comboUSB.Text.Contains("PHYSICALDRIVE") Then
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs("IDENTIFY", Color.Orange, True, True)
            RichLogs(" Connect   : ", Color.White, True, False)
            RichLogs("Direct ISP", Color.DeepSkyBlue, True, True)
            RichLogs(" Disk      : ", Color.White, True, False)
            RichLogs(comboUSB.Text, Color.DeepSkyBlue, True, True)
            RichLogs(" ", Color.DeepSkyBlue, True, True)
            RichLogs(" ", Color.DeepSkyBlue, True, True)
            Delay(3)

            Dim thread As System.Threading.Thread = New System.Threading.Thread(AddressOf eMMCISP.Identity)
            thread.Start()

        End If
        'LabelTimer.Visible = True
        'RichLogs("Reading Device Info : ... ", Color.White, False, True)
        'RichLogs(Fastboot.Command("getvar:all").Payload, Color.White, False, True)
        'AdbDotNet.RunWorkerAsync()
    End Sub

    Private Sub AdbDotNet_DoWork(sender As Object, e As DoWorkEventArgs) Handles AdbDotNet.DoWork
        AdbDotNetcmd = "ls"
        SharedUI.AdbToolCtrl.adbcmd(AdbDotNetcmd, AdbDotNet, e)
    End Sub

    Private Sub labelControlRefresh_Click(sender As Object, e As EventArgs) Handles labelControlRefresh.Click
        RichTextBox.Clear()
        If Ports.IsOpen Then
            Ports.Close()
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text = "qwerty1234" Then
            FormCtrl.Controls.Clear()
            FormCtrl.Controls.Add(SettingsCtrl)
            SettingsCtrl.BringToFront()
            SettingsCtrl.Dock = DockStyle.Fill
        End If
    End Sub

    Private WithEvents LabelControlADBManager As LabelControl
    Private WithEvents LabelControlISPDirect As LabelControl
    Private WithEvents LabelControlFastboot As LabelControl

    Private Sub LabelControlFastboot_Click(sender As Object, e As EventArgs) Handles LabelControlFastboot.Click
        FormCtrl.Controls.Clear()
        FormCtrl.Controls.Add(FastbootUICtrl)
        FastbootUICtrl.BringToFront()
        FastbootUICtrl.Dock = DockStyle.Fill
    End Sub

    Private Sub LabelControlISPDirect_Click(sender As Object, e As EventArgs) Handles LabelControlISPDirect.Click
        FormCtrl.Controls.Clear()
        FormCtrl.Controls.Add(DirectISPCtrl)
        DirectISPCtrl.BringToFront()
        DirectISPCtrl.Dock = DockStyle.Fill
    End Sub


    Private Sub LabelControlADBManager_Click(sender As Object, e As EventArgs) Handles LabelControlADBManager.Click

    End Sub
End Class
