Module mProgramacion
    Public Sub ControlesAD(ByVal F As Form, ByVal Valor As Boolean)
        Dim X As New Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Enabled = Valor
            If TypeOf X Is ComboBox Then X.Enabled = Valor
            If TypeOf X Is MaskedTextBox Then X.Enabled = Valor
            If TypeOf X Is DateTimePicker Then X.Enabled = Valor
        Next
    End Sub
    Public Sub LimpiarTab(ByVal F As TabPage)
        Dim X, y As New Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Text = ""
            If TypeOf X Is Label Then If X.borderstyle = 1 Then X.text = ""
            If TypeOf X Is MaskedTextBox Then X.Text = ""

        Next
    End Sub
    Public Sub Limpiar(ByVal F As Form)
        Dim X, y As New Object
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

    Public Function DameMes(ByVal Numero As String) As String
        Select Case Numero
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
