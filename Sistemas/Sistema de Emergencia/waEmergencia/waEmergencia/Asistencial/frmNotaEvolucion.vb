Public Class frmNotaEvolucion
    Dim objNota As New clsNota
    Dim objIngreso As New clsEmergenciaIngreso
    Dim objHistoria As New clsHistoria
    Dim objConsulta As New clsEmergenciaIngreso_Consulta
    Dim objEstadoCivil As New clsEstadoCivil
    Dim objServicios As New clsEmergenciaSer
    Dim objHospitalizacion As New clsHospitalizacion
    Dim objMedico As New Medico

    Dim CodigoIngreso As String

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objNota.Buscar(CodigoIngreso)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdNota"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Hora"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Responsable"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
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

    Private Sub frmNotaEvolucion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "NOTA DE EVOLUCION - Dr(a) " & NomMedico
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
        btnBuscarP.Enabled = False
        dtpFecha.Value = Date.Now
        Botones(True, False, False, True)
        lvTabla.Items.Clear()
        ControlesAD(Me, False)
        Limpiar(Me)
    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        dtpFecha.Value = Date.Now
        txtHora.Text = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboTipo.Text = "SINTOMAS"
        cboMedico.Text = NomMedico
        btnBuscarP.Enabled = True
        txtHistoria.Select()
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter Then cboMedico.Select()
    End Sub

    Private Sub txtHora_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHora.TextChanged

    End Sub

    Private Sub cboMedico_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboMedico.SelectedValue) Then cboTipo.Select()
    End Sub

    Private Sub cboMedico_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedico.SelectedIndexChanged

    End Sub

    Private Sub cboTipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtDescripción.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If txtDescripción.Text = "" Then MessageBox.Show("Debe ingresar una Descripcion de la Nota de Evolución", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDescripción.Select() : Exit Sub
        If cboTipo.Text = "" Then MessageBox.Show("Debe ingresar un Tipo de la Nota de Evolución", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipo.Select() : Exit Sub
        If txtHora.Text = "" Then MessageBox.Show("Debe ingresar la Hora de la Nota de Evolución", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtHora.Select() : Exit Sub
        If Not IsNumeric(cboMedico.SelectedValue) Then MessageBox.Show("Debe ingresar un Médico Responsable de la Nota de Evolución", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboMedico.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar Nota de Evolución", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objNota.Grabar(CodigoIngreso, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name, dtpFecha.Value.ToShortDateString, txtHora.Text, cboMedico.SelectedValue, cboMedico.Text, cboTipo.Text, txtDescripción.Text)
            txtDescripción.Text = ""
            cboTipo.Select()
            Buscar()
        End If
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

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
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
End Class