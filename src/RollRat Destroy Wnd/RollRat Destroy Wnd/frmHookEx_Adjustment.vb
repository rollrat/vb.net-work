Public Class frmHookEx_Adjustment

    Public Shared Event Me_Enter(ByVal chrLetter As String)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent Me_Enter(TextBox1.Text)
        Me.Close()
    End Sub

    Private Sub frmHookEx_Adjustment_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class