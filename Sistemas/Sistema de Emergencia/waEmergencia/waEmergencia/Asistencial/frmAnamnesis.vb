Public Class frmAnamnesis
    Dim objIngreso As New clsEmergenciaIngreso
    Dim objConsulta As New clsEmergenciaIngreso_Consulta
    Dim objHistoria As New clsHistoria
    Dim objEstadoCivil As New clsEstadoCivil
    Dim objCie10 As New clsCIE10HE
    Dim objCentroSalud As New clsCentroSaludSIS
    Dim objServicioItem As New clsServicioItem
    Dim objDetalleSer As New clsEmergenciaSer
    Dim objSoat As New clsSOAT
    Dim objSIS As New clsSIS
    Dim objConvenio As New clsConvenio
    Dim objCondicionAlta As New clsCondicionAlta
    Dim objTipoAlta As New clsTipoAlta
    Dim objDestinoFinal As New clsDestinoFinal
    Dim objMedico As New clsMedico
    Dim objAlta As New clsEmergenciaIngreso_Alta
    Dim objTipoTarifar As New clsTipoTarifa
    Dim objServicio As New clsServicioEmergencia

    Dim Oper As Integer
    Dim CodigoIngreso As String
    Dim Filtro As String
    Dim Tipo As String

    Private Sub Total()
        Dim I As Integer
        lblTotal.Text = "0.00"
        For I = 0 To lvTabla.Items.Count - 1
            lblTotal.Text = Val(lblTotal.Text) + Val(lvTabla.Items(I).SubItems(4).Text)
        Next
        lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#,##0.00")
    End Sub

    Private Sub Botones(Nuevo As Boolean, Grabar As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Public Sub CalcularEdad(FechaActual As Date, FechaNacimiento As Date)
        Dim Dias As Integer, Meses As Integer, Años As Integer
        Dim DiasMes As Integer
        Dim dfin, dinicio As Date
        Dim EdadA, EdadM, EdadD As String
        dfin = FechaActual
        dinicio = FechaNacimiento
        Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
        Meses = DatePart("m", dfin) - DatePart("m", dinicio)
        Años = DateDiff("yyyy", dinicio, dfin)

        If Meses = 0 And Años = 0 Then
            EdadA = 0
            EdadM = 0
            Dias = Math.Abs(Dias)
            EdadD = Dias
        Else
            'Verificar Dias
            If Dias < 0 Then
                DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
                Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
                Meses = Meses - 1
            End If
            If Meses < 0 Then
                Meses = 12 + Meses
                Años = Años - 1
            End If
            EdadA = Años
            EdadM = Meses
            EdadD = Dias

            EdadD = Microsoft.VisualBasic.Day(FechaNacimiento)
            If Val(EdadD) > FechaActual.Day Then
                EdadD = Val(EdadD) - FechaActual.Day
            ElseIf Val(EdadD) < FechaActual.Day Then
                If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                EdadD = FechaActual.Day - EdadD
                EdadD = DameDiasMes(FechaActual.Month) - EdadD
            Else
                EdadD = 0
            End If
        End If
        lblEdad.Text = EdadA
        lblTEdad.Text = "A"
        lblEdadM.Text = EdadM
        lblTEdadM.Text = "M"
        lblEdadD.Text = EdadD
        lblTEdadD.Text = "D"

        'If Val(EdadA) > 0 Then
        '    lblEdad.Text = EdadA
        '    lblTEdad.Text = "A"
        'ElseIf Val(EdadM) > 0 Then
        '    lblEdad.Text = EdadM
        '    lblTEdad.Text = "M"
        'Else
        '    lblEdad.Text = EdadD
        '    lblTEdad.Text = "D"
        'End If
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            If dsHistorias.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                dtpFechaNcto.Value = dsHistorias.Tables(0).Rows(0)("FNacimiento").ToString
            Else
                dtpFecha.Value = InputBox("Ingrear Fecha de Nacimiento de Paciente", "Información de Paciente")
            End If

            CalcularEdad(dtpFecha.Value, dtpFechaNcto.Value)

            lblGrado.Text = dsHistorias.Tables(0).Rows(0)("GradoInstruccion").ToString

            'Estado Civil
            dsEC = objEstadoCivil.DameDes(Val(dsHistorias.Tables(0).Rows(0)("EstadoCivil").ToString))
            If dsEC.Tables(0).Rows.Count > 0 Then
                lblEstadoCivil.Text = dsEC.Tables(0).Rows(0)("Descripcion")
            Else
                lblEstadoCivil.Text = "NINGUNO"
            End If

            lblGrado.Text = dsHistorias.Tables(0).Rows(0)("GradoInstruccion").ToString
            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
            lblDomicilio.Text = dsHistorias.Tables(0).Rows(0)("Direccion").ToString
            lblDpto.Text = dsHistorias.Tables(0).Rows(0)("Departamento").ToString
            lblProvincia.Text = dsHistorias.Tables(0).Rows(0)("Provincia").ToString
            lblDistrito.Text = dsHistorias.Tables(0).Rows(0)("Distrito").ToString
            dtpFechaNcto.Select()
            btnGrabar.Enabled = True
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmAnamnesis_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        rbDx1.Checked = True
        gbPaciente.Left = 12
        gbPaciente.Top = 77
        gbCIE.BringToFront()
        gbCIE.Left = 6
        gbCIE.Top = 13
        gbAD.BringToFront()
        gbAD.Left = 15
        gbAD.Top = 30
        Me.Text = "ANAMNESIS - Dr(a) " & NomMedico

        'CentroSaludSIS
        'Dim dsCentro As New DataSet
        'dsCentro = objCentroSalud.Combo
        'cboDesOrigen.DataSource = dsCentro.Tables(0)
        'cboDesOrigen.DisplayMember = "Descripcion"
        'cboDesOrigen.ValueMember = "IdCentro"

        ''Combos de Alta Medica
        'CondicionAlta
        Dim dsCondicion As New DataSet
        dsCondicion = objCondicionAlta.Combo
        cboCondicion.DataSource = dsCondicion.Tables(0)
        cboCondicion.DisplayMember = "Descripcion"
        cboCondicion.ValueMember = "CodCondicion"

        'TipoAlta
        Dim dsTipoAlta As New DataSet
        dsTipoAlta = objTipoAlta.Combo
        cboTipoAlta.DataSource = dsTipoAlta.Tables(0)
        cboTipoAlta.DisplayMember = "Descripcion"
        cboTipoAlta.ValueMember = "IdTipoAlta"

        'DestinoFInal
        Dim dsDestino As New DataSet
        dsDestino = objDestinoFinal.Combo
        cboDestino.DataSource = dsDestino.Tables(0)
        cboDestino.DisplayMember = "Descripcion"
        cboDestino.ValueMember = "CodDestino"

        'Medico
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"

        'Medico Ingreso
        Dim dsMedicoIng As New DataSet
        dsMedicoIng = objMedico.Medico_BuscarNombres("")
        cboMedIng.DataSource = dsMedicoIng.Tables(0)
        cboMedIng.DisplayMember = "NMedico"
        cboMedIng.ValueMember = "IdMedico"

        'Tipo Tarifa
        Dim dsTT As New DataSet
        dsTT = objTipoTarifar.Combo
        cboTipoAten.DataSource = dsTT.Tables(0)
        cboTipoAten.DisplayMember = "Descripcion"
        cboTipoAten.ValueMember = "IdTipoTarifa"

        'Servicio Emergencia
        Dim dsServicio As New DataSet
        dsServicio = objServicio.Buscar
        lblServicio.DataSource = dsServicio.Tables(0)
        lblServicio.DisplayMember = "Descripcion"
        lblServicio.ValueMember = "IdServicio"
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click

        gbCIE.Visible = False
        gbAD.Visible = False
        gbSI.Visible = False
        gbAlta.Visible = False
        gbAlta.Visible = False
        gbCIEA.Visible = False
        gbLabCE.Visible = False
        gbTipoAtencion.Visible = False
        dtpFecha.Value = Date.Now
        gbPaciente.Visible = False
        Botones(True, False, False, True)
        btnBuscarP.Enabled = False
        ControlesAD(Me, False)
        LimpiarTab(tbAnamnesis.TabPages(0))
        LimpiarTab(tbAnamnesis.TabPages(1))
        'Limpiar(Me)


        MenuStrip1.Enabled = False
        cboTipoIngreso.Text = "NUEVO"
        cboTipoAtenEmer.Text = "EMERGENCIA"
        tbAnamnesis.Enabled = False
        'Tipo Tarifa
        Dim dsTT As New DataSet
        dsTT = objTipoTarifar.Combo
        cboTipoAtencion.DataSource = dsTT.Tables(0)
        cboTipoAtencion.DisplayMember = "Descripcion"
        cboTipoAtencion.ValueMember = "IdTipoTarifa"
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1

        dtpFecha.Value = Date.Now
        txtHora.Text = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboOrigen.Text = "CASA"
        'cboDesOrigen.Text = "NINGUNO"
        btnBuscarP.Enabled = True
        cboTipoIngreso.Text = "NUEVO"
        cboTipoAtenEmer.Text = "EMERGENCIA"
        cboSala.Text = "NO"
        cboRCP.Text = "NO"
        tbAnamnesis.Enabled = True
        dtpFecha.Select()
        txtHistoria.Select()

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtHora.Text <> "" Then txtHistoria.Select()
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            lblSerieSIS.Text = ""
            lblNumeroSIS.Text = ""
            lblPreliquidacion.Text = ""
            BuscarHistoria()
            Dim dsVer As New DataSet
            dsVer = objIngreso.VerificarIngreso(txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                CodigoIngreso = dsVer.Tables(0).Rows(0)("IdIngreso")
                lblServicio.Text = dsVer.Tables(0).Rows(0)("Especialidad")
                cboMedIng.Text = dsVer.Tables(0).Rows(0)("Medico")
                lblIngEsta.Text = dsVer.Tables(0).Rows(0)("IngEstablecimiento").ToString
                lblIngSer.Text = dsVer.Tables(0).Rows(0)("IngServicio").ToString
                dtpFecha.Value = dsVer.Tables(0).Rows(0)("FechaIngreso")
                txtHora.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblFechaAdmision.Text = dsVer.Tables(0).Rows(0)("FechaIngreso")
                lblHoraAdmision.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblInformante.Text = dsVer.Tables(0).Rows(0)("Conyuge")
                cboTipoAten.Text = dsVer.Tables(0).Rows(0)("TipoAtencion").ToString
                cboTipoIngreso.Text = dsVer.Tables(0).Rows(0)("TipoIngreso").ToString
                cboTipoAtenEmer.Text = dsVer.Tables(0).Rows(0)("TipoEmergencia").ToString
                cboArea.SelectedItem = dsVer.Tables(0).Rows(0)("area").ToString
                cboPrioridad.SelectedItem = dsVer.Tables(0).Rows(0)("prioridad").ToString
               

                If dsVer.Tables(0).Rows(0)("TipoAtencion").ToString = "SIS" Then
                    lblSerieSIS.Text = dsVer.Tables(0).Rows(0)("SerieSIS").ToString
                    lblNumeroSIS.Text = dsVer.Tables(0).Rows(0)("NumeroSIS").ToString
                ElseIf dsVer.Tables(0).Rows(0)("TipoAtencion").ToString = "SOAT/AFOCAT" Then
                    lblPreliquidacion.Text = dsVer.Tables(0).Rows(0)("Preliquidacion").ToString
                ElseIf cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Then
                    lblPreliquidacion.Text = dsVer.Tables(0).Rows(0)("Preliquidacion").ToString
                Else
                    lblSerieSIS.Text = ""
                    lblNumeroSIS.Text = ""
                    lblPreliquidacion.Text = ""
                End If

                cboOrigen.Select()

                Dim dsConsulta As New DataSet
                dsConsulta = objConsulta.ConsultaBuscar(CodigoIngreso)
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    dtpFecha.Value = dsConsulta.Tables(0).Rows(0)("Fecha")
                    txtHora.Text = dsConsulta.Tables(0).Rows(0)("Hora")
                    txtTalla.Text = dsConsulta.Tables(0).Rows(0)("Talla")
                    txtPeso.Text = dsConsulta.Tables(0).Rows(0)("Peso")
                    txtPulso.Text = dsConsulta.Tables(0).Rows(0)("Pulso")
                    txtPresion.Text = dsConsulta.Tables(0).Rows(0)("Presion")
                    txtTemperatura.Text = dsConsulta.Tables(0).Rows(0)("Temperatura")
                    txtMolestia.Text = dsConsulta.Tables(0).Rows(0)("MolestiaPrincipal")
                    txtTiempoEnf.Text = dsConsulta.Tables(0).Rows(0)("TiempoEnfermedad")
                    txtFormaInicio.Text = dsConsulta.Tables(0).Rows(0)("FormaInicio")
                    txtC.Text = dsConsulta.Tables(0).Rows(0)("C")
                    txtEnfermedadAct.Text = dsConsulta.Tables(0).Rows(0)("EnfermedadActual")
                    txtApetito.Text = dsConsulta.Tables(0).Rows(0)("Apetito")
                    txtSed.Text = dsConsulta.Tables(0).Rows(0)("Sed")
                    txtOrina.Text = dsConsulta.Tables(0).Rows(0)("Orina")
                    txtDeposiciones.Text = dsConsulta.Tables(0).Rows(0)("Deposiciones")
                    txtSueño.Text = dsConsulta.Tables(0).Rows(0)("Sueño")
                    txtPesoFB.Text = dsConsulta.Tables(0).Rows(0)("PesoFB")
                    txtExamenFisico.Text = dsConsulta.Tables(0).Rows(0)("ExamenFisico")
                    txtCie1.Text = dsConsulta.Tables(0).Rows(0)("Cie1")
                    txtDes1.Enabled = False
                    txtDes1.Text = dsConsulta.Tables(0).Rows(0)("DesCie1")
                    txtDes1.Enabled = True
                    txtLab1.Text = dsConsulta.Tables(0).Rows(0)("Lab1")
                    cboTD1.Text = dsConsulta.Tables(0).Rows(0)("TD1")
                    txtCie2.Text = dsConsulta.Tables(0).Rows(0)("Cie2")
                    txtDes2.Enabled = False
                    txtDes2.Text = dsConsulta.Tables(0).Rows(0)("DesCie2")
                    txtDes2.Enabled = True
                    txtLab2.Text = dsConsulta.Tables(0).Rows(0)("Lab2")
                    cboTD2.Text = dsConsulta.Tables(0).Rows(0)("TD2")
                    txtCie3.Text = dsConsulta.Tables(0).Rows(0)("Cie3")
                    txtDes3.Enabled = False
                    txtDes3.Text = dsConsulta.Tables(0).Rows(0)("DesCie3")
                    txtDes3.Enabled = True
                    txtLab3.Text = dsConsulta.Tables(0).Rows(0)("Lab3")
                    cboTD3.Text = dsConsulta.Tables(0).Rows(0)("TD3")
                    txtCie4.Text = dsConsulta.Tables(0).Rows(0)("Cie4")
                    txtDes4.Enabled = False
                    txtDes4.Text = dsConsulta.Tables(0).Rows(0)("DesCie4")
                    txtDes4.Enabled = True
                    txtLab4.Text = dsConsulta.Tables(0).Rows(0)("Lab4")
                    cboTD4.Text = dsConsulta.Tables(0).Rows(0)("TD4")
                    txtCie5.Text = dsConsulta.Tables(0).Rows(0)("Cie5")
                    txtDes5.Enabled = False
                    txtDes5.Text = dsConsulta.Tables(0).Rows(0)("DesCie5")
                    txtDes5.Enabled = True
                    txtLab5.Text = dsConsulta.Tables(0).Rows(0)("Lab5")
                    cboTD5.Text = dsConsulta.Tables(0).Rows(0)("TD5")
                    txtCie6.Text = dsConsulta.Tables(0).Rows(0)("Cie6")
                    txtDes6.Enabled = False
                    txtDes6.Text = dsConsulta.Tables(0).Rows(0)("DesCie6")
                    txtDes6.Enabled = True
                    txtLab6.Text = dsConsulta.Tables(0).Rows(0)("Lab6")
                    cboTD6.Text = dsConsulta.Tables(0).Rows(0)("TD6")
                    txtAntPat.Text = dsConsulta.Tables(0).Rows(0)("AntecedentesPat")
                    txtAntFam.Text = dsConsulta.Tables(0).Rows(0)("AntecedentesFam")
                    cboOrigen.Text = dsConsulta.Tables(0).Rows(0)("Origen")
                    cboDesOrigen.Text = dsConsulta.Tables(0).Rows(0)("DesOrigen")
                    cboSala.Text = dsConsulta.Tables(0).Rows(0)("Sala")
                    cboRCP.Text = dsConsulta.Tables(0).Rows(0)("RCP")
                    rbDx1.Checked = dsConsulta.Tables(0).Rows(0)("Dx1")
                    rbDx2.Checked = dsConsulta.Tables(0).Rows(0)("Dx2")
                    rbDx3.Checked = dsConsulta.Tables(0).Rows(0)("Dx3")
                    rbDx4.Checked = dsConsulta.Tables(0).Rows(0)("Dx4")
                    rbDx5.Checked = dsConsulta.Tables(0).Rows(0)("Dx5")
                    rbDx6.Checked = dsConsulta.Tables(0).Rows(0)("Dx6")
                    txtTalla.Select()
                    Oper = 2
                End If
                MenuStrip1.Enabled = True
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub txtTalla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtPeso.Select()
    End Sub

    Private Sub txtTalla_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtPeso_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtPulso.Select()
    End Sub

    Private Sub txtPeso_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtPulso_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtPresion.Select()
    End Sub

    Private Sub txtPulso_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtPresion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtTemperatura.Select()
    End Sub

    Private Sub txtPresion_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtTemperatura_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtMolestia.Select()
    End Sub

    Private Sub txtTemperatura_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtTiempoEnf_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtFormaInicio.Select()
    End Sub

    Private Sub txtTiempoEnf_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtFormaInicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtC.Select()
    End Sub

    Private Sub txtFormaInicio_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtC_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtEnfermedadAct.Select()
    End Sub

    Private Sub txtC_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtApetito_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtSed.Select()
    End Sub

    Private Sub txtApetito_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtSed_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtOrina.Select()
    End Sub

    Private Sub txtSed_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtOrina_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtDeposiciones.Select()
    End Sub

    Private Sub txtDeposiciones_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtSueño.Select()
    End Sub

    Private Sub txtSueño_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtPesoFB.Select()
    End Sub

    Private Sub txtPesoFB_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtExamenFisico.Select()
    End Sub

    Private Sub txtCie1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie1.KeyDown
        If e.KeyCode = Keys.Enter And txtCie1.Text = "" Then txtDes1.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie1.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie1.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If dsVer.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                    MessageBox.Show("Diagnóstico no es conciderado como Emergencia...", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCie1.Text = ""
                    txtDes1.Text = ""
                    txtCie1.Select()
                    Exit Sub
                End If
                txtDes1.Enabled = False
                txtDes1.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes1.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD1.Text = "DEFINITIVO"
                txtLab1.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie1.Text = ""
                txtDes1.Text = ""
                txtCie1.Select()
            End If
        End If
    End Sub

    Private Sub txtCie1_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtLab1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD1.Select()
    End Sub

    Private Sub txtDes1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes1.TextChanged
        If txtDes1.Text <> "" And txtDes1.Enabled Then txtFiltro.Text = txtDes1.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "1"
    End Sub

    Private Sub btnRetornar_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornar.Click
        gbCIE.Visible = False
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If txtFiltro.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsCIE As New DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvCIE.Items.Clear()
            dsCIE = objCie10.BuscarFiltro(txtFiltro.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvCIE.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Definitivo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Sexo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MinEdad"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MinTipo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MaxEdad"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MaxTipo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Emergencia"))
            Next
            If lvCIE.Items.Count > 0 Then lvCIE.Select()
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub lvCIE_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvCIE.KeyDown
        If e.KeyCode = Keys.Enter And lvCIE.SelectedItems.Count > 0 Then
            'Verificar Diagnóstico de Emergencia
            If lvCIE.SelectedItems(0).SubItems(8).Text = "NO" Then
                MessageBox.Show("Diagnóstico no es conciderado como Emergencia...", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Select Case Filtro
                Case "1"
                    txtCie1.Text = lvCIE.SelectedItems(0).SubItems(0).Text
                    txtDes1.Enabled = False
                    txtDes1.Text = lvCIE.SelectedItems(0).SubItems(1).Text
                    txtDes1.Enabled = True
                    If lvCIE.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD1.Text = "DEFINITIVO" Else cboTD1.Text = ""
                    txtLab1.Select()
                    gbCIE.Visible = False
                Case "2"
                    txtCie2.Text = lvCIE.SelectedItems(0).SubItems(0).Text
                    txtDes2.Enabled = False
                    txtDes2.Text = lvCIE.SelectedItems(0).SubItems(1).Text
                    txtDes2.Enabled = True
                    If lvCIE.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD2.Text = "DEFINITIVO" Else cboTD2.Text = ""
                    txtLab2.Select()
                    gbCIE.Visible = False
                Case "3"
                    txtCie3.Text = lvCIE.SelectedItems(0).SubItems(0).Text
                    txtDes3.Enabled = False
                    txtDes3.Text = lvCIE.SelectedItems(0).SubItems(1).Text
                    txtDes3.Enabled = True
                    If lvCIE.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD3.Text = "DEFINITIVO" Else cboTD3.Text = ""
                    txtLab3.Select()
                    gbCIE.Visible = False
                Case "4"
                    txtCie4.Text = lvCIE.SelectedItems(0).SubItems(0).Text
                    txtDes4.Enabled = False
                    txtDes4.Text = lvCIE.SelectedItems(0).SubItems(1).Text
                    txtDes4.Enabled = True
                    If lvCIE.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD4.Text = "DEFINITIVO" Else cboTD4.Text = ""
                    txtLab4.Select()
                    gbCIE.Visible = False
                Case "5"
                    txtCie5.Text = lvCIE.SelectedItems(0).SubItems(0).Text
                    txtDes5.Enabled = False
                    txtDes5.Text = lvCIE.SelectedItems(0).SubItems(1).Text
                    txtDes5.Enabled = True
                    If lvCIE.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD5.Text = "DEFINITIVO" Else cboTD5.Text = ""
                    txtLab5.Select()
                    gbCIE.Visible = False
                Case "6"
                    txtCie6.Text = lvCIE.SelectedItems(0).SubItems(0).Text
                    txtDes6.Enabled = False
                    txtDes6.Text = lvCIE.SelectedItems(0).SubItems(1).Text
                    txtDes6.Enabled = True
                    If lvCIE.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD6.Text = "DEFINITIVO" Else cboTD6.Text = ""
                    txtLab6.Select()
                    gbCIE.Visible = False
            End Select
        End If
    End Sub

    Private Sub lvCIE_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCIE.SelectedIndexChanged

    End Sub

    Private Sub cboTD1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And cboTD1.Text <> "" Then txtCie2.Select()
    End Sub

    Private Sub cboTD1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie2.Text = "" Then txtAntPat.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD2.Text <> "" Then txtCie3.Select()
    End Sub

    Private Sub cboTD2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie3.Text = "" Then txtAntPat.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD3.Text <> "" Then txtCie4.Select()
    End Sub

    Private Sub cboTD3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie4.Text = "" Then txtAntPat.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD4.Text <> "" Then txtCie5.Select()
    End Sub

    Private Sub cboTD4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie5.Text = "" Then txtAntPat.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD5.Text <> "" Then txtCie6.Select()
    End Sub

    Private Sub cboTD5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie6.Text = "" Then txtAntPat.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD6.Text <> "" Then txtAntPat.Select()
    End Sub

    Private Sub cboTD6_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtCie2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie2.KeyDown
        If e.KeyCode = Keys.Enter And txtCie2.Text = "" Then txtDes2.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie2.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie2.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If dsVer.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                    MessageBox.Show("Diagnóstico no es conciderado como Emergencia...", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCie2.Text = ""
                    txtDes1.Text = ""
                    txtCie2.Select()
                    Exit Sub
                End If
                txtDes2.Enabled = False
                txtDes2.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes2.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD2.Text = "DEFINITIVO"
                txtLab2.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie2.Text = ""
                txtDes2.Text = ""
                txtCie2.Select()
            End If
        End If
    End Sub

    Private Sub txtCie2_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtCie3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie3.KeyDown
        If e.KeyCode = Keys.Enter And txtCie3.Text = "" Then txtDes3.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie3.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie3.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If dsVer.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                    MessageBox.Show("Diagnóstico no es conciderado como Emergencia...", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCie3.Text = ""
                    txtDes3.Text = ""
                    txtCie3.Select()
                    Exit Sub
                End If
                txtDes3.Enabled = False
                txtDes3.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes3.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD3.Text = "DEFINITIVO"
                txtLab3.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie3.Text = ""
                txtDes3.Text = ""
                txtCie3.Select()
            End If
        End If
    End Sub

    Private Sub txtCie3_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtCie4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie4.KeyDown
        If e.KeyCode = Keys.Enter And txtCie4.Text = "" Then txtDes4.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie4.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie4.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If dsVer.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                    MessageBox.Show("Diagnóstico no es conciderado como Emergencia...", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCie4.Text = ""
                    txtDes4.Text = ""
                    txtCie4.Select()
                    Exit Sub
                End If
                txtDes4.Enabled = False
                txtDes4.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes4.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD4.Text = "DEFINITIVO"
                txtLab4.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie4.Text = ""
                txtDes4.Text = ""
                txtCie4.Select()
            End If
        End If
    End Sub

    Private Sub txtCie4_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtCie5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie5.KeyDown
        If e.KeyCode = Keys.Enter And txtCie5.Text = "" Then txtDes5.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie5.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie5.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If dsVer.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                    MessageBox.Show("Diagnóstico no es conciderado como Emergencia...", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCie5.Text = ""
                    txtDes5.Text = ""
                    txtCie5.Select()
                    Exit Sub
                End If
                txtDes5.Enabled = False
                txtDes5.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes5.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD5.Text = "DEFINITIVO"
                txtLab5.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie5.Text = ""
                txtDes5.Text = ""
                txtCie5.Select()
            End If
        End If
    End Sub

    Private Sub txtCie5_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtCie6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie6.KeyDown
        If e.KeyCode = Keys.Enter And txtCie6.Text = "" Then txtDes6.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie6.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie6.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If dsVer.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                    MessageBox.Show("Diagnóstico no es conciderado como Emergencia...", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCie6.Text = ""
                    txtDes6.Text = ""
                    txtCie6.Select()
                    Exit Sub
                End If
                txtDes6.Enabled = False
                txtDes6.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes6.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD6.Text = "DEFINITIVO"
                txtLab6.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie6.Text = ""
                txtDes6.Text = ""
                txtCie6.Select()
            End If
        End If
    End Sub

    Private Sub txtCie6_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtLab2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD2.Select()
    End Sub

    Private Sub txtLab2_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtLab3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD3.Select()
    End Sub

    Private Sub txtLab4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD4.Select()
    End Sub

    Private Sub txtLab5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD5.Select()
    End Sub

    Private Sub txtLab6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD6.Select()
    End Sub

    Private Sub txtDes2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes2.TextChanged
        If txtDes2.Text <> "" And txtDes2.Enabled Then rbDx2.Enabled = True : txtFiltro.Text = txtDes2.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "2"
        If txtDes2.TextLength >= 3 Then
            rbDx2.Enabled = True
        Else
            rbDx2.Enabled = False
        End If
    End Sub

    Private Sub txtDes3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes3.TextChanged
        If txtDes3.Text <> "" And txtDes3.Enabled Then rbDx3.Enabled = True : txtFiltro.Text = txtDes3.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "3"
        If txtDes3.TextLength >= 3 Then
            rbDx3.Enabled = True
        Else
            rbDx3.Enabled = False
        End If

    End Sub

    Private Sub txtDes4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes4.KeyDown
        If txtDes4.Text <> "" And txtDes4.Enabled Then rbDx4.Enabled = True : txtFiltro.Text = txtDes4.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "4"
        If txtDes4.TextLength >= 3 Then
            rbDx4.Enabled = True
        Else
            rbDx4.Enabled = False
        End If

    End Sub

    Private Sub txtDes5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes6.TextChanged
        If txtDes5.Text <> "" And txtDes5.Enabled Then rbDx5.Enabled = True : txtFiltro.Text = txtDes5.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "5"
        If txtDes5.TextLength >= 3 Then
            rbDx5.Enabled = True
        Else
            rbDx5.Enabled = False
        End If
    End Sub

    Private Sub txtDes6_TextChanged(sender As System.Object, e As System.EventArgs)
        If txtDes6.Text <> "" And txtDes6.Enabled Then rbDx6.Enabled = True : txtFiltro.Text = txtDes6.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "6"
        If txtDes6.TextLength >= 3 Then
            rbDx6.Enabled = True
        Else
            rbDx6.Enabled = False
        End If

    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de guardar la Información", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If txtCie1.Text = "" Then MessageBox.Show("Debe ingresar al menos un Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie1.Select() : Exit Sub
            If txtDes1.Text = "" Then MessageBox.Show("Debe ingresar información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes1.Select() : Exit Sub
            If cboTD1.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD1.Select() : Exit Sub

            If txtCie2.Text <> "" And txtDes2.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes2.Select() : Exit Sub
            If txtCie3.Text <> "" And txtDes3.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes3.Select() : Exit Sub
            If txtCie4.Text <> "" And txtDes4.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes4.Select() : Exit Sub
            If txtCie5.Text <> "" And txtDes5.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes5.Select() : Exit Sub
            If txtCie6.Text <> "" And txtDes6.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes6.Select() : Exit Sub

            If txtCie2.Text <> "" And cboTD2.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD2.Select() : Exit Sub
            If txtCie3.Text <> "" And cboTD3.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD3.Select() : Exit Sub
            If txtCie4.Text <> "" And cboTD4.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD4.Select() : Exit Sub
            If txtCie5.Text <> "" And cboTD5.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD5.Select() : Exit Sub
            If txtCie6.Text <> "" And cboTD6.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD6.Select() : Exit Sub
            If cboPrioridad.SelectedIndex = 0 Then MessageBox.Show("Debe definir prioridad Atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If cboArea.SelectedIndex = 0 Then MessageBox.Show("Debe definir Area", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If cboDesOrigen.SelectedIndex = 0 Then MessageBox.Show("Debe definir motivo Atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            'Verificar Diagnosticos Ingresados
            Dim dsValCie As New DataSet
            If txtCie1.Text <> "" Then
                dsValCie = objCie10.BuscarCodigo(txtCie1.Text)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie1.Text = "" : txtDes1.Text = "" : txtCie1.Select() : Exit Sub
                Else
                    If dsValCie.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                        MessageBox.Show("Diagnóstico no es conciderado como Emergencia... Modifique el Diagnóstico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCie1.Text = ""
                        txtDes1.Text = ""
                        txtCie1.Select()
                        Exit Sub
                    End If
                    txtDes1.Enabled = False
                    txtDes1.Text = dsValCie.Tables(0).Rows(0)("desc_enf")
                    txtDes1.Enabled = True
                End If

            End If

            If txtCie2.Text <> "" Then
                dsValCie = objCie10.BuscarCodigo(txtCie2.Text)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie2.Text = "" : txtDes2.Text = "" : txtCie2.Select() : Exit Sub
                Else
                    If dsValCie.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                        MessageBox.Show("Diagnóstico no es conciderado como Emergencia... Modifique el Diagnóstico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCie2.Text = ""
                        txtDes2.Text = ""
                        txtCie2.Select()
                        Exit Sub
                    End If
                    txtDes2.Enabled = False
                    txtDes2.Text = dsValCie.Tables(0).Rows(0)("desc_enf")
                    txtDes2.Enabled = True
                End If
            End If

            If txtCie3.Text <> "" Then
                dsValCie = objCie10.BuscarCodigo(txtCie3.Text)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie3.Text = "" : txtDes3.Text = "" : txtCie3.Select() : Exit Sub
                Else
                    If dsValCie.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                        MessageBox.Show("Diagnóstico no es conciderado como Emergencia... Modifique el Diagnóstico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCie3.Text = ""
                        txtDes3.Text = ""
                        txtCie3.Select()
                        Exit Sub
                    End If
                    txtDes3.Enabled = False
                    txtDes3.Text = dsValCie.Tables(0).Rows(0)("desc_enf")
                    txtDes3.Enabled = True
                End If
            End If

            If txtCie4.Text <> "" Then
                dsValCie = objCie10.BuscarCodigo(txtCie4.Text)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie4.Text = "" : txtDes4.Text = "" : txtCie4.Select() : Exit Sub
                Else
                    If dsValCie.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                        MessageBox.Show("Diagnóstico no es conciderado como Emergencia... Modifique el Diagnóstico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCie4.Text = ""
                        txtDes4.Text = ""
                        txtCie4.Select()
                        Exit Sub
                    End If
                    txtDes4.Enabled = False
                    txtDes4.Text = dsValCie.Tables(0).Rows(0)("desc_enf")
                    txtDes4.Enabled = True
                End If
            End If

            If txtCie5.Text <> "" Then
                dsValCie = objCie10.BuscarCodigo(txtCie5.Text)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie5.Text = "" : txtDes5.Text = "" : txtCie5.Select() : Exit Sub
                Else
                    If dsValCie.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                        MessageBox.Show("Diagnóstico no es conciderado como Emergencia... Modifique el Diagnóstico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCie5.Text = ""
                        txtDes5.Text = ""
                        txtCie5.Select()
                        Exit Sub
                    End If
                    txtDes5.Enabled = False
                    txtDes5.Text = dsValCie.Tables(0).Rows(0)("desc_enf")
                    txtDes5.Enabled = True
                End If
            End If

            If txtCie6.Text <> "" Then
                dsValCie = objCie10.BuscarCodigo(txtCie6.Text)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie6.Text = "" : txtDes6.Text = "" : txtCie6.Select() : Exit Sub
                Else
                    If dsValCie.Tables(0).Rows(0)("EMERGENCIA") = "NO" Then
                        MessageBox.Show("Diagnóstico no es conciderado como Emergencia... Modifique el Diagnóstico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCie6.Text = ""
                        txtDes6.Text = ""
                        txtCie6.Select()
                        Exit Sub
                    End If
                    txtDes6.Enabled = False
                    txtDes6.Text = dsValCie.Tables(0).Rows(0)("desc_enf")
                    txtDes6.Enabled = True
                End If
            End If

            objIngreso.CambiarMedicoIng(CodigoIngreso, cboMedIng.Text)
            objIngreso.CambiarTipoAten(CodigoIngreso, cboTipoAten.Text)
            objIngreso.CambiarEspecialidadIng(CodigoIngreso, lblServicio.Text)
            objIngreso.ModificarPrioridadArea(CodigoIngreso, cboPrioridad.Text, cboArea.Text)
            If Val(lblNumeroSIS.Text) > 0 Then
                objIngreso.NumeroSIS(CodigoIngreso, lblSerieSIS.Text, lblNumeroSIS.Text)
            End If
            If Val(lblPreliquidacion.Text) > 0 Then
                objIngreso.NumeroPre(CodigoIngreso, lblPreliquidacion.Text)
            End If

            'Grabar Tipo de Ingreso y Emergencia
            objIngreso.TipoIngreso(CodigoIngreso, cboTipoIngreso.Text, cboTipoAtenEmer.Text)


            If Oper = 1 Then
                objConsulta.GrabarSala(CodigoIngreso, dtpFecha.Value.ToShortDateString, txtHora.Text, txtTalla.Text, txtPeso.Text, txtPulso.Text, txtPresion.Text, txtTemperatura.Text, txtMolestia.Text, txtTiempoEnf.Text, txtFormaInicio.Text, txtC.Text, txtEnfermedadAct.Text, txtApetito.Text, txtSed.Text, txtOrina.Text, txtDeposiciones.Text, txtSueño.Text, txtPesoFB.Text, txtExamenFisico.Text, txtCie1.Text, txtDes1.Text, txtLab1.Text, cboTD1.Text, txtCie2.Text, txtDes2.Text, txtLab2.Text, cboTD2.Text, txtCie3.Text, txtDes3.Text, txtLab3.Text, cboTD3.Text, txtCie4.Text, txtDes4.Text, txtLab4.Text, cboTD4.Text, txtCie5.Text, txtDes5.Text, txtLab5.Text, cboTD5.Text, txtCie6.Text, txtDes6.Text, txtLab6.Text, cboTD6.Text, txtAntPat.Text, txtAntFam.Text, cboOrigen.Text, cboDesOrigen.Text, txtCama.Text, cboSala.Text, cboRCP.Text)
                objConsulta.PriorizarDx(rbDx1.Checked, rbDx2.Checked, rbDx3.Checked, rbDx4.Checked, rbDx5.Checked, rbDx6.Checked)
            ElseIf Oper = 2 Then
                objConsulta.ModificarSala(CodigoIngreso, dtpFecha.Value.ToShortDateString, txtHora.Text, txtTalla.Text, txtPeso.Text, txtPulso.Text, txtPresion.Text, txtTemperatura.Text, txtMolestia.Text, txtTiempoEnf.Text, txtFormaInicio.Text, txtC.Text, txtEnfermedadAct.Text, txtApetito.Text, txtSed.Text, txtOrina.Text, txtDeposiciones.Text, txtSueño.Text, txtPesoFB.Text, txtExamenFisico.Text, txtCie1.Text, txtDes1.Text, txtLab1.Text, cboTD1.Text, txtCie2.Text, txtDes2.Text, txtLab2.Text, cboTD2.Text, txtCie3.Text, txtDes3.Text, txtLab3.Text, cboTD3.Text, txtCie4.Text, txtDes4.Text, txtLab4.Text, cboTD4.Text, txtCie5.Text, txtDes5.Text, txtLab5.Text, cboTD5.Text, txtCie6.Text, txtDes6.Text, txtLab6.Text, cboTD6.Text, txtAntPat.Text, txtAntFam.Text, cboOrigen.Text, cboDesOrigen.Text, txtCama.Text, cboSala.Text, cboRCP.Text)
                objConsulta.ModificarPrioridadDx(CodigoIngreso, rbDx1.Checked, rbDx2.Checked, rbDx3.Checked, rbDx4.Checked, rbDx5.Checked, rbDx6.Checked)
            End If
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub cboOrigen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And cboOrigen.Text <> "" Then
            If cboOrigen.Text = "CASA" Then txtTalla.Select() Else cboDesOrigen.Select()
        End If
    End Sub

    Private Sub cboDesOrigen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And IsNumeric(cboDesOrigen.SelectedValue) Then txtTalla.Select()
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If cboOrigen.Text = "CASA" Then cboDesOrigen.Text = "NINGUNO"
    End Sub

    Private Sub btnRetornarAD_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarAD.Click
        gbAD.Visible = False
    End Sub

    Private Sub LaboratorioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LaboratorioToolStripMenuItem.Click
        chkPagoContado.Checked = False
        If txtCie1.Text = "" Then MessageBox.Show("Debe asignar por lo menos un Diagnostico de Ingreso, y proceder a Grabar la Anamnesis", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie1.Select() : Exit Sub
        If lblSerieSIS.Text = "" And cboTipoAten.Text = "SIS" Then MessageBox.Show("El paciente es SIS, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS, para obtener su Nro de Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And cboTipoAten.Text = "SOAT/AFOCAT" Then MessageBox.Show("El paciente es SOAT/AFOCAT, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS (07:00 A 19:00) y a Caja Emergencia (19:00 A 07:00), para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And (cboTipoAten.Text = "SOAT/AFOCAT" Or cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Or cboTipoAten.Text = "PARSALUD") Then MessageBox.Show("El paciente es CONVENIOS, para asignar procedimientos debe ser Registrado en la CAJA DE EMERGENCIA, para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        lvTabla.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "LABORATORIO"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False
        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If cboTipoAten.Text <> "COMUN" Then
                Fila.SubItems.Add("SI")
            Else
                If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                    Fila.SubItems.Add("NO")
                Else
                    Fila.SubItems.Add("SI")
                End If
            End If
            If dsVer.Tables(0).Rows(I)("Descripcion") = "HIV POR ELISA" Then Fila.SubItems.Add("RECOGER RESULTADO EN CERITS") Else Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
    End Sub

    Private Sub txtProcedimiento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProcedimiento.TextChanged
        If txtProcedimiento.Text <> "" And txtProcedimiento.Enabled Then txtDescripcion.Text = txtProcedimiento.Text : txtDescripcion.SelectionStart = txtDescripcion.Text.Length : gbSI.Visible = True : txtDescripcion.Select()
    End Sub

    Private Sub btnRetornarSI_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarSI.Click
        txtDescripcion.Text = ""
        gbSI.Visible = False
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If lvSI.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvSI.Select()
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        If txtDescripcion.Text <> "" And txtDescripcion.Enabled Then
            Dim dsVer As New DataSet
            Dim I As Integer
            Dim Fila As ListViewItem

            lvSI.Items.Clear()

            'Procedimientos de Paciente Comun
            If cboTipoAten.Text = "COMUN" Then
                dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "COMUN")
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                Next
            End If

            'Procedimientos de Paciente SIS
            If cboTipoAten.Text = "SIS" Then
                If chkPagoContado.Checked Then
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "COMUN")
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                Else
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "SIS")
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                End If
            End If

            'Procedimientos de Paciente SOAT
            If cboTipoAten.Text = "SOAT/AFOCAT" Then
                If chkPagoContado.Checked Then
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "COMUN")
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                Else
                    dsVer = objSoat.BuscarDes(txtDescripcion.Text, Tipo)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdTarifario"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
                    Next
                End If

            End If

            'Procedimientos de Paciente Convenio
            If cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Then
                If chkPagoContado.Checked Then
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "COMUN")
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                Else
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, cboTipoAten.Text)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                End If

            End If
        End If
    End Sub

    Private Sub lvSI_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvSI.KeyDown
        If e.KeyCode = Keys.Enter And lvSI.SelectedItems.Count > 0 Then
            'If Val(lvSI.SelectedItems(0).SubItems(2).Text) = 0 Then MessageBox.Show("No tiene Precio definido informar a Farmacia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            txtProcedimiento.Enabled = False
            txtProcedimiento.Tag = lvSI.SelectedItems(0).SubItems(0).Text
            txtProcedimiento.Text = lvSI.SelectedItems(0).SubItems(1).Text
            txtProcedimiento.Enabled = True
            txtCantidad.Text = "1"
            lblPrecio.Text = lvSI.SelectedItems(0).SubItems(2).Text
            lblTipo.Text = lvSI.SelectedItems(0).SubItems(3).Text
            lblTipo.Tag = lvSI.SelectedItems(0).SubItems(4).Text

            txtCantidad.Select()
            btnRetornarSI_Click(sender, e)
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If txtProcedimiento.Text <> "" And IsNumeric(txtCantidad.Text) And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(txtProcedimiento.Tag)
            If cboTipoAten.Text = "SIS" And txtProcedimiento.Text = "OXIGENOTERAPIA" Then txtCantidad.Text = Val(txtCantidad.Text) * 300
            Fila.SubItems.Add(txtCantidad.Text)
            Fila.SubItems.Add(txtProcedimiento.Text)
            Fila.SubItems.Add(lblPrecio.Text)
            Fila.SubItems.Add(Val(lblPrecio.Text) * Val(txtCantidad.Text))
            Fila.SubItems.Add(lblTipo.Text)
            Fila.SubItems.Add(lblTipo.Tag)
            Total()
            txtProcedimiento.Tag = ""
            txtProcedimiento.Text = ""
            txtCantidad.Text = ""
            lblPrecio.Text = ""
            txtProcedimiento.Select()
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("Esta seguro de Grabar Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            Dim CodigoSIS As String
            Dim CodigoSoat As String
            Dim CodigoConvenio As String
            Dim Fecha As String
            Dim Hora As String

            'Verificar Tipo de Paciente para obtener Codigos
            If cboTipoAten.Text = "SIS" Then
                Dim dsSIS As New DataSet
                dsSIS = objSIS.ConsultarLN(lblSerieSIS.Text, lblNumeroSIS.Text, txtHistoria.Text)
                If dsSIS.Tables(0).Rows.Count = 0 Then MessageBox.Show("Los datos del Formato no son correctos, Verificar Numeros del Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                CodigoSIS = dsSIS.Tables(0).Rows(0)("IdSis")

                If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                    If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                End If
                If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                    MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                End If
            End If

            'Verificar Tipo de Paciente para obtener Codigos
            If cboTipoAten.Text = "SOAT/AFOCAT" Then
                Dim dsSoat As New DataSet
                dsSoat = objSoat.BuscarPH(lblPreliquidacion.Text, txtHistoria.Text)
                CodigoSoat = dsSoat.Tables(0).Rows(0)("IdSoat")

                If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If

            'Verificar Tipo de Paciente para obtener Codigos
            If cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Then
                Dim dsConvenio As New DataSet
                dsConvenio = objConvenio.BuscarCH(lblPreliquidacion.Text, txtHistoria.Text)
                CodigoConvenio = dsConvenio.Tables(0).Rows(0)("IdConvenio")

                If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then MessageBox.Show("Atencion de Convenio ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If

            'Registrar detalle de Procedimientos
            For I = 0 To lvTabla.Items.Count - 1
                Fecha = Date.Now.ToShortDateString
                Hora = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
                'Paciente Comun
                If cboTipoAten.Text = "COMUN" Then
                    If Val(lvTabla.Items(I).SubItems(3).Text) > 0 Then
                        objDetalleSer.GrabarContado(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTabla.Items(I).SubItems(6).Text)
                    Else
                        objDetalleSer.GrabarConvenio(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, vIdMedico, UsuarioSistema, lvTabla.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTabla.Items(I).SubItems(6).Text)
                    End If
                End If

                'Paciente SIS
                If cboTipoAten.Text = "SIS" Then
                    If chkPagoContado.Checked Then
                        objDetalleSer.GrabarContado(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTabla.Items(I).SubItems(6).Text)
                    Else
                        objSIS.GrabarProcedimientosN(CodigoSIS, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(4).Text, NomMedico, My.Computer.Name, Fecha, Hora)
                        objDetalleSer.GrabarConvenio(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, vIdMedico, UsuarioSistema, lvTabla.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTabla.Items(I).SubItems(6).Text)
                    End If
                End If

                'Paciente Soat
                If cboTipoAten.Text = "SOAT/AFOCAT" Then
                    If chkPagoContado.Checked Then
                        objDetalleSer.GrabarContado(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTabla.Items(I).SubItems(6).Text)
                    Else
                        Dim Clasificador As String = 7

                        objSoat.GrabarDetalle(CodigoSoat, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, 3, "  /  /", Fecha, Hora, UsuarioSistema, My.Computer.Name)
                        objDetalleSer.GrabarConvenio(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, vIdMedico, UsuarioSistema, lvTabla.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTabla.Items(I).SubItems(6).Text)
                    End If
                End If

                'Pacientes Convenio
                If cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Then
                    If chkPagoContado.Checked Then
                        objDetalleSer.GrabarContado(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTabla.Items(I).SubItems(6).Text)
                    Else
                        objConvenio.GrabarProcedimientos(CodigoConvenio, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(4).Text, Fecha, Hora, UsuarioSistema, My.Computer.Name, Date.Now.ToShortDateString, "  /  /")
                        objDetalleSer.GrabarConvenio(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, vIdMedico, UsuarioSistema, lvTabla.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTabla.Items(I).SubItems(6).Text)
                    End If
                End If
            Next
            btnRetornarAD_Click(sender, e)
        End If
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
            Total()
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub lvSolicitado_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvSolicitado.KeyDown
        If e.KeyCode = Keys.Delete And lvSolicitado.SelectedItems.Count > 0 Then
            If lvSolicitado.SelectedItems(0).SubItems(4).Text <> "" Then MessageBox.Show("Procedimiento no puede ser eliminado por tener asignado un resultado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If MessageBox.Show("Esta seguro de Eliminar Procedimiento?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'Verificar Tipo de Paciente para obtener Codigos
                If cboTipoAten.Text = "SIS" Then
                    Dim CodigoSIS As String
                    Dim dsSIS As New DataSet
                    dsSIS = objSIS.ConsultarLN(lblSerieSIS.Text, lblNumeroSIS.Text, txtHistoria.Text)
                    CodigoSIS = dsSIS.Tables(0).Rows(0)("IdSis")

                    If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                        If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                    End If
                    If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                        MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                    End If

                    If lvSolicitado.SelectedItems(0).SubItems(6).Text <> "" Then objSIS.EliminarEmergencia(CodigoSIS, lvSolicitado.SelectedItems(0).SubItems(0).Text, lvSolicitado.SelectedItems(0).SubItems(6).Text, lvSolicitado.SelectedItems(0).SubItems(7).Text)
                End If

                'Verificar Tipo de Paciente para obtener Codigos
                Dim CodigoSoat As String
                If cboTipoAten.Text = "SOAT/AFOCAT" Then
                    Dim dsSoat As New DataSet
                    dsSoat = objSoat.BuscarPH(lblPreliquidacion.Text, txtHistoria.Text)
                    CodigoSoat = dsSoat.Tables(0).Rows(0)("IdSoat")

                    If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                    objSoat.EliminarEmergencia(CodigoSoat, lvSolicitado.SelectedItems(0).Text, lvSolicitado.SelectedItems(0).SubItems(6).Text, lvSolicitado.SelectedItems(0).SubItems(7).Text)
                End If

                'Verificar Tipo de Paciente para obtener Codigos
                Dim CodigoConvenio As String
                If cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Then
                    Dim dsConvenio As New DataSet
                    dsConvenio = objConvenio.BuscarCH(lblPreliquidacion.Text, txtHistoria.Text)
                    CodigoConvenio = dsConvenio.Tables(0).Rows(0)("IdConvenio")

                    If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then MessageBox.Show("Atencion de Convenio ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                    objConvenio.EliminarEmergencia(CodigoConvenio, lvSolicitado.SelectedItems(0).SubItems(0).Text, lvSolicitado.SelectedItems(0).SubItems(6).Text, lvSolicitado.SelectedItems(0).SubItems(7).Text)
                End If


                objDetalleSer.Eliminar(lvSolicitado.SelectedItems(0).SubItems(5).Text)
                lvSolicitado.Items.RemoveAt(lvSolicitado.SelectedItems(0).Index)
                Total()
            End If
        End If

        If lvSolicitado.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            lblPro1.Text = lvSolicitado.SelectedItems(0).SubItems(2).Text
            txtRes1.Text = lvSolicitado.SelectedItems(0).SubItems(4).Text
            gbLabCE.Visible = True
        End If
    End Sub

    Private Sub lvSolicitado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvSolicitado.SelectedIndexChanged
        If lvSolicitado.SelectedItems.Count > 0 Then
            If lvSolicitado.SelectedItems(0).SubItems(3).Text = "NO" Then
                btnPendiente.Enabled = True
            Else
                btnPendiente.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        gbPaciente.BringToFront()
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtPaciente.Text)
            lvPaciente.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvPaciente.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
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

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
            gbPaciente.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub btnRetornarAlta_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarAlta.Click

        gbAlta.Visible = False
    End Sub

    Private Sub btnPendiente_Click(sender As System.Object, e As System.EventArgs) Handles btnPendiente.Click
        If MessageBox.Show("Esta seguro de Asignar como PENDIENTE DE PAGO EL PROCEDIMIENTO SELECCIONADO?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objDetalleSer.PendientePago(lvSolicitado.SelectedItems(0).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name)
            lvSolicitado.SelectedItems(0).SubItems(11).Text = "SI"
            btnPendiente.Enabled = False
        End If
    End Sub

    Private Sub txtDes1A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes1A.TextChanged
        If txtDes1A.Text <> "" And txtDes1A.Enabled Then txtFiltroA.Text = txtDes1A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "1"
    End Sub

    Private Sub txtCie1A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie1A.KeyDown
        If e.KeyCode = Keys.Enter And txtCie1A.Text = "" Then txtDes1A.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie1A.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie1A.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                txtDes1A.Enabled = False
                txtDes1A.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes1A.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD1.Text = "DEFINITIVO"
                txtLab1A.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie1A.Text = ""
                txtDes1A.Text = ""
                txtCie1A.Select()
            End If
        End If
    End Sub

    Private Sub txtCie1A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie1A.TextChanged

    End Sub

    Private Sub txtCie2A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie2A.KeyDown
        If e.KeyCode = Keys.Enter And txtCie2A.Text = "" Then txtDes2A.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie2A.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie2A.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                txtDes2A.Enabled = False
                txtDes2A.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes2A.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD2A.Text = "DEFINITIVO"
                txtLab2A.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie2A.Text = ""
                txtDes2A.Text = ""
                txtCie2A.Select()
            End If
        End If
    End Sub

    Private Sub txtCie2A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie2A.TextChanged

    End Sub

    Private Sub txtCie3A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie3A.KeyDown
        If e.KeyCode = Keys.Enter And txtCie3A.Text = "" Then txtDes3A.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie3A.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie3A.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                txtDes3A.Enabled = False
                txtDes3A.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes3A.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD3A.Text = "DEFINITIVO"
                txtLab3A.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie3A.Text = ""
                txtDes3A.Text = ""
                txtCie3A.Select()
            End If
        End If
    End Sub

    Private Sub txtCie3A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie3A.TextChanged

    End Sub

    Private Sub txtCie4A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie4A.KeyDown
        If e.KeyCode = Keys.Enter And txtCie4A.Text = "" Then txtDes4A.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie4A.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie4A.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                txtDes4A.Enabled = False
                txtDes4A.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes4A.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD4A.Text = "DEFINITIVO"
                txtLab4A.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie4A.Text = ""
                txtDes4A.Text = ""
                txtCie4A.Select()
            End If
        End If
    End Sub

    Private Sub txtCie4A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie4A.TextChanged

    End Sub

    Private Sub txtCie5A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie5A.KeyDown
        If e.KeyCode = Keys.Enter And txtCie5A.Text = "" Then txtDes5A.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie5A.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie5A.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                txtDes5A.Enabled = False
                txtDes5A.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes5A.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD5A.Text = "DEFINITIVO"
                txtLab5A.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie5A.Text = ""
                txtDes5A.Text = ""
                txtCie5A.Select()
            End If
        End If
    End Sub

    Private Sub txtCie5A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie5A.TextChanged

    End Sub

    Private Sub txtCie6A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie6A.KeyDown
        If e.KeyCode = Keys.Enter And txtCie6A.Text = "" Then txtDes6A.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie6A.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie6A.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                txtDes6A.Enabled = False
                txtDes6A.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDes6A.Enabled = True
                If dsVer.Tables(0).Rows(0)("DEFINITIVO") = "SI" Then cboTD6A.Text = "DEFINITIVO"
                txtLab6A.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCie6A.Text = ""
                txtDes6A.Text = ""
                txtCie6A.Select()
            End If
        End If
    End Sub

    Private Sub txtCie6A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie6A.TextChanged

    End Sub

    Private Sub txtDes2A_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes2A.TextChanged
        If txtDes2A.Text <> "" And txtDes2A.Enabled Then txtFiltroA.Text = txtDes2A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "2"
    End Sub

    Private Sub txtDes3A_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes3A.TextChanged
        If txtDes3A.Text <> "" And txtDes3A.Enabled Then txtFiltroA.Text = txtDes3A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "3"
    End Sub

    Private Sub txtDes4A_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes4A.TextChanged
        If txtDes4A.Text <> "" And txtDes4A.Enabled Then txtFiltroA.Text = txtDes4A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "4"
    End Sub

    Private Sub txtDes5A_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes5A.TextChanged
        If txtDes5A.Text <> "" And txtDes5A.Enabled Then txtFiltroA.Text = txtDes5A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "5"
    End Sub

    Private Sub txtDes6A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes6A.KeyDown
        If txtDes6A.Text <> "" And txtDes6A.Enabled Then txtFiltroA.Text = txtDes6A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "6"
    End Sub

    Private Sub txtFiltroA_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltroA.KeyDown
        If txtFiltroA.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsCIE As New DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvCIEA.Items.Clear()
            dsCIE = objCie10.BuscarFiltro(txtFiltroA.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvCIEA.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Definitivo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Sexo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MinEdad"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MinTipo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MaxEdad"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MaxTipo"))
            Next
            If lvCIEA.Items.Count > 0 Then lvCIEA.Select()
        End If
    End Sub

    Private Sub txtFiltroA_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltroA.TextChanged

    End Sub

    Private Sub btnRetornarA_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarA.Click
        gbCIEA.Visible = False
    End Sub

    'Private Sub btnAceptarAlta_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarAlta.Click
    '    If MessageBox.Show("Esta seguro de Guardar Información de Alta de Paciente?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '        If txtCie1A.Text = "" Then MessageBox.Show("Debe ingresar al menos un Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie1A.Select() : Exit Sub
    '        If txtDes1A.Text = "" Then MessageBox.Show("Debe ingresar información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes1A.Select() : Exit Sub
    '        If cboTD1A.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD1A.Select() : Exit Sub

    '        If txtCie2A.Text <> "" And txtDes2A.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes2A.Select() : Exit Sub
    '        If txtCie3A.Text <> "" And txtDes3A.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes3A.Select() : Exit Sub
    '        If txtCie4A.Text <> "" And txtDes4A.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes4A.Select() : Exit Sub
    '        If txtCie5A.Text <> "" And txtDes5A.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes5A.Select() : Exit Sub
    '        If txtCie6A.Text <> "" And txtDes6A.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes6A.Select() : Exit Sub

    '        If txtCie2A.Text <> "" And cboTD2A.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD2A.Select() : Exit Sub
    '        If txtCie3A.Text <> "" And cboTD3A.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD3A.Select() : Exit Sub
    '        If txtCie4A.Text <> "" And cboTD4A.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD4A.Select() : Exit Sub
    '        If txtCie5A.Text <> "" And cboTD5A.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD5A.Select() : Exit Sub
    '        If txtCie6A.Text <> "" And cboTD6A.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para el Alta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD6A.Select() : Exit Sub


    '        objAlta.Grabar(CodigoIngreso, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), cboCondicion.Text, cboMedico.Text, cboTipoAlta.Text, cboDestino.Text, txtDesDestino.Text, txtCie1A.Text, txtDes1A.Text, txtLab1A.Text, cboTD1A.Text, txtCie2A.Text, txtDes2A.Text, txtLab2A.Text, cboTD2A.Text, txtCie3A.Text, txtDes3A.Text, txtLab3A.Text, cboTD3A.Text, txtCie4A.Text, txtDes4A.Text, txtLab4A.Text, cboTD4A.Text, txtCie5A.Text, txtDes5A.Text, txtLab5A.Text, cboTD5A.Text, txtCie6A.Text, txtDes6A.Text, txtLab6A.Text, cboTD6A.Text, cboMedico.SelectedValue)
    '        btnCancelar_Click(sender, e)
    '    End If
    'End Sub

    Private Sub lvCIEA_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvCIEA.KeyDown
        If e.KeyCode = Keys.Enter And lvCIEA.SelectedItems.Count > 0 Then
            Select Case Filtro
                Case "1"
                    txtCie1A.Text = lvCIEA.SelectedItems(0).SubItems(0).Text
                    txtDes1A.Enabled = False
                    txtDes1A.Text = lvCIEA.SelectedItems(0).SubItems(1).Text
                    txtDes1A.Enabled = True
                    If lvCIEA.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD1A.Text = "DEFINITIVO" Else cboTD1A.Text = ""
                    txtLab1A.Select()
                    gbCIEA.Visible = False
                Case "2"
                    txtCie2A.Text = lvCIEA.SelectedItems(0).SubItems(0).Text
                    txtDes2A.Enabled = False
                    txtDes2A.Text = lvCIEA.SelectedItems(0).SubItems(1).Text
                    txtDes2A.Enabled = True
                    If lvCIEA.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD2A.Text = "DEFINITIVO" Else cboTD2A.Text = ""
                    txtLab2A.Select()
                    gbCIEA.Visible = False
                Case "3"
                    txtCie3A.Text = lvCIEA.SelectedItems(0).SubItems(0).Text
                    txtDes3A.Enabled = False
                    txtDes3A.Text = lvCIEA.SelectedItems(0).SubItems(1).Text
                    txtDes3A.Enabled = True
                    If lvCIEA.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD3A.Text = "DEFINITIVO" Else cboTD3A.Text = ""
                    txtLab3A.Select()
                    gbCIEA.Visible = False
                Case "4"
                    txtCie4A.Text = lvCIEA.SelectedItems(0).SubItems(0).Text
                    txtDes4A.Enabled = False
                    txtDes4A.Text = lvCIEA.SelectedItems(0).SubItems(1).Text
                    txtDes4A.Enabled = True
                    If lvCIEA.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD4A.Text = "DEFINITIVO" Else cboTD4A.Text = ""
                    txtLab4A.Select()
                    gbCIEA.Visible = False
                Case "5"
                    txtCie5A.Text = lvCIEA.SelectedItems(0).SubItems(0).Text
                    txtDes5A.Enabled = False
                    txtDes5A.Text = lvCIEA.SelectedItems(0).SubItems(1).Text
                    txtDes5A.Enabled = True
                    If lvCIEA.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD5A.Text = "DEFINITIVO" Else cboTD5A.Text = ""
                    txtLab5A.Select()
                    gbCIEA.Visible = False
                Case "6"
                    txtCie6A.Text = lvCIEA.SelectedItems(0).SubItems(0).Text
                    txtDes6A.Enabled = False
                    txtDes6A.Text = lvCIEA.SelectedItems(0).SubItems(1).Text
                    txtDes6A.Enabled = True
                    If lvCIEA.SelectedItems(0).SubItems(2).Text = "SI" Then cboTD6A.Text = "DEFINITIVO" Else cboTD6A.Text = ""
                    txtLab6A.Select()
                    gbCIEA.Visible = False
            End Select
        End If
    End Sub

    Private Sub lvCIEA_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCIEA.SelectedIndexChanged

    End Sub

    Private Sub cboCondicion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCondicion.KeyDown
        If cboCondicion.Text <> "" And e.KeyCode = Keys.Enter Then cboMedico.Select()
    End Sub

    Private Sub cboCondicion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCondicion.SelectedIndexChanged

    End Sub

    Private Sub cboMedico_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If e.KeyCode = Keys.Enter And cboMedico.Text <> "" Then cboTipoAlta.Select()
    End Sub

    Private Sub cboMedico_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedico.SelectedIndexChanged

    End Sub

    Private Sub cboTipoAlta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAlta.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoAlta.Text <> "" Then cboDestino.Select()
    End Sub

    Private Sub cboTipoAlta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoAlta.SelectedIndexChanged

    End Sub

    Private Sub cboDestino_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboDestino.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboDestino.SelectedValue) Then
            If cboDestino.Text = "REFERENCIA" Or cboDestino.Text = "CONTRAREFERENCIA" Then txtDesDestino.Select() Else txtCie1A.Select()
        End If
    End Sub

    Private Sub cboDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDestino.SelectedIndexChanged

    End Sub

    Private Sub txtLab1A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab1A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD1A.Select()
    End Sub

    Private Sub txtLab1A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab1A.TextChanged

    End Sub

    Private Sub cboTD1A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD1A.KeyDown
        If cboTD1A.Text <> "" And e.KeyCode = Keys.Enter Then txtCie2A.Select()
    End Sub

    Private Sub cboTD1A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD1A.SelectedIndexChanged

    End Sub

    Private Sub txtLab2A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab2A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD2A.Select()
    End Sub

    Private Sub txtLab2A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab2A.TextChanged

    End Sub

    Private Sub txtLab3A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab3A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD3.Select()
    End Sub

    Private Sub txtLab3A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab3A.TextChanged

    End Sub

    Private Sub txtLab4A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab4A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD4.Select()
    End Sub

    Private Sub txtLab4A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab4A.TextChanged

    End Sub

    Private Sub txtLab5A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab5A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD5.Select()
    End Sub

    Private Sub txtLab5A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab5A.TextChanged

    End Sub

    Private Sub txtLab6A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab6A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD6.Select()
    End Sub

    Private Sub txtLab6A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab6A.TextChanged

    End Sub

    Private Sub cboTD2A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD2A.KeyDown
        If e.KeyCode = Keys.Enter And cboTD2A.Text <> "" Then txtCie3A.Select()
    End Sub

    Private Sub cboTD2A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD2A.SelectedIndexChanged

    End Sub

    Private Sub cboTD3A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD3A.KeyDown
        If e.KeyCode = Keys.Enter And cboTD3A.Text <> "" Then txtCie4A.Select()
    End Sub

    Private Sub cboTD3A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD3A.SelectedIndexChanged

    End Sub

    Private Sub cboTD4A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD4A.KeyDown
        If e.KeyCode = Keys.Enter And cboTD4A.Text <> "" Then txtCie5A.Select()
    End Sub

    Private Sub cboTD4A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD4A.SelectedIndexChanged

    End Sub

    Private Sub cboTD5A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD5A.KeyDown
        If e.KeyCode = Keys.Enter And cboTD5A.Text <> "" Then txtCie6A.Select()
    End Sub

    Private Sub cboTD5A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD5A.SelectedIndexChanged

    End Sub

    Private Sub cboTD6A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD6A.KeyDown
        If e.KeyCode = Keys.Enter And cboTD6A.Text <> "" Then btnAceptarAlta.Select()
    End Sub

    

    Private Sub RayosXToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RayosXToolStripMenuItem.Click
        chkPagoContado.Checked = False
        If txtCie1.Text = "" Then MessageBox.Show("Debe asignar por lo menos un Diagnostico de Ingreso, y proceder a Grabar la Anamnesis", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie1.Select() : Exit Sub
        If lblSerieSIS.Text = "" And cboTipoAten.Text = "SIS" Then MessageBox.Show("El paciente es SIS, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS, para obtener su Nro de Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And cboTipoAten.Text = "SOAT/AFOCAT" Then MessageBox.Show("El paciente es SOAT/AFOCAT, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS (07:00 A 19:00) y a Caja Emergencia (19:00 A 07:00), para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And (cboTipoAten.Text = "SOAT/AFOCAT" Or cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Or cboTipoAten.Text = "PARSALUD") Then MessageBox.Show("El paciente es CONVENIOS, para asignar procedimientos debe ser Registrado en la CAJA DE EMERGENCIA, para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        lvTabla.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "RADIOGRAFIA"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False

        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If cboTipoAten.Text <> "COMUN" Then
                Fila.SubItems.Add("SI")
            Else
                If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                    Fila.SubItems.Add("NO")
                Else
                    Fila.SubItems.Add("SI")
                End If
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
    End Sub

    Private Sub EcografíaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EcografíaToolStripMenuItem.Click
        chkPagoContado.Checked = False
        If txtCie1.Text = "" Then MessageBox.Show("Debe asignar por lo menos un Diagnostico de Ingreso, y proceder a Grabar la Anamnesis", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie1.Select() : Exit Sub
        If lblSerieSIS.Text = "" And cboTipoAten.Text = "SIS" Then MessageBox.Show("El paciente es SIS, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS, para obtener su Nro de Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And cboTipoAten.Text = "SOAT/AFOCAT" Then MessageBox.Show("El paciente es SOAT/AFOCAT, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS (07:00 A 19:00) y a Caja Emergencia (19:00 A 07:00), para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And (cboTipoAten.Text = "SOAT/AFOCAT" Or cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Or cboTipoAten.Text = "PARSALUD") Then MessageBox.Show("El paciente es CONVENIOS, para asignar procedimientos debe ser Registrado en la CAJA DE EMERGENCIA, para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        lvTabla.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "ECOGRAFIA"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False

        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If cboTipoAten.Text <> "COMUN" Then
                Fila.SubItems.Add("SI")
            Else
                If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                    Fila.SubItems.Add("NO")
                Else
                    Fila.SubItems.Add("SI")
                End If
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
    End Sub

    Private Sub PatologíaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PatologíaToolStripMenuItem.Click
        chkPagoContado.Checked = False
        If txtCie1.Text = "" Then MessageBox.Show("Debe asignar por lo menos un Diagnostico de Ingreso, y proceder a Grabar la Anamnesis", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie1.Select() : Exit Sub
        If lblSerieSIS.Text = "" And cboTipoAten.Text = "SIS" Then MessageBox.Show("El paciente es SIS, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS, para obtener su Nro de Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And cboTipoAten.Text = "SOAT/AFOCAT" Then MessageBox.Show("El paciente es SOAT/AFOCAT, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS (07:00 A 19:00) y a Caja Emergencia (19:00 A 07:00), para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And (cboTipoAten.Text = "SOAT/AFOCAT" Or cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Or cboTipoAten.Text = "PARSALUD") Then MessageBox.Show("El paciente es CONVENIOS, para asignar procedimientos debe ser Registrado en la CAJA DE EMERGENCIA, para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        lvTabla.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "PATOLOGIA"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False

        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If cboTipoAten.Text <> "COMUN" Then
                Fila.SubItems.Add("SI")
            Else
                If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                    Fila.SubItems.Add("NO")
                Else
                    Fila.SubItems.Add("SI")
                End If
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
    End Sub

    Private Sub btnAceptarTA_Click(sender As Object, e As System.EventArgs)
        objIngreso.ActualizarTipoAtencion(CodigoIngreso, cboTipoAtencion.Text, lblPaciente.Text, lblSexo.Text)
        gbTipoAtencion.Visible = False
    End Sub

    Private Sub OtrosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OtrosToolStripMenuItem.Click
        chkPagoContado.Checked = False
        If lblSerieSIS.Text = "" And cboTipoAten.Text = "SIS" Then MessageBox.Show("El paciente es SIS, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS, para obtener su Nro de Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And cboTipoAten.Text = "SOAT/AFOCAT" Then MessageBox.Show("El paciente es SOAT/AFOCAT, para asignar procedimientos debe ser Registrado en la OFICINA DE SEGUROS (07:00 A 19:00) y a Caja Emergencia (19:00 A 07:00), para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPreliquidacion.Text) = 0 And (cboTipoAten.Text = "SOAT/AFOCAT" Or cboTipoAten.Text = "CAJA DE PROTECCION" Or cboTipoAten.Text = "INPE" Or cboTipoAten.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAten.Text = "MARINA DE GUERRA DEL PERU" Or cboTipoAten.Text = "PARSALUD") Then MessageBox.Show("El paciente es CONVENIOS, para asignar procedimientos debe ser Registrado en la CAJA DE EMERGENCIA, para obtener su Nro de Preliquidación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        lvTabla.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "ENFERMERIA"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False

        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                Fila.SubItems.Add("NO")
            Else
                Fila.SubItems.Add("SI")
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
    End Sub

    Private Sub gbAD_Enter(sender As System.Object, e As System.EventArgs) Handles gbAD.Enter

    End Sub

    Private Sub lvSI_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvSI.SelectedIndexChanged

    End Sub

    Private Sub lblNumeroSIS_LostFocus(sender As Object, e As System.EventArgs)
        If Val(lblNumeroSIS.Text) > 0 Then
            Dim dsVer As New DataSet
            dsVer = objSIS.ConsultarLN(lblSerieSIS.Text, lblNumeroSIS.Text, txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Debe verificar que este bien escrito la SERIE y NUMERO de lote SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : lblSerieSIS.Text = "" : lblNumeroSIS.Text = 0 : Exit Sub
            Else
                objIngreso.CancelarProc(CodigoIngreso, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema)
            End If
        End If
    End Sub

    Private Sub NotaDeEvoluciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NotaDeEvoluciónToolStripMenuItem.Click
        frmNotaEvolucion.Show()
    End Sub

    Private Sub InterconsultaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InterconsultaToolStripMenuItem.Click
        frmInterconsulta.Show()
    End Sub

    Private Sub gbAlta_Enter(sender As System.Object, e As System.EventArgs) Handles gbAlta.Enter

    End Sub

    Private Sub chkPagoContado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPagoContado.CheckedChanged
        If chkPagoContado.Checked And Tipo = "LABORATORIO" Then MessageBox.Show("No puede activar esta opción para exámenes de laboratorio", "Mensaje de Información", MessageBoxButtons.OK) : chkPagoContado.Checked = False
    End Sub

    Private Sub lblPreliquidacion_LostFocus(sender As Object, e As System.EventArgs)
        If Val(lblPreliquidacion.Text) > 0 Then
            Dim dsVer As New DataSet
            dsVer = objSoat.BuscarFicha(txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If Val(dsVer.Tables(0).Rows(0)("IdSoat")) <> Val(lblPreliquidacion.Text) Then
                    MessageBox.Show("Debe verificar que el numero de Preliquidación esté bien registrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblPreliquidacion.Text = ""
                    lblPreliquidacion.Select()
                End If
            Else
                MessageBox.Show("Debe verificar que el numero de Preliquidación esté bien registrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblPreliquidacion.Text = ""
                lblPreliquidacion.Select()
            End If
        End If
    End Sub

    Private Sub lblPreliquidacion_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoIngreso_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And cboTipoIngreso.Text <> "" Then cboTipoAtenEmer.Select()
    End Sub

    Private Sub cboTipoIngreso_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTipoAtenEmer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If cboTipoAtenEmer.Text <> "" And e.KeyCode = Keys.Enter Then txtTalla.Select()
    End Sub

    Private Sub cboTipoAtenEmer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnRetornar01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar01.Click
        gbLabCE.Visible = False
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

  

End Class