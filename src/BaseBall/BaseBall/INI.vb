Module INI
    Const Max_Path As Integer = 255
    Declare Ansi Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" ( _
    ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, _
    ByVal lpDefault As String, _
    ByVal lpReturnedString As String, _
    ByVal nSize As Integer, _
    ByVal lpFileName As String) As Integer
    Declare Ansi Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" ( _
    ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, _
    ByVal lpString As String, _
    ByVal lpFileName As String) As Integer
    Public Function ReadIni(ByVal fileName As String, ByVal section As String, ByVal item As String, Optional ByVal defaultValue As String = "") As String
        Dim buffer As New String(Chr(0), Max_Path)
        Dim bufLen As Integer
        bufLen = GetPrivateProfileString(section, item, defaultValue, buffer, Max_Path, fileName)
        Return Left(buffer, bufLen)
    End Function
    Public Sub WriteIni(ByVal fileName As String, ByVal section As String, ByVal item As String, ByVal value As String)
        WritePrivateProfileString(section, item, value, fileName)
    End Sub
    Public Function Switch(ByVal ParamArray VarExpr() As Object) As Object
        Return Microsoft.VisualBasic.Switch(VarExpr)
    End Function
    Public Function Left(ByVal str As String, ByVal Length As Integer) As String
        Return Microsoft.VisualBasic.Left(str, Length)
    End Function
    Public Function Right(ByVal str As String, ByVal Length As Integer) As String
        Return Microsoft.VisualBasic.Right(str, Length)
    End Function
    Public Function Mid(ByVal str As String, ByVal Start As Integer) As String
        Return Microsoft.VisualBasic.Mid(str, Start)
    End Function
    Public Function Mid(ByVal str As String, ByVal Start As Integer, ByVal Length As Integer) As String
        Return Microsoft.VisualBasic.Mid(str, Start)
    End Function
End Module
