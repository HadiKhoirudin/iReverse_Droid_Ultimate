Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Newtonsoft.Json

Namespace Oneclick.Unlock_list
    Public Class ListDevice
        Public Shared Property DevicesName As String
        Public Shared Property ModelName As String
        Public Shared Property Platform As String

        Public Shared Sub CreateListDevice()
            Try
                If (Unlock.SharedUI.ListBoxview.Items.Count > 0) Then
                    Unlock.SharedUI.ListBoxview.Items.Clear()
                End If
                Dim webRequest As WebRequest = WebRequest.Create(String.Concat(datatool, "List/", "Devices/", "Brands/", Brand, ".json"))
                webRequest.Method = "POST"
                webRequest.ContentType = "application/x-www-form-urlencoded"
                webRequest.Timeout = 10000
                webRequest.GetRequestStream().Close()
                Dim streamReader As New StreamReader(webRequest.GetResponse().GetResponseStream())
                Dim response As HttpWebResponse = DirectCast(webRequest.GetResponse(), HttpWebResponse)
                If response.StatusCode = HttpStatusCode.OK Then
                    Dim RichTextBoxJSON As New RichTextBox
                    While Not streamReader.EndOfStream
                        RichTextBoxJSON.AppendText(streamReader.ReadLine().ToString())
                    End While
                    Console.WriteLine(RichTextBoxJSON.Text)
                    Dim Models As List(Of Info) = DataSource(RichTextBoxJSON.Text)
                    Unlock.SharedUI.ListBoxview.DataSource = Models
                    Unlock.SharedUI.labelTotal.Text = Unlock.SharedUI.ListBoxview.ItemCount & " " & "Models"
                Else
                    XtraMessageBox.Show(String.Concat("server error ", response.StatusCode.ToString), "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Catch exception As Exception
                XtraMessageBox.Show(exception.ToString(), "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End Try
        End Sub

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
            Devicelists = JsonConvert.DeserializeObject(Of List(Of Info))(path)
            Dim lists As New List(Of Info)()
            lists.Clear()

            For Each inf As Info In Devicelists
                lists.Add(New Info(inf.Devices, inf.Models, inf.Platform, inf.Conn, inf.Broom, inf.[New]))
            Next

            Return lists
        End Function

        Public Shared Devicelists As New List(Of Info)()
    End Class
End Namespace
