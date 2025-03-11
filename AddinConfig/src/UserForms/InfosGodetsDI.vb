Public Class InfosGodetsDI
    Public largeur As Long
    Public flanc As String
    Public deflecteur As Boolean
    Public caisson As Boolean
    Public caissonRallonge As Boolean
    Public volume As Double
    Public angDos As Double
    Public angPos As Double
    Public entraxeButee As Double
    Public Annuler As Boolean
    Public classe As String

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Annuler = False

        With ComboBoxFlanc.Items

            .Add("Creux")
            .Add("Droits")
            .Add("Bombés")

        End With

        With ComboBoxLargeur.Items

            .Add("2400")
            .Add("2500")
            .Add("2600")
            .Add("2650")
            .Add("2696")
            .Add("2750")
            .Add("2800")
            .Add("2900")
            .Add("3000")
            .Add("3100")
            .Add("3200")
            .Add("3300")
            .Add("3400")
            .Add("3500")

        End With



    End Sub

    Private Sub CommandButton1_Click(sender As Object, e As EventArgs) Handles CommandButton1.Click
        Annuler = True
        Hide()
    End Sub

    Private Sub CommandButtonOK_Click(sender As Object, e As EventArgs) Handles CommandButtonOK.Click
        If ComboBoxLargeur.Text <> "" Then largeur = ComboBoxLargeur.Text
        flanc = ComboBoxFlanc.Text
        deflecteur = CheckBoxDeflecteur.Checked
        caisson = CheckBoxCaisson.Checked
        caissonRallonge = CheckBoxCR.Checked
        If IsNumeric(TextBoxVolume.Text) Then volume = TextBoxVolume.Text
        If IsNumeric(TextBoxAngDos.Text) Then angDos = TextBoxAngDos.Text
        If IsNumeric(TextBoxAngPos.Text) Then angPos = TextBoxAngPos.Text
        Select Case largeur
            Case "2400", "2500"
                entraxeButee = 1500
            Case "2600", "2650", "2696", "2750", "2800", "2900"
                entraxeButee = 1700
            Case "3000", "3100", "3200"
                entraxeButee = 2000
            Case "3300", "3400", "3500"
                entraxeButee = 2300
        End Select

        classe = ComboBoxClasse.Text

        Hide()
    End Sub


End Class