Imports SolidWorks.Interop.sldworks


Public Class Equipment

    Protected _swApp As SldWorks
    Protected _swModelDoc As ModelDoc2

    Public Sub New(swApp As SldWorks)

        _swApp = swApp
        _swModelDoc = _swApp.ActiveDoc

        Call AddCustInfoToAllConfig(_swModelDoc, "Numéro", GetNumber)

    End Sub
    Protected Function ReplaceComp(swComp As Component2, path As String) As Boolean

        If swComp Is Nothing Then Return False

        swComp.Select4(False, Nothing, False)
        Return _swModelDoc.ReplaceComponents2(path, "", False, 0, True)

    End Function

    Private Function GetNumber() As String

        Dim bufferTab As String() = Split(_swModelDoc.GetPathName, "\")

        Return Split(bufferTab(Utils.DimTableau(bufferTab)), ".")(0)

    End Function

End Class
