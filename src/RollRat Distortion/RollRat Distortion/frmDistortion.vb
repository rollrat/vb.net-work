'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO
Imports System.Text

Public Class frmDistortion

    Dim list_matched As List(Of String)
    Dim list_line As List(Of Integer)
    Dim list_addr As List(Of String)

    '
    '   문법 분리를 위한 Split는 사용하지 마십시오.
    '
    Private Function BackGeta(ByVal split_target As String) As String()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f = OpenFileDialog1.ShowDialog()
        If f = DialogResult.OK Then
            Dim srt As StreamReader = New StreamReader(OpenFileDialog1.FileName, Encoding.UTF8)
            Dim linetext As String
            Label2.Text = OpenFileDialog1.FileName
            list_matched = New List(Of String)
            list_line = New List(Of Integer)
            list_addr = New List(Of String)
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            TextBox1.Enabled = True
            Do
                linetext = srt.ReadLine()

                If linetext = Nothing Then
                    If srt.EndOfStream Then
                        Exit Do
                    End If
                End If

                If linetext <> "" AndAlso linetext.Contains("|"c) AndAlso Not linetext.StartsWith("//") Then
                    Dim splits As String() = BackGeta(linetext)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        For i As Integer = 0 To list_matched.Count - 1
            If CheckBox1.Checked Then
                Dim match2 As System.Text.RegularExpressions.Match
                match2 = System.Text.RegularExpressions.Regex.Match(list_matched(i), TextBox1.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If match2.Success Then
                    ListBox1.Items.Add(list_matched(i) & "<" & list_line(i) & "," & Path.GetFileName(list_addr(i)) & ">|" & i)
                End If
            Else
                If list_matched(i).IndexOf(TextBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    ListBox1.Items.Add(list_matched(i) & "<" & list_line(i) & "," & Path.GetFileName(list_addr(i)) & ">|" & i)
                End If
            End If
        Next
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        If Not ListBox1.SelectedItem Is Nothing Then
            Dim xis As String = ListBox1.SelectedItem.ToString
            Dim xis_offset As Integer = xis.Split("|"c)(1)
            Dim selected_filename As String
            selected_filename = list_addr(xis_offset)
            Process.Start(selected_filename)
        End If
    End Sub

    Private Sub ListBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyUp
        If e.KeyCode = Keys.Delete Then
            If Not ListBox1.SelectedItem Is Nothing Then
                Dim xis_text As String = ListBox1.SelectedItem.ToString.Split("<"c)(0)
                Dim list_pos As New List(Of Integer)

                '
                '   Reference 상황을 고려해 리스트 아이템이 정렬되지 않았다고 가정함
                '
                For i As Integer = 0 To ListBox1.Items.Count - 1
                    If ListBox1.Items(i).ToString.Contains(xis_text) Then

                        '
                        '   리스트 아이템을 한 개씩 제거할 때마다 한 칸씩 요소가 뒤로 밀려나게 된다.
                        '
                        list_pos.Add(i - list_pos.Count)
                    End If
                Next
                For Each pos As Integer In list_pos
                    ListBox1.Items.Remove(ListBox1.Items(pos))
                Next
            End If
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Not ListBox1.SelectedItem Is Nothing Then
            Dim xis As String = ListBox1.SelectedItem.ToString
            Dim xis_split As String() = xis.Split("|"c)
            Dim xis_offset As Integer = xis_split(xis_split.Length - 1)
            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(list_addr(xis_offset))
            If fileExists Then
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(list_addr(xis_offset))
                RichTextBox1.Text = fileContents

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

                RichTextBox1.SelectionStart = offset
                RichTextBox1.ScrollToCaret()
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Not RichTextBox1.Text = "" AndAlso Not ListBox1.SelectedItem Is Nothing Then
            Dim xis As String = ListBox1.SelectedItem.ToString
            Dim xis_offset As Integer = xis.Split("|"c)(1)
            Dim selected_filename As String = list_addr(xis_offset)
            Dim srt As StreamReader = New StreamReader(selected_filename, Encoding.Default)
            Dim linetext As String
            Dim line As Integer = 0
            Dim count As Integer = 0
            Dim startalreay As Boolean = False
            ListBox1.Items.Clear()
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
                        ListBox1.Items.Add(list_matched(i) & "<" & list_line(i) & "," & Path.GetFileName(list_addr(i)) & ">|" & i)
                    End If
                End If
            Loop
            srt.Close()
        End If
    End Sub

    Private Function find_offset(ByVal filename As String, ByVal count As Integer, ByVal syntax As String) As Integer
        For i As Integer = 0 To list_addr.Count - 1
            If list_line(i) = count Then
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str As New StringBuilder
        For Each s As String In ListBox1.Items
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

    Private Sub RunFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Not ListBox1.SelectedItem Is Nothing Then
            Dim xis As String = ListBox1.SelectedItem.ToString
            Dim xis_offset As Integer = xis.Split("|"c)(1)
            Dim selected_filename As String
            selected_filename = list_addr(xis_offset)
            Process.Start(selected_filename)
        End If
    End Sub

End Class