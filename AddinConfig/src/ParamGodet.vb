Option Explicit On
Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Module ParamGodet


    Dim longueur As String
    Dim volume As String
    Dim angDos As String
    Dim angPos As String
    Dim flanc As String
    Dim classe As String

    Dim boolStatut As Boolean

    Sub ParamGodet(typesGodet As Object, swModelDoc As ModelDoc2) 'configuré pour le DI 201

        Const PI = 3.14159265358979

        Dim infosGodDI As InfosGodetsDI

        Dim swDim As Dimension

        Dim tabCodeGodet() As String
        Dim codeGodet As String
        Dim stringTampon As String
        Dim tabTamp() As String


        'codeGodet = CopieInfos.Copier(typesGodet, swModelDoc)

        If codeGodet = "" Then

            MsgBox("Le code godet n'a pas été sélectionné")
            Exit Sub

        End If

        tabCodeGodet = Split(codeGodet, ";")

        If Utils.IsInArray(tabCodeGodet, "") Then

            If MsgBox("Le code godet n'a pas reussi à récupérer toutes les infos du godet. Cela peut être du à un copié/collé avec un ancien godet. Voulez vous tout de même continuer?", vbYesNo) = 7 Then Exit Sub

        End If

        infosGodDI = New InfosGodetsDI

        swDim = swModelDoc.Parameter("D1@Profil godet")

        infosGodDI.TextBoxAngDos.Text = Math.Round(tabCodeGodet(6) * 180 / PI)

        If angDos <> "" Then 'dans le cas ou on a récupéré les infos du document excel

            infosGodDI.Frame1.Visible = True

            infosGodDI.AngDosReco.Text = angDos

        End If

        infosGodDI.TextBoxAngPos.Text = Math.Round(tabCodeGodet(5) * 180 / PI)

        If angPos <> "" Then 'dans le cas ou on a récupéré les infos du document excel

            infosGodDI.Frame1.Visible = True

            infosGodDI.AngPosReco.Text = angPos

        End If

        infosGodDI.ComboBoxFlanc.Text = tabCodeGodet(7)
        infosGodDI.ComboBoxLargeur.Text = CDbl(tabCodeGodet(1) * 1000)
        infosGodDI.CheckBoxCaisson.Checked = Not CBool(tabCodeGodet(18))
        infosGodDI.CheckBoxDeflecteur.Checked = Not CBool(tabCodeGodet(10))
        infosGodDI.TextBoxVolume.Text = getVolume()

        'vérifie si c'est un DI 201 ou 211L grâce au paramètre 26
        classe = IIf(tabCodeGodet(26) = 225 / 1000, "201", "211L")
        infosGodDI.ComboBoxClasse.Text = classe
        infosGodDI.ShowDialog()

        If infosGodDI.Annuler Then Exit Sub

        tabCodeGodet(1) = infosGodDI.largeur / 1000
        tabCodeGodet(2) = CStr(infosGodDI.largeur)
        tabCodeGodet(3) = infosGodDI.entraxeButee / 1000

        If infosGodDI.deflecteur Then
            stringTampon = " déflecteur"
        ElseIf Not infosGodDI.caissonRallonge Then
            stringTampon = " SR"
        Else
            stringTampon = ""
        End If

        flanc = infosGodDI.flanc

        tabCodeGodet(7) = flanc
        tabCodeGodet(8) = flanc + stringTampon
        tabCodeGodet(9) = flanc

        If infosGodDI.deflecteur Then
            stringTampon = "Déflecteur"
        Else
            stringTampon = "Défaut"
        End If
        tabCodeGodet(13) = stringTampon
        tabCodeGodet(10) = Not infosGodDI.deflecteur
        tabCodeGodet(11) = Not infosGodDI.deflecteur
        tabCodeGodet(12) = Not infosGodDI.deflecteur

        If infosGodDI.caisson Then
            stringTampon = "Caisson balancier"
        Else
            stringTampon = "Défaut"
        End If
        tabCodeGodet(14) = stringTampon
        tabCodeGodet(15) = stringTampon
        tabCodeGodet(16) = stringTampon
        tabCodeGodet(17) = stringTampon
        tabCodeGodet(18) = Not infosGodDI.caisson
        tabCodeGodet(19) = Not infosGodDI.caisson
        tabCodeGodet(20) = Not infosGodDI.caisson
        tabCodeGodet(28) = Not infosGodDI.caisson

        If infosGodDI.caissonRallonge Then

            stringTampon = "Défaut"

        Else

            stringTampon = "Sans retour"

        End If

        tabCodeGodet(22) = stringTampon
        tabCodeGodet(23) = stringTampon

        If infosGodDI.classe = "201" Then

            classe = "201"
            tabCodeGodet(24) = 879 / 1000
            tabCodeGodet(25) = 1229 / 1000
            tabCodeGodet(26) = 225 / 1000
            tabCodeGodet(27) = 50 * PI / 180

        Else

            classe = "211L"
            tabCodeGodet(24) = 1079 / 1000
            tabCodeGodet(25) = 1629 / 1000
            tabCodeGodet(26) = 325 / 1000
            tabCodeGodet(27) = 47.5 * PI / 180

        End If

        volume = infosGodDI.volume

        tabCodeGodet(5) = infosGodDI.angPos * PI / 180
        tabCodeGodet(6) = infosGodDI.angDos * PI / 180

        longueur = ReplaceRoundLg(tabCodeGodet(1) * 1000)

        'Call Coller(typesGodet, Join((tabCodeGodet), ";"))

        'Change la description de la caisse du godet pour qu'elle corresponde aux valeurs données en entrée
        Call addCustInfoToAllConfig(swModelDoc, "Description", "Caisse DI " & infosGodDI.classe & " " & volume & "L x " & longueur & "mm")

        tabTamp = Split(swModelDoc.GetPathName, "\")

        Call addCustInfoToAllConfig(swModelDoc, "Numéro", Split(tabTamp(Utils.DimTableau(tabTamp)), ".")(0))

        boolStatut = CopieInfos.setVolume(swDim, volume)

    End Sub

    Sub FullParamGodet(swApp As SldWorks, typesGodet As Object, swModelDoc As ModelDoc2) 'configuré seulement pour le DI201

        Dim swAssModelDoc As AssemblyDoc
        Dim swComponents() As Object
        Dim swComponent As Component2
        Dim swFirstModelDoc As ModelDoc2
        Dim swModelDocTamp As ModelDoc2
        Dim swModelDocCaisse As ModelDoc2
        Dim swCustomPropMng As CustomPropertyManager
        Dim swComponentChassis As Component2
        Dim swComponentTuyauterie As Component2
        Dim swComponentTuyauterieBlocEqui As Component2
        Dim swComponentAttaches As Component2
        Dim swComponentGraiTrad As Component2
        Dim swComponentGraiTwin As Component2
        Dim swComponentVerin As Component2
        Dim swDimension As Dimension

        Dim vComponent As Object
        Dim vInfosAttache As Object

        Dim customProp As String
        Dim customPropNb As String
        Dim activeChassisConfig As String
        Dim oldChassisLg As String
        Dim planAttache As String
        Dim Marque As String
        Dim modele As String
        Dim version As String
        Dim attacheDirect As Boolean
        Dim hauteurTransport As String
        Dim angleTransport As String
        Dim hauteurCaveeHaute As String

        'récupère les différents assemblage avec les mots corespondants en début de description

        swAssModelDoc = swModelDoc

        swComponents = swAssModelDoc.GetComponents(True)

        For Each vComponent In swComponents

            swComponent = vComponent
            swModelDocTamp = swComponent.GetModelDoc2

            If swModelDocTamp IsNot Nothing Then



                swCustomPropMng = swModelDocTamp.Extension.CustomPropertyManager(swModelDocTamp.ConfigurationManager.ActiveConfiguration.Name)

                swCustomPropMng.Get6("Description", False, "", customProp, False, False)
                swCustomPropMng.Get6("Numéro", False, "", customPropNb, False, False)

                If Left(customProp, 6) = "Caisse" Then

                    swModelDocCaisse = swModelDocTamp

                ElseIf Left(customProp, 7) = "Châssis" Then

                    swComponentChassis = swComponent

                ElseIf Left(customProp, 7) = "Crosses" Or Left(customProp, 3) = "Att" Then

                    swComponentAttaches = swComponent

                ElseIf Left(customProp, 5) = "Vérin" Then

                    'Si le vérin n'est pas une répétition linéaire de composant
                    'afin de prendre le vérin maitre et changer les deux vérins d'un coup
                    If swComponent.IsPatternInstance = False Then

                        swComponentVerin = swComponent

                    End If

                End If

            End If

            'On récupère les deux graissages et les deux tuyauteries grâce à leur nom pour plus tard

            If swComponent.Name2 = "TRAD-1" Then

                swComponentGraiTrad = swComponent

            ElseIf swComponent.Name2 = "TWIN-1" Then

                swComponentGraiTwin = swComponent

            ElseIf swComponent.Name2 = "GC TU 186-1" Then

                swComponentTuyauterie = swComponent

            ElseIf swComponent.Name2 = "GC TU 187-1" Then

                swComponentTuyauterieBlocEqui = swComponent

            End If

        Next vComponent

        swFirstModelDoc = swModelDoc
        swModelDoc = swModelDocCaisse

        'récupération d'informations sur les machines
        vInfosAttache = Split(GetAttachesInfos.recupInfosMachineChoisi, "\")

        angDos = ""
        angPos = ""

        If UBound(vInfosAttache) = 9 Then

            angDos = vInfosAttache(0)
            angPos = vInfosAttache(1)
            planAttache = vInfosAttache(2)
            Marque = vInfosAttache(3)
            modele = vInfosAttache(4)
            version = vInfosAttache(5)
            attacheDirect = vInfosAttache(6)
            hauteurTransport = vInfosAttache(7)
            angleTransport = vInfosAttache(8)
            hauteurCaveeHaute = vInfosAttache(9)

        End If

        Call ParamGodet(typesGodet, swModelDoc)

        'on s'occupe de mettre le bon châssis et le bon vérin en fonction de la classe du godet

        If classe = "201" Then
            boolStatut = swComponentChassis.Select4(False, Nothing, False)
            boolStatut = swAssModelDoc.ReplaceComponents2("C:\_IEV\03-STANDARDS\IEV\GC EN 2210\GC EN 2210.SLDASM", "", False, 0, True)
            boolStatut = swComponentVerin.Select4(False, Nothing, False)
            boolStatut = swAssModelDoc.ReplaceComponents2("C:\_IEV\03-STANDARDS\IEV\GC VE 48\GC VE 48.SLDASM", "", False, 0, True)

        Else

            boolStatut = swComponentChassis.Select4(False, Nothing, False)
            boolStatut = swAssModelDoc.ReplaceComponents2("C:\_IEV\03-STANDARDS\IEV\GC EN 2212\GC EN 2212.SLDASM", "", False, 0, True)
            boolStatut = swComponentVerin.Select4(False, Nothing, False)
            boolStatut = swAssModelDoc.ReplaceComponents2("C:\_IEV\03-STANDARDS\IEV\GC VE 49\GC VE 49.SLDASM", "", False, 0, True)

        End If

        'Après avoir paramètré la caisse, on s'occupe de la configuration du châssis
        activeChassisConfig = swComponentChassis.ReferencedConfiguration
        oldChassisLg = Mid(activeChassisConfig, 5, 4)
        swComponentChassis.ReferencedConfiguration = Replace(activeChassisConfig, oldChassisLg, longueur)

        'On remplace l'attache si il y a un plan d'attache correspondant
        If planAttache <> "" And Not swComponentAttaches Is Nothing Then

            boolStatut = swComponentAttaches.Select4(False, Nothing, False)

            boolStatut = swAssModelDoc.ReplaceComponents2("C:\_IEV\03-STANDARDS\IEV\" + planAttache + "\" + planAttache + ".SLDASM", "", False, 0, True)

        End If

        'Si attaches rapides et autre que liebherr
        If Not attacheDirect And Marque <> "Liebherr" Then

            boolStatut = swComponentAttaches.Select4(False, Nothing, False)

            boolStatut = swAssModelDoc.ReplaceComponents2("C:\_IEV\03-STANDARDS\IEV\GC EN 2625\GC EN 2625.SLDASM", "", False, 0, True)

            'Si attaches rapides et donc Liebherr
        ElseIf Not attacheDirect Then

            boolStatut = swComponentAttaches.Select4(False, Nothing, False)

            boolStatut = swAssModelDoc.ReplaceComponents2("C:\_IEV\03-STANDARDS\IEV\GC EN 3184\GC EN 3184.SLDASM", "", False, 0, True)

        End If

        'On met les infos d'angles , de cavage et de transport

        If hauteurTransport <> "-" Then

            swDimension = swFirstModelDoc.Parameter("D2@Transport")

            swDimension.Value = hauteurTransport

        Else

            MsgBox("Vérifier hauteurTransport sur l'esquisse")

        End If

        If angPos <> "" Then

            swDimension = swFirstModelDoc.Parameter("D2@Cavée haute")

            swDimension.Value = angPos

        Else

            MsgBox("Vérifier angPos/angle transport sur l'esquisse")

        End If

        If hauteurCaveeHaute <> "-" Then

            swDimension = swFirstModelDoc.Parameter("D1@Cavée haute")

            swDimension.Value = hauteurCaveeHaute

        Else

            MsgBox("Vérifier hauteurCaveeHaute sur l'esquisse")

        End If

        If angleTransport <> "-" Then

            swDimension = swFirstModelDoc.Parameter("D1@Transport")

            swDimension.Value = angleTransport

        Else

            MsgBox("Vérifier angleCaveeHaute sur l'esquisse")

        End If

        swFirstModelDoc.EditRebuild3()

        'On fait les différentes vues pour cavée haute et transport
        Call MakeViews(swApp, angleTransport, angPos)

        'Demande si on veut mettre un graissage centralisé et de quel type / demande bloc equi
        Dim ChoixGraissageBlocEqui As New ChoixGraissageBlocEqui

        ChoixGraissageBlocEqui.ShowDialog()


        'graissange centralisé
        If ChoixGraissageBlocEqui.CheckedListBox1.SelectedIndex = 1 Then

            swComponentGraiTwin.SetSuppression2(0)
            swComponentGraiTrad.SetSuppression2(2)

        ElseIf ChoixGraissageBlocEqui.CheckedListBox1.SelectedIndex = 2 Then

            swComponentGraiTwin.SetSuppression2(2)
            swComponentGraiTrad.SetSuppression2(0)

        Else

            swComponentGraiTwin.SetSuppression2(0)
            swComponentGraiTrad.SetSuppression2(0)

        End If

        'bloc equi et config tuyauterie

        If ChoixGraissageBlocEqui.BlocEqui.Checked Then

            swComponentTuyauterie.SetSuppression2(0)
            swComponentTuyauterieBlocEqui.SetSuppression2(2)
            swComponentTuyauterieBlocEqui.ReferencedConfiguration = longueur & " - " & classe

        Else

            swComponentTuyauterie.SetSuppression2(2)
            swComponentTuyauterieBlocEqui.SetSuppression2(0)
            swComponentTuyauterie.ReferencedConfiguration = longueur & " - " & classe

        End If




        'On remplit les informations des propriétés de fichier
        Call addCustInfoToAllConfig(swFirstModelDoc, "VOLUME_GC", volume)
        Call addCustInfoToAllConfig(swFirstModelDoc, "LARGEUR_GC", longueur)

        Select Case flanc
            Case "Bombés"
                flanc = "Bords Bombés"
            Case "Droits"
                flanc = "Flancs Droits"
            Case "Creux"
                flanc = "Flancs Creux"
        End Select

        Call addCustInfoToAllConfig(swFirstModelDoc, "FLANCS_GC", flanc)

        Call addCustInfoToAllConfig(swFirstModelDoc, "MARQUE_MACHINE", Marque)
        Call addCustInfoToAllConfig(swFirstModelDoc, "MODELE_MACHINE", modele)
        Call addCustInfoToAllConfig(swFirstModelDoc, "VERSION_MACHINE", version)

        If attacheDirect Then

            Call addCustInfoToAllConfig(swFirstModelDoc, "ATTACHES_GC", "Attaches Directes")

        Else

            Call addCustInfoToAllConfig(swFirstModelDoc, "ATTACHES_GC", "Attaches Rapides Volvo")

        End If

        Call addCustInfoToAllConfig(swFirstModelDoc, "CLASSE_GC", classe)


    End Sub

    Function ReplaceRoundLg(elmtToReplace As String) As String ' taille modifié pour DI201

        Dim RealLg As Object
        Dim configNameLg As Object
        Dim i As Integer

        'Normalement fait pour remplacer plusieurs elmt de RealLg et par configNameLg
        RealLg = {"2696"}
        configNameLg = {"2700"}

        For i = 0 To UBound(RealLg)

            If elmtToReplace = RealLg(i) Then

                Return configNameLg(i)

                Exit Function

            End If

        Next i

        Return elmtToReplace

    End Function

    Sub addCustInfoToAllConfig(ModelDoc As ModelDoc2, ByVal FieldName As String, ByVal FieldValue As String)

        Dim configs() As String
        Dim config As Object

        configs = ModelDoc.GetConfigurationNames

        ModelDoc.Extension.CustomPropertyManager("").Set2(FieldName, FieldValue)

        For Each config In configs

            ModelDoc.Extension.CustomPropertyManager(config).Set2(FieldName, FieldValue)

        Next

    End Sub

End Module