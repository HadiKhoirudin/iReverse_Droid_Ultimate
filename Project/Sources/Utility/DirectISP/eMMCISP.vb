Imports emmclibs.emmclibs
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.Devices
Imports Microsoft.VisualBasic.MyServices
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Management
Imports System.RuntiCompilerServices
Imports System.RuntiInteropServices
Imports System.RuntiCompilerServices
Imports System.RuntiInteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices
Imports Reverse_Tool.emmclibs

Public Class eMMCISP

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
    Public Shared da As String = String.Concat(FileSystem.CurDir(), "\spft\MTK_AllInOne_DA.bin")
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

    Public Shared TodoCommand As String = ""
    Public Shared Totaltodo As Integer = 0

    Public Shared ListBox1 As ListBox
    Public Shared ListBox2 As ListBox
    Public Shared ListBox3 As ListBox
    Public Shared ListBox4 As ListBox
    Public Shared ListBox5 As ListBox
    Public Shared ListBox6 As ListBox
    Public Shared ListBox7 As ListBox

    Public Shared Property lvi As ListViewItem
    Public Shared Property ListView1 As New ListView
    Public Shared Property ListView2 As New ListView
    Public Shared proc As Process

    Public Delegate Sub txtbabbledelegate(ByVal text As String)

    Public waitEvent As AutoResetEvent


    Public Shared prosesnya As Object
    Public Shared allprosess As Object

