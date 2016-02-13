Public Class setting

    Private Sub setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini")
        If Not fileExists Then
            Label2.Text = "False"
            Button1.Enabled = True
        Else
            GroupBox1.Enabled = True
            Dim a As String = ReadIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT_USE")
            If a = "TRUE" Then
                CheckBox1.Checked = True
                NumericUpDown1.Enabled = True
            End If
            Dim b As String = ReadIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "BUTTON", "VISI_COUNT")
            If b = "FALSE" Then
                CheckBox2.Checked = False
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT_USE", "FALSE")
        WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT", "0")
        WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "BUTTON", "VISI_COUNT", "TRUE")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT_USE", "TRUE")
            WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT", NumericUpDown1.Value)
            NumericUpDown1.Enabled = True
        Else
            WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT_USE", "FALSE")
            WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT", "0")
            NumericUpDown1.Enabled = False
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT", NumericUpDown1.Value)

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "BUTTON", "VISI_COUNT", "TRUE")
        Else
            WriteIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "BUTTON", "VISI_COUNT", "FALSE")
        End If
    End Sub
End Class