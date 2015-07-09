Public Class frmAcceso
    Dim objUsuario As New Usuario
    Dim objMedico As New Medico

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dsTabla As New Data.DataSet
        Dim Inicial As String
        If cboNivel.Text = "HOSPITALIZACION" Or cboNivel.Text = "ESTADISTICA" Then
            dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
        ElseIf cboNivel.Text = "MEDICO" Then
            dsTabla = objMedico.Medico_ControlAcceso(txtUsuario.Text, txtClave.Text)
        End If
        If dsTabla.Tables(0).Rows.Count > 0 Then
            If cboNivel.Text = "HOSPITALIZACION" Or cboNivel.Text = "ESTADISTICA" Then
                IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
                Inicial = dsTabla.Tables(0).Rows(0)("Inicial")
                If Inicial = "1" Then
                    If dsTabla.Tables(0).Rows(0)("Nivel") = "HOSPITALIZACION" Then
                        IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
                        UsuarioSistema = txtUsuario.Text
                        Me.Hide()
                        frmMenuAsistencial.Show()
                    ElseIf dsTabla.Tables(0).Rows(0)("Nivel") = "ESTADISTICAHOSP" Then
                        IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
                        UsuarioSistema = txtUsuario.Text
                        Me.Hide()
                        frmMenuEstadistica.Show()
                    Else
                        MessageBox.Show("Usuario no esta autorizado para el ingreso a este módulo", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtUsuario.Text = ""
                        txtClave.Text = ""
                        txtUsuario.Select()
                    End If
                Else
                    frmCambiarUsuario.Show()
                End If
            ElseIf cboNivel.Text = "MEDICO" Then
                Inicial = dsTabla.Tables(0).Rows(0)("CambiarC")
                IdUsuario = dsTabla.Tables(0).Rows(0)("IdMedico")
                If Inicial = "0" Then

                    UsuarioSistema = txtUsuario.Text
                    Me.Hide()
                    frmMenuMedico.Show()
                Else
                    frmClaves.Show()
                End If
            End If
        Else
            MessageBox.Show("Usuario no ha sido regitrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Text = ""
            txtClave.Text = ""
            txtUsuario.Select()
        End If
    End Sub

    Private Sub frmAcceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AbrirBD()
        cboNivel.Text = "HOSPITALIZACION"
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then txtClave.Select()
    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Then btnAceptar.Select()
    End Sub

    Private Sub cboNivel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNivel.KeyDown
        If e.KeyCode = Keys.Enter And cboNivel.Text <> "" Then txtUsuario.Select()
    End Sub

    Private Sub cboNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNivel.SelectedIndexChanged

    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub
End Class