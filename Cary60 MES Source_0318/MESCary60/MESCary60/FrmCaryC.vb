Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Threading

Imports CaryDN
Imports CaryDN.SCary32
Public Class FrmCaryC
    Delegate Sub StatusEventDelegate(ByVal args As StatusEventArgs)
    Delegate Sub DataEventDelegate(ByVal args As DataEventArgs)
    Delegate Sub ValueInEventDelegate(ByVal args As ValueInEventArgs)

    Dim m_instrument As CaryDN.InstrumentEx
    Dim Di As Integer
    Dim RefC As Boolean
    Dim OnData(0 To 500, 0 To 4) As Single
    Dim rData(320, 1) As Single
    Public aData(320, 1) As Single
    Public CaryMassage As String
    Public FCStatus As String
    Dim LoadEvent As Boolean
    ' Applications will only run in the folder [drive]\Program files\Agilent\Cary WinUV\
    ' Attempts to run apps else where will only result in tears.
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub OnValueInReceived(ByVal sender As Object, ByVal args As ValueInEventArgs)
        If Me.InvokeRequired Then
            Dim d As New ValueInEventDelegate(AddressOf DoShowValueIn)
            Me.Invoke(d, args)
        Else
            DoShowValueIn(args)
        End If
    End Sub

    Private Sub DoShowValueIn(ByVal args As ValueInEventArgs)
        If (args.ParameterID = InstrumentParameterID.RESP_WAVELENGTH) Then
            txtValueIn.Text = String.Format("Wavelength = {0:####.#}", args.FParam)
            Return
        End If
        'TextBox1.Text = args.Value
        txtValueIn.Text = String.Format("{0} = {1}", args.ParameterID, args.Value)
    End Sub

    Private Sub OnStatusChanged(ByVal sender As Object, ByVal args As StatusEventArgs)
        If Me.InvokeRequired Then
            Dim d As New StatusEventDelegate(AddressOf DoShowStatus)
            Me.Invoke(d, args)
        Else
            DoShowStatus(args)
        End If
    End Sub

    Private Sub OnDataReceived(ByVal sender As Object, ByVal args As DataEventArgs)
        If Me.InvokeRequired Then
            Dim d As New DataEventDelegate(AddressOf DoShowData)
            Me.Invoke(d, args)
        Else

            DoShowData(args)

        End If
    End Sub

    Private Sub OnlineChanged(ByVal sender As Object, ByVal args As BoolValueEventArgs)
        If (args.Value) Then
            m_instrument.Stop()
            m_instrument.SubSetup(SubSetupCode.SUB_PROM_MODEL)
        End If
    End Sub

    Private Sub DoShowStatus(ByVal args As StatusEventArgs)
        Dim msg As String = CaryDN.InstrumentStatusCode.ToString(args.Value)
        CaryMassage = msg
        FCStatus = msg
    End Sub

    Private Sub OnConnecting(ByVal sender As Object, ByVal args As Object)
        CaryMassage = "Connecting"
    End Sub

    Private Sub OnConnected(ByVal sender As Object, ByVal args As Object)
        CaryMassage = "Connected"
    End Sub

    Private Sub OnDisconnected(ByVal sender As Object, ByVal args As Object)
        CaryMassage = "Disconnected"
    End Sub

    Private Sub OnInstrumentError(ByVal sender As Object, ByVal args As ErrorEventArgs)
        CaryMassage = args.GetErrorMessage()
    End Sub

    Private Sub DoShowData(ByVal args As DataEventArgs)
        Dim abs As Double = 9.999
        If args.Wavelength = 0 Or args.Wavelength > 100 Then
            'If args.Wavelength < 501 And args.Wavelength > 190 Then
            Di = Di + 1
            OnData(Di, 1) = args.Abs
            OnData(Di, 2) = args.Wavelength
            OnData(Di, 3) = args.FrontBeam
            OnData(Di, 4) = args.RearBeam
            ''If Di = 1 Then
            'abs1.Text = args.Abs
            'Wav1.Text = args.Wavelength
            'Fb1.Text = args.FrontBeam
            'Rb1.Text = args.RearBeam
            ''End If
            'txtMessage.Text = Di
        End If
        'If args.FrontBeam > 0 Then
        '    abs = -Math.Log10(args.FrontBeam)

        'End If

        'txtAbs.Text = String.Format("{0:###.###}", abs)
        'txtWavelength.Text = String.Format("{0:###.#}", args.Wavelength)


    End Sub
    Public Sub Setup()
        m_instrument.GetDefaultSetup()

        m_instrument.BeamMode = BeamMode.DoubleAutoSelect
        'm_instrument.UvVisSlitWidth = 1
        m_instrument.UvVisSlitWidth = 1
        m_instrument.SlitHeight = SlitHeight.Full
        m_instrument.UvVisInterval = -1 * Val(frmCary60.txtNM.Text)
        'm_instrument.UvVisWaveNumberInterval = 10
        'm_instrument.UvVisWaveNumberInterval = 10
        m_instrument.UvVisAveraging = 2
        'm_instrument.UvVisAveraging = 1
        m_instrument.Wavelength = 500
        m_instrument.IsVisibleLampOn = True
        m_instrument.ScanStart = 510
        m_instrument.ScanStop = 190
        m_instrument.SourceMode = SourceMode.Auto
        m_instrument.ScanMode = ScanMode.Wavelength
    End Sub

    Private Sub FrmCaryC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Thread.CurrentThread.Name = "Main"
        m_instrument = New CaryDN.InstrumentEx()
        m_instrument.Registration.Key = "A7405-43748-8CC19-CC176-67F60"
        AddHandler m_instrument.DataReceived, AddressOf OnDataReceived
        AddHandler m_instrument.Error, AddressOf OnInstrumentError
        AddHandler m_instrument.Connecting, AddressOf OnConnecting
        AddHandler m_instrument.Connected, AddressOf OnConnected
        AddHandler m_instrument.Disconnected, AddressOf OnDisconnected
        AddHandler m_instrument.StatusChanged, AddressOf OnStatusChanged
        AddHandler m_instrument.ValueInReceived, AddressOf OnValueInReceived
        AddHandler m_instrument.OnlineChanged, AddressOf OnlineChanged


        m_instrument.Connect()

        Setup()
        m_instrument.WaitNotBusy()
        LoadEvent = True

        Timer1.Interval = 5000
        Timer1.Enabled = True

    End Sub
    Public Sub CaryMeasure()
        m_instrument.ScanStart = 510
        m_instrument.ScanStop = 190
        m_instrument.ScanMode = ScanMode.Wavelength
        Di = 0
        RefC = False
        StartScan()

    End Sub
    Sub StartScan()
        Dim m As Integer
        Dim n As Integer
        If m_instrument.IsBusy Then
            m_instrument.Stop()
        End If

        If m_instrument.IsScanning Then
            m_instrument.Stop()
            m_instrument.WaitNotScanning()
        End If
        Di = 0
        m_instrument.ScanMode = ScanMode.Wavelength
        m = m_instrument.ScanStart - m_instrument.ScanStop
        n = (m + 1) / Math.Abs(m_instrument.UvVisInterval)
        ReDim OnData(n + 1, 4)

        m_instrument.Setup()
        m_instrument.WaitNotBusy()
        'abs2.Text = m_instrument.ScanStart
        'wav2.Text = m_instrument.ScanStop
        'm_instrument.Setup()
        'm_instrument.WaitNotBusy()
        m_instrument.Start()

        'System.Threading.Thread.Sleep(2000)
        m_instrument.WaitNotBusy()
        m_instrument.WaitNotScanning()
        'Debug.Print(Now)
        'DelayTime(1.5)
        Thread.Sleep(1.5)
        ' Debug.Print(Now)
        'Debug.Print(Di)
        OutFile(OnData, "ON")
        FormatCary()
        OutFile(aData, "A")
        If RefC Then
            RefData()
            OutFile(rData, "R")
        Else
            BaseLine()
            OutFile(aData, "T")
        End If
        'Timer1.Interval = 1000
        'Timer1.Enabled = True
        'System.Threading.Thread.Sleep(5000)
        'm = 0
        'Do
        '    System.Threading.Thread.Sleep(500)
        '    m = m + 1
        '    m_instrument.WaitNotScanning()
        'Loop Until m >= 5

        ''TextBox2.Text = "AAAAAAAAA"
        'OutFile(OnData, "ON")
        'FormatCary()
        'OutFile(aData, "A")
        'If RefC Then
        '    RefData()
        '    OutFile(rData, "R")
        'Else
        '    BaseLine()
        '    OutFile(aData, "T")
        'End If

        'SetPic()
    End Sub

    Private Sub FormatCary()
        Dim i As Integer
        Dim w As Integer
        Dim j As Integer
        Dim newData(320, 1) As Single

        j = 0
        w = 510
        For i = 1 To UBound(OnData, 1)
            If (i <= UBound(OnData, 1) Or i = 1) And w >= 190 And (OnData(i, 2) = 0 Or OnData(i, 2) > 100) Then
                Do
                    newData(j, 0) = w
                    newData(j, 1) = Interpolate(Int(newData(j, 0)), i)
                    j = j + 1
                    w = w - 1

                Loop Until w >= OnData(i, 2) Or w <= OnData(i + 1, 2) Or w < 190

            End If
        Next

        ReDim aData(UBound(newData), 1)
        For i = 0 To UBound(newData)
            aData(UBound(newData) - (i), 0) = newData(i, 0)
            aData(UBound(newData) - (i), 1) = newData(i, 1)
        Next

    End Sub
    Private Function Interpolate(w As Integer, index As Integer) As Single
        Dim i As Integer
        Dim m As Single
        Dim mC As Single

        i = index
        Do While OnData(i, 2) > w
            If i >= UBound(OnData, 1) Then Exit Do
            i = i + 1
        Loop

        If OnData(i, 2) < w And i > 1 Then
            i = i - 1
        End If
        If i = UBound(OnData) Then i = i - 1

        If OnData(i, 2) = w Then
            Interpolate = OnData(i, 3)
        Else
            m = (OnData(i, 3) - OnData(i + 1, 3)) / (OnData(i, 2) - OnData(i + 1, 2))
            mC = OnData(i + 1, 3) - (m * OnData(i + 1, 2))
            Interpolate = (m * w) + mC

        End If

    End Function
    Private Sub RefData()
        Dim i As Integer
        ReDim rData(UBound(aData), 1)
        For i = 0 To UBound(aData)
            rData(i, 0) = aData(i, 0)
            rData(i, 1) = aData(i, 1)
        Next
    End Sub
    Private Sub BaseLine()
        Dim i As Integer
        For i = 0 To UBound(aData)
            'rData(i, 0) = aData(i, 0)
            aData(i, 1) = aData(i, 1) / rData(i, 1)
        Next
        If frmCary60.txtNM.Text > 1 Then
            If aData(58, 1) < aData(59, 1) Then
                aData(58, 1) = (aData(58, 1) + aData(59, 1)) / 2
            End If
            If aData(58, 1) < aData(57, 1) Then
                aData(58, 1) = (aData(58, 1) + aData(57, 1)) / 2
            End If
        End If
    End Sub
    Public Sub CaryReference()
        m_instrument.ScanStart = 510
        m_instrument.ScanStop = 190
        m_instrument.ScanMode = ScanMode.Wavelength
        Di = 0
        RefC = True
        StartScan()
    End Sub

    Private Sub FrmCaryC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(m_instrument) Then
            m_instrument.Stop()
            m_instrument.Disconnect()
            m_instrument.Dispose()
            m_instrument = Nothing
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Dim Film As String = "", status As String = ""
        'Dim avg10 As Single, avg100 As Single

        'Dim j As Integer
        Timer1.Enabled = False
        If LoadEvent Then
            LoadEvent = False
            m_instrument.Stop()
            m_instrument.Read(500)

        Else
            OutFile(OnData, "ON")
            FormatCary()
            OutFile(aData, "A")
            If RefC Then
                RefData()
                OutFile(rData, "R")
            Else
                BaseLine()
                OutFile(aData, "T")
            End If

        End If
        CaryBusy = False
    End Sub
    Public Sub OutFile(mdata(,) As Single, Filna As String)
        Dim FileNum As Integer
        Dim strTemp As String = vbEmpty
        'Dim strSplit() As String
        Dim i As Integer = 0
        Dim j As Integer

        FileNum = FreeFile()
        FileOpen(FileNum, "C:\Tmp\CaryTest" & Filna & ".txt", OpenMode.Output)

        For i = 0 To UBound(mdata)
            strTemp = ""
            For j = 0 To UBound(mdata, 2)
                strTemp = strTemp & mdata(i, j) & ","
            Next j
            '& mdata(i, 1) & "," & mdata(i, 2) & "," & mdata(i, 3) & "," & mdata(i, 4)
            PrintLine(FileNum, strTemp)

        Next i

        FileClose(FileNum)

    End Sub

    Private Sub FrmCaryC_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Not IsNothing(m_instrument) Then
            m_instrument.Stop()
            m_instrument.Disconnect()
            m_instrument.Dispose()
            m_instrument = Nothing
        End If

    End Sub
End Class