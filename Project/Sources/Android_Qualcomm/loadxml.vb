Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Reverse_Tool.Bismillah.FIREHOSE.FIREHOSE_MANAGER

Partial Public Class loadxml

    Public Shared LoadFolder As String
    Private Property lvi As ListViewItem

    Shared Sub New()
        LoadFolder = ""
    End Sub

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        AddHandler Load, New EventHandler(AddressOf LoadMenu)
        AddHandler ListView1.DrawColumnHeader, AddressOf ListView1_DrawColumnHeader
        AddHandler ListView1.DrawItem, AddressOf ListView1_DrawItem
    End Sub

    Public Sub LoadMenu(sender As Object, e As EventArgs)
        LoadFolder = LoadFolderXml
        Dim directoryInfo As New DirectoryInfo(LoadFolder)
        Dim listView1 As ListView = Me.ListView1
        listView1.Columns.Add("", 20)
        listView1.Columns.Add("", 254, HorizontalAlignment.Left)
        listView1.View = View.Details
        listView1.CheckBoxes = True
        listView1.FullRowSelect = True
        Dim fileInfos As New List(Of FileInfo)()
        Dim files As FileInfo() = directoryInfo.GetFiles()
        Dim num As Integer = 0
        While num < files.Length
            Dim fileInfo As FileInfo = files(num)
            If fileInfo IsNot Nothing AndAlso Operators.CompareString(Path.GetExtension(fileInfo.ToString().ToLower()), ".xml", False) = 0 Then
                lvi = New ListViewItem()
                lvi.SubItems.Add(fileInfo.ToString())
                Me.ListView1.Items.Add(lvi)
            End If
            num += 1
        End While
    End Sub
    Public Sub ListView1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        Dim brush As New SolidBrush(Color.FromArgb(70, 70, 70))
        e.Graphics.FillRectangle(brush, e.Bounds)
        e.Graphics.DrawString(e.Header.Text, e.Font, Brushes.White, e.Bounds)
    End Sub
    Public Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs)
        e.DrawDefault = True
    End Sub
    Public Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim enumerator As IEnumerator = Nothing
        Dim strxml As String = ""
        Try
            enumerator = ListView1.CheckedItems.GetEnumerator()
            While enumerator.MoveNext()
                Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
                strxml = String.Concat(strxml, current.SubItems(1).Text, ",")
            End While
        Finally
            If (TypeOf enumerator Is IDisposable) Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        Main.SharedUI.QcFlashCtrl.Loadsss(strxml)
        Close()
    End Sub

    Public Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        Main.SharedUI.QcFlashCtrl.TxtFlashRawXML.Text = ""

        Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim enumerator As IEnumerator = Nothing
        Dim enumerator1 As IEnumerator = Nothing
        If ListView1.Items.Count = 0 Then
            MsgBox("zonk", MsgBoxStyle.OkOnly, Nothing)
        ElseIf Not CheckBox1.Checked Then
            Try
                enumerator1 = ListView1.Items.GetEnumerator()
                While enumerator1.MoveNext()
                    DirectCast(enumerator1.Current, ListViewItem).Checked = False
                End While
            Finally
                If (TypeOf enumerator1 Is IDisposable) Then
                    TryCast(enumerator1, IDisposable).Dispose()
                End If
            End Try
        Else
            Try
                enumerator = ListView1.Items.GetEnumerator()
                While enumerator.MoveNext()
                    DirectCast(enumerator.Current, ListViewItem).Checked = True
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub

    Public WithEvents CheckBox1 As CheckBox
    Friend WithEvents LabelControl1 As LabelControl
End Class
