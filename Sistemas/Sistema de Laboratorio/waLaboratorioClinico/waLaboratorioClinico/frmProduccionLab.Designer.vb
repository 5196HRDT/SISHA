<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduccionLab
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProduccionLab))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpF2 = New System.Windows.Forms.DateTimePicker()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpF1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnImprimirE = New System.Windows.Forms.Button()
        Me.lblImpE = New System.Windows.Forms.Label()
        Me.lblCantE = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvE = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnImprimirH = New System.Windows.Forms.Button()
        Me.lblImpH = New System.Windows.Forms.Label()
        Me.lblCantH = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lvH = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnImprimirC = New System.Windows.Forms.Button()
        Me.lblImpC = New System.Windows.Forms.Label()
        Me.lblCantC = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lvC = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(464, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 55
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(303, 7)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 54
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpF2
        '
        Me.dtpF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF2.Location = New System.Drawing.Point(199, 7)
        Me.dtpF2.Name = "dtpF2"
        Me.dtpF2.Size = New System.Drawing.Size(98, 20)
        Me.dtpF2.TabIndex = 53
        '
        'pdcDocumento
        '
        Me.pdcDocumento.DocumentName = "Preliquidacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(166, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "y el"
        '
        'dtpF1
        '
        Me.dtpF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF1.Location = New System.Drawing.Point(66, 8)
        Me.dtpF1.Name = "dtpF1"
        Me.dtpF1.Size = New System.Drawing.Size(98, 20)
        Me.dtpF1.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Entre el"
        '
        'ppdVistaPrevia
        '
        Me.ppdVistaPrevia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdVistaPrevia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdVistaPrevia.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdVistaPrevia.Document = Me.pdcDocumento
        Me.ppdVistaPrevia.Enabled = True
        Me.ppdVistaPrevia.Icon = CType(resources.GetObject("ppdVistaPrevia.Icon"), System.Drawing.Icon)
        Me.ppdVistaPrevia.Name = "ppdVistaPrevia"
        Me.ppdVistaPrevia.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 34)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(548, 357)
        Me.TabControl1.TabIndex = 61
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnImprimirE)
        Me.TabPage1.Controls.Add(Me.lblImpE)
        Me.TabPage1.Controls.Add(Me.lblCantE)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.lvE)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(540, 331)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "EMERGENCIA"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnImprimirE
        '
        Me.btnImprimirE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirE.Location = New System.Drawing.Point(121, 294)
        Me.btnImprimirE.Name = "btnImprimirE"
        Me.btnImprimirE.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimirE.TabIndex = 63
        Me.btnImprimirE.Text = "&Imprimir"
        Me.btnImprimirE.UseVisualStyleBackColor = True
        '
        'lblImpE
        '
        Me.lblImpE.BackColor = System.Drawing.Color.White
        Me.lblImpE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImpE.Location = New System.Drawing.Point(438, 298)
        Me.lblImpE.Name = "lblImpE"
        Me.lblImpE.Size = New System.Drawing.Size(70, 23)
        Me.lblImpE.TabIndex = 62
        '
        'lblCantE
        '
        Me.lblCantE.BackColor = System.Drawing.Color.White
        Me.lblCantE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCantE.Location = New System.Drawing.Point(362, 298)
        Me.lblCantE.Name = "lblCantE"
        Me.lblCantE.Size = New System.Drawing.Size(70, 23)
        Me.lblCantE.TabIndex = 61
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(284, 299)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Totales"
        '
        'lvE
        '
        Me.lvE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvE.FullRowSelect = True
        Me.lvE.GridLines = True
        Me.lvE.Location = New System.Drawing.Point(6, 3)
        Me.lvE.Name = "lvE"
        Me.lvE.Size = New System.Drawing.Size(527, 283)
        Me.lvE.TabIndex = 57
        Me.lvE.UseCompatibleStateImageBehavior = False
        Me.lvE.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Procedimiento"
        Me.ColumnHeader1.Width = 360
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Cant"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Importe"
        Me.ColumnHeader3.Width = 80
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnImprimirH)
        Me.TabPage2.Controls.Add(Me.lblImpH)
        Me.TabPage2.Controls.Add(Me.lblCantH)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.lvH)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(540, 331)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "HOSPITALIZACION"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnImprimirH
        '
        Me.btnImprimirH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirH.Location = New System.Drawing.Point(125, 295)
        Me.btnImprimirH.Name = "btnImprimirH"
        Me.btnImprimirH.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimirH.TabIndex = 67
        Me.btnImprimirH.Text = "&Imprimir"
        Me.btnImprimirH.UseVisualStyleBackColor = True
        '
        'lblImpH
        '
        Me.lblImpH.BackColor = System.Drawing.Color.White
        Me.lblImpH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImpH.Location = New System.Drawing.Point(439, 301)
        Me.lblImpH.Name = "lblImpH"
        Me.lblImpH.Size = New System.Drawing.Size(70, 23)
        Me.lblImpH.TabIndex = 66
        '
        'lblCantH
        '
        Me.lblCantH.BackColor = System.Drawing.Color.White
        Me.lblCantH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCantH.Location = New System.Drawing.Point(363, 301)
        Me.lblCantH.Name = "lblCantH"
        Me.lblCantH.Size = New System.Drawing.Size(70, 23)
        Me.lblCantH.TabIndex = 65
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(285, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Totales"
        '
        'lvH
        '
        Me.lvH.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvH.FullRowSelect = True
        Me.lvH.GridLines = True
        Me.lvH.Location = New System.Drawing.Point(7, 6)
        Me.lvH.Name = "lvH"
        Me.lvH.Size = New System.Drawing.Size(527, 283)
        Me.lvH.TabIndex = 63
        Me.lvH.UseCompatibleStateImageBehavior = False
        Me.lvH.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Procedimiento"
        Me.ColumnHeader4.Width = 360
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cant"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Importe"
        Me.ColumnHeader6.Width = 80
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnImprimirC)
        Me.TabPage3.Controls.Add(Me.lblImpC)
        Me.TabPage3.Controls.Add(Me.lblCantC)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.lvC)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(540, 331)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "CONSULTA EXTERNA"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnImprimirC
        '
        Me.btnImprimirC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirC.Location = New System.Drawing.Point(124, 297)
        Me.btnImprimirC.Name = "btnImprimirC"
        Me.btnImprimirC.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimirC.TabIndex = 68
        Me.btnImprimirC.Text = "&Imprimir"
        Me.btnImprimirC.UseVisualStyleBackColor = True
        '
        'lblImpC
        '
        Me.lblImpC.BackColor = System.Drawing.Color.White
        Me.lblImpC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImpC.Location = New System.Drawing.Point(439, 301)
        Me.lblImpC.Name = "lblImpC"
        Me.lblImpC.Size = New System.Drawing.Size(70, 23)
        Me.lblImpC.TabIndex = 66
        '
        'lblCantC
        '
        Me.lblCantC.BackColor = System.Drawing.Color.White
        Me.lblCantC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCantC.Location = New System.Drawing.Point(363, 301)
        Me.lblCantC.Name = "lblCantC"
        Me.lblCantC.Size = New System.Drawing.Size(70, 23)
        Me.lblCantC.TabIndex = 65
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(285, 302)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Totales"
        '
        'lvC
        '
        Me.lvC.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lvC.FullRowSelect = True
        Me.lvC.GridLines = True
        Me.lvC.Location = New System.Drawing.Point(7, 6)
        Me.lvC.Name = "lvC"
        Me.lvC.Size = New System.Drawing.Size(527, 283)
        Me.lvC.TabIndex = 63
        Me.lvC.UseCompatibleStateImageBehavior = False
        Me.lvC.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Procedimiento"
        Me.ColumnHeader7.Width = 360
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Cant"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Importe"
        Me.ColumnHeader9.Width = 80
        '
        'frmProduccionLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 403)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dtpF2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpF1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmProduccionLab"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produccion de Laboratorio"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dtpF2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpF1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lvE As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lblImpE As System.Windows.Forms.Label
    Friend WithEvents lblCantE As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblImpH As System.Windows.Forms.Label
    Friend WithEvents lblCantH As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lvH As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblImpC As System.Windows.Forms.Label
    Friend WithEvents lblCantC As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lvC As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnImprimirE As System.Windows.Forms.Button
    Friend WithEvents btnImprimirH As System.Windows.Forms.Button
    Friend WithEvents btnImprimirC As System.Windows.Forms.Button
End Class
