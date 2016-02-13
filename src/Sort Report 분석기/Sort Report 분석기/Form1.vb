Imports System.IO
Imports System.Text

Public Class Form1

    Structure _dataset
        Dim sort_name As String
        Dim array_name As String
        Dim continue_count As Integer
        Dim summation As Double
        Dim average As Double
        Dim variance As Double
        Dim standard_deviation As Double
    End Structure

    Dim list_data As New List(Of _dataset)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim srt As StreamReader = New StreamReader(OpenFileDialog1.FileName, Encoding.Default)
            Dim line As String
            Dim now_data As New _dataset
            Do
                line = srt.ReadLine()
                If line = Nothing Then _
                    If srt.EndOfStream Then Exit Do
                If line = "" Then
                    list_data.Add(now_data)
                    now_data = New _dataset
                    Continue Do
                End If
                If line.Contains("["c) Then
                    Dim split As String() = line.Split("["c)
                    now_data.sort_name = split(1).Split("]"c)(0)
                    now_data.array_name = split(2).Split("]"c)(0)
                    now_data.continue_count = split(3).Split("]"c)(0)
                ElseIf line.StartsWith("합계") Then
                    now_data.summation = line.Split(" "c)(2)
                ElseIf line.StartsWith("평균") Then
                    now_data.average = line.Split(" "c)(2)
                ElseIf line.StartsWith("분산") Then
                    now_data.variance = line.Split(" "c)(2)
                ElseIf line.StartsWith("표준편차") Then
                    now_data.standard_deviation = line.Split(" "c)(2)
                End If
            Loop
            srt.Close()

            Dim list_overlap As New List(Of String)
            For Each i As _dataset In list_data
                If list_overlap.Contains(i.sort_name) Then Continue For
                list_overlap.Add(i.sort_name)
            Next
            For Each i As String In list_overlap
                ListBox1.Items.Add(i)
            Next
            list_overlap.Clear()
            For Each i As _dataset In list_data
                If list_overlap.Contains(i.continue_count) Then Continue For
                list_overlap.Add(i.continue_count)
            Next
            For Each i As String In list_overlap
                ListBox2.Items.Add(i)
            Next
            list_overlap.Clear()
            For Each i As _dataset In list_data
                If list_overlap.Contains(i.array_name) Then Continue For
                list_overlap.Add(i.array_name)
            Next
            For Each i As String In list_overlap
                ListBox3.Items.Add(i)
            Next
            ListBox4.Items.Add("합계")
            ListBox4.Items.Add("평균")
            ListBox4.Items.Add("분산")
            ListBox4.Items.Add("표준편차")
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox3.SelectedItem Is Nothing Then Exit Sub
        If ListBox4.SelectedItem Is Nothing Then Exit Sub
        report_result()
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        If ListBox2.SelectedItem Is Nothing Then Exit Sub
        If ListBox4.SelectedItem Is Nothing Then Exit Sub
        report_result()
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        If ListBox2.SelectedItem Is Nothing Then Exit Sub
        If ListBox3.SelectedItem Is Nothing Then Exit Sub
        report_result()
    End Sub

    Private Sub report_result()
        Dim i As String = ListBox2.SelectedItem.ToString
        Dim j As String = ListBox3.SelectedItem.ToString
        Dim k As String = ListBox4.SelectedItem.ToString
        RichTextBox1.Clear()
        Dim i_ As New List(Of _dataset)
        Dim j_ As New List(Of Double)

        For Each item As _dataset In list_data
            If item.continue_count = i Then
                If item.array_name = j Then
                    If k = "합계" Then
                        j_.Add(item.summation)
                    ElseIf k = "평균" Then
                        j_.Add(item.average)
                    ElseIf k = "분산" Then
                        j_.Add(item.variance)
                    ElseIf k = "표준편차" Then
                        j_.Add(item.standard_deviation)
                    End If
                    i_.Add(item)
                End If
            End If
        Next

        Dim to_i As _dataset() = i_.ToArray
        Dim to_j As Double() = j_.ToArray
        Array.Sort(to_j, to_i)
        For p As Integer = 0 To j_.Count - 1
            RichTextBox1.AppendText(Strings.LSet(to_i(p).sort_name, 10) & vbTab & to_j(p) & vbCrLf)
        Next

    End Sub

End Class
