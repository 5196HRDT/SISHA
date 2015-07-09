Public Class frmMortalidad
    Dim objMortalidad As New Mortalidad
    Dim objHospitalizacion As New Hospitalizacion
    Dim objMedico As New Medico
    Dim objServicio As New Servicio
    Dim objSubServicio As New SubServicio
    Dim objEspecialidad As New Especialidad
    Dim objIngreso As New Ingreso
    Dim objCIE As New CIE10

    Dim Filtro As String
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
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim dsHist As New Data.DataSet
        lvTabla.Items.Clear()
        dsHist = objMortalidad.Buscar(IdIngreso)
        If dsHist.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("Datos Mortalidad ya fueron registrados", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            For I = 0 To dsHist.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(IdIngreso)
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Servicio"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("SubServicio"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Especialidad"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Responsable"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Fecha"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Causa"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("CIE"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("IdEspecialidad"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("IdResponsable"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Necropsia"))
            Next
            Oper = 2
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblPaciente.Text = ""
        lblFecha.Text = ""
        Botones(True, False, False, True)
        Limpiar(Me)
        Activar(Me, False)
        gbConsulta.Visible = False
        lvDet.Items.Clear()
        lvTabla.Items.Clear()
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter Then
            lvTabla.Items.Clear()
            Dim dsHospitalizacion As New Data.DataSet
            IdIngreso = ""
            dsHospitalizacion = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
            If dsHospitalizacion.Tables(0).Rows.Count > 0 Then
                'Verificar Ingreso Hospitalizacion
                Dim dsIngreso As New Data.DataSet
                dsIngreso = objIngreso.Buscar(dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion"))
                If dsIngreso.Tables(0).Rows.Count > 0 Then
                    IdIngreso = dsIngreso.Tables(0).Rows(0)("IdIngreso")
                Else
                    MessageBox.Show("Debe registrar ingreso de paciente ha hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                'Buscar Datos de Mortalidad
                Dim dsMortalidad As New DataSet
                dsMortalidad = objMortalidad.Buscar(IdIngreso)
                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsMortalidad.Tables(0).Rows.Count - 1
                    Fila = lvTabla.Items.Add(dsMortalidad.Tables(0).Rows(I)("IdIngreso"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("Servicio"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("SubServicio"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("Especialidad"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("Responsable"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("Fecha"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("Causa"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("CIE"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("IdEspecialidad"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("IdResponsable"))
                    Fila.SubItems.Add(dsMortalidad.Tables(0).Rows(I)("Necropsia"))
                Next

                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsHospitalizacion.Tables(0).Rows(0)("FecIngreso")
                cboServicio.Select()
                Buscar()
            Else
                MessageBox.Show("Paciente No Esta Registrado En Hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblFecha.Text = ""
                lblPaciente.Text = ""
                IdIngreso = ""
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If IdIngreso = "" Then MessageBox.Show("Debe Seleccionar un paciente hospitalizado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            'Eliminar Mortalidad Anterior
            objMortalidad.Eliminar(IdIngreso)
            'Grabar Mortalidad
            objMortalidad.Mantenimiento(IdIngreso, lvTabla.Items(0).SubItems(9).Text, lvTabla.Items(0).SubItems(10).Text, lvTabla.Items(0).SubItems(5).Text, lvTabla.Items(0).SubItems(6).Text, lvTabla.Items(0).SubItems(7).Text, lvTabla.Items(0).SubItems(8).Text, lvTabla.Items(0).SubItems(9).Text, 3)
            For I = 0 To lvTabla.Items.Count - 1
                objMortalidad.Mantenimiento(IdIngreso, lvTabla.Items(I).SubItems(9).Text, lvTabla.Items(I).SubItems(10).Text, lvTabla.Items(I).SubItems(5).Text, lvTabla.Items(I).SubItems(6).Text, lvTabla.Items(I).SubItems(7).Text, lvTabla.Items(I).SubItems(8).Text, lvTabla.Items(I).SubItems(9).Text, 1)
            Next
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtCie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie.KeyDown
        If e.KeyCode = Keys.Enter And txtCie.Text = "" Then txtDescripcion.Select() : Exit Sub
        If txtCie.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsCIE As New Data.DataSet
            dsCIE = objCIE.BuscarCodigo(txtCie.Text)
            If dsCIE.Tables(0).Rows.Count > 0 Then
                txtDescripcion.Enabled = False
                txtDescripcion.Text = dsCIE.Tables(0).Rows(0)("desc_enf")
                txtDescripcion.Enabled = True
                txtDescripcion.Select()
            Else
                txtDescripcion.Text = ""
                txtCie.Select()
                MessageBox.Show("Codigo de CIE 10 no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub


    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter And txtDescripcion.Text <> "" And txtCie.Text <> "" Then
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(IdIngreso)
            Fila.SubItems.Add(cboServicio.Text)
            Fila.SubItems.Add(cboSubServicio.Text)
            Fila.SubItems.Add(cboEspecialidad.Text)
            Fila.SubItems.Add(cboResponsable.Text)
            Fila.SubItems.Add(dtpFecha.Value.ToShortDateString)
            Fila.SubItems.Add(cboCausa.Text)
            Fila.SubItems.Add(txtCie.Text)
            Fila.SubItems.Add(txtDescripcion.Text)
            Fila.SubItems.Add(cboEspecialidad.SelectedValue)
            Fila.SubItems.Add(cboResponsable.SelectedValue)
            Fila.SubItems.Add(cboNecropsia.Text)
            txtCie.Text = ""
            txtDescripcion.Text = ""
            dtpFecha.Select()
        End If
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
            dsCIE = objCIE.BuscarDes(txtFiltro.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
            Next
        End If
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            If lvDet.SelectedItems.Count > 0 Then
                Dim Fila As ListViewItem
                Fila = lvTabla.Items.Add(IdIngreso)
                Fila.SubItems.Add(cboServicio.Text)
                Fila.SubItems.Add(cboSubServicio.Text)
                Fila.SubItems.Add(cboEspecialidad.Text)
                Fila.SubItems.Add(cboResponsable.Text)
                Fila.SubItems.Add(dtpFecha.Value.ToShortDateString)
                Fila.SubItems.Add(cboCausa.Text)
                Fila.SubItems.Add(lvDet.SelectedItems(0).SubItems(0).Text)
                Fila.SubItems.Add(lvDet.SelectedItems(0).SubItems(1).Text)
                Fila.SubItems.Add(cboEspecialidad.SelectedValue)
                Fila.SubItems.Add(cboResponsable.SelectedValue)
                Fila.SubItems.Add(cboNecropsia.Text)
                btnRetornar_Click(sender, e)
                txtCie.Text = ""
                txtDescripcion.Text = ""
                dtpFecha.Select()
            End If
            btnRetornar_Click(sender, e)
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        txtFiltro.Text = ""
        gbConsulta.Visible = False
        lvDet.Items.Clear()
    End Sub

    Private Sub frmMortalidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Servicio
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Combo("%")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdPiso"

        'Responsable
        Dim dsResponsable As New Data.DataSet
        dsResponsable = objMedico.BuscarTipoPersonal(1)
        cboResponsable.DataSource = dsResponsable.Tables(0)
        cboResponsable.DisplayMember = "Personal"
        cboResponsable.ValueMember = "IdMedico"
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        txtHistoria.Select()
        gbConsulta.Visible = False
        cboNecropsia.Text = "NO"
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If IsNumeric(cboServicio.SelectedValue) And e.KeyCode = Keys.Enter Then cboSubServicio.Select()
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
        If e.KeyCode = Keys.Enter And IsNumeric(cboEspecialidad.SelectedValue) Then cboResponsable.Select()
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged

    End Sub

    Private Sub cboResponsable_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboResponsable.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboResponsable.SelectedValue) Then cboNecropsia.Select()
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged

    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboCausa.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub cboCausa_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCausa.KeyDown
        If e.KeyCode = Keys.Enter And cboCausa.Text <> "" Then txtCie.Select()
    End Sub

    Private Sub cboCausa_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCausa.SelectedIndexChanged

    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de quitar información de mortalidad?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
                MessageBox.Show("Para completar la eliminación de los procedimientos, Haga click en Grabar", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub cboNecropsia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboNecropsia.KeyDown
        If e.KeyCode = Keys.Enter And cboNecropsia.Text <> "" Then dtpFecha.Select()
    End Sub

    Private Sub txtCie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie.TextChanged
        If txtCie.Text = "" Then txtDescripcion.Text = ""
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        If txtDescripcion.Text <> "" And txtDescripcion.Enabled Then txtFiltro.Text = txtDescripcion.Text : txtFiltro.SelectionStart = txtFiltro.TextLength : gbConsulta.Visible = True : txtFiltro.Select() : Filtro = "CF"
    End Sub
End Class