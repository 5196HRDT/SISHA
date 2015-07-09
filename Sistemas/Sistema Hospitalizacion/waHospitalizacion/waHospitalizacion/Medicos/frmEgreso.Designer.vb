<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEgreso
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
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.MaskedTextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboTipoAlta = New System.Windows.Forms.ComboBox()
        Me.cboCondicionAlta = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboResponsable = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.txtCIE = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.cboReferido = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.gbConsulta = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.cboEspecialidad = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboSubServicio = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboServicio = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboEnfermera = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.btnBPac = New System.Windows.Forms.Button()
        Me.gbBPac = New System.Windows.Forms.GroupBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.btnRetBPac = New System.Windows.Forms.Button()
        Me.lvBPac = New System.Windows.Forms.ListView()
        Me.ColumnHeader59 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader61 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader62 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader63 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader64 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader65 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader66 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFPac = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.gbConsulta.SuspendLayout()
        Me.gbBPac.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.White
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.Location = New System.Drawing.Point(313, 10)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(86, 23)
        Me.lblFecha.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(227, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Fecha Ingreso"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(500, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Paciente"
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(119, 12)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(62, 20)
        Me.txtHistoria.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Historia Clinica"
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(215, 69)
        Me.txtHora.Mask = "00:00"
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(49, 20)
        Me.txtHora.TabIndex = 17
        Me.txtHora.ValidatingType = GetType(Date)
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(119, 70)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(90, 20)
        Me.dtpFecha.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Fecha/Hora"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(270, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Tipo Alta"
        '
        'cboTipoAlta
        '
        Me.cboTipoAlta.FormattingEnabled = True
        Me.cboTipoAlta.Location = New System.Drawing.Point(364, 71)
        Me.cboTipoAlta.Name = "cboTipoAlta"
        Me.cboTipoAlta.Size = New System.Drawing.Size(132, 21)
        Me.cboTipoAlta.TabIndex = 29
        '
        'cboCondicionAlta
        '
        Me.cboCondicionAlta.FormattingEnabled = True
        Me.cboCondicionAlta.Location = New System.Drawing.Point(586, 68)
        Me.cboCondicionAlta.Name = "cboCondicionAlta"
        Me.cboCondicionAlta.Size = New System.Drawing.Size(210, 21)
        Me.cboCondicionAlta.TabIndex = 31
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(500, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Condicion"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(13, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(191, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "DATOS DE ALTA DE PACIENTE"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(500, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Medico"
        '
        'cboResponsable
        '
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(586, 117)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(377, 21)
        Me.cboResponsable.TabIndex = 34
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(17, 312)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(480, 13)
        Me.Label16.TabIndex = 80
        Me.Label16.Text = "(*) Presione SUPR para anular una transferencia. Los datos quedaran registrados d" & _
            "e esta operacion."
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(12, 225)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(951, 81)
        Me.lvTabla.TabIndex = 78
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "CIE"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripcion"
        Me.ColumnHeader2.Width = 860
        '
        'txtDes
        '
        Me.txtDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes.Location = New System.Drawing.Point(120, 199)
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(380, 20)
        Me.txtDes.TabIndex = 77
        '
        'txtCIE
        '
        Me.txtCIE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCIE.Location = New System.Drawing.Point(12, 199)
        Me.txtCIE.Name = "txtCIE"
        Me.txtCIE.Size = New System.Drawing.Size(91, 20)
        Me.txtCIE.TabIndex = 76
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 173)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(141, 13)
        Me.Label15.TabIndex = 79
        Me.Label15.Text = "Diagnosticos de Egreso"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(611, 331)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 28)
        Me.btnCerrar.TabIndex = 84
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(495, 331)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 28)
        Me.btnCancelar.TabIndex = 83
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(389, 331)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 28)
        Me.btnGrabar.TabIndex = 82
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(279, 331)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 28)
        Me.btnNuevo.TabIndex = 81
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cboReferido
        '
        Me.cboReferido.FormattingEnabled = True
        Me.cboReferido.Location = New System.Drawing.Point(119, 146)
        Me.cboReferido.Name = "cboReferido"
        Me.cboReferido.Size = New System.Drawing.Size(377, 21)
        Me.cboReferido.TabIndex = 85
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 149)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 86
        Me.Label17.Text = "Referido de"
        '
        'gbConsulta
        '
        Me.gbConsulta.BackColor = System.Drawing.Color.Silver
        Me.gbConsulta.Controls.Add(Me.Label32)
        Me.gbConsulta.Controls.Add(Me.btnRetornar)
        Me.gbConsulta.Controls.Add(Me.lvDet)
        Me.gbConsulta.Controls.Add(Me.txtFiltro)
        Me.gbConsulta.Controls.Add(Me.Label31)
        Me.gbConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConsulta.Location = New System.Drawing.Point(20, 38)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Size = New System.Drawing.Size(907, 277)
        Me.gbConsulta.TabIndex = 118
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta General"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(6, 246)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(265, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Presione Enter para Insertar un Codigo CIE10"
        '
        'btnRetornar
        '
        Me.btnRetornar.Location = New System.Drawing.Point(427, 238)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Size = New System.Drawing.Size(78, 29)
        Me.btnRetornar.TabIndex = 3
        Me.btnRetornar.Text = "&Retornar"
        Me.btnRetornar.UseVisualStyleBackColor = True
        '
        'lvDet
        '
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(9, 52)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(883, 177)
        Me.lvDet.TabIndex = 2
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "CIE10"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Descripción"
        Me.ColumnHeader5.Width = 660
        '
        'txtFiltro
        '
        Me.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltro.Location = New System.Drawing.Point(135, 22)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(342, 20)
        Me.txtFiltro.TabIndex = 1
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(6, 22)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(124, 13)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "Ingresar Descripción"
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Location = New System.Drawing.Point(586, 8)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(379, 23)
        Me.lblPaciente.TabIndex = 132
        '
        'cboEspecialidad
        '
        Me.cboEspecialidad.FormattingEnabled = True
        Me.cboEspecialidad.Location = New System.Drawing.Point(120, 119)
        Me.cboEspecialidad.Name = "cboEspecialidad"
        Me.cboEspecialidad.Size = New System.Drawing.Size(377, 21)
        Me.cboEspecialidad.TabIndex = 140
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "Especialidad"
        '
        'cboSubServicio
        '
        Me.cboSubServicio.FormattingEnabled = True
        Me.cboSubServicio.Location = New System.Drawing.Point(586, 90)
        Me.cboSubServicio.Name = "cboSubServicio"
        Me.cboSubServicio.Size = New System.Drawing.Size(377, 21)
        Me.cboSubServicio.TabIndex = 139
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(500, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 143
        Me.Label18.Text = "Sub Servicio"
        '
        'cboServicio
        '
        Me.cboServicio.FormattingEnabled = True
        Me.cboServicio.Location = New System.Drawing.Point(119, 95)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(377, 21)
        Me.cboServicio.TabIndex = 138
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(13, 98)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 13)
        Me.Label19.TabIndex = 142
        Me.Label19.Text = "Servicio"
        '
        'cboEnfermera
        '
        Me.cboEnfermera.FormattingEnabled = True
        Me.cboEnfermera.Location = New System.Drawing.Point(586, 141)
        Me.cboEnfermera.Name = "cboEnfermera"
        Me.cboEnfermera.Size = New System.Drawing.Size(377, 21)
        Me.cboEnfermera.TabIndex = 146
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(500, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Enfermera(o)"
        '
        'lblHora
        '
        Me.lblHora.BackColor = System.Drawing.Color.White
        Me.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHora.Location = New System.Drawing.Point(405, 10)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(59, 23)
        Me.lblHora.TabIndex = 147
        '
        'btnBPac
        '
        Me.btnBPac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBPac.Location = New System.Drawing.Point(180, 12)
        Me.btnBPac.Name = "btnBPac"
        Me.btnBPac.Size = New System.Drawing.Size(42, 23)
        Me.btnBPac.TabIndex = 178
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
        Me.gbBPac.Location = New System.Drawing.Point(72, 8)
        Me.gbBPac.Name = "gbBPac"
        Me.gbBPac.Size = New System.Drawing.Size(702, 279)
        Me.gbBPac.TabIndex = 340
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
        Me.lvBPac.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader59, Me.ColumnHeader3, Me.ColumnHeader61, Me.ColumnHeader62, Me.ColumnHeader63, Me.ColumnHeader64, Me.ColumnHeader65, Me.ColumnHeader66})
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
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Apaterno"
        Me.ColumnHeader3.Width = 100
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
        'frmEgreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 369)
        Me.Controls.Add(Me.gbBPac)
        Me.Controls.Add(Me.btnBPac)
        Me.Controls.Add(Me.lblHora)
        Me.Controls.Add(Me.gbConsulta)
        Me.Controls.Add(Me.cboEnfermera)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboEspecialidad)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboSubServicio)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboServicio)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.cboReferido)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lvTabla)
        Me.Controls.Add(Me.txtDes)
        Me.Controls.Add(Me.txtCIE)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboResponsable)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboCondicionAlta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboTipoAlta)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmEgreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Egreso de Paciente Hospitalizado"
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.gbBPac.ResumeLayout(False)
        Me.gbBPac.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAlta As System.Windows.Forms.ComboBox
    Friend WithEvents cboCondicionAlta As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDes As System.Windows.Forms.TextBox
    Friend WithEvents txtCIE As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents cboReferido As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents cboEspecialidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSubServicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboServicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboEnfermera As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents btnBPac As System.Windows.Forms.Button
    Friend WithEvents gbBPac As System.Windows.Forms.GroupBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents btnRetBPac As System.Windows.Forms.Button
    Friend WithEvents lvBPac As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader59 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader61 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader62 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader63 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader64 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader65 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader66 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFPac As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
End Class
