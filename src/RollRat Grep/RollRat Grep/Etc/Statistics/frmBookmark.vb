Public Class frmBookmark

    Private Sub frmBookmark_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmBookmark_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim index As Integer = 1
        For Each x In frmStatistics.book_mark
            Dim strArray = New String() {index, x}
            Dim lvt = New ListViewItem(strArray)
            ListView1.Items.Add(lvt)
            index += 1
        Next
    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        If e.KeyCode = Keys.Delete Then
            For Each i As ListViewItem In ListView1.SelectedItems
                ListView1.Items.Remove(i)
            Next
            frmStatistics.book_mark.Clear()
            For i As Integer = 0 To ListView1.Items.Count - 1
                frmStatistics.book_mark.Add(ListView1.Items.Item(i).SubItems(1).Text)
            Next
        End If
    End Sub

End Class