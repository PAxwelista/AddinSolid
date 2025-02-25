Imports SolidWorks.Interop.sldworks


Public Class Equipment

    Protected _swApp As SldWorks
    Protected _swModelDoc As ModelDoc2

    Public Sub New(swApp As SldWorks)

        _swApp = swApp
        _swModelDoc = _swApp.ActiveDoc

    End Sub
    Protected Function ReplaceComp(swComp As Component2, path As String) As Boolean

        swComp.Select4(False, Nothing, False)
        Return _swModelDoc.ReplaceComponents2(path, "", False, 0, True)

    End Function

End Class
