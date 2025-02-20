Public Class ChoixMachine

    Public machines As Object

    Public Sub New(machines As Object)

        Me.machines = machines


        InitializeComponent()
        ListBoxMarque.Items.Clear()
        ListBoxMarque.Items.AddRange(getColumn(1, "", ""))
        ListBoxModele.Items.Clear()
        ListBoxModele.Items.AddRange(getColumn(2, "", ""))
        ListBoxVersion.Items.Clear()
        ListBoxVersion.Items.AddRange(getColumn(3, "", ""))

    End Sub

    Private Sub CommandButtonOk_Click(sender As Object, e As EventArgs) Handles CommandButtonOk.Click
        Hide()
    End Sub



    Sub addInTab(ByRef ttab() As String, ByVal item As String)

        If ttab(0) = "" Then

            ttab(UBound(ttab)) = item

        ElseIf Not Utils.IsInArray(ttab, item) Then

            ReDim Preserve ttab(UBound(ttab) + 1)

            ttab(UBound(ttab)) = item

        End If

    End Sub

    Private Sub ListBoxMarque_Click(sender As Object, e As EventArgs) Handles ListBoxMarque.Click

        ListBoxModele.Items.Clear()
        ListBoxModele.Items.AddRange(getColumn(2, ListBoxMarque.SelectedItem, ""))
        ListBoxVersion.Items.Clear()
        ListBoxVersion.Items.AddRange(getColumn(3, ListBoxMarque.SelectedItem, ""))

    End Sub

    Private Sub ListBoxModele_Click(sender As Object, e As EventArgs) Handles ListBoxModele.Click

        ListBoxVersion.Items.Clear()
        ListBoxVersion.Items.AddRange(getColumn(3, ListBoxMarque.SelectedItem, ListBoxModele.SelectedItem))

    End Sub

    Private Function getColumn(column As Long, firstSelection As Object, secondSelection As Object) As String()

        Dim machine As Object
        Dim result() As String

        ReDim result(0)

        Select Case column

            Case 1

                For Each machine In machines

                    Call addInTab(result, Split(machine, "\")(0))

                Next

            Case 2

                For Each machine In machines

                    If isNullOrEmpty(ListBoxMarque.SelectedItem) Then

                        Call addInTab(result,
                                      Split(machine, "\")(1))

                    Else

                        If ListBoxMarque.SelectedItem = Split(machine, "\")(0) Then

                            Call addInTab(result, Split(machine, "\")(1))

                        End If

                    End If

                Next

            Case 3

                For Each machine In machines

                    If isNullOrEmpty(ListBoxMarque.SelectedItem) And isNullOrEmpty(ListBoxModele.SelectedItem) Then

                        Call addInTab(result, Split(machine, "\")(2))

                    ElseIf isNullOrEmpty(ListBoxModele.SelectedItem) Then

                        If ListBoxMarque.SelectedItem = Split(machine, "\")(0) Then

                            Call addInTab(result, Split(machine, "\")(2))

                        End If

                    Else

                        If ListBoxModele.SelectedItem = Split(machine, "\")(1) Then

                            Call addInTab(result, Split(machine, "\")(2))

                        End If

                    End If

                Next

        End Select

        Return result


    End Function
    Private Function isNullOrEmpty(expression As Object) As Boolean

        If expression Is Nothing Or expression = "" Then

            Return True
            Exit Function


        End If

        Return False

    End Function


End Class