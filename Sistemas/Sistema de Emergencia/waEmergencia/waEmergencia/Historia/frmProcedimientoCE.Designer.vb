<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcedimientoCE
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
        Me.txtIndicacion = New System.Windows.Forms.TextBox()
        Me.Label166 = New System.Windows.Forms.Label()
        Me.lblSTP = New System.Windows.Forms.Label()
        Me.lblTipoP = New System.Windows.Forms.Label()
        Me.dgExamenes = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader60 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader93 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label95 = New System.Windows.Forms.Label()
        Me.txtCantidadE = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.lblPrecioE = New System.Windows.Forms.Label()
        Me.txtExamenes = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalE = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.gbFiltro = New System.Windows.Forms.GroupBox()
        Me.lvFiltro = New System.Windows.Forms.ListView()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnRetornarF = New System.Windows.Forms.Button()
        Me.dgFiltro = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboServicio = New System.Windows.Forms.ComboBox()
        Me.cboSubServicio = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbValidar = New System.Windows.Forms.GroupBox()
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbFiltro.SuspendLayout()
        CType(Me.dgFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbValidar.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIndicacion
        '
        Me.txtIndicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicacion.Location = New System.Drawing.Point(75, 189)
        Me.txtIndicacion.Name = "txtIndicacion"
        Me.txtIndicacion.Size = New System.Drawing.Size(451, 20)
        Me.txtIndicacion.TabIndex = 6
        '
        'Label166
        '
        Me.Label166.AutoSize = True
        Me.Label166.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label166.Location = New System.Drawing.Point(12, 192)
        Me.Label166.Name = "Label166"
        Me.Label166.Size = New System.Drawing.Size(66, 13)
        Me.Label166.TabIndex = 48
        Me.Label166.Text = "Indicación"
        '
        'lblSTP
        '
        Me.lblSTP.BackColor = System.Drawing.Color.White
        Me.lblSTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTP.Location = New System.Drawing.Point(380, 165)
        Me.lblSTP.Name = "lblSTP"
        Me.lblSTP.Size = New System.Drawing.Size(147, 17)
        Me.lblSTP.TabIndex = 47
        '
        'lblTipoP
        '
        Me.lblTipoP.BackColor = System.Drawing.Color.White
        Me.lblTipoP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipoP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoP.Location = New System.Drawing.Point(235, 166)
        Me.lblTipoP.Name = "lblTipoP"
        Me.lblTipoP.Size = New System.Drawing.Size(139, 17)
        Me.lblTipoP.TabIndex = 46
        '
        'dgExamenes
        '
        Me.dgExamenes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader11, Me.ColumnHeader60, Me.ColumnHeader93})
        Me.dgExamenes.FullRowSelect = True
        Me.dgExamenes.GridLines = True
        Me.dgExamenes.Location = New System.Drawing.Point(12, 215)
        Me.dgExamenes.Name = "dgExamenes"
        Me.dgExamenes.Size = New System.Drawing.Size(515, 133)
        Me.dgExamenes.TabIndex = 7
        Me.dgExamenes.UseCompatibleStateImageBehavior = False
        Me.dgExamenes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripción"
        Me.ColumnHeader2.Width = 320
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Precio"
        Me.ColumnHeader3.Width = 53
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cant"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Imp"
        Me.ColumnHeader6.Width = 55
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Tipo"
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader60
        '
        Me.ColumnHeader60.Text = "SubTipo"
        Me.ColumnHeader60.Width = 0
        '
        'ColumnHeader93
        '
        Me.ColumnHeader93.Text = "Indicación"
        Me.ColumnHeader93.Width = 200
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.Location = New System.Drawing.Point(12, 139)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(51, 13)
        Me.Label95.TabIndex = 44
        Me.Label95.Text = "Examen"
        '
        'txtCantidadE
        '
        Me.txtCantidadE.Location = New System.Drawing.Point(173, 163)
        Me.txtCantidadE.Name = "txtCantidadE"
        Me.txtCantidadE.Size = New System.Drawing.Size(45, 20)
        Me.txtCantidadE.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(142, 163)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Cant"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.Location = New System.Drawing.Point(12, 163)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(43, 13)
        Me.Label94.TabIndex = 41
        Me.Label94.Text = "Precio"
        '
        'lblPrecioE
        '
        Me.lblPrecioE.BackColor = System.Drawing.Color.White
        Me.lblPrecioE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecioE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioE.Location = New System.Drawing.Point(76, 166)
        Me.lblPrecioE.Name = "lblPrecioE"
        Me.lblPrecioE.Size = New System.Drawing.Size(51, 17)
        Me.lblPrecioE.TabIndex = 4
        '
        'txtExamenes
        '
        Me.txtExamenes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExamenes.Location = New System.Drawing.Point(76, 139)
        Me.txtExamenes.Name = "txtExamenes"
        Me.txtExamenes.Size = New System.Drawing.Size(451, 20)
        Me.txtExamenes.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(337, 351)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "TOTAL"
        '
        'lblTotalE
        '
        Me.lblTotalE.BackColor = System.Drawing.Color.White
        Me.lblTotalE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalE.Location = New System.Drawing.Point(408, 351)
        Me.lblTotalE.Name = "lblTotalE"
        Me.lblTotalE.Size = New System.Drawing.Size(96, 29)
        Me.lblTotalE.TabIndex = 37
        Me.lblTotalE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaciente.Location = New System.Drawing.Point(123, 38)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(363, 22)
        Me.lblPaciente.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Paciente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(123, 10)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(100, 20)
        Me.txtHistoria.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Nro de Historia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(318, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(380, 10)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(106, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(52, 400)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 8
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(148, 400)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 9
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(246, 400)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(340, 400)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 11
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'gbFiltro
        '
        Me.gbFiltro.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.gbFiltro.Controls.Add(Me.lvFiltro)
        Me.gbFiltro.Controls.Add(Me.Label20)
        Me.gbFiltro.Controls.Add(Me.btnRetornarF)
        Me.gbFiltro.Controls.Add(Me.dgFiltro)
        Me.gbFiltro.Controls.Add(Me.txtFiltro)
        Me.gbFiltro.Controls.Add(Me.Label88)
        Me.gbFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiltro.Location = New System.Drawing.Point(6, 139)
        Me.gbFiltro.Name = "gbFiltro"
        Me.gbFiltro.Size = New System.Drawing.Size(545, 272)
        Me.gbFiltro.TabIndex = 55
        Me.gbFiltro.TabStop = False
        Me.gbFiltro.Text = "Consulta General de Información"
        '
        'lvFiltro
        '
        Me.lvFiltro.FullRowSelect = True
        Me.lvFiltro.GridLines = True
        Me.lvFiltro.Location = New System.Drawing.Point(6, 55)
        Me.lvFiltro.Name = "lvFiltro"
        Me.lvFiltro.Size = New System.Drawing.Size(535, 202)
        Me.lvFiltro.TabIndex = 13
        Me.lvFiltro.UseCompatibleStateImageBehavior = False
        Me.lvFiltro.View = System.Windows.Forms.View.Details
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(9, 256)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(381, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Presione la Tecla Enter para Seleccionar un Elemento de la Lista."
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
        'dgFiltro
        '
        Me.dgFiltro.AllowUserToAddRows = False
        Me.dgFiltro.AllowUserToDeleteRows = False
        Me.dgFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFiltro.Location = New System.Drawing.Point(6, 52)
        Me.dgFiltro.Name = "dgFiltro"
        Me.dgFiltro.ReadOnly = True
        Me.dgFiltro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFiltro.Size = New System.Drawing.Size(534, 202)
        Me.dgFiltro.TabIndex = 12
        '
        'txtFiltro
        '
        Me.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltro.Location = New System.Drawing.Point(59, 26)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(330, 20)
        Me.txtFiltro.TabIndex = 10
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(6, 25)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(35, 13)
        Me.Label88.TabIndex = 0
        Me.Label88.Text = "Filtro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Servicio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboServicio
        '
        Me.cboServicio.FormattingEnabled = True
        Me.cboServicio.Location = New System.Drawing.Point(123, 66)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(237, 21)
        Me.cboServicio.TabIndex = 2
        '
        'cboSubServicio
        '
        Me.cboSubServicio.FormattingEnabled = True
        Me.cboSubServicio.Location = New System.Drawing.Point(123, 93)
        Me.cboSubServicio.Name = "cboSubServicio"
        Me.cboSubServicio.Size = New System.Drawing.Size(237, 21)
        Me.cboSubServicio.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Sub Servicio"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'gbValidar
        '
        Me.gbValidar.BackColor = System.Drawing.Color.Silver
        Me.gbValidar.Controls.Add(Me.btnRetornar)
        Me.gbValidar.Controls.Add(Me.btnAceptar)
        Me.gbValidar.Controls.Add(Me.txtClave)
        Me.gbValidar.Controls.Add(Me.Label7)
        Me.gbValidar.Controls.Add(Me.txtUsuario)
        Me.gbValidar.Controls.Add(Me.Label6)
        Me.gbValidar.Location = New System.Drawing.Point(156, 106)
        Me.gbValidar.Name = "gbValidar"
        Me.gbValidar.Size = New System.Drawing.Size(239, 128)
        Me.gbValidar.TabIndex = 59
        Me.gbValidar.TabStop = False
        Me.gbValidar.Text = "Validar Usuario"
        '
        'btnRetornar
        '
        Me.btnRetornar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornar.Location = New System.Drawing.Point(125, 99)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Size = New System.Drawing.Size(75, 23)
        Me.btnRetornar.TabIndex = 57
        Me.btnRetornar.Text = "&Retornar"
        Me.btnRetornar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(27, 99)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 56
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(100, 63)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(100, 20)
        Me.txtClave.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Clave"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Location = New System.Drawing.Point(100, 27)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuario.TabIndex = 52
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Usuario"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(690, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(193, 13)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Lista de Examenes No Atendidos"
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(566, 38)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(463, 190)
        Me.lvTabla.TabIndex = 61
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Id"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Descripcion"
        Me.ColumnHeader7.Width = 350
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "FechaReg"
        Me.ColumnHeader8.Width = 80
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(575, 231)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(414, 13)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "(*) Para eliminar seleccione el Examen y Presione la Tecla SUPR o DEL"
        '
        'frmProcedimientoCE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 431)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lvTabla)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.gbValidar)
        Me.Controls.Add(Me.cboServicio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gbFiltro)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIndicacion)
        Me.Controls.Add(Me.Label166)
        Me.Controls.Add(Me.lblSTP)
        Me.Controls.Add(Me.lblTipoP)
        Me.Controls.Add(Me.dgExamenes)
        Me.Controls.Add(Me.Label95)
        Me.Controls.Add(Me.txtCantidadE)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label94)
        Me.Controls.Add(Me.lblPrecioE)
        Me.Controls.Add(Me.txtExamenes)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblTotalE)
        Me.Controls.Add(Me.cboSubServicio)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmProcedimientoCE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procedimientos de Consulta Externa"
        Me.gbFiltro.ResumeLayout(False)
        Me.gbFiltro.PerformLayout()
        CType(Me.dgFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbValidar.ResumeLayout(False)
        Me.gbValidar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIndicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label166 As System.Windows.Forms.Label
    Friend WithEvents lblSTP As System.Windows.Forms.Label
    Friend WithEvents lblTipoP As System.Windows.Forms.Label
    Friend WithEvents dgExamenes As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader60 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader93 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadE As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents lblPrecioE As System.Windows.Forms.Label
    Friend WithEvents txtExamenes As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTotalE As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents gbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents lvFiltro As System.Windows.Forms.ListView
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnRetornarF As System.Windows.Forms.Button
    Friend WithEvents dgFiltro As System.Windows.Forms.DataGridView
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboServicio As System.Windows.Forms.ComboBox
    Friend WithEvents cboSubServicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbValidar As System.Windows.Forms.GroupBox
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
