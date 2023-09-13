Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace Qualcomm.Qualcomm_list
    Public Class Modellist
        Public Shared Brand As String
        Public Shared Sub CreatingCommand(list As String(), command As String)
            MtkUnlock.SharedUI.UI_Unibrom.Controls.Clear()
            Dim num = 3
            Dim text As String
            For Each text In list
                Dim Simplebutton As New SimpleButton With {
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                }
                Simplebutton.Appearance.BackColor = Color.DimGray
                Simplebutton.Appearance.Font = New Font("Tahoma", 8.25F)
                Simplebutton.Appearance.Options.UseBackColor = True
                Simplebutton.Appearance.Options.UseFont = True
                Simplebutton.Appearance.Options.UseTextOptions = True
                Simplebutton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                Simplebutton.AppearanceHovered.Font = New Font("Tahoma", 9.25F)
                Simplebutton.AppearanceHovered.Options.UseFont = True
                Simplebutton.AppearanceHovered.Options.UseImage = True
                If Equals(text, "READ INFO") Then
                    Simplebutton.ImageOptions.Image = My.Resources.Readinfo22
                End If
                If Equals(text, "FORMAT DATA") Then
                    Simplebutton.ImageOptions.Image = My.Resources.Format22
                End If
                If Equals(text, "ERASE FRP") Then
                    Simplebutton.ImageOptions.Image = My.Resources.Erase22
                End If
                If Equals(text, "ERASE MICLOUD") Then
                    Simplebutton.ImageOptions.Image = My.Resources.MiCloud22
                End If
                If Equals(text, "SAFE FORMAT MISC") Then
                    Simplebutton.ImageOptions.Image = My.Resources.Save22
                End If
                If Equals(text, "SAFE FORMAT MISC II") Then
                    Simplebutton.ImageOptions.Image = My.Resources.Save22
                End If
                If Equals(text, "SAFE FORMAT PARA") Then
                    Simplebutton.ImageOptions.Image = My.Resources.Safe22px
                End If
                If Equals(text, "SAFE FORMAT PARA II") Then
                    Simplebutton.ImageOptions.Image = My.Resources.Safe22px
                End If
                If Equals(text, "VIVO FORMAT SAFE GALERY") Then
                    Simplebutton.ImageOptions.Image = My.Resources.Safe22
                End If
                Simplebutton.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
                Simplebutton.Location = New Point(2, num)
                Simplebutton.LookAndFeel.UseDefaultLookAndFeel = False
                Simplebutton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False
                Simplebutton.Size = New Size(341, 30)
                Simplebutton.TabIndex = 36
                Simplebutton.Text = text
                MtkUnlock.SharedUI.UI_Unibrom.Controls.Add(Simplebutton)
                num += 35
                If Equals(command, "BROM") Then
                    AddHandler Simplebutton.Click, AddressOf MtkUnlock.SharedUI.Progress_Command
                ElseIf Equals(command, "SAFE FORMAT") Then
                    AddHandler Simplebutton.Click, AddressOf MtkUnlock.SharedUI.SafeFormat_Command

                End If
            Next
            If Equals(command, "REPAIR") Then
                MtkUnlock.SharedUI.UI_Unibrom.Controls.Add(MtkUnlock.SharedUI.UiMEI)
                MtkUnlock.SharedUI.UiMEI.Dock = DockStyle.Fill
            End If
        End Sub

        Public Class Brandlist
            Public Shared xiaomi As String() = New String() {"READ INFO", "ERASE FRP", "FORMAT DATA", "ERASE MICLOUD"}
            Public Shared listall As String() = New String() {"READ INFO", "ERASE FRP", "FORMAT DATA"}
            Public Shared lisedl As String() = New String() {"READ INFO", "ENABLE BROM", "ERASE FRP", "FORMAT DATA"}
            Public Shared miscpara As String() = New String() {"SAFE FORMAT MISC", "SAFE FORMAT MISC II", "SAFE FORMAT PARA", "SAFE FORMAT PARA II", "VIVO FORMAT SAFE GALERY"}
        End Class
    End Class
End Namespace
