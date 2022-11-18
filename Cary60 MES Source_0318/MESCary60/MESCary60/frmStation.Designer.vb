<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStation
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
        Me.cboStationID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboShift = New System.Windows.Forms.ComboBox()
        Me.ButCancel = New System.Windows.Forms.Button()
        Me.ButOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboStationID
        '
        Me.cboStationID.FormattingEnabled = True
        Me.cboStationID.Location = New System.Drawing.Point(84, 25)
        Me.cboStationID.Name = "cboStationID"
        Me.cboStationID.Size = New System.Drawing.Size(173, 21)
        Me.cboStationID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Station_id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Shift"
        '
        'cboShift
        '
        Me.cboShift.FormattingEnabled = True
        Me.cboShift.Location = New System.Drawing.Point(84, 67)
        Me.cboShift.Name = "cboShift"
        Me.cboShift.Size = New System.Drawing.Size(173, 21)
        Me.cboShift.TabIndex = 3
        '
        'ButCancel
        '
        Me.ButCancel.Location = New System.Drawing.Point(180, 111)
        Me.ButCancel.Name = "ButCancel"
        Me.ButCancel.Size = New System.Drawing.Size(75, 25)
        Me.ButCancel.TabIndex = 9
        Me.ButCancel.Text = "Cancel"
        Me.ButCancel.UseVisualStyleBackColor = True
        '
        'ButOk
        '
        Me.ButOk.Location = New System.Drawing.Point(36, 111)
        Me.ButOk.Name = "ButOk"
        Me.ButOk.Size = New System.Drawing.Size(75, 25)
        Me.ButOk.TabIndex = 8
        Me.ButOk.Text = "OK"
        Me.ButOk.UseVisualStyleBackColor = True
        '
        'frmStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 148)
        Me.Controls.Add(Me.ButCancel)
        Me.Controls.Add(Me.ButOk)
        Me.Controls.Add(Me.cboShift)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboStationID)
        Me.Name = "frmStation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboStationID As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboShift As ComboBox
    Friend WithEvents ButCancel As Button
    Friend WithEvents ButOk As Button
End Class
