<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuCta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuCta))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AtencionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AperturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresoProcedimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AnularAtencionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularCierreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AtencionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtencionToolStripMenuItem, Me.ReportesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(306, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AtencionToolStripMenuItem
        '
        Me.AtencionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AperturaToolStripMenuItem, Me.IngresoProcedimientosToolStripMenuItem, Me.ToolStripMenuItem4, Me.ToolStripMenuItem2, Me.AnularAtencionToolStripMenuItem, Me.AnularCierreToolStripMenuItem, Me.ToolStripMenuItem1, Me.SalirToolStripMenuItem})
        Me.AtencionToolStripMenuItem.Name = "AtencionToolStripMenuItem"
        Me.AtencionToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.AtencionToolStripMenuItem.Text = "Atencion"
        '
        'AperturaToolStripMenuItem
        '
        Me.AperturaToolStripMenuItem.Name = "AperturaToolStripMenuItem"
        Me.AperturaToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.AperturaToolStripMenuItem.Text = "Apertura"
        '
        'IngresoProcedimientosToolStripMenuItem
        '
        Me.IngresoProcedimientosToolStripMenuItem.Name = "IngresoProcedimientosToolStripMenuItem"
        Me.IngresoProcedimientosToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.IngresoProcedimientosToolStripMenuItem.Text = "Servicios"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(197, 22)
        Me.ToolStripMenuItem4.Text = "Relacion de Atenciones"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(194, 6)
        '
        'AnularAtencionToolStripMenuItem
        '
        Me.AnularAtencionToolStripMenuItem.Name = "AnularAtencionToolStripMenuItem"
        Me.AnularAtencionToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.AnularAtencionToolStripMenuItem.Text = "Anular Atencion"
        '
        'AnularCierreToolStripMenuItem
        '
        Me.AnularCierreToolStripMenuItem.Name = "AnularCierreToolStripMenuItem"
        Me.AnularCierreToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.AnularCierreToolStripMenuItem.Text = "Anular Alta"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(194, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtencionesToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'AtencionesToolStripMenuItem
        '
        Me.AtencionesToolStripMenuItem.Name = "AtencionesToolStripMenuItem"
        Me.AtencionesToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.AtencionesToolStripMenuItem.Text = "Atenciones"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(307, 141)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'frmMenuCta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 165)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmMenuCta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Convenio Cuenta Corriente"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AtencionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AperturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresoProcedimientosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AnularAtencionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularCierreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AtencionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
