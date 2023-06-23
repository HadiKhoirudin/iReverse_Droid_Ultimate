Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows.Forms.Application

Public Class Consoles
    Public Shared Function Fastboot(cmd As String, worker As BackgroundWorker, ee As DoWorkEventArgs) As String
        Dim output As String = ""
        Dim fastBootExe As New Process()
        fastBootExe.StartInfo.FileName = StartupPath & "\Tools\process\fastboot.exe"
        fastBootExe.StartInfo.Arguments = $"{cmd}"
        fastBootExe.StartInfo.CreateNoWindow = True
        fastBootExe.StartInfo.UseShellExecute = False
        fastBootExe.StartInfo.RedirectStandardOutput = True
        fastBootExe.StartInfo.RedirectStandardError = True

        If worker.CancellationPending Then
            fastBootExe.Dispose()
            ee.Cancel = True
            Return output
        Else
            fastBootExe.Start()
            Dim readerStdError = fastBootExe.StandardError
            Dim readerStdOutput = fastBootExe.StandardError
            output = readerStdError.ReadToEnd() & readerStdOutput.ReadToEnd()
            fastBootExe.WaitForExit()
        End If
        Console.WriteLine(output)
        Return output
    End Function

End Class
