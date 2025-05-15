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

        If configType = "Godet GHD 150" Then

            Call StartFullBucketDI("150")

        ElseIf configType = "Godet GHD 200" Then

            Call StartFullBucketDI("200")

        ElseIf configType = "Caisse godet GHD 150" Then

            Call StartOnlyBucketDI("150")

        ElseIf configType = "Caisse godet GHD 200" Then

            Call StartOnlyBucketDI("200")

        ElseIf configType = "Godet HD" Then

            Call StartFullBucketHD()

        Else

            ErrorsHandling.AddError("Ce godet n'est pas un godet pour le configurateur / ou de l'ancienne version")

        End If

        _swModelDoc.EditRebuild3()

    End Sub

    Private Sub StartOnlyBucketDI(bucketClass As String)

        Dim caisse As New CaisseDI(_swModelDoc, _swModelDoc.Parameter("D1@Profil godet"), If(bucketClass = "150", New Generic.List(Of Classe) From {ClassesDIData.GetClasseByName("151"), ClassesDIData.GetClasseByName("160L")}, New Generic.List(Of Classe) From {ClassesDIData.GetClasseByName("201"), ClassesDIData.GetClasseByName("211L")}))

        caisse.SetBucket()

    End Sub

    Private Sub StartFullBucketDI(bucketClass As String)

        Dim godetDI As New GodetDI(_swApp, bucketClass)

        godetDI.ChangeEquipment()

    End Sub

    Private Sub StartFullBucketHD()

        Dim godetHD As New GodetHD(_swApp)

        godetHD.ChangeEquipment()

    End Sub

End Class