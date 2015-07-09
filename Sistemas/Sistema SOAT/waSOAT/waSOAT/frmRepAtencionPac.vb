Public Class frmRepAtencionPac
    Dim objFicha As New FichaSoat

    Private Sub Buscar()
        Dim dsTabla As New Data.DataSet
        dsTabla = objFicha.AtencionPac(txtPaciente.Text, Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"))
        Dim I As Integer
        Dim Fila As ListViewItem
        lvTabla.Items.Clear()
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("IdSoat"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("FechaRegistro"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("APaterno") & " " & dsTabla.Tables(0).Rows(I)("AMaterno") & " " & dsTabla.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("SubEspecialidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Placa"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("MotivoAnulado").ToString)
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmRepAtencionPac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged
        Buscar()
    End Sub
End Class