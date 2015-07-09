Public Class frmMenuEstadistica

    Private Sub frmMenuEstadistica_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuEstadistica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HospitalizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HospitalizaciónToolStripMenuItem.Click
        frmReporteHospEst.Show()
    End Sub

    Private Sub IngresoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoToolStripMenuItem.Click
        frmIngreso.Show()
    End Sub

    Private Sub EpicrisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EpicrisisToolStripMenuItem.Click
        frmEpicrisis.Show()
    End Sub

    Private Sub AltaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaToolStripMenuItem.Click
        frmEgreso.Show()
    End Sub

    Private Sub MovimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientoToolStripMenuItem.Click
        frmMovimientosHosp.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        frmTransferenciaServicio.Show()
    End Sub

    Private Sub CIE10ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CIE10ToolStripMenuItem.Click
        frmCIE10.Show()
    End Sub

    Private Sub ConsolidadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsolidadoToolStripMenuItem.Click
        frmConsolidado.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmUsuarios.Show()
    End Sub
End Class