Imports System
Imports System.IO

Namespace BismillahAdb
	Public Module AdbHelpers
		Public Function CombinePath(path1 As String, path2 As String) As String
			Dim str As String = Path.Combine(path1, path2).Replace("\"C, "/"C)
			Return str
		End Function

		Public Function FromUnixTime(unixTime As Integer) As DateTime
			Dim unixEpoch As DateTime = GetUnixEpoch()
			unixEpoch = unixEpoch.AddSeconds(unixTime)
			Return unixEpoch.ToLocalTime()
		End Function

		Private Function GetUnixEpoch() As System.DateTime
			Dim dateTime As System.DateTime = New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
			Return dateTime
		End Function

		Public Function ToUnixTime(dateTime As System.DateTime) As Integer
			Dim timeSpan As TimeSpan = dateTime.ToUniversalTime() - GetUnixEpoch()
			Return Convert.ToInt32(timeSpan.TotalSeconds)
		End Function
	End Module
End Namespace