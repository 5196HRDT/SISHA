Public Class frmFormatoInforme
    Dim objInforme As New clsFormatoInforme
    Dim objOrgano As New clsOrgano
    Dim objTipoMuestra As New clsTipoMuestraOrgano

    Dim I As Integer
    Dim Fila As ListViewItem

    Dim Oper As Integer
    Dim CodLocal As String

    Private Sub Buscar(ByVal Filtro As String)
        lvTabla.Items.Clear()
        Dim dsTabla As New DataSet
        dsTabla = objInforme.Buscar(Filtro)
        For Me.I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("IdFormato"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Nombre"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Organo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TipoMuestra"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cuerpo"))
        Next
    End Sub


    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmFormatoInforme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Organo
        Dim dsOrgano As New DataSet
        dsOrgano = objOrgano.Buscar(1, "")
        cboOrgano.DataSource = dsOrgano.Tables(0)
        cboOrgano.DisplayMember = "Descripcion"
        cboOrgano.ValueMember = "IdOrgano"

        'Tipo Muestra
        Dim dsTipoMuestra As New DataSet
        dsTipoMuestra = objTipoMuestra.Buscar(1, "")
        cboTipoMuestra.DataSource = dsTipoMuestra.Tables(0)
        cboTipoMuestra.DisplayMember = "Descripcion"
        cboTipoMuestra.ValueMember = "IdTipoMuestra"
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        txtNombre.Select()
        Oper = 1
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Guardar la Información", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objInforme.Mantenimiento(CodLocal, txtNombre.Text, cboOrgano.SelectedValue, cboTipoMuestra.SelectedValue, txtCuerpo.Rtf, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        txtCuerpo.Rtf = ""
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        txtFiltro.Enabled = True
        Buscar(txtFiltro.Text)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter And txtNombre.Text <> "" Then cboOrgano.Select()
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        If txtNombre.Enabled Then Buscar(txtFiltro.Text)
    End Sub

    Private Sub cboOrgano_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrgano.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboOrgano.SelectedValue) Then cboTipoMuestra.Select()
    End Sub

    Private Sub cboOrgano_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrgano.SelectedIndexChanged

    End Sub

    Private Sub cboTipoMuestra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoMuestra.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboTipoMuestra.SelectedValue) Then txtCuerpo.Select()
    End Sub

    Private Sub cboTipoMuestra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoMuestra.SelectedIndexChanged

    End Sub

    Private Sub btnFuente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFuente.Click
        'Todo el texto
        If txtCuerpo.SelectedText.Trim = "" Then
            Fuente.Font = txtCuerpo.Font
            Fuente.ShowDialog()
            txtCuerpo.Font = Fuente.Font
        Else
            Fuente.Font = txtCuerpo.SelectionFont
            Fuente.ShowDialog()
            txtCuerpo.SelectionFont = Fuente.Font
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar(txtFiltro.Text)
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            CodLocal = lvTabla.SelectedItems(0).SubItems(0).Text
            txtNombre.Enabled = False
            txtNombre.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            txtNombre.Enabled = True
            cboOrgano.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            cboTipoMuestra.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            txtCuerpo.Rtf = lvTabla.SelectedItems(0).SubItems(4).Text
            Oper = 2
            ControlesAD(Me, True)
            Botones(False, True, True, False)
        End If
    End Sub
End Class