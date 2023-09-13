Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class loadxml
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(loadxml))
        ListView1 = New ListView()
        SimpleButton1 = New SimpleButton()
        SimpleButton2 = New SimpleButton()
        CheckBox1 = New CheckBox()
        LabelControl1 = New LabelControl()
        SuspendLayout()
        '
        'ListView1
        '
        ListView1.BackColor = Color.FromArgb(38, 38, 38)
        ListView1.BorderStyle = BorderStyle.None
        ListView1.ForeColor = Color.WhiteSmoke
        ListView1.HideSelection = False
        ListView1.Location = New Point(12, 12)
        ListView1.Name = "ListView1"
        ListView1.OwnerDraw = True
        ListView1.Scrollable = False
        ListView1.Size = New Size(274, 227)
        ListView1.TabIndex = 0
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        '
        'SimpleButton1
        '
        SimpleButton1.Location = New Point(187, 247)
        SimpleButton1.Name = "SimpleButton1"
        SimpleButton1.Size = New Size(99, 23)
        SimpleButton1.TabIndex = 2
        SimpleButton1.Text = "Load Selected XML"
        '
        'SimpleButton2
        '
        SimpleButton2.Location = New Point(12, 247)
        SimpleButton2.Name = "SimpleButton2"
        SimpleButton2.Size = New Size(99, 23)
        SimpleButton2.TabIndex = 3
        SimpleButton2.Text = "Cancel"
        '
        'CheckBox1
        '
        CheckBox1.AutoSize = True
        CheckBox1.FlatStyle = FlatStyle.Flat
        CheckBox1.ForeColor = Color.FromArgb(192, 64, 0)
        CheckBox1.Location = New Point(18, 18)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(12, 11)
        CheckBox1.TabIndex = 34
        CheckBox1.UseVisualStyleBackColor = True
        '
        'LabelControl1
        '
        LabelControl1.Appearance.BackColor = Color.FromArgb(70, 70, 70)
        LabelControl1.Appearance.Options.UseBackColor = True
        LabelControl1.Location = New Point(36, 18)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(38, 13)
        LabelControl1.TabIndex = 35
        LabelControl1.Text = "File XML"
        '
        'loadxml
        '
        AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(298, 278)
        Controls.Add(LabelControl1)
        Controls.Add(CheckBox1)
        Controls.Add(SimpleButton2)
        Controls.Add(SimpleButton1)
        Controls.Add(ListView1)
        IconOptions.Image = CType(resources.GetObject("loadxml.IconOptions.Image"), Image)
        MaximizeBox = False
        MinimizeBox = False
        Name = "loadxml"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Load XML Files"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents ListView1 As ListView
    Friend WithEvents SimpleButton1 As SimpleButton
    Friend WithEvents SimpleButton2 As SimpleButton
End Class
