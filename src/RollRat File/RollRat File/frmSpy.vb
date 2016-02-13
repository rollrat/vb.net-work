Imports System.IO

Public Class frmSpy

    Private SavePath As String = "c:\spy.evr"

    Private Sub FileSystemWatcher1_Changed(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        If e.FullPath.Contains("KakaoTalk") And CheckBox1.Checked Then
            Return
        End If
        ListView1.Items.Add(New ListViewItem(New String() {e.ChangeType.ToString(), e.FullPath, My.Computer.Clock.LocalTime}))
    End Sub

    Private Sub FileSystemWatcher1_Created(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Created
        If e.FullPath.Contains("KakaoTalk") And CheckBox1.Checked Then
            Return
        End If
        ListView1.Items.Add(New ListViewItem(New String() {e.ChangeType.ToString(), e.FullPath, My.Computer.Clock.LocalTime}))
    End Sub

    Private Sub FileSystemWatcher1_Deleted(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Deleted
        If e.FullPath.Contains("KakaoTalk") And CheckBox1.Checked Then
            Return
        End If
        ListView1.Items.Add(New ListViewItem(New String() {e.ChangeType.ToString(), e.FullPath, My.Computer.Clock.LocalTime}))
    End Sub

    Private Sub FileSystemWatcher1_Renamed(sender As Object, e As RenamedEventArgs) Handles FileSystemWatcher1.Renamed
        If e.FullPath.Contains("KakaoTalk") And CheckBox1.Checked Then
            Return
        End If
        ListView1.Items.Add(New ListViewItem(New String() {e.ChangeType.ToString(), e.FullPath, My.Computer.Clock.LocalTime}))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(SavePath)
        If fileExists = False Then
            My.Computer.FileSystem.WriteAllText(SavePath, String.Empty, False)
        End If

        Dim savestr As String = ""
        For Each item In ListView1.Items
            savestr += item.Subitems(0).text & " | " & Strings.LSet(item.subitems(1).text, 256) & " | " & item.subitems(2).text & vbCrLf
        Next
        My.Computer.FileSystem.WriteAllText(SavePath, savestr, True)
    End Sub

End Class