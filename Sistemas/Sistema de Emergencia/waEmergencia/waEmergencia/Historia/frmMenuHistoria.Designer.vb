<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuHistoria
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuHistoria))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HistoriaClíniciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadiologiaYEcografiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatologiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImagenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcedimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaExternaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HistoriaClíniciaToolStripMenuItem, Me.ProcedimientosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(310, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HistoriaClíniciaToolStripMenuItem
        '
        Me.HistoriaClíniciaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem8, Me.HistoriaToolStripMenuItem, Me.ToolStripMenuItem7, Me.ToolStripMenuItem6, Me.RadiologiaYEcografiaToolStripMenuItem, Me.PatologiaToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ImagenesToolStripMenuItem, Me.ToolStripMenuItem1, Me.SalirToolStripMenuItem})
        Me.HistoriaClíniciaToolStripMenuItem.Name = "HistoriaClíniciaToolStripMenuItem"
        Me.HistoriaClíniciaToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.HistoriaClíniciaToolStripMenuItem.Text = "Historia Clínicia"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem8.Text = "Emergencia"
        '
        'HistoriaToolStripMenuItem
        '
        Me.HistoriaToolStripMenuItem.Name = "HistoriaToolStripMenuItem"
        Me.HistoriaToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.HistoriaToolStripMenuItem.Text = "Consulta Externa"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem7.Text = "Hospitalización"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem6.Text = "Laboratorio Clínico"
        '
        'RadiologiaYEcografiaToolStripMenuItem
        '
        Me.RadiologiaYEcografiaToolStripMenuItem.Name = "RadiologiaYEcografiaToolStripMenuItem"
        Me.RadiologiaYEcografiaToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.RadiologiaYEcografiaToolStripMenuItem.Text = "Radiologia y Ecografia"
        '
        'PatologiaToolStripMenuItem
        '
        Me.PatologiaToolStripMenuItem.Name = "PatologiaToolStripMenuItem"
        Me.PatologiaToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.PatologiaToolStripMenuItem.Text = "Patologia"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem2.Text = "EKG"
        '
        'ImagenesToolStripMenuItem
        '
        Me.ImagenesToolStripMenuItem.Name = "ImagenesToolStripMenuItem"
        Me.ImagenesToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ImagenesToolStripMenuItem.Text = "Imagenes"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(188, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ProcedimientosToolStripMenuItem
        '
        Me.ProcedimientosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsultaExternaToolStripMenuItem})
        Me.ProcedimientosToolStripMenuItem.Name = "ProcedimientosToolStripMenuItem"
        Me.ProcedimientosToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.ProcedimientosToolStripMenuItem.Text = "Procedimientos"
        '
        'ConsultaExternaToolStripMenuItem
        '
        Me.ConsultaExternaToolStripMenuItem.Name = "ConsultaExternaToolStripMenuItem"
        Me.ConsultaExternaToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ConsultaExternaToolStripMenuItem.Text = "Consulta Externa"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-28, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(340, 203)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem3.Text = "Electroencefalograma"
        '
        'frmMenuHistoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 231)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMenuHistoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Historia Clínica"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HistoriaClíniciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoriaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadiologiaYEcografiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatologiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImagenesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcedimientosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaExternaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
End Class
