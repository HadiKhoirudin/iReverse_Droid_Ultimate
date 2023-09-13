Imports System
Imports System.IO
Imports System.Windows.Forms

Namespace Mediatek.Authentication
    Public Class Pythonfile
        Public Shared Python As String = Path.Combine(Windows.Forms.Application.StartupPath & "/Tools/process/process")
        Public Shared mtk As String = "Tools/process/Lib/site-packages/usb/backend/Exception/standalone.xsd"
        Public Shared arg As String = "standalone.xsd"
        Public Shared Broomwork As String = "Tools/process/Lib/site-packages/usb/backend/Exception/Recyclebin"
        Public Shared Modem As String = Path.Combine(Windows.Forms.Application.StartupPath & "/Tools/process/pythonw.exe")
        Public Shared DElet As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) & "\" & "PackDir" & "\")
    End Class
End Namespace
