Public Class frmCentroSalud
    Dim objCentro As New CentroSalud
    Dim Oper As String

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
        dsTabla = objCentro.Filtrar(txtFiltro.Text)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("IdCentro"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion").ToString)
        Next
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        Buscar()
        txtFiltro.Enabled = True
    End Sub

    Private Sub frmCentroSalud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        txtCodigo.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Oper = "1" Then
            objCentro.Grabar(txtNombre.Text)
        Else
            objCentro.Modificar(txtCodigo.Text, txtNombre.Text)
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
                    objCentro.Eliminar(Fila.SubItems(0).Text)
                Next
                btnCancelar_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Insert Then
            Dim Fila As ListViewItem
            For Each Fila In lvDet.SelectedItems
                txtCodigo.Text = Fila.SubItems(0).Text
                txtNombre.Text = Fila.SubItems(1).Text
                Botones(False, True, True, False)
                ControlesAD(Me, True)
                txtNombre.Select()
                Oper = 2
            Next
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub
End Class