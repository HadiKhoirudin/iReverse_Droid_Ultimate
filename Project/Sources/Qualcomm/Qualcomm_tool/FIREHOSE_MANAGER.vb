
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Management
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports DevExpress.XtraEditors
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Reverse_Tool.Bismillah.DISK.DiskWriter
Imports Reverse_Tool.Bismillah.FIREHOSE.PACKET
Imports Reverse_Tool.Bismillah.SAHARA
Imports Reverse_Tool.HexOperation
Imports Reverse_Tool.CryptoOperation

Namespace Bismillah.FIREHOSE
    Public Class FIREHOSE_MANAGER
        Public Shared Booln As Boolean
        Friend Shared WithEvents CariPortQcom As New Windows.Forms.Timer()
        Public Shared saharaManager As SAHARA_MANAGER
        Public Shared QcomWorker As New BackgroundWorker()

        Public Shared keyEncrypt As String = "BabiBangsad"
        Public Shared MenuEx As MenuEksekusi = MenuEksekusi.manual
        Public Shared MenuManual As String
        Public Shared datafile As String
        Public Shared MerkTerpilih As String = ""
        Public Shared DevicesTerpilih As String = ""
        Public Shared TypeTerpilih As String = ""
        Public Shared loader As Byte() = New Byte(-1) {}
        Public Shared OutDecripted As Byte() = New Byte(-1) {}
        Public Shared PortQcom As Integer = 0
        Public Shared SectorSize As String = "512"
        Public Shared TypeMemory As String = "emmc"
        Public Shared URL As String = "hahaha"

        Public Const SPARSE_DONT_CARE As Long = 969411L
        Public Const SPARSE_FILL_CHUNK As Long = 969410L
        Public Const SPARSE_MAGIC As Long = 64108298042L
        Public Const SPARSE_RAW_CHUNK As Long = 969409L

        Public Shared ListLastSector As New ListBox()
        Public Shared ListPartitionName As New ListBox()
        Public Shared listPhysicalPartition As New ListBox()
        Public Shared listSectorSize As New ListBox()
        Public Shared ListStartSector As New ListBox()
        Public Shared Mode As DeviceMode
        Public Shared skipbyte As Integer = 0
        Public Shared tanggalexpired As String = ""
        Public Shared TextLOGS As TextBox
        Public Shared sendingloaderStatus As Boolean = False

        Public Shared bta As String
        Public Shared CheckKelar As Integer
        Public Shared chunkheader As CHUNK_HEADER
        Public Shared ReadOnly DeviceExist As Boolean
        Public Shared DoubleBytes As Double
        Public Shared EncryptedDownloadData As Byte()
        Public Shared ReadOnly EncryptedLoader As Boolean
        Public Shared gettypehpnya As Windows.Forms.ComboBox
        Public Shared foldersave As String
        Public Shared gpt As FIREHOSE_GPT
        Public Shared ReadOnly Kuning As Object
        Public Shared ReadOnly Merah As Object
        Public Shared NumDigestsFound As Long
        Public Shared server As String
        Public Shared serverFolderFile As String
        Public Shared xmlpatch As String
        Public Shared sparseheader As SPARSE_HEADER
        Public Shared ReadOnly timeout As UInteger
        Public Shared tot As Integer
        Public Shared totalchecked As Integer
        Public Shared totalchunk As Integer
        Public Shared WaktuCari As Integer

        Public Shared lb As New ListBox()
        Public Shared PatchString As String
        Public Shared LoadFolderXml As String
        
        Public Shared StringXml As String
        Public Shared FilesOneClick As Byte()
        Public Shared portsfound As Boolean
        Public Enum MenuEksekusi
            manual
            oneclick
        End Enum

        Public Enum DeviceMode
            sahara
            firehose
        End Enum

        Public Structure SPARSE_HEADER
            Public dwMagic As Integer
            Public wVerMajor As Short
            Public wVerMinor As Short
            Public wSparseHeaderSize As Short
            Public wChunkHeaderSize As Short
            Public dwBlockSize As Integer
            Public dwTotalBlocks As Integer
            Public dwTotalChunks As Integer
            Public dwImageChecksum As Integer
        End Structure

        Public Structure CHUNK_HEADER
            Public wChunkType As Short
            Public wReserved As Short
            Public dwChunkSize As Integer
            Public dwTotalSize As Integer
        End Structure

        Public Structure FIREHOSE_GPT
            Public header As gpt_header

            Public entries As List(Of gpt_partition_entry)
        End Structure

        Public Structure gpt_header
            Public signature As String
            Public revision As Integer
            Public header_size As Integer
            Public crc_header As Integer
            Public reserved As Integer
            Public current_lba As Integer
            Public backup_lba As Integer
            Public first_usable_lba As Integer
            Public last_usable_lba As Long
            Public disk_guid As Byte()
            Public starting_lba_pe As Integer
            Public number_partitions As Integer
            Public size_partition_entries As Integer
            Public ReadOnly crc_partition As Integer
            Public ReadOnly reserved2 As Byte
        End Structure

        Public Structure gpt_partition_entry
            Public ReadOnly Property num512Sectors As Integer
                Get
                    Return last_lba - first_lba + 1
                End Get
            End Property

            Public partTypeGUID As String
            Public partID As String
            Public first_lba As Integer
            Public last_lba As Integer
            Public flags As Byte()
            Public partName As String

        End Structure

        Public Shared Function getfilenames(label As String) As String
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
            ElseIf label = "keymaster" And SAHARA_MANAGER.cpu64 Then
                Return "keymaster64.mbn"
            ElseIf label = "keymasterbak" And SAHARA_MANAGER.cpu64 Then
                Return "keymasterbak64.mbn"
            ElseIf label = "keymaster" And Not SAHARA_MANAGER.cpu64 Then
                Return "keymaster.mbn"
            ElseIf label = "keymasterbak" And Not SAHARA_MANAGER.cpu64 Then
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
        Public Shared Function getfile(namafile As String, pbar As Boolean) As Byte()
            Dim s As String = String.Concat(New String() {"username=" & Main.username, "&password=" & Main.password, "&merk=", MerkTerpilih.ToUpper(), "&type=", TypeTerpilih, "&file=", namafile})
            Dim requestUriString As String = "http://localhost/iReverseWebsite/api/download.php"
            Dim result As Byte()
            Try
                Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(requestUriString), HttpWebRequest)
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(s)
                httpWebRequest.Method = "POST"
                httpWebRequest.Timeout = 600000
                httpWebRequest.ContentType = "application/x-www-form-urlencoded"
                httpWebRequest.ContentLength = bytes.Length
                Using requestStream As Stream = httpWebRequest.GetRequestStream()
                    requestStream.Write(bytes, 0, bytes.Length)
                End Using
                Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Dim num As Double = httpWebResponse.ContentLength
                Dim array As Byte() = New Byte(CInt(Math.Round(num - 1.0)) + 1 - 1) {}
                Dim buffer As Byte() = New Byte(4095) {}
                Using memoryStream As New MemoryStream(array)
                    Dim num2 As Integer = httpWebResponse.GetResponseStream().Read(buffer, 0, 4096)
                    memoryStream.Write(buffer, 0, num2)
                    While num2 <> 0
                        Dim num3 As Integer
                        num3 += num2
                        num2 = httpWebResponse.GetResponseStream().Read(buffer, 0, 4096)
                        memoryStream.Write(buffer, 0, num2)
                        If pbar Then
                            ProcessBar1(num3, Math.Round(num))
                        End If
                    End While
                End Using
                httpWebResponse.GetResponseStream().Close()
                result = array
            Catch ex As Exception
                result = New Byte(-1) {}
            End Try
            Return result
        End Function
        Public Shared Function getautoloader(namafile As String, pbar As Boolean) As Byte()
            Dim s As String = String.Concat(New String() {"username=" & Main.username, "&password=" & Main.password, "&namafile=", namafile})
            Dim requestUriString As String = "http://localhost/iReverseWebsite/api/autoloader.php"
            Dim result As Byte()
            Try
                Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(requestUriString), HttpWebRequest)
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(s)
                httpWebRequest.Method = "POST"
                httpWebRequest.Timeout = 600000
                httpWebRequest.ContentType = "application/x-www-form-urlencoded"
                httpWebRequest.ContentLength = bytes.Length
                Using requestStream As Stream = httpWebRequest.GetRequestStream()
                    requestStream.Write(bytes, 0, bytes.Length)
                End Using
                Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Dim num As Double = httpWebResponse.ContentLength
                Dim array As Byte() = New Byte(CInt(Math.Round(num - 1.0)) + 1 - 1) {}
                Dim buffer As Byte() = New Byte(4095) {}
                Using memoryStream As New MemoryStream(array)
                    Dim num2 As Integer = httpWebResponse.GetResponseStream().Read(buffer, 0, 4096)
                    memoryStream.Write(buffer, 0, num2)
                    While num2 <> 0
                        Dim num3 As Integer
                        num3 += num2
                        num2 = httpWebResponse.GetResponseStream().Read(buffer, 0, 4096)
                        memoryStream.Write(buffer, 0, num2)
                        If pbar Then
                            ProcessBar1(num3, Math.Round(num))
                        End If
                    End While
                End Using
                httpWebResponse.GetResponseStream().Close()
                result = array
            Catch ex As Exception
                result = New Byte(-1) {}
            End Try
            Return result
        End Function

        Public Shared Sub RtbClear()
            Main.SharedUI.RichTextBox.Invoke(Sub()
                                                 Main.SharedUI.RichTextBox.Clear()
                                             End Sub)
        End Sub
        Public Shared Sub Setwaktu()
            WaktuCari = 60
        End Sub

        Public Shared Function GetInfDrive() As Boolean
            Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
            Try
                Try
                    enumerator = New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=""{4d36e978-e325-11ce-bfc1-08002be10318}"" and Name LIKE '%Qualcomm HS-USB QDLoader 9008%'").[Get]().GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As ManagementObject = DirectCast(enumerator.Current, ManagementObject)
                        RichLogs("Download Port" & vbTab & vbTab & ":  ", Color.White, True, False)
                        RichLogs(String.Concat(current.GetPropertyValue("Name").ToString()), Color.Orange, True, True)
                        Booln = True
                        RichLogs("Driver Manufacturer" & vbTab & ":  ", Color.White, True, False)
                        RichLogs(String.Concat(current.GetPropertyValue("Manufacturer").ToString()), Color.Red, True, True)
                        RichLogs("USB HWID" & vbTab & vbTab & ":  ", Color.White, True, False)
                        RichLogs(String.Concat(current.GetPropertyValue("DeviceID").ToString()), Color.White, True, True)
                        RichLogs("Class Guid" & vbTab & vbTab & ":  ", Color.White, True, False)
                        RichLogs(String.Concat(current.GetPropertyValue("ClassGuid").ToString()), Color.White, True, True)
                        RichLogs("Driver Status" & vbTab & vbTab & ":  ", Color.White, True, False)
                        RichLogs(String.Concat(current.GetPropertyValue("Status").ToString()), Color.LimeGreen, True, True)
                        RichLogs("Connection Status" & vbTab & ":  ", Color.White, True, False)
                        RichLogs("XHCI:HUB:USB 2.00 ", Color.Orange, True, False)
                        RichLogs("High-Speed" & vbCrLf & "", Color.LimeGreen, True, False)
                    End While
                Finally
                    If enumerator IsNot Nothing Then
                        DirectCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
            Catch exception As Exception
                ProjectData.SetProjectError(exception)
                Booln = False
                ProjectData.ClearProjectError()
            End Try
            Return Booln
        End Function
        Public Shared Function GetFileSize(TheSize As Long) As String
            Dim str As String
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

        Public Shared Sub CariPortQcom_Tick(sender As Object, e As EventArgs) Handles CariPortQcom.Tick
            If Not QcomWorker.IsBusy Then
                QcomWorker.RunWorkerAsync()
            End If
        End Sub
        Public Shared Function CariPorts() As Boolean
            Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
            Try
                Using managementObjectSearcher As New ManagementObjectSearcher("root\cimv2", "SELECT * FROM Win32_PnPEntity  WHERE Name LIKE '%9008%'  ")
                    enumerator = managementObjectSearcher.[Get]().GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As ManagementObject = DirectCast(enumerator.Current, ManagementObject)
                        CariPortQcom.[Stop]()
                        Dim str As String = current("Name").ToString()
                        Dim str1 As String = current("Name").ToString().Substring(current("Name").ToString().IndexOf("(COM") + 4)
                        PortQcom = Conversions.ToInteger(str1.TrimEnd(New Char() {")"c}))

                        Main.SharedUI.ComboPort.Invoke(Sub()
                                                           Main.SharedUI.ComboPort.Text = str
                                                       End Sub)

                        RichLogs(String.Concat("Found at COM", Conversions.ToString(PortQcom)), Color.Yellow, True, True)
                        Return True
                    End While
                End Using
            Catch managementException1 As ManagementException
                ProjectData.SetProjectError(managementException1)
                Dim managementException As ManagementException = managementException1
                MessageBox.Show(String.Concat("An error occurred while querying for WMI data: ", managementException.Message))
                ProjectData.ClearProjectError()
            End Try
            Return False
        End Function
        Public Shared Sub CariPortsDone(sender As Object, e As RunWorkerCompletedEventArgs)
            If portsfound Then
                If Not QcomWorker.IsBusy Then
                    QcomWorker = New BackgroundWorker()
                    QcomWorker.WorkerSupportsCancellation = True
                    AddHandler QcomWorker.DoWork, AddressOf sendingLoader
                    AddHandler QcomWorker.RunWorkerCompleted, AddressOf sendingloaderDone
                    AddHandler QcomWorker.ProgressChanged, AddressOf ProcessSendingLoader
                    QcomWorker.RunWorkerAsync()
                    QcomWorker.Dispose()
                    GetInfDrive()
                Else
                    RichLogs("Worker Flash is Busy", Color.Yellow, True, True)
                End If
            End If
        End Sub
        Public Shared Sub sendingLoader(sender As Object, e As DoWorkEventArgs)
            Thread.Sleep(500)
            Thread.Sleep(500)
            saharaManager = New SAHARA_MANAGER()
        End Sub

        Public Shared Sub sendingloaderDone(sender As Object, e As RunWorkerCompletedEventArgs)
            If Not sendingloaderStatus Then
                RichLogs("Done With Error", Color.Red, True, True)
                TimeSpanElapsed.ElapsedTime(Watch)
                Watch.Stop()
            Else
                If QcomWorker.IsBusy Then
                    RichLogs("Worker Flash Is Busy", Color.Red, True, True)
                Else
                    QcomWorker = New BackgroundWorker()
                    QcomWorker.WorkerSupportsCancellation = True
                    AddHandler QcomWorker.DoWork, AddressOf ConnectToFlshLoader
                    AddHandler QcomWorker.RunWorkerCompleted, AddressOf AllDone
                    AddHandler QcomWorker.ProgressChanged, AddressOf ProcessSendingLoader
                    QcomWorker.RunWorkerAsync()
                    QcomWorker.Dispose()
                End If
            End If
        End Sub

        Public Shared Sub ProcessSendingLoader(sender As Object, e As ProgressChangedEventArgs)
            RichLogs(e.ToString(), Color.White, True, True)
        End Sub

        Public Shared Sub AllDone(sender As Object, e As RunWorkerCompletedEventArgs)
            DiskClose()
            RichLogs(vbCrLf & "All Progress Completed", Color.White, True, True)
            TimeSpanElapsed.ElapsedTime(Watch)
            Watch.Stop()
        End Sub

        Public Shared Sub Write(request As Byte())
            DiskWrite(request)
        End Sub

        Public Shared Function IsAckFast() As Boolean
            Try

                Dim comBuffer() As Byte = DiskRead()
                Dim x = System.Text.Encoding.UTF8.GetString(comBuffer, 0, comBuffer.Length)
                Return True
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try
            Return False
        End Function
        Public Shared Function IsAck() As Boolean
            Try
                Do
                    Dim comBuffer() As Byte = DiskRead(50)
                    Dim x = System.Text.Encoding.UTF8.GetString(comBuffer, 0, comBuffer.Length)

                    If x.Contains("""ACK""") Then
                        '   _
                        Return True
                    ElseIf x.Contains("""NAK""") Then
                        RichLogs(x, Color.Red, True, True)
                        Return False
                    End If
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try
            Return False
        End Function
        Public Shared Sub SendXmlFast(ByVal xml As String)
            Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes(xml)
            DiskWrite(data)
            IsAckFast()
        End Sub
        Public Shared Sub SendXml(ByVal xml As String)
            Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes(xml)
            DiskWrite(data)
        End Sub

        Public Shared Function CekResponseConfig() As String
            Dim str As String
            Dim num As Integer = 0
            Try
                Do
                    Dim numArray As Byte() = DiskRead()
                    Dim str1 As String = Encoding.UTF8.GetString(numArray, 0, numArray.Length)
                    If str1.ToUpper().Contains("""ACK""") Then
                        str = "ack"
                        Return str
                    ElseIf str1.ToUpper().Contains("""NAK""") Then
                        str = str1
                        Return str
                    Else
                        num += 1
                        Thread.Sleep(300)
                    End If
                Loop While num <> 3
                str = "failed"
            Catch exception As Exception
                ProjectData.SetProjectError(exception)
                str = "failed"
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Shared Sub ConnectToFlshLoader(sender As Object, e As DoWorkEventArgs)
            Try
                If Not OpenDisk("\\.\COM" & PortQcom) Then
                    Console.WriteLine("Failed to configuring safehandler...")
                    Return
                End If

                Dim xr1 As XmlTextReader
                If MenuEx = MenuEksekusi.oneclick Then
                    xr1 = New XmlTextReader(New StringReader(StringXml))
                    Do While xr1.Read()
                        If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name.ToLower = "program" Or xr1.Name.ToLower = "erase" Or xr1.Name.ToLower = "patch" Then
                            SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                            Exit Do
                        End If
                    Loop
                    If SectorSize = "512" Then
                        TypeMemory = "emmc"
                    ElseIf SectorSize = "4096" Then
                        TypeMemory = "ufs"
                    Else
                        RichLogs("Failed Get Sector Size From data Server", Color.Red, True, True)
                        Return
                    End If
                End If

                Dim cfg = pkt_fhConfig(TypeMemory)
                RichLogs("Sending Congigure : ", Color.White, True, False)
                SendXml(cfg)
                RichLogs("OK ", Color.Yellow, True, True)
                Dim k = CekResponseConfig()
                RichLogs("Get Response      : ", Color.White, True, False)
                If k.ToLower.Contains("ack") Then
                    RichLogs("Configured", Color.Yellow, True, True)
                    If MerkTerpilih.ToLower().Contains("vivo") Then
                        If TypeTerpilih.ToUpper().Contains("[PD1818EF]") Or TypeTerpilih.ToUpper().Contains("[PD1818EF]") Or TypeTerpilih.ToUpper().Contains("[PD1818EF]") Then
                            RichLogs("Need Patching", Color.Blue, True, True)
                            Dim xmldata = "<?xml version=""1.0"" ?><data><poke SizeInBytes=""4"" address64=""0x08062F04"" value=""1""/></data>"
                            SendXml(xmldata)
                            Dim status2 = IsAck()
                            If Not status2 Then
                                RichLogs("Failed", Color.Red, True, True)
                                Return
                            End If
                        End If
                    End If
                Else
                        If Not k.Contains("xml") Then
                        Return
                    Else
                        If k.Contains("Only nop and sig tag") Then
                            RichLogs("Only nop and sig tag Before Authentification", Color.Yellow, True, True)
                            RichLogs("Try Bypassing Auth", Color.Yellow, True, True)
                            Dim xmdata = "<?xml version=""1.0"" ?><data><sig TargetName=""sig"" size_in_bytes=""256"" verbose=""1""/></data>"
                            RichLogs("Sending auth      : ", Color.Yellow, True, False)
                            SendXml(xmdata)
                            Dim status2 = IsAck()
                            If Not status2 Then
                                RichLogs("Failed", Color.Red, True, True)
                                Return
                            End If

                            Dim datah = My.Resources.skip
                            DiskWrite(datah)
                            If Not IsAck() Then
                                RichLogs("Failed", Color.Red, True, True)
                                Return
                            End If

                            RichLogs("Re-Sending Configure : ", Color.White, True, False)
                            SendXml(cfg)
                            If Not IsAck() Then
                                RichLogs("Failed", Color.Red, True, True)
                                Return
                            End If
                            RichLogs("OK", Color.Yellow, True, True)

                        End If
                    End If
                End If
                If MenuEx = MenuEksekusi.manual Then
                    If MenuManual = "Read GPT" Then
                        If TypeMemory.ToLower = "emmc" Then


                            tot = 0
                            Thread.Sleep(500)
                            RichLogs("Get Flash Storage : ", Color.White, True, False)
                            If ParseGPT(TypeMemory, "0") = True Then
                                Thread.Sleep(500)
                                tot = 0
                                ParsePartions(gpt.header.starting_lba_pe, TypeMemory, "0")

                                RichLogs("Done  ✓", Color.Yellow, True, True)
                            End If

                        ElseIf TypeMemory.ToLower = "ufs" Then

                            tot = 0
                            Thread.Sleep(500)
                            RichLogs("Get Flash Storage : ", Color.White, True, False)
                            If ParseGPT(TypeMemory, "0") = True Then
                                Thread.Sleep(500)
                                tot = 0
                                ParsePartions(gpt.header.starting_lba_pe, TypeMemory, 0)
                            End If
                            Thread.Sleep(500)
                            If ParseGPT(TypeMemory, "1") = True Then
                                Thread.Sleep(500)
                                tot = 0
                                ParsePartions(gpt.header.starting_lba_pe, TypeMemory, 1)
                            End If
                            Thread.Sleep(500)
                            If ParseGPT(TypeMemory, "2") = True Then
                                Thread.Sleep(500)
                                tot = 0
                                ParsePartions(gpt.header.starting_lba_pe, TypeMemory, 2)
                            End If
                            Thread.Sleep(500)
                            If ParseGPT(TypeMemory, "3") = True Then
                                Thread.Sleep(500)
                                tot = 0
                                ParsePartions(gpt.header.starting_lba_pe, TypeMemory, 3)
                            End If
                            Thread.Sleep(500)
                            If ParseGPT(TypeMemory, "4") = True Then
                                Thread.Sleep(500)
                                tot = 0
                                ParsePartions(gpt.header.starting_lba_pe, TypeMemory, 4)
                            End If
                            Thread.Sleep(500)
                            If ParseGPT(TypeMemory, "5") = True Then
                                Thread.Sleep(500)
                                tot = 0
                                ParsePartions(gpt.header.starting_lba_pe, TypeMemory, 5)
                            End If
                            RichLogs("Done  ✓", Color.Yellow, True, True)
                        End If


                    ElseIf MenuManual = "UnRelock Bootloader" Then
                        Dim Totalpatch As Integer = 3
                        Dim dopatch As Integer = 0

                        xr1 = New XmlTextReader(New StringReader(StringXml))

                        Do While xr1.Read()
                            If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "patch" Then
                                Dim SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                Dim BytesOffset = xr1.GetAttribute("byte_offset")
                                Dim FileName = xr1.GetAttribute("filename")
                                Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                                Dim SizesInBytes = xr1.GetAttribute("size_in_bytes")
                                Dim StartSector = xr1.GetAttribute("start_sector")
                                Dim Value = xr1.GetAttribute("value")
                                Dim what = xr1.GetAttribute("what")
                                If FileName.ToLower.Contains("disk") Then
                                    Dim pkt = pkt_patch(SectorSize, BytesOffset, FileName, PhysicalPartition, SizesInBytes, StartSector, Value, what)

                                    dopatch += 1
                                    If dopatch = 1 Then
                                        RichLogs("Patch Partition Data : ", Color.White, True, False)
                                        SendXml(pkt)
                                        ProcessBar1(dopatch, Totalpatch)
                                    Else
                                        SendXmlFast(pkt)

                                    End If
                                    If dopatch = Totalpatch Then
                                        ProcessBar1(Totalpatch, Totalpatch)
                                        RichLogs("Done  ✓", Color.Yellow, True, True)
                                    End If
                                End If
                            End If
                        Loop


                    ElseIf MenuManual = "Safe Format" Then
                        Dim totaldo As Integer = 1
                        Dim doprosess As Integer = 0

                        xr1 = New XmlTextReader(New StringReader(StringXml))
                        Do While xr1.Read()
                            If xr1.NodeType = XmlNodeType.Element AndAlso Operators.CompareString(xr1.Name, "program", False) = 0 Then
                                SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                Dim numPartSect = xr1.GetAttribute("num_partition_sectors")
                                Dim label = xr1.GetAttribute("label")
                                Dim filename = xr1.GetAttribute("filename")
                                Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                                Dim StartSector = xr1.GetAttribute("start_sector")
                                doprosess += 1
                                Dim status = WriteEmmc(SectorSize, numPartSect, PhysicalPartition, StartSector, filename)
                                If Not status Then
                                    RichLogs("Failed", Color.LimeGreen, True, False)
                                End If
                                RichLogs("Done  ✓", Color.Yellow, True, True)

                            End If

                            ProcessBar2(doprosess, totaldo)

                            If SectorSize = "512" Then
                                FilesOneClick = My.Resources.safeformat_emmc
                            Else
                                FilesOneClick = My.Resources.safeformat_ufs
                            End If
                        Loop

                    ElseIf MenuManual = "Format Data" Then
                        Dim totaldo As Integer = 1
                        Dim doprosess As Integer = 0
                        xr1 = New XmlTextReader(New StringReader(StringXml))
                        Do While xr1.Read()
                            If xr1.NodeType = XmlNodeType.Element AndAlso Operators.CompareString(xr1.Name, "program", False) = 0 Then
                                SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                Dim numPartSect = xr1.GetAttribute("num_partition_sectors")
                                Dim label = xr1.GetAttribute("label")
                                Dim filename = xr1.GetAttribute("filename")
                                Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                                Dim StartSector = xr1.GetAttribute("start_sector")
                                doprosess += 1
                                Dim status = EraseParts(SectorSize, numPartSect, PhysicalPartition, StartSector)
                                If Not status Then
                                    RichLogs("Failed", Color.LimeGreen, True, False)
                                End If
                                RichLogs("Done  ✓", Color.Yellow, True, True)
                            End If

                            ProcessBar2(doprosess, totaldo)
                        Loop

                    ElseIf MenuManual = "HexOperation" Then
                        Dim totaldo As Integer = 1
                        Dim doprosess As Integer = 0
                        xr1 = New XmlTextReader(New StringReader(StringXml))
                        Do While xr1.Read()
                            If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "read" Then
                                Dim SectSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                Dim SectorSizeStorage = SectSize
                                Dim numPartSect = xr1.GetAttribute("num_partition_sectors")
                                Dim label = xr1.GetAttribute("label")
                                Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                                Dim StartSector = xr1.GetAttribute("start_sector")

                                RichLogs("Reading ", Color.White, True, False)
                                RichLogs(label & " : ", Color.DeepSkyBlue, True, False)
                                RichLogs("Start Sector => ", Color.Orange, True, False)
                                RichLogs(StartSector & " : ", Color.Aqua, True, False)

                                Dim result As Boolean
                                Dim patch_result As Boolean
                                Dim Status = ReadPart(StartSector, numPartSect, SectSize, PhysicalPartition, label)
                                If Status Then
                                    RichLogs("Done  ✓", Color.Yellow, True, True)
                                    RichLogs("Patching " & label & " partition...", Color.White, True, False)

                                    If label = "modem" Then
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "CARDAPP", "SLOTAPP")
                                    ElseIf label = "persist" Then
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "ftf", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "Ttf", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "tTf", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "ftF", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "FTF", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "fdsd", "ftst")
                                    ElseIf label = "persistent" Then
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "ftf", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "Ttf", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "tTf", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "ftF", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "FTF", "ttf")
                                        result = HexPatch(foldersave & "\" & getfilenames(label), "fdsd", "ftst")
                                    Else

                                    End If
                                    If result Then

                                        If label = "modem" Then
                                            patch_result = WriteEmmc(SectorSize, numPartSect, PhysicalPartition, StartSector, foldersave & "\" & getfilenames(label))
                                        ElseIf label = "persist" Then
                                            patch_result = WriteEmmc(SectorSize, numPartSect, PhysicalPartition, StartSector, foldersave & "\" & getfilenames(label))
                                        ElseIf label = "persistent" Then
                                            patch_result = WriteEmmc(SectorSize, numPartSect, PhysicalPartition, StartSector, foldersave & "\" & getfilenames(label))
                                        Else

                                        End If

                                        If patch_result Then
                                            RichLogs("Writing files ...", Color.DeepSkyBlue, True, False)
                                            RichLogs("Done  ✓", Color.Yellow, True, True)
                                        End If

                                    End If
                                    doprosess += 1

                                Else
                                    RichLogs("Failed", Color.Red, True, True)
                                    doprosess += 1

                                End If
                                ProcessBar2(doprosess, totaldo)
                            End If
                        Loop


                    ElseIf MenuManual = "Flashing" Then
                        Dim totaldo As Integer
                        totaldo = totalchecked
                        Dim doprosess = 0
                        xr1 = New XmlTextReader(New StringReader(StringXml))
                        Do While xr1.Read()
                            If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "program" Then
                                SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                Dim numPartSect = xr1.GetAttribute("num_partition_sectors")
                                Dim label = xr1.GetAttribute("label")
                                Dim filename = xr1.GetAttribute("filename")
                                Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                                Dim StartSector = xr1.GetAttribute("start_sector")
                                If filename = "" Then
                                    doprosess += 1
                                Else

                                    If File.Exists(filename) Then
                                        doprosess += 1
                                        Dim status = WriteEmmc(SectorSize, numPartSect, PhysicalPartition, StartSector, filename)
                                        If Not status Then
                                            RichLogs("Failed", Color.LimeGreen, True, False)
                                            Return
                                        End If
                                        RichLogs("Done  ✓", Color.Yellow, True, True)
                                    Else

                                        RichLogs("File Not exist : ", Color.White, True, False)
                                        RichLogs("skiping", Color.Red, True, True)
                                        doprosess += 1
                                    End If

                                End If


                                ProcessBar2(doprosess, totaldo)
                            Else

                            End If
                        Loop

                        Dim cmdlist() = PatchString.Split(",")
                        Dim filenamePatch As String = ""
                        For i As Integer = 0 To cmdlist.Length - 1
                            filenamePatch = cmdlist(i)

                            If filenamePatch = "" Then
                                Exit For
                            End If
                            Console.WriteLine(LoadFolderXml & "\" & filenamePatch)
                            RichLogs("Apply Patch       : ", Color.White, True, False)
                            xr1 = New XmlTextReader(New StringReader(File.ReadAllText(LoadFolderXml & "\" & filenamePatch)))
                            Do While xr1.Read()
                                If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "patch" Then
                                    Dim SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                    Dim BytesOffset = xr1.GetAttribute("byte_offset")
                                    Dim FileName = xr1.GetAttribute("filename")
                                    Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                                    Dim SizesInBytes = xr1.GetAttribute("size_in_bytes")
                                    Dim StartSector = xr1.GetAttribute("start_sector")
                                    Dim Value = xr1.GetAttribute("value")
                                    Dim what = xr1.GetAttribute("what")
                                    If FileName.ToUpper.Contains("DISK") Then
                                        Dim pkt = pkt_patch(SectorSize, BytesOffset, FileName, PhysicalPartition, SizesInBytes, StartSector, Value, what)

                                        SendXml(pkt)

                                        If IsAckFast() Then

                                        Else
                                            RichLogs("Failed", Color.Red, True, True)
                                            Return
                                        End If


                                    Else


                                    End If
                                End If
                            Loop
                            RichLogs("Done  ✓", Color.White, True, True)
                        Next



                        If QcFlash.SharedUI.CekSetBootQC.Checked = True Then
                            SendXml(BootConf())

                            RichLogs("User area Boot : ", Color.White, True, False)
                            RichLogs("Done  ✓", Color.Yellow, True, False)
                            RichLogs("", Color.Yellow, True, True)
                            Dim status = IsAck()

                            If status Then

                            Else

                                Return
                            End If
                        End If

                        If QcFlash.SharedUI.CekAutoRebootQc.Checked = True Then
                            SendXml(pkt_sendReset)
                            RichLogs("Reboot After Flash: ", Color.White, True, False)
                            RichLogs("Done  ✓", Color.Yellow, True, False)
                            RichLogs("", Color.Yellow, True, True)
                            Return
                        End If

                        Return
                    ElseIf MenuManual = "Erase" Then
                        Dim totaldo As Integer
                        totaldo = totalchecked
                        Dim doprosess = 0
                        xr1 = New XmlTextReader(New StringReader(StringXml))
                        Do While xr1.Read()
                            If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "program" Then
                                SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")

                                Dim numPartSect = xr1.GetAttribute("num_partition_sectors")
                                Dim label = xr1.GetAttribute("label")
                                Dim filename = xr1.GetAttribute("filename")
                                Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                                Dim StartSector = xr1.GetAttribute("start_sector")
                                If filename = "" Then
                                    doprosess += 1
                                Else
                                    RichLogs("Erasing : " & label & " : ", Color.White, True, False)
                                    doprosess += 1
                                    Dim status = EraseParts(SectorSize, numPartSect, PhysicalPartition, StartSector)
                                    If Not status Then
                                        RichLogs("Failed", Color.Red, True, True)
                                        Return
                                    End If
                                    RichLogs("Done  ✓", Color.Yellow, True, True)
                                End If


                                ProcessBar2(doprosess, totaldo)
                            Else

                            End If
                        Loop
                    ElseIf MenuManual = "Read" Then

                        RichLogs(" " & vbCrLf, Color.White, True, False)
                        Dim totaldo = totalchecked
                        Dim doprosess = 0
                        If File.Exists(foldersave & "\rawprogram.xml") Then
                            File.Delete(foldersave & "\rawprogram.xml")
                        End If
                        Dim files As StreamWriter
                        files = My.Computer.FileSystem.OpenTextFileWriter(foldersave & "\rawprogram.xml", True)
                        files.WriteLine("<?xml version=""1.0"" ?>")
                        files.WriteLine("<data>")
                        files.WriteLine("<!--NOTE: Genererate by HadiK IT **-->")
                        Try

                            xr1 = New XmlTextReader(New StringReader(StringXml))
                            Do While xr1.Read()
                                If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "read" Then
                                    Dim SectSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                    Dim SectorSizeStorage = SectSize
                                    Dim numPartSect = xr1.GetAttribute("num_partition_sectors")
                                    Dim label = xr1.GetAttribute("label")
                                    Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                                    Dim StartSector = xr1.GetAttribute("start_sector")

                                    RichLogs("Reading ", Color.White, True, False)
                                    RichLogs(label & " : ", Color.DeepSkyBlue, True, False)
                                    RichLogs("Start Sector => ", Color.Orange, True, False)
                                    RichLogs(StartSector & " : ", Color.Aqua, True, False)


                                    Dim Status = ReadPart(StartSector, numPartSect, SectSize, PhysicalPartition, label)
                                    If Status Then
                                        RichLogs("Done  ✓", Color.Yellow, True, True)
                                        files.WriteLine("<program SECTOR_SIZE_IN_BYTES=""" & SectorSize & """ file_sector_offset=""0"" filename=""" & getfilenames(label) & """ label=""" & label & """ num_partition_sectors=""" & numPartSect & """ physical_partition_number=""" & PhysicalPartition & """ start_sector=""" & StartSector & """/>")
                                        doprosess += 1

                                    Else
                                        RichLogs("Failed", Color.Red, True, True)
                                        doprosess += 1

                                    End If
                                    ProcessBar2(doprosess, totaldo)
                                End If
                            Loop
                            files.WriteLine("</data>")
                            files.Close()

                            Return
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try

                    ElseIf MenuManual = "Reboot" Then
                        SendXml(pkt_sendReset)
                        RichLogs(vbCrLf & "Reboot ", Color.White, True, False)
                        RichLogs("Done  ✓", Color.Yellow, True, False)
                        RichLogs("", Color.Yellow, True, True)
                    End If



                ElseIf MenuEksekusi.oneclick Then
                    Dim Totalpatch As Long = 0
                    Dim dopatch As Long = 0

                    If StringXml.ToLower.Contains("patch") Then
                        xr1 = New XmlTextReader(New StringReader(StringXml))

                        Do While xr1.Read()
                            If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "patch" Then
                                Dim SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                Dim BytesOffset = xr1.GetAttribute("byte_offset")
                                Dim FileName = xr1.GetAttribute("filename")
                                Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                                Dim SizesInBytes = xr1.GetAttribute("size_in_bytes")
                                Dim StartSector = xr1.GetAttribute("start_sector")
                                Dim Value = xr1.GetAttribute("value")
                                Dim what = xr1.GetAttribute("what")
                                If FileName.ToLower.Contains("disk") Then
                                    Totalpatch += 1

                                End If

                            End If

                        Loop
                    End If


                    xr1 = New XmlTextReader(New StringReader(StringXml))

                    Do While xr1.Read()
                        If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "patch" Then
                            Dim SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                            Dim BytesOffset = xr1.GetAttribute("byte_offset")
                            Dim FileName = xr1.GetAttribute("filename")
                            Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                            Dim SizesInBytes = xr1.GetAttribute("size_in_bytes")
                            Dim StartSector = xr1.GetAttribute("start_sector")
                            Dim Value = xr1.GetAttribute("value")
                            Dim what = xr1.GetAttribute("what")
                            If FileName.ToLower.Contains("disk") Then
                                Dim pkt = pkt_patch(SectorSize, BytesOffset, FileName, PhysicalPartition, SizesInBytes, StartSector, Value, what)

                                dopatch += 1
                                If dopatch = 1 Then
                                    RichLogs("Patch Partition Data : ", Color.White, True, False)
                                    SendXml(pkt)
                                    ProcessBar1(dopatch, Totalpatch)
                                Else
                                    SendXmlFast(pkt)

                                End If
                                If dopatch = Totalpatch Then
                                    ProcessBar1(Totalpatch, Totalpatch)
                                    RichLogs("Done  ✓", Color.Yellow, True, True)
                                End If
                            End If
                        End If
                        If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "erase" Then
                            Dim SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                            Dim numPartSect = xr1.GetAttribute("num_partition_sectors")
                            Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                            Dim StartSector = xr1.GetAttribute("start_sector")
                            Dim label = xr1.GetAttribute("label")
                            RichLogs("Erase Sector" & StartSector & " : ", Color.White, True, False)
                            Dim status = EraseParts(SectorSize, numPartSect, PhysicalPartition, StartSector)
                            If Not status Then
                                RichLogs("Failed", Color.Red, True, True)
                                Return
                            End If
                            RichLogs("Done  ✓" & vbNewLine, Color.Yellow, True, True)
                        End If
                        If xr1.NodeType = XmlNodeType.Element AndAlso xr1.Name = "program" Then
                            Dim SectorSize = xr1.GetAttribute("SECTOR_SIZE_IN_BYTES")
                            Dim numPartSect = xr1.GetAttribute("num_partition_sectors")
                            Dim filename = xr1.GetAttribute("filename")
                            Dim PhysicalPartition = xr1.GetAttribute("physical_partition_number")
                            Dim label = xr1.GetAttribute("label")
                            Dim StartSector = xr1.GetAttribute("start_sector")
                            If filename = "" Then
                                RichLogs("Erase Sector" & StartSector & " : ", Color.White, True, False)
                                Dim status = EraseParts(SectorSize, numPartSect, PhysicalPartition, StartSector)
                                If Not status Then
                                    RichLogs("Failed", Color.Red, True, True)
                                    Return
                                End If
                                RichLogs("Done  ✓" & vbNewLine, Color.Yellow, True, True)

                            Else
                                CheckKelar = 0
                                RichLogs(" Downloading data : ", Color.White, True, False)
                                EncryptedDownloadData = getfile(filename, True)


                                OutDecripted = EncryptedDownloadData
                                RichLogs("Initialized Data : " & GetFileSize(EncryptedDownloadData.Length), Color.Yellow, True, False)

                                If Not CryptStream(keyEncrypt, EncryptedDownloadData, False, "raw", numPartSect * SectorSize) Then
                                    Return
                                End If
                                RichLogs(" Done  ✓", Color.Yellow, True, True)

                                Dim status = WriteEmmc(SectorSize, numPartSect, PhysicalPartition, StartSector, filename)
                                If Not status Then
                                    RichLogs("Failed", Color.Red, True, True)
                                    Return
                                End If
                                RichLogs("Done  ✓" & vbNewLine, Color.Yellow, True, True)

                            End If
                        End If
                    Loop

                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Sub

        Public Property DigestSizeInBytes As Integer

        Public Sub SendSignedDigest()
            Dim numArray As Byte() = File.ReadAllBytes("digs")
            If numArray.Length <= 6440 Then
                NumDigestsFound = CLng(Math.Round((numArray.Length - 40) / DigestSizeInBytes))
            Else
                NumDigestsFound = CLng(Math.Round((numArray.Length - 40 - 256 - 6144) / DigestSizeInBytes))
            End If
        End Sub


        Public Shared Function CekSparse(DataFiles As Byte()) As Boolean
            Dim result As Boolean
            If DataFiles.Length = 0 Then
                result = False
            Else
                Dim stream As Stream = New MemoryStream(DataFiles)
                Dim array As Byte() = New Byte(1024) {}
                Using binaryReader As New BinaryReader(stream)
                    binaryReader.Read(array, 0, 28)
                    sparseheader = parsingheader(array)
                    Dim dwMagic As Integer = sparseheader.dwMagic
                    Dim num As Long = Math.Round(Val("&HE" + Hex(dwMagic)))
                    If num = 64108298042L Then
                        totalchunk = sparseheader.dwTotalChunks
                        stream.Close()
                        binaryReader.Close()
                        result = True
                    Else
                        stream.Close()
                        binaryReader.Close()
                        result = False
                    End If
                End Using
            End If
            Return result
        End Function

        Public Shared Function bulat(number As Double) As Long
            Return Math.Round(-Int(-number))
        End Function

        Public Shared Function WriteEmmc(SectSize As String, NumSect As String, Physical As String, StartSect As String, Filename As String) As Boolean
            Dim imgfile As String = ""

            Dim dataBytes(16384) As Byte
            Dim stream As Stream = New MemoryStream(dataBytes)
            If MenuEx = MenuEksekusi.manual Then
                If Not File.Exists(Filename) Then
                    If FilesOneClick IsNot Nothing AndAlso FilesOneClick.Length > 0 Then
                        stream = New MemoryStream(FilesOneClick)
                        stream.Read(dataBytes, 0, dataBytes.Length)
                        imgfile = "Data"
                    Else
                        Return True
                    End If
                End If
                stream = New FileStream(Filename, FileMode.Open, FileAccess.Read)
                stream.Read(dataBytes, 0, dataBytes.Length)
                imgfile = Path.GetFileName(Filename)
            ElseIf MenuEx = MenuEksekusi.oneclick Then

                stream = New MemoryStream(FilesOneClick)
                stream.Read(dataBytes, 0, dataBytes.Length)
                imgfile = "Data"
            End If


            stream.Seek(0, SeekOrigin.Begin)
            If CekSparse(dataBytes) = True Then
                RichLogs("Writing ", Color.White, True, False)
                RichLogs(imgfile & " : ", Color.DeepSkyBlue, True, False)
                RichLogs("Start Sector => ", Color.Orange, True, False)
                RichLogs(StartSect & " : ", Color.Aqua, True, False)
                Dim type As Int16
                Dim hexchunk As Double
                Dim totalsizechunk As Integer
                Dim sizechunk As Long
                Dim sectorsizeCunk As Long
                Dim offsset As Long
                Dim offsetdisk As Long
                Dim su As Integer = 0
                Dim numsectorfile As Integer = 0
                Dim kunyukasu As Long = 0
                Dim bytesTobeWrite As Long = 0
                If totalchunk > 0 Then
                    Dim i As Integer = 0
                    Using reader As New BinaryReader(stream)
                        Dim buffer(1024) As Byte
                        chunkheader = New CHUNK_HEADER
                        Do
                            Try
                                If i = 0 Then
                                    reader.BaseStream.Seek(28, SeekOrigin.Begin)
                                    reader.Read(buffer, 0, 12)
                                    chunkheader.wChunkType = BitConverter.ToInt16(buffer.Skip(0).Take(2).ToArray(), 0)
                                    chunkheader.dwChunkSize = BitConverter.ToInt32(buffer.Skip(4).Take(4).ToArray(), 0)
                                    chunkheader.dwTotalSize = BitConverter.ToInt32(buffer.Skip(8).Take(4).ToArray(), 0)
                                    type = chunkheader.wChunkType
                                    hexchunk = Val("&HE" & Hex(type))
                                    totalsizechunk = chunkheader.dwTotalSize
                                    sizechunk = chunkheader.dwChunkSize
                                    sectorsizeCunk = sizechunk * sparseheader.dwBlockSize
                                    offsset += chunkheader.dwTotalSize
                                    offsetdisk = 0

                                Else
                                    reader.BaseStream.Seek(offsset + 28, SeekOrigin.Begin)
                                    reader.Read(buffer, 0, 12)
                                    chunkheader.wChunkType = BitConverter.ToInt16(buffer.Skip(0).Take(12).ToArray(), 0)
                                    chunkheader.dwChunkSize = BitConverter.ToInt32(buffer.Skip(4).Take(4).ToArray(), 0)
                                    chunkheader.dwTotalSize = BitConverter.ToInt32(buffer.Skip(8).Take(4).ToArray(), 0)
                                    type = chunkheader.wChunkType
                                    hexchunk = Val("&HE" & Hex(type))
                                    totalsizechunk = chunkheader.dwTotalSize
                                    offsset += chunkheader.dwTotalSize
                                    sizechunk = chunkheader.dwChunkSize
                                    sectorsizeCunk = sizechunk * sparseheader.dwBlockSize
                                    offsetdisk += sectorsizeCunk / SectSize

                                End If
                                If hexchunk = SPARSE_RAW_CHUNK Then

                                    su += 1
                                    Dim PartitionName As String = Filename
                                    Dim completed As Boolean = False
                                    Dim PacketSize As Integer = 524288
                                    Dim NumSec As Long = sectorsizeCunk / SectSize
                                    Dim bytesWritten As Long = 0
                                    Dim ii As Integer = 0
                                    If sectorsizeCunk <= PacketSize Then
                                        PacketSize = sectorsizeCunk
                                    End If
                                    Dim OffsetStreams As Integer = 0



                                    Dim pkt = pkt_Program(SectSize, NumSec, Physical, StartSect + kunyukasu)

                                    kunyukasu += NumSec

                                    SendXml(pkt)
                                    If Not IsAckFast() Then
                                        RichLogs("Failed ", Color.Red, True, False)
                                        Return False
                                    Else


                                        Do
                                            If sectorsizeCunk - bytesWritten < PacketSize Then
                                                PacketSize = sectorsizeCunk - bytesWritten
                                            End If
                                            If bytesWritten = sectorsizeCunk Then
                                                If IsAckFast() Then
                                                    Exit Do
                                                End If

                                            End If
                                            Dim byt As Byte() = New Byte(PacketSize - 1) {}
                                            reader.Read(byt, 0, PacketSize)
                                            DiskWrite(byt)
                                            bytesTobeWrite += byt.Length

                                            bytesWritten += byt.Length
                                            OffsetStreams += byt.Length

                                            ProcessBar1(bytesWritten, sectorsizeCunk)
                                        Loop
                                    End If
                                ElseIf hexchunk = SPARSE_FILL_CHUNK Then
                                    Dim NumSec As Long = sectorsizeCunk / SectSize
                                    kunyukasu += NumSec
                                ElseIf hexchunk = SPARSE_DONT_CARE Then
                                    Dim NumSec As Long = sectorsizeCunk / SectSize
                                    kunyukasu += NumSec
                                Else

                                End If
                                i += 1
                                If i = totalchunk Then
                                    ProcessBar2(i, totalchunk)
                                    stream.Close()
                                    reader.Close()
                                    Return True
                                    Exit Do
                                End If
                                ProcessBar2(i, totalchunk)
                                Continue Do
                            Catch e As Exception
                                MsgBox(e.ToString)
                                stream.Close()
                                Return False
                                Exit Do
                            End Try
                            Exit Do
                        Loop
                    End Using
                End If
                stream.Close()

            Else
                stream.Seek(0, SeekOrigin.Begin)
                RichLogs("Writing ", Color.White, True, False)
                RichLogs(imgfile & " : ", Color.DeepSkyBlue, True, False)
                RichLogs("Start Sector => ", Color.Orange, True, False)
                RichLogs(StartSect & " : ", Color.Aqua, True, False)

                Dim besarFile As Long = 0

                If MenuEx = MenuEksekusi.manual Then
                    Dim Finfo = My.Computer.FileSystem.GetFileInfo(Filename)
                    besarFile = Finfo.Length
                ElseIf MenuEx = MenuEksekusi.oneclick Then

                    besarFile = FilesOneClick.Length

                End If









                Dim PacketSize As Integer = 8192




                If besarFile >= 16777216 Then
                    PacketSize = 524288 * 2
                End If

                Dim RealsectorSizeToBeWrite As Long = bulat(besarFile / SectorSize)
                Dim RealBesarNyaFile = RealsectorSizeToBeWrite * SectorSize


                If besarFile < SectSize Then
                    RealsectorSizeToBeWrite = 1
                    RealBesarNyaFile = SectSize
                    PacketSize = 512
                End If

                Dim xmlpkt = pkt_Program(SectSize, RealsectorSizeToBeWrite, Physical, StartSect)

                SendXml(xmlpkt)

                Dim status = IsAck()


                If status Then


                    Dim TotalWriten As Long

                    Using reader As New BinaryReader(stream)
                        Try
                            Do
                                If RealBesarNyaFile = TotalWriten Then
                                    If IsAck() Then ' got ACK, continue writing
                                        reader.Close()
                                        Return True
                                    Else
                                        reader.Close()
                                        Return False
                                    End If
                                End If

                                If (RealBesarNyaFile - TotalWriten) < PacketSize Then
                                    PacketSize = RealBesarNyaFile - TotalWriten
                                    Dim Buffer As Byte() = New Byte(PacketSize - 1) {}
                                    reader.Read(Buffer, 0, PacketSize)
                                    DiskWrite(Buffer)
                                    TotalWriten += Buffer.Length
                                    ProcessBar1(TotalWriten, RealBesarNyaFile)
                                Else
                                    Dim Buffer As Byte() = New Byte(PacketSize - 1) {}
                                    reader.Read(Buffer, 0, PacketSize)
                                    DiskWrite(Buffer)
                                    TotalWriten += Buffer.Length
                                    ProcessBar1(TotalWriten, RealBesarNyaFile)
                                End If



                            Loop

                        Catch ex As Exception
                            stream.Close()
                            RichLogs(ex.ToString, Color.Red, True, False)
                            Return False
                        End Try


                    End Using


                Else

                    RichLogs("Failed ", Color.Red, True, False)
                    Return False
                End If

            End If




            Return False
        End Function

        Public Shared Function parsingheader(bytes As Byte()) As SPARSE_HEADER
            Dim gchandle As GCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned)
            Dim result As SPARSE_HEADER
            Try
                Dim obj As Object = Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), GetType(SPARSE_HEADER))
                result = If(obj IsNot Nothing, CType(obj, SPARSE_HEADER), Nothing)
            Finally
                gchandle.Free()
            End Try
            Return result
        End Function

        Public Shared Sub ParsePartions(startingLbaPe As Integer, storage As String, lun As String)
            ListPartitionName.Items.Clear()
            ListStartSector.Items.Clear()
            ListLastSector.Items.Clear()
            listSectorSize.Items.Clear()
            listPhysicalPartition.Items.Clear()
            If storage.ToLower = "emmc" Then
                SendXml(pkt_read(512, 100, lun, startingLbaPe))

                Dim comBuffer As Byte() = readByte(512 * 100)

                Dim i As Integer = 0
                gpt.entries = New List(Of gpt_partition_entry)()
                Do
                    Try
                        Dim gptEntry As New gpt_partition_entry()
                        If i > 128 Then
                            Exit Do
                        End If
                        If i = 0 Then
                            gptEntry.partTypeGUID = Encoding.UTF8.GetString(comBuffer.Skip(0).Take(16).ToArray(), 0, 16)
                            gptEntry.partID = Encoding.UTF8.GetString(comBuffer.Skip(16).Take(16).ToArray(), 0, 16)
                            gptEntry.first_lba = BitConverter.ToInt32(comBuffer.Skip(32).Take(8).ToArray(), 0)
                            gptEntry.last_lba = BitConverter.ToInt32(comBuffer.Skip(40).Take(8).ToArray(), 0)
                            gptEntry.flags = comBuffer.Skip(48).Take(8).ToArray()
                            gptEntry.partName = Encoding.UTF8.GetString(comBuffer.Skip(56).Take(72).ToArray(), 0, 72).Trim(ControlChars.NullChar)
                            gptEntry.partName = gptEntry.partName.Replace(ControlChars.NullChar, "")
                        Else
                            Dim startOffset As Integer = i * 128
                            gptEntry.partTypeGUID = Encoding.UTF8.GetString(comBuffer.Skip(startOffset).Take(16).ToArray(), 0, 16)
                            gptEntry.partID = Encoding.UTF8.GetString(comBuffer.Skip(startOffset + 16).Take(16).ToArray(), 0, 16)
                            gptEntry.first_lba = BitConverter.ToInt32(comBuffer.Skip(startOffset + 32).Take(8).ToArray(), 0)
                            gptEntry.last_lba = BitConverter.ToInt32(comBuffer.Skip(startOffset + 40).Take(8).ToArray(), 0)
                            gptEntry.flags = comBuffer.Skip(startOffset + 48).Take(8).ToArray()
                            gptEntry.partName = Encoding.ASCII.GetString(comBuffer.Skip(startOffset + 56).Take(72).ToArray()).Trim(ControlChars.NullChar)
                            gptEntry.partName = gptEntry.partName.Replace(ControlChars.NullChar, "")
                        End If
                        If gptEntry.partName = "" Then
                            Exit Do
                        End If
                        If gptEntry.partName <> "" Then
                            ListPartitionName.Items.Add(gptEntry.partName)
                            ListStartSector.Items.Add(gptEntry.first_lba.ToString)
                            ListLastSector.Items.Add(gptEntry.last_lba.ToString)
                            listSectorSize.Items.Add("512")
                            listPhysicalPartition.Items.Add("0")
                            i += 1
                            Continue Do
                        End If
                    Catch e As Exception
                        Exit Do
                    End Try
                    Exit Do
                Loop



                QcFlash.SharedUI.DataView.Invoke(CType(Sub() QcFlash.SharedUI.DataView.Rows.Add(False,
                                                              "0",
                                                              "512",
                                                              "double click ...",
                                                              "PrimaryGPT",
                                                              "0",
                                                              "34",
                                                              "none"),
                                                              Action))

                QcFlash.SharedUI.DataView.Invoke(CType(Sub() QcFlash.SharedUI.DataView.Rows.Add(False,
                                                              "0",
                                                              "512",
                                                              "double click ...",
                                                              "BackupGPT",
                                                              "NUM_DISK_SECTORS-33.",
                                                              "33",
                                                              "none"),
                                                              Action))

                For kk As Integer = 0 To ListPartitionName.Items.Count - 1
                    QcFlash.SharedUI.DataView.Invoke(CType(Sub() QcFlash.SharedUI.DataView.Rows.Add(False,
                                                              listPhysicalPartition.Items(kk),
                                                              "512",
                                                              "double click ...",
                                                              ListPartitionName.Items(kk),
                                                              ListStartSector.Items(kk),
                                                              ListLastSector.Items(kk) - ListStartSector.Items(kk) + 1,
                                                              "none"),
                                                              Action))

                Next

                QcFlash.SharedUI.VScrollBarQcFlashDataView.Invoke(Sub()
                                                                      QcFlash.SharedUI.VScrollBarQcFlashDataView.LargeChange = QcFlash.SharedUI.DataView.Rows.Count
                                                                  End Sub)


            ElseIf storage.ToLower = "ufs" Then


                SendXml(pkt_read(4096, 100, lun, 2))

                Dim comBuffer As Byte() = readByte(4096 * 100)
                Dim i As Integer = 0
                gpt.entries = New List(Of gpt_partition_entry)()
                Do
                    Try
                        Dim gptEntry As New gpt_partition_entry()
                        If i > 128 Then
                            Exit Do
                        End If
                        If i = 0 Then
                            gptEntry.partTypeGUID = Encoding.UTF8.GetString(comBuffer.Skip(0).Take(16).ToArray(), 0, 16)
                            gptEntry.partID = Encoding.UTF8.GetString(comBuffer.Skip(16).Take(16).ToArray(), 0, 16)
                            gptEntry.first_lba = BitConverter.ToInt32(comBuffer.Skip(32).Take(8).ToArray(), 0)
                            gptEntry.last_lba = BitConverter.ToInt32(comBuffer.Skip(40).Take(8).ToArray(), 0)
                            gptEntry.flags = comBuffer.Skip(48).Take(8).ToArray()
                            gptEntry.partName = Encoding.UTF8.GetString(comBuffer.Skip(56).Take(72).ToArray(), 0, 72).Trim(ControlChars.NullChar)
                            gptEntry.partName = gptEntry.partName.Replace(ControlChars.NullChar, "")
                        Else
                            Dim startOffset As Integer = i * 128
                            gptEntry.partTypeGUID = Encoding.UTF8.GetString(comBuffer.Skip(startOffset).Take(16).ToArray(), 0, 16)
                            gptEntry.partID = Encoding.UTF8.GetString(comBuffer.Skip(startOffset + 16).Take(16).ToArray(), 0, 16)
                            gptEntry.first_lba = BitConverter.ToInt32(comBuffer.Skip(startOffset + 32).Take(8).ToArray(), 0)
                            gptEntry.last_lba = BitConverter.ToInt32(comBuffer.Skip(startOffset + 40).Take(8).ToArray(), 0)
                            gptEntry.flags = comBuffer.Skip(startOffset + 48).Take(8).ToArray()
                            gptEntry.partName = Encoding.ASCII.GetString(comBuffer.Skip(startOffset + 56).Take(72).ToArray()).Trim(ControlChars.NullChar)
                            gptEntry.partName = gptEntry.partName.Replace(ControlChars.NullChar, "")
                        End If
                        If gptEntry.partName = "" Then
                            Exit Do
                        End If
                        If gptEntry.partName <> "" Then
                            ListPartitionName.Items.Add(gptEntry.partName)
                            ListStartSector.Items.Add(gptEntry.first_lba.ToString)
                            ListLastSector.Items.Add(gptEntry.last_lba.ToString)
                            listSectorSize.Items.Add("4096")
                            listPhysicalPartition.Items.Add(lun)
                            i += 1
                            Continue Do
                        End If
                    Catch e As Exception
                        Exit Do
                    End Try
                    Exit Do
                Loop

                QcFlash.SharedUI.DataView.Invoke(CType(Sub() QcFlash.SharedUI.DataView.Rows.Add(False,
                                                              "0",
                                                              "4096",
                                                              "double click ...",
                                                              "PrimaryGPT",
                                                              "0",
                                                              "6",
                                                              "none"),
                                                              Action))

                QcFlash.SharedUI.DataView.Invoke(CType(Sub() QcFlash.SharedUI.DataView.Rows.Add(False,
                                                              "0",
                                                              "4096",
                                                              "double click ...",
                                                              "BackupGPT",
                                                              "NUM_DISK_SECTORS-5.",
                                                              "5",
                                                              "none"),
                                                              Action))

                For kk As Integer = 0 To ListPartitionName.Items.Count - 1
                    QcFlash.SharedUI.DataView.Invoke(CType(Sub() QcFlash.SharedUI.DataView.Rows.Add(False,
                                                              listPhysicalPartition.Items(kk),
                                                              "4096",
                                                              "double click ...",
                                                              ListPartitionName.Items(kk),
                                                              ListStartSector.Items(kk),
                                                              ListLastSector.Items(kk) - ListStartSector.Items(kk) + 1,
                                                              "none"),
                                                              Action))
                Next


                QcFlash.SharedUI.VScrollBarQcFlashDataView.Invoke(Sub()
                                                                      QcFlash.SharedUI.VScrollBarQcFlashDataView.LargeChange = QcFlash.SharedUI.DataView.Rows.Count
                                                                  End Sub)

            End If
        End Sub

        Public Shared Function ParseGPT(storage As String, lun As String) As Boolean

            If storage.ToLower = "emmc" Then

                SendXml(pkt_read(SectorSize, 1, lun, 1))

                Dim comBuffer As Byte() = readByte(512)


                If comBuffer.Length > 200 Then
                    Dim s As String = Encoding.UTF8.GetString(comBuffer, 0, comBuffer.Length)
                    If Not s.Contains("EFI") Then
                        RichLogs("No Valid Gpt", Color.Red, True, True)
                        Return False
                    End If
                    gpt.header = New gpt_header With {.signature = Encoding.UTF8.GetString(comBuffer.Skip(0).Take(8).ToArray(), 0, 8), .revision = BitConverter.ToInt32(comBuffer.Skip(8).Take(4).ToArray(), 0), .header_size = BitConverter.ToInt32(comBuffer.Skip(12).Take(4).ToArray(), 0), .crc_header = BitConverter.ToInt32(comBuffer.Skip(16).Take(4).ToArray(), 0), .reserved = BitConverter.ToInt32(comBuffer.Skip(20).Take(4).ToArray(), 0), .current_lba = BitConverter.ToInt32(comBuffer.Skip(24).Take(8).ToArray(), 0), .backup_lba = BitConverter.ToInt32(comBuffer.Skip(32).Take(8).ToArray(), 0), .first_usable_lba = BitConverter.ToInt32(comBuffer.Skip(40).Take(8).ToArray(), 0), .last_usable_lba = BitConverter.ToInt32(comBuffer.Skip(48).Take(8).ToArray(), 0), .disk_guid = comBuffer.Skip(56).Take(16).ToArray(), .starting_lba_pe = BitConverter.ToInt32(comBuffer.Skip(72).Take(8).ToArray(), 0)}
                    Dim numParts() As Byte = comBuffer.Skip(80).Take(4).ToArray()
                    gpt.header.number_partitions = BitConverter.ToInt32(comBuffer.Skip(80).Take(4).ToArray(), 0)
                    gpt.header.size_partition_entries = BitConverter.ToInt32(comBuffer.Skip(84).Take(4).ToArray(), 0)
                    Dim hardDriveSizeBytes As Decimal = gpt.header.last_usable_lba * CDec(512)
                    Dim hardDriveSizeGb As Decimal = hardDriveSizeBytes / 1073741824
                    hardDriveSizeGb = Math.Round(hardDriveSizeGb, 2)

                    RichLogs("Found eMMC " + Conversions.ToString(hardDriveSizeGb) + "GB ", Color.White, True, False)

                    Return True
                End If
            ElseIf storage.ToLower = "ufs" Then
                Dim retry As Integer = 0
                Do
                    If retry = 6 Then
                        RichLogs("GPT Not Found", Color.Red, True, True)
                        Return False
                    End If

                    SendXml(pkt_read(SectorSize, 1, lun, 1 + retry))
                    Dim comBuffer() As Byte = readByte(4096)


                    If comBuffer.Length > 200 Then
                        Dim s As String = Encoding.UTF8.GetString(comBuffer, 0, comBuffer.Length)
                        If Not s.Contains("EFI") Then
                            RichLogs("No Valid Gpt", Color.Red, True, True)
                            Return False
                        End If
                        gpt.header = New gpt_header With {.signature = Encoding.UTF8.GetString(comBuffer.Skip(0).Take(8).ToArray(), 0, 8), .revision = BitConverter.ToInt32(comBuffer.Skip(8).Take(4).ToArray(), 0), .header_size = BitConverter.ToInt32(comBuffer.Skip(12).Take(4).ToArray(), 0), .crc_header = BitConverter.ToInt32(comBuffer.Skip(16).Take(4).ToArray(), 0), .reserved = BitConverter.ToInt32(comBuffer.Skip(20).Take(4).ToArray(), 0), .current_lba = BitConverter.ToInt32(comBuffer.Skip(24).Take(8).ToArray(), 0), .backup_lba = BitConverter.ToInt32(comBuffer.Skip(32).Take(8).ToArray(), 0), .first_usable_lba = BitConverter.ToInt32(comBuffer.Skip(40).Take(8).ToArray(), 0), .last_usable_lba = BitConverter.ToInt32(comBuffer.Skip(48).Take(8).ToArray(), 0), .disk_guid = comBuffer.Skip(56).Take(16).ToArray(), .starting_lba_pe = BitConverter.ToInt32(comBuffer.Skip(72).Take(8).ToArray(), 0)}
                        Dim numParts() As Byte = comBuffer.Skip(80).Take(4).ToArray()
                        gpt.header.number_partitions = BitConverter.ToInt32(comBuffer.Skip(80).Take(4).ToArray(), 0)
                        gpt.header.size_partition_entries = BitConverter.ToInt32(comBuffer.Skip(84).Take(4).ToArray(), 0)
                        Dim hardDriveSizeBytes As Decimal = gpt.header.last_usable_lba * CDec(4096)
                        Dim hardDriveSizeGb As Decimal = hardDriveSizeBytes / 1073741824
                        hardDriveSizeGb = Math.Round(hardDriveSizeGb, 2)

                        RichLogs("Found UFS " + Conversions.ToString(hardDriveSizeGb) + "GB ", Color.White, True, False)
                        Return True
                    End If
                Loop
            End If
            Return False
        End Function

        Public Shared Function EraseParts(SectSize As String, numPartSect As String, PhysicalPartition As String, startSector As String) As Boolean
            Dim totalhapus As Integer = 1048576
            Dim bytesec As Long = 0
            Dim PacketSize As Integer = 16384
            If numPartSect * SectSize >= totalhapus Then
                bytesec = totalhapus / SectSize
            Else
                bytesec = numPartSect
            End If
            If numPartSect = 0 Then
                bytesec = totalhapus / SectSize
            End If
            Dim legthFile = bytesec * SectSize
            Dim byteswritten As Long = 0
            Dim offset As Long = 0
            Dim i As Integer = 0
            Dim pkt = pkt_Program(SectorSize, bytesec, PhysicalPartition, startSector)
            SendXml(pkt)

            If Not IsAck() Then
                Return False
            Else
                Try
                    Do
                        If byteswritten = legthFile Then
                            If IsAck() Then
                                Return True
                            Else
                                Return False
                            End If
                        End If
                        If legthFile - byteswritten < PacketSize Then
                            PacketSize = legthFile - byteswritten
                        End If
                        Dim bytes As Byte() = New Byte(PacketSize - 1) {}

                        DiskWrite(bytes)
                        byteswritten += bytes.Length
                        offset += bytes.Length

                        i += 1
                    Loop
                    Return True
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Return False
                End Try
            End If
        End Function

        Public Shared Function ReadPartWarning(NumPartition As String, pname As String) As String
            Return "Read " & pname & " skipped!"
        End Function
        Public Shared Function ReadPart(Startsector As String, NumPartition As String, ByRef SectSize As String, physical As String, pname As String) As Boolean
            If NumPartition < 1 Then
                RichLogs(ReadPartWarning(NumPartition, pname), Color.Yellow, True, True)
                RichLogs("Please Try Read " & pname & " From GPT... ", Color.Yellow, True, False)
                Return False
            Else
                'If CacheBoxConsole.Checked Then
                'Return ReadpartNonConsoleMode(Startsector, NumPartition, SectSize, physical, pname)
                'Else
                Return ReadpartNonConsoleMode(Startsector, NumPartition, SectSize, physical, pname)
                'End If
            End If
        End Function
        Public Shared Function ReadpartNonConsoleMode(Startsector As String, NumPartition As String, ByRef SectSize As String, physical As String, pname As String) As Boolean
            If NumPartition < 1 Then
                RichLogs(ReadPartWarning(NumPartition, pname), Color.Yellow, True, True)
                Return True
            End If
            Try
                Dim i As Integer = 0
                Dim BYTES_TO_READ As Long = NumPartition * SectSize
                Dim totalLen = NumPartition * SectSize
                Dim fileOffset As Long = 0
                Dim bytesRead As Long = 0
                Dim SECTORS_TO_READ = NumPartition

                Dim pkt = pkt_read(SectSize, NumPartition, physical, Startsector)


                Dim stream As New FileStream(foldersave & "\" & getfilenames(pname), FileMode.Append, FileAccess.Write)
                Using stream

                    Dim buffer As Byte() = New Byte() {}
                    SendXml(pkt)
                    Dim s As Byte() = readByte()
                    If Not s.Length = 0 Then
                        fileOffset += s.Length
                        bytesRead -= s.Length
                        If fileOffset >= BYTES_TO_READ Then
                            stream.Write(s, 0, BYTES_TO_READ)
                            ProcessBar1(BYTES_TO_READ, BYTES_TO_READ)
                            stream.Close()
                            Return True
                        End If
                        stream.Write(s, 0, s.Length)
                        ProcessBar1(fileOffset, BYTES_TO_READ)
                    End If
                    Do
                        buffer = DiskRead()
                        fileOffset += buffer.Length
                        If fileOffset > BYTES_TO_READ Then
                            Dim bytesLeft = fileOffset - BYTES_TO_READ
                            Dim zz = buffer.Length - bytesLeft
                            Dim buffer2 = buffer.Take(CInt(zz)).ToArray()
                            stream.Write(buffer2, 0, buffer2.Length)
                            ProcessBar1(fileOffset - bytesLeft, BYTES_TO_READ)
                            stream.Close()
                            Exit Do
                        End If
                        stream.Write(buffer, 0, buffer.Length)
                        ProcessBar1(fileOffset, BYTES_TO_READ)
                        i += 1
                    Loop
                End Using
                Return True
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try
        End Function

        Public Shared Function readByte() As Byte()
            tot = 0
            Try
                Dim buff As Byte() = New Byte() {}
                Do
                    Dim s As Byte() = DiskRead()
                    If Not Encoding.UTF8.GetString(s).ToLower.Contains("ack") Then
                        Continue Do
                    End If
                    If Encoding.UTF8.GetString(s).ToLower.Contains("nak") Then
                        logs(Encoding.UTF8.GetString(s), True, Merah)
                        Throw New Exception(Encoding.UTF8.GetString(s))
                    End If
                    If Encoding.UTF8.GetString(s).ToLower.Contains("ack") Then
                        findOffset(s.Take(512).ToArray, "</data>")
                        Dim totlb = lb.Items.Count
                        Dim ks As String = lb.Items(totlb - 1)
                        buff = s.Skip(ks + 7).ToArray
                        Exit Do
                    End If
                Loop
                Return buff
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return {}
            End Try
        End Function

        Public Shared Function readByte(ByVal len As String) As Byte()
            tot = 0
            Try
                Dim i As Integer = 0
                Dim BYTES_TO_READ As Long = len
                Dim bytesRead As Long = 0
                Dim Buffout As Byte() = New Byte((len + 512) - 1) {}
                Dim buff As Byte() = New Byte() {}
                Do
                    If i = 0 Then
                        Dim s As Byte() = DiskRead()
                        If Encoding.UTF8.GetString(s).ToLower.Contains("nak") Then
                            Throw New Exception("Error nak")
                        End If
                        If Not Encoding.UTF8.GetString(s).ToLower.Contains("ack") Then
                            Continue Do
                        End If
                        findOffset(s.Take(200).ToArray, "</data>")
                        Dim totlb = lb.Items.Count
                        If totlb = 0 Then
                        Else
                            Dim ks As String = lb.Items(totlb - 1)
                            buff = s.Skip(ks + 7).ToArray
                        End If
                    Else
                        buff = DiskRead()
                    End If
                    Buffer.BlockCopy(buff, 0, Buffout, bytesRead, buff.Length)
                    bytesRead += buff.Length
                    i += 1
                    If bytesRead > BYTES_TO_READ Then
                        Exit Do
                    End If
                Loop
                Return Buffout.Take(len).ToArray
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return {}
            End Try
        End Function

        Public Shared Function findOffset(inpubytes() As Byte, ByVal oldstring As String)
            Dim query = System.Text.Encoding.UTF8.GetBytes(oldstring)

            lb.Items.Clear()
            lb = New ListBox()

            Using reader As New BinaryReader(New MemoryStream(inpubytes))
                Dim length As Integer = reader.BaseStream.Length
                If query.Length <= length Then
                    ' process initial (first) search
                    Dim values As Byte() = reader.ReadBytes(query.Length)
                    Dim found As Boolean = False
                    For fnd As Integer = 0 To query.Length - 1
                        If values(fnd) <> query(fnd) Then
                            found = False
                            Exit For
                        End If
                        found = True
                    Next fnd
                    If found = True Then


                        Return 0
                    Else ' keep searching the rest of the binary stream
                        For pos As Integer = query.Length To length - 1
                            ' shift values over 1, [1,2,3,4] => [2,3,4,4]
                            Array.Copy(values, 1, values, 0, values.Length - 1)
                            ' put the next new byte at the end
                            values(values.Length - 1) = reader.ReadByte()
                            For fnd As Integer = 0 To query.Length - 1
                                If values(fnd) <> query(fnd) Then
                                    found = False
                                    Exit For
                                End If
                                found = True
                            Next fnd
                            If found = True Then
                                '[  RichTextBox1.Text += (pos - (query.Length - 1)).ToString & vbNewLine

                                lb.Items.Add((pos - (query.Length - 1)).ToString)
                                '         RichTextBox1.Invoke(CType(Sub() RichTextBox1.Text += "found " & (pos - (query.Length - 1)) & vbCrLf, Action))


                            End If
                        Next pos

                    End If
                End If
            End Using

            Return -1 ' not found
        End Function

        Public Shared Sub WorkerFlashRun(sender As Object, e As DoWorkEventArgs)
            MenuEx = MenuEksekusi.manual
            If QcFlash.SharedUI.CheckBoxServer.Checked Then
                RichLogs("Operation  : ", Color.White, True, False)
                RichLogs(MenuManual, Color.Orange, True, True)
                RichLogs(" Brand     : ", Color.White, True, False)
                RichLogs(QcFlash.SharedUI.ComboBoxEditBrand.Text, Color.DeepSkyBlue, True, True)
                RichLogs(" Devices   : ", Color.White, True, False)
                RichLogs(QcFlash.SharedUI.ComboBoxEditModels.Text, Color.DeepSkyBlue, True, True)
                RichLogs(" Model     : ", Color.White, True, False)
                RichLogs(TypeTerpilih, Color.DeepSkyBlue, True, True)
                RichLogs(" Platform  : ", Color.White, True, False)
                RichLogs("Qualcomm", Color.DeepSkyBlue, True, True)
                RichLogs(" Connect   : ", Color.White, True, False)
                RichLogs("Auth", Color.DeepSkyBlue, True, True)
                RichLogs("Dowloading Loader Data  : ", Color.White, True, False)

                Dim numArray As Byte() = getfile("loader.bin", False)
                RichLogs("Done  ✓", Color.Yellow, True, True)
                OutDecripted = numArray
                RichLogs(String.Concat("Checking Data" & vbTab & vbTab & ":  ", GetFileSize(numArray.Length), " : "), Color.White, True, False)

                If CryptStream(keyEncrypt, numArray, False, "loader", 0L) Then

                    If Not Encoding.UTF8.GetString(loader.Take(20).ToArray()).ToUpper().Contains("ELF") Then
                        Return
                    End If
                    RichLogs("Done  ✓", Color.Yellow, True, True)
                Else
                    RichLogs("Failed", Color.Red, True, True)
                    Return
                End If

            Else
                RichLogs("Operation  : ", Color.White, True, False)
                RichLogs(MenuManual, Color.Orange, True, True)
                RichLogs(" Brand     : ", Color.White, True, False)
                RichLogs(" - ", Color.DeepSkyBlue, True, True)
                RichLogs(" Model     : ", Color.White, True, False)
                RichLogs(" - ", Color.DeepSkyBlue, True, True)
                RichLogs(" Platform  : ", Color.White, True, False)
                RichLogs("Qualcomm", Color.DeepSkyBlue, True, True)
                RichLogs(" Connect   : ", Color.White, True, False)
                RichLogs("Auth", Color.DeepSkyBlue, True, True)
                If Not QcFlash.SharedUI.TxtFlashLoader.Text = "" Then
                    RichLogs("Checking Custom Firehose       : ", Color.White, True, False)
                    loader = File.ReadAllBytes(QcFlash.SharedUI.TxtFlashLoader.Text)
                    If Not Encoding.UTF8.GetString(loader).Contains("ELF") Then
                        RichLogs("Loader is Invalid Or Encrypted  ", Color.Red, True, False)
                        Return
                    End If
                    RichLogs("Ok ", Color.Yellow, True, True)
                End If

            End If
            RichLogs("Searching Qualcomm Usb Devices : ", Color.White, True, False)
            While Not QcomWorker.CancellationPending
                If WaktuCari = 0 Then
                    RichLogs("Not Founds", Color.Red, True, True)
                    TimeSpanElapsed.ElapsedTime(Watch)
                    Watch.Stop()
                    portsfound = False
                    Return
                End If
                If CariPorts() Then
                    portsfound = True
                    Return
                End If
                Thread.Sleep(1000)
                Main.SharedUI.LabelTimer.Invoke(Sub()
                                                    Main.SharedUI.LabelTimer.Visible = True
                                                    Main.SharedUI.LabelTimer.Text = Conversions.ToString(WaktuCari)
                                                End Sub)
                Dim ptr As Integer = WaktuCari
                WaktuCari = ptr - 1
            End While
            e.Cancel = True
            RichLogs("Process stoped", Color.Red, True, True)
            TimeSpanElapsed.ElapsedTime(Watch)
            Watch.Stop()
            Return
        End Sub

        Public Shared Sub WorkerOneclickhRun(sender As Object, e As DoWorkEventArgs)
            MenuEx = MenuEksekusi.oneclick
            Setwaktu()
            RichLogs("Searching Qualcomm Usb Devices" & vbTab & ":  ", Color.Yellow, True, False)
            While Not QcomWorker.CancellationPending
                If WaktuCari = 0 Then
                    RichLogs("Not Founds", Color.Red, True, True)
                    TimeSpanElapsed.ElapsedTime(Watch)
                    Watch.Stop()
                    portsfound = False
                    Return
                End If
                If CariPorts() Then
                    portsfound = True
                    Return
                End If
                Thread.Sleep(1000)
                Main.SharedUI.LabelTimer.Invoke(Sub()
                                                    Main.SharedUI.LabelTimer.Visible = True
                                                    Main.SharedUI.LabelTimer.Text = Conversions.ToString(WaktuCari)
                                                End Sub)
                Dim ptr As Integer = WaktuCari
                WaktuCari = ptr - 1
            End While
            e.Cancel = True
            RichLogs("Process stoped", Color.Red, True, True)
            TimeSpanElapsed.ElapsedTime(Watch)
            Watch.Stop()
            Return
        End Sub
    End Class
End Namespace