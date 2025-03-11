Imports SolidWorks.Interop.sldworks
Imports System.Collections.Generic

Public MustInherit Class Caisse

    Protected ReadOnly _swModelDoc As ModelDoc2

    Protected _classe As Classe
    Protected _possibleClasse As New List(Of Classe)
    Protected _length As String
    Protected _deflecteur As Boolean
    Protected _caisson As Boolean
    Protected _flanc As String
    Protected _volume As Volume
    Protected _volumeL As Integer
    Protected _angDos As Integer
    Protected _angPos As Integer
    Protected _angDosReco As Integer = 0
    Protected _angPosReco As Integer = 0
    Protected _tabCode As String()
    Private _swEditableDim As Dimension

    Public Sub New(swModelDoc As ModelDoc2, swDimension As Dimension, possibleClasse As List(Of Classe))

        _swModelDoc = swModelDoc

        _swEditableDim = swDimension

        _possibleClasse = possibleClasse

        GetBucketDim()

    End Sub

    Public Function SetBucket() As Boolean

        AskUserForDim()

        PasteCode()

    End Function

    Public Sub SetRecommandAngles(angDosReco As Integer, angPosReco As Integer)

        _angDosReco = angDosReco

        _angPosReco = angPosReco


    End Sub

    Public Function GetClasseName() As String

        Return _classe.getName

    End Function

    Public Function GetLength() As String

        Return _length

    End Function
    Public Function GetAngDos() As String

        Return _angDos

    End Function
    Public Function GetFlanc() As String

        Return _flanc

    End Function

    Public Function GetVolume() As String

        Return _volumeL

    End Function

    Protected MustOverride Sub AskUserForDim()

    Protected Overridable Sub PasteCode()

        Dim paste As New Paste(_swModelDoc)

        ChangeCode()

        paste.Paste(Join(_tabCode, ";"))

        If _volume IsNot Nothing Then _volume.SetVolume(_swEditableDim, _volumeL, _swModelDoc)

        Call AddCustInfoToAllConfig(_swModelDoc, "Numéro", GetNumber)

    End Sub

    Protected MustOverride Sub ChangeCode()



    Protected Overridable Function GetBucketDim() As Boolean

        Dim copy As New Copy(_swModelDoc)

        _tabCode = copy.Copy.Split(";")

        If IsInArray(_tabCode, "-") Then

            ErrorsHandling.AddError("le code godet n'est pas bon, peut être il a été lancé sur un mauvais godet")
            Return False

        End If

        _length = CDbl(_tabCode(1) * 1000)

        _deflecteur = Not CBool(_tabCode(10))

        _caisson = Not CBool(_tabCode(18))

        _flanc = _tabCode(7)

        _volume = New Volume(SearchModelDocByProp(_swModelDoc, "Description", "Volume"))

        _angDos = Math.Round(_tabCode(6) * 180 / Math.PI)

        _angPos = Math.Round(_tabCode(5) * 180 / Math.PI)

        Return True

    End Function


    Private Function GetNumber() As String

        Dim bufferTab As String() = Split(_swModelDoc.GetPathName, "\")

        Return Split(bufferTab(Utils.DimTableau(bufferTab)), ".")(0)

    End Function

End Class
