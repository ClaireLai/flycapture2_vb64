<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneral
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTravelNo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblEndTime = New System.Windows.Forms.Label()
        Me.lblOperationID = New System.Windows.Forms.Label()
        Me.lblCustNo = New System.Windows.Forms.Label()
        Me.lblProdNo = New System.Windows.Forms.Label()
        Me.lblProdName = New System.Windows.Forms.Label()
        Me.lblCustSpec = New System.Windows.Forms.Label()
        Me.lblTravelSeq = New System.Windows.Forms.Label()
        Me.lblRework = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblDueDate = New System.Windows.Forms.Label()
        Me.lblStationID = New System.Windows.Forms.Label()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblOperatorID = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRejQty = New System.Windows.Forms.Label()
        Me.lblPassQty = New System.Windows.Forms.Label()
        Me.lblInQty = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblFrame = New System.Windows.Forms.Label()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.lblNextStation = New System.Windows.Forms.Label()
        Me.dgvReject = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvMatr = New System.Windows.Forms.DataGridView()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboMacNo = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtGluePsi = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdbFrameReuse = New System.Windows.Forms.RadioButton()
        Me.rdbFrameNew = New System.Windows.Forms.RadioButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.butTravel = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ButDone = New System.Windows.Forms.Button()
        Me.butSerial = New System.Windows.Forms.Button()
        Me.butWaitOp = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DPopMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvReject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvMatr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Travel No"
        '
        'lblTravelNo
        '
        Me.lblTravelNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTravelNo.Location = New System.Drawing.Point(84, 25)
        Me.lblTravelNo.Name = "lblTravelNo"
        Me.lblTravelNo.Size = New System.Drawing.Size(140, 23)
        Me.lblTravelNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Operation ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Customer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Part No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Spec"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(247, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Data Seq"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(251, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Rework"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(334, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Start Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(336, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Due Date"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(496, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "(mm/dd/yy)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(496, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "(mm/dd/yy)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(594, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Station ID"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(594, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Login ID"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(615, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Shift"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(600, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Entry ID"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(600, 157)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Start time"
        '
        'lblEndTime
        '
        Me.lblEndTime.AutoSize = True
        Me.lblEndTime.Location = New System.Drawing.Point(599, 194)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(48, 13)
        Me.lblEndTime.TabIndex = 17
        Me.lblEndTime.Text = "End time"
        '
        'lblOperationID
        '
        Me.lblOperationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOperationID.Location = New System.Drawing.Point(84, 60)
        Me.lblOperationID.Name = "lblOperationID"
        Me.lblOperationID.Size = New System.Drawing.Size(140, 23)
        Me.lblOperationID.TabIndex = 18
        '
        'lblCustNo
        '
        Me.lblCustNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustNo.Location = New System.Drawing.Point(84, 89)
        Me.lblCustNo.Name = "lblCustNo"
        Me.lblCustNo.Size = New System.Drawing.Size(456, 23)
        Me.lblCustNo.TabIndex = 19
        '
        'lblProdNo
        '
        Me.lblProdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProdNo.Location = New System.Drawing.Point(84, 121)
        Me.lblProdNo.Name = "lblProdNo"
        Me.lblProdNo.Size = New System.Drawing.Size(140, 23)
        Me.lblProdNo.TabIndex = 20
        '
        'lblProdName
        '
        Me.lblProdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProdName.Location = New System.Drawing.Point(230, 120)
        Me.lblProdName.Name = "lblProdName"
        Me.lblProdName.Size = New System.Drawing.Size(310, 23)
        Me.lblProdName.TabIndex = 21
        '
        'lblCustSpec
        '
        Me.lblCustSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustSpec.Location = New System.Drawing.Point(84, 157)
        Me.lblCustSpec.Name = "lblCustSpec"
        Me.lblCustSpec.Size = New System.Drawing.Size(456, 59)
        Me.lblCustSpec.TabIndex = 22
        '
        'lblTravelSeq
        '
        Me.lblTravelSeq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTravelSeq.Location = New System.Drawing.Point(299, 24)
        Me.lblTravelSeq.Name = "lblTravelSeq"
        Me.lblTravelSeq.Size = New System.Drawing.Size(29, 23)
        Me.lblTravelSeq.TabIndex = 23
        '
        'lblRework
        '
        Me.lblRework.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRework.Location = New System.Drawing.Point(299, 60)
        Me.lblRework.Name = "lblRework"
        Me.lblRework.Size = New System.Drawing.Size(29, 23)
        Me.lblRework.TabIndex = 24
        '
        'lblStartDate
        '
        Me.lblStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDate.Location = New System.Drawing.Point(390, 23)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(100, 23)
        Me.lblStartDate.TabIndex = 25
        '
        'lblDueDate
        '
        Me.lblDueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDueDate.Location = New System.Drawing.Point(390, 59)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(100, 23)
        Me.lblDueDate.TabIndex = 26
        '
        'lblStationID
        '
        Me.lblStationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStationID.Location = New System.Drawing.Point(665, 22)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(107, 23)
        Me.lblStationID.TabIndex = 27
        '
        'lblUserID
        '
        Me.lblUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUserID.Location = New System.Drawing.Point(665, 57)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(107, 23)
        Me.lblUserID.TabIndex = 28
        '
        'lblShift
        '
        Me.lblShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblShift.Location = New System.Drawing.Point(665, 89)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(107, 23)
        Me.lblShift.TabIndex = 29
        '
        'lblOperatorID
        '
        Me.lblOperatorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOperatorID.Location = New System.Drawing.Point(665, 119)
        Me.lblOperatorID.Name = "lblOperatorID"
        Me.lblOperatorID.Size = New System.Drawing.Size(107, 23)
        Me.lblOperatorID.TabIndex = 30
        '
        'lblStartTime
        '
        Me.lblStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartTime.Location = New System.Drawing.Point(665, 157)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(107, 23)
        Me.lblStartTime.TabIndex = 31
        '
        'Label18
        '
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Location = New System.Drawing.Point(665, 194)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 23)
        Me.Label18.TabIndex = 32
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRejQty)
        Me.GroupBox1.Controls.Add(Me.lblPassQty)
        Me.GroupBox1.Controls.Add(Me.lblInQty)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.lblFrame)
        Me.GroupBox1.Controls.Add(Me.lblDelay)
        Me.GroupBox1.Controls.Add(Me.lblNextStation)
        Me.GroupBox1.Controls.Add(Me.dgvReject)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 230)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(448, 294)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reject"
        '
        'lblRejQty
        '
        Me.lblRejQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRejQty.Location = New System.Drawing.Point(364, 254)
        Me.lblRejQty.Name = "lblRejQty"
        Me.lblRejQty.Size = New System.Drawing.Size(69, 23)
        Me.lblRejQty.TabIndex = 12
        '
        'lblPassQty
        '
        Me.lblPassQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPassQty.Location = New System.Drawing.Point(364, 218)
        Me.lblPassQty.Name = "lblPassQty"
        Me.lblPassQty.Size = New System.Drawing.Size(69, 23)
        Me.lblPassQty.TabIndex = 11
        '
        'lblInQty
        '
        Me.lblInQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInQty.Location = New System.Drawing.Point(364, 174)
        Me.lblInQty.Name = "lblInQty"
        Me.lblInQty.Size = New System.Drawing.Size(69, 29)
        Me.lblInQty.TabIndex = 10
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(297, 254)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 13)
        Me.Label27.TabIndex = 9
        Me.Label27.Text = "Reject qty"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(307, 218)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(47, 13)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Pass qty"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(307, 176)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(33, 13)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "In qty"
        '
        'lblFrame
        '
        Me.lblFrame.Font = New System.Drawing.Font("PMingLiU", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblFrame.ForeColor = System.Drawing.Color.Red
        Me.lblFrame.Location = New System.Drawing.Point(15, 263)
        Me.lblFrame.Name = "lblFrame"
        Me.lblFrame.Size = New System.Drawing.Size(150, 27)
        Me.lblFrame.TabIndex = 6
        Me.lblFrame.Text = "染黑供應商"
        '
        'lblDelay
        '
        Me.lblDelay.Font = New System.Drawing.Font("PMingLiU", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblDelay.ForeColor = System.Drawing.Color.Red
        Me.lblDelay.Location = New System.Drawing.Point(11, 204)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(150, 41)
        Me.lblDelay.TabIndex = 5
        Me.lblDelay.Text = "Delay"
        '
        'lblNextStation
        '
        Me.lblNextStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNextStation.Location = New System.Drawing.Point(6, 167)
        Me.lblNextStation.Name = "lblNextStation"
        Me.lblNextStation.Size = New System.Drawing.Size(155, 22)
        Me.lblNextStation.TabIndex = 2
        '
        'dgvReject
        '
        Me.dgvReject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReject.Location = New System.Drawing.Point(6, 24)
        Me.dgvReject.Name = "dgvReject"
        Me.dgvReject.RowTemplate.Height = 24
        Me.dgvReject.Size = New System.Drawing.Size(427, 133)
        Me.dgvReject.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvMatr)
        Me.GroupBox2.Location = New System.Drawing.Point(468, 230)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(304, 141)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Matr."
        '
        'dgvMatr
        '
        Me.dgvMatr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMatr.Location = New System.Drawing.Point(6, 24)
        Me.dgvMatr.Name = "dgvMatr"
        Me.dgvMatr.RowTemplate.Height = 24
        Me.dgvMatr.Size = New System.Drawing.Size(274, 107)
        Me.dgvMatr.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(472, 374)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 13)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Machine No"
        '
        'cboMacNo
        '
        Me.cboMacNo.FormattingEnabled = True
        Me.cboMacNo.Location = New System.Drawing.Point(474, 394)
        Me.cboMacNo.Name = "cboMacNo"
        Me.cboMacNo.Size = New System.Drawing.Size(168, 21)
        Me.cboMacNo.TabIndex = 36
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(652, 374)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "Glue Pressure"
        '
        'txtGluePsi
        '
        Me.txtGluePsi.Location = New System.Drawing.Point(654, 394)
        Me.txtGluePsi.Name = "txtGluePsi"
        Me.txtGluePsi.Size = New System.Drawing.Size(79, 20)
        Me.txtGluePsi.TabIndex = 38
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdbFrameReuse)
        Me.GroupBox3.Controls.Add(Me.rdbFrameNew)
        Me.GroupBox3.Location = New System.Drawing.Point(477, 425)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(294, 50)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Frame type"
        '
        'rdbFrameReuse
        '
        Me.rdbFrameReuse.AutoSize = True
        Me.rdbFrameReuse.Location = New System.Drawing.Point(128, 23)
        Me.rdbFrameReuse.Name = "rdbFrameReuse"
        Me.rdbFrameReuse.Size = New System.Drawing.Size(58, 17)
        Me.rdbFrameReuse.TabIndex = 1
        Me.rdbFrameReuse.TabStop = True
        Me.rdbFrameReuse.Text = "ReUse"
        Me.rdbFrameReuse.UseVisualStyleBackColor = True
        '
        'rdbFrameNew
        '
        Me.rdbFrameNew.AutoSize = True
        Me.rdbFrameNew.Location = New System.Drawing.Point(6, 23)
        Me.rdbFrameNew.Name = "rdbFrameNew"
        Me.rdbFrameNew.Size = New System.Drawing.Size(47, 17)
        Me.rdbFrameNew.TabIndex = 0
        Me.rdbFrameNew.TabStop = True
        Me.rdbFrameNew.Text = "New"
        Me.rdbFrameNew.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 550)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(19, 13)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "F1"
        '
        'butTravel
        '
        Me.butTravel.Location = New System.Drawing.Point(27, 550)
        Me.butTravel.Name = "butTravel"
        Me.butTravel.Size = New System.Drawing.Size(75, 25)
        Me.butTravel.TabIndex = 41
        Me.butTravel.Text = "Travel"
        Me.butTravel.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(129, 550)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(19, 13)
        Me.Label21.TabIndex = 42
        Me.Label21.Text = "F5"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(404, 550)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(19, 13)
        Me.Label22.TabIndex = 43
        Me.Label22.Text = "F8"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(545, 550)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(19, 13)
        Me.Label23.TabIndex = 44
        Me.Label23.Text = "F9"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(672, 550)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 13)
        Me.Label24.TabIndex = 45
        Me.Label24.Text = "ESC"
        '
        'ButDone
        '
        Me.ButDone.Location = New System.Drawing.Point(152, 550)
        Me.ButDone.Name = "ButDone"
        Me.ButDone.Size = New System.Drawing.Size(75, 25)
        Me.ButDone.TabIndex = 46
        Me.ButDone.Text = "Done"
        Me.ButDone.UseVisualStyleBackColor = True
        '
        'butSerial
        '
        Me.butSerial.Location = New System.Drawing.Point(427, 550)
        Me.butSerial.Name = "butSerial"
        Me.butSerial.Size = New System.Drawing.Size(75, 25)
        Me.butSerial.TabIndex = 47
        Me.butSerial.Text = "Cary60"
        Me.butSerial.UseVisualStyleBackColor = True
        '
        'butWaitOp
        '
        Me.butWaitOp.Location = New System.Drawing.Point(567, 550)
        Me.butWaitOp.Name = "butWaitOp"
        Me.butWaitOp.Size = New System.Drawing.Size(75, 25)
        Me.butWaitOp.TabIndex = 48
        Me.butWaitOp.Text = "Wait List"
        Me.butWaitOp.UseVisualStyleBackColor = True
        '
        'butExit
        '
        Me.butExit.Location = New System.Drawing.Point(697, 550)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(75, 25)
        Me.butExit.TabIndex = 49
        Me.butExit.Text = "Exit"
        Me.butExit.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 587)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 50
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DPopMenu})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 26)
        '
        'DPopMenu
        '
        Me.DPopMenu.Name = "DPopMenu"
        Me.DPopMenu.Size = New System.Drawing.Size(117, 22)
        Me.DPopMenu.Text = "Del Row"
        '
        'frmGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 609)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butWaitOp)
        Me.Controls.Add(Me.butSerial)
        Me.Controls.Add(Me.ButDone)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.butTravel)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtGluePsi)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboMacNo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.lblOperatorID)
        Me.Controls.Add(Me.lblShift)
        Me.Controls.Add(Me.lblUserID)
        Me.Controls.Add(Me.lblStationID)
        Me.Controls.Add(Me.lblDueDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.lblRework)
        Me.Controls.Add(Me.lblTravelSeq)
        Me.Controls.Add(Me.lblCustSpec)
        Me.Controls.Add(Me.lblProdName)
        Me.Controls.Add(Me.lblProdNo)
        Me.Controls.Add(Me.lblCustNo)
        Me.Controls.Add(Me.lblOperationID)
        Me.Controls.Add(Me.lblEndTime)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTravelNo)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGeneral"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvReject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvMatr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblTravelNo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblEndTime As Label
    Friend WithEvents lblOperationID As Label
    Friend WithEvents lblCustNo As Label
    Friend WithEvents lblProdNo As Label
    Friend WithEvents lblProdName As Label
    Friend WithEvents lblCustSpec As Label
    Friend WithEvents lblTravelSeq As Label
    Friend WithEvents lblRework As Label
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblDueDate As Label
    Friend WithEvents lblStationID As Label
    Friend WithEvents lblUserID As Label
    Friend WithEvents lblShift As Label
    Friend WithEvents lblOperatorID As Label
    Friend WithEvents lblStartTime As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvReject As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvMatr As DataGridView
    Friend WithEvents Label17 As Label
    Friend WithEvents cboMacNo As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtGluePsi As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rdbFrameReuse As RadioButton
    Friend WithEvents rdbFrameNew As RadioButton
    Friend WithEvents Label20 As Label
    Friend WithEvents butTravel As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents ButDone As Button
    Friend WithEvents butSerial As Button
    Friend WithEvents butWaitOp As Button
    Friend WithEvents butExit As Button
    Friend WithEvents lblRejQty As Label
    Friend WithEvents lblPassQty As Label
    Friend WithEvents lblInQty As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lblFrame As Label
    Friend WithEvents lblDelay As Label
    Friend WithEvents lblNextStation As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DPopMenu As ToolStripMenuItem
End Class
