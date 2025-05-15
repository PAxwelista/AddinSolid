
Imports BiblioIEV
Public Class AttachesInfosTuyauGraissage

    Private indexMachine As Integer = -1
    Private choixMachineForm As ChoixMachineTuyauGraissage
    Private blocEqui As Boolean
    Private graissage As String
    Private attDirect As Boolean

    Private allValues As Object(,)

    Private excelReader As New ReadExcel


    Public Sub New()

        Initialize()

    End Sub


    Private Sub Initialize()

        allValues = excelReader.GetExcelTab("T:\Commun\B.E\Cinématique\Tableau attaches machines.xlsx", "Feuil1")

        choixMachineForm = New ChoixMachineTuyauGraissage(allValues)

        choixMachineForm.ShowDialog()

        graissage = If(choixMachineForm.RadioButton2.Checked, "TRAD", If(choixMachineForm.RadioButton3.Checked, "TWIN", "SANS"))

        blocEqui = choixMachineForm.CheckBoxBlocEqui.Checked

        attDirect = choixMachineForm.CheckBoxAD.Checked

        indexMachine = GetIndexTabMachine(choixMachineForm.ListBoxMarque.SelectedItem, choixMachineForm.ListBoxModele.SelectedItem, choixMachineForm.ListBoxVersion.SelectedItem)


    End Sub

    Public Function GetSelectColumn(index As Integer) As String

        If indexMachine < 0 Then

            Return ""

        Else

            Return allValues(indexMachine, index)  ' it Must be good, try it

        End If



    End Function

    Public Function GetSelectColumnValues(beginIndex As Integer, endIndex As Integer) As String

        Dim columnValues As String = ""

        If indexMachine < 0 Then

            Return ""

        Else

            For i As Integer = beginIndex To endIndex

                columnValues &= If(i = beginIndex, "", ";") & allValues(indexMachine, i) ' it Must be good, try it

            Next

            Return columnValues

        End If



    End Function

    Public Function GetGraissage() As String

        Return graissage

    End Function
    Public Function GetBlocEqui() As Boolean

        Return blocEqui

    End Function
    Public Function GetAttDirect() As Boolean

        Return attDirect

    End Function


    Private Function GetIndexTabMachine(Marque As Object, modele As Object, version As Object) As Integer

        Call ReplaceNullToString(Marque)
        Call ReplaceNullToString(modele)
        Call ReplaceNullToString(version)

        For i As Integer = 1 To allValues.GetLength(0)

            If allValues(i, 1) = Marque And allValues(i, 2) = modele And allValues(i, 3) = version Then ' good but need a try

                Return i
                Exit Function

            End If

        Next i

        Return -1

    End Function



End Class