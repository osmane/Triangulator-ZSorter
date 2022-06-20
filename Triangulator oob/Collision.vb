Namespace Triangulator
    Public Class Collision
        Public depth As Single
        ' depth of collision (positive = penetration)
        Public normalX As Single
        ' normal (pointing outward from normalObj)
        Public normalY As Single
        Public impactX As Single
        ' point of impact
        Public impactY As Single
        ' NOTE (Dec 2006):  R and R2 seem to actually be vector from point of impact to CM,
        ' not from CM to point of impact!
        Public Rx As Single
        ' distance vector from CM (center of mass) of object to point of impact
        Public Ry As Single
        Public R2x As Single
        ' distance vector from CM of normalObj to point of impact
        Public R2y As Single
        Public rxnForceX As Single
        Public rxnForceY As Single
        Public obje As Integer
        ' "primary" object whose corner is colliding (index in bods[] vector)
        Public normalObj As Integer
        ' object corresponding to the normal (negative = wall)
        Public corner As Integer
        ' which corner, 1=a, 2=b, 3=c, 4=d  see Thruster5Object
        Public colliding As Boolean = True
        ' true if colliding, false if resting contact
        Public handled As Boolean = False
        ' true once its impact has been handled
        Public Sub New()
        End Sub

        Public Function isEqual(ByVal coll As Collision) As Boolean
            If coll IsNot Nothing Then
                If (((coll.Rx = Me.Rx) And (coll.Ry = Me.Ry)) Or ((coll.Rx = Me.Ry) And (coll.Ry = Me.Rx))) And (coll.impactX = Me.impactX) And (coll.impactY = Me.impactY) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Function
    End Class
End Namespace
