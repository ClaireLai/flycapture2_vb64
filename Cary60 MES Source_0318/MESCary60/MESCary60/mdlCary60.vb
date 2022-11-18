Module mdlCary60
    Dim Peaks(50, 2) As Single, NewPeaks(40, 2) As Single, Intro(30, 2) As Single, Mt(25) As Single
    Dim SavePeak(2, 2) As Single
    Public Sub FLMCHK(ByRef Film As String, ByRef status As String, ByRef AVG100 As Single, ByRef AVG10 As Single,
                       ByRef retThickness As Single, TansData(,) As Single)
        Dim TOT200 As Single, TOT350 As Single, TOT100 As Single, TOT400 As Single, AVG400 As Single
        Dim U As Integer
        Dim i As Integer
        Dim actual As Integer
        Dim Thickness As Single, deriation As Single
        Dim TOTAVG As Single, AVGA As Single, AVGB As Single, AVGC As Single

        'On Error GoTo ErrPo
        TOT200 = 0
        U = 0
        For i = 10 To 59
            U = U + 1
            TOT200 = TOT200 + TansData(i, 1)
        Next i
        AVG100 = TOT200 / U
        If AVG100 > 0.99 Then
        Else
            peakchk(160, 310, 0.98, actual, 6, TansData)        '350 to 500nm   '½¤«p 93.5.27--·|¶Ç¦^ Thickness
            If actual = -100 Then
                MsgBox("The peak1 error,Please Measure again")
                Exit Sub
            End If 'Err.Raise vbObjectError, , "THE Peak1 Error, Please Measure Again"
            THICK(actual, Thickness, deriation)                      '½¤«p 93.5.27
            retThickness = String.Format(Thickness / 1000, "####.0000")
            '          Open "c:\Peak.txt" For Append As #2
            '          Print #2, Chr(13) + Chr(10) & Chr(13) + Chr(10)
            '          For i = 161 To 311
            '          Print #2, TansData(i, 1) & "," & TansData(i, 2)
            '          Next i
            '          Print #2, actual
            '          For i = 1 To actual
            '          Print #2, NewPeaks(i, 1) & "," & NewPeaks(i, 2)
            '          Next i
            '          Print #2, retThickness
            '          Close #2
        End If

        Select Case AVG100

            Case Is > 0.99        ' ---------------------  CHECK BLANK
                Film$ = "BLK"
                status = "BLK"
                Exit Sub

            Case Is > 0.9         ' ---------------------  CHECK FILM 601
                peakchk(10, 260, 0.95, actual, 8, TansData)          '200 to 450nm
                Select Case actual
                    Case Is > 8
                        Film = "602"
                        If TansData(58, 1) > 0.993 And TansData(175, 1) > 0.99 Then
                            status = "PAS"
                        Else
                            'Print Chr$(7): Print Chr$(7)
                            status = "REJ"
                        End If
                        Exit Sub
                    Case 6 To 8
                        Film = "603"
                        If TansData(58, 1) > 0.992 And TansData(175, 1) > 0.992 Then
                            status = "PAS"
                        ElseIf TansData(3, 1) > 0.965 And actual = 6 Then
                            Film = "704"
                            If TansData(3, 1) > 0.99 Then status = "PAS"
                        Else
                            'Print Chr$(7): Print Chr$(7)
                            status = "REJ"
                        End If
                        Exit Sub
                    Case 4 To 5
                        Film = "703"
                        If TansData(3, 1) >= 0.99 And TansData(58, 1) > 0.99 Then
                            status = "PAS"
                        Else
                            'Print Chr$(7): Print Chr$(7)
                            status = "REJ"
                        End If
                        Exit Sub
                End Select
            Case Is > 0.5         ' ---------------------  CHECK FILM 200, 201, 203
                TOT200 = 0
                U = 0
                For i = 145 To 205                '335 to 395nm
                    U = U + 1
                    TOT200 = TOT200 + TansData(i, 1)
                Next i
                AVG10 = TOT200 / U

                Select Case AVG10

                    Case Is > 0.935               ' -----------  CHECK FILM 201

                        peakchk(90, 190, 0.97, actual, 6, TansData)             '280 to 380nm
                        If actual > 4 Then
                            For i = 90 To 190   '------------  CHECK FILM 203  (280 to 380nm)
                                If TansData(i, 1) < 0.9 Then
                                    'Print Chr$(7): Print Chr$(7)
                                    Film = "203"
                                    status = "REJ"
                                    Exit Sub
                                End If
                            Next i
                            Film = "203"
                            status = "PAS"
                            Exit Sub

                        Else 'actual% is less than or equal to 4

                            If TansData(175, 1) > 0.987 Then        '365nm
                                status = "PAS"
                                Film = "201"
                                Exit Sub
                            Else
                                'Print Chr$(7): Print Chr$(7)
                                Film = "201"
                                status = "REJ"
                                Exit Sub
                            End If
                        End If

                    Case Is <= 0.935               ' -----------  CHECK FILM 200
                        For i = 90 To 260            '280 to 450nm
                            If TansData(i, 1) < 0.8 Then
                                'Print Chr$(7): Print Chr$(7)
                                Film = "200"
                                status = "REJ"
                                Exit Sub
                            End If
                        Next i
                        status = "PAS"
                        Film = "200"
                        Exit Sub


                End Select

            Case Is > 0.2
                peakchk(160, 310, 0.98, actual, 6, TansData)         '350 to 500nm   '½¤«p 93.5.27--·|¶Ç¦^ Thickness
                THICK(actual, Thickness, deriation)                      '½¤«p 93.5.27
                '  retThickness = Thickness / 1000

                TOT200 = 0
                U = 0
                For i = 145 To 205                '335 to 395nm
                    U = U + 1
                    TOT200 = TOT200 + TansData(i, 1)
                Next i
                AVG10 = TOT200 / U
                If AVG10 > 0.99 Then                '------------- CHECK FILM 202

                    If TansData(175, 1) > 0.99 Then         '365nm
                        Film = "202"
                        status = "PAS"
                        Exit Sub
                    Else
                        'Print Chr$(7): Print Chr$(7)
                        status = "REJ"
                        Film = "202"
                        Exit Sub
                    End If
                Else
                    U = 0
                    TOT350 = 0
                    For i = 160 To 310           '350 to 500nm
                        U = U + 1
                        TOT350 = TOT350 + TansData(i, 1)
                    Next i
                    AVG10 = TOT350 / U

                    Select Case AVG10

                        Case Is > 0.95
                            peakchk(145, 259, 0.99, actual, 9, TansData)            '355 to 449nm

                            Select Case actual
                                Case 3                          '------- CHECK FILM 122
                                    SavePeak(1, 1) = NewPeaks(1, 1)
                                    SavePeak(1, 2) = NewPeaks(1, 2)
                                    SavePeak(2, 1) = NewPeaks(3, 1)
                                    SavePeak(2, 2) = NewPeaks(3, 2)
                                    If TansData(175, 1) >= 0.993 And TansData(246, 2) >= 0.993 Then
                                        Film = "122"
                                        status = "PAS"
                                        Exit Sub
                                    Else
                                        ' Print Chr$(7): Print Chr$(7)
                                        Film = "122"
                                        status = "REJ"
                                        Exit Sub
                                    End If
                                Case 2                          '------- CHECK FILM 111, 113
                                    peakchk(165, 295, 0.99, actual, 10, TansData)        '355 to 485nm

                                    Select Case actual
                                        Case 2                       '------- CHECK FILM 111
                                            If Thickness / 1000 > 0.95 Then
                                                SavePeak(1, 1) = NewPeaks(1, 1)
                                                SavePeak(1, 2) = NewPeaks(1, 2)

                                                If TansData(246, 1) > 0.995 Then
                                                    Film = "111"
                                                    status = "PAS"
                                                    Exit Sub
                                                Else
                                                    ' Print Chr$(7): Print Chr$(7)
                                                    Film = "111"
                                                    status = "REJ"
                                                    Exit Sub
                                                End If
                                            Else
                                                SavePeak(1, 1) = NewPeaks(1, 1)
                                                SavePeak(1, 2) = NewPeaks(1, 2)
                                                SavePeak(2, 1) = NewPeaks(2, 1)
                                                SavePeak(2, 2) = NewPeaks(2, 2)

                                                If TansData(175, 1) > 0.99 And TansData(246, 1) > 0.99 Then
                                                    Film = "172"
                                                    status = "PAS"
                                                    Exit Sub
                                                Else
                                                    Film = "172"
                                                    status = "REJ"
                                                    Exit Sub
                                                End If
                                            End If
                                        Case 3                       '--------- CHECK FILM 113
                                            SavePeak(1, 1) = NewPeaks(1, 1)
                                            SavePeak(1, 2) = NewPeaks(1, 2)
                                            If TansData(175, 1) >= 0.99 Then
                                                Film = "113"
                                                status = "PAS"
                                                Exit Sub
                                            Else
                                                ' Print Chr$(7): Print Chr$(7)
                                                Film = "113"
                                                status = "REJ"
                                                Exit Sub
                                            End If
                                    End Select

                                Case Else
                                    For i = 210 To 270                '400 to 460nm
                                        If TansData(i, 1) < 0.98 Then
                                            ' Print Chr$(7): Print Chr$(7)
                                            Film = "205"
                                            status = "REJ"
                                            Exit Sub
                                        End If
                                    Next i
                                    If TansData(246, 1) > 0.99 Then            '436nm
                                        status = "PAS"
                                    Else
                                        status = "REJ"
                                    End If
                                    Film = "205"
                                    Exit Sub

                            End Select

                        Case Is < 0.95           ' ---------------  CHECK FILM 110, 170
                            peakchk(135, 309, 0.99, actual, 8, TansData)            '325 to 499nm

                            Select Case actual
                                Case 3                       '------- CHECK FILM 110
                                    SavePeak(1, 1) = NewPeaks(3, 1)
                                    SavePeak(1, 2) = NewPeaks(3, 2)
                                    If TansData(246, 1) > 0.99 Then            '436nm
                                        Film = "110"
                                        status = "PAS"
                                        Exit Sub
                                    Else
                                        ' Print Chr$(7): Print Chr$(7)
                                        Film = "110"
                                        status = "REJ"
                                        Exit Sub
                                    End If

                                Case 2                       ' -------- CHECK FILM 170
                                    SavePeak(1, 1) = NewPeaks(1, 1)
                                    SavePeak(1, 2) = NewPeaks(1, 2)
                                    SavePeak(2, 1) = NewPeaks(2, 1)
                                    SavePeak(2, 2) = NewPeaks(2, 2)
                                    If TansData(246, 1) > 0.99 And TansData(175, 1) > 0.99 Then
                                        Film = "170"
                                        status = "PAS"
                                        Exit Sub
                                    Else
                                        '  Print Chr$(7): Print Chr$(7)
                                        Film = "170"
                                        status = "REJ"
                                        Exit Sub
                                    End If

                                Case Else
                                    Film = "REJ"
                                    Exit Sub

                            End Select
                    End Select
                End If

            Case Is > 0.09      ' ------------------------- CHECK FILM 100, 101, 102
                TOT100 = 0
                U = 0
                For i = 160 To 260                '350 to 450nm
                    U = U + 1
                    TOT100 = TOT100 + TansData(i, 1)
                Next i
                AVG10 = TOT100 / U

                Select Case AVG10