#End Region
    Public Shared Sub Refresh_Disk()
        Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
        asu = ""
        drivename = ""
        Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Properties.Items.Clear(), Action))
        Dim flag As Boolean = False
        Using managementObjectSearcher As System.Management.ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(New WqlObjectQuery("SELECT * FROM Win32_DiskDrive"))
            enumerator = managementObjectSearcher.[Get]().GetEnumerator()
            While enumerator.MoveNext()
                Dim current As ManagementObject = DirectCast(enumerator.Current, ManagementObject)
                If Conversions.ToBoolean(If(Not Conversions.ToBoolean(Operators.CompareObjectGreater(current("MediaType"), Nothing, False)), False, current("MediaType").ToString().Contains("Removable"))) Then
                    str = current("Model").ToString()
                    uks = current("size").ToString()
                    str2 = current("DeviceID").ToString().Replace("\\.\", "")
                    str3 = String.Concat("MediaType:	", current("MediaType").ToString())
                    drivename = str2
                    Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Properties.Items.Add(String.Concat(str2, " [ ", str, " ] ")), Action))
                    Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.SelectedItem = String.Concat(str2, " [ ", str, " ] "), Action))
                    flag = True
                End If
            End While
        End Using
        If flag Then
            ComboboxDisk_Selected()
        Else
            Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Properties.Items.Clear(), Action))
        End If
    End Sub
    Public Shared Sub Scan_Partition()
        'Button8.Enabled = False
        'Button7.Enabled = False
        asu = ""
        m = "readgpt"
        DirectISP.SharedUI.Logs1Clear()
        DirectISP.SharedUI.Logs2Clear()
        DirectISP.SharedUI.DGV_C()
        ListView1.Clear()
        ListView2.Clear()
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        Dim num As Long = secc
        ListBox3.Items.Clear()
        If Equals(Main.SharedUI.comboUSB.Text, "") Then
            Interaction.MsgBox("Please select disk", MsgBoxStyle.OkOnly, Nothing)
        Else
            DirectISP.SharedUI.Logs1("reading GPT...")
            Try
                Try
                    Dim _streamer As emmc.streamer = emmc.CreateStream(String.Concat("\\.\PHYSICALDRIVE", selecteddisk), FileAccess.ReadWrite)
                    Try
                        Try
                            If File.Exists("Tools\process\file\readgpt.bin") Then
                                File.Delete("Tools\process\file\readgpt.bin")
                            End If
                            Dim fileStream As System.IO.FileStream = New System.IO.FileStream("Tools\process\file\readgpt.bin", FileMode.Append, FileAccess.Write)
                            Try
                                Try
                                    Using fileStream
                                        Dim numArray As Byte() = emmc.ReadSector(CLng(0), CInt(num), _streamer)
                                        fileStream.Write(numArray, 0, CInt(num))
                                    End Using
                                Catch exception As System.Exception
                                    ProjectData.SetProjectError(exception)
                                    DirectISP.SharedUI.Logs1("   Error at " & Conversions.ToString(karung))
                                    ProjectData.ClearProjectError()
                                End Try
                            Finally
                                fileStream.Close()
                            End Try
                        Catch exception1 As System.Exception
                            ProjectData.SetProjectError(exception1)
                            DirectISP.SharedUI.lb1("ERROR: Can't Open File")
                            ProjectData.ClearProjectError()
                        End Try
                    Finally
                        emmc.DropStream(_streamer)
                    End Try
                Catch exception2 As System.Exception
                    ProjectData.SetProjectError(exception2)
                    DirectISP.SharedUI.lb1("ERROR: Can't Open File")
                    ProjectData.ClearProjectError()
                End Try
                ListView1.Clear()
                ListView1.Items.Clear()
                DirectISP.SharedUI.Logs1Clear()
                DirectISP.SharedUI.Logs2("done")
                Dim process As System.Diagnostics.Process = New System.Diagnostics.Process()
                DirectISP.SharedUI.Logs2("Analyzing partition Table ....")
                Dim process1 As System.Diagnostics.Process = New System.Diagnostics.Process()
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
                    Dim str As String = standardOutput.ReadLine()
                    nums = nums + 1

                    If nums > lineskip Then
                        txtBabble(str)
                    End If

                End While
                process1.Dispose()
                Dim textBox As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox() With
                {
                    .Text = Main.SharedUI.RichTextBox.Text
                }
                ListBox1.Items.Add("primaryGPT.bin")
                ListBox2.Items.Add("17408")
                ListBox3.Items.Add("0")
                If If(textBox.Text.Contains("Path"), True, textBox.Text.Contains("Size")) Then
                    Dim strArrays(2) As String
                    Dim strArrays1(2) As String
                    Dim lines As String() = textBox.Lines
                    Dim num1 As Integer = 0
                    While num1 < CInt(lines.Length)
                        Dim str1 As String = lines(num1)
                        If If(str1.Contains("Path = Tools\process\file\readgpt.bin"), False, Not str1.Contains("Physical Size")) Then
                            If str1.Contains("Path") Then
                                str1 = Regex.Replace(str1, "Path = ", "")
                                str1 = Regex.Replace(str1, ".ntfs", "")
                                str1 = Regex.Replace(str1, ".img", "")
                                ListBox1.Items.Add(str1)
                            End If
                        End If
                        If If(str1.Contains("Physical Size"), False, Not str1.Contains("Path = Tools\process\file\readgpt.bin")) Then
                            If str1.Contains("Size") Then
                                str1 = Regex.Replace(str1, "Size = ", "")
                                ListBox2.Items.Add(str1)
                            End If
                        End If
                        If If(str1.Contains("Physical Size"), False, Not str1.Contains("Path = Tools\process\file\readgpt.bin")) Then
                            If str1.Contains("Offset") Then
                                str1 = Regex.Replace(str1, "Offset = ", "")
                                ListBox3.Items.Add(str1)
                            End If
                        End If
                        num1 = num1 + 1
                    End While
                End If

                DirectISP.SharedUI.DGV_C()
                Dim count As Integer = ListBox1.Items.Count - 1
                i = 0
                While i <= count
                    lvi = New ListViewItem() With
                    {
                        .Text = Conversions.ToString(ListBox1.Items(i))
                    }
                    Dim num2 As Integer = i
                    Dim num3 As Integer = num2
                    Dim item(0) As Object
                    Dim subItems As ListViewItem.ListViewSubItemCollection = lvi.SubItems
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

                    Dim listViewSubItemCollections As ListViewItem.ListViewSubItemCollection = lvi.SubItems
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

                    Dim subItems1 As ListViewItem.ListViewSubItemCollection = lvi.SubItems
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
                    lvi.SubItems.Add("")

                    ListView1.Items.Add(lvi)

                    i = i + 1
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

                process1.Dispose()
                check = False
            Catch exception3 As System.Exception
                ProjectData.SetProjectError(exception3)
                DirectISP.SharedUI.Logs2("eMMC has no partition or blank or encrypted partitin label")
                DirectISP.SharedUI.Logs2("please write partion table or full dump")
                ProjectData.ClearProjectError()
            End Try
        End If
        Identity()
        check = False
    End Sub

    Public Shared Sub Scan_Dump()
        'Button8.Enabled = False
        'Button7.Enabled = False
        Dim richTextBox As System.Windows.Forms.RichTextBox
        Dim enumerator As IEnumerator = Nothing
        asu = ""
        DirectISP.SharedUI.Logs1Clear()
        DirectISP.SharedUI.Logs2Clear()
        DirectISP.SharedUI.DGV_C()
        ListView1.Items.Clear()
        ListView1.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()

        Dim process As System.Diagnostics.Process = New System.Diagnostics.Process()
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

            Dim str As String = standardOutput.ReadLine()
            nums = nums + 1

            If nums > lineskip Then
                txtBabble(str)
            End If

        End While

        process.Dispose()
        Dim textBox As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox() With
        {
            .Text = Main.SharedUI.RichTextBox.Text
        }
        ListBox1.Items.Add("primaryGPT.bin")
        ListBox2.Items.Add("")
        ListBox3.Items.Add("0")
        If If(textBox.Text.Contains("Path"), True, textBox.Text.Contains("Size")) Then
            Dim strArrays(2) As String
            Dim strArrays1(2) As String
            Dim lines As String() = textBox.Lines
            Dim num As Integer = 0
            While num < CInt(lines.Length)
                Dim str1 As String = lines(num)
                If If(str1.Contains(DirectISP.SharedUI.TxtRawDump.Text), False, Not str1.Contains("Physical Size")) Then
                    If str1.Contains("Path") Then
                        str1 = Regex.Replace(str1, "Path = ", "")
                        str1 = Regex.Replace(str1, ".img", "")
                        strArrays = str1.Split(New Char() {Strings.ChrW(32)})
                        ListBox1.Items.Add(str1)
                    End If
                End If
                If If(str1.Contains(DirectISP.SharedUI.TxtRawDump.Text), False, Not str1.Contains("Physical Size")) Then
                    If str1.Contains("Size") Then
                        str1 = Regex.Replace(str1, "Size = ", "")
                        ListBox2.Items.Add(str1)
                    End If
                End If
                If If(str1.Contains(DirectISP.SharedUI.TxtRawDump.Text), False, Not str1.Contains("Physical Size")) Then
                    If str1.Contains("Offset") Then
                        str1 = Regex.Replace(str1, "Offset = ", "")
                        ListBox3.Items.Add(str1)
                    End If
                End If
                num = num + 1
            End While
            ListBox2.Items(0) = RuntimeHelpers.GetObjectValue(ListBox3.Items(1))
            ListView1.Items.Clear()
            Dim count As Integer = ListBox1.Items.Count - 1
            i = 0
            While i <= count
                lvi = New ListViewItem() With
                {
                    .Text = Conversions.ToString(ListBox1.Items(i))
                }
                Dim subItems As ListViewItem.ListViewSubItemCollection = lvi.SubItems
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
                Dim listViewSubItemCollections As ListViewItem.ListViewSubItemCollection = lvi.SubItems
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
                Dim subItems1 As ListViewItem.ListViewSubItemCollection = lvi.SubItems
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
                    ListView1.Items.Add(lvi)
                End If
                i = i + 1
            End While


            Dim lvItem() As String
            For i As Integer = 0 To ListView1.Items.Count - 1
                lvItem = {False, ListView1.Items(i).SubItems(1).Text, "double click...", ListView1.Items(i).SubItems(2).Text, ListView1.Items(i).SubItems(3).Text, ""}
                DirectISP.SharedUI.DataView.Rows.Add(lvItem)
            Next

            If File.Exists("build.prop") Then
                File.Delete("build.prop")
            End If
            DirectISP.SharedUI.Logs2("Scanning file system...")
            'wait(1)
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
                        Dim fileStream As System.IO.FileStream = New System.IO.FileStream(openfile, FileMode.Open, FileAccess.Read)
                        Dim fileStream1 As System.IO.FileStream = New System.IO.FileStream("build.prop", FileMode.Append, FileAccess.Write)
                        Try
                            Try
                                Using fileStream
                                    Dim num6 As Integer = 1048576
                                    Dim num7 As Double = Conversions.ToDouble(text1) / CDbl(num6)
                                    num7 = Conversion.Int(num7)
                                    fileStream.Position = Conversions.ToLong(text)
                                    Dim num8 As Integer = CInt(Math.Round(num7))
                                    i = 0
                                    While i <= num8
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
                                            i = i + 1
                                        Else
                                            fileStream1.Write(numArray, 0, num6)
                                            fileStream1.Close()
                                            DirectISP.SharedUI.Logs2("Reading build prop")
                                            Dim StringLog As String
                                            Dim streamReader As System.IO.StreamReader = MyProject.Computer.FileSystem.OpenTextFileReader("build.prop")
                                            While True
                                                Dim str2 As String = streamReader.ReadLine()
                                                If str2.Contains("ro.product.model") Then
                                                    Dim log As String = String.Concat(log, "model: ", str2.Replace("ro.product.model=", ""))
                                                    StringLog = String.Concat(StringLog, log, vbCrLf)
                                                End If
                                                If str2.Contains("ro.product.brand") Then
                                                    Dim log As String = String.Concat(log, "brand: ", str2.Replace("ro.product.brand=", ""))
                                                    StringLog = String.Concat(StringLog, log, vbCrLf)
                                                End If
                                                If str2.Contains("ro.product.locale") Then
                                                    Dim log As String = String.Concat(log, "local: ", str2.Replace("ro.product.locale=", ""))
                                                    StringLog = String.Concat(StringLog, log, vbCrLf)
                                                End If
                                                If str2.Contains("ro.product.name") Then
                                                    Dim log As String = String.Concat(log, "codename: ", str2.Replace("ro.product.name=", ""))
                                                    StringLog = String.Concat(StringLog, log, vbCrLf)
                                                End If
                                                If str2.Contains("end build prop") Then
                                                    Exit While
                                                End If
                                            End While
                                            streamReader.Close()
                                            RichLogs(StringLog, Color.WhiteSmoke, False, True)
                                            Return
                                        End If
                                    End While
                                End Using
                            Catch exception As System.Exception
                                ProjectData.SetProjectError(exception)
                                DirectISP.SharedUI.lb1(String.Concat("Error: at ", Conversions.ToString(karung)))
                                Dim log As String = String.Concat(log, "   Error at ", Conversions.ToString(karung))
                                DirectISP.SharedUI.Logs2(log)
                                ProjectData.ClearProjectError()
                            End Try
                        Finally
                            fileStream.Close()
                        End Try
                    End If
                End While
            Finally

            End Try
        End If
    End Sub
    Public Shared Sub txtBabble(ByVal text As String)
        DirectISP.SharedUI.Logs1(text)
        Dim str As String = ""
        If Equals(asu, "inisparse") Then
            If text.Contains("filename") Then
                str = text.Replace(".sparse", "")
                str = str.Replace("filename", "")
                str = str.Replace(" ", "")
                Dim num As Double = (Conversions.ToDouble(totalchunk) - Conversions.ToDouble(str)) / (Conversions.ToDouble(totalchunk) - 1) * 100
                DirectISP.SharedUI.PB2(CInt(Math.Round(num)))
            End If
            Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo("unsparse.img")
        End If
    End Sub
    Public Shared Sub Identity()
        Dim str As String
        Dim richTextBox As System.Windows.Forms.RichTextBox
        Try
            If DirectISP.SharedUI.DataView.RowCount > 0 Then
                For Each row As DataGridViewRow In DirectISP.SharedUI.DataView.Rows
                    If Equals(row.Cells(DirectISP.SharedUI.DataView.Columns(1).Index).Value.ToString(), "system") Then
                        Dim text As String = row.Cells(DirectISP.SharedUI.DataView.Columns(3).Index).Value.ToString()
                        Dim _streamer As emmc.streamer = emmc.CreateStream(String.Concat("\\.\PHYSICALDRIVE", selecteddisk), FileAccess.ReadWrite)
                        Dim text1 As String = row.Cells(DirectISP.SharedUI.DataView.Columns(3).Index).Value.ToString()
                        If File.Exists("build.prop") Then
                            File.Delete("build.prop")
                        End If
                        Dim [integer] As Integer = 1048576
                        Dim objectValue As Object = Operators.DivideObject(uks, [integer])
                        Dim fileStream As System.IO.FileStream = New System.IO.FileStream("build.prop", FileMode.Append, FileAccess.Write)
                        Dim num As Long = CLng(0)
                        If Conversions.ToDouble(text1) >= 536870912 Then
                            num = CLng(536870912)
                        End If
                        Try
                            Try
                                Dim num1 As Long = CLng(0)
                                objectValue = RuntimeHelpers.GetObjectValue(Conversion.Int(RuntimeHelpers.GetObjectValue(objectValue)))
                                Dim num2 As Long = Conversions.ToLong(objectValue)
                                num1 = CLng(0)
                                While num1 <= num2
                                    If Operators.ConditionalCompareObjectEqual(num1, objectValue, False) Then
                                        [integer] = Conversions.ToInteger(Operators.SubtractObject(uks, Operators.MultiplyObject(objectValue, [integer])))
                                    End If
                                    If [integer] <> 0 Then
                                        Dim numArray As Byte() = emmc.ReadSector(CLng(Math.Round(CDbl(num1 * CLng([integer])) + Conversions.ToDouble(text) + CDbl(num))), [integer], _streamer)
                                        If UnicodeBytesToString(numArray).Contains("begin build prop") Then
                                            fileStream.Write(numArray, 0, [integer])
                                            fileStream.Close()
                                            emmc.DropStream(_streamer)
                                            Dim richTextBox2 As System.Windows.Forms.RichTextBox = richTextBox2
                                            richTextBox2.Text = String.Concat(richTextBox2.Text, "Reading build prop" & vbCrLf & "")
                                            Dim streamReader As System.IO.StreamReader = MyProject.Computer.FileSystem.OpenTextFileReader("build.prop")
                                            Do
                                                str = streamReader.ReadLine()
                                                If str2.Contains("ro.product.model") Then
                                                    Dim log As String = String.Concat(log, "model: ", str2.Replace("ro.product.model=", ""))
                                                    DirectISP.SharedUI.Logs2(log)
                                                End If
                                                If str2.Contains("ro.product.brand") Then
                                                    Dim log As String = String.Concat(log, "brand: ", str2.Replace("ro.product.brand=", ""))
                                                    DirectISP.SharedUI.Logs2(log)
                                                End If
                                                If str2.Contains("ro.product.locale") Then
                                                    Dim log As String = String.Concat(log, "local: ", str2.Replace("ro.product.locale=", ""))
                                                    DirectISP.SharedUI.Logs2(log)
                                                End If
                                                If str2.Contains("ro.product.name") Then
                                                    Dim log As String = String.Concat(log, "codename: ", str2.Replace("ro.product.name=", ""))
                                                    DirectISP.SharedUI.Logs2(log)
                                                End If
                                                If str2.Contains("end build prop") Then
                                                    Continue Do
                                                End If
                                                streamReader.Close()
                                                Return
                                            Loop While str IsNot Nothing
                                        End If
                                        num1 = num1 + CLng(1)
                                    Else
                                        Exit While
                                    End If
                                End While
                            Catch exception As System.Exception
                                ProjectData.SetProjectError(exception)
                                DirectISP.SharedUI.lb1(String.Concat("Error: at ", Conversions.ToString(karung)))
                                DirectISP.SharedUI.Logs2("   Error at " & Conversions.ToString(karung))
                                ProjectData.ClearProjectError()
                            End Try
                        Finally
                            emmc.DropStream(_streamer)
                            DirectISP.SharedUI.PB1(100)
                            TaskbarManager.Instance().SetProgressValue(0, 100)
                            TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                        End Try
                    End If
                Next

            End If

        Finally

        End Try
    End Sub
    Public Shared Function UnicodeBytesToString(ByVal bytes As Byte()) As String
        Return Encoding.ASCII.GetString(bytes)
    End Function

    Public Shared Sub ComboboxDisk_Selected()
        Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
        Dim managementObjectEnumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
        Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Main.SharedUI.comboUSB.SelectedItem)
        objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, Nothing, "replace", New Object() {String.Concat("[ ", str, " ]"), ""}, Nothing, Nothing, Nothing))
        selecteddisk = Conversions.ToString(NewLateBinding.LateGet(objectValue, Nothing, "Replace", New Object() {"PHYSICALDRIVE", ""}, Nothing, Nothing, Nothing))
        selecteddisk = selecteddisk.Replace(" ", "")
        Console.WriteLine("Selected disk : " & selecteddisk)
        Dim wqlObjectQuery As System.Management.WqlObjectQuery = New System.Management.WqlObjectQuery(String.Concat("SELECT * FROM Win32_DiskDrive WHERE DeviceID = ""\\\\.\\PHYSICALDRIVE", selecteddisk, """"))
        Using managementObjectSearcher As System.Management.ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(wqlObjectQuery)
            enumerator = managementObjectSearcher.[Get]().GetEnumerator()
            While enumerator.MoveNext()
                Dim current As System.Management.ManagementObject = DirectCast(enumerator.Current, System.Management.ManagementObject)
                If Conversions.ToBoolean(If(Not Conversions.ToBoolean(Operators.CompareObjectGreater(current("MediaType"), Nothing, False)), False, current("MediaType").ToString().Contains("Removable"))) Then
                    str = current("Model").ToString()
                    uks = current("size").ToString()
                    str2 = current("DeviceID").ToString().Replace("\\.\", "")
                    str3 = String.Concat("MediaType:  	", current("MediaType").ToString())
                    drivename = str2
                End If
            End While
        End Using
        ListBox1.Items.Clear()
        Dim wqlObjectQuery1 As System.Management.WqlObjectQuery = New System.Management.WqlObjectQuery(String.Concat("SELECT * FROM Win32_Diskpartition Where Diskindex = '", selecteddisk, "'"))
        Dim managementObjectSearcher1 As System.Management.ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(wqlObjectQuery1)
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
        secc = Conversions.ToLong(ListBox1.Items(0))
    End Sub
    Public Shared Sub Open_RAWXML()
        Dim enumerator As IEnumerator = Nothing
        DirectISP.SharedUI.DGV_C()
        If File.Exists(DirectISP.SharedUI.TxtFlashRawXML.Text) Then
            Dim xmlReader As System.Xml.XmlReader = System.Xml.XmlReader.Create(DirectISP.SharedUI.TxtFlashRawXML.Text)
            While xmlReader.Read()
                If (If(xmlReader.NodeType <> XmlNodeType.Element, False, Operators.CompareString(xmlReader.Name, "program", False) = 0)) Then
                    lvi = New System.Windows.Forms.ListViewItem()
                    lvi.SubItems.Add(xmlReader.GetAttribute("label"))
                    lvi.SubItems.Add(Conversions.ToString(Conversions.ToDouble(xmlReader.GetAttribute("num_partition_sectors")) * 512))
                    If Not xmlReader.GetAttribute("start_sector").Contains("NUM_DISK_SECTORS") Then
                        lvi.SubItems.Add(Conversions.ToString(Conversions.ToDouble(xmlReader.GetAttribute("start_sector")) * 512))
                    Else
                        Dim str2 As String = xmlReader.GetAttribute("start_sector").Replace("NUM_DISK_SECTORS-", "").Replace(".", "")
                        NewLateBinding.LateCall(lvi.SubItems, Nothing, "Add", New Object() {Operators.SubtractObject(uks, Conversions.ToDouble(str2) * 512)}, Nothing, Nothing, Nothing, True)
                    End If

                    If Not Equals(xmlReader.GetAttribute("filename"), "") Then
                        lvi.SubItems.Add(If(String.Concat(Path.GetDirectoryName(DirectISP.SharedUI.TxtFlashRawXML.Text), "\", xmlReader.GetAttribute("filename")), ""))
                    Else
                        lvi.SubItems.Add("none")
                    End If
                    ListView1.Items.Add(lvi)
                    lvi.Checked = True
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


            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub

    Public Shared Sub Open_ScatterTXT()
        Dim enumerator As IEnumerator = Nothing
        Dim enumerator1 As IEnumerator = Nothing
        Dim directoryName As String = Path.GetDirectoryName(DirectISP.SharedUI.TxtScatterFile.Text)
        Dim str3 As String = String.Concat(directoryName, "\temp.xml")
        If File.Exists(str3) Then
            MyProject.Computer.FileSystem.DeleteFile(str3)
        End If
        lvi = New System.Windows.Forms.ListViewItem()
        Dim streamWriter As System.IO.StreamWriter = MyProject.Computer.FileSystem.OpenTextFileWriter(str3, True)
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
                Dim str6 As String = str4
                str6 = str4.Replace(tstor, "")
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
                streamWriter.Write(String.Concat("Size=""", str16, """ />" & vbCrLf & ""))
            End If
            num = num + 1
        End While
        streamWriter.Write("</data>")
        streamWriter.Close()

        If Not Equals(DirectISP.SharedUI.TxtScatterFile.Text, "") Then
            Dim directoryName1 As String = Path.GetDirectoryName(DirectISP.SharedUI.TxtScatterFile.Text)
            Dim str17 As String = String.Concat(directoryName, "\temp.xml")
            If File.Exists(str17) Then
                Dim xmlReader1 As System.Xml.XmlReader = System.Xml.XmlReader.Create(str17)
                While xmlReader1.Read()
                    If If(xmlReader1.NodeType <> XmlNodeType.Element, False, Equals(xmlReader1.Name, "program")) Then
                        lvi = New System.Windows.Forms.ListViewItem()
                        lvi.SubItems.Add(xmlReader1.GetAttribute(1))
                        Dim str18 As String = xmlReader1.GetAttribute(4).Replace("0x", "")
                        Dim num1 As Long = Convert.ToInt64(str18, 16)
                        lvi.SubItems.Add(Conversions.ToString(num1))
                        Dim str19 As String = xmlReader1.GetAttribute(3).Replace("0x", "")
                        Dim num2 As Long = Convert.ToInt64(str19, 16)
                        lvi.SubItems.Add(Conversions.ToString(num2))
                        lvi.SubItems.Add(String.Concat(directoryName1, "\", xmlReader1.GetAttribute(2)))
                        ListView1.Items.Add(lvi)
                        lvi.Checked = True
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
    Public Shared Sub read()
        Dim num As Integer = 1
        Try
            Using stringReader As StringReader = New StringReader(TodoCommand)
                While stringReader.Peek() <> -1
                    Dim cmd As String = stringReader.ReadLine()

                    If cmd <> String.Empty Then

                        Dim exec As String = Nothing
                        Dim arg As String() = cmd.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        ' 0 bool
                        ' 1 partition
                        ' 2 size bytes
                        ' 3 offset
                        ' 4 location

                        Dim num1 As Integer
                        If Conversions.ToLong(arg(2)) < 1048576 Then
                            num1 = Conversions.ToLong(arg(2))
                        End If
                        If Conversions.ToLong(arg(2)) > 1048576 Then
                            num1 = 1048576
                        End If
                        If Conversions.ToLong(arg(2)) > 1048576 * 2 Then
                            num1 = 1048576 * 2
                        End If
                        If Conversions.ToLong(arg(2)) > 1048576 * 3 Then
                            num1 = 1048576 * 3
                        End If
                        If Conversions.ToLong(arg(2)) > 1048576 * 4 Then
                            num1 = 1048576 * 4
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
                        RichLog.RichLogs("Reading " & str, Color.WhiteSmoke, False, False)
                        Dim _streamer As emmc.streamer = emmc.CreateStream(String.Concat("\\.\PHYSICALDRIVE", selecteddisk), FileAccess.ReadWrite)
                        Try
                            If File.Exists(folderdersave & "\" & Bismillah.FIREHOSE.FIREHOSE_MANAGER.getfilenames(str)) Then
                                File.Delete(folderdersave & "\" & Bismillah.FIREHOSE.FIREHOSE_MANAGER.getfilenames(str))
                            End If
                            Dim fileStream As System.IO.FileStream = New System.IO.FileStream(folderdersave & "\" & Bismillah.FIREHOSE.FIREHOSE_MANAGER.getfilenames(str), FileMode.Append, FileAccess.Write)
                            Try
                                Dim num3 As Long = CLng(0)
                                DirectISP.SharedUI.PB2(0)
                                Using fileStream
                                    num2 = Conversion.Int(num2)
                                    Dim num4 As Integer = num1
                                    Dim num5 As Long = CLng(Math.Round(num2))
                                    num3 = CLng(0)
                                    Do
                                        If CDbl(num3) = num2 Then
                                            num1 = CInt(Math.Round(CDbl(psize) - num2 * CDbl(num1)))
                                            If num1 = 0 Then
                                                Exit Do
                                            End If
                                        End If
                                        Dim numArray As Byte() = emmc.ReadSector(CLng(Math.Round(Conversions.ToDouble(text) + CDbl(num3 * CLng(num4)))), num1, _streamer)
                                        fileStream.Write(numArray, 0, num1)
                                        Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = Bismillah.FIREHOSE.FIREHOSE_MANAGER.GetFileSize(Conversions.ToLong(arg(2))), Action))
                                        Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = Bismillah.FIREHOSE.FIREHOSE_MANAGER.GetFileSize(CDbl(num3 * CLng(num4))), Action))
                                        Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = Bismillah.FIREHOSE.FIREHOSE_MANAGER.GetFileSize(CLng(num4)) & " /s", Action))

                                        If num2 <> 0 Then
                                            num8 = CDbl(num3 * CLng(num1) * CLng(100)) / CDbl(psize)
                                        Else
                                            num8 = 100
                                        End If
                                        DirectISP.SharedUI.PB1(CInt(Math.Round(Conversion.Int(num8))))
                                        TaskbarManager.Instance().SetProgressValue(CInt(Math.Round(num8)), 100)
                                        TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                                        num3 = num3 + CLng(1)
                                    Loop While num3 <= num5
                                    RichLogs(" done", Color.LimeGreen, False, True)
                                End Using
                            Finally
                                fileStream.Close()
                                Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = "0.00 Bytes           ", Action))
                                Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = "0.00 Bytes           ", Action))
                                Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = "0.00 Bytes /s        ", Action))
                                TaskbarManager.Instance().SetProgressValue(0, 100)
                                TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                            End Try
                        Finally
                            emmc.DropStream(_streamer)
                        End Try
                        Dim num6 As Integer = CInt(Math.Round(CDbl(num) / CDbl(Totaltodo) * 100))
                        DirectISP.SharedUI.PB2(num6)

                        num = num + 1
                    End If
                End While
            End Using

        Catch exception As System.Exception
            Console.WriteLine(exception)
        Finally

        End Try
        DirectISP.SharedUI.PB1OK()
        DirectISP.SharedUI.PB2OK()
    End Sub

    Public Shared Sub readfull()
        Dim enumerator As IEnumerator = Nothing
        DirectISP.SharedUI.Logs1("Start Reading...")
        If Equals(Main.SharedUI.comboUSB.Text, "8mb") Then
            uks = 8388608
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "16mb") Then
            uks = 16777216
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "32mb") Then
            uks = 33554432
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "64mb") Then
            uks = 67108864
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "128mb") Then
            uks = 134217728
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "256mb") Then
            uks = 268435456
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "512mb") Then
            uks = 536870912
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "1gb") Then
            uks = 1073741824
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "2gb") Then
            uks = -2147483648
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "4gb") Then
            uks = 4294967296L
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "auto") Then
            uks = RuntimeHelpers.GetObjectValue(uks)
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "ExcludeUserdata") Then
            If ListView1.Items.Count <> 0 Then
                Try
                    enumerator = ListView1.Items.GetEnumerator()
                    While enumerator.MoveNext()
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
        Try
            Dim _streamer As emmc.streamer = emmc.CreateStream(String.Concat("\\.\PHYSICALDRIVE", selecteddisk), FileAccess.ReadWrite)
            Try
                Try
                    If File.Exists(folderdersave & "\dump" & Main.SharedUI.comboUSB.Text & ".bin") Then
                        File.Delete(folderdersave & "\dump" & Main.SharedUI.comboUSB.Text & ".bin")
                    End If
                    Dim [integer] As Integer = 1048576
                    Dim objectValue As Object = Operators.DivideObject(uks, [integer])
                    Dim fileStream As System.IO.FileStream = New System.IO.FileStream(folderdersave & "\dump" & Main.SharedUI.comboUSB.Text & ".bin", FileMode.Append, FileAccess.Write)
                    Try
                        Try
                            Dim num As Long = CLng(0)
                            Using fileStream
                                objectValue = RuntimeHelpers.GetObjectValue(Conversion.Int(RuntimeHelpers.GetObjectValue(objectValue)))
                                Dim num1 As Long = Conversions.ToLong(objectValue)
                                num = CLng(0)
                                While num <= num1
                                    If Operators.ConditionalCompareObjectEqual(num, objectValue, False) Then
                                        [integer] = Conversions.ToInteger(Operators.SubtractObject(uks, Operators.MultiplyObject(objectValue, [integer])))
                                    End If
                                    If [integer] <> 0 Then
                                        Dim numArray As Byte() = emmc.ReadSector(num * CLng([integer]), [integer], _streamer)
                                        fileStream.Write(numArray, 0, [integer])
                                        karung = num * CLng([integer])
                                        num8 = Conversions.ToDouble(Operators.DivideObject(num * CLng([integer]) * CLng(100), uks))
                                        DirectISP.SharedUI.lb2(String.Concat("Reading sector 0x00", Conversion.Hex(num * CLng([integer]))))
                                        DirectISP.SharedUI.lb1(String.Concat("process  ", Conversions.ToString(Conversion.Int(num8)), "%"))
                                        DirectISP.SharedUI.PB1(CInt(Math.Round(num)))
                                        TaskbarManager.Instance().SetProgressValue(CInt(Math.Round(num8)), 100)
                                        TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                                        num = num + CLng(1)
                                    Else
                                        Exit While
                                    End If
                                End While
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
                    DirectISP.SharedUI.lb1("ERROR: Can't Open File")
                    ProjectData.ClearProjectError()
                End Try
            Finally
                emmc.DropStream(_streamer)
            End Try
        Catch exception2 As System.Exception
            ProjectData.SetProjectError(exception2)
            DirectISP.SharedUI.lb1("ERROR: Can't Open File")
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Shared Sub readselected()
        Dim enumerator As IEnumerator = Nothing
        Dim str As String
        If ListView1.CheckedItems.Count <> 0 Then
            Dim num As Integer = 0
            Try
                enumerator = ListView1.CheckedItems.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                    If ListView1.CheckedItems.Count <> 0 Then
                        Dim count As Integer = ListView1.CheckedItems.Count
                        Dim richTextBox2 As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
                        Dim richTextBox As System.Windows.Forms.RichTextBox = richTextBox2
                        richTextBox2.Text = String.Concat(richTextBox.Text, "reading ", current.SubItems(1).Text, "...")
                        'DirectISP.SharedUI.wait(1)
                        Dim size1 As Double = CDbl(current.SubItems(2).Text) / 512
                        Dim size2 As Double = CDbl(current.SubItems(3).Text) / 512
                        Dim size3 As Long = CLng((uks / 512) - size2)

                        If size1 <> 0 Then
                            str = String.Format(" -backup PhysicalDrive{0} ""{1}\{2}.bin"" {3} {4}", selecteddisk, folderdersave, current.SubItems(1).Text, size2, size1)
                        Else
                            str = String.Format(" -backup PhysicalDrive{0} ""{1}\{2}.bin"" {3} {4}", selecteddisk, folderdersave, current.SubItems(1).Text, size2, size3)
                        End If
                        Dim process As System.Diagnostics.Process = New System.Diagnostics.Process()
                        Dim startInfo As ProcessStartInfo = process.StartInfo
                        startInfo.FileName = "Tools\process\file\secinspect.exe"
                        startInfo.Arguments = str
                        startInfo.UseShellExecute = False
                        startInfo.CreateNoWindow = True
                        startInfo.RedirectStandardInput = True
                        startInfo.RedirectStandardOutput = True
                        startInfo.RedirectStandardError = True
                        startInfo.StandardOutputEncoding = Encoding.ASCII
                        startInfo = Nothing
                        process.Start()
                        Dim standardOutput As StreamReader = process.StandardOutput
                        While Not process.StandardOutput.EndOfStream
                            Dim str1 As String = standardOutput.ReadLine()
                            txtBabble(String.Concat(str1, "" & vbCrLf & ""))
                        End While
                        process.Dispose()
                        num = num + 1
                        Dim richTextBox21 As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
                        richTextBox21.Text = String.Concat(richTextBox21.Text, "done" & vbCrLf & "")
                        Dim num4 As Double = CDbl(num * 100) / CDbl(count)
                        DirectISP.SharedUI.PB2(CInt(Math.Round(num4)))
                        'DirectISP.SharedUI.wait(1)
                    End If
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub


    Public Shared Sub writedump()
        Dim num As Double
        Dim enumerator As IEnumerator = Nothing
        Dim num1 As Long = filesize
        Dim num2 As Long = filesize
        Dim length As Long = New FileInfo(openfile).Length
        If Equals(Main.SharedUI.comboUSB.Text, "8mb") Then
            If length < CLng(8388608) Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(8388608)
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "16mb") Then
            If length < CLng(16777216) Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(16777216)
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "32mb") Then
            If length < CLng(33554432) Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(33554432)
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "64mb") Then
            If length < CLng(67108864) Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(67108864)
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "128mb") Then
            If length < CLng(134217728) Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(134217728)
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "256mb") Then
            If length < CLng(268435456) Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(268435456)
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "512mb") Then
            If length < CLng(536870912) Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(536870912)
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "1gb") Then
            If length < CLng(1073741824) Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(1073741824)
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "2gb") Then
            If length < -2147483648 Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = CLng(-2147483648)
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "4gb") Then
            If length < 4294967296L Then
                Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
            Else
                length = 4294967296L
            End If
        ElseIf Equals(Main.SharedUI.comboUSB.Text, "auto") Then
            If Equals(Main.SharedUI.comboUSB.Text, "ExcludeUserdata") Then
                If ListView1.Items.Count <> 0 Then
                    Try
                        enumerator = ListView1.Items.GetEnumerator()
                        While enumerator.MoveNext()
                            Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                            If Equals(current.SubItems(1).Text, "userdata") Then
                                If CDbl(length) < Conversions.ToDouble(current.SubItems(3).Text) Then
                                    Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
                                Else
                                    length = Conversions.ToLong(current.SubItems(3).Text)
                                End If
                                Console.WriteLine(length)
                            ElseIf Equals(current.SubItems(1).Text, "usrdata") Then
                                If CDbl(length) < Conversions.ToDouble(current.SubItems(3).Text) Then
                                    Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
                                Else
                                    length = Conversions.ToLong(current.SubItems(3).Text)
                                End If
                            ElseIf Equals(current.SubItems(1).Text, "data") Then
                                If CDbl(length) < Conversions.ToDouble(current.SubItems(3).Text) Then
                                    Interaction.MsgBox("file size is smaller than file size in seting to writen" & vbCrLf & "using seting with actual size file", MsgBoxStyle.OkOnly, Nothing)
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
        Dim fileStream As System.IO.FileStream = New System.IO.FileStream(openfile, FileMode.Open, FileAccess.Read)
        Try
            Try
                Dim i As Long = CLng(0)
                Using fileStream
                    num4 = CInt(Math.Round(CDbl(length) / CDbl(num3)))
                    num4 = Conversion.Int(num4)
                    Dim num6 As Long = CLng(num4)
                    For i = CLng(0) To num6 Step CLng(1)
                        If i = CLng(num4) Then
                            num3 = length - CLng(num4) * num3
                            If num3 = CLng(0) Then
                                Exit For
                            End If
                        End If
                        offset = i * num3
                        karung = offset
                        Dim numArray(CInt(num3 - CLng(1)) + 1 - 1) As Byte
                        fileStream.Read(numArray, 0, CInt(num3))
                        ekse(offset, num3, numArray)
                        DirectISP.SharedUI.lb5("Writing")
                        num = If(num4 <> 0, CDbl(i * num3 * CLng(100)) / CDbl(length), 100)
                        DirectISP.SharedUI.PB1(CInt(Math.Round(num)))
                        DirectISP.SharedUI.lb1(String.Concat("Process ", Conversions.ToString(CInt(Math.Round(num))), "%"))
                        TaskbarManager.Instance().SetProgressValue(CInt(Math.Round(num)), 100)
                        TaskbarManager.Instance().SetOverlayIcon(Main.SharedUI.Icon, "")
                        fileStream.Flush()
                    Next

                End Using
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                DirectISP.SharedUI.lb1(String.Concat("Error: load file at ", Conversions.ToString(offset)))
                ProjectData.ClearProjectError()
            End Try
        Finally
            fileStream.Close()

            RichLogs("done ", Color.WhiteSmoke, False, True)
            DirectISP.SharedUI.lb1("done")
        End Try
        If cekerror Then
            Dim count As Integer = ListBox1.Items.Count - 1
            For j As Integer = 0 To count Step 1
                RichLogs("done with error at sector " & ListBox1.Items(j), Color.WhiteSmoke, False, True)
            Next

        End If
    End Sub

    Public Shared Sub WritePartitionDump()
        Dim enumerator As IEnumerator = Nothing
        Dim length As Long = New FileInfo(openfile).Length
        Dim num As Integer = 0
        If ListView1.CheckedItems.Count <> 0 Then
            Try
                enumerator = ListView1.CheckedItems.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                    Dim count As Integer = ListView1.CheckedItems.Count
                    poffsets = Conversions.ToLong(current.SubItems(3).Text)
                    psize = Conversions.ToLong(current.SubItems(2).Text)
                    pname = current.SubItems(1).Text
                    If CDbl(length) >= Conversions.ToDouble(current.SubItems(3).Text) Then
                        DirectISP.SharedUI.DirectISPWorker.WorkerReportsProgress = True
                        DirectISP.SharedUI.DirectISPWorker.WorkerSupportsCancellation = True
                        If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                            Application.DoEvents()
                            DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                            Application.DoEvents()
                        End If
                        'waitEvent.WaitOne()
                        Thread.Sleep(300)
                        DirectISP.SharedUI.PB2(CInt(Math.Round(CDbl(num * 100) / CDbl(count))))
                        Dim richTextBox2 As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
                        richTextBox2.Text = String.Concat(richTextBox2.Text, "done" & vbCrLf & "")
                        num = num + 1
                    Else
                        Dim richTextBox As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
                        richTextBox.Text = String.Concat(richTextBox.Text, "sector size to be writen is biger than file size")
                        Exit While
                    End If
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            DirectISP.SharedUI.PB2(100)
            Dim richTextBox21 As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
            richTextBox21.Text = String.Concat(richTextBox21.Text, "All done" & vbCrLf & "")
        End If
    End Sub

    Public Shared Sub writeselected()
        Dim num As Integer = 0
        DirectISP.SharedUI.PB2(0)
        Using stringReader As StringReader = New StringReader(TodoCommand)
            While stringReader.Peek() <> -1
                Dim cmd As String = stringReader.ReadLine()

                If cmd <> String.Empty Then

                    Dim exec As String = Nothing
                    Dim arg As String() = cmd.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    ' 0 bool
                    ' 1 partition
                    ' 2 size bytes
                    ' 3 offset
                    ' 4 location

                    If File.Exists(arg(4)) Then

                        DirectISP.SharedUI.Logs1Clear()
                        ListBox1.Items.Clear()
                        ListBox2.Items.Clear()
                        ListView2.Clear()
                        ListView2.Items.Clear()
                        partname = arg(1)
                        sentot = arg(3)
                        Dim process As System.Diagnostics.Process = New System.Diagnostics.Process()
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
                            Dim str As String = standardOutput.ReadLine()
                            txtBabble(String.Concat(str, "" & vbCrLf & ""))
                        End While
                        process.Dispose()
                        Dim output As String
                        Main.SharedUI.RichTextBox.Invoke(CType(Sub() output = Main.SharedUI.RichTextBox.Text, Action))
                        Dim textBox As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox() With
                            {
                                .Text = output
                            }
                        ListBox1.Items.Add("0")
                        If textBox.Text.Contains("notsparse") Then
                            DirectISP.SharedUI.Logs1Clear()
                            openfile = arg(4)
                            Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(openfile)
                            filesize = Conversions.ToLong(arg(2))
                            awales = Conversions.ToLong(arg(3))
                            partname = arg(1)
                            asu = "notsparse"
                            Dim fileInfo1 As System.IO.FileInfo = New System.IO.FileInfo(arg(4))
                            If CDbl(fileInfo1.Length) <= Conversions.ToDouble(arg(2)) Then
                                DirectISP.SharedUI.DirectISPWorker.WorkerReportsProgress = True
                                DirectISP.SharedUI.DirectISPWorker.WorkerSupportsCancellation = True
                                If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                                    Application.DoEvents()
                                    DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                                    'waitEvent.WaitOne()
                                    Thread.Sleep(300)
                                End If
                                RichLogs(" done", Color.LimeGreen, False, True)
                            Else
                                If MessageBox.Show(String.Concat(New String() {"file Size ", fileInfo1.Name, " is bigger than partition size of ", arg(1), "" & vbCrLf & "if yes, not all sector will be writen" & vbCrLf & "if no ,file will skiping"}), "Warning", MessageBoxButtons.YesNo) <> System.Windows.Forms.DialogResult.Yes Then
                                    RichLogs(" skiping " & fileInfo1.Name, Color.LimeGreen, False, True)
                                Else
                                    DirectISP.SharedUI.DirectISPWorker.WorkerReportsProgress = True
                                    DirectISP.SharedUI.DirectISPWorker.WorkerSupportsCancellation = True
                                    If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                                        Application.DoEvents()
                                        DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                                        'waitEvent.WaitOne()
                                        Thread.Sleep(300)
                                    End If
                                End If
                                RichLogs(" done", Color.LimeGreen, False, True)
                            End If
                        End If
                        If textBox.Text.Contains("inisparse") Then
                            Dim richTextBox22 As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
                            RichLogs(" processing " & partname, Color.WhiteSmoke, False, True)
                            asu = "inisparse"
                            If textBox.Text.Contains("total") Then
                                Dim lines As String() = textBox.Lines
                                Dim num1 As Integer = 0
                                While num1 < CInt(lines.Length)
                                    Dim str1 As String = lines(num1)
                                    If str1.Contains("total") Then
                                        str1 = Regex.Replace(str1, "total chunk =", "")
                                        str1 = Regex.Replace(str1, "sparse", "")
                                        totalchunk = str1
                                    End If
                                    num1 = num1 + 1
                                End While
                            End If
                            DirectISP.SharedUI.Logs1Clear()
                            DirectISP.SharedUI.Logs1Clear()
                            DirectISP.SharedUI.lb2("parsing sparse image " & vbCrLf & "")
                            Dim process1 As System.Diagnostics.Process = New System.Diagnostics.Process()
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
                                Dim str2 As String = streamReader.ReadLine()
                                txtBabble(String.Concat(str2, "" & vbCrLf & ""))
                            End While
                            process1.Dispose()
                            Dim outputdump As String
                            Main.SharedUI.RichTextBox.Invoke(CType(Sub() outputdump = Main.SharedUI.RichTextBox.Text, Action))
                            Dim TxtRawDump As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox() With
                                {
                                    .Text = outputdump
                                }
                            DirectISP.SharedUI.Logs1Clear()
                            openfile = "unsparse.img"
                            filesize = New System.IO.FileInfo(openfile).Length
                            Dim fileInfo2 As System.IO.FileInfo = New System.IO.FileInfo("unsparse.img")
                            If CDbl(fileInfo2.Length) <= Conversions.ToDouble(arg(2)) Then
                                DirectISP.SharedUI.DirectISPWorker.WorkerReportsProgress = True
                                DirectISP.SharedUI.DirectISPWorker.WorkerSupportsCancellation = True
                                If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                                    Application.DoEvents()
                                    DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                                    'waitEvent.WaitOne()
                                    Thread.Sleep(300)
                                End If
                                RichLogs(" done", Color.LimeGreen, False, True)
                            ElseIf MessageBox.Show(String.Concat(New String() {"file Size ", fileInfo2.Name, " is bigger than partition size of ", arg(1), "" & vbCrLf & "if yes, not all sector will be writen" & vbCrLf & "if no ,file will skiping"}), "Warning", MessageBoxButtons.YesNo) <> System.Windows.Forms.DialogResult.Yes Then
                                RichLogs(" skiping  " & arg(1), Color.LimeGreen, False, True)
                            Else
                                DirectISP.SharedUI.DirectISPWorker.WorkerReportsProgress = True
                                DirectISP.SharedUI.DirectISPWorker.WorkerSupportsCancellation = True
                                If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                                    Application.DoEvents()
                                    DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                                    'waitEvent.WaitOne()
                                    Thread.Sleep(300)
                                End If
                                Dim richTextBox24 As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
                                richTextBox24.Text = String.Concat(richTextBox24.Text, "done" & vbCrLf & "")
                            End If
                            Dim files As String() = Directory.GetFiles(FileSystem.CurDir(), "*", SearchOption.AllDirectories)
                            Dim num2 As Integer = 0
                            While num2 < CInt(files.Length)
                                Dim str3 As String = files(num2)
                                If str3.Contains("unsparse.img") Then
                                    MyProject.Computer.FileSystem.DeleteFile(str3)
                                End If
                                num2 = num2 + 1
                            End While
                        End If
                        num = num + 1
                        DirectISP.SharedUI.PB2(CInt(Math.Round(CDbl(num * 100) / CDbl(Totaltodo))))
                    End If

                End If
            End While
        End Using
    End Sub

    Public Shared Sub ekse(ByVal offset As Long, ByVal count As Long, ByVal buffer As Byte())
        Dim _streamer As emmc.streamer = emmc.CreateStream(String.Concat("\\.\PHYSICALDRIVE", selecteddisk), FileAccess.ReadWrite)
        Try
            Try
                emmc.WriteSector(offset, CInt(count), buffer, _streamer)
                DirectISP.SharedUI.lb2(String.Concat(" 0x00", Conversion.Hex(offset)))
            Catch exception As System.Exception
                Console.WriteLine(exception.ToString())
                cekerror = True
            End Try
        Finally
            emmc.DropStream(_streamer)
        End Try
    End Sub

    Public Shared Sub erases()
        Dim enumerator As IEnumerator = Nothing
        Dim num As Integer = 0
        If ListView1.CheckedItems.Count <> 0 Then
            Try
                enumerator = ListView1.CheckedItems.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                    Dim count As Integer = ListView1.CheckedItems.Count
                    poffsets = Conversions.ToLong(current.SubItems(3).Text)
                    If Conversions.ToDouble(current.SubItems(2).Text) <> 0 Then
                        psize = Conversions.ToLong(current.SubItems(2).Text)
                    Else
                        psize = Conversions.ToLong(Operators.SubtractObject(uks, current.SubItems(3).Text))
                    End If
                    pname = current.SubItems(1).Text
                    Dim richTextBox2 As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
                    Dim richTextBox As System.Windows.Forms.RichTextBox = richTextBox2
                    richTextBox2.Text = String.Concat(richTextBox.Text, "erasing ", pname, "...")
                    DirectISP.SharedUI.DirectISPWorker.WorkerReportsProgress = True
                    DirectISP.SharedUI.DirectISPWorker.WorkerSupportsCancellation = True
                    If Not DirectISP.SharedUI.DirectISPWorker.IsBusy Then
                        Application.DoEvents()
                        DirectISP.SharedUI.DirectISPWorker.RunWorkerAsync()
                        'waitEvent.WaitOne()
                        Thread.Sleep(300)
                    End If
                    Dim richTextBox21 As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
                    richTextBox21.Text = String.Concat(richTextBox21.Text, "done" & vbCrLf & "")
                    num = num + 1
                    Dim num1 As Double = CDbl(num * 100) / CDbl(count)
                    DirectISP.SharedUI.PB2(CInt(Math.Round(num1)))
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Dim richTextBox1 As System.Windows.Forms.RichTextBox = DirectISP.SharedUI.RichTextBox2
            richTextBox1.Text = String.Concat(richTextBox1.Text, "All done" & vbCrLf & "")
            DirectISP.SharedUI.PB2(0)
        End If
    End Sub

    Public Shared Sub DirectISPWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Console.WriteLine("DoWork Start....")
        Dim num As Double
        Dim richTextBox As System.Windows.Forms.RichTextBox
        Dim num1 As Long = filesize
        Dim num2 As Long = filesize
        Dim length As Long = (New FileInfo(openfile)).Length
        Dim num3 As Long = CLng(1048576)
        Dim num4 As Integer = CInt(Math.Round(CDbl(num2) / CDbl(num3)))
        Dim num5 As Long = CLng(0)
        Dim fileStream As System.IO.FileStream = New System.IO.FileStream(openfile, FileMode.Open, FileAccess.Read)
        Try
            Try
                Dim i As Long = CLng(0)
                Using fileStream
                    If (Operators.CompareString(m, "saveformat", False) = 0) Then
                        num3 = length
                        Dim numArray(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                        fileStream.Read(numArray, 0, CInt(num3))
                        ekse(miscpart, num3, numArray)
                    End If
                    If (Operators.CompareString(m, "frp", False) = 0) Then
                        num3 = dawane
                        Dim numArray1(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                        ekse(configpart, num3, numArray1)
                    End If
                    If (Operators.CompareString(m, "micloudmtk1", False) = 0) Then
                        num3 = dawane
                        Dim numArray2(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                        ekse(configpart, num3, numArray2)
                    End If
                    If (Operators.CompareString(m, "micloudmtk2", False) = 0) Then
                        num3 = dawane
                        Dim numArray3(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                        ekse(configpart, num3, numArray3)
                    End If
                    If (Operators.CompareString(m, "factreset", False) = 0) Then
                        Dim richTextBox2 As System.Windows.Forms.RichTextBox = richTextBox2
                        richTextBox2.Text = String.Concat(richTextBox2.Text, "writing userdata")
                        Dim num6 As Double = CDbl(length) / CDbl(num3)
                        num6 = Conversion.Int(num6)
                        Dim num7 As Long = CLng(Math.Round(num6))
                        For i = CLng(0) To num7 Step CLng(1)
                            If (CDbl(i) = num6) Then
                                num3 = CLng(Math.Round(CDbl(length) - num6 * CDbl(num3)))
                                If (num3 = CLng(0)) Then
                                    Exit For
                                End If
                            End If
                            Dim numArray4(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                            Dim num8 As Long = i * num3
                            Dim num9 As Long = startsecpart + num8
                            karung = num9
                            fileStream.Read(numArray4, 0, CInt(num3))
                            'Label5.Text = "writing userdata"
                            ekse(num9, num3, numArray4)
                            num = If(num6 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(length), 100)
                            DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                            fileStream.Flush()
                        Next

                    End If
                    If (Operators.CompareString(m, "p", False) = 0) Then
                        num3 = CLng(1048576)
                        Dim num10 As Double = CDbl(psize) / CDbl(num3)
                        num10 = Conversion.Int(num10)
                        fileStream.Position = poffsets
                        RichLogs("writing... " & pname, Color.WhiteSmoke, False, False)
                        Dim num11 As Long = CLng(Math.Round(num10))
                        For i = CLng(0) To num11 Step CLng(1)
                            If (CDbl(i) = num10) Then
                                num3 = CLng(Math.Round(CDbl(psize) - num10 * CDbl(num3)))
                                If (num3 = CLng(0)) Then
                                    Exit For
                                End If
                            End If
                            Dim numArray5(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                            Dim num12 As Long = i * num3
                            Dim num13 As Long = poffsets + num12
                            karung = num13
                            fileStream.Read(numArray5, 0, CInt(num3))
                            ekse(num13, num3, numArray5)
                            'Label5.Text = String.Concat("Writing ", pname)
                            If (num10 <> 0) Then
                                num = If(num10 <> 1, CDbl((i * num3 * CLng(100))) / CDbl(psize), 100)
                            Else
                                num = 100
                            End If
                            DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                            fileStream.Flush()
                        Next

                    End If
                    If (Operators.CompareString(m, "f", False) = 0) Then
                        num4 = CInt(Math.Round(CDbl(length) / CDbl(num3)))
                        num4 = Conversion.Int(num4)
                        Dim num14 As Long = CLng(num4)
                        For i = CLng(0) To num14 Step CLng(1)
                            If (i = CLng(num4)) Then
                                num3 = length - CLng(num4) * num3
                                If (num3 = CLng(0)) Then
                                    Exit For
                                End If
                            End If
                            offset = i * num3
                            karung = offset
                            Dim numArray6(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                            fileStream.Read(numArray6, 0, CInt(num3))
                            ekse(offset, num3, numArray6)
                            num = If(num4 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(length), 100)
                            DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                            fileStream.Flush()
                        Next

                    End If
                    If (Operators.CompareString(m, "erase", False) = 0) Then
                        num3 = CLng(1048576)
                        Dim num15 As Double = CDbl(psize) / CDbl(num3)
                        num15 = Conversion.Int(num15)
                        Dim num16 As Long = CLng(Math.Round(num15))
                        i = CLng(0)
                        While i <= num16
                            If (CDbl(i) = num15) Then
                                num3 = CLng(Math.Round(CDbl(psize) - num15 * CDbl(num3)))
                            End If
                            If (num3 <> CLng(0)) Then
                                Dim numArray7(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                                berapakali = i * num3
                                Dim num17 As Long = poffsets + berapakali
                                'Label5.Text = String.Concat("erasing ", pname)
                                ekse(num17, num3, numArray7)
                                num = If(num15 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(psize), 100)
                                DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                                i = i + CLng(1)
                            Else
                                Exit While
                            End If
                        End While
                    End If
                    If (Operators.CompareString(m, "wp", False) = 0) Then
                        If (Operators.CompareString(asu, "inisparse", False) = 0) Then
                            RichLogs("writing " & partname, Color.WhiteSmoke, False, False)
                            Dim num18 As Long = Conversions.ToLong(sentot)
                            Dim num19 As Double = CDbl(filesize) / CDbl(num3)
                            num19 = Conversion.Int(num19)
                            Dim num20 As Long = CLng(Math.Round(num19))
                            For i = CLng(0) To num20 Step CLng(1)
                                If (CDbl(i) = num19) Then
                                    num3 = CLng(Math.Round(CDbl(filesize) - num19 * CDbl(num3)))
                                    If (num3 = CLng(0)) Then
                                        Exit For
                                    End If
                                End If
                                Dim numArray8(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                                Dim num21 As Long = i * num3 + num18
                                karung = num21
                                fileStream.Read(numArray8, 0, CInt(num3))
                                'Label5.Text = String.Concat("writing ", partname)
                                ekse(num21, num3, numArray8)
                                num = If(num19 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(filesize), 100)
                                DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                                fileStream.Flush()
                            Next

                        End If
                        If (Operators.CompareString(asu, "notsparse", False) = 0) Then
                            RichLogs("writing " & partname, Color.WhiteSmoke, False, False)
                            num4 = Conversion.Int(num4)
                            num3 = CLng(1048576)
                            Dim num22 As Long = CLng(num4)
                            For i = CLng(0) To num22 Step CLng(1)
                                If (i = CLng(num4)) Then
                                    num3 = filesize - CLng(num4) * num3
                                    If (num3 = CLng(0)) Then
                                        Exit For
                                    End If
                                End If
                                Dim num23 As Long = i * num3
                                Dim num24 As Long = awales + num23
                                Dim numArray9(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                                karung = num24
                                fileStream.Read(numArray9, 0, CInt(num3))
                                'Label5.Text = String.Concat("writing ", partname)
                                ekse(num24, num3, numArray9)
                                num = If(num4 <> 0, CDbl((i * num3 * CLng(100))) / CDbl(filesize), 100)
                                DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                                fileStream.Flush()
                            Next

                        End If
                    End If
                    If (Operators.CompareString(m, "erasefull", False) = 0) Then
                        Dim obj As Object = Operators.DivideObject(uks, num3)
                        Dim num25 As Long = Conversions.ToLong(obj)
                        For i = CLng(0) To num25 Step CLng(1)
                            If (Operators.ConditionalCompareObjectEqual(i, obj, False)) Then
                                num3 = Conversions.ToLong(Operators.SubtractObject(uks, Operators.MultiplyObject(obj, num3)))
                                If (num3 = CLng(0)) Then
                                    Exit For
                                End If
                            End If
                            Dim numArray10(CInt((num3 - CLng(1))) + 1 - 1) As Byte
                            Dim num26 As Long = i * num3
                            karung = num26
                            'Label2.Text = "erasing"
                            ekse(num26, num3, numArray10)
                            num5 = num5 + num3
                            num = If(Not Operators.ConditionalCompareObjectEqual(obj, 0, False), Conversions.ToDouble(Operators.DivideObject(num5 * CLng(100), uks)), 100)
                            DirectISP.SharedUI.DirectISPWorker.ReportProgress(CInt(Math.Round(num)))
                        Next

                    End If
                End Using
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                'Label1.Text = String.Concat("Error: at ", Conversions.ToString(karung))
                ProjectData.ClearProjectError()
            End Try
        Finally
            fileStream.Close()
            e.Cancel = True
        End Try
    End Sub

End Class
