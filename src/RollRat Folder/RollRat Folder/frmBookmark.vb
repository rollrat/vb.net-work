'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmBookmark

    Private Sub frmBookmark_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmBookmark_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim index As Integer = 1
        For Each x In frmMain.book_mark
            Dim spt As String() = x.Split("\"c)
            Dim strArray = New String() {index, spt(spt.Length - 1), x}
            Dim lvt = New ListViewItem(strArray)
            ListView1.Items.Add(lvt)
            index += 1
        Next
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        For Each i As ListViewItem In ListView1.SelectedItems
            frmMain.expandbyfullpath(i.SubItems(2).Text)
            Exit For
        Next
    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp

        '
        '   Delete가 눌렀다 때어진 경우 선택된 
        '   모든 항목을 리스트 뷰에서 삭제함
        '
        If e.KeyCode = Keys.Delete Then

            '
            '   선택된 모든 항목을 삭제
            '
            For Each i As ListViewItem In ListView1.SelectedItems
                ListView1.Items.Remove(i)
            Next

            '
            '   메인폼에 있는 북마크리스트를 초기화하고
            '   현재 리스트 뷰에 있는 아이템을 삽입함
            '
            frmMain.book_mark.Clear()
            For i As Integer = 0 To ListView1.Items.Count - 1
                frmMain.book_mark.Add(ListView1.Items.Item(i).SubItems(2).Text)
            Next
        End If
    End Sub

End Class