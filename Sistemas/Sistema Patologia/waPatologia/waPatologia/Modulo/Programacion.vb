Module Programacion
    Public Sub ControlesAD(ByVal F As Form, ByVal Valor As Boolean)
        Dim X As New Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Enabled = Valor
            If TypeOf X Is ComboBox Then X.Enabled = Valor
            If TypeOf X Is MaskedTextBox Then X.Enabled = Valor
            If TypeOf X Is DateTimePicker Then X.Enabled = Valor
            If TypeOf X Is CheckBox Then X.Checked = Valor
        Next
    End Sub

    Public Sub Limpiar(ByVal F As Form)
        Dim X As New Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Text = ""
            If TypeOf X Is Label Then If X.borderstyle = 1 Then X.text = ""
            If TypeOf X Is MaskedTextBox Then X.Text = ""
        Next
    End Sub

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

    Public Function DameNumeroMes(ByVal Mes As Integer) As Integer
        Select Case Mes
            Case "ENERO"
                Return 1
            Case "FEBRERO"
                Return 2
            Case "MARZO"
                Return 3
            Case "ABRIL"
                Return 4
            Case "MAYO"
                Return 5
            Case "JUNIO"
                Return 6
            Case "JULIO"
                Return 7
            Case "AGOSTO"
                Return 8
            Case "SEPTIEMBRE"
                Return 9
            Case "OCTUBRE"
                Return 10
            Case "NOVIEMBRE"
                Return 11
            Case "DICIEMBRE"
                Return 12
        End Select
    End Function

    Public Function DameMes(ByVal NroMes As Integer) As String
        Select Case NroMes
            Case 1
                Return "ENERO"
            Case 2
                Return "FEBRERO"
            Case 3
                Return "MARZO"
            Case 4
                Return "ABRIL"
            Case 5
                Return "MAYO"
            Case 6
                Return "JUNIO"
            Case 7
                Return "JULIO"
            Case 8
                Return "AGOSTO"
            Case 9
                Return "SEPTIEMBRE"
            Case 10
                Return "OCTUBRE"
            Case 11
                Return "NOVIEMBRE"
            Case 12
                Return "DICIEMBRE"
        End Select
    End Function
End Module
