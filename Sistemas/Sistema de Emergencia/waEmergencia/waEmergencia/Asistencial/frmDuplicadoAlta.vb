Public Class frmDuplicadoAlta
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

    Dim Talla As String
    Dim Peso As String
    Dim Pulso As String
    Dim Presion As String
    Dim Temp As String
    Dim Molestias As String
    Dim EnfermedadAct As String
    Dim ExamenFisico As String

    Dim FBApetito As String
    Dim FBSed As String
    Dim FBOrina As String
    Dim FBDepo As String
    Dim FBSueño As String
    Dim FBPeso As String

    Dim CodigoIngreso As String

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

    Private Sub Botones(Nuevo As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        lvLista.Items.Clear()
        lvLista.Enabled = False
        dtpFecha.Value = Date.Now
        Botones(True, False, True)
        btnBuscarP.Enabled = False
        ControlesAD(Me, False)
        cboSala.Text = "NO"
        gbPaciente.Visible = False
        Limpiar(Me)
        btnImprimir.Enabled = False
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        dtpFecha.Value = Date.Now
        txtHora.Text = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Botones(False, True, False)
        ControlesAD(Me, True)
        btnBuscarP.Enabled = True
        lvLista.Enabled = False
        txtFHistoria.Select()
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
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
        End If
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

    Private Sub txtFHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFHistoria.TextChanged

    End Sub

    Private Sub lvLista_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvLista.KeyDown
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
                lblServicio.Text = dsVer.Tables(0).Rows(0)("Especialidad")
                lblMedicoIng.Text = dsVer.Tables(0).Rows(0)("Medico")
                lblIngEsta.Text = dsVer.Tables(0).Rows(0)("IngEstablecimiento").ToString
                lblIngSer.Text = dsVer.Tables(0).Rows(0)("IngServicio").ToString
                dtpFecha.Value = dsVer.Tables(0).Rows(0)("FechaIngreso")
                txtHora.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblFechaAdmision.Text = dsVer.Tables(0).Rows(0)("FechaIngreso")
                lblHoraAdmision.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblInformante.Text = dsVer.Tables(0).Rows(0)("Conyuge")
                lblTipoAtencion.Text = dsVer.Tables(0).Rows(0)("TipoAtencion").ToString
                cboSala.Text = dsVer.Tables(0).Rows(0)("SalaObservacion").ToString

                Dim dsConsulta As New DataSet
                dsConsulta = objConsulta.ConsultaBuscar(CodigoIngreso)
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    OperConsulta = True
                    dtpFecha.Value = dsConsulta.Tables(0).Rows(0)("Fecha")
                    txtHora.Text = dsConsulta.Tables(0).Rows(0)("Hora")

                    Molestias = dsConsulta.Tables(0).Rows(0)("MolestiaPrincipal")
                    EnfermedadAct = dsConsulta.Tables(0).Rows(0)("EnfermedadActual")
                    ExamenFisico = dsConsulta.Tables(0).Rows(0)("ExamenFisico")
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
                    lblDes1.Enabled = False
                    lblDes1.Text = dsConsulta.Tables(0).Rows(0)("DesCie1")
                    lblDes1.Enabled = True
                    lblLab1.Text = dsConsulta.Tables(0).Rows(0)("Lab1")
                    lblTD1.Text = dsConsulta.Tables(0).Rows(0)("TD1")
                    lblCie2.Text = dsConsulta.Tables(0).Rows(0)("Cie2")
                    lblDes2.Enabled = False
                    lblDes2.Text = dsConsulta.Tables(0).Rows(0)("DesCie2")
                    lblDes2.Enabled = True
                    lblLab2.Text = dsConsulta.Tables(0).Rows(0)("Lab2")
                    lblTD2.Text = dsConsulta.Tables(0).Rows(0)("TD2")
                    lblCie3.Text = dsConsulta.Tables(0).Rows(0)("Cie3")
                    lblDes3.Enabled = False
                    lblDes3.Text = dsConsulta.Tables(0).Rows(0)("DesCie3")
                    lblDes3.Enabled = True
                    lblLab3.Text = dsConsulta.Tables(0).Rows(0)("Lab3")
                    lblTD3.Text = dsConsulta.Tables(0).Rows(0)("TD3")
                    lblCie4.Text = dsConsulta.Tables(0).Rows(0)("Cie4")
                    lblDes4.Enabled = False
                    lblDes4.Text = dsConsulta.Tables(0).Rows(0)("DesCie4")
                    lblDes4.Enabled = True
                    lblLab4.Text = dsConsulta.Tables(0).Rows(0)("Lab4")
                    lblTD4.Text = dsConsulta.Tables(0).Rows(0)("TD4")
                    lblCie5.Text = dsConsulta.Tables(0).Rows(0)("Cie5")
                    lblDes5.Enabled = False
                    lblDes5.Text = dsConsulta.Tables(0).Rows(0)("DesCie5")
                    lblDes5.Enabled = True
                    lblLab5.Text = dsConsulta.Tables(0).Rows(0)("Lab5")
                    lblTD5.Text = dsConsulta.Tables(0).Rows(0)("TD5")
                    lblCie6.Text = dsConsulta.Tables(0).Rows(0)("Cie6")
                    lblDes6.Enabled = False
                    lblDes6.Text = dsConsulta.Tables(0).Rows(0)("DesCie6")
                    lblDes6.Enabled = True
                    lblLab6.Text = dsConsulta.Tables(0).Rows(0)("Lab6")
                    lblTD6.Text = dsConsulta.Tables(0).Rows(0)("TD6")
                Else
                    OperConsulta = False
                End If

                'Alta de Paciente
                Dim dsAlta As New DataSet
                dsAlta = objAlta.BuscarAlta(CodigoIngreso)
                If dsAlta.Tables(0).Rows.Count > 0 Then
                    OperAlta = True

                    lblFechaAlta.Text = dsAlta.Tables(0).Rows(0)("Fecha")
                    lblHoraAlta.Text = dsAlta.Tables(0).Rows(0)("Hora")
                    lblCondicion.Text = dsAlta.Tables(0).Rows(0)("CondicionAlta")
                    lblMedico.Text = dsAlta.Tables(0).Rows(0)("Medico")
                    lblTipoAlta.Text = dsAlta.Tables(0).Rows(0)("TipoAlta")
                    lblDestino.Text = dsAlta.Tables(0).Rows(0)("Destino")
                    lblDesDestino.Text = dsAlta.Tables(0).Rows(0)("DesDestino")

                    lblCie1A.Text = dsAlta.Tables(0).Rows(0)("Cie1")
                    lblDes1A.Enabled = False
                    lblDes1A.Text = dsAlta.Tables(0).Rows(0)("DesCie1")
                    lblDes1A.Enabled = True
                    lblLab1A.Text = dsAlta.Tables(0).Rows(0)("Lab1")
                    lblTD1A.Text = dsAlta.Tables(0).Rows(0)("TD1")
                    lblCie2A.Text = dsAlta.Tables(0).Rows(0)("Cie2")
                    lblDes2A.Enabled = False
                    lblDes2A.Text = dsAlta.Tables(0).Rows(0)("DesCie2")
                    lblDes2A.Enabled = True
                    lblLab2A.Text = dsAlta.Tables(0).Rows(0)("Lab2")
                    lblTD2A.Text = dsAlta.Tables(0).Rows(0)("TD2")
                    lblCie3A.Text = dsAlta.Tables(0).Rows(0)("Cie3")
                    lblDes3A.Enabled = False
                    lblDes3A.Text = dsAlta.Tables(0).Rows(0)("DesCie3")
                    lblDes3A.Enabled = True
                    lblLab3A.Text = dsAlta.Tables(0).Rows(0)("Lab3")
                    lblTD3A.Text = dsAlta.Tables(0).Rows(0)("TD3")
                    lblCie4A.Text = dsAlta.Tables(0).Rows(0)("Cie4")
                    lblDes4A.Enabled = False
                    lblDes4A.Text = dsAlta.Tables(0).Rows(0)("DesCie4")
                    lblDes4A.Enabled = True
                    lblLab4A.Text = dsAlta.Tables(0).Rows(0)("Lab4")
                    lblTD4A.Text = dsAlta.Tables(0).Rows(0)("TD4")
                    lblCie5A.Text = dsAlta.Tables(0).Rows(0)("Cie5")
                    lblDes5A.Enabled = False
                    lblDes5A.Text = dsAlta.Tables(0).Rows(0)("DesCie5")
                    lblDes5A.Enabled = True
                    lblLab5A.Text = dsAlta.Tables(0).Rows(0)("Lab5")
                    lblTD5A.Text = dsAlta.Tables(0).Rows(0)("TD5")
                    lblCie6A.Text = dsAlta.Tables(0).Rows(0)("Cie6")
                    lblDes6A.Enabled = False
                    lblDes6A.Text = dsAlta.Tables(0).Rows(0)("DesCie6")
                    lblDes6A.Enabled = True
                    lblLab6A.Text = dsAlta.Tables(0).Rows(0)("Lab6")
                    lblTD6A.Text = dsAlta.Tables(0).Rows(0)("TD6")
                Else
                    OperAlta = False
                    lblMedico.Text = lblMedicoIng.Text
                    lblCondicion.Text = "VIVO"
                    lblTipoAlta.Text = "ALTA MEDICA"
                    lblDestino.Text = "CASA"
                    lblFechaAlta.Text = dtpFecha.Value
                    lblHoraAlta.Text = txtHora.Text
                End If
                btnImprimir.Enabled = True
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmDuplicadoAlta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        Me.Text = "DUPLICADO DE ALTA - Dr(a) " & NomMedico
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
            .DrawString(lblFechaAdmision.Text & " | " & lblHoraAdmision.Text, Fuente12N, Pincel, 220, Y)
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
            .DrawString(lblMedicoIng.Text, Fuente12N, Pincel, 410, Y)
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
            Aux = Molestias
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
            Aux = EnfermedadAct
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
            Aux = ExamenFisico
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
            .DrawString("Fecha: " & lblFechaAlta.Text & " Hora: " & lblHoraAlta.Text & "  Médico: " & lblMedico.Text, Fuente10, Pincel, 50, Y)
            Y = Y + 15
            .DrawString("Condición : " & lblCondicion.Text, Fuente10, Pincel, 50, Y)
            .DrawString("Tipo Alta : " & lblTipoAlta.Text, Fuente10, Pincel, 250, Y)
            .DrawString("Destino : " & lblDestino.Text, Fuente10, Pincel, 560, Y)
            Y = Y + 15
            .DrawString("Lugar Des : " & Microsoft.VisualBasic.Left(lblDesDestino.Text & StrDup(60, "-"), 60), Fuente10, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("DIAGNOSTICOS DE ALTA", Fuente14N, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("CIE10", Fuente10N, Pincel, 50, Y)
            .DrawString("Descripción", Fuente10N, Pincel, 200, Y)
            .DrawString("LAB", Fuente10N, Pincel, 640, Y)
            .DrawString("Tipo", Fuente10N, Pincel, 740, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie1A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes1A.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab1A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD1A.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie2A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes2A.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab2A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD2A.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie3A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes3A.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab3A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD3A.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie4A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes4A.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab4A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD4A.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie5A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes5A.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab5A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD5A.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 15
            .DrawString(Microsoft.VisualBasic.Left(lblCie6A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 50, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblDes6A.Text & StrDup(58, "-"), 58), Fuente10, Pincel, 120, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblLab6A.Text & StrDup(6, "-"), 6), Fuente10, Pincel, 630, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblTD6A.Text & StrDup(10, "-"), 10), Fuente10, Pincel, 710, Y)
            Y = Y + 40
            .DrawString(StrDup(30, "-"), Fuente10, Pincel, 290, Y)
            Y = Y + 10
            .DrawString("FIRMA Y SELLO DE MEDICO", Fuente10, Pincel, 320, Y)
            e.HasMorePages = False
        End With
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        ppDialogo.ShowDialog()
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

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub
End Class