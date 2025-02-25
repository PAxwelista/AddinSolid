
Public Class EquipmentCode

    Private ReadOnly _type As String

    Private ReadOnly _codes() As Tuple(Of Integer, String)

    Public Sub New(type As String, codes As Tuple(Of Integer, String)())


        _type = type
        _codes = codes

    End Sub

    Public Function GetCode() As Tuple(Of Integer, String)()

        Return _codes

    End Function

    Public Function GetEquipmentType() As String

        Return _type

    End Function

    Public Function GetStringCode() As String
        Dim fullCode As String = _type

        For Each code As Tuple(Of Integer, String) In _codes

            fullCode += ";" & code.Item1 & "\" & code.Item2

        Next

        Return fullCode

    End Function


End Class
