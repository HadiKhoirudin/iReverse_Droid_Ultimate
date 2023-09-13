Imports System
Imports System.IO
Imports System.Windows.Forms

Namespace Mediatek.Mediatek_tool
    Public Class Flashpath
        Public Shared Download_DA As String = Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Plugin\Download"
        Public Shared Flashtoolexe As String = Path.Combine(Windows.Forms.Application.StartupPath) & "\Tools\Explorer\ext\storage_setting\QMSL_MSVC10R.dll"
        ' public static string Flashtooldirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts)) + "/" + "PackDir";
        ' public static string FlashtoolDownload = Path.Combine(Windows.Forms.Application.StartupPath) + "Tools/Plugin/Download";
        ' public static string Sp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts)) + "/" + "PackDir/";//
        ' public static string FlashToolLib = Path.Combine(Windows.Forms.Application.StartupPath) + "/Tools/Plugin/Flash_Tool/FlashtoollibEx.dll";
    End Class
    Public Class Mediatek
        Public Shared Property DA As String
        Public Shared Property Auth As String
        Public Shared Property Scatterfile As String
        Public Shared Property Preloader As String
        Public Shared Property Connection As String
        Public Shared Property Preloaderunlock As String
        Public Shared Property PreloaderEmi As String
        Public Shared Property Savepartition As String
    End Class

    Public Class Flashcommand
        Public Shared Property Flasfirmware As Boolean
        Public Shared Property Customflash As Boolean
        Public Shared Property Formatdata As Boolean
        Public Shared Property Readfirmware As Boolean
        Public Shared Property Readallfirmware As Boolean
        Public Shared Property Writememory As Boolean
        Public Shared Sub Config(result As Boolean)
            Flasfirmware = result
            Customflash = result
            Formatdata = result
            Readfirmware = result
            Readallfirmware = result
            Writememory = result
        End Sub
        Public Shared Formatdisable As Boolean = False
    End Class

    Public Class FlashOption
        Public Shared Property FirmwareXML As String

        Public Shared Config As String = Path.Combine(Path.GetTempPath(), "config.xml")
        Public Shared Property Method As String
        Public Shared Property progres As Integer
        Public Shared Property Devicesallredy As Boolean
        Public Shared Property Textpartition As String

        Public Shared NV_save As String = "nvdata.img,nvram.img"
        Public Shared Property RPMB As String
        Public Shared Property Scatterpath As String
    End Class

    Public Class Flashtoolpath
        Public Shared DevExpres As String = Windows.Forms.Application.StartupPath & "/Tools/Explorer/ext/storage_setting.xsd"
    End Class
    Public Class Extdata
        Public Shared Extfilepath As String = Windows.Forms.Application.StartupPath & "/Tools/Explorer/ext/extcs.exe"
    End Class

    Public Class Sourcefile
        Public Shared Directorypath As String = "Tools/process/Lib/email/police"
        Public Shared Andoidpath As String = Directorypath & "/C4.exe"
        Public Shared Dumped As String = Directorypath & "/" & "boot.img"
    End Class
    Public Class ExSamsung
        Public Shared persistent As String = Windows.Forms.Application.StartupPath & "\Tools\process\Lib\site-packages\Crypto\IO\persistent.bin"
        Public Shared param As String = Windows.Forms.Application.StartupPath & "\Tools\process\Lib\site-packages\Crypto\IO\param.bin"
    End Class
End Namespace
