Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports DevExpress.XtraEditors
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json.Linq
Imports Reverse_Tool.Bismillah.FIREHOSE.FIREHOSE_MANAGER

Public Class QcFlash

    Friend Shared SharedUI As QcFlash

    Public Sub New()
        server = "http://localhost/iReverseWebsite/datatool/"
        InitializeComponent()
        SharedUI = Me
        Watch = New Stopwatch()
        AddHandler Load, AddressOf LoadMenu
        AddHandler DataView.MouseWheel, AddressOf DataView_Mousewheel
        AddHandler DataView.RowPrePaint, AddressOf DataView_RowPrePaint
    End Sub

    Shared Sub New()
        ReDim loader(-1)
        ReDim OutDecripted(-1)
        PortQcom = 0
        sendingloaderStatus = False
        TypeMemory = "emmc"
        SectorSize = "512"
        MenuEx = New MenuEksekusi()
        PatchString = ""
        LoadFolderXml = ""
    End Sub

    Public Sub LoadMenu(sender As Object, e As EventArgs)
        MenuEx = MenuEksekusi.manual
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

    Private Sub MainTab_MouseClick(sender As Object, e As MouseEventArgs) Handles MainTab.MouseClick
        Dim WorkerMethod As String
        If MainTab.SelectedTabPage.Name = MainTab.TabPages(0).Name Then
            WorkerMethod = "FLASH"
        End If

        If MainTab.SelectedTabPage.Name = MainTab.TabPages(1).Name Then
            WorkerMethod = "UNIFERSAL"
        End If
    End Sub
    Private Sub VScrollBarQcFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBarQcFlashDataView.Scroll
        If DataView.Rows.Count > 0 Then
            VScrollBarQcFlashDataView.LargeChange = DataView.Rows.Count
            VScrollBarQcFlashDataView.Maximum = DataView.Rows.Count - 1 + VScrollBarQcFlashDataView.LargeChange - 1
            DataView.FirstDisplayedScrollingRowIndex = e.NewValue
        End If
    End Sub

    Private Sub HScrollBarQcFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBarQcFlashDataView.Scroll
        DataView.FirstDisplayedScrollingColumnIndex = e.NewValue
    End Sub
    Private Sub DataView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataView.CellDoubleClick
        If e.ColumnIndex = 3 Then
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog With {
                            .Title = String.Format("Choice {0}  file !", DataView.CurrentRow.Cells(4).Value),
                            .Filter = String.Format("{0}  |*.*|Other|*.*", DataView.CurrentRow.Cells(4).Value)
                            }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                DataView.CurrentRow.Cells(7).Value = openFileDialog.FileName
                DataView.CurrentRow.Cells(0).Value = True
            End If

        End If
    End Sub

    Public Sub Loadsss(xml As String)
        LoadXmlFolder(xml)
    End Sub
    Private Sub LoadXmlFolder(xml As String)
        Dim enumerator As IEnumerator = Nothing
        DataView.Rows.Clear()
        Dim strArrays As String() = xml.Split(New Char() {","c})
        Dim str As String = ""
        Dim length As Integer = strArrays.Length - 1
        For i As Integer = 0 To length Step 1
            str = strArrays(i)
            If Operators.CompareString(str, "", False) = 0 Then
                Exit For
            End If
            Dim attribute As String = ""
            Dim text As String = ""
            Dim xmlReader As XmlReader = XmlReader.Create(String.Concat(LoadFolderXml, "\", str))
            While True
                If xmlReader.Read() Then
                    If If(xmlReader.NodeType <> XmlNodeType.Element, False, Operators.CompareString(xmlReader.Name, "program", False) = 0) Then
                        If Operators.CompareString(xmlReader.GetAttribute("filename"), "", False) <> 0 Then
                            text = String.Concat(LoadFolderXml, "\", xmlReader.GetAttribute("filename"))
                        Else
                            text = "none"
                        End If
                        attribute = xmlReader.GetAttribute("SECTOR_SIZE_IN_BYTES")

                        DataView.Rows.Add(False,
                            xmlReader.GetAttribute("physical_partition_number"), 'LUNs
                            xmlReader.GetAttribute("SECTOR_SIZE_IN_BYTES"), 'Blocks
                            "double click ...", ' Browse Files
                            xmlReader.GetAttribute("label"), 'Partitions
                            xmlReader.GetAttribute("start_sector"), 'Start Sectors
                            xmlReader.GetAttribute("num_partition_sectors"), 'End Sectors
                            text) 'Locations

                    End If
                    If If(xmlReader.NodeType <> XmlNodeType.Element, False, Operators.CompareString(xmlReader.Name.ToLower(), "patch", False) = 0) Then
                        PatchString = String.Concat(PatchString, str, ",")
                        Console.WriteLine(PatchString)
                        Exit While
                    End If
                Else
                    Exit While
                End If
            End While

            For Each itm As DataGridViewRow In DataView.Rows
                If itm.Cells(7).Value = "none" Then
                    itm.Cells(0).Value = False
                Else
                    itm.Cells(0).Value = True
                End If
            Next
            If attribute.Contains("512") Then
                ComboChipQc.SelectedIndex = 0
                TypeMemory = "emmc"
                SectorSize = "512"
            ElseIf attribute.Contains("4096") Then
                ComboChipQc.SelectedIndex = 1
                TypeMemory = "ufs"
                SectorSize = "4096"
            End If
        Next
    End Sub

    Private Sub ButtonLoader_Click(sender As Object, e As EventArgs) Handles ButtonLoader.Click
        TxtFlashLoader.Text = ""
        ReDim loader(-1)
        ReDim OutDecripted(-1)
        datafile = ""
        Dim openFileDialog As New OpenFileDialog() With
                            {
                            .Title = "loader",
                            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                            .FileName = "*.*",
                            .Filter = "all file |*.*;*.* ",
                            .FilterIndex = 2,
                            .RestoreDirectory = True
                            }
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            TxtFlashLoader.Text = openFileDialog.FileName
            Dim fileInfo As New FileInfo(openFileDialog.FileName)
        End If
    End Sub

    Public Sub Btn_RawXML_Click(sender As Object, e As EventArgs) Handles Btn_BrowseXML.Click
        TxtFlashRawXML.Text = ""
        TxtFlashRawXML.Enabled = False

        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If folderDlg.ShowDialog() = DialogResult.OK Then
            LoadFolderXml = folderDlg.SelectedPath
            My.Forms.loadxml.Show()
            TxtFlashRawXML.Text = LoadFolderXml

        End If

    End Sub

    Private Sub ComboChipQc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboChipQc.SelectedIndexChanged
        If ComboChipQc.SelectedIndex = 0 Then
            TypeMemory = "emmc"
            SectorSize = "512"
        ElseIf ComboChipQc.SelectedIndex = 1 Then
            TypeMemory = "ufs"
            SectorSize = "4096"
        End If
        Console.WriteLine("Selected : " & TypeMemory & " " & SectorSize)
    End Sub
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

    Public Sub ButtonFlashQc_Click(sender As Object, e As EventArgs) Handles ButtonFlashQc.Click
        Dim flag As Boolean

        For Each item As DataGridViewRow In DataView.Rows
            If CacheBoxAutoFormatData.Checked Then
                If item.Cells(DataView.Columns(4).Index).Value = "misc" Then
                    If SectorSize = "512" Then
                        item.Cells(DataView.Columns(7).Index).Value = Windows.Forms.Application.StartupPath & "\Tools\Reset\misc_emmc.img"
                    Else
                        item.Cells(DataView.Columns(7).Index).Value = Windows.Forms.Application.StartupPath & "\Tools\Reset\misc_ufs.img"
                    End If
                    item.Cells(DataView.Columns(0).Index).Value = True
                End If
                If item.Cells(DataView.Columns(4).Index).Value = "frp" Then
                    item.Cells(DataView.Columns(7).Index).Value = Windows.Forms.Application.StartupPath & "\Tools\Reset\frp.bin"
                    item.Cells(DataView.Columns(0).Index).Value = True
                ElseIf item.Cells(DataView.Columns(4).Index).Value = "config" Then
                    item.Cells(DataView.Columns(7).Index).Value = Windows.Forms.Application.StartupPath & "\Tools\Reset\config.bin"
                    item.Cells(DataView.Columns(0).Index).Value = True
                End If
            End If
            If item.Cells(0).Value = True Then
                flag = True
            End If
        Next

        If flag Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "Flashing"
            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If

            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            totalchecked = 0
            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(0).Index).Value = True Then
                    totalchecked += 1

                    StringXml = String.Concat(StringXml, String.Format("<program SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0"" filename=""{1}"" label=""{2}"" num_partition_sectors=""{3}"" physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {
                            SectorSize, '512, 4096
                            item.Cells(DataView.Columns(7).Index).Value.ToString(), 'filenames = Locations
                            item.Cells(DataView.Columns(4).Index).Value.ToString(), 'label = Partitions
                            item.Cells(DataView.Columns(6).Index).Value.ToString(),  'num_partition_sectors = End Sectors
                            item.Cells(DataView.Columns(1).Index).Value.ToString(),   'physical_partition_number = Luns
                            item.Cells(DataView.Columns(5).Index).Value.ToString()    'start_sector = Start Sector
                            }),
                            "" & vbCrLf & "")

                End If
            Next

            StringXml = String.Concat(StringXml, "</data>")

        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub


    Private Sub SimpleButtonReboot_Click(sender As Object, e As EventArgs) Handles SimpleButtonReboot.Click
        MenuEx = MenuEksekusi.manual
        MenuManual = "Reboot"

        Thread.Sleep(500)
        If Not CheckBoxServer.Checked Then
            If TxtFlashLoader.Text = "" Then
                Main.IsAutoLoader = True
            Else
                Main.IsAutoLoader = False
            End If
        End If

        If Not CariportQC.IsBusy Then
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            Watch.Restart()
            RtbClear()
            Setwaktu()
            Watch.Start()
            StringXml = ""
            CariportQC.RunWorkerAsync()
            CariportQC.Dispose()
        Else
            RichLogs("", Color.Yellow, True, True)
            RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
        End If

    End Sub


    Private Sub ButtonQc_ReadP_Click(sender As Object, e As EventArgs) Handles ButtonQc_ReadP.Click
        Dim flag As Boolean

        For Each item As DataGridViewRow In DataView.Rows
            If item.Cells(0).Value = True Then
                flag = True
            End If
        Next

        If flag Then
            Dim folderBrowserDialog As New FolderBrowserDialog() With
                            {
                            .ShowNewFolderButton = True
                            }

            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                foldersave = folderBrowserDialog.SelectedPath
                MenuEx = MenuEksekusi.manual
                MenuManual = "Read"

                Thread.Sleep(500)
                If Not CheckBoxServer.Checked Then
                    If TxtFlashLoader.Text = "" Then
                        Main.IsAutoLoader = True
                    Else
                        Main.IsAutoLoader = False
                    End If
                End If

                If Not CariportQC.IsBusy Then
                    Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                    Watch.Restart()
                    RtbClear()
                    Setwaktu()
                    Watch.Start()
                    StringXml = ""
                    CariportQC.RunWorkerAsync()
                    CariportQC.Dispose()
                Else
                    RichLogs("", Color.Yellow, True, True)
                    RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
                End If

                StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
                StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


                totalchecked = 0
                For Each item As DataGridViewRow In DataView.Rows
                    If item.Cells(DataView.Columns(0).Index).Value = True Then
                        totalchecked += 1

                        StringXml = String.Concat(StringXml, String.Format("<read SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0"" filename=""{1}"" label=""{2}"" num_partition_sectors=""{3}"" physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {
                            SectorSize, '512, 4096
                            item.Cells(DataView.Columns(7).Index).Value.ToString(), 'filenames = Locations
                            item.Cells(DataView.Columns(4).Index).Value.ToString(), 'label = Partitions
                            item.Cells(DataView.Columns(6).Index).Value.ToString(),  'num_partition_sectors = End Sectors
                            item.Cells(DataView.Columns(1).Index).Value.ToString(),   'physical_partition_number = Luns
                            item.Cells(DataView.Columns(5).Index).Value.ToString()    'start_sector = Start Sector
                            }),
                            "" & vbCrLf & "")

                    End If
                Next

                StringXml = String.Concat(StringXml, "</data>")

            End If
        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub ButtonQc_eP_Click(sender As Object, e As EventArgs) Handles ButtonQc_eP.Click
        Dim flag As Boolean

        For Each item As DataGridViewRow In DataView.Rows
            If item.Cells(0).Value = True Then
                flag = True
            End If
        Next

        If flag Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "Erase"

            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If

            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            totalchecked = 0
            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(0).Index).Value = True Then
                    totalchecked += 1

                    StringXml = String.Concat(StringXml, String.Format("<program SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0"" filename=""{1}"" label=""{2}"" num_partition_sectors=""{3}"" physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {
                            SectorSize, '512, 4096
                            item.Cells(DataView.Columns(7).Index).Value.ToString(), 'filenames = Locations
                            item.Cells(DataView.Columns(4).Index).Value.ToString(), 'label = Partitions
                            item.Cells(DataView.Columns(6).Index).Value.ToString(),  'num_partition_sectors = End Sectors
                            item.Cells(DataView.Columns(1).Index).Value.ToString(),   'physical_partition_number = Luns
                            item.Cells(DataView.Columns(5).Index).Value.ToString()    'start_sector = Start Sector
                            }),
                            "" & vbCrLf & "")

                End If
            Next

            StringXml = String.Concat(StringXml, "</data>")

        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub ButtonQc_Idnt_Click(sender As Object, e As EventArgs) Handles ButtonQc_Idnt.Click
        MenuEx = MenuEksekusi.manual
        MenuManual = "Read GPT"
        Thread.Sleep(500)
        If Not CheckBoxServer.Checked Then
            If TxtFlashLoader.Text = "" Then
                Main.IsAutoLoader = True
            Else
                Main.IsAutoLoader = False
            End If
        End If

        If Not CariportQC.IsBusy Then
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            DataView.Rows.Clear()
            Watch.Restart()
            RtbClear()
            Setwaktu()
            Watch.Start()
            StringXml = ""
            CariportQC.RunWorkerAsync()
            CariportQC.Dispose()
        Else
            RichLogs("", Color.Yellow, True, True)
            RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
        End If
    End Sub


    Private Sub CheckBoxServer_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxServer.CheckedChanged

        If Not CheckBoxServer.Checked Then
            ButtonLoader.Enabled = True
            TxtFlashLoader.Enabled = True
            ComboBoxEditBrand.Properties.Items.Clear()
            ComboBoxEditBrand.Text = ""
            ComboBoxEditModels.Text = ""
            ComboBoxEditModels.Properties.Items.Clear()
        Else
            Try
                Dim str As String = String.Concat("username=" & Main.username, "&password=" & Main.password)
                Dim webRequest As WebRequest = WebRequest.Create(String.Concat(server, "/merks.php"))
                webRequest.Method = "POST"
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(str)
                webRequest.ContentType = "application/x-www-form-urlencoded"
                webRequest.Timeout = 10000
                Dim requestStream As Stream = webRequest.GetRequestStream()
                requestStream.Write(bytes, 0, bytes.Length)
                requestStream.Close()
                requestStream = webRequest.GetResponse().GetResponseStream()
                Dim streamReader As New StreamReader(requestStream)
                Dim response As HttpWebResponse = DirectCast(webRequest.GetResponse(), HttpWebResponse)
                If response.StatusCode = HttpStatusCode.OK Then
                    Dim jObjects As JObject = JObject.Parse(streamReader.ReadToEnd())
                    If CBool(jObjects.SelectToken("GetStatus.StatusLogin")) Then

                        URL = CStr(jObjects.SelectToken("GetStatus.URL"))


                        keyEncrypt = CStr(jObjects.SelectToken("GetStatus.key"))

                        Dim str1 As String = CStr(jObjects.SelectToken("GetStatus.MerkHp"))
                        Dim strArrays As String() = str1.Split(New Char() {","c})
                        Dim length As Integer = strArrays.Length - 1
                        Dim numcombo As Integer = 0
                        Do
                            ComboBoxEditBrand.Properties.Items.Add(strArrays(numcombo))
                            numcombo += 1
                        Loop While numcombo <= length
                        ComboBoxEditBrand.Text = strArrays(0)
                        Dim num As Integer = 2
                        Dim text As String = CStr(jObjects.SelectToken("GetStatus.MerkHp"))
                        Dim array As String() = text.Split(New Char() {","c})
                        Dim num2 As Integer = array.Length - 1
                    End If
                Else
                    MsgBox(String.Concat("server error ", Conversions.ToString(response.StatusCode)), MsgBoxStyle.OkOnly, Nothing)
                End If
            Catch exception As Exception
                ProjectData.SetProjectError(exception)
                MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
                ProjectData.ClearProjectError()
            End Try

        End If
    End Sub

    Private Sub ComboBoxEditBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEditBrand.SelectedIndexChanged
        Dim Flag As Boolean = True
        ComboBoxEditModels.Properties.Items.Clear()
        ComboBoxEditModels.Text = ""

        If ComboBoxEditBrand.Text = "HUAWEI" Then
            XtraMessageBox.Show("Saat Ini Untuk HUAWEI Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Flag = False
        ElseIf ComboBoxEditBrand.Text = "INFINIX" Then
            XtraMessageBox.Show("Saat Ini Untuk INFINIX Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Flag = False
        ElseIf ComboBoxEditBrand.Text = "LENOVO" Then
            XtraMessageBox.Show("Saat Ini Untuk LENOVO Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Flag = False
        ElseIf ComboBoxEditBrand.Text = "MEIZU" Then
            XtraMessageBox.Show("Saat Ini Untuk MEIZU Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Flag = False
        ElseIf ComboBoxEditBrand.Text = "NOKIA" Then
            XtraMessageBox.Show("Saat Ini Untuk NOKIA Qualcomm Belum Tersedia!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Flag = False
        End If
        If Flag Then
            Try

                MerkTerpilih = ComboBoxEditBrand.Text

                ButtonLoader.Enabled = False
                TxtFlashLoader.Enabled = False
                TxtFlashLoader.Text = ""
                Dim webRequest As WebRequest = WebRequest.Create(String.Concat(server, ComboBoxEditBrand.Text.ToUpper(), ".txt"))
                webRequest.Method = "POST"
                webRequest.ContentType = "application/x-www-form-urlencoded"
                webRequest.Timeout = 10000
                webRequest.GetRequestStream().Close()
                Dim streamReader As New StreamReader(webRequest.GetResponse().GetResponseStream())
                Dim str As String = ""
                Dim response As HttpWebResponse = DirectCast(webRequest.GetResponse(), HttpWebResponse)
                If response.StatusCode = HttpStatusCode.OK Then
                    gettypehpnya = New Windows.Forms.ComboBox()
                    Dim strArrays(-1) As String
                    While Not streamReader.EndOfStream
                        str = streamReader.ReadLine()
                        gettypehpnya.Items.Add(str)
                        Dim str1 As String = ""
                        strArrays = str.Split(New Char() {","c})
                        str1 = strArrays(0)
                        ComboBoxEditModels.Properties.Items.Add(str1)
                        ComboBoxEditModels.Properties.Tag = strArrays(1)
                    End While
                    ComboBoxEditModels.Text = strArrays(0)
                Else
                    MsgBox(String.Concat("server error ", Conversions.ToString(response.StatusCode)), MsgBoxStyle.OkOnly, Nothing)
                End If
            Catch exception As Exception
                ProjectData.SetProjectError(exception)
                MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
                ProjectData.ClearProjectError()
            End Try
        End If
    End Sub
    Private Sub ComboBoxEditModels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEditModels.SelectedIndexChanged
        ReDim loader(-1)

        ReDim OutDecripted(-1)


        datafile = ""

        Dim text As String = ComboBoxEditModels.Text
        Dim count As Integer = gettypehpnya.Items.Count - 1
        For i As Integer = 0 To count Step 1
            Dim objectValue As Object = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(gettypehpnya.Items(i), Nothing, "Split", New Object() {","}, Nothing, Nothing, Nothing))
            If Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(objectValue, New Object() {0}, Nothing), text, False) Then

                MerkTerpilih = ComboBoxEditBrand.Text.ToUpper()


                TypeTerpilih = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, New Object() {1}, Nothing))


                datafile = "loader.bin"

            End If
        Next
    End Sub

    Private Sub BtnGPTread_Click(sender As Object, e As EventArgs) Handles BtnGPTread.Click
        ButtonQc_Idnt_Click(sender, e)
    End Sub

    Private Sub ButtonRebbot_Click(sender As Object, e As EventArgs) Handles ButtonRebbot.Click
        SimpleButtonReboot_Click(sender, e)
    End Sub

    Private Sub ButtonGptWrite_Click(sender As Object, e As EventArgs) Handles ButtonGptWrite.Click
        ButtonFlashQc_Click(sender, e)
    End Sub

    Private Sub ButtonReadGPT_Click(sender As Object, e As EventArgs) Handles ButtonReadGPT.Click
        ButtonQc_ReadP_Click(sender, e)
    End Sub

    Private Sub ButtonEraseGPT_Click(sender As Object, e As EventArgs) Handles ButtonEraseGPT.Click
        ButtonQc_eP_Click(sender, e)
    End Sub

    Private Sub CheckboxLoaderELF_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxLoaderELF.CheckedChanged
        If CheckBoxServer.Checked Then
            CheckBoxServer.Checked = False
        End If
        If CheckboxLoaderELF.Checked Then
            TxtloaderELF.Enabled = True
            ButtonELF.Enabled = True
        Else
            TxtloaderELF.Text = ""
            TxtloaderELF.Enabled = False
            ButtonELF.Enabled = False
        End If
    End Sub

    Private Sub ButtonReadInfo_Click(sender As Object, e As EventArgs) Handles ButtonReadInfo.Click
        If DataView.Rows.Count > 0 Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "Read Info"

            If Not File.Exists(Mediatek.Mediatek_tool.Sourcefile.Andoidpath) Then
                Directory.CreateDirectory(Path.GetDirectoryName(Mediatek.Mediatek_tool.Sourcefile.Andoidpath))
                File.WriteAllBytes(Mediatek.Mediatek_tool.Sourcefile.Andoidpath, My.Resources.C4)
            End If

            If File.Exists(Mediatek.Mediatek_tool.Sourcefile.Dumped) Then
                File.Delete(Mediatek.Mediatek_tool.Sourcefile.Dumped)
            End If

            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If

            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            totalchecked = 0
            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(4).Index).Value = "recovery" Then
                    totalchecked += 1

                    foldersave = Mediatek.Mediatek_tool.Sourcefile.Directorypath

                    StringXml = String.Concat(StringXml, String.Format("<read SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0"" filename=""{1}"" label=""{2}"" num_partition_sectors=""{3}"" physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {
                            SectorSize, '512, 4096
                            item.Cells(DataView.Columns(7).Index).Value.ToString(), 'filenames = Locations
                            item.Cells(DataView.Columns(4).Index).Value.ToString(), 'label = Partitions
                            item.Cells(DataView.Columns(6).Index).Value.ToString(), 'num_partition_sectors = End Sectors
                            item.Cells(DataView.Columns(1).Index).Value.ToString(), 'physical_partition_number = Luns
                            item.Cells(DataView.Columns(5).Index).Value.ToString()  'start_sector = Start Sector
                            }),
                            "" & vbCrLf & "")
                End If
            Next


            StringXml = String.Concat(StringXml, "</data>")
        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub ButtonMiReset_Click(sender As Object, e As EventArgs) Handles ButtonMiReset.Click
        If DataView.Rows.Count > 0 Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "HexOperation"

            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If

            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            totalchecked = 0
            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(4).Index).Value = "persist" Then
                    totalchecked += 1
                    foldersave = Windows.Forms.Application.StartupPath & "\Tools\process"

                    StringXml = String.Concat(StringXml, String.Format("<read SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0"" filename=""{1}"" label=""{2}"" num_partition_sectors=""{3}"" physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {
                            SectorSize, '512, 4096
                            item.Cells(DataView.Columns(7).Index).Value.ToString(), 'filenames = Locations
                            item.Cells(DataView.Columns(4).Index).Value.ToString(), 'label = Partitions
                            item.Cells(DataView.Columns(6).Index).Value.ToString(), 'num_partition_sectors = End Sectors
                            item.Cells(DataView.Columns(1).Index).Value.ToString(), 'physical_partition_number = Luns
                            item.Cells(DataView.Columns(5).Index).Value.ToString()  'start_sector = Start Sector
                            }),
                            "" & vbCrLf & "")
                End If
            Next


            StringXml = String.Concat(StringXml, "</data>")
        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

    End Sub
    Private Sub ButtonMiDisable_Click(sender As Object, e As EventArgs) Handles ButtonMiDisable.Click
        If DataView.Rows.Count > 0 Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "HexOperation"

            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If

            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            totalchecked = 0
            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(4).Index).Value = "modem" Then
                    totalchecked += 1
                    foldersave = Windows.Forms.Application.StartupPath & "\Tools\process"

                    StringXml = String.Concat(StringXml, String.Format("<read SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0"" filename=""{1}"" label=""{2}"" num_partition_sectors=""{3}"" physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {
                            SectorSize, '512, 4096
                            item.Cells(DataView.Columns(7).Index).Value.ToString(), 'filenames = Locations
                            item.Cells(DataView.Columns(4).Index).Value.ToString(), 'label = Partitions
                            item.Cells(DataView.Columns(6).Index).Value.ToString(), 'num_partition_sectors = End Sectors
                            item.Cells(DataView.Columns(1).Index).Value.ToString(), 'physical_partition_number = Luns
                            item.Cells(DataView.Columns(5).Index).Value.ToString()  'start_sector = Start Sector
                            }),
                            "" & vbCrLf & "")
                End If
            Next


            StringXml = String.Concat(StringXml, "</data>")
        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

    End Sub


    Private Sub ButtonFormatUser_Click(sender As Object, e As EventArgs) Handles ButtonFormatUser.Click
        If DataView.Rows.Count > 0 Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "Format Data"

            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If

            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            totalchecked = 0
            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(4).Index).Value = "userdata" Then
                    totalchecked += 1

                    StringXml = String.Concat(StringXml, String.Format("<program SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0"" filename=""{1}"" label=""{2}"" num_partition_sectors=""{3}"" physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {
                            SectorSize, '512, 4096
                            item.Cells(DataView.Columns(7).Index).Value.ToString(), 'filenames = Locations
                            item.Cells(DataView.Columns(4).Index).Value.ToString(), 'label = Partitions
                            item.Cells(DataView.Columns(6).Index).Value.ToString(),  'num_partition_sectors = End Sectors
                            item.Cells(DataView.Columns(1).Index).Value.ToString(),   'physical_partition_number = Luns
                            item.Cells(DataView.Columns(5).Index).Value.ToString()    'start_sector = Start Sector
                            }),
                            "" & vbCrLf & "")

                End If
            Next

            StringXml = String.Concat(StringXml, "</data>")

        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub ButtonAuth_Click(sender As Object, e As EventArgs) Handles ButtonAuth.Click
        If Not CheckBoxServer.Checked Then
            If TxtFlashLoader.Text = "" Then
                Main.IsAutoLoader = True
            Else
                Main.IsAutoLoader = False
            End If
        End If

        If Not CariportQC.IsBusy Then
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            Watch.Restart()
            RtbClear()
            Setwaktu()
            Watch.Start()
            StringXml = ""
            CariportQC.RunWorkerAsync()
            CariportQC.Dispose()
        Else
            RichLogs("", Color.Yellow, True, True)
            RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
        End If

    End Sub

    Private Sub ButtonUBL_Click(sender As Object, e As EventArgs) Handles ButtonUBL.Click
        If DataView.Rows.Count > 0 Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "UnRelock Bootloader"

            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If


            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(4).Index).Value = "devinfo" Then

                    StringXml = String.Concat(StringXml, "<patch SECTOR_SIZE_IN_BYTES=""" & SectorSize & """ byte_offset=""16"" filename=""DISK"" physical_partition_number=""0"" size_in_bytes=""1"" start_sector=""" & item.Cells(DataView.Columns(5).Index).Value.ToString() & """ value=""1""  what=""Zero.""/>" & vbCrLf & "")
                    StringXml = String.Concat(StringXml, "<patch SECTOR_SIZE_IN_BYTES=""" & SectorSize & """ byte_offset=""24"" filename=""DISK"" physical_partition_number=""0"" size_in_bytes=""1"" start_sector=""" & item.Cells(DataView.Columns(5).Index).Value.ToString() & """ value=""1""  what=""Zero.""/>" & vbCrLf & "")
                    StringXml = String.Concat(StringXml, "<patch SECTOR_SIZE_IN_BYTES=""" & SectorSize & """ byte_offset=""28"" filename=""DISK"" physical_partition_number=""0"" size_in_bytes=""1"" start_sector=""" & item.Cells(DataView.Columns(5).Index).Value.ToString() & """ value=""1""  what=""Zero.""/>" & vbCrLf & "")

                End If
            Next

            StringXml = String.Concat(StringXml, "</data>")
        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub ButtonRelockUBL_Click(sender As Object, e As EventArgs) Handles ButtonRelockUBL.Click
        If DataView.Rows.Count > 0 Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "UnRelock Bootloader"

            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If


            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(4).Index).Value = "devinfo" Then

                    StringXml = String.Concat(StringXml, "<patch SECTOR_SIZE_IN_BYTES=""" & SectorSize & """ byte_offset=""16"" filename=""DISK"" physical_partition_number=""0"" size_in_bytes=""1"" start_sector=""" & item.Cells(DataView.Columns(5).Index).Value.ToString() & """ value=""0""  what=""Zero.""/>" & vbCrLf & "")
                    StringXml = String.Concat(StringXml, "<patch SECTOR_SIZE_IN_BYTES=""" & SectorSize & """ byte_offset=""24"" filename=""DISK"" physical_partition_number=""0"" size_in_bytes=""1"" start_sector=""" & item.Cells(DataView.Columns(5).Index).Value.ToString() & """ value=""0""  what=""Zero.""/>" & vbCrLf & "")
                    StringXml = String.Concat(StringXml, "<patch SECTOR_SIZE_IN_BYTES=""" & SectorSize & """ byte_offset=""28"" filename=""DISK"" physical_partition_number=""0"" size_in_bytes=""1"" start_sector=""" & item.Cells(DataView.Columns(5).Index).Value.ToString() & """ value=""0""  what=""Zero.""/>" & vbCrLf & "")

                End If
            Next

            StringXml = String.Concat(StringXml, "</data>")
        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnSAM_FRP_Oem_Click(sender As Object, e As EventArgs) Handles BtnSAM_FRP_Oem.Click
    End Sub

    Private Sub ButtonAllFRP_Click(sender As Object, e As EventArgs) Handles ButtonAllFRP.Click
        If DataView.Rows.Count > 0 Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "Erase"

            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If

            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            totalchecked = 0
            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(4).Index).Value = "frp" Then
                    totalchecked += 1

                    StringXml = String.Concat(StringXml, String.Format("<program SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0"" filename=""{1}"" label=""{2}"" num_partition_sectors=""{3}"" physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {
                            SectorSize, '512, 4096
                            item.Cells(DataView.Columns(7).Index).Value.ToString(), 'filenames = Locations
                            item.Cells(DataView.Columns(4).Index).Value.ToString(), 'label = Partitions
                            item.Cells(DataView.Columns(6).Index).Value.ToString(),  'num_partition_sectors = End Sectors
                            item.Cells(DataView.Columns(1).Index).Value.ToString(),   'physical_partition_number = Luns
                            item.Cells(DataView.Columns(5).Index).Value.ToString()    'start_sector = Start Sector
                            }),
                            "" & vbCrLf & "")
                Else
                    XtraMessageBox.Show("Tidak ada data FRP!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return
                End If
            Next

            StringXml = String.Concat(StringXml, "</data>")

        Else
            XtraMessageBox.Show("Tidak ada list data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub ButtonFRP_SAM_Click(sender As Object, e As EventArgs) Handles ButtonFRP_SAM.Click

        If DataView.Rows.Count > 0 Then
            MenuEx = MenuEksekusi.manual
            MenuManual = "Erase"

            Thread.Sleep(500)
            If Not CheckBoxServer.Checked Then
                If TxtFlashLoader.Text = "" Then
                    Main.IsAutoLoader = True
                Else
                    Main.IsAutoLoader = False
                End If
            End If

            If Not CariportQC.IsBusy Then
                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Watch.Restart()
                RtbClear()
                Setwaktu()
                Watch.Start()
                StringXml = ""
                CariportQC.RunWorkerAsync()
                CariportQC.Dispose()
            Else
                RichLogs("", Color.Yellow, True, True)
                RichLogs("Worker Flash Is Running...", Color.Yellow, True, True)
            End If

            StringXml = String.Concat(StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
            StringXml = String.Concat(StringXml, "<data>" & vbCrLf & "")


            totalchecked = 0
            For Each item As DataGridViewRow In DataView.Rows
                If item.Cells(DataView.Columns(4).Index).Value = "persistent" Then
                    totalchecked += 1

                    StringXml = String.Concat(StringXml, String.Format("<program SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0"" filename=""{1}"" label=""{2}"" num_partition_sectors=""{3}"" physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {
                            SectorSize, '512, 4096
                            item.Cells(DataView.Columns(7).Index).Value.ToString(), 'filenames = Locations
                            item.Cells(DataView.Columns(4).Index).Value.ToString(), 'label = Partitions
                            item.Cells(DataView.Columns(6).Index).Value.ToString(),  'num_partition_sectors = End Sectors
                            item.Cells(DataView.Columns(1).Index).Value.ToString(),   'physical_partition_number = Luns
                            item.Cells(DataView.Columns(5).Index).Value.ToString()    'start_sector = Start Sector
                            }),
                            "" & vbCrLf & "")
                Else
                    XtraMessageBox.Show("Tidak ada data FRP Samsung!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return
                End If
            Next

            StringXml = String.Concat(StringXml, "</data>")

        Else
            XtraMessageBox.Show("Tidak ada data!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

    End Sub


    Private Sub Btn_OFPQc_Click(sender As Object, e As EventArgs) Handles Btn_OFPQc.Click
        Dim openFileDialog As New OpenFileDialog() With
                            {
                            .Title = "Select Qualcomm OFP",
                            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                            .FileName = "*.*",
                            .Filter = "all file |*.*;*.* ",
                            .FilterIndex = 2,
                            .RestoreDirectory = True
                            }
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            TxtOFPQC.Text = openFileDialog.FileName
            OFPExtractor.fname = openFileDialog.FileName
            Dim folderBrowserDialog As New FolderBrowserDialog() With
                            {
                            .ShowNewFolderButton = True
                            }

            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                foldersave = folderBrowserDialog.SelectedPath
                OFPExtractor.LoadTabelKeyOFP()
                OFPExtractor.OPFWorkerQC.RunWorkerAsync()
                OFPExtractor.OPFWorkerQC.Dispose()
            End If
        End If
    End Sub
End Class
