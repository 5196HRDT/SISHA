Public Class frmCatalogoMedicamentos
    Dim objMedicamento As New Medicamentos
    Dim Oper As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Buscar()
        Dim Fila As ListViewItem
        Dim I As Integer
        Dim dsTabla As New Data.DataSet
        lvDet.Items.Clear()
        dsTabla = objMedicamento.BuscarMedicina(txtFiltro.Text, "COMUN", 1)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("Id"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Presentacion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Concentracion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Precio"))
        Next
    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmCatalogoMedicamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        Buscar()
        txtFiltro.Enabled = True
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        txtCodigo.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        objMedicamento.Mantenimiento(txtCodigo.Text, txtNombre.Text, txtPresentacion.Text, txtConcentracion.Text, txtCosto.Text, Oper)
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim Fila As ListViewItem
            If MessageBox.Show("Esta seguro de Eliminar Medicamento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For Each Fila In lvDet.SelectedItems
                    objMedicamento.Mantenimiento(Fila.SubItems(0).Text, txtNombre.Text, txtPresentacion.Text, txtConcentracion.Text, txtCosto.Text, 3)
                Next
                btnCancelar_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Insert Then
            Dim Fila As ListViewItem
            For Each Fila In lvDet.SelectedItems
                txtCodigo.Text = Fila.SubItems(0).Text
                txtNombre.Text = Fila.SubItems(1).Text
                txtPresentacion.Text = Fila.SubItems(2).Text
                txtConcentracion.Text = Fila.SubItems(3).Text
                txtCosto.Text = Fila.SubItems(4).Text
                Botones(False, True, True, False)
                ControlesAD(Me, True)
                txtNombre.Select()
                Oper = 2
            Next
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub txtPresentacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPresentacion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtPresentacion.Text.Length > 0 Then txtConcentracion.Select()
    End Sub

    Private Sub txtPresentacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPresentacion.TextChanged

    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNombre.Text.Length > 0 Then txtPresentacion.Select()
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCodigo.Text.Length > 0 Then txtNombre.Select()
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub txtConcentracion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcentracion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtConcentracion.Text.Length > 0 Then txtCosto.Select()
    End Sub

    Private Sub txtConcentracion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConcentracion.TextChanged

    End Sub

    Private Sub txtCosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCosto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCosto.Text.Length > 0 Then btnGrabar.Select()
    End Sub

    Private Sub txtCosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCosto.TextChanged

    End Sub
End Class