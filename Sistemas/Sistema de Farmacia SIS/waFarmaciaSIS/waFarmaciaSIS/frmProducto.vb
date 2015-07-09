Public Class frmProducto
    Dim objProducto As New clsProductoFarmacia

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        lblBienServ.Text = ""
        lblClase.Text = ""
        lblCodigo.Text = ""
        lblGrupo.Text = ""
    End Sub

    Private Sub frmProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Unidad
        Dim dsUnidad As New DataSet
        dsUnidad = objProducto.Unidad
        cboUnidad.DataSource = dsUnidad.Tables(0)
        cboUnidad.DisplayMember = "Und"
        cboUnidad.ValueMember = "Und"
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        'Buscar Codigo
        Dim dsProducto As New DataSet
        dsProducto = objProducto.BuscarNroFormato
        If dsProducto.Tables(0).Rows.Count > 0 Then
            Dim Codigo As String
            Codigo = Val(dsProducto.Tables(0).Rows(0)("Codigo")) + 1
            lblCodigo.Text = Codigo
            lblGrupo.Text = dsProducto.Tables(0).Rows(0)("Grupo")
            lblClase.Text = dsProducto.Tables(0).Rows(0)("Clase")
            lblBienServ.Text = dsProducto.Tables(0).Rows(0)("Grupo") & "965" & Codigo
            cboUnidad.Select()
        End If
    End Sub

    Private Sub cboUnidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUnidad.KeyDown
        If cboUnidad.Text <> "" And e.KeyCode = Keys.Enter Then txtDescripcion.Select()
    End Sub

    Private Sub cboUnidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnidad.SelectedIndexChanged

    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter And txtDescripcion.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        lvTabla.Items.Clear()
        Dim dsP As New DataSet
        dsP = objProducto.Buscar(txtDescripcion.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsP.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsP.Tables(0).Rows(I)("BienServ"))
            Fila.SubItems.Add(dsP.Tables(0).Rows(I)("Grupo"))
            Fila.SubItems.Add(dsP.Tables(0).Rows(I)("Clase"))
            Fila.SubItems.Add(dsP.Tables(0).Rows(I)("Codigo"))
            Fila.SubItems.Add(dsP.Tables(0).Rows(I)("Und"))
            Fila.SubItems.Add(dsP.Tables(0).Rows(I)("Descripción"))
        Next
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboUnidad.Text = "" Then MessageBox.Show("Debe Seleccionar Unidad de Producto", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboUnidad.Select() : Exit Sub
        If txtDescripcion.Text = "" Then MessageBox.Show("Debe Ingresar Descripción de Producto", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDescripcion.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar Información de Producto?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objProducto.Grabar(lblBienServ.Text, lblGrupo.Text, lblClase.Text, lblCodigo.Text, txtDescripcion.Text, cboUnidad.Text, Date.Now, Date.Now.ToShortDateString)
            btnCancelar_Click(sender, e)
        End If
    End Sub
End Class