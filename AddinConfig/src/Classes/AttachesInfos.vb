
Imports Microsoft.Office.Interop.Excel
Public Class AttachesInfosTuyauGraissage

    Private indexMachine As Integer = -1
    Private choixMachineForm As ChoixMachineTuyauGraissage
    Private sizeTab As Integer
    Private sizeColumn As Integer
    Private blocEqui As Boolean
    Private graissage As String
    Private attDirect As Boolean

    Private xlAp As Application
    Private xlWb As Workbook
    Private xlWs As Worksheet
    Private dataRange As Range


    Public Sub New()

        Initialize()

    End Sub


    Private Sub Initialize()

        xlAp = New Application
        xlWb = xlAp.Workbooks.Open("T:\Commun\B.E\Cinématique\Tableau attaches machines.xlsx")
        xlWs = xlWb.Sheets("Feuil1")

        sizeTab = xlWs.Cells(xlWs.Rows.Count, 1).End(XlDirection.xlUp).Row
        sizeColumn = xlWs.Cells(1, xlWs.Columns.Count).End(XlDirection.xlToLeft).Column

        dataRange = xlWs.Range(xlWs.Cells(2, 1), xlWs.Cells(sizeTab, sizeColumn))

        choixMachineForm = New ChoixMachineTuyauGraissage(dataRange.Resize(, 3).Value2)

        choixMachineForm.ShowDialog()

        graissage = If(choixMachineForm.RadioButton2.Checked, "TRAD", If(choixMachineForm.RadioButton3.Checked, "TWIN", "SANS"))

        blocEqui = choixMachineForm.CheckBoxBlocEqui.Checked

        attDirect = choixMachineForm.CheckBoxAD.Checked

        indexMachine = getIndexTabMachine(choixMachineForm.ListBoxMarque.SelectedItem, choixMachineForm.ListBoxModele.SelectedItem, choixMachineForm.ListBoxVersion.SelectedItem)


    End Sub

    Public Function GetSelectColumn(index As Integer) As String

        If indexMachine < 0 Then

            Return ""

        Else

            Return dataRange.Value2(indexMachine, index)

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

        Call replaceNullToString(Marque)
        Call replaceNullToString(modele)
        Call replaceNullToString(version)

        For i As Integer = 1 To sizeTab

            If dataRange.Value2(i, 1) = Marque And dataRange.Value2(i, 2) = modele And dataRange.Value2(i, 3) = version Then

                Return i
                Exit Function

            End If

        Next i

        Return -1

    End Function


    Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try

            xlWb.Close(False)
            xlAp.Quit()
            ReleaseObject(xlWs)
            ReleaseObject(xlWb)
            ReleaseObject(xlAp)

        Finally

            MyBase.Finalize()

        End Try

    End Sub
End Class