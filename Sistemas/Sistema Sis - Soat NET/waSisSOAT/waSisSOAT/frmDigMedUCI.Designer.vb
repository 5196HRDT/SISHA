<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDigMedUCI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDigMedUCI))
        Me.lblRN = New System.Windows.Forms.Label()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblTotalMed = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lvMed = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtCorrelativo = New System.Windows.Forms.MaskedTextBox()
        Me.txtNumeroA = New System.Windows.Forms.MaskedTextBox()
        Me.txtNumero = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dgFiltro = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboLoteA = New System.Windows.Forms.ComboBox()
        Me.btnRetornarF = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblDISAHEI = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboLote = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblHEI = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbFiltro = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtExamenes = New System.Windows.Forms.TextBox()
        Me.lblTotalE = New System.Windows.Forms.Label()
        Me.lblPrecioE = New System.Windows.Forms.Label()
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.txtCantidadE = New System.Windows.Forms.TextBox()
        Me.lblTotalPro = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblAutorizado = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        CType(Me.dgFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRN
        '
        Me.lblRN.BackColor = System.Drawing.Color.White
        Me.lblRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRN.Location = New System.Drawing.Point(504, 100)
        Me.lblRN.Name = "lblRN"
        Me.lblRN.Size = New System.Drawing.Size(39, 15)
        Me.lblRN.TabIndex = 242
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ID"
        Me.ColumnHeader6.Width = 40
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Descipción"
        Me.ColumnHeader7.Width = 220
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(452, 102)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(25, 13)
        Me.Label23.TabIndex = 241
        Me.Label23.Text = "RN"
        '
        'lblTotalMed
        '
        Me.lblTotalMed.BackColor = System.Drawing.Color.LightSalmon
        Me.lblTotalMed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalMed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMed.ForeColor = System.Drawing.Color.Black
        Me.lblTotalMed.Location = New System.Drawing.Point(918, 422)
        Me.lblTotalMed.Name = "lblTotalMed"
        Me.lblTotalMed.Size = New System.Drawing.Size(93, 22)
        Me.lblTotalMed.TabIndex = 240
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(812, 424)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 13)
        Me.Label22.TabIndex = 239
        Me.Label22.Text = "TOTAL MED S/."
        '
        'lvMed
        '
        Me.lvMed.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader15, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.lvMed.FullRowSelect = True
        Me.lvMed.GridLines = True
        Me.lvMed.Location = New System.Drawing.Point(556, 27)
        Me.lvMed.Name = "lvMed"
        Me.lvMed.Size = New System.Drawing.Size(460, 388)
        Me.lvMed.TabIndex = 238
        Me.lvMed.UseCompatibleStateImageBehavior = False
        Me.lvMed.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Precio"
        Me.ColumnHeader8.Width = 70
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Cantidad"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Importe"
        Me.ColumnHeader10.Width = 70
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Id"
        Me.ColumnHeader15.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "FecDig"
        Me.ColumnHeader11.Width = 80
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "HorDig"
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "UsuDig"
        Me.ColumnHeader13.Width = 80
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "FecAte"
        Me.ColumnHeader14.Width = 80
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(661, 9)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(242, 13)
        Me.Label21.TabIndex = 237
        Me.Label21.Text = "LISTA DE MEDICAMENTOS ASIGNADOS"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(439, 461)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 27)
        Me.btnCerrar.TabIndex = 236
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(243, 461)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 206
        Me.btnCancelar.Text = "Cance&lar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(51, 461)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 27)
        Me.btnGrabar.TabIndex = 205
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorrelativo.Location = New System.Drawing.Point(504, 43)
        Me.txtCorrelativo.Mask = "000"
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Size = New System.Drawing.Size(37, 23)
        Me.txtCorrelativo.TabIndex = 203
        '
        'txtNumeroA
        '
        Me.txtNumeroA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroA.Location = New System.Drawing.Point(405, 43)
        Me.txtNumeroA.Mask = "00000000"
        Me.txtNumeroA.Name = "txtNumeroA"
        Me.txtNumeroA.Size = New System.Drawing.Size(80, 23)
        Me.txtNumeroA.TabIndex = 202
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(132, 42)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(80, 23)
        Me.txtNumero.TabIndex = 200
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(452, 73)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 234
        Me.Label15.Text = "HORA"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(204, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 13)
        Me.Label13.TabIndex = 232
        Me.Label13.Text = "FECHA ATENCION"
        '
        'lblHora
        '
        Me.lblHora.BackColor = System.Drawing.Color.White
        Me.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHora.Location = New System.Drawing.Point(504, 73)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(39, 15)
        Me.lblHora.TabIndex = 235
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.White
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(333, 73)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(113, 15)
        Me.lblFecha.TabIndex = 233
        '
        'lblHistoria
        '
        Me.lblHistoria.BackColor = System.Drawing.Color.White
        Me.lblHistoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoria.Location = New System.Drawing.Point(124, 75)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(74, 19)
        Me.lblHistoria.TabIndex = 231
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaciente.Location = New System.Drawing.Point(124, 100)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(322, 19)
        Me.lblPaciente.TabIndex = 230
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Cant"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(22, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 13)
        Me.Label16.TabIndex = 229
        Me.Label16.Text = "PACIENTE"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(20, 77)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 228
        Me.Label14.Text = "HISTORIA"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(502, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 227
        Me.Label12.Text = "CORR"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Precio"
        '
        'dgFiltro
        '
        Me.dgFiltro.AllowUserToAddRows = False
        Me.dgFiltro.AllowUserToDeleteRows = False
        Me.dgFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFiltro.Location = New System.Drawing.Point(8, 51)
        Me.dgFiltro.Name = "dgFiltro"
        Me.dgFiltro.ReadOnly = True
        Me.dgFiltro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFiltro.Size = New System.Drawing.Size(534, 202)
        Me.dgFiltro.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(305, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(209, 13)
        Me.Label7.TabIndex = 226
        Me.Label7.Text = "CODIGO INSCRIPCION / AFILIADO"
        '
        'cboLoteA
        '
        Me.cboLoteA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoteA.FormattingEnabled = True
        Me.cboLoteA.ItemHeight = 16
        Me.cboLoteA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cboLoteA.Location = New System.Drawing.Point(333, 43)
        Me.cboLoteA.Name = "cboLoteA"
        Me.cboLoteA.Size = New System.Drawing.Size(56, 24)
        Me.cboLoteA.TabIndex = 201
        '
        'btnRetornarF
        '
        Me.btnRetornarF.Location = New System.Drawing.Point(435, 22)
        Me.btnRetornarF.Name = "btnRetornarF"
        Me.btnRetornarF.Size = New System.Drawing.Size(75, 24)
        Me.btnRetornarF.TabIndex = 11
        Me.btnRetornarF.Text = "&Retornar"
        Me.btnRetornarF.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(412, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 225
        Me.Label8.Text = "NUMERO"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(342, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 224
        Me.Label9.Text = "LOTE"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripcion"
        Me.ColumnHeader2.Width = 280
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Importe"
        '
        'lblDISAHEI
        '
        Me.lblDISAHEI.AutoSize = True
        Me.lblDISAHEI.BackColor = System.Drawing.Color.White
        Me.lblDISAHEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDISAHEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDISAHEI.Location = New System.Drawing.Point(285, 43)
        Me.lblDISAHEI.Name = "lblDISAHEI"
        Me.lblDISAHEI.Size = New System.Drawing.Size(33, 19)
        Me.lblDISAHEI.TabIndex = 223
        Me.lblDISAHEI.Text = "LIB"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(273, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 222
        Me.Label11.Text = "DISA/HEI"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(9, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Presione la Tecla I para Seleccionar."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(47, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(155, 13)
        Me.Label10.TabIndex = 221
        Me.Label10.Text = "FORMATO DE ATENCION"
        '
        'cboLote
        '
        Me.cboLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLote.FormattingEnabled = True
        Me.cboLote.Items.AddRange(New Object() {"07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cboLote.Location = New System.Drawing.Point(62, 43)
        Me.cboLote.Name = "cboLote"
        Me.cboLote.Size = New System.Drawing.Size(56, 24)
        Me.cboLote.TabIndex = 199
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Filtro"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(141, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 13)
        Me.Label17.TabIndex = 220
        Me.Label17.Text = "NUMERO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(71, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 219
        Me.Label18.Text = "LOTE"
        '
        'lblHEI
        '
        Me.lblHEI.AutoSize = True
        Me.lblHEI.BackColor = System.Drawing.Color.White
        Me.lblHEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHEI.Location = New System.Drawing.Point(23, 43)
        Me.lblHEI.Name = "lblHEI"
        Me.lblHEI.Size = New System.Drawing.Size(33, 19)
        Me.lblHEI.TabIndex = 217
        Me.lblHEI.Text = "LIB"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(28, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 218
        Me.Label19.Text = "HEI"
        '
        'txtFiltro
        '
        Me.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltro.Location = New System.Drawing.Point(59, 26)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(330, 20)
        Me.txtFiltro.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(374, 422)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 214
        Me.Label4.Text = "Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(1, 418)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(292, 13)
        Me.Label6.TabIndex = 216
        Me.Label6.Text = "Presione la Tecla Q para Quitar un Procedimiento."
        '
        'gbFiltro
        '
        Me.gbFiltro.Controls.Add(Me.Label5)
        Me.gbFiltro.Controls.Add(Me.btnRetornarF)
        Me.gbFiltro.Controls.Add(Me.dgFiltro)
        Me.gbFiltro.Controls.Add(Me.txtFiltro)
        Me.gbFiltro.Controls.Add(Me.Label20)
        Me.gbFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiltro.Location = New System.Drawing.Point(1, 136)
        Me.gbFiltro.Name = "gbFiltro"
        Me.gbFiltro.Size = New System.Drawing.Size(549, 279)
        Me.gbFiltro.TabIndex = 213
        Me.gbFiltro.TabStop = False
        Me.gbFiltro.Text = "Consulta General de Información"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(493, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 212
        Me.Label3.Text = "Cantidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(424, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 211
        Me.Label2.Text = "Precio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "Descripción"
        '
        'txtExamenes
        '
        Me.txtExamenes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExamenes.Location = New System.Drawing.Point(4, 163)
        Me.txtExamenes.Name = "txtExamenes"
        Me.txtExamenes.Size = New System.Drawing.Size(406, 20)
        Me.txtExamenes.TabIndex = 204
        '
        'lblTotalE
        '
        Me.lblTotalE.AutoSize = True
        Me.lblTotalE.BackColor = System.Drawing.Color.White
        Me.lblTotalE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalE.Location = New System.Drawing.Point(444, 422)
        Me.lblTotalE.Name = "lblTotalE"
        Me.lblTotalE.Size = New System.Drawing.Size(2, 15)
        Me.lblTotalE.TabIndex = 209
        '
        'lblPrecioE
        '
        Me.lblPrecioE.AutoSize = True
        Me.lblPrecioE.BackColor = System.Drawing.Color.White
        Me.lblPrecioE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecioE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioE.Location = New System.Drawing.Point(427, 163)
        Me.lblPrecioE.Name = "lblPrecioE"
        Me.lblPrecioE.Size = New System.Drawing.Size(2, 15)
        Me.lblPrecioE.TabIndex = 208
        '
        'lvDet
        '
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(5, 189)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(533, 218)
        Me.lvDet.TabIndex = 215
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'txtCantidadE
        '
        Me.txtCantidadE.Location = New System.Drawing.Point(500, 163)
        Me.txtCantidadE.Name = "txtCantidadE"
        Me.txtCantidadE.Size = New System.Drawing.Size(41, 20)
        Me.txtCantidadE.TabIndex = 207
        '
        'lblTotalPro
        '
        Me.lblTotalPro.BackColor = System.Drawing.Color.LightSalmon
        Me.lblTotalPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalPro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPro.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPro.Location = New System.Drawing.Point(659, 421)
        Me.lblTotalPro.Name = "lblTotalPro"
        Me.lblTotalPro.Size = New System.Drawing.Size(93, 22)
        Me.lblTotalPro.TabIndex = 244
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(553, 423)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(108, 13)
        Me.Label25.TabIndex = 243
        Me.Label25.Text = "TOTAL PROD S/."
        '
        'lblAutorizado
        '
        Me.lblAutorizado.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lblAutorizado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAutorizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutorizado.ForeColor = System.Drawing.Color.Black
        Me.lblAutorizado.Location = New System.Drawing.Point(659, 459)
        Me.lblAutorizado.Name = "lblAutorizado"
        Me.lblAutorizado.Size = New System.Drawing.Size(93, 22)
        Me.lblAutorizado.TabIndex = 246
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(553, 461)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(128, 13)
        Me.Label26.TabIndex = 245
        Me.Label26.Text = "Monto Autorizado S/."
        '
        'lblSaldo
        '
        Me.lblSaldo.BackColor = System.Drawing.Color.SeaShell
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.ForeColor = System.Drawing.Color.Black
        Me.lblSaldo.Location = New System.Drawing.Point(918, 458)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(93, 22)
        Me.lblSaldo.TabIndex = 248
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(837, 461)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(70, 13)
        Me.Label27.TabIndex = 247
        Me.Label27.Text = "SALDO S/."
        '
        'frmDigMedUCI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 490)
        Me.Controls.Add(Me.lblSaldo)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.lblAutorizado)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.lblTotalPro)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.lblRN)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lblTotalMed)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.lvMed)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.txtCorrelativo)
        Me.Controls.Add(Me.txtNumeroA)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblHora)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblHistoria)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboLoteA)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblDISAHEI)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboLote)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblHEI)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.gbFiltro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtExamenes)
        Me.Controls.Add(Me.lblTotalE)
        Me.Controls.Add(Me.lblPrecioE)
        Me.Controls.Add(Me.lvDet)
        Me.Controls.Add(Me.txtCantidadE)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDigMedUCI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Medicamentos UCI"
        CType(Me.dgFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFiltro.ResumeLayout(False)
        Me.gbFiltro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRN As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblTotalMed As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lvMed As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents txtCorrelativo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNumeroA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgFiltro As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboLoteA As System.Windows.Forms.ComboBox
    Friend WithEvents btnRetornarF As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblDISAHEI As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboLote As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblHEI As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtExamenes As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalE As System.Windows.Forms.Label
    Friend WithEvents lblPrecioE As System.Windows.Forms.Label
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents txtCantidadE As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTotalPro As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblAutorizado As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
