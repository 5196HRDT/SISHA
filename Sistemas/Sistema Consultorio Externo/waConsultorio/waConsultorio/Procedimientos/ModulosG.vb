Module ModulosG
    Public Function DameDiasMes(ByVal Mes As Integer) As Integer
        Select Case Mes
            Case 1
                Return 31
            Case 2
                If Date.Now.Year Mod 4 = 0 Then Return 29 Else Return 28
            Case 3
                Return 31
            Case 4
                Return 30
            Case 5
                Return 31
            Case 6
                Return 30
            Case 7
                Return 31
            Case 8
                Return 31
            Case 9
                Return 30
            Case 10
                Return 31
            Case 11
                Return 30
            Case 12
                Return 31
        End Select
    End Function

    'Public Function CalcularEdad(ByVal FechaNacimiento As String) As String
    '    'Verificar Años
    '    EdadA = Date.Now.Year - Microsoft.VisualBasic.Year(dsTab.Tables(0).Rows(0)("FNacimiento"))

    '    'Verificar Meses
    '    EdadM = Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(0)("FNacimiento"))
    '    If Val(EdadM) > Date.Now.Month Then
    '        EdadM = Val(EdadM) - Date.Now.Month
    '    ElseIf Val(EdadM) < Date.Now.Month Then
    '        EdadM = Date.Now.Month - Val(EdadM)
    '        EdadM = 12 - Val(EdadM)
    '        EdadA = Val(EdadA) - 1
    '    Else
    '        EdadM = 0
    '    End If

    '    'Verificar Dias
    '    EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento"))
    '    If Val(EdadD) > Date.Now.Day Then
    '        EdadD = Val(EdadD) - Date.Now.Day
    '    ElseIf Val(EdadD) < Date.Now.Day Then
    '        EdadM = Val(EdadM) - 1
    '        EdadD = Date.Now.Day - EdadD
    '        EdadD = DameDiasMes(Date.Now.Month) - EdadD
    '    Else
    '        EdadD = 0
    '    End If

    '    If Val(EdadA) > 0 Then
    '        Edad = EdadA & "A " & EdadM & "M"
    '    Else
    '        Edad = EdadM & "M " & EdadD & "D"
    '    End If
    'End Function
End Module
