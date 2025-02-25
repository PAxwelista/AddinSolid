Imports SolidWorks.Interop.sldworks
Public Class CopyPaste

    Protected _swModelDoc As ModelDoc2
    Protected _equipmentCodes As New EquipmentCodes
    Public Sub New(swModelDoc As ModelDoc2)

        _swModelDoc = swModelDoc


    End Sub





    Function SearchComponent(ByVal CompPos As Integer) As Component2

        Dim swFeat As Feature
        Dim swSelMan As SelectionMgr
        Dim i As Integer = 0
        Dim swComp As Component

        If _swModelDoc Is Nothing Then

            Return Nothing
            Exit Function

        End If

        swSelMan = _swModelDoc.SelectionManager

        swFeat = _swModelDoc.FirstFeature

        While swFeat IsNot Nothing

            If swFeat.GetTypeName = "Reference" Then

                i += 1

            End If

            If i = CompPos Then

                swFeat.Select2(False, 0)
                swComp = swSelMan.GetSelectedObjectsComponent4(1, -1)
                swSelMan.DeSelect2(CLng(1), -1)
                Return swComp
                Exit Function

            End If

            swFeat = swFeat.GetNextFeature

        End While

        Return Nothing


    End Function

    Function SearchFeat(ByVal FeatName As String) As Feature

        Dim swFeat As Feature

        If _swModelDoc Is Nothing Then

            Return Nothing
            Exit Function

        End If

        swFeat = _swModelDoc.FirstFeature

        While swFeat IsNot Nothing

            If swFeat.Name = FeatName Then

                Return swFeat

                Exit Function

            End If

            swFeat = swFeat.GetNextFeature

        End While

        Return Nothing

    End Function

End Class
