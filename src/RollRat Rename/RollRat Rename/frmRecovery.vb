'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Text

Public Class frmRecovery

    Public Structure _dataset
        Dim BeforeFileName As String
        Dim AfterFileName As String
        Dim BeforeFileExist As Boolean
        Dim AfterFileExist As Boolean
        Dim MD5Before As String
        Dim MD5After As String
        Dim MD5BeforeOk As Boolean
        Dim MD5AfterOk As Boolean
    End Structure

    Private Structure _dataset_event
        Dim datas As _dataset()
        Dim s_date As String
        Dim address As String
    End Structure

    Dim _Log As New List(Of _dataset_event)

    Public Shared ChkedFolderAddr As String
    Public Shared ChkedDataSet As _dataset()

    Private Sub GetAddressAndDate(ByVal Line As String, ByRef _Date As String, ByRef _Addr As String)
        Dim i As Integer = 1
        Dim __date As New StringBuilder
        Dim __addr As New StringBuilder
        Do : If (Line(i) = "]"c) Then Exit Do
            __date.Append(Line(i))
            i += 1 : Loop
        Do : i += 1
            If (Line(i) = "="c) Then i += 1 : Exit Do
        Loop
        For j As Integer = i To Line.Length - 1 : __addr.Append(Line(j)) : Next
        _Date = __date.ToString()
        _Addr = __addr.ToString()
    End Sub

    Private Sub frmRecovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim LogLines As String() = ReadAllLogLines()
        If LogLines Is Nothing Then
            MsgBox("로그기록파일이 존재하지 않거나 내용이 삭제되어 더 이상 진행할 수 없습니다.", MsgBoxStyle.Critical, "RollRat Rename")
            Close()
        End If
        For i As Integer = 0 To LogLines.Length - 1
            If LogLines(i)(0) = vbTab Then
                Dim _event As _dataset_event
                Dim _date As String = Nothing
                Dim _addr As String = Nothing
                GetAddressAndDate(LogLines(i - 1), _date, _addr)
                _event.s_date = _date
                _event.address = _addr

                Dim j As Integer = i

                Dim _Data As New List(Of _dataset)

                Do
                    Dim k As Integer = 1
                    Dim _Set As _dataset
                    Dim BeforeFileName As New StringBuilder
                    Dim AfterFileName As New StringBuilder
                    Dim Md5Before As New StringBuilder
                    Dim Md5After As New StringBuilder
                    Do
                        BeforeFileName.Append(LogLines(j)(k)) : k += 1
                    Loop Until LogLines(j)(k) = vbTab
                    k += 6
                    Do
                        AfterFileName.Append(LogLines(j)(k)) : k += 1
                    Loop Until LogLines(j)(k) = vbTab
                    k += 1
                    Do
                        Md5Before.Append(LogLines(j)(k)) : k += 1
                    Loop Until LogLines(j)(k) = " "c
                    k += 1
                    Do
                        Md5After.Append(LogLines(j)(k)) : k += 1
                    Loop Until k = LogLines(j).Length

                    _Set.BeforeFileName = BeforeFileName.ToString()
                    _Set.AfterFileName = AfterFileName.ToString()
                    _Set.MD5Before = Md5Before.ToString()
                    _Set.MD5After = Md5After.ToString()

                    _Set.MD5BeforeOk = (MD5Str(_Set.BeforeFileName) = _Set.MD5Before)
                    _Set.MD5AfterOk = (MD5Str(_Set.AfterFileName) = _Set.MD5After)
                    _Set.BeforeFileExist = My.Computer.FileSystem.FileExists(_addr & "\" & _Set.BeforeFileName)
                    _Set.AfterFileExist = My.Computer.FileSystem.FileExists(_addr & "\" & _Set.AfterFileName)

                    _Data.Add(_Set)
                    j += 1
                Loop While j < LogLines.Length AndAlso LogLines(j)(0) = vbTab

                i = j

                _event.datas = _Data.ToArray()
                _Log.Add(_event)
            End If
        Next
        For i As Integer = _Log.Count - 1 To 0 Step -1
            Dim LI As ListViewItem
            Dim _Useable As Boolean = True

            For jk As Integer = 0 To _Log(i).datas.Length - 1
                Dim j = _Log(i).datas(jk)
                If Not (Not j.BeforeFileExist AndAlso j.AfterFileExist AndAlso j.MD5AfterOk AndAlso j.MD5BeforeOk) Then
                    _Useable = False
                    Exit For
                End If
            Next

            LI = ListView1.Items.Add(New ListViewItem(New String() {_Log.Count - i, _Log(i).s_date, _Log(i).address, _Useable.ToString}))
            LI.StateImageIndex = 0
            If Not _Useable Then
                LI.ForeColor = Color.White
                LI.BackColor = Color.Orange
            End If
        Next
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            If ListView1.SelectedItems.Item(i).SubItems(3).Text = "True" Then
                Process.Start(ListView1.SelectedItems.Item(i).SubItems(2).Text)
            End If
            Exit For
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            If ListView1.SelectedItems.Item(i).SubItems(3).Text = "True" Then
                Dim BeforeFN As New List(Of String)
                Dim AfterFN As New List(Of String)
                Dim _LogIndex As Integer = ListView1.Items.Count - CInt(ListView1.SelectedItems.Item(i).Text)
                For Each _DS As _dataset In _Log(_LogIndex).datas
                    BeforeFN.Add(_DS.AfterFileName)
                    AfterFN.Add(_DS.BeforeFileName)
                Next

                '
                '   사용자 동의 체크
                '
                Dim maximum_message As Integer = 25
                Dim message_bottom As String = ""
                If BeforeFN.Count < maximum_message Then
                    For j = 0 To BeforeFN.Count - 1
                        If maximum_message = 0 Then
                            Exit For
                        End If
                        message_bottom += BeforeFN(j) & " -> " & AfterFN(j) & vbCrLf
                        maximum_message -= 1
                    Next
                Else

                    '
                    '   앞의 12개의 메시지를, 뒤에 12개의 
                    '   메시지를 메시지창에 보여줍니다.
                    '
                    maximum_message = 12
                    For j = 0 To BeforeFN.Count - 1
                        If maximum_message = 0 Then
                            Exit For
                        End If
                        message_bottom += BeforeFN(j) & " -> " & AfterFN(j) & vbCrLf
                        maximum_message -= 1
                    Next
                    message_bottom += vbTab & "." & vbCrLf & vbTab & "." & vbCrLf & vbTab & "." & vbCrLf
                    For j = BeforeFN.Count - 12 To BeforeFN.Count - 1
                        message_bottom += BeforeFN(j) & " -> " & AfterFN(j) & vbCrLf
                    Next
                End If

                If MsgBox("다음 원래(왼쪽)이름들이 오른쪽과 같이 바뀌는 것에 동의하십니까?" & vbCrLf & vbCrLf & message_bottom, _
                          MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "RollRat Rename") = MsgBoxResult.Yes Then

                    Dim str_str As New List(Of String)

                    '
                    '   이름 바꾸기 실행 & 로그 작성
                    '
                    Try
                        For j = 0 To BeforeFN.Count - 1
                            My.Computer.FileSystem.RenameFile(ListView1.SelectedItems.Item(i).SubItems(2).Text & "\" & BeforeFN(j), AfterFN(j))
                            str_str.Add(vbTab & BeforeFN(j) & vbTab & vbTab & "->" & vbTab & vbTab & AfterFN(j) & vbTab & MD5Str(BeforeFN(j)) & " " & MD5Str(AfterFN(j)))
                        Next
                    Catch ex As Exception
                        MsgBox("작업에 오류가 생겨 작동을 중지하였습니다. 자세한 사항은 로그기록을 참조하십시오.", MsgBoxStyle.Critical, "RollRat Rename")
                        WriteLog("Aborted the requested operation. [RenameButton]", True, err_None)
                        WriteLog("  ErrMsg:" & ex.Message & vbCrLf & "  Success : " & str_str.Count)
                        If str_str.Count <> 0 Then
                            WriteLog(" ------- Successful Rename List Begin -------")
                            WriteLines(str_str.ToArray())
                            WriteLog(" ------- Successful Rename List End -------")
                        End If
                        Exit Sub
                    End Try

                    MsgBox("요청하신 작업이 완료되었습니다.", MsgBoxStyle.Information, "RollRat Rename")
                    WriteLog("   - addr=" & ListView1.SelectedItems.Item(i).SubItems(2).Text)
                    WriteLines(str_str.ToArray())
                    WriteLog("Complete the requested operation. [RenameButton]")
                End If

            Else
                MsgBox("해당 항목으로 되돌리기를 실행할 수 없습니다. 자세한 정보는 메뉴얼을 참고하십시오.", MsgBoxStyle.Critical, "RollRat Rename")
            End If
            Exit For
        Next
    End Sub

    Private Sub 상세한정보확인KToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 상세한정보확인KToolStripMenuItem.Click
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim _LogIndex As Integer = ListView1.Items.Count - CInt(ListView1.SelectedItems.Item(i).Text)
            ChkedDataSet = _Log(_LogIndex).datas
            ChkedFolderAddr = _Log(_LogIndex).address
            frmRecoveryChk.Show()
            Exit For
        Next
    End Sub

End Class