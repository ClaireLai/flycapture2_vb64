Public Class FrmParticle

    Public ParticleYN As String
    Public WashFilm As String
    Public Sub ShowI()
        Me.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub CheckBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox1.KeyDown
        If e.KeyCode = Keys.PageDown Then
            CheckBox1.Checked = True
        ElseIf e.KeyCode = Keys.PageUp Then
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CheckBox1.KeyPress
        If e.KeyChar = vbCr Then
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub ButOk_Click(sender As Object, e As EventArgs) Handles ButOk.Click
        If TxtParticle.Text = "" Then
            MsgBox("請判斷Particle顆數")
            Exit Sub
        End If
        ParticleYN = TxtParticle.Text
        If CheckBox1.Checked Then
            WashFilm = "Y"
        Else
            WashFilm = "N"
        End If
        Me.Hide()
    End Sub

    Private Sub FrmParticle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtParticle.Text = 0
    End Sub

    Private Sub TxtParticle_GotFocus(sender As Object, e As EventArgs) Handles TxtParticle.GotFocus
        TxtParticle.SelectionStart = 0
        TxtParticle.SelectionLength = 100
    End Sub

    Private Sub TxtParticle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtParticle.KeyPress

        If e.KeyChar = vbCr Then
            SendKeys.Send("{TAB}")

        ElseIf (e.KeyChar < "0" Or e.KeyChar > "9") And (e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub

End Class