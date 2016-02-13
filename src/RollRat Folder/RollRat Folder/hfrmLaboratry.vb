Imports System.Text.RegularExpressions

Public Class hfrmLaboratry

    Dim src As String

    Dim ytb_search As String = "https://www.youtube.com/results?search_query="""

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim client As Net.WebClient = New Net.WebClient()
                client.Encoding = System.Text.Encoding.UTF8
                src = client.DownloadString(ytb_search & TextBox1.Text)
                enumeration()
            Catch ex As Exception
                MsgBox("Error!", MsgBoxStyle.Critical, "")
            End Try
        End If
    End Sub

    Private Sub enumeration()
        ListView1.Items.Clear()
        Dim regex As Regex = New Regex("(?<=dir\=\""ltr\""\>).*?(?=\<\/a\>\<span class\=)")
        Dim regex1 As Regex = New Regex("(?<=<h3 class=""yt-lockup-title""><a href="").*?(?="")")
        Dim match As MatchCollection = regex.Matches(src)
        Dim match1 As MatchCollection = regex1.Matches(src)
        For i As Integer = 0 To match.Count - 1
            ListView1.Items.Add(New ListViewItem(New String() {replace(match(i).ToString), match1(i).ToString}))
        Next
    End Sub

    Private Function replace(ByVal str As String) As String
        Dim strs As String = str
        Dim oj() As String = {"&nbsp;", "&amp;", "&quot;", "&lt;", _
           "&gt;", "&reg;", "&copy;", "&bull;", "&trade;", "&#39;"}
        Dim kj() As String = {" ", "&", """", "<", ">", "Â®", "Â©", "â€¢", "â„¢", "'"}
        For i As Integer = 0 To oj.Length - 1
            strs = strs.Replace(oj(i), kj(i))
        Next
        Return strs
    End Function

End Class