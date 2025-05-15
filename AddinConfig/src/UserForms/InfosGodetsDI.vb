Public Class InfosGodetsDI
    Public largeur As Long
    Public flanc As String
    Public deflecteur As Boolean
    Public caisson As Boolean
    Public caissonRallonge As Boolean
    Public volume As Double
    Public angDos As Double
    Public angPos As Double
    Public Annuler As Boolean
    Public classe As String

    Public Sub New(Optional possibleLength As String() = Nothing)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Annuler = False

        If possibleLength Is Nothing Then possibleLength = {"2400", "2500", "2600", "2650", "2696", "2750", "2800", "2900", "3000", "3100", "3200", "3300", "3400", "3500"}

        With ComboBoxFlanc.Items

            .Add("Creux")
            .Add("Droits")
            .Add("Bombés")

        End With

        ComboBoxLargeur.Items.AddRange(possibleLength)

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

        classe = ComboBoxClasse.Text

        Hide()
    End Sub


End Class