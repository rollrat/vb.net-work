﻿'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmPreview

    Private Sub frmPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tmp_ret As New List(Of String)
        For i As Integer = 0 To frmMain.preview_forward.Count - 1
            Dim err As String = ""

            '
            '   파일이름 중복체크
            '
            If tmp_ret.Contains(frmMain.preview_return(i)) Then
                err = "Overlapped"
            Else
                tmp_ret.Add(frmMain.preview_return(i))
            End If

            '
            '   파일이름에서 사용 불가능한 문자 검색
            '
            If frmMain.Check_Irregular(frmMain.preview_return(i)) Then
                If err.Length <> 0 Then
                    err += "+Irregular"
                Else
                    err = "Irregular"
                End If
            End If

            Dim LI As ListViewItem
            LI = ListView1.Items.Add(New ListViewItem(New String() {frmMain.preview_forward(i), frmMain.preview_return(i), err}))
            LI.StateImageIndex = 0

            If err.Length <> 0 Then
                LI.ForeColor = Color.White
                LI.BackColor = Color.Orange
            End If
        Next
        tmp_ret.Clear()
    End Sub

End Class