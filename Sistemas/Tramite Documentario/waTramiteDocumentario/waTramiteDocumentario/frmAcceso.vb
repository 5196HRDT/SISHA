Public Class frmAcceso
    Dim objUsuario As New Usuario
    Dim objDptoUnidad As New DptoUnidad
    Dim objServiArea As New ServiArea
    Dim objTrabajador As New Trabajador

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtClave.Select()
    End Sub

    Private Sub frmAcceso_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmAcceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Verificar si el programa esta en ejecución
        Dim ProcesosLocales As Process() = Process.GetProcessesByName("waTramiteDocumentario")
        If ProcesosLocales.Length >= 1 Then MessageBox.Show("Ya Aplicación está siendo usada por un Usuario. Cierre la Aplicación e Ingrese con sus Datos", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Application.Exit()

        'Llenar DptoUnidad
        Dim dsDptoUnidad As New Data.DataSet
        dsDptoUnidad = objDptoUnidad.Buscar("")
        cboDpto.DataSource = dsDptoUnidad.Tables(0)
        cboDpto.DisplayMember = "Descripcion"
        cboDpto.ValueMember = "IdDptoUnidad"
    End Sub

    Private Sub rbTramite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTramite.CheckedChanged
        gbTramite.Visible = True
        gbServicioArea.Visible = False
    End Sub

    Private Sub rbServicioArea_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbServicioArea.CheckedChanged
        gbTramite.Visible = False
        gbServicioArea.Visible = True
    End Sub

    Private Sub cboDpto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDpto.KeyDown
        If IsNumeric(cboDpto.SelectedValue) And e.KeyCode = Keys.Enter Then cboServiArea.Select()
    End Sub

    Private Sub cboDpto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDpto.SelectedIndexChanged
        cboServiArea.Text = ""
        If IsNumeric(cboDpto.SelectedValue) Then
            'Llenar ServiArea
            Dim dsServiArea As New Data.DataSet
            dsServiArea = objServiArea.Combo(cboDpto.SelectedValue.ToString)
            cboServiArea.DataSource = dsServiArea.Tables(0)
            cboServiArea.DisplayMember = "Descripcion"
            cboServiArea.ValueMember = "IdServiArea"
        End If
    End Sub

    Private Sub cboServiArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServiArea.KeyDown
        If IsNumeric(cboServiArea.SelectedValue) And e.KeyCode = Keys.Enter Then cboTrabajador.Select()
    End Sub

    Private Sub cboServiArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServiArea.SelectedIndexChanged
        cboTrabajador.Text = ""
        If IsNumeric(cboServiArea.SelectedValue) Then
            cboTrabajador.Text = ""
            'Llenar Trabajador
            Dim dsTrabajador As New Data.DataSet
            dsTrabajador = objTrabajador.BuscarTrabjador(cboServiArea.SelectedValue.ToString)
            cboTrabajador.DataSource = dsTrabajador.Tables(0)
            cboTrabajador.DisplayMember = "Nombres"
            cboTrabajador.ValueMember = "IdTrabajador"
        End If
    End Sub

    Private Sub cboTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTrabajador.KeyDown
        If IsNumeric(cboTrabajador.SelectedValue) And e.KeyCode = Keys.Enter Then txtFirma.Select()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub

    Private Sub btnCancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar1.Click
        Application.Exit()
    End Sub

    Private Sub btnAceptar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar1.Click
        Dim dsTabla As New Data.DataSet
        dsTabla = objTrabajador.ValidarAcceso(cboServiArea.SelectedValue.ToString, cboTrabajador.SelectedValue.ToString, txtFirma.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            TrabajadorOrigen = cboTrabajador.Text
            ServicioOrigen = cboServiArea.Text
            TituloOrigen = dsTabla.Tables(0).Rows(0)("Titulo")
            CargoOrigen = dsTabla.Tables(0).Rows(0)("Cargo")

            ServicioAreaTrabajador = cboServiArea.Text
            CodigoServiArea = cboServiArea.SelectedValue.ToString
            CodigoTrabajador = cboTrabajador.SelectedValue.ToString
            NombreSecretaria = cboTrabajador.Text
            MessageBox.Show("Bienvenido " & TituloOrigen & " " & NombreSecretaria, "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmMenuOficina.Show()
            Me.Hide()
        Else
            MessageBox.Show("Usuario no es Valido", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dsTabla As New Data.DataSet
        Dim Inicial As String
        dsTabla = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
                IdUsuario = dsTabla.Tables(0).Rows(0)("IdUsuario")
            Inicial = dsTabla.Tables(0).Rows(0)("Usuario")
                UsuarioSistema = txtUsuario.Text
            frmMenu.Show()
            Me.Hide()
        Else
            MessageBox.Show("Usuario no ha sido regitrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Text = ""
            txtClave.Text = ""
            txtUsuario.Select()
        End If
    End Sub

    Private Sub txtUsuario_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If txtUsuario.Text <> "" And e.KeyCode = Keys.Enter Then txtClave.Select()
    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If txtClave.Text <> "" And e.KeyCode = Keys.Enter Then btnAceptar_Click(sender, e)
    End Sub

    Private Sub txtFirma_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFirma.KeyDown
        If txtFirma.Text <> "" And e.KeyCode = Keys.Enter Then btnAceptar1_Click(sender, e)
    End Sub
End Class
