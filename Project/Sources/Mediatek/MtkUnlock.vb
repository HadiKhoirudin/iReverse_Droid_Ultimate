Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Microsoft.VisualBasic
Imports Reverse_Tool.DXApplication.Mtkxml
Imports SevenZip


Public Class MtkUnlock

    Friend Shared SharedUI As MtkUnlock
    Public Sub New()
        InitializeComponent()
        SharedUI = Me
        Watch = New Stopwatch()
        AddHandler Load, AddressOf MtkUnlock_Load
    End Sub

    Private Sub MtkUnlock_Load(sender As Object, e As EventArgs)
        UnlockMethod = BableUniBrom.Text
        Try
            Ground.Controls.Clear()
            Ground.Controls.Add(UI_Unibrom)
            UI_Unibrom.BringToFront()
            UI_Unibrom.Dock = DockStyle.Fill
        Catch

        End Try
    End Sub

    Public Sub CheckListBrand(brand As String)

        Dim list As String() = New String() {}

        If UnlockMethod = BableUniBrom.Text Then

            If brand.Contains("XIAOMI") Then
                list = Mediatek.Mediatek_list.Modellist.Brandlist.xiaomi
            Else
                list = Mediatek.Mediatek_list.Modellist.Brandlist.listall
            End If
        ElseIf UnlockMethod = BableSafe.Text Then
            list = Mediatek.Mediatek_list.Modellist.Brandlist.miscpara
        ElseIf UnlockMethod = BableMeta.Text Then
            list = Mediatek.Mediatek_list.Modellist.Brandlist.Entermeta
        End If

        Mediatek.Mediatek_list.Modellist.CreatingCommand(list, UnlockMethod)


    End Sub

    Private Sub ListBoxview_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs)
        If e.Index Mod 2 = 0 Then
            e.Appearance.BackColor = Color.FromArgb(64, 64, 64)
        Else
            e.Appearance.BackColor = Color.DimGray
        End If

        If e.State.HasFlag(DrawItemState.Selected) Then
            e.Appearance.BackColor = Color.FromArgb(0, 122, 204)
        ElseIf e.State = DrawItemState.HotLight Then
            e.Appearance.BackColor = Color.FromArgb(0, 122, 204)
        End If
    End Sub

    Private Sub BableUniBrom_Click(sender As Object, e As EventArgs) Handles BableUniBrom.Click
        UnlockMethod = BableUniBrom.Text
        CheckListBrand(Mediatek.Mediatek_list.Modellist.Brand)
    End Sub

    Public Sub Progress_Command(sender As Object, e As EventArgs)
        If Not BgwUnlocked.IsBusy Then
            Dim text = CType(sender, SimpleButton).Text
            Mediatek.Mediatek_tool.FlashOption.Method = text
            If Equals(text, "READ INFO") Then
                If Not File.Exists(Mediatek.Mediatek_tool.Sourcefile.Andoidpath) Then
                    Directory.CreateDirectory(Path.GetDirectoryName(Mediatek.Mediatek_tool.Sourcefile.Andoidpath))
                    File.WriteAllBytes(Mediatek.Mediatek_tool.Sourcefile.Andoidpath, My.Resources.C4)
                End If
                WaitingStart.WaitingUniversaDevices(RichtextBox)
            Else
                Mediatek.Mediatek_tool.Flashcommand.Formatdata = True
                WaitingStart.WaitingUniversaDevices(RichtextBox)
            End If
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.MediatekInt.PathEditor = 20
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            BgwUnlocked.RunWorkerAsync()
            Console.WriteLine(text)
        End If
    End Sub

    Public Sub SafeFormat_Command(sender As Object, e As EventArgs)
        If Not BgwUnlocked.IsBusy Then
            Dim text = CType(sender, SimpleButton).Text
            Mediatek.Mediatek_tool.FlashOption.Method = text
            KillCommand.ProcessKill()
            Mediatek.Mediatek_tool.Flashcommand.Writememory = True
            Mediatek.Mediatek_tool.MediatekInt.PathEditor = 20
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            WaitingStart.WaitingUniversaDevices(RichtextBox)
            BgwUnlocked.RunWorkerAsync()
            Console.WriteLine(text)
        End If
    End Sub
    Private Sub BableSafe_Click(sender As Object, e As EventArgs) Handles BableSafe.Click
        UnlockMethod = BableSafe.Text
        CheckListBrand(String.Empty)
    End Sub

    Private Sub BableMeta_Click(sender As Object, e As EventArgs) Handles BableMeta.Click
        UnlockMethod = BableMeta.Text
        CheckListBrand(String.Empty)
    End Sub

    Private Sub BableImei_Click(sender As Object, e As EventArgs) Handles BableImei.Click
        UnlockMethod = BableImei.Text
        CheckListBrand(String.Empty)
    End Sub

    Public Shared Sub BgwUnlocked_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwUnlocked.DoWork
        Watch.Restart()
        Watch.Start()
        If Equals(Mediatek.Mediatek_tool.FlashOption.Method, "READ INFO") Then
            Dim text As String = """" & Mediatek.Mediatek_tool.Sourcefile.Dumped & """"
            Mediatek.Authentication.Python.Command(String.Concat(New String() {"r", " ", "recovery", " ", text}), SharedUI.BgwUnlocked, e)
            If SharedUI.BgwUnlocked.CancellationPending Then
                If File.Exists(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock) Then
                    File.Delete(Mediatek.Mediatek_tool.Mediatek.Preloaderunlock)
                End If
                Dim directory As DirectoryInfo = New DirectoryInfo(Path.GetDirectoryName(Mediatek.Mediatek_tool.Sourcefile.Andoidpath))
                For Each File As FileInfo In directory.EnumerateFiles()
                    File.Delete()
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
                Dim directory As DirectoryInfo = New DirectoryInfo(Path.GetDirectoryName(Mediatek.Mediatek_tool.Sourcefile.Andoidpath))
                For Each File As FileInfo In directory.EnumerateFiles()
                    File.Delete()
                Next
                For Each subDirectory As DirectoryInfo In directory.EnumerateDirectories()
                    subDirectory.Delete(True)
                Next
                directory.Delete(True)
                Watch.Stop()
                TimeSpanElapsed.ElapsedTime(Watch)
            End If
        Else
            For i As Integer = 0 To Mediatek.Mediatek_tool.MediatekInt.PathEditor
                Thread.Sleep(1000)
                Dim parse = Convert.ToDouble("20") - i
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
                                                               Main.SharedUI.ComboPort.Properties.Items.AddRange(New Object() {info.Mediatekport})
                                                               Main.SharedUI.ComboPort.EditValue = Main.SharedUI.ComboPort.Properties.Items(0)
                                                               Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                                                           End Sub)
                        End If
                        If Main.SharedUI.CheckAuth.Checked Then
                            If Equals(Mediatek.Authentication.Python.Authentication, "auto") Then
                                Mediatek.Authentication.Python.Exploits("windows.xsd", SharedUI.BgwUnlocked, e)
                            ElseIf Equals(Mediatek.Authentication.Python.Authentication, "usbdk") Then
                                Mediatek.Authentication.Python.Command("payload", SharedUI.BgwUnlocked, e)
                            End If
                        Else
                            RichLogs(" Found devices : ", Color.GhostWhite, False, False)
                            RichLogs(info.Mediatekport, Color.Yellow, False, True)
                            RichLogs(" Manufacturer  : ", Color.GhostWhite, False, False)
                            RichLogs(info.Manufacturer, Color.Yellow, False, True)
                            RichLogs(" Usb HadwareID : ", Color.GhostWhite, False, False)
                            RichLogs(info.DeviceID, Color.Yellow, False, True)
                            RichLogs(" Class GUID    : ", Color.GhostWhite, False, False)
                            RichLogs(info.ClassGuid, Color.Yellow, False, True)
                        End If
                        If Mediatek.Mediatek_tool.Flashcommand.Formatdata Then
                            If SharedUI.BgwUnlocked.CancellationPending Then
                                Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                fileInfo.Delete()
                                TimeSpanElapsed.ElapsedPending(Watch)
                                e.Cancel = True
                                Return
                            End If
                            If Equals(Mediatek.Mediatek_tool.FlashOption.Method, "FORMAT DATA") Then
                                Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)
                                For Each Addres As mtk In partaddres
                                    If Addres.Partition_name.Contains("userdata") Then
                                        RichLogs(vbCrLf & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                        RichLogs("Data", Color.DarkOrange, True, True)
                                        RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                        RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                        RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                        RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                        Exit For
                                    End If
                                Next
                                RichLogs(vbCrLf & " Formating Format Data ... ", Color.WhiteSmoke, True, False)
                                Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "userdata", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkUsbport)
                                Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwUnlocked, e)
                                If SharedUI.BgwUnlocked.CancellationPending Then
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    TimeSpanElapsed.ElapsedPending(Watch)
                                    e.Cancel = True
                                    Return
                                Else
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    Watch.Stop()
                                    TimeSpanElapsed.ElapsedTime(Watch)
                                End If
                            ElseIf Equals(Mediatek.Mediatek_tool.FlashOption.Method, "ERASE FRP") Then
                                Dim [erase] As String
                                If Equals(Mediatek.Mediatek_list.Modellist.Brand, "SAMSUNG") Then
                                    [erase] = "persistent"
                                Else
                                    [erase] = "frp"
                                End If
                                Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)
                                For Each Addres As mtk In partaddres
                                    If Addres.Partition_name.Contains([erase]) Then
                                        RichLogs(vbCrLf & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                        RichLogs("FRP", Color.DarkOrange, True, True)
                                        RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                        RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                        RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                        RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                        Exit For
                                    End If
                                Next
                                RichLogs(vbCrLf & " Formating FRP Protection ... ", Color.WhiteSmoke, True, False)
                                Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, [erase], Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkUsbport)
                                Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwUnlocked, e)
                                If SharedUI.BgwUnlocked.CancellationPending Then
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    TimeSpanElapsed.ElapsedPending(Watch)
                                    e.Cancel = True
                                    Return
                                Else
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    Watch.Stop()
                                    TimeSpanElapsed.ElapsedTime(Watch)
                                End If
                            ElseIf Equals(Mediatek.Mediatek_tool.FlashOption.Method, "ERASE MICLOUD") Then
                                Dim partaddres As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)
                                For Each Addres As mtk In partaddres
                                    If Addres.Partition_name.Contains("persist") Then
                                        RichLogs(vbCrLf & " Formated" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                        RichLogs("MI Account", Color.DarkOrange, True, True)
                                        RichLogs(" Addres [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                        RichLogs(Addres.Linear_start_addr, Color.DarkOrange, True, True)
                                        RichLogs(" Length [hex]" & vbTab & ":  ", Color.WhiteSmoke, True, False)
                                        RichLogs(Addres.Partition_size, Color.DarkOrange, True, True)
                                        Exit For
                                    End If
                                Next
                                RichLogs(vbCrLf & " Formating MI Account ... ", Color.WhiteSmoke, True, False)
                                Mediatek.Mediatek_tool.FlashOption.FirmwareXML = Addressformat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, "persist", Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkUsbport)
                                Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwUnlocked, e)
                                If SharedUI.BgwUnlocked.CancellationPending Then
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    TimeSpanElapsed.ElapsedPending(Watch)
                                    e.Cancel = True
                                    Return
                                Else
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    Watch.Stop()
                                    TimeSpanElapsed.ElapsedTime(Watch)
                                End If
                            End If
                        ElseIf Mediatek.Mediatek_tool.Flashcommand.Writememory Then
                            If Equals(Mediatek.Mediatek_tool.FlashOption.Method, "SAFE FORMAT MISC") Then
                                Dim mtklist As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)
                                Mediatek.Mediatek_tool.FlashOption.FirmwareXML = SaveFormat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkUsbport, "misc", Path.Combine(Windows.Forms.Application.StartupPath) & "/Tools/process/Lib/site-packages/usb/backend/vendor/cookiejar.py", mtklist)
                                Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwUnlocked, e)
                                If SharedUI.BgwUnlocked.CancellationPending Then
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    TimeSpanElapsed.ElapsedPending(Watch)
                                    e.Cancel = True
                                    Return
                                Else
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    Watch.Stop()
                                    TimeSpanElapsed.ElapsedTime(Watch)
                                End If
                            ElseIf Equals(Mediatek.Mediatek_tool.FlashOption.Method, "SAFE FORMAT MISC II") Then
                                Dim mtklist As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)
                                Mediatek.Mediatek_tool.FlashOption.FirmwareXML = SaveFormat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkUsbport, "misc", Path.Combine(Windows.Forms.Application.StartupPath) & "/Tools/process/Lib/site-packages/usb/backend/vendor/cookiekes.py", mtklist)
                                Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwUnlocked, e)
                                If SharedUI.BgwUnlocked.CancellationPending Then
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    TimeSpanElapsed.ElapsedPending(Watch)
                                    e.Cancel = True
                                    Return
                                Else
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    Watch.Stop()
                                    TimeSpanElapsed.ElapsedTime(Watch)
                                End If
                            ElseIf Equals(Mediatek.Mediatek_tool.FlashOption.Method, "SAFE FORMAT PARA") Then
                                Dim mtklist As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)
                                Mediatek.Mediatek_tool.FlashOption.FirmwareXML = SaveFormat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkUsbport, "para", Path.Combine(Windows.Forms.Application.StartupPath) & "/Tools/process/Lib/site-packages/usb/backend/vendor/cookiejar.py", mtklist)
                                Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwUnlocked, e)
                                If SharedUI.BgwUnlocked.CancellationPending Then
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    TimeSpanElapsed.ElapsedPending(Watch)
                                    e.Cancel = True
                                    Return
                                Else
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    Watch.Stop()
                                    TimeSpanElapsed.ElapsedTime(Watch)
                                End If
                            ElseIf Equals(Mediatek.Mediatek_tool.FlashOption.Method, "SAFE FORMAT PARA II") Then
                                Dim mtklist As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)
                                Mediatek.Mediatek_tool.FlashOption.FirmwareXML = SaveFormat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkUsbport, "para", Path.Combine(Windows.Forms.Application.StartupPath) & "/Tools/process/Lib/site-packages/usb/backend/vendor/cookiekes.py", mtklist)
                                Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwUnlocked, e)
                                If SharedUI.BgwUnlocked.CancellationPending Then
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    TimeSpanElapsed.ElapsedPending(Watch)
                                    e.Cancel = True
                                    Return
                                Else
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    Watch.Stop()
                                    TimeSpanElapsed.ElapsedTime(Watch)
                                End If
                            ElseIf Equals(Mediatek.Mediatek_tool.FlashOption.Method, "VIVO FORMAT SAFE GALERY") Then
                                Dim mtklist As List(Of mtk) = ScatterTable(Mediatek.Mediatek_tool.Mediatek.Scatterfile)
                                Mediatek.Mediatek_tool.FlashOption.FirmwareXML = SaveFormat(Mediatek.Mediatek_tool.Mediatek.Scatterfile, Mediatek.Mediatek_tool.Mediatek.DA, Mediatek.Mediatek_tool.Mediatek.Auth, Mediatek.Mediatek_tool.Mediatek.Preloader, Mediatek.Mediatek_tool.Mediatek.Connection, Mediatek.Mediatek_list.Listport.MtkUsbport, "para", Path.Combine(Windows.Forms.Application.StartupPath) & "/Tools/process/Lib/site-packages/usb/backend/vendor/resetsettings.py", mtklist)
                                Mediatek.Mediatek_tool.Flash_Tool.Command(String.Format(" -b -i ""{0}", Mediatek.Mediatek_tool.FlashOption.FirmwareXML), SharedUI.BgwUnlocked, e)
                                If SharedUI.BgwUnlocked.CancellationPending Then
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    TimeSpanElapsed.ElapsedPending(Watch)
                                    e.Cancel = True
                                    Return
                                Else
                                    Dim fileInfo As FileInfo = New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)
                                    fileInfo.Delete()
                                    Watch.Stop()
                                    TimeSpanElapsed.ElapsedTime(Watch)
                                End If
                            End If
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
                If SharedUI.BgwUnlocked.CancellationPending Then
                    TimeSpanElapsed.ElapsedPending(Watch)
                    Mediatek.Mediatek_tool.MediatekInt.PathEditor = 0
                    e.Cancel = True
                    Return
                End If
            Next
        End If
    End Sub


    Public Shared Sub BgwUnlocked_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwUnlocked.RunWorkerCompleted
        Mediatek.Mediatek_tool.FlashOption.Method = String.Empty
        Mediatek.Mediatek_tool.Flashcommand.Config(Mediatek.Mediatek_tool.Flashcommand.Formatdisable)
        Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop_30
        Main.SharedUI.Progressbar1.EditValue = 100
        Main.SharedUI.Progressbar2.EditValue = 100
    End Sub

    Private Sub ButtonFormatSave_Click(sender As Object, e As EventArgs) 'Handles ButtonFormatSave.Click
        If Not BgwUnlocked.IsBusy Then
            Mediatek.Mediatek_tool.MediatekInt.PathEditor = 20
            RichLogs(" Searchcing port : ", Color.GhostWhite, False, False)
            BgwUnlocked.RunWorkerAsync()
        End If
    End Sub


    Private Sub ListBoxview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxview.SelectedIndexChanged
        CheckListBrand(Mediatek.Mediatek_list.Modellist.Brand)

        If Mediatek.Mediatek_tool.MediatekInt.MediatekMethod Then

            For Each item As Object In ListBoxview.SelectedItems
                Dim list As Mediatek.Mediatek_list.ListDevice.Info = TryCast(item, Mediatek.Mediatek_list.ListDevice.Info)
                Mediatek.Mediatek_list.ListDevice.DevicesName = list.Devices
                Mediatek.Mediatek_list.ListDevice.ModelName = list.Models
                Mediatek.Mediatek_list.ListDevice.Platform = list.Platform

                If list.[New] = "NEW" Then
                    Console.WriteLine("Selected : " & list.Devices & " " & list.Models & " " & list.Platform & " New Method")
                Else
                    Console.WriteLine("Selected : " & list.Devices & " " & list.Models & " " & list.Platform & " Old Method")
                End If

                Extrax_Dowork(Mediatek.Mediatek_list.ListPath.SUPPORT + Mediatek.Mediatek_list.Modellist.Brand, Mediatek.Mediatek_tool.Extraxpath.Temp)
            Next
        End If
    End Sub

    Public Sub Extrax_Dowork(text As String, path As String)
        Try

            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont)) Then
                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont))
            End If

            If File.Exists(IO.Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont) & Mediatek.Mediatek_tool.Extraxpath.Scatter) Or File.Exists(IO.Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont) & Mediatek.Mediatek_tool.Extraxpath.Preloader) Then
                Dim directoryInfo As DirectoryInfo = New DirectoryInfo(IO.Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont))

                For Each fileInfo As FileInfo In directoryInfo.EnumerateFiles()
                    fileInfo.Delete()
                Next
            End If

            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(path)) Then
                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(path))
                Dim DirectoryInfo As New DirectoryInfo(IO.Path.GetDirectoryName(path)) With {
                        .Attributes = FileAttributes.Hidden Or FileAttributes.System
                    }
            End If

            Dim directory As DirectoryInfo = New DirectoryInfo(text)

            For Each file As FileInfo In directory.EnumerateFiles()

                If file.Name.Contains(Mediatek.Mediatek_list.ListDevice.DevicesName & " " + Mediatek.Mediatek_list.ListDevice.ModelName) Then
                    Dim sevenZipPath As String = IO.Path.Combine(IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), If(Environment.Is64BitProcess, "x64", "x86"), "7z.dll")
                    SevenZipBase.SetLibraryPath(sevenZipPath)
                    Dim sevenZipExtractor As SevenZipExtractor = New SevenZipExtractor(file.FullName, "collabs0#0#")
                    sevenZipExtractor.ExtractArchive(IO.Path.GetDirectoryName(path))
                    Dim DirInfo As DirectoryInfo = New DirectoryInfo(IO.Path.GetDirectoryName(path))

                    For Each INfo As FileInfo In DirInfo.EnumerateFiles()

                        If INfo.Name.Contains("scatter") Then
                            IO.File.Move(INfo.FullName, IO.Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont) & Mediatek.Mediatek_tool.Extraxpath.Scatter)
                            Mediatek.Mediatek_tool.Mediatek.Scatterfile = IO.Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont) & Mediatek.Mediatek_tool.Extraxpath.Scatter
                        End If

                        If INfo.Name.Contains("preloader") Then
                            Mediatek.Mediatek_tool.Extraxpath.Preloaderback = INfo.Name
                            IO.File.Move(INfo.FullName, IO.Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont) & Mediatek.Mediatek_tool.Extraxpath.Preloader)
                            Mediatek.Mediatek_tool.Mediatek.Preloader = IO.Path.GetDirectoryName(Mediatek.Mediatek_tool.Extraxpath.FolderFont) & Mediatek.Mediatek_tool.Extraxpath.Preloader
                        End If
                    Next

                    For Each Info As FileInfo In DirInfo.EnumerateFiles()
                        Info.Delete()
                    Next

                    DirInfo.Delete()
                End If
            Next

        Catch
        End Try
    End Sub

    Private Sub Text_IMEI1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_IMEI1.KeyPress
        If e.KeyChar <> vbBack AndAlso Not Char.IsNumber(e.KeyChar) Then
            MessageBox.Show(" Invalid Input ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            e.Handled = True
        End If
    End Sub

    Private Sub Text_IMEI2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_IMEI2.KeyPress
        If e.KeyChar <> vbBack AndAlso Not Char.IsNumber(e.KeyChar) Then
            MessageBox.Show(" Invalid Input ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            e.Handled = True
        End If
    End Sub

    Private Sub Text_IMEI1_EditValueChanged(sender As Object, e As EventArgs) Handles Text_IMEI1.EditValueChanged
        Try
            Text_IMEI1.Properties.MaxLength = 14
            Dim text As String = Text_IMEI1.Text.ToUpper()
            Dim num3 = 0
            Dim num4 = text.Length
            Dim i = num4

            While i >= 1
                Dim num5 = Asc(Mid(text, i, 1)) - 48
                num3 = CType(Math.Round(num3 + 2 * num5 - Int(num5 / 5.0) * 9.0), Integer)
                If i > 1 Then
                    num5 = Asc(Mid(text, i - 1, 1)) - 48
                    num3 += num5
                End If

                i += -2
            End While
            num3 += 10
            ValidIMEI1.Text = ((10 - num3 Mod 10) Mod 10).ToString()
            CheckIMEI1.Checked = True
            If Equals(Text_IMEI1.Text, "") Then
                CheckIMEI1.Checked = False
                ValidIMEI1.Text = "0"
            End If

        Catch
        End Try
    End Sub

    Private Sub Text_IMEI2_EditValueChanged(sender As Object, e As EventArgs) Handles Text_IMEI2.EditValueChanged
        Try
            Text_IMEI2.Properties.MaxLength = 14
            Dim text As String = Text_IMEI2.Text.ToUpper()
            Dim num3 = 0
            Dim num4 = text.Length
            Dim i = num4

            While i >= 1
                Dim num5 = Asc(Mid(text, i, 1)) - 48
                num3 = CType(Math.Round(num3 + 2 * num5 - Int(num5 / 5.0) * 9.0), Integer)
                If i > 1 Then
                    num5 = Asc(Mid(text, i - 1, 1)) - 48
                    num3 += num5
                End If

                i += -2
            End While
            num3 += 10
            ValidIMEI2.Text = ((10 - num3 Mod 10) Mod 10).ToString()
            CheckIMEI2.Checked = True
            If Equals(Text_IMEI2.Text, "") Then
                CheckIMEI2.Checked = False
                ValidIMEI2.Text = "0"
            End If

        Catch
        End Try
    End Sub


End Class
