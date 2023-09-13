Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net.Sockets
Imports System.Text

Namespace BismillahAdb
	Public Class AdbSocket
		Implements IDisposable
		Private _tcpClient As TcpClient

		Private _tcpStream As NetworkStream

		Private _encoding As Encoding = Encoding.ASCII

		Private _buffer As Byte() = New Byte(65535) {}

		Public Sub New(adbServerHost As String, adbServerPort As Integer)
			MyBase.New()
			Try
                Trace(String.Format("Connecting to {0} port {1}", adbServerHost, adbServerPort))
				_tcpClient = New TcpClient(adbServerHost, adbServerPort)
				_tcpStream = _tcpClient.GetStream()
			Catch
                Trace("adbnotrun")
			End Try
		End Sub

		Public Sub Dispose() Implements IDisposable.Dispose
			If _tcpClient IsNot Nothing Then
				_tcpClient.Close()
				_tcpClient = Nothing
			End If
			If _tcpStream IsNot Nothing Then
				_tcpStream.Close()
				_tcpStream = Nothing
			End If
		End Sub

		Public Sub Read(data As Byte(), size As Integer)
			Dim total As Integer = 0
			While total < size
				Dim num As Integer = _tcpStream.Read(data, total, size - total)
				total += num
			End While
		End Sub

		Public Function Read(size As Integer) As Byte()
			Dim bytes(size - 1) As Byte
			Read(bytes, size)
			Return bytes
		End Function

		Public Function ReadAllLines() As String()
			Dim lines As New List(Of String)()
			Using reader As New StreamReader(_tcpStream, _encoding)
				While True
					Dim line As String = reader.ReadLine()
					If line Is Nothing Then
						Exit While
					End If
					lines.Add(line.Trim())
				End While
			End Using
			Return lines.ToArray()
		End Function

		Public Function ReadHexString() As String
			Return ReadString(ReadInt32Hex())
		End Function

		Public Function ReadInt32() As Integer
			Read(_buffer, 4)
			Return BitConverter.ToInt32(_buffer, 0)
		End Function

		Public Function ReadInt32Hex() As Integer
			Read(_buffer, 4)
			Dim hex As String = _encoding.GetString(_buffer, 0, 4)
			Return Convert.ToInt32(hex, 16)
		End Function

		Public Function ReadString(length As Integer) As String
			Read(_buffer, length)
			Return _encoding.GetString(_buffer, 0, length)
		End Function

		Public Function ReadSyncString() As String
			Return ReadString(ReadInt32())
		End Function

		Public Sub SendCommand(command As String)
			WriteString(String.Format("{0:X04}", command.Length))
			WriteString(command)
			Dim response As String = ReadString(4)
			Dim str As String = response
			If str <> "OKAY" Then
				If str = "FAIL" Then
					Throw New AdbException(ReadHexString())
				End If
				Throw New AdbInvalidResponseException(response)
			End If
		End Sub

		Public Function SendSyncCommand(command As String, parameter As String, Optional readResponse As Boolean = True) As String
			Dim str As String
			WriteString(command)
			WriteInt32(parameter.Length)
			WriteString(parameter)
			If readResponse Then
				Dim response As String = ReadString(4)
				If response.Equals("FAIL") Then
					Throw New AdbException(ReadSyncString())
				End If
				str = response
			Else
				str = Nothing
			End If
			Return str
		End Function

		Public Sub Write(data As Byte(), size As Integer)
            Trace("$Sending {size} bytes")
			_tcpStream.Write(data, 0, size)
		End Sub

		Public Sub Write(data As Byte())
			Write(data, data.Length)
		End Sub

		Public Sub WriteInt32(number As Integer)
			Write(BitConverter.GetBytes(number))
		End Sub

		Public Sub WriteString(text As String)
			Dim size As Integer = _encoding.GetBytes(text, 0, text.Length, _buffer, 0)
			Write(_buffer, size)
		End Sub
	End Class
End Namespace