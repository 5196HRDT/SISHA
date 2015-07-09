<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepPacSIS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepPacSIS))
        Me.btnImprimirI = New System.Windows.Forms.Button
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.lvI = New System.Windows.Forms.ListView
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument
        Me.pdImpresion = New System.Windows.Forms.PrintDialog
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnExcelBS = New System.Windows.Forms.Button
        Me.btnImprimirBS = New System.Windows.Forms.Button
        Me.lvBS = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader51 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader57 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader63 = New System.Windows.Forms.ColumnHeader
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lvB = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.btnImprimirB = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.lvH = New System.Windows.Forms.ListView
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.btnImprimirH = New System.Windows.Forms.Button
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.lvM = New System.Windows.Forms.ListView
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader19 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader20 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader21 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader22 = New System.Windows.Forms.ColumnHeader
        Me.btnMicrobiologia = New System.Windows.Forms.Button
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.dtpF2 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpF1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExcelB = New System.Windows.Forms.Button
        Me.btnExcelH = New System.Windows.Forms.Button
        Me.btnExcelI = New System.Windows.Forms.Button
        Me.btnExcelM = New System.Windows.Forms.Button
        Me.pBarra = New System.Windows.Forms.ProgressBar
        Me.TabPage4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnImprimirI
        '
        Me.btnImprimirI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirI.Location = New System.Drawing.Point(117, 318)
        Me.btnImprimirI.Name = "btnImprimirI"
        Me.btnImprimirI.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimirI.TabIndex = 12
        Me.btnImprimirI.Text = "&Imprimir"
        Me.btnImprimirI.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnExcelI)
        Me.TabPage4.Controls.Add(Me.lvI)
        Me.TabPage4.Controls.Add(Me.btnImprimirI)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(625, 360)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Inmunologia"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lvI
        '
        Me.lvI.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17})
        Me.lvI.FullRowSelect = True
        Me.lvI.GridLines = True
        Me.lvI.Location = New System.Drawing.Point(0, 0)
        Me.lvI.Name = "lvI"
        Me.lvI.Size = New System.Drawing.Size(616, 312)
        Me.lvI.TabIndex = 13
        Me.lvI.UseCompatibleStateImageBehavior = False
        Me.lvI.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Examen"
        Me.ColumnHeader13.Width = 258
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "EMER"
        Me.ColumnHeader14.Width = 100
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "HOSP"
        Me.ColumnHeader15.Width = 100
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "CON EXT"
        Me.ColumnHeader16.Width = 100
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Total"
        '
        'pdcDocumento
        '
        Me.pdcDocumento.DocumentName = "Preliquidacion"
        '
        'pdImpresion
        '
        Me.pdImpresion.AllowCurrentPage = True
        Me.pdImpresion.AllowSelection = True
        Me.pdImpresion.AllowSomePages = True
        Me.pdImpresion.PrintToFile = True
        Me.pdImpresion.ShowHelp = True
        Me.pdImpresion.UseEXDialog = True
        '
        'ppdVistaPrevia
        '
        Me.ppdVistaPrevia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdVistaPrevia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdVistaPrevia.ClientSize = New System.Drawing.Size(400, 300)
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
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(6, 34)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(633, 386)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnExcelBS)
        Me.TabPage1.Controls.Add(Me.btnImprimirBS)
        Me.TabPage1.Controls.Add(Me.lvBS)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(625, 360)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Banco de Sangre"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnExcelBS
        '
        Me.btnExcelBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelBS.Location = New System.Drawing.Point(442, 324)
        Me.btnExcelBS.Name = "btnExcelBS"
        Me.btnExcelBS.Size = New System.Drawing.Size(75, 23)
        Me.btnExcelBS.TabIndex = 12
        Me.btnExcelBS.Text = "&Excel"
        Me.btnExcelBS.UseVisualStyleBackColor = True
        '
        'btnImprimirBS
        '
        Me.btnImprimirBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirBS.Location = New System.Drawing.Point(117, 324)
        Me.btnImprimirBS.Name = "btnImprimirBS"
        Me.btnImprimirBS.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimirBS.TabIndex = 11
        Me.btnImprimirBS.Text = "&Imprimir"
        Me.btnImprimirBS.UseVisualStyleBackColor = True
        '
        'lvBS
        '
        Me.lvBS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader51, Me.ColumnHeader57, Me.ColumnHeader63})
        Me.lvBS.FullRowSelect = True
        Me.lvBS.GridLines = True
        Me.lvBS.Location = New System.Drawing.Point(4, 6)
        Me.lvBS.Name = "lvBS"
        Me.lvBS.Size = New System.Drawing.Size(616, 312)
        Me.lvBS.TabIndex = 2
        Me.lvBS.UseCompatibleStateImageBehavior = False
        Me.lvBS.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Examen"
        Me.ColumnHeader1.Width = 258
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "EMER"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader51
        '
        Me.ColumnHeader51.Text = "HOSP"
        Me.ColumnHeader51.Width = 100
        '
        'ColumnHeader57
        '
        Me.ColumnHeader57.Text = "CON EXT"
        Me.ColumnHeader57.Width = 100
        '
        'ColumnHeader63
        '
        Me.ColumnHeader63.Text = "Total"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnExcelB)
        Me.TabPage2.Controls.Add(Me.lvB)
        Me.TabPage2.Controls.Add(Me.btnImprimirB)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(625, 360)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bioquimica"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lvB
        '
        Me.lvB.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvB.FullRowSelect = True
        Me.lvB.GridLines = True
        Me.lvB.Location = New System.Drawing.Point(0, 0)
        Me.lvB.Name = "lvB"
        Me.lvB.Size = New System.Drawing.Size(616, 312)
        Me.lvB.TabIndex = 13
        Me.lvB.UseCompatibleStateImageBehavior = False
        Me.lvB.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Examen"
        Me.ColumnHeader3.Width = 258
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "EMER"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "HOSP"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "CON EXT"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Total"
        '
        'btnImprimirB
        '
        Me.btnImprimirB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirB.Location = New System.Drawing.Point(117, 318)
        Me.btnImprimirB.Name = "btnImprimirB"
        Me.btnImprimirB.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimirB.TabIndex = 12
        Me.btnImprimirB.Text = "&Imprimir"
        Me.btnImprimirB.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnExcelH)
        Me.TabPage3.Controls.Add(Me.lvH)
        Me.TabPage3.Controls.Add(Me.btnImprimirH)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(625, 360)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Hematologia"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lvH
        '
        Me.lvH.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12})
        Me.lvH.FullRowSelect = True
        Me.lvH.GridLines = True
        Me.lvH.Location = New System.Drawing.Point(0, 0)
        Me.lvH.Name = "lvH"
        Me.lvH.Size = New System.Drawing.Size(616, 312)
        Me.lvH.TabIndex = 13
        Me.lvH.UseCompatibleStateImageBehavior = False
        Me.lvH.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Examen"
        Me.ColumnHeader8.Width = 258
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "EMER"
        Me.ColumnHeader9.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "HOSP"
        Me.ColumnHeader10.Width = 100
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "CON EXT"
        Me.ColumnHeader11.Width = 100
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Total"
        '
        'btnImprimirH
        '
        Me.btnImprimirH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirH.Location = New System.Drawing.Point(130, 318)
        Me.btnImprimirH.Name = "btnImprimirH"
        Me.btnImprimirH.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimirH.TabIndex = 12
        Me.btnImprimirH.Text = "&Imprimir"
        Me.btnImprimirH.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.btnExcelM)
        Me.TabPage5.Controls.Add(Me.lvM)
        Me.TabPage5.Controls.Add(Me.btnMicrobiologia)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(625, 360)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Microbiologia"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lvM
        '
        Me.lvM.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22})
        Me.lvM.FullRowSelect = True
        Me.lvM.GridLines = True
        Me.lvM.Location = New System.Drawing.Point(0, 0)
        Me.lvM.Name = "lvM"
        Me.lvM.Size = New System.Drawing.Size(616, 312)
        Me.lvM.TabIndex = 13
        Me.lvM.UseCompatibleStateImageBehavior = False
        Me.lvM.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Examen"
        Me.ColumnHeader18.Width = 258
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "EMER"
        Me.ColumnHeader19.Width = 100
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "HOSP"
        Me.ColumnHeader20.Width = 100
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "CON EXT"
        Me.ColumnHeader21.Width = 100
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Total"
        '
        'btnMicrobiologia
        '
        Me.btnMicrobiologia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMicrobiologia.Location = New System.Drawing.Point(129, 318)
        Me.btnMicrobiologia.Name = "btnMicrobiologia"
        Me.btnMicrobiologia.Size = New System.Drawing.Size(75, 23)
        Me.btnMicrobiologia.TabIndex = 12
        Me.btnMicrobiologia.Text = "&Imprimir"
        Me.btnMicrobiologia.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(393, 4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 16
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(312, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 15
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpF2
        '
        Me.dtpF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF2.Location = New System.Drawing.Point(208, 5)
        Me.dtpF2.Name = "dtpF2"
        Me.dtpF2.Size = New System.Drawing.Size(98, 20)
        Me.dtpF2.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(175, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "y el"
        '
        'dtpF1
        '
        Me.dtpF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF1.Location = New System.Drawing.Point(60, 5)
        Me.dtpF1.Name = "dtpF1"
        Me.dtpF1.Size = New System.Drawing.Size(98, 20)
        Me.dtpF1.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Entre el"
        '
        'btnExcelB
        '
        Me.btnExcelB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelB.Location = New System.Drawing.Point(473, 318)
        Me.btnExcelB.Name = "btnExcelB"
        Me.btnExcelB.Size = New System.Drawing.Size(75, 23)
        Me.btnExcelB.TabIndex = 14
        Me.btnExcelB.Text = "&Excel"
        Me.btnExcelB.UseVisualStyleBackColor = True
        '
        'btnExcelH
        '
        Me.btnExcelH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelH.Location = New System.Drawing.Point(474, 318)
        Me.btnExcelH.Name = "btnExcelH"
        Me.btnExcelH.Size = New System.Drawing.Size(75, 23)
        Me.btnExcelH.TabIndex = 14
        Me.btnExcelH.Text = "&Excel"
        Me.btnExcelH.UseVisualStyleBackColor = True
        '
        'btnExcelI
        '
        Me.btnExcelI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelI.Location = New System.Drawing.Point(472, 318)
        Me.btnExcelI.Name = "btnExcelI"
        Me.btnExcelI.Size = New System.Drawing.Size(75, 23)
        Me.btnExcelI.TabIndex = 14
        Me.btnExcelI.Text = "&Excel"
        Me.btnExcelI.UseVisualStyleBackColor = True
        '
        'btnExcelM
        '
        Me.btnExcelM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelM.Location = New System.Drawing.Point(471, 318)
        Me.btnExcelM.Name = "btnExcelM"
        Me.btnExcelM.Size = New System.Drawing.Size(75, 23)
        Me.btnExcelM.TabIndex = 14
        Me.btnExcelM.Text = "&Excel"
        Me.btnExcelM.UseVisualStyleBackColor = True
        '
        'pBarra
        '
        Me.pBarra.Location = New System.Drawing.Point(474, 5)
        Me.pBarra.Name = "pBarra"
        Me.pBarra.Size = New System.Drawing.Size(156, 23)
        Me.pBarra.Step = 1
        Me.pBarra.TabIndex = 18
        '
        'frmRepPacSIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 424)
        Me.Controls.Add(Me.pBarra)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dtpF2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpF1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmRepPacSIS"
        Me.Text = "Reporte de Produccion de Laboratorio de Atenciones SIS"
        Me.TabPage4.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImprimirI As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdImpresion As System.Windows.Forms.PrintDialog
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnImprimirBS As System.Windows.Forms.Button
    Friend WithEvents lvBS As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader51 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader57 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader63 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnImprimirB As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnImprimirH As System.Windows.Forms.Button
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents btnMicrobiologia As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dtpF2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpF1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvB As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvI As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvH As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvM As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnExcelBS As System.Windows.Forms.Button
    Friend WithEvents btnExcelB As System.Windows.Forms.Button
    Friend WithEvents btnExcelI As System.Windows.Forms.Button
    Friend WithEvents btnExcelH As System.Windows.Forms.Button
    Friend WithEvents btnExcelM As System.Windows.Forms.Button
    Friend WithEvents pBarra As System.Windows.Forms.ProgressBar
End Class
