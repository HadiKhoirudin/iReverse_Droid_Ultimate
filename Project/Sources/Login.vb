Imports System
Imports System.Collections.Specialized
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Microsoft.VisualBasic.CompilerServices

Public Class Login
    Public Shared hwidPC As String
    Public Shared ReasonsFailed As String
    Public Shared namatool As String
    Public LoginFailed As Label
    Private TargetDT As DateTime
    Public Shared TanggalExpired As String
    Private VTool As Integer
    Public Shared ExpiredDate As String
    Public Shared username As String
    Public Shared password As String
    Private ReadOnly server As String
    Public Shared Property TimeBinding As String
    Private wc As WebClient = New WebClient()
    Private dataToSend As NameValueCollection = New NameValueCollection()

    Public Sub New()
        AddHandler Load, AddressOf Main_Load
        server = "http://localhost/iReverseWebsite/api/"
        InitializeComponent()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs)
        hwidPC = Get_HWID()
        Console.WriteLine(hwidPC.ToString)
        If File.Exists("setting.ini") Then
            Dim strArrays As String() = File.ReadAllLines("setting.ini")
            Dim num As Integer = strArrays.Count() - 1
            For i As Integer = 0 To num Step 1
                If strArrays(i).Contains("username") Then
                    username = strArrays(i).Split(New Char() {":"c})(1)
                    BunifuMaterialTextboxUsername.Text = username
                End If
                If strArrays(i).Contains("password") Then
                    password = strArrays(i).Split(New Char() {":"c})(1)
                    BunifuMaterialTextboxPassword.Text = password
                End If
            Next
            CheckBox1.Checked = True
        End If
        If File.Exists("me.ini") Then
            Dim strArrays1 As String() = File.ReadAllLines("me.ini")
            namatool = strArrays1(0)
            Text = strArrays1(0)
        End If
    End Sub
    Public Sub MyFormClosing() Handles MyBase.FormClosing
        SystemIsExit = True
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If msg.WParam.ToInt32() = Keys.Enter Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Shared Function GenerateSHA512String(inputString As Object) As String
        Dim sHA512 As SHA512 = SHA512.Create()
        Dim uTF8 As Encoding = Encoding.UTF8
        Dim objArray() As Object = {inputString}
        Dim objArray1 As Object() = objArray
        Dim flagArray() As Boolean = {True}
        Dim flagArray1 As Boolean() = flagArray
        Dim obj As Object = NewLateBinding.LateGet(uTF8, Nothing, "GetBytes", objArray, Nothing, Nothing, flagArray)
        If flagArray1(0) Then
            inputString = RuntimeHelpers.GetObjectValue(objArray1(0))
        End If
        Dim numArray As Byte() = sHA512.ComputeHash(DirectCast(obj, Byte()))
        Dim stringBuilder As StringBuilder = New StringBuilder()
        Dim length As Integer = numArray.Length - 1
        Dim num As Integer = 0
        Do
            stringBuilder.Append(numArray(num).ToString("X2"))
            num = num + 1
        Loop While num <= length
        Return stringBuilder.ToString()
    End Function

    Public Shared Function Get_HWID() As String
        Dim _clsComputerInfo As ClsComputerInfo = New ClsComputerInfo()
        Dim processorId As String = _clsComputerInfo.GetProcessorId()
        Dim motherBoardID As String = _clsComputerInfo.GetMotherBoardID()
        _clsComputerInfo.GetMACAddress()
        _clsComputerInfo.GetMACAddress()
        Return GenerateSHA512String(String.Concat(processorId, motherBoardID))
    End Function

    Public Sub ProcessLogin()
        Main.username = BunifuMaterialTextboxUsername.Text
        Main.password = BunifuMaterialTextboxPassword.Text

        username = BunifuMaterialTextboxUsername.Text
        password = BunifuMaterialTextboxPassword.Text
        If Not CheckBox1.Checked Then
            File.Delete("setting.ini")
        ElseIf Not File.Exists("setting.ini") Then
            Dim streamWriter As StreamWriter = Computer.FileSystem.OpenTextFileWriter("setting.ini", True)
            streamWriter.WriteLine(String.Concat("username:", username))
            streamWriter.WriteLine(String.Concat("password:", password))
            streamWriter.Close()
        Else
            File.Delete("setting.ini")
            Dim streamWriter1 As StreamWriter = Computer.FileSystem.OpenTextFileWriter("setting.ini", True)
            streamWriter1.WriteLine(String.Concat("username:", username))
            streamWriter1.WriteLine(String.Concat("password:", password))
            streamWriter1.Close()
        End If

        Try
            dataToSend("username") = BunifuMaterialTextboxUsername.Text
            dataToSend("password") = BunifuMaterialTextboxPassword.Text

            Dim GetData As String = Encoding.UTF8.GetString(wc.UploadValues("http://localhost/iReverseWebsite/api/mtklogin.php", dataToSend))

            If GetData = "noconn" Then
                MessageBox.Show("Pastikan Komputer Terhubung Ke Internet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            ElseIf GetData = "nodata" Then
                MessageBox.Show("Username/Password Tidak Boleh Kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            ElseIf GetData = "Expired" Then
                MessageBox.Show("Akun Anda Telah Expired!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            ElseIf GetData = "Register" Then
                MessageBox.Show("Akun Anda Belum Terdaftar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            ElseIf GetData = "True" Then
                My.Forms.Main.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString(), "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub
    Private Sub loginbutton_Click(sender As Object, e As EventArgs) Handles loginbutton.Click
        ProcessLogin()
    End Sub
End Class
