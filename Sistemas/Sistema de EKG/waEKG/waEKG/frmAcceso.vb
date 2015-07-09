Public Class frmAcceso
    Dim objUsuario As New clsUsuario

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter And txtUsuario.Text <> "" Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And txtClave.Text <> "" Then btnAceptar.Select()
    End Sub

    Private Sub txtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub frmAcceso_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmAcceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dsTabla As New Data.DataSet
        Dim Inicial As String
        dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
            Inicial = dsTabla.Tables(0).Rows(0)("Inicial")
            NivelSistema = dsTabla.Tables(0).Rows(0)("Nivel")
            UsuarioSistema = txtUsuario.Text
            If Inicial = "1" Then
                If dsTabla.Tables(0).Rows(0)("Nivel") = "EKG" Then
                    Me.Hide()
                    frmMenu.Show()
                Else
                    MessageBox.Show("Usuario no tiene privilegios para este módulo del sistema", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtUsuario.Text = ""
                    txtClave.Text = ""
                    txtUsuario.Select()
                End If
            Else
                MessageBox.Show("Ud. por seguridad deberá cambiar su Clave Personalizada", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmCambiarUsuario.Show()
            End If
        Else
            MessageBox.Show("Usuario no ha sido regitrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Text = ""
            txtClave.Text = ""
            txtUsuario.Select()
        End If
    End Sub
End Class
