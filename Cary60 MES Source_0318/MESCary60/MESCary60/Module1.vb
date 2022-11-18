Imports System.Data.SqlClient
Module Module1
    Public CORP_NO As String
    Public USER_ID As String
    Public STATION_ID As String
    Public SHIFT As String
    Public BOMV As String
    Public BOMP As String
    Public Const SR_PREFIX = "T"
    Public Const BAG_PREFIX = "BG"
    Public Const PK_PREFIX = "PKT"
    Public FrmCa As FrmCaryC
    Public CaryBusy As Boolean
    Public Sub Main()
        Dim frmLogin As New frmLogin
        Dim frmStation As New frmStation
        Dim frmGeneral As New frmGeneral

        frmLogin.ShowI()
        With frmLogin
            If .Ok Then
                CORP_NO = .CorpNo
                USER_ID = .UserID
            Else
                .Dispose()
                Exit Sub
            End If
            .Close()
            .Dispose()
        End With
        frmLogin = Nothing

        frmStation.ShowI()
        With frmStation
            If .Ok Then
                STATION_ID = .StationID
                SHIFT = .mShift
            Else
                .Dispose()
                Exit Sub
            End If
            .Dispose()
        End With
        Debug.Print(CORP_NO & "," & USER_ID & "," & STATION_ID & "," & SHIFT)
        frmGeneral.ShowDialog()

        'Debug.Print(CORP_NO & "," & USER_ID & "," & STATION_ID & "," & SHIFT)
    End Sub
    Public Function GetAdoConn() As SqlClient.SqlConnection
        Dim Cn As SqlClient.SqlConnection

        Cn = New SqlClient.SqlConnection
        Cn.ConnectionString = "user id=sqlpub;password=sqlpub;initial catalog=PS;data source=MLIDB"
        Cn.Open()
        Return Cn
    End Function

    Public Function GetDs(Sql As String, C As SqlConnection) As DataSet
        Dim Ds As DataSet
        'Dim C As SqlConnection
        Dim objDataAdapter As SqlDataAdapter

        'C = GetAdoConn()
        objDataAdapter = New SqlDataAdapter(Sql, C)
        Ds = New DataSet
        objDataAdapter.Fill(Ds, "DsTab1")
        objDataAdapter.Dispose()
        'C.Close()
        'C.Dispose()
        Return Ds

    End Function
    Public Function GetDr(sql As String, C As SqlConnection) As SqlClient.SqlDataReader
        Dim Dr As SqlDataReader
        'Dim C As SqlConnection
        Dim objCmd As SqlCommand

        ' C = GetAdoConn()
        objCmd = New SqlCommand(sql, C)
        Dr = objCmd.ExecuteReader()

        Return Dr
        ' C.Close()
        'objCmd.Dispose()
        'C.Dispose()

    End Function
    Public Function GetTable(Sql As String, C As SqlConnection) As DataTable
        Dim mTable As DataTable
        'Dim C As SqlConnection
        Dim objDataAdapter As SqlDataAdapter

        'C = GetAdoConn()
        objDataAdapter = New SqlDataAdapter(Sql, C)
        mTable = New DataTable
        objDataAdapter.Fill(mTable)
        objDataAdapter.Dispose()
        'C.Close()
        'C.Dispose()
        Return mTable

    End Function
    Public Function Nz(OriVal As Object) As Object
        Dim TVal As Object = ""
        If IsDBNull(OriVal) Then

        Else
            TVal = OriVal
        End If
        Return TVal
    End Function

    Public Function AMax(vData() As Single) As Single
        Dim i As Integer
        Dim T As Single

        If UBound(vData) >= 0 Then T = vData(0)
        For i = 1 To UBound(vData)
            If vData(i) <> 0 Then
                If vData(i) >= T Then T = vData(i)
            End If
        Next
        Return T
    End Function
    Public Function AMin(vData() As Single) As Single
        Dim i As Integer
        Dim T As Single

        If UBound(vData) >= 0 Then T = vData(0)
        For i = 1 To UBound(vData)
            If vData(i) <> 0 Then
                If vData(i) <= T Then T = vData(i)
            End If
        Next
        Return T
    End Function
    Public Sub DelayTime(Sec As Single)
        Dim Stime As Date
        Dim Etime As Date

        Stime = Now
        Etime = DateAdd(DateInterval.Second, Sec, Stime)
        Do While Stime < Etime
            Application.DoEvents()
            Stime = Now
        Loop
    End Sub
End Module
