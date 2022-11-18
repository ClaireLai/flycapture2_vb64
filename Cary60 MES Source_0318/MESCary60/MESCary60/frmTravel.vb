Public Class frmTravel
    Public Ok As Boolean
    Public DsMES As DataSet
    Public Sub ShowI()
        Ok = False

        Me.ShowDialog()
    End Sub
    Private Sub FrmTravel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTravelNo.Focus()

    End Sub

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Me.Hide()
    End Sub

    Private Sub ButOk_Click(sender As Object, e As EventArgs) Handles ButOk.Click
        Dim xTravel As String
        Dim xVNo As String = vbEmpty
        Dim Sql As String
        Dim mTable As DataTable
        Dim i As Integer
        Dim C As SqlClient.SqlConnection
        Dim mRow As DataRow, row As DataRow
        Dim Da As SqlClient.SqlDataAdapter
        Dim dr As SqlClient.SqlDataReader
        Dim sMsg As String, sMsgA As String
        Dim xStationId As String, xNextStation As String, xStatus As String
        C = GetAdoConn()
        xStationId = "N/A"
        xNextStation = "N/A"
        xStatus = "N/A"
        xTravel = Trim(txtTravelNo.Text)
        DsMES = New DataSet
        Sql = "select * from MES0200 where CORP_NO='" & CORP_NO & "' and TRAVEL_NO='" & xTravel & "'"
        Debug.Print(Sql)
        Da = New SqlClient.SqlDataAdapter(Sql, C)
        Da.Fill(DsMES, "tabMES0200")
        Da.Dispose()
        For Each mRow In DsMES.Tables("tabMES0200").Rows
            i = i + 1
        Next
        mTable = DsMES.Tables("tabMES0200")
        If mTable.Rows.Count = 0 Then
            sMsgA = "This travel no is not exist." : GoTo Erp
        End If
        Sql = "select BECOME_INVALID_YN,CLOSE_YN from IVF1301 where CORP_NO='" & CORP_NO & "' and VOUCHER_NO='" & mTable.Rows(0)("VOUCHER_NO_IVF1301") & "'"
        Da = New SqlClient.SqlDataAdapter(Sql, C)
        Da.Fill(DsMES, "tabIVF1301")
        Da.Dispose()
        mTable = DsMES.Tables("tabIVF1301")
        If mTable.Rows.Count = 0 Then
        Else
            mRow = mTable.Rows(0)
            If Nz(mRow("BECOME_INVALID_YN")) = "Y" Then
                sMsgA = "This travel is canceled." : GoTo Erp
            ElseIf Nz(mRow("CLOSE_YN")) = "Y" Then
                sMsgA = "This travel is closed." : GoTo Erp
            End If
        End If
        mTable.Dispose()

        Sql = "select * from mes0102 where corp_no='" & CORP_NO & "' and OPERATION_ID='" & DsMES.Tables("tabMES0200").Rows(0)("OPERATION_ID") & "'"
        Da = New SqlClient.SqlDataAdapter(Sql, C)
        Da.Fill(DsMES, "tabMES0102")
        Da.Dispose()
        If DsMES.Tables("tabMES0102").Rows.Count <= 0 Then
            sMsgA = "Bad opoeration id" : GoTo Erp
        End If

        Sql = "select *,(select station_attrib from MES0101 where CORP_NO=m.CORP_NO and STATION_ID=m.STATION_ID) as STATION_ATTRIB "
        Sql = Sql & "from MES0201 m where CORP_NO='" & CORP_NO & "' and TRAVEL_NO='" & xTravel & "' order by TRAVEL_SEQ"
        Da = New SqlClient.SqlDataAdapter(Sql, C)
        Da.Fill(DsMES, "tabMES0201")
        Da.Dispose()
        If DsMES.Tables("tabMES0201").Rows.Count <= 0 Then
            xStationId = DsMES.Tables("tabMES0102").Rows(0)("STATION_ID")
            xNextStation = xStationId
        Else
            mRow = DsMES.Tables("tabMES0201").Rows(DsMES.Tables("tabMES0201").Rows.Count - 1)
            xStationId = mRow("STATION_ID")
            Select Case mRow("STATUS")
                Case "M"
                    xStatus = "Wait for Measure"
                    i = 0
                    For Each row In DsMES.Tables("tabMES0102").Rows
                        i = i + 1
                        If mRow("STATION_ID") = row("STATION_ID") Then Exit For
                    Next
                    If i = DsMES.Tables("tabMES0102").Rows.Count Then
                        sMsgA = "Can not locate current station." : GoTo Erp
                    End If
                Case "Q"
                    xStatus = "Wait for QC."
                    xNextStation = mRow("NEXT_STATION")
                    sMsgA = "This station is not in proper order."
                Case "P"
                    xStatus = "Pass"
                    xNextStation = mRow("NEXT_STATION")
                    i = 0
                    For Each row In DsMES.Tables("tabMES0102").Rows
                        i = i + 1
                        If mRow("NEXT_STATION") = row("STATION_ID") Then Exit For
                    Next
                    If i = DsMES.Tables("tabMES0102").Rows.Count Then
                        sMsgA = "Can not locate next station." : GoTo Erp
                    End If
                Case "S"
                    xStatus = "Return"
                    xNextStation = mRow("NEXT_STATION")
                    i = 0
                    For Each row In DsMES.Tables("tabMES0102").Rows
                        i = i + 1
                        If mRow("NEXT_STATION") = row("STATION_ID") Then Exit For
                    Next
                    If i = DsMES.Tables("tabMES0102").Rows.Count Then
                        sMsgA = "Can not locate the next station." : GoTo Erp
                    End If
                Case "!"
                    xStatus = "Hold."
                    xNextStation = "N/A"
                    sMsgA = "This travel was holded by QC."
                    GoTo Erp
                Case "~"
                    xStatus = "Release."
                    xNextStation = mRow("NEXT_STATION")
                    i = 0
                    For Each row In DsMES.Tables("tabMES0102").Rows
                        i = i + 1
                        If mRow("NEXT_STATION") = row("STATION_ID") Then Exit For
                    Next
                    If i = DsMES.Tables("tabMES0102").Rows.Count Then
                        sMsgA = "Can not locate current station." : GoTo Erp
                    End If
                Case Else
                    sMsgA = "Unknow status."
                    GoTo Erp
            End Select
        End If

        If STATION_ID <> xNextStation Then
            sMsgA = "This station " & STATION_ID & " is not in proper order.."
            GoTo Erp
        End If

        Select Case STATION_ID
            Case "PREPARE", "PRE-WASH"
                Sql = "select * from mes0096 where corp_no='" & CORP_NO & "' and voucher_no_ivf1301='" & DsMES.Tables("tabMES0200").Rows(0)("VOCUER_NO_IVF1301") & "'"
                dr = GetDr(Sql, C)
                If dr.HasRows Then
                Else
                    sMsgA = "No Frame Vendor Data. Please input the frame vendor Data."
                    GoTo Erp
                End If
                dr.Close()

            Case "INSPECT"
                Select Case DsMES.Tables("tabMES0200").Rows(0)("CUST_NO")
                    Case "32IK", "DNP", "HOYA", "MATSUSHITA", "NEC", "ROHM", "SANYO", "SIGA", "TOPPAN", "YAMAHA KAGOSHIMA", "31INA"
                        Select Case Mid(xTravel, 1, 4)
                            Case "111-", "188-", "131I", "131D", "188A", "111T"
                                Sql = "select * from mes0210 where corp_no='" & CORP_NO & "' and travel_no='" & DsMES.Tables("tabMES0200").Rows(0)("VOUCHER_NO_IVF1301") & "' and station_id='WASH BOX' "
                                dr = GetDr(Sql, C)
                                If dr.HasRows Then
                                Else
                                    sMsgA = "VOUCHER_NO:" & DsMES.Tables("tabMES0200").Rows(0)("VOUCHER_NO_IVF1301") & "WASH BOX Check inspection no input"
                                    GoTo Erp
                                End If
                        End Select
                End Select
                End Select
        Ok = True
        Me.Hide()
        Exit Sub
Erp:
        sMsg = "Travel NO:" & xTravel & vbCrLf
        sMsg = sMsg & "Current Station: " & xStationId & vbCrLf
        sMsg = sMsg & "Status: " & xStatus & vbCrLf
        sMsg = sMsg & "Next Station: " & xNextStation & vbCrLf
        sMsg = sMsg & "Message: " & sMsgA & vbCrLf
        MsgBox(sMsg, vbOKOnly)

    End Sub

    Private Sub txtTravelNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTravelNo.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            ButOk.Focus()
        End If
    End Sub
End Class