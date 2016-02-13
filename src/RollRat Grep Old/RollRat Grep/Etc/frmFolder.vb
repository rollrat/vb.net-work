'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmFolder

    Dim index_count As Long = 1
    Public Shared FolderReport As New ArrayList

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(ListView1.SelectedItems(0).SubItems(2).Text)

        If folderExists Then
            Process.Start(ListView1.SelectedItems(0).SubItems(2).Text)
        End If
    End Sub

    Private Sub ListView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter
        ' Check for the custom DataFormat ListViewItem array.
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each filePath As String In filePaths
                Dim folderExists As Boolean
                folderExists = My.Computer.FileSystem.DirectoryExists(filePath)
                If folderExists = True Then
                    Dim LI As ListViewItem
                    Dim strArray, t As String()
                    t = filePath.Split("\"c)
                    strArray = New String() {index_count, t(t.Length - 1), filePath}
                    Dim lvt = New ListViewItem(strArray)
                    LI = Me.ListView1.Items.Add(lvt)
                    LI.StateImageIndex = 0
                    index_count += 1
                End If
            Next filePath
        End If
    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        If e.KeyCode = Keys.Delete Then
            For Each i As ListViewItem In ListView1.SelectedItems
                ListView1.Items.Remove(i)
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderReport.Clear()
        For Each lvwData As ListViewItem In ListView1.Items
            FolderReport.Add(lvwData.SubItems(1).Text)
        Next
        frmReport.Show()
    End Sub

    Private Sub frmFolder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmFolder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pw As New Security.Principal.WindowsPrincipal(Security.Principal.WindowsIdentity.GetCurrent)
        If pw.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator) Then
            MsgBox("관리자모드로 이 항목을 실행할 수 없습니다.", MsgBoxStyle.Critical, "Folder Mode")
            Close()
        End If
    End Sub

End Class