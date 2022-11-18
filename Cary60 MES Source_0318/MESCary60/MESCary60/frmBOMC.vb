Public Class frmBOMC
    Dim DsBOM As DataSet
    Dim TravelNo As String
    Dim TSeq As Integer
    Public Ok As Boolean
    Dim CheckItem As String()
    Public Sub ShowI(mTravelNo As String, mTseq As Integer)
        Dim Q As String
        Dim C As SqlClient.SqlConnection
        Dim Da As SqlClient.SqlDataAdapter

        TravelNo = mTravelNo
        TSeq = mTseq

        If STATION_ID = "CARTON PAK" Then
            Select Case Mid(TravelNo, 1, 4)
                Case "111-", "188-", "120-", "121-", "125-", "131I", "131D", "188A", "111E", "111T"
                Case Else
                    Ok = True
                    Exit Sub
            End Select
        End If

        CheckItem = GetChkItem()

        If CheckItem.GetLowerBound(0) = -1 Then
            Ok = True
            Exit Sub
        End If
        Select Case STATION_ID
            Case "CARTON PAK"
                Q = "select * from mes0200 m where corp_no='" & CORP_NO & "' and travel_no in (select travel_no from mes0204 where corp_no=m.corp_no and pack_no='" & TravelNo & "')"
            Case Else
                Q = "select * from mes0200 where corp_no='" & CORP_NO & "' and travel_no like '" & TravelNo & "%'"
        End Select
        C = GetAdoConn()
        Da = New SqlClient.SqlDataAdapter(Q, C)
        DsBOM = New DataSet
        Da.Fill(DsBOM, "tab0200")
        Da.Dispose()
        If DsBOM.Tables("tab0200").Rows.Count <= 0 Then
            Ok = False
            MsgBox("TRAVEL_NO:" & TravelNo & "Not in MES System")
            Exit Sub
        End If

        Q = "select * from MLI_ST0200 where corp_no='" & CORP_NO & "' and PROD_NO='" & DsBOM.Tables("tab0200").Rows(0)("PROD_NO") & "'"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Da.Fill(DsBOM, "tabBOM")
        If DsBOM.Tables("tabBOM").Rows.Count <= 0 Then
            Ok = False
            MsgBox("PROD_NO:" & DsBOM.Tables("tab0200").Rows(0)("PROD_NO") & " not in BOM system)")
            Exit Sub
        End If

        If STATION_ID = "SERIAL" Then
            If DsBOM.Tables("tab0200").Rows(0)("VOUCHER_NO_IVF1301") = BOMV Then
                Ok = True
                Exit Sub
            End If
        End If
        C.Close()
        C.Dispose()
        Da.Dispose()
        Me.ShowDialog()
    End Sub
    Private Function GetChkItem() As String()
        Dim CKI As String()
        Select Case Mid(TravelNo, 1, 4)
            Case "121-", "125-", "120-"
                Select Case STATION_ID
                    Case "INSPECT"
                        CKI = {"FRAME_ID", "ADH", "FILTER", "COAT_HOLE", "LC_GLUE", "FRAME_LASER_MARK", "BUCKLE_CODE", "BSC", "BOX_TOP", "BOX_BOTTOM", "BOX_PAD_TOP", "BOX_PAD_BOTTOM",
                         "BOX_MATERIAL_TOP", "BOX_MATERIAL_BOTTOM", "BOX_COAT_TOP", "BOX_COAT_BOTTOM", "BARCODE"}
                    Case "BAG PACK", "SERIAL"
                        CKI = {"FRAME_ID", "FRAME_LASER_MARK", "BUCKLE_CODE", "BSC", "BOX_TOP", "BOX_BOTTOM", "BOX_MATERIAL_TOP", "BOX_MATERIAL_BOTTOM", "BARCODE", "LABEL", "BAG_LABEL", "BAG_MATHOD"}
                    Case "QC CHECK"
                        CKI = {"FRAME_ID", "ADH", "FILTER", "COAT_HOLE", "LC_GLUE", "FRAME_LASER_MARK", "BUCKLE_CODE", "BSC", "BOX_TOP", "BOX_BOTTOM", "BOX_PAD_TOP", "BOX_PAD_BOTTOM",
                                "BOX_MATERIAL_TOP", "BOX_MATERIAL_BOTTOM", "BOX_COAT_TOP", "BOX_COAT_BOTTOM", "BARCODE", "LABEL", "BAG_LABEL", "BAG_MATHOD", "LABEL_LEVEL"}
                    Case "CARTON PAK"
                        CKI = {"BAG_LABEL", "BAG_MATHOD"}
                End Select
            Case "111-", "188-", "131I", "131D", "188A", "111E", "111T"
                Select Case STATION_ID
                    Case "WASH BOX"
                        CKI = {"BOX_TOP", "BOX_BOTTOM", "BOX_PAD_TOP", "BOX_PAD_BOTTOM",
                                 "BOX_MATERIAL_TOP", "BOX_MATERIAL_BOTTOM", "BOX_COAT_TOP", "BOX_COAT_BOTTOM"}
                    Case "FRINSP_2"
                        CKI = {"FRAME_ID", "ADH", "FILTER", "COAT_HOLE", "LC_GLUE", "FRAME_LASER_MARK"}
                    Case "INSPECT"
                        CKI = {"FRAME_ID", "ADH", "FILM_TYPE", "FILTER", "COAT_HOLE", "LC_GLUE", "FRAME_LASER_MARK", "BUCKLE_CODE", "BSC", "TAB", "BOX_TOP", "BOX_BOTTOM", "BOX_PAD_TOP", "BOX_PAD_BOTTOM",
                        "BOX_MATERIAL_TOP", "BOX_MATERIAL_BOTTOM", "BOX_COAT_TOP", "BOX_COAT_BOTTOM"}
                    Case "BAG PACK", "SERIAL", "LABEL"
                        CKI = {"FRAME_ID", "FRAME_LASER_MARK", "BUCKLE_CODE", "BSC", "BOX_TOP", "BOX_BOTTOM", "BOX_MATERIAL_TOP", "BOX_MATERIAL_BOTTOM", "BARCODE", "LABEL", "BAG_LABEL", "BAG_MATHOD"}
                    Case "CARTON PAK"
                        CKI = {"BAG_LABEL", "BAG_MATHOD"}
                    Case "QC CHECK"
                        CKI = {"FRAME_ID", "ADH", "FILTER", "COAT_HOLE", "LC_GLUE", "FRAME_LASER_MARK", "BUCKLE_CODE", "BSC", "BOX_TOP", "BOX_BOTTOM", "BOX_PAD_TOP", "BOX_PAD_BOTTOM",
                        "BOX_MATERIAL_TOP", "BOX_MATERIAL_BOTTOM", "BOX_COAT_TOP", "BOX_COAT_BOTTOM", "BARCODE", "LABEL", "BAG_LABEL", "BAG_MATHOD", "LABEL_LEVEL"}
                    Case "ASSEMBLY"
                        CKI = {"FRAME_ID", "ADH", "FILTER", "COAT_HOLE", "LC_GLUE", "FRAME_LASER_MARK", "BUCKLE_CODE", "BSC", "BOX_TOP", "BOX_BOTTOM", "BOX_PAD_TOP", "BOX_PAD_BOTTOM",
                         "BOX_MATERIAL_TOP", "BOX_MATERIAL_BOTTOM", "BOX_COAT_TOP", "BOX_COAT_BOTTOM", "BARCODE"}
                End Select
            Case Else
                If STATION_ID = "CARTON PAK" Then
                    CKI = {"BAG_LABEL", "BAG_MATHOD"}
                Else
                    ReDim CKI(-1)
                End If
        End Select
        Return CKI
    End Function
    Private Sub frmBOMC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mTable As DataTable
        Dim Q As String
        Dim C As SqlClient.SqlConnection
        'Dim Da As SqlClient.SqlDataAdapter
        lblTravelNo.Text = TravelNo
        lblProdNo.Text = DsBOM.Tables("tab0200").Rows(0)("PROD_NO")
        lblProdName.Text = DsBOM.Tables("tab0200").Rows(0)("PROD_NAME")
        lblCustNo.Text = DsBOM.Tables("tab0200").Rows(0)("CUST_NO")

        If Mid(DsBOM.Tables("tab0200").Rows(0)("CUST_NO"), 1, 2) = "US" Then
            Q = "select * from ivf9921 where corp_no='" & CORP_NO & "' and PROD_NO='" & lblProdNo.Text & "' and BUSINESS_CORP_NO='S0001'"
        Else
            Q = "select * from ivf9921 where corp_no='" & CORP_NO & "' and prod_NO='" & lblProdNo.Text & "' and BUSINESS_CORP_NO='" & lblCustNo.Text & "'"
        End If
        C = GetAdoConn()
        mTable = GetTable(Q, C)
        'Da.Fill(mTable)

        If mTable.Rows.Count > 0 Then
            lblProdNoBusiness.Text = mTable.Rows(0)("BUSINESS_PROD_NO")
        Else
            lblProdNoBusiness.Text = ""
        End If

        lblShift.Text = SHIFT
        lblUserID.Text = USER_ID
        LblStationID.Text = STATION_ID
        ShowCls
        butTravel.Visible = False
        butTravel.Enabled = False
        C.Close()
        C.Dispose()
    End Sub

    Private Sub butDone_Click(sender As Object, e As EventArgs) Handles butDone.Click
        Dim mTable As DataTable
        Dim Ctl As Control
        Dim CtlA As Control

        For Each Ctl In Panel2.Controls
            If TypeOf Ctl Is TextBox Or TypeOf Ctl Is ComboBox Then
                If Ctl.Visible = True And Ctl.Text = "" Then
                    For Each CtlA In Panel2.Controls
                        If TypeOf CtlA Is Label Then
                            If CtlA.Tag = Ctl.Tag Then
                                MsgBox(CtlA.Text & " No Input")
                                Exit Sub
                            End If
                        End If
                    Next
                End If
            End If
        Next

        For Each Ctl In Panel2.Controls
            If (TypeOf Ctl Is TextBox Or TypeOf Ctl Is ComboBox) And Ctl.Tag <> "LABEL_LEVEL" Then
                If Ctl.Visible = True Then
                    For Each CtlA In Panel2.Controls
                        If TypeOf CtlA Is Label And CtlA.Tag = Ctl.Tag Then
                            mTable = DsBOM.Tables("tabBOM")
                            Select Case Ctl.Tag
                                Case "LC_GLUE"
                                    If InStr(mTable.Rows(0)(Ctl.Tag), "LC") > 0 Then
                                        If InStr(UCase(Ctl.Text), "LC") <= 0 Then
                                            MsgBox("LC GLUE Input Error")
                                            Exit Sub
                                        End If
                                    Else
                                        If UCase(Ctl.Text) <> UCase(mTable.Rows(0)(Ctl.Tag)) Then
                                            MsgBox(CtlA.Text & " Value :" & Ctl.Text & " is difference with BOM List")
                                            Exit Sub
                                        End If
                                    End If
                                Case "BOX_TOP", "BOX_BOTTOM"
                                    If InStr(mTable.Rows(0)(Ctl.Tag), Ctl.Text) <= 0 Then
                                        MsgBox(CtlA.Text & " Value :" & Ctl.Text & " is difference with BOM List")
                                        Exit Sub
                                    End If
                                Case "FRAME_LASER_MARK"
                                    If UCase(Replace(Ctl.Text, " ", "")) <> UCase(Replace(mTable.Rows(0)(Ctl.Tag), " ", "")) Then
                                        'Debug.Print(UCase(Replace(Ctl.Text, " ", "")))
                                        'Debug.Print(UCase(Replace(mTable.Rows(0)(Ctl.Tag), " ", "")))
                                        MsgBox(CtlA.Text & " Value :" & Ctl.Text & " is difference with BOM List")
                                        Exit Sub
                                    End If
                                Case Else
                                    If UCase(Ctl.Text) <> UCase(mTable.Rows(0)(Ctl.Tag)) Then
                                        MsgBox(CtlA.Text & " Value :" & Ctl.Text & " is difference with BOM List")
                                        Exit Sub
                                    End If
                            End Select
                        End If
                    Next
                End If
            End If
        Next

        SaveRec()
        BOMV = DsBOM.Tables("tab0200").Rows(0)("VOUCHER_NO_IVF1301")
        BOMP = DsBOM.Tables("tab0200").Rows(0)("PROD_NO")
        Select Case STATION_ID
            Case "QC CHECK", "WASH BOX"
                'refreshfrm
            Case Else
                Ok = True
                Me.Hide()
        End Select
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs) Handles butExit.Click
        Ok = False
        Me.Hide()

    End Sub
    Private Sub ShowCls()
        Dim i As Integer
        Dim j As Integer

        For i = 0 To Panel2.Controls.Count - 1
            If Panel2.Controls(i).Name Like "lblField*" Then
                Panel2.Controls(i).Visible = False
                For j = LBound(CheckItem) To UBound(CheckItem)
                    If Panel2.Controls(i).Tag = CheckItem(j) Then
                        Panel2.Controls(i).Visible = True
                        If Panel2.Controls(i).Tag = "TAB" Then Panel2.Controls(i).Visible = False
                        If j Mod 2 = 1 Then
                            Panel2.Controls(i).Location = New Point(300, 9 + (26 * Int(j / 2)))
                            Panel2.Controls(i).Size = New Size(120, 22)
                        Else
                            Panel2.Controls(i).Location = New Point(12, 9 + (26 * Int(j / 2)))
                            Panel2.Controls(i).Size = New Size(120, 22)
                        End If

                    End If
                Next
            ElseIf TypeOf Panel2.Controls(i) Is TextBox Then
                Panel2.Controls(i).Visible = False
                For j = LBound(CheckItem) To UBound(CheckItem)
                    If Panel2.Controls(i).Tag = CheckItem(j) Then
                        Panel2.Controls(i).Visible = True
                        If Panel2.Controls(i).Tag = "TAB" Then Panel2.Controls(i).Visible = False
                        Panel2.Controls(i).TabIndex = j
                        If j Mod 2 = 1 Then
                            Panel2.Controls(i).Location = New Point(420, 9 + (26 * Int(j / 2)))
                            Panel2.Controls(i).Size = New Size(135, 22)
                        Else
                            Panel2.Controls(i).Location = New Point(132, 9 + (26 * Int(j / 2)))
                            Panel2.Controls(i).Size = New Size(135, 22)

                        End If
                    End If
                Next
            ElseIf TypeOf Panel2.Controls(i) Is ComboBox Then
                Panel2.Controls(i).Visible = False
                For j = LBound(CheckItem) To UBound(CheckItem)
                    If Panel2.Controls(i).Tag = CheckItem(j) Then
                        Panel2.Controls(i).Visible = True
                        Panel2.Controls(i).TabIndex = j
                        If j Mod 2 = 1 Then
                            Panel2.Controls(i).Location = New Point(420, 9 + (26 * Int(j / 2)))
                            Panel2.Controls(i).Size = New Size(135, 22)
                        Else
                            Panel2.Controls(i).Location = New Point(132, 9 + (26 * Int(j / 2)))
                            Panel2.Controls(i).Size = New Size(135, 22)

                        End If
                    End If
                Next
            End If

        Next
        TextBox1.Text = i
    End Sub

    Private Sub frmBOMC_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim ctl As Control
        For Each ctl In Panel2.Controls
            If ctl.TabIndex = 0 Then
                ctl.Focus()
            End If
        Next

        Select Case STATION_ID
            Case "SERIAL", "WASH BOX"
                FillData(DsBOM.Tables("tab0200").Rows(0)("VOUCHER_NO_IVF1301"))
            Case Else
                If lblProdNo.Text = BOMP Then
                    FillDataP(BOMP)
                End If
        End Select

        Me.Text = CORP_NO & "-" & STATION_ID & "BOM Check List"
    End Sub
    Private Sub FillData(mBOMV As String)
        Dim mTable As DataTable
        Dim Q As String
        Dim C As SqlClient.SqlConnection
        Dim Ctl As Control

        Q = "select * from MES0210 where corp_no='" & CORP_NO & "' and travel_no like '" & mBOMV & "%" & "' and station_id='" & STATION_ID & "'"
        C = GetAdoConn()
        mTable = GetTable(1, C)

        If mTable.Rows.Count <= 0 Then Exit Sub

        For Each Ctl In Panel2.Controls
            If TypeOf Ctl Is TextBox Or TypeOf Ctl Is ComboBox Then
                If Ctl.Visible = True Then
                    Ctl.Text = mTable.Rows(0)(Ctl.Tag)
                End If
            End If
        Next
        mTable.Dispose()
        C.Close()
        C.Dispose()

    End Sub
    Private Sub FillDataP(mBOMP As String)
        Dim mTable As DataTable
        Dim Q As String
        Dim C As SqlClient.SqlConnection
        Dim Ctl As Control

        Q = "select * from MES0210 m where corp_no='" & CORP_NO & "' and  station_id='" & STATION_ID & "' "
        Q = Q & " and exists(select * from mes0200 where travel_no=m.travel_no and corp_no=m.corp_no and prod_no='" & mBOMP & "'"
        Q = Q & " order by enter_time desc"
        C = GetAdoConn()
        mTable = GetTable(1, C)

        If mTable.Rows.Count <= 0 Then Exit Sub

        For Each Ctl In Panel2.Controls
            If TypeOf Ctl Is TextBox Or TypeOf Ctl Is ComboBox Then
                If Ctl.Visible = True Then
                    Ctl.Text = mTable.Rows(0)(Ctl.Tag)
                End If
            End If
        Next
        mTable.Dispose()
        C.Close()
        C.Dispose()

    End Sub

    Private Sub frmBOMC_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

    End Sub

    Private Sub frmBOMC_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                If butTravel.Visible And butTravel.Enabled Then
                    butTravel.PerformClick()
                End If
            Case Keys.F5
                If butDone.Visible Then butDone.PerformClick()
            Case Keys.Escape
                If butExit.Visible Then butExit.PerformClick()

        End Select
    End Sub

    Private Sub butTravel_Click(sender As Object, e As EventArgs) Handles butTravel.Click

    End Sub
    Private Sub SaveRec()
        Dim Q As String
        Dim C As SqlClient.SqlConnection
        Dim Da As SqlClient.SqlDataAdapter
        Dim Ds As DataSet
        Dim Ctl As Control
        Dim mTable As DataTable
        Dim mRow As DataRow
        Dim i As Integer
        Dim cmdBuilder As SqlClient.SqlCommandBuilder

        Q = "select * from mes0210 where corp_no='" & CORP_NO & "' and travel_no='" & TravelNo & "' and travel_seq='" & TSeq & "'"
        C = GetAdoConn()
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        Da.Fill(Ds, "DsTable1")
        mTable = Ds.Tables("DsTable1")
        If Ds.Tables("DsTable1").Rows.Count <= 0 Then
            mRow = Ds.Tables("DsTable1").NewRow
            mRow("CORP_NO") = CORP_NO
            mRow("TRAVEL_NO") = TravelNo
            mRow("TRAVEL_SEQ") = TSeq
            mRow("STATION_ID") = STATION_ID
            For Each Ctl In Panel2.Controls
                If TypeOf Ctl Is TextBox Or TypeOf Ctl Is ComboBox Then
                    If Ctl.Visible = True Then
                        mRow(Ctl.Tag) = Ctl.Text
                    End If
                End If
            Next
            mRow("USER_ID") = USER_ID
            mRow("ENTER_TIME") = Now
            Ds.Tables("DsTable1").Rows.Add(mRow)

        Else
            mRow = Ds.Tables("DsTable1").Rows(0)
            mRow("TRAVEL_SEQ") = TSeq
            mRow("STATION_ID") = STATION_ID
            For Each Ctl In Panel2.Controls
                If TypeOf Ctl Is TextBox Or TypeOf Ctl Is ComboBox Then
                    If Ctl.Visible = True Then
                        mRow(Ctl.Tag) = Ctl.Text
                    End If
                End If
            Next
            mRow("USER_ID") = USER_ID
            mRow("ENTER_TIME") = Now
        End If
        Da.Update(Ds, "DsTable1")

        Ds.Dispose()
        Da.Dispose()
        C.Close()
        C.Dispose()
    End Sub

    Private Sub frmBOMC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtFrID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFrID.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbADH_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbADH.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtFilmType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFilmType.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbFilter.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbCoatHole_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCoatHole.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbLCGlue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbLCGlue.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtFrameLaserMark_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFrameLaserMark.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbBuckleCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBuckleCode.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtBSC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBSC.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtBoxTop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBoxTop.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtBoxBottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBoxBottom.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbBoxPadTop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBoxPadTop.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbBoxPadBottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBoxPadBottom.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtPadDescTop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPadDescTop.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtPadDescBottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPadDescBottom.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbBoxMaterialTop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBoxMaterialTop.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbBoxMaterialBottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBoxMaterialBottom.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbBoxCoatTop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBoxCoatTop.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmbBoxCoatBottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBoxCoatBottom.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtLabel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLabel.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtBagLabel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBagLabel.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtBagMathod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBagMathod.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtLabelLevel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLabelLevel.KeyPress
        If e.KeyChar = vbCr Then SendKeys.Send("{TAB}")
    End Sub
End Class