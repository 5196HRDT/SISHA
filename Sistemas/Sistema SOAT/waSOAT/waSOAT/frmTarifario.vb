Public Class frmTarifario
    Dim objTarifario As New TarifarioSOAT
    Dim objTipoTarifario As New clsTipoTarifario
    Dim objSubTipo As New clsSubTipoTarifa
    Dim objItemServicio As New clsItemServicio
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
        dsTabla = objTarifario.BuscarFiltro(txtFiltro.Text)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("IdTarifario"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Codigo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(I)("Precio")), "#0.00"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Tipo").ToString)
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("SubTipo").ToString)
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("IdHRDT").ToString)
        Next
    End Sub

    Private Sub frmCatalogoProcedimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Tipo Tarifario
        Dim dsTT As New DataSet
        dsTT = objTipoTarifario.Combo
        cboTipo.DataSource = dsTT.Tables(0)
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.ValueMember = "IdTipo"

        'Item Servicio
        Dim dsItem As New DataSet
        dsItem = objItemServicio.ObtenerItemServicio("")
        cboHRDT.DataSource = dsItem.Tables(0)
        cboHRDT.DisplayMember = "Actividad"
        cboHRDT.ValueMember = "Id"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        Buscar()
        txtFiltro.Enabled = True
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        txtCodigo.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Oper = 1 Then
            objTarifario.Grabar(txtCodigo.Text, txtNombre.Text, txtCosto.Text, cboTipo.Text, cboSubtipo.Text, cboHRDT.SelectedValue)
        Else
            objTarifario.Modificar(CodLocal, txtCodigo.Text, txtNombre.Text, txtCosto.Text, cboTipo.Text, cboSubtipo.Text, cboHRDT.SelectedValue)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim Fila As ListViewItem
            If MessageBox.Show("Esta seguro de Eliminar Procedimiento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For Each Fila In lvDet.SelectedItems
                    objTarifario.Eliminar(Fila.SubItems(0).Text)
                Next
                btnCancelar_Click(sender, e)
            End If
        End If
        
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub lvDet_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        If lvDet.SelectedItems.Count > 0 Then
            cboTipo.Text = ""
            cboSubtipo.Text = ""
            CodLocal = lvDet.SelectedItems(0).SubItems(0).Text
            txtCodigo.Text = lvDet.SelectedItems(0).SubItems(1).Text
            txtNombre.Text = lvDet.SelectedItems(0).SubItems(2).Text
            txtCosto.Text = lvDet.SelectedItems(0).SubItems(3).Text
            cboTipo.Text = lvDet.SelectedItems(0).SubItems(4).Text
            cboTipo_SelectedIndexChanged(sender, e)
            cboSubtipo.Text = lvDet.SelectedItems(0).SubItems(5).Text
            If IsNumeric(lvDet.SelectedItems(0).SubItems(6).Text) Then
                Dim dsIS As New DataSet
                dsIS = objItemServicio.BuscarId(lvDet.SelectedItems(0).SubItems(6).Text)
                If dsIS.Tables(0).Rows.Count > 0 Then cboHRDT.Text = dsIS.Tables(0).Rows(0)("Actividad") Else cboHRDT.Text = ""
            Else
                cboHRDT.Text = ""
            End If

            Botones(False, True, True, False)
            ControlesAD(Me, True)
            Oper = 2
        End If
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If IsNumeric(cboTipo.SelectedValue) Then
            Dim dsST As New DataSet
            dsST = objSubTipo.Combo(cboTipo.SelectedValue)
            cboSubtipo.DataSource = dsST.Tables(0)
            cboSubtipo.DisplayMember = "Descripcion"
            cboSubtipo.ValueMember = "IdSubTipo"
        End If
    End Sub
End Class