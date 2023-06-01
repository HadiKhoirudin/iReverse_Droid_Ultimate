Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Xml

Namespace DXApplication
    Public Class Mtkxml
        Public Shared Property CPU As String
        Public Shared Property CPUType As String
        Public Shared Property Cache As String
        Public Shared Property Userdata As String
        Public Shared Property Cachepath As String
        Public Shared Property Userpath As String
        Public Shared Function IsSupport(scatter As String) As Boolean
            Dim result As Boolean
            Try
                Dim flag = False
                Dim s = File.ReadAllText(scatter)
                Using stringReader As StringReader = New StringReader(s)
                    While stringReader.Peek() <> -1
                        Dim text As String = stringReader.ReadLine()
                        If text.Contains("platform:") Then
                            CPU = text.Substring(text.IndexOf(":") + 2)
                            flag = True
                        ElseIf text.Contains("storage: EMMC") Then
                            CPUType = "EMMC"
                        ElseIf text.Contains("storage: NAND") Then
                            CPUType = "NAND"
                        ElseIf text.Contains("storage: UFS") Then
                            CPUType = "UFS"
                        End If
                    End While
                End Using
                result = flag
            Catch
                Throw New Exception("Scatter cant support !")
            End Try
            Return result
        End Function

        Public Class mtk
            Public Partition_index As String
            Public Partition_name As String
            Public File_name As String
            Public Is_download As String
            Public Linear_start_addr As String
            Public Partition_size As String
            Public Sub New(Partition_index As String, Partition_name As String, File_name As String, Is_download As String, Linear_start_addr As String, Partition_size As String)
                Me.Partition_index = Partition_index
                Me.Partition_name = Partition_name
                Me.File_name = File_name
                Me.Is_download = Is_download
                Me.Linear_start_addr = Linear_start_addr
                Me.Partition_size = Partition_size
            End Sub
        End Class

        Public Shared Function ScatterTable(Scatterfile As String) As List(Of mtk)
            Dim list As List(Of mtk) = New List(Of mtk)()
            Dim text = File.ReadAllText(Scatterfile).Replace("- partition_index:", "+ partition_index:")
            Dim array = text.Split(New Char() {"+"c})
            For Each text2 As String In array
                If text2.Contains("partition_name") Then
                    Dim partition_index = ""
                    Dim partition_name = ""
                    Dim file_name = ""
                    Dim is_download = ""
                    Dim linear_start_addr = ""
                    Dim partition_size = ""
                    Using stringReader As StringReader = New StringReader(text2)
                        While stringReader.Peek() <> -1
                            Dim text3 As String = stringReader.ReadLine()
                            If text3.Contains("partition_index") Then
                                partition_index = text3.Substring(text3.IndexOf(":") + 2).Replace("SYS", "")
                            End If
                            If text3.Contains("partition_name") Then
                                partition_name = text3.Substring(text3.IndexOf(":") + 2)
                            End If
                            If text3.Contains("file_name") Then
                                file_name = text3.Substring(text3.IndexOf(":") + 2)
                            End If
                            If text3.Contains("is_download") Then
                                is_download = text3.Substring(text3.IndexOf(":") + 2)
                            End If
                            If text3.Contains("linear_start_addr") Then
                                linear_start_addr = text3.Substring(text3.IndexOf(":") + 2)
                            End If
                            If text3.Contains("partition_size") Then
                                partition_size = text3.Substring(text3.IndexOf(":") + 2)
                            End If
                        End While
                    End Using
                    list.Add(New mtk(partition_index, partition_name, file_name, is_download, linear_start_addr, partition_size))
                End If
            Next
            Return list
        End Function

        Public Class Firmware
            Public Property Index As String
            Public Property Filepath As String
            Public Sub New(Index As String, Filepath As String)
                Me.Index = Index
                Me.Filepath = Filepath
            End Sub
        End Class

        Public Shared Function DownloadOnly(scatter As String, DA As String, auth As String, Connection As String, COM_port As String, downloadlist As List(Of Firmware)) As String
            Dim result As String
            If IsSupport(scatter) Then
                If File.Exists(Mediatek.Mediatek_tool.FlashOption.Config) Then
                    File.Delete(Mediatek.Mediatek_tool.FlashOption.Config)
                End If
                Dim xmlDocument As XmlDocument = New XmlDocument()
                Dim newChild As XmlNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
                Dim xmlElement = xmlDocument.CreateElement("flashtool-config")
                xmlElement.SetAttribute("version", "2.0")
                Dim xmlNode As XmlNode = xmlDocument.CreateElement("general")
                Dim xmlElement2 = xmlDocument.CreateElement("chip-name")
                xmlElement2.InnerText = CPU
                Dim xmlElement3 = xmlDocument.CreateElement("storage-type")
                xmlElement3.InnerText = CPUType
                Dim xmlElement4 = xmlDocument.CreateElement("download-agent")
                xmlElement4.InnerText = DA
                Dim xmlElement5 = xmlDocument.CreateElement("scatter")
                xmlElement5.InnerText = scatter
                Dim xmlElement6 = xmlDocument.CreateElement("authentication")
                xmlElement6.InnerText = auth
                Dim xmlElement7 = xmlDocument.CreateElement("certification")
                xmlElement7.InnerText = ""
                Dim xmlNode2 As XmlNode = xmlDocument.CreateElement("rom-list")
                For Each firmware As Firmware In downloadlist
                    Dim xmlElement8 = xmlDocument.CreateElement("rom")
                    xmlElement8.SetAttribute("enable", "true")
                    xmlElement8.SetAttribute("index", firmware.Index)
                    xmlElement8.InnerText = firmware.Filepath
                    xmlNode2.AppendChild(xmlElement8)
                Next
                Dim xmlElement9 = xmlDocument.CreateElement("connection")
                If Equals(Connection, "BromUSB") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("high-speed", "true")
                    xmlElement9.SetAttribute("power", "AutoDetect")
                    xmlElement9.SetAttribute("da_log_level", "Info")
                    xmlElement9.SetAttribute("da_log_channel", "UART")
                    xmlElement9.SetAttribute("timeout-count", "120000")
                    xmlElement9.SetAttribute("com-port", "")
                ElseIf Equals(Connection, "BromUART") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("port", "\\.\" & COM_port)
                End If
                Dim xmlNode3 As XmlNode = xmlDocument.CreateElement("checksum-level")
                xmlNode3.InnerText = "none"
                Dim xmlElement10 = xmlDocument.CreateElement("log-info")
                xmlElement10.SetAttribute("log_on", "true")
                xmlElement10.SetAttribute("log_path", "C:\ProgramData\SP_FT_Logs")
                xmlElement10.SetAttribute("clean_hours", "24")
                xmlDocument.AppendChild(newChild)
                xmlDocument.AppendChild(xmlElement)
                xmlNode.AppendChild(xmlElement2)
                xmlNode.AppendChild(xmlElement3)
                xmlNode.AppendChild(xmlElement4)
                xmlNode.AppendChild(xmlElement5)
                xmlNode.AppendChild(xmlElement6)
                xmlNode.AppendChild(xmlElement7)
                xmlNode.AppendChild(xmlNode2)
                xmlNode.AppendChild(xmlElement9)
                xmlNode.AppendChild(xmlNode3)
                xmlNode.AppendChild(xmlElement10)
                Dim xmlNode4 As XmlNode = xmlDocument.CreateElement("commands")
                Dim xmlElement11 = xmlDocument.CreateElement("download-only")
                Dim newChild2 = xmlDocument.CreateElement("da-download-all")
                xmlElement.AppendChild(xmlNode)
                xmlElement.AppendChild(xmlNode4)
                xmlNode4.AppendChild(xmlElement11)
                xmlElement11.AppendChild(newChild2)
                xmlDocument.Save(Mediatek.Mediatek_tool.FlashOption.Config)

                Dim savingxml As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)

                result = Mediatek.Mediatek_tool.FlashOption.Config
            Else
                result = Nothing
            End If
            Return result
        End Function

        Public Shared Function FirmwareUpgrade(scatter As String, DA As String, auth As String, Connection As String, COM_port As String, downloadlist As List(Of Firmware)) As String
            Dim result As String
            If IsSupport(scatter) Then
                If File.Exists(Mediatek.Mediatek_tool.FlashOption.Config) Then
                    File.Delete(Mediatek.Mediatek_tool.FlashOption.Config)
                End If
                Dim xmlDocument As XmlDocument = New XmlDocument()
                Dim newChild As XmlNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
                Dim xmlElement = xmlDocument.CreateElement("flashtool-config")
                xmlElement.SetAttribute("version", "2.0")
                Dim xmlNode As XmlNode = xmlDocument.CreateElement("general")
                Dim xmlElement2 = xmlDocument.CreateElement("chip-name")
                xmlElement2.InnerText = CPU
                Dim xmlElement3 = xmlDocument.CreateElement("storage-type")
                xmlElement3.InnerText = CPUType
                Dim xmlElement4 = xmlDocument.CreateElement("download-agent")
                xmlElement4.InnerText = DA
                Dim xmlElement5 = xmlDocument.CreateElement("scatter")
                xmlElement5.InnerText = scatter
                Dim xmlElement6 = xmlDocument.CreateElement("authentication")
                xmlElement6.InnerText = auth
                Dim xmlElement7 = xmlDocument.CreateElement("certification")
                xmlElement7.InnerText = ""
                Dim xmlNode2 As XmlNode = xmlDocument.CreateElement("rom-list")
                For Each firmware As Firmware In downloadlist
                    Dim xmlElement8 = xmlDocument.CreateElement("rom")
                    xmlElement8.SetAttribute("index", firmware.Index)
                    xmlElement8.SetAttribute("enable", "true")
                    xmlElement8.InnerText = firmware.Filepath
                    xmlNode2.AppendChild(xmlElement8)
                Next
                Dim xmlElement9 = xmlDocument.CreateElement("connection")
                If Equals(Connection, "BromUSB") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("high-speed", "true")
                    xmlElement9.SetAttribute("power", "AutoDetect")
                    xmlElement9.SetAttribute("da_log_level", "Info")
                    xmlElement9.SetAttribute("da_log_channel", "UART")
                    xmlElement9.SetAttribute("timeout-count", "120000")
                    xmlElement9.SetAttribute("com-port", "")
                ElseIf Equals(Connection, "BromUART") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("port", "\\.\" & COM_port)
                End If
                Dim xmlNode3 As XmlNode = xmlDocument.CreateElement("checksum-level")
                xmlNode3.InnerText = "none"
                Dim xmlElement10 = xmlDocument.CreateElement("log-info")
                xmlElement10.SetAttribute("log_on", "true")
                xmlElement10.SetAttribute("log_path", "C:\ProgramData\SP_FT_Logs")
                xmlElement10.SetAttribute("clean_hours", "24")
                xmlDocument.AppendChild(newChild)
                xmlDocument.AppendChild(xmlElement)
                xmlNode.AppendChild(xmlElement2)
                xmlNode.AppendChild(xmlElement3)
                xmlNode.AppendChild(xmlElement4)
                xmlNode.AppendChild(xmlElement5)
                xmlNode.AppendChild(xmlElement6)
                xmlNode.AppendChild(xmlElement7)
                xmlNode.AppendChild(xmlNode2)
                xmlNode.AppendChild(xmlElement9)
                xmlNode.AppendChild(xmlNode3)
                xmlNode.AppendChild(xmlElement10)
                Dim xmlNode4 As XmlNode = xmlDocument.CreateElement("commands")
                Dim xmlElement11 = xmlDocument.CreateElement("firmware-upgrade")
                Dim xmlElement12 = xmlDocument.CreateElement("scene")
                xmlElement12.InnerText = "FIRMWARE_UPGRADE"
                Dim xmlElement13 = xmlDocument.CreateElement("readback")
                Dim xmlElement14 = xmlDocument.CreateElement("format")
                xmlElement14.SetAttribute("validation", "false")
                xmlElement14.SetAttribute("physical", "true")
                xmlElement14.SetAttribute("erase-flag", "NormalErase")
                xmlElement14.SetAttribute("auto-format", "false")
                xmlElement14.SetAttribute("auto-format-flag", "FormatAll")
                Dim newChild2 = xmlDocument.CreateElement("da-download-all")
                xmlElement.AppendChild(xmlNode)
                xmlElement.AppendChild(xmlNode4)
                xmlNode4.AppendChild(xmlElement11)
                xmlElement11.AppendChild(xmlElement12)
                xmlElement11.AppendChild(xmlElement13)
                xmlElement11.AppendChild(xmlElement14)
                xmlElement11.AppendChild(newChild2)
                xmlDocument.Save(Mediatek.Mediatek_tool.FlashOption.Config)

                Dim savingxml As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)

                result = Mediatek.Mediatek_tool.FlashOption.Config
            Else
                result = Nothing
            End If
            Return result
        End Function

        Public Shared Function FormatAllDownload(scatter As String, DA As String, auth As String, Connection As String, COM_port As String, downloadlist As List(Of Firmware)) As String
            Dim result As String
            If IsSupport(scatter) Then
                If File.Exists(Mediatek.Mediatek_tool.FlashOption.Config) Then
                    File.Delete(Mediatek.Mediatek_tool.FlashOption.Config)
                End If
                Dim xmlDocument As XmlDocument = New XmlDocument()
                Dim newChild As XmlNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
                Dim xmlElement = xmlDocument.CreateElement("flashtool-config")
                xmlElement.SetAttribute("version", "2.0")
                Dim xmlNode As XmlNode = xmlDocument.CreateElement("general")
                Dim xmlElement2 = xmlDocument.CreateElement("chip-name")
                xmlElement2.InnerText = CPU
                Dim xmlElement3 = xmlDocument.CreateElement("storage-type")
                xmlElement3.InnerText = CPUType
                Dim xmlElement4 = xmlDocument.CreateElement("download-agent")
                xmlElement4.InnerText = DA
                Dim xmlElement5 = xmlDocument.CreateElement("scatter")
                xmlElement5.InnerText = scatter
                Dim xmlElement6 = xmlDocument.CreateElement("authentication")
                xmlElement6.InnerText = auth
                Dim xmlElement7 = xmlDocument.CreateElement("certification")
                xmlElement7.InnerText = ""
                Dim xmlNode2 As XmlNode = xmlDocument.CreateElement("rom-list")
                For Each firmware As Firmware In downloadlist
                    Dim xmlElement8 = xmlDocument.CreateElement("rom")
                    xmlElement8.SetAttribute("index", firmware.Index)
                    xmlElement8.SetAttribute("enable", "true")
                    xmlElement8.InnerText = firmware.Filepath
                    xmlNode2.AppendChild(xmlElement8)
                Next
                Dim xmlElement9 = xmlDocument.CreateElement("connection")
                If Equals(Connection, "BromUSB") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("high-speed", "true")
                    xmlElement9.SetAttribute("power", "AutoDetect")
                    xmlElement9.SetAttribute("da_log_level", "Info")
                    xmlElement9.SetAttribute("da_log_channel", "UART")
                    xmlElement9.SetAttribute("timeout-count", "120000")
                    xmlElement9.SetAttribute("com-port", "")
                ElseIf Equals(Connection, "BromUART") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("port", "\\.\" & COM_port)
                End If
                Dim xmlNode3 As XmlNode = xmlDocument.CreateElement("checksum-level")
                xmlNode3.InnerText = "none"
                Dim xmlElement10 = xmlDocument.CreateElement("log-info")
                xmlElement10.SetAttribute("log_on", "true")
                xmlElement10.SetAttribute("log_path", "C:\ProgramData\SP_FT_Logs")
                xmlElement10.SetAttribute("clean_hours", "24")
                xmlDocument.AppendChild(newChild)
                xmlDocument.AppendChild(xmlElement)
                xmlNode.AppendChild(xmlElement2)
                xmlNode.AppendChild(xmlElement3)
                xmlNode.AppendChild(xmlElement4)
                xmlNode.AppendChild(xmlElement5)
                xmlNode.AppendChild(xmlElement6)
                xmlNode.AppendChild(xmlElement7)
                xmlNode.AppendChild(xmlNode2)
                xmlNode.AppendChild(xmlElement9)
                xmlNode.AppendChild(xmlNode3)
                xmlNode.AppendChild(xmlElement10)
                Dim xmlNode4 As XmlNode = xmlDocument.CreateElement("commands")
                Dim xmlElement11 = xmlDocument.CreateElement("format-download")
                Dim xmlNode5 As XmlNode = xmlDocument.CreateElement("combo-format")
                Dim xmlElement12 = xmlDocument.CreateElement("format")
                xmlElement12.SetAttribute("validation", "false")
                xmlElement12.SetAttribute("physical", "true")
                xmlElement12.SetAttribute("erase-flag", "NormalErase")
                xmlElement12.SetAttribute("auto-format", "true")
                xmlElement12.SetAttribute("auto-format-flag", "FormatAll")
                xmlNode5.AppendChild(xmlElement12)
                Dim newChild2 = xmlDocument.CreateElement("da-download-all")
                xmlElement.AppendChild(xmlNode)
                xmlElement.AppendChild(xmlNode4)
                xmlNode4.AppendChild(xmlElement11)
                xmlElement11.AppendChild(xmlNode5)
                xmlElement11.AppendChild(newChild2)
                xmlDocument.Save(Mediatek.Mediatek_tool.FlashOption.Config)

                Dim savingxml As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)

                result = Mediatek.Mediatek_tool.FlashOption.Config
            Else
                result = Nothing
            End If
            Return result
        End Function

        Public Shared Function Addressformat(scatter As String, DA As String, auth As String, preloader As String, partition As String, Connection As String, COM_port As String) As String
            Dim result As String
            If IsSupport(scatter) Then
                If File.Exists(Mediatek.Mediatek_tool.FlashOption.Config) Then
                    File.Delete(Mediatek.Mediatek_tool.FlashOption.Config)
                End If
                Dim innerText = ""
                Dim innerText2 = ""
                Dim list = ScatterTable(scatter)
                For Each mtk As mtk In list
                    If Equals(mtk.Partition_name.ToLower(), partition) Then
                        innerText = mtk.Linear_start_addr
                        innerText2 = mtk.Partition_size
                        Dim index = mtk.Partition_index
                        Exit For
                    End If
                Next
                Dim xmlDocument As XmlDocument = New XmlDocument()
                Dim newChild As XmlNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
                Dim xmlElement = xmlDocument.CreateElement("flashtool-config")
                xmlElement.SetAttribute("version", "2.0")
                Dim xmlNode As XmlNode = xmlDocument.CreateElement("general")
                Dim xmlElement2 = xmlDocument.CreateElement("chip-name")
                xmlElement2.InnerText = CPU
                Dim xmlElement3 = xmlDocument.CreateElement("storage-type")
                xmlElement3.InnerText = CPUType
                Dim xmlElement4 = xmlDocument.CreateElement("download-agent")
                xmlElement4.InnerText = DA
                Dim xmlElement5 = xmlDocument.CreateElement("scatter")
                xmlElement5.InnerText = scatter
                Dim xmlElement6 = xmlDocument.CreateElement("authentication")
                xmlElement6.InnerText = auth
                Dim xmlElement7 = xmlDocument.CreateElement("certification")
                xmlElement7.InnerText = ""
                Dim xmlNode2 As XmlNode = xmlDocument.CreateElement("rom-list")
                Dim xmlElement8 = xmlDocument.CreateElement("rom")
                If Not String.IsNullOrEmpty(preloader) Then
                    xmlElement8.SetAttribute("index", "0")
                    xmlElement8.SetAttribute("enable", "true")
                    xmlElement8.InnerText = preloader
                Else
                    xmlElement8.SetAttribute("index", "0")
                    xmlElement8.SetAttribute("enable", "false")
                End If
                Dim xmlElement9 = xmlDocument.CreateElement("connection")
                If Equals(Connection, "BromUSB") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("high-speed", "true")
                    xmlElement9.SetAttribute("power", "AutoDetect")
                    xmlElement9.SetAttribute("da_log_level", "Info")
                    xmlElement9.SetAttribute("da_log_channel", "UART")
                    xmlElement9.SetAttribute("timeout-count", "120000")
                    xmlElement9.SetAttribute("com-port", "")
                ElseIf Equals(Connection, "BromUART") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("port", "\\.\" & COM_port)
                End If
                Dim xmlNode3 As XmlNode = xmlDocument.CreateElement("checksum-level")
                xmlNode3.InnerText = "none"
                Dim xmlElement10 = xmlDocument.CreateElement("log-info")
                xmlElement10.SetAttribute("log_on", "true")
                xmlElement10.SetAttribute("log_path", "C:\ProgramData\SP_FT_Logs")
                xmlElement10.SetAttribute("clean_hours", "24")
                xmlNode2.AppendChild(xmlElement8)
                xmlDocument.AppendChild(newChild)
                xmlDocument.AppendChild(xmlElement)
                xmlNode.AppendChild(xmlElement2)
                xmlNode.AppendChild(xmlElement3)
                xmlNode.AppendChild(xmlElement4)
                xmlNode.AppendChild(xmlElement5)
                xmlNode.AppendChild(xmlElement6)
                xmlNode.AppendChild(xmlElement7)
                xmlNode.AppendChild(xmlNode2)
                xmlNode.AppendChild(xmlElement9)
                xmlNode.AppendChild(xmlNode3)
                xmlNode.AppendChild(xmlElement10)
                Dim xmlNode4 As XmlNode = xmlDocument.CreateElement("commands")
                Dim xmlElement11 = xmlDocument.CreateElement("format")
                xmlElement11.SetAttribute("validation", "false")
                xmlElement11.SetAttribute("physical", "false")
                xmlElement11.SetAttribute("erase-flag", "NormalErase")
                xmlElement11.SetAttribute("auto-format", "false")
                Dim xmlNode5 As XmlNode = xmlDocument.CreateElement("begin-addr")
                xmlNode5.InnerText = innerText
                Dim xmlNode6 As XmlNode = xmlDocument.CreateElement("length")
                xmlNode6.InnerText = innerText2
                Dim xmlNode7 As XmlNode = xmlDocument.CreateElement("part-id")
                xmlNode7.InnerText = "8"
                xmlElement.AppendChild(xmlNode)
                xmlElement.AppendChild(xmlNode4)
                xmlNode4.AppendChild(xmlElement11)
                xmlElement11.AppendChild(xmlNode5)
                xmlElement11.AppendChild(xmlNode6)
                xmlElement11.AppendChild(xmlNode7)
                xmlDocument.Save(Mediatek.Mediatek_tool.FlashOption.Config)

                Dim savingxml As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)

                result = Mediatek.Mediatek_tool.FlashOption.Config
            Else
                result = Mediatek.Mediatek_tool.FlashOption.Config
            End If
            Return result
        End Function

        Public Shared Function SaveFormat(scatter As String, DA As String, Auth As String, preloader As String, Connection As String, comport As String, partition As String, path As String, addres As List(Of mtk)) As String
            Dim result As String
            If IsSupport(scatter) Then
                If File.Exists(Mediatek.Mediatek_tool.FlashOption.Config) Then
                    File.Delete(Mediatek.Mediatek_tool.FlashOption.Config)
                End If
                Dim xmlDocument As XmlDocument = New XmlDocument()
                Dim newChild As XmlNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
                Dim xmlElement = xmlDocument.CreateElement("flashtool-config")
                xmlElement.SetAttribute("version", "2.0")
                Dim xmlNode As XmlNode = xmlDocument.CreateElement("general")
                Dim xmlElement2 = xmlDocument.CreateElement("chip-name")
                xmlElement2.InnerText = CPU
                Dim xmlElement3 = xmlDocument.CreateElement("storage-type")
                xmlElement3.InnerText = CPUType
                Dim xmlElement4 = xmlDocument.CreateElement("download-agent")
                xmlElement4.InnerText = DA
                Dim xmlElement5 = xmlDocument.CreateElement("scatter")
                xmlElement5.InnerText = scatter
                Dim xmlElement6 = xmlDocument.CreateElement("authentication")
                xmlElement6.InnerText = Auth
                Dim xmlElement7 = xmlDocument.CreateElement("certification")
                xmlElement7.InnerText = ""
                Dim xmlNode2 As XmlNode = xmlDocument.CreateElement("rom-list")
                Dim xmlElement8 = xmlDocument.CreateElement("rom")
                If Not String.IsNullOrEmpty(preloader) Then
                    xmlElement8.SetAttribute("index", "0")
                    xmlElement8.SetAttribute("enable", "true")
                    xmlElement8.InnerText = preloader
                End If
                Dim xmlElement9 = xmlDocument.CreateElement("connection")
                If Equals(Connection, "BromUSB") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("high-speed", "true")
                    xmlElement9.SetAttribute("power", "AutoDetect")
                    xmlElement9.SetAttribute("da_log_level", "Info")
                    xmlElement9.SetAttribute("da_log_channel", "UART")
                    xmlElement9.SetAttribute("timeout-count", "120000")
                    xmlElement9.SetAttribute("com-port", "")
                ElseIf Equals(Connection, "BromUART") Then
                    xmlElement9.SetAttribute("type", Connection)
                    xmlElement9.SetAttribute("port", "\\.\" & comport)
                End If
                Dim xmlNode3 As XmlNode = xmlDocument.CreateElement("checksum-level")
                xmlNode3.InnerText = "none"
                Dim xmlElement10 = xmlDocument.CreateElement("log-info")
                xmlElement10.SetAttribute("log_on", "true")
                xmlElement10.SetAttribute("log_path", "C:\ProgramData\SP_FT_Logs")
                xmlElement10.SetAttribute("clean_hours", "24")
                xmlNode2.AppendChild(xmlElement8)
                xmlDocument.AppendChild(newChild)
                xmlDocument.AppendChild(xmlElement)
                xmlNode.AppendChild(xmlElement2)
                xmlNode.AppendChild(xmlElement3)
                xmlNode.AppendChild(xmlElement4)
                xmlNode.AppendChild(xmlElement5)
                xmlNode.AppendChild(xmlElement6)
                xmlNode.AppendChild(xmlElement7)
                xmlNode.AppendChild(xmlNode2) '
                xmlNode.AppendChild(xmlElement9)
                xmlNode.AppendChild(xmlNode3)
                xmlNode.AppendChild(xmlElement10)
                Dim xmlNode4 As XmlNode = xmlDocument.CreateElement("commands")
                Dim xmlElement11 = xmlDocument.CreateElement("write-memory")
                Dim xmlElement12 = xmlDocument.CreateElement("write-memory-item")
                xmlElement12.SetAttribute("input-mode", "FromFile")
                xmlElement12.SetAttribute("program-mode", "PageOnly")
                xmlElement12.SetAttribute("addr-mode", "LogicalAddress")
                For Each firmware As mtk In addres
                    If firmware.Partition_name.Contains(partition) Then
                        xmlElement12.SetAttribute("address", firmware.Linear_start_addr)
                        xmlElement12.SetAttribute("input-length", "0x0100000")
                    End If
                Next
                xmlElement12.SetAttribute("part-id", "8")
                xmlElement12.SetAttribute("is_by_sram", "0")
                xmlElement12.InnerText = path
                xmlElement.AppendChild(xmlNode)
                xmlElement.AppendChild(xmlNode4)
                xmlNode4.AppendChild(xmlElement11)
                xmlElement11.AppendChild(xmlElement12)
                xmlDocument.Save(Mediatek.Mediatek_tool.FlashOption.Config)

                Dim savingxml As New FileInfo(Mediatek.Mediatek_tool.FlashOption.Config)

                result = Mediatek.Mediatek_tool.FlashOption.Config
            Else
                result = Mediatek.Mediatek_tool.FlashOption.Config
            End If
            Return result
        End Function
    End Class
End Namespace
