Public Class frmLogin
    Public CorpNo As String
    Public UserID As String
    Public Ok As Boolean


    Public Sub ShowI()
        'Dim C As SqlClient.SqlConnection
        'Dim Q As String
        Ok = False
        'C = GetAdoConn()
        'Q = "select * from MES0108 order by CORP_NO"
        'DrMES0108 = GetDr(Q, C)
        Me.ShowDialog()

    End Sub
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim C As SqlClient.SqlConnection
        Dim Q As String
        Dim DrID As Integer
        Dim DrMES0108 As SqlClient.SqlDataReader

        Me.Text = "USER Login"
        Ok = False
        C = GetAdoConn()
        Q = "select * from MES0108 order by CORP_NO"
        DrMES0108 = GetDr(Q, C)
        cboCorp.Items.Clear()

        DrID = DrMES0108.GetOrdinal("CORP_NO")
        If DrMES0108.HasRows Then
            Do While DrMES0108.Read
                cboCorp.Items.Add(DrMES0108(DrID).ToString())
            Loop
        End If
        DrMES0108.Close()
        DrMES0108 = Nothing
        C.Close()
        C = Nothing

        cboCorp.Text = GetSetting("MES", "Login", "CORP_NO")
        txtUserID.Text = GetSetting("MES", "Login", "USER_ID")
    End Sub

    Private Sub ButOk_Click(sender As Object, e As EventArgs) Handles ButOk.Click
        ChkUseID()
    End Sub
    Private Sub ChkUseID()
        Dim Q As String
        Dim objDr As SqlClient.SqlDataReader
        Dim C As SqlClient.SqlConnection

        If cboCorp.Text = "" Then
            MsgBox("No CORP_NO INPUT", MsgBoxStyle.OkOnly) : Exit Sub
        End If
        If txtUserID.Text = "" Then
            MsgBox("No User_ID INPUT", MsgBoxStyle.OkOnly) : Exit Sub
        End If

        If txtPassword.Text = "" Then
            MsgBox("NO PASSWORD INPUT", MsgBoxStyle.OkOnly) : Exit Sub
        End If
        C = GetAdoConn()

        Q = "select * from MES0103 where CORP_NO='" & cboCorp.Text & "' and user_id='" & txtUserID.Text & "' "

        objDr = GetDr(Q, C)
        If objDr.HasRows Then
            Do While objDr.Read()
                If objDr.Item("PASSWORD") <> txtPassword.Text Then
                    MsgBox("密碼輸入錯誤", MsgBoxStyle.OkOnly) : Exit Sub
                Else
                    UserID = UCase(txtUserID.Text)
                    CorpNo = UCase(cboCorp.Text)
                    Ok = True
                    SaveSetting("MES", "Login", "CORP_NO", CorpNo)
                    SaveSetting("MES", "Login", "USER_ID", UserID)
                    'frmProgView.ShowI(UserID)
                End If
            Loop
        Else
            MsgBox("登入名稱錯誤", MsgBoxStyle.OkOnly) : Exit Sub
        End If

        objDr.Close()

        C.Close()
        C.Dispose()
        Me.Hide()
    End Sub

    Private Sub cboCorp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCorp.SelectedIndexChanged

    End Sub

    Private Sub cboCorp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCorp.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtUserID.Focus()
        End If
    End Sub

    Private Sub txtUserID_TextChanged(sender As Object, e As EventArgs) Handles txtUserID.TextChanged

    End Sub

    Private Sub txtUserID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserID.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ButOk.Focus()
        End If
    End Sub

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Me.Hide()
    End Sub
End Class
