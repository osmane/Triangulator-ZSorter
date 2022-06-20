Namespace Triangulator
    Public Class World
        Public PolygonList As List(Of Polygon)
        Public TotalNoktaList As List(Of Nokta)
        Public TotalUcgenList As List(Of Ucgen)
        Public tmpMuseumPolygonGiden As List(Of Kenar)
        Public tmpMuseumPolygonGelen As List(Of Kenar)
        Public MuseumPolygonGiden As List(Of Kenar)
        Public MuseumPolygonGelen As List(Of Kenar)
        Public istikametList As List(Of Integer)
        Public TmpUcgenList As List(Of Ucgen)


        Public PoinLineIntList As List(Of Nokta)
        Public Cemberlist As List(Of Integer)
        Public NormalList As List(Of Kenar)
        Public DrectionList As List(Of Kenar)

        Public SonBasilanNokta As Nokta
        Public PicXMin As Integer
        Public PicXMax As Integer
        Public PicYMin As Integer
        Public PicYMax As Integer
        Public PolyMoveEnabled As Boolean
        Public FatalError As Boolean
        Public CollisionFound As Boolean
        Public ZoomFactor As Double
        Dim BasaYakin As Boolean
        Dim EskiCiz As Boolean
        Dim EarCiz As Boolean
        Dim ActivePolygon As Polygon
        'Public CizilenPolygonNo As Integer
        Dim ClosingPointNo As Integer
        Public AramailkNoktasi As Nokta
        Dim EarKesisimKenarGidenUcgen, EarKesisimKenarGelenUcgen As Integer
        Dim Backistikamet As Integer
        Dim GidenMuseumSonUcgen As Integer
        Dim MoveEtkinGeo As New PointToAnswer
        Public logImpacts As Boolean
        Public tmpSayac As Integer

        Sub New()
            Me.PolygonList = New List(Of Polygon)
            Me.TotalNoktaList = New List(Of Nokta)
            Me.TotalUcgenList = New List(Of Ucgen)
            Me.tmpMuseumPolygonGiden = New List(Of Kenar)
            Me.tmpMuseumPolygonGelen = New List(Of Kenar)
            Me.MuseumPolygonGiden = New List(Of Kenar)
            Me.MuseumPolygonGelen = New List(Of Kenar)
            Me.istikametList = New List(Of Integer)
            Me.TmpUcgenList = New List(Of Ucgen)

            Me.PoinLineIntList = New List(Of Nokta)
            Me.Cemberlist = New List(Of Integer)
            Me.SonBasilanNokta = New Nokta(Me)

            Me.PicXMin = 1
            Me.PicXMax = 1000
            Me.PicYMin = 1
            Me.PicYMax = 1000
            'Me.CizilenPolygonNo = 0
            Me.PolyMoveEnabled = False
            Me.FatalError = False
            Me.CollisionFound = False
            Me.ZoomFactor = 1
            Me.BasaYakin = False
            Me.EskiCiz = True
            Me.EarCiz = True
            Me.logImpacts = False
            Me.tmpSayac = 0
            Me.NormalList = New List(Of Kenar)
            Me.DrectionList = New List(Of Kenar)
            Dim Nokta0 As New Nokta(Me)
            Nokta0.KendiYeri.X = PicXMin
            Nokta0.KendiYeri.Y = PicYMin

            Dim Aralik0N0 As New Aralik
            Aralik0N0.GidenUcNo = 4
            Aralik0N0.GelenUcNo = 3
            Aralik0N0.UcgenNo = 0
            Aralik0N0.UcgeniciKarsiKenarNo = 2
            Aralik0N0.UcgeniciGidenKenarNo = 1
            Aralik0N0.UcgeniciGelenKenarNo = 0
            Nokta0.AralikList.Add(Aralik0N0)

            Dim Aralik0N1 As New Aralik
            Aralik0N1.GidenUcNo = 1
            Aralik0N1.GelenUcNo = 4
            Aralik0N1.UcgenNo = 1
            Aralik0N1.UcgeniciKarsiKenarNo = 1
            Aralik0N1.UcgeniciGidenKenarNo = 0
            Aralik0N1.UcgeniciGelenKenarNo = 2
            Nokta0.AralikList.Add(Aralik0N1)
            Nokta0.NoktaNo = TotalNoktaList.Count
            TotalNoktaList.Add(Nokta0)

            Dim Nokta1 As New Nokta(Me)
            Nokta1.KendiYeri.X = PicXMax
            Nokta1.KendiYeri.Y = PicYMin

            Dim Aralik1N0 As New Aralik
            Aralik1N0.GidenUcNo = 4
            Aralik1N0.GelenUcNo = 0
            Aralik1N0.UcgenNo = 1
            Aralik1N0.UcgeniciKarsiKenarNo = 2
            Aralik1N0.UcgeniciGidenKenarNo = 1
            Aralik1N0.UcgeniciGelenKenarNo = 0
            Nokta1.AralikList.Add(Aralik1N0)

            Dim Aralik1N1 As New Aralik
            Aralik1N1.GidenUcNo = 2
            Aralik1N1.GelenUcNo = 4
            Aralik1N1.UcgenNo = 2
            Aralik1N1.UcgeniciKarsiKenarNo = 1
            Aralik1N1.UcgeniciGidenKenarNo = 0
            Aralik1N1.UcgeniciGelenKenarNo = 2
            Nokta1.AralikList.Add(Aralik1N1)
            Nokta1.NoktaNo = TotalNoktaList.Count
            TotalNoktaList.Add(Nokta1)

            Dim Nokta2 As New Nokta(Me)
            Nokta2.KendiYeri.X = PicXMax
            Nokta2.KendiYeri.Y = PicYMax

            Dim Aralik2N0 As New Aralik
            Aralik2N0.GidenUcNo = 4
            Aralik2N0.GelenUcNo = 1
            Aralik2N0.UcgenNo = 2
            Aralik2N0.UcgeniciKarsiKenarNo = 2
            Aralik2N0.UcgeniciGidenKenarNo = 1
            Aralik2N0.UcgeniciGelenKenarNo = 0
            Nokta2.AralikList.Add(Aralik2N0)

            Dim Aralik2N1 As New Aralik
            Aralik2N1.GidenUcNo = 3
            Aralik2N1.GelenUcNo = 4
            Aralik2N1.UcgenNo = 3
            Aralik2N1.UcgeniciKarsiKenarNo = 1
            Aralik2N1.UcgeniciGidenKenarNo = 0
            Aralik2N1.UcgeniciGelenKenarNo = 2
            Nokta2.AralikList.Add(Aralik2N1)
            Nokta2.NoktaNo = TotalNoktaList.Count
            TotalNoktaList.Add(Nokta2)

            Dim Nokta3 As New Nokta(Me)
            Nokta3.KendiYeri.X = PicXMin
            Nokta3.KendiYeri.Y = PicYMax

            Dim Aralik3N0 As New Aralik
            Aralik3N0.GidenUcNo = 4
            Aralik3N0.GelenUcNo = 2
            Aralik3N0.UcgenNo = 3
            Aralik3N0.UcgeniciKarsiKenarNo = 2
            Aralik3N0.UcgeniciGidenKenarNo = 1
            Aralik3N0.UcgeniciGelenKenarNo = 0
            Nokta3.AralikList.Add(Aralik3N0)

            Dim Aralik3N1 As New Aralik
            Aralik3N1.GidenUcNo = 0
            Aralik3N1.GelenUcNo = 4
            Aralik3N1.UcgenNo = 0
            Aralik3N1.UcgeniciKarsiKenarNo = 1
            Aralik3N1.UcgeniciGidenKenarNo = 0
            Aralik3N1.UcgeniciGelenKenarNo = 2
            Nokta3.AralikList.Add(Aralik3N1)
            Nokta3.NoktaNo = TotalNoktaList.Count
            TotalNoktaList.Add(Nokta3)

            Dim Nokta4 As New Nokta(Me)
            Nokta4.KendiYeri.X = 295
            Nokta4.KendiYeri.Y = 295
            Nokta4.NoktaPolyNo = 0

            Dim Aralik4N0 As New Aralik
            Aralik4N0.GidenUcNo = 3
            Aralik4N0.GelenUcNo = 0
            Aralik4N0.UcgenNo = 0
            Aralik4N0.UcgeniciKarsiKenarNo = 0
            Aralik4N0.UcgeniciGidenKenarNo = 2
            Aralik4N0.UcgeniciGelenKenarNo = 1
            Nokta4.AralikList.Add(Aralik4N0)

            Dim Aralik4N1 As New Aralik
            Aralik4N1.GidenUcNo = 0
            Aralik4N1.GelenUcNo = 1
            Aralik4N1.UcgenNo = 1
            Aralik4N1.UcgeniciKarsiKenarNo = 0
            Aralik4N1.UcgeniciGidenKenarNo = 2
            Aralik4N1.UcgeniciGelenKenarNo = 1
            Nokta4.AralikList.Add(Aralik4N1)

            Dim Aralik4N2 As New Aralik
            Aralik4N2.GidenUcNo = 1
            Aralik4N2.GelenUcNo = 2
            Aralik4N2.UcgenNo = 2
            Aralik4N2.UcgeniciKarsiKenarNo = 0
            Aralik4N2.UcgeniciGidenKenarNo = 2
            Aralik4N2.UcgeniciGelenKenarNo = 1
            Nokta4.AralikList.Add(Aralik4N2)

            Dim Aralik4N3 As New Aralik
            Aralik4N3.GidenUcNo = 2
            Aralik4N3.GelenUcNo = 3
            Aralik4N3.UcgenNo = 3
            Aralik4N3.UcgeniciKarsiKenarNo = 0
            Aralik4N3.UcgeniciGidenKenarNo = 2
            Aralik4N3.UcgeniciGelenKenarNo = 1
            Nokta4.AralikList.Add(Aralik4N3)
            Nokta4.NoktaNo = TotalNoktaList.Count
            TotalNoktaList.Add(Nokta4)
            '0
            Dim Ucgen0 As New Ucgen(Me)
            'Left wall
            Dim Kenar0U0 As New Kenar
            Kenar0U0.Uc1NoktaNo = 3
            Kenar0U0.Uc2NoktaNo = 0
            Kenar0U0.KomsuNo = -10
            Kenar0U0.KenarPolyNo = -10
            Kenar0U0.KarsiNoktaNo = 4
            Kenar0U0.KomsudaKacinciKenarNo = 0
            Kenar0U0.KarsiNoktaAralikNo = 0
            Ucgen0.KenarList.Add(Kenar0U0)

            Dim Kenar0U1 As New Kenar
            Kenar0U1.Uc1NoktaNo = 0
            Kenar0U1.Uc2NoktaNo = 4
            Kenar0U1.KomsuNo = 1
            Kenar0U1.KarsiNoktaNo = 3
            Kenar0U1.KomsudaKacinciKenarNo = 2
            Kenar0U1.KarsiNoktaAralikNo = 1
            Ucgen0.KenarList.Add(Kenar0U1)

            Dim Kenar0U2 As New Kenar
            Kenar0U2.Uc1NoktaNo = 4
            Kenar0U2.Uc2NoktaNo = 3
            Kenar0U2.KomsuNo = 3
            Kenar0U2.KarsiNoktaNo = 0
            Kenar0U2.KomsudaKacinciKenarNo = 1
            Kenar0U2.KarsiNoktaAralikNo = 0
            Ucgen0.KenarList.Add(Kenar0U2)

            TotalUcgenList.Add(Ucgen0)
            '1
            Dim Ucgen1 As New Ucgen(Me)
            'up wall
            Dim Kenar1U0 As New Kenar
            Kenar1U0.Uc1NoktaNo = 0
            Kenar1U0.Uc2NoktaNo = 1
            Kenar1U0.KomsuNo = -20
            Kenar1U0.KenarPolyNo = -20
            Kenar1U0.KarsiNoktaNo = 4
            Kenar1U0.KomsudaKacinciKenarNo = 0
            Kenar1U0.KarsiNoktaAralikNo = 1
            Ucgen1.KenarList.Add(Kenar1U0)

            Dim Kenar1U1 As New Kenar
            Kenar1U1.Uc1NoktaNo = 1
            Kenar1U1.Uc2NoktaNo = 4
            Kenar1U1.KomsuNo = 2
            Kenar1U1.KarsiNoktaNo = 0
            Kenar1U1.KomsudaKacinciKenarNo = 2
            Kenar1U1.KarsiNoktaAralikNo = 1
            Ucgen1.KenarList.Add(Kenar1U1)

            Dim Kenar1U2 As New Kenar
            Kenar1U2.Uc1NoktaNo = 4
            Kenar1U2.Uc2NoktaNo = 0
            Kenar1U2.KomsuNo = 0
            Kenar1U2.KarsiNoktaNo = 1
            Kenar1U2.KomsudaKacinciKenarNo = 1
            Kenar1U2.KarsiNoktaAralikNo = 0
            Ucgen1.KenarList.Add(Kenar1U2)

            TotalUcgenList.Add(Ucgen1)
            '2
            Dim Ucgen2 As New Ucgen(Me)
            'right wall
            Dim Kenar2U0 As New Kenar
            Kenar2U0.Uc1NoktaNo = 1
            Kenar2U0.Uc2NoktaNo = 2
            Kenar2U0.KomsuNo = -30
            Kenar2U0.KenarPolyNo = -30
            Kenar2U0.KarsiNoktaNo = 4
            Kenar2U0.KomsudaKacinciKenarNo = 0
            Kenar2U0.KarsiNoktaAralikNo = 2
            Ucgen2.KenarList.Add(Kenar2U0)

            Dim Kenar2U1 As New Kenar
            Kenar2U1.Uc1NoktaNo = 2
            Kenar2U1.Uc2NoktaNo = 4
            Kenar2U1.KomsuNo = 3
            Kenar2U1.KarsiNoktaNo = 1
            Kenar2U1.KomsudaKacinciKenarNo = 2
            Kenar2U1.KarsiNoktaAralikNo = 1
            Ucgen2.KenarList.Add(Kenar2U1)

            Dim Kenar2U2 As New Kenar
            Kenar2U2.Uc1NoktaNo = 4
            Kenar2U2.Uc2NoktaNo = 1
            Kenar2U2.KomsuNo = 1
            Kenar2U2.KarsiNoktaNo = 2
            Kenar2U2.KomsudaKacinciKenarNo = 1
            Kenar2U2.KarsiNoktaAralikNo = 0
            Ucgen2.KenarList.Add(Kenar2U2)

            TotalUcgenList.Add(Ucgen2)

            Dim Ucgen3 As New Ucgen(Me)
            'bottom Wall
            Dim Kenar3U0 As New Kenar
            Kenar3U0.Uc1NoktaNo = 2
            Kenar3U0.Uc2NoktaNo = 3
            Kenar3U0.KomsuNo = -40
            Kenar3U0.KenarPolyNo = -40
            Kenar3U0.KarsiNoktaNo = 4
            Kenar3U0.KomsudaKacinciKenarNo = 0
            Kenar3U0.KarsiNoktaAralikNo = 3
            Ucgen3.KenarList.Add(Kenar3U0)

            Dim Kenar3U1 As New Kenar
            Kenar3U1.Uc1NoktaNo = 3
            Kenar3U1.Uc2NoktaNo = 4
            Kenar3U1.KomsuNo = 0
            Kenar3U1.KarsiNoktaNo = 2
            Kenar3U1.KomsudaKacinciKenarNo = 2
            Kenar3U1.KarsiNoktaAralikNo = 1
            Ucgen3.KenarList.Add(Kenar3U1)

            Dim Kenar3U2 As New Kenar
            Kenar3U2.Uc1NoktaNo = 4
            Kenar3U2.Uc2NoktaNo = 2
            Kenar3U2.KomsuNo = 2
            Kenar3U2.KarsiNoktaNo = 3
            Kenar3U2.KomsudaKacinciKenarNo = 1
            Kenar3U2.KarsiNoktaAralikNo = 0
            Ucgen3.KenarList.Add(Kenar3U2)

            TotalUcgenList.Add(Ucgen3)

            SonBasilanNokta = TotalNoktaList.Item(TotalNoktaList.Count - 1)
            Dim p1 As New Polygon(Me)
            p1.PolyNoktaList.Add(TotalNoktaList.Count - 1)
            PolygonList.Add(p1)
            ActivePolygon = PolygonList(0)

            ClosingPointNo = 4

            AramailkNoktasi = TotalNoktaList(0)

        End Sub

        Public Sub Ucgenle(ByVal PointKoord As PointF, ByVal EkranYenile As Boolean, ByRef TargetNokta As Nokta, ByVal CizilenPolygonNo As Integer)
            Dim KesCev1, KesCev2 As New KesisimCevap
            Dim KesilenKenar, KesilenKenar2, tmpKenar, KomsuAktifKenar As Kenar
            Dim TmpKenarNo2, KenarSay As Integer
            Dim BasaYakinlik, AralikSay As Double
            Dim TmpKenarNo As Integer
            Dim KesNok As KesisimCevap
            Dim tmpUcgen As Ucgen
            Dim KomsuUcgen As Ucgen
            Dim ActiveUcgenNo As Integer
            Dim ActiveNokta As Nokta
            Dim ActiveAralik As Aralik
            Dim PolyKomsu As Ucgen
            Dim tmpPolyKenar As Kenar
            Dim KesPoint As New PointF
            MuseumPolygonGiden.Clear()
            MuseumPolygonGelen.Clear()
            'SonAci = AciBul(SonBasilanNokta.KendiYeri, TargetNokta.KendiYeri)
            'ClosingPointNo = 0

            If ClosingPointNo > 0 Then

                BasaYakinlik = MesafeHesapla(PointKoord, TotalNoktaList(ClosingPointNo).KendiYeri)

                If BasaYakinlik < 5 * ZoomFactor Then
                    BasaYakin = True
                    TargetNokta.KendiYeri = TotalNoktaList(ClosingPointNo).KendiYeri
                    PointKoord = TotalNoktaList(ClosingPointNo).KendiYeri
                Else
                    BasaYakin = False
                End If
                EskiCiz = True
            Else
                EskiCiz = False
                BasaYakin = False
            End If
            'If HScrollBar1.Value = 70 And TotalNoktaList.Count = 70 Then
            '    Beep()

            'End If
            For AralikSay = 0 To SonBasilanNokta.AralikList.Count - 1
                If SonBasilanNokta.AralikList.Item(AralikSay).Disabled = False Then


                    If PointKoord = TotalNoktaList(SonBasilanNokta.AralikList.Item(AralikSay).GidenUcNo).KendiYeri Or _
                       PointKoord = TotalNoktaList(SonBasilanNokta.AralikList.Item(AralikSay).GelenUcNo).KendiYeri Then
                        If ClosingPointNo > 0 Then
                            EskiCiz = False
                            EarCiz = False
                            'TotalNoktaList.Add(TotalNoktaList(ClosingPointNo))

                            If SonBasilanNokta.AralikList.Item(AralikSay).GelenUcNo = ClosingPointNo Then
                                TotalUcgenList(SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo).KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGelenKenarNo).PolyKenar = True
                                TotalUcgenList(SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo).KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGelenKenarNo).DisKenar = True
                                TotalUcgenList(SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo).KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGelenKenarNo).KenarPolyNo = CizilenPolygonNo
                                tmpPolyKenar = TotalUcgenList(SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo).KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGelenKenarNo)
                                PolyKomsu = TotalUcgenList(tmpPolyKenar.KomsuNo)
                                PolyKomsu.KenarList(tmpPolyKenar.KomsudaKacinciKenarNo).PolyKenar = True
                                PolyKomsu.KenarList(tmpPolyKenar.KomsudaKacinciKenarNo).DisKenar = True
                                PolyKomsu.KenarList(tmpPolyKenar.KomsudaKacinciKenarNo).KenarPolyNo = CizilenPolygonNo

                            ElseIf SonBasilanNokta.AralikList.Item(AralikSay).GidenUcNo = ClosingPointNo Then
                                TotalUcgenList(SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo).KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGidenKenarNo).PolyKenar = True
                                TotalUcgenList(SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo).KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGidenKenarNo).DisKenar = True
                                TotalUcgenList(SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo).KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGidenKenarNo).KenarPolyNo = CizilenPolygonNo
                                tmpPolyKenar = TotalUcgenList(SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo).KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGidenKenarNo)
                                PolyKomsu = TotalUcgenList(tmpPolyKenar.KomsuNo)
                                PolyKomsu.KenarList(tmpPolyKenar.KomsudaKacinciKenarNo).PolyKenar = True
                                PolyKomsu.KenarList(tmpPolyKenar.KomsudaKacinciKenarNo).DisKenar = True
                                PolyKomsu.KenarList(tmpPolyKenar.KomsudaKacinciKenarNo).KenarPolyNo = CizilenPolygonNo

                            End If

                            Exit For
                        End If

                    Else
                        ActiveUcgenNo = SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo
                        tmpUcgen = TotalUcgenList(ActiveUcgenNo)
                        tmpKenar = tmpUcgen.KenarList.Item(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciKarsiKenarNo)
                        istikametList.Clear()
                        KesNok = CollKesisimHesapla(tmpKenar, SonBasilanNokta, TargetNokta.KendiYeri, 0, TotalNoktaList)
                        If KesNok.Durum > 0 Then
                            'Label1.Text = (KesNok.Durum.ToString + " | " + KesNok.KesisimNok.ToString + " | " + SonBasilanNokta.AralikList.Item(AralikSay).UcgenNo.ToString + " | " + AralikSay.ToString + " | " + TotalUcgenList.Count.ToString)
                            'tmpUcgen.Boya = True
                            If KesNok.Durum = 1 Then
                                If PointKoord <> TotalNoktaList(ClosingPointNo).KendiYeri Or ClosingPointNo = 0 Then
                                    Dim YeniSonBasilanNokta As New Nokta(Me)
                                    YeniSonBasilanNokta.KendiYeri = PointKoord
                                    Dim TmpUcgenList As New List(Of Ucgen)
                                    For KenarSay = 0 To 2
                                        tmpKenar = tmpUcgen.KenarList.Item(KenarSay)
                                        ActiveNokta = TotalNoktaList.Item(tmpKenar.KarsiNoktaNo)
                                        ActiveAralik = ActiveNokta.AralikList.Item(tmpKenar.KarsiNoktaAralikNo)
                                        'ActiveAralik.GelenUcNo = ActiveAralik.GelenUcNo
                                        ActiveAralik.GidenUcNo = TotalNoktaList.Count

                                        ActiveAralik.UcgeniciGelenKenarNo = 0
                                        ActiveAralik.UcgeniciGidenKenarNo = 1
                                        ActiveAralik.UcgeniciKarsiKenarNo = 2
                                        If KenarSay <> 2 Then
                                            ActiveAralik.UcgenNo = TotalUcgenList.Count + (KenarSay)

                                        End If

                                        Dim YeniAralik As New Aralik
                                        YeniAralik.GelenUcNo = TotalNoktaList.Count
                                        YeniAralik.GidenUcNo = tmpKenar.Uc1NoktaNo
                                        YeniAralik.UcgeniciGelenKenarNo = 2
                                        YeniAralik.UcgeniciGidenKenarNo = 0
                                        YeniAralik.UcgeniciKarsiKenarNo = 1
                                        Select Case KenarSay
                                            Case 0
                                                YeniAralik.UcgenNo = TotalUcgenList.Count + 1
                                            Case 1
                                                YeniAralik.UcgenNo = ActiveUcgenNo
                                            Case 2
                                                YeniAralik.UcgenNo = TotalUcgenList.Count
                                        End Select
                                        ActiveNokta.AralikList.Add(YeniAralik)

                                        Dim icYeniAralik As New Aralik
                                        icYeniAralik.GelenUcNo = tmpKenar.Uc2NoktaNo
                                        icYeniAralik.GidenUcNo = tmpKenar.Uc1NoktaNo
                                        icYeniAralik.UcgeniciGelenKenarNo = 1
                                        icYeniAralik.UcgeniciGidenKenarNo = 2
                                        icYeniAralik.UcgeniciKarsiKenarNo = 0
                                        If KenarSay > 0 Then
                                            icYeniAralik.UcgenNo = TotalUcgenList.Count + KenarSay - 1
                                        ElseIf KenarSay = 0 Then
                                            icYeniAralik.UcgenNo = ActiveUcgenNo
                                        End If
                                        YeniSonBasilanNokta.AralikList.Add(icYeniAralik)

                                        Dim YeniUcgen As New Ucgen(Me)
                                        Dim YeniKenar0 As New Kenar
                                        YeniKenar0.Uc1NoktaNo = tmpKenar.Uc1NoktaNo
                                        YeniKenar0.Uc2NoktaNo = tmpKenar.Uc2NoktaNo
                                        YeniKenar0.KomsuNo = tmpKenar.KomsuNo
                                        YeniKenar0.KarsiNoktaNo = TotalNoktaList.Count
                                        YeniKenar0.KomsudaKacinciKenarNo = tmpKenar.KomsudaKacinciKenarNo
                                        YeniKenar0.KarsiNoktaAralikNo = KenarSay
                                        YeniKenar0.PolyKenar = tmpKenar.PolyKenar
                                        YeniKenar0.DisKenar = tmpKenar.PolyKenar
                                        YeniKenar0.KenarPolyNo = tmpKenar.KenarPolyNo
                                        YeniUcgen.KenarList.Add(YeniKenar0)
                                        Dim KomsuUcgen0 As Ucgen
                                        If tmpKenar.KomsuNo > -1 Then
                                            KomsuUcgen0 = TotalUcgenList.Item(tmpKenar.KomsuNo)
                                            If KenarSay > 0 Then
                                                KomsuUcgen0.KenarList.Item(tmpKenar.KomsudaKacinciKenarNo).KomsuNo = TotalUcgenList.Count + (KenarSay - 1)
                                            End If
                                            KomsuUcgen0.KenarList.Item(tmpKenar.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = 0
                                        End If

                                        Dim YeniKenar1 As New Kenar
                                        YeniKenar1.Uc1NoktaNo = tmpKenar.Uc2NoktaNo
                                        YeniKenar1.Uc2NoktaNo = TotalNoktaList.Count
                                        YeniKenar1.KomsuNo = ActiveAralik.UcgenNo
                                        YeniKenar1.KarsiNoktaNo = tmpKenar.Uc1NoktaNo
                                        YeniKenar1.KomsudaKacinciKenarNo = 2
                                        YeniKenar1.KarsiNoktaAralikNo = TotalNoktaList.Item(YeniKenar1.KarsiNoktaNo).AralikList.Count - ((KenarSay * (KenarSay - 1)) * 0.5)
                                        YeniUcgen.KenarList.Add(YeniKenar1)

                                        Dim YeniKenar2 As New Kenar

                                        YeniKenar2.Uc1NoktaNo = TotalNoktaList.Count
                                        YeniKenar2.Uc2NoktaNo = tmpKenar.Uc1NoktaNo
                                        YeniKenar2.KomsuNo = YeniAralik.UcgenNo
                                        YeniKenar2.KarsiNoktaNo = tmpKenar.Uc2NoktaNo
                                        YeniKenar2.KomsudaKacinciKenarNo = 1
                                        YeniKenar2.KarsiNoktaAralikNo = tmpUcgen.KenarList.Item((((KenarSay + 1) ^ KenarSay) + 1) Mod 3).KarsiNoktaAralikNo
                                        YeniUcgen.KenarList.Add(YeniKenar2)
                                        TmpUcgenList.Add(YeniUcgen)

                                    Next
                                    YeniSonBasilanNokta.NoktaPolyNo = PolygonList.Count - 1
                                    YeniSonBasilanNokta.NoktaNo = TotalNoktaList.Count
                                    TotalNoktaList.Add(YeniSonBasilanNokta)
                                    PolygonList(PolygonList.Count - 1).PolyNoktaList.Add(TotalNoktaList.Count - 1)
                                    If ClosingPointNo = 0 Then
                                        ClosingPointNo = TotalNoktaList.Count - 1
                                    End If
                                    tmpUcgen.KenarList.Clear()

                                    tmpUcgen.KenarList.AddRange(TmpUcgenList.Item(0).KenarList)
                                    TotalUcgenList.Add(TmpUcgenList.Item(1))
                                    TotalUcgenList.Add(TmpUcgenList.Item(2))
                                    If PolygonList(PolygonList.Count - 1).PolyNoktaList.Count > 1 Then
                                        For KenarSay = 1 To 2
                                            If (TotalUcgenList(TotalUcgenList.Count - 1).KenarList(KenarSay).Uc1NoktaNo = TotalNoktaList.Count - 1 And _
                                                TotalUcgenList(TotalUcgenList.Count - 1).KenarList(KenarSay).Uc2NoktaNo = TotalNoktaList.Count - 2) Or _
                                               (TotalUcgenList(TotalUcgenList.Count - 1).KenarList(KenarSay).Uc2NoktaNo = TotalNoktaList.Count - 1 And _
                                                TotalUcgenList(TotalUcgenList.Count - 1).KenarList(KenarSay).Uc1NoktaNo = TotalNoktaList.Count - 2) Then
                                                TotalUcgenList(TotalUcgenList.Count - 1).KenarList(KenarSay).PolyKenar = True
                                                TotalUcgenList(TotalUcgenList.Count - 1).KenarList(KenarSay).DisKenar = True
                                                TotalUcgenList(TotalUcgenList.Count - 1).KenarList(KenarSay).KenarPolyNo = CizilenPolygonNo
                                                tmpPolyKenar = TotalUcgenList(TotalUcgenList.Count - 1).KenarList(KenarSay)
                                                PolyKomsu = TotalUcgenList(tmpPolyKenar.KomsuNo)
                                                PolyKomsu.KenarList(tmpPolyKenar.KomsudaKacinciKenarNo).PolyKenar = True
                                                PolyKomsu.KenarList(tmpPolyKenar.KomsudaKacinciKenarNo).DisKenar = True
                                                PolyKomsu.KenarList(tmpPolyKenar.KomsudaKacinciKenarNo).KenarPolyNo = CizilenPolygonNo
                                            End If
                                        Next
                                    End If
                                Else
                                    'TotalNoktaList.Add(TotalNoktaList(ClosingPointNo))

                                End If
                                '{
                            ElseIf KesNok.Durum = 2 Then
                                Dim ModStart, ModKenarSay As Integer
                                'istikametList.Clear()
                                'If ClosingPointNo > 0 Then
                                istikametList.Add(ActiveUcgenNo)
                                'End If
                                tmpUcgen.CikisPoint.X = KesNok.KesisimNok.X
                                tmpUcgen.CikisPoint.Y = KesNok.KesisimNok.Y
                                tmpUcgen.CikilanKenarNo = SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciKarsiKenarNo
                                TotalUcgenList.Item(tmpKenar.KomsuNo).GirilenKenarNo = tmpKenar.KomsudaKacinciKenarNo
                                TotalUcgenList.Item(tmpKenar.KomsuNo).GirisPoint = tmpUcgen.CikisPoint
                                'TotalUcgenList(ActiveUcgenNo).Disabled = True
                                MuseumPolygonGiden.Add(tmpUcgen.KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGidenKenarNo))
                                If PolygonList(CizilenPolygonNo).PolyNoktaList.Count > 0 Then
                                    For KenarSay = 0 To 2
                                        If TotalNoktaList(tmpUcgen.KenarList(KenarSay).KarsiNoktaNo).AralikList(tmpUcgen.KenarList(KenarSay).KarsiNoktaAralikNo).Disabled = False Then
                                            TotalNoktaList(tmpUcgen.KenarList(KenarSay).KarsiNoktaNo).AralikList(tmpUcgen.KenarList(KenarSay).KarsiNoktaAralikNo).Disabled = True
                                            TotalNoktaList(tmpUcgen.KenarList(KenarSay).KarsiNoktaNo).DisableList.Add(tmpUcgen.KenarList(KenarSay).KarsiNoktaAralikNo)
                                        End If
                                    Next
                                End If
                                MuseumPolygonGelen.Insert(0, tmpUcgen.KenarList(SonBasilanNokta.AralikList.Item(AralikSay).UcgeniciGelenKenarNo))
                                KesPoint = tmpUcgen.CikisPoint


                                Do
                                    '								  If mesafehesapla(KesPoint, PointKoord)<0.1 Then
                                    ''                                    'istikametlist.RemoveAt(istikametlist.Count-1)
                                    ''                                    'basayakin=true
                                    ''                                    
                                    '                                         Exit do
                                    '                                   end if
                                    '
                                    If tmpKenar.KomsuNo >= 0 Then

                                        KomsuUcgen = TotalUcgenList.Item(tmpKenar.KomsuNo)
                                        KomsuAktifKenar = KomsuUcgen.KenarList.Item(tmpKenar.KomsudaKacinciKenarNo)
                                        KomsuUcgen.Boya = True

                                        If SonBasilanNokta.KendiYeri = TotalNoktaList((KomsuUcgen.KenarList(tmpKenar.KomsudaKacinciKenarNo).KarsiNoktaNo)).KendiYeri Then
                                            '                                        istikametlist.RemoveAt(istikametlist.Count-1)
                                            '                                        Exit Do
                                        End If

                                        If tmpKenar.PolyKenar = True Then
                                            '
                                            ActiveUcgenNo = tmpKenar.KomsuNo
                                            Dim tmpSonBasilanNokta As New Nokta(Me)
                                            tmpSonBasilanNokta.KendiYeri.X = KesPoint.X
                                            tmpSonBasilanNokta.KendiYeri.Y = KesPoint.Y
                                            tmpKenar.PolyKenar = False
                                            tmpKenar.DisKenar = False
                                            'MsgBox("alarm")

                                            Dim KendiniKesmeNoktasi As New Nokta(Me)
                                            KendiniKesmeNoktasi.KendiYeri.X = KesPoint.X
                                            KendiniKesmeNoktasi.KendiYeri.Y = KesPoint.Y

                                            KendiniKesmeNoktasi.NoktaPolyNo = PolygonList.Count - 1
                                            KendiniKesmeNoktasi.Turemis = True
                                            KendiniKesmeNoktasi.NoktaNo = TotalNoktaList.Count
                                            TotalNoktaList.Add(KendiniKesmeNoktasi)
                                            PolygonList(PolygonList.Count - 1).PolyNoktaList.Add(TotalNoktaList.Count - 1)


                                            Dim KesilenGidenKenar As New Kenar
                                            Dim KesilenGelenKenar As New Kenar

                                            KesilenGidenKenar.Uc1NoktaNo = MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo
                                            KesilenGidenKenar.Uc2NoktaNo = TotalNoktaList.Count - 1
                                            KesilenGidenKenar.PolyKenar = True
                                            KesilenGidenKenar.DisKenar = True
                                            KesilenGidenKenar.KenarPolyNo = CizilenPolygonNo
                                            KesilenGidenKenar.KomsuNo = -5
                                            MuseumPolygonGiden.Add(KesilenGidenKenar)

                                            Dim GidenSonKenar As New Kenar

                                            GidenSonKenar.Uc1NoktaNo = MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo
                                            GidenSonKenar.Uc2NoktaNo = MuseumPolygonGiden(0).Uc1NoktaNo
                                            GidenSonKenar.PolyKenar = True
                                            GidenSonKenar.DisKenar = True
                                            GidenSonKenar.KenarPolyNo = CizilenPolygonNo
                                            GidenSonKenar.KomsudaKacinciKenarNo = 2
                                            MuseumPolygonGiden.Add(GidenSonKenar)

                                            KesilenGelenKenar.Uc1NoktaNo = TotalNoktaList.Count - 1
                                            KesilenGelenKenar.Uc2NoktaNo = MuseumPolygonGelen(0).Uc1NoktaNo
                                            KesilenGelenKenar.PolyKenar = True
                                            KesilenGelenKenar.DisKenar = True
                                            KesilenGelenKenar.KenarPolyNo = CizilenPolygonNo
                                            KesilenGelenKenar.KomsuNo = -5
                                            MuseumPolygonGelen.Insert(0, KesilenGelenKenar)

                                            Dim GelenSonKenar As New Kenar

                                            GelenSonKenar.Uc1NoktaNo = MuseumPolygonGelen(MuseumPolygonGelen.Count - 1).Uc2NoktaNo
                                            GelenSonKenar.Uc2NoktaNo = KesilenGelenKenar.Uc1NoktaNo
                                            GelenSonKenar.KomsudaKacinciKenarNo = 2
                                            GelenSonKenar.PolyKenar = True
                                            GelenSonKenar.DisKenar = True
                                            GelenSonKenar.KenarPolyNo = CizilenPolygonNo
                                            MuseumPolygonGelen.Add(GelenSonKenar)

                                            EarClipping(MuseumPolygonGiden, True, 0, 0, CizilenPolygonNo)
                                            EarClipping(MuseumPolygonGelen, False, 0, 0, CizilenPolygonNo)
                                            MuseumPolygonGiden.Clear()
                                            MuseumPolygonGelen.Clear()

                                            Dim trsKesilenGidenKenar As New Kenar
                                            Dim trsKesilenGelenKenar As New Kenar

                                            trsKesilenGidenKenar.Uc1NoktaNo = KesilenGidenKenar.Uc2NoktaNo
                                            trsKesilenGidenKenar.Uc2NoktaNo = KesilenGidenKenar.Uc1NoktaNo
                                            trsKesilenGidenKenar.PolyKenar = True
                                            trsKesilenGidenKenar.DisKenar = True
                                            trsKesilenGidenKenar.KenarPolyNo = CizilenPolygonNo
                                            trsKesilenGidenKenar.KomsuNo = EarKesisimKenarGidenUcgen
                                            trsKesilenGidenKenar.KomsudaKacinciKenarNo = TotalUcgenList(EarKesisimKenarGidenUcgen).CikilanKenarNo
                                            MuseumPolygonGiden.Add(trsKesilenGidenKenar)

                                            trsKesilenGelenKenar.Uc1NoktaNo = KesilenGelenKenar.Uc2NoktaNo
                                            trsKesilenGelenKenar.Uc2NoktaNo = KesilenGelenKenar.Uc1NoktaNo
                                            trsKesilenGelenKenar.PolyKenar = True
                                            trsKesilenGelenKenar.DisKenar = True
                                            trsKesilenGelenKenar.KenarPolyNo = CizilenPolygonNo
                                            trsKesilenGelenKenar.KomsuNo = EarKesisimKenarGelenUcgen
                                            trsKesilenGelenKenar.KomsudaKacinciKenarNo = TotalUcgenList(EarKesisimKenarGelenUcgen).CikilanKenarNo
                                            MuseumPolygonGelen.Insert(0, trsKesilenGelenKenar)

                                            tmpMuseumPolygonGiden.Clear()
                                            tmpMuseumPolygonGiden.AddRange(MuseumPolygonGiden)
                                            tmpMuseumPolygonGelen.Clear()
                                            tmpMuseumPolygonGelen.AddRange(MuseumPolygonGelen)

                                            istikametList.Clear()

                                        End If
                                        '{
                                        istikametList.Add(tmpKenar.KomsuNo)
                                        TotalUcgenList.Item(tmpKenar.KomsuNo).GirilenKenarNo = tmpKenar.KomsudaKacinciKenarNo
                                        TotalUcgenList.Item(tmpKenar.KomsuNo).GirisPoint = KomsuUcgen.CikisPoint

                                        TmpKenarNo = (tmpKenar.KomsudaKacinciKenarNo + 1) Mod 3
                                        TmpKenarNo2 = (tmpKenar.KomsudaKacinciKenarNo + 2) Mod 3
                                        KesilenKenar = KomsuUcgen.KenarList.Item(TmpKenarNo)
                                        KesilenKenar2 = KomsuUcgen.KenarList.Item(TmpKenarNo2)
                                        KesCev1 = CollKesisimHesapla(KesilenKenar, SonBasilanNokta, TargetNokta.KendiYeri, 0, TotalNoktaList)
                                        KesCev2 = CollKesisimHesapla(KesilenKenar2, SonBasilanNokta, TargetNokta.KendiYeri, 0, TotalNoktaList)
                                        If KesCev1.Durum = 2 Then
                                            'If ClosingPointNo > 0 Then
                                            KomsuUcgen.CikisPoint.X = KesCev1.KesisimNok.X
                                            KomsuUcgen.CikisPoint.Y = KesCev1.KesisimNok.Y
                                            KomsuUcgen.CikilanKenarNo = TmpKenarNo

                                            'End If

                                            tmpKenar = KesilenKenar
                                            TmpKenarNo = TmpKenarNo
                                            KesPoint.X = KesCev1.KesisimNok.X
                                            KesPoint.Y = KesCev1.KesisimNok.Y
                                        ElseIf KesCev2.Durum = 2 Then
                                            'If ClosingPointNo > 0 Then
                                            KomsuUcgen.CikisPoint.X = KesCev2.KesisimNok.X
                                            KomsuUcgen.CikisPoint.Y = KesCev2.KesisimNok.Y
                                            KomsuUcgen.CikilanKenarNo = TmpKenarNo2
                                            'End If

                                            tmpKenar = KesilenKenar2
                                            TmpKenarNo = TmpKenarNo2
                                            KesPoint.X = KesCev2.KesisimNok.X
                                            KesPoint.Y = KesCev2.KesisimNok.Y

                                        Else

                                            Exit Do
                                        End If

                                        If KomsuUcgen.KenarList(KomsuUcgen.CikilanKenarNo).KarsiNoktaNo = MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo Then
                                            MuseumPolygonGiden.Add(KomsuUcgen.KenarList.Item((KomsuUcgen.CikilanKenarNo + 2) Mod 3))
                                        Else
                                            MuseumPolygonGelen.Insert(0, KomsuUcgen.KenarList.Item((KomsuUcgen.CikilanKenarNo + 1) Mod 3))
                                        End If


                                        If PolygonList(CizilenPolygonNo).PolyNoktaList.Count > 0 Then
                                            For KenarSay = 0 To 2
                                                If TotalNoktaList(KomsuUcgen.KenarList(KenarSay).KarsiNoktaNo).AralikList(KomsuUcgen.KenarList(KenarSay).KarsiNoktaAralikNo).Disabled = False Then
                                                    TotalNoktaList(KomsuUcgen.KenarList(KenarSay).KarsiNoktaNo).AralikList(KomsuUcgen.KenarList(KenarSay).KarsiNoktaAralikNo).Disabled = True
                                                    TotalNoktaList(KomsuUcgen.KenarList(KenarSay).KarsiNoktaNo).DisableList.Add(KomsuUcgen.KenarList(KenarSay).KarsiNoktaAralikNo)
                                                End If
                                            Next
                                        End If
                                        If MesafeHesapla(KesPoint, PointKoord) < 0.001 Then
                                            'Normalde yukardaki sorgunun eşitlik sorgusu olması gerekiyor
                                            'ancak geometrik eşitliklerle aritmetik eşitlikler arasındaki düzensizlik ve
                                            'reel sayıların bilgisayarda 64 veya 32 bitle sınırlanıyor olması ve 
                                            'sayı dönüştürmeler sırasındaki yuvarlamalar eşitlik sorgulamalarını bozuyor.
                                            'Beklenmedik durumlarda buna dikkat.
                                            Exit Do
                                            'bu exit do dan önce istikametlist ve museumda son eklenenleri silme gibi 
                                            'bazı değişikliler gerekebilir.
                                        End If
                                    Else
                                        'Exit Do
                                        Exit Sub
                                    End If

                                Loop

                                tmpUcgen = TotalUcgenList(tmpKenar.KomsuNo)
                                ActiveUcgenNo = tmpKenar.KomsuNo
                                ModStart = tmpKenar.KomsudaKacinciKenarNo
                                tmpKenar = tmpUcgen.KenarList.Item(ModStart)
                                'KesNok = KesisimHesapla(tmpKenar, TotalNoktaList.Item(tmpKenar.KarsiNoktaNo))KesNok.Durum = 1 And
                                '}
                                If (EskiCiz) Or ClosingPointNo = 0 Then
                                    'Kesişimlerden sonraki üçgeni üçe bölmek için kullanılan kod
                                    'poligon kapatılırken veya kesişim yokken kullanılımıyo
                                    If BasaYakin = False Then
                                        Dim YeniSonBasilanNokta As New Nokta(Me)
                                        YeniSonBasilanNokta.KendiYeri = PointKoord
                                        Dim TmpUcgenList As New List(Of Ucgen)
                                        For KenarSay = ModStart To (ModStart + 2)
                                            ModKenarSay = KenarSay Mod 3
                                            tmpKenar = tmpUcgen.KenarList.Item(ModKenarSay)
                                            ActiveNokta = TotalNoktaList.Item(tmpKenar.KarsiNoktaNo)
                                            ActiveAralik = ActiveNokta.AralikList.Item(tmpKenar.KarsiNoktaAralikNo)
                                            'ActiveAralik.GelenUcNo = ActiveAralik.GelenUcNo
                                            ActiveAralik.GidenUcNo = TotalNoktaList.Count

                                            ActiveAralik.UcgeniciGelenKenarNo = 0
                                            ActiveAralik.UcgeniciGidenKenarNo = 1
                                            ActiveAralik.UcgeniciKarsiKenarNo = 2
                                            If KenarSay <> (ModStart + 2) Then
                                                ActiveAralik.UcgenNo = TotalUcgenList.Count + (KenarSay - ModStart)
                                            End If

                                            Dim YeniAralik As New Aralik
                                            YeniAralik.GelenUcNo = TotalNoktaList.Count
                                            YeniAralik.GidenUcNo = tmpKenar.Uc1NoktaNo
                                            YeniAralik.UcgeniciGelenKenarNo = 2
                                            YeniAralik.UcgeniciGidenKenarNo = 0
                                            YeniAralik.UcgeniciKarsiKenarNo = 1
                                            Select Case (KenarSay - ModStart)
                                                Case 0
                                                    YeniAralik.UcgenNo = TotalUcgenList.Count + 1
                                                Case 1
                                                    YeniAralik.UcgenNo = ActiveUcgenNo
                                                Case 2
                                                    YeniAralik.UcgenNo = TotalUcgenList.Count
                                            End Select
                                            ActiveNokta.AralikList.Add(YeniAralik)

                                            Dim icYeniAralik As New Aralik
                                            icYeniAralik.GelenUcNo = tmpKenar.Uc2NoktaNo
                                            icYeniAralik.GidenUcNo = tmpKenar.Uc1NoktaNo
                                            icYeniAralik.UcgeniciGelenKenarNo = 1
                                            icYeniAralik.UcgeniciGidenKenarNo = 2
                                            icYeniAralik.UcgeniciKarsiKenarNo = 0
                                            If ModKenarSay <> ModStart Then
                                                icYeniAralik.UcgenNo = TotalUcgenList.Count + (KenarSay - ModStart) - 1
                                            ElseIf ModKenarSay = ModStart Then
                                                icYeniAralik.UcgenNo = ActiveUcgenNo
                                            End If
                                            YeniSonBasilanNokta.AralikList.Add(icYeniAralik)

                                            Dim KomsuUcgen0 As Ucgen
                                            If tmpKenar.KomsuNo > -1 Then
                                                KomsuUcgen0 = TotalUcgenList.Item(tmpKenar.KomsuNo)
                                                If ModKenarSay <> ModStart Then
                                                    KomsuUcgen0.KenarList.Item(tmpKenar.KomsudaKacinciKenarNo).KomsuNo = TotalUcgenList.Count + (KenarSay - ModStart) - 1
                                                    KomsuUcgen0.KenarList.Item(tmpKenar.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = 0
                                                End If
                                                If ClosingPointNo = 0 Then
                                                    KomsuUcgen0.KenarList.Item(tmpKenar.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = 0
                                                End If
                                            End If

                                            Dim YeniUcgen As New Ucgen(Me)
                                            Dim YeniKenar0 As New Kenar
                                            YeniKenar0.Uc1NoktaNo = tmpKenar.Uc1NoktaNo
                                            YeniKenar0.Uc2NoktaNo = tmpKenar.Uc2NoktaNo
                                            YeniKenar0.KomsuNo = tmpKenar.KomsuNo
                                            YeniKenar0.KarsiNoktaNo = TotalNoktaList.Count
                                            YeniKenar0.KomsudaKacinciKenarNo = tmpKenar.KomsudaKacinciKenarNo
                                            YeniKenar0.KarsiNoktaAralikNo = KenarSay - ModStart
                                            YeniKenar0.PolyKenar = tmpKenar.PolyKenar
                                            YeniKenar0.DisKenar = tmpKenar.PolyKenar
                                            YeniKenar0.KenarPolyNo = tmpKenar.KenarPolyNo
                                            YeniUcgen.KenarList.Add(YeniKenar0)


                                            Dim YeniKenar1 As New Kenar
                                            YeniKenar1.Uc1NoktaNo = tmpKenar.Uc2NoktaNo
                                            YeniKenar1.Uc2NoktaNo = TotalNoktaList.Count
                                            Select Case (KenarSay - ModStart)
                                                Case 0
                                                    YeniKenar1.KomsuNo = TotalUcgenList.Count
                                                Case 1
                                                    YeniKenar1.KomsuNo = TotalUcgenList.Count + 1

                                                Case 2
                                                    YeniKenar1.KomsuNo = ActiveUcgenNo
                                            End Select
                                            'YeniKenar1.KomsuNo = YeniAralik.UcgenNo
                                            YeniKenar1.KarsiNoktaNo = tmpKenar.Uc1NoktaNo
                                            YeniKenar1.KomsudaKacinciKenarNo = 2
                                            YeniKenar1.KarsiNoktaAralikNo = TotalNoktaList.Item(YeniKenar1.KarsiNoktaNo).AralikList.Count - (((KenarSay - ModStart) * ((KenarSay - ModStart) - 1)) * 0.5)
                                            YeniUcgen.KenarList.Add(YeniKenar1)

                                            Dim YeniKenar2 As New Kenar

                                            YeniKenar2.Uc1NoktaNo = TotalNoktaList.Count
                                            YeniKenar2.Uc2NoktaNo = tmpKenar.Uc1NoktaNo
                                            Select Case (KenarSay - ModStart)
                                                Case 0
                                                    YeniKenar2.KomsuNo = TotalUcgenList.Count + 1
                                                Case 1
                                                    YeniKenar2.KomsuNo = ActiveUcgenNo

                                                Case 2
                                                    YeniKenar2.KomsuNo = TotalUcgenList.Count

                                            End Select
                                            'YeniKenar2.KomsuNo = TotalNoktaList.Item(TotalUcgenList.Item(ActiveUcgenNo).KenarList.Item((KenarSay + 1) Mod 3).KarsiNoktaNo).AralikList.Item(TotalUcgenList.Item(ActiveUcgenNo).KenarList.Item((KenarSay + 1) Mod 3).KarsiNoktaAralikNo).UcgenNo
                                            YeniKenar2.KarsiNoktaNo = tmpKenar.Uc2NoktaNo
                                            YeniKenar2.KomsudaKacinciKenarNo = 1
                                            YeniKenar2.KarsiNoktaAralikNo = tmpUcgen.KenarList.Item((((ModKenarSay + 1) ^ ModKenarSay) + 1) Mod 3).KarsiNoktaAralikNo
                                            YeniUcgen.KenarList.Add(YeniKenar2)
                                            TmpUcgenList.Add(YeniUcgen)
                                        Next

                                        YeniSonBasilanNokta.NoktaPolyNo = PolygonList.Count - 1
                                        YeniSonBasilanNokta.NoktaNo = TotalNoktaList.Count
                                        TotalNoktaList.Add(YeniSonBasilanNokta)
                                        PolygonList(PolygonList.Count - 1).PolyNoktaList.Add(TotalNoktaList.Count - 1)


                                        If ClosingPointNo = 0 Then
                                            ClosingPointNo = TotalNoktaList.Count - 1
                                        End If
                                        tmpUcgen.KenarList.Clear()

                                        tmpUcgen.KenarList.AddRange(TmpUcgenList(0).KenarList)
                                        TotalUcgenList.Add(TmpUcgenList(1))
                                        TotalUcgenList.Add(TmpUcgenList(2))
                                        'Beep()
                                        'yapilacak: burada derleyici bug'u var. alt satıra boş bir else yerleştirip "tmpUcgen.KenarList.Clear()" satırından sonra
                                        'step into veya overla adımladığım zaman "TotalUcgenList.Add(TmpUcgenList(1))" satırındaki TmpUcgenList yapısıyla
                                        '"TotalUcgenList.Add(TmpUcgenList(2))" satırı işletildikten sonraki TmpUcgenList yapısı aynı değil. listeler orjinal .net listesi
                                        'add eventine veya başka bir evente mudahale etmedim. else yi devredışı ettiğimde bu olay olmuyor
                                        'örnek harita bugfound.xml nokta 11 elle basılırken.
                                        'Else
                                        'bıdıbıdı
                                        'MsgBox("hebelek")
                                    End If
                                End If

                            End If


                            Exit For
                        End If
                    End If
                End If
            Next

            '{
            If istikametList.Count > 0 Then

                Dim SonUcgen As Ucgen
                SonUcgen = TotalUcgenList.Item(istikametList.Item(istikametList.Count - 1))
                If BasaYakin = False Then
                    SonUcgen.GirilenKenarNo = 0

                Else


                End If
                Dim SonUcgenTepe, SonUcgenYan1, SonUcgenYan2 As Nokta
                Dim SonUcgenTepeAra, SonUcgenYanAra1, SonUcgenYanAra2 As Aralik
                SonUcgenTepe = TotalNoktaList.Item(SonUcgen.KenarList.Item(SonUcgen.GirilenKenarNo).KarsiNoktaNo)
                SonUcgenTepeAra = SonUcgenTepe.AralikList.Item(SonUcgen.KenarList.Item(SonUcgen.GirilenKenarNo).KarsiNoktaAralikNo)

                SonUcgenYan1 = TotalNoktaList.Item(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGelenKenarNo).Uc1NoktaNo)
                SonUcgenYanAra1 = SonUcgenYan1.AralikList.Item(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo).KarsiNoktaAralikNo)

                SonUcgenYan2 = TotalNoktaList.Item(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo).Uc2NoktaNo)
                SonUcgenYanAra2 = SonUcgenYan2.AralikList.Item(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGelenKenarNo).KarsiNoktaAralikNo)
                If EarCiz Then
                    If PolygonList(CizilenPolygonNo).PolyNoktaList.Count > 0 Then
                        For KenarSay = 0 To 2
                            If TotalNoktaList(SonUcgen.KenarList(KenarSay).KarsiNoktaNo).AralikList(SonUcgen.KenarList(KenarSay).KarsiNoktaAralikNo).Disabled = False Then
                                TotalNoktaList(SonUcgen.KenarList(KenarSay).KarsiNoktaNo).AralikList(SonUcgen.KenarList(KenarSay).KarsiNoktaAralikNo).Disabled = True
                                TotalNoktaList(SonUcgen.KenarList(KenarSay).KarsiNoktaNo).DisableList.Add(SonUcgen.KenarList(KenarSay).KarsiNoktaAralikNo)
                            End If

                        Next
                    End If
                    If SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGelenKenarNo).Uc1NoktaNo = MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo Then
                        MuseumPolygonGiden.Add(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGelenKenarNo))
                    End If
                    Dim GidenSonKenar As New Kenar
                    If MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc1NoktaNo <> MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo And _
                       MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo <> MuseumPolygonGiden(0).Uc1NoktaNo Then

                        GidenSonKenar.Uc1NoktaNo = MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo
                        GidenSonKenar.Uc2NoktaNo = MuseumPolygonGiden(0).Uc1NoktaNo
                        GidenSonKenar.PolyKenar = True
                        GidenSonKenar.DisKenar = True
                        GidenSonKenar.KenarPolyNo = CizilenPolygonNo
                        GidenSonKenar.KomsudaKacinciKenarNo = 2
                        MuseumPolygonGiden.Add(GidenSonKenar)

                    End If
                    tmpMuseumPolygonGiden.Clear()
                    tmpMuseumPolygonGiden.AddRange(MuseumPolygonGiden)
                    TmpUcgenList.Clear()

                    If MuseumPolygonGelen(0).Uc1NoktaNo <> SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo).Uc1NoktaNo And _
                       MuseumPolygonGelen(0).Uc2NoktaNo <> SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo).Uc2NoktaNo Then

                        MuseumPolygonGelen.Insert(0, SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo))

                    End If

                    Dim GelenSonKenar As New Kenar
                    GelenSonKenar.Uc1NoktaNo = GidenSonKenar.Uc2NoktaNo
                    GelenSonKenar.Uc2NoktaNo = GidenSonKenar.Uc1NoktaNo
                    GelenSonKenar.KomsudaKacinciKenarNo = 2
                    GelenSonKenar.PolyKenar = True
                    GelenSonKenar.DisKenar = True
                    GelenSonKenar.KenarPolyNo = CizilenPolygonNo
                    MuseumPolygonGelen.Add(GelenSonKenar)

                    tmpMuseumPolygonGelen.Clear()
                    tmpMuseumPolygonGelen.AddRange(MuseumPolygonGelen)

                    EarClipping(MuseumPolygonGiden, True, 0, 0, CizilenPolygonNo)
                    EarClipping(MuseumPolygonGelen, False, 0, 0, CizilenPolygonNo)

                End If
            End If

            SonBasilanNokta = TotalNoktaList.Item(TotalNoktaList.Count - 1)

            EskiCiz = True


            If BasaYakin Then
                TotalNoktaList.Item(ClosingPointNo).NoktaPolyNo = PolygonList.Count - 1
                TotalNoktaList.Item(ClosingPointNo).NoktaNo = TotalNoktaList.Count
                TotalNoktaList.Add(TotalNoktaList.Item(ClosingPointNo))
                'PolygonList(PolygonList.Count - 1).PolyNoktaList.Add(TotalNoktaList.Count - 1)
                'MoveUcgenle(TotalNoktaList(ClosingPointNo), SonBasilanNokta, ActiveAralik, PolygonList.Count - 1)

                ClosingPointNo = TotalNoktaList.Count - 1

                SelectPolyGons()

                Dim PolyilkNokta, PolySonNokta, PolyNextNokta As Nokta
                Dim PolySonAralik, PolyilkAralik, PolyNextAralik As Aralik
                Dim PolySonUcgen, PolyilkUcgen As Ucgen
                Dim PolySonKenar, PolyilkKenar, PolyNextKenar As Kenar
                PolyilkNokta = TotalNoktaList(PolygonList(PolygonList.Count - 2).PolyNoktaList.Item(0))
                PolySonNokta = TotalNoktaList.Item(TotalNoktaList.Count - 1)
                PolyilkNokta.NoktaNo = PolygonList(PolygonList.Count - 2).PolyNoktaList.Item(0)
                For AralikSay = 0 To PolyilkNokta.AralikList.Count - 1
                    PolySonAralik = PolySonNokta.AralikList(AralikSay)
                    PolySonUcgen = TotalUcgenList(PolySonAralik.UcgenNo)
                    PolySonKenar = PolySonUcgen.KenarList(PolySonAralik.UcgeniciKarsiKenarNo)

                    PolyilkAralik = PolyilkNokta.AralikList(AralikSay)
                    PolyilkUcgen = TotalUcgenList(PolyilkAralik.UcgenNo)
                    PolyilkKenar = PolyilkUcgen.KenarList(PolyilkAralik.UcgeniciKarsiKenarNo)

                    PolySonKenar.KarsiNoktaNo = PolyilkKenar.KarsiNoktaNo
                    For KenarSay = 0 To 2
                        PolyNextKenar = PolyilkUcgen.KenarList(KenarSay)
                        If PolyNextKenar.Uc1NoktaNo = PolySonNokta.NoktaNo Then PolyNextKenar.Uc1NoktaNo = PolyilkNokta.NoktaNo
                        If PolyNextKenar.Uc2NoktaNo = PolySonNokta.NoktaNo Then PolyNextKenar.Uc2NoktaNo = PolyilkNokta.NoktaNo
                        PolyNextNokta = TotalNoktaList(PolyNextKenar.KarsiNoktaNo)
                        PolyNextAralik = PolyNextNokta.AralikList(PolyNextKenar.KarsiNoktaAralikNo)
                        If PolyNextAralik.GelenUcNo = PolySonNokta.NoktaNo Then PolyNextAralik.GelenUcNo = PolyilkNokta.NoktaNo
                        If PolyNextAralik.GidenUcNo = PolySonNokta.NoktaNo Then PolyNextAralik.GidenUcNo = PolyilkNokta.NoktaNo

                    Next
                Next
                PolySonNokta.NoktaNo = PolyilkNokta.NoktaNo
                TotalNoktaList.RemoveAt(TotalNoktaList.Count - 1)
                'PolygonList(PolygonList.Count - 2).PolyNoktaList.RemoveAt(PolygonList(PolygonList.Count - 2).PolyNoktaList.Count - 1)
                ClosingPointNo = 0
                PolygonList(PolygonList.Count - 2).FindPolyCenter()
                PolygonList(PolygonList.Count - 2).WriteMinRotations()
                ClosingPointNo = 0
                EarCiz = False

            Else
                EarCiz = True
            End If
            If EkranYenile Then

            End If
            AramailkNoktasi = SonBasilanNokta
        End Sub

        Public Function EarClipping(ByVal MusePolyGon As List(Of Kenar), ByVal Duz As Boolean, ByVal bakan As Integer, ByVal hedef As Integer, ByVal EarPolygonNo As Integer) As Integer
            Dim KenarNo As Integer = 0
            Dim ModLimit As Integer = MusePolyGon.Count
            Dim SeciliKenar As Kenar
            Dim SonrakiKenar As Kenar
            Dim DahaSonrakiKenar As Kenar
            Dim OncekiKenar As Kenar
            Dim BuyukAci, Darlik As Double
            Dim KucukAci As Double
            Dim BakisAcisi As Double
            Dim EksiMod, EarSonUcgen As Integer
            Dim Sayac As Integer
            If MusePolyGon.Count < 3 Then
                MsgBox("earclipping başlangıç kenar sayısı 3 ten az")
                Exit Function
            End If
            'Dim UcgenSay As Integer
            'Dim K0, K1, K2 As Kenar
            'Dim tmpUcgen As Ucgen
            If Duz = True Then
                Backistikamet = istikametList.Count - 1
                'TotalUcgenTahmin = 0
            Else
                'Backistikamet = Backistikamet - 1
            End If
            Do
                If MusePolyGon.Count < 3 Then Exit Do
                SeciliKenar = MusePolyGon(KenarNo)
                SonrakiKenar = MusePolyGon((KenarNo + 1))
                If SeciliKenar.KenarPolyNo < 0 And SeciliKenar.KomsuNo > -1 Then
                    SeciliKenar.KenarPolyNo = TotalUcgenList(SeciliKenar.KomsuNo).KenarList(SeciliKenar.KomsudaKacinciKenarNo).KenarPolyNo
                End If
                If SonrakiKenar.KenarPolyNo < 0 And SonrakiKenar.KomsuNo > -1 Then
                    SonrakiKenar.KenarPolyNo = TotalUcgenList(SonrakiKenar.KomsuNo).KenarList(SonrakiKenar.KomsudaKacinciKenarNo).KenarPolyNo
                End If
                EksiMod = (KenarNo - 1)
                If EksiMod < 0 Then EksiMod = MusePolyGon.Count - 1
                OncekiKenar = MusePolyGon(EksiMod)
                'Darlik = MesafeHesapla(PointLineIntsct2(TotalNoktaList(SeciliKenar.Uc1NoktaNo).KendiYeri, TotalNoktaList(SonrakiKenar.Uc2NoktaNo).KendiYeri, TotalNoktaList(SeciliKenar.Uc2NoktaNo).KendiYeri).KesisimNok, TotalNoktaList(SeciliKenar.Uc2NoktaNo).KendiYeri)
                'Burada bağlanan son kenarla museumların ilk eklenen kenarları arasında geniş açı olma olasılığı olmadığından
                'aşağıdaki açı düzeneğiyle işe başlanıp devam ediliyor
                KucukAci = AciBul(TotalNoktaList(SeciliKenar.Uc1NoktaNo).KendiYeri, TotalNoktaList(OncekiKenar.Uc1NoktaNo).KendiYeri)
                BuyukAci = AciBul(TotalNoktaList(SeciliKenar.Uc1NoktaNo).KendiYeri, TotalNoktaList(SeciliKenar.Uc2NoktaNo).KendiYeri)
                BakisAcisi = AciBul(TotalNoktaList(SeciliKenar.Uc1NoktaNo).KendiYeri, TotalNoktaList(SonrakiKenar.Uc2NoktaNo).KendiYeri)

                Dim EarAngle, invEarangle As Double
                EarAngle = GetAngle(TotalNoktaList(SonrakiKenar.Uc2NoktaNo).KendiYeri, TotalNoktaList(SeciliKenar.Uc2NoktaNo).KendiYeri, TotalNoktaList(SeciliKenar.Uc1NoktaNo).KendiYeri)
                'testcode start
                'invEarangle = GetAngle(TotalNoktaList(SeciliKenar.Uc1NoktaNo).KendiYeri, TotalNoktaList(SeciliKenar.Uc2NoktaNo).KendiYeri, TotalNoktaList(SonrakiKenar.Uc2NoktaNo).KendiYeri)
                'testcode finish
                If BuyukAci < KucukAci Then BuyukAci = BuyukAci + 360
                If BakisAcisi < KucukAci Then BakisAcisi = BakisAcisi + 360


                Dim Kenar1 As New Kenar
                Dim Kenar2 As New Kenar
                Dim Kenar0 As New Kenar
                Kenar1 = SeciliKenar
                Kenar2 = SonrakiKenar

                Kenar0.Uc1NoktaNo = Kenar1.Uc1NoktaNo
                Kenar0.Uc2NoktaNo = Kenar2.Uc2NoktaNo

                Dim insideTest As New KesisimCevap
                insideTest = CollKesisimHesapla(Kenar0, TotalNoktaList(OncekiKenar.Uc1NoktaNo), TotalNoktaList(SeciliKenar.Uc2NoktaNo).KendiYeri, 0, TotalNoktaList)


                If (BakisAcisi <= BuyukAci And EarAngle <= 180.0F) Or (BakisAcisi <= BuyukAci And insideTest.Durum = 0 And (EarAngle < 180.0F)) Or (MusePolyGon.Count = 3) Then
                    'If (insideTest.Durum = 0) Then
                    '    Beep()
                    '    'FatalError = True
                    'End If
                    Dim YeniUcgen As New Ucgen(Me)

                    YeniUcgen.KenarList.Add(Kenar1) '0
                    YeniUcgen.KenarList.Add(Kenar2) '1
                    YeniUcgen.KenarList.Add(New Kenar) '2

                    YeniUcgen.KenarList(2).Uc1NoktaNo = Kenar0.Uc2NoktaNo
                    YeniUcgen.KenarList(2).Uc2NoktaNo = Kenar0.Uc1NoktaNo
                    If KenarNo + 2 < MusePolyGon.Count Then
                        DahaSonrakiKenar = MusePolyGon((KenarNo + 2))
                    Else
                        DahaSonrakiKenar = MusePolyGon((KenarNo + 1))
                    End If


                    If (SonrakiKenar.Uc1NoktaNo = DahaSonrakiKenar.Uc2NoktaNo And SonrakiKenar.Uc2NoktaNo = DahaSonrakiKenar.Uc1NoktaNo) Or _
                       (SonrakiKenar.Uc2NoktaNo = DahaSonrakiKenar.Uc2NoktaNo And SonrakiKenar.Uc1NoktaNo = DahaSonrakiKenar.Uc1NoktaNo) Then
                        SonrakiKenar.KomsuNo = -1
                        'SonrakiKenar.KomsudaKacinciKenarNo = 1
                    End If

                    If SeciliKenar.KenarPolyNo = SonrakiKenar.KenarPolyNo Then
                        'If SeciliKenar.KenarPolyNo = MusePolyGon(MusePolyGon.Count - 1).KenarPolyNo Then
                        Kenar0.KenarPolyNo = SonrakiKenar.KenarPolyNo
                        YeniUcgen.KenarList(2).KenarPolyNo = SonrakiKenar.KenarPolyNo
                        'End If
                    End If
                    TmpUcgenList.Add(YeniUcgen)
                    EarSonUcgen = EarBagYaz(YeniUcgen, Duz)

                    Kenar0.KomsuNo = EarSonUcgen
                    Kenar0.KomsudaKacinciKenarNo = 2


                    If (SonrakiKenar.Uc1NoktaNo = DahaSonrakiKenar.Uc2NoktaNo And SonrakiKenar.Uc2NoktaNo = DahaSonrakiKenar.Uc1NoktaNo) Or _
                        (SonrakiKenar.Uc2NoktaNo = DahaSonrakiKenar.Uc2NoktaNo And SonrakiKenar.Uc1NoktaNo = DahaSonrakiKenar.Uc1NoktaNo) Then
                        DahaSonrakiKenar.KomsuNo = EarSonUcgen
                        DahaSonrakiKenar.KomsudaKacinciKenarNo = 1
                    End If


                    MusePolyGon(KenarNo) = Kenar0
                    MusePolyGon.RemoveAt((KenarNo + 1))
                    ModLimit = MusePolyGon.Count
                    KenarNo = KenarNo - 1

                Else
                    KenarNo = KenarNo + 1
                End If

                Sayac = Sayac + 1
                If Sayac >= 100 Then

                    Beep()


                    MsgBox("Hata" + bakan.ToString + "-to-" + hedef.ToString)

                    Exit Function
                End If
                If KenarNo >= ModLimit - 1 Or KenarNo < 0 Then KenarNo = 0
            Loop

            If Duz = True Then
                GidenMuseumSonUcgen = EarSonUcgen
            Else
                TotalUcgenList(EarSonUcgen).KenarList(2).KomsuNo = GidenMuseumSonUcgen
                TotalUcgenList(EarSonUcgen).KenarList(2).KomsudaKacinciKenarNo = 2

                TotalUcgenList(GidenMuseumSonUcgen).KenarList(2).KomsuNo = EarSonUcgen
                TotalUcgenList(GidenMuseumSonUcgen).KenarList(2).KomsudaKacinciKenarNo = 2
                'If CollTest = False Then
                TotalUcgenList(EarSonUcgen).KenarList(2).PolyKenar = True
                TotalUcgenList(EarSonUcgen).KenarList(2).DisKenar = True
                TotalUcgenList(EarSonUcgen).KenarList(2).KenarPolyNo = EarPolygonNo
                TotalUcgenList(GidenMuseumSonUcgen).KenarList(2).PolyKenar = True
                TotalUcgenList(GidenMuseumSonUcgen).KenarList(2).DisKenar = True
                TotalUcgenList(GidenMuseumSonUcgen).KenarList(2).KenarPolyNo = EarPolygonNo
                'End If

            End If
            Return EarSonUcgen
            'PictureBox2.Refresh()
            'Button2.Text = TmpUcgenList.Count.ToString
        End Function

        Public Function EarBagYaz(ByVal RefUcgen As Ucgen, ByVal Duz As Boolean) As Integer
            Dim K0, K1, K2 As Kenar
            Dim tmpucgen As Ucgen
            Dim EarSonUcgen As Integer
            tmpucgen = RefUcgen
            K0 = tmpucgen.KenarList(0)
            K1 = tmpucgen.KenarList(1)
            K2 = tmpucgen.KenarList(2)

            K0.KarsiNoktaNo = K1.Uc2NoktaNo
            If TotalNoktaList(K0.KarsiNoktaNo).DisableList.Count > 0 Then
                K0.KarsiNoktaAralikNo = TotalNoktaList(K0.KarsiNoktaNo).DisableList(TotalNoktaList(K0.KarsiNoktaNo).DisableList.Count - 1)
                TotalNoktaList(K0.KarsiNoktaNo).DisableList.RemoveAt(TotalNoktaList(K0.KarsiNoktaNo).DisableList.Count - 1)
                TotalNoktaList(K0.KarsiNoktaNo).AralikList(K0.KarsiNoktaAralikNo).Disabled = False
            Else
                Dim YeniAralik0 As New Aralik
                TotalNoktaList(K0.KarsiNoktaNo).AralikList.Add(YeniAralik0)
                K0.KarsiNoktaAralikNo = TotalNoktaList(K0.KarsiNoktaNo).AralikList.Count - 1
            End If
            With TotalNoktaList(K0.KarsiNoktaNo).AralikList(K0.KarsiNoktaAralikNo)
                .Disabled = False
                .GelenUcNo = K0.Uc2NoktaNo
                .GidenUcNo = K0.Uc1NoktaNo
                .UcgeniciGelenKenarNo = 1
                .UcgeniciGidenKenarNo = 2
                .UcgeniciKarsiKenarNo = 0
                '.UcgenNo = istikametList(Backistikamet)
            End With

            K1.KarsiNoktaNo = K2.Uc2NoktaNo
            If TotalNoktaList(K1.KarsiNoktaNo).DisableList.Count > 0 Then
                K1.KarsiNoktaAralikNo = TotalNoktaList(K1.KarsiNoktaNo).DisableList(TotalNoktaList(K1.KarsiNoktaNo).DisableList.Count - 1)
                TotalNoktaList(K1.KarsiNoktaNo).DisableList.RemoveAt(TotalNoktaList(K1.KarsiNoktaNo).DisableList.Count - 1)
                TotalNoktaList(K1.KarsiNoktaNo).AralikList(K1.KarsiNoktaAralikNo).Disabled = False
            Else
                Dim YeniAralik1 As New Aralik
                TotalNoktaList(K1.KarsiNoktaNo).AralikList.Add(YeniAralik1)
                K1.KarsiNoktaAralikNo = TotalNoktaList(K1.KarsiNoktaNo).AralikList.Count - 1
            End If
            With TotalNoktaList(K1.KarsiNoktaNo).AralikList(K1.KarsiNoktaAralikNo)
                .Disabled = False
                .GelenUcNo = K1.Uc2NoktaNo
                .GidenUcNo = K1.Uc1NoktaNo
                .UcgeniciGelenKenarNo = 2
                .UcgeniciGidenKenarNo = 0
                .UcgeniciKarsiKenarNo = 1
                '.UcgenNo = istikametList(Backistikamet)
            End With

            K2.KarsiNoktaNo = K0.Uc2NoktaNo
            If TotalNoktaList(K2.KarsiNoktaNo).DisableList.Count > 0 Then
                K2.KarsiNoktaAralikNo = TotalNoktaList(K2.KarsiNoktaNo).DisableList(TotalNoktaList(K2.KarsiNoktaNo).DisableList.Count - 1)
                TotalNoktaList(K2.KarsiNoktaNo).DisableList.RemoveAt(TotalNoktaList(K2.KarsiNoktaNo).DisableList.Count - 1)
                TotalNoktaList(K2.KarsiNoktaNo).AralikList(K2.KarsiNoktaAralikNo).Disabled = False
            Else
                Dim YeniAralik2 As New Aralik
                TotalNoktaList(K2.KarsiNoktaNo).AralikList.Add(YeniAralik2)
                K2.KarsiNoktaAralikNo = TotalNoktaList(K2.KarsiNoktaNo).AralikList.Count - 1
            End If
            With TotalNoktaList(K2.KarsiNoktaNo).AralikList(K2.KarsiNoktaAralikNo)
                .Disabled = False
                .GelenUcNo = K2.Uc2NoktaNo
                .GidenUcNo = K2.Uc1NoktaNo
                .UcgeniciGelenKenarNo = 0
                .UcgeniciGidenKenarNo = 1
                .UcgeniciKarsiKenarNo = 2
                '.UcgenNo = istikametList(Backistikamet)
            End With

            If Backistikamet > -1 Then
                EarSonUcgen = istikametList(Backistikamet)
                TotalNoktaList(K0.KarsiNoktaNo).AralikList(K0.KarsiNoktaAralikNo).UcgenNo = EarSonUcgen
                TotalNoktaList(K1.KarsiNoktaNo).AralikList(K1.KarsiNoktaAralikNo).UcgenNo = EarSonUcgen
                TotalNoktaList(K2.KarsiNoktaNo).AralikList(K2.KarsiNoktaAralikNo).UcgenNo = EarSonUcgen
                TotalUcgenList.Item(EarSonUcgen).KenarList.Clear()
                TotalUcgenList.Item(EarSonUcgen).KenarList.AddRange(tmpucgen.KenarList)
                'MsgBox("NoktaNo: " + K0.KarsiNoktaNo.ToString + " AralıkNo: " + K0.KarsiNoktaAralikNo.ToString + " AralıkDisabled: " + TotalNoktaList(K0.KarsiNoktaNo).AralikList(K0.KarsiNoktaAralikNo).Disabled.ToString _
                '+ " GidenUcNoktaNo:" + TotalNoktaList(K0.KarsiNoktaNo).AralikList(K0.KarsiNoktaAralikNo).GidenUcNo.ToString _
                '+ " GelenUcNoktaNo:" + TotalNoktaList(K0.KarsiNoktaNo).AralikList(K0.KarsiNoktaAralikNo).GelenUcNo.ToString _
                '+ " ÜçgenNo:" + EarSonUcgen.ToString)
            Else
                EarSonUcgen = TotalUcgenList.Count
                TotalNoktaList(K0.KarsiNoktaNo).AralikList(K0.KarsiNoktaAralikNo).UcgenNo = EarSonUcgen
                TotalNoktaList(K1.KarsiNoktaNo).AralikList(K1.KarsiNoktaAralikNo).UcgenNo = EarSonUcgen
                TotalNoktaList(K2.KarsiNoktaNo).AralikList(K2.KarsiNoktaAralikNo).UcgenNo = EarSonUcgen
                TotalUcgenList.Add(tmpucgen)

            End If


            If K0.KomsuNo = -5 Then
                If Duz = True Then
                    EarKesisimKenarGidenUcgen = EarSonUcgen
                    TotalUcgenList(EarKesisimKenarGidenUcgen).CikilanKenarNo = 0
                Else
                    EarKesisimKenarGelenUcgen = EarSonUcgen
                    TotalUcgenList(EarKesisimKenarGelenUcgen).CikilanKenarNo = 0

                End If
            End If

            If K1.KomsuNo = -5 Then
                If Duz = True Then
                    EarKesisimKenarGidenUcgen = EarSonUcgen
                    TotalUcgenList(EarKesisimKenarGidenUcgen).CikilanKenarNo = 1
                Else
                    EarKesisimKenarGelenUcgen = EarSonUcgen
                    TotalUcgenList(EarKesisimKenarGelenUcgen).CikilanKenarNo = 1
                End If
            End If

            If K0.KomsuNo > -1 Then
                TotalUcgenList(K0.KomsuNo).KenarList(K0.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = 0
                TotalUcgenList(K0.KomsuNo).KenarList(K0.KomsudaKacinciKenarNo).KomsuNo = EarSonUcgen
                K0.KenarPolyNo = TotalUcgenList(K0.KomsuNo).KenarList(K0.KomsudaKacinciKenarNo).KenarPolyNo
            End If


            If K1.KomsuNo > -1 Then
                TotalUcgenList(K1.KomsuNo).KenarList(K1.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = 1
                TotalUcgenList(K1.KomsuNo).KenarList(K1.KomsudaKacinciKenarNo).KomsuNo = EarSonUcgen
                K1.KenarPolyNo = TotalUcgenList(K1.KomsuNo).KenarList(K1.KomsudaKacinciKenarNo).KenarPolyNo
            End If


            Backistikamet = Backistikamet - 1
            Return EarSonUcgen
        End Function

        Public Sub SelectPolyGons()
            Dim SifirUcgeni, ActiveTestUcgen, Mod0U, Mod1U, Mod2U As Ucgen
            Dim KenarAl As Byte
            Dim DoldurmaTestList As New List(Of Integer)
            Dim TmpDoldurmaTestList As New List(Of Integer)
            Dim NoktaSay, DUcgenNo, AralikSay As Integer
            Dim SelIlkNokta As Nokta
            Dim SelIlkAralik As Aralik
            For NoktaSay = 0 To TotalNoktaList.Count - 1
                SelIlkNokta = TotalNoktaList(NoktaSay)
                For AralikSay = 0 To SelIlkNokta.AralikList.Count - 1
                    If SelIlkNokta.AralikList(AralikSay).Disabled = False Then
                        SelIlkAralik = SelIlkNokta.AralikList(AralikSay)
                        SifirUcgeni = TotalUcgenList(SelIlkAralik.UcgenNo)
                        Exit For
                    End If
                Next
                If SifirUcgeni IsNot (Nothing) Then
                    Exit For
                End If
            Next


            For KenarAl = 0 To 2
                If SifirUcgeni.KenarList(KenarAl).KomsuNo > -1 Then
                    DoldurmaTestList.Add(SifirUcgeni.KenarList(KenarAl).KomsuNo)
                    TotalUcgenList(SifirUcgeni.KenarList(KenarAl).KomsuNo).DoldurmaKenari = SifirUcgeni.KenarList(KenarAl).KomsudaKacinciKenarNo
                End If
            Next
            SifirUcgeni.islemGordu = True
            Do
                TmpDoldurmaTestList.Clear()
                For DUcgenNo = 0 To DoldurmaTestList.Count - 1
                    ActiveTestUcgen = TotalUcgenList(DoldurmaTestList(DUcgenNo))
                    If ActiveTestUcgen.islemGordu = False Then
                        If ActiveTestUcgen.KenarList(ActiveTestUcgen.DoldurmaKenari).PolyKenar = True Then

                            ActiveTestUcgen.KenarList(ActiveTestUcgen.DoldurmaKenari).PolyKenar = False
                            Mod0U = TotalUcgenList(ActiveTestUcgen.KenarList(ActiveTestUcgen.DoldurmaKenari).KomsuNo)
                            Mod0U.KenarList(ActiveTestUcgen.KenarList(ActiveTestUcgen.DoldurmaKenari).KomsudaKacinciKenarNo).PolyKenar = ActiveTestUcgen.KenarList(ActiveTestUcgen.DoldurmaKenari).PolyKenar

                            ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 1) Mod 3).PolyKenar = Not (ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 1) Mod 3).PolyKenar)
                            Mod1U = TotalUcgenList(ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 1) Mod 3).KomsuNo)
                            Mod1U.KenarList(ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 1) Mod 3).KomsudaKacinciKenarNo).PolyKenar = ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 1) Mod 3).PolyKenar


                            ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 2) Mod 3).PolyKenar = Not (ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 2) Mod 3).PolyKenar)
                            Mod2U = TotalUcgenList(ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 2) Mod 3).KomsuNo)
                            Mod2U.KenarList(ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 2) Mod 3).KomsudaKacinciKenarNo).PolyKenar = ActiveTestUcgen.KenarList((ActiveTestUcgen.DoldurmaKenari + 2) Mod 3).PolyKenar


                            ActiveTestUcgen.Dolu = True

                            'ActivePolygon.UcgenList.Add(DUcgenNo)
                        End If
                        For KenarAl = 0 To 2
                            If ActiveTestUcgen.KenarList(KenarAl).KomsuNo > -1 Then
                                If TotalUcgenList(ActiveTestUcgen.KenarList(KenarAl).KomsuNo).islemGordu = False Then
                                    TmpDoldurmaTestList.Add(ActiveTestUcgen.KenarList(KenarAl).KomsuNo)
                                    TotalUcgenList(ActiveTestUcgen.KenarList(KenarAl).KomsuNo).DoldurmaKenari = ActiveTestUcgen.KenarList(KenarAl).KomsudaKacinciKenarNo
                                End If
                            End If

                        Next
                        ActiveTestUcgen.islemGordu = True
                    End If
                    For KenarAl = 0 To 2
                        If ActiveTestUcgen.KenarList(KenarAl).KenarPolyNo > -1 And ActiveTestUcgen.Dolu = True Then
                            ActiveTestUcgen.UcgenPolyNo = ActiveTestUcgen.KenarList(KenarAl).KenarPolyNo
                            'PolygonList(ActiveTestUcgen.UcgenPolyNo).UcgenList.Add(DoldurmaTestList(DUcgenNo))
                            ActiveTestUcgen.KenarList(0).KenarPolyNo = ActiveTestUcgen.UcgenPolyNo
                            ActivePolygon = PolygonList(ActiveTestUcgen.UcgenPolyNo)
                            If ActiveTestUcgen.PolyEklendi = False Then
                                ActivePolygon.UcgenList.Add(DoldurmaTestList(DUcgenNo))
                                ActiveTestUcgen.PolyEklendi = True
                                ActiveTestUcgen.PolyListSira = ActivePolygon.UcgenList.Count - 1
                            End If
                            If (ActiveTestUcgen.KenarList(0).KomsuNo) > -1 Then
                                Mod0U = TotalUcgenList(ActiveTestUcgen.KenarList(0).KomsuNo)
                                Mod0U.KenarList(ActiveTestUcgen.KenarList(0).KomsudaKacinciKenarNo).KenarPolyNo = ActiveTestUcgen.UcgenPolyNo
                                If Mod0U.Dolu = True Then
                                    Mod0U.UcgenPolyNo = ActiveTestUcgen.UcgenPolyNo
                                    If Mod0U.PolyEklendi = False Then
                                        ActivePolygon.UcgenList.Add(ActiveTestUcgen.KenarList(0).KomsuNo)
                                        Mod0U.PolyEklendi = True
                                        Mod0U.PolyListSira = ActivePolygon.UcgenList.Count - 1
                                    End If
                                End If
                            End If
                            ActiveTestUcgen.KenarList(1).KenarPolyNo = ActiveTestUcgen.UcgenPolyNo
                            Mod1U = TotalUcgenList(ActiveTestUcgen.KenarList(1).KomsuNo)
                            Mod1U.KenarList(ActiveTestUcgen.KenarList(1).KomsudaKacinciKenarNo).KenarPolyNo = ActiveTestUcgen.UcgenPolyNo
                            If Mod1U.Dolu = True Then
                                Mod1U.UcgenPolyNo = ActiveTestUcgen.UcgenPolyNo
                                If Mod1U.PolyEklendi = False Then
                                    ActivePolygon.UcgenList.Add(ActiveTestUcgen.KenarList(1).KomsuNo)
                                    Mod1U.PolyEklendi = True
                                    Mod1U.PolyListSira = ActivePolygon.UcgenList.Count - 1
                                End If
                            End If


                            ActiveTestUcgen.KenarList(2).KenarPolyNo = ActiveTestUcgen.UcgenPolyNo
                            Mod2U = TotalUcgenList(ActiveTestUcgen.KenarList(2).KomsuNo)
                            Mod2U.KenarList(ActiveTestUcgen.KenarList(2).KomsudaKacinciKenarNo).KenarPolyNo = ActiveTestUcgen.UcgenPolyNo
                            If Mod2U.Dolu = True Then
                                Mod2U.UcgenPolyNo = ActiveTestUcgen.UcgenPolyNo
                                If Mod2U.PolyEklendi = False Then
                                    ActivePolygon.UcgenList.Add(ActiveTestUcgen.KenarList(2).KomsuNo)
                                    Mod2U.PolyEklendi = True
                                    Mod2U.PolyListSira = ActivePolygon.UcgenList.Count - 1
                                End If
                            End If

                            Exit For
                        End If
                    Next
                Next
                DoldurmaTestList.Clear()
                DoldurmaTestList.AddRange(TmpDoldurmaTestList)
                If DoldurmaTestList.Count < 1 Then Exit Do
            Loop

            For DUcgenNo = 0 To TotalUcgenList.Count - 1
                TotalUcgenList(DUcgenNo).islemGordu = False
            Next
            Dim NextPolygon As New Polygon(Me)

            PolygonList.Add(NextPolygon)
            ActivePolygon = PolygonList(PolygonList.Count - 1)
            'CizilenPolygonNo = CizilenPolygonNo + 1

        End Sub

        Public Sub FreeNokta(ByVal HangiNokta As Nokta, ByVal YeniLoc As PointF, ByVal HangiUcgen As Ucgen, ByVal HangiUcgenNo As Integer)
            Dim tmpFreeUcgenList As New List(Of Ucgen)
            Dim FreeUcgenSay, FreeKenarSay, FreeSonAralikNo, KenarPolyNo As Integer
            KenarPolyNo = -1
            tmpFreeUcgenList.Clear()
            'yapılacak: bu prosedürdeki tüm işler tek döngüde bitirilmeye çalışılacak
            'veya her seri işlem için farklı döngü açmakdan doğan zaman farkı araştırılacak
            HangiNokta.KendiYeri = YeniLoc
            For FreeKenarSay = 0 To 2
                TotalNoktaList(HangiUcgen.KenarList(FreeKenarSay).KarsiNoktaNo).AralikList(HangiUcgen.KenarList(FreeKenarSay).KarsiNoktaAralikNo).Disabled = True
                TotalNoktaList(HangiUcgen.KenarList(FreeKenarSay).KarsiNoktaNo).DisableList.Add(HangiUcgen.KenarList(FreeKenarSay).KarsiNoktaAralikNo)
            Next
            If HangiUcgen.KenarList(0).KenarPolyNo > -1 Then
                If HangiUcgen.KenarList(1).KenarPolyNo > -1 Then
                    If HangiUcgen.KenarList(2).KenarPolyNo > -1 Then
                        If HangiUcgen.KenarList(0).KenarPolyNo = HangiUcgen.KenarList(1).KenarPolyNo Then
                            If HangiUcgen.KenarList(0).KenarPolyNo = HangiUcgen.KenarList(2).KenarPolyNo Then
                                KenarPolyNo = HangiUcgen.KenarList(0).KenarPolyNo
                            End If
                        End If
                    End If
                End If
            End If
            For FreeKenarSay = 0 To 2
                Dim FreeUcgen As New Ucgen(Me)
                'freekenar0 ve FreeAralik0 ın tüm bilgileri burada verilebilir
                Dim FreeKenar0 As Kenar
                FreeKenar0 = HangiUcgen.KenarList(FreeKenarSay)
                FreeKenar0.KarsiNoktaNo = HangiNokta.NoktaNo
                If FreeKenar0.KomsuNo > -1 Then
                    TotalUcgenList(FreeKenar0.KomsuNo).KenarList(FreeKenar0.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = 0
                End If


                Dim FreeAralik0 As New Aralik
                FreeAralik0.GelenUcNo = FreeKenar0.Uc2NoktaNo
                FreeAralik0.GidenUcNo = FreeKenar0.Uc1NoktaNo


                FreeAralik0.UcgeniciKarsiKenarNo = 0
                FreeAralik0.UcgeniciGelenKenarNo = 1
                FreeAralik0.UcgeniciGidenKenarNo = 2
                HangiNokta.AralikList.Add(FreeAralik0)
                FreeKenar0.KarsiNoktaAralikNo = FreeKenarSay
                FreeUcgen.KenarList.Add(FreeKenar0)

                'tüm aralik.üçgen noları sonradan yazılacak

                'freekenar1 in komşu kenarının komşukenarno ve komşuno sonradan yazılacak
                Dim FreeKenar1 As New Kenar
                FreeKenar1.Uc1NoktaNo = FreeKenar0.Uc2NoktaNo
                FreeKenar1.Uc2NoktaNo = HangiNokta.NoktaNo
                FreeKenar1.KarsiNoktaNo = FreeKenar0.Uc1NoktaNo

                FreeKenar1.KenarPolyNo = KenarPolyNo


                Dim FreeNokta1 As Nokta = TotalNoktaList(FreeKenar1.KarsiNoktaNo)

                Dim FreeAralik1 As Aralik
                If FreeNokta1.DisableList.Count > 0 Then
                    FreeSonAralikNo = FreeNokta1.DisableList(FreeNokta1.DisableList.Count - 1)
                    FreeAralik1 = FreeNokta1.AralikList(FreeNokta1.DisableList(FreeNokta1.DisableList.Count - 1))
                    FreeAralik1.Disabled = False
                    FreeNokta1.DisableList.RemoveAt(FreeNokta1.DisableList.Count - 1)
                Else
                    FreeAralik1 = New Aralik
                    FreeNokta1.AralikList.Add(FreeAralik1)
                    'FreeAralik1 = FreeNokta1.AralikList(FreeNokta1.AralikList.Count - 1)
                    'yapılacak: üstteki atamanın gerekliği kontrol edilecek
                    FreeSonAralikNo = FreeNokta1.AralikList.Count - 1
                End If
                FreeAralik1.GelenUcNo = HangiNokta.NoktaNo
                FreeAralik1.GidenUcNo = FreeKenar1.Uc1NoktaNo
                FreeAralik1.UcgeniciKarsiKenarNo = 1
                FreeAralik1.UcgeniciGelenKenarNo = 2
                FreeAralik1.UcgeniciGidenKenarNo = 0

                FreeKenar1.KarsiNoktaAralikNo = FreeSonAralikNo
                FreeUcgen.KenarList.Add(FreeKenar1)

                'freekenar2 nin komşu kenarının komşukenarno ve komşuno sonradan yazılacak
                Dim FreeKenar2 As New Kenar
                FreeKenar2.Uc1NoktaNo = HangiNokta.NoktaNo
                FreeKenar2.Uc2NoktaNo = FreeKenar0.Uc1NoktaNo
                FreeKenar2.KarsiNoktaNo = FreeKenar1.Uc1NoktaNo
                FreeKenar2.KenarPolyNo = KenarPolyNo
                Dim FreeNokta2 As Nokta = TotalNoktaList(FreeKenar2.KarsiNoktaNo)

                Dim FreeAralik2 As Aralik
                If FreeNokta2.DisableList.Count > 0 Then
                    FreeSonAralikNo = FreeNokta2.DisableList(FreeNokta2.DisableList.Count - 1)
                    FreeAralik2 = FreeNokta2.AralikList(FreeNokta2.DisableList(FreeNokta2.DisableList.Count - 1))
                    FreeAralik2.Disabled = False
                    FreeNokta2.DisableList.RemoveAt(FreeNokta2.DisableList.Count - 1)
                Else
                    FreeAralik2 = New Aralik
                    FreeNokta2.AralikList.Add(FreeAralik2)
                    'FreeAralik2 = FreeNokta2.AralikList(FreeNokta2.AralikList.Count - 1)
                    FreeSonAralikNo = FreeNokta2.AralikList.Count - 1
                End If
                FreeAralik2.GelenUcNo = FreeKenar2.Uc2NoktaNo
                FreeAralik2.GidenUcNo = HangiNokta.NoktaNo
                FreeAralik2.UcgeniciKarsiKenarNo = 2
                FreeAralik2.UcgeniciGelenKenarNo = 0
                FreeAralik2.UcgeniciGidenKenarNo = 1

                FreeKenar2.KarsiNoktaAralikNo = FreeSonAralikNo
                FreeUcgen.KenarList.Add(FreeKenar2)
                tmpFreeUcgenList.Add(FreeUcgen)
            Next

            tmpFreeUcgenList(0).KendiNo = HangiUcgenNo
            tmpFreeUcgenList(1).KendiNo = TotalUcgenList.Count
            tmpFreeUcgenList(2).KendiNo = TotalUcgenList.Count + 1

            For FreeUcgenSay = 0 To 2
                If tmpFreeUcgenList(FreeUcgenSay).KenarList(0).KomsuNo > -1 Then
                    TotalUcgenList(tmpFreeUcgenList(FreeUcgenSay).KenarList(0).KomsuNo).KenarList(tmpFreeUcgenList(FreeUcgenSay).KenarList(0).KomsudaKacinciKenarNo).KomsuNo = tmpFreeUcgenList(FreeUcgenSay).KendiNo
                End If



                tmpFreeUcgenList(FreeUcgenSay).KenarList(1).KomsuNo = tmpFreeUcgenList((FreeUcgenSay + 1) Mod 3).KendiNo
                tmpFreeUcgenList(FreeUcgenSay).KenarList(1).KomsudaKacinciKenarNo = 2

                tmpFreeUcgenList(FreeUcgenSay).KenarList(2).KomsuNo = tmpFreeUcgenList((FreeUcgenSay + 2) Mod 3).KendiNo
                tmpFreeUcgenList(FreeUcgenSay).KenarList(2).KomsudaKacinciKenarNo = 1

                HangiNokta.AralikList(FreeUcgenSay).UcgenNo = tmpFreeUcgenList(FreeUcgenSay).KendiNo

                'TotalNoktaList(tmpFreeUcgenList(FreeUcgenSay).KenarList(1).KarsiNoktaNo).AralikList(tmpFreeUcgenList(FreeUcgenSay).KenarList(1).KarsiNoktaAralikNo).UcgenNo = tmpFreeUcgenList(FreeUcgenSay).KendiNo
                TotalNoktaList(tmpFreeUcgenList((FreeUcgenSay + 1) Mod 3).KenarList(1).KarsiNoktaNo).AralikList(tmpFreeUcgenList((FreeUcgenSay + 1) Mod 3).KenarList(1).KarsiNoktaAralikNo).UcgenNo = tmpFreeUcgenList((FreeUcgenSay + 1) Mod 3).KendiNo
                TotalNoktaList(tmpFreeUcgenList((FreeUcgenSay + 2) Mod 3).KenarList(2).KarsiNoktaNo).AralikList(tmpFreeUcgenList((FreeUcgenSay + 2) Mod 3).KenarList(2).KarsiNoktaAralikNo).UcgenNo = tmpFreeUcgenList((FreeUcgenSay + 2) Mod 3).KendiNo
            Next
            HangiUcgen.KenarList.Clear()
            HangiUcgen.KenarList.AddRange(tmpFreeUcgenList(0).KenarList)
            TotalUcgenList.Add(tmpFreeUcgenList(1))
            TotalUcgenList.Add(tmpFreeUcgenList(2))

        End Sub

        Public Function KosedenKoseyeBagla(ByVal TargetNokta As Nokta, ByVal LookingNokta As Nokta, ByVal LookAralik As Aralik, ByVal Dolu As Boolean, ByRef kkbAnswer As PointToAnswer, ByVal CizilenPolygonNo As Integer) As PointToAnswer
            Dim tmpUcgen As Ucgen
            Dim tmpKenar As Kenar
            Dim ActiveUcgenNo As Integer
            Dim KomsuUcgen As Ucgen
            Dim KomsuAktifKenar As Kenar
            Dim KesCev1, KesCev2, KesNok As New KesisimCevap
            Dim KesPoint As New PointF
            Dim TmpKenarNo, TmpKenarNo2 As Integer
            Dim KesilenKenar, KesilenKenar2 As Kenar

            MuseumPolygonGiden.Clear()
            MuseumPolygonGelen.Clear()
            TmpUcgenList.Clear()
            ActiveUcgenNo = LookAralik.UcgenNo
            tmpUcgen = TotalUcgenList(ActiveUcgenNo)
            tmpKenar = tmpUcgen.KenarList.Item(LookAralik.UcgeniciKarsiKenarNo)
            istikametList.Clear()

            If TargetNokta Is Nothing Then
                kkbAnswer.Connected = False
                Return kkbAnswer

            End If
            If tmpKenar.Uc1NoktaNo = LookingNokta.NoktaNo Or tmpKenar.Uc2NoktaNo = LookingNokta.NoktaNo Or _
                tmpKenar.Uc1NoktaNo = TargetNokta.NoktaNo Or tmpKenar.Uc2NoktaNo = TargetNokta.NoktaNo Then
                kkbAnswer.Connected = True

            End If
            If tmpKenar.KomsuNo >= 0 And TargetNokta.KendiYeri <> LookingNokta.KendiYeri Then
                KomsuUcgen = TotalUcgenList.Item(tmpKenar.KomsuNo)
                KomsuAktifKenar = KomsuUcgen.KenarList.Item(tmpKenar.KomsudaKacinciKenarNo)

            Else

                TmpUcgenList.Clear()
                istikametList.Clear()
                MuseumPolygonGiden.Clear()
                MuseumPolygonGelen.Clear()
                kkbAnswer.Connected = False
                Return kkbAnswer

            End If

            KesNok = CollKesisimHesapla(tmpKenar, LookingNokta, TargetNokta.KendiYeri, 0, TotalNoktaList)
            kkbAnswer.KesNok = KesNok.KesisimNok
            If KesNok.Durum > 0 And TargetNokta IsNot Nothing Then


                istikametList.Add(ActiveUcgenNo)
                tmpUcgen.CikisPoint.X = KesNok.KesisimNok.X
                tmpUcgen.CikisPoint.Y = KesNok.KesisimNok.Y
                tmpUcgen.CikilanKenarNo = LookAralik.UcgeniciKarsiKenarNo
                TotalUcgenList.Item(tmpKenar.KomsuNo).GirilenKenarNo = tmpKenar.KomsudaKacinciKenarNo
                TotalUcgenList.Item(tmpKenar.KomsuNo).GirisPoint = tmpUcgen.CikisPoint

                MuseumPolygonGiden.Add(tmpUcgen.KenarList(LookAralik.UcgeniciGidenKenarNo))

                MuseumPolygonGelen.Insert(0, tmpUcgen.KenarList(LookAralik.UcgeniciGelenKenarNo))
                KesPoint = tmpUcgen.CikisPoint

                Do
                    If tmpKenar.KomsuNo < 0 Then

                        TmpUcgenList.Clear()
                        istikametList.Clear()
                        MuseumPolygonGiden.Clear()
                        MuseumPolygonGelen.Clear()

                        kkbAnswer.Connected = False
                        Return kkbAnswer

                    Else

                        KomsuUcgen = TotalUcgenList.Item(tmpKenar.KomsuNo)
                        KomsuAktifKenar = KomsuUcgen.KenarList.Item(tmpKenar.KomsudaKacinciKenarNo)



                        If tmpKenar.KomsuNo < 0 Then

                            TmpUcgenList.Clear()
                            istikametList.Clear()
                            MuseumPolygonGiden.Clear()
                            MuseumPolygonGelen.Clear()

                            kkbAnswer.Connected = False
                            Return kkbAnswer

                        End If
                        If istikametList.Count > 0 Then
                            'teorem: üçgen mozaik geometrisi üzerindeki bir doğru,  aynı üçgenden 1 kereden fazla geçemez.
                            'yapilacak: ancak bu döngüden bu şekilde çıkmak bağlama hattı için gereken durumun oluştuğunu göstermez
                            'bu durum muhtemelen sadece istisna kontrolünde kullanılabilir.
                            'gerçek istisna bulunana kadar bu kullanılacak.
                            If tmpKenar.KomsuNo = istikametList(0) Then
                                Beep()
                                'yapilacak: bu ve benzeri durumlar için exception log u tutan bir dosya oluşturulacak.
                                Exit Do
                            End If
                        End If
                        istikametList.Add(tmpKenar.KomsuNo)
                        TotalUcgenList.Item(tmpKenar.KomsuNo).GirilenKenarNo = tmpKenar.KomsudaKacinciKenarNo
                        TotalUcgenList.Item(tmpKenar.KomsuNo).GirisPoint = KomsuUcgen.CikisPoint
                        If KesNok.Durum = 2 Then

                            If ((kkbAnswer.OncekiDoluKenar Is Nothing) And (tmpKenar.KenarPolyNo > -1)) Then
                                kkbAnswer.SonKesilenDoluPoly = tmpKenar.KenarPolyNo
                                kkbAnswer.OncekiDoluKenar = tmpKenar
                            ElseIf ((kkbAnswer.OncekiDoluKenar Is Nothing) And (KomsuAktifKenar.KenarPolyNo > -1)) Then
                                kkbAnswer.SonKesilenDoluPoly = KomsuAktifKenar.KenarPolyNo
                                kkbAnswer.OncekiDoluKenar = KomsuAktifKenar
                            End If
                            If ((kkbAnswer.ilKesilenDiskenar Is Nothing) And ((tmpKenar.PolyKenar = True) Or (tmpKenar.DisKenar = True))) Then
                                kkbAnswer.ilKesilenDiskenar = tmpKenar
                            ElseIf ((kkbAnswer.ilKesilenDiskenar Is Nothing) And ((KomsuAktifKenar.PolyKenar = True) Or (KomsuAktifKenar.DisKenar = True))) Then
                                kkbAnswer.ilKesilenDiskenar = KomsuAktifKenar
                            End If
                            If kkbAnswer.OncekiDoluKenar IsNot Nothing Then
                                TmpUcgenList.Clear()
                                istikametList.Clear()
                                MuseumPolygonGiden.Clear()
                                MuseumPolygonGelen.Clear()

                                kkbAnswer.Connected = False
                                Return kkbAnswer
                            End If
                        End If
                        If TotalNoktaList(KomsuUcgen.KenarList(KomsuUcgen.GirilenKenarNo).KarsiNoktaNo).KendiYeri = TargetNokta.KendiYeri Then
                            Exit Do
                        End If

                        TmpKenarNo = (tmpKenar.KomsudaKacinciKenarNo + 1) Mod 3
                        TmpKenarNo2 = (tmpKenar.KomsudaKacinciKenarNo + 2) Mod 3

                        KesilenKenar = KomsuUcgen.KenarList.Item(TmpKenarNo)
                        KesilenKenar2 = KomsuUcgen.KenarList.Item(TmpKenarNo2)
                        KesCev1 = CollKesisimHesapla(KesilenKenar, LookingNokta, TargetNokta.KendiYeri, 0, TotalNoktaList)
                        kkbAnswer.KesNok = KesCev1.KesisimNok
                        If KesCev1.Durum = 2 Then

                            KomsuUcgen.CikisPoint.X = KesCev1.KesisimNok.X
                            KomsuUcgen.CikisPoint.Y = KesCev1.KesisimNok.Y
                            KomsuUcgen.CikilanKenarNo = TmpKenarNo
                            tmpKenar = KesilenKenar
                            TmpKenarNo = TmpKenarNo
                            KesPoint.X = KesCev1.KesisimNok.X
                            KesPoint.Y = KesCev1.KesisimNok.Y
                        Else
                            KesCev2 = CollKesisimHesapla(KesilenKenar2, LookingNokta, TargetNokta.KendiYeri, 0, TotalNoktaList)
                            If KesCev2.Durum = 2 Then
                                kkbAnswer.KesNok = KesCev2.KesisimNok
                                KomsuUcgen.CikisPoint.X = KesCev2.KesisimNok.X
                                KomsuUcgen.CikisPoint.Y = KesCev2.KesisimNok.Y
                                KomsuUcgen.CikilanKenarNo = TmpKenarNo2
                                tmpKenar = KesilenKenar2
                                TmpKenarNo = TmpKenarNo2
                                KesPoint.X = KesCev2.KesisimNok.X
                                KesPoint.Y = KesCev2.KesisimNok.Y
                            Else
                                Exit Do
                            End If
                        End If
                        'yapilacak: aşağıda test code blok u test amaçlı olarak eklendi sonraki sorgudaki KomsuUcgen 'in atamasının 
                        'yeniden mi yapılacak yoksa KesCev atamasından sonra mı yapılacak bakılması lazım
                        'yapildi: yukardaki durumun şimdi olduğu gibi olması gerekiyor.
                        KomsuAktifKenar = TotalUcgenList.Item(tmpKenar.KomsuNo).KenarList.Item(tmpKenar.KomsudaKacinciKenarNo)

                        If ((kkbAnswer.OncekiDoluKenar Is Nothing) And (tmpKenar.KenarPolyNo > -1)) Then
                            kkbAnswer.SonKesilenDoluPoly = tmpKenar.KenarPolyNo
                            kkbAnswer.OncekiDoluKenar = tmpKenar
                        ElseIf ((kkbAnswer.OncekiDoluKenar Is Nothing) And (KomsuAktifKenar.KenarPolyNo > -1)) Then
                            kkbAnswer.SonKesilenDoluPoly = KomsuAktifKenar.KenarPolyNo
                            kkbAnswer.OncekiDoluKenar = KomsuAktifKenar
                        End If
                        If ((kkbAnswer.ilKesilenDiskenar Is Nothing) And ((tmpKenar.PolyKenar = True) Or (tmpKenar.DisKenar = True))) Then
                            kkbAnswer.ilKesilenDiskenar = tmpKenar
                        ElseIf ((kkbAnswer.ilKesilenDiskenar Is Nothing) And ((KomsuAktifKenar.PolyKenar = True) Or (KomsuAktifKenar.DisKenar = True))) Then
                            'yapilacak: bu durumda komşu üçgen veya poligon numarası OncekiDoluKenar dan alınmamalı
                            kkbAnswer.ilKesilenDiskenar = KomsuAktifKenar
                        End If
                        If kkbAnswer.OncekiDoluKenar IsNot Nothing Then
                            TmpUcgenList.Clear()
                            istikametList.Clear()
                            MuseumPolygonGiden.Clear()
                            MuseumPolygonGelen.Clear()

                            kkbAnswer.Connected = False
                            Return kkbAnswer
                        End If

                        If KomsuUcgen.KenarList(KomsuUcgen.CikilanKenarNo).KarsiNoktaNo = MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo Then
                            MuseumPolygonGiden.Add(KomsuUcgen.KenarList.Item((KomsuUcgen.CikilanKenarNo + 2) Mod 3))
                        Else
                            MuseumPolygonGelen.Insert(0, KomsuUcgen.KenarList.Item((KomsuUcgen.CikilanKenarNo + 1) Mod 3))
                        End If

                    End If
                Loop

            Else

                TmpUcgenList.Clear()
                istikametList.Clear()
                MuseumPolygonGiden.Clear()
                MuseumPolygonGelen.Clear()

                kkbAnswer.Connected = False
                Return kkbAnswer

            End If

            If istikametList.Count > 0 Then

                Dim SonUcgen As Ucgen
                SonUcgen = TotalUcgenList.Item(istikametList.Item(istikametList.Count - 1))

                Dim SonUcgenTepe, SonUcgenYan1, SonUcgenYan2 As Nokta
                Dim SonUcgenTepeAra, SonUcgenYanAra1, SonUcgenYanAra2 As Aralik
                SonUcgenTepe = TotalNoktaList.Item(SonUcgen.KenarList.Item(SonUcgen.GirilenKenarNo).KarsiNoktaNo)
                If SonUcgenTepe.NoktaNo <> TargetNokta.NoktaNo Then
                    TmpUcgenList.Clear()
                    istikametList.Clear()
                    MuseumPolygonGiden.Clear()
                    MuseumPolygonGelen.Clear()

                    kkbAnswer.Connected = False
                    FatalError = True
                    Return kkbAnswer

                End If
                SonUcgenTepeAra = SonUcgenTepe.AralikList.Item(SonUcgen.KenarList.Item(SonUcgen.GirilenKenarNo).KarsiNoktaAralikNo)

                SonUcgenYan1 = TotalNoktaList.Item(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGelenKenarNo).Uc1NoktaNo)
                SonUcgenYanAra1 = SonUcgenYan1.AralikList.Item(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo).KarsiNoktaAralikNo)

                SonUcgenYan2 = TotalNoktaList.Item(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo).Uc2NoktaNo)
                SonUcgenYanAra2 = SonUcgenYan2.AralikList.Item(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGelenKenarNo).KarsiNoktaAralikNo)

                For isucgensira As Integer = 0 To istikametList.Count - 1
                    Dim isucgenno As Integer = istikametList(isucgensira)
                    Dim isucgen = TotalUcgenList(isucgenno)
                    For KenarSay = 0 To 2
                        If TotalNoktaList(isucgen.KenarList(KenarSay).KarsiNoktaNo).AralikList(isucgen.KenarList(KenarSay).KarsiNoktaAralikNo).Disabled = False Then
                            TotalNoktaList(isucgen.KenarList(KenarSay).KarsiNoktaNo).AralikList(isucgen.KenarList(KenarSay).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(isucgen.KenarList(KenarSay).KarsiNoktaNo).DisableList.Add(isucgen.KenarList(KenarSay).KarsiNoktaAralikNo)
                        End If
                    Next
                Next

                If SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGelenKenarNo).Uc1NoktaNo = MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo Then
                    MuseumPolygonGiden.Add(SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGelenKenarNo))
                Else
                    'Beep()
                End If

                Dim GidenSonKenar As New Kenar
                If MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc1NoktaNo <> MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo And _
                   MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo <> MuseumPolygonGiden(0).Uc1NoktaNo Then

                    GidenSonKenar.Uc1NoktaNo = MuseumPolygonGiden(MuseumPolygonGiden.Count - 1).Uc2NoktaNo
                    GidenSonKenar.Uc2NoktaNo = MuseumPolygonGiden(0).Uc1NoktaNo

                    GidenSonKenar.KomsudaKacinciKenarNo = 2
                    If TotalNoktaList(GidenSonKenar.Uc1NoktaNo).NoktaPolyNo = TotalNoktaList(GidenSonKenar.Uc2NoktaNo).NoktaPolyNo Then
                        GidenSonKenar.KenarPolyNo = TotalNoktaList(GidenSonKenar.Uc1NoktaNo).NoktaPolyNo
                    End If
                    MuseumPolygonGiden.Add(GidenSonKenar)

                End If
                tmpMuseumPolygonGiden.Clear()
                tmpMuseumPolygonGiden.AddRange(MuseumPolygonGiden)
                TmpUcgenList.Clear()



                If MuseumPolygonGelen(0).Uc1NoktaNo <> SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo).Uc1NoktaNo And _
                   MuseumPolygonGelen(0).Uc2NoktaNo <> SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo).Uc2NoktaNo Then

                    MuseumPolygonGelen.Insert(0, SonUcgen.KenarList.Item(SonUcgenTepeAra.UcgeniciGidenKenarNo))

                End If

                Dim GelenSonKenar As New Kenar
                GelenSonKenar.Uc1NoktaNo = GidenSonKenar.Uc2NoktaNo
                GelenSonKenar.Uc2NoktaNo = GidenSonKenar.Uc1NoktaNo
                GelenSonKenar.KomsudaKacinciKenarNo = 2
                If TotalNoktaList(GelenSonKenar.Uc1NoktaNo).NoktaPolyNo = TotalNoktaList(GelenSonKenar.Uc2NoktaNo).NoktaPolyNo Then
                    GelenSonKenar.KenarPolyNo = TotalNoktaList(GelenSonKenar.Uc1NoktaNo).NoktaPolyNo
                End If

                MuseumPolygonGelen.Add(GelenSonKenar)

                tmpMuseumPolygonGelen.Clear()
                tmpMuseumPolygonGelen.AddRange(MuseumPolygonGelen)

                EarClipping(MuseumPolygonGiden, True, LookingNokta.NoktaNo, TargetNokta.NoktaNo, CizilenPolygonNo)
                kkbAnswer.EarSonUcgen = EarClipping(MuseumPolygonGelen, False, LookingNokta.NoktaNo, TargetNokta.NoktaNo, CizilenPolygonNo)

                'If Form1.ChkBozukBul1.Checked = True Then
                '    Form1.BozukUcgenBul()
                '    'If Form1.FatalError Then Exit Function
                'End If

                kkbAnswer.Connected = True
                Return kkbAnswer
            Else

                TmpUcgenList.Clear()
                istikametList.Clear()
                MuseumPolygonGiden.Clear()
                MuseumPolygonGelen.Clear()
                kkbAnswer.Connected = False
                Return kkbAnswer
            End If
        End Function

        Public Sub NoktaSil(ByVal NoktaNo As Integer, ByVal SelfCall As Boolean)
            Dim CevrilecekNokta As Nokta
            Dim Karsi1, Karsi2 As Nokta
            Dim tmpKomsuUcgen As Ucgen
            Dim BakisAralik As Aralik
            Dim DarAci1, DarAci2 As Double
            Dim EnabledAralikSira As Integer
            Dim Baglanamadi As Boolean = False
            Dim NoktaSay, YanKarsiNo, SilAralikSay As Integer
            Dim BakilanAralik As Aralik
            Dim BakilanUcgen As Ucgen
            Dim GecisKenari As Kenar

            Baglanamadi = False
            CevrilecekNokta = TotalNoktaList(NoktaNo)

            'yapılacak: çevirme işleminin silinecek noktayı içermesi şart değil
            'önemli olan silinecek noktayı çeviren poligonun yeniden üçgenlenmesi ve
            'silinecek nokta olmadan yeni bir geometri yaratılabilmesi.

            If CevrilecekNokta.NoktaSilindi = False Then
                CevrilecekNokta.Siliniyor = True
                If CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count > 3 Then
                    Do
                        If CevrilecekNokta.NoktaSilindi = True Then
                            Exit Do
                        End If

                        Baglanamadi = True
                        'yapilacak: burada çevirme işlemi for değil do döngüsüyle yapılmalı.
                        'sonraki bağ noktası önceki noktanın bağlandığı nokta olmalı
                        'ilk nokta ise for döngüsü içinde bulunmalı.
                        'yankarsıno silme işlemi eğer cevrilecek noktanın silinmesinde bir zorlanma olacaksa yapılmalı.
                        'bu tip zorlanmaların tümü silmeden önce bulunmalı.
                        For NoktaSay = 0 To CevrilecekNokta.AralikList.Count - 1
                            If CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count > 3 Then

                                'Beep()
                                If CevrilecekNokta.AralikList(NoktaSay).Disabled = False Then
                                    BakilanAralik = CevrilecekNokta.AralikList(NoktaSay)
                                    BakilanUcgen = TotalUcgenList(BakilanAralik.UcgenNo)
                                    GecisKenari = BakilanUcgen.KenarList((BakilanAralik.UcgeniciKarsiKenarNo + 1) Mod 3)

                                    'testcode start
                                    If BakilanAralik.GelenUcNo = CevrilecekNokta.NoktaNo Or BakilanAralik.GidenUcNo = CevrilecekNokta.NoktaNo Then
                                        Beep()
                                    End If
                                    'testcode finis

                                    'aciklama: aşağıdaki iki if bloğuyla taşınan nokta çevrilirken bağlı noktalardaki aralık sayısının
                                    '1'e düşmesi engelleniyor.
                                    If GecisKenari.Uc1NoktaNo = CevrilecekNokta.NoktaNo Then
                                        YanKarsiNo = GecisKenari.Uc2NoktaNo
                                    Else
                                        YanKarsiNo = GecisKenari.Uc1NoktaNo
                                    End If
                                    If TotalNoktaList(YanKarsiNo).AralikList.Count - TotalNoktaList(YanKarsiNo).DisableList.Count < 4 Then
                                        If CevrilecekNokta.NoktaPolyNo = TotalNoktaList(YanKarsiNo).NoktaPolyNo And SelfCall = False Then
                                            'yapılacak: recurcivity adamı siker.

                                        ElseIf SelfCall = False Then

                                            ''yapilacak: recurcivity gerektiren nokta başka poligondaysa bişeyler yapması gerekiyor
                                            ''yoksa sıçar.

                                        End If
                                        'yapilacak: yankarşınoktanın polygonu farklıysa ve bu işlem bu nokta aralığını 3 ve altına düşürüse
                                        'veya yankarşı yeni bir recurcivity başlatırsa sıçabilir.
                                        'bu işlem bu uygulamanın her noktayı silemeyeceğini yada 
                                        'bir üçgenin alanının 0 olamayacağını yani tüm noktalarının aynı doğru üzerinde
                                        'olamayacağını gösteriyor.
                                        'ilk denemelerde çalıştı, çoklu taşımalarda eşitlik yerine "taşınıyomu" sorgusu yapılabilir
                                        'bu işlem aralık sayısının 1 e düşmesini engeliyor belkide 2 ye
                                        '24.01.2011 recursivity asıl silinecek noktayı ilk durumuna geri getiryor ve kısır döngü yaratıyor.
                                        'poligon animasyonla hareket ettirildiğinde kısır döngüye giriyor. ancak mousela taşındığında muhtemelen
                                        'multitherad etkisiyle kilitlenmiyor ancak geometri bozuluyor. map m6a anim m6abuganim1
                                        'ancak bu harita bozuk yükleniyomuş hata buradan kaynaklanabilir.
                                        'yapılacak: map m6 da test çokgeninde birinci taşımadan sonra ağırlık merkezi yanlış hesaplanıyor
                                        'sorunun diğer maplardaki durumuna bakılacak.
                                    End If

                                    Karsi1 = TotalNoktaList(GecisKenari.KarsiNoktaNo)
                                    AramailkNoktasi = Karsi1
                                    tmpKomsuUcgen = TotalUcgenList(GecisKenari.KomsuNo)
                                    Karsi2 = TotalNoktaList(tmpKomsuUcgen.KenarList(GecisKenari.KomsudaKacinciKenarNo).KarsiNoktaNo)
                                    If Karsi1.NoktaNo = Karsi2.NoktaNo Or Karsi1.NoktaSilindi = True Or Karsi2.NoktaSilindi = True Then
                                        If Karsi1.AralikList.Count - Karsi1.DisableList.Count > 2 Then
                                            Beep()

                                            If TotalNoktaList(GecisKenari.Uc1NoktaNo).AralikList.Count - TotalNoktaList(GecisKenari.Uc1NoktaNo).DisableList.Count = 2 Then
                                                NoktaSil(GecisKenari.Uc1NoktaNo, True)
                                                TotalNoktaList(GecisKenari.Uc1NoktaNo).NoktaSilindi = True
                                                TotalNoktaList(GecisKenari.Uc1NoktaNo).AralikList.Clear()
                                                TotalNoktaList(GecisKenari.Uc1NoktaNo).DisableList.Clear()
                                                NoktaSil(CevrilecekNokta.NoktaNo, False)
                                                Exit Sub
                                            ElseIf TotalNoktaList(GecisKenari.Uc2NoktaNo).AralikList.Count - TotalNoktaList(GecisKenari.Uc2NoktaNo).DisableList.Count = 2 Then
                                                NoktaSil(GecisKenari.Uc2NoktaNo, True)
                                                TotalNoktaList(GecisKenari.Uc2NoktaNo).NoktaSilindi = True
                                                TotalNoktaList(GecisKenari.Uc2NoktaNo).AralikList.Clear()
                                                TotalNoktaList(GecisKenari.Uc2NoktaNo).DisableList.Clear()
                                                NoktaSil(CevrilecekNokta.NoktaNo, False)
                                                Exit Sub
                                            End If
                                            Exit Do
                                        Else
                                            Exit Do
                                        End If
                                    End If
                                    'yapılacak: karsi1 ve karsi2 aynı noktaya refere edebiliyor ve açı değerleri 0 oluyor.
                                    'şimdilik çözümü karmaşık olduğundan gerçek poligon silmede gerçekleşip gerçekleşmediğine bakılacak.
                                    'm6 mapinin 106 noktası için yukardaki olay gerçekleşti.sebebi bi önceki 105 in cevirme işleminden 2 aralikla çıkıp üçgen silmeye girmemesi.
                                    'şimdilik çözümü kolay görünüyor ancak moving sırasında olabilecek benzer bi istisna düşünülecek.
                                    '105 in bu durumu şimdi olduğu gibi sadece nokta/üçgen silmede gerçekleşebilir. teoride geometrik olarak  mümkün görünmüyor.
                                    'bir çözüm yazdım ancak 2 aralık istisnası başka bir geometriyle gerçekleşirse çözüm çökebilir.

                                    'yapılacak: tekrarlayan ters aralıklar ve çizgi üzerindeki düzensiz dar üçgenlerden kaynaklanan
                                    'kısır döngülerin gerçek nokta veya poligon silmede gerçekleşip gerçekleşmediği araştırılacak.
                                    '09.08.2010 kement mode 5
                                    '12.08.2010 yukardaki duruma kayıtlı maplarde sadece bir kere rastladım geometri gerçekleşiyor.
                                    '18.08.2010 sorun devam ediyormuş 2 aralıklı noktaları 3 aralığa çıkmaya zorladım şimdilik çalışıyor
                                    'ancak 3 aralıkla ilgili başka sorunlar var
                                    DarAci1 = GetAngle(Karsi2.KendiYeri, TotalNoktaList(GecisKenari.Uc1NoktaNo).KendiYeri, Karsi1.KendiYeri)
                                    DarAci2 = GetAngle(Karsi1.KendiYeri, TotalNoktaList(GecisKenari.Uc2NoktaNo).KendiYeri, Karsi2.KendiYeri)

                                    BakisAralik = Karsi1.AralikList(GecisKenari.KarsiNoktaAralikNo)

                                    'yapılacak: çizgi üzerindeki noktaların aralik sayıları 3 e düşürülsede aralik karşıkenarları
                                    'bir üçgen oluşturmuyorsa noktayı silmek için başka bir yol bulmak gerekebilir.
                                    CevrilecekNokta.SilmeYontemi = 2
                                    If BakisAralik.UcgenNo <> BakilanAralik.UcgenNo Then
                                        Beep()
                                    End If
                                    If DarAci1 <= 180 And DarAci2 <= 180 Then

                                        BakilanUcgen.Dolu = False
                                        BakilanUcgen.PolyEklendi = False
                                        BakilanUcgen.UcgenPolyNo = -1
                                        tmpKomsuUcgen.Dolu = False
                                        tmpKomsuUcgen.PolyEklendi = False
                                        tmpKomsuUcgen.UcgenPolyNo = -1

                                        ikiUcgenBagla(BakilanUcgen, Karsi1, Karsi2, tmpKomsuUcgen, BakisAralik)

                                        Baglanamadi = False

                                    End If

                                End If
                            Else
                                CevrilecekNokta.SilmeYontemi = 2
                                Exit Do
                            End If
                            If NoktaSay = CevrilecekNokta.AralikList.Count - 1 And Baglanamadi = True Then
                                Exit Do
                            End If
                        Next
                    Loop
                End If

                If CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count > 3 Then
                    Do
                        Baglanamadi = True
                        For NoktaSay = 0 To CevrilecekNokta.AralikList.Count - 1
                            If CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count > 3 Then

                                'Beep()
                                If CevrilecekNokta.AralikList(NoktaSay).Disabled = False Then
                                    BakilanAralik = CevrilecekNokta.AralikList(NoktaSay)
                                    BakilanUcgen = TotalUcgenList(BakilanAralik.UcgenNo)
                                    GecisKenari = BakilanUcgen.KenarList((BakilanAralik.UcgeniciKarsiKenarNo + 1) Mod 3)

                                    If GecisKenari.Uc1NoktaNo = CevrilecekNokta.NoktaNo Then
                                        YanKarsiNo = GecisKenari.Uc2NoktaNo
                                    Else
                                        YanKarsiNo = GecisKenari.Uc1NoktaNo
                                    End If
                                    If TotalNoktaList(YanKarsiNo).AralikList.Count - TotalNoktaList(YanKarsiNo).DisableList.Count < 4 Then
                                        If CevrilecekNokta.NoktaPolyNo = TotalNoktaList(YanKarsiNo).NoktaPolyNo Then
                                            'yapılacak: recurcivity adamı siker.
                                            NoktaSil(YanKarsiNo, True)
                                            TotalNoktaList(YanKarsiNo).NoktaSilindi = True
                                            TotalNoktaList(YanKarsiNo).AralikList.Clear()
                                            TotalNoktaList(YanKarsiNo).DisableList.Clear()
                                            Exit For
                                        End If
                                        'yapilacak: yankarşınoktanın polygonu farklıysa ve bu işlem bu nokta aralığını  ve altına düşürüse
                                        'veya yankarşı yeni bir recurcivity başlatırsa sıçabilir.
                                    End If

                                    Karsi1 = TotalNoktaList(GecisKenari.KarsiNoktaNo)
                                    AramailkNoktasi = Karsi1
                                    tmpKomsuUcgen = TotalUcgenList(GecisKenari.KomsuNo)
                                    Karsi2 = TotalNoktaList(tmpKomsuUcgen.KenarList(GecisKenari.KomsudaKacinciKenarNo).KarsiNoktaNo)
                                    If Karsi1.NoktaNo = Karsi2.NoktaNo Then
                                        Beep()
                                        If Karsi1.NoktaNo = Karsi2.NoktaNo Or Karsi1.NoktaSilindi = True Or Karsi2.NoktaSilindi = True Then
                                            If Karsi1.AralikList.Count - Karsi1.DisableList.Count > 2 Then
                                                'FatalError = True
                                                Beep()

                                                If TotalNoktaList(GecisKenari.Uc1NoktaNo).AralikList.Count - TotalNoktaList(GecisKenari.Uc1NoktaNo).DisableList.Count = 2 Then
                                                    NoktaSil(GecisKenari.Uc1NoktaNo, True)
                                                    TotalNoktaList(GecisKenari.Uc1NoktaNo).NoktaSilindi = True
                                                    TotalNoktaList(GecisKenari.Uc1NoktaNo).AralikList.Clear()
                                                    TotalNoktaList(GecisKenari.Uc1NoktaNo).DisableList.Clear()
                                                    NoktaSil(CevrilecekNokta.NoktaNo, False)
                                                    Exit Sub
                                                ElseIf TotalNoktaList(GecisKenari.Uc2NoktaNo).AralikList.Count - TotalNoktaList(GecisKenari.Uc2NoktaNo).DisableList.Count = 2 Then
                                                    NoktaSil(GecisKenari.Uc2NoktaNo, True)
                                                    TotalNoktaList(GecisKenari.Uc2NoktaNo).NoktaSilindi = True
                                                    TotalNoktaList(GecisKenari.Uc2NoktaNo).AralikList.Clear()
                                                    TotalNoktaList(GecisKenari.Uc2NoktaNo).DisableList.Clear()
                                                    NoktaSil(CevrilecekNokta.NoktaNo, False)
                                                    Exit Sub
                                                End If
                                                Exit Do
                                            Else
                                                Exit Do
                                            End If
                                        End If
                                    End If

                                    DarAci1 = GetAngle(Karsi2.KendiYeri, TotalNoktaList(GecisKenari.Uc1NoktaNo).KendiYeri, Karsi1.KendiYeri)
                                    DarAci2 = GetAngle(Karsi1.KendiYeri, TotalNoktaList(GecisKenari.Uc2NoktaNo).KendiYeri, Karsi2.KendiYeri)

                                    BakisAralik = Karsi1.AralikList(GecisKenari.KarsiNoktaAralikNo)

                                    CevrilecekNokta.SilmeYontemi = 2
                                    If BakisAralik.UcgenNo <> BakilanAralik.UcgenNo Then
                                        Beep()
                                    End If
                                    If DarAci1 <= 180 Or DarAci2 <= 180 Then

                                        BakilanUcgen.Dolu = False
                                        BakilanUcgen.PolyEklendi = False
                                        BakilanUcgen.UcgenPolyNo = -1
                                        tmpKomsuUcgen.Dolu = False
                                        tmpKomsuUcgen.PolyEklendi = False
                                        tmpKomsuUcgen.UcgenPolyNo = -1
                                        ikiUcgenBagla(BakilanUcgen, Karsi1, Karsi2, tmpKomsuUcgen, BakisAralik)
                                        Baglanamadi = False

                                    End If

                                End If
                            Else
                                CevrilecekNokta.SilmeYontemi = 2
                                Exit Do
                            End If
                            If NoktaSay = CevrilecekNokta.AralikList.Count - 1 And Baglanamadi = True Then
                                Exit Do
                            End If
                        Next
                    Loop
                End If

                If Baglanamadi = True And CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count > 3 Then
                    'Dim cevirenuclu As New List(Of Integer)
                    'cevirenuclu = CevirenUcgeniBul(CevrilecekNokta)
                    'UcluCevir(CevrilecekNokta, cevirenuclu)
                    'Beep()
                    'If CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count > 3 Then
                    '    Beep()
                    '    Exit Sub
                    'End If


                End If


                If CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count <= 3 Then
                    CevrilecekNokta.SilmeYontemi = 0
                    EnabledAralikSira = 0
                    Dim Ucgen1, Ucgen2, Ucgen3 As Ucgen
                    Dim Ucgen1No, Ucgen2No, Ucgen3No As Integer
                    Dim Aralik1, Aralik2, Aralik3 As Aralik
                    Dim Kenar1, Kenar2, Kenar3 As Kenar
                    Dim SonAralikNo As Integer
                    For SilAralikSay = 0 To CevrilecekNokta.AralikList.Count - 1
                        If CevrilecekNokta.AralikList(SilAralikSay).Disabled = False Then
                            Select Case EnabledAralikSira
                                Case 0
                                    Ucgen1No = CevrilecekNokta.AralikList(SilAralikSay).UcgenNo
                                    Ucgen1 = TotalUcgenList(Ucgen1No)
                                    Aralik1 = CevrilecekNokta.AralikList(SilAralikSay)
                                    Kenar1 = Ucgen1.KenarList(Aralik1.UcgeniciKarsiKenarNo)
                                    If Kenar1.KenarPolyNo > -1 Then Kenar1.PolyKenar = True

                                Case 1
                                    Ucgen2No = CevrilecekNokta.AralikList(SilAralikSay).UcgenNo
                                    Ucgen2 = TotalUcgenList(Ucgen2No)
                                    Aralik2 = CevrilecekNokta.AralikList(SilAralikSay)
                                    Kenar2 = Ucgen2.KenarList(Aralik2.UcgeniciKarsiKenarNo)
                                    If Kenar2.KenarPolyNo > -1 Then Kenar2.PolyKenar = True

                                    If TotalNoktaList(Kenar2.Uc1NoktaNo).NoktaSilindi = True Or TotalNoktaList(Kenar2.Uc2NoktaNo).NoktaSilindi = True Then
                                        Beep()
                                        Aralik2.Disabled = True
                                        CevrilecekNokta.DisableList.Add(SilAralikSay)
                                    End If
                                Case 2
                                    Ucgen3No = CevrilecekNokta.AralikList(SilAralikSay).UcgenNo
                                    Ucgen3 = TotalUcgenList(Ucgen3No)
                                    Aralik3 = CevrilecekNokta.AralikList(SilAralikSay)
                                    Kenar3 = Ucgen3.KenarList(Aralik3.UcgeniciKarsiKenarNo)
                                    If Kenar3.KenarPolyNo > -1 Then Kenar3.PolyKenar = True

                            End Select
                            EnabledAralikSira = EnabledAralikSira + 1
                        End If

                    Next

                    If CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count = 3 Then
                        If Kenar1 Is Nothing Or Kenar2 Is Nothing Or Kenar3 Is Nothing Then
                            Exit Sub
                        End If

                        If Kenar1.Uc2NoktaNo = Kenar3.Uc1NoktaNo Then
                            'tmpKenar = Kenar2
                            Kenar2 = Ucgen3.KenarList(Aralik3.UcgeniciKarsiKenarNo)
                            Kenar3 = Ucgen2.KenarList(Aralik2.UcgeniciKarsiKenarNo)
                            Ucgen2 = TotalUcgenList(Ucgen3No)
                            Ucgen3 = TotalUcgenList(Ucgen2No)
                            Dim tmpUno As Integer
                            tmpUno = Ucgen2No
                            Ucgen2No = Ucgen3No
                            Ucgen3No = tmpUno
                        End If
                        'yapılacak: sonraki kısımlar için daha az satır harcanacak.
                        'burası diğer noktaların aralık sayısını 3'ün altına düşürebilir.
                        If TotalNoktaList(Ucgen1.KenarList(0).KarsiNoktaNo).NoktaSilindi = False Then
                            TotalNoktaList(Ucgen1.KenarList(0).KarsiNoktaNo).AralikList(Ucgen1.KenarList(0).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(Ucgen1.KenarList(0).KarsiNoktaNo).DisableList.Add(Ucgen1.KenarList(0).KarsiNoktaAralikNo)
                        End If

                        If TotalNoktaList(Ucgen1.KenarList(1).KarsiNoktaNo).NoktaSilindi = False Then
                            TotalNoktaList(Ucgen1.KenarList(1).KarsiNoktaNo).AralikList(Ucgen1.KenarList(1).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(Ucgen1.KenarList(1).KarsiNoktaNo).DisableList.Add(Ucgen1.KenarList(1).KarsiNoktaAralikNo)
                        End If

                        If TotalNoktaList(Ucgen1.KenarList(2).KarsiNoktaNo).NoktaSilindi = False Then
                            TotalNoktaList(Ucgen1.KenarList(2).KarsiNoktaNo).AralikList(Ucgen1.KenarList(2).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(Ucgen1.KenarList(2).KarsiNoktaNo).DisableList.Add(Ucgen1.KenarList(2).KarsiNoktaAralikNo)
                        End If

                        If TotalNoktaList(Ucgen2.KenarList(0).KarsiNoktaNo).NoktaSilindi = False Then
                            TotalNoktaList(Ucgen2.KenarList(0).KarsiNoktaNo).AralikList(Ucgen2.KenarList(0).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(Ucgen2.KenarList(0).KarsiNoktaNo).DisableList.Add(Ucgen2.KenarList(0).KarsiNoktaAralikNo)
                        End If

                        If TotalNoktaList(Ucgen2.KenarList(1).KarsiNoktaNo).NoktaSilindi = False Then
                            TotalNoktaList(Ucgen2.KenarList(1).KarsiNoktaNo).AralikList(Ucgen2.KenarList(1).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(Ucgen2.KenarList(1).KarsiNoktaNo).DisableList.Add(Ucgen2.KenarList(1).KarsiNoktaAralikNo)
                        End If

                        If TotalNoktaList(Ucgen2.KenarList(2).KarsiNoktaNo).NoktaSilindi = False Then
                            TotalNoktaList(Ucgen2.KenarList(2).KarsiNoktaNo).AralikList(Ucgen2.KenarList(2).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(Ucgen2.KenarList(2).KarsiNoktaNo).DisableList.Add(Ucgen2.KenarList(2).KarsiNoktaAralikNo)
                        End If

                        If TotalNoktaList(Ucgen3.KenarList(0).KarsiNoktaNo).NoktaSilindi = False Then
                            TotalNoktaList(Ucgen3.KenarList(0).KarsiNoktaNo).AralikList(Ucgen3.KenarList(0).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(Ucgen3.KenarList(0).KarsiNoktaNo).DisableList.Add(Ucgen3.KenarList(0).KarsiNoktaAralikNo)
                        End If

                        If TotalNoktaList(Ucgen3.KenarList(1).KarsiNoktaNo).NoktaSilindi = False Then
                            TotalNoktaList(Ucgen3.KenarList(1).KarsiNoktaNo).AralikList(Ucgen3.KenarList(1).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(Ucgen3.KenarList(1).KarsiNoktaNo).DisableList.Add(Ucgen3.KenarList(1).KarsiNoktaAralikNo)
                        End If

                        If TotalNoktaList(Ucgen3.KenarList(2).KarsiNoktaNo).NoktaSilindi = False Then
                            TotalNoktaList(Ucgen3.KenarList(2).KarsiNoktaNo).AralikList(Ucgen3.KenarList(2).KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(Ucgen3.KenarList(2).KarsiNoktaNo).DisableList.Add(Ucgen3.KenarList(2).KarsiNoktaAralikNo)
                        End If

                        Kenar1.KarsiNoktaNo = Kenar2.Uc2NoktaNo
                        If TotalNoktaList(Kenar2.Uc2NoktaNo).DisableList.Count > 0 Then

                            SonAralikNo = TotalNoktaList(Kenar2.Uc2NoktaNo).DisableList(TotalNoktaList(Kenar2.Uc2NoktaNo).DisableList.Count - 1)
                            If TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList(SonAralikNo).Disabled = False Then
                                Beep()
                            End If
                            TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList(SonAralikNo).Disabled = False
                            TotalNoktaList(Kenar2.Uc2NoktaNo).DisableList.RemoveAt(TotalNoktaList(Kenar2.Uc2NoktaNo).DisableList.Count - 1)
                        Else
                            Dim YeniAralik As New Aralik
                            TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList.Add(YeniAralik)
                            SonAralikNo = TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList.Count - 1
                        End If
                        TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList(SonAralikNo).GelenUcNo = Kenar1.Uc2NoktaNo
                        TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList(SonAralikNo).GidenUcNo = Kenar1.Uc1NoktaNo
                        TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList(SonAralikNo).UcgeniciKarsiKenarNo = 0
                        TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList(SonAralikNo).UcgeniciGelenKenarNo = 1
                        TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList(SonAralikNo).UcgeniciGidenKenarNo = 2
                        TotalNoktaList(Kenar2.Uc2NoktaNo).AralikList(SonAralikNo).UcgenNo = Ucgen1No
                        Kenar1.KarsiNoktaAralikNo = SonAralikNo
                        If Kenar1.KomsuNo > -1 Then
                            TotalUcgenList(Kenar1.KomsuNo).KenarList(Kenar1.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = 0
                            TotalUcgenList(Kenar1.KomsuNo).KenarList(Kenar1.KomsudaKacinciKenarNo).KomsuNo = Ucgen1No
                        End If

                        Kenar2.KarsiNoktaNo = Kenar3.Uc2NoktaNo
                        If TotalNoktaList(Kenar3.Uc2NoktaNo).DisableList.Count > 0 Then

                            SonAralikNo = TotalNoktaList(Kenar3.Uc2NoktaNo).DisableList(TotalNoktaList(Kenar3.Uc2NoktaNo).DisableList.Count - 1)
                            If TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList(SonAralikNo).Disabled = False Then
                                Beep()
                            End If
                            TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList(SonAralikNo).Disabled = False
                            TotalNoktaList(Kenar3.Uc2NoktaNo).DisableList.RemoveAt(TotalNoktaList(Kenar3.Uc2NoktaNo).DisableList.Count - 1)
                        Else
                            Dim YeniAralik As New Aralik
                            TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList.Add(YeniAralik)
                            SonAralikNo = TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList.Count - 1
                        End If
                        TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList(SonAralikNo).GelenUcNo = Kenar2.Uc2NoktaNo
                        TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList(SonAralikNo).GidenUcNo = Kenar2.Uc1NoktaNo
                        TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList(SonAralikNo).UcgeniciKarsiKenarNo = 1
                        TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList(SonAralikNo).UcgeniciGelenKenarNo = 2
                        TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList(SonAralikNo).UcgeniciGidenKenarNo = 0
                        TotalNoktaList(Kenar3.Uc2NoktaNo).AralikList(SonAralikNo).UcgenNo = Ucgen1No
                        Kenar2.KarsiNoktaAralikNo = SonAralikNo
                        If Kenar2.KomsuNo > -1 Then
                            TotalUcgenList(Kenar2.KomsuNo).KenarList(Kenar2.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = 1
                            TotalUcgenList(Kenar2.KomsuNo).KenarList(Kenar2.KomsudaKacinciKenarNo).KomsuNo = Ucgen1No
                        End If

                        Kenar3.KarsiNoktaNo = Kenar1.Uc2NoktaNo
                        If TotalNoktaList(Kenar1.Uc2NoktaNo).DisableList.Count > 0 Then

                            SonAralikNo = TotalNoktaList(Kenar1.Uc2NoktaNo).DisableList(TotalNoktaList(Kenar1.Uc2NoktaNo).DisableList.Count - 1)
                            If TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList(SonAralikNo).Disabled = False Then
                                Beep()
                            End If
                            TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList(SonAralikNo).Disabled = False
                            TotalNoktaList(Kenar1.Uc2NoktaNo).DisableList.RemoveAt(TotalNoktaList(Kenar1.Uc2NoktaNo).DisableList.Count - 1)
                        Else
                            Dim YeniAralik As New Aralik
                            TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList.Add(YeniAralik)
                            SonAralikNo = TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList.Count - 1
                        End If
                        TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList(SonAralikNo).GelenUcNo = Kenar3.Uc2NoktaNo
                        TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList(SonAralikNo).GidenUcNo = Kenar3.Uc1NoktaNo
                        TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList(SonAralikNo).UcgeniciKarsiKenarNo = 2
                        TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList(SonAralikNo).UcgeniciGelenKenarNo = 0
                        TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList(SonAralikNo).UcgeniciGidenKenarNo = 1
                        TotalNoktaList(Kenar1.Uc2NoktaNo).AralikList(SonAralikNo).UcgenNo = Ucgen1No
                        Kenar3.KarsiNoktaAralikNo = SonAralikNo
                        If Kenar3.KomsuNo > -1 Then
                            TotalUcgenList(Kenar3.KomsuNo).KenarList(Kenar3.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = 2
                            TotalUcgenList(Kenar3.KomsuNo).KenarList(Kenar3.KomsudaKacinciKenarNo).KomsuNo = Ucgen1No
                        End If
                        Ucgen1.KenarList.Clear()
                        Ucgen1.KenarList.Add(Kenar1)
                        Ucgen1.KenarList.Add(Kenar2)
                        Ucgen1.KenarList.Add(Kenar3)
                        Ucgen1.CalcTriArea()
                        Ucgen1.FindTriCenter()
                        If Ucgen1.Disabled = True Then
                            Beep()
                        End If

                        AramailkNoktasi = TotalNoktaList(Ucgen1.KenarList(0).Uc1NoktaNo)
                        Ucgen2.Disabled = True
                        Ucgen3.Disabled = True
                        UcgenSil(Ucgen2No)
                        UcgenSil(Ucgen3No)

                    ElseIf CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count = 2 Then
                        For SilAralikSay = 0 To CevrilecekNokta.AralikList.Count - 1
                            If CevrilecekNokta.AralikList(SilAralikSay).Disabled = False Then
                                Dim SilTmpKenar As Kenar
                                BakisAralik = CevrilecekNokta.AralikList(SilAralikSay)
                                SilTmpKenar = TotalUcgenList(BakisAralik.UcgenNo).KenarList(BakisAralik.UcgeniciKarsiKenarNo)
                                Karsi2 = TotalNoktaList(TotalUcgenList(SilTmpKenar.KomsuNo).KenarList(SilTmpKenar.KomsudaKacinciKenarNo).KarsiNoktaNo)

                                TotalUcgenList(BakisAralik.UcgenNo).Dolu = False
                                TotalUcgenList(BakisAralik.UcgenNo).PolyEklendi = False
                                TotalUcgenList(BakisAralik.UcgenNo).UcgenPolyNo = -1
                                TotalUcgenList(SilTmpKenar.KomsuNo).Dolu = False
                                TotalUcgenList(SilTmpKenar.KomsuNo).PolyEklendi = False
                                TotalUcgenList(SilTmpKenar.KomsuNo).UcgenPolyNo = -1
                                ikiUcgenBagla(TotalUcgenList(BakisAralik.UcgenNo), CevrilecekNokta, Karsi2, TotalUcgenList(SilTmpKenar.KomsuNo), BakisAralik)
                                If CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count = 3 Then
                                    NoktaSil(CevrilecekNokta.NoktaNo, True)
                                    CevrilecekNokta.NoktaSilindi = True
                                    CevrilecekNokta.AralikList.Clear()
                                    CevrilecekNokta.DisableList.Clear()

                                    Exit For
                                End If
                            End If
                        Next



                    End If
                    If CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count = 1 Then
                        For SilAralikSay = 0 To CevrilecekNokta.AralikList.Count - 1

                            FatalError = True
                            Beep()
                            Exit Sub
                            If CevrilecekNokta.AralikList(SilAralikSay).Disabled = False Then

                                BakisAralik = CevrilecekNokta.AralikList(SilAralikSay)
                                'TotalUcgenList(BakisAralik.UcgenNo).Disabled = True
                                Ucgen1No = BakisAralik.UcgenNo
                                Ucgen1 = TotalUcgenList(Ucgen1No)
                                Ucgen1.Disabled = True
                                If TotalNoktaList(Ucgen1.KenarList(0).KarsiNoktaNo).NoktaSilindi = False Then
                                    TotalNoktaList(Ucgen1.KenarList(0).KarsiNoktaNo).AralikList(Ucgen1.KenarList(0).KarsiNoktaAralikNo).Disabled = True
                                    TotalNoktaList(Ucgen1.KenarList(0).KarsiNoktaNo).DisableList.Add(Ucgen1.KenarList(0).KarsiNoktaAralikNo)
                                End If

                                If TotalNoktaList(Ucgen1.KenarList(1).KarsiNoktaNo).NoktaSilindi = False Then
                                    TotalNoktaList(Ucgen1.KenarList(1).KarsiNoktaNo).AralikList(Ucgen1.KenarList(1).KarsiNoktaAralikNo).Disabled = True
                                    TotalNoktaList(Ucgen1.KenarList(1).KarsiNoktaNo).DisableList.Add(Ucgen1.KenarList(1).KarsiNoktaAralikNo)
                                End If

                                If TotalNoktaList(Ucgen1.KenarList(2).KarsiNoktaNo).NoktaSilindi = False Then
                                    TotalNoktaList(Ucgen1.KenarList(2).KarsiNoktaNo).AralikList(Ucgen1.KenarList(2).KarsiNoktaAralikNo).Disabled = True
                                    TotalNoktaList(Ucgen1.KenarList(2).KarsiNoktaNo).DisableList.Add(Ucgen1.KenarList(2).KarsiNoktaAralikNo)
                                End If
                                'yapılacak: noktaya bağlı tek üçgen kalması durumunda bu son üçgen bazı durumlarda silinemiyor
                                'normalde bu üçgene refere eden hiç bir kenar olmaması gerekiyor ama var.

                                UcgenSil(Ucgen1No)

                                Beep()

                                Exit For

                            End If
                        Next
                    End If

                ElseIf CevrilecekNokta.AralikList.Count - CevrilecekNokta.DisableList.Count > 3 Then
                    Beep()
                End If
            End If
            CevrilecekNokta.Siliniyor = False
        End Sub

        Public Sub ikiUcgenBagla(ByVal bagBakanUcgen As Ucgen, ByVal bagBakanNokta As Nokta, ByVal bagHedefNokta As Nokta, ByVal bagKarsiUcgen As Ucgen, ByVal bagBakanAralik As Aralik)
            Dim komsudaKac As Integer
            Dim komsukackenar, TakasKenar As Kenar
            Dim TakasUcgen1 As New Ucgen(Me)
            Dim TakasUcgen2 As New Ucgen(Me)
            Dim BakanUcgenNo, KarsiUcgenNo, SonAralikNo, TakasSay, Takenarsay, YedekPolyNo As Integer
            Dim BagKenari1, BagKenari2 As New Kenar
            Dim TakasUcgen As Ucgen
            Dim TakasNokta As Nokta

            If bagBakanUcgen.KenarList.Count < 3 Or bagKarsiUcgen.KenarList.Count < 3 Then
                Beep()
            End If
            komsudaKac = bagBakanUcgen.KenarList(bagBakanAralik.UcgeniciKarsiKenarNo).KomsudaKacinciKenarNo
            komsukackenar = bagKarsiUcgen.KenarList(komsudaKac)
            If komsukackenar.KarsiNoktaNo <> bagHedefNokta.NoktaNo Then
                Beep()
            End If
            KarsiUcgenNo = bagHedefNokta.AralikList(komsukackenar.KarsiNoktaAralikNo).UcgenNo
            If KarsiUcgenNo <> bagBakanUcgen.KenarList(bagBakanAralik.UcgeniciKarsiKenarNo).KomsuNo Then
                Beep()
            End If
            bagHedefNokta.DisableList.Add(komsukackenar.KarsiNoktaAralikNo)
            bagHedefNokta.AralikList(komsukackenar.KarsiNoktaAralikNo).Disabled = True

            BakanUcgenNo = bagBakanAralik.UcgenNo

            bagBakanNokta.DisableList.Add(bagBakanUcgen.KenarList(bagBakanAralik.UcgeniciKarsiKenarNo).KarsiNoktaAralikNo)
            bagBakanAralik.Disabled = True
            YedekPolyNo = bagBakanUcgen.KenarList(bagBakanAralik.UcgeniciKarsiKenarNo).KenarPolyNo

            bagBakanUcgen.KenarList.RemoveAt(bagBakanAralik.UcgeniciKarsiKenarNo)
            'yapılacak: aşağıda if aslında gereksiz olabilir.
            If komsudaKac < bagKarsiUcgen.KenarList.Count Then
                If bagKarsiUcgen.KenarList(komsudaKac).KenarPolyNo > YedekPolyNo Then
                    YedekPolyNo = bagKarsiUcgen.KenarList(komsudaKac).KenarPolyNo
                End If
                bagKarsiUcgen.KenarList.RemoveAt(komsudaKac)
            End If


            If bagBakanUcgen.KenarList(0).Uc2NoktaNo <> bagBakanUcgen.KenarList(1).Uc1NoktaNo Then
                bagBakanUcgen.KenarList.Reverse()
                If bagBakanUcgen.KenarList(0).Uc2NoktaNo <> bagBakanUcgen.KenarList(1).Uc1NoktaNo Then
                    Beep()
                End If
            End If
            If bagKarsiUcgen.KenarList(0).Uc2NoktaNo <> bagKarsiUcgen.KenarList(1).Uc1NoktaNo Then
                bagKarsiUcgen.KenarList.Reverse()
                If bagKarsiUcgen.KenarList(0).Uc2NoktaNo <> bagKarsiUcgen.KenarList(1).Uc1NoktaNo Then
                    Beep()
                End If
            End If

            TakasUcgen1.KenarList.Add(bagBakanUcgen.KenarList(1).Clone)
            TakasUcgen1.KenarList.Add(bagKarsiUcgen.KenarList(0).Clone)
            BagKenari1.Uc1NoktaNo = bagHedefNokta.NoktaNo
            BagKenari1.Uc2NoktaNo = bagBakanNokta.NoktaNo
            BagKenari1.KomsuNo = KarsiUcgenNo
            BagKenari1.KarsiNoktaNo = TakasUcgen1.KenarList(0).Uc2NoktaNo
            BagKenari1.KomsudaKacinciKenarNo = 2
            'BagKenari1.KenarPolyNo = YedekPolyNo
            'TotalNoktaList(BagKenari1.KarsiNoktaNo).AralikList(BagKenari1.KarsiNoktaAralikNo).Disabled = True
            'TotalNoktaList(BagKenari1.KarsiNoktaNo).DisableList.Add(BagKenari1.KarsiNoktaAralikNo)
            TakasUcgen1.KenarList.Add(BagKenari1)
            TakasUcgen1.KendiNo = BakanUcgenNo

            TakasUcgen2.KenarList.Add(bagKarsiUcgen.KenarList(1).Clone)
            TakasUcgen2.KenarList.Add(bagBakanUcgen.KenarList(0).Clone)
            BagKenari2.Uc1NoktaNo = bagBakanNokta.NoktaNo
            BagKenari2.Uc2NoktaNo = bagHedefNokta.NoktaNo
            BagKenari2.KomsuNo = BakanUcgenNo
            BagKenari2.KarsiNoktaNo = TakasUcgen2.KenarList(0).Uc2NoktaNo
            BagKenari2.KomsudaKacinciKenarNo = 2
            'BagKenari2.KenarPolyNo = YedekPolyNo
            If komsukackenar.KenarPolyNo > -1 And komsukackenar.DisKenar = False Then
                If bagHedefNokta.NoktaPolyNo = bagBakanNokta.NoktaPolyNo And bagHedefNokta.NoktaPolyNo = komsukackenar.KenarPolyNo Then
                    BagKenari1.KenarPolyNo = bagBakanNokta.NoktaPolyNo
                    BagKenari1.PolyKenar = True
                    BagKenari2.KenarPolyNo = bagBakanNokta.NoktaPolyNo
                    BagKenari2.PolyKenar = True
                End If
            End If
            If bagBakanUcgen.KenarList(1).KenarPolyNo > -1 Then
                If bagBakanUcgen.KenarList(1).KenarPolyNo = bagKarsiUcgen.KenarList(0).KenarPolyNo Then
                    If bagKarsiUcgen.KenarList(0).KenarPolyNo = bagKarsiUcgen.KenarList(1).KenarPolyNo Then
                        If bagKarsiUcgen.KenarList(1).KenarPolyNo = bagBakanUcgen.KenarList(0).KenarPolyNo Then
                            BagKenari1.KenarPolyNo = bagBakanUcgen.KenarList(1).KenarPolyNo
                            BagKenari2.KenarPolyNo = bagBakanUcgen.KenarList(1).KenarPolyNo
                        End If
                    End If
                End If
            End If



            'BagKenari2.KenarPolyNo = bagBakanNokta.NoktaPolyNo
            'BagKenari2.PolyKenar = True
            'TotalNoktaList(BagKenari2.KarsiNoktaNo).AralikList(BagKenari2.KarsiNoktaAralikNo).Disabled = True
            'TotalNoktaList(BagKenari2.KarsiNoktaNo).DisableList.Add(BagKenari2.KarsiNoktaAralikNo)
            TakasUcgen2.KenarList.Add(BagKenari2)
            TakasUcgen2.KendiNo = KarsiUcgenNo

            bagBakanUcgen.KenarList.Clear()
            bagBakanUcgen.KenarList.AddRange(TakasUcgen1.KenarList)
            bagBakanUcgen.KendiNo = BakanUcgenNo

            bagKarsiUcgen.KenarList.Clear()
            bagKarsiUcgen.KenarList.AddRange(TakasUcgen2.KenarList)
            bagKarsiUcgen.KendiNo = KarsiUcgenNo

            If bagBakanUcgen.KenarList(0).Uc1NoktaNo <> bagBakanNokta.NoktaNo Then
                Beep()
            End If
            If bagKarsiUcgen.KenarList(0).Uc1NoktaNo <> bagHedefNokta.NoktaNo Then
                Beep()
            End If

            TakasUcgen = bagBakanUcgen
            For TakasSay = 0 To 1
                For Takenarsay = 0 To 2
                    TakasKenar = TakasUcgen.KenarList(Takenarsay)
                    If TakasKenar.KomsuNo > -1 Then
                        TotalUcgenList(TakasKenar.KomsuNo).KenarList(TakasKenar.KomsudaKacinciKenarNo).KomsudaKacinciKenarNo = Takenarsay
                        TotalUcgenList(TakasKenar.KomsuNo).KenarList(TakasKenar.KomsudaKacinciKenarNo).KomsuNo = TakasUcgen.KendiNo
                    End If


                    If Takenarsay < 2 Then
                        If TotalNoktaList(TakasKenar.KarsiNoktaNo).AralikList(TakasKenar.KarsiNoktaAralikNo).Disabled = False Then
                            'bu sorgunun noktasil (veya diğer aralık disablingler) içinde de yapılması gerekebilir.
                            TotalNoktaList(TakasKenar.KarsiNoktaNo).AralikList(TakasKenar.KarsiNoktaAralikNo).Disabled = True
                            TotalNoktaList(TakasKenar.KarsiNoktaNo).DisableList.Add(TakasKenar.KarsiNoktaAralikNo)
                        End If
                    End If


                    TakasNokta = TotalNoktaList(TakasUcgen.KenarList((Takenarsay + 1) Mod 3).Uc2NoktaNo)
                    TakasKenar.KarsiNoktaNo = TakasNokta.NoktaNo


                    Dim TakasAralik As Aralik
                    If TakasNokta.DisableList.Count > 0 Then
                        SonAralikNo = TakasNokta.DisableList(TakasNokta.DisableList.Count - 1)
                        TakasAralik = TakasNokta.AralikList(TakasNokta.DisableList(TakasNokta.DisableList.Count - 1))
                        TakasAralik.Disabled = False
                        TakasNokta.DisableList.RemoveAt(TakasNokta.DisableList.Count - 1)
                    Else
                        TakasAralik = New Aralik
                        TakasNokta.AralikList.Add(TakasAralik)
                        SonAralikNo = TakasNokta.AralikList.Count - 1
                    End If
                    TakasAralik.GidenUcNo = TakasKenar.Uc1NoktaNo
                    TakasAralik.GelenUcNo = TakasKenar.Uc2NoktaNo
                    If TakasAralik.GidenUcNo = TakasNokta.NoktaNo Or TakasAralik.GelenUcNo = TakasNokta.NoktaNo Then
                        Beep()
                    End If
                    TakasAralik.UcgeniciKarsiKenarNo = Takenarsay
                    TakasAralik.UcgeniciGelenKenarNo = (Takenarsay + 1) Mod 3
                    TakasAralik.UcgeniciGidenKenarNo = (Takenarsay + 2) Mod 3

                    TakasAralik.UcgenNo = TakasUcgen.KendiNo
                    TakasKenar.KarsiNoktaAralikNo = SonAralikNo
                Next
                'For testKenarsay As Integer = 0 To 2
                '    Dim testkenar, komsutestkenar As Kenar
                '    Dim testAralik As Aralik
                '    testkenar = TakasUcgen.KenarList(testKenarsay)
                '    testAralik = TotalNoktaList(testkenar.KarsiNoktaNo).AralikList(testkenar.KarsiNoktaAralikNo)
                '    komsutestkenar = TotalUcgenList(TakasUcgen.KenarList(testAralik.UcgeniciKarsiKenarNo).KomsuNo).KenarList(TakasUcgen.KenarList(testAralik.UcgeniciKarsiKenarNo).KomsudaKacinciKenarNo)
                '    If komsutestkenar.KomsuNo <> TakasUcgen.KendiNo Then
                '        Beep()
                '    End If
                '    komsutestkenar = TotalUcgenList(TakasUcgen.KenarList(testAralik.UcgeniciGelenKenarNo).KomsuNo).KenarList(TakasUcgen.KenarList(testAralik.UcgeniciGelenKenarNo).KomsudaKacinciKenarNo)
                '    If komsutestkenar.KomsuNo <> TakasUcgen.KendiNo Then
                '        Beep()
                '    End If
                '    komsutestkenar = TotalUcgenList(TakasUcgen.KenarList(testAralik.UcgeniciGidenKenarNo).KomsuNo).KenarList(TakasUcgen.KenarList(testAralik.UcgeniciGidenKenarNo).KomsudaKacinciKenarNo)
                '    If komsutestkenar.KomsuNo <> TakasUcgen.KendiNo Then
                '        Beep()
                '    End If
                'Next
                TakasUcgen = bagKarsiUcgen
                'If TotalNoktaList(TakasUcgen.KenarList(0).Uc1NoktaNo).NoktaPolyNo > -1 Then
                '    If TotalNoktaList(TakasUcgen.KenarList(0).Uc1NoktaNo).NoktaPolyNo = TotalNoktaList(TakasUcgen.KenarList(1).Uc1NoktaNo).NoktaPolyNo Then
                '        If TotalNoktaList(TakasUcgen.KenarList(0).Uc1NoktaNo).NoktaPolyNo = TotalNoktaList(TakasUcgen.KenarList(2).Uc1NoktaNo).NoktaPolyNo Then
                '            TakasUcgen.PolyEklendi = True
                '            TakasUcgen.Dolu = True
                '            TakasUcgen.UcgenPolyNo = TotalNoktaList(TakasUcgen.KenarList(0).Uc1NoktaNo).NoktaPolyNo
                '        End If
                '    End If
                'End If

            Next

            TakasUcgen1 = Nothing
            TakasUcgen2 = Nothing

        End Sub

        Public Sub UcgenSil(ByVal BosUcgenNo As Integer)
            Dim ListSonUcgenNo As Integer = TotalUcgenList.Count - 1
            Dim BosUcgen As Ucgen
            Dim ListSonUcgen As Ucgen = TotalUcgenList(ListSonUcgenNo)
            Dim tmpKomsuKenar As Kenar
            Dim KarsiNokta As Nokta
            Dim KarsiAralik As Aralik
            Dim KenarSay As Integer
            Do
                If TotalUcgenList(TotalUcgenList.Count - 1).Disabled = True Then
                    TotalUcgenList.RemoveAt(TotalUcgenList.Count - 1)
                    ListSonUcgenNo = TotalUcgenList.Count - 1
                    ListSonUcgen = TotalUcgenList(ListSonUcgenNo)
                Else
                    ListSonUcgenNo = TotalUcgenList.Count - 1
                    ListSonUcgen = TotalUcgenList(ListSonUcgenNo)
                    Exit Do
                End If
            Loop
            If BosUcgenNo < ListSonUcgenNo Then
                BosUcgen = TotalUcgenList(BosUcgenNo)
                BosUcgen.KenarList.Clear()
                BosUcgen.KenarList.AddRange(ListSonUcgen.KenarList)
                BosUcgen.PolyEklendi = ListSonUcgen.PolyEklendi
                BosUcgen.UcgenPolyNo = ListSonUcgen.UcgenPolyNo
                BosUcgen.Dolu = ListSonUcgen.Dolu
                BosUcgen.TriCenter = ListSonUcgen.TriCenter
                BosUcgen.Disabled = False
                If BosUcgen.Dolu = True Then
                    'PolygonList(ListSonUcgen.UcgenPolyNo).UcgenList(ListSonUcgen.PolyListSira) = BosUcgenNo
                    BosUcgen.PolyListSira = ListSonUcgen.PolyListSira
                Else
                    BosUcgen.PolyListSira = -1
                End If
                For KenarSay = 0 To 2
                    If ListSonUcgen.KenarList(KenarSay).KomsuNo < TotalUcgenList.Count Then
                        If ListSonUcgen.KenarList(KenarSay).KomsuNo > -1 Then
                            If TotalUcgenList(ListSonUcgen.KenarList(KenarSay).KomsuNo).Disabled = False Then
                                tmpKomsuKenar = TotalUcgenList(ListSonUcgen.KenarList(KenarSay).KomsuNo).KenarList(ListSonUcgen.KenarList(KenarSay).KomsudaKacinciKenarNo)
                                tmpKomsuKenar.KomsuNo = BosUcgenNo
                                tmpKomsuKenar.KomsudaKacinciKenarNo = KenarSay
                            End If
                        End If
                    Else
                        ListSonUcgen.KenarList(KenarSay).KomsuNo = BosUcgenNo
                    End If

                    KarsiNokta = TotalNoktaList(ListSonUcgen.KenarList(KenarSay).KarsiNoktaNo)
                    'If KarsiNokta.NoktaSilindi = False Then
                    KarsiAralik = KarsiNokta.AralikList(ListSonUcgen.KenarList(KenarSay).KarsiNoktaAralikNo)
                    KarsiAralik.UcgenNo = BosUcgenNo
                    If KarsiAralik.Disabled = True Then
                        MsgBox("ola!")
                        Exit Sub
                    End If
                    'End If
                    'BosUcgen.KenarList(KenarSay).KenarPolyNo = ListSonUcgen.UcgenPolyNo
                Next
                ListSonUcgen.Disabled = True
            Else
                'Beep()
            End If

            Do
                If TotalUcgenList(TotalUcgenList.Count - 1).Disabled = True Then
                    TotalUcgenList.RemoveAt(TotalUcgenList.Count - 1)
                Else
                    Exit Do
                End If
            Loop
        End Sub

        Public Function ReNewEdge(ByVal MovingNokta As Nokta, ByVal MovedPolygonNo As Integer, ByVal PolyNoktaSiraNo As Integer) As PointToAnswer
            Dim BoyamaKenari1, BoyamaKenari2 As Kenar
            Dim AramailkNoktasiArama As Integer = 0
            Dim RneAnswer As New PointToAnswer
            Dim AralikSay2, Araliksay3 As Integer
            If MovingNokta.NoktaSilindi = True Then
                Do

                    RneAnswer.Poligonized = False
                    For AralikSay2 = 0 To AramailkNoktasi.AralikList.Count - 1
                        If AramailkNoktasi.AralikList(AralikSay2).Disabled = False Then
                            MoveEtkinGeo = PointToPointQuery2(AramailkNoktasi, MovingNokta.KendiYeri, False, AramailkNoktasi.AralikList(AralikSay2), 0, TotalNoktaList, TotalUcgenList)
                            If ((MoveEtkinGeo.SonKesilenDoluPoly > -1) Or (MoveEtkinGeo.SonKesilenDoluPoly < -9)) Then
                                RneAnswer.SonKesilenDoluPoly = MoveEtkinGeo.SonKesilenDoluPoly
                            End If

                            If MoveEtkinGeo.UcgenNo > -1 And MoveEtkinGeo.Durum > 0 And MoveEtkinGeo.SonKesilenDoluPoly > -2 Then
                                Dim Uclu As New List(Of Integer)
                                Uclu.Add(TotalUcgenList(MoveEtkinGeo.UcgenNo).KenarList(0).Uc1NoktaNo)
                                Uclu.Add(TotalUcgenList(MoveEtkinGeo.UcgenNo).KenarList(1).Uc1NoktaNo)
                                Uclu.Add(TotalUcgenList(MoveEtkinGeo.UcgenNo).KenarList(2).Uc1NoktaNo)
                                If NoktaIsInsideTri(Uclu, MovingNokta.KendiYeri, TotalNoktaList) Then
                                    'yapilacak: bu NoktaIsInsideTri sorgusu uygulamanın genel konseptine aykırı
                                    'MoveEtkinGeo içinden gereken cevap alınabilmeli

                                    'If TotalUcgenList(MoveEtkinGeo.UcgenNo).Dolu Then
                                    '    RneAnswer = MoveEtkinGeo
                                    '    MovingNokta.NoktaSilindi = True
                                    '    Return RneAnswer
                                    '    Beep()
                                    'End If
                                    'If MoveEtkinGeo.OncekiDoluKenar IsNot Nothing Then
                                    '    RneAnswer = MoveEtkinGeo
                                    '    MovingNokta.NoktaSilindi = True
                                    '    Return RneAnswer
                                    'End If
                                    Dim Nokta0Polyno, Nokta1Polyno, Nokta2Polyno As Integer
                                    Nokta0Polyno = TotalNoktaList(TotalUcgenList(MoveEtkinGeo.UcgenNo).KenarList(0).Uc1NoktaNo).NoktaPolyNo
                                    Nokta1Polyno = TotalNoktaList(TotalUcgenList(MoveEtkinGeo.UcgenNo).KenarList(1).Uc1NoktaNo).NoktaPolyNo
                                    Nokta2Polyno = TotalNoktaList(TotalUcgenList(MoveEtkinGeo.UcgenNo).KenarList(2).Uc1NoktaNo).NoktaPolyNo

                                    'alttaki sorguda çarpanın köşemi yoksa kenarmı olduğu olduğu bulunuyor
                                    'köşeyse noktanın konumu diğer poligonun içinde olacağından 3 noktanın poligonnosu aynı olur
                                    If Nokta0Polyno > -1 Then
                                        If Nokta1Polyno > -1 Then
                                            If Nokta2Polyno > -1 Then
                                                If Nokta0Polyno = Nokta1Polyno Then
                                                    RneAnswer.ColledKenar = (TotalUcgenList(MoveEtkinGeo.UcgenNo).KenarList(0))
                                                    If Nokta1Polyno = Nokta2Polyno Then
                                                        RneAnswer.Poligonized = True
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If


                                    FreeNokta(MovingNokta, MovingNokta.KendiYeri, TotalUcgenList(MoveEtkinGeo.UcgenNo), MoveEtkinGeo.UcgenNo)

                                    'taşınan nokta yeniden basıldı.
                                    'AralikSay = MovingNokta.AralikList.Count
                                    'MovingNokta.MovedaBasildi = True
                                    'Exit Do
                                    MovingNokta.NoktaSilindi = False

                                    AramailkNoktasi = TotalNoktaList(TotalUcgenList(MoveEtkinGeo.UcgenNo).KenarList(0).KarsiNoktaNo)

                                    Dim PolyBagNokta1 As Nokta = TotalNoktaList(PolygonList(MovedPolygonNo).PolyNoktaList((PolyNoktaSiraNo + 1) Mod PolygonList(MovedPolygonNo).PolyNoktaList.Count))
                                    If PolyBagNokta1.NoktaSilindi = False Then

                                        For Araliksay3 = 0 To MovingNokta.AralikList.Count - 1

                                            If MovingNokta.AralikList(Araliksay3).Disabled = False Then

                                                Dim Arakenar As Kenar = TotalUcgenList(MovingNokta.AralikList(Araliksay3).UcgenNo).KenarList(MovingNokta.AralikList(Araliksay3).UcgeniciKarsiKenarNo)
                                                If MovingNokta.AralikList(Araliksay3).GidenUcNo <> PolyBagNokta1.NoktaNo And MovingNokta.AralikList(Araliksay3).GelenUcNo <> PolyBagNokta1.NoktaNo Then
                                                    'BagEtkinGeo1 = PointToPointQuery2(MovingNokta, PolyBagNokta1.KendiYeri, False, MovingNokta.AralikList(Araliksay3), 0)
                                                    If CollKesisimHesapla(Arakenar, MovingNokta, PolyBagNokta1.KendiYeri, 0, TotalNoktaList).Durum > 0 Then

                                                        RneAnswer = KosedenKoseyeBagla(PolyBagNokta1, MovingNokta, MovingNokta.AralikList(Araliksay3), True, RneAnswer, MovingNokta.NoktaPolyNo)
                                                        If RneAnswer.Connected = False And RneAnswer.OncekiDoluKenar IsNot Nothing Then
                                                            RneAnswer.karsiNokta = PolyBagNokta1
                                                            Exit Do
                                                        Else
                                                            'BoyamaKenari1, BoyamaKenari2
                                                            BoyamaKenari1 = TotalUcgenList(RneAnswer.EarSonUcgen).KenarList(2)
                                                            BoyamaKenari1.PolyKenar = False
                                                            BoyamaKenari1.DisKenar = True
                                                            BoyamaKenari1.KenarPolyNo = MovedPolygonNo
                                                            TotalUcgenList(BoyamaKenari1.KomsuNo).KenarList(BoyamaKenari1.KomsudaKacinciKenarNo).PolyKenar = False
                                                            TotalUcgenList(BoyamaKenari1.KomsuNo).KenarList(BoyamaKenari1.KomsudaKacinciKenarNo).DisKenar = True
                                                            TotalUcgenList(BoyamaKenari1.KomsuNo).KenarList(BoyamaKenari1.KomsudaKacinciKenarNo).KenarPolyNo = MovedPolygonNo
                                                            KenardanUcgenBoya(BoyamaKenari1, RneAnswer.EarSonUcgen, MovingNokta.NoktaPolyNo)

                                                            'If ChkBozukBul1.Checked = True Then
                                                            '    BozukUcgenBul()
                                                            '    If FatalError Then Exit Sub
                                                            'End If
                                                            Exit For
                                                        End If

                                                    End If
                                                Else
                                                    If MovingNokta.AralikList(Araliksay3).GidenUcNo = PolyBagNokta1.NoktaNo Then
                                                        BoyamaKenari1 = TotalUcgenList(MovingNokta.AralikList(Araliksay3).UcgenNo).KenarList(MovingNokta.AralikList(Araliksay3).UcgeniciGidenKenarNo)
                                                        BoyamaKenari1.PolyKenar = False
                                                        BoyamaKenari1.DisKenar = True
                                                        BoyamaKenari1.KenarPolyNo = MovedPolygonNo
                                                        TotalUcgenList(BoyamaKenari1.KomsuNo).KenarList(BoyamaKenari1.KomsudaKacinciKenarNo).PolyKenar = False
                                                        TotalUcgenList(BoyamaKenari1.KomsuNo).KenarList(BoyamaKenari1.KomsudaKacinciKenarNo).DisKenar = True
                                                        TotalUcgenList(BoyamaKenari1.KomsuNo).KenarList(BoyamaKenari1.KomsudaKacinciKenarNo).KenarPolyNo = MovedPolygonNo
                                                        KenardanUcgenBoya(BoyamaKenari1, MovingNokta.AralikList(Araliksay3).UcgenNo, MovingNokta.NoktaPolyNo)
                                                    End If
                                                    If MovingNokta.AralikList(Araliksay3).GelenUcNo = PolyBagNokta1.NoktaNo Then
                                                        BoyamaKenari1 = TotalUcgenList(MovingNokta.AralikList(Araliksay3).UcgenNo).KenarList(MovingNokta.AralikList(Araliksay3).UcgeniciGelenKenarNo)
                                                        BoyamaKenari1.PolyKenar = False
                                                        BoyamaKenari1.DisKenar = True
                                                        BoyamaKenari1.KenarPolyNo = MovedPolygonNo
                                                        TotalUcgenList(BoyamaKenari1.KomsuNo).KenarList(BoyamaKenari1.KomsudaKacinciKenarNo).PolyKenar = False
                                                        TotalUcgenList(BoyamaKenari1.KomsuNo).KenarList(BoyamaKenari1.KomsudaKacinciKenarNo).DisKenar = True
                                                        TotalUcgenList(BoyamaKenari1.KomsuNo).KenarList(BoyamaKenari1.KomsudaKacinciKenarNo).KenarPolyNo = MovedPolygonNo
                                                        KenardanUcgenBoya(BoyamaKenari1, MovingNokta.AralikList(Araliksay3).UcgenNo, MovingNokta.NoktaPolyNo)
                                                    End If
                                                    Exit For
                                                End If
                                            Else
                                            End If
                                        Next
                                    End If

                                    Dim PolyBagNokta2no As Integer = PolyNoktaSiraNo - 1
                                    If PolyBagNokta2no < 0 Then PolyBagNokta2no = PolygonList(MovedPolygonNo).PolyNoktaList.Count - 1
                                    Dim PolyBagNokta2 As Nokta = TotalNoktaList(PolygonList(MovedPolygonNo).PolyNoktaList(PolyBagNokta2no))

                                    If PolyBagNokta2.NoktaSilindi = False Then

                                        For Araliksay3 = 0 To MovingNokta.AralikList.Count - 1
                                            If MovingNokta.AralikList(Araliksay3).Disabled = False Then
                                                Dim Arakenar As Kenar = TotalUcgenList(MovingNokta.AralikList(Araliksay3).UcgenNo).KenarList(MovingNokta.AralikList(Araliksay3).UcgeniciKarsiKenarNo)

                                                If MovingNokta.AralikList(Araliksay3).GidenUcNo <> PolyBagNokta2.NoktaNo And MovingNokta.AralikList(Araliksay3).GelenUcNo <> PolyBagNokta2.NoktaNo Then
                                                    'BagEtkinGeo2 = PointToPointQuery2(MovingNokta, PolyBagNokta2.KendiYeri, False, MovingNokta.AralikList(Araliksay3), 0)
                                                    If CollKesisimHesapla(Arakenar, MovingNokta, PolyBagNokta2.KendiYeri, 0, TotalNoktaList).Durum > 0 Then

                                                        RneAnswer = KosedenKoseyeBagla(PolyBagNokta2, MovingNokta, MovingNokta.AralikList(Araliksay3), True, RneAnswer, MovingNokta.NoktaPolyNo)
                                                        If RneAnswer.Connected = False And RneAnswer.OncekiDoluKenar IsNot Nothing Then
                                                            RneAnswer.karsiNokta = PolyBagNokta2
                                                            Exit Do
                                                        Else

                                                            BoyamaKenari2 = TotalUcgenList(RneAnswer.EarSonUcgen).KenarList(2)
                                                            BoyamaKenari2.PolyKenar = False
                                                            BoyamaKenari2.DisKenar = True
                                                            BoyamaKenari2.KenarPolyNo = MovedPolygonNo
                                                            TotalUcgenList(BoyamaKenari2.KomsuNo).KenarList(BoyamaKenari2.KomsudaKacinciKenarNo).PolyKenar = False
                                                            TotalUcgenList(BoyamaKenari2.KomsuNo).KenarList(BoyamaKenari2.KomsudaKacinciKenarNo).DisKenar = True
                                                            TotalUcgenList(BoyamaKenari2.KomsuNo).KenarList(BoyamaKenari2.KomsudaKacinciKenarNo).KenarPolyNo = MovedPolygonNo
                                                            KenardanUcgenBoya(BoyamaKenari2, RneAnswer.EarSonUcgen, MovingNokta.NoktaPolyNo)
                                                            'yapilacak: komşuyuda doldur
                                                            'If ChkBozukBul1.Checked = True Then
                                                            '    BozukUcgenBul()
                                                            '    If FatalError Then Exit Sub
                                                            'End If
                                                            Exit For
                                                        End If

                                                    End If
                                                Else
                                                    If MovingNokta.AralikList(Araliksay3).GidenUcNo = PolyBagNokta2.NoktaNo Then
                                                        BoyamaKenari2 = TotalUcgenList(MovingNokta.AralikList(Araliksay3).UcgenNo).KenarList(MovingNokta.AralikList(Araliksay3).UcgeniciGidenKenarNo)
                                                        BoyamaKenari2.PolyKenar = False
                                                        BoyamaKenari2.DisKenar = True
                                                        BoyamaKenari2.KenarPolyNo = MovedPolygonNo
                                                        TotalUcgenList(BoyamaKenari2.KomsuNo).KenarList(BoyamaKenari2.KomsudaKacinciKenarNo).PolyKenar = False
                                                        TotalUcgenList(BoyamaKenari2.KomsuNo).KenarList(BoyamaKenari2.KomsudaKacinciKenarNo).DisKenar = True
                                                        TotalUcgenList(BoyamaKenari2.KomsuNo).KenarList(BoyamaKenari2.KomsudaKacinciKenarNo).KenarPolyNo = MovedPolygonNo
                                                        KenardanUcgenBoya(BoyamaKenari2, MovingNokta.AralikList(Araliksay3).UcgenNo, MovingNokta.NoktaPolyNo)
                                                    End If
                                                    If MovingNokta.AralikList(Araliksay3).GelenUcNo = PolyBagNokta2.NoktaNo Then
                                                        BoyamaKenari2 = TotalUcgenList(MovingNokta.AralikList(Araliksay3).UcgenNo).KenarList(MovingNokta.AralikList(Araliksay3).UcgeniciGelenKenarNo)
                                                        BoyamaKenari2.PolyKenar = False
                                                        BoyamaKenari2.DisKenar = True
                                                        BoyamaKenari2.KenarPolyNo = MovedPolygonNo
                                                        TotalUcgenList(BoyamaKenari2.KomsuNo).KenarList(BoyamaKenari2.KomsudaKacinciKenarNo).PolyKenar = False
                                                        TotalUcgenList(BoyamaKenari2.KomsuNo).KenarList(BoyamaKenari2.KomsudaKacinciKenarNo).DisKenar = True
                                                        TotalUcgenList(BoyamaKenari2.KomsuNo).KenarList(BoyamaKenari2.KomsudaKacinciKenarNo).KenarPolyNo = MovedPolygonNo
                                                        KenardanUcgenBoya(BoyamaKenari2, MovingNokta.AralikList(Araliksay3).UcgenNo, MovingNokta.NoktaPolyNo)
                                                    End If

                                                    Exit For
                                                End If

                                            Else

                                            End If
                                        Next

                                    End If


                                    Exit For

                                End If

                            ElseIf MoveEtkinGeo.Durum = 2 Then
                                'Console.WriteLine("dedeler sıçtık")
                                Return MoveEtkinGeo
                            End If

                        End If

                    Next
                    'testcode start

                    If MovingNokta.NoktaSilindi = True Then
                        'MovingNokta.KendiYeri.X = MovingNokta.KendiYeri.X - (MovingNokta.Moving.X)
                        'MovingNokta.KendiYeri.Y = MovingNokta.KendiYeri.Y - (MovingNokta.Moving.Y)
                        'burada amaç eğer basılacak noktanın koordinatına bir aramailknoktasından erişilememişse geometrideki sonraki
                        'noktadan yeni bir arama başlatmak, toplam nokta sayısı kadar arama yapıldığında üçgen bulunamamışsa exception oluşuyor.
                        Do
                            AramailkNoktasiArama = AramailkNoktasiArama + 1
                            AramailkNoktasi = TotalNoktaList((AramailkNoktasi.NoktaNo + 1) Mod TotalNoktaList.Count)

                            If AramailkNoktasiArama >= TotalNoktaList.Count - 2 Then
                                Beep()
                                FatalError = True
                                'Exit Function
                                'BtnJump.BackColor = Color.Red
                                AramailkNoktasiArama = 0
                                Exit Function
                            End If


                            If AramailkNoktasi.NoktaSilindi = False Then
                                Exit Do
                            End If
                        Loop
                    Else
                        Exit Do
                    End If
                    'testcode finish
                Loop
            End If
            Return RneAnswer
        End Function

        Public Sub KenardanUcgenBoya(ByVal BoyaliKenar As Kenar, ByVal UcgenNo As Integer, ByVal MovedPolygonNo As Integer)
            'If TotalNoktaList(BoyaliKenar.Uc1NoktaNo).NoktaPolyNo = TotalNoktaList(BoyaliKenar.Uc2NoktaNo).NoktaPolyNo Then
            Dim TetikUcgen1 As Ucgen = TotalUcgenList(UcgenNo)
            Dim TetikUcgen2 As Ucgen = TotalUcgenList(BoyaliKenar.KomsuNo)
            If TotalNoktaList(BoyaliKenar.KarsiNoktaNo).NoktaPolyNo = TotalNoktaList(BoyaliKenar.Uc1NoktaNo).NoktaPolyNo Then
                'yapilcak: holed ve kendini kesen poligonlarda düzgün doldurulamayabilir
                'ancak kendini kesenlerde üç noktada türemiş türündedir
                'holedler henüz yok ama onlarada nokta sınıfı içine içnokta değişkeni eklenerek sorgu düzeltilebilir.
                If TetikUcgen1.KenarList(0).KenarPolyNo > -1 Then
                    If TetikUcgen1.KenarList(1).KenarPolyNo > -1 Then
                        If TetikUcgen1.KenarList(2).KenarPolyNo > -1 Then
                            TetikUcgen1.Dolu = True
                            TetikUcgen1.UcgenPolyNo = MovedPolygonNo
                            TetikUcgen1.PolyEklendi = True
                        End If
                    End If
                End If
            ElseIf TotalNoktaList(TetikUcgen2.KenarList(BoyaliKenar.KomsudaKacinciKenarNo).KarsiNoktaNo).NoktaPolyNo = TotalNoktaList(BoyaliKenar.Uc1NoktaNo).NoktaPolyNo Then
                If TetikUcgen2.KenarList(0).KenarPolyNo > -1 Then
                    If TetikUcgen2.KenarList(1).KenarPolyNo > -1 Then
                        If TetikUcgen2.KenarList(2).KenarPolyNo > -1 Then
                            TetikUcgen2.Dolu = True
                            TetikUcgen2.UcgenPolyNo = MovedPolygonNo
                            TetikUcgen2.PolyEklendi = True
                        End If
                    End If
                End If
            Else
                TotalUcgenList(UcgenNo).Dolu = False
                TotalUcgenList(UcgenNo).UcgenPolyNo = -1
                TotalUcgenList(UcgenNo).PolyEklendi = False
            End If

            'End If
        End Sub

    End Class
End Namespace
