Imports System
Imports System.IO
Public Class CRC32

    Public Shared HexString As String = Nothing
    Public Shared NumSectors As Integer = 0
    Public Shared Offsets_Sector1 As Integer = 0
    Public Shared Offsets_Sector2 As Integer = 0
    Public Shared Offsets_Userdata As Integer = 0
    Public Shared TotalSizeDisk As Integer = EMMCISP.uks / 512
    Public Shared First_usable_LBA As Integer = TotalSizeDisk + 33
    Public Shared Last_usable_LBA As Integer = TotalSizeDisk
    Public Shared CRC32_Sector1 As String = Nothing
    Public Shared CRC32_Sector2 As String = Nothing


    Public Shared Function GetHexInFile(ByVal filePath As String, ByVal offset As Integer, ByVal length As Integer) As String
        Dim HexString As String = Nothing
        Dim buffer As Byte() = New Byte(length - 1) {}

        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.ReadWrite)
            fs.Seek(offset, SeekOrigin.Begin)
            fs.Read(buffer, 0, buffer.Length)
            HexString = HexString.Concat(HexString, ByteArrayToHexString(buffer))
        End Using


        Dim Result As String = ReverseStrings(HexString)
        Return Convert.ToInt32(Result, 16)
    End Function

    Public Shared Sub ReplaceHexInFile(ByVal filePath As String, ByVal offset As Integer, ByVal hexValues As String)
        Dim bytesToWrite As Byte() = HexStringToBytes(hexValues)

        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.ReadWrite)
            fs.Seek(offset, SeekOrigin.Begin)
            fs.Write(bytesToWrite, 0, bytesToWrite.Length)
        End Using
    End Sub

    Public Shared Function HexStringToBytes(ByVal hexString As String) As Byte()
        hexString = hexString.Replace(" ", "").Replace("-", "")

        Dim bytes(hexString.Length \ 2 - 1) As Byte

        For i As Integer = 0 To bytes.Length - 1
            bytes(i) = Convert.ToByte(hexString.Substring(i * 2, 2), 16)
        Next

        Return bytes
    End Function

    Public Shared Function ByteArrayToHexString(ByVal bytes As Byte()) As String
        Dim hexArray As String() = Array.ConvertAll(bytes, Function(b) b.ToString("X2"))
        Return String.Join("", hexArray)
    End Function

    Public Shared Function CalculateCRC32(ByVal filePath As String, ByVal startOffset As Integer, ByVal endOffset As Integer) As String
        HexString = ""
        Convert.ToInt32(endOffset).ToString("X2")

        If File.Exists(Path.GetDirectoryName(filePath) & "/" & startOffset.ToString("X8") & "-" & endOffset.ToString("X8") & ".bin") Then
            File.Delete(Path.GetDirectoryName(filePath) & "/" & startOffset.ToString("X8") & "-" & endOffset.ToString("X8") & ".bin")
        End If

        Dim buffer As Byte() = New Byte(0) {}
        Dim totalBytesRead As Integer = 0
        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            fs.Seek(startOffset, SeekOrigin.Begin)

            Using fsout As New FileStream(Path.GetDirectoryName(filePath) & "/" & startOffset.ToString("X8") & "-" & endOffset.ToString("X8") & ".bin", FileMode.Create, FileAccess.Write)

                While totalBytesRead < (endOffset - startOffset + 1)
                    Dim bytesRead As Integer = fs.Read(buffer, 0, buffer.Length)
                    If bytesRead = 0 Then Exit While

                    fsout.Write(buffer, 0, bytesRead)
                    HexString = HexString.Concat(HexString, "&H", ByteArrayToHexString(buffer), ", ")
                    totalBytesRead += bytesRead
                End While

            End Using
        End Using

        HexString = HexString.TrimEnd(" ").TrimEnd(",")
        Dim hexElements As String() = HexString.Split(","c)
        Dim bytes(hexElements.Length - 1) As Byte

        For i As Integer = 0 To hexElements.Length - 1
            Dim hexValue As String = hexElements(i).Trim().Replace("&H", "")
            bytes(i) = Convert.ToByte(hexValue, 16)
        Next

        Dim data As Byte() = bytes
        Dim crc As UInt32 = CalculateCRC32Hex(data, 0, data.Length)
        Dim result As String = crc.ToString("X8") ' Hasil dalam bentuk hexadesimal
        Dim littleEndianResult As String = ReverseStrings(result) ' Hasil dalam bentuk little endian
        NumSectors += 1

        Console.WriteLine("Sector: " & NumSectors & " Start Offset: " & startOffset.ToString("X8") & " End Offset: " & endOffset.ToString("X8") & " CRC32: " & littleEndianResult)
        Return littleEndianResult
    End Function

    Public Shared Function CalculateCRC32Hex(ByVal data As Byte(), ByVal startOffset As Integer, ByVal length As Integer) As UInt32
        Dim crcTable As UInt32() = GenerateCRCTable()
        Dim crc As UInt32 = &HFFFFFFFFUI

        For i As Integer = startOffset To startOffset + length - 1
            Dim index As Byte = CByte((crc Xor data(i)) And &HFF)
            crc = (crc >> 8) Xor crcTable(index)
        Next

        Return Not crc
    End Function

    Public Shared Function GenerateCRCTable() As UInt32()
        Dim crcTable As UInt32() = New UInt32(255) {}

        For i As Integer = 0 To 255
            Dim crc As UInt32 = CUInt(i)
            For j As Integer = 0 To 7
                If (crc And 1) = 1 Then
                    crc = (crc >> 1) Xor &HEDB88320UI
                Else
                    crc >>= 1
                End If
            Next
            crcTable(i) = crc
        Next

        Return crcTable
    End Function

    Public Shared Function ReverseStrings(ByVal value As String) As String
        Dim reversed As String = ""
        For i As Integer = value.Length - 2 To 0 Step -2
            reversed += value.Substring(i, 2)
        Next
        Return reversed
    End Function

    Public Shared Function FindOffsetInFile(ByVal filePath As String, ByVal pattern As String) As Long
        Dim patternBytes As Byte() = HexStringToBytes(pattern)
        Dim bufferSize As Integer = File.ReadAllBytes(filePath).Length ' Ukuran buffer baca file
        Dim buffer(bufferSize - 1) As Byte
        Dim bytesRead As Integer
        Dim offset As Long = 0

        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            While bytesRead < bufferSize
                bytesRead = fs.Read(buffer, 0, bufferSize)
                For i As Integer = 0 To bytesRead - patternBytes.Length
                    If MatchesPattern(buffer, i, patternBytes) Then
                        Return offset + i
                    End If
                Next
                offset += bytesRead
            End While
        End Using

        Return -1 ' Jika tidak ditemukan pola dalam file
    End Function

    Public Shared Function MatchesPattern(ByVal buffer As Byte(), ByVal index As Integer, ByVal pattern As Byte()) As Boolean
        For i As Integer = 0 To pattern.Length - 1
            If buffer(index + i) <> pattern(i) Then
                Return False
            End If
        Next
        Return True
    End Function

End Class
