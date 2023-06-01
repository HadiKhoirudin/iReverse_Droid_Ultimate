Imports System
Imports System.CodeDom.Compiler
Imports System.Configuration
Imports System.Runtime.CompilerServices

Namespace Reverse_Tool.Properties
	<CompilerGenerated>
	<GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")>
	Friend NotInheritable Class Settings
		Inherits ApplicationSettingsBase
		Private Shared defaultInstance As Settings

		Public Shared ReadOnly Property [Default] As Settings
			Get
				Return Settings.defaultInstance
			End Get
		End Property

		Shared Sub New()
			Settings.defaultInstance = DirectCast(SettingsBase.Synchronized(New Settings()), Settings)
		End Sub

		Public Sub New()
			MyBase.New()
		End Sub
	End Class
End Namespace