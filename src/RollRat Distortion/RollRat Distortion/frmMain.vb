'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO
Imports System.Text
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.ComponentModel
Imports System.Threading
Imports System.Text.RegularExpressions

Public Class frmMain

    Dim status As Integer = 0
    Dim lFound As Integer
    Dim escapeLoop As Boolean = False
    Dim index As Integer = 0
    Dim ready As Boolean = False
    Dim notallowsyntax As Boolean = False

    Public Shared array_ext() As String
    Public Shared LoadFiles As New ArrayList
    Public Shared result As New List(Of List(Of String))
    Public Shared seletedindex As Integer
    Public Shared filename As String
    Public Shared loadDb As String

    Public Shared sdb_opened As Boolean = False
    Public Shared sdb_global_filename As String
    Public Shared ignore_open As Boolean = False

    Dim str As New StringBuilder

    Function CompactString(ByVal MyString As String, ByVal Width As Integer,
                    ByVal Font As Drawing.Font,
                    ByVal FormatFlags As TextFormatFlags) As String

        Dim Result As String = String.Copy(MyString)

        TextRenderer.MeasureText(Result, Font, New Drawing.Size(Width, 0),
            FormatFlags Or TextFormatFlags.ModifyString)

        Return Result

    End Function

    Private SearhThread As Thread

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ready Then
            MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If LoadFiles.Count = 0 Then
            MsgBox("DB를 먼저 로드하시기 바랍니다.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        SearchTask()

    End Sub

    Private Sub SearchTask()
        Dim srt_first As Boolean = True

        str.Clear()
        ListView1.Items.Clear()
        index = 0
        lFound = 0
        ready = True
        ProgressBar1.Visible = True
        Timer1.Start()
        status = 0
        escapeLoop = False
        TextBox1.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False

        For Each File As String In LoadFiles
            If escapeLoop Then
                Exit For
            End If
            On Error Resume Next
            status += 1

            '
            '   주소를 줄여서 출력할 때 쓰이는 부분
            '
            Label2.Text = CompactString(File, ListView1.Width, Label2.Font, TextFormatFlags.PathEllipsis)

            If Not notallowsyntax And array_ext.Contains(IO.Path.GetExtension(File)) Then

                '
                '   디폴트 옵션으로하면 자동으로 잡아주더라
                '
                Dim srt As StreamReader = New StreamReader(File, Encoding.Default)
                Dim linetext As String
                Dim line As Integer = 0
                Dim count As Integer = 0
                Dim startalreay As Boolean = False
                Do
                    linetext = srt.ReadLine()

                    '
                    '   가끔 이런게 올라오더라고요
                    '
                    If linetext = Nothing Then
                        If srt.EndOfStream Then
                            Exit Do
                        End If
                    End If

                    line += 1

                    Dim match2 As System.Text.RegularExpressions.Match
                    Dim origin As String = linetext

                    match2 = System.Text.RegularExpressions.Regex.Match(linetext, TextBox1.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

                    If match2.Success Then
                        linetext = "<" & match2.Captures(0).ToString & "|" & line & "|" & File & ">"
                        count += 1
                        lFound += 1

                        '
                        '   한 파일에서 여러개를 검사할 경우 세트됨
                        '
                        If startalreay Then

                            '
                            '   줄 표시 숫자를 추가할 것인가의 여부
                            '
                            If srt_first = True Then
                                srt_first = False
                            Else
                                str.Append(vbCrLf)
                            End If
                            str.Append(linetext)

                        Else
                            startalreay = True
                            index += 1

                            '
                            '   새로운 배열에 리스트를 추가함
                            '
                            result.Add(New List(Of String))
                        End If

                        '
                        '   index는 현재까지 센 줄의 개수를 의미하므로 -1을 더해야됨
                        '
                        result(index - 1).Add(line & ": " & linetext)
                    End If
                    Application.DoEvents()
                Loop

                srt.Close()

                '
                '   1개 이상의 줄이 파일에서 일치할 경우
                '
                If startalreay Then
                    Dim strArray = New String() {index, File, count}
                    Dim lvt = New ListViewItem(strArray)
                    ListView1.Items.Add(lvt)
                End If
            End If
            Application.DoEvents()
        Next
FORCEEND:
        Timer1.Stop()
        Label3.Text = ""
        Label4.Text = ""
        Label2.Text = ""

        Dim fileData As FileInfo
        fileData = My.Computer.FileSystem.GetFileInfo(loadDb)

        status = 0
        ready = False
        ProgressBar1.Visible = False
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(IO.Path.GetDirectoryName(loadDb) & "\" & _
                            IO.Path.GetFileNameWithoutExtension(loadDb) & ".txt")
        If fileExists = True Then
            If MsgBox("이미 파일이 있습니다. 덮어쓰시겠습니까?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile(IO.Path.GetDirectoryName(loadDb) _
                        & "\" & IO.Path.GetFileNameWithoutExtension(loadDb) & ".txt", _
                        FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                '
                '   이것이 false이면 저장하지 못함
                '
                fileExists = False
            End If
        End If
        TextBox1.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        If fileExists Then
            Return
        End If

        '
        '   정렬
        '
        Dim a As New RichTextBox
        a.Text = str.ToString()
        str.Clear()
        result.Clear()
        ListView1.Items.Clear()
        a.Lines = (From value In a.Lines Select value Distinct Order By value).ToArray

        IO.File.WriteAllText(IO.Path.GetDirectoryName(loadDb) & "\" & IO.Path.GetFileNameWithoutExtension(loadDb) & ".txt", _
                             "// This file auto created by RollRat Distortion Tool " & Version.VersionText & _
                             vbCrLf & vbCrLf & a.Text)
        MsgBox("탐색이 완료되었습니다.", MsgBoxStyle.Information)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        '
        '   실행중인 스레드까지 모두 종료
        '
        End
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = "Status: " & status & "/" & LoadFiles.Count
        Label4.Text = "Found: " & lFound

        Dim prog As Integer = Math.Round((status / LoadFiles.Count) * 100)
        ProgressBar1.Value = prog
        Application.DoEvents()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim svp As String
        Dim sec As Boolean = False
        Dim f = OpenFileDialog1.ShowDialog()
        If ready Then
            MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        sdb_opened = False
        If f = DialogResult.OK Then
            loadDb = OpenFileDialog1.FileName
            svp = loadDb

            LoadFiles.Clear()

            '
            '   \tmp를 생성하여 압축을 풀은 뒤 데이터를 모두 읽고 \tmp삭제
            '
            My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp")
            IO.Compression.ZipFile.ExtractToDirectory(svp, System.IO.Directory.GetCurrentDirectory & "\tmp")
            Try
                LoadFiles.AddRange(File.ReadAllText(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp").Split({"*"c}))
            Catch ex As Exception
                'MsgBox("이 데이터베이스는 너무 커서 x86모드로 열 수 없습니다.", MsgBoxStyle.Critical)
                MsgBox("이 데이터베이스는 너무 커서 열 수 없습니다.", MsgBoxStyle.Critical)
            End Try
            My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", _
                                               FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Directory.Delete(System.IO.Directory.GetCurrentDirectory & "\tmp")
            Label6.Text = Path.GetFileNameWithoutExtension(svp) & "/ Files: " & LoadFiles.Count
            If sec Then
                File.Delete(svp)
            End If
        End If
    End Sub

    Dim n_str As String
    Dim df_dirCount = 0
    Dim indexedF As Long = 0

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ready Then
            MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim svp As String
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            svp = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If
        '//////////////
        ProgressBar1.Visible = True

        '
        '   이 Marquee옵션을 설정하면 폴더를 탐색하는 동안 ProgressBar의 블록이 움직임
        '
        ProgressBar1.Style = ProgressBarStyle.Marquee
        My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\db")
        df_dirCount = 0
        Timer2.Interval = 50
        ready = True
        escapeLoop = False
        Timer2.Start()

        '
        '   폴더 검색
        '
        df_approach(svp)
        Timer2.Interval = 30

        '
        '   이 코드는 폴더탐색중에 설정된 Marquee를 기본형으로 바꾸어줌
        '
        ProgressBar1.Style = ProgressBarStyle.Blocks

        '
        '   ./Path추출을 위해 기본 주소 입력 Ver >= 1.4.1
        '
        df_stringb.Append(svp & "*")

        For Each Directory As String In df_Directories
            If escapeLoop Then
                Exit For
            End If
            df_dirCount += 1
            Try
                df_getfile(Directory)
            Catch ex As Exception
                Continue For
            End Try
        Next

        Timer2.Stop()
        df_Directories.Clear()
        ready = False
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(System.IO.Directory.GetCurrentDirectory & "\db\" & _
                                                       Path.GetFileName(FolderBrowserDialog1.SelectedPath) & ".db")
        If fileExists = True Then
            If MsgBox("이미 파일이 있습니다. 덮어쓰시겠습니까?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\db\" & _
                                Path.GetFileName(FolderBrowserDialog1.SelectedPath) & ".db", _
                                FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                fileExists = False
            End If
        End If
        ProgressBar1.Visible = False
        Label3.Text = ""
        Label4.Text = ""
        Label2.Text = ""

        '
        '   파일을 생성하지 않음
        '
        If fileExists Then
            Return
        End If
        My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp")
        File.WriteAllText(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", df_stringb.ToString)
        df_stringb.Clear()
        IO.Compression.ZipFile.CreateFromDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp", _
                                                   System.IO.Directory.GetCurrentDirectory & "\db\" & _
                                                   Path.GetFileName(FolderBrowserDialog1.SelectedPath) & ".db")
        My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", _
                                          FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Directory.Delete(System.IO.Directory.GetCurrentDirectory & "\tmp")
        MsgBox("데이터베이스 작성이 완료되었습니다.", MsgBoxStyle.Information)
    End Sub

    Dim df_Directories As New ArrayList
    Dim df_stringb As New StringBuilder

    Sub df_approach(fdrectory As String)
        On Error Resume Next
        n_str = fdrectory

        '
        '   디렉토리의 계층 구조 표현을 위해 추가 Ver >= 3.0
        '
        df_Directories.Add(fdrectory)
        If Directory.GetDirectories(fdrectory).Length Then
            For Each recu As String In Directory.GetDirectories(fdrectory)
                If escapeLoop Then
                    Exit For
                End If
                If Directory.Exists(recu) Then
                    df_approach(recu)
                    df_Directories.Add(recu)
                End If
                Application.DoEvents()
            Next
        End If
    End Sub

    Sub df_getfile(directory As String)
        On Error Resume Next
        df_stringb.Append(directory & "*")
        For Each di In (New IO.DirectoryInfo(directory)).GetFiles()
            If escapeLoop Then
                Exit For
            End If
            n_str = di.ToString

            If directory.EndsWith("\") = False Then
                df_stringb.Append(directory & "\" & n_str & "*")
            Else
                df_stringb.Append(directory & n_str & "*")
            End If
            indexedF += 1
            Application.DoEvents()
        Next
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label3.Text = "Status : " & df_dirCount & "/" & df_Directories.Count
        'Label2.Text = n_str
        Label2.Text = CompactString(n_str, ListView1.Width, Label2.Font, TextFormatFlags.PathEllipsis)

        Dim prog As Integer = Math.Round((df_dirCount / df_Directories.Count) * 100)
        ProgressBar1.Value = prog
        Application.DoEvents()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        seletedindex = ListView1.SelectedItems(0).SubItems(0).Text
        filename = ListView1.SelectedItems(0).SubItems(1).Text
        frmResult.Show()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown

        '
        '   이 이벤트는 frmMain자체에서 진행하게 하려면 KeyPreview를 활성화하여야함
        '
        If e.KeyCode = Keys.F2 Then
            escapeLoop = True
            Exit Sub
        ElseIf e.KeyCode = Keys.F7 Then
            If ready Then
                MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical, "RollRat Distortion")
                Exit Sub
            End If
            frmExtension.Show()
        ElseIf e.KeyCode = Keys.F3 Then
            If str.Length = 0 Then
                MsgBox("내역 없음!", MsgBoxStyle.Critical, "RollRat Distortion")
            Else
                Dim a As New RichTextBox
                a.Text = str.ToString()
                str.Clear()
                result.Clear()
                ListView1.Items.Clear()
                a.Lines = (From value In a.Lines Select value Distinct Order By value).ToArray

                IO.File.WriteAllText(IO.Path.GetDirectoryName(loadDb) & "\" & IO.Path.GetFileNameWithoutExtension(loadDb) & ".txt", _
                                     "// This file auto created by RollRat Distortion Tool " & Version.VersionText & _
                                     vbCrLf & vbCrLf & a.Text)
                MsgBox("요청이 완료되었습니다.", MsgBoxStyle.Information)
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            If str.Length = 0 Then
                MsgBox("내역 없음!", MsgBoxStyle.Critical, "RollRat Distortion")
            Else
                IO.File.WriteAllText(IO.Path.GetDirectoryName(loadDb) & "\" & IO.Path.GetFileNameWithoutExtension(loadDb) & ".txt", _
                                     "// This file auto created by RollRat Distortion Tool " & Version.VersionText & _
                                     vbCrLf & vbCrLf & str.ToString())
                MsgBox("요청이 완료되었습니다.", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text += Version.VersionText
        ParseExtension(My.Settings.Extension)
    End Sub

    Public Shared Sub ParseExtension(ByVal strExtension As String)
        Dim strexarr As String() = strExtension.Split("|"c)
        array_ext = strexarr
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmDistortion.Show()
    End Sub

End Class