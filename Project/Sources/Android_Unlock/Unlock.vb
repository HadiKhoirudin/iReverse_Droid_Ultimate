Imports System
Imports Reverse_Tool.Oneclick.Unlock_list.ListDevice
Imports Reverse_Tool.Bismillah.FIREHOSE.FIREHOSE_MANAGER
Imports System.ComponentModel

Public Class Unlock

    Friend Shared SharedUI As Unlock
    Public Shared WorkerUnlock As New BackgroundWorker()
    Public Shared CurrentUnlockPage As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        SharedUI = Me
        AddHandler Load, AddressOf Unlock_Load
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub Unlock_Load()

        WorkerUnlock.WorkerSupportsCancellation = True
        WorkerUnlock.WorkerReportsProgress = True

#Region "Tab EFS"

        AddHandler BtnADBEnableDiag.Click, AddressOf BtnADBEnableDiag_Click
        AddHandler BtnADBEnableDiagXiaomi.Click, AddressOf BtnADBEnableDiagXiaomi_Click

        AddHandler BtnBrowseQCN.Click, AddressOf BtnBrowseQCN_Click
        AddHandler BtnReadQCN.Click, AddressOf BtnReadQCN_Click
        AddHandler BtnQcReadIMEI.Click, AddressOf BtnQcReadIMEI_Click
        AddHandler BtnWriteQCN.Click, AddressOf BtnWriteQCN_Click
        AddHandler BtnQcWriteIMEI.Click, AddressOf BtnQcWriteIMEI_Click
        AddHandler TxtQcIMEI1.KeyPress, AddressOf TxtQcIMEI1_KeyPress
        AddHandler TxtQcIMEI1.EditValueChanged, AddressOf TxtQcIMEI1_EditValueChanged
        AddHandler TxtQcIMEI2.KeyPress, AddressOf TxtQcIMEI2_KeyPress
        AddHandler TxtQcIMEI2.EditValueChanged, AddressOf TxtQcIMEI2_EditValueChanged
        AddHandler cb_SingleIMEI.CheckedChanged, AddressOf cb_SingleIMEI_CheckedChanged

#End Region

#Region "Tab MTP"

        AddHandler BtnMTPOpenYouTube.Click, AddressOf BtnMTPOpenYouTube_Click
        AddHandler BtnMTPOpenBrowser.Click, AddressOf BtnMTPOpenBrowser_Click
        AddHandler BtnMTPOpenSettings.Click, AddressOf BtnMTPOpenSettings_Click
        AddHandler BtnMTPOpenStore.Click, AddressOf BtnMTPOpenStore_Click

        AddHandler BtnMTPEnableADB.Click, AddressOf BtnMTPEnableADB_Click
        AddHandler BtnMTPRemoveFrpSamsung.Click, AddressOf BtnMTPRemoveFrpSamsung_Click
        AddHandler BtnMTPBypassFRPOld.Click, AddressOf BtnMTPBypassFRPOld_Click
        AddHandler BtnMTPBypassFRPNew.Click, AddressOf BtnMTPBypassFRPNew_Click
        AddHandler BtnMTPFactoryResetOld.Click, AddressOf BtnMTPFactoryResetOld_Click
        AddHandler BtnMTPFactoryResetNew.Click, AddressOf BtnMTPFactoryResetNew_Click

