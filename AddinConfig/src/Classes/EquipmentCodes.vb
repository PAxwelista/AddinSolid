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

        Dim CodeDI_201 As New EquipmentCode("DI", {
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
            Tuple.Create(0, "D3@Dessous caisse"),
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
            Tuple.Create(0, "D8@Position et Ø trous"),
            Tuple.Create(0, "D4@Position et Ø trous"),
            Tuple.Create(0, "D5@Position et Ø trous"),
            Tuple.Create(0, "D6@Position et Ø trous"),
            Tuple.Create(0, "D7@Position et Ø trous"),
            Tuple.Create(0, "D1@Position et Ø trous"),
            Tuple.Create(0, "D38@Profil général"),
            Tuple.Create(0, "D65@Profil général"),
            Tuple.Create(0, "D21@Profil général"),
            Tuple.Create(0, "D5@Profil général"),
            Tuple.Create(0, "D60@Profil général"),
            Tuple.Create(0, "D35@Profil général"),
            Tuple.Create(3, "Butée type Liebherr"),
            Tuple.Create(3, "Butée type Develon"),
            Tuple.Create(0, "D4@Dessous attaches"),
            Tuple.Create(0, "D13@Dessous attaches"),
            Tuple.Create(0, "D2@Dessous attaches"),
            Tuple.Create(0, "D3@Dessous attaches"),
            Tuple.Create(0, "D8@Dessous attaches"),
            Tuple.Create(0, "D14@Dessous attaches"),
            Tuple.Create(0, "D1@Dessous attaches"),
            Tuple.Create(0, "D6@Dessous attaches"),
            Tuple.Create(0, "D7@Dessous attaches"),
            Tuple.Create(0, "D25@Profil général"),
            Tuple.Create(0, "D24@Profil général"),
            Tuple.Create(0, "D5@Dessous attaches"),
            Tuple.Create(0, "D16@Dessous attaches"),
            Tuple.Create(2, "28"),
            Tuple.Create(2, "29"),
            Tuple.Create(2, "2"),
            Tuple.Create(2, "3"),
            Tuple.Create(3, "Bossage joint int."),
            Tuple.Create(3, "Sym. Liebherr"),
            Tuple.Create(3, "Sym. Develon"),
            Tuple.Create(3, "Sym. Volvo"),
            Tuple.Create(1, "1"),
            Tuple.Create(1, "2"),
            Tuple.Create(1, "3"),
            Tuple.Create(2, "4"),
            Tuple.Create(3, "Sym goutte d'eau central int"),
            Tuple.Create(2, "5"),
            Tuple.Create(3, "Sym goutte d'eau central ext"),
            Tuple.Create(2, "6"),
            Tuple.Create(2, "7"),
            Tuple.Create(5, "Trou taraudé")
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


    Public Function SelectCodeWithType(type As String) As Boolean

        _typeGodet = GetCodeWithType(type)

    End Function

End Class
