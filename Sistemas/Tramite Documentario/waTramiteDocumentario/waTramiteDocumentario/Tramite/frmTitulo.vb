Public Class frmTitulo
    Dim Oper As String
    Dim objTitulo As New Titulo
    Dim CodLocal As String = ""

    Private Sub Buscar()
        Dim dsTab As New Data.DataSet
        dsTab = objTitulo.Buscar(txtFiltro.Text)
        lvTabla.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTab.Tables(0).Rows(I)("IdTitulo"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Iniciales"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Activo"))
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmTitulo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        chkActivo.Checked = True
        txtDescripcion.Select()
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.Items.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Departamento/Unidad", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                objTitulo.Mantenimiento(CodLocal, txtDescripcion.Text, txtIniciales.Text, "1", 3)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.Items.Count > 0 Then
            Oper = 2
            ControlesAD(Me, True)
            Botones(False, True, True, False)
            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                If lvTabla.Items(I).Selected Then
                    CodLocal = lvTabla.Items(I).SubItems(0).Text
                    txtDescripcion.Text = lvTabla.Items(I).SubItems(1).Text
                    txtIniciales.Text = lvTabla.Items(I).SubItems(2).Text
                    If lvTabla.Items(I).SubItems(3).Text = "1" Then chkActivo.Checked = True Else chkActivo.Checked = False
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        txtFiltro.Enabled = True
        Buscar()
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar Datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Activo As String
            If chkActivo.Checked Then Activo = "1" Else Activo = "0"
            objTitulo.Mantenimiento(CodLocal, txtDescripcion.Text, txtIniciales.Text, Activo, Oper)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter And txtDescripcion.Text <> "" Then txtIniciales.Select()
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub txtIniciales_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtIniciales.KeyDown
        If e.KeyCode = Keys.Enter And txtIniciales.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub txtIniciales_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIniciales.TextChanged

    End Sub
End Class