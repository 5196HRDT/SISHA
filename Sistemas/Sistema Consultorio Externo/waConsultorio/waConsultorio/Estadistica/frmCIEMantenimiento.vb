Public Class frmCIEMantenimiento
    Dim objCIE As New CIE10
    Dim I As Integer
    Dim Fila As ListViewItem
    Dim Oper As Integer

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Buscar()
        lvTabla.Items.Clear()
        If txtFiltro.Text.Length < 2 Then Exit Sub
        Dim dsTabla As New DataSet
        dsTabla = objCIE.Buscar(txtFiltro.Text, 3)
        For Me.I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("Codigo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Clase2"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Clase1"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Sexo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("MinEdad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("MinTipo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("MaxEdad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("MaxTipo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Estado"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Definitivo"))
        Next
    End Sub

    Private Sub frmCIEMantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        Buscar()
        txtFiltro.Enabled = True
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        txtCodigo.Select()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If txtCodigo.Text <> "" And e.KeyCode = Keys.Enter Then txtDescripcion.Select()
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter And txtDescripcion.Text <> "" Then txtClase2.Select()
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub txtClase2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClase2.KeyDown
        If e.KeyCode = Keys.Enter Then txtClase1.Select()
    End Sub

    Private Sub txtClase2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClase2.TextChanged

    End Sub

    Private Sub txtClase1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClase1.KeyDown
        If e.KeyCode = Keys.Enter Then cboSexo.Select()
    End Sub

    Private Sub txtClase1_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles txtClase1.Layout

    End Sub

    Private Sub txtClase1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClase1.TextChanged

    End Sub

    Private Sub cboSexo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSexo.KeyDown
        If e.KeyCode = Keys.Enter Then txtMinEdad.Select()
    End Sub

    Private Sub cboSexo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSexo.SelectedIndexChanged

    End Sub

    Private Sub txtMinEdad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMinEdad.KeyDown
        If e.KeyCode = Keys.Enter Then cboMinTipo.Select()
    End Sub

    Private Sub txtMinEdad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMinEdad.TextChanged

    End Sub

    Private Sub cboMinTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMinTipo.KeyDown
        If e.KeyCode = Keys.Enter Then txtMaxEdad.Select()
    End Sub

    Private Sub cboMinTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMinTipo.SelectedIndexChanged

    End Sub

    Private Sub txtMaxEdad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaxEdad.KeyDown
        If e.KeyCode = Keys.Enter Then cboMaxTipo.Select()
    End Sub

    Private Sub txtMaxEdad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaxEdad.TextChanged

    End Sub

    Private Sub cboMaxTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMaxTipo.KeyDown
        If e.KeyCode = Keys.Enter Then cboEstado.Select()
    End Sub

    Private Sub cboMaxTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMaxTipo.SelectedIndexChanged

    End Sub

    Private Sub cboEstado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEstado.KeyDown
        If e.KeyCode = Keys.Enter And cboEstado.Text <> "" Then cboDefinitivo.Select()
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged

    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            Oper = 2
            txtCodigo.Text = lvTabla.SelectedItems(0).SubItems(0).Text
            txtDescripcion.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            txtClase2.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            txtClase1.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            cboSexo.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            txtMinEdad.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            cboMinTipo.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            txtMaxEdad.Text = lvTabla.SelectedItems(0).SubItems(7).Text
            cboMaxTipo.Text = lvTabla.SelectedItems(0).SubItems(8).Text
            cboEstado.Text = lvTabla.SelectedItems(0).SubItems(9).Text
            cboDefinitivo.Text = lvTabla.SelectedItems(0).SubItems(10).Text
            Botones(False, True, True, False)
            ControlesAD(Me, True)
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        objCIE.Mantenimiento(txtCodigo.Text, txtDescripcion.Text, txtClase2.Text, txtClase1.Text, cboSexo.Text, txtMinEdad.Text, cboMinTipo.Text, txtMaxEdad.Text, cboMaxTipo.Text, cboEstado.Text, cboDefinitivo.Text, Oper)
        btnCancelar_Click(sender, e)
    End Sub
End Class