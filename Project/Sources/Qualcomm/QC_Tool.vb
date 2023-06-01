Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.IO.Ports
Imports System.Linq
Imports System.Management
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json.Linq
Imports Qualcom_Flash.My
Imports Qualcom_Flash.QcFlash

Namespace Qualcom_Flash.Qualcomm
    Public Class QC_Tool

        Public Shared Booln As Boolean
        Public Shared buttontypehp As Button
        Public Shared eksekusiButton As Button
        Public Shared paneltype As Panel
        Public Shared saharaManager As Bismillah.SAHARA.SAHARA_MANAGER
        Public Shared CariPortQcom As System.Windows.Forms.Timer
        Public RichTextBox As RichTextBox

        Public Shared keyEncrypt As String = "BabiBangsad"
        Public Shared loader As Byte() = New Byte(-1) {}
        Public Shared MenuEx As MenuEksekusi = MenuEksekusi.manual
        Public Shared MerkTerpilih As String = ""
        Public Shared OutDecripted As Byte() = New Byte(-1) {}
        Public Shared PortQcom As Integer = 0
        Public Shared SectorSize As String = "512"
        Public Shared sendingloaderStatus As Boolean = False
        Public Shared TypeMemory As String = "emmc"
        Public Shared typeterpilih As String = ""
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

        Public Shared Biru As Object
        Public Shared bta As String
        Public Shared CheckKelar As Integer
        Public Shared chunkheader As CHUNK_HEADER
        Public Shared datafile As String
        Public Shared DeviceExist As Boolean
        Public Shared DoubleBytes As Double
        Public Shared EncryptedDownloadData As Byte()
        Public Shared EncryptedLoader As Boolean
        Public Shared foldersave As String
        'Private gettypehpnya As ComboBox
        Public Shared gpt As FIREHOSE_GPT
        Public Shared Kuning As Object
        Public Shared MenuManual As String
        Public Shared Merah As Object
        Public Shared NumDigestsFound As Long
        Public Shared Ports As SerialPort
        Public Shared server As String
        Public Shared serverFolderFile As String
        Public Shared xmlpatch As String
        Public Shared SnAdb As String
        Public Shared sparseheader As SPARSE_HEADER
        Public Shared timeout As UInteger
        Public Shared tot As Integer
        Public Shared totalchecked As Integer
        Public Shared totalchunk As Integer
        Shared Property ui As uiManager
        Public Shared WaktuCari As Integer

        Public Property datadownload As Byte()
        Public Property UrlOneClick As String
        Public Property DigestSizeInBytes As Integer

        Public Shared PatchString As String
        Public Shared LoadFolderXml As String
        Public Shared Property lvi As ListViewItem
        Public Shared Property StringXml As String
        Public Shared Property FilesOneClick As Byte()
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
            Private ReadOnly crc_partition As Integer
            Private ReadOnly reserved2 As Byte
        End Structure

        Public Structure gpt_partition_entry
            Public ReadOnly Property num512Sectors As Integer
                Get
                    Return Me.last_lba - Me.first_lba + 1
                End Get
            End Property

            Public partTypeGUID As String
            Public partID As String
            Public first_lba As Integer
            Public last_lba As Integer
            Public flags As Byte()
            Public partName As String

        End Structure

        Public Enum MessageType
            Incoming
            Outgoing
            ok
            Warning
            [Error]
        End Enum

        Public Sub New(ui As uiManager)
            MyBase.New()
            Dim listView As ListView = Qualcom_Flash.QcFlash.ListViewQc
            Me.ui = New uiManager
            QC_Tool.ui = New uiManager
            Me.Merah = uiManager.MessageType.[Error]
            Me.Kuning = uiManager.MessageType.Warning
            Me.Biru = uiManager.MessageType.Incoming
            Me.ui.rtb = XtraMain.RichTextBox
            Me.RichTextBox = XtraMain.RichTextBox
        End Sub

        Public Shared Sub ProcessBar1(Process As Long, total As Long)
            QC_Tool.ui.ProgressBar1.Invoke(New Action(Sub()

                                                          QC_Tool.ui.ProgressBar1.Value = CInt(Math.Round(CDbl((Process * 100L)) / CDbl(total)))
                                                      End Sub))
        End Sub

        Public Shared Sub ProcessBar2(Process As Long, total As Long)
            QC_Tool.ui.ProgressBar2.Invoke(New Action(Sub()
                                                          QC_Tool.ui.ProgressBar2.Value = CInt(Math.Round(CDbl((Process * 100L)) / CDbl(total)))
                                                      End Sub))
        End Sub


        Private Sub exectype(sender As Object, e As EventArgs)
            Dim button As Button = CType(sender, Button)
            typeterpilih = Conversions.ToString(button.Tag)
            'QC_Tool.panelheadertype.Controls.Clear()
            'QC_Tool.paneleksekusi.Controls.Clear()
            'QC_Tool.panelheadertype.Controls.Clear()
            'QC_Tool.buttontypehp.Location = New Point(10, 1)
            'QC_Tool.buttontypehp.Text = typeterpilih
            'QC_Tool.buttontypehp.Size = New Size(260, 40)
            'QC_Tool.buttontypehp.BackColor = Color.DimGray
            'QC_Tool.buttontypehp.ForeColor = Color.White
            'QC_Tool.buttontypehp.Enabled = True
            'QC_Tool.paneleksekusi.Visible = True
            'QC_Tool.panelheadertype.Visible = True
            'QC_Tool.panelheadertype.Controls.Add(QC_Tool.buttontypehp)
            'Try
            '	Dim webRequest As WebRequest = webRequest.Create(String.Concat(New String() {QC_Tool.server, MerkTerpilih.ToUpper(), "/", typeterpilih, ".txt"}))
            'WebRequest.Method = "POST"
            'WebRequest.ContentType = "application/x-www-form-urlencoded"
            'WebRequest.Timeout = 10000
            '	Dim stream As Stream = webRequest.GetRequestStream()
            'Stream.Close()
            '	Dim response As WebResponse = webRequest.GetResponse()
            'Stream = response.GetResponseStream()
            'Dim streamReader As New StreamReader(stream)
            '			Dim num As Integer = 20
            '			Dim httpWebResponse As HttpWebResponse = CType(webRequest.GetResponse(), HttpWebResponse)
            'If httpWebResponse.StatusCode <> HttpStatusCode.OK Then
            '	Interaction.MsgBox("server Error " + Conversions.ToString(CInt(httpWebResponse.StatusCode)), MsgBoxStyle.OkOnly, Nothing)
            'Else
            'While Not streamReader.EndOfStream
            'QC_Tool.eksekusiButton = New Button()
            'Dim text As String = streamReader.ReadLine()
            'QC_Tool.eksekusiButton.Size = New Size(230, 30)
            'QC_Tool.eksekusiButton.Location = CType(New Size(28, num), Point)
            'QC_Tool.eksekusiButton.BackColor = Color.DimGray
            'QC_Tool.eksekusiButton.ForeColor = Color.White
            'QC_Tool.eksekusiButton.Text = text
            'QC_Tool.paneleksekusi.Controls.Add(QC_Tool.eksekusiButton)
            'num += 30
            'AddHandler QC_Tool.eksekusiButton.Click, AddressOf QC_Tool.DoExecOneClick
            'End While
            'End If
            'Catch ex As Exception
            'Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
            'End Try
        End Sub

        Public Shared Sub logs(ByVal Textlogs As String, ByVal newline As Boolean, ByVal warna As uiManager.MessageType)
            If (Not newline) Then
                QC_Tool.DisplayData(warna, Textlogs, True)
            Else
                QC_Tool.DisplayData(warna, String.Concat(Textlogs, "" & vbCrLf & ""), True)
            End If
        End Sub
        Public Shared Sub DisplayData(type As uiManager.MessageType, msg As String, bold As Boolean)
            Dim MessageColor = New Color() {Color.DeepSkyBlue, Color.AliceBlue, Color.Green, Color.Yellow, Color.Red}
            Dim rtb = XtraMain.RichTextBox
            Dim _displayWindow As RichTextBox = rtb
            _displayWindow.Invoke(New EventHandler(Sub(sender As Object, e As EventArgs)
                                                       rtb.SelectionStart = rtb.TextLength
                                                       rtb.SelectionLength = 0
                                                       rtb.SelectionColor = MessageColor(CInt(type))
                                                       If (Not bold) Then
                                                           'rtb.SelectionFont = New Font(CStr(rtb.SelectionFont), FontStyle.Regular)
                                                       Else
                                                           'rtb.SelectionFont = New Font(CStr(rtb.SelectionFont), FontStyle.Regular)
                                                       End If
                                                       rtb.SelectionBullet = False
                                                       rtb.AppendText(msg)
                                                       rtb.ScrollToCaret()
                                                   End Sub))
        End Sub


        Public Shared Sub Log2(s As String, color As Color, isBold As Boolean, Optional newline As Boolean = False)
            If newline AndAlso XtraMain.RichTextBox.TextLength > 0 Then
                XtraMain.RichTextBox.AppendText(vbCrLf)
            End If
            XtraMain.RichTextBox.SelectionStart = XtraMain.RichTextBox.Text.Length
            Dim selectionColor As Color = XtraMain.RichTextBox.SelectionColor
            XtraMain.RichTextBox.SelectionColor = color
            If isBold Then
                XtraMain.RichTextBox.SelectionFont = New Font(XtraMain.RichTextBox.Font, FontStyle.Regular)
            End If
            XtraMain.RichTextBox.AppendText(s)
            XtraMain.RichTextBox.SelectionColor = selectionColor
            XtraMain.RichTextBox.SelectionFont = New Font(XtraMain.RichTextBox.Font, FontStyle.Regular)
            XtraMain.RichTextBox.ScrollToCaret()
        End Sub

        Public Shared Function getfile(namafile As String, pbar As Boolean) As Byte()
            Dim s As String = String.Concat(New String() {"username=hadikit", "&password=mtktest", "&merk=", MerkTerpilih.ToUpper(), "&type=", typeterpilih, "&file=", namafile})
            Dim requestUriString As String = "http://adanichelltool.com/api/download.php"
            Dim result As Byte()
            Try
                Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(requestUriString), HttpWebRequest)
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(s)
                httpWebRequest.Method = "POST"
                httpWebRequest.Timeout = 600000
                httpWebRequest.ContentType = "application/x-www-form-urlencoded"
                httpWebRequest.ContentLength = CLng(bytes.Length)
                Using requestStream As Stream = httpWebRequest.GetRequestStream()
                    requestStream.Write(bytes, 0, bytes.Length)
                End Using
                Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Dim num As Double = CDbl(httpWebResponse.ContentLength)
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
                            'XtraMain.ProcessBar1(CLng(num3), CLng(Math.Round(num)))
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
            XtraMain.RichTextBox.Clear()
        End Sub

        Public Shared Sub DoExecOneClick(sender As Object, e As EventArgs)
            Dim str As String = Conversions.ToString(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing))
            QC_Tool.RtbClear()
            QC_Tool.logs("Dowloading Loader Data : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
            Dim array As Byte() = QC_Tool.getfile("loader.bin", False)
            OutDecripted = array
            Thread.Sleep(500)
            If Not QC_Tool.CryptStream(keyEncrypt, array, False, "loader", 0L) Then
                QC_Tool.logs("Failed ", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
            Else
                Dim [string] As String = Encoding.UTF8.GetString(loader.Take(20).ToArray())
                If Not [string].ToUpper().Contains("ELF") Then
                    QC_Tool.logs(" Invalid Loader Data", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                Else
                    QC_Tool.logs("Done  ", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                    QC_Tool.logs("Dowloading Support Data : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                    Dim array2 As Byte() = QC_Tool.getfile((str + ".xml").Replace(" ", "%20").Replace("+", "%2b"), False)
                    OutDecripted = array2
                    Thread.Sleep(500)
                    If QC_Tool.CryptStream(keyEncrypt, array2, False, "xml", 0L) Then
                        If Not QC_Tool.StringXml.ToLower().Contains("xml") Then
                            QC_Tool.logs("Invalid xml Data", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                        Else
                            QC_Tool.logs("Done", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                            QC_Tool.GetInfDrive()
                            QC_Tool.Setwaktu()
                            QC_Tool.logs("Searching Qualcomm Usb Devices : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                            QC_Tool.CariPortQcom.Start()
                        End If
                    End If
                End If
            End If
        End Sub

        Public Shared Function GetInfDrive() As Boolean
            Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
            Try
                Try
                    enumerator = (New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=""{4d36e978-e325-11ce-bfc1-08002be10318}"" and Name LIKE '%Qualcomm HS-USB QDLoader 9008%'")).[Get]().GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As ManagementObject = DirectCast(enumerator.Current, ManagementObject)
                        QC_Tool.logs("Download Port : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                        QC_Tool.Log2(String.Concat(current.GetPropertyValue("Name").ToString(), "" & vbCrLf & ""), Color.Orange, True, False)
                        QC_Tool.Booln = True
                        QC_Tool.logs("Driver Manufacturer : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                        QC_Tool.Log2(String.Concat(current.GetPropertyValue("Manufacturer").ToString(), "" & vbCrLf & ""), Color.Red, True, False)
                        QC_Tool.logs("USB HWID : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                        QC_Tool.Log2(String.Concat(current.GetPropertyValue("DeviceID").ToString(), "" & vbCrLf & ""), Color.White, True, False)
                        QC_Tool.logs("Class Guid : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                        QC_Tool.Log2(String.Concat(current.GetPropertyValue("ClassGuid").ToString(), "" & vbCrLf & ""), Color.White, True, False)
                        QC_Tool.logs("Driver Status : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                        QC_Tool.Log2(String.Concat(current.GetPropertyValue("Status").ToString(), "" & vbCrLf & ""), Color.LimeGreen, True, False)
                        QC_Tool.logs("Connection Status : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                        QC_Tool.Log2("XHCI:HUB:USB 2.00 ", Color.Orange, True, False)
                        QC_Tool.Log2("High-Speed" & vbCrLf & "", Color.LimeGreen, True, False)
                    End While
                Finally
                    If (enumerator IsNot Nothing) Then
                        DirectCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                ProjectData.SetProjectError(exception)
                QC_Tool.Booln = False
                ProjectData.ClearProjectError()
                ProjectData.ClearProjectError()
            End Try
            Return QC_Tool.Booln
        End Function

        Public Shared Sub EncryptFile(password As String, in_file As Byte(), Filenya As String)
            QC_Tool.CryptFile(password, in_file, OutDecripted, True, Filenya)
        End Sub


        Public Shared Sub DecryptFile(password As String, in_file As Byte(), FileNYa As String)
            QC_Tool.CryptFile(password, in_file, OutDecripted, False, FileNYa)
        End Sub


        Public Shared Sub CryptFile(password As String, in_file As Byte(), out_file As Byte(), encrypt As Boolean, Filenya As String)
            Using New MemoryStream(in_file)
                Using New MemoryStream(OutDecripted)
                    QC_Tool.CryptStream(password, in_file, encrypt, Filenya, 0L)
                End Using
            End Using
        End Sub

        Public Shared Function CryptStream(password As String, in_stream As Byte(), encrypt As Boolean, Filenya As String, PanjangFile As Long) As Boolean
            If String.IsNullOrEmpty(Filenya) Then
                Throw New ArgumentException($"'{NameOf(Filenya)}' cannot be null or empty.", NameOf(Filenya))
            End If

            If in_stream Is Nothing Then
                Throw New ArgumentNullException(NameOf(in_stream))
            End If

            If String.IsNullOrEmpty(password) Then
                Throw New ArgumentException($"'{NameOf(password)}' cannot be null or empty.", NameOf(password))
            End If

            Dim flag As Boolean
            Dim cryptoTransform As ICryptoTransform
            Dim aesCryptoServiceProvider As New System.Security.Cryptography.AesCryptoServiceProvider()
            Dim num As Integer = 0
            Dim num1 As Integer = 1024
            Do
                If (Not aesCryptoServiceProvider.ValidKeySize(num1)) Then
                    num1 += -1
                Else
                    num = num1
                    Exit Do
                End If
            Loop While num1 >= 1
            Debug.Assert(num > 0)
            Console.WriteLine(String.Concat("Key size: ", Conversions.ToString(num)))
            Dim blockSize As Integer = aesCryptoServiceProvider.BlockSize
            Dim numArray As Byte() = Nothing
            Dim numArray1 As Byte() = Nothing
            Dim numArray2() As Byte = {0, 0, 1, 2, 3, 4, 5, 6, 241, 240, 238, 33, 34, 69}
            QC_Tool.MakeKeyAndIV(password, numArray2, num, blockSize, numArray, numArray1)
            cryptoTransform = If(Not encrypt, aesCryptoServiceProvider.CreateDecryptor(numArray, numArray1), aesCryptoServiceProvider.CreateEncryptor(numArray, numArray1))
            Dim memoryStream As New System.IO.MemoryStream()
            Dim memoryStream1 As New System.IO.MemoryStream(QC_Tool.OutDecripted)
            Dim num2 As Long = 0L
            Try
                Using memoryStream2 As New System.IO.MemoryStream(in_stream)
                    Using cryptoStream As New System.Security.Cryptography.CryptoStream(memoryStream1, cryptoTransform, CryptoStreamMode.Write)
                        Dim numArray3(1024) As Byte
                        While True
                            Dim num3 As Integer = memoryStream2.Read(numArray3, 0, 1024)
                            num2 += CLng(num3)
                            If (num3 = 0) Then
                                Exit While
                            End If
                            cryptoStream.Write(numArray3, 0, num3)
                        End While
                    End Using
                End Using
                If (Operators.CompareString(Filenya, "loader", False) = 0) Then
                    QC_Tool.loader = QC_Tool.GetRawData(QC_Tool.OutDecripted.Take(CInt(num2)).ToArray())
                ElseIf (Operators.CompareString(Filenya, "xml", False) = 0) Then
                    Dim rawData As Byte() = QC_Tool.GetRawData(QC_Tool.OutDecripted.Take(CInt(num2)).ToArray())
                    Dim num4 As Integer = QC_Tool.FilterData(rawData)
                    Dim str As String = Encoding.UTF8.GetString(rawData)
                    QC_Tool.StringXml = New String(str.Skip(num4 - 1).ToArray())
                ElseIf (Operators.CompareString(Filenya, "raw", False) = 0) Then
                    QC_Tool.FilesOneClick = QC_Tool.GetRawData(QC_Tool.OutDecripted.Take(CInt(num2)).ToArray())
                End If
                cryptoTransform.Dispose()
                flag = True
            Catch exception1 As System.Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As System.Exception = exception1
                cryptoTransform.Dispose()
                QC_Tool.logs(exception.ToString(), True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                flag = False
                ProjectData.ClearProjectError()
            End Try
            Return flag
        End Function

        Public Shared Function FilterData(inputdata As Byte()) As Integer
            Dim numArray(3) As Byte
            Dim memoryStream As Stream = New System.IO.MemoryStream(inputdata)
            Dim num As Integer = 0
            While True
                memoryStream.Seek(CLng(num), SeekOrigin.Begin)
                memoryStream.Read(numArray, 0, CInt(numArray.Length))
                If (Encoding.UTF8.GetString(numArray).ToLower().Contains("<?x")) Then
                    Exit While
                End If
                num += 1
            End While
            Return num
        End Function

        Public Shared Function GetRawData(inputdata As Byte()) As Byte()
            Dim numArray(4) As Byte
            Dim memoryStream As Stream = New System.IO.MemoryStream(inputdata)
            Dim num As Integer = 0
            While True
                memoryStream.Seek(CLng((CInt(inputdata.Length) - num)), SeekOrigin.Begin)
                memoryStream.Read(numArray, 0, CInt(numArray.Length))
                If (Operators.CompareString(Encoding.UTF8.GetString(numArray), "EndCF", False) = 0) Then
                    Exit While
                End If
                num = num + 1
            End While
            Dim array As Byte() = inputdata.Take(CInt(inputdata.Length) - num).ToArray()
            Return array
        End Function

        Public Shared Sub MakeKeyAndIV(password As String, salt As Byte(), key_size_bits As Integer, block_size_bits As Integer, ByRef key As Byte(), ByRef iv As Byte())
            Dim rfc2898DeriveBytes As New Rfc2898DeriveBytes(password, salt, 1000)
            key = rfc2898DeriveBytes.GetBytes(CInt(Math.Round(CDbl(key_size_bits) / 8.0)))
            iv = rfc2898DeriveBytes.GetBytes(CInt(Math.Round(CDbl(block_size_bits) / 8.0)))
        End Sub
        Public Shared Sub Setwaktu()
            QC_Tool.WaktuCari = 60
            'QC_Tool.Label1.Text = Conversions.ToString(QC_Tool.WaktuCari)
            'QC_Tool.Label1.Visible = True
        End Sub
        Public Shared Sub OpenPorts()
            Try
                QC_Tool.Ports.BaudRate = 921600
                QC_Tool.Ports.Handshake = Handshake.None
                QC_Tool.Ports.DataBits = 8
                QC_Tool.Ports.StopBits = StopBits.One
                QC_Tool.Ports.Parity = Parity.None
                QC_Tool.Ports.DtrEnable = True
                QC_Tool.Ports.NewLine = Environment.NewLine
                QC_Tool.Ports.PortName = String.Concat("COM", Conversions.ToString(QC_Tool.PortQcom))
                QC_Tool.Ports.Open()
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Interaction.MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
                ProjectData.ClearProjectError()
            End Try
        End Sub


        Public Shared Sub CariPortQcom_Tick(sender As Object, e As EventArgs)
            Dim ptr As Integer = QC_Tool.WaktuCari
            QC_Tool.WaktuCari = ptr - 1
            If QC_Tool.WaktuCari = 0 Then
                QC_Tool.logs("Not Found...", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                QC_Tool.CariPortQcom.[Stop]()
                'QC_Tool.Label1.Visible = False
            End If
            'QC_Tool.Label1.Text = Conversions.ToString(QC_Tool.WaktuCari)
            QC_Tool.CariPorts()
        End Sub

        Public Shared Sub CariPorts()
            Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
            Try
                Using managementObjectSearcher As New System.Management.ManagementObjectSearcher("root\cimv2", "SELECT * FROM Win32_PnPEntity  WHERE Name LIKE '%9008%'  ")
                    enumerator = managementObjectSearcher.[Get]().GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As ManagementObject = DirectCast(enumerator.Current, ManagementObject)
                        XtraMain.CariPortQcom.[Stop]()
                        Dim str As String = current("Name").ToString()
                        Dim str1 As String = current("Name").ToString().Substring(current("Name").ToString().IndexOf("(COM") + 4)
                        QC_Tool.PortQcom = Conversions.ToInteger(str1.TrimEnd(New Char() {")"c}))
                        'QC_Tool.ComboBox3.Text = str
                        QC_Tool.logs(String.Concat("Found at COM", Conversions.ToString(QC_Tool.PortQcom)), True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                        Dim backgroundWorker As New System.ComponentModel.BackgroundWorker()
                        AddHandler backgroundWorker.DoWork, New DoWorkEventHandler(AddressOf QC_Tool.sendingLoader)
                        AddHandler backgroundWorker.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf QC_Tool.sendingloaderDone)
                        AddHandler backgroundWorker.ProgressChanged, New ProgressChangedEventHandler(AddressOf QC_Tool.ProcessSendingLoader)
                        backgroundWorker.RunWorkerAsync()
                        backgroundWorker.Dispose()
                    End While
                End Using
            Catch managementException1 As System.Management.ManagementException
                ProjectData.SetProjectError(managementException1)
                Dim managementException As System.Management.ManagementException = managementException1
                MessageBox.Show(String.Concat("An error occurred while querying for WMI data: ", managementException.Message))
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Public Shared Sub ProcessSendingLoader(sender As Object, e As ProgressChangedEventArgs)
            QC_Tool.logs(e.ToString(), True, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
        End Sub

        Public Shared Sub sendingLoader(sender As Object, e As DoWorkEventArgs)
            Thread.Sleep(500)
            Thread.Sleep(500)
            QC_Tool.saharaManager = New Bismillah.SAHARA.SAHARA_MANAGER(QC_Tool.ui)
        End Sub

        Private Shared Sub ConnectToFlshLoader(sender As Object, e As DoWorkEventArgs)
            Dim xmlTextReader As System.Xml.XmlTextReader
            Try
                QC_Tool.OpenPorts()
                QC_Tool.logs("Connect To Flash Storage : ... ", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                Thread.Sleep(500)
                If (QC_Tool.MenuEx = QC_Tool.MenuEksekusi.oneclick) Then
                    xmlTextReader = New System.Xml.XmlTextReader(New StringReader(QC_Tool.StringXml))
                    While True
                        If (Not xmlTextReader.Read()) Then
                            Exit While
                        ElseIf (xmlTextReader.NodeType = XmlNodeType.Element AndAlso Operators.CompareString(xmlTextReader.Name.ToLower(), "program", False) = 0 Or Operators.CompareString(xmlTextReader.Name.ToLower(), "erase", False) = 0 Or Operators.CompareString(xmlTextReader.Name.ToLower(), "patch", False) = 0) Then
                            QC_Tool.SectorSize = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                            Exit While
                        End If
                    End While
                    If (Operators.CompareString(QC_Tool.SectorSize, "512", False) = 0) Then
                        QC_Tool.TypeMemory = "emmc"
                    ElseIf (Operators.CompareString(QC_Tool.SectorSize, "4096", False) <> 0) Then
                        QC_Tool.logs("Failed Get Sector Size From data Server", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                        Return
                    Else
                        QC_Tool.TypeMemory = "ufs"
                    End If
                End If
                Dim str As String = Bismillah.FIREHOSE.firehose_pkts.pkt_fhConfig(QC_Tool.TypeMemory)
                QC_Tool.logs("Configuring : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                QC_Tool.SendXml(str)
                Dim str1 As String = QC_Tool.CekResponseConfig()
                If (str1.ToLower().Contains("ack")) Then
                    QC_Tool.logs(" Configured", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                ElseIf (Not str1.Contains("xml")) Then
                    Return
                ElseIf (str1.Contains("Only nop and sig tag")) Then
                    QC_Tool.logs("Only nop and sig tag Before Authentification", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                    QC_Tool.logs("Try Bypassing Auth", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                    Dim str2 As String = "<?xml version=""1.0"" ?><data><sig TargetName=""sig"" size_in_bytes=""256"" verbose=""1""/></data>"
                    QC_Tool.logs("Sending auth : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                    QC_Tool.SendXml(str2)
                    If (QC_Tool.isAck()) Then
                        QC_Tool.Write(File.ReadAllBytes("skip"))
                        If (Not QC_Tool.isAck()) Then
                            QC_Tool.logs("Failed", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                            Return
                        End If
                    Else
                        QC_Tool.logs("Failed", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                        Return
                    End If
                End If
                If (QC_Tool.MenuEx <> QC_Tool.MenuEksekusi.manual) Then
                    Dim num As Long = 0L
                    Dim num1 As Long = 0L
                    If (QC_Tool.StringXml.ToLower().Contains("patch")) Then
                        xmlTextReader = New System.Xml.XmlTextReader(New StringReader(QC_Tool.StringXml))
                        While xmlTextReader.Read()
                            If (xmlTextReader.NodeType <> XmlNodeType.Element OrElse Operators.CompareString(xmlTextReader.Name, "patch", False) <> 0) Then
                                Continue While
                            End If
                            xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                            xmlTextReader.GetAttribute("byte_offset")
                            Dim attribute As String = xmlTextReader.GetAttribute("filename")
                            xmlTextReader.GetAttribute("physical_partition_number")
                            xmlTextReader.GetAttribute("size_in_bytes")
                            xmlTextReader.GetAttribute("start_sector")
                            xmlTextReader.GetAttribute("value")
                            xmlTextReader.GetAttribute("what")
                            If (Not attribute.ToLower().Contains("disk")) Then
                                Continue While
                            End If
                            num += 1L
                        End While
                    End If
                    xmlTextReader = New System.Xml.XmlTextReader(New StringReader(QC_Tool.StringXml))
                    While xmlTextReader.Read()
                        If (xmlTextReader.NodeType = XmlNodeType.Element AndAlso Operators.CompareString(xmlTextReader.Name, "patch", False) = 0) Then
                            Dim attribute1 As String = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                            Dim attribute2 As String = xmlTextReader.GetAttribute("byte_offset")
                            Dim attribute3 As String = xmlTextReader.GetAttribute("filename")
                            Dim str3 As String = xmlTextReader.GetAttribute("physical_partition_number")
                            Dim attribute4 As String = xmlTextReader.GetAttribute("size_in_bytes")
                            Dim str4 As String = xmlTextReader.GetAttribute("start_sector")
                            Dim attribute5 As String = xmlTextReader.GetAttribute("value")
                            Dim str5 As String = xmlTextReader.GetAttribute("what")
                            If (attribute3.ToLower().Contains("disk")) Then
                                Dim str6 As String = Bismillah.FIREHOSE.firehose_pkts.pkt_patch(attribute1, attribute2, attribute3, str3, attribute4, str4, attribute5, str5)
                                num1 += 1L
                                If (num1 <> 1L) Then
                                    QC_Tool.SendXmlFast(str6)
                                Else
                                    QC_Tool.logs("Patch Partition Data : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                                    QC_Tool.SendXml(str6)
                                    If (Not QC_Tool.isAck()) Then
                                        Return
                                    Else
                                        QC_Tool.ProcessBar1(num1, num)
                                    End If
                                End If
                                If (num1 = num) Then
                                    QC_Tool.ProcessBar1(num, num)
                                    QC_Tool.logs("Done ", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                                End If
                            End If
                        End If
                        If (xmlTextReader.NodeType = XmlNodeType.Element AndAlso Operators.CompareString(xmlTextReader.Name, "erase", False) = 0) Then
                            Dim attribute6 As String = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                            Dim attribute7 As String = xmlTextReader.GetAttribute("num_partition_sectors")
                            Dim str7 As String = xmlTextReader.GetAttribute("physical_partition_number")
                            Dim attribute8 As String = xmlTextReader.GetAttribute("start_sector")
                            xmlTextReader.GetAttribute("label")
                            Dim str8 As String = Bismillah.FIREHOSE.firehose_pkts.pkt_erase(attribute6, attribute7, str7, attribute8)
                            QC_Tool.logs(String.Concat("Erase Sector ", attribute8, ": "), False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                            QC_Tool.SendXml(str8)
                            If (Not QC_Tool.isAck()) Then
                                QC_Tool.logs("Failed", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                                Return
                            Else
                                QC_Tool.logs("Done" & vbCrLf & "", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                            End If
                        End If
                        If (xmlTextReader.NodeType <> XmlNodeType.Element OrElse Operators.CompareString(xmlTextReader.Name, "program", False) <> 0) Then
                            Continue While
                        End If
                        Dim attribute9 As String = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                        Dim str9 As String = xmlTextReader.GetAttribute("num_partition_sectors")
                        Dim attribute10 As String = xmlTextReader.GetAttribute("filename")
                        Dim str10 As String = xmlTextReader.GetAttribute("physical_partition_number")
                        xmlTextReader.GetAttribute("label")
                        Dim attribute11 As String = xmlTextReader.GetAttribute("start_sector")
                        If (Operators.CompareString(attribute10, "", False) <> 0) Then
                            QC_Tool.CheckKelar = 0
                            QC_Tool.logs("Downloading data : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                            QC_Tool.EncryptedDownloadData = QC_Tool.getfile(attribute10, True)
                            QC_Tool.OutDecripted = QC_Tool.EncryptedDownloadData
                            QC_Tool.logs(String.Concat("Initialized Data ", QC_Tool.GetFileSize(CLng(CInt(QC_Tool.EncryptedDownloadData.Length)))), False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                            If (Not QC_Tool.CryptStream(QC_Tool.keyEncrypt, QC_Tool.EncryptedDownloadData, False, "raw", CLng(Math.Round(Conversions.ToDouble(str9) * Conversions.ToDouble(attribute9))))) Then
                                Return
                            Else
                                QC_Tool.logs("Done", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                                If (Not QC_Tool.WriteEmmc(attribute9, str9, str10, attribute11, attribute10)) Then
                                    QC_Tool.logs("Failed", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                                    Return
                                Else
                                    QC_Tool.logs("Done" & vbCrLf & "", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                                End If
                            End If
                        Else
                            QC_Tool.logs("Writing data : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                            If (Not QC_Tool.EraseParts(attribute9, str9, str10, attribute11)) Then
                                QC_Tool.logs("Failed", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                                Return
                            Else
                                QC_Tool.logs("Done" & vbCrLf & "", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                            End If
                        End If
                    End While
                    QC_Tool.SendXmlFast(Bismillah.FIREHOSE.firehose_pkts.pkt_sendReset())
                ElseIf (Operators.CompareString(QC_Tool.MenuManual, "ident", False) = 0) Then
                    If (Operators.CompareString(QC_Tool.TypeMemory.ToLower(), "emmc", False) = 0) Then
                        QC_Tool.tot = 0
                        Thread.Sleep(500)
                        QC_Tool.logs("Reading Partition : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                        If (QC_Tool.ParseGPT(QC_Tool.TypeMemory, "0")) Then
                            Thread.Sleep(500)
                            QC_Tool.tot = 0
                            QC_Tool.ParsePartions(QC_Tool.gpt.header.starting_lba_pe, QC_Tool.TypeMemory, "0")
                            QC_Tool.logs("Done", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                        End If
                    ElseIf (Operators.CompareString(QC_Tool.TypeMemory.ToLower(), "ufs", False) = 0) Then
                        QC_Tool.tot = 0
                        If (QC_Tool.ParseGPT(QC_Tool.TypeMemory, "0")) Then
                            Thread.Sleep(500)
                            QC_Tool.tot = 0
                            QC_Tool.ParsePartions(QC_Tool.gpt.header.starting_lba_pe, QC_Tool.TypeMemory, Conversions.ToString(0))
                        End If
                        Thread.Sleep(500)
                        If (QC_Tool.ParseGPT(QC_Tool.TypeMemory, "1")) Then
                            Thread.Sleep(500)
                            QC_Tool.tot = 0
                            QC_Tool.ParsePartions(QC_Tool.gpt.header.starting_lba_pe, QC_Tool.TypeMemory, Conversions.ToString(1))
                        End If
                        Thread.Sleep(500)
                        If (QC_Tool.ParseGPT(QC_Tool.TypeMemory, "2")) Then
                            Thread.Sleep(500)
                            QC_Tool.tot = 0
                            QC_Tool.ParsePartions(QC_Tool.gpt.header.starting_lba_pe, QC_Tool.TypeMemory, Conversions.ToString(2))
                        End If
                        Thread.Sleep(500)
                        If (QC_Tool.ParseGPT(QC_Tool.TypeMemory, "3")) Then
                            Thread.Sleep(500)
                            QC_Tool.tot = 0
                            QC_Tool.ParsePartions(QC_Tool.gpt.header.starting_lba_pe, QC_Tool.TypeMemory, Conversions.ToString(3))
                        End If
                        Thread.Sleep(500)
                        If (QC_Tool.ParseGPT(QC_Tool.TypeMemory, "4")) Then
                            Thread.Sleep(500)
                            QC_Tool.tot = 0
                            QC_Tool.ParsePartions(QC_Tool.gpt.header.starting_lba_pe, QC_Tool.TypeMemory, Conversions.ToString(4))
                        End If
                        Thread.Sleep(500)
                        If (QC_Tool.ParseGPT(QC_Tool.TypeMemory, "5")) Then
                            Thread.Sleep(500)
                            QC_Tool.tot = 0
                            QC_Tool.ParsePartions(QC_Tool.gpt.header.starting_lba_pe, QC_Tool.TypeMemory, Conversions.ToString(5))
                        End If
                    End If
                ElseIf (Operators.CompareString(QC_Tool.MenuManual, "flash", False) = 0) Then
                    Dim num2 As Integer = QC_Tool.totalchecked
                    Dim num3 As Integer = 0
                    xmlTextReader = New System.Xml.XmlTextReader(New StringReader(QC_Tool.StringXml))
                    While xmlTextReader.Read()
                        If (xmlTextReader.NodeType <> XmlNodeType.Element OrElse Operators.CompareString(xmlTextReader.Name, "program", False) <> 0) Then
                            Continue While
                        End If
                        QC_Tool.SectorSize = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                        Dim str11 As String = xmlTextReader.GetAttribute("num_partition_sectors")
                        xmlTextReader.GetAttribute("label")
                        Dim attribute12 As String = xmlTextReader.GetAttribute("filename")
                        Dim str12 As String = xmlTextReader.GetAttribute("physical_partition_number")
                        Dim attribute13 As String = xmlTextReader.GetAttribute("start_sector")
                        If (Operators.CompareString(attribute12, "", False) = 0) Then
                            num3 += 1
                        ElseIf (Not File.Exists(attribute12)) Then
                            QC_Tool.logs("File Not exist , skiping" & vbCrLf & "", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                            num3 += 1
                        Else
                            num3 += 1
                            If (Not QC_Tool.WriteEmmc(QC_Tool.SectorSize, str11, str12, attribute13, attribute12)) Then
                                QC_Tool.logs("Failed", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                                Return
                            Else
                                QC_Tool.logs("Done" & vbCrLf & "", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                            End If
                        End If
                        QC_Tool.ProcessBar2(CLng(num3), CLng(num2))
                    End While
                    If (Operators.CompareString(QcFlash.CkboxSelectpartitionQc.Text, "", False) <> 0) Then
                        QC_Tool.ui.DisplayData(uiManager.MessageType.Outgoing, "Apply Patch : ", False)
                        xmlTextReader = New System.Xml.XmlTextReader(New StringReader(QC_Tool.xmlpatch))
                        While xmlTextReader.Read()
                            If (xmlTextReader.NodeType <> XmlNodeType.Element OrElse Operators.CompareString(xmlTextReader.Name, "patch", False) <> 0) Then
                                Continue While
                            End If
                            Dim str13 As String = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                            Dim attribute14 As String = xmlTextReader.GetAttribute("byte_offset")
                            Dim str14 As String = xmlTextReader.GetAttribute("filename")
                            Dim attribute15 As String = xmlTextReader.GetAttribute("physical_partition_number")
                            Dim str15 As String = xmlTextReader.GetAttribute("size_in_bytes")
                            Dim attribute16 As String = xmlTextReader.GetAttribute("start_sector")
                            Dim str16 As String = xmlTextReader.GetAttribute("value")
                            Dim attribute17 As String = xmlTextReader.GetAttribute("what")
                            If (Not str14.ToUpper().Contains("DISK")) Then
                                Continue While
                            End If
                            Dim str17 As String = Bismillah.FIREHOSE.firehose_pkts.pkt_patch(str13, attribute14, str14, attribute15, str15, attribute16, str16, attribute17)
                            QC_Tool.SendXml(str17)
                            If (QC_Tool.isAckFast()) Then
                                Continue While
                            End If
                            QC_Tool.ui.DisplayData(uiManager.MessageType.[Error], "Failed" & vbCrLf & "", False)
                            Return
                        End While
                        QC_Tool.ui.DisplayData(uiManager.MessageType.Outgoing, "Done" & vbCrLf & "", False)
                    End If
                    'If (QC_Tool.CheckBox5.Checked) Then
                    'QC_Tool.SendXml(Bismillah.FIREHOSE.firehose_pkts.BootConf())
                    'If (Not QC_Tool.isAck()) Then
                    'Return
                    'End If
                    'End If
                    If (Not XtraMain.CheckAuth.Checked) Then
                        Return
                    Else
                        QC_Tool.SendXml(Bismillah.FIREHOSE.firehose_pkts.pkt_sendReset())
                        Return
                    End If
                ElseIf (Operators.CompareString(QC_Tool.MenuManual, "erase", False) = 0) Then
                    Dim num4 As Integer = QC_Tool.totalchecked
                    Dim num5 As Integer = 0
                    xmlTextReader = New System.Xml.XmlTextReader(New StringReader(QC_Tool.StringXml))
                    While xmlTextReader.Read()
                        If (xmlTextReader.NodeType <> XmlNodeType.Element OrElse Operators.CompareString(xmlTextReader.Name, "program", False) <> 0) Then
                            Continue While
                        End If
                        QC_Tool.SectorSize = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                        Dim attribute18 As String = xmlTextReader.GetAttribute("num_partition_sectors")
                        Dim str18 As String = xmlTextReader.GetAttribute("label")
                        Dim attribute19 As String = xmlTextReader.GetAttribute("filename")
                        Dim str19 As String = xmlTextReader.GetAttribute("physical_partition_number")
                        Dim attribute20 As String = xmlTextReader.GetAttribute("start_sector")
                        If (Operators.CompareString(attribute19, "", False) <> 0) Then
                            QC_Tool.logs(String.Concat("Erasing ", str18, " : "), False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                            num5 += 1
                            If (Not QC_Tool.EraseParts(QC_Tool.SectorSize, attribute18, str19, attribute20)) Then
                                QC_Tool.logs("Failed", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                                Return
                            Else
                                QC_Tool.logs("Done" & vbCrLf & "", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                            End If
                        Else
                            num5 += 1
                        End If
                        QC_Tool.ProcessBar2(CLng(num5), CLng(num4))
                    End While
                ElseIf (Operators.CompareString(QC_Tool.MenuManual, "read", False) = 0) Then
                    Dim num6 As Integer = QC_Tool.totalchecked
                    Dim num7 As Integer = 0
                    If (File.Exists(String.Concat(QC_Tool.foldersave, "\rawprogram0.xml"))) Then
                        File.Delete(String.Concat(QC_Tool.foldersave, "\rawprogram0.xml"))
                    End If
                    Dim streamWriter As System.IO.StreamWriter = MyProject.Computer.FileSystem.OpenTextFileWriter(String.Concat(QC_Tool.foldersave, "\rawprogram0.xml"), True)
                    streamWriter.WriteLine("<?xml version=""1.0"" ?>")
                    streamWriter.WriteLine("<data>")
                    streamWriter.WriteLine("<!--NOTE: genererate by HadiKIT tool **-->")
                    Try
                        xmlTextReader = New System.Xml.XmlTextReader(New StringReader(QC_Tool.StringXml))
                        While True
                            If (Not xmlTextReader.Read()) Then
                                Exit While
                            ElseIf (xmlTextReader.NodeType = XmlNodeType.Element AndAlso Operators.CompareString(xmlTextReader.Name, "read", False) = 0) Then
                                Dim str20 As String = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                Dim attribute21 As String = xmlTextReader.GetAttribute("num_partition_sectors")
                                Dim str21 As String = xmlTextReader.GetAttribute("label")
                                Dim attribute22 As String = xmlTextReader.GetAttribute("physical_partition_number")
                                Dim str22 As String = xmlTextReader.GetAttribute("start_sector")
                                QC_Tool.logs(String.Concat("Reading ", str21, " : "), False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                                If (Not QC_Tool.ReadPart(str22, attribute21, str20, attribute22, str21)) Then
                                    QC_Tool.logs("Failed", False, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                                    num7 += 1
                                    streamWriter.WriteLine("</data>")
                                    streamWriter.Close()
                                    Exit While
                                Else
                                    QC_Tool.logs("Done" & vbCrLf & "", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                                    streamWriter.WriteLine(String.Concat(New String() {"<program SECTOR_SIZE_IN_BYTES=""", QC_Tool.SectorSize, """ file_sector_offset=""0"" filename=""", str21, ".img"" label=""", str21, """ num_partition_sectors=""", attribute21, """ physical_partition_number=""", attribute22, """ start_sector=""", str22, """/>"}))
                                    num7 += 1
                                    QC_Tool.ProcessBar2(CLng(num7), CLng(num6))
                                End If
                            End If
                        End While
                        streamWriter.WriteLine("</data>")
                        streamWriter.Close()
                        Return
                    Catch exception As System.Exception
                        ProjectData.SetProjectError(exception)
                        Interaction.MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
                        ProjectData.ClearProjectError()
                    End Try
                End If
            Catch exception1 As System.Exception
                ProjectData.SetProjectError(exception1)
                Interaction.MsgBox(exception1.ToString(), MsgBoxStyle.OkOnly, Nothing)
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Public Shared Function ParseGPT(storage As String, lun As String) As Boolean
            Dim flag As Boolean
            Dim gptHeader As gpt_header
            If (Operators.CompareString(storage.ToLower(), "emmc", False) = 0) Then
                QC_Tool.SendXml(Bismillah.FIREHOSE.firehose_pkts.pkt_read(Conversions.ToInteger(QC_Tool.SectorSize), 1, Conversions.ToInteger(lun), Conversions.ToString(1)))
                Dim numArray As Byte() = QC_Tool.ReciveWithLimit(100, 512)
                Dim str As String = Encoding.UTF8.GetString(numArray)
                QC_Tool.skipbyte = CInt(QC_Tool.removebytes(str))
                Dim array As Byte() = numArray.Skip(QC_Tool.skipbyte).ToArray()
                If (CInt(array.Length) <= 200) Then
                    flag = False
                    Return flag
                End If
                If (Encoding.UTF8.GetString(array, 0, CInt(array.Length)).Contains("EFI")) Then
                    gptHeader = New gpt_header() With
                    {
                        .signature = Encoding.UTF8.GetString(array.Skip(0).Take(8).ToArray(), 0, 8),
                        .revision = BitConverter.ToInt32(array.Skip(8).Take(4).ToArray(), 0),
                        .header_size = BitConverter.ToInt32(array.Skip(12).Take(4).ToArray(), 0),
                        .crc_header = BitConverter.ToInt32(array.Skip(16).Take(4).ToArray(), 0),
                        .reserved = BitConverter.ToInt32(array.Skip(20).Take(4).ToArray(), 0),
                        .current_lba = BitConverter.ToInt32(array.Skip(24).Take(8).ToArray(), 0),
                        .backup_lba = BitConverter.ToInt32(array.Skip(32).Take(8).ToArray(), 0),
                        .first_usable_lba = BitConverter.ToInt32(array.Skip(40).Take(8).ToArray(), 0),
                        .last_usable_lba = CLng(BitConverter.ToInt32(array.Skip(48).Take(8).ToArray(), 0)),
                        .disk_guid = array.Skip(56).Take(16).ToArray(),
                        .starting_lba_pe = BitConverter.ToInt32(array.Skip(72).Take(8).ToArray(), 0)
                    }
                    QC_Tool.gpt.header = gptHeader
                    array.Skip(80).Take(4).ToArray()
                    QC_Tool.gpt.header.number_partitions = BitConverter.ToInt32(array.Skip(80).Take(4).ToArray(), 0)
                    QC_Tool.gpt.header.size_partition_entries = BitConverter.ToInt32(array.Skip(84).Take(4).ToArray(), 0)
                    Dim num As Decimal = Decimal.Multiply(New Decimal(QC_Tool.gpt.header.last_usable_lba), New Decimal(512L))
                    Dim num1 As Decimal = Decimal.Divide(num, New Decimal(1073741824L))
                    num1 = Math.Round(num1, 2)
                    flag = True
                    Return flag
                Else
                    QC_Tool.logs("No Valid Gpt", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                    flag = False
                    Return flag
                End If
            ElseIf (Operators.CompareString(storage.ToLower(), "ufs", False) = 0) Then
                QC_Tool.SendXml(Bismillah.FIREHOSE.firehose_pkts.pkt_read(Conversions.ToInteger(QC_Tool.SectorSize), 1, Conversions.ToInteger(lun), Conversions.ToString(1)))
                Dim numArray1 As Byte() = QC_Tool.Read(100)
                Dim str1 As String = Encoding.UTF8.GetString(numArray1)
                QC_Tool.skipbyte = CInt(QC_Tool.removebytes(str1))
                Dim array1 As Byte() = numArray1.Skip(QC_Tool.skipbyte).ToArray()
                If (CInt(array1.Length) <= 200) Then
                    flag = False
                    Return flag
                End If
                If (Encoding.UTF8.GetString(array1, 0, CInt(array1.Length)).Contains("EFI")) Then
                    gptHeader = New gpt_header() With
                    {
                        .signature = Encoding.UTF8.GetString(array1.Skip(0).Take(8).ToArray(), 0, 8),
                        .revision = BitConverter.ToInt32(array1.Skip(8).Take(4).ToArray(), 0),
                        .header_size = BitConverter.ToInt32(array1.Skip(12).Take(4).ToArray(), 0),
                        .crc_header = BitConverter.ToInt32(array1.Skip(16).Take(4).ToArray(), 0),
                        .reserved = BitConverter.ToInt32(array1.Skip(20).Take(4).ToArray(), 0),
                        .current_lba = BitConverter.ToInt32(array1.Skip(24).Take(8).ToArray(), 0),
                        .backup_lba = BitConverter.ToInt32(array1.Skip(32).Take(8).ToArray(), 0),
                        .first_usable_lba = BitConverter.ToInt32(array1.Skip(40).Take(8).ToArray(), 0),
                        .last_usable_lba = CLng(BitConverter.ToInt32(array1.Skip(48).Take(8).ToArray(), 0)),
                        .disk_guid = array1.Skip(56).Take(16).ToArray(),
                        .starting_lba_pe = BitConverter.ToInt32(array1.Skip(72).Take(8).ToArray(), 0)
                    }
                    QC_Tool.gpt.header = gptHeader
                    array1.Skip(80).Take(4).ToArray()
                    QC_Tool.gpt.header.number_partitions = BitConverter.ToInt32(array1.Skip(80).Take(4).ToArray(), 0)
                    QC_Tool.gpt.header.size_partition_entries = BitConverter.ToInt32(array1.Skip(84).Take(4).ToArray(), 0)
                    Dim num2 As Decimal = Decimal.Multiply(New Decimal(QC_Tool.gpt.header.last_usable_lba), New Decimal(4096L))
                    Dim num3 As Decimal = Decimal.Divide(num2, New Decimal(1073741824L))
                    num3 = Math.Round(num3, 2)
                    flag = True
                    Return flag
                Else
                    QC_Tool.logs("No Valid Gpt", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                    flag = False
                    Return flag
                End If
            End If
            flag = False
            Return flag
        End Function

        Public Shared Function bulat(number As Double) As Long
            Return CLng(Math.Round(-Conversion.Int(-number)))
        End Function

        Public Shared Function CekSparse(DataFiles As Byte()) As Boolean
            Dim result As Boolean
            If DataFiles.Length = 0 Then
                result = False
            Else
                Dim stream As Stream = New MemoryStream(DataFiles)
                Dim array As Byte() = New Byte(1024) {}
                Using binaryReader As New BinaryReader(stream)
                    binaryReader.Read(array, 0, 28)
                    QC_Tool.sparseheader = QC_Tool.parsingheader(array)
                    Dim dwMagic As Integer = QC_Tool.sparseheader.dwMagic
                    Dim num As Long = CLng(Math.Round(Conversion.Val("&HE" + Conversion.Hex(dwMagic))))
                    If num = 64108298042L Then
                        QC_Tool.totalchunk = QC_Tool.sparseheader.dwTotalChunks
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
        Public Shared Function parsingheader(bytes As Byte()) As SPARSE_HEADER
            Dim gchandle As GCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned)
            Dim result As SPARSE_HEADER
            Try
                Dim obj As Object = Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), GetType(SPARSE_HEADER))
                result = If((obj IsNot Nothing), CType(obj, SPARSE_HEADER), Nothing)
            Finally
                gchandle.Free()
            End Try
            Return result
        End Function

        Public Shared Sub Write(request As Byte())
            QC_Tool.Ports.Write(request, 0, CInt(request.Length))
        End Sub

        Public Shared Function WriteEmmc(SectSize As String, NumSect As String, Physical As String, StartSect As String, Filename As String) As Boolean
            Dim flag As Boolean
            Dim num As Short
            Dim num1 As Double
            Dim num2 As Long
            Dim num3 As Long
            Dim num4 As Long = 0L
            Dim num5 As Long = 0L
            Dim length As Long = 0L
            Dim str As String = ""
            Dim numArray(16384) As Byte
            Dim memoryStream As Stream = New System.IO.MemoryStream(numArray)
            If (QC_Tool.MenuEx = QC_Tool.MenuEksekusi.manual) Then
                If (Not File.Exists(Filename)) Then
                    flag = True
                    Return flag
                End If
                memoryStream = New FileStream(Filename, FileMode.Open, FileAccess.Read)
                memoryStream.Read(numArray, 0, CInt(numArray.Length))
                str = Path.GetFileName(Filename)
            ElseIf (QC_Tool.MenuEx = QC_Tool.MenuEksekusi.oneclick) Then
                memoryStream = New System.IO.MemoryStream(QC_Tool.FilesOneClick)
                memoryStream.Read(numArray, 0, CInt(numArray.Length))
                str = "Data"
            End If
            memoryStream.Seek(0L, SeekOrigin.Begin)
            If (Not QC_Tool.CekSparse(numArray)) Then
                memoryStream.Seek(0L, SeekOrigin.Begin)
                QC_Tool.logs(String.Concat("Writing UnSparse Files : ", str), True, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                QC_Tool.logs(String.Concat("Start Sector  => ", StartSect, " : "), False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                Dim length1 As Long = 0L
                If (QC_Tool.MenuEx = QC_Tool.MenuEksekusi.manual) Then
                    length1 = MyProject.Computer.FileSystem.GetFileInfo(Filename).Length
                ElseIf (QC_Tool.MenuEx = QC_Tool.MenuEksekusi.oneclick) Then
                    length1 = CLng(CInt(QC_Tool.FilesOneClick.Length))
                End If
                Dim num6 As Integer = 8192
                If (length1 >= 16777216L) Then
                    num6 = 1048576
                End If
                Dim num7 As Long = QC_Tool.bulat(CDbl(length1) / Conversions.ToDouble(QC_Tool.SectorSize))
                Dim num8 As Double = CDbl(num7) * Conversions.ToDouble(QC_Tool.SectorSize)
                If (CDbl(length1) < Conversions.ToDouble(SectSize)) Then
                    num7 = 1L
                    num8 = Conversions.ToDouble(SectSize)
                    num6 = 512
                End If
                Dim str1 As String = Bismillah.FIREHOSE.firehose_pkts.pkt_Program(SectSize, Conversions.ToString(num7), Physical, StartSect)
                QC_Tool.SendXml(str1)
                If (Not QC_Tool.isAck()) Then
                    QC_Tool.logs("Failed ", False, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                    flag = False
                Else
                    Using binaryReader As New System.IO.BinaryReader(memoryStream)
                        Try
                            While num8 <> CDbl(length)
                                If (num8 - CDbl(length) >= CDbl(num6)) Then
                                    Dim numArray1(num6 - 1 + 1 - 1) As Byte
                                    binaryReader.Read(numArray1, 0, num6)
                                    QC_Tool.Write(numArray1)
                                    length += CLng(CInt(numArray1.Length))
                                    QC_Tool.ProcessBar1(length, CLng(Math.Round(num8)))
                                Else
                                    num6 = CInt(Math.Round(num8 - CDbl(length)))
                                    Dim numArray2(num6 - 1 + 1 - 1) As Byte
                                    binaryReader.Read(numArray2, 0, num6)
                                    QC_Tool.Write(numArray2)
                                    length += CLng(CInt(numArray2.Length))
                                    QC_Tool.ProcessBar1(length, CLng(Math.Round(num8)))
                                End If
                            End While
                            If (Not QC_Tool.isAck()) Then
                                binaryReader.Close()
                                flag = False
                            Else
                                binaryReader.Close()
                                flag = True
                            End If
                        Catch exception1 As System.Exception
                            ProjectData.SetProjectError(exception1)
                            Dim exception As System.Exception = exception1
                            memoryStream.Close()
                            QC_Tool.logs(exception.ToString(), False, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                            flag = False
                            ProjectData.ClearProjectError()
                        End Try
                    End Using
                End If
            Else
                QC_Tool.logs(String.Concat("Writing Sparse Files : ", str), True, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                QC_Tool.logs(String.Concat("Start Sector  => ", StartSect, " : "), False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                Dim num9 As Integer = 0
                Dim num10 As Long = 0L
                Dim length2 As Long = 0L
                If (QC_Tool.totalchunk <= 0) Then
                    memoryStream.Close()
                    flag = False
                Else
                    Dim num11 As Integer = 0
                    Using binaryReader1 As New System.IO.BinaryReader(memoryStream)
                        Dim numArray3(1024) As Byte
                        QC_Tool.chunkheader = New CHUNK_HEADER()
                        While True
                            Try
                                If (num11 <> 0) Then
                                    binaryReader1.BaseStream.Seek(num4 + 28L, SeekOrigin.Begin)
                                    binaryReader1.Read(numArray3, 0, 12)
                                    QC_Tool.chunkheader.wChunkType = BitConverter.ToInt16(numArray3.Skip(0).Take(12).ToArray(), 0)
                                    QC_Tool.chunkheader.dwChunkSize = BitConverter.ToInt32(numArray3.Skip(4).Take(4).ToArray(), 0)
                                    QC_Tool.chunkheader.dwTotalSize = BitConverter.ToInt32(numArray3.Skip(8).Take(4).ToArray(), 0)
                                    num = QC_Tool.chunkheader.wChunkType
                                    num1 = Conversion.Val(String.Concat("&HE", Conversion.Hex(num)))
                                    num4 += CLng(QC_Tool.chunkheader.dwTotalSize)
                                    num2 = CLng(QC_Tool.chunkheader.dwChunkSize)
                                    num3 = num2 * CLng(QC_Tool.sparseheader.dwBlockSize)
                                    num5 = CLng(Math.Round(CDbl(num5) + CDbl(num3) / Conversions.ToDouble(SectSize)))
                                Else
                                    binaryReader1.BaseStream.Seek(28L, SeekOrigin.Begin)
                                    binaryReader1.Read(numArray3, 0, 12)
                                    QC_Tool.chunkheader.wChunkType = BitConverter.ToInt16(numArray3.Skip(0).Take(2).ToArray(), 0)
                                    QC_Tool.chunkheader.dwChunkSize = BitConverter.ToInt32(numArray3.Skip(4).Take(4).ToArray(), 0)
                                    QC_Tool.chunkheader.dwTotalSize = BitConverter.ToInt32(numArray3.Skip(8).Take(4).ToArray(), 0)
                                    num = QC_Tool.chunkheader.wChunkType
                                    num1 = Conversion.Val(String.Concat("&HE", Conversion.Hex(num)))
                                    num2 = CLng(QC_Tool.chunkheader.dwChunkSize)
                                    num3 = num2 * CLng(QC_Tool.sparseheader.dwBlockSize)
                                    num4 += CLng(QC_Tool.chunkheader.dwTotalSize)
                                    num5 = 0L
                                End If
                                If (num1 = 969409) Then
                                    num9 += 1
                                    Dim num12 As Integer = 524288
                                    Dim num13 As Long = CLng(Math.Round(CDbl(num3) / Conversions.ToDouble(SectSize)))
                                    Dim length3 As Long = 0L
                                    If (num3 <= 524288L) Then
                                        num12 = CInt(num3)
                                    End If
                                    Dim length4 As Integer = 0
                                    Dim str2 As String = Bismillah.FIREHOSE.firehose_pkts.pkt_Program(SectSize, Conversions.ToString(num13), Physical, Conversions.ToString(Conversions.ToDouble(StartSect) + CDbl(num10)))
                                    num10 += num13
                                    QC_Tool.SendXml(str2)
                                    If (QC_Tool.isAckFast()) Then
                                        While True
                                            If (num3 - length3 < CLng(num12)) Then
                                                num12 = CInt((num3 - length3))
                                            End If
                                            If (length3 = num3 AndAlso QC_Tool.isAckFast()) Then
                                                Exit While
                                            End If
                                            Dim numArray4(num12 - 1 + 1 - 1) As Byte
                                            binaryReader1.Read(numArray4, 0, num12)
                                            QC_Tool.Write(numArray4)
                                            length2 += CLng(CInt(numArray4.Length))
                                            length3 += CLng(CInt(numArray4.Length))
                                            length4 += CInt(numArray4.Length)
                                            QC_Tool.ProcessBar1(length3, num3)
                                        End While
                                    Else
                                        QC_Tool.logs("Failed ", False, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                                        flag = False
                                        Exit While
                                    End If
                                ElseIf (num1 = 969410) Then
                                    Dim num14 As Long = CLng(Math.Round(CDbl(num3) / Conversions.ToDouble(SectSize)))
                                    num10 += num14
                                ElseIf (num1 = 969411) Then
                                    Dim num15 As Long = CLng(Math.Round(CDbl(num3) / Conversions.ToDouble(SectSize)))
                                    num10 += num15
                                End If
                                num11 += 1
                                If (num11 <> QC_Tool.totalchunk) Then
                                    QC_Tool.ProcessBar2(CLng(num11), CLng(QC_Tool.totalchunk))
                                Else
                                    QC_Tool.ProcessBar2(CLng(num11), CLng(QC_Tool.totalchunk))
                                    memoryStream.Close()
                                    binaryReader1.Close()
                                    flag = True
                                    Exit While
                                End If
                            Catch exception2 As System.Exception
                                ProjectData.SetProjectError(exception2)
                                Interaction.MsgBox(exception2.ToString(), MsgBoxStyle.OkOnly, Nothing)
                                memoryStream.Close()
                                flag = False
                                ProjectData.ClearProjectError()
                                Exit While
                            End Try
                        End While
                    End Using
                End If
            End If
            Return flag
        End Function

        Public Shared Function Read(timeSpan As Integer) As Byte()
            Thread.Sleep(timeSpan)
            Dim bytesToRead As Integer = QC_Tool.Ports.BytesToRead
            Dim numArray(bytesToRead - 1 + 1 - 1) As Byte
            QC_Tool.Ports.Read(numArray, 0, bytesToRead)
            Return numArray
        End Function

        Public Shared Function ReadPart(Startsector As String, NumPartition As String, ByRef SectSize As String, physical As String, pname As String) As Boolean
            Dim flag As Boolean
            QC_Tool.tot = 0
            Try
                Dim num As Integer = 0
                Dim num1 As Long = CLng(Math.Round(Conversions.ToDouble(NumPartition) * Conversions.ToDouble(SectSize)))
                Dim length As Long = 0L
                Dim str As String = Bismillah.FIREHOSE.firehose_pkts.pkt_read(Conversions.ToInteger(SectSize), Conversions.ToInteger(NumPartition), Conversions.ToInteger(physical), Startsector)
                Dim fileStream As New System.IO.FileStream(String.Concat(QC_Tool.foldersave, "\", pname, ".img"), FileMode.Append, FileAccess.Write)
                Using fileStream
                    Dim array As Byte() = New Byte(-1) {}
                    QC_Tool.SendXml(str)
                    While True
                        If num = 0 Then
                            Dim numArray As Byte() = QC_Tool.Read(10)
                            Dim str1 As String = Encoding.UTF8.GetString(numArray)
                            QC_Tool.skipbyte = CInt(QC_Tool.removebytes(str1))
                            array = numArray.Skip(QC_Tool.skipbyte).ToArray()
                        Else
                            array = QC_Tool.Read(10)
                        End If
                        length += CLng(CInt(array.Length))
                        If (length > num1) Then
                            Exit While
                        End If
                        fileStream.Write(array, 0, CInt(array.Length))
                        QC_Tool.ProcessBar1(length, num1)
                        num += 1
                    End While
                    Dim num2 As Long = length - num1
                    Dim length1 As Long = CLng(CInt(array.Length)) - num2
                    Dim array1 As Byte() = array.Take(CInt(length1)).ToArray()
                    fileStream.Write(array1, 0, CInt(array1.Length))
                    QC_Tool.ProcessBar1(length - num2, num1)
                End Using
                flag = True
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Interaction.MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
                flag = False
                ProjectData.ClearProjectError()
            End Try
            Return flag
        End Function

        Public Shared Function removebytes(h As String) As Long
            Try
                Dim num As Integer = h.IndexOf("<?xml")
                Dim num2 As Integer = h.IndexOf("</data>")
                Dim text As String = h.Substring(num, num2 - num + 7)
                Dim ptr As Integer = QC_Tool.tot
                QC_Tool.tot = ptr + text.Length
                h = h.Replace(text, String.Empty)
                If Not h.Contains("<?xml") Then
                    Return CLng(QC_Tool.tot)
                End If
                QC_Tool.removebytes(h)
            Catch ex As Exception
                Return 0L
            End Try
            Return 0L
        End Function

        Public Shared Function GetFileSize(TheSize As Long) As String
            Dim str As String
            Try
                Dim num As Long = TheSize
                If (num >= 1099511627776L) Then
                    QC_Tool.DoubleBytes = CDbl((CDbl(TheSize) / 1099511627776))
                    str = String.Concat(Strings.FormatNumber(QC_Tool.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " TB")
                ElseIf (num >= 1073741824L AndAlso num <= 1099511627775L) Then
                    QC_Tool.DoubleBytes = CDbl((CDbl(TheSize) / 1073741824))
                    str = String.Concat(Strings.FormatNumber(QC_Tool.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " GB")
                ElseIf (num >= 1048576L AndAlso num <= 1073741823L) Then
                    QC_Tool.DoubleBytes = CDbl((CDbl(TheSize) / 1048576))
                    str = String.Concat(Strings.FormatNumber(QC_Tool.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " MB")
                ElseIf (num >= 1024L AndAlso num <= 1048575L) Then
                    QC_Tool.DoubleBytes = CDbl((CDbl(TheSize) / 1024))
                    str = String.Concat(Strings.FormatNumber(QC_Tool.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " KB")
                ElseIf (num < 0L OrElse num > 1023L) Then
                    str = ""
                Else
                    QC_Tool.DoubleBytes = CDbl(TheSize)
                    str = String.Concat(Strings.FormatNumber(QC_Tool.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault), " bytes")
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                str = ""
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Shared Sub sendingloaderDone(sender As Object, e As RunWorkerCompletedEventArgs)
            If (Not QC_Tool.sendingloaderStatus) Then
                QC_Tool.Ports.Close()
                QC_Tool.logs("Done With Error", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
            Else
                Dim backgroundWorker As New System.ComponentModel.BackgroundWorker()
                AddHandler backgroundWorker.DoWork, New DoWorkEventHandler(AddressOf QC_Tool.ConnectToFlshLoader)
                AddHandler backgroundWorker.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf QC_Tool.AllDone)
                AddHandler backgroundWorker.ProgressChanged, New ProgressChangedEventHandler(AddressOf QC_Tool.ProcessSendingLoader)
                backgroundWorker.RunWorkerAsync()
                backgroundWorker.Dispose()
            End If
        End Sub
        Public Shared Sub AllDone(sender As Object, e As RunWorkerCompletedEventArgs)
            QC_Tool.Ports.Close()
            QC_Tool.logs("All Progress Completed", True, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
        End Sub

        Public Shared Sub SendXml(xml As String)
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(xml)
            QC_Tool.Write(bytes)
        End Sub
        Public Shared Function isAck() As Boolean
            Dim flag As Boolean
            Try
                Dim numArray As Byte() = QC_Tool.Read(300)
                Dim str As String = Encoding.UTF8.GetString(numArray, 0, CInt(numArray.Length))
                If (Not str.Contains("""ACK""")) Then
                    QC_Tool.logs(str, True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                    flag = False
                Else
                    flag = True
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Interaction.MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
                flag = False
                ProjectData.ClearProjectError()
            End Try
            Return flag
        End Function

        Public Shared Sub SendXmlFast(xml As String)
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(xml)
            QC_Tool.Write(bytes)
            QC_Tool.isAckFast()
        End Sub

        Public Shared Function isAckFast() As Boolean
            Dim flag As Boolean
            Try
                Dim numArray As Byte() = QC_Tool.Read(0)
                Encoding.UTF8.GetString(numArray, 0, CInt(numArray.Length))
                flag = True
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Interaction.MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
                flag = False
                ProjectData.ClearProjectError()
            End Try
            Return flag
        End Function

        Public Shared Function CekResponseConfig() As String
            Dim str As String
            Dim num As Integer = 0
            Try
                Do
                    Dim numArray As Byte() = QC_Tool.Read(300)
                    Dim str1 As String = Encoding.UTF8.GetString(numArray, 0, CInt(numArray.Length))
                    If (str1.ToUpper().Contains("""ACK""")) Then
                        str = "ack"
                        Return str
                    ElseIf (str1.ToUpper().Contains("""NAK""")) Then
                        str = str1
                        Return str
                    Else
                        num += 1
                        Thread.Sleep(300)
                    End If
                Loop While num <> 3
                str = "failed"
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                str = "failed"
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Shared Function EraseParts(SectSize As String, numPartSect As String, PhysicalPartition As String, startSector As String) As Boolean
            Dim flag As Boolean
            Dim num As Integer = 1048576
            Dim num1 As Long = 0L
            Dim num2 As Integer = 16384
            num1 = If(Conversions.ToDouble(numPartSect) * Conversions.ToDouble(SectSize) < 1048576.0!, Conversions.ToLong(numPartSect), CLng(Math.Round(CDbl(num) / Conversions.ToDouble(SectSize))))
            If (Conversions.ToDouble(numPartSect) = 0) Then
                num1 = CLng(Math.Round(CDbl(num) / Conversions.ToDouble(SectSize)))
            End If
            Dim num3 As Double = CDbl(num1) * Conversions.ToDouble(SectSize)
            Dim length As Long = 0L
            Dim length1 As Long = 0L
            Dim num4 As Integer = 0
            Dim str As String = Bismillah.FIREHOSE.firehose_pkts.pkt_Program(QC_Tool.SectorSize, Conversions.ToString(num1), PhysicalPartition, startSector)
            QC_Tool.SendXml(str)
            If (QC_Tool.isAck()) Then
                Try
                    While CDbl(length) <> num3
                        If (num3 - CDbl(length) < CDbl(num2)) Then
                            num2 = CInt(Math.Round(num3 - CDbl(length)))
                        End If
                        Dim numArray(num2 - 1 + 1 - 1) As Byte
                        QC_Tool.Write(numArray)
                        length += CLng(CInt(numArray.Length))
                        length1 += CLng(CInt(numArray.Length))
                        num4 += 1
                    End While
                    flag = QC_Tool.isAck
                Catch exception As System.Exception
                    ProjectData.SetProjectError(exception)
                    Interaction.MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
                    flag = False
                    ProjectData.ClearProjectError()
                End Try
            Else
                flag = False
            End If
            Return flag
        End Function

        Public Shared Function ReciveWithLimit(timeSpan As Integer, numBytes As Integer) As Byte()
            Thread.Sleep(timeSpan)
            Dim array As Byte() = New Byte(numBytes - 1 + 1 - 1) {}
            QC_Tool.Ports.Read(array, 0, numBytes)
            QC_Tool.Ports.DiscardOutBuffer()
            QC_Tool.Ports.DiscardInBuffer()
            Return array
        End Function

        Public Shared Sub ParsePartions(startingLbaPe As Integer, storage As String, lun As String)
            Dim objectValue As ListBox.ObjectCollection
            Dim objArray As Object()
            Dim flagArray As Boolean()
            Dim num As Integer
            QC_Tool.ListPartitionName.Items.Clear()
            QC_Tool.ListStartSector.Items.Clear()
            QC_Tool.ListLastSector.Items.Clear()
            QC_Tool.listSectorSize.Items.Clear()
            QC_Tool.listPhysicalPartition.Items.Clear()
            If (Operators.CompareString(storage.ToLower(), "emmc", False) = 0) Then
                QC_Tool.SendXml(Bismillah.FIREHOSE.firehose_pkts.pkt_read(512, 100, Conversions.ToInteger(lun), Conversions.ToString(startingLbaPe)))
                Dim numArray As Byte() = QC_Tool.ReciveWithLimit(100, 51200)
                Dim str As String = Encoding.UTF8.GetString(numArray)
                QC_Tool.skipbyte = CInt(QC_Tool.removebytes(str))
                Dim array As Byte() = numArray.Skip(QC_Tool.skipbyte).ToArray()
                Dim num1 As Integer = 0
                QC_Tool.gpt.entries = New List(Of gpt_partition_entry)()
                While True
                    Try
                        Dim gptPartitionEntry As New gpt_partition_entry()
                        If (num1 <= 128) Then
                            If (num1 <> 0) Then
                                Dim num2 As Integer = num1 * 128
                                gptPartitionEntry.partTypeGUID = Encoding.UTF8.GetString(array.Skip(num2).Take(16).ToArray(), 0, 16)
                                gptPartitionEntry.partID = Encoding.UTF8.GetString(array.Skip(num2 + 16).Take(16).ToArray(), 0, 16)
                                gptPartitionEntry.first_lba = BitConverter.ToInt32(array.Skip(num2 + 32).Take(8).ToArray(), 0)
                                gptPartitionEntry.last_lba = BitConverter.ToInt32(array.Skip(num2 + 40).Take(8).ToArray(), 0)
                                gptPartitionEntry.flags = array.Skip(num2 + 48).Take(8).ToArray()
                                gptPartitionEntry.partName = Encoding.ASCII.GetString(array.Skip(num2 + 56).Take(72).ToArray()).Trim(New Char(0) {})
                                gptPartitionEntry.partName = gptPartitionEntry.partName.Replace(vbNullChar, "")
                            Else
                                gptPartitionEntry.partTypeGUID = Encoding.UTF8.GetString(array.Skip(0).Take(16).ToArray(), 0, 16)
                                gptPartitionEntry.partID = Encoding.UTF8.GetString(array.Skip(16).Take(16).ToArray(), 0, 16)
                                gptPartitionEntry.first_lba = BitConverter.ToInt32(array.Skip(32).Take(8).ToArray(), 0)
                                gptPartitionEntry.last_lba = BitConverter.ToInt32(array.Skip(40).Take(8).ToArray(), 0)
                                gptPartitionEntry.flags = array.Skip(48).Take(8).ToArray()
                                gptPartitionEntry.partName = Encoding.UTF8.GetString(array.Skip(56).Take(72).ToArray(), 0, 72).Trim(New Char(0) {})
                                gptPartitionEntry.partName = gptPartitionEntry.partName.Replace(vbNullChar, "")
                            End If
                            If (Operators.CompareString(gptPartitionEntry.partName, "", False) = 0) Then
                                Exit While
                            ElseIf (Operators.CompareString(gptPartitionEntry.partName, "", False) = 0) Then
                                Exit While
                            Else
                                QC_Tool.ListPartitionName.Items.Add(gptPartitionEntry.partName)
                                QC_Tool.ListStartSector.Items.Add(gptPartitionEntry.first_lba.ToString())
                                QC_Tool.ListLastSector.Items.Add(gptPartitionEntry.last_lba.ToString())
                                QC_Tool.listSectorSize.Items.Add("512")
                                QC_Tool.listPhysicalPartition.Items.Add("0")
                                num1 += 1
                            End If
                        Else
                            Exit While
                        End If
                    Catch exception As System.Exception
                        ProjectData.SetProjectError(exception)
                        ProjectData.ClearProjectError()
                        Exit While
                    End Try
                End While
                QC_Tool.lvi = New ListViewItem()
                QC_Tool.lvi.SubItems.Add("0")
                QC_Tool.lvi.SubItems.Add("512")
                QC_Tool.lvi.SubItems.Add("PrimaryGpt")
                QC_Tool.lvi.SubItems.Add("0")
                Dim subItems As ListViewItem.ListViewSubItemCollection = QC_Tool.lvi.SubItems
                Dim item(0) As Object
                Dim items As ListBox.ObjectCollection = QC_Tool.ListStartSector.Items
                objectValue = items
                item(0) = items(0)
                objArray = item
                Dim flagArray1() As Boolean = {True}
                flagArray = flagArray1
                NewLateBinding.LateCall(subItems, Nothing, "Add", item, Nothing, Nothing, flagArray1, True)
                If (flagArray(0)) Then
                    objectValue(0) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                End If
                QC_Tool.lvi.SubItems.Add("none")
                QcFlash.ListViewQc.Invoke(New Action(Sub() QcFlash.ListViewQc.Items.Add(QC_Tool.lvi)))
                Dim count As Integer = QC_Tool.ListPartitionName.Items.Count - 1
                For i As Integer = 0 To count Step 1
                    QC_Tool.lvi = New ListViewItem()
                    Dim listViewSubItemCollections As ListViewItem.ListViewSubItemCollection = QC_Tool.lvi.SubItems
                    Dim item1(0) As Object
                    Dim objectCollections As ListBox.ObjectCollection = QC_Tool.listPhysicalPartition.Items
                    objectValue = objectCollections
                    Dim num3 As Integer = i
                    num = num3
                    item1(0) = objectCollections(num3)
                    objArray = item1
                    Dim flagArray2() As Boolean = {True}
                    flagArray = flagArray2
                    NewLateBinding.LateCall(listViewSubItemCollections, Nothing, "Add", item1, Nothing, Nothing, flagArray2, True)
                    If (flagArray(0)) Then
                        objectValue(num) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                    End If
                    QC_Tool.lvi.SubItems.Add("512")
                    Dim subItems1 As ListViewItem.ListViewSubItemCollection = QC_Tool.lvi.SubItems
                    Dim objArray1(0) As Object
                    Dim items1 As ListBox.ObjectCollection = QC_Tool.ListPartitionName.Items
                    objectValue = items1
                    Dim num4 As Integer = i
                    num = num4
                    objArray1(0) = items1(num4)
                    objArray = objArray1
                    Dim flagArray3() As Boolean = {True}
                    flagArray = flagArray3
                    NewLateBinding.LateCall(subItems1, Nothing, "Add", objArray1, Nothing, Nothing, flagArray3, True)
                    If (flagArray(0)) Then
                        objectValue(num) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                    End If
                    Dim listViewSubItemCollections1 As ListViewItem.ListViewSubItemCollection = QC_Tool.lvi.SubItems
                    Dim item2(0) As Object
                    Dim objectCollections1 As ListBox.ObjectCollection = QC_Tool.ListStartSector.Items
                    objectValue = objectCollections1
                    Dim num5 As Integer = i
                    num = num5
                    item2(0) = objectCollections1(num5)
                    objArray = item2
                    Dim flagArray4() As Boolean = {True}
                    flagArray = flagArray4
                    NewLateBinding.LateCall(listViewSubItemCollections1, Nothing, "Add", item2, Nothing, Nothing, flagArray4, True)
                    If (flagArray(0)) Then
                        objectValue(num) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                    End If
                    NewLateBinding.LateCall(QC_Tool.lvi.SubItems, Nothing, "Add", New Object() {Operators.AddObject(Operators.SubtractObject(QC_Tool.ListLastSector.Items(i), QC_Tool.ListStartSector.Items(i)), 1)}, Nothing, Nothing, Nothing, True)
                    QC_Tool.lvi.SubItems.Add("none")
                    QcFlash.ListViewQc.Invoke(New Action(Sub() QcFlash.ListViewQc.Items.Add(QC_Tool.lvi)))
                Next

            ElseIf (Operators.CompareString(storage.ToLower(), "ufs", False) = 0) Then
                QC_Tool.SendXml(Bismillah.FIREHOSE.firehose_pkts.pkt_read(4096, 100, Conversions.ToInteger(lun), Conversions.ToString(2)))
                Dim numArray1 As Byte() = QC_Tool.ReciveWithLimit(100, 409600)
                Dim str1 As String = Encoding.UTF8.GetString(numArray1)
                QC_Tool.skipbyte = CInt(QC_Tool.removebytes(str1))
                Dim array1 As Byte() = numArray1.Skip(QC_Tool.skipbyte).ToArray()
                Dim num6 As Integer = 0
                QC_Tool.gpt.entries = New List(Of gpt_partition_entry)()
                While True
                    Try
                        Dim gptPartitionEntry1 As New gpt_partition_entry()
                        If (num6 <= 128) Then
                            If (num6 <> 0) Then
                                Dim num7 As Integer = num6 * 128
                                gptPartitionEntry1.partTypeGUID = Encoding.UTF8.GetString(array1.Skip(num7).Take(16).ToArray(), 0, 16)
                                gptPartitionEntry1.partID = Encoding.UTF8.GetString(array1.Skip(num7 + 16).Take(16).ToArray(), 0, 16)
                                gptPartitionEntry1.first_lba = BitConverter.ToInt32(array1.Skip(num7 + 32).Take(8).ToArray(), 0)
                                gptPartitionEntry1.last_lba = BitConverter.ToInt32(array1.Skip(num7 + 40).Take(8).ToArray(), 0)
                                gptPartitionEntry1.flags = array1.Skip(num7 + 48).Take(8).ToArray()
                                gptPartitionEntry1.partName = Encoding.ASCII.GetString(array1.Skip(num7 + 56).Take(72).ToArray()).Trim(New Char(0) {})
                                gptPartitionEntry1.partName = gptPartitionEntry1.partName.Replace(" ", "")
                            Else
                                gptPartitionEntry1.partTypeGUID = Encoding.UTF8.GetString(array1.Skip(0).Take(16).ToArray(), 0, 16)
                                gptPartitionEntry1.partID = Encoding.UTF8.GetString(array1.Skip(16).Take(16).ToArray(), 0, 16)
                                gptPartitionEntry1.first_lba = BitConverter.ToInt32(array1.Skip(32).Take(8).ToArray(), 0)
                                gptPartitionEntry1.last_lba = BitConverter.ToInt32(array1.Skip(40).Take(8).ToArray(), 0)
                                gptPartitionEntry1.flags = array1.Skip(48).Take(8).ToArray()
                                gptPartitionEntry1.partName = Encoding.UTF8.GetString(array1.Skip(56).Take(72).ToArray(), 0, 72).Trim(New Char(0) {})
                                gptPartitionEntry1.partName = gptPartitionEntry1.partName.Replace(" ", "")
                            End If
                            If (Operators.CompareString(gptPartitionEntry1.partName, "", False) = 0) Then
                                Exit While
                            ElseIf (Operators.CompareString(gptPartitionEntry1.partName, "", False) = 0) Then
                                Exit While
                            Else
                                QC_Tool.ListPartitionName.Items.Add(gptPartitionEntry1.partName)
                                QC_Tool.ListStartSector.Items.Add(gptPartitionEntry1.first_lba.ToString())
                                QC_Tool.ListLastSector.Items.Add(gptPartitionEntry1.last_lba.ToString())
                                QC_Tool.listSectorSize.Items.Add("4096")
                                QC_Tool.listPhysicalPartition.Items.Add(lun)
                                num6 += 1
                            End If
                        Else
                            Exit While
                        End If
                    Catch exception1 As System.Exception
                        ProjectData.SetProjectError(exception1)
                        ProjectData.ClearProjectError()
                        Exit While
                    End Try
                End While
                QC_Tool.lvi = New ListViewItem()
                QC_Tool.lvi.SubItems.Add("0")
                QC_Tool.lvi.SubItems.Add("4096")
                QC_Tool.lvi.SubItems.Add("PrimaryGpt")
                QC_Tool.lvi.SubItems.Add("0")
                Dim subItems2 As ListViewItem.ListViewSubItemCollection = QC_Tool.lvi.SubItems
                Dim objArray2(0) As Object
                Dim items2 As ListBox.ObjectCollection = QC_Tool.ListStartSector.Items
                objectValue = items2
                objArray2(0) = items2(0)
                objArray = objArray2
                Dim flagArray5() As Boolean = {True}
                flagArray = flagArray5
                NewLateBinding.LateCall(subItems2, Nothing, "Add", objArray2, Nothing, Nothing, flagArray5, True)
                If (flagArray(0)) Then
                    objectValue(0) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                End If
                QC_Tool.lvi.SubItems.Add("none")
                QcFlash.ListViewQc.Invoke(New Action(Sub() QcFlash.ListViewQc.Items.Add(QC_Tool.lvi)))
                Dim count1 As Integer = QC_Tool.ListPartitionName.Items.Count - 1
                For j As Integer = 0 To count1 Step 1
                    QC_Tool.lvi = New ListViewItem()
                    Dim listViewSubItemCollections2 As ListViewItem.ListViewSubItemCollection = QC_Tool.lvi.SubItems
                    Dim item3(0) As Object
                    Dim objectCollections2 As ListBox.ObjectCollection = QC_Tool.listPhysicalPartition.Items
                    objectValue = objectCollections2
                    Dim num8 As Integer = j
                    num = num8
                    item3(0) = objectCollections2(num8)
                    objArray = item3
                    Dim flagArray6() As Boolean = {True}
                    flagArray = flagArray6
                    NewLateBinding.LateCall(listViewSubItemCollections2, Nothing, "Add", item3, Nothing, Nothing, flagArray6, True)
                    If (flagArray(0)) Then
                        objectValue(num) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                    End If
                    QC_Tool.lvi.SubItems.Add("4096")
                    Dim subItems3 As ListViewItem.ListViewSubItemCollection = QC_Tool.lvi.SubItems
                    Dim objArray3(0) As Object
                    Dim items3 As ListBox.ObjectCollection = QC_Tool.ListPartitionName.Items
                    objectValue = items3
                    Dim num9 As Integer = j
                    num = num9
                    objArray3(0) = items3(num9)
                    objArray = objArray3
                    Dim flagArray7() As Boolean = {True}
                    flagArray = flagArray7
                    NewLateBinding.LateCall(subItems3, Nothing, "Add", objArray3, Nothing, Nothing, flagArray7, True)
                    If (flagArray(0)) Then
                        objectValue(num) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                    End If
                    Dim listViewSubItemCollections3 As ListViewItem.ListViewSubItemCollection = QC_Tool.lvi.SubItems
                    Dim item4(0) As Object
                    Dim objectCollections3 As ListBox.ObjectCollection = QC_Tool.ListStartSector.Items
                    objectValue = objectCollections3
                    Dim num10 As Integer = j
                    num = num10
                    item4(0) = objectCollections3(num10)
                    objArray = item4
                    Dim flagArray8() As Boolean = {True}
                    flagArray = flagArray8
                    NewLateBinding.LateCall(listViewSubItemCollections3, Nothing, "Add", item4, Nothing, Nothing, flagArray8, True)
                    If (flagArray(0)) Then
                        objectValue(num) = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray(0)))
                    End If
                    NewLateBinding.LateCall(QC_Tool.lvi.SubItems, Nothing, "Add", New Object() {Operators.AddObject(Operators.SubtractObject(QC_Tool.ListLastSector.Items(j), QC_Tool.ListStartSector.Items(j)), 1)}, Nothing, Nothing, Nothing, True)
                    QC_Tool.lvi.SubItems.Add("none")
                    QcFlash.ListViewQc.Invoke(New Action(Sub() QcFlash.ListViewQc.Items.Add(QC_Tool.lvi)))
                Next

            End If
        End Sub
        Public Shared Function FlashQc()
            Dim enumerator As IEnumerator = Nothing
            If (Qualcom_Flash.QcFlash.ListViewQc.CheckedItems.Count <> 0) Then
                Qualcom_Flash.QcFlash.MenuManual = "flash"
                Thread.Sleep(500)
                If (Not XtraMain.CheckAuth.Checked) Then
                    If (QcFlash.TxtFlashLoader.Text = "") Then
                        Interaction.MsgBox("Silahkan masukan loader firehose programmernya terlebih dahulu!", MsgBoxStyle.OkOnly, Nothing)
                        'QC_Tool.Label1.Visible = False
                        'Return
                    Else
                        QC_Tool.RtbClear()
                        QC_Tool.Setwaktu()
                        QC_Tool.StringXml = ""
                        QC_Tool.logs("Checking Loader : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                        QC_Tool.loader = File.ReadAllBytes(QcFlash.TxtFlashLoader.Text)
                        If (Not Encoding.UTF8.GetString(QC_Tool.loader).Contains("ELF")) Then
                            QC_Tool.logs("Loader is Invalid Or Encrypted  ", False, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                            'Return
                        End If
                        QC_Tool.logs("Ok ", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                    End If
                Else
                    QC_Tool.RtbClear()
                    QC_Tool.Setwaktu()
                    QC_Tool.StringXml = ""
                    Dim numArray As Byte() = QC_Tool.getfile("loader.bin", False)
                    QC_Tool.logs("Checking Loader : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                    QC_Tool.logs("Done", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                    QC_Tool.OutDecripted = numArray
                    QC_Tool.logs(String.Concat("Checking Data ", QC_Tool.GetFileSize(CLng(CInt(numArray.Length))), " :"), False, DirectCast(Conversions.ToInteger(QC_Tool.Biru), uiManager.MessageType))
                    If (QC_Tool.CryptStream(QC_Tool.keyEncrypt, numArray, False, "loader", 0L)) Then
                        If (Not Encoding.UTF8.GetString(QC_Tool.loader.Take(20).ToArray()).ToUpper().Contains("ELF")) Then
                            'Return
                        End If
                        QC_Tool.logs("Done", True, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                    Else
                        QC_Tool.logs("Failed", True, DirectCast(Conversions.ToInteger(QC_Tool.Merah), uiManager.MessageType))
                        'Return
                    End If
                End If
                QC_Tool.StringXml = String.Concat(QC_Tool.StringXml, "<?xml version=""1.0"" ?>" & vbCrLf & "")
                QC_Tool.StringXml = String.Concat(QC_Tool.StringXml, "<data>" & vbCrLf & "")
                QC_Tool.totalchecked = QcFlash.ListViewQc.CheckedItems.Count
                Try
                    enumerator = QcFlash.ListViewQc.CheckedItems.GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                        QC_Tool.StringXml = String.Concat(QC_Tool.StringXml, String.Format("<program SECTOR_SIZE_IN_BYTES=""{0}"" file_sector_offset=""0""  filename=""{1}""  label=""{2}"" num_partition_sectors=""{3}""  physical_partition_number=""{4}"" start_sector=""{5}""/>", New Object() {QC_Tool.SectorSize, current.SubItems(6).Text, current.SubItems(3).Text, current.SubItems(5).Text, current.SubItems(1).Text, current.SubItems(4).Text}), "" & vbCrLf & "")
                    End While
                Finally
                    If (TypeOf enumerator Is IDisposable) Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
                QC_Tool.StringXml = String.Concat(QC_Tool.StringXml, "</data>")
                QC_Tool.GetInfDrive()
                QC_Tool.logs("Searching Qualcomm Usb Devices : ", False, DirectCast(Conversions.ToInteger(QC_Tool.Kuning), uiManager.MessageType))
                XtraMain.CariPortQcom.Start()
            Else
                Interaction.MsgBox("Silahkan masukan Raw XML / Identify terlebih dahulu!", MsgBoxStyle.OkOnly, Nothing)
            End If
        End Function
    End Class
End Namespace