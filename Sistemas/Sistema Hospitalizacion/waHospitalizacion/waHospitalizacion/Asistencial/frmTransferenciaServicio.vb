Public Class frmTransferenciaServicio
    Dim objTransferencia As New TransferenciaServicio
    Dim objServicio As New Servicio
    Dim objMedico As New Medico
    Dim objSubServicio As New SubServicio
    Dim objHospitalizacion As New Hospitalizacion
    Dim objIngreso As New Ingreso
    Dim objEspecialidad As New Especialidad
    Dim objCama As New CamaHosp
    Dim objHistoria As New Historia

    Dim Oper As String
    Dim CodLocal As String
    Dim IdHospitalizacion As String
    Dim IdIngreso As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblPaciente.Text = ""
        lblFecha.Text = ""
        lblServicio.Text = ""
        lblSubServicio.Text = ""
        cboServicio.Text = ""
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        cboCama.Text = ""
        lvTabla.Items.Clear()
        Botones(True, False, False, True)
        Limpiar(Me)
        Activar(Me, False)
        btnBPac.Enabled = False
        gbBPac.Visible = False
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        btnBPac.Enabled = True
        Oper = 1
        dtpFecha.Value = Date.Now
        txtHora.Text = Date.Now.TimeOfDay.ToString
        txtHistoria.Select()
    End Sub

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsHist As New Data.DataSet
        dsHist = objTransferencia.Buscar(IdIngreso)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsHist.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsHist.Tables(0).Rows(I)("IdTransferencia"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Hora"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Responsable"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Medico"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("SubServicio"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Cama"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Enfermera"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Motivo"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("IdIngreso"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("IdCama"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Tipo"))
        Next
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dsHospitalizacion As New Data.DataSet
            IdHospitalizacion = ""
            dsHospitalizacion = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
            If dsHospitalizacion.Tables(0).Rows.Count > 0 Then
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")
                'Verificar Ingreso Hospitalizacion
                Dim dsIngreso As New Data.DataSet
                dsIngreso = objIngreso.Buscar(IdHospitalizacion)
                If dsIngreso.Tables(0).Rows.Count > 0 Then
                    IdIngreso = dsIngreso.Tables(0).Rows(0)("IdIngreso")
                    lblFecha.Text = dsIngreso.Tables(0).Rows(0)("Fecha")
                    lblHora.Text = dsIngreso.Tables(0).Rows(0)("Hora")
                    lblServicio.Text = dsIngreso.Tables(0).Rows(0)("Servicio")
                    lblSubServicio.Text = dsIngreso.Tables(0).Rows(0)("SubServicio")
                    lblEspecialidad.Text = dsIngreso.Tables(0).Rows(0)("Especialidad")
                    lblCama.Tag = dsIngreso.Tables(0).Rows(0)("IdCama")
                    lblCama.Text = dsIngreso.Tables(0).Rows(0)("Numero")
                    lblMedicoIng.Text = dsIngreso.Tables(0).Rows(0)("Responsable")
                    lblMedicoIng.Tag = dsIngreso.Tables(0).Rows(0)("IdResponsable")
                    lblEnfermeraIng.Text = dsIngreso.Tables(0).Rows(0)("Enfermera")
                    lblEnfermeraIng.Tag = dsIngreso.Tables(0).Rows(0)("IdEnfermera")
                    cboResponsable.Text = dsIngreso.Tables(0).Rows(0)("Responsable")
                    cboEnfermeraO.Text = dsIngreso.Tables(0).Rows(0)("Enfermera")

                    Dim dsTransferencia As New DataSet
                    dsTransferencia = objTransferencia.Buscar(IdIngreso)
                    If dsTransferencia.Tables(0).Rows.Count > 0 Then
                        lblFecha.Text = dsTransferencia.Tables(0).Rows(0)("Fecha")
                        lblHora.Text = dsTransferencia.Tables(0).Rows(0)("Hora")
                        lblServicio.Text = dsTransferencia.Tables(0).Rows(0)("Servicio")
                        lblSubServicio.Text = dsTransferencia.Tables(0).Rows(0)("SubServicio")
                        lblEspecialidad.Text = dsTransferencia.Tables(0).Rows(0)("Especialidad")
                        lblCama.Tag = dsTransferencia.Tables(0).Rows(0)("IdCama")
                        lblCama.Text = dsTransferencia.Tables(0).Rows(0)("Cama")
                        lblMedicoIng.Text = dsTransferencia.Tables(0).Rows(0)("Medico")
                        lblMedicoIng.Tag = dsTransferencia.Tables(0).Rows(0)("IdMedico")
                        lblEnfermeraIng.Text = dsTransferencia.Tables(0).Rows(0)("Enfermera")
                        lblEnfermeraIng.Tag = dsTransferencia.Tables(0).Rows(0)("IdEnfermera")
                        cboResponsable.Text = dsTransferencia.Tables(0).Rows(0)("Medico")
                        cboEnfermeraO.Text = dsTransferencia.Tables(0).Rows(0)("Enfermera")
                    End If
                Else
                    MessageBox.Show("Debe registrar ingreso de paciente ha hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                'lblFecha.Text = dsHospitalizacion.Tables(0).Rows(0)("FecIngreso")
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")

                Buscar()

                cboResponsable.Select()
            Else
                MessageBox.Show("Paciente No Esta Registrado En Hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblFecha.Text = ""
                lblPaciente.Text = ""
                lblServicio.Text = ""
                lblSubServicio.Text = ""
                IdIngreso = ""
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged
        
    End Sub

    Private Sub frmTransferenciaServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Servicio
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Combo("%")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdPiso"

        'Responsable
        Dim dsResponsable As New Data.DataSet
        dsResponsable = objMedico.BuscarTipoPersonal(1)
        cboResponsable.DataSource = dsResponsable.Tables(0)
        cboResponsable.DisplayMember = "Personal"
        cboResponsable.ValueMember = "IdMedico"

        'Medico
        Dim dsMedico As New Data.DataSet
        dsMedico = objMedico.BuscarTipoPersonal(1)
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "Personal"
        cboMedico.ValueMember = "IdMedico"

        'Enfermera
        Dim dsEnfermera As New Data.DataSet
        dsEnfermera = objMedico.BuscarTipoPersonal(2)
        cboEnfermera.DataSource = dsEnfermera.Tables(0)
        cboEnfermera.DisplayMember = "Personal"
        cboEnfermera.ValueMember = "IdMedico"

        'Enfermera Origen
        Dim dsEnfermeraO As New Data.DataSet
        dsEnfermeraO = objMedico.BuscarTipoPersonal(2)
        cboEnfermeraO.DataSource = dsEnfermeraO.Tables(0)
        cboEnfermeraO.DisplayMember = "Personal"
        cboEnfermeraO.ValueMember = "IdMedico"
    End Sub

    Private Sub cboServicio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.Click
        cboServicio_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cboServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If IsNumeric(cboServicio.SelectedValue) And e.KeyCode = Keys.Enter Then cboSubServicio.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        cboCama.Text = ""
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSubServicio As New Data.DataSet
            dsSubServicio = objSubServicio.Combo(cboServicio.SelectedValue.ToString)
            cboSubServicio.DataSource = dsSubServicio.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdSerHos"
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim dsVer As New DataSet
            dsVer = objTransferencia.Buscar(IdIngreso)
            If dsVer.Tables(0).Rows.Count = 0 Then
                objTransferencia.MantenimientoP(CodLocal, IdIngreso, lblFecha.Text, lblHora.Text, lblMedicoIng.Tag, lblMedicoIng.Tag, lblCama.Tag, lblEnfermeraIng.Tag, "", "INGRESO", Oper)
            End If
            objTransferencia.MantenimientoP(CodLocal, IdIngreso, dtpFecha.Value.ToShortDateString, txtHora.Text, cboResponsable.SelectedValue, cboMedico.SelectedValue, cboCama.SelectedValue, cboEnfermera.SelectedValue, txtMotivo.Text, "INGRESO TRANSFERENCIA", Oper)

            MessageBox.Show("Transferencia realizada satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'objCama.CambiarEstado(cboCama.SelectedValue, "OCUPADA")
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de Anular Transferencia Interna", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim I As Integer
                For I = 0 To lvTabla.Items.Count - 1
                    If lvTabla.Items(I).Selected Then
                        objTransferencia.Anular(lvTabla.Items(I).SubItems(0).Text, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Date.Now.TimeOfDay.ToString, UsuarioSistema, My.Computer.Name)

                        'Liberar Cama
                        objCama.CambiarEstado(lvTabla.Items(I).SubItems(12).Text, "DISPONIBLE")

                        lvTabla.Items.RemoveAt(I)
                        Exit For
                    End If
                Next
                Buscar()
            End If
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.Items.Count > 0 Then
            'Dim I As Integer
            'For I = 0 To lvTabla.Items.Count - 1
            '    If lvTabla.Items(I).Selected Then
            '        dtpFecha.Value = lvTabla.Items(I).SubItems(0).Text
            '        txtHora.Text = lvTabla.Items(I).SubItems(1).Text
            '        cboResponsable.Text = lvTabla.Items(I).SubItems(2).Text
            '        cboServicio.Text = lvTabla.Items(I).SubItems(3).Text
            '        cboSubServicio.Text = lvTabla.Items(I).SubItems(4).Text
            '        CodLocal = lvTabla.Items(I).SubItems(5).Text
            '        Oper = 2
            '        Botones(False, True, True, False)
            '        Activar(Me, True)
            '    End If
            'Next
        End If
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter Then cboMedico.Select()
    End Sub

    Private Sub txtHora_MaskInputRejected(sender As System.Object, e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtHora.MaskInputRejected

    End Sub

    Private Sub cboResponsable_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboResponsable.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboResponsable.SelectedValue) Then cboEnfermeraO.Select()
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged

    End Sub

    Private Sub cboSubServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSubServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboSubServicio.SelectedValue) Then cboEspecialidad.Select()
    End Sub

    Private Sub cboSubServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSubServicio.SelectedIndexChanged
        cboEspecialidad.Text = ""
        cboCama.Text = ""
        If IsNumeric(cboSubServicio.SelectedValue) Then
            Dim dsEspecialidad As New Data.DataSet
            dsEspecialidad = objEspecialidad.Buscar(cboSubServicio.SelectedValue)
            cboEspecialidad.DataSource = dsEspecialidad.Tables(0)
            cboEspecialidad.DisplayMember = "Descripcion"
            cboEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub cboEspecialidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEspecialidad.SelectedValue) Then cboCama.Select()
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged
        cboCama.Text = ""
        If IsNumeric(cboEspecialidad.SelectedValue) Then
            Dim dsCama As New Data.DataSet
            dsCama = objCama.Asignacion(cboEspecialidad.SelectedValue)
            cboCama.DataSource = dsCama.Tables(0)
            cboCama.DisplayMember = "Numero"
            cboCama.ValueMember = "IdCama"
        End If
    End Sub

    Private Sub cboCama_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCama.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboCama.SelectedValue) Then cboEnfermera.Select()
    End Sub

    Private Sub cboCama_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCama.SelectedIndexChanged

    End Sub

    Private Sub cboEnfermera_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEnfermera.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEnfermera.SelectedValue) Then txtMotivo.Select()
    End Sub

    Private Sub cboEnfermera_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEnfermera.SelectedIndexChanged

    End Sub

    Private Sub txtMotivo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMotivo.KeyDown
        If txtMotivo.Text <> "" And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub cboMedico_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboMedico.SelectedValue) Then cboServicio.Select()
    End Sub

    Private Sub cboMedico_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedico.SelectedIndexChanged

    End Sub

    Private Sub cboEnfermeraO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEnfermeraO.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEnfermeraO.SelectedValue) Then dtpFecha.Select()
    End Sub

    Private Sub cboEnfermeraO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEnfermeraO.SelectedIndexChanged

    End Sub

    Private Sub btnBPac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBPac.Click
        gbBPac.Visible = True
        txtFPac.Select()
    End Sub

    Private Sub txtFPac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPac.KeyDown
        If txtFPac.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtFPac.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvBPac.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FNacimiento").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomPadre").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomMadre").ToString)
            Next
        End If
    End Sub

    Private Sub txtFPac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFPac.TextChanged

    End Sub

    Private Sub btnRetBPac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetBPac.Click
        gbBPac.Visible = False
    End Sub

    Private Sub lvBPac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvBPac.KeyDown
        If e.KeyCode = Keys.Enter And lvBPac.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvBPac.SelectedItems(0).SubItems(0).Text
            gbBPac.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvBPac_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBPac.SelectedIndexChanged

    End Sub
End Class