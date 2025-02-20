Public Class ErrorsHandling

    Private Shared _errors() As String

    Public Shared Function AddError(err As String) As Boolean

        If _errors Is Nothing Then

            ReDim _errors(0)

        Else

            ReDim Preserve _errors(_errors.Length)

        End If

        _errors(_errors.Length - 1) = err

        Return True

    End Function
    Public Shared Function RemoveAllErrors() As Boolean

        _errors = {}

        Return True


    End Function

    Public Shared Function NbErrors() As Integer

        If _errors Is Nothing Then

            Return 0
            Exit Function

        End If

        Return _errors.Length

    End Function

    Public Shared Function ShowErrors() As String

        Dim errorMessage As String = ""

        If _errors Is Nothing Then

            Return "No errors"
            Exit Function

        End If

        For i As Integer = 0 To _errors.Length - 1

            errorMessage += "Error n°" & i + 1 & " : " & _errors(i) & vbLf

        Next i

        Return errorMessage


    End Function

    Public Shared Function GetError(index As Integer) As String

        If index < 0 Or index >= _errors.Length Then

            Return "No error at this index"
            Exit Function

        End If

        Return _errors(index)

    End Function



End Class
