Imports System
Imports System.ComponentModel
Imports System.Net
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Public Class DownloadOperation

    Private CheckKelar As Integer
    Private EncryptedDownloadData As Byte()

    Public Overridable Property downloader As WebClient
    Private Sub runProc(sender As Object, e As DoWorkEventArgs)
        Try
            downloader = New WebClient()
            AddHandler downloader.DownloadDataCompleted, New DownloadDataCompletedEventHandler(AddressOf DownloadFileCompleted)
            AddHandler downloader.DownloadProgressChanged, New DownloadProgressChangedEventHandler(AddressOf downloader_DownloadProgressChanged)
            downloader.DownloadDataAsync(New Uri(UrlOneClick))
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub savefile(sender As Object, e As DoWorkEventArgs)
        Try
            downloader = New WebClient()
            AddHandler downloader.DownloadDataCompleted, New DownloadDataCompletedEventHandler(AddressOf DownloadSave)
            AddHandler downloader.DownloadProgressChanged, New DownloadProgressChangedEventHandler(AddressOf downloader_DownloadProgressChanged)
            downloader.DownloadDataAsync(New Uri(UrlOneClick))
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            MsgBox(exception.ToString(), MsgBoxStyle.OkOnly, Nothing)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub downloader_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        Main.SharedUI.Progressbar2.Invoke(New Action(Sub()
                                                         Main.SharedUI.Progressbar2.EditValue = e.ProgressPercentage
                                                     End Sub))
        CheckKelar = e.ProgressPercentage
    End Sub

    Private Sub DownloadFileCompleted(sender As Object, e As DownloadDataCompletedEventArgs)
        EncryptedDownloadData = e.Result
        CheckKelar = 100
    End Sub

    Private Sub DownloadSave(sender As Object, e As DownloadDataCompletedEventArgs)
        datadownload = e.Result
        CheckKelar = 100
    End Sub

    Public Property datadownload As Byte()

    Public Property UrlOneClick As String

End Class
