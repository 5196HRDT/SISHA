Public Class frmNumeracion
    Dim objDptoUnidad As New DptoUnidad
    Dim objserviArea As New ServiArea
    Dim objTrabajador As New Trabajador
    Dim objTipo As New TipoDocumento
    Dim objNumeracion As New Numeracion
    Dim CodLocal As String
    Dim Oper As String
    Dim I As Integer
    Dim Fila As ListViewItem

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmNumeracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Llenar DptoUnidad
        Dim dsDptoUnidad As New Data.DataSet
        dsDptoUnidad = objDptoUnidad.Buscar("")
        cboDpto.DataSource = dsDptoUnidad.Tables(0)
        cboDpto.DisplayMember = "Descripcion"
        cboDpto.ValueMember = "IdDptoUnidad"

        'Llenar Tipo
        Dim dsTipo As New Data.DataSet
        dsTipo = objTipo.Buscar("")
        cboTipo.DataSource = dsTipo.Tables(0)
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.ValueMember = "IdTipoDocumento"
    End Sub

    Private Sub cboDpto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDpto.KeyDown
        If IsNumeric(cboDpto.SelectedValue) And e.KeyCode = Keys.Enter Then cboServiArea.Select()
    End Sub

    Private Sub cboDpto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDpto.SelectedIndexChanged
        If IsNumeric(cboDpto.SelectedValue) Then
            'Llenar ServiArea
            Dim dsServiArea As New Data.DataSet
            dsServiArea = objServiArea.Combo(cboDpto.SelectedValue.ToString)
            cboServiArea.DataSource = dsServiArea.Tables(0)
            cboServiArea.DisplayMember = "Descripcion"
            cboServiArea.ValueMember = "IdServiArea"
        End If
    End Sub

    Private Sub cboServiArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServiArea.KeyDown
        If IsNumeric(cboServiArea.SelectedValue) And e.KeyCode = Keys.Enter Then cboTrabajador.Select()
    End Sub

    Private Sub cboServiArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServiArea.SelectedIndexChanged
        If IsNumeric(cboServiArea.SelectedValue) Then
            cboTrabajador.Text = ""
            'Llenar ServiArea
            Dim dsTrabajador As New Data.DataSet
            dsTrabajador = objTrabajador.BuscarTrabjador(cboServiArea.SelectedValue.ToString)
            cboTrabajador.DataSource = dsTrabajador.Tables(0)
            cboTrabajador.DisplayMember = "Nombres"
            cboTrabajador.ValueMember = "IdTrabajador"
        End If
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If lvTabla.SelectedItems.Count > 0 Then lvTabla.Select()
    End Sub

   
    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        lvTabla.Items.Clear()
        If txtFiltro.Text <> "" Then
            Dim dsNumeracion As New Data.DataSet
            dsNumeracion = objNumeracion.Buscar(txtFiltro.Text)
            For I = 0 To dsNumeracion.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsNumeracion.Tables(0).Rows(I)("IdNumeracion"))
                Fila.SubItems.Add(dsNumeracion.Tables(0).Rows(I)("DptoUni"))
                Fila.SubItems.Add(dsNumeracion.Tables(0).Rows(I)("ServiArea"))
                Fila.SubItems.Add(dsNumeracion.Tables(0).Rows(I)("Trabajador"))
                Fila.SubItems.Add(dsNumeracion.Tables(0).Rows(I)("Tipo"))
                Fila.SubItems.Add(dsNumeracion.Tables(0).Rows(I)("Año"))
                Fila.SubItems.Add(dsNumeracion.Tables(0).Rows(I)("Numero"))
                Fila.SubItems.Add(dsNumeracion.Tables(0).Rows(I)("Activo"))
            Next
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        txtFiltro.Text = ""
        txtFiltro.Enabled = True
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboDpto.Select()
        cboActivo.Text = "SI"
        Oper = 1
    End Sub

    Private Sub cboTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTrabajador.KeyDown
        If IsNumeric(cboTrabajador.SelectedValue) And e.KeyCode = Keys.Enter Then cboTipo.Select()
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If IsNumeric(cboTipo.SelectedValue) And e.KeyCode = Keys.Enter Then txtAño.Select()
    End Sub

    Private Sub txtAño_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAño.KeyDown
        If IsNumeric(txtAño.Text) And e.KeyCode = Keys.Enter Then txtNumero.Select()
    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If IsNumeric(txtNumero.Text) And e.KeyCode = Keys.Enter Then cboActivo.Select()
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            Oper = 2
            CodLocal = lvTabla.SelectedItems(0).SubItems(0).Text
            cboDpto.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            cboDpto_SelectedIndexChanged(sender, e)
            cboServiArea.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            cboServiArea_SelectedIndexChanged(sender, e)
            cboTrabajador.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            cboTipo.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            txtAño.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            txtNumero.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            cboActivo.Text = lvTabla.SelectedItems(0).SubItems(7).Text
            ControlesAD(Me, True)
            Botones(False, True, True, False)
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        'If MessageBox.Show("Esta seguro de grabar los datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    objNumeracion.Mantenimiento(CodLocal, cboTipo.SelectedValue, cboServiArea.SelectedValue, cboTrabajador.SelectedValue, txtAño.Text, txtNumero.Text, Oper)
        'End If
        'btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboActivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboActivo.KeyDown
        If cboActivo.Text <> "" And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub
End Class