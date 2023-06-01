Imports System.Collections.Generic
Imports System.Management
Imports System.Windows.Forms

Namespace Mediatek.Mediatek_list
    Public Class Listport
        Public Shared MtkUsbport As String
        Public Shared MtkComport As String = ""
        Public Shared Manufacturer As String
        Public Shared DeviceID As String
        Public Shared ClassGuid As String

        Public Class Info
            Public Mediatekport As String
            Public Comport As String
            Public Manufacturer As String
            Public DeviceID As String
            Public ClassGuid As String

            Public Sub New(Mediatekport As String, Comport As String, Manufacturer As String, DeviceID As String, ClassGuid As String)
                Me.Mediatekport = Mediatekport
                Me.Comport = Comport
                Me.Manufacturer = Manufacturer
                Me.DeviceID = DeviceID
                Me.ClassGuid = ClassGuid
            End Sub
        End Class

        Public Shared Function Devicelists() As List(Of Info)
            Dim list As List(Of Info) = New List(Of Info)()

            Try
                Dim query As WqlObjectQuery = New WqlObjectQuery("SELECT * FROM Win32_PnPEntity WHERE ClassGuid=""{4d36e978-e325-11ce-bfc1-08002be10318}"" and Name LIKE '%MediaTek%'")
                Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher(query)

                For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
                    Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)

                    If managementObject("Caption") IsNot Nothing AndAlso managementObject("Caption").ToString().Contains("MediaTek") Then
                        list.Add(New Info(managementObject("Name").ToString(), managementObject("Name").ToString().Substring(managementObject("Name").ToString().IndexOf("(") + 1).Replace("(", "").Replace(")", ""), managementObject("Manufacturer").ToString(), managementObject("DeviceID").ToString(), managementObject("ClassGuid").ToString().Replace("{", "").Replace("}", "")))
                    End If
                Next

            Catch ex As ManagementException
                MessageBox.Show("An error occurred while querying for WMI data: " & ex.Message)
            End Try

            Return list
        End Function
    End Class
End Namespace
