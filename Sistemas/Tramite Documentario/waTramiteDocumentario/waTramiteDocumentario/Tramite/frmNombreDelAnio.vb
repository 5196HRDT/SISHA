Public Class frmNombreDelAnio
    Dim Oper As String
    Dim objNombreDelAnio As New NombreDelAnio
    Dim CodLocal As String = ""

    Private Sub Buscar()
        Dim dsTab As New Data.DataSet
        dsTab = objNombreDelAnio.Buscar(txtFiltro.Text)
        lvTabla.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTab.Tables(0).Rows(I)("IdAnio"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Anio"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Detalle"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Activo"))
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmNombreDelAnio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        chkActivo.Checked = True
        TxtAnio.Select()
    End Sub

    Private Sub lvTabla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTabla.Click
        If lvTabla.Items.Count > 0 Then
            Oper = 2
            ControlesAD(Me, True)
            Botones(False, True, True, False)
            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                If lvTabla.Items(I).Selected Then
                    CodLocal = lvTabla.Items(I).SubItems(0).Text
                    TxtAnio.Text = lvTabla.Items(I).SubItems(1).Text
                    txtDetalle.Text = lvTabla.Items(I).SubItems(2).Text
                    If lvTabla.Items(I).SubItems(2).Text = "1" Then chkActivo.Checked = True Else chkActivo.Checked = False
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        txtFiltro.Enabled = True
        Buscar()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar Datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Activo As String
            If chkActivo.Checked Then Activo = "1" Else Activo = "0"
            objNombreDelAnio.Mantenimiento(CodLocal, TxtAnio.Text, txtDetalle.Text, Activo, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.Items.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Nombre del A�o", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                objNombreDelAnio.Mantenimiento(CodLocal, TxtAnio.Text, txtDetalle.Text, "1", 3)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub TxtAnio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAnio.KeyDown
        If e.KeyCode = Keys.Enter Then txtDetalle.Select()
    End Sub

    Private Sub TxtAnio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAnio.TextChanged

    End Sub

    Private Sub txtDetalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDetalle.TextChanged

    End Sub

    Private Sub btnNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnNuevo.KeyDown
        If e.KeyCode = Keys.Enter Then TxtAnio.Select()
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub
End Class