Public Class frmControlDonante
    Dim objContro As New ControlDonacion

    Private Sub frmControlDonante_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtDNI.Select()
    End Sub

    Private Sub txtDNI_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyDown
        If e.KeyCode = Keys.Enter And txtDNI.Text.Length = 8 Then
            lvTabla.Items.Clear()
            Dim dsTab As New DataSet
            dsTab = objContro.Buscar(txtDNI.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsTab.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsTab.Tables(0).Rows(I)("Fecha"))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdControl"))
            Next
            btnGrabar.Select()
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If txtDNI.Text.Length = 8 Then
            If MessageBox.Show("Esta seguro de grabar información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objContro.Grabar(txtDNI.Text, dtpFecha.Value.ToShortDateString)
                MessageBox.Show("Datos Grabados Satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDNI.Text = ""
                dtpFecha.Select()
                lvTabla.Items.Clear()
            End If
        End If
    End Sub

    Private Sub txtDNI_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub lvTabla_DoubleClick(sender As Object, e As System.EventArgs) Handles lvTabla.DoubleClick
        If MessageBox.Show("Esta seguro de Eliminar Fecha de Donación?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objContro.Eliminar(lvTabla.SelectedItems(0).SubItems(1).Text)
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
            dtpFecha.Select()
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub
End Class