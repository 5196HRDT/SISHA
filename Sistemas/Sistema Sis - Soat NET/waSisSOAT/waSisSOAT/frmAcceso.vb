Public Class frmAcceso
    Dim objUsuario As New Usuario

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dsTabla As New Data.DataSet
        Dim Inicial As String
        dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
            Inicial = dsTabla.Tables(0).Rows(0)("Inicial")
            NivelSistema = dsTabla.Tables(0).Rows(0)("Nivel")
            NombreUsuario = dsTabla.Tables(0).Rows(0)("Nombres")
            UsuarioSistema = txtUsuario.Text
            objUsuario.TracerLogin(UsuarioSistema, My.Computer.Name)
            If Inicial = "1" Then
                If dsTabla.Tables(0).Rows(0)("Nivel") = "CTASIS" Then
                    MenuCta.Show()
                ElseIf dsTabla.Tables(0).Rows(0)("Nivel") = "UNIDADSIS" Then
                    MenuSIS.Show()
                ElseIf dsTabla.Tables(0).Rows(0)("Nivel") = "ADMISIONSIS" Then
                    MenuAdm.Show()
                ElseIf dsTabla.Tables(0).Rows(0)("Nivel") = "HOSPITALIZACION" And Microsoft.VisualBasic.Left(UsuarioSistema, 3) = "UCI" Then
                    MenuUCI.Show()
                End If
            Else
                frmCambiarUsuario.Show()
            End If
        Else
            MessageBox.Show("Usuario no ha sido regitrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Text = ""
            txtClave.Text = ""
            txtUsuario.Select()
        End If
    End Sub

    Private Sub frmAcceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main()
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then txtClave.Select()
    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Then btnAceptar.Select()
    End Sub

    Private Sub txtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub
End Class