Imports SolidWorks.Interop.sldworks
Public Class Copy
    Inherits CopyPaste

    Public Sub New(swModelDoc As ModelDoc2)
        MyBase.New(swModelDoc)

        If GetCustomProperty(_swModelDoc, "Code configurateur") = "" Then

            _equipmentCodes.SelectCode()

        Else

            _equipmentCodes.SelectCodeWithType(GetCustomProperty(_swModelDoc, "Code configurateur"))

        End If



    End Sub

    Public Function Copy() As String

        Dim FenetreChoixCopier As New FenetreChoixCopier
        Dim codeGodet As String
        Dim Volume As New Volume(SearchModelDocByProp(_swModelDoc, "Description", "Volume"))
        Dim equipmentCode As EquipmentCode
        Dim code As Integer
        Dim codeValue As String


        If _equipmentCodes.GetSelected Is Nothing Then

            Return "Problème code"
            Exit Function

        End If

        equipmentCode = _equipmentCodes.GetSelected
        codeGodet = equipmentCode.GetEquipmentType



        For i As Integer = 0 To equipmentCode.GetCode.Length - 1
            code = equipmentCode.GetCode(i).Item1
            codeValue = equipmentCode.GetCode(i).Item2

            If code = 0 Then

                codeGodet += ";" & SaveViaSketch(codeValue)

            ElseIf code = 1 Then

                codeGodet += ";" & SaveConfig(codeValue)

            ElseIf code = 2 Then

                codeGodet += ";" & SaveState(codeValue)

            ElseIf code = 3 Then

                codeGodet += ";" & SaveStateFeat(codeValue)

            ElseIf code = 4 Then

                codeGodet += ";" & Volume.GetLitre()


            ElseIf code = 5 Then

                codeGodet += ";" & SaveHoleFastenerSize(codeValue)

            End If

        Next i

        Return codeGodet

    End Function

    Private Function SaveViaSketch(ByVal valeurPrimaire As String) As String

        Dim swDimension As Dimension
        swDimension = _swModelDoc.Parameter(valeurPrimaire)

        If swDimension IsNot Nothing Then

            Return swDimension.GetValue3(1, "")(0)

        Else

            ErrorsHandling.AddError("""" + valeurPrimaire + """ n'existe pas dans cet assemblage")
            Return "-"

        End If

    End Function
    Private Function SaveConfig(ByVal CompPos As String) As String

        Dim swComp As Component2

        If Not IsNumeric(CompPos) Then

            ErrorsHandling.AddError("La pièce numéro """ + CompPos + """ n'est pas un nombre")
            Return "-"
            Exit Function

        End If

        swComp = SearchComponent(CompPos)

        If swComp IsNot Nothing Then

            Return swComp.ReferencedConfiguration

        Else

            ErrorsHandling.AddError("La pièce numéro """ + CompPos + """ n'existe pas dans cet assemblage")
            Return "-"

        End If

    End Function
    Private Function SaveState(ByVal CompPos As String) As String

        Dim swComp As Component2

        swComp = SearchComponent(CompPos)

        If swComp IsNot Nothing Then

            Return Not swComp.IsSuppressed

        Else

            ErrorsHandling.AddError("La pièce numéro """ + CompPos + """ n'existe pas dans cet assemblage")
            Return "-"

        End If

    End Function
    Private Function SaveStateFeat(ByVal nomFeat As String) As String

        Dim swFeat As Feature

        swFeat = SearchFeat(nomFeat)

        If swFeat IsNot Nothing Then

            Return Not swFeat.IsSuppressed

        Else

            ErrorsHandling.AddError("""" + nomFeat + """ n'existe pas dans cet assemblage")
            Return "-"

        End If

    End Function

    Private Function SaveHoleFastenerSize(ByVal nomFeat As String) As String

        Dim swFeat As Feature
        Dim swWizardHole As WizardHoleFeatureData2

        swFeat = SearchFeat(nomFeat)

        If swFeat Is Nothing Then

            ErrorsHandling.AddError("""" + nomFeat + """ n'existe pas dans cet assemblage")
            Return "-"
            Exit Function

        End If

        If swFeat.GetTypeName2 <> "HoleWzd" Then

            ErrorsHandling.AddError("""" + nomFeat + """ n'est pas un trou avec assistance de perçage")
            Return "-"
            Exit Function

        End If

        swWizardHole = swFeat.GetDefinition

        Return swWizardHole.FastenerSize

    End Function

End Class
