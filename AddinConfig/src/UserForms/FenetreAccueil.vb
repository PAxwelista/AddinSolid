Public Class FenetreAccueil
    Public choix As String
    Private Sub Annuler_Click(sender As Object, e As EventArgs) Handles Annuler.Click
        choix = "Annuler"
        Hide()
    End Sub

    Private Sub Coller_Click(sender As Object, e As EventArgs) Handles Coller.Click
        choix = "Coller"
        Hide()
    End Sub

    Private Sub Copier_Click(sender As Object, e As EventArgs) Handles Copier.Click
        choix = "Copier"
        Hide()
    End Sub

    Private Sub GetPosition_Click(sender As Object, e As EventArgs) Handles GetPosition.Click
        choix = "GetPosition"
        Hide()
    End Sub

    Private Sub Paramètres_Click(sender As Object, e As EventArgs) Handles Paramètres.Click
        choix = "Paramètre"
        Hide()
    End Sub

End Class