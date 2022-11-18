<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRejcetCode
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
        Me.DgvReject = New System.Windows.Forms.DataGridView()
        Me.ButOk = New System.Windows.Forms.Button()
        Me.ButCancel = New System.Windows.Forms.Button()
        CType(Me.DgvReject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvReject
        '
        Me.DgvReject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvReject.Location = New System.Drawing.Point(12, 12)
        Me.DgvReject.Name = "DgvReject"
        Me.DgvReject.Size = New System.Drawing.Size(425, 99)
        Me.DgvReject.TabIndex = 0
        '
        'ButOk
        '
        Me.ButOk.Location = New System.Drawing.Point(252, 117)
        Me.ButOk.Name = "ButOk"
        Me.ButOk.Size = New System.Drawing.Size(97, 27)
        Me.ButOk.TabIndex = 1
        Me.ButOk.Text = "OK"
        Me.ButOk.UseVisualStyleBackColor = True
        '
        'ButCancel
        '
        Me.ButCancel.Location = New System.Drawing.Point(358, 117)
        Me.ButCancel.Name = "ButCancel"
        Me.ButCancel.Size = New System.Drawing.Size(78, 26)
        Me.ButCancel.TabIndex = 2
        Me.ButCancel.Text = "Cancel"
        Me.ButCancel.UseVisualStyleBackColor = True
        '
        'FrmRejcetCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 153)
        Me.Controls.Add(Me.ButCancel)
        Me.Controls.Add(Me.ButOk)
        Me.Controls.Add(Me.DgvReject)
        Me.Name = "FrmRejcetCode"
        Me.Text = "FrmRejcetCode"
        CType(Me.DgvReject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvReject As DataGridView
    Friend WithEvents ButOk As Button
    Friend WithEvents ButCancel As Button
End Class
