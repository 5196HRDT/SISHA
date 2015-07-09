Public Class frmClasificarTar
    Dim objItem As New ItemServicio

    Private Sub frmClasificarTar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboDes.DataSource = objItem.BuscarLaboratorio.Tables(0)
        cboDes.DisplayMember = "Actividad"
        cboDes.ValueMember = "Id"
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de asignar Clasificacion", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objItem.GrabarClasificacion(cboDes.SelectedValue, cboClas.Text)
        End If
    End Sub

    Private Sub cboDes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDes.KeyPress
        If IsNumeric(cboDes.SelectedItem) Then cboClas.Select()
    End Sub

    Private Sub cboDes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDes.SelectedIndexChanged

    End Sub

    Private Sub cboClas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboClas.KeyPress
        If cboClas.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub cboClas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClas.SelectedIndexChanged

    End Sub
End Class