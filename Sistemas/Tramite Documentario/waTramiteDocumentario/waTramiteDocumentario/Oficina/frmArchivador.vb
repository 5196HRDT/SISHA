Public Class frmArchivador
    Dim objTrabajador As New Trabajador
    Dim objAsignacionCargo As New clsAsignacionCargo
    Dim objArchivador As New Archivador
    Dim IdArchivador As Integer

    Dim Oper As Integer
    Dim I As Integer
    Dim activo As String

    Dim Fila As New ListViewItem

    Public Sub Buscar()
        lvBuscar.Items.Clear()
        Dim dsArchivador As New Data.DataSet
        dsArchivador = objArchivador.Buscar(txtDescripcion.Text)
        For Me.I = 0 To dsArchivador.Tables(0).Rows.Count - 1
            Fila = lvBuscar.Items.Add(dsArchivador.Tables(0).Rows(I)("IdArchivador"))
            Fila.SubItems.Add(dsArchivador.Tables(0).Rows(I)("IdAsignacionCargo"))
            Fila.SubItems.Add(dsArchivador.Tables(0).Rows(I)("Cargo"))
            Fila.SubItems.Add(dsArchivador.Tables(0).Rows(I)("Archivador"))
            Fila.SubItems.Add(dsArchivador.Tables(0).Rows(I)("Periodo"))
            Fila.SubItems.Add(dsArchivador.Tables(0).Rows(I)("Activo"))
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Botones(False, True, True, False)
        ControlesAD(Me, True)

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        'Buscar Trabajador
        Dim dsTrabajador As New DataSet
        dsTrabajador = objTrabajador.BuscarID(CodigoTrabajador)
        If dsTrabajador.Tables(0).Rows.Count > 0 Then
            lblTrabajador.Text = dsTrabajador.Tables(0).Rows(0)("Nombre")
        End If

        'Cargos del Trabajador
        Dim dsAsignacionCargo As New Data.DataSet
        dsAsignacionCargo = objAsignacionCargo.CargoPorTrabajador(CodigoTrabajador)
        cboCargo.DataSource = dsAsignacionCargo.Tables(0)
        cboCargo.DisplayMember = "Cargo"
        cboCargo.ValueMember = "IdAsignacionCargo"

        Botones(True, False, False, True)
        ControlesAD(Me, False)
        Limpiar(Me)
        txtDescripcion.Clear()
        txtAño.Clear()
        cboCargo.SelectedIndex = -1
        cboCargo.Select()
        chkbActivo.Checked = True
        Buscar()
    End Sub

    Private Sub frmArchivador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If chkbActivo.Checked = True Then
            activo = "SI"
        Else
            If chkbActivo.Checked = False Then
                activo = "NO"
            End If
        End If

        If txtDescripcion.Text = "" Then
            MessageBox.Show("Debe ingresar un nombre para el Archivador", "Mensaje de Información", MessageBoxButtons.OK)
            txtDescripcion.Select()
        Else
            If txtAño.Text = "" Then
                MessageBox.Show("Debe ingresar un año para el Archivador", "Mensaje de Información", MessageBoxButtons.OK)
                txtAño.Select()
            Else
                'CREAR ARCHIVADOR
                If Oper = 1 Then
                    If MessageBox.Show("¿Esta seguro de guardar los datos?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        objArchivador.Mantenedor(IdArchivador, cboCargo.SelectedValue, txtDescripcion.Text, txtAño.Text, activo, Oper)
                    End If
                End If
                'MODIFICAR ARCHIVADO
                If Oper = 2 Then
                    If MessageBox.Show("¿Esta seguro de modificar los datos?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        objArchivador.Mantenedor(IdArchivador, cboCargo.SelectedValue, txtDescripcion.Text, txtAño.Text, activo, Oper)
                    End If
                End If
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtAño_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAño.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAño_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAño.TextChanged
        txtAño.MaxLength = 4
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        If lvBuscar.SelectedItems.Count > 0 Then
            Oper = 2
            Botones(False, True, True, False)
            ControlesAD(Me, True)
            IdArchivador = lvBuscar.SelectedItems(0).SubItems(0).Text
            cboCargo.Text = lvBuscar.SelectedItems(0).SubItems(2).Text
            txtDescripcion.Text = lvBuscar.SelectedItems(0).SubItems(3).Text
            txtAño.Text = lvBuscar.SelectedItems(0).SubItems(4).Text
            activo = lvBuscar.SelectedItems(0).SubItems(5).Text
            If activo = "SI" Then
                chkbActivo.Checked = True
            Else
                chkbActivo.Checked = False
            End If
        End If
    End Sub
End Class