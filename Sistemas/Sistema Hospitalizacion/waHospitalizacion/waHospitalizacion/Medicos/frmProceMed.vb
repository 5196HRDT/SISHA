Public Class frmProceMed
    Dim objHistoria As New Historia
    Dim objHospitalizacion As New Hospitalizacion
    Dim objDetHosp As New clsDetalleHospitalizacion
    Dim objIngreso As New Ingreso
    Dim objMedico As New Medico
    Dim objServicio As New Servicio
    Dim objSubServicio As New SubServicio
    Dim objEspecialidad As New Especialidad
    Dim objCama As New CamaHosp
    Dim objTipoTarifa As New clsTipoTarifa
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
        lblCuentaInicial.Text = "0.00"
        lblTotal.Text = "0.00"
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
                    lvCIE.Items.Clear()


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

                    'Buscar Historia de Procedimientos
                    Dim Importe As Double
                    lvTabla.Items.Clear()
                    dsVer = objDetHosp.Buscar(IdHospitalizacion)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdDetalle"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
                        If dsVer.Tables(0).Rows(I)("Descripcion").ToString <> "" Then
                            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion").ToString)
                        Else
                            Dim objTarifario As New Tarifario
                            Dim dsTarifario As New DataSet
                            dsTarifario = objTarifario.ServicioItem_BuscarId(dsVer.Tables(0).Rows(0)("IdServicioItem"))
                            dsTarifario = objTarifario.ItemServicio_BuscarIdItem(dsTarifario.Tables(0).Rows(0)("IdItem"))
                            If dsTarifario.Tables(0).Rows.Count > 0 Then
                                Fila.SubItems.Add(dsTarifario.Tables(0).Rows(0)("Actividad").ToString)
                            Else
                                Fila.SubItems.Add("")
                            End If
                        End If
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegAten").ToString)
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad").ToString)
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecPendiente").ToString)
                        Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Precio")), "#,##0.00"))
                        Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("PrecioReal")), "#,##0.00"))
                        Importe = CDbl(dsVer.Tables(0).Rows(I)("Cantidad")) * CDbl(dsVer.Tables(0).Rows(I)("Precio"))
                        Fila.SubItems.Add(Format(Importe, "#,##0.00"))
                        lblTotal.Text = CDbl(lblTotal.Text) + Importe
                        Importe = CDbl(dsVer.Tables(0).Rows(I)("Cantidad")) * CDbl(dsVer.Tables(0).Rows(I)("PrecioReal"))
                        Fila.SubItems.Add(Format(Importe, "#,##0.00"))
                        lblCuentaInicial.Text = CDbl(lblCuentaInicial.Text) + Importe
                    Next
                    lblTotal.Text = Format(CDbl(lblCuentaInicial.Text), "#,##0.00")
                    lblCuentaInicial.Text = Format(CDbl(lblCuentaInicial.Text), "#,##0.00")
                Else
                    MessageBox.Show("Debe registrar ingreso de paciente ha hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")
                cboResponsable.Select()
            Else
                MessageBox.Show("Paciente No Esta Registrado En Hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub frmProceMed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        gbBPac.Visible = False
        btnBPac.Enabled = False
        btnPendiente.Enabled = False

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
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        dtpFecha.Value = Date.Now
        btnBPac.Enabled = False
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

        txtExamenes.Text = ""
        txtCantidadE.Text = ""
        txtIndicacion.Text = ""
        lblPrecioE.Text = ""
        lblTipoP.Text = ""
        lblSTP.Text = ""
        dgExamenes.Items.Clear()
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

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        btnBPac.Enabled = True
        btnBPac.Enabled = True
        txtHistoria.Select()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtExamenes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExamenes.TextChanged
        If txtExamenes.Text <> "" And txtExamenes.Enabled Then
            If lvCIE.Items.Count = 0 Then MessageBox.Show("Debe ingresar un Diagnóstico como mínimo para Solicitar los Procedimientos", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
            'Validar Diagnostico

            If cboTipoAtencion.Text = "SIS" And txtSerieSIS.Text = "" Then MessageBox.Show("Debe Ingresar La Serie de SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Select() : Exit Sub
            If cboTipoAtencion.Text = "SIS" And IsNumeric(txtNumeroSIS.Text) = 0 Then MessageBox.Show("Debe Ingresar El Numero de SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNumeroSIS.Select() : Exit Sub

            Filtro = "EXAMENES" : gbFiltro.Visible = True : txtFiltro.Text = txtExamenes.Text : txtFiltro.SelectionStart = Len(txtFiltro.Text) : txtFiltro.Select()
        End If
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter And lvFiltro.Items.Count > 0 Then lvFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Select Case Filtro
            'Case "MEDICAMENTO"
            '    Dim Fila As ListViewItem
            '    Dim I As Integer
            '    Dim dsMed As New Data.DataSet
            '    dsMed = objMedicamento.ObtenerMedicamentos(txtFiltro.Text & "%", 1)
            '    dgFiltro.DataSource = objMedicamento.ObtenerMedicamentos(txtFiltro.Text & "%", 1).Tables(0)
            '    lvFiltro.Clear()
            '    lvFiltro.Columns.Add("Id", 0)
            '    lvFiltro.Columns.Add("Descripcion", 300)
            '    lvFiltro.Columns.Add("Precio", 60)
            '    lvFiltro.Columns.Add("IdTipoTarifa", 0)
            '    lvFiltro.Columns.Add("UND", 50)
            '    lvFiltro.Columns.Add("PrecioSIGV", 0)
            '    lvFiltro.Columns.Add("Stock", 60)
            '    For I = 0 To dsMed.Tables(0).Rows.Count - 1
            '        Fila = lvFiltro.Items.Add(dsMed.Tables(0).Rows(I)("BienServ"))
            '        Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Descripcion"))
            '        Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Precio"))
            '        Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("IdTipoTarifa"))
            '        Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Unidad"))
            '        Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("PrecioSIGV"))
            '        Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Stock"))
            '    Next
            Case "EXAMENES"
                Dim Fila As ListViewItem
                Dim I As Integer
                Dim dsExa As New Data.DataSet
                Dim TipoTarifa As String
                If cboTipoAtencion.Text <> "" Then
                    If Val(txtNroPre.Text) = 0 Then
                        If cboTipoAtencion.Text = "COMUN" Or cboTipoAtencion.Text = "EXONERADO" Or cboTipoAtencion.Text = "PROGRAMA" Or cboTipoAtencion.Text = "OTROS" Then
                            TipoTarifa = 1
                        ElseIf cboTipoAtencion.Text = "SIS" Then
                            TipoTarifa = 12
                        End If
                        dsExa = objExamen.BuscarServicio(txtFiltro.Text & "%", TipoTarifa, "D")
                    Else
                        If cboTipoAtencion.Text = "SOAT" Then
                            dsExa = objSoat.BuscarDes(txtFiltro.Text, "TODO")
                        Else
                            Dim dsVerC As New DataSet
                            dsVerC = objConvenio.VerificarTipoAtencionCE(txtNroPre.Text)
                            If dsVerC.Tables(0).Rows.Count > 0 Then TipoTarifa = dsVerC.Tables(0).Rows(0)("IdTipoConvenio") Else TipoTarifa = 1
                            dsExa = objExamen.BuscarServicio(txtFiltro.Text & "%", TipoTarifa, "D")
                        End If
                    End If

                    dgFiltro.DataSource = dsExa.Tables(0)
                Else

                End If

                lvFiltro.Clear()
                lvFiltro.Columns.Add("Id", 0)
                lvFiltro.Columns.Add("Descripcion", 400)
                lvFiltro.Columns.Add("Precio", 100, HorizontalAlignment.Right)
                lvFiltro.Columns.Add("IdTipoTarifa", 0)
                lvFiltro.Columns.Add("IdItem", 0)
                lvFiltro.Columns.Add("Tipo", 0)
                lvFiltro.Columns.Add("Clase", 0)
                For I = 0 To dsExa.Tables(0).Rows.Count - 1
                    If cboTipoAtencion.Text <> "SOAT" Then
                        Fila = lvFiltro.Items.Add(dsExa.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsExa.Tables(0).Rows(I)("Precio")), "#,##0.00"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("IdTipoTarifa"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("IdItem"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("ClasLaboratorio"))
                    Else
                        Fila = lvFiltro.Items.Add(dsExa.Tables(0).Rows(I)("IdTarifario"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsExa.Tables(0).Rows(I)("Precio")), "#,##0.00"))
                        Fila.SubItems.Add("")
                        Fila.SubItems.Add("")
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("SubTipo"))
                    End If
                Next
        End Select
    End Sub

    Private Sub txtCantidadE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidadE.KeyDown
        If e.KeyCode = Keys.Enter Then txtIndicacion.Select()
    End Sub

    Private Sub txtCantidadE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadE.TextChanged

    End Sub

    Private Sub txtIndicacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIndicacion.KeyDown
        If txtCantidadE.Text.Length > 0 And txtExamenes.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            If cboTipoAtencion.Text = "SIS" And Val(txtNumeroSIS.Text) = 0 Then MessageBox.Show("Paciente es SIS y no se ha ingresado el Numero de Formato, verifique esta información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Select() : Exit Sub
            If cboTipoAtencion.Text = "SOAT" And Val(txtNroPre.Text) = 0 Then MessageBox.Show("Paciente es SOAT y no se ha ingresado el Numero de Preliquidación, verifique esta información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub
            If Microsoft.VisualBasic.Left(cboTipoAtencion.Text, 7) = "SANIDAD" And Val(txtNroPre.Text) = 0 Then MessageBox.Show("Paciente es Convenio y no se ha ingresado el Numero de Preliquidación, verifique esta información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub

            If txtIndicacion.Text.Length = 0 And lblTipoP.Text = "RAYOS" Then MessageBox.Show("Para este tipo de exámen, debe ingresar una indicación que oriente al especialista.", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtIndicacion.Select() : Exit Sub
            If txtIndicacion.Text.Length = 0 And lblSTP.Text = "ECOGRAFIA" Then MessageBox.Show("Para este tipo de exámen, debe ingresar una indicación que oriente al especialista.", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtIndicacion.Select() : Exit Sub

            Dim Fila As New ListViewItem
            Dim Importe As String
            Fila = dgExamenes.Items.Add(txtExamenes.Tag)
            Fila.SubItems.Add(txtExamenes.Text)
            Fila.SubItems.Add(lblPrecioE.Text)
            Fila.SubItems.Add(txtCantidadE.Text)
            Importe = Microsoft.VisualBasic.Format(Val(lblPrecioE.Text) * Val(txtCantidadE.Text), "#0.00")
            lblTotalE.Text = Microsoft.VisualBasic.Format(Val(lblTotalE.Text) + Val(Importe), "#0.00")
            Fila.SubItems.Add(Importe)
            Fila.SubItems.Add(lblTipoP.Text)
            Fila.SubItems.Add(lblSTP.Text)
            Fila.SubItems.Add(txtIndicacion.Text)

            'Informar de Examenes de CERIT
            If txtExamenes.Text = "ANTICORE TOTAL" Or txtExamenes.Text = "HEPATITIS C (ANTICUERPO)" Or txtExamenes.Text = "HTVL1" Or txtExamenes.Text = "RPR" Or txtExamenes.Text = "ANTICORE TOTAL" Or txtExamenes.Text = "HIV POR ELISA" Then
                MessageBox.Show("Exámen requiere Consejería de CERITS. Por favor Informe al Paciente", "MENSAJE IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            txtCantidadE.Text = ""
            lblPrecioE.Text = ""
            txtExamenes.Text = ""
            lblTipoP.Text = ""
            lblSTP.Text = ""
            txtIndicacion.Text = ""


            txtExamenes.Select()
        End If
    End Sub

    Private Sub txtIndicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIndicacion.TextChanged

    End Sub

    Private Sub dgExamenes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgExamenes.KeyDown
        If e.KeyCode = Keys.Delete And dgExamenes.Items.Count >= 1 Then
            Dim IdProcedimiento As String
            Dim Importe As String
            IdProcedimiento = dgExamenes.SelectedItems(0).SubItems(0).Text
            Importe = dgExamenes.SelectedItems(0).SubItems(4).Text
            lblTotalE.Text = Microsoft.VisualBasic.Format(Val(lblTotalE.Text) - Val(Importe), "#0.00")
            dgExamenes.Items.RemoveAt(dgExamenes.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub dgExamenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgExamenes.SelectedIndexChanged

    End Sub

    Private Function VerExa() As Boolean
        VerExa = False
        Dim I As Integer
        For I = 0 To dgExamenes.Items.Count - 1
            If dgExamenes.Items(I).SubItems(0).Text = lvFiltro.SelectedItems(0).SubItems(0).Text Then VerExa = True : Exit For
        Next
    End Function

    Private Sub lvFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvFiltro.KeyDown
        If lvFiltro.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            Select Case Filtro
                'Case "MEDICAMENTO"
                '    If cboTipoAtencion.Text <> "SIS" Then MessageBox.Show("Solo puede digitar Medicamentos a Pacientes SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                '    txtMedicamento.Enabled = False
                '    txtMedicamento.Tag = lvFiltro.SelectedItems(0).SubItems(0).Text
                '    txtMedicamento.Text = lvFiltro.SelectedItems(0).SubItems(1).Text
                '    txtMedicamento.Enabled = True
                '    lblUnidad.Text = lvFiltro.SelectedItems(0).SubItems(4).Text
                '    lblPrecioM.Text = Microsoft.VisualBasic.Format(CDbl(lvFiltro.SelectedItems(0).SubItems(2).Text), "#,##0.00")
                '    StockMed = lvFiltro.SelectedItems(0).SubItems(6).Text
                '    gbFiltro.Visible = False
                '    txtCantidadM.Text = 1
                '    txtCantidadM.Select()
                Case "EXAMENES"
                    If VerExa() Then
                        MessageBox.Show("Procedimiento ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    txtExamenes.Enabled = False
                    txtExamenes.Tag = lvFiltro.SelectedItems(0).SubItems(0).Text
                    txtExamenes.Text = lvFiltro.SelectedItems(0).SubItems(1).Text
                    txtExamenes.Enabled = True
                    lblPrecioE.Text = Microsoft.VisualBasic.Format(Val(lvFiltro.SelectedItems(0).SubItems(2).Text), "#0.00")
                    lblTipoP.Text = lvFiltro.SelectedItems(0).SubItems(5).Text
                    lblSTP.Text = lvFiltro.SelectedItems(0).SubItems(6).Text

                    gbFiltro.Visible = False
                    txtCantidadE.Text = 1
                    txtCantidadE.Select()
            End Select
        End If
    End Sub

    Private Sub lvFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvFiltro.SelectedIndexChanged

    End Sub

    Private Sub btnRetornarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarF.Click
        gbFiltro.Visible = False
    End Sub

    Private Sub cboResponsable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboResponsable.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboResponsable.SelectedValue) Then cboEnfermeraO.Select()
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged

    End Sub

    Private Sub cboEnfermeraO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEnfermeraO.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEnfermeraO.SelectedValue) Then cboTipoAtencion.Select()
    End Sub

    Private Sub cboEnfermeraO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEnfermeraO.SelectedIndexChanged

    End Sub

    Private Sub cboTipoAtencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAtencion.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoAtencion.Text <> "" Then txtSerieSIS.Select()
    End Sub

    Private Sub cboTipoAtencion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAtencion.SelectedIndexChanged

    End Sub

    Private Sub txtSerieSIS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerieSIS.KeyDown
        If e.KeyCode = Keys.Enter Then txtNumeroSIS.Select()
    End Sub

    Private Sub txtSerieSIS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerieSIS.TextChanged

    End Sub

    Private Sub txtNumeroSIS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroSIS.KeyDown
        If e.KeyCode = Keys.Enter Then txtNroPre.Select()
    End Sub

    Private Sub txtNumeroSIS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroSIS.LostFocus
        If Val(txtNumeroSIS.Text) > 0 Then
            Dim dsVer As New DataSet
            dsVer = objSIS.ConsultarLN(txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Debe verificar que este bien escrito la SERIE y NUMERO de lote SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Text = "" : txtNumeroSIS.Text = 0 : txtSerieSIS.Select() : Exit Sub
            End If
        End If
    End Sub

    Private Sub txtNumeroSIS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroSIS.TextChanged

    End Sub

    Private Sub txtNroPre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroPre.KeyDown
        If e.KeyCode = Keys.Enter Then dtpFecha.Select()
    End Sub

    Private Sub txtNroPre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroPre.LostFocus
        If Val(txtNroPre.Text) > 0 And cboTipoAtencion.Text = "SOAT/AFOCAT" Then
            Dim dsVer As New DataSet
            dsVer = objSoat.BuscarFicha(txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If Val(dsVer.Tables(0).Rows(0)("IdSoat")) <> Val(txtNroPre.Text) Then
                    MessageBox.Show("Debe verificar que el numero de Preliquidación esté bien registrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNroPre.Text = ""
                    txtNroPre.Select()
                End If
            Else
                MessageBox.Show("Debe verificar que el numero de Preliquidación esté bien registrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroPre.Text = ""
                txtNroPre.Select()
            End If
        End If
        If Val(txtNroPre.Text) > 0 And cboTipoAtencion.Text <> "SOAT/AFOCAT" Then
            Dim dsVer As New DataSet
            dsVer = objConvenio.BuscarCH(txtNroPre.Text, txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If dsVer.Tables(0).Rows(0)("Tipo") = "CONSULTA EXTERNA" Then
                    MessageBox.Show("El Convenio fue registrador como CONSULTA EXTERNA, Verifique la información en Cuentas Corrientes", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNroPre.Text = ""
                    txtNroPre.Select()
                End If
            Else
                MessageBox.Show("Debe verificar que el numero de Preliquidación esté bien registrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroPre.Text = ""
                txtNroPre.Select()
            End If
        End If
    End Sub

    Private Sub txtNroPre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroPre.TextChanged

    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtExamenes.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged

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
        End If
        'Fin de validar Codigo SIS

        'Verificar Tipo de Paciente Convenios para obtener Codigos
        Dim CodigoConvenio As String
        If cboTipoAtencion.Text <> "SOAT" And Val(txtNroPre.Text) <> 0 Then
            Dim dsConvenio As New DataSet
            dsConvenio = objConvenio.BuscarCH(txtNroPre.Text, txtHistoria.Text)
            CodigoConvenio = dsConvenio.Tables(0).Rows(0)("IdConvenio")

            If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then
                If dsConvenio.Tables(0).Rows(0)("FechaFinal") < Date.Now.ToShortDateString Then
                    MessageBox.Show("Atencion de Convenio ya fue finalizada con fecha " & dsConvenio.Tables(0).Rows(0)("FechaFinal") & ". Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Text = "COMUN" : txtNroPre.Text = "" : Exit Sub
                End If
            End If
        End If
        'Fin Validar Convenio

        'Verificar Tipo de Paciente SOAT AFOCAT
        Dim CodigoSoat As String
        If cboTipoAtencion.Text = "SOAT" Then
            Dim dsSoat As New DataSet
            dsSoat = objSoat.BuscarPH(txtNroPre.Text, txtHistoria.Text)
            If dsSoat.Tables(0).Rows.Count > 0 Then
                CodigoSoat = dsSoat.Tables(0).Rows(0)("IdSoat")

                If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Else
                'CodigoSoat = txtNroPre.Text
                MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        End If
        'Fin Validar SOAT/AFOCAT

        If cboTipoAtencion.Text = "SOAT" And txtNroPre.Text = "" Then MessageBox.Show("Debe ingresar Nro de Preliquidación de Paciente SOAT", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub
        If cboTipoAtencion.Text = "CONVENIO" And txtNroPre.Text = "" Then MessageBox.Show("Debe ingresar Nro de Preliquidación de Paciente de Convenio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub

        If MessageBox.Show("Esta seguro de Solicitar los Examenes?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            For I = 0 To dgExamenes.Items.Count - 1
                If cboTipoAtencion.Text = "COMUN" Then
                    objDetHosp.Grabar(IdHospitalizacion, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(2).Text, cboEspecialidad.Text, Date.Now.ToShortDateString, Format(Date.Now, "HH:MM"), UsuarioSistema, My.Computer.Name, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(4).Text, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text, lblPaciente.Text, dgExamenes.Items(I).SubItems(7).Text, cboResponsable.Text, cboServicio.Text, cboSubServicio.Text, cboEspecialidad.Text)
                Else
                    objDetHosp.GrabarCancelado(IdHospitalizacion, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(2).Text, cboEspecialidad.Text, Date.Now.ToShortDateString, Format(Date.Now, "HH:MM"), UsuarioSistema, My.Computer.Name, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(4).Text, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text, lblPaciente.Text, dgExamenes.Items(I).SubItems(7).Text, cboResponsable.Text, cboServicio.Text, cboSubServicio.Text, cboEspecialidad.Text)
                End If

                'Si Paciente es SIS
                If cboTipoAtencion.Text = "SIS" Then
                    objSIS.GrabarProcedimientosN(CodigoSIS, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, UsuarioSistema, My.Computer.Name, Date.Now.ToShortDateString, Format(Date.Now, "HH:MM"))
                End If
                'Si Paciente es de Convenio
                If cboTipoAtencion.Text <> "SIS" And cboTipoAtencion.Text <> "COMUN" And cboTipoAtencion.Text <> "SOAT/AFOCAT" Then
                    objConvenio.GrabarProcedimientos(CodigoConvenio, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Format(Date.Now, "HH:MM"), UsuarioSistema, My.Computer.Name, dtpFecha.Value.ToShortDateString, dtpFecha.Value.ToShortDateString)
                End If
                'Si Paciente es SOAT
                If cboTipoAtencion.Text = "SOAT/AFOCAT" Then
                    objSoat.GrabarDetalle(CodigoSoat, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, 3, Date.Now.ToString, Date.Now.ToString, Format(Date.Now, "HH:MM"), UsuarioSistema, My.Computer.Name)
                End If
            Next
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodigo.Click
        frmCodigo.Show()
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If lvTabla.SelectedItems(0).SubItems(5).Text = "" Then
                If MessageBox.Show("Esta seguro de Anular Procedimiento?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim Motivo As String
                    Motivo = InputBox("Ingresar Motivo de Anulación de Procedimiento", "Datos de Anulación")
                    If Motivo = "" Then MessageBox.Show("Debe ingresar motivo de anulación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                    objDetHosp.Anular(lvTabla.SelectedItems(0).SubItems(0).Text, UsuarioSistema, Date.Now.ToShortDateString, Format(Date.Now, "HH:MM"), My.Computer.Name)
                    lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
                End If
            Else
                MessageBox.Show("Procedimiento ya fue recibido en el Servicio.", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
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

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            If lvTabla.SelectedItems(0).SubItems(9).Text = "" Then btnPendiente.Enabled = True
        Else
            btnPendiente.Enabled = False
        End If
    End Sub

    Private Sub btnPendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPendiente.Click
        If MessageBox.Show("Está seguro de Asignar Pendiente de Pago?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objDetHosp.GrabarPendiente(lvTabla.SelectedItems(0).SubItems(0).Text, UsuarioSistema, Date.Now.ToShortDateString, My.Computer.Name, Date.Now.ToShortTimeString)
            lvTabla.SelectedItems(0).SubItems(9).Text = Date.Now.ToShortDateString
            btnPendiente.Enabled = False
        End If
    End Sub
End Class