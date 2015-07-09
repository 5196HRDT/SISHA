Public Class frmCambiarPac
    Dim objMedico As New Medico
    Dim objCupo As New Cupo

    Private Sub frmCambiarPac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
        cboTurno.Text = "MAÑANA"

        cboMedico.DataSource = objMedico.Combo.Tables(0)
        cboMedico.DisplayMember = "Nombres"
        cboMedico.ValueMember = "IdMedico"

    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If cboTurno.Text = "" Or cboMedico.Text = "" Then MessageBox.Show("Debe ingresar informacion completa", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim dsAtencion As New Data.DataSet
        dsAtencion = objCupo.Cupos_BuscarAtencion(dtpFecha.Value, cboTurno.Text, CodMedico)
        dgTabla.DataSource = dsAtencion.Tables(0)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        If MessageBox.Show("Esta seguro de Asignar Paciente al Medico Seleccionado", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If dgTabla.RowCount > 0 Then
                Dim IdCupo As String
                IdCupo = dgTabla.Item(8, dgTabla.CurrentRow.Index).Value

            End If
            Me.Close()
        End If
    End Sub
End Class