Public Class frmCambioProg
    Dim objProgramacion As New Programacion

    Private Sub Buscar()
        If cboOrigenSala.Text = "" Then Exit Sub
        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objProgramacion.BuscarOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), 1, cboOrigenSala.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("Id"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Hora"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Serie"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Numero"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Exonerado"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("APaterno"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("AMaterno"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("FechaNac"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Operacion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Sala"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Anestesia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cirujano"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Origen"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TipoProgramacion"))
            If dsTabla.Tables(0).Rows(I)("Cambio").ToString <> "" Then Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cambio")) Else Fila.SubItems.Add("")
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboOrigenSala.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Buscar()
    End Sub

    Private Sub frmCambioProg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        txtCambio.Text = ""
        btnGrabar.Enabled = False
        Buscar()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Guardar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objProgramacion.GrabarCambio(lvDet.SelectedItems(0).SubItems(0).Text, txtCambio.Text)
        End If
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        If lvDet.Items.Count > 1 And lvDet.SelectedItems.Count > 0 Then
            lblHistoria.Text = lvDet.SelectedItems(0).SubItems(6).Text
            lblPaciente.Text = lvDet.SelectedItems(0).SubItems(7).Text & " " & lvDet.SelectedItems(0).SubItems(8).Text & " " & lvDet.SelectedItems(0).SubItems(9).Text
            txtCambio.Text = lvDet.SelectedItems(0).SubItems(19).Text
        End If
    End Sub

    Private Sub txtCambio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCambio.TextChanged
        If lblHistoria.Text <> "" And txtCambio.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub

    Private Sub cboOrigenSala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrigenSala.SelectedIndexChanged
        Buscar()
    End Sub
End Class