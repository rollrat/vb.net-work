Imports 추출.RollRat_Vb_Api
Imports 추출.RollRat_Vb_Api.WinApi
Imports 추출.RollRat_Vb_Api.WinApiUsr
Imports System.Runtime.InteropServices

Public Class frmHookEx

    Dim ShowMessage As Boolean = True
    Dim Last_Letter As String = "carriage return"

    Private WithEvents Adjustment As New frmHookEx_Adjustment

    Private WithEvents fHook As New HookEvent

    Private Sub fHook_Hook_SendMessage(iMsg As UInteger, wParam As UInteger, lParam As UInteger) Handles fHook.Hook_SendMessage
        If ShowMessage = True Then
            If Last_Letter = "carriage return" Then
                RichTextBox1.AppendText(wParam & ", " & lParam & vbCrLf)
            ElseIf Last_Letter = "none" Then
                RichTextBox1.AppendText(wParam & ", " & lParam)
            ElseIf Last_Letter = "noshow" Then
            ElseIf Not _Str.SplitS(Last_Letter, "middlecharx:", 1) = "" Then
                RichTextBox1.AppendText(wParam & _Str.SplitS(Last_Letter, "middlecharx:", 1) & lParam & vbCrLf)
            ElseIf Not _Str.SplitS(Last_Letter, "middlecharxwithnone:", 1) = "" Then
                RichTextBox1.AppendText(wParam & _Str.SplitS(Last_Letter, "middlecharxwithnone:", 1) & lParam)
            ElseIf Not _Str.SplitS(Last_Letter, "onlywParam:", 1) = "" Then
                RichTextBox1.AppendText(wParam & _Str.SplitS(Last_Letter, "onlywParam:", 1))
            ElseIf Not _Str.SplitS(Last_Letter, "onlylParam:", 1) = "" Then
                RichTextBox1.AppendText(lParam & _Str.SplitS(Last_Letter, "onlylParam:", 1))
            Else
                RichTextBox1.AppendText(wParam & ", " & lParam & vbCrLf)
            End If
        End If
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        ShowMessage = True
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click
        ShowMessage = False
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Clipboard.SetText(RichTextBox1.Text)
    End Sub

    Private Sub AdjustToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdjustToolStripMenuItem.Click
        Adjustment = New frmHookEx_Adjustment
        Adjustment.Show()
    End Sub

    Private Sub Adjustment_HandleDestroyed(chrLetter As String) Handles Adjustment.Me_Enter
        Last_Letter = chrLetter
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub frmHookEx_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Class HookEvent

    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" ( _
         ByVal idHook As UInteger, ByVal lpfn As HookProc, _
         ByVal hmod As UInteger, ByVal dwThreadId As UInteger) As UInteger
    Private Declare Function CallNextHookEx Lib "user32" ( _
         ByVal hHook As UInteger, ByVal nCode As UInteger, _
         ByVal wParam As UInteger, ByVal lParam As UInteger) As UInteger
    Private Declare Function UnhookWindowsHookEx Lib "user32" ( _
         ByVal hHook As UInteger) As UInteger
    Private Delegate Function HookProc( _
         ByVal nCode As UInteger, ByVal wParam As UInteger, ByRef lParam As UInteger) As UInteger

    <DllImport("kernel32.dll")> _
    Public Shared Function GetCurrentThreadId() As UInteger
    End Function

    Private HookInt As UInteger
    Private HookProcDelegate As HookProc

    Public Event Hook_SendMessage(ByVal iMsg As UInteger, ByVal wParam As UInteger, ByVal lParam As UInteger)

    Public Sub New()
        HookProcDelegate = New HookProc(AddressOf HookProcEx)
        HookInt = SetWindowsHookEx(WH_GETMESSAGE, HookProcDelegate, _
                IntPtr.Zero, GetCurrentThreadId)
    End Sub

    Private Function HookProcEx(ByVal nCode As UInteger, ByVal wParam As UInteger, ByRef lParam As UInteger) As UInteger
        Try
            RaiseEvent Hook_SendMessage(nCode, wParam, lParam)
            Return CallNextHookEx(HookInt, nCode, wParam, lParam)
        Catch ex As Exception
        End Try
    End Function

    Protected Overrides Sub Finalize()
        UnhookWindowsHookEx(HookInt)
        MyBase.Finalize()
    End Sub

    Public Sub Dispose()
        If (HookInt = 0) Then
            Return
        End If
        UnhookWindowsHookEx(HookInt)
        HookInt = 0
    End Sub

    '******************************************************************************
    ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
    '                         RollRat Software Programs & Lab(R LAB)
    '******************************************************************************
End Class
