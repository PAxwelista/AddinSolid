Imports SolidWorks.Interop.sldworks
Imports System.Linq
Imports System.Collections.Generic
Public Class CaisseDI
    Inherits Caisse
    Private _infosGodDI As InfosGodetsDI
    Private ReadOnly lengthDI150 As String() = {"2000", "2170", "2300", "2350", "2400", "2500", "2550", "2600", "2650", "v", "2750", "2900", "3000", "3100"}
    Private ReadOnly lengthDI200 As String() = {"2400", "2500", "2600", "2650", "2696", "2750", "2800", "2900", "3000", "3100", "3200", "3300", "3400", "3500"}

    Private _caissonRal As Boolean


    Public Sub New(swModelDoc As ModelDoc2, swDimension As Dimension, possibleClasse As List(Of Classe))
        MyBase.New(swModelDoc, swDimension, possibleClasse)
    End Sub

    Protected Overrides Function AskUserForDim() As Boolean

        _infosGodDI = New InfosGodetsDI(If(_classe.GetName = "151" Or _classe.GetName = "160L", lengthDI150, lengthDI200))

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
        _tabCode(3) = GetCenterAxisRubberStop(_length)


        _tabCode(7) = _flanc
        _tabCode(8) = _flanc + If(_deflecteur, " déflecteur", "") + If(_caissonRal, "", " SR")
        _tabCode(9) = _flanc

        _tabCode(13) = If(_deflecteur, "Déflecteur", "Défaut")
        _tabCode(10) = _deflecteur
        _tabCode(11) = _deflecteur
        _tabCode(12) = _deflecteur

        _tabCode(14) = If(_caisson, "Caisson balancier", "Défaut")
        _tabCode(15) = If(_caisson, "Caisson balancier", "Défaut")
        _tabCode(16) = If(_caisson, "Caisson balancier", "Défaut")
        _tabCode(17) = If(_caisson, "Caisson balancier", "Défaut")
        _tabCode(18) = _caisson
        _tabCode(19) = _caisson
        _tabCode(20) = _caisson
        _tabCode(28) = _caisson

        _tabCode(22) = If(_caissonRal, "Défaut", "Sans retour")
        _tabCode(23) = If(_caissonRal, "Défaut", "Sans retour")


        _tabCode(24) = _classe.getCylinderIn
        _tabCode(25) = _classe.getCylinderOut
        _tabCode(26) = _classe.getHolesCenterDist
        _tabCode(27) = _classe.GetAngle


        _tabCode(5) = _angPos
        _tabCode(6) = _angDos

    End Sub

    Protected Overrides Sub PasteCode()

        MyBase.PasteCode()

        Call AddCustInfoToAllConfig(_swModelDoc, "Description", "Caisse DI " & _classe.getName & " " & _volumeL & "L x " & _length & "mm")

    End Sub


    Protected Overrides Function GetBucketDim() As Boolean

        If Not MyBase.GetBucketDim() Then Return False

        _classe = _possibleClasse.FirstOrDefault(Function(e) e.getHolesCenterDist = ConvertToNumb(_tabCode(26)))
        _caissonRal = Right(_tabCode(8), 2) <> "SR"

        _length = CDbl(_tabCode(1))

        _deflecteur = CBool(_tabCode(10))

        _caisson = CBool(_tabCode(18))

        _flanc = _tabCode(7)

        _volume = New Volume(SearchModelDocByProp(_swModelDoc, "Description", "Volume"))

        _angDos = _tabCode(6)

        _angPos = _tabCode(5)

        Return True

    End Function

    Protected Function GetCenterAxisRubberStop(length As String) As String
        If _classe.GetName = "201" Or _classe.GetName = "211L" Then

            Select Case length

                Case "2400", "2500"

                    Return "1500"

                Case "2600", "2650", "2700", "2750", "2800", "2900"

                    Return "1700"

                Case "3000", "3100", "3200"

                    Return "2000"

                Case "3300", "3400", "3500"

                    Return "2300"

            End Select

        ElseIf _classe.GetName = "151" Or _classe.GetName = "160L" Then

            Select Case length

                Case "2000"

                    Return "1300"

                Case "2170"

                    Return "1500"

                Case "2300", "2350", "2400", "2500", "2550", "2600", "2650", "2700", "2750", "2900", "3000", "3100"

                    Return "1600"


            End Select

        End If

        Return ""

    End Function

End Class