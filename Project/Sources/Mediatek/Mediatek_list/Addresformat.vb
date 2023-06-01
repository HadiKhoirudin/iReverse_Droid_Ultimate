Imports System.Collections.Generic

Namespace Mediatek.Mediatek_list
    Public Class Addresformat
        Public Class Addres
            Public Filename As String
            Public Filepath As String

            Public Sub New(Filename As String, Filepath As String)
                Me.Filename = Filename
                Me.Filepath = Filepath
            End Sub
        End Class

        Public Shared Format As List(Of Addres) = New List(Of Addres)()
    End Class
End Namespace
