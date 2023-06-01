Imports System
Imports System.Runtime.CompilerServices

Namespace BismillahAdb
	Public Class AdbAppInfo
		Public Property FileName As String

		Public Property Location As AdbAppLocation

		Public Property Name As String

		Public Property Type As AdbAppType

		Public Sub New(name As String, fileName As String, type As AdbAppType, location As AdbAppLocation)
			MyBase.New()
			Me.Name = name
			Me.FileName = fileName
			Me.Type = type
			Me.Location = location
		End Sub
	End Class
End Namespace