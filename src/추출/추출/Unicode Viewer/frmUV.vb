Imports 추출.RollRat_Vb_Api

Public Class frmUV

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim A As New OpenFileDialog
        Dim Str As String

        If A.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Bytes() As Byte = _F.ReadBytes(A.FileName)
            For dA = 0 To UBound(Bytes)
                Str += Bytes(dA).ToString("X") & " "
            Next
        End If

        RichTextBox1.Text = Str

    End Sub

End Class