<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaPaciente
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
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.lblEstadoCivil = New System.Windows.Forms.Label()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.lblDistrito = New System.Windows.Forms.Label()
        Me.lblDpto = New System.Windows.Forms.Label()
        Me.lblInformante = New System.Windows.Forms.Label()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dtpFechaNcto = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblHoraAdmision = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFechaAdmision = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTEdadD = New System.Windows.Forms.Label()
        Me.lblEdadD = New System.Windows.Forms.Label()
        Me.lblTEdadM = New System.Windows.Forms.Label()
        Me.lblEdadM = New System.Windows.Forms.Label()
        Me.lblTEdad = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.btnBuscarP = New System.Windows.Forms.Button()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblTipoAtencion = New System.Windows.Forms.Label()
        Me.lblMedico = New System.Windows.Forms.Label()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblSerieSIS = New System.Windows.Forms.Label()
        Me.lblNumeroSIS = New System.Windows.Forms.Label()
        Me.lblPreliquidacion = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lvTablaA = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AyudaDiagnósticaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaboratorioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RayosXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EcografíaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatologíaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbAD = New System.Windows.Forms.GroupBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkPagoContado = New System.Windows.Forms.CheckBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.gbSI = New System.Windows.Forms.GroupBox()
        Me.btnRetornarSI = New System.Windows.Forms.Button()
        Me.lvSI = New System.Windows.Forms.ListView()
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.btnRetornarAD = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lvTablaP = New System.Windows.Forms.ListView()
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader37 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader38 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtProcedimiento = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lvSolicitado = New System.Windows.Forms.ListView()
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader36 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnPendiente = New System.Windows.Forms.Button()
        Me.ColumnHeader39 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader40 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1.SuspendLayout()
        Me.gbAD.SuspendLayout()
        Me.gbSI.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDomicilio
        '
        Me.lblDomicilio.BackColor = System.Drawing.Color.White
        Me.lblDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDomicilio.Location = New System.Drawing.Point(101, 113)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(604, 23)
        Me.lblDomicilio.TabIndex = 375
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Location = New System.Drawing.Point(180, 61)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(298, 23)
        Me.lblPaciente.TabIndex = 374
        '
        'lblEstadoCivil
        '
        Me.lblEstadoCivil.BackColor = System.Drawing.Color.White
        Me.lblEstadoCivil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstadoCivil.Location = New System.Drawing.Point(420, 88)
        Me.lblEstadoCivil.Name = "lblEstadoCivil"
        Me.lblEstadoCivil.Size = New System.Drawing.Size(100, 23)
        Me.lblEstadoCivil.TabIndex = 373
        '
        'lblGrado
        '
        Me.lblGrado.BackColor = System.Drawing.Color.White
        Me.lblGrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGrado.Location = New System.Drawing.Point(101, 87)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(211, 23)
        Me.lblGrado.TabIndex = 372
        '
        'lblProvincia
        '
        Me.lblProvincia.BackColor = System.Drawing.Color.White
        Me.lblProvincia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProvincia.Location = New System.Drawing.Point(418, 175)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(287, 23)
        Me.lblProvincia.TabIndex = 371
        '
        'lblDistrito
        '
        Me.lblDistrito.BackColor = System.Drawing.Color.White
        Me.lblDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDistrito.Location = New System.Drawing.Point(101, 203)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(211, 23)
        Me.lblDistrito.TabIndex = 370
        '
        'lblDpto
        '
        Me.lblDpto.BackColor = System.Drawing.Color.White
        Me.lblDpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDpto.Location = New System.Drawing.Point(101, 174)
        Me.lblDpto.Name = "lblDpto"
        Me.lblDpto.Size = New System.Drawing.Size(211, 23)
        Me.lblDpto.TabIndex = 369
        '
        'lblInformante
        '
        Me.lblInformante.BackColor = System.Drawing.Color.White
        Me.lblInformante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInformante.Location = New System.Drawing.Point(418, 203)
        Me.lblInformante.Name = "lblInformante"
        Me.lblInformante.Size = New System.Drawing.Size(287, 23)
        Me.lblInformante.TabIndex = 368
        '
        'lblSexo
        '
        Me.lblSexo.BackColor = System.Drawing.Color.White
        Me.lblSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSexo.Location = New System.Drawing.Point(608, 87)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(97, 23)
        Me.lblSexo.TabIndex = 367
        Me.lblSexo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 364
        Me.Label8.Text = "Edad"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(176, 300)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(387, 20)
        Me.Label37.TabIndex = 362
        Me.Label37.Text = "LISTA DE PROCEDIMIENTOS DE PACIENTES"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(326, 150)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(86, 13)
        Me.Label36.TabIndex = 361
        Me.Label36.Text = "Tipo Atención"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(11, 236)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 13)
        Me.Label28.TabIndex = 358
        Me.Label28.Text = "Servicio"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(326, 236)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(48, 13)
        Me.Label27.TabIndex = 357
        Me.Label27.Text = "Médico"
        '
        'dtpFechaNcto
        '
        Me.dtpFechaNcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNcto.Location = New System.Drawing.Point(607, 63)
        Me.dtpFechaNcto.Name = "dtpFechaNcto"
        Me.dtpFechaNcto.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaNcto.TabIndex = 335
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(521, 66)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 13)
        Me.Label26.TabIndex = 356
        Me.Label26.Text = "Fecha Ncto."
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(11, 201)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(47, 13)
        Me.Label25.TabIndex = 355
        Me.Label25.Text = "Distrito"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(326, 180)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 13)
        Me.Label24.TabIndex = 354
        Me.Label24.Text = "Provincia"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 175)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 353
        Me.Label12.Text = "Departamento"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(317, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 352
        Me.Label11.Text = "Estado Civil"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 351
        Me.Label10.Text = "Domicilio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 350
        Me.Label9.Text = "Grado Inst."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(326, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 349
        Me.Label6.Text = "Informante"
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(250, 37)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(62, 20)
        Me.txtHora.TabIndex = 332
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(210, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 348
        Me.Label5.Text = "Hora"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(101, 37)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(105, 20)
        Me.dtpFecha.TabIndex = 330
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 347
        Me.Label3.Text = "Fecha"
        '
        'lblHoraAdmision
        '
        Me.lblHoraAdmision.BackColor = System.Drawing.Color.White
        Me.lblHoraAdmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHoraAdmision.Location = New System.Drawing.Point(608, 36)
        Me.lblHoraAdmision.Name = "lblHoraAdmision"
        Me.lblHoraAdmision.Size = New System.Drawing.Size(100, 23)
        Me.lblHoraAdmision.TabIndex = 346
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(522, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 345
        Me.Label4.Text = "Hora Admisión"
        '
        'lblFechaAdmision
        '
        Me.lblFechaAdmision.BackColor = System.Drawing.Color.White
        Me.lblFechaAdmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFechaAdmision.Location = New System.Drawing.Point(420, 36)
        Me.lblFechaAdmision.Name = "lblFechaAdmision"
        Me.lblFechaAdmision.Size = New System.Drawing.Size(100, 23)
        Me.lblFechaAdmision.TabIndex = 344
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(318, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 343
        Me.Label2.Text = "Fecha Admisión"
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(101, 63)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(73, 20)
        Me.txtHistoria.TabIndex = 331
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 342
        Me.Label1.Text = "Paciente"
        '
        'lblTEdadD
        '
        Me.lblTEdadD.BackColor = System.Drawing.Color.White
        Me.lblTEdadD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdadD.Location = New System.Drawing.Point(284, 141)
        Me.lblTEdadD.Name = "lblTEdadD"
        Me.lblTEdadD.Size = New System.Drawing.Size(30, 23)
        Me.lblTEdadD.TabIndex = 381
        Me.lblTEdadD.Text = "A"
        Me.lblTEdadD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdadD
        '
        Me.lblEdadD.BackColor = System.Drawing.Color.White
        Me.lblEdadD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdadD.Location = New System.Drawing.Point(247, 141)
        Me.lblEdadD.Name = "lblEdadD"
        Me.lblEdadD.Size = New System.Drawing.Size(30, 23)
        Me.lblEdadD.TabIndex = 380
        Me.lblEdadD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTEdadM
        '
        Me.lblTEdadM.BackColor = System.Drawing.Color.White
        Me.lblTEdadM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdadM.Location = New System.Drawing.Point(211, 141)
        Me.lblTEdadM.Name = "lblTEdadM"
        Me.lblTEdadM.Size = New System.Drawing.Size(30, 23)
        Me.lblTEdadM.TabIndex = 379
        Me.lblTEdadM.Text = "M"
        Me.lblTEdadM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdadM
        '
        Me.lblEdadM.BackColor = System.Drawing.Color.White
        Me.lblEdadM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdadM.Location = New System.Drawing.Point(175, 141)
        Me.lblEdadM.Name = "lblEdadM"
        Me.lblEdadM.Size = New System.Drawing.Size(30, 23)
        Me.lblEdadM.TabIndex = 378
        Me.lblEdadM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTEdad
        '
        Me.lblTEdad.BackColor = System.Drawing.Color.White
        Me.lblTEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdad.Location = New System.Drawing.Point(138, 140)
        Me.lblTEdad.Name = "lblTEdad"
        Me.lblTEdad.Size = New System.Drawing.Size(31, 23)
        Me.lblTEdad.TabIndex = 366
        Me.lblTEdad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.White
        Me.lblEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdad.Location = New System.Drawing.Point(101, 140)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(31, 23)
        Me.lblEdad.TabIndex = 365
        Me.lblEdad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(526, 92)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(35, 13)
        Me.Label65.TabIndex = 382
        Me.Label65.Text = "Sexo"
        '
        'btnBuscarP
        '
        Me.btnBuscarP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarP.Location = New System.Drawing.Point(484, 62)
        Me.btnBuscarP.Name = "btnBuscarP"
        Me.btnBuscarP.Size = New System.Drawing.Size(36, 23)
        Me.btnBuscarP.TabIndex = 363
        Me.btnBuscarP.Text = "&B"
        Me.btnBuscarP.UseVisualStyleBackColor = True
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader40})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(20, 488)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(696, 141)
        Me.lvTabla.TabIndex = 384
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Cant"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Descripción"
        Me.ColumnHeader3.Width = 300
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Precio"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Importe"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Can"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Pendiente"
        Me.ColumnHeader7.Width = 80
        '
        'lblTipoAtencion
        '
        Me.lblTipoAtencion.BackColor = System.Drawing.Color.White
        Me.lblTipoAtencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipoAtencion.Location = New System.Drawing.Point(418, 149)
        Me.lblTipoAtencion.Name = "lblTipoAtencion"
        Me.lblTipoAtencion.Size = New System.Drawing.Size(287, 23)
        Me.lblTipoAtencion.TabIndex = 385
        '
        'lblMedico
        '
        Me.lblMedico.BackColor = System.Drawing.Color.White
        Me.lblMedico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedico.Location = New System.Drawing.Point(418, 233)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(287, 23)
        Me.lblMedico.TabIndex = 386
        '
        'lblServicio
        '
        Me.lblServicio.BackColor = System.Drawing.Color.White
        Me.lblServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblServicio.Location = New System.Drawing.Point(101, 233)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(211, 23)
        Me.lblServicio.TabIndex = 387
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(385, 635)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(93, 33)
        Me.btnCerrar.TabIndex = 391
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(267, 635)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(93, 33)
        Me.btnCancelar.TabIndex = 390
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(150, 635)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(93, 33)
        Me.btnGrabar.TabIndex = 389
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(22, 635)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(93, 33)
        Me.btnNuevo.TabIndex = 388
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 264)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 392
        Me.Label13.Text = "Formato SIS"
        '
        'lblSerieSIS
        '
        Me.lblSerieSIS.BackColor = System.Drawing.Color.White
        Me.lblSerieSIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSerieSIS.Location = New System.Drawing.Point(101, 264)
        Me.lblSerieSIS.Name = "lblSerieSIS"
        Me.lblSerieSIS.Size = New System.Drawing.Size(44, 23)
        Me.lblSerieSIS.TabIndex = 393
        Me.lblSerieSIS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumeroSIS
        '
        Me.lblNumeroSIS.BackColor = System.Drawing.Color.White
        Me.lblNumeroSIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumeroSIS.Location = New System.Drawing.Point(151, 264)
        Me.lblNumeroSIS.Name = "lblNumeroSIS"
        Me.lblNumeroSIS.Size = New System.Drawing.Size(126, 23)
        Me.lblNumeroSIS.TabIndex = 394
        Me.lblNumeroSIS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPreliquidacion
        '
        Me.lblPreliquidacion.BackColor = System.Drawing.Color.White
        Me.lblPreliquidacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreliquidacion.Location = New System.Drawing.Point(418, 264)
        Me.lblPreliquidacion.Name = "lblPreliquidacion"
        Me.lblPreliquidacion.Size = New System.Drawing.Size(102, 23)
        Me.lblPreliquidacion.TabIndex = 396
        Me.lblPreliquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(328, 264)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
        Me.Label15.TabIndex = 395
        Me.Label15.Text = "Preliquidación"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(591, 635)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(98, 23)
        Me.lblTotal.TabIndex = 398
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(520, 635)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 397
        Me.Label14.Text = "TOTAL S/"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 468)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 17)
        Me.Label7.TabIndex = 399
        Me.Label7.Text = "PENDIENTES"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 325)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(281, 17)
        Me.Label16.TabIndex = 400
        Me.Label16.Text = "CANCELADOS/ATENDIDOS/SIS/SOAT"
        '
        'lvTablaA
        '
        Me.lvTablaA.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader39})
        Me.lvTablaA.FullRowSelect = True
        Me.lvTablaA.GridLines = True
        Me.lvTablaA.Location = New System.Drawing.Point(20, 348)
        Me.lvTablaA.Name = "lvTablaA"
        Me.lvTablaA.Size = New System.Drawing.Size(696, 117)
        Me.lvTablaA.TabIndex = 401
        Me.lvTablaA.UseCompatibleStateImageBehavior = False
        Me.lvTablaA.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Id"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Cant"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Descripción"
        Me.ColumnHeader10.Width = 300
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Precio"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Importe"
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Can"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Pendiente"
        Me.ColumnHeader14.Width = 80
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaDiagnósticaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(721, 24)
        Me.MenuStrip1.TabIndex = 402
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AyudaDiagnósticaToolStripMenuItem
        '
        Me.AyudaDiagnósticaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LaboratorioToolStripMenuItem, Me.RayosXToolStripMenuItem, Me.EcografíaToolStripMenuItem, Me.PatologíaToolStripMenuItem, Me.ToolStripMenuItem1, Me.OtrosToolStripMenuItem})
        Me.AyudaDiagnósticaToolStripMenuItem.Name = "AyudaDiagnósticaToolStripMenuItem"
        Me.AyudaDiagnósticaToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.AyudaDiagnósticaToolStripMenuItem.Text = "Ayuda Diagnóstica"
        '
        'LaboratorioToolStripMenuItem
        '
        Me.LaboratorioToolStripMenuItem.Name = "LaboratorioToolStripMenuItem"
        Me.LaboratorioToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.LaboratorioToolStripMenuItem.Text = "Laboratorio"
        '
        'RayosXToolStripMenuItem
        '
        Me.RayosXToolStripMenuItem.Name = "RayosXToolStripMenuItem"
        Me.RayosXToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.RayosXToolStripMenuItem.Text = "Rayos X"
        '
        'EcografíaToolStripMenuItem
        '
        Me.EcografíaToolStripMenuItem.Name = "EcografíaToolStripMenuItem"
        Me.EcografíaToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.EcografíaToolStripMenuItem.Text = "Ecografía"
        '
        'PatologíaToolStripMenuItem
        '
        Me.PatologíaToolStripMenuItem.Name = "PatologíaToolStripMenuItem"
        Me.PatologíaToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PatologíaToolStripMenuItem.Text = "Patología"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(132, 6)
        '
        'OtrosToolStripMenuItem
        '
        Me.OtrosToolStripMenuItem.Name = "OtrosToolStripMenuItem"
        Me.OtrosToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.OtrosToolStripMenuItem.Text = "Enfermeria"
        '
        'gbAD
        '
        Me.gbAD.Controls.Add(Me.lblTipo)
        Me.gbAD.Controls.Add(Me.Label67)
        Me.gbAD.Controls.Add(Me.chkPagoContado)
        Me.gbAD.Controls.Add(Me.Label52)
        Me.gbAD.Controls.Add(Me.gbSI)
        Me.gbAD.Controls.Add(Me.txtCantidad)
        Me.gbAD.Controls.Add(Me.btnRetornarAD)
        Me.gbAD.Controls.Add(Me.Label17)
        Me.gbAD.Controls.Add(Me.Label49)
        Me.gbAD.Controls.Add(Me.lvTablaP)
        Me.gbAD.Controls.Add(Me.Label46)
        Me.gbAD.Controls.Add(Me.txtProcedimiento)
        Me.gbAD.Controls.Add(Me.Label45)
        Me.gbAD.Controls.Add(Me.btnAceptar)
        Me.gbAD.Controls.Add(Me.lblPrecio)
        Me.gbAD.Controls.Add(Me.Label47)
        Me.gbAD.Controls.Add(Me.lvSolicitado)
        Me.gbAD.Controls.Add(Me.btnPendiente)
        Me.gbAD.Location = New System.Drawing.Point(10, 36)
        Me.gbAD.Name = "gbAD"
        Me.gbAD.Size = New System.Drawing.Size(706, 387)
        Me.gbAD.TabIndex = 403
        Me.gbAD.TabStop = False
        Me.gbAD.Text = "Ayuda Diagnóstica"
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.White
        Me.lblTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipo.Location = New System.Drawing.Point(380, 59)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(95, 23)
        Me.lblTipo.TabIndex = 184
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.ForeColor = System.Drawing.Color.Red
        Me.Label67.Location = New System.Drawing.Point(137, 17)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(460, 13)
        Me.Label67.TabIndex = 182
        Me.Label67.Text = "Activar esta Opcion SOLO cuando es Paciente SIS/SOAT y debe pagar en caja"
        '
        'chkPagoContado
        '
        Me.chkPagoContado.AutoSize = True
        Me.chkPagoContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPagoContado.Location = New System.Drawing.Point(24, 16)
        Me.chkPagoContado.Name = "chkPagoContado"
        Me.chkPagoContado.Size = New System.Drawing.Size(106, 17)
        Me.chkPagoContado.TabIndex = 181
        Me.chkPagoContado.Text = "Pago Contado"
        Me.chkPagoContado.UseVisualStyleBackColor = True
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Red
        Me.Label52.Location = New System.Drawing.Point(15, 360)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(435, 13)
        Me.Label52.TabIndex = 179
        Me.Label52.Text = "(*) Presione la Tecla SUPR o DEL para Eliminar un Procedimiento Asignado"
        '
        'gbSI
        '
        Me.gbSI.Controls.Add(Me.btnRetornarSI)
        Me.gbSI.Controls.Add(Me.lvSI)
        Me.gbSI.Controls.Add(Me.txtDescripcion)
        Me.gbSI.Controls.Add(Me.Label48)
        Me.gbSI.Location = New System.Drawing.Point(49, 85)
        Me.gbSI.Name = "gbSI"
        Me.gbSI.Size = New System.Drawing.Size(551, 184)
        Me.gbSI.TabIndex = 176
        Me.gbSI.TabStop = False
        '
        'btnRetornarSI
        '
        Me.btnRetornarSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornarSI.Location = New System.Drawing.Point(506, 17)
        Me.btnRetornarSI.Name = "btnRetornarSI"
        Me.btnRetornarSI.Size = New System.Drawing.Size(28, 23)
        Me.btnRetornarSI.TabIndex = 176
        Me.btnRetornarSI.Text = "&X"
        Me.btnRetornarSI.UseVisualStyleBackColor = True
        '
        'lvSI
        '
        Me.lvSI.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader31, Me.ColumnHeader32})
        Me.lvSI.FullRowSelect = True
        Me.lvSI.GridLines = True
        Me.lvSI.Location = New System.Drawing.Point(12, 46)
        Me.lvSI.Name = "lvSI"
        Me.lvSI.Size = New System.Drawing.Size(522, 132)
        Me.lvSI.TabIndex = 12
        Me.lvSI.UseCompatibleStateImageBehavior = False
        Me.lvSI.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Codigo"
        Me.ColumnHeader15.Width = 0
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Descripcion"
        Me.ColumnHeader16.Width = 420
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Precio"
        Me.ColumnHeader17.Width = 80
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "Tipo"
        Me.ColumnHeader31.Width = 100
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "SubTipo"
        Me.ColumnHeader32.Width = 100
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(106, 20)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(379, 20)
        Me.txtDescripcion.TabIndex = 11
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(13, 23)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(74, 13)
        Me.Label48.TabIndex = 10
        Me.Label48.Text = "Descripción"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(114, 62)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(73, 20)
        Me.txtCantidad.TabIndex = 11
        '
        'btnRetornarAD
        '
        Me.btnRetornarAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornarAD.Location = New System.Drawing.Point(672, 11)
        Me.btnRetornarAD.Name = "btnRetornarAD"
        Me.btnRetornarAD.Size = New System.Drawing.Size(28, 23)
        Me.btnRetornarAD.TabIndex = 175
        Me.btnRetornarAD.Text = "&X"
        Me.btnRetornarAD.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Location = New System.Drawing.Point(582, 172)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 23)
        Me.Label17.TabIndex = 174
        Me.Label17.Visible = False
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(610, 154)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(36, 13)
        Me.Label49.TabIndex = 173
        Me.Label49.Text = "Total"
        Me.Label49.Visible = False
        '
        'lvTablaP
        '
        Me.lvTablaP.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader37, Me.ColumnHeader38})
        Me.lvTablaP.FullRowSelect = True
        Me.lvTablaP.GridLines = True
        Me.lvTablaP.Location = New System.Drawing.Point(15, 87)
        Me.lvTablaP.Name = "lvTablaP"
        Me.lvTablaP.Size = New System.Drawing.Size(543, 115)
        Me.lvTablaP.TabIndex = 172
        Me.lvTablaP.UseCompatibleStateImageBehavior = False
        Me.lvTablaP.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Codigo"
        Me.ColumnHeader18.Width = 0
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Cant"
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Descripcion"
        Me.ColumnHeader20.Width = 300
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Precio"
        Me.ColumnHeader21.Width = 80
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Importe"
        Me.ColumnHeader22.Width = 80
        '
        'ColumnHeader37
        '
        Me.ColumnHeader37.Text = "Tipo"
        Me.ColumnHeader37.Width = 100
        '
        'ColumnHeader38
        '
        Me.ColumnHeader38.Text = "SubTipo"
        Me.ColumnHeader38.Width = 100
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(21, 64)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(57, 13)
        Me.Label46.TabIndex = 10
        Me.Label46.Text = "Cantidad"
        '
        'txtProcedimiento
        '
        Me.txtProcedimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProcedimiento.Location = New System.Drawing.Point(114, 36)
        Me.txtProcedimiento.Name = "txtProcedimiento"
        Me.txtProcedimiento.Size = New System.Drawing.Size(361, 20)
        Me.txtProcedimiento.TabIndex = 9
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(21, 39)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(87, 13)
        Me.Label45.TabIndex = 8
        Me.Label45.Text = "Procedimiento"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(582, 76)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(93, 33)
        Me.btnAceptar.TabIndex = 177
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblPrecio
        '
        Me.lblPrecio.BackColor = System.Drawing.Color.White
        Me.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecio.Location = New System.Drawing.Point(274, 59)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(100, 23)
        Me.lblPrecio.TabIndex = 171
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(225, 62)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(43, 13)
        Me.Label47.TabIndex = 12
        Me.Label47.Text = "Precio"
        '
        'lvSolicitado
        '
        Me.lvSolicitado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader33, Me.ColumnHeader35, Me.ColumnHeader36, Me.ColumnHeader34})
        Me.lvSolicitado.FullRowSelect = True
        Me.lvSolicitado.GridLines = True
        Me.lvSolicitado.Location = New System.Drawing.Point(15, 208)
        Me.lvSolicitado.Name = "lvSolicitado"
        Me.lvSolicitado.Size = New System.Drawing.Size(685, 137)
        Me.lvSolicitado.TabIndex = 178
        Me.lvSolicitado.UseCompatibleStateImageBehavior = False
        Me.lvSolicitado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Codigo"
        Me.ColumnHeader23.Width = 0
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Cant"
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Descripcion"
        Me.ColumnHeader25.Width = 300
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Pagado"
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Resultado"
        Me.ColumnHeader27.Width = 300
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "IdDetalle"
        Me.ColumnHeader28.Width = 0
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "FechaCan"
        Me.ColumnHeader29.Width = 0
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "HoraCan"
        Me.ColumnHeader30.Width = 0
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "FechaMuestra"
        Me.ColumnHeader33.Width = 80
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Text = "FechaRes"
        Me.ColumnHeader35.Width = 80
        '
        'ColumnHeader36
        '
        Me.ColumnHeader36.Text = "HoraRes"
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "Pendiente"
        Me.ColumnHeader34.Width = 80
        '
        'btnPendiente
        '
        Me.btnPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPendiente.Location = New System.Drawing.Point(506, 347)
        Me.btnPendiente.Name = "btnPendiente"
        Me.btnPendiente.Size = New System.Drawing.Size(169, 33)
        Me.btnPendiente.TabIndex = 180
        Me.btnPendiente.Text = "&Pendiente de Pago"
        Me.btnPendiente.UseVisualStyleBackColor = True
        '
        'ColumnHeader39
        '
        Me.ColumnHeader39.Text = "IdDet"
        Me.ColumnHeader39.Width = 0
        '
        'ColumnHeader40
        '
        Me.ColumnHeader40.Text = "IdDet"
        Me.ColumnHeader40.Width = 0
        '
        'frmCuentaPaciente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 674)
        Me.Controls.Add(Me.gbAD)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lvTablaA)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblPreliquidacion)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblNumeroSIS)
        Me.Controls.Add(Me.lblSerieSIS)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.lblServicio)
        Me.Controls.Add(Me.lblMedico)
        Me.Controls.Add(Me.lblTipoAtencion)
        Me.Controls.Add(Me.lvTabla)
        Me.Controls.Add(Me.lblDomicilio)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.lblEstadoCivil)
        Me.Controls.Add(Me.lblGrado)
        Me.Controls.Add(Me.lblProvincia)
        Me.Controls.Add(Me.lblDistrito)
        Me.Controls.Add(Me.lblDpto)
        Me.Controls.Add(Me.lblInformante)
        Me.Controls.Add(Me.lblSexo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.dtpFechaNcto)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblHoraAdmision)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFechaAdmision)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTEdadD)
        Me.Controls.Add(Me.lblEdadD)
        Me.Controls.Add(Me.lblTEdadM)
        Me.Controls.Add(Me.lblEdadM)
        Me.Controls.Add(Me.lblTEdad)
        Me.Controls.Add(Me.lblEdad)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.btnBuscarP)
        Me.Name = "frmCuentaPaciente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuenta de Paciente"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gbAD.ResumeLayout(False)
        Me.gbAD.PerformLayout()
        Me.gbSI.ResumeLayout(False)
        Me.gbSI.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDomicilio As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents lblEstadoCivil As System.Windows.Forms.Label
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents lblProvincia As System.Windows.Forms.Label
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents lblDpto As System.Windows.Forms.Label
    Friend WithEvents lblInformante As System.Windows.Forms.Label
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaNcto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblHoraAdmision As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFechaAdmision As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTEdadD As System.Windows.Forms.Label
    Friend WithEvents lblEdadD As System.Windows.Forms.Label
    Friend WithEvents lblTEdadM As System.Windows.Forms.Label
    Friend WithEvents lblEdadM As System.Windows.Forms.Label
    Friend WithEvents lblTEdad As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarP As System.Windows.Forms.Button
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTipoAtencion As System.Windows.Forms.Label
    Friend WithEvents lblMedico As System.Windows.Forms.Label
    Friend WithEvents lblServicio As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblSerieSIS As System.Windows.Forms.Label
    Friend WithEvents lblNumeroSIS As System.Windows.Forms.Label
    Friend WithEvents lblPreliquidacion As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lvTablaA As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AyudaDiagnósticaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaboratorioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RayosXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EcografíaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatologíaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbAD As System.Windows.Forms.GroupBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkPagoContado As System.Windows.Forms.CheckBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents gbSI As System.Windows.Forms.GroupBox
    Friend WithEvents btnRetornarSI As System.Windows.Forms.Button
    Friend WithEvents lvSI As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents btnRetornarAD As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lvTablaP As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtProcedimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents lvSolicitado As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader33 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader35 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader36 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader34 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPendiente As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader31 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader32 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader37 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader38 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader40 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader39 As System.Windows.Forms.ColumnHeader
End Class
