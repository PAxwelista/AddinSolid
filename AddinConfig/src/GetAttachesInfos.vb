Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module GetAttachesInfos

    Dim isExcelAlreadyOpen As Boolean
    Dim isDocOpen As Boolean
    Dim sizeTab As Long
    Dim xlWs As Worksheet

    Function recupInfosMachineChoisi() As String

        Dim xlAp As Application
        Dim xlWbs As Workbooks
        Dim xlWb As Workbook
        Dim xlSs As Sheets

        Dim ChoixMachineForm As ChoixMachine

        Dim exitSelectMachine As Boolean
        Dim angDos As String
        Dim angPos As String
        Dim hauteurTransport As String
        Dim angleCaveeHaute As String
        Dim hauteurCaveeHaute As String
        Dim planAttache As String
        Dim indexSelectMachine As Integer
        Dim i As Integer
        Dim machines() As String

        isDocOpen = False

        xlAp = getXlApp()
        On Error GoTo closeExcel 'permet de fermer excel si besoin en cas d'erreur, cela évite les 20 excel ouvert en arrière plan
        xlWbs = xlAp.Workbooks

        If isExcelAlreadyOpen Then

            For i = 1 To xlWbs.Count

                If xlWbs.Item(i).Name = "Tableau attaches machines.xlsx" Then

                    isDocOpen = True

                End If

            Next i

        End If

        xlWb = xlWbs.Open("T:\Commun\B.E\Cinématique\Tableau attaches machines.xlsx")

        'récupère le premier onglet
        xlSs = xlWb.Sheets

        xlWs = xlWb.ActiveSheet

        sizeTab = xlWs.UsedRange.Rows.Count

        ReDim machines(sizeTab - 2)

        For i = 2 To sizeTab



            machines(i - 2) = (xlWs.Cells(i, 1).Value & "\" & xlWs.Cells(i, 2).Value & "\" & xlWs.Cells(i, 3).Value)

        Next i

        ChoixMachineForm = New ChoixMachine(machines)

        indexSelectMachine = -1
        exitSelectMachine = False

        While indexSelectMachine = -1 And Not exitSelectMachine

            ChoixMachineForm.ShowDialog()

            indexSelectMachine = getIndexTabMachine(ChoixMachineForm.ListBoxMarque.SelectedItem, ChoixMachineForm.ListBoxModele.SelectedItem, ChoixMachineForm.ListBoxVersion.SelectedItem)

            If indexSelectMachine = -1 Then exitSelectMachine = IIf(MsgBox("La machine ne correspond pas, voulez vous refaire une sélection?", vbYesNo) = 7, True, False)

        End While

        If indexSelectMachine <> -1 Then

            planAttache = ""

            If ChoixMachineForm.CheckBoxAD.Checked Then 'si on chosit une attahe directe on récupère le plan adapté

                planAttache = xlWs.Cells(indexSelectMachine, 19)

            End If

            angDos = xlWs.Cells(indexSelectMachine, 17).Value
            angPos = xlWs.Cells(indexSelectMachine, 18).Value
            hauteurTransport = xlWs.Cells(indexSelectMachine, 23).Value
            angleCaveeHaute = xlWs.Cells(indexSelectMachine, 22).Value
            hauteurCaveeHaute = xlWs.Cells(indexSelectMachine, 21).Value

        End If

        Return angDos & "\" & angPos & "\" & planAttache & "\" & ChoixMachineForm.ListBoxMarque.SelectedItem & "\" & ChoixMachineForm.ListBoxModele.SelectedItem & "\" & ChoixMachineForm.ListBoxVersion.SelectedItem & "\" & ChoixMachineForm.CheckBoxAD.Checked & "\" & hauteurTransport & "\" & angleCaveeHaute & "\" & hauteurCaveeHaute

        If indexSelectMachine = -1 Then Return "" 'dans le cas ou le choix n'était pas bon

        If Not isDocOpen Then

            xlWb.Close()

        End If

closeExcel:

        If Not isExcelAlreadyOpen Then


            'vide tout les éléments de type excel afin de pouvoir fermer le processus correctement
            xlSs = Nothing
            xlWbs = Nothing
            xlWb = Nothing
            xlWs = Nothing
            xlAp.Quit()
            xlAp = Nothing

        End If

    End Function
    Function getXlApp() As Application

        On Error GoTo openNewExcel

        Return GetObject(, "Excel.Application")
        isExcelAlreadyOpen = True
        Exit Function

openNewExcel:

        Return CreateObject("Excel.Application")
        Exit Function

    End Function

    Function getIndexTabMachine(Marque As Object, modele As Object, version As Object) As Integer

        Dim i As Integer

        Call replaceNullToString(Marque)
        Call replaceNullToString(modele)
        Call replaceNullToString(version)

        For i = 2 To sizeTab

            If xlWs.Cells(i, 1) = Marque And xlWs.Cells(i, 2) = modele And xlWs.Cells(i, 3) = version Then

                Return i
                Exit Function

            End If

        Next i

        Return -1

    End Function

    Private Sub replaceNullToString(ByRef expression As Object)

        If expression = vbNull Then expression = "" 'vérifier le vbnull

    End Sub
End Module