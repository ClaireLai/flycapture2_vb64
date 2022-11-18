Public Class frmWaitList
    Dim mNextStation As String
    Public Sub ShowI(StationType As String, NextStation As String)
        If NextStation <> "" Then
            mNextStation = NextStation
            ShowDialog()
        End If
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs) Handles butExit.Click
        Me.Dispose()
    End Sub

    Private Sub frmWaitList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Q As String
        Dim C As SqlClient.SqlConnection
        Dim mTable As DataTable
        Dim textColumn As DataGridViewTextBoxColumn

        Q = "select TRAVEL_NO,TRAVEL_SEQ,STATION_ID,STATUS,OP_END_TIME from MES0201 M where CORP_NO='" & CORP_NO & "' "
        Q = Q & "and STATUS in ('P','S','!','~') "
        Q = Q & "and TRAVEL_SEQ=(select max(TRAVEL_SEQ) from MES0201 where CORP_NO=M.CORP_NO and TRAVEL_NO=M.TRAVEL_NO) "
        Q = Q & "and NEXT_STATION='" & mNextStation & "' and isnull(OUT_QTY,0)<>0 "
        Q = Q & "and exists(select * from IVF1301 where corp_no=m.corp_no and isnull(close_yn,'')<>'Y' and isnull(become_invalid_yn,'')<>'Y' "
        Q = Q & "and voucher_no in (select voucher_no_ivf1301 from mes0200 where corp_no=m.corp_no and travel_no=m.travel_no)) "
        Q = Q & " order by TRAVEL_NO,TRAVEL_SEQ"
        Debug.Print(Q)
        C = GetAdoConn()
        mTable = GetTable(Q, C)
        Debug.Print(mTable.Rows.Count)

        With DataGridView1
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .RowTemplate.Height = 20
            textColumn = New DataGridViewTextBoxColumn
            With textColumn
                .HeaderText = "Travel No"
                .DataPropertyName = "TRAVEL_NO"
                .Width = 120
            End With
            .Columns.Add(textColumn)
            textColumn = New DataGridViewTextBoxColumn
            With textColumn
                .HeaderText = "Last Station"
                .DataPropertyName = "STATION_ID"
                .Width = 60
            End With
            .Columns.Add(textColumn)
            textColumn = New DataGridViewTextBoxColumn
            With textColumn
                .HeaderText = "Status"
                .DataPropertyName = "STATUS"
                .Width = 50
            End With
            .Columns.Add(textColumn)
            textColumn = New DataGridViewTextBoxColumn
            With textColumn
                .HeaderText = "OP End Time"
                .DataPropertyName = "OP_END_TIME"
                .Width = 100
                .DefaultCellStyle.Format = "MM/dd HH:MM"
            End With
            .Columns.Add(textColumn)
        End With
        DataGridView1.DataSource = mTable
        C.Close()
        C.Dispose()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.ColumnIndex = 2 Then
            Select Case e.Value
                Case "M" : e.Value = "M-Wait for Measure"
                Case "Q" : e.Value = "Q-Wait for QC"
                Case "P" : e.Value = "P-Pass"
                Case "S" : e.Value = "S-Skip"
                Case "!" : e.Value = "!-Hold"
                Case "~" : e.Value = "~-Release"
            End Select
        End If
    End Sub
End Class