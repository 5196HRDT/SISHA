Public Class frmCita
    Dim objCupo As New clsCupoEspirometria
    Dim objConsulta As New clsConsulta
    Dim objHistoria As New clsHistoria
    Dim objMedico As New clsMedico
    Dim objSis As New clsSIS

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmInforme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
        btnCancelar_Click(sender, e)
        cboTCita.Text = "MAÑANA"
        dtpFCita.Value = Date.Now

        'Medico Tratante
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"
    End Sub

    Private Function Verificar(ByVal Procedimiento As String) As Boolean
        Verificar = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(4).Text = Procedimiento Then Verificar = True : Exit For
        Next
    End Function

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        lvTabla.Items.Clear()
        If e.KeyCode = Keys.Enter And txtPaciente.Text <> "" Then
            Dim dsVer As New DataSet

            'Buscar Consulta Externa
            dsVer = objConsulta.BuscarEspirometrias(txtPaciente.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim Solicitante As String = ""

            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Indicacion"))
                If dsVer.Tables(0).Rows(I)("UsuarioRegistro").ToString.Length > 5 Then Solicitante = dsVer.Tables(0).Rows(I)("UsuarioRegistro") Else Solicitante = dsVer.Tables(0).Rows(I)("Solicitante")
                Fila.SubItems.Add(Solicitante)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
                Fila.SubItems.Add("CONSULTA EXTERNA")
            Next

            'Buscar SIS
            dsVer = objSis.BuscarEspirometria(txtPaciente.Text)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                If Not Verificar(dsVer.Tables(0).Rows(I)("Descripcion")) Then
                    Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("Id"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                    Fila.SubItems.Add("SIS")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(UsuarioSistema)
                    Fila.SubItems.Add("SIS")
                    Fila.SubItems.Add("SIS")
                End If
            Next
        End If
    End Sub

    Private Sub BuscarHistoria(ByVal Historia As String)
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(Historia)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblHistoria.Text = Historia
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")
            lblSexo.Text = dsHistorias.Tables(0).Rows(0)("Sexo")
            If dsHistorias.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                Dim EdadA, EdadM, EdadD As String
                dfin = Date.Now.ToShortDateString
                dinicio = dsHistorias.Tables(0).Rows(0)("FNACIMIENTO")
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

                    EdadD = Microsoft.VisualBasic.Day(dinicio)
                    If Val(EdadD) > Date.Now.Day Then
                        EdadD = Val(EdadD) - Date.Now.Day
                    ElseIf Val(EdadD) < Date.Now.Day Then
                        If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                        EdadD = Date.Now.Day - EdadD
                        EdadD = DameDiasMes(Date.Now.Month) - EdadD
                    Else
                        EdadD = 0
                    End If
                End If
                lblEdad.Text = EdadA & " A " & EdadM & " M " & EdadD & " D "
            Else
                lblEdad.Text = ""
            End If
        Else
            MessageBox.Show("Paciente no se encuentra registrado en el Sistema", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Enter And lvTabla.SelectedItems.Count > 0 Then dtpFecha.Select()
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        If lvTabla.SelectedItems.Count > 0 Then
            lblHistoria.Tag = lvTabla.SelectedItems(0).SubItems(0).Text
            BuscarHistoria(lvTabla.SelectedItems(0).SubItems(1).Text)
            lblExamen.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            txtIndicacion.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            cboMedico.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            lblTipoPaciente.Text = lvTabla.SelectedItems(0).SubItems(7).Text
        End If
    End Sub



    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        lvTabla.Items.Clear()
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        lblEdad.Text = ""
        lblSexo.Text = ""
        txtPaciente.Text = ""
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If lblHistoria.Text = "" Then MessageBox.Show("Debe Seleccionar un Paciente para asignarle una cita", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtPaciente.Select() : Exit Sub
        If cboTurno.Text = "" Then MessageBox.Show("Debe ingresar un Turno de Cita", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTurno.Select() : Exit Sub
        If Not IsNumeric(cboMedico.SelectedValue) Then MessageBox.Show("Debe Indicar el Medico Solicitante", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboMedico.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar Informe?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objCupo.Grabar(Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name, dtpFecha.Value.ToShortDateString, cboTurno.Text, lblHistoria.Tag, lblExamen.Text, lblHistoria.Text, lblPaciente.Text, lblEdad.Text, lblSexo.Text, cboMedico.Text, lblTipoPaciente.Text, txtIndicacion.Text)
            If lvTabla.SelectedItems(0).SubItems(8).Text = "SIS" Then
                objSis.AtencionProcedimientoSis(lvTabla.SelectedItems(0).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema)
            Else
                objConsulta.MuestraTomada(lblHistoria.Tag, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name)
            End If
            btnCancelar_Click(sender, e)
            btnMostrar_Click(sender, e)
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        cboTurno.Text = "MAÑANA"
        txtPaciente.Select()
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub cboMedico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboMedico.SelectedValue) Then dtpFecha.Select()
    End Sub

    Private Sub cboMedico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMedico.SelectedIndexChanged

    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboTurno.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub cboTurno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTurno.KeyDown
        If cboTurno.Text <> "" And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub cboTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTurno.SelectedIndexChanged

    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If cboTCita.Text = "" Then MessageBox.Show("Debe asignar un Turno", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTCita.Select() : Exit Sub
        lvCita.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objCupo.Buscar(dtpFCita.Value.ToShortDateString, cboTCita.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvCita.Items.Add(dsVer.Tables(0).Rows(I)("IdCita"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
        Next
    End Sub

    Private Sub lvCita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCita.KeyDown
        If lvCita.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de Eliminar Cita de Paciente?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objCupo.Eliminar(lvCita.SelectedItems(0).SubItems(0).Text)

                objConsulta.AnularMuestraTomada(lvCita.SelectedItems(0).SubItems(4).Text)
                lvCita.Items.RemoveAt(lvCita.SelectedItems(0).Index)
            End If
        End If
    End Sub

    Private Sub lvCita_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCita.SelectedIndexChanged

    End Sub
End Class