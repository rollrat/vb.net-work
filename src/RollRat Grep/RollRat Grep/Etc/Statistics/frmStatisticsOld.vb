'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO
Imports System.Collections.ObjectModel

Public Class frmStatisticsOld

    Dim FolderGrid As New ArrayList
    Dim count As Integer

    Function CompactString(ByVal MyString As String, ByVal Width As Integer,
                    ByVal Font As Drawing.Font,
                    ByVal FormatFlags As TextFormatFlags) As String

        Dim Result As String = String.Copy(MyString)

        TextRenderer.MeasureText(Result, Font, New Drawing.Size(Width, 0),
            FormatFlags Or TextFormatFlags.ModifyString)

        Return Result

    End Function

    Public Shared Function ParseExtension(ByVal strExtension As String)
        Dim pic_extension As String() = strExtension.Split("|"c)
        Return pic_extension
    End Function

    Dim pic_extension As String()

    Private Sub frmStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pic_extension = ParseExtension(".jpg|.jpeg|.png|.bmp|.gif")

        Me.Show()

        Label1.Text = "폴더 추출중..."
        scan_folder()
        Label1.Text = "폴더 나열중..."
        list_treeview()

        Label1.Visible = False
        Label2.Visible = False

    End Sub

    Private Sub scan_folder()
        Timer1.Interval = 30
        Timer1.Start()
        count = 0
        FolderGrid.Clear()
        Dim PreAccess As String = ""

        For Each it As String In frmMain.LoadFiles
            On Error Resume Next
            Application.DoEvents()

            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(it)
            Dim NowAccess As String
            If fileExists = True Then
                Continue For
            Else
                Dim folderExists As Boolean
                folderExists = My.Computer.FileSystem.DirectoryExists(it)
                If folderExists Then
                    NowAccess = it
                Else
                    Continue For
                End If
            End If

            count += 1

            '
            '   바로 전 주소가 현재 주소와 같은 경우가 매우 많으니 추가함
            '
            If PreAccess = NowAccess Then
                Continue For
            Else
                If FolderGrid.Contains(NowAccess) Then
                    Continue For
                End If
            End If

            Label2.Text = CompactString(NowAccess, Me.Location.X - ProgressBar1.Location.X, Label2.Font, TextFormatFlags.PathEllipsis)
            FolderGrid.Add(NowAccess)
            PreAccess = NowAccess
        Next

        Label2.Text = ""
        Timer1.Stop()
        ProgressBar1.Value = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim prog As Integer = Math.Round((count / frmMain.LoadFiles.Count) * 100)
        ProgressBar1.Value = prog
        Application.DoEvents()
    End Sub

    Dim globalcount As Integer

    Private Sub list_treeview()
        Dim j As Integer = 0

        '
        '   DB파일의 최상위 폴더를 가져옴
        '
        top_addr = Path.GetDirectoryName(FolderGrid(0)) & "\"
        For i As Integer = 0 To FolderGrid.Count - 1
            Application.DoEvents()
            TreeView1.Nodes.Add(Path.GetFileName(FolderGrid(i)))

            '
            '   주소 맨 끝에 \를 추가하여 해당 폴더가 포함되어있는지 확인합니다.
            '   ex) D:\2014\rollrat에 D:\2014가 포함되어있는지 알아보려면,
            '       D:\2014\가 포함되어있는지 알아보는 것이 D:\2014보다 정확합니다.
            '       가령, D:\2014-abs라는 폴더는 D:\2014가 포함된 주소이므로,
            '       Contains함수는 해당 주소가 포함되어있다고 True가 반환됩니다.
            '
            If CType(FolderGrid(i + 1), String).Contains(FolderGrid(i) & "\") Then
                globalcount = i
                integernal_list_treeview(FolderGrid(i), TreeView1.Nodes(j))
            End If
            j += 1
            i = globalcount
        Next
    End Sub

    Dim perpect_then_exit As Boolean = False

    Private Sub integernal_list_treeview(ByVal obstr As String, ByVal panode As TreeNode)
        On Error Resume Next

        Application.DoEvents()

        For i As Integer = globalcount + 1 To FolderGrid.Count - 1

            If CType(FolderGrid(i), String).Contains(obstr & "\") Then
                Label2.Text = CompactString(Path.GetFileName(FolderGrid(i)), Me.Location.X - ProgressBar1.Location.X, Label2.Font, TextFormatFlags.PathEllipsis)
                Dim chnode As New TreeNode(Path.GetFileName(FolderGrid(i)))
                panode.Nodes.Add(chnode)
                If CType(FolderGrid(i + 1), String).Contains(FolderGrid(i) & "\") Then
                    globalcount = i
                    If globalcount = FolderGrid.Count - 1 Then
                        perpect_then_exit = True
                        Exit Sub
                    End If
                    integernal_list_treeview(FolderGrid(i), chnode)
                    If perpect_then_exit Then
                        Exit Sub
                    End If
                    i = globalcount - 1
                End If
            Else
                globalcount = i
                Exit Sub
            End If
        Next
    End Sub

    '// http://www.freevbcode.com/ShowCode.asp?ID=4287
    Function GetFolderSize(ByVal DirPath As String, Optional IncludeSubFolders As Boolean = True) As Long

        Dim lngDirSize As Long
        Dim objFileInfo As FileInfo
        Dim objDir As DirectoryInfo = New DirectoryInfo(DirPath)
        Dim objSubFolder As DirectoryInfo

        Try

            'add length of each file
            For Each objFileInfo In objDir.GetFiles()
                lngDirSize += objFileInfo.Length
            Next

            'call recursively to get sub folders
            'if you don't want this set optional
            'parameter to false 
            If IncludeSubFolders Then
                For Each objSubFolder In objDir.GetDirectories()
                    lngDirSize += GetFolderSize(objSubFolder.FullName)
                Next
            End If

        Catch Ex As Exception


        End Try

        Return lngDirSize
    End Function

    Dim top_addr As String = ""

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Label4.Text = top_addr & TreeView1.SelectedNode.FullPath
        Label6.Text = TreeView1.SelectedNode.FullPath
        Dim files As ReadOnlyCollection(Of String)
        If CheckBox1.Checked Then
            files = My.Computer.FileSystem.GetFiles(Label4.Text, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
            'Label28.Text = files.Count
        End If
        files = My.Computer.FileSystem.GetFiles(Label4.Text, FileIO.SearchOption.SearchTopLevelOnly, "*.*")
        ListBox1.Items.Clear()
        Label9.Text = files.Count
        For Each x In files
            ListBox1.Items.Add(Path.GetFileName(x))
        Next
        Dim j = 0
        If files.Count > 0 Then
RE:
            ListBox1.SelectedIndex = j
            If Not pic_extension.Contains(IO.Path.GetExtension(ListBox1.SelectedItem)) Then
                j += 1
                If files.Count > j Then
                    GoTo RE
                Else
                    ListBox1.SelectedIndex = 0
                End If
            End If
        Else
            If Me.Location.X <> 923 Then
                Me.Size = New Point(923, 441)
            End If
        End If
        Label10.Text = Directory.GetDirectories(Label4.Text).Length
        If CheckBox1.Checked Then
            'Label30.Text = Directory.GetDirectories(Label4.Text, "*", SearchOption.AllDirectories).Length
        End If
        Label12.Text = Directory.GetCreationTime(Label4.Text)
        Label14.Text = Directory.GetLastAccessTime(Label4.Text)
        Label16.Text = Directory.GetLastWriteTime(Label4.Text)
        'TextBox1.Text = Directory.GetParent(Label4.Text).ToString
        If CheckBox1.Checked Then
            Label20.Text = GetFolderSize(Label4.Text).ToString("#,#")
        End If
    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        On Error Resume Next
        Process.Start(top_addr & TreeView1.SelectedNode.FullPath)
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Process.Start(Label4.Text & "\" & ListBox1.SelectedItem)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        On Error Resume Next

        Dim addr As String = Label4.Text & "\" & ListBox1.SelectedItem
        Label26.Text = File.GetCreationTime(addr)
        Label24.Text = File.GetLastAccessTime(addr)
        Label22.Text = File.GetLastWriteTime(addr)
        Label18.Text = New FileInfo(addr).Length.ToString("#,#")

        If frmMain.array_ext.Contains(IO.Path.GetExtension(addr)) Then
            Label33.Text = File.ReadAllLines(addr).Length
        ElseIf pic_extension.Contains(IO.Path.GetExtension(addr)) Then
            '923, 441
            '1207, 441
            Me.Size = New Point(1207, 441)
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Image.FromFile(addr)
            Exit Sub
        End If

        If Me.Location.X <> 923 Then
            Me.Size = New Point(923, 441)
        End If

    End Sub

    Dim book_mark As New List(Of String)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not book_mark.Contains(top_addr & TreeView1.SelectedNode.FullPath) Then
            book_mark.Add(top_addr & TreeView1.SelectedNode.FullPath)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim svp As String
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            svp = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        PictureBox1.Image.Dispose()
        For Each sr As String In book_mark
            'Directory.Move(sr & "\", svp)
            'My.Computer.FileSystem.CreateDirectory(svp & "\" & Path.GetFileName(sr))
            My.Computer.FileSystem.MoveDirectory(sr & "\", svp & "\" & Path.GetFileName(sr))
        Next
    End Sub

End Class