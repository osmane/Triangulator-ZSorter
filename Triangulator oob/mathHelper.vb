Imports System.Math
Namespace Triangulator
    Module mathHelper
        Public world As World
        Dim ppKenarNo, ppKenarNo2 As Integer
        Dim ppKesilenKenar, ppKesilenKenar2, ppVolumKenar, ppKomsuAktifKenar As Kenar
        Dim ppKesnok, ppKesCev1, ppKesCev2 As New KesisimCevap
        Dim ppUcgen, ppKomsuUcgen As Ucgen

        Dim Magnetism As Byte = 5
        Dim Testkenar As New Kenar

        Property Cemberlist As List(Of Integer)
            Get
                Cemberlist = world.Cemberlist
            End Get
            Set(value As List(Of Integer))

            End Set
        End Property
        Public Function NoktaIsInsideTri(ByVal TestUcgen As List(Of Integer), ByVal TargetPoint As PointF, ByVal TotalNoktaList As List(Of Nokta)) As Boolean
            Dim InsideCevap As KesisimCevap
            Testkenar.Uc1NoktaNo = TestUcgen(1)
            Testkenar.Uc2NoktaNo = TestUcgen(2)
            InsideCevap = CollKesisimHesapla(Testkenar, TotalNoktaList(TestUcgen(0)), TargetPoint, 0, TotalNoktaList)
            If InsideCevap.Durum = 1 Then
                Return True
            Else
                Return False
            End If

        End Function
        Function MesafeHesapla(ByVal Nokta1 As PointF, ByVal Nokta2 As PointF) As Double
            Dim HedefXFark, HedefYFark, HedefMesafe As Double
            HedefXFark = Nokta1.X - Nokta2.X
            HedefYFark = Nokta1.Y - Nokta2.Y
            HedefMesafe = Math.Sqrt(HedefXFark ^ 2 + HedefYFark ^ 2)
            Return HedefMesafe
        End Function
        Function AciBul(ByVal Nokta1 As PointF, ByVal Nokta2 As PointF) As Double
            Dim HedefXFark, HedefYFark, HedefUzaklik As Double
            Dim HedefSin, HedefCos As Double
            HedefXFark = Nokta1.X - Nokta2.X
            HedefYFark = Nokta1.Y - Nokta2.Y
            HedefUzaklik = Sqrt(HedefXFark ^ 2 + HedefYFark ^ 2)
            HedefCos = HedefXFark / HedefUzaklik
            HedefSin = HedefYFark / HedefUzaklik

            Dim tmpAci As Double
            tmpAci = Math.Atan2(HedefSin, HedefCos * -1) / (PI / 180)
            If tmpAci < 0 Then
                Return 360 + tmpAci
            Else
                Return tmpAci
            End If
        End Function
        Function CollKesisimHesapla(ByVal Kenar1 As Kenar, ByVal HangiNokta As Nokta, ByVal FinishNokta As PointF, ByVal MinKesArea As Single, ByVal TotalNoktaList As List(Of Nokta)) As KesisimCevap
            Dim KesisimNokta As New KesisimCevap
            Dim x1, x2, x3, x4, y1, y2, y3, y4 As Double
            Dim a1, a2, xi, yi, KesilenUzunlugu As Double
            'Dim As Boolean
            'Dim Q1, Q2, Q3, Q4, q4str As String
            Dim gonder As Boolean = True

            x1 = TotalNoktaList(Kenar1.Uc1NoktaNo).KendiYeri.X
            y1 = TotalNoktaList(Kenar1.Uc1NoktaNo).KendiYeri.Y

            x2 = TotalNoktaList(Kenar1.Uc2NoktaNo).KendiYeri.X
            y2 = TotalNoktaList(Kenar1.Uc2NoktaNo).KendiYeri.Y

            x3 = HangiNokta.KendiYeri.X
            y3 = HangiNokta.KendiYeri.Y

            x4 = FinishNokta.X
            y4 = FinishNokta.Y

            a1 = (((x1 - x2) * (y3 - y4)) - ((y1 - y2) * (x3 - x4)))
            a2 = (((x1 - x2) * (y3 - y4)) - ((y1 - y2) * (x3 - x4)))
            If a1 <> 0 Then
                xi = ((((x1 * y2) - (y1 * x2)) * (x3 - x4)) - ((x1 - x2) * ((x3 * y4) - (y3 * x4)))) / a1
                yi = ((((x1 * y2) - (y1 * x2)) * (y3 - y4)) - ((y1 - y2) * ((x3 * y4) - (y3 * x4)))) / a2
                KesisimNokta.KesisimNok.X = xi
                KesisimNokta.KesisimNok.Y = yi


                KesisimNokta.Uc1toKN = MesafeHesapla(TotalNoktaList(Kenar1.Uc1NoktaNo).KendiYeri, KesisimNokta.KesisimNok)
                KesisimNokta.Uc2toKN = MesafeHesapla(TotalNoktaList(Kenar1.Uc2NoktaNo).KendiYeri, KesisimNokta.KesisimNok)
                'Q1 = ((x1 - xi) * (xi - x2)).ToString
                'Q2 = ((y1 - yi) * (yi - y2)).ToString
                'Q3 = ((x3 - xi) * (xi - x4)).ToString
                'Q4 = ((y3 - yi) * (yi - y4)).ToString
                'q4str = (((y3 - yi) * (yi - y4)).ToString)
                If ((x1 - xi) * (xi - x2)) >= 0 And ((y1 - yi) * (yi - y2)) >= 0 And ((x3 - xi) * (xi - x4)) >= 0 And ((y3 - yi) * (yi - y4)) >= 0 Then
                    KesisimNokta.Durum = 2

                    If KesisimNokta.Uc1toKN >= MinKesArea And KesisimNokta.Uc2toKN >= MinKesArea Then
                        KesisimNokta.Durum = 2
                        'KesisimUzakligi = MesafeHesapla(HangiNokta.KendiYeri, KesisimNokta.KesisimNok)
                        'If KesisimUzakligi < 0.1 Then
                        '    KesisimNokta.Durum = 0
                        'End If
                    Else
                        KesisimNokta.Durum = 0
                        KesisimNokta.SifirKesisim = True
                    End If
                    If (Abs(xi - x4) = 0.0 And Abs(yi - y4) = 0.0) Then KesisimNokta.Durum = 1
                Else

                    '  If ((xi <> x1) Or (yi <> y1)) And _
                    '((xi <> x2) Or (yi <> y2)) And _
                    '((xi <> x3) Or (yi <> y3)) And _
                    '((xi <> x4) Or (yi <> y4)) Then
                    KesisimNokta.KesenUzunlugu = MesafeHesapla(HangiNokta.KendiYeri, FinishNokta)
                    KesisimNokta.KesisimUzakligi = MesafeHesapla(HangiNokta.KendiYeri, KesisimNokta.KesisimNok)
                    'If KesenUzunlugu <> KesisimUzakligi Then


                    Dim qsinusal As Double = Abs(((xi - x3) / KesisimNokta.KesisimUzakligi) - ((x4 - x3) / KesisimNokta.KesenUzunlugu))
                    Dim qcosinusal As Double = Abs(((yi - y3) / KesisimNokta.KesisimUzakligi) - ((y4 - y3) / KesisimNokta.KesenUzunlugu))
                    If (qsinusal < (0.9) And _
                        qcosinusal < (0.9)) Then
                        'KesilenUzunlugu = Round(MesafeHesapla(TotalNoktaList(Kenar1.Uc1NoktaNo).KendiYeri, TotalNoktaList(Kenar1.Uc2NoktaNo).KendiYeri), 2)
                        KesilenUzunlugu = MesafeHesapla(TotalNoktaList(Kenar1.Uc1NoktaNo).KendiYeri, TotalNoktaList(Kenar1.Uc2NoktaNo).KendiYeri)
                        Dim yarakafedersin = ((KesisimNokta.Uc1toKN + KesisimNokta.Uc2toKN) - KesilenUzunlugu)
                        If ((KesisimNokta.Uc1toKN + KesisimNokta.Uc2toKN) - KesilenUzunlugu) <= (0.000009) Then
                            KesisimNokta.Durum = 1
                            KesisimNokta.SifirKesisim = True
                            If (KesisimNokta.KesenUzunlugu - KesisimNokta.KesisimUzakligi) <= (0.0) Then
                                'Çizgilerden birisi dik ise yukardaki durum 2 cevabını göndermesi
                                'gereken sorgu düzgün çalışmıyor onun yerine bu karşılaştırmayı
                                'yazmak zorunda kaldım. 
                                'bunun yerine yukardaki sorgu üçgenlerin toplam alanları ve 
                                'yamuğun toplam alanı karşılaştırmasıyla değiştirilebilir.
                                KesisimNokta.SifirKesisim = True
                                KesisimNokta.Durum = 1
                            Else
                                KesisimNokta.Durum = 2
                                KesisimNokta.SifirKesisim = True
                            End If
                        Else
                            'KesisimNokta.Durum = 0
                            'KesisimNokta.SifirKesisim = True
                        End If
                    Else

                        KesisimNokta.Durum = 0
                        'testcode start
                        'If KesisimUzakligi < 0.01 Then
                        '    KesisimNokta.Durum = 1
                        'End If
                        'testcode finish
                    End If
                    'Else
                    '    KesisimNokta.SifirKesisim = True
                    '    KesisimNokta.Durum = 1
                    'End If
                End If

            Else
                KesisimNokta.Durum = 0
                If a2 = 0 Then KesisimNokta.SifirKesisim = True
            End If

            Return KesisimNokta

        End Function
        Function CollKesisimHesapla(ByVal p1 As PointF, ByVal p2 As PointF, ByVal p3 As PointF, ByVal FinishNokta As PointF, ByVal MinKesArea As Single) As KesisimCevap
            Dim KesisimNokta As New KesisimCevap
            Dim x1, x2, x3, y1, y2, y3, x4, y4 As Double
            Dim a1, a2, xi, yi, KesenUzunlugu, KesisimUzakligi, KesilenUzunlugu, Uc1toKN, Uc2toKN As Double
            'Dim As Boolean
            'Dim Q1, Q2, Q3, Q4, q4str As String
            Dim gonder As Boolean = True

            x1 = p1.X
            y1 = p1.Y

            x2 = p2.X
            y2 = p2.Y

            x3 = p3.X
            y3 = p3.Y

            x4 = FinishNokta.X
            y4 = FinishNokta.Y

            a1 = (((x1 - x2) * (y3 - y4)) - ((y1 - y2) * (x3 - x4)))
            a2 = (((x1 - x2) * (y3 - y4)) - ((y1 - y2) * (x3 - x4)))
            If a1 <> 0 Then
                xi = ((((x1 * y2) - (y1 * x2)) * (x3 - x4)) - ((x1 - x2) * ((x3 * y4) - (y3 * x4)))) / a1
                yi = ((((x1 * y2) - (y1 * x2)) * (y3 - y4)) - ((y1 - y2) * ((x3 * y4) - (y3 * x4)))) / a2
                KesisimNokta.KesisimNok.X = xi
                KesisimNokta.KesisimNok.Y = yi


                Uc1toKN = MesafeHesapla(p1, KesisimNokta.KesisimNok)
                Uc2toKN = MesafeHesapla(p2, KesisimNokta.KesisimNok)
                'Q1 = ((x1 - xi) * (xi - x2)).ToString
                'Q2 = ((y1 - yi) * (yi - y2)).ToString
                'Q3 = ((x3 - xi) * (xi - x4)).ToString
                'Q4 = ((y3 - yi) * (yi - y4)).ToString
                'q4str = (((y3 - yi) * (yi - y4)).ToString)
                If ((x1 - xi) * (xi - x2)) >= 0 And ((y1 - yi) * (yi - y2)) >= 0 And ((x3 - xi) * (xi - x4)) >= 0 And ((y3 - yi) * (yi - y4)) >= 0 Then
                    KesisimNokta.Durum = 2

                    If Uc1toKN >= MinKesArea And Uc2toKN >= MinKesArea Then
                        KesisimNokta.Durum = 2
                        'KesisimUzakligi = MesafeHesapla(HangiNokta.KendiYeri, KesisimNokta.KesisimNok)
                        'If KesisimUzakligi < 0.1 Then
                        '    KesisimNokta.Durum = 0
                        'End If
                    Else
                        KesisimNokta.Durum = 0
                        KesisimNokta.SifirKesisim = True
                    End If
                    If (Abs(xi - x4) < 0.0 And Abs(yi - y4) < 0.0) Then KesisimNokta.Durum = 1
                Else

                    '  If ((xi <> x1) Or (yi <> y1)) And _
                    '((xi <> x2) Or (yi <> y2)) And _
                    '((xi <> x3) Or (yi <> y3)) And _
                    '((xi <> x4) Or (yi <> y4)) Then
                    KesenUzunlugu = MesafeHesapla(p3, FinishNokta)
                    KesisimUzakligi = MesafeHesapla(p3, KesisimNokta.KesisimNok)
                    'If KesenUzunlugu <> KesisimUzakligi Then


                    Dim qsinusal As Double = Abs(((xi - x3) / KesisimUzakligi) - ((x4 - x3) / KesenUzunlugu))
                    Dim qcosinusal As Double = Abs(((yi - y3) / KesisimUzakligi) - ((y4 - y3) / KesenUzunlugu))
                    If (qsinusal < (0.9) And _
                        qcosinusal < (0.9)) Then
                        'KesilenUzunlugu = Round(MesafeHesapla(TotalNoktaList(Kenar1.Uc1NoktaNo).KendiYeri, TotalNoktaList(Kenar1.Uc2NoktaNo).KendiYeri), 2)
                        KesilenUzunlugu = MesafeHesapla(p1, p2)

                        If ((Uc1toKN + Uc2toKN) - KesilenUzunlugu) <= (0.000009) Then
                            KesisimNokta.Durum = 1
                            KesisimNokta.SifirKesisim = True
                            If (KesenUzunlugu - KesisimUzakligi) <= (0.0) Then
                                'Çizgilerden birisi dik ise yukardaki durum 2 cevabını göndermesi
                                'gereken sorgu düzgün çalışmıyor onun yerine bu karşılaştırmayı
                                'yazmak zorunda kaldım. 
                                'bunun yerine yukardaki sorgu üçgenlerin toplam alanları ve 
                                'yamuğun toplam alanı karşılaştırmasıyla değiştirilebilir.
                                KesisimNokta.SifirKesisim = True
                                KesisimNokta.Durum = 1
                            Else
                                KesisimNokta.Durum = 2
                                KesisimNokta.SifirKesisim = True
                            End If
                        Else
                            'KesisimNokta.Durum = 0
                            'KesisimNokta.SifirKesisim = True
                        End If
                    Else

                        KesisimNokta.Durum = 0
                        'testcode start
                        'If KesisimUzakligi < 0.01 Then
                        '    KesisimNokta.Durum = 1
                        'End If
                        'testcode finish
                    End If
                    'Else
                    '    KesisimNokta.SifirKesisim = True
                    '    KesisimNokta.Durum = 1
                    'End If
                End If

            Else
                KesisimNokta.Durum = 0
                If a2 = 0 Then KesisimNokta.SifirKesisim = True
            End If

            Return KesisimNokta

        End Function
        Public Function GetAngle(ByVal GelenUc As PointF, ByVal OrtaUc As PointF, ByVal GidenUc As PointF) As Double

            GetAngle = Math.Atan2(CrossProductLength(GelenUc.X, GelenUc.Y, OrtaUc.X, OrtaUc.Y, GidenUc.X, GidenUc.Y), _
                                  DotProduct(GelenUc.X, GelenUc.Y, OrtaUc.X, OrtaUc.Y, GidenUc.X, GidenUc.Y)) * (180 / PI)
            'yapılacak: son düzenleme ikiucgenbagla için yapıldı. bu fonksiyona olan diğer başvurular yenilenecek
            If GetAngle < 0 Then
                Return 360 + GetAngle
            Else
                Return GetAngle
            End If
        End Function
        Private Function DotProduct( _
           ByVal Ax As Double, ByVal Ay As Double, _
           ByVal Bx As Double, ByVal By As Double, _
           ByVal Cx As Double, ByVal Cy As Double _
         ) As Double
            Dim BAx As Double
            Dim BAy As Double
            Dim BCx As Double
            Dim BCy As Double

            ' Get the vectors' coordinates.
            BAx = Ax - Bx
            BAy = Ay - By
            BCx = Cx - Bx
            BCy = Cy - By

            ' Calculate the dot product.
            DotProduct = BAx * BCx + BAy * BCy
        End Function
        Public Function CrossProductLength( _
            ByVal Ax As Double, ByVal Ay As Double, _
            ByVal Bx As Double, ByVal By As Double, _
            ByVal Cx As Double, ByVal Cy As Double _
          ) As Double
            Dim BAx As Double
            Dim BAy As Double
            Dim BCx As Double
            Dim BCy As Double

            ' Get the vectors' coordinates.
            BAx = Ax - Bx
            BAy = Ay - By
            BCx = Cx - Bx
            BCy = Cy - By

            ' Calculate the Z coordinate of the cross product.
            CrossProductLength = BAx * BCy - BAy * BCx
        End Function
        Public Function ATange2(ByVal opp As Double, ByVal adj As Double) As Double
            Dim angle As Double

            ' Get the basic angle.
            If Math.Abs(adj) < 0.000001 Then
                angle = Math.PI / 2
            Else
                angle = Math.Abs(Math.Atan(opp / adj))
            End If

            ' See if we are in quadrant 2 or 3.
            If adj < 0 Then
                ' angle > PI/2 or angle < -PI/2.
                angle = Math.PI - angle
            End If

            ' See if we are in quadrant 3 or 4.
            If opp < 0 Then
                angle = -angle
            End If

            ' Return the result.
            ATange2 = angle
        End Function
        Public Function PointToPointQuery2(ByVal BakanNokta As Nokta, ByVal HedefNokta As PointF, ByVal ShowCember As Boolean, ByVal LookAralik As Aralik, ByVal MinKesArea As Double, ByVal TotalNoktaList As List(Of Nokta), ByVal TotalUcgenList As List(Of Ucgen)) As PointToAnswer
            Dim ppAnswer As New PointToAnswer
            ppAnswer.PolyNo = -7
            ppAnswer.Durum = 0
            ppAnswer.SonKesilenDoluPoly = -1
            ppAnswer.OnKesilenDoluPoly = -1

            ppAnswer.OncekiDoluKenar = Nothing
            ppAnswer.KesilenKenarSay = 0
            ppAnswer.ihlal = False
            'Noktanın kendi üzerindeki dolu aralıkları sayıp saymayacağı ve tüm aralıkları sayıp saymayacağı parametre olarak verilecek
            'bu düzenleme yapılınca "BakanNokta.NoktaPolyNo <> ppKomsuUcgen.UcgenPolyNo" sorguları kaldırılacak

            If LookAralik.Disabled = False Then
                ppUcgen = TotalUcgenList(LookAralik.UcgenNo)
                ppKomsuUcgen = ppUcgen
                ppVolumKenar = ppUcgen.KenarList.Item(LookAralik.UcgeniciKarsiKenarNo)
                ppKenarNo = LookAralik.UcgeniciKarsiKenarNo
                ppKesnok = CollKesisimHesapla(ppVolumKenar, BakanNokta, HedefNokta, MinKesArea, TotalNoktaList)
                'If ShowCember Then
                '    For CemberSay = 0 To 2
                '        If MesafeHesapla(TotalNoktaList(ppUcgen.KenarList(CemberSay).Uc1NoktaNo).KendiYeri, HedefNokta) < Magnetism * 3 Then
                '            Cemberlist.Add(ppUcgen.KenarList(CemberSay).Uc1NoktaNo)
                '            Exit For
                '        End If
                '    Next
                'End If
                If ppKesnok.Durum = 0 Then ppAnswer.ihlal = True
                If ppKesnok.Durum > 0 Then
                    ppAnswer.UcgenNo = LookAralik.UcgenNo
                    ppAnswer.Durum = 1
                    ppAnswer.PolyNo = ppKomsuUcgen.UcgenPolyNo
                    ppAnswer.KesNok = ppKesnok.KesisimNok
                    If ppAnswer.PolyNo > -1 Then
                        ppAnswer.KesilenKenarSay = ppAnswer.KesilenKenarSay + 1
                        ppAnswer.SonKesilenDoluPoly = ppAnswer.PolyNo
                    End If

                    'If ppVolumKenar.KomsuNo >= 0 Then
                    'If ShowCember Then
                    '    For CemberSay = 0 To 2
                    '        If MesafeHesapla(TotalNoktaList(TotalUcgenList.Item(ppVolumKenar.KomsuNo).KenarList(CemberSay).Uc1NoktaNo).KendiYeri, HedefNokta) < Magnetism * 2 Or _
                    '           MesafeHesapla(TotalNoktaList(TotalUcgenList.Item(ppVolumKenar.KomsuNo).KenarList(CemberSay).Uc1NoktaNo).KendiYeri, ppKesnok.KesisimNok) < Magnetism Then
                    '            Cemberlist.Add(TotalUcgenList.Item(ppVolumKenar.KomsuNo).KenarList(CemberSay).Uc1NoktaNo)
                    '        End If
                    '    Next
                    'End If
                    If ppKesnok.Durum = 2 Then
                        Do
                            If ppVolumKenar.KomsuNo >= 0 Then
                                'If TotalUcgenList.Count - 1 < ppVolumKenar.KomsuNo Then
                                '    FatalError = True
                                '    Exit Function
                                'End If
                                ppKomsuUcgen = TotalUcgenList.Item(ppVolumKenar.KomsuNo)
                                ppKomsuAktifKenar = ppKomsuUcgen.KenarList.Item(ppVolumKenar.KomsudaKacinciKenarNo)
                                ppAnswer.Durum = 2
                                ppAnswer.UcgenNo = ppVolumKenar.KomsuNo
                                ppAnswer.PolyNo = ppKomsuUcgen.UcgenPolyNo
                                If ppAnswer.OncekiDoluKenar Is Nothing Then
                                    If (ppVolumKenar.KenarPolyNo > -1) Then
                                        ppAnswer.OncekiDoluKenar = ppVolumKenar
                                    ElseIf (ppKomsuAktifKenar.KenarPolyNo > -1) Then
                                        ppAnswer.OncekiDoluKenar = ppKomsuAktifKenar
                                    End If
                                End If
                             

                                If (ppAnswer.ilKesilenDiskenar Is Nothing) Then
                                    If (ppVolumKenar.DisKenar = True) Then
                                        ppAnswer.ilKesilenDiskenar = ppVolumKenar
                                    ElseIf (ppKomsuAktifKenar.DisKenar = True) Then
                                        ppAnswer.ilKesilenDiskenar = ppKomsuAktifKenar
                                    End If
                                End If

                                If ppAnswer.SonKesilenDoluPoly > -1 Then
                                    If ppAnswer.ihlal = False Then
                                        If ((ppVolumKenar.Uc1NoktaNo = BakanNokta.NoktaNo Or TotalNoktaList(ppVolumKenar.Uc1NoktaNo).KendiYeri = HedefNokta) Or _
                                           (ppVolumKenar.Uc2NoktaNo = BakanNokta.NoktaNo Or TotalNoktaList(ppVolumKenar.Uc2NoktaNo).KendiYeri = HedefNokta)) Then
                                            ppAnswer.ihlal = False
                                        Else
                                            ppAnswer.ihlal = True
                                        End If
                                    End If
                                End If


                                If ppAnswer.PolyNo > -1 Then

                                    ppAnswer.KesilenKenarSay = ppAnswer.KesilenKenarSay + 1
                                    If ppAnswer.KesilenKenarSay > 1 Then
                                        ppAnswer.OnKesilenDoluPoly = ppAnswer.SonKesilenDoluPoly
                                    End If
                                    ppAnswer.SonKesilenDoluPoly = ppAnswer.PolyNo
                                End If

                                If ShowCember Then
                                    ppKomsuUcgen.Boya = True
                                End If

                                If BakanNokta.KendiYeri = TotalNoktaList.Item((ppKomsuUcgen.KenarList.Item(ppVolumKenar.KomsudaKacinciKenarNo).KarsiNoktaNo)).KendiYeri Then
                                    Exit Do
                                End If
                                ppKenarNo = (ppVolumKenar.KomsudaKacinciKenarNo + 1) Mod 3
                                ppKenarNo2 = (ppVolumKenar.KomsudaKacinciKenarNo + 2) Mod 3
                                ppKesilenKenar = ppKomsuUcgen.KenarList.Item(ppKenarNo)
                                ppKesilenKenar2 = ppKomsuUcgen.KenarList.Item(ppKenarNo2)
                                ppKesCev1 = CollKesisimHesapla(ppKesilenKenar, BakanNokta, HedefNokta, MinKesArea, TotalNoktaList)
                                If ppKesCev1.Durum = 2 Then
                                    ppVolumKenar = ppKesilenKenar
                                    ppKenarNo = ppKenarNo
                                    ppAnswer.KesNok = ppKesCev1.KesisimNok
                                Else
                                    ppKesCev2 = CollKesisimHesapla(ppKesilenKenar2, BakanNokta, HedefNokta, MinKesArea, TotalNoktaList)
                                    If ppKesCev2.Durum = 2 Then
                                        ppVolumKenar = ppKesilenKenar2
                                        ppKenarNo = ppKenarNo2
                                        ppAnswer.KesNok = ppKesCev2.KesisimNok
                                    Else
                                        Exit Do
                                    End If

                                    If ppKesCev1.Durum = 0 And ppKesCev2.Durum = 0 Then
                                        ppAnswer.ihlal = True
                                        Exit Do
                                    End If

                                End If

                                If (ppVolumKenar.KomsuNo > -1) Then
                                    ppKomsuUcgen = TotalUcgenList.Item(ppVolumKenar.KomsuNo)
                                    ppKomsuAktifKenar = ppKomsuUcgen.KenarList.Item(ppVolumKenar.KomsudaKacinciKenarNo)
                                    If (ppAnswer.OncekiDoluKenar Is Nothing) Then
                                        If (ppVolumKenar.KenarPolyNo > -1) Then
                                            ppAnswer.OncekiDoluKenar = ppVolumKenar
                                        ElseIf (ppKomsuAktifKenar.KenarPolyNo > -1) Then
                                            ppAnswer.OncekiDoluKenar = ppKomsuAktifKenar
                                        End If
                                    End If
                                    
                                    If (ppAnswer.ilKesilenDiskenar Is Nothing) Then
                                        If (ppVolumKenar.DisKenar = True) Then
                                            ppAnswer.ilKesilenDiskenar = ppVolumKenar
                                        ElseIf (ppKomsuAktifKenar.DisKenar = True) Then
                                            ppAnswer.ilKesilenDiskenar = ppKomsuAktifKenar
                                        End If
                                    End If
                                End If

                                If ppVolumKenar.KomsuNo >= 0 And ShowCember Then
                                    For CemberSay = 0 To 2
                                        If MesafeHesapla(TotalNoktaList(TotalUcgenList.Item(ppVolumKenar.KomsuNo).KenarList(CemberSay).Uc1NoktaNo).KendiYeri, HedefNokta) < Magnetism * 2 Or _
                                             MesafeHesapla(TotalNoktaList(TotalUcgenList.Item(ppVolumKenar.KomsuNo).KenarList(CemberSay).Uc1NoktaNo).KendiYeri, ppAnswer.KesNok) < Magnetism Then

                                            Cemberlist.Add(TotalUcgenList.Item(ppVolumKenar.KomsuNo).KenarList(CemberSay).Uc1NoktaNo)

                                        End If
                                    Next
                                End If
                            Else
                                If ppVolumKenar.KomsuNo < -9 Then
                                    ppAnswer.ilKesilenDiskenar = ppVolumKenar
                                    ppAnswer.OncekiDoluKenar = ppVolumKenar
                                    ppAnswer.SonKesilenDoluPoly = ppVolumKenar.KomsuNo
                                End If
                                Exit Do
                            End If
                        Loop
                        If ppAnswer.SonKesilenDoluPoly > -1 Then
                            If ppAnswer.ihlal = False Then
                                If ((ppVolumKenar.Uc1NoktaNo = BakanNokta.NoktaNo Or TotalNoktaList(ppVolumKenar.Uc1NoktaNo).KendiYeri = HedefNokta) Or _
                                   (ppVolumKenar.Uc2NoktaNo = BakanNokta.NoktaNo Or TotalNoktaList(ppVolumKenar.Uc2NoktaNo).KendiYeri = HedefNokta)) Then
                                    ppAnswer.ihlal = False
                                Else
                                    ppAnswer.ihlal = True
                                End If
                            End If
                        End If

                    End If
                    'Else
                    '    ppAnswer.ihlal = True
                    '    If ppVolumKenar.KomsuNo < -9 Then
                    '        ppAnswer.SonKesilenDoluPoly = ppVolumKenar.KomsuNo
                    '    End If
                    '    'ppAnswer.UcgenNo = ppVolumKenar.KomsuNo
                    'End If
                    If ppVolumKenar.KomsuNo < 0 Then
                        ppAnswer.ihlal = True

                        'ppVolumKenar.KomsuNo = TotalNoktaList(ppKomsuUcgen.KenarList(ppVolumKenar.KomsudaKacinciKenarNo).KarsiNoktaNo).AralikList(ppVolumKenar.KarsiNoktaAralikNo).UcgenNo
                        'ppAnswer.UcgenNo = ppVolumKenar.KomsuNo
                    End If
                Else
                    ppAnswer.ihlal = True
                    ppAnswer.UcgenNo = -1
                End If
            Else
                ppAnswer.ihlal = True
                ppAnswer.PolyNo = -1
                ppAnswer.Durum = 0
                ppAnswer.SonKesilenDoluPoly = -1

                ppAnswer.OncekiDoluKenar = Nothing
            End If

            If Cemberlist.Count > 0 Then ppAnswer.ihlal = True

            'Eğer noktanın bir aralığının kenarlarının açısı 180 dereceyse ve bu aralık 
            'liste sıralamasında öndeyse, hedef nokta nerde olursa olsun
            'kesişim sorgusu bu aralık için 2 yanıtını gönderiyor
            'böyle durumlarda aralık arama döngüsünün devamı için triangle inside sorgusu yapıyor.
            'yapılacak: triangle inside sorgusu sadece bahsedilen dar aralık noktada mevcutsa çalışacak şekilde düzenlenecek. PtoP3 içinde ayarlama yaılacak.
            'If ppAnswer.Durum > 0 Then
            '    If CollKesisimHesapla(TotalUcgenList(ppAnswer.UcgenNo).KenarList(0), TotalNoktaList(TotalUcgenList(ppAnswer.UcgenNo).KenarList(0).KarsiNoktaNo), HedefNokta, 0).Durum <> 1 Then
            '        'ppAnswer.Durum = 0
            '    End If
            'End If
      

            Return ppAnswer
        End Function

    End Module
    Public Class PointToAnswer
        Public UcgenNo As Integer
        Public Poligonized As Boolean = False
        Public PolyNo, EarSonUcgen As Integer
        Public Durum As Byte
        Public Daralma As Boolean = False
        Public SonKesilenDoluPoly, OnKesilenDoluPoly As Integer
        Public KesNok As PointF

        Public OncekiDoluKenar As Kenar = Nothing
        Public ColledKenar As Kenar = Nothing
        Public KesilenKenarSay As Integer
        Public ihlal As Boolean
        Public Connected As Boolean = True
        Public ilKesilenDiskenar As Kenar = Nothing
        Public karsiNokta As Nokta
    End Class
    Public Class KesisimCevap
        Public Durum As Byte = 0
        Public KesisimNok As PointF
        'Public KesilenUzunlugu As Double
        Public SifirKesisim As Boolean = False
        Public KesenUzunlugu, KesisimUzakligi, Uc1toKN, Uc2toKN As Double
    End Class

End Namespace