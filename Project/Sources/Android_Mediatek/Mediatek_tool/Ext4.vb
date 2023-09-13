Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports Microsoft.VisualBasic

Namespace Mediatek.Mediatek_tool
    Public Class Ext4
        Public Shared Sub Create(filename As String, fileoutput As String, length As Double, filename2 As String, fileoutput2 As String, length2 As Double)
            Dim result As Boolean = True
            Dim arg As String = String.Format("-s -l {0}U -b 4096 -a {1} ""{2}""", length, filename, fileoutput)
            Make_Ext4(arg)
            Dim cmd As String = String.Format("-s -l {0}U -b 4096 -a {1} ""{2}""", length2, filename2, fileoutput2)
            Dim text As String = Make_Ext4(cmd)
            Dim array As String() = text.Split(New Char() {vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

            If array.Count() > 1 Then
                Dim array2 As String() = array

                For Each text2 As String In array2
                    Console.WriteLine(text2)

                    If text2.Contains("error") OrElse text2.Contains("failed") Then
                        result = False
                    End If
                Next
            Else
                result = False
            End If

            If result Then
                RichLogs("done", Color.Lime, True, True)
            Else
                RichLogs("filed", Color.Red, True, True)
            End If
        End Sub

        Public Shared Sub Test(filename As String, fileoutput As String)
            Dim smd As String = String.Format("{0} -v {1}", filename, fileoutput)
            Dim text As String = Make_Ext4(smd)
            Console.WriteLine(text)
        End Sub

        Public Shared Function Make_Ext4(cmd As String) As String
            Dim process As New Process With {
                .StartInfo = New ProcessStartInfo With {
                    .UseShellExecute = False,
                    .CreateNoWindow = True,
                    .FileName = Extdata.Extfilepath,
                    .Verb = "runas",
                    .Arguments = cmd,
                    .RedirectStandardOutput = True,
                    .RedirectStandardError = True
                }
            }
            process.Start()
            Return process.StandardOutput.ReadToEnd() & process.StandardError.ReadToEnd()
        End Function

        Public Shared Function Spdl(cmd As String) As String
            Dim process As New Process With {
                .StartInfo = New ProcessStartInfo With {
                    .UseShellExecute = False,
                    .CreateNoWindow = True,
                    .FileName = Extdata.Extfilepath,
                    .Verb = "runas",
                    .Arguments = cmd,
                    .RedirectStandardOutput = True,
                    .RedirectStandardError = True
                }
            }
            process.Start()
            Return process.StandardOutput.ReadToEnd() & process.StandardError.ReadToEnd()
        End Function
    End Class
End Namespace
