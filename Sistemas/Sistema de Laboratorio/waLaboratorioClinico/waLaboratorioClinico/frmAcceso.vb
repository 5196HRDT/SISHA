Public Class frmAcceso
    Dim objUsuario As New clsUsuario

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtUsuario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter And txtUsuario.Text <> "" Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And txtClave.Text <> "" Then btnAceptar.Select()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim dsTabla As New Data.DataSet
        Dim Inicial As String
        dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
            Inicial = dsTabla.Tables(0).Rows(0)("Inicial")
            NivelSistema = dsTabla.Tables(0).Rows(0)("Nivel")
            UsuarioSistema = txtUsuario.Text
            If Inicial = "1" Then
                If dsTabla.Tables(0).Rows(0)("Nivel") = "LABORATORIO" Then
                    Me.Hide()
                    If cboTipo.Text = "EMERGENCIA" Then
                        frmMenuAtencion.Show()
                    ElseIf cboTipo.Text = "CENTRAL" Then
                        frmMenuCentral.Show()
                    ElseIf cboTipo.Text = "HOSPITALIZACION" Then
                        frmMenuHospitalizacion.Show()
                    End If
                ElseIf dsTabla.Tables(0).Rows(0)("Nivel") = "ADMLABORATORIO" Then
                    Me.Hide()
                    frmMenu.Show()
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

    Private Sub cboTipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtUsuario.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub frmAcceso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboTipo.Text = "EMERGENCIA"
    End Sub
End Class