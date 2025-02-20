

Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst


Public Class Volume


    Private _swVolumeModelDoc As ModelDoc2

    Public Sub New(swModelDoc As ModelDoc2)

        _swVolumeModelDoc = swModelDoc


    End Sub

    Public Function GetLitre() As Integer

        If _swVolumeModelDoc IsNot Nothing Then
            Return Math.Round(_swVolumeModelDoc.Extension.CreateMassProperty2.volume * 1000)
        Else
            Return -1
        End If


    End Function

    Public Function SetVolume(volume As Integer) As Boolean




    End Function

End Class

