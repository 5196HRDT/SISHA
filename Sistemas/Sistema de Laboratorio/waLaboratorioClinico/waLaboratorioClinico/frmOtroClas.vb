Public Class frmOtroClas
    Dim objAnalisis As New AnalisisInternosLab
    Dim CodLocal As String
    Dim Oper As String

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objAnalisis.Buscar(txtFiltro.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("IdAnalisis"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("ClasLaboratorio"))
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmLinea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, False, True, False)
        ControlesAD(Me, True)
        Oper = 1
        txtDes.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de grabar los datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objAnalisis.Mantenimiento(CodLocal, txtDes.Text, cboClas.Text, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ControlesAD(Me, False)
        Limpiar(Me)
        Botones(True, False, False, True)
        txtFiltro.Enabled = True
        txtFiltro.Select()
        Buscar()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            lvTabla.Select()
            lvTabla.Items(0).Selected = True
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.Items.Count > 0 Then
            If MessageBox.Show("Esta seguro de Eliminar los Datos", "Mensaje de Consulta", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                objAnalisis.Mantenimiento(lvTabla.SelectedItems(0).SubItems(0).Text, "", "", 3)
            End If
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

        btnNuevo.Enabled = False
        If lvTabla.Items.Count > 0 Then
            Oper = 2
            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                ControlesAD(Me, True)
                If lvTabla.Items(I).Selected Then
                    CodLocal = lvTabla.Items(I).SubItems(0).Text
                    txtDes.Text = lvTabla.Items(I).SubItems(1).Text
                    cboClas.Text = lvTabla.Items(I).SubItems(2).Text
                    Botones(False, True, True, False)
                End If
            Next
        End If
    End Sub

    Private Sub cboClas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClas.SelectedIndexChanged
        If txtDes.Text <> "" And cboClas.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And cboClas.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub
End Class