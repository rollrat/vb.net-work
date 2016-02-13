'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Security.Principal
Imports System.IO
Imports System.Text

Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If (New WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator) Then
            ShowMsgCritical("이 프로그램은 관리자권한으로 실행할 수 없습니다.") : End
        End If
    End Sub

#Region "Message Box"

    Private Sub ShowMsgCritical(ByVal body As String, Optional ByVal title As String = "Subtitle Renamer")
        MsgBox(body, MsgBoxStyle.Critical, title)
    End Sub
    Private Sub ShowMsgWarning(ByVal body As String, Optional ByVal title As String = "Subtitle Renamer")
        MsgBox(body, MsgBoxStyle.Exclamation, title)
    End Sub
    Private Sub ShowMsgInform(ByVal body As String, Optional ByVal title As String = "Subtitle Renamer")
        MsgBox(body, MsgBoxStyle.Information, title)
    End Sub

#End Region

#Region "Drag & Drop"

    Private Sub tbMovieAddr_DragDrop(sender As Object, e As DragEventArgs) Handles tbMovieAddr.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If filePaths.Length <> 1 Then
                ShowMsgCritical("하나의 폴더만 끌어오십시오.")
            Else
                tbMovieAddr.Text = CType(e.Data.GetData(DataFormats.FileDrop), String())(0)
            End If
        End If
    End Sub
    Private Sub tbMovieAddr_DragEnter(sender As Object, e As DragEventArgs) Handles tbMovieAddr.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub tbSubtitleAddr_DragDrop(sender As Object, e As DragEventArgs) Handles tbSubtitleAddr.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If filePaths.Length <> 1 Then
                ShowMsgCritical("하나의 폴더만 끌어오십시오.")
            Else
                tbSubtitleAddr.Text = CType(e.Data.GetData(DataFormats.FileDrop), String())(0)
            End If
        End If
    End Sub
    Private Sub tbSubtitleAddr_DragEnter(sender As Object, e As DragEventArgs) Handles tbSubtitleAddr.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

#End Region

#Region "Path Comparer"

    Declare Unicode Function StrCmpLogicalW Lib "shlwapi.dll" (ByVal s1 As String, ByVal s2 As String) As Integer

    Public Class PathComparer
        Implements IComparer

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Return StrCmpLogicalW(x, y)
        End Function
    End Class
    Public Shared Function GetPathComparer() As IComparer
        Return CType(New PathComparer(), IComparer)
    End Function

#End Region

#Region "Parse Filename"

    Public Shared symbolList As String = "._+-=$[]{}()^%!#&"

    Public Shared Function is_number(ByVal ch As Char) As Boolean
        Dim i As Integer = AscW(ch)
        If AscW("0"c) <= i AndAlso i <= AscW("9"c) Then
            Return True
        End If
        Return False
    End Function

    Public Shared Function is_deli(ByVal ch As Char) As Boolean
        Dim deli As String = symbolList
        For Each ch_t As Char In deli
            If ch_t = ch Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function ParsePattern(ByVal target As String) As String
        Dim ret As New StringBuilder
        For i As Integer = 0 To target.Length - 1
            If is_number(target(i)) Then
                Do
                    i += 1
                    If i >= target.Length Then Exit Do
                Loop While is_number(target(i))
                i -= 1
                ret.Append("숫자+")
            ElseIf is_deli(target(i)) Then
                Do
                    i += 1
                    If i >= target.Length Then Exit Do
                Loop While is_deli(target(i))
                i -= 1
                ret.Append("기호+")
            Else
                Do
                    i += 1
                    If i >= target.Length Then Exit Do
                Loop While Not is_number(target(i)) AndAlso Not is_deli(target(i))
                i -= 1
                ret.Append("문자+")
            End If
        Next
        ret.Remove(ret.Length - 1, 1)
        Return ret.ToString
    End Function

    Public Function SplitPattern(ByVal target As String) As List(Of String)
        Dim ret As New List(Of String)
        For i As Integer = 0 To target.Length - 1
            Dim replace_string As String = ""
            If is_number(target(i)) Then
                Do
                    replace_string += target(i)
                    i += 1
                    If i >= target.Length Then Exit Do
                Loop While is_number(target(i))
                i -= 1
            ElseIf is_deli(target(i)) Then
                Do
                    replace_string += target(i)
                    i += 1
                    If i >= target.Length Then Exit Do
                Loop While is_deli(target(i))
                i -= 1
            Else
                Do
                    replace_string += target(i)
                    i += 1
                    If i >= target.Length Then Exit Do
                Loop While Not is_number(target(i)) AndAlso Not is_deli(target(i))
                i -= 1
            End If
            ret.Add(replace_string)
        Next
        Return ret
    End Function

    Private Function CheckPatternOverlap(files As String(), type As String) As Boolean
        Dim first_pattern As String = Nothing
        Dim first_pattern_already As Boolean = False
        For Each x In files
            If first_pattern_already Then
                If Not first_pattern = ParsePattern(Path.GetFileNameWithoutExtension(x)) Then
                    ShowMsgCritical(type & " 동일하지 않은 패턴을 발견하여 계속 실행할 수 없습니다." & vbCrLf & _
                                    "대상:" & x & vbCrLf & _
                                    "패턴:" & first_pattern)
                    Return False
                End If
            Else
                first_pattern_already = True
                first_pattern = ParsePattern(Path.GetFileNameWithoutExtension(x))
            End If
        Next
        Return True
    End Function

#End Region

    Private Sub bSubtitle_Click(sender As Object, e As EventArgs) Handles bSubtitle.Click
        Dim filesMovie = My.Computer.FileSystem.GetFiles(tbMovieAddr.Text, FileIO.SearchOption.SearchTopLevelOnly, "*.*").ToArray
        Dim filesSubtitle = My.Computer.FileSystem.GetFiles(tbSubtitleAddr.Text, FileIO.SearchOption.SearchTopLevelOnly, "*.*").ToArray

        Array.Sort(filesMovie, GetPathComparer())
        Array.Sort(filesSubtitle, GetPathComparer())

        If filesMovie.Count = filesSubtitle.Count Then

            If Not CheckPatternOverlap(filesMovie, "[동영상]") Or Not CheckPatternOverlap(filesSubtitle, "[자막]") Then Exit Sub

            Dim filenameMovie As New List(Of String)
            Dim filenameSubtitle As New List(Of String)
            Dim extensionSubtitle As String = Path.GetExtension(filesSubtitle(0))
            For Each fullname In filesMovie
                filenameMovie.Add(Path.GetFileNameWithoutExtension(fullname))
            Next
            For Each fullname In filesSubtitle
                If extensionSubtitle = Path.GetExtension(fullname) Then
                    filenameSubtitle.Add(Path.GetFileName(fullname))
                Else
                    ShowMsgCritical("확장자가 다른 파일이 존재합니다." & vbCrLf &
                                     "대상1: " & extensionSubtitle & vbCrLf &
                                     "대상2: " & Path.GetExtension(fullname))
                    Exit Sub
                End If
            Next

            Dim splitsMovie As List(Of String) = SplitPattern(filenameMovie(0))
            Dim splitsSubtitle As List(Of String) = SplitPattern(filenameSubtitle(0))
            Dim movieDiff As New List(Of Integer)
            Dim subtitleDiff As New List(Of Integer)

            For i As Integer = 0 To splitsMovie.Count - 1
                movieDiff.Add(0)
                subtitleDiff.Add(0)
            Next

            For i As Integer = 1 To filesMovie.Count - 1
                Dim splitsMovieA As List(Of String) = SplitPattern(filenameMovie(i))
                For j As Integer = 0 To splitsMovie.Count - 1
                    If splitsMovieA(j) <> splitsMovie(j) Then
                        movieDiff(j) += 1
                    End If
                Next
            Next
            For i As Integer = 1 To filesMovie.Count - 1
                Dim splitsSubtitleA As List(Of String) = SplitPattern(filenameSubtitle(i))
                For j As Integer = 0 To splitsSubtitle.Count - 1
                    If splitsSubtitleA(j) <> splitsSubtitle(j) Then
                        subtitleDiff(j) += 1
                    End If
                Next
            Next

            Dim maxMovie As Integer = movieDiff(0)
            Dim maxSubtitle As Integer = subtitleDiff(0)
            Dim maxMoviePos As Integer = 0
            Dim maxSubtitlePos As Integer = 0
            For i As Integer = 0 To movieDiff.Count - 1
                If maxMovie < movieDiff(i) Then
                    maxMovie = movieDiff(i)
                    maxMoviePos = i
                End If
            Next
            For i As Integer = 0 To subtitleDiff.Count - 1
                If maxSubtitle < subtitleDiff(i) Then
                    maxSubtitle = subtitleDiff(i)
                    maxSubtitlePos = i
                End If
            Next
            
            Dim resultSubtitle As New List(Of String)
            For i As Integer = 0 To filenameSubtitle.Count - 1
                If Not cbAnime.Checked Then
                    Dim movieFront As String = ""
                    Dim movieBack As String = ""
                    Dim splitsMovieNow = SplitPattern(filenameMovie(i))
                    For j As Integer = 0 To maxMoviePos - 1
                        movieFront += splitsMovieNow(j)
                    Next
                    For j As Integer = maxMoviePos + 1 To movieDiff.Count - 1
                        movieBack += splitsMovieNow(j)
                    Next
                    movieBack &= extensionSubtitle
                    resultSubtitle.Add(movieFront & SplitPattern(filenameSubtitle(i))(maxSubtitlePos) & movieBack)
                Else
                    Dim j As Integer
                    Dim replacePartSubtitle As String = SplitPattern(filenameSubtitle(i))(maxSubtitlePos)
                    For j = 0 To filenameSubtitle.Count
                        If j = filenameSubtitle.Count Then
                            ShowMsgCritical("이 모드로 실행할 수 없습니다.")
                            Exit Sub
                        End If
                        If replacePartSubtitle.TrimStart("0"c) = SplitPattern(filenameMovie(j))(maxMoviePos).TrimStart("0"c) Then Exit For
                    Next
                    Dim movieFront As String = ""
                    Dim movieBack As String = ""
                    Dim splitsMovieNow = SplitPattern(filenameMovie(j))
                    For k As Integer = 0 To maxMoviePos - 1
                        movieFront += splitsMovieNow(k)
                    Next
                    For k As Integer = maxMoviePos + 1 To movieDiff.Count - 1
                        movieBack += splitsMovieNow(k)
                    Next
                    movieBack &= extensionSubtitle
                    resultSubtitle.Add(movieFront & SplitPattern(filenameSubtitle(i))(maxSubtitlePos).PadLeft(2, "0") & movieBack)
                End If
            Next
            '//////////////////////////////////////////////////////////////////

            Dim maximum_message As Integer = 25
            Dim message_bottom As String = ""
            If filenameSubtitle.Count < maximum_message Then
                For i = 0 To filenameSubtitle.Count - 1
                    If maximum_message = 0 Then
                        Exit For
                    End If
                    message_bottom += filenameSubtitle(i) & " -> " & resultSubtitle(i) & vbCrLf
                    maximum_message -= 1
                Next
            Else
                maximum_message = 12
                For i = 0 To filenameSubtitle.Count - 1
                    If maximum_message = 0 Then
                        Exit For
                    End If
                    message_bottom += filenameSubtitle(i) & " -> " & resultSubtitle(i) & vbCrLf
                    maximum_message -= 1
                Next
                message_bottom += vbTab & "." & vbCrLf & vbTab & "." & vbCrLf & vbTab & "." & vbCrLf
                For i = filenameSubtitle.Count - 12 To filenameSubtitle.Count - 1
                    message_bottom += filenameSubtitle(i) & " -> " & resultSubtitle(i) & vbCrLf
                Next
            End If

            If MsgBox("한 번 변경되면 다시 되돌릴 수 없습니다. 다음 원래(왼쪽)이름들이 오른쪽과 같이 바뀌는 것에 동의하십니까?" & vbCrLf & vbCrLf & message_bottom, _
                      MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Subtitle Renamer") = MsgBoxResult.Yes Then

                Try
                    For i = 0 To filenameSubtitle.Count - 1
                        My.Computer.FileSystem.RenameFile(tbSubtitleAddr.Text & "\" & filenameSubtitle(i), resultSubtitle(i))
                    Next
                Catch ex As Exception
                    ShowMsgCritical("작업에 오류가 생겨 작동을 중지하였습니다. 자세한 사항은 로그기록을 참조하십시오.")
                    Exit Sub
                End Try

                ShowMsgInform("요청하신 작업이 완료되었습니다.")
            End If

        Else
            ShowMsgCritical("파일 개수가 달라 진행할 수 없습니다.")
        End If

    End Sub

End Class
