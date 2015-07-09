Public Class frmAcceso
    Dim objUsuario As New Usuario

    Private Sub frmAcceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AbrirBase()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dsUsuario As New Data.DataSet
        dsUsuario = objUsuario.Acceso(txtUsuario.Text, txtClave.Text)
        If dsUsuario.Tables(0).Rows.Count > 0 Then
            IdUsuario = dsUsuario.Tables(0).Rows(0)("IdUsuario")
            UsuarioSistema = txtUsuario.Text
            NivelSistema = cboNivel.Text
            Select Case NivelSistema
                Case "SECRETARIA"
                    frmMenu.Show()
                Case "EPIDEMIOLOGIA"
                    frmEpidemiologia.Show()
            End Select
        Else
            MessageBox.Show("Usuario no ha sido Registrado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub

    Private Sub cboNivel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNivel.KeyDown
        If cboNivel.Text <> "" And e.KeyCode = Keys.Enter Then txtUsuario.Select()
    End Sub

    Private Sub cboNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNivel.SelectedIndexChanged

    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If txtUsuario.Text <> "" And e.KeyCode = Keys.Enter Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If txtClave.Text <> "" And e.KeyCode = Keys.Enter Then btnAceptar_Click(sender, e)
    End Sub

    Private Sub txtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged

    End Sub
End Class