<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTravel
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTravelNo = New System.Windows.Forms.TextBox()
        Me.ButOk = New System.Windows.Forms.Button()
        Me.ButCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Travel No"
        '
        'txtTravelNo
        '
        Me.txtTravelNo.Location = New System.Drawing.Point(86, 37)
        Me.txtTravelNo.Name = "txtTravelNo"
        Me.txtTravelNo.Size = New System.Drawing.Size(158, 20)
        Me.txtTravelNo.TabIndex = 1
        '
        'ButOk
        '
        Me.ButOk.Location = New System.Drawing.Point(45, 79)
        Me.ButOk.Name = "ButOk"
        Me.ButOk.Size = New System.Drawing.Size(75, 25)
        Me.ButOk.TabIndex = 2
        Me.ButOk.Text = "OK"
        Me.ButOk.UseVisualStyleBackColor = True
        '
        'ButCancel
        '
        Me.ButCancel.Location = New System.Drawing.Point(152, 79)
        Me.ButCancel.Name = "ButCancel"
        Me.ButCancel.Size = New System.Drawing.Size(75, 25)
        Me.ButCancel.TabIndex = 3
        Me.ButCancel.Text = "Cancel"
        Me.ButCancel.UseVisualStyleBackColor = True
        '
        'frmTravel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 122)
        Me.Controls.Add(Me.ButCancel)
        Me.Controls.Add(Me.ButOk)
        Me.Controls.Add(Me.txtTravelNo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTravel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTravel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtTravelNo As TextBox
    Friend WithEvents ButOk As Button
    Friend WithEvents ButCancel As Button
End Class
