Public Class MenuSIS

    Private Sub IngresoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoToolStripMenuItem.Click
        frmIngresoSis.Show()
    End Sub

    Private Sub SalidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalidaToolStripMenuItem.Click
        frmSalidaSIS.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmControlCuentaSIS.Show()
    End Sub

    Private Sub ProcedimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcedimientosToolStripMenuItem.Click
        frmProcedimientos.Show()
    End Sub

    Private Sub MedicamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedicamentosToolStripMenuItem.Click
        frmMedicamentos.Show()
    End Sub

    Private Sub ProcedimientosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcedimientosToolStripMenuItem1.Click
        'frmCatalogoProcedimientos.Show()
    End Sub

    Private Sub MedicamentosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedicamentosToolStripMenuItem1.Click
        frmCatalogoMedicamentos.Show()
    End Sub

    Private Sub EmisiónDeFormatosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmisiónDeFormatosToolStripMenuItem.Click
        frmConsultaAtencionesSIS.Show()
    End Sub

    Private Sub FormatosXPacienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormatosXPacienteToolStripMenuItem.Click
        frmConsultaAtencionSISPac.Show()
    End Sub

    Private Sub SISToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SISToolStripMenuItem1.Click
        Catalogo = "SIS"
        frmCatalogoServicios.Show()
    End Sub

    Private Sub SOATToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOATToolStripMenuItem.Click
        Catalogo = "SOAT"
        frmCatalogoServicios.Show()
    End Sub

    Private Sub CentrosDeSaludToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CentrosDeSaludToolStripMenuItem.Click
        frmCentroSalud.Show()
    End Sub

    Private Sub ConsultaExternaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaExternaToolStripMenuItem.Click
        frmConsultaExt.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmAnularIngSis.Show()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmNuevoProcedimiento.Show()
    End Sub

    Private Sub ToolStripMenuItem6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        frmRecuperarAltaSIS.Show()
    End Sub

    Private Sub AtencionesHospitalizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtencionesHospitalizaciónToolStripMenuItem.Click
        frmConsultaAtencionsHospSis.Show()
    End Sub

    Private Sub PrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrToolStripMenuItem.Click
        frmProduccionProd.Show()
    End Sub

    Private Sub TotalMedicamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalMedicamentosToolStripMenuItem.Click
        frmProduccionMed.Show()
    End Sub

    Private Sub PaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaToolStripMenuItem.Click
        frmConsultaPacAten.Show()
    End Sub

    Private Sub OxigenoPacienteHospitalizadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OxigenoPacienteHospitalizadosToolStripMenuItem.Click
        frmConsultaOxiPacH.Show()
    End Sub

    Private Sub ClasificacionMedicamentosSISToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClasificacionMedicamentosSISToolStripMenuItem.Click
        frmSelMedSIS.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        frmCuposAsignados.Show()
    End Sub

    Private Sub SusaludToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SusaludToolStripMenuItem.Click
        frmSusalud.Show()
    End Sub

    Private Sub ConsultarSISToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuSIS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class