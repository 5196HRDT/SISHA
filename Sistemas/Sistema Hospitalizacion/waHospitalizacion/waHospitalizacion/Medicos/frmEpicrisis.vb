Public Class frmEpicrisis
    Dim objHospitalizacion As New Hospitalizacion
    Dim objIngreso As New Ingreso
    Dim objResumen As New IngresoHospitalizacionResumen
    Dim objTratamiento As New IngresoHospitalizacionTto
    Dim objProcedimiento As New Procedimiento
    Dim objMortalidad As New Mortalidad
    Dim objRN As New RecienNacidoHosp
    Dim objCIE As New CIE10
    Dim objCPT As New CPT
    Dim objTransferencia As New TransferenciaServicio
    Dim objHistoria As New Historia

    Dim objIngresoCIE As New IngresoCIE

    Dim objMedico As New Medico
    Dim objServicio As New Servicio
    Dim objSubServicio As New SubServicio
    Dim objEspecialidad As New Especialidad
    Dim objCama As New CamaHosp

    Dim IdHospitalizacion As String
    Dim IdIngreso As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmEpicrisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        gbBPac.Visible = False

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

        'Enfermera
        Dim dsEnfermera As New Data.DataSet
        dsEnfermera = objMedico.BuscarTipoPersonal(2)
        cboEnfermeraO.DataSource = dsEnfermera.Tables(0)
        cboEnfermeraO.DisplayMember = "Personal"
        cboEnfermeraO.ValueMember = "IdMedico"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        btnBPac.Enabled = False
        dtpFecha.Value = Date.Now
        lblPaciente.Text = ""
        lblFecha.Text = ""
        cboServicio.Text = ""
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        cboCama.Text = ""
        lblEnfermeraIng.Text = ""
        lblMedicoIng.Text = ""
        lblFecha.Text = ""
        lblHora.Text = ""
        txtHistoria.Text = ""
        cboResponsable.Text = ""
        cboEnfermeraO.Text = ""
        gbConsulta.Visible = False
        tcGrupo.Enabled = False

        lvCIE.Items.Clear()
        txtCie.Text = ""
        txtDes.Text = ""

        txtAnamnesis.Text = ""
        txtExamenClinico.Text = ""
        txtExamenesAuxiliares.Text = ""
        txtEvolucion.Text = ""

        lvTratamiento.Items.Clear()
        txtNombreGenerico.Text = ""
        txtDosis.Text = ""
        txtVia.Text = ""
        txtFrecuencia.Text = ""
        txtDiasTratamiento.Text = ""

        txtCPT.Text = ""
        txtDesCPT.Text = ""
        lvFiltroCPT.Items.Clear()
        lvCPT.Items.Clear()
        gbCPT.Visible = False

        cboNecropsia.Text = "NO"
        dtpFechaM.Text = Date.Now
        cboCausa.Text = ""
        txtCieM.Text = ""
        txtDescripcionM.Text = ""
        lvTabla.Items.Clear()
        lvCIEN.Items.Clear()
        gbCIEN.Visible = False

        lvRN.Items.Clear()
        dtpFecha.Value = Date.Now
        txtHora.Text = "__:__"
        cboOrden.Text = ""
        cboCondicion.Text = ""
        cboSexo.Text = ""
        txtPeso.Text = ""
        txtTalla.Text = ""
        txtSemanas.Text = ""
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        lvCIE.Items.Clear()
        lvCPT.Items.Clear()
        lvRN.Items.Clear()
        lvTabla.Items.Clear()
        lvTratamiento.Items.Clear()
        If e.KeyCode = Keys.Enter Then
            Dim dsHospitalizacion As New Data.DataSet
            IdHospitalizacion = ""
            tcGrupo.Enabled = False
            dsHospitalizacion = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
            If dsHospitalizacion.Tables(0).Rows.Count > 0 Then
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")
                tcGrupo.Enabled = True
                'Verificar Ingreso Hospitalizacion
                Dim dsIngreso As New Data.DataSet
                dsIngreso = objIngreso.Buscar(IdHospitalizacion)
                If dsIngreso.Tables(0).Rows.Count > 0 Then
                    IdIngreso = dsIngreso.Tables(0).Rows(0)("IdIngreso")
                    lblFecha.Text = dsIngreso.Tables(0).Rows(0)("Fecha")
                    lblHora.Text = dsIngreso.Tables(0).Rows(0)("Hora")
                    cboServicio.Text = dsIngreso.Tables(0).Rows(0)("Servicio")
                    cboServicio_SelectedIndexChanged(sender, e)

                    cboSubServicio.Text = dsIngreso.Tables(0).Rows(0)("SubServicio")
                    cboSubServicio_SelectedIndexChanged(sender, e)
                    cboEspecialidad.Text = dsIngreso.Tables(0).Rows(0)("Especialidad")
                    cboEspecialidad_SelectedIndexChanged(sender, e)
                    cboCama.Text = dsIngreso.Tables(0).Rows(0)("Numero")
                    lblMedicoIng.Text = dsIngreso.Tables(0).Rows(0)("Responsable")
                    lblMedicoIng.Tag = dsIngreso.Tables(0).Rows(0)("IdResponsable")
                    lblEnfermeraIng.Text = dsIngreso.Tables(0).Rows(0)("Enfermera")
                    lblEnfermeraIng.Tag = dsIngreso.Tables(0).Rows(0)("IdEnfermera")
                    cboResponsable.Text = dsIngreso.Tables(0).Rows(0)("Responsable")
                    cboEnfermeraO.Text = dsIngreso.Tables(0).Rows(0)("Enfermera")

                    Dim dsVer As New DataSet
                    Dim I As Integer
                    Dim Fila As ListViewItem

                    'Verificar Transferencia de Servicio
                    Dim dsTransferencia As New DataSet
                    dsTransferencia = objTransferencia.Buscar(IdIngreso)
                    If dsTransferencia.Tables(0).Rows.Count > 0 Then
                        lblFecha.Text = dsTransferencia.Tables(0).Rows(0)("Fecha")
                        lblHora.Text = dsTransferencia.Tables(0).Rows(0)("Hora")
                        cboServicio.Text = dsTransferencia.Tables(0).Rows(0)("Servicio")
                        cboServicio_SelectedIndexChanged(sender, e)
                        cboSubServicio.Text = dsTransferencia.Tables(0).Rows(0)("SubServicio")
                        cboSubServicio_SelectedIndexChanged(sender, e)
                        cboEspecialidad.Text = dsTransferencia.Tables(0).Rows(0)("Especialidad")
                        cboEspecialidad_SelectedIndexChanged(sender, e)
                        cboCama.Text = dsTransferencia.Tables(0).Rows(0)("Cama")
                        lblMedicoIng.Text = dsTransferencia.Tables(0).Rows(0)("Medico")
                        lblMedicoIng.Tag = dsTransferencia.Tables(0).Rows(0)("IdMedico")
                        lblEnfermeraIng.Text = dsTransferencia.Tables(0).Rows(0)("Enfermera")
                        lblEnfermeraIng.Tag = dsTransferencia.Tables(0).Rows(0)("IdEnfermera")
                        cboResponsable.Text = dsTransferencia.Tables(0).Rows(0)("Medico")
                        cboEnfermeraO.Text = dsTransferencia.Tables(0).Rows(0)("Enfermera")
                    End If

                    'Buscar CIE
                    dsVer = objIngresoCIE.Buscar(IdIngreso)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvCIE.Items.Add(dsVer.Tables(0).Rows(I)("CIE"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    Next

                    'Buscar Resumen
                    dsVer = objResumen.Buscar(IdIngreso)
                    If dsVer.Tables(0).Rows.Count > 0 Then
                        dtpFecha.Value = dsVer.Tables(0).Rows(0)("Fecha")
                        txtAnamnesis.Text = dsVer.Tables(0).Rows(0)("Anamnesis")
                        txtExamenClinico.Text = dsVer.Tables(0).Rows(0)("ExamenClinico")
                        txtExamenesAuxiliares.Text = dsVer.Tables(0).Rows(0)("ExamenesAuxiliares")
                        txtEvolucion.Text = dsVer.Tables(0).Rows(0)("Evolucion")
                    End If

                    'Buscar Tratamiento
                    dsVer = objTratamiento.Buscar(IdIngreso)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvTratamiento.Items.Add(dsVer.Tables(0).Rows(I)("Nombre"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Dosis"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Via"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Frecuencia"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Dias"))
                    Next

                    'Buscar Procedimientos
                    dsVer = objProcedimiento.Buscar(IdIngreso)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvCPT.Items.Add(dsVer.Tables(0).Rows(I)("Codigo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    Next

                    'Buscar Mortalidad
                    dsVer = objMortalidad.Buscar(IdIngreso)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("Servicio"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubServicio"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Responsable"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Causa"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cie"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEspecialidad"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdResponsable"))
                        cboNecropsia.Text = dsVer.Tables(0).Rows(I)("Necropsia")
                    Next

                    'Buscar RN
                    dsVer = objRN.Buscar(IdIngreso)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvRN.Items.Add(dsVer.Tables(0).Rows(I)("Fecha"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Hora"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Orden"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Condicion"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Peso"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Talla"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Semanas"))
                    Next
                Else
                    MessageBox.Show("Debe registrar ingreso de paciente ha hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                'lblFecha.Text = dsHospitalizacion.Tables(0).Rows(0)("FecIngreso")
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")

                'Buscar()

                cboResponsable.Select()
            Else
                MessageBox.Show("Paciente No Esta Registrado En Hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblFecha.Text = ""
                lblPaciente.Text = ""
                cboServicio.Text = ""
                cboSubServicio.Text = ""
                cboEspecialidad.Text = ""
                cboCama.Text = ""
                IdIngreso = ""
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        btnBPac.Enabled = True
        txtHistoria.Select()
    End Sub

    Private Sub cboResponsable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboResponsable.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboResponsable.SelectedValue) Then cboEnfermeraO.Select()
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged

    End Sub

    Private Sub cboEnfermeraO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEnfermeraO.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEnfermeraO.SelectedValue) Then txtCieM.Select()
    End Sub

    Private Sub cboEnfermeraO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEnfermeraO.SelectedIndexChanged

    End Sub

    Private Function VerificarCodigoCIE() As Boolean
        VerificarCodigoCIE = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(0).Text = txtCieM.Text Then VerificarCodigoCIE = True : Exit For
        Next
    End Function

    Private Sub txtCie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCie.KeyDown
        'If e.KeyCode = Keys.Enter And txtCie.Text = "" Then txtDesCPT.Select()
        'If e.KeyCode = Keys.Enter And txtCie.Text <> "" Then
        '    If VerificarCodigoCIE() Then MessageBox.Show("Diagnóstico de CIE10 ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        '    Dim dsCIE As New Data.DataSet
        '    Dim I As Integer
        '    lvDet.Items.Clear()
        '    dsCIE = objCIE.BuscarCodigo(txtCie.Text)
        '    If dsCIE.Tables(0).Rows.Count > 0 Then
        '        txtDes.Enabled = False
        '        txtDes.Text = dsCIE.Tables(0).Rows(I)("desc_enf")
        '        txtDes.Enabled = True
        '        txtDes.Select()
        '    Else
        '        txtDes.Text = ""
        '        txtCie.Select()
        '        MessageBox.Show("Codigo de CIE 10 no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'End If
        If e.KeyCode = Keys.Enter Then txtDes.Select()
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And txtDes.Enabled Then txtFiltro.Text = txtDes.Text : txtFiltro.SelectionStart = txtFiltro.TextLength : gbConsulta.Visible = True : txtFiltro.Select()
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter And lvDet.Items.Count > 0 Then lvDet.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvDet.Items.Clear()
            dsCIE = objCIE.BuscarDes(txtFiltro.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
            Next
        End If
    End Sub

    Private Sub btnRetornarCie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarCie.Click
        txtFiltro.Text = ""
        gbConsulta.Visible = False
        lvDet.Items.Clear()
    End Sub

    Private Function VerificarCIE() As Boolean
        VerificarCIE = False
        Dim I As Integer
        For I = 0 To lvCIE.Items.Count - 1
            If lvCIE.Items(I).SubItems(0).Text = lvDet.SelectedItems(0).SubItems(0).Text Then VerificarCIE = True : Exit For
        Next
    End Function

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            If VerificarCIE() Then MessageBox.Show("Diagnóstico de CIE10 ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim Fila As ListViewItem
            Fila = lvCIE.Items.Add(lvDet.SelectedItems(0).SubItems(0).Text)
            Fila.SubItems.Add(lvDet.SelectedItems(0).SubItems(1).Text)
              
            btnRetornarCie_Click(sender, e)
            txtCie.Text = ""
            txtDes.Text = ""
            txtDes.Select()
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub lvTratamiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTratamiento.KeyDown
        If lvTratamiento.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            lvTratamiento.Items.RemoveAt(lvTratamiento.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvTratamiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTratamiento.SelectedIndexChanged

    End Sub

    Private Sub lvCIE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCIE.KeyDown
        If e.KeyCode = Keys.Delete And lvCIE.SelectedItems.Count > 0 Then
            lvCIE.Items.RemoveAt(lvCIE.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvCIE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCIE.SelectedIndexChanged

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtCie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCie.TextChanged

    End Sub

    Private Sub txtNombreGenerico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombreGenerico.KeyDown
        If e.KeyCode = Keys.Enter And txtNombreGenerico.Text <> "" Then txtDosis.Select()
    End Sub

    Private Sub txtNombreGenerico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreGenerico.TextChanged

    End Sub

    Private Sub txtDosis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDosis.KeyDown
        If e.KeyCode = Keys.Enter And txtDosis.Text <> "" Then txtVia.Select()
    End Sub

    Private Sub txtDosis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDosis.TextChanged

    End Sub

    Private Sub txtVia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVia.KeyDown
        If e.KeyCode = Keys.Enter And txtVia.Text <> "" Then txtFrecuencia.Select()
    End Sub

    Private Sub txtVia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVia.TextChanged

    End Sub

    Private Sub txtFrecuencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFrecuencia.KeyDown
        If e.KeyCode = Keys.Enter And txtFrecuencia.Text <> "" Then txtDiasTratamiento.Select()
    End Sub

    Private Sub txtFrecuencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrecuencia.TextChanged

    End Sub

    Private Sub txtDiasTratamiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiasTratamiento.KeyDown
        If e.KeyCode = Keys.Enter Then btnAgregar.Select()
    End Sub

    Private Sub txtDiasTratamiento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiasTratamiento.TextChanged

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim Fila As ListViewItem
        Fila = lvTratamiento.Items.Add(txtNombreGenerico.Text)
        Fila.SubItems.Add(txtDosis.Text)
        Fila.SubItems.Add(txtVia.Text)
        Fila.SubItems.Add(txtFrecuencia.Text)
        Fila.SubItems.Add(txtDiasTratamiento.Text)

        txtNombreGenerico.Text = ""
        txtDosis.Text = ""
        txtVia.Text = ""
        txtFrecuencia.Text = ""
        txtDiasTratamiento.Text = ""
        txtNombreGenerico.Select()
    End Sub

    Private Sub txtCPT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPT.KeyDown
        If e.KeyCode = Keys.Enter Then txtDesCPT.Select()
    End Sub

    Private Sub txtCPT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPT.TextChanged

    End Sub

    Private Sub txtDesCPT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesCPT.TextChanged
        If txtDesCPT.Text <> "" And txtDesCPT.Enabled Then txtFiltroCPT.Text = txtDesCPT.Text : txtFiltroCPT.SelectionStart = txtFiltroCPT.TextLength : gbCPT.Visible = True : txtFiltroCPT.Select()
    End Sub

    Private Sub txtFiltroCPT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltroCPT.KeyDown
        If e.KeyCode = Keys.Enter And lvFiltroCPT.Items.Count > 0 Then lvFiltroCPT.Select()
    End Sub

    Private Sub txtFiltroCPT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltroCPT.TextChanged
        If txtFiltroCPT.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvFiltroCPT.Items.Clear()
            dsCIE = objCPT.BuscarDes(txtFiltroCPT.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvFiltroCPT.Items.Add(dsCIE.Tables(0).Rows(I)("Codigo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Descripcion"))
            Next
        End If
    End Sub

    Private Function VerificarCPT() As Boolean
        VerificarCPT = False
        Dim I As Integer
        For I = 0 To lvCPT.Items.Count - 1
            If lvCPT.Items(I).SubItems(0).Text = lvFiltroCPT.SelectedItems(0).SubItems(0).Text Then VerificarCPT = True : Exit For
        Next
    End Function

    Private Sub lvFiltroCPT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvFiltroCPT.KeyDown
        If lvFiltroCPT.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            If VerificarCPT() Then MessageBox.Show("Procedimiento CPT ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim Fila As ListViewItem
            Fila = lvCPT.Items.Add(lvFiltroCPT.SelectedItems(0).SubItems(0).Text)
            Fila.SubItems.Add(lvFiltroCPT.SelectedItems(0).SubItems(1).Text)
            txtCPT.Text = ""
            txtDesCPT.Text = ""
            txtDesCPT.Select()
            btnRetornarCPT_Click(sender, e)
        End If
    End Sub

    Private Sub lvFiltroCPT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvFiltroCPT.SelectedIndexChanged

    End Sub

    Private Sub btnRetornarCPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarCPT.Click
        txtFiltroCPT.Text = ""
        lvFiltroCPT.Items.Clear()
        gbCPT.Visible = False
    End Sub

    Private Sub cboNecropsia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNecropsia.KeyDown
        If cboNecropsia.Text <> "" And e.KeyCode = Keys.Enter Then dtpFechaM.Select()
    End Sub

    Private Sub cboNecropsia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNecropsia.SelectedIndexChanged

    End Sub

    Private Sub dtpFechaM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaM.KeyDown
        If e.KeyCode = Keys.Enter Then cboCausa.Select()
    End Sub

    Private Sub dtpFechaM_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaM.ValueChanged

    End Sub

    Private Sub cboCausa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCausa.KeyDown
        If cboCausa.Text <> "" And e.KeyCode = Keys.Enter Then txtCieM.Select()
    End Sub

    Private Sub cboCausa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCausa.SelectedIndexChanged

    End Sub

    Private Sub txtCieM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCieM.KeyDown
        If e.KeyCode = Keys.Enter Then txtDescripcionM.Select()
    End Sub

    Private Sub txtCieM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCieM.TextChanged

    End Sub

    Private Sub txtDescripcionM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcionM.KeyDown

    End Sub

    Private Sub txtDescripcionM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcionM.TextChanged
        If txtDescripcionM.Text <> "" And txtDescripcionM.Enabled Then txtFiltroCieN.Text = txtDescripcionM.Text : txtFiltroCieN.SelectionStart = txtFiltroCieN.TextLength : gbCIEN.Visible = True : txtFiltroCieN.Select()
    End Sub

    Private Sub txtFiltroCieN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltroCieN.KeyDown
        If lvCIEN.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvCIEN.Select()
    End Sub

    Private Sub txtFiltroCieN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltroCieN.TextChanged
        If txtFiltroCieN.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvCIEN.Items.Clear()
            dsCIE = objCIE.BuscarDes(txtFiltroCieN.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvCIEN.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
            Next
        End If
    End Sub

    Private Function VerificarCIEM() As Boolean
        VerificarCIEM = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(0).Text = txtCieM.Text Then VerificarCIEM = True : Exit For
        Next
    End Function

    Private Sub lvCIEN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCIEN.KeyDown
        If lvCIEN.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            If VerificarCIEM() Then MessageBox.Show("Diagnóstico de CIE10 ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(cboServicio.Text)
            Fila.SubItems.Add(cboSubServicio.Text)
            Fila.SubItems.Add(cboEspecialidad.Text)
            Fila.SubItems.Add(cboResponsable.Text)
            Fila.SubItems.Add(dtpFechaM.Value.ToShortDateString)
            Fila.SubItems.Add(cboCausa.Text)
            Fila.SubItems.Add(lvCIEN.SelectedItems(0).SubItems(0).Text)
            Fila.SubItems.Add(lvCIEN.SelectedItems(0).SubItems(1).Text)
            Fila.SubItems.Add(cboEspecialidad.SelectedValue)
            Fila.SubItems.Add(cboResponsable.SelectedValue)
            Fila.SubItems.Add(cboNecropsia.Text)


            btnRetornarCIEN_Click(sender, e)
            cboCausa.Text = ""
            txtCieM.Text = ""
            txtDescripcionM.Text = ""
            dtpFechaM.Select()
        End If
    End Sub

    Private Sub lvCIEN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCIEN.SelectedIndexChanged

    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSubServicio As New Data.DataSet
            dsSubServicio = objSubServicio.Combo(cboServicio.SelectedValue.ToString)
            cboSubServicio.DataSource = dsSubServicio.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdSerHos"
        End If
    End Sub

    Private Sub cboSubServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubServicio.SelectedIndexChanged
        cboEspecialidad.Text = ""
        If IsNumeric(cboSubServicio.SelectedValue) Then
            Dim dsEspecialidad As New Data.DataSet
            dsEspecialidad = objEspecialidad.Buscar(cboSubServicio.SelectedValue)
            cboEspecialidad.DataSource = dsEspecialidad.Tables(0)
            cboEspecialidad.DisplayMember = "Descripcion"
            cboEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged
        cboCama.Text = ""
        If IsNumeric(cboEspecialidad.SelectedValue) Then
            Dim dsCama As New Data.DataSet
            dsCama = objCama.Asignacion(cboEspecialidad.SelectedValue)
            cboCama.DataSource = dsCama.Tables(0)
            cboCama.DisplayMember = "Numero"
            cboCama.ValueMember = "IdCama"
        End If
    End Sub

    Private Sub btnRetornarCIEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarCIEN.Click
        txtFiltroCieN.Text = ""
        lvCIEN.Items.Clear()
        gbCIEN.Visible = False
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub dtpFechaNac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaNac.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFechaNac_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaNac.ValueChanged

    End Sub

    Private Sub txtHora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If txtHora.Text <> "" And e.KeyCode = Keys.Enter Then cboOrden.Select()
    End Sub

    Private Sub txtHora_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtHora.MaskInputRejected

    End Sub

    Private Sub cboOrden_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrden.KeyDown
        If cboOrden.Text <> "" And e.KeyCode = Keys.Enter Then cboCondicion.Select()
    End Sub

    Private Sub cboOrden_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrden.SelectedIndexChanged

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim I As Integer

        'Grabar informacion de Epicrisis

        'Diagnostico de ingreso
        objIngresoCIE.Eliminar(IdIngreso)
        For I = 0 To lvCIE.Items.Count - 1
            objIngresoCIE.Grabar(IdIngreso, lvCIE.Items(I).SubItems(0).Text, lvCIE.Items(I).SubItems(1).Text)
        Next

        'Grabar Resumen de Epicrisis
        objResumen.Eliminar(IdIngreso)
        objResumen.Grabar(IdIngreso, dtpFecha.Value.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name, txtAnamnesis.Text, txtExamenClinico.Text, txtExamenesAuxiliares.Text, txtEvolucion.Text)

        'Grabar Tratamiento
        objTratamiento.Eliminar(IdIngreso)
        For I = 0 To lvTratamiento.Items.Count - 1
            objTratamiento.Grabar(IdIngreso, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name, lvTratamiento.Items(I).SubItems(0).Text, lvTratamiento.Items(I).SubItems(1).Text, lvTratamiento.Items(I).SubItems(2).Text, lvTratamiento.Items(I).SubItems(3).Text, lvTratamiento.Items(I).SubItems(4).Text)
        Next

        'Procedimiento CPT
        objProcedimiento.Mantenimiento(IdIngreso, 0, 0, "", "", 3)
        For I = 0 To lvCPT.Items.Count - 1
            objProcedimiento.Mantenimiento(IdIngreso, cboEspecialidad.SelectedValue, cboResponsable.SelectedValue, lvCPT.Items(I).SubItems(0).Text, lvCPT.Items(I).SubItems(1).Text, 1)
        Next

        'Mortalidad
        objMortalidad.Eliminar(IdIngreso)
        For I = 0 To lvTabla.Items.Count - 1
            objMortalidad.Mantenimiento(IdIngreso, lvTabla.Items(I).SubItems(8).Text, lvTabla.Items(I).SubItems(9).Text, lvTabla.Items(I).SubItems(4).Text, lvTabla.Items(I).SubItems(5).Text, lvTabla.Items(I).SubItems(6).Text, lvTabla.Items(I).SubItems(7).Text, cboNecropsia.Text, 1)
        Next

        'Recien Nacido
        objRN.Mantenimiento(IdIngreso, dtpFecha.Value.ToShortDateString, "", "", "", "", "", "", "", 3)
        For I = 0 To lvRN.Items.Count - 1
            objRN.Mantenimiento(IdIngreso, lvRN.Items(I).SubItems(0).Text, lvRN.Items(I).SubItems(1).Text, lvRN.Items(I).SubItems(2).Text, lvRN.Items(I).SubItems(3).Text, lvRN.Items(I).SubItems(4).Text, lvRN.Items(I).SubItems(5).Text, lvRN.Items(I).SubItems(6).Text, lvRN.Items(I).SubItems(7).Text, 1)
        Next

        MessageBox.Show("Datos Grabados Satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboCondicion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCondicion.KeyDown
        If e.KeyCode = Keys.Enter And cboCondicion.Text <> "" Then cboSexo.Select()
    End Sub

    Private Sub cboCondicion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondicion.SelectedIndexChanged

    End Sub

    Private Sub cboSexo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSexo.KeyDown
        If cboSexo.Text <> "" And e.KeyCode = Keys.Enter Then txtPeso.Select()
    End Sub

    Private Sub cboSexo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSexo.SelectedIndexChanged

    End Sub

    Private Sub txtPeso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPeso.KeyDown
        If e.KeyCode = Keys.Enter And txtPeso.Text <> "" Then txtTalla.Select()
    End Sub

    Private Sub txtPeso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPeso.TextChanged

    End Sub

    Private Sub txtTalla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTalla.KeyDown
        If txtTalla.Text <> "" And e.KeyCode = Keys.Enter Then txtSemanas.Select()
    End Sub

    Private Sub txtTalla_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTalla.TextChanged

    End Sub

    Private Sub txtSemanas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSemanas.KeyDown
        If txtSemanas.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvRN.Items.Add(dtpFechaNac.Value.ToShortDateString)
            Fila.SubItems.Add(txtHora.Text)
            Fila.SubItems.Add(cboOrden.Text)
            Fila.SubItems.Add(cboCondicion.Text)
            Fila.SubItems.Add(cboSexo.Text)
            Fila.SubItems.Add(txtPeso.Text)
            Fila.SubItems.Add(txtTalla.Text)
            Fila.SubItems.Add(txtSemanas.Text)
            txtHora.Text = "__:__"
            cboOrden.Text = ""
            cboCondicion.Text = ""
            cboSexo.Text = ""
            txtPeso.Text = ""
            txtTalla.Text = ""
            txtSemanas.Text = ""
            dtpFechaNac.Select()
        End If
    End Sub

    Private Sub txtSemanas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSemanas.TextChanged

    End Sub

    Private Sub lvRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvRN.KeyDown
        If lvRN.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            lvRN.Items.RemoveAt(lvRN.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvRN.SelectedIndexChanged

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