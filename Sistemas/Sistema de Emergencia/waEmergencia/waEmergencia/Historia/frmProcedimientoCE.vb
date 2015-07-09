Public Class frmProcedimientoCE
    Dim objPaciente As New clsHistoria
    Dim objExamen As New clsServicioItem
    Dim objConsulta As New clsConsulta
    Dim objEspecialidad As New Especialidad
    Dim objSubEspecialidad As New SubEspecialidad
    Dim objUsuario As New clsUsuario

    Dim Filtro As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            lvTabla.Items.Clear()
            lblPaciente.Text = ""
            Dim dsPac As New Data.DataSet
            btnGrabar.Enabled = False
            dsPac = objPaciente.Buscar(txtHistoria.Text)
            If dsPac.Tables(0).Rows.Count > 0 Then
                lblPaciente.Text = dsPac.Tables(0).Rows(0)("Apaterno") & " " & dsPac.Tables(0).Rows(0)("AMaterno") & " " & dsPac.Tables(0).Rows(0)("Nombres")
                btnGrabar.Enabled = True
                cboServicio.Select()

                'Buscar Historial sin Cancelar
                Dim dsVer As New DataSet
                dsVer = objConsulta.BuscarExaSinAtencionComun(txtHistoria.Text)
                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegistro"))
                Next
            Else
                MessageBox.Show("Paciente no esta registrado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        gbFiltro.Visible = False
        gbValidar.Visible = False
        dgExamenes.Items.Clear()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmProcedimientoCE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        gbFiltro.Visible = False
        gbValidar.Visible = False

        'Llenar Especialidad
        Dim dsEspecialidad As New DataSet
        dsEspecialidad = objEspecialidad.Combo("%")
        cboServicio.DataSource = dsEspecialidad.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdDpto"
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, False, True, False)
        dtpFecha.Value = Date.Now
        txtHistoria.Select()
    End Sub

    Private Sub txtExamenes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExamenes.TextChanged
        If txtExamenes.Text <> "" And txtExamenes.Enabled Then
            Filtro = "EXAMENES" : gbFiltro.Visible = True : txtFiltro.Text = txtExamenes.Text : txtFiltro.SelectionStart = Len(txtFiltro.Text) : txtFiltro.Select()
        End If
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter And lvFiltro.Items.Count > 0 Then lvFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text.Length <= 1 Then Exit Sub
        Select Case Filtro
            Case "EXAMENES"
                Dim Fila As ListViewItem
                Dim I As Integer
                Dim dsExa As New Data.DataSet

                dsExa = objExamen.BuscarServicioCE(txtFiltro.Text & "%", 1, "D")

                dgFiltro.DataSource = dsExa.Tables(0)
                

                lvFiltro.Clear()
                lvFiltro.Columns.Add("Id", 0)
                lvFiltro.Columns.Add("Descripcion", 400)
                lvFiltro.Columns.Add("Precio", 100, HorizontalAlignment.Right)
                lvFiltro.Columns.Add("IdTipoTarifa", 0)
                lvFiltro.Columns.Add("IdItem", 0)
                lvFiltro.Columns.Add("Tipo", 0)
                lvFiltro.Columns.Add("Clase", 0)
                For I = 0 To dsExa.Tables(0).Rows.Count - 1
                    Fila = lvFiltro.Items.Add(dsExa.Tables(0).Rows(I)("IdServicioItem"))
                    Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsExa.Tables(0).Rows(I)("Precio")), "#,##0.00"))
                    Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("IdTipoTarifa"))
                    Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("IdItem"))
                    Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Tipo"))
                    Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("ClasLaboratorio"))
                Next
        End Select
    End Sub

    Private Function VerExa() As Boolean
        VerExa = False
        Dim I As Integer
        For I = 0 To dgExamenes.Items.Count - 1
            If dgExamenes.Items(I).SubItems(0).Text = lvFiltro.SelectedItems(0).SubItems(0).Text Then VerExa = True : Exit For
        Next
    End Function

    Private Sub lvFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvFiltro.KeyDown
        If lvFiltro.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            Select Case Filtro
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

    Private Sub txtCantidadE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidadE.KeyDown
        If e.KeyCode = Keys.Enter Then txtIndicacion.Select()
    End Sub

    Private Sub txtCantidadE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadE.TextChanged

    End Sub

    Private Sub txtIndicacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIndicacion.KeyDown
        If txtCantidadE.Text.Length > 0 And txtExamenes.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            If txtIndicacion.Text = "" And lblTipoP.Text = "RAYOS" Then MessageBox.Show("Para este tipo de exámen, debe ingresar una indicación que oriente al especialista.", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtIndicacion.Select() : Exit Sub
            If txtIndicacion.Text = "" And lblSTP.Text = "ECOGRAFIA" Then MessageBox.Show("Para este tipo de exámen, debe ingresar una indicación que oriente al especialista.", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtIndicacion.Select() : Exit Sub

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

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If lblPaciente.Text = "" Then MessageBox.Show("Debe Asignar un Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtHistoria.Select() : Exit Sub
        If Not IsNumeric(cboSubServicio.SelectedValue) Then MessageBox.Show("Debe seleccionar un Sub Servicio de Atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboSubServicio.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar Informacion de Procedimientos del Paciente?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            txtUsuario.Text = ""
            txtClave.Text = ""
            gbValidar.Visible = True
            txtUsuario.Select()
        Else
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboServicio.SelectedValue) Then cboSubServicio.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSubServicio As New DataSet
            dsSubServicio = objSubEspecialidad.Combo(cboServicio.SelectedValue)
            cboSubServicio.DataSource = dsSubServicio.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub cboSubServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboSubServicio.SelectedValue) Then txtExamenes.Select()
    End Sub

    Private Sub cboSubServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubServicio.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbValidar.Visible = False
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dsUsuario As New DataSet
        dsUsuario = objUsuario.VerificarUsuario(txtUsuario.Text, txtClave.Text)
        If dsUsuario.Tables(0).Rows.Count > 0 Then
            If Not dsUsuario.Tables(0).Rows(0)("Nivel") = "SERVICIOSCE" Then
                MessageBox.Show("Usuario no tiene el nivel requerido, verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
                Exit Sub
            End If
        Else
            MessageBox.Show("Usuario no existe, verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnCancelar_Click(sender, e)
            Exit Sub
        End If

        Dim I As Integer
        For I = 0 To dgExamenes.Items.Count - 1
            'Grabar Procedimeintos pacientes pago directo

            If Val(dgExamenes.Items(I).SubItems(2).Text) <> 0 Then
                objConsulta.Consulta_GrabarExamenesInd(0, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), txtUsuario.Text, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, "COMUN", 0, "", 0, txtHistoria.Text, lblPaciente.Text, cboSubServicio.Text, dgExamenes.Items(I).SubItems(7).Text)
            Else
                objConsulta.GrabarExamenesCanInd(0, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), txtUsuario.Text, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, "COMUN", 0, "", 0, txtHistoria.Text, lblPaciente.Text, cboSubServicio.Text, dgExamenes.Items(I).SubItems(7).Text)
            End If
        Next
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If txtUsuario.Text <> "" And e.KeyCode = Keys.Enter Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And txtClave.Text <> "" Then btnAceptar.Select()
    End Sub

    Private Sub txtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de Eliminar Permanentemente el Examen Solicitado?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objConsulta.EliminarExamen(lvTabla.SelectedItems(0).SubItems(0).Text)
                lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
            End If
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub
End Class