Imports System
Imports System.Runtime.CompilerServices

Namespace BismillahAdb
	Public Class AdbFileInfo
		Public Property FullName As String

		Public ReadOnly Property IsDirectory As Boolean
			Get
				Return (Mode And 16384) > 0
			End Get
		End Property

		Public ReadOnly Property IsFile As Boolean
			Get
				Return (Mode And 32768) > 0
			End Get
		End Property

		Public ReadOnly Property IsSymbolicLink As Boolean
			Get
				Return (Mode And 40960) > 0
			End Get
		End Property

		Public Property Mode As Integer

		Public Property Modified As DateTime

		Public Property Name As String

		Public Property Size As Integer

		Friend Sub New(fullName As String, name As String, size As Integer, mode As Integer, modified As DateTime)
			MyBase.New()
			Me.FullName = fullName
			Me.Name = name
			Me.Size = size
			Me.Mode = mode
			Me.Modified = modified
		End Sub
	End Class
End Namespace