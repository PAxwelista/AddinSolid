Imports SolidWorks.Interop.sldworks

Public Class Caisse

    Private ReadOnly _infosGodDI As New InfosGodetsDI

    Private ReadOnly _swModelDoc As ModelDoc2

    Private _classe As String
    Private _length As String
    Private _deflecteur As Boolean
    Private _caisson As Boolean
    Private _flanc As String
    Private _volume As Volume
    Private _volumeL As Integer
    Private _angDos As Integer
    Private _angPos As Integer
    Private _caissonRal As Boolean
    Private _angDosReco As Integer = 0
    Private _angPosReco As Integer = 0
    Private _tabCode As String()
    Private _swDim As Dimension

    Public Sub New(swModelDoc As ModelDoc2, swDimension As Dimension)

        _swModelDoc = swModelDoc

        _swDim = swDimension

        GetBucketDim()


    End Sub

    Public Function SetBucket() As Boolean

        AskUserForDim()

        PasteCode()

    End Function

    Public Sub SetRecommandAngles(angDosReco As Integer, angPosReco As Integer)

        _angDosReco = angDosReco

        _angPosReco = angPosReco


    End Sub

    Public Function GetClasse() As String

        Return _classe

    End Function

    Public Function GetLength() As String

        Return _length

    End Function
    Public Function GetAngDos() As String

        Return _angDos

    End Function
    Public Function GetFlanc() As String

        Return _flanc

    End Function

    Public Function GetVolume() As String

        Return _volumeL

    End Function

    Private Function AskUserForDim() As Boolean

        _infosGodDI.ComboBoxClasse.Text = _classe

        _infosGodDI.ComboBoxLargeur.Text = _length

        _infosGodDI.CheckBoxDeflecteur.Checked = _deflecteur

        _infosGodDI.CheckBoxCaisson.Checked = _caisson

        _infosGodDI.ComboBoxFlanc.Text = _flanc

        _infosGodDI.TextBoxVolume.Text = _volume.GetLitre

        _infosGodDI.TextBoxAngDos.Text = _angDos

        If _angDosReco <> 0 Then 'dans le cas ou on a récupéré les infos du document excel

            _infosGodDI.Frame1.Visible = True

            _infosGodDI.AngDosReco.Text = _angDosReco

        End If

        _infosGodDI.TextBoxAngPos.Text = _angPos

        If _angPosReco <> 0 Then 'dans le cas ou on a récupéré les infos du document excel

            _infosGodDI.Frame1.Visible = True

            _infosGodDI.AngPosReco.Text = _angPosReco

        End If

        _infosGodDI.CheckBoxCR.Checked = _caissonRal

        _infosGodDI.ShowDialog()

        _classe = _infosGodDI.classe
        _length = ReplaceRoundLg(_infosGodDI.largeur, {"2696"}, {"2700"})
        _deflecteur = _infosGodDI.deflecteur
        _caisson = _infosGodDI.caisson
        _flanc = _infosGodDI.flanc
        _volumeL = _infosGodDI.volume
        _angDos = _infosGodDI.angDos
        _angPos = _infosGodDI.angPos
        _caissonRal = _infosGodDI.caissonRallonge

        Return True

    End Function

    Private Function PasteCode() As Boolean

        Dim paste As New Paste(_swModelDoc)

        ChangeCode()

        paste.Paste(Join(_tabCode, ";"))

        _volume.SetVolume(_swDim, _volumeL, _swModelDoc)

        Call AddCustInfoToAllConfig(_swModelDoc, "Description", "Caisse DI " & _infosGodDI.classe & " " & _volumeL & "L x " & _length & "mm")

        Call AddCustInfoToAllConfig(_swModelDoc, "Numéro", GetNumber)

    End Function

    Private Function ChangeCode() As Boolean



        _tabCode(1) = _infosGodDI.largeur / 1000
        _tabCode(2) = CStr(_infosGodDI.largeur)
        _tabCode(3) = _infosGodDI.entraxeButee / 1000


        _tabCode(7) = _flanc
        _tabCode(8) = _flanc + If(_deflecteur, " déflecteur", If(_caissonRal, "", " SR"))
        _tabCode(9) = _flanc

        _tabCode(13) = If(_deflecteur, "Déflecteur", "Défaut")
        _tabCode(10) = Not _deflecteur
        _tabCode(11) = Not _deflecteur
        _tabCode(12) = Not _deflecteur

        _tabCode(14) = If(_caisson, "Caisson balancier", "Défaut")
        _tabCode(15) = If(_caisson, "Caisson balancier", "Défaut")
        _tabCode(16) = If(_caisson, "Caisson balancier", "Défaut")
        _tabCode(17) = If(_caisson, "Caisson balancier", "Défaut")
        _tabCode(18) = Not _caisson
        _tabCode(19) = Not _caisson
        _tabCode(20) = Not _caisson
        _tabCode(28) = Not _caisson

        _tabCode(22) = If(_caissonRal, "Défaut", "Sans retour")
        _tabCode(23) = If(_caissonRal, "Défaut", "Sans retour")


        If _classe = "201" Then

            _classe = "201"
            _tabCode(24) = 879 / 1000
            _tabCode(25) = 1229 / 1000
            _tabCode(26) = 225 / 1000
            _tabCode(27) = 50 * Math.PI / 180

        Else

            _classe = "211L"
            _tabCode(24) = 1079 / 1000
            _tabCode(25) = 1629 / 1000
            _tabCode(26) = 325 / 1000
            _tabCode(27) = 47.5 * Math.PI / 180

        End If

        _tabCode(5) = _angPos * Math.PI / 180
        _tabCode(6) = _angDos * Math.PI / 180

        Return True

    End Function



    Private Function GetBucketDim() As Boolean

        Dim copy As New Copy(_swModelDoc)

        _tabCode = copy.Copy.Split(";")

        If IsInArray(_tabCode, "-") Then

            ErrorsHandling.AddError("le code godet n'est pas bon, peut être lancer sur un mauvais godet")
            Return False

        End If

        _classe = IIf(_tabCode(26) = 225 / 1000, "201", "211L")

        _length = CDbl(_tabCode(1) * 1000)

        _deflecteur = Not CBool(_tabCode(10))

        _caisson = Not CBool(_tabCode(18))

        _flanc = _tabCode(7)

        _volume = New Volume(SearchModelDocByProp(_swModelDoc, "Description", "Volume"))

        _angDos = Math.Round(_tabCode(6) * 180 / Math.PI)

        _angPos = Math.Round(_tabCode(5) * 180 / Math.PI)

        _caissonRal = False

        Return True

    End Function


    Private Function GetNumber() As String

        Dim bufferTab As String() = Split(_swModelDoc.GetPathName, "\")

        Return Split(bufferTab(Utils.DimTableau(bufferTab)), ".")(0)

    End Function

End Class
