Public Class OnlyNumberTextbox
    Inherits System.Windows.Forms.TextBox

    Private Sub UserControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 8
            Case 48 To 57
            Case Else
                KeyAscii = 0
        End Select
        If KeyAscii = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

End Class
