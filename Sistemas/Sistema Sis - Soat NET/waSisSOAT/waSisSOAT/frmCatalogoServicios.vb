Public Class frmCatalogoServicios
    Dim objTarifario As New Tarifario
    Dim TipoTarifa As String
    Dim objDep As New Departamento
    Dim objSubDep As New SubDepartamento
    Dim objProcedimiento As New Procedimientos
    Dim Modificar As Boolean
    Dim IdServicioItem As String

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblCodServicio.Text = ""
        lblCodSubServicio.Text = ""
        lblDepartamento.Text = ""
        lblServicio.Text = ""
        lblTipoTarifa.Text = Catalogo
        txtPrecio.Text = ""
        btnGrabar.Enabled = False
        Modificar = False
    End Sub

    Private Sub txtPrecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecio.KeyDown
        If IsNumeric(txtPrecio.Text) And Val(txtPrecio.Text) > 0 And IsNumeric(cboServicio.SelectedValue) And e.KeyCode = Keys.Enter Then
            btnGrabar.Enabled = True
            btnGrabar.Select()
        Else
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub txtPrecio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecio.TextChanged
        
    End Sub

    Private Sub frmCatalogoServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Departamento
        Dim dsDep As New Data.DataSet
        dsDep = objDep.Combo
        cboDep.DataSource = dsDep.Tables(0)
        cboDep.DisplayMember = "Nombre"
        cboDep.ValueMember = "IdOrigenServicio"

        'Servicio
        Dim dsEsp As New Data.DataSet
        dsEsp = objTarifario.ObtenerServicio("%")
        cboServicio.DataSource = dsEsp.Tables(0)
        cboServicio.DisplayMember = "Actividad"
        cboServicio.ValueMember = "IDITEM"
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub VerificarCatalogo()
        If Catalogo = "SIS" Then TipoTarifa = 12 Else TipoTarifa = 4
        Dim dsTabla As New Data.DataSet
        dsTabla = objTarifario.Tarifario_BuscarDepSer(cboServicio.SelectedValue, TipoTarifa, 2)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            If MessageBox.Show("Procedimiento ya fue registrado" & Chr(13) & "Desea Modificar el Precio?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Modificar = True
                IdServicioItem = dsTabla.Tables(0).Rows(0)("IdServicioItem")
                txtPrecio.Text = dsTabla.Tables(0).Rows(0)("Precio")
                txtPrecio.Select()
            End If
        Else
            txtPrecio.Text = ""
            txtPrecio.Select()
        End If
    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboServicio.SelectedValue) Then txtPrecio.Select()
    End Sub

    Private Sub cboServicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.LostFocus
        cboServicio_SelectedIndexChanged(sender, e)
        VerificarCatalogo()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objTarifario.Tarifario_BuscarDepSer(cboServicio.SelectedValue.ToString, 12, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                lblCodServicio.Text = dsTabla.Tables(0).Rows(0)("IdOrigenServicio")
                lblDepartamento.Text = dsTabla.Tables(0).Rows(0)("Servicio")
                lblCodSubServicio.Text = dsTabla.Tables(0).Rows(0)("IdSubServicios")
                lblServicio.Text = dsTabla.Tables(0).Rows(0)("SubServicio")
            End If
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Guardar los Datos", "Mensaje de Consulta", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If Not Modificar Then
                objTarifario.GuardarServicioItem(lblCodSubServicio.Text, cboServicio.SelectedValue, TipoTarifa, txtPrecio.Text, "SIS")
            Else
                objTarifario.GuardarModTarifa(IdServicioItem, lblCodSubServicio.Text, cboServicio.SelectedValue, TipoTarifa, txtPrecio.Text, "SIS")
            End If
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboDep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDep.SelectedIndexChanged
        If IsNumeric(cboDep.SelectedValue) Then
            lblCodServicio.Text = cboDep.SelectedValue
            'Sub Departamento
            Dim dsSubDep As New Data.DataSet
            dsSubDep = objSubDep.Combo(lblCodServicio.Text)
            cboSubDep.DataSource = dsSubDep.Tables(0)
            cboSubDep.DisplayMember = "Descripcion"
            cboSubDep.ValueMember = "IdSubServicios"
        End If
    End Sub
End Class