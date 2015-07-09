Public Class frmAsignacionCargo
    Dim objCargo As New Cargo
    Dim objTrabajador As New Trabajador
    Dim objDptoUnidad As New DptoUnidad
    Dim objServiArea As New ServiArea
    Dim objAsignacionCargo As New clsAsignacionCargo

    Dim Fila As ListViewItem

    Dim Oper As Integer
    Dim I As Integer
    Dim IdAsignacionCargo As Integer

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsAsignacionCargo As Data.DataSet
        dsAsignacionCargo = objAsignacionCargo.BuscarPorNombre(txtFiltro.Text)
        For Me.I = 0 To dsAsignacionCargo.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsAsignacionCargo.Tables(0).Rows(I)("IdAsignacionCargo"))
            Fila.SubItems.Add(dsAsignacionCargo.Tables(0).Rows(I)("IdTrabajador"))
            Fila.SubItems.Add(dsAsignacionCargo.Tables(0).Rows(I)("IdServiArea"))
            Fila.SubItems.Add(dsAsignacionCargo.Tables(0).Rows(I)("IdCargo"))
            Fila.SubItems.Add(dsAsignacionCargo.Tables(0).Rows(I)("Nombre"))
            Fila.SubItems.Add(dsAsignacionCargo.Tables(0).Rows(I)("Dpto/Und"))
            Fila.SubItems.Add(dsAsignacionCargo.Tables(0).Rows(I)("Servi/Area"))
            Fila.SubItems.Add(dsAsignacionCargo.Tables(0).Rows(I)("Cargo"))
            Fila.SubItems.Add(dsAsignacionCargo.Tables(0).Rows(I)("Activo").ToString)
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        btnAgregar.Enabled = True
        btnQuitar.Enabled = True
        txtTrabajador.Select()
        Oper = 1
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        btnAgregar.Enabled = False
        btnQuitar.Enabled = False
        txtFiltro.Enabled = True
        Buscar()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmAsignacionCargo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        lvTrabajador.Visible = False
        'btnRegresar.Visible = False

        'Llenar Cargo
        Dim dsCargo As New Data.DataSet
        dsCargo = objCargo.Combo()
        cboCargo.DataSource = dsCargo.Tables(0)
        cboCargo.DisplayMember = "Descripcion"
        cboCargo.ValueMember = "IdCargo"

        'Llenar DptoUnidad
        Dim dsDptoUnidad As New Data.DataSet
        dsDptoUnidad = objDptoUnidad.Buscar("")
        cboDptoUnidad.DataSource = dsDptoUnidad.Tables(0)
        cboDptoUnidad.DisplayMember = "Descripcion"
        cboDptoUnidad.ValueMember = "IdDptoUnidad"

        'Llenar ServiArea
        Dim dsServiArea As New Data.DataSet
        dsServiArea = objServiArea.Combo(cboDptoUnidad.SelectedValue.ToString)
        cboServiArea.DataSource = dsServiArea.Tables(0)
        cboServiArea.DisplayMember = "Descripcion"
        cboServiArea.ValueMember = "IdServiArea"
    End Sub

    Private Sub cboDptoUnidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDptoUnidad.SelectedIndexChanged
        cboServiArea.Text = ""
        If IsNumeric(cboDptoUnidad.SelectedValue) Then
            'Llenar ServiArea
            Dim dsServiArea As New Data.DataSet
            dsServiArea = objServiArea.Combo(cboDptoUnidad.SelectedValue.ToString)
            cboServiArea.DataSource = dsServiArea.Tables(0)
            cboServiArea.DisplayMember = "Descripcion"
            cboServiArea.ValueMember = "IdServiArea"
        End If
    End Sub

    Private Sub txtTrabajador_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTrabajador.TextChanged
        If txtTrabajador.Enabled And txtTrabajador.Text <> "" Then
            Dim dsTrabajador As New Data.DataSet
            dsTrabajador = objTrabajador.Buscar(txtTrabajador.Text)
            lvTrabajador.Items.Clear()
            For Me.I = 0 To dsTrabajador.Tables(0).Rows.Count - 1
                    Fila = lvTrabajador.Items.Add(dsTrabajador.Tables(0).Rows(I)("IdTrabajador"))
                    Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("Nombres"))
                    Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("Iniciales"))
                    Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("DNI"))
                    Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("Activo"))
            Next
            lvTrabajador.Visible = True
            'btnRegresar.Visible = True
        Else
            If txtTrabajador.Text = "" Then
                lvTrabajador.Items.Clear()
                lvTrabajador.Visible = False
            End If
        End If
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lvTrabajador.Items.Clear()
        'btnRegresar.Visible = False
        lvTrabajador.Visible = False
        txtTrabajador.Text = ""
    End Sub

    Private Sub lvTrabajador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTrabajador.KeyDown
        If lvTrabajador.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            txtTrabajador.Tag = lvTrabajador.SelectedItems(0).SubItems(0).Text
            txtTrabajador.Text = lvTrabajador.SelectedItems(0).SubItems(1).Text
            lvTrabajador.Items.Clear()
            lvTrabajador.Visible = False
            'btnRegresar.Visible = False
            cboDptoUnidad.Select()
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If txtTrabajador.Text <> "" And txtTrabajador.Tag <> "" Then
            Fila = lvTabla.Items.Add("")
            Fila.SubItems.Add(txtTrabajador.Tag)
            Fila.SubItems.Add(cboServiArea.SelectedValue)
            Fila.SubItems.Add(cboCargo.SelectedValue)
            Fila.SubItems.Add(txtTrabajador.Text)
            Fila.SubItems.Add(cboDptoUnidad.Text)
            Fila.SubItems.Add(cboServiArea.Text)
            Fila.SubItems.Add(cboCargo.Text)
        Else
            MessageBox.Show("Ingrese el Personal a Asignar", "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTrabajador.Select()
        End If
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        If lvTabla.SelectedItems.Count > 0 Then
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
        Else
            MessageBox.Show("Seleccione el elemento a quitar", "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim activo As String
        If chbxActivo.Checked = True Then
            activo = "SI"
        Else
            activo = "NO"
        End If
        If Oper = 1 Then
            If MessageBox.Show("¿Está seguro que desea guardar los datos?", "Mensaje de consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For Me.I = 0 To lvTabla.Items.Count - 1
                    If lvTabla.Items(I).SubItems(0).Text = "" Then
                        objAsignacionCargo.Mantenimiento(IdAsignacionCargo, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(2).Text,
                                                         lvTabla.Items(I).SubItems(3).Text, activo, Oper)
                    End If
                Next
            End If
            btnCancelar_Click(sender, e)
        Else
            If Oper = 2 Then
                If MessageBox.Show("¿Está seguro de modificar los datos?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    objAsignacionCargo.Mantenimiento(lvTabla.SelectedItems(0).SubItems(0).Text, lvTabla.SelectedItems(0).SubItems(1).Text, cboServiArea.SelectedValue,
                                                     cboCargo.SelectedValue, activo, Oper)
                End If
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtTrabajador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrabajador.KeyDown
        If txtTrabajador.Text <> "" And e.KeyCode = Keys.Enter Then
            lvTrabajador.Select()
        End If
    End Sub
    Private Sub cboDptoUnidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDptoUnidad.KeyDown
        If txtTrabajador.Text <> "" And e.KeyCode = Keys.Enter Then cboServiArea.Select()
    End Sub

    Private Sub cboServiArea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServiArea.KeyDown
        If e.KeyCode = Keys.Enter Then cboCargo.Select()
    End Sub

    Private Sub cboCargo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCargo.KeyDown
        If e.KeyCode = Keys.Enter Then btnAgregar.Select()
    End Sub

    Private Sub btnAgregar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnAgregar.KeyDown
        If e.KeyCode = Keys.Enter Then txtTrabajador.Select()
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            txtTrabajador.Enabled = False
            txtTrabajador.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            txtTrabajador.Enabled = True
            cboDptoUnidad.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            cboServiArea.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            cboCargo.Text = lvTabla.SelectedItems(0).SubItems(7).Text
            Dim activo As String
            activo = lvTabla.SelectedItems(0).SubItems(8).Text
            If activo = "SI" Then
                chbxActivo.Checked = True
            Else
                chbxActivo.Checked = False
            End If
        End If
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        btnAgregar.Enabled = False
        btnQuitar.Enabled = False
        Oper = 2
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If txtFiltro.Text <> "" And e.KeyCode = Keys.Enter Then lvTabla.Select()
    End Sub
End Class