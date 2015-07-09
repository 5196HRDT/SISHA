Public Class frmMenu

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CargoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCargo.Show()
    End Sub

    Private Sub ServicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmServicio.Show()
    End Sub

    Private Sub PersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonalToolStripMenuItem.Click
        frmPersonal.Show()
    End Sub

    Private Sub TipoAnestesiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmTipoAnestesia.Show()
    End Sub

    Private Sub ProgramacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramacionToolStripMenuItem.Click
        TipoProgramacion = 1
        frmProgramacion.Show()
    End Sub

    Private Sub frmMenu_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AbrirBD()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmProgPer.Show()
    End Sub

    Private Sub ProgramaciónOpreacioensToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramaciónOpreacioensToolStripMenuItem.Click
        frmConsultaProgramacion.Show()
    End Sub

    Private Sub CambioProgramacionOperacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambioProgramacionOperacionesToolStripMenuItem.Click
        frmCambioProg.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub PrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrToolStripMenuItem.Click
        frmConsultaTotal.Show()
    End Sub

    Private Sub OperacionesReprogramadasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperacionesReprogramadasToolStripMenuItem.Click
        frmConsultaRepro.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        TipoProgramacion = 2
        frmProgramacion.Show()
    End Sub
End Class
