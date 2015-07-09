Public Class frmUsuarios
    Dim objUsuario As New Usuario
    Dim objTipoNivel As New clsTipoUsuario

    Dim Oper As Integer
    Dim Codigo As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        Dim dsTipoNivel As New DataSet
        dsTipoNivel = objTipoNivel.Combo
        cboNivel.DataSource = dsTipoNivel.Tables(0)
        cboNivel.DisplayMember = "Nivel"
        cboNivel.ValueMember = "IdTipo"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        Limpiar(Me)
        Activar(Me, False)
        Oper = 1
        Codigo = ""
        txtFiltro.Text = ""
        lvTabla.Items.Clear()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        Activar(Me, True)
        Oper = 1
        Codigo = ""
        cboActivo.Text = "SI"
        cboCambiarClave.Text = "SI"
        txtUsuario.Select()
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter And txtUsuario.Text <> "" Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And txtClave.Text <> "" Then txtNombres.Select()
    End Sub

    Private Sub txtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub txtNombres_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombres.KeyDown
        If e.KeyCode = Keys.Enter And txtNombres.Text <> "" Then cboActivo.Select()
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged

    End Sub

    Private Sub cboActivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboActivo.KeyDown
        If e.KeyCode = Keys.Enter And cboActivo.Text <> "" Then cboCambiarClave.Select()
    End Sub

    Private Sub cboActivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboActivo.SelectedIndexChanged

    End Sub

    Private Sub cboCambiarClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCambiarClave.KeyDown
        If e.KeyCode = Keys.Enter And cboCambiarClave.Text <> "" Then cboNivel.Select()
    End Sub

    Private Sub cboCambiarClave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCambiarClave.SelectedIndexChanged

    End Sub

    Private Sub cboNivel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNivel.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboNivel.SelectedValue) Then btnGrabar.Select()
    End Sub

    Private Sub cboNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNivel.SelectedIndexChanged

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim Activo, Iniciales As String

        If cboActivo.Text = "SI" Then Activo = "1" Else Activo = "0"
        If cboCambiarClave.Text = "SI" Then Iniciales = "1" Else Iniciales = "0"
        If Oper = 1 Then
            objUsuario.Grabar(Date.Now.ToShortDateString, txtUsuario.Text, txtClave.Text, txtNombres.Text, cboNivel.Text, Activo, Iniciales)
        Else
            objUsuario.Modificar(Codigo, txtUsuario.Text, txtClave.Text, txtNombres.Text, cboNivel.Text, Activo, Iniciales)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        lvTabla.Items.Clear()
        If txtFiltro.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objUsuario.Filtro(txtFiltro.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdUsuario"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Iniciales"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Clave"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Activo"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Inicial"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nivel"))
            Next
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            Oper = 2
            Codigo = lvTabla.SelectedItems(0).SubItems(0).Text
            txtUsuario.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            txtClave.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            txtNombres.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            If lvTabla.SelectedItems(0).SubItems(4).Text = "1" Then cboActivo.Text = "SI" Else cboActivo.Text = "NO"
            If lvTabla.SelectedItems(0).SubItems(5).Text = "1" Then cboCambiarClave.Text = "SI" Else cboCambiarClave.Text = "NO"
            cboNivel.Text = lvTabla.SelectedItems(0).SubItems(6).Text
        End If
    End Sub
End Class