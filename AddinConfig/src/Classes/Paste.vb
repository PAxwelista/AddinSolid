Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Public Class Paste
    Inherits CopyPaste

    Public Sub New(swModelDoc As ModelDoc2)
        MyBase.New(swModelDoc)

    End Sub
    Public Function Paste(Optional initialCode As String = "") As Boolean

        Dim codeGodet As String
        Dim typeGodet As EquipmentCode
        Dim tableau() As String

        If initialCode = "" Then

            codeGodet = InputBox("Coller le code Godet : ", "Code Godet")

        Else

            codeGodet = initialCode

        End If

        If codeGodet = "" Then
            ErrorsHandling.AddError("Aucun code renseigné")
            Return False
            Exit Function
        End If

        tableau = Split(codeGodet, ";")

        typeGodet = _equipmentCodes.GetCodeWithType(tableau(0))



        If typeGodet Is Nothing Then

            ErrorsHandling.AddError("typeGodet est nothing")

            Return False

            Exit Function

        End If

        If Not ((Utils.DimTableau(tableau)) = (typeGodet.GetCode.Length)) Then

            ErrorsHandling.AddError("Le code godet n'est pas de même taille, ce qui peut influencer sur les résultats finaux")

        End If

        For i As Integer = 1 To Utils.DimTableau(tableau)
            Dim code As Integer = typeGodet.GetCode(i - 1).Item1
            Dim codeValue As String = typeGodet.GetCode(i - 1).Item2

            If code = 0 Then

                Call LoadViaSketch(codeValue, (tableau(i)))

            ElseIf code = 1 Then

                Call LoadConfig(codeValue, (tableau(i)))

            ElseIf code = 2 Then

                If tableau(i) <> "" And tableau(i) <> "-" Then Call LoadState(codeValue, (tableau(i)))

            ElseIf code = 3 Then

                Call LoadStateFeat(codeValue, (tableau(i)))

            ElseIf code = 5 Then

                Call LoadHoleFastenerSize(codeValue, (tableau(i)))

            End If

        Next i

        Return True

    End Function


    Private Sub LoadViaSketch(ByVal valeurPrimaire As String, ByVal cote As String)

        Dim swDimension As Dimension

        swDimension = _swModelDoc.Parameter(valeurPrimaire)

        If swDimension Is Nothing Then

            ErrorsHandling.AddError("Le nom " + valeurPrimaire + " n'existe pas dans l'assemblage")
            Exit Sub

        End If

        If cote = "" Then

            ErrorsHandling.AddError("La côte utilisé pour " + valeurPrimaire + " n'a aucune valeur")
            Exit Sub

        End If

        If Not IsNumeric(cote) Then

            ErrorsHandling.AddError("La côte utilisé pour " + valeurPrimaire + " n'est pas numérique")
            Exit Sub

        End If

        swDimension.SetValue3(cote, 1, "")

    End Sub

    Private Sub LoadConfig(ByVal compPos As String, ByVal config As String)

        Dim swComp As Component2

        swComp = SearchComponent(compPos)

        If swComp Is Nothing Then

            ErrorsHandling.AddError("Aucune pièce avec la position " + compPos + " n'existe dans l'assemblage")
            Exit Sub

        End If

        swComp.ReferencedConfiguration = config

    End Sub
    Private Sub LoadState(ByVal compPos As String, ByVal state As Boolean)

        Dim swComp As Component2

        swComp = SearchComponent(compPos)

        If swComp Is Nothing Then

            ErrorsHandling.AddError("Aucune pièce avec la position " & compPos & " n'existe dans l'assemblage")
            Exit Sub

        End If

        If state Then

            swComp.SetSuppression2(2)

        ElseIf Not state Then

            swComp.SetSuppression2(0)

        End If

    End Sub

    Private Sub LoadStateFeat(ByVal nomFeat As String, ByVal state As Boolean)

        Dim swFeat As Feature

        swFeat = SearchFeat(nomFeat)

        If swFeat Is Nothing Then

            ErrorsHandling.AddError("Aucun feat avec le nom " & nomFeat & " n'existe dans l'assemblage")
            Exit Sub

        End If

        If swFeat.GetTypeName2 = "FtrFolder" Then 'Si le Feat est un Dossier

            _swModelDoc.Extension.SelectByID2(swFeat.Name, UCase(swFeat.GetTypeName2), 0, 0, 0, False, 0, Nothing, 0)

            If state Then

                _swModelDoc.EditUnsuppress2()

            ElseIf Not state Then

                _swModelDoc.EditSuppress2()


            End If

        Else

            If state Then

                swFeat.SetSuppression2(2, 1, 0)

            ElseIf Not state Then

                swFeat.SetSuppression2(0, 1, 0)

            End If

        End If

    End Sub

    Private Sub LoadHoleFastenerSize(ByVal nomFeat As String, ByVal fastener As String)

        Dim swFeat As Feature
        Dim swWizardHole As WizardHoleFeatureData2

        swFeat = SearchFeat(nomFeat)

        If swFeat Is Nothing Then

            ErrorsHandling.AddError("""" + nomFeat + """ n'existe pas dans cet assemblage")
            Exit Sub

        End If

        If swFeat.GetTypeName2 <> "HoleWzd" Then

            ErrorsHandling.AddError("""" + nomFeat + """ n'est pas un trou avec assistance de perçage")
            Exit Sub

        End If

        swWizardHole = swFeat.GetDefinition

        If Not swWizardHole.ChangeStandard(swWzdHoleStandards_e.swStandardISO, swWzdHoleStandardFastenerTypes_e.swStandardISOTappedHole, fastener) Then

            ErrorsHandling.AddError("""" + nomFeat + """ n'a pas reussi le changement de taraudage")
            Exit Sub

        End If

        swFeat.ModifyDefinition(swWizardHole, _swModelDoc, Nothing)

    End Sub

End Class
