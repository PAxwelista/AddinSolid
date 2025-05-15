Imports SolidWorks.Interop.sldworks
Imports System.Linq
Imports System.Collections.Generic
Public Class CaisseHD
    Inherits Caisse
    Private ReadOnly _infosGodDI As New InfosGodetsDI

    Private _caissonRal As Boolean


    Public Sub New(swModelDoc As ModelDoc2, swDimension As Dimension, possibleClasse As List(Of Classe))
        MyBase.New(swModelDoc, swDimension, possibleClasse)
    End Sub

    Protected Overrides Function AskUserForDim() As Boolean

        _infosGodDI.CheckBoxCR.Visible = False ' caché l'option caisson rallongé pour ce type de godet

        _infosGodDI.ComboBoxClasse.Text = If(_classe IsNot Nothing, _classe.GetName, "")

        For Each classe In _possibleClasse

            _infosGodDI.ComboBoxClasse.Items.Add(classe.GetName)

        Next classe

        _infosGodDI.ComboBoxLargeur.Text = _length

        _infosGodDI.CheckBoxDeflecteur.Checked = _deflecteur

        _infosGodDI.CheckBoxCaisson.Checked = _caisson

        _infosGodDI.ComboBoxFlanc.Text = _flanc

        _infosGodDI.TextBoxVolume.Text = If(_volume IsNot Nothing, _volume.GetLitre, Nothing)

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

        If _infosGodDI.Annuler = True Then Return False

        _classe = _possibleClasse.FirstOrDefault(Function(e) e.GetName = _infosGodDI.ComboBoxClasse.Text)
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

    Protected Overrides Sub ChangeCode()


        _tabCode(1) = _infosGodDI.largeur
        _tabCode(2) = CStr(_infosGodDI.largeur)

        _tabCode(4) = _angPos
        _tabCode(5) = _angDos


        _tabCode(6) = _flanc
        _tabCode(7) = _flanc
        _tabCode(8) = _flanc
        _tabCode(9) = "Gauche " + _flanc.ToLower()
        _tabCode(10) = _flanc

        _tabCode(11) = _deflecteur
        _tabCode(12) = _deflecteur
        _tabCode(13) = _deflecteur
        _tabCode(14) = _deflecteur

        'Rajouter les épaisseurs des éléments
        _tabCode(16) = 10
        _tabCode(17) = 12
        _tabCode(18) = 30
        _tabCode(19) = 25
        _tabCode(20) = 10
        _tabCode(21) = 10

        'Infos de rayon et de poutres
        _tabCode(22) = 400
        _tabCode(23) = 110
        _tabCode(24) = 150

    End Sub

    Protected Overrides Sub PasteCode()

        MyBase.PasteCode()

        Call AddCustInfoToAllConfig(_swModelDoc, "Description", "Caisse HD " & If(_classe Is Nothing, "", _classe.GetName) & " " & _volumeL & "L x " & _length & "mm")

    End Sub


    Protected Overrides Function GetBucketDim() As Boolean

        If Not MyBase.GetBucketDim() Then Return False

        _classe = _possibleClasse(0)

        _caissonRal = False

        _length = _tabCode(1)

        _deflecteur = CBool(_tabCode(11))

        _flanc = _tabCode(6)

        _volume = New Volume(SearchModelDocByProp(_swModelDoc, "Description", "Volume"))

        _angDos = _tabCode(5)

        _angPos = _tabCode(4)

        Return True

    End Function

End Class