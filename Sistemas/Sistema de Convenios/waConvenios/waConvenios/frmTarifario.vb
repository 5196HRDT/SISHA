Public Class frmTarifario
    Dim objProcedimiento As New Procedimientos
    Dim objTarifario As New ServicioItem
    Dim objTipoTarifa As New TipoTarifario
    Dim Oper As String
    Dim CodLocal As String
    Dim IdSubServicio As String

    Private Sub Botones(ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub BuscarTA()
        Dim Fila As ListViewItem
        Dim I As Integer
        Dim dsTabla As New Data.DataSet
        lvTA.Items.Clear()
        dsTabla = objProcedimiento.BuscarTarifarioComun(txtFiltroAct.Text)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTA.Items.Add(dsTabla.Tables(0).Rows(I)("IdServicioItem"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("IDITEM"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Procedimiento"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Precio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("IdSubServicio"))
        Next
    End Sub


    Private Sub Buscar()
        Dim Fila As ListViewItem
        Dim I As Integer
        Dim dsTabla As New Data.DataSet
        lvDet.Items.Clear()
        dsTabla = objProcedimiento.BuscarTarifarioCon(cboTipo.SelectedValue.ToString, txtFiltro.Text)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("IdServicioItem"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("IDITEM"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Procedimiento"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(I)("Precio")), "#0.00"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("IdSubServicio"))
        Next
    End Sub

    Private Sub frmCatalogoProcedimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dsCombo As New Data.DataSet
        dsCombo = objTipoTarifa.ComboConvenio
        cboTipo.DataSource = dsCombo.Tables(0)
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.ValueMember = "IdTipoTarifa"

        btnCancelar_Click(sender, e)

        cboTipo.Enabled = True

        BuscarTA()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Botones(False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        Buscar()
        cboTipo.Enabled = True
        txtFiltro.Enabled = True
        txtFiltroAct.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        'objTarifario.Mantenimiento(0, txtCodigo.Tag, txtCodigo.Text, cboTipo.SelectedValue.ToString, txtCosto.Text, "1", UsuarioSistema, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00", Date.Now.Minute), 4)
        If Oper = 1 Then
            objTarifario.Mantenimiento(0, txtCodigo.Tag, txtCodigo.Text, cboTipo.SelectedValue.ToString, txtCosto.Text, "1", UsuarioSistema, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00", Date.Now.Minute), Oper)
        Else
            objTarifario.Mantenimiento(txtCodigo.Tag, IdSubServicio, txtCodigo.Text, cboTipo.SelectedValue.ToString, txtCosto.Text, "1", UsuarioSistema, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00", Date.Now.Minute), Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Procedimiento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objTarifario.Mantenimiento(lvDet.SelectedItems(0).SubItems(0).Text, txtCodigo.Tag, txtCodigo.Text, cboTipo.SelectedValue.ToString, txtCosto.Text, "1", UsuarioSistema, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00", Date.Now.Minute), 3)
                btnCancelar_Click(sender, e)
            End If
        End If
        
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If IsNumeric(cboTipo.SelectedValue) Then Buscar()
    End Sub

    Private Sub txtFiltroAct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltroAct.TextChanged
        BuscarTA()
    End Sub

    Private Sub lvTA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTA.SelectedIndexChanged
        If lvTA.Items.Count > 0 And lvTA.SelectedItems.Count > 0 Then
            txtCodigo.Text = lvTA.SelectedItems(0).SubItems(1).Text
            txtCodigo.Tag = lvTA.SelectedItems(0).SubItems(4).Text
            txtNombre.Text = lvTA.SelectedItems(0).SubItems(2).Text

            Oper = 1
            Botones(True, True, False)
            ControlesAD(Me, True)
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        If lvDet.SelectedItems.Count > 0 Then
            Dim Fila As ListViewItem
            For Each Fila In lvDet.SelectedItems
                CodLocal = lvDet.SelectedItems(0).SubItems(0).Text
                txtCodigo.Tag = lvDet.SelectedItems(0).SubItems(0).Text
                txtCodigo.Text = lvDet.SelectedItems(0).SubItems(1).Text
                txtNombre.Text = lvDet.SelectedItems(0).SubItems(2).Text
                txtCosto.Text = lvDet.SelectedItems(0).SubItems(3).Text
                IdSubServicio = lvDet.SelectedItems(0).SubItems(4).Text
                Botones(True, True, False)
                ControlesAD(Me, True)
                Oper = 2
            Next
        End If
    End Sub
End Class
