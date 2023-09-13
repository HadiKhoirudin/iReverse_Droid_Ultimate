Imports System
Imports System.IO
Imports System.Windows.Forms

Namespace Mediatek.Authentication
    Public Class Spdlpath
        Public Shared Property Spdl1 As String
        Public Shared Property Spdl2 As String
        Public Shared Property PAC As String
        Public Shared Downloadini As String = Windows.Forms.Application.StartupPath & "\call\Unisoc\ResearchDownload.ini"
        Public Shared Downloadnewini As String = Windows.Forms.Application.StartupPath & "\call\Unisoc\ResearchDownload.ini"
        Public Shared CmdDloader As String = Path.Combine(Windows.Forms.Application.StartupPath & "\call\Unisoc\CmdDloader.exe")
    End Class
End Namespace
