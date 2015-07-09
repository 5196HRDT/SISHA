Public Class frmServicio
    Dim objServicio As New Servicio

    Dim Oper As Integer
    Dim CodLocal As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsServicio As New DataSet
        Dim I As Integer
        Dim Fila As ListViewItem
        dsServicio = objServicio.Combo("")
        For I = 0 To dsServicio.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsServicio.Tables(0).Rows(I)("IdPiso"))
            Fila.SubItems.Add(dsServicio.Tables(0).Rows(I)("Descripcion"))
        Next
    End Sub


    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmServicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        Limpiar(Me)
        Activar(Me, False)
        Buscar()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        txtDescripcion.Select()
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter And txtDescripcion.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Está seguro de grabar la información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objServicio.Guardar(CodLocal, txtDescripcion.Text, Oper)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de anular la información", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objServicio.Anular(CodLocal)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            CodLocal = lvTabla.SelectedItems(0).SubItems(0).Text
            txtDescripcion.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            Botones(False, True, True, False)
            Activar(Me, True)
        End If
    End Sub
End Class