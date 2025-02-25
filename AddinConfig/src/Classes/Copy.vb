Imports SolidWorks.Interop.sldworks
Public Class Copy
    Inherits CopyPaste

    Public Sub New(swModelDoc As ModelDoc2)
        MyBase.New(swModelDoc)
        _equipmentCodes.SelectCode()
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

        '_swModelDoc.GetComponents(False) 'ligne qui permet de résoudre le problème avec le fullParamsGodet (SearchComponent qui retourne nothing)



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

            End If

        Next i

        Return codeGodet

    End Function

    Private Function SaveViaSketch(ByVal valeurPrimaire As String) As String

        Dim swDimension As Dimension
        swDimension = _swModelDoc.Parameter(valeurPrimaire)

        If swDimension IsNot Nothing Then

            Return swDimension.SystemValue

        Else

            ErrorsHandling.AddError("""" + valeurPrimaire + """" + " n'existe pas dans cet assemblage")
            Return "-"

        End If

    End Function
    Private Function SaveConfig(ByVal CompPos As String) As String

        Dim swComp As Component2

        If Not IsNumeric(CompPos) Then

            ErrorsHandling.AddError("La pièce numéro """ + CompPos + """" + " n'est pas un nombre")
            Return "-"
            Exit Function

        End If

        swComp = SearchComponent(CompPos)

        If swComp IsNot Nothing Then

            Return swComp.ReferencedConfiguration

        Else

            ErrorsHandling.AddError("La pièce numéro """ + CompPos + """" + " n'existe pas dans cet assemblage")
            Return "-"

        End If

    End Function
    Private Function SaveState(ByVal CompPos As String) As String

        Dim swComp As Component2

        swComp = SearchComponent(CompPos)

        If swComp IsNot Nothing Then

            Return swComp.IsSuppressed

        Else

            ErrorsHandling.AddError("La pièce numéro """ + CompPos + """" + " n'existe pas dans cet assemblage")
            Return "-"

        End If

    End Function
    Private Function SaveStateFeat(ByVal nomFeat As String) As String

        Dim swFeat As Feature

        swFeat = SearchFeat(nomFeat)

        If swFeat IsNot Nothing Then

            Return swFeat.IsSuppressed

        Else

            ErrorsHandling.AddError("""" + nomFeat + """" + " n'existe pas dans cet assemblage")

            Return "-"

        End If

    End Function

End Class
