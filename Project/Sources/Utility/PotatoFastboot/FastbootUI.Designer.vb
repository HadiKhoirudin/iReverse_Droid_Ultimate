Imports System.ComponentModel
Imports DevExpress.XtraEditors
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FastbootUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FastbootUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.XtraFlash = New DevExpress.XtraEditors.PanelControl()
        Me.MainTab = New DevExpress.XtraTab.XtraTabControl()
        Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.ButtonRebootSYS = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelDownload = New DevExpress.XtraEditors.PanelControl()
        Me.CacheBoxAutoFormatData = New CacheBox()
        Me.CekSetBootQC = New CacheBox()
        Me.CekAutoRebootQc = New CacheBox()
        Me.ButtonReadInfo = New DevExpress.XtraEditors.SimpleButton()
        Me.panelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ButtonBrowse = New System.Windows.Forms.Button()
        Me.CheckBoxServer = New CacheBox()
        Me.labelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBoxEditBrand = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ComboBoxEditModels = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.labelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TextBoxLocation = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.TxtFlashLoader = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Btn_RawXML = New System.Windows.Forms.Button()
        Me.TxtFlashRawXML = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.ButtonLoader = New System.Windows.Forms.Button()
        Me.ButtonFlash = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRebootEDLnew = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRebootEDLold = New DevExpress.XtraEditors.SimpleButton()
        Me.xtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.Punif = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.CacheBox1 = New CacheBox()
        Me.CacheBox2 = New CacheBox()
        Me.CacheBox3 = New CacheBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonMiReset = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonMiDisable = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonFormatUser = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSAM_FRP_Oem = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonFRP_SAM = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRpmbErase = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonAllFRP = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonNvErase = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRelockUBL = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonUBL = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonReadInfoUniversal = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelDg = New DevExpress.XtraEditors.PanelControl()
        Me.CkboxSelectpartitionDataView = New System.Windows.Forms.CheckBox()
        Me.VScrollBarFbFlashDataView = New DevExpress.XtraEditors.VScrollBar()
        Me.HScrollBarFbFlashDataView = New DevExpress.XtraEditors.HScrollBar()
        Me.DataView = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.FastbootWorker = New System.ComponentModel.BackgroundWorker()
        CType(Me.XtraFlash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraFlash.SuspendLayout()
        CType(Me.MainTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainTab.SuspendLayout()
        Me.xtraTabPage1.SuspendLayout()
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl1.SuspendLayout()
        CType(Me.PanelDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDownload.SuspendLayout()
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl7.SuspendLayout()
        CType(Me.ComboBoxEditBrand.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEditModels.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtraTabPage2.SuspendLayout()
        CType(Me.Punif, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Punif.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
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
        Me.XtraFlash.TabIndex = 3
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
        Me.panelControl1.Controls.Add(Me.ButtonRebootSYS)
        Me.panelControl1.Controls.Add(Me.PanelDownload)
        Me.panelControl1.Controls.Add(Me.ButtonReadInfo)
        Me.panelControl1.Controls.Add(Me.panelControl7)
        Me.panelControl1.Controls.Add(Me.ButtonFlash)
        Me.panelControl1.Controls.Add(Me.ButtonRebootEDLnew)
        Me.panelControl1.Controls.Add(Me.ButtonRebootEDLold)
        Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelControl1.Location = New System.Drawing.Point(0, 0)
        Me.panelControl1.Name = "panelControl1"
        Me.panelControl1.Size = New System.Drawing.Size(627, 193)
        Me.panelControl1.TabIndex = 0
        '
        'ButtonRebootSYS
        '
        Me.ButtonRebootSYS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRebootSYS.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonRebootSYS.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.ButtonRebootSYS.Appearance.Options.UseBackColor = True
        Me.ButtonRebootSYS.Appearance.Options.UseFont = True
        Me.ButtonRebootSYS.Appearance.Options.UseTextOptions = True
        Me.ButtonRebootSYS.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRebootSYS.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ButtonRebootSYS.AppearanceHovered.Options.UseFont = True
        Me.ButtonRebootSYS.AppearanceHovered.Options.UseImage = True
        Me.ButtonRebootSYS.ImageOptions.Image = CType(resources.GetObject("ButtonRebootSYS.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonRebootSYS.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonRebootSYS.Location = New System.Drawing.Point(395, 43)
        Me.ButtonRebootSYS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRebootSYS.Name = "ButtonRebootSYS"
        Me.ButtonRebootSYS.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonRebootSYS.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRebootSYS.Size = New System.Drawing.Size(129, 28)
        Me.ButtonRebootSYS.TabIndex = 36
        Me.ButtonRebootSYS.Text = "REBOOT SYSTEM"
        '
        'PanelDownload
        '
        Me.PanelDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDownload.Controls.Add(Me.CacheBoxAutoFormatData)
        Me.PanelDownload.Controls.Add(Me.CekSetBootQC)
        Me.PanelDownload.Controls.Add(Me.CekAutoRebootQc)
        Me.PanelDownload.Location = New System.Drawing.Point(5, 4)
        Me.PanelDownload.Name = "PanelDownload"
        Me.PanelDownload.Size = New System.Drawing.Size(619, 33)
        Me.PanelDownload.TabIndex = 2
        '
        'CacheBoxAutoFormatData
        '
        Me.CacheBoxAutoFormatData.AutoSize = True
        Me.CacheBoxAutoFormatData.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CacheBoxAutoFormatData.CheckedColor = System.Drawing.Color.Red
        Me.CacheBoxAutoFormatData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CacheBoxAutoFormatData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CacheBoxAutoFormatData.Location = New System.Drawing.Point(8, 5)
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
        Me.CekSetBootQC.Location = New System.Drawing.Point(485, 5)
        Me.CekSetBootQC.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CekSetBootQC.Name = "CekSetBootQC"
        Me.CekSetBootQC.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CekSetBootQC.Size = New System.Drawing.Size(130, 21)
        Me.CekSetBootQC.TabIndex = 34
        Me.CekSetBootQC.Text = "Auto Boot Recovery"
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
        Me.CekAutoRebootQc.Location = New System.Drawing.Point(271, 5)
        Me.CekAutoRebootQc.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CekAutoRebootQc.Name = "CekAutoRebootQc"
        Me.CekAutoRebootQc.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CekAutoRebootQc.Size = New System.Drawing.Size(94, 21)
        Me.CekAutoRebootQc.TabIndex = 35
        Me.CekAutoRebootQc.Text = "Auto Reboot"
        Me.CekAutoRebootQc.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CekAutoRebootQc.UseVisualStyleBackColor = False
        '
        'ButtonReadInfo
        '
        Me.ButtonReadInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReadInfo.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonReadInfo.Appearance.Options.UseBackColor = True
        Me.ButtonReadInfo.Appearance.Options.UseTextOptions = True
        Me.ButtonReadInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonReadInfo.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonReadInfo.AppearanceHovered.Options.UseFont = True
        Me.ButtonReadInfo.AppearanceHovered.Options.UseImage = True
        Me.ButtonReadInfo.ImageOptions.Image = CType(resources.GetObject("ButtonReadInfo.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonReadInfo.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonReadInfo.Location = New System.Drawing.Point(9, 43)
        Me.ButtonReadInfo.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonReadInfo.Name = "ButtonReadInfo"
        Me.ButtonReadInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonReadInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonReadInfo.Size = New System.Drawing.Size(94, 28)
        Me.ButtonReadInfo.TabIndex = 28
        Me.ButtonReadInfo.Text = "READ INFO"
        '
        'panelControl7
        '
        Me.panelControl7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelControl7.Controls.Add(Me.LabelControl1)
        Me.panelControl7.Controls.Add(Me.ButtonBrowse)
        Me.panelControl7.Controls.Add(Me.CheckBoxServer)
        Me.panelControl7.Controls.Add(Me.labelControl11)
        Me.panelControl7.Controls.Add(Me.ComboBoxEditBrand)
        Me.panelControl7.Controls.Add(Me.ComboBoxEditModels)
        Me.panelControl7.Controls.Add(Me.labelControl9)
        Me.panelControl7.Controls.Add(Me.labelControl10)
        Me.panelControl7.Controls.Add(Me.TextBoxLocation)
        Me.panelControl7.Controls.Add(Me.TxtFlashLoader)
        Me.panelControl7.Controls.Add(Me.Btn_RawXML)
        Me.panelControl7.Controls.Add(Me.TxtFlashRawXML)
        Me.panelControl7.Controls.Add(Me.ButtonLoader)
        Me.panelControl7.Location = New System.Drawing.Point(5, 77)
        Me.panelControl7.Name = "panelControl7"
        Me.panelControl7.Size = New System.Drawing.Size(619, 103)
        Me.panelControl7.TabIndex = 27
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl1.TabIndex = 44
        Me.LabelControl1.Text = "Custom Recovery"
        '
        'ButtonBrowse
        '
        Me.ButtonBrowse.BackColor = System.Drawing.Color.Transparent
        Me.ButtonBrowse.FlatAppearance.BorderSize = 0
        Me.ButtonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBrowse.Image = CType(resources.GetObject("ButtonBrowse.Image"), System.Drawing.Image)
        Me.ButtonBrowse.Location = New System.Drawing.Point(534, 56)
        Me.ButtonBrowse.Name = "ButtonBrowse"
        Me.ButtonBrowse.Size = New System.Drawing.Size(23, 13)
        Me.ButtonBrowse.TabIndex = 41
        Me.ButtonBrowse.UseVisualStyleBackColor = False
        '
        'CheckBoxServer
        '
        Me.CheckBoxServer.AutoSize = True
        Me.CheckBoxServer.CheckedColor = System.Drawing.Color.Red
        Me.CheckBoxServer.Location = New System.Drawing.Point(534, 6)
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
        Me.labelControl11.Location = New System.Drawing.Point(8, 57)
        Me.labelControl11.Name = "labelControl11"
        Me.labelControl11.Size = New System.Drawing.Size(69, 13)
        Me.labelControl11.TabIndex = 37
        Me.labelControl11.Text = "File Flash *bat"
        '
        'ComboBoxEditBrand
        '
        Me.ComboBoxEditBrand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEditBrand.EditValue = ""
        Me.ComboBoxEditBrand.Location = New System.Drawing.Point(108, 6)
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
        Me.ComboBoxEditBrand.Size = New System.Drawing.Size(199, 20)
        Me.ComboBoxEditBrand.TabIndex = 30
        '
        'ComboBoxEditModels
        '
        Me.ComboBoxEditModels.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEditModels.EditValue = ""
        Me.ComboBoxEditModels.Location = New System.Drawing.Point(313, 6)
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
        Me.ComboBoxEditModels.Size = New System.Drawing.Size(196, 20)
        Me.ComboBoxEditModels.TabIndex = 29
        '
        'labelControl9
        '
        Me.labelControl9.Location = New System.Drawing.Point(8, 33)
        Me.labelControl9.Name = "labelControl9"
        Me.labelControl9.Size = New System.Drawing.Size(86, 13)
        Me.labelControl9.TabIndex = 24
        Me.labelControl9.Text = "Custom Command"
        '
        'labelControl10
        '
        Me.labelControl10.Location = New System.Drawing.Point(8, 81)
        Me.labelControl10.Name = "labelControl10"
        Me.labelControl10.Size = New System.Drawing.Size(89, 13)
        Me.labelControl10.TabIndex = 23
        Me.labelControl10.Text = "Custom Flash *bat"
        '
        'TextBoxLocation
        '
        Me.TextBoxLocation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxLocation.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TextBoxLocation.ForeColor = System.Drawing.Color.White
        Me.TextBoxLocation.HintForeColor = System.Drawing.Color.Empty
        Me.TextBoxLocation.HintText = ""
        Me.TextBoxLocation.isPassword = False
        Me.TextBoxLocation.LineFocusedColor = System.Drawing.Color.Red
        Me.TextBoxLocation.LineIdleColor = System.Drawing.Color.DarkRed
        Me.TextBoxLocation.LineMouseHoverColor = System.Drawing.Color.Red
        Me.TextBoxLocation.LineThickness = 2
        Me.TextBoxLocation.Location = New System.Drawing.Point(100, 48)
        Me.TextBoxLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxLocation.Name = "TextBoxLocation"
        Me.TextBoxLocation.Size = New System.Drawing.Size(450, 24)
        Me.TextBoxLocation.TabIndex = 42
        Me.TextBoxLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
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
        Me.TxtFlashLoader.Location = New System.Drawing.Point(100, 23)
        Me.TxtFlashLoader.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFlashLoader.Name = "TxtFlashLoader"
        Me.TxtFlashLoader.Size = New System.Drawing.Size(450, 24)
        Me.TxtFlashLoader.TabIndex = 43
        Me.TxtFlashLoader.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Btn_RawXML
        '
        Me.Btn_RawXML.BackColor = System.Drawing.Color.Transparent
        Me.Btn_RawXML.FlatAppearance.BorderSize = 0
        Me.Btn_RawXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_RawXML.Image = CType(resources.GetObject("Btn_RawXML.Image"), System.Drawing.Image)
        Me.Btn_RawXML.Location = New System.Drawing.Point(527, 78)
        Me.Btn_RawXML.Name = "Btn_RawXML"
        Me.Btn_RawXML.Size = New System.Drawing.Size(23, 13)
        Me.Btn_RawXML.TabIndex = 42
        Me.Btn_RawXML.UseVisualStyleBackColor = False
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
        Me.TxtFlashRawXML.Location = New System.Drawing.Point(108, 70)
        Me.TxtFlashRawXML.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFlashRawXML.Name = "TxtFlashRawXML"
        Me.TxtFlashRawXML.Size = New System.Drawing.Size(435, 24)
        Me.TxtFlashRawXML.TabIndex = 43
        Me.TxtFlashRawXML.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'ButtonLoader
        '
        Me.ButtonLoader.BackColor = System.Drawing.Color.Transparent
        Me.ButtonLoader.FlatAppearance.BorderSize = 0
        Me.ButtonLoader.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLoader.Image = CType(resources.GetObject("ButtonLoader.Image"), System.Drawing.Image)
        Me.ButtonLoader.Location = New System.Drawing.Point(520, 32)
        Me.ButtonLoader.Name = "ButtonLoader"
        Me.ButtonLoader.Size = New System.Drawing.Size(23, 13)
        Me.ButtonLoader.TabIndex = 29
        Me.ButtonLoader.UseVisualStyleBackColor = False
        '
        'ButtonFlash
        '
        Me.ButtonFlash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFlash.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonFlash.Appearance.Options.UseBackColor = True
        Me.ButtonFlash.Appearance.Options.UseTextOptions = True
        Me.ButtonFlash.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonFlash.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonFlash.AppearanceHovered.Options.UseFont = True
        Me.ButtonFlash.AppearanceHovered.Options.UseImage = True
        Me.ButtonFlash.ImageOptions.Image = CType(resources.GetObject("ButtonFlash.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonFlash.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonFlash.Location = New System.Drawing.Point(530, 43)
        Me.ButtonFlash.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonFlash.Name = "ButtonFlash"
        Me.ButtonFlash.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonFlash.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonFlash.Size = New System.Drawing.Size(94, 28)
        Me.ButtonFlash.TabIndex = 28
        Me.ButtonFlash.Text = "FLASH"
        '
        'ButtonRebootEDLnew
        '
        Me.ButtonRebootEDLnew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRebootEDLnew.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonRebootEDLnew.Appearance.Options.UseBackColor = True
        Me.ButtonRebootEDLnew.Appearance.Options.UseTextOptions = True
        Me.ButtonRebootEDLnew.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRebootEDLnew.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonRebootEDLnew.AppearanceHovered.Options.UseFont = True
        Me.ButtonRebootEDLnew.AppearanceHovered.Options.UseImage = True
        Me.ButtonRebootEDLnew.ImageOptions.Image = Global.Reverse_Tool.My.Resources.Resources.Format22
        Me.ButtonRebootEDLnew.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonRebootEDLnew.Location = New System.Drawing.Point(260, 43)
        Me.ButtonRebootEDLnew.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRebootEDLnew.Name = "ButtonRebootEDLnew"
        Me.ButtonRebootEDLnew.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonRebootEDLnew.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRebootEDLnew.Size = New System.Drawing.Size(129, 28)
        Me.ButtonRebootEDLnew.TabIndex = 28
        Me.ButtonRebootEDLnew.Text = "REBOOT EDL [NEW]"
        '
        'ButtonRebootEDLold
        '
        Me.ButtonRebootEDLold.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRebootEDLold.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonRebootEDLold.Appearance.Options.UseBackColor = True
        Me.ButtonRebootEDLold.Appearance.Options.UseTextOptions = True
        Me.ButtonRebootEDLold.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRebootEDLold.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonRebootEDLold.AppearanceHovered.Options.UseFont = True
        Me.ButtonRebootEDLold.AppearanceHovered.Options.UseImage = True
        Me.ButtonRebootEDLold.ImageOptions.Image = Global.Reverse_Tool.My.Resources.Resources.Format22
        Me.ButtonRebootEDLold.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonRebootEDLold.Location = New System.Drawing.Point(113, 43)
        Me.ButtonRebootEDLold.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRebootEDLold.Name = "ButtonRebootEDLold"
        Me.ButtonRebootEDLold.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonRebootEDLold.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRebootEDLold.Size = New System.Drawing.Size(129, 28)
        Me.ButtonRebootEDLold.TabIndex = 28
        Me.ButtonRebootEDLold.Text = "REBOOT EDL [OLD]"
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
        Me.Punif.Controls.Add(Me.PanelControl2)
        Me.Punif.Controls.Add(Me.SimpleButton1)
        Me.Punif.Controls.Add(Me.SimpleButton2)
        Me.Punif.Controls.Add(Me.ButtonMiReset)
        Me.Punif.Controls.Add(Me.ButtonMiDisable)
        Me.Punif.Controls.Add(Me.ButtonFormatUser)
        Me.Punif.Controls.Add(Me.BtnSAM_FRP_Oem)
        Me.Punif.Controls.Add(Me.ButtonFRP_SAM)
        Me.Punif.Controls.Add(Me.ButtonRpmbErase)
        Me.Punif.Controls.Add(Me.ButtonAllFRP)
        Me.Punif.Controls.Add(Me.ButtonNvErase)
        Me.Punif.Controls.Add(Me.ButtonRelockUBL)
        Me.Punif.Controls.Add(Me.ButtonUBL)
        Me.Punif.Controls.Add(Me.ButtonReadInfoUniversal)
        Me.Punif.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Punif.Location = New System.Drawing.Point(0, 0)
        Me.Punif.Name = "Punif"
        Me.Punif.Size = New System.Drawing.Size(627, 193)
        Me.Punif.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl2.Controls.Add(Me.CacheBox1)
        Me.PanelControl2.Controls.Add(Me.CacheBox2)
        Me.PanelControl2.Controls.Add(Me.CacheBox3)
        Me.PanelControl2.Location = New System.Drawing.Point(5, 4)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(619, 33)
        Me.PanelControl2.TabIndex = 61
        '
        'CacheBox1
        '
        Me.CacheBox1.AutoSize = True
        Me.CacheBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CacheBox1.CheckedColor = System.Drawing.Color.Red
        Me.CacheBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CacheBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CacheBox1.Location = New System.Drawing.Point(8, 5)
        Me.CacheBox1.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CacheBox1.Name = "CacheBox1"
        Me.CacheBox1.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CacheBox1.Size = New System.Drawing.Size(133, 21)
        Me.CacheBox1.TabIndex = 37
        Me.CacheBox1.Text = "Auto Clean Userdata"
        Me.CacheBox1.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CacheBox1.UseVisualStyleBackColor = False
        '
        'CacheBox2
        '
        Me.CacheBox2.AutoSize = True
        Me.CacheBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CacheBox2.CheckedColor = System.Drawing.Color.Red
        Me.CacheBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CacheBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CacheBox2.Location = New System.Drawing.Point(485, 5)
        Me.CacheBox2.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CacheBox2.Name = "CacheBox2"
        Me.CacheBox2.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CacheBox2.Size = New System.Drawing.Size(130, 21)
        Me.CacheBox2.TabIndex = 34
        Me.CacheBox2.Text = "Auto Boot Recovery"
        Me.CacheBox2.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CacheBox2.UseVisualStyleBackColor = False
        '
        'CacheBox3
        '
        Me.CacheBox3.AutoSize = True
        Me.CacheBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CacheBox3.CheckedColor = System.Drawing.Color.Red
        Me.CacheBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CacheBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CacheBox3.Location = New System.Drawing.Point(271, 5)
        Me.CacheBox3.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CacheBox3.Name = "CacheBox3"
        Me.CacheBox3.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CacheBox3.Size = New System.Drawing.Size(94, 21)
        Me.CacheBox3.TabIndex = 35
        Me.CacheBox3.Text = "Auto Reboot"
        Me.CacheBox3.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CacheBox3.UseVisualStyleBackColor = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseTextOptions = True
        Me.SimpleButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton1.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.SimpleButton1.AppearanceHovered.Options.UseFont = True
        Me.SimpleButton1.AppearanceHovered.Options.UseImage = True
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.SimpleButton1.Location = New System.Drawing.Point(161, 164)
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.SimpleButton1.Size = New System.Drawing.Size(150, 25)
        Me.SimpleButton1.TabIndex = 60
        Me.SimpleButton1.Text = "LOCK BL VIVO"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Appearance.Options.UseTextOptions = True
        Me.SimpleButton2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SimpleButton2.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.SimpleButton2.AppearanceHovered.Options.UseFont = True
        Me.SimpleButton2.AppearanceHovered.Options.UseImage = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.SimpleButton2.Location = New System.Drawing.Point(161, 135)
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.SimpleButton2.Size = New System.Drawing.Size(150, 25)
        Me.SimpleButton2.TabIndex = 59
        Me.SimpleButton2.Text = "UNLOCK BL VIVO"
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
        Me.BtnSAM_FRP_Oem.ImageOptions.Image = CType(resources.GetObject("BtnSAM_FRP_Oem.ImageOptions.Image"), System.Drawing.Image)
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
        Me.ButtonRpmbErase.Location = New System.Drawing.Point(317, 105)
        Me.ButtonRpmbErase.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRpmbErase.Name = "ButtonRpmbErase"
        Me.ButtonRpmbErase.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRpmbErase.Size = New System.Drawing.Size(150, 25)
        Me.ButtonRpmbErase.TabIndex = 51
        Me.ButtonRpmbErase.Text = "ERASE EFS"
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
        Me.ButtonNvErase.Location = New System.Drawing.Point(317, 75)
        Me.ButtonNvErase.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonNvErase.Name = "ButtonNvErase"
        Me.ButtonNvErase.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonNvErase.Size = New System.Drawing.Size(150, 25)
        Me.ButtonNvErase.TabIndex = 55
        Me.ButtonNvErase.Text = "ERASE CONFIG"
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
        Me.ButtonRelockUBL.Location = New System.Drawing.Point(161, 106)
        Me.ButtonRelockUBL.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRelockUBL.Name = "ButtonRelockUBL"
        Me.ButtonRelockUBL.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRelockUBL.Size = New System.Drawing.Size(150, 25)
        Me.ButtonRelockUBL.TabIndex = 43
        Me.ButtonRelockUBL.Text = "LOCK BL UNIVERSAL"
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
        Me.ButtonUBL.Location = New System.Drawing.Point(161, 75)
        Me.ButtonUBL.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonUBL.Name = "ButtonUBL"
        Me.ButtonUBL.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonUBL.Size = New System.Drawing.Size(150, 25)
        Me.ButtonUBL.TabIndex = 40
        Me.ButtonUBL.Text = "UNLOCK BL UNIVERSAL"
        '
        'ButtonReadInfoUniversal
        '
        Me.ButtonReadInfoUniversal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReadInfoUniversal.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonReadInfoUniversal.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.ButtonReadInfoUniversal.Appearance.Options.UseBackColor = True
        Me.ButtonReadInfoUniversal.Appearance.Options.UseFont = True
        Me.ButtonReadInfoUniversal.Appearance.Options.UseTextOptions = True
        Me.ButtonReadInfoUniversal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonReadInfoUniversal.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.ButtonReadInfoUniversal.AppearanceHovered.Options.UseFont = True
        Me.ButtonReadInfoUniversal.AppearanceHovered.Options.UseImage = True
        Me.ButtonReadInfoUniversal.ImageOptions.Image = CType(resources.GetObject("ButtonReadInfoUniversal.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonReadInfoUniversal.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonReadInfoUniversal.Location = New System.Drawing.Point(5, 75)
        Me.ButtonReadInfoUniversal.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonReadInfoUniversal.Name = "ButtonReadInfoUniversal"
        Me.ButtonReadInfoUniversal.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonReadInfoUniversal.Size = New System.Drawing.Size(150, 25)
        Me.ButtonReadInfoUniversal.TabIndex = 42
        Me.ButtonReadInfoUniversal.Text = "READ INFO"
        '
        'PanelDg
        '
        Me.PanelDg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelDg.Controls.Add(Me.CkboxSelectpartitionDataView)
        Me.PanelDg.Controls.Add(Me.VScrollBarFbFlashDataView)
        Me.PanelDg.Controls.Add(Me.HScrollBarFbFlashDataView)
        Me.PanelDg.Controls.Add(Me.DataView)
        Me.PanelDg.Controls.Add(Me.LabelProductName)
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
        'VScrollBarFbFlashDataView
        '
        Me.VScrollBarFbFlashDataView.Dock = System.Windows.Forms.DockStyle.Right
        Me.VScrollBarFbFlashDataView.Location = New System.Drawing.Point(632, 0)
        Me.VScrollBarFbFlashDataView.Name = "VScrollBarFbFlashDataView"
        Me.VScrollBarFbFlashDataView.Size = New System.Drawing.Size(17, 266)
        Me.VScrollBarFbFlashDataView.TabIndex = 37
        '
        'HScrollBarFbFlashDataView
        '
        Me.HScrollBarFbFlashDataView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HScrollBarFbFlashDataView.LargeChange = 95
        Me.HScrollBarFbFlashDataView.Location = New System.Drawing.Point(0, 266)
        Me.HScrollBarFbFlashDataView.Name = "HScrollBarFbFlashDataView"
        Me.HScrollBarFbFlashDataView.Size = New System.Drawing.Size(649, 17)
        Me.HScrollBarFbFlashDataView.TabIndex = 35
        '
        'DataView
        '
        Me.DataView.AllowUserToAddRows = False
        Me.DataView.AllowUserToDeleteRows = False
        Me.DataView.AllowUserToResizeRows = False
        Me.DataView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.DataView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column2, Me.Column3, Me.Column7, Me.Column6, Me.Column5, Me.Column8})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataView.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataView.EnableHeadersVisualStyles = False
        Me.DataView.GridColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.DataView.Location = New System.Drawing.Point(0, 0)
        Me.DataView.Name = "DataView"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataView.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataView.RowHeadersVisible = False
        Me.DataView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.DataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataView.Size = New System.Drawing.Size(649, 283)
        Me.DataView.TabIndex = 39
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.NullValue = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.Width = 20
        '
        'Column1
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column1.HeaderText = "Command"
        Me.Column1.Items.AddRange(New Object() {"boot", "erase", "flash", "oem", "reboot", "reboot-edl"})
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column2
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = "Partition"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Column3
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column3.HeaderText = "Custom"
        Me.Column3.Name = "Column3"
        '
        'Column7
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkRed
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column7.HeaderText = "Filename"
        Me.Column7.Name = "Column7"
        '
        'Column6
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column6.HeaderText = "Path"
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.Width = 580
        '
        'Column5
        '
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 5
        '
        'Column8
        '
        Me.Column8.HeaderText = "Column8"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 5
        '
        'LabelProductName
        '
        Me.LabelProductName.AutoSize = True
        Me.LabelProductName.Location = New System.Drawing.Point(376, 171)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(0, 13)
        Me.LabelProductName.TabIndex = 41
        '
        'FastbootWorker
        '
        Me.FastbootWorker.WorkerReportsProgress = True
        Me.FastbootWorker.WorkerSupportsCancellation = True
        '
        'FastbootUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.XtraFlash)
        Me.Name = "FastbootUI"
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
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl7.ResumeLayout(False)
        Me.panelControl7.PerformLayout()
        CType(Me.ComboBoxEditBrand.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEditModels.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtraTabPage2.ResumeLayout(False)
        CType(Me.Punif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Punif.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
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
    Private WithEvents ButtonRebootSYS As SimpleButton
    Private WithEvents PanelDownload As PanelControl
    Friend WithEvents CacheBoxAutoFormatData As CacheBox
    Friend WithEvents CekSetBootQC As CacheBox
    Friend WithEvents CekAutoRebootQc As CacheBox
    Private WithEvents ButtonReadInfo As SimpleButton
    Private WithEvents panelControl7 As PanelControl
    Private WithEvents LabelControl1 As LabelControl
    Friend WithEvents CheckBoxServer As CacheBox
    Private WithEvents labelControl11 As LabelControl
    Public WithEvents ComboBoxEditBrand As ComboBoxEdit
    Public WithEvents ComboBoxEditModels As ComboBoxEdit
    Private WithEvents labelControl9 As LabelControl
    Private WithEvents labelControl10 As LabelControl
    Public WithEvents TextBoxLocation As Bunifu.Framework.UI.BunifuMaterialTextbox
    Public WithEvents TxtFlashLoader As Bunifu.Framework.UI.BunifuMaterialTextbox
    Public WithEvents TxtFlashRawXML As Bunifu.Framework.UI.BunifuMaterialTextbox
    Private WithEvents ButtonFlash As SimpleButton
    Private WithEvents ButtonRebootEDLold As SimpleButton
    Private WithEvents xtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents Punif As PanelControl
    Private WithEvents ButtonMiReset As SimpleButton
    Private WithEvents ButtonMiDisable As SimpleButton
    Private WithEvents ButtonFormatUser As SimpleButton
    Private WithEvents BtnSAM_FRP_Oem As SimpleButton
    Private WithEvents ButtonFRP_SAM As SimpleButton
    Private WithEvents ButtonRpmbErase As SimpleButton
    Private WithEvents ButtonAllFRP As SimpleButton
    Private WithEvents ButtonNvErase As SimpleButton
    Private WithEvents ButtonRelockUBL As SimpleButton
    Private WithEvents ButtonUBL As SimpleButton
    Private WithEvents ButtonReadInfoUniversal As SimpleButton
    Private WithEvents PanelDg As PanelControl
    Private WithEvents CkboxSelectpartitionDataView As System.Windows.Forms.CheckBox
    Friend WithEvents VScrollBarFbFlashDataView As DevExpress.XtraEditors.VScrollBar
    Private WithEvents HScrollBarFbFlashDataView As DevExpress.XtraEditors.HScrollBar
    Public WithEvents DataView As System.Windows.Forms.DataGridView
    Private WithEvents ButtonLoader As System.Windows.Forms.Button
    Private WithEvents PanelControl2 As PanelControl
    Friend WithEvents CacheBox1 As CacheBox
    Friend WithEvents CacheBox2 As CacheBox
    Friend WithEvents CacheBox3 As CacheBox
    Private WithEvents SimpleButton1 As SimpleButton
    Private WithEvents SimpleButton2 As SimpleButton


    Private WithEvents ButtonRebootEDLnew As SimpleButton
    Public WithEvents FastbootWorker As BackgroundWorker
End Class
