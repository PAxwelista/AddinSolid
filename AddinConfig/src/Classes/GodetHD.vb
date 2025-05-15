Imports SolidWorks.Interop.sldworks
Public Class GodetHD
    Inherits Equipment
    Private ReadOnly _attachesInfos As New AttachesInfosTuyauGraissage
    Private _caisse As CaisseHD
    Private _swComponentAttaches As Component2
    Public Sub New(swApp As SldWorks)

        MyBase.New(swApp)


        If _swModelDoc IsNot Nothing Then

            InitializeComponents(_swModelDoc.GetComponents(True))

        End If


    End Sub


    Public Sub ChangeEquipment()

        Dim Paste As New Paste(_swComponentAttaches.GetModelDoc2)

        Dim infosAttaches As String

        _caisse.SetRecommandAngles(ConvertToNumb(_attachesInfos.GetSelectColumn(17)), ConvertToNumb(_attachesInfos.GetSelectColumn(18)))

        infosAttaches = _attachesInfos.GetSelectColumnValues(25, 68)

        If IsInArray(infosAttaches.Split(";"), "") Then

            ErrorsHandling.AddError("La partie du fichier excel de cette machine ne doit pas être complète")
            Exit Sub

        End If

        _caisse.SetBucket()

        Paste.Paste("Attaches GP-HD-XHD;" & infosAttaches)

    End Sub

    Private Sub InitializeComponents(comps As Object)

        For Each swComponent As Component2 In comps

            Dim swModelDocTamp As ModelDoc2 = swComponent.GetModelDoc2

            If swModelDocTamp IsNot Nothing Then

                Dim swCustomPropMng As CustomPropertyManager = swModelDocTamp.Extension.CustomPropertyManager(swModelDocTamp.ConfigurationManager.ActiveConfiguration.Name)
                Dim customProp As String = ""


                swCustomPropMng.Get6("Description", False, "", customProp, False, False)

                If Left(customProp, 6) = "Caisse" Then

                    _caisse = New CaisseHD(swModelDocTamp, swModelDocTamp.Parameter("D2@Profil godet"), New Generic.List(Of Classe) From {ClassesDIData.GetClasseByName("150"), ClassesDIData.GetClasseByName("200")})

                ElseIf Left(customProp, 7) = "Crosses" Or Left(customProp, 3) = "Att" Then

                    _swComponentAttaches = swComponent

                End If

            End If

        Next

    End Sub

End Class
