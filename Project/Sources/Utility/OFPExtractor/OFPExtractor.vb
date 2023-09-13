Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.Linq
Imports Microsoft.VisualBasic
Imports Reverse_Tool.Bismillah.FIREHOSE.FIREHOSE_MANAGER
Public Class OFPExtractor
    Public Shared startoffsetofp As Double = 0
    Public Shared cekvalidmd5 As String
    Public Shared cekvalidsha256 As String
    Public Shared totalchecked As Integer
    Public Shared fname As String = ""
    Public Shared pagesize As String = ""
    Public Shared namafileofp As String = ""
    Public Shared rlen As String = ""
    Public Shared StringXML As String = ""
    Public Shared loadofp As Boolean = False
    Public Shared flashofp As Boolean = False
    Public Shared lb As New ListBox()
    Public Shared lbofpMtk As New ListBox()
    Public Shared lbofpQcom As New ListBox()
    Public Shared OPFWorkerMTK As New BackgroundWorker()
    Public Shared OPFWorkerQC As New BackgroundWorker()
    Public Shared Function rol(ByVal he As String, ByVal n As String, Optional ByVal bits As String = "32") As String
        n = bits - n
        Dim a As Double = (2 ^ n) - 1
        Dim b As String = DecToBinary(he)
        Dim c As String = DecToBinary(a)
        Dim d As String = ApplyAnd(b, c)
        Dim e As String = DecToBinary(n)
        Dim s As Double = Bin2Dec(ApplyShiftDoblekanan(b, n))
        Dim x As Double = bits - n
        Dim y As String = ApplyShiftDoblekiri(d, x)
        Dim h As Double = Bin2Dec(y)
        Dim z As Double = h + s
        '   Dim tt = ToBinary(z)
        Return z
    End Function
    Public Shared Function ApplyAnd(ByVal input1 As String, ByVal input2 As String) As String
        Dim len As Integer
        If input1.Length > input2.Length Then
            Dim add As Integer = input1.Length - input2.Length
            For i As Integer = 0 To add - 1
                input2 = "0" & input2
            Next
        ElseIf input2.Length > input1.Length Then
            Dim add As Integer = input2.Length - input1.Length
            For i As Integer = 0 To add - 1
                input1 = "0" & input1
            Next
        End If
        len = input1.Length
        Dim s As Integer = 0
        Dim output As String = ""
        For i As Integer = 0 To len - 1
            If input1.Substring(s, 1) = 1 AndAlso input2.Substring(s, 1) = 1 Then
                output += "1"
            Else
                output += "0"
            End If
            s += 1
        Next
        Return output
    End Function
    Public Shared Function ApplyShiftDoblekiri(ByVal input As String, ByVal num As Integer) As String
        For i As Integer = 0 To num - 1
            input += "0"
        Next
        Return input
    End Function
    Public Shared Function Bin2Dec(ByVal ans As String) As Double
        Dim dig As String, p As Integer
        Dim dec, B, d As Double
        p = 0
        For x As Integer = ans.Length - 1 To 0 Step -1
            dig = ans.Substring(x, 1)
            If Not (dig = "0" Or dig = "1") Then
                dec = 0
                MessageBox.Show("Incorrect entry.  ")
                Exit For
            End If
            Double.TryParse(dig, B)
            d = B * (2 ^ p)
            dec += d
            p += 1
        Next x
        Return dec
    End Function
    Public Shared Function BytesToHextring(input() As Byte) As String
        Return BitConverter.ToString(input).Replace("-", "").ToLower
    End Function
    Public Shared Function DeObsucaate(ByVal input1 As String, ByVal input2 As String) As String
        Dim outpit As String = ""
        Dim s As String = 0
        Dim p = 0
        For i As Integer = 0 To (input1.Length / 2) - 1
            p += 1
            Dim a As String = input1.Substring(s, 2)
            Dim b As String = input2.Substring(s, 2)
            Dim x As String = (DecToBinary(HexToDec(a)))
            Dim y As String = (DecToBinary(HexToDec(b)))
            Dim c As String = ApplyXor(x, y)
            Dim e As Double = Bin2Dec(c)
            '    MsgBox(e)
            '  MsgBox(input2.Substring(s, 2))
            Dim ikeh As UInt64 = rol(e, 4, 8)
            Dim by() As Byte = BitConverter.GetBytes(ikeh)
            Dim sk As String = BytesToHextring(by).Substring(0, 2)
            outpit += sk
            s += 2
        Next
        Return outpit
    End Function
    Public Shared Function md5Hash(ByVal input As Byte()) As String
        Using hasher As MD5CryptoServiceProvider = MD5CryptoServiceProvider.Create() ' create hash object

            Dim dbytes As Byte() = hasher.ComputeHash(input)
            Dim sBuilder As New StringBuilder()
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n
            Return sBuilder.ToString
        End Using
    End Function
    Public Shared Sub BruteKeyQcom(sender As Object, e As DoWorkEventArgs)
        logs("Search Key : ", False, Biru)
        Dim superdone0 As Boolean = False
        Dim superdone1 As Boolean = False
        Dim superdone2 As Boolean = False
        Dim ada As Boolean = False
        Dim xmlstring As String = ""
        Dim keystring As String = ""
        Dim ivstring As String = ""
        Dim kuy() As Byte = New Byte() {}
        For i As Integer = 0 To lbofpQcom.Items.Count - 1
            Dim key() As Byte = New Byte() {}
            Dim iv() As Byte = New Byte() {}
            Dim liskey() As String = lbofpQcom.Items(i).ToString.Split(",")
            If liskey.Count = 2 Then
                keystring = liskey(0)
                ivstring = liskey(1)
                kuy = GetXml(keystring, ivstring)
            Else
                Dim stringMc As String = (liskey(1))
                Dim stringUserkey As String = (liskey(2))
                Dim Stringivec As String = (liskey(3))
                Dim DeciKey As String = DeObsucaate(stringUserkey, stringMc)
                Dim decivi As String = DeObsucaate(Stringivec, stringMc)
                keystring = md5Hash(HexStringToBytes(DeciKey)).ToLower.Substring(0, 16)
                ivstring = md5Hash(HexStringToBytes(decivi)).ToLower.Substring(0, 16)
                kuy = GetXml(keystring, ivstring)
            End If
            '   logs(keystring & " || " & ivstring, True, Kuning)
            If Encoding.UTF8.GetString(kuy).ToLower.Contains("xml") Then
                '   MsgBox("ada")
                xmlstring = Encoding.UTF8.GetString(kuy)
                logs("Key Founds", True, Kuning)
                logs("", True, Kuning)
                ada = True
                Exit For
            End If
        Next
        '  Return
        If Not ada Then
            logs("Key Not Founds", True, Merah)
            Return
        End If
        If flashofp = True Then
        Else
            If Not Directory.Exists("temp") Then
                Directory.CreateDirectory("temp")
            Else
                Directory.Delete("temp", True)
                Directory.CreateDirectory("temp")
            End If
        End If
        If File.Exists(foldersave & "\profile.xml") Then
            File.Delete(foldersave & "\profile.xml")
        End If
        logs("Saving Profile Xml : ", False, putih)
        Dim reader As New StringReader(xmlstring)
        Dim linestring As String
        Dim files As System.IO.StreamWriter
        files = My.Computer.FileSystem.OpenTextFileWriter(foldersave & "\profile.xml", True)
        logs("Done", True, Kuning)
        Do
            linestring = reader.ReadLine
            '   MsgBox(linestring)
            files.WriteLine(linestring)
            If linestring.ToLower.Contains("</profile>") Then
                files.Close()
                Exit Do
            End If
        Loop
        reader.Close()
        Dim wfilename As String = ""
        Dim len As String = ""
        Dim FilePartition As String = ""
        Dim decryptsize As String = ""
        Dim ceksums() As String = {}
        Dim sumsha256 As String = ""
        Dim summd5 As String = ""
        logs("Start Extracting : ", True, Kuning)
        Try
            Dim doc As XDocument = XDocument.Parse(File.ReadAllText(foldersave & "\profile.xml"))
            Dim root As XElement = doc.Root
            Dim u As Integer = 0
            Dim totalbaris As Integer = 0
            For Each child As XElement In root.Elements
                If OPFWorkerQC.CancellationPending Then
                    e.Cancel = True
                    logs("", True, Merah)

                    Exit Sub
                End If
                totalbaris += 1
            Next
            Dim yukyuk As Integer = 0
            For Each child As XElement In root.Elements
                yukyuk += 1
                ProcessBar1(yukyuk, totalbaris)
                If OPFWorkerQC.CancellationPending Then
                    e.Cancel = True
                    logs("", True, Merah)

                    Exit Sub
                End If
                For Each itm As XElement In child.Elements
                    If OPFWorkerQC.CancellationPending Then
                        e.Cancel = True
                        logs("", True, Merah)

                        Exit Sub
                    End If
                    If Not itm.Attribute("Path") Is Nothing Or Not itm.Attribute("Filename") Is Nothing Then
                        For Each att As XAttribute In itm.Attributes
                            Dim skuy() As String = decrypitem(itm, pagesize)
                            wfilename = foldersave & "\" & skuy(0)
                            Dim tempFiles As String = foldersave & "\" & skuy(0)
                            startoffsetofp = skuy(1)
                            len = skuy(2)
                            rlen = skuy(3)
                            sumsha256 = skuy(4)
                            summd5 = skuy(5)
                            decryptsize = skuy(6)
                            ceksums = {sumsha256, summd5}
                            Dim cekFiles As String = tempFiles.Replace(foldersave & "\", "")
                            If cekFiles = "" Or startoffsetofp = -1 Then
                                Continue For
                            End If
                            '   decryptFile(sender, e, keystring, ivstring, wfilename, startoffsetofp, len, rlen, ceksums, decryptsize)
                            '  logs("decrypt Untaged : " & wfilename, True, Kuning)
                        Next
                    End If
                    Dim ku() As String = decrypitem(itm, pagesize)
                    wfilename = foldersave & "\" & ku(0)
                    FilePartition = ku(0)
                    Dim tempFile As String = foldersave & "\" & ku(0)
                    startoffsetofp = ku(1)
                    len = ku(2)
                    rlen = ku(3)
                    sumsha256 = ku(4)
                    summd5 = ku(5)
                    decryptsize = ku(6)
                    ceksums = {sumsha256, summd5}
                    Dim cekFile As String = tempFile.Replace(foldersave & "\", "")
                    If cekFile = "" Or startoffsetofp = -1 Then
                        Continue For
                    End If
                    If child.Name.ToString = "Sahara" Then
                        decryptsize = rlen
                    End If
                    If child.Name.ToString = "Config" Or child.Name = "Provision" Or child.Name = "ChainedTableOfDigests" Or child.Name = "DigestsToSign" Or child.Name = "Firmware" Then
                        len = rlen
                    End If
                    If flashofp = True Then
                        Dim totaldo As Integer = 0
                        totaldo = totalchecked
                        Dim doprosess As Integer = 0
                        Dim XmlReader As New XmlTextReader(New StringReader(StringXML))
                        Do While XmlReader.Read()
                            If OPFWorkerQC.CancellationPending = True Then
                                'bg worker flash cancel
                                e.Cancel = True
                                logs("Process Stopped By User", True, Merah)
                                Return
                            Else
                                If XmlReader.NodeType = XmlNodeType.Element AndAlso XmlReader.Name = "program" Then
                                    Dim SectorSize As String = XmlReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                                    Dim numPartSect As String = XmlReader.GetAttribute("num_partition_sectors")
                                    Dim filename As String = XmlReader.GetAttribute("filename")
                                    Dim PhysicalPartition As String = XmlReader.GetAttribute("physical_partition_number")
                                    Dim label As String = XmlReader.GetAttribute("label")
                                    Dim StartSector As String = XmlReader.GetAttribute("start_sector")
                                    If (FilePartition).ToLower.Contains("super.0") Then
                                        If superdone0 Then
                                            Continue For
                                        End If
                                        logs("Writing " & FilePartition, False, Merah)
                                        logs("Done ", True, putih)
                                        superdone0 = True
                                    ElseIf (FilePartition).ToLower.Contains("super.1") Then
                                        If superdone1 Then
                                            Continue For
                                        End If
                                        logs("Writing " & FilePartition, False, Merah)
                                        logs("Done ", True, putih)
                                        superdone1 = True
                                    ElseIf (FilePartition).ToLower.Contains("super.2") Then
                                        If superdone2 Then
                                            Continue For
                                        End If
                                        logs("Writing " & FilePartition, False, Merah)
                                        logs("Done ", True, putih)
                                        superdone2 = True
                                    ElseIf (wfilename) = filename Then
                                        logs("Writing " & label, False, Merah)
                                        logs("Done ", True, putih)
                                        Continue For
                                    End If
                                End If
                            End If
                            Continue For
                        Loop
                    Else
                        If loadofp = True Then
                            If wfilename.ToLower.Contains("rawprogram") Then
                                decryptFile(sender, e, keystring, ivstring, wfilename, startoffsetofp, len, rlen, ceksums, decryptsize)
                            End If
                            If wfilename.ToLower.Contains("patch") Then
                                decryptFile(sender, e, keystring, ivstring, wfilename, startoffsetofp, len, rlen, ceksums, decryptsize)
                            End If
                        Else
                            If child.Name.ToString = "DigestsToSign" Or child.Name = "ChainedTableOfDigests" Or child.Name = "Firmware" Then
                                logs("copy " & wfilename, True, Kuning)
                                CopyOfp(wfilename, startoffsetofp, len, ceksums)
                                Dim cek As String() = CheckSumsFile(wfilename, ceksums)
                                logs("[SHA256 : " & cek(0) & " | md5 : " & cek(1) & "]", True, putih)
                                logs("", True, putih)
                            Else
                                logs("decrypt " & wfilename & " " & startoffsetofp & " " & len & " " & rlen & " " & decryptsize, True, Kuning)
                                decryptFile(sender, e, keystring, ivstring, wfilename, startoffsetofp, len, rlen, ceksums, decryptsize)
                                Dim cek As String() = CheckSumsFile(wfilename, ceksums)
                                logs("[SHA256 : " & cek(0) & " | md5 : " & cek(1) & "]", True, putih)
                                logs("", True, putih)
                                '   Exit Function
                                '   u += 1
                                '  If u = 2 Then
                                '  Exit Function
                                'End If
                            End If
                        End If
                    End If
                Next
            Next
            '  yukyuk += 1
            ProcessBar1(totalbaris, totalbaris)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Shared Function CheckSumsFile(filename As String, HashListCek() As String) As String()
        Dim retSha256 As String
        If Not HashListCek(0) = "" Then
            retSha256 = sha256cek(filename, HashListCek(0))
        Else
            retSha256 = "empty"
        End If

        Dim retMd5 As String
        If Not HashListCek(1) = "" Then
            retMd5 = md5cek(filename, HashListCek(1))
        Else
            retMd5 = "empty"
        End If
        Return {retSha256, retMd5}
    End Function
    Public Shared Function sha256cek(wfilename As String, hascek As String) As String
        Dim lencek As Long = New FileInfo(wfilename).Length
        If Not lencek < &H40000 Then
            lencek = &H40000
        End If
        Dim s As FileStream = File.OpenRead(wfilename)
        Dim buf As Byte() = New Byte(lencek - 1) {}
        s.Read(buf, 0, buf.Length)
        Dim SHA256Obj As New SHA256Managed
        Dim hash = SHA256Obj.ComputeHash(buf)
        s.Close()
        Dim k As String = ""
        ConvertByteArrayToHexString(hash, hash.Length, k)
        If hascek = k.ToLower Then
            Return "verified"
        Else
            Return "bad"
        End If
    End Function
    Public Shared Function bulat(number As Double) As Long
        bulat = -Int(-number)
    End Function
    Public Shared Sub ConvertByteArrayToHexString(ByteArrayIn As Byte(), StrLength As Integer, <System.Runtime.InteropServices.OutAttribute()> ByRef StringOut As String)
        Dim array As String() = New String(StrLength - 1) {}
        Dim array2 As String() = New String(1) {}
        StringOut = ""
        For i As Integer = 0 To StrLength - 1
            Dim flag As Boolean = ByteArrayIn IsNot Nothing AndAlso ByteArrayIn.Length > i
            If flag Then
                Dim b As Byte = Convert.ToByte(ByteArrayIn(i))
                Dim value As Byte = Convert.ToByte(CInt((b And 15)))
                Dim value2 As Byte = Convert.ToByte((b And 240) >> 4)
                array2(0) = Convert.ToString(value, 16)
                array2(1) = Convert.ToString(value2, 16)
                StringOut = StringOut + array2(1).ToUpper() + array2(0).ToUpper()
            End If
        Next
    End Sub
    Public Shared Function md5cek(wfilename As String, SourceCek As String) As String
        Dim lencek As Long = New FileInfo(wfilename).Length
        If Not lencek < &H40000 Then
            lencek = &H40000
        End If
        Dim s As FileStream = File.OpenRead(wfilename)
        Dim buf As Byte() = New Byte(lencek - 1) {}
        s.Read(buf, 0, buf.Length)
        Dim k As String = md5Hash(buf).ToLower
        s.Close()
        If SourceCek = k Then
            Return "verified"
        Else
            Return "bad"
        End If
    End Function
    Public Shared Sub CopyOfp(wfilename As String, startoffsetofp As Double, len As String, ceksums() As String)
        Dim size As Integer = 0
        Dim bytesread As Integer = 0
        If len < 1048576 Then
            size = len
        Else
            size = 1048576
        End If
        Try

            Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(size), Action))

            Using fsin As New FileStream(fname, FileMode.Open)
                Using fsout As New FileStream(wfilename, FileMode.Create)
                    fsin.Seek(startoffsetofp, SeekOrigin.Begin)
                    'Membuat objek Stopwatch untuk mengukur waktu
                    Dim stopwatch As New Stopwatch()
                    stopwatch.Start()

                    Do
                        Dim buffer As Byte() = New Byte(size - 1) {}
                        fsin.Read(buffer, 0, buffer.Length)
                        bytesread += buffer.Length

                        Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(bytesread), Action))

                        ' Menghitung Waktu yang telah berlalu
                        Dim elapsed As TimeSpan = stopwatch.Elapsed
                        Dim speed As Double = bytesread / elapsed.TotalSeconds
                        Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))

                        If bytesread > size Then
                            Dim num2 As Integer = bytesread - size
                            Dim zz As Integer = buffer.Length - num2
                            Dim data2 As Byte() = buffer.Take(zz).ToArray
                            fsout.Write(data2, 0, data2.Length)
                            Exit Do
                        End If
                        fsout.Write(buffer, 0, buffer.Length)
                    Loop
                    ' Berhenti menghitung
                    stopwatch.Stop()
                    Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = "0.00 Bytes / s", Action))
                    Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = "0.00 Bytes           ", Action))
                    Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = "0.00 Bytes           ", Action))
                    fsin.Close()
                    fsout.Close()
                End Using
            End Using
            '   rlen += len(Data)
            '  length -= size
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Shared Function decrypitem(item As XElement, pagesize As String) As String()
        Dim sha256sum As String = ""
        Dim md5sum As String = ""
        Dim wfilename As String = ""
        Dim start As Long = -1
        Dim rlength As Long = 0
        Dim decryptsize = &H40000

        If item.Attribute("Path") IsNot Nothing Then
            wfilename = item.Attribute("Path")
        ElseIf item.Attribute("filename") IsNot Nothing Then
            wfilename = item.Attribute("filename")
        End If
        If item.Attribute("sha256") IsNot Nothing Then
            sha256sum = item.Attribute("sha256")
        End If
        If item.Attribute("md5") IsNot Nothing Then
            md5sum = item.Attribute("md5")
        End If
        If item.Attribute("FileOffsetInSrc") IsNot Nothing Then
            start = item.Attribute("FileOffsetInSrc").Value * pagesize
        ElseIf item.Attribute("SizeInSectorInSrc") IsNot Nothing Then
            start = item.Attribute("SizeInSectorInSrc").Value * pagesize
        End If
        If item.Attribute("SizeInByteInSrc") IsNot Nothing Then
            rlength = item.Attribute("SizeInByteInSrc").Value
        End If
        Dim len As Long
        If item.Attribute("SizeInSectorInSrc") IsNot Nothing Then
            len = item.Attribute("SizeInSectorInSrc").Value * pagesize
        Else
            len = rlength
        End If

        '  If "Path" Then In item.attrib
        '    wfilename = item.attrib["Path"]
        'elif "filename" in item.attrib
        '     wfilename = item.attrib["filename"]


        Return {wfilename, start, len, rlength, sha256sum, md5sum, decryptsize}
    End Function
    Public Shared Sub decryptFile(sender As Object, e As DoWorkEventArgs, ByVal key As String, ByVal iv As String, ByVal wfilename As String, ByVal start As String, ByVal lengthSource As String, ByVal lengthFile As String, ByVal Checksum() As String, Optional ByVal decryptedsize As Double = &H40000)
        Dim LenFileOut As Long = lengthFile
        Dim blocksize As Double = decryptedsize
        If lengthSource < decryptedsize Then
            blocksize = lengthSource
        End If
        If Not blocksize Mod 16 = 0 Then
            blocksize = lengthSource
        End If
        If Not blocksize Mod 16 = 0 Then
            Dim jkl As Double = (blocksize Mod 16)
            Dim kurangnya As Double = 16 - jkl
            blocksize += kurangnya
        End If
        Dim byt As Byte() = Encoding.UTF8.GetBytes(key) '   
        Dim byts As Byte() = Encoding.UTF8.GetBytes(iv)
        Dim BytesRead As Long = 0
        Dim setseek As Long = 0
        Try

            Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = GetFileSize(lengthSource), Action))

            'Membuat objek Stopwatch untuk mengukur waktu
            Dim stopwatch As New Stopwatch()
            stopwatch.Start()

            Using fsin As New FileStream(fname, FileMode.Open)
                Using fsout As New FileStream(wfilename, FileMode.Create)
                    fsin.Seek(start, SeekOrigin.Begin)
                    If LenFileOut < blocksize Then
                        blocksize = LenFileOut
                    End If
                    Dim Rawbyte() As Byte = New Byte(blocksize - 1) {}
                    If Not blocksize Mod 16 = 0 Then
                        Dim finlen As Double = blocksize + (16 - (blocksize Mod 16))
                        Rawbyte = New Byte(finlen - 1) {}
                    End If
                    fsin.Read(Rawbyte, 0, Rawbyte.Length)

                    ' Limit Max Long Data Type Value
                    ' 2147483647

                    Dim data As Byte()
                    If LenFileOut < 2147483647 Then
                        data = DecryptorAes(Rawbyte, byt, byts).Take(LenFileOut).ToArray
                    Else
                        data = DecryptorAes(Rawbyte, byt, byts).Take(Rawbyte.Length).ToArray
                    End If
                    fsout.Write(data, 0, data.Length)
                    BytesRead += data.Length
                    If data.Length > lengthSource Then
                        ProcessBar2(lengthSource, lengthSource)
                    Else

                        Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(data.Length), Action))

                        ' Menghitung Waktu yang telah berlalu
                        Dim elapsed As TimeSpan = stopwatch.Elapsed
                        Dim speed As Double = data.Length / elapsed.TotalSeconds
                        Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))

                        ProcessBar2(data.Length, lengthSource)
                    End If
                    LenFileOut -= data.Length
                    If LenFileOut > 0 Then
                        fsin.Seek(start + data.Length, SeekOrigin.Begin)
                        While LenFileOut > 0
                            If OPFWorkerQC.CancellationPending Then
                                e.Cancel = True
                                logs("", True, Merah)

                                Exit Sub
                            End If
                            Dim Sizebuf As Integer = &H200000
                            If LenFileOut < Sizebuf Then
                                Sizebuf = LenFileOut
                            End If
                            Dim buff As Byte() = New Byte(Sizebuf - 1) {}
                            fsin.Read(buff, 0, buff.Length)
                            LenFileOut -= Sizebuf
                            fsout.Write(buff, 0, buff.Length)
                            BytesRead += buff.Length

                            Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = GetFileSize(BytesRead), Action))

                            ' Menghitung Waktu yang telah berlalu
                            Dim elapsed As TimeSpan = stopwatch.Elapsed
                            Dim speed As Double = BytesRead / elapsed.TotalSeconds
                            Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = GetFileSize(speed) & " /s", Action))

                            If BytesRead < lengthSource Then
                                ProcessBar2(BytesRead, lengthSource)
                            Else
                                ProcessBar2(lengthSource, lengthSource)
                            End If
                        End While
                    End If
                    fsin.Close()
                    fsout.Close()
                End Using

                ' Berhenti menghitung
                stopwatch.Stop()
                Main.SharedUI.label_transferrate.Invoke(CType(Sub() Main.SharedUI.label_transferrate.Text = "0.00 Bytes / s", Action))

                Main.SharedUI.label_totalsize.Invoke(CType(Sub() Main.SharedUI.label_totalsize.Text = "0.00 Bytes           ", Action))
                Main.SharedUI.label_writensize.Invoke(CType(Sub() Main.SharedUI.label_writensize.Text = "0.00 Bytes           ", Action))

            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Shared Function GetXml(ByVal keystring As String, ByVal ivstring As String) As Byte()
        Try
            Dim fi As New FileInfo(fname)
            Dim LenFile As String = fi.Length
            pagesize = 0
            Using stream As New FileStream(fname, FileMode.Open, FileAccess.Read)
                Dim buff = New Byte() {}
                For i As Integer = 0 To 1
                    If i = 0 Then
                        stream.Seek(LenFile + 16 - 512, SeekOrigin.Begin)
                        buff = New Byte(4 - 1) {}
                        stream.Read(buff, 0, buff.Length)
                        If BytesToHextring(buff).ToLower.Contains("ef7c") Then
                            pagesize = 512
                            Exit For
                        End If
                    Else
                        stream.Seek(LenFile + 16 - 4096, SeekOrigin.Begin)
                        buff = New Byte(4 - 1) {}
                        stream.Read(buff, 0, buff.Length)
                        If BytesToHextring(buff).ToLower.Contains("ef7c") Then
                            pagesize = 4096
                            Exit For
                        End If
                    End If
                Next
                If pagesize = 0 Then
                    Return {}
                End If
                Dim xmloffset As Long = LenFile - pagesize
                stream.Seek(xmloffset + 20, SeekOrigin.Begin)
                buff = New Byte(4 - 1) {}
                stream.Read(buff, 0, buff.Length)
                Dim offset As String = HexToDec((Unpack((BytesToHextring(buff))))) * pagesize
                buff = New Byte(4 - 1) {}
                stream.Read(buff, 0, buff.Length)
                Dim lengthsize As String = HexToDec((Unpack((BytesToHextring(buff)))))
                Dim sk As String = ((lengthsize / 16))
                Dim l As Long = bulat(sk) * 16
                buff = New Byte(l - 1) {}
                stream.Seek(offset, SeekOrigin.Begin)
                stream.Read(buff, 0, buff.Length)
                stream.Close()
                Dim ku As Byte() = DecryptXml(buff, keystring, ivstring).Take(lengthsize).ToArray
                Return ku
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return {}
        End Try
    End Function
    Public Shared Function DectoHex(input() As Integer) As String
        Dim s As String = ""
        For i As Integer = 0 To input.Length - 1
            s += Hex(input(i))
        Next
        Return s
    End Function
    Public Shared Function DecryptorAes(ByVal cipherText As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
        Dim Algo As RijndaelManaged = RijndaelManaged.Create()
        With Algo
            .BlockSize = 128
            .FeedbackSize = 128
            .KeySize = 128
            .Mode = CipherMode.CFB
            .IV = IV
            .Key = Key
            .Padding = PaddingMode.None
        End With
        Dim lenFile As Long = 0
        Dim buffout() As Byte = New Byte((cipherText.Length - 1)) {}
        Dim s As New MemoryStream(buffout)
        Using Decryptor As ICryptoTransform = Algo.CreateDecryptor()
            Using StreamInput As New MemoryStream(cipherText)
                Using crypto_stream As New CryptoStream(s, Decryptor, CryptoStreamMode.Write)
                    Const block_size As Integer = 128
                    Dim buffer(block_size) As Byte
                    Dim bytes_read As Integer
                    Do
                        bytes_read = StreamInput.Read(buffer, 0, block_size)
                        crypto_stream.Write(buffer, 0, bytes_read)
                        If (bytes_read = 0) Then Exit Do
                    Loop
                End Using
            End Using


            ' Using MemStream As New MemoryStream(cipherText)
            'Using CryptStream As New CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read)
            'Using Reader As New StreamReader(CryptStream)

            'Return Reader.ReadToEnd
            'End Using
            'End Using
            'End Using
        End Using
        '   File.WriteAllBytes("gg", buffout)
        Return buffout
    End Function
    Public Shared Function Unpack(ByVal hexstring As String) As String
        Dim s As Integer = 0
        Dim lenbyte As Double = hexstring.Length / 2
        Dim lists As New List(Of String)()
        Dim ret As String = ""
        For i As Integer = 0 To lenbyte - 1
            Dim kl As String = hexstring.Substring(s, 2)
            lists.Add(kl)
            s += 2
        Next
        ' lists.Reverse()
        Dim l As Integer = 0
        For Isd As Integer = 0 To lists.Count - 1
            ret += lists((lists.Count - 1) - l)
            l += 1
        Next
        Return ret
    End Function
    Public Shared Function DecryptXml(ByVal data() As Byte, key As String, iv As String) As Byte()
        Dim byt As Byte() = Encoding.UTF8.GetBytes(key) '   
        Dim byts As Byte() = Encoding.UTF8.GetBytes(iv)
        Dim ctx = DecryptorAes(data, byt, byts)
        Return ctx
        '   MsgBox(Encoding.UTF8.GetString(ctx))
    End Function
    Public Shared Function HexStringToBytes(ByVal s As String) As Byte()
        s = s.Replace(" "c, "")
        Dim nBytes As Integer = s.Length \ 2
        Dim a(nBytes - 1) As Byte
        For i As Integer = 0 To nBytes - 1
            a(i) = Convert.ToByte(s.Substring(i * 2, 2), 16)
        Next
        Return a
    End Function
    Public Shared Function ApplyShiftDoblekanan(ByVal input As String, ByVal num As Integer) As String
        Try
            Dim panjang As Integer = input.Length - num
            Return input.Substring(0, panjang)
        Catch ex As Exception
            Return 0
        End Try  ' MsgBox(input.Length)


    End Function
    Public Shared Function DecToBinary(dec As Integer) As String
        Dim bin As Integer
        Dim output As String = Nothing
        While dec <> 0
            If dec Mod 2 = 0 Then
                bin = 0
            Else
                bin = 1
            End If
            dec \= 2
            output = Convert.ToString(bin) & output
        End While
        If output Is Nothing Then
            Return "0"
        Else
            Return output
        End If
    End Function
    Public Shared Function ApplyXor(ByVal input1 As String, ByVal input2 As String) As String
        Dim len As Integer
        If input1.Length > input2.Length Then
            Dim add As Integer = input1.Length - input2.Length
            For i As Integer = 0 To add - 1
                input2 = "0" & input2
            Next
        ElseIf input2.Length > input1.Length Then
            Dim add As Integer = input2.Length - input1.Length
            For i As Integer = 0 To add - 1
                input1 = "0" & input1
            Next
        End If
        len = input1.Length
        Dim s As Integer = 0
        Dim output As String = ""
        For i As Integer = 0 To len - 1
            If input1.Substring(s, 1) = 0 AndAlso input2.Substring(s, 1) = 0 Then
                output += "0"
            ElseIf input1.Substring(s, 1) = 1 AndAlso input2.Substring(s, 1) = 0 Then
                output += "1"
            ElseIf input1.Substring(s, 1) = 0 AndAlso input2.Substring(s, 1) = 1 Then
                output += "1"
            ElseIf input1.Substring(s, 1) = 1 AndAlso input2.Substring(s, 1) = 1 Then
                output += "0"
            End If
            s += 1
        Next
        Return output
    End Function
    Public Shared Function HexToDec(ByVal hexstring As String) As String
        Return CLng("&H" & hexstring)
    End Function
    Public Shared Sub LoadTabelKeyOFP()
        lbofpMtk.Items.Clear()
        lbofpQcom.Items.Clear()
        lbofpMtk.Items.Add("67657963787565E837D226B69A495D21,F6C50203515A2CE7D8C3E1F938B7E94C,42F2D5399137E2B2813CD8ECDF2F4D72")
        lbofpMtk.Items.Add(("9E4F32639D21357D37D226B69A495D21,A3D8D358E42F5A9E931DD3917D9A3218,386935399137416B67416BECF22F519A"))
        lbofpMtk.Items.Add(("892D57E92A4D8A975E3C216B7C9DE189,D26DF2D9913785B145D18C7219B89F26,516989E4A1BFC78B365C6BC57D944391"))
        lbofpMtk.Items.Add(("27827963787265EF89D126B69A495A21,82C50203285A2CE7D8C3E198383CE94C,422DD5399181E223813CD8ECDF2E4D72"))
        lbofpMtk.Items.Add(("3C4A618D9BF2E4279DC758CD535147C3,87B13D29709AC1BF2382276C4E8DF232,59B7A8E967265E9BCABE2469FE4A915E"))
        lbofpMtk.Items.Add(("1C3288822BF824259DC852C1733127D3,E7918D22799181CF2312176C9E2DF298,3247F889A7B6DECBCA3E28693E4AAAFE"))
        lbofpMtk.Items.Add(("1E4F32239D65A57D37D2266D9A775D43,A332D3C3E42F5A3E931DD991729A321D,3F2A35399A373377674155ECF28FD19A"))
        lbofpMtk.Items.Add(("122D57E92A518AFF5E3C786B7C34E189,DD6DF2D9543785674522717219989FB0,12698965A132C76136CC88C5DD94EE91"))
        lbofpMtk.Items.Add(("ab3f76d7989207f2,2bf515b3a9737835"))


        'qcom
        lbofpQcom.Items.Add("d154afeeaafa958f,2c040f5786829207")
        lbofpQcom.Items.Add("2e96d7f462591a0f,17cc63224c208708")
        lbofpQcom.Items.Add("4a837229e6fc77d4,00bed47b80eec9d7")
        lbofpQcom.Items.Add("3398699acebda0da,b39a46f5cc4f0d45")
        lbofpQcom.Items.Add("94d62e831cf1a1a0,7ab5e33bd50d81ca")
        lbofpQcom.Items.Add("b4b7358eea220991,e9077e26ab102d1b")
        lbofpQcom.Items.Add("V1.4.17/1.4.27,27827963787265EF89D126B69A495A21,82C50203285A2CE7D8C3E198383CE94C,422DD5399181E223813CD8ECDF2E4D72")
        lbofpQcom.Items.Add("V1.6.17,E11AA7BB558A436A8375FD15DDD4651F,77DDF6A0696841F6B74782C097835169,A739742384A44E8BA45207AD5C3700EA")
        lbofpQcom.Items.Add("V1.6.6/1.6.9/1.6.17/1.6.24/1.6.26/1.7.6,3C2D518D9BF2E4279DC758CD535147C3,87C74A29709AC1BF2382276C4E8DF232,598D92E967265E9BCABE2469FE4A915E")
        lbofpQcom.Items.Add("V1.7.2,8FB8FB261930260BE945B841AEFA9FD4,E529E82B28F5A2F8831D860AE39E425D,8A09DA60ED36F125D64709973372C1CF")
        lbofpQcom.Items.Add("V1.5.13,67657963787565E837D226B69A495D21,F6C50203515A2CE7D8C3E1F938B7E94C,42F2D5399137E2B2813CD8ECDF2F4D72")
        lbofpQcom.Items.Add("V2.0.3,E8AE288C0192C54BF10C5707E9C4705B,D64FC385DCD52A3C9B5FBA8650F92EDA,79051FD8D8B6297E2E4559E997F63B7F")
    End Sub
    Public Shared Sub BruteKeyMtk(sender As Object, e As DoWorkEventArgs)
        Dim found As Boolean = False
        Dim byt As Byte() = New Byte() {}
        Dim byts As Byte() = New Byte() {}
        Dim aesiv As String
        Dim AesKey As String
        logs("Searching Key : ", False, Kuning)
        For i As Integer = 0 To lbofpMtk.Items.Count - 1
            Dim sk() As String = lbofpMtk.Items(i).ToString.Split(",")
            If sk.Length = 2 Then
                Dim ku As String() = GetKey(sk)
                AesKey = ku(0)
                aesiv = ku(1)
                byt = HexStringToBytes(AesKey)
                byts = HexStringToBytes(aesiv)
            Else
                Dim ku As String() = GetKey(sk)
                Dim a As Byte() = HexStringToBytes((ku(0)))
                Dim b As Byte() = HexStringToBytes((ku(1)))
                AesKey = md5Hash(a).ToLower.Substring(0, 16)
                aesiv = md5Hash(b).ToLower.Substring(0, 16)
                byt = Encoding.UTF8.GetBytes(AesKey) '   
                byts = Encoding.UTF8.GetBytes(aesiv)
                If BruteKey(byt, byts) Then
                    logs("Key founds ", True, Kuning)
                    found = True
                    Exit For
                End If
            End If
        Next
        If Not found Then
            logs("Key Not Founds ", True, Kuning)
            Return
        End If
        Try
            Dim fi As New FileInfo(fname)
            Dim LenFile As String = fi.Length
            Dim hdrLen As Integer = 108
            Dim headerkey As Byte() = Encoding.UTF8.GetBytes("geyixue")
            Using stream As New FileStream(fname, FileMode.Open, FileAccess.Read)
                stream.Seek(LenFile - hdrLen, SeekOrigin.Begin)
                Dim InputBuff = New Byte(108 - 1) {}
                stream.Read(InputBuff, 0, InputBuff.Length)
                Dim HeaderKeyHexString As String = BytesToHextring(headerkey).Replace("-", "")
                Dim inputHextring As String = BytesToHextring(InputBuff).Replace("-", "")
                Dim s As String = Mtk_Shuffle(HeaderKeyHexString, inputHextring)
                Dim ArrayData As Byte() = HexStringToBytes((s))
                Dim prjname As String = Encoding.UTF8.GetString(ArrayData.Take(46).ToArray).Trim(ControlChars.NullChar)
                Dim unknownval As UInteger = BitConverter.ToUInt32(ArrayData.Skip(46).Take(8).ToArray, 0)
                Dim reserved As String = Encoding.UTF8.GetString(ArrayData.Skip(54).Take(4).ToArray).Trim(ControlChars.NullChar)
                Dim cputype As String = Encoding.UTF8.GetString(ArrayData.Skip(58).Take(8).ToArray).Trim(ControlChars.NullChar)
                Dim Flashtype As String = Encoding.UTF8.GetString(ArrayData.Skip(66).Take(8).ToArray).Trim(ControlChars.NullChar)
                Dim HeaderEntries As Short = BitConverter.ToInt16(ArrayData.Skip(72).Take(2).ToArray, 0)
                Dim pjrinfo As String = Encoding.UTF8.GetString(ArrayData.Skip(74).Take(32).ToArray).Trim(ControlChars.NullChar)
                Dim crc As Short = BitConverter.ToInt16(ArrayData.Skip(74 + 32).Take(2).ToArray, 0)
                Dim hdr2length As Integer = HeaderEntries * &H60
                stream.Seek((LenFile - hdr2length - hdrLen), SeekOrigin.Begin)
                InputBuff = New Byte(hdr2length - 1) {}
                stream.Read(InputBuff, 0, InputBuff.Length)
                inputHextring = BytesToHextring(InputBuff).Replace("-", "")
                Dim hdr2 As String = Mtk_Shuffle(HeaderKeyHexString, inputHextring)
                ArrayData = HexStringToBytes((hdr2))
                Dim addskip As Integer = 0
                Dim totalfile As Integer = Int(ArrayData.Length) / &H60
                For i As Integer = 0 To (Int(ArrayData.Length) / &H60) - 1
                    If OPFWorkerMTK.CancellationPending Then
                        e.Cancel = True
                        logs("", True, Merah)

                        Exit Sub
                    End If
                    ProcessBar1(i, totalfile)
                    Dim pname As String = Encoding.UTF8.GetString(ArrayData.Skip(addskip).Take(32).ToArray).Trim(ControlChars.NullChar)
                    Dim start As UInteger = BitConverter.ToUInt32(ArrayData.Skip(32 + addskip).Take(8).ToArray, 0)
                    Dim length As UInteger = BitConverter.ToUInt32(ArrayData.Skip(40 + addskip).Take(8).ToArray, 0)
                    Dim encylenk As UInteger = BitConverter.ToUInt32(ArrayData.Skip(48 + addskip).Take(8).ToArray, 0)
                    Dim filename As String = Encoding.UTF8.GetString(ArrayData.Skip(56 + addskip).Take(32).ToArray).Trim(ControlChars.NullChar)
                    Dim crcf As UInteger = BitConverter.ToUInt32(ArrayData.Skip(88 + addskip).Take(8).ToArray, 0)
                    Dim totallen As Long = length
                    Dim byteprocess As Long = 0
                    Using FsOut As New FileStream(foldersave & "\" & filename, FileMode.Create)
                        If encylenk > 0 Then
                            stream.Seek(start, SeekOrigin.Begin)
                            Dim buff As Byte() = New Byte(encylenk - 1) {}
                            If Not buff.Length Mod 16 = 0 Then
                                Dim finlen As Double = encylenk + (16 - (encylenk Mod 16))
                                buff = New Byte(finlen - 1) {}
                            End If
                            stream.Read(buff, 0, buff.Length)
                            Dim data As Byte() = DecryptorAes(buff, byt, byts).Take(encylenk).ToArray
                            FsOut.Write(data, 0, data.Length)
                            logs("Extracting " & filename & ": ", False, Biru)
                            '   Write(123, 567)

                        End If
                        byteprocess = encylenk
                        ProcessBar2(byteprocess, totallen)
                        length -= encylenk
                        If length > 0 Then
                            stream.Seek(start + encylenk, SeekOrigin.Begin)
                            While length > 0
                                If OPFWorkerMTK.CancellationPending Then
                                    e.Cancel = True
                                    logs("", True, Merah)

                                    Exit Sub
                                End If
                                Dim Sizebuf As Integer = &H200000
                                If length < Sizebuf Then
                                    Sizebuf = length
                                End If
                                Dim buff As Byte() = New Byte(Sizebuf - 1) {}
                                stream.Read(buff, 0, buff.Length)
                                length -= Sizebuf
                                FsOut.Write(buff, 0, buff.Length)
                                byteprocess += buff.Length
                                ProcessBar2(byteprocess, totallen)
                            End While
                        End If
                    End Using
                    logs("Oks ", True, Kuning)
                    addskip += &H60
                Next
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Shared Function Mtk_Shuffle(ByVal key As String, ByVal input As String) As String
        Dim s As Integer = 0
        Dim mu As String = ""
        Dim lenInput As Double = input.Length / 2
        Dim lenKey As Double = key.Length / 2
        Dim z As Integer = 0
        For i As Integer = 0 To lenInput - 1
            Dim a As String = i Mod lenKey
            If a = 0 Then
                z = 0
            ElseIf a = 1 Then
                z = 2
            ElseIf a = 2 Then
                z = 4
            ElseIf a = 3 Then
                z = 6
            ElseIf a = 4 Then
                z = 8
            ElseIf a = 5 Then
                z = 10
            ElseIf a = 6 Then
                z = 12
            End If
            Dim b As String = key.Substring(z, 2)
            Dim v As String = input.Substring(s, 2)
            Dim l As String = (DecToBinary(HexToDec(v)))
            Dim n As Double = Bin2Dec(ApplyShiftDoblekanan(ApplyAnd(l, "11110000"), 4))
            Dim m As Double = Bin2Dec(ApplyAnd(l, "1111")) * 16
            Dim k As String = ((HexToDec(b)))
            Dim h As Double = (m + n)
            Dim tmp As Double = Bin2Dec(ApplyXor(DecToBinary(k), DecToBinary(h)))
            Dim hh As UInt64 = tmp
            Dim by() As Byte = BitConverter.GetBytes(hh)

            '    logs(tmp, True, Merah)
            '    
            '     


            '  Dim a = ApplyAnd(tmp, "11110000")
            '  Dim b = ApplyShiftDoblekanan(a, 4)
            '   Dim c = Bin2Dec(b)
            '    Dim d = ApplyAnd(tmp, "1111")
            '    Dim e = Bin2Dec(d) * 16



            '   Dim f As UInt64 = c + e

            '    Dim by() = BitConverter.GetBytes(f)
            '    Dim sk = BytesToHextring(by).Substring(0, 2)

            Dim sk As String = BytesToHextring(by).Substring(0, 2)
            mu += sk
            s += 2
        Next
        Return mu
    End Function
    Public Shared Function Mtk_Shuffle2(ByVal key As String, ByVal input As String) As String
        Dim s As Integer
        Dim mu As String = ""
        For i As Integer = 0 To (input.Length / 2) - 1
            Dim h As String = key.Substring(s, 2)
            Dim j As String = input.Substring(s, 2)
            Dim x As String = (DecToBinary(HexToDec(h)))
            Dim y As String = (DecToBinary(HexToDec(j)))
            Dim tmp As String = ApplyXor(x, y)
            Dim a As String = ApplyAnd(tmp, "11110000")
            Dim b As String = ApplyShiftDoblekanan(a, 4)
            Dim c As Double = Bin2Dec(b)
            Dim d As String = ApplyAnd(tmp, "1111")
            Dim e As Double = Bin2Dec(d) * 16
            Dim f As UInt64 = c + e
            Dim by() As Byte = BitConverter.GetBytes(f)
            Dim sk As String = BytesToHextring(by).Substring(0, 2)
            mu += sk
            s += 2
        Next
        Return mu
    End Function
    Public Shared Function GetKey(ByVal index() As String) As String()
        If index.Length = 3 Then
            Dim h As String = Mtk_Shuffle2(index(0), index(1))
            Dim j As String = Mtk_Shuffle2(index(0), index(2))
            Return {h, j}
        Else
            Dim encaeskey As Byte() = HexStringToBytes(index(0))
            Dim encaesiv As Byte() = HexStringToBytes(index(1))
            Return {index(0), index(1)}
        End If
    End Function
    Public Shared Function BruteKey(ByRef aeskey() As Byte, ByRef aesiv() As Byte) As Boolean
        Dim stream As New FileStream(fname, FileMode.Open, FileAccess.Read)
        Dim buf() As Byte = New Byte(16 - 1) {}
        Using stream
            stream.Seek(0, SeekOrigin.Begin)
            stream.Read(buf, 0, buf.Length)
        End Using
        Dim bufout() As Byte = New Byte(16 - 1) {}
        Try
            Dim k As String = Encoding.UTF8.GetString(DecryptorAes(buf, aeskey, aesiv))
            If k.Contains("MMM") Then
                Return True
            End If
        Catch ex As Exception
            Return False
            MsgBox(ex.ToString)
        End Try
        Return False
    End Function


    'OPFWorker = New BackgroundWorker()
    'OPFWorker.WorkerSupportsCancellation = True
    'AddHandler OPFWorker.DoWork, AddressOf BruteKeyQcom
    '   AddHandler OPFWorker.RunWorkerCompleted, AddressOf CariDevicesEnableAdbSamsung
    '   AddHandler OPFWorker.ProgressChanged, AddressOf ProcessSendingLoader
    'OPFWorker.RunWorkerAsync()
    'OPFWorker.Dispose()


    'OPFWorker = New BackgroundWorker()
    'OPFWorker.WorkerSupportsCancellation = True
    'AddHandler() OPFWorker.DoWork, AddressOf extractofpmtk
    '   AddHandler OPFWorker.RunWorkerCompleted, AddressOf CariDevicesEnableAdbSamsung
    '   AddHandler OPFWorker.ProgressChanged, AddressOf ProcessSendingLoader
    'OPFWorker.RunWorkerAsync()
    'OPFWorker.Dispose()


    Public Shared Sub AllDone(sender As Object, e As RunWorkerCompletedEventArgs)
        'RichLogs(vbCrLf & "All Progress Completed", Color.White, True, True)
        TimeSpanElapsed.ElapsedTime(Watch)
        Watch.Stop()
    End Sub


End Class
