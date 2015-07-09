Public Class frmServiArea
    Dim Oper As String
    Dim Activo As String
    Dim objDptoUnidad As New DptoUnidad
    Dim objServiArea As New ServiArea
    Dim CodLocal As String = ""

    Private Sub Buscar()
        Dim dsTab As New Data.DataSet
        dsTab = objServiArea.Buscar(txtFiltro.Text)
        lvTabla.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTab.Tables(0).Rows(I)("IdServiArea"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DptoUnidad").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sigla"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Activo"))
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

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        chkActivo.Checked = True
        cboDptoUnidad.Select()
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
            If chkActivo.Checked Then Activo = "1" Else Activo = "0"
            objServiArea.Mantenimiento(CodLocal, cboDptoUnidad.SelectedValue.ToString, TxtServiArea.Text, TxtSiglas.Text, Activo, Oper)
        End If
        btnCancelar_Click(sender, e)
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
                    cboDptoUnidad.Text = lvTabla.Items(I).SubItems(1).Text
                    TxtServiArea.Text = lvTabla.Items(I).SubItems(2).Text
                    TxtSiglas.Text = lvTabla.Items(I).SubItems(3).Text
                    If lvTabla.Items(I).SubItems(4).Text = "1" Then chkActivo.Checked = True Else chkActivo.Checked = False
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.Items.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Servicio/Area", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                'objServiArea.Mantenimiento(CodLocal, cboDptoUnidad.SelectedValue.ToString, TxtServiArea.Text, TxtSiglas.Text, Activo, 3)
                objServiArea.Mantenimiento(CodLocal, cboDptoUnidad.SelectedValue.ToString, TxtServiArea.Text, TxtSiglas.Text, "1", 3)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub cboDptoUnidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDptoUnidad.KeyDown
        If e.KeyCode = Keys.Enter Then TxtServiArea.Select()
    End Sub

    Private Sub frmServiArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        'Llenar DptoUnidad
        Dim dsDptoUnidad As New Data.DataSet
        dsDptoUnidad = objDptoUnidad.Buscar("")
        cboDptoUnidad.DataSource = dsDptoUnidad.Tables(0)
        cboDptoUnidad.DisplayMember = "Descripcion"
        cboDptoUnidad.ValueMember = "IdDptoUnidad"
    End Sub

    Private Sub TxtServiArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtServiArea.KeyDown
        If e.KeyCode = Keys.Enter Then TxtSiglas.Select()
    End Sub

    Private Sub TxtSiglas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSiglas.KeyDown
        If e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub
End Class