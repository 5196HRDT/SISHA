Public Class frmRelacionPaciente
    Dim objConvenio As New Convenio
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmRelacionPaciente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy")
        dtpF2.Value = Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy")
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim dsVer As New Data.DataSet
        dsVer = objConvenio.ReporteAtenciones(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), txtPaciente.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        lvTabla.Items.Clear()
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdConvenio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegistro"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoConvenio"))
            If dsVer.Tables(0).Rows(I)("FechaFinal").ToString <> "" Then Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaFinal")) Else Fila.SubItems.Add("")
            If dsVer.Tables(0).Rows(I)("FechaAnu").ToString <> "" Then Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaAnu")) Else Fila.SubItems.Add("")
        Next
        If lvTabla.Items.Count = 0 Then MessageBox.Show("No existen Atenciones Registradas", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

    End Sub
End Class