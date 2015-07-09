Public Class frmNumeracionOficina
    Dim objNumeracion As New Numeracion
    Dim objTipoDocumento As New TipoDocumento
    Dim objTrabajador As New Trabajador
    Dim objAsignacionCargo As New clsAsignacionCargo
    Dim IdAsignacionCargo As String

    Dim Oper As Integer
    Dim IdNumeracion As Integer

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        ControlesAD(Me, False)
        Limpiar(Me)
    End Sub

    Private Sub frmNumeracionOficina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Llenar Tipo
        Dim dsTipo As New Data.DataSet
        dsTipo = objTipoDocumento.Buscar("")
        cboTipo.DataSource = dsTipo.Tables(0)
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.ValueMember = "IdTipoDocumento"

        'Cargos del Trabajador
        Dim dsAsignacionCargo As New Data.DataSet
        dsAsignacionCargo = objAsignacionCargo.CargoPorTrabajador(CodigoTrabajador)
        cboCargo.DataSource = dsAsignacionCargo.Tables(0)
        cboCargo.DisplayMember = "Cargo"
        cboCargo.ValueMember = "IdAsignacionCargo"
    End Sub

    Private Sub cboCargo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCargo.SelectedIndexChanged
        If IsNumeric(cboCargo.SelectedValue) Then
            Dim dsVer As New DataSet
            dsVer = objNumeracion.Verificar(txtAño.Text, cboCargo.SelectedValue, cboTipo.SelectedValue)
            If dsVer.Tables(0).Rows.Count > 0 Then
                Oper = 2
                IdNumeracion = dsVer.Tables(0).Rows(0)("IdNumeracion")
                txtNumero.Text = dsVer.Tables(0).Rows(0)("Numero")
            Else
                IdNumeracion = 0
                Oper = 1
                txtNumero.Text = ""
            End If
        End If
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If IsNumeric(cboTipo.SelectedValue) Then
            Dim dsVer As New DataSet
            dsVer = objNumeracion.Verificar(txtAño.Text, cboCargo.SelectedValue, cboTipo.SelectedValue)
            If dsVer.Tables(0).Rows.Count > 0 Then
                Oper = 2
                IdNumeracion = dsVer.Tables(0).Rows(0)("IdNumeracion")
                txtNumero.Text = dsVer.Tables(0).Rows(0)("Numero")
            Else
                IdNumeracion = 0
                Oper = 1
                txtNumero.Text = ""
            End If
        End If
    End Sub

    Private Sub cboTipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.Click
        cboTipo_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        objNumeracion.Mantenimiento(IdNumeracion, cboTipo.SelectedValue, cboCargo.SelectedValue, txtAño.Text, txtNumero.Text, Oper)
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        txtAño.Text = Date.Now.Year
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboTipo.Select()

        'Buscar Trabajador
        Dim dsTrabajador As New DataSet
        dsTrabajador = objTrabajador.BuscarID(CodigoTrabajador)
        If dsTrabajador.Tables(0).Rows.Count > 0 Then
            lblDptoUnd.Text = dsTrabajador.Tables(0).Rows(0)("DptoUnid")
            lblServArea.Text = dsTrabajador.Tables(0).Rows(0)("ServArea")
            lblTrabajador.Text = dsTrabajador.Tables(0).Rows(0)("Nombre")
        End If
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboTipo.SelectedValue) Then txtAño.Select()
    End Sub

    Private Sub txtAño_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAño.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtAño.Text) Then txtNumero.Select()
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtNumero.Text) Then btnGrabar.Select()
    End Sub
End Class