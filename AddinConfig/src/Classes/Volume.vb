

Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst


Public Class Volume

    Private ReadOnly _swVolumeModelDoc As ModelDoc2

    Public Sub New(swModelDoc As ModelDoc2)

        _swVolumeModelDoc = swModelDoc


    End Sub

    Public Function GetLitre() As Integer

        If _swVolumeModelDoc IsNot Nothing Then

            If _swVolumeModelDoc.Extension.CreateMassProperty2 Is Nothing Then Return -1

            Return Math.Round(_swVolumeModelDoc.Extension.CreateMassProperty2.volume * 1000)
        Else
            Return -1
        End If


    End Function

    Public Function SetVolume(swDimension As Dimension, ByVal targetVolume As Double, swModelDoc As ModelDoc2) As Boolean
        'Permet de modifier une côtes en paramètre pour atteindre le volume ciblé

        Dim targetVolumeM3 As Double
        Dim LoadingForm As New LoadingForm
        Dim currentDim As Double


        targetVolumeM3 = targetVolume / 1000

        currentDim = swDimension.GetValue3(1, "")(0)
        LoadingForm.TopMost = False
        LoadingForm.TargetVolume.Text = targetVolume
        LoadingForm.Show()

        LoopSetVolume(swModelDoc, LoadingForm, targetVolumeM3, swDimension)


        swModelDoc.Extension.ForceRebuildAll()

        LoadingForm.Hide()

        Return True

    End Function

    Function LoopSetVolume(swModelDoc As ModelDoc2, LoadingForm As LoadingForm, targetVolumeM3 As Double, swDimension As Dimension) As Boolean


        Dim exitWhile As Boolean
        Dim currentVolumeM3 As Double
        Dim increment As Double = 300
        Dim currentDim As Double = swDimension.GetValue3(1, "")(0)
        Dim previousDown As Boolean = True

        exitWhile = False

        While Not (exitWhile)

            currentVolumeM3 = GetLitre() / 1000

            LoadingForm.ActualVolume.Text = currentVolumeM3 * 1000

            LoadingForm.Refresh()

            If currentVolumeM3 < 0 Then

                ErrorsHandling.AddError("Erreur de récupération du volume")
                Return False
                LoadingForm.Hide()
                Exit Function

            ElseIf increment < 1 Then

                ErrorsHandling.AddError("Lors du calcul du volume, l'incrémentation était inférieur à 1mm. Le volume est potentiellement erroné")
                Return False
                LoadingForm.Hide()
                Exit Function

            ElseIf (currentVolumeM3 - targetVolumeM3 < 0.05 And currentVolumeM3 - targetVolumeM3 >= 0) Then

                exitWhile = True

            ElseIf (currentDim <= 0 Or currentDim > 3000) Then

                ErrorsHandling.AddError("Valeur de la dimensions pour calcul du volume incohérente.")
                Return False
                LoadingForm.Hide()
                Exit Function

            ElseIf (currentVolumeM3 > targetVolumeM3 And previousDown) Then

                previousDown = True
                currentDim -= increment
                swDimension.SetValue3(currentDim, swSetValueInConfiguration_e.swSetValue_InAllConfigurations, Nothing)

            ElseIf (currentVolumeM3 < targetVolumeM3 And Not previousDown) Then

                previousDown = False
                currentDim += increment
                swDimension.SetValue3(currentDim, swSetValueInConfiguration_e.swSetValue_InAllConfigurations, Nothing)

            ElseIf (currentVolumeM3 > targetVolumeM3) Then

                previousDown = True
                increment /= 2
                currentDim -= increment
                swDimension.SetValue3(currentDim, swSetValueInConfiguration_e.swSetValue_InAllConfigurations, Nothing)

            ElseIf (currentVolumeM3 < targetVolumeM3) Then
                previousDown = False
                increment /= 2
                currentDim += increment
                swDimension.SetValue3(currentDim, swSetValueInConfiguration_e.swSetValue_InAllConfigurations, Nothing)

            End If

            swModelDoc.Extension.Rebuild(0)

        End While


    End Function


End Class

