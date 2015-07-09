Public Class frmAcceso
    Dim objUsuario As New clsUsuario

    Private Sub frmAcceso_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmAcceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTipo.Text = "CITAS"
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter And txtUsuario.Text <> "" Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And txtClave.Text <> "" Then btnAceptar.Select()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dsTabla As New Data.DataSet
        Dim Inicial As String
        dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            vIdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
            Inicial = dsTabla.Tables(0).Rows(0)("Inicial")
            vNivelSistema = dsTabla.Tables(0).Rows(0)("Nivel")
            vUsuarioSistema = txtUsuario.Text
            If Inicial = "1" Then
                If dsTabla.Tables(0).Rows(0)("Nivel") = "ADMISIONRAYOS" Then
                    Me.Hide()
                    frmSolicitudExa.Show()
                ElseIf dsTabla.Tables(0).Rows(0)("Nivel") = "RAYOS" Then
                    Me.Hide()
                    frmInformeRX.Show()
                ElseIf dsTabla.Tables(0).Rows(0)("Nivel") = "RAYOSSALA" Then
                    Me.Hide()
                    frmConsultaProgSala.Show()
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

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtUsuario.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub
End Class