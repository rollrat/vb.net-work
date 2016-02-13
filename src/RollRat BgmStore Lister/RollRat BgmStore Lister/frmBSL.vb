'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Net
Imports System.Security.Policy

Public Class frmBSL

    Public Const URL_Category As String = "https://bgmstore.net/?q_type=category&q="
    Public Const URL_General As String = "https://bgmstore.net/?q_type=title&q_mode=general&q="
    Public Const URL_EachWord As String = "https://bgmstore.net/?q_type=title&q_mode=word&q="
    Public Const URL_Perpect As String = "https://bgmstore.net/?q_type=title&q_mode=strict&q="
    Public Const URL_Address As String = "https://bgmstore.net/?q_type=url&q_mode=general&q="
    Public Const URL_Nickname As String = "https://bgmstore.net/?q_type=nickname&q_mode=general&q="
    Public Const BSL_URL As String = "https://bgmstore.net/view/"
    Public Const BSL_PlayURL As String = "http://player.bgmstore.net/"
    Public Const HELPER_Descending As String = "&sort_by=vote&sort_type=desc"
    Public Const HELPER_Ascending As String = "&sort_by=vote&sort_type=asc"

    Public Const PATTERN_Stolen As String = "(?<=player\.bgmstore\.net\/)\w+"
    Public Const PATTERN_Listing As String = "search_result[\s\S]*?category"">(.*?)</a>[\s\S]*?<a href=""(.*?)"".*?>(.*?)</a>.*?10pt;"">(.*?)</span>.*?Cnt"">(.*?)</span>.*?Cnt"">(.*?)</span>[\s\S]*?<a href=""(.*?)>mp3"

    Public Const ProgramName As String = "RollRat BgmStore Lister"

    Public Enum BSSearchType
        General = 0
        Normal = 0
        Category
        EachWord
        Perpect
        Address
        Nickname
    End Enum

    Public Enum BSOrderType
        Normal
        Descended
        Ascended
    End Enum

    Public Structure BSSearchInfo
        Dim Category As String
        Dim Address As String
        Dim Title As String
        Dim RunTime As String
        Dim Download As String
        Dim Reply As String
        Dim Recommand As String
    End Structure


    '
    '   페이지가 저장된 문자열입니다.
    '
    Public PageFromURL As String
    Public PageDownloadError As Boolean

    Public ResultAsSearchData As List(Of BSSearchInfo)


    '
    '   파일이름으로 적용될 수 없는 문자 삭제
    '
    Public Function CheckWindowsFileNameIrregularAndDelete(ByVal stritem As String) As String
        Dim irregular As String = "\/:*?""<>|"
        Dim strstream As New StringBuilder

        For Each ch As Char In stritem
            Dim targeting As Boolean = False
            For Each ch_t As Char In irregular
                If ch_t = ch Then
                    targeting = True
                    Exit For
                End If
            Next
            If Not targeting Then
                strstream.Append(ch)
            End If
        Next

        Return strstream.ToString()
    End Function


    '
    '   URL을 통해 브금저장소의 사이트 코드를 가져옵니다.
    '
    Public Function GetBgmstoreCodeFromURL(ByVal blog_write_address As String) As String
        Dim ret_str As String = ""

        Try
            '
            '   네이버 블로그 타겟팅
            '
            If blog_write_address.StartsWith("http://blog.naver.com/") Then
                ret_str = New System.Text.RegularExpressions.Regex _
                        (PATTERN_Stolen).Match( _
                        New IO.StreamReader(Net.HttpWebRequest.Create( _
                        "http://blog.naver.com/PostView.nhn?blogId=" & _
                        blog_write_address.Split("/")(3) & "&logNo=" & _
                        blog_write_address.Split("/")(4)).GetResponse().GetResponseStream()).ReadToEnd()).Value()
            Else
                ret_str = New System.Text.RegularExpressions.Regex _
                        (PATTERN_Stolen).Match( _
                        New IO.StreamReader(Net.HttpWebRequest.Create( _
                        blog_write_address).GetResponse().GetResponseStream()).ReadToEnd()).Value()
            End If
        Catch ex As Exception
            MsgBox("브금저장소 플레이어를 찾지 못했습니다.", MsgBoxStyle.Critical, ProgramName)
        End Try

        Return ret_str
    End Function


    '
    '   URL을 통해 페이지를 다운로드합니다.
    '
    Public Sub DownloadURL(ByVal address_of_url As String)
        Try
            Dim wclient As New Net.WebClient()
            wclient.Encoding = System.Text.Encoding.UTF8
            PageFromURL = wclient.DownloadString(address_of_url)
            PageDownloadError = False
        Catch ex As Exception
            PageDownloadError = True
            MsgBox(ex.Message, MsgBoxStyle.Critical, ProgramName)
        End Try
    End Sub


    '
    '   키워드를 통해 브금저장소의 검색페이지를 다운로드 합니다.
    '
    Public Sub DownloadBgmstoreSearchPage(ByVal search_contents As String, _
                                          Optional ByVal search_type As BSSearchType = BSSearchType.Normal, _
                                          Optional ByRef order_type As BSOrderType = BSOrderType.Normal)
        Dim SearchType As String
        Dim OrderType As String
        Select Case search_type
            Case BSSearchType.Address : SearchType = URL_Address
            Case BSSearchType.Category : SearchType = URL_Category
            Case BSSearchType.EachWord : SearchType = URL_EachWord
            Case BSSearchType.Nickname : SearchType = URL_Nickname
            Case BSSearchType.Perpect : SearchType = URL_Perpect
            Case Else : SearchType = URL_General
        End Select
        If search_type = BSSearchType.Address Then
            order_type = BSOrderType.Normal
        End If
        Select Case order_type
            Case BSOrderType.Ascended : OrderType = HELPER_Ascending
            Case BSOrderType.Descended : OrderType = HELPER_Descending
            Case Else : OrderType = New String("")
        End Select
        DownloadURL(SearchType & search_contents & OrderType)
    End Sub


    '
    '   Page를 분석하여 나열한 자료를 가져옵니다.
    '
    Public Function GetListingData() As List(Of BSSearchInfo)
        Dim Result As New List(Of BSSearchInfo)
        Dim Matches As MatchCollection = Regex.Matches(PageFromURL, PATTERN_Listing)
        For Each Match As Match In Matches
            Dim BSInfo As BSSearchInfo
            With Match
                BSInfo.Category = .Groups(1).Value
                BSInfo.Address = .Groups(2).Value
                BSInfo.Title = replace(.Groups(3).Value)
                BSInfo.RunTime = .Groups(4).Value
                BSInfo.Reply = .Groups(5).Value
                BSInfo.Recommand = .Groups(6).Value
                BSInfo.Download = .Groups(7).Value
            End With
            Result.Add(BSInfo)
        Next
        Return Result
    End Function


    '
    '   HTML 독립체 호환용 문자열 대체
    '
    Private Function replace(ByVal str As String) As String
        Dim strs As String = str
        Dim oj() As String = {"&nbsp;", "&amp;", "&quot;", "&lt;", _
           "&gt;", "&reg;", "&copy;", "&bull;", "&trade;", "&#39;"}
        Dim kj() As String = {" ", "&", """", "<", ">", "Â®", "Â©", "â€¢", "â„¢", "'"}
        For i As Integer = 0 To oj.Length - 1
            strs = strs.Replace(oj(i), kj(i))
        Next
        Return strs
    End Function


    '
    '   Bgm을 검색하고 나열합니다.
    '
    Public Sub SearchBgmAndListing(ByVal search_contents As String, _
                         Optional ByVal search_type As BSSearchType = BSSearchType.Normal, _
                         Optional ByRef order_type As BSOrderType = BSOrderType.Normal)
        DownloadBgmstoreSearchPage(search_contents, search_type, order_type)
        If PageDownloadError Then Exit Sub
        If Not ResultAsSearchData Is Nothing Then ResultAsSearchData.Clear()
        ResultAsSearchData = GetListingData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text.StartsWith("http://") Or TextBox1.Text.StartsWith("https://") Then
            Dim url As String = GetBgmstoreCodeFromURL(TextBox1.Text)
            If Not url Is "" Then
                TextBox1.Text = url
                ComboBox1.SelectedIndex = 1
                Button1.PerformClick()
                Exit Sub
            End If
        End If

        Dim SearchType As BSSearchType
        Dim OrderType As BSOrderType

        Select Case ComboBox1.SelectedIndex
            Case 0 : SearchType = BSSearchType.General
            Case 1 : SearchType = BSSearchType.Address
            Case 2 : SearchType = BSSearchType.Nickname
        End Select

        Select Case ComboBox2.SelectedIndex
            Case 1
                If SearchType = BSSearchType.General Then
                    SearchType = BSSearchType.EachWord
                End If
            Case 2
                If SearchType = BSSearchType.General Then
                    SearchType = BSSearchType.Perpect
                End If
        End Select

        Select Case ComboBox3.SelectedIndex
            Case 0 : OrderType = BSOrderType.Normal
            Case 1 : OrderType = BSOrderType.Descended
            Case 2 : OrderType = BSOrderType.Ascended
        End Select

        SearchBgmAndListing(TextBox1.Text, SearchType, OrderType)

        If ResultAsSearchData.Count <> 0 Then
            Dim count As Integer = 1
            Label2.Text = ResultAsSearchData.Count & "건"
            ListView1.Items.Clear()
            For Each BSInfo As BSSearchInfo In ResultAsSearchData
                ListView1.Items.Add(New ListViewItem(New String() { _
                                                     count, _
                                                     BSInfo.Category, _
                                                     BSInfo.Title, _
                                                     BSInfo.RunTime, _
                                                     BSInfo.Reply, _
                                                     BSInfo.Recommand}))
                count += 1
            Next
        End If
    End Sub

    Private Sub frmBSL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 1
        TextBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 1 Or ComboBox1.SelectedIndex = 2 Then
            ComboBox2.Enabled = False
        Else
            ComboBox2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Checked = True
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Checked = False
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        For i = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Checked = Not ListView1.Items(i).Checked
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            WebBrowser1.Navigate(New Uri(BSL_PlayURL & ResultAsSearchData(ListView1.SelectedItems.Item(i).Text - 1).Address.Split("/"c)(2)))
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Async Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ListView1.Enabled = False
        Button1.Enabled = False
        TextBox1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        For i As Integer = 0 To ListView1.CheckedItems.Count - 1
            Dim wclient As New Net.WebClient()
            Label4.Text = (i + 1) & "/"c & ListView1.CheckedItems.Count
            AddHandler wclient.DownloadProgressChanged, AddressOf ProgressChanged
            Await wclient.DownloadFileTaskAsync(New Uri(ResultAsSearchData(ListView1.CheckedItems.Item(i).Text - 1).Download), _
                                  TextBox2.Text & "\"c & CheckWindowsFileNameIrregularAndDelete(ResultAsSearchData( _
                                                                          ListView1.CheckedItems.Item(i).Text - 1).Title) & ".mp3")
        Next
        ListView1.Enabled = True
        Button1.Enabled = True
        TextBox1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        MsgBox("다운로드 완료", MsgBoxStyle.Information, ProgramName)
    End Sub

    'Private Async Sub a(ByVal wclient As Net.WebClient, ByVal i As Integer)
    '    Await wclient.DownloadFileAsync(New Uri(ResultAsSearchData(ListView1.CheckedItems.Item(i).Text - 1).Download), _
    '                              TextBox2.Text & "\"c & CheckWindowsFileNameIrregularAndDelete(ResultAsSearchData( _
    '                                                                      ListView1.CheckedItems.Item(i).Text - 1).Title) & ".mp3", )
    'End Sub

    Private Sub ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100

        ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub 웹에서보기VToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 웹에서보기VToolStripMenuItem.Click
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Process.Start(BSL_URL & ResultAsSearchData(ListView1.SelectedItems.Item(i).Text - 1).Address.Split("/"c)(2))
        Next
    End Sub

End Class
