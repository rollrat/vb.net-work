'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text
Imports System.Security.Principal

Public Class frmMain

    Dim ars_pattern As New ArrayList
    Dim ars_overlap_pattern As New ArrayList
    Dim files_extension As New ArrayList

    Dim files As ReadOnlyCollection(Of String)
    Dim last_listing_path As String

    Dim folder_name As String

    Public Shared chk_lettercount As Boolean = False
    Public Shared chk_numasletter As Boolean = False
    Public Shared chk_spaceletter As Boolean = True
    Public Shared deli_c As String = "._+-=$[]{}()^%!#&"

    Public Shared preview_forward As List(Of String)
    Public Shared preview_return As List(Of String)

    Dim now_pattern As String

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WriteLog("----------Program End----------", False)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
        If isElevated Then
            MsgBox("이 프로그램은 관리자권한으로 실행할 수 없습니다.", MsgBoxStyle.Critical, "RollRat Grep")
            End
        End If
        WriteLog("----------Program Start----------", False)
        Me.Text += Version.VersionText
    End Sub

    Private Sub ListView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If filePaths.Length <> 1 Then
                MsgBox("하나의 폴더만 끌어오십시오.", MsgBoxStyle.Critical, "RollRat Rename")
                WriteLog("<-- Drag Only One --> [DragDrop];filePaths=" & filePaths.Length, True, err_DragOnlyOne)
            Else
                Listing_File(CType(e.Data.GetData(DataFormats.FileDrop), String())(0))
            End If
        End If
    End Sub

    Private Sub Listing_File(ByVal pathstr As String)
        Dim filePaths As String = pathstr
        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(pathstr)
        If folderExists = True Then
            last_listing_path = pathstr
            folder_name = pathstr
            Label2.Text = pathstr
            files = My.Computer.FileSystem.GetFiles(pathstr, FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            ListBox2.Items.Clear()
            CheckedListBox1.Items.Clear()
            ListBox1.Items.Clear()
            RichTextBox1.Text = ""
            search()
            ListView1.Items.Clear()
            For Each x In files
                Dim LI As ListViewItem
                LI = ListView1.Items.Add(New ListViewItem(New String() {Path.GetFileName(x)}))
                LI.StateImageIndex = 0
            Next
            WriteLog("Drag and Drop. [ListViewDragDrop] ;files=" & files.Count)
            WriteLog("   - addr=" & pathstr)
        End If
    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        If e.KeyCode = Keys.Delete Then
            For Each i As ListViewItem In ListView1.SelectedItems
                ListView1.Items.Remove(i)
            Next
        End If
    End Sub

    Private Sub search()
        If Not files Is Nothing Then
            ListBox1.Items.Clear()
            ars_pattern.Clear()
            ars_overlap_pattern.Clear()
            ComboBox1.Items.Clear()
            files_extension.Clear()
            ComboBox1.Items.Add("모두")
            For Each addr As String In files
                Dim file_name As String = Path.GetFileName(addr)
                Dim extension As String = Path.GetExtension(addr)
                Dim pattern As String = search_pattern(file_name)
                If ars_pattern.Contains(pattern) Then
                    If Not ars_overlap_pattern.Contains(pattern) Then
                        ars_overlap_pattern.Add(pattern)
                    End If
                Else
                    ars_pattern.Add(pattern)
                End If
                If Not files_extension.Contains(extension) Then
                    files_extension.Add(extension)
                End If
            Next
            For Each pattern As String In ars_pattern
                If ars_overlap_pattern.Contains(pattern) Then
                    ListBox1.Items.Add("★" & pattern)
                Else
                    ListBox1.Items.Add(pattern)
                End If
            Next
            For Each ext In files_extension
                ComboBox1.Items.Add(ext)
            Next
        End If
    End Sub

    Public Shared Function is_number(ByVal ch As Char) As Boolean
        Dim i As Integer = AscW(ch)
        If chk_numasletter Then
            Return False
        End If
        If AscW("0"c) <= i AndAlso i <= AscW("9"c) Then
            Return True
        End If
        Return False
    End Function

    Public Shared Function is_deli(ByVal ch As Char) As Boolean
        Dim deli As String = deli_c
        If Not chk_spaceletter Then
            If ch = " "c Then
                Return True
            End If
        End If
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        chk_lettercount = CheckBox1.Checked
        search()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        chk_numasletter = CheckBox2.Checked
        search()
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        chk_spaceletter = CheckBox3.Checked
        search()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        search()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        deli_c = TextBox1.Text
        search()
    End Sub

    Function UnCryption(ByRef convert As String())
        For i As Integer = 0 To convert.Length() - 1
            convert(i) -= (3 ^ i) * (i Mod 15)
            If (convert(i) < 0) Then
                convert(i) += 64
            End If
        Next
    End Function
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        CheckedListBox1.Items.Clear()
        ListBox2.Items.Clear()

        If Not ListBox1.SelectedItem Is Nothing Then
            Dim addr As String = ListBox1.SelectedItem
            now_pattern = addr
            For Each a As String In addr.Replace("★"c, "").Split("+"c)
                CheckedListBox1.Items.Add(a)
            Next
            For Each a As ListViewItem In ListView1.Items
                If search_pattern(a.Text) = addr.Replace("★"c, "") Then
                    ListBox2.Items.Add(a.Text)
                End If
            Next
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim sii As String
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            sii = search_pattern(ListView1.SelectedItems.Item(i).Text)
            If ars_overlap_pattern.Contains(sii) Then
                sii = "★" & sii
            End If
            For j As Integer = 0 To ListBox1.Items.Count - 1
                If ListBox1.Items.Item(j) = sii Then
                    ListBox1.SelectedIndex = j
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rich_count As Integer = 0
        Dim rich_lines As New List(Of String)

        Dim chkd_whats As New List(Of Integer)
        Dim chkd_lines As New List(Of String)

        deli_c = TextBox1.Text

        For Each line As String In RichTextBox1.Lines
            rich_lines.Add(line)
        Next

        For clbsi As Integer = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(clbsi) = True Then
                If rich_lines.Count <= rich_count Then
                    MsgBox("입력값이 부족합니다.", MsgBoxStyle.Critical, "RollRat Rename")
                    WriteLog("<-- Too low input --> [RenameButton];rich_lines=" & rich_lines.Count & ";rich_count=" & rich_count, True, err_Input_size_low)
                    Exit Sub
                End If
                chkd_lines.Add(rich_lines(rich_count))
                rich_count += 1
                chkd_whats.Add(clbsi)
            End If
        Next

        force_end = False

        '
        '   선택된 항목 없음
        '
        If rich_count = 0 Then
            Exit Sub
        End If

        rich_lines.Clear()

        Dim tagt_items As New List(Of String)

        For index As Integer = 0 To ListBox2.Items.Count - 1
            'If search_pattern(CStr(ListBox1.Items(index))) = now_pattern Then
            tagt_items.Add(CStr(ListBox2.Items(index)))
            'End If
        Next

        Dim ret As List(Of String) = replace_pattern(chkd_whats, chkd_lines, tagt_items)
        chkd_whats.Clear()
        chkd_lines.Clear()
        If force_end = True Then
            ret.Clear()
            Exit Sub
        End If

        '
        '   타깃, 리턴된 배열의 요소 개수 체크
        '
        If ret.Count <> tagt_items.Count Then
            MsgBox("알 수 없는 내부 오류가 발생했습니다.", MsgBoxStyle.Critical, "RollRat Rename")
            WriteLog("<-- None --> [RenameButton];ret=" & ret.Count & ";tagt_items=" & tagt_items.Count, True, err_None)
            Exit Sub
        End If

        '
        '   파일이름 중복체크
        '
        Dim tmp_ret As New List(Of String)
        For Each item As String In ret
            If tmp_ret.Contains(item) Then
                MsgBox("중복되는 파일이름을 발견해 계속 실행할 수 없습니다. 자세한 내용은 미리보기를 참고하십시오." & vbCrLf & vbCrLf & item, MsgBoxStyle.Critical, "RollRat Rename")
                WriteLog("<-- Overlapped Error --> [RenameButton];" & item, True, err_Overlapped_Text)
                Exit Sub
            Else
                tmp_ret.Add(item)
            End If
        Next
        tmp_ret.Clear()

        '
        '   파일이름에서 사용 불가능한 문자 검색
        '
        For Each item As String In ret
            If Check_Irregular(item) Then
                MsgBox("파일이름으로 사용할 수 없는 문자가 발견되었습니다." & vbCrLf & _
                       "대상 : " & item, MsgBoxStyle.Critical, "RollRat Grep")
                WriteLog("<-- Irregular Error --> [RenameButton];item=" & item, True, err_Irregular_Text)
                Exit Sub
            End If
        Next

        '
        '   사용자 동의 체크
        '
        Dim maximum_message As Integer = 25
        Dim message_bottom As String = ""
        If tagt_items.Count < maximum_message Then
            For i = 0 To tagt_items.Count - 1
                If maximum_message = 0 Then
                    Exit For
                End If
                message_bottom += tagt_items(i) & " -> " & ret(i) & vbCrLf
                maximum_message -= 1
            Next
        Else

            '
            '   앞의 12개의 메시지를, 뒤에 12개의 
            '   메시지를 메시지창에 보여줍니다.
            '
            maximum_message = 12
            For i = 0 To tagt_items.Count - 1
                If maximum_message = 0 Then
                    Exit For
                End If
                message_bottom += tagt_items(i) & " -> " & ret(i) & vbCrLf
                maximum_message -= 1
            Next
            message_bottom += vbTab & "." & vbCrLf & vbTab & "." & vbCrLf & vbTab & "." & vbCrLf
            For i = tagt_items.Count - 12 To tagt_items.Count - 1
                message_bottom += tagt_items(i) & " -> " & ret(i) & vbCrLf
            Next
        End If

        If MsgBox("다음 원래(왼쪽)이름들이 오른쪽과 같이 바뀌는 것에 동의하십니까?" & vbCrLf & vbCrLf & message_bottom, _
                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "RollRat Rename") = MsgBoxResult.Yes Then

            Dim str_str As New List(Of String)

            '
            '   이름 바꾸기 실행 & 로그 작성
            '
            Try
                For i = 0 To tagt_items.Count - 1
                    My.Computer.FileSystem.RenameFile(folder_name & "\" & tagt_items(i), ret(i))
                    str_str.Add(vbTab & tagt_items(i) & vbTab & vbTab & "->" & vbTab & vbTab & ret(i) & vbTab & MD5Str(tagt_items(i)) & " " & MD5Str(ret(i)))
                Next
            Catch ex As Exception
                MsgBox("작업에 오류가 생겨 작동을 중지하였습니다. 자세한 사항은 로그기록을 참조하십시오.", MsgBoxStyle.Critical, "RollRat Rename")
                WriteLog("Aborted the requested operation. [RenameButton]", True, err_None)
                WriteLog("  ErrMsg:" & ex.Message & vbCrLf & "  Success : " & str_str.Count)
                If str_str.Count <> 0 Then
                    WriteLog(" ------- Successful Rename List Begin -------")
                    WriteLines(str_str.ToArray())
                    WriteLog(" ------- Successful Rename List End -------")
                End If
                Exit Sub
            End Try

            MsgBox("요청하신 작업이 완료되었습니다.", MsgBoxStyle.Information, "RollRat Rename")
            Listing_File(last_listing_path)
            WriteLog("   - addr=" & last_listing_path)
            WriteLines(str_str.ToArray())
            WriteLog("Complete the requested operation. [RenameButton]")
        End If

    End Sub

    Public Shared Function Check_Irregular(ByVal stritem As String) As Boolean
        Dim irregular As String = "\/:*?""<>|"

        For Each ch As Char In stritem
            For Each ch_t As Char In irregular
                If ch_t = ch Then
                    Return True
                End If
            Next
        Next

        Return False
    End Function

    Private Sub ListBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles ListBox2.KeyUp
        If e.KeyCode = Keys.Delete Then
            ListBox2.Items.Remove(ListBox2.SelectedItem)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ListBox2.Items.Count = 0 Then
            MsgBox("바꿀 패턴을 먼저 선택하십시오.", MsgBoxStyle.Critical, "RollRat Rename")
            WriteLog("<-- Choose First --> [OverlapProccessButton];", True, err_ChooseFirst)
            Exit Sub
        End If

        If FolderBrowserDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim folder_addr As String = FolderBrowserDialog1.SelectedPath
            Dim files = My.Computer.FileSystem.GetFiles(folder_addr, FileIO.SearchOption.SearchTopLevelOnly, "*.*")

            Dim s_tagt_items As New List(Of String)
            Dim s_overlap_int As List(Of Integer) = New List(Of Integer)

            '
            '   패턴 중복 검사
            '
            Dim first_pattern As String = Nothing
            Dim first_pattern_already As Boolean = False

            For Each x In files
                If first_pattern_already Then
                    If Not first_pattern = search_pattern(Path.GetFileNameWithoutExtension(x)) Then
                        MsgBox("동일하지 않은 패턴을 발견하여 계속 실행할 수 없습니다." & vbCrLf & _
                               "대상:" & x & vbCrLf & _
                               "패턴:" & first_pattern, MsgBoxStyle.Critical, "RollRat Rename")
                        WriteLog("<-- Not found equally pattern --> [OverlapProccessButton];", True, err_NotFoundPattern)
                        Exit Sub
                    End If
                Else
                    first_pattern_already = True
                    first_pattern = search_pattern(Path.GetFileNameWithoutExtension(x))
                End If
            Next

            For Each x In files
                s_tagt_items.Add(Path.GetFileNameWithoutExtension(x))
            Next

            find_overlap(s_tagt_items, s_overlap_int)

            '
            '   두 구역으로 나누기
            '
            Dim s_first As String = ""
            Dim s_last As String = ""
            Dim monotone As Integer = 0
            Dim monotone_bool As Boolean = False
            Dim strpat As List(Of String) = split_pattern(s_tagt_items(0))
            For Each i As Integer In s_overlap_int
                If i <> monotone Then
                    monotone_bool = True
                    monotone = i
                End If
                monotone += 1
                If monotone_bool Then
                    s_last += strpat(i)
                Else
                    s_first += strpat(i)
                End If
            Next

            WriteLog("Division 2 Area. [OverlapProccessButton] ;first=" & s_first & ";last=" & s_last)

            Dim extension As String = ""

            '
            '   현재 이름 분석
            '
            Dim tagt_items As New List(Of String)
            Dim overlap_int As List(Of Integer)
            Dim disoverlap_int As List(Of Integer)
            Dim max_value As Integer

            max_value = CheckedListBox1.Items.Count

            For index As Integer = 0 To ListBox2.Items.Count - 1
                tagt_items.Add(CStr(ListBox2.Items(index)))
            Next

            extension = Path.GetExtension(folder_addr & "\" & ListBox2.Items(0))

            overlap_int = New List(Of Integer)
            disoverlap_int = New List(Of Integer)

            find_overlap(tagt_items, overlap_int)

            For i As Integer = 0 To max_value - 1
                If Not overlap_int.Contains(i) Then
                    disoverlap_int.Add(i)
                End If
            Next

            If disoverlap_int.Count <> 1 Then
                MsgBox("disoverlap의 인수가 적절하지 않습니다. 이 오류는 중복된 이름이 검사되지 " & _
                       "않았을 때나 중복된 중복부분이 감지되었을때 실행됩니다.", MsgBoxStyle.Critical, "RollRat Rename")
                WriteLog("<-- Disoverlap Counting Error --> [OverlapProccessButton];disoverlap_int" & disoverlap_int.Count, True, err_Common_size)
                Exit Sub
            End If

            '
            '   변경된 이름 확인
            '
            Dim result As New List(Of String)
            For Each iss As String In tagt_items
                result.Add(s_first & split_pattern(iss)(disoverlap_int(0)) & s_last & extension)
            Next

            '
            '   사용자 동의 체크
            '
            Dim maximum_message As Integer = 25
            Dim message_bottom As String = ""
            If tagt_items.Count < maximum_message Then
                For i = 0 To tagt_items.Count - 1
                    If maximum_message = 0 Then
                        Exit For
                    End If
                    message_bottom += tagt_items(i) & " -> " & result(i) & vbCrLf
                    maximum_message -= 1
                Next
            Else

                '
                '   앞의 12개의 메시지를, 뒤에 12개의 
                '   메시지를 메시지창에 보여줍니다.
                '
                maximum_message = 12
                For i = 0 To tagt_items.Count - 1
                    If maximum_message = 0 Then
                        Exit For
                    End If
                    message_bottom += tagt_items(i) & " -> " & result(i) & vbCrLf
                    maximum_message -= 1
                Next
                message_bottom += vbTab & "." & vbCrLf & vbTab & "." & vbCrLf & vbTab & "." & vbCrLf
                For i = tagt_items.Count - 12 To tagt_items.Count - 1
                    message_bottom += tagt_items(i) & " -> " & result(i) & vbCrLf
                Next
            End If

            If MsgBox("다음 원래(왼쪽)이름들이 오른쪽과 같이 바뀌는 것에 동의하십니까?" & vbCrLf & vbCrLf & message_bottom, _
                      MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "RollRat Rename") = MsgBoxResult.Yes Then

                Dim str_str As New List(Of String)

                '
                '   이름 바꾸기 실행 & 로그 작성
                '
                Try
                    For i = 0 To tagt_items.Count - 1
                        My.Computer.FileSystem.RenameFile(folder_name & "\" & tagt_items(i), result(i))
                        str_str.Add(vbTab & tagt_items(i) & vbTab & vbTab & "->" & vbTab & vbTab & result(i) & vbTab & MD5Str(tagt_items(i)) & " " & MD5Str(result(i)))
                    Next
                Catch ex As Exception
                    MsgBox("작업에 오류가 생겨 작동을 중지하였습니다. 자세한 사항은 로그기록을 참조하십시오.", MsgBoxStyle.Critical, "RollRat Rename")
                    WriteLog("Aborted the requested operation. [RenameButton]", True, err_None)
                    WriteLog("  ErrMsg:" & ex.Message & vbCrLf & "  Success : " & str_str.Count)
                    If str_str.Count <> 0 Then
                        WriteLog(" ------- Successful Rename List Begin -------")
                        WriteLines(str_str.ToArray())
                        WriteLog(" ------- Successful Rename List End -------")
                    End If
                    Exit Sub
                End Try

                MsgBox("요청하신 작업이 완료되었습니다.", MsgBoxStyle.Information, "RollRat Rename")
                Listing_File(last_listing_path)
                WriteLog("   - addr=" & last_listing_path)
                WriteLines(str_str.ToArray())
                WriteLog("Complete the requested operation. [RenameButton]")
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If files_extension.Contains(ComboBox1.Text) Then
            ListView1.Items.Clear()
            For Each x In files
                If Path.GetExtension(x) = ComboBox1.Text Then
                    Dim LI As ListViewItem
                    LI = ListView1.Items.Add(New ListViewItem(New String() {Path.GetFileName(x)}))
                    LI.StateImageIndex = 0
                End If
            Next
            WriteLog("Choosing extension. [ExtensionBox] ;items=" & ListView1.Items.Count & ";text=" & ComboBox1.Text)
        ElseIf ComboBox1.Text = "모두" Then
            ListView1.Items.Clear()
            For Each x In files
                Dim LI As ListViewItem
                LI = ListView1.Items.Add(New ListViewItem(New String() {Path.GetFileName(x)}))
                LI.StateImageIndex = 0
            Next
            WriteLog("Choosing extension. [ExtensionBox] ;items=" & ListView1.Items.Count & ";text=" & ComboBox1.Text)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tagt_items As New List(Of String)
        Dim overlap_int As List(Of Integer)
        Dim max_value As Integer

        max_value = CheckedListBox1.Items.Count

        For index As Integer = 0 To ListBox2.Items.Count - 1
            tagt_items.Add(CStr(ListBox2.Items(index)))
        Next

        overlap_int = New List(Of Integer)

        find_overlap(tagt_items, overlap_int)

        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next
        For Each i As Integer In overlap_int
            CheckedListBox1.SetItemChecked(i, True)
        Next

        WriteLog("Complete find. [FindOverlapButton] ;max_value=" & max_value & ";tagt_items=" & tagt_items.Count & ";overlap=" & overlap_int.Count)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim tagt_items As New List(Of String)
        Dim overlap_int As List(Of Integer)
        Dim disoverlap_int As List(Of Integer)
        Dim max_value As Integer

        max_value = CheckedListBox1.Items.Count

        For index As Integer = 0 To ListBox2.Items.Count - 1
            tagt_items.Add(CStr(ListBox2.Items(index)))
        Next

        overlap_int = New List(Of Integer)
        disoverlap_int = New List(Of Integer)

        find_overlap(tagt_items, overlap_int)

        For i As Integer = 0 To max_value - 1
            If Not overlap_int.Contains(i) Then
                disoverlap_int.Add(i)
            End If
        Next

        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next
        For Each i As Integer In disoverlap_int
            CheckedListBox1.SetItemChecked(i, True)
        Next

        WriteLog("Complete find. [FindDisoverlapButton] ;max_value=" & max_value & ";tagt_items=" & tagt_items.Count & ";overlap=" & overlap_int.Count & ";disoverlap=" & disoverlap_int.Count)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim rich_count As Integer = 0
        Dim rich_lines As New List(Of String)

        Dim chkd_whats As New List(Of Integer)
        Dim chkd_lines As New List(Of String)

        deli_c = TextBox1.Text

        For Each line As String In RichTextBox1.Lines
            rich_lines.Add(line)
        Next

        For clbsi As Integer = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(clbsi) = True Then
                If rich_lines.Count <= rich_count Then
                    MsgBox("입력값이 부족합니다.", MsgBoxStyle.Critical, "RollRat Rename")
                    WriteLog("<-- Too low input --> [PreviewButton];rich_lines=" & rich_lines.Count & ";rich_count=" & rich_count, True, err_Input_size_low)
                    Exit Sub
                End If
                chkd_lines.Add(rich_lines(rich_count))
                rich_count += 1
                chkd_whats.Add(clbsi)
            End If
        Next

        force_end = False

        '
        '   선택된 항목 없음
        '
        If rich_count = 0 Then
            Exit Sub
        End If

        rich_lines.Clear()

        preview_forward = New List(Of String)

        For index As Integer = 0 To ListBox2.Items.Count - 1
            'If search_pattern(CStr(ListBox1.Items(index))) = now_pattern Then
            preview_forward.Add(CStr(ListBox2.Items(index)))
            'End If
        Next

        preview_return = replace_pattern(chkd_whats, chkd_lines, preview_forward)
        chkd_whats.Clear()
        chkd_lines.Clear()
        If force_end = True Then
            preview_return.Clear()
            Exit Sub
        End If

        '
        '   타깃, 리턴된 배열의 요소 개수 체크
        '
        If preview_return.Count <> preview_forward.Count Then
            MsgBox("알 수 없는 내부 오류가 발생했습니다.", MsgBoxStyle.Critical, "RollRat Rename")
            WriteLog("<-- None --> [PreviewButton];preview_return=" & preview_return.Count & ";preview_forward=" & preview_forward.Count, True, err_None)
            Exit Sub
        End If

        WriteLog("Complete preview. [PreviewButton]")
        frmPreview.Show()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ListView1.Items.Clear()
        If Not files Is Nothing Then
            For Each x In files
                If Path.GetFileName(x).Contains(TextBox2.Text) Then
                    Dim LI As ListViewItem
                    LI = ListView1.Items.Add(New ListViewItem(New String() {Path.GetFileName(x)}))
                    LI.StateImageIndex = 0
                End If
            Next
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ListView1.Items.Clear()
        If Not files Is Nothing Then
            For Each x In files
                Dim LI As ListViewItem
                LI = ListView1.Items.Add(New ListViewItem(New String() {Path.GetFileName(x)}))
                LI.StateImageIndex = 0
            Next
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim list_items As New List(Of String)
        For i As Integer = 0 To ListView1.Items.Count - 1
            list_items.Add(ListView1.Items(i).Text)
        Next
        ListView1.Items.Clear()
        For i As Integer = list_items.Count - 1 To 0 Step -1
            ListView1.Items.Add(list_items(i))
        Next
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim filenames As New List(Of String)
        Dim extensions As New List(Of String)
        For i As Integer = 0 To ListView1.Items.Count - 1
            filenames.Add(Path.GetFileNameWithoutExtension(ListView1.Items(i).Text))
            extensions.Add(Path.GetExtension(ListView1.Items(i).Text))
        Next
        Dim filenames_array As String() = filenames.ToArray
        Dim extensions_array As String() = extensions.ToArray
        Array.Sort(extensions_array, filenames_array)
        ListView1.Items.Clear()
        For i As Integer = 0 To filenames_array.Count - 1
            ListView1.Items.Add(filenames_array(i) & extensions_array(i))
        Next
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        frmRecovery.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim orderedFiles = ((New DirectoryInfo(folder_name)).GetFileSystemInfos()).OrderBy(Function(f) f.LastWriteTime)
        ListView1.Items.Clear()
        For Each i As FileSystemInfo In orderedFiles
            Dim LI As ListViewItem
            LI = ListView1.Items.Add(New ListViewItem(New String() {Path.GetFileName(i.FullName)}))
            LI.StateImageIndex = 0
        Next
    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        Dim val As Integer
        If e.NewValue = CheckState.Checked Then
            val = CheckedListBox1.CheckedItems.Count + 1
        Else
            val = CheckedListBox1.CheckedItems.Count - 1
        End If
        Label11.Text = val & " 개 선택됨"
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Label12.Text = RichTextBox1.Lines.Length & " 줄 쓰여짐"
    End Sub

End Class