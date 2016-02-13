'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Text

Public Class frmStatistics

    Dim FolderGrid As New ArrayList
    Dim count As Integer
    Dim search_time As Boolean = false

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

    Private Sub frmStatistics_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pic_extension = ParseExtension(".jpg|.jpeg|.png|.bmp|.gif")

        Me.Show()

        search_time = True

        If frmMain.sdb_opened Then
            list_array(frmMain.sdb_global_filename)
            search_time = False
            Exit Sub
        End If

        If frmMain.ignore_open Then
            Exit Sub
        End If

        Label1.Text = "폴더 추출중..."
        scan_folder()
        Label1.Text = "폴더 나열중..."
        list_treeview()

        search_time = False
        Label1.Visible = False
        Label2.Visible = False
        ProgressBar1.Visible = False
        Me.Size = New Point(624, 534)

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

            Label2.Text = CompactString(NowAccess, Me.Location.X - Label2.Location.X, Label2.Font, TextFormatFlags.PathEllipsis)
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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim prog As Integer = Math.Round((count / FolderGrid.Count) * 100)
        ProgressBar1.Value = prog
        Application.DoEvents()
    End Sub

    Dim globalcount As Integer

    Private Sub list_treeview()

        Timer2.Interval = 30
        Timer2.Start()
        count = 0

        Dim j As Integer = 0

        '
        '   DB파일의 최상위 폴더를 가져옴
        '
        top_addr = Path.GetDirectoryName(FolderGrid(0)) & "\"
        For i As Integer = 0 To FolderGrid.Count - 1
            count = i
            Application.DoEvents()
            TreeView1.Nodes.Add(Path.GetFileName(FolderGrid(i)))

            '
            '   주소 맨 끝에 \를 추가하여 해당 폴더가 포함되어있는지 확인합니다.
            '   ex) D:\2014\rollrat에 D:\2014가 포함되어있는지 알아보려면,
            '       D:\2014\가 포함되어있는지 알아보는 것이 D:\2014보다 정확합니다.
            '       가령, D:\2014-abs라는 폴더는 D:\2014가 포함된 주소이므로,
            '       Contains함수는 해당 주소가 포함되어있다고 True가 반환됩니다.
            '   이 구문은 Ver >= 3.0에서 지원하며 최적화되지 않았습니다.
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
            count = i
            If CType(FolderGrid(i), String).Contains(obstr & "\") Then
                Label2.Text = CompactString(Path.GetFileName(FolderGrid(i)), Me.Location.X - Label2.Location.X, Label2.Font, TextFormatFlags.PathEllipsis)
                Dim chnode As New TreeNode(Path.GetFileName(FolderGrid(i)))
                panode.Nodes.Add(chnode)
                If CType(FolderGrid(i + 1), String).Contains(FolderGrid(i) & "\") Then
                    globalcount = i

                    '
                    '   globalcount 는 FolderGrid.Count - 1이 되면 이 부분에서 무한 재귀를 일으키므로
                    '   perpect_then_exit전역변수를 만들어 모든 재귀 루프가 끝나도록 설정함
                    '
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

    Dim top_addr As String = ""
    Dim current_addr As String

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        current_addr = top_addr & TreeView1.SelectedNode.FullPath

        '
        '   트리뷰 클릭시 리스트 박스 아이템 재설정
        '
        ListBox1.Items.Clear()
        listbox_item_text.Clear()
        Dim files As ReadOnlyCollection(Of String)
        files = My.Computer.FileSystem.GetFiles(current_addr, FileIO.SearchOption.SearchTopLevelOnly, "*.*")
        Label9.Text = files.Count
        For Each x In files
            listbox_item_text.Add(Path.GetFileName(x))
            ListBox1.Items.Add(Path.GetFileName(x))
        Next

        '
        '   pic_extension에 포함된 확장자는 미리보기를 지원하여 보여줌
        '   모든 리스트 박스 아이템을 전부 찾아서 확장자가 있는지 확인함
        '   없다면 선택인덱스를 첫 번째 아이템으로 둠
        '
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
            If Me.Location.X <> 624 Then
                If search_time Then
                    Me.Size = New Point(624, 561)
                Else
                    Me.Size = New Point(624, 534)
                End If
            End If
        End If

        Label10.Text = Directory.GetDirectories(current_addr).Length
    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        On Error Resume Next
        Process.Start(top_addr & TreeView1.SelectedNode.FullPath)
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Process.Start(current_addr & "\" & ListBox1.SelectedItem)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        On Error Resume Next

        Dim addr As String = current_addr & "\" & ListBox1.SelectedItem

        If pic_extension.Contains(IO.Path.GetExtension(addr)) Then
            '624, 561
            '1003, 561
            '624, 534
            '1003, 534
            '965, 534
            If search_time Then
                Me.Size = New Point(965, 561)
            Else
                Me.Size = New Point(965, 534)
            End If
            If Not PictureBox1.Image Is Nothing Then
                PictureBox1.Image.Dispose()
            End If
            PictureBox1.Image = Image.FromFile(addr)
            pic_addr = addr
            Exit Sub
        End If

        If Me.Location.X <> 624 Then
            If search_time Then
                Me.Size = New Point(624, 561)
            Else
                Me.Size = New Point(624, 534)
            End If
        End If

    End Sub

    Public Shared book_mark As New List(Of String)

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

        If Not PictureBox1.Image Is Nothing Then
            PictureBox1.Image.Dispose()
        End If

        For Each sr As String In book_mark
            'Directory.Move(sr & "\", svp)
            'My.Computer.FileSystem.CreateDirectory(svp & "\" & Path.GetFileName(sr))
            My.Computer.FileSystem.MoveDirectory(sr & "\", svp & "\" & Path.GetFileName(sr))
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim svp As String

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            svp = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        If Not PictureBox1.Image Is Nothing Then
            PictureBox1.Image.Dispose()
        End If

        For Each sr As String In book_mark
            My.Computer.FileSystem.CopyDirectory(sr & "\", svp & "\" & Path.GetFileName(sr))
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmBookmark.Show()
    End Sub

    Public Shared pic_addr As String
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        frmPicPreview.Show()
    End Sub

    Public Shared listbox_item_text As New ArrayList
    Public Shared listbox_folder_addr As String
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        listbox_folder_addr = current_addr
        If Not PictureBox1.Image Is Nothing Then
            PictureBox1.Image.Dispose()
        End If
        frmRename.Show()
    End Sub

    Dim df_Directories As New ArrayList
    Dim df_stringb As New StringBuilder
    Dim n_str As String

    Sub df_approach(fdrectory As String)
        On Error Resume Next
        n_str = fdrectory
        df_stringb.Append(fdrectory & "*")
        df_Directories.Add(fdrectory)
        If Directory.GetDirectories(fdrectory).Length Then
            For Each recu As String In Directory.GetDirectories(fdrectory)
                If Directory.Exists(recu) Then
                    df_approach(recu)
                End If
                Application.DoEvents()
            Next
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Dim svp As String
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            svp = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If

        '//////////////

        If Me.Location.X <> 624 Then
            Me.Size = New Point(624, 561)
        Else
            Me.Size = New Point(965, 561)
        End If

        My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\db")
        ProgressBar1.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        search_time = True
        Timer3.Interval = 50
        Timer3.Start()

        df_approach(svp)

        Timer3.Stop()
        df_Directories.Clear()
        ProgressBar1.Style = ProgressBarStyle.Blocks
        ProgressBar1.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        search_time = False

        '//////////////

        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(System.IO.Directory.GetCurrentDirectory & "\db\" & _
                                                       Path.GetFileName(FolderBrowserDialog1.SelectedPath) & ".sdb")
        If fileExists = True Then
            If MsgBox("이미 파일이 있습니다. 덮어쓰시겠습니까?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\db\" & _
                                Path.GetFileName(FolderBrowserDialog1.SelectedPath) & ".sdb", _
                                FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                fileExists = False
            End If
        End If

        If fileExists Then
            Return
        End If
        My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp")
        File.WriteAllText(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", df_stringb.ToString)
        df_stringb.Clear()
        IO.Compression.ZipFile.CreateFromDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp", _
                                                   System.IO.Directory.GetCurrentDirectory & "\db\" & _
                                                   Path.GetFileName(FolderBrowserDialog1.SelectedPath) & ".sdb")
        My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", _
                                          FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Directory.Delete(System.IO.Directory.GetCurrentDirectory & "\tmp")
        MsgBox("데이터베이스 작성이 완료되었습니다.", MsgBoxStyle.Information)

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Label1.Text = "Status : " & df_Directories.Count
        'Label2.Text = n_str
        Label2.Text = CompactString(n_str, Me.Location.X - Label2.Location.X, Label2.Font, TextFormatFlags.PathEllipsis)

        Application.DoEvents()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Dim svp As String
        Dim f = OpenFileDialog1.ShowDialog()

        If f = DialogResult.OK Then
            svp = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If

        list_array(svp)

    End Sub

    Private Sub list_array(ByVal svp As String)

        FolderGrid.Clear()

        '
        '   \tmp를 생성하여 압축을 풀은 뒤 데이터를 모두 읽고 \tmp삭제
        '
        My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp")
        IO.Compression.ZipFile.ExtractToDirectory(svp, System.IO.Directory.GetCurrentDirectory & "\tmp")
        Try
            FolderGrid.AddRange(File.ReadAllText(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp").Split({"*"c}))
        Catch ex As Exception
            'MsgBox("이 데이터베이스는 너무 커서 x86모드로 열 수 없습니다.", MsgBoxStyle.Critical)
            MsgBox("이 데이터베이스는 너무 커서 열 수 없습니다.", MsgBoxStyle.Critical)
            Exit Sub
        End Try
        My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", _
                                           FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Directory.Delete(System.IO.Directory.GetCurrentDirectory & "\tmp")

        TreeView1.Nodes.Clear()
        ListBox1.Items.Clear()
        Me.Size = New Point(624, 561)
        Label1.Visible = True
        Label2.Visible = True
        ProgressBar1.Visible = True
        Label1.Text = "폴더 나열중..."
        list_treeview()

        Label1.Visible = False
        Label2.Visible = False
        ProgressBar1.Visible = False
        Me.Size = New Point(624, 534)

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        TreeView1.Nodes.Clear()
        ListBox1.Items.Clear()
        Me.Size = New Point(624, 561)
        Label1.Visible = True
        Label2.Visible = True
        ProgressBar1.Visible = True
        Label1.Text = "폴더 나열중..."
        list_treeview()

        Label1.Visible = False
        Label2.Visible = False
        ProgressBar1.Visible = False
        Me.Size = New Point(624, 534)

    End Sub

End Class