<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaAtencionesSIS
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaAtencionesSIS))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpF1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpF2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPaciente = New System.Windows.Forms.TextBox()
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.pdImpresion = New System.Windows.Forms.PrintDialog()
        Me.dbCajaDataSet = New waSisSOAT.dbCajaDataSet()
        Me.tempRepAtenSISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tempRepAtenSISTableAdapter = New waSisSOAT.dbCajaDataSetTableAdapters.tempRepAtenSISTableAdapter()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalAten = New System.Windows.Forms.Label()
        Me.chkOrden = New System.Windows.Forms.CheckBox()
        CType(Me.dbCajaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tempRepAtenSISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Entre el"
        '
        'dtpF1
        '
        Me.dtpF1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF1.Location = New System.Drawing.Point(69, 9)
        Me.dtpF1.Name = "dtpF1"
        Me.dtpF1.Size = New System.Drawing.Size(101, 20)
        Me.dtpF1.TabIndex = 0
        '
        'dtpF2
        '
        Me.dtpF2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF2.Location = New System.Drawing.Point(209, 9)
        Me.dtpF2.Name = "dtpF2"
        Me.dtpF2.Size = New System.Drawing.Size(101, 20)
        Me.dtpF2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(176, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "y el"
        '
        'lvDet
        '
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(12, 64)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(668, 292)
        Me.lvDet.TabIndex = 4
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Formato"
        Me.ColumnHeader1.Width = 106
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Afiliado"
        Me.ColumnHeader2.Width = 111
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Situacion"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "PlanSis"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Historia"
        Me.ColumnHeader5.Width = 69
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Paciente"
        Me.ColumnHeader6.Width = 228
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "FecAtencion"
        Me.ColumnHeader7.Width = 86
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "FecAlta"
        Me.ColumnHeader8.Width = 86
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Referido"
        Me.ColumnHeader9.Width = 120
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Servicio"
        Me.ColumnHeader10.Width = 120
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Especialidad"
        Me.ColumnHeader11.Width = 150
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(15, 35)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(114, 35)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(209, 35)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(326, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Paciente"
        '
        'txtPaciente
        '
        Me.txtPaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaciente.Location = New System.Drawing.Point(384, 9)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(288, 20)
        Me.txtPaciente.TabIndex = 2
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
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.pdcDocumento
        '
        'pdImpresion
        '
        Me.pdImpresion.AllowCurrentPage = True
        Me.pdImpresion.AllowSelection = True
        Me.pdImpresion.AllowSomePages = True
        Me.pdImpresion.Document = Me.pdcDocumento
        Me.pdImpresion.PrintToFile = True
        Me.pdImpresion.ShowHelp = True
        Me.pdImpresion.UseEXDialog = True
        '
        'dbCajaDataSet
        '
        Me.dbCajaDataSet.DataSetName = "dbCajaDataSet"
        Me.dbCajaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tempRepAtenSISBindingSource
        '
        Me.tempRepAtenSISBindingSource.DataMember = "tempRepAtenSIS"
        Me.tempRepAtenSISBindingSource.DataSource = Me.dbCajaDataSet
        '
        'tempRepAtenSISTableAdapter
        '
        Me.tempRepAtenSISTableAdapter.ClearBeforeFill = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 363)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Total Atenciones"
        '
        'lblTotalAten
        '
        Me.lblTotalAten.BackColor = System.Drawing.Color.White
        Me.lblTotalAten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalAten.Location = New System.Drawing.Point(121, 363)
        Me.lblTotalAten.Name = "lblTotalAten"
        Me.lblTotalAten.Size = New System.Drawing.Size(112, 23)
        Me.lblTotalAten.TabIndex = 10
        Me.lblTotalAten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkOrden
        '
        Me.chkOrden.AutoSize = True
        Me.chkOrden.Location = New System.Drawing.Point(329, 39)
        Me.chkOrden.Name = "chkOrden"
        Me.chkOrden.Size = New System.Drawing.Size(187, 17)
        Me.chkOrden.TabIndex = 11
        Me.chkOrden.Text = "Ordenado por Nro de Formato SIS"
        Me.chkOrden.UseVisualStyleBackColor = True
        '
        'frmConsultaAtencionesSIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 395)
        Me.Controls.Add(Me.chkOrden)
        Me.Controls.Add(Me.lblTotalAten)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPaciente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lvDet)
        Me.Controls.Add(Me.dtpF2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpF1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnImprimir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaAtencionesSIS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Atenciones SIS"
        CType(Me.dbCajaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tempRepAtenSISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpF1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpF2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPaciente As System.Windows.Forms.TextBox
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents pdImpresion As System.Windows.Forms.PrintDialog
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tempRepAtenSISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dbCajaDataSet As waSisSOAT.dbCajaDataSet
    Friend WithEvents tempRepAtenSISTableAdapter As waSisSOAT.dbCajaDataSetTableAdapters.tempRepAtenSISTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalAten As System.Windows.Forms.Label
    Friend WithEvents chkOrden As System.Windows.Forms.CheckBox
End Class