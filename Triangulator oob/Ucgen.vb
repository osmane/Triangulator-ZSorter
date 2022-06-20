Namespace Triangulator
    Public Class Ucgen

        Public TotalNoktaList As List(Of Nokta)
        Public KenarList As List(Of Kenar)

        Public Boya As Boolean
        Public GirilenKenarNo As Byte
        Public CikilanKenarNo As Byte
        Public GirisPoint As New PointF
        Public CikisPoint As New PointF
        Public Dolu As Boolean = False
        Public islemGordu As Boolean
        Public DoldurmaKenari As Byte
        Public Disabled As Boolean
        Public UcgenPolyNo As Integer
        Public PolyListSira As Integer
        Public PolyEklendi As Boolean
        Public SonKontrolTick As Long
        Public TriCenter As PointF
        Public Area As Double
        Public KendiNo As Integer
        Public Sub New(ByRef word As World)
            Me.TotalNoktaList = word.TotalNoktaList
            Me.KenarList = New List(Of Kenar)
            Me.Boya = False
            Me.UcgenPolyNo = -1
            Me.PolyListSira = -1
            Me.islemGordu = False
            Me.Disabled = False
            Me.PolyEklendi = False
        End Sub
        Public Function FindTriCenter() As PointF
            Dim K0Uc1 As PointF = TotalNoktaList(Me.KenarList(0).Uc1NoktaNo).KendiYeri
            Dim K1Uc2 As PointF = TotalNoktaList(Me.KenarList(1).Uc2NoktaNo).KendiYeri
            Dim K0Uc2 As PointF = TotalNoktaList(Me.KenarList(0).Uc2NoktaNo).KendiYeri
            Me.TriCenter.X = (K0Uc1.X + (K1Uc2.X - K0Uc1.X) / 2) - ((K0Uc1.X + (K1Uc2.X - K0Uc1.X) / 2) - K0Uc2.X) / 3
            Me.TriCenter.Y = (K0Uc1.Y + (K1Uc2.Y - K0Uc1.Y) / 2) - ((K0Uc1.Y + (K1Uc2.Y - K0Uc1.Y) / 2) - K0Uc2.Y) / 3
            Return Me.TriCenter
        End Function
        Public Function CalcTriArea() As Double
            Dim K0Uc1 As PointF = TotalNoktaList(Me.KenarList(0).Uc1NoktaNo).KendiYeri
            Dim K0Uc2 As PointF = TotalNoktaList(Me.KenarList(0).Uc2NoktaNo).KendiYeri
            Dim K0D As Double = mathHelper.MesafeHesapla(K0Uc1, K0Uc2)

            Dim K1Uc1 As PointF = TotalNoktaList(Me.KenarList(1).Uc1NoktaNo).KendiYeri
            Dim K1Uc2 As PointF = TotalNoktaList(Me.KenarList(1).Uc2NoktaNo).KendiYeri
            Dim K1D As Double = mathHelper.MesafeHesapla(K1Uc1, K1Uc2)

            Dim K2Uc1 As PointF = TotalNoktaList(Me.KenarList(2).Uc1NoktaNo).KendiYeri
            Dim K2Uc2 As PointF = TotalNoktaList(Me.KenarList(2).Uc2NoktaNo).KendiYeri
            Dim K2D As Double = mathHelper.MesafeHesapla(K2Uc1, K2Uc2)

            Dim U As Double = (K0D + K1D + K2D) / 2
            Me.Area = Math.Sqrt(U * (U - K0D) * (U - K1D) * (U - K2D))
            Return Me.Area

        End Function
    End Class
End Namespace