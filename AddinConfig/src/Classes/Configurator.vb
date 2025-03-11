Imports SolidWorks.Interop.sldworks

Public Class Configurator

    Private ReadOnly _swApp As SldWorks
    Private ReadOnly _swModelDoc As ModelDoc

    Public Sub New(swApp As SldWorks)

        _swApp = swApp

        _swModelDoc = swApp.ActiveDoc

    End Sub

    Public Sub StartConfig()

        Dim configType As String = GetCustomProperty(_swModelDoc, "Type configurateur")

        If configType = "Godet GHD" Then

            Call StartFullBucket()

        ElseIf configType = "Caisse godet GHD 201" Then

            Call StartOnlyBucket()

        ElseIf configType = "Godet HD" Then

            MsgBox("in")

        Else


            ErrorsHandling.AddError("Ce godet n'est pas un godet pour le configurateur / ou de l'ancienne version")

        End If

        _swModelDoc.EditRebuild3()


    End Sub

    Private Sub StartOnlyBucket()

        Dim caisse As New CaisseDI(_swModelDoc, _swModelDoc.Parameter("D1@Profil godet"), New Generic.List(Of Classe) From {ClassesDIData.GetClasseByName("201"), ClassesDIData.GetClasseByName("211L")})

        caisse.SetBucket()

    End Sub

    Private Sub StartFullBucket()

        Dim godetDI As New DI(_swApp)

        godetDI.ChangeEquipment()

    End Sub


End Class
