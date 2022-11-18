<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVideo
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVideo))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPassScore = New System.Windows.Forms.TextBox()
        Me.cmd_Load = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.check_ROI = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmd_Learn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Y = New System.Windows.Forms.Label()
        Me.X = New System.Windows.Forms.Label()
        Me.txtY = New System.Windows.Forms.TextBox()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.txtScore = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdDeleteRs = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmdupdateFail = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdInsertRs = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(773, 607)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(791, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(790, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(124, 169)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox1.Controls.Add(Me.button2)
        Me.GroupBox1.Controls.Add(Me.button1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.textBox2)
        Me.GroupBox1.Controls.Add(Me.textBox1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(783, 370)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 112)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DIO"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(110, 65)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(92, 23)
        Me.button2.TabIndex = 36
        Me.button2.Text = "Read From ＤＩ"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(10, 65)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(98, 23)
        Me.button1.TabIndex = 35
        Me.button1.Text = "Write To ＤＯ"
        Me.button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(117, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 12)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "DI:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 12)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "DO:"
        '
        'textBox2
        '
        Me.textBox2.Location = New System.Drawing.Point(119, 37)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(53, 22)
        Me.textBox2.TabIndex = 32
        Me.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(30, 37)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(59, 22)
        Me.textBox1.TabIndex = 31
        Me.textBox1.Text = "1"
        Me.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtPassScore)
        Me.GroupBox2.Controls.Add(Me.cmd_Load)
        Me.GroupBox2.Controls.Add(Me.cmdSave)
        Me.GroupBox2.Controls.Add(Me.check_ROI)
        Me.GroupBox2.Location = New System.Drawing.Point(780, 305)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(211, 59)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(113, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Pass Score"
        '
        'txtPassScore
        '
        Me.txtPassScore.Location = New System.Drawing.Point(165, 0)
        Me.txtPassScore.Name = "txtPassScore"
        Me.txtPassScore.Size = New System.Drawing.Size(46, 22)
        Me.txtPassScore.TabIndex = 16
        '
        'cmd_Load
        '
        Me.cmd_Load.Location = New System.Drawing.Point(115, 28)
        Me.cmd_Load.Name = "cmd_Load"
        Me.cmd_Load.Size = New System.Drawing.Size(76, 25)
        Me.cmd_Load.TabIndex = 15
        Me.cmd_Load.Text = "Load Pattern"
        Me.cmd_Load.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(44, 17)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 36)
        Me.cmdSave.TabIndex = 6
        Me.cmdSave.Text = "Save ROI as Pattern"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'check_ROI
        '
        Me.check_ROI.AutoSize = True
        Me.check_ROI.Location = New System.Drawing.Point(6, 21)
        Me.check_ROI.Name = "check_ROI"
        Me.check_ROI.Size = New System.Drawing.Size(44, 16)
        Me.check_ROI.TabIndex = 5
        Me.check_ROI.Text = "ROI"
        Me.check_ROI.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox3.Controls.Add(Me.cmd_Learn)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Y)
        Me.GroupBox3.Controls.Add(Me.X)
        Me.GroupBox3.Controls.Add(Me.txtY)
        Me.GroupBox3.Controls.Add(Me.txtX)
        Me.GroupBox3.Controls.Add(Me.txtScore)
        Me.GroupBox3.Location = New System.Drawing.Point(783, 488)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 107)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        '
        'cmd_Learn
        '
        Me.cmd_Learn.BackColor = System.Drawing.Color.Ivory
        Me.cmd_Learn.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmd_Learn.Location = New System.Drawing.Point(96, 49)
        Me.cmd_Learn.Name = "cmd_Learn"
        Me.cmd_Learn.Size = New System.Drawing.Size(92, 42)
        Me.cmd_Learn.TabIndex = 29
        Me.cmd_Learn.Text = "Learn & Match"
        Me.cmd_Learn.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(94, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 12)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Score"
        '
        'Y
        '
        Me.Y.AutoSize = True
        Me.Y.Location = New System.Drawing.Point(10, 51)
        Me.Y.Name = "Y"
        Me.Y.Size = New System.Drawing.Size(13, 12)
        Me.Y.TabIndex = 27
        Me.Y.Text = "Y"
        '
        'X
        '
        Me.X.AutoSize = True
        Me.X.Location = New System.Drawing.Point(10, 20)
        Me.X.Name = "X"
        Me.X.Size = New System.Drawing.Size(13, 12)
        Me.X.TabIndex = 26
        Me.X.Text = "X"
        '
        'txtY
        '
        Me.txtY.Location = New System.Drawing.Point(33, 48)
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(55, 22)
        Me.txtY.TabIndex = 25
        '
        'txtX
        '
        Me.txtX.Location = New System.Drawing.Point(32, 21)
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(56, 22)
        Me.txtX.TabIndex = 24
        '
        'txtScore
        '
        Me.txtScore.Location = New System.Drawing.Point(131, 21)
        Me.txtScore.Name = "txtScore"
        Me.txtScore.Size = New System.Drawing.Size(57, 22)
        Me.txtScore.TabIndex = 23
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(919, 238)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(66, 33)
        Me.Button3.TabIndex = 34
        Me.Button3.Text = "Start Capture"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(863, 277)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(108, 22)
        Me.txtType.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(801, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "目前型號"
        '
        'cmdDeleteRs
        '
        Me.cmdDeleteRs.Location = New System.Drawing.Point(790, 199)
        Me.cmdDeleteRs.Name = "cmdDeleteRs"
        Me.cmdDeleteRs.Size = New System.Drawing.Size(62, 25)
        Me.cmdDeleteRs.TabIndex = 37
        Me.cmdDeleteRs.Text = "DeleteRs"
        Me.cmdDeleteRs.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(909, 189)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(77, 22)
        Me.TextBox3.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(858, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "資料筆數"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(673, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(318, 95)
        Me.DataGridView1.TabIndex = 40
        '
        'cmdupdateFail
        '
        Me.cmdupdateFail.Location = New System.Drawing.Point(790, 230)
        Me.cmdupdateFail.Name = "cmdupdateFail"
        Me.cmdupdateFail.Size = New System.Drawing.Size(81, 20)
        Me.cmdupdateFail.TabIndex = 41
        Me.cmdupdateFail.Text = "UpdatePASS"
        Me.cmdupdateFail.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(929, 158)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(41, 22)
        Me.Button4.TabIndex = 42
        Me.Button4.Text = "refersh"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cmdInsertRs
        '
        Me.cmdInsertRs.Location = New System.Drawing.Point(790, 256)
        Me.cmdInsertRs.Name = "cmdInsertRs"
        Me.cmdInsertRs.Size = New System.Drawing.Size(66, 22)
        Me.cmdInsertRs.TabIndex = 43
        Me.cmdInsertRs.Text = "InsertRS"
        Me.cmdInsertRs.UseVisualStyleBackColor = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'frmVideo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(998, 613)
        Me.Controls.Add(Me.cmdInsertRs)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cmdupdateFail)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.cmdDeleteRs)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtType)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVideo"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Private WithEvents button2 As Button
    Private WithEvents button1 As Button
    Private WithEvents Label3 As Label
    Private WithEvents Label4 As Label
    Private WithEvents textBox2 As TextBox
    Private WithEvents textBox1 As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmd_Load As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents check_ROI As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmd_Learn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Y As Label
    Friend WithEvents X As Label
    Friend WithEvents txtY As TextBox
    Friend WithEvents txtX As TextBox
    Friend WithEvents txtScore As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPassScore As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents txtType As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdDeleteRs As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmdupdateFail As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents cmdInsertRs As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
