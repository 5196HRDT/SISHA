Public Class frmMedico
    Dim objMedico As New Medico
    Dim objEspecialidad As New Especialidad
    Dim objSE As New SubEspecialidad
    Dim objProfesion As New Profesion
    Dim objCondicion As New CondicionContrato
    Dim objColegio As New ColegioProfesional
    Dim CodLocal As String
    Dim Oper As String

    Dim I As Integer
    Dim Fila As ListViewItem

    Private Sub Buscar(Filtro As String)
        Dim dsMedico As New Data.DataSet
        dsMedico = objMedico.Medico_BuscarNombres(Filtro)
        lvTabla.Items.Clear()
        For I = 0 To dsMedico.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsMedico.Tables(0).Rows(I)("IdMedico"))
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("Apellidos"))
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("NroCMP"))
            If dsMedico.Tables(0).Rows(I)("DNI").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("DNI"))
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("SubServicio"))
            If dsMedico.Tables(0).Rows(I)("Usuario").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("Usuario"))
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("Clave"))
            If dsMedico.Tables(0).Rows(I)("Activo") = "1" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
            If dsMedico.Tables(0).Rows(I)("CambiarC").ToString <> "" Then If dsMedico.Tables(0).Rows(I)("CambiarC") = "1" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("FechaIngreso").ToString)
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("CodigoProfesion").ToString)
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("TipoColegiatura").ToString)
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("CodigoCondicion").ToString)
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("Medico").ToString)
            Fila.SubItems.Add(dsMedico.Tables(0).Rows(I)("Programas").ToString)
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmMedico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Especialidad
        Dim dsEsp As New Data.DataSet
        dsEsp = objEspecialidad.Combo("%")
        cboServicio.DataSource = dsEsp.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdDpto"

        'Profesion
        Dim dsProfesion As New Data.DataSet
        dsProfesion = objProfesion.Buscar("")
        cboProfesion.DataSource = dsProfesion.Tables(0)
        cboProfesion.DisplayMember = "Descripcion"
        cboProfesion.ValueMember = "Codigo"

        'Condicion Contrato
        Dim dsCondicion As New Data.DataSet
        dsCondicion = objCondicion.Buscar("")
        cboCondicion.DataSource = dsCondicion.Tables(0)
        cboCondicion.DisplayMember = "Descripcion"
        cboCondicion.ValueMember = "Codigo"

        'Condicion Contrato
        Dim dsColegio As New Data.DataSet
        dsColegio = objColegio.Buscar("")
        cboColegiatura.DataSource = dsColegio.Tables(0)
        cboColegiatura.DisplayMember = "Descripcion"
        cboColegiatura.ValueMember = "Codigo"

        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        dtpFechaIng.Value = Date.Now
        Botones(True, False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        Buscar(txtMedico.Text)
        txtMedico.Enabled = True
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        cboActivo.Text = "SI"
        cboFijar.Text = "SI"
        cboPrograma.Text = "NO"
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        txtApellidos.Select()
        Oper = 1
    End Sub

    Private Sub txtApellidos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApellidos.KeyDown
        If txtApellidos.Text <> "" And e.KeyCode = Keys.Enter Then txtNombres.Select()
    End Sub

    Private Sub txtApellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellidos.TextChanged
        If txtApellidos.Enabled Then Buscar(txtApellidos.Text)
    End Sub

    Private Sub txtNombres_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombres.KeyDown
        If txtNombres.Text <> "" And e.KeyCode = Keys.Enter Then txtCMP.Select()
    End Sub

    Private Sub txtCMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCMP.KeyDown
        If txtCMP.Text <> "" And e.KeyCode = Keys.Enter Then txtDNI.Select()
    End Sub

    Private Sub txtDNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyDown
        If txtDNI.Text <> "" And e.KeyCode = Keys.Enter Then cboServicio.Select()
    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If IsNumeric(cboServicio.SelectedValue) And e.KeyCode = Keys.Enter Then cboSubServicio.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSS As New Data.DataSet
            dsSS = objSE.Combo(cboServicio.SelectedValue)
            cboSubServicio.DataSource = dsSS.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub cboSubServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubServicio.KeyDown
        If IsNumeric(cboSubServicio.SelectedValue) And e.KeyCode = Keys.Enter Then txtUsuario.Select()
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If txtUsuario.Text <> "" And e.KeyCode = Keys.Enter Then txtClave.Select()
    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If txtClave.Text <> "" And e.KeyCode = Keys.Enter Then cboActivo.Select()
    End Sub

    Private Sub cboActivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboActivo.KeyDown
        If cboActivo.Text <> "" And e.KeyCode = Keys.Enter Then cboFijar.Select()
    End Sub

    Private Sub cboFijar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFijar.KeyDown
        If cboFijar.Text <> "" And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim Activo, Fijar As String
        If txtCMP.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Colegio Médico", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCMP.Select() : Exit Sub
        If cboActivo.Text = "SI" Then Activo = 1 Else Activo = 2
        If cboFijar.Text = "SI" Then Fijar = 1 Else Fijar = 2
        If MessageBox.Show("Esta seguro de grabar la informacion?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objMedico.Medicos_Mantenimiento(CodLocal, txtApellidos.Text, txtNombres.Text, txtCMP.Text, cboSubServicio.SelectedValue, txtUsuario.Text, txtClave.Text, Activo, Fijar, txtDNI.Text, cboProfesion.SelectedValue, cboColegiatura.SelectedValue, cboCondicion.SelectedValue, dtpFechaIng.Value.ToShortDateString, txtNomMedico.Text, Oper, cboPrograma.Text)
        End If
        btnCancelar_Click(sender, e)
        Buscar(txtMedico.Text)
    End Sub

    Private Sub txtMedico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMedico.TextChanged
        Buscar(txtMedico.Text)
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            CodLocal = lvTabla.SelectedItems(0).SubItems(0).Text
            txtApellidos.Enabled = False
            txtApellidos.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            txtApellidos.Enabled = True
            txtNombres.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            txtCMP.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            txtDNI.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            cboServicio.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            cboServicio_SelectedIndexChanged(sender, e)
            cboSubServicio.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            txtUsuario.Text = lvTabla.SelectedItems(0).SubItems(7).Text
            txtClave.Text = lvTabla.SelectedItems(0).SubItems(8).Text
            cboActivo.Text = lvTabla.SelectedItems(0).SubItems(9).Text
            cboFijar.Text = lvTabla.SelectedItems(0).SubItems(10).Text
            If lvTabla.SelectedItems(0).SubItems(11).Text <> "" Then dtpFechaIng.Value = lvTabla.SelectedItems(0).SubItems(11).Text
            'Profesion
            If lvTabla.SelectedItems(0).SubItems(12).Text <> "" Then
                Dim dsPro As New DataSet
                dsPro = objProfesion.BuscarCodigo(lvTabla.SelectedItems(0).SubItems(12).Text)
                cboProfesion.Text = dsPro.Tables(0).Rows(0)("Descripcion")
            End If
            'Colegiatura
            If lvTabla.SelectedItems(0).SubItems(13).Text <> "" Then
                Dim dsCol As New DataSet
                dsCol = objColegio.BuscarCodigo(lvTabla.SelectedItems(0).SubItems(13).Text)
                cboColegiatura.Text = dsCol.Tables(0).Rows(0)("Descripcion")
            End If
            'Condicion Contrato
            If lvTabla.SelectedItems(0).SubItems(14).Text <> "" Then
                Dim dsContrato As New DataSet
                dsContrato = objCondicion.BuscarCodigo(lvTabla.SelectedItems(0).SubItems(14).Text)
                cboCondicion.Text = dsContrato.Tables(0).Rows(0)("Descripcion")
            End If
            txtNomMedico.Text = lvTabla.SelectedItems(0).SubItems(15).Text.ToString
            cboPrograma.Text = lvTabla.SelectedItems(0).SubItems(16).Text.ToString

            Oper = 2
            ControlesAD(Me, True)
            Botones(False, True, True, False)
        End If
    End Sub

    Private Sub cboCondicion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCondicion.SelectedIndexChanged

    End Sub
End Class