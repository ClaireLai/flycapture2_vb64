Public Class frmSerialType
    Dim NewProd As Boolean
    Dim Second As Boolean
    Public TF(9) As String
    Public TravelNo As String
    Public OldNo As String
    Public USALotNo As String
    Public Ok As Boolean
    Public SerialType As String

    Public Sub ShowI(mNewProd As Boolean, msecond As Boolean)
        Dim i As Integer
        For i = 0 To 9
            TF(i) = ""
        Next
        NewProd = mNewProd
        Second = msecond
        ShowDialog()

    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Ok = False
        Me.Hide()
    End Sub

    Private Sub frmSerialType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not NewProd Then
            rdbSNo.Enabled = True
            rdbSNo.Visible = True
            rdbSNo.Checked = True
            rdbSNo.TabStop = False
        End If

        If Second Then
            txtSerialNo.BackColor = Color.Yellow

        End If
        txtSerialNo.Select()

    End Sub

    Private Sub txtSerialNo_TextChanged(sender As Object, e As EventArgs) Handles txtSerialNo.TextChanged

    End Sub

    Private Sub txtSerialNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerialNo.KeyPress
        If e.KeyChar = vbCr Then
            If txtSerialNo.Text = "" Then Exit Sub
            If txtLotNo.Visible = True Then
                txtLotNo.Select()
            Else
                butOk.PerformClick()
            End If

        End If
    End Sub

    Private Sub butOk_Click(sender As Object, e As EventArgs) Handles butOk.Click
        Dim SerialNo As String
        Dim C As SqlClient.SqlConnection
        Dim Q As String
        Dim mTable As DataTable
        Dim mTableA As DataTable
        Dim mTableB As DataTable

        If Len(UCase(Trim(txtSerialNo.Text))) > 9 Then
            If InStr(UCase(Trim(txtSerialNo.Text)), "$I") > 0 Then
                SerialNo = UCase(Trim(txtSerialNo.Text))
                SerialNo = Mid(SerialNo, InStr(SerialNo, "$I") + 2, 9)
            Else
                SerialNo = UCase(Trim(txtSerialNo.Text))
                SerialNo = Mid(SerialNo, 1, InStr(SerialNo, "-") - 1)
            End If
        Else
            SerialNo = UCase(Trim(txtSerialNo.Text))
        End If

        txtSerialNo.Text = SerialNo
        If Second And NewProd Then
            Q = "select top 1 * from MES0204 where corp_no='" & CORP_NO & "' and serial_no ='" & SerialNo & "' order by modify_time desc"
        Else
            Q = "select top 1 * from mes0204 where corp_no='" & CORP_NO & "' and travel_no like '" & Mid(TravelNo, 1, Len(TravelNo) - 3) & "%' "
            Q = Q & "and (serial_no_old='" & SerialNo & "' or serial_no='" & SerialNo & "') order by modify_time desc"
        End If
        Debug.Print(Q)
        C = GetAdoConn()
        mTable = GetTable(Q, C)

        If mTable.Rows.Count > 0 Then
            C.Dispose()
            mTable.Dispose()
            MsgBox("serial No is exists! Please change another serial no.")
            Exit Sub
        Else
            If Not Second Then
                mTable.Dispose()
                Q = "select top 1 *,(select prod_name from mes0200 where corp_no=m.corp_no and travel_no=m.travel_no) as PROD_NAME,"
                Q = Q & "(select operator_id from mes0201 where corp_no=m.corp_no and travel_no=m.travel_no and station_id='INSPECT') as OP_ID "
                Q = Q & "from MES0204 m where corp_no='" & CORP_NO & "' and SERIAL_NO='" & SerialNo & "' order by modify_time desc"
                mTable = GetTable(Q, C)
                Q = "select * from duvdata where serial_id='" & SerialNo & "'"
                mTableA = GetTable(Q, C)
                Q = "select PROD_NAME from mes0200 where corp_no='" & CORP_NO & "'and TRAVEL_NO='" & TravelNo & "'"
                mTableB = GetTable(Q, C)
                If mTable.Rows.Count <= 0 And mTableA.Rows.Count <= 0 Then
                    If txtLotNo.Visible = True Then
                        MsgBox("查無舊資料!請輸入舊Lot No" & vbCrLf & "無法比對貨品型號，請注意型號是否相同")
                    Else
                        MsgBox("查無舊資料!請輸入舊Lot No" & vbCrLf & "無法比對貨品型號，請注意型號是否相同")
                        Label1.Visible = True
                        txtLotNo.Visible = True
                        txtLotNo.Enabled = True
                        txtLotNo.Select()
                        Exit Sub
                    End If
                Else
                    Label1.Visible = False
                    txtLotNo.Visible = False
                    txtLotNo.Enabled = False
                    If mTable.Rows.Count > 0 Then
                        If ChkProdName(mTableB.Rows(0)("PROD_NAME"), mTable.Rows(0)("PROD_NAME")) Then
                            USALotNo = mTable.Rows(0)("LOT_NO")
                            TF(0) = mTable.Rows(0)("F193").ToString
                            TF(1) = mTable.Rows(0)("F248").ToString
                            TF(2) = mTable.Rows(0)("F365").ToString
                            TF(3) = mTable.Rows(0)("F400").ToString
                            TF(4) = mTable.Rows(0)("F430").ToString
                            TF(5) = mTable.Rows(0)("F436").ToString
                            TF(6) = mTable.Rows(0)("FAVG").ToString
                            TF(7) = mTable.Rows(0)("FILM_THICKNESS").ToString
                            TF(8) = mTable.Rows(0)("OP_ID").ToString
                            TF(9) = mTable.Rows(0)("PEAK").ToString
                        Else
                            MsgBox("貨品型號不符，請重新輸入")
                            txtSerialNo.Text = ""
                            txtSerialNo.Focus()
                            Exit Sub
                        End If
                    ElseIf mTableA.Rows.Count > 0 Then
                        USALotNo = mTableA.Rows(0)("LOT_ID")
                        Select Case Mid(mTableA.Rows(0)("ITEM_NAME"), InStr(mTableA.Rows(0)("ITEM_NAME"), "-") + 1, 3)
                            Case "122", "107", "172"
                                TF(2) = mTableA.Rows(0)("F248nm").ToString
                                TF(5) = mTableA.Rows(0)("F365nm").ToString
                            Case "602", "603"
                                TF(1) = mTableA.Rows(0)("F248nm").ToString
                                TF(2) = mTableA.Rows(0)("F365nm").ToString
                            Case "701", "703"
                                TF(0) = mTableA.Rows(0)("F248nm").ToString
                                TF(1) = mTableA.Rows(0)("F365nm").ToString
                            Case "101", "102", "103", "104", "105", "100"
                                TF(6) = mTableA.Rows(0)("F248nm").ToString
                            Case "110", "111"
                                TF(5) = mTableA.Rows(0)("F248nm").ToString
                            Case "113", "201", "202"
                                TF(2) = mTableA.Rows(0)("F248nm").ToString
                            Case "231"
                                TF(3) = mTableA.Rows(0)("F248nm").ToString
                            Case Else
                                TF(1) = mTableA.Rows(0)("F248nm").ToString
                                TF(2) = mTableA.Rows(0)("F365nm").ToString
                        End Select
                        TF(7) = mTableA.Rows(0)("THICKNESS").ToString
                        TF(8) = "" : TF(9) = ""
                    End If

                End If
                mTable.Dispose()
                mTableA.Dispose()
                mTableB.Dispose()
            End If
            SerialType = "Old"
            OldNo = txtSerialNo.Text
            If txtLotNo.Visible Then
                USALotNo = UCase(Trim(txtLotNo.Text))
            End If
            If OldNo = "" Then
                MsgBox("The old no. should not be empty")
                Exit Sub
            End If
            If USALotNo = "" And txtLotNo.Visible Then
                MsgBox("The Lot No should not be empty")
                Exit Sub
            End If
        End If
        Ok = True
        Me.Hide()
    End Sub
    Private Function ChkProdName(PNow As String, PBefore As String) As Boolean
        Dim subPNow As String = ""
        Dim subPBefore As String = ""

        If InStrRev(PNow, "-") Then
            subPNow = Mid(PNow, 1, InStrRev(PNow, "-"))
            subPNow = subPNow & Strings.Right(PNow, Len(PNow) - InStrRev(PNow, "-") - 4)
        End If
        If InStrRev(PBefore, "-") Then
            subPBefore = Mid(PBefore, 1, InStrRev(PBefore, "-"))
            subPBefore = subPBefore & Strings.Right(PBefore, Len(PBefore) - InStrRev(PBefore, "-") - 4)
        End If

        If subPNow = subPBefore Then ChkProdName = True
        Return ChkProdName
    End Function

    Private Sub txtLotNo_TextChanged(sender As Object, e As EventArgs) Handles txtLotNo.TextChanged

    End Sub

    Private Sub txtLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLotNo.KeyPress
        If e.KeyChar = vbCr Then
            butOk.PerformClick()
        End If
    End Sub
End Class