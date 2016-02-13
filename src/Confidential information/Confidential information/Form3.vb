Public Class Form3

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        MsgBox("Unlock !", MsgBoxStyle.Information, "Error 000x003")
        Form2.Enabled = True
        Me.Close()
    End Sub
End Class