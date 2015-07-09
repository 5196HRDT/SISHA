Public Class frmProcedimientos
    Dim objProcedimiento As New Procedimiento
    Dim objHospitalizacion As New Hospitalizacion
    Dim objServicio As New Servicio
    Dim objSubServicio As New SubServicio
    Dim objEspecialidad As New Especialidad
    Dim objMedico As New Medico
    Dim objIngreso As New Ingreso
    Dim objCPT As New CPT

    Dim IdHospitalizacion As String
    Dim IdIngreso As String
    Dim Oper As String
    Dim CodLocal As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsHist As New Data.DataSet
        dsHist = objProcedimiento.Buscar(IdIngreso)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsHist.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(IdIngreso)
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("SubServicio"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Responsable"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Codigo"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("IdEspecialidad"))
            Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("IdResponsable"))
        Next
    End Sub

    Private Sub txtCIE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE.Text = "" Then txtDes.Select()
        If e.KeyCode = Keys.Enter And txtCIE.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            lvDet.Items.Clear()
            dsCIE = objCPT.BuscarCodigo(txtCIE.Text)
            If dsCIE.Tables(0).Rows.Count > 0 Then
                txtDes.Enabled = False
                txtDes.Text = dsCIE.Tables(0).Rows(I)("Descripcion")
                txtDes.Enabled = True
                txtDes.Select()
            Else
                txtDes.Text = ""
                txtCIE.Select()
                MessageBox.Show("Codigo de CPT no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If txtCIE.Text <> "" And txtDes.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(IdIngreso)
            Fila.SubItems.Add(cboServicio.Text)
            Fila.SubItems.Add(cboSubServicio.Text)
            Fila.SubItems.Add(cboEspecialidad.Text)
            Fila.SubItems.Add(cboResponsable.Text)
            Fila.SubItems.Add(txtCIE.Text)
            Fila.SubItems.Add(txtDes.Text)
            Fila.SubItems.Add(cboEspecialidad.SelectedValue)
            Fila.SubItems.Add(cboResponsable.SelectedValue)
            txtCIE.Text = ""
            txtDes.Text = ""
            txtCIE.Select()
        End If
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And txtDes.Enabled Then txtFiltro.Text = txtDes.Text : txtFiltro.SelectionStart = txtFiltro.TextLength : gbConsulta.Visible = True : txtFiltro.Select()
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvDet.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvDet.Items.Clear()
            dsCIE = objCPT.BuscarDes(txtFiltro.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsCIE.Tables(0).Rows(I)("Codigo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Descripcion"))
            Next
        End If
    End Sub

    Private Sub frmProcedimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Servicio
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Combo("%")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdPiso"

        'Responsable
        Dim dsResponsable As New Data.DataSet
        dsResponsable = objMedico.Combo("")
        cboResponsable.DataSource = dsResponsable.Tables(0)
        cboResponsable.DisplayMember = "NMedico"
        cboResponsable.ValueMember = "IdMedico"
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        txtFiltro.Text = ""
        gbConsulta.Visible = False
        lvDet.Items.Clear()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblPaciente.Text = ""
        lblFecha.Text = ""
        cboServicio.Text = ""
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        cboResponsable.Text = ""
        lvTabla.Items.Clear()
        Botones(True, False, False, True)
        Limpiar(Me)
        Activar(Me, False)
        gbConsulta.Visible = False
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        txtHistoria.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            objProcedimiento.Mantenimiento(IdIngreso, lvTabla.Items(I).SubItems(7).Text, lvTabla.Items(I).SubItems(8).Text, lvTabla.Items(I).SubItems(5).Text, lvTabla.Items(I).SubItems(6).Text, 3)
            For I = 0 To lvTabla.Items.Count - 1
                objProcedimiento.Mantenimiento(IdIngreso, lvTabla.Items(I).SubItems(7).Text, lvTabla.Items(I).SubItems(8).Text, lvTabla.Items(I).SubItems(5).Text, lvTabla.Items(I).SubItems(6).Text, Oper)
            Next
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dsHospitalizacion As New Data.DataSet
            IdHospitalizacion = ""
            dsHospitalizacion = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
            If dsHospitalizacion.Tables(0).Rows.Count > 0 Then
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")
                'Verificar Ingreso Hospitalizacion
                Dim dsIngreso As New Data.DataSet
                dsIngreso = objIngreso.Buscar(IdHospitalizacion)
                If dsIngreso.Tables(0).Rows.Count > 0 Then
                    idingreso = dsIngreso.Tables(0).Rows(0)("IdIngreso")
                Else
                    MessageBox.Show("Debe registrar ingreso de paciente ha hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsHospitalizacion.Tables(0).Rows(0)("FecIngreso")
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")

                Buscar()
                cboServicio.Select()
            Else
                MessageBox.Show("Paciente No Esta Registrado En Hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblFecha.Text = ""
                lblPaciente.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    txtCIE.Text = ""
                    txtDes.Text = ""
                    Dim Fila As ListViewItem
                    Fila = lvTabla.Items.Add(IdIngreso)
                    Fila.SubItems.Add(cboServicio.Text)
                    Fila.SubItems.Add(cboSubServicio.Text)
                    Fila.SubItems.Add(cboEspecialidad.Text)
                    Fila.SubItems.Add(cboResponsable.Text)
                    Fila.SubItems.Add(lvDet.Items(I).SubItems(0).Text)
                    Fila.SubItems.Add(lvDet.Items(I).SubItems(1).Text)
                    Fila.SubItems.Add(cboEspecialidad.SelectedValue)
                    Fila.SubItems.Add(cboResponsable.SelectedValue)
                End If
            Next
            btnRetornar_Click(sender, e)
            txtDes.Select()
        End If
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.Items.Count > 0 Then
            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                If lvTabla.Items(I).Selected Then
                    lvTabla.Items.RemoveAt(I)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cboServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboServicio.SelectedValue) Then cboSubServicio.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSubServicio As New Data.DataSet
            dsSubServicio = objSubServicio.Combo(cboServicio.SelectedValue.ToString)
            cboSubServicio.DataSource = dsSubServicio.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdSerHos"
        End If
    End Sub

    Private Sub cboSubServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSubServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboSubServicio.SelectedValue) Then cboEspecialidad.Select()
    End Sub

    Private Sub cboSubServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSubServicio.SelectedIndexChanged
        cboEspecialidad.Text = ""
        If IsNumeric(cboSubServicio.SelectedValue) Then
            Dim dsEspecialidad As New Data.DataSet
            dsEspecialidad = objEspecialidad.Buscar(cboSubServicio.SelectedValue)
            cboEspecialidad.DataSource = dsEspecialidad.Tables(0)
            cboEspecialidad.DisplayMember = "Descripcion"
            cboEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub cboEspecialidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If IsNumeric(cboEspecialidad.SelectedValue) And e.KeyCode = Keys.Enter Then cboResponsable.Select()
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged

    End Sub

    Private Sub cboResponsable_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboResponsable.KeyDown
        If IsNumeric(cboResponsable.SelectedValue) And e.KeyCode = Keys.Enter Then txtCIE.Select()
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged

    End Sub

    Private Sub txtCIE_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCIE.TextChanged

    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub lvDet_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub
End Class