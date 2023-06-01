Imports System.Collections.Generic

Namespace Mediatek.Mediatek_list
    Public Class Datarows
        Public Class Info
            Public PartitionName As String
            Public FileOffset As String
            Public FileLenght As String
            Public FileFlags As String
            Public FileUUID As String

            Public Sub New(PartitionName As String, FileOffset As String, FileLenght As String, FileFlags As String, FileUUID As String)
                Me.PartitionName = PartitionName
                Me.FileOffset = FileOffset
                Me.FileLenght = FileLenght
                Me.FileFlags = FileFlags
                Me.FileUUID = FileUUID
            End Sub
        End Class

        Public Shared MtkDataview As List(Of Info) = New List(Of Info)()
    End Class
End Namespace
