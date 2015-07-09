Module Documento
    Public Sub Activar(ByVal F As Form, ByVal Valor As Boolean)
        Dim X As Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Enabled = Valor
            If TypeOf X Is ComboBox Then X.Enabled = Valor
            If TypeOf X Is CheckBox Then X.Enabled = Valor
        Next
    End Sub

    Public Sub Limpiar(ByVal F As Form)
        Dim X As Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Text = ""
        Next
    End Sub
End Module
