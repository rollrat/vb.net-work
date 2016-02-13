Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Threading.Thread.CurrentThread.CurrentCulture.CompareInfo.IndexOf(TextBox1.Text, "http://blog.naver.com/", 0, 0) Then
            TextBox2.Text = "http://bgmstore.net/view/" & New  _
            System.Text.RegularExpressions.Regex _
            ("(?<=player\.bgmstore\.net\/)\w+").Match( _
            New IO.StreamReader(Net.HttpWebRequest.Create( _
            "http://blog.naver.com/PostView.nhn?blogId=" & _
            TextBox1.Text.Split("/")(3) & "&logNo=" & _
            TextBox1.Text.Split("/")(4)).GetResponse().GetResponseStream()).ReadToEnd()).Value()
        End If
        Clipboard.SetText(New IO.StreamReader(Net.HttpWebRequest.Create( _
            "http://blog.naver.com/PostView.nhn?blogId=" & _
            TextBox1.Text.Split("/")(3) & "&logNo=" & _
            TextBox1.Text.Split("/")(4)).GetResponse().GetResponseStream()).ReadToEnd())
    End Sub

End Class
