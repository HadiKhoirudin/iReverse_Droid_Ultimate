Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports Microsoft.VisualBasic

Namespace Mediatek.Mediatek_tool
#Disable Warning BC40000 ' Type or member is obsolete
    Public Class Android
        Private Shared Property Result As Object

        Public Shared Function AndroidUnpact(path As String, filepath As String, worker As BackgroundWorker, e As DoWorkEventArgs) As Object
            MTKUnpackinfo(String.Concat(New String() {"--unpack-bootimg", " ", path}), filepath, worker, e)
            Result = New Object()
            Return Result
        End Function

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Private Shared Sub MTKUnpackinfo(cmd As String, path As String, worker As BackgroundWorker, ee As DoWorkEventArgs)
            Dim flag As Boolean = False
            Dim array As String = ""
            Dim array1 As String = ""
            Dim array2 As String = ""
            Dim array3 As String = ""
            Dim array4 As String = ""
            Dim array5 As String = ""
            Dim array6 As String = ""
            Dim array7 As String = ""
            Dim array8 As String = ""
            Dim array9 As String = ""
            Dim array10 As String = ""
            Dim array11 As String = ""
            Dim array12 As String = ""
            Dim FilePath As String = String.Empty
            RichLogs("", Color.Transparent, False, True)
            Dim startInfo As New ProcessStartInfo(Sourcefile.Andoidpath, cmd) With {
                .CreateNoWindow = True,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = False,
                .Verb = "runas",
                .WorkingDirectory = IO.Path.GetDirectoryName(Sourcefile.Andoidpath),
                .RedirectStandardError = True,
                .RedirectStandardOutput = True
            }

            Using process As Process = Process.Start(startInfo)
                Console.WriteLine(cmd)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()

                If worker.CancellationPending Then
                    process.Dispose()
                    ee.Cancel = True
                    Return
                Else
                    AddHandler process.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                               Console.WriteLine(e.Data)

                                                               If File.Exists(path & "\system\build.prop") Then
                                                                   FilePath = path & "\system\build.prop"
                                                                   Dim str As String() = File.ReadAllLines(FilePath)

                                                                   For i As Integer = 0 To str.Length - 1

                                                                       If str(i).Contains("manufacturer=") Then
                                                                           flag = True
                                                                           Exit For
                                                                       End If
                                                                   Next
                                                               ElseIf File.Exists(path & "\vendor\build.prop") Then
                                                                   FilePath = path & "\vendor\build.prop"
                                                                   Dim str2 As String() = File.ReadAllLines(FilePath)

                                                                   For j As Integer = 0 To str2.Length - 1

                                                                       If str2(j).Contains("manufacturer=") Then
                                                                           flag = True
                                                                           Exit For
                                                                       End If
                                                                   Next
                                                               ElseIf File.Exists(path & "prop.default") Then
                                                                   FilePath = path & "prop.default"
                                                                   Dim str3 As String() = File.ReadAllLines(FilePath)

                                                                   For k As Integer = 0 To str3.Length - 1

                                                                       If str3(k).Contains("manufacturer=") Then
                                                                           flag = True
                                                                           Exit For
                                                                       End If
                                                                   Next
                                                               ElseIf File.Exists(path & "default.prop") Then
                                                                   FilePath = path & "default.prop"
                                                                   Dim str4 As String() = File.ReadAllLines(FilePath)

                                                                   For l As Integer = 0 To str4.Length - 1

                                                                       If str4(l).Contains("manufacturer=") Then
                                                                           flag = True
                                                                           Exit For
                                                                       End If
                                                                   Next
                                                               End If

                                                               If flag = True Then

                                                                   Using streamReader As New StreamReader(FilePath)
                                                                       Dim text As String = Nothing

                                                                       'While text IsNot Nothing


                                                                       While CSharpImpl.__Assign(text, streamReader.ReadLine()) IsNot Nothing

                                                                           Console.WriteLine(text)

                                                                           If text.Contains("ro.product.manufacturer=") Then
                                                                               array2 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.dolby.manufacturer=") Then
                                                                               array2 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.product.vendor.manufacturer=") Then
                                                                               array2 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.product.brand=") Then
                                                                               array5 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.dolby.brand=") Then
                                                                               array5 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.product.vendor.brand=") Then
                                                                               array5 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.product.name=") Then
                                                                               array4 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.product.vendor.name=") Then
                                                                               array4 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.dolby.name=") Then
                                                                               array4 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.product.model=") Then
                                                                               array6 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.product.vendor.model=") Then
                                                                               array6 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.dolby.model=") Then
                                                                               array6 = text.Substring(text.IndexOf("=") + 1).Replace("effectmodel", "")
                                                                           End If

                                                                           If text.Contains("ro.build.version.release=") Or text.Contains("ro.vendor.build.version.release=") Then
                                                                               array8 = AndroidCommands.AndroidName(text.Replace("ro.build.version.release=", "").Replace("ro.vendor.build.version.release=", ""))
                                                                           End If

                                                                           If text.Contains("ro.mediatek.version.release=") Then
                                                                               array9 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.build.id=") Or text.Contains("ro.vendor.build.id=") Then
                                                                               array7 = text.Replace("ro.build.id=", "").Replace("ro.vendor.build.id=", "")
                                                                           End If

                                                                           If text.Contains("ro.build.version.security_patch=") Or text.Contains("ro.vendor.build.security_patch=") Then
                                                                               array11 = text.Replace("ro.build.version.security_patch=", "").Replace("ro.vendor.build.security_patch=", "")
                                                                           End If

                                                                           If text.Contains("ro.product.board=") Then
                                                                               array3 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.build.description=") Then
                                                                               array12 = text.Substring(text.IndexOf("=") + 1).Replace("release-keys", "")
                                                                           End If

                                                                           If text.Contains("ro.bootimage.build.date=") Or text.Contains("ro.build.date=") Then
                                                                               array10 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If

                                                                           If text.Contains("ro.oppo.market.name=") Then
                                                                           End If

                                                                           If text.Contains("ro.mediatek.platform=") Or text.Contains("ro.vendor.mediatek.platform=") Then
                                                                               array = text.Replace("ro.mediatek.platform=", "").Replace("release-keys", "").Replace("ro.vendor.mediatek.platform=", "")
                                                                               Dim text9 As String = array.ToLower()
                                                                               array = text9.Replace("qcom", "Qualcomm SnapDragon( QLM ) ").Replace("mt", "MT").Replace("sc", "SpreadTrum( SPD ) SP").Replace("sp", "SpreadTrum( SPD ) SP").Replace("samsungexynos", "Samsung Exynos ").Replace("hi", "( HiSilicon Kirin ) ").Replace("m7cdug", "Qualcomm SnapDragon( QLM )")
                                                                           End If

                                                                           If text.Contains("ro.product.cpu.abi=") Then
                                                                               array1 = text.Substring(text.IndexOf("=") + 1)
                                                                           End If
                                                                           text = streamReader.ReadLine()
                                                                       End While

                                                                       If array <> "" Then
                                                                           RichLogs(" platform" & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array.ToUpper(), Color.Cyan, True, True)
                                                                       End If

                                                                       If array1 <> "" Then
                                                                           RichLogs(" cpu abi" & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array1, Color.Cyan, True, True)
                                                                       End If

                                                                       If array2 <> "" Then
                                                                           RichLogs(" manufacturer" & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array2, Color.Cyan, True, True)
                                                                       End If

                                                                       If array3 <> "" Then
                                                                           RichLogs(" board" & vbTab & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array3, Color.Cyan, True, True)
                                                                       End If

                                                                       If array4 <> "" Then
                                                                           RichLogs(" name" & vbTab & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array4, Color.Cyan, True, True)
                                                                       End If

                                                                       If array5 <> "" Then
                                                                           RichLogs(" brand" & vbTab & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array5, Color.Cyan, True, True)
                                                                       End If

                                                                       If array6 <> "" Then
                                                                           RichLogs(" model" & vbTab & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array6, Color.Cyan, True, True)
                                                                       End If

                                                                       If array7 <> "" Then
                                                                           RichLogs(" build id" & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array7, Color.Cyan, True, True)
                                                                       End If

                                                                       If array8 <> "" Then
                                                                           RichLogs(" version" & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array8, Color.Cyan, True, True)
                                                                       End If

                                                                       If array9 <> "" Then
                                                                           RichLogs(" build number" & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array9, Color.Cyan, True, True)
                                                                       End If

                                                                       If array10 <> "" Then
                                                                           RichLogs(" build date" & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array10, Color.Cyan, True, True)
                                                                       End If

                                                                       If array11 <> "" Then
                                                                           RichLogs(" security Patch" & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array11, Color.Cyan, True, True)
                                                                       End If

                                                                       If array12 <> "" Then
                                                                           RichLogs(" description" & vbTab & ": ", Color.WhiteSmoke, True, False)
                                                                           RichLogs(array12, Color.Cyan, True, True)
                                                                       End If
                                                                   End Using
                                                               End If
                                                           End Sub
                End If

                process.WaitForExit()
            End Using
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class

    Public Class AndroidCommands
        Public Shared Function AndroidName(os As String) As String
            os = os.Trim()
            Dim result As String = ""

            If os.Contains("1.5") Then
                result = "Android (" & os & ") Cupcake"
            End If

            If os.Contains("1.6") Then
                result = "Android (" & os & ") Donut"
            End If

            If os.Contains("2") Then
                result = "Android (" & os & ") Eclair"
            End If

            If os.Contains("2.2") OrElse os.Contains("2.2.3") Then
                result = "Android (" & os & ") Froyo"
            End If

            If os.Contains("2.3") Then
                result = "Android (" & os & ") Gingerbread"
            End If

            If os.Contains("3.0") OrElse os.Contains("3.1") OrElse os.Contains("3.2") Then
                result = "Android (" & os & ") Honeycomb"
            End If

            If os.Contains("4.0") Then
                result = "Android (" & os & ") ICE Cream Sandwich"
            End If

            If os.Contains("4.1") OrElse os.Contains("4.2") OrElse os.Contains("4.3") Then
                result = "Android (" & os & ") Jelly Bean"
            End If

            If os.Contains("4.4") Then
                result = "Android (" & os & ") KitKat"
            End If

            If os.Contains("5.0") OrElse os.Contains("5.1") Then
                result = "Android (" & os & ") Lollipop"
            End If

            If os.Contains("6.0") Then
                result = "Android (" & os & ") Marshmallow"
            End If

            If os.Contains("7.0") OrElse os.Contains("7.1") Then
                result = "Android (" & os & ") Nougat"
            End If

            If os.Contains("8.0") OrElse os.Contains("8.1") Then
                result = "Android (" & os & ") Oreo"
            End If

            If os.Contains("9") Then
                result = "Android (" & os & ") Pie"
            End If

            If os.Contains("10") Then
                result = "Android (" & os & ")"
            End If

            If os.Contains("11") Then
                result = "Android (" & os & ")"
            End If

            If os.Contains("12") Then
                result = "Android (" & os & ")"
            End If

            Return result
        End Function

        'Private Class CSharpImpl
        '<Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        'Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
        'target = value
        'Return value
        'End Function
        'End Class
    End Class
End Namespace
