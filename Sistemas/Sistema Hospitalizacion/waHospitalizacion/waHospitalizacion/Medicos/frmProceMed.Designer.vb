<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProceMed
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
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.cboCama = New System.Windows.Forms.ComboBox()
        Me.cboEspecialidad = New System.Windows.Forms.ComboBox()
        Me.cboSubServicio = New System.Windows.Forms.ComboBox()
        Me.cboServicio = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.lblEnfermeraIng = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblMedicoIng = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboEnfermeraO = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboResponsable = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.lblPrecioE = New System.Windows.Forms.Label()
        Me.txtExamenes = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalE = New System.Windows.Forms.Label()
        Me.gbFiltro = New System.Windows.Forms.GroupBox()
        Me.lvFiltro = New System.Windows.Forms.ListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRetornarF = New System.Windows.Forms.Button()
        Me.dgFiltro = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.lvCIE = New System.Windows.Forms.ListView()
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNroPre = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboTipoAtencion = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNumeroSIS = New System.Windows.Forms.TextBox()
        Me.txtSerieSIS = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnCodigo = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnBPac = New System.Windows.Forms.Button()
        Me.gbBPac = New System.Windows.Forms.GroupBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.btnRetBPac = New System.Windows.Forms.Button()
        Me.lvBPac = New System.Windows.Forms.ListView()
        Me.ColumnHeader59 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader61 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader62 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader63 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader64 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader65 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader66 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFPac = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblCuentaInicial = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnPendiente = New System.Windows.Forms.Button()
        Me.gbFiltro.SuspendLayout()
        CType(Me.dgFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBPac.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Location = New System.Drawing.Point(452, 173)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(234, 20)
        Me.dtpFecha.TabIndex = 10
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(345, 179)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(42, 13)
        Me.Label46.TabIndex = 201
        Me.Label46.Text = "Fecha"
        '
        'cboCama
        '
        Me.cboCama.FormattingEnabled = True
        Me.cboCama.Location = New System.Drawing.Point(453, 83)
        Me.cboCama.Name = "cboCama"
        Me.cboCama.Size = New System.Drawing.Size(210, 21)
        Me.cboCama.TabIndex = 4
        '
        'cboEspecialidad
        '
        Me.cboEspecialidad.FormattingEnabled = True
        Me.cboEspecialidad.Location = New System.Drawing.Point(117, 82)
        Me.cboEspecialidad.Name = "cboEspecialidad"
        Me.cboEspecialidad.Size = New System.Drawing.Size(213, 21)
        Me.cboEspecialidad.TabIndex = 3
        '
        'cboSubServicio
        '
        Me.cboSubServicio.FormattingEnabled = True
        Me.cboSubServicio.Location = New System.Drawing.Point(453, 61)
        Me.cboSubServicio.Name = "cboSubServicio"
        Me.cboSubServicio.Size = New System.Drawing.Size(274, 21)
        Me.cboSubServicio.TabIndex = 2
        '
        'cboServicio
        '
        Me.cboServicio.FormattingEnabled = True
        Me.cboServicio.Location = New System.Drawing.Point(117, 59)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(213, 21)
        Me.cboServicio.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(545, 11)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 13)
        Me.Label23.TabIndex = 196
        Me.Label23.Text = "Hora"
        '
        'lblHora
        '
        Me.lblHora.BackColor = System.Drawing.Color.White
        Me.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHora.Location = New System.Drawing.Point(580, 10)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(86, 23)
        Me.lblHora.TabIndex = 195
        '
        'lblEnfermeraIng
        '
        Me.lblEnfermeraIng.BackColor = System.Drawing.Color.White
        Me.lblEnfermeraIng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEnfermeraIng.Location = New System.Drawing.Point(453, 106)
        Me.lblEnfermeraIng.Name = "lblEnfermeraIng"
        Me.lblEnfermeraIng.Size = New System.Drawing.Size(274, 23)
        Me.lblEnfermeraIng.TabIndex = 194
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(345, 108)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(110, 13)
        Me.Label22.TabIndex = 193
        Me.Label22.Text = "Enfermera Ingreso"
        '
        'lblMedicoIng
        '
        Me.lblMedicoIng.BackColor = System.Drawing.Color.White
        Me.lblMedicoIng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedicoIng.Location = New System.Drawing.Point(117, 106)
        Me.lblMedicoIng.Name = "lblMedicoIng"
        Me.lblMedicoIng.Size = New System.Drawing.Size(213, 23)
        Me.lblMedicoIng.TabIndex = 192
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(12, 108)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(98, 13)
        Me.Label21.TabIndex = 191
        Me.Label21.Text = "Medico Ingreso "
        '
        'cboEnfermeraO
        '
        Me.cboEnfermeraO.FormattingEnabled = True
        Me.cboEnfermeraO.Location = New System.Drawing.Point(453, 130)
        Me.cboEnfermeraO.Name = "cboEnfermeraO"
        Me.cboEnfermeraO.Size = New System.Drawing.Size(213, 21)
        Me.cboEnfermeraO.TabIndex = 6
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(344, 130)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 13)
        Me.Label20.TabIndex = 190
        Me.Label20.Text = "Enfermera"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(345, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 188
        Me.Label14.Text = "Cama"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 187
        Me.Label13.Text = "Especialidad"
        '
        'cboResponsable
        '
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(117, 130)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(213, 21)
        Me.cboResponsable.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 186
        Me.Label8.Text = "Medico "
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.White
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.Location = New System.Drawing.Point(453, 11)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(86, 23)
        Me.lblFecha.TabIndex = 185
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(344, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 184
        Me.Label5.Text = "Fecha Ingreso"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(344, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 183
        Me.Label7.Text = "Sub Servicio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "Servicio"
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Location = New System.Drawing.Point(117, 35)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(421, 23)
        Me.lblPaciente.TabIndex = 181
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 180
        Me.Label4.Text = "Paciente"
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(117, 11)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(91, 20)
        Me.txtHistoria.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Historia Clinica"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(299, 470)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 20
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(201, 470)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(111, 470)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 18
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(20, 470)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 17
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtIndicacion
        '
        Me.txtIndicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicacion.Location = New System.Drawing.Point(120, 308)
        Me.txtIndicacion.Name = "txtIndicacion"
        Me.txtIndicacion.Size = New System.Drawing.Size(451, 20)
        Me.txtIndicacion.TabIndex = 15
        '
        'Label166
        '
        Me.Label166.AutoSize = True
        Me.Label166.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label166.Location = New System.Drawing.Point(17, 308)
        Me.Label166.Name = "Label166"
        Me.Label166.Size = New System.Drawing.Size(66, 13)
        Me.Label166.TabIndex = 218
        Me.Label166.Text = "Indicación"
        '
        'lblSTP
        '
        Me.lblSTP.BackColor = System.Drawing.Color.White
        Me.lblSTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTP.Location = New System.Drawing.Point(425, 288)
        Me.lblSTP.Name = "lblSTP"
        Me.lblSTP.Size = New System.Drawing.Size(147, 17)
        Me.lblSTP.TabIndex = 217
        '
        'lblTipoP
        '
        Me.lblTipoP.BackColor = System.Drawing.Color.White
        Me.lblTipoP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipoP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoP.Location = New System.Drawing.Point(280, 289)
        Me.lblTipoP.Name = "lblTipoP"
        Me.lblTipoP.Size = New System.Drawing.Size(139, 17)
        Me.lblTipoP.TabIndex = 216
        '
        'dgExamenes
        '
        Me.dgExamenes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader11, Me.ColumnHeader60, Me.ColumnHeader93})
        Me.dgExamenes.FullRowSelect = True
        Me.dgExamenes.GridLines = True
        Me.dgExamenes.Location = New System.Drawing.Point(17, 331)
        Me.dgExamenes.Name = "dgExamenes"
        Me.dgExamenes.Size = New System.Drawing.Size(710, 133)
        Me.dgExamenes.TabIndex = 16
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
        Me.Label95.Location = New System.Drawing.Point(17, 264)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(51, 13)
        Me.Label95.TabIndex = 214
        Me.Label95.Text = "Examen"
        '
        'txtCantidadE
        '
        Me.txtCantidadE.Location = New System.Drawing.Point(218, 286)
        Me.txtCantidadE.Name = "txtCantidadE"
        Me.txtCantidadE.Size = New System.Drawing.Size(45, 20)
        Me.txtCantidadE.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(179, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Cant"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.Location = New System.Drawing.Point(17, 283)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(43, 13)
        Me.Label94.TabIndex = 211
        Me.Label94.Text = "Precio"
        '
        'lblPrecioE
        '
        Me.lblPrecioE.BackColor = System.Drawing.Color.White
        Me.lblPrecioE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecioE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioE.Location = New System.Drawing.Point(121, 289)
        Me.lblPrecioE.Name = "lblPrecioE"
        Me.lblPrecioE.Size = New System.Drawing.Size(51, 17)
        Me.lblPrecioE.TabIndex = 210
        '
        'txtExamenes
        '
        Me.txtExamenes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExamenes.Location = New System.Drawing.Point(121, 267)
        Me.txtExamenes.Name = "txtExamenes"
        Me.txtExamenes.Size = New System.Drawing.Size(451, 20)
        Me.txtExamenes.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(382, 467)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 208
        Me.Label12.Text = "TOTAL"
        '
        'lblTotalE
        '
        Me.lblTotalE.BackColor = System.Drawing.Color.White
        Me.lblTotalE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalE.Location = New System.Drawing.Point(435, 465)
        Me.lblTotalE.Name = "lblTotalE"
        Me.lblTotalE.Size = New System.Drawing.Size(96, 25)
        Me.lblTotalE.TabIndex = 21
        Me.lblTotalE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbFiltro
        '
        Me.gbFiltro.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.gbFiltro.Controls.Add(Me.lvFiltro)
        Me.gbFiltro.Controls.Add(Me.Label2)
        Me.gbFiltro.Controls.Add(Me.btnRetornarF)
        Me.gbFiltro.Controls.Add(Me.dgFiltro)
        Me.gbFiltro.Controls.Add(Me.txtFiltro)
        Me.gbFiltro.Controls.Add(Me.Label88)
        Me.gbFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiltro.Location = New System.Drawing.Point(12, 308)
        Me.gbFiltro.Name = "gbFiltro"
        Me.gbFiltro.Size = New System.Drawing.Size(649, 272)
        Me.gbFiltro.TabIndex = 22
        Me.gbFiltro.TabStop = False
        Me.gbFiltro.Text = "Consulta General de Información"
        '
        'lvFiltro
        '
        Me.lvFiltro.FullRowSelect = True
        Me.lvFiltro.GridLines = True
        Me.lvFiltro.Location = New System.Drawing.Point(4, 50)
        Me.lvFiltro.Name = "lvFiltro"
        Me.lvFiltro.Size = New System.Drawing.Size(636, 202)
        Me.lvFiltro.TabIndex = 1
        Me.lvFiltro.UseCompatibleStateImageBehavior = False
        Me.lvFiltro.View = System.Windows.Forms.View.Details
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(9, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(381, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Presione la Tecla Enter para Seleccionar un Elemento de la Lista."
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
        Me.dgFiltro.Location = New System.Drawing.Point(12, 51)
        Me.dgFiltro.Name = "dgFiltro"
        Me.dgFiltro.ReadOnly = True
        Me.dgFiltro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFiltro.Size = New System.Drawing.Size(534, 202)
        Me.dgFiltro.TabIndex = 2
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
        'lvCIE
        '
        Me.lvCIE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader22, Me.ColumnHeader23})
        Me.lvCIE.FullRowSelect = True
        Me.lvCIE.GridLines = True
        Me.lvCIE.Location = New System.Drawing.Point(15, 204)
        Me.lvCIE.Name = "lvCIE"
        Me.lvCIE.Size = New System.Drawing.Size(712, 58)
        Me.lvCIE.TabIndex = 12
        Me.lvCIE.UseCompatibleStateImageBehavior = False
        Me.lvCIE.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "CIE"
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Descripcion"
        Me.ColumnHeader23.Width = 600
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 188)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Diagnosticos de Ingreso"
        '
        'txtNroPre
        '
        Me.txtNroPre.Location = New System.Drawing.Point(182, 172)
        Me.txtNroPre.Name = "txtNroPre"
        Me.txtNroPre.Size = New System.Drawing.Size(68, 20)
        Me.txtNroPre.TabIndex = 9
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 172)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(153, 13)
        Me.Label25.TabIndex = 273
        Me.Label25.Text = "Convenio/SOAT/AFOCAT"
        '
        'cboTipoAtencion
        '
        Me.cboTipoAtencion.FormattingEnabled = True
        Me.cboTipoAtencion.Items.AddRange(New Object() {"COMUN", "SIS", "SOAT", "CONVENIO", "PROGRAMA"})
        Me.cboTipoAtencion.Location = New System.Drawing.Point(117, 150)
        Me.cboTipoAtencion.Name = "cboTipoAtencion"
        Me.cboTipoAtencion.Size = New System.Drawing.Size(185, 21)
        Me.cboTipoAtencion.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 152)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 271
        Me.Label10.Text = "Tipo Paciente"
        '
        'txtNumeroSIS
        '
        Me.txtNumeroSIS.Location = New System.Drawing.Point(493, 152)
        Me.txtNumeroSIS.Name = "txtNumeroSIS"
        Me.txtNumeroSIS.Size = New System.Drawing.Size(78, 20)
        Me.txtNumeroSIS.TabIndex = 8
        '
        'txtSerieSIS
        '
        Me.txtSerieSIS.Location = New System.Drawing.Point(453, 152)
        Me.txtSerieSIS.Name = "txtSerieSIS"
        Me.txtSerieSIS.Size = New System.Drawing.Size(41, 20)
        Me.txtSerieSIS.TabIndex = 276
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(345, 153)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 13)
        Me.Label24.TabIndex = 275
        Me.Label24.Text = "Nro Formato SIS"
        '
        'btnCodigo
        '
        Me.btnCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCodigo.Location = New System.Drawing.Point(538, 467)
        Me.btnCodigo.Name = "btnCodigo"
        Me.btnCodigo.Size = New System.Drawing.Size(189, 29)
        Me.btnCodigo.TabIndex = 277
        Me.btnCodigo.Text = "Código SIS/SOAT/AFOCAT"
        Me.btnCodigo.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(21, 495)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(158, 13)
        Me.Label11.TabIndex = 278
        Me.Label11.Text = "Historia de Procedimientos"
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(12, 511)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(715, 133)
        Me.lvTabla.TabIndex = 279
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
        Me.ColumnHeader7.Text = "Cant"
        Me.ColumnHeader7.Width = 40
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Descripción"
        Me.ColumnHeader8.Width = 200
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "FecRegistro"
        Me.ColumnHeader9.Width = 80
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "FecCan"
        Me.ColumnHeader10.Width = 80
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "FecTomaMuest"
        Me.ColumnHeader12.Width = 80
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "FecResultado"
        Me.ColumnHeader13.Width = 80
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Resultado"
        Me.ColumnHeader14.Width = 200
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Especialidad"
        Me.ColumnHeader15.Width = 100
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "FecPendiente"
        Me.ColumnHeader16.Width = 80
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Precio"
        Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader18.Width = 0
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "PrecioReal"
        Me.ColumnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader19.Width = 0
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Importe"
        Me.ColumnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader20.Width = 0
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "ImporteReal"
        Me.ColumnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader21.Width = 0
        '
        'btnBPac
        '
        Me.btnBPac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBPac.Location = New System.Drawing.Point(218, 6)
        Me.btnBPac.Name = "btnBPac"
        Me.btnBPac.Size = New System.Drawing.Size(42, 23)
        Me.btnBPac.TabIndex = 280
        Me.btnBPac.Text = "&B"
        Me.btnBPac.UseVisualStyleBackColor = True
        '
        'gbBPac
        '
        Me.gbBPac.BackColor = System.Drawing.Color.Silver
        Me.gbBPac.Controls.Add(Me.Label57)
        Me.gbBPac.Controls.Add(Me.btnRetBPac)
        Me.gbBPac.Controls.Add(Me.lvBPac)
        Me.gbBPac.Controls.Add(Me.txtFPac)
        Me.gbBPac.Controls.Add(Me.Label58)
        Me.gbBPac.Location = New System.Drawing.Point(12, 7)
        Me.gbBPac.Name = "gbBPac"
        Me.gbBPac.Size = New System.Drawing.Size(702, 279)
        Me.gbBPac.TabIndex = 281
        Me.gbBPac.TabStop = False
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.Blue
        Me.Label57.Location = New System.Drawing.Point(19, 260)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(619, 13)
        Me.Label57.TabIndex = 101
        Me.Label57.Text = "En paciente, escriba los apellidos y presione ENTER.  Seleccione al paciente y pr" & _
            "esione ENTER de la lista."
        '
        'btnRetBPac
        '
        Me.btnRetBPac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetBPac.Location = New System.Drawing.Point(656, 15)
        Me.btnRetBPac.Name = "btnRetBPac"
        Me.btnRetBPac.Size = New System.Drawing.Size(28, 27)
        Me.btnRetBPac.TabIndex = 100
        Me.btnRetBPac.Text = "&X"
        Me.btnRetBPac.UseVisualStyleBackColor = True
        '
        'lvBPac
        '
        Me.lvBPac.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader59, Me.ColumnHeader17, Me.ColumnHeader61, Me.ColumnHeader62, Me.ColumnHeader63, Me.ColumnHeader64, Me.ColumnHeader65, Me.ColumnHeader66})
        Me.lvBPac.FullRowSelect = True
        Me.lvBPac.GridLines = True
        Me.lvBPac.Location = New System.Drawing.Point(13, 45)
        Me.lvBPac.Name = "lvBPac"
        Me.lvBPac.Size = New System.Drawing.Size(683, 206)
        Me.lvBPac.TabIndex = 99
        Me.lvBPac.UseCompatibleStateImageBehavior = False
        Me.lvBPac.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader59
        '
        Me.ColumnHeader59.Text = "Historia"
        Me.ColumnHeader59.Width = 80
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Apaterno"
        Me.ColumnHeader17.Width = 100
        '
        'ColumnHeader61
        '
        Me.ColumnHeader61.Text = "Amaterno"
        Me.ColumnHeader61.Width = 100
        '
        'ColumnHeader62
        '
        Me.ColumnHeader62.Text = "Nombres"
        Me.ColumnHeader62.Width = 100
        '
        'ColumnHeader63
        '
        Me.ColumnHeader63.Text = "FNacimiento"
        Me.ColumnHeader63.Width = 80
        '
        'ColumnHeader64
        '
        Me.ColumnHeader64.Text = "Sexo"
        '
        'ColumnHeader65
        '
        Me.ColumnHeader65.Text = "Papa"
        Me.ColumnHeader65.Width = 100
        '
        'ColumnHeader66
        '
        Me.ColumnHeader66.Text = "Mama"
        Me.ColumnHeader66.Width = 100
        '
        'txtFPac
        '
        Me.txtFPac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPac.Location = New System.Drawing.Point(92, 19)
        Me.txtFPac.Name = "txtFPac"
        Me.txtFPac.Size = New System.Drawing.Size(543, 20)
        Me.txtFPac.TabIndex = 97
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(10, 19)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(57, 13)
        Me.Label58.TabIndex = 98
        Me.Label58.Text = "Paciente"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(814, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(220, 13)
        Me.Label15.TabIndex = 282
        Me.Label15.Text = "Procedimientos Asignados a Paciente"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(309, 663)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 13)
        Me.Label16.TabIndex = 283
        Me.Label16.Text = "Cuenta Inicial"
        '
        'lblCuentaInicial
        '
        Me.lblCuentaInicial.BackColor = System.Drawing.Color.White
        Me.lblCuentaInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCuentaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuentaInicial.Location = New System.Drawing.Point(400, 662)
        Me.lblCuentaInicial.Name = "lblCuentaInicial"
        Me.lblCuentaInicial.Size = New System.Drawing.Size(108, 17)
        Me.lblCuentaInicial.TabIndex = 284
        Me.lblCuentaInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(549, 664)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 13)
        Me.Label17.TabIndex = 285
        Me.Label17.Text = "Total"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(591, 663)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(105, 17)
        Me.lblTotal.TabIndex = 286
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPendiente
        '
        Me.btnPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPendiente.Location = New System.Drawing.Point(12, 650)
        Me.btnPendiente.Name = "btnPendiente"
        Me.btnPendiente.Size = New System.Drawing.Size(153, 29)
        Me.btnPendiente.TabIndex = 287
        Me.btnPendiente.Text = "Pendiente de Pago"
        Me.btnPendiente.UseVisualStyleBackColor = True
        '
        'frmProceMed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 685)
        Me.Controls.Add(Me.btnPendiente)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblCuentaInicial)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.gbFiltro)
        Me.Controls.Add(Me.gbBPac)
        Me.Controls.Add(Me.lvTabla)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnCodigo)
        Me.Controls.Add(Me.txtIndicacion)
        Me.Controls.Add(Me.Label166)
        Me.Controls.Add(Me.lblSTP)
        Me.Controls.Add(Me.lblTipoP)
        Me.Controls.Add(Me.dgExamenes)
        Me.Controls.Add(Me.Label95)
        Me.Controls.Add(Me.txtCantidadE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label94)
        Me.Controls.Add(Me.lblPrecioE)
        Me.Controls.Add(Me.txtExamenes)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblTotalE)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.cboCama)
        Me.Controls.Add(Me.cboEspecialidad)
        Me.Controls.Add(Me.cboSubServicio)
        Me.Controls.Add(Me.cboServicio)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lblHora)
        Me.Controls.Add(Me.lblEnfermeraIng)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.lblMedicoIng)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cboEnfermeraO)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboResponsable)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lvCIE)
        Me.Controls.Add(Me.txtNumeroSIS)
        Me.Controls.Add(Me.txtSerieSIS)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtNroPre)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cboTipoAtencion)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnBPac)
        Me.Name = "frmProceMed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procedimientos Médicos"
        Me.gbFiltro.ResumeLayout(False)
        Me.gbFiltro.PerformLayout()
        CType(Me.dgFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBPac.ResumeLayout(False)
        Me.gbBPac.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cboCama As System.Windows.Forms.ComboBox
    Friend WithEvents cboEspecialidad As System.Windows.Forms.ComboBox
    Friend WithEvents cboSubServicio As System.Windows.Forms.ComboBox
    Friend WithEvents cboServicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents lblEnfermeraIng As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblMedicoIng As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboEnfermeraO As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents lblPrecioE As System.Windows.Forms.Label
    Friend WithEvents txtExamenes As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTotalE As System.Windows.Forms.Label
    Friend WithEvents gbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents lvFiltro As System.Windows.Forms.ListView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnRetornarF As System.Windows.Forms.Button
    Friend WithEvents dgFiltro As System.Windows.Forms.DataGridView
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents lvCIE As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNroPre As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAtencion As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSIS As System.Windows.Forms.TextBox
    Friend WithEvents txtSerieSIS As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnCodigo As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnBPac As System.Windows.Forms.Button
    Friend WithEvents gbBPac As System.Windows.Forms.GroupBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents btnRetBPac As System.Windows.Forms.Button
    Friend WithEvents lvBPac As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader59 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader61 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader62 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader63 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader64 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader65 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader66 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFPac As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblCuentaInicial As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents btnPendiente As System.Windows.Forms.Button
End Class
