Public Class frmTrabajadores
    Dim Oper As String
    Dim objTrabajador As New Trabajador
    Dim objDptoUnidad As New DptoUnidad
    Dim objServiArea As New ServiArea
    Dim objTitulo As New Titulo
    Dim objCargo As New Cargo
    Dim CodLocal As String = ""
    Dim CEmail As Boolean = False

    Private Sub ValidarEmail()
        If txtEmail.Text <> "" And txtCEmail.Text <> "" Then
            'If txtEmail.Text <> txtCEmail.Text Then MessageBox.Show("No Coincide Email del Personal", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : CEmail = False Else CEmail = True
        End If
    End Sub

    Private Sub Buscar()
        Dim dsTab As New Data.DataSet
        dsTab = objTrabajador.Buscar(txtFiltro.Text)
        lvTabla.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTab.Tables(0).Rows(I)("IdTrabajador"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNI"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Titulo"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Iniciales"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("firma"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Email"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Activo"))
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

    Private Sub frmTrabajador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Llenar Titulo
        Dim dsTitulo As New Data.DataSet
        dsTitulo = objTitulo.Combo()
        cboTitulo.DataSource = dsTitulo.Tables(0)
        cboTitulo.DisplayMember = "Iniciales"
        cboTitulo.ValueMember = "IdTitulo"
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        chkActivo.Checked = True
        cboTitulo.Select()
    End Sub

    Private Sub lvTabla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTabla.Click
        lvTabla_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        txtFiltro.Enabled = True
        Buscar()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        'If Not CEmail Then MessageBox.Show("Debe ingresar correctamente el Email", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim Activo As String
        If txtDNI.Text = "" Then
            MessageBox.Show("Debe ingresar el número de DNI", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDNI.Select()
        Else
            If txtNombres.Text = "" Then
                MessageBox.Show("Debe ingresar su nombre completo", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNombres.Select()
            Else
                If TxtIniciales.Text = "" Then
                    MessageBox.Show("Debe ingresar sus iniciales", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtIniciales.Select()
                Else
                    If TxtFirmaDigital.Text = "" Then
                        MessageBox.Show("Debe ingresar una clave", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtFirmaDigital.Select()
                    Else
                        If MessageBox.Show("Esta seguro de Grabar Datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            If chkActivo.Checked Then Activo = "SI" Else Activo = "NO"
                            objTrabajador.Mantenimiento(CodLocal, cboTitulo.SelectedValue, txtDNI.Text, txtNombres.Text, TxtIniciales.Text, TxtFirmaDigital.Text, txtEmail.Text, Activo, Oper)
                        End If
                        btnCancelar_Click(sender, e)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.Items.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Trabajador", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                objTrabajador.Mantenimiento(CodLocal, cboTitulo.SelectedValue, txtDNI.Text, txtNombres.Text, TxtIniciales.Text, TxtFirmaDigital.Text, txtEmail.Text, "SI", 3)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            Oper = 2
            CodLocal = lvTabla.SelectedItems(0).SubItems(0).Text
            txtDNI.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            cboTitulo.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            txtNombres.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            TxtIniciales.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            TxtFirmaDigital.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            txtEmail.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            txtCEmail.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            If lvTabla.SelectedItems(0).SubItems(7).Text = "SI" Then chkActivo.Checked = True Else chkActivo.Checked = False
            ControlesAD(Me, True)
            Botones(False, True, True, False)
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub TxtIniciales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIniciales.KeyDown
        If e.KeyCode = Keys.Enter Then TxtFirmaDigital.Select()
    End Sub

    Private Sub cboTitulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTitulo.KeyDown
        If e.KeyCode = Keys.Enter Then txtDNI.Select()
    End Sub

    Private Sub txtEmail_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter And txtEmail.Text <> "" Then txtCEmail.Select()
    End Sub

    Private Sub txtEmail_LostFocus(sender As Object, e As System.EventArgs) Handles txtEmail.LostFocus
        ValidarEmail()
    End Sub

    Private Sub txtCEmail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCEmail.KeyDown
        If e.KeyCode = Keys.Enter And txtCEmail.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub txtCEmail_LostFocus(sender As Object, e As System.EventArgs) Handles txtCEmail.LostFocus
        ValidarEmail()
    End Sub

    Private Sub txtDNI_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtDNI.Text) Then txtNombres.Select()
    End Sub
End Class