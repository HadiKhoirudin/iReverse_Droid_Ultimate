'By : Hadi Khoirudin, S.Kom
Imports QC.QMSLPhone
Imports System
Imports System.Drawing
Imports System.Management
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.ComponentModel

Public Module EFS

#Region "UI Function"

    Public Sub BtnADBEnableDiag_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            EFSCommand = GetButtonText(sender)
            RtbClear()
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(EFSCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnADBEnableDiagXiaomi_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            EFSCommand = GetButtonText(sender)
            RtbClear()
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(EFSCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnBrowseQCN_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            Dim fd As New OpenFileDialog With {
                    .Title = "qcn",
                    .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                    .FileName = "*.*",
                    .Filter = "all file |*.qcn;*.xqcn ",
                    .FilterIndex = 2,
                    .RestoreDirectory = True
                }
            If fd.ShowDialog() = DialogResult.OK Then
                foldersave = fd.FileName
                Unlock.SharedUI.TxtQCN.Text = foldersave
            End If
        End If
    End Sub

    Public Sub BtnReadQCN_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            Dim folderDlg As New FolderBrowserDialog With {.ShowNewFolderButton = True}
            If folderDlg.ShowDialog() = DialogResult.OK Then
                foldersave = folderDlg.SelectedPath
                Unlock.SharedUI.TxtQCN.Text = foldersave
                EFSCommand = GetButtonText(sender)
                RtbClear()
                RichLogs("Operation  : ", Color.White, True, False)
                RichLogs(EFSCommand & vbCrLf, Color.Orange, True, True)
                Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
                Unlock.SharedUI.WorkerUnlock.Dispose()
            End If
        End If
    End Sub

    Public Sub BtnWriteQCN_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            EFSCommand = GetButtonText(sender)
            RtbClear()
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(EFSCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnQcReadIMEI_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            EFSCommand = GetButtonText(sender)
            RtbClear()
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(EFSCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub
    Public Sub BtnQcWriteIMEI_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            If Not Unlock.SharedUI.cb_Qc_IMEI1.Checked AndAlso Not Unlock.SharedUI.cb_Qc_IMEI2.Checked Then
                RichLogs("Please Select Imei To write", Color.Red, False, True)
                Return
            End If
            If Unlock.SharedUI.cb_Qc_IMEI1.Checked AndAlso String.IsNullOrEmpty(Unlock.SharedUI.TxtQcIMEISub1.Text) Then
                RichLogs("Please insert imei 1", Color.Red, False, True)
                Return
            End If
            If Unlock.SharedUI.cb_Qc_IMEI2.Checked AndAlso String.IsNullOrEmpty(Unlock.SharedUI.TxtQcIMEISub2.Text) Then
                RichLogs("Please insert imei 2", Color.Red, False, True)
                Return
            End If
            EFSCommand = GetButtonText(sender)
            RtbClear()
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(EFSCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub TxtQcIMEI1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> vbBack AndAlso Not Char.IsNumber(e.KeyChar) Then
            MessageBox.Show(" Invalid Input ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            e.Handled = True
        End If
    End Sub

    Public Sub TxtQcIMEI2_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> vbBack AndAlso Not Char.IsNumber(e.KeyChar) Then
            MessageBox.Show(" Invalid Input ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            e.Handled = True
        End If
    End Sub

    Public Sub TxtQcIMEI1_EditValueChanged(sender As Object, e As EventArgs)
        Try
            Unlock.SharedUI.TxtQcIMEI1.Properties.MaxLength = 14
            Dim text As String = Unlock.SharedUI.TxtQcIMEI1.Text.ToUpper()
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
            Unlock.SharedUI.TxtQcIMEISub1.Text = ((10 - num3 Mod 10) Mod 10).ToString()
            Unlock.SharedUI.cb_Qc_IMEI1.Checked = True
            If Equals(Unlock.SharedUI.TxtQcIMEI1.Text, "") Then
                Unlock.SharedUI.cb_Qc_IMEI1.Checked = False
                Unlock.SharedUI.TxtQcIMEISub1.Text = "0"
            End If

        Catch
        End Try
    End Sub

    Public Sub TxtQcIMEI2_EditValueChanged(sender As Object, e As EventArgs)
        Try
            Unlock.SharedUI.TxtQcIMEI2.Properties.MaxLength = 14
            Dim text As String = Unlock.SharedUI.TxtQcIMEI2.Text.ToUpper()
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
            Unlock.SharedUI.TxtQcIMEISub2.Text = ((10 - num3 Mod 10) Mod 10).ToString()
            Unlock.SharedUI.cb_Qc_IMEI2.Checked = True
            If Equals(Unlock.SharedUI.TxtQcIMEI2.Text, "") Then
                Unlock.SharedUI.cb_Qc_IMEI2.Checked = False
                Unlock.SharedUI.TxtQcIMEISub2.Text = "0"
            End If

        Catch
        End Try
    End Sub

    Public Sub cb_SingleIMEI_CheckedChanged(sender As Object, e As EventArgs)
        If Unlock.SharedUI.cb_SingleIMEI.Checked Then
            IsDualIMEI = False
            Unlock.SharedUI.cb_Qc_IMEI2.Enabled = False
            Unlock.SharedUI.TxtQcIMEI2.Enabled = False
            Unlock.SharedUI.TxtQcIMEISub2.Enabled = False
        Else
            IsDualIMEI = True
            Unlock.SharedUI.cb_Qc_IMEI2.Enabled = True
            Unlock.SharedUI.TxtQcIMEI2.Enabled = True
            Unlock.SharedUI.TxtQcIMEISub2.Enabled = True
        End If
    End Sub
#End Region


#Region "EFS"
    Public IsDualIMEI As Boolean = True
    Public EFSCommand As String
    Public QCphone As New Phone()
    Public meid As String
    Public timeout As UInteger = 10000
    Public mac As String
    Public bta As String
    Public sn As String
    Public Sub EFSWorkerStart(sender As Object, e As DoWorkEventArgs)
        Watch.Start()

        If (EFSCommand = "[ADB] Enable Diag") Then
            AdbOpenDiag(sender, e)

        ElseIf (EFSCommand = "[ADB] Enable Diag Xiaomi") Then
            AdbOpenDiagXIAOMI(sender, e)

        ElseIf (EFSCommand = "READ QCN") Then
            ReadQCN()

        ElseIf (EFSCommand = "WRITE QCN") Then
            WriteQcnExec()

        ElseIf (EFSCommand = "READ IMEI") Then
            ReadIMEI()

        ElseIf (EFSCommand = "WRITE IMEI") Then
            WriteImeiExec()

        End If
    End Sub

    Public Sub EFSAllDone(sender As Object, e As RunWorkerCompletedEventArgs)
        EFSCommand = ""

        Delay(3)
        Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Text = "", Action))
        TimeSpanElapsed.ElapsedTime(Watch)
        Watch.Stop()
    End Sub
    Public Sub AdbOpenDiag(worker As BackgroundWorker, e As DoWorkEventArgs)
        ProcessBar1(0)
        ProcessBar1(50)
        AdbTool.SharedUI.adbcmd("shell setprop sys.usb.config diag", worker, e)
        ProcessBar1(80)
        ProcessBar1(100)
    End Sub
    Public Sub AdbOpenDiagXIAOMI(worker As BackgroundWorker, e As DoWorkEventArgs)
        ProcessBar1(0)
        ProcessBar1(50)
        AdbTool.SharedUI.adbcmd("shell am start -n com.longcheertel.midtest/com.longcheertel.midtest.Diag", worker, e)
        ProcessBar1(80)
        ProcessBar1(100)
    End Sub
    Public Sub WriteQcn()
        Try
            If Not IsConnect(10) Then
                Return
            End If
            Dim num As Integer = 0
            Dim num2 As Integer = -1
            QCphone.SetLibraryMode(0)
            RichLogs("Connect To server     : ", Color.WhiteSmoke, False, False)

            QCphone.ConnectToServer(PortCOM, timeout)

            RichLogs("OK", Color.Lime, False, True)

            RichLogs("Sending SPC : ", Color.WhiteSmoke, False, False)
            QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"))
            RichLogs("OK", Color.Lime, False, True)


            RichLogs("Loading Qcn From File : ", Color.WhiteSmoke, False, False)
            QCphone.LoadNVsFromQCN(Unlock.SharedUI.TxtQCN.Text, num, num2)
            RichLogs("OK", Color.Lime, False, True)
            Dim num3 As Integer = 10
            Dim flag As Boolean = False



            RichLogs("Writing EFS : ", Color.WhiteSmoke, False, False)
            Do While Not flag AndAlso num3 > 0
                num3 -= 1
                Try
                    QCphone.NV_WriteNVsToMobile(num2)
                    flag = True
                Catch ex As Exception
                    RichLogs(ex.ToString(), Color.Red, False, True)
                End Try
            Loop
            RichLogs("OK", Color.Lime, False, True)

            Dim flag2 As Boolean = Not flag
            If flag2 Then
                RichLogs("Fail", Color.Red, False, True)
            End If
            RichLogs("Sync EFS : ", Color.WhiteSmoke, False, False)
            QCphone.EFS_SyncWithWait(10000)
            RichLogs("OK", Color.Lime, False, True)

        Catch ex As Exception

            MessageBox.Show(ex.ToString())
        Finally
            QCphone.DisconnectServer()
        End Try
    End Sub
    Public Function IsConnect(ByVal tries As Integer) As Boolean
        Dim flag As Boolean = QCphone.IsPhoneConnected()
        Do While Not flag AndAlso tries > 0
            Thread.Sleep(1000)
            tries -= 1
            flag = QCphone.IsPhoneConnected()
        Loop
        Return flag
    End Function
    Public Sub WriteIMEI(ByVal imei As String, ByVal numimei As Integer)
        Try
            ProcessBar1(40)
            QCphone.SetLibraryMode(0)
            QCphone.ConnectToServer(PortCOM, timeout)
            QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"))

            ProcessBar1(80)
            If IsDualIMEI Then
                QCphone.WriteIMEI_DualSIM(imei, numimei)
            Else
                QCphone.WriteIMEI(imei)
            End If

            ProcessBar1(100)
        Catch ex As Exception
            If ex.Message.Contains("NV item is Read Only") Then
                RichLogs("Can't Write IMEI! NV item is Protected.", Color.Red, False, True)
                RichLogs("Please Backup QCN and then reset EFS Before Write IMEI.", Color.DarkOrange, False, True)
            End If
        Finally
            QCphone.DisconnectServer()
        End Try
    End Sub
    Public Sub WriteMEID(ByVal meid As String)
        Try
            ProcessBar1(40)
            QCphone.SetLibraryMode(0)
            QCphone.ConnectToServer(PortCOM, timeout)
            QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"))

            ProcessBar1(80)
            QCphone.WriteMEIDNumber(meid)

            ProcessBar1(100)
        Catch ex As Exception

        Finally
            QCphone.DisconnectServer()
        End Try
    End Sub

    Public Sub ReadQCN()
        Try
            ProcessBar1(40)

            RichLogs("Mencari Ports Diag : ", Color.WhiteSmoke, False, False)
            If Not ProcesCariPortDiags() Then
                ProcessBar1(100)
                Return
            End If

            ProcessBar1(60)
            QCphone.SetLibraryMode(0)
            QCphone.ConnectToServer(PortIO.PortCOM, timeout)
            Readinfo()
            Dim num As Integer = -1
            QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"))
            Thread.Sleep(50)
            ProcessBar1(80)
            RichLogs("", Color.WhiteSmoke, False, True)
            RichLogs("Reading NV network data, please wait ... ", Color.WhiteSmoke, False, True)
            QCphone.EnableQcnNvItemCallBacks()
            QCphone.EnableQcnNvItemCallBacks()
            ProcessBar1(90)
            QCphone.BackupNVFromMobileToQCN(foldersave & "\" & imei1 & "_" & imei2 & "-backup.qcn", num)

            RichLogs("Saved To : ", Color.WhiteSmoke, False, False)
            RichLogs(foldersave & "\" & imei1 & "_" & imei2 & "-backup.qcn", Color.WhiteSmoke, False, True)
            ProcessBar1(100)
        Catch

        Finally
            QCphone.DisableQcnNvItemCallBacks()
            QCphone.DisconnectServer()
        End Try
    End Sub
    Public Sub readSN()
        Dim sn = ""
        QCphone.ReadSN(sn)
    End Sub
    Public imei1 As String
    Public imei2 As String
    Public Sub ReadEmei()
        Dim imei_Info As Imei_Info = Nothing
        Dim imei_Info2 As Imei_Info = Nothing
        Try
            QCphone.ReadIMEI_DualSIM(imei_Info, 0)
            QCphone.ReadIMEI_DualSIM(imei_Info2, 1)
        Catch ex As Exception
            Throw New Exception(ex.ToString())
        End Try
        imei1 = imei_Info.imei
        imei2 = imei_Info2.imei
    End Sub
    Public macLoc As MACADD_Location
    Public Enum MACADD_Location

        AP_PERSIST

        NV4678
    End Enum
    Public nvitemtype As nv_items_enum_type = CType(4678, nv_items_enum_type)
    Public Sub ReadMac()
        Dim array(5) As Byte
        Dim strLength As Integer = 6
        Dim flag As Boolean = True
        Try
            macLoc = MACADD_Location.NV4678
            Dim flag2 As Boolean = macLoc = MACADD_Location.AP_PERSIST
            If flag2 Then
                array = QCphone.FTM_WLAN_GEN6_GET_MAC_ADDRESS()
            Else
                Dim flag3 As Boolean = macLoc = MACADD_Location.NV4678
                If flag3 Then
                    QCphone.NVRead(nvitemtype, array, 128)
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.ToString())
        End Try
        Dim flag4 As Boolean = flag
        If flag4 Then
            ConvertByteArrayToHexString(array, strLength, mac)
        End If
    End Sub
    Public Sub ConvertByteArrayToHexString(ByteArrayIn As Byte(), StrLength As Integer, <System.Runtime.InteropServices.OutAttribute()> ByRef StringOut As String)
        Dim array As String() = New String(StrLength - 1) {}
        Dim array2 As String() = New String(1) {}
        StringOut = ""
        For i As Integer = 0 To StrLength - 1
            Dim flag As Boolean = ByteArrayIn IsNot Nothing AndAlso ByteArrayIn.Length > i
            If flag Then
                Dim b As Byte = Convert.ToByte(ByteArrayIn(i))
                Dim value As Byte = Convert.ToByte(CInt((b And 15)))
                Dim value2 As Byte = Convert.ToByte((b And 240) >> 4)
                array2(0) = Convert.ToString(value, 16)
                array2(1) = Convert.ToString(value2, 16)
                StringOut = StringOut + array2(1).ToUpper() + array2(0).ToUpper()
            End If
        Next
    End Sub


    Public skl As nv_items_enum_type = CType(447, nv_items_enum_type)
    Public Sub ReadBTa()
        Dim flag As Boolean = True
        Dim array As Byte() = New Byte(5) {}
        Dim array2 As Byte() = New Byte(5) {}
        Dim array3 As String() = New String(5) {}
        Dim num As Integer = 6
        Try
            QCphone.NVRead(skl, array, 128S)
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.ToString())
        End Try
        Dim flag2 As Boolean = flag
        If flag2 Then
            Dim i As Integer = 0
            Dim num2 As Integer = num - 1
            While i <= num - 1
                array2(i) = array(num2)
                i += 1
                num2 -= 1
            End While
            ConvertByteArrayToHexString(array2, num, bta)
            bta = bta.ToUpper()
        End If
    End Sub

    Public Sub Readinfo()
        Try
            readSN()
            ReadMeid()
            ReadEmei()
            ReadMac()
            ReadBTa()
            Dim msg As String
            Dim text As String
            QCphone.GetPhoneVersionInfo(msg, text)
            Dim msg2 As String
            QCphone.ReadTrackingInfo(msg2)
            RichLogs("", Color.WhiteSmoke, False, True)
            RichLogs("Reading selected port info ... ", Color.WhiteSmoke, False, True)
            RichLogs("Software Version : " & vbCrLf & msg, Color.WhiteSmoke, False, True)
            RichLogs("MEID " & vbTab & ": " & meid, Color.WhiteSmoke, False, True)
            RichLogs("IMEI 1 " & vbTab & ": " & imei1, Color.WhiteSmoke, False, True)
            RichLogs("IMEI 2 " & vbTab & ": " & imei2, Color.WhiteSmoke, False, True)
            RichLogs("MAC " & vbTab & ": " & mac, Color.WhiteSmoke, False, True)
            RichLogs("BTA " & vbTab & ": " & bta, Color.WhiteSmoke, False, True)
            RichLogs("", Color.WhiteSmoke, False, True)
        Catch ex As Exception
            RichLogs(ex.Message, Color.Red, False, True)
        End Try
    End Sub
    Public meid_Info As Meid_Info
    Public Sub ReadMeid()

        QCphone.ReadMEID(meid_Info)
        meid = meid_Info.RR & meid_Info.MAC & meid_Info.SNR
    End Sub

    Public Function CariPortsDiag() As Boolean

        Try
            Dim searcher As New ManagementObjectSearcher("root\cimv2", "SELECT * FROM Win32_PnPEntity  WHERE Name LIKE '%Diagnostics%'  ")
            For Each queryObj As ManagementObject In searcher.Get()

                Dim portNameData = queryObj("Name").ToString()
                Dim comPortNumber = queryObj("Name").ToString().Substring(queryObj("Name").ToString().IndexOf("(COM") + 4)
                comPortNumber = comPortNumber.TrimEnd(")"c)
                PortCOM = Convert.ToInt32(comPortNumber)
                Main.SharedUI.ComboPort.Invoke(CType(Sub() Main.SharedUI.ComboPort.Text = portNameData, Action))

                RichLogs("Found at COM" & PortCOM, Color.DarkOrange, False, True)
                Return True

            Next queryObj
            Return False
        Catch err As ManagementException
            MessageBox.Show("An error occurred while querying for WMI data: " & err.Message)
            Return False
        End Try
    End Function
    Public Function ProcesCariPortDiags() As Boolean
        Setwaktu()
        Main.SharedUI.LabelTimer.Invoke(CType(Sub() Main.SharedUI.LabelTimer.Visible = True, Action))
        Dim i As Integer = 0
        Do While i <= WaktuCari
            If CariPortsDiag() Then
                Return True
            End If
            Thread.Sleep(1000)
            WaktuCari -= 1
            If WaktuCari = 0 Then
                RichLogs("Not Found", Color.Red, False, True)
                Main.SharedUI.LabelTimer.Invoke(CType(Sub() Main.SharedUI.LabelTimer.Text = WaktuCari.ToString(), Action))
                Main.SharedUI.LabelTimer.Invoke(CType(Sub() Main.SharedUI.LabelTimer.Visible = False, Action))
                Return False
            End If
            Main.SharedUI.LabelTimer.Invoke(CType(Sub() Main.SharedUI.LabelTimer.Text = WaktuCari.ToString(), Action))
            i += 1
        Loop
        Main.SharedUI.LabelTimer.Invoke(CType(Sub() Main.SharedUI.LabelTimer.Visible = False, Action))
        RichLogs("Not Found", Color.Red, False, True)
        Return False
    End Function

    Public Sub WriteQcnExec()
        RichLogs("Searching Ports Diag : ", Color.WhiteSmoke, False, False)

        ProcessBar1(20)

        If Not ProcesCariPortDiags() Then
            Return
        End If

        ProcessBar1(40)
        Try

            Dim num As Integer = 0
            Dim num2 As Integer = -1
            QCphone.SetLibraryMode(0)
            RichLogs("Connect To server     : ", Color.WhiteSmoke, False, False)
            QCphone.ConnectToServer(PortCOM, timeout)
            RichLogs("OK", Color.Lime, False, True)

            ProcessBar1(60)
            If Not IsConnect(10) Then
                ProcessBar1(100)
                Return
            End If
            Readinfo()
            ProcessBar1(70)
            RichLogs("Sending SPC : ", Color.WhiteSmoke, False, False)
            QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"))
            RichLogs("OK", Color.Lime, False, True)


            ProcessBar1(80)
            RichLogs("Loading Qcn From File : ", Color.WhiteSmoke, False, False)
            QCphone.LoadNVsFromQCN(Unlock.SharedUI.TxtQCN.Text, num, num2)
            RichLogs("OK", Color.Lime, False, True)
            Dim num3 As Integer = 10
            Dim flag As Boolean = False

            RichLogs("Writing EFS : ", Color.WhiteSmoke, False, False)
            Do While Not flag AndAlso num3 > 0
                num3 -= 1
                Try
                    QCphone.NV_WriteNVsToMobile(num2)
                    flag = True
                Catch ex As Exception
                    RichLogs(ex.ToString(), Color.Red, False, True)
                End Try
            Loop

            ProcessBar1(90)
            RichLogs("OK", Color.Lime, False, True)

            Dim flag2 As Boolean = Not flag
            If flag2 Then
                RichLogs("Fail", Color.Red, False, True)
                ProcessBar1(100)
            End If
            RichLogs("Sync EFS : ", Color.WhiteSmoke, False, False)
            QCphone.EFS_SyncWithWait(10000)
            RichLogs("OK", Color.Lime, False, True)

            ProcessBar1(100)
        Catch ex As Exception
            RichLogs(ex.ToString(), Color.Red, False, True)
        Finally
            QCphone.DisconnectServer()
        End Try

    End Sub
    Public Sub WriteImeiExec()
        RichLogs("Mencari Ports Diag : ", Color.WhiteSmoke, False, False)

        ProcessBar1(40)
        Dim OK As Boolean = False

        If Not ProcesCariPortDiags() Then
            ProcessBar1(100)
            Return
        End If

        ProcessBar1(60)

        Try
            ProcessBar1(70)
            QCphone.SetLibraryMode(0)
            QCphone.ConnectToServer(PortCOM, timeout)

            Readinfo()
            QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"))

            ProcessBar1(80)
            If Unlock.SharedUI.cb_Qc_IMEI1.Checked Then
                Dim IMEI1 As String = String.Concat(Unlock.SharedUI.TxtQcIMEI1.Text, Unlock.SharedUI.TxtQcIMEISub1)
                WriteIMEI(IMEI1, 0)
            End If

            ProcessBar1(90)
            If Unlock.SharedUI.cb_Qc_IMEI2.Checked Then
                Dim IMEI2 As String = String.Concat(Unlock.SharedUI.TxtQcIMEI1.Text, Unlock.SharedUI.TxtQcIMEISub1)
                WriteIMEI(IMEI2, 1)
            End If

            ProcessBar1(100)

        Catch ex As Exception

            RichLogs(ex.ToString(), Color.Red, False, True)
        Finally
            QCphone.DisconnectServer()
        End Try

    End Sub

    Public Sub ReadIMEI()
        RichLogs("Searching Ports Diag : ", Color.WhiteSmoke, False, False)

        ProcessBar1(0)
        If Not ProcesCariPortDiags() Then
            Return
        End If

        ProcessBar1(80)
        Try

            Dim num As Integer = 0
            Dim num2 As Integer = -1
            QCphone.SetLibraryMode(0)
            RichLogs("Connect To server     : ", Color.WhiteSmoke, False, False)
            QCphone.ConnectToServer(PortCOM, timeout)
            RichLogs("OK", Color.Lime, False, True)

            If Not IsConnect(10) Then
                Return
            End If
            Readinfo()
            Unlock.SharedUI.TxtQcIMEI1.Invoke(CType(Sub() Unlock.SharedUI.TxtQcIMEI1.Text = imei1.Substring(0, 14), Action))
            Unlock.SharedUI.TxtQcIMEISub1.Invoke(CType(Sub() Unlock.SharedUI.TxtQcIMEISub1.Text = imei2.Substring(14), Action))
            Unlock.SharedUI.TxtQcIMEI2.Invoke(CType(Sub() Unlock.SharedUI.TxtQcIMEI2.Text = imei2.Substring(0, 14), Action))
            Unlock.SharedUI.TxtQcIMEISub2.Invoke(CType(Sub() Unlock.SharedUI.TxtQcIMEISub2.Text = imei2.Substring(14), Action))

            ProcessBar1(100)

        Catch ex As Exception

            RichLogs(ex.ToString(), Color.Red, False, True)
        Finally
            QCphone.DisconnectServer()
        End Try

    End Sub



#End Region

End Module

