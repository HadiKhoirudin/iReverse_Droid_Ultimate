Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports System.IO

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MtkUnlock
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
        Me.components = New System.ComponentModel.Container()
        Dim ItemTemplateBase1 As DevExpress.XtraEditors.TableLayout.ItemTemplateBase = New DevExpress.XtraEditors.TableLayout.ItemTemplateBase()
        Dim TableColumnDefinition1 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New DevExpress.XtraEditors.TableLayout.TableColumnDefinition()
        Dim TemplatedItemElement1 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement2 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement3 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement4 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement5 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement6 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TableRowDefinition1 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition2 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MtkUnlock))
        Me.BackGround = New DevExpress.XtraEditors.PanelControl()
        Me.BableImei = New DevExpress.XtraEditors.LabelControl()
        Me.BableSafe = New DevExpress.XtraEditors.LabelControl()
        Me.BableMeta = New DevExpress.XtraEditors.LabelControl()
        Me.panelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.labelTotal = New DevExpress.XtraEditors.LabelControl()
        Me.lLabelInt = New DevExpress.XtraEditors.LabelControl()
        Me.BableUniBrom = New DevExpress.XtraEditors.LabelControl()
        Me.SearchControl1 = New DevExpress.XtraEditors.SearchControl()
        Me.ListBoxview = New DevExpress.XtraEditors.ListBoxControl()
        Me.Ground = New DevExpress.XtraEditors.PanelControl()
        Me.xtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.UI_Unibrom = New DevExpress.XtraEditors.PanelControl()
        Me.groupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.groupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.simpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.simpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.groupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.xtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.UI_Safeformat = New DevExpress.XtraEditors.PanelControl()
        Me.xtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.xtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.UiMEI = New DevExpress.XtraEditors.PanelControl()
        Me.ButtonIMEI = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonBP = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonAP = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEditBP = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditAP = New DevExpress.XtraEditors.TextEdit()
        Me.CheckIMEI2 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckIMEI1 = New DevExpress.XtraEditors.CheckEdit()
        Me.ValidIMEI2 = New DevExpress.XtraEditors.TextEdit()
        Me.ValidIMEI1 = New DevExpress.XtraEditors.TextEdit()
        Me.Text_IMEI2 = New DevExpress.XtraEditors.TextEdit()
        Me.Text_IMEI1 = New DevExpress.XtraEditors.TextEdit()
        Me.ControList = New DevExpress.XtraEditors.PanelControl()
        Me.BgwUnlocked = New System.ComponentModel.BackgroundWorker()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        CType(Me.BackGround, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BackGround.SuspendLayout()
        CType(Me.panelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl4.SuspendLayout()
        CType(Me.SearchControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListBoxview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ground.SuspendLayout()
        CType(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtraTabControl1.SuspendLayout()
        Me.xtraTabPage1.SuspendLayout()
        CType(Me.UI_Unibrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UI_Unibrom.SuspendLayout()
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupControl2.SuspendLayout()
        CType(Me.groupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupControl1.SuspendLayout()
        Me.xtraTabPage2.SuspendLayout()
        CType(Me.UI_Safeformat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtraTabPage4.SuspendLayout()
        CType(Me.UiMEI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiMEI.SuspendLayout()
        CType(Me.TextEditBP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditAP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckIMEI2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckIMEI1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidIMEI2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidIMEI1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text_IMEI2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Text_IMEI1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControList.SuspendLayout()
        Me.SuspendLayout()
        '
        'BackGround
        '
        Me.BackGround.Controls.Add(Me.BableImei)
        Me.BackGround.Controls.Add(Me.BableSafe)
        Me.BackGround.Controls.Add(Me.BableMeta)
        Me.BackGround.Controls.Add(Me.panelControl4)
        Me.BackGround.Controls.Add(Me.BableUniBrom)
        Me.BackGround.Controls.Add(Me.SearchControl1)
        Me.BackGround.Controls.Add(Me.Ground)
        Me.BackGround.Controls.Add(Me.ControList)
        Me.BackGround.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BackGround.Location = New System.Drawing.Point(0, 0)
        Me.BackGround.Name = "BackGround"
        Me.BackGround.Size = New System.Drawing.Size(653, 482)
        Me.BackGround.TabIndex = 1
        '
        'BableImei
        '
        Me.BableImei.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BableImei.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BableImei.Appearance.Options.UseBackColor = True
        Me.BableImei.Appearance.Options.UseFont = True
        Me.BableImei.Appearance.Options.UseTextOptions = True
        Me.BableImei.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BableImei.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.BableImei.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.BableImei.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BableImei.AppearanceHovered.Options.UseBackColor = True
        Me.BableImei.AppearanceHovered.Options.UseFont = True
        Me.BableImei.AppearanceHovered.Options.UseForeColor = True
        Me.BableImei.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.BableImei.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.BableImei.Location = New System.Drawing.Point(565, 4)
        Me.BableImei.Name = "BableImei"
        Me.BableImei.Size = New System.Drawing.Size(85, 20)
        Me.BableImei.TabIndex = 33
        Me.BableImei.Text = "REPAIR"
        '
        'BableSafe
        '
        Me.BableSafe.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BableSafe.Appearance.Font = New System.Drawing.Font("Corbel", 7.25!, System.Drawing.FontStyle.Bold)
        Me.BableSafe.Appearance.Options.UseBackColor = True
        Me.BableSafe.Appearance.Options.UseFont = True
        Me.BableSafe.Appearance.Options.UseTextOptions = True
        Me.BableSafe.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BableSafe.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.BableSafe.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.BableSafe.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BableSafe.AppearanceHovered.Options.UseBackColor = True
        Me.BableSafe.AppearanceHovered.Options.UseFont = True
        Me.BableSafe.AppearanceHovered.Options.UseForeColor = True
        Me.BableSafe.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.BableSafe.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.BableSafe.Location = New System.Drawing.Point(389, 4)
        Me.BableSafe.Name = "BableSafe"
        Me.BableSafe.Size = New System.Drawing.Size(85, 20)
        Me.BableSafe.TabIndex = 33
        Me.BableSafe.Text = "SAFE FORMAT"
        '
        'BableMeta
        '
        Me.BableMeta.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BableMeta.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BableMeta.Appearance.Options.UseBackColor = True
        Me.BableMeta.Appearance.Options.UseFont = True
        Me.BableMeta.Appearance.Options.UseTextOptions = True
        Me.BableMeta.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BableMeta.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.BableMeta.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.BableMeta.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BableMeta.AppearanceHovered.Options.UseBackColor = True
        Me.BableMeta.AppearanceHovered.Options.UseFont = True
        Me.BableMeta.AppearanceHovered.Options.UseForeColor = True
        Me.BableMeta.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.BableMeta.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.BableMeta.Location = New System.Drawing.Point(477, 4)
        Me.BableMeta.Name = "BableMeta"
        Me.BableMeta.Size = New System.Drawing.Size(85, 20)
        Me.BableMeta.TabIndex = 34
        Me.BableMeta.Text = "META"
        '
        'panelControl4
        '
        Me.panelControl4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.panelControl4.Appearance.Options.UseBackColor = True
        Me.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panelControl4.Controls.Add(Me.labelTotal)
        Me.panelControl4.Controls.Add(Me.lLabelInt)
        Me.panelControl4.Location = New System.Drawing.Point(3, 27)
        Me.panelControl4.LookAndFeel.SkinName = "Office 2019 Dark Gray"
        Me.panelControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.panelControl4.Name = "panelControl4"
        Me.panelControl4.Size = New System.Drawing.Size(296, 20)
        Me.panelControl4.TabIndex = 0
        '
        'labelTotal
        '
        Me.labelTotal.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelTotal.Appearance.Options.UseForeColor = True
        Me.labelTotal.Location = New System.Drawing.Point(30, 3)
        Me.labelTotal.Name = "labelTotal"
        Me.labelTotal.Size = New System.Drawing.Size(12, 13)
        Me.labelTotal.TabIndex = 0
        Me.labelTotal.Text = "00"
        '
        'lLabelInt
        '
        Me.lLabelInt.Location = New System.Drawing.Point(4, 3)
        Me.lLabelInt.Name = "lLabelInt"
        Me.lLabelInt.Size = New System.Drawing.Size(21, 13)
        Me.lLabelInt.TabIndex = 0
        Me.lLabelInt.Text = "Int :"
        '
        'BableUniBrom
        '
        Me.BableUniBrom.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BableUniBrom.Appearance.Font = New System.Drawing.Font("Corbel", 7.25!, System.Drawing.FontStyle.Bold)
        Me.BableUniBrom.Appearance.Options.UseBackColor = True
        Me.BableUniBrom.Appearance.Options.UseFont = True
        Me.BableUniBrom.Appearance.Options.UseTextOptions = True
        Me.BableUniBrom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BableUniBrom.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.BableUniBrom.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.BableUniBrom.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BableUniBrom.AppearanceHovered.Options.UseBackColor = True
        Me.BableUniBrom.AppearanceHovered.Options.UseFont = True
        Me.BableUniBrom.AppearanceHovered.Options.UseForeColor = True
        Me.BableUniBrom.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.BableUniBrom.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.BableUniBrom.Location = New System.Drawing.Point(301, 4)
        Me.BableUniBrom.Name = "BableUniBrom"
        Me.BableUniBrom.Size = New System.Drawing.Size(85, 20)
        Me.BableUniBrom.TabIndex = 34
        Me.BableUniBrom.Text = "BROM"
        '
        'SearchControl1
        '
        Me.SearchControl1.Client = Me.ListBoxview
        Me.SearchControl1.Location = New System.Drawing.Point(3, 3)
        Me.SearchControl1.Name = "SearchControl1"
        Me.SearchControl1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.SearchControl1.Properties.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SearchControl1.Properties.Appearance.Options.UseBackColor = True
        Me.SearchControl1.Properties.Appearance.Options.UseForeColor = True
        Me.SearchControl1.Properties.AutoHeight = False
        Me.SearchControl1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SearchControl1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        Me.SearchControl1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SearchControl1.Properties.Client = Me.ListBoxview
        Me.SearchControl1.Properties.FilterCondition = DevExpress.Data.Filtering.FilterCondition.Contains
        Me.SearchControl1.Size = New System.Drawing.Size(296, 22)
        Me.SearchControl1.TabIndex = 2
        '
        'ListBoxview
        '
        Me.ListBoxview.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.ListBoxview.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ListBoxview.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ListBoxview.Appearance.Options.UseBackColor = True
        Me.ListBoxview.Appearance.Options.UseFont = True
        Me.ListBoxview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxview.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard
        Me.ListBoxview.HotTrackItems = True
        Me.ListBoxview.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick
        Me.ListBoxview.ItemHeight = 35
        Me.ListBoxview.Location = New System.Drawing.Point(0, 0)
        Me.ListBoxview.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ListBoxview.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ListBoxview.Name = "ListBoxview"
        Me.ListBoxview.ShowFocusRect = False
        Me.ListBoxview.Size = New System.Drawing.Size(296, 430)
        Me.ListBoxview.TabIndex = 3
        TableColumnDefinition1.Length.Value = 220.0R
        ItemTemplateBase1.Columns.Add(TableColumnDefinition1)
        TemplatedItemElement1.Appearance.Normal.Font = New System.Drawing.Font("Consolas", 8.5!, System.Drawing.FontStyle.Bold)
        TemplatedItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.Orange
        TemplatedItemElement1.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement1.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement1.FieldName = "Devices"
        TemplatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TemplatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TemplatedItemElement1.Text = "Devices"
        TemplatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft
        TemplatedItemElement1.TextLocation = New System.Drawing.Point(5, 0)
        TemplatedItemElement2.Appearance.Normal.Font = New System.Drawing.Font("MV Boli", 7.25!)
        TemplatedItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.DarkGray
        TemplatedItemElement2.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement2.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement2.FieldName = "Models"
        TemplatedItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TemplatedItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TemplatedItemElement2.RowIndex = 1
        TemplatedItemElement2.Text = "Models"
        TemplatedItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft
        TemplatedItemElement2.TextLocation = New System.Drawing.Point(5, 0)
        TemplatedItemElement3.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TemplatedItemElement3.AnchorElementIndex = 1
        TemplatedItemElement3.Appearance.Normal.Font = New System.Drawing.Font("MV Boli", 7.25!)
        TemplatedItemElement3.Appearance.Normal.ForeColor = System.Drawing.Color.DarkGray
        TemplatedItemElement3.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement3.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement3.FieldName = "Platform"
        TemplatedItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TemplatedItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TemplatedItemElement3.RowIndex = 1
        TemplatedItemElement3.Text = "Platform"
        TemplatedItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TemplatedItemElement4.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TemplatedItemElement4.AnchorElementIndex = 0
        TemplatedItemElement4.Appearance.Normal.BackColor = System.Drawing.Color.DeepPink
        TemplatedItemElement4.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 7.25!)
        TemplatedItemElement4.Appearance.Normal.ForeColor = System.Drawing.Color.White
        TemplatedItemElement4.Appearance.Normal.Options.UseBackColor = True
        TemplatedItemElement4.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement4.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement4.FieldName = "Conn"
        TemplatedItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TemplatedItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TemplatedItemElement4.Text = "Conn"
        TemplatedItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TemplatedItemElement5.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TemplatedItemElement5.AnchorElementIndex = 3
        TemplatedItemElement5.Appearance.Normal.BackColor = System.Drawing.Color.Yellow
        TemplatedItemElement5.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 7.25!)
        TemplatedItemElement5.Appearance.Normal.ForeColor = System.Drawing.Color.Gray
        TemplatedItemElement5.Appearance.Normal.Options.UseBackColor = True
        TemplatedItemElement5.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement5.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement5.FieldName = "Broom"
        TemplatedItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TemplatedItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TemplatedItemElement5.Text = "Broom"
        TemplatedItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TemplatedItemElement6.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TemplatedItemElement6.AnchorElementIndex = 4
        TemplatedItemElement6.Appearance.Normal.BackColor = System.Drawing.Color.Lime
        TemplatedItemElement6.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 7.25!)
        TemplatedItemElement6.Appearance.Normal.ForeColor = System.Drawing.Color.White
        TemplatedItemElement6.Appearance.Normal.Options.UseBackColor = True
        TemplatedItemElement6.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement6.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement6.FieldName = "New"
        TemplatedItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TemplatedItemElement6.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TemplatedItemElement6.Text = "New"
        TemplatedItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        ItemTemplateBase1.Elements.Add(TemplatedItemElement1)
        ItemTemplateBase1.Elements.Add(TemplatedItemElement2)
        ItemTemplateBase1.Elements.Add(TemplatedItemElement3)
        ItemTemplateBase1.Elements.Add(TemplatedItemElement4)
        ItemTemplateBase1.Elements.Add(TemplatedItemElement5)
        ItemTemplateBase1.Elements.Add(TemplatedItemElement6)
        ItemTemplateBase1.Name = "template1"
        TableRowDefinition1.AutoHeight = True
        TableRowDefinition1.Length.Value = 17.0R
        TableRowDefinition2.AutoHeight = True
        TableRowDefinition2.Length.Value = 14.0R
        ItemTemplateBase1.Rows.Add(TableRowDefinition1)
        ItemTemplateBase1.Rows.Add(TableRowDefinition2)
        Me.ListBoxview.Templates.Add(ItemTemplateBase1)
        '
        'Ground
        '
        Me.Ground.Controls.Add(Me.xtraTabControl1)
        Me.Ground.Location = New System.Drawing.Point(301, 29)
        Me.Ground.Name = "Ground"
        Me.Ground.Size = New System.Drawing.Size(349, 450)
        Me.Ground.TabIndex = 1
        '
        'xtraTabControl1
        '
        Me.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.xtraTabControl1.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.xtraTabControl1.Location = New System.Drawing.Point(2, 2)
        Me.xtraTabControl1.MultiLine = DevExpress.Utils.DefaultBoolean.[True]
        Me.xtraTabControl1.Name = "xtraTabControl1"
        Me.xtraTabControl1.SelectedTabPage = Me.xtraTabPage1
        Me.xtraTabControl1.Size = New System.Drawing.Size(345, 441)
        Me.xtraTabControl1.TabIndex = 1
        Me.xtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtraTabPage1, Me.xtraTabPage2, Me.xtraTabPage3, Me.xtraTabPage4})
        '
        'xtraTabPage1
        '
        Me.xtraTabPage1.Appearance.Header.Options.UseTextOptions = True
        Me.xtraTabPage1.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.xtraTabPage1.Controls.Add(Me.UI_Unibrom)
        Me.xtraTabPage1.Name = "xtraTabPage1"
        Me.xtraTabPage1.Size = New System.Drawing.Size(343, 420)
        Me.xtraTabPage1.Text = "UNI | BROM"
        '
        'UI_Unibrom
        '
        Me.UI_Unibrom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.UI_Unibrom.Controls.Add(Me.groupControl3)
        Me.UI_Unibrom.Controls.Add(Me.groupControl2)
        Me.UI_Unibrom.Controls.Add(Me.groupControl1)
        Me.UI_Unibrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UI_Unibrom.Location = New System.Drawing.Point(0, 0)
        Me.UI_Unibrom.Name = "UI_Unibrom"
        Me.UI_Unibrom.Size = New System.Drawing.Size(343, 420)
        Me.UI_Unibrom.TabIndex = 0
        '
        'groupControl3
        '
        Me.groupControl3.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.groupControl3.Location = New System.Drawing.Point(4, 242)
        Me.groupControl3.Name = "groupControl3"
        Me.groupControl3.Size = New System.Drawing.Size(337, 175)
        Me.groupControl3.TabIndex = 54
        Me.groupControl3.Text = "unif | read info"
        '
        'groupControl2
        '
        Me.groupControl2.Controls.Add(Me.simpleButton4)
        Me.groupControl2.Controls.Add(Me.simpleButton3)
        Me.groupControl2.Controls.Add(Me.simpleButton2)
        Me.groupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.groupControl2.Location = New System.Drawing.Point(4, 65)
        Me.groupControl2.Name = "groupControl2"
        Me.groupControl2.Size = New System.Drawing.Size(337, 127)
        Me.groupControl2.TabIndex = 54
        Me.groupControl2.Text = "broom"
        '
        'simpleButton4
        '
        Me.simpleButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.simpleButton4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.simpleButton4.Appearance.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.simpleButton4.Appearance.Options.UseBackColor = True
        Me.simpleButton4.Appearance.Options.UseFont = True
        Me.simpleButton4.Appearance.Options.UseTextOptions = True
        Me.simpleButton4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.simpleButton4.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.simpleButton4.AppearanceHovered.Options.UseFont = True
        Me.simpleButton4.AppearanceHovered.Options.UseImage = True
        Me.simpleButton4.ImageOptions.Image = CType(resources.GetObject("simpleButton4.ImageOptions.Image"), System.Drawing.Image)
        Me.simpleButton4.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.simpleButton4.Location = New System.Drawing.Point(4, 90)
        Me.simpleButton4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.simpleButton4.Name = "simpleButton4"
        Me.simpleButton4.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.simpleButton4.ShowToolTips = False
        Me.simpleButton4.Size = New System.Drawing.Size(327, 28)
        Me.simpleButton4.TabIndex = 53
        Me.simpleButton4.Text = "READ INFO"
        '
        'simpleButton3
        '
        Me.simpleButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.simpleButton3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.simpleButton3.Appearance.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.simpleButton3.Appearance.Options.UseBackColor = True
        Me.simpleButton3.Appearance.Options.UseFont = True
        Me.simpleButton3.Appearance.Options.UseTextOptions = True
        Me.simpleButton3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.simpleButton3.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.simpleButton3.AppearanceHovered.Options.UseFont = True
        Me.simpleButton3.AppearanceHovered.Options.UseImage = True
        Me.simpleButton3.ImageOptions.Image = CType(resources.GetObject("simpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.simpleButton3.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.simpleButton3.Location = New System.Drawing.Point(4, 56)
        Me.simpleButton3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.simpleButton3.Name = "simpleButton3"
        Me.simpleButton3.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.simpleButton3.ShowToolTips = False
        Me.simpleButton3.Size = New System.Drawing.Size(327, 28)
        Me.simpleButton3.TabIndex = 53
        Me.simpleButton3.Text = "READ INFO"
        '
        'simpleButton2
        '
        Me.simpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.simpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.simpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.simpleButton2.Appearance.Options.UseBackColor = True
        Me.simpleButton2.Appearance.Options.UseFont = True
        Me.simpleButton2.Appearance.Options.UseTextOptions = True
        Me.simpleButton2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.simpleButton2.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.simpleButton2.AppearanceHovered.Options.UseFont = True
        Me.simpleButton2.AppearanceHovered.Options.UseImage = True
        Me.simpleButton2.ImageOptions.Image = CType(resources.GetObject("simpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.simpleButton2.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.simpleButton2.Location = New System.Drawing.Point(4, 22)
        Me.simpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.simpleButton2.Name = "simpleButton2"
        Me.simpleButton2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.simpleButton2.ShowToolTips = False
        Me.simpleButton2.Size = New System.Drawing.Size(327, 28)
        Me.simpleButton2.TabIndex = 53
        Me.simpleButton2.Text = "ENBLE BROOM"
        '
        'groupControl1
        '
        Me.groupControl1.Controls.Add(Me.simpleButton1)
        Me.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.groupControl1.Location = New System.Drawing.Point(3, 2)
        Me.groupControl1.Name = "groupControl1"
        Me.groupControl1.Size = New System.Drawing.Size(337, 56)
        Me.groupControl1.TabIndex = 54
        Me.groupControl1.Text = "unif | read info"
        '
        'simpleButton1
        '
        Me.simpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.simpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.simpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.simpleButton1.Appearance.Options.UseBackColor = True
        Me.simpleButton1.Appearance.Options.UseFont = True
        Me.simpleButton1.Appearance.Options.UseTextOptions = True
        Me.simpleButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.simpleButton1.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.simpleButton1.AppearanceHovered.Options.UseFont = True
        Me.simpleButton1.AppearanceHovered.Options.UseImage = True
        Me.simpleButton1.ImageOptions.Image = CType(resources.GetObject("simpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.simpleButton1.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.simpleButton1.Location = New System.Drawing.Point(5, 21)
        Me.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.simpleButton1.Name = "simpleButton1"
        Me.simpleButton1.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.simpleButton1.ShowToolTips = False
        Me.simpleButton1.Size = New System.Drawing.Size(327, 28)
        Me.simpleButton1.TabIndex = 53
        Me.simpleButton1.Text = "READ INFO"
        '
        'xtraTabPage2
        '
        Me.xtraTabPage2.Appearance.Header.Options.UseTextOptions = True
        Me.xtraTabPage2.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.xtraTabPage2.Controls.Add(Me.UI_Safeformat)
        Me.xtraTabPage2.Name = "xtraTabPage2"
        Me.xtraTabPage2.Size = New System.Drawing.Size(343, 420)
        Me.xtraTabPage2.Text = "SAVEFORMAT"
        '
        'UI_Safeformat
        '
        Me.UI_Safeformat.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.UI_Safeformat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UI_Safeformat.Location = New System.Drawing.Point(0, 0)
        Me.UI_Safeformat.Name = "UI_Safeformat"
        Me.UI_Safeformat.Size = New System.Drawing.Size(343, 420)
        Me.UI_Safeformat.TabIndex = 0
        '
        'xtraTabPage3
        '
        Me.xtraTabPage3.Appearance.Header.Options.UseTextOptions = True
        Me.xtraTabPage3.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.xtraTabPage3.Name = "xtraTabPage3"
        Me.xtraTabPage3.Size = New System.Drawing.Size(343, 420)
        Me.xtraTabPage3.Text = "META"
        '
        'xtraTabPage4
        '
        Me.xtraTabPage4.Appearance.Header.Options.UseTextOptions = True
        Me.xtraTabPage4.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.xtraTabPage4.Controls.Add(Me.UiMEI)
        Me.xtraTabPage4.Name = "xtraTabPage4"
        Me.xtraTabPage4.Size = New System.Drawing.Size(343, 420)
        Me.xtraTabPage4.Text = "UNLOCK"
        '
        'UiMEI
        '
        Me.UiMEI.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.UiMEI.Controls.Add(Me.ButtonIMEI)
        Me.UiMEI.Controls.Add(Me.ButtonBP)
        Me.UiMEI.Controls.Add(Me.ButtonAP)
        Me.UiMEI.Controls.Add(Me.TextEditBP)
        Me.UiMEI.Controls.Add(Me.TextEditAP)
        Me.UiMEI.Controls.Add(Me.CheckIMEI2)
        Me.UiMEI.Controls.Add(Me.CheckIMEI1)
        Me.UiMEI.Controls.Add(Me.ValidIMEI2)
        Me.UiMEI.Controls.Add(Me.ValidIMEI1)
        Me.UiMEI.Controls.Add(Me.Text_IMEI2)
        Me.UiMEI.Controls.Add(Me.Text_IMEI1)
        Me.UiMEI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiMEI.Location = New System.Drawing.Point(0, 0)
        Me.UiMEI.Name = "UiMEI"
        Me.UiMEI.Size = New System.Drawing.Size(343, 420)
        Me.UiMEI.TabIndex = 1
        '
        'ButtonIMEI
        '
        Me.ButtonIMEI.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonIMEI.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.ButtonIMEI.Appearance.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.ButtonIMEI.Appearance.Options.UseBackColor = True
        Me.ButtonIMEI.Appearance.Options.UseFont = True
        Me.ButtonIMEI.Appearance.Options.UseTextOptions = True
        Me.ButtonIMEI.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonIMEI.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ButtonIMEI.AppearanceHovered.Options.UseFont = True
        Me.ButtonIMEI.AppearanceHovered.Options.UseImage = True
        Me.ButtonIMEI.ImageOptions.Image = CType(resources.GetObject("ButtonIMEI.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonIMEI.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonIMEI.Location = New System.Drawing.Point(225, 82)
        Me.ButtonIMEI.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonIMEI.Name = "ButtonIMEI"
        Me.ButtonIMEI.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonIMEI.Size = New System.Drawing.Size(96, 31)
        Me.ButtonIMEI.TabIndex = 52
        Me.ButtonIMEI.Text = "WRITE"
        '
        'ButtonBP
        '
        Me.ButtonBP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonBP.Appearance.Options.UseBackColor = True
        Me.ButtonBP.Location = New System.Drawing.Point(308, 149)
        Me.ButtonBP.Name = "ButtonBP"
        Me.ButtonBP.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonBP.Size = New System.Drawing.Size(30, 20)
        Me.ButtonBP.TabIndex = 51
        Me.ButtonBP.Text = "BP"
        '
        'ButtonAP
        '
        Me.ButtonAP.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAP.Appearance.Options.UseBackColor = True
        Me.ButtonAP.Location = New System.Drawing.Point(308, 125)
        Me.ButtonAP.Name = "ButtonAP"
        Me.ButtonAP.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonAP.Size = New System.Drawing.Size(30, 20)
        Me.ButtonAP.TabIndex = 50
        Me.ButtonAP.Text = "AP"
        '
        'TextEditBP
        '
        Me.TextEditBP.EditValue = ""
        Me.TextEditBP.Location = New System.Drawing.Point(5, 148)
        Me.TextEditBP.Name = "TextEditBP"
        Me.TextEditBP.Properties.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.TextEditBP.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Bold)
        Me.TextEditBP.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.TextEditBP.Properties.Appearance.Options.UseBackColor = True
        Me.TextEditBP.Properties.Appearance.Options.UseFont = True
        Me.TextEditBP.Properties.Appearance.Options.UseForeColor = True
        Me.TextEditBP.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEditBP.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextEditBP.Size = New System.Drawing.Size(297, 20)
        Me.TextEditBP.TabIndex = 49
        '
        'TextEditAP
        '
        Me.TextEditAP.EditValue = ""
        Me.TextEditAP.Location = New System.Drawing.Point(5, 125)
        Me.TextEditAP.Name = "TextEditAP"
        Me.TextEditAP.Properties.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.TextEditAP.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Bold)
        Me.TextEditAP.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.TextEditAP.Properties.Appearance.Options.UseBackColor = True
        Me.TextEditAP.Properties.Appearance.Options.UseFont = True
        Me.TextEditAP.Properties.Appearance.Options.UseForeColor = True
        Me.TextEditAP.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEditAP.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextEditAP.Size = New System.Drawing.Size(297, 20)
        Me.TextEditAP.TabIndex = 48
        '
        'CheckIMEI2
        '
        Me.CheckIMEI2.Location = New System.Drawing.Point(17, 44)
        Me.CheckIMEI2.Name = "CheckIMEI2"
        Me.CheckIMEI2.Properties.AllowFocused = False
        Me.CheckIMEI2.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CheckIMEI2.Properties.Appearance.Options.UseFont = True
        Me.CheckIMEI2.Properties.Caption = "IMEI 2"
        Me.CheckIMEI2.Size = New System.Drawing.Size(54, 20)
        Me.CheckIMEI2.TabIndex = 2
        '
        'CheckIMEI1
        '
        Me.CheckIMEI1.Location = New System.Drawing.Point(17, 20)
        Me.CheckIMEI1.Name = "CheckIMEI1"
        Me.CheckIMEI1.Properties.AllowFocused = False
        Me.CheckIMEI1.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CheckIMEI1.Properties.Appearance.Options.UseFont = True
        Me.CheckIMEI1.Properties.Caption = "IMEI 1"
        Me.CheckIMEI1.Size = New System.Drawing.Size(54, 20)
        Me.CheckIMEI1.TabIndex = 2
        '
        'ValidIMEI2
        '
        Me.ValidIMEI2.EditValue = "0"
        Me.ValidIMEI2.Location = New System.Drawing.Point(298, 46)
        Me.ValidIMEI2.Name = "ValidIMEI2"
        Me.ValidIMEI2.Properties.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.ValidIMEI2.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ValidIMEI2.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.ValidIMEI2.Properties.Appearance.Options.UseBackColor = True
        Me.ValidIMEI2.Properties.Appearance.Options.UseFont = True
        Me.ValidIMEI2.Properties.Appearance.Options.UseForeColor = True
        Me.ValidIMEI2.Properties.Appearance.Options.UseTextOptions = True
        Me.ValidIMEI2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ValidIMEI2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ValidIMEI2.Properties.MaxLength = 1
        Me.ValidIMEI2.Size = New System.Drawing.Size(23, 22)
        Me.ValidIMEI2.TabIndex = 0
        '
        'ValidIMEI1
        '
        Me.ValidIMEI1.EditValue = "0"
        Me.ValidIMEI1.Location = New System.Drawing.Point(298, 19)
        Me.ValidIMEI1.Name = "ValidIMEI1"
        Me.ValidIMEI1.Properties.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.ValidIMEI1.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ValidIMEI1.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.ValidIMEI1.Properties.Appearance.Options.UseBackColor = True
        Me.ValidIMEI1.Properties.Appearance.Options.UseFont = True
        Me.ValidIMEI1.Properties.Appearance.Options.UseForeColor = True
        Me.ValidIMEI1.Properties.Appearance.Options.UseTextOptions = True
        Me.ValidIMEI1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ValidIMEI1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ValidIMEI1.Properties.MaxLength = 1
        Me.ValidIMEI1.Size = New System.Drawing.Size(23, 22)
        Me.ValidIMEI1.TabIndex = 0
        '
        'Text_IMEI2
        '
        Me.Text_IMEI2.EditValue = "00000000000000"
        Me.Text_IMEI2.Location = New System.Drawing.Point(75, 45)
        Me.Text_IMEI2.Name = "Text_IMEI2"
        Me.Text_IMEI2.Properties.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.Text_IMEI2.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text_IMEI2.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.Text_IMEI2.Properties.Appearance.Options.UseBackColor = True
        Me.Text_IMEI2.Properties.Appearance.Options.UseFont = True
        Me.Text_IMEI2.Properties.Appearance.Options.UseForeColor = True
        Me.Text_IMEI2.Properties.Appearance.Options.UseTextOptions = True
        Me.Text_IMEI2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Text_IMEI2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Text_IMEI2.Properties.MaxLength = 14
        Me.Text_IMEI2.Size = New System.Drawing.Size(218, 22)
        Me.Text_IMEI2.TabIndex = 0
        '
        'Text_IMEI1
        '
        Me.Text_IMEI1.EditValue = "00000000000000"
        Me.Text_IMEI1.Location = New System.Drawing.Point(75, 19)
        Me.Text_IMEI1.Name = "Text_IMEI1"
        Me.Text_IMEI1.Properties.Appearance.BackColor = System.Drawing.Color.DimGray
        Me.Text_IMEI1.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text_IMEI1.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.Text_IMEI1.Properties.Appearance.Options.UseBackColor = True
        Me.Text_IMEI1.Properties.Appearance.Options.UseFont = True
        Me.Text_IMEI1.Properties.Appearance.Options.UseForeColor = True
        Me.Text_IMEI1.Properties.Appearance.Options.UseTextOptions = True
        Me.Text_IMEI1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Text_IMEI1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Text_IMEI1.Properties.MaxLength = 14
        Me.Text_IMEI1.Size = New System.Drawing.Size(218, 22)
        Me.Text_IMEI1.TabIndex = 0
        '
        'ControList
        '
        Me.ControList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.ControList.Controls.Add(Me.ListBoxview)
        Me.ControList.Location = New System.Drawing.Point(3, 49)
        Me.ControList.Name = "ControList"
        Me.ControList.Size = New System.Drawing.Size(296, 430)
        Me.ControList.TabIndex = 0
        '
        'BgwUnlocked
        '
        Me.BgwUnlocked.WorkerReportsProgress = True
        Me.BgwUnlocked.WorkerSupportsCancellation = True
        '
        'MtkUnlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BackGround)
        Me.Name = "MtkUnlock"
        Me.Size = New System.Drawing.Size(653, 482)
        CType(Me.BackGround, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BackGround.ResumeLayout(False)
        CType(Me.panelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl4.ResumeLayout(False)
        Me.panelControl4.PerformLayout()
        CType(Me.SearchControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListBoxview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ground.ResumeLayout(False)
        CType(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtraTabControl1.ResumeLayout(False)
        Me.xtraTabPage1.ResumeLayout(False)
        CType(Me.UI_Unibrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UI_Unibrom.ResumeLayout(False)
        CType(Me.groupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupControl2.ResumeLayout(False)
        CType(Me.groupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupControl1.ResumeLayout(False)
        Me.xtraTabPage2.ResumeLayout(False)
        CType(Me.UI_Safeformat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtraTabPage4.ResumeLayout(False)
        CType(Me.UiMEI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiMEI.ResumeLayout(False)
        CType(Me.TextEditBP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditAP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckIMEI2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckIMEI1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidIMEI2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidIMEI1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text_IMEI2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Text_IMEI1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents BackGround As PanelControl
    Private WithEvents BableImei As LabelControl
    Private WithEvents BableSafe As LabelControl
    Private WithEvents BableMeta As LabelControl
    Private WithEvents panelControl4 As PanelControl
    Public WithEvents labelTotal As LabelControl
    Private WithEvents lLabelInt As LabelControl
    Private WithEvents BableUniBrom As LabelControl
    Private WithEvents SearchControl1 As SearchControl
    Public WithEvents ListBoxview As ListBoxControl
    Private WithEvents Ground As PanelControl
    Private WithEvents xtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Private WithEvents xtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Public WithEvents UI_Unibrom As PanelControl
    Private WithEvents groupControl3 As GroupControl
    Private WithEvents groupControl2 As GroupControl
    Private WithEvents simpleButton4 As SimpleButton
    Private WithEvents simpleButton3 As SimpleButton
    Private WithEvents simpleButton2 As SimpleButton
    Private WithEvents groupControl1 As GroupControl
    Private WithEvents simpleButton1 As SimpleButton
    Private WithEvents xtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents UI_Safeformat As PanelControl
    Private WithEvents xtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents xtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Public WithEvents UiMEI As PanelControl
    Private WithEvents ButtonIMEI As SimpleButton
    Private WithEvents ButtonBP As SimpleButton
    Private WithEvents ButtonAP As SimpleButton
    Private WithEvents TextEditBP As TextEdit
    Private WithEvents TextEditAP As TextEdit
    Public WithEvents CheckIMEI2 As CheckEdit
    Public WithEvents CheckIMEI1 As CheckEdit
    Private WithEvents ValidIMEI2 As TextEdit
    Private WithEvents ValidIMEI1 As TextEdit
    Private WithEvents Text_IMEI2 As TextEdit
    Private WithEvents Text_IMEI1 As TextEdit
    Private WithEvents ControList As PanelControl


    Public Shared RichtextBox As RichTextBox
    
    Public UnlockMethod As String

    Friend WithEvents SerialPort1 As Ports.SerialPort
    Public WithEvents BgwUnlocked As BackgroundWorker

End Class
