Public Class frmNuevoProcedimiento
    Dim objProcedimiento As New Procedimientos
    Dim CodLocal As String
    Dim Oper As String

    Private Sub Buscar()
        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objProcedimiento.ItemServicio_Buscar(txtFiltro.Text)
        Dim Fila As ListViewItem
        Dim I As Integer
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("Id"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Actividad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Factor"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Activo").ToString)
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

    Private Sub frmNuevoProcedimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        txtDes.Enabled = False
        txtFactor.Enabled = False
        txtDes.Text = ""
        txtFactor.Text = ""
        Botones(True, False, False, True)
        Buscar()
    End Sub

    Private Sub lstLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLista.SelectedIndexChanged
        If lstLista.SelectedIndex < 6 Then
            txtFactor.Text = lstLista.SelectedIndex + 1
        Else
            txtFactor.Text = lstLista.SelectedIndex + 2
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim Activo As String
        If chkActivo.Checked Then Activo = 1 Else Activo = 0
        objProcedimiento.ItemServicio_Grabar(CodLocal, txtDes.Text, txtFactor.Text, Activo, Oper)
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, False, True, False)
        txtDes.Enabled = True
        chkActivo.Checked = True
        txtFactor.Enabled = True
        Oper = 1
        txtDes.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        If lvDet.Items.Count > 0 Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items.Item(I).Selected Then
                    CodLocal = lvDet.Items.Item(I).SubItems(0).Text
                    txtDes.Text = lvDet.Items.Item(I).SubItems(1).Text
                    txtFactor.Text = lvDet.Items.Item(I).SubItems(2).Text
                    Botones(False, True, True, False)
                    txtDes.Enabled = True
                    txtFactor.Enabled = True
                    Oper = 2
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And txtFactor.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub

    Private Sub txtFactor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFactor.TextChanged
        If txtDes.Text <> "" And txtFactor.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub
End Class