Imports System.IO
Imports System.Linq
Imports System.Text
Imports LibUsbDotNet
Imports LibUsbDotNet.Main
Namespace Potato.Fastboot
    Public Class Fastboot
        Private Const USB_VID As Integer = &H18D1
        Private Const USB_PID As Integer = &HD00D
        Private Const HEADER_SIZE As Integer = 4
        Private Const BLOCK_SIZE As Integer = 512 * 1024 ' 512 KB

        Public Property Timeout As Integer = 3000

        Private device As UsbDevice
        Private targetSerialNumber As String

        Public Enum Status
            Fail
            Okay
            Data
            Info
            Unknown
        End Enum

        Public Class Response
            Public Property Status As Status
            Public Property Payload As String
            Public Property RawData As Byte()

            Public Sub New(ByVal status As Status, ByVal payload As String)
                Me.Status = status
                Me.Payload = payload
            End Sub
        End Class

        Public Sub New(ByVal serial As String)
            targetSerialNumber = serial
        End Sub

        Public Sub New()
            targetSerialNumber = Nothing
        End Sub

        Private Function GetStatusFromString(ByVal header As String) As Status
            Select Case header
                Case "INFO"
                    Return Status.Info
                Case "OKAY"
                    Return Status.Okay
                Case "DATA"
                    Return Status.Data
                Case "FAIL"
                    Return Status.Fail
                Case Else
                    Return Status.Unknown
            End Select
        End Function

        Public Function Wait()
            While True
                Dim allDevices As UsbRegDeviceList = UsbDevice.AllDevices

                If allDevices.Any(Function(x) x.Vid = USB_VID And x.Pid = USB_PID) Then
                    Return True
                End If

                If Counter = 0 Then
                    Return False
                End If

                Delay(1)
                Counter -= 1
                Main.SharedUI.LabelTimer.Invoke(CType(Sub() Main.SharedUI.LabelTimer.Text = Counter, System.Action))
            End While
            Return False
        End Function

        Public Sub Connect()
            Dim finder As UsbDeviceFinder

            If String.IsNullOrWhiteSpace(targetSerialNumber) Then
                finder = New UsbDeviceFinder(USB_VID, USB_PID)
            Else
                finder = New UsbDeviceFinder(USB_VID, USB_PID, targetSerialNumber)
            End If

            device = UsbDevice.OpenUsbDevice(finder)

            Do While device Is Nothing
                device = UsbDevice.OpenUsbDevice(finder)
            Loop

            Dim wDev = TryCast(device, IUsbDevice)

            If TypeOf wDev Is IUsbDevice Then
                wDev.SetConfiguration(1)
                wDev.ClaimInterface(0)
            End If
        End Sub


        Public Sub Disconnect()
            device.Close()
        End Sub


        Public Function GetSerialNumber() As String
            Return device.Info.SerialString
        End Function


        Public Function Command(ByVal pCommand As Byte()) As Response
            Dim writeEndpoint = device.OpenEndpointWriter(WriteEndpointID.Ep01)
            Dim readEndpoint = device.OpenEndpointReader(ReadEndpointID.Ep01)

            Dim wrAct As Integer = Nothing
            writeEndpoint.Write(pCommand, Timeout, wrAct)

            If wrAct <> pCommand.Length Then
                Throw New System.Exception($"Failed to write command! Transfered: {wrAct} of {pCommand.Length} bytes")
            End If

            Dim status As Status
            Dim response As StringBuilder = New StringBuilder()
            Dim buffer As Byte() = New Byte(63) {}
            Dim strBuffer As String = Nothing
            Dim rdAct As Integer = Nothing

            While True
                readEndpoint.Read(buffer, Timeout, rdAct)

                strBuffer = Encoding.ASCII.GetString(buffer)

                If strBuffer.Length < HEADER_SIZE Then
                    status = Status.Unknown
                Else
                    Dim header As New String(strBuffer.Take(HEADER_SIZE).ToArray())

                    status = GetStatusFromString(header)
                End If

                response.Append(strBuffer.Skip(HEADER_SIZE).Take(rdAct - HEADER_SIZE).ToArray())

                response.Append(Microsoft.VisualBasic.Constants.vbLf)

                If status <> Status.Info Then
                    Exit While
                End If
            End While

            Dim str As String = response.ToString().Replace(CStr(Microsoft.VisualBasic.Constants.vbCr), CStr(String.Empty)).Replace(Microsoft.VisualBasic.Constants.vbNullChar, String.Empty)

            Return New Response(status, str) With {
                    .RawData = Encoding.ASCII.GetBytes(strBuffer)
                }
        End Function


        Private Sub SendDataCommand(ByVal size As Long)
            If Command($"download:{size:X8}").Status <> Status.Data Then
                Throw New System.Exception($"Invalid response from device! (data size: {size})")
            End If
        End Sub


        Private Sub TransferBlock(ByVal stream As FileStream, ByVal writeEndpoint As UsbEndpointWriter, ByVal buffer As Byte(), ByVal size As Integer)
            stream.Read(buffer, 0, size)
            Dim act As Integer = Nothing
            writeEndpoint.Write(buffer, Timeout, act)

            If act <> size Then
                Throw New System.Exception($"Failed to transfer block (sent {act} of {size})")
            End If
        End Sub


        Public Sub UploadData(ByVal stream As FileStream)
            Dim writeEndpoint = device.OpenEndpointWriter(WriteEndpointID.Ep01)
            Dim readEndpoint = device.OpenEndpointReader(ReadEndpointID.Ep01)

            Dim totallength As Long = stream.Length
            Dim length As Long = stream.Length
            Dim buffer As Byte() = New Byte(524287) {}

            SendDataCommand(length)

            Dim resultprogress As Integer
            Dim fileOffset As Long = 0
            Dim totalprogress As Long = 0

            While length >= BLOCK_SIZE
                fileOffset += stream.Length
                totalprogress += length
                resultprogress = CInt(System.Math.Round((fileOffset / 100))) - CInt(System.Math.Round((totalprogress / 100)))

                If resultprogress < totallength Then
                    ProcessBar1(CInt(System.Math.Round((resultprogress / 1000))), CInt(System.Math.Round((totallength / 1000))))
                End If

                TransferBlock(stream, writeEndpoint, buffer, BLOCK_SIZE)
                length -= BLOCK_SIZE
            End While

            If length > 0 Then
                buffer = New Byte(length - 1) {}
                TransferBlock(stream, writeEndpoint, buffer, length)
            End If

            Dim resBuffer As Byte() = New Byte(63) {}

            readEndpoint.Read(resBuffer, Timeout, Nothing)

            Dim strBuffer As String = Encoding.ASCII.GetString(resBuffer)

            If strBuffer.Length < HEADER_SIZE Then
                Throw New System.Exception($"Invalid response from device: {strBuffer}")
            End If

            Dim header As String = New String(strBuffer.Take(HEADER_SIZE).ToArray())

            Dim status As Status = GetStatusFromString(header)

            If status <> status.Okay Then
                Throw New System.Exception($"Invalid status: {strBuffer}")
            Else
                ProcessBar1(100, 100)
            End If
        End Sub

        Public Sub UploadData(ByVal path As String)
            Using stream = New FileStream(path, FileMode.Open)
                UploadData(stream)
            End Using
        End Sub

        Public Shared Function GetDevices() As String()
            Dim dev As UsbDevice

            Dim devices = New System.Collections.Generic.List(Of String)()

            Dim allDevices As UsbRegDeviceList = UsbDevice.AllDevices

            For Each usbRegistry As UsbRegistry In allDevices
                If usbRegistry.Vid <> USB_VID OrElse usbRegistry.Pid <> USB_PID Then
                    Continue For
                End If

                If usbRegistry.Open(dev) Then
                    devices.Add(dev.Info.SerialString)
                    dev.Close()
                End If
            Next

            Return devices.ToArray()
        End Function

        Public Function Command(ByVal pCommand As String) As Response
            Return Command(Encoding.ASCII.GetBytes(pCommand))
        End Function
    End Class
End Namespace