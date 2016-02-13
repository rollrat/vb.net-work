Public Class frmDBList

    Private Sub frmDBList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim files As ArrayList = frmMain.Files

        For Each File As String In files
            ListView1.Items.Add(File)
            Application.DoEvents()
        Next
    End Sub

End Class