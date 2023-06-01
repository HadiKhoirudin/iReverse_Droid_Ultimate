Imports System

Namespace BismillahAdb
	Public Class AdbException
		Inherits Exception
		Friend Sub New(message As String)
			MyBase.New(message)
            Trace(message)
		End Sub
	End Class
End Namespace