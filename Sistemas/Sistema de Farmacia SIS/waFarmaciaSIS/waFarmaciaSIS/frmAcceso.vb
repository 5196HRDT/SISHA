Public Class frmAcceso
    Dim objUsuario As New clsUsuario

    Private Sub frmAcceso_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmAcceso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AbrirBD()
    End Sub

    Private Sub txtUsuario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Then btnAceptar.Select()
    End Sub

    Private Sub txtClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim dsTabla As New Data.DataSet
        Dim Inicial As String
        dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
            Inicial = dsTabla.Tables(0).Rows(0)("Inicial")
            UsuarioSistema = txtUsuario.Text
            If dsTabla.Tables(0).Rows(0)("Nivel") = "VENFARMACIA" Or dsTabla.Tables(0).Rows(0)("Nivel") = "ADMFAR" Then
                If Inicial = "1" Then
                    Me.Hide()
                    frmMenu.Show()
                Else
                    Me.Hide()
                    frmCambiarUsuario.Show()
                End If
            Else
                MessageBox.Show("Usuario no posee el nivel de acceso a este módulo", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUsuario.Text = ""
                txtClave.Text = ""
                txtUsuario.Select()
            End If
        Else
            MessageBox.Show("Usuario no ha sido regitrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Text = ""
            txtClave.Text = ""
            txtUsuario.Select()
        End If
    End Sub
End Class
