<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistorial))
        Me.txtIndicacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtExámenes = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboMedico = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboSecretaria = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboRadiologo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboTecnico = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSubServicio = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnPaciente = New System.Windows.Forms.Button()
        Me.gbPaciente = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lvPaciente = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtPaciente = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lvInforme = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fuente = New System.Windows.Forms.FontDialog()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.lblCie3 = New System.Windows.Forms.Label()
        Me.lblCie2 = New System.Windows.Forms.Label()
        Me.lblCie1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtInforme = New System.Windows.Forms.RichTextBox()
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.gbPaciente.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIndicacion
        '
        Me.txtIndicacion.Location = New System.Drawing.Point(88, 313)
        Me.txtIndicacion.Multiline = True
        Me.txtIndicacion.Name = "txtIndicacion"
        Me.txtIndicacion.Size = New System.Drawing.Size(373, 55)
        Me.txtIndicacion.TabIndex = 80
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 313)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Indicaciones"
        '
        'txtExámenes
        '
        Me.txtExámenes.Location = New System.Drawing.Point(88, 287)
        Me.txtExámenes.Name = "txtExámenes"
        Me.txtExámenes.Size = New System.Drawing.Size(373, 20)
        Me.txtExámenes.TabIndex = 78
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 290)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Exámenes"
        '
        'cboMedico
        '
        Me.cboMedico.FormattingEnabled = True
        Me.cboMedico.Location = New System.Drawing.Point(88, 259)
        Me.cboMedico.Name = "cboMedico"
        Me.cboMedico.Size = New System.Drawing.Size(373, 21)
        Me.cboMedico.TabIndex = 76
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 259)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Medico Sol"
        '
        'cboSecretaria
        '
        Me.cboSecretaria.FormattingEnabled = True
        Me.cboSecretaria.Location = New System.Drawing.Point(88, 230)
        Me.cboSecretaria.Name = "cboSecretaria"
        Me.cboSecretaria.Size = New System.Drawing.Size(373, 21)
        Me.cboSecretaria.TabIndex = 74
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 230)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "Secretaria"
        '
        'cboRadiologo
        '
        Me.cboRadiologo.FormattingEnabled = True
        Me.cboRadiologo.Location = New System.Drawing.Point(88, 201)
        Me.cboRadiologo.Name = "cboRadiologo"
        Me.cboRadiologo.Size = New System.Drawing.Size(373, 21)
        Me.cboRadiologo.TabIndex = 72
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Radiologo"
        '
        'cboTecnico
        '
        Me.cboTecnico.FormattingEnabled = True
        Me.cboTecnico.Location = New System.Drawing.Point(88, 174)
        Me.cboTecnico.Name = "cboTecnico"
        Me.cboTecnico.Size = New System.Drawing.Size(373, 21)
        Me.cboTecnico.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Técnico"
        '
        'lblSubServicio
        '
        Me.lblSubServicio.BackColor = System.Drawing.Color.White
        Me.lblSubServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubServicio.Location = New System.Drawing.Point(88, 149)
        Me.lblSubServicio.Name = "lblSubServicio"
        Me.lblSubServicio.Size = New System.Drawing.Size(373, 23)
        Me.lblSubServicio.TabIndex = 68
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Sub Servicio"
        '
        'lblServicio
        '
        Me.lblServicio.BackColor = System.Drawing.Color.White
        Me.lblServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblServicio.Location = New System.Drawing.Point(88, 114)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(252, 23)
        Me.lblServicio.TabIndex = 66
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Servicio"
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.White
        Me.lblEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdad.Location = New System.Drawing.Point(238, 84)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(102, 23)
        Me.lblEdad.TabIndex = 64
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(196, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Edad"
        '
        'lblSexo
        '
        Me.lblSexo.BackColor = System.Drawing.Color.White
        Me.lblSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSexo.Location = New System.Drawing.Point(88, 84)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(102, 23)
        Me.lblSexo.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Sexo"
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.White
        Me.lblTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipo.Location = New System.Drawing.Point(88, 38)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(102, 23)
        Me.lblTipo.TabIndex = 60
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Location = New System.Drawing.Point(88, 61)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(373, 23)
        Me.lblPaciente.TabIndex = 59
        '
        'lblHistoria
        '
        Me.lblHistoria.BackColor = System.Drawing.Color.White
        Me.lblHistoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHistoria.Location = New System.Drawing.Point(197, 38)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(102, 23)
        Me.lblHistoria.TabIndex = 58
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Paciente"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 447)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Informe"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(503, 570)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 84
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(335, 570)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 83
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnPaciente
        '
        Me.btnPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaciente.Location = New System.Drawing.Point(305, 35)
        Me.btnPaciente.Name = "btnPaciente"
        Me.btnPaciente.Size = New System.Drawing.Size(75, 23)
        Me.btnPaciente.TabIndex = 1
        Me.btnPaciente.Text = "&Paciente"
        Me.btnPaciente.UseVisualStyleBackColor = True
        '
        'gbPaciente
        '
        Me.gbPaciente.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.gbPaciente.Controls.Add(Me.btnRetornar)
        Me.gbPaciente.Controls.Add(Me.Label16)
        Me.gbPaciente.Controls.Add(Me.lvPaciente)
        Me.gbPaciente.Controls.Add(Me.txtPaciente)
        Me.gbPaciente.Controls.Add(Me.Label13)
        Me.gbPaciente.Location = New System.Drawing.Point(2, 61)
        Me.gbPaciente.Name = "gbPaciente"
        Me.gbPaciente.Size = New System.Drawing.Size(536, 340)
        Me.gbPaciente.TabIndex = 86
        Me.gbPaciente.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(6, 311)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(354, 13)
        Me.Label16.TabIndex = 61
        Me.Label16.Text = "Seleccione un paciente de la lista y presione la tecla ENTER"
        '
        'lvPaciente
        '
        Me.lvPaciente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvPaciente.FullRowSelect = True
        Me.lvPaciente.GridLines = True
        Me.lvPaciente.Location = New System.Drawing.Point(3, 39)
        Me.lvPaciente.Name = "lvPaciente"
        Me.lvPaciente.Size = New System.Drawing.Size(523, 262)
        Me.lvPaciente.TabIndex = 60
        Me.lvPaciente.UseCompatibleStateImageBehavior = False
        Me.lvPaciente.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Historia"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Paciente"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Sexo"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Papa"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Mama"
        Me.ColumnHeader5.Width = 80
        '
        'txtPaciente
        '
        Me.txtPaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaciente.Location = New System.Drawing.Point(133, 13)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(311, 20)
        Me.txtPaciente.TabIndex = 59
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 13)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Apellidos y Nombres"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 87
        Me.Label14.Text = "Tipo"
        '
        'cboTipo
        '
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {"RADIOGRAFIA", "ECOGRAFIA"})
        Me.cboTipo.Location = New System.Drawing.Point(86, 9)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(146, 21)
        Me.cboTipo.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(641, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 20)
        Me.Label15.TabIndex = 61
        Me.Label15.Text = "Informes"
        '
        'lvInforme
        '
        Me.lvInforme.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lvInforme.FullRowSelect = True
        Me.lvInforme.GridLines = True
        Me.lvInforme.Location = New System.Drawing.Point(467, 35)
        Me.lvInforme.Name = "lvInforme"
        Me.lvInforme.Size = New System.Drawing.Size(439, 406)
        Me.lvInforme.TabIndex = 62
        Me.lvInforme.UseCompatibleStateImageBehavior = False
        Me.lvInforme.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "IdInforme"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fecha"
        Me.ColumnHeader7.Width = 80
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Título"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Descripcion"
        Me.ColumnHeader9.Width = 300
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "TipoPac"
        '
        'pdcDocumento
        '
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
        'lblCie3
        '
        Me.lblCie3.BackColor = System.Drawing.Color.White
        Me.lblCie3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCie3.Location = New System.Drawing.Point(88, 418)
        Me.lblCie3.Name = "lblCie3"
        Me.lblCie3.Size = New System.Drawing.Size(373, 23)
        Me.lblCie3.TabIndex = 93
        '
        'lblCie2
        '
        Me.lblCie2.BackColor = System.Drawing.Color.White
        Me.lblCie2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCie2.Location = New System.Drawing.Point(88, 395)
        Me.lblCie2.Name = "lblCie2"
        Me.lblCie2.Size = New System.Drawing.Size(373, 23)
        Me.lblCie2.TabIndex = 91
        '
        'lblCie1
        '
        Me.lblCie1.BackColor = System.Drawing.Color.White
        Me.lblCie1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCie1.Location = New System.Drawing.Point(88, 372)
        Me.lblCie1.Name = "lblCie1"
        Me.lblCie1.Size = New System.Drawing.Size(373, 23)
        Me.lblCie1.TabIndex = 89
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 418)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 13)
        Me.Label17.TabIndex = 96
        Me.Label17.Text = "Dx 3"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 395)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 13)
        Me.Label18.TabIndex = 95
        Me.Label18.Text = "Dx 2"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 372)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(33, 13)
        Me.Label19.TabIndex = 94
        Me.Label19.Text = "Dx 1"
        '
        'txtInforme
        '
        Me.txtInforme.Location = New System.Drawing.Point(11, 463)
        Me.txtInforme.Name = "txtInforme"
        Me.txtInforme.Size = New System.Drawing.Size(895, 101)
        Me.txtInforme.TabIndex = 97
        Me.txtInforme.Text = ""
        '
        'btnRetornar
        '
        Me.btnRetornar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornar.Location = New System.Drawing.Point(490, 10)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Size = New System.Drawing.Size(35, 23)
        Me.btnRetornar.TabIndex = 62
        Me.btnRetornar.Text = "&X"
        Me.btnRetornar.UseVisualStyleBackColor = True
        '
        'frmHistorial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 600)
        Me.Controls.Add(Me.txtInforme)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.gbPaciente)
        Me.Controls.Add(Me.btnPaciente)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtIndicacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtExámenes)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboMedico)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboSecretaria)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboRadiologo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboTecnico)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblSubServicio)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblServicio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblEdad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSexo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.lblHistoria)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lvInforme)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblCie3)
        Me.Controls.Add(Me.lblCie2)
        Me.Controls.Add(Me.lblCie1)
        Me.Name = "frmHistorial"
        Me.Text = "Historial de Informes de Pacientes"
        Me.gbPaciente.ResumeLayout(False)
        Me.gbPaciente.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIndicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtExámenes As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboMedico As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboSecretaria As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboRadiologo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTecnico As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSubServicio As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblServicio As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnPaciente As System.Windows.Forms.Button
    Friend WithEvents gbPaciente As System.Windows.Forms.GroupBox
    Friend WithEvents txtPaciente As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lvPaciente As System.Windows.Forms.ListView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lvInforme As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Fuente As System.Windows.Forms.FontDialog
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblCie3 As System.Windows.Forms.Label
    Friend WithEvents lblCie2 As System.Windows.Forms.Label
    Friend WithEvents lblCie1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtInforme As System.Windows.Forms.RichTextBox
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
End Class
