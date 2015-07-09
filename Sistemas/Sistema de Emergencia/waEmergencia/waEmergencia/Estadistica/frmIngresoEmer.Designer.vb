<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresoEmer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoEmer))
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cboTipoAtencion = New System.Windows.Forms.ComboBox()
        Me.cboIngSer = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cboIngEst = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dtpFechaNcto = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cboDistrito = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboProvincia = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboDpto = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboGrado = New System.Windows.Forms.ComboBox()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtInformante = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPaciente = New System.Windows.Forms.TextBox()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboServicio = New System.Windows.Forms.ComboBox()
        Me.cboMedico = New System.Windows.Forms.ComboBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblTEdad = New System.Windows.Forms.Label()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.Fuente = New System.Windows.Forms.FontDialog()
        Me.ppDialogo = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdDocumento = New System.Drawing.Printing.PrintDocument()
        Me.Pagina = New System.Windows.Forms.PageSetupDialog()
        Me.gbPaciente = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSerieSIS = New System.Windows.Forms.TextBox()
        Me.txtNumeroSIS = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPreliquidacion = New System.Windows.Forms.TextBox()
        Me.lblEdadM = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblTEdadM = New System.Windows.Forms.Label()
        Me.lblEdadD = New System.Windows.Forms.Label()
        Me.lblTEdadD = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbPaciente.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(329, 94)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(86, 13)
        Me.Label36.TabIndex = 133
        Me.Label36.Text = "Tipo Atención"
        '
        'cboTipoAtencion
        '
        Me.cboTipoAtencion.FormattingEnabled = True
        Me.cboTipoAtencion.Items.AddRange(New Object() {"CONVENIO", "PROGRAMA", "SIS", "CREDITO", "SOAT", "COMUN"})
        Me.cboTipoAtencion.Location = New System.Drawing.Point(423, 88)
        Me.cboTipoAtencion.Name = "cboTipoAtencion"
        Me.cboTipoAtencion.Size = New System.Drawing.Size(288, 21)
        Me.cboTipoAtencion.TabIndex = 8
        '
        'cboIngSer
        '
        Me.cboIngSer.FormattingEnabled = True
        Me.cboIngSer.Items.AddRange(New Object() {"NUEVO", "CONTINUADOR", "REINGRESANTE"})
        Me.cboIngSer.Location = New System.Drawing.Point(423, 224)
        Me.cboIngSer.Name = "cboIngSer"
        Me.cboIngSer.Size = New System.Drawing.Size(211, 21)
        Me.cboIngSer.TabIndex = 16
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(329, 227)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(79, 13)
        Me.Label35.TabIndex = 132
        Me.Label35.Text = "Ing. Servicio"
        '
        'cboIngEst
        '
        Me.cboIngEst.FormattingEnabled = True
        Me.cboIngEst.Items.AddRange(New Object() {"NUEVO", "CONTINUADOR", "REINGRESANTE"})
        Me.cboIngEst.Location = New System.Drawing.Point(104, 224)
        Me.cboIngEst.Name = "cboIngEst"
        Me.cboIngEst.Size = New System.Drawing.Size(211, 21)
        Me.cboIngEst.TabIndex = 15
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(14, 227)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(78, 13)
        Me.Label34.TabIndex = 131
        Me.Label34.Text = "Tipo Ingreso"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(14, 198)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 13)
        Me.Label28.TabIndex = 129
        Me.Label28.Text = "Servicio"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(329, 198)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(48, 13)
        Me.Label27.TabIndex = 127
        Me.Label27.Text = "Médico"
        '
        'dtpFechaNcto
        '
        Me.dtpFechaNcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNcto.Location = New System.Drawing.Point(609, 10)
        Me.dtpFechaNcto.Name = "dtpFechaNcto"
        Me.dtpFechaNcto.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaNcto.TabIndex = 4
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(523, 13)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 13)
        Me.Label26.TabIndex = 126
        Me.Label26.Text = "Fecha Ncto."
        '
        'cboDistrito
        '
        Me.cboDistrito.FormattingEnabled = True
        Me.cboDistrito.Location = New System.Drawing.Point(104, 165)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(211, 21)
        Me.cboDistrito.TabIndex = 11
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(14, 163)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(47, 13)
        Me.Label25.TabIndex = 125
        Me.Label25.Text = "Distrito"
        '
        'cboProvincia
        '
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(423, 139)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(288, 21)
        Me.cboProvincia.TabIndex = 10
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(329, 142)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 13)
        Me.Label24.TabIndex = 124
        Me.Label24.Text = "Provincia"
        '
        'cboDpto
        '
        Me.cboDpto.FormattingEnabled = True
        Me.cboDpto.Location = New System.Drawing.Point(104, 139)
        Me.cboDpto.Name = "cboDpto"
        Me.cboDpto.Size = New System.Drawing.Size(211, 21)
        Me.cboDpto.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 137)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 123
        Me.Label12.Text = "Departamento"
        '
        'cboGrado
        '
        Me.cboGrado.FormattingEnabled = True
        Me.cboGrado.Location = New System.Drawing.Point(103, 62)
        Me.cboGrado.Name = "cboGrado"
        Me.cboGrado.Size = New System.Drawing.Size(211, 21)
        Me.cboGrado.TabIndex = 5
        '
        'cboEstado
        '
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(399, 61)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(122, 21)
        Me.cboEstado.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(319, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 122
        Me.Label11.Text = "Estado Civil"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(104, 113)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(418, 20)
        Me.txtDomicilio.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Domicilio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Grado Inst."
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.White
        Me.lblEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdad.Location = New System.Drawing.Point(104, 87)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(30, 23)
        Me.lblEdad.TabIndex = 119
        Me.lblEdad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(522, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 116
        Me.Label8.Text = "Sexo"
        '
        'txtInformante
        '
        Me.txtInformante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInformante.Location = New System.Drawing.Point(423, 166)
        Me.txtInformante.Name = "txtInformante"
        Me.txtInformante.Size = New System.Drawing.Size(288, 20)
        Me.txtInformante.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(329, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "Informante"
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(252, 12)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(62, 20)
        Me.txtHora.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(212, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "Hora"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(103, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(105, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Fecha"
        '
        'txtPaciente
        '
        Me.txtPaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaciente.Location = New System.Drawing.Point(182, 38)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(340, 20)
        Me.txtPaciente.TabIndex = 3
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(103, 38)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(73, 20)
        Me.txtHistoria.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Paciente"
        '
        'cboServicio
        '
        Me.cboServicio.FormattingEnabled = True
        Me.cboServicio.Location = New System.Drawing.Point(104, 195)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(211, 21)
        Me.cboServicio.TabIndex = 13
        '
        'cboMedico
        '
        Me.cboMedico.FormattingEnabled = True
        Me.cboMedico.Location = New System.Drawing.Point(423, 195)
        Me.cboMedico.Name = "cboMedico"
        Me.cboMedico.Size = New System.Drawing.Size(287, 21)
        Me.cboMedico.TabIndex = 14
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.White
        Me.lblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUsuario.Location = New System.Drawing.Point(422, 9)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(100, 23)
        Me.lblUsuario.TabIndex = 137
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(320, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = "Usuario"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(507, 287)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(93, 33)
        Me.btnCerrar.TabIndex = 23
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(389, 287)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(93, 33)
        Me.btnCancelar.TabIndex = 22
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(272, 287)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(93, 33)
        Me.btnGrabar.TabIndex = 21
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(144, 287)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(93, 33)
        Me.btnNuevo.TabIndex = 20
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'lblTEdad
        '
        Me.lblTEdad.BackColor = System.Drawing.Color.White
        Me.lblTEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdad.Location = New System.Drawing.Point(140, 87)
        Me.lblTEdad.Name = "lblTEdad"
        Me.lblTEdad.Size = New System.Drawing.Size(30, 23)
        Me.lblTEdad.TabIndex = 147
        Me.lblTEdad.Text = "A"
        Me.lblTEdad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSexo
        '
        Me.lblSexo.BackColor = System.Drawing.Color.White
        Me.lblSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSexo.Location = New System.Drawing.Point(609, 40)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(101, 23)
        Me.lblSexo.TabIndex = 148
        Me.lblSexo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Fuente
        '
        Me.Fuente.Color = System.Drawing.SystemColors.ControlText
        '
        'ppDialogo
        '
        Me.ppDialogo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppDialogo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppDialogo.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppDialogo.Document = Me.pdDocumento
        Me.ppDialogo.Enabled = True
        Me.ppDialogo.Icon = CType(resources.GetObject("ppDialogo.Icon"), System.Drawing.Icon)
        Me.ppDialogo.Name = "ppDialogo"
        Me.ppDialogo.Visible = False
        '
        'pdDocumento
        '
        '
        'gbPaciente
        '
        Me.gbPaciente.Controls.Add(Me.Label7)
        Me.gbPaciente.Controls.Add(Me.btnRetornar)
        Me.gbPaciente.Controls.Add(Me.lvTabla)
        Me.gbPaciente.Controls.Add(Me.txtFiltro)
        Me.gbPaciente.Controls.Add(Me.Label2)
        Me.gbPaciente.Location = New System.Drawing.Point(12, 38)
        Me.gbPaciente.Name = "gbPaciente"
        Me.gbPaciente.Size = New System.Drawing.Size(702, 279)
        Me.gbPaciente.TabIndex = 149
        Me.gbPaciente.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(19, 260)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(619, 13)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "En paciente, escriba los apellidos y presione ENTER.  Seleccione al paciente y pr" & _
            "esione ENTER de la lista."
        '
        'btnRetornar
        '
        Me.btnRetornar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornar.Location = New System.Drawing.Point(656, 15)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Size = New System.Drawing.Size(28, 27)
        Me.btnRetornar.TabIndex = 100
        Me.btnRetornar.Text = "&X"
        Me.btnRetornar.UseVisualStyleBackColor = True
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(13, 45)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(683, 206)
        Me.lvTabla.TabIndex = 99
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Historia"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Apaterno"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Amaterno"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Nombres"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "FNacimiento"
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Sexo"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Papa"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Mama"
        Me.ColumnHeader8.Width = 100
        '
        'txtFiltro
        '
        Me.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltro.Location = New System.Drawing.Point(92, 19)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(543, 20)
        Me.txtFiltro.TabIndex = 97
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Paciente"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 150
        Me.Label13.Text = "Formato SIS"
        '
        'txtSerieSIS
        '
        Me.txtSerieSIS.Location = New System.Drawing.Point(104, 256)
        Me.txtSerieSIS.Name = "txtSerieSIS"
        Me.txtSerieSIS.Size = New System.Drawing.Size(62, 20)
        Me.txtSerieSIS.TabIndex = 17
        '
        'txtNumeroSIS
        '
        Me.txtNumeroSIS.Location = New System.Drawing.Point(172, 256)
        Me.txtNumeroSIS.Name = "txtNumeroSIS"
        Me.txtNumeroSIS.Size = New System.Drawing.Size(143, 20)
        Me.txtNumeroSIS.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(329, 256)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 13)
        Me.Label14.TabIndex = 153
        Me.Label14.Text = "Preliquidación"
        '
        'txtPreliquidacion
        '
        Me.txtPreliquidacion.Location = New System.Drawing.Point(423, 253)
        Me.txtPreliquidacion.Name = "txtPreliquidacion"
        Me.txtPreliquidacion.Size = New System.Drawing.Size(100, 20)
        Me.txtPreliquidacion.TabIndex = 19
        '
        'lblEdadM
        '
        Me.lblEdadM.BackColor = System.Drawing.Color.White
        Me.lblEdadM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdadM.Location = New System.Drawing.Point(176, 87)
        Me.lblEdadM.Name = "lblEdadM"
        Me.lblEdadM.Size = New System.Drawing.Size(30, 23)
        Me.lblEdadM.TabIndex = 154
        Me.lblEdadM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 155
        Me.Label16.Text = "Edad"
        '
        'lblTEdadM
        '
        Me.lblTEdadM.BackColor = System.Drawing.Color.White
        Me.lblTEdadM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdadM.Location = New System.Drawing.Point(212, 87)
        Me.lblTEdadM.Name = "lblTEdadM"
        Me.lblTEdadM.Size = New System.Drawing.Size(30, 23)
        Me.lblTEdadM.TabIndex = 156
        Me.lblTEdadM.Text = "M"
        Me.lblTEdadM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdadD
        '
        Me.lblEdadD.BackColor = System.Drawing.Color.White
        Me.lblEdadD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdadD.Location = New System.Drawing.Point(248, 87)
        Me.lblEdadD.Name = "lblEdadD"
        Me.lblEdadD.Size = New System.Drawing.Size(30, 23)
        Me.lblEdadD.TabIndex = 157
        Me.lblEdadD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTEdadD
        '
        Me.lblTEdadD.BackColor = System.Drawing.Color.White
        Me.lblTEdadD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdadD.Location = New System.Drawing.Point(285, 87)
        Me.lblTEdadD.Name = "lblTEdadD"
        Me.lblTEdadD.Size = New System.Drawing.Size(30, 23)
        Me.lblTEdadD.TabIndex = 158
        Me.lblTEdadD.Text = "A"
        Me.lblTEdadD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(732, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(151, 276)
        Me.Label15.TabIndex = 159
        Me.Label15.Text = "NOTA: A partir de la fecha deberá poner atención en el registro de los pacientes " & _
            "en emergencia, se ha desactivado la opción de Modificar un ingreso, por lo que t" & _
            "odo registro se considerará como NUEVO."
        '
        'frmIngresoEmer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 323)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.gbPaciente)
        Me.Controls.Add(Me.lblTEdadD)
        Me.Controls.Add(Me.lblEdadD)
        Me.Controls.Add(Me.lblTEdadM)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lblEdadM)
        Me.Controls.Add(Me.lblSexo)
        Me.Controls.Add(Me.lblTEdad)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboMedico)
        Me.Controls.Add(Me.cboServicio)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.cboTipoAtencion)
        Me.Controls.Add(Me.cboIngSer)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.cboIngEst)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.dtpFechaNcto)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cboDistrito)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cboProvincia)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.cboDpto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboGrado)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblEdad)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtInformante)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPaciente)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPreliquidacion)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtNumeroSIS)
        Me.Controls.Add(Me.txtSerieSIS)
        Me.Controls.Add(Me.Label13)
        Me.Name = "frmIngresoEmer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Emergencia - Estadistica"
        Me.gbPaciente.ResumeLayout(False)
        Me.gbPaciente.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAtencion As System.Windows.Forms.ComboBox
    Friend WithEvents cboIngSer As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboIngEst As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaNcto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboDpto As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboGrado As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInformante As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPaciente As System.Windows.Forms.TextBox
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboServicio As System.Windows.Forms.ComboBox
    Friend WithEvents cboMedico As System.Windows.Forms.ComboBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents lblTEdad As System.Windows.Forms.Label
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents Fuente As System.Windows.Forms.FontDialog
    Friend WithEvents ppDialogo As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents Pagina As System.Windows.Forms.PageSetupDialog
    Friend WithEvents gbPaciente As System.Windows.Forms.GroupBox
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSerieSIS As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroSIS As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPreliquidacion As System.Windows.Forms.TextBox
    Friend WithEvents lblEdadM As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblTEdadM As System.Windows.Forms.Label
    Friend WithEvents lblEdadD As System.Windows.Forms.Label
    Friend WithEvents lblTEdadD As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
