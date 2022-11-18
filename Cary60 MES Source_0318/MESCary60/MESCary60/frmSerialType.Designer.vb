<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSerialType
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSerialNo = New System.Windows.Forms.TextBox()
        Me.rdbSNo = New System.Windows.Forms.RadioButton()
        Me.butOk = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLotNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSerialNo)
        Me.GroupBox1.Controls.Add(Me.rdbSNo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 154)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "What kind of Serial no do you want?"
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(32, 101)
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(187, 20)
        Me.txtLotNo.TabIndex = 2
        Me.txtLotNo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "No USA Lot# find, Please Input then USA LotNo"
        Me.Label1.Visible = False
        '
        'txtSerialNo
        '
        Me.txtSerialNo.Location = New System.Drawing.Point(32, 42)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.Size = New System.Drawing.Size(187, 20)
        Me.txtSerialNo.TabIndex = 1
        '
        'rdbSNo
        '
        Me.rdbSNo.AutoSize = True
        Me.rdbSNo.Location = New System.Drawing.Point(16, 19)
        Me.rdbSNo.Name = "rdbSNo"
        Me.rdbSNo.Size = New System.Drawing.Size(137, 17)
        Me.rdbSNo.TabIndex = 0
        Me.rdbSNo.TabStop = True
        Me.rdbSNo.Text = "I will scan old SN# here"
        Me.rdbSNo.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(140, 187)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(75, 27)
        Me.butOk.TabIndex = 3
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Location = New System.Drawing.Point(241, 187)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 27)
        Me.butCancel.TabIndex = 2
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'frmSerialType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 226)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSerialType"
        Me.Text = "frmSerialType"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtLotNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSerialNo As TextBox
    Friend WithEvents rdbSNo As RadioButton
    Friend WithEvents butOk As Button
    Friend WithEvents butCancel As Button
End Class
