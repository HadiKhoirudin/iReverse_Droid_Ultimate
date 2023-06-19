Imports System
Imports System.Drawing
Imports System.IO
Imports System.IO.Ports
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports Microsoft.VisualBasic
Imports Reverse_Tool.Bismillah.DISK
Imports Reverse_Tool.Bismillah.FIREHOSE.FIREHOSE_MANAGER

Namespace Bismillah.SAHARA
    Public Class SAHARA_MANAGER
        Private Property mode() As SAHARA_MODE
        Private Shared Function ByteArrayToString(ba() As Byte) As String
            Dim hex As New StringBuilder(ba.Length * 2)
            For Each b As Byte In ba
                hex.AppendFormat("{0:x2}", b)
            Next b
            Return hex.ToString()
        End Function

        Public Property Ports As New SerialPort()
        Public Shared IsLoaderExist As Boolean = False
        Public Sub PortsOpen()
            Try
                If Ports.IsOpen Then
                    Ports.Close()
                    Ports.Dispose()
                End If
                Ports.BaudRate = 115200 'BaudRate
                Ports.Handshake = Handshake.None
                Ports.DataBits = 8 'DataBits
                Ports.StopBits = StopBits.One
                Ports.Parity = Parity.None
                Ports.DtrEnable = True
                Ports.NewLine = Environment.NewLine
                Ports.PortName = "COM" & PortQcom
                Ports.Open()
            Catch ex As Exception
                If Ports.IsOpen Then
                    Ports.Close()
                End If
                MsgBox(ex.ToString)
            End Try
        End Sub

        Public Shared Function RawDeserialize(rawData() As Byte, position As Integer, anyType As Type) As Object
            Dim rawsize As Integer = Marshal.SizeOf(anyType)
            If rawsize > rawData.Length Then
                Return Nothing
            End If
            Dim buffer As IntPtr = Marshal.AllocHGlobal(rawsize)
            Marshal.Copy(rawData, position, buffer, rawsize)
            Dim retobj As Object = Marshal.PtrToStructure(buffer, anyType)
            Marshal.FreeHGlobal(buffer)
            Return retobj
        End Function
        Public Shared Function SerializeMessage(Of T As Structure)(msg As T) As Byte()
            Dim objsize As Integer = Marshal.SizeOf(GetType(T))
            Dim ret(objsize - 1) As Byte
            Dim buff As IntPtr = Marshal.AllocHGlobal(objsize)
            Marshal.StructureToPtr(msg, buff, True)
            Marshal.Copy(buff, ret, 0, objsize)
            Marshal.FreeHGlobal(buff)
            Return ret
        End Function

        Private _pblInfo As New SAHARA_PBL_INFO()
        Private Property deviceMode() As SAHARA_MODE
        Public Property connected() As Boolean

        Public Sub New()
            cpu64 = False
            openPort()
        End Sub
        Private Sub sendBytes(bytes() As Byte)
            Write(bytes)
            Thread.Sleep(80)
        End Sub
        Public Shared cpu64 As Boolean = False
        Private Function validateResponse(expectedCMD As SAHARA_CMD, response() As Byte) As Boolean
            Dim numBytes As Integer = response.Length
            If expectedCMD = SAHARA_CMD.SAHARA_CMD_READ_DATA AndAlso numBytes = 20 Then
                cpu64 = False
                Return True
            End If
            If expectedCMD = SAHARA_CMD.SAHARA_CMD_READ_DATA AndAlso numBytes = 32 Then
                cpu64 = True
                Return True
            End If
            If expectedCMD = SAHARA_CMD.SAHARA_CMD_HELLO_REQ AndAlso numBytes = 48 Then
                Return True
            End If
            If expectedCMD = SAHARA_CMD.SAHARA_CMD_IMG_END_TRSFR AndAlso numBytes = 16 Then
                Return True
            End If
            If expectedCMD = SAHARA_CMD.SAHARA_CMD_IMG_DONE_RESP AndAlso numBytes = 16 Then
                Dim x = RawDeserialize(response, 0, GetType(SAHARA_RESPONSE_IMGDONE_PACKET))
            End If
            If expectedCMD = SAHARA_CMD.SAHARA_CMD_READY AndAlso numBytes = 8 Then
                Dim x = RawDeserialize(response, 0, GetType(SAHARA_RESPONSE_IMGDONE_PACKET))
                Return True
            End If
            If expectedCMD = SAHARA_CMD.SAHARA_CMD_EXECUTE_RESPONSE AndAlso numBytes = 16 Then
                Return True
            End If
            Return False
        End Function
        Public Function validateClientCmd(expectedCMD As SAHARA_CMD, response() As Byte) As Boolean
            Dim expectedLen As Integer = Marshal.SizeOf(GetType(SAHARA_RESPONSE_EXECCMD_RESPONSE))

            If response.Length <> expectedLen Then
                Return False
            End If
            If response.Length = expectedLen Then
                Dim respStruct = DirectCast(RawDeserialize(response, 0, GetType(SAHARA_RESPONSE_EXECCMD_RESPONSE)), SAHARA_RESPONSE_EXECCMD_RESPONSE)
                If respStruct.header.command = expectedCMD Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Function

        Private Sub sendFlashLoader(initReq As SAHARA_REQUESTS_READDATA)
            Dim bytesSent As Integer = 0
            Dim i As Integer = 1
            Dim doneSending As Boolean = False
            Dim fh As Byte() = loader
            Dim retry = 0
            RichLogs("Sending Loader    : ", Color.White, True, False)
            Do While Not doneSending
                Dim bytesToSend As Integer = initReq.size
                Dim offset As Integer = initReq.offset

                Dim stream As Stream = New MemoryStream(fh)
                Using reader As New BinaryReader(stream)
                    Dim buffer(bytesToSend - 1) As Byte
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin)
                    reader.Read(buffer, 0, bytesToSend)
                    Write(buffer)
                    bytesSent += buffer.Length
                    ProcessBar2(bytesSent, fh.Length)
                    Dim response = Read(0)
                    If response.Length = 0 Then
                        Do
                            response = Read(10)
                            retry += 1
                            If response.Length = 0 Then
                                If retry = 10 Then
                                    sendingloaderStatus = False
                                    RichLogs("Packet Rejected ", Color.Red, True, True)
                                    Return
                                End If
                                Continue Do
                            Else
                                retry = 0
                                Exit Do
                            End If

                        Loop

                    End If
                    If validateResponse(SAHARA_CMD.SAHARA_CMD_READ_DATA, response) Then
                        Dim response2 = DirectCast(RawDeserialize(response, 0, GetType(SAHARA_REQUESTS_READDATA)), SAHARA_REQUESTS_READDATA)
                        initReq = response2

                        i += 5
                        Continue Do
                    ElseIf validateResponse(SAHARA_CMD.SAHARA_CMD_IMG_END_TRSFR, response) Then
                        Dim imgDonePkt As New SAHARA_REQUESTS_IMG_DONE()
                        imgDonePkt.header.command = SAHARA_CMD.SAHARA_CMD_IMG_DONE_REQ
                        imgDonePkt.header.size = Marshal.SizeOf(GetType(SAHARA_REQUESTS_IMG_DONE))
                        Write(SerializeMessage(imgDonePkt))
                        Dim comBuffer = Read(100)
                        Dim doneResp = DirectCast(RawDeserialize(comBuffer, 0, GetType(SAHARA_RESPONSE_IMGDONE_PACKET)), SAHARA_RESPONSE_IMGDONE_PACKET)
                        If doneResp.status = SAHARA_STATUS.SAHARA_STATUS_32 Then
                            RichLogs("OK", Color.White, True, True)
                            mode = SAHARA_MODE.SAHARA_MODE_IMAGE_TX_COMPLETE
                            Ports.Close()
                            sendingloaderStatus = True
                            Exit Do
                        Else
                            Ports.Close()
                            RichLogs("Failed  ", Color.Red, True, True)
                            RichLogs(doneResp.status.ToString, Color.Red, True, True)
                            sendingloaderStatus = False
                            Exit Do
                        End If
                    Else

                        sendingloaderStatus = False
                        RichLogs("Packet Rejected", Color.Red, True, True)
                        RichLogs("Loader Is Mismatch With Devices", Color.Red, True, True)
                        Ports.Close()
                        Exit Do
                    End If
                End Using
            Loop
        End Sub

        Private Sub sendFlashLoader64(initReq As SAHARA_REQUESTS_READDATA_64)
            Dim bytesSent As Integer = 0
            Dim i As Integer = 1
            Dim fh As Byte() = loader
            Dim doneSending As Boolean = False
            Dim retry = 0

            RichLogs("Sending Loader    : ", Color.White, True, False)
            Do While Not doneSending
                Dim bytesToSend As Integer = initReq.size
                Dim offset As Integer = initReq.offset

                Dim stream As Stream = New MemoryStream(fh)
                Using reader As New BinaryReader(stream)
                    Dim buffer(bytesToSend - 1) As Byte
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin)
                    reader.Read(buffer, 0, bytesToSend)
                    Write(buffer)
                    bytesSent += bytesToSend
                    ProcessBar2(bytesSent, fh.Length)
                    Dim response = Read(0)
                    If response.Length = 0 Then
                        Do
                            response = Read(10)
                            retry += 1
                            If response.Length = 0 Then
                                If retry = 10 Then
                                    sendingloaderStatus = False
                                    RichLogs("Packet Rejected ", Color.Red, True, True)

                                    Return
                                End If
                                Continue Do
                            Else
                                retry = 0
                                Exit Do
                            End If

                        Loop

                    End If
                    If validateResponse(SAHARA_CMD.SAHARA_CMD_READ_DATA, response) Then
                        Dim response2 = DirectCast(RawDeserialize(response, 0, GetType(SAHARA_REQUESTS_READDATA_64)), SAHARA_REQUESTS_READDATA_64)
                        initReq = response2
                        i += 5
                        Continue Do
                    ElseIf validateResponse(SAHARA_CMD.SAHARA_CMD_IMG_END_TRSFR, response) Then
                        Dim imgDonePkt As New SAHARA_REQUESTS_IMG_DONE64()
                        imgDonePkt.header.command = SAHARA_CMD.SAHARA_CMD_IMG_DONE_REQ
                        imgDonePkt.header.size = Marshal.SizeOf(GetType(SAHARA_REQUESTS_IMG_DONE64))
                        Write(SerializeMessage(imgDonePkt))
                        Dim comBuffer = Read(100)
                        Dim doneResp = DirectCast(RawDeserialize(comBuffer, 0, GetType(SAHARA_RESPONSE_IMGDONE_PACKET64)), SAHARA_RESPONSE_IMGDONE_PACKET64)
                        If doneResp.status = SAHARA_STATUS.SAHARA_STATUS_64 Then
                            RichLogs("OK", Color.Yellow, True, True)
                            mode = SAHARA_MODE.SAHARA_MODE_IMAGE_TX_COMPLETE
                            sendingloaderStatus = True
                            Ports.Close()
                            Exit Do
                        Else
                            sendingloaderStatus = False
                            RichLogs("Failed  ", Color.Red, True, True)
                            RichLogs(doneResp.status.ToString, Color.Red, True, True)
                            Ports.Close()
                            Exit Do

                        End If
                    Else
                        Ports.Close()
                        sendingloaderStatus = False
                        RichLogs("Packet Rejected", Color.Red, True, True)
                        RichLogs("Loader Is Mismatch With Devices", Color.Red, True, True)
                        Exit Do
                    End If
                End Using
            Loop
        End Sub
        Private Sub SendHelloResponse(pkt As SAHARA_REQUESTS_HELLO, mode As SAHARA_MODE)

            If connected Then

                If mode = SAHARA_MODE.SAHARA_MODE_COMMAND Then
                    pkt.header.command = SAHARA_CMD.SAHARA_CMD_HELLO_RESP
                    pkt.mode = SAHARA_MODE.SAHARA_MODE_COMMAND
                    pkt.header.size = Marshal.SizeOf(GetType(SAHARA_REQUESTS_HELLO))
                    pkt.maxCommandPacketSize = 0
                    Me.mode = SAHARA_MODE.SAHARA_MODE_COMMAND
                    RichLogs("Hello Response Packet   : ", Color.White, True, False)
                    Dim bytes() As Byte = SerializeMessage(pkt)
                    sendBytes(bytes)
                    RichLogs("OK", Color.White, True, True)
                End If

                If mode = SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING Then

                    pkt.header.command = SAHARA_CMD.SAHARA_CMD_HELLO_RESP
                    pkt.mode = SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING
                    pkt.header.size = Marshal.SizeOf(GetType(SAHARA_REQUESTS_HELLO))
                    pkt.maxCommandPacketSize = 0
                    Me.mode = SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING

                    Dim bytes() As Byte = SerializeMessage(pkt)
                    sendBytes(bytes)
                End If

                Dim responseBytes = Read(0)
                If validateResponse(SAHARA_CMD.SAHARA_CMD_READY, responseBytes) Then
                    dumpDeviceInfo()
                    switchMode(SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING)
                    Return
                End If

                If IsLoaderExist Then
                    If validateResponse(SAHARA_CMD.SAHARA_CMD_READ_DATA, responseBytes) Then

                        Me.mode = SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING
                        If cpu64 Then
                            RichLogs("CPU 64bit Detected", Color.LimeGreen, True, True)
                            Dim rdq = DirectCast(RawDeserialize(responseBytes, 0, GetType(SAHARA_REQUESTS_READDATA_64)), SAHARA_REQUESTS_READDATA_64)
                            sendFlashLoader64(rdq)
                        Else

                            RichLogs("CPU 32bit Detected", Color.LimeGreen, True, True)
                            Dim rdq = DirectCast(RawDeserialize(responseBytes, 0, GetType(SAHARA_REQUESTS_READDATA)), SAHARA_REQUESTS_READDATA)
                            sendFlashLoader(rdq)
                        End If
                    End If
                Else
                    XtraMessageBox.Show("Silahkan masukan loader firehose programmernya terlebih dahulu!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            End If
        End Sub

        Private Sub dumpDeviceInfo()
            ReadData(SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_MSM_HW_ID_READ)
            ReadData(SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_SERIAL_NUM_READ)
            ReadData(SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_OEM_PK_HASH_READ)
        End Sub
        Private Sub ReadData(cmd As SAHARA_EXEC_CMD)

            Dim newPkt As SAHARA_REQUEST_EXE_CMD = New SAHARA_REQUEST_EXE_CMD()
            newPkt.header.command = SAHARA_CMD.SAHARA_CMD_EXECUTE_REQ
            newPkt.header.size = Marshal.SizeOf(GetType(SAHARA_REQUEST_EXE_CMD))
            newPkt.clientCmd = cmd
            Dim bytes() As Byte = SerializeMessage(newPkt)
            sendBytes(bytes)
            Dim response1 = Read(10)
            If validateResponse(SAHARA_CMD.SAHARA_CMD_EXECUTE_RESPONSE, response1) Then
                Dim responsePkt = DirectCast(RawDeserialize(response1, 0, GetType(SAHARA_RESPONSE_EXECCMD_RESPONSE)), SAHARA_RESPONSE_EXECCMD_RESPONSE)
                Dim size = responsePkt.size
                newPkt.header.command = SAHARA_CMD.SAHARA_CMD_EXECUTE_DATA
                Dim bytes2() As Byte = SerializeMessage(newPkt)
                sendBytes(bytes2)
            Else
                'error
            End If
            Dim response2 = Read(10)
            If cmd = SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_MSM_HW_ID_READ Then
                Array.Reverse(response2, 0, response2.Length)
                Dim hwid As String = BitConverter.ToString(response2).Replace("-", String.Empty)
                hwid = hwid.Substring(0, 16)
                _pblInfo.msm_id = hwid

                RichLogs(" MSM_HW_ID        : ", Color.White, True, False)
                RichLogs(hwid, Color.Yellow, True, True)

            End If
            If cmd = SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_OEM_PK_HASH_READ Then
                Dim sn As String = BitConverter.ToString(response2).Replace("-", String.Empty)
                _pblInfo.pk_hash = sn

                RichLogs(" OEM PK_HASH [0]  : ", Color.White, True, False)
                RichLogs(sn.Substring(0, 32), Color.Yellow, True, True)

                RichLogs(" OEM PK_HASH [1]  : ", Color.White, True, False)
                RichLogs(sn.Substring(sn.Length - 32, 32), Color.Yellow, True, True)

                If Main.IsAutoLoader Then
                    If _pblInfo.msm_id.Length < 16 Then
                        Dim Str As String
                        Do
                            Dim sb As New Text.StringBuilder()
                            Str = sb.Append("0").ToString()

                            _pblInfo.msm_id = _pblInfo.msm_id & Str

                            If _pblInfo.msm_id.Length = 16 Then
                                Exit Do
                            End If
                        Loop
                    End If

                    Console.WriteLine(_pblInfo.msm_id.ToLower() & "_" & _pblInfo.pk_hash.Substring(0, 16).ToLower())
                    Dim string_to_find As String = _pblInfo.msm_id & "_" & _pblInfo.pk_hash.Substring(0, 16)

                    loader = getautoloader(string_to_find.ToLower(), False)

                    If Not Encoding.UTF8.GetString(loader).Take(20).Contains("ELF") Then
                        RichLogs("Auto loader tidak tersedia!", Color.Red, True, False)
                        IsLoaderExist = False
                    Else
                        IsLoaderExist = True
                    End If

                Else
                    If Not QcFlash.SharedUI.TxtFlashLoader.Text = "" Then
                        loader = File.ReadAllBytes(QcFlash.SharedUI.TxtFlashLoader.Text)
                        If Not Encoding.UTF8.GetString(loader).Take(20).Contains("ELF") Then
                            RichLogs("Loader is Invalid Or Encrypted  ", Color.Red, True, False)
                            IsLoaderExist = False
                        Else
                            IsLoaderExist = True
                        End If
                    End If
                End If
            End If
            If cmd = SAHARA_EXEC_CMD.SAHARA_EXEC_CMD_SERIAL_NUM_READ Then
                Dim sn = BitConverter.ToString(response2).Replace("-", String.Empty)
                _pblInfo.serial = sn
                RichLogs(" SERIAL_NUMBER    : ", Color.White, True, False)
                RichLogs(sn, Color.Yellow, True, True)


            End If
        End Sub

        Private Function switchMode(mode As SAHARA_MODE) As Boolean
            Dim pkt As New SAHARA_SWITCH_PACKET()
            pkt.header.command = SAHARA_CMD.SAHARA_CMD_SWITCH_MODE
            pkt.header.size = Marshal.SizeOf(GetType(SAHARA_SWITCH_PACKET))
            pkt.mode = SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING
            Dim bytes() As Byte = SerializeMessage(pkt)
            sendBytes(bytes)
            Dim responseBytes = Read(0)
            If validateResponse(SAHARA_CMD.SAHARA_CMD_HELLO_REQ, responseBytes) Then
                Dim data2 = RawDeserialize(responseBytes, 0, GetType(SAHARA_REQUESTS_HELLO))
                Dim pkt2 = DirectCast(data2, SAHARA_REQUESTS_HELLO)
                If mode = SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING Then
                    SendHelloResponse(pkt2, SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING)
                End If
            End If
            Return False
        End Function
        Private Sub hangHack(mode As SAHARA_MODE)
            Dim pkt As New SAHARA_SWITCH_PACKET()
            pkt.header.command = SAHARA_CMD.SAHARA_CMD_SWITCH_MODE
            pkt.header.size = Marshal.SizeOf(GetType(SAHARA_SWITCH_PACKET))
            pkt.mode = SAHARA_MODE.SAHARA_MODE_IMAGE_PENDING
            Dim bytes() As Byte = SerializeMessage(pkt)
            RichLogs("Get Device Mode   : ", Color.Yellow, True, False)
            Write(bytes)

            Dim retry = 0
            Do
                Dim responseBytes = Read(0)

                If Encoding.UTF8.GetString(responseBytes).Contains("xml") Then
                    RichLogs("Device Allready  Programing Mode", Color.White, True, True)
                    Me.mode = SAHARA_MODE.SAHARA_MODE_IMAGE_TX_COMPLETE
                    sendingloaderStatus = True
                    Ports.Close()
                    Return

                End If
                retry += 1
                Thread.Sleep(500)
                If retry = 3 Then
                    RichLogs("Error After 3 times read response", Color.Red, True, True)
                    RichLogs("Please Reconect Device", Color.Red, True, True)


                    sendingloaderStatus = False
                    Ports.Close()
                    Return
                End If
            Loop


        End Sub


        Public Function Read(timeSpan As Integer) As Byte()
            Thread.Sleep(timeSpan)
            Dim numBytes As Integer = Ports.BytesToRead
            Dim buffer(numBytes - 1) As Byte
            Ports.Read(buffer, 0, numBytes)
            Return buffer
        End Function
        Public Sub Write(request() As Byte)
            Ports.Write(request, 0, request.Length)
        End Sub


        Private Sub openPort()
            RichLogs("Connect To Device : ", Color.LimeGreen, True, False)


            PortsOpen()


            RichLogs("Conected", Color.Yellow, True, True)

            connected = True

            Dim response = Read(50)

            RichLogs("Get Hand Shake    : ", Color.LimeGreen, True, False)
            If response.Length = 0 Then
                RichLogs("Failed ", Color.Red, True, True)
                hangHack(SAHARA_MODE.SAHARA_MODE_COMMAND)
                Return
            End If
            If response.Length = Marshal.SizeOf(GetType(SAHARA_REQUESTS_HELLO)) Then


                RichLogs("Received Response Hand Shake", Color.White, True, True)
                Dim data2 = RawDeserialize(response, 0, GetType(SAHARA_REQUESTS_HELLO))
                Dim pkt = DirectCast(data2, SAHARA_REQUESTS_HELLO)
                SendHelloResponse(pkt, SAHARA_MODE.SAHARA_MODE_COMMAND) 'switch to cmd mode


            End If
            Ports.Close()
        End Sub
    End Class
End Namespace
