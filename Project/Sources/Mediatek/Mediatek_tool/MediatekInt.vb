Imports System
Imports System.IO

Namespace Mediatek.Mediatek_tool
    Public Class MediatekInt
        Public Shared PathEditor As Integer
        Public Shared Mtk_Unlock As Boolean = False
        Public Shared MediatekMethod As Boolean = True
        Public Shared ListAllredy As Boolean = False
    End Class

    Public Class Extraxpath
        Public Shared FolderFont As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + "Temp" + "\")
        Public Shared Scatter As String = "\" & "ireverse_tool.txt"
        Public Shared Preloader As String = "\" & "preloader.bin"
        Public Shared Property Preloaderback As String
        Public Shared Temp As String = Path.Combine(Path.GetTempPath() & "\" & "A3A9B35EDB33TB".ToLower() & "\")
    End Class

    Public Class Unifersalformat
        Public Shared format As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "format.txt")
        Public Shared formatpath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "formatpath.txt")
    End Class
End Namespace
