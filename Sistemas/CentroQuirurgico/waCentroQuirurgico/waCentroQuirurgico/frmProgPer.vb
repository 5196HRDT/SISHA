Public Class frmProgPer
    Dim objProgPer As New ProgPer
    Dim objPersonal As New Personal
    Dim objCargo As New Cargo
    Dim objSala As New Sala
    Dim CodLocal As String
    Dim Oper As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Buscar()
        If cboOrigenSala.Text = "" Then Exit Sub

        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objProgPer.BuscarOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), cboOrigenSala.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("IdProgPer"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cargo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Personal"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Sala"))
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        Buscar()
    End Sub

    Private Sub frmProgPer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cargo
        Dim dsCargo As New Data.DataSet
        dsCargo = objCargo.Buscar("Select * From CQCargo")
        cboCargo.DataSource = dsCargo.Tables(0)
        cboCargo.DisplayMember = "Descripcion"
        cboCargo.ValueMember = "IdCargo"

        btnCancelar_Click(sender, e)
        dtpFecha.Value = Date.Now
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        dtpFecha.Select()
        Botones(False, False, True, False)
        Oper = 1
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de guardar la programacion", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objProgPer.Grabar(CodLocal, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), cboCargo.SelectedValue.ToString, cboPersonal.SelectedValue.ToString, cboSala.SelectedValue.ToString, Oper, cboOrigenSala.Text)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub cboCargo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCargo.KeyDown
        If e.KeyCode = Keys.Enter And cboCargo.Text <> "" Then cboPersonal.Select()
    End Sub

    Private Sub cboCargo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCargo.SelectedIndexChanged
        If IsNumeric(cboCargo.SelectedValue) Then
            Dim dsPersonal As New Data.DataSet
            dsPersonal = objPersonal.BuscarPersonal("Select * From CQPersonal Where IdCargo = " + cboCargo.SelectedValue.ToString + " And Activo='1' Order By Nombres")
            cboPersonal.DataSource = dsPersonal.Tables(0)
            cboPersonal.DisplayMember = "Nombres"
            cboPersonal.ValueMember = "IdPersonal"
        End If
    End Sub

    Private Sub cboPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPersonal.KeyDown
        If IsNumeric(cboPersonal.SelectedValue) And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub cboPersonal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPersonal.SelectedIndexChanged
        If IsNumeric(cboPersonal.SelectedValue) Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        If lvDet.Items.Count > 0 Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    CodLocal = lvDet.Items(I).SubItems(0).Text
                    dtpFecha.Value = lvDet.Items(I).SubItems(1).Text
                    cboCargo.Text = lvDet.Items(I).SubItems(2).Text
                    cboCargo_SelectedIndexChanged(sender, e)
                    cboPersonal.Text = lvDet.Items(I).SubItems(3).Text
                    cboSala.Text = lvDet.Items(I).SubItems(4).Text
                    Exit For
                End If
            Next
            Oper = 2
            Activar(Me, True)
            Botones(False, True, True, False)
        End If
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboOrigenSala.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Buscar()
    End Sub

    Private Sub cboOrigenSala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrigenSala.KeyDown
        If e.KeyCode = Keys.Enter And cboOrigenSala.Text <> "" Then cboSala.Select()
    End Sub

    Private Sub cboOrigenSala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrigenSala.SelectedIndexChanged
        If cboOrigenSala.Text <> "" Then
            'Sala
            Dim dsSala As New Data.DataSet
            dsSala = objSala.BuscarOrigen(cboOrigenSala.Text)
            cboSala.DataSource = dsSala.Tables(0)
            cboSala.DisplayMember = "Descripcion"
            cboSala.ValueMember = "IdSala"
            Buscar()
        End If
    End Sub

    Private Sub cboSala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSala.KeyDown
        If e.KeyCode = Keys.Enter And cboSala.Text <> "" Then cboCargo.Select()
    End Sub

    Private Sub cboSala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSala.SelectedIndexChanged

    End Sub
End Class