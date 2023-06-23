Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Friend Class CacheBox
    Inherits CheckBox
    Private checkedColor_Conflict As Color = Color.MediumSlateBlue
    Private unCheckedColor_Conflict As Color = Color.Gray

    Public Property CheckedColor() As Color
        Get
            Return checkedColor_Conflict
        End Get

        Set(value As Color)
            checkedColor_Conflict = value
            Me.Invalidate()
        End Set
    End Property

    Public Property UnCheckedColor() As Color
        Get
            Return unCheckedColor_Conflict
        End Get

        Set(ByVal value As Color)
            unCheckedColor_Conflict = value
            Me.Invalidate()
        End Set
    End Property

    'Constructor
    Public Sub New()
        Me.MinimumSize = New Size(0, 21)
        'Add a padding of 10 to the left to have a considerable distance between the text and the RadioButton.
        Me.Padding = New Padding(10, 0, 0, 0)
    End Sub


    'Overridden methods
    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        'Fields
        Dim graphics As Graphics = pevent.Graphics
        graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rbBorderSize As Single = 13.0F
        Dim rbCheckSize As Single = 8.0F
        Dim rectRbBorder As New RectangleF() With {
            .X = 0.5F,
            .Y = (Me.Height - rbBorderSize) / 2,
            .Width = rbBorderSize,
            .Height = rbBorderSize
        }
        Dim rectRbCheck As New RectangleF() With {
            .X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2),
            .Y = (Me.Height - rbCheckSize) / 2,
            .Width = rbCheckSize,
            .Height = rbCheckSize
        }

        'Drawing
        Using penBorder As New Pen(checkedColor_Conflict, 1.6F)
            Using brushRbCheck As New SolidBrush(checkedColor_Conflict)
                Using brushText As New SolidBrush(Me.ForeColor)
                    'Draw surface
                    graphics.Clear(Me.BackColor)
                    'Draw Radio Button
                    If Me.Checked Then
                        graphics.DrawEllipse(penBorder, rectRbBorder) 'Circle border
                        graphics.FillEllipse(brushRbCheck, rectRbCheck) 'Circle Radio Check
                    Else
                        penBorder.Color = unCheckedColor_Conflict
                        graphics.DrawEllipse(penBorder, rectRbBorder) 'Circle border
                    End If
                    'Draw text
                    graphics.DrawString(Me.Text, Me.Font, brushText, rbBorderSize + 8, (Me.Height - TextRenderer.MeasureText(Me.Text, Me.Font).Height) \ 2) 'Y=Center
                End Using
            End Using
        End Using
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub
End Class
