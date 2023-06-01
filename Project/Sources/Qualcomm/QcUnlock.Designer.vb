Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QcUnlock
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
        Dim ItemTemplateBase2 As DevExpress.XtraEditors.TableLayout.ItemTemplateBase = New DevExpress.XtraEditors.TableLayout.ItemTemplateBase()
        Dim TableColumnDefinition2 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New DevExpress.XtraEditors.TableLayout.TableColumnDefinition()
        Dim TemplatedItemElement7 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement8 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement9 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement10 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement11 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TemplatedItemElement12 As DevExpress.XtraEditors.TableLayout.TemplatedItemElement = New DevExpress.XtraEditors.TableLayout.TemplatedItemElement()
        Dim TableRowDefinition3 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition4 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Me.BackGround = New DevExpress.XtraEditors.PanelControl()
        Me.ControList = New DevExpress.XtraEditors.PanelControl()
        Me.ListBoxview = New DevExpress.XtraEditors.ListBoxControl()
        Me.labelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BableSafe = New DevExpress.XtraEditors.LabelControl()
        Me.BableMeta = New DevExpress.XtraEditors.LabelControl()
        Me.panelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.labelTotal = New DevExpress.XtraEditors.LabelControl()
        Me.lLabelInt = New DevExpress.XtraEditors.LabelControl()
        Me.BableUniBrom = New DevExpress.XtraEditors.LabelControl()
        Me.SearchControl1 = New DevExpress.XtraEditors.SearchControl()
        Me.Ground = New DevExpress.XtraEditors.PanelControl()
        Me.xtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.UI_Unibrom = New DevExpress.XtraEditors.PanelControl()
        Me.xtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.UI_Safeformat = New DevExpress.XtraEditors.PanelControl()
        Me.xtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.xtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.CariPortQcom = New System.Windows.Forms.Timer(Me.components)
        CType(Me.BackGround, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BackGround.SuspendLayout()
        CType(Me.ControList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControList.SuspendLayout()
        CType(Me.ListBoxview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl4.SuspendLayout()
        CType(Me.SearchControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ground.SuspendLayout()
        CType(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtraTabControl1.SuspendLayout()
        Me.xtraTabPage1.SuspendLayout()
        CType(Me.UI_Unibrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtraTabPage2.SuspendLayout()
        CType(Me.UI_Safeformat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackGround
        '
        Me.BackGround.Controls.Add(Me.ControList)
        Me.BackGround.Controls.Add(Me.labelControl4)
        Me.BackGround.Controls.Add(Me.BableSafe)
        Me.BackGround.Controls.Add(Me.BableMeta)
        Me.BackGround.Controls.Add(Me.panelControl4)
        Me.BackGround.Controls.Add(Me.BableUniBrom)
        Me.BackGround.Controls.Add(Me.SearchControl1)
        Me.BackGround.Controls.Add(Me.Ground)
        Me.BackGround.Dock = DockStyle.Fill
        Me.BackGround.Location = New System.Drawing.Point(0, 0)
        Me.BackGround.Name = "BackGround"
        Me.BackGround.Size = New System.Drawing.Size(653, 482)
        Me.BackGround.TabIndex = 2
        '
        'ControList
        '
        Me.ControList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.ControList.Controls.Add(Me.ListBoxview)
        Me.ControList.Location = New System.Drawing.Point(3, 49)
        Me.ControList.Name = "ControList"
        Me.ControList.Size = New System.Drawing.Size(296, 430)
        Me.ControList.TabIndex = 35
        '
        'ListBoxview
        '
        Me.ListBoxview.AccessibleRole = AccessibleRole.None
        Me.ListBoxview.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ListBoxview.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold)
        Me.ListBoxview.Appearance.Options.UseBackColor = True
        Me.ListBoxview.Appearance.Options.UseFont = True
        Me.ListBoxview.Dock = DockStyle.Fill
        Me.ListBoxview.HighlightedItemStyle = HighlightStyle.Standard
        Me.ListBoxview.HotTrackItems = True
        Me.ListBoxview.HotTrackSelectMode = HotTrackSelectMode.SelectItemOnClick
        Me.ListBoxview.ItemHeight = 35
        Me.ListBoxview.Location = New System.Drawing.Point(0, 0)
        Me.ListBoxview.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ListBoxview.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ListBoxview.Name = "ListBoxview"
        Me.ListBoxview.ShowFocusRect = False
        Me.ListBoxview.Size = New System.Drawing.Size(296, 430)
        Me.ListBoxview.TabIndex = 3
        TableColumnDefinition2.Length.Value = 220.0R
        ItemTemplateBase2.Columns.Add(TableColumnDefinition2)
        TemplatedItemElement7.Appearance.Normal.Font = New System.Drawing.Font("Consolas", 8.5!, FontStyle.Bold)
        TemplatedItemElement7.Appearance.Normal.ForeColor = Color.Orange
        TemplatedItemElement7.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement7.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement7.FieldName = "Devices"
        TemplatedItemElement7.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TemplatedItemElement7.ImageOptions.ImageScaleMode = TileItemImageScaleMode.ZoomInside
        TemplatedItemElement7.Text = "Devices"
        TemplatedItemElement7.TextAlignment = TileItemContentAlignment.MiddleLeft
        TemplatedItemElement7.TextLocation = New System.Drawing.Point(5, 0)
        TemplatedItemElement8.Appearance.Normal.Font = New System.Drawing.Font("MV Boli", 7.25!)
        TemplatedItemElement8.Appearance.Normal.ForeColor = Color.DarkGray
        TemplatedItemElement8.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement8.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement8.FieldName = "Models"
        TemplatedItemElement8.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TemplatedItemElement8.ImageOptions.ImageScaleMode = TileItemImageScaleMode.ZoomInside
        TemplatedItemElement8.RowIndex = 1
        TemplatedItemElement8.Text = "Models"
        TemplatedItemElement8.TextAlignment = TileItemContentAlignment.MiddleLeft
        TemplatedItemElement8.TextLocation = New System.Drawing.Point(5, 0)
        TemplatedItemElement9.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TemplatedItemElement9.AnchorElementIndex = 1
        TemplatedItemElement9.Appearance.Normal.Font = New System.Drawing.Font("MV Boli", 7.25!)
        TemplatedItemElement9.Appearance.Normal.ForeColor = Color.DarkGray
        TemplatedItemElement9.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement9.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement9.FieldName = "Platform"
        TemplatedItemElement9.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TemplatedItemElement9.ImageOptions.ImageScaleMode = TileItemImageScaleMode.ZoomInside
        TemplatedItemElement9.RowIndex = 1
        TemplatedItemElement9.Text = "Platform"
        TemplatedItemElement9.TextAlignment = TileItemContentAlignment.MiddleCenter
        TemplatedItemElement10.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TemplatedItemElement10.AnchorElementIndex = 0
        TemplatedItemElement10.Appearance.Normal.BackColor = Color.DeepPink
        TemplatedItemElement10.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 7.25!)
        TemplatedItemElement10.Appearance.Normal.ForeColor = Color.White
        TemplatedItemElement10.Appearance.Normal.Options.UseBackColor = True
        TemplatedItemElement10.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement10.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement10.FieldName = "Conn"
        TemplatedItemElement10.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TemplatedItemElement10.ImageOptions.ImageScaleMode = TileItemImageScaleMode.ZoomInside
        TemplatedItemElement10.Text = "Conn"
        TemplatedItemElement10.TextAlignment = TileItemContentAlignment.MiddleCenter
        TemplatedItemElement11.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TemplatedItemElement11.AnchorElementIndex = 3
        TemplatedItemElement11.Appearance.Normal.BackColor = Color.Yellow
        TemplatedItemElement11.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 7.25!)
        TemplatedItemElement11.Appearance.Normal.ForeColor = Color.Gray
        TemplatedItemElement11.Appearance.Normal.Options.UseBackColor = True
        TemplatedItemElement11.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement11.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement11.FieldName = "Broom"
        TemplatedItemElement11.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TemplatedItemElement11.ImageOptions.ImageScaleMode = TileItemImageScaleMode.ZoomInside
        TemplatedItemElement11.Text = "Broom"
        TemplatedItemElement11.TextAlignment = TileItemContentAlignment.MiddleCenter
        TemplatedItemElement12.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TemplatedItemElement12.AnchorElementIndex = 4
        TemplatedItemElement12.Appearance.Normal.BackColor = Color.Lime
        TemplatedItemElement12.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 7.25!)
        TemplatedItemElement12.Appearance.Normal.ForeColor = Color.White
        TemplatedItemElement12.Appearance.Normal.Options.UseBackColor = True
        TemplatedItemElement12.Appearance.Normal.Options.UseFont = True
        TemplatedItemElement12.Appearance.Normal.Options.UseForeColor = True
        TemplatedItemElement12.FieldName = "New"
        TemplatedItemElement12.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TemplatedItemElement12.ImageOptions.ImageScaleMode = TileItemImageScaleMode.ZoomInside
        TemplatedItemElement12.Text = "New"
        TemplatedItemElement12.TextAlignment = TileItemContentAlignment.MiddleCenter
        ItemTemplateBase2.Elements.Add(TemplatedItemElement7)
        ItemTemplateBase2.Elements.Add(TemplatedItemElement8)
        ItemTemplateBase2.Elements.Add(TemplatedItemElement9)
        ItemTemplateBase2.Elements.Add(TemplatedItemElement10)
        ItemTemplateBase2.Elements.Add(TemplatedItemElement11)
        ItemTemplateBase2.Elements.Add(TemplatedItemElement12)
        ItemTemplateBase2.Name = "template1"
        TableRowDefinition3.AutoHeight = True
        TableRowDefinition3.Length.Value = 17.0R
        TableRowDefinition4.AutoHeight = True
        TableRowDefinition4.Length.Value = 14.0R
        ItemTemplateBase2.Rows.Add(TableRowDefinition3)
        ItemTemplateBase2.Rows.Add(TableRowDefinition4)
        Me.ListBoxview.Templates.Add(ItemTemplateBase2)
        '
        'labelControl4
        '
        Me.labelControl4.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.labelControl4.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!, FontStyle.Bold)
        Me.labelControl4.Appearance.Options.UseBackColor = True
        Me.labelControl4.Appearance.Options.UseFont = True
        Me.labelControl4.Appearance.Options.UseTextOptions = True
        Me.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.labelControl4.AppearanceHovered.BackColor = Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.labelControl4.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.labelControl4.AppearanceHovered.ForeColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelControl4.AppearanceHovered.Options.UseBackColor = True
        Me.labelControl4.AppearanceHovered.Options.UseFont = True
        Me.labelControl4.AppearanceHovered.Options.UseForeColor = True
        Me.labelControl4.AutoSizeMode = LabelAutoSizeMode.None
        Me.labelControl4.ImageOptions.Alignment = ContentAlignment.MiddleLeft
        Me.labelControl4.Location = New System.Drawing.Point(565, 4)
        Me.labelControl4.Name = "labelControl4"
        Me.labelControl4.Size = New System.Drawing.Size(85, 20)
        Me.labelControl4.TabIndex = 33
        Me.labelControl4.Text = "QCN | IMEI"
        '
        'BableSafe
        '
        Me.BableSafe.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BableSafe.Appearance.Font = New System.Drawing.Font("Corbel", 7.25!, FontStyle.Bold)
        Me.BableSafe.Appearance.Options.UseBackColor = True
        Me.BableSafe.Appearance.Options.UseFont = True
        Me.BableSafe.Appearance.Options.UseTextOptions = True
        Me.BableSafe.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BableSafe.AppearanceHovered.BackColor = Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.BableSafe.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.BableSafe.AppearanceHovered.ForeColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BableSafe.AppearanceHovered.Options.UseBackColor = True
        Me.BableSafe.AppearanceHovered.Options.UseFont = True
        Me.BableSafe.AppearanceHovered.Options.UseForeColor = True
        Me.BableSafe.AutoSizeMode = LabelAutoSizeMode.None
        Me.BableSafe.ImageOptions.Alignment = ContentAlignment.MiddleLeft
        Me.BableSafe.Location = New System.Drawing.Point(389, 4)
        Me.BableSafe.Name = "BableSafe"
        Me.BableSafe.Size = New System.Drawing.Size(85, 20)
        Me.BableSafe.TabIndex = 33
        Me.BableSafe.Text = "ADB COMMAND"
        '
        'BableMeta
        '
        Me.BableMeta.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BableMeta.Appearance.Font = New System.Drawing.Font("Corbel", 8.25!, FontStyle.Bold)
        Me.BableMeta.Appearance.Options.UseBackColor = True
        Me.BableMeta.Appearance.Options.UseFont = True
        Me.BableMeta.Appearance.Options.UseTextOptions = True
        Me.BableMeta.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BableMeta.AppearanceHovered.BackColor = Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.BableMeta.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.BableMeta.AppearanceHovered.ForeColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BableMeta.AppearanceHovered.Options.UseBackColor = True
        Me.BableMeta.AppearanceHovered.Options.UseFont = True
        Me.BableMeta.AppearanceHovered.Options.UseForeColor = True
        Me.BableMeta.AutoSizeMode = LabelAutoSizeMode.None
        Me.BableMeta.ImageOptions.Alignment = ContentAlignment.MiddleLeft
        Me.BableMeta.Location = New System.Drawing.Point(477, 4)
        Me.BableMeta.Name = "BableMeta"
        Me.BableMeta.Size = New System.Drawing.Size(85, 20)
        Me.BableMeta.TabIndex = 34
        Me.BableMeta.Text = "FASTBOOT"
        '
        'panelControl4
        '
        Me.panelControl4.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.labelTotal.Appearance.ForeColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
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
        Me.BableUniBrom.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BableUniBrom.Appearance.Font = New System.Drawing.Font("Corbel", 7.25!, FontStyle.Bold)
        Me.BableUniBrom.Appearance.Options.UseBackColor = True
        Me.BableUniBrom.Appearance.Options.UseFont = True
        Me.BableUniBrom.Appearance.Options.UseTextOptions = True
        Me.BableUniBrom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BableUniBrom.AppearanceHovered.BackColor = Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.BableUniBrom.AppearanceHovered.Font = New System.Drawing.Font("Corbel", 9.25!)
        Me.BableUniBrom.AppearanceHovered.ForeColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BableUniBrom.AppearanceHovered.Options.UseBackColor = True
        Me.BableUniBrom.AppearanceHovered.Options.UseFont = True
        Me.BableUniBrom.AppearanceHovered.Options.UseForeColor = True
        Me.BableUniBrom.AutoSizeMode = LabelAutoSizeMode.None
        Me.BableUniBrom.ImageOptions.Alignment = ContentAlignment.MiddleLeft
        Me.BableUniBrom.Location = New System.Drawing.Point(301, 4)
        Me.BableUniBrom.Name = "BableUniBrom"
        Me.BableUniBrom.Size = New System.Drawing.Size(85, 20)
        Me.BableUniBrom.TabIndex = 34
        Me.BableUniBrom.Text = "ONECLICK"
        '
        'SearchControl1
        '
        Me.SearchControl1.Client = Me.ListBoxview
        Me.SearchControl1.Location = New System.Drawing.Point(3, 3)
        Me.SearchControl1.Name = "SearchControl1"
        Me.SearchControl1.Properties.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.SearchControl1.Properties.Appearance.ForeColor = Color.WhiteSmoke
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
        'Ground
        '
        Me.Ground.Controls.Add(Me.xtraTabControl1)
        Me.Ground.Location = New System.Drawing.Point(301, 34)
        Me.Ground.Name = "Ground"
        Me.Ground.Size = New System.Drawing.Size(349, 445)
        Me.Ground.TabIndex = 1
        '
        'xtraTabControl1
        '
        Me.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.xtraTabControl1.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.xtraTabControl1.Dock = DockStyle.Fill
        Me.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.xtraTabControl1.Location = New System.Drawing.Point(2, 2)
        Me.xtraTabControl1.MultiLine = DevExpress.Utils.DefaultBoolean.[True]
        Me.xtraTabControl1.Name = "xtraTabControl1"
        Me.xtraTabControl1.SelectedTabPage = Me.xtraTabPage1
        Me.xtraTabControl1.Size = New System.Drawing.Size(345, 441)
        Me.xtraTabControl1.TabIndex = 0
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
        Me.UI_Unibrom.Dock = DockStyle.Fill
        Me.UI_Unibrom.Location = New System.Drawing.Point(0, 0)
        Me.UI_Unibrom.Name = "UI_Unibrom"
        Me.UI_Unibrom.Size = New System.Drawing.Size(343, 420)
        Me.UI_Unibrom.TabIndex = 0
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
        Me.UI_Safeformat.Dock = DockStyle.Fill
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
        Me.xtraTabPage4.Name = "xtraTabPage4"
        Me.xtraTabPage4.Size = New System.Drawing.Size(343, 420)
        Me.xtraTabPage4.Text = "UNLOCK"
        '
        'CariPortQcom
        '
        Me.CariPortQcom.Interval = 1000
        '
        'QcUnlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.Controls.Add(Me.BackGround)
        Me.Name = "QcUnlock"
        Me.Size = New System.Drawing.Size(653, 482)
        CType(Me.BackGround, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BackGround.ResumeLayout(False)
        CType(Me.ControList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControList.ResumeLayout(False)
        CType(Me.ListBoxview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl4.ResumeLayout(False)
        Me.panelControl4.PerformLayout()
        CType(Me.SearchControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ground.ResumeLayout(False)
        CType(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtraTabControl1.ResumeLayout(False)
        Me.xtraTabPage1.ResumeLayout(False)
        CType(Me.UI_Unibrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtraTabPage2.ResumeLayout(False)
        CType(Me.UI_Safeformat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents BackGround As PanelControl
    Private WithEvents labelControl4 As LabelControl
    Private WithEvents BableSafe As LabelControl
    Private WithEvents BableMeta As LabelControl
    Private WithEvents panelControl4 As PanelControl
    Public WithEvents labelTotal As LabelControl
    Private WithEvents lLabelInt As LabelControl
    Private WithEvents BableUniBrom As LabelControl
    Private WithEvents SearchControl1 As SearchControl
    Private WithEvents Ground As PanelControl
    Private WithEvents xtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Private WithEvents xtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents UI_Unibrom As PanelControl
    Private WithEvents xtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents UI_Safeformat As PanelControl
    Private WithEvents xtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents xtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents ControList As PanelControl
    Public WithEvents ListBoxview As ListBoxControl
    Friend WithEvents CariPortQcom As Windows.Forms.Timer


End Class
