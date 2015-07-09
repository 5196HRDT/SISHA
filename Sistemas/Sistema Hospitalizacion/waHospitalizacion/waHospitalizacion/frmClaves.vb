Public Class frmClaves
    Dim objMedico As New Medico

    Private Sub frmClaves_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtClave.Text <> txtRepetir.Text Then MessageBox.Show("La Nueva Clave y Repetir Clave deben ser IGUALES.... Intente Nuevamente", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Text = "" : txtRepetir.Text = "" : txtClave.Select() : Exit Sub
        If txtClave.Text = "" Then MessageBox.Show("Debe ingresar una clave", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Select() : Exit Sub
        objMedico.Medicos_CambiarClave(IdUsuario, txtClave.Text)
        MessageBox.Show("Se ha cambiado la clave correctamente, ingrese nuevamente con su clave actualizada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Application.Exit()
    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And txtClave.Text <> "" Then txtRepetir.Select()
    End Sub

    Private Sub txtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged
        If Not IsNumeric(txtClave.Text) Then
            MessageBox.Show("Debe ingresar solo NUMEROS en su clave", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If txtClave.Text.Length = 1 Then
                txtClave.Text = ""
            ElseIf txtClave.Text.Length > 1 Then
                txtClave.Text = Microsoft.VisualBasic.Left(txtClave.Text, txtClave.Text.Length - 1)
            End If

            txtClave.Select()
        End If
    End Sub
End Class