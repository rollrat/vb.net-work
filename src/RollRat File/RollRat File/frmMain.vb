Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.AccessControl
Imports System.Threading

Public Class frmMain
    ' 이 파일은 UAC Manifest Option일부가 수정됨.
    'http://researchaholic.com/2010/07/15/how-to-set-an-exe-to-require-admin-authority-uac-on-launch/
    '
    ' Drag & Drop 기능 상실시 https://connect.microsoft.com/VisualStudio/feedback/details/537964/drag-and-drop-to-open-file-is-not-working-when-run-as-administrator
    ' 를 방문하거나 IDE를 최신 버전으로 업데이트 또는
    ' 바이져(관리자)모드를 비활성화 시켜 릴리즈 하십시오.
    '
    ' Win7 8 8.1 에서 확인됨.

    ' .{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}
    Dim Directories As New ArrayList
    Public Shared Files As New ArrayList
    Dim stringb As New StringBuilder
    Dim indexedF As Long = 0
    Dim loadicon As Boolean = False
    Dim lc As Long = 0
    Dim dirCount = 0
    Dim cf_dirCount = 0
    Dim array_ext As String() = {".txt", ".c", ".cpp", ".h", ".hpp", ".vb", ".xml", ".log", ".html", ".java", ".php", ".cs"}
    Dim d_d_mode As Boolean = False
    Dim n_str As String
    Dim safe_mode As Boolean = True

    '[0] File Index, GetDirs Function, Daniel Valland, v27NNpyOGMg
    '[1] Microsoft Example, library/c1sez4sc(v=vs.110).aspx
    Sub approach(fdrectory As String)
        On Error Resume Next
        n_str = fdrectory
        Directories.Add(fdrectory)
        If Directory.GetDirectories(fdrectory).Length Then
            For Each recu As String In Directory.GetDirectories(fdrectory)
                If Directory.Exists(recu) Then
                    approach(recu)
                    Directories.Add(recu)
                End If
                Application.DoEvents()
            Next
        End If
    End Sub

    '[0] File Index, GetDirs Function, Daniel Valland, v27NNpyOGMg
    Sub getfile(directory As String)
        On Error Resume Next
        For Each di In (New IO.DirectoryInfo(directory)).GetFiles()
            n_str = di.ToString
            If directory.EndsWith("\") = False Then
                stringb.Append(directory & "\" & di.ToString & "*")
            Else
                stringb.Append(directory & di.ToString & "*")
            End If
            indexedF += 1
            Application.DoEvents()
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileExists As Boolean
        dirCount = 0
        fileExists = My.Computer.FileSystem.FileExists(System.IO.Directory.GetCurrentDirectory & "\file.db")
        If fileExists = True Then
            If MsgBox("이미 파일이 있습니다. 덮어쓰시겠습니까?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\file.db", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
            Else
                Return
            End If
        End If
        ToolStripStatusLabel1.Font = New Font(ToolStripStatusLabel1.Font, FontStyle.Bold)
        Timer1.Interval = 50
        Timer1.Start()
        approach(TextBox1.Text)
        Timer1.Interval = 30
        For Each Directory As String In Directories
            dirCount += 1
            getfile(Directory)
            'ListView1.Items.Add(New ListViewItem(Directory))
        Next
        Timer1.Stop()
        Directories.Clear()
        My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp")
        File.WriteAllText(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", stringb.ToString)
        stringb.Clear()
        IO.Compression.ZipFile.CreateFromDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp", System.IO.Directory.GetCurrentDirectory & "\file.db")
        My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Directory.Delete(System.IO.Directory.GetCurrentDirectory & "\tmp")
        MsgBox("데이터베이스 작성이 완료되었습니다.", MsgBoxStyle.Information)
        ToolStripStatusLabel1.Font = New Font(ToolStripStatusLabel1.Font, FontStyle.Regular)
        ToolStripStatusLabel3.Text = ""
        ToolStripProgressBar1.Value = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp")
        IO.Compression.ZipFile.ExtractToDirectory(System.IO.Directory.GetCurrentDirectory & "\file.db", System.IO.Directory.GetCurrentDirectory & "\tmp")
        Files.AddRange(File.ReadAllText(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp").Split({"*"c}))
        My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Directory.Delete(System.IO.Directory.GetCurrentDirectory & "\tmp")

        MsgBox(Files.Count & "개의 데이터가 로딩됨.", MsgBoxStyle.Information)
        Button2.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListView1.Items.Clear()
        Dim at As Integer = 1
        For Each a As String In Directory.GetDirectories(TextBox1.Text)
            Dim strArray = New String() {at, a}
            Dim lvt = New ListViewItem(strArray)
            ListView1.Items.Add(lvt)
            at += 1
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListView1.Items.Clear()
        lc = 0
        Dim diar1 As IO.FileInfo() = (New IO.DirectoryInfo(TextBox1.Text)).GetFiles()
        If loadicon Then
            ListView1.SmallImageList = ImageList1
            For Each dra In diar1
                Dim iconForFile As Icon = SystemIcons.WinLogo
                If Not (ImageList1.Images.ContainsKey(dra.Name)) Then
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(dra.FullName)
                    ImageList1.Images.Add(dra.Name, iconForFile)
                End If
            Next
            Dim a As Integer = 1
            For Each dra In diar1
                Dim strArray = New String() {a, dra.Name, Convert.ToInt32(dra.Length / 1000).ToString("#,#.#") & " KB", dra.FullName}
                Dim lvt = New ListViewItem(strArray, dra.Name)
                ListView1.Items.Add(lvt)
                a += 1
            Next
        Else
            ListView1.SmallImageList = Nothing
            Dim a As Integer = 1
            For Each dra In diar1
                Dim strArray As String()
                If (Convert.ToInt32(Math.Round(dra.Length / 1000)) = 0) Then
                    strArray = New String() {a, dra.Name, 0 & " KB", dra.FullName}
                Else
                    If array_ext.Contains(dra.Extension) Then
                        lc += File.ReadAllLines(dra.FullName).Length
                        strArray = New String() {a, dra.Name, Convert.ToInt32(Math.Round(dra.Length / 1000)).ToString("#,#") & " KB", dra.FullName, File.ReadAllLines(dra.FullName).Length.ToString("#,#") & " LB"}
                    Else
                        strArray = New String() {a, dra.Name, Convert.ToInt32(Math.Round(dra.Length / 1000)).ToString("#,#") & " KB", dra.FullName}
                    End If
                End If
                Dim lvt = New ListViewItem(strArray)
                ListView1.Items.Add(lvt)
                a += 1
            Next
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        FolderBrowserDialog1.ShowDialog()
        If FolderBrowserDialog1.SelectedPath <> "" Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
        Button4.PerformClick()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox2.Text = "" Then
            MsgBox("확장자가 공백일 수 없습니다.", MsgBoxStyle.Critical)
            Return
        End If
        For Each a In ListView1.SelectedItems
            My.Computer.FileSystem.RenameFile(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & "." & TextBox2.Text)
        Next
        Button4.PerformClick()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(ListView1.SelectedItems(0).SubItems(1).Text)

        If folderExists Then
            TextBox1.Text = ListView1.SelectedItems(0).SubItems(1).Text
            ListView1.SmallImageList = Nothing
            ListView1.Items.Clear()
            Try
                ListView1.Items.Add(New ListViewItem(New String() {"...", Directory.GetParent(TextBox1.Text).FullName}))
            Catch ex As Exception
            End Try
            Dim at As Integer = 1
            For Each a As String In Directory.GetDirectories(TextBox1.Text)
                Dim strArray = New String() {at, a}
                Dim lvt = New ListViewItem(strArray)
                ListView1.Items.Add(lvt)
                at += 1
            Next
        Else
            Process.Start(ListView1.SelectedItems(0).SubItems(3).Text)
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        'RichTextBox1.Clear()
        'For Each a In ListView1.SelectedItems
        '    RichTextBox1.AppendText(a.SubItems(1).text & vbCrLf)
        'Next
    End Sub

    Dim index_count As Long = 1

    Private Sub ListView_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListView_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Button6.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            'Button20.Enabled = False
            TextBox1.Enabled = False
            Button21.Visible = True
            If d_d_mode = False Then
                ListView1.Items.Clear()
                lc = 0
            End If
            d_d_mode = True
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each filePath As String In filePaths
                Dim LI As ListViewItem
                Dim folderExists As Boolean
                folderExists = My.Computer.FileSystem.DirectoryExists(filePath)

                If folderExists Then
                    Dim diar1 As IO.FileInfo() = (New IO.DirectoryInfo(filePath)).GetFiles()
                    For Each dra In diar1
                        Dim strArray As String()
                        If (Convert.ToInt32(Math.Round(dra.Length / 1000)) = 0) Then
                            strArray = New String() {index_count, dra.Name, 0 & " KB", dra.FullName}
                        Else
                            If array_ext.Contains(dra.Extension) Then
                                lc += File.ReadAllLines(dra.FullName).Length
                                strArray = New String() {index_count, dra.Name, Convert.ToInt32(Math.Round(dra.Length / 1000)).ToString("#,#") & " KB", dra.FullName, File.ReadAllLines(dra.FullName).Length.ToString("#,#") & " LB"}
                            Else
                                strArray = New String() {index_count, dra.Name, Convert.ToInt32(Math.Round(dra.Length / 1000)).ToString("#,#") & " KB", dra.FullName}
                            End If
                        End If
                        Dim lvt = New ListViewItem(strArray)
                        ListView1.Items.Add(lvt)
                        index_count += 1
                    Next

                    Continue For
                End If

                Dim fi As New FileInfo(filePath)

                If array_ext.Contains(fi.Extension) Then
                    lc += File.ReadAllLines(fi.FullName).Length
                    LI = New ListViewItem(New String() {index_count.ToString(), fi.Name, Convert.ToInt32(fi.Length / 1000).ToString("#,#.#") & " KB", fi.FullName, File.ReadAllLines(fi.FullName).Length.ToString("#,#") & " LB"})
                Else
                    LI = New ListViewItem(New String() {index_count.ToString(), fi.Name, Convert.ToInt32(fi.Length / 1000).ToString("#,#.#") & " KB", fi.FullName})
                End If

                index_count += 1
                ListView1.Items.Add(LI)
            Next filePath
        End If
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Button6.Enabled = True
        Button4.Enabled = True
        Button3.Enabled = True
        'Button20.Enabled = True
        TextBox1.Enabled = True
        Button21.Visible = False
        index_count = 1
        lc = 0
        d_d_mode = False
        ListView1.Items.Clear()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If OnlyNumberTextbox1.Text < 1 Then
            MsgBox("값은 0보다 커야합니다.", MsgBoxStyle.Critical)
            Return
        End If
        For Each a In ListView1.SelectedItems
            My.Computer.FileSystem.RenameFile(a.SubItems(3).text, Strings.Right(Path.GetFileNameWithoutExtension(a.SubItems(3).text), Path.GetFileNameWithoutExtension(a.SubItems(3).text).Length - Convert.ToInt32(OnlyNumberTextbox1.Text)) & Path.GetExtension(a.SubItems(3).text))
        Next
        Button4.PerformClick()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If OnlyNumberTextbox1.Text < 1 Then
            MsgBox("값은 0보다 커야합니다.", MsgBoxStyle.Critical)
            Return
        End If
        For Each a In ListView1.SelectedItems
            My.Computer.FileSystem.RenameFile(a.SubItems(3).text, Strings.Left(Path.GetFileNameWithoutExtension(a.SubItems(3).text), Path.GetFileNameWithoutExtension(a.SubItems(3).text).Length - Convert.ToInt32(OnlyNumberTextbox1.Text)) & Path.GetExtension(a.SubItems(3).text))
        Next
        Button4.PerformClick()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If TextBox4.Text = "" Then
            MsgBox("값이 공백일 수 없습니다.", MsgBoxStyle.Critical)
            Return
        End If
        For Each a In ListView1.SelectedItems
            My.Computer.FileSystem.RenameFile(a.SubItems(3).text, TextBox4.Text & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
        Next
        Button4.PerformClick()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If TextBox4.Text = "" Then
            MsgBox("값이 공백일 수 없습니다.", MsgBoxStyle.Critical)
            Return
        End If
        For Each a In ListView1.SelectedItems
            My.Computer.FileSystem.RenameFile(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & TextBox4.Text & Path.GetExtension(a.SubItems(3).text))
        Next
        Button4.PerformClick()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        For Each a In ListView1.SelectedItems
            My.Computer.FileSystem.RenameFile(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text))
        Next
        Button4.PerformClick()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        For Each a In ListView1.SelectedItems
            Dim at As Regex = New Regex(TextBox5.Text)
            Dim rt As Match = at.Match(Path.GetFileNameWithoutExtension(a.SubItems(3).text))
            My.Computer.FileSystem.RenameFile(a.SubItems(3).text, rt.Value & Path.GetExtension(a.SubItems(3).text))
        Next
        Button4.PerformClick()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        For Each a In ListView1.SelectedItems
            Dim at As Regex = New Regex(TextBox5.Text)
            Dim rt As Match = at.Match(a.SubItems(1).text)
            My.Computer.FileSystem.RenameFile(a.SubItems(3).text, rt.Value)
        Next
        Button4.PerformClick()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Processa(TextBox3.Text)
        'Button4.PerformClick()
    End Sub

    Public Sub Processa(ByVal str As String)
        If str = "" Then
            MsgBox("명령줄을 입력하십시오.", MsgBoxStyle.Critical)
            Return
        End If
        Processing_Multi(str)
    End Sub

    Function get_argument(ByVal args As String) As List(Of String)
        Dim strr As New List(Of String)
        Dim i As Integer = 0
        While i < args.Length
            If args(i) = """" Then
                Dim tmpstr As String = ""
                i += 1
                While args(i) <> """"
                    tmpstr += args(i)
                    i += 1
                    If i >= args.Length Then
                        MsgBox(tmpstr & "이 ""로 닫히지 않았습니다.", MsgBoxStyle.Critical)
                        Exit While
                    End If
                End While
                strr.Add(tmpstr)
                i += 1
            ElseIf args(i) <> " " Then
                Dim tmpstr As String = ""
                While args(i) <> " "
                    tmpstr += args(i)
                    i += 1
                    If i >= args.Length Then
                        Exit While
                    End If
                End While
                strr.Add(tmpstr)
                i += 1
            ElseIf args(i) = " " Then
                i += 1
            End If
        End While
        Return strr
    End Function

    Sub RenameFileWithSafeMode(left As String, right As String)
        My.Computer.FileSystem.RenameFile(left, right)
    End Sub

    Public Sub Processing_Multi(ByVal str As String)
        Dim strsing() As String = get_argument(str).ToArray
        If strsing.Length = 0 Then
            MsgBox("Error : Not to serve this item.", MsgBoxStyle.Critical)
            Return
        End If
        If strsing(0) = "/s" Then
            If strsing.Length < 2 Then
                MsgBox("명령줄 오류 :" & vbCrLf & vbCrLf & "/s [address]", MsgBoxStyle.Critical)
                Return
            End If
            Process.Start(strsing(1))
        ElseIf strsing(0) = "/r" Then
            If strsing.Length < 3 Then
                MsgBox("명령줄 오류 :" & vbCrLf & vbCrLf & "/r [target] [option] [value1, value2, ...]", MsgBoxStyle.Critical)
                Return
            End If
            If strsing(1) = "-sa" Then '// selected item add
                If strsing(2) = "nf" Then '// numberic first 증가

                    ''
                    ''  Number
                    ''
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nfr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nl" Then '// numberic last 증가
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nlr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i -= 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nfts" Then '// numberic to string first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i.ToString(strsing(4)) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nlts" Then '// numberic to string last
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i.ToString(strsing(4)) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nif" Then '// numberic insert first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)

                    If InStr(strsing(4), "{0}") Then
                        For Each a In ListView1.SelectedItems
                            RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            i += 1
                        Next
                    ElseIf InStr(strsing(4), "{1}") Then
                        For Each a In ListView1.SelectedItems
                            If i < 10 Then
                                RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Replace(strsing(4), "{1}", "0" & Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            Else
                                RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Replace(strsing(4), "{1}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            End If
                            i += 1
                        Next
                    End If
                ElseIf strsing(2) = "nil" Then '// numberic insert last
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrf" Then '// numberic first 증가

                    ''
                    ''  Number
                    ''
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nrfr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrl" Then '// numberic last 증가
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrlr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i -= 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrfts" Then '// numberic to string first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i.ToString(strsing(4)) & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nrlts" Then '// numberic to string last
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i.ToString(strsing(4)) & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrif" Then '// numberic insert first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nril" Then '// numberic insert last
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next


                    ''
                    ''  Trim
                    ''
                ElseIf strsing(2) = "ltrim" Then
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, LTrim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                ElseIf strsing(2) = "rtrim" Then
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, RTrim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                ElseIf strsing(2) = "trim" Then
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Trim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next

                    '    ''
                    '    ''  Sorting Listview
                    '    ''
                    'ElseIf strsing(2) = "sort" Then
                    '    If strsing.Length < 4 Then
                    '        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                    '        Return
                    '    End If

                End If
            ElseIf strsing(1) = "-aa" Then '// all item add
                If strsing(2) = "nf" Then '// numberic first


                    ''
                    ''  Number
                    ''
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nfr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nl" Then '// numberic last
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nlr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i -= 1
                    Next
                    i += 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nfts" Then '// numberic to string first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i.ToString(strsing(4)) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nlts" Then '// numberic to string last
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & i.ToString(strsing(4)) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next

                ElseIf strsing(2) = "nif" Then '// numberic insert first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)

                    If InStr(strsing(4), "{0}") Then
                        For Each a In ListView1.Items
                            RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            i += 1
                        Next
                    ElseIf InStr(strsing(4), "{1}") Then
                        For Each a In ListView1.Items
                            If i < 10 Then
                                RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Replace(strsing(4), "{1}", "0" & Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            Else
                                RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Replace(strsing(4), "{1}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            End If
                            i += 1
                        Next
                    End If
                ElseIf strsing(2) = "nil" Then '// numberic insert last
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrf" Then '// numberic first 증가

                    ''
                    ''  Number
                    ''
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nrfr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrl" Then '// numberic last 증가
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrlr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i -= 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrfts" Then '// numberic to string first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i.ToString(strsing(4)) & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nrlts" Then '// numberic to string last
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i.ToString(strsing(4)) & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nrif" Then '// numberic insert first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nril" Then '// numberic insert last
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetFileNameWithoutExtension(a.SubItems(3).text) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next


                    ''
                    ''  Trim
                    ''
                ElseIf strsing(2) = "ltrim" Then
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, LTrim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                ElseIf strsing(2) = "rtrim" Then
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, RTrim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                ElseIf strsing(2) = "trim" Then
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Trim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                End If





            ElseIf strsing(1) = "-s" Then '// selected item
                If strsing(2) = "nf" Then '// numberic first 증가

                    ''
                    ''  Number
                    ''
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nfr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nl" Then '// numberic last 증가
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nlr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i -= 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nfts" Then '// numberic to string first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i.ToString(strsing(4)) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nlts" Then '// numberic to string last
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, i.ToString(strsing(4)) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nif" Then '// numberic insert first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)

                    If InStr(strsing(4), "{0}") Then
                        For Each a In ListView1.SelectedItems
                            RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            i += 1
                        Next
                    ElseIf InStr(strsing(4), "{1}") Then
                        For Each a In ListView1.SelectedItems
                            If i < 10 Then
                                RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{1}", "0" & Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            Else
                                RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{1}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            End If
                            i += 1
                        Next
                    End If


                ElseIf strsing(2) = "nil" Then '// numberic insert last
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.SelectedItems
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next

                    ''
                    ''  Trim
                    ''
                ElseIf strsing(2) = "ltrim" Then
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, LTrim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                ElseIf strsing(2) = "rtrim" Then
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, RTrim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                ElseIf strsing(2) = "trim" Then
                    For Each a In ListView1.SelectedItems
                        RenameFileWithSafeMode(a.SubItems(3).text, Trim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next

                    '    ''
                    '    ''  Sorting Listview
                    '    ''
                    'ElseIf strsing(2) = "sort" Then
                    '    If strsing.Length < 4 Then
                    '        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                    '        Return
                    '    End If

                End If
            ElseIf strsing(1) = "-a" Then '// all item add
                If strsing(2) = "nf" Then '// numberic first


                    ''
                    ''  Number
                    ''
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nfr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nl" Then '// numberic last
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nlr" Then '// 감소
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i -= 1
                    Next
                    i += 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nfts" Then '// numberic to string first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i.ToString(strsing(4)) & Path.GetExtension(a.SubItems(3).text))
                        i += 1
                    Next
                ElseIf strsing(2) = "nlts" Then '// numberic to string last
                    Dim i As Integer
                    If strsing.Length < 4 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, i.ToString(strsing(4)) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next
                ElseIf strsing(2) = "nif" Then '// numberic insert first
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)

                    If InStr(strsing(4), "{0}") Then
                        For Each a In ListView1.Items
                            RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            i += 1
                        Next
                    ElseIf InStr(strsing(4), "{1}") Then
                        For Each a In ListView1.Items
                            If i < 10 Then
                                RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{1}", "0" & Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            Else
                                RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{1}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                            End If
                            i += 1
                        Next
                    End If


                ElseIf strsing(2) = "nil" Then '// numberic insert last
                    Dim i As Integer
                    If strsing.Length < 5 Then
                        MsgBox("옵션 argument가 부족합니다.", MsgBoxStyle.Critical)
                        Return
                    End If
                    i = strsing(3)
                    For Each a In ListView1.Items
                        i += 1
                    Next
                    i -= 1
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Replace(strsing(4), "{0}", Convert.ToString(i)) & Path.GetExtension(a.SubItems(3).text))
                        i -= 1
                    Next

                    ''
                    ''  Trim
                    ''
                ElseIf strsing(2) = "ltrim" Then
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, LTrim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                ElseIf strsing(2) = "rtrim" Then
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, RTrim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                ElseIf strsing(2) = "trim" Then
                    For Each a In ListView1.Items
                        RenameFileWithSafeMode(a.SubItems(3).text, Trim(Path.GetFileNameWithoutExtension(a.SubItems(3).text)) & Path.GetExtension(a.SubItems(3).text))
                    Next
                End If
            End If
        ElseIf strsing(0) = "/h" Then
            MsgBox("명령 사용 : " & vbCrLf & vbCrLf _
                  & "/s [address] : 프로그램 실행" & vbCrLf _
                  & "/r [target] [option] [value1, value2, ...]" & vbCrLf _
                  & "    -option -sa : 선택된 영역, 원제변경없이 처리" & vbCrLf _
                  & "            -aa : 모든 영역, 원제변경없이 처리" & vbCrLf _
                  & "            -s : 선택된 영역, 원제버리고 처리" & vbCrLf _
                  & "            -a : 모든 영역, 원제버리고 처리" & vbCrLf _
                  & "                      nf : 마지막에 숫자를 넣음 value 2부터 시작, 증가시키며 진행" & vbCrLf _
                  & "                      nfr : 마지막에 숫자를 넣음, value 2를 감소시키며 진행" & vbCrLf _
                  & "                      nl : 마지막에 숫자 넣음, 마지막부터 위로 올라오면서 역순으로 넣음" & vbCrLf _
                  & "                      nlr :  반대로 밑에서부터 감소시키며 넣음" & vbCrLf _
                  & "                      nfts : tostring format을 이용하여 넣음 nf형" & vbCrLf _
                  & "                      nlts : tostring format을 이용하여 넣음 nl형" & vbCrLf _
                  & "                      nif : {0}를 문장 중간에 삽입하여 순서대로 넣음" & vbCrLf _
                  & "                      nil : {0}를 문장 중간에 삽입하여 역순서대로 넣음" & vbCrLf _
                  & "                      nrf : 처음에 숫자를 넣음 value 2부터 시작, 증가시키며 진행" & vbCrLf _
                  & "                      nrfr : 처음에 숫자를 넣음, value 2를 감소시키며 진행" & vbCrLf _
                  & "                      nrl : 처음에 숫자 넣음, 마지막부터 위로 올라오면서 역순으로 넣음" & vbCrLf _
                  & "                      nrlr :  반대로 밑에서부터 감소시키며 넣음" & vbCrLf _
                  & "                      nrfts : tostring format을 이용하여 넣음 nf형" & vbCrLf _
                  & "                      nrlts : tostring format을 이용하여 넣음 nl형" & vbCrLf _
                  & "                      nrif : {0}를 문장 중간에 삽입하여 순서대로 넣음" & vbCrLf _
                  & "                      nril : {0}를 문장 중간에 삽입하여 역순서대로 넣음" & vbCrLf _
                  & "                      ltrim : 왼쪽 공백지움" & vbCrLf _
                  & "                      rtrim : 오른쪽 공백지움" & vbCrLf _
                  & "                      trim : 양쪽 공백지움" & vbCrLf _
                  & "/q : 프로그램 완전종료" & vbCrLf _
                  & "/i : information" & vbCrLf _
                  & "/spy : file/folder spy run" & vbCrLf _
                  & "/f : dblist view" & vbCrLf _
                  & "/safe [option] : 세이프 모드 제어 -option : true/false" & vbCrLf _
                  & "/c [option] : DB파일만들기 -option : fs#계층파일제작" & vbCrLf _
                  , MsgBoxStyle.Information)
        ElseIf strsing(0) = "/q" Then
            End
        ElseIf strsing(0) = "/i" Then
            diaInformation.Show()
        ElseIf strsing(0) = "/spy" Then
            frmSpy.Show()
        ElseIf strsing(0) = "/f" Then
            If Files.Count = 0 Then
                MsgBox("먼저 DB를 로드해야 합니다.", MsgBoxStyle.Critical)
                Return
            End If
            frmDBList.Show()
        ElseIf strsing(0) = "/safe" Then
            If strsing(1) = "true" Then
                safe_mode = True
            ElseIf strsing(1) = "false" Then
                If MsgBox("세이프 모드를 해제하면 중요파일들이 변경될 수 있습니다. 계속하시겠습니까?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    safe_mode = False
                End If
            Else
                MsgBox("알 수 없는 키워드 : " & strsing(1), MsgBoxStyle.Critical)
            End If
        ElseIf strsing(0) = "/c" Then
            If strsing(1) = "fs" Then
                My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\crt_filesystem")
                cf_dirCount = 0
                ToolStripStatusLabel1.Font = New Font(ToolStripStatusLabel1.Font, FontStyle.Bold)
                Timer2.Interval = 50
                Timer2.Start()
                Try
                    cf_approach(TextBox1.Text)
                Catch ex As Exception
                End Try
                Timer2.Interval = 30
                For Each Directory As String In cf_Directories
                    cf_dirCount += 1
                    Try
                        cf_getfile(Directory)
                    Catch ex As Exception
                        Continue For
                    End Try
                    Dim at As String = Directory.Replace("\"c, "$"c).Replace(":"c, ";"c)
                    If at.Length > 1000 Then
                        MsgBox("Skip : file name is too long : " & Directory & vbCrLf)
                        Continue For
                    End If
                    cf_stringb.Append(vbCrLf & vbCrLf & "File Count : " & (New IO.DirectoryInfo(Directory)).GetFiles().Length)
                    If cf_stringb.Length > 3 And at.Length > 4 And (New IO.DirectoryInfo(Directory)).GetFiles().Length > 0 Then
                        Try
                            File.WriteAllText(System.IO.Directory.GetCurrentDirectory & "\crt_filesystem\" & at & ".db", cf_stringb.ToString)
                        Catch ex As Exception
                        End Try
                    End If
                    cf_stringb.Clear()
                    cf_stringb.Append("RollRat Software File 1.3" & vbCrLf)
                    cf_stringb.Append("Copyright (c) rollrat. 2014. All rights reserved." & vbCrLf & vbCrLf)
                Next
                Timer2.Stop()
                cf_Directories.Clear()
                MsgBox("complete!")
            End If
        Else
            MsgBox("알 수 없는 명령입니다.", MsgBoxStyle.Critical)
        End If
    End Sub


    Dim cf_Directories As New ArrayList
    Dim cf_stringb As New StringBuilder

    Sub cf_approach(fdrectory As String)
        On Error Resume Next
        n_str = fdrectory
        cf_Directories.Add(fdrectory)
        If Directory.GetDirectories(fdrectory).Length Then
            For Each recu As String In Directory.GetDirectories(fdrectory)
                If Directory.Exists(recu) Then
                    cf_approach(recu)
                    cf_Directories.Add(recu)
                End If
                Application.DoEvents()
            Next
        End If
    End Sub

    Sub cf_getfile(directory As String)
        On Error Resume Next
        For Each di In (New IO.DirectoryInfo(directory)).GetFiles()
            n_str = di.ToString
            If directory.EndsWith("\") = False Then
                cf_stringb.Append(directory & "\" & di.ToString & vbCrLf)
            Else
                cf_stringb.Append(directory & di.ToString & vbCrLf)
            End If
            Application.DoEvents()
        Next
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim sort As New Sorter.ListViewSorter(ListView1)

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        frmSpy.Show()
    End Sub

    Dim ltv_opti As Boolean = False
    '695, 316
    '695, 157
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If ltv_opti = False Then
            If ListView1.SelectedItems.Count > 1 Then
                MsgBox("하나의 항목만 선택하십시오.", MsgBoxStyle.Critical)
                Return
            ElseIf ListView1.SelectedItems.Count = 0 Then
                MsgBox("항목을 선택하십시오.", MsgBoxStyle.Critical)
                Return
            End If

            For a = 1 To 316 - 157
                ListView1.Size = New Size(695, 316 - a)
                Thread.Sleep(0)
                'Application.DoEvents()
            Next
            ltv_opti = True

            Dim fileData As FileInfo
            fileData = My.Computer.FileSystem.GetFileInfo(ListView1.SelectedItems(0).SubItems(3).Text)

            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            Label7.Visible = True
            Label8.Visible = True
            Label9.Visible = True
            Label10.Visible = True


            Label2.Text = fileData.LastWriteTime
            Label3.Text = fileData.LastAccessTime
            Label5.Text = fileData.IsReadOnly
            Label7.Text = fileData.CreationTime
            Label9.Text = fileData.Attributes.ToString

            Button17.Enabled = False
            Button20.Enabled = False
        Else
t:
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Label8.Visible = False
            Label9.Visible = False
            Label10.Visible = False
            For a = 1 To 316 - 157
                ListView1.Size = New Size(695, 157 + a)
                Thread.Sleep(0)
                'Application.DoEvents()
            Next
            ltv_opti = False

            Button17.Enabled = True
            Button20.Enabled = True
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If Files.Count = 0 Then
            MsgBox("먼저 DB를 로드해야 합니다.", MsgBoxStyle.Critical)
            Return
        End If
        If ltv_opti = False Then
            For a = 1 To 316 - 157
                ListView1.Size = New Size(695, 316 - a)
                Thread.Sleep(0)
                'Application.DoEvents()
            Next
            ltv_opti = True
            Button18.Visible = True
            TextBox6.Visible = True
            RichTextBox1.Visible = True
            Button16.Enabled = False
            Button20.Enabled = False
        Else
            Button18.Visible = False
            TextBox6.Visible = False
            RichTextBox1.Visible = False
            For a = 1 To 316 - 157
                ListView1.Size = New Size(695, 157 + a)
                Thread.Sleep(0)
                'Application.DoEvents()
            Next
            ltv_opti = False
            Button16.Enabled = True
            Button20.Enabled = True
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim tmp_str As String = ""
        Dim count As Integer = 0
        Dim a As Integer = 0
        For Each File As String In Files
            If File.Contains(TextBox6.Text) Then
                tmp_str += File & vbCrLf
                count += 1
            End If
            a += 1
            Application.DoEvents()
        Next
        RichTextBox1.Text = tmp_str
        RichTextBox1.AppendText("-----------------------------------------------" & vbCrLf)
        RichTextBox1.AppendText("-Count : " & count & "/" & a & vbCrLf)
        RichTextBox1.AppendText("-----------------------------------------------" & vbCrLf)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        frmAnalyzer.Show()
    End Sub

    '// http://www.freevbcode.com/ShowCode.asp?ID=4287
    Function GetFolderSize(ByVal DirPath As String, Optional IncludeSubFolders As Boolean = True) As Long
        Dim lngDirSize As Long
        Dim objFileInfo As FileInfo
        Dim objDir As DirectoryInfo = New DirectoryInfo(DirPath)
        Dim objSubFolder As DirectoryInfo

        For Each objFileInfo In objDir.GetFiles()
            lngDirSize += objFileInfo.Length
        Next

        If IncludeSubFolders Then
            For Each objSubFolder In objDir.GetDirectories()
                lngDirSize += GetFolderSize(objSubFolder.FullName)
            Next
        End If

        Return lngDirSize
    End Function

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If ltv_opti = False Then
            For a = 1 To 316 - 157
                ListView1.Size = New Size(695, 316 - a)
                Thread.Sleep(0)
                'Application.DoEvents()
            Next
            ltv_opti = True

            If d_d_mode = False Then
                Label12.Text = GetFolderSize(TextBox1.Text)
            End If
            Label13.Text = lc

            Label11.Visible = True
            Label12.Visible = True
            Label13.Visible = True
            Label14.Visible = True

            Button17.Enabled = False
            Button16.Enabled = False
        Else
            Label11.Visible = False
            Label12.Visible = False
            Label13.Visible = False
            Label14.Visible = False

            For a = 1 To 316 - 157
                ListView1.Size = New Size(695, 157 + a)
                Thread.Sleep(0)
                'Application.DoEvents()
            Next
            ltv_opti = False

            Button17.Enabled = True
            Button16.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = "Status : " & dirCount & "/" & Directories.Count
        ToolStripStatusLabel3.Text = n_str

        Dim prog As Integer = Math.Round((dirCount / Directories.Count) * 100)
        ToolStripProgressBar1.Value = prog
        Application.DoEvents()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        frmFolder.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ToolStripStatusLabel1.Text = "Status : " & cf_dirCount & "/" & cf_Directories.Count
        ToolStripStatusLabel3.Text = n_str

        Dim prog As Integer = Math.Round((cf_dirCount / cf_Directories.Count) * 100)
        ToolStripProgressBar1.Value = prog
        Application.DoEvents()
    End Sub
End Class