Public Class frmCargo
    Dim objCargo As New Cargo
    Dim Oper As String
    Dim CodLocal As String

    Private Sub Buscar()
        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objCargo.Buscar("Select * From CQCargo Order By Descripcion")
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("IdCargo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
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

    Private Sub frmCargo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        Buscar()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        txtDes.Select()
        Oper = 1
        Botones(False, False, True, False)
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If txtDes.Text.Length > 0 And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text.Length > 0 Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de grabar los datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objCargo.Grabar(CodLocal, txtDes.Text, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        If lvDet.Items.Count > 0 Then
            CodLocal = lvDet.SelectedItems(0).Text
            txtDes.Text = lvDet.SelectedItems(1).Text
            Oper = 2
            Botones(False, True, True, False)
        End If
    End Sub
End Class