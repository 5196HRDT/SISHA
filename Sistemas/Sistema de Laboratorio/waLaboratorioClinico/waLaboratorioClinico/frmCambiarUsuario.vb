Public Class frmCambiarUsuario
    Dim objUsuario As New clsUsuario

    Private Sub frmCambiarUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If txtClave.Text.Length > 5 Then MessageBox.Show("Debe ingresar como Maximo 05 Digitos para definir su Clave de Acceso", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Text = "" : txtCClave.Text = "" : txtClave.Select() : Exit Sub
        If txtClave.Text = txtCClave.Text Then
            objUsuario.CambiarUsuario(IdUsuario, txtClave.Text)
            Application.Exit()
        Else
            MessageBox.Show("Las Claves deben ser Identicas, Por Favor Verificar", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtClave.Select()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtClave.Text) Then txtCClave.Select()
    End Sub

    Private Sub txtClave_LostFocus(sender As Object, e As System.EventArgs) Handles txtClave.LostFocus
        If Not IsNumeric(txtClave.Text) Then MessageBox.Show("Debe ingresar solo números", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Select()
    End Sub

    Private Sub txtClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub txtCClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCClave.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtCClave.Text) Then btnAceptar.Select()
    End Sub

    Private Sub txtCClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCClave.TextChanged

    End Sub
End Class