<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPannel
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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Button")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CheckBox")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("GroupBox")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Edit")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Edit(MultiLine)")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("RadioButton")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Combobox")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("C스타일 윈도우즈창", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7})
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("사용자가 추가한 아이템")
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.추가ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.기본세팅제스타일에맞춰서창조ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WndProc세팅ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.기본헤더ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.메세지세팅ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.선택한항목에대해페인트이벤트추가ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.라인ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.렉트ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.원ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Button"
        TreeNode1.Text = "Button"
        TreeNode2.Name = "CheckBox"
        TreeNode2.Text = "CheckBox"
        TreeNode3.Name = "GroupBox"
        TreeNode3.Text = "GroupBox"
        TreeNode4.Name = "Edit"
        TreeNode4.Text = "Edit"
        TreeNode5.Name = "Edit(MultiLine)"
        TreeNode5.Text = "Edit(MultiLine)"
        TreeNode6.Name = "RadioButton"
        TreeNode6.Text = "RadioButton"
        TreeNode7.Name = "Combobox"
        TreeNode7.Text = "Combobox"
        TreeNode8.Name = "CStyleWND"
        TreeNode8.Text = "C스타일 윈도우즈창"
        TreeNode9.Name = "UserITEM"
        TreeNode9.Text = "사용자가 추가한 아이템"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9})
        Me.TreeView1.Size = New System.Drawing.Size(359, 353)
        Me.TreeView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(241, 411)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 35)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Add Control"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(108, 411)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(130, 35)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Property"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 411)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 34)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Delete"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 371)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(359, 34)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Export"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.추가ToolStripMenuItem, Me.기본헤더ToolStripMenuItem, Me.메세지세팅ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(135, 70)
        '
        '추가ToolStripMenuItem
        '
        Me.추가ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.기본세팅제스타일에맞춰서창조ToolStripMenuItem, Me.WndProc세팅ToolStripMenuItem})
        Me.추가ToolStripMenuItem.Name = "추가ToolStripMenuItem"
        Me.추가ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.추가ToolStripMenuItem.Text = "추가"
        '
        '기본세팅제스타일에맞춰서창조ToolStripMenuItem
        '
        Me.기본세팅제스타일에맞춰서창조ToolStripMenuItem.Name = "기본세팅제스타일에맞춰서창조ToolStripMenuItem"
        Me.기본세팅제스타일에맞춰서창조ToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.기본세팅제스타일에맞춰서창조ToolStripMenuItem.Text = "기본세팅(제스타일에 맞춰서 창조)"
        '
        'WndProc세팅ToolStripMenuItem
        '
        Me.WndProc세팅ToolStripMenuItem.Name = "WndProc세팅ToolStripMenuItem"
        Me.WndProc세팅ToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.WndProc세팅ToolStripMenuItem.Text = "WndProc세팅"
        '
        '기본헤더ToolStripMenuItem
        '
        Me.기본헤더ToolStripMenuItem.Name = "기본헤더ToolStripMenuItem"
        Me.기본헤더ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.기본헤더ToolStripMenuItem.Text = "기본헤더"
        '
        '메세지세팅ToolStripMenuItem
        '
        Me.메세지세팅ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.선택한항목에대해페인트이벤트추가ToolStripMenuItem, Me.DCToolStripMenuItem})
        Me.메세지세팅ToolStripMenuItem.Name = "메세지세팅ToolStripMenuItem"
        Me.메세지세팅ToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.메세지세팅ToolStripMenuItem.Text = "메세지세팅"
        '
        '선택한항목에대해페인트이벤트추가ToolStripMenuItem
        '
        Me.선택한항목에대해페인트이벤트추가ToolStripMenuItem.Name = "선택한항목에대해페인트이벤트추가ToolStripMenuItem"
        Me.선택한항목에대해페인트이벤트추가ToolStripMenuItem.Size = New System.Drawing.Size(274, 22)
        Me.선택한항목에대해페인트이벤트추가ToolStripMenuItem.Text = "선택한 항목에대해 페인트이벤트추가"
        '
        'DCToolStripMenuItem
        '
        Me.DCToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.라인ToolStripMenuItem, Me.렉트ToolStripMenuItem, Me.원ToolStripMenuItem})
        Me.DCToolStripMenuItem.Name = "DCToolStripMenuItem"
        Me.DCToolStripMenuItem.Size = New System.Drawing.Size(274, 22)
        Me.DCToolStripMenuItem.Text = "DC"
        '
        '라인ToolStripMenuItem
        '
        Me.라인ToolStripMenuItem.Name = "라인ToolStripMenuItem"
        Me.라인ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.라인ToolStripMenuItem.Text = "라인"
        '
        '렉트ToolStripMenuItem
        '
        Me.렉트ToolStripMenuItem.Name = "렉트ToolStripMenuItem"
        Me.렉트ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.렉트ToolStripMenuItem.Text = "렉트"
        '
        '원ToolStripMenuItem
        '
        Me.원ToolStripMenuItem.Name = "원ToolStripMenuItem"
        Me.원ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.원ToolStripMenuItem.Text = "원"
        '
        'frmPannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TreeView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPannel"
        Me.Text = "Pannel"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 추가ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 기본세팅제스타일에맞춰서창조ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WndProc세팅ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 기본헤더ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 메세지세팅ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 선택한항목에대해페인트이벤트추가ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 라인ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 렉트ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 원ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
