'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO
Imports System.Text

Public Class frmView

    Dim count As Integer
    Dim isFolderGridMod As Boolean = False
    Dim FolderGrid As New ArrayList
    Dim isIndexingMode As Boolean = False
    Dim Indexing As New ArrayList

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim svp As String
        Dim f = SaveFileDialog1.ShowDialog()
        If f = Windows.Forms.DialogResult.OK Then
            svp = SaveFileDialog1.FileName
        Else
            Exit Sub
        End If

        Dim ats As New StringBuilder
        count = 0

        ats.Append("RollRat Software Grep Utility " & Version.VersionText & vbCrLf)
        ats.Append("Copyright (c) rollrat. 2015. All rights reserved." & vbCrLf & vbCrLf)

        ProgressBar1.Visible = True
        Timer1.Interval = 30
        Timer1.Start()
        'If CheckBox1.Checked Then
        '    For Each it As String In frmMain.LoadFiles
        '        count += 1
        '        ats.Append(Path.GetFileName(it) & vbCrLf)
        '        Application.DoEvents()
        '    Next
        'Else
        '    If isFolderGridMod Then
        '        For Each fg As String In FolderGrid
        '            count += 1
        '            ats.Append(fg & vbCrLf)
        '            Application.DoEvents()
        '        Next
        '    ElseIf isIndexingMode Then
        '        For Each fg As String In Indexing
        '            count += 1
        '            ats.Append(fg & vbCrLf)
        '            Application.DoEvents()
        '        Next
        '    Else
        '        For Each it As String In frmMain.LoadFiles
        '            count += 1
        '            ats.Append(it & vbCrLf)
        '            Application.DoEvents()
        '        Next
        '    End If
        'End If

        For Each it As ListViewItem In ListView1.Items
            count += 1
            ats.Append(it.SubItems(0).Text & vbCrLf)
            Application.DoEvents()
        Next

        Timer1.Stop()
        ProgressBar1.Visible = False

        Dim fileData As FileInfo
        fileData = My.Computer.FileSystem.GetFileInfo(frmMain.loadDb)

        With ats
            If isFolderGridMod Then
                .Append(vbCrLf)
            End If
            .Append("   DataBase Name: " & frmMain.loadDb & vbCrLf)
            .Append("       File Name: " & fileData.Name & vbCrLf)
            .Append("     File Length: " & RSet(fileData.Length.ToString("#,#"), 10) & vbCrLf)
            If isFolderGridMod Then
                .Append(" Counted Folders: " & RSet(FolderGrid.Count.ToString("#,#"), 10) & vbCrLf)
            Else
                .Append("   Counted Files: " & RSet(frmMain.LoadFiles.Count.ToString("#,#"), 10) & vbCrLf)
            End If
            .Append("      Attributes: " & fileData.Attributes.ToString() & vbCrLf)
            .Append(" Last Write Time: " & fileData.LastWriteTime & vbCrLf)
            .Append("Last Access Time: " & fileData.LastAccessTime & vbCrLf)
            .Append("   Creation Time: " & fileData.CreationTime & vbCrLf)
            .Append("    DataBase MD5: " & MD5DBFile(frmMain.loadDb) & vbCrLf)
            .Append("  DataBase SHA-1: " & SHA1DBFile(frmMain.loadDb) & vbCrLf)
        End With

        File.WriteAllText(svp, ats.ToString)

        MsgBox("파일을 내보냈습니다.", MsgBoxStyle.Information)
    End Sub

    Function MD5DBFile(ByVal addr As String) As String
        Dim md5service As New Security.Cryptography.MD5CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In md5service.ComputeHash(File.ReadAllBytes(addr))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function SHA1DBFile(ByVal addr As String) As String
        Dim sha1service As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In sha1service.ComputeHash(File.ReadAllBytes(addr))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown

        '
        '   F2를 눌러 폴더만 추출하자
        '
        If e.KeyCode = Keys.F2 And isFolderGridMod = False Then
추출GOTO:
            '// Grid Folder From File Data Base

            ProgressBar1.Visible = True
            Timer1.Interval = 30
            Timer1.Start()
            count = 0
            FolderGrid.Clear()

            Dim PreAccess As String = ""

            For Each it As String In frmMain.LoadFiles
                On Error Resume Next
                Dim NowAccess As String = Path.GetDirectoryName(it)
                count += 1
                Application.DoEvents()

                '
                '   바로 전 주소가 현재 주소와 같은 경우가 매우 많으니 추가함
                '
                If PreAccess = NowAccess Then
                    Continue For
                Else

                    '
                    '   배열을 전부 뒤져서 있는지 없는지 찾음(간혹 
                    '   배열이 순서대로 되어있지않아 처리가 않되는 경우가 있더라고요
                    '
                    If FolderGrid.Contains(NowAccess) Then
                        Continue For
                    End If
                End If

                FolderGrid.Add(NowAccess)
                PreAccess = NowAccess
            Next

            Timer1.Stop()
            ProgressBar1.Visible = False
            ListView1.Items.Clear()

            For Each fg As String In FolderGrid
                ListView1.Items.Add(fg)
            Next

            isFolderGridMod = True
            CheckBox1.Enabled = False
            CheckBox1.Checked = False


            '
            '   해제
            '
        ElseIf e.KeyCode = Keys.F2 Then
해제GOTO:
            CheckBox1.Enabled = True
            isFolderGridMod = False
            ListView1.Items.Clear()
            frmView_Load(0, New EventArgs())


            '
            '   F3을 눌러서 ./Path만 출력하자(파일나열이든 폴더나열이든 따지지 않음)
            '
        ElseIf e.KeyCode = Keys.F3 And Not isIndexingMode Then

            ProgressBar1.Visible = True
            Timer1.Interval = 30
            Timer1.Start()
            count = 0
            Indexing.Clear()

            '
            '   배열의 첫 번째 요소에 ./Path가 들어있음
            '
            Dim pathA As String = frmMain.LoadFiles(0)
            Dim pathB As String() = pathA.Split("\"c)

            '
            '   마지막폴더 가져오기
            '
            Dim pathC As String = "./" & pathB(pathB.Length - 1)

            '
            '   INDEX ./Path Emission(INDEXING)
            '
            For Each fg As ListViewItem In ListView1.Items
                count += 1
                fg.SubItems(0).Text = pathC & fg.SubItems(0).Text _
                    .Replace(pathA, "").Replace("\"c, "/"c)
                Indexing.Add(pathC & fg.SubItems(0).Text _
                    .Replace(pathA, "").Replace("\"c, "/"c))
                Application.DoEvents()
            Next

            Timer1.Stop()
            ProgressBar1.Visible = False
            isIndexingMode = True


            '
            '   F3을 한 번 더누르면 INDEXING모드 해제
            '
        ElseIf e.KeyCode = Keys.F3 Then

            isIndexingMode = False

            If isFolderGridMod Then
                GoTo 해제GOTO
            Else
                GoTo 추출GOTO
            End If

        End If
    End Sub

    Private Sub frmView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmMain.LoadFiles.Count > 100000 Then
            If MsgBox("파일이 너무 커서 자동으로 로드하지 않았습니다. 로드하시겠습니까?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        Else
            For Each it As String In frmMain.LoadFiles
                ListView1.Items.Add(it)
            Next
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim prog As Integer = Math.Round((count / frmMain.LoadFiles.Count) * 100)
        ProgressBar1.Value = prog
        Application.DoEvents()
    End Sub

    Private Sub frmView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

End Class