Public Class FrmRejcetCode
    Dim rejTable As DataTable
    Dim Ok As Boolean = False
    Public Vendor As String
    Public Vendor2 As String
    Public RejCode As String
    Dim mVNo As String
    Public Function ShowI(VNo As String) As Boolean
        mVNo = VNo
        ShowDialog()
        Return Ok
    End Function

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Ok = False
        Me.Hide()
    End Sub

    Private Sub FrmRejcetCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim comboboxColumn As DataGridViewComboBoxColumn
        'Dim textColumn As DataGridViewTextBoxColumn
        Dim C As SqlClient.SqlConnection
        Dim mtable As DataTable
        Dim Sql As String

        C = GetAdoConn()
        rejTable = New DataTable("RejTable")
        With rejTable
            .Columns.Add("VENDOR_ID_FRAME", Type.GetType("System.String"))
            .Columns.Add("VENDOR_ID_POLE", Type.GetType("System.String"))
            .Columns.Add("REJECT_CODE", Type.GetType("System.String"))
        End With

        With DgvReject
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
                Sql = "select *,VENDOR_ID + (select VENDOR_NAME from MES0109 where corp_no=m.corp_no and VENDOR_NO=m.VENDOR_ID) as V_FRAME "
                Sql = Sql & "from MES0096 m where CORP_NO='" & CORP_NO & "' and DATA_TYPE='FRAME' and voucher_no_ivf1301='" & mVNo & "'"
                mtable = GetTable(Sql, C)
                If mtable.Rows.Count <= 0 Then
                    mtable.Dispose()
                    Sql = "select *,VENDOR_NO + '-' + VENDOR_NAME as V_FRAME "
                    Sql = Sql & "from MES0109 where CORP_NO='" & CORP_NO & "' and isnull(FRAME_VENDOR,'')='Y' order by VENDOR_NO"
                    mtable = GetTable(Sql, C)
                    .DataSource = mtable
                    .DisplayMember = "V_FRAME"
                    .ValueMember = "VENDOR_NO"
                Else
                    .DataSource = mtable
                    .DisplayMember = "V_FRAME"
                    .ValueMember = "VENDOR_ID"
                End If
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
                Sql = "select *,VENDOR_ID + (select VENDOR_NAME from MES0109 where corp_no=m.corp_no and VENDOR_NO=m.VENDOR_ID) as V_FRAME "
                Sql = Sql & "from MES0096 m where CORP_NO='" & CORP_NO & "' and DATA_TYPE='POLE' and voucher_no_ivf1301='" & mVNo & "'"
                mtable = GetTable(Sql, C)
                If mtable.Rows.Count <= 0 Then
                    mtable.Dispose()
                    Sql = "select *,VENDOR_NO + '-' + VENDOR_NAME as V_FRAME "
                    Sql = Sql & "from MES0109 where CORP_NO='" & CORP_NO & "' and isnull(POLE_VENDOR,'')='Y' order by VENDOR_NO"
                    mtable = GetTable(Sql, C)
                    .DataSource = mtable
                    .DisplayMember = "V_FRAME"
                    .ValueMember = "VENDOR_NO"
                Else
                    .DataSource = mtable
                    .DisplayMember = "V_FRAME"
                    .ValueMember = "VENDOR_ID"
                End If
            End With
            Try
                .Columns.Add(comboboxColumn)
            Catch eA As system.ArgumentException
                MsgBox(eA.Message)
            End Try
            '.Columns.Add(comboboxColumn)
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

        End With
        DgvReject.DataSource = rejTable
    End Sub

    Private Sub ButOk_Click(sender As Object, e As EventArgs) Handles ButOk.Click
        DgvReject.EndEdit()

        If rejTable.Rows.Count > 0 Then
            For Each mRow In rejTable.Rows
                Vendor = mRow("VENDOR_ID_FRAME")
                Vendor2 = mRow("VENDOR_ID_POLE")
                RejCode = mRow("REJECT_CODE")

            Next
        End If
        If Trim(Vendor) = "" Then
            MsgBox("Frame Vendor should not be empty")
            Exit Sub
        End If
        If Trim(Vendor2) = "" Then
            MsgBox("Pole Vendor should not be empty")
            Exit Sub
        End If
        If Trim(RejCode) = "" Then
            MsgBox("Reject Code should not be empty")
            Exit Sub
        End If
        Ok = True
        Me.Hide()
    End Sub
End Class