Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic


<DebuggerNonUserCode()>
    <HideModuleName()>
    <CompilerGenerated()>
    Friend Module MySettingsProperty

        <HelpKeyword("My.Settings")>
        Friend ReadOnly Property Settings As MySettings
            Get
                Return MySettings.[Default]
            End Get
        End Property
End Module