Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports System.IO
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.loginbutton = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckBox1 = New CacheBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BunifuMaterialTextboxUsername = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.BunifuMaterialTextboxPassword = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.Reverse_Tool.My.Resources.logoireverse
        Me.pictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(150, 197)
        Me.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 10
        Me.pictureBox1.TabStop = False
        '
        'loginbutton
        '
        Me.loginbutton.Location = New System.Drawing.Point(212, 134)
        Me.loginbutton.Name = "loginbutton"
        Me.loginbutton.Size = New System.Drawing.Size(267, 33)
        Me.loginbutton.TabIndex = 5
        Me.loginbutton.Text = "LOGIN"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckedColor = Drawing.Color.Red
        Me.CheckBox1.ForeColor = Drawing.Color.Gainsboro
        Me.CheckBox1.Location = New System.Drawing.Point(212, 107)
        Me.CheckBox1.MinimumSize = New System.Drawing.Size(0, 21)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.CheckBox1.Size = New System.Drawing.Size(104, 21)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Remember Me"
        Me.CheckBox1.UnCheckedColor = Drawing.Color.DarkRed
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(228, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 13
        '
        'BunifuMaterialTextboxUsername
        '
        Me.BunifuMaterialTextboxUsername.Cursor = Cursors.IBeam
        Me.BunifuMaterialTextboxUsername.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.BunifuMaterialTextboxUsername.ForeColor = Drawing.Color.White
        Me.BunifuMaterialTextboxUsername.HintForeColor = Drawing.Color.Empty
        Me.BunifuMaterialTextboxUsername.HintText = ""
        Me.BunifuMaterialTextboxUsername.isPassword = False
        Me.BunifuMaterialTextboxUsername.LineFocusedColor = Drawing.Color.Red
        Me.BunifuMaterialTextboxUsername.LineIdleColor = Drawing.Color.DarkRed
        Me.BunifuMaterialTextboxUsername.LineMouseHoverColor = Drawing.Color.Red
        Me.BunifuMaterialTextboxUsername.LineThickness = 3
        Me.BunifuMaterialTextboxUsername.Location = New System.Drawing.Point(212, 26)
        Me.BunifuMaterialTextboxUsername.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuMaterialTextboxUsername.Name = "BunifuMaterialTextboxUsername"
        Me.BunifuMaterialTextboxUsername.Size = New System.Drawing.Size(267, 33)
        Me.BunifuMaterialTextboxUsername.TabIndex = 17
        Me.BunifuMaterialTextboxUsername.Text = "Please Input Username & Password"
        Me.BunifuMaterialTextboxUsername.TextAlign = HorizontalAlignment.Center
        '
        'BunifuMaterialTextboxPassword
        '
        Me.BunifuMaterialTextboxPassword.Cursor = Cursors.IBeam
        Me.BunifuMaterialTextboxPassword.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.BunifuMaterialTextboxPassword.ForeColor = Drawing.Color.White
        Me.BunifuMaterialTextboxPassword.HintForeColor = Drawing.Color.Empty
        Me.BunifuMaterialTextboxPassword.HintText = ""
        Me.BunifuMaterialTextboxPassword.isPassword = True
        Me.BunifuMaterialTextboxPassword.LineFocusedColor = Drawing.Color.Red
        Me.BunifuMaterialTextboxPassword.LineIdleColor = Drawing.Color.DarkRed
        Me.BunifuMaterialTextboxPassword.LineMouseHoverColor = Drawing.Color.Red
        Me.BunifuMaterialTextboxPassword.LineThickness = 3
        Me.BunifuMaterialTextboxPassword.Location = New System.Drawing.Point(212, 67)
        Me.BunifuMaterialTextboxPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuMaterialTextboxPassword.Name = "BunifuMaterialTextboxPassword"
        Me.BunifuMaterialTextboxPassword.Size = New System.Drawing.Size(267, 33)
        Me.BunifuMaterialTextboxPassword.TabIndex = 18
        Me.BunifuMaterialTextboxPassword.TextAlign = HorizontalAlignment.Center
        '
        'Login
        '
        Me.ActiveGlowColor = Drawing.Color.Red
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 217)
        Me.Controls.Add(Me.BunifuMaterialTextboxPassword)
        Me.Controls.Add(Me.BunifuMaterialTextboxUsername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.loginbutton)
        Me.Controls.Add(Me.pictureBox1)
        Me.FormBorderEffect = FormBorderEffect.Glow
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.IconOptions.Image = Global.Reverse_Tool.My.Resources.logoireverse
        Me.MaximizeBox = False
        Me.Name = "Login"
        Me.Opacity = 0.98R
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Login | iREVERSE DROID ULTIMATE - @HadiKIT"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents pictureBox1 As PictureBox

    Friend WithEvents loginbutton As SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label

    Friend WithEvents CheckBox1 As CacheBox
    Friend WithEvents BunifuMaterialTextboxUsername As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents BunifuMaterialTextboxPassword As Bunifu.Framework.UI.BunifuMaterialTextbox
End Class
