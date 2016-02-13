<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cbIgnore = New System.Windows.Forms.CheckBox()
        Me.cbRegex = New System.Windows.Forms.CheckBox()
        Me.lAddr = New System.Windows.Forms.Label()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bStart = New System.Windows.Forms.Button()
        Me.tmFoundText = New System.Windows.Forms.Timer(Me.components)
        Me.diaOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.lFind = New System.Windows.Forms.Label()
        Me.diaOpenFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.lvResult = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cbOnlyLines = New System.Windows.Forms.CheckBox()
        Me.bExtension = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbIgnore
        '
        Me.cbIgnore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbIgnore.AutoSize = True
        Me.cbIgnore.Checked = True
        Me.cbIgnore.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbIgnore.Location = New System.Drawing.Point(511, 11)
        Me.cbIgnore.Name = "cbIgnore"
        Me.cbIgnore.Size = New System.Drawing.Size(60, 19)
        Me.cbIgnore.TabIndex = 17
        Me.cbIgnore.Text = "Ignore"
        Me.cbIgnore.UseVisualStyleBackColor = True
        '
        'cbRegex
        '
        Me.cbRegex.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbRegex.AutoSize = True
        Me.cbRegex.Location = New System.Drawing.Point(577, 11)
        Me.cbRegex.Name = "cbRegex"
        Me.cbRegex.Size = New System.Drawing.Size(58, 19)
        Me.cbRegex.TabIndex = 14
        Me.cbRegex.Text = "Regex"
        Me.cbRegex.UseVisualStyleBackColor = True
        '
        'lAddr
        '
        Me.lAddr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lAddr.AutoSize = True
        Me.lAddr.Location = New System.Drawing.Point(12, 264)
        Me.lAddr.Name = "lAddr"
        Me.lAddr.Size = New System.Drawing.Size(0, 15)
        Me.lAddr.TabIndex = 13
        '
        'tbSearch
        '
        Me.tbSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSearch.Location = New System.Drawing.Point(53, 12)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(452, 23)
        Me.tbSearch.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Text :"
        '
        'bStart
        '
        Me.bStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bStart.Location = New System.Drawing.Point(489, 239)
        Me.bStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bStart.Name = "bStart"
        Me.bStart.Size = New System.Drawing.Size(146, 27)
        Me.bStart.TabIndex = 9
        Me.bStart.Text = "&Start"
        Me.bStart.UseVisualStyleBackColor = True
        '
        'tmFoundText
        '
        Me.tmFoundText.Interval = 30
        '
        'diaOpenFile
        '
        Me.diaOpenFile.Filter = "DB 파일|*.db;*.fsm;*.sdb"
        '
        'lFind
        '
        Me.lFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lFind.AutoSize = True
        Me.lFind.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lFind.Location = New System.Drawing.Point(12, 277)
        Me.lFind.Name = "lFind"
        Me.lFind.Size = New System.Drawing.Size(0, 15)
        Me.lFind.TabIndex = 20
        '
        'lvResult
        '
        Me.lvResult.AllowDrop = True
        Me.lvResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvResult.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.lvResult.FullRowSelect = True
        Me.lvResult.GridLines = True
        Me.lvResult.Location = New System.Drawing.Point(14, 42)
        Me.lvResult.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvResult.Name = "lvResult"
        Me.lvResult.Size = New System.Drawing.Size(621, 189)
        Me.lvResult.TabIndex = 21
        Me.lvResult.UseCompatibleStateImageBehavior = False
        Me.lvResult.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Index"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Address"
        Me.ColumnHeader2.Width = 468
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Count"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 66
        '
        'cbOnlyLines
        '
        Me.cbOnlyLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbOnlyLines.AutoSize = True
        Me.cbOnlyLines.Location = New System.Drawing.Point(14, 238)
        Me.cbOnlyLines.Name = "cbOnlyLines"
        Me.cbOnlyLines.Size = New System.Drawing.Size(82, 19)
        Me.cbOnlyLines.TabIndex = 25
        Me.cbOnlyLines.Text = "Only Lines"
        Me.cbOnlyLines.UseVisualStyleBackColor = True
        '
        'bExtension
        '
        Me.bExtension.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bExtension.Location = New System.Drawing.Point(337, 239)
        Me.bExtension.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bExtension.Name = "bExtension"
        Me.bExtension.Size = New System.Drawing.Size(146, 27)
        Me.bExtension.TabIndex = 26
        Me.bExtension.Text = "&Extension"
        Me.bExtension.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 276)
        Me.Controls.Add(Me.bExtension)
        Me.Controls.Add(Me.cbOnlyLines)
        Me.Controls.Add(Me.lvResult)
        Me.Controls.Add(Me.lFind)
        Me.Controls.Add(Me.cbIgnore)
        Me.Controls.Add(Me.cbRegex)
        Me.Controls.Add(Me.lAddr)
        Me.Controls.Add(Me.tbSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bStart)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(663, 315)
        Me.Name = "frmMain"
        Me.Text = "RollRat Grep 2 "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbIgnore As System.Windows.Forms.CheckBox
    Friend WithEvents cbRegex As System.Windows.Forms.CheckBox
    Friend WithEvents lAddr As System.Windows.Forms.Label
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bStart As System.Windows.Forms.Button
    Friend WithEvents tmFoundText As System.Windows.Forms.Timer
    Friend WithEvents diaOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lFind As System.Windows.Forms.Label
    Friend WithEvents diaOpenFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lvResult As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbOnlyLines As System.Windows.Forms.CheckBox
    Friend WithEvents bExtension As System.Windows.Forms.Button

End Class
