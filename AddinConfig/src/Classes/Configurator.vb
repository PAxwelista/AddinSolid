Imports SolidWorks.Interop.sldworks

Public Class Configurator

    Private _swModelDoc As ModelDoc2

    Public Sub New(swModelDoc As ModelDoc2)

        _swModelDoc = swModelDoc

    End Sub

    Public Function StartConfig() As Boolean


        MsgBox("we are here")

        'Dim FenetreAccueil As New FenetreAccueil

        'Dim codeGodet As String

        'Dim typesGodet As String()
        'typesGodet = {"test, CodeDI_201"}




        'Si c'est un godet entier on ouvre la caisse pour pouvoir lancer les paramètres
        'nameGodet = Split(_swModelDoc.GetTitle, ".")(0) 'Récupére sans l'extension
        'If Left(nameGodet, 2) = "GC" And (Len(nameGodet) = 7 Or Len(nameGodet) = 13) Then 'normalement mettre 14 pour la version finale et 20 pour le godet master

        ' Call FullParamGodet(swApp, typesGodet, swModelDoc)

        ' Else

        'Call ParamGodet.ParamGodet(typesGodet, swModelDoc)

        'End If

    End Function





End Class
