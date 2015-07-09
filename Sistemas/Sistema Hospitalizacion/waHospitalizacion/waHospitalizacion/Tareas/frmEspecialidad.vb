Public Class frmEspecialidad
    Dim objEspecialidad As New Especialidad
    Dim objServicio As New Servicio
    Dim objSubServicio As New SubServicio

    Dim Oper As Integer
    Dim CodLocal As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Buscar()
        If IsNumeric(cboSubServicio.SelectedValue) Then
            lvTabla.Items.Clear()
            Dim dsSubServicio As New DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            dsSubServicio = objEspecialidad.Buscar(cboSubServicio.SelectedValue)
            For I = 0 To dsSubServicio.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsSubServicio.Tables(0).Rows(I)("IdEspecialidad"))
                Fila.SubItems.Add(dsSubServicio.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsSubServicio.Tables(0).Rows(I)("Servicio"))
                Fila.SubItems.Add(dsSubServicio.Tables(0).Rows(I)("SubServicio"))
            Next
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmEspecialidad_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Servicio
        Dim dsServico As New DataSet
        dsServico = objServicio.Combo("")
        cboServicio.DataSource = dsServico.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdPiso"
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSS As New DataSet
            dsSS = objSubServicio.Combo(cboServicio.SelectedValue)
            cboSubServicio.DataSource = dsSS.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdSerHos"
        End If
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
        cboServicio.Select()
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If Not IsNumeric(cboServicio.SelectedValue) Then MessageBox.Show("Debe seleccionar un servicio válido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboServicio.Select() : Exit Sub
        If Not IsNumeric(cboSubServicio.SelectedValue) Then MessageBox.Show("Debe seleccionar un sub servicio válido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboSubServicio.Select() : Exit Sub
        If MessageBox.Show("Está seguro de grabar la información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objEspecialidad.Mantenimiento(CodLocal, cboSubServicio.SelectedValue, txtDescripcion.Text, Oper)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de anular la información", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objEspecialidad.Mantenimiento(CodLocal, 0, "", 3)
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
            Oper = 2
        End If
    End Sub

    Private Sub cboSubServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSubServicio.SelectedIndexChanged
        If cboSubServicio.Enabled Then Buscar()
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter And txtDescripcion.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged

    End Sub
End Class