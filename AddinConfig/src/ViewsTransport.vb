Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Module ViewsTransport


    Sub MakeViews(swApp As SldWorks, paramAngleTransport As String, paramAngleCaveeHaute As String)


        Dim Part As ModelDoc2


        Part = swApp.ActiveDoc
        Dim iVW As ModelViewManager
        iVW = Part.ModelViewManager
        Dim boolstatus As Boolean
        Dim bTransport As Boolean
        Dim bCavée As Boolean

        Dim angleTransport As Double, angleCaveeHaute As Double, diff As Double
        Dim str As String

        Dim vModelViewNames As Object
        Dim vModelViewName As Object
        Dim FirstView As String
        Dim SecondView As String

        FirstView = "Transport"
        SecondView = "Cavée Haute"
        vModelViewNames = Part.GetModelViewNames

        'met la vue face pour initialiser correctement la macro
        Call Part.ShowNamedView2("", swStandardViews_e.swFrontView)

        For Each vModelViewName In vModelViewNames
            If InStr(1, vModelViewName, FirstView, 1) Then
                Part.DeleteNamedView(FirstView)
            ElseIf InStr(1, vModelViewName, SecondView, 1) Then
                Part.DeleteNamedView(SecondView)
            End If
        Next

        If paramAngleTransport <> vbNullString Then
            angleTransport = CDbl(paramAngleTransport)
            bTransport = True
        Else
            str = InputBox("Angle de transport ?")
            If str <> vbNullString Then
                angleTransport = CDbl(str)
                bTransport = True
            Else
                GoTo EndProg
            End If

        End If
        If angleTransport < 0 Or angleTransport > 360 Then
            MsgBox("la valeur doit être comprise entre 0 et 360")
            Exit Sub
        ElseIf angleTransport >= 0 And angleTransport <= 360 Then
            angleTransport = angleTransport * 3.14159265358 / 180
        Else
            MsgBox("Veuillez entrer un nombre entre 0 et 360")
        End If


        If paramAngleCaveeHaute <> vbNullString Then
            angleCaveeHaute = CDbl(paramAngleCaveeHaute)
            bCavée = True
        Else
            str = InputBox("Angle en position cavé haute?")
            If str <> vbNullString Then
                angleCaveeHaute = CDbl(str)
                bCavée = True
            Else
                GoTo EndProg
            End If
        End If
        If angleCaveeHaute < 0 Or angleCaveeHaute > 360 Then
            MsgBox("la valeur doit être comprise entre 0 et 360")
            Exit Sub
        ElseIf angleCaveeHaute >= 0 And angleCaveeHaute <= 360 Then
            angleCaveeHaute = angleCaveeHaute * 3.14159265358 / 180
        Else
            MsgBox("Veuillez entrer un nombre entre 0 et 360")
        End If

        diff = angleCaveeHaute - angleTransport


        Part.ViewRotYMinusNinety()
        boolstatus = swApp.SetUserPreferenceDoubleValue(swUserPreferenceDoubleValue_e.swViewRotationArrowKeys, angleTransport)
        'MsgBox boolstatus
        Part.ViewRotateplusx()
        Part.ViewRotYPlusNinety()
        Part.ViewZoomtofit2()

        'créer la vue Transport
        If bTransport = True Then Part.NameView(FirstView)

        If diff = 0 And bCavée = True Then
            Part.NameView(SecondView)
            GoTo InitialView
        End If

        'on tourne pour atteindre la position cavée
        boolstatus = swApp.SetUserPreferenceDoubleValue(swUserPreferenceDoubleValue_e.swViewRotationArrowKeys, diff)
        Part.ViewRotYMinusNinety()
        Part.ViewRotateplusx()
        Part.ViewRotYPlusNinety()
        Part.ViewZoomtofit2()

        'créer la vue Cavée Haute
        If bCavée = True Then Part.NameView(SecondView)

        'on revient à la position initiale
InitialView:
        boolstatus = swApp.SetUserPreferenceDoubleValue(swUserPreferenceDoubleValue_e.swViewRotationArrowKeys, angleCaveeHaute)
        Part.ViewRotYMinusNinety()
        Part.ViewRotateminusx()
        Part.ViewRotYPlusNinety()
        Part.ViewZoomtofit2()

EndProg:

    End Sub
End Module