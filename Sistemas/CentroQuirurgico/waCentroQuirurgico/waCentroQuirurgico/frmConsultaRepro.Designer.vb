﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaRepro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaRepro))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstCirculante = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lstAnestesiologo = New System.Windows.Forms.ListBox()
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.pdImpresion = New System.Windows.Forms.PrintDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.cboOrigenSala = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(301, 155)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(301, 114)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(301, 74)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Fecha"
        '
        'lvDet
        '
        Me.lvDet.BackColor = System.Drawing.Color.Ivory
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader8, Me.ColumnHeader11})
        Me.lvDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(5, 196)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(675, 167)
        Me.lvDet.TabIndex = 4
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "HC"
        Me.ColumnHeader1.Width = 66
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "PACIENTE"
        Me.ColumnHeader2.Width = 170
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "EDAD"
        Me.ColumnHeader3.Width = 45
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "SERV"
        Me.ColumnHeader4.Width = 63
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "OPERACION"
        Me.ColumnHeader5.Width = 253
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "HORA"
        Me.ColumnHeader6.Width = 58
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "SALA"
        Me.ColumnHeader7.Width = 42
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "ANEST"
        Me.ColumnHeader9.Width = 59
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "CIRUJANO"
        Me.ColumnHeader10.Width = 152
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "TipoPac"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Motivo Rep"
        Me.ColumnHeader11.Width = 200
        '
        'lstCirculante
        '
        Me.lstCirculante.BackColor = System.Drawing.SystemColors.Info
        Me.lstCirculante.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstCirculante.FormattingEnabled = True
        Me.lstCirculante.Location = New System.Drawing.Point(465, 56)
        Me.lstCirculante.Name = "lstCirculante"
        Me.lstCirculante.Size = New System.Drawing.Size(215, 130)
        Me.lstCirculante.TabIndex = 61
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(522, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "CIRCULANTES"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "ANESTESIOLOGOS"
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(92, 6)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'lstAnestesiologo
        '
        Me.lstAnestesiologo.BackColor = System.Drawing.SystemColors.Info
        Me.lstAnestesiologo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstAnestesiologo.FormattingEnabled = True
        Me.lstAnestesiologo.Location = New System.Drawing.Point(5, 56)
        Me.lstAnestesiologo.Name = "lstAnestesiologo"
        Me.lstAnestesiologo.Size = New System.Drawing.Size(215, 130)
        Me.lstAnestesiologo.TabIndex = 59
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
        'pdcDocumento
        '
        Me.pdcDocumento.DocumentName = "Preliquidacion"
        '
        'pdImpresion
        '
        Me.pdImpresion.UseEXDialog = True
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.pdcDocumento
        '
        'cboOrigenSala
        '
        Me.cboOrigenSala.FormattingEnabled = True
        Me.cboOrigenSala.Items.AddRange(New Object() {"PRINCIPAL", "CIRUGIA DE DIA"})
        Me.cboOrigenSala.Location = New System.Drawing.Point(373, 6)
        Me.cboOrigenSala.Name = "cboOrigenSala"
        Me.cboOrigenSala.Size = New System.Drawing.Size(161, 21)
        Me.cboOrigenSala.TabIndex = 63
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(312, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Origen"
        '
        'frmConsultaRepro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 369)
        Me.Controls.Add(Me.cboOrigenSala)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvDet)
        Me.Controls.Add(Me.lstCirculante)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.lstAnestesiologo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaRepro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Operaciones Reprogramadas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstCirculante As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lstAnestesiologo As System.Windows.Forms.ListBox
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdImpresion As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents cboOrigenSala As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