#End Region
    End Sub
    Private Sub ListBoxview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxview.SelectedIndexChanged
        For Each item As Object In ListBoxview.SelectedItems
            Dim list As Info = TryCast(item, Info)
            DevicesName = list.Devices
            ModelName = list.Models
            Platform = list.Platform

            If (Platform = "Qualcomm") Then
                SelectedQC(list.Devices, list.Models)
            ElseIf (Platform = "Spreadtrum" OrElse Platform = "Unisoc") Then
                SelectedSPD(list.Devices, list.Models)
            Else
                SelectedMTK(list.Devices, list.Models)
            End If

            If Not list.[New] = Nothing Then
                Console.WriteLine("Selected : " & list.Devices & " " & list.Models & " " & list.Platform & " New Method")
            Else
                Console.WriteLine("Selected : " & list.Devices & " " & list.Models & " " & list.Platform & " Old Method")
            End If

        Next
        labelTotal.Text = ListBoxview.ItemCount & " " & "Models"
    End Sub

    Private Sub SelectedQC(Devices As String, Models As String)
        Chipset = "Qualcomm"
        Main.SharedUI.PictureEditSelectedChip.EditValue = My.Resources.logochipqualcomm

        TabQCEDL.PageVisible = True
        TabQCEFS.PageVisible = True
        TabUnlock.SelectedTabPage = TabQCEDL

        TabMTKBrom.PageVisible = False
        TabMTKClient.PageVisible = False
        TabMTKMeta.PageVisible = False
        TabMTKNV.PageVisible = False

        TabSPDDownload.PageVisible = False
        TabSPDDiag.PageVisible = False

        MerkTerpilih = Brand
        DevicesTerpilih = Devices
        TypeTerpilih = Models
        EDL.exectype(TypeTerpilih)
    End Sub
    Private Sub SelectedMTK(Devices As String, Models As String)
        Chipset = "Mediatek"
        Main.SharedUI.PictureEditSelectedChip.EditValue = My.Resources.logochipmediatek

        TabQCEDL.PageVisible = False
        TabQCEFS.PageVisible = False

        TabSPDDownload.PageVisible = False
        TabSPDDiag.PageVisible = False

        TabMTKBrom.PageVisible = True
        TabMTKClient.PageVisible = True
        TabMTKMeta.PageVisible = True
        TabMTKNV.PageVisible = True

        TabUnlock.SelectedTabPage = TabMTKBrom

    End Sub
    Private Sub SelectedSPD(Devices As String, Models As String)
        Chipset = "Spreadtrum"
        Main.SharedUI.PictureEditSelectedChip.EditValue = My.Resources.logochipspreadtrum

        TabSPDDownload.PageVisible = True
        TabSPDDiag.PageVisible = True

        TabUnlock.SelectedTabPage = TabSPDDownload

        TabQCEDL.PageVisible = False
        TabQCEFS.PageVisible = False

        TabMTKBrom.PageVisible = False
        TabMTKClient.PageVisible = False
        TabMTKMeta.PageVisible = False
        TabMTKNV.PageVisible = False
    End Sub

    Private Sub TabUnlock_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangingEventArgs) Handles TabUnlock.SelectedPageChanging

        If Not (e.Page.Text = "") Then
            Console.WriteLine("Unlock : Selected Page " & e.Page.Text & " Last Page " & e.PrevPage.Text)
        End If

        If Not WorkerUnlock.IsBusy Then

            If e.PrevPage Is TabMTKBrom Then


            ElseIf e.PrevPage Is TabMTKClient Then


            ElseIf e.PrevPage Is TabMTKMeta Then


            ElseIf e.PrevPage Is TabMTKNV Then


            ElseIf e.PrevPage Is TabQCEDL Then


            ElseIf e.PrevPage Is TabQCEFS Then

                RemoveHandler WorkerUnlock.DoWork, AddressOf EFSWorkerStart
                RemoveHandler WorkerUnlock.RunWorkerCompleted, AddressOf EFSAllDone

            ElseIf e.PrevPage Is TabSPDDownload Then


            ElseIf e.PrevPage Is TabSPDDiag Then


            ElseIf e.PrevPage Is TabMTP Then

                RemoveHandler WorkerUnlock.DoWork, AddressOf MTPWorkerStart
                RemoveHandler WorkerUnlock.RunWorkerCompleted, AddressOf MTPAllDone

            End If

            If e.Page Is TabMTKBrom Then


            ElseIf e.Page Is TabMTKClient Then


            ElseIf e.Page Is TabMTKMeta Then


            ElseIf e.Page Is TabMTKNV Then


            ElseIf e.Page Is TabQCEDL Then


            ElseIf e.Page Is TabQCEFS Then

                AddHandler WorkerUnlock.DoWork, AddressOf EFSWorkerStart
                AddHandler WorkerUnlock.RunWorkerCompleted, AddressOf EFSAllDone

            ElseIf e.Page Is TabSPDDownload Then


            ElseIf e.Page Is TabSPDDiag Then


            ElseIf e.Page Is TabMTP Then

                AddHandler WorkerUnlock.DoWork, AddressOf MTPWorkerStart
                AddHandler WorkerUnlock.RunWorkerCompleted, AddressOf MTPAllDone

            End If


        End If
    End Sub

End Class
