Public Class frmBuscarTrabajador
    Dim objTrabajador As New Trabajador
    Dim I As Integer
    Dim Fila As New ListViewItem

    Private Sub txtConCopiaFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConCopiaFiltro.TextChanged
        If txtConCopiaFiltro.Text = "" Then
            gbBuscarConCopiaA.Visible = False
            'txtConCopiaA.Select()
            'txtConCopiaA.Text = ""
        Else
            Dim dsTrabajador As DataSet
            lvConCopiaAFiltro.Items.Clear()
            dsTrabajador = objTrabajador.BuscarParaEnvio(txtConCopiaFiltro.Text)
            For Me.I = 0 To dsTrabajador.Tables(0).Rows.Count - 1
                Fila = lvConCopiaAFiltro.Items.Add(dsTrabajador.Tables(0).Rows(I)("IdAsignacionCargo"))
                Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("IdTrabajador"))
                Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("Trabajador"))
                Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("Cargo"))
            Next
        End If
    End Sub

    Private Sub lvConCopiaAFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvConCopiaAFiltro.KeyDown
        'If e.KeyCode = Keys.Enter And lvConCopiaAFiltro.SelectedItems.Count > 0 Then
        '    Fila = lvConCopiaA.Items.Add(lvConCopiaAFiltro.SelectedItems(0).SubItems(0).Text)
        '    Fila.SubItems.Add(lvConCopiaAFiltro.SelectedItems(0).SubItems(1).Text)
        '    Fila.SubItems.Add(lvConCopiaAFiltro.SelectedItems(0).SubItems(2).Text)
        '    Fila.SubItems.Add(lvConCopiaAFiltro.SelectedItems(0).SubItems(3).Text)
        '    lvConCopiaAFiltro.Items.Clear()
        '    gbBuscarConCopiaA.Visible = False
        '    txtConCopiaA.Text = ""
        '    txtConCopiaA.Select()
        'End If
    End Sub
End Class