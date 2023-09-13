Imports System
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports DevExpress.XtraEditors
Imports Reverse_Tool.Bismillah.FIREHOSE.FIREHOSE_MANAGER
Imports Reverse_Tool.CryptoOperation
Public Class EDL

    Public Shared Sub exectype(TypeTerpilih As String)
        Try
            Dim webRequest As WebRequest = WebRequest.Create(String.Concat(New String() {datatool, MerkTerpilih.ToUpper(), "/", TypeTerpilih, ".txt"}))
            webRequest.Method = "POST"
            webRequest.ContentType = "application/x-www-form-urlencoded"
            webRequest.Timeout = 10000
            Dim stream As Stream = webRequest.GetRequestStream()
            stream.Close()
            Dim response As WebResponse = webRequest.GetResponse()
            stream = response.GetResponseStream()
            Dim streamReader As New StreamReader(stream)
            Dim num As Integer = 3
            Dim httpWebResponse As HttpWebResponse = CType(webRequest.GetResponse(), HttpWebResponse)
            If httpWebResponse.StatusCode <> HttpStatusCode.OK Then
                MsgBox("server Error " + Conversions.ToString(httpWebResponse.StatusCode), MsgBoxStyle.OkOnly, Nothing)
            Else
                Unlock.SharedUI.TabQCEDL.Controls.Clear()
                While Not streamReader.EndOfStream
                    Dim text As String = streamReader.ReadLine()
                    Dim Simplebutton As New SimpleButton With {
                            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                        }
                    Simplebutton.Appearance.BackColor = Color.FromArgb(64, 64, 64)
                    Simplebutton.Appearance.Font = New Font("Tahoma", 8.25F)
                    Simplebutton.Appearance.Options.UseBackColor = True
                    Simplebutton.Appearance.Options.UseFont = True
                    Simplebutton.Appearance.Options.UseTextOptions = True
                    Simplebutton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    Simplebutton.AppearanceHovered.Font = New Font("Tahoma", 9.25F)
                    Simplebutton.AppearanceHovered.Options.UseFont = True
                    Simplebutton.AppearanceHovered.Options.UseImage = True

                    If Equals(text, "FACTORY RESET") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Factory
                    End If
                    If Equals(text, "FACTORY RESET BY PATCH") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Factory
                    End If
                    If Equals(text, "FACTORY RESET + FRP BY PATCH") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Factory
                    End If
                    If Equals(text, "FACTORY RESET + FRP [EMMC]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Factory
                    End If
                    If Equals(text, "UNLOCK MI AKUN + FRP") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Factory
                    End If
                    If Equals(text, "FACTORY RESET + FRP [UFS]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Factory
                    End If
                    If Equals(text, "FACTORY RESET + FRP") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Factory
                    End If
                    If Equals(text, "FACTORY RESET + FRP [New Patch]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Factory
                    End If
                    If Equals(text, "INSTANN IMEI TO 0 [EMMC]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Safe22px
                    End If
                    If Equals(text, "INSTANN IMEI TO 0") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Safe22px
                    End If
                    If Equals(text, "ERASE FRP") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "RESET FRP") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "RESET FRP BY PATCH") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "RESET FRP [EMMC]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "RESET FRP [UFS]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "RESET EFS") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "RESET EFS [New Patch]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "RESET EFS 2") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "RESET EFS [UFS]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "RESET EFS [EMMC]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Erasefrp
                    End If
                    If Equals(text, "UNLOCK DEMO") Then
                        Simplebutton.ImageOptions.Image = My.Resources.OpenLock
                    End If
                    If Equals(text, "REMOVE DEMO") Then
                        Simplebutton.ImageOptions.Image = My.Resources.OpenLock
                    End If
                    If Equals(text, "UNLOCK BOOTLOADER") Then
                        Simplebutton.ImageOptions.Image = My.Resources.OpenLock
                    End If
                    If Equals(text, "UNLOCK BOOTLOADER II") Then
                        Simplebutton.ImageOptions.Image = My.Resources.OpenLock
                    End If
                    If Equals(text, "UNLOCK BOOTLOADER V2") Then
                        Simplebutton.ImageOptions.Image = My.Resources.OpenLock
                    End If
                    If Equals(text, "RELOCK BOOTLOADER") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Factory
                    End If
                    If Equals(text, "UNLOCK MI CLOUD TAM") Then
                        Simplebutton.ImageOptions.Image = My.Resources.miremof
                    End If
                    If Equals(text, "RESET CLOUD TAM") Then
                        Simplebutton.ImageOptions.Image = My.Resources.miremof
                    End If
                    If Equals(text, "RESET CLOUD DISTRI") Then
                        Simplebutton.ImageOptions.Image = My.Resources.miremof
                    End If
                    If Equals(text, "UNLOCK MI CLOUD TAM BY PATCH") Then
                        Simplebutton.ImageOptions.Image = My.Resources.miremof
                    End If
                    If Equals(text, "UNLOCK MI CLOUD [Tam]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.miremof
                    End If
                    If Equals(text, "DISABLE MI CLOUD [Distri]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.miremof
                    End If
                    If Equals(text, "DISABLE MI CLOUD [BETA]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.miremof
                    End If
                    If Equals(text, "DISABLE MICLOUD[BETA]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.miremof
                    End If
                    If Equals(text, "SAFE FORMAT [Keep Media]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Safe22
                    End If
                    If Equals(text, "SAFE FORMAT [Keep All Data]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Safe22
                    End If
                    If Equals(text, "SAFE FORMAT") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Safe22
                    End If
                    If Equals(text, "SAFE FORMAT [UFS]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Safe22
                    End If
                    If Equals(text, "SAFE FORMAT [EMMC]") Then
                        Simplebutton.ImageOptions.Image = My.Resources.Safe22
                    End If

                    Simplebutton.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
                    Simplebutton.Location = New Point(2, num)
                    Simplebutton.LookAndFeel.UseDefaultLookAndFeel = False
                    Simplebutton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False
                    Simplebutton.Size = New Size(341, 30)
                    Simplebutton.TabIndex = 36
                    Simplebutton.Text = text
                    Unlock.SharedUI.TabQCEDL.Controls.Add(Simplebutton)
                    num += 35

                    AddHandler Simplebutton.Click, AddressOf DoExecOneClick
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
        End Try
    End Sub
    Public Shared Sub DoExecOneClick(sender As Object, e As EventArgs)
        If Not CariportQC.IsBusy Then
            MenuEx = MenuEksekusi.oneclick
            Main.SharedUI.ButtonSTOP.ImageOptions.Image = My.Resources.Stop30
            Watch.Restart()
            Watch.Start()
            Dim str As String = Conversions.ToString(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing))
            RtbClear()
            RichLogs("Operation  : ", Color.White, True, False)
            RichLogs(str, Color.Orange, True, True)
            RichLogs(" Brand     : ", Color.White, True, False)
            RichLogs(MerkTerpilih, Color.DeepSkyBlue, True, True)
            RichLogs(" Devices   :", Color.White, True, False)
            RichLogs(DevicesTerpilih.Replace(MerkTerpilih, ""), Color.DeepSkyBlue, True, True)
            RichLogs(" Model     : ", Color.White, True, False)
            RichLogs(TypeTerpilih, Color.DeepSkyBlue, True, True)
            RichLogs(" Platform  : ", Color.White, True, False)
            RichLogs("Qualcomm", Color.DeepSkyBlue, True, True)
            RichLogs(" Connect   : ", Color.White, True, False)
            RichLogs("Auth", Color.DeepSkyBlue, True, True)
            RichLogs("Dowloading Loader Data" & vbTab & ":  ", Color.White, True, False)
            Dim array As Byte() = Getfile("loader.bin", False)
            OutDecripted = array
            Thread.Sleep(500)
            If Not CryptStream(keyEncrypt, array, False, "loader", 0L) Then
                RichLogs("Failed ", Color.Red, True, True)
            Else
                Dim [string] As String = Encoding.UTF8.GetString(loader.Take(20).ToArray())
                If Not [string].ToUpper().Contains("ELF") Then
                    RichLogs(" Invalid Loader Data", Color.Red, True, True)
                Else
                    RichLogs("Done  ✓ ", Color.Yellow, True, True)
                    RichLogs("Dowloading Support Data" & vbTab & ":  ", Color.White, True, False)
                    Dim array2 As Byte() = Getfile((str + ".xml").Replace(" ", "%20").Replace("+", "%2b"), False)
                    OutDecripted = array2
                    Thread.Sleep(500)
                    If CryptStream(keyEncrypt, array2, False, "xml", 0L) Then
                        If Not StringXml.ToLower().Contains("xml") Then
                            RichLogs("Invalid xml Data", Color.Red, True, True)
                        Else
                            RichLogs("Done  ✓ ", Color.Yellow, True, True)
                            CariportQC.RunWorkerAsync()
                            CariportQC.Dispose()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

End Class
