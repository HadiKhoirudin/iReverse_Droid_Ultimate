Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MtkFlash
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MtkFlash))
        Me.BgwFlashfirmware = New System.ComponentModel.BackgroundWorker()
        Me.PythonAdb = New System.ComponentModel.BackgroundWorker()
        Me.TimerSmart = New System.Windows.Forms.Timer(Me.components)
        Me.WorkerAtoport = New System.ComponentModel.BackgroundWorker()
        Me.PanelDg = New DevExpress.XtraEditors.PanelControl()
        Me.CkboxSelectpartitionDataView = New System.Windows.Forms.CheckBox()
        Me.HScrollBarMtkFlashDataView = New DevExpress.XtraEditors.HScrollBar()
        Me.VScrollBarMtkFlashDataView = New DevExpress.XtraEditors.VScrollBar()
        Me.VScrollBarMtkFlashQlMGPTGrid = New DevExpress.XtraEditors.VScrollBar()
        Me.HScrollBarMtkFlashQlMGPTGrid = New DevExpress.XtraEditors.HScrollBar()
        Me.CkboxSelectpartitionQlMGPTGrid = New System.Windows.Forms.CheckBox()
        Me.DataView = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QlMGPTGrid = New System.Windows.Forms.DataGridView()
        Me.dataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MainTab = New DevExpress.XtraTab.XtraTabControl()
        Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelDownload = New DevExpress.XtraEditors.PanelControl()
        Me.Radio_Format = New RadioButtons()
        Me.Radio_Upgrade = New RadioButtons()
        Me.Radio_Download = New RadioButtons()
        Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboSp = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ButtonSP_Micloud = New DevExpress.XtraEditors.SimpleButton()
        Me.panelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.ButtonScatter = New System.Windows.Forms.Button()
        Me.TxtFlashScatter = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.BoxCustomFlash = New CacheBox()
        Me.Btn_Auth = New System.Windows.Forms.Button()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Btn_DA = New System.Windows.Forms.Button()
        Me.labelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtFlashAuth = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtFlashDA = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.ComboChip = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Btn_EMIFlash = New System.Windows.Forms.Button()
        Me.labelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtpreloderEMIFLash = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.labelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.ButtonFlashSP = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonSP_FormatData = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonSP_frp = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonSP_Sam = New DevExpress.XtraEditors.SimpleButton()
        Me.xtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.Punif = New DevExpress.XtraEditors.PanelControl()
        Me.ButtonMiReset = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEraseSAM_LOST = New DevExpress.XtraEditors.SimpleButton()
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
        Me.CheckboxEMI = New CacheBox()
        Me.ButtonEMI = New System.Windows.Forms.Button()
        Me.TxtpreloderEMI = New DevExpress.XtraEditors.TextEdit()
        Me.labelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnGPTread = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonGptWrite = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRebbot = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonReadGPT = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonEraseGPT = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraFlash = New DevExpress.XtraEditors.PanelControl()
        CType(Me.PanelDg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDg.SuspendLayout()
        CType(Me.DataView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QlMGPTGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainTab.SuspendLayout()
        Me.xtraTabPage1.SuspendLayout()
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl1.SuspendLayout()
        CType(Me.PanelDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDownload.SuspendLayout()
        CType(Me.ComboSp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl7.SuspendLayout()
        CType(Me.ComboChip.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtraTabPage2.SuspendLayout()
        CType(Me.Punif, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Punif.SuspendLayout()
        CType(Me.panelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl5.SuspendLayout()
        CType(Me.TxtpreloderEMI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraFlash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraFlash.SuspendLayout()
        Me.SuspendLayout()
        '
        'BgwFlashfirmware
        '
        Me.BgwFlashfirmware.WorkerReportsProgress = True
        Me.BgwFlashfirmware.WorkerSupportsCancellation = True
        '
        'PythonAdb
        '
        '
        'TimerSmart
        '
        '
        'WorkerAtoport
        '
        '
        'PanelDg
        '
        Me.PanelDg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelDg.Controls.Add(Me.CkboxSelectpartitionDataView)
        Me.PanelDg.Controls.Add(Me.HScrollBarMtkFlashDataView)
        Me.PanelDg.Controls.Add(Me.VScrollBarMtkFlashDataView)
        Me.PanelDg.Controls.Add(Me.VScrollBarMtkFlashQlMGPTGrid)
        Me.PanelDg.Controls.Add(Me.HScrollBarMtkFlashQlMGPTGrid)
        Me.PanelDg.Controls.Add(Me.CkboxSelectpartitionQlMGPTGrid)
        Me.PanelDg.Controls.Add(Me.DataView)
        Me.PanelDg.Controls.Add(Me.QlMGPTGrid)
        Me.PanelDg.Dock = DockStyle.Top
        Me.PanelDg.Location = New System.Drawing.Point(2, 2)
        Me.PanelDg.Name = "PanelDg"
        Me.PanelDg.Size = New System.Drawing.Size(649, 283)
        Me.PanelDg.TabIndex = 0
        '
        'CkboxSelectpartitionDataView
        '
        Me.CkboxSelectpartitionDataView.AutoSize = True
        Me.CkboxSelectpartitionDataView.FlatStyle = FlatStyle.Flat
        Me.CkboxSelectpartitionDataView.ForeColor = Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CkboxSelectpartitionDataView.Location = New System.Drawing.Point(5, 6)
        Me.CkboxSelectpartitionDataView.Name = "CkboxSelectpartitionDataView"
        Me.CkboxSelectpartitionDataView.Size = New System.Drawing.Size(12, 11)
        Me.CkboxSelectpartitionDataView.TabIndex = 38
        Me.CkboxSelectpartitionDataView.UseVisualStyleBackColor = True
        '
        'HScrollBarMtkFlashDataView
        '
        Me.HScrollBarMtkFlashDataView.LargeChange = 95
        Me.HScrollBarMtkFlashDataView.Location = New System.Drawing.Point(0, 266)
        Me.HScrollBarMtkFlashDataView.Name = "HScrollBarMtkFlashDataView"
        Me.HScrollBarMtkFlashDataView.Size = New System.Drawing.Size(649, 17)
        Me.HScrollBarMtkFlashDataView.TabIndex = 37
        '
        'VScrollBarMtkFlashDataView
        '
        Me.VScrollBarMtkFlashDataView.Location = New System.Drawing.Point(632, 0)
        Me.VScrollBarMtkFlashDataView.Name = "VScrollBarMtkFlashDataView"
        Me.VScrollBarMtkFlashDataView.Size = New System.Drawing.Size(17, 266)
        Me.VScrollBarMtkFlashDataView.TabIndex = 36
        '
        'VScrollBarMtkFlashQlMGPTGrid
        '
        Me.VScrollBarMtkFlashQlMGPTGrid.Dock = DockStyle.Right
        Me.VScrollBarMtkFlashQlMGPTGrid.Location = New System.Drawing.Point(632, 0)
        Me.VScrollBarMtkFlashQlMGPTGrid.Name = "VScrollBarMtkFlashQlMGPTGrid"
        Me.VScrollBarMtkFlashQlMGPTGrid.Size = New System.Drawing.Size(17, 266)
        Me.VScrollBarMtkFlashQlMGPTGrid.TabIndex = 3
        '
        'HScrollBarMtkFlashQlMGPTGrid
        '
        Me.HScrollBarMtkFlashQlMGPTGrid.Dock = DockStyle.Bottom
        Me.HScrollBarMtkFlashQlMGPTGrid.LargeChange = 95
        Me.HScrollBarMtkFlashQlMGPTGrid.Location = New System.Drawing.Point(0, 266)
        Me.HScrollBarMtkFlashQlMGPTGrid.Name = "HScrollBarMtkFlashQlMGPTGrid"
        Me.HScrollBarMtkFlashQlMGPTGrid.Size = New System.Drawing.Size(649, 17)
        Me.HScrollBarMtkFlashQlMGPTGrid.TabIndex = 35
        '
        'CkboxSelectpartitionQlMGPTGrid
        '
        Me.CkboxSelectpartitionQlMGPTGrid.AutoSize = True
        Me.CkboxSelectpartitionQlMGPTGrid.FlatStyle = FlatStyle.Flat
        Me.CkboxSelectpartitionQlMGPTGrid.ForeColor = Color.Blue
        Me.CkboxSelectpartitionQlMGPTGrid.Location = New System.Drawing.Point(5, 6)
        Me.CkboxSelectpartitionQlMGPTGrid.Name = "CkboxSelectpartitionQlMGPTGrid"
        Me.CkboxSelectpartitionQlMGPTGrid.Size = New System.Drawing.Size(12, 11)
        Me.CkboxSelectpartitionQlMGPTGrid.TabIndex = 33
        Me.CkboxSelectpartitionQlMGPTGrid.UseVisualStyleBackColor = True
        '
        'DataView
        '
        Me.DataView.AllowUserToAddRows = False
        Me.DataView.AllowUserToDeleteRows = False
        Me.DataView.AllowUserToResizeRows = False
        Me.DataView.BackgroundColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.DataView.BorderStyle = BorderStyle.None
        Me.DataView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = Color.White
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.[True]
        Me.DataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column2, Me.Column5, Me.Column3, Me.Column7, Me.Index, Me.Column6})
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle9.ForeColor = Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.[False]
        Me.DataView.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataView.Dock = DockStyle.Fill
        Me.DataView.EnableHeadersVisualStyles = False
        Me.DataView.GridColor = Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.DataView.Location = New System.Drawing.Point(0, 0)
        Me.DataView.Name = "DataView"
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle10.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.[True]
        Me.DataView.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataView.RowHeadersVisible = False
        Me.DataView.ScrollBars = ScrollBars.None
        Me.DataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.DataView.Size = New System.Drawing.Size(649, 283)
        Me.DataView.TabIndex = 29
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.Gray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.NullValue = False
        DataGridViewCellStyle2.SelectionBackColor = Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.FlatStyle = FlatStyle.Flat
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = DataGridViewColumnSortMode.Automatic
        Me.Column4.Width = 20
        '
        'Column1
        '
        DataGridViewCellStyle3.BackColor = Color.DimGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = Color.Silver
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(10, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = Color.White
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "Partitions"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 80
        '
        'Column2
        '
        DataGridViewCellStyle4.BackColor = SystemColors.Info
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cambria", 8.25!, FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = Color.Silver
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(10, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = Color.White
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = "Files"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = DataGridViewTriState.[True]
        Me.Column2.Width = 80
        '
        'Column5
        '
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle5.ForeColor = Color.Silver
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(10, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = Color.White
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column5.HeaderText = "Customs"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = DataGridViewTriState.[True]
        Me.Column5.Width = 80
        '
        'Column3
        '
        DataGridViewCellStyle6.BackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle6.ForeColor = Color.Silver
        DataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(10, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = Color.White
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column3.HeaderText = "Starts"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 80
        '
        'Column7
        '
        Me.Column7.HeaderText = "Sizes"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 80
        '
        'Index
        '
        DataGridViewCellStyle7.ForeColor = Color.GhostWhite
        DataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(10, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = Color.White
        Me.Index.DefaultCellStyle = DataGridViewCellStyle7
        Me.Index.HeaderText = "Indexs"
        Me.Index.Name = "Index"
        Me.Index.Width = 50
        '
        'Column6
        '
        DataGridViewCellStyle8.BackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.ForeColor = Color.LightGray
        DataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(10, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = Color.White
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column6.HeaderText = " Locations"
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = DataGridViewTriState.[True]
        Me.Column6.Width = 1480
        '
        'QlMGPTGrid
        '
        Me.QlMGPTGrid.AllowUserToAddRows = False
        Me.QlMGPTGrid.AllowUserToDeleteRows = False
        Me.QlMGPTGrid.AllowUserToResizeRows = False
        Me.QlMGPTGrid.BackgroundColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.QlMGPTGrid.BorderStyle = BorderStyle.None
        Me.QlMGPTGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle11.ForeColor = Color.White
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.[True]
        Me.QlMGPTGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.QlMGPTGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.QlMGPTGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dataGridViewCheckBoxColumn1, Me.dataGridViewTextBoxColumn1, Me.dataGridViewTextBoxColumn2, Me.dataGridViewTextBoxColumn3, Me.dataGridViewTextBoxColumn4, Me.dataGridViewTextBoxColumn5, Me.dataGridViewTextBoxColumn6})
        DataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle19.ForeColor = Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        DataGridViewCellStyle19.SelectionBackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = DataGridViewTriState.[False]
        Me.QlMGPTGrid.DefaultCellStyle = DataGridViewCellStyle19
        Me.QlMGPTGrid.Dock = DockStyle.Fill
        Me.QlMGPTGrid.EnableHeadersVisualStyles = False
        Me.QlMGPTGrid.GridColor = Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.QlMGPTGrid.Location = New System.Drawing.Point(0, 0)
        Me.QlMGPTGrid.Name = "QlMGPTGrid"
        Me.QlMGPTGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle20.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle20.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = DataGridViewTriState.[True]
        Me.QlMGPTGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.QlMGPTGrid.RowHeadersVisible = False
        Me.QlMGPTGrid.ScrollBars = ScrollBars.None
        Me.QlMGPTGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.QlMGPTGrid.Size = New System.Drawing.Size(649, 283)
        Me.QlMGPTGrid.TabIndex = 34
        '
        'dataGridViewCheckBoxColumn1
        '
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle12.NullValue = False
        DataGridViewCellStyle12.SelectionBackColor = Color.DimGray
        DataGridViewCellStyle12.SelectionForeColor = Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.dataGridViewCheckBoxColumn1.DefaultCellStyle = DataGridViewCellStyle12
        Me.dataGridViewCheckBoxColumn1.FlatStyle = FlatStyle.Flat
        Me.dataGridViewCheckBoxColumn1.HeaderText = ""
        Me.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1"
        Me.dataGridViewCheckBoxColumn1.Resizable = DataGridViewTriState.[False]
        Me.dataGridViewCheckBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic
        Me.dataGridViewCheckBoxColumn1.Width = 20
        '
        'dataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle13.BackColor = Color.DimGray
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Cambria", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = Color.LightGray
        DataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = Color.White
        Me.dataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle13
        Me.dataGridViewTextBoxColumn1.HeaderText = "Partitions"
        Me.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1"
        Me.dataGridViewTextBoxColumn1.Width = 120
        '
        'dataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle14.BackColor = SystemColors.Info
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Cambria", 8.25!)
        DataGridViewCellStyle14.ForeColor = Color.LightGray
        DataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = Color.White
        Me.dataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle14
        Me.dataGridViewTextBoxColumn2.HeaderText = "Offsets"
        Me.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2"
        Me.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.[True]
        '
        'dataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle15.BackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle15.ForeColor = Color.LightGray
        DataGridViewCellStyle15.SelectionBackColor = Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = Color.White
        Me.dataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle15
        Me.dataGridViewTextBoxColumn3.HeaderText = "Lenghts"
        Me.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3"
        Me.dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.[True]
        '
        'dataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle16.BackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle16.ForeColor = Color.LightGray
        DataGridViewCellStyle16.SelectionBackColor = Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = Color.White
        Me.dataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle16
        Me.dataGridViewTextBoxColumn4.HeaderText = "Customs"
        Me.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4"
        Me.dataGridViewTextBoxColumn4.ReadOnly = True
        '
        'dataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle17.BackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle17.ForeColor = Color.LightGray
        DataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle17.SelectionForeColor = Color.White
        Me.dataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle17
        Me.dataGridViewTextBoxColumn5.HeaderText = "Flags"
        Me.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5"
        '
        'dataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle18.ForeColor = Color.LightGray
        DataGridViewCellStyle18.SelectionBackColor = Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = Color.White
        Me.dataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle18
        Me.dataGridViewTextBoxColumn6.HeaderText = "UIDDs"
        Me.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6"
        Me.dataGridViewTextBoxColumn6.Width = 200
        '
        'MainTab
        '
        Me.MainTab.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainTab.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainTab.Dock = DockStyle.Fill
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
        Me.xtraTabPage1.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold)
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
        Me.panelControl1.Controls.Add(Me.PanelDownload)
        Me.panelControl1.Controls.Add(Me.ButtonSP_Micloud)
        Me.panelControl1.Controls.Add(Me.panelControl7)
        Me.panelControl1.Controls.Add(Me.ButtonFlashSP)
        Me.panelControl1.Controls.Add(Me.ButtonSP_FormatData)
        Me.panelControl1.Controls.Add(Me.ButtonSP_frp)
        Me.panelControl1.Controls.Add(Me.ButtonSP_Sam)
        Me.panelControl1.Dock = DockStyle.Fill
        Me.panelControl1.Location = New System.Drawing.Point(0, 0)
        Me.panelControl1.Name = "panelControl1"
        Me.panelControl1.Size = New System.Drawing.Size(627, 193)
        Me.panelControl1.TabIndex = 0
        '
        'PanelDownload
        '
        Me.PanelDownload.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDownload.Controls.Add(Me.Radio_Format)
        Me.PanelDownload.Controls.Add(Me.Radio_Upgrade)
        Me.PanelDownload.Controls.Add(Me.Radio_Download)
        Me.PanelDownload.Controls.Add(Me.labelControl1)
        Me.PanelDownload.Controls.Add(Me.ComboSp)
        Me.PanelDownload.Location = New System.Drawing.Point(5, 4)
        Me.PanelDownload.Name = "PanelDownload"
        Me.PanelDownload.Size = New System.Drawing.Size(619, 33)
        Me.PanelDownload.TabIndex = 2
        '
        'Radio_Format
        '
        Me.Radio_Format.AutoSize = True
        Me.Radio_Format.CheckedColor = Color.Red
        Me.Radio_Format.Font = New System.Drawing.Font("Georgia", 8.25!)
        Me.Radio_Format.ForeColor = Color.Gainsboro
        Me.Radio_Format.Location = New System.Drawing.Point(324, 7)
        Me.Radio_Format.MinimumSize = New System.Drawing.Size(0, 21)
        Me.Radio_Format.Name = "Radio_Format"
        Me.Radio_Format.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Radio_Format.Size = New System.Drawing.Size(137, 21)
        Me.Radio_Format.TabIndex = 30
        Me.Radio_Format.Text = "Format Downlaod"
        Me.Radio_Format.UnCheckedColor = Color.DarkRed
        Me.Radio_Format.UseVisualStyleBackColor = True
        '
        'Radio_Upgrade
        '
        Me.Radio_Upgrade.AutoSize = True
        Me.Radio_Upgrade.CheckedColor = Color.Red
        Me.Radio_Upgrade.Font = New System.Drawing.Font("Georgia", 8.25!)
        Me.Radio_Upgrade.ForeColor = Color.Gainsboro
        Me.Radio_Upgrade.Location = New System.Drawing.Point(162, 6)
        Me.Radio_Upgrade.MinimumSize = New System.Drawing.Size(0, 21)
        Me.Radio_Upgrade.Name = "Radio_Upgrade"
        Me.Radio_Upgrade.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Radio_Upgrade.Size = New System.Drawing.Size(145, 21)
        Me.Radio_Upgrade.TabIndex = 29
        Me.Radio_Upgrade.Text = "Firmware Upgrade"
        Me.Radio_Upgrade.UnCheckedColor = Color.DarkRed
        Me.Radio_Upgrade.UseVisualStyleBackColor = True
        '
        'Radio_Download
        '
        Me.Radio_Download.AutoSize = True
        Me.Radio_Download.Checked = True
        Me.Radio_Download.CheckedColor = Color.Red
        Me.Radio_Download.Font = New System.Drawing.Font("Georgia", 8.25!)
        Me.Radio_Download.ForeColor = Color.Gainsboro
        Me.Radio_Download.Location = New System.Drawing.Point(16, 6)
        Me.Radio_Download.MinimumSize = New System.Drawing.Size(0, 21)
        Me.Radio_Download.Name = "Radio_Download"
        Me.Radio_Download.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Radio_Download.Size = New System.Drawing.Size(123, 21)
        Me.Radio_Download.TabIndex = 28
        Me.Radio_Download.TabStop = True
        Me.Radio_Download.Text = "Download Only"
        Me.Radio_Download.UnCheckedColor = Color.DarkRed
        Me.Radio_Download.UseVisualStyleBackColor = True
        '
        'labelControl1
        '
        Me.labelControl1.Location = New System.Drawing.Point(467, 10)
        Me.labelControl1.Name = "labelControl1"
        Me.labelControl1.Size = New System.Drawing.Size(32, 13)
        Me.labelControl1.TabIndex = 27
        Me.labelControl1.Text = "Conn :"
        '
        'ComboSp
        '
        Me.ComboSp.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboSp.EditValue = "BromUSB"
        Me.ComboSp.Location = New System.Drawing.Point(512, 7)
        Me.ComboSp.Name = "ComboSp"
        Me.ComboSp.Properties.AllowFocused = False
        Me.ComboSp.Properties.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboSp.Properties.Appearance.Options.UseBackColor = True
        Me.ComboSp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboSp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.ComboSp.Properties.Items.AddRange(New Object() {"BromUSB", "BromUART"})
        Me.ComboSp.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboSp.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboSp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboSp.Size = New System.Drawing.Size(100, 20)
        Me.ComboSp.TabIndex = 23
        '
        'ButtonSP_Micloud
        '
        Me.ButtonSP_Micloud.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSP_Micloud.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonSP_Micloud.Appearance.Options.UseBackColor = True
        Me.ButtonSP_Micloud.Appearance.Options.UseTextOptions = True
        Me.ButtonSP_Micloud.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonSP_Micloud.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonSP_Micloud.AppearanceHovered.Options.UseFont = True
        Me.ButtonSP_Micloud.AppearanceHovered.Options.UseImage = True
        Me.ButtonSP_Micloud.ImageOptions.Image = CType(resources.GetObject("ButtonSP_Micloud.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonSP_Micloud.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonSP_Micloud.Location = New System.Drawing.Point(265, 43)
        Me.ButtonSP_Micloud.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonSP_Micloud.Name = "ButtonSP_Micloud"
        Me.ButtonSP_Micloud.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonSP_Micloud.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonSP_Micloud.Size = New System.Drawing.Size(118, 28)
        Me.ButtonSP_Micloud.TabIndex = 28
        Me.ButtonSP_Micloud.Text = "RESET MICLOUD"
        '
        'panelControl7
        '
        Me.panelControl7.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelControl7.Controls.Add(Me.ButtonScatter)
        Me.panelControl7.Controls.Add(Me.TxtFlashScatter)
        Me.panelControl7.Controls.Add(Me.BoxCustomFlash)
        Me.panelControl7.Controls.Add(Me.Btn_Auth)
        Me.panelControl7.Controls.Add(Me.LabelControl3)
        Me.panelControl7.Controls.Add(Me.Btn_DA)
        Me.panelControl7.Controls.Add(Me.labelControl11)
        Me.panelControl7.Controls.Add(Me.TxtFlashAuth)
        Me.panelControl7.Controls.Add(Me.labelControl2)
        Me.panelControl7.Controls.Add(Me.TxtFlashDA)
        Me.panelControl7.Controls.Add(Me.ComboChip)
        Me.panelControl7.Controls.Add(Me.Btn_EMIFlash)
        Me.panelControl7.Controls.Add(Me.labelControl9)
        Me.panelControl7.Controls.Add(Me.TxtpreloderEMIFLash)
        Me.panelControl7.Controls.Add(Me.labelControl10)
        Me.panelControl7.Location = New System.Drawing.Point(5, 77)
        Me.panelControl7.Name = "panelControl7"
        Me.panelControl7.Size = New System.Drawing.Size(619, 103)
        Me.panelControl7.TabIndex = 27
        '
        'ButtonScatter
        '
        Me.ButtonScatter.BackColor = Color.Transparent
        Me.ButtonScatter.FlatAppearance.BorderSize = 0
        Me.ButtonScatter.FlatStyle = FlatStyle.Flat
        Me.ButtonScatter.Image = CType(resources.GetObject("ButtonScatter.Image"), System.Drawing.Image)
        Me.ButtonScatter.Location = New System.Drawing.Point(486, 9)
        Me.ButtonScatter.Name = "ButtonScatter"
        Me.ButtonScatter.Size = New System.Drawing.Size(23, 13)
        Me.ButtonScatter.TabIndex = 50
        Me.ButtonScatter.UseVisualStyleBackColor = False
        '
        'TxtFlashScatter
        '
        Me.TxtFlashScatter.Cursor = Cursors.IBeam
        Me.TxtFlashScatter.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtFlashScatter.ForeColor = Color.White
        Me.TxtFlashScatter.HintForeColor = Color.Empty
        Me.TxtFlashScatter.HintText = ""
        Me.TxtFlashScatter.isPassword = False
        Me.TxtFlashScatter.LineFocusedColor = Color.Red
        Me.TxtFlashScatter.LineIdleColor = Color.DarkRed
        Me.TxtFlashScatter.LineMouseHoverColor = Color.Red
        Me.TxtFlashScatter.LineThickness = 2
        Me.TxtFlashScatter.Location = New System.Drawing.Point(92, 1)
        Me.TxtFlashScatter.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFlashScatter.Name = "TxtFlashScatter"
        Me.TxtFlashScatter.Size = New System.Drawing.Size(417, 24)
        Me.TxtFlashScatter.TabIndex = 51
        Me.TxtFlashScatter.TextAlign = HorizontalAlignment.Left
        '
        'BoxCustomFlash
        '
        Me.BoxCustomFlash.AutoSize = True
        Me.BoxCustomFlash.CheckedColor = Color.Red
        Me.BoxCustomFlash.Font = New System.Drawing.Font("Georgia", 8.25!)
        Me.BoxCustomFlash.ForeColor = Color.Gainsboro
        Me.BoxCustomFlash.Location = New System.Drawing.Point(512, 79)
        Me.BoxCustomFlash.MinimumSize = New System.Drawing.Size(0, 21)
        Me.BoxCustomFlash.Name = "BoxCustomFlash"
        Me.BoxCustomFlash.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.BoxCustomFlash.Size = New System.Drawing.Size(114, 21)
        Me.BoxCustomFlash.TabIndex = 41
        Me.BoxCustomFlash.Text = "Custom Flash"
        Me.BoxCustomFlash.UnCheckedColor = Color.DarkRed
        Me.BoxCustomFlash.UseVisualStyleBackColor = True
        '
        'Btn_Auth
        '
        Me.Btn_Auth.BackColor = Color.Transparent
        Me.Btn_Auth.FlatAppearance.BorderSize = 0
        Me.Btn_Auth.FlatStyle = FlatStyle.Flat
        Me.Btn_Auth.Image = CType(resources.GetObject("Btn_Auth.Image"), System.Drawing.Image)
        Me.Btn_Auth.Location = New System.Drawing.Point(520, 57)
        Me.Btn_Auth.Name = "Btn_Auth"
        Me.Btn_Auth.Size = New System.Drawing.Size(23, 13)
        Me.Btn_Auth.TabIndex = 45
        Me.Btn_Auth.UseVisualStyleBackColor = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(8, 81)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl3.TabIndex = 37
        Me.LabelControl3.Text = "Preloader | EMI"
        '
        'Btn_DA
        '
        Me.Btn_DA.BackColor = Color.Transparent
        Me.Btn_DA.FlatAppearance.BorderSize = 0
        Me.Btn_DA.FlatStyle = FlatStyle.Flat
        Me.Btn_DA.Image = CType(resources.GetObject("Btn_DA.Image"), System.Drawing.Image)
        Me.Btn_DA.Location = New System.Drawing.Point(520, 32)
        Me.Btn_DA.Name = "Btn_DA"
        Me.Btn_DA.Size = New System.Drawing.Size(23, 13)
        Me.Btn_DA.TabIndex = 44
        Me.Btn_DA.UseVisualStyleBackColor = False
        '
        'labelControl11
        '
        Me.labelControl11.Location = New System.Drawing.Point(8, 33)
        Me.labelControl11.Name = "labelControl11"
        Me.labelControl11.Size = New System.Drawing.Size(14, 13)
        Me.labelControl11.TabIndex = 22
        Me.labelControl11.Text = "DA"
        '
        'TxtFlashAuth
        '
        Me.TxtFlashAuth.Cursor = Cursors.IBeam
        Me.TxtFlashAuth.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtFlashAuth.ForeColor = Color.White
        Me.TxtFlashAuth.HintForeColor = Color.Empty
        Me.TxtFlashAuth.HintText = ""
        Me.TxtFlashAuth.isPassword = False
        Me.TxtFlashAuth.LineFocusedColor = Color.Red
        Me.TxtFlashAuth.LineIdleColor = Color.DarkRed
        Me.TxtFlashAuth.LineMouseHoverColor = Color.Red
        Me.TxtFlashAuth.LineThickness = 2
        Me.TxtFlashAuth.Location = New System.Drawing.Point(92, 48)
        Me.TxtFlashAuth.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFlashAuth.Name = "TxtFlashAuth"
        Me.TxtFlashAuth.Size = New System.Drawing.Size(450, 24)
        Me.TxtFlashAuth.TabIndex = 46
        Me.TxtFlashAuth.TextAlign = HorizontalAlignment.Left
        '
        'labelControl2
        '
        Me.labelControl2.Location = New System.Drawing.Point(512, 9)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(33, 13)
        Me.labelControl2.TabIndex = 26
        Me.labelControl2.Text = "Layout"
        '
        'TxtFlashDA
        '
        Me.TxtFlashDA.Cursor = Cursors.IBeam
        Me.TxtFlashDA.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtFlashDA.ForeColor = Color.White
        Me.TxtFlashDA.HintForeColor = Color.Empty
        Me.TxtFlashDA.HintText = ""
        Me.TxtFlashDA.isPassword = False
        Me.TxtFlashDA.LineFocusedColor = Color.Red
        Me.TxtFlashDA.LineIdleColor = Color.DarkRed
        Me.TxtFlashDA.LineMouseHoverColor = Color.Red
        Me.TxtFlashDA.LineThickness = 2
        Me.TxtFlashDA.Location = New System.Drawing.Point(92, 23)
        Me.TxtFlashDA.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFlashDA.Name = "TxtFlashDA"
        Me.TxtFlashDA.Size = New System.Drawing.Size(450, 24)
        Me.TxtFlashDA.TabIndex = 48
        Me.TxtFlashDA.TextAlign = HorizontalAlignment.Left
        '
        'ComboChip
        '
        Me.ComboChip.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboChip.EditValue = "eMMC"
        Me.ComboChip.Location = New System.Drawing.Point(553, 5)
        Me.ComboChip.Name = "ComboChip"
        Me.ComboChip.Properties.AllowFocused = False
        Me.ComboChip.Properties.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboChip.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.5!, FontStyle.Bold)
        Me.ComboChip.Properties.Appearance.ForeColor = Color.Silver
        Me.ComboChip.Properties.Appearance.Options.UseBackColor = True
        Me.ComboChip.Properties.Appearance.Options.UseFont = True
        Me.ComboChip.Properties.Appearance.Options.UseForeColor = True
        Me.ComboChip.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboChip.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.ComboChip.Properties.Items.AddRange(New Object() {"eMMC", "  UFS"})
        Me.ComboChip.Properties.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.ComboChip.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ComboChip.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ComboChip.Size = New System.Drawing.Size(59, 20)
        Me.ComboChip.TabIndex = 22
        '
        'Btn_EMIFlash
        '
        Me.Btn_EMIFlash.BackColor = Color.Transparent
        Me.Btn_EMIFlash.FlatAppearance.BorderSize = 0
        Me.Btn_EMIFlash.FlatStyle = FlatStyle.Flat
        Me.Btn_EMIFlash.Image = CType(resources.GetObject("Btn_EMIFlash.Image"), System.Drawing.Image)
        Me.Btn_EMIFlash.Location = New System.Drawing.Point(486, 80)
        Me.Btn_EMIFlash.Name = "Btn_EMIFlash"
        Me.Btn_EMIFlash.Size = New System.Drawing.Size(23, 13)
        Me.Btn_EMIFlash.TabIndex = 47
        Me.Btn_EMIFlash.UseVisualStyleBackColor = False
        '
        'labelControl9
        '
        Me.labelControl9.Location = New System.Drawing.Point(8, 9)
        Me.labelControl9.Name = "labelControl9"
        Me.labelControl9.Size = New System.Drawing.Size(35, 13)
        Me.labelControl9.TabIndex = 24
        Me.labelControl9.Text = "Scatter"
        '
        'TxtpreloderEMIFLash
        '
        Me.TxtpreloderEMIFLash.Cursor = Cursors.IBeam
        Me.TxtpreloderEMIFLash.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtpreloderEMIFLash.ForeColor = Color.White
        Me.TxtpreloderEMIFLash.HintForeColor = Color.Empty
        Me.TxtpreloderEMIFLash.HintText = ""
        Me.TxtpreloderEMIFLash.isPassword = False
        Me.TxtpreloderEMIFLash.LineFocusedColor = Color.Red
        Me.TxtpreloderEMIFLash.LineIdleColor = Color.DarkRed
        Me.TxtpreloderEMIFLash.LineMouseHoverColor = Color.Red
        Me.TxtpreloderEMIFLash.LineThickness = 2
        Me.TxtpreloderEMIFLash.Location = New System.Drawing.Point(92, 71)
        Me.TxtpreloderEMIFLash.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtpreloderEMIFLash.Name = "TxtpreloderEMIFLash"
        Me.TxtpreloderEMIFLash.Size = New System.Drawing.Size(417, 24)
        Me.TxtpreloderEMIFLash.TabIndex = 49
        Me.TxtpreloderEMIFLash.TextAlign = HorizontalAlignment.Left
        '
        'labelControl10
        '
        Me.labelControl10.Location = New System.Drawing.Point(8, 57)
        Me.labelControl10.Name = "labelControl10"
        Me.labelControl10.Size = New System.Drawing.Size(42, 13)
        Me.labelControl10.TabIndex = 23
        Me.labelControl10.Text = "Auth File"
        '
        'ButtonFlashSP
        '
        Me.ButtonFlashSP.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFlashSP.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonFlashSP.Appearance.Options.UseBackColor = True
        Me.ButtonFlashSP.Appearance.Options.UseTextOptions = True
        Me.ButtonFlashSP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonFlashSP.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonFlashSP.AppearanceHovered.Options.UseFont = True
        Me.ButtonFlashSP.AppearanceHovered.Options.UseImage = True
        Me.ButtonFlashSP.ImageOptions.Image = CType(resources.GetObject("ButtonFlashSP.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonFlashSP.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonFlashSP.Location = New System.Drawing.Point(502, 43)
        Me.ButtonFlashSP.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonFlashSP.Name = "ButtonFlashSP"
        Me.ButtonFlashSP.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonFlashSP.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonFlashSP.Size = New System.Drawing.Size(78, 28)
        Me.ButtonFlashSP.TabIndex = 28
        Me.ButtonFlashSP.Text = "FLASH"
        '
        'ButtonSP_FormatData
        '
        Me.ButtonSP_FormatData.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSP_FormatData.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonSP_FormatData.Appearance.Options.UseBackColor = True
        Me.ButtonSP_FormatData.Appearance.Options.UseTextOptions = True
        Me.ButtonSP_FormatData.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonSP_FormatData.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonSP_FormatData.AppearanceHovered.Options.UseFont = True
        Me.ButtonSP_FormatData.AppearanceHovered.Options.UseImage = True
        Me.ButtonSP_FormatData.ImageOptions.Image = CType(resources.GetObject("ButtonSP_FormatData.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonSP_FormatData.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonSP_FormatData.Location = New System.Drawing.Point(54, 43)
        Me.ButtonSP_FormatData.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonSP_FormatData.Name = "ButtonSP_FormatData"
        Me.ButtonSP_FormatData.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonSP_FormatData.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonSP_FormatData.Size = New System.Drawing.Size(107, 28)
        Me.ButtonSP_FormatData.TabIndex = 28
        Me.ButtonSP_FormatData.Text = "FORMAT DATA"
        '
        'ButtonSP_frp
        '
        Me.ButtonSP_frp.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSP_frp.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonSP_frp.Appearance.Options.UseBackColor = True
        Me.ButtonSP_frp.Appearance.Options.UseTextOptions = True
        Me.ButtonSP_frp.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonSP_frp.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonSP_frp.AppearanceHovered.Options.UseFont = True
        Me.ButtonSP_frp.AppearanceHovered.Options.UseImage = True
        Me.ButtonSP_frp.ImageOptions.Image = CType(resources.GetObject("ButtonSP_frp.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonSP_frp.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonSP_frp.Location = New System.Drawing.Point(167, 43)
        Me.ButtonSP_frp.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonSP_frp.Name = "ButtonSP_frp"
        Me.ButtonSP_frp.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonSP_frp.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonSP_frp.Size = New System.Drawing.Size(92, 28)
        Me.ButtonSP_frp.TabIndex = 28
        Me.ButtonSP_frp.Text = "ERASE FRP"
        '
        'ButtonSP_Sam
        '
        Me.ButtonSP_Sam.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSP_Sam.Appearance.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonSP_Sam.Appearance.Options.UseBackColor = True
        Me.ButtonSP_Sam.Appearance.Options.UseTextOptions = True
        Me.ButtonSP_Sam.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonSP_Sam.AppearanceHovered.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ButtonSP_Sam.AppearanceHovered.Options.UseFont = True
        Me.ButtonSP_Sam.AppearanceHovered.Options.UseImage = True
        Me.ButtonSP_Sam.ImageOptions.Image = CType(resources.GetObject("ButtonSP_Sam.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonSP_Sam.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.ButtonSP_Sam.Location = New System.Drawing.Point(389, 43)
        Me.ButtonSP_Sam.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonSP_Sam.Name = "ButtonSP_Sam"
        Me.ButtonSP_Sam.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.ButtonSP_Sam.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonSP_Sam.Size = New System.Drawing.Size(107, 28)
        Me.ButtonSP_Sam.TabIndex = 28
        Me.ButtonSP_Sam.Text = "FRP SAMSUNG"
        '
        'xtraTabPage2
        '
        Me.xtraTabPage2.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold)
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
        Me.Punif.Controls.Add(Me.BtnEraseSAM_LOST)
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
        Me.Punif.Dock = DockStyle.Fill
        Me.Punif.Location = New System.Drawing.Point(0, 0)
        Me.Punif.Name = "Punif"
        Me.Punif.Size = New System.Drawing.Size(627, 193)
        Me.Punif.TabIndex = 0
        '
        'ButtonMiReset
        '
        Me.ButtonMiReset.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMiReset.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonMiReset.Location = New System.Drawing.Point(473, 164)
        Me.ButtonMiReset.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonMiReset.Name = "ButtonMiReset"
        Me.ButtonMiReset.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonMiReset.Size = New System.Drawing.Size(150, 25)
        Me.ButtonMiReset.TabIndex = 46
        Me.ButtonMiReset.Text = "RESET MCLOUD"
        '
        'BtnEraseSAM_LOST
        '
        Me.BtnEraseSAM_LOST.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEraseSAM_LOST.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.BtnEraseSAM_LOST.Appearance.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.25!)
        Me.BtnEraseSAM_LOST.Appearance.Options.UseBackColor = True
        Me.BtnEraseSAM_LOST.Appearance.Options.UseFont = True
        Me.BtnEraseSAM_LOST.Appearance.Options.UseTextOptions = True
        Me.BtnEraseSAM_LOST.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.BtnEraseSAM_LOST.AppearanceHovered.Font = New System.Drawing.Font("Bahnschrift SemiLight SemiConde", 8.75!)
        Me.BtnEraseSAM_LOST.AppearanceHovered.Options.UseFont = True
        Me.BtnEraseSAM_LOST.AppearanceHovered.Options.UseImage = True
        Me.BtnEraseSAM_LOST.ImageOptions.Image = CType(resources.GetObject("BtnEraseSAM_LOST.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnEraseSAM_LOST.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.BtnEraseSAM_LOST.Location = New System.Drawing.Point(473, 105)
        Me.BtnEraseSAM_LOST.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnEraseSAM_LOST.Name = "BtnEraseSAM_LOST"
        Me.BtnEraseSAM_LOST.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.BtnEraseSAM_LOST.Size = New System.Drawing.Size(150, 25)
        Me.BtnEraseSAM_LOST.TabIndex = 47
        Me.BtnEraseSAM_LOST.Text = "ERASE SAMSUNG LOST"
        '
        'ButtonFormatUser
        '
        Me.ButtonFormatUser.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFormatUser.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonFormatUser.Location = New System.Drawing.Point(473, 135)
        Me.ButtonFormatUser.LookAndFeel.UseDefaultLookAndFeel = False
        Me.ButtonFormatUser.Name = "ButtonFormatUser"
        Me.ButtonFormatUser.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonFormatUser.Size = New System.Drawing.Size(150, 25)
        Me.ButtonFormatUser.TabIndex = 48
        Me.ButtonFormatUser.Text = "FORMAT DATA"
        '
        'BtnSAM_FRP_Oem
        '
        Me.BtnSAM_FRP_Oem.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSAM_FRP_Oem.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.BtnSAM_FRP_Oem.Text = "FRP SAMSUNG [OEM]"
        '
        'ButtonFRP_SAM
        '
        Me.ButtonFRP_SAM.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFRP_SAM.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonRpmbErase.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRpmbErase.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonWrNvram.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonWrNvram.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonAllFRP.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAllFRP.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonRPMBwrite.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRPMBwrite.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonNvErase.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonNvErase.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonRelockUBL.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRelockUBL.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonRDrpmb.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRDrpmb.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonUniNvBackup.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUniNvBackup.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonUBL.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUBL.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonAuth.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAuth.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonReadInfo.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReadInfo.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.panelControl5.Controls.Add(Me.CheckboxEMI)
        Me.panelControl5.Controls.Add(Me.ButtonEMI)
        Me.panelControl5.Controls.Add(Me.TxtpreloderEMI)
        Me.panelControl5.Controls.Add(Me.labelControl6)
        Me.panelControl5.Location = New System.Drawing.Point(6, 32)
        Me.panelControl5.Name = "panelControl5"
        Me.panelControl5.Size = New System.Drawing.Size(616, 37)
        Me.panelControl5.TabIndex = 39
        '
        'CheckboxEMI
        '
        Me.CheckboxEMI.AutoSize = True
        Me.CheckboxEMI.CheckedColor = Color.Red
        Me.CheckboxEMI.ForeColor = Color.Gainsboro
        Me.CheckboxEMI.Location = New System.Drawing.Point(463, 8)
        Me.CheckboxEMI.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CheckboxEMI.Name = "CheckboxEMI"
        Me.CheckboxEMI.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CheckboxEMI.Size = New System.Drawing.Size(144, 21)
        Me.CheckboxEMI.TabIndex = 36
        Me.CheckboxEMI.Text = "Custom Preloder [EMI]"
        Me.CheckboxEMI.UnCheckedColor = Color.DarkRed
        Me.CheckboxEMI.UseVisualStyleBackColor = True
        '
        'ButtonEMI
        '
        Me.ButtonEMI.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEMI.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonEMI.Enabled = False
        Me.ButtonEMI.FlatAppearance.BorderSize = 0
        Me.ButtonEMI.FlatStyle = FlatStyle.Flat
        Me.ButtonEMI.Image = CType(resources.GetObject("ButtonEMI.Image"), System.Drawing.Image)
        Me.ButtonEMI.Location = New System.Drawing.Point(417, 10)
        Me.ButtonEMI.Name = "ButtonEMI"
        Me.ButtonEMI.Size = New System.Drawing.Size(24, 16)
        Me.ButtonEMI.TabIndex = 35
        Me.ButtonEMI.UseVisualStyleBackColor = False
        '
        'TxtpreloderEMI
        '
        Me.TxtpreloderEMI.Location = New System.Drawing.Point(106, 9)
        Me.TxtpreloderEMI.Name = "TxtpreloderEMI"
        Me.TxtpreloderEMI.Properties.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.TxtpreloderEMI.Properties.Appearance.ForeColor = Color.Silver
        Me.TxtpreloderEMI.Properties.Appearance.Options.UseBackColor = True
        Me.TxtpreloderEMI.Properties.Appearance.Options.UseForeColor = True
        Me.TxtpreloderEMI.Size = New System.Drawing.Size(338, 20)
        Me.TxtpreloderEMI.TabIndex = 28
        '
        'labelControl6
        '
        Me.labelControl6.Location = New System.Drawing.Point(13, 12)
        Me.labelControl6.Name = "labelControl6"
        Me.labelControl6.Size = New System.Drawing.Size(74, 13)
        Me.labelControl6.TabIndex = 0
        Me.labelControl6.Text = "Preloader | EMI"
        '
        'BtnGPTread
        '
        Me.BtnGPTread.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGPTread.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonGptWrite.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGptWrite.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonRebbot.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRebbot.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonReadGPT.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReadGPT.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        Me.ButtonEraseGPT.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEraseGPT.Appearance.BackColor = Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
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
        'XtraFlash
        '
        Me.XtraFlash.Controls.Add(Me.MainTab)
        Me.XtraFlash.Controls.Add(Me.PanelDg)
        Me.XtraFlash.Location = New System.Drawing.Point(0, 0)
        Me.XtraFlash.Name = "XtraFlash"
        Me.XtraFlash.Size = New System.Drawing.Size(653, 482)
        Me.XtraFlash.TabIndex = 2
        '
        'MtkFlash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.Controls.Add(Me.XtraFlash)
        Me.Name = "MtkFlash"
        Me.Size = New System.Drawing.Size(653, 482)
        CType(Me.PanelDg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDg.ResumeLayout(False)
        Me.PanelDg.PerformLayout()
        CType(Me.DataView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QlMGPTGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainTab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainTab.ResumeLayout(False)
        Me.xtraTabPage1.ResumeLayout(False)
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl1.ResumeLayout(False)
        CType(Me.PanelDownload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDownload.ResumeLayout(False)
        Me.PanelDownload.PerformLayout()
        CType(Me.ComboSp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl7.ResumeLayout(False)
        Me.panelControl7.PerformLayout()
        CType(Me.ComboChip.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtraTabPage2.ResumeLayout(False)
        CType(Me.Punif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Punif.ResumeLayout(False)
        CType(Me.panelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl5.ResumeLayout(False)
        Me.panelControl5.PerformLayout()
        CType(Me.TxtpreloderEMI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraFlash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraFlash.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WorkerAtoport As BackgroundWorker
    Private WithEvents PanelDg As PanelControl
    Private WithEvents HScrollBarMtkFlashQlMGPTGrid As DevExpress.XtraEditors.HScrollBar
    Public WithEvents QlMGPTGrid As DataGridView
    Private WithEvents CkboxSelectpartitionQlMGPTGrid As CheckBox
    Private WithEvents MainTab As DevExpress.XtraTab.XtraTabControl
    Private WithEvents xtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents panelControl1 As PanelControl
    Private WithEvents PanelDownload As PanelControl
    Private WithEvents labelControl1 As LabelControl
    Private WithEvents ComboSp As ComboBoxEdit
    Private WithEvents ButtonSP_Micloud As SimpleButton
    Private WithEvents panelControl7 As PanelControl
    Private WithEvents labelControl11 As LabelControl
    Private WithEvents labelControl2 As LabelControl
    Private WithEvents ComboChip As ComboBoxEdit
    Private WithEvents labelControl9 As LabelControl
    Private WithEvents labelControl10 As LabelControl
    Private WithEvents ButtonFlashSP As SimpleButton
    Private WithEvents ButtonSP_FormatData As SimpleButton
    Private WithEvents ButtonSP_frp As SimpleButton
    Private WithEvents ButtonSP_Sam As SimpleButton
    Private WithEvents xtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Private WithEvents Punif As PanelControl
    Private WithEvents ButtonMiReset As SimpleButton
    Private WithEvents BtnEraseSAM_LOST As SimpleButton
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
    Private WithEvents ButtonEMI As Button
    Private WithEvents TxtpreloderEMI As TextEdit
    Private WithEvents labelControl6 As LabelControl
    Private WithEvents BtnGPTread As SimpleButton
    Private WithEvents ButtonGptWrite As SimpleButton
    Private WithEvents ButtonRebbot As SimpleButton
    Private WithEvents ButtonReadGPT As SimpleButton
    Private WithEvents ButtonEraseGPT As SimpleButton
    Private WithEvents XtraFlash As PanelControl
    Friend WithEvents PythonAdb As BackgroundWorker
    Friend WithEvents TimerSmart As Windows.Forms.Timer
    Friend WithEvents CheckboxEMI As CacheBox
    Friend WithEvents Radio_Format As RadioButtons
    Friend WithEvents Radio_Upgrade As RadioButtons
    Friend WithEvents Radio_Download As RadioButtons
    Public WithEvents BgwFlashfirmware As BackgroundWorker
    Friend WithEvents VScrollBarMtkFlashQlMGPTGrid As DevExpress.XtraEditors.VScrollBar
    Public WithEvents DataView As DataGridView
    Private WithEvents LabelControl3 As LabelControl
    Friend WithEvents BoxCustomFlash As CacheBox
    Private WithEvents HScrollBarMtkFlashDataView As DevExpress.XtraEditors.HScrollBar
    Friend WithEvents VScrollBarMtkFlashDataView As DevExpress.XtraEditors.VScrollBar
    Private WithEvents CkboxSelectpartitionDataView As CheckBox
    Friend WithEvents Column4 As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Index As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Private WithEvents ButtonScatter As Button
    Friend WithEvents TxtFlashScatter As Bunifu.Framework.UI.BunifuMaterialTextbox
    Private WithEvents Btn_Auth As Button
    Private WithEvents Btn_DA As Button
    Friend WithEvents TxtFlashAuth As Bunifu.Framework.UI.BunifuMaterialTextbox
    Private WithEvents Btn_EMIFlash As Button
    Friend WithEvents TxtpreloderEMIFLash As Bunifu.Framework.UI.BunifuMaterialTextbox
    Public WithEvents TxtFlashDA As Bunifu.Framework.UI.BunifuMaterialTextbox
End Class
