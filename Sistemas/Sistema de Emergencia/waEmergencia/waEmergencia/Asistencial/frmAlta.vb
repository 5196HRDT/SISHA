Public Class frmAlta
    Dim objAlta As New clsEmergenciaIngreso_Alta
    Dim objIngreso As New clsEmergenciaIngreso
    Dim objConsulta As New clsEmergenciaIngreso_Consulta
    Dim objHistoria As New clsHistoria
    Dim objEstadoCivil As New clsEstadoCivil
    Dim objCie10 As New clsCIE10HE
    Dim objTipoAlta As New clsTipoAlta
    Dim objCondicionAlta As New clsCondicionAlta
    Dim objDestinoFinal As New clsDestinoFinal
    Dim objMedico As New clsMedico
    Dim objServicios As New clsEmergenciaSer
    Dim objHospitalizacion As New clsHospitalizacion


    Dim Talla As String
    Dim Peso As String
    Dim Pulso As String
    Dim Presion As String
    Dim Temp As String
    Dim FBApetito As String
    Dim FBSed As String
    Dim FBOrina As String
    Dim FBDepo As String
    Dim FBSueño As String
    Dim FBPeso As String


    Dim CodigoIngreso As String
    Dim Filtro As String

    'Variables Impresion
    Dim Fuente24N As New Font("Courier New", 24, FontStyle.Bold)
    Dim Fuente14N As New Font("Courier New", 14, FontStyle.Bold)
    Dim Fuente12 As New Font("Courier New", 12)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente10 As New Font("Courier New", 10)
    Dim Fuente10N As New Font("Courier New", 10, FontStyle.Bold)
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
                cboMedico.Text = dsVer.Tables(0).Rows(0)("Medico")
                lblEdad.Text = dsVer.Tables(0).Rows(0)("Edad")
                lblTEdad.Text = dsVer.Tables(0).Rows(0)("TipoEdad")
                cboCondicion.Select()

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
                    txtMolestia.Text = dsConsulta.Tables(0).Rows(0)("MolestiaPrincipal")
                    txtEnfermedadAct.Text = dsConsulta.Tables(0).Rows(0)("EnfermedadActual")
                    txtExamenFisico.Text = dsConsulta.Tables(0).Rows(0)("ExamenFisico")
                    lblOrigen.Text = dsConsulta.Tables(0).Rows(0)("Origen")
                    lblDesOrigen.Text = dsConsulta.Tables(0).Rows(0)("DesOrigen")
                    Talla = dsConsulta.Tables(0).Rows(0)("Talla")
                    Peso = dsConsulta.Tables(0).Rows(0)("Peso")
                    Pulso = dsConsulta.Tables(0).Rows(0)("Pulso")
                    Presion = dsConsulta.Tables(0).Rows(0)("Presion")
                    Temp = dsConsulta.Tables(0).Rows(0)("Temperatura")
                    FBApetito = dsConsulta.Tables(0).Rows(0)("Apetito")
                    FBSed = dsConsulta.Tables(0).Rows(0)("Sed")
                    FBOrina = dsConsulta.Tables(0).Rows(0)("Orina")
                    FBDepo = dsConsulta.Tables(0).Rows(0)("Deposiciones")
                    FBSueño = dsConsulta.Tables(0).Rows(0)("Sueño")
                    FBPeso = dsConsulta.Tables(0).Rows(0)("PesoFB")

                    lblCie1.Text = dsConsulta.Tables(0).Rows(0)("Cie1")
                    lblDes1.Text = dsConsulta.Tables(0).Rows(0)("DesCie1")
                    lblLab1.Text = dsConsulta.Tables(0).Rows(0)("Lab1")
                    lblTD1.Text = dsConsulta.Tables(0).Rows(0)("TD1")
                    lblCie2.Text = dsConsulta.Tables(0).Rows(0)("Cie2")
                    lblDes2.Text = dsConsulta.Tables(0).Rows(0)("DesCie2")
                    lblLab2.Text = dsConsulta.Tables(0).Rows(0)("Lab2")
                    lblTD2.Text = dsConsulta.Tables(0).Rows(0)("TD2")
                    lblCie3.Text = dsConsulta.Tables(0).Rows(0)("Cie3")
                    lblDes3.Text = dsConsulta.Tables(0).Rows(0)("DesCie3")
                    lblLab3.Text = dsConsulta.Tables(0).Rows(0)("Lab3")
                    lblTD3.Text = dsConsulta.Tables(0).Rows(0)("TD3")
                    lblCie4.Text = dsConsulta.Tables(0).Rows(0)("Cie4")
                    lblDes4.Text = dsConsulta.Tables(0).Rows(0)("DesCie4")
                    lblLab4.Text = dsConsulta.Tables(0).Rows(0)("Lab4")
                    lblTD4.Text = dsConsulta.Tables(0).Rows(0)("TD4")
                    lblCie5.Text = dsConsulta.Tables(0).Rows(0)("Cie5")
                    lblDes5.Text = dsConsulta.Tables(0).Rows(0)("DesCie5")
                    lblLab5.Text = dsConsulta.Tables(0).Rows(0)("Lab5")
                    lblTD5.Text = dsConsulta.Tables(0).Rows(0)("TD5")
                    lblCie6.Text = dsConsulta.Tables(0).Rows(0)("Cie6")
                    lblDes6.Text = dsConsulta.Tables(0).Rows(0)("DesCie6")
                    lblLab6.Text = dsConsulta.Tables(0).Rows(0)("Lab6")
                    lblTD6.Text = dsConsulta.Tables(0).Rows(0)("TD6")
                End If
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmAlta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        btnCancelar_Click(sender, e)
        gbP.BringToFront()
        gbP.Left = 10
        gbP.Top = 70
        gbCIE.BringToFront()
        gbCIE.Left = 12
        gbCIE.Top = 50

        Me.Text = "ALTA - Dr(a) " & NomMedico

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

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        tbAlta.Enabled = False
        gbCIE.Visible = False
        gbP.Visible = False
        gbPaciente.Visible = False
        btnBuscarP.Enabled = False
        dtpFecha.Value = Date.Now
        Botones(True, False, False, True)
        LimpiarTab(tbAlta.TabPages(0))
        LimpiarTab(tbAlta.TabPages(1))
        Limpiar(Me)
        lvTabla.Items.Clear()
        ControlesAD(Me, False)
        Limpiar(Me)
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
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

        If MessageBox.Show("Esta seguro de Grabar Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objAlta.Grabar(CodigoIngreso, dtpFecha.Value.ToShortDateString, txtHora.Text, cboCondicion.Text, cboMedico.Text, cboTipoAlta.Text, cboDestino.Text, txtDesDestino.Text, txtCie1.Text, txtDes1.Text, txtLab1.Text, cboTD1.Text, txtCie2.Text, txtDes2.Text, txtLab2.Text, cboTD2.Text, txtCie3.Text, txtDes3.Text, txtLab3.Text, cboTD3.Text, txtCie4.Text, txtDes4.Text, txtLab4.Text, cboTD4.Text, txtCie5.Text, txtDes5.Text, txtLab5.Text, cboTD5.Text, txtCie6.Text, txtDes6.Text, txtLab6.Text, cboTD6.Text, cboMedico.SelectedValue)
            ppDialogo.ShowDialog()
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub txtCie1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub txtCie2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub txtCie3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub txtCie3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie3.TextAlignChanged

    End Sub

    Private Sub txtCie4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub txtCie4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie4.TextAlignChanged

    End Sub

    Private Sub txtCie5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub txtCie5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie5.TextAlignChanged

    End Sub

    Private Sub txtCie6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub txtCie6_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie6.TextAlignChanged

    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtHistoria.Select()
    End Sub

    Private Sub txtHora_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboCondicion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And IsNumeric(cboCondicion.SelectedValue) Then cboMedico.Select()
    End Sub

    Private Sub cboCondicion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboMedico_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTipoAlta.Select()
    End Sub



    Private Sub cboTipoAlta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And IsNumeric(cboTipoAlta.SelectedValue) Then cboDestino.Select()
    End Sub

    Private Sub cboTipoAlta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboDestino_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And IsNumeric(cboDestino.SelectedValue) Then
            If cboDestino.Text = "REFERENCIA" Or cboDestino.Text = "CONTRAREFERENCIA" Then txtDesDestino.Select() Else txtCie1.Select()
        End If
    End Sub

    Private Sub cboDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtDes1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes1.TextChanged
        If txtDes1.Text <> "" And txtDes1.Enabled Then txtFiltro.Text = txtDes1.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "1"
    End Sub

    Private Sub txtDes2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes2.TextChanged
        If txtDes2.Text <> "" And txtDes2.Enabled Then txtFiltro.Text = txtDes2.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "2"
    End Sub

    Private Sub txtDes3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes3.TextChanged, txtDes4.TextChanged
        If txtDes3.Text <> "" And txtDes3.Enabled Then txtFiltro.Text = txtDes3.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "3"
    End Sub

    Private Sub txtDes4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes5.TextChanged
        If txtDes4.Text <> "" And txtDes4.Enabled Then txtFiltro.Text = txtDes4.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "4"
    End Sub

    Private Sub txtDes5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes6.TextChanged
        If txtDes5.Text <> "" And txtDes5.Enabled Then txtFiltro.Text = txtDes5.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "5"
    End Sub

    Private Sub txtDes6_TextChanged(sender As System.Object, e As System.EventArgs)
        If txtDes6.Text <> "" And txtDes6.Enabled Then txtFiltro.Text = txtDes6.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select() : Filtro = "6"
    End Sub

    Private Sub txtLab1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD1.Select()
    End Sub

    Private Sub txtLab1_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtLab2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD2.Select()
    End Sub

    Private Sub txtLab2_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtLab3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD3.Select()
    End Sub

    Private Sub txtLab3_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtLab4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD4.Select()
    End Sub

    Private Sub txtLab4_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtLab5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD5.Select()
    End Sub

    Private Sub txtLab5_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtLab6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboTD6.Select()
    End Sub

    Private Sub txtLab6_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And cboTD1.Text <> "" Then txtCie2.Select()
    End Sub

    Private Sub cboTD1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie2.Text = "" Then btnGrabar.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD2.Text <> "" Then txtCie3.Select()
    End Sub

    Private Sub cboTD2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie3.Text = "" Then btnGrabar.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD3.Text <> "" Then txtCie4.Select()
    End Sub

    Private Sub cboTD3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD4_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie4.Text = "" Then btnGrabar.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD4.Text <> "" Then txtCie5.Select()
    End Sub

    Private Sub cboTD4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD5_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie5.Text = "" Then btnGrabar.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD5.Text <> "" Then txtCie6.Select()
    End Sub

    Private Sub cboTD5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboTD6_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter And txtCie6.Text = "" Then btnGrabar.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And cboTD6.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub cboTD6_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

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
            Next
            If lvCIE.Items.Count > 0 Then lvCIE.Select()
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

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

    Private Sub lvCIE_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCIE.SelectedIndexChanged

    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        tbAlta.Enabled = True
        dtpFecha.Value = Date.Now
        txtHora.Text = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboCondicion.Text = "VIVO"
        cboTipoAlta.Text = "ALTA MEDICA"
        cboDestino.Text = "CASA"
        btnBuscarP.Enabled = True
        dtpFecha.Select()
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub pdDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdDocumento.PrintPage
        Dim Aux As String
        Y = 20
        With e.Graphics
            .DrawString("HOSPITAL REGIONAL", Fuente10, Pincel, 50, Y)
            .DrawString("ESTADISTICA E INFORMATICA", Fuente10, Pincel, 580, Y)
            Y = Y + 15
            .DrawString("DOCENTE DE TRUJILLO" & StrDup(10, " "), Fuente10, Pincel, 40, Y)
            .DrawString(Date.Now.ToShortDateString & "|" & Date.Now.ToShortTimeString & "|" & UsuarioSistema, Fuente10, Pincel, 550, Y)
            Y = Y + 30
            .DrawString("CONSULTA DE EMERGENCIA " & "HC: " & txtHistoria.Text, Fuente24N, Pincel, 100, Y)

            Y = Y + 40
            .DrawString("Fecha y Hora Ingreso: ", Fuente10, Pincel, 40, Y)
            .DrawString(lblFecha.Text & " | " & lblHora.Text, Fuente12N, Pincel, 220, Y)
            Y = Y + 20
            .DrawString("Apellidos y Nombres: ", Fuente10, Pincel, 40, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblPaciente.Text & StrDup(40, "*"), 40), Fuente14N, Pincel, 220, Y)
            .DrawString("Sexo: ", Fuente10, Pincel, 720, Y)
            .DrawString(lblSexo.Text, Fuente12N, Pincel, 760, Y)
            Y = Y + 20
            .DrawString("Tipo Atención: ", Fuente10, Pincel, 40, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTipoAtencion.Text & StrDup(20, " "), 20), Fuente12N, Pincel, 220, Y)
            .DrawString("FNacimiento: ", Fuente10, Pincel, 440, Y)
            .DrawString(dtpFechaNcto.Value.ToShortDateString, Fuente12N, Pincel, 540, Y)
            .DrawString("Edad: ", Fuente10, Pincel, 660, Y)
            .DrawString(lblEdad.Text & lblTEdad.Text & "|" & lblEdadM.Text & "M|" & lblEdadD.Text & "D", Fuente12N, Pincel, 700, Y)

            Y = Y + 20
            .DrawString("Domicilio: ", Fuente10, Pincel, 40, Y)
            .DrawString(lblDomicilio.Text, Fuente12N, Pincel, 220, Y)
            Y = Y + 20
            .DrawString("Procedencia: ", Fuente10, Pincel, 40, Y)
            .DrawString(lblDpto.Text & " / " & lblProvincia.Text & " / " & lblDistrito.Text, Fuente12N, Pincel, 220, Y)
            Y = Y + 20
            .DrawString("Servicio: ", Fuente10, Pincel, 40, Y)
            .DrawString(lblServicio.Text, Fuente12N, Pincel, 220, Y)
            .DrawString("Médico: ", Fuente10, Pincel, 340, Y)
            .DrawString(cboMedico.Text, Fuente12N, Pincel, 410, Y)
            Y = Y + 20
            .DrawString("Ing. Estable.: ", Fuente10, Pincel, 40, Y)
            .DrawString(lblIngEsta.Text, Fuente12N, Pincel, 220, Y)
            .DrawString("Ing. Servicio: ", Fuente10, Pincel, 340, Y)
            .DrawString(lblIngSer.Text, Fuente12N, Pincel, 460, Y)
            Y = Y + 20
            .DrawLine(Pens.Black, 30, Y, 840, Y)
            Y = Y + 10
            .DrawString("ANAMNESIS", Fuente14N, Pincel, 40, Y)
            .DrawString("Talla:" & Talla & "cm.", Fuente10, Pincel, 180, Y)
            .DrawString("Peso:" & Peso & "Kg.", Fuente10, Pincel, 300, Y)
            .DrawString("Pulso:" & Pulso, Fuente10, Pincel, 420, Y)
            .DrawString("Presión:" & Presion, Fuente10, Pincel, 540, Y)
            .DrawString("Temp:" & Temp & "°C", Fuente10, Pincel, 680, Y)
            Y = Y + 20
            .DrawString("MOLESTIA PRINCIPAL: ", Fuente10N, Pincel, 50, Y)
            Y = Y + 15
            'Molestia Principal
            Aux = txtMolestia.Text
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
                Aux = ""
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            'Enfermedad Actual
            .DrawString("ENFERMEDAD ACTUAL: ", Fuente10N, Pincel, 50, Y)
            Y = Y + 15
            Aux = txtEnfermedadAct.Text
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
                Aux = ""
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            'Funciones Biologicas
            Y = Y + 30
            .DrawString("FUNCIONES BIOLOGICAS: ", Fuente10N, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("Apetito:" & Microsoft.VisualBasic.Left(FBApetito & StrDup(35, " "), 35), Fuente10, Pincel, 50, Y)
            .DrawString("Sed:         " & Microsoft.VisualBasic.Left(FBSed & StrDup(32, " "), 32), Fuente10, Pincel, 430, Y)
            Y = Y + 20
            .DrawString("Orina:  " & Microsoft.VisualBasic.Left(FBOrina & StrDup(35, " "), 35), Fuente10, Pincel, 50, Y)
            .DrawString("Deposiciones:" & Microsoft.VisualBasic.Left(FBDepo & StrDup(32, " "), 32), Fuente10, Pincel, 430, Y)
            Y = Y + 20
            .DrawString("Sueño:  " & Microsoft.VisualBasic.Left(FBSueño & StrDup(35, " "), 35), Fuente10, Pincel, 50, Y)
            .DrawString("Peso:        " & Microsoft.VisualBasic.Left(FBPeso & StrDup(32, " "), 32), Fuente10, Pincel, 430, Y)
            Y = Y + 15
            'Examen Fisico
            .DrawString("EXAMEN FISICO: ", Fuente10N, Pincel, 50, Y)
            Y = Y + 15
            Aux = txtExamenFisico.Text
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
                Aux = ""
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 15
            If Aux.Length <= 85 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(85, "-"), 85), Fuente10, Pincel, 50, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 85), Fuente10, Pincel, 50, Y)
                If Aux.Length > 85 Then Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 85)
            End If
            Y = Y + 20
            .DrawString("CIE10", Fuente10N, Pincel, 50, Y)
            .DrawString("Descripción", Fuente10N, Pincel, 200, Y)
            .DrawString("LAB", Fuente10N, Pincel, 640, Y)
            .DrawString("Tipo", Fuente10N, Pincel, 740, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie1.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes1.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab1.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD1.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie2.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes2.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab2.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD2.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie3.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes3.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab3.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD3.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie4.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes4.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab4.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD4.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie5.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes5.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab5.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD5.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie6.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes6.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab6.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD6.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 30
            .DrawLine(Pens.Black, 30, Y, 840, Y)
            Y = Y + 10
            .DrawString("ALTA DE PACIENTE", Fuente14N, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("Fecha: " & dtpFecha.Value.ToShortDateString & " Hora: " & txtHora.Text & "  Médico: " & cboMedico.Text, Fuente10, Pincel, 50, Y)
            Y = Y + 15
            .DrawString("Condición : " & cboCondicion.Text, Fuente10, Pincel, 50, Y)
            .DrawString("Tipo Alta : " & cboTipoAlta.Text, Fuente10, Pincel, 250, Y)
            .DrawString("Destino : " & cboDestino.Text, Fuente10, Pincel, 560, Y)
            Y = Y + 15
            .DrawString("Lugar Des : " & Microsoft.VisualBasic.Left(txtDesDestino.Text & StrDup(60, "-"), 60), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("DIAGNOSTICOS DE ALTA", Fuente14N, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("CIE10", Fuente10N, Pincel, 50, Y)
            .DrawString("Descripción", Fuente10N, Pincel, 200, Y)
            .DrawString("LAB", Fuente10N, Pincel, 640, Y)
            .DrawString("Tipo", Fuente10N, Pincel, 740, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(txtCie1.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtDes1.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtLab1.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboTD1.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(txtCie2.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtDes2.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtLab2.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboTD2.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(txtCie3.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtDes3.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtLab3.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboTD3.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(txtCie4.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtDes4.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtLab4.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboTD4.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(txtCie5.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtDes5.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtLab5.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboTD5.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(txtCie6.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtDes6.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(txtLab6.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboTD6.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 40
            .DrawString(StrDup(30, "-"), Fuente10, Pincel, 290, Y)
            Y = Y + 10
            .DrawString("FIRMA Y SELLO DE MEDICO", Fuente10, Pincel, 320, Y)
            e.HasMorePages = False
        End With
    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        gbPaciente.Left = 15
        gbPaciente.Top = 60
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


End Class