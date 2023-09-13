Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports Reverse_Tool.Bismillah.FIREHOSE.FIREHOSE_MANAGER

Public Class CryptoOperation

    Public Sub EncryptFile(password As String, in_file As Byte(), Filenya As String)
        CryptFile(password, in_file, OutDecripted, True, Filenya)
    End Sub

    Public Shared Sub DecryptFile(password As String, in_file As Byte(), FileNYa As String)
        CryptFile(password, in_file, OutDecripted, False, FileNYa)
    End Sub


    Public Shared Sub CryptFile(password As String, in_file As Byte(), out_file As Byte(), encrypt As Boolean, Filenya As String)
        Using New MemoryStream(in_file)
            Using New MemoryStream(OutDecripted)
                CryptStream(password, in_file, encrypt, Filenya, 0L)
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
        Dim aesCryptoServiceProvider As New AesCryptoServiceProvider()
        Dim num As Integer = 0
        Dim num1 As Integer = 1024
        Do
            If Not aesCryptoServiceProvider.ValidKeySize(num1) Then
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
        MakeKeyAndIV(password, numArray2, num, blockSize, numArray, numArray1)
        cryptoTransform = If(Not encrypt, aesCryptoServiceProvider.CreateDecryptor(numArray, numArray1), aesCryptoServiceProvider.CreateEncryptor(numArray, numArray1))
        Dim memoryStream As New MemoryStream()

        Dim memoryStream1 As New MemoryStream(OutDecripted)

        Dim num2 As Long = 0L
        Try
            Using memoryStream2 As New MemoryStream(in_stream)
                Using cryptoStream As New CryptoStream(memoryStream1, cryptoTransform, CryptoStreamMode.Write)
                    Dim numArray3(1024) As Byte
                    While True
                        Dim num3 As Integer = memoryStream2.Read(numArray3, 0, 1024)
                        num2 += num3
                        If num3 = 0 Then
                            Exit While
                        End If
                        cryptoStream.Write(numArray3, 0, num3)
                    End While
                End Using
            End Using
            If Operators.CompareString(Filenya, "loader", False) = 0 Then

                loader = GetRawData(OutDecripted.Take(num2).ToArray())

            ElseIf Operators.CompareString(Filenya, "xml", False) = 0 Then

                Dim rawData As Byte() = GetRawData(OutDecripted.Take(num2).ToArray())

                Dim num4 As Integer = FilterData(rawData)
                Dim str As String = Encoding.UTF8.GetString(rawData)
                StringXml = New String(str.Skip(num4 - 1).ToArray())
            ElseIf Operators.CompareString(Filenya, "raw", False) = 0 Then

                FilesOneClick = GetRawData(OutDecripted.Take(num2).ToArray())

            End If
            cryptoTransform.Dispose()
            flag = True
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            cryptoTransform.Dispose()
            RichLogs(exception.ToString(), Color.Red, True, True)
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Shared Function FilterData(inputdata As Byte()) As Integer
        Dim numArray(3) As Byte
        Dim memoryStream As Stream = New MemoryStream(inputdata)
        Dim num As Integer = 0
        While True
            memoryStream.Seek(num, SeekOrigin.Begin)
            memoryStream.Read(numArray, 0, numArray.Length)
            If Encoding.UTF8.GetString(numArray).ToLower().Contains("<?x") Then
                Exit While
            End If
            num += 1
        End While
        Return num
    End Function

    Public Shared Function GetRawData(inputdata As Byte()) As Byte()
        Dim numArray(4) As Byte
        Dim memoryStream As Stream = New MemoryStream(inputdata)
        Dim num As Integer = 0
        While True
            memoryStream.Seek(inputdata.Length - num, SeekOrigin.Begin)
            memoryStream.Read(numArray, 0, numArray.Length)
            If Operators.CompareString(Encoding.UTF8.GetString(numArray), "EndCF", False) = 0 Then
                Exit While
            End If
            num += 1
        End While
        Dim array As Byte() = inputdata.Take(inputdata.Length - num).ToArray()
        Return array
    End Function

    Public Shared Sub MakeKeyAndIV(password As String, salt As Byte(), key_size_bits As Integer, block_size_bits As Integer, ByRef key As Byte(), ByRef iv As Byte())
        Dim rfc2898DeriveBytes As New Rfc2898DeriveBytes(password, salt, 1000)
        key = rfc2898DeriveBytes.GetBytes(Math.Round(key_size_bits / 8.0))
        iv = rfc2898DeriveBytes.GetBytes(Math.Round(block_size_bits / 8.0))
    End Sub

End Class