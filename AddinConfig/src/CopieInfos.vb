
Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Module CopieInfos


    Dim swModelDoc As ModelDoc2

    Dim volume As Volume

    Dim nameGodet As String

    Dim boolStatut As Boolean
    Dim intStatut As Integer


    Function SearchPosInStr(searchStr As String) As Integer

        Dim swAss As AssemblyDoc
        Dim swComp As Component2
        Dim swComps() As Object
        Dim swCompModelDoc As ModelDoc2
        Dim swCustomInfos As CustomPropertyManager

        Dim tampon As Object

        Dim descriptionBuffer As String

        swAss = swModelDoc

        swComps = swAss.GetComponents(False)

        For Each tampon In swComps

            swComp = tampon

            swCompModelDoc = swComp.GetModelDoc2

            If swCompModelDoc IsNot Nothing Then

                swCustomInfos = swCompModelDoc.Extension.CustomPropertyManager(swCompModelDoc.GetActiveConfiguration.Name)

                swCustomInfos.Get6("Description", False, "", descriptionBuffer, False, False)

                If InStr(1, descriptionBuffer, searchStr) <> 0 Then

                    boolStatut = swComp.Select4(False, Nothing, False)

                    'Return SearchPosSelectedComponent()

                    Exit Function

                End If

            End If

        Next

        Return -1

    End Function



    Function setVolume(ByRef swDimension As Dimension, ByVal targetVolume As Double) As Boolean
        'Permet de modifier une côtes en paramètre pour atteindre le volume ciblé

        Dim targetVolumeM3 As Double
        Dim currentVolumeM3 As Double
        Dim increment As Double
        Dim previousDown As Boolean 'boolean qui permet de savoir si le target est entre deux valeur déjà cherché
        Dim exitWhile As Boolean
        Dim LoadingForm As New LoadingForm
        Dim currentDim As Double

        previousDown = True
        exitWhile = False
        increment = 300
        targetVolumeM3 = targetVolume / 1000

        currentDim = swDimension.Value

        LoadingForm.Show()



        'LoadingForm.Repaint



        While Not (exitWhile)

            currentVolumeM3 = volume.GetLitre() / 1000

            If currentVolumeM3 < 0 Then

                MsgBox("Erreur de récupération du volume")
                exitWhile = True

            ElseIf Math.Abs(currentVolumeM3 - targetVolumeM3) < 0.05 Then

                exitWhile = True

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

            Else
                previousDown = False
                increment /= 2
                currentDim += increment
                swDimension.SetValue3(currentDim, swSetValueInConfiguration_e.swSetValue_InAllConfigurations, Nothing)

            End If

            swModelDoc.Extension.Rebuild(0)

        End While


        boolStatut = swModelDoc.Extension.ForceRebuildAll

        LoadingForm.Hide()

        Return True

    End Function

    Function getVolume() As Long

        Dim swComp As Component2
        Dim swVolumeModelDoc As ModelDoc2
        Dim swMassProperty As MassProperty2

        'swComp = SearchComponent(SearchPosInStr("Volume"))
        If swComp IsNot Nothing Then

            swVolumeModelDoc = swComp.GetModelDoc2
            boolStatut = swVolumeModelDoc.ShowConfiguration2(swComp.ReferencedConfiguration)
            swMassProperty = swVolumeModelDoc.Extension.CreateMassProperty2
            Return Math.Round(swVolumeModelDoc.Extension.CreateMassProperty2.volume * 1000)
            Exit Function

        End If

        Return -1

    End Function

End Module