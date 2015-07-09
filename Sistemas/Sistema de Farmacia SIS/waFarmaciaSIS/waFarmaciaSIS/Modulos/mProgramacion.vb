Module mProgramacion
    Public Sub Activar(ByVal F As Form, ByVal Valor As Boolean)
        Dim X As Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Enabled = Valor
            If TypeOf X Is ComboBox Then X.Enabled = Valor
            If TypeOf X Is CheckBox Then X.Enabled = Valor
            If TypeOf X Is MaskedTextBox Then X.Enabled = Valor
            If TypeOf X Is DateTimePicker Then X.Enabled = Valor
        Next
    End Sub

    Public Sub Limpiar(ByVal F As Form)
        Dim X As Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Text = ""
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
End Module
