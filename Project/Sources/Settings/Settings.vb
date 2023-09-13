Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Microsoft.VisualBasic

Public Class Settings


    Public totaldo As Integer = 0
    Public doprosess As Integer = 0
    Private ReadOnly Biru As Object
    Private ReadOnly Kuning As Object
    Private ReadOnly Merah As Object
    Private foldersave As String = Path.Combine(Windows.Forms.Application.StartupPath) & "\outfile"
    Private Shared xmlpatch As String
    Public Shared OutDecripted As Byte() = New Byte() {}
    Public Shared loader As Byte() = New Byte() {}
    Public Shared in_file As Byte() = New Byte() {}
    Public Shared Filenya As String
    Public Shared NamaFilenya As String
    Public Shared EncryptDecrypt As Boolean
    Public Shared lenFile As Long
    Public Shared LoadFolder As String
    Private Property lvi As ListViewItem
    Public Property StringXml As String
    Public Property FilesOneClick As Byte()
    Friend Shared SharedUI As Settings
    Public Shared SavedFolder As String
    Public FilesCollection As String = ""

    Public Sub New()
        InitializeComponent()
        SharedUI = Me
        Watch = New Stopwatch()
        AddHandler Load, AddressOf LoadMenu
        AddHandler ListView1.DrawColumnHeader, AddressOf ListView1_DrawColumnHeader
        AddHandler ListView1.DrawItem, AddressOf ListView1_DrawItem
    End Sub

    Shared Sub New()

    End Sub
    Public Sub ListView1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        Dim brush As New SolidBrush(Color.FromArgb(70, 70, 70))
        e.Graphics.FillRectangle(brush, e.Bounds)
        e.Graphics.DrawString(e.Header.Text, e.Font, Brushes.White, e.Bounds)
    End Sub
    Public Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs)
        e.DrawDefault = True
    End Sub

    Public Sub LoadMenu(sender As Object, e As EventArgs)
    End Sub
    Private Sub CheckEditShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditShowPassword.CheckedChanged
        If CheckEditShowPassword.Checked Then
            TxtPassword.Properties.UseSystemPasswordChar = True
        Else
            TxtPassword.Properties.UseSystemPasswordChar = False
        End If
    End Sub
    Private Sub CheckEditEncrypt_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditEncrypt.CheckedChanged
        If CheckEditEncrypt.Checked Then
            EncryptDecrypt = True
        Else
            EncryptDecrypt = False
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim enumerator As IEnumerator = Nothing
        Dim enumerator1 As IEnumerator = Nothing
        If ListView1.Items.Count = 0 Then
            MsgBox("zonk", MsgBoxStyle.OkOnly, Nothing)
        ElseIf Not CheckBox1.Checked Then
            Try
                enumerator1 = ListView1.Items.GetEnumerator()
                While enumerator1.MoveNext()
                    DirectCast(enumerator1.Current, ListViewItem).Checked = False
                End While
            Finally
                If (TypeOf enumerator1 Is IDisposable) Then
                    TryCast(enumerator1, IDisposable).Dispose()
                End If
            End Try
        Else
            Try
                enumerator = ListView1.Items.GetEnumerator()
                While enumerator.MoveNext()
                    DirectCast(enumerator.Current, ListViewItem).Checked = True
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub
    Private Sub SimpleButtonBrowseFile_Click(sender As Object, e As EventArgs) Handles SimpleButtonBrowseFile.Click
        ListView1.Items.Clear()
        Dim BrowseFileDialogFolders As New SaveFileDialog With {
                .FileName = "Select Folder"
                }
        If BrowseFileDialogFolders.ShowDialog() = DialogResult.OK Then
            LoadFolder = Path.Combine(New String() {Path.GetDirectoryName(BrowseFileDialogFolders.FileName)})
            TxtFile.Text = LoadFolder

            Dim directoryInfo As New DirectoryInfo(LoadFolder)
            Dim listView1 As ListView = Me.ListView1
            listView1.Columns.Add("", 20)
            listView1.Columns.Add("", 609, HorizontalAlignment.Left)
            listView1.View = View.Details
            listView1.CheckBoxes = True
            listView1.FullRowSelect = True
            Dim fileInfos As New List(Of FileInfo)()
            Dim files As FileInfo() = directoryInfo.GetFiles()
            Dim num As Integer = 0
            While num < files.Length
                Dim fileInfo As FileInfo = files(num)
                If fileInfo IsNot Nothing Then
                    lvi = New ListViewItem()
                    lvi.SubItems.Add(fileInfo.ToString())
                    Me.ListView1.Items.Add(lvi)
                End If
                num += 1
            End While
        End If
    End Sub
    Private Sub SimpleButtonSaveFiles_Click(sender As Object, e As EventArgs) Handles SimpleButtonSaveFiles.Click
        Dim saveFileDialogFolders As New SaveFileDialog With {
        .FileName = "Save Here"
        }

        If saveFileDialogFolders.ShowDialog() = DialogResult.OK Then
            If ListView1.Items.Count > 0 Then
                Main.SharedUI.RichTextBoxLogs.Invoke(New Action(Sub()
                                                                Main.SharedUI.RichTextBoxLogs.Clear()
                                                            End Sub))
                Watch.Start()
                FilesCollection = ""
                doprosess = 0
                totaldo = ListView1.CheckedItems.Count
                SavedFolder = Path.Combine(New String() {Path.GetDirectoryName(saveFileDialogFolders.FileName)})

                Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
                Dim enumerator As IEnumerator = Nothing
                Try
                    enumerator = ListView1.CheckedItems.GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                        FilesCollection = String.Concat(FilesCollection, current.SubItems(1).Text, ",")
                    End While
                Finally
                    If (TypeOf enumerator Is IDisposable) Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try

                BgWorker = New BackgroundWorker With {
                    .WorkerSupportsCancellation = True
                }
                AddHandler BgWorker.DoWork, AddressOf WorkerRun
                AddHandler BgWorker.RunWorkerCompleted, AddressOf AllDone
                BgWorker.RunWorkerAsync()

                RichLogs("", Color.White, True, True)
            End If
        End If
    End Sub
    Private Sub WorkerRun(sender As Object, e As DoWorkEventArgs)
        Dim str1 As String = FilesCollection
        Dim strArrays As String() = str1.Split(New Char() {","c})
        Dim length As Integer = strArrays.Length - 1
        For num As Integer = 0 To length
            If Not num > length Then

                Console.WriteLine(strArrays(num) & " Current : " & num & " Total length : " & length)
                ProcessBar2(doprosess, totaldo)
                RichLogs(" Process " & num & ">" & length & " " & strArrays(num), Color.White, True, False)
                NamaFilenya = strArrays(num)

                doprosess += 1

                If NamaFilenya.Contains("bin") OrElse NamaFilenya.Contains("elf") OrElse NamaFilenya.Contains("mbn") Then
                    Filenya = "loader"
                ElseIf NamaFilenya.Contains("xml") Then
                    Filenya = "xml"
                ElseIf NamaFilenya.Contains("img") Then
                    Filenya = "raw"
                End If

                Dim str As String = SavedFolder & "\" & NamaFilenya
                Dim keyEncrypt As String = TxtPassword.Text

                Dim EncyLoader As Byte() = File.ReadAllBytes(LoadFolder & "\" & NamaFilenya)
                OutDecripted = EncyLoader

                lenFile = 0L
                If EncryptDecrypt Then
                    File.Copy(LoadFolder & "\" & NamaFilenya, LoadFolder & "\tmp.process")

                    File.AppendAllText(LoadFolder & "\tmp.process", "EndCF")
                    Delay(0.1)
                    EncryptFile(keyEncrypt, LoadFolder & "\tmp.process", str)

                    Delay(0.1)
                    If File.Exists(LoadFolder & "\tmp.process") Then
                        File.Delete(LoadFolder & "\tmp.process")
                    End If

                    RichLogs(" encrypt Done!", Color.Lime, True, True)

                Else
                    DecryptFile(keyEncrypt, LoadFolder & "\" & NamaFilenya, str)
                    Delay(0.1)
                    If NamaFilenya.Contains(".xml") Then
                        Dim ss As Integer = FilterData(File.ReadAllBytes(str))
                        Dim sk As String = Encoding.UTF8.GetString(File.ReadAllBytes(str))
                        StringXml = sk.Skip(ss - 1).ToArray
                        If StringXml.Contains("EndCF") Then
                            File.WriteAllText(str, StringXml.Replace("EndCF", ""))
                        End If
                    Else
                        OutDecripted = File.ReadAllBytes(str)
                        If Encoding.UTF8.GetString(OutDecripted).Contains("EndCF") Then
                            File.WriteAllBytes(str, GetRawData(OutDecripted.Take(lenFile).ToArray))
                        End If
                    End If

                    RichLogs(" decrypt Done!", Color.Lime, True, True)
                End If

                ProcessBar2(doprosess, totaldo)
            Else
                Exit For
            End If
        Next
    End Sub

    Public Sub AllDone(sender As Object, e As RunWorkerCompletedEventArgs)
        ProcessBar1(100L, 100L)
        ProcessBar2(100L, 100L)
        RichLogs(vbCrLf & " All Progress Completed", Color.White, True, True)
        TimeSpanElapsed.ElapsedTime(Watch)
        Watch.Stop()
    End Sub

    Public Sub EncryptFile(password As String, in_file As String, out_file As String)
        CryptFile(password, in_file, out_file, True)
    End Sub

    Public Sub DecryptFile(password As String, in_file As String, out_file As String)
        CryptFile(password, in_file, out_file, False)
    End Sub

    Public Sub CryptFile(password As String, in_file As String, out_file As String, encrypt As Boolean)
        Using in_stream As New FileStream(in_file,
        FileMode.Open, FileAccess.Read)
            Using out_stream As New FileStream(out_file,
            FileMode.Create, FileAccess.Write)
                CryptStream(password, in_stream, out_stream,
                encrypt)
            End Using
        End Using
    End Sub

    Public Sub CryptStream(password As String, in_stream As Stream, out_stream As Stream, encrypt As Boolean)

        Dim aes_provider As New AesCryptoServiceProvider()

        Dim key_size_bits As Integer = 0
        For i As Integer = 1024 To 1 Step -1
            If aes_provider.ValidKeySize(i) Then
                key_size_bits = i
                Exit For
            End If
        Next i
        Debug.Assert(key_size_bits > 0)
        Console.WriteLine("Key size: " & key_size_bits)

        Dim block_size_bits As Integer = aes_provider.BlockSize

        Dim key() As Byte = Nothing
        Dim iv() As Byte = Nothing
        Dim salt() As Byte = {&H0, &H0, &H1, &H2, &H3, &H4,
        &H5, &H6, &HF1, &HF0, &HEE, &H21, &H22, &H45}
        MakeKeyAndIV(password, salt, key_size_bits,
        block_size_bits, key, iv)

        Dim crypto_transform As ICryptoTransform
        If encrypt Then
            crypto_transform =
            aes_provider.CreateEncryptor(key, iv)
        Else
            crypto_transform =
            aes_provider.CreateDecryptor(key, iv)
        End If

        Try
            Using crypto_stream As New CryptoStream(out_stream,
            crypto_transform, CryptoStreamMode.Write)
                Const block_size As Integer = 1024
                Dim buffer(block_size) As Byte
                Dim bytes_read As Integer
                Do
                    bytes_read = in_stream.Read(buffer, 0,
                    block_size)
                    lenFile += bytes_read
                    If bytes_read = 0 Then Exit Do
                    crypto_stream.Write(buffer, 0, bytes_read)

                    ProcessBar1(lenFile, OutDecripted.Length)
                Loop
            End Using

        Catch ex As Exception
            crypto_transform.Dispose()
            RichLogs(ex.ToString, Color.Red, True, True)
        End Try
        crypto_transform.Dispose()
    End Sub

    Public Function FilterData(inputdata() As Byte) As Integer
        Dim newbyte(3) As Byte
        Dim reader As Stream = New MemoryStream(inputdata)
        Dim i As Integer = 0
        Do
            reader.Seek(i, SeekOrigin.Begin)
            reader.Read(newbyte, 0, newbyte.Length)
            If Encoding.UTF8.GetString(newbyte).ToLower.Contains("<?x") Then
                Return i
                Exit Do
            End If
            i += 1
        Loop
        Return 0
    End Function
    Public Function GetRawData(inputdata() As Byte) As Byte()
        Dim newbyte(4) As Byte
        Dim reader As Stream = New MemoryStream(inputdata)
        Dim i As Integer = 0
        Do
            reader.Seek(inputdata.Length - i, SeekOrigin.Begin)
            reader.Read(newbyte, 0, newbyte.Length)
            If Encoding.UTF8.GetString(newbyte) = "EndCF" Then
                Return inputdata.Take(inputdata.Length - i).ToArray
                Exit Do
            End If
            i += 1
        Loop
        Return {}
    End Function

    Private Sub MakeKeyAndIV(password As String, salt() As Byte, key_size_bits As Integer, block_size_bits As Integer, ByRef key() As Byte, ByRef _
        iv() As Byte)
        Dim derive_bytes As New Rfc2898DeriveBytes(password,
            salt, 1000)

        key = derive_bytes.GetBytes(key_size_bits / 8)
        iv = derive_bytes.GetBytes(block_size_bits / 8)
    End Sub

    Public WithEvents BgWorker As BackgroundWorker
End Class