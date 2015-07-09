Public Class frmProgramacion
    Dim objConsulta As New clsConsulta

    Private Sub frmProgramacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        'Consulta Externa
        lvCE.Items.Clear()
        Dim dsTabla As New DataSet
        dsTabla = objConsulta.AtencionPatologia(txtPaciente.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvCE.Items.Add(dsTabla.Tables(0).Rows(I)("IdConsultaExa"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TipoPaciente"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("FechaRegistro"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
        Next
    End Sub
End Class