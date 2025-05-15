Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst

Public Class GodetDI
    Inherits Equipment

    Private _caisse As CaisseDI
    Private _swComponentChassis As Component2
    Private _swComponentAttaches As Component2

    Private _swComponentVerin As Component2
    Private _swComponentGraiTrad As Component2
    Private _swComponentGraiTwin As Component2
    Private _swComponentTuyauterie As Component2
    Private _swComponentTuyauterieBlocEqui As Component2

    Private _planAtt As String
    Private _marqueAtt As String
    Private _modeleAtt As String
    Private _versionAtt As String
    Private _attDirect As String
    Private _transportHeigth As String
    Private _transportAngle As String
    Private _caveeHauteHeigth As String
    Private _graissage As String
    Private _blocEqui As Boolean
    Private _classe As String


    Public Sub New(swApp As SldWorks, bucketClass As String)

        MyBase.New(swApp)

        _classe = bucketClass


        If _swModelDoc IsNot Nothing Then
            InitializeComponents(_swModelDoc.GetComponents(True))
        End If


    End Sub

    Public Sub ChangeEquipment()

        Dim infosAttache As New AttachesInfosTuyauGraissage()

        If _caisse Is Nothing Then

            ErrorsHandling.AddError("Caisson non présente dans l'assemblage")
            Exit Sub

        End If

        _caisse.SetRecommandAngles(ConvertToNumb(infosAttache.GetSelectColumn(17)), ConvertToNumb(infosAttache.GetSelectColumn(18)))

        _marqueAtt = infosAttache.GetSelectColumn(1)
        _modeleAtt = infosAttache.GetSelectColumn(2)
        _versionAtt = infosAttache.GetSelectColumn(3)
        _attDirect = infosAttache.GetAttDirect
        _transportHeigth = infosAttache.GetSelectColumn(23)
        _transportAngle = infosAttache.GetSelectColumn(22)
        _caveeHauteHeigth = infosAttache.GetSelectColumn(21)
        _graissage = infosAttache.GetGraissage
        _blocEqui = infosAttache.GetBlocEqui

        _planAtt = If(_attDirect, infosAttache.GetSelectColumn(19), If(_marqueAtt = "Liebherr", If(_classe = "150", "GC EN 3003", "GC EN 3184"), If(_classe = "150", "GC EN 2622", "GC EN 2625")))

        _caisse.SetBucket()

        ChangeChassis()

        ChangeConfigChassis()

        If _swComponentAttaches IsNot Nothing And Not _planAtt = "" Then ChangeAttache()

        ChangeTransportDims()

        MakeViews(_swApp, ConvertToNumb(_transportAngle), ConvertToNumb(_caisse.GetAngDos))

        ChangeCustInfos()

        ChangeGraissage()

        ChangeTuyau()

    End Sub

    Private Function InitializeComponents(comps As Object) As Boolean

        For Each swComponent As Component2 In comps

            Dim swModelDocTamp As ModelDoc2 = swComponent.GetModelDoc2

            If swModelDocTamp IsNot Nothing Then

                Dim swCustomPropMng As CustomPropertyManager = swModelDocTamp.Extension.CustomPropertyManager(swModelDocTamp.ConfigurationManager.ActiveConfiguration.Name)
                Dim customProp As String = ""


                swCustomPropMng.Get6("Description", False, "", customProp, False, False)

                If Left(customProp, 6) = "Caisse" Then

                    _caisse = New CaisseDI(swModelDocTamp, swModelDocTamp.Parameter("D1@Profil godet"), If(_classe = "150", New Generic.List(Of Classe) From {ClassesDIData.GetClasseByName("151"), ClassesDIData.GetClasseByName("160L")}, New Generic.List(Of Classe) From {ClassesDIData.GetClasseByName("201"), ClassesDIData.GetClasseByName("211L")}))

                ElseIf Left(customProp, 7) = "Châssis" Or Left(customProp, 7) = "Chassis" Or Left(customProp, 16) = "Ensemble Chassis" Then

                    _swComponentChassis = swComponent

                ElseIf Left(customProp, 7) = "Crosses" Or Left(customProp, 3) = "Att" Then

                    _swComponentAttaches = swComponent

                ElseIf Left(customProp, 5) = "Vérin" Then

                    'Si le vérin n'est pas une répétition linéaire de composant
                    'afin de prendre le vérin maitre et changer les deux vérins d'un coup
                    If swComponent.IsPatternInstance = False Then

                        _swComponentVerin = swComponent

                    End If

                End If

            End If

            'On récupère les deux graissages et les deux tuyauteries grâce à leur nom

            If swComponent.Name2 = "TRAD-1" Then

                _swComponentGraiTrad = swComponent

            ElseIf swComponent.Name2 = "TWIN-1" Then

                _swComponentGraiTwin = swComponent

            ElseIf swComponent.Name2 = "GC TU 186-1" Or swComponent.Name2 = "GC TU 185-1" Then

                _swComponentTuyauterie = swComponent

            ElseIf swComponent.Name2 = "GC TU 187-1" Or swComponent.Name2 = "GC TU 188-1" Then

                _swComponentTuyauterieBlocEqui = swComponent

            End If

        Next


        Return True

    End Function

    Private Sub ChangeChassis()

        If _caisse.GetClasseName = "201" Then

            ReplaceComp(_swComponentChassis, "C:\PDM\_IEV\03-STANDARDS\IEV\GC EN 2210\GC EN 2210.SLDASM")
            ReplaceComp(_swComponentVerin, "C:\PDM\_IEV\03-STANDARDS\IEV\GC VE 48\GC VE 48.SLDASM")

        ElseIf _caisse.GetClasseName = "211L" Then

            ReplaceComp(_swComponentChassis, "C:\PDM\_IEV\03-STANDARDS\IEV\GC EN 2212\GC EN 2212.SLDASM")
            ReplaceComp(_swComponentVerin, "C:\PDM\_IEV\03-STANDARDS\IEV\GC VE 49\GC VE 49.SLDASM")

        ElseIf _caisse.GetClasseName = "151" Then

            ReplaceComp(_swComponentChassis, "C:\PDM\_IEV\03-STANDARDS\IEV\GC EN 1035 Bis\GC EN 1035 Bis.SLDASM")
            ReplaceComp(_swComponentVerin, "C:\PDM\_IEV\03-STANDARDS\IEV\GC VE 52\GC VE 52.SLDASM")

        ElseIf _caisse.GetClasseName = "160L" Then

            ReplaceComp(_swComponentChassis, "C:\PDM\_IEV\03-STANDARDS\IEV\GC EN 1305\GC EN 1305.SLDASM")
            ReplaceComp(_swComponentVerin, "C:\PDM\_IEV\03-STANDARDS\IEV\GC VE 53\GC VE 53.SLDASM")

        End If

    End Sub

    Private Sub ChangeConfigChassis()

        Dim currentConfig As String = _swComponentChassis.ReferencedConfiguration

        _swComponentChassis.ReferencedConfiguration = Replace(currentConfig, Mid(currentConfig, 5, 4), _caisse.GetLength)

    End Sub

    Private Sub ChangeAttache()

        ReplaceComp(_swComponentAttaches, "C:\PDM\_IEV\03-STANDARDS\IEV\" + _planAtt + "\" + _planAtt + ".SLDASM")

    End Sub


    Private Sub ChangeTransportDims()

        If _transportHeigth <> "-" And _transportHeigth <> "" And _transportHeigth IsNot Nothing Then ChangeSketchDim(_swModelDoc, _transportHeigth, "D2@Transport")
        If _caisse.GetAngDos <> "-" And _caisse.GetAngDos <> "" And _caisse.GetAngDos IsNot Nothing Then ChangeSketchDim(_swModelDoc, _caisse.GetAngDos, "D2@Cavée haute")
        If _caveeHauteHeigth <> "-" And _caveeHauteHeigth <> "" And _caveeHauteHeigth IsNot Nothing Then ChangeSketchDim(_swModelDoc, _caveeHauteHeigth, "D1@Cavée haute")
        If _transportAngle <> "-" And _transportAngle <> "" And _transportAngle IsNot Nothing Then ChangeSketchDim(_swModelDoc, _transportAngle, "D1@Transport")

    End Sub


    Private Sub ChangeCustInfos()

        Dim flanc As String

        Call AddCustInfoToAllConfig(_swModelDoc, "VOLUME_GC", _caisse.GetVolume)
        Call AddCustInfoToAllConfig(_swModelDoc, "LARGEUR_GC", _caisse.GetLength)

        Select Case _caisse.GetFlanc
            Case "Bombés"
                flanc = "Bords Bombés"
            Case "Droits"
                flanc = "Flancs Droits"
            Case "Creux"
                flanc = "Flancs Creux"
            Case Else
                flanc = ""
        End Select

        Call AddCustInfoToAllConfig(_swModelDoc, "FLANCS_GC", flanc)

        Call AddCustInfoToAllConfig(_swModelDoc, "MARQUE_MACHINE", _marqueAtt)
        Call AddCustInfoToAllConfig(_swModelDoc, "MODELE_MACHINE", _modeleAtt)
        Call AddCustInfoToAllConfig(_swModelDoc, "VERSION_MACHINE", _versionAtt)

        If _attDirect Then

            Call AddCustInfoToAllConfig(_swModelDoc, "ATTACHES_GC", "Attaches Directes")

        Else

            Call AddCustInfoToAllConfig(_swModelDoc, "ATTACHES_GC", "Attaches Rapides Volvo")

        End If

        Call AddCustInfoToAllConfig(_swModelDoc, "CLASSE_GC", _caisse.GetClasseName)

    End Sub

    Private Sub ChangeTuyau()

        If _blocEqui Then

            _swComponentTuyauterie.SetSuppression2(0)
            _swComponentTuyauterieBlocEqui.SetSuppression2(2)
            _swComponentTuyauterieBlocEqui.ReferencedConfiguration = _caisse.GetLength & " - " & _caisse.GetClasseName

        Else

            _swComponentTuyauterie.SetSuppression2(2)
            _swComponentTuyauterieBlocEqui.SetSuppression2(0)
            _swComponentTuyauterie.ReferencedConfiguration = _caisse.GetLength & " - " & _caisse.GetClasseName

        End If

    End Sub

    Private Sub ChangeGraissage()

        If _graissage = "TRAD" Then

            _swComponentGraiTwin.SetSuppression2(0)
            _swComponentGraiTrad.SetSuppression2(2)

        ElseIf _graissage = "TWIN" Then

            _swComponentGraiTwin.SetSuppression2(2)
            _swComponentGraiTrad.SetSuppression2(0)

        Else

            _swComponentGraiTwin.SetSuppression2(0)
            _swComponentGraiTrad.SetSuppression2(0)

        End If

    End Sub

End Class
