Namespace Triangulator
    Public Class Kenar
        Implements ICloneable
        Private _kenar As Kenar

        Sub New(kenar As Kenar)
            _kenar = kenar.Clone
        End Sub

        Sub New()
        End Sub

        Public Function Clone() As Object Implements ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
        Public Uc1NoktaNo As Integer
        Public Uc2NoktaNo As Integer
        Public KomsuNo As Integer
        Public KomsudaKacinciKenarNo As Byte
        Public KarsiNoktaNo As Integer
        Public KarsiNoktaAralikNo As Integer
        Public PolyKenar As Boolean = False
        Public KenarPolyNo As Integer = -1
        Public DisKenar As Boolean = False
        Public KarsiYakinlik As Double
        Public ImpactNoktaNo As Integer
        Public Angle As Double
        Public KendiUcgeni As Ucgen
        'yapilacak: start ve finish tipleri test amaçlı eklendi paint sırasında normalleri çizmek için kullanılıyor.
        Public start As PointF
        Public finish As PointF
        Public Kalem As Pen
        Public Yenile As Boolean = False


        Public Function isEqual(ByVal MatchedKenar As Kenar) As Boolean
            Dim Match As Boolean = False
            If MatchedKenar.Uc1NoktaNo = Me.Uc1NoktaNo And MatchedKenar.Uc2NoktaNo = Me.Uc2NoktaNo Then
                Match = True
            End If
            Return Match
        End Function
    End Class
End Namespace
