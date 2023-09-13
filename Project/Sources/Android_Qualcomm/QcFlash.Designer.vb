Imports DevExpress.XtraEditors
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QcFlash
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QcFlash))
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.XtraFlash = New DevExpress.XtraEditors.PanelControl()
        Me.MainTab = New DevExpress.XtraTab.XtraTabControl()
        Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButtonReboot = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelDownload = New DevExpress.XtraEditors.PanelControl()
        Me.CacheBoxAutoCleanUserAccount = New CacheBox()
        Me.CacheBoxAutoFormatData = New CacheBox()
        Me.CekSetBootQC = New CacheBox()
        Me.CekAutoRebootQc = New CacheBox()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboChipQc = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ButtonQc_Idnt = New DevExpress.XtraEditors.SimpleButton()
        Me.panelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Btn_OFPQc = New System.Windows.Forms.Button()
        Me.CheckBoxServer = New CacheBox()
        Me.labelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBoxEditBrand = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ComboBoxEditModels = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ButtonLoader = New System.Windows.Forms.Button()
        Me.labelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtOFPQC = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.TxtFlashLoader = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Btn_BrowseXML = New System.Windows.Forms.Button()
        Me.TxtFlashRawXML = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.ButtonFlashQc = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonQc_ReadP = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonQc_eP = New DevExpress.XtraEditors.SimpleButton()
        Me.xtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.Punif = New DevExpress.XtraEditors.PanelControl()
        Me.ButtonMiReset = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonMiDisable = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonFormatUser = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSAM_FRP_Oem = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonFRP_SAM = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRpmbErase = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonWrNvram = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonAllFRP = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRPMBwrite = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonNvErase = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRelockUBL = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRDrpmb = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonUniNvBackup = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonUBL = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonAuth = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonReadInfo = New DevExpress.XtraEditors.SimpleButton()
        Me.panelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.CheckboxLoaderELF = New CacheBox()
        Me.ButtonELF = New System.Windows.Forms.Button()
        Me.TxtloaderELF = New DevExpress.XtraEditors.TextEdit()
        Me.labelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnGPTread = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonGptWrite = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRebbot = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonReadGPT = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonEraseGPT = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelDg = New DevExpress.XtraEditors.PanelControl()
        Me.CkboxSelectpartitionDataView = New System.Windows.Forms.CheckBox()
        Me.VScrollBarQcFlashDataView = New DevExpress.XtraEditors.VScrollBar()
        Me.HScrollBarQcFlashDataView = New DevExpress.XtraEditors.HScrollBar()
        Me.DataView = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.XtraFlash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraFlash.SuspendLayout()
        CType(Me.MainTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainTab.SuspendLayout()
        Me.xtraTabPage1.SuspendLayout()
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl1.SuspendLayout()
        CType(Me.PanelDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDownload.SuspendLayout()
        CType(Me.ComboChipQc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl7.SuspendLayout()
        CType(Me.ComboBoxEditBrand.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEditModels.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtraTabPage2.SuspendLayout()
        CType(Me.Punif, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Punif.SuspendLayout()
        CType(Me.panelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl5.SuspendLayout()
        CType(Me.TxtloaderELF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelDg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDg.SuspendLayout()
        CType(Me.DataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraFlash
        '
        Me.XtraFlash.Controls.Add(Me.MainTab)
        Me.XtraFlash.Controls.Add(Me.PanelDg)
        Me.XtraFlash.Location = New System.Drawing.Point(0, 0)
        Me.XtraFlash.Name = "XtraFlash"
        Me.XtraFlash.Size = New System.Drawing.Size(653, 482)
        Me.XtraFlash.TabIndex = 2
        '
        'MainTab
        '
        Me.MainTab.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainTab.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTab.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.MainTab.Location = New System.Drawing.Point(2, 285)
        Me.MainTab.MultiLine = DevExpress.Utils.DefaultBoolean.[True]
        Me.MainTab.Name = "MainTab"
        Me.MainTab.SelectedTabPage = Me.xtraTabPage1
        Me.MainTab.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainTab.ShowTabHeader = DevExpress.Utils.DefaultBoolean.[True]
        Me.MainTab.Size = New System.Drawing.Size(649, 195)
        Me.MainTab.TabIndex = 29
        Me.MainTab.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtraTabPage1, Me.xtraTabPage2})
        '
        'xtraTabPage1
        '
        Me.xtraTabPage1.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.xtraTabPage1.Appearance.Header.Options.UseFont = True
        Me.xtraTabPage1.Appearance.Header.Options.UseTextOptions = True
        Me.xtraTabPage1.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.xtraTabPage1.Controls.Add(Me.panelControl1)
        Me.xtraTabPage1.Name = "xtraTabPage1"
        Me.xtraTabPage1.Size = New System.Drawing.Size(627, 193)
        Me.xtraTabPage1.Text = "FLASH"
        '
        'panelControl1
        '
        Me.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl1.Controls.Add(Me.SimpleButtonReboot)
        Me.panelControl1.Controls.Add(Me.PanelDownload)
        Me.panelControl1.Controls.Add(Me.ButtonQc_Idnt)
        Me.panelControl1.Controls.Add(Me.panelControl7)
        Me.panelControl1.Controls.Add(Me.ButtonFlashQc)
        Me.panelControl1.Controls.Add(Me.ButtonQc_ReadP)
        Me.panelControl1.Controls.Add(Me.ButtonQc_eP)
        Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelControl1.Location = New System.Drawing.Point(0, 0)
        Me.panelControl1.Name = "panelControl1"
        Me.panelControl1.Size = New System.Drawing.Size(627, 193)
        Me.panelControl1.TabIndex = 0
        '
        'SimpleButtonReboot
        '
        Me.SimpleButtonReboot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButtonReboot.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SimpleButtonReboot.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.SimpleButtonReboot.Appearance.Options.UseBackColor = True
        Me.SimpleButtonReboot.Appearance.Options.UseFont = True
        Me.SimpleButtonReboot.Appearance.Options.UseTextOptions = True
        Me.SimpleButtonReboot.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButtonReboot.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.SimpleButtonReboot.AppearanceHovered.Options.UseFont = True
        Me.SimpleButtonReboot.AppearanceHovered.Options.UseImage = True
        Me.SimpleButtonReboot.ImageOptions.Image = CType(resources.GetObject("SimpleButtonReboot.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButtonReboot.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.SimpleButtonReboot.Location = New System.Drawing.Point(406, 43)
        Me.SimpleButtonReboot.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButtonReboot.Name = "SimpleButtonReboot"
        Me.SimpleButtonReboot.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.SimpleButtonReboot.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.SimpleButtonReboot.Size = New System.Drawing.Size(75, 28)
        Me.SimpleButtonReboot.TabIndex = 36
        Me.SimpleButtonReboot.Text = "REBOOT"
        '
        'PanelDownload
        '
        Me.PanelDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDownload.Controls.Add(Me.CacheBoxAutoCleanUserAccount)
        Me.PanelDownload.Controls.Add(Me.CacheBoxAutoFormatData)
        Me.PanelDownload.Controls.Add(Me.CekSetBootQC)
        Me.PanelDownload.Controls.Add(Me.CekAutoRebootQc)
        Me.PanelDownload.Controls.Add(Me.labelControl2)
        Me.PanelDownload.Controls.Add(Me.ComboChipQc)
        Me.PanelDownload.Location = New System.Drawing.Point(5, 4)
        Me.PanelDownload.Name = "PanelDownload"
        Me.PanelDownload.Size = New System.Drawing.Size(619, 33)
        Me.PanelDownload.TabIndex = 2
        '
        'CacheBoxAutoCleanUserAccount
        '
        Me.CacheBoxAutoCleanUserAccount.AutoSize = True
        Me.CacheBoxAutoCleanUserAccount.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CacheBoxAutoCleanUserAccount.CheckedColor = System.Drawing.Color.Red
        Me.CacheBoxAutoCleanUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CacheBoxAutoCleanUserAccount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CacheBoxAutoCleanUserAccount.Location = New System.Drawing.Point(142, 5)
        Me.CacheBoxAutoCleanUserAccount.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CacheBoxAutoCleanUserAccount.Name = "CacheBoxAutoCleanUserAccount"
        Me.CacheBoxAutoCleanUserAccount.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CacheBoxAutoCleanUserAccount.Size = New System.Drawing.Size(153, 21)
        Me.CacheBoxAutoCleanUserAccount.TabIndex = 41
        Me.CacheBoxAutoCleanUserAccount.Text = "Auto Clean User Account"
        Me.CacheBoxAutoCleanUserAccount.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CacheBoxAutoCleanUserAccount.UseVisualStyleBackColor = False
        '
        'CacheBoxAutoFormatData
        '
        Me.CacheBoxAutoFormatData.AutoSize = True
        Me.CacheBoxAutoFormatData.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CacheBoxAutoFormatData.CheckedColor = System.Drawing.Color.Red
        Me.CacheBoxAutoFormatData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CacheBoxAutoFormatData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CacheBoxAutoFormatData.Location = New System.Drawing.Point(3, 5)
        Me.CacheBoxAutoFormatData.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CacheBoxAutoFormatData.Name = "CacheBoxAutoFormatData"
        Me.CacheBoxAutoFormatData.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CacheBoxAutoFormatData.Size = New System.Drawing.Size(133, 21)
        Me.CacheBoxAutoFormatData.TabIndex = 37
        Me.CacheBoxAutoFormatData.Text = "Auto Clean Userdata"
        Me.CacheBoxAutoFormatData.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CacheBoxAutoFormatData.UseVisualStyleBackColor = False
        '
        'CekSetBootQC
        '
        Me.CekSetBootQC.AutoSize = True
        Me.CekSetBootQC.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CekSetBootQC.CheckedColor = System.Drawing.Color.Red
        Me.CekSetBootQC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CekSetBootQC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CekSetBootQC.Location = New System.Drawing.Point(401, 5)
        Me.CekSetBootQC.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CekSetBootQC.Name = "CekSetBootQC"
        Me.CekSetBootQC.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CekSetBootQC.Size = New System.Drawing.Size(108, 21)
        Me.CekSetBootQC.TabIndex = 34
        Me.CekSetBootQC.Text = "Set Boot Config"
        Me.CekSetBootQC.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CekSetBootQC.UseVisualStyleBackColor = False
        '
        'CekAutoRebootQc
        '
        Me.CekAutoRebootQc.AutoSize = True
        Me.CekAutoRebootQc.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CekAutoRebootQc.CheckedColor = System.Drawing.Color.Red
        Me.CekAutoRebootQc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CekAutoRebootQc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CekAutoRebootQc.Location = New System.Drawing.Point(301, 5)
        Me.CekAutoRebootQc.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CekAutoRebootQc.Name = "CekAutoRebootQc"
        Me.CekAutoRebootQc.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CekAutoRebootQc.Size = New System.Drawing.Size(94, 21)
        Me.CekAutoRebootQc.TabIndex = 35
        Me.CekAutoRebootQc.Text = "Auto Reboot"
        Me.CekAutoRebootQc.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CekAutoRebootQc.UseVisualStyleBackColor = False
        '
        'labelControl2
        '
        Me.labelControl2.Location = New System.Drawing.Point(514, 9)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(33, 13)
        Me.labelControl2.TabIndex = 26
        Me.labelControl2.Text = "Layout"
        '
        'ComboChipQc
        '
        Me.ComboChipQc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboChipQc.EditValue = "eMMC"
        Me.ComboChipQc.Location = New System.Drawing.Point(553, 6)
        Me.ComboChipQc.Name = "ComboChipQc"
        Me.ComboChipQc.Properties.AllowFocused = False
        Me.ComboChipQc.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboChipQc.Properties.Appearance.BorderColor = System.Drawing.Color.DarkRed
        Me.ComboChipQc.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.ComboChipQc.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboChipQc.Properties.Appearance.Options.UseBackColor = True
        Me.ComboChipQc.Properties.Appearance.Options.UseBorderColor = True
        Me.ComboChipQc.Properties.Appearance.Options.UseFont = True
        Me.ComboChipQc.Properties.Appearance.Options.UseForeColor = True
        Me.ComboChipQc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboChipQc.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ComboChipQc.Properties.Items.AddRange(New Object() {"eMMC", "UFS"})
        Me.ComboChipQc.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboChipQc.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboChipQc.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboChipQc.Size = New System.Drawing.Size(59, 20)
        Me.ComboChipQc.TabIndex = 22
        '
        'ButtonQc_Idnt
        '
        Me.ButtonQc_Idnt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonQc_Idnt.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonQc_Idnt.Appearance.Options.UseBackColor = True
        Me.ButtonQc_Idnt.Appearance.Options.UseTextOptions = True
        Me.ButtonQc_Idnt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonQc_Idnt.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonQc_Idnt.AppearanceHovered.Options.UseFont = True
        Me.ButtonQc_Idnt.AppearanceHovered.Options.UseImage = True
        Me.ButtonQc_Idnt.ImageOptions.Image = CType(resources.GetObject("ButtonQc_Idnt.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonQc_Idnt.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonQc_Idnt.Location = New System.Drawing.Point(60, 43)
        Me.ButtonQc_Idnt.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonQc_Idnt.Name = "ButtonQc_Idnt"
        Me.ButtonQc_Idnt.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonQc_Idnt.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonQc_Idnt.Size = New System.Drawing.Size(83, 28)
        Me.ButtonQc_Idnt.TabIndex = 28
        Me.ButtonQc_Idnt.Text = "READ GPT"
        '
        'panelControl7
        '
        Me.panelControl7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelControl7.Controls.Add(Me.LabelControl1)
        Me.panelControl7.Controls.Add(Me.Btn_OFPQc)
        Me.panelControl7.Controls.Add(Me.CheckBoxServer)
        Me.panelControl7.Controls.Add(Me.labelControl11)
        Me.panelControl7.Controls.Add(Me.ComboBoxEditBrand)
        Me.panelControl7.Controls.Add(Me.ComboBoxEditModels)
        Me.panelControl7.Controls.Add(Me.ButtonLoader)
        Me.panelControl7.Controls.Add(Me.labelControl9)
        Me.panelControl7.Controls.Add(Me.labelControl10)
        Me.panelControl7.Controls.Add(Me.TxtOFPQC)
        Me.panelControl7.Controls.Add(Me.TxtFlashLoader)
        Me.panelControl7.Controls.Add(Me.Btn_BrowseXML)
        Me.panelControl7.Controls.Add(Me.TxtFlashRawXML)
        Me.panelControl7.Location = New System.Drawing.Point(5, 77)
        Me.panelControl7.Name = "panelControl7"
        Me.panelControl7.Size = New System.Drawing.Size(619, 103)
        Me.panelControl7.TabIndex = 27
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl1.TabIndex = 44
        Me.LabelControl1.Text = "Select Loader"
        '
        'Btn_OFPQc
        '
        Me.Btn_OFPQc.BackColor = System.Drawing.Color.Transparent
        Me.Btn_OFPQc.FlatAppearance.BorderSize = 0
        Me.Btn_OFPQc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_OFPQc.Image = CType(resources.GetObject("Btn_OFPQc.Image"), System.Drawing.Image)
        Me.Btn_OFPQc.Location = New System.Drawing.Point(567, 83)
        Me.Btn_OFPQc.Name = "Btn_OFPQc"
        Me.Btn_OFPQc.Size = New System.Drawing.Size(23, 13)
        Me.Btn_OFPQc.TabIndex = 41
        Me.Btn_OFPQc.UseVisualStyleBackColor = False
        '
        'CheckBoxServer
        '
        Me.CheckBoxServer.AutoSize = True
        Me.CheckBoxServer.CheckedColor = System.Drawing.Color.Red
        Me.CheckBoxServer.Location = New System.Drawing.Point(537, 6)
        Me.CheckBoxServer.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CheckBoxServer.Name = "CheckBoxServer"
        Me.CheckBoxServer.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CheckBoxServer.Size = New System.Drawing.Size(68, 21)
        Me.CheckBoxServer.TabIndex = 39
        Me.CheckBoxServer.Text = "Server"
        Me.CheckBoxServer.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CheckBoxServer.UseVisualStyleBackColor = True
        '
        'labelControl11
        '
        Me.labelControl11.Location = New System.Drawing.Point(22, 61)
        Me.labelControl11.Name = "labelControl11"
        Me.labelControl11.Size = New System.Drawing.Size(57, 13)
        Me.labelControl11.TabIndex = 37
        Me.labelControl11.Text = "Browse XML"
        '
        'ComboBoxEditBrand
        '
        Me.ComboBoxEditBrand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEditBrand.EditValue = ""
        Me.ComboBoxEditBrand.Location = New System.Drawing.Point(106, 6)
        Me.ComboBoxEditBrand.Name = "ComboBoxEditBrand"
        Me.ComboBoxEditBrand.Properties.AllowFocused = False
        Me.ComboBoxEditBrand.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ComboBoxEditBrand.Properties.Appearance.BorderColor = System.Drawing.Color.DarkRed
        Me.ComboBoxEditBrand.Properties.Appearance.Options.UseBackColor = True
        Me.ComboBoxEditBrand.Properties.Appearance.Options.UseBorderColor = True
        Me.ComboBoxEditBrand.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEditBrand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ComboBoxEditBrand.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboBoxEditBrand.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboBoxEditBrand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEditBrand.Size = New System.Drawing.Size(206, 20)
        Me.ComboBoxEditBrand.TabIndex = 30
        '
        'ComboBoxEditModels
        '
        Me.ComboBoxEditModels.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEditModels.EditValue = ""
        Me.ComboBoxEditModels.Location = New System.Drawing.Point(317, 6)
        Me.ComboBoxEditModels.Name = "ComboBoxEditModels"
        Me.ComboBoxEditModels.Properties.AllowFocused = False
        Me.ComboBoxEditModels.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ComboBoxEditModels.Properties.Appearance.BorderColor = System.Drawing.Color.DarkRed
        Me.ComboBoxEditModels.Properties.Appearance.Options.UseBackColor = True
        Me.ComboBoxEditModels.Properties.Appearance.Options.UseBorderColor = True
        Me.ComboBoxEditModels.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEditModels.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ComboBoxEditModels.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboBoxEditModels.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboBoxEditModels.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxEditModels.Size = New System.Drawing.Size(206, 20)
        Me.ComboBoxEditModels.TabIndex = 29
        '
        'ButtonLoader
        '
        Me.ButtonLoader.BackColor = System.Drawing.Color.Transparent
        Me.ButtonLoader.FlatAppearance.BorderSize = 0
        Me.ButtonLoader.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLoader.Image = CType(resources.GetObject("ButtonLoader.Image"), System.Drawing.Image)
        Me.ButtonLoader.Location = New System.Drawing.Point(567, 37)
        Me.ButtonLoader.Name = "ButtonLoader"
        Me.ButtonLoader.Size = New System.Drawing.Size(23, 13)
        Me.ButtonLoader.TabIndex = 29
        Me.ButtonLoader.UseVisualStyleBackColor = False
        '
        'labelControl9
        '
        Me.labelControl9.Location = New System.Drawing.Point(22, 37)
        Me.labelControl9.Name = "labelControl9"
        Me.labelControl9.Size = New System.Drawing.Size(60, 13)
        Me.labelControl9.TabIndex = 24
        Me.labelControl9.Text = "Loader | ELF"
        '
        'labelControl10
        '
        Me.labelControl10.Location = New System.Drawing.Point(22, 85)
        Me.labelControl10.Name = "labelControl10"
        Me.labelControl10.Size = New System.Drawing.Size(58, 13)
        Me.labelControl10.TabIndex = 23
        Me.labelControl10.Text = "Browse OFP"
        '
        'TxtOFPQC
        '
        Me.TxtOFPQC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtOFPQC.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtOFPQC.ForeColor = System.Drawing.Color.White
        Me.TxtOFPQC.HintForeColor = System.Drawing.Color.Empty
        Me.TxtOFPQC.HintText = ""
        Me.TxtOFPQC.isPassword = False
        Me.TxtOFPQC.LineFocusedColor = System.Drawing.Color.Red
        Me.TxtOFPQC.LineIdleColor = System.Drawing.Color.DarkRed
        Me.TxtOFPQC.LineMouseHoverColor = System.Drawing.Color.Red
        Me.TxtOFPQC.LineThickness = 2
        Me.TxtOFPQC.Location = New System.Drawing.Point(106, 75)
        Me.TxtOFPQC.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtOFPQC.Name = "TxtOFPQC"
        Me.TxtOFPQC.Size = New System.Drawing.Size(484, 24)
        Me.TxtOFPQC.TabIndex = 42
        Me.TxtOFPQC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'TxtFlashLoader
        '
        Me.TxtFlashLoader.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtFlashLoader.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtFlashLoader.ForeColor = System.Drawing.Color.White
        Me.TxtFlashLoader.HintForeColor = System.Drawing.Color.Empty
        Me.TxtFlashLoader.HintText = ""
        Me.TxtFlashLoader.isPassword = False
        Me.TxtFlashLoader.LineFocusedColor = System.Drawing.Color.Red
        Me.TxtFlashLoader.LineIdleColor = System.Drawing.Color.DarkRed
        Me.TxtFlashLoader.LineMouseHoverColor = System.Drawing.Color.Red
        Me.TxtFlashLoader.LineThickness = 2
        Me.TxtFlashLoader.Location = New System.Drawing.Point(106, 27)
        Me.TxtFlashLoader.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFlashLoader.Name = "TxtFlashLoader"
        Me.TxtFlashLoader.Size = New System.Drawing.Size(484, 24)
        Me.TxtFlashLoader.TabIndex = 43
        Me.TxtFlashLoader.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Btn_BrowseXML
        '
        Me.Btn_BrowseXML.BackColor = System.Drawing.Color.Transparent
        Me.Btn_BrowseXML.FlatAppearance.BorderSize = 0
        Me.Btn_BrowseXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_BrowseXML.Image = CType(resources.GetObject("Btn_BrowseXML.Image"), System.Drawing.Image)
        Me.Btn_BrowseXML.Location = New System.Drawing.Point(567, 58)
        Me.Btn_BrowseXML.Name = "Btn_BrowseXML"
        Me.Btn_BrowseXML.Size = New System.Drawing.Size(23, 13)
        Me.Btn_BrowseXML.TabIndex = 42
        Me.Btn_BrowseXML.UseVisualStyleBackColor = False
        '
        'TxtFlashRawXML
        '
        Me.TxtFlashRawXML.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtFlashRawXML.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtFlashRawXML.ForeColor = System.Drawing.Color.White
        Me.TxtFlashRawXML.HintForeColor = System.Drawing.Color.Empty
        Me.TxtFlashRawXML.HintText = ""
        Me.TxtFlashRawXML.isPassword = False
        Me.TxtFlashRawXML.LineFocusedColor = System.Drawing.Color.Red
        Me.TxtFlashRawXML.LineIdleColor = System.Drawing.Color.DarkRed
        Me.TxtFlashRawXML.LineMouseHoverColor = System.Drawing.Color.Red
        Me.TxtFlashRawXML.LineThickness = 2
        Me.TxtFlashRawXML.Location = New System.Drawing.Point(106, 52)
        Me.TxtFlashRawXML.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFlashRawXML.Name = "TxtFlashRawXML"
        Me.TxtFlashRawXML.Size = New System.Drawing.Size(484, 24)
        Me.TxtFlashRawXML.TabIndex = 43
        Me.TxtFlashRawXML.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'ButtonFlashQc
        '
        Me.ButtonFlashQc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFlashQc.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonFlashQc.Appearance.Options.UseBackColor = True
        Me.ButtonFlashQc.Appearance.Options.UseTextOptions = True
        Me.ButtonFlashQc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonFlashQc.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonFlashQc.AppearanceHovered.Options.UseFont = True
        Me.ButtonFlashQc.AppearanceHovered.Options.UseImage = True
        Me.ButtonFlashQc.ImageOptions.Image = CType(resources.GetObject("ButtonFlashQc.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonFlashQc.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonFlashQc.Location = New System.Drawing.Point(487, 43)
        Me.ButtonFlashQc.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonFlashQc.Name = "ButtonFlashQc"
        Me.ButtonFlashQc.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonFlashQc.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonFlashQc.Size = New System.Drawing.Size(68, 28)
        Me.ButtonFlashQc.TabIndex = 28
        Me.ButtonFlashQc.Text = "FLASH"
        '
        'ButtonQc_ReadP
        '
        Me.ButtonQc_ReadP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonQc_ReadP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonQc_ReadP.Appearance.Options.UseBackColor = True
        Me.ButtonQc_ReadP.Appearance.Options.UseTextOptions = True
        Me.ButtonQc_ReadP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonQc_ReadP.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonQc_ReadP.AppearanceHovered.Options.UseFont = True
        Me.ButtonQc_ReadP.AppearanceHovered.Options.UseImage = True
        Me.ButtonQc_ReadP.ImageOptions.Image = CType(resources.GetObject("ButtonQc_ReadP.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonQc_ReadP.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonQc_ReadP.Location = New System.Drawing.Point(149, 43)
        Me.ButtonQc_ReadP.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonQc_ReadP.Name = "ButtonQc_ReadP"
        Me.ButtonQc_ReadP.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonQc_ReadP.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonQc_ReadP.Size = New System.Drawing.Size(118, 28)
        Me.ButtonQc_ReadP.TabIndex = 28
        Me.ButtonQc_ReadP.Text = "READ PARTITION"
        '
        'ButtonQc_eP
        '
        Me.ButtonQc_eP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonQc_eP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonQc_eP.Appearance.Options.UseBackColor = True
        Me.ButtonQc_eP.Appearance.Options.UseTextOptions = True
        Me.ButtonQc_eP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonQc_eP.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonQc_eP.AppearanceHovered.Options.UseFont = True
        Me.ButtonQc_eP.AppearanceHovered.Options.UseImage = True
        Me.ButtonQc_eP.ImageOptions.Image = CType(resources.GetObject("ButtonQc_eP.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonQc_eP.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonQc_eP.Location = New System.Drawing.Point(282, 43)
        Me.ButtonQc_eP.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonQc_eP.Name = "ButtonQc_eP"
        Me.ButtonQc_eP.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonQc_eP.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonQc_eP.Size = New System.Drawing.Size(118, 28)
        Me.ButtonQc_eP.TabIndex = 28
        Me.ButtonQc_eP.Text = "ERASE PARTITION"
        '
        'xtraTabPage2
        '
        Me.xtraTabPage2.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.xtraTabPage2.Appearance.Header.Options.UseFont = True
        Me.xtraTabPage2.Appearance.Header.Options.UseTextOptions = True
        Me.xtraTabPage2.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.xtraTabPage2.Controls.Add(Me.Punif)
        Me.xtraTabPage2.Name = "xtraTabPage2"
        Me.xtraTabPage2.Size = New System.Drawing.Size(627, 193)
        Me.xtraTabPage2.Text = "UNIVER"
        '
        'Punif
        '
        Me.Punif.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Punif.Controls.Add(Me.ButtonMiReset)
        Me.Punif.Controls.Add(Me.ButtonMiDisable)
        Me.Punif.Controls.Add(Me.ButtonFormatUser)
        Me.Punif.Controls.Add(Me.BtnSAM_FRP_Oem)
        Me.Punif.Controls.Add(Me.ButtonFRP_SAM)
        Me.Punif.Controls.Add(Me.ButtonRpmbErase)
        Me.Punif.Controls.Add(Me.ButtonWrNvram)
        Me.Punif.Controls.Add(Me.ButtonAllFRP)
        Me.Punif.Controls.Add(Me.ButtonRPMBwrite)
        Me.Punif.Controls.Add(Me.ButtonNvErase)
        Me.Punif.Controls.Add(Me.ButtonRelockUBL)
        Me.Punif.Controls.Add(Me.ButtonRDrpmb)
        Me.Punif.Controls.Add(Me.ButtonUniNvBackup)
        Me.Punif.Controls.Add(Me.ButtonUBL)
        Me.Punif.Controls.Add(Me.ButtonAuth)
        Me.Punif.Controls.Add(Me.ButtonReadInfo)
        Me.Punif.Controls.Add(Me.panelControl5)
        Me.Punif.Controls.Add(Me.BtnGPTread)
        Me.Punif.Controls.Add(Me.ButtonGptWrite)
        Me.Punif.Controls.Add(Me.ButtonRebbot)
        Me.Punif.Controls.Add(Me.ButtonReadGPT)
        Me.Punif.Controls.Add(Me.ButtonEraseGPT)
        Me.Punif.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Punif.Location = New System.Drawing.Point(0, 0)
        Me.Punif.Name = "Punif"
        Me.Punif.Size = New System.Drawing.Size(627, 193)
        Me.Punif.TabIndex = 0
        '
        'ButtonMiReset
        '
        Me.ButtonMiReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMiReset.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonMiReset.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonMiReset.Appearance.Options.UseBackColor = True
        Me.ButtonMiReset.Appearance.Options.UseFont = True
        Me.ButtonMiReset.Appearance.Options.UseTextOptions = True
        Me.ButtonMiReset.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonMiReset.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonMiReset.AppearanceHovered.Options.UseFont = True
        Me.ButtonMiReset.AppearanceHovered.Options.UseImage = True
        Me.ButtonMiReset.ImageOptions.Image = CType(resources.GetObject("ButtonMiReset.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonMiReset.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonMiReset.Location = New System.Drawing.Point(473, 135)
        Me.ButtonMiReset.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonMiReset.Name = "ButtonMiReset"
        Me.ButtonMiReset.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonMiReset.Size = New System.Drawing.Size(150, 25)
        Me.ButtonMiReset.TabIndex = 46
        Me.ButtonMiReset.Text = "RESET MiCLOUD"
        '
        'ButtonMiDisable
        '
        Me.ButtonMiDisable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMiDisable.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonMiDisable.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonMiDisable.Appearance.Options.UseBackColor = True
        Me.ButtonMiDisable.Appearance.Options.UseFont = True
        Me.ButtonMiDisable.Appearance.Options.UseTextOptions = True
        Me.ButtonMiDisable.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonMiDisable.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonMiDisable.AppearanceHovered.Options.UseFont = True
        Me.ButtonMiDisable.AppearanceHovered.Options.UseImage = True
        Me.ButtonMiDisable.ImageOptions.Image = CType(resources.GetObject("ButtonMiDisable.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonMiDisable.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonMiDisable.Location = New System.Drawing.Point(473, 164)
        Me.ButtonMiDisable.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonMiDisable.Name = "ButtonMiDisable"
        Me.ButtonMiDisable.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonMiDisable.Size = New System.Drawing.Size(150, 25)
        Me.ButtonMiDisable.TabIndex = 47
        Me.ButtonMiDisable.Text = "DISABLE MiCLOUD"
        '
        'ButtonFormatUser
        '
        Me.ButtonFormatUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFormatUser.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonFormatUser.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonFormatUser.Appearance.Options.UseBackColor = True
        Me.ButtonFormatUser.Appearance.Options.UseFont = True
        Me.ButtonFormatUser.Appearance.Options.UseTextOptions = True
        Me.ButtonFormatUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonFormatUser.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonFormatUser.AppearanceHovered.Options.UseFont = True
        Me.ButtonFormatUser.AppearanceHovered.Options.UseImage = True
        Me.ButtonFormatUser.ImageOptions.Image = CType(resources.GetObject("ButtonFormatUser.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonFormatUser.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonFormatUser.Location = New System.Drawing.Point(473, 105)
        Me.ButtonFormatUser.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonFormatUser.Name = "ButtonFormatUser"
        Me.ButtonFormatUser.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonFormatUser.Size = New System.Drawing.Size(150, 25)
        Me.ButtonFormatUser.TabIndex = 48
        Me.ButtonFormatUser.Text = "FORMAT DATA"
        '
        'BtnSAM_FRP_Oem
        '
        Me.BtnSAM_FRP_Oem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSAM_FRP_Oem.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.BtnSAM_FRP_Oem.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.BtnSAM_FRP_Oem.Appearance.Options.UseBackColor = True
        Me.BtnSAM_FRP_Oem.Appearance.Options.UseFont = True
        Me.BtnSAM_FRP_Oem.Appearance.Options.UseTextOptions = True
        Me.BtnSAM_FRP_Oem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.BtnSAM_FRP_Oem.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.BtnSAM_FRP_Oem.AppearanceHovered.Options.UseFont = True
        Me.BtnSAM_FRP_Oem.AppearanceHovered.Options.UseImage = True
        Me.BtnSAM_FRP_Oem.ImageOptions.Image = CType(resources.GetObject("ButtonFormatUser.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSAM_FRP_Oem.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.BtnSAM_FRP_Oem.Location = New System.Drawing.Point(473, 75)
        Me.BtnSAM_FRP_Oem.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSAM_FRP_Oem.Name = "BtnSAM_FRP_Oem"
        Me.BtnSAM_FRP_Oem.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.BtnSAM_FRP_Oem.Size = New System.Drawing.Size(150, 25)
        Me.BtnSAM_FRP_Oem.TabIndex = 49
        Me.BtnSAM_FRP_Oem.Text = "FORMAT DATA SAFE"
        '
        'ButtonFRP_SAM
        '
        Me.ButtonFRP_SAM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFRP_SAM.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonFRP_SAM.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonFRP_SAM.Appearance.Options.UseBackColor = True
        Me.ButtonFRP_SAM.Appearance.Options.UseFont = True
        Me.ButtonFRP_SAM.Appearance.Options.UseTextOptions = True
        Me.ButtonFRP_SAM.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonFRP_SAM.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonFRP_SAM.AppearanceHovered.Options.UseFont = True
        Me.ButtonFRP_SAM.AppearanceHovered.Options.UseImage = True
        Me.ButtonFRP_SAM.ImageOptions.Image = CType(resources.GetObject("ButtonFRP_SAM.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonFRP_SAM.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonFRP_SAM.Location = New System.Drawing.Point(317, 164)
        Me.ButtonFRP_SAM.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonFRP_SAM.Name = "ButtonFRP_SAM"
        Me.ButtonFRP_SAM.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonFRP_SAM.Size = New System.Drawing.Size(150, 25)
        Me.ButtonFRP_SAM.TabIndex = 50
        Me.ButtonFRP_SAM.Text = "ERASE FRP SAMSUNG"
        '
        'ButtonRpmbErase
        '
        Me.ButtonRpmbErase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRpmbErase.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonRpmbErase.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonRpmbErase.Appearance.Options.UseBackColor = True
        Me.ButtonRpmbErase.Appearance.Options.UseFont = True
        Me.ButtonRpmbErase.Appearance.Options.UseTextOptions = True
        Me.ButtonRpmbErase.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRpmbErase.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonRpmbErase.AppearanceHovered.Options.UseFont = True
        Me.ButtonRpmbErase.AppearanceHovered.Options.UseImage = True
        Me.ButtonRpmbErase.ImageOptions.Image = CType(resources.GetObject("ButtonRpmbErase.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonRpmbErase.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonRpmbErase.Location = New System.Drawing.Point(161, 164)
        Me.ButtonRpmbErase.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRpmbErase.Name = "ButtonRpmbErase"
        Me.ButtonRpmbErase.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRpmbErase.Size = New System.Drawing.Size(150, 25)
        Me.ButtonRpmbErase.TabIndex = 51
        Me.ButtonRpmbErase.Text = "ERASE RPMB"
        '
        'ButtonWrNvram
        '
        Me.ButtonWrNvram.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonWrNvram.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonWrNvram.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonWrNvram.Appearance.Options.UseBackColor = True
        Me.ButtonWrNvram.Appearance.Options.UseFont = True
        Me.ButtonWrNvram.Appearance.Options.UseTextOptions = True
        Me.ButtonWrNvram.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonWrNvram.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonWrNvram.AppearanceHovered.Options.UseFont = True
        Me.ButtonWrNvram.AppearanceHovered.Options.UseImage = True
        Me.ButtonWrNvram.ImageOptions.Image = CType(resources.GetObject("ButtonWrNvram.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonWrNvram.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonWrNvram.Location = New System.Drawing.Point(5, 164)
        Me.ButtonWrNvram.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonWrNvram.Name = "ButtonWrNvram"
        Me.ButtonWrNvram.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonWrNvram.Size = New System.Drawing.Size(150, 25)
        Me.ButtonWrNvram.TabIndex = 52
        Me.ButtonWrNvram.Text = "RESTORE NV"
        '
        'ButtonAllFRP
        '
        Me.ButtonAllFRP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAllFRP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonAllFRP.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonAllFRP.Appearance.Options.UseBackColor = True
        Me.ButtonAllFRP.Appearance.Options.UseFont = True
        Me.ButtonAllFRP.Appearance.Options.UseTextOptions = True
        Me.ButtonAllFRP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonAllFRP.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonAllFRP.AppearanceHovered.Options.UseFont = True
        Me.ButtonAllFRP.AppearanceHovered.Options.UseImage = True
        Me.ButtonAllFRP.ImageOptions.Image = CType(resources.GetObject("ButtonAllFRP.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonAllFRP.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonAllFRP.Location = New System.Drawing.Point(317, 135)
        Me.ButtonAllFRP.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonAllFRP.Name = "ButtonAllFRP"
        Me.ButtonAllFRP.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonAllFRP.Size = New System.Drawing.Size(150, 25)
        Me.ButtonAllFRP.TabIndex = 53
        Me.ButtonAllFRP.Text = "ERASE FRP"
        '
        'ButtonRPMBwrite
        '
        Me.ButtonRPMBwrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRPMBwrite.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonRPMBwrite.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonRPMBwrite.Appearance.Options.UseBackColor = True
        Me.ButtonRPMBwrite.Appearance.Options.UseFont = True
        Me.ButtonRPMBwrite.Appearance.Options.UseTextOptions = True
        Me.ButtonRPMBwrite.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRPMBwrite.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonRPMBwrite.AppearanceHovered.Options.UseFont = True
        Me.ButtonRPMBwrite.AppearanceHovered.Options.UseImage = True
        Me.ButtonRPMBwrite.ImageOptions.Image = CType(resources.GetObject("ButtonRPMBwrite.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonRPMBwrite.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonRPMBwrite.Location = New System.Drawing.Point(161, 135)
        Me.ButtonRPMBwrite.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRPMBwrite.Name = "ButtonRPMBwrite"
        Me.ButtonRPMBwrite.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRPMBwrite.Size = New System.Drawing.Size(150, 25)
        Me.ButtonRPMBwrite.TabIndex = 54
        Me.ButtonRPMBwrite.Text = "WRITE RPMB"
        '
        'ButtonNvErase
        '
        Me.ButtonNvErase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonNvErase.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonNvErase.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonNvErase.Appearance.Options.UseBackColor = True
        Me.ButtonNvErase.Appearance.Options.UseFont = True
        Me.ButtonNvErase.Appearance.Options.UseTextOptions = True
        Me.ButtonNvErase.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonNvErase.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonNvErase.AppearanceHovered.Options.UseFont = True
        Me.ButtonNvErase.AppearanceHovered.Options.UseImage = True
        Me.ButtonNvErase.ImageOptions.Image = CType(resources.GetObject("ButtonNvErase.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonNvErase.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonNvErase.Location = New System.Drawing.Point(5, 135)
        Me.ButtonNvErase.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonNvErase.Name = "ButtonNvErase"
        Me.ButtonNvErase.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonNvErase.Size = New System.Drawing.Size(150, 25)
        Me.ButtonNvErase.TabIndex = 55
        Me.ButtonNvErase.Text = "ERASE NV"
        '
        'ButtonRelockUBL
        '
        Me.ButtonRelockUBL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRelockUBL.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonRelockUBL.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonRelockUBL.Appearance.Options.UseBackColor = True
        Me.ButtonRelockUBL.Appearance.Options.UseFont = True
        Me.ButtonRelockUBL.Appearance.Options.UseTextOptions = True
        Me.ButtonRelockUBL.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRelockUBL.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonRelockUBL.AppearanceHovered.Options.UseFont = True
        Me.ButtonRelockUBL.AppearanceHovered.Options.UseImage = True
        Me.ButtonRelockUBL.ImageOptions.Image = CType(resources.GetObject("ButtonRelockUBL.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonRelockUBL.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonRelockUBL.Location = New System.Drawing.Point(317, 105)
        Me.ButtonRelockUBL.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRelockUBL.Name = "ButtonRelockUBL"
        Me.ButtonRelockUBL.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRelockUBL.Size = New System.Drawing.Size(150, 25)
        Me.ButtonRelockUBL.TabIndex = 43
        Me.ButtonRelockUBL.Text = "RELOCK BOOTLOADER"
        '
        'ButtonRDrpmb
        '
        Me.ButtonRDrpmb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRDrpmb.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonRDrpmb.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonRDrpmb.Appearance.Options.UseBackColor = True
        Me.ButtonRDrpmb.Appearance.Options.UseFont = True
        Me.ButtonRDrpmb.Appearance.Options.UseTextOptions = True
        Me.ButtonRDrpmb.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRDrpmb.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonRDrpmb.AppearanceHovered.Options.UseFont = True
        Me.ButtonRDrpmb.AppearanceHovered.Options.UseImage = True
        Me.ButtonRDrpmb.ImageOptions.Image = CType(resources.GetObject("ButtonRDrpmb.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonRDrpmb.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonRDrpmb.Location = New System.Drawing.Point(161, 105)
        Me.ButtonRDrpmb.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRDrpmb.Name = "ButtonRDrpmb"
        Me.ButtonRDrpmb.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRDrpmb.Size = New System.Drawing.Size(150, 25)
        Me.ButtonRDrpmb.TabIndex = 44
        Me.ButtonRDrpmb.Text = "READ RPMB"
        '
        'ButtonUniNvBackup
        '
        Me.ButtonUniNvBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUniNvBackup.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonUniNvBackup.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonUniNvBackup.Appearance.Options.UseBackColor = True
        Me.ButtonUniNvBackup.Appearance.Options.UseFont = True
        Me.ButtonUniNvBackup.Appearance.Options.UseTextOptions = True
        Me.ButtonUniNvBackup.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonUniNvBackup.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonUniNvBackup.AppearanceHovered.Options.UseFont = True
        Me.ButtonUniNvBackup.AppearanceHovered.Options.UseImage = True
        Me.ButtonUniNvBackup.ImageOptions.Image = CType(resources.GetObject("ButtonUniNvBackup.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonUniNvBackup.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonUniNvBackup.Location = New System.Drawing.Point(5, 105)
        Me.ButtonUniNvBackup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonUniNvBackup.Name = "ButtonUniNvBackup"
        Me.ButtonUniNvBackup.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonUniNvBackup.Size = New System.Drawing.Size(150, 25)
        Me.ButtonUniNvBackup.TabIndex = 45
        Me.ButtonUniNvBackup.Text = "BACKUP NV"
        '
        'ButtonUBL
        '
        Me.ButtonUBL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUBL.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonUBL.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonUBL.Appearance.Options.UseBackColor = True
        Me.ButtonUBL.Appearance.Options.UseFont = True
        Me.ButtonUBL.Appearance.Options.UseTextOptions = True
        Me.ButtonUBL.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonUBL.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonUBL.AppearanceHovered.Options.UseFont = True
        Me.ButtonUBL.AppearanceHovered.Options.UseImage = True
        Me.ButtonUBL.ImageOptions.Image = CType(resources.GetObject("ButtonUBL.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonUBL.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonUBL.Location = New System.Drawing.Point(317, 75)
        Me.ButtonUBL.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonUBL.Name = "ButtonUBL"
        Me.ButtonUBL.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonUBL.Size = New System.Drawing.Size(150, 25)
        Me.ButtonUBL.TabIndex = 40
        Me.ButtonUBL.Text = "UNLOCK BOOTLOADER"
        '
        'ButtonAuth
        '
        Me.ButtonAuth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAuth.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonAuth.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonAuth.Appearance.Options.UseBackColor = True
        Me.ButtonAuth.Appearance.Options.UseFont = True
        Me.ButtonAuth.Appearance.Options.UseTextOptions = True
        Me.ButtonAuth.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonAuth.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonAuth.AppearanceHovered.Options.UseFont = True
        Me.ButtonAuth.AppearanceHovered.Options.UseImage = True
        Me.ButtonAuth.ImageOptions.Image = CType(resources.GetObject("ButtonAuth.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonAuth.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonAuth.Location = New System.Drawing.Point(161, 75)
        Me.ButtonAuth.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonAuth.Name = "ButtonAuth"
        Me.ButtonAuth.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonAuth.Size = New System.Drawing.Size(150, 25)
        Me.ButtonAuth.TabIndex = 41
        Me.ButtonAuth.Text = "AUTH BYPASS"
        '
        'ButtonReadInfo
        '
        Me.ButtonReadInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReadInfo.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonReadInfo.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonReadInfo.Appearance.Options.UseBackColor = True
        Me.ButtonReadInfo.Appearance.Options.UseFont = True
        Me.ButtonReadInfo.Appearance.Options.UseTextOptions = True
        Me.ButtonReadInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonReadInfo.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonReadInfo.AppearanceHovered.Options.UseFont = True
        Me.ButtonReadInfo.AppearanceHovered.Options.UseImage = True
        Me.ButtonReadInfo.ImageOptions.Image = CType(resources.GetObject("ButtonReadInfo.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonReadInfo.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonReadInfo.Location = New System.Drawing.Point(5, 75)
        Me.ButtonReadInfo.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonReadInfo.Name = "ButtonReadInfo"
        Me.ButtonReadInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonReadInfo.Size = New System.Drawing.Size(150, 25)
        Me.ButtonReadInfo.TabIndex = 42
        Me.ButtonReadInfo.Text = "READ INFO"
        '
        'panelControl5
        '
        Me.panelControl5.Controls.Add(Me.CheckboxLoaderELF)
        Me.panelControl5.Controls.Add(Me.ButtonELF)
        Me.panelControl5.Controls.Add(Me.TxtloaderELF)
        Me.panelControl5.Controls.Add(Me.labelControl6)
        Me.panelControl5.Location = New System.Drawing.Point(6, 32)
        Me.panelControl5.Name = "panelControl5"
        Me.panelControl5.Size = New System.Drawing.Size(616, 37)
        Me.panelControl5.TabIndex = 39
        '
        'CheckboxLoaderELF
        '
        Me.CheckboxLoaderELF.AutoSize = True
        Me.CheckboxLoaderELF.CheckedColor = System.Drawing.Color.Red
        Me.CheckboxLoaderELF.ForeColor = System.Drawing.Color.Gainsboro
        Me.CheckboxLoaderELF.Location = New System.Drawing.Point(467, 8)
        Me.CheckboxLoaderELF.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CheckboxLoaderELF.Name = "CheckboxLoaderELF"
        Me.CheckboxLoaderELF.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CheckboxLoaderELF.Size = New System.Drawing.Size(136, 21)
        Me.CheckboxLoaderELF.TabIndex = 37
        Me.CheckboxLoaderELF.Text = "Custom Loader [ELF]"
        Me.CheckboxLoaderELF.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CheckboxLoaderELF.UseVisualStyleBackColor = True
        '
        'ButtonELF
        '
        Me.ButtonELF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonELF.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonELF.Enabled = False
        Me.ButtonELF.FlatAppearance.BorderSize = 0
        Me.ButtonELF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonELF.Image = CType(resources.GetObject("ButtonELF.Image"), System.Drawing.Image)
        Me.ButtonELF.Location = New System.Drawing.Point(417, 10)
        Me.ButtonELF.Name = "ButtonELF"
        Me.ButtonELF.Size = New System.Drawing.Size(24, 16)
        Me.ButtonELF.TabIndex = 35
        Me.ButtonELF.UseVisualStyleBackColor = False
        '
        'TxtloaderELF
        '
        Me.TxtloaderELF.Location = New System.Drawing.Point(106, 9)
        Me.TxtloaderELF.Name = "TxtloaderELF"
        Me.TxtloaderELF.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtloaderELF.Properties.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.TxtloaderELF.Properties.Appearance.Options.UseBackColor = True
        Me.TxtloaderELF.Properties.Appearance.Options.UseForeColor = True
        Me.TxtloaderELF.Size = New System.Drawing.Size(338, 20)
        Me.TxtloaderELF.TabIndex = 28
        '
        'labelControl6
        '
        Me.labelControl6.Location = New System.Drawing.Point(13, 12)
        Me.labelControl6.Name = "labelControl6"
        Me.labelControl6.Size = New System.Drawing.Size(60, 13)
        Me.labelControl6.TabIndex = 0
        Me.labelControl6.Text = "Loader | ELF"
        '
        'BtnGPTread
        '
        Me.BtnGPTread.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGPTread.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.BtnGPTread.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.BtnGPTread.Appearance.Options.UseBackColor = True
        Me.BtnGPTread.Appearance.Options.UseFont = True
        Me.BtnGPTread.Appearance.Options.UseTextOptions = True
        Me.BtnGPTread.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.BtnGPTread.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.BtnGPTread.AppearanceHovered.Options.UseFont = True
        Me.BtnGPTread.AppearanceHovered.Options.UseImage = True
        Me.BtnGPTread.ImageOptions.Image = CType(resources.GetObject("BtnGPTread.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnGPTread.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.BtnGPTread.Location = New System.Drawing.Point(522, 5)
        Me.BtnGPTread.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnGPTread.Name = "BtnGPTread"
        Me.BtnGPTread.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.BtnGPTread.Size = New System.Drawing.Size(100, 22)
        Me.BtnGPTread.TabIndex = 37
        Me.BtnGPTread.Text = "READ GPT"
        '
        'ButtonGptWrite
        '
        Me.ButtonGptWrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGptWrite.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonGptWrite.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.ButtonGptWrite.Appearance.Options.UseBackColor = True
        Me.ButtonGptWrite.Appearance.Options.UseFont = True
        Me.ButtonGptWrite.Appearance.Options.UseTextOptions = True
        Me.ButtonGptWrite.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonGptWrite.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ButtonGptWrite.AppearanceHovered.Options.UseFont = True
        Me.ButtonGptWrite.AppearanceHovered.Options.UseImage = True
        Me.ButtonGptWrite.ImageOptions.Image = CType(resources.GetObject("ButtonGptWrite.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonGptWrite.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonGptWrite.Location = New System.Drawing.Point(179, 5)
        Me.ButtonGptWrite.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonGptWrite.Name = "ButtonGptWrite"
        Me.ButtonGptWrite.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonGptWrite.Size = New System.Drawing.Size(80, 22)
        Me.ButtonGptWrite.TabIndex = 38
        Me.ButtonGptWrite.Text = "WRITE"
        '
        'ButtonRebbot
        '
        Me.ButtonRebbot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRebbot.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonRebbot.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.ButtonRebbot.Appearance.Options.UseBackColor = True
        Me.ButtonRebbot.Appearance.Options.UseFont = True
        Me.ButtonRebbot.Appearance.Options.UseTextOptions = True
        Me.ButtonRebbot.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRebbot.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ButtonRebbot.AppearanceHovered.Options.UseFont = True
        Me.ButtonRebbot.AppearanceHovered.Options.UseImage = True
        Me.ButtonRebbot.ImageOptions.Image = CType(resources.GetObject("ButtonRebbot.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonRebbot.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonRebbot.Location = New System.Drawing.Point(431, 5)
        Me.ButtonRebbot.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRebbot.Name = "ButtonRebbot"
        Me.ButtonRebbot.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRebbot.Size = New System.Drawing.Size(85, 22)
        Me.ButtonRebbot.TabIndex = 35
        Me.ButtonRebbot.Text = "REBOOT"
        '
        'ButtonReadGPT
        '
        Me.ButtonReadGPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReadGPT.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonReadGPT.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.ButtonReadGPT.Appearance.Options.UseBackColor = True
        Me.ButtonReadGPT.Appearance.Options.UseFont = True
        Me.ButtonReadGPT.Appearance.Options.UseTextOptions = True
        Me.ButtonReadGPT.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonReadGPT.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ButtonReadGPT.AppearanceHovered.Options.UseFont = True
        Me.ButtonReadGPT.AppearanceHovered.Options.UseImage = True
        Me.ButtonReadGPT.ImageOptions.Image = CType(resources.GetObject("ButtonReadGPT.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonReadGPT.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonReadGPT.Location = New System.Drawing.Point(93, 5)
        Me.ButtonReadGPT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonReadGPT.Name = "ButtonReadGPT"
        Me.ButtonReadGPT.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonReadGPT.Size = New System.Drawing.Size(80, 22)
        Me.ButtonReadGPT.TabIndex = 36
        Me.ButtonReadGPT.Text = "READ"
        '
        'ButtonEraseGPT
        '
        Me.ButtonEraseGPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEraseGPT.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonEraseGPT.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.ButtonEraseGPT.Appearance.Options.UseBackColor = True
        Me.ButtonEraseGPT.Appearance.Options.UseFont = True
        Me.ButtonEraseGPT.Appearance.Options.UseTextOptions = True
        Me.ButtonEraseGPT.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonEraseGPT.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ButtonEraseGPT.AppearanceHovered.Options.UseFont = True
        Me.ButtonEraseGPT.AppearanceHovered.Options.UseImage = True
        Me.ButtonEraseGPT.ImageOptions.Image = CType(resources.GetObject("ButtonEraseGPT.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonEraseGPT.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonEraseGPT.Location = New System.Drawing.Point(7, 5)
        Me.ButtonEraseGPT.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonEraseGPT.Name = "ButtonEraseGPT"
        Me.ButtonEraseGPT.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonEraseGPT.Size = New System.Drawing.Size(80, 22)
        Me.ButtonEraseGPT.TabIndex = 34
        Me.ButtonEraseGPT.Text = "ERASE"
        '
        'PanelDg
        '
        Me.PanelDg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelDg.Controls.Add(Me.CkboxSelectpartitionDataView)
        Me.PanelDg.Controls.Add(Me.VScrollBarQcFlashDataView)
        Me.PanelDg.Controls.Add(Me.HScrollBarQcFlashDataView)
        Me.PanelDg.Controls.Add(Me.DataView)
        Me.PanelDg.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDg.Location = New System.Drawing.Point(2, 2)
        Me.PanelDg.Name = "PanelDg"
        Me.PanelDg.Size = New System.Drawing.Size(649, 283)
        Me.PanelDg.TabIndex = 0
        '
        'CkboxSelectpartitionDataView
        '
        Me.CkboxSelectpartitionDataView.AutoSize = True
        Me.CkboxSelectpartitionDataView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CkboxSelectpartitionDataView.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CkboxSelectpartitionDataView.Location = New System.Drawing.Point(5, 6)
        Me.CkboxSelectpartitionDataView.Name = "CkboxSelectpartitionDataView"
        Me.CkboxSelectpartitionDataView.Size = New System.Drawing.Size(12, 11)
        Me.CkboxSelectpartitionDataView.TabIndex = 40
        Me.CkboxSelectpartitionDataView.UseVisualStyleBackColor = True
        '
        'VScrollBarQcFlashDataView
        '
        Me.VScrollBarQcFlashDataView.Dock = System.Windows.Forms.DockStyle.Right
        Me.VScrollBarQcFlashDataView.Location = New System.Drawing.Point(632, 0)
        Me.VScrollBarQcFlashDataView.Name = "VScrollBarQcFlashDataView"
        Me.VScrollBarQcFlashDataView.Size = New System.Drawing.Size(17, 266)
        Me.VScrollBarQcFlashDataView.TabIndex = 37
        '
        'HScrollBarQcFlashDataView
        '
        Me.HScrollBarQcFlashDataView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HScrollBarQcFlashDataView.LargeChange = 95
        Me.HScrollBarQcFlashDataView.Location = New System.Drawing.Point(0, 266)
        Me.HScrollBarQcFlashDataView.Name = "HScrollBarQcFlashDataView"
        Me.HScrollBarQcFlashDataView.Size = New System.Drawing.Size(649, 17)
        Me.HScrollBarQcFlashDataView.TabIndex = 35
        '
        'DataView
        '
        Me.DataView.AllowUserToAddRows = False
        Me.DataView.AllowUserToDeleteRows = False
        Me.DataView.AllowUserToResizeRows = False
        Me.DataView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.DataView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column2, Me.Column5, Me.Column3, Me.Column7, Me.Index, Me.Column6})
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataView.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataView.EnableHeadersVisualStyles = False
        Me.DataView.GridColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.DataView.Location = New System.Drawing.Point(0, 0)
        Me.DataView.Name = "DataView"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataView.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.DataView.RowHeadersVisible = False
        Me.DataView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.DataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataView.Size = New System.Drawing.Size(649, 283)
        Me.DataView.TabIndex = 39
        '
        'Column4
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle13.NullValue = False
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle13
        Me.Column4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.Width = 20
        '
        'Column1
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle14
        Me.Column1.HeaderText = "LUNs"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 80
        '
        'Column2
        '
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle15
        Me.Column2.HeaderText = "Blocks"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.Width = 80
        '
        'Column5
        '
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle16
        Me.Column5.HeaderText = "Customs"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.Width = 80
        '
        'Column3
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle17
        Me.Column3.HeaderText = "Partitions"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 80
        '
        'Column7
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.DarkRed
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle18
        Me.Column7.HeaderText = "Start Sectors"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 80
        '
        'Index
        '
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White
        Me.Index.DefaultCellStyle = DataGridViewCellStyle19
        Me.Index.HeaderText = "End Sectors"
        Me.Index.Name = "Index"
        Me.Index.Width = 80
        '
        'Column6
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle20
        Me.Column6.HeaderText = " Locations"
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.Width = 1480
        '
        'QcFlash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.XtraFlash)
        Me.Name = "QcFlash"
        Me.Size = New System.Drawing.Size(653, 482)
        CType(Me.XtraFlash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraFlash.ResumeLayout(False)
        CType(Me.MainTab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainTab.ResumeLayout(False)
        Me.xtraTabPage1.ResumeLayout(False)
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl1.ResumeLayout(False)
        CType(Me.PanelDownload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDownload.ResumeLayout(False)
        Me.PanelDownload.PerformLayout()
        CType(Me.ComboChipQc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl7.ResumeLayout(False)
        Me.panelControl7.PerformLayout()
        CType(Me.ComboBoxEditBrand.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEditModels.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtraTabPage2.ResumeLayout(False)
        CType(Me.Punif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Punif.ResumeLayout(False)
        CType(Me.panelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl5.ResumeLayout(False)
        Me.panelControl5.PerformLayout()
        CType(Me.TxtloaderELF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelDg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDg.ResumeLayout(False)
        Me.PanelDg.PerformLayout()
        CType(Me.DataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents XtraFlash As PanelControl
    Private WithEvents MainTab As DevExpress.XtraTab.XtraTabControl
    Private WithEvents xtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents panelControl1 As PanelControl
    Private WithEvents PanelDownload As PanelControl
    Private WithEvents ButtonQc_Idnt As SimpleButton
    Private WithEvents panelControl7 As PanelControl
    Private WithEvents ButtonLoader As Button
    Private WithEvents labelControl2 As LabelControl
    Private WithEvents labelControl9 As LabelControl
    Private WithEvents labelControl10 As LabelControl
    Private WithEvents ButtonFlashQc As SimpleButton
    Private WithEvents ButtonQc_ReadP As SimpleButton
    Private WithEvents ButtonQc_eP As SimpleButton
    Private WithEvents xtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents Punif As PanelControl
    Private WithEvents ButtonMiReset As SimpleButton
    Private WithEvents ButtonMiDisable As SimpleButton
    Private WithEvents ButtonFormatUser As SimpleButton
    Private WithEvents BtnSAM_FRP_Oem As SimpleButton
    Private WithEvents ButtonFRP_SAM As SimpleButton
    Private WithEvents ButtonRpmbErase As SimpleButton
    Private WithEvents ButtonWrNvram As SimpleButton
    Private WithEvents ButtonAllFRP As SimpleButton
    Private WithEvents ButtonRPMBwrite As SimpleButton
    Private WithEvents ButtonNvErase As SimpleButton
    Private WithEvents ButtonRelockUBL As SimpleButton
    Private WithEvents ButtonRDrpmb As SimpleButton
    Private WithEvents ButtonUniNvBackup As SimpleButton
    Private WithEvents ButtonUBL As SimpleButton
    Private WithEvents ButtonAuth As SimpleButton
    Private WithEvents ButtonReadInfo As SimpleButton
    Private WithEvents panelControl5 As PanelControl
    Private WithEvents ButtonELF As Button
    Private WithEvents TxtloaderELF As TextEdit
    Private WithEvents labelControl6 As LabelControl
    Private WithEvents BtnGPTread As SimpleButton
    Private WithEvents ButtonGptWrite As SimpleButton
    Private WithEvents ButtonRebbot As SimpleButton
    Private WithEvents ButtonReadGPT As SimpleButton
    Private WithEvents ButtonEraseGPT As SimpleButton
    Private WithEvents PanelDg As PanelControl
    Private WithEvents HScrollBarQcFlashDataView As DevExpress.XtraEditors.HScrollBar
    Friend WithEvents VScrollBarQcFlashDataView As DevExpress.XtraEditors.VScrollBar
    Friend WithEvents CekAutoRebootQc As CacheBox
    Public WithEvents ComboChipQc As ComboBoxEdit
    Friend WithEvents CekSetBootQC As CacheBox
    Public WithEvents DataView As DataGridView
    Private WithEvents SimpleButtonReboot As SimpleButton
    Private WithEvents CkboxSelectpartitionDataView As CheckBox
    Private WithEvents labelControl11 As LabelControl
    Friend WithEvents CheckBoxServer As CacheBox
    Private WithEvents Btn_BrowseXML As Button
    Private WithEvents Btn_OFPQc As Button
    Friend WithEvents Column4 As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Index As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Private WithEvents LabelControl1 As LabelControl
    Friend WithEvents CheckboxLoaderELF As CacheBox
    Friend WithEvents CacheBoxAutoFormatData As CacheBox
    Public WithEvents TxtFlashRawXML As Bunifu.Framework.UI.BunifuMaterialTextbox
    Public WithEvents TxtFlashLoader As Bunifu.Framework.UI.BunifuMaterialTextbox
    Public WithEvents ComboBoxEditBrand As ComboBoxEdit
    Public WithEvents ComboBoxEditModels As ComboBoxEdit

    Public WithEvents TxtOFPQC As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents CacheBoxAutoCleanUserAccount As CacheBox
End Class