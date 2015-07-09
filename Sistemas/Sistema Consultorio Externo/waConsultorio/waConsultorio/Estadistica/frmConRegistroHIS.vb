Public Class frmConRegistroHIS
    Dim objRegistro As New RegistroHIS

    Private Sub Buscar()
        Dim dsTabla As New DataSet
        dsTabla = objRegistro.Buscar(dtpFecha.Value.ToShortDateString, "MAÑANA")
        lvTabla.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("FechaMigracion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("HoraMigracion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("EquipoMigracion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("UsuarioMigracion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Fecha"))
        Next
    End Sub

    Private Sub frmConRegistroHIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Buscar()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Buscar()
    End Sub
End Class