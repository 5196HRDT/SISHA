Public Class frmSelMedSIS
    Dim objMed As New Medicamentos

    Dim I As Integer
    Dim Fila As ListViewItem

    Private Sub BuscarSIS()
        lvTabla.Items.Clear()
        Dim dsM As New Data.DataSet
        dsM = objMed.ObtenerMedicamentosSISUCI(txtFiltro.Text + "%", 1)
        For I = 0 To dsM.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsM.Tables(0).Rows(I)("IdListaPrecio"))
            Fila.SubItems.Add(dsM.Tables(0).Rows(I)("Descripcion"))
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmSelMedSIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsMed As New Data.DataSet
        dsMed = objMed.ObtenerMedicamentosSIS("%")
        cboMedicamento.DataSource = dsMed.Tables(0)
        cboMedicamento.DisplayMember = "Descripcion"
        cboMedicamento.ValueMember = "IdListaPrecio"

        BuscarSIS()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        BuscarSIS()
    End Sub

    Private Sub cboMedicamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMedicamento.KeyDown
        If IsNumeric(cboMedicamento.SelectedValue) And e.KeyCode = Keys.Enter Then
            objMed.AsignarQuitarSISUCI(cboMedicamento.SelectedValue, 1)
            MessageBox.Show("Medicamento Asignado Satisfactoriamente", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BuscarSIS()
        End If
    End Sub

    Private Sub cboMedicamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMedicamento.SelectedIndexChanged

    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.Items.Count > 0 And e.KeyCode = Keys.Delete Then
            objMed.AsignarQuitarSISUCI(lvTabla.SelectedItems(0).SubItems(0).Text, 2)
            MessageBox.Show("Medicamento Retirado Satisfactoriamente", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BuscarSIS()
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub
End Class