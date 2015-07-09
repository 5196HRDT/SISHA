Public Class frmMenu


    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click

    End Sub

    Private Sub SalirToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub GeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralToolStripMenuItem.Click
        frmRepPacSIS.Show()
    End Sub

    Private Sub DetalladoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalladoToolStripMenuItem.Click
        frmProduccionLab.Show()
    End Sub

    Private Sub SOATToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOATToolStripMenuItem.Click
        frmLaboratorioSOAT.Show()
    End Sub

    Private Sub DetalladoToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles DetalladoToolStripMenuItem1.Click
        frmRepPacCom.Show()
    End Sub

    Private Sub ServiciosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ServiciosToolStripMenuItem.Click
        frmRepPacCoSe.Show()
    End Sub

    Private Sub VerificacionDeComprobanteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerificacionDeComprobanteToolStripMenuItem.Click
        frmVerificacion.Show()
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem9.Click
        frmOtroClas.Show()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem7.Click
        frmClasificarTar.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem10.Click
        frmConsultaClas.Show()
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem11.Click
        frmParametros.Show()
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem8.Click
        frmServicio.Show()
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem12.Click
        frmServicioHRDTLab.Show()
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem13.Click
        frmControlDonante.Show()
    End Sub

    Private Sub ProducciónConsultaExternaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProducciónConsultaExternaToolStripMenuItem.Click
        'frmProduccionCE.Show()
        frmRepEmergencia.Show()
    End Sub

    Private Sub RestringidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestringidosToolStripMenuItem.Click
        frmResultadosRes.Show()
    End Sub

    Private Sub ConsultaExternaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaExternaToolStripMenuItem.Click
        frmRepConsultaExterna.Show()
    End Sub

    Private Sub ProcetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcetsToolStripMenuItem.Click
        frmBolsaColectoraSangre.Show()
    End Sub

    Private Sub frmMenu_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class