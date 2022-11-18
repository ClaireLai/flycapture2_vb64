Public Class frmStation
    Public Ok As Boolean
    Public StationID As String
    Public mShift As String
    Public Sub ShowI()
        Ok = False
        Me.ShowDialog()

    End Sub
    Private Sub frmStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim C As SqlClient.SqlConnection
        Dim Q As String
        Dim DrID As Integer
        Dim objDr As SqlClient.SqlDataReader

        Me.Text = "USER Login System"
        Ok = False
        C = GetAdoConn()
        Q = "select distinct A.* from MES0101 A right join MES0103 B on A.CORP_NO=B.CORP_NO where A.CORP_NO='" & CORP_NO & "'"
        Q = Q & " and B.USER_ID='" & USER_ID & "' and patindex('%'+A.STATION_ID+'%',B.STATION_ID)>0 and A.STATION_ATTRIB='3' order by A.STATION_ID "
        objDr = GetDr(Q, C)
        cboStationID.Items.Clear()
        DrID = objDr.GetOrdinal("STATION_ID")
        If objDr.HasRows Then
            Do While objDr.Read
                cboStationID.Items.Add(objDr(DrID).ToString())
            Loop
        End If
        objDr.Close()
        objDr = Nothing

        Q = "select * from MES0110 where CORP_NO='" & CORP_NO & "' order by SHIFT_CODE"
        objDr = GetDr(Q, C)
        cboShift.Items.Clear()

        DrID = objDr.GetOrdinal("SHIFT_CODE")
        If objDr.HasRows Then
            Do While objDr.Read
                cboShift.Items.Add(objDr(DrID).ToString())
            Loop
        End If
        objDr.Close()
        objDr = Nothing

        C.Close()
        C = Nothing

        cboStationID.Text = GetSetting("MES", "Login", "STATION_ID")
        cboShift.Text = GetSetting("MES", "Login", "SHIFT")

    End Sub

    Private Sub ButOk_Click(sender As Object, e As EventArgs) Handles ButOk.Click
        If cboStationID.Text = "" Then
            MsgBox("No STATION_ID Input", vbOKOnly) : Exit Sub
        End If
        If cboShift.Text = "" Then
            MsgBox("No Shift Input", vbOKOnly) : Exit Sub
        End If
        Ok = True
        StationID = cboStationID.Text
        mShift = cboShift.Text
        Me.Hide()
    End Sub

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Me.Hide()
    End Sub
End Class