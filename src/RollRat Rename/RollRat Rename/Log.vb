'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Reflection
Imports System.Text
Imports System.IO

Module Log

    Public admission As Boolean = True

    Public Sub WriteLog(ByVal Text As String, Optional ByVal err As Boolean = False, Optional ByVal errcode As Integer = 0)
        If admission Then
            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(Application.StartupPath() & "\report.log")
            If fileExists = False Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath() & "\report.log", String.Empty, False)
            End If

            If err Then
                putline(Application.StartupPath() & "\report.log", _
                        "[" & DateTime.Now.ToString & "] * Error * " & Text & ";code=" & errcode) '& MD5Str(errcode))
            Else
                putline(Application.StartupPath() & "\report.log", _
                        "[" & DateTime.Now.ToString & "] " & Text)
            End If
        End If
    End Sub

    Private Sub putline(ByVal addr As String, ByVal txt As String)
        My.Computer.FileSystem.WriteAllText(addr, txt & vbCrLf, True)
    End Sub

    Public Sub WriteLines(ByVal txts As String())
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(Application.StartupPath() & "\report.log")
        If fileExists = False Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath() & "\report.log", String.Empty, False)
        End If

        Dim strl As New StringBuilder
        For i As Integer = 0 To txts.Length - 1
            If txts.Length - 1 = i Then
                strl.Append(txts(i))
                Exit For
            End If
            strl.Append(txts(i) & vbCrLf)
        Next
        putline(Application.StartupPath() & "\report.log", strl.ToString())
    End Sub

    Public Function ReadAllLogLines() As String()
        Dim ret As String() = Nothing
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(Application.StartupPath() & "\report.log")
        If fileExists = True Then
            ret = File.ReadAllLines(Application.StartupPath() & "\report.log")
        End If
        Return ret
    End Function

End Module
