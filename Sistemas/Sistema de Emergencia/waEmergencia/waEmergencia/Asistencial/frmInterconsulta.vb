Public Class frmInterconsulta
    Dim objInterconsulta As New clsInterconsulta
    Dim objHistoria As New clsHistoria
    Dim objEstadoCivil As New clsEstadoCivil
    Dim objMedico As New Medico
    Dim objIngreso As New clsEmergenciaIngreso
    Dim objConsulta As New clsEmergenciaIngreso_Consulta
    Dim objServicios As New clsEmergenciaSer
    Dim objHospitalizacion As New clsHospitalizacion
    Dim objCie10 As New clsCIE10HE

    Dim Filtro As String
    Dim CodigoIngreso As String

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objInterconsulta.Buscar(CodigoIngreso)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdInterconsulta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Hora"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Responsable"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cie1"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Lab1"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TD1"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Des2"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Lab2"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TD2"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Des3"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Lab3"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TD3"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tratamiento"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Pronostico"))
        Next
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
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            dtpFechaNcto.Value = dsHistorias.Tables(0).Rows(0)("FNacimiento")
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

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub frmInterconsulta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "INTERCONSULTA DE EMERGENCIA - Dr(a) " & NomMedico
        btnCancelar_Click(sender, e)

        'Medico
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            Dim dsVer As New DataSet
            dsVer = objIngreso.VerificarIngreso(txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                CodigoIngreso = dsVer.Tables(0).Rows(0)("IdIngreso")
                lblServicio.Text = dsVer.Tables(0).Rows(0)("Especialidad")
                lblMedico.Text = dsVer.Tables(0).Rows(0)("Medico")
                lblIngEsta.Text = dsVer.Tables(0).Rows(0)("IngEstablecimiento").ToString
                lblIngSer.Text = dsVer.Tables(0).Rows(0)("IngServicio").ToString
                lblInformante.Text = dsVer.Tables(0).Rows(0)("Conyuge")
                lblTipoAtencion.Text = dsVer.Tables(0).Rows(0)("TipoAtencion")
                'cboMedico.Text = dsVer.Tables(0).Rows(0)("Medico")
                lblEdad.Text = dsVer.Tables(0).Rows(0)("Edad")
                lblTEdad.Text = dsVer.Tables(0).Rows(0)("TipoEdad")

                Dim dsDeuda As New DataSet
                dsDeuda = objServicios.BuscarDeuda(CodigoIngreso)
                If dsDeuda.Tables(0).Rows.Count > 0 Then
                    lvTabla.Items.Clear()
                    Dim Fila As ListViewItem
                    For I = 0 To dsDeuda.Tables(0).Rows.Count - 1
                        Fila = lvTabla.Items.Add(dsDeuda.Tables(0).Rows(I)("IdEmerSer"))
                        Fila.SubItems.Add(dsDeuda.Tables(0).Rows(I)("Cantidad"))
                        Fila.SubItems.Add(dsDeuda.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(dsDeuda.Tables(0).Rows(I)("Precio"))
                        Fila.SubItems.Add(Val(dsDeuda.Tables(0).Rows(I)("Precio")) * Val(dsDeuda.Tables(0).Rows(I)("Cantidad")))
                    Next
                    If MessageBox.Show("Paciente Presente Deuda de Procedimientos, envie al paciente a cancelar a Caja. Desea continuar?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Dim Resultado As String
                        Resultado = InputBox("Que Acción desea Realizar con el Pendiente de Pago?" + vbLf + "(A) ANULAR PROCEDIMIENTOS" + vbLf + "(T) TRANSFERIR A HOSPITALIZACION", "Acción a Tomar con Pendiente de Pago")
                        If UCase(Resultado) = "A" Then
                            Dim Motivo As String = InputBox("Ingresar Motivo de Anulación de Procedimientos Pendientes de Pago", "")
                            If Motivo.Length <= 5 Then MessageBox.Show("Debe ingrear un motivo Valido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                            objServicios.AnularProcedimientos(CodigoIngreso, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, Motivo)
                        ElseIf UCase(Resultado) = "T" Then
                            Dim dsVerH As New DataSet
                            dsVerH = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
                            If dsVerH.Tables(0).Rows.Count = 0 Then
                                MessageBox.Show("Paciente no presenta Registro de Sumario de Hospitalización, Solicitar en Admisión su Apertura para realizar esta operación", "Mensaje de Información", MessageBoxButtons.OK)
                                btnCancelar_Click(sender, e)
                                Exit Sub
                            Else
                                Dim Motivo As String = InputBox("Ingresar Motivo de Anulación de Procedimientos Pendientes de Pago", "")
                                objServicios.AnularProcedimientos(CodigoIngreso, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, Motivo)
                                For I = 0 To lvTabla.Items.Count - 1
                                    objHospitalizacion.GuardarDetHospitalizacionArea(dsVerH.Tables(0).Rows(0)("IdHospitalizacion"), lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(3).Text, Date.Now.ToShortDateString, UsuarioSistema, My.Computer.Name, "EMERGENCIA " & lblServicio.Text)
                                Next
                            End If
                        Else
                            MessageBox.Show("Ud a elegido " & Resultado & " que no es un valor válido, Se Cancelara la Operación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            btnCancelar_Click(sender, e)
                            Exit Sub
                        End If
                    Else
                        btnCancelar_Click(sender, e)
                    End If
                End If

                Dim dsConsulta As New DataSet
                dsConsulta = objConsulta.ConsultaBuscar(CodigoIngreso)
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    lblFecha.Text = dsConsulta.Tables(0).Rows(0)("Fecha")
                    lblHora.Text = dsConsulta.Tables(0).Rows(0)("Hora")
                    'txtMolestia.Text = dsConsulta.Tables(0).Rows(0)("MolestiaPrincipal")
                    'txtEnfermedadAct.Text = dsConsulta.Tables(0).Rows(0)("EnfermedadActual")
                    'txtExamenFisico.Text = dsConsulta.Tables(0).Rows(0)("ExamenFisico")
                    lblOrigen.Text = dsConsulta.Tables(0).Rows(0)("Origen")
                    lblDesOrigen.Text = dsConsulta.Tables(0).Rows(0)("DesOrigen")
                    'Talla = dsConsulta.Tables(0).Rows(0)("Talla")
                    'Peso = dsConsulta.Tables(0).Rows(0)("Peso")
                    'Pulso = dsConsulta.Tables(0).Rows(0)("Pulso")
                    'Presion = dsConsulta.Tables(0).Rows(0)("Presion")
                    'Temp = dsConsulta.Tables(0).Rows(0)("Temperatura")
                    'FBApetito = dsConsulta.Tables(0).Rows(0)("Apetito")
                    'FBSed = dsConsulta.Tables(0).Rows(0)("Sed")
                    'FBOrina = dsConsulta.Tables(0).Rows(0)("Orina")
                    'FBDepo = dsConsulta.Tables(0).Rows(0)("Deposiciones")
                    'FBSueño = dsConsulta.Tables(0).Rows(0)("Sueño")
                    'FBPeso = dsConsulta.Tables(0).Rows(0)("PesoFB")

                    'lblCie1.Text = dsConsulta.Tables(0).Rows(0)("Cie1")
                    'lblDes1.Text = dsConsulta.Tables(0).Rows(0)("DesCie1")
                    'lblLab1.Text = dsConsulta.Tables(0).Rows(0)("Lab1")
                    'lblTD1.Text = dsConsulta.Tables(0).Rows(0)("TD1")
                    'lblCie2.Text = dsConsulta.Tables(0).Rows(0)("Cie2")
                    'lblDes2.Text = dsConsulta.Tables(0).Rows(0)("DesCie2")
                    'lblLab2.Text = dsConsulta.Tables(0).Rows(0)("Lab2")
                    'lblTD2.Text = dsConsulta.Tables(0).Rows(0)("TD2")
                    'lblCie3.Text = dsConsulta.Tables(0).Rows(0)("Cie3")
                    'lblDes3.Text = dsConsulta.Tables(0).Rows(0)("DesCie3")
                    'lblLab3.Text = dsConsulta.Tables(0).Rows(0)("Lab3")
                    'lblTD3.Text = dsConsulta.Tables(0).Rows(0)("TD3")
                    'lblCie4.Text = dsConsulta.Tables(0).Rows(0)("Cie4")
                    'lblDes4.Text = dsConsulta.Tables(0).Rows(0)("DesCie4")
                    'lblLab4.Text = dsConsulta.Tables(0).Rows(0)("Lab4")
                    'lblTD4.Text = dsConsulta.Tables(0).Rows(0)("TD4")
                    'lblCie5.Text = dsConsulta.Tables(0).Rows(0)("Cie5")
                    'lblDes5.Text = dsConsulta.Tables(0).Rows(0)("DesCie5")
                    'lblLab5.Text = dsConsulta.Tables(0).Rows(0)("Lab5")
                    'lblTD5.Text = dsConsulta.Tables(0).Rows(0)("TD5")
                    'lblCie6.Text = dsConsulta.Tables(0).Rows(0)("Cie6")
                    'lblDes6.Text = dsConsulta.Tables(0).Rows(0)("DesCie6")
                    'lblLab6.Text = dsConsulta.Tables(0).Rows(0)("Lab6")
                    'lblTD6.Text = dsConsulta.Tables(0).Rows(0)("TD6")
                End If
                dtpFecha.Select()
                Buscar()
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        gbPaciente.Visible = False
        gbCIE.Visible = False
        btnBuscarP.Enabled = False
        dtpFecha.Value = Date.Now
        Botones(True, False, False, True)
        lvTabla.Items.Clear()
        ControlesAD(Me, False)
        Limpiar(Me)
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

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter And txtHora.Text <> "" Then cboMedico.Select()
    End Sub

    Private Sub txtHora_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHora.TextChanged

    End Sub

    Private Sub cboMedico_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboMedico.SelectedValue) Then txtResultado.Select()
    End Sub

    Private Sub cboMedico_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedico.SelectedIndexChanged

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

    Private Sub txtCie1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie1.TextChanged

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

    Private Sub txtCie2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie2.TextChanged

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

    Private Sub txtCie3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie3.TextChanged

    End Sub

    Private Sub txtDes1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes1.TextChanged
        If txtDes1.Text <> "" And txtDes1.Enabled Then txtFiltro.Text = txtDes1.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "1"
    End Sub

    Private Sub txtDes2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes2.TextChanged
        If txtDes2.Text <> "" And txtDes2.Enabled Then txtFiltro.Text = txtDes2.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "2"
    End Sub

    Private Sub txtDes3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes3.TextChanged
        If txtDes3.Text <> "" And txtDes3.Enabled Then txtFiltro.Text = txtDes3.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "3"
    End Sub

    Private Sub txtLab1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab1.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD1.Select()
    End Sub

    Private Sub txtLab1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab1.TextChanged

    End Sub

    Private Sub txtLab2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab2.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD2.Select()
    End Sub

    Private Sub txtLab2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab2.TextChanged

    End Sub

    Private Sub txtLab3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLab3.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD3.Select()
    End Sub

    Private Sub txtLab3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLab3.TextChanged

    End Sub

    Private Sub cboTD1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD1.KeyDown
        If e.KeyCode = Keys.Enter And cboTD1.Text <> "" Then txtCie2.Select()
    End Sub

    Private Sub cboTD1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD1.SelectedIndexChanged

    End Sub

    Private Sub cboTD2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD2.KeyDown
        If e.KeyCode = Keys.Enter And txtCie2.Text = "" Then btnGrabar.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD2.Text <> "" Then txtCie3.Select()
    End Sub

    Private Sub cboTD2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD2.SelectedIndexChanged

    End Sub

    Private Sub cboTD3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTD3.KeyDown
        If e.KeyCode = Keys.Enter And txtCie3.Text = "" Then txtTratamiento.Select()
    End Sub

    Private Sub cboTD3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTD3.SelectedIndexChanged

    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If txtCie1.Text = "" Then MessageBox.Show("Debe ingresar al menos un Diagnostico Válido para la Interconsulta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie1.Select() : Exit Sub
        If txtDes1.Text = "" Then MessageBox.Show("Debe ingresar información del Diagnostico Válido para la Interconsulta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes1.Select() : Exit Sub
        If cboTD1.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para la Interconsulta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD1.Select() : Exit Sub

        If txtCie2.Text <> "" And txtDes2.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para la Interconsulta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes2.Select() : Exit Sub
        If txtCie3.Text <> "" And txtDes3.Text = "" Then MessageBox.Show("Debe ingresar Información del Diagnostico Válido para la Interconsulta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDes3.Select() : Exit Sub
        If txtCie2.Text <> "" And cboTD2.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para la Interconsulta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD2.Select() : Exit Sub
        If txtCie3.Text <> "" And cboTD3.Text = "" Then MessageBox.Show("Debe ingresar Tipo de Diagnostico Válido para la Interconsulta de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD3.Select() : Exit Sub

        'Verificar Diagnosticos Ingresados
        Dim dsCIE As New DataSet
        If txtCie1.Text <> "" Then
            dsCIE = objCie10.BuscarCodigo(txtCie1.Text)
            If dsCIE.Tables(0).Rows.Count = 0 Then MessageBox.Show("Debe ingresar un Diagnostico Válidos en CIE1", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie1.Text = "" : txtDes1.Text = "" : txtCie1.Select() : Exit Sub
        End If
        If txtCie2.Text <> "" Then
            dsCIE = objCie10.BuscarCodigo(txtCie2.Text)
            If dsCIE.Tables(0).Rows.Count = 0 Then MessageBox.Show("Debe ingresar un Diagnostico Válidos en CIE2", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie2.Text = "" : txtDes2.Text = "" : txtCie2.Select() : Exit Sub
        End If
        If txtCie3.Text <> "" Then
            dsCIE = objCie10.BuscarCodigo(txtCie3.Text)
            If dsCIE.Tables(0).Rows.Count = 0 Then MessageBox.Show("Debe ingresar un Diagnostico Válidos en CIE3", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCie3.Text = "" : txtDes3.Text = "" : txtCie3.Select() : Exit Sub
        End If

        If MessageBox.Show("Esta seguro de Grabar Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objInterconsulta.Grabar(CodigoIngreso, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name, dtpFecha.Value.ToShortDateString, txtHora.Text, txtResultado.Text, txtCie1.Text, txtDes1.Text, txtLab1.Text, cboTD1.Text, txtCie2.Text, txtDes2.Text, txtLab2.Text, cboTD2.Text, txtCie3.Text, txtDes3.Text, txtLab3.Text, cboTD3.Text, txtTratamiento.Text, txtPronostico.Text, cboMedico.SelectedValue, cboMedico.Text)
            'ppDialogo.ShowDialog()
            btnCancelar_Click(sender, e)
        End If
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

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub btnRetornar_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornar.Click
        gbCIE.Visible = False
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
            End Select
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        dtpFecha.Value = Date.Now
        txtHora.Text = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboMedico.Text = NomMedico
        btnBuscarP.Enabled = True
        txtHistoria.Select()
    End Sub
End Class