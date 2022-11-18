Imports System.Windows.Forms
Public Class frmGeneral
    Dim GridRs As DataSet
    Dim RejTable As DataTable
    Dim DsMES As DataSet
    Dim MatrTable As DataTable
    Private Sub frmGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim comboboxColumn As DataGridViewComboBoxColumn
        Dim textColumn As DataGridViewTextBoxColumn
        Dim Sql As String
        Dim DrID As Integer
        Dim objDr As SqlClient.SqlDataReader
        Dim mTable As DataTable
        Dim C As SqlClient.SqlConnection
        Text = CORP_NO & "MES Work Flow"
        C = GetAdoConn()
        Sql = "select * from MES0106 where CORP_NO='" & CORP_NO & "' and STATION_ID='" & STATION_ID & "' order by MAC_SEQ"
        objDr = GetDr(Sql, C)
        cboMacNo.Items.Clear()

        DrID = objDr.GetOrdinal("MAC_NO")
        If objDr.HasRows Then
            Do While objDr.Read
                cboMacNo.Items.Add(objDr(DrID).ToString())
            Loop
        End If
        objDr.Close()
        objDr = Nothing


        RejTable = New DataTable("RejTable")
        With RejTable
            .Columns.Add("VENDOR_ID_FRAME", Type.GetType("System.String"))
            .Columns.Add("VENDOR_ID_POLE", Type.GetType("System.String"))
            .Columns.Add("REJECT_CODE", Type.GetType("System.String"))
            .Columns.Add("REJECT_QTY", Type.GetType("System.Int16"))
            .Columns.Add("FROM_HP8452", Type.GetType("System.Boolean"))
            .Columns.Add("REJ_SERIAL_NO", Type.GetType("System.String"))
            .Columns.Add("PARTICLE_YN", Type.GetType("System.String"))
            .Columns.Add("WASH_FILM", Type.GetType("System.String"))
        End With

        With dgvReject
            .AutoGenerateColumns = False
            .AllowUserToAddRows = True
            .RowTemplate.Height = 20
            comboboxColumn = New DataGridViewComboBoxColumn
            With comboboxColumn
                .HeaderText = "Frame Vendor"
                .DataPropertyName = "VENDOR_ID_FRAME"
                .DropDownWidth = 100
                .Width = 60
                .MaxDropDownItems = 6
                .FlatStyle = FlatStyle.Flat
                Sql = "select *,VENDOR_NO + '-' + VENDOR_NAME as V_FRAME "
                Sql = Sql & "from MES0109 where CORP_NO='" & CORP_NO & "' and isnull(FRAME_VENDOR,'')='Y' order by VENDOR_NO"
                mTable = GetTable(Sql, C)
                .DataSource = mTable
                .DisplayMember = "V_FRAME"
                .ValueMember = "VENDOR_NO"

                '.Items.AddRange("AA", "BB", "CC")

            End With
            .Columns.Add(comboboxColumn)
            comboboxColumn = New DataGridViewComboBoxColumn
            With comboboxColumn
                .HeaderText = "Pole Vendor"
                .DataPropertyName = "VENDOR_ID_POLE"
                .DropDownWidth = 100
                .Width = 60
                .MaxDropDownItems = 6
                .FlatStyle = FlatStyle.Flat
                Sql = "select *,VENDOR_NO + '-' + VENDOR_NAME as V_FRAME "
                Sql = Sql & "from MES0109 where CORP_NO='" & CORP_NO & "' and isnull(POLE_VENDOR,'')='Y' order by VENDOR_NO"
                mTable = GetTable(Sql, C)
                .DataSource = mTable
                .DisplayMember = "V_FRAME"
                .ValueMember = "VENDOR_NO"

            End With
            .Columns.Add(comboboxColumn)
            comboboxColumn = New DataGridViewComboBoxColumn
            With comboboxColumn
                .HeaderText = "Reject Code"
                .DataPropertyName = "REJECT_CODE"
                .DropDownWidth = 200
                .Width = 200
                .MaxDropDownItems = 6
                .FlatStyle = FlatStyle.Flat
                Sql = "SELECT *,(REJECT_CODE + '-' + REJECT_DESC) as REJ_D "
                Sql = Sql & "from MES0104 where CORP_NO='" & CORP_NO & "' order by REJECT_CODE "
                mTable = GetTable(Sql, C)
                .DataSource = mTable
                .DisplayMember = "REJ_D"
                .ValueMember = "REJECT_CODE"
                '.Items.AddRange("01", "02", "03")
            End With
            .Columns.Add(comboboxColumn)
            textColumn = New DataGridViewTextBoxColumn
            With textColumn
                .HeaderText = "Rej. Qty"
                .DataPropertyName = "REJECT_QTY"
                .Width = 30
            End With
            .Columns.Add(textColumn)
            textColumn = New DataGridViewTextBoxColumn
            With textColumn
                .HeaderText = "Particle YN"
                .DataPropertyName = "PARTICLE_YN"
                .Width = 30
            End With
            .Columns.Add(textColumn)
        End With
        dgvReject.DataSource = RejTable

        MatrTable = New DataTable("MatrTable")
        With MatrTable
            .Columns.Add("MATR_NO", Type.GetType("System.String"))
            .Columns.Add("MATR_DATE", Type.GetType("System.String"))
            .Columns.Add("INHERIT", Type.GetType("System.String"))

        End With
        With dgvMatr
            .AutoGenerateColumns = False
            .AllowUserToAddRows = True
            .RowTemplate.Height = 20
            comboboxColumn = New DataGridViewComboBoxColumn
            With comboboxColumn
                .HeaderText = "Matr. No."
                .DataPropertyName = "MATR_NO"
                .DropDownWidth = 80
                .Width = 120
                .MaxDropDownItems = 3
                .FlatStyle = FlatStyle.Flat
                Sql = "SELECT *,(MATR_NO + '-' + MATR_NAME) as MATR_D "
                Sql = Sql & "from MES0105 where CORP_NO='" & CORP_NO & "' and isnull(close_yn,'')<>'Y' order by MATR_NO "
                Debug.Print(Sql)
                mTable = GetTable(Sql, C)
                .DataSource = mTable
                .DisplayMember = "MATR_D"
                .ValueMember = "MATR_NO"
                '.Items.AddRange("01", "02", "03")
            End With
            .Columns.Add(comboboxColumn)
            textColumn = New DataGridViewTextBoxColumn
            With textColumn
                .HeaderText = "Matr. Date"
                .DataPropertyName = "MATR_DATE"
                .Width = 100
            End With
            .Columns.Add(textColumn)
            textColumn = New DataGridViewTextBoxColumn
            With textColumn
                .HeaderText = "Inherit"
                .DataPropertyName = "INHERIT"
                .Width = 30
            End With
            .Columns.Add(textColumn)
        End With
        dgvMatr.DataSource = MatrTable
        C.Close()
        C.Dispose()
        ButDone.Enabled = False
        butSerial.Enabled = False
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs) Handles butExit.Click
        If Not IsNothing(FrmCa) Then
            ''Else
            FrmCa.Close()
            FrmCa.Dispose()
            FrmCa = Nothing
        End If
        Dispose()
    End Sub

    Private Sub ButDone_Click(sender As Object, e As EventArgs) Handles ButDone.Click
        Dim mRow As DataRow
        Dim C As SqlClient.SqlConnection
        Dim Da As SqlClient.SqlDataAdapter
        Dim Ds As DataSet
        Dim Q As String
        Dim i As Integer
        Dim cmdBuilder As SqlClient.SqlCommandBuilder

        dgvReject.EndEdit()
        For Each mRow In RejTable.Rows
            If Nz(mRow("VENDOR_ID_FRAME")) = "" Then
                MsgBox("The Vendor Should not be empty")
                Exit Sub
            End If
            If Nz(mRow("REJECT_CODE")) = "" Then
                MsgBox("The Rejcet Code should not be empty")
                Exit Sub
            End If
            If Nz(mRow("REJECT_QTY")) = 0 Then
                MsgBox("The Reject Qty should not be Zeor")
                Exit Sub
            End If
            Debug.Print(mRow("VENDOR_ID_FRAME") & mRow("VENDOR_ID_POLE") & mRow("REJECT_CODE"))
        Next

        'Select Case DsMES.Tables("tabMES0200").Rows(0).Item("CUST_NO")
        'BOMChek
        'End Select

        C = GetAdoConn()
        Q = "select * from MES0201 where corp_no='" & CORP_NO & "' and TRAVEL_NO='" & lblTravelNo.Text & "' and TRAVEL_SEQ='" & lblTravelSeq.Text & "'"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet()
        Da.Fill(Ds, "0201")
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        For Each mRow In Ds.Tables("0201").Rows
            mRow.Delete()
        Next
        mRow = Ds.Tables("0201").NewRow
        mRow("CORP_NO") = CORP_NO
        mRow("TRAVEL_NO") = lblTravelNo.Text
        mRow("TRAVEL_SEQ") = lblTravelSeq.Text
        mRow("STATION_ID") = STATION_ID
        mRow("MAC_NO") = cboMacNo.Text
        If rdbFrameNew.Checked Then mRow("FRAME_TYPE") = "N"
        mRow("IN_QTY") = lblInQty.Text
        mRow("OUT_QTY") = lblPassQty.Text
        mRow("OPERATOR_ID") = lblOperatorID.Text
        mRow("OP_START_TIME") = lblStartTime.Text
        mRow("OP_END_TIME") = Now
        lblEndTime.Text = Now
        mRow("SHIFT") = SHIFT
        mRow("NEXT_STATION") = lblNextStation.Text
        'mRow("GLUE_PSI") = txtGluePsi.Text

        For Each Row In DsMES.Tables("tabMES0102").Rows
            If Row("STATION_ID") = STATION_ID Then
                Select Case Row("QC_YN")
                    Case "1", "3"
                        mRow("STATUS") = "M"
                    Case "2"
                        mRow("STATUS") = "Q"
                    Case Else
                        mRow("STATUS") = "P"
                End Select
            End If
        Next
        Ds.Tables("0201").Rows.Add(mRow)
        Da.Update(Ds, "0201")
        Da.Dispose()
        cmdBuilder.Dispose()

        Q = "select * from MES0202 where CORP_NO='" & CORP_NO & "' and TRAVEL_NO='" & lblTravelNo.Text & "' and TRAVEL_SEQ='" & lblTravelSeq.Text & "'"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Da.Fill(Ds, "0202")
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        For Each mRow In Ds.Tables("0202").Rows
            mRow.Delete()
        Next
        i = 0
        For Each row In RejTable.Rows
            i = i + 1
            mRow = Ds.Tables("0202").NewRow
            mRow("CORP_NO") = CORP_NO
            mRow("TRAVEL_NO") = lblTravelNo.Text
            mRow("TRAVEL_SEQ") = lblTravelSeq.Text
            mRow("REJECT_SEQ") = i
            mRow("REJECT_CODE") = row("REJECT_CODE")
            mRow("REJECT_QTY") = row("REJECT_QTY")
            mRow("VENDOR_ID") = row("VENDOR_ID_FRAME")
            mRow("VENDOR_ID2") = row("VENDOR_ID_POLE")
            mRow("REJ_SERIAL_NO") = row("REJ_SERIAL_NO")
            mRow("PARTICLE_YN") = row("PARTICLE_YN")
            mRow("WASH_FILM") = row("WASH_FILM")
            Ds.Tables("0202").Rows.Add(mRow)
        Next
        Da.Update(Ds, "0202")
        Da.Dispose()
        cmdBuilder.Dispose()
        dgvMatr.EndEdit()
        Q = "select * from MES0203 where corp_no='" & CORP_NO & "' and TRAVEL_NO='" & lblTravelNo.Text & "' and TRAVEL_SEQ='" & lblTravelSeq.Text & "'"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Da.Fill(Ds, "0203")
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        For Each mRow In Ds.Tables("0203").Rows
            mRow.Delete()
        Next
        i = 0
        For Each Row In MatrTable.Rows
            If Nz(Row("INHERIT")) <> "Y" Then
                i = i + 1
                mRow = Ds.Tables("0203").NewRow
                mRow("CORP_NO") = CORP_NO
                mRow("TRAVEL_NO") = lblTravelNo.Text
                mRow("TRAVEL_SEQ") = lblTravelSeq.Text
                mRow("MATR_SEQ") = i
                mRow("MATR_NO") = Row("MATR_NO")
                mRow("MATR_DATE") = Row("MATR_DATE")
                Ds.Tables("0203").Rows.Add(mRow)
            End If
        Next
        Da.Update(Ds, "0203")
        Da.Dispose()
        cmdBuilder.Dispose()
        Ds.Dispose()
        C.Close()
        C.Dispose()

        ButDone.Enabled = False
        butTravel.Enabled = True
        butTravel.PerformClick()
    End Sub
    Private Sub Reset()
        Dim cls As Control
        For Each cls In Me.Controls
            If TypeOf cls Is Label Then
                If cls.Name Like "lbl*" Then
                    cls.Text = ""
                End If
            ElseIf TypeOf cls Is TextBox Then
                Select Case cls.Name
                    Case "txtGluePsi"
                    Case Else
                        cls.Text = ""
                End Select
            ElseIf TypeOf cls Is ComboBox Then
                Select Case cls.Name
                    Case "cboMacNo"
                    Case Else
                        cls.Text = ""
                End Select

            End If
        Next
        dgvMatr.DataSource = Nothing
        MatrTable.Clear()
        dgvMatr.DataSource = MatrTable
        dgvMatr.Refresh()
        dgvReject.DataSource = Nothing
        RejTable.Clear()
        dgvReject.DataSource = RejTable
        dgvReject.Refresh()
        lblStationID.Text = STATION_ID
        lblShift.Text = SHIFT
        lblUserID.Text = USER_ID

        ButDone.Enabled = False
        butSerial.Enabled = False
        butTravel.Enabled = True

        txtGluePsi.BackColor = Me.BackColor
        txtGluePsi.Enabled = False
    End Sub

    Private Sub frmGeneral_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.F1 Then
        '    If butTravel.Enabled = True Then
        '        butTravel_Click(Me, e)
        '    End If

        'End If
        Select Case e.KeyCode
            Case Keys.F1
                If butTravel.Enabled Then butTravel.PerformClick()
            Case Keys.F5
                If ButDone.Enabled Then ButDone.PerformClick()
            Case Keys.F8
                If butSerial.Enabled Then butSerial.PerformClick()
            Case Keys.F9
                If butWaitOp.Enabled Then butWaitOp.PerformClick()
            Case Keys.Escape
                If butExit.Enabled Then butExit.PerformClick()
            Case Else
                Exit Select
        End Select

    End Sub

    Private Sub butTravel_Click(sender As Object, e As EventArgs) Handles butTravel.Click
        Dim frmTravel As frmTravel
        Dim comboboxColumn As DataGridViewComboBoxColumn
        Dim mRow As DataRow
        Dim rRow As DataRow
        Dim rRowS As DataRow()
        Dim C As SqlClient.SqlConnection
        Dim Q As String
        Dim mTable As DataTable
        Dim DataCount As Integer
        Dim dgvRow As DataGridViewRow
        frmTravel = New frmTravel
        With frmTravel
            .ShowI()
            If .Ok Then
                DsMES = .DsMES
            Else
                butTravel.Enabled = True
                Exit Sub
            End If
            .Dispose()
        End With
        mRow = DsMES.Tables("tabMES0200").Rows(0)
        lblTravelNo.Text = mRow("TRAVEL_NO")
        If DsMES.Tables("tabMES0201").Rows.Count > 0 Then
            DataCount = DsMES.Tables("tabMES0201").Rows.Count - 1
            lblTravelSeq.Text = DsMES.Tables("tabMES0201").Rows(DataCount)("TRAVEL_SEQ") + 1
            lblInQty.Text = DsMES.Tables("tabMES0201").Rows(DataCount)("OUT_QTY")
            GroupBox3.Enabled = False
            If DsMES.Tables("tabMES0201").Rows(DataCount)("FRAME_TYPE") = "N" Then
                rdbFrameNew.Checked = True
                rdbFrameReuse.Checked = False
            Else
                rdbFrameNew.Checked = False
                rdbFrameReuse.Checked = True
            End If
        Else
            lblTravelSeq.Text = 1
            lblInQty.Text = mRow("IN_QTY")
            GroupBox3.Enabled = True
        End If
        lblRejQty.Text = "0"
        lblPassQty.Text = lblInQty.Text
        'lblTravelSeq.Text = mRow("TRAVEL_SEQ")
        lblCustNo.Text = mRow("CUST_NO") & "-" & mRow("CUST_NAME")
        lblProdNo.Text = mRow("PROD_NO")
        lblProdName.Text = mRow("PROD_NAME")
        lblCustSpec.Text = mRow("CUST_SPEC")
        lblStartDate.Text = mRow("START_DATE")
        lblDueDate.Text = mRow("DUE_DATE")
        lblOperationID.Text = mRow("OPERATION_ID")
        lblStartTime.Text = Now
        lblStationID.Text = STATION_ID
        lblUserID.Text = USER_ID
        lblShift.Text = SHIFT
        lblOperatorID.Text = USER_ID

        If cboMacNo.Text = "" Then
            'DataCount = cboMacNo.Items.Count - 1
            If cboMacNo.Items.Count > 0 Then
                cboMacNo.Text = cboMacNo.Items(0).ToString
            End If
        End If
        'dgvReject.DataSource = Nothing

        comboboxColumn = DirectCast(dgvReject.Columns(0), DataGridViewComboBoxColumn)

        C = GetAdoConn()
        Q = "select *,VENDOR_ID + (select VENDOR_NAME from MES0109 where corp_no=m.corp_no and VENDOR_NO=m.VENDOR_ID) as V_FRAME "
        Q = Q & "from MES0096 m where CORP_NO='" & CORP_NO & "' and DATA_TYPE='FRAME' and voucher_no_ivf1301='" & DsMES.Tables("tabMES0200").Rows(0)("VOUCHER_NO_IVF1301") & "'"
        mTable = GetTable(Q, C)

        If mTable.Rows.Count > 0 Then
            With comboboxColumn
                .DataSource = Nothing
                .Items.Clear()
                .DataSource = mTable
                .DisplayMember = "V_FRAME"
                .ValueMember = "VENDOR_ID"
            End With
        End If
        comboboxColumn = DirectCast(dgvReject.Columns(1), DataGridViewComboBoxColumn)

        Q = "select *,VENDOR_ID + (select VENDOR_NAME from MES0109 where corp_no=m.corp_no and VENDOR_NO=m.VENDOR_ID) as V_FRAME "
        Q = Q & "from MES0096 m where CORP_NO='" & CORP_NO & "' and DATA_TYPE='POLE' and voucher_no_ivf1301='" & DsMES.Tables("tabMES0200").Rows(0)("VOUCHER_NO_IVF1301") & "'"
        mTable = GetTable(Q, C)

        If mTable.Rows.Count > 0 Then
            With comboboxColumn
                .DataSource = Nothing
                .Items.Clear()
                .DataSource = mTable
                .DisplayMember = "V_FRAME"
                .ValueMember = "VENDOR_ID"
            End With
        End If
        ' dgvReject.DataSource = RejTable
        dgvReject.Refresh()

        Q = "select * from MES0202 where corp_no='" & CORP_NO & "' and travel_no='" & lblTravelNo.Text & "' and travel_seq='" & lblTravelSeq.Text & "'"
        mTable = GetTable(Q, C)
        RejTable.Clear()

        For Each rRow In mTable.Rows
            mRow = RejTable.NewRow
            mRow("VENDOR_ID_FRAME") = rRow("VENDOR_ID")
            mRow("VENDOR_ID_POLE") = rRow("VENDOR_ID2")
            mRow("REJECT_CODE") = rRow("REJECT_CODE")
            mRow("REJECT_QTY") = rRow("REJECT_QTY")
            mRow("REJ_SERIAL_NO") = rRow("REJ_SERIAL_NO")
            mRow("PARTICLE_YN") = rRow("PARTICLE_YN")
            mRow("WASH_FILM") = rRow("WASH_FILM")
            RejTable.Rows.Add(mRow)
        Next
        dgvReject.Refresh()
        mTable.Dispose()

        dgvMatr.EndEdit()
        mTable = MatrTable.Copy()

        Q = "select * from MES0203 m where CORP_NO='" & CORP_NO & "' and TRAVEL_NO='" & lblTravelNo.Text & "' and "
        Q = Q & "TRAVEL_SEQ=(select max(TRAVEL_SEQ) from MES0203 where CORP_NO=m.CORP_NO and TRAVEL_NO=m.TRAVEL_NO) order by MATR_SEQ"
        Dim nTable As New DataTable
        nTable = (GetTable(Q, C))

        MatrTable.Clear()
        Debug.Print(MatrTable.Rows.Count)
        For Each rRow In nTable.Rows
            mRow = MatrTable.NewRow
            mRow("MATR_NO") = rRow("MATR_NO")
            mRow("MATR_DATE") = rRow("MATR_DATE")
            mRow("INHERIT") = "Y"
            MatrTable.Rows.Add(mRow)
        Next
        Debug.Print(mTable.Rows.Count)
        'rRowS = mTable.Select("INHERIT<>'Y'")
        For Each rRow In mTable.Rows
            If Nz(rRow("INHERIT")) <> "Y" Then
                mRow = MatrTable.NewRow
                mRow("MATR_NO") = rRow("MATR_NO")
                mRow("MATR_DATE") = rRow("MATR_DATE")
                mRow("INHERIT") = ""
                MatrTable.Rows.Add(mRow)
            End If
        Next
        mTable.Dispose()
        'Try
        dgvMatr.Refresh()
        'Catch eA As System.

        If RejTable.Rows.Count > 0 Then
            lblRejQty.Text = RejTable.Rows.Count
            lblPassQty.Text = Val(lblInQty.Text) - Val(lblRejQty.Text)
        End If
        butSerial.Enabled = True
        ButDone.Enabled = False
        'dgvReject.Enabled = False
        For Each dgvRow In dgvMatr.Rows
            If dgvRow.Cells(2).Value = "Y" Then
                dgvRow.ReadOnly = True
                dgvRow.DefaultCellStyle.BackColor = Color.LightYellow
            End If
        Next
        DataCount = 0
        For Each mRow In DsMES.Tables("tabMES0102").Rows
            DataCount = DataCount + 1
            If mRow("STATION_ID") = STATION_ID Then
                Exit For
            End If
        Next
        If DataCount >= DsMES.Tables("tabMES0102").Rows.Count Then
            lblNextStation.Text = ""
        Else
            lblNextStation.Text = DsMES.Tables("tabMES0102").Rows(DataCount)("STATION_ID")
        End If
        butSerial.Enabled = True
    End Sub

    Private Sub butWaitOp_Click(sender As Object, e As EventArgs) Handles butWaitOp.Click
        frmWaitList.ShowI("General", STATION_ID)
    End Sub

    Private Sub butSerial_Click(sender As Object, e As EventArgs) Handles butSerial.Click

        Select Case DsMES.Tables("tabMES0200").Rows(0)("CUST_NO")
            Case "32IK", "DNP", "HOYA", "MATSUSHITA", "NEC", "ROHM", "SANYO", "SIGA", "TOPPAN", "YAMAHA KAGOSHIMA", "31INA", "US-DNP", "US-INB"
                If STATION_ID = "INSPECT" Then
                    Dim frmBOMC As frmBOMC = New frmBOMC
                    With frmBOMC
                        .ShowI(lblTravelNo.Text, lblTravelSeq.Text)
                        If Not .Ok Then
                            MsgBox("Travel未過站,需完成BOM點檢方可產生過站紀錄")
                            Exit Sub
                        End If
                        .Dispose()
                    End With
                End If
        End Select

        Dim frmCary60 As New frmCary60
        With frmCary60
            .DsMes = DsMES
            .mRejTable = RejTable.Copy
            .ShowI()
            '.Show()

            dgvReject.DataSource = Nothing
            RejTable = .mRejTable

            Dim RejQty As Integer = RejTable.Rows.Count
            lblPassQty.Text = lblInQty.Text - RejQty
            lblRejQty.Text = RejQty
            dgvReject.DataSource = RejTable
            dgvReject.Refresh()
            If .Ok Then
                ButDone.Enabled = True
                ButDone.PerformClick()
            End If
        End With
        ' ButDone.PerformClick()
    End Sub

    Private Sub dgvReject_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReject.CellEndEdit
        Dim mRejQ As Integer = 0
        Dim mTable As DataTable

        mTable = RejTable.Copy
        If mTable.Rows.Count > 0 Then
            For Each Row In mTable.Rows
                If IsDBNull(Row("REJECT_QTY")) Then
                Else
                    mRejQ = mRejQ + Row("REJECT_QTY")
                End If
            Next
        End If

        lblPassQty.Text = Val(lblInQty.Text) - mRejQ

    End Sub

    Private Sub dgvReject_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReject.CellValueChanged
        Dim mTable As DataTable
        Dim cobomboxColumn As DataGridViewComboBoxColumn

        Select Case e.ColumnIndex
            Case 0
                cobomboxColumn = DirectCast(dgvReject.Columns(0), DataGridViewComboBoxColumn)
                mTable = DirectCast(cobomboxColumn.DataSource, DataTable).Copy
                mTable.Select("VENDOR_ID='" & ToString(dgvReject.CurrentCell.Value) & "'")
                If mTable.Rows.Count > 0 Then
                Else
                    dgvReject.CancelEdit()
                End If
            Case 1
                cobomboxColumn = DirectCast(dgvReject.Columns(1), DataGridViewComboBoxColumn)
                mTable = DirectCast(cobomboxColumn.DataSource, DataTable).Copy
                mTable.Select("VENDOR_ID='" & ToString(dgvReject.CurrentCell.Value) & "'")
                If mTable.Rows.Count > 0 Then
                Else
                    dgvReject.CancelEdit()
                End If
            Case 2
                cobomboxColumn = DirectCast(dgvReject.Columns(2), DataGridViewComboBoxColumn)
                mTable = DirectCast(cobomboxColumn.DataSource, DataTable).Copy
                mTable.Select("VENDOR_ID='" & ToString(dgvReject.CurrentCell.Value) & "'")
                If mTable.Rows.Count > 0 Then
                Else
                    dgvReject.CancelEdit()
                End If
            Case 3
                Dim mValue As Integer
                mValue = Integer.Parse(dgvReject.Rows.Item(e.RowIndex).Cells(e.ColumnIndex).Value.ToString())
                If mValue < 1 And mValue > Val(lblPassQty.Text) Then
                    dgvReject.CancelEdit()

                End If
        End Select
    End Sub

    Private Sub dgvMatr_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvMatr.MouseDown
        If e.Button = MouseButtons.Right Then
            ContextMenuStrip1.Tag = "Matr"
            ContextMenuStrip1.Show(dgvMatr, e.X, e.Y)
        End If
    End Sub

    Private Sub dgvReject_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvReject.MouseDown

        If e.Button = MouseButtons.Right Then
            ContextMenuStrip1.Tag = "Rej"
            ContextMenuStrip1.Show(dgvReject, e.X, e.Y)
        End If
    End Sub

    Private Sub DPopMenu_Click(sender As Object, e As EventArgs) Handles DPopMenu.Click
        If ContextMenuStrip1.Tag = "Rej" Then
            dgvReject.EndEdit()
            If dgvReject.CurrentCell.RowIndex > 0 And Not dgvReject.CurrentCell.RowIndex > dgvReject.Rows.Count - 1 Then
                dgvReject.Rows.RemoveAt(dgvReject.CurrentCell.RowIndex)
                dgvReject.EndEdit()

            End If
        ElseIf ContextMenuStrip1.Tag = "Matr" Then
            dgvMatr.EndEdit()
            If dgvMatr.CurrentCell.RowIndex > 0 And Not dgvMatr.CurrentCell.RowIndex > dgvMatr.Rows.Count - 1 _
                 And Nz(dgvMatr.Rows(dgvMatr.CurrentCell.RowIndex).Cells(2).Value) <> "Y" Then
                dgvMatr.Rows.RemoveAt(dgvMatr.CurrentCell.RowIndex)
                dgvMatr.EndEdit()
            End If
            'If dgvMatr.SelectedRows.Count > 0 And Not dgvMatr.SelectedRows(0).Index > dgvMatr.Rows.Count - 1 _
            '    And Nz(dgvMatr.SelectedRows(0).Cells(2).Value) <> "Y" Then
            '    dgvMatr.Rows.RemoveAt(dgvMatr.SelectedRows(0).Index)
            '    dgvMatr.EndEdit()
            'End If

        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub dgvMatr_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMatr.CellContentClick

    End Sub

    Private Sub dgvMatr_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvMatr.DataError
        MessageBox.Show("Error happened " _
        & e.Context.ToString())

    End Sub

    Private Sub frmGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(FrmCa) Then
            ''Else
            FrmCa.Close()
            FrmCa.Dispose()
            FrmCa = Nothing
        End If
    End Sub
End Class