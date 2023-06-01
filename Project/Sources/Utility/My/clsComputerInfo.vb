Imports System
Imports System.Management
Imports Microsoft.VisualBasic.CompilerServices

Public Class ClsComputerInfo

        Friend Function GetProcessorId() As String
            Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
            Dim empty As String = String.Empty
            Using managementObjectSearcher As New ManagementObjectSearcher(New SelectQuery("Win32_processor"))
                enumerator = managementObjectSearcher.[Get]().GetEnumerator()
                While enumerator.MoveNext()
                    empty = DirectCast(enumerator.Current, ManagementObject)("processorId").ToString()
                End While
            End Using
            Return empty
        End Function


        Friend Function GetMACAddress() As String
            Dim managementClass As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim instances As ManagementObjectCollection = managementClass.GetInstances()
            Dim text As String = String.Empty
            Try
                For Each managementBaseObject As ManagementBaseObject In instances
                    Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
                    If text.Equals(String.Empty) Then
                        If Conversions.ToBoolean(managementObject("IPEnabled")) Then
                            text = managementObject("MacAddress").ToString()
                        End If
                        managementObject.Dispose()
                    End If
                    text = text.Replace(":", String.Empty)
                Next
            Finally
                Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                If enumerator IsNot Nothing Then
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                    CType(enumerator, IDisposable).Dispose()
                End If
            End Try
            Return text
        End Function


        Friend Function GetMotherBoardID() As String
            Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
            Dim empty As String = String.Empty
            Using managementObjectSearcher As New ManagementObjectSearcher(New SelectQuery("Win32_BaseBoard"))
                enumerator = managementObjectSearcher.[Get]().GetEnumerator()
                While enumerator.MoveNext()
                    empty = DirectCast(enumerator.Current, ManagementObject)("SerialNumber").ToString()
                End While
            End Using
            Return empty
        End Function
End Class