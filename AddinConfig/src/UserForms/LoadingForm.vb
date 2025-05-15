
Imports System.Windows.Forms

Public Class LoadingForm

    Public Annuler As Boolean = False

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        Me.KeyPreview = True

    End Sub



    Private Sub CancelBtn_Click_1(sender As Object, e As EventArgs) 

        Annuler = True

    End Sub

    Private Sub LoadingForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        Debug.Print("bam")

    End Sub

    Private Sub LoadingForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Debug.Print("bam2")

    End Sub

    Private Sub LoadingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class