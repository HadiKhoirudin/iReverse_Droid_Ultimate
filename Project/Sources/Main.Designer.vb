Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.panelControl11 = New DevExpress.XtraEditors.PanelControl()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.PictureEditSelectedChip = New DevExpress.XtraEditors.PictureEdit()
        Me.ButtonVivoModel = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonFlashQc = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonSamsungModel = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRealmeModel = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonFlashMtk = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonHuaweiModel = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonInfinixModel = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonAssusModel = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonNokiaModel = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonOppoModel = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonMeizuModel = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonMiModel = New DevExpress.XtraEditors.SimpleButton()
        Me.XFORM = New DevExpress.XtraEditors.PanelControl()
        Me.panelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.Progressbar1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.Progressbar2 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.ButtonSTOP = New DevExpress.XtraEditors.LabelControl()
        Me.PanelText = New DevExpress.XtraEditors.PanelControl()
        Me.RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.panelControl9 = New DevExpress.XtraEditors.PanelControl()
        Me.labelControlADBIdent = New DevExpress.XtraEditors.LabelControl()
        Me.labelControlRefresh = New DevExpress.XtraEditors.LabelControl()
        Me.LabUSB = New DevExpress.XtraEditors.LabelControl()
        Me.LabelPort = New DevExpress.XtraEditors.LabelControl()
        Me.comboUSB = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ComboPort = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.panelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.FormCtrl = New DevExpress.XtraEditors.PanelControl()
        Me.panelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelTimer = New System.Windows.Forms.Label()
        Me.LabelControlISPDirect = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControlFastboot = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControlADBManager = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControlFlash = New DevExpress.XtraEditors.LabelControl()
        Me.panelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.panelControl10 = New DevExpress.XtraEditors.PanelControl()
        Me.Combo_AllInOne_DA = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ComboAuth = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.labelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.labelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckAuth = New DevExpress.XtraEditors.CheckEdit()
        Me.labelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBroom = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelTime = New DevExpress.XtraEditors.LabelControl()
        Me.panelControl8 = New DevExpress.XtraEditors.PanelControl()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.TimerTime = New System.Windows.Forms.Timer(Me.components)
        Me.Flashtool_Doworker = New System.ComponentModel.BackgroundWorker()
        Me.AdbPython = New System.ComponentModel.BackgroundWorker()
        Me.AdbDotNet = New System.ComponentModel.BackgroundWorker()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonFlashApple = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.panelControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl11.SuspendLayout()
        CType(Me.PictureEditSelectedChip.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XFORM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XFORM.SuspendLayout()
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl7.SuspendLayout()
        CType(Me.Progressbar1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Progressbar2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelText.SuspendLayout()
        CType(Me.panelControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl9.SuspendLayout()
        CType(Me.comboUSB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboPort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl4.SuspendLayout()
        CType(Me.panelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl5.SuspendLayout()
        CType(Me.panelControl10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl10.SuspendLayout()
        CType(Me.Combo_AllInOne_DA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboAuth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckAuth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBroom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl1.SuspendLayout()
        CType(Me.panelControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelControl11
        '
        Me.panelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl11.Controls.Add(Me.ButtonFlashApple)
        Me.panelControl11.Controls.Add(Me.TextBox7)
        Me.panelControl11.Controls.Add(Me.PictureEditSelectedChip)
        Me.panelControl11.Controls.Add(Me.ButtonVivoModel)
        Me.panelControl11.Controls.Add(Me.ButtonFlashQc)
        Me.panelControl11.Controls.Add(Me.ButtonSamsungModel)
        Me.panelControl11.Controls.Add(Me.ButtonRealmeModel)
        Me.panelControl11.Controls.Add(Me.SimpleButton2)
        Me.panelControl11.Controls.Add(Me.ButtonFlashMtk)
        Me.panelControl11.Controls.Add(Me.ButtonHuaweiModel)
        Me.panelControl11.Controls.Add(Me.ButtonInfinixModel)
        Me.panelControl11.Controls.Add(Me.ButtonAssusModel)
        Me.panelControl11.Controls.Add(Me.ButtonNokiaModel)
        Me.panelControl11.Controls.Add(Me.ButtonOppoModel)
        Me.panelControl11.Controls.Add(Me.ButtonMeizuModel)
        Me.panelControl11.Controls.Add(Me.ButtonMiModel)
        Me.panelControl11.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelControl11.Location = New System.Drawing.Point(0, 0)
        Me.panelControl11.Name = "panelControl11"
        Me.panelControl11.Size = New System.Drawing.Size(1084, 65)
        Me.panelControl11.TabIndex = 1
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox7.ForeColor = System.Drawing.Color.Honeydew
        Me.TextBox7.Location = New System.Drawing.Point(792, 41)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(82, 14)
        Me.TextBox7.TabIndex = 36
        '
        'PictureEditSelectedChip
        '
        Me.PictureEditSelectedChip.EditValue = Global.Reverse_Tool.My.Resources.Resources.logochipqualcomm
        Me.PictureEditSelectedChip.Location = New System.Drawing.Point(880, 4)
        Me.PictureEditSelectedChip.Name = "PictureEditSelectedChip"
        Me.PictureEditSelectedChip.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEditSelectedChip.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEditSelectedChip.Size = New System.Drawing.Size(199, 53)
        Me.PictureEditSelectedChip.TabIndex = 35
        '
        'ButtonVivoModel
        '
        Me.ButtonVivoModel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.ButtonVivoModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonVivoModel.Appearance.Options.UseBackColor = True
        Me.ButtonVivoModel.Appearance.Options.UseFont = True
        Me.ButtonVivoModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonVivoModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonVivoModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logovivo
        Me.ButtonVivoModel.Location = New System.Drawing.Point(667, 33)
        Me.ButtonVivoModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonVivoModel.Name = "ButtonVivoModel"
        Me.ButtonVivoModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonVivoModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonVivoModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonVivoModel.TabIndex = 34
        '
        'ButtonFlashQc
        '
        Me.ButtonFlashQc.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.ButtonFlashQc.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFlashQc.Appearance.Options.UseBackColor = True
        Me.ButtonFlashQc.Appearance.Options.UseFont = True
        Me.ButtonFlashQc.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonFlashQc.AppearanceHovered.Options.UseFont = True
        Me.ButtonFlashQc.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logoqualcomm
        Me.ButtonFlashQc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonFlashQc.Location = New System.Drawing.Point(115, 4)
        Me.ButtonFlashQc.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonFlashQc.Name = "ButtonFlashQc"
        Me.ButtonFlashQc.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonFlashQc.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonFlashQc.Size = New System.Drawing.Size(105, 26)
        Me.ButtonFlashQc.TabIndex = 32
        '
        'ButtonSamsungModel
        '
        Me.ButtonSamsungModel.Appearance.BackColor = System.Drawing.Color.Navy
        Me.ButtonSamsungModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSamsungModel.Appearance.Options.UseBackColor = True
        Me.ButtonSamsungModel.Appearance.Options.UseFont = True
        Me.ButtonSamsungModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonSamsungModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonSamsungModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logosamsung
        Me.ButtonSamsungModel.Location = New System.Drawing.Point(559, 33)
        Me.ButtonSamsungModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonSamsungModel.Name = "ButtonSamsungModel"
        Me.ButtonSamsungModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonSamsungModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonSamsungModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonSamsungModel.TabIndex = 34
        '
        'ButtonRealmeModel
        '
        Me.ButtonRealmeModel.Appearance.BackColor = System.Drawing.Color.Gray
        Me.ButtonRealmeModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRealmeModel.Appearance.Options.UseBackColor = True
        Me.ButtonRealmeModel.Appearance.Options.UseFont = True
        Me.ButtonRealmeModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonRealmeModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonRealmeModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logorealme
        Me.ButtonRealmeModel.Location = New System.Drawing.Point(451, 33)
        Me.ButtonRealmeModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonRealmeModel.Name = "ButtonRealmeModel"
        Me.ButtonRealmeModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonRealmeModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRealmeModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonRealmeModel.TabIndex = 33
        '
        'ButtonFlashMtk
        '
        Me.ButtonFlashMtk.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonFlashMtk.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFlashMtk.Appearance.Options.UseBackColor = True
        Me.ButtonFlashMtk.Appearance.Options.UseFont = True
        Me.ButtonFlashMtk.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonFlashMtk.AppearanceHovered.Options.UseFont = True
        Me.ButtonFlashMtk.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logomediatek
        Me.ButtonFlashMtk.Location = New System.Drawing.Point(6, 33)
        Me.ButtonFlashMtk.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonFlashMtk.Name = "ButtonFlashMtk"
        Me.ButtonFlashMtk.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonFlashMtk.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonFlashMtk.Size = New System.Drawing.Size(105, 26)
        Me.ButtonFlashMtk.TabIndex = 32
        '
        'ButtonHuaweiModel
        '
        Me.ButtonHuaweiModel.Appearance.BackColor = System.Drawing.Color.Red
        Me.ButtonHuaweiModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonHuaweiModel.Appearance.Options.UseBackColor = True
        Me.ButtonHuaweiModel.Appearance.Options.UseFont = True
        Me.ButtonHuaweiModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonHuaweiModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonHuaweiModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logohuawei
        Me.ButtonHuaweiModel.Location = New System.Drawing.Point(343, 4)
        Me.ButtonHuaweiModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonHuaweiModel.Name = "ButtonHuaweiModel"
        Me.ButtonHuaweiModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonHuaweiModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonHuaweiModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonHuaweiModel.TabIndex = 33
        '
        'ButtonInfinixModel
        '
        Me.ButtonInfinixModel.Appearance.BackColor = System.Drawing.Color.LimeGreen
        Me.ButtonInfinixModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonInfinixModel.Appearance.Options.UseBackColor = True
        Me.ButtonInfinixModel.Appearance.Options.UseFont = True
        Me.ButtonInfinixModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonInfinixModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonInfinixModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logoinfinix
        Me.ButtonInfinixModel.Location = New System.Drawing.Point(451, 4)
        Me.ButtonInfinixModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonInfinixModel.Name = "ButtonInfinixModel"
        Me.ButtonInfinixModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonInfinixModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonInfinixModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonInfinixModel.TabIndex = 32
        '
        'ButtonAssusModel
        '
        Me.ButtonAssusModel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.ButtonAssusModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAssusModel.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.ButtonAssusModel.Appearance.Options.UseBackColor = True
        Me.ButtonAssusModel.Appearance.Options.UseFont = True
        Me.ButtonAssusModel.Appearance.Options.UseForeColor = True
        Me.ButtonAssusModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonAssusModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonAssusModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logoasus
        Me.ButtonAssusModel.Location = New System.Drawing.Point(235, 4)
        Me.ButtonAssusModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonAssusModel.Name = "ButtonAssusModel"
        Me.ButtonAssusModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonAssusModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonAssusModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonAssusModel.TabIndex = 34
        '
        'ButtonNokiaModel
        '
        Me.ButtonNokiaModel.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonNokiaModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNokiaModel.Appearance.Options.UseBackColor = True
        Me.ButtonNokiaModel.Appearance.Options.UseFont = True
        Me.ButtonNokiaModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonNokiaModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonNokiaModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logonokia
        Me.ButtonNokiaModel.Location = New System.Drawing.Point(235, 33)
        Me.ButtonNokiaModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonNokiaModel.Name = "ButtonNokiaModel"
        Me.ButtonNokiaModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonNokiaModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonNokiaModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonNokiaModel.TabIndex = 34
        '
        'ButtonOppoModel
        '
        Me.ButtonOppoModel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.ButtonOppoModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOppoModel.Appearance.Options.UseBackColor = True
        Me.ButtonOppoModel.Appearance.Options.UseFont = True
        Me.ButtonOppoModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonOppoModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonOppoModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logooppo
        Me.ButtonOppoModel.Location = New System.Drawing.Point(343, 33)
        Me.ButtonOppoModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonOppoModel.Name = "ButtonOppoModel"
        Me.ButtonOppoModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonOppoModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonOppoModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonOppoModel.TabIndex = 32
        '
        'ButtonMeizuModel
        '
        Me.ButtonMeizuModel.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonMeizuModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonMeizuModel.Appearance.Options.UseBackColor = True
        Me.ButtonMeizuModel.Appearance.Options.UseFont = True
        Me.ButtonMeizuModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonMeizuModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonMeizuModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logomeizu
        Me.ButtonMeizuModel.Location = New System.Drawing.Point(559, 4)
        Me.ButtonMeizuModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonMeizuModel.Name = "ButtonMeizuModel"
        Me.ButtonMeizuModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonMeizuModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonMeizuModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonMeizuModel.TabIndex = 32
        '
        'ButtonMiModel
        '
        Me.ButtonMiModel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.ButtonMiModel.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonMiModel.Appearance.Options.UseBackColor = True
        Me.ButtonMiModel.Appearance.Options.UseFont = True
        Me.ButtonMiModel.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonMiModel.AppearanceHovered.Options.UseFont = True
        Me.ButtonMiModel.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logomi
        Me.ButtonMiModel.Location = New System.Drawing.Point(667, 4)
        Me.ButtonMiModel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonMiModel.Name = "ButtonMiModel"
        Me.ButtonMiModel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonMiModel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonMiModel.Size = New System.Drawing.Size(105, 26)
        Me.ButtonMiModel.TabIndex = 33
        '
        'XFORM
        '
        Me.XFORM.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.XFORM.Controls.Add(Me.panelControl7)
        Me.XFORM.Controls.Add(Me.panelControl6)
        Me.XFORM.Controls.Add(Me.FormCtrl)
        Me.XFORM.Controls.Add(Me.panelControl4)
        Me.XFORM.Location = New System.Drawing.Point(5, 65)
        Me.XFORM.Name = "XFORM"
        Me.XFORM.Size = New System.Drawing.Size(1074, 509)
        Me.XFORM.TabIndex = 0
        '
        'panelControl7
        '
        Me.panelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl7.Controls.Add(Me.Progressbar1)
        Me.panelControl7.Controls.Add(Me.Progressbar2)
        Me.panelControl7.Controls.Add(Me.ButtonSTOP)
        Me.panelControl7.Controls.Add(Me.PanelText)
        Me.panelControl7.Controls.Add(Me.panelControl9)
        Me.panelControl7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelControl7.Location = New System.Drawing.Point(658, 28)
        Me.panelControl7.Name = "panelControl7"
        Me.panelControl7.Size = New System.Drawing.Size(416, 481)
        Me.panelControl7.TabIndex = 5
        '
        'Progressbar1
        '
        Me.Progressbar1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Progressbar1.EditValue = 100
        Me.Progressbar1.Location = New System.Drawing.Point(4, 432)
        Me.Progressbar1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Progressbar1.Name = "Progressbar1"
        Me.Progressbar1.Properties.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.Progressbar1.Properties.Appearance.Font = New System.Drawing.Font("Cambria", 7.25!, System.Drawing.FontStyle.Bold)
        Me.Progressbar1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Progressbar1.Properties.EndColor = System.Drawing.Color.Red
        Me.Progressbar1.Properties.LookAndFeel.SkinName = "Metropolis Dark"
        Me.Progressbar1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D
        Me.Progressbar1.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Progressbar1.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.Progressbar1.Properties.ShowTitle = True
        Me.Progressbar1.Properties.StartColor = System.Drawing.Color.DarkRed
        Me.Progressbar1.Size = New System.Drawing.Size(335, 20)
        Me.Progressbar1.TabIndex = 57
        '
        'Progressbar2
        '
        Me.Progressbar2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Progressbar2.EditValue = 100
        Me.Progressbar2.Location = New System.Drawing.Point(4, 455)
        Me.Progressbar2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Progressbar2.Name = "Progressbar2"
        Me.Progressbar2.Properties.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.Progressbar2.Properties.Appearance.Font = New System.Drawing.Font("Cambria", 7.25!, System.Drawing.FontStyle.Bold)
        Me.Progressbar2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Progressbar2.Properties.EndColor = System.Drawing.Color.Red
        Me.Progressbar2.Properties.LookAndFeel.SkinName = "Metropolis Dark"
        Me.Progressbar2.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D
        Me.Progressbar2.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Progressbar2.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.Progressbar2.Properties.ShowTitle = True
        Me.Progressbar2.Properties.StartColor = System.Drawing.Color.DarkRed
        Me.Progressbar2.Size = New System.Drawing.Size(335, 20)
        Me.Progressbar2.TabIndex = 58
        '
        'ButtonSTOP
        '
        Me.ButtonSTOP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ButtonSTOP.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSTOP.Appearance.Options.UseBackColor = True
        Me.ButtonSTOP.Appearance.Options.UseFont = True
        Me.ButtonSTOP.Appearance.Options.UseTextOptions = True
        Me.ButtonSTOP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ButtonSTOP.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSTOP.AppearanceHovered.Options.UseFont = True
        Me.ButtonSTOP.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.ButtonSTOP.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSTOP.ImageOptions.Image = CType(resources.GetObject("ButtonSTOP.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonSTOP.Location = New System.Drawing.Point(341, 431)
        Me.ButtonSTOP.Name = "ButtonSTOP"
        Me.ButtonSTOP.Size = New System.Drawing.Size(72, 44)
        Me.ButtonSTOP.TabIndex = 33
        Me.ButtonSTOP.Text = "STOP "
        '
        'PanelText
        '
        Me.PanelText.Controls.Add(Me.RichTextBox)
        Me.PanelText.Location = New System.Drawing.Point(0, 58)
        Me.PanelText.Name = "PanelText"
        Me.PanelText.Size = New System.Drawing.Size(415, 369)
        Me.PanelText.TabIndex = 1
        '
        'RichTextBox
        '
        Me.RichTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.RichTextBox.Location = New System.Drawing.Point(2, 2)
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.RichTextBox.Size = New System.Drawing.Size(411, 365)
        Me.RichTextBox.TabIndex = 0
        Me.RichTextBox.Text = ""
        Me.RichTextBox.WordWrap = False
        '
        'panelControl9
        '
        Me.panelControl9.Controls.Add(Me.labelControlADBIdent)
        Me.panelControl9.Controls.Add(Me.labelControlRefresh)
        Me.panelControl9.Controls.Add(Me.LabUSB)
        Me.panelControl9.Controls.Add(Me.LabelPort)
        Me.panelControl9.Controls.Add(Me.comboUSB)
        Me.panelControl9.Controls.Add(Me.ComboPort)
        Me.panelControl9.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelControl9.Location = New System.Drawing.Point(0, 0)
        Me.panelControl9.Name = "panelControl9"
        Me.panelControl9.Size = New System.Drawing.Size(416, 52)
        Me.panelControl9.TabIndex = 0
        '
        'labelControlADBIdent
        '
        Me.labelControlADBIdent.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.labelControlADBIdent.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.labelControlADBIdent.Appearance.Options.UseBackColor = True
        Me.labelControlADBIdent.Appearance.Options.UseFont = True
        Me.labelControlADBIdent.Appearance.Options.UseTextOptions = True
        Me.labelControlADBIdent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.labelControlADBIdent.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.labelControlADBIdent.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.labelControlADBIdent.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelControlADBIdent.AppearanceHovered.Options.UseBackColor = True
        Me.labelControlADBIdent.AppearanceHovered.Options.UseFont = True
        Me.labelControlADBIdent.AppearanceHovered.Options.UseForeColor = True
        Me.labelControlADBIdent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labelControlADBIdent.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.labelControlADBIdent.ImageOptions.Image = CType(resources.GetObject("labelControlADBIdent.ImageOptions.Image"), System.Drawing.Image)
        Me.labelControlADBIdent.Location = New System.Drawing.Point(326, 28)
        Me.labelControlADBIdent.Name = "labelControlADBIdent"
        Me.labelControlADBIdent.Size = New System.Drawing.Size(85, 20)
        Me.labelControlADBIdent.TabIndex = 35
        Me.labelControlADBIdent.Text = "     IDENTIFY"
        '
        'labelControlRefresh
        '
        Me.labelControlRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.labelControlRefresh.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.labelControlRefresh.Appearance.Options.UseBackColor = True
        Me.labelControlRefresh.Appearance.Options.UseFont = True
        Me.labelControlRefresh.Appearance.Options.UseTextOptions = True
        Me.labelControlRefresh.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.labelControlRefresh.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.labelControlRefresh.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.labelControlRefresh.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelControlRefresh.AppearanceHovered.Options.UseBackColor = True
        Me.labelControlRefresh.AppearanceHovered.Options.UseFont = True
        Me.labelControlRefresh.AppearanceHovered.Options.UseForeColor = True
        Me.labelControlRefresh.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labelControlRefresh.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.labelControlRefresh.ImageOptions.Image = CType(resources.GetObject("labelControlRefresh.ImageOptions.Image"), System.Drawing.Image)
        Me.labelControlRefresh.Location = New System.Drawing.Point(326, 5)
        Me.labelControlRefresh.Name = "labelControlRefresh"
        Me.labelControlRefresh.Size = New System.Drawing.Size(85, 20)
        Me.labelControlRefresh.TabIndex = 34
        Me.labelControlRefresh.Text = "     REFRESH"
        '
        'LabUSB
        '
        Me.LabUSB.Location = New System.Drawing.Point(11, 31)
        Me.LabUSB.Name = "LabUSB"
        Me.LabUSB.Size = New System.Drawing.Size(32, 13)
        Me.LabUSB.TabIndex = 0
        Me.LabUSB.Text = "USB   :"
        '
        'LabelPort
        '
        Me.LabelPort.Location = New System.Drawing.Point(9, 9)
        Me.LabelPort.Name = "LabelPort"
        Me.LabelPort.Size = New System.Drawing.Size(34, 13)
        Me.LabelPort.TabIndex = 0
        Me.LabelPort.Text = "PORT :"
        '
        'comboUSB
        '
        Me.comboUSB.Location = New System.Drawing.Point(47, 28)
        Me.comboUSB.Name = "comboUSB"
        Me.comboUSB.Properties.AllowFocused = False
        Me.comboUSB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.comboUSB.Properties.Appearance.BorderColor = System.Drawing.Color.DarkRed
        Me.comboUSB.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.comboUSB.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.comboUSB.Properties.Appearance.Options.UseBackColor = True
        Me.comboUSB.Properties.Appearance.Options.UseBorderColor = True
        Me.comboUSB.Properties.Appearance.Options.UseFont = True
        Me.comboUSB.Properties.Appearance.Options.UseForeColor = True
        Me.comboUSB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.comboUSB.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.comboUSB.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.comboUSB.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.comboUSB.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.comboUSB.Size = New System.Drawing.Size(275, 20)
        Me.comboUSB.TabIndex = 56
        '
        'ComboPort
        '
        Me.ComboPort.Location = New System.Drawing.Point(47, 5)
        Me.ComboPort.Name = "ComboPort"
        Me.ComboPort.Properties.AllowFocused = False
        Me.ComboPort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ComboPort.Properties.Appearance.BorderColor = System.Drawing.Color.DarkRed
        Me.ComboPort.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.ComboPort.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ComboPort.Properties.Appearance.Options.UseBackColor = True
        Me.ComboPort.Properties.Appearance.Options.UseBorderColor = True
        Me.ComboPort.Properties.Appearance.Options.UseFont = True
        Me.ComboPort.Properties.Appearance.Options.UseForeColor = True
        Me.ComboPort.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboPort.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ComboPort.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboPort.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboPort.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboPort.Size = New System.Drawing.Size(275, 20)
        Me.ComboPort.TabIndex = 56
        '
        'panelControl6
        '
        Me.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl6.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelControl6.Location = New System.Drawing.Point(653, 28)
        Me.panelControl6.Name = "panelControl6"
        Me.panelControl6.Size = New System.Drawing.Size(5, 481)
        Me.panelControl6.TabIndex = 4
        '
        'FormCtrl
        '
        Me.FormCtrl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.FormCtrl.Dock = System.Windows.Forms.DockStyle.Left
        Me.FormCtrl.Location = New System.Drawing.Point(0, 28)
        Me.FormCtrl.Name = "FormCtrl"
        Me.FormCtrl.Size = New System.Drawing.Size(653, 481)
        Me.FormCtrl.TabIndex = 1
        '
        'panelControl4
        '
        Me.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl4.Controls.Add(Me.LabelTimer)
        Me.panelControl4.Controls.Add(Me.LabelControlISPDirect)
        Me.panelControl4.Controls.Add(Me.LabelControlFastboot)
        Me.panelControl4.Controls.Add(Me.LabelControlADBManager)
        Me.panelControl4.Controls.Add(Me.labelControl2)
        Me.panelControl4.Controls.Add(Me.labelControlFlash)
        Me.panelControl4.Controls.Add(Me.panelControl5)
        Me.panelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelControl4.Location = New System.Drawing.Point(0, 0)
        Me.panelControl4.Name = "panelControl4"
        Me.panelControl4.Size = New System.Drawing.Size(1074, 28)
        Me.panelControl4.TabIndex = 0
        '
        'LabelTimer
        '
        Me.LabelTimer.AutoSize = True
        Me.LabelTimer.Location = New System.Drawing.Point(637, 7)
        Me.LabelTimer.Name = "LabelTimer"
        Me.LabelTimer.Size = New System.Drawing.Size(0, 13)
        Me.LabelTimer.TabIndex = 33
        Me.LabelTimer.Visible = False
        '
        'LabelControlISPDirect
        '
        Me.LabelControlISPDirect.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.LabelControlISPDirect.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.LabelControlISPDirect.Appearance.Options.UseBackColor = True
        Me.LabelControlISPDirect.Appearance.Options.UseFont = True
        Me.LabelControlISPDirect.Appearance.Options.UseTextOptions = True
        Me.LabelControlISPDirect.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControlISPDirect.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.LabelControlISPDirect.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.LabelControlISPDirect.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControlISPDirect.AppearanceHovered.Options.UseBackColor = True
        Me.LabelControlISPDirect.AppearanceHovered.Options.UseFont = True
        Me.LabelControlISPDirect.AppearanceHovered.Options.UseForeColor = True
        Me.LabelControlISPDirect.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControlISPDirect.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelControlISPDirect.ImageOptions.Image = Global.Reverse_Tool.My.Resources.Resources.Safe22
        Me.LabelControlISPDirect.Location = New System.Drawing.Point(519, 4)
        Me.LabelControlISPDirect.Name = "LabelControlISPDirect"
        Me.LabelControlISPDirect.Size = New System.Drawing.Size(122, 20)
        Me.LabelControlISPDirect.TabIndex = 34
        Me.LabelControlISPDirect.Text = "DIRECT ISP"
        '
        'LabelControlFastboot
        '
        Me.LabelControlFastboot.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.LabelControlFastboot.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.LabelControlFastboot.Appearance.Options.UseBackColor = True
        Me.LabelControlFastboot.Appearance.Options.UseFont = True
        Me.LabelControlFastboot.Appearance.Options.UseTextOptions = True
        Me.LabelControlFastboot.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControlFastboot.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.LabelControlFastboot.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.LabelControlFastboot.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControlFastboot.AppearanceHovered.Options.UseBackColor = True
        Me.LabelControlFastboot.AppearanceHovered.Options.UseFont = True
        Me.LabelControlFastboot.AppearanceHovered.Options.UseForeColor = True
        Me.LabelControlFastboot.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControlFastboot.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelControlFastboot.ImageOptions.Image = Global.Reverse_Tool.My.Resources.Resources.Readinfo22
        Me.LabelControlFastboot.Location = New System.Drawing.Point(391, 4)
        Me.LabelControlFastboot.Name = "LabelControlFastboot"
        Me.LabelControlFastboot.Size = New System.Drawing.Size(122, 20)
        Me.LabelControlFastboot.TabIndex = 34
        Me.LabelControlFastboot.Text = "FASTBOOT"
        '
        'LabelControlADBManager
        '
        Me.LabelControlADBManager.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.LabelControlADBManager.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.LabelControlADBManager.Appearance.Options.UseBackColor = True
        Me.LabelControlADBManager.Appearance.Options.UseFont = True
        Me.LabelControlADBManager.Appearance.Options.UseTextOptions = True
        Me.LabelControlADBManager.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControlADBManager.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.LabelControlADBManager.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.LabelControlADBManager.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControlADBManager.AppearanceHovered.Options.UseBackColor = True
        Me.LabelControlADBManager.AppearanceHovered.Options.UseFont = True
        Me.LabelControlADBManager.AppearanceHovered.Options.UseForeColor = True
        Me.LabelControlADBManager.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControlADBManager.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelControlADBManager.ImageOptions.Image = Global.Reverse_Tool.My.Resources.Resources.cyber
        Me.LabelControlADBManager.Location = New System.Drawing.Point(263, 4)
        Me.LabelControlADBManager.Name = "LabelControlADBManager"
        Me.LabelControlADBManager.Size = New System.Drawing.Size(122, 20)
        Me.LabelControlADBManager.TabIndex = 34
        Me.LabelControlADBManager.Text = "ADB MANAGER"
        '
        'labelControl2
        '
        Me.labelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.labelControl2.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.labelControl2.Appearance.Options.UseBackColor = True
        Me.labelControl2.Appearance.Options.UseFont = True
        Me.labelControl2.Appearance.Options.UseTextOptions = True
        Me.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.labelControl2.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.labelControl2.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.labelControl2.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelControl2.AppearanceHovered.Options.UseBackColor = True
        Me.labelControl2.AppearanceHovered.Options.UseFont = True
        Me.labelControl2.AppearanceHovered.Options.UseForeColor = True
        Me.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labelControl2.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.labelControl2.ImageOptions.Image = CType(resources.GetObject("labelControl2.ImageOptions.Image"), System.Drawing.Image)
        Me.labelControl2.Location = New System.Drawing.Point(135, 4)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(122, 20)
        Me.labelControl2.TabIndex = 32
        Me.labelControl2.Text = "UNLOCK"
        '
        'labelControlFlash
        '
        Me.labelControlFlash.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.labelControlFlash.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.labelControlFlash.Appearance.Options.UseBackColor = True
        Me.labelControlFlash.Appearance.Options.UseFont = True
        Me.labelControlFlash.Appearance.Options.UseTextOptions = True
        Me.labelControlFlash.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.labelControlFlash.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.labelControlFlash.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.labelControlFlash.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelControlFlash.AppearanceHovered.Options.UseBackColor = True
        Me.labelControlFlash.AppearanceHovered.Options.UseFont = True
        Me.labelControlFlash.AppearanceHovered.Options.UseForeColor = True
        Me.labelControlFlash.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.labelControlFlash.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.labelControlFlash.ImageOptions.Image = CType(resources.GetObject("labelControlFlash.ImageOptions.Image"), System.Drawing.Image)
        Me.labelControlFlash.Location = New System.Drawing.Point(7, 4)
        Me.labelControlFlash.Name = "labelControlFlash"
        Me.labelControlFlash.Size = New System.Drawing.Size(122, 20)
        Me.labelControlFlash.TabIndex = 32
        Me.labelControlFlash.Text = "FLASH"
        '
        'panelControl5
        '
        Me.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl5.Controls.Add(Me.panelControl10)
        Me.panelControl5.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelControl5.Location = New System.Drawing.Point(658, 0)
        Me.panelControl5.Name = "panelControl5"
        Me.panelControl5.Size = New System.Drawing.Size(416, 28)
        Me.panelControl5.TabIndex = 31
        '
        'panelControl10
        '
        Me.panelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl10.Controls.Add(Me.Combo_AllInOne_DA)
        Me.panelControl10.Controls.Add(Me.ComboAuth)
        Me.panelControl10.Controls.Add(Me.labelControl5)
        Me.panelControl10.Controls.Add(Me.labelControl4)
        Me.panelControl10.Controls.Add(Me.CheckAuth)
        Me.panelControl10.Controls.Add(Me.labelControl3)
        Me.panelControl10.Controls.Add(Me.ComboBroom)
        Me.panelControl10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelControl10.Location = New System.Drawing.Point(0, 0)
        Me.panelControl10.Name = "panelControl10"
        Me.panelControl10.Size = New System.Drawing.Size(416, 28)
        Me.panelControl10.TabIndex = 52
        '
        'Combo_AllInOne_DA
        '
        Me.Combo_AllInOne_DA.EditValue = "Auto"
        Me.Combo_AllInOne_DA.Location = New System.Drawing.Point(211, 5)
        Me.Combo_AllInOne_DA.Name = "Combo_AllInOne_DA"
        Me.Combo_AllInOne_DA.Properties.AllowFocused = False
        Me.Combo_AllInOne_DA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.Combo_AllInOne_DA.Properties.Appearance.BorderColor = System.Drawing.Color.DarkRed
        Me.Combo_AllInOne_DA.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.Combo_AllInOne_DA.Properties.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Combo_AllInOne_DA.Properties.Appearance.Options.UseBackColor = True
        Me.Combo_AllInOne_DA.Properties.Appearance.Options.UseBorderColor = True
        Me.Combo_AllInOne_DA.Properties.Appearance.Options.UseFont = True
        Me.Combo_AllInOne_DA.Properties.Appearance.Options.UseForeColor = True
        Me.Combo_AllInOne_DA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Combo_AllInOne_DA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.Combo_AllInOne_DA.Properties.Items.AddRange(New Object() {"Auto", "MTK_AllInOne_DA.bin", "MTK_AllInOne_DA_.bin", "MTK_AllInOne_DA_4-19_-signed.bin", "MTK_AllInOne_DA_5.1420.bin", "MTK_AllInOne_DA_5.1824.bin", "MTK_AllInOne_DA_5.2136.bin", "MTK_AllInOne_DA_5.2152.bin", "MTK_AllInOne_DA_sig.bin", "MTK_AllInOne_DAA.bin", "MTK_OPPO_DA.bin", "MTK_XIAOMI_DA_6765_6785_6768_6873_6885_6853.bin"})
        Me.Combo_AllInOne_DA.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.Combo_AllInOne_DA.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Combo_AllInOne_DA.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.Combo_AllInOne_DA.Size = New System.Drawing.Size(113, 20)
        Me.Combo_AllInOne_DA.TabIndex = 27
        '
        'ComboAuth
        '
        Me.ComboAuth.EditValue = "Auto"
        Me.ComboAuth.Location = New System.Drawing.Point(355, 5)
        Me.ComboAuth.Name = "ComboAuth"
        Me.ComboAuth.Properties.AllowFocused = False
        Me.ComboAuth.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ComboAuth.Properties.Appearance.BorderColor = System.Drawing.Color.DarkRed
        Me.ComboAuth.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.ComboAuth.Properties.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ComboAuth.Properties.Appearance.Options.UseBackColor = True
        Me.ComboAuth.Properties.Appearance.Options.UseBorderColor = True
        Me.ComboAuth.Properties.Appearance.Options.UseFont = True
        Me.ComboAuth.Properties.Appearance.Options.UseForeColor = True
        Me.ComboAuth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboAuth.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ComboAuth.Properties.Items.AddRange(New Object() {"Auto", "Usbdk"})
        Me.ComboAuth.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboAuth.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboAuth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboAuth.Size = New System.Drawing.Size(57, 20)
        Me.ComboAuth.TabIndex = 27
        '
        'labelControl5
        '
        Me.labelControl5.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.labelControl5.Appearance.Options.UseFont = True
        Me.labelControl5.Location = New System.Drawing.Point(330, 8)
        Me.labelControl5.Name = "labelControl5"
        Me.labelControl5.Size = New System.Drawing.Size(19, 13)
        Me.labelControl5.TabIndex = 22
        Me.labelControl5.Text = "Auth"
        '
        'labelControl4
        '
        Me.labelControl4.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.labelControl4.Appearance.Options.UseFont = True
        Me.labelControl4.Location = New System.Drawing.Point(190, 8)
        Me.labelControl4.Name = "labelControl4"
        Me.labelControl4.Size = New System.Drawing.Size(15, 13)
        Me.labelControl4.TabIndex = 22
        Me.labelControl4.Text = "DA "
        '
        'CheckAuth
        '
        Me.CheckAuth.EditValue = True
        Me.CheckAuth.Location = New System.Drawing.Point(5, 5)
        Me.CheckAuth.Name = "CheckAuth"
        Me.CheckAuth.Properties.AllowFocused = False
        Me.CheckAuth.Properties.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.CheckAuth.Properties.Appearance.Options.UseFont = True
        Me.CheckAuth.Properties.Caption = "Auth"
        Me.CheckAuth.Size = New System.Drawing.Size(41, 18)
        Me.CheckAuth.TabIndex = 0
        '
        'labelControl3
        '
        Me.labelControl3.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.labelControl3.Appearance.Options.UseFont = True
        Me.labelControl3.Location = New System.Drawing.Point(52, 8)
        Me.labelControl3.Name = "labelControl3"
        Me.labelControl3.Size = New System.Drawing.Size(25, 13)
        Me.labelControl3.TabIndex = 35
        Me.labelControl3.Text = "BROM"
        '
        'ComboBroom
        '
        Me.ComboBroom.EditValue = " V7.2216.00"
        Me.ComboBroom.Location = New System.Drawing.Point(92, 5)
        Me.ComboBroom.Name = "ComboBroom"
        Me.ComboBroom.Properties.AllowFocused = False
        Me.ComboBroom.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ComboBroom.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.ComboBroom.Properties.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ComboBroom.Properties.Appearance.Options.UseBackColor = True
        Me.ComboBroom.Properties.Appearance.Options.UseFont = True
        Me.ComboBroom.Properties.Appearance.Options.UseForeColor = True
        Me.ComboBroom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBroom.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ComboBroom.Properties.Items.AddRange(New Object() {"V7.2209.00"})
        Me.ComboBroom.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboBroom.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboBroom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboBroom.Size = New System.Drawing.Size(90, 20)
        Me.ComboBroom.TabIndex = 23
        '
        'panelControl1
        '
        Me.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl1.Controls.Add(Me.LabelTime)
        Me.panelControl1.Controls.Add(Me.panelControl8)
        Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelControl1.Location = New System.Drawing.Point(0, 583)
        Me.panelControl1.Name = "panelControl1"
        Me.panelControl1.Size = New System.Drawing.Size(1084, 33)
        Me.panelControl1.TabIndex = 6
        '
        'LabelTime
        '
        Me.LabelTime.Appearance.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.LabelTime.Appearance.ForeColor = System.Drawing.Color.Moccasin
        Me.LabelTime.Appearance.Options.UseFont = True
        Me.LabelTime.Appearance.Options.UseForeColor = True
        Me.LabelTime.Location = New System.Drawing.Point(1011, 10)
        Me.LabelTime.Name = "LabelTime"
        Me.LabelTime.Size = New System.Drawing.Size(56, 15)
        Me.LabelTime.TabIndex = 1
        Me.LabelTime.Text = "00:00:00"
        '
        'panelControl8
        '
        Me.panelControl8.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.panelControl8.Appearance.Options.UseBackColor = True
        Me.panelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl8.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelControl8.Location = New System.Drawing.Point(0, 0)
        Me.panelControl8.Name = "panelControl8"
        Me.panelControl8.Size = New System.Drawing.Size(1084, 2)
        Me.panelControl8.TabIndex = 0
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'TimerTime
        '
        Me.TimerTime.Enabled = True
        '
        'Flashtool_Doworker
        '
        Me.Flashtool_Doworker.WorkerReportsProgress = True
        Me.Flashtool_Doworker.WorkerSupportsCancellation = True
        '
        'AdbDotNet
        '
        Me.AdbDotNet.WorkerReportsProgress = True
        Me.AdbDotNet.WorkerSupportsCancellation = True
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton2.AppearanceHovered.Options.UseFont = True
        Me.SimpleButton2.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logospreadtrum
        Me.SimpleButton2.Location = New System.Drawing.Point(115, 33)
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.SimpleButton2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.SimpleButton2.Size = New System.Drawing.Size(105, 26)
        Me.SimpleButton2.TabIndex = 32
        '
        'ButtonFlashApple
        '
        Me.ButtonFlashApple.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.ButtonFlashApple.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFlashApple.Appearance.Options.UseBackColor = True
        Me.ButtonFlashApple.Appearance.Options.UseFont = True
        Me.ButtonFlashApple.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ButtonFlashApple.AppearanceHovered.Options.UseFont = True
        Me.ButtonFlashApple.BackgroundImage = Global.Reverse_Tool.My.Resources.Resources.logoapple
        Me.ButtonFlashApple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonFlashApple.Location = New System.Drawing.Point(6, 4)
        Me.ButtonFlashApple.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonFlashApple.Name = "ButtonFlashApple"
        Me.ButtonFlashApple.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonFlashApple.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonFlashApple.Size = New System.Drawing.Size(105, 26)
        Me.ButtonFlashApple.TabIndex = 32
        '
        'Main
        '
        Me.ActiveGlowColor = System.Drawing.Color.Red
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 616)
        Me.Controls.Add(Me.panelControl1)
        Me.Controls.Add(Me.XFORM)
        Me.Controls.Add(Me.panelControl11)
        Me.DoubleBuffered = True
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.Image = Global.Reverse_Tool.My.Resources.Resources.logoireverse
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "iREVERSE DROID ULTIMATE - @HadiKIT"
        CType(Me.panelControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl11.ResumeLayout(False)
        Me.panelControl11.PerformLayout()
        CType(Me.PictureEditSelectedChip.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XFORM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XFORM.ResumeLayout(False)
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl7.ResumeLayout(False)
        CType(Me.Progressbar1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Progressbar2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelText.ResumeLayout(False)
        CType(Me.panelControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl9.ResumeLayout(False)
        Me.panelControl9.PerformLayout()
        CType(Me.comboUSB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboPort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl4.ResumeLayout(False)
        Me.panelControl4.PerformLayout()
        CType(Me.panelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl5.ResumeLayout(False)
        CType(Me.panelControl10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl10.ResumeLayout(False)
        Me.panelControl10.PerformLayout()
        CType(Me.Combo_AllInOne_DA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboAuth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckAuth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBroom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl1.ResumeLayout(False)
        Me.panelControl1.PerformLayout()
        CType(Me.panelControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panelControl11 As PanelControl
    Private WithEvents ButtonFlashMtk As SimpleButton
    Private WithEvents ButtonVivoModel As SimpleButton
    Private WithEvents ButtonAssusModel As SimpleButton
    Private WithEvents ButtonInfinixModel As SimpleButton
    Private WithEvents ButtonNokiaModel As SimpleButton
    Private WithEvents ButtonSamsungModel As SimpleButton
    Private WithEvents ButtonOppoModel As SimpleButton
    Private WithEvents ButtonMeizuModel As SimpleButton
    Private WithEvents ButtonHuaweiModel As SimpleButton
    Private WithEvents ButtonMiModel As SimpleButton
    Private WithEvents ButtonRealmeModel As SimpleButton
    Private WithEvents XFORM As PanelControl
    Private WithEvents panelControl7 As PanelControl
    Private WithEvents PanelText As PanelControl
    Private WithEvents panelControl9 As PanelControl

    Private WithEvents LabUSB As LabelControl
    Private WithEvents LabelPort As LabelControl
    Private WithEvents panelControl6 As PanelControl
    Private WithEvents FormCtrl As PanelControl
    Private WithEvents panelControl4 As PanelControl
    Private WithEvents labelControl2 As LabelControl
    Private WithEvents labelControlFlash As LabelControl
    Private WithEvents panelControl5 As PanelControl
    Private WithEvents panelControl10 As PanelControl
    Private WithEvents Combo_AllInOne_DA As ComboBoxEdit
    Private WithEvents labelControl5 As LabelControl
    Private WithEvents labelControl4 As LabelControl
    Private WithEvents labelControl3 As LabelControl
    Private WithEvents ComboBroom As ComboBoxEdit
    Private WithEvents panelControl1 As PanelControl
    Private WithEvents LabelTime As LabelControl
    Private WithEvents panelControl8 As PanelControl

    Public Shared RichTextBoxJSON As RichTextBox
    Friend WithEvents Flashtool_Doworker As BackgroundWorker
    Public WithEvents LabelTimer As Label
    Public WithEvents Progressbar1 As ProgressBarControl
    Public WithEvents Progressbar2 As ProgressBarControl
    Public WithEvents CheckAuth As CheckEdit
    Public WithEvents labelControlRefresh As LabelControl
    Public WithEvents ComboPort As ComboBoxEdit
    Public WithEvents ComboAuth As ComboBoxEdit
    Public WithEvents RichTextBox As RichTextBox
    Public WithEvents AdbPython As BackgroundWorker
    Public WithEvents ButtonSTOP As LabelControl
    Friend WithEvents PictureEditSelectedChip As PictureEdit
    Private WithEvents ButtonFlashQc As SimpleButton
    Public WithEvents comboUSB As ComboBoxEdit
    Public WithEvents labelControlADBIdent As LabelControl
    Public WithEvents TextBox7 As TextBox
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents TimerTime As System.Windows.Forms.Timer
    Private WithEvents ButtonFlashApple As SimpleButton
    Private WithEvents SimpleButton2 As SimpleButton
End Class
