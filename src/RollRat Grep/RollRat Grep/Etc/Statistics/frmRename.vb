'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Text

Public Class frmRename

    Private Sub frmRename_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmRename_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each st As String In frmStatistics.listbox_item_text
            ListBox1.Items.Add(st)
        Next

        search()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    Do While (ListBox1.SelectedItems.Count > 0)
    '        ListBox2.Items.Add(ListBox1.SelectedItem)
    '        ListBox1.Items.Remove(ListBox1.SelectedItem)
    '    Loop
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Do While (ListBox2.SelectedItems.Count > 0)
    '        ListBox1.Items.Add(ListBox2.SelectedItem)
    '        ListBox2.Items.Remove(ListBox2.SelectedItem)
    '    Loop
    'End Sub

    Dim ars As New ArrayList
    Dim ars_pattern As New ArrayList
    Dim pattern_equal As Integer = 0
    Dim now_pattern As String
    Dim chk_lettercount As Boolean = False

    Private Sub search()
        ListBox3.Items.Clear()
        ListBox2.Items.Clear()
        pattern_equal = 0
        ars.Clear()
        ars_pattern.Clear()
        For index As Integer = 0 To ListBox1.Items.Count - 1
            Dim a As String = search_pattern(CStr(ListBox1.Items(index)))
            If ars.Contains(a) Then
                pattern_equal += 1
                Label1.Text = "중복된 패턴이 발견되었습니다.(" & pattern_equal & ")"
                If Not ars_pattern.Contains(a) Then
                    ars_pattern.Add(a)
                    ListBox2.Items.Add(a)
                End If
            Else
                ars.Add(a)
                ListBox3.Items.Add(a)
            End If
        Next
        If pattern_equal = 0 Then
            Label1.Text = "중복된 패턴이 발견되지않았습니다."
        End If
    End Sub

    Private Function is_number(ByVal ch As Char) As Boolean
        Dim i As Integer = AscW(ch)
        If AscW("0"c) <= i AndAlso i <= AscW("9"c) Then
            Return True
        End If
        Return False
    End Function

    Private Function is_deli(ByVal ch As Char) As Boolean
        Dim deli As String = "._-$[]{}()^%!#&"
        For Each ch_t As Char In deli
            If ch_t = ch Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function search_pattern(ByVal target As String) As String
        Dim ret As New StringBuilder
        Dim j As Integer = 0
        Dim p_count As Integer = 0
        For i As Integer = 0 To target.Length - 1
            If is_number(target(i)) Then
                j = 0
                Do
                    i += 1
                    j += 1
                    If i >= target.Length Then
                        Exit Do
                    End If
                Loop While is_number(target(i))
                i -= 1
                If chk_lettercount = True Then
                    ret.Append("숫자(" & j & ")+")
                Else
                    ret.Append("숫자+")
                End If
            ElseIf is_deli(target(i)) Then
                j = 0
                Do
                    i += 1
                    j += 1
                    If i >= target.Length Then
                        Exit Do
                    End If
                Loop While is_deli(target(i))
                i -= 1
                If chk_lettercount = True Then
                    ret.Append("기호(" & j & ")+")
                Else
                    ret.Append("기호+")
                End If
            Else
                j = 0
                Do
                    i += 1
                    j += 1
                    If i >= target.Length Then
                        Exit Do
                    End If
                Loop While Not is_number(target(i)) AndAlso Not is_deli(target(i))
                i -= 1
                If chk_lettercount = True Then
                    ret.Append("문자(" & j & ")+")
                Else
                    ret.Append("문자+")
                End If
            End If
            p_count += 1
            If p_count = NumericUpDown1.Value Then
                Exit For
            End If
        Next
        ret.Remove(ret.Length - 1, 1)
        Return ret.ToString
    End Function

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        CheckedListBox1.Items.Clear()

        Dim addr As String = ListBox2.SelectedItem
        now_pattern = addr
        For Each a As String In addr.Split("+"c)
            CheckedListBox1.Items.Add(a)
        Next
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        CheckedListBox1.Items.Clear()

        Dim addr As String = ListBox3.SelectedItem
        now_pattern = addr
        For Each a As String In addr.Split("+"c)
            CheckedListBox1.Items.Add(a)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rich_count As Integer = 0
        Dim rich_lines As New List(Of String)

        Dim chkd_whats As New List(Of Integer)
        Dim chkd_lines As New List(Of String)

        For Each line As String In RichTextBox1.Lines
            rich_lines.Add(line)
        Next

        For clbsi As Integer = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(clbsi) = True Then
                If rich_lines.Count <= rich_count Then
                    MsgBox("입력값이 부족합니다.", MsgBoxStyle.Critical, "RollRat Grep")
                    Exit Sub
                End If
                chkd_lines.Add(rich_lines(rich_count))
                rich_count += 1
                chkd_whats.Add(clbsi)
            End If
        Next

        '
        '   선택된 항목 없음
        '
        If rich_count = 0 Then
            Exit Sub
        End If

        rich_lines.Clear()

        Dim tagt_items As New List(Of String)

        For index As Integer = 0 To ListBox1.Items.Count - 1
            If search_pattern(CStr(ListBox1.Items(index))) = now_pattern Then
                tagt_items.Add(CStr(ListBox1.Items(index)))
            End If
        Next

        Dim ret As List(Of String) = replace_pattern(chkd_whats, chkd_lines, tagt_items)
        chkd_whats.Clear()
        chkd_lines.Clear()

        '
        '   타깃, 리턴된 배열의 요소 개수 체크
        '
        If ret.Count <> tagt_items.Count Then
            MsgBox("알 수 없는 내부 오류가 발생했습니다.", MsgBoxStyle.Critical, "RollRat Grep")
            Exit Sub
        End If

        '
        '   파일이름 중복체크
        '
        Dim tmp_ret As New List(Of String)
        For Each item As String In ret
            If tmp_ret.Contains(item) Then
                MsgBox("중복되는 파일이름을 발견해 계속 실행할 수 없습니다." & vbCrLf & vbCrLf & item, MsgBoxStyle.Critical, "RollRat Grep")
                Exit Sub
            Else
                tmp_ret.Add(item)
            End If
        Next
        tmp_ret.Clear()

        '
        '   사용자 동의 체크
        '
        Dim maximum_message As Integer = 51
        Dim message_bottom As String = ""
        For i = 0 To tagt_items.Count - 1
            If maximum_message = 0 Then
                Exit For
            End If
            message_bottom += tagt_items(i) & " -> " & ret(i) & vbCrLf
            maximum_message -= 1
        Next

        If MsgBox("다음 원래(왼쪽)파일이름들이 오른쪽과 같이 바뀌는 것에 동의하십니까?" & vbCrLf & vbCrLf & message_bottom, _
                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "RollRat Grep") = MsgBoxResult.Yes Then
            '
            '   이름 바꾸기 실행
            '
            For i = 0 To tagt_items.Count - 1
                My.Computer.FileSystem.RenameFile(frmStatistics.listbox_folder_addr & "\" & tagt_items(i), ret(i))
            Next
            MsgBox("요청하신 작업이 완료되었습니다. 원활한 작업을 위해 새로고침하십시오.", MsgBoxStyle.Information, "RollRat Grep")
            Me.Close()
        End If

    End Sub

    Private Function replace_pattern(ByVal indexs As List(Of Integer), _
                   ByVal lines As List(Of String), ByVal targets As List(Of String)) As List(Of String)
        Dim ret As New List(Of String)
        For Each target As String In targets
            Dim count As Integer = 0
            Dim line_c As Integer = 0
            Dim j As Integer = 0
            Dim replace_string As String = ""
            Dim skip As Boolean = False
            For i As Integer = 0 To target.Length - 1
                If indexs.Contains(count) Then
                    skip = True
                    replace_string += lines(line_c)
                    line_c += 1
                End If
                If is_number(target(i)) Then
                    Do
                        If Not skip Then replace_string += target(i)
                        i += 1
                        If i >= target.Length Then Exit Do
                    Loop While is_number(target(i))
                    i -= 1
                ElseIf is_deli(target(i)) Then
                    Do
                        If Not skip Then replace_string += target(i)
                        i += 1
                        If i >= target.Length Then Exit Do
                    Loop While is_deli(target(i))
                    i -= 1
                Else
                    Do
                        If Not skip Then replace_string += target(i)
                        i += 1
                        If i >= target.Length Then Exit Do
                    Loop While Not is_number(target(i)) AndAlso Not is_deli(target(i))
                    i -= 1
                End If
                skip = False
                count += 1
            Next
            ret.Add(replace_string)
        Next
        Return ret
    End Function

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim a As String = search_pattern(CStr(ListBox1.SelectedItem))
        For i As Integer = 0 To ListBox3.Items.Count - 1
            If ListBox3.Items.Item(i) = a Then
                ListBox3.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        chk_lettercount = CheckBox1.Checked
        search()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        search()
    End Sub

End Class