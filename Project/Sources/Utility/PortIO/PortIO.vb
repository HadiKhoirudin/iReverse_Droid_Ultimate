Imports System
Imports System.IO.Ports
Imports System.Management
Module PortIO
    ' Get and Set Port by USB VID & PID So there is no limitation to COM 10 this will be able to detect COM 48 
    ' set "Vid_xxxx&Pid_xxxx" to match with your Target Device Just see driver *inf or Device Manager to get USB VID & PID -  HadiK IT
    Public Port As SerialPort, timercount As Integer
    Public PortCOM As Integer = 0
    Public Sub SetPort(Vid_xxxx As String, Pid_xxxx As String)
        Dim PortNames As String() = SerialPort.GetPortNames()
        Dim bFound As Boolean = False
        timercount = 30

        For i As Integer = 0 To PortNames.Length - 1
            Dim searcher As New ManagementObjectSearcher("root\WMI", "SELECT * FROM MSSerial_PortName")
            For Each queryObj As ManagementObject In searcher.[Get]()
                Dim sInstanceName As String = queryObj("InstanceName").ToString()
                If sInstanceName.IndexOf(Vid_xxxx & "" & "" & Pid_xxxx) > -1 Then
                    Dim sPortName As String = queryObj("PortName").ToString()
                    Port = New SerialPort(sPortName, 115200, Parity.None, 8, StopBits.One)
                    bFound = True
                    Exit For
                End If
            Next
            timercount -= 1
            Console.WriteLine(timercount)
            If timercount = 0 OrElse bFound Then Exit For
        Next
    End Sub
End Module
