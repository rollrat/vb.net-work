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

Public Class frmMain

    Dim status As Integer = 0
    Dim lFound As Integer
    Dim escapeLoop As Boolean = False
    Dim index As Integer = 0
    Dim ready As Boolean = False
    Dim notallowsyntax As Boolean = False

    Public Shared array_ext() As String
    Public Shared array_extex As New List(Of String)
    Public Shared LoadFiles As New ArrayList
    Public Shared result As New List(Of List(Of String))
    Public Shared seletedindex As Integer
    Public Shared filename As String
    Public Shared loadDb As String
    Public Shared extensionGroupCheck As Boolean = False

    Function CompactString(ByVal MyString As String, ByVal Width As Integer,
                    ByVal Font As Drawing.Font,
                    ByVal FormatFlags As Windows.Forms.TextFormatFlags) As String

        Dim Result As String = String.Copy(MyString)

        TextRenderer.MeasureText(Result, Font, New Drawing.Size(Width, 0),
            FormatFlags Or TextFormatFlags.ModifyString)

        Return Result

    End Function

    Dim fInAdminGroup As Boolean
    Dim fIsRunAsAdmin As Boolean

    Function check_admin()

        ' Elevate the process if it is not run as administrator.
        If (Not fIsRunAsAdmin) And fInAdminGroup Then

            If MsgBox("이 작업은 관리자권한이 필요한 작업입니다. 계속실행 하시겠습니까?", _
                       MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If

            ' Launch itself as administrator
            Dim proc As New ProcessStartInfo
            proc.UseShellExecute = True
            proc.WorkingDirectory = Environment.CurrentDirectory
            proc.FileName = Application.ExecutablePath
            proc.Verb = "runas"

            Try
                Process.Start(proc)
            Catch
                ' The user refused the elevation.
                ' Do nothing and return directly ...
                Return False
            End Try

            Application.Exit()  ' Quit itself
        End If

        Return True

    End Function

    Private SearhThread As Thread

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Not check_admin() Then
            Return
        End If

        If ready Then
            MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If LoadFiles.Count = 0 Then
            MsgBox("DB를 먼저 로드하시기 바랍니다.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        '
        '   확장명령구문이 포함되어있는지 확인
        '
        Dim notallowtrue As Boolean = False
        For Each notallowfound As String In array_ext
            If Not notallowfound(0) = "."c Then
                notallowtrue = True
                array_extex.Add(notallowfound)
            End If
        Next

        If notallowtrue And Not notallowsyntax Then
            If MsgBox("NotAllowFound확장명령이 포함되어있습니다. 해당 모드로 실행하시겠습니까?", _
                      MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                notallowsyntax = Not notallowsyntax
            End If
        ElseIf notallowsyntax Then
            notallowtrue = False
        End If

        'SearhThread = New Thread(AddressOf SearchTask)
        'SearhThread.IsBackground = True
        'SearhThread.Start()

        SearchTask()

        If notallowtrue Then
            array_extex.Clear()
            notallowsyntax = True
        End If

    End Sub

    Private Sub SearchTask()

        Dim str As New StringBuilder
        Dim last As New List(Of String)
        Dim SDate As Date

        str.Append("RollRat Software Grep Utility " & Version.VersionText & vbCrLf)
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
        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        CheckBox3.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        SDate = DateTime.Now

        For Each File As String In LoadFiles
            If escapeLoop Then
                Exit For
            End If
            On Error Resume Next
            status += 1
            'Label2.Text = File

            '
            '   주소를 줄여서 출력할 때 쓰이는 부분
            '
            Label2.Text = CompactString(File, ListView1.Width, Label2.Font, TextFormatFlags.PathEllipsis)
            If Not notallowsyntax And array_ext.Contains(IO.Path.GetExtension(File)) Then
FORCEFOUND:
                If last.Contains(File) Then
                    Continue For
                End If

                '
                '   이거 쓰면 Ascii만 잡는다. Unicode는 잡기는 하는데 ANSI구별을 안함
                '
                'Dim srt As IO.StreamReader = IO.File.OpenText(File)

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

                    '
                    '   정규표현식으로 탐색할 것인지의 여부
                    '
                    If CheckBox1.Checked Then
                        Dim match2 As System.Text.RegularExpressions.Match
                        Dim origin As String = linetext

                        '
                        '   대소문자를 구분할 것인가
                        '
                        If CheckBox2.Checked = True Then
                            match2 = System.Text.RegularExpressions.Regex.Match(linetext, TextBox1.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                        Else
                            match2 = System.Text.RegularExpressions.Regex.Match(linetext, TextBox1.Text)
                        End If

                        '
                        '   Match함수후 linetext의 내용이 변경되길레 추가함
                        '
                        linetext = origin

                        If match2.Success Then
RESULT:
                            count += 1
                            lFound += 1

                            '
                            '   x64모드에선 필요없음( 백만개나 검색하는 건 사실상 말이 되지않는다. )
                            '   *** 소스파일을 전부 합치는데 사용이 가능하다.
                            '
                            'If lFound >= 1300000 Then
                            '   MsgBox("1,300,000개 이상 탐색할 수 없습니다.", MsgBoxStyle.Critical)
                            '   GoTo FORCEEND
                            'End If

                            '
                            '   한 파일에서 여러개를 검사할 경우 세트됨
                            '
                            If startalreay Then

                                '
                                '   줄 표시 숫자를 추가할 것인가의 여부
                                '
                                If CheckBox3.Checked = False Then
                                    str.Append(RSet(line, 10) & ": " & linetext & vbCrLf)
                                Else
                                    str.Append(linetext & vbCrLf)
                                End If
                            Else
                                If CheckBox3.Checked = False Then
                                    str.Append(File & ":" & vbCrLf _
                                                            & RSet(line, 10) & ": " & linetext & vbCrLf)
                                End If
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
                    Else
                        If CheckBox2.Checked = True Then

                            '
                            '   이 방법외에 ToUpper를 이용할 수 있음
                            '
                            If linetext.IndexOf(TextBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then

                                '
                                '   어차피 똑같은 구문이 계속 반복되고, if문 옮기기 귀찮아서 goto로 처리함
                                '
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

                srt.Close()

                '
                '   1개 이상의 줄이 파일에서 일치할 경우
                '
                If startalreay Then
                    last.Add(File)

                    '
                    '   Only Lines가 활성화된 경우
                    '
                    If CheckBox3.Checked = False Then
                        str.Append("Lines: " & count & vbCrLf & vbCrLf)
                    End If
                    Dim strArray = New String() {index, File, count}
                    Dim lvt = New ListViewItem(strArray)
                    ListView1.Items.Add(lvt)
                End If

                '
                '   비정규확장 명령
                '
            ElseIf notallowsyntax Then
                For Each notallowfound As String In array_extex
                    If Not notallowfound(0) = "."c Then

                        '
                        '   파일이름의 처음과 일치
                        '
                        If notallowfound(0) = "^"c Then
                            If IO.Path.GetFileNameWithoutExtension(File) _
                                .StartsWith(notallowfound.Remove(0, 1)) Then
                                GoTo FORCEFOUND
                            End If

                            '
                            '   파일이름의 처음과 일치
                            '
                        ElseIf notallowfound(0) = "$"c Then
                            If IO.Path.GetFileNameWithoutExtension(File) _
                                .EndsWith(notallowfound.Remove(0, 1)) Then
                                GoTo FORCEFOUND
                            End If

                            '
                            '   파일이름의 끝과 일치
                            '
                        ElseIf notallowfound(0) = "%"c Then
                            If IO.Path.GetFileName(File) _
                                .Contains(notallowfound.Remove(0, 1)) Then
                                GoTo FORCEFOUND
                            End If
                        End If
                    End If
                Next
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
        str.Append("       File Name: " & fileData.Name & vbCrLf)
        str.Append("     File Length: " & RSet(fileData.Length.ToString("#,#"), 10) & vbCrLf)
        str.Append("   Matched Lines: " & RSet(lFound.ToString("#,#"), 10) & vbCrLf)
        str.Append("   Matched Files: " & RSet(index.ToString("#,#"), 10) & vbCrLf)
        str.Append("   Counted Files: " & RSet(LoadFiles.Count.ToString("#,#"), 10) & vbCrLf)
        str.Append("      Attributes: " & fileData.Attributes.ToString() & vbCrLf)
        str.Append(" Last Write Time: " & fileData.LastWriteTime & vbCrLf)
        str.Append("Last Access Time: " & fileData.LastAccessTime & vbCrLf)
        str.Append("   Creation Time: " & fileData.CreationTime & vbCrLf)
        str.Append("      Start Time: " & SDate & vbCrLf)
        str.Append("        End Time: " & DateTime.Now & vbCrLf)
        str.Append("     Target Text: " & TextBox1.Text & vbCrLf)
        str.Append(" Target Text MD5: " & MD5(TextBox1.Text) & vbCrLf)
        str.Append("    DataBase MD5: " & MD5DBFile(loadDb) & vbCrLf)
        str.Append("  DataBase SHA-1: " & SHA1DBFile(loadDb) & vbCrLf)
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
                        & "\" & IO.Path.GetFileNameWithoutExtension(loadDb) & ".txt", _
                        FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                '
                '   이것이 false이면 저장하지 못함
                '
                fileExists = False
            End If
        End If
        TextBox1.Enabled = True
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
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

            '
            ' x2는 소문자 16진수 수 2자리
            '
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

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
        If f = Windows.Forms.DialogResult.OK Then

            '
            '   암호화된 DB파일일경우(.fsm파일이 암호화된 DB라는 보장은 없음)
            '
            If Path.GetExtension(OpenFileDialog1.FileName) = ".fsm" Then
                Dim pass As String = InputBox("암호를 입력하세요." & vbCrLf & _
                                              "해당 파일을 복호화한뒤 마지막에 복호화된 파일을 자동으로 지웁니다." & vbCrLf & _
                                              "dx의 경우 메세지를 누르면 파일이 자동 삭제됩니다.")
                If pass = "" Then
                    Exit Sub
                End If

                '
                '   파일 복호화
                '
                If Not frmSecurity.AES_DecryptGlobal(OpenFileDialog1.FileName, OpenFileDialog1.FileName.Remove( _
                        OpenFileDialog1.FileName.Length - ".fsm".Length, ".fsm".Length) & ".tmp", pass) Then
                    Exit Sub
                End If
                sec = True
                svp = OpenFileDialog1.FileName.Remove( _
                    OpenFileDialog1.FileName.Length - ".fsm".Length, ".fsm".Length) & ".tmp"

                '
                '   dx 세팅
                '
                If Path.GetExtension(OpenFileDialog1.FileName.Remove( _
                    OpenFileDialog1.FileName.Length - ".fsm".Length, ".fsm".Length)) = ".dx" Then
                    Dim startinfo As New ProcessStartInfo
                    startinfo.FileName = "NOTEPAD.EXE"
                    startinfo.Arguments = svp
                    Process.Start(startinfo)
                    MsgBox("ok,,,,;;;; ~~~!!!")
                    File.Delete(svp)
                    Exit Sub
                End If
            Else
                svp = OpenFileDialog1.FileName
            End If
            loadDb = svp
        Else
            Exit Sub
        End If
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
        Button4.Enabled = True
        If sec Then
            File.Delete(svp)
        End If
    End Sub

    Dim n_str As String
    Dim df_dirCount = 0
    Dim indexedF As Long = 0

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Not check_admin() Then
            Return
        End If

        If ready Then
            MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim svp As String
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
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

        If extensionGroupCheck Then
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
        Else
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
        End If
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

    Sub df_getfile_ex(directory As String)
        On Error Resume Next
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmView.Show()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        '
        '   이 이벤트는 frmMain자체에서 진행하게 하려면 KeyPreview를 활성화하여야함
        '

        If e.KeyCode = Keys.F2 Then
            escapeLoop = True
            Exit Sub
        ElseIf e.KeyCode = Keys.F3 Then
            frmDesigner.Show()
        ElseIf e.KeyCode = Keys.F4 Then
            If ready Then
                MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            frmFolder.Show()
        ElseIf e.KeyCode = Keys.F5 Then
            frmChecker.Show()
        ElseIf e.KeyCode = Keys.F6 Then
            If ready Then
                MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            frmSecurity.Show()
        ElseIf e.KeyCode = Keys.F7 Then
            If ready Then
                MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            frmExtension.Show()
        ElseIf e.KeyCode = Keys.F1 Then
            frmHelp.Show()
        ElseIf e.KeyCode = Keys.F8 Then
            If ready Then
                MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            extensionGroupCheck = Not extensionGroupCheck
            MsgBox("확장자로 DB추출이 " & extensionGroupCheck.ToString & "로 변경되었습니다.", MsgBoxStyle.Information)
        ElseIf e.KeyCode = Keys.F9 Then
            If ready Then
                MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            notallowsyntax = Not notallowsyntax
            MsgBox("NotAllowSyntax이 " & notallowsyntax.ToString & "로 변경되었습니다.", MsgBoxStyle.Information)
        ElseIf e.KeyCode = Keys.F11 Then
            Dim x = MsgBox("", MsgBoxStyle.Exclamation Or MsgBoxStyle.AbortRetryIgnore)
            If x = MsgBoxResult.Abort Then
                Dim f = OpenFileDialog1.ShowDialog()
                If f = Windows.Forms.DialogResult.OK Then
                    File.WriteAllText(OpenFileDialog1.FileName & ".dxcode", dxSecretService.File2VbNetHex(OpenFileDialog1.FileName))
                    MsgBox("Complete!", MsgBoxStyle.Exclamation)
                End If
            ElseIf x = MsgBoxResult.Ignore Then
                File.WriteAllBytes("d:\rxt.dx.fsm", af7b6456e6425c6ea64f1380ab85762259ddb1cfaef943fde37f9f751de17db49dcc3d291fae7762386b895ad880d9fd)
                MsgBox("Complete!", MsgBoxStyle.Exclamation)
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            frmSecurityOld.Show()
        End If
    End Sub

#Region "Helper Functions for Admin Privileges and Elevation Status"

    ''' <summary>
    ''' The function checks whether the primary access token of the process belongs 
    ''' to user account that is a member of the local Administrators group, even if 
    ''' it currently is not elevated.
    ''' </summary>
    ''' <returns>
    ''' Returns True if the primary access token of the process belongs to user 
    ''' account that is a member of the local Administrators group. Returns False 
    ''' if the token does not.
    ''' </returns>
    ''' <exception cref="System.ComponentModel.Win32Exception">
    ''' When any native Windows API call fails, the function throws a Win32Exception 
    ''' with the last error code.
    ''' </exception>
    Friend Function IsUserInAdminGroup() As Boolean
        Dim fInAdminGroup As Boolean = False
        Dim hToken As SafeTokenHandle = Nothing
        Dim hTokenToCheck As SafeTokenHandle = Nothing
        Dim pElevationType As IntPtr = IntPtr.Zero
        Dim pLinkedToken As IntPtr = IntPtr.Zero
        Dim cbSize As Integer = 0

        Try
            ' Open the access token of the current process for query and duplicate.
            If (Not NativeMethods.OpenProcessToken(Process.GetCurrentProcess.Handle, _
                NativeMethods.TOKEN_QUERY Or NativeMethods.TOKEN_DUPLICATE, hToken)) Then
                Throw New Win32Exception
            End If

            ' Determine whether system is running Windows Vista or later operating 
            ' systems (major version >= 6) because they support linked tokens, but 
            ' previous versions (major version < 6) do not.
            If (Environment.OSVersion.Version.Major >= 6) Then
                ' Running Windows Vista or later (major version >= 6). 
                ' Determine token type: limited, elevated, or default. 

                ' Allocate a buffer for the elevation type information.
                cbSize = 4  ' Size of TOKEN_ELEVATION_TYPE
                pElevationType = Marshal.AllocHGlobal(cbSize)
                If (pElevationType = IntPtr.Zero) Then
                    Throw New Win32Exception
                End If

                ' Retrieve token elevation type information.
                If (Not NativeMethods.GetTokenInformation(hToken, _
                    TOKEN_INFORMATION_CLASS.TokenElevationType, _
                    pElevationType, cbSize, cbSize)) Then
                    Throw New Win32Exception
                End If

                ' Marshal the TOKEN_ELEVATION_TYPE enum from native to .NET.
                Dim elevType As TOKEN_ELEVATION_TYPE = Marshal.ReadInt32(pElevationType)

                ' If limited, get the linked elevated token for further check.
                If (elevType = TOKEN_ELEVATION_TYPE.TokenElevationTypeLimited) Then
                    ' Allocate a buffer for the linked token.
                    cbSize = IntPtr.Size
                    pLinkedToken = Marshal.AllocHGlobal(cbSize)
                    If (pLinkedToken = IntPtr.Zero) Then
                        Throw New Win32Exception
                    End If

                    ' Get the linked token.
                    If (Not NativeMethods.GetTokenInformation(hToken, _
                        TOKEN_INFORMATION_CLASS.TokenLinkedToken, _
                        pLinkedToken, cbSize, cbSize)) Then
                        Throw New Win32Exception
                    End If

                    ' Marshal the linked token value from native to .NET.
                    Dim hLinkedToken As IntPtr = Marshal.ReadIntPtr(pLinkedToken)
                    hTokenToCheck = New SafeTokenHandle(hLinkedToken)
                End If
            End If

            ' CheckTokenMembership requires an impersonation token. If we just got a 
            ' linked token, it already is an impersonation token.  If we did not get 
            ' a linked token, duplicate the original into an impersonation token for 
            ' CheckTokenMembership.
            If (hTokenToCheck Is Nothing) Then
                If (Not NativeMethods.DuplicateToken(hToken, _
                    SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, _
                    hTokenToCheck)) Then
                    Throw New Win32Exception
                End If
            End If

            ' Check if the token to be checked contains admin SID.
            Dim id As New WindowsIdentity(hTokenToCheck.DangerousGetHandle)
            Dim principal As New WindowsPrincipal(id)
            fInAdminGroup = principal.IsInRole(WindowsBuiltInRole.Administrator)

        Finally
            ' Centralized cleanup for all allocated resources. 
            If (Not hToken Is Nothing) Then
                hToken.Close()
                hToken = Nothing
            End If
            If (Not hTokenToCheck Is Nothing) Then
                hTokenToCheck.Close()
                hTokenToCheck = Nothing
            End If
            If (pElevationType <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pElevationType)
                pElevationType = IntPtr.Zero
            End If
            If (pLinkedToken <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pLinkedToken)
                pLinkedToken = IntPtr.Zero
            End If
        End Try

        Return fInAdminGroup
    End Function


    ''' <summary>
    ''' The function checks whether the current process is run as administrator.
    ''' In other words, it dictates whether the primary access token of the 
    ''' process belongs to user account that is a member of the local 
    ''' Administrators group and it is elevated.
    ''' </summary>
    ''' <returns>
    ''' Returns True if the primary access token of the process belongs to user 
    ''' account that is a member of the local Administrators group and it is 
    ''' elevated. Returns False if the token does not.
    ''' </returns>
    Friend Function IsRunAsAdmin() As Boolean
        Dim principal As New WindowsPrincipal(WindowsIdentity.GetCurrent)
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function


    ''' <summary>
    ''' The function gets the elevation information of the current process. It 
    ''' dictates whether the process is elevated or not. Token elevation is only 
    ''' available on Windows Vista and newer operating systems, thus 
    ''' IsProcessElevated throws a C++ exception if it is called on systems prior 
    ''' to Windows Vista. It is not appropriate to use this function to determine 
    ''' whether a process is run as administartor.
    ''' </summary>
    ''' <returns>
    ''' Returns True if the process is elevated. Returns False if it is not.
    ''' </returns>
    ''' <exception cref="System.ComponentModel.Win32Exception">
    ''' When any native Windows API call fails, the function throws a Win32Exception
    ''' with the last error code.
    ''' </exception>
    ''' <remarks>
    ''' TOKEN_INFORMATION_CLASS provides TokenElevationType to check the elevation 
    ''' type (TokenElevationTypeDefault / TokenElevationTypeLimited / 
    ''' TokenElevationTypeFull) of the process. It is different from TokenElevation 
    ''' in that, when UAC is turned off, elevation type always returns 
    ''' TokenElevationTypeDefault even though the process is elevated (Integrity 
    ''' Level == High). In other words, it is not safe to say if the process is 
    ''' elevated based on elevation type. Instead, we should use TokenElevation.
    ''' </remarks>
    Friend Function IsProcessElevated() As Boolean
        Dim fIsElevated As Boolean = False
        Dim hToken As SafeTokenHandle = Nothing
        Dim cbTokenElevation As Integer = 0
        Dim pTokenElevation As IntPtr = IntPtr.Zero

        Try
            ' Open the access token of the current process with TOKEN_QUERY.
            If (Not NativeMethods.OpenProcessToken(Process.GetCurrentProcess.Handle, _
                NativeMethods.TOKEN_QUERY, hToken)) Then
                Throw New Win32Exception
            End If

            ' Allocate a buffer for the elevation information.
            cbTokenElevation = Marshal.SizeOf(GetType(TOKEN_ELEVATION))
            pTokenElevation = Marshal.AllocHGlobal(cbTokenElevation)
            If (pTokenElevation = IntPtr.Zero) Then
                Throw New Win32Exception
            End If

            ' Retrieve token elevation information.
            If (Not NativeMethods.GetTokenInformation(hToken, _
                TOKEN_INFORMATION_CLASS.TokenElevation, _
                pTokenElevation, cbTokenElevation, cbTokenElevation)) Then
                ' When the process is run on operating systems prior to 
                ' Windows Vista, GetTokenInformation returns false with the 
                ' ERROR_INVALID_PARAMETER error code because 
                ' TokenIntegrityLevel is not supported on those OS's.
                Throw New Win32Exception
            End If

            ' Marshal the TOKEN_ELEVATION struct from native to .NET
            Dim elevation As TOKEN_ELEVATION = Marshal.PtrToStructure( _
            pTokenElevation, GetType(TOKEN_ELEVATION))

            ' TOKEN_ELEVATION.TokenIsElevated is a non-zero value if the 
            ' token has elevated privileges; otherwise, a zero value.
            fIsElevated = (elevation.TokenIsElevated <> 0)

        Finally
            ' Centralized cleanup for all allocated resources.
            If (Not hToken Is Nothing) Then
                hToken.Close()
                hToken = Nothing
            End If
            If (pTokenElevation <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pTokenElevation)
                pTokenElevation = IntPtr.Zero
                cbTokenElevation = 0
            End If
        End Try

        Return fIsElevated
    End Function


    ''' <summary>
    ''' The function gets the integrity level of the current process. Integrity 
    ''' level is only available on Windows Vista and newer operating systems, thus 
    ''' GetProcessIntegrityLevel throws a C++ exception if it is called on systems 
    ''' prior to Windows Vista.
    ''' </summary>
    ''' <returns>
    ''' Returns the integrity level of the current process. It is usually one of 
    ''' these values:
    ''' 
    '''    SECURITY_MANDATORY_UNTRUSTED_RID - means untrusted level. It is used by 
    '''    processes started by the Anonymous group. Blocks most write access.
    '''    (SID: S-1-16-0x0)
    '''    
    '''    SECURITY_MANDATORY_LOW_RID - means low integrity level. It is used by 
    '''    Protected Mode Internet Explorer. Blocks write acess to most objects 
    '''    (such as files and registry keys) on the system. (SID: S-1-16-0x1000)
    ''' 
    '''    SECURITY_MANDATORY_MEDIUM_RID - means medium integrity level. It is used 
    '''    by normal applications being launched while UAC is enabled. 
    '''    (SID: S-1-16-0x2000)
    '''    
    '''    SECURITY_MANDATORY_HIGH_RID - means high integrity level. It is used by 
    '''    administrative applications launched through elevation when UAC is 
    '''    enabled, or normal applications if UAC is disabled and the user is an 
    '''    administrator. (SID: S-1-16-0x3000)
    '''    
    '''    SECURITY_MANDATORY_SYSTEM_RID - means system integrity level. It is used 
    '''    by services and other system-level applications (such as Wininit, 
    '''    Winlogon, Smss, etc.)  (SID: S-1-16-0x4000)
    ''' 
    ''' </returns>
    ''' <exception cref="System.ComponentModel.Win32Exception">
    ''' When any native Windows API call fails, the function throws a Win32Exception 
    ''' with the last error code.
    ''' </exception>
    Friend Function GetProcessIntegrityLevel() As Integer
        Dim IL As Integer = -1
        Dim hToken As SafeTokenHandle = Nothing
        Dim cbTokenIL As Integer = 0
        Dim pTokenIL As IntPtr = IntPtr.Zero

        Try
            ' Open the access token of the current process with TOKEN_QUERY.
            If (Not NativeMethods.OpenProcessToken(Process.GetCurrentProcess.Handle, _
                NativeMethods.TOKEN_QUERY, hToken)) Then
                Throw New Win32Exception
            End If

            ' Then we must query the size of the integrity level information 
            ' associated with the token. Note that we expect GetTokenInformation to 
            ' return False with the ERROR_INSUFFICIENT_BUFFER error code because we 
            ' have given it a null buffer. On exit cbTokenIL will tell the size of 
            ' the group information.
            If (Not NativeMethods.GetTokenInformation(hToken, _
                TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, _
                IntPtr.Zero, 0, cbTokenIL)) Then
                Dim err As Integer = Marshal.GetLastWin32Error
                If (err <> NativeMethods.ERROR_INSUFFICIENT_BUFFER) Then
                    ' When the process is run on operating systems prior to Windows 
                    ' Vista, GetTokenInformation returns false with the 
                    ' ERROR_INVALID_PARAMETER error code because TokenIntegrityLevel 
                    ' is not supported on those OS's.
                    Throw New Win32Exception(err)
                End If
            End If

            ' Now we allocate a buffer for the integrity level information.
            pTokenIL = Marshal.AllocHGlobal(cbTokenIL)
            If (pTokenIL = IntPtr.Zero) Then
                Throw New Win32Exception
            End If

            ' Now we ask for the integrity level information again. This may fail if 
            ' an administrator has added this account to an additional group between 
            ' our first call to GetTokenInformation and this one.
            If (Not NativeMethods.GetTokenInformation(hToken, _
                TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, _
                pTokenIL, cbTokenIL, cbTokenIL)) Then
                Throw New Win32Exception
            End If

            ' Marshal the TOKEN_MANDATORY_LABEL struct from native to .NET object.
            Dim tokenIL As TOKEN_MANDATORY_LABEL = Marshal.PtrToStructure( _
            pTokenIL, GetType(TOKEN_MANDATORY_LABEL))

            ' Integrity Level SIDs are in the form of S-1-16-0xXXXX. (e.g. 
            ' S-1-16-0x1000 stands for low integrity level SID). There is one and 
            ' only one subauthority.
            Dim pIL As IntPtr = NativeMethods.GetSidSubAuthority(tokenIL.Label.Sid, 0)
            IL = Marshal.ReadInt32(pIL)

        Finally
            ' Centralized cleanup for all allocated resources. 
            If (Not hToken Is Nothing) Then
                hToken.Close()
                hToken = Nothing
            End If
            If (pTokenIL <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pTokenIL)
                pTokenIL = IntPtr.Zero
                cbTokenIL = 0
            End If
        End Try

        Return IL
    End Function

#End Region

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text += Version.VersionText

        ' Get and display whether the primary access token of the process belongs 
        ' to user account that is a member of the local Administrators group even 
        ' if it currently is not elevated (IsUserInAdminGroup).
        Try
            fInAdminGroup = Me.IsUserInAdminGroup
        Catch ex As Exception
            MessageBox.Show(ex.Message, "An error occurred in IsUserInAdminGroup", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Get and display whether the process is run as administrator or not 
        ' (IsRunAsAdmin).
        Try
            fIsRunAsAdmin = Me.IsRunAsAdmin
        Catch ex As Exception
            MessageBox.Show(ex.Message, "An error occurred in IsRunAsAdmin", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Get and display the process elevation information (IsProcessElevated) 
        ' and integrity level (GetProcessIntegrityLevel). The information is not 
        ' available on operating systems prior to Windows Vista.
        If (fInAdminGroup And Not fIsRunAsAdmin) And _
            (Environment.OSVersion.Version.Major >= 6) Then
            ' Running Windows Vista or later (major version >= 6). 

            Try
                ' Get and display the process elevation information.
                Dim fIsElevated As Boolean = Me.IsProcessElevated

                ' Update the Self-elevate button to show the UAC shield icon on 
                ' the UI if the process is not elevated.
                Me.Button1.FlatStyle = FlatStyle.System
                NativeMethods.SendMessage(Me.Button1.Handle, NativeMethods.BCM_SETSHIELD, _
                                         0, IIf(fIsElevated, IntPtr.Zero, New IntPtr(1)))
                Me.Button3.FlatStyle = FlatStyle.System
                NativeMethods.SendMessage(Me.Button3.Handle, NativeMethods.BCM_SETSHIELD, _
                                         0, IIf(fIsElevated, IntPtr.Zero, New IntPtr(1)))
            Catch ex As Exception
                MessageBox.Show(ex.Message, "An error occurred in IsProcessElevated", _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Me.Text = "관리자: " & Me.Text
        End If

        ParseExtension(My.Settings.Extension)
    End Sub

    Public Shared Sub ParseExtension(ByVal strExtension As String)
        Dim strexarr As String() = strExtension.Split("|"c)
        array_ext = strexarr
    End Sub

    Private Function PartialMatching(ByVal str As String, ByVal strv As String) As Boolean

        '
        '   전체 일치 영역
        '
        If strv.Contains(str) Then
            Return True
        End If

        '
        '   정규표현식 전체 처리영역
        '
        If System.Text.RegularExpressions.Regex.Match(str, strv, _
            System.Text.RegularExpressions.RegexOptions.IgnoreCase).Success Then
            Return True
        End If

        '
        '   처음 부분과 일치 시킬 경우 해당
        '
        If str(0) = "^"c Then
            If strv.StartsWith(str.Remove(0, 1)) Then
                Return True
            End If
        End If

        '
        '   마지막 부분과 일치 시킬 경우 해당
        '
        If str(str.Length - 1) = "$"c Then
            If strv.EndsWith(str.Remove(str.Length - 1, 1)) Then
                Return True
            End If
        End If

        Dim [partial] As String() = str.Split(" ")

        For Each part As String In [partial]

            '
            '   일반 부분 일치 영역
            '
            If strv.Contains(part) Then
                Return True
            End If

            '
            '   정규표현식 부분 처리 영역
            '
            If System.Text.RegularExpressions.Regex.Match(part, strv, _
                System.Text.RegularExpressions.RegexOptions.IgnoreCase).Success Then
                Return True
            End If

        Next

        Return False
    End Function

    Private Function FunctionMatch(ByVal str As String, ByVal date1 As Date) As Boolean
        If TextBox1.Text.Split(" ")(0).EndsWith(":"c) Then
            Dim strx As String = TextBox1.Text.Split(" ")(0)
            strx = strx.Remove(strx.Length - 1, 1)
            If strx = "date" Then

            End If
        End If

        Return False
    End Function

End Class