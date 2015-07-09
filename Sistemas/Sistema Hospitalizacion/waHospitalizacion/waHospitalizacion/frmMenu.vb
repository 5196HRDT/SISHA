Public Class frmMenu

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    Private Sub ProgramaciónOpreacioensToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramaciónOpreacioensToolStripMenuItem.Click
        frmConsultaProgramacion.Show()
    End Sub

    Private Sub TransferenciaServicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferenciaServicioToolStripMenuItem.Click
        frmTransferenciaServicio.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmIngreso.Show()
    End Sub

    Private Sub EgresoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EgresoToolStripMenuItem.Click
        frmEgreso.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        frmProcedimientos.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmMortalidad.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub NeonatologiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeonatologiaToolStripMenuItem.Click
        frmFichaNeonatal.Show()
    End Sub

    Private Sub OperacionesReprogramadasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperacionesReprogramadasToolStripMenuItem.Click
        frmConsultaRepro.Show()
    End Sub

    Private Sub ServicioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ServicioToolStripMenuItem.Click
        frmServicio.Show()
    End Sub

    Private Sub EspecialidadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EspecialidadToolStripMenuItem.Click
        frmEspecialidad.Show()
    End Sub

    Private Sub SubServicioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SubServicioToolStripMenuItem.Click
        frmSubServicio.Show()
    End Sub

    Private Sub frmMenu_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CamaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CamaToolStripMenuItem.Click
        frmCama.Show()
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem9.Click
        frmRecienNacido.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem10.Click
        frmReporteHospEst.Show()
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem11.Click
        frmConsolidado.Show()
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem12.Click
        frmCIE10.Show()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        frmMovimientosHosp.Show()
    End Sub
End Class
