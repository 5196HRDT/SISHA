Public Class frmMenuOficina

    Private Sub frmMenuOficina_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuOficina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " - " & "Usuario: " & NombreSecretaria & "    Servicio/Area: " & ServicioAreaTrabajador
    End Sub

    Private Sub EnviarDocumentosInternosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarDocumentosInternosToolStripMenuItem.Click
        Dim fm As New frmEnviarDocumento
        fm.MdiParent = Me
        fm.Show()
    End Sub

    Private Sub NumeraciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumeraciónToolStripMenuItem.Click
        Dim fm As New frmNumeracionOficina
        fm.MdiParent = Me
        fm.Show()
    End Sub

    Private Sub ResponderDocumentoPendienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResponderDocumentoPendienteToolStripMenuItem.Click
        Dim fm As New frmResponderDocPendiente
        fm.MdiParent = Me
        fm.Show()
    End Sub

    Private Sub ArchivadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArchivadoresToolStripMenuItem.Click
        Dim fm As New frmArchivador
        fm.MdiParent = Me
        fm.Show()
    End Sub
End Class