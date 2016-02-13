'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices

Public Class frmDistortion

    Dim list_matched As List(Of String)
    Dim list_line As List(Of Integer)
    Dim list_addr As List(Of String)

    Dim list_keyword As String() = {"if", "return", "else"}

    Private Function BackGet(ByVal split_target As String) As String()
        Dim ret As New List(Of String)
        Dim st As New StringBuilder
        Dim st_count As Integer = 0
        Dim back_splitter As Integer = split_target.Length - 2
        For i As Integer = back_splitter To 1 Step -1
            If split_target(i) = "|"c Then
                back_splitter = i + 1
                Exit For
            End If
        Next
        For j As Integer = back_splitter To split_target.Length - 2
            st.Append(split_target(j))
        Next
        ret.Add(st.ToString)
        st.Clear()
        Dim front_splitter As Integer = 0
        For i As Integer = back_splitter - 2 To 1 Step -1
            If split_target(i) = "|"c Then
                front_splitter = i + 1
                Exit For
            End If
        Next
        For j As Integer = front_splitter To back_splitter - 2
            st.Append(split_target(j))
        Next
        ret.Add(st.ToString)
        st.Clear()
        For j As Integer = 1 To front_splitter - 2
            st.Append(split_target(j))
        Next
        ret.Add(st.ToString)
        Return ret.ToArray
    End Function

    Private Sub bOpen_Click(sender As Object, e As EventArgs) Handles bOpen.Click
        Dim f = OpenFileDialog1.ShowDialog()
        If f = DialogResult.OK Then
            Dim srt As StreamReader = New StreamReader(OpenFileDialog1.FileName, Encoding.UTF8)
            Dim linetext As String
            Label2.Text = OpenFileDialog1.FileName
            list_matched = New List(Of String)
            list_line = New List(Of Integer)
            list_addr = New List(Of String)
            bSave.Enabled = True
            bSearch.Enabled = True
            bReference.Enabled = True
            tbSearch.Enabled = True
            Do
                linetext = srt.ReadLine()

                If linetext = Nothing Then
                    If srt.EndOfStream Then
                        Exit Do
                    End If
                End If

                If linetext <> "" AndAlso linetext.Contains("|"c) AndAlso Not linetext.StartsWith("//") Then
                    Dim splits As String() = BackGet(linetext)
                    If IsNumeric(splits(1)) Then
                        list_matched.Add(splits(2))
                        list_line.Add(splits(1))
                        list_addr.Add(splits(0))
                    End If
                End If
            Loop

            srt.Close()
        End If
    End Sub

    Private Sub bSearch_Click(sender As Object, e As EventArgs) Handles bSearch.Click
        Dim excludeKeyword As Boolean = tbOption.Text.Contains("ExcludeCKeyWord")
        lvResult.Items.Clear()
        Dim splits As String() = tbSearch.Text.Split(" "c)
        For i As Integer = 0 To list_matched.Count - 1

            Dim chk As Boolean = False
            For j = 0 To splits.Length - 1
                If excludeKeyword Then
                    If list_keyword.Contains(list_matched(i).ToLower) Then
                        Exit For
                    End If
                End If
                If cbRegex.Checked Then
                    Dim match2 As System.Text.RegularExpressions.Match
                    match2 = System.Text.RegularExpressions.Regex.Match(list_matched(i), splits(j), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    If Not match2.Success Then
                        Exit For
                    End If
                Else
                    If Not list_matched(i).IndexOf(splits(j), 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                        Exit For
                    End If
                End If

                If j = splits.Length - 1 Then
                    chk = True
                End If
            Next

            If chk Then
                lvResult.Items.Add(list_matched(i) & "<" & list_line(i) & "," & Path.GetFileName(list_addr(i)) & ">|" & i)
            End If

        Next
    End Sub

    Private Sub lvResult_DoubleClick(sender As Object, e As EventArgs) Handles lvResult.DoubleClick
        If Not lvResult.SelectedItem Is Nothing Then
            Dim xis As String = lvResult.SelectedItem.ToString
            Dim xis_offset As Integer = xis.Split("|"c)(1)
            Dim selected_filename As String
            selected_filename = list_addr(xis_offset)
            Process.Start(selected_filename)
        End If
    End Sub

    Private Sub lvResult_KeyUp(sender As Object, e As KeyEventArgs) Handles lvResult.KeyUp
        If e.KeyCode = Keys.Delete Then
            If Not lvResult.SelectedItem Is Nothing Then
                Dim xis_text As String = lvResult.SelectedItem.ToString.Split("<"c)(0)
                Dim list_pos As New List(Of Integer)

                '
                '   Reference 상황을 고려해 리스트 아이템이 정렬되지 않았다고 가정함
                '
                For i As Integer = 0 To lvResult.Items.Count - 1
                    If lvResult.Items(i).ToString.Contains(xis_text) Then

                        '
                        '   리스트 아이템을 한 개씩 제거할 때마다 한 칸씩 요소가 뒤로 밀려나게 된다.
                        '
                        list_pos.Add(i - list_pos.Count)
                    End If
                Next
                For Each pos As Integer In list_pos
                    lvResult.Items.Remove(lvResult.Items(pos))
                Next
            End If
        End If
    End Sub

    Private Sub lvResult_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvResult.SelectedIndexChanged
        If Not lvResult.SelectedItem Is Nothing Then
            Dim xis As String = lvResult.SelectedItem.ToString
            Dim xis_split As String() = xis.Split("|"c)
            Dim xis_offset As Integer = xis_split(xis_split.Length - 1)
            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(list_addr(xis_offset))
            If fileExists Then
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(list_addr(xis_offset))
                rtbCode.Text = fileContents

                '
                '   텍스트박스 스크롤을 위한 작업 ( 위치 찾아가기 )
                '   Lines로 가져오는 것은 너무 느림
                '
                Dim offset As Integer = -1
                Dim srt As StreamReader = New StreamReader(list_addr(xis_offset), Encoding.Default)
                For i As Integer = 0 To list_line(xis_offset) - 1
                    offset += srt.ReadLine().Length + 1
                Next
                srt.Close()

                rtbCode.SelectionStart = offset
                rtbCode.ScrollToCaret()
            End If
        End If
    End Sub

    Private Sub bReference_Click(sender As Object, e As EventArgs) Handles bReference.Click
        If Not rtbCode.Text = "" AndAlso Not lvResult.SelectedItem Is Nothing Then
            Dim xis As String = lvResult.SelectedItem.ToString
            Dim xis_offset As Integer = xis.Split("|"c)(1)
            Dim selected_filename As String = list_addr(xis_offset)
            Dim srt As StreamReader = New StreamReader(selected_filename, Encoding.Default)
            Dim linetext As String
            Dim line As Integer = 0
            Dim count As Integer = 0
            Dim startalreay As Boolean = False
            lvResult.Items.Clear()

            '
            '   Inverse Hash 루틴
            '
            Do
                linetext = srt.ReadLine()

                If linetext = Nothing Then
                    If srt.EndOfStream Then
                        Exit Do
                    End If
                End If

                line += 1

                Dim match2 As System.Text.RegularExpressions.Match
                Dim origin As String = linetext

                '
                '   함수선언이나 호출, define구문, define구문의 요소구문 등이 있는지의 여부를 찾음
                '
                match2 = System.Text.RegularExpressions.Regex.Match(linetext, "\w+(?=\s*\()", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

                If match2.Success Then

                    '
                    '   파일이름과 라인, 구문을 비교하여 오프셋을 찾음(구문과 같이 찾을 
                    '   경우 같은 라인내에서 많은 파일이름을 비교해가며 찾을 필요가 없고,
                    '   세 가지 모두를 비교하는 것이 이론상 더 빠름)
                    '
                    Dim i As Integer = find_offset(selected_filename, line, match2.Captures(0).ToString)
                    If i <> -1 Then
                        lvResult.Items.Add(list_matched(i) & "<" & list_line(i) & "," & Path.GetFileName(list_addr(i)) & ">|" & i)
                    End If
                End If
            Loop
            srt.Close()
        End If
    End Sub

    Private Function find_offset(ByVal filename As String, ByVal count As Integer, ByVal syntax As String) As Integer
        For i As Integer = 0 To list_addr.Count - 1
            If list_line(i) = count Then ' 불일치 확률이 제일높다.
                If list_matched(i) = syntax Then
                    If list_addr(i) = filename Then
                        Return i
                    End If
                End If
            End If
        Next

        '
        '   못 찾았는데 찾았다고 뜨면 안되잖아
        '
        Return -1
    End Function

    Private Sub bSave_Click(sender As Object, e As EventArgs) Handles bSave.Click
        Dim str As New StringBuilder
        For Each s As String In lvResult.Items
            str.Append(s & vbCrLf)
        Next

        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(Application.StartupPath() & "\selected.log")
        If fileExists = True Then
            If MsgBox("이미 파일이 있습니다. 덮어쓰시겠습니까?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath() & "\selected.log", _
                        FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Else
                Exit Sub
            End If
        End If
        My.Computer.FileSystem.WriteAllText(Application.StartupPath() & "\selected.log", str.ToString, True)
    End Sub

    Private Sub RunFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunFileToolStripMenuItem.Click
        If Not lvResult.SelectedItem Is Nothing Then
            Dim xis As String = lvResult.SelectedItem.ToString
            Dim xis_offset As Integer = xis.Split("|"c)(1)
            Dim selected_filename As String
            selected_filename = list_addr(xis_offset)
            Process.Start(selected_filename)
        End If
    End Sub




    '//////////////////////////////////////////////////////////////////
    '
    '   Processing command line ( Text Intellisense )
    '
    '   Deliberate string find helper
    '   with RollRat New Distortion Viewer
    '
    '//////////////////////////////////////////////////////////////////

    Dim KeyWordList As New List(Of String)({"FrontMatch?", "FrontMatchRegex?", _
            "ExtensionMatch?", "ExcludeCKeyWord!", "SetMaxNumberOfText?"})
    Dim GlobalPosition As Integer
    Dim GlobalText As String
    Dim SelectedPart As Boolean = False
    Dim MustPutLock As Boolean = False

    '
    '   Get text position measure by [pixel] from relative letter position
    '
    Function GetCaretWidthFromtbOption(ByVal pos As Integer)
        Return TextRenderer.MeasureText(tbOption.Text.Substring(0, pos), tbOption.Font).Width
    End Function

    Private Sub tbOption_KeyDown(sender As Object, e As KeyEventArgs) Handles tbOption.KeyDown

        If lvIntellisense.Visible = True Then

            '
            '   ListBox Index Set
            '
            If e.KeyCode = Keys.Down Then
                lvIntellisense.SelectedIndex = 0
                lvIntellisense.Focus()
                e.Handled = True
            ElseIf e.KeyCode = Keys.Up Then
                lvIntellisense.SelectedIndex = lvIntellisense.Items.Count - 1
                lvIntellisense.Focus()
                e.Handled = True
            End If
        End If

        If SelectedPart Or MustPutLock Then
            SelectedPart = False
            MustPutLock = False

            '
            '   Whole erase target text.
            '
            If e.KeyCode <> Keys.Back Then

                If e.KeyCode = Keys.Space AndAlso tbOption.Text(GlobalPosition - 1) = "?" Then
                    ToolTip1.Show("You should put parameter.", _
                                  Me, _
                                  tbOption.Left + GetCaretWidthFromtbOption(GlobalPosition), _
                                  tbOption.Top + tbOption.Font.Height + 5)
                    MustPutLock = True
                    Exit Sub
                Else
                    ToolTip1.Hide(Me)
                End If

                tbOption.SelectionStart = GlobalPosition
                tbOption.SelectionLength = 0
            End If
        End If

    End Sub

    Private Sub tbOption_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbOption.KeyPress

        '
        '   Fake alread processed
        '
        If MustPutLock Then
            e.Handled = True
        End If

    End Sub

    Private Sub tbOption_KeyUp(sender As Object, e As KeyEventArgs) Handles tbOption.KeyUp

        '
        '   Search word position & Set That
        '
        Dim Position As Integer = tbOption.SelectionStart
        While Position AndAlso tbOption.Text(Position - 1) <> " "
            Position -= 1
        End While

        '
        '   Get word
        '
        Dim WordBuild As New StringBuilder
        Dim Word As String
        For i As Integer = Position To tbOption.TextLength - 1
            If tbOption.Text(i) = " " Then
                Exit For
            End If
            WordBuild.Append(tbOption.Text(i))
        Next
        Word = WordBuild.ToString()

        '
        '   Null string
        '
        If Word = "" Then
            lvIntellisense.Visible = False
            Exit Sub
        End If

        '
        '   Auto complete text comparation
        '
        Dim MatchWordList As New List(Of String)
        For Each comp As String In KeyWordList
            If comp.ToLower.StartsWith(Word.ToLower) Then
                If comp <> Word Then
                    MatchWordList.Add(comp)
                End If
            End If
        Next

        '
        '   Sort Array
        '
        Dim MatchedOrderList As String() = (From value In MatchWordList Select value Distinct Order By value).ToArray

        '
        '   Set ListBox
        '
        If MatchedOrderList.Length > 0 Then
            lvIntellisense.Visible = True
            lvIntellisense.Items.Clear()
            For Each item As String In MatchedOrderList
                lvIntellisense.Items.Add(item)
            Next
            lvIntellisense.Location = New Point(tbOption.Left + GetCaretWidthFromtbOption(Position), _
                                                tbOption.Top + tbOption.Font.Height + 5)
            lvIntellisense.MaxColoredTextLength = Word.Length
        Else
            lvIntellisense.Visible = False
            Exit Sub
        End If

        GlobalPosition = Position
        GlobalText = Word

        '
        '   ListBox Index Set
        '
        If e.KeyCode = Keys.Down Then
            lvIntellisense.SelectedIndex = 0
            lvIntellisense.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            lvIntellisense.SelectedIndex = lvIntellisense.Items.Count - 1
            lvIntellisense.Focus()
        ElseIf e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            PutStringIntoTextBox(lvIntellisense.Items(0).ToString)
        End If

    End Sub

    '
    '   Only targetting Keyboard, double click event not support.
    '
    Private Sub lvIntellisense_KeyUp(sender As Object, e As KeyEventArgs) Handles lvIntellisense.KeyUp

        If e.KeyCode = Keys.Enter Then

            PutStringIntoTextBox(lvIntellisense.SelectedItem.ToString())

        ElseIf e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Escape Then

            lvIntellisense.Hide()
            tbOption.Focus()

        End If

    End Sub

    Private Sub lvIntellisense_DoubleClick(sender As Object, e As EventArgs) Handles lvIntellisense.DoubleClick
        PutStringIntoTextBox(lvIntellisense.SelectedItem.ToString())
    End Sub

    Private Sub PutStringIntoTextBox(ByVal ItemText As String)

        '
        '   Merge front and rear of the sentences containing the target.
        '
        tbOption.Text = tbOption.Text.Substring(0, GlobalPosition) & _
                        ItemText.ToString() & _
                        tbOption.Text.Substring(GlobalPosition + GlobalText.Length)
        lvIntellisense.Hide()

        '
        '   Select searched words
        '
        tbOption.SelectionStart = GlobalPosition
        tbOption.SelectionLength = ItemText.Length
        tbOption.Focus()

        GlobalPosition = GlobalPosition + tbOption.SelectionLength
        SelectedPart = True

    End Sub

End Class