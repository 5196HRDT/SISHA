Public Class frmConsolidado
    Dim objEgreso As New Egreso
    Dim objIngreso As New Ingreso

    Private Sub btnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrar.Click
        lvTabla.Items.Clear()
        lvTabla1.Items.Clear()
        Dim dsTabla As New DataSet
        Dim I As Integer
        Dim Fila As ListViewItem

        dsTabla = objIngreso.Consolidado(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("SubServicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Ingreso"))
        Next

        dsTabla = objEgreso.Consolidado(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla1.Items.Add(dsTabla.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("SubServicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Egresos"))
        Next
    End Sub

    Private Sub frmConsolidado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
    End Sub
End Class