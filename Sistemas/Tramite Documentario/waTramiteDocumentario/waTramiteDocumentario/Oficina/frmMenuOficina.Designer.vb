<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuOficina
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MantenedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NumeraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchivadoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarDocumentosInternosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResponderDocumentoPendienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarDocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenedorToolStripMenuItem, Me.OperacionesToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(668, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MantenedorToolStripMenuItem
        '
        Me.MantenedorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NumeraciónToolStripMenuItem, Me.ArchivadoresToolStripMenuItem})
        Me.MantenedorToolStripMenuItem.Name = "MantenedorToolStripMenuItem"
        Me.MantenedorToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.MantenedorToolStripMenuItem.Text = "Mantenedor"
        '
        'NumeraciónToolStripMenuItem
        '
        Me.NumeraciónToolStripMenuItem.Name = "NumeraciónToolStripMenuItem"
        Me.NumeraciónToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NumeraciónToolStripMenuItem.Text = "Correlativos"
        '
        'ArchivadoresToolStripMenuItem
        '
        Me.ArchivadoresToolStripMenuItem.Name = "ArchivadoresToolStripMenuItem"
        Me.ArchivadoresToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ArchivadoresToolStripMenuItem.Text = "Archivadores"
        '
        'OperacionesToolStripMenuItem
        '
        Me.OperacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DocumentosToolStripMenuItem})
        Me.OperacionesToolStripMenuItem.Name = "OperacionesToolStripMenuItem"
        Me.OperacionesToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.OperacionesToolStripMenuItem.Text = "Operaciones"
        '
        'DocumentosToolStripMenuItem
        '
        Me.DocumentosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarDocumentosInternosToolStripMenuItem, Me.ResponderDocumentoPendienteToolStripMenuItem, Me.ConsultarDocumentosToolStripMenuItem})
        Me.DocumentosToolStripMenuItem.Name = "DocumentosToolStripMenuItem"
        Me.DocumentosToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DocumentosToolStripMenuItem.Text = "Documentos"
        '
        'EnviarDocumentosInternosToolStripMenuItem
        '
        Me.EnviarDocumentosInternosToolStripMenuItem.Name = "EnviarDocumentosInternosToolStripMenuItem"
        Me.EnviarDocumentosInternosToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.EnviarDocumentosInternosToolStripMenuItem.Text = "Enviar Documentos Internos"
        '
        'ResponderDocumentoPendienteToolStripMenuItem
        '
        Me.ResponderDocumentoPendienteToolStripMenuItem.Name = "ResponderDocumentoPendienteToolStripMenuItem"
        Me.ResponderDocumentoPendienteToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ResponderDocumentoPendienteToolStripMenuItem.Text = "Responder Documento Pendiente"
        '
        'ConsultarDocumentosToolStripMenuItem
        '
        Me.ConsultarDocumentosToolStripMenuItem.Name = "ConsultarDocumentosToolStripMenuItem"
        Me.ConsultarDocumentosToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.ConsultarDocumentosToolStripMenuItem.Text = "Consultar Documentos"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'frmMenuOficina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(668, 381)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMenuOficina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema de Trámite Documentario Interno HRDT"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MantenedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NumeraciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarDocumentosInternosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResponderDocumentoPendienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarDocumentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArchivadoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
