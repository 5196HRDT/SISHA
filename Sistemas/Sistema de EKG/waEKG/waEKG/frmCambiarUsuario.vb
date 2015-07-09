Public Class frmCambiarUsuario
    Dim objUsuario As New clsUsuario

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And txtClave.Text <> "" Then txtCClave.Select()
    End Sub

    Private Sub txtCClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCClave.KeyDown
        If e.KeyCode = Keys.Enter And txtCClave.Text <> "" Then btnAceptar.Select()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtClave.Text.Length > 5 Then MessageBox.Show("Debe ingresar como Maximo 05 Digitos para definir su Clave de Acceso", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Text = "" : txtCClave.Text = "" : txtClave.Select() : Exit Sub
        If txtClave.Text = txtCClave.Text Then
            objUsuario.CambiarUsuario(IdUsuario, txtClave.Text)
            Application.Exit()
        Else
            MessageBox.Show("Las Claves deben ser Identicas, Por Favor Verificar", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtClave.Select()
        End If
    End Sub

    Private Sub txtClave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClave.LostFocus
        If Not IsNumeric(txtClave.Text) Then MessageBox.Show("Debe ingresar solo números", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Select()
    End Sub

    Private Sub txtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub

    Private Sub btnCancelar_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Disposed
        Application.Exit()
    End Sub

    Private Sub frmCambiarUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class