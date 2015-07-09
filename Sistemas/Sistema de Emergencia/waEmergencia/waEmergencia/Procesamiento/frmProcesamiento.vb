Public Class frmProcesamiento
    Dim objTipoTarifar As New clsTipoTarifa
    Dim objCondicionAlta As New clsCondicionAlta
    Dim objTipoAlta As New clsTipoAlta
    Dim objDestinoFinal As New clsDestinoFinal
    Dim objMedico As New clsMedico
    Dim objHistoria As New clsHistoria
    Dim objEstadoCivil As New clsEstadoCivil
    Dim objIngreso As New clsEmergenciaIngreso
    Dim objConsulta As New clsEmergenciaIngreso_Consulta
    Dim objAlta As New clsEmergenciaIngreso_Alta
    Dim objCie10 As New clsCIE10HE
    Dim objServicio As New clsServicioEmergencia

    Dim Filtro As String
    Dim OperConsulta As Boolean
    Dim OperAlta As Boolean

    Dim CodigoIngreso As String

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
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

            Dim FNacimiento As String
            If dsHistorias.Tables(0).Rows(0)("FNacimiento").ToString = "" Then
                FNacimiento = InputBox("Ingresar Fecha de Nacimiento", "Datos de Paciente")
                dtpFechaNcto.Value = FNacimiento
                objHistoria.GrabarFN(txtHistoria.Text, dtpFechaNcto.Value.ToShortDateString)
            Else
                'Calcular Edad
                dtpFechaNcto.Value = dsHistorias.Tables(0).Rows(0)("FNacimiento")
                CalcularEdad(dtpFecha.Value, dtpFechaNcto.Value)
            End If

            

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
            btnGrabar.Enabled = True
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        lvLista.Items.Clear()
        gbCIE.Visible = False
        gbCIEA.Visible = False
        lvLista.Enabled = False
        dtpFecha.Value = Date.Now
        Botones(True, False, False, True)
        btnBuscarP.Enabled = False
        ControlesAD(Me, False)
        cboSala.Text = "NO"
        cboPrioridad.SelectedIndex = 0
        cboArea.SelectedIndex = 0
        gbPaciente.Visible = False
        Limpiar(Me)
    End Sub

    Private Sub frmProcesamiento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Tipo Tarifa
        Dim dsTT As New DataSet
        dsTT = objTipoTarifar.Combo
        cboTipoAtencion.DataSource = dsTT.Tables(0)
        cboTipoAtencion.DisplayMember = "Descripcion"
        cboTipoAtencion.ValueMember = "IdTipoTarifa"

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
        Dim dsMedicoI As New DataSet
        dsMedicoI = objMedico.Medico_BuscarNombres("")
        cboMedicoIng.DataSource = dsMedicoI.Tables(0)
        cboMedicoIng.DisplayMember = "NMedico"
        cboMedicoIng.ValueMember = "IdMedico"

        'Servicio Emergencia
        Dim dsServicio As New DataSet
        dsServicio = objServicio.Buscar
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        dtpFecha.Value = Date.Now
        txtHora.Text = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboOrigen.Text = "CASA"
        'cboDesOrigen.Text = "NINGUNO"
        btnBuscarP.Enabled = True
        lvLista.Enabled = False
        txtFHistoria.Select()
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged
        lblFechaAdmision.Text = dtpFecha.Value.ToShortDateString
    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter And txtHora.Text <> "" Then txtHistoria.Select()
    End Sub

    Private Sub txtFHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtFHistoria.Text) Then
            lvLista.Items.Clear()
            lvLista.Enabled = True
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim dsLista As New DataSet
            dsLista = objIngreso.BuscarHistoria(txtFHistoria.Text)

            For I = 0 To dsLista.Tables(0).Rows.Count - 1
                Fila = lvLista.Items.Add(dsLista.Tables(0).Rows(I)("IdIngreso"))
                Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("FechaIngreso"))
                Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("HoraIngreso"))
                Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("Especialidad"))
                Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("TipoAtencion").ToString)
                Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("FechaAlta").ToString)
            Next
        End If
    End Sub

    Private Sub lvLista_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvLista.KeyDown
        If lvLista.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Atencion de Emergencia?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objIngreso.Eliminar(lvLista.SelectedItems(0).SubItems(0).Text)
                lvLista.Items.RemoveAt(lvLista.SelectedItems(0).Index)
            End If
        End If
        If lvLista.SelectedItems.Count > 0 And e.KeyCode = Keys.A Then
            If MessageBox.Show("Esta seguro de Anular Alta de Emergencia?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objAlta.AltaEliminar(lvLista.SelectedItems(0).SubItems(0).Text)
                lvLista.SelectedItems(0).SubItems(5).Text = ""
            End If
        End If
    End Sub

    Private Sub lvLista_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvLista.SelectedIndexChanged
        If lvLista.SelectedItems.Count > 0 Then
            Dim tHistoria As String = txtFHistoria.Text
            Limpiar(Me)
            txtFHistoria.Text = tHistoria
            CodigoIngreso = lvLista.SelectedItems(0).SubItems(0).Text
            txtHistoria.Text = txtFHistoria.Text
            BuscarHistoria()
            OperConsulta = False
            OperAlta = False

            Dim dsVer As New DataSet
            dsVer = objIngreso.BuscarCodigo(CodigoIngreso)
            If dsVer.Tables(0).Rows.Count > 0 Then
                CodigoIngreso = dsVer.Tables(0).Rows(0)("IdIngreso")
                cboServicio.Text = dsVer.Tables(0).Rows(0)("Especialidad")
                cboMedicoIng.Text = dsVer.Tables(0).Rows(0)("Medico")
                cboIngEst.Text = dsVer.Tables(0).Rows(0)("IngEstablecimiento").ToString
                cboIngSer.Text = dsVer.Tables(0).Rows(0)("IngServicio").ToString
                dtpFecha.Value = dsVer.Tables(0).Rows(0)("FechaIngreso")
                txtHora.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblFechaAdmision.Text = dsVer.Tables(0).Rows(0)("FechaIngreso")
                lblHoraAdmision.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblInformante.Text = dsVer.Tables(0).Rows(0)("Conyuge")
                cboTipoAtencion.Text = dsVer.Tables(0).Rows(0)("TipoAtencion").ToString
                cboSala.Text = dsVer.Tables(0).Rows(0)("SalaObservacion").ToString
                cboIngSer.Text = dsVer.Tables(0).Rows(0)("IngServicio").ToString
                cboTipoAtenEmer.Text = dsVer.Tables(0).Rows(0)("TipoEmergencia").ToString
                If dsVer.Tables(0).Rows(0)("prioridad").ToString.Equals("") Then
                    cboPrioridad.SelectedIndex = 0
                Else
                    cboPrioridad.SelectedItem = dsVer.Tables(0).Rows(0)("prioridad").ToString
                End If
                If dsVer.Tables(0).Rows(0)("area").ToString.Equals("") Then
                    cboArea.SelectedIndex = 0
                Else
                    cboArea.SelectedItem = dsVer.Tables(0).Rows(0)("area").ToString
                End If


                Dim dsConsulta As New DataSet
                dsConsulta = objConsulta.ConsultaBuscar(CodigoIngreso)
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    OperConsulta = True
                    dtpFecha.Value = dsConsulta.Tables(0).Rows(0)("Fecha")
                    txtHora.Text = dsConsulta.Tables(0).Rows(0)("Hora")
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
                    cboOrigen.Text = dsConsulta.Tables(0).Rows(0)("Origen")
                    cboDesOrigen.Text = dsConsulta.Tables(0).Rows(0)("Motivo")
                    'cboSala.Text = dsConsulta.Tables(0).Rows(0)("Sala")
                    cboRCP.Text = dsConsulta.Tables(0).Rows(0)("RCP")
                Else
                    OperConsulta = False
                End If

                'Alta de Paciente
                Dim dsAlta As New DataSet
                dsAlta = objAlta.BuscarAlta(CodigoIngreso)
                If dsAlta.Tables(0).Rows.Count > 0 Then
                    OperAlta = True

                    dtpFechaAlta.Value = dsAlta.Tables(0).Rows(0)("Fecha")
                    txtHoraAlta.Text = dsAlta.Tables(0).Rows(0)("Hora")
                    cboCondicion.Text = dsAlta.Tables(0).Rows(0)("CondicionAlta")
                    cboMedico.Text = dsAlta.Tables(0).Rows(0)("Medico")
                    cboTipoAlta.Text = dsAlta.Tables(0).Rows(0)("TipoAlta")
                    cboDestino.Text = dsAlta.Tables(0).Rows(0)("Destino")
                    txtDesDestino.Text = dsAlta.Tables(0).Rows(0)("DesDestino")

                    txtCie1A.Text = dsAlta.Tables(0).Rows(0)("Cie1")
                    txtDes1A.Enabled = False
                    txtDes1A.Text = dsAlta.Tables(0).Rows(0)("DesCie1")
                    txtDes1A.Enabled = True
                    txtLab1A.Text = dsAlta.Tables(0).Rows(0)("Lab1")
                    cboTD1A.Text = dsAlta.Tables(0).Rows(0)("TD1")
                    txtCie2A.Text = dsAlta.Tables(0).Rows(0)("Cie2")
                    txtDes2A.Enabled = False
                    txtDes2A.Text = dsAlta.Tables(0).Rows(0)("DesCie2")
                    txtDes2A.Enabled = True
                    txtLab2A.Text = dsAlta.Tables(0).Rows(0)("Lab2")
                    cboTD2A.Text = dsAlta.Tables(0).Rows(0)("TD2")
                    txtCie3A.Text = dsAlta.Tables(0).Rows(0)("Cie3")
                    txtDes3A.Enabled = False
                    txtDes3A.Text = dsAlta.Tables(0).Rows(0)("DesCie3")
                    txtDes3A.Enabled = True
                    txtLab3A.Text = dsAlta.Tables(0).Rows(0)("Lab3")
                    cboTD3A.Text = dsAlta.Tables(0).Rows(0)("TD3")
                    txtCie4A.Text = dsAlta.Tables(0).Rows(0)("Cie4")
                    txtDes4A.Enabled = False
                    txtDes4A.Text = dsAlta.Tables(0).Rows(0)("DesCie4")
                    txtDes4A.Enabled = True
                    txtLab4A.Text = dsAlta.Tables(0).Rows(0)("Lab4")
                    cboTD4A.Text = dsAlta.Tables(0).Rows(0)("TD4")
                    txtCie5A.Text = dsAlta.Tables(0).Rows(0)("Cie5")
                    txtDes5A.Enabled = False
                    txtDes5A.Text = dsAlta.Tables(0).Rows(0)("DesCie5")
                    txtDes5A.Enabled = True
                    txtLab5A.Text = dsAlta.Tables(0).Rows(0)("Lab5")
                    cboTD5A.Text = dsAlta.Tables(0).Rows(0)("TD5")
                    txtCie6A.Text = dsAlta.Tables(0).Rows(0)("Cie6")
                    txtDes6A.Enabled = False
                    txtDes6A.Text = dsAlta.Tables(0).Rows(0)("DesCie6")
                    txtDes6A.Enabled = True
                    txtLab6A.Text = dsAlta.Tables(0).Rows(0)("Lab6")
                    cboTD6A.Text = dsAlta.Tables(0).Rows(0)("TD6")
                Else
                    OperAlta = False
                    cboMedico.Text = cboMedicoIng.Text
                    cboCondicion.Text = "VIVO"
                    cboTipoAlta.Text = "ALTA MEDICA"
                    cboDestino.Text = "CASA"
                    dtpFechaAlta.Value = dtpFecha.Value
                    txtHoraAlta.Text = txtHora.Text
                End If
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
            End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If cboTipoAtencion.Text = "" Then MessageBox.Show("Debe definir el tipo de Ingreso del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Select() : Exit Sub
        If cboIngEst.Text = "" Then MessageBox.Show("Debe definir el tipo de Ingreso al establecimiento del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboIngEst.Select() : Exit Sub
        If cboIngSer.Text = "" Then MessageBox.Show("Debe definir el tipo de Ingreso al servicio del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboIngSer.Select() : Exit Sub
        If cboMedicoIng.Text = "" Then MessageBox.Show("Debe definir el médico de ingreso", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboMedicoIng.Select() : Exit Sub
        If cboMedico.Text = "" Then MessageBox.Show("Debe definir el médico de alta", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboMedico.Select() : Exit Sub
        If cboDesOrigen.SelectedIndex = 0 Then MessageBox.Show("Debe definir motivo Atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        'If cboPrioridad.SelectedIndex = 0 Then MessageBox.Show("Debe definir prioridad Atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        ' If cbo.SelectedIndex = 0 Then MessageBox.Show("Debe definir motivo Atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

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
        Try
            objIngreso.ModificarProcesamiento(CodigoIngreso, cboServicio.Text, cboMedicoIng.Text, cboTipoAtencion.Text, cboIngEst.Text, cboIngSer.Text, cboSala.Text, lblFechaAdmision.Text)
            objIngreso.ModificarPrioridadArea(CodigoIngreso, cboPrioridad.Text, cboArea.Text)
            If Not OperConsulta Then
                objConsulta.GrabarSala(CodigoIngreso, dtpFecha.Value.ToShortDateString, txtHora.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtCie1.Text, txtDes1.Text, txtLab1.Text, cboTD1.Text, txtCie2.Text, txtDes2.Text, txtLab2.Text, cboTD2.Text, txtCie3.Text, txtDes3.Text, txtLab3.Text, cboTD3.Text, txtCie4.Text, txtDes4.Text, txtLab4.Text, cboTD4.Text, txtCie5.Text, txtDes5.Text, txtLab5.Text, cboTD5.Text, txtCie6.Text, txtDes6.Text, txtLab6.Text, cboTD6.Text, "", "", cboOrigen.Text, cboDesOrigen.Text, "", cboSala.Text, cboRCP.Text)
            Else
                objConsulta.ModificarProSala(CodigoIngreso, dtpFecha.Value.ToShortDateString, txtHora.Text, txtCie1.Text, txtDes1.Text, txtLab1.Text, cboTD1.Text, txtCie2.Text, txtDes2.Text, txtLab2.Text, cboTD2.Text, txtCie3.Text, txtDes3.Text, txtLab3.Text, cboTD3.Text, txtCie4.Text, txtDes4.Text, txtLab4.Text, cboTD4.Text, txtCie5.Text, txtDes5.Text, txtLab5.Text, cboTD5.Text, txtCie6.Text, txtDes6.Text, txtLab6.Text, cboTD6.Text, cboOrigen.Text, cboDesOrigen.Text, cboSala.Text, cboRCP.Text)
            End If
            If Not OperAlta Then
                objAlta.Grabar(CodigoIngreso, dtpFechaAlta.Value.ToShortDateString, txtHoraAlta.Text, cboCondicion.Text, cboMedico.Text, cboTipoAlta.Text, cboDestino.Text, txtDesDestino.Text, txtCie1A.Text, txtDes1A.Text, txtLab1A.Text, cboTD1A.Text, txtCie2A.Text, txtDes2A.Text, txtLab2A.Text, cboTD2A.Text, txtCie3A.Text, txtDes3A.Text, txtLab3A.Text, cboTD3A.Text, txtCie4A.Text, txtDes4A.Text, txtLab4A.Text, cboTD4A.Text, txtCie5A.Text, txtDes5A.Text, txtLab5A.Text, cboTD5A.Text, txtCie6A.Text, txtDes6A.Text, txtLab6A.Text, cboTD6A.Text, cboMedico.SelectedValue)
            Else
                objAlta.Modificar(CodigoIngreso, dtpFechaAlta.Value.ToShortDateString, txtHoraAlta.Text, cboCondicion.Text, cboMedico.Text, cboTipoAlta.Text, cboDestino.Text, txtDesDestino.Text, txtCie1A.Text, txtDes1A.Text, txtLab1A.Text, cboTD1A.Text, txtCie2A.Text, txtDes2A.Text, txtLab2A.Text, cboTD2A.Text, txtCie3A.Text, txtDes3A.Text, txtLab3A.Text, cboTD3A.Text, txtCie4A.Text, txtDes4A.Text, txtLab4A.Text, cboTD4A.Text, txtCie5A.Text, txtDes5A.Text, txtLab5A.Text, cboTD5A.Text, txtCie6A.Text, txtDes6A.Text, txtLab6A.Text, cboTD6A.Text, cboMedico.SelectedValue)
            End If

            'Grabar Tipo de Ingreso y Emergencia
            objIngreso.TipoIngreso(CodigoIngreso, cboIngSer.Text, cboTipoAtenEmer.Text)

            btnCancelar_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
       
    End Sub

    Private Sub txtCie1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie1.KeyDown
        If e.KeyCode = Keys.Enter And txtCie1.Text = "" Then txtDes1.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie1.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie1.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
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

    Private Sub txtCie2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie2.KeyDown
        If e.KeyCode = Keys.Enter And txtCie2.Text = "" Then txtDes2.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie2.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie2.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
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

    Private Sub txtCie3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie3.KeyDown
        If e.KeyCode = Keys.Enter And txtCie3.Text = "" Then txtDes3.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie3.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie3.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
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

    Private Sub txtCie4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie4.KeyDown
        If e.KeyCode = Keys.Enter And txtCie4.Text = "" Then txtDes4.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie4.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie4.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
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

    Private Sub txtCie5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie5.KeyDown
        If e.KeyCode = Keys.Enter And txtCie5.Text = "" Then txtDes5.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie5.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie5.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
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

    Private Sub txtCie6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie6.KeyDown
        If e.KeyCode = Keys.Enter And txtCie6.Text = "" Then txtDes6.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCie6.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCie10.BuscarCodigo(txtCie6.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
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

    Private Sub txtDes1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes1.KeyDown
        If e.KeyCode = Keys.Enter And txtDes1.Text = "" Then txtLab1.Select()
    End Sub

    Private Sub txtDes1_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes1.TextChanged
        If txtDes1.Text <> "" And txtDes1.Enabled Then txtFiltro.Text = txtDes1.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "1"
    End Sub

    Private Sub txtDes2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes2.KeyDown
        If e.KeyCode = Keys.Enter And txtDes2.Text = "" Then txtLab2.Select()
    End Sub

    Private Sub txtDes2_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes2.TextChanged
        If txtDes2.Text <> "" And txtDes2.Enabled Then txtFiltro.Text = txtDes2.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "2"
    End Sub

    Private Sub txtDes3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes3.KeyDown
        If e.KeyCode = Keys.Enter And txtDes3.Text = "" Then txtLab3.Select()
    End Sub

    Private Sub txtDes3_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes3.TextChanged
        If txtDes3.Text <> "" And txtDes3.Enabled Then txtFiltro.Text = txtDes3.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "3"
    End Sub

    Private Sub txtDes4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes4.KeyDown
        If e.KeyCode = Keys.Enter And txtDes4.Text = "" Then txtLab4.Select()
    End Sub

    Private Sub txtDes4_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes4.TextChanged
        If txtDes4.Text <> "" And txtDes4.Enabled Then txtFiltro.Text = txtDes4.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "4"
    End Sub

    Private Sub txtDes5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes5.KeyDown
        If e.KeyCode = Keys.Enter And txtDes5.Text = "" Then txtLab5.Select()
    End Sub

    Private Sub txtDes5_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes5.TextChanged
        If txtDes5.Text <> "" And txtDes5.Enabled Then txtFiltro.Text = txtDes5.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "5"
    End Sub

    Private Sub txtDes6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes6.KeyDown
        If e.KeyCode = Keys.Enter And txtDes6.Text = "" Then txtLab6.Select()
    End Sub

    Private Sub txtDes6_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes6.TextChanged
        If txtDes6.Text <> "" And txtDes6.Enabled Then txtFiltro.Text = txtDes6.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "6"
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
            Next
            If lvCIE.Items.Count > 0 Then lvCIE.Select()
        End If
    End Sub

    Private Sub lvCIE_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvCIE.KeyDown
        If e.KeyCode = Keys.Enter And lvCIE.SelectedItems.Count > 0 Then
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

    Private Sub txtDes1A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes1A.KeyDown
        If e.KeyCode = Keys.Enter And txtDes1A.Text = "" Then txtLab1A.Select()
    End Sub

    Private Sub txtDes1A_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes1A.TextChanged
        If txtDes1A.Text <> "" And txtDes1A.Enabled Then txtFiltroA.Text = txtDes1A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "1"
    End Sub

    Private Sub txtDes2A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes2A.KeyDown
        If e.KeyCode = Keys.Enter And txtDes2A.Text = "" Then txtLab2A.Select()
    End Sub

    Private Sub txtDes3A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes3A.KeyDown
        If e.KeyCode = Keys.Enter And txtDes3A.Text = "" Then txtLab3A.Select()
    End Sub

    Private Sub txtDes4A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes4A.KeyDown
        If e.KeyCode = Keys.Enter And txtDes4A.Text = "" Then txtLab4A.Select()
    End Sub

    Private Sub txtDes5A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes5A.KeyDown
        If e.KeyCode = Keys.Enter And txtDes5A.Text = "" Then txtLab5A.Select()
    End Sub

    Private Sub txtDes6A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes6A.KeyDown
        If e.KeyCode = Keys.Enter And txtDes6A.Text = "" Then txtLab6A.Select()
    End Sub

    Private Sub txtLab1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab1.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD1.Select()
    End Sub

    Private Sub cboTD1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD1.KeyDown
        If e.KeyCode = Keys.Enter And cboTD2.Text <> "" Then txtCie2.Select()
    End Sub

    Private Sub cboTD1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD1.SelectedIndexChanged

    End Sub

    Private Sub txtLab2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab2.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD2.Select()
    End Sub

    Private Sub txtLab2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLab2.KeyPress

    End Sub

    Private Sub txtLab2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab2.TextChanged

    End Sub

    Private Sub txtLab3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab3.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD3.Select()
    End Sub

    Private Sub txtLab3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab3.TextChanged

    End Sub

    Private Sub txtLab4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab4.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD4.Select()
    End Sub

    Private Sub txtLab4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab4.TextChanged

    End Sub

    Private Sub txtLab5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab5.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD5.Select()
    End Sub

    Private Sub txtLab5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab5.TextChanged

    End Sub

    Private Sub txtLab6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab6.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD6.Select()
    End Sub

    Private Sub txtLab6_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab6.TextChanged

    End Sub

    Private Sub cboTD2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD2.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie3.Select()
    End Sub

    Private Sub cboTD2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD2.SelectedIndexChanged

    End Sub

    Private Sub cboTD3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD3.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie4.Select()
    End Sub

    Private Sub cboTD3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD3.SelectedIndexChanged

    End Sub

    Private Sub cboTD4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD4.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie5.Select()
    End Sub

    Private Sub cboTD4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD4.SelectedIndexChanged

    End Sub

    Private Sub cboTD5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD5.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie6.Select()
    End Sub

    Private Sub cboTD5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD5.SelectedIndexChanged

    End Sub

    Private Sub cboTD6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD6.KeyDown
        If e.KeyCode = Keys.Enter Then dtpFechaAlta.Select()
    End Sub

    Private Sub cboTD6_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD6.SelectedIndexChanged

    End Sub

    Private Sub cboMedicoIng_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMedicoIng.KeyDown
        If e.KeyCode = Keys.Enter And cboMedicoIng.Text <> "" Then cboIngEst.Select()
    End Sub

    Private Sub cboMedicoIng_TextChanged(sender As Object, e As System.EventArgs) Handles cboMedicoIng.TextChanged
        If IsNumeric(cboMedicoIng.SelectedValue) Then cboMedico.Text = cboMedicoIng.Text
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtHistoria.Text) Then cboTipoAtencion.Select()
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub cboTipoAtencion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAtencion.KeyDown
        If cboTipoAtencion.Text <> "" And e.KeyCode = Keys.Enter Then cboServicio.Select()
    End Sub

    Private Sub cboTipoAtencion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoAtencion.SelectedIndexChanged

    End Sub

    Private Sub cboServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And cboServicio.Text <> "" Then cboMedicoIng.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServicio.SelectedIndexChanged

    End Sub

    Private Sub cboMedicoIng_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedicoIng.SelectedIndexChanged

    End Sub

    Private Sub cboIngEst_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboIngEst.KeyDown
        If e.KeyCode = Keys.Enter And cboIngEst.Text <> "" Then cboIngSer.Select()
    End Sub

    Private Sub cboIngEst_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboIngEst.SelectedIndexChanged

    End Sub

    Private Sub cboIngSer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboIngSer.KeyDown
        If e.KeyCode = Keys.Enter And cboIngSer.Text <> "" Then cboOrigen.Select()
    End Sub

    Private Sub cboIngSer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboIngSer.SelectedIndexChanged

    End Sub

    Private Sub cboOrigen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboOrigen.KeyDown
        If e.KeyCode = Keys.Enter And cboOrigen.Text <> "" Then cboDesOrigen.Select()
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged

    End Sub

    Private Sub cboDesOrigen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboDesOrigen.KeyDown
        If e.KeyCode = Keys.Enter And cboDesOrigen.Text <> "" Then cboSala.Select()
    End Sub

    Private Sub cboDesOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDesOrigen.SelectedIndexChanged

    End Sub

    Private Sub txtCie1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie1.TextChanged
        If txtCie1.Text = "" Then txtDes1.Text = "" : txtLab1.Text = "" : cboTD1.Text = ""
    End Sub

    Private Sub txtCie2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie2.TextChanged
        If txtCie2.Text = "" Then txtDes2.Text = "" : txtLab2.Text = "" : cboTD2.Text = ""
    End Sub

    Private Sub txtLab1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab1.TextChanged

    End Sub

    Private Sub txtCie3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie3.TextChanged
        If txtCie3.Text = "" Then txtDes3.Text = "" : txtLab3.Text = "" : cboTD3.Text = ""
    End Sub

    Private Sub txtCie4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie4.TextChanged
        If txtCie4.Text = "" Then txtDes4.Text = "" : txtLab4.Text = "" : cboTD4.Text = ""
    End Sub

    Private Sub txtCie5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie5.TextChanged
        If txtCie5.Text = "" Then txtDes5.Text = "" : txtLab5.Text = "" : cboTD5.Text = ""
    End Sub

    Private Sub txtCie6_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie6.TextChanged
        If txtCie6.Text = "" Then txtDes6.Text = "" : txtLab6.Text = "" : cboTD6.Text = ""
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub lvCIE_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCIE.SelectedIndexChanged

    End Sub

    Private Sub dtpFechaAlta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaAlta.KeyDown
        If e.KeyCode = Keys.Enter Then txtHoraAlta.Select()
    End Sub

    Private Sub dtpFechaAlta_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaAlta.ValueChanged

    End Sub

    Private Sub txtHoraAlta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHoraAlta.KeyDown
        If e.KeyCode = Keys.Enter And txtHoraAlta.Text <> "" Then cboCondicion.Select()
    End Sub

    Private Sub txtHoraAlta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHoraAlta.TextChanged

    End Sub

    Private Sub cboCondicion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCondicion.KeyDown
        If e.KeyCode = Keys.Enter And cboCondicion.Text <> "" Then cboMedico.Select()
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
        If e.KeyCode = Keys.Enter And cboDestino.Text <> "" Then txtDesDestino.Select()
    End Sub

    Private Sub cboDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDestino.SelectedIndexChanged

    End Sub

    Private Sub txtDesDestino_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDesDestino.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie1A.Select()
    End Sub

    Private Sub txtDesDestino_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDesDestino.TextChanged

    End Sub

    Private Sub txtLab1A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab1A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD1A.Select()
    End Sub

    Private Sub txtLab1A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab1A.TextChanged

    End Sub

    Private Sub txtLab2A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab2A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD2A.Select()
    End Sub

    Private Sub txtLab2A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab2A.TextChanged

    End Sub

    Private Sub txtLab3A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab3A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD3A.Select()
    End Sub

    Private Sub txtLab3A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab3A.TextChanged

    End Sub

    Private Sub txtLab4A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab4A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD4A.Select()
    End Sub

    Private Sub txtLab4A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab4A.TextChanged

    End Sub

    Private Sub txtLab5A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab5A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD5A.Select()
    End Sub

    Private Sub txtLab5A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab5A.TextChanged

    End Sub

    Private Sub txtLab6A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab6A.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD6A.Select()
    End Sub

    Private Sub txtLab6A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab6A.TextChanged

    End Sub

    Private Sub cboTD1A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD1A.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie2A.Select()
    End Sub

    Private Sub cboTD1A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD1A.SelectedIndexChanged

    End Sub

    Private Sub cboTD2A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD2A.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie3A.Select()
    End Sub

    Private Sub cboTD2A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD2A.SelectedIndexChanged

    End Sub

    Private Sub cboTD3A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD3A.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie4A.Select()
    End Sub

    Private Sub cboTD3A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD3A.SelectedIndexChanged

    End Sub

    Private Sub cboTD4A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD4A.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie5A.Select()
    End Sub

    Private Sub cboTD4A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD4A.SelectedIndexChanged

    End Sub

    Private Sub cboTD5A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD5A.KeyDown
        If e.KeyCode = Keys.Enter Then txtCie6A.Select()
    End Sub

    Private Sub cboTD5A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD5A.SelectedIndexChanged

    End Sub

    Private Sub cboTD6A_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD6A.KeyDown
        If e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub cboTD6A_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD6A.SelectedIndexChanged

    End Sub

    Private Sub txtDes2A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes2A.TextChanged
        If txtDes2A.Text <> "" And txtDes2A.Enabled Then txtFiltroA.Text = txtDes2A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "2"
    End Sub

    Private Sub txtDes3A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes3A.TextChanged
        If txtDes3A.Text <> "" And txtDes3A.Enabled Then txtFiltroA.Text = txtDes3A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "3"
    End Sub

    Private Sub txtDes4A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes4A.TextChanged
        If txtDes4A.Text <> "" And txtDes4A.Enabled Then txtFiltroA.Text = txtDes4A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "4"
    End Sub

    Private Sub txtDes5A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes5A.TextChanged
        If txtDes5A.Text <> "" And txtDes5A.Enabled Then txtFiltroA.Text = txtDes5A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "5"
    End Sub

    Private Sub txtDes6A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes6A.TextChanged
        If txtDes6A.Text <> "" And txtDes6A.Enabled Then txtFiltroA.Text = txtDes6A.Text : txtFiltroA.SelectionStart = txtFiltroA.Text.Length : gbCIEA.Visible = True : txtFiltroA.Select() : Filtro = "6"
    End Sub

    Private Sub cboSala_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSala.KeyDown
        If e.KeyCode = Keys.Enter And cboSala.Text <> "" Then txtCie1.Select()
    End Sub

    Private Sub cboSala_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSala.SelectedIndexChanged

    End Sub

    Private Sub txtCie1A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie1A.TextChanged
        If txtCie1A.Text = "" Then txtDes1A.Text = "" : txtLab1A.Text = "" : cboTD1A.Text = ""
    End Sub

    Private Sub txtCie2A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie2A.TextChanged
        If txtCie2A.Text = "" Then txtDes2A.Text = "" : txtLab2A.Text = "" : cboTD2A.Text = ""
    End Sub

    Private Sub txtCie3A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie3A.TextChanged
        If txtCie3A.Text = "" Then txtDes3A.Text = "" : txtLab3A.Text = "" : cboTD3A.Text = ""
    End Sub

    Private Sub txtCie4A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie4A.TextChanged
        If txtCie4A.Text = "" Then txtDes4A.Text = "" : txtLab4A.Text = "" : cboTD4A.Text = ""
    End Sub

    Private Sub txtCie5A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie5A.TextChanged
        If txtCie5A.Text = "" Then txtDes5A.Text = "" : txtLab5A.Text = "" : cboTD5A.Text = ""
    End Sub

    Private Sub txtCie6A_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie6A.TextChanged
        If txtCie6A.Text = "" Then txtDes6A.Text = "" : txtLab6A.Text = "" : cboTD6A.Text = ""
    End Sub

    Private Sub txtFHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFHistoria.TextChanged

    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
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

    Private Sub lvPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtFHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            gbPaciente.Visible = False
            txtFHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub cboPrioridad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPrioridad.SelectedIndexChanged

    End Sub
End Class