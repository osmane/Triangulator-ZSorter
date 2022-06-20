Namespace Triangulator
    Public Class Aralik
        Implements ICloneable
        Public Function Clone() As Object Implements ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
        Public GidenUcNo As Integer
        Public GelenUcNo As Integer
        Public UcgenNo As Integer
        Public UcgeniciGidenKenarNo As Byte
        Public UcgeniciGelenKenarNo As Byte
        Public UcgeniciKarsiKenarNo As Byte
        Public Boya As Boolean = False
        Public Disabled As Boolean = False
        Public izdusum As Double = -1
        Public GidenMesafe As Double
        Public SonrakiGidenMesafe As Double
        Public NoktaNo As Integer
        Public PolyMerkez As PointF
        'NoktaNo sadece MoveUcgenle'deki aralık.disable işleminde kullanılıyor
    End Class
End Namespace
