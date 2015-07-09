Module Programacion
    Public Sub ControlesAD(ByVal F As Form, ByVal Valor As Boolean)
        Dim X As New Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Enabled = Valor
            If TypeOf X Is ComboBox Then X.Enabled = Valor
            If TypeOf X Is MaskedTextBox Then X.Enabled = Valor
            If TypeOf X Is DateTimePicker Then X.Enabled = Valor
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
End Module
