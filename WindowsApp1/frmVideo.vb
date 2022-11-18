Imports System
Imports System.Text
Imports System.ComponentModel
Imports System.Threading
Imports System.Drawing
Imports System.IO
Imports FlyCapture2Managed
Imports Euresys.Open_eVision_2_5

' Open eVision objects declaration
Public Class frmVideo
#Region "宣告"
    'integer
    Dim imgcnt As Integer = 0
    Dim numCam As UInt32
    Dim triggerEnable As Integer = 0
    'camera
    Dim busMgr As ManagedBusManager
    Dim guid As ManagedPGRGuid
    Dim camInfo As CameraInfo
    Dim cam As ManagedCamera = New ManagedCamera
    Dim triggerMode As TriggerMode
    'imageformat
    Dim m_rawImg As ManagedImage
    Dim m_processImg As ManagedImage
    'thread
    Dim m_grabThgreadExited As AutoResetEvent
    Dim m_grabthread As BackgroundWorker
    'boolean
    Dim m_grabImg As Boolean
    Dim useSoftwareTrigger As Boolean = True
    Dim retVal As Boolean
#End Region
    ' Open eVision objects
    Dim _image As New EImageBW8     '即時影像
    Dim m_Source As New EImageBW8 'copy 即時影像
    Dim _roi As New EROIBW8         '即時影像中ROI
    Dim _imagePattern As New EImageBW8     'Pattern
    Dim _handle As EDragHandle

    Dim Q As String
    Dim C As SqlClient.SqlConnection
    Dim Da As SqlClient.SqlDataAdapter
    Dim Ds As DataSet
    Dim mTable As DataTable
    Dim mRow As DataRow
    Dim ProdNo As String
    Dim cmdBuilder As SqlClient.SqlCommandBuilder
    Dim cmd As SqlClient.SqlCommand
    Dim bolCheckHardware As Boolean = False
    Dim OldBSCType As String
    Dim NowBSCType As String
    Dim bolChecked As Boolean
    Dim bmp As Bitmap
    Private m_Matcher As New EMatcher()
    Private m_Handle As EDragHandle
    Dim m_dev As Short
    Private openFileDialog As System.Windows.Forms.OpenFileDialog

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim version As FC2Version = ManagedUtilities.libraryVersion
        Dim newStr As StringBuilder = New StringBuilder()
        Dim FileNum As Integer
        Dim strTemp As String

        FileNum = FreeFile()
        FileOpen(FileNum, "Test.txt", OpenMode.Input)

        Do Until EOF(FileNum)
            txtPassScore.Text &= LineInput(FileNum) & vbNewLine
        Loop
        FileClose(FileNum)
        C = GetAdoConn()
        Q = "select * from MES0010 where PC_Name='" & Environment.MachineName & "'"
        'Q = "select * from MES0010"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        Da.Fill(Ds, "00")
        mTable = Ds.Tables("00")
        DO_WritePort(m_dev, 0, 0)
        Try
            If mTable.Rows.Count < 1 Then
                mRow = Ds.Tables("00").NewRow
                mRow("Pc_Name") = Environment.MachineName
                mRow("Image_Check") = "FAIL"
                If IsDBNull(mRow("PROD_NO")) = True Then mRow("PROD_NO") = "2SV07-602BA20LB"
                ProdNo = mRow("PROD_NO")
                txtType.Text = ProdNo
                Ds.Tables("00").Rows.Add(mRow)
            End If
            Da.Update(Ds, "00")
            Ds.Dispose()
            Da.Dispose()
            cmdBuilder.Dispose()
            C.Close()
            C.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            'cmd_Load_Click_1(Nothing, Nothing)
        End Try
        If bolCheckHardware = True Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
            Exit Sub
        End If

        DO_WritePort(m_dev, 0, 0)
        FileClose(FileNum)
        ' Introduction message
        m_dev = Register_Card(PCI_7250, 0)
        If (m_dev < 0) Then
            MessageBox.Show("Register_Card error!")
        End If

        Dim strMsg As String
        strMsg = "Load an image, then use your mouse to drag and resize the ROI." + vbCrLf + vbCrLf
        strMsg = strMsg + "Suggested image: Any gray level image." + vbCrLf
        strMsg = strMsg + "Required licences: Any"
        ' MsgBox(strMsg, vbInformation)

        ' Initialize the ROI handle to 'NoHandle' FlyCap3CameraControl
        _handle = EDragHandle.NoHandle

        busMgr = New ManagedBusManager()
        numCam = busMgr.GetNumOfCameras()
        If bolCheckHardware = True Then
            If (numCam < 1) Then
                MsgBox("No Camera Detected!")
                End
            End If
        Else
            Exit Sub
        End If
        guid = busMgr.GetCameraFromIndex(0)
        cam.Connect(guid)

        Dim embeddedInfo As EmbeddedImageInfo = cam.GetEmbeddedImageInfo()

        If (embeddedInfo.timestamp.available = True) Then
            embeddedInfo.timestamp.onOff = True
        End If

        cam.SetEmbeddedImageInfo(embeddedInfo)

        m_rawImg = New ManagedImage()
        m_processImg = New ManagedImage()
        m_grabThgreadExited = New AutoResetEvent(False)
        camInfo = cam.GetCameraInfo()
        printcamInfo()
        cam.StartCapture()
        m_grabImg = True

        StartGrabLoop()

    End Sub

    '   Dim bImage As New Bitmap(_image)
    Private Sub UpdateUI()
        Try
            PictureBox1.Image = m_processImg.bitmap
            PictureBox1.Invalidate()
        Catch exc As EException
            'MessageBox.Show(Err.Description)
        End Try
    End Sub

    ''' <summary>
    ''' age
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GrabLoop(sender As Object, e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = New BackgroundWorker

        worker = sender
        While m_grabImg
            Try
                cam.RetrieveBuffer(m_rawImg)
            Catch ex As FC2Exception
                MsgBox("error :" & ex.Message()) ', 
                Continue While
            End Try

            m_rawImg.Convert(PixelFormat.PixelFormatMono8, m_processImg)

            Dim _bmp = New Bitmap(808, 608)
            Dim rect As New Rectangle(0, 0, _bmp.Width, _bmp.Height)
            Dim bmpData = New System.Drawing.Imaging.BitmapData()
            Try
                _bmp = m_processImg.bitmap.Clone(rect, m_processImg.bitmap.PixelFormat)
                bmpData = _bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, _bmp.PixelFormat)
            Catch exc As EException
                'MessageBox.Show(Err.Description)
            End Try

            Dim ptr As IntPtr
            ptr = bmpData.Scan0
            _image.SetImagePtr(_bmp.Width, _bmp.Height, ptr)
            Thread.Sleep(600)
            'EasyImage.Copy(_image, m_Source)
            worker.ReportProgress(0)
        End While
        m_grabThgreadExited.Set()
    End Sub

    Private Sub StartGrabLoop()
        m_grabthread = New BackgroundWorker()
        AddHandler m_grabthread.ProgressChanged, AddressOf UpdateUI
        AddHandler m_grabthread.DoWork, AddressOf GrabLoop
        m_grabthread.WorkerReportsProgress = True
        m_grabthread.RunWorkerAsync()
    End Sub

    Function printcamInfo()
        Dim newStr As StringBuilder = New StringBuilder()
        newStr.Append("*** camera information ***" & vbNewLine)
        newStr.AppendFormat("serail Num - {0}" & vbNewLine, camInfo.serialNumber)
        newStr.AppendFormat("camera Model - {0}" & vbNewLine, camInfo.modelName)
        newStr.AppendFormat("camera Vendor - {0}" & vbNewLine, camInfo.vendorName)
        newStr.AppendFormat("sendor - {0}" & vbNewLine, camInfo.sensorInfo)
        newStr.AppendFormat("resolution - {0}" & vbNewLine, camInfo.sensorResolution)
        Label1.Text = newStr.ToString()
    End Function

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        m_grabImg = False
        Thread.Sleep(2000)
        cam.StopCapture()
        cam.Disconnect()
        Dim err As Short
        If (m_dev >= 0) Then
            err = DASK.Release_Card(m_dev)
        End If
    End Sub

    Private Sub Redraw(ByVal g As Graphics)
        If _image.IsVoid Then
            Return
        End If
        Try
            _image.Draw(g)
            '_image.Draw(g)
            ' Draw the ROI frame
            If check_ROI.Checked = True Then
                _roi.DrawFrame(g, True)
            End If
        Catch exc As EException
            MessageBox.Show(Err.Description)
        End Try
        Dim greenPen As New ERGBColor(0, 255, 0)
        m_Matcher.DrawPositions(g, greenPen, True)

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        ' Redraw the form content
        Redraw(e.Graphics)
    End Sub

    Private Sub PictureBox2_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        ' Redraw the form content
        Redraw(e.Graphics)
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        ' If the ROI is empty, exit
        If _roi.IsVoid Then
            Exit Sub
        End If
        ' Get the ROI handle under the cursor
        _handle = _roi.HitTest(e.X, e.Y)
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        ' If the ROI is empty, exit
        If bolCheckHardware = False Then Exit Sub
        If _roi.IsVoid Then
            Exit Sub
        End If

        ' If there is a handle under the cursor...
        If (_handle <> EDragHandle.NoHandle) Then

            ' Drag the ROI handle to the cursor position
            _roi.Drag(_handle, e.X, e.Y)

            ' Refresh the form
            'Redraw(CreateGraphics())
        End If

        ' Change the cursor shape
        Select Case _roi.HitTest(e.X, e.Y)
            Case EDragHandle.North : Cursor = Cursors.SizeNS
            Case EDragHandle.South : Cursor = Cursors.SizeNS
            Case EDragHandle.West : Cursor = Cursors.SizeWE
            Case EDragHandle.East : Cursor = Cursors.SizeWE
            Case EDragHandle.NorthEast : Cursor = Cursors.SizeNESW
            Case EDragHandle.SouthWest : Cursor = Cursors.SizeNESW
            Case EDragHandle.NorthWest : Cursor = Cursors.SizeNWSE
            Case EDragHandle.SouthEast : Cursor = Cursors.SizeNWSE
            Case EDragHandle.Inside : Cursor = Cursors.SizeAll
            Case EDragHandle.NoHandle : Cursor = Cursors.Arrow
        End Select
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        ' Reset the current handle to 'NoHandle'
        _handle = EDragHandle.NoHandle
    End Sub

    Private Sub button1_Click_1(sender As Object, e As EventArgs) Handles button1.Click
        Dim err As Short
        Dim out_value As Integer
        If (Int32.TryParse(textBox1.Text, out_value)) Then
            err = DO_WritePort(m_dev, 0, out_value)
            If (err < 0) Then
                MessageBox.Show("DO_WritePort error!")
            End If
        Else
            MessageBox.Show("Input error!")
        End If
    End Sub

    Private Sub button2_Click_1(sender As Object, e As EventArgs) Handles button2.Click
        Dim err As Short
        Dim int_value As UInteger
        err = DASK.DI_ReadPort(m_dev, 0, int_value)
        If (err < 0) Then
            MessageBox.Show("D2K_DI_ReadPort error!")
            Return
        End If
        textBox2.Text = int_value
    End Sub

    Private Sub check_ROI_CheckedChanged_1(sender As Object, e As EventArgs) Handles check_ROI.CheckedChanged
        If check_ROI.Checked = True Then
            _roi.SetPlacement(50, 50, 120, 120)
            _roi.Attach(_image)
        Else
            _roi.Detach()
        End If
    End Sub

    Private Sub cmdSave_Click_1(sender As Object, e As EventArgs) Handles cmdSave.Click
        'PictureBox1.Image.Save("test.jpg")
        Dim filePath As String
        FileOpen(2, "test.txt", OpenMode.Output)
        Print(2, Trim(txtPassScore.Text))   ' Print text to file.
        FileClose(2)
        SaveFileDialog1 = New SaveFileDialog()
        SaveFileDialog1.InitialDirectory = Application.StartupPath
        SaveFileDialog1.ShowDialog()
        filePath = SaveFileDialog1.FileName
        PictureBox2.Load("ROI1.jpg")
        _roi.Save(filePath)
        cmd_Load_Click_1(Nothing, Nothing)
    End Sub

    Private Sub cmd_Load_Click_1(sender As Object, e As EventArgs) Handles cmd_Load.Click
        If ProdNo = "" Then ProdNo = "2SV07-602BA20LB"
        C = GetAdoConn()
        Q = "select * from MLI_ST0200 where PROD_NO='" & ProdNo & "'"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        Da.Fill(Ds, "00")
        mTable = Ds.Tables("00")
        If mTable.Rows.Count > 0 Then
            mRow = mTable.Rows(0)
            NowBSCType = mRow("BSC")
        End If
        If bolCheckHardware = True Then _imagePattern.Load("'" & NowBSCType & ".jpg'")
        PictureBox2.Load(NowBSCType & ".jpg")
    End Sub

    Private Sub cmd_Learn_Click_1(sender As Object, e As EventArgs) Handles cmd_Learn.Click
        '_roi.Detach()
        Dim K As EMatchPosition
        Try
            ' Learn the pattern defined by the ROI
            m_Matcher.LearnPattern(_imagePattern)
            'EasyImage.Copy(_image, m_Source)
            ' If a pattern has been learnt
            If m_Matcher.PatternLearnt Then
                ' Find the pattern in the Image
                m_Matcher.Match(_image)
            End If
        Catch exc As EException
            MessageBox.Show(exc.Message)
        End Try

        K = m_Matcher.GetPosition(0)
        txtX.Text = K.CenterX
        txtY.Text = K.CenterY
        txtScore.Text = K.Score
        GroupBox3.BackColor = Color.Green
    End Sub

    Public Function GetAdoConn() As SqlClient.SqlConnection
        Dim Cn As SqlClient.SqlConnection
        Cn = New SqlClient.SqlConnection
        Cn.ConnectionString = "user id=sqlpub;password=sqlpub;initial catalog=PS;data source=MLIDB"
        Cn.Open()
        Return Cn
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'If PictureBox1 Then
        button2_Click_1(Nothing, Nothing)
        If textBox2.Text = "1" Then      'SENSER ON
            'txtScore.Text = 0

            Thread.Sleep(10)
            If bolChecked = True Then   '已經量過東西還在
                DO_WritePort(m_dev, 0, 1) '叫
                Thread.Sleep(500)
                DO_WritePort(m_dev, 0, 0)
                Exit Sub
            End If
            C = GetAdoConn()
            Q = "select * from MES0010 where PC_Name='" & Environment.MachineName & "'"
            Da = New SqlClient.SqlDataAdapter(Q, C)
            Ds = New DataSet
            cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
            Da.Fill(Ds, "MES0010")
            mTable = Ds.Tables("MES0010")
            If mTable.Rows.Count <= 0 Then  '要量
                For i = 0 To 10
                    cmd_Learn_Click_1(Nothing, Nothing)
                    If Val(txtScore.Text) > Val(txtPassScore.Text) Then '過形狀對
                        button1_Click_1(Nothing, Nothing)
                        GroupBox3.BackColor = Color.Green
                        mRow = mTable.NewRow
                        mRow("PC_Name") = Environment.MachineName
                        mRow("Image_Check") = "Pass"
                        mTable.Rows.Add(mRow)
                        Da.Update(Ds, "MES0010")
                        Ds.Dispose()
                        Da.Dispose()
                        DO_WritePort(m_dev, 0, 1) '叫
                        Thread.Sleep(500)
                        DO_WritePort(m_dev, 0, 0)
                        bolChecked = True
                        Thread.Sleep(1000)
                        Exit For
                    Else
                        GroupBox3.BackColor = Color.Red
                    End If
                Next
            Else

            End If
        Else
            bolChecked = False
            GroupBox3.BackColor = Color.White
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cam.StartCapture()
    End Sub

    Private Sub cmdDeleteRs_Click(sender As Object, e As EventArgs) Handles cmdDeleteRs.Click
        C = GetAdoConn()
        Q = "select * from MES0010 where PC_Name='" & Environment.MachineName & "'"
        'Q = "select * from MES0010"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        Da.Fill(Ds, "00")
        mTable = Ds.Tables("00")
        DataGridView1.DataSource = mTable
        DO_WritePort(m_dev, 0, 0)
        TextBox3.Text = mTable.Rows.Count
        If mTable.Rows.Count > 0 Then
            Q = "delete from MES0010 where PC_Name='" & Environment.MachineName & "'"
            cmd = New SqlClient.SqlCommand(Q, C)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        Da.Dispose()
        Ds.Dispose()
        cmdBuilder.Dispose()
        C.Close()
        C.Dispose()
    End Sub

    Private Sub cmdupdateFail_Click(sender As Object, e As EventArgs) Handles cmdupdateFail.Click
        C = GetAdoConn()
        Q = "select * from MES0010 where PC_Name='" & Environment.MachineName & "'"
        'Q = "select * from MES0010"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        Da.Fill(Ds, "00")
        mTable = Ds.Tables("00")
        DataGridView1.DataSource = mTable
        DO_WritePort(m_dev, 0, 0)
        TextBox3.Text = mTable.Rows.Count
        If mTable.Rows.Count > 0 Then
            Q = "Update MES0010 set Image_check = 'PASS' where PC_Name='" & Environment.MachineName & "'"
            cmd = New SqlClient.SqlCommand(Q, C)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        Da.Dispose()
        Ds.Dispose()
        cmdBuilder.Dispose()
        C.Close()
        C.Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        C = GetAdoConn()
        Q = "select * from MES0010 where PC_Name='" & Environment.MachineName & "'"
        'Q = "select * from MES0010"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        Da.Fill(Ds, "00")
        mTable = Ds.Tables("00")
        DataGridView1.DataSource = mTable
    End Sub

    Private Sub cmdInsertRs_Click(sender As Object, e As EventArgs) Handles cmdInsertRs.Click
        C = GetAdoConn()
        Q = "select * from MES0010 where PC_Name='" & Environment.MachineName & "'"
        'Q = "select * from MES0010"
        Da = New SqlClient.SqlDataAdapter(Q, C)
        Ds = New DataSet
        cmdBuilder = New SqlClient.SqlCommandBuilder(Da)
        Da.Fill(Ds, "00")
        mTable = Ds.Tables("00")
        DataGridView1.DataSource = mTable
        DO_WritePort(m_dev, 0, 0)
        TextBox3.Text = mTable.Rows.Count
        If mTable.Rows.Count < 1 Then

            Q = "Insert into MES0010 ([Image_check],[PC_NAME],[PROD_NO]) VALUES('Fail','" & Environment.MachineName & "','" & ProdNo & "')"
            cmd = New SqlClient.SqlCommand(Q, C)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        Da.Dispose()
        Ds.Dispose()
        cmdBuilder.Dispose()
        C.Close()
        C.Dispose()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Interval = "20000"
        cmd_Load_Click_1(Nothing, Nothing)

    End Sub

End Class
