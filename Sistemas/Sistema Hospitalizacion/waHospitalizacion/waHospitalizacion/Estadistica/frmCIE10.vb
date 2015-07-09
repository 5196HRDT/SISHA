Public Class frmCIE10
    Dim objCIE10 As New CIE10

    Dim Oper As Integer

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        lvTabla.Items.Clear()
        Botones(True, False, False, True)
        Limpiar(Me)
        Activar(Me, False)
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        Activar(Me, True)
        txtCIE10.Select()
        cboActivo.Text = "SI"
        cboEmergencia.Text = "SI"
        Oper = 1
    End Sub

    Private Sub txtCIE10_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCIE10.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE10.Text <> "" Then txtDescripcion.Select()
    End Sub

    Private Sub txtCIE10_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCIE10.TextChanged

    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter And txtDescripcion.Text <> "" Then cboDefinitivo.Select()
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub cboDefinitivo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboDefinitivo.KeyDown
        If e.KeyCode = Keys.Enter And cboDefinitivo.Text <> "" Then cboActivo.Select()
    End Sub

    Private Sub cboDefinitivo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDefinitivo.SelectedIndexChanged

    End Sub

    Private Sub cboActivo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboActivo.KeyDown
        If e.KeyCode = Keys.Enter And cboActivo.Text <> "" Then cboEmergencia.Select()
    End Sub

    Private Sub cboActivo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboActivo.SelectedIndexChanged

    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de grabar la información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objCIE10.Mantenimiento(txtCIE10.Tag, txtDescripcion.Text, txtCIE10.Text, cboDefinitivo.Text, cboActivo.Text, cboEmergencia.Text, cboPrioridadE.Text, cboPrioridadH.Text, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            Oper = 2
            txtCIE10.Tag = lvTabla.SelectedItems(0).SubItems(0).Text
            txtCIE10.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            txtDescripcion.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            cboDefinitivo.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            cboActivo.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            cboEmergencia.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            cboPrioridadE.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            cboPrioridadH.Text = lvTabla.SelectedItems(0).SubItems(7).Text
            Botones(False, True, True, False)
            Activar(Me, True)
        End If
    End Sub

    Private Sub frmCIE10_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            lvTabla.Items.Clear()
            Dim dsVer As New DataSet
            dsVer = objCIE10.BuscarFiltro(txtFiltro.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdCIE10"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("desc_enf"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Definitivo"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Activo"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Emergencia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("PrioridadE"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("PrioridadH"))
            Next
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged
        
    End Sub

    Private Sub cboEmergencia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEmergencia.KeyDown
        If e.KeyCode = Keys.Enter And cboEmergencia.Text <> "" Then cboPrioridadE.Select()
    End Sub

    Private Sub cboEmergencia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEmergencia.SelectedIndexChanged

    End Sub

    Private Sub cboPrioridadE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPrioridadE.KeyDown
        If e.KeyCode = Keys.Enter Then cboPrioridadH.Select()
    End Sub

    Private Sub cboPrioridadE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrioridadE.SelectedIndexChanged

    End Sub

    Private Sub cboPrioridadH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPrioridadH.KeyDown
        If e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub cboPrioridadH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrioridadH.SelectedIndexChanged

    End Sub
End Class