Imports System

Namespace BismillahAdb
	Public Class AdbInvalidResponseException
		Inherits AdbException
		Friend Sub New(response As String)
			MyBase.New(String.Concat("The server returned an invalid response '", response, "'"))
		End Sub
	End Class
End Namespace