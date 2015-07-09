Public Class frmInterconsultaE
    Dim objPaciente As New Historia

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmInterconsultaE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnGrabar.Enabled = False
        txtHistoria.Text = ""
        lblPaciente.Text = ""
        cboTipoPaciente.Text = "COMUN"
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            Dim dsPac As New Data.DataSet
            btnGrabar.Enabled = False
            dsPac = objPaciente.BuscarHistoria(txtHistoria.Text)
            If dsPac.Tables(0).Rows.Count > 0 Then
                lblPaciente.Text = dsPac.Tables(0).Rows(0)("Apaterno") & " " & dsPac.Tables(0).Rows(0)("AMaterno") & " " & dsPac.Tables(0).Rows(0)("Nombres")
                btnGrabar.Enabled = True
                cboTipoPaciente.Select()
            Else
                MessageBox.Show("Paciente no esta registrado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If txtHistoria.Text = "" Then MessageBox.Show("Debe ingresar el Numero de Historia Clínica del Paciente y Presionar Enter para su Búsqueda", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtHistoria.Select() : Exit Sub
        If cboTipoPaciente.Text = "" Then MessageBox.Show("Debe seleccionar el Tipo de Atención del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoPaciente.Select() : Exit Sub
        CodCupo = 0
        NHistoria = txtHistoria.Text
        NomPaciente = lblPaciente.Text
        vTipoAtencion = "INTERCONSULTAE"
        vTipoCupo = cboTipoPaciente.Text
        Me.Close()
        frmConsulta.Show()
    End Sub

    Private Sub cboTipoPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipoPaciente.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoPaciente.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub cboTipoPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoPaciente.SelectedIndexChanged

    End Sub
End Class