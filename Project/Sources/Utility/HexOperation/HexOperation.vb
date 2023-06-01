Imports System.Drawing
Imports System.IO
Imports System.Text

Public Class HexOperation
    Public Shared Function HexPatch(File As String, Value As String, Replace As String)
        Do
            Dim SearchIn() As Byte
            Dim FS As New FileStream(File, FileMode.Open)
            Dim BR As New BinaryReader(FS)
            SearchIn = BR.ReadBytes(CInt(FS.Length))
            BR.Close()
            FS.Close()
            Dim SearchFor() As Byte
            SearchFor = Encoding.ASCII.GetBytes(Value)
            Dim StartIndex As Integer = ByteArraySearch(SearchIn, SearchFor)
            If StartIndex = -1 Then
                RichLogs("File Patched!", Color.Lime, True, True)
                Return True
                Exit Do
            Else
                Dim FSf As New FileStream(File, FileMode.Open)
                Dim BW As New BinaryWriter(FSf, Encoding.ASCII)
                BW.Seek(StartIndex - 1, SeekOrigin.Begin)
                BW.Write(Replace)
                BW.Close()
                FSf.Close()
            End If
        Loop
    End Function
    Public Shared Function ByteArraySearch(SearchIn() As Byte, SearchFor() As Byte) As Integer
        Dim SearchInIndex As Integer = 0
        Dim SearchForIndex As Integer = 0
        Dim FoundIndex As Integer = -1
        If SearchFor Is Nothing Then Return FoundIndex
        If SearchFor.Length = 0 Then Return FoundIndex
        If SearchIn Is Nothing Then Return FoundIndex
        If SearchIn.Length = 0 Then Return FoundIndex
        For SearchInIndex = 0 To SearchIn.Length - 1
            If SearchIn(SearchInIndex).Equals(SearchFor(SearchForIndex)) Then
                If SearchForIndex = 0 Then
                    FoundIndex = SearchInIndex
                End If
                SearchForIndex += 1
                If SearchForIndex = SearchFor.Length Then
                    Return FoundIndex
                End If
            Else
                FoundIndex = -1
                SearchForIndex = 0
            End If
        Next
        Return FoundIndex
    End Function
End Class
