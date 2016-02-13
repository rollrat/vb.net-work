<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDistortion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDistortion))
        Me.bOpen = New System.Windows.Forms.Button()
        Me.bSave = New System.Windows.Forms.Button()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.bSearch = New System.Windows.Forms.Button()
        Me.bReference = New System.Windows.Forms.Button()
        Me.lvResult = New System.Windows.Forms.ListBox()
        Me.rtbCode = New System.Windows.Forms.RichTextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbRegex = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbOption = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RunFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lvIntellisense = New RollRat_New_Distortion.ExListBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bOpen
        '
        Me.bOpen.Location = New System.Drawing.Point(12, 13)
        Me.bOpen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bOpen.Name = "bOpen"
        Me.bOpen.Size = New System.Drawing.Size(256, 31)
        Me.bOpen.TabIndex = 0
        Me.bOpen.Text = "Open"
        Me.bOpen.UseVisualStyleBackColor = True
        '
        'bSave
        '
        Me.bSave.Enabled = False
        Me.bSave.Location = New System.Drawing.Point(798, 13)
        Me.bSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(256, 31)
        Me.bSave.TabIndex = 1
        Me.bSave.Text = "Save"
        Me.bSave.UseVisualStyleBackColor = True
        '
        'tbSearch
        '
        Me.tbSearch.Enabled = False
        Me.tbSearch.Location = New System.Drawing.Point(12, 51)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(978, 23)
        Me.tbSearch.TabIndex = 2
        '
        'bSearch
        '
        Me.bSearch.Enabled = False
        Me.bSearch.Location = New System.Drawing.Point(536, 13)
        Me.bSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSearch.Name = "bSearch"
        Me.bSearch.Size = New System.Drawing.Size(256, 31)
        Me.bSearch.TabIndex = 3
        Me.bSearch.Text = "Search"
        Me.bSearch.UseVisualStyleBackColor = True
        '
        'bReference
        '
        Me.bReference.Enabled = False
        Me.bReference.Location = New System.Drawing.Point(274, 13)
        Me.bReference.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bReference.Name = "bReference"
        Me.bReference.Size = New System.Drawing.Size(256, 31)
        Me.bReference.TabIndex = 4
        Me.bReference.Text = "Reference"
        Me.bReference.UseVisualStyleBackColor = True
        '
        'lvResult
        '
        Me.lvResult.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvResult.FormattingEnabled = True
        Me.lvResult.ItemHeight = 15
        Me.lvResult.Location = New System.Drawing.Point(12, 110)
        Me.lvResult.Name = "lvResult"
        Me.lvResult.ScrollAlwaysVisible = True
        Me.lvResult.Size = New System.Drawing.Size(360, 394)
        Me.lvResult.TabIndex = 5
        '
        'rtbCode
        '
        Me.rtbCode.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbCode.Location = New System.Drawing.Point(378, 110)
        Me.rtbCode.Name = "rtbCode"
        Me.rtbCode.Size = New System.Drawing.Size(676, 394)
        Me.rtbCode.TabIndex = 6
        Me.rtbCode.Text = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "텍스트 파일|*.txt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 507)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Load File : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(84, 507)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "None"
        '
        'cbRegex
        '
        Me.cbRegex.AutoSize = True
        Me.cbRegex.Location = New System.Drawing.Point(996, 53)
        Me.cbRegex.Name = "cbRegex"
        Me.cbRegex.Size = New System.Drawing.Size(58, 19)
        Me.cbRegex.TabIndex = 9
        Me.cbRegex.Text = "Regex"
        Me.cbRegex.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Option : "
        '
        'tbOption
        '
        Me.tbOption.Location = New System.Drawing.Point(73, 80)
        Me.tbOption.Name = "tbOption"
        Me.tbOption.Size = New System.Drawing.Size(981, 23)
        Me.tbOption.TabIndex = 14
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunFileToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(114, 26)
        '
        'RunFileToolStripMenuItem
        '
        Me.RunFileToolStripMenuItem.Name = "RunFileToolStripMenuItem"
        Me.RunFileToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RunFileToolStripMenuItem.Text = "RunFile"
        '
        'lvIntellisense
        '
        Me.lvIntellisense.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lvIntellisense.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.lvIntellisense.FormattingEnabled = True
        Me.lvIntellisense.Items.AddRange(New Object() {"a"})
        Me.lvIntellisense.Location = New System.Drawing.Point(422, 252)
        Me.lvIntellisense.Name = "lvIntellisense"
        Me.lvIntellisense.ScrollAlwaysVisible = True
        Me.lvIntellisense.Size = New System.Drawing.Size(307, 124)
        Me.lvIntellisense.TabIndex = 15
        Me.lvIntellisense.Visible = False
        '
        'frmDistortion
        '
        Me.AcceptButton = Me.bSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 530)
        Me.Controls.Add(Me.lvIntellisense)
        Me.Controls.Add(Me.tbOption)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbRegex)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtbCode)
        Me.Controls.Add(Me.lvResult)
        Me.Controls.Add(Me.bReference)
        Me.Controls.Add(Me.bSearch)
        Me.Controls.Add(Me.tbSearch)
        Me.Controls.Add(Me.bSave)
        Me.Controls.Add(Me.bOpen)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDistortion"
        Me.Text = "RollRat New Distortion Viewer"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bOpen As System.Windows.Forms.Button
    Friend WithEvents bSave As System.Windows.Forms.Button
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents bSearch As System.Windows.Forms.Button
    Friend WithEvents bReference As System.Windows.Forms.Button
    Friend WithEvents lvResult As System.Windows.Forms.ListBox
    Friend WithEvents rtbCode As System.Windows.Forms.RichTextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbRegex As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbOption As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lvIntellisense As RollRat_New_Distortion.ExListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RunFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