'     CASE IS > .986                  ' -----------  CHECK FILM 106
'          IF TRANSRAW(176, 2) >= .99 AND TRANSRAW(247, 2) >= .99 THEN
'             Film$ = "106"
'             Status$ = "PAS"
'             EXIT SUB
'          ELSE
'             Film$ = "106"
'             Status$ = "REJ"
'             EXIT SUB
'          END IF

                    Case Is > 0.96                 ' -----------  CHECK FILM 102, OR 106
                        TOT400 = 0
                        U = 0
                        For i = 200 To 219              '390 to 409nm
                            U = U + 1
                            TOT400 = TOT400 + TansData(i, 1)
                        Next i
                        AVG400 = TOT400 / U

                        If AVG400 > 0.99 Then           '-------------- CHECK FILM 106
                            If TansData(175, 1) >= 0.99 And TansData(246, 1) >= 0.99 Then
                                Film = "106"
                                status = "PAS"
                                Exit Sub
                            Else
                                Film = "106"
                                status = "REJ"
                                Exit Sub
                            End If

                        Else                         '-------------- CHECK FILM 102
                            For i = 170 To 250
                                If TansData(i, 1) < 0.95 Then
                                    ' Print Chr$(7): Print Chr$(7)
                                    Film = "102"
                                    status = "REJ"
                                    Exit Sub
                                End If
                            Next i
                            Film = "102"
                            status = "PAS"
                            Exit Sub
                        End If

                    Case Is > 0.93                 ' ------------  CHECK FILM 101
                        For i = 170 To 250           '360 to 440nm
                            If TansData(i, 1) < 0.9 Then
                                ' Print Chr$(7): Print Chr$(7)
                                Film = "101"
                                status = "REJ"
                                Exit Sub
                            End If
                        Next i
                        Film = "101"
                        status = "PAS"
                        Exit Sub

                    Case Is > 0.88                ' -------------  CHECK FILM 100
                        For i = 160 To 260           '350 to 450nm
                            If TansData(i, 1) < 0.8 Then
                                '  Print Chr$(7): Print Chr$(7)
                                Film = "100"
                                status = "REJ"
                                Exit Sub
                            End If
                        Next i
                        status = "PAS"
                        Film = "100"
                        Exit Sub

                    Case Is < 0.88
                        Film = "REJ"
                        Exit Sub

                End Select

            Case Is < 0.09        ' -----------------------   CHECK FILM 104, 105

                U = 0
                TOT350 = 0
                For i = 103 To 159                '299 to 349nm
                    U = U + 1
                    TOT350 = TOT350 + TansData(i, 1)
                Next i
                AVG10 = TOT350 / U

                If AVG10 >= 0.87 Then                 ' ------- CHECK FILM 105
                    Film = "105"
                    For i = 170 To 229           '360 to 419nm
                        If TansData(i, 1) < 0.98 Then
                            '  Print Chr$(7): Print Chr$(7)
                            Film = "105"
                            status = "REJ"
                            Exit Sub
                        End If
                    Next i
                    status = "PAS"
                    Exit Sub
                End If

                U = 0           ' ------- from Wave 360 - 390
                TOTAVG = 0
                For i = 170 To 199               '360 to 389nm
                    U = U + 1
                    TOTAVG = TOTAVG + TansData(i, 1)
                Next i
                AVGA = TOTAVG / U

                U = 0           ' ------- from Wave 400 - 410
                TOTAVG = 0
                For i = 210 To 219               '400 to 409nm
                    U = U + 1
                    TOTAVG = TOTAVG + TansData(i, 1)
                Next i
                AVGB = TOTAVG / U

                U = 0           ' ------- from Wave 420 - 450
                TOTAVG = 0
                For i = 230 To 259                '420 to 449nm
                    U = U + 1
                    TOTAVG = TOTAVG + TansData(i, 1)
                Next i
                AVGC = TOTAVG / U

                If AVGA < 0.993 And AVGB > 0.993 And AVGC < 0.993 Then '-- 104H
                    Film = "104H"

                    For i = 195 To 229             '385 to 419nm
                        If TansData(i, 1) < 0.99 Then
                            'Print Chr$(7): Print Chr$(7)
                            status = "REJ"
                            Exit Sub
                        End If
                    Next i
                    If TansData(215, 1) >= 0.994 Then       '405nm
                        status = "PAS"
                    Else
                        status = "REJ"
                    End If
                    Exit Sub
                End If

                If AVGA < 0.99 And AVGB > 0.99 And AVGC > 0.993 Then '----- FILM 104
                    'AdjTrans pFTRAN104

                    Film = "104"
                    For i = 210 To 259             '400 to 449nm
                        If TansData(i, 1) < 0.99 Then
                            ' Print Chr$(7): Print Chr$(7)
                            status = "REJ"
                            Exit Sub
                        End If
                    Next i
                    If TansData(246, 1) >= 0.994 And TansData(215, 1) > 0.99 Then
                        status = "PAS"
                    Else
                        'Print Chr$(7): Print Chr$(7)
                        status = "REJ"
                    End If
                    Exit Sub

                End If


        End Select
        Exit Sub
        'ErrPo:
        '        MsgBox Err.Number & "-" & Err.Description
        ''     peakchk 161, 311, 0.98, actual, 6         '350 to 500nm   '½¤«p 93.5.27--·|¶Ç¦^ Thickness
        '        '     THICK actual, Thickness, deriation                        '½¤«p 93.5.27
        '        '    retThickness = Thickness
    End Sub
    Public Sub peakchk(startindex As Integer, stopindex As Integer, min As Single, ByRef actual As Integer, dist As Integer, TansData(,) As Single)
        Dim K As Integer
        Dim i As Integer, j As Integer
        Dim SaveWave(1, 2) As Single
        'Wavelength=startindex or stopindex + 190
        'actual= number of peaks between start and stop index

        K = 1
        For i = startindex To stopindex - 2
            If TansData(i + 1, 1) >= TansData(i, 1) Then
                If TansData(i + 1, 1) >= TansData(i + 2, 1) And TansData(i + 1, 1) >= min Then
                    Peaks(K, 1) = TansData(i + 1, 0)
                    Peaks(K, 2) = TansData(i + 1, 1)
                    K = K + 1
                End If
            End If
        Next
        actual = K - 1

        SaveWave(1, 1) = Peaks(1, 1)
        SaveWave(1, 2) = Peaks(1, 2)
        j = 1
        For i = 1 To actual - 1
            If Peaks(i + 1, 1) > SaveWave(1, 1) + dist Then
                NewPeaks(j, 1) = SaveWave(1, 1)
                NewPeaks(j, 2) = SaveWave(1, 2)
                SaveWave(1, 1) = Peaks(i + 1, 1)
                SaveWave(1, 2) = Peaks(i + 1, 2)
                j = j + 1
            Else
                If Peaks(i + 1, 2) >= SaveWave(1, 2) Then
                    SaveWave(1, 1) = Peaks(i + 1, 1)
                    SaveWave(1, 2) = Peaks(i + 1, 2)
                End If
            End If
        Next
        If j = 1 Then Exit Sub
        If (SaveWave(1, 1) - NewPeaks(j - 1, 1)) > dist Then
            NewPeaks(j, 1) = SaveWave(1, 1)
            NewPeaks(j, 2) = SaveWave(1, 2)
        Else
            j = j - 1
        End If
        actual = j

    End Sub
    Public Sub THICK(actual As Integer, ByRef Thickness As Single, ByRef deriation As Single)
        Dim i As Integer, j As Integer, increase As Integer, tto As Single
        Dim mk As Integer, mkdist As Integer, mkmin As Integer
        Dim avto As Single
        Dim savemin As Single
        ' Get The N1 to Nn
        'THICKNESS= (newpeaks(1,1) * newpeaks(actual,1) * (actual-1) / (3* (newpeaks(actual,1)-newpeak(1,1)))

        For i = 1 To actual
            If NewPeaks(i, 1) > 350 And NewPeaks(i, 1) < 410 Then
                Intro(i, 1) = ((410 - NewPeaks(i, 1)) * (1.525 - 1.53) / (410 - 350) - 1.525) * -1
            End If
            If NewPeaks(i, 1) > 410 And NewPeaks(i, 1) < 475 Then
                Intro(i, 1) = ((475 - NewPeaks(i, 1)) * (1.541 - 1.525) / (475 - 410) - 1.514) * -1
            End If
            If NewPeaks(i, 1) > 475 And NewPeaks(i, 1) < 580 Then
                Intro(i, 1) = ((580 - NewPeaks(i, 1)) * (1.506 - 1.514) / (580 - 475) - 1.506) * -1
            End If
            If NewPeaks(i, 1) > 580 And NewPeaks(i, 1) < 750 Then
                Intro(i, 1) = ((750 - NewPeaks(i, 1)) * (1.497 - 1.506) / (750 - 580) - 1.497) * -1
            End If
            If NewPeaks(i, 1) = 350 Then Intro(i, 1) = 1.53
            If NewPeaks(i, 1) = 410 Then Intro(i, 1) = 1.525
            If NewPeaks(i, 1) = 475 Then Intro(i, 1) = 1.497
            If NewPeaks(i, 1) = 580 Then Intro(i, 1) = 1.506
            If NewPeaks(i, 1) = 750 Then Intro(i, 1) = 1.497

        Next
        mk = actual
        increase = 0
        For j = 1 To 25
            tto = 0
            For i = 1 To actual
                'Get T1 T0 Tn
                Intro(i, 2) = mk * NewPeaks(i, 1) / (2 * Intro(i, 1))
                'Get Total Thickness
                tto = Intro(i, 2) + tto
                mk = mk - 1
            Next
            avto = tto / actual
            Mt(j) = 0
            For i = 1 To actual
                Mt(j) = Mt(j) + (avto - Intro(i, 2)) * (avto - Intro(i, 2))
            Next
            increase = increase + 1
            mk = actual + increase
        Next
        'CHECK THE MININUM

        savemin = Mt(1)
        For j = 1 To 25
            If Mt(j) < savemin Then
                savemin = Mt(j)
                mkdist = j - 1
            End If
        Next

        'RECALCULATE THE THICKNESS
        'mkdist=12
        mkmin = actual + mkdist
        tto = 0
        For i = 1 To actual
            'GET T1 T0 Tn
            Intro(i, 2) = (mkmin * NewPeaks(i, 1)) / (2 * Intro(i, 1))
            'Get TOTAL THICKNESS
            tto = Intro(i, 2) + tto
            mkmin = mkmin - 1
        Next

        Thickness = (tto / actual)
        For i = 1 To actual
            deriation = deriation + (Thickness - Intro(i, 2)) * (Thickness - Intro(i, 2))

        Next
        deriation = Math.Sqrt(deriation / (actual - 1))
    End Sub
End Module
