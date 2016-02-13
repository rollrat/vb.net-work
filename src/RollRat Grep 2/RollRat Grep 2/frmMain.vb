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

    Dim m_Button As List(Of Object)
    Dim m_CheckBox As List(Of Object)

    Private Sub EnableObject(obj As List(Of Object))
        For Each objt As Object In obj
            objt.Enabled = True
        Next
    End Sub
    Private Sub DisableObject(obj As List(Of Object))
        For Each objt As Object In obj
            objt.Enabled = False
        Next
    End Sub

    Function CompactString(ByVal MyString As String, ByVal Width As Integer,
                    ByVal Font As Drawing.Font,
                    ByVal FormatFlags As TextFormatFlags) As String

        Dim Result As String = String.Copy(MyString)

        TextRenderer.MeasureText(Result, Font, New Drawing.Size(Width, 0),
            FormatFlags Or TextFormatFlags.ModifyString)

        Return Result

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ready Then
            MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical, Version.ProgramName)
            Exit Sub
        End If
        If LoadFiles.Count = 0 Then
            MsgBox("DB를 먼저 로드하시기 바랍니다.", MsgBoxStyle.Critical, Version.ProgramName)
            Exit Sub
        End If

        SearchTask()

    End Sub

    Private Sub SearchTask()

        Dim str As New StringBuilder
        Dim last As New List(Of String)
        Dim SDate As Date
        Dim totalLines As Integer = 0

        str.Append("RollRat Software Grep Utility 2 " & Version.VersionText & vbCrLf)
        str.Append("Copyright (c) rollrat. 2015. All rights reserved." & vbCrLf & vbCrLf)
        result = New List(Of List(Of String))
        ListView1.Items.Clear()
        index = 0
        lFound = 0
        ready = True
        ProgressBar1.Visible = True
        Timer1.Start()
        status = 0
        escapeLoop = False
        TextBox1.Enabled = False
        DisableObject(m_CheckBox)
        DisableObject(m_Button)
        SDate = DateTime.Now

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
FORCEFOUND:
                If last.Contains(File) Then
                    Continue For
                End If

                Dim srt As StreamReader = New StreamReader(File, Encoding.Default)
                Dim linetext As String
                Dim line As Integer = 0
                Dim count As Integer = 0
                Dim startalreay As Boolean = False
                Do
                    linetext = srt.ReadLine()

                    If linetext = Nothing Then
                        If srt.EndOfStream Then
                            Exit Do
                        End If
                    End If
                    line += 1

                    If CheckBox1.Checked Then
                        Dim match2 As System.Text.RegularExpressions.Match
                        Dim origin As String = linetext

                        If CheckBox2.Checked = True Then
                            match2 = System.Text.RegularExpressions.Regex.Match(linetext, TextBox1.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                        Else
                            match2 = System.Text.RegularExpressions.Regex.Match(linetext, TextBox1.Text)
                        End If

                        linetext = origin

                        If match2.Success Then
RESULT:
                            count += 1
                            lFound += 1
                            If startalreay Then
                                If CheckBox3.Checked = False Then
                                    str.Append(RSet(line, 10) & ": " & linetext & vbCrLf)
                                Else
                                    str.Append(linetext & vbCrLf)
                                End If
                            Else
                                If CheckBox3.Checked = False Then
                                    str.Append(File & ":" & vbCrLf & RSet(line, 10) & ": " & linetext & vbCrLf)
                                End If
                                startalreay = True
                                index += 1
                                result.Add(New List(Of String))
                            End If
                            result(index - 1).Add(line & ": " & linetext)
                        End If
                    Else
                        If CheckBox2.Checked = True Then
                            If linetext.IndexOf(TextBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                                GoTo RESULT
                            End If
                        Else
                            If linetext.Contains(TextBox1.Text) Then
                                GoTo RESULT
                            End If
                        End If
                    End If
                    Application.DoEvents()
                Loop
                totalLines += line
                srt.Close()
                If startalreay Then
                    last.Add(File)
                    If CheckBox3.Checked = False Then
                        str.Append("Lines: " & count & vbCrLf & vbCrLf)
                    End If
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

        If CheckBox3.Checked Then
            str.Append(vbCrLf)
        End If

        str.Append("   DataBase Name: " & loadDb & vbCrLf)
        str.Append("     Total Lines: " & RSet(totalLines.ToString("#,#"), 15) & vbCrLf)
        str.Append("   Matched Lines: " & RSet(lFound.ToString("#,#"), 15) & vbCrLf)
        str.Append("   Matched Files: " & RSet(index.ToString("#,#"), 15) & vbCrLf)
        str.Append("   Counted Files: " & RSet(LoadFiles.Count.ToString("#,#"), 15) & vbCrLf)
        str.Append("      Start Time: " & SDate & vbCrLf)
        str.Append("        End Time: " & DateTime.Now & vbCrLf)
        str.Append("     Target Text: " & TextBox1.Text & vbCrLf)
        str.Append(" Target Text MD5: " & MD5(TextBox1.Text) & vbCrLf)
        str.Append("     Ignore Case: " & CheckBox2.Checked.ToString & vbCrLf)
        str.Append("     Using Regex: " & CheckBox1.Checked.ToString & vbCrLf)
        str.Append("      Only Lines: " & CheckBox3.Checked.ToString)
        If escapeLoop Then
            str.Append(vbCrLf & vbCrLf & "       This operation has been canceled midway.")
        End If

        status = 0
        ready = False
        ProgressBar1.Visible = False
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(IO.Path.GetDirectoryName(loadDb) & "\" & _
                            IO.Path.GetFileNameWithoutExtension(loadDb) & ".txt")
        If fileExists = True Then
            If MsgBox("이미 파일이 있습니다. 덮어쓰시겠습니까?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile(IO.Path.GetDirectoryName(loadDb) _
                        & "\" & IO.Path.GetFileNameWithoutExtension(loadDb), _
                        FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently & ".txt")

                '
                '   이것이 false이면 저장하지 못함
                '
                fileExists = False
            End If
        End If
        TextBox1.Enabled = True
        EnableObject(m_CheckBox)
        EnableObject(m_Button)
        If fileExists Then
            Return
        End If
        IO.File.WriteAllText(IO.Path.GetDirectoryName(loadDb) & "\" & IO.Path.GetFileNameWithoutExtension(loadDb) & ".txt", str.ToString)
        MsgBox("탐색이 완료되었습니다.", MsgBoxStyle.Information)
    End Sub

    Function MD5(ByVal str As String) As String
        Dim md5service As New Security.Cryptography.MD5CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In md5service.ComputeHash(Encoding.ASCII.GetBytes(str))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        Dim f = OpenFileDialog1.ShowDialog()
        If ready Then
            MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If f = DialogResult.OK Then
            svp = OpenFileDialog1.FileName
            loadDb = svp

            LoadFiles.Clear()

            My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\tmp")
            IO.Compression.ZipFile.ExtractToDirectory(svp, System.IO.Directory.GetCurrentDirectory & "\tmp")
            LoadFiles.AddRange(File.ReadAllText(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp").Split({"*"c}))
            My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\tmp\file.tmp", _
                                               FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Directory.Delete(System.IO.Directory.GetCurrentDirectory & "\tmp")
            Label6.Text = Path.GetFileNameWithoutExtension(svp) & "/ Files: " & LoadFiles.Count
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
                df_getfile_ex(Directory)
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

    Sub df_getfile_ex(directory As String)
        On Error Resume Next
        df_stringb.Append(directory & "*")
        For Each di In (New IO.DirectoryInfo(directory)).GetFiles()
            If escapeLoop Then
                Exit For
            End If
            n_str = di.ToString

            '
            '   확장자로 DB추출이 활성화되어있는 경우 이 함수를 통해 추가됨
            '
            If array_ext.Contains(Path.GetExtension(n_str)) Then
                If directory.EndsWith("\") = False Then
                    df_stringb.Append(directory & "\" & n_str & "*")
                Else
                    df_stringb.Append(directory & n_str & "*")
                End If
                indexedF += 1
            End If
            Application.DoEvents()
        Next
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label3.Text = "Status : " & df_dirCount & "/" & df_Directories.Count
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
        If e.KeyCode = Keys.F2 Then
            escapeLoop = True
            Exit Sub
        ElseIf e.KeyCode = Keys.F1 Then
            frmHelp.Show()
        End If
    End Sub

    Public Shared Sub ParseExtension(ByVal strExtension As String)
        Dim strexarr As String() = strExtension.Split("|"c)
        array_ext = strexarr
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text += Version.VersionText

        m_Button = New List(Of Object)({Button1, Button2, Button3, Button4})
        m_CheckBox = New List(Of Object)({CheckBox1, CheckBox2, CheckBox3})

        ParseExtension(My.Settings.Extension)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmExtension.Show()
    End Sub

End Class