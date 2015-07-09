Public Class frmAcceso
    Dim objMedico As New Medico
    Dim objUsuario As New Usuario

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtUsuario.Text = "" Then MessageBox.Show("Debe ingresar Usuario", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Select() : Exit Sub
        If txtClave.Text = "" Then MessageBox.Show("Debe ingresar Clave", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtUsuario.Select() : Exit Sub
        If chkEstadistica.Checked Then
            vProgramas = "NO"
            Dim dsTabla As New Data.DataSet
            Dim Inicial As String
            dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
                Inicial = dsTabla.Tables(0).Rows(0)("Inicial")
                NivelSistema = dsTabla.Tables(0).Rows(0)("Nivel")
                UsuarioSistema = txtUsuario.Text
                If Inicial = "1" Then
                    If dsTabla.Tables(0).Rows(0)("Nivel") = "ESTADISTICA" Then
                        Me.Hide()
                        frmEstadistica.Show()
                    ElseIf dsTabla.Tables(0).Rows(0)("Nivel") = "ESTADISTICAADM" Then
                        Me.Hide()
                        frmEstadisticaAdm.Show()
                    ElseIf dsTabla.Tables(0).Rows(0)("Nivel") = "CONCONV" Then
                        Me.Hide()
                        frmMenuConvenio.Show()
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
        Else
            vProgramas = "NO"
            Dim dsMedico As New DataSet
            dsMedico = objMedico.Medico_ControlAcceso(txtUsuario.Text, txtClave.Text)
            If dsMedico.Tables(0).Rows.Count > 0 Then
                CodMedico = dsMedico.Tables(0).Rows(0)("IdMedico")
                vIdMedico = CodMedico
                NomMedico = dsMedico.Tables(0).Rows(0)("Apellidos") & " " & dsMedico.Tables(0).Rows(0)("Nombres")
                vProgramas = dsMedico.Tables(0).Rows(0)("Programas")
                If dsMedico.Tables(0).Rows(0)("CambiarC") = "0" Then
                    If vProgramas = "NO" Then
                        MessageBox.Show("Bienvenido Dr(a) " & NomMedico, "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        frmListaAtencion.Show()
                    Else
                        MessageBox.Show("Bienvenido(a) " & NomMedico, "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        frmNovafis.Show()
                    End If
                Else
                    MessageBox.Show("Ud. por seguridad debera cambiar su Clave Personalizada", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmClaves.Show()
                End If
            Else
                MessageBox.Show("Personal no esta autorizado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtUsuario_Disposed(sender As Object, e As System.EventArgs) Handles txtUsuario.Disposed
        Application.Exit()
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If txtUsuario.Text.Length > 0 And e.KeyCode = Keys.Enter Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If txtClave.Text.Length > 0 And e.KeyCode = Keys.Enter Then btnAceptar.Select()
    End Sub

    Private Sub frmAcceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AbrirBase()

        'Borrar Archivo Espirometría
        Dim Archivo As String = Application.StartupPath() & "\mydocumento.pdf"
        If My.Computer.FileSystem.FileExists(Archivo) Then My.Computer.FileSystem.DeleteFile(Archivo)
    End Sub
End Class