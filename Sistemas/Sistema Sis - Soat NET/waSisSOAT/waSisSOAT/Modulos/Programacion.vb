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
    Public Sub LimpiarTab(ByVal F As TabPage)
        Dim X, y As New Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Text = ""
            If TypeOf X Is Label Then If X.borderstyle = 1 Then X.text = ""
            If TypeOf X Is MaskedTextBox Then X.Text = ""
            If TypeOf X Is CheckBox Then X.CHECKED = False


        Next
    End Sub
    Public Sub LimpiarGroup(ByVal f As GroupBox)
        Dim x As New Object
        For Each x In f.Controls
            If TypeOf x Is TextBox Then x.Text = ""
            If TypeOf x Is Label Then If x.borderstyle = 1 Then x.text = ""
            If TypeOf x Is MaskedTextBox Then x.Text = ""
            If TypeOf x Is CheckBox Then x.CHECKED = False
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
