Public Class frmRecetaSis
    Dim objHistoria As New Historia
    Dim objHospitalizacion As New Hospitalizacion
    Dim objMedicamento As New clsMedicamento
    Dim objDetalleMedHospitalizacion As New clsDetalleMedHospitalizacion
    Dim objIngreso As New Ingreso
    Dim objMedico As New Medico
    Dim objServicio As New Servicio
    Dim objSubServicio As New SubServicio
    Dim objEspecialidad As New Especialidad
    Dim objCama As New CamaHosp
    Dim objTipoTarifa As New clsTipoTarifa
    Dim objReceta As New RecetaMedicaSIS
    Dim objDosis As New clsDosisMedica
    Dim objTransferencia As New TransferenciaServicio

    Dim objSIS As New clsSIS
    Dim objExamen As New clsTarifario
    Dim objConvenio As New clsConvenio
    Dim objSoat As New clsSOAT

    Dim IdHospitalizacion As String
    Dim IdIngreso As String
    Dim Filtro As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
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

                    cboTipoAtencion.Text = dsIngreso.Tables(0).Rows(0)("TipoPaciente").ToString
                    txtSerieSIS.Text = dsIngreso.Tables(0).Rows(0)("SerieSIS").ToString
                    txtNumeroSIS.Text = dsIngreso.Tables(0).Rows(0)("NumeroSIS").ToString
                    txtNroPre.Text = dsIngreso.Tables(0).Rows(0)("NumeroPre").ToString

                    Dim objIngresoCIE As New IngresoCIE
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


                    lvCIE.Items.Clear()
                    'Buscar CIE
                    dsVer = objIngresoCIE.Buscar(IdIngreso)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvCIE.Items.Add(dsVer.Tables(0).Rows(I)("CIE"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    Next

                    'Buscar Historia de Recetas
                    'lvTabla.Items.Clear()
                    'dsVer = objDetHosp.Buscar(IdHospitalizacion)
                    'For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    '    Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdDetalle"))
                    '    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
                    '    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion").ToString)
                    '    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegAten").ToString)
                    '    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
                    '    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
                    '    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
                    '    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
                    '    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad").ToString)
                    '    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecPendiente").ToString)
                    'Next
                Else
                    MessageBox.Show("Debe registrar ingreso de paciente ha hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")
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

    Private Sub frmRecetaSis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        'Enfermera
        Dim dsEnfermera As New Data.DataSet
        dsEnfermera = objMedico.BuscarTipoPersonal(2)
        cboEnfermeraO.DataSource = dsEnfermera.Tables(0)
        cboEnfermeraO.DisplayMember = "Personal"
        cboEnfermeraO.ValueMember = "IdMedico"

        'Tipo Tarifa
        Dim dsTT As New DataSet
        dsTT = objTipoTarifa.Combo
        cboTipoAtencion.DataSource = dsTT.Tables(0)
        cboTipoAtencion.DisplayMember = "Descripcion"
        cboTipoAtencion.ValueMember = "IdTipoTarifa"

        'Dosis
        Dim dsDosis As New DataSet
        dsDosis = objDosis.Combo
        cboDosis.DataSource = dsDosis.Tables(0)
        cboDosis.DisplayMember = "Descripcion"
        cboDosis.ValueMember = "IdDosis"
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
        cboTipoAtencion.Text = ""
        txtSerieSIS.Text = ""
        txtNumeroSIS.Text = ""
        txtNroPre.Text = ""
        gbFiltro.Visible = False
        lvCIE.Items.Clear()
        lvTabla.Items.Clear()
        gbBPac.Visible = False

        txtMedicamento.Text = ""
        txtCantidadM.Text = ""
        txtIndicacionMed.Text = ""
        lblPrecioM.Text = ""
        lblUnidad.Text = ""
        dgMedicamento.Items.Clear()
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

    Private Sub lvBPac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvBPac.KeyDown
        If e.KeyCode = Keys.Enter And lvBPac.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvBPac.SelectedItems(0).SubItems(0).Text
            gbBPac.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvBPac_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBPac.SelectedIndexChanged

    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim Fila As ListViewItem
        Dim I As Integer
        Dim dsMed As New Data.DataSet
        dsMed = objMedicamento.ObtenerMedicamentos(txtFiltro.Text & "%", 1)
        dgFiltro.DataSource = objMedicamento.ObtenerMedicamentos(txtFiltro.Text & "%", 1).Tables(0)
        lvFiltro.Clear()
        lvFiltro.Columns.Add("Id", 0)
        lvFiltro.Columns.Add("Descripcion", 300)
        lvFiltro.Columns.Add("Precio", 60)
        lvFiltro.Columns.Add("IdTipoTarifa", 0)
        lvFiltro.Columns.Add("UND", 50)
        lvFiltro.Columns.Add("PrecioSIGV", 0)
        lvFiltro.Columns.Add("Stock", 60)
        For I = 0 To dsMed.Tables(0).Rows.Count - 1
            Fila = lvFiltro.Items.Add(dsMed.Tables(0).Rows(I)("BienServ"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Precio"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("IdTipoTarifa"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Unidad"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("PrecioSIGV"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Stock"))
        Next

    End Sub

    Private Sub txtMedicamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMedicamento.TextChanged
        If txtMedicamento.Text <> "" And txtMedicamento.Enabled Then Filtro = "MEDICAMENTO" : gbFiltro.Visible = True : txtFiltro.Text = txtMedicamento.Text : txtFiltro.SelectionStart = Len(txtFiltro.Text) : txtFiltro.Select()
    End Sub

    Private Sub txtCantidadM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidadM.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtCantidadM.Text) Then cboDosis.Select()
    End Sub

    Private Sub txtCantidadM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadM.TextChanged

    End Sub

    Private Sub cboDosis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDosis.KeyDown
        If txtCantidadM.Text.Length > 0 And txtMedicamento.Text.Length > 0 And e.KeyCode = Keys.Enter And IsNumeric(cboDosis.SelectedValue) Then
            If cboTipoAtencion.Text = "SIS" And Val(txtNumeroSIS.Text) = 0 Then MessageBox.Show("Paciente es SIS y no se ha ingresado el Numero de Formato, verifique esta información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Select() : Exit Sub
            Dim Fila As New ListViewItem
            Dim Importe As String
            Fila = dgMedicamento.Items.Add(txtMedicamento.Tag)
            Fila.SubItems.Add(txtMedicamento.Text)
            Fila.SubItems.Add(lblPrecioM.Text)
            Fila.SubItems.Add(txtCantidadM.Text)
            Importe = Microsoft.VisualBasic.Format(CDbl(lblPrecioM.Text) * CDbl(txtCantidadM.Text), "#,##0.00")
            lblTotalM.Text = Microsoft.VisualBasic.Format(Val(lblTotalM.Text) + Val(Importe), "#,##0.00")
            Fila.SubItems.Add(Importe)
            Fila.SubItems.Add(cboDosis.Text)
            Fila.SubItems.Add(lblUnidad.Text)
            txtCantidadM.Text = ""
            lblPrecioM.Text = ""
            txtMedicamento.Text = ""
            lblUnidad.Text = ""
            txtMedicamento.Select()
        End If
    End Sub

    Private Sub cboDosis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDosis.SelectedIndexChanged

    End Sub

    Private Sub dgMedicamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgMedicamento.KeyDown
        If e.KeyCode = Keys.Delete And dgMedicamento.Items.Count >= 1 Then
            Dim IdMedicamento As String
            Dim Importe As String
            IdMedicamento = dgMedicamento.SelectedItems(0).SubItems(0).Text
            Importe = dgMedicamento.SelectedItems(0).SubItems(4).Text
            lblTotalM.Text = Microsoft.VisualBasic.Format(Val(lblTotalM.Text) - Val(Importe), "#0.00")
            dgMedicamento.Items.RemoveAt(dgMedicamento.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub dgMedicamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgMedicamento.SelectedIndexChanged

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        btnBPac.Enabled = True
        txtHistoria.Select()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboTipoAtencion.Text = "SIS" And (txtSerieSIS.Text = "" Or txtNumeroSIS.Text = "") Then
            MessageBox.Show("Debe ingresar Serie y Numero de SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Select() : Exit Sub
        End If

        Dim CodigoSIS As String
        'Validar Codigo SIS
        If cboTipoAtencion.Text = "SIS" And Val(txtNumeroSIS.Text) <> 0 Then
            Dim dsSIS As New DataSet
            dsSIS = objSIS.ConsultarLN(txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text)
            If dsSIS.Tables(0).Rows.Count = 0 Then MessageBox.Show("Los datos del Formato no son correctos, Verificar Numeros del Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Text = "COMUN" : txtSerieSIS.Text = "" : txtNumeroSIS.Text = "" : Exit Sub
            CodigoSIS = dsSIS.Tables(0).Rows(0)("IdSis")

            If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
            If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        Else
            MessageBox.Show("El paciente debe Tener un Registro SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'Fin de validar Codigo SIS

        'Verificar Tipo de Paciente Convenios para obtener Codigos
        'Dim CodigoConvenio As String
        'If cboTipoAtencion.Text <> "SOAT" And Val(txtNroPre.Text) <> 0 Then
        '    Dim dsConvenio As New DataSet
        '    dsConvenio = objConvenio.BuscarCH(txtNroPre.Text, txtHistoria.Text)
        '    CodigoConvenio = dsConvenio.Tables(0).Rows(0)("IdConvenio")

        '    If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then
        '        If dsConvenio.Tables(0).Rows(0)("FechaFinal") < Date.Now.ToShortDateString Then
        '            MessageBox.Show("Atencion de Convenio ya fue finalizada con fecha " & dsConvenio.Tables(0).Rows(0)("FechaFinal") & ". Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Text = "COMUN" : txtNroPre.Text = "" : Exit Sub
        '        End If
        '    End If
        'End If
        'Fin Validar Convenio

        'Verificar Tipo de Paciente SOAT AFOCAT
        'Dim CodigoSoat As String
        'If cboTipoAtencion.Text = "SOAT" Then
        '    Dim dsSoat As New DataSet
        '    dsSoat = objSoat.BuscarPH(txtNroPre.Text, txtHistoria.Text)
        '    If dsSoat.Tables(0).Rows.Count > 0 Then
        '        CodigoSoat = dsSoat.Tables(0).Rows(0)("IdSoat")

        '        If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        '    Else
        '        'CodigoSoat = txtNroPre.Text
        '        MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        '    End If
        'End If
        'Fin Validar SOAT/AFOCAT

        If cboTipoAtencion.Text = "SOAT" And txtNroPre.Text = "" Then MessageBox.Show("Debe ingresar Nro de Preliquidación de Paciente SOAT", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub
        If cboTipoAtencion.Text = "CONVENIO" And txtNroPre.Text = "" Then MessageBox.Show("Debe ingresar Nro de Preliquidación de Paciente de Convenio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub

        If MessageBox.Show("Esta seguro de Solicitar los Examenes?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            Dim IdRecetaSIS As Integer

            IdRecetaSIS = objReceta.SolicitudInd(cboResponsable.Text, "HOSPITALIZACION", cboEspecialidad.Text, cboResponsable.SelectedValue, cboResponsable.Text, txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text, lblPaciente.Text, txtIndicacionMed.Text)
            For I = 0 To dgMedicamento.Items.Count - 1
                objDetalleMedHospitalizacion.Grabar(IdIngreso, dgMedicamento.Items(I).SubItems(0).Text, dgMedicamento.Items(I).SubItems(1).Text, dgMedicamento.Items(I).SubItems(2).Text, dgMedicamento.Items(I).SubItems(3).Text, dgMedicamento.Items(I).SubItems(4).Text, dgMedicamento.Items(I).SubItems(5).Text)
                objReceta.GrabarDetalle(IdRecetaSIS, dgMedicamento.Items(I).SubItems(0).Text, dgMedicamento.Items(I).SubItems(1).Text, dgMedicamento.Items(I).SubItems(2).Text, dgMedicamento.Items(I).SubItems(3).Text, dgMedicamento.Items(I).SubItems(5).Text, dgMedicamento.Items(I).SubItems(6).Text)
            Next

            For I = 0 To lvCIE.Items.Count - 1
                objReceta.GrabarCIE(IdRecetaSIS, lvCIE.Items(I).SubItems(0).Text, lvCIE.Items(I).SubItems(1).Text)
            Next

            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodigo.Click
        frmCodigo.Show()
    End Sub

    Private Sub btnRetBPac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetBPac.Click
        gbBPac.Visible = False
    End Sub
End Class