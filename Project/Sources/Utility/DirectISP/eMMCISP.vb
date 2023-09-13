Imports emmclibs.emmclibs
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Management
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports System.Runtime.CompilerServices
Imports Reverse_Tool.Android
Imports Reverse_Tool.Sourcefile
Imports Reverse_Tool.Bismillah.FIREHOSE.FIREHOSE_MANAGER
Imports Reverse_Tool.EjectUSB

Public Class EMMCISP

#Region "Deklarasi"
    Public Shared asu As String = ""
    Public Shared commands As String = ""
    Public Shared secc As Long
    Public Shared str As String = ""
    Public Shared str2 As String = ""
    Public Shared str3 As String = ""
    Public Shared disk As String = ""
    Public Shared pname As String = ""
    Public Shared drivename As String = ""
    Public Shared selecteddisk As String = ""
    Public Shared m As String = ""
    Public Shared partname As String = ""
    Public Shared totalchunk As String = ""
    Public Shared openfile As String = ""
    Public Shared pilih As String = ""
    Public Shared portqcom As String = ""
    Public Shared portNameData As String = ""
    Public Shared comPortNumber As String = ""
    Public Shared spa As String = ""
    Public Shared chipa As String = "platform: "
    Public Shared port As String = ""
    Public Shared ukuran As String = ""
    Public Shared pi As String = "- partition_index: "
    Public Shared pn As String = "  partition_name: "
    Public Shared fn As String = "  file_name: "
    Public Shared id As String = "  is_download: "
    Public Shared ty As String = "  type: "
    Public Shared lin As String = "  linear_start_addr: "
    Public Shared py As String = "  physical_start_addr: "
    Public Shared ps As String = "  partition_size: "
    Public Shared reg As String = "  region: "
    Public Shared sto As String = "  storage:"
    Public Shared bc As String = "  boundary_check: "
    Public Shared ir As String = "  is_reserved: "
    Public Shared ot As String = "  operation_type: "
    Public Shared iu As String = "  is_upgradable: "
    Public Shared ebn As String = "  empty_boot_needed: "
    Public Shared re As String = "  reserve: "
    Public Shared da As String = String.Concat(CurDir(), "\spft\MTK_AllInOne_DA.bin")
    Public Shared foldersave As String = ""
    Public Shared gen As String = "- general: MTK_PLATFORM_CFG"
    Public Shared info As String = "  info: "
    Public Shared conf As String = "    - config_version: "
    Public Shared plat As String = "platform:"
    Public Shared pro As String = "project:"
    Public Shared boot As String = "boot_channel:"
    Public Shared block As String = "block_size: "
    Public Shared storage As String = "      storage: EMMC"
    Public Shared tstor As String = "storage:"
    Public Shared tstor1 As String = "boot_channel"
    Public Shared chipb As String = "platform: "

    Public Shared berapakali As Long = 0
    Public Shared configpart As Long = 0
    Public Shared dawane As Long = 0
    Public Shared miscpart As Long = 0
    Public Shared offset As Long = 0
    Public Shared karung As Long = 0
    Public Shared startsecpart As Long = 0
    Public Shared filesize As Long = 0
    Public Shared offsets As Long = 0
    Public Shared poffsets As Long = 0
    Public Shared psize As Long = 0
    Public Shared awales As Long = 0

    Public Shared i As Integer = 0
    Public Shared c As Char()

    Public Shared disksec As Object
    Public Shared uks As Object
    Public Shared sentot As Object
    Public Shared folderdersave As Object

    Public Shared checksparse As Boolean = False
    Public Shared cekerror As Boolean = False
    Public Shared check As Boolean = False
    Public Shared status As Boolean = False

    Public Shared num8 As Double = 0

    Public Shared SelectedCommand As String = ""
    Public Shared TodoCommand As String = ""
    Public Shared Totaltodo As Integer = 0

    Public Shared ListBox1 As ListBox
    Public Shared ListBox2 As ListBox
    Public Shared ListBox3 As ListBox
    Public Shared ListBox4 As ListBox
    Public Shared ListBox5 As ListBox
    Public Shared ListBox6 As ListBox
    Public Shared ListBox7 As ListBox

    Public Shared Property Lvi As ListViewItem
    Public Shared Property ListView1 As New ListView
    Public Shared Property ListView2 As New ListView
    Public Shared proc As Process

    Public Delegate Sub txtbabbledelegate(ByVal text As String)

    Public Shared waitEvent As New AutoResetEvent(False)

    Public Shared prosesnya As Object
    Public Shared allprosess As Object

    Public Shared Watch As New Stopwatch()

#End Region

    Public Shared Sub Refresh_Disk(e As DoWorkEventArgs)
        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
        asu = ""
        drivename = ""
        Main.SharedUI.comboUSB.Invoke(Sub()
                                          If Main.SharedUI.comboUSB.Properties.Items.Count > 0 Then
                                              Main.SharedUI.comboUSB.Properties.Items.Clear()
                                              Main.SharedUI.comboUSB.Text = ""
                                          End If
                                      End Sub)

        Dim flag As Boolean = False
        Dim flagdisk As Boolean = False
        Using managementObjectSearcher As New System.Management.ManagementObjectSearcher(New WqlObjectQuery("SELECT * FROM Win32_DiskDrive"))
            enumerator = managementObjectSearcher.[Get]().GetEnumerator()
            While enumerator.MoveNext()
                Dim current As ManagementObject = DirectCast(enumerator.Current, ManagementObject)

                If Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectGreater(current("MediaType"), Nothing, False)) AndAlso current("MediaType").ToString().Contains("Removable")) Then

                    flagdisk = True
                    If Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectGreater(current("MediaType"), Nothing, False)) AndAlso current("MediaType").ToString().Contains("Removable")) Then
                        str = "eTHR eMMC Red Edition" 'current("Model").ToString()
                        uks = current("size").ToString()
                        str2 = current("DeviceID").ToString().Replace("\\.\", "")
                        str3 = String.Concat("MediaType:	", current("MediaType").ToString())
                        drivename = str2
                        RichLogs(" Found     : ", Color.White, True, False)
                        RichLogs(String.Concat(str2, " [ ", str, " ] "), Color.DeepSkyBlue, True, True)
                        Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Properties.Items.Add(String.Concat(str2, " [ ", str, " ] ")), Action))
                        Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.SelectedItem = String.Concat(str2, " [ ", str, " ] "), Action))
                        flag = True
                    End If
                End If
            End While
        End Using
        If flag Then
            ComboboxDisk_Selected(e)
        Else
            If flagdisk Then
                RichLogs(" Error !   : ", Color.Crimson, True, False)
                RichLogs("Disk Detected", Color.Crimson, True, True)
                RichLogs("             But EIP-Tool or eTHR or MFE Interface Doesn't Found... ", Color.Crimson, True, True)
                RichLogs("             Get It From -> https://www.smart-connects.com ", Color.WhiteSmoke, True, True)
            Else
                RichLogs(" Error !   : ", Color.Crimson, True, False)
                RichLogs("Disk Doesn't Detected.", Color.Crimson, True, True)
                RichLogs("             Please Check Direct ISP Pinout Connection And Try Again... ", Color.Crimson, True, True)
            End If
        End If
    End Sub

    Public Shared Sub ComboboxDisk_Selected(e As DoWorkEventArgs)
        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Dim USBSelected As String = ""
        Main.SharedUI.comboUSB.Invoke(CType(Sub() USBSelected = Main.SharedUI.comboUSB.Text, Action))
        selecteddisk = USBSelected.Replace("[ " & str & " ]", "").Replace("PHYSICALDRIVE", "").Replace(" ", "")
        Dim managementObjectEnumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
        ListBox1.Items.Clear()
        Dim wqlObjectQuery1 As New System.Management.WqlObjectQuery(String.Concat("SELECT * FROM Win32_Diskpartition Where Diskindex = '", selecteddisk, "'"))
        Dim managementObjectSearcher1 As New System.Management.ManagementObjectSearcher(wqlObjectQuery1)
        Using managementObjectSearcher1
            Dim num As Integer = 0
            managementObjectEnumerator = managementObjectSearcher1.[Get]().GetEnumerator()
            While managementObjectEnumerator.MoveNext()
                Dim managementObject As System.Management.ManagementObject = DirectCast(managementObjectEnumerator.Current, System.Management.ManagementObject)
                str = managementObject("startingoffset").ToString()
                ListBox1.Items.Add(str)
                num += 1
            End While
        End Using
        If ListBox1.Items.Count > 0 Then
            secc = Conversions.ToLong(ListBox1.Items(0))
        Else
            RichLogs(" ", Color.Red, True, True)
            RichLogs(" ", Color.Red, True, True)
            RichLogs("Error!", Color.Red, True, True)
            RichLogs(" eMMC has no partition or blank or encrypted partition label", Color.FromArgb(97, 197, 84), True, True)
            RichLogs(" Please Write PrimaryGPT or Write Dump File...", Color.FromArgb(97, 197, 84), True, True)
            RichLogs(" ", Color.Red, True, True)
            secc = 1048576
        End If
    End Sub
    Public Shared Sub Scan_Partition(e As DoWorkEventArgs)
        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        asu = ""
        m = "readgpt"
        ListView1.Clear()
        ListView2.Clear()
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        Dim num As Long = secc
        ListBox3.Items.Clear()

        Dim strusb As String = ""
        Main.SharedUI.comboUSB.Invoke(CType(Sub() strusb = Main.SharedUI.comboUSB.Text, Action))
        If (Equals(strusb, "")) Then
            MsgBox("Please select disk", MsgBoxStyle.OkOnly, Nothing)
        Else
            DirectISP.SharedUI.Logs1("Reading PrimaryGPT & Create Auto Backup ...")
            Try
                Dim _streamer As emmc.streamer = emmc.CreateStream(String.Concat("\\.\PHYSICALDRIVE", selecteddisk), FileAccess.ReadWrite)
                Try
                    If File.Exists("Tools\process\file\readgpt.bin") Then
                        File.Delete("Tools\process\file\readgpt.bin")
                    End If

                    Dim fileStream As New System.IO.FileStream("Tools\process\file\readgpt.bin", FileMode.Append, FileAccess.Write)
                    Try
                        Using fileStream
                            Dim numArray As Byte() = emmc.ReadSector(CLng(0), CInt(num), _streamer)
                            fileStream.Write(numArray, 0, CInt(num))
                        End Using
                    Catch exfs As Exception
                        MsgBox(exfs.ToString())
                    Finally
                        fileStream.Close()
                    End Try
                Finally
                    emmc.DropStream(_streamer)
                End Try


                ListView1.Clear()
                ListView1.Items.Clear()
                DirectISP.SharedUI.Logs2("done")
                Dim process As New System.Diagnostics.Process()
                DirectISP.SharedUI.Logs2("Analyzing partition Table ....")
                Dim process1 As New System.Diagnostics.Process()
                Dim startInfo As ProcessStartInfo = process1.StartInfo
                startInfo.FileName = "Tools\process\file\7z.exe"
                startInfo.Arguments = " l Tools\process\file\readgpt.bin -slt"
                startInfo.UseShellExecute = False
                startInfo.CreateNoWindow = True
                startInfo.RedirectStandardInput = True
                startInfo.RedirectStandardOutput = True
                startInfo.RedirectStandardError = True
                startInfo.StandardOutputEncoding = Encoding.ASCII
                startInfo = Nothing
                process1.Start()
                Dim standardOutput As StreamReader = process1.StandardOutput
                Dim lineskip As Integer = 9
                Dim nums As Integer = 0
                While Not process1.StandardOutput.EndOfStream
                    Dim str As String = standardOutput.ReadLine().Replace("Errors: 1", "")
                    nums += 1

                    If nums > lineskip Then
                        TxtBabble(str)
                    End If

                End While
                process1.Dispose()

                Dim textBox As New TextBox
                Main.SharedUI.RichTextBoxOutput.Invoke(CType(Sub() textBox.Text = Main.SharedUI.RichTextBoxOutput.Text, Action))

                ListBox1.Items.Add("PrimaryGPT")
                ListBox2.Items.Add("17408")
                ListBox3.Items.Add("0")
                If textBox.Text.Contains("Path") OrElse textBox.Text.Contains("Size") Then
                    Dim strArrays(2) As String
                    Dim strArrays1(2) As String
                    Dim lines As String() = textBox.Lines
                    Dim num1 As Integer = 0
                    While num1 < CInt(lines.Length)
                        Dim str1 As String = lines(num1)
                        If Not str1.Contains("Path = Tools\process\file\readgpt.bin") AndAlso Not str1.Contains("Physical Size") Then
                            If str1.Contains("Path") Then
                                str1 = Regex.Replace(str1, "Path = ", "")
                                str1 = Regex.Replace(str1, ".ntfs", "")
                                str1 = Regex.Replace(str1, ".img", "")
                                ListBox1.Items.Add(str1)
                            End If
                        End If
                        If Not str1.Contains("Physical Size") AndAlso Not str1.Contains("Path = Tools\process\file\readgpt.bin") Then
                            If str1.Contains("Size") Then
                                str1 = Regex.Replace(str1, "Size = ", "")
                                ListBox2.Items.Add(str1)
                            End If
                        End If
                        If Not str1.Contains("Physical Size") AndAlso Not str1.Contains("Path = Tools\process\file\readgpt.bin") Then
                            If str1.Contains("Offset") Then
                                str1 = Regex.Replace(str1, "Offset = ", "")
                                ListBox3.Items.Add(str1)
                            End If
                        End If
                        num1 += 1
                    End While
                End If

                DirectISP.SharedUI.DGV_C()
                Dim count As Integer = ListBox1.Items.Count - 1
                i = 0
                While i <= count
                    Lvi = New ListViewItem() With
            {
                .Text = Conversions.ToString(ListBox1.Items(i))
            }
                    Dim num2 As Integer = i
                    Dim num3 As Integer = num2
                    Dim item(0) As Object
                    Dim subItems As ListViewItem.ListViewSubItemCollection = Lvi.SubItems
                    Dim items As ListBox.ObjectCollection = ListBox1.Items
                    Dim objectValue As ListBox.ObjectCollection = items
                    item(0) = items(num2)
                    Dim objArray As Object() = item
                    Dim flagArray() As Boolean = {True}
                    Dim flagArray1 As Boolean() = flagArray
                    NewLateBinding.LateCall(subItems, Nothing, "Add", item, Nothing, Nothing, flagArray, True)

                    If flagArray1(0) Then
                        objectValue(num3) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                    End If

                    Dim listViewSubItemCollections As ListViewItem.ListViewSubItemCollection = Lvi.SubItems
                    Dim item1(0) As Object
                    Dim objectCollections As ListBox.ObjectCollection = ListBox2.Items
                    objectValue = objectCollections
                    Dim num4 As Integer = i
                    num3 = num4
                    item1(0) = objectCollections(num4)
                    objArray = item1
                    Dim flagArray2() As Boolean = {True}
                    flagArray1 = flagArray2
                    NewLateBinding.LateCall(listViewSubItemCollections, Nothing, "Add", item1, Nothing, Nothing, flagArray2, True)
                    If flagArray1(0) Then
                        objectValue(num3) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                    End If

                    Dim subItems1 As ListViewItem.ListViewSubItemCollection = Lvi.SubItems
                    Dim objArray1(0) As Object
                    Dim items1 As ListBox.ObjectCollection = ListBox3.Items
                    objectValue = items1
                    Dim num5 As Integer = i
                    num3 = num5
                    objArray1(0) = items1(num5)
                    objArray = objArray1
                    Dim flagArray3() As Boolean = {True}
                    flagArray1 = flagArray3
                    NewLateBinding.LateCall(subItems1, Nothing, "Add", objArray1, Nothing, Nothing, flagArray3, True)
                    If flagArray1(0) Then
                        objectValue(num3) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                    End If
                    Lvi.SubItems.Add("")

                    ListView1.Items.Add(Lvi)

                    i += 1
                End While


                Dim lvItem() As String
                Dim bool As Boolean = False
                Dim location As String = ""
                For i As Integer = 0 To ListView1.Items.Count - 1
                    If (File.Exists(ListView1.Items(i).SubItems(4).Text)) Then
                        bool = True
                        location = ListView1.Items(i).SubItems(4).Text
                    Else
                        bool = False
                        location = ""
                    End If
                    lvItem = {bool, ListView1.Items(i).SubItems(1).Text, "double click...", ListView1.Items(i).SubItems(2).Text, ListView1.Items(i).SubItems(3).Text, location}
                    DirectISP.SharedUI.DataView.Invoke(CType(Sub() DirectISP.SharedUI.DataView.Rows.Add(lvItem), Action))
                Next

                For Each row As DataGridViewRow In DirectISP.SharedUI.DataView.Rows

                    If row.Cells(1).Value.ToString() = "modem" _
                     OrElse row.Cells(1).Value.ToString() = "modemst1" _
                     OrElse row.Cells(1).Value.ToString() = "modemst2" _
                     OrElse row.Cells(1).Value.ToString() = "fsg" _
                     OrElse row.Cells(1).Value.ToString() = "proinfo" _
                     OrElse row.Cells(1).Value.ToString() = "nvdata" _
                     OrElse row.Cells(1).Value.ToString() = "nvram" _
                     OrElse row.Cells(1).Value.ToString() = "secro" _
                     OrElse row.Cells(1).Value.ToString() = "ProdNV" _
                     OrElse row.Cells(1).Value.ToString() = "Modem_W" _
                     OrElse row.Cells(1).Value.ToString() = "NV_W" _
                     OrElse row.Cells(1).Value.ToString() = "NV_WCN" _
                     OrElse row.Cells(1).Value.ToString() = "PrimaryGPT" _
                     OrElse row.Cells(1).Value.ToString() = "persist" _
                     OrElse row.Cells(1).Value.ToString() = "persistbak" _
                     OrElse row.Cells(1).Value.ToString() = "persistent" _
                     OrElse row.Cells(1).Value.ToString() = "oppodycnvbk" _
                     OrElse row.Cells(1).Value.ToString() = "oppostanvbk" _
                     OrElse row.Cells(1).Value.ToString() = "EFS" _
                     OrElse row.Cells(1).Value.ToString() = "config" _
                     Then
                        row.DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next

                process1.Dispose()
                check = False
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Console.WriteLine("eMMC has no partition or blank or encrypted partitin label")
                Console.WriteLine("please write partion table or full dump")
                Console.WriteLine(exception)
                ProjectData.ClearProjectError()
            End Try
        End If

        For Each row As DataGridViewRow In DirectISP.SharedUI.DataView.Rows
            If Equals(row.Cells(DirectISP.SharedUI.DataView.Columns(1).Index).Value.ToString(), "PrimaryGPT") Then
                Console.WriteLine("Identify search PrimaryGPT ..." & row.Cells(DirectISP.SharedUI.DataView.Columns(3).Index).Value.ToString())
                If File.Exists("Backup\GPT\gpt_main0.bin") Then
                    File.Delete("Backup\GPT\gpt_main0.bin")
                End If
                folderdersave = "Backup\GPT"
                Totaltodo += 1
                TodoCommand = ""
                TodoCommand = String.Concat(TodoCommand, row.Cells(0).Value, "|", row.Cells(1).Value, "|", row.Cells(3).Value, "|", row.Cells(4).Value, "|", row.Cells(5).Value & Environment.NewLine & "")
                Read(e)
            End If
        Next

        Delay(1)
        Dim Saveas As String = CLng(DateTime.Now.Subtract(New DateTime()).TotalMilliseconds)
        If File.Exists("Backup\GPT\gpt_main0.bin") Then
            File.Move("Backup\GPT\gpt_main0.bin", "Backup\GPT\" & Saveas & "_AutoBackup_PrimaryGPT.bin")
            Delay(1)
        End If

        RichLogs("PrimaryGPT Saved   : ", Color.WhiteSmoke, False, False)
        RichLogs(Saveas & "_AutoBackup_PrimaryGPT.bin", Color.WhiteSmoke, False, True)

        check = False
    End Sub

    Public Shared Sub Scan_Dump(e As DoWorkEventArgs)
        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Dim enumerator As IEnumerator = Nothing
        asu = ""
        ListView1.Items.Clear()
        ListView1.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()

        Dim process As New System.Diagnostics.Process()
        Dim startInfo As ProcessStartInfo = process.StartInfo
        startInfo.FileName = "Tools\process\file\7z.exe"
        startInfo.Arguments = String.Concat(" l """, DirectISP.SharedUI.TxtRawDump.Text, """ -slt")
        startInfo.UseShellExecute = False
        startInfo.CreateNoWindow = True
        startInfo.RedirectStandardInput = True
        startInfo.RedirectStandardOutput = True
        startInfo.RedirectStandardError = True
        startInfo.StandardOutputEncoding = Encoding.ASCII
        startInfo = Nothing
        process.Start()
        Dim standardOutput As System.IO.StreamReader = process.StandardOutput

        Dim lineskip As Integer = 9
        Dim nums As Integer = 0
        While Not process.StandardOutput.EndOfStream

            Dim str As String = standardOutput.ReadLine().Replace("Errors: 1", "")
            nums += 1

            If nums > lineskip Then
                TxtBabble(str)
            End If

        End While

        process.Dispose()

        Dim textBox As New TextBox
        Main.SharedUI.RichTextBoxOutput.Invoke(CType(Sub() textBox.Text = Main.SharedUI.RichTextBoxOutput.Text, Action))

        ListBox1.Items.Add("PrimaryGPT")
        ListBox2.Items.Add("")
        ListBox3.Items.Add("0")
        If textBox.Text.Contains("Path") OrElse textBox.Text.Contains("Size") Then
            Dim strArrays(2) As String
            Dim strArrays1(2) As String
            Dim lines As String() = textBox.Lines
            Dim num As Integer = 0
            While num < CInt(lines.Length)
                Dim str1 As String = lines(num)
                If Not str1.Contains(DirectISP.SharedUI.TxtRawDump.Text) AndAlso Not str1.Contains("Physical Size") Then
                    If str1.Contains("Path") Then
                        str1 = Regex.Replace(str1, "Path = ", "")
                        str1 = Regex.Replace(str1, ".img", "")
                        strArrays = str1.Split(New Char() {ChrW(32)})
                        ListBox1.Items.Add(str1)
                    End If
                End If
                If Not str1.Contains(DirectISP.SharedUI.TxtRawDump.Text) AndAlso Not str1.Contains("Physical Size") Then
                    If str1.Contains("Size") Then
                        str1 = Regex.Replace(str1, "Size = ", "")
                        ListBox2.Items.Add(str1)
                    End If
                End If
                If Not str1.Contains(DirectISP.SharedUI.TxtRawDump.Text) AndAlso Not str1.Contains("Physical Size") Then
                    If str1.Contains("Offset") Then
                        str1 = Regex.Replace(str1, "Offset = ", "")
                        ListBox3.Items.Add(str1)
                    End If
                End If
                num += 1
            End While
            ListBox2.Items(0) = RuntimeHelpers.GetObjectValue(ListBox3.Items(1))
            ListView1.Items.Clear()
            Dim count As Integer = ListBox1.Items.Count - 1
            i = 0
            While i <= count
                Lvi = New ListViewItem() With
        {
            .Text = Conversions.ToString(ListBox1.Items(i))
        }
                Dim subItems As ListViewItem.ListViewSubItemCollection = Lvi.SubItems
                Dim item(0) As Object
                Dim items As ListBox.ObjectCollection = ListBox1.Items
                Dim objectValue As ListBox.ObjectCollection = items
                Dim num1 As Integer = i
                Dim num2 As Integer = num1
                item(0) = items(num1)
                Dim objArray As Object() = item
                Dim flagArray() As Boolean = {True}
                Dim flagArray1 As Boolean() = flagArray
                NewLateBinding.LateCall(subItems, Nothing, "Add", item, Nothing, Nothing, flagArray, True)
                If flagArray1(0) Then
                    objectValue(num2) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                End If
                Dim listViewSubItemCollections As ListViewItem.ListViewSubItemCollection = Lvi.SubItems
                Dim item1(0) As Object
                Dim objectCollections As ListBox.ObjectCollection = ListBox2.Items
                objectValue = objectCollections
                Dim num3 As Integer = i
                num2 = num3
                item1(0) = objectCollections(num3)
                objArray = item1
                Dim flagArray2() As Boolean = {True}
                flagArray1 = flagArray2
                NewLateBinding.LateCall(listViewSubItemCollections, Nothing, "Add", item1, Nothing, Nothing, flagArray2, True)
                If flagArray1(0) Then
                    objectValue(num2) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                End If
                Dim subItems1 As ListViewItem.ListViewSubItemCollection = Lvi.SubItems
                Dim objArray1(0) As Object
                Dim items1 As ListBox.ObjectCollection = ListBox3.Items
                objectValue = items1
                Dim num4 As Integer = i
                num2 = num4
                objArray1(0) = items1(num4)
                objArray = objArray1
                Dim flagArray3() As Boolean = {True}
                flagArray1 = flagArray3
                NewLateBinding.LateCall(subItems1, Nothing, "Add", objArray1, Nothing, Nothing, flagArray3, True)
                If flagArray1(0) Then
                    objectValue(num2) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                End If
                If Not Operators.ConditionalCompareObjectEqual(ListBox1.Items(i), "", False) Then
                    ListView1.Items.Add(Lvi)
                End If
                i += 1
            End While


            Dim lvItem() As String
            For i As Integer = 0 To ListView1.Items.Count - 1
                lvItem = {False, ListView1.Items(i).SubItems(1).Text, "double click...", ListView1.Items(i).SubItems(2).Text, ListView1.Items(i).SubItems(3).Text, ""}
                DirectISP.SharedUI.DataView.Invoke(CType(Sub() DirectISP.SharedUI.DataView.Rows.Add(lvItem), Action))
            Next

            For Each row As DataGridViewRow In DirectISP.SharedUI.DataView.Rows

                If row.Cells(1).Value.ToString() = "modem" _
                     OrElse row.Cells(1).Value.ToString() = "modemst1" _
                     OrElse row.Cells(1).Value.ToString() = "modemst2" _
                     OrElse row.Cells(1).Value.ToString() = "fsg" _
                     OrElse row.Cells(1).Value.ToString() = "proinfo" _
                     OrElse row.Cells(1).Value.ToString() = "nvdata" _
                     OrElse row.Cells(1).Value.ToString() = "nvram" _
                     OrElse row.Cells(1).Value.ToString() = "secro" _
                     OrElse row.Cells(1).Value.ToString() = "ProdNV" _
                     OrElse row.Cells(1).Value.ToString() = "Modem_W" _
                     OrElse row.Cells(1).Value.ToString() = "NV_W" _
                     OrElse row.Cells(1).Value.ToString() = "NV_WCN" _
                     OrElse row.Cells(1).Value.ToString() = "PrimaryGPT" _
                     OrElse row.Cells(1).Value.ToString() = "persist" _
                     OrElse row.Cells(1).Value.ToString() = "persistbak" _
                     OrElse row.Cells(1).Value.ToString() = "persistent" _
                     OrElse row.Cells(1).Value.ToString() = "oppodycnvbk" _
                     OrElse row.Cells(1).Value.ToString() = "oppostanvbk" _
                     OrElse row.Cells(1).Value.ToString() = "EFS" _
                     OrElse row.Cells(1).Value.ToString() = "config" _
                     Then
                    row.DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

            If File.Exists("build.prop") Then
                File.Delete("build.prop")
            End If
            DirectISP.SharedUI.Logs2("Scanning file system...")
            Delay(1)
            Try
                enumerator = ListView1.Items.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                    If Equals(current.SubItems(1).Text, "system") Then
                        Dim text As String = current.SubItems(3).Text
                        Dim text1 As String = current.SubItems(2).Text
                        Dim num5 As Long = CLng(0)
                        If Conversions.ToDouble(text1) >= 536870912 Then
                            num5 = CLng(536870912)
                        End If
                        Dim fileStream As New System.IO.FileStream(openfile, FileMode.Open, FileAccess.Read)
                        Dim fileStream1 As New System.IO.FileStream("build.prop", FileMode.Append, FileAccess.Write)
                        Try
                            Try
                                Using fileStream
                                    Dim Stopwatch As New Stopwatch()
                                    Stopwatch.Start()
                                    Dim num6 As Integer = 1048576
                                    Dim num7 As Double = Conversions.ToDouble(text1) / CDbl(num6)
                                    num7 = Int(num7)
                                    fileStream.Position = Conversions.ToLong(text)
                                    Dim num8 As Integer = CInt(Math.Round(num7))
                                    i = 0
                                    While i <= num8

                                        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                            e.Cancel = True
                                            Stopwatch.Stop()
                                            fileStream.Close()
                                            Return
                                        End If

                                        If CDbl(i) = num7 Then
                                            num6 = CInt(Math.Round(Conversions.ToDouble(text1) - num7 * CDbl(num6)))
                                            If num6 = 0 Then
                                                Exit While
                                            End If
                                        End If
                                        Dim numArray(num6 - 1 + 1 - 1) As Byte
                                        Dim num9 As Long = CLng(i * num6)
                                        Dim num10 As Double = Conversions.ToDouble(text) + CDbl(num5)
                                        fileStream.Read(numArray, 0, num6)
                                        If Not UnicodeBytesToString(numArray).Contains("begin build prop") Then
                                            i += 1
                                        Else
                                            fileStream1.Write(numArray, 0, num6)
                                            fileStream1.Close()
                                            RichLogs("Reading Dump Info ....", Color.DarkOrchid, False, True)
                                            RichLogs(" ", Color.DarkOrchid, False, True)

                                            Dim streamReader As System.IO.StreamReader = Computer.FileSystem.OpenTextFileReader("build.prop")
                                            While True
                                                Dim str2 As String = streamReader.ReadLine()
                                                If str2.Contains("ro.product.model") Then
                                                    RichLogs("Model    : " & str2.Replace("ro.product.model=", ""), Color.WhiteSmoke, False, True)
                                                End If
                                                If str2.Contains("ro.product.brand") Then
                                                    RichLogs("Brand    : " & str2.Replace("ro.product.brand=", ""), Color.WhiteSmoke, False, True)
                                                End If
                                                If str2.Contains("ro.product.locale.region") Then
                                                    RichLogs("Region   : " & str2.Replace("ro.product.locale.region=", ""), Color.WhiteSmoke, False, True)
                                                End If
                                                If str2.Contains("ro.product.name") Then
                                                    RichLogs("Codename : " & str2.Replace("ro.product.name=", ""), Color.WhiteSmoke, False, True)
                                                End If
                                                If str2.Contains("ro.build.display.id") Then
                                                    RichLogs("Build ID : " & str2.Replace("ro.build.display.id=", ""), Color.WhiteSmoke, False, True)
                                                End If
                                                If str2.Contains("ro.build.version.security_patch") Then
                                                    RichLogs("Security : " & str2.Replace("ro.build.version.security_patch=", ""), Color.WhiteSmoke, False, True)
                                                End If
                                                If str2.Contains("ro.frp.pst=") Then
                                                    RichLogs("FRP Part : " & str2.Replace("ro.frp.pst=", ""), Color.WhiteSmoke, False, True)
                                                End If
                                                If str2.Contains("end build prop") Then
                                                    Exit While
                                                End If
                                            End While
                                            streamReader.Close()
                                            Return
                                        End If
                                    End While
                                End Using
                            Catch exception As System.Exception
                                ProjectData.SetProjectError(exception)
                                DirectISP.SharedUI.Logs2("  Error at " & Conversions.ToString(karung))
                                ProjectData.ClearProjectError()
                            End Try
                        Finally
                            fileStream.Close()
                        End Try
                    End If
                End While
            Catch ex As Exception
                '
            End Try
        End If
    End Sub
    Public Shared Sub TxtBabble(ByVal text As String)
        DirectISP.SharedUI.Logs2(text)

        If Equals(asu, "inisparse") Then
            If text.Contains("filename") Then
                Dim str As String = text.Replace(".sparse", "")
                str = str.Replace("filename", "")
                str = str.Replace(" ", "")
                Dim num As Double = (Conversions.ToDouble(totalchunk) - Conversions.ToDouble(str)) / (Conversions.ToDouble(totalchunk) - 1) * 100
                DirectISP.SharedUI.PB2(CInt(Math.Round(num)))
            End If
            Dim fileInfo As New System.IO.FileInfo("unsparse.img")
        End If
    End Sub
    Public Shared Sub Identity(e As DoWorkEventArgs)
        If DirectISP.SharedUI.DataView.RowCount > 0 Then
            If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                e.Cancel = True
                Return
            End If
            Console.WriteLine("Identify start ...")
            For Each row As DataGridViewRow In DirectISP.SharedUI.DataView.Rows
                If Equals(row.Cells(DirectISP.SharedUI.DataView.Columns(1).Index).Value.ToString(), "recovery") Then
                    Console.WriteLine("Identify search recovery ..." & row.Cells(DirectISP.SharedUI.DataView.Columns(3).Index).Value.ToString())

                    If Not File.Exists(Andoidpath) Then
                        Directory.CreateDirectory(Path.GetDirectoryName(Andoidpath))
                        File.WriteAllBytes(Andoidpath, My.Resources.C4)
                    End If

                    If File.Exists(Dumped) Then
                        File.Delete(Dumped)
                    End If

                    folderdersave = Directorypath
                    Totaltodo += 1
                    TodoCommand = ""
                    TodoCommand = String.Concat(TodoCommand, row.Cells(0).Value, "|", row.Cells(1).Value, "|", row.Cells(3).Value, "|", row.Cells(4).Value, "|", row.Cells(5).Value & Environment.NewLine & "")


                    Read(e)

                    RichLogs(" ", Color.Orange, True, True)
                    RichLogs("Reading Device Info : ... ", Color.WhiteSmoke, True, True)

                    If File.Exists(Directorypath & "/recovery.img") Then
                        File.Move(Directorypath & "/recovery.img", Directorypath & "/boot.img")
                    End If

                    If File.Exists(Directorypath & "/boot.img") Then
                        AndroidUnpack(Path.GetFileName(Dumped), Path.GetDirectoryName(Andoidpath) & "\initrd\", DirectISP.SharedUI.eMMCISPWorker, e)

                        Dim directory As New DirectoryInfo(Path.GetDirectoryName(Andoidpath))

                        For Each file As FileInfo In directory.EnumerateFiles()
                            file.Delete()
                        Next

                        For Each subDirectory As DirectoryInfo In directory.EnumerateDirectories()
                            subDirectory.Delete(True)
                        Next

                        directory.Delete(True)

                    End If

                End If
            Next
        End If
    End Sub
    Public Shared Function UnicodeBytesToString(ByVal bytes As Byte()) As String
        Return Encoding.ASCII.GetString(bytes)
    End Function

    Public Shared Sub Open_RAWXML()
        Dim enumerator As IEnumerator = Nothing
        DirectISP.SharedUI.DGV_C()
        If File.Exists(DirectISP.SharedUI.TxtFlashRawXML.Text) Then
            Dim xmlReader As System.Xml.XmlReader = XmlReader.Create(DirectISP.SharedUI.TxtFlashRawXML.Text)
            While xmlReader.Read()
                If (xmlReader.NodeType = XmlNodeType.Element AndAlso Operators.CompareString(xmlReader.Name, "program", False) = 0) Then
                    Lvi = New System.Windows.Forms.ListViewItem()
                    Lvi.SubItems.Add(xmlReader.GetAttribute("label"))
                    Lvi.SubItems.Add(Conversions.ToString(Conversions.ToDouble(xmlReader.GetAttribute("num_partition_sectors")) * 512))
                    If Not xmlReader.GetAttribute("start_sector").Contains("NUM_DISK_SECTORS") Then
                        Lvi.SubItems.Add(Conversions.ToString(Conversions.ToDouble(xmlReader.GetAttribute("start_sector")) * 512))
                    Else
                        Dim str2 As String = xmlReader.GetAttribute("start_sector").Replace("NUM_DISK_SECTORS-", "").Replace(".", "")
                        NewLateBinding.LateCall(Lvi.SubItems, Nothing, "Add", New Object() {Operators.SubtractObject(uks, Conversions.ToDouble(str2) * 512)}, Nothing, Nothing, Nothing, True)
                    End If

                    If Not Equals(xmlReader.GetAttribute("filename"), "") Then
                        Lvi.SubItems.Add(If(String.Concat(Path.GetDirectoryName(DirectISP.SharedUI.TxtFlashRawXML.Text), "\", xmlReader.GetAttribute("filename")), ""))
                    Else
                        Lvi.SubItems.Add("none")
                    End If
                    ListView1.Items.Add(Lvi)
                    Lvi.Checked = True
                End If
            End While
            Try

                Dim lvItem() As String
                Dim bool As Boolean = False
                Dim location As String = ""
                enumerator = ListView1.Items.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As System.Windows.Forms.ListViewItem = DirectCast(enumerator.Current, System.Windows.Forms.ListViewItem)
                    If (File.Exists(current.SubItems(4).Text)) Then
                        bool = True
                        location = current.SubItems(4).Text
                    Else
                        bool = False
                        location = ""
                    End If
                    lvItem = {bool, current.SubItems(1).Text, "double click...", current.SubItems(2).Text, current.SubItems(3).Text, location}
                    DirectISP.SharedUI.DataView.Rows.Add(lvItem)
                End While


                For Each row As DataGridViewRow In DirectISP.SharedUI.DataView.Rows

                    If row.Cells(1).Value.ToString() = "modem" _
                     OrElse row.Cells(1).Value.ToString() = "modemst1" _
                     OrElse row.Cells(1).Value.ToString() = "modemst2" _
                     OrElse row.Cells(1).Value.ToString() = "fsg" _
                     OrElse row.Cells(1).Value.ToString() = "proinfo" _
                     OrElse row.Cells(1).Value.ToString() = "nvdata" _
                     OrElse row.Cells(1).Value.ToString() = "nvram" _
                     OrElse row.Cells(1).Value.ToString() = "secro" _
                     OrElse row.Cells(1).Value.ToString() = "ProdNV" _
                     OrElse row.Cells(1).Value.ToString() = "Modem_W" _
                     OrElse row.Cells(1).Value.ToString() = "NV_W" _
                     OrElse row.Cells(1).Value.ToString() = "NV_WCN" _
                     OrElse row.Cells(1).Value.ToString() = "PrimaryGPT" _
                     OrElse row.Cells(1).Value.ToString() = "persist" _
                     OrElse row.Cells(1).Value.ToString() = "persistbak" _
                     OrElse row.Cells(1).Value.ToString() = "persistent" _
                     OrElse row.Cells(1).Value.ToString() = "oppodycnvbk" _
                     OrElse row.Cells(1).Value.ToString() = "oppostanvbk" _
                     OrElse row.Cells(1).Value.ToString() = "EFS" _
                     OrElse row.Cells(1).Value.ToString() = "config" _
                     Then
                        row.DefaultCellStyle.ForeColor = Color.Red
                    End If

                Next

            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub

    Public Shared Sub Open_ScatterTXT()
        Dim enumerator1 As IEnumerator = Nothing
        Dim directoryName As String = Path.GetDirectoryName(DirectISP.SharedUI.TxtScatterFile.Text)
        Dim str3 As String = String.Concat(directoryName, "\temp.xml")
        If File.Exists(str3) Then
            Computer.FileSystem.DeleteFile(str3)
        End If
        Lvi = New System.Windows.Forms.ListViewItem()
        Dim streamWriter As System.IO.StreamWriter = Computer.FileSystem.OpenTextFileWriter(str3, True)
        Dim strArrays As String() = File.ReadAllLines(DirectISP.SharedUI.TxtScatterFile.Text)
        streamWriter.WriteLine("<?xml version=""1.0"" ?>")
        streamWriter.WriteLine(" <data>")
        Dim strArrays1 As String() = strArrays
        Dim num As Integer = 0
        While num < CInt(strArrays1.Length)
            Dim str4 As String = strArrays1(num)
            If str4.Contains(chipa) Then
                Dim str5 As String = str4.Replace(chipa, "")
                str5.Replace(" ", "")
            End If
            If str4.Contains(tstor) Then
                Dim str6 As String = str4.Replace(tstor, "")
                If Not str6.Contains("EMMC") Then
                    If str6.Contains("UFS") Then
                    End If
                End If
            End If
            If str4.Contains(pi) Then
                Dim str7 As String = str4.Replace(pi, "")
                Dim str8 As String = str7.Replace(" ", "")
                streamWriter.Write(String.Concat("<program partindex=""", str8, """ "))
            End If
            If str4.Contains(pn) Then
                Dim str9 As String = str4.Replace(pn, "")
                Dim str10 As String = str9.Replace(" ", "")
                streamWriter.Write(String.Concat("label=""", str10, """ "))
            End If
            If str4.Contains(fn) Then
                Dim str11 As String = str4.Replace(fn, "")
                Dim str12 As String = str11.Replace(" ", "")
                streamWriter.Write(String.Concat("filename=""", str12, """ "))
            End If
            If str4.Contains(lin) Then
                Dim str13 As String = str4.Replace(lin, "")
                Dim str14 As String = str13.Replace(" ", "")
                streamWriter.Write(String.Concat("startsec=""", str14, """ "))
            End If
            If str4.Contains(ps) Then
                Dim str15 As String = str4.Replace(ps, "")
                Dim str16 As String = str15.Replace(" ", "")
                streamWriter.Write(String.Concat("Size=""", str16, """ />" & Environment.NewLine & ""))
            End If
            num += 1
        End While
        streamWriter.Write("</data>")
        streamWriter.Close()

        If Not Equals(DirectISP.SharedUI.TxtScatterFile.Text, "") Then
            Dim directoryName1 As String = Path.GetDirectoryName(DirectISP.SharedUI.TxtScatterFile.Text)
            Dim str17 As String = String.Concat(directoryName, "\temp.xml")
            If File.Exists(str17) Then
                Dim xmlReader1 As System.Xml.XmlReader = XmlReader.Create(str17)
                While xmlReader1.Read()
                    If xmlReader1.NodeType = XmlNodeType.Element AndAlso Equals(xmlReader1.Name, "program") Then
                        Lvi = New System.Windows.Forms.ListViewItem()
                        Lvi.SubItems.Add(xmlReader1.GetAttribute(1))
                        Dim str18 As String = xmlReader1.GetAttribute(4).Replace("0x", "")
                        Dim num1 As Long = Convert.ToInt64(str18, 16)
                        Lvi.SubItems.Add(Conversions.ToString(num1))
                        Dim str19 As String = xmlReader1.GetAttribute(3).Replace("0x", "")
                        Dim num2 As Long = Convert.ToInt64(str19, 16)
                        Lvi.SubItems.Add(Conversions.ToString(num2))
                        Lvi.SubItems.Add(String.Concat(directoryName1, "\", xmlReader1.GetAttribute(2)))
                        ListView1.Items.Add(Lvi)
                        Lvi.Checked = True
                    End If
                End While
                Try
                    enumerator1 = ListView1.Items.GetEnumerator()
                    While enumerator1.MoveNext()
                        Dim listViewItem As System.Windows.Forms.ListViewItem = DirectCast(enumerator1.Current, System.Windows.Forms.ListViewItem)
                        If listViewItem.SubItems(4).Text.Contains("NONE") Then
                            listViewItem.Remove()
                        ElseIf listViewItem.SubItems(1).Text.Contains("PRELOADER") Then
                            listViewItem.Remove()
                        ElseIf Not listViewItem.SubItems(1).Text.Contains("preloader") Then
                            Dim extension As String = ""
                            Dim str20 As String = ""
                            Dim directoryName2 As String = Path.GetDirectoryName(DirectISP.SharedUI.TxtScatterFile.Text)
                            Dim fileName As String = Path.GetFileName(listViewItem.SubItems(4).Text)
                            extension = Path.GetExtension(listViewItem.SubItems(4).Text)
                            str20 = If(Equals(extension, "") <> 0, fileName.Replace(extension, ""), fileName)
                            If File.Exists(String.Concat(New String() {directoryName2, "\", str20, "-sign", extension})) Then
                                listViewItem.Checked = True
                                listViewItem.SubItems(4).Text = String.Concat(New String() {directoryName2, "\", str20, "-sign", extension})
                            ElseIf Not File.Exists(listViewItem.SubItems(4).Text) Then
                                listViewItem.Checked = False
                            Else
                                listViewItem.Checked = True
                            End If
                        Else
                            listViewItem.Remove()
                        End If
                    End While

                    Dim lvItem() As String
                    Dim bool As Boolean = False
                    Dim location As String = ""
                    For i As Integer = 0 To ListView1.Items.Count - 1
                        If (File.Exists(ListView1.Items(i).SubItems(4).Text)) Then
                            bool = True
                            location = ListView1.Items(i).SubItems(4).Text
                        Else
                            bool = False
                            location = ""
                        End If
                        lvItem = {bool, ListView1.Items(i).SubItems(1).Text, "double click...", ListView1.Items(i).SubItems(2).Text, ListView1.Items(i).SubItems(3).Text, location}
                        DirectISP.SharedUI.DataView.Rows.Add(lvItem)
                    Next

                Finally
                    If (TypeOf enumerator1 Is IDisposable) Then
                        TryCast(enumerator1, IDisposable).Dispose()
                    End If
                End Try
            End If
        End If
    End Sub
    Public Shared Sub Read(e As DoWorkEventArgs)
        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Eject(USBEject(selecteddisk))
        Delay(1)
        Dim num As Integer = 1
        DirectISP.SharedUI.PB1(0)
        DirectISP.SharedUI.PB2(0)
        Try
            Using stringReader As New StringReader(TodoCommand)
                While stringReader.Peek() <> -1
                    Dim cmd As String = stringReader.ReadLine()
                    If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                        e.Cancel = True
                        Return
                    End If
                    If cmd <> String.Empty Then

                        Dim exec As String = Nothing
                        Dim arg As String() = cmd.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        ' 0 bool
                        ' 1 partition
                        ' 2 size bytes
                        ' 3 offset
                        ' 4 location

                        RichLogs("Reading ", Color.WhiteSmoke, True, False)
                        RichLogs(arg(1), Color.DarkOrchid, True, False)
                        RichLogs(" : ", Color.WhiteSmoke, True, False)
                        RichLogs("Start Sector => ", Color.Orange, True, False)
                        RichLogs(arg(2), Color.FromArgb(128, 128, 255), True, True)

                        Dim num1 As Integer = 1048576

                        If Conversions.ToLong(arg(2)) < 1048576 Then
                            num1 = Conversions.ToLong(arg(2))
                        End If

                        Console.WriteLine("Read selected partition " & arg(1) & " partition size : " & arg(2) & " Offsets : " & arg(3) & " Speed : " & num1)

                        Dim text As String = arg(3)
                        Dim str As String = arg(1)
                        str = str.Replace(" ", "")
                        If Conversions.ToDouble(arg(2)) <> 0 Then
                            psize = Conversions.ToLong(arg(2))
                        Else
                            psize = Conversions.ToLong(Operators.SubtractObject(uks, arg(3)))
                        End If
                        Dim num2 As Double = CDbl(psize) / CDbl(num1)
                        Dim _streamer As emmc.streamer = emmc.CreateStream(String.Concat("\\.\PHYSICALDRIVE", selecteddisk), FileAccess.ReadWrite)
                        Try
                            If File.Exists(folderdersave & "\" & Getfilenames(str)) Then
                                File.Delete(folderdersave & "\" & Getfilenames(str))
                                Delay(1)
                            End If
                            Dim fileStream As New System.IO.FileStream(folderdersave & "\" & Getfilenames(str), FileMode.Append, FileAccess.Write)
                            Try
                                Dim num3 As Long = CLng(0)
                                Dim Stopwatch As New Stopwatch()
                                Stopwatch.Start()
                                Using fileStream
                                    num2 = Int(num2)
                                    Dim num4 As Integer = num1
                                    Dim num5 As Long = CLng(Math.Round(num2))
                                    num3 = CLng(0)
                                    Do
                                        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                            e.Cancel = True
                                            Stopwatch.Stop()
                                            emmc.DropStream(_streamer)
                                            fileStream.Close()
                                            Return
                                        End If
                                        If CDbl(num3) = num2 Then
                                            num1 = CInt(Math.Round(CDbl(psize) - num2 * CDbl(num1)))
                                            If num1 = 0 Then
                                                Stopwatch.Stop()
                                                Exit Do
                                            End If
                                        End If
                                        Dim numArray As Byte() = emmc.ReadSector(CLng(Math.Round(Conversions.ToDouble(text) + CDbl(num3 * CLng(num4)))), num1, _streamer)
                                        fileStream.Write(numArray, 0, num1)
                                        Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(Conversions.ToLong(arg(2))), Action))
                                        Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(CDbl(num3 * CLng(num4))), Action))

                                        ' Menghitung Waktu yang telah berlalu
                                        Dim elapsed As TimeSpan = Stopwatch.Elapsed
                                        Dim speed As Double = num3 * CLng(num4) / elapsed.TotalSeconds
                                        If speed > 0 Then
                                            Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))
                                        End If

                                        If num2 <> 0 Then
                                            num8 = CDbl(num3 * CLng(num1) * CLng(100)) / CDbl(psize)
                                        Else
                                            num8 = 100
                                        End If
                                        DirectISP.SharedUI.PB1(CInt(Math.Round(Int(num8))))
                                        TaskbarManager.Instance().SetProgressValue(CInt(Math.Round(num8)), 100)
                                        TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                                        num3 += CLng(1)
                                    Loop While num3 <= num5
                                    Stopwatch.Stop()
                                End Using
                            Finally
                                fileStream.Close()
                                TaskbarManager.Instance().SetProgressValue(0, 100)
                                TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                            End Try
                        Finally
                            emmc.DropStream(_streamer)
                        End Try
                        Dim num6 As Integer = CInt(Math.Round(CDbl(num) / CDbl(Totaltodo) * 100))
                        DirectISP.SharedUI.PB2(num6)

                        num += 1
                    End If
                    If cekerror Then
                        RichLogs("Failed!", Color.Red, True, True)
                    Else
                        RichLogs("Done  ✓", Color.FromArgb(97, 197, 84), True, True)
                    End If
                End While
            End Using

        Catch exception As System.Exception
            Console.WriteLine(exception)
        End Try


    End Sub

    Public Shared Sub Readfull(e As DoWorkEventArgs)
        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Dim StrUSB As String = ""
        Main.SharedUI.comboUSB.Invoke(CType(Sub() StrUSB = Main.SharedUI.comboUSB.Text, Action))
        RichLogs("Dumping " & StrUSB & " ", Color.WhiteSmoke, False, True)
        Eject(USBEject(selecteddisk))
        Delay(1)
        Dim enumerator As IEnumerator = Nothing
        Dim StrUkrDmp As String = ""
        DirectISP.SharedUI.ComboBoxSizeDump.Invoke(CType(Sub() StrUkrDmp = DirectISP.SharedUI.ComboBoxSizeDump.Text, Action))
        If Equals(StrUkrDmp, "8 MB Size Dump") Then
            uks = 8388608
        ElseIf Equals(StrUkrDmp, "16 MB Size Dump") Then
            uks = 16777216
        ElseIf Equals(StrUkrDmp, "32 MB Size Dump") Then
            uks = 33554432
        ElseIf Equals(StrUkrDmp, "64 MB Size Dump") Then
            uks = 67108864
        ElseIf Equals(StrUkrDmp, "128 MB Size Dump") Then
            uks = 134217728
        ElseIf Equals(StrUkrDmp, "256mb") Then
            uks = 268435456
        ElseIf Equals(StrUkrDmp, "512 MB Size Dump") Then
            uks = 536870912
        ElseIf Equals(StrUkrDmp, "1 GB Size Dump") Then
            uks = 1073741824
        ElseIf Equals(StrUkrDmp, "2 GB Size Dump") Then
            uks = -2147483648
        ElseIf Equals(StrUkrDmp, "4 GB Size Dump") Then
            uks = 4294967296L
        ElseIf Equals(StrUkrDmp, "Auto Size Dump") Then
            uks = RuntimeHelpers.GetObjectValue(uks)
        ElseIf Equals(StrUkrDmp, "Without Userdata Dump") Then
            If ListView1.Items.Count <> 0 Then
                Try
                    enumerator = ListView1.Items.GetEnumerator()
                    While enumerator.MoveNext()
                        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                            e.Cancel = True
                            Return
                        End If
                        Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                        If Equals(current.SubItems(1).Text, "userdata") Then
                            uks = current.SubItems(3).Text
                        ElseIf Equals(current.SubItems(1).Text, "usrdata") Then
                            uks = current.SubItems(3).Text
                        ElseIf Equals(current.SubItems(1).Text, "data") Then
                            uks = current.SubItems(3).Text
                        End If
                    End While
                Finally
                    If (TypeOf enumerator Is IDisposable) Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
            End If
        End If

        RichLogs("Reading ", Color.WhiteSmoke, True, False)
        RichLogs("DUMP : ", Color.DarkOrchid, True, False)
        RichLogs("Start Sector => ", Color.Orange, True, False)
        RichLogs(uks & " : ", Color.FromArgb(128, 128, 255), True, False)
        Try
            Dim _streamer As emmc.streamer = emmc.CreateStream(String.Concat("\\.\PHYSICALDRIVE", selecteddisk), FileAccess.ReadWrite)
            Try
                Try
                    If File.Exists(folderdersave & "\" & StrUSB.Replace(" ", "_") & "dump.bin") Then
                        File.Delete(folderdersave & "\" & StrUSB.Replace(" ", "_") & "dump.bin")
                    End If
                    Dim [integer] As Integer = 1048576 * 8
                    Dim objectValue As Object = Operators.DivideObject(uks, [integer])
                    Dim fileStream As New System.IO.FileStream(folderdersave & "\" & StrUSB.Replace(" ", "_") & "dump.bin", FileMode.Append, FileAccess.Write)
                    Try
                        Try
                            Dim num As Long = CLng(0)
                            Using fileStream
                                objectValue = RuntimeHelpers.GetObjectValue(Int(RuntimeHelpers.GetObjectValue(objectValue)))
                                Dim num1 As Long = Conversions.ToLong(objectValue)
                                num = CLng(0)
                                Dim Stopwatch As New Stopwatch()
                                Stopwatch.Start()
                                While num <= num1
                                    If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                        e.Cancel = True
                                        Stopwatch.Stop()
                                        emmc.DropStream(_streamer)
                                        fileStream.Close()
                                        Return
                                    End If
                                    If Operators.ConditionalCompareObjectEqual(num, objectValue, False) Then
                                        [integer] = Conversions.ToInteger(Operators.SubtractObject(uks, Operators.MultiplyObject(objectValue, [integer])))
                                    End If
                                    If [integer] <> 0 Then
                                        Dim numArray As Byte() = emmc.ReadSector(num * CLng([integer]), [integer], _streamer)
                                        fileStream.Write(numArray, 0, [integer])
                                        karung = num * CLng([integer])
                                        num8 = Conversions.ToDouble(Operators.DivideObject(num * CLng([integer]) * CLng(100), uks))
                                        Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(Conversions.ToLong(uks)), Action))
                                        Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(CDbl(num * CLng([integer]))), Action))
                                        ' Menghitung Waktu yang telah berlalu
                                        Dim elapsed As TimeSpan = Stopwatch.Elapsed
                                        Dim speed As Double = CDbl(num * CLng([integer])) / elapsed.TotalSeconds
                                        If speed > 0 Then
                                            Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))
                                        End If
                                        DirectISP.SharedUI.PB1(CInt(Math.Round(num8)))
                                        TaskbarManager.Instance().SetProgressValue(CInt(Math.Round(num8)), 100)
                                        TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                                        num += CLng(1)
                                    Else
                                        Stopwatch.Stop()
                                        Exit While
                                    End If
                                End While
                                Stopwatch.Stop()
                            End Using
                        Catch exception As System.Exception
                            ProjectData.SetProjectError(exception)
                            DirectISP.SharedUI.Logs1("   Error at " & Conversions.ToString(karung))
                            ProjectData.ClearProjectError()
                        End Try
                    Finally
                        fileStream.Close()
                        DirectISP.SharedUI.PB1(100)
                        TaskbarManager.Instance().SetProgressValue(0, 100)
                        TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                    End Try
                Catch exception1 As System.Exception
                    ProjectData.SetProjectError(exception1)
                    ProjectData.ClearProjectError()
                End Try
            Finally
                emmc.DropStream(_streamer)
            End Try
        Catch exception2 As System.Exception
            ProjectData.SetProjectError(exception2)
            ProjectData.ClearProjectError()
        End Try

        If cekerror Then
            RichLogs("Failed!", Color.Red, True, True)
        Else
            RichLogs("Done  ✓", Color.FromArgb(97, 197, 84), True, True)
        End If
    End Sub

    Public Shared Sub Writedump(e As DoWorkEventArgs)
        Eject(USBEject(selecteddisk))
        Delay(1)
        Dim num As Double
        Dim enumerator As IEnumerator = Nothing
        Dim num1 As Long = filesize
        Dim num2 As Long = filesize
        Dim length As Long = New FileInfo(openfile).Length

        Dim StrUkrDmp As String = ""
        DirectISP.SharedUI.ComboBoxSizeDump.Invoke(CType(Sub() StrUkrDmp = DirectISP.SharedUI.ComboBoxSizeDump.Text, Action))

        If Equals(StrUkrDmp, "8 MB Size Dump") Then
            If length < CLng(8388608) Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(8388608)
            End If
        ElseIf Equals(StrUkrDmp, "16 MB Size Dump") Then
            If length < CLng(16777216) Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(16777216)
            End If
        ElseIf Equals(StrUkrDmp, "32 MB Size Dump") Then
            If length < CLng(33554432) Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(33554432)
            End If
        ElseIf Equals(StrUkrDmp, "64 MB Size Dump") Then
            If length < CLng(67108864) Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(67108864)
            End If
        ElseIf Equals(StrUkrDmp, "128 MB Size Dump") Then
            If length < CLng(134217728) Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(134217728)
            End If
        ElseIf Equals(StrUkrDmp, "256mb") Then
            If length < CLng(268435456) Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(268435456)
            End If
        ElseIf Equals(StrUkrDmp, "512 MB Size Dump") Then
            If length < CLng(536870912) Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(536870912)
            End If
        ElseIf Equals(StrUkrDmp, "1 GB Size Dump") Then
            If length < CLng(1073741824) Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(1073741824)
            End If
        ElseIf Equals(StrUkrDmp, "2 GB Size Dump") Then
            If length < -2147483648 Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(-2147483648)
            End If
        ElseIf Equals(StrUkrDmp, "4 GB Size Dump") Then
            If length < 4294967296L Then
                MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = 4294967296L
            End If
        ElseIf Equals(StrUkrDmp, "Auto Size Dump") Then
            If Equals(StrUkrDmp, "Without Userdata Dump") Then
                If ListView1.Items.Count <> 0 Then
                    Try
                        enumerator = ListView1.Items.GetEnumerator()
                        While enumerator.MoveNext()
                            Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                            If Equals(current.SubItems(1).Text, "userdata") Then
                                If CDbl(length) < Conversions.ToDouble(current.SubItems(3).Text) Then
                                    MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
                                Else
                                    length = Conversions.ToLong(current.SubItems(3).Text)
                                End If
                                Console.WriteLine(length)
                            ElseIf Equals(current.SubItems(1).Text, "usrdata") Then
                                If CDbl(length) < Conversions.ToDouble(current.SubItems(3).Text) Then
                                    MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
                                Else
                                    length = Conversions.ToLong(current.SubItems(3).Text)
                                End If
                            ElseIf Equals(current.SubItems(1).Text, "data") Then
                                If CDbl(length) < Conversions.ToDouble(current.SubItems(3).Text) Then
                                    MsgBox("file size is smaller than file size in seting to writen" & Environment.NewLine & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
                                Else
                                    length = Conversions.ToLong(current.SubItems(3).Text)
                                End If
                            End If
                        End While
                    Finally
                        If (TypeOf enumerator Is IDisposable) Then
                            TryCast(enumerator, IDisposable).Dispose()
                        End If
                    End Try
                End If
            End If
        End If
        Dim num3 As Long = CLng(1048576)
        Dim num4 As Integer = CInt(Math.Round(CDbl(num2) / CDbl(num3)))
        Dim num5 As Long = CLng(0)

        RichLogs("Writing ", Color.WhiteSmoke, True, False)
        RichLogs("DUMP" & " : ", Color.DarkOrchid, True, False)
        RichLogs("Start Sector => ", Color.Orange, True, False)
        RichLogs(length & " : ", Color.FromArgb(128, 128, 255), True, False)

        Dim fileStream As New System.IO.FileStream(openfile, FileMode.Open, FileAccess.Read)
        Try
            Try
                Dim i As Long = CLng(0)
                Using fileStream
                    num4 = CInt(Math.Round(CDbl(length) / CDbl(num3)))
                    num4 = Int(num4)
                    Dim num6 As Long = CLng(num4)
                    Dim Stopwatch As New Stopwatch()
                    Stopwatch.Start()
                    For i = CLng(0) To num6 Step CLng(1)
                        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                            e.Cancel = True
                            Stopwatch.Stop()
                            fileStream.Close()
                            Return
                        End If
                        If i = CLng(num4) Then
                            num3 = length - CLng(num4) * num3
                            If num3 = CLng(0) Then
                                Stopwatch.Stop()
                                Exit For
                            End If
                        End If
                        offset = i * num3
                        karung = offset
                        Dim numArray(CInt(num3 - CLng(1)) + 1 - 1) As Byte
                        fileStream.Read(numArray, 0, CInt(num3))
                        Ekse(offset, num3, numArray)
                        'Main.SharedUI.lb5("Writing")
                        num = If(num4 <> 0, CDbl(i * num3 * CLng(100)) / CDbl(length), 100)
                        DirectISP.SharedUI.PB1(CInt(Math.Round(num)))

                        Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(filesize), Action))
                        Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(CDbl(num3 * i)), Action))

                        ' Menghitung Waktu yang telah berlalu
                        Dim elapsed As TimeSpan = Stopwatch.Elapsed
                        Dim speed As Double = num3 * i / elapsed.TotalSeconds
                        If speed > 0 Then
                            Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))
                        End If

                        TaskbarManager.Instance().SetProgressValue(CInt(Math.Round(num)), 100)
                        TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                        fileStream.Flush()
                    Next
                    Stopwatch.Stop()
                End Using
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                ProjectData.ClearProjectError()
            End Try
        Finally
            fileStream.Close()
        End Try
        If cekerror Then
            RichLogs("Failed!", Color.Red, True, True)
        Else
            RichLogs("Done  ✓", Color.FromArgb(97, 197, 84), True, True)
        End If
    End Sub

    Public Shared Sub Writeselected(e As DoWorkEventArgs)
        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Eject(USBEject(selecteddisk))
        Delay(1)
        Dim num As Integer = 0
        DirectISP.SharedUI.PB2(0)
        Using stringReader As New StringReader(TodoCommand)
            While stringReader.Peek() <> -1
                Dim cmd As String = stringReader.ReadLine()

                If cmd <> String.Empty Then
                    If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                        e.Cancel = True
                        Return
                    End If
                    Dim exec As String = Nothing
                    Dim arg As String() = cmd.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    ' 0 bool
                    ' 1 partition
                    ' 2 size bytes
                    ' 3 offset
                    ' 4 location

                    If Not arg(4) = "none" AndAlso File.Exists(arg(4)) Then
                        Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(arg(2)), Action))
                        cekerror = False
                        RichLogs("Writing ", Color.WhiteSmoke, True, False)
                        RichLogs(arg(1) & " : ", Color.DarkOrchid, True, False)
                        RichLogs("Start Sector => ", Color.Orange, True, False)
                        RichLogs(arg(2) & " : ", Color.FromArgb(128, 128, 255), True, False)

                        DirectISP.SharedUI.Logs2Clear()
                        ListBox1.Items.Clear()
                        ListBox2.Items.Clear()
                        ListView2.Clear()
                        ListView2.Items.Clear()
                        partname = arg(1)
                        sentot = arg(3)
                        Dim process As New System.Diagnostics.Process()
                        Dim startInfo As ProcessStartInfo = process.StartInfo
                        startInfo.FileName = "Tools\process\file\checksparse.exe"
                        startInfo.Arguments = String.Concat("""", arg(4), """")
                        startInfo.UseShellExecute = False
                        startInfo.CreateNoWindow = True
                        startInfo.RedirectStandardInput = True
                        startInfo.RedirectStandardOutput = True
                        startInfo.RedirectStandardError = True
                        startInfo.StandardOutputEncoding = Encoding.ASCII
                        startInfo = Nothing
                        process.Start()
                        Dim standardOutput As System.IO.StreamReader = process.StandardOutput
                        While Not process.StandardOutput.EndOfStream
                            If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                e.Cancel = True
                                Return
                            End If
                            Dim str As String = standardOutput.ReadLine()
                            TxtBabble(String.Concat(str, "" & Environment.NewLine & ""))
                        End While
                        process.Dispose()

                        Dim textBox As New TextBox
                        Main.SharedUI.RichTextBoxOutput.Invoke(CType(Sub() textBox.Text = Main.SharedUI.RichTextBoxOutput.Text, Action))

                        ListBox1.Items.Add("0")
                        If textBox.Text.Contains("notsparse") Then
                            openfile = arg(4)
                            Dim fileInfo As New System.IO.FileInfo(openfile)
                            filesize = Conversions.ToLong(arg(2))
                            awales = Conversions.ToLong(arg(3))
                            partname = arg(1)
                            asu = "notsparse"
                            Dim fileInfo1 As New System.IO.FileInfo(arg(4))
                            If CDbl(fileInfo1.Length) <= Conversions.ToDouble(arg(2)) Then


                                If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                                    Application.DoEvents()

                                    If arg(1).Contains("PrimaryGPT") Then
                                        RichLogs("Applying GPT ", Color.FromArgb(97, 197, 84), True, False)

                                        Delay(1)
                                        If File.Exists(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin") Then
                                            File.Delete(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin")
                                        End If

                                        Delay(1)
                                        If File.Exists(Path.GetDirectoryName(arg(4)) & "/gpt_main0.bak___.bin") Then
                                            File.Delete(Path.GetDirectoryName(arg(4)) & "/gpt_main0.bak___.bin")
                                        End If

                                        Delay(1)
                                        File.Copy(arg(4), Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin")

                                        Delay(1)
                                        ' Reset Checksum CRC32 Sector 1
                                        CRC32.ReplaceHexInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", &H210, "00 00 00 00")

                                        Delay(1)
                                        ' Add First Usable LBA
                                        CRC32.ReplaceHexInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", &H220, CRC32.ReverseStrings(CRC32.First_usable_LBA.ToString("X8")))

                                        Delay(1)
                                        ' Add Last Usable LBA
                                        CRC32.ReplaceHexInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", &H230, CRC32.ReverseStrings(CRC32.Last_usable_LBA.ToString("X8")))

                                        Delay(1)
                                        ' Count Sector 2 Size
                                        CRC32.Offsets_Sector2 = (CRC32.GetHexInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", &H250, 4) _
                                                               * CRC32.GetHexInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", &H254, 4) + 1024 - 1)

                                        Delay(1)
                                        ' Find Userdata Offset
                                        CRC32.Offsets_Userdata = CRC32.FindOffsetInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", "75 00 73 00 65 00 72 00 64 00 61 00 74 00 61")

                                        Delay(1)
                                        ' Fix Userdata Last Usable LBA
                                        CRC32.ReplaceHexInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", CRC32.Offsets_Userdata - 16, CRC32.ReverseStrings(CRC32.Last_usable_LBA.ToString("X8")))

                                        Delay(1)
                                        ' Checksum CRC32 Sector 2
                                        CRC32.CRC32_Sector2 = CRC32.CalculateCRC32(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", 1024, CRC32.Offsets_Sector2)

                                        Delay(1)
                                        ' Update CRC32 Sector 2 From Sector 1
                                        CRC32.ReplaceHexInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", &H258, CRC32.CRC32_Sector2)

                                        Delay(1)
                                        ' Count Sector 1 Size
                                        CRC32.Offsets_Sector1 = (CRC32.GetHexInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", &H20C, 4) + 512 - 1)

                                        Delay(1)
                                        ' Checksum CRC32 Sector 1
                                        CRC32.CRC32_Sector1 = CRC32.CalculateCRC32(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", 512, CRC32.Offsets_Sector1)

                                        Delay(1)
                                        ' Update CRC32 Sector 1 From Sector 1
                                        CRC32.ReplaceHexInFile(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", &H210, CRC32.CRC32_Sector1)

                                        Delay(1)
                                        File.Move(arg(4), Path.GetDirectoryName(arg(4)) & "/gpt_main0.bak___.bin")

                                        Delay(1)
                                        File.Move(Path.GetDirectoryName(arg(4)) & "/temp.main_gpt.bin", arg(4))

                                    End If

                                    DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                                    waitEvent.WaitOne()
                                    Thread.Sleep(300)
                                End If
                            Else
                                If MessageBox.Show(String.Concat(New String() {"file Size ", fileInfo1.Name, " is bigger than partition size of ", arg(1), "" & Environment.NewLine & "if yes, not all sector will be writen" & Environment.NewLine & "if no ,file will skiping"}), "Warning", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                                    RichLogs("skiping " & fileInfo1.Name, Color.FromArgb(97, 197, 84), True, False)
                                Else


                                    If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                                        Application.DoEvents()
                                        DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                                        waitEvent.WaitOne()
                                        Thread.Sleep(300)
                                    End If
                                End If
                            End If
                        End If
                        If textBox.Text.Contains("inisparse") Then
                            Dim richTextBox22 As System.Windows.Forms.RichTextBox = Main.SharedUI.RichTextBoxOutput
                            asu = "inisparse"
                            If textBox.Text.Contains("total") Then
                                Dim lines As String() = textBox.Lines
                                Dim num1 As Integer = 0
                                While num1 < CInt(lines.Length)
                                    If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                        e.Cancel = True
                                        Return
                                    End If
                                    Dim str1 As String = lines(num1)
                                    If str1.Contains("total") Then
                                        str1 = Regex.Replace(str1, "total chunk =", "")
                                        str1 = Regex.Replace(str1, "sparse", "")
                                        totalchunk = str1
                                    End If
                                    num1 += 1
                                End While
                            End If
                            Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = "Parsing *IMG", Action))
                            Dim process1 As New System.Diagnostics.Process()
                            Dim aSCII As ProcessStartInfo = process1.StartInfo
                            aSCII.FileName = "Tools\process\file\simg2imgv2.exe"
                            aSCII.Arguments = String.Concat("""", arg(4), """")
                            aSCII.UseShellExecute = False
                            aSCII.CreateNoWindow = True
                            aSCII.RedirectStandardInput = True
                            aSCII.RedirectStandardOutput = True
                            aSCII.RedirectStandardError = True
                            aSCII.StandardOutputEncoding = Encoding.ASCII
                            aSCII = Nothing
                            process1.Start()
                            Dim streamReader As System.IO.StreamReader = process1.StandardOutput
                            While Not process1.StandardOutput.EndOfStream
                                If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                    e.Cancel = True
                                    Return
                                End If
                                Dim str2 As String = streamReader.ReadLine()
                                TxtBabble(String.Concat(str2, "" & Environment.NewLine & ""))
                            End While
                            process1.Dispose()
                            Dim TxtRawDump As New TextBox()
                            Main.SharedUI.RichTextBoxOutput.Invoke(CType(Sub() TxtRawDump.Text = Main.SharedUI.RichTextBoxOutput.Text, Action))
                            openfile = "unsparse.img"
                            filesize = New System.IO.FileInfo(openfile).Length
                            Dim fileInfo2 As New System.IO.FileInfo("unsparse.img")
                            If CDbl(fileInfo2.Length) <= Conversions.ToDouble(arg(2)) Then
                                If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                                    Application.DoEvents()
                                    DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                                    waitEvent.WaitOne()
                                    Thread.Sleep(300)
                                End If
                            ElseIf MessageBox.Show(String.Concat(New String() {"file Size ", fileInfo2.Name, " is bigger than partition size of ", arg(1), "" & Environment.NewLine & "if yes, not all sector will be writen" & Environment.NewLine & "if no ,file will skiping"}), "Warning", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                                RichLogs("skiping " & arg(1), Color.FromArgb(97, 197, 84), True, False)
                            Else


                                If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                                    Application.DoEvents()
                                    DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                                    waitEvent.WaitOne()
                                    Thread.Sleep(300)
                                End If
                            End If
                            Dim files As String() = Directory.GetFiles(CurDir(), "*", SearchOption.AllDirectories)
                            Dim num2 As Integer = 0
                            While num2 < CInt(files.Length)
                                If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                    e.Cancel = True
                                    Return
                                End If
                                Dim str3 As String = files(num2)
                                If str3.Contains("unsparse.img") Then
                                    Computer.FileSystem.DeleteFile(str3)
                                End If
                                num2 += 1
                            End While
                        End If
                        num += 1
                        DirectISP.SharedUI.PB2(CInt(Math.Round(CDbl(num * 100) / CDbl(Totaltodo))))
                    Else
                        If String.IsNullOrEmpty(DirectISP.SharedUI.TxtRawDump.Text) Then
                            RichLogs("Writing ", Color.WhiteSmoke, True, False)
                            RichLogs(arg(1) & " : ", Color.DarkOrchid, True, False)
                            RichLogs("Start Sector => ", Color.Orange, True, False)
                            RichLogs(arg(2) & " : ", Color.FromArgb(128, 128, 255), True, False)
                            RichLogs("skiping : ", Color.FromArgb(97, 197, 84), True, False)
                            RichLogs("File doesn't exist!", Color.Red, True, True)
                        Else

                            cekerror = False
                            Console.WriteLine("Writing from dump " & arg(1))
                            RichLogs("Writing ", Color.WhiteSmoke, True, False)
                            RichLogs(arg(1) & " : ", Color.DarkOrchid, True, False)
                            RichLogs("Start Sector => ", Color.Orange, True, False)
                            RichLogs(arg(2) & " : ", Color.FromArgb(128, 128, 255), True, False)

                            m = "p"
                            Dim length As Long = New FileInfo(openfile).Length
                            poffsets = Conversions.ToLong(arg(3))
                            psize = Conversions.ToLong(arg(2))
                            pname = arg(1)
                            If CDbl(length) >= Conversions.ToDouble(arg(3)) Then


                                If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                                    Application.DoEvents()
                                    DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                                    Application.DoEvents()
                                End If
                                waitEvent.WaitOne()
                                Thread.Sleep(300)
                                DirectISP.SharedUI.PB2(CInt(Math.Round(CDbl(num * 100) / CDbl(Totaltodo))))
                                num += 1
                            End If
                            m = "wp"
                        End If
                    End If
                    If arg(1).Contains("PrimaryGPT") Then
                        Delay(10)
                        File.Delete(arg(4))
                        Delay(1)
                        File.Move(Path.GetDirectoryName(arg(4)) & "/gpt_main0.bak___.bin", arg(4))
                    End If
                End If
                If cekerror Then
                    RichLogs("Failed!", Color.Red, True, True)
                Else
                    RichLogs("Done  ✓", Color.FromArgb(97, 197, 84), True, True)
                End If
            End While
        End Using
    End Sub

    Public Shared Sub Ekse(ByVal offset As Long, ByVal count As Long, ByVal buffer As Byte())
        Dim _streamer As emmc.streamer = emmc.CreateStream(String.Concat("\\.\PHYSICALDRIVE", selecteddisk), FileAccess.ReadWrite)
        Try
            Try
                emmc.WriteSector(offset, CInt(count), buffer, _streamer)
            Catch exception As System.Exception
                Console.WriteLine(exception.ToString())
                cekerror = True
            End Try
        Finally
            emmc.DropStream(_streamer)
        End Try
    End Sub

    Public Shared Sub Erases(e As DoWorkEventArgs)
        If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Eject(USBEject(selecteddisk))
        Delay(1)
        Dim num As Integer = 0
        DirectISP.SharedUI.PB2(0)
        Using stringReader As New StringReader(TodoCommand)
            While stringReader.Peek() <> -1
                Dim cmd As String = stringReader.ReadLine()
                If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                    e.Cancel = True
                    Return
                End If
                If cmd <> String.Empty Then
                    cekerror = False

                    Dim arg As String() = cmd.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    ' 0 bool
                    ' 1 partition
                    ' 2 size bytes
                    ' 3 offset
                    ' 4 location

                    RichLogs("Erasing ", Color.WhiteSmoke, True, False)
                    RichLogs(arg(1) & " : ", Color.DarkOrchid, True, False)
                    RichLogs("Start Sector => ", Color.Orange, True, False)
                    RichLogs(arg(2) & " : ", Color.FromArgb(128, 128, 255), True, False)


                    poffsets = Conversions.ToLong(arg(3))
                    If Conversions.ToDouble(arg(2)) <> 0 Then
                        psize = Conversions.ToLong(arg(2))
                    Else
                        psize = Conversions.ToLong(Operators.SubtractObject(uks, arg(3)))
                    End If
                    pname = arg(1)


                    If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                        Application.DoEvents()
                        DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                        waitEvent.WaitOne()
                        Thread.Sleep(300)
                    End If

                    num += 1
                    Dim num1 As Double = CDbl(num * 100) / CDbl(Totaltodo)
                    DirectISP.SharedUI.PB2(CInt(Math.Round(num1)))
                End If
                If cekerror Then
                    RichLogs("Failed!", Color.Red, True, True)
                Else
                    RichLogs("Done  ✓", Color.FromArgb(97, 197, 84), True, True)
                End If
            End While
        End Using
        DirectISP.SharedUI.PB1(100)
        DirectISP.SharedUI.PB2(100)
    End Sub


    Public Shared Sub EMMCISPWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Delay(3)

        If SelectedCommand = "Refresh_Disk" Then
            Refresh_Disk(e)
        ElseIf SelectedCommand = "Scan_Partition" Then
            Scan_Partition(e)
        ElseIf SelectedCommand = "Scan_Dump" Then
            Scan_Dump(e)
        ElseIf SelectedCommand = "read" Then
            Read(e)
        ElseIf SelectedCommand = "writeselected" Then
            Writeselected(e)
        ElseIf SelectedCommand = "erases" Then
            Erases(e)
        ElseIf SelectedCommand = "readfull" Then
            Readfull(e)
        ElseIf SelectedCommand = "writedump" Then
            Writedump(e)
        ElseIf SelectedCommand = "identify" Then
            Identity(e)
        End If

    End Sub

    Public Shared Sub EMMCISPWorker_RunWorkerComplete(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        AllDone()
        SelectedCommand = ""
    End Sub

    Public Shared Sub DirectISPWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Console.WriteLine("DoWork Start....")
        Dim num As Double
        Dim num1 As Long = filesize
        Dim num2 As Long = filesize
        Dim length As Long = (New FileInfo(openfile)).Length
        Dim num3 As Long = CLng(1048576)
        Dim num4 As Integer = CInt(Math.Round(CDbl(num2) / CDbl(num3)))
        Dim num5 As Long = CLng(0)
        Dim fileStream As New System.IO.FileStream(openfile, FileMode.Open, FileAccess.Read)
        Try
            Try
                Dim i As Long = CLng(0)
                Using fileStream
                    If (Operators.CompareString(m, "saveformat", False) = 0) Then
                        num3 = length
                        Dim numArray(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                        fileStream.Read(numArray, 0, CInt(num3))
                        Ekse(miscpart, num3, numArray)
                    End If
                    If (Operators.CompareString(m, "frp", False) = 0) Then
                        num3 = dawane
                        Dim numArray1(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                        Ekse(configpart, num3, numArray1)
                    End If
                    If (Operators.CompareString(m, "micloudmtk1", False) = 0) Then
                        num3 = dawane
                        Dim numArray2(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                        Ekse(configpart, num3, numArray2)
                    End If
                    If (Operators.CompareString(m, "micloudmtk2", False) = 0) Then
                        num3 = dawane
                        Dim numArray3(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                        Ekse(configpart, num3, numArray3)
                    End If
                    If (Operators.CompareString(m, "factreset", False) = 0) Then
                        Dim num6 As Double = CDbl(length) / CDbl(num3)
                        num6 = Int(num6)
                        Dim num7 As Long = CLng(Math.Round(num6))
                        For i = CLng(0) To num7 Step CLng(1)
                            If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                e.Cancel = True
                                Exit For
                            Else
                                If (CDbl(i) = num6) Then
                                    num3 = CLng(Math.Round(CDbl(length) - num6 * CDbl(num3)))
                                    If (num3 = CLng(0)) Then
                                        Exit For
                                    End If
                                End If
                            End If
                            Dim numArray4(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                            Dim num8 As Long = i * num3
                            Dim num9 As Long = startsecpart + num8
                            karung = num9
                            fileStream.Read(numArray4, 0, CInt(num3))
                            'Label5.Text = "writing userdata"
                            Ekse(num9, num3, numArray4)
                            num = If(num6 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(length), 100)
                            DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                            fileStream.Flush()
                        Next

                    End If
                    If (Operators.CompareString(m, "p", False) = 0) Then
                        num3 = CLng(1048576)
                        Dim num10 As Double = CDbl(psize) / CDbl(num3)
                        num10 = Int(num10)
                        fileStream.Position = poffsets
                        'RichLogs("writing... " & pname, Color.WhiteSmoke, False, False)
                        Dim num11 As Long = CLng(Math.Round(num10))
                        Dim Stopwatch As New Stopwatch()
                        Stopwatch.Start()
                        For i = CLng(0) To num11 Step CLng(1)
                            If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                Stopwatch.Stop()
                                e.Cancel = True
                                Exit For
                            Else
                                If (CDbl(i) = num10) Then
                                    num3 = CLng(Math.Round(CDbl(psize) - num10 * CDbl(num3)))
                                    If (num3 = CLng(0)) Then
                                        Stopwatch.Stop()
                                        Exit For
                                    End If
                                End If
                            End If
                            Dim numArray5(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                            Dim num12 As Long = i * num3
                            Dim num13 As Long = poffsets + num12
                            karung = num13
                            fileStream.Read(numArray5, 0, CInt(num3))
                            Ekse(num13, num3, numArray5)
                            'nLabel5.Text = String.Concat("Writing ", pname)
                            If (num10 <> 0) Then
                                num = If(num10 <> 1, CDbl((i * num3 * CLng(100))) / CDbl(psize), 100)
                            Else
                                num = 100
                            End If

                            Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(psize), Action))
                            Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(CDbl(num3 * i)), Action))

                            ' Menghitung Waktu yang telah berlalu
                            Dim elapsed As TimeSpan = Stopwatch.Elapsed
                            Dim speed As Double = num3 * i / elapsed.TotalSeconds
                            If speed > 0 Then
                                Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))
                            End If
                            DirectISP.SharedUI.PB1(CInt(Math.Round(num)))
                            DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                            fileStream.Flush()
                        Next
                        Stopwatch.Stop()
                    End If
                    If (Operators.CompareString(m, "f", False) = 0) Then
                        num4 = CInt(Math.Round(CDbl(length) / CDbl(num3)))
                        num4 = Int(num4)
                        Dim num14 As Long = CLng(num4)
                        Dim Stopwatch As New Stopwatch()
                        Stopwatch.Start()
                        For i = CLng(0) To num14 Step CLng(1)
                            If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                Stopwatch.Stop()
                                e.Cancel = True
                                Exit For
                            Else
                                If (i = CLng(num4)) Then
                                    num3 = length - CLng(num4) * num3
                                    If (num3 = CLng(0)) Then
                                        Stopwatch.Stop()
                                        Exit For
                                    End If
                                End If
                            End If
                            offset = i * num3
                            karung = offset
                            Dim numArray6(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                            fileStream.Read(numArray6, 0, CInt(num3))
                            Ekse(offset, num3, numArray6)
                            num = If(num4 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(length), 100)

                            DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                            Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(psize), Action))
                            Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(CDbl(num3 * i)), Action))

                            ' Menghitung Waktu yang telah berlalu
                            Dim elapsed As TimeSpan = Stopwatch.Elapsed
                            Dim speed As Double = num3 * i / elapsed.TotalSeconds
                            If speed > 0 Then
                                Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))
                            End If
                            fileStream.Flush()
                        Next
                        Stopwatch.Stop()
                    End If
                    If (Operators.CompareString(m, "erase", False) = 0) Then
                        num3 = CLng(1048576)
                        Dim num15 As Double = CDbl(psize) / CDbl(num3)
                        num15 = Int(num15)
                        Dim num16 As Long = CLng(Math.Round(num15))
                        i = CLng(0)

                        ' Membuat objek Stopwatch untuk mengukur waktu
                        Dim Stopwatch As New Stopwatch()
                        Stopwatch.Start()

                        While i <= num16
                            If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                Stopwatch.Stop()
                                e.Cancel = True
                                Exit While
                            Else
                                If (CDbl(i) = num15) Then
                                    num3 = CLng(Math.Round(CDbl(psize) - num15 * CDbl(num3)))
                                End If
                                If (num3 <> CLng(0)) Then
                                    Dim numArray7(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                                    berapakali = i * num3
                                    Dim num17 As Long = poffsets + berapakali
                                    'Label5.Text = String.Concat("erasing ", pname)
                                    Ekse(num17, num3, numArray7)
                                    num = If(num15 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(psize), 100)
                                    DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                                    i += CLng(1)
                                    Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(psize), Action))
                                    Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(CDbl(num3 * i)), Action))

                                    ' Menghitung Waktu yang telah berlalu
                                    Dim elapsed As TimeSpan = Stopwatch.Elapsed
                                    Dim speed As Double = num3 * i / elapsed.TotalSeconds
                                    If speed > 0 Then
                                        Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))
                                    End If
                                    DirectISP.SharedUI.PB1(CInt(Math.Round(num)))
                                    TaskbarManager.Instance().SetProgressValue(CInt(Math.Round(num)), 100)
                                    TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                                Else
                                    Stopwatch.Stop()
                                    Exit While
                                End If
                            End If
                        End While
                        Stopwatch.Stop()
                    End If
                    If (Operators.CompareString(m, "wp", False) = 0) Then
                        If (Operators.CompareString(asu, "inisparse", False) = 0) Then

                            'RichLogs("Writing ", Color.WhiteSmoke, True, False)
                            'RichLogs(partname & " : ", Color.DarkOrchid, True, False)
                            'RichLogs("Start Sector => ", Color.Orange, True, False)
                            'RichLogs(filesize & " : ", Color.FromArgb(128, 128, 255), True, False)

                            Dim num18 As Long = Conversions.ToLong(sentot)
                            Dim num19 As Double = CDbl(filesize) / CDbl(num3)
                            num19 = Int(num19)
                            Dim num20 As Long = CLng(Math.Round(num19))
                            Dim Stopwatch As New Stopwatch()
                            Stopwatch.Start()
                            For i = CLng(0) To num20 Step CLng(1)
                                If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                    Stopwatch.Stop()
                                    e.Cancel = True
                                    Exit For
                                Else
                                    If (CDbl(i) = num19) Then
                                        num3 = CLng(Math.Round(CDbl(filesize) - num19 * CDbl(num3)))
                                        If (num3 = CLng(0)) Then
                                            Stopwatch.Stop()
                                            Exit For
                                        End If
                                    End If
                                End If
                                Dim numArray8(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                                Dim num21 As Long = i * num3 + num18
                                karung = num21
                                fileStream.Read(numArray8, 0, CInt(num3))
                                'Label5.Text = String.Concat("writing ", partname)
                                Ekse(num21, num3, numArray8)
                                num = If(num19 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(filesize), 100)
                                DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                                Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(CDbl(num3 * i)), Action))

                                ' Menghitung Waktu yang telah berlalu
                                Dim elapsed As TimeSpan = Stopwatch.Elapsed
                                Dim speed As Double = num3 * i / elapsed.TotalSeconds
                                If speed > 0 Then
                                    Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))
                                End If
                                DirectISP.SharedUI.PB1(CInt(Math.Round(num)))
                                TaskbarManager.Instance().SetProgressValue(CInt(Math.Round(num)), 100)
                                TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                                fileStream.Flush()
                            Next
                            Stopwatch.Stop()
                        End If
                        If (Operators.CompareString(asu, "notsparse", False) = 0) Then

                            'RichLogs("Writing ", Color.WhiteSmoke, True, False)
                            'RichLogs(partname & " : ", Color.DarkOrchid, True, False)
                            'RichLogs("Start Sector => ", Color.Orange, True, False)
                            'RichLogs(filesize & " : ", Color.FromArgb(128, 128, 255), True, False)

                            num4 = Int(num4)
                            num3 = CLng(1048576)
                            Dim num22 As Long = CLng(num4)
                            Dim Stopwatch As New Stopwatch()
                            Stopwatch.Start()
                            For i = CLng(0) To num22 Step CLng(1)
                                If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                    Stopwatch.Stop()
                                    e.Cancel = True
                                    Exit For
                                Else
                                    If (i = CLng(num4)) Then
                                        num3 = filesize - CLng(num4) * num3
                                        If (num3 = CLng(0)) Then
                                            Stopwatch.Stop()
                                            Exit For
                                        End If
                                    End If
                                End If
                                Dim num23 As Long = i * num3
                                Dim num24 As Long = awales + num23
                                Dim numArray9(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                                karung = num24
                                fileStream.Read(numArray9, 0, CInt(num3))
                                'Label5.Text = String.Concat("writing ", partname)
                                Ekse(num24, num3, numArray9)
                                num = If(num4 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(filesize), 100)
                                DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                                Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(CDbl(num3 * i)), Action))

                                ' Menghitung Waktu yang telah berlalu
                                Dim elapsed As TimeSpan = Stopwatch.Elapsed
                                Dim speed As Double = num3 * i / elapsed.TotalSeconds
                                If speed > 0 Then
                                    Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))
                                End If
                                DirectISP.SharedUI.PB1(CInt(Math.Round(num)))
                                fileStream.Flush()
                            Next
                            Stopwatch.Stop()
                        End If
                    End If
                    If (Operators.CompareString(m, "erasefull", False) = 0) Then
                        Dim obj As Object = Operators.DivideObject(uks, num3)
                        Dim num25 As Long = Conversions.ToLong(obj)
                        Dim Stopwatch As New Stopwatch()
                        Stopwatch.Start()
                        For i = CLng(0) To num25 Step CLng(1)
                            If DirectISP.SharedUI.eMMCISPWorker.CancellationPending Then
                                Stopwatch.Stop()
                                e.Cancel = True
                                Exit For
                            Else
                                If (Operators.ConditionalCompareObjectEqual(i, obj, False)) Then
                                    num3 = Conversions.ToLong(Operators.SubtractObject(uks, Operators.MultiplyObject(obj, num3)))
                                    If (num3 = CLng(0)) Then
                                        Stopwatch.Stop()
                                        Exit For
                                    End If
                                End If
                            End If
                            Dim numArray10(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                            Dim num26 As Long = i * num3
                            karung = num26
                            'Label2.Text = "erasing"
                            Ekse(num26, num3, numArray10)
                            num5 += num3
                            num = If(Not Operators.ConditionalCompareObjectEqual(obj, 0, False), Conversions.ToDouble(Operators.DivideObject(num5 * CLng(100), uks)), 100)

                            Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(psize), Action))
                            Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(CDbl(num3 * i)), Action))

                            ' Menghitung Waktu yang telah berlalu
                            Dim elapsed As TimeSpan = Stopwatch.Elapsed
                            Dim speed As Double = num3 * i / elapsed.TotalSeconds
                            If speed > 0 Then
                                Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))
                            End If
                            DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                        Next
                        Stopwatch.Stop()
                    End If
                End Using
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                'Label1.Text = String.Concat("Error: at ", Conversions.ToString(karung))
                ProjectData.ClearProjectError()
            End Try
        Finally
            fileStream.Close()
        End Try
    End Sub
    Public Shared Sub DirectISPWorker_RunWorkerComplete(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        TaskbarManager.Instance().SetProgressValue(100, 100)
        waitEvent.[Set]()
    End Sub


    Public Shared Sub AllDone()
        DirectISP.SharedUI.PB1OK()
        DirectISP.SharedUI.PB2OK()
        Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = "0.00 Bytes           ", Action))
        Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = "0.00 Bytes           ", Action))
        Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = "0.00 Bytes /s        ", Action))
        Dim CheckUSB As String = ""
        Main.SharedUI.RichTextBoxLogs.Invoke(CType(Sub() CheckUSB = Main.SharedUI.comboUSB.Text, Action))
        Dim ChekGPT As String = ""
        Main.SharedUI.RichTextBoxLogs.Invoke(CType(Sub() ChekGPT = Main.SharedUI.RichTextBoxLogs.Text, Action))
        If ChekGPT.Contains("Applying GPT") Then
            RichLogs(Environment.NewLine & "[ Info !!! ]", Color.DarkOrchid, True, True)
            RichLogs("  Please Remove USB " & CheckUSB, Color.DarkOrchid, True, True)
            RichLogs("  Then Plug-In  USB " & CheckUSB, Color.DarkOrchid, True, True)
            RichLogs("  Refresh Disk And Then Scan Partition to continue ...", Color.DarkOrchid, True, True)
            RichLogs("  ", Color.DarkOrchid, True, True)
        End If
        RichLogs(Environment.NewLine, Color.WhiteSmoke, True, True)
        TimeSpanElapsed.ElapsedTime(Watch)
        Watch.Stop()
    End Sub


    Public Shared Function Getfilenames(label As String) As String
        If label = "aboot" Then
            Return "emmc_appsboot.mbn"
        ElseIf label = "abootbak" Then
            Return "emmc_appsbootbak.mbn"
        ElseIf label = "apdp" Then
            Return "dpAP.mbn"
        ElseIf label = "BackupGPT" Then
            Return "gpt_backup0.bin"
        ElseIf label = "boot" Then
            Return "boot.img"
        ElseIf label = "cache" Then
            Return "cache.img"
        ElseIf label = "cmnlib" Then
            Return "cmnlib.mbn"
        ElseIf label = "cmnlibbak" Then
            Return "cmnlibbak.mbn"
        ElseIf label = "cmnlib64" Then
            Return "cmnlib64.mbn"
        ElseIf label = "cmnlib64bak" Then
            Return "cmnlib64bak.mbn"
        ElseIf label = "devcfg" Then
            Return "devcfg.mbn"
        ElseIf label = "devcfgbak" Then
            Return "devcfgbak.mbn"
        ElseIf label = "DRIVER" Then
            Return "DRIVER.ISO"
        ElseIf label = "dsp" Then
            Return "adspso.bin"
        ElseIf label = "dtbo" Then
            Return "dtbo.img"
        ElseIf label = "keymaster" Then
            Return "keymaster.mbn"
        ElseIf label = "keymasterbak" Then
            Return "keymasterbak.mbn"
        ElseIf label = "lksecapp" Then
            Return "lksecapp.mbn"
        ElseIf label = "lksecappbak" Then
            Return "lksecappbak.mbn"
        ElseIf label = "LOGO" Then
            Return "logo.bin"
        ElseIf label = "mdtp" Then
            Return "mdtp.img"
        ElseIf label = "misc" Then
            Return "misc.img"
        ElseIf label = "modem" Then
            Return "NON - HLOS.bin"
        ElseIf label = "oppodycnvbk" Then
            Return "dynamic_nvbk.bin"
        ElseIf label = "opporeserve1" Then
            Return "emmc_fw.bin"
        ElseIf label = "opporeserve2" Then
            Return "opporeserve2.img"
        ElseIf label = "oppostanvbk" Then
            Return "static_nvbk.bin"
        ElseIf label = "persist" Then
            Return "persist.img"
        ElseIf label = "PrimaryGPT" Then
            Return "gpt_main0.bin"
        ElseIf label = "recovery" Then
            Return "recovery.img"
        ElseIf label = "rpm" Then
            Return "rpm.mbn"
        ElseIf label = "rpmbak" Then
            Return "rpmbak.mbn"
        ElseIf label = "sbl1" Then
            Return "sbl1.mbn"
        ElseIf label = "sbl1bak" Then
            Return "sbl1bak.mbn"
        ElseIf label = "sec" Then
            Return "sec.dat"
        ElseIf label = "system" Then
            Return "system.img"
        ElseIf label = "tz" Then
            Return "tz.mbn"
        ElseIf label = "tzbak" Then
            Return "tzbak.mbn"
        ElseIf label = "userdata" Then
            Return "userdata.img"
        ElseIf label = "vbmeta" Then
            Return "vbmeta.img"
        ElseIf label = "vendor" Then
            Return "vendor.img"
        Else
            Return label & ".bin"
        End If
    End Function
    Public Shared Function GetFileSize(TheSize As Long) As String
        Dim str As String
        Dim DoubleBytes As Double
        Try
            Dim num As Long = TheSize
            If num >= 1099511627776L Then
                DoubleBytes = TheSize / 1099511627776
                str = String.Concat(FormatNumber(DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " TB")
            ElseIf num >= 1073741824L AndAlso num <= 1099511627775L Then
                DoubleBytes = TheSize / 1073741824
                str = String.Concat(FormatNumber(DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " GB")
            ElseIf num >= 1048576L AndAlso num <= 1073741823L Then
                DoubleBytes = TheSize / 1048576
                str = String.Concat(FormatNumber(DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " MB")
            ElseIf num >= 1024L AndAlso num <= 1048575L Then
                DoubleBytes = TheSize / 1024
                str = String.Concat(FormatNumber(DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " KB")
            ElseIf num < 0L OrElse num > 1023L Then
                str = ""
            Else
                DoubleBytes = TheSize
                str = String.Concat(FormatNumber(DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " bytes")
            End If
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            str = ""
            ProjectData.ClearProjectError()
        End Try
        Return str
    End Function

End Class
