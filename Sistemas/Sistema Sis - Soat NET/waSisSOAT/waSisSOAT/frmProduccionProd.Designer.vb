<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduccionProd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProduccionProd))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpF2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpF1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvG = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCant = New System.Windows.Forms.Label()
        Me.lblImp = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(460, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 22
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(299, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 21
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpF2
        '
        Me.dtpF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF2.Location = New System.Drawing.Point(195, 10)
        Me.dtpF2.Name = "dtpF2"
        Me.dtpF2.Size = New System.Drawing.Size(98, 20)
        Me.dtpF2.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(162, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "y el"
        '
        'dtpF1
        '
        Me.dtpF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF1.Location = New System.Drawing.Point(62, 11)
        Me.dtpF1.Name = "dtpF1"
        Me.dtpF1.Size = New System.Drawing.Size(98, 20)
        Me.dtpF1.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Entre el"
        '
        'lvG
        '
        Me.lvG.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvG.FullRowSelect = True
        Me.lvG.GridLines = True
        Me.lvG.Location = New System.Drawing.Point(8, 38)
        Me.lvG.Name = "lvG"
        Me.lvG.Size = New System.Drawing.Size(527, 331)
        Me.lvG.TabIndex = 23
        Me.lvG.UseCompatibleStateImageBehavior = False
        Me.lvG.View = System.Windows.Forms.View.Details
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(257, 372)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Totales"
        '
        'lblCant
        '
        Me.lblCant.BackColor = System.Drawing.Color.White
        Me.lblCant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCant.Location = New System.Drawing.Point(363, 376)
        Me.lblCant.Name = "lblCant"
        Me.lblCant.Size = New System.Drawing.Size(70, 23)
        Me.lblCant.TabIndex = 25
        '
        'lblImp
        '
        Me.lblImp.BackColor = System.Drawing.Color.White
        Me.lblImp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImp.Location = New System.Drawing.Point(439, 376)
        Me.lblImp.Name = "lblImp"
        Me.lblImp.Size = New System.Drawing.Size(70, 23)
        Me.lblImp.TabIndex = 26
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(379, 10)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 27
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pdcDocumento
        '
        Me.pdcDocumento.DocumentName = "Preliquidacion"
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
        'frmProduccionProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 402)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.lblImp)
        Me.Controls.Add(Me.lblCant)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lvG)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dtpF2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpF1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProduccionProd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produccion de Procedimientos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dtpF2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpF1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvG As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCant As System.Windows.Forms.Label
    Friend WithEvents lblImp As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
End Class
