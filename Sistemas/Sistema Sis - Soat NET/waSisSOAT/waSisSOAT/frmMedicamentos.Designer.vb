<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedicamentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicamentos))
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnRetornarF = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgFiltro = New System.Windows.Forms.DataGridView()
        Me.txtCantidadE = New System.Windows.Forms.TextBox()
        Me.gbFiltro = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtExamenes = New System.Windows.Forms.TextBox()
        Me.lblTotalE = New System.Windows.Forms.Label()
        Me.lblPrecioE = New System.Windows.Forms.Label()
        Me.txtCorrelativo = New System.Windows.Forms.MaskedTextBox()
        Me.txtNumeroA = New System.Windows.Forms.MaskedTextBox()
        Me.txtNumero = New System.Windows.Forms.MaskedTextBox()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboLoteA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblDISAHEI = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboLote = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblHEI = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lvMed = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblTotalMed = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblRN = New System.Windows.Forms.Label()
        CType(Me.dgFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Cant"
        '
        'txtFiltro
        '
        Me.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltro.Location = New System.Drawing.Point(59, 26)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(330, 20)
        Me.txtFiltro.TabIndex = 10
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Precio"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripcion"
        Me.ColumnHeader2.Width = 280
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
        'lvDet
        '
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(14, 198)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(533, 218)
        Me.lvDet.TabIndex = 58
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Importe"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(383, 431)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Total"
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(10, 427)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(292, 13)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Presione la Tecla Q para Quitar un Procedimiento."
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
        'txtCantidadE
        '
        Me.txtCantidadE.Location = New System.Drawing.Point(509, 172)
        Me.txtCantidadE.Name = "txtCantidadE"
        Me.txtCantidadE.Size = New System.Drawing.Size(41, 20)
        Me.txtCantidadE.TabIndex = 50
        '
        'gbFiltro
        '
        Me.gbFiltro.Controls.Add(Me.Label5)
        Me.gbFiltro.Controls.Add(Me.btnRetornarF)
        Me.gbFiltro.Controls.Add(Me.dgFiltro)
        Me.gbFiltro.Controls.Add(Me.txtFiltro)
        Me.gbFiltro.Controls.Add(Me.Label20)
        Me.gbFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiltro.Location = New System.Drawing.Point(10, 145)
        Me.gbFiltro.Name = "gbFiltro"
        Me.gbFiltro.Size = New System.Drawing.Size(549, 279)
        Me.gbFiltro.TabIndex = 56
        Me.gbFiltro.TabStop = False
        Me.gbFiltro.Text = "Consulta General de Información"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(502, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Cantidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(433, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Precio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Descripción"
        '
        'txtExamenes
        '
        Me.txtExamenes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExamenes.Location = New System.Drawing.Point(13, 172)
        Me.txtExamenes.Name = "txtExamenes"
        Me.txtExamenes.Size = New System.Drawing.Size(406, 20)
        Me.txtExamenes.TabIndex = 5
        '
        'lblTotalE
        '
        Me.lblTotalE.AutoSize = True
        Me.lblTotalE.BackColor = System.Drawing.Color.White
        Me.lblTotalE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalE.Location = New System.Drawing.Point(453, 431)
        Me.lblTotalE.Name = "lblTotalE"
        Me.lblTotalE.Size = New System.Drawing.Size(2, 15)
        Me.lblTotalE.TabIndex = 52
        '
        'lblPrecioE
        '
        Me.lblPrecioE.AutoSize = True
        Me.lblPrecioE.BackColor = System.Drawing.Color.White
        Me.lblPrecioE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecioE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioE.Location = New System.Drawing.Point(436, 172)
        Me.lblPrecioE.Name = "lblPrecioE"
        Me.lblPrecioE.Size = New System.Drawing.Size(2, 15)
        Me.lblPrecioE.TabIndex = 51
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorrelativo.Location = New System.Drawing.Point(513, 52)
        Me.txtCorrelativo.Mask = "000"
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Size = New System.Drawing.Size(37, 23)
        Me.txtCorrelativo.TabIndex = 4
        '
        'txtNumeroA
        '
        Me.txtNumeroA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroA.Location = New System.Drawing.Point(414, 52)
        Me.txtNumeroA.Mask = "00000000"
        Me.txtNumeroA.Name = "txtNumeroA"
        Me.txtNumeroA.Size = New System.Drawing.Size(80, 23)
        Me.txtNumeroA.TabIndex = 3
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(141, 51)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(80, 23)
        Me.txtNumero.TabIndex = 1
        '
        'lblHora
        '
        Me.lblHora.BackColor = System.Drawing.Color.White
        Me.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHora.Location = New System.Drawing.Point(513, 82)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(39, 15)
        Me.lblHora.TabIndex = 106
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(461, 82)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 105
        Me.Label15.Text = "HORA"
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.White
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(342, 82)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(113, 15)
        Me.lblFecha.TabIndex = 104
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(213, 86)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 13)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "FECHA ATENCION"
        '
        'lblHistoria
        '
        Me.lblHistoria.BackColor = System.Drawing.Color.White
        Me.lblHistoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoria.Location = New System.Drawing.Point(133, 84)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(74, 19)
        Me.lblHistoria.TabIndex = 102
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaciente.Location = New System.Drawing.Point(133, 109)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(322, 19)
        Me.lblPaciente.TabIndex = 101
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(31, 111)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 13)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "PACIENTE"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(29, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 99
        Me.Label14.Text = "HISTORIA"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(511, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "CORR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(314, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(209, 13)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "CODIGO INSCRIPCION / AFILIADO"
        '
        'cboLoteA
        '
        Me.cboLoteA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoteA.FormattingEnabled = True
        Me.cboLoteA.ItemHeight = 16
        Me.cboLoteA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cboLoteA.Location = New System.Drawing.Point(342, 52)
        Me.cboLoteA.Name = "cboLoteA"
        Me.cboLoteA.Size = New System.Drawing.Size(56, 24)
        Me.cboLoteA.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(421, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "NUMERO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(351, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "LOTE"
        '
        'lblDISAHEI
        '
        Me.lblDISAHEI.AutoSize = True
        Me.lblDISAHEI.BackColor = System.Drawing.Color.White
        Me.lblDISAHEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDISAHEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDISAHEI.Location = New System.Drawing.Point(294, 52)
        Me.lblDISAHEI.Name = "lblDISAHEI"
        Me.lblDISAHEI.Size = New System.Drawing.Size(33, 19)
        Me.lblDISAHEI.TabIndex = 93
        Me.lblDISAHEI.Text = "LIB"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(282, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "DISA/HEI"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(56, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(155, 13)
        Me.Label10.TabIndex = 91
        Me.Label10.Text = "FORMATO DE ATENCION"
        '
        'cboLote
        '
        Me.cboLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLote.FormattingEnabled = True
        Me.cboLote.Items.AddRange(New Object() {"07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cboLote.Location = New System.Drawing.Point(71, 52)
        Me.cboLote.Name = "cboLote"
        Me.cboLote.Size = New System.Drawing.Size(56, 24)
        Me.cboLote.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(150, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 13)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "NUMERO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(80, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "LOTE"
        '
        'lblHEI
        '
        Me.lblHEI.AutoSize = True
        Me.lblHEI.BackColor = System.Drawing.Color.White
        Me.lblHEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHEI.Location = New System.Drawing.Point(32, 52)
        Me.lblHEI.Name = "lblHEI"
        Me.lblHEI.Size = New System.Drawing.Size(33, 19)
        Me.lblHEI.TabIndex = 84
        Me.lblHEI.Text = "LIB"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(37, 36)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 88
        Me.Label19.Text = "HEI"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(448, 470)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 27)
        Me.btnCerrar.TabIndex = 109
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(252, 470)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cance&lar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(60, 470)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 27)
        Me.btnGrabar.TabIndex = 7
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(670, 18)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(242, 13)
        Me.Label21.TabIndex = 111
        Me.Label21.Text = "LISTA DE MEDICAMENTOS ASIGNADOS"
        '
        'lvMed
        '
        Me.lvMed.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lvMed.FullRowSelect = True
        Me.lvMed.GridLines = True
        Me.lvMed.Location = New System.Drawing.Point(565, 36)
        Me.lvMed.Name = "lvMed"
        Me.lvMed.Size = New System.Drawing.Size(460, 430)
        Me.lvMed.TabIndex = 112
        Me.lvMed.UseCompatibleStateImageBehavior = False
        Me.lvMed.View = System.Windows.Forms.View.Details
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
        'lblTotalMed
        '
        Me.lblTotalMed.AutoSize = True
        Me.lblTotalMed.BackColor = System.Drawing.Color.White
        Me.lblTotalMed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalMed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMed.Location = New System.Drawing.Point(963, 475)
        Me.lblTotalMed.Name = "lblTotalMed"
        Me.lblTotalMed.Size = New System.Drawing.Size(2, 15)
        Me.lblTotalMed.TabIndex = 196
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(794, 477)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(150, 13)
        Me.Label22.TabIndex = 195
        Me.Label22.Text = "TOTAL MEDICAMENTOS"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(461, 111)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(25, 13)
        Me.Label23.TabIndex = 197
        Me.Label23.Text = "RN"
        '
        'lblRN
        '
        Me.lblRN.BackColor = System.Drawing.Color.White
        Me.lblRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRN.Location = New System.Drawing.Point(513, 109)
        Me.lblRN.Name = "lblRN"
        Me.lblRN.Size = New System.Drawing.Size(39, 15)
        Me.lblRN.TabIndex = 198
        '
        'frmMedicamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 505)
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
        Me.Controls.Add(Me.lblHora)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label13)
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
        Me.Name = "frmMedicamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Medicamentos"
        CType(Me.dgFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFiltro.ResumeLayout(False)
        Me.gbFiltro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnRetornarF As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgFiltro As System.Windows.Forms.DataGridView
    Friend WithEvents txtCantidadE As System.Windows.Forms.TextBox
    Friend WithEvents gbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtExamenes As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalE As System.Windows.Forms.Label
    Friend WithEvents lblPrecioE As System.Windows.Forms.Label
    Friend WithEvents txtCorrelativo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNumeroA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboLoteA As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDISAHEI As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboLote As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblHEI As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lvMed As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTotalMed As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblRN As System.Windows.Forms.Label
End Class
