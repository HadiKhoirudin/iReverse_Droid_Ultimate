Imports System
Imports System.Globalization

Namespace Mediatek.Disksize
    Public Class SizeSize
        Public Shared Function ParseHexString(hexNumber As String) As Double
            hexNumber = hexNumber.Replace("x", String.Empty)
            Dim result As Long = Nothing
            Long.TryParse(hexNumber, NumberStyles.HexNumber, Nothing, result)
            Return result
        End Function

        Public Shared Function GetFileCalc(byteCount As Double) As String
            Dim size As String = "0 Bytes"

            If byteCount >= 1073741824.0 Then
                size = byteCount.ToString() & "KB"
            ElseIf byteCount >= 1048576.0 Then
                size = byteCount.ToString() & "KB"
            ElseIf byteCount >= 1024.0 Then
                size = byteCount.ToString() & "KB"
            ElseIf byteCount > 0.0 AndAlso byteCount < 1024.0 Then
                size = byteCount.ToString() & " KB"
            End If

            Return size
        End Function

        Public Shared SizeSuffixes As String() = {"bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}

        Public Shared Function ParseFileSize(value As String, kb_value As Integer) As Double
            value = value.Trim()

            Try
                Dim ext_start As Integer = 0

                For i As Integer = value.Length - 1 To 0

                    If Not Char.IsLetter(value, i) Then
                        ext_start = i + 1
                        Exit For
                    End If
                Next

                Dim number As Double = Double.Parse(value.Substring(0, ext_start))
                Dim suffix As String

                If ext_start < value.Length Then
                    suffix = value.Substring(ext_start).Trim().ToUpper()
                    If suffix = "BYTES" Then suffix = "bytes"
                Else
                    suffix = "bytes"
                End If

                Dim suffix_index As Integer = -1

                For i As Integer = 0 To SizeSuffixes.Length - 1

                    If SizeSuffixes(i) = suffix Then
                        suffix_index = i
                        Exit For
                    End If
                Next

                If suffix_index < 0 Then Throw New FormatException("Unknown file size extension " & suffix & ".")
                Return Math.Round(number * Math.Pow(kb_value, suffix_index))
            Catch ex As Exception
                Throw New FormatException("Invalid file size format", ex)
            End Try
        End Function

        Public Shared Function ToFileSize(value As Double) As String
            Dim suffixes As String() = {"bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}

            For i As Integer = 0 To suffixes.Length - 1

                If value <= Math.Pow(1024, i + 1) Then
                    Return ThreeNonZeroDigits(value / Math.Pow(1024, i)) & " " & suffixes(i)
                End If
            Next

            Return ThreeNonZeroDigits(value / Math.Pow(1024, suffixes.Length - 1)) & " " & suffixes(suffixes.Length - 1)
        End Function

        Private Shared Function ThreeNonZeroDigits(value As Double) As String
            If value >= 100 Then
                Return value.ToString("0,0")
            ElseIf value >= 10 Then
                Return value.ToString("0.0")
            Else
                Return value.ToString("0.00")
            End If
        End Function
    End Class
End Namespace
