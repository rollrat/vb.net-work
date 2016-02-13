Public Class frmResult

    Private Sub frmResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim files As ArrayList = frmFolder.FolderReport
        For Each file In files
            RichTextBox1.AppendText(file & vbCrLf)
        Next
    End Sub
End Class