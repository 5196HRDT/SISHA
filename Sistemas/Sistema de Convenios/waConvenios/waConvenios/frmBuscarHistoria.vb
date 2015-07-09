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
        
    End Sub

    Private Sub frmBuscarHistoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtApaterno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApaterno.KeyDown
        If e.KeyCode = Keys.Enter Then txtAMaterno.Select()
    End Sub

    Private Sub txtApaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApaterno.TextChanged

    End Sub

    Private Sub txtAMaterno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAMaterno.KeyDown
        If e.KeyCode = Keys.Enter Then txtNombres.Select()
    End Sub

    Private Sub txtAMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAMaterno.TextChanged

    End Sub

    Private Sub txtNombres_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombres.KeyDown
        If e.KeyCode = Keys.Enter Then btnBuscar.Select()
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged

    End Sub

    Private Sub dgTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgTabla.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgTabla.RowCount > 0 Then
                NumeroHistoria = dgTabla.Item(0, dgTabla.CurrentRow.Index).Value
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If txtHistoria.Text = "" Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                dgTabla.DataSource = dsTabla.Tables(0)
            Else
                MessageBox.Show("No existen coincidencias de busqueda", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgTabla.DataSource = dsTabla.Tables(0)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub
End Class