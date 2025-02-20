Imports SolidWorks.Interop.sldworks
Public Class CopyPaste

    Protected _swModelDoc As ModelDoc2
    Protected _equipmentCodes As New EquipmentCodes
    Public Sub New(swModelDoc As ModelDoc2)

        _swModelDoc = swModelDoc


    End Sub


    Protected Function SearchCModelDocByProp(ByVal prop As String, ByVal value As String) As ModelDoc2

        Dim swAss As AssemblyDoc
        Dim swComp As Component2
        Dim swComps() As Object
        Dim swCompModelDoc As ModelDoc2
        Dim swCustomInfos As CustomPropertyManager

        Dim tampon As Object

        Dim descriptionBuffer As String

        If _swModelDoc.GetType <> 2 Or _swModelDoc Is Nothing Then

            Return Nothing
            Exit Function

        End If

        swAss = _swModelDoc

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
