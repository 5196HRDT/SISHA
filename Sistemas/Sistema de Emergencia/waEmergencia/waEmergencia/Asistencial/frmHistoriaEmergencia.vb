Public Class frmHistoriaEmergencia
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

    Dim Filtro As String
    Dim OperConsulta As Boolean
    Dim OperAlta As Boolean

    Dim CodigoIngreso As String

    Private Sub Botones(Nuevo As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
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
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
        End If
    End Sub

    Private Sub frmHistoriaEmergencia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        Me.Text = "HISTORIA CLINICA DE EMERGENCIA - Dr(a) " & NomMedico

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

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        lvLista.Items.Clear()
        lvLista.Enabled = False
        dtpFecha.Value = Date.Now
        Botones(True, False, True)
        btnBuscarP.Enabled = False
        ControlesAD(Me, False)
        gbPaciente.Visible = False
        Limpiar(Me)
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
                dtpFecha.Value = dsVer.Tables(0).Rows(0)("FechaIngreso")
                txtHora.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblFechaAdmision.Text = dsVer.Tables(0).Rows(0)("FechaIngreso")
                lblHoraAdmision.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblTipoAtencion.Text = dsVer.Tables(0).Rows(0)("TipoAtencion").ToString

                Dim dsConsulta As New DataSet
                dsConsulta = objConsulta.ConsultaBuscar(CodigoIngreso)
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    OperConsulta = True
                    dtpFecha.Value = dsConsulta.Tables(0).Rows(0)("Fecha")
                    txtHora.Text = dsConsulta.Tables(0).Rows(0)("Hora")
                    txtEnfermedadAct.Text = dsConsulta.Tables(0).Rows(0)("EnfermedadActual")
                    txtMolestia.Text = dsConsulta.Tables(0).Rows(0)("MolestiaPrincipal")
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
                End If
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
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

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtFHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            gbPaciente.Visible = False
            txtFHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub
End Class