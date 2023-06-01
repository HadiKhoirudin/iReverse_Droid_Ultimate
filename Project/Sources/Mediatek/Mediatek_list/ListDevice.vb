Imports System.Collections.Generic
Imports System.IO
Imports Newtonsoft.Json

Namespace Mediatek.Mediatek_list
    Public Class ListDevice
        Public Shared Property DevicesName As String
        Public Shared Property ModelName As String
        Public Shared Property Platform As String

        Public Class Info
            Public Property Devices As String
            Public Property Models As String
            Public Property Platform As String
            Public Property Conn As String
            Public Property Broom As String
            Public Property [New] As String

            Public Sub New(Devices As String, Models As String, Platform As String, Conn As String, Broom As String, [New] As String)
                Me.Devices = Devices
                Me.Models = Models
                Me.Platform = Platform
                Me.Conn = Conn
                Me.Broom = Broom
                Me.[New] = [New]
            End Sub
        End Class

        Public Shared Function DataSource(path As String) As List(Of Info)
            Dim DevicePath As String = File.ReadAllText(path)
            Devicelists = JsonConvert.DeserializeObject(Of List(Of Info))(DevicePath)
            Dim lists As List(Of Info) = New List(Of Info)()
            lists.Clear()

            For Each inf As Info In Devicelists
                lists.Add(New Info(inf.Devices, inf.Models, inf.Platform, inf.Conn, inf.Broom, inf.[New]))
            Next

            Return lists
        End Function

        Public Shared Devicelists As List(Of Info) = New List(Of Info)()
    End Class
End Namespace
