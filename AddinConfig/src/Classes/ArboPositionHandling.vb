Imports SolidWorks.Interop.sldworks
Public Class ArboPositionHandling


    Private _swModelDoc As ModelDoc2

    Public Sub New(swModelDoc As ModelDoc2)

        _swModelDoc = swModelDoc

    End Sub

    Public Function GetSelectedArboPos() As Integer

        Dim swCompSelected As Component2
        Dim swSelMan As SelectionMgr
        Dim swFeat As Feature

        Dim i As Integer

        i = 0

        swSelMan = _swModelDoc.SelectionManager

        swCompSelected = swSelMan.GetSelectedObjectsComponent4(1, -1)

        If swCompSelected Is Nothing Then

            Return 0
            Exit Function

        ElseIf swSelMan.GetSelectedObjectCount2(-1) > 1 Then

            Return -1
            Exit Function

        End If

        swFeat = _swModelDoc.FirstFeature

        While swFeat IsNot Nothing

            If swFeat.GetTypeName = "Reference" Then

                i += 1

            End If

            If swCompSelected.GetID = swFeat.GetID Then

                Return i
                Exit Function

            End If

            swFeat = swFeat.GetNextFeature

        End While

    End Function

    Public Function GetSelectedArboInfo() As Boolean

        Dim resultSearchPosComp As Integer

        If _swModelDoc Is Nothing Then

            Return False
            Exit Function

        End If

        resultSearchPosComp = GetSelectedArboPos()

        If resultSearchPosComp = 0 Then

            MsgBox("Aucun composant n'est selectionné")

        ElseIf resultSearchPosComp < 0 Then

            MsgBox("Vous avez selectionné plusieurs éléments, veuillez n'en selectionner qu'un seul")

        Else

            MsgBox("L'élément sélectionné est à la position : " + CStr(resultSearchPosComp))

        End If

        Return True

    End Function

End Class


