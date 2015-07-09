Public Class frmServicio
    Dim objServicio As New Servicio

    Dim Oper As String
    Dim CodLocal As String

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
        dsTabla = objServicio.Buscar(txtFiltro.Text, 1)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Activo"))
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        Buscar()
        txtFiltro.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        objServicio.Mantenimiento(txtServicio.Tag, txtServicio.Text, cboActivo.Text, Oper)
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboActivo.Text = "SI"
        txtServicio.Select()
    End Sub

    Private Sub frmServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim Fila As ListViewItem
            If MessageBox.Show("Esta seguro de Eliminar Servicio", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For Each Fila In lvDet.SelectedItems
                    objServicio.Mantenimiento(lvDet.SelectedItems(0).SubItems(0).Text, "", "", 3)
                Next
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        If lvDet.SelectedItems.Count > 0 Then
            Dim Fila As ListViewItem
            For Each Fila In lvDet.SelectedItems
                txtServicio.Tag = lvDet.SelectedItems(0).SubItems(0).Text
                txtServicio.Text = lvDet.SelectedItems(0).SubItems(1).Text
                cboActivo.Text = lvDet.SelectedItems(0).SubItems(2).Text
                Botones(False, True, True, False)
                ControlesAD(Me, True)
                Oper = 2
            Next
        End If
    End Sub

    Private Sub txtServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtServicio.KeyDown
        If txtServicio.Text <> "" And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub txtServicio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServicio.TextChanged

    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub
End Class