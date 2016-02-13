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

    Dim lFound As Integer
    Dim escapeLoop As Boolean = False
    Dim index As Integer = 0
    Dim ready As Boolean = False
    Dim count As Integer = 0 ' file count

    Public Shared array_ext() As String
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

    Private Sub tmFoundText_Tick(sender As Object, e As EventArgs) Handles tmFoundText.Tick
        lFind.Text = "Found: " & lFound

        Application.DoEvents()
    End Sub

    Private Sub bStart_Click(sender As Object, e As EventArgs) Handles bStart.Click

        If ready Then
            MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical, Version.ProgramName)
            Exit Sub
        End If
        If ready Then
            MsgBox("다른 작업을 마친 후 다시시도하십시오.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If diaOpenFolder.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        Dim saveFileName As String = ""

        Dim svp As String
        svp = diaOpenFolder.SelectedPath

        saveFileName = svp

        ' 드라이버이면,
        If svp.Length = 3 Then
            saveFileName = svp(0).ToString.ToUpper & " Drive"
        Else
            saveFileName = Path.GetFileName(svp)
        End If

        str.Clear()

        str.Append("RollRat Software Grep Utility 2 " & Version.VersionText & vbCrLf)
        str.Append("Copyright (c) rollrat. 2015. All rights reserved." & vbCrLf & vbCrLf)
        result = New List(Of List(Of String))
        lvResult.Items.Clear()
        index = 0
        lFound = 0
        count = 0
        ready = True
        tmFoundText.Start()
        escapeLoop = False
        tbSearch.Enabled = False
        DisableObject(m_CheckBox)
        DisableObject(m_Button)
        SDate = DateTime.Now

        FormSizeEffectingAuto(New Size(Me.Size.Width, Me.Size.Height + 25))

        ''''
        df_approach(svp)
        ''''

        FormSizeEffectingAuto(New Size(Me.Size.Width, Me.Size.Height - 25))

        tmFoundText.Stop()
        lFind.Text = ""
        lAddr.Text = ""

        If cbOnlyLines.Checked Then
            str.Append(vbCrLf)
        End If

        str.Append("   DataBase Name: " & loadDb & vbCrLf)
        str.Append("     Total Lines: " & RSet(totalLines.ToString("#,#"), 15) & vbCrLf)
        str.Append("   Matched Lines: " & RSet(lFound.ToString("#,#"), 15) & vbCrLf)
        str.Append("   Matched Files: " & RSet(index.ToString("#,#"), 15) & vbCrLf)
        str.Append("   Counted Files: " & RSet(count.ToString("#,#"), 15) & vbCrLf)
        str.Append("      Start Time: " & SDate & vbCrLf)
        str.Append("        End Time: " & DateTime.Now & vbCrLf)
        str.Append("     Target Text: " & tbSearch.Text & vbCrLf)
        str.Append(" Target Text MD5: " & MD5(tbSearch.Text) & vbCrLf)
        str.Append("     Ignore Case: " & cbIgnore.Checked.ToString & vbCrLf)
        str.Append("     Using Regex: " & cbRegex.Checked.ToString & vbCrLf)
        str.Append("      Only Lines: " & cbOnlyLines.Checked.ToString)
        If escapeLoop Then
            str.Append(vbCrLf & vbCrLf & "       This operation has been canceled midway.")
        End If

        ready = False
        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(System.IO.Directory.GetCurrentDirectory & "\db")
        If Not folderExists Then
            My.Computer.FileSystem.CreateDirectory(System.IO.Directory.GetCurrentDirectory & "\db")
        End If

        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(System.IO.Directory.GetCurrentDirectory & "\db\" & _
                            saveFileName & ".txt")
        If fileExists = True Then
            If MsgBox("이미 파일이 있습니다. 덮어쓰시겠습니까?" & vbCrLf & "취소 버튼을 누르면 검색된 자료가 사라집니다.", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                ' 사용자가 파일을 옮겼을 수 있으니 다시 체크
                fileExists = My.Computer.FileSystem.FileExists(System.IO.Directory.GetCurrentDirectory & "\db\" & _
                            saveFileName & ".txt")

                If fileExists Then
                    My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\db\" & _
                            saveFileName & ".txt", _
                            FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End If

                '
                '   이것이 false이면 저장하지 못함
                '
                fileExists = False
            End If
        End If
        tbSearch.Enabled = True
        EnableObject(m_CheckBox)
        EnableObject(m_Button)
        If fileExists Then
            Return
        End If
        IO.File.WriteAllText(System.IO.Directory.GetCurrentDirectory & "\db\" & _
                            saveFileName & ".txt", str.ToString)
        MsgBox("탐색이 완료되었습니다.", MsgBoxStyle.Information)
    End Sub

    Dim str As New StringBuilder
    Dim SDate As Date
    Dim totalLines As Integer = 0

    Dim indexedF As Long = 0

    Sub df_approach(fdrectory As String)
        On Error Resume Next
        If Directory.GetDirectories(fdrectory).Length Then
            For Each recu As String In Directory.GetDirectories(fdrectory)
                If escapeLoop Then Exit For
                If Directory.Exists(recu) Then
                    df_approach(recu)
                    For Each di In (New IO.DirectoryInfo(recu)).GetFiles()
                        If escapeLoop Then Exit For
                        Dim n_str As String = di.ToString
                        If array_ext.Contains(Path.GetExtension(n_str)) Then
                            Dim addr As String
                            count += 1
                            If recu.EndsWith("\") = False Then
                                addr = recu & "\" & n_str
                            Else
                                addr = recu & n_str
                            End If
                            addr_search(addr)
                        End If
                        Application.DoEvents()
                    Next
                End If
                Application.DoEvents()
            Next
        End If
    End Sub

    Sub addr_search(ByVal addr As String)
        If escapeLoop Then
            Exit Sub
        End If

        lAddr.Text = CompactString(addr, lvResult.Width, lAddr.Font, TextFormatFlags.PathEllipsis)
FORCEFOUND:

        ' StreamReader 오류 처리
        Dim srt As StreamReader
        Try
            srt = New StreamReader(addr, Encoding.Default)
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

                If cbRegex.Checked Then
                    Dim match2 As System.Text.RegularExpressions.Match
                    Dim origin As String = linetext

                    If cbIgnore.Checked = True Then
                        match2 = System.Text.RegularExpressions.Regex.Match(linetext, tbSearch.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    Else
                        match2 = System.Text.RegularExpressions.Regex.Match(linetext, tbSearch.Text)
                    End If

                    linetext = origin

                    If match2.Success Then
RESULT:
                        count += 1
                        lFound += 1
                        If startalreay Then
                            If cbOnlyLines.Checked = False Then
                                str.Append(RSet(line, 10) & ": " & linetext & vbCrLf)
                            Else
                                str.Append(linetext & vbCrLf)
                            End If
                        Else
                            If cbOnlyLines.Checked = False Then
                                str.Append(addr & ":" & vbCrLf & RSet(line, 10) & ": " & linetext & vbCrLf)
                            End If
                            startalreay = True
                            index += 1
                            result.Add(New List(Of String))
                        End If
                        result(index - 1).Add(line & ": " & linetext)
                    End If
                Else
                    If cbIgnore.Checked = True Then
                        If linetext.IndexOf(tbSearch.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                            GoTo RESULT
                        End If
                    Else
                        If linetext.Contains(tbSearch.Text) Then
                            GoTo RESULT
                        End If
                    End If
                End If
                Application.DoEvents()
            Loop
            totalLines += line
            srt.Close()
            If startalreay Then
                If cbOnlyLines.Checked = False Then
                    str.Append("Lines: " & count & vbCrLf & vbCrLf)
                End If
                Dim strArray = New String() {index, addr, count}
                Dim lvt = New ListViewItem(strArray)
                lvResult.Items.Add(lvt)
            End If
            Application.DoEvents()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lvResult_DoubleClick(sender As Object, e As EventArgs) Handles lvResult.DoubleClick
        seletedindex = lvResult.SelectedItems(0).SubItems(0).Text
        filename = lvResult.SelectedItems(0).SubItems(1).Text
        frmResult.Show()
    End Sub

    Private Sub lvResult_KeyDown(sender As Object, e As KeyEventArgs) Handles lvResult.KeyDown
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

        m_Button = New List(Of Object)({bStart, bExtension})
        m_CheckBox = New List(Of Object)({cbRegex, cbIgnore, cbOnlyLines})

        ParseExtension(My.Settings.Extension)
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

    Private Sub bExtension_Click(sender As Object, e As EventArgs) Handles bExtension.Click
        frmExtension.Show()
    End Sub

    ' 이 값은 Math.tanh(i / 7)의 함숫값임.
    Public ReadOnly tanh_value As Double() = {0, 0.141893193766933, 0.278185490325702, 0.404126739757859, 0.51640765518518,
            0.613357260395383, 0.694782670314738, 0.761594155955765, 0.815373942495404, 0.857999961698402,
            0.891373467734719, 0.917252697879849, 0.93717125793686, 0.952414115203671, 0.964027580075817,
            0.972846166112511, 0.979525425675133, 0.984574576974176, 0.988385883107241, 0.991259640913111,
            0.993424677228132, 0.99505475368673, 0.996281474641925, 0.997204320833022, 0.997898380495443, 0.998420268116527}

    Private Sub FormSizeEffectingAuto(ByVal size As Size, Optional ByVal ExpandWithEvents As Boolean = True)
        bStart.Anchor = AnchorStyles.Top
        bExtension.Anchor = AnchorStyles.Top
        cbOnlyLines.Anchor = AnchorStyles.Top
        lAddr.Anchor = AnchorStyles.Top
        lFind.Anchor = AnchorStyles.Top
        lvResult.Anchor = AnchorStyles.Top
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
        bStart.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        bExtension.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        cbOnlyLines.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lAddr.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lFind.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lvResult.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    End Sub

End Class