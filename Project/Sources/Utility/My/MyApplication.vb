Imports System
Imports Microsoft.VisualBasic.ApplicationServices


Friend Class MyApplication
        Inherits WindowsFormsApplicationBase
        Public Sub New()
            MyBase.New(AuthenticationMode.ApplicationDefined)
            IsSingleInstance = False
            EnableVisualStyles = True
            SaveMySettingsOnExit = True
            ShutdownStyle = ShutdownMode.AfterAllFormsClose
        End Sub


        <STAThread()>
        Friend Shared Sub Main(args As String())
            Application.Run(args)
        End Sub

    Protected Overrides Sub OnCreateMainForm()
        checkerdump()
        MainForm = Forms.Login
    End Sub
End Class