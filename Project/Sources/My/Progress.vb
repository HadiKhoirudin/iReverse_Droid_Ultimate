Imports System
Imports System.Diagnostics
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Module Progress

    Public SystemIsExit As Boolean = False
    Public Watch As Stopwatch
    Public Counter As Integer = 30
    Public WaktuCari As Integer
    Public foldersave As String

    Public Function GetButtonText(sender As Object) As String
        If TypeOf sender Is Button Then
            Dim btn As Button = DirectCast(sender, Button)
            Return btn.Text
        ElseIf TypeOf sender Is SimpleButton Then
            Dim btn As SimpleButton = DirectCast(sender, SimpleButton)
            Return btn.Text
        End If
        Return ""
    End Function

    Public Sub Delay(ByVal dblSecs As Double)
        Microsoft.VisualBasic.DateAndTime.Now.AddSeconds(0.0000115740740740741)
        Dim dateTime As DateTime = Microsoft.VisualBasic.DateAndTime.Now.AddSeconds(0.0000115740740740741)
        Dim dateTime1 As DateTime = dateTime.AddSeconds(dblSecs)
        While DateTime.Compare(Microsoft.VisualBasic.DateAndTime.Now, dateTime1) <= 0
            Windows.Forms.Application.DoEvents()
        End While
    End Sub
    Public Sub Setwaktu()
        WaktuCari = 60
    End Sub

    Public Sub ProcessBar1(Process As Long, total As Long)
        Main.SharedUI.Progressbar1.Invoke(CType(Sub() Main.SharedUI.Progressbar1.EditValue = CInt(Math.Round(Process * 100L / total)), Action))
    End Sub

    Public Sub ProcessBar2(Process As Long, total As Long)
        Main.SharedUI.Progressbar2.Invoke(CType(Sub() Main.SharedUI.Progressbar2.EditValue = CInt(Math.Round(Process * 100L / total)), Action))
    End Sub

    Public Sub ProcessBar1(Process As Long)
        Main.SharedUI.Progressbar1.Invoke(CType(Sub() Main.SharedUI.Progressbar1.EditValue = CInt(Process), Action))
    End Sub

    Public Sub ProcessBar2(Process As Long)
        Main.SharedUI.Progressbar2.Invoke(CType(Sub() Main.SharedUI.Progressbar2.EditValue = CInt(Process), Action))
    End Sub

End Module
