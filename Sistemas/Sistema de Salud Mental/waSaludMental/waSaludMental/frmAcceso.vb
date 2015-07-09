Public Class frmAcceso
    Dim objUsuario As New clsUsuario
    Dim objMedico As New clsMedico

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        If txtUsuario.Text = "" Then MessageBox.Show("Debe ingresar Usuario de Acceso", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtUsuario.Select() : Exit Sub
        If txtClave.Text = "" Then MessageBox.Show("Debe ingresar Clave de Acceso", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Select() : Exit Sub
        If cboTipo.Text = "CONSULTORIO" Then
            Dim dsMedico As New DataSet
            dsMedico = objMedico.Medico_ControlAcceso(txtUsuario.Text, txtClave.Text)
            If dsMedico.Tables(0).Rows.Count > 0 Then
                CodMedico = dsMedico.Tables(0).Rows(0)("IdMedico")
                vIdMedico = CodMedico
                NomMedico = dsMedico.Tables(0).Rows(0)("Apellidos") & " " & dsMedico.Tables(0).Rows(0)("Nombres")
                UsuarioSistema = txtUsuario.Text
                If dsMedico.Tables(0).Rows(0)("CambiarC") = "0" Then
                    MessageBox.Show("Bienvenido Dr(a) " & NomMedico, "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    frmMenuConsultorio.Show()
                Else
                    MessageBox.Show("Ud. por seguridad debera cambiar su Clave Personalizada", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmClaves.Show()
                End If
            Else
                MessageBox.Show("Personal no esta autorizado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf cboTipo.Text = "CUPOS" Then
            Dim dsTabla As New Data.DataSet
            Dim Inicial As String
            dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
                vIdMedico = dsTabla.Tables(0).Rows(0)("IdUsuario")
                Inicial = dsTabla.Tables(0).Rows(0)("Inicial")
                NivelSistema = dsTabla.Tables(0).Rows(0)("Nivel")
                UsuarioSistema = txtUsuario.Text
                If Inicial = "1" Then
                    If dsTabla.Tables(0).Rows(0)("Nivel") = "CUPOSSM" Then
                        Me.Hide()
                        frmMenuCupos.Show()
                    Else
                        MessageBox.Show("Ud. no tiene privilegios para ingresar a este módulo.", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Ud. por seguridad debera cambiar su Clave Personalizada", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmCambiarUsuario.Show()
                End If
            Else
                MessageBox.Show("Usuario no ha sido regitrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUsuario.Text = ""
                txtClave.Text = ""
                txtUsuario.Select()
            End If
        ElseIf cboTipo.Text = "TRAMITE" Then
            Dim dsTabla As New Data.DataSet
            Dim Inicial As String
            dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
                Inicial = dsTabla.Tables(0).Rows(0)("Inicial")
                NivelSistema = dsTabla.Tables(0).Rows(0)("Nivel")
                UsuarioSistema = txtUsuario.Text
                If Inicial = "1" Then
                    If dsTabla.Tables(0).Rows(0)("Nivel") = "TRAMITE" Or dsTabla.Tables(0).Rows(0)("Nivel") = "TRAMITEDOC" Then
                        Me.Hide()
                        frmMenuTramite.Show()
                    End If
                Else
                    MessageBox.Show("Ud. por seguridad debera cambiar su Clave Personalizada", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmCambiarUsuario.Show()
                End If
            Else
                MessageBox.Show("Usuario no ha sido regitrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUsuario.Text = ""
                txtClave.Text = ""
                txtUsuario.Select()
            End If
        End If
    End Sub

    Private Sub frmAcceso_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmAcceso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboTipo.Text = "CONSULTORIO"
    End Sub

    Private Sub cboTipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtUsuario.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub txtUsuario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter And txtUsuario.Text <> "" Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And txtClave.Text <> "" Then btnAceptar.Select()
    End Sub

    Private Sub txtClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClave.TextChanged

    End Sub
End Class
