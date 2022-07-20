Imports System.Math
Imports System
Imports System.Xml
Imports System.IO
Imports System.Threading.Tasks
Imports System.Threading
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Namespace Triangulator
    Public Class Form1
        Public world As World
        Property TotalUcgenList As List(Of Ucgen)
            Get
                TotalUcgenList = world.TotalUcgenList
            End Get
            Set(value As List(Of Ucgen))
            End Set
        End Property

        Property TotalNoktaList As List(Of Nokta)
            Get
                TotalNoktaList = world.TotalNoktaList
            End Get
            Set(value As List(Of Nokta))
            End Set
        End Property

        Property PolygonList As List(Of Polygon)
            Get
                PolygonList = world.PolygonList
            End Get
            Set(value As List(Of Polygon))
            End Set
        End Property
        Property AramailkNoktasi As Nokta
            Get
                AramailkNoktasi = world.AramailkNoktasi
                Return world.AramailkNoktasi
            End Get
            Set(value As Nokta)
                world.AramailkNoktasi = value
            End Set
        End Property
        Property tmpMuseumPolygonGiden As List(Of Kenar)
            Get
                tmpMuseumPolygonGiden = world.tmpMuseumPolygonGiden
            End Get
            Set(value As List(Of Kenar))
            End Set
        End Property
        Property tmpMuseumPolygonGelen As List(Of Kenar)
            Get
                tmpMuseumPolygonGelen = world.tmpMuseumPolygonGelen
            End Get
            Set(value As List(Of Kenar))
            End Set
        End Property

        Property PolyMoveEnabled As Boolean
            Get
                PolyMoveEnabled = world.PolyMoveEnabled
            End Get
            Set(value As Boolean)
                world.PolyMoveEnabled = value
            End Set
        End Property
        Property ZoomFactor As Double
            Get
                ZoomFactor = world.ZoomFactor
            End Get
            Set(value As Double)
            End Set
        End Property

        Property PoinLineIntList As List(Of Nokta)
            Get
                PoinLineIntList = world.PoinLineIntList
            End Get
            Set(value As List(Of Nokta))
            End Set
        End Property

        Property Cemberlist As List(Of Integer)
            Get
                Cemberlist = world.Cemberlist
            End Get
            Set(value As List(Of Integer))

            End Set
        End Property

        Property NormalList As List(Of Kenar)
            Get
                NormalList = world.NormalList
            End Get
            Set(value As List(Of Kenar))
            End Set
        End Property
        Property DrectionList As List(Of Kenar)
            Get
                DrectionList = world.DrectionList
            End Get
            Set(value As List(Of Kenar))

            End Set
        End Property

        Dim ShowMuseum As Boolean = False
        Dim ilkNoktaDegisti As Boolean = False
        Dim gr As System.Drawing.Graphics
        Dim SelectedPolygonNo As Integer = -1
        Dim PolySelectMode As Boolean = False
        Dim Elpen As Pen = New Pen(Color.Blue, 1)
        Dim GidenP1, GelenP1 As PointF
        Dim OrtaP As New PointF
        Dim tmpArray(2) As PointF
        Dim firca As New SolidBrush(Color.Black)
        Dim GidenPen As Pen = New Pen(Color.Cyan, 2)
        Dim GelenPen As Pen = New Pen(Color.Magenta, 2)
        Dim karsiPen As Pen = New Pen(Color.Black, 2)
        Dim MuseGidenPen As Pen = New Pen(Color.Orange, 2)
        Dim MuseGelenPen As Pen = New Pen(Color.LightGreen, 2)
        Dim paintKomsuBag1, paintKomsuBag2, paintKomsuOrtaBag, paintKomsuKenar0Uc, paintKomsuKenar1Uc As New PointF
        Dim LinePath As New List(Of PointF)

        Dim PolyFill As Boolean = False
        Dim TargetNokta As Nokta
        Public KornerToKorner As Boolean = False
        Dim ZoomedLoc As PointF
        Dim EtkinGeo As New PointToAnswer
        Public MouseSeciliAralik As Integer
        Dim Label1Text As String
        Public ActiveXmlFileName As String
        Public WithEvents ActiveXmlDocument As New XmlDocument
        Public DocChanged As Boolean = False

        Dim AnimMode As Boolean = False
        Dim AnimPathLoc As Integer = 0
        Dim AdimYon As Integer
        Public AnimPath As New List(Of AnimPathPoint)
        Dim surdur As Integer
        Shared LogWriter As StreamWriter
        Const quote As String = """"
        Private Sub btnNewMap_Click(sender As System.Object, e As System.EventArgs) Handles btnNewMap.Click

            OsmXmlTreeCnt1.xml_document = Nothing
            Me.world = New World()

            ilkNoktaDegisti = False
            pboxCanvas.BackColor = Color.White
            Timer1.Enabled = True
            pboxCanvas.Refresh()
        End Sub

        Private Sub pboxCanvas_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pboxCanvas.Paint
            Dim UcgenSay, museumSay, AralikSay, KenarSay, NoktaSay As Integer
            Dim KenarOrta As Point
            Dim CizilenUcgen As Ucgen
            gr = e.Graphics
            For UcgenSay = 0 To TotalUcgenList.Count - 1
                CizilenUcgen = TotalUcgenList.Item(UcgenSay)
                If CizilenUcgen.UcgenPolyNo = SelectedPolygonNo And PolySelectMode = True Then
                    CizilenUcgen.Boya = True
                End If

                If CizilenUcgen.Boya = True Then
                    tmpArray(0) = TotalNoktaList.Item(CizilenUcgen.KenarList.Item(0).Uc1NoktaNo).KendiYeri
                    tmpArray(1) = TotalNoktaList.Item(CizilenUcgen.KenarList.Item(0).Uc2NoktaNo).KendiYeri
                    tmpArray(2) = TotalNoktaList.Item(CizilenUcgen.KenarList.Item(0).KarsiNoktaNo).KendiYeri
                    If PolySelectMode = False Then
                        ZoomedPolygon(gr, Brushes.Gray, tmpArray)
                        If CizilenUcgen.KenarList(0).KenarPolyNo > -1 Then
                            If CizilenUcgen.KenarList(1).KenarPolyNo > -1 Then
                                If CizilenUcgen.KenarList(2).KenarPolyNo > -1 Then
                                    ZoomedPolygon(gr, Brushes.Green, tmpArray)
                                End If
                            End If
                        End If
                    Else
                        If CizilenUcgen.PolyEklendi = True And CizilenUcgen.UcgenPolyNo = SelectedPolygonNo Then
                            ZoomedPolygon(gr, Brushes.GreenYellow, tmpArray)
                        End If

                    End If
                End If
                CizilenUcgen.Boya = False
                For KenarSay = 0 To 2

                    If CizilenUcgen.KenarList.Item(KenarSay).DisKenar = False Then
                        ZoomedLine(gr, Elpen, TotalNoktaList.Item(CizilenUcgen.KenarList.Item(KenarSay).Uc1NoktaNo).KendiYeri, TotalNoktaList.Item(CizilenUcgen.KenarList.Item(KenarSay).Uc2NoktaNo).KendiYeri)
                    ElseIf CizilenUcgen.KenarList.Item(KenarSay).PolyKenar = False Then
                        ZoomedLine(gr, Pens.Brown, TotalNoktaList.Item(CizilenUcgen.KenarList.Item(KenarSay).Uc1NoktaNo).KendiYeri, TotalNoktaList.Item(CizilenUcgen.KenarList.Item(KenarSay).Uc2NoktaNo).KendiYeri)
                    Else
                        ZoomedLine(gr, Pens.Black, TotalNoktaList.Item(CizilenUcgen.KenarList.Item(KenarSay).Uc1NoktaNo).KendiYeri, TotalNoktaList.Item(CizilenUcgen.KenarList.Item(KenarSay).Uc2NoktaNo).KendiYeri)
                    End If

                Next
            Next
            If PolySelectMode = False Then
                Dim paintkarsiucgen As Ucgen
                Dim karsikenar As Kenar
                Dim KarsiOrta As New Point
                For NoktaSay = 0 To TotalNoktaList.Count - 1
                    If TotalNoktaList.Item(NoktaSay).AralikList.Count > 0 Then
                        For AralikSay = 0 To TotalNoktaList.Item(NoktaSay).AralikList.Count - 1
                            If TotalNoktaList.Item(NoktaSay).AralikList(AralikSay).Boya = True Then
                                paintkarsiucgen = TotalUcgenList.Item(TotalNoktaList.Item(NoktaSay).AralikList(AralikSay).UcgenNo)
                                karsikenar = paintkarsiucgen.KenarList(TotalNoktaList.Item(NoktaSay).AralikList(AralikSay).UcgeniciKarsiKenarNo)
                                GidenP1 = TotalNoktaList(TotalNoktaList.Item(NoktaSay).AralikList(AralikSay).GidenUcNo).KendiYeri
                                GelenP1 = TotalNoktaList(TotalNoktaList.Item(NoktaSay).AralikList(AralikSay).GelenUcNo).KendiYeri
                                'OrtaP.X = (GidenP1.X + (GelenP1.X - GidenP1.X) / 2) - ((GidenP1.X + (GelenP1.X - GidenP1.X) / 2) - TotalNoktaList.Item(NoktaSay).KendiYeri.X) / 3
                                'OrtaP.Y = (GidenP1.Y + (GelenP1.Y - GidenP1.Y) / 2) - ((GidenP1.Y + (GelenP1.Y - GidenP1.Y) / 2) - TotalNoktaList.Item(NoktaSay).KendiYeri.Y) / 3
                                OrtaP = TotalUcgenList.Item(TotalNoktaList.Item(NoktaSay).AralikList(AralikSay).UcgenNo).FindTriCenter
                                ZoomedLine(gr, GidenPen, GidenP1, TotalNoktaList.Item(karsikenar.KarsiNoktaNo).KendiYeri)
                                ZoomedLine(gr, GelenPen, GelenP1, TotalNoktaList.Item(karsikenar.KarsiNoktaNo).KendiYeri)
                                ZoomedLine(gr, karsiPen, TotalNoktaList.Item(karsikenar.Uc1NoktaNo).KendiYeri, TotalNoktaList.Item(karsikenar.Uc2NoktaNo).KendiYeri)

                                gr.FillEllipse(Brushes.Red, CInt(KenarOrta.X / ZoomFactor), CInt(KenarOrta.Y / ZoomFactor), 5, 5)
                                gr.DrawEllipse(Pens.Red, CInt(OrtaP.X / ZoomFactor), CInt(OrtaP.Y / ZoomFactor), 5, 5)
                                If karsikenar.KomsuNo > -1 And karsikenar.KomsuNo < TotalUcgenList.Count Then
                                    paintKomsuBag1 = TotalNoktaList(TotalUcgenList(karsikenar.KomsuNo).KenarList(karsikenar.KomsudaKacinciKenarNo).Uc1NoktaNo).KendiYeri
                                    paintKomsuBag2 = TotalNoktaList(TotalUcgenList(karsikenar.KomsuNo).KenarList(karsikenar.KomsudaKacinciKenarNo).Uc2NoktaNo).KendiYeri
                                    ZoomedLine(gr, Pens.DimGray, paintKomsuBag1, OrtaP)
                                    ZoomedLine(gr, Pens.DarkOrange, paintKomsuBag2, OrtaP)
                                End If
                                TotalNoktaList.Item(NoktaSay).AralikList(AralikSay).Boya = False
                            End If
                        Next
                        If NoktaSay > 3 Then
                            LinePath.Add(TotalNoktaList.Item(NoktaSay).KendiYeri)
                        End If
                    End If
                Next
                If Cemberlist.Count > 0 Then
                    For CemberCount = 0 To Cemberlist.Count - 1
                        If Cemberlist(CemberCount) = 4 Then
                            gr.FillEllipse(Brushes.Red, TotalNoktaList(Cemberlist(CemberCount)).KendiYeri.X \ CInt(ZoomFactor) - 5, TotalNoktaList(Cemberlist(CemberCount)).KendiYeri.Y \ CInt(ZoomFactor) - 5, 10, 10)
                        Else
                            Try
                                gr.FillEllipse(Brushes.Black, TotalNoktaList(Cemberlist(CemberCount)).KendiYeri.X \ CInt(ZoomFactor) - 5, TotalNoktaList(Cemberlist(CemberCount)).KendiYeri.Y \ CInt(ZoomFactor) - 5, 10, 10)
                                gr.FillEllipse(Brushes.Blue, TotalNoktaList(TotalNoktaList(Cemberlist(CemberCount)).Bag1).KendiYeri.X \ CInt(ZoomFactor) - 5, TotalNoktaList(TotalNoktaList(Cemberlist(CemberCount)).Bag1).KendiYeri.Y \ CInt(ZoomFactor) - 5, 10, 10)
                                gr.FillEllipse(Brushes.Green, TotalNoktaList(TotalNoktaList(Cemberlist(CemberCount)).Bag2).KendiYeri.X \ CInt(ZoomFactor) - 5, TotalNoktaList(TotalNoktaList(Cemberlist(CemberCount)).Bag2).KendiYeri.Y \ CInt(ZoomFactor) - 5, 10, 10)

                            Catch ex As Exception
                                Exit Sub
                            End Try

                        End If
                    Next

                End If

                If LinePath.Count > 3 Then
                    If PolyFill = True Then
                        ZoomedPolygon(gr, Brushes.Gold, LinePath.ToArray)
                    End If
                End If

                gr.DrawEllipse(Pens.Red, CInt(AramailkNoktasi.KendiYeri.X / ZoomFactor - 3), CInt(AramailkNoktasi.KendiYeri.Y / ZoomFactor - 3), 6, 6)
                ZoomedLine(gr, Pens.IndianRed, AramailkNoktasi.KendiYeri, TargetNokta.KendiYeri)
                LinePath.Clear()
                If tmpMuseumPolygonGiden.Count > 0 And ShowMuseum Then


                    For museumSay = 0 To tmpMuseumPolygonGiden.Count - 1
                        Try
                            ZoomedLine(gr, MuseGidenPen, TotalNoktaList(tmpMuseumPolygonGiden(museumSay).Uc1NoktaNo).KendiYeri, TotalNoktaList(tmpMuseumPolygonGiden(museumSay).Uc2NoktaNo).KendiYeri)
                            If museumSay = tmpMuseumPolygonGiden.Count - 1 Then
                                gr.FillEllipse(Brushes.DarkOrange, TotalNoktaList(tmpMuseumPolygonGiden(museumSay).Uc1NoktaNo).KendiYeri.X \ CInt(ZoomFactor) - 5, TotalNoktaList(tmpMuseumPolygonGiden(museumSay).Uc1NoktaNo).KendiYeri.Y \ CInt(ZoomFactor) - 5, 10, 10)
                                gr.FillEllipse(Brushes.DarkOrchid, TotalNoktaList(tmpMuseumPolygonGiden(museumSay).Uc2NoktaNo).KendiYeri.X \ CInt(ZoomFactor) - 5, TotalNoktaList(tmpMuseumPolygonGiden(museumSay).Uc2NoktaNo).KendiYeri.Y \ CInt(ZoomFactor) - 5, 10, 10)
                            End If

                        Catch ex As Exception
                            ShowMuseum = False
                            Exit Sub
                        End Try
                    Next


                    For museumSay = 0 To tmpMuseumPolygonGelen.Count - 1
                        Try
                            ZoomedLine(gr, MuseGelenPen, TotalNoktaList(tmpMuseumPolygonGelen(museumSay).Uc1NoktaNo).KendiYeri, TotalNoktaList(tmpMuseumPolygonGelen(museumSay).Uc2NoktaNo).KendiYeri)
                        Catch ex As Exception
                            ShowMuseum = False
                            Exit Sub
                        End Try

                    Next

                End If
            End If
            If PolygonList.Count > -1 Then
                For polyno As Integer = 0 To PolygonList.Count - 1
                    gr.DrawEllipse(Pens.Black, PolygonList(polyno).PolyMerkez.X, PolygonList(polyno).PolyMerkez.Y, 5, 5)
                Next
            End If
            If PoinLineIntList.Count > 0 Then
                For NoktaSay = 0 To PoinLineIntList.Count - 1
                    firca.Color = PoinLineIntList(NoktaSay).Color
                    gr.FillEllipse(firca, PoinLineIntList(NoktaSay).KendiYeri.X - 5, PoinLineIntList(NoktaSay).KendiYeri.Y - 5, 10, 10)
                Next
            End If

            'If NormalList.Count > 0 Then
            '    For Each NormalSay As Kenar In NormalList
            '        gr.DrawEllipse(Pens.DeepPink, CInt(NormalSay.finish.X / ZoomFactor), CInt(NormalSay.finish.Y / ZoomFactor), 5, 5)
            '        ZoomedLine(gr, Pens.DeepPink, NormalSay.start, NormalSay.finish)
            '    Next
            'End If
            If NormalList.Count > 3 Then
                NormalList.RemoveAt(0)
            End If

            If DrectionList.Count > 0 Then
                For Each LineSay As Kenar In DrectionList
                    gr.DrawEllipse(LineSay.Kalem, CInt(LineSay.finish.X / ZoomFactor), CInt(LineSay.finish.Y / ZoomFactor), 5, 5)
                    ZoomedLine(gr, LineSay.Kalem, LineSay.start, LineSay.finish)
                Next
            End If
            If DrectionList.Count > 6 Then
                DrectionList.RemoveAt(0)
            End If
        End Sub
        Sub ZoomedPolygon(ByVal graph As System.Drawing.Graphics, ByVal brush As System.Drawing.Brush, ByVal points() As System.Drawing.PointF)
            Dim copyarray(2) As PointF
            For pn As Integer = 0 To 2
                copyarray(pn).X = points(pn).X / ZoomFactor
                copyarray(pn).Y = points(pn).Y / ZoomFactor
            Next
            graph.FillPolygon(brush, copyarray)
            If SelectedPolygonNo > -1 Then
                graph.DrawEllipse(Pens.Black, PolygonList(SelectedPolygonNo).PolyMerkez.X, PolygonList(SelectedPolygonNo).PolyMerkez.Y, 5, 5)
            End If


        End Sub
        Public Sub ZoomedLine(ByVal graph As System.Drawing.Graphics, ByVal pen As System.Drawing.Pen, ByVal Location1 As PointF, ByVal Location2 As PointF)
            Location1.X = Location1.X / ZoomFactor
            Location1.Y = Location1.Y / ZoomFactor
            Location2.X = Location2.X / ZoomFactor
            Location2.Y = Location2.Y / ZoomFactor
            If pen.Color = Color.Brown Then
                pen = New Pen(Color.Brown, 3)
            End If
            graph.DrawLine(pen, Location1, Location2)
        End Sub

        Private Sub pboxCanvas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pboxCanvas.MouseDown
            Dim mdAnswer As New PointToAnswer
            If PolySelectMode = False Then
                If TotalNoktaList.Count = 5 And ilkNoktaDegisti = False Then
                    TotalNoktaList.Item(4).KendiYeri.X = e.Location.X * ZoomFactor
                    TotalNoktaList.Item(4).KendiYeri.Y = e.Location.Y * ZoomFactor
                    pboxCanvas.Refresh()
                    ilkNoktaDegisti = True
                Else
                    RemoveHandler pboxCanvas.MouseMove, AddressOf pboxCanvas_MouseMove
                    If KornerToKorner = False Then
                        ZoomedLoc.X = e.Location.X * ZoomFactor
                        ZoomedLoc.Y = e.Location.Y * ZoomFactor
                        PolyMoveEnabled = False

                        world.Ucgenle(ZoomedLoc, True, TargetNokta, PolygonList.Count - 1)

                        RemoveHandler sbarSelectNokta.Scroll, AddressOf sbarSelectNokta_Scroll
                        sbarSelectNokta.Maximum = TotalNoktaList.Count + 8
                        sbarSelectNokta.Minimum = 0
                        sbarSelectNokta.Value = sbarSelectNokta.Minimum
                        AddHandler sbarSelectNokta.Scroll, AddressOf sbarSelectNokta_Scroll

                        pboxCanvas.Invalidate()
                    ElseIf Cemberlist.Count > 0 Then
                        PolyMoveEnabled = False
                        If world.KosedenKoseyeBagla(TotalNoktaList(Cemberlist(Cemberlist.Count - 1)), AramailkNoktasi, AramailkNoktasi.AralikList(MouseSeciliAralik), False, mdAnswer, -1).Connected = True Then
                            AramailkNoktasi = TotalNoktaList(Cemberlist(Cemberlist.Count - 1))
                        End If
                        Cemberlist.Clear()
                    End If

                    AddHandler pboxCanvas.MouseMove, AddressOf pboxCanvas_MouseMove
                End If


            ElseIf PolySelectMode = True And PolyMoveEnabled = False And SelectedPolygonNo > -1 Then

                PolyMoveEnabled = True

            End If
        End Sub

        Private Sub pboxCanvas_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pboxCanvas.MouseMove
            Dim AralikSay As Integer
            EtkinGeo.PolyNo = -2
            EtkinGeo.UcgenNo = -1
            Cemberlist.Clear()
            If TotalUcgenList.Count > 3 Then

                TargetNokta.KendiYeri.X = e.Location.X * ZoomFactor
                TargetNokta.KendiYeri.Y = e.Location.Y * ZoomFactor
                'If SelectedPolygonNo = -1 Then
                For AralikSay = 0 To AramailkNoktasi.AralikList.Count - 1
                    EtkinGeo = PointToPointQuery2(AramailkNoktasi, TargetNokta.KendiYeri, True, AramailkNoktasi.AralikList.Item(AralikSay), 0, TotalNoktaList, TotalUcgenList)
                    If EtkinGeo.Durum > 0 Then
                        AramailkNoktasi.AralikList(AralikSay).Boya = True
                        MouseSeciliAralik = AralikSay
                        If PolyMoveEnabled = False And PolySelectMode = True Then
                            SelectedPolygonNo = TotalUcgenList(EtkinGeo.UcgenNo).UcgenPolyNo

                        End If
                        Exit For
                    Else
                        AramailkNoktasi.AralikList(AralikSay).Boya = False
                    End If
                Next
                If chboxShowInfo.Checked = True Then
                    If EtkinGeo.Durum > 0 And EtkinGeo.UcgenNo > -1 Then
                        Label1.Text = ("durum" + EtkinGeo.Durum.ToString + " ActifÜçgen:" + EtkinGeo.UcgenNo.ToString + " AktifKenar:" + AramailkNoktasi.AralikList.Item(AralikSay).UcgeniciKarsiKenarNo.ToString + " UcgenAdedi:" + TotalUcgenList.Count.ToString + Label1Text)
                        Label1.Text = Label1.Text + " Poligon: " + TotalUcgenList(EtkinGeo.UcgenNo).UcgenPolyNo.ToString
                        Label1.Text = Label1.Text + " SonKesilenPoligon: " + EtkinGeo.SonKesilenDoluPoly.ToString
                        Label1.Text = Label1.Text + " ÖnKesilenPoligon: " + EtkinGeo.OnKesilenDoluPoly.ToString

                        Label1.Text = Label1.Text + " BakanNokta: " + AramailkNoktasi.NoktaNo.ToString
                        Label1.Text = Label1.Text + " KarşıKenarPolyDış: " + TotalUcgenList(EtkinGeo.UcgenNo).KenarList.Item(AramailkNoktasi.AralikList.Item(AralikSay).UcgeniciKarsiKenarNo).PolyKenar.ToString + " - " +
                            TotalUcgenList(EtkinGeo.UcgenNo).KenarList.Item(AramailkNoktasi.AralikList.Item(AralikSay).UcgeniciKarsiKenarNo).DisKenar.ToString
                        If Cemberlist.Count > 0 Then
                            Label1.Text = Label1.Text + " HedefNokta: " + Cemberlist(Cemberlist.Count - 1).ToString
                        End If
                        Label1.Text = Label1.Text + "  " + e.Location.ToString
                        Label1.Text = Label1.Text + " Zoom:  " + ZoomFactor.ToString
                        If PolygonList.Count > 0 Then
                            If EtkinGeo.PolyNo > -1 Then
                                Label1.Text = Label1.Text + " PoligonÜçgenSayısı:  " + PolygonList(EtkinGeo.PolyNo).UcgenList.Count.ToString
                            End If

                        End If
                        Label1.Text = Label1.Text + " ihlal: " + EtkinGeo.ihlal.ToString
                    End If
                End If



                If e.X > world.PicXMin + 20 And e.X < world.PicXMax - 20 And e.Y > world.PicYMin + 20 And e.Y < world.PicYMax - 20 Then

                    If PolyMoveEnabled = True And SelectedPolygonNo > -1 Then
                        ZoomedLoc.X = TargetNokta.KendiYeri.X
                        ZoomedLoc.Y = TargetNokta.KendiYeri.Y

                        Dim pathpoint As New AnimPathPoint
                        pathpoint.PolyNo = SelectedPolygonNo
                        pathpoint.StartLoc = PolygonList(SelectedPolygonNo).PolyMerkez
                        pathpoint.TargetLoc = ZoomedLoc
                        AnimPath.Add(pathpoint)

                        If chkMove.Checked = True Then
                            LogToFile("<WP SX=" & quote & pathpoint.StartLoc.X.ToString & quote & _
                                  " SY=" & quote & pathpoint.StartLoc.Y.ToString & quote & _
                                  " X=" & quote & pathpoint.TargetLoc.X.ToString & quote & _
                                  " Y=" & quote & pathpoint.TargetLoc.Y.ToString & quote & _
                                  " PolyNo=" & quote & SelectedPolygonNo.ToString & quote & "/>", "MoveLog.txt")
                        End If

                        RemoveHandler pboxCanvas.MouseMove, AddressOf pboxCanvas_MouseMove
                        PolygonList(SelectedPolygonNo).doMove = True
                        PolygonList(SelectedPolygonNo).BasicPolyMove(ZoomedLoc, False)
                        AddHandler pboxCanvas.MouseMove, AddressOf pboxCanvas_MouseMove

                    End If
                End If

            End If
            pboxCanvas.Invalidate()
        End Sub

        Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Me.world = New World
            mathHelper.world = world
            TargetNokta = New Nokta(Me.world)
            AnimPath = New List(Of AnimPathPoint)

            Try
                If File.Exists("MoveLog.txt") Then
                    File.Delete("MoveLog.txt")
                End If
                If File.Exists("impLog.txt") Then
                    File.Delete("impLog.txt")
                End If
            Catch generatedExceptionName As Exception
            Finally

            End Try
        End Sub

        Private Sub sbarSelectNokta_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles sbarSelectNokta.Scroll
            If sbarSelectNokta.Value < TotalNoktaList.Count Then
                AramailkNoktasi = TotalNoktaList(sbarSelectNokta.Value)
            End If
            pboxCanvas.Invalidate()
        End Sub

        Private Sub ChkPolySel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkPolySel.CheckedChanged
            If ChkPolySel.Checked = False Then
                PolyMoveEnabled = False
                SelectedPolygonNo = -1
            End If
            world.FatalError = False
        End Sub

        Private Sub ChkPolySel_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles ChkPolySel.CheckStateChanged
            PolySelectMode = ChkPolySel.CheckState
        End Sub

        Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
            Dim tmpSeciliNokta As Integer
            If TotalNoktaList.Count > 0 Then
                Try
                    tmpSeciliNokta = TotalUcgenList(Me.world.SonBasilanNokta.AralikList(0).UcgenNo).KenarList(Me.world.SonBasilanNokta.AralikList(0).UcgeniciKarsiKenarNo).KarsiNoktaNo
                Catch ex As Exception
                    tmpSeciliNokta = 0
                End Try

            End If


            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                ActiveXmlFileName = OpenFileDialog1.FileName
                ActiveXmlDocument.Load(ActiveXmlFileName)
                OsmXmlTreeCnt1.Load(ActiveXmlDocument)
                AddHandler ActiveXmlDocument.NodeChanged, AddressOf MyNodeChangedEvent
                AddHandler ActiveXmlDocument.NodeInserted, AddressOf MyNodeInsertedEvent
                AddHandler ActiveXmlDocument.NodeRemoved, AddressOf MyNodeDeletedEvent

                Dim tmpAnimPath As New List(Of AnimPathPoint)
                tmpAnimPath = AnimPath
                Me.world = New World
                AnimPath = tmpAnimPath
                mathHelper.world = world
                TargetNokta = New Nokta(Me.world)

                Dim ponceki As XmlNode
                For pNo As Integer = 0 To OsmXmlTreeCnt1.xml_document.LastChild.ChildNodes.Count - 1
                    Dim p As XmlNode = OsmXmlTreeCnt1.xml_document.LastChild.ChildNodes(pNo)
                    If p.NodeType = XmlNodeType.Element Then
                        Dim YeniNokta As New PointF
                        YeniNokta.X = CSng(p.Attributes(0).Value)
                        YeniNokta.Y = CSng(p.Attributes(1).Value)

                        If pNo = 0 Then
                            TotalNoktaList.Item(4).KendiYeri = YeniNokta
                        Else

                            If pNo > 3 Then
                                ponceki = OsmXmlTreeCnt1.xml_document.LastChild.ChildNodes(pNo - 1)
                                If ponceki.NodeType = XmlNodeType.Element And ponceki.Attributes.Count > 2 Then
                                    'Basılacak yeni noktanın poligon numarası bir öncekinden farklıysa önceki poligonun kapatılması için son noktası tekrar basılıyor.
                                    If p.Attributes(2).Value <> ponceki.Attributes(2).Value Then
                                        TargetNokta.KendiYeri = TotalNoktaList(PolygonList(CInt(ponceki.Attributes(2).Value)).PolyNoktaList(0)).KendiYeri
                                        Me.world.Ucgenle(TotalNoktaList(PolygonList(CInt(ponceki.Attributes(2).Value)).PolyNoktaList(0)).KendiYeri, False, TargetNokta, PolygonList.Count - 1)
                                    End If
                                End If
                            End If
                            TargetNokta.KendiYeri = YeniNokta
                            Me.world.Ucgenle(YeniNokta, False, TargetNokta, PolygonList.Count - 1)
                        End If

                    End If

                    If (pNo > 3 And pNo = OsmXmlTreeCnt1.xml_document.LastChild.ChildNodes.Count - 1) Then
                        If p.Attributes.Count > 2 Then
                            Try
                                'Son poligon kapatılıyor
                                TargetNokta.KendiYeri = TotalNoktaList(PolygonList(CInt(p.Attributes(2).Value)).PolyNoktaList(0)).KendiYeri
                                Me.world.Ucgenle(TargetNokta.KendiYeri, False, TargetNokta, PolygonList.Count - 1)
                            Catch ex As Exception

                            End Try

                        End If

                    End If
                Next

                'oob
                If AnimPath.Count > 0 Then

                    sbarAnim.Minimum = 0
                    sbarAnim.Maximum = (AnimPath.Count - 1)
                    sbarAnim.Value = 0
                    sbarAnim.Enabled = True

                Else
                    sbarAnim.Enabled = False
                End If
                AnimPathLoc = 0
                'oob

                If tmpSeciliNokta < TotalNoktaList.Count Then
                    Me.world.SonBasilanNokta = TotalNoktaList(tmpSeciliNokta)
                    sbarSelectNokta.Value = tmpSeciliNokta
                End If

                'oob
                'RemoveHandler HScrollBar5.ValueChanged, AddressOf HScrollBar5_ValueChanged
                'HScrollBar5.Value = 4
                'HScrollBar5.Minimum = 4
                'HScrollBar5.Maximum = TotalNoktaList.Count
                'AddHandler HScrollBar5.ValueChanged, AddressOf HScrollBar5_ValueChanged
                'oob

            End If
            pboxCanvas.Invalidate()
        End Sub
        Private Sub MyNodeChangedEvent(ByVal source As Object, ByVal args As XmlNodeChangedEventArgs)
            DocChanged = True
            removehandlers()
        End Sub
        Public Sub MyNodeInsertedEvent(ByVal source As Object, ByVal args As XmlNodeChangedEventArgs)
            DocChanged = True
            removehandlers()
        End Sub
        Private Sub MyNodeDeletedEvent(ByVal source As Object, ByVal args As XmlNodeChangedEventArgs)
            DocChanged = True
            removehandlers()
        End Sub

        Sub removehandlers()
            RemoveHandler ActiveXmlDocument.NodeChanged, AddressOf MyNodeChangedEvent
            RemoveHandler ActiveXmlDocument.NodeInserted, AddressOf MyNodeInsertedEvent
            RemoveHandler ActiveXmlDocument.NodeRemoved, AddressOf MyNodeDeletedEvent
        End Sub

        Private Sub pboxCanvas_DoubleClick(sender As System.Object, e As System.EventArgs) Handles pboxCanvas.DoubleClick
            PolyMoveEnabled = False
            SelectedPolygonNo = -1
        End Sub

        Private Sub sbarAnim_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles sbarAnim.Scroll

            Dim startscrl, finishscrl As Integer
            ToolTip1.SetToolTip(sbarAnim, sbarAnim.Value.ToString)
            AnimMode = True
            If e.NewValue > AnimPathLoc Then
                startscrl = e.OldValue
                finishscrl = e.NewValue
                AdimYon = 1
            ElseIf e.NewValue < AnimPathLoc Then
                startscrl = e.OldValue
                finishscrl = e.NewValue
                AdimYon = -1
            Else
                Exit Sub
            End If
            ToolTip1.SetToolTip(sbarAnim, sbarAnim.Value.ToString)
            For surdur = AnimPathLoc To sbarAnim.Value Step AdimYon
                If (surdur + AdimYon) < AnimPath.Count - 1 And (surdur + AdimYon) > -1 Then
                    RemoveHandler sbarAnim.Scroll, AddressOf sbarAnim_Scroll
                    PolygonList(AnimPath(surdur).PolyNo).doMove = True
                    PolygonList(AnimPath(surdur).PolyNo).BasicPolyMove(AnimPath(surdur).TargetLoc, False)
                    pboxCanvas.Invalidate()

                    AddHandler sbarAnim.Scroll, AddressOf sbarAnim_Scroll
                End If

            Next
            If surdur = -1 Then surdur = 0
            AnimPathLoc = surdur

            AnimMode = False

        End Sub

        Private Sub BtnSaveAnim_Click(sender As System.Object, e As System.EventArgs) Handles BtnSaveAnim.Click
            Try
                With SaveFileDialog1
                    .FileName = ""
                    .Filter = "xml files (*.xml)|*.xml|" & "All files|*.*"
                    If .ShowDialog() = DialogResult.OK Then
                        Dim ActiveXmlDocument As New XmlDocument
                        Dim instructor As XmlProcessingInstruction = ActiveXmlDocument.CreateProcessingInstruction("xml", "version='1.0' encoding='UTF-8'")
                        ActiveXmlDocument.AppendChild(CType(instructor, XmlNode))
                        Dim rootNode As XmlNode = ActiveXmlDocument.CreateNode(XmlNodeType.Element, "Anim", "")
                        ActiveXmlDocument.AppendChild(rootNode)
                        Me.ActiveXmlDocument = ActiveXmlDocument
                        OsmXmlTreeCnt1.xml_document = ActiveXmlDocument
                        ActiveXmlFileName = .FileName
                        For node As Integer = 0 To AnimPath.Count - 1
                            'If TotalNoktaList(node).Turemis = False Then
                            Dim YeniXmlNode As XmlNode
                            YeniXmlNode = OsmXmlTreeCnt1.xml_document.CreateElement("WP")
                            'YeniXmlNode.Value = "P"

                            Dim SX As XmlAttribute = OsmXmlTreeCnt1.xml_document.CreateAttribute("SX")
                            SX.Value = CStr(AnimPath(node).StartLoc.X)
                            YeniXmlNode.Attributes.Append(SX)

                            Dim SY As XmlAttribute = OsmXmlTreeCnt1.xml_document.CreateAttribute("SY")
                            SY.Value = CStr(AnimPath(node).StartLoc.Y)
                            YeniXmlNode.Attributes.Append(SY)

                            Dim X As XmlAttribute = OsmXmlTreeCnt1.xml_document.CreateAttribute("X")
                            X.Value = CStr(AnimPath(node).TargetLoc.X)
                            YeniXmlNode.Attributes.Append(X)

                            Dim Y As XmlAttribute = OsmXmlTreeCnt1.xml_document.CreateAttribute("Y")
                            Y.Value = CStr(AnimPath(node).TargetLoc.Y)
                            YeniXmlNode.Attributes.Append(Y)

                            Dim PolyNo As XmlAttribute = OsmXmlTreeCnt1.xml_document.CreateAttribute("PolyNo")
                            PolyNo.Value = CStr(AnimPath(node).PolyNo)
                            YeniXmlNode.Attributes.Append(PolyNo)
                            OsmXmlTreeCnt1.xml_document.LastChild.AppendChild(YeniXmlNode)
                            'End If
                        Next
                        ActiveXmlDocument.Save(ActiveXmlFileName)
                    End If
                End With
            Catch es As Exception
                MessageBox.Show(es.Message)
                Exit Sub
            End Try
        End Sub

        Private Sub BtnLoadAnim_Click(sender As System.Object, e As System.EventArgs) Handles BtnLoadAnim.Click
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                ActiveXmlFileName = OpenFileDialog1.FileName
                ActiveXmlDocument.Load(ActiveXmlFileName)
                OsmXmlTreeCnt1.Load(ActiveXmlDocument)
                AnimPath.Clear()

                For AnimNo As Integer = 0 To OsmXmlTreeCnt1.xml_document.LastChild.ChildNodes.Count - 1
                    Dim p As XmlNode = OsmXmlTreeCnt1.xml_document.LastChild.ChildNodes(AnimNo)
                    If p.NodeType = XmlNodeType.Element Then
                        Dim YeniAnim As New AnimPathPoint
                        YeniAnim.StartLoc.X = CSng(p.Attributes(0).Value)
                        YeniAnim.StartLoc.Y = CSng(p.Attributes(1).Value)
                        YeniAnim.TargetLoc.X = CSng(p.Attributes(2).Value)
                        YeniAnim.TargetLoc.Y = CSng(p.Attributes(3).Value)
                        YeniAnim.PolyNo = CSng(p.Attributes(4).Value)
                        AnimPath.Add(YeniAnim)

                    End If
                Next
                RemoveHandler sbarAnim.Scroll, AddressOf sbarAnim_Scroll
                If AnimPath.Count > 0 Then
                    sbarAnim.Minimum = 0
                    sbarAnim.Maximum = (AnimPath.Count - 1)
                    sbarAnim.Value = 0
                    sbarAnim.Enabled = True

                Else
                    sbarAnim.Enabled = False
                End If
                AnimPathLoc = 0
                AddHandler sbarAnim.Scroll, AddressOf sbarAnim_Scroll


            End If
        End Sub

        Private Sub BtnClearAnim_Click(sender As System.Object, e As System.EventArgs) Handles BtnClearAnim.Click
            AnimPath.Clear()
            AnimPathLoc = 0
            sbarAnim.Enabled = False
        End Sub

        Private Sub BtnJump_Click(sender As System.Object, e As System.EventArgs) Handles BtnJump.Click
            Dim FinishFrame As Integer = CInt(TxtJump.Text)
            If FinishFrame > AnimPathLoc Then AdimYon = 1 Else AdimYon = -1
            Dim surdur As Integer
            If FinishFrame < AnimPath.Count - 1 Then
                AnimMode = True
                RemoveHandler sbarAnim.Scroll, AddressOf sbarAnim_Scroll
                For surdur = AnimPathLoc To FinishFrame Step AdimYon
                    If (surdur + AdimYon) < AnimPath.Count - 1 And (surdur + AdimYon) > -1 Then
                        PolygonList(AnimPath(surdur).PolyNo).BasicPolyMove(AnimPath(surdur + AdimYon).TargetLoc, False)
                        pboxCanvas.Invalidate()
                    End If

                Next
                If surdur = -1 Then surdur = 0
                AnimPathLoc = surdur

                sbarAnim.Value = FinishFrame
                AddHandler sbarAnim.Scroll, AddressOf sbarAnim_Scroll
            Else
                MsgBox("Yanlış Frame")
            End If
            AnimMode = False
        End Sub

        Private Sub BtnJump_MouseHover(sender As System.Object, e As System.EventArgs) Handles BtnJump.MouseHover
            ToolTip1.SetToolTip(BtnJump, (AnimPath.Count - 2).ToString)
        End Sub
        Shared strLogText As String = "Default string to log"
        Public Shared Sub LogToFile(message As String, fileName As String)
            Try
                If Not File.Exists(fileName) Then
                    LogWriter = New StreamWriter(fileName)
                Else
                    LogWriter = File.AppendText(fileName)
                End If
                LogWriter.WriteLine(If(String.IsNullOrEmpty(message), strLogText, message))
                LogWriter.Flush()
            Catch generatedExceptionName As Exception
            Finally
                If LogWriter IsNot Nothing Then
                    LogWriter.Close()
                End If
            End Try
        End Sub

        Private Sub sbarAnim_MouseHover(sender As System.Object, e As System.EventArgs) Handles sbarAnim.MouseHover
            ToolTip1.SetToolTip(sbarAnim, sbarAnim.Value.ToString)
        End Sub

        Private Sub chkImpLog_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles chkImpLog.CheckStateChanged
            world.logImpacts = chkImpLog.CheckState
        End Sub

        Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
            SavePointsAsXmlDocument(TotalNoktaList)
        End Sub
        Public Sub SavePointsAsXmlDocument(ByVal NoktaList As List(Of Nokta))
            Try
                With SaveFileDialog1
                    .FileName = ""
                    .Filter = "xml files (*.xml)|*.xml|" & "All files|*.*"
                    If .ShowDialog() = DialogResult.OK Then
                        Dim ActiveXmlDocument As New XmlDocument
                        Dim instructor As XmlProcessingInstruction = ActiveXmlDocument.CreateProcessingInstruction("xml", "version='1.0' encoding='UTF-8'")
                        ActiveXmlDocument.AppendChild(CType(instructor, XmlNode))
                        Dim rootNode As XmlNode = ActiveXmlDocument.CreateNode(XmlNodeType.Element, "Points", "")
                        ActiveXmlDocument.AppendChild(rootNode)
                        Me.ActiveXmlDocument = ActiveXmlDocument
                        OsmXmlTreeCnt1.xml_document = ActiveXmlDocument
                        ActiveXmlFileName = .FileName
                        For node As Integer = 4 To NoktaList.Count - 1
                            If NoktaList(node).Turemis = False Then
                                Dim YeniXmlNode As XmlNode
                                YeniXmlNode = OsmXmlTreeCnt1.xml_document.CreateElement("P")

                                Dim X As XmlAttribute = OsmXmlTreeCnt1.xml_document.CreateAttribute("X")
                                X.Value = CStr(NoktaList(node).KendiYeri.X)
                                YeniXmlNode.Attributes.Append(X)

                                Dim Y As XmlAttribute = OsmXmlTreeCnt1.xml_document.CreateAttribute("Y")
                                Y.Value = CStr(NoktaList(node).KendiYeri.Y)
                                YeniXmlNode.Attributes.Append(Y)

                                Dim PolyNo As XmlAttribute = OsmXmlTreeCnt1.xml_document.CreateAttribute("PolyNo")
                                PolyNo.Value = CStr(NoktaList(node).NoktaPolyNo)
                                YeniXmlNode.Attributes.Append(PolyNo)
                                OsmXmlTreeCnt1.xml_document.LastChild.AppendChild(YeniXmlNode)

                                Dim NoktaNo As XmlAttribute = OsmXmlTreeCnt1.xml_document.CreateAttribute("NoktaNo")
                                NoktaNo.Value = CStr(NoktaList(node).NoktaNo)
                                YeniXmlNode.Attributes.Append(NoktaNo)
                                OsmXmlTreeCnt1.xml_document.LastChild.AppendChild(YeniXmlNode)
                            End If
                        Next
                        ActiveXmlDocument.Save(ActiveXmlFileName)
                    End If
                End With
            Catch es As Exception
                MessageBox.Show(es.Message)
                Exit Sub
            End Try
        End Sub
    End Class

End Namespace