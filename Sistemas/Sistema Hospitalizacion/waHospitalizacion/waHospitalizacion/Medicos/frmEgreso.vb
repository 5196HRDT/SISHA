Public Class frmEgreso
    Dim objEgreso As New Egreso
    Dim objHospitalizacion As New Hospitalizacion
    Dim objIngreso As New Ingreso
    Dim objTipoAlta As New TipoAlta
    Dim objCondicionAlta As New CondicionAlta
    Dim objServicio As New Servicio
    Dim objSubServicio As New SubServicio
    Dim objEspecialidad As New Especialidad
    Dim objMedico As New Medico
    Dim objCIE As New CIE10
    Dim objCentro As New CentroSalud
    Dim objEgresoCIE As New EgresoCIE
    Dim objTransferencia As New TransferenciaServicio
    Dim objHistoria As New Historia


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

        Dim dsCIE As New DataSet
        Dim I As Integer
        Dim Fila As ListViewItem
        dsCIE = objEgresoCIE.Buscar(IdIngreso)
        For I = 0 To dsCIE.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsCIE.Tables(0).Rows(I)("Cie"))
            Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Descripcion"))
        Next
    End Sub

    Private Sub frmEgreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        btnBPac.Enabled = False
        gbBPac.Visible = False

        'Tipo Alta
        Dim dsTipoAlta As New Data.DataSet
        dsTipoAlta = objTipoAlta.Buscar("Select * From TipoAlta")
        cboTipoAlta.DataSource = dsTipoAlta.Tables(0)
        cboTipoAlta.DisplayMember = "Descripcion"
        cboTipoAlta.ValueMember = "IdTipoAlta"

        'Condicion Alta
        Dim dsCondicionAlta As New Data.DataSet
        dsCondicionAlta = objCondicionAlta.Buscar("Select * From CondicionAlta")
        cboCondicionAlta.DataSource = dsCondicionAlta.Tables(0)
        cboCondicionAlta.DisplayMember = "Descripcion"
        cboCondicionAlta.ValueMember = "CodCondicion"

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

        'Enfermera
        Dim dsEnfermera As New Data.DataSet
        dsEnfermera = objMedico.BuscarTipoPersonal(2)
        cboEnfermera.DataSource = dsEnfermera.Tables(0)
        cboEnfermera.DisplayMember = "Personal"
        cboEnfermera.ValueMember = "IdMedico"

        'Centro Salud
        Dim dsCentro As New Data.DataSet
        dsCentro = objCentro.Combo
        cboReferido.DataSource = dsCentro.Tables(0)
        cboReferido.DisplayMember = "Descripcion"
        cboReferido.ValueMember = "IdCentro"
    End Sub


    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dsHospitalizacion As New Data.DataSet
            IdHospitalizacion = ""
            dsHospitalizacion = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
            If dsHospitalizacion.Tables(0).Rows.Count > 0 Then
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")
                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsHospitalizacion.Tables(0).Rows(0)("FecIngreso")
                'Verificar Ingreso Hospitalizacion
                Dim dsIngreso As New Data.DataSet
                dsIngreso = objIngreso.Buscar(IdHospitalizacion)
                If dsIngreso.Tables(0).Rows.Count > 0 Then
                    IdIngreso = dsIngreso.Tables(0).Rows(0)("IdIngreso")
                    lblFecha.Text = dsIngreso.Tables(0).Rows(0)("Fecha")
                    cboServicio.Text = dsIngreso.Tables(0).Rows(0)("Servicio")
                    cboServicio_SelectedIndexChanged(sender, e)

                    cboSubServicio.Text = dsIngreso.Tables(0).Rows(0)("SubServicio")
                    cboSubServicio_SelectedIndexChanged(sender, e)
                    cboEspecialidad.Text = dsIngreso.Tables(0).Rows(0)("Especialidad")
                    cboEspecialidad_SelectedIndexChanged(sender, e)
                    cboResponsable.Text = dsIngreso.Tables(0).Rows(0)("Responsable")
                    cboEnfermera.Text = dsIngreso.Tables(0).Rows(0)("Enfermera")

                    'Verificar Transferencia de Servicio
                    Dim dsTransferencia As New DataSet
                    dsTransferencia = objTransferencia.Buscar(IdIngreso)
                    If dsTransferencia.Tables(0).Rows.Count > 0 Then
                        lblFecha.Text = dsTransferencia.Tables(0).Rows(0)("Fecha")
                        lblHora.Text = dsTransferencia.Tables(0).Rows(0)("Hora")
                        cboServicio.Text = dsTransferencia.Tables(0).Rows(0)("Servicio")
                        cboServicio_SelectedIndexChanged(sender, e)
                        cboSubServicio.Text = dsTransferencia.Tables(0).Rows(0)("SubServicio")
                        cboSubServicio_SelectedIndexChanged(sender, e)
                        cboEspecialidad.Text = dsTransferencia.Tables(0).Rows(0)("Especialidad")
                        cboEspecialidad_SelectedIndexChanged(sender, e)
                        'cboCama.Text = dsTransferencia.Tables(0).Rows(0)("Cama")
                        cboResponsable.Text = dsTransferencia.Tables(0).Rows(0)("Medico")
                        cboEnfermera.Text = dsTransferencia.Tables(0).Rows(0)("Enfermera")
                    End If


                    lblPaciente.Text = ""
                Else
                    MessageBox.Show("Debe registrar ingreso de paciente ha hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")

                Buscar()

                dtpFecha.Select()
            Else
                MessageBox.Show("Paciente No Esta Registrado En Hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        btnBPac.Enabled = True
        Oper = 1
        dtpFecha.Value = Date.Now
        txtHora.Text = Date.Now.TimeOfDay.ToString
        txtHistoria.Select()
        cboReferido.Enabled = False
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objEgreso.Mantenimiento(IdIngreso, dtpFecha.Value.ToShortDateString, txtHora.Text, cboResponsable.SelectedValue, cboEspecialidad.SelectedValue, cboEnfermera.SelectedValue, cboTipoAlta.SelectedValue, cboCondicionAlta.SelectedValue, cboReferido.Text, Oper)

            objEgresoCIE.Eliminar(IdIngreso)
            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                objEgresoCIE.Grabar(IdIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text)
            Next

            objIngreso.AltaPaciente(IdIngreso, dtpFecha.Value.ToShortDateString)
            objHospitalizacion.AltaServicio(IdHospitalizacion, dtpFecha.Value.ToShortDateString, txtHora.Text, UsuarioSistema, My.Computer.Name, dtpFecha.Value.ToShortDateString)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblPaciente.Text = ""
        lblFecha.Text = ""
        lvTabla.Items.Clear()
        Botones(True, False, False, True)
        Limpiar(Me)
        Activar(Me, False)
        cboReferido.Enabled = False
        gbConsulta.Visible = False
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtCIE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE.Text = "" Then txtDes.Select()
        If e.KeyCode = Keys.Enter And txtCIE.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            lvDet.Items.Clear()
            dsCIE = objCIE.BuscarCodigo(txtCIE.Text)
            If dsCIE.Tables(0).Rows.Count > 0 Then
                txtDes.Enabled = False
                txtDes.Text = dsCIE.Tables(0).Rows(I)("desc_enf")
                txtDes.Enabled = True
                txtDes.Select()
            Else
                txtDes.Text = ""
                txtCIE.Select()
                MessageBox.Show("Codigo de CIE 10 no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If txtCIE.Text <> "" And txtDes.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(txtCIE.Text)
            Fila.SubItems.Add(txtDes.Text)
            txtCIE.Text = ""
            txtDes.Text = ""
            txtCIE.Select()
        End If
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And txtDes.Enabled Then txtFiltro.Text = txtDes.Text : txtFiltro.SelectionStart = txtFiltro.TextLength : gbConsulta.Visible = True : txtFiltro.Select()
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    txtCIE.Text = ""
                    txtDes.Text = ""
                    Dim Fila As ListViewItem
                    Fila = lvTabla.Items.Add(lvDet.Items(I).SubItems(0).Text)
                    Fila.SubItems.Add(lvDet.Items(I).SubItems(1).Text)
                End If
            Next
            btnRetornar_Click(sender, e)
            txtCIE.Select()
        End If
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        txtFiltro.Text = ""
        gbConsulta.Visible = False
        lvDet.Items.Clear()
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvDet.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
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

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

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

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

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
        If IsNumeric(cboSubServicio.SelectedValue) And e.KeyCode = Keys.Enter Then cboEspecialidad.Select()
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

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter And txtHora.Text <> "" Then cboTipoAlta.Select()
    End Sub

    Private Sub txtHora_MaskInputRejected(sender As System.Object, e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtHora.MaskInputRejected

    End Sub

    Private Sub cboTipoAlta_Click(sender As Object, e As System.EventArgs) Handles cboTipoAlta.Click
        cboTipoAlta_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cboTipoAlta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAlta.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoAlta.Text <> "" Then cboCondicionAlta.Select()
    End Sub

    Private Sub cboTipoAlta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoAlta.SelectedIndexChanged
        If cboTipoAlta.Text = "REFERIDO" Then cboReferido.Enabled = True Else cboReferido.Enabled = False
    End Sub

    Private Sub cboCondicionAlta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCondicionAlta.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboCondicionAlta.SelectedValue) Then cboServicio.Select()
    End Sub

    Private Sub cboCondicionAlta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCondicionAlta.SelectedIndexChanged

    End Sub

    Private Sub cboEspecialidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEspecialidad.SelectedValue) Then cboResponsable.Select()
    End Sub

    Private Sub cboEspecialidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboEspecialidad.KeyPress

    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged

    End Sub

    Private Sub cboResponsable_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboResponsable.KeyDown
        If e.KeyCode = Keys.Enter And cboReferido.Enabled And IsNumeric(cboResponsable.SelectedValue) Then cboReferido.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And Not cboReferido.Enabled And IsNumeric(cboResponsable.SelectedValue) Then cboEnfermera.Select()
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged

    End Sub

    Private Sub cboEnfermera_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEnfermera.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEnfermera.SelectedValue) Then txtCIE.Select()
    End Sub

    Private Sub cboEnfermera_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEnfermera.SelectedIndexChanged

    End Sub

    Private Sub cboReferido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboReferido.KeyDown
        If e.KeyCode = Keys.Enter Then cboEnfermera.Select()
    End Sub

    Private Sub btnBPac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBPac.Click
        gbBPac.Visible = True
        txtFPac.Select()
    End Sub

    Private Sub txtFPac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPac.KeyDown
        If txtFPac.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtFPac.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvBPac.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
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

    Private Sub txtFPac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFPac.TextChanged

    End Sub

    Private Sub lvBPac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvBPac.KeyDown
        If e.KeyCode = Keys.Enter And lvBPac.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvBPac.SelectedItems(0).SubItems(0).Text
            gbBPac.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvBPac_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBPac.SelectedIndexChanged

    End Sub
End Class