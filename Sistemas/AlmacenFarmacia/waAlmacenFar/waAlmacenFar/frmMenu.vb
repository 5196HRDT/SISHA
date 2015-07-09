Public Class frmMenu

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub PecosaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PecosaToolStripMenuItem.Click
        frmPecosa.Show()
    End Sub

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AbrirBD()
    End Sub

    Private Sub TomaInventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TomaInventarioToolStripMenuItem.Click
        ListaInventarioAlm.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmMedicamento.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmUnidad.Show()
    End Sub

    Private Sub TomaInventarioFarmaciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TomaInventarioFarmaciaToolStripMenuItem.Click
        frmListaInventarioFar.Show()
    End Sub
End Class