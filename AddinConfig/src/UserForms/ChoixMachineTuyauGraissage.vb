Public Class ChoixMachineTuyauGraissage

    Public machines As Object(,)

    Public Sub New(machines As Object(,))

        Me.machines = machines


        InitializeComponent()
        ListBoxMarque.Items.Clear()
        ListBoxMarque.Items.AddRange(GetColumn(1))
        ListBoxModele.Items.Clear()
        ListBoxModele.Items.AddRange(GetColumn(2))
        ListBoxVersion.Items.Clear()
        ListBoxVersion.Items.AddRange(GetColumn(3))

    End Sub

    Private Sub CommandButtonOk_Click(sender As Object, e As EventArgs) Handles CommandButtonOk.Click
        Hide()
    End Sub



    Sub AddInTab(ByRef ttab() As String, ByVal item As String)

        If ttab(0) = "" Then

            ttab(UBound(ttab)) = item

        ElseIf Not Utils.IsInArray(ttab, item) Then

            ReDim Preserve ttab(UBound(ttab) + 1)

            ttab(UBound(ttab)) = item

        End If

    End Sub

    Private Sub ListBoxMarque_Click(sender As Object, e As EventArgs) Handles ListBoxMarque.Click

        ListBoxModele.Items.Clear()
        ListBoxModele.Items.AddRange(GetColumn(2))
        ListBoxVersion.Items.Clear()
        ListBoxVersion.Items.AddRange(GetColumn(3))

    End Sub

    Private Sub ListBoxModele_Click(sender As Object, e As EventArgs) Handles ListBoxModele.Click

        ListBoxVersion.Items.Clear()
        ListBoxVersion.Items.AddRange(GetColumn(3))

    End Sub

    Private Function GetColumn(column As Integer) As String()


        Dim result() As String
        ReDim result(0)

        Select Case column

            Case 1

                For i As Integer = 2 To machines.GetLength(0)

                    Call AddInTab(result, machines(i, 1).ToString)

                Next

            Case 2

                For i As Integer = 2 To machines.GetLength(0)

                    If IsNullOrEmpty(ListBoxMarque.SelectedItem) Then

                        Call AddInTab(result, machines(i, 2).ToString)

                    Else

                        If ListBoxMarque.SelectedItem = machines(i, 1) Then

                            Call AddInTab(result, machines(i, 2).ToString)

                        End If

                    End If

                Next

            Case 3

                For i As Integer = 2 To machines.GetLength(0)

                    If IsNullOrEmpty(ListBoxMarque.SelectedItem) And IsNullOrEmpty(ListBoxModele.SelectedItem) Then

                        Call AddInTab(result, machines(i, 3).ToString)

                    ElseIf IsNullOrEmpty(ListBoxModele.SelectedItem) Then

                        If ListBoxMarque.SelectedItem = machines(i, 1).ToString Then

                            Call AddInTab(result, machines(i, 3).ToString)

                        End If

                    Else

                        If ListBoxModele.SelectedItem = machines(i, 2).ToString Then

                            Call AddInTab(result, machines(i, 3).ToString)

                        End If

                    End If

                Next

        End Select

        Return result


    End Function
    Private Function IsNullOrEmpty(expression As Object) As Boolean

        If expression Is Nothing Or expression = "" Then

            Return True
            Exit Function


        End If

        Return False

    End Function

    Private Sub ChoixMachineTuyauGraissage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class