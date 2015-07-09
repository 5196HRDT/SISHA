Public Class frmInformeEmergencia
    Dim objEmergencia As New clsEmergenciaIngreso

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrar.Click
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objEmergencia.ReporteGeneral(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add((I + 1).ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaIngreso"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraIngreso"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoEdad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("EstadoCivil"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Doc_Identidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo"))
        Next
        lblTotalE.Text = "Total de Historia Clínicas Trabajadas: " & dsVer.Tables(0).Rows.Count
    End Sub

    Private Sub frmInformeEmergencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTotalE.Text = "Total de Historia Clínicas Trabajadas: 0"
    End Sub
End Class