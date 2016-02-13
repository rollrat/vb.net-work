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

Public Class frmMain

    Public TotalGrid As New ArrayList
    Public FolderGrid As New ArrayList
    Private count As Integer

    ' 이 값은 Math.tanh(i / 7)의 함숫값임.
    Public ReadOnly tanh_value As Double() = {0, 0.141893193766933, 0.278185490325702, 0.404126739757859, 0.51640765518518,
            0.613357260395383, 0.694782670314738, 0.761594155955765, 0.815373942495404, 0.857999961698402,
            0.891373467734719, 0.917252697879849, 0.93717125793686, 0.952414115203671, 0.964027580075817,
            0.972846166112511, 0.979525425675133, 0.984574576974176, 0.988385883107241, 0.991259640913111,
            0.993424677228132, 0.99505475368673, 0.996281474641925, 0.997204320833022, 0.997898380495443, 0.998420268116527}

    Public Shared Function CompactString(ByVal MyString As String, ByVal Width As Integer,
                    ByVal Font As Drawing.Font,
                    ByVal FormatFlags As TextFormatFlags) As String

        Dim Result As String = String.Copy(MyString)

        TextRenderer.MeasureText(Result, Font, New Drawing.Size(Width, 0),
            FormatFlags Or TextFormatFlags.ModifyString)

        Return Result

    End Function

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    '
    '   모든 리스트를 트리뷰에 나열합니다.
    '
    Dim globalcount As Integer
    Dim perpect_then_exit As Boolean = False
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim prog As Integer = Math.Round((count / FolderGrid.Count) * 100)
        ProgressBar1.Value = prog
        Application.DoEvents()
    End Sub
    Private Sub list_treeview()

        Timer2.Interval = 30
        Timer2.Start()
        count = 0
        perpect_then_exit = False

        Dim j As Integer = 0

        '
        '   DB파일의 최상위 폴더를 가져옴
        '
        top_addr = Path.GetDirectoryName(FolderGrid(0)) & "\"
        If top_addr.EndsWith("\\") Then

            '
            '   최상위 폴더(드라이브 폴더)에 포함된 폴더에 대한 대비
            '
            top_addr = top_addr.Substring(0, top_addr.Length - 1)
        End If
        For i As Integer = 0 To FolderGrid.Count - 1
            count = i
            Application.DoEvents()
            Dim first As String = Path.GetFileName(FolderGrid(i))
            If first.Length > 0 Then
                TreeView1.Nodes.Add(first)
            Else
                TreeView1.Nodes.Add(FolderGrid(i).ToString().Substring(0, 2))

                '
                '   최상위 폴더가 드라이브일 경우 모든 디렉터리가 트리에 표현되므로
                '   top_addr를 생략해 검색을 편리하게함.
                '
                top_addr = ""
            End If

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

            i = globalcount
            j += 1
        Next

        Timer2.Stop()
    End Sub
    Private Sub integernal_list_treeview(ByVal obstr As String, ByVal panode As TreeNode)
        Application.DoEvents()
        For i As Integer = globalcount + 1 To FolderGrid.Count - 1
            count = i
            If CType(FolderGrid(i), String).Contains(obstr & "\") Then
                Label2.Text = CompactString(Path.GetFileName(FolderGrid(i)), Me.Location.X - Label2.Location.X, Label2.Font, TextFormatFlags.PathEllipsis)
                Dim chnode As New TreeNode(Path.GetFileName(FolderGrid(i)))
                panode.Nodes.Add(chnode)

                globalcount = i

                '
                '   globalcount 는 FolderGrid.Count - 1이 되면 이 부분에서 무한 재귀를 일으키므로
                '   perpect_then_exit전역변수를 만들어 모든 재귀 루프가 끝나도록 설정함
                '
                If globalcount = FolderGrid.Count - 1 Then
                    perpect_then_exit = True
                    Exit Sub
                End If
                If CType(FolderGrid(i + 1), String).Contains(FolderGrid(i) & "\") Then
                    integernal_list_treeview(FolderGrid(i), chnode)
                    If perpect_then_exit Then
                        Exit Sub
                    End If
                    i = globalcount - 1
                Else

                End If
            Else
                globalcount = i
                Exit Sub
            End If
        Next
    End Sub

    '
    '   DB의 최상위 항목(최상위층 폴더)
    '
    Public top_addr As String = ""

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim current_addr As String = top_addr & TreeView1.SelectedNode.FullPath & "\"

        '
        '   트리뷰 클릭시 리스트 박스 아이템 재설정
        '
        ListBox1.Items.Clear()
        For i As Integer = 0 To TotalGrid.Count - 1
            Dim str As String = TotalGrid(i).ToString()
            If str.StartsWith(current_addr) Then
                If Not str.Contains("\|") Then
                    str = str.Split("|"c)(0).Substring(current_addr.Length)
                    If Not str.Contains("\") Then
                        ListBox1.Items.Add(Path.GetFileName(TotalGrid(i).Split("|"c)(0)))
                    End If
                Else
                    Dim splits As String() = str.Split("|"c)
                    Label4.Text = 0
                    Label9.Text = DateTime.FromFileTime(splits(1)).ToString
                    Label10.Text = DateTime.FromFileTime(splits(2)).ToString
                    Label11.Text = DateTime.FromFileTime(splits(3)).ToString
                End If
            End If
        Next
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim f = OpenFileDialog1.ShowDialog()
        Dim last_sdb_addr As String

        If f = DialogResult.OK Then
            last_sdb_addr = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If

        Button10.Enabled = False

        list_array(last_sdb_addr)

        Button10.Enabled = True
    End Sub

    Private Sub list_array(ByVal svp As String)
        TotalGrid.Clear()
        FolderGrid.Clear()

        '
        '   \tmp를 생성하여 압축을 풀은 뒤 데이터를 모두 읽고 \tmp삭제
        '
        My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp")
        IO.Compression.ZipFile.ExtractToDirectory(svp, System.IO.Directory.GetCurrentDirectory & "\tmp")
        Try
            TotalGrid.AddRange(File.ReadAllText(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp").Split({"*"c}))
        Catch ex As Exception
            'MsgBox("이 데이터베이스는 너무 커서 x86모드로 열 수 없습니다.", MsgBoxStyle.Critical)
            MsgBox("이 데이터베이스는 너무 커서 열 수 없습니다.", MsgBoxStyle.Critical)
            Exit Sub
        End Try
        My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", _
                                           FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Directory.Delete(System.IO.Directory.GetCurrentDirectory & "\tmp")

        ' 귀찮으니 한 곳에 다 꼴아 박는다.
        For Each specific As String In TotalGrid
            If specific.Contains("\|") Then
                Dim splits As String = specific.Split("|"c)(0)
                FolderGrid.Add(splits.Substring(0, splits.Length - 1))
            End If
        Next

        refresh_sdb()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        refresh_sdb()
    End Sub

    Private Sub refresh_sdb()
        TreeView1.Nodes.Clear()
        ListBox1.Items.Clear()
        Label1.Visible = True
        Label2.Visible = True
        Button10.Enabled = False
        ProgressBar1.Visible = True
        Label1.Text = "폴더 나열중..."
        Application.DoEvents()
        FormSizeEffectingAuto(New Point(1239, 561))
        list_treeview()

        Label2.Visible = False
        FormSizeEffectingAuto(New Point(1239, 534))
        Label1.Visible = False
        ProgressBar1.Visible = False
        Button10.Enabled = True

    End Sub

    '
    '   트리뷰의 주소를 이용하여 특정한 노드를 찾아 확장합니다.
    '
    Dim deepinloop As Integer
    Dim deepinstr As String()
    Public Sub ExpandByFullPath(ByVal str As String)
        Dim strstr As String() = str.Split("\"c)
        For Each tn As TreeNode In TreeView1.Nodes
            If tn.Text = strstr(0) Then
                deepinloop = 0
                deepinstr = strstr
                __internal_iterate_expandbyfullpath(tn)
            End If
        Next
    End Sub
    Public Sub __internal_iterate_expandbyfullpath(node As TreeNode)
        node.Expand()
        If deepinloop = deepinstr.Length - 1 Then
            TreeView1.Focus()
            TreeView1.SelectedNode = node
            Exit Sub
        End If
        deepinloop += 1
        For Each tn As TreeNode In node.Nodes
            If tn.Text = deepinstr(deepinloop) Then
                __internal_iterate_expandbyfullpath(tn)
            End If
        Next
    End Sub
    Public Sub FindAndExpand(ByVal addr As String)
        ExpandByFullPath(addr.Substring(top_addr.Length))
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim cti As String = ListBox1.SelectedItem.ToString
        If cti <> "" Then
            Dim current_addr As String = top_addr & TreeView1.SelectedNode.FullPath & "\" & cti
            For Each istr As String In TotalGrid
                If istr.StartsWith(current_addr) Then
                    Dim splits As String() = istr.Split("|"c)
                    If Convert.ToInt64(splits(1) \ 1024) = 0 Then
                        Label4.Text = "0 KB"
                    Else
                        Label4.Text = (Convert.ToInt64(splits(1)) \ 1024).ToString("#,#") & " KB"
                    End If
                    Label9.Text = DateTime.FromFileTime(splits(2)).ToString
                    Label10.Text = DateTime.FromFileTime(splits(3)).ToString
                    Label11.Text = DateTime.FromFileTime(splits(4)).ToString
                    Exit For
                End If
            Next
        End If
    End Sub

    '
    '   사용하기 쉽게 함수로 만듦
    '
    Private Sub FormSizeEffectingAuto(ByVal size As Size, Optional ByVal ExpandWithEvents As Boolean = True)
        Dim originw As Integer = Me.Width
        Dim originh As Integer = Me.Height
        If Me.Size = size Then
            Exit Sub
        End If
        Dim exsizew As Integer = Math.Abs(originw - size.Width)
        Dim exsizeh As Integer = Math.Abs(originh - size.Height)
        If originw < size.Width Then
            For i As Integer = 0 To 25
                Me.Width = originw + exsizew * tanh_value(i)
                If ExpandWithEvents Then
                    Application.DoEvents()
                End If
                Threading.Thread.Sleep(10)
            Next
        Else
            For i As Integer = 0 To 25
                Me.Width = originw - exsizew * tanh_value(i)
                If ExpandWithEvents Then
                    Application.DoEvents()
                End If
                Threading.Thread.Sleep(10)
            Next
        End If
        If originh < size.Height Then
            For i As Integer = 0 To 25
                Me.Height = originh + exsizeh * tanh_value(i)
                If ExpandWithEvents Then
                    Application.DoEvents()
                End If
                Threading.Thread.Sleep(10)
            Next
        Else
            For i As Integer = 0 To 25
                Me.Height = originh - exsizeh * tanh_value(i)
                If ExpandWithEvents Then
                    Application.DoEvents()
                End If
                Threading.Thread.Sleep(10)
            Next
        End If
        Me.Size = size
    End Sub

End Class