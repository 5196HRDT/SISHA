<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepPacAseg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepPacAseg))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpF1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpF2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboAseguradora = New System.Windows.Forms.ComboBox()
        Me.chkTodo = New System.Windows.Forms.CheckBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pdImpresion = New System.Windows.Forms.PrintDialog()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.chkTodoS = New System.Windows.Forms.CheckBox()
        Me.cboEspecialidad = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotal1 = New System.Windows.Forms.Label()
        Me.lblTotal2 = New System.Windows.Forms.Label()
        Me.lblTotal3 = New System.Windows.Forms.Label()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Entre el"
        '
        'dtpF1
        '
        Me.dtpF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF1.Location = New System.Drawing.Point(95, 12)
        Me.dtpF1.Name = "dtpF1"
        Me.dtpF1.Size = New System.Drawing.Size(96, 20)
        Me.dtpF1.TabIndex = 1
        '
        'dtpF2
        '
        Me.dtpF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF2.Location = New System.Drawing.Point(232, 12)
        Me.dtpF2.Name = "dtpF2"
        Me.dtpF2.Size = New System.Drawing.Size(96, 20)
        Me.dtpF2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(199, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "y el"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(343, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Aseguradora"
        '
        'cboAseguradora
        '
        Me.cboAseguradora.FormattingEnabled = True
        Me.cboAseguradora.Location = New System.Drawing.Point(427, 13)
        Me.cboAseguradora.Name = "cboAseguradora"
        Me.cboAseguradora.Size = New System.Drawing.Size(232, 21)
        Me.cboAseguradora.TabIndex = 5
        '
        'chkTodo
        '
        Me.chkTodo.AutoSize = True
        Me.chkTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodo.Location = New System.Drawing.Point(674, 15)
        Me.chkTodo.Name = "chkTodo"
        Me.chkTodo.Size = New System.Drawing.Size(55, 17)
        Me.chkTodo.TabIndex = 6
        Me.chkTodo.Text = "Todo"
        Me.chkTodo.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(404, 44)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(485, 44)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 8
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(566, 44)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lvDet
        '
        Me.lvDet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader10, Me.ColumnHeader9})
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(12, 73)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(864, 333)
        Me.lvDet.TabIndex = 10
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Aseguradora"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fecha"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Historia"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Paciente"
        Me.ColumnHeader4.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Servicio"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "FAlta"
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "MontoFar"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "MontoPro"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Total"
        '
        'pdImpresion
        '
        Me.pdImpresion.Document = Me.pdcDocumento
        Me.pdImpresion.UseEXDialog = True
        '
        'pdcDocumento
        '
        Me.pdcDocumento.DocumentName = "Preliquidacion"
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.pdcDocumento
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
        'chkTodoS
        '
        Me.chkTodoS.AutoSize = True
        Me.chkTodoS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodoS.Location = New System.Drawing.Point(343, 46)
        Me.chkTodoS.Name = "chkTodoS"
        Me.chkTodoS.Size = New System.Drawing.Size(55, 17)
        Me.chkTodoS.TabIndex = 13
        Me.chkTodoS.Text = "Todo"
        Me.chkTodoS.UseVisualStyleBackColor = True
        '
        'cboEspecialidad
        '
        Me.cboEspecialidad.FormattingEnabled = True
        Me.cboEspecialidad.Location = New System.Drawing.Point(96, 44)
        Me.cboEspecialidad.Name = "cboEspecialidad"
        Me.cboEspecialidad.Size = New System.Drawing.Size(232, 21)
        Me.cboEspecialidad.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Origen"
        '
        'lblTotal1
        '
        Me.lblTotal1.BackColor = System.Drawing.Color.White
        Me.lblTotal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal1.Location = New System.Drawing.Point(521, 409)
        Me.lblTotal1.Name = "lblTotal1"
        Me.lblTotal1.Size = New System.Drawing.Size(81, 22)
        Me.lblTotal1.TabIndex = 14
        '
        'lblTotal2
        '
        Me.lblTotal2.BackColor = System.Drawing.Color.White
        Me.lblTotal2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal2.Location = New System.Drawing.Point(622, 409)
        Me.lblTotal2.Name = "lblTotal2"
        Me.lblTotal2.Size = New System.Drawing.Size(81, 22)
        Me.lblTotal2.TabIndex = 15
        '
        'lblTotal3
        '
        Me.lblTotal3.BackColor = System.Drawing.Color.White
        Me.lblTotal3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal3.Location = New System.Drawing.Point(720, 409)
        Me.lblTotal3.Name = "lblTotal3"
        Me.lblTotal3.Size = New System.Drawing.Size(81, 22)
        Me.lblTotal3.TabIndex = 16
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "NroPre"
        Me.ColumnHeader9.Width = 80
        '
        'frmRepPacAseg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 440)
        Me.Controls.Add(Me.lblTotal3)
        Me.Controls.Add(Me.lblTotal2)
        Me.Controls.Add(Me.lblTotal1)
        Me.Controls.Add(Me.chkTodoS)
        Me.Controls.Add(Me.cboEspecialidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lvDet)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.chkTodo)
        Me.Controls.Add(Me.cboAseguradora)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpF2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpF1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmRepPacAseg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Pacientes x Aseguradora"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpF1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpF2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboAseguradora As System.Windows.Forms.ComboBox
    Friend WithEvents chkTodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pdImpresion As System.Windows.Forms.PrintDialog
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents chkTodoS As System.Windows.Forms.CheckBox
    Friend WithEvents cboEspecialidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotal1 As System.Windows.Forms.Label
    Friend WithEvents lblTotal2 As System.Windows.Forms.Label
    Friend WithEvents lblTotal3 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
End Class
