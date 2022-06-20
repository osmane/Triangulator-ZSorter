Imports System.Math
Imports System.Threading.Tasks
Imports System.Threading
Imports System.Diagnostics

Namespace Triangulator
    Public Class Polygon
        Public world As World
        Public PolygonList As List(Of Polygon)
        Public TotalUcgenList As List(Of Ucgen)
        Public TotalNoktaList As List(Of Nokta)
        'Public AnimPath As List(Of AnimPathPoint)
        Public PoinLineIntList As List(Of Nokta)
        Public NormalList As List(Of Kenar)
        Public DrectionList As List(Of Kenar)
        Public PolyNoktaList As New List(Of Integer)
        Public UcgenList As New List(Of Integer)
        Public PolyPolyNo As Integer
        Public Uzakliklar As New List(Of Point)
        Public PolyMerkez As New PointF
        Public EnUzakNokta As Integer
        Public EnUzakMesafe As Single
        Public EnUzakMesafeX As Single
        Public EnUzakMesafeY As Single
        Public MoveKucult As Boolean = False
        Public PolygonSilindi As Boolean = False
        Public mass As Double
        Public TotalArea As Double
        Dim NewPolyMoveHypo, PolyMoveHypo, SnapHypo As Single
        Public VelocityX As Single
        Public VelocityY As Single
        Public VelocityW As Single
        Public NewColl, OldColl As Collision
        Public CollisionFound As Boolean
        Public elasticity As Single
        Public Angle As Single
        Dim EtkinGeo As New PointToAnswer
        Dim dumyNokta, SnapTarget As PointF
        Dim tmpcoll As New Collision
        Dim moveFactory As TaskFactory
        Dim ui As Object
        Public doMove As Boolean
        Dim lineerpen As Pen
        Dim angularpen As Pen

        Property PolyMoveEnabled As Boolean
            Get
                PolyMoveEnabled = Me.world.PolyMoveEnabled
            End Get
            Set(value As Boolean)
                Me.world.PolyMoveEnabled = value
            End Set
        End Property
        Public Sub New(ByRef world As World)
            Me.world = world
            Me.TotalUcgenList = world.TotalUcgenList
            Me.TotalNoktaList = world.TotalNoktaList
            'Me.AnimPath = world.AnimPath
            Me.PoinLineIntList = world.PoinLineIntList
            Me.NormalList = world.NormalList
            Me.DrectionList = world.DrectionList
            Me.lineerpen = New Pen(Color.Black, 1)
            Me.angularpen = New Pen(Color.Red, 1)
            Me.PolygonList = world.PolygonList
            Me.PolyPolyNo = world.PolygonList.Count
            Me.CollisionFound = False
            Me.mass = 1
            Me.TotalArea = 1
            Me.elasticity = 1
            Me.moveFactory = New TaskFactory()
            Me.ui = TaskScheduler.FromCurrentSynchronizationContext()
            Me.Angle = 0
            Me.doMove = True
            dumyNokta.X = 0
            dumyNokta.Y = 0
        End Sub
        Public Function invMass() As Double
            Return If((mass = [Double].PositiveInfinity), 0, 1 / mass)
        End Function

        Public Function momentAboutCM() As Double
            Return mass * (Me.TotalArea) / 12
        End Function

        Public Function invMomentAboutCM() As Double
            Return If((mass = [Double].PositiveInfinity), 0, 12 / (mass * (Me.TotalArea)))
        End Function

        Public Function FindPolyCenter() As PointF
            Dim TriCenter As PointF
            Dim TriArea, TotalArea, TriUX, TriUY As Double
            For UcgenSay As Integer = 0 To Me.UcgenList.Count - 1
                'yapılacak: aşağıdaki test geçici.
                'If UcgenSay < Me.UcgenList.Count Then
                If UcgenList(UcgenSay) < TotalUcgenList.Count Then
                    TriCenter = TotalUcgenList(UcgenList(UcgenSay)).FindTriCenter
                    TriArea = TotalUcgenList(UcgenList(UcgenSay)).CalcTriArea
                    TriUX = TriUX + (TriCenter.X * TriArea)
                    TriUY = TriUY + (TriCenter.Y * TriArea)
                    TotalArea = TotalArea + TriArea
                    'Else
                    '    UcgenList.RemoveAt(UcgenSay)
                End If
                'End If
            Next
            Me.TotalArea = TotalArea
            Me.PolyMerkez.X = TriUX / TotalArea
            Me.PolyMerkez.Y = TriUY / TotalArea
            Return Me.PolyMerkez
        End Function

        Public Sub WriteMinRotations()
            Dim SonUzaklik As Double
            Dim NoktaAcisi As Double
            For noktasay As Integer = 0 To Me.PolyNoktaList.Count - 1
                SonUzaklik = mathHelper.MesafeHesapla(TotalNoktaList(Me.PolyNoktaList(noktasay)).KendiYeri, Me.PolyMerkez)
                TotalNoktaList(Me.PolyNoktaList(noktasay)).Uzaklik = SonUzaklik
                NoktaAcisi = mathHelper.AciBul(Me.PolyMerkez, TotalNoktaList(Me.PolyNoktaList(noktasay)).KendiYeri)
                TotalNoktaList(Me.PolyNoktaList(noktasay)).Aci = NoktaAcisi
                If SonUzaklik > EnUzakMesafe Then
                    EnUzakMesafe = SonUzaklik
                    EnUzakNokta = Me.PolyNoktaList(noktasay)
                    EnUzakMesafeX = Me.PolyMerkez.X - TotalNoktaList(EnUzakNokta).KendiYeri.X
                    EnUzakMesafeY = Me.PolyMerkez.Y - TotalNoktaList(EnUzakNokta).KendiYeri.Y
                End If

                TotalNoktaList(Me.PolyNoktaList(noktasay)).MinRotation.X = _
                TotalNoktaList(Me.PolyNoktaList(noktasay)).KendiYeri.X - _
                (Me.PolyMerkez.X + SonUzaklik * Cos((1 + NoktaAcisi) * (PI / 180)))
                'Triangulator.Form1.TotalNoktaList(Me.PolyNoktaList(noktasay)).MinRotation.X = Triangulator.Form1.TotalNoktaList(Me.PolyNoktaList(noktasay)).KendiYeri.X
                TotalNoktaList(Me.PolyNoktaList(noktasay)).MinRotation.Y = _
               TotalNoktaList(Me.PolyNoktaList(noktasay)).KendiYeri.Y - _
                (Me.PolyMerkez.Y - SonUzaklik * Sin((1 + NoktaAcisi) * (PI / 180)))
                'Triangulator.Form1.TotalNoktaList(Me.PolyNoktaList(noktasay)).MinRotation.Y = Triangulator.Form1.TotalNoktaList(Me.PolyNoktaList(noktasay)).KendiYeri.Y
            Next
        End Sub

        Public Sub BasicPolyMove(ByVal finish As PointF, ByVal SaveAnim As Boolean)


            PolyMoveHypo = mathHelper.MesafeHesapla(Me.PolyMerkez, finish)
            Me.world.CollisionFound = False
            If Me.world.FatalError Then Exit Sub
            If SaveAnim Then
                Dim pathpoint As New AnimPathPoint
                pathpoint.PolyNo = Me.PolyPolyNo
                pathpoint.StartLoc = Me.PolyMerkez
                pathpoint.TargetLoc = finish

            End If
            If PolyMoveHypo > 2 Then
                'PoinLineIntList.Clear()
                NewPolyMoveHypo = PolyMoveHypo
                Do
                    Me.VelocityX = ((finish.X - Me.PolyMerkez.X) / NewPolyMoveHypo) * 1
                    Me.VelocityY = ((finish.Y - Me.PolyMerkez.Y) / NewPolyMoveHypo) * 1
                    SnapTarget.X = Me.VelocityX
                    SnapTarget.Y = Me.VelocityY
                    SnapHypo = mathHelper.MesafeHesapla(dumyNokta, SnapTarget)
                    'NewPolyMoveHypo = mathHelper.MesafeHesapla(Me.PolyMerkez, finish)
                    NewPolyMoveHypo = NewPolyMoveHypo - SnapHypo
                    If doMove Then
                        Me.PolygonJump(Me.PolyPolyNo, Me.VelocityX, Me.VelocityY, False, SaveAnim)
                    Else
                        Me.VelocityX = 0
                        Me.VelocityY = 0
                        Me.VelocityW = 0
                        Exit Do
                    End If

                    If Me.world.CollisionFound Then
                        Dim NewPolyTarget As PointF
                        NewPolyTarget.X = Me.PolyMerkez.X + Me.VelocityX * 1
                        NewPolyTarget.Y = Me.PolyMerkez.Y + Me.VelocityY * 1
                        Dim NewPolyTargetnok As New Nokta(Me.world)
                        NewPolyTargetnok.KendiYeri.X = NewPolyTarget.X
                        NewPolyTargetnok.KendiYeri.Y = NewPolyTarget.Y
                        PoinLineIntList.Add(NewPolyTargetnok)
                        Exit Do
                    End If


                    If (NewPolyMoveHypo <= 2) Or (SnapHypo < 0.01) Then
                        Me.doMove = False
                        Exit Do
                    End If

                Loop
            End If
            'Me.VelocityX = 0
            'Me.VelocityY = 0
            Me.world.PolyMoveEnabled = True
        End Sub

        Public Sub PolygonJump(ByVal MovedPolygonNo As Integer, ByVal PolyMoveXFark As Double, ByVal PolyMoveYFark As Double, ByVal CollTestEnable As Boolean, ByVal SaveAnim As Boolean)
            Dim moveTokenSource As New CancellationTokenSource()
            Dim CollKesCevap As New KesisimCevap
            Dim MovingNokta As Nokta
            'Dim MoveBakanNokta As Nokta

            Dim SonrakiNoktaKonumu As New PointF
            Dim BirNoktaSilindi As Boolean = False

            Dim ColledKenar As New Kenar
            Dim rneAnswer As PointToAnswer
            Dim MoveNoktaSay As Integer

            Dim MouseMoveXFark As Double = Me.VelocityX
            Dim MouseMoveYFark As Double = Me.VelocityY
            CollisionFound = False
            'CollTestKenar0, CollTestKenar1, CollTestKenar2,
            PoinLineIntList.Clear()
            'NormalList.Clear()
            MoveNoktaSay = 0
            'yapılacak: NoktaSay gibi ortak kullanılan değişken isimleri soruna neden olabiliyor. istisna oluşumlarında 
            'bu durum kontrol edilecek.
            'PolyMoveXFark: noktaların hareket farkı
            'MouseMoveXFark: merkezin hareket farkı
            If MovedPolygonNo > -1 Then
                Angle -= Me.VelocityW * (180 / PI)
                PolyMoveEnabled = False
                Do

                    MovingNokta = TotalNoktaList(Me.PolyNoktaList(MoveNoktaSay))

                    MovingNokta.Aci -= Me.VelocityW * (180 / PI)
                    PolyMoveXFark = (Me.PolyMerkez.X + (MovingNokta.Uzaklik * Cos(MovingNokta.Aci * (PI / 180))) + (MouseMoveXFark)) - MovingNokta.KendiYeri.X
                    PolyMoveYFark = (Me.PolyMerkez.Y - (MovingNokta.Uzaklik * Sin(MovingNokta.Aci * (PI / 180))) + (MouseMoveYFark)) - MovingNokta.KendiYeri.Y

                    If MovingNokta.NoktaSilindi = False Then
                        SonrakiNoktaKonumu = (MovingNokta.KendiYeri)
                        If MovingNokta.NoktaPolyNo = MovedPolygonNo Then
                            SonrakiNoktaKonumu.X = (MovingNokta.KendiYeri.X) + PolyMoveXFark
                            SonrakiNoktaKonumu.Y = (MovingNokta.KendiYeri.Y) + PolyMoveYFark
                        End If


                        'If MovingNokta.Daraldi = False Then
                        'oob
                        MovingNokta.AraliklariTara(MovingNokta, MovedPolygonNo, SonrakiNoktaKonumu)
                        'oob
                        'End If

                    End If

                    SyncLock (Me)

                        If (MovingNokta.Daraldi = True) Then

                            Me.world.NoktaSil(MovingNokta.NoktaNo, False)


                            If Me.world.FatalError Then
                                Exit Sub
                            End If

                            MovingNokta.NoktaSilindi = True
                            MovingNokta.AralikList.Clear()
                            MovingNokta.DisableList.Clear()
                            BirNoktaSilindi = True
                            MovingNokta.Daraldi = False
                        End If

                        MovingNokta.Moving.X = PolyMoveXFark
                        MovingNokta.Moving.Y = PolyMoveYFark
                        MovingNokta.KendiYeri.X = MovingNokta.KendiYeri.X + (MovingNokta.Moving.X)
                        MovingNokta.KendiYeri.Y = MovingNokta.KendiYeri.Y + (MovingNokta.Moving.Y)


                        If BirNoktaSilindi = True Or MovingNokta.NoktaSilindi = True Then
                            ' Me.world.CizilenPolygonNo = Me.PolyPolyNo
                            'oob
                            rneAnswer = Me.world.ReNewEdge(MovingNokta, MovedPolygonNo, MoveNoktaSay)
                            'oob
                            If rneAnswer IsNot Nothing Then
                                If rneAnswer.OncekiDoluKenar IsNot Nothing Then
                                    If rneAnswer.OncekiDoluKenar.KenarPolyNo <> MovedPolygonNo Or rneAnswer.SonKesilenDoluPoly < -9 Then
                                        CollisionFound = True
                                        MovingNokta.OldMoving = MovingNokta.Moving
                                        'oob
                                        'If rneAnswer.Poligonized = True Then
                                        '    Button7.Text = "corner-coll"
                                        'Else
                                        '    Button7.Text = "edge-coll"
                                        'End If
                                        'oob

                                        If MovingNokta.NoktaSilindi = False Then

                                            Me.world.NoktaSil(MovingNokta.NoktaNo, False)

                                            MovingNokta.NoktaSilindi = True
                                            MovingNokta.AralikList.Clear()
                                            MovingNokta.DisableList.Clear()
                                        End If

                                        Dim GerisayNokta As Nokta
                                        For gerisay As Integer = (MoveNoktaSay) To 0 Step -1
                                            GerisayNokta = TotalNoktaList(Me.PolyNoktaList(gerisay))
                                            If GerisayNokta.NoktaSilindi = False Then

                                                Me.world.NoktaSil(GerisayNokta.NoktaNo, False)

                                                GerisayNokta.NoktaSilindi = True
                                                GerisayNokta.AralikList.Clear()
                                                GerisayNokta.DisableList.Clear()
                                            End If

                                            GerisayNokta.KendiYeri.X = GerisayNokta.KendiYeri.X - GerisayNokta.Moving.X
                                            GerisayNokta.KendiYeri.Y = GerisayNokta.KendiYeri.Y - GerisayNokta.Moving.Y
                                            GerisayNokta.OldMoving = GerisayNokta.Moving
                                            GerisayNokta.Moving.X = 0
                                            GerisayNokta.Moving.Y = 0
                                            If GerisayNokta.NoktaSilindi = True Then
                                                'oob
                                                Me.world.ReNewEdge(GerisayNokta, MovedPolygonNo, gerisay)
                                                'oob
                                            End If
                                            'BirNoktaSilindi = GerisayNokta.NoktaSilindi
                                        Next
                                        PolyMoveXFark = 0
                                        PolyMoveYFark = 0
                                        MouseMoveXFark = 0
                                        MouseMoveYFark = 0
                                        Me.WriteMinRotations()
                                        Me.PolyMerkez.X = Me.PolyMerkez.X - (MouseMoveXFark)
                                        Me.PolyMerkez.Y = Me.PolyMerkez.Y - (MouseMoveYFark)
                                        Exit Do
                                        'Else

                                    End If
                                End If
                            End If
                            BirNoktaSilindi = MovingNokta.NoktaSilindi

                        End If

                        If BirNoktaSilindi = False And MoveNoktaSay >= Me.PolyNoktaList.Count - 1 Then 'And Sayac > 1
                            'MoveNoktaSay = 0
                            Exit Do
                        ElseIf BirNoktaSilindi = False Then
                            MoveNoktaSay = MoveNoktaSay + 1

                            'yapilacak: poligondaki tüm noktalara daralma durumunda silinebilir
                            'bu durumda nokasil exception verir finalde kontrol eklenecek
                        End If
                    End SyncLock
                Loop

                SyncLock (Me)
                    If CollisionFound = False Then
                        Me.PolyMerkez.X = Me.PolyMerkez.X + (MouseMoveXFark)
                        Me.PolyMerkez.Y = Me.PolyMerkez.Y + (MouseMoveYFark)

                        'For MoveNoktaSay = 0 To Me.PolyNoktaList.Count - 1
                        '    MovingNokta = TotalNoktaList(Me.PolyNoktaList(MoveNoktaSay))
                        '    'If ChkBozukBul1.Checked = True Then
                        '    '    BozukUcgenBul()
                        '    '    If FatalError Then Exit Sub
                        '    'End If
                        'Next
                    ElseIf rneAnswer.SonKesilenDoluPoly > -1 Then
                        Dim coll As New Collision
                        Dim normalnokta As New Nokta(Me.world)
                        Dim impNokta As New Nokta(Me.world)
                        Dim NormalUc1 As New Nokta(Me.world)
                        Dim NormalUc2 As New Nokta(Me.world)
                        Dim OldMoveLoc As PointF
                        Dim NormalAci As Double
                        Dim izduscevap As KesisimCevap
                        Dim DikPoint As PointF
                        Dim OtherPolygon As Polygon

                        ColledKenar = Nothing
                        If rneAnswer.Poligonized = True Then
                            'OldMoveLoc.X = MovingNokta.KendiYeri.X - MovingNokta.OldMoving.X
                            'OldMoveLoc.Y = MovingNokta.KendiYeri.Y - MovingNokta.OldMoving.Y
                            'For AralikSay = 0 To MovingNokta.AralikList.Count - 1
                            '    If MovingNokta.AralikList(AralikSay).Disabled = False Then
                            '        EtkinGeo = PointToPointQuery2(MovingNokta, OldMoveLoc, False, MovingNokta.AralikList(AralikSay), 0, TotalNoktaList, TotalUcgenList)
                            '        If EtkinGeo.Durum = 2 Then
                            '            ColledKenar = EtkinGeo.ilKesilenDiskenar
                            '            impNokta.KendiYeri = EtkinGeo.KesNok
                            '            Exit For
                            '        End If
                            '    End If
                            'Next
                            'If ColledKenar Is Nothing Then
                            '    For AralikSay = 0 To MovingNokta.AralikList.Count - 1
                            '        If MovingNokta.AralikList(AralikSay).Disabled = False Then
                            '            EtkinGeo = PointToPointQuery2(MovingNokta, OldMoveLoc, False, MovingNokta.AralikList(AralikSay), 0, TotalNoktaList, TotalUcgenList)
                            '            If EtkinGeo.Durum = 1 Then
                            '                ColledKenar = TotalUcgenList(MovingNokta.AralikList(AralikSay).UcgenNo).KenarList(MovingNokta.AralikList(AralikSay).UcgeniciKarsiKenarNo)
                            '                impNokta.KendiYeri = EtkinGeo.KesNok
                            '                Exit For
                            '            End If
                            '        End If
                            '    Next
                            'End If
                            ColledKenar = MovingNokta.darKarsi
                            impNokta.KendiYeri = MovingNokta.KendiYeri
                        Else
                            ColledKenar = New Kenar
                            Dim sonrakiNoktaNo1, sonrakiNoktaNo2, sonrakiNoktaNo As Integer
                            sonrakiNoktaNo1 = (((MovingNokta.NoktaNo - Me.PolyNoktaList(0)) + 1) Mod (Me.PolyNoktaList.Count)) + Me.PolyNoktaList(0)
                            Dim testAci1 = GetAngle(MovingNokta.KendiYeri, rneAnswer.KesNok, TotalNoktaList(sonrakiNoktaNo1).KendiYeri)

                            sonrakiNoktaNo2 = MovingNokta.NoktaNo - 1
                            If sonrakiNoktaNo2 < Me.PolyNoktaList(0) Then sonrakiNoktaNo2 = Me.PolyNoktaList(Me.PolyNoktaList.Count - 1)
                            Dim testAci2 = GetAngle(MovingNokta.KendiYeri, rneAnswer.KesNok, TotalNoktaList(sonrakiNoktaNo2).KendiYeri)

                            If (Abs(180 - testAci1)) < (Abs(180 - testAci2)) Then
                                sonrakiNoktaNo = sonrakiNoktaNo1
                            Else
                                sonrakiNoktaNo = sonrakiNoktaNo2
                            End If

                            ColledKenar.Uc1NoktaNo = MovingNokta.NoktaNo
                            ColledKenar.Uc2NoktaNo = sonrakiNoktaNo

                            impNokta.KendiYeri = rneAnswer.KesNok
                        End If
                        ColledKenar.Angle = AciBul(TotalNoktaList(ColledKenar.Uc1NoktaNo).KendiYeri, TotalNoktaList(ColledKenar.Uc2NoktaNo).KendiYeri)

                        Dim RealCollKenar As Kenar = ColledKenar
                        impNokta.KendiYeri = PointLineIntsct(RealCollKenar, impNokta.KendiYeri).KesisimNok
                        'Dim stepval As Integer
                        'For adddiff As Integer = 1 To 20
                        '    If rneAnswer.OncekiDoluKenar.Uc1NoktaNo < rneAnswer.OncekiDoluKenar.Uc2NoktaNo Then stepval = 1 Else stepval = -1
                        '    For OtherNoktaNo As Integer = rneAnswer.OncekiDoluKenar.Uc1NoktaNo To rneAnswer.OncekiDoluKenar.Uc2NoktaNo Step stepval

                        '        ColledKenar = FindCollisionEdge(MovingNokta, TotalNoktaList(OtherNoktaNo), adddiff, rneAnswer.Poligonized)

                        '        If ColledKenar IsNot Nothing Then Exit For
                        '    Next
                        '    If ColledKenar IsNot Nothing Then Exit For
                        'Next

                        'If ColledKenar Is Nothing Then
                        '    For adddiff As Integer = 1 To 20
                        '        For OtherNoktaNo As Integer = PolygonList(rneAnswer.SonKesilenDoluPoly).PolyNoktaList(0) To PolygonList(rneAnswer.SonKesilenDoluPoly).PolyNoktaList(PolygonList(rneAnswer.SonKesilenDoluPoly).PolyNoktaList.Count - 1)

                        '            ColledKenar = FindCollisionEdge(MovingNokta, TotalNoktaList(OtherNoktaNo), adddiff, rneAnswer.Poligonized)

                        '            If ColledKenar IsNot Nothing Then Exit For
                        '        Next
                        '        If ColledKenar IsNot Nothing Then Exit For
                        '    Next
                        'End If
                        'Dim RealCollKenar As Kenar = getRealKenar(ColledKenar)

                        'impNokta = TotalNoktaList(ColledKenar.ImpactNoktaNo)
                        'RealCollKenar.Angle = AciBul(TotalNoktaList(RealCollKenar.Uc1NoktaNo).KendiYeri, TotalNoktaList(RealCollKenar.Uc2NoktaNo).KendiYeri)

                        'If impNokta.NoktaPolyNo = MovedPolygonNo Then
                        '    OtherPolygon = PolygonList(TotalNoktaList(ColledKenar.Uc1NoktaNo).NoktaPolyNo)
                        '    OtherPolygon.PolyPolyNo = TotalNoktaList(ColledKenar.Uc1NoktaNo).NoktaPolyNo
                        'Else
                        '    OtherPolygon = PolygonList(impNokta.NoktaPolyNo)
                        '    OtherPolygon.PolyPolyNo = impNokta.NoktaPolyNo
                        'End If
                        OtherPolygon = PolygonList(rneAnswer.SonKesilenDoluPoly)
                        OtherPolygon.PolyPolyNo = rneAnswer.SonKesilenDoluPoly
                        normalnokta.Color = Color.Green

                        If rneAnswer.Poligonized = False Then
                            OldMoveLoc.X = impNokta.KendiYeri.X + MovingNokta.OldMoving.X
                            OldMoveLoc.Y = impNokta.KendiYeri.Y + MovingNokta.OldMoving.Y
                        Else
                            OldMoveLoc.X = impNokta.KendiYeri.X - MovingNokta.OldMoving.X
                            OldMoveLoc.Y = impNokta.KendiYeri.Y - MovingNokta.OldMoving.Y
                        End If

                        'yapilacak: kenar normalleri poligon çizilirken hesaplanacak, burada rotate değeri eklenecek.

                        izduscevap = PointLineIntsct(RealCollKenar, OldMoveLoc)

                        DikPoint.X = impNokta.KendiYeri.X + (OldMoveLoc.X - izduscevap.KesisimNok.X)
                        DikPoint.Y = impNokta.KendiYeri.Y + (OldMoveLoc.Y - izduscevap.KesisimNok.Y)

                        NormalAci = AciBul(impNokta.KendiYeri, DikPoint)


                        'normalnokta.KendiYeri.X = impNokta.KendiYeri.X + (30 * Cos((NormalAci) * (PI / 180)))
                        'normalnokta.KendiYeri.Y = impNokta.KendiYeri.Y - (30 * Sin((NormalAci) * (PI / 180)))
                        normalnokta.KendiYeri.X = (Cos((NormalAci) * (PI / 180)))
                        normalnokta.KendiYeri.Y = -(Sin((NormalAci) * (PI / 180)))

                        Dim EdgeNormal As New Kenar
                        EdgeNormal.start = impNokta.KendiYeri
                        EdgeNormal.finish.X = impNokta.KendiYeri.X + (50 * Cos((NormalAci) * (PI / 180)))
                        EdgeNormal.finish.Y = impNokta.KendiYeri.Y + -(50 * Sin((NormalAci) * (PI / 180)))
                        NormalList.Add(EdgeNormal)

                        coll.Rx = ColledKenar.Uc1NoktaNo
                        coll.Ry = ColledKenar.Uc2NoktaNo
                        coll.normalX = normalnokta.KendiYeri.X
                        coll.normalY = normalnokta.KendiYeri.Y
                        coll.impactX = impNokta.KendiYeri.X
                        coll.impactY = impNokta.KendiYeri.Y
                        'OtherPolygon.mass = 10
                        'Me.mass = 0.000001
                        Me.PolyPolyNo = MovedPolygonNo

                        'testcode start
                        'If Me.NewColl IsNot Nothing Then
                        '    Console.WriteLine("meNewCollimpactx: " + Me.NewColl.impactX.ToString + " MeNewCollimpactY: " + Me.NewColl.impactY.ToString)
                        '    tmpcoll.impactX = Me.NewColl.impactX
                        '    tmpcoll.impactY = Me.NewColl.impactY
                        '    tmpcoll.normalX = Me.NewColl.normalX
                        '    tmpcoll.normalY = Me.NewColl.normalY
                        'End If
                        'If OtherPolygon.NewColl IsNot Nothing Then
                        '    Console.WriteLine("otherNewCollimpactx: " + OtherPolygon.NewColl.impactX.ToString + " otherNewCollimpactY: " + OtherPolygon.NewColl.impactY.ToString)
                        'End If
                        'Console.WriteLine("collimpactx :" + coll.impactX.ToString + " collimpacty: " + coll.impactY.ToString + Environment.NewLine)
                        'testcode finish
                        Me.NewColl = coll
                        OtherPolygon.NewColl = coll
                        Me.VelocityW = 0
                        If Me.NewColl.isEqual(Me.OldColl) = False And Me.NewColl.isEqual(OtherPolygon.OldColl) = False Then
                            doMove = True
                            OtherPolygon.doMove = True
                            If world.logImpacts Then

                                Form1.LogToFile("AfterMe: " & Me.PolyPolyNo.ToString & " Center: " & Me.PolyMerkez.ToString _
                                            & " Xvel: " & Me.VelocityX.ToString & " Yvel: " & Me.VelocityY.ToString & " Wvel :" & Me.VelocityW & " MeoldCollX: " & Me.OldColl.impactX.ToString & " MeoldCollY: " & Me.OldColl.impactY.ToString, "impLog.txt")
                                Form1.LogToFile("AfterOt: " & OtherPolygon.PolyPolyNo.ToString & " Center: " & OtherPolygon.PolyMerkez.ToString _
                                                & " Xvel: " & OtherPolygon.VelocityX.ToString & " Yvel: " & OtherPolygon.VelocityY.ToString & " Wvel :" & OtherPolygon.VelocityW _
                                                & " Normal: " & normalnokta.KendiYeri.ToString, "impLog.txt")

                                addImpact(coll, OtherPolygon, Me)

                                Form1.LogToFile("BeforeMe: " & Me.PolyPolyNo.ToString & " Center: " & Me.PolyMerkez.ToString _
                                              & " Xvel: " & Me.VelocityX.ToString & " Yvel: " & Me.VelocityY.ToString & " Wvel :" & Me.VelocityW, "impLog.txt")
                                Form1.LogToFile("BeforeOt: " & OtherPolygon.PolyPolyNo.ToString & " Center: " & OtherPolygon.PolyMerkez.ToString _
                                                & " Xvel: " & OtherPolygon.VelocityX.ToString & " Yvel: " & OtherPolygon.VelocityY.ToString & " Wvel :" _
                                                & OtherPolygon.VelocityW & impNokta.KendiYeri.ToString & Environment.NewLine, "impLog.txt")
                            Else
                                'addImpact(coll, Me, OtherPolygon)
                                addImpact(coll, OtherPolygon, Me)
                            End If

                            OtherPolygon.OldColl = coll
                            Me.OldColl = coll

                            Dim OtherPolyTargetnok As New Nokta(Me.world)
                            Dim OtherPolyTarget As PointF
                            OtherPolyTargetnok.Color = Color.Red
                            OtherPolyTarget.X = OtherPolygon.PolyMerkez.X + OtherPolygon.VelocityX * 10
                            OtherPolyTarget.Y = OtherPolygon.PolyMerkez.Y + OtherPolygon.VelocityY * 10
                            OtherPolygon.VelocityW = OtherPolygon.VelocityW * 1.5

                            Dim MovedPolyTargetnok As New Nokta(Me.world)
                            Dim MovedPolyTarget As PointF
                            MovedPolyTargetnok.Color = Color.Gray


                            MovedPolyTargetnok.KendiYeri.X = MovedPolyTarget.X
                            MovedPolyTargetnok.KendiYeri.Y = MovedPolyTarget.Y
                            PoinLineIntList.Add(MovedPolyTargetnok)

                            OtherPolyTargetnok.KendiYeri.X = OtherPolyTarget.X
                            OtherPolyTargetnok.KendiYeri.Y = OtherPolyTarget.Y
                            PoinLineIntList.Add(OtherPolyTargetnok)
                            'testcode start
                            'OtherPolygon.VelocityX = 0
                            'OtherPolygon.VelocityY = 0
                            'OtherPolygon.VelocityW = 0
                            'testcode finish
                            'oob

                            'OtherPolygon.PolyMoveHypo = 0
                            'Me.PolyMoveHypo = 0
                            '    OtherPolygon.NewPolyMoveHypo = 0
                            '    Me.NewPolyMoveHypo = 0
                            If MesafeHesapla(OtherPolygon.PolyMerkez, OtherPolyTarget) >= 2 Then
                                OtherPolygon.BasicPolyMove(OtherPolyTarget, False)
                                OtherPolygon.VelocityW = 0
                            Else
                                OtherPolygon.doMove = False
                                OtherPolygon.VelocityX = 0
                                OtherPolygon.VelocityY = 0
                                OtherPolygon.VelocityW = 0
                            End If

                            Dim lineerLine As New Kenar
                            lineerLine.start = OtherPolygon.PolyMerkez
                            lineerLine.finish.X = OtherPolygon.PolyMerkez.X + (OtherPolygon.VelocityX * 20)
                            lineerLine.finish.Y = OtherPolygon.PolyMerkez.Y + (OtherPolygon.VelocityY * 20)
                            lineerLine.Kalem = lineerpen
                            DrectionList.Add(lineerLine)

                            Dim angularline As New Kenar
                            angularline.start = OtherPolygon.PolyMerkez
                            angularline.finish.X = OtherPolygon.PolyMerkez.X + 50 * Cos(OtherPolygon.Angle * (PI / 180))
                            angularline.finish.Y = OtherPolygon.PolyMerkez.Y - 50 * Sin(OtherPolygon.Angle * (PI / 180))
                            angularline.Kalem = angularpen
                            DrectionList.Add(angularline)

                            MovedPolyTarget.X = Me.PolyMerkez.X + Me.VelocityX * 10
                            MovedPolyTarget.Y = Me.PolyMerkez.Y + Me.VelocityY * 10
                            If MesafeHesapla(Me.PolyMerkez, MovedPolyTarget) >= 2 Then
                                'Me.BasicPolyMove(MovedPolyTarget, False)
                                Me.VelocityW = 0
                            Else
                                Me.doMove = False
                                Me.VelocityX = 0
                                Me.VelocityY = 0
                                Me.VelocityW = 0
                            End If


                            'Exit Sub
                            'Me.VelocityX = 0
                            'Me.VelocityY = 0
                            'Me.VelocityW = 0
                        Else
                            doMove = False
                            OtherPolygon.doMove = False
                            OtherPolygon.VelocityX = 0
                            OtherPolygon.VelocityY = 0
                            OtherPolygon.VelocityW = 0
                        End If

                        NormalUc1.Color = Color.Blue
                        NormalUc2.Color = Color.Violet
                        Dim OtherCenter As New Nokta(Me.world)
                        OtherCenter.KendiYeri = OtherPolygon.PolyMerkez
                        OtherCenter.Color = Color.Yellow
                        'PoinLineIntList.Add(OtherCenter)
                        'If ColledKenar Is Nothing Then
                        '    ColledKenar = rneAnswer.OncekiDoluKenar
                        '    NormalUc1.Color = Color.Green
                        '    NormalUc2.Color = Color.Green
                        'End If


                        'MovingNokta.Color = Color.Orange

                        'NormalUc1 = TotalNoktaList(rneAnswer.OncekiDoluKenar.Uc1NoktaNo)
                        'NormalUc2 = TotalNoktaList(rneAnswer.OncekiDoluKenar.Uc2NoktaNo)

                        If (ColledKenar IsNot (Nothing)) Then
                            NormalUc1.NoktaNo = ColledKenar.Uc1NoktaNo
                            NormalUc2.NoktaNo = ColledKenar.Uc2NoktaNo
                            NormalUc1.KendiYeri = TotalNoktaList(ColledKenar.Uc1NoktaNo).KendiYeri
                            NormalUc2.KendiYeri = TotalNoktaList(ColledKenar.Uc2NoktaNo).KendiYeri
                            'If (NormalUc1.NoktaPolyNo = NormalUc2.NoktaPolyNo) Then
                            '    NormalUc1.Color = Color.Blue
                            '    NormalUc2.Color = Color.Violet
                            'Else
                            '    NormalUc1.Color = Color.Red
                            '    NormalUc2.Color = Color.Red
                            'End If
                            PoinLineIntList.Add(NormalUc1)
                            PoinLineIntList.Add(NormalUc2)
                            'PoinLineIntList.Add(normalnokta)

                        End If
                        PoinLineIntList.Add(impNokta)

                    End If
                End SyncLock
                'PolyMoveEnabled = True
                'Application.DoEvents()
            End If
            Form1.pboxCanvas.Invalidate()
        End Sub
        Public Function getRealKenar(ByVal fakeKenar As Kenar) As Kenar
            Dim uc1Nokta As Nokta = TotalNoktaList(fakeKenar.Uc1NoktaNo)
            Dim TUcgen As Ucgen
            Dim TAralik As Aralik
            Dim TKenar As Kenar = Nothing
            For TAralikNo As Integer = 0 To uc1Nokta.AralikList.Count - 1
                TAralik = uc1Nokta.AralikList(TAralikNo)
                TUcgen = TotalUcgenList(TAralik.UcgenNo)
                If TUcgen.KenarList(TAralik.UcgeniciGelenKenarNo).Uc1NoktaNo = fakeKenar.Uc1NoktaNo Then
                    If TUcgen.KenarList(TAralik.UcgeniciGelenKenarNo).Uc1NoktaNo = fakeKenar.Uc2NoktaNo Then
                        TKenar = TUcgen.KenarList(TAralik.UcgeniciGelenKenarNo)
                        Return TKenar
                    ElseIf TUcgen.KenarList(TAralik.UcgeniciGelenKenarNo).Uc2NoktaNo = fakeKenar.Uc2NoktaNo Then
                        TKenar = TUcgen.KenarList(TAralik.UcgeniciGelenKenarNo)
                        Return TKenar
                    End If
                ElseIf TUcgen.KenarList(TAralik.UcgeniciGidenKenarNo).Uc1NoktaNo = fakeKenar.Uc1NoktaNo Then
                    If TUcgen.KenarList(TAralik.UcgeniciGidenKenarNo).Uc1NoktaNo = fakeKenar.Uc2NoktaNo Then
                        TKenar = TUcgen.KenarList(TAralik.UcgeniciGidenKenarNo)
                        Return TKenar
                    ElseIf TUcgen.KenarList(TAralik.UcgeniciGidenKenarNo).Uc2NoktaNo = fakeKenar.Uc2NoktaNo Then
                        TKenar = TUcgen.KenarList(TAralik.UcgeniciGidenKenarNo)
                        Return TKenar
                    End If
                End If
            Next
            Return TKenar
        End Function

        Public Function FindCollisionEdge(ByVal MovedPoint As Nokta, ByVal OtherPoint As Nokta, ByVal MoveDiff As Integer, ByVal CornerColl As Boolean) As Kenar
            Dim mswitch As Integer = -1
            Dim oswitch As Integer = -1
            Dim m, o As Integer
            Dim OtherPolygon As Polygon = PolygonList(OtherPoint.NoktaPolyNo)
            Dim MovedPolygon As Polygon = PolygonList(MovedPoint.NoktaPolyNo)
            Dim newMovedLoc As PointF
            Dim CevapList As New List(Of Kenar)
            Dim CollEdge As Kenar = Nothing
            For m = 1 To 2
                mswitch *= -1
                Dim mk As New Kenar
                mk.Uc1NoktaNo = MovedPoint.NoktaNo
                mk.Uc2NoktaNo = CyclePolyNoktaNo(mk.Uc1NoktaNo, MovedPolygon, mswitch)
                newMovedLoc.X = TotalNoktaList(mk.Uc1NoktaNo).KendiYeri.X + TotalNoktaList(mk.Uc1NoktaNo).OldMoving.X * MoveDiff
                newMovedLoc.Y = TotalNoktaList(mk.Uc1NoktaNo).KendiYeri.Y + TotalNoktaList(mk.Uc1NoktaNo).OldMoving.Y * MoveDiff
                For o = 1 To 2
                    oswitch *= -1
                    Dim ok As New Kenar
                    ok.Uc1NoktaNo = OtherPoint.NoktaNo
                    ok.Uc2NoktaNo = CyclePolyNoktaNo(ok.Uc1NoktaNo, OtherPolygon, oswitch)

                    Dim c As KesisimCevap = mathHelper.CollKesisimHesapla(ok, TotalNoktaList(mk.Uc2NoktaNo), newMovedLoc, 0, TotalNoktaList)
                    If c.Durum = 2 Then
                        CevapList.Add(mk)
                        CevapList.Add(ok)
                    End If

                    If CevapList.Count = 4 Then
                        If CevapList(0).isEqual(CevapList(2)) Then
                            CollEdge = CevapList(0)
                            If CevapList(1).Uc1NoktaNo = CevapList(3).Uc1NoktaNo Then
                                CollEdge.ImpactNoktaNo = CevapList(1).Uc1NoktaNo
                            ElseIf CevapList(1).Uc2NoktaNo = CevapList(3).Uc2NoktaNo Then
                                CollEdge.ImpactNoktaNo = CevapList(1).Uc1NoktaNo
                            Else
                                CollEdge.ImpactNoktaNo = -1
                            End If

                        ElseIf CevapList(0).isEqual(CevapList(2)) = False And CevapList(1).isEqual(CevapList(3)) Then
                            CollEdge = CevapList(1)
                            CollEdge.ImpactNoktaNo = MovedPoint.NoktaNo

                        ElseIf CevapList(0).isEqual(CevapList(2)) = False And CevapList(1).isEqual(CevapList(3)) = False Then
                            Dim isCtoCorner1 As KesisimCevap = CollKesisimHesapla(CevapList(1), TotalNoktaList(CevapList(0).Uc1NoktaNo), newMovedLoc, 0, TotalNoktaList)
                            If isCtoCorner1.Durum = 2 Then
                                CollEdge = CevapList(1)
                                CollEdge.ImpactNoktaNo = MovedPoint.NoktaNo
                            Else
                                'Dim isCtoCorner2 As KesisimCevap = CollKesisimHesapla(CevapList(3), TotalNoktaList(CevapList(2).Uc1NoktaNo), newMovedLoc, 0)
                                CollEdge = CevapList(3)
                                CollEdge.ImpactNoktaNo = MovedPoint.NoktaNo
                            End If
                        End If
                        Return CollEdge
                    End If

                Next
            Next
            Return CollEdge
        End Function

        Public Function CyclePolyNoktaNo(ByVal NoktaNo As Integer, ByVal Polygon As Polygon, ByVal StepSize As Integer) As Integer
            NoktaNo = NoktaNo + StepSize
            If (NoktaNo < TotalNoktaList(Polygon.PolyNoktaList(0)).NoktaNo) Then
                NoktaNo = TotalNoktaList(Polygon.PolyNoktaList(Polygon.PolyNoktaList.Count - 1)).NoktaNo
            ElseIf (NoktaNo > TotalNoktaList(Polygon.PolyNoktaList(Polygon.PolyNoktaList.Count - 1)).NoktaNo) Then
                NoktaNo = TotalNoktaList(Polygon.PolyNoktaList(0)).NoktaNo
            End If
            Return NoktaNo
        End Function

        Function PointLineIntsct(ByVal TestKenar As Kenar, ByVal TestNokta As PointF) As KesisimCevap
            Dim U As Double
            Dim X1, X2, X3, Y1, Y2, Y3 As Double
            Dim izdusumPoint As New PointF
            Dim cevap As New KesisimCevap

            X1 = TotalNoktaList(TestKenar.Uc1NoktaNo).KendiYeri.X
            Y1 = TotalNoktaList(TestKenar.Uc1NoktaNo).KendiYeri.Y
            X2 = TotalNoktaList(TestKenar.Uc2NoktaNo).KendiYeri.X
            Y2 = TotalNoktaList(TestKenar.Uc2NoktaNo).KendiYeri.Y
            X3 = TestNokta.X
            Y3 = TestNokta.Y

            U = ((X3 - X1) * (X2 - X1)) + ((Y3 - Y1) * (Y2 - Y1))
            U = U / (MesafeHesapla(TotalNoktaList(TestKenar.Uc1NoktaNo).KendiYeri, TotalNoktaList(TestKenar.Uc2NoktaNo).KendiYeri)) ^ 2
            izdusumPoint.X = X1 + U * (X2 - X1)
            izdusumPoint.Y = Y1 + U * (Y2 - Y1)

            cevap.KesisimNok = izdusumPoint
            Return cevap

        End Function

        Public Sub addImpact(cd As Collision, ByRef PolyA As Polygon, ByRef PolyB As Polygon)

            Dim nx As Double = cd.normalX
            ' n = normal vector pointing towards body
            Dim ny As Double = cd.normalY
            ' get the correct current location of corner, to get correct Rx, Ry
            ' because (impactX, impactY) may be from an interpenetration state.
            'cd.impactX = bods[cd.object].getCornerX(cd.corner);
            'cd.impactY = bods[cd.object].getCornerY(cd.corner);
            '
            '              cross product in the plane: unit vectors i,j,k
            '                (ax,ay,0) x (bx,by,0) = k(ax by - ay bx)
            '            

            Dim rax As Double, ray As Double, rbx As Double, rby As Double
            Dim vax As Double, vay As Double, wa As Double, vbx As Double, vby As Double, wb As Double
            Dim d As Double, dx As Double, dy As Double, j As Double
            If cd.normalObj < 0 Then
                ' wall collision
                'objB = cd.obje
                'offsetB = 6 * objB
                ' normal is pointing in towards body B, so it is correct here.
                ''rbx = cd.impactX - bods(objB).x
                rbx = cd.impactX - PolyB.PolyMerkez.X
                ' r = vector from cm to point of impact, p
                ''rby = cd.impactY - bods(objB).y
                rby = cd.impactY - PolyB.PolyMerkez.Y

                Dim Ib As Double = PolyB.momentAboutCM()
                Dim mb As Double = PolyB.mass
                ''vbx = vars(1 + offsetB)
                vbx = PolyB.VelocityX
                ''vby = vars(3 + offsetB)
                vby = PolyB.VelocityY
                ''wb = vars(5 + offsetB)
                wb = PolyB.VelocityW
                Dim e As Double = elasticity

                '
                '                  vb = old linear velocity of cm = (vbx, vby)
                '                  mb = mass
                '                  n = normal vector pointing towards body (length 1 here)
                '                  vb2 = new linear velocity of cm = (vbx2,vby2)
                '                  wb = old angular velocity = vars[5]
                '                  rb = vector from cm to point of impact
                '                  Ib = moment of inertia of body about cm
                '                  wb2 = new angular velocity
                '                  velocity of collision point = vb + w x rb
                '                       -(1 + elasticity) (v1 + w1 x r).n
                '                  j = -------------------------
                '                          n.n + (rp x n)^2
                '                          ---   --------
                '                           M       I
                '                

                ' cross product r x n = (rx, ry, 0) x (nx, ny, 0) = (0, 0, rx*ny - ry*nx)
                j = rbx * ny - rby * nx
                j = (j * j) / Ib + (1 / mb)
                ' make sure that normal velocity is negative, otherwise do nothing
                ' cross product: w1 x r = (0,0,w) x (rx, ry, 0) = (-w*ry, w*rx, 0)
                Dim normalVelocity As Double = (vbx - rby * wb) * nx + (vby + rbx * wb) * ny

                j = -(1 + e) * normalVelocity / j
                ' v2 = v1 + (j/M)n = new linear velocity
                PolyB.VelocityX += nx * j / mb
                PolyB.VelocityY += ny * j / mb
                ' w2 = w1 + j(r x n)/I = new angular velocity

                PolyB.VelocityW += j * (rbx * ny - rby * nx) / Ib
            Else
                ' object-object collision
                ' The vertex of body A is colliding into an edge of body B.
                ' The normal points out from body B, perpendicular to the edge.   
                ''rax = cd.impactX - bods(objA).x
                rax = cd.impactX - PolyA.PolyMerkez.X
                ' ra = vector from A's cm to point of impact, p
                ''ray = cd.impactY - bods(objA).y
                ray = cd.impactY - PolyA.PolyMerkez.Y
                ''rbx = cd.impactX - bods(objB).x
                rbx = cd.impactX - PolyB.PolyMerkez.X
                ' rb = vector from B's cm to point of impact
                ''rby = cd.impactY - bods(objB).y
                rby = cd.impactY - PolyB.PolyMerkez.Y
                '
                '                Ia = bods[objA].momentAboutCM();
                '                Ib = bods[objB].momentAboutCM();
                '                ma = bods[objA].mass;
                '                mb = bods[objB].mass;
                '                

                Dim invIa As Double, invIb As Double, invma As Double, invmb As Double
                ''invIa = bods(objA).invMomentAboutCM()
                invIa = PolyA.invMomentAboutCM()
                ''invIb = bods(objB).invMomentAboutCM()
                invIb = PolyB.invMomentAboutCM()
                ''invma = bods(objA).invMass()
                invma = PolyA.invMass()
                ''invmb = bods(objB).invMass()
                invmb = PolyB.invMass()
                nx = -nx
                ' reverse n so it points out from body A into body B
                ny = -ny
                ''vax = vars(1 + offsetA)
                vax = PolyA.VelocityX
                ''vay = vars(3 + offsetA)
                vay = PolyA.VelocityY
                ''wa = vars(5 + offsetA)
                wa = PolyA.VelocityW
                ''vbx = vars(1 + offsetB)
                vbx = PolyB.VelocityX
                ''vby = vars(3 + offsetB)
                vby = PolyB.VelocityY
                ''wb = vars(5 + offsetB)
                wb = PolyB.VelocityW
                '
                '                  ma = mass of body A
                '                  n = normal vector pointing out from body A (length 1 here)
                '                  j = impulse scalar
                '                  jn = impulse vector
                '                  va = old linear velocity of cm for body A
                '                  va2 = new linear velocity of cm
                '                  wa = old angular velocity for body A
                '                  wa2 = new angular velocity
                '                  ra = vector from body A cm to point of impact = (rax, ray)
                '                  Ia = moment of inertia of body A about center of mass
                '                  vab = relative velocity of contact points (vpa, vpb) on bodies
                '                  vab = (vpa - vpb)
                '                  vpa = va + wa x ra = velocity of contact point
                '                  vab = va + wa x ra - vb - wb x rb
                '
                '                                -(1 + elasticity) vab.n
                '                  j = -------------------------------------
                '                        1     1     (ra x n)^2    (rb x n)^2
                '                      (--- + ---) + ---------  + ---------
                '                        Ma   Mb        Ia           Ib
                '                  Note that we use -j for body B.
                '                

                ' cross product r x n = (rx, ry, 0) x (nx, ny, 0) = (0, 0, rx*ny - ry*nx)
                d = rax * ny - ray * nx
                j = d * d * invIa
                d = -rby * nx + rbx * ny
                j += d * d * invIb + invma + invmb
                ' vab.n = (va + wa x ra - vb - wb x rb) . n
                ' cross product: w x r = (0,0,w) x (rx, ry, 0) = (-w*ry, w*rx, 0)
                dx = (vax + wa * (-ray) - vbx - wb * (-rby))
                dy = (vay + wa * (rax) - vby - wb * (rbx))
                j = -(1 + elasticity) * (dx * nx + dy * ny) / j
                ' v2 = v1 + j n / m = new linear velocity
                ''velo(1 + offsetA) += j * nx * invma
                PolyA.VelocityX += j * nx * invma
                ''velo(3 + offsetA) += j * ny * invma
                PolyA.VelocityY += j * ny * invma
                ''velo(1 + offsetB) += -j * nx * invmb
                PolyB.VelocityX += -j * nx * invmb
                ''velo(3 + offsetB) += -j * ny * invmb
                PolyB.VelocityY += -j * ny * invmb
           
                ' w2 = w1 + j(r x n)/I = new angular velocity
                PolyA.VelocityW += j * (-ray * nx + rax * ny) * invIa
                PolyB.VelocityW += -j * (-rby * nx + rbx * ny) * invIb
            End If
        End Sub
    End Class
End Namespace