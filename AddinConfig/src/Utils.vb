
Option Explicit On
Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst


Module Utils



    Sub AddInTab(ByRef ttab() As String, item As String)

        If ttab(0) = "" Then

            ttab(UBound(ttab)) = item

        ElseIf Not Utils.IsInArray(ttab, item) Then

            ReDim Preserve ttab(UBound(ttab) + 1)

            ttab(UBound(ttab)) = item

        End If

    End Sub

    Function IsInArray(ByRef arr As String(), elmt As String) As Boolean

        Dim i As Integer

        For i = 0 To UBound(arr)

            If arr(i) = elmt Then

                Return True
                Exit Function

            End If

        Next i

        Return False

    End Function

    Function DimTableau(a As Object) As Long

        If a Is Nothing Then ' vérifier ce point la égaelement

            Return 0

        Else

            Return UBound(a) - LBound(a)

        End If

    End Function
    Sub AddCustInfoToAllConfig(ModelDoc As ModelDoc2, ByVal FieldName As String, ByVal FieldValue As String)

        Dim configs() As String
        Dim config As Object

        configs = ModelDoc.GetConfigurationNames

        ModelDoc.Extension.CustomPropertyManager("").Set2(FieldName, FieldValue)

        For Each config In configs

            ModelDoc.Extension.CustomPropertyManager(config).Set2(FieldName, FieldValue)

        Next

    End Sub
    Function ReplaceRoundLg(elmtToReplace As String, realLg As String(), configNameLg As String()) As String ' taille modifié pour DI201

        'Fait pour remplacer plusieurs elmt de RealLg et par configNameLg


        For i As Integer = 0 To UBound(realLg)

            If elmtToReplace = realLg(i) Then

                Return configNameLg(i)

                Exit Function

            End If

        Next i

        Return elmtToReplace

    End Function

    Function SearchModelDocByProp(swModelDoc As ModelDoc2, ByVal prop As String, ByVal value As String) As ModelDoc2

        Dim swAss As AssemblyDoc
        Dim swComp As Component2
        Dim swComps() As Object
        Dim swCompModelDoc As ModelDoc2
        Dim swCustomInfos As CustomPropertyManager

        Dim tampon As Object

        Dim descriptionBuffer As String = ""

        If swModelDoc.GetType <> 2 Or swModelDoc Is Nothing Then

            Return Nothing
            Exit Function

        End If

        swAss = swModelDoc

        swComps = swAss.GetComponents(False)

        For Each tampon In swComps

            swComp = tampon

            swCompModelDoc = swComp.GetModelDoc2

            If swCompModelDoc IsNot Nothing Then

                swCustomInfos = swCompModelDoc.Extension.CustomPropertyManager(swCompModelDoc.GetActiveConfiguration.Name)

                swCustomInfos.Get6(prop, False, "", descriptionBuffer, False, False)

                If descriptionBuffer = value Then

                    Return swComp.GetModelDoc2

                    Exit Function

                End If

            End If

        Next

        Return Nothing

    End Function

    Function ConvertToNumb(val As String) As Integer

        If IsNumeric(val) Then

            Return val


        Else

            Return 0

        End If

    End Function

    Function ChangeSketchDim(swModelDoc As ModelDoc2, newDim As Double, dimString As String) As Boolean

        Dim swDimension As Dimension

        swDimension = swModelDoc.Parameter(dimString)

        swDimension.SetValue3(newDim, swSetValueInConfiguration_e.swSetValue_InAllConfigurations, Nothing)


    End Function

    Sub ReplaceNullToString(ByRef expression As Object)

        If expression = Nothing Then expression = ""

    End Sub
End Module