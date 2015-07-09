Public Class frmCambiarUsuario
    Dim objUsuario As New clsUsuario

    Private Sub frmCambiarUsuario_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmCambiarUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Then txtCClave.Select()
    End Sub

    Private Sub txtClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub txtCClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCClave.KeyDown
        If e.KeyCode = Keys.Enter Then btnAceptar.Select()
    End Sub

    Private Sub txtCClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCClave.TextChanged

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If txtClave.Text = txtCClave.Text Then
            objUsuario.CambiarUsuario(IdUsuario, txtClave.Text)
            Application.Exit()
        Else
            MessageBox.Show("Las Claves deben ser Identicas, Por Favor Verificar", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtClave.Select()
        End If
    End Sub
End Class