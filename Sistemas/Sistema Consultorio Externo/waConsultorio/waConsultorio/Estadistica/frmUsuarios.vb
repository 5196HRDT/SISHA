Public Class frmUsuarios
    Dim objUsuario As New Usuario

    Dim Bandera As String
    Dim CodLocal As String

    Private Sub Buscar(ByVal Filtro As String)
        Dim dsTabla As New DataSet
        dsTabla = objUsuario.BuscarConsultorio(Filtro)
        lvTabla.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("IdUsuario"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Iniciales"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Clave"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Nivel"))
            If dsTabla.Tables(0).Rows(I)("Activo") = "1" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
            If dsTabla.Tables(0).Rows(I)("Inicial") = "0" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        ControlesAD(Me, False)
        txtFiltro.Enabled = True
        Buscar(txtFiltro.Text)
    End Sub

    Private Sub frmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        txtNombres.Select()
        cboActivo.Text = "SI"
        cboCambiar.Text = "SI"
        cboNivel.Text = "ESTADISTICA"
        Bandera = 1
        CodLocal = 0
    End Sub

    Private Sub txtNombres_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombres.KeyDown
        If e.KeyCode = Keys.Enter And txtNombres.Text <> "" Then txtUsuario.Select()
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If txtNombres.Enabled Then Buscar(txtNombres.Text)
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter And txtUsuario.Text <> "" Then txtClave.Select()
    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And txtClave.Text <> "" Then cboNivel.Select()
    End Sub

    Private Sub txtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub cboNivel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNivel.KeyDown
        If e.KeyCode = Keys.Enter And cboNivel.Text <> "" Then cboActivo.Select()
    End Sub

    Private Sub cboActivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboActivo.KeyDown
        If e.KeyCode = Keys.Enter And cboActivo.Text <> "" Then cboCambiar.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Guardar la Información de Usuario?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Inicial, Activo As String
            If cboActivo.Text = "SI" Then Activo = 1 Else Activo = 0
            If cboCambiar.Text = "SI" Then Inicial = 0 Else Inicial = 1
            objUsuario.GuardarUsuario(CodLocal, Date.Now.ToShortDateString, txtUsuario.Text, txtNombres.Text, txtClave.Text, cboNivel.Text, Inicial, Activo, Bandera)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            CodLocal = lvTabla.SelectedItems(0).SubItems(0).Text
            txtNombres.Enabled = False
            txtNombres.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            txtNombres.Enabled = True
            txtUsuario.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            txtClave.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            cboNivel.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            cboActivo.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            cboCambiar.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            ControlesAD(Me, True)
            Botones(False, True, True, False)
            Bandera = 2
        End If
    End Sub

    Private Sub cboCambiar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCambiar.KeyDown
        If e.KeyCode = Keys.Enter And cboCambiar.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar(txtFiltro.Text)
    End Sub
End Class