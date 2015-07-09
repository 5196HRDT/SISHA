Module Programacion
    Public Sub ControlesAD(ByVal F As Form, ByVal Valor As Boolean)
        Dim X As New Object
        Dim Y As New Object
        Dim Z As New Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Enabled = Valor
            If TypeOf X Is ComboBox Then X.Enabled = Valor
            If TypeOf X Is MaskedTextBox Then X.Enabled = Valor
            If TypeOf X Is DateTimePicker Then X.Enabled = Valor
            If TypeOf X Is TabControl Then
                For Each Pestaña As TabPage In X.TabPages
                    For Each Y In Pestaña.Controls
                        If TypeOf Z Is TextBox Then Z.Enabled = Valor
                        If TypeOf Z Is ComboBox Then Z.Enabled = Valor
                        If TypeOf Z Is MaskedTextBox Then Z.Enabled = Valor
                        If TypeOf Z Is DateTimePicker Then Z.Enabled = Valor
                    Next
                Next
            End If
        Next
    End Sub

    Public Sub Limpiar(ByVal F As Form)
        Dim X As New Object
        Dim Y As New Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.Text = ""
            If TypeOf X Is Label Then If X.borderstyle = 1 Then X.text = ""
            If TypeOf X Is MaskedTextBox Then X.Text = ""
            If TypeOf X Is TabControl Then
                For Each Pestaña As TabPage In X.TabPages
                    For Each Y In Pestaña.Controls
                        If TypeOf Y Is TextBox Then Y.Text = ""
                        If TypeOf Y Is RichTextBox Then Y.Text = ""
                        If TypeOf Y Is ComboBox Then Y.Text = ""
                        If TypeOf Y Is Label Then
                            If Y.BorderStyle = 1 Then Y.Text = ""
                        End If
                    Next
                Next
            End If
        Next
    End Sub

    Public Sub Tabulador(ByVal F As Form, ByVal Valor As Boolean)
        Dim X As New Object
        For Each X In F.Controls
            If TypeOf X Is TextBox Then X.TabStop = Valor
            If TypeOf X Is ComboBox Then X.TabStop = Valor
            If TypeOf X Is MaskedTextBox Then X.TabStop = Valor
            If TypeOf X Is DateTimePicker Then X.TabStop = Valor
            If TypeOf X Is TabControl Then
                Dim Y As New Object
                Dim I As Integer = 0
                For Each Y In X.controls
                    Dim Z As New Object
                    For Each Z In X.TabPages(I).Controls
                        If TypeOf Z Is TextBox Then Z.TabStop = Valor
                        If TypeOf Z Is ComboBox Then Z.TabStop = Valor
                        If TypeOf Z Is MaskedTextBox Then Z.TabStop = Valor
                        If TypeOf Z Is DateTimePicker Then Z.TabStop = Valor
                    Next
                    I += 1
                Next
            End If
        Next
    End Sub

    Public Function ValidarFormAbierto(ByVal F As Form) As Boolean
        Dim objForm As Form
        Dim Abierto As Boolean = False
        For Each objForm In My.Application.OpenForms
            If objForm.Name = F.Name Then
                Abierto = True
            End If
        Next
        Return Abierto
    End Function
End Module
