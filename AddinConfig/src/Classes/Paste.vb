Imports SolidWorks.Interop.sldworks
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

                Call LoadState(codeValue, (tableau(i)))

            ElseIf code = 3 Then

                Call LoadStateFeat(codeValue, (tableau(i)))

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

        swDimension.SystemValue = cote

    End Sub

    Private Sub LoadConfig(ByVal nomPiece As String, ByVal config As String)

        Dim swComp As Component2

        swComp = SearchComponent(nomPiece)

        If swComp Is Nothing Then

            ErrorsHandling.AddError("Aucune pièce avec le nom " + nomPiece + " n'existe dans l'assemblage")
            Exit Sub

        End If

        swComp.ReferencedConfiguration = config

    End Sub
    Private Sub LoadState(ByVal nomPiece As String, ByVal state As Boolean)

        Dim swComp As Component2

        swComp = SearchComponent(nomPiece)

        If swComp Is Nothing Then

            ErrorsHandling.AddError("Aucune pièce avec le nom " & nomPiece & " n'existe dans l'assemblage")
            Exit Sub

        End If

        If state Then

            swComp.SetSuppression2(0)

        ElseIf Not state Then

            swComp.SetSuppression2(2)

        End If

    End Sub

    Private Sub LoadStateFeat(ByVal nomFeat As String, ByVal state As Boolean)

        Dim swFeat As Feature

        swFeat = SearchFeat(nomFeat)

        If swFeat Is Nothing Then

            ErrorsHandling.AddError("Aucun feat avec le nom " & nomFeat & " n'existe dans l'assemblage")
            Exit Sub

        End If

        If state Then

            swFeat.SetSuppression2(0, 1, 0)

        ElseIf Not state Then

            swFeat.SetSuppression2(2, 1, 0)

        End If

    End Sub

End Class
