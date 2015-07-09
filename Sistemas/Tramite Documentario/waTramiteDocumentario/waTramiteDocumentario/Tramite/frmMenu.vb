Public Class frmMenu

    Private Sub frmMenu_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub SalidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalidaToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub DepartamentoUnidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartamentoUnidadToolStripMenuItem.Click
        Dim DptoUnidad As String = frmDptoUnidad.Text
        If ValidarFormAbierto(frmDptoUnidad) = False Then
            Dim fm As New frmDptoUnidad
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & DptoUnidad, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TipoDocumentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDocumentoToolStripMenuItem.Click
        Dim TipoDocumento As String = frmTipoDocumento.Text
        If ValidarFormAbierto(frmTipoDocumento) = False Then
            Dim fm As New frmTipoDocumento
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & TipoDocumento, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TrabajadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrabajadoresToolStripMenuItem.Click
        Dim Trabajadores As String = frmTrabajadores.Text
        If ValidarFormAbierto(frmTrabajadores) = False Then
            Dim fm As New frmTrabajadores
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & Trabajadores, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub MotivoDelPaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotivoDelPaseToolStripMenuItem.Click
        Dim MotivoDelPase As String = frmMotivoDelPase.Text
        If ValidarFormAbierto(frmMotivoDelPase) = False Then
            Dim fm As New frmMotivoDelPase
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & MotivoDelPase, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub NombreDelAñoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NombreDelAñoToolStripMenuItem.Click
        Dim NombreDelAnio As String = frmNombreDelAnio.Text
        If ValidarFormAbierto(frmNombreDelAnio) = False Then
            Dim fm As New frmNombreDelAnio
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & NombreDelAnio, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ServicioAReaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServicioAReaToolStripMenuItem.Click
        Dim ServicioArea As String = frmServiArea.Text
        If ValidarFormAbierto(frmServiArea) = False Then
            Dim fm As New frmServiArea
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & ServicioArea, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub GeneraDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraDocumentosToolStripMenuItem.Click
        Dim GeneraDocumentos As String = frmEnviarDocumento.Text
        If ValidarFormAbierto(frmEnviarDocumento) = False Then
            Dim fm As New frmEnviarDocumento
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & GeneraDocumentos, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DocumentoExternoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentoExternoToolStripMenuItem.Click
        Dim Documento As String = frmDocumentoExt.Text
        If ValidarFormAbierto(frmDocumentoExt) = False Then
            Dim fm As New frmDocumentoExt
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & Documento, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub NumeracionDocStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumeracionDocStripMenuItem.Click
        Dim NumeracionDoc As String = frmNumeracion.Text
        If ValidarFormAbierto(frmTitulo) = False Then
            Dim fm As New frmNumeracion
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & NumeracionDoc, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TituloStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TituloStripMenuItem.Click
        Dim Titulo As String = frmTitulo.Text
        If ValidarFormAbierto(frmTitulo) = False Then
            Dim fm As New frmTitulo
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & Titulo, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CargoStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoStripMenuItem.Click
        Dim Cargo As String = frmCargo.Text
        If ValidarFormAbierto(frmCargo) = False Then
            Dim fm As New frmCargo
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & Cargo, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub AsignacionCargoStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignacionCargoStripMenuItem.Click
        Dim AsignacionCargo As String = frmAsignacionCargo.Text
        If ValidarFormAbierto(frmAsignacionCargo) = False Then
            Dim fm As New frmAsignacionCargo
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & AsignacionCargo, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TipoJeraqDocStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoJeraqDocStripMenuItem.Click
        Dim TipoJeraqDoc As String = frmTipoJerarquia.Text
        If ValidarFormAbierto(frmTipoJerarquia) = False Then
            Dim fm As New frmTipoJerarquia
            fm.MdiParent = Me
            fm.Show()
        Else
            MessageBox.Show("Ya se encuentra abierto el formulario: " & TipoJeraqDoc, "Mensaje de información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class