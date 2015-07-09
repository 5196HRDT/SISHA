Public Class frmServicio
    Dim objServicio As New Servicio
    Dim CodLocal As String
    Dim Oper As String
    Dim I As Integer
    Dim Fila As ListViewItem

    Private Sub Buscar()
        Dim dsTabla As New Data.DataSet
        lvTabla.Items.Clear()
        dsTabla = objServicio.Buscar(1, txtBuscar.Text)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Abreviatura"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Activo"))
        Next
    End Sub
    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As String)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        Oper = 1
        cboActivo.Text = "SI"
        txtDescripcion.Select()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ControlesAD(Me, False)
        Limpiar(Me)
        Botones(True, False, False, True)
        txtBuscar.Enabled = True
        Buscar()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Guardar los Datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objServicio.Mantenimiento(CodLocal, txtDescripcion.Text, txtAbreviatura.Text, cboActivo.Text, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub
    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de Eliminar el Registro", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objServicio.Mantenimiento(CodLocal, txtDescripcion.Text, txtAbreviatura.Text, cboActivo.Text, 3)
            End If
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.Items.Count > 0 And lvTabla.SelectedItems.Count > 0 Then
            CodLocal = lvTabla.SelectedItems(0).SubItems(0).Text
            txtDescripcion.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            txtAbreviatura.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            cboActivo.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            Oper = 2
            ControlesAD(Me, True)
            Botones(False, True, True, False)
        End If

    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        Buscar()
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If txtDescripcion.Text <> "" And e.KeyCode = Keys.Enter Then txtAbreviatura.Select()
    End Sub

    Private Sub txtAbreviatura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAbreviatura.KeyDown
        If txtAbreviatura.Text <> "" And e.KeyCode = Keys.Enter Then cboActivo.Select()
    End Sub

    Private Sub cboActivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboActivo.KeyDown
        If e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub frmServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub
End Class
