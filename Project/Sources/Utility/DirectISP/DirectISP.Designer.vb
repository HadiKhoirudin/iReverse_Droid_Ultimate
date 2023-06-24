Imports DevExpress.XtraEditors
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DirectISP
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DirectISP))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.XtraFlash = New DevExpress.XtraEditors.PanelControl()
        Me.MainTab = New DevExpress.XtraTab.XtraTabControl()
        Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Button_WriteP = New DevExpress.XtraEditors.SimpleButton()
        Me.Button_ReadD = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelDownload = New DevExpress.XtraEditors.PanelControl()
        Me.ButtonScan = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBox1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBoxChipset = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.panelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.CacheBoxAutoFormatData = New CacheBox()
        Me.CacheBoxCreateDigest = New CacheBox()
        Me.CekAutoRebootQc = New CacheBox()
        Me.Btn_ScatterTXT = New System.Windows.Forms.Button()
        Me.labelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.ButtonOpenDump = New System.Windows.Forms.Button()
        Me.labelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtScatterFile = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.TxtRawDump = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Btn_RawXML = New System.Windows.Forms.Button()
        Me.TxtFlashRawXML = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.CheckEditAutoXML = New CacheBox()
        Me.Button_WriteD = New DevExpress.XtraEditors.SimpleButton()
        Me.Button_ReadP = New DevExpress.XtraEditors.SimpleButton()
        Me.Button_EraseP = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelDg = New DevExpress.XtraEditors.PanelControl()
        Me.CkboxSelectpartitionDataView = New System.Windows.Forms.CheckBox()
        Me.VScrollBarDirectISPFlashDataView = New DevExpress.XtraEditors.VScrollBar()
        Me.HScrollBarDirectISPFlashDataView = New DevExpress.XtraEditors.HScrollBar()
        Me.DataView = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirectISPWorker = New System.ComponentModel.BackgroundWorker()
        CType(Me.XtraFlash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraFlash.SuspendLayout()
        CType(Me.MainTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainTab.SuspendLayout()
        Me.xtraTabPage1.SuspendLayout()
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl1.SuspendLayout()
        CType(Me.PanelDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDownload.SuspendLayout()
        CType(Me.ComboBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxChipset.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl7.SuspendLayout()
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
        Me.MainTab.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtraTabPage1})
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
        Me.xtraTabPage1.Text = "DISK OPERATION"
        '
        'panelControl1
        '
        Me.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl1.Controls.Add(Me.Button_WriteP)
        Me.panelControl1.Controls.Add(Me.Button_ReadD)
        Me.panelControl1.Controls.Add(Me.PanelDownload)
        Me.panelControl1.Controls.Add(Me.panelControl7)
        Me.panelControl1.Controls.Add(Me.Button_WriteD)
        Me.panelControl1.Controls.Add(Me.Button_ReadP)
        Me.panelControl1.Controls.Add(Me.Button_EraseP)
        Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelControl1.Location = New System.Drawing.Point(0, 0)
        Me.panelControl1.Name = "panelControl1"
        Me.panelControl1.Size = New System.Drawing.Size(627, 193)
        Me.panelControl1.TabIndex = 0
        '
        'Button_WriteP
        '
        Me.Button_WriteP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_WriteP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_WriteP.Appearance.Options.UseBackColor = True
        Me.Button_WriteP.Appearance.Options.UseTextOptions = True
        Me.Button_WriteP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Button_WriteP.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Button_WriteP.AppearanceHovered.Options.UseFont = True
        Me.Button_WriteP.AppearanceHovered.Options.UseImage = True
        Me.Button_WriteP.ImageOptions.Image = Global.Reverse_Tool.My.Resources.Resources.Save22
        Me.Button_WriteP.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.Button_WriteP.Location = New System.Drawing.Point(147, 43)
        Me.Button_WriteP.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Button_WriteP.Name = "Button_WriteP"
        Me.Button_WriteP.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.Button_WriteP.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.Button_WriteP.Size = New System.Drawing.Size(131, 28)
        Me.Button_WriteP.TabIndex = 37
        Me.Button_WriteP.Text = "WRITE PARTITION"
        '
        'Button_ReadD
        '
        Me.Button_ReadD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_ReadD.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_ReadD.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.Button_ReadD.Appearance.Options.UseBackColor = True
        Me.Button_ReadD.Appearance.Options.UseFont = True
        Me.Button_ReadD.Appearance.Options.UseTextOptions = True
        Me.Button_ReadD.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Button_ReadD.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.Button_ReadD.AppearanceHovered.Options.UseFont = True
        Me.Button_ReadD.AppearanceHovered.Options.UseImage = True
        Me.Button_ReadD.ImageOptions.Image = Global.Reverse_Tool.My.Resources.Resources.Save22px
        Me.Button_ReadD.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.Button_ReadD.Location = New System.Drawing.Point(408, 43)
        Me.Button_ReadD.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Button_ReadD.Name = "Button_ReadD"
        Me.Button_ReadD.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.Button_ReadD.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.Button_ReadD.Size = New System.Drawing.Size(97, 28)
        Me.Button_ReadD.TabIndex = 36
        Me.Button_ReadD.Text = "READ DUMP"
        '
        'PanelDownload
        '
        Me.PanelDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDownload.Controls.Add(Me.ButtonScan)
        Me.PanelDownload.Controls.Add(Me.ButtonRefresh)
        Me.PanelDownload.Controls.Add(Me.LabelControl3)
        Me.PanelDownload.Controls.Add(Me.ComboBox1)
        Me.PanelDownload.Controls.Add(Me.labelControl2)
        Me.PanelDownload.Controls.Add(Me.ComboBoxChipset)
        Me.PanelDownload.Location = New System.Drawing.Point(5, 4)
        Me.PanelDownload.Name = "PanelDownload"
        Me.PanelDownload.Size = New System.Drawing.Size(619, 33)
        Me.PanelDownload.TabIndex = 2
        '
        'ButtonScan
        '
        Me.ButtonScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonScan.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonScan.Appearance.Options.UseBackColor = True
        Me.ButtonScan.Appearance.Options.UseTextOptions = True
        Me.ButtonScan.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonScan.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonScan.AppearanceHovered.Options.UseFont = True
        Me.ButtonScan.AppearanceHovered.Options.UseImage = True
        Me.ButtonScan.ImageOptions.Image = CType(resources.GetObject("ButtonScan.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonScan.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonScan.Location = New System.Drawing.Point(334, 2)
        Me.ButtonScan.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonScan.Name = "ButtonScan"
        Me.ButtonScan.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonScan.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonScan.Size = New System.Drawing.Size(83, 28)
        Me.ButtonScan.TabIndex = 44
        Me.ButtonScan.Text = "SCAN DISK"
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonRefresh.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.ButtonRefresh.Appearance.Options.UseBackColor = True
        Me.ButtonRefresh.Appearance.Options.UseFont = True
        Me.ButtonRefresh.Appearance.Options.UseTextOptions = True
        Me.ButtonRefresh.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRefresh.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.ButtonRefresh.AppearanceHovered.Options.UseFont = True
        Me.ButtonRefresh.AppearanceHovered.Options.UseImage = True
        Me.ButtonRefresh.ImageOptions.Image = CType(resources.GetObject("ButtonRefresh.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonRefresh.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonRefresh.Location = New System.Drawing.Point(231, 2)
        Me.ButtonRefresh.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonRefresh.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRefresh.Size = New System.Drawing.Size(97, 28)
        Me.ButtonRefresh.TabIndex = 43
        Me.ButtonRefresh.Text = "REFRESH DISK"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(6, 9)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl3.TabIndex = 42
        Me.LabelControl3.Text = "Size"
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.EditValue = "auto"
        Me.ComboBox1.Location = New System.Drawing.Point(41, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Properties.AllowFocused = False
        Me.ComboBox1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboBox1.Properties.Appearance.BorderColor = System.Drawing.Color.DarkRed
        Me.ComboBox1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.ComboBox1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBox1.Properties.Appearance.Options.UseBackColor = True
        Me.ComboBox1.Properties.Appearance.Options.UseBorderColor = True
        Me.ComboBox1.Properties.Appearance.Options.UseFont = True
        Me.ComboBox1.Properties.Appearance.Options.UseForeColor = True
        Me.ComboBox1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBox1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ComboBox1.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboBox1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboBox1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBox1.Size = New System.Drawing.Size(184, 20)
        Me.ComboBox1.TabIndex = 41
        '
        'labelControl2
        '
        Me.labelControl2.Location = New System.Drawing.Point(438, 9)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(36, 13)
        Me.labelControl2.TabIndex = 40
        Me.labelControl2.Text = "Chipset"
        '
        'ComboBoxChipset
        '
        Me.ComboBoxChipset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxChipset.EditValue = "auto"
        Me.ComboBoxChipset.Location = New System.Drawing.Point(497, 6)
        Me.ComboBoxChipset.Name = "ComboBoxChipset"
        Me.ComboBoxChipset.Properties.AllowFocused = False
        Me.ComboBoxChipset.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboBoxChipset.Properties.Appearance.BorderColor = System.Drawing.Color.DarkRed
        Me.ComboBoxChipset.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.ComboBoxChipset.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ComboBoxChipset.Properties.Appearance.Options.UseBackColor = True
        Me.ComboBoxChipset.Properties.Appearance.Options.UseBorderColor = True
        Me.ComboBoxChipset.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxChipset.Properties.Appearance.Options.UseForeColor = True
        Me.ComboBoxChipset.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxChipset.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ComboBoxChipset.Properties.Items.AddRange(New Object() {"Qualcomm", "Mediatek", "Spreadtrum"})
        Me.ComboBoxChipset.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboBoxChipset.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboBoxChipset.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBoxChipset.Size = New System.Drawing.Size(115, 20)
        Me.ComboBoxChipset.TabIndex = 39
        '
        'panelControl7
        '
        Me.panelControl7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelControl7.Controls.Add(Me.CacheBoxAutoFormatData)
        Me.panelControl7.Controls.Add(Me.CacheBoxCreateDigest)
        Me.panelControl7.Controls.Add(Me.CekAutoRebootQc)
        Me.panelControl7.Controls.Add(Me.Btn_ScatterTXT)
        Me.panelControl7.Controls.Add(Me.labelControl11)
        Me.panelControl7.Controls.Add(Me.ButtonOpenDump)
        Me.panelControl7.Controls.Add(Me.labelControl9)
        Me.panelControl7.Controls.Add(Me.labelControl10)
        Me.panelControl7.Controls.Add(Me.TxtScatterFile)
        Me.panelControl7.Controls.Add(Me.TxtRawDump)
        Me.panelControl7.Controls.Add(Me.Btn_RawXML)
        Me.panelControl7.Controls.Add(Me.TxtFlashRawXML)
        Me.panelControl7.Controls.Add(Me.CheckEditAutoXML)
        Me.panelControl7.Location = New System.Drawing.Point(5, 77)
        Me.panelControl7.Name = "panelControl7"
        Me.panelControl7.Size = New System.Drawing.Size(619, 103)
        Me.panelControl7.TabIndex = 27
        '
        'CacheBoxAutoFormatData
        '
        Me.CacheBoxAutoFormatData.AutoSize = True
        Me.CacheBoxAutoFormatData.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CacheBoxAutoFormatData.CheckedColor = System.Drawing.Color.Red
        Me.CacheBoxAutoFormatData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CacheBoxAutoFormatData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CacheBoxAutoFormatData.Location = New System.Drawing.Point(107, 5)
        Me.CacheBoxAutoFormatData.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CacheBoxAutoFormatData.Name = "CacheBoxAutoFormatData"
        Me.CacheBoxAutoFormatData.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CacheBoxAutoFormatData.Size = New System.Drawing.Size(133, 21)
        Me.CacheBoxAutoFormatData.TabIndex = 47
        Me.CacheBoxAutoFormatData.Text = "Auto Clean Userdata"
        Me.CacheBoxAutoFormatData.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CacheBoxAutoFormatData.UseVisualStyleBackColor = False
        '
        'CacheBoxCreateDigest
        '
        Me.CacheBoxCreateDigest.AutoSize = True
        Me.CacheBoxCreateDigest.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CacheBoxCreateDigest.CheckedColor = System.Drawing.Color.Red
        Me.CacheBoxCreateDigest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CacheBoxCreateDigest.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CacheBoxCreateDigest.Location = New System.Drawing.Point(367, 5)
        Me.CacheBoxCreateDigest.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CacheBoxCreateDigest.Name = "CacheBoxCreateDigest"
        Me.CacheBoxCreateDigest.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CacheBoxCreateDigest.Size = New System.Drawing.Size(126, 21)
        Me.CacheBoxCreateDigest.TabIndex = 46
        Me.CacheBoxCreateDigest.Text = "Auto Clean MiCloud"
        Me.CacheBoxCreateDigest.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CacheBoxCreateDigest.UseVisualStyleBackColor = False
        '
        'CekAutoRebootQc
        '
        Me.CekAutoRebootQc.AutoSize = True
        Me.CekAutoRebootQc.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.CekAutoRebootQc.CheckedColor = System.Drawing.Color.Red
        Me.CekAutoRebootQc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CekAutoRebootQc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CekAutoRebootQc.Location = New System.Drawing.Point(253, 5)
        Me.CekAutoRebootQc.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CekAutoRebootQc.Name = "CekAutoRebootQc"
        Me.CekAutoRebootQc.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CekAutoRebootQc.Size = New System.Drawing.Size(108, 21)
        Me.CekAutoRebootQc.TabIndex = 45
        Me.CekAutoRebootQc.Text = "Auto Clean FRP"
        Me.CekAutoRebootQc.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CekAutoRebootQc.UseVisualStyleBackColor = False
        '
        'Btn_ScatterTXT
        '
        Me.Btn_ScatterTXT.BackColor = System.Drawing.Color.Transparent
        Me.Btn_ScatterTXT.FlatAppearance.BorderSize = 0
        Me.Btn_ScatterTXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_ScatterTXT.Image = CType(resources.GetObject("Btn_ScatterTXT.Image"), System.Drawing.Image)
        Me.Btn_ScatterTXT.Location = New System.Drawing.Point(518, 60)
        Me.Btn_ScatterTXT.Name = "Btn_ScatterTXT"
        Me.Btn_ScatterTXT.Size = New System.Drawing.Size(23, 13)
        Me.Btn_ScatterTXT.TabIndex = 41
        Me.Btn_ScatterTXT.UseVisualStyleBackColor = False
        '
        'labelControl11
        '
        Me.labelControl11.Location = New System.Drawing.Point(6, 60)
        Me.labelControl11.Name = "labelControl11"
        Me.labelControl11.Size = New System.Drawing.Size(54, 13)
        Me.labelControl11.TabIndex = 37
        Me.labelControl11.Text = "Scatter File"
        '
        'ButtonOpenDump
        '
        Me.ButtonOpenDump.BackColor = System.Drawing.Color.Transparent
        Me.ButtonOpenDump.FlatAppearance.BorderSize = 0
        Me.ButtonOpenDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOpenDump.Image = CType(resources.GetObject("ButtonOpenDump.Image"), System.Drawing.Image)
        Me.ButtonOpenDump.Location = New System.Drawing.Point(518, 35)
        Me.ButtonOpenDump.Name = "ButtonOpenDump"
        Me.ButtonOpenDump.Size = New System.Drawing.Size(23, 13)
        Me.ButtonOpenDump.TabIndex = 29
        Me.ButtonOpenDump.UseVisualStyleBackColor = False
        '
        'labelControl9
        '
        Me.labelControl9.Location = New System.Drawing.Point(6, 36)
        Me.labelControl9.Name = "labelControl9"
        Me.labelControl9.Size = New System.Drawing.Size(51, 13)
        Me.labelControl9.TabIndex = 24
        Me.labelControl9.Text = "Raw Dump"
        '
        'labelControl10
        '
        Me.labelControl10.Location = New System.Drawing.Point(6, 84)
        Me.labelControl10.Name = "labelControl10"
        Me.labelControl10.Size = New System.Drawing.Size(43, 13)
        Me.labelControl10.TabIndex = 23
        Me.labelControl10.Text = "Raw XML"
        '
        'TxtScatterFile
        '
        Me.TxtScatterFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtScatterFile.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtScatterFile.ForeColor = System.Drawing.Color.White
        Me.TxtScatterFile.HintForeColor = System.Drawing.Color.Empty
        Me.TxtScatterFile.HintText = ""
        Me.TxtScatterFile.isPassword = False
        Me.TxtScatterFile.LineFocusedColor = System.Drawing.Color.Red
        Me.TxtScatterFile.LineIdleColor = System.Drawing.Color.DarkRed
        Me.TxtScatterFile.LineMouseHoverColor = System.Drawing.Color.Red
        Me.TxtScatterFile.LineThickness = 2
        Me.TxtScatterFile.Location = New System.Drawing.Point(90, 51)
        Me.TxtScatterFile.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtScatterFile.Name = "TxtScatterFile"
        Me.TxtScatterFile.Size = New System.Drawing.Size(450, 24)
        Me.TxtScatterFile.TabIndex = 42
        Me.TxtScatterFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'TxtRawDump
        '
        Me.TxtRawDump.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtRawDump.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtRawDump.ForeColor = System.Drawing.Color.White
        Me.TxtRawDump.HintForeColor = System.Drawing.Color.Empty
        Me.TxtRawDump.HintText = ""
        Me.TxtRawDump.isPassword = False
        Me.TxtRawDump.LineFocusedColor = System.Drawing.Color.Red
        Me.TxtRawDump.LineIdleColor = System.Drawing.Color.DarkRed
        Me.TxtRawDump.LineMouseHoverColor = System.Drawing.Color.Red
        Me.TxtRawDump.LineThickness = 2
        Me.TxtRawDump.Location = New System.Drawing.Point(90, 26)
        Me.TxtRawDump.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtRawDump.Name = "TxtRawDump"
        Me.TxtRawDump.Size = New System.Drawing.Size(450, 24)
        Me.TxtRawDump.TabIndex = 43
        Me.TxtRawDump.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Btn_RawXML
        '
        Me.Btn_RawXML.BackColor = System.Drawing.Color.Transparent
        Me.Btn_RawXML.FlatAppearance.BorderSize = 0
        Me.Btn_RawXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_RawXML.Image = CType(resources.GetObject("Btn_RawXML.Image"), System.Drawing.Image)
        Me.Btn_RawXML.Location = New System.Drawing.Point(484, 83)
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
        Me.TxtFlashRawXML.Location = New System.Drawing.Point(90, 74)
        Me.TxtFlashRawXML.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFlashRawXML.Name = "TxtFlashRawXML"
        Me.TxtFlashRawXML.Size = New System.Drawing.Size(417, 24)
        Me.TxtFlashRawXML.TabIndex = 43
        Me.TxtFlashRawXML.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'CheckEditAutoXML
        '
        Me.CheckEditAutoXML.AutoSize = True
        Me.CheckEditAutoXML.CheckedColor = System.Drawing.Color.Red
        Me.CheckEditAutoXML.Location = New System.Drawing.Point(520, 80)
        Me.CheckEditAutoXML.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CheckEditAutoXML.Name = "CheckEditAutoXML"
        Me.CheckEditAutoXML.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CheckEditAutoXML.Size = New System.Drawing.Size(81, 21)
        Me.CheckEditAutoXML.TabIndex = 40
        Me.CheckEditAutoXML.Text = " AutoXML"
        Me.CheckEditAutoXML.UnCheckedColor = System.Drawing.Color.DarkRed
        Me.CheckEditAutoXML.UseVisualStyleBackColor = True
        '
        'Button_WriteD
        '
        Me.Button_WriteD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_WriteD.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_WriteD.Appearance.Options.UseBackColor = True
        Me.Button_WriteD.Appearance.Options.UseTextOptions = True
        Me.Button_WriteD.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Button_WriteD.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Button_WriteD.AppearanceHovered.Options.UseFont = True
        Me.Button_WriteD.AppearanceHovered.Options.UseImage = True
        Me.Button_WriteD.ImageOptions.Image = CType(resources.GetObject("Button_WriteD.ImageOptions.Image"), System.Drawing.Image)
        Me.Button_WriteD.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.Button_WriteD.Location = New System.Drawing.Point(511, 43)
        Me.Button_WriteD.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Button_WriteD.Name = "Button_WriteD"
        Me.Button_WriteD.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.Button_WriteD.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.Button_WriteD.Size = New System.Drawing.Size(95, 28)
        Me.Button_WriteD.TabIndex = 28
        Me.Button_WriteD.Text = "WRITE DUMP"
        '
        'Button_ReadP
        '
        Me.Button_ReadP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_ReadP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_ReadP.Appearance.Options.UseBackColor = True
        Me.Button_ReadP.Appearance.Options.UseTextOptions = True
        Me.Button_ReadP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Button_ReadP.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Button_ReadP.AppearanceHovered.Options.UseFont = True
        Me.Button_ReadP.AppearanceHovered.Options.UseImage = True
        Me.Button_ReadP.ImageOptions.Image = CType(resources.GetObject("Button_ReadP.ImageOptions.Image"), System.Drawing.Image)
        Me.Button_ReadP.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.Button_ReadP.Location = New System.Drawing.Point(23, 43)
        Me.Button_ReadP.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Button_ReadP.Name = "Button_ReadP"
        Me.Button_ReadP.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.Button_ReadP.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.Button_ReadP.Size = New System.Drawing.Size(118, 28)
        Me.Button_ReadP.TabIndex = 28
        Me.Button_ReadP.Text = "READ PARTITION"
        '
        'Button_EraseP
        '
        Me.Button_EraseP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_EraseP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_EraseP.Appearance.Options.UseBackColor = True
        Me.Button_EraseP.Appearance.Options.UseTextOptions = True
        Me.Button_EraseP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Button_EraseP.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Button_EraseP.AppearanceHovered.Options.UseFont = True
        Me.Button_EraseP.AppearanceHovered.Options.UseImage = True
        Me.Button_EraseP.ImageOptions.Image = CType(resources.GetObject("Button_EraseP.ImageOptions.Image"), System.Drawing.Image)
        Me.Button_EraseP.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.Button_EraseP.Location = New System.Drawing.Point(284, 43)
        Me.Button_EraseP.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Button_EraseP.Name = "Button_EraseP"
        Me.Button_EraseP.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.Button_EraseP.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.Button_EraseP.Size = New System.Drawing.Size(118, 28)
        Me.Button_EraseP.TabIndex = 28
        Me.Button_EraseP.Text = "ERASE PARTITION"
        '
        'PanelDg
        '
        Me.PanelDg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelDg.Controls.Add(Me.CkboxSelectpartitionDataView)
        Me.PanelDg.Controls.Add(Me.VScrollBarDirectISPFlashDataView)
        Me.PanelDg.Controls.Add(Me.HScrollBarDirectISPFlashDataView)
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
        'VScrollBarDirectISPFlashDataView
        '
        Me.VScrollBarDirectISPFlashDataView.Dock = System.Windows.Forms.DockStyle.Right
        Me.VScrollBarDirectISPFlashDataView.Location = New System.Drawing.Point(632, 0)
        Me.VScrollBarDirectISPFlashDataView.Name = "VScrollBarDirectISPFlashDataView"
        Me.VScrollBarDirectISPFlashDataView.Size = New System.Drawing.Size(17, 266)
        Me.VScrollBarDirectISPFlashDataView.TabIndex = 37
        '
        'HScrollBarDirectISPFlashDataView
        '
        Me.HScrollBarDirectISPFlashDataView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HScrollBarDirectISPFlashDataView.LargeChange = 95
        Me.HScrollBarDirectISPFlashDataView.Location = New System.Drawing.Point(0, 266)
        Me.HScrollBarDirectISPFlashDataView.Name = "HScrollBarDirectISPFlashDataView"
        Me.HScrollBarDirectISPFlashDataView.Size = New System.Drawing.Size(649, 17)
        Me.HScrollBarDirectISPFlashDataView.TabIndex = 35
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
        Me.DataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column3, Me.Column5, Me.Column7, Me.Index, Me.Column6, Me.Column2, Me.Column1})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataView.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataView.EnableHeadersVisualStyles = False
        Me.DataView.GridColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.DataView.Location = New System.Drawing.Point(0, 0)
        Me.DataView.Name = "DataView"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataView.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
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
        'Column3
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "Partitions"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 80
        '
        'Column5
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Customs"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.Width = 80
        '
        'Column7
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkRed
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column7.HeaderText = "Start Sectors"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 80
        '
        'Index
        '
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.Index.DefaultCellStyle = DataGridViewCellStyle6
        Me.Index.HeaderText = "End Sectors"
        Me.Index.Name = "Index"
        Me.Index.Width = 80
        '
        'Column6
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column6.HeaderText = " Locations"
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.Width = 800
        '
        'Column2
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column2.HeaderText = " "
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.Width = 5
        '
        'Column1
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Silver
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column1.HeaderText = " "
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 5
        '
        'DirectISPWorker
        '
        Me.DirectISPWorker.WorkerReportsProgress = True
        Me.DirectISPWorker.WorkerSupportsCancellation = True
        '
        'DirectISP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.XtraFlash)
        Me.Name = "DirectISP"
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
        CType(Me.ComboBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxChipset.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl7.ResumeLayout(False)
        Me.panelControl7.PerformLayout()
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
    Private WithEvents Button_ReadD As SimpleButton
    Private WithEvents PanelDownload As PanelControl
    Private WithEvents panelControl7 As PanelControl
    Private WithEvents Btn_ScatterTXT As Button
    Private WithEvents labelControl11 As LabelControl
    Private WithEvents ButtonOpenDump As Button
    Private WithEvents labelControl9 As LabelControl
    Private WithEvents labelControl10 As LabelControl
    Public WithEvents TxtScatterFile As Bunifu.Framework.UI.BunifuMaterialTextbox
    Public WithEvents TxtRawDump As Bunifu.Framework.UI.BunifuMaterialTextbox
    Private WithEvents Btn_RawXML As Button
    Public WithEvents TxtFlashRawXML As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents CheckEditAutoXML As CacheBox
    Private WithEvents Button_WriteD As SimpleButton
    Private WithEvents Button_ReadP As SimpleButton
    Private WithEvents Button_EraseP As SimpleButton
    Private WithEvents PanelDg As PanelControl
    Private WithEvents CkboxSelectpartitionDataView As CheckBox
    Friend WithEvents VScrollBarDirectISPFlashDataView As DevExpress.XtraEditors.VScrollBar
    Private WithEvents HScrollBarDirectISPFlashDataView As DevExpress.XtraEditors.HScrollBar
    Public WithEvents DataView As DataGridView
    Private WithEvents Button_WriteP As SimpleButton
    Friend WithEvents Column4 As DataGridViewCheckBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Index As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Private WithEvents ButtonScan As SimpleButton
    Private WithEvents ButtonRefresh As SimpleButton
    Private WithEvents LabelControl3 As LabelControl
    Public WithEvents ComboBox1 As ComboBoxEdit
    Private WithEvents labelControl2 As LabelControl
    Public WithEvents ComboBoxChipset As ComboBoxEdit
    Friend WithEvents CacheBoxAutoFormatData As CacheBox
    Friend WithEvents CacheBoxCreateDigest As CacheBox
    Friend WithEvents CekAutoRebootQc As CacheBox
    Public WithEvents DirectISPWorker As System.ComponentModel.BackgroundWorker
End Class
