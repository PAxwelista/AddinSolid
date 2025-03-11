Public Class Classe

    Private _name As String
    Private _cylinderIn As Double
    Private _cylinderOut As Double
    Private _holesCenterDist As Double
    Private _angle As Double

    Public Sub New(name As String, Optional cylinderIn As Double = 0, Optional cylinderOut As Double = 0, Optional holesCenterDist As Double = 0, Optional angle As Double = 0)

        _name = name
        _cylinderIn = cylinderIn
        _cylinderOut = cylinderOut
        _holesCenterDist = holesCenterDist
        _angle = angle

    End Sub

    Public Function GetName() As String

        Return _name

    End Function
    Public Function GetCylinderIn() As Double

        Return _cylinderIn

    End Function
    Public Function GetCylinderOut() As Double

        Return _cylinderOut

    End Function
    Public Function GetHolesCenterDist() As Double

        Return _holesCenterDist

    End Function
    Public Function GetAngle() As Double

        Return _angle

    End Function

End Class
