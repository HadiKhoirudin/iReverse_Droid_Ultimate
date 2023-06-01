Imports System
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace BismillahAdb
	Friend Module Tracer
		Public Sub Trace(format As String, ParamArray args As Object())
            Trace(String.Format(format, args))
		End Sub

		Public Sub Trace(message As String)

			Main.SharedUI.TextBox7.Invoke(New Action(Sub()
														 Main.SharedUI.TextBox7.Text = message
													 End Sub))
		End Sub
	End Module
End Namespace