<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlCuentaSIS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlCuentaSIS))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lvMed = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvSer = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblTotalMed = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblTotalSer = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCorrelativo = New System.Windows.Forms.MaskedTextBox()
        Me.txtNumeroA = New System.Windows.Forms.MaskedTextBox()
        Me.txtNumero = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboLoteA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblDISAHEI = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboLote = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblHEI = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblHoraAlta = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFechaAlta = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkAtendido = New System.Windows.Forms.CheckBox()
        Me.btnProcedimientos = New System.Windows.Forms.Button()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdImpresion = New System.Windows.Forms.PrintDialog()
        Me.lvCon = New System.Windows.Forms.ListView()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRayos = New System.Windows.Forms.Button()
        Me.pdInformeRX = New System.Drawing.Printing.PrintDocument()
        Me.pInformeRX = New System.Windows.Forms.PrintDialog()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.pdcFarmacia = New System.Drawing.Printing.PrintDocument()
        Me.lvMedR = New System.Windows.Forms.ListView()
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pdCostos = New System.Drawing.Printing.PrintDocument()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(446, 162)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(88, 25)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "C&ancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(559, 162)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(88, 25)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(26, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(304, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "INFORMACION DE CONSUMO DE MEDICAMENTOS"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(26, 331)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(271, 13)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "INFORMACION DE CONSUMO DE SERVICIOS"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(307, 162)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(125, 25)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.Text = "&Imprimir Medicina"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.BackColor = System.Drawing.Color.White
        Me.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHora.Location = New System.Drawing.Point(539, 78)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(2, 15)
        Me.lblHora.TabIndex = 88
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(478, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 87
        Me.Label15.Text = "HORA"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.White
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(327, 78)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(2, 15)
        Me.lblFecha.TabIndex = 86
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(198, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(114, 13)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "FECHA ATENCION"
        '
        'lblHistoria
        '
        Me.lblHistoria.AutoSize = True
        Me.lblHistoria.BackColor = System.Drawing.Color.White
        Me.lblHistoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoria.Location = New System.Drawing.Point(116, 80)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(2, 19)
        Me.lblHistoria.TabIndex = 84
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 13)
        Me.Label16.TabIndex = 83
        Me.Label16.Text = "HISTORIA"
        '
        'lblPaciente
        '
        Me.lblPaciente.AutoSize = True
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaciente.Location = New System.Drawing.Point(116, 108)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(2, 19)
        Me.lblPaciente.TabIndex = 90
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(14, 110)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 89
        Me.Label17.Text = "PACIENTE"
        '
        'lvMed
        '
        Me.lvMed.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvMed.FullRowSelect = True
        Me.lvMed.GridLines = True
        Me.lvMed.Location = New System.Drawing.Point(27, 208)
        Me.lvMed.Name = "lvMed"
        Me.lvMed.Size = New System.Drawing.Size(620, 119)
        Me.lvMed.TabIndex = 91
        Me.lvMed.UseCompatibleStateImageBehavior = False
        Me.lvMed.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descipción"
        Me.ColumnHeader2.Width = 320
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Precio"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Cantidad"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Importe"
        Me.ColumnHeader5.Width = 80
        '
        'lvSer
        '
        Me.lvSer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lvSer.FullRowSelect = True
        Me.lvSer.GridLines = True
        Me.lvSer.Location = New System.Drawing.Point(27, 347)
        Me.lvSer.Name = "lvSer"
        Me.lvSer.Size = New System.Drawing.Size(620, 131)
        Me.lvSer.TabIndex = 92
        Me.lvSer.UseCompatibleStateImageBehavior = False
        Me.lvSer.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ID"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Descipción"
        Me.ColumnHeader7.Width = 320
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Precio"
        Me.ColumnHeader8.Width = 80
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Cantidad"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Importe"
        Me.ColumnHeader10.Width = 80
        '
        'lblTotalMed
        '
        Me.lblTotalMed.AutoSize = True
        Me.lblTotalMed.BackColor = System.Drawing.Color.White
        Me.lblTotalMed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalMed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMed.Location = New System.Drawing.Point(566, 329)
        Me.lblTotalMed.Name = "lblTotalMed"
        Me.lblTotalMed.Size = New System.Drawing.Size(2, 15)
        Me.lblTotalMed.TabIndex = 94
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(397, 331)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(150, 13)
        Me.Label19.TabIndex = 93
        Me.Label19.Text = "TOTAL MEDICAMENTOS"
        '
        'lblTotalSer
        '
        Me.lblTotalSer.AutoSize = True
        Me.lblTotalSer.BackColor = System.Drawing.Color.White
        Me.lblTotalSer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalSer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSer.Location = New System.Drawing.Point(570, 479)
        Me.lblTotalSer.Name = "lblTotalSer"
        Me.lblTotalSer.Size = New System.Drawing.Size(2, 15)
        Me.lblTotalSer.TabIndex = 96
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(428, 481)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(117, 13)
        Me.Label20.TabIndex = 95
        Me.Label20.Text = "TOTAL SERVICIOS"
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorrelativo.Location = New System.Drawing.Point(535, 43)
        Me.txtCorrelativo.Mask = "000"
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Size = New System.Drawing.Size(37, 23)
        Me.txtCorrelativo.TabIndex = 4
        '
        'txtNumeroA
        '
        Me.txtNumeroA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroA.Location = New System.Drawing.Point(436, 43)
        Me.txtNumeroA.Mask = "00000000"
        Me.txtNumeroA.Name = "txtNumeroA"
        Me.txtNumeroA.Size = New System.Drawing.Size(80, 23)
        Me.txtNumeroA.TabIndex = 3
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(163, 42)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(80, 23)
        Me.txtNumero.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(533, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 112
        Me.Label12.Text = "CORR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(336, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(209, 13)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "CODIGO INSCRIPCION / AFILIADO"
        '
        'cboLoteA
        '
        Me.cboLoteA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoteA.FormattingEnabled = True
        Me.cboLoteA.ItemHeight = 16
        Me.cboLoteA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cboLoteA.Location = New System.Drawing.Point(364, 43)
        Me.cboLoteA.Name = "cboLoteA"
        Me.cboLoteA.Size = New System.Drawing.Size(56, 24)
        Me.cboLoteA.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(443, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "NUMERO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(373, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "LOTE"
        '
        'lblDISAHEI
        '
        Me.lblDISAHEI.AutoSize = True
        Me.lblDISAHEI.BackColor = System.Drawing.Color.White
        Me.lblDISAHEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDISAHEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDISAHEI.Location = New System.Drawing.Point(316, 43)
        Me.lblDISAHEI.Name = "lblDISAHEI"
        Me.lblDISAHEI.Size = New System.Drawing.Size(33, 19)
        Me.lblDISAHEI.TabIndex = 108
        Me.lblDISAHEI.Text = "LIB"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(304, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 107
        Me.Label11.Text = "DISA/HEI"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(78, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(155, 13)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "FORMATO DE ATENCION"
        '
        'cboLote
        '
        Me.cboLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLote.FormattingEnabled = True
        Me.cboLote.Items.AddRange(New Object() {"07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cboLote.Location = New System.Drawing.Point(93, 43)
        Me.cboLote.Name = "cboLote"
        Me.cboLote.Size = New System.Drawing.Size(56, 24)
        Me.cboLote.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(172, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "NUMERO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(102, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "LOTE"
        '
        'lblHEI
        '
        Me.lblHEI.AutoSize = True
        Me.lblHEI.BackColor = System.Drawing.Color.White
        Me.lblHEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHEI.Location = New System.Drawing.Point(54, 43)
        Me.lblHEI.Name = "lblHEI"
        Me.lblHEI.Size = New System.Drawing.Size(33, 19)
        Me.lblHEI.TabIndex = 98
        Me.lblHEI.Text = "LIB"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(59, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "HEI"
        '
        'lblHoraAlta
        '
        Me.lblHoraAlta.AutoSize = True
        Me.lblHoraAlta.BackColor = System.Drawing.Color.White
        Me.lblHoraAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHoraAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraAlta.Location = New System.Drawing.Point(539, 133)
        Me.lblHoraAlta.Name = "lblHoraAlta"
        Me.lblHoraAlta.Size = New System.Drawing.Size(2, 15)
        Me.lblHoraAlta.TabIndex = 116
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(443, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "HORA ALTA"
        '
        'lblFechaAlta
        '
        Me.lblFechaAlta.AutoSize = True
        Me.lblFechaAlta.BackColor = System.Drawing.Color.White
        Me.lblFechaAlta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFechaAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaAlta.Location = New System.Drawing.Point(327, 133)
        Me.lblFechaAlta.Name = "lblFechaAlta"
        Me.lblFechaAlta.Size = New System.Drawing.Size(2, 15)
        Me.lblFechaAlta.TabIndex = 114
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(198, 137)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 13)
        Me.Label21.TabIndex = 113
        Me.Label21.Text = "FECHA ALTA"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.BackColor = System.Drawing.Color.White
        Me.lblCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuenta.Location = New System.Drawing.Point(570, 501)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(2, 15)
        Me.lblCuenta.TabIndex = 118
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(416, 503)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 13)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "TOTAL CUENTA SIS"
        '
        'chkAtendido
        '
        Me.chkAtendido.AutoSize = True
        Me.chkAtendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAtendido.Location = New System.Drawing.Point(27, 162)
        Me.chkAtendido.Name = "chkAtendido"
        Me.chkAtendido.Size = New System.Drawing.Size(166, 17)
        Me.chkAtendido.TabIndex = 119
        Me.chkAtendido.Text = "Procedimientos Atendido"
        Me.chkAtendido.UseVisualStyleBackColor = True
        '
        'btnProcedimientos
        '
        Me.btnProcedimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcedimientos.Location = New System.Drawing.Point(12, 490)
        Me.btnProcedimientos.Name = "btnProcedimientos"
        Me.btnProcedimientos.Size = New System.Drawing.Size(158, 23)
        Me.btnProcedimientos.TabIndex = 120
        Me.btnProcedimientos.Text = "Imprimir &Procedimientos"
        Me.btnProcedimientos.UseVisualStyleBackColor = True
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.pdcDocumento
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
        'lvCon
        '
        Me.lvCon.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.lvCon.FullRowSelect = True
        Me.lvCon.GridLines = True
        Me.lvCon.Location = New System.Drawing.Point(29, 347)
        Me.lvCon.Name = "lvCon"
        Me.lvCon.Size = New System.Drawing.Size(600, 118)
        Me.lvCon.TabIndex = 121
        Me.lvCon.UseCompatibleStateImageBehavior = False
        Me.lvCon.View = System.Windows.Forms.View.Details
        Me.lvCon.Visible = False
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Descripcion"
        Me.ColumnHeader11.Width = 283
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Cant"
        Me.ColumnHeader12.Width = 37
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Descripcion"
        Me.ColumnHeader13.Width = 232
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Cant"
        Me.ColumnHeader14.Width = 40
        '
        'btnRayos
        '
        Me.btnRayos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRayos.Location = New System.Drawing.Point(175, 490)
        Me.btnRayos.Name = "btnRayos"
        Me.btnRayos.Size = New System.Drawing.Size(116, 23)
        Me.btnRayos.TabIndex = 122
        Me.btnRayos.Text = "Informe Rayos"
        Me.btnRayos.UseVisualStyleBackColor = True
        '
        'pdInformeRX
        '
        '
        'pInformeRX
        '
        Me.pInformeRX.Document = Me.pdInformeRX
        Me.pInformeRX.UseEXDialog = True
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(559, 9)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(100, 50)
        Me.pbImagen.TabIndex = 123
        Me.pbImagen.TabStop = False
        Me.pbImagen.Visible = False
        '
        'pdcFarmacia
        '
        '
        'lvMedR
        '
        Me.lvMedR.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18})
        Me.lvMedR.FullRowSelect = True
        Me.lvMedR.GridLines = True
        Me.lvMedR.Location = New System.Drawing.Point(27, 207)
        Me.lvMedR.Name = "lvMedR"
        Me.lvMedR.Size = New System.Drawing.Size(620, 119)
        Me.lvMedR.TabIndex = 124
        Me.lvMedR.UseCompatibleStateImageBehavior = False
        Me.lvMedR.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Cant"
        Me.ColumnHeader16.Width = 55
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Descripcion"
        Me.ColumnHeader17.Width = 480
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Importe"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(297, 490)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 23)
        Me.Button1.TabIndex = 125
        Me.Button1.Text = "Imp &Cuenta Proc"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pdCostos
        '
        Me.pdCostos.DocumentName = "Preliquidacion"
        '
        'frmControlCuentaSIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 525)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lvMedR)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.btnRayos)
        Me.Controls.Add(Me.lvCon)
        Me.Controls.Add(Me.btnProcedimientos)
        Me.Controls.Add(Me.chkAtendido)
        Me.Controls.Add(Me.lblCuenta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblHoraAlta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFechaAlta)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtCorrelativo)
        Me.Controls.Add(Me.txtNumeroA)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboLoteA)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblDISAHEI)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboLote)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblHEI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTotalSer)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lblTotalMed)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lvSer)
        Me.Controls.Add(Me.lvMed)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblHora)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblHistoria)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmControlCuentaSIS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Cuenta SIS"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lvMed As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSer As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTotalMed As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblTotalSer As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCorrelativo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNumeroA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboLoteA As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDISAHEI As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboLote As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblHEI As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHoraAlta As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFechaAlta As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkAtendido As System.Windows.Forms.CheckBox
    Friend WithEvents btnProcedimientos As System.Windows.Forms.Button
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdImpresion As System.Windows.Forms.PrintDialog
    Friend WithEvents lvCon As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRayos As System.Windows.Forms.Button
    Friend WithEvents pdInformeRX As System.Drawing.Printing.PrintDocument
    Friend WithEvents pInformeRX As System.Windows.Forms.PrintDialog
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents pdcFarmacia As System.Drawing.Printing.PrintDocument
    Friend WithEvents lvMedR As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pdCostos As System.Drawing.Printing.PrintDocument
End Class
