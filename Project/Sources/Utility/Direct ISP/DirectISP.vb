Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Management
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports emmclibs.emmclibs
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports DevExpress.XtraEditors

Public Class DirectISP


    Friend Shared SharedUI As DirectISP


    Private Declare Ansi Function CreateFile Lib "kernel32" Alias "CreateFileA" (<MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpFileName As String, dwDesiredAccess As Integer, dwShareMode As Integer, lpSecurityAttributes As Integer, dwCreationDisposition As Integer, dwFlagsAndAttributes As Integer, hTemplateFile As Integer) As Integer

    Private Declare Ansi Function WriteFile Lib "kernel32" (hFile As Integer, ByRef lpBuffer As Integer, nNumberOfBytesToWrite As Integer, ByRef lpNumberOfBytesWritten As Integer, lpOverlapped As Integer) As Integer

    Private Declare Ansi Function ReadFile Lib "kernel32" (hFile As Integer, <MarshalAs(UnmanagedType.AnsiBStr)> ByRef lpBuffer As String, nNumberOfBytesToRead As Integer, ByRef lpNumberOfBytesRead As Integer, lpOverlapped As Integer) As Integer

    Private Declare Auto Function DeviceIoControl Lib "kernel32" (hDevice As IntPtr, dwIoControlCode As Integer, lpInBuffer As IntPtr, nInBufferSize As Integer, lpOutBuffer As IntPtr, nOutBufferSize As Integer, ByRef lpBytesReturned As Integer, lpOverlapped As IntPtr) As Boolean

    Public Declare Function DeviceIoControls Lib "kernel32.dll" (hDevice As IntPtr, dwIoControlCode As UInteger, lpInBuffer As IntPtr, nInBufferSize As UInteger, ByRef lpOutBuffer As Long, nOutBufferSize As UInteger, <System.Runtime.InteropServices.OutAttribute()> ByRef lpBytesReturned As UInteger, lpOverlapped As IntPtr) As Boolean
    Public Overridable Property MyProcess As Process

    Private Property lvi As ListViewItem

    Private str As String
    Private secc As Long
    Private str2 As String
    Private berapakali As Long
    Private commands As String
    Private str3 As String
    Private configpart As Long
    Private dawane As Long
    Private disk As String
    Private miscpart As Long
    Private selecteddisk As String
    Private i As Integer
    Private c As Char()
    Private pname As String
    Private uks As Object
    Private sentot As Object
    Private offset As Long
    Private karung As Long
    Private asu As String
    Private startsecpart As Long
    Private totalchunk As String
    Private folderdersave As Object
    Private checksparse As Boolean
    Private openfile As String
    Private filesize As Long
    Private offsets As Long
    Private poffsets As Long
    Private psize As Long
    Private m As String
    Private awales As Long
    Private partname As String
    Private num8 As Double
    Private pilih As String
    Private portqcom As String
    Private cekerror As Boolean
    Private portNameData As String
    Private comPortNumber As String
    Private spa As String
    Private chipa As String
    Private port As String
    Private pi As String
    Private pn As String
    Private fn As String
    Private id As String
    Private ty As String
    Private lin As String
    Private py As String
    Private ps As String
    Private reg As String
    Private sto As String
    Private bc As String
    Private ir As String
    Private ot As String
    Private iu As String
    Private ebn As String
    Private re As String
    Private da As String
    Private foldersave As String
    Private gen As String
    Private info As String
    Private conf As String
    Private plat As String
    Private pro As String
    Private boot As String
    Private block As String
    Private storage As String
    Private tstor As String
    Private tstor1 As String
    Private chipb As String
    Private ListBox1 As ListBox
    Private ListBox2 As ListBox
    Private ListBox3 As ListBox
    Private ListBox4 As ListBox
    Private ListBox5 As ListBox
    Private ListBox6 As ListBox
    Private ListBox7 As ListBox
    Private check As Boolean
    Private ukuran As String
    Private proc As Process
    Private disksec As Object
    Private drivename As String
    Public waitEvent As AutoResetEvent
    Private status As Boolean
    Public Shared prosesnya As Object
    Public Shared allprosess As Object

    Private Const INVALID_HANDLE As Integer = -1
    Private Const GENERIC_READ As Integer = -2147483648
    Private Const GENERIC_WRITE As Integer = 1073741824
    Private Const FILE_SHARE_READ As Integer = 1
    Private Const FILE_SHARE_WRITE As Integer = 2
    Private Const CREATE_ALWAYS As Integer = 2
    Private Const OPEN_EXISTING As Integer = 3
    Private Const OPEN_ALWAYS As Integer = 4
    Private Const INIT_SUCCESS As Integer = 0
    Private Const WRITE_ERROR As Integer = 0
    Private Const READ_ERROR As Integer = 0
    Private Const LOCK_TIMEOUT As Integer = 3000
    Private Const LOCK_RETRIES As Integer = 5
    Private Const INVALID_HANDLE_VALUE As Integer = -1
    Private Const FSCTL_LOCK_VOLUME As Integer = 589848
    Private Const FSCTL_DISMOUNT_VOLUME As Integer = 589856
    Private Const FSCTL_UNLOCK_VOLUME As Integer = 589852
    Private Const IOCTL_STORAGE_MEDIA_REMOVAL As Integer = 2967556
    Private Const IOCTL_STORAGE_EJECT_MEDIA As Integer = 2967560
    Private Const IOCTL_STORAGE_LOAD_MEDIA As Integer = 2967564

    Private hSource As Integer
    Private hTarget As Integer

    Private Delegate Sub SetStatusTextInvoker(Text As String)
    Private Delegate Sub txtbabbledelegate(text As String)
    Private Delegate Sub btnFillEnableDelegate()

    Private Class PartitionInfo
        Public DrivePartition As String
        Public Drivetype As String
        Public SizeInBytes As ULong
        Public StartingOffset As ULong
        Public IsDivBy1024 As Boolean
    End Class









    Public Sub New()
        InitializeComponent()
        SharedUI = Me
        Watch = New Stopwatch()
        AddHandler DataView.MouseWheel, AddressOf DataView_Mousewheel
        AddHandler DataView.RowPrePaint, AddressOf DataView_RowPrePaint


        AddHandler MyBase.Load, AddressOf Me.Main_Load

        Me.str = ""
        Me.str2 = ""
        Me.commands = ""
        Me.str3 = ""
        Me.disk = ""
        Me.selecteddisk = ""
        Me.i = 0
        Me.c = New Char(1) {}
        Me.checksparse = False
        Me.openfile = ""
        Me.filesize = 0L
        Me.m = ""
        Me.portqcom = ""
        Me.cekerror = False
        Me.spa = """"
        Me.chipa = "platform: "
        Me.port = ""
        Me.pi = "- partition_index: "
        Me.pn = "  partition_name: "
        Me.fn = "  file_name: "
        Me.id = "  is_download: "
        Me.ty = "  type: "
        Me.lin = "  linear_start_addr: "
        Me.py = "  physical_start_addr: "
        Me.ps = "  partition_size: "
        Me.reg = "  region: "
        Me.sto = "  storage:"
        Me.bc = "  boundary_check: "
        Me.ir = "  is_reserved: "
        Me.ot = "  operation_type: "
        Me.iu = "  is_upgradable: "
        Me.ebn = "  empty_boot_needed: "
        Me.re = "  reserve: "
        Me.da = FileSystem.CurDir() + "\spft\MTK_AllInOne_DA.bin"
        Me.foldersave = ""
        Me.gen = "- general: MTK_PLATFORM_CFG"
        Me.info = "  info: "
        Me.conf = "    - config_version: "
        Me.plat = "platform:"
        Me.pro = "project:"
        Me.boot = "boot_channel:"
        Me.block = "block_size: "
        Me.storage = "      storage: EMMC"
        Me.tstor = "storage:"
        Me.tstor1 = "boot_channel"
        Me.chipb = "platform: "
        Me.ListBox1 = New ListBox()
        Me.ListBox2 = New ListBox()
        Me.ListBox3 = New ListBox()
        Me.ListBox4 = New ListBox()
        Me.ListBox5 = New ListBox()
        Me.ListBox6 = New ListBox()
        Me.ListBox7 = New ListBox()
        Me.check = False
        Me.ukuran = ""
        Me.proc = New Process()
        Me.drivename = ""
        Me.waitEvent = New AutoResetEvent(False)


    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs)
        'Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub DataView_Mousewheel(sender As Object, e As MouseEventArgs)
        If DataView.Rows.Count > 0 Then

            If e.Delta > 0 AndAlso DataView.FirstDisplayedScrollingRowIndex > 0 Then
                DataView.FirstDisplayedScrollingRowIndex -= 1
            ElseIf e.Delta < 0 Then
                DataView.FirstDisplayedScrollingRowIndex += 1
            End If

        End If
    End Sub

    Private Sub DataView_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs)
        If e.RowIndex Mod 2 = 0 Then
            DataView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
        Else
            DataView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(96, 94, 92)
        End If
    End Sub
    Private Sub DataView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataView.CellDoubleClick
        If DataView.Rows.Count > 0 Then
            If e.ColumnIndex = 3 Then
                If DataView.CurrentRow.Cells(1).Value = "flash" OrElse DataView.CurrentRow.Cells(1).Value = "boot" Then
                    Dim openFileDialog As New OpenFileDialog()
                    openFileDialog.Title = "Select File Partition " + DataView.CurrentRow.Cells(2).Value
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
                    openFileDialog.FileName = "*.*"
                    openFileDialog.Filter = "ALL FILE  (*.*)|*.*"
                    openFileDialog.FilterIndex = 2
                    openFileDialog.RestoreDirectory = True
                    If openFileDialog.ShowDialog() = DialogResult.OK Then
                        DataView.CurrentRow.Cells(4).Value = openFileDialog.SafeFileName
                        DataView.CurrentRow.Cells(5).Value = Path.Combine(New String() {Path.GetDirectoryName(openFileDialog.FileName)})
                    End If
                Else
                    XtraMessageBox.Show("Custom file available for flash and boot command!", "iREVERSE DROID ULTIMATE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            End If
        End If
    End Sub
    Private Sub VScrollBarDirectISPFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBarDirectISPFlashDataView.Scroll
        If DataView.Rows.Count > 0 Then
            VScrollBarDirectISPFlashDataView.LargeChange = DataView.Rows.Count
            VScrollBarDirectISPFlashDataView.Maximum = DataView.Rows.Count - 1 + VScrollBarDirectISPFlashDataView.LargeChange - 1
            DataView.FirstDisplayedScrollingRowIndex = e.NewValue
        End If
    End Sub

    Private Sub HScrollBarDirectISPFlashDataView_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBarDirectISPFlashDataView.Scroll
        DataView.FirstDisplayedScrollingColumnIndex = e.NewValue
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.asu = ""
        Me.drivename = ""
        Me.ComboBox1.Properties.Items.Clear()
        Dim flag As Boolean = False
        Dim query As WqlObjectQuery = New WqlObjectQuery("SELECT * FROM Win32_DiskDrive")
        Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher(query)
        Try
            For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
                Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
                Dim flag2 As Boolean = Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectGreater(managementObject("MediaType"), Nothing, False)) AndAlso managementObject("MediaType").ToString().Contains("Removable"))
                If flag2 Then
                    Me.str = managementObject("Model").ToString()
                    Me.uks = managementObject("size").ToString()
                    Me.str2 = managementObject("DeviceID").ToString().Replace("\\.\", "")
                    Me.str3 = "MediaType:" & vbTab + managementObject("MediaType").ToString()
                    Me.drivename = Me.str2
                    Main.SharedUI.comboUSB.Invoke(CType(Sub() Main.SharedUI.comboUSB.Text = " [ " + Me.str + " ] ", Action))
                    Me.ComboBox1.Properties.Items.Add(Me.str2)
                    Me.ComboBox1.SelectedIndex = 0
                    flag = True
                End If
            Next
        Finally
            Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator = Nothing
            If enumerator IsNot Nothing Then
                CType(enumerator, IDisposable).Dispose()
            End If
        End Try
        Dim flag3 As Boolean = Not flag
        If flag3 Then
            Me.ComboBox1.Properties.Items.Clear()
        End If
    End Sub
End Class

