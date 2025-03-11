Imports SolidWorks.Interop.sldworks
Imports System.Linq
Imports System.Collections.Generic
Public Class CaisseDI
    Inherits Caisse
    Private ReadOnly _infosGodDI As New InfosGodetsDI

    Private _caissonRal As Boolean


    Public Sub New(swModelDoc As ModelDoc2, swDimension As Dimension, possibleClasse As List(Of Classe))
        MyBase.New(swModelDoc, swDimension, possibleClasse)
    End Sub

    Protected Overrides Sub AskUserForDim()

        _infosGodDI.ComboBoxClasse.Text = If(_classe IsNot Nothing, _classe.GetName, "")

        For Each classe In _possibleClasse

            _infosGodDI.ComboBoxClasse.Items.Add(classe.getName)

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

        _classe = _possibleClasse.FirstOrDefault(Function(e) e.getName = _infosGodDI.ComboBoxClasse.Text)
        _length = ReplaceRoundLg(_infosGodDI.largeur, {"2696"}, {"2700"})
        _deflecteur = _infosGodDI.deflecteur
        _caisson = _infosGodDI.caisson
        _flanc = _infosGodDI.flanc
        _volumeL = _infosGodDI.volume
        _angDos = _infosGodDI.angDos
        _angPos = _infosGodDI.angPos
        _caissonRal = _infosGodDI.caissonRallonge

    End Sub

    Protected Overrides Sub ChangeCode()


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


        _tabCode(24) = _classe.getCylinderIn
        _tabCode(25) = _classe.getCylinderOut
        _tabCode(26) = _classe.getHolesCenterDist
        _tabCode(27) = _classe.getAngle


        _tabCode(5) = _angPos * Math.PI / 180
        _tabCode(6) = _angDos * Math.PI / 180

    End Sub

    Protected Overrides Sub PasteCode()

        MyBase.PasteCode()

        Call AddCustInfoToAllConfig(_swModelDoc, "Description", "Caisse DI " & _classe.getName & " " & _volumeL & "L x " & _length & "mm")

    End Sub


    Protected Overrides Function GetBucketDim() As Boolean

        If Not MyBase.GetBucketDim() Then Return False

        _classe = _possibleClasse.FirstOrDefault(Function(e) e.getHolesCenterDist = ConvertToNumb(_tabCode(26)))
        _caissonRal = False

        Return True

    End Function

End Class
