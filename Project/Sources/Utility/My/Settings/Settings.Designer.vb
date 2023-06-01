Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
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
        Me.PanelControlGroup2 = New DevExpress.XtraEditors.PanelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButtonSaveFiles = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckEditShowPassword = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEditEncrypt = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControlPassword = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControlFile = New DevExpress.XtraEditors.LabelControl()
        Me.TxtFile = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButtonBrowseFile = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControlGroup1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.BgWorker = New System.ComponentModel.BackgroundWorker()
        CType(Me.PanelControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlGroup2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.CheckEditShowPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditEncrypt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlGroup1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControlGroup2
        '
        Me.PanelControlGroup2.Controls.Add(Me.GroupControl1)
        Me.PanelControlGroup2.Location = New System.Drawing.Point(0, 306)
        Me.PanelControlGroup2.Name = "PanelControlGroup2"
        Me.PanelControlGroup2.Size = New System.Drawing.Size(653, 173)
        Me.PanelControlGroup2.TabIndex = 1
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.SimpleButtonSaveFiles)
        Me.GroupControl1.Controls.Add(Me.CheckEditShowPassword)
        Me.GroupControl1.Controls.Add(Me.CheckEditEncrypt)
        Me.GroupControl1.Controls.Add(Me.LabelControlPassword)
        Me.GroupControl1.Controls.Add(Me.TxtPassword)
        Me.GroupControl1.Controls.Add(Me.LabelControlFile)
        Me.GroupControl1.Controls.Add(Me.TxtFile)
        Me.GroupControl1.Controls.Add(Me.SimpleButtonBrowseFile)
        Me.GroupControl1.Location = New System.Drawing.Point(16, 18)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(618, 136)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "ENCRYPT DECRYPT FILE"
        '
        'SimpleButtonSaveFiles
        '
        Me.SimpleButtonSaveFiles.Location = New System.Drawing.Point(436, 102)
        Me.SimpleButtonSaveFiles.Name = "SimpleButtonSaveFiles"
        Me.SimpleButtonSaveFiles.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButtonSaveFiles.TabIndex = 13
        Me.SimpleButtonSaveFiles.Text = " Save Files "
        '
        'CheckEditShowPassword
        '
        Me.CheckEditShowPassword.EditValue = True
        Me.CheckEditShowPassword.Location = New System.Drawing.Point(526, 46)
        Me.CheckEditShowPassword.Name = "CheckEditShowPassword"
        Me.CheckEditShowPassword.Properties.Caption = " Hide"
        Me.CheckEditShowPassword.Size = New System.Drawing.Size(75, 18)
        Me.CheckEditShowPassword.TabIndex = 12
        '
        'CheckEditEncrypt
        '
        Me.CheckEditEncrypt.Location = New System.Drawing.Point(526, 72)
        Me.CheckEditEncrypt.Name = "CheckEditEncrypt"
        Me.CheckEditEncrypt.Properties.Caption = " Encrypt"
        Me.CheckEditEncrypt.Size = New System.Drawing.Size(75, 18)
        Me.CheckEditEncrypt.TabIndex = 11
        '
        'LabelControlPassword
        '
        Me.LabelControlPassword.Location = New System.Drawing.Point(17, 48)
        Me.LabelControlPassword.Name = "LabelControlPassword"
        Me.LabelControlPassword.Size = New System.Drawing.Size(92, 13)
        Me.LabelControlPassword.TabIndex = 10
        Me.LabelControlPassword.Text = "Password             : "
        '
        'TxtPassword
        '
        Me.TxtPassword.EditValue = "BabiBangsad"
        Me.TxtPassword.Location = New System.Drawing.Point(115, 45)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Properties.UseSystemPasswordChar = True
        Me.TxtPassword.Size = New System.Drawing.Size(396, 20)
        Me.TxtPassword.TabIndex = 9
        '
        'LabelControlFile
        '
        Me.LabelControlFile.Location = New System.Drawing.Point(17, 74)
        Me.LabelControlFile.Name = "LabelControlFile"
        Me.LabelControlFile.Size = New System.Drawing.Size(92, 13)
        Me.LabelControlFile.TabIndex = 8
        Me.LabelControlFile.Text = "File                       : "
        '
        'TxtFile
        '
        Me.TxtFile.Location = New System.Drawing.Point(115, 71)
        Me.TxtFile.Name = "TxtFile"
        Me.TxtFile.Size = New System.Drawing.Size(396, 20)
        Me.TxtFile.TabIndex = 7
        '
        'SimpleButtonBrowseFile
        '
        Me.SimpleButtonBrowseFile.Location = New System.Drawing.Point(115, 102)
        Me.SimpleButtonBrowseFile.Name = "SimpleButtonBrowseFile"
        Me.SimpleButtonBrowseFile.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButtonBrowseFile.TabIndex = 6
        Me.SimpleButtonBrowseFile.Text = " Browse Folder "
        '
        'PanelControlGroup1
        '
        Me.PanelControlGroup1.Controls.Add(Me.LabelControl1)
        Me.PanelControlGroup1.Controls.Add(Me.CheckBox1)
        Me.PanelControlGroup1.Controls.Add(Me.ListView1)
        Me.PanelControlGroup1.Location = New System.Drawing.Point(0, 3)
        Me.PanelControlGroup1.Name = "PanelControlGroup1"
        Me.PanelControlGroup1.Size = New System.Drawing.Size(650, 297)
        Me.PanelControlGroup1.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseBackColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(28, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl1.TabIndex = 38
        Me.LabelControl1.Text = "Files"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.FlatStyle = FlatStyle.Flat
        Me.CheckBox1.ForeColor = Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CheckBox1.Location = New System.Drawing.Point(5, 5)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(12, 11)
        Me.CheckBox1.TabIndex = 37
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.BackColor = Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ListView1.BorderStyle = BorderStyle.None
        Me.ListView1.Dock = DockStyle.Fill
        Me.ListView1.ForeColor = Color.WhiteSmoke
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(2, 2)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.OwnerDraw = True
        Me.ListView1.Size = New System.Drawing.Size(646, 293)
        Me.ListView1.TabIndex = 36
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = View.Details
        '
        'BgWorker
        '
        Me.BgWorker.WorkerReportsProgress = True
        Me.BgWorker.WorkerSupportsCancellation = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.Controls.Add(Me.PanelControlGroup1)
        Me.Controls.Add(Me.PanelControlGroup2)
        Me.Name = "Settings"
        Me.Size = New System.Drawing.Size(653, 482)
        CType(Me.PanelControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlGroup2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.CheckEditShowPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditEncrypt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlGroup1.ResumeLayout(False)
        Me.PanelControlGroup1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlGroup2 As PanelControl
    Friend WithEvents PanelControlGroup1 As PanelControl

    Friend WithEvents GroupControl1 As GroupControl
    Friend WithEvents LabelControlPassword As LabelControl
    Friend WithEvents TxtPassword As TextEdit
    Friend WithEvents LabelControlFile As LabelControl
    Friend WithEvents TxtFile As TextEdit
    Friend WithEvents SimpleButtonBrowseFile As SimpleButton
    Friend WithEvents CheckEditEncrypt As CheckEdit
    Friend WithEvents LabelControl1 As LabelControl
    Public WithEvents CheckBox1 As CheckBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents SimpleButtonSaveFiles As SimpleButton
    Friend WithEvents CheckEditShowPassword As CheckEdit


End Class
