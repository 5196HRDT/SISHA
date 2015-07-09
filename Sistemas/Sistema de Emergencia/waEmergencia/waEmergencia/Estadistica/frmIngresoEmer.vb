Public Class frmIngresoEmer
    Dim objHistoria As New clsHistoria
    Dim objIngreso As New clsEmergenciaIngreso
    Dim objMedico As New clsMedico
    Dim objServicio As New clsServicioEmergencia
    Dim objGrado As New clsGradoInstruccion
    Dim objEstadoCivil As New clsEstadoCivil
    Dim objUbigeo As New clsUbigeo
    Dim objSIS As New clsSIS
    Dim objSoat As New clsSOAT
    Dim objConvenio As New clsConvenio
    Dim objTipoTarifar As New clsTipoTarifa

    Dim Oper As Integer
    Dim CodigoIngreso As String

    'Variables Impresion
    Dim Fuente24N As New Font("Courier New", 24, FontStyle.Bold)
    Dim Fuente14N As New Font("Courier New", 14, FontStyle.Bold)
    Dim Fuente12 As New Font("Courier New", 12)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente10 As New Font("Courier New", 10)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub Botones(Nuevo As Boolean, Grabar As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        Limpiar(Me)
        gbPaciente.Visible = False
    End Sub

    Private Sub frmIngresoEmer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        lblUsuario.Text = UsuarioSistema

        'Medico
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"

        'Servicio Emergencia
        Dim dsServicio As New DataSet
        dsServicio = objServicio.Buscar
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"

        'Grado de Instruccion
        Dim dsGrado As New DataSet
        dsGrado = objGrado.Buscar
        cboGrado.DataSource = dsGrado.Tables(0)
        cboGrado.DisplayMember = "Descripcion"
        cboGrado.ValueMember = "IdGrado"

        'Estado Civil
        Dim dsEstado As New DataSet
        dsEstado = objEstadoCivil.Buscar
        cboEstado.DataSource = dsEstado.Tables(0)
        cboEstado.DisplayMember = "Descripcion"
        cboEstado.ValueMember = "IdEstado"

        'Departamento
        Dim dsDpto As New DataSet
        dsDpto = objUbigeo.UbigeoDepartamento_Combo
        cboDpto.DataSource = dsDpto.Tables(0)
        cboDpto.DisplayMember = "desc_dpto"
        cboDpto.ValueMember = "cod_dpto"

        'Tipo Tarifa
        Dim dsTT As New DataSet
        dsTT = objTipoTarifar.Combo
        cboTipoAtencion.DataSource = dsTT.Tables(0)
        cboTipoAtencion.DisplayMember = "Descripcion"
        cboTipoAtencion.ValueMember = "IdTipoTarifa"
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        ControlesAD(Me, True)
        Botones(False, False, True, False)
        dtpFecha.Value = Date.Now
        txtHora.Text = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        dtpFecha.Select()
        cboDpto.Text = "LA LIBERTAD"
        cboDpto_SelectedIndexChanged(sender, e)
        cboProvincia.Text = "TRUJILLO"
        cboProvincia_SelectedIndexChanged(sender, e)
        cboDistrito.Text = "TRUJILLO"
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter And txtHora.Text <> "" Then txtHistoria.Select()
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
            txtPaciente.Enabled = False
            txtPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")
            txtPaciente.Enabled = True

            'Calcular Edad
            If dsHistorias.Tables(0).Rows(0)("FNacimiento").ToString = "" Then
                dtpFechaNcto.Value = InputBox("Ingresar Fecha de Nacimiento", "Datos de Paciente")
            Else
                dtpFechaNcto.Value = dsHistorias.Tables(0).Rows(0)("FNacimiento")
            End If

            CalcularEdad(dtpFecha.Value, dtpFechaNcto.Value)

            cboGrado.Text = dsHistorias.Tables(0).Rows(0)("GradoInstruccion").ToString

            'Estado Civil
            dsEC = objEstadoCivil.DameDes(Val(dsHistorias.Tables(0).Rows(0)("EstadoCivil").ToString))
            If dsEC.Tables(0).Rows.Count > 0 Then
                cboEstado.Text = dsEC.Tables(0).Rows(0)("Descripcion")
            Else
                cboEstado.Text = "NINGUNO"
            End If

            cboGrado.Text = dsHistorias.Tables(0).Rows(0)("GradoInstruccion").ToString
            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
            txtDomicilio.Text = dsHistorias.Tables(0).Rows(0)("Direccion").ToString
            cboDpto.Text = dsHistorias.Tables(0).Rows(0)("Departamento").ToString
            cboProvincia.Text = dsHistorias.Tables(0).Rows(0)("Provincia").ToString
            cboDistrito.Text = dsHistorias.Tables(0).Rows(0)("Distrito").ToString
            dtpFechaNcto.Select()
            btnGrabar.Enabled = True
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtHistoria.Text) Then
            Dim dsVer As New DataSet
            dsVer = objIngreso.VerificarIngreso(txtHistoria.Text)
            BuscarHistoria()
            'If dsVer.Tables(0).Rows.Count = 0 Then
            '    BuscarHistoria()
            'Else
            '    If MessageBox.Show("Paciente presenta un Ingreso a Emergencia sin Alta Médica, Desea Modificar Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        Oper = 2
            '        BuscarHistoria()
            '        CodigoIngreso = dsVer.Tables(0).Rows(0)("IdIngreso")
            '        dtpFecha.Value = dsVer.Tables(0).Rows(0)("FechaIngreso")
            '        txtHora.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
            '        cboTipoAtencion.Text = dsVer.Tables(0).Rows(0)("TipoAtencion").ToString
            '        txtInformante.Text = dsVer.Tables(0).Rows(0)("Conyuge").ToString
            '        cboGrado.Text = dsVer.Tables(0).Rows(0)("GradoInstruccion").ToString
            '        cboServicio.Text = dsVer.Tables(0).Rows(0)("Especialidad").ToString
            '        cboMedico.Text = dsVer.Tables(0).Rows(0)("Medico").ToString
            '        cboIngEst.Text = dsVer.Tables(0).Rows(0)("IngEstablecimiento").ToString
            '        cboIngSer.Text = dsVer.Tables(0).Rows(0)("IngServicio").ToString
            '        txtSerieSIS.Text = dsVer.Tables(0).Rows(0)("SerieSIS").ToString
            '        txtNumeroSIS.Text = dsVer.Tables(0).Rows(0)("NumeroSIS").ToString
            '        txtPreliquidacion.Text = dsVer.Tables(0).Rows(0)("Preliquidacion").ToString
            '    Else
            '        btnCancelar_Click(sender, e)
            '    End If
            'End If
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If cboTipoAtencion.Text = "PARTICULAR" Then MessageBox.Show("Tipo de Atencion PARTICULAR no esta Autorizada. Elija otra Opción", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Select() : Exit Sub
        If cboTipoAtencion.Text = "EXONERADO" Then MessageBox.Show("Tipo de Atencion EXONERADO no esta Autorizada. Elija otra Opción", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Select() : Exit Sub
        If cboTipoAtencion.Text = "PARSALUD" Then MessageBox.Show("Tipo de Atencion PARSALUD no esta Autorizada. Elija otra Opción", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Select() : Exit Sub
        If cboTipoAtencion.Text = "PENDIENTE DE PAGO" Then MessageBox.Show("Tipo de Atencion PENDIENTE DE PAGO no esta Autorizada. Elija otra Opción", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If txtHistoria.Text = "" Then MessageBox.Show("Debe Indicar el Numero de Historia del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtHistoria.Select() : Exit Sub
            If cboGrado.Text = "" Then MessageBox.Show("Debe Solicitar Información de Grado de Estudio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboGrado.Select() : Exit Sub
            If Not IsNumeric(cboEstado.SelectedValue) Or cboEstado.Text = "NINGUNO" Then MessageBox.Show("Debe Solicitar Información del Estado Civil", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboEstado.Select() : Exit Sub
            If lblSexo.Text = "" Then MessageBox.Show("Debe Completar la Información del Sexo del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If Not IsNumeric(cboDpto.SelectedValue) Then MessageBox.Show("Debe Solicitar Información del Departamento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDpto.Select() : Exit Sub
            If Not IsNumeric(cboProvincia.SelectedValue) Then MessageBox.Show("Debe Solicitar Información de la Provincia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboProvincia.Select() : Exit Sub
            If Not IsNumeric(cboDistrito.SelectedValue) Then MessageBox.Show("Debe Solicitar Información del Distrito", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDistrito.Select() : Exit Sub
            If cboTipoAtencion.Text = "" Then MessageBox.Show("Debe Solicitar Información del Tipo de Atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Select() : Exit Sub
            If cboServicio.Text = "" Then MessageBox.Show("Debe Solicitar Información del Servicio de Atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboServicio.Select() : Exit Sub
            If cboIngEst.Text = "" Then MessageBox.Show("Debe Solicitar Información del Ingreso al Establecimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboIngEst.Select() : Exit Sub
            If cboIngSer.Text = "" Then MessageBox.Show("Debe Solicitar Información del Ingreso al Servicio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboIngSer.Select() : Exit Sub
            If cboMedico.Text = "" Then MessageBox.Show("Debe Solicitar Información del Medico de Guardia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboMedico.Select() : Exit Sub
            If txtHora.Text = "" Then MessageBox.Show("Debe Definir la Hora de Ingreso en Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtHora.Select() : Exit Sub

            'Verificar Paciente SIS
            If cboTipoAtencion.Text = "SIS" Then
                'If txtSerieSIS.Text = "" Then MessageBox.Show("Debe ingresar Numero de Serie de Formato SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Select() : Exit Sub
                'If txtNumeroSIS.Text = "" Then MessageBox.Show("Debe ingresar Numero de Formato SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNumeroSIS.Select() : Exit Sub
                'Dim dsSIS As New DataSet
                'dsSIS = objSIS.ConsultarLN(txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text)
                'If dsSIS.Tables(0).Rows.Count = 0 Then MessageBox.Show("Formato Ingresado no esta autorizado para Atención SIS, no se pudo grabar información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Select() : Exit Sub
                'If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                '    If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                'End If
                'If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                '    MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                'End If
                If txtSerieSIS.Text = "" Or Val(txtNumeroSIS.Text) = 0 Then MessageBox.Show("Debe Informar al Paciente que debe Registrar su Atencion en al UNIDAD DE SEGUROS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Verificar Paciente SOAT
            If cboTipoAtencion.Text = "SOAT/AFOCAT" Then
                'If txtPreliquidacion.Text = "" Then MessageBox.Show("Debe ingresar Numero de Preliquidación de SOAT-AFOCAT", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Select() : Exit Sub
                'Dim dsSoat As New DataSet
                'dsSoat = objSoat.BuscarPH(txtPreliquidacion.Text, txtHistoria.Text)
                'If dsSoat.Tables(0).Rows.Count = 0 Then MessageBox.Show("Nro de Preliquidaciín Ingresada no esta autorizado para Atención SOAT", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtPreliquidacion.Select() : Exit Sub

                'If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If Val(txtPreliquidacion.Text) = 0 Then MessageBox.Show("Debe Informar al Paciente que debe Registrar su Atencion en al UNIDAD DE SEGUROS SOAT/AFOCAT", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Verificar Paciente Convenio
            If cboTipoAtencion.Text = "CAJA DE PROTECCION" Or cboTipoAtencion.Text = "INPE" Or cboTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or cboTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                'If txtPreliquidacion.Text = "" Then MessageBox.Show("Debe ingresar Numero de Preliquidación de Convenio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Select() : Exit Sub
                'Dim dsConvenio As New DataSet
                'dsConvenio = objConvenio.BuscarCH(txtPreliquidacion.Text, txtHistoria.Text)
                'If dsConvenio.Tables(0).Rows.Count = 0 Then MessageBox.Show("Nro de Preliquidaciín Ingresada no esta autorizado para Atención de Convenio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtPreliquidacion.Select() : Exit Sub

                'If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then MessageBox.Show("Atencion Convenio ya fue finalizada. Comunicarse con Cuentas Corrientes", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If Val(txtPreliquidacion.Text) = 0 Then MessageBox.Show("Debe Informar al Paciente que debe Registrar su Atencion de Convenios en CAJA DE EMERGENCIA", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If Oper = 1 Then
                objIngreso.GrabarEstadistica(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), UsuarioSistema, txtHistoria.Text, txtPaciente.Text, cboProvincia.Text, cboDistrito.Text, cboDpto.Text, txtInformante.Text, cboServicio.Text, cboMedico.Text, dtpFechaNcto.Value.ToShortDateString, lblSexo.Text, lblEdad.Text, lblTEdad.Text, cboTipoAtencion.Text, cboIngEst.Text, cboIngSer.Text, cboGrado.Text, cboEstado.Text, cboDpto.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, txtSerieSIS.Text, txtNumeroSIS.Text, txtPreliquidacion.Text, lblEdadM.Text, lblEdadD.Text)
            ElseIf Oper = 2 Then
                objIngreso.ModificarEstadistica(CodigoIngreso, dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), UsuarioSistema, txtHistoria.Text, txtPaciente.Text, cboProvincia.Text, cboDistrito.Text, cboDpto.Text, txtInformante.Text, cboServicio.Text, cboMedico.Text, dtpFechaNcto.Value.ToShortDateString, lblSexo.Text, lblEdad.Text, lblTEdad.Text, cboTipoAtencion.Text, cboIngEst.Text, cboIngSer.Text, cboGrado.Text, cboEstado.Text, cboDpto.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, txtSerieSIS.Text, txtNumeroSIS.Text, txtPreliquidacion.Text, lblEdadM.Text, lblEdadD.Text)
            End If

            objHistoria.GrabarEstadoCivil(txtHistoria.Text, cboEstado.SelectedValue)
            objHistoria.GrabarGradoInstruccion(txtHistoria.Text, cboGrado.Text)
            objHistoria.GrabarUbigeo(txtHistoria.Text, cboDpto.Text, cboProvincia.Text, cboDistrito.Text)
            objHistoria.GrabarFN(txtHistoria.Text, dtpFechaNcto.Value.ToShortDateString)

            ppDialogo.ShowDialog()
            'pdImpresion.ShowDialog()
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub cboDpto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboDpto.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboDpto.SelectedValue) Then cboProvincia.Select()
    End Sub

    Private Sub cboDpto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDpto.SelectedIndexChanged
        If IsNumeric(cboDpto.SelectedValue) Then
            'Provincia
            Dim dsProvincia As New DataSet
            dsProvincia = objUbigeo.UbigeoProvincia_Combo(cboDpto.SelectedValue)
            cboProvincia.DataSource = dsProvincia.Tables(0)
            cboProvincia.DisplayMember = "desc_prov"
            cboProvincia.ValueMember = "cod_prov"
        End If
    End Sub

    Private Sub cboProvincia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboProvincia.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboProvincia.SelectedValue) Then cboDistrito.Select()
    End Sub

    Private Sub cboProvincia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        If IsNumeric(cboDpto.SelectedValue) And IsNumeric(cboProvincia.SelectedValue) Then
            'Distrito
            Dim dsDistrito As New DataSet
            dsDistrito = objUbigeo.UbigeoDistrito_Combo(cboDpto.SelectedValue, cboProvincia.SelectedValue)
            cboDistrito.DataSource = dsDistrito.Tables(0)
            cboDistrito.DisplayMember = "desc_dist"
            cboDistrito.ValueMember = "cod_dist"
        End If
    End Sub

    Private Sub cboGrado_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboGrado.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboGrado.SelectedValue) Then cboEstado.Select()
    End Sub

    Private Sub cboEstado_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEstado.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEstado.SelectedValue) Then txtDomicilio.Select()
    End Sub

    Private Sub txtDomicilio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDomicilio.KeyDown
        If e.KeyCode = Keys.Enter And txtDomicilio.Text <> "" Then cboTipoAtencion.Select()
    End Sub


    Private Sub dtpFechaNcto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaNcto.KeyDown
        If e.KeyCode = Keys.Enter Then cboGrado.Select()
    End Sub

    Private Sub dtpFechaNcto_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaNcto.ValueChanged
        CalcularEdad(dtpFecha.Value.ToShortDateString, dtpFechaNcto.Value.ToShortDateString)
    End Sub

    Private Sub cboTipoAtencion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAtencion.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoAtencion.Text <> "" Then cboDpto.Select()
    End Sub

    Private Sub cboTipoAtencion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoAtencion.SelectedIndexChanged

    End Sub

    Private Sub cboDistrito_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboDistrito.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboDistrito.SelectedValue) Then txtInformante.Select()
    End Sub

    Private Sub cboDistrito_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDistrito.SelectedIndexChanged

    End Sub

    Private Sub txtInformante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtInformante.KeyDown
        If e.KeyCode = Keys.Enter And txtInformante.Text <> "" Then cboServicio.Select()
    End Sub

    Private Sub txtInformante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtInformante.TextChanged

    End Sub

    Private Sub cboIngEst_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboIngEst.KeyDown
        If e.KeyCode = Keys.Enter And cboIngEst.Text <> "" Then cboIngSer.Select()
    End Sub

    Private Sub cboIngEst_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboIngEst.SelectedIndexChanged

    End Sub

    Private Sub cboIngSer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboIngSer.KeyDown
        If e.KeyCode = Keys.Enter And cboIngSer.Text <> "" Then txtSerieSIS.Select()
    End Sub

    Private Sub cboServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And cboServicio.Text <> "" Then cboMedico.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServicio.SelectedIndexChanged

    End Sub

    Private Sub cboMedico_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If e.KeyCode = Keys.Enter And cboMedico.Text <> "" Then cboIngEst.Select()
    End Sub

    Private Sub pdDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdDocumento.PrintPage
        Y = 20
        With e.Graphics
            .DrawString("HOSPITAL REGIONAL", Fuente10, Pincel, 50, Y)
            .DrawString("ESTADISTICA E INFORMATICA", Fuente10, Pincel, 600, Y)
            Y = Y + 15
            .DrawString("DOCENTE DE TRUJILLO" & StrDup(10, " "), Fuente10, Pincel, 40, Y)
            .DrawString(Date.Now.ToShortDateString & "|" & Date.Now.ToShortTimeString & "|" & UsuarioSistema, Fuente10, Pincel, 580, Y)
            Y = Y + 30
            .DrawString("INGRESO DE EMERGENCIA", Fuente24N, Pincel, 200, Y)

            Y = Y + 40
            .DrawString("Historia Clínica: ", Fuente10, Pincel, 40, Y)
            .DrawString(txtHistoria.Text, Fuente14N, Pincel, 220, Y)
            .DrawString("Fecha y Hora Ingreso: ", Fuente10, Pincel, 400, Y)
            .DrawString(dtpFecha.Value.ToShortDateString & " | " & txtHora.Text, Fuente12N, Pincel, 600, Y)
            Y = Y + 20
            .DrawString("Apellidos y Nombres: ", Fuente10, Pincel, 40, Y)
            .DrawString(txtPaciente.Text, Fuente14N, Pincel, 220, Y)
            .DrawString("Sexo: ", Fuente10, Pincel, 740, Y)
            .DrawString(lblSexo.Text, Fuente12N, Pincel, 790, Y)
            Y = Y + 20
            .DrawString("Tipo Atención: ", Fuente10, Pincel, 40, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboTipoAtencion.Text & StrDup(20, " "), 20), Fuente12N, Pincel, 220, Y)
            .DrawString("FNacimiento: ", Fuente10, Pincel, 440, Y)
            .DrawString(dtpFechaNcto.Value.ToShortDateString, Fuente12N, Pincel, 540, Y)
            .DrawString("Edad: ", Fuente10, Pincel, 660, Y)
            .DrawString(lblEdad.Text & lblTEdad.Text & " " & lblEdadM.Text & "M" & " " & lblEdadD.Text & "D", Fuente12N, Pincel, 700, Y)
           
            Y = Y + 20
            .DrawString("Domicilio: ", Fuente10, Pincel, 40, Y)
            .DrawString(txtDomicilio.Text, Fuente12N, Pincel, 220, Y)
            Y = Y + 20
            .DrawString("Procedencia: ", Fuente10, Pincel, 40, Y)
            .DrawString(cboDpto.Text & " / " & cboProvincia.Text & " / " & cboDistrito.Text, Fuente12N, Pincel, 220, Y)
            Y = Y + 20
            .DrawString("Servicio: ", Fuente10, Pincel, 40, Y)
            .DrawString(cboServicio.Text, Fuente12N, Pincel, 220, Y)
            .DrawString("Médico: ", Fuente10, Pincel, 340, Y)
            .DrawString(cboMedico.Text, Fuente12N, Pincel, 450, Y)
            Y = Y + 20
            .DrawString("Ing. Estable.: ", Fuente10, Pincel, 40, Y)
            .DrawString(cboIngEst.Text, Fuente12N, Pincel, 220, Y)
            .DrawString("Ing. Servicio: ", Fuente10, Pincel, 340, Y)
            .DrawString(cboIngSer.Text, Fuente12N, Pincel, 460, Y)
            Y = Y + 20
            .DrawLine(Pens.Black, 30, Y, 840, Y)
            Y = Y + 20
            .DrawString("ANAMNESIS", Fuente14N, Pincel, 40, Y)
            .DrawString("Talla:______", Fuente10, Pincel, 180, Y)
            .DrawString("Peso:______", Fuente10, Pincel, 300, Y)
            .DrawString("Pulso:______", Fuente10, Pincel, 420, Y)
            .DrawString("Presión:______", Fuente10, Pincel, 540, Y)
            .DrawString("Temp:______", Fuente10, Pincel, 680, Y)
            Y = Y + 30
            .DrawString("MOLESTIA PRINCIPAL: ", Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString(StrDup(90, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString(StrDup(90, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString(StrDup(90, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 30
            .DrawString("ENFERMEDAD ACTUAL: ", Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString(StrDup(90, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString(StrDup(90, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString(StrDup(90, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 30
            .DrawString("FUNCIONES BIOLOGICAS: ", Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("Apetito " & StrDup(30, "_"), Fuente10, Pincel, 50, Y)
            .DrawString("Sed          " & StrDup(30, "_"), Fuente10, Pincel, 450, Y)
            Y = Y + 20
            .DrawString("Orina   " & StrDup(30, "_"), Fuente10, Pincel, 50, Y)
            .DrawString("Deposiciones " & StrDup(30, "_"), Fuente10, Pincel, 450, Y)
            Y = Y + 20
            .DrawString("Sueño   " & StrDup(30, "_"), Fuente10, Pincel, 50, Y)
            .DrawString("Peso         " & StrDup(30, "_"), Fuente10, Pincel, 450, Y)
            Y = Y + 30
            .DrawString("EXAMEN FISICO: ", Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString(StrDup(90, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString(StrDup(90, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString(StrDup(90, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("DIAGNOSTICOS DE INGRESO", Fuente14N, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("CIE10", Fuente10, Pincel, 50, Y)
            .DrawString("Descripción", Fuente10, Pincel, 200, Y)
            .DrawString("LAB", Fuente10, Pincel, 640, Y)
            .DrawString("Tipo", Fuente10, Pincel, 740, Y)
            Y = Y + 20
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 50, Y)
            .DrawString(StrDup(58, "_"), Fuente10, Pincel, 120, Y)
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 630, Y)
            .DrawString("D(  ) P(  ) R(  )", Fuente10, Pincel, 690, Y)
            Y = Y + 20
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 50, Y)
            .DrawString(StrDup(58, "_"), Fuente10, Pincel, 120, Y)
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 630, Y)
            .DrawString("D(  ) P(  ) R(  )", Fuente10, Pincel, 690, Y)
            Y = Y + 20
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 50, Y)
            .DrawString(StrDup(58, "_"), Fuente10, Pincel, 120, Y)
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 630, Y)
            .DrawString("D(  ) P(  ) R(  )", Fuente10, Pincel, 690, Y)
            Y = Y + 20
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 50, Y)
            .DrawString(StrDup(58, "_"), Fuente10, Pincel, 120, Y)
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 630, Y)
            .DrawString("D(  ) P(  ) R(  )", Fuente10, Pincel, 690, Y)
            Y = Y + 30
            .DrawLine(Pens.Black, 30, Y, 840, Y)
            Y = Y + 10
            .DrawString("ALTA DE PACIENTE", Fuente14N, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("Fecha Alta:___/____/____  Hora Alta:___:___  Médico de Alta:_____________________________", Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("Condición : VIVO(  ) FALLECIDO(  )", Fuente10, Pincel, 50, Y)
            .DrawString("Tipo Alta : MEDICA(  ) VOLUNTARIA(  ) FUGA(  )", Fuente10, Pincel, 350, Y)
            Y = Y + 20
            .DrawString("Destino   : CASA(  ) HOSPITALIZACION(  ) REFERENCIA(  ) CONTRAREFERENCIA(  ) MORGUE(  )", Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("Lugar Des : " & StrDup(60, "_"), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("DIAGNOSTICOS DE ALTA", Fuente14N, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("CIE10", Fuente10, Pincel, 50, Y)
            .DrawString("Descripción", Fuente10, Pincel, 200, Y)
            .DrawString("LAB", Fuente10, Pincel, 640, Y)
            .DrawString("Tipo", Fuente10, Pincel, 740, Y)
            Y = Y + 20
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 50, Y)
            .DrawString(StrDup(58, "_"), Fuente10, Pincel, 120, Y)
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 630, Y)
            .DrawString("D(  ) P(  ) R(  )", Fuente10, Pincel, 690, Y)
            Y = Y + 20
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 50, Y)
            .DrawString(StrDup(58, "_"), Fuente10, Pincel, 120, Y)
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 630, Y)
            .DrawString("D(  ) P(  ) R(  )", Fuente10, Pincel, 690, Y)
            Y = Y + 20
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 50, Y)
            .DrawString(StrDup(58, "_"), Fuente10, Pincel, 120, Y)
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 630, Y)
            .DrawString("D(  ) P(  ) R(  )", Fuente10, Pincel, 690, Y)
            Y = Y + 20
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 50, Y)
            .DrawString(StrDup(58, "_"), Fuente10, Pincel, 120, Y)
            .DrawString(StrDup(6, "_"), Fuente10, Pincel, 630, Y)
            .DrawString("D(  ) P(  ) R(  )", Fuente10, Pincel, 690, Y)
            e.HasMorePages = False
        End With
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If txtFiltro.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtFiltro.Text)
            lvTabla.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
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

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged
        
    End Sub

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged
        If txtPaciente.Text <> "" And txtPaciente.Enabled Then txtFiltro.Text = txtPaciente.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbPaciente.Visible = True : txtFiltro.Select() Else gbPaciente.Visible = False
    End Sub

    Private Sub btnRetornar_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornar.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Enter And lvTabla.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvTabla.SelectedItems(0).SubItems(0).Text
            txtPaciente.Enabled = False
            txtPaciente.Text = lvTabla.SelectedItems(0).SubItems(1).Text & " " & lvTabla.SelectedItems(0).SubItems(2).Text & " " & lvTabla.SelectedItems(0).SubItems(3).Text
            txtPaciente.Enabled = True
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub cboIngSer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboIngSer.SelectedIndexChanged

    End Sub

    Private Sub txtSerieSIS_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieSIS.KeyDown
        If e.KeyCode = Keys.Enter Then txtNumeroSIS.Select()
    End Sub

    Private Sub txtSerieSIS_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerieSIS.LostFocus
        'If IsNumeric(txtSerieSIS.Text) Then txtSerieSIS.Text = Microsoft.VisualBasic.Right("000" & txtSerieSIS.Text, 3)
    End Sub

    Private Sub txtSerieSIS_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerieSIS.TextChanged

    End Sub

    Private Sub txtNumeroSIS_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroSIS.KeyDown
        If e.KeyCode = Keys.Enter Then txtPreliquidacion.Select()
    End Sub

    Private Sub txtNumeroSIS_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroSIS.TextChanged

    End Sub

    Private Sub txtPreliquidacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPreliquidacion.KeyDown
        If e.KeyCode = Keys.Enter And btnGrabar.Enabled Then btnGrabar.Select()
    End Sub

    Private Sub txtPreliquidacion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPreliquidacion.TextChanged

    End Sub
End Class