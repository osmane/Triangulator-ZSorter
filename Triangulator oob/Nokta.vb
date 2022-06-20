Imports System.Threading
Imports System.Threading.Tasks

Namespace Triangulator
    Public Class Nokta
        Public world As World
        Public TotalNoktaList As List(Of Nokta)
        Public PolygonList As List(Of Polygon)
        Public AralikList As List(Of Aralik)
        Public KendiYeri As PointF
        Public Turemis As Boolean
        Public DisableList As List(Of Integer)
        Public NoktaPolyNo As Integer
        Public NoktaNo, Bag1, Bag2 As Integer
        Public Uzaklik As Double
        Public MinRotation As PointF
        Public Aci As Double
        Public Moving As PointF
        Public OldMoving As PointF
        Public MoveKucult As Boolean = False
        Public AralikSayIlk As Integer
        Public MovedaBasildi As Boolean = False
        Public NoktaSilindi As Boolean = False
        Public SilmeYontemi As Byte
        Public Daraldi As Boolean = False
        Public darKarsi As Kenar
        Public Siliniyor As Byte = False
        Public Color As Color = Drawing.Color.Black
        Dim araliksayFactory As TaskFactory = New TaskFactory()

        Public Sub New(ByVal world As World)
            Me.world = world
            Me.TotalNoktaList = world.TotalNoktaList
            Me.PolygonList = world.PolygonList
            Me.AralikList = New List(Of Aralik)
            Me.Turemis = False
            Me.DisableList = New List(Of Integer)
            Me.NoktaPolyNo = -1
            Me.AralikSayIlk = 0
            Me.SilmeYontemi = 0
            Me.Color = Drawing.Color.Black
            Me.NoktaNo = Me.TotalNoktaList.Count
            Me.darKarsi = New Kenar
        End Sub


        'Dim araliksayTasks As New List(Of Task)
        Public Sub AraliklariTara(taraNokta As Nokta, ByVal MovedPolygonNo As Integer, ByVal SonrakiNoktaKonumu As PointF)

            Dim Start As Integer
            Dim Finish As Integer
            Dim araliksayTokenSource As New CancellationTokenSource()
            Dim adim As Integer = 20
            'Dim ui = TaskScheduler.FromCurrentSynchronizationContext()
            For yarimsay As Integer = 0 To (taraNokta.AralikList.Count - 1) Step adim
                'araliksayTasks.Clear()

                Start = yarimsay
                Finish = yarimsay + adim
                If Finish > (taraNokta.AralikList.Count) Then Finish = (taraNokta.AralikList.Count)
                Dim arrtasks((Finish - 1) - Start) As Task
                For Araliksay As Integer = Start To Finish - 1

                    Dim CollTestAralik As Aralik = taraNokta.AralikList(Araliksay)
                    'Dim tara As Task = araliksayFactory.StartNew(Sub(x)
                    '                                                 If taraNokta.Daraldi = False Then
                    '                                                     BirAralikTara(taraNokta, MovedPolygonNo, SonrakiNoktaKonumu, CollTestAralik, araliksayTokenSource)
                    '                                                 Else
                    '                                                     Exit Sub
                    '                                                 End If

                    '                                             End Sub, araliksayTokenSource.Token)

                    'tara.Wait()

                    'If taraNokta.Daraldi = False Then
                    'araliksayTasks.Add(tara)
                    'End If



                    BirAralikTara(taraNokta, MovedPolygonNo, SonrakiNoktaKonumu, CollTestAralik, araliksayTokenSource)
                    If taraNokta.Daraldi Then Exit Sub
                    'If araliksayTokenSource.Token.IsCancellationRequested = True Then Exit Sub
                    'arrtasks(Araliksay - yarimsay) = tara
                Next
                'If araliksayTokenSource.Token.IsCancellationRequested = False Then
                '    Tasks.Task.WaitAll(arrtasks)
                'Else
                '    Exit Sub
                'End If
                If (taraNokta.AralikList.Count - 1) < adim Then Exit For
            Next

            'If taraNokta.Daraldi = False Then
            'Tasks.Task.WaitAll(araliksayTasks.ToArray)
            'End If

            'araliksayFactory.ContinueWhenAll(araliksayTasks.ToArray(), Sub(result)
            '                                                               Task.WaitAll(araliksayTasks.ToArray)
            '                                                           End Sub, araliksayTokenSource.Token, TaskContinuationOptions.None, ui)
            'For Each gorev As Task In araliksayTasks
            '    If gorev IsNot Nothing Then
            '        If gorev.IsCanceled = False Then
            '            Tasks.Task.WaitAny(gorev)
            '        End If
            '    End If
            'Next
            'If araliksayTasks.Count > -1 Then

            'Return daraldi
        End Sub
        Public Sub BirAralikTara(taraNokta As Nokta, ByVal MovedPolygonNo As Integer, ByVal SonrakiNoktaKonumu As PointF, ByVal CollTestAralik As Aralik, ByRef araliksayTokenSource As CancellationTokenSource)

            'If araliksayTokenSource.Token.IsCancellationRequested = False Then

            Dim SimdikiAralikAcisi As Double
            If taraNokta.Daraldi = False Then

                If (CollTestAralik.Disabled = False) Then

                    SimdikiAralikAcisi = GetAngle(TotalNoktaList(CollTestAralik.GidenUcNo).KendiYeri, SonrakiNoktaKonumu, TotalNoktaList(CollTestAralik.GelenUcNo).KendiYeri)

                    If (SimdikiAralikAcisi > 179.5 Or SimdikiAralikAcisi < 0.5) _
                        And taraNokta.NoktaPolyNo = MovedPolygonNo Then
                        taraNokta.Daraldi = True
                        darKarsi.Uc1NoktaNo = CollTestAralik.GidenUcNo
                        darKarsi.Uc2NoktaNo = CollTestAralik.GelenUcNo
                        'araliksayTokenSource.Cancel()
                    End If
                End If
            End If


            'End If

        End Sub
    End Class

End Namespace
