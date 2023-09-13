Imports System
Imports System.IO
Imports Microsoft.VisualBasic

Public Class ClearDirectory
        Public Shared Sub DeleteDirrectory(path As String)
            If Directory.Exists(path) Then
                Dim directory As New DirectoryInfo(path)

                For Each file As FileInfo In directory.EnumerateFiles()
                    file.Delete()
                Next

                For Each subDirectory As DirectoryInfo In directory.EnumerateDirectories()
                    subDirectory.Delete(True)
                Next

                directory.Delete(True)
            End If
        End Sub

        Public Shared Sub Spdellra(path As String, list As String)
            Dim stringlist As String() = list.Split(New Char(1) {vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

            If Directory.Exists(path) Then
                Dim directory As New DirectoryInfo(path)

                For Each file As FileInfo In directory.EnumerateFiles()

                    For Each value As String In stringlist

                        If file.Name.Contains(value) Then
                            file.Delete()
                        End If
                    Next
                Next
            End If
        End Sub
End Class