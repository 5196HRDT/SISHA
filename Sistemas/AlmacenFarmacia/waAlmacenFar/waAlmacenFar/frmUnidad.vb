Public Class frmUnidad
    Dim objUnidad As New Unidad
    Dim CodLocal As String
    Dim Oper As String

    Private Sub Buscar()
        lvDet.Items.Clear()
        Dim dsVer As Data.DataSet
        dsVer = objUnidad.Buscar(txtFiltro.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsVer.Tables(0).Rows(I)("IdUnidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        txtFiltro.Enabled = True
        Buscar()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Activar(Me, True)
        Botones(False, True, True, False)
        txtDescripcion.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objUnidad.Grabar(CodLocal, txtDescripcion.Text, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDet.Click
        If lvDet.Items.Count > 0 And lvDet.SelectedItems.Count > 0 Then
            Oper = 2
            CodLocal = lvDet.SelectedItems(0).SubItems(0).Text
            lblCodigo.Text = lvDet.SelectedItems(0).SubItems(0).Text
            txtDescripcion.Text = lvDet.SelectedItems(0).SubItems(1).Text
            Activar(Me, True)
            Botones(False, True, True, False)
        End If
    End Sub

    Private Sub frmUnidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub
End Class