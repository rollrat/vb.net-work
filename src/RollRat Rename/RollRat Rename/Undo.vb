'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Runtime.InteropServices

Public Class Undo

    Public Sub undo_new()
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(Application.StartupPath() & "\undo.db")
        If fileExists = False Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath() & "\undo.db", String.Empty, False)
        End If
    End Sub

    Public Structure Undo_DB_Architecture
        Dim Magic As Byte
        Dim size_of_recent As Integer
        Dim address_of_recent_start As Integer
    End Structure

    Public Function Marshal_Structure_to_Bytearray(ByVal uda As Undo_DB_Architecture)
        Dim bytearray As Byte() = New Byte() {}
        Dim ptr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(uda))
        ReDim bytearray(Marshal.SizeOf(uda) - 1)
        Marshal.StructureToPtr(uda, ptr, False)
        Marshal.Copy(ptr, bytearray, 0, Marshal.SizeOf(uda))
        Marshal.FreeHGlobal(ptr)
        Return bytearray
    End Function

    Public Function undo_read_recent(ByVal addr As String) As String()
        Dim return_array As New List(Of String)



        Return return_array.ToArray()
    End Function

End Class
