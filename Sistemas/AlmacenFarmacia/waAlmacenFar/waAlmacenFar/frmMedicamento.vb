Public Class frmMedicamento
    Dim objMedicamento As New Medicamento
    Dim CodLocal As String
    Dim Oper As String

    Private Sub Buscar()
        lvDet.Items.Clear()
        Dim dsVer As Data.DataSet
        dsVer = objMedicamento.Buscar(txtFiltro.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsVer.Tables(0).Rows(I)("IdMedicamento"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoBien"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Unidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("PrecioCosto"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("StockActual"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("StockMinFar"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("StockMinAlm"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Activo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("StockActualA"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("BienServ"))
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtNombre.Select()
    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter And txtNombre.Text <> "" Then cboUnidad.Select()
    End Sub

    Private Sub cboUnidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUnidad.KeyDown
        If e.KeyCode = Keys.Enter And cboUnidad.Text <> "" Then txtCosto.Select()
    End Sub

    Private Sub txtCosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCosto.KeyDown
        If e.KeyCode = Keys.Enter And txtCosto.Text <> "" Then txtStockAct.Select()
    End Sub

    Private Sub txtStockAct_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockAct.KeyDown
        If txtStockAct.Text <> "" And e.KeyCode = Keys.Enter Then txtStockMinF.Select()
    End Sub

    Private Sub txtStockMinF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockMinF.KeyDown
        If txtStockMinF.Text <> "" And e.KeyCode = Keys.Enter Then txtStockActA.Select()
    End Sub

    Private Sub txtStockMinA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockMinA.KeyDown
        If txtStockMinA.Text <> "" And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        txtFiltro.Enabled = True
        Buscar()
    End Sub

    Private Sub frmMedicamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Activar(Me, True)
        Botones(False, True, True, False)
        cboTipo.Select()
    End Sub

    Private Sub lvDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDet.Click
        If lvDet.Items.Count > 0 And lvDet.SelectedItems.Count > 0 Then
            Oper = 2
            CodLocal = lvDet.SelectedItems(0).SubItems(0).Text
            lblCodigo.Text = lvDet.SelectedItems(0).SubItems(0).Text
            cboTipo.Text = lvDet.SelectedItems(0).SubItems(1).Text
            txtNombre.Text = lvDet.SelectedItems(0).SubItems(2).Text
            cboUnidad.Text = lvDet.SelectedItems(0).SubItems(3).Text
            txtCosto.Text = lvDet.SelectedItems(0).SubItems(4).Text
            txtStockAct.Text = lvDet.SelectedItems(0).SubItems(5).Text
            txtStockMinF.Text = lvDet.SelectedItems(0).SubItems(6).Text
            txtStockMinA.Text = lvDet.SelectedItems(0).SubItems(7).Text
            If lvDet.SelectedItems(0).SubItems(8).Text = 1 Then chkActivo.Checked = True Else chkActivo.Checked = False
            txtStockActA.Text = lvDet.SelectedItems(0).SubItems(9).Text
            txtCod.Text = lvDet.SelectedItems(0).SubItems(10).Text
            Activar(Me, True)
            Botones(False, True, True, False)
        End If
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de eliminar el registro", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim Activo As String = 0
                If chkActivo.Checked Then Activo = 1
                objMedicamento.Grabar(lvDet.SelectedItems(0).SubItems(0).Text, cboTipo.Text, txtNombre.Text, cboUnidad.Text, txtCosto.Text, txtStockAct.Text, txtStockMinF.Text, txtStockMinA.Text, txtStockActA.Text, Activo, Oper)
            End If
        End If
        
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Activo As String = 0
            If chkActivo.Checked Then Activo = 1
            objMedicamento.Grabar(CodLocal, cboTipo.Text, txtNombre.Text, cboUnidad.Text, txtCosto.Text, txtStockAct.Text, txtStockMinF.Text, txtStockMinA.Text, txtStockActA.Text, Activo, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

   

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub txtStockMinA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockMinA.TextChanged

    End Sub

    Private Sub txtStockMinF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockMinF.TextChanged

    End Sub

    Private Sub txtStockActA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockActA.KeyDown
        If e.KeyCode = Keys.Enter And txtStockActA.Text <> "" Then txtStockMinA.Select()
    End Sub

    Private Sub txtStockActA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockActA.TextChanged

    End Sub
End Class