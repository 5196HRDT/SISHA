Public Class frmFichaNeonatal
    Dim oper As String
    Dim objHospitalizacion As New Hospitalizacion
    Dim objIngreso As New Ingreso
    Dim CodLocal As String
    Dim IdHospitalizacion As String
    Dim idHistoria As String

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dsHospitalizacion As New Data.DataSet
            IdHospitalizacion = ""
            dsHospitalizacion = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
            If dsHospitalizacion.Tables(0).Rows.Count > 0 Then
                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                lblFecIng.Text = dsHospitalizacion.Tables(0).Rows(0)("FecIngreso")
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")
                'Buscar()
            Else
                MessageBox.Show("Paciente No Esta Registrado En Hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblFecIng.Text = ""
                lblPaciente.Text = ""
            End If
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False, True)
        oper = 1
        txtHistoria.Select()
    End Sub
    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Imprimir As Boolean, ByVal Salir As Boolean)
        BtnNuevo.Enabled = Nuevo
        BtnGrabar.Enabled = Grabar
        BtnCancelar.Enabled = Cancelar
        BtnImprimir.Enabled = Imprimir
        BtnSalir.Enabled = Salir
    End Sub
    
    Private Sub BtmImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub CmbReanimaNatal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbReanimaNatal.SelectedIndexChanged

    End Sub
End Class