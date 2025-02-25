Imports SolidWorks.Interop.sldworks

Public Class Configurator

    Private ReadOnly _swApp As SldWorks

    Public Sub New(swApp As SldWorks)

        _swApp = swApp

    End Sub

    Public Sub StartConfig()

        Dim nameGodet As String = Split(_swApp.ActiveDoc.GetTitle, ".")(0)

        If Left(nameGodet, 2) = "GC" And (Len(nameGodet) = 7 Or Len(nameGodet) = 13) Then


            Call StartFullBucket()

        Else

            Call StartOnlyBucket()

        End If

    End Sub

    Private Sub StartOnlyBucket()

        Dim caisse As New Caisse(_swApp.ActiveDoc, _swApp.ActiveDoc.Parameter("D1@Profil godet"))

        caisse.SetBucket()

    End Sub

    Private Sub StartFullBucket()

        Dim godetDI As New DI(_swApp)

        godetDI.ChangeEquipment()

    End Sub


End Class
