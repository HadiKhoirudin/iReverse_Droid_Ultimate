Imports System.Diagnostics

Public Class KillCommand
        Public Shared Sub KillName(Kill As String)
            Dim processesByName As Process() = Process.GetProcessesByName(Kill)

            For Each process As Process In processesByName
                process.Kill()
                process.WaitForExit()
                process.Dispose()
            Next
        End Sub

        Public Shared Sub ProcessKill()
        Dim array As String() = New String() {"CmdDloader", "process", "process.exe", "Python", "Python.exe", "Python", "Python.exe", "QMSL_MSVC10R", "QMSL_MSVC10R.dll", "pythonw", "pythonw.exe", "adb", "adb.exe", "fastboot", "fastboot.exe", "fh_loader", "fh_loader.exe"}

        For Each text As String In array
                Dim processes As Process() = Process.GetProcesses()

                For Each process As Process In processes

                    If process.ProcessName.ToLower().Contains(text.ToLower()) Then
                        process.Kill()
                        process.WaitForExit()
                        process.Dispose()
                    End If
                Next

            Next
        End Sub
End Class