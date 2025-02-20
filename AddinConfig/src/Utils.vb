
Option Explicit On
Module Utils



    Sub addInTab(ByRef ttab() As String, item As String)

        If ttab(0) = "" Then

            ttab(UBound(ttab)) = item

        ElseIf Not utils.IsInArray(ttab, item) Then

            ReDim Preserve ttab(UBound(ttab) + 1)

            ttab(UBound(ttab)) = item

        End If

    End Sub

    Function IsInArray(ByRef arr() As String, elmt As String) As Boolean

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
End Module