Public Class EquipmentCodes

    Private ReadOnly _typesGodet() As EquipmentCode
    Private _typeGodet As EquipmentCode

    Public Sub New()

        Dim codeDI_M As New EquipmentCode("DI_M", {
            Tuple.Create(0, "D1@Dessus"),
            Tuple.Create(0, "D2@Profil general"),
            Tuple.Create(0, "D10@Profil general"),
            Tuple.Create(0, "D3@Profil general"),
            Tuple.Create(0, "D11@Profil general"),
            Tuple.Create(1, "31"),
            Tuple.Create(1, "4"),
            Tuple.Create(1, "5"),
            Tuple.Create(1, "6"),
            Tuple.Create(1, "20"),
            Tuple.Create(1, "1"),
            Tuple.Create(2, "16"),
            Tuple.Create(2, "26"),
            Tuple.Create(2, "27"),
            Tuple.Create(2, "28"),
            Tuple.Create(1, "16"),
            Tuple.Create(1, "36"),
            Tuple.Create(3, "Composant sym caisson balancier"),
            Tuple.Create(1, "2"),
            Tuple.Create(1, "3"),
            Tuple.Create(2, "24"),
            Tuple.Create(2, "25")
            }
         )

        Dim CodeDI_201 As New EquipmentCode("DI_201", {
            Tuple.Create(0, "D1@Dessus"),
            Tuple.Create(1, "26"),
            Tuple.Create(0, "D6@Dessus"),
            Tuple.Create(0, "D1@Profil godet"),
            Tuple.Create(0, "D2@Profil godet"),
            Tuple.Create(0, "D3@Profil godet"),
            Tuple.Create(1, "4"),
            Tuple.Create(1, "5"),
            Tuple.Create(1, "29"),
            Tuple.Create(2, "24"),
            Tuple.Create(2, "23"),
            Tuple.Create(2, "25"),
            Tuple.Create(1, "19"),
            Tuple.Create(1, "1"),
            Tuple.Create(1, "15"),
            Tuple.Create(1, "2"),
            Tuple.Create(1, "3"),
            Tuple.Create(2, "21"),
            Tuple.Create(3, "Composant sym caisson balancier"),
            Tuple.Create(2, "22"),
            Tuple.Create(4, "24"),
            Tuple.Create(1, "6"),
            Tuple.Create(1, "7"),
            Tuple.Create(0, "D3@Positions axes chassis et caisse"),
            Tuple.Create(0, "D5@Positions axes chassis et caisse"),
            Tuple.Create(0, "D2@Positions axes chassis et caisse"),
            Tuple.Create(0, "D4@Positions axes chassis et caisse"),
            Tuple.Create(2, "35")
            }
         )

        Dim CodeCaisseGP_HD_XHD As New EquipmentCode("Caisse GP-HD-XHD", {
            Tuple.Create(0, "D4@Dessous caisse"),
            Tuple.Create(1, "15"),
            Tuple.Create(0, "D2@Profil godet"),
            Tuple.Create(0, "D6@Profil godet"),
            Tuple.Create(0, "D1@Profil godet"),
            Tuple.Create(1, "7"),
            Tuple.Create(1, "5"),
            Tuple.Create(1, "6"),
            Tuple.Create(1, "9"),
            Tuple.Create(1, "16"),
            Tuple.Create(2, "18"),
            Tuple.Create(2, "17"),
            Tuple.Create(3, "Composant symétrique déflecteur"),
            Tuple.Create(2, "13"),
            Tuple.Create(4, "16"),
            Tuple.Create(0, "D17@Profil caisse"),
            Tuple.Create(0, "D43@Profil caisse"),
            Tuple.Create(0, "D4@Dessous caisse"),
            Tuple.Create(0, "D5@Dessous caisse"),
            Tuple.Create(0, "D6@Dessous caisse"),
            Tuple.Create(0, "D9@Dessous caisse"),
            Tuple.Create(0, "D5@Profil godet"),
            Tuple.Create(0, "D14@Profil caisse"),
            Tuple.Create(0, "D13@Profil caisse"),
            Tuple.Create(0, "D39@Profil caisse")
            }
         )

        Dim CodeAttachesGP_HD_XHD As New EquipmentCode("Attaches GP-HD-XHD", {
            Tuple.Create(3, "Composant sym. général"),
            Tuple.Create(3, "Sym. Develon")
            }
        )

        _typesGodet = {codeDI_M, CodeDI_201, CodeCaisseGP_HD_XHD, CodeAttachesGP_HD_XHD}

    End Sub

    Public Function SelectCode() As Boolean

        Dim FenetreChoixCopier As New FenetreChoixCopier

        FenetreChoixCopier.ComboBoxType.ResetText()

        For Each typeGodet As EquipmentCode In _typesGodet

            FenetreChoixCopier.ComboBoxType.Items.Add(typeGodet.GetEquipmentType)

        Next

        FenetreChoixCopier.ShowDialog()

        _typeGodet = GetCodeWithType(FenetreChoixCopier.ComboBoxType.SelectedItem)
    End Function

    Public Function GetSelected() As EquipmentCode

        Return _typeGodet

    End Function


    Public Function GetCodeWithType(type As String) As EquipmentCode

        For Each typeGodet As EquipmentCode In _typesGodet

            If typeGodet.GetEquipmentType = type Then

                Return typeGodet

                Exit Function

            End If

        Next

        Return Nothing


    End Function


End Class
