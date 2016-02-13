<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrammar
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("왼쪽 연산")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("오른쪽 연산")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("가운데 연산")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("문자 세팅", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("왼쪽 숫자")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("오른쪽 숫자")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("일련 숫자", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("해쉬")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("기능", New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("대문자로")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("소문자")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("대소문자", New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("문자열 복호화")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("문자열 암호화")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("직접 치환")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("좌표로 치환")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("치환", New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode13, TreeNode14, TreeNode15, TreeNode16})
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("좌표로 복제")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("복제", New System.Windows.Forms.TreeNode() {TreeNode18})
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("원래 문자 앞에 삽입")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("원래 문자 뒤에 삽입")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("좌표값을 이용하여 삽입")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("삽입", New System.Windows.Forms.TreeNode() {TreeNode20, TreeNode21, TreeNode22})
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("뒤집기")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("위치", New System.Windows.Forms.TreeNode() {TreeNode24})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGrammar))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 25.0!)
        Me.Label1.Location = New System.Drawing.Point(207, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 46)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "문법 : "
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("맑은 고딕", 25.0!)
        Me.TextBox1.Location = New System.Drawing.Point(332, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(622, 52)
        Me.TextBox1.TabIndex = 2
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "노드25"
        TreeNode1.Text = "왼쪽 연산"
        TreeNode2.Name = "노드26"
        TreeNode2.Text = "오른쪽 연산"
        TreeNode3.Name = "노드27"
        TreeNode3.Text = "가운데 연산"
        TreeNode4.Name = "노드4"
        TreeNode4.Text = "문자 세팅"
        TreeNode5.Name = "노드29"
        TreeNode5.Text = "왼쪽 숫자"
        TreeNode6.Name = "노드28"
        TreeNode6.Text = "오른쪽 숫자"
        TreeNode7.Name = "노드3"
        TreeNode7.Text = "일련 숫자"
        TreeNode8.Name = "노드30"
        TreeNode8.Text = "해쉬"
        TreeNode9.Name = "노드2"
        TreeNode9.Text = "기능"
        TreeNode10.Name = "노드20"
        TreeNode10.Text = "대문자로"
        TreeNode11.Name = "노드21"
        TreeNode11.Text = "소문자"
        TreeNode12.Name = "노드19"
        TreeNode12.Text = "대소문자"
        TreeNode13.Name = "노드32"
        TreeNode13.Text = "문자열 복호화"
        TreeNode14.Name = "노드31"
        TreeNode14.Text = "문자열 암호화"
        TreeNode15.Name = "노드16"
        TreeNode15.Text = "직접 치환"
        TreeNode16.Name = "노드14"
        TreeNode16.Text = "좌표로 치환"
        TreeNode17.Name = "노드11"
        TreeNode17.Text = "치환"
        TreeNode18.Name = "노드15"
        TreeNode18.Text = "좌표로 복제"
        TreeNode19.Name = "노드12"
        TreeNode19.Text = "복제"
        TreeNode20.Name = "노드7"
        TreeNode20.Text = "원래 문자 앞에 삽입"
        TreeNode21.Name = "노드8"
        TreeNode21.Text = "원래 문자 뒤에 삽입"
        TreeNode22.Name = "노드17"
        TreeNode22.Text = "좌표값을 이용하여 삽입"
        TreeNode23.Name = "노드33"
        TreeNode23.Text = "삽입"
        TreeNode24.Name = "노드22"
        TreeNode24.Text = "뒤집기"
        TreeNode25.Name = "노드10"
        TreeNode25.Text = "위치"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode9, TreeNode17, TreeNode19, TreeNode23, TreeNode25})
        Me.TreeView1.Size = New System.Drawing.Size(189, 394)
        Me.TreeView1.TabIndex = 3
        '
        'frmGrammar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 418)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmGrammar"
        Me.Text = "문법 만들기"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
End Class
