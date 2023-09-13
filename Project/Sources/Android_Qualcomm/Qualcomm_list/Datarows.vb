Imports System.Collections.Generic
Imports System.Xml
Imports Microsoft.VisualBasic.CompilerServices

Namespace Qualcomm.Qualcomm_list
    Public Class Datarows
        Public Class Info
            Public physical_partition_number As String
            Public SECTOR_SIZE_IN_BYTES As String
            Public label As String
            Public start_sector As String
            Public num_partition_sectors As String
            Public filename As String

            Public Sub New(physical_partition_number As String, SECTOR_SIZE_IN_BYTES As String, label As String, start_sector As String, num_partition_sectors As String, filename As String)
                Me.physical_partition_number = physical_partition_number
                Me.SECTOR_SIZE_IN_BYTES = SECTOR_SIZE_IN_BYTES
                Me.label = label
                Me.start_sector = start_sector
                Me.num_partition_sectors = num_partition_sectors
                Me.filename = filename
            End Sub
        End Class

        Public Shared QcDataview As New List(Of Info)()


        Public Shared Function ScatterTable(XmlCollector As String) As List(Of Info)

            Dim list As New List(Of Info)()
            Dim XmlReader As XmlReader = XmlReader.Create(XmlCollector)
            Dim attribute As String = ""
            While XmlReader.Read()
                If XmlReader.NodeType <> XmlNodeType.Element OrElse Operators.CompareString(XmlReader.Name, "program", False) <> 0 Then
                    Continue While
                End If

                Dim physical_partition_number As Object = XmlReader.GetAttribute("physical_partition_number")
                Dim SECTOR_SIZE_IN_BYTES As Object = XmlReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
                Dim label As Object = XmlReader.GetAttribute("label")
                Dim start_sector As Object = XmlReader.GetAttribute("start_sector")
                Dim num_partition_sectors As Object = XmlReader.GetAttribute("num_partition_sectors")
                Dim filename As Object
                If Operators.CompareString(XmlReader.GetAttribute("filename"), "", False) <> 0 Then
                    filename = ((Main.SharedUI.QcFlashCtrl.PathXMLFile, "\", XmlReader.GetAttribute("filename")), "")
                Else
                    filename = "none"
                End If

                attribute = XmlReader.GetAttribute("SECTOR_SIZE_IN_BYTES")

                list.Add(New Info(physical_partition_number, SECTOR_SIZE_IN_BYTES, label, start_sector, num_partition_sectors, filename))
            End While

            If attribute.Contains("512") Then
                Main.SharedUI.QcFlashCtrl.ComboChipQc.SelectedIndex = 0
                Main.SharedUI.QcFlashCtrl.TypeMemory = "emmc"
                Main.SharedUI.QcFlashCtrl.SectorSize = "512"
            ElseIf attribute.Contains("4096") Then
                Main.SharedUI.QcFlashCtrl.ComboChipQc.SelectedIndex = 1
                Main.SharedUI.QcFlashCtrl.TypeMemory = "ufs"
                Main.SharedUI.QcFlashCtrl.SectorSize = "4096"
            End If

            Return list
        End Function

    End Class
End Namespace
