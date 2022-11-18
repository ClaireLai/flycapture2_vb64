Imports System
Imports System.Diagnostics
Imports System.Threading
Imports Microsoft.VisualBasic.Interaction

Public Class frmCary60

    Dim RefC As Boolean
    Dim OnData(0 To 500, 0 To 4) As Single
    'Dim rData(320, 1) As Single
    Dim aData(320, 1) As Single
    'Dim LoadEvent As Boolean
    Dim CaLoad As Boolean = False
    Dim mCaTime As Integer
    Public DsMes As DataSet
    Public mRejTable As DataTable
    Public Ok As Boolean
    Dim FILM_TYPE As String
    Dim Thickness As Single
    Dim Hi_AVG As Single
    Dim Low_AVG As Single
    Dim tScale As Single
    Dim F440(2) As Single
    Dim F441(2) As Single
    Dim F405(2) As Single
    Dim rdbMR As RadioButton()
    Dim txtF193 As TextBox()
    Dim txtF248 As TextBox()
    Dim txtF365 As TextBox()
    Dim txtF400 As TextBox()
    Dim txtF430 As TextBox()
    Dim txtF436 As TextBox()
    Dim txtFAVG As TextBox()
    Dim txtThickness As TextBox()
    Dim txtPeak As TextBox()
    Dim bolConnectCary60 As Boolean

    Public Sub ShowI()
        Ok = False
        ShowDialog()
    End Sub

    Private Sub Cary60_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim C As SqlClient.SqlConnection
        Dim Q As String
        Dim mTable As DataTable
        Dim mTableA As DataTable
        Dim mRow As DataRow
        'Dim Ctl As Control
        Dim DataCount As Integer
        bolConnectCary60 = False
        Timer1.Enabled = False
        CaLoad = True
        If bolConnectCary60 = True Then
            If IsNothing(FrmCa) Then
                FrmCa = New FrmCaryC
                FrmCa.Show()
            End If
        End If
        rdbMR = New RadioButton() {Me.rdbMR_1, Me.rdbMR_2, Me.rdbMR_3}
        txtF193 = New TextBox() {Me.txtF193_1, Me.txtF193_2, Me.txtF193_3}
        txtF248 = New TextBox() {Me.txtF248_1, Me.txtF248_2, Me.txtF248_3}
        txtF365 = New TextBox() {Me.txtF365_1, Me.txtF365_2, Me.txtF365_3}
        txtF400 = New TextBox() {Me.txtF400_1, Me.txtF400_2, Me.txtF400_3}
        txtF430 = New TextBox() {Me.txtF430_1, Me.txtF430_2, Me.txtF430_3}
        txtF436 = New TextBox() {Me.txtF436_1, Me.txtF436_2, Me.txtF436_3}
        txtFAVG = New TextBox() {Me.txtFAVG_1, Me.txtFAVG_2, Me.txtFAVG_3}
        txtThickness = New TextBox() {Me.txtThickness_1, Me.txtThickness_2, Me.txtThickness_3}
        txtPeak = New TextBox() {Me.txtPeak_1, Me.txtPeak_2, Me.txtPeak_3}

        SetPic()
        'LoadEvent = True

        ButMeasure.Enabled = False
        ButReference.Enabled = False
        C = GetAdoConn()


        Q = "select FIELD_CHA_2,PROD_KIND_9 from uuf0013 where corp_no='" & CORP_NO & "' and PROD_NO='" & DsMes.Tables("tabMES0200").Rows(0).Item("PROD_NO") & "'"
        mTable = GetTable(Q, C)
        If mTable.Rows.Count > 0 Then
            FILM_TYPE = mTable.Rows(0)("FIELD_CHA_2")
            txtRemark.Text = Nz(mTable.Rows(0)("PROD_KIND_9"))
        End If
        mTable.Dispose()
        Me.Text = "Cary60 @ Part#:" & DsMes.Tables("tabMES0200").Rows(0).Item("PROD_NO") & "; Film type:" & FILM_TYPE
        Select Case FILM_TYPE
            Case "100"
                Hi_AVG = 450 : Low_AVG = 350
            Case "101", "102", "105"
                Hi_AVG = 440 : Low_AVG = 360
            Case "104"
                Hi_AVG = 400 : Low_AVG = 350
            Case Else
                Hi_AVG = 450 : Low_AVG = 350
        End Select

        If DsMes.Tables("tabMES0200").Rows(0).Item("CUST_NO") = "13TSMC" Then

        Else
            For j = 1 To 2
                rdbMR(j).Enabled = False
            Next
        End If
        Q = "select CENTER,FLOOR from MES0111 join uuf0013 on MES0111.CORP_NO=UUF0013.CORP_NO and MES0111.FILM_TYPE=UUF0013.FIELD_CHA_2 WHERE MES0111.CORP_NO='" & CORP_NO & "' and UUF0013.PROD_NO='" & DsMes.Tables("tabMES0200").Rows(0).Item("PROD_NO") & "'"

        mTable = GetTable(Q, C)
        If mTable.Rows.Count > 0 Then
            For i = 0 To 2
                txtF193(i).Enabled = False : txtF193(i).BackColor = Me.BackColor
                txtF248(i).Enabled = False : txtF248(i).BackColor = Me.BackColor
                txtF365(i).Enabled = False : txtF365(i).BackColor = Me.BackColor
                txtF400(i).Enabled = False : txtF400(i).BackColor = Me.BackColor
                txtF436(i).Enabled = False : txtF436(i).BackColor = Me.BackColor
                txtF430(i).Enabled = False : txtF430(i).BackColor = Me.BackColor
                txtFAVG(i).Enabled = False : txtFAVG(i).BackColor = Me.BackColor
                txtThickness(i).Enabled = False : txtThickness(i).BackColor = Me.BackColor
                txtPeak(i).Enabled = False : txtPeak(i).BackColor = Me.BackColor

                If rdbMR(i).Enabled = True Then
                    txtThickness(i).Enabled = True : txtThickness(i).BackColor = Color.White
                    If FILM_TYPE = "122" Then
                        txtPeak(i).Enabled = True
                        txtPeak(i).BackColor = Color.White
                    End If
                    Dim Center As String() = Split(mTable.Rows(0)("CENTER"), ",")
                    For j = LBound(Center) To UBound(Center)
                        Select Case Center(j)
                            Case "193" : txtF193(i).Enabled = True : txtF193(i).BackColor = Color.White
                            Case "248" : txtF248(i).Enabled = True : txtF248(i).BackColor = Color.White
                            Case "365" : txtF365(i).Enabled = True : txtF365(i).BackColor = Color.White
                            Case "400" : txtF400(i).Enabled = True : txtF400(i).BackColor = Color.White
                            Case "430" : txtF430(i).Enabled = True : txtF430(i).BackColor = Color.White
                            Case "436" : txtF436(i).Enabled = True : txtF436(i).BackColor = Color.White
                            Case "AVG" : txtFAVG(i).Enabled = True : txtFAVG(i).BackColor = Color.White
                        End Select
                    Next
                End If
            Next
            tScale = mTable.Rows(0)("FLOOR")
        End If
        mTable.Dispose()

        PictureBox2.Visible = True
        txtTestM.Visible = False
        Dim MyImagelist As New ImageList
        MyImagelist.Images.Add("Pass", Image.FromFile(Application.StartupPath & "\Pass.ico"))
        MyImagelist.Images.Add("Rej", Image.FromFile(Application.StartupPath & "\Rej.ico"))


        With ListView1

            .View = View.Details

            .Columns.Add("#", 40, HorizontalAlignment.Left)
            .Columns.Add("Serial#", 75)
            .Columns.Add("old#", 75)
            .Columns.Add("USALot#", 55)
            .Columns.Add("Particli_yn", 50)
            .Columns.Add("Wash_film", 20)
            .GridLines = True
            .SmallImageList = MyImagelist
            .LargeImageList = MyImagelist
        End With
        If DsMes.Tables("tabMES0201").Rows.Count <= 0 Then
            txtTotalQty.Text = DsMes.Tables("tabMES0200").Rows(0).Item("IN_QTY")
        Else
            DataCount = DsMes.Tables("tabMES0201").Rows.Count - 1
            txtTotalQty.Text = DsMes.Tables("tabMES0201").Rows(DataCount)("OUT_QTY")
        End If
        ' Debug.Print(DsMes.Tables("tabMES0201").Rows(DataCount).Item("travel_no"))
        txtPassQty.Text = 0
        txtRejectQty.Text = 0
        txtWaitQty.Text = txtTotalQty.Text

        Ok = False

        Dim itemX As ListViewItem

        Q = "select * from MES0204 where corp_no='" & CORP_NO & "' and TRAVEL_NO='" & DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO") & "' order by SERIAL_NO"
        'Debug.Print(Q)
        mTable = GetTable(Q, C)
        If mTable.Rows.Count > 0 Then
            Dim i As Integer = 0
            For Each mRow In mTable.Rows
                i = i + 1
                itemX = New ListViewItem(i.ToString, "Pass")
                itemX.SubItems.Add(mRow("SERIAL_NO"))
                itemX.SubItems.Add(mRow("SERIAL_NO_OLD"))
                Q = "select * from DUVDATA where serial_id='" & mRow("SERIAL_NO_OLD") & "'"
                mTableA = GetTable(Q, C)
                If mTableA.Rows.Count > 0 Then
                    Debug.Print(Nz(mTableA.Rows(0)("LOT_ID")))
                    itemX.SubItems.Add(Nz(mTableA.Rows(0)("LOT_ID")))
                Else
                    itemX.SubItems.Add("")
                End If
                itemX.SubItems.Add(Nz(mRow("Particle_YN")))
                itemX.SubItems.Add(Nz(mRow("WASH_FILM")))
                mTableA.Dispose()
                ListView1.Items.Add(itemX)
            Next
        End If

        If mRejTable.Rows.Count > 0 And ListView1.Items.Count < Int(txtTotalQty.Text) Then
            Dim i As Integer = ListView1.Items.Count
            For Each mRow In mRejTable.Rows
                i = i + 1
                itemX = New ListViewItem(i.ToString, "Rej")
                itemX.SubItems.Add(mRow("REJECT_CODE") & "-" & mRow("VENDOR_ID_FRAME") & "-" & mRow("VENDOR_ID_POLE"))
                itemX.SubItems.Add(mRow("REJ_SERIAL_NO"))
                Q = "select * from DUVDATA where serial_id='" & mRow("REJ_SERIAL_NO") & "'"
                mTableA = GetTable(Q, C)
                If mTableA.Rows.Count > 0 Then
                    itemX.SubItems.Add(Nz(mTableA.Rows(0)("LOT_ID")))
                Else
                    itemX.SubItems.Add("")
                End If
                mTableA.Dispose()
                itemX.SubItems.Add(Nz(mRow("PARTICLE_YN")))
                itemX.SubItems.Add(Nz(mRow("WASH_FILM")))
                ListView1.Items.Add(itemX)
            Next
        End If

        txtPassQty.Text = mTable.Rows.Count
        txtRejectQty.Text = mRejTable.Rows.Count
        txtWaitQty.Text = Int(txtTotalQty.Text) - Int(txtPassQty.Text) - Int(txtRejectQty.Text)
        If Int(txtWaitQty.Text) > 0 Then butDone.Enabled = False

        mTable.Dispose()

        If Int(txtWaitQty.Text) <> 0 Then Chk_Type(C)
        rdbMR(0).Checked = True
        C.Close()
        C.Dispose()
        'Dim frmVideo As New frmVideo
        'frmVideo.Show()
    End Sub

    Private Sub ButMeasure_Click(sender As Object, e As EventArgs) Handles ButMeasure.Click
        Dim Film As String = "", status As String = ""
        Dim avg10 As Single, avg100 As Single
        Dim i As Integer, j As Integer, ii As Integer, jj As Integer
        If CheckBox1.Checked Then
            ii = 3
        Else
            ii = 1
        End If

        For jj = 1 To ii
            For i = 0 To 2
                If rdbMR(i).Checked Then Exit For
            Next

            If rdbMR(i).Enabled Then
                If txtF193(i).Enabled = True Then txtF193(i).BackColor = Color.White
                If txtF248(i).Enabled = True Then txtF248(i).BackColor = Color.White
                If txtF365(i).Enabled = True Then txtF365(i).BackColor = Color.White
                If txtF400(i).Enabled = True Then txtF400(i).BackColor = Color.White
                If txtF430(i).Enabled = True Then txtF430(i).BackColor = Color.White
                If txtF436(i).Enabled = True Then txtF436(i).BackColor = Color.White
                If txtFAVG(i).Enabled = True Then txtFAVG(i).BackColor = Color.White
                If txtPeak(i).Enabled = True Then txtPeak(i).BackColor = Color.White
            End If

            ButMeasure.Enabled = False
            txtTestM.Text = ""
            txtMessage.Text = ""
            ButReference.Enabled = False
            PictureBox2.Visible = True
            txtTestM.Visible = False

            If FrmCa Is Nothing Then
                MsgBox("未連接Cary60")
                Exit Sub
            End If

            FrmCa.CaryMeasure()

            aData = FrmCa.aData
            RefC = False

            SetPic()
            If Not RefC Then
                For j = 0 To 2
                    If rdbMR(j).Checked Then Exit For
                Next
                FLMCHK(Film, status, avg100, avg10, Thickness, aData)
                TextBox3.Text = Film & "," & status & "," & avg100 & "," & avg10 & "," & Thickness
                If FILM_TYPE = "602" Then
                    Thickness = 1.55 / 1.36 * Thickness
                    If Thickness = 0 Then
                        txtThickness(j).Text = 1.18
                    ElseIf Thickness > 0 And Thickness <= 0.8 Then
                        txtThickness(j).Text = 1.19
                    ElseIf Thickness > 0.8 And Thickness <= 1.1 Then
                        txtThickness(j).Text = 1.2
                    ElseIf Thickness > 1.1 And Thickness <= 1.3 Then
                        txtThickness(j).Text = 1.21
                    ElseIf Thickness > 1.3 Then
                        txtThickness(j).Text = 1.22
                    End If
                Else
                    txtThickness(j).Text = Thickness
                End If

                If txtPeak(j).Enabled Then
                    FindPeak(j)
                    If txtPeak(j).Text < 365 And txtF365(j).Text > 99.55 Then
                        txtPeak(j).BackColor = Color.Red
                        MsgBox("波峰波長小於365時，F365應大於99.6")
                    End If
                End If
                If rdbMR(1).Enabled Then
                    Chk_U()
                    If j = 2 Then
                        rdbMR(0).Checked = True
                    Else
                        rdbMR(j + 1).Checked = True
                    End If
                End If
            End If
        Next
        ButMeasure.Enabled = True
        butTest.Enabled = True
        ButReference.Enabled = True

    End Sub

    Private Sub ButReference_Click(sender As Object, e As EventArgs) Handles ButReference.Click

        RefC = True
        If FrmCa Is Nothing Then Exit Sub
        CaryBusy = True
        FrmCa.CaryReference()
        aData = FrmCa.aData
        SetPic()
        ButMeasure.Enabled = True
    End Sub
    Private Sub SetPic()
        Dim X1 As Single
        Dim X2 As Single
        Dim Y1 As Single
        Dim Y2 As Single
        Dim j As Integer
        Dim AvgNum As Integer = 0
        Dim TAvg As Single = 0

        Dim mPen As New Pen(Color.Black)
        Dim G As Graphics
        Dim B As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim Ga As Graphics
        Dim Ba As New Bitmap(PictureBox2.Width, PictureBox2.Height)
        G = Graphics.FromImage(B)
        ''繪圖動作
        'G.DrawLine(New Pen(Color.Blue), 0, 0, 100, 100)

        ' G = PictureBox1.CreateGraphics
        X1 = TranPixs("X", 190)
        X2 = TranPixs("X", 500)
        Y1 = TranPixs("Y", 90)
        Y2 = TranPixs("Y", 90)
        G.DrawLine(mPen, X1, Y1, X2, Y2)
        X1 = TranPixs("X", 190)
        X2 = TranPixs("X", 190)
        Y1 = TranPixs("Y", 90)
        Y2 = TranPixs("Y", 101)

        G.DrawLine(mPen, X1, Y1, X2, Y2)
        For i = 2 To 10 Step 2
            X1 = TranPixs("X", 190)
            X2 = TranPixs("X", 192)
            Y1 = TranPixs("Y", 90 + i)
            Y2 = TranPixs("Y", 90 + i)
            G.DrawLine(mPen, X1, Y1, X2, Y2)
            G.DrawString(90 + i, New Font("新細明體", 9), Brushes.Black, X1 - 20, Y1 - 5) '画布写上字符串
        Next i

        X1 = TranPixs("X", 183)
        Y1 = TranPixs("Y", 89.7)
        G.DrawString("190,90", New Font("新細明體", 9), Brushes.Black, X1, Y1) '画布写上字符串
        X1 = TranPixs("X", 495)
        Y1 = TranPixs("Y", 89.7)
        G.DrawString("500", New Font("新細明體", 9), Brushes.Black, X1, Y1) '画布写上字符串
        X1 = TranPixs("X", 193)
        X2 = TranPixs("X", 193)
        Y1 = TranPixs("Y", 90)
        Y2 = TranPixs("Y", 101)
        G.DrawLine(New Pen(Color.Blue), X1, Y1, X2, Y2)
        X1 = TranPixs("X", 248)
        X2 = TranPixs("X", 248)
        G.DrawLine(New Pen(Color.Blue), X1, Y1, X2, Y2)
        X1 = TranPixs("X", 365)
        X2 = TranPixs("X", 365)
        G.DrawLine(New Pen(Color.Blue), X1, Y1, X2, Y2)
        X1 = TranPixs("X", 436)
        X2 = TranPixs("X", 436)
        G.DrawLine(New Pen(Color.Blue), X1, Y1, X2, Y2)
        X1 = TranPixs("X", 188)
        Y1 = TranPixs("Y", 101.7)
        G.DrawString("F193", New Font("新細明體", 9), Brushes.Black, X1, Y1) '画布写上字符串
        X1 = TranPixs("X", 243)
        G.DrawString("F248", New Font("新細明體", 9), Brushes.Black, X1, Y1) '画布写上字符串
        X1 = TranPixs("X", 360)
        G.DrawString("F365", New Font("新細明體", 9), Brushes.Black, X1, Y1) '画布写上字符串
        X1 = TranPixs("X", 431)
        G.DrawString("F436", New Font("新細明體", 9), Brushes.Black, X1, Y1) '画布写上字符串

        X1 = TranPixs("X", aData(0, 0)) : Y1 = TranPixs("Y", aData(0, 1) * 100) : X2 = 0 : Y2 = 0
        For j = 0 To 2
            If rdbMR(j).Checked Then Exit For
        Next
        If aData(0, 0) > 0 Then
            For i = 0 To UBound(aData)
                If aData(i, 0) <> 0 Then
                    X2 = TranPixs("X", aData(i, 0)) : Y2 = TranPixs("Y", aData(i, 1) * 100)
                    G.DrawLine(mPen, X1, Y1, X2, Y2)
                    X1 = X2 : Y1 = Y2
                End If

                Select Case aData(i, 0)
                    Case "193" : txtF193(j).Text = Format(aData(i, 1) * 100, "##0.000")
                    Case "248" : txtF248(j).Text = Format(aData(i, 1) * 100, "##0.000")
                    Case "365" : txtF365(j).Text = Format(aData(i, 1) * 100, "##0.000")
                    Case "400" : txtF400(j).Text = Format(aData(i, 1) * 100, "##0.000")
                    Case "430" : txtF430(j).Text = Format(aData(i, 1) * 100, "##0.000")
                    Case "436" : txtF436(j).Text = Format(aData(i, 1) * 100, "##0.000")
                    Case "440" : F440(j) = Format(aData(i, 1) * 100, "##0.000")
                    Case "441" : F440(j) = Format(aData(i, 1) * 100, "##0.000")
                    Case "405" : F440(j) = Format(aData(i, 1) * 100, "##0.000")
                End Select

                If Val(aData(i, 0)) >= Low_AVG And Val(aData(i, 0)) <= Hi_AVG Then
                    AvgNum = AvgNum + 1
                    TAvg = TAvg + aData(i, 1)
                End If
                'i = i + 1
            Next
            txtFAVG(j).Text = Format(TAvg / AvgNum * 100, "##0.000")
            If txtF193(j).Enabled And CFD(txtF193(j).Text) Then txtF193(j).BackColor = Color.Red
            If txtF248(j).Enabled And CFD(txtF248(j).Text) Then txtF248(j).BackColor = Color.Red
            If txtF365(j).Enabled And CFD(txtF365(j).Text) Then txtF365(j).BackColor = Color.Red
            If txtF400(j).Enabled And CFD(txtF400(j).Text) Then txtF400(j).BackColor = Color.Red
            If txtF430(j).Enabled And CFD(txtF430(j).Text) Then txtF430(j).BackColor = Color.Red
            If txtF436(j).Enabled And CFD(txtF436(j).Text) Then txtF436(j).BackColor = Color.Red

            If txtFAVG(j).Enabled Then
                Select Case FILM_TYPE
                    Case "100"
                        If Val(txtFAVG(j).Text) < 90 Or Val(txtFAVG(j).Text) > 92 Then txtFAVG(j).BackColor = Color.Red
                    Case Else
                        If CFD(txtFAVG(j).Text) Then txtFAVG(j).BackColor = Color.Red
                End Select
            End If

        End If
        PictureBox1.Image = B
        '設定PICture2
        Ga = Graphics.FromImage(Ba)
        X1 = TranPixsB("X", 365)
        X2 = TranPixsB("X", 436)
        Y1 = TranPixsB("Y", 99)
        Y2 = TranPixsB("Y", 99)
        Ga.DrawLine(mPen, X1, Y1, X2, Y2)
        X1 = TranPixsB("X", 365)
        X2 = TranPixsB("X", 365)
        Y1 = TranPixsB("Y", 99)
        Y2 = TranPixsB("Y", 100)
        Ga.DrawLine(mPen, X1, Y1, X2, Y2)
        'Ga.DrawLine(mPen, X1, Y1, X2, Y2)
        For i = 2 To 10 Step 2
            X1 = TranPixsB("X", 365)
            X2 = TranPixsB("X", 366)
            Y1 = TranPixsB("Y", 99 + (i / 10))
            Y2 = TranPixsB("Y", 99 + (i / 10))
            Ga.DrawLine(mPen, X1, Y1, X2, Y2)
            Ga.DrawString(99 + (i / 10), New Font("新細明體", 9), Brushes.Black, X1 - 25, Y1 - 5) '画布写上字符串
        Next i
        X1 = TranPixsB("X", 363)
        Y1 = TranPixsB("Y", 99)
        Ga.DrawString("99,365", New Font("新細明體", 9), Brushes.Black, X1, Y1) '画布写上字符串
        X1 = TranPixsB("X", 433)
        Y1 = TranPixsB("Y", 99)
        Ga.DrawString("436", New Font("新細明體", 9), Brushes.Black, X1, Y1) '画布写上字符串

        X1 = TranPixsB("X", aData(0, 0)) : Y1 = TranPixsB("Y", aData(0, 1) * 100) : X2 = 0 : Y2 = 0
        If aData(0, 0) > 0 Then
            For i = 0 To UBound(aData)
                If aData(i, 0) = 365 Then
                    X1 = TranPixsB("X", aData(i, 0))
                    Y1 = TranPixsB("Y", aData(i, 1) * 100)
                End If
                If aData(i, 0) >= 365 And aData(i, 0) <= 436 Then
                    X2 = TranPixsB("X", aData(i, 0)) : Y2 = TranPixsB("Y", aData(i, 1) * 100)
                    Ga.DrawLine(mPen, X1, Y1, X2, Y2)
                    X1 = X2 : Y1 = Y2
                End If
                'i = i + 1
            Next
        End If
        PictureBox2.Image = Ba
    End Sub
    Private Function TranPixs(mMode As String, mValue As Single) As Single
        Dim PbXL As Single = PictureBox1.Left
        Dim PbYT As Single = PictureBox1.Top
        Dim PbXR As Single = PictureBox1.Right
        Dim PbYB As Single = PictureBox1.Bottom

        If mMode = "X" Then
            TranPixs = (PbXR - PbXL) * (mValue - 175) / (515 - 175)
        Else
            TranPixs = (PbYB - PbYT) * (mValue - 102) / (88 - 102)
        End If

    End Function
    Private Function TranPixsB(mMode As String, mValue As Single) As Single
        Dim PbXL As Single = PictureBox2.Left
        Dim PbYT As Single = PictureBox2.Top
        Dim PbXR As Single = PictureBox2.Right
        Dim PbYB As Single = PictureBox2.Bottom

        If mMode = "X" Then
            TranPixsB = (PbXR - PbXL) * (mValue - 360) / (440 - 360)
        Else
            TranPixsB = (PbYB - PbYT) * (mValue - 100.1) / (98.9 - 100.1)
        End If

    End Function

    Private Sub ButExit_Click(sender As Object, e As EventArgs) Handles ButExit.Click
        Me.Dispose()

    End Sub


    Private Sub Cary60_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'TextBox2.Text = "BBBBBBBB"

        Select Case e.KeyCode
            Case Keys.F2
                If ButMeasure.Enabled Then ButMeasure.PerformClick()
            Case Keys.F3
                If ButReference.Enabled Then ButReference.PerformClick()
            Case Keys.F5
                If butDone.Enabled Then butDone.PerformClick()
            Case Keys.F8
                If butPass.Enabled Then butPass.PerformClick()
            Case Keys.F9
                If butReject.Enabled Then butReject.PerformClick()
            Case Keys.Escape
                If ButExit.Enabled Then ButExit.PerformClick()
            Case Else
                Exit Select
        End Select


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If FrmCa Is Nothing Then Exit Sub
        txtMessage.Text = FrmCa.CaryMassage
        If mCaTime <= 8 Then
            mCaTime = mCaTime + 1
        End If
        If FrmCa.FCStatus = Nothing And CaLoad = True And mCaTime = 8 Then
            CaLoad = False
            MsgBox("Can not connect to Cary60. Please Check the status of instrument")
            FrmCa.Close()
            FrmCa.Dispose()
            FrmCa = Nothing
        End If

    End Sub
    Private Sub Chk_U()
        Dim i As Integer
        Dim mxData(2) As Single
        Dim mUOk As Boolean = True
        Dim mRange As Single

        If rdbMR(1).Enabled Then
            For i = 0 To 2
                If txtF193(i).Enabled Then mxData(i) = Val(txtF193(i).Text)
            Next
            mRange = AMax(mxData) - AMin(mxData)

            If mRange > 0.4 Then mUOk = False
            For i = 0 To 2
                If txtF248(i).Enabled Then mxData(i) = Val(txtF248(i).Text)
            Next
            mRange = AMax(mxData) - AMin(mxData)
            If mRange > 0.4 Then mUOk = False

            For i = 0 To 2
                If txtF365(i).Enabled Then mxData(i) = Val(txtF365(i).Text)
            Next
            mRange = AMax(mxData) - AMin(mxData)
            If mRange > 0.4 Then mUOk = False

            For i = 0 To 2
                If txtF400(i).Enabled Then mxData(i) = Val(txtF400(i).Text)
            Next
            mRange = AMax(mxData) - AMin(mxData)
            If mRange > 0.4 Then mUOk = False

            For i = 0 To 2
                If txtF430(i).Enabled Then mxData(i) = Val(txtF430(i).Text)
            Next
            mRange = AMax(mxData) - AMin(mxData)
            If mRange > 0.4 Then mUOk = False

            For i = 0 To 2
                If txtF436(i).Enabled Then mxData(i) = Val(txtF436(i).Text)
            Next
            mRange = AMax(mxData) - AMin(mxData)
            If mRange > 0.4 Then mUOk = False

            If mUOk = False Then
                lblOk.Text = "Uniformity is NG"
                lblOk.Visible = True
            Else

                lblOk.Visible = False
            End If
        End If


    End Sub
    Private Sub FindPeak(k As Integer)
        Dim i As Integer, j As Integer
        Dim m1 As Integer = 0, m2 As Integer = 0
        Dim mMax As Single = 0, mAbs As Single = 0
        Dim mPo As Integer = 0
        Dim mFP As Single = 0

        For i = 0 To UBound(aData)
            If aData(i, 0) >= 350 And aData(i, 0) <= 380 Then
                If aData(i, 1) > mMax Then
                    mMax = aData(i, 1)
                    mPo = aData(i, 0)
                    j = i
                End If
            End If
        Next

        mAbs = 1
        i = j
        Do
            If Math.Abs(aData(i, 1) - 0.98) < mAbs Then
                mAbs = Math.Abs(aData(i, 1) - 0.98)
                m1 = aData(i, 0)
                mFP = aData(i, 1)
            End If
            i = i - 1
        Loop Until aData(i, 0) > 350
        mAbs = 1
        i = j
        Do
            If Math.Abs(aData(i, 1) - mFP) < mAbs Then
                mAbs = Math.Abs(aData(i, 1) - mFP)
                m2 = aData(i, 1)
            End If
            i = i + 1
        Loop Until aData(i, 0) > 380

        mFP = (m1 + m2) / 2

        If mFP - Int(mFP) > 0 Then
            mFP = Int(mFP) + 1
        End If
        txtPeak(k).Text = mFP

    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
    Private Sub Chk_Type(C As SqlClient.SqlConnection)
        Dim NewProd As Boolean = False
        Dim Second As Boolean = False
        Dim OldNo As String = ""
        Dim SerialType As String
        Dim Q As String
        Dim i As Integer
        Dim USALotNo As String
        Dim TF(9) As String
        Dim mTable As DataTable
        Select Case Mid(DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO"), 1, 3)
            Case "111", "188", "115", "131" : NewProd = True
        End Select
        If Not NewProd Then
            Dim frmSerialType As frmSerialType = New frmSerialType
            With frmSerialType
                .TravelNo = DsMes.Tables("tabMES0200").Rows(0)("TRAVEL_NO")
                .ShowI(NewProd, Second)
                If .Ok Then
                    OldNo = .OldNo
                    SerialType = .SerialType
                    USALotNo = .USALotNo
                    TF = .TF
                Else
                    butPass.Enabled = False
                    butReject.Enabled = True
                    MsgBox("No serial no and lot no input")
                    Exit Sub
                End If
            End With
            i = ListView1.Items.Count + 1
            Dim itemX As ListViewItem
            itemX = New ListViewItem(i.ToString)
            itemX.SubItems.Add("")
            itemX.SubItems.Add(OldNo)
            itemX.SubItems.Add(USALotNo)
            itemX.SubItems.Add("")
            itemX.SubItems.Add("")

            ListView1.Items.Add(itemX)

            txtF193(0).Text = TF(0)
            txtF248(0).Text = TF(1)
            txtF365(0).Text = TF(2)
            txtF400(0).Text = TF(3)
            txtF430(0).Text = TF(4)
            txtF436(0).Text = TF(5)
            txtFAVG(0).Text = TF(6)
            txtThickness(0).Text = TF(7)
            txtPeak(0).Text = TF(9)
            txtLIOp.Text = TF(8)

            If rdbMR(1).Enabled Then
                Q = "select * from MES0213 where corp_no='" & CORP_NO & "' and seril_no='" & OldNo & "' order by travel_no desc,data_seq"
                mTable = GetTable(Q, C)
                If mTable.Rows.Count > 0 Then
                    For Each mRow In mTable.Rows
                        i = mRow("DATA_SEQ") - 1
                        If Not IsDBNull(mRow("F193")) Then txtF193(i).Text = mRow("F193")
                        If Not IsDBNull(mRow("F248")) Then txtF248(i).Text = mRow("F248")
                        If Not IsDBNull(mRow("F365")) Then txtF365(i).Text = mRow("F365")
                        If Not IsDBNull(mRow("F400")) Then txtF400(i).Text = mRow("F400")
                        If Not IsDBNull(mRow("F430")) Then txtF430(i).Text = mRow("F430")
                        If Not IsDBNull(mRow("F436")) Then txtF436(i).Text = mRow("F436")
                        If Not IsDBNull(mRow("FAVG")) Then txtFAVG(i).Text = mRow("FAVG")
                        If Not IsDBNull(mRow("FILM_THICKNESS")) Then txtThickness(i).Text = mRow("FILM_THICKNESS")
                        If Not IsDBNull(mRow("PEAK")) Then txtPeak(i).Text = mRow("PEAK")
                    Next
                Else
                    mTable.Dispose()
                    Q = "select * from DUVDATA where SERIAL_ID='" & OldNo & "'"
                    mTable = GetTable(Q, C)
                    If mTable.Rows.Count > 0 Then
                        If Nz(mTable.Rows(0)("TRAN_2ND")) <> 0 Then
                            Select Case Mid(mTable.Rows(0)("ITEM_NAME"), InStr(mTable.Rows(0)("ITEM_ID"), "-") + 1, 3)
                                Case "122", "170", "172"
                                    txtF365(1).Text = Nz(mTable.Rows(0)("TRAN1_2ND"))
                                    txtF436(1).Text = Nz(mTable.Rows(0)("TRAN2_2ND"))
                                    txtF365(2).Text = Nz(mTable.Rows(0)("TRAN1_3RD"))
                                    txtF436(2).Text = Nz(mTable.Rows(0)("TRAN2_3RD"))
                                Case "602", "603"
                                    txtF248(1).Text = Nz(mTable.Rows(0)("TRAN1_2ND"))
                                    txtF365(1).Text = Nz(mTable.Rows(0)("TRAN2_2ND"))
                                    txtF248(2).Text = Nz(mTable.Rows(0)("TRAN1_3RD"))
                                    txtF365(2).Text = Nz(mTable.Rows(0)("TRAN2_3RD"))
                                Case "701", "703"
                                    txtF193(1).Text = Nz(mTable.Rows(0)("TRAN1_2ND"))
                                    txtF248(1).Text = Nz(mTable.Rows(0)("TRAN2_2ND"))
                                    txtF193(2).Text = Nz(mTable.Rows(0)("TRAN1_3RD"))
                                    txtF248(2).Text = Nz(mTable.Rows(0)("TRAN2_3RD"))
                                Case "101", "102", "103", "104", "105", "100"
                                    txtFAVG(1).Text = Nz(mTable.Rows(0)("TRAN1_2ND"))
                                    txtFAVG(2).Text = Nz(mTable.Rows(0)("TRAN1_3ND"))
                                Case "110", "111"
                                    txtF436(1).Text = Nz(mTable.Rows(0)("TRAN1_2ND"))
                                    txtF436(2).Text = Nz(mTable.Rows(0)("TRAN1_3RD"))
                                Case "113", "201", "202"
                                    txtF365(1) = Nz(mTable.Rows(0)("TRAN1_2ND"))
                                    txtF365(2) = Nz(mTable.Rows(0)("TRAN1_3RD"))
                                Case "231"
                                    txtF400(1).Text = Nz(mTable.Rows(0)("TRAN1_2ND"))
                                    txtF400(2).Text = Nz(mTable.Rows(0)("TRAN1_3RD"))
                                Case Else
                                    txtF248(1).Text = Nz(mTable.Rows(0)("TRAN1_2ND"))
                                    txtF365(1).Text = Nz(mTable.Rows(0)("TRAN2_2ND"))
                                    txtF248(2).Text = Nz(mTable.Rows(0)("TRAN1_3RD"))
                                    txtF365(2).Text = Nz(mTable.Rows(0)("TRAN2_3RD"))
                            End Select
                            txtThickness(1) = Nz(mTable.Rows(0)("THICKNESS"))
                            txtThickness(2) = Nz(mTable.Rows(0)("THICKNESS"))
                        End If
                    End If
                End If
            End If
            butPass.Enabled = True
            butReject.Enabled = True
            For i = 0 To 2
                If txtF193(i).Enabled And CFD(txtF193(i).Text) Then txtF193(i).BackColor = Color.Red
                If txtF248(i).Enabled And CFD(txtF248(i).Text) Then txtF248(i).BackColor = Color.Red
                If txtF365(i).Enabled And CFD(txtF365(i).Text) Then txtF365(i).BackColor = Color.Red
                If txtF400(i).Enabled And CFD(txtF400(i).Text) Then txtF400(i).BackColor = Color.Red
                If txtF430(i).Enabled And CFD(txtF430(i).Text) Then txtF430(i).BackColor = Color.Red
                If txtF436(i).Enabled And CFD(txtF436(i).Text) Then txtF436(i).BackColor = Color.Red
                If txtFAVG(i).Enabled Then
                    Select Case FILM_TYPE
                        Case "100"
                            If Val(txtFAVG(i).Text) < 90 Or Val(txtFAVG(i).Text) > 92 Then txtFAVG(i).BackColor = Color.Red
                        Case Else
                            If CFD(txtFAVG(i).Text) Then txtFAVG(i).BackColor = Color.Red
                    End Select
                End If
            Next
        End If
    End Sub
    Private Function CFD(mD As String) As Boolean
        Dim FData As Single

        FData = Val(mD)

        FData = Int(FData * 10 + 0.5) / 10
        CFD = False
        If FData < tScale Or FData >= 99.994 Then
            CFD = True
        End If

        Return CFD

    End Function

    Private Sub butPass_Click(sender As Object, e As EventArgs) Handles butPass.Click
        Dim Q As String
        Dim C As SqlClient.SqlConnection
        Dim Da As SqlClient.SqlDataAdapter
        Dim Ds As DataSet
        Dim mTable As DataTable
        Dim mRow As DataRow
        Dim cmdBuilder As SqlClient.SqlCommandBuilder
        Dim i As Integer
        Dim PartYN As String
        Dim mWashFilm As String
        Dim itemX As ListViewItem
        Dim cmd As SqlClient.SqlCommand

        C = GetAdoConn()

        If InStr(1, Me.Text, "UT") = 0 And FILM_TYPE = "602" Then

            Q = "select * from MES0010 where PC_Name='" & Environment.MachineName & "'"
            'Q = "select * from MES0010"
            Da = New SqlClient.SqlDataAdapter(Q, C)
            Ds = New DataSet
            cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
            Da.Fill(Ds, "MES0010")
            mTable = Ds.Tables("MES0010")

            If mTable.Rows.Count <= 0 Then
                MsgBox("Please Check BSC Image!")
                Exit Sub
            Else
                Q = "delete from MES0010 where PC_Name='" & Environment.MachineName & "'"
                cmd = New SqlClient.SqlCommand(Q, C)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If

        End If


        For i = 0 To 2
            If txtF193(i).Enabled Then
                If Trim(txtF193(i).Text) + Trim(txtF248(i).Text) + Trim(txtF365(i).Text) + Trim(txtF400(i).Text) + Trim(txtF430(i).Text) + Trim(txtF436(i).Text) + Trim(txtFAVG(i).Text) = "" Then
                    MsgBox("The measure data should not be empty,Please measure again!")
                    Exit Sub
                End If
            End If
        Next

        For i = 0 To 2
            If txtF193(i).Enabled And CFD(txtF193(i).Text) Then
                MsgBox("F193 should between " & tScale & " and 100%")
                Exit Sub
            End If
            If txtF248(i).Enabled And CFD(txtF248(i).Text) Then
                MsgBox("F248 should between " & tScale & " and 100%")
                Exit Sub
            End If
            If txtF365(i).Enabled And CFD(txtF365(i).Text) Then
                MsgBox("F365 should between " & tScale & " and 100%")
                Exit Sub
            End If
            If txtF400(i).Enabled And CFD(txtF400(i).Text) Then
                MsgBox("F400 should between " & tScale & " and 100%")
                Exit Sub
            End If
            If txtF430(i).Enabled And CFD(txtF430(i).Text) Then
                MsgBox("F430 should between " & tScale & " and 100%")
                Exit Sub
            End If
            If txtF436(i).Enabled And CFD(txtF436(i).Text) Then
                MsgBox("F436 should between " & tScale & " and 100%")
                Exit Sub
            End If
            If txtFAVG(i).Enabled Then
                Select Case FILM_TYPE
                    Case "100"
                        If (Val(txtFAVG(i).Text) < 90 Or Val(txtFAVG(i).Text) > 92) Then
                            MsgBox("FAVG should between 90 and 92%")
                            Exit Sub
                        End If
                    Case Else
                        If CFD(txtFAVG(i).Text) Then
                            MsgBox("FAVG should between " & tScale & " and 100%")
                            Exit Sub
                        End If
                End Select
            End If
            If txtPeak(i).Enabled And (Val(txtPeak(i).Text) < 365 And Val(txtF365(i).Text) < 99.55) Then
                MsgBox("波峰波長小於365時，F365應大於99.6")
                Exit Sub
            End If
        Next
        If rdbMR(1).Enabled And lblOk.Visible = True Then
            MsgBox("Uniformity Error")
            Exit Sub
        End If
        If Val(txtWaitQty.Text) <= 0 Then
            MsgBox("Please do next Travel No.")
            Exit Sub
        End If
        butPass.Enabled = True
        Dim FrmParticle As FrmParticle = New FrmParticle
        With FrmParticle
            .ShowI()
            PartYN = .ParticleYN
            mWashFilm = .WashFilm
            .Dispose()
        End With

        Dim NewProd As Boolean = False
        Dim Second As Boolean = False
        Dim OldNo As String = ""
        Dim SerialType As String = ""
        Dim USALotNo As String
        Dim TF(9) As String
        Select Case Strings.Left(DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO"), 3)
            Case "111", "115", "188", "131" : NewProd = True
        End Select
        Dim CUST_NO As String = DsMes.Tables("tabMES0200").Rows(0).Item("CUST_NO")
        If CUST_NO = "32IK" Or CUST_NO = "DNP" Or CUST_NO = "HOYA" Or CUST_NO = "MATSUSHITA" Or CUST_NO = "31INA" Or
            CUST_NO = "NEC" Or CUST_NO = "ROHM" Or CUST_NO = "SANYO" Or CUST_NO = "SIGA" Or CUST_NO = "TOPPAN" Or
            CUST_NO = "YAMAHA KAGOSHIMA" Or Strings.Left(CUST_NO, 2) = "US" Then 'Or CUST_NO = "96SWT" Then
            If Strings.Left(DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO"), 3) <> "125" Then
                Second = True
                Dim frmSerialType As frmSerialType = New frmSerialType
                With frmSerialType
                    .TravelNo = DsMes.Tables("tabMES0200").Rows(0)("TRAVEL_NO")
                    .ShowI(NewProd, Second)
                    If .Ok Then
                        OldNo = .OldNo
                        SerialType = .SerialType
                        USALotNo = .USALotNo
                        TF = .TF
                    Else
                        MsgBox("No serial no and lot no input")
                        Exit Sub
                        'butPass.Enabled = True
                    End If
                    .Dispose()
                End With
                If NewProd Then
                    i = ListView1.Items.Count + 1
                    itemX = New ListViewItem(i.ToString, "Pass")
                    itemX.SubItems.Add("")
                    itemX.SubItems.Add("")
                    itemX.SubItems.Add("")
                    itemX.SubItems.Add(PartYN)
                    itemX.SubItems.Add(mWashFilm)
                    ListView1.Items.Add(itemX)
                Else
                    i = ListView1.Items.Count
                    i = ListView1.FindItemWithText(i.ToString).Index
                    itemX = ListView1.Items(i)
                End If
            Else
                i = ListView1.Items.Count
                i = ListView1.FindItemWithText(i.ToString).Index
                itemX = ListView1.Items(i)
                itemX.ImageKey = "Pass"
                OldNo = itemX.SubItems(2).Text
            End If
        Else
            SerialType = "New"
            If NewProd Then
                i = ListView1.Items.Count + 1
                itemX = New ListViewItem(i.ToString, "Pass")
                itemX.SubItems.Add("")
                itemX.SubItems.Add("")
                itemX.SubItems.Add("")
                itemX.SubItems.Add(PartYN)
                itemX.SubItems.Add(mWashFilm)
                ListView1.Items.Add(itemX)
            Else
                i = ListView1.Items.Count
                i = ListView1.FindItemWithText(i.ToString).Index
                itemX = ListView1.Items(i)
                itemX.ImageKey = "Pass"
            End If
        End If


        txtPassQty.Text = Val(txtPassQty.Text) + 1
        txtWaitQty.Text = Val(txtTotalQty.Text) - Val(txtPassQty.Text) - Val(txtRejectQty.Text)
        Dim realSerial As String
        If SerialType = "New" Then
            Q = "select * from MES0903 where CORP_NO='" & CORP_NO & "'"
            Da = New SqlClient.SqlDataAdapter(Q, C)
            Ds = New DataSet
            'cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
            Da.Fill(Ds, "tab01")
            mTable = Ds.Tables("tab01")
            If mTable.Rows.Count <= 0 Then
                mRow = mTable.NewRow
                mRow("CORP_NO") = CORP_NO
                mRow("CHR") = "A"
                mRow("SERIAL") = 0
                mTable.Rows.Add(mRow)
            End If
            Dim ch As String
            Dim serial As Long
            ch = mTable.Rows(0).Item("CHR")
            serial = mTable.Rows(0).Item("SERIAL") + 1
            If serial > 9999999 Then
                ch = Chr(Asc(ch) + 1)
                serial = 1
            End If

            realSerial = SR_PREFIX & ch & Format(serial, "0000000")

            mTable.Dispose()
            Ds.Dispose()
            Da.Dispose()
            Q = "update MES0903 set SERIAL='" & serial & "', CHR='" & ch & "'  where CORP_NO='" & CORP_NO & "' "
            'Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(Q, C)
            cmd = New SqlClient.SqlCommand(Q, C)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Else
            realSerial = OldNo
        End If
        If Not NewProd And Strings.Left(DsMes.Tables("tabMES0200").Rows(0).Item("PROD_NO"), 1) = "0" Then
            Q = "select * from MES0204 where CORP_NO='" & CORP_NO & "' and SERIAL_NO='" & itemX.SubItems(2).Text & "'"
            mTable = GetTable(Q, C)
            Q = "select * from DUVDATA where SERIAL_ID='" & itemX.SubItems(2).Text & "'"
            Da = New SqlClient.SqlDataAdapter(Q, C)
            Da = New SqlClient.SqlDataAdapter(Q, C)
            Ds = New DataSet
            cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
            Da.Fill(Ds, "tab01")
            If mTable.Rows.Count = 0 And Ds.Tables("tab01").Rows.Count = 0 Then
                mRow = Ds.Tables("tab01").NewRow
                mRow("ITEM_NAME") = DsMes.Tables("tabMES0200").Rows(0)("PROD_NAME")
                mRow("SERIAL_ID") = itemX.SubItems(2).Text
                mRow("LOT_ID") = itemX.SubItems(3).Text
                Select Case FILM_TYPE
                    Case "122", "170", "172"
                        mRow("F248nm") = txtF365(0).Text
                        mRow("F365nm") = txtF436(0).Text
                    Case "602", "603"
                        mRow("F248nm") = txtF248(0).Text
                        mRow("F365nm") = txtF365(0).Text
                    Case "701", "703"
                        mRow("F248nm") = txtF193(0).Text
                        mRow("F365nm") = txtF248(0).Text
                    Case "101", "102", "103", "104", "105", "100"
                        mRow("F248nm") = txtFAVG(0).Text
                        'mRow("F365nm") = txtF436(0).Text
                    Case "110", "111"
                        mRow("F248nm") = txtF436(0).Text
                        'mRow("F365nm") = txtF436(0).Text
                    Case "113", "201", "202"
                        mRow("F248nm") = txtF365(0).Text
                        'mRow("F365nm") = txtF436(0).Text
                    Case "231"
                        mRow("F248nm") = txtF400(0).Text
                        ' mRow("F365nm") = txtF436(0).Text
                    Case Else
                        mRow("F248nm") = txtF248(0).Text
                        mRow("F365nm") = txtF365(0).Text
                End Select
                mRow("THICKNESS") = txtThickness(0).Text
                mRow("FILE_NAME") = CORP_NO & "-SYSTEM"
                Ds.Tables("tab01").Rows.Add(mRow)
                Da.Update(Ds, "tab01")
            End If
            mTable.Dispose()
            Ds.Dispose()
            cmdBuilder.Dispose()
            Da.Dispose()
        End If

        Q = "select * from MES0204 where CORP_NO='" & CORP_NO & "' and TRAVEL_NO='" & DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO") & "'"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        Da.Fill(Ds, "00")
        mRow = Ds.Tables("00").NewRow
        mRow("CORP_NO") = CORP_NO
        mRow("TRAVEL_NO") = DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO")
        mRow("SERIAL_NO") = realSerial
        mRow("SERIAL_NO_OLD") = itemX.SubItems(2).Text
        If mRow("TRAVEL_NO") Like "125*" Then
            mRow("LOT_NO") = itemX.SubItems(3).Text
        Else
            Select Case DsMes.Tables("tabMES0200").Rows(0).Item("PROD_NAME")
                Case "ASM14P-122-1017HFLC"
                    mRow("LOT_NO") = Format(DateAndTime.Now, "MMdd") & Strings.Right(Year(DateAndTime.Now), 1) & "P"
                Case Else
                    mRow("LOT_NO") = Format(DateAndTime.Now, "MMdd") & Strings.Right(Year(DateAndTime.Now), 1) & Mid(SHIFT, 1, 1)
            End Select
        End If
        If txtF193(0).Enabled Then mRow("F193") = txtF193(0).Text
        If txtF248(0).Enabled Then mRow("F248") = txtF248(0).Text
        If txtF365(0).Enabled Then mRow("F365") = txtF365(0).Text
        If txtF400(0).Enabled Then mRow("F400") = txtF400(0).Text
        If txtF430(0).Enabled Then mRow("F430") = txtF430(0).Text
        If txtF436(0).Enabled Then mRow("F436") = txtF436(0).Text
        If txtFAVG(0).Enabled Then mRow("FAVG") = txtFAVG(0).Text
        If txtPeak(0).Enabled Then mRow("PEAK") = txtPeak(0).Text
        mRow("DIAG_9") = F440(0)
        mRow("DIAG_10") = F441(0)
        If FILM_TYPE = "122" Then mRow("F405") = F405(0)
        mRow("FILM_THICKNESS") = txtThickness(0).Text
        mRow("THICK_ORI") = Thickness
        mRow("REMARK") = txtRemark.Text
        mRow("MODIFY_ID") = USER_ID
        mRow("MODIFY_TIME") = Now
        mRow("PARTICLE_YN") = PartYN
        mRow("WASH_FILM") = mWashFilm
        itemX.SubItems(1).Text = realSerial
        itemX.SubItems(4).Text = PartYN
        itemX.SubItems(5).Text = mWashFilm
        Ds.Tables("00").Rows.Add(mRow)
        Da.Update(Ds, "00")
        Ds.Dispose()
        cmdBuilder.Dispose()
        Da.Dispose()

        If rdbMR(1).Enabled Then
            Q = "select * from MES0213 where CORP_NO='" & CORP_NO & "' and TRAVEL_NO='" & DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO") & "'"
            Da = New SqlClient.SqlDataAdapter(Q, C)
            Ds = New DataSet
            cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
            Da.Fill(Ds, "00")
            For i = 0 To 2
                mRow = Ds.Tables("00").NewRow
                mRow("CORP_NO") = CORP_NO
                mRow("TRAVEL_NO") = DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO")
                If DsMes.Tables("tabMES0201").Rows.Count <= 0 Then
                    mRow("TRAVEL_SEQ") = 1
                Else
                    mRow("TRAVEL_SEQ") = DsMes.Tables("tabMES0201").Rows(DsMes.Tables("tabMES0201").Rows.Count - 1).Item("TRAVEL_SEQ") + 1
                End If
                mRow("SERIAL_NO") = realSerial
                mRow("DATA_SEQ") = i + 1
                If txtF193(i).Enabled Then mRow("F193") = txtF193(i).Text
                If txtF248(i).Enabled Then mRow("F248") = txtF248(i).Text
                If txtF365(i).Enabled Then mRow("F365") = txtF365(i).Text
                If txtF400(i).Enabled Then mRow("F400") = txtF400(i).Text
                If txtF430(i).Enabled Then mRow("F430") = txtF430(i).Text
                If txtF436(i).Enabled Then mRow("F436") = txtF436(i).Text
                If txtFAVG(i).Enabled Then mRow("FAVG") = txtFAVG(i).Text
                If txtPeak(i).Enabled Then mRow("PEAK") = txtPeak(i).Text
                If txtThickness(i).Enabled Then mRow("FILM_THICKNESS") = txtThickness(i).Text
                If FILM_TYPE = "122" Then mRow("F405") = F405(i)
                Ds.Tables("00").Rows.Add(mRow)
            Next
            Da.Update(Ds, "00")
            Ds.Dispose()
            cmdBuilder.Dispose()
            Da.Dispose()
        End If
        txtWaitQty.Text = Val(txtTotalQty.Text) - Val(txtPassQty.Text) - Val(txtRejectQty.Text)
        If Val(txtWaitQty.Text) <= 0 Then butDone.Enabled = True
        For i = 0 To 2
            txtF193(i).Text = "" : txtF248(i).Text = "" : txtF365(i).Text = "" : txtF400(i).Text = ""
            txtF430(i).Text = "" : txtF436(i).Text = "" : txtFAVG(i).Text = ""
            If txtF193(i).Enabled Then txtF193(i).BackColor = Color.White : If txtF248(i).Enabled Then txtF248(i).BackColor = Color.White
            If txtF365(i).Enabled Then txtF365(i).BackColor = Color.White : If txtF400(i).Enabled Then txtF400(i).BackColor = Color.White
            If txtF430(i).Enabled Then txtF430(i).BackColor = Color.White : If txtF436(i).Enabled Then txtF436(i).BackColor = Color.White : txtFAVG(i).BackColor = Color.White

            F405(i) = 0 : F440(i) = 0 : F441(i) = 0
            txtThickness(i).Text = "" : txtPeak(i).Text = ""
            Thickness = 0
            rdbMR(i).Checked = False
        Next
        rdbMR(0).Checked = True
        If txtWaitQty.Text <> 0 Then Chk_Type(C)
        'butPass.Enabled = True
        If rdbMR(1).Enabled = True Then lblOk.Visible = False
        C.Close()
        C.Dispose()
    End Sub

    Private Sub butReject_Click(sender As Object, e As EventArgs) Handles butReject.Click
        Dim rej As String, Vendor As String, Vendor2 As String
        Dim PartYN As String, mWashFilm As String
        Dim FrmRejectCode As FrmRejcetCode
        Dim FrmParticle As FrmParticle
        Dim itemX As ListViewItem
        Dim i As Integer, j As Integer
        Dim C As SqlClient.SqlConnection
        Dim Da As SqlClient.SqlDataAdapter
        Dim Ds As DataSet
        'Dim mTable As DataTable
        Dim mRow As DataRow
        Dim cmdBuilder As SqlClient.SqlCommandBuilder
        Dim Q As String
        If Val(txtWaitQty.Text) <= 0 Then
            MsgBox("Please do next Travel")
            Exit Sub
        End If

        FrmRejectCode = New FrmRejcetCode
        With FrmRejectCode
            If .ShowI(DsMes.Tables("tabMES0200").Rows(0).Item("VOUCHER_NO_IVF1301")) Then
                Vendor = .Vendor
                Vendor2 = .Vendor2
                rej = .RejCode
                .Dispose()
            Else
                .Dispose()
                Exit Sub
            End If
        End With

        FrmParticle = New FrmParticle
        With FrmParticle
            .ShowI()
            PartYN = .ParticleYN
            mWashFilm = .WashFilm
            .Dispose()
        End With
        txtRejectQty.Text = Val(txtRejectQty.Text) + 1

        Dim mTravel As String = DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO")
        Select Case Strings.Left(mTravel, 3)
            Case "111", "188", "115", "131"
                i = ListView1.Items.Count + 1
                itemX = New ListViewItem(i.ToString, "Rej")
                itemX.SubItems.Add("")
                itemX.SubItems.Add("N" & i.ToString)
                itemX.SubItems.Add("")
                itemX.SubItems.Add(PartYN)
                itemX.SubItems.Add(mWashFilm)
                ListView1.Items.Add(itemX)
                'itemX = ListView1.Items.Add(ToString(i), "Rej")
                'itemX.SubItems(2).Text = "N" & ToString(i)
            Case Else
                i = ListView1.Items.Count
                i = ListView1.FindItemWithText(i.ToString).Index
                itemX = ListView1.Items(i)
                itemX.ImageKey = "Rej"
                'itemX.SubItems(2).Text = "N" & i
        End Select
        itemX.SubItems(1).Text = rej & "-" & Vendor & "-" & Vendor2
        itemX.SubItems(4).Text = PartYN
        itemX.SubItems(5).Text = mWashFilm
        txtWaitQty.Text = Val(txtTotalQty.Text) - Val(txtPassQty.Text) - Val(txtRejectQty.Text)

        C = GetAdoConn()
        If DsMes.Tables("tabMES0201").Rows.Count <= 0 Then
            i = 1
        Else
            i = DsMes.Tables("tabMES0201").Rows.Count - 1
            i = DsMes.Tables("tabMES0201").Rows(i).Item("TRAVEL_SEQ") + 1
        End If
        Q = "select * from mes0202 where corp_no='" & CORP_NO & "' and travel_no='" & mTravel & "' and travel_seq='" & i & "'"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet
        Da.Fill(Ds, "00")
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        j = Ds.Tables("00").Rows.Count
        mRow = Ds.Tables("00").NewRow
        mRow("CORP_NO") = CORP_NO
        mRow("TRAVEL_NO") = mTravel
        mRow("TRAVEL_SEQ") = i
        mRow("REJECT_SEQ") = j + 1
        mRow("REJECT_CODE") = rej
        mRow("VENDOR_ID") = Vendor
        mRow("VENDOR_ID2") = Vendor2
        mRow("REJECT_QTY") = 1
        mRow("REJ_SERIAL_NO") = itemX.SubItems(2).Text
        mRow("PARTICLE_YN") = PartYN
        mRow("WASH_FILM") = mWashFilm
        Ds.Tables("00").Rows.Add(mRow)
        Da.Update(Ds, "00")
        Ds.Dispose()
        Da.Dispose()
        cmdBuilder.Dispose()

        If Strings.Left(DsMes.Tables("tabMES0200").Rows(0).Item("PROD_NO"), 1) = "0" Then
            Q = "select * from MES0204 where CORP_NO='" & CORP_NO & "' and SERIAL_NO='" & itemX.SubItems(2).Text & "' "
            Da = New SqlClient.SqlDataAdapter(Q, C)
            Ds = New DataSet
            Da.Fill(Ds, "00")
            Da.Dispose()
            Q = "select * from DUVDATA where serial_id='" & itemX.SubItems(2).Text & "'"
            Da = New SqlClient.SqlDataAdapter(Q, C)
            Da.Fill(Ds, "01")
            cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
            If Ds.Tables("00").Rows.Count <= 0 And Ds.Tables("01").Rows.Count <= 0 Then
                mRow = Ds.Tables("01").NewRow
                mRow("ITEM_NAME") = DsMes.Tables("tabMES0201").Rows(i).Item("PROD_NAME")
                mRow("SERIAL_ID") = itemX.SubItems(2).Text
                mRow("LOT_ID") = itemX.SubItems(3).Text
                Select Case FILM_TYPE
                    Case "122", "170", "172"
                        mRow("F248nm") = txtF365(0).Text
                        mRow("F365nm") = txtF436(0).Text
                    Case "602", "603"
                        mRow("F248nm") = txtF248(0).Text
                        mRow("F365nm") = txtF365(0).Text
                    Case "701", "703"
                        mRow("F248nm") = txtF193(0).Text
                        mRow("F365nm") = txtF248(0).Text
                    Case "101", "102", "103", "104", "105", "100"
                        mRow("F248nm") = txtFAVG(0).Text
                        'mRow("F365nm") = txtF436(0).Text
                    Case "110", "111"
                        mRow("F248nm") = txtF436(0).Text
                        'mRow("F365nm") = txtF436(0).Text
                    Case "113", "201", "202"
                        mRow("F248nm") = txtF365(0).Text
                        'mRow("F365nm") = txtF436(0).Text
                    Case "231"
                        mRow("F248nm") = txtF400(0).Text
                        ' mRow("F365nm") = txtF436(0).Text
                    Case Else
                        mRow("F248nm") = txtF248(0).Text
                        mRow("F365nm") = txtF365(0).Text
                End Select
                mRow("THICKNESS") = txtThickness(0).Text
                mRow("FILE_NAME") = CORP_NO & "-SYSTEM"
                Ds.Tables("01").Rows.Add(mRow)
                Da.Update(Ds, "01")
            End If
            Ds.Dispose()
            Da.Dispose()
            cmdBuilder.Dispose()

        End If

        If itemX.ImageKey = "Rej" Then
            mRow = mRejTable.NewRow
            mRow("REJECT_CODE") = rej
            mRow("VENDOR_ID_FRAME") = Vendor
            mRow("VENDOR_ID_POLE") = Vendor2
            mRow("REJECT_QTY") = 1
            mRow("REJ_SERIAL_NO") = itemX.SubItems(2).Text
            mRow("PARTICLE_YN") = itemX.SubItems(4).Text
            mRow("WASH_FILM") = itemX.SubItems(5).Text
            mRejTable.Rows.Add(mRow)
        End If
        For i = 0 To 2
            txtF193(i).Text = "" : txtF248(i).Text = "" : txtF365(i).Text = "" : txtF400(i).Text = ""
            txtF430(i).Text = "" : txtF436(i).Text = "" : txtFAVG(i).Text = ""
            F405(i) = 0 : F440(i) = 0 : F441(i) = 0
            txtThickness(i).Text = "" : txtPeak(i).Text = ""
            Thickness = 0
            rdbMR(i).Checked = False
        Next
        rdbMR(0).Checked = True
        If txtWaitQty.Text <> 0 Then Chk_Type(C)
        If Val(txtWaitQty.Text) = 0 Then butDone.Enabled = True
        butReject.Enabled = True
        C.Close()
        C.Dispose()

    End Sub

    Private Sub butDelLine_Click(sender As Object, e As EventArgs) Handles butDelLine.Click
        Dim Q As String
        Dim Da As SqlClient.SqlDataAdapter
        Dim ds As DataSet
        Dim mRow As DataRow
        Dim C As SqlClient.SqlConnection
        Dim cmdBuilder As SqlClient.SqlCommandBuilder
        Dim cmd As SqlClient.SqlCommand
        Dim i As Integer, j As Integer, mindex As Integer = 0
        Dim SerialNo As String = ""
        Dim itemX As ListViewItem
        Dim itemXs As ListView.SelectedListViewItemCollection = ListView1.SelectedItems

        If itemXs.Count = 0 Then
            MsgBox("No item selected")
            Exit Sub
        End If

        For Each itemX In itemXs
            mindex = itemX.Index
            SerialNo = itemX.SubItems(1).Text
        Next
        If vbYes = MsgBox("Do you really want to delete this item" & vbCrLf & SerialNo, vbYesNo) Then
        Else
            Exit Sub
        End If

        C = GetAdoConn()
        Q = "delete from MES0204 where CORP_NO='" & CORP_NO & "' and TRAVEL_NO='" & DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO") & "' and SERIAL_NO='" & SerialNo & "'"
        cmd = New SqlClient.SqlCommand(Q, C)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        If DsMes.Tables("tabMES0201").Rows.Count <= 0 Then
            i = 1
        Else
            i = DsMes.Tables("tabMES0201").Rows.Count - 1
            i = DsMes.Tables("tabMES0201").Rows(i).Item("TRAVEL_SEQ") + 1
        End If
        Q = "delete from MES0202 where CORP_NO='" & CORP_NO & "' and TRAVEL_NO='" & DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO") & "' and REJ_SERIAL_NO='" & ListView1.Items(mindex).SubItems(2).Text & "' "
        Q = Q & "and TRAVEL_SEQ='" & i & "' "
        cmd = New SqlClient.SqlCommand(Q, C)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        If rdbMR(1).Enabled Then
            Q = "delete from MES0213 where CORP_NO='" & CORP_NO & "' and TRAVEL_NO='" & DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO") & "' and serial_no='" & SerialNo & "'"
            cmd = New SqlClient.SqlCommand(Q, C)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        Q = "select * from MES0202 where corp_no='" & CORP_NO & "' and TRAVEL_NO='" & DsMes.Tables("tabMES0200").Rows(0).Item("TRAVEL_NO") & "' and TRAVEL_SEQ='" & i & "'"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        ds = New DataSet
        Da.Fill(ds, "00")
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        For Each mrow In ds.Tables("00").Rows
            j = j + 1
            mrow("REJECT_SEQ") = j
        Next
        Da.Update(ds, "00")
        ds.Dispose()
        cmdBuilder.Dispose()
        Da.Dispose()

        If ListView1.Items(mindex).ImageKey = "Pass" Then
            txtPassQty.Text = Val(txtPassQty.Text) - 1
        ElseIf ListView1.Items(mindex).ImageKey = "Rej" Then
            txtRejectQty.Text = Val(txtRejectQty.Text) - 1
            For Each mRow In mRejTable.Rows
                If mRow("REJ_SERIAL_NO") = ListView1.Items(mindex).SubItems(2).Text Then
                    mRow.Delete()
                    Exit For
                End If
            Next
            mRejTable.AcceptChanges()
        End If

        txtWaitQty.Text = Val(txtTotalQty.Text) - Val(txtPassQty.Text) - Val(txtRejectQty.Text)

        ListView1.Items(mindex).Remove()

        For i = 1 To ListView1.Items.Count
            ListView1.Items(i - 1).Text = i
        Next
        If txtWaitQty.Text > 0 Then Chk_Type(C)
        C.Close()
        C.Dispose()
    End Sub

    Private Sub butDone_Click(sender As Object, e As EventArgs) Handles butDone.Click
        If Val(txtWaitQty.Text) <> 0 Then
            MsgBox("This Travel does not finished")
            Exit Sub
        End If
        Ok = True
        Me.Hide()
    End Sub

    Private Sub butTest_Click(sender As Object, e As EventArgs) Handles butTest.Click

    End Sub

    Private Sub frmCary60_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If bolConnectCary60 = True Then
            Do
                DelayTime(1)
                'Thread.Sleep(1)
                If mCaTime >= 8 And IsNothing(FrmCa) Then Exit Sub
            Loop Until txtMessage.Text = "Ready"
            ButReference.Enabled = True
        End If
    End Sub

    Private Sub txtF193_1_LostFocus(sender As Object, e As EventArgs) Handles txtF193_1.LostFocus, txtF193_2.LostFocus, txtF193_3.LostFocus
        If rdbMR(1).Enabled Then Chk_U()
    End Sub

    Private Sub txtF248_1_LostFocus(sender As Object, e As EventArgs) Handles txtF248_1.LostFocus, txtF248_2.LostFocus, txtF248_3.LostFocus
        If rdbMR(1).Enabled Then Chk_U()
    End Sub

    Private Sub txtF365_1_LostFocus(sender As Object, e As EventArgs) Handles txtF365_1.LostFocus, txtF365_2.LostFocus, txtF365_3.LostFocus
        If rdbMR(1).Enabled Then Chk_U()
    End Sub

    Private Sub txtF400_1_LostFocus(sender As Object, e As EventArgs) Handles txtF400_1.LostFocus, txtF400_2.LostFocus, txtF400_3.LostFocus
        If rdbMR(1).Enabled Then Chk_U()
    End Sub

    Private Sub txtF436_1_LostFocus(sender As Object, e As EventArgs) Handles txtF436_1.LostFocus, txtF436_2.LostFocus, txtF436_3.LostFocus
        If rdbMR(1).Enabled Then Chk_U()
    End Sub

    Private Sub txtFAVG_1_LostFocus(sender As Object, e As EventArgs) Handles txtFAVG_1.LostFocus, txtFAVG_2.LostFocus, txtFAVG_3.LostFocus
        If rdbMR(1).Enabled Then Chk_U()
    End Sub

    Private Sub connectCary60_CheckedChanged(sender As Object, e As EventArgs) Handles connectCary60.CheckedChanged
        If connectCary60.Checked = True Then
            bolConnectCary60 = True
            If IsNothing(FrmCa) Then
                FrmCa = New FrmCaryC
                FrmCa.Show()
            End If
            Timer1.Enabled = True
        Else
            bolConnectCary60 = False
            Timer1.Enabled = False
        End If
    End Sub


End Class