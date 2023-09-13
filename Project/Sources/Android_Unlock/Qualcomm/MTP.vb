Imports System
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Module MTP
    Public MTPCommand As String
    Public URLCommand As String
#Region "UI"

    Public Sub BtnMTPOpenYouTube_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub
    Public Sub BtnMTPOpenBrowser_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnMTPOpenSettings_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnMTPOpenStore_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnMTPEnableADB_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnMTPRemoveFrpSamsung_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnMTPBypassFRPOld_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnMTPBypassFRPNew_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnMTPFactoryResetOld_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

    Public Sub BtnMTPFactoryResetNew_Click(sender As Object, e As EventArgs)
        If Not Unlock.SharedUI.WorkerUnlock.IsBusy Then
            RtbClear()
            MTPCommand = GetButtonText(sender)
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(MTPCommand & vbCrLf, Color.Orange, True, True)
            Unlock.SharedUI.WorkerUnlock.RunWorkerAsync()
            Unlock.SharedUI.WorkerUnlock.Dispose()
        End If
    End Sub

#End Region

#Region "UI Function"
    Public Sub MTPWorkerStart(sender As Object, e As DoWorkEventArgs)
        Console.WriteLine("Worker Unlock Is Started For MTP...")
        Watch.Start()
        KillCommand.ProcessKill()

        If Consoles.FindUSBMTP() Then

            If (MTPCommand = "[MTP] Open YouTube") Then
                URLCommand = "https://www.youtube.com/account_privacy"

            ElseIf (MTPCommand = "[MTP] Open Browser") Then

                If (Consoles.Manufacturer.ToLower().Contains("samsung")) Then
                    URLCommand = "https://apps.samsung.com/appquery/appDetail.as?appId=com.sec.android.app.sbrowser&cld-000005006635"

                ElseIf (Consoles.Manufacturer.ToLower().Contains("xiaomi")) Then
                    URLCommand = "https://hadikhoirudin.github.io/#xiaomi-browser"

                Else
                    URLCommand = "https://hadikhoirudin.github.io/#universal-browser"
                End If

            ElseIf (MTPCommand = "[MTP] Open Settings") Then
                URLCommand = "https://hadikhoirudin.github.io/#universal-settings"

            ElseIf (MTPCommand = "[MTP] Open Store") Then
                URLCommand = "https://www.samsung.com/vn/apps/galaxy-store/"

            ElseIf (MTPCommand = "[MTP] Enable ADB") Then

            ElseIf (MTPCommand = "[MTP] Remove FRP") Then

            ElseIf (MTPCommand = "[MTP] Bypass FRP [OLD]") Then

            ElseIf (MTPCommand = "[MTP] Bypas FRP [NEW]") Then

            ElseIf (MTPCommand = "[MTP] Factory Reset [OLD]") Then

            ElseIf (MTPCommand = "[MTP] Factory Reset [New]") Then

            End If


            If URLCommand = "" Then

            Else
                Consoles.MTPFiles(sender, e)

                RichLogs("Installing driver ... ", Color.WhiteSmoke, False, False)
                Consoles.Driver("install --inf=" & """" & Consoles.PackDir & "\SAMSUNG_Android.inf" & """", sender, e)
                RichLogs("[OK]", Color.Lime, False, True)

                Dim AOA As String = 1
                If Unlock.SharedUI.cb_AOA2.Checked Then
                    AOA = 2
                Else
                    RichLogs("Limiting AOA to version 1.0 ... ", Color.WhiteSmoke, False, False)
                    Delay(2)
                    RichLogs("[OK]", Color.Lime, False, True)
                End If
                Dim command As String = "-d " & """" & Consoles.VID.Replace("VID_", "").ToLower() & ":" & Consoles.PID.Replace("PID_", "").ToLower() & """" & " -a " & """" & AOA & """" & " -D " & """" & "iReverse Droid Ultimate" & """" & " -u " & """" & URLCommand & """" & " -V"

                RichLogs("Starting MTP Bypass Services ... ", Color.WhiteSmoke, False, False)

                If Not Consoles.LinuxAdk(command, sender, e) Then
                    RichLogs("[Failed]", Color.Red, False, True)
                Else
                    RichLogs("[OK]", Color.Lime, False, True)

                    RichLogs(" ", Color.WhiteSmoke, False, True)
                    RichLogs("--------------------------------------------------------------------", Color.WhiteSmoke, False, True)
                    RichLogs("              SUCCESS! PLEASE CHECK YOUR DEVICE SCREEN              ", Color.Lime, True, True)
                    RichLogs("--------------------------------------------------------------------", Color.WhiteSmoke, False, True)
                End If

                Consoles.Driver("uninstall --inf=" & """" & Consoles.PackDir & "\SAMSUNG_Android.inf" & """", sender, e)
            End If
        End If

    End Sub

    Public Sub MTPAllDone(sender As Object, e As RunWorkerCompletedEventArgs)
        If Not URLCommand = "" Then
            URLCommand = ""
            KillCommand.ProcessKill()
            Consoles.Cleaner()
        End If

        MTPCommand = ""

        Delay(3)
        Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Text = "", Action))

        TimeSpanElapsed.ElapsedTime(Watch)
        Watch.Stop()
    End Sub

#End Region
End Module
