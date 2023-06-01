Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Friend Class RadioButtons
        Inherits RadioButton
        Private checkedColorField As Color = Color.MediumSlateBlue
        Private unCheckedColorField As Color = Color.Gray

        'Properties
        Public Property CheckedColor As Color
            Get
                Return checkedColorField
            End Get

            Set(value As Color)
                checkedColorField = value
                Invalidate()
            End Set
        End Property

        Public Property UnCheckedColor As Color
            Get
                Return unCheckedColorField
            End Get

            Set(value As Color)
                unCheckedColorField = value
                Invalidate()
            End Set
        End Property

        'Constructor
        Public Sub New()
            MinimumSize = New Size(0, 21)
            'Add a padding of 10 to the left to have a considerable distance between the text and the RadioButton.
            Padding = New Padding(10, 0, 0, 0)
        End Sub

        'Overridden methods
        Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
            'Fields
            Dim graphics = pevent.Graphics
            graphics.SmoothingMode = SmoothingMode.AntiAlias
            Dim rbBorderSize = 13.0F
            Dim rbCheckSize = 8.0F
            Dim rectRbBorder As RectangleF = New RectangleF() With {
    .X = 0.5F,
    .Y = (Height - rbBorderSize) / 2, 'Center
    .Width = rbBorderSize,
    .Height = rbBorderSize
}
            Dim rectRbCheck As RectangleF = New RectangleF() With {
    .X = rectRbBorder.X + (rectRbBorder.Width - rbCheckSize) / 2, 'Center
    .Y = (Height - rbCheckSize) / 2, 'Center
    .Width = rbCheckSize,
    .Height = rbCheckSize
}

            'Drawing
            Using penBorder As Pen = New Pen(checkedColorField, 1.6F)
                Using brushRbCheck As SolidBrush = New SolidBrush(checkedColorField)
                    Using brushText As SolidBrush = New SolidBrush(ForeColor)
                        'Draw surface
                        graphics.Clear(BackColor)
                        'Draw Radio Button
                        If Checked Then
                            graphics.DrawEllipse(penBorder, rectRbBorder) 'Circle border
                            graphics.FillEllipse(brushRbCheck, rectRbCheck) 'Circle Radio Check
                        Else
                            penBorder.Color = unCheckedColorField
                            graphics.DrawEllipse(penBorder, rectRbBorder) 'Circle border
                        End If
                        'Draw text
                        graphics.DrawString(Text, Font, brushText, rbBorderSize + 8, (Height - TextRenderer.MeasureText(Text, Font).Height) / 2) 'Y=Center
                    End Using
                End Using
            End Using
        End Sub
End Class