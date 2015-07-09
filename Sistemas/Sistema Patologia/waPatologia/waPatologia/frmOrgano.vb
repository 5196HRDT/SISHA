Public Class frmOrgano
    Dim objOrgano As New clsOrgano

    Dim I As Integer
    Dim Fila As ListViewItem

    Dim Oper As Integer
    Dim CodLocal As String

    Private Sub Buscar(ByVal Filtro As String)
        lvTabla.Items.Clear()
        Dim dsTabla As New DataSet
        Dim Activo As String
        dsTabla = objOrgano.Buscar(1, Filtro)
        For Me.I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("IdOrgano"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
            If dsTabla.Tables(0).Rows(I)("Activo") = 1 Then Activo = "SI" Else Activo = "NO"
            Fila.SubItems.Add(Activo)
        Next
    End Sub


    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmOrgano_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        txtFiltro.Enabled = True
        Buscar(txtFiltro.Text)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        chkActivo.Checked = True
        txtDescripcion.Select()
        Oper = 1
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If txtDescripcion.Text <> "" And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Guardar la Información", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Activo As String
            If chkActivo.Checked Then Activo = 1 Else Activo = 0
            objOrgano.Mantenimiento(CodLocal, txtDescripcion.Text, Activo, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar(txtFiltro.Text)
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        If txtDescripcion.Enabled Then Buscar(txtDescripcion.Text)
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            CodLocal = lvTabla.SelectedItems(0).SubItems(0).Text
            txtDescripcion.Enabled = False
            txtDescripcion.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            txtDescripcion.Enabled = True
            If lvTabla.SelectedItems(0).SubItems(2).Text = "SI" Then chkActivo.Checked = True Else chkActivo.Checked = False
            Oper = 2
            ControlesAD(Me, True)
            Botones(False, True, True, False)
        End If
    End Sub
End Class