Public Class frmCambiarUsuario
    Dim objUsuario As New Usuario

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Then txtCClave.Select()
    End Sub

    Private Sub txtCClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCClave.KeyDown
        If e.KeyCode = Keys.Enter Then btnAceptar.Select()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtClave.Text = txtCClave.Text Then
            objUsuario.CambiarUsuario(IdUsuario, txtClave.Text)
            Application.Exit()
        Else
            MessageBox.Show("Las Claves deben ser Identicas, Por Favor Verificar", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtClave.Select()
        End If
    End Sub

    Private Sub frmCambiarUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class