Public Class frmInterconsultaH
    Dim objHospitalizacion As New Hospitalizacion
    Dim objPaciente As New Historia

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmInterconsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnGrabar.Enabled = False
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            Dim dsHosp As New Data.DataSet
            Dim dsPac As New Data.DataSet
            btnGrabar.Enabled = False
            dsHosp = objHospitalizacion.BuscarHospitalizacion(txtHistoria.Text)
            If dsHosp.Tables(0).Rows.Count > 0 Then
                dsPac = objPaciente.BuscarHistoria(txtHistoria.Text)
                lblPaciente.Text = dsPac.Tables(0).Rows(0)("Apaterno") & " " & dsPac.Tables(0).Rows(0)("AMaterno") & " " & dsPac.Tables(0).Rows(0)("Nombres")
                btnGrabar.Enabled = True
                btnGrabar.Select()
            Else
                MessageBox.Show("Paciente no registra un Ingreso de Hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        CodCupo = 0
        NHistoria = txtHistoria.Text
        NomPaciente = lblPaciente.Text
        vTipoAtencion = "INTERCONSULTA"
        frmConsulta.Show()
    End Sub
End Class