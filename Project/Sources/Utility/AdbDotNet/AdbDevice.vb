Imports System
Imports System.Runtime.CompilerServices

Namespace BismillahAdb
	Public Class AdbDevice
		Public Property Device As String

		Public Property Model As String

		Public Property Product As String

		Public Property SerialNumber As String

		Public Sub New(id As String, product As String, model As String, device As String)
			MyBase.New()
			SerialNumber = id
			Me.Product = product
			Me.Model = model
			Me.Device = device
		End Sub

		Public Overrides Function ToString() As String
			Return String.Concat(New String() { "serialNumber:", SerialNumber, ", product:", Product, ", model:", Model, ", device:", Device })
		End Function
	End Class
End Namespace