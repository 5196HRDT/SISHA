Public Class frmBuscarHistoria
    Dim objHistoria As New Historia

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If txtApaterno.Text = "" And txtAMaterno.Text = "" And txtNombres.Text = "" Then Exit Sub
        Dim dsTabla As New Data.DataSet
        dsTabla = objHistoria.BuscarNombres(txtApaterno.Text, txtAMaterno.Text, txtNombres.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            dgTabla.DataSource = dsTabla.Tables(0)
        Else
            MessageBox.Show("No existen coincidencias de busqueda", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgTabla.DataSource = dsTabla.Tables(0)
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dgTabla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTabla.DoubleClick
        NumeroHistoria = dgTabla.Item(0, dgTabla.CurrentRow.Index).Value
        Me.Close()
    End Sub

    Private Sub dgTabla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub dgTabla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgTabla.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If dgTabla.RowCount > 0 Then
                NumeroHistoria = dgTabla.Item(0, dgTabla.CurrentRow.Index).Value
                Me.Close()
            End If
        End If
    End Sub
End Class