<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInforme
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInforme))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarP = New System.Windows.Forms.Button()
        Me.lblPacienteH = New System.Windows.Forms.Label()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.lblFechaNac = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.gbPaciente = New System.Windows.Forms.GroupBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.btnRetornarP = New System.Windows.Forms.Button()
        Me.lvPaciente = New System.Windows.Forms.ListView()
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtPaciente = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.cboExamen = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipoDx = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCie = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbConsulta = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtConclusiones = New System.Windows.Forms.TextBox()
        Me.cboSolicitado = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboCardiologo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lvH = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pdDocumento = New System.Drawing.Printing.PrintDocument()
        Me.ppdDocumento = New System.Windows.Forms.PrintPreviewDialog()
        Me.psDocumento = New System.Windows.Forms.PageSetupDialog()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPac = New System.Windows.Forms.TextBox()
        Me.lvReq = New System.Windows.Forms.ListView()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.gbPaciente.SuspendLayout()
        Me.gbConsulta.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(80, 122)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(104, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(276, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Origen"
        '
        'cboOrigen
        '
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Items.AddRange(New Object() {"EMERGENCIA", "CONSULTA EXTERNA", "HOSPITALIZACION", "SALA DE OPERACIONES", "CONVENIO"})
        Me.cboOrigen.Location = New System.Drawing.Point(337, 126)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(304, 21)
        Me.cboOrigen.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Paciente"
        '
        'btnBuscarP
        '
        Me.btnBuscarP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarP.Location = New System.Drawing.Point(605, 150)
        Me.btnBuscarP.Name = "btnBuscarP"
        Me.btnBuscarP.Size = New System.Drawing.Size(36, 23)
        Me.btnBuscarP.TabIndex = 213
        Me.btnBuscarP.Text = "&B"
        Me.btnBuscarP.UseVisualStyleBackColor = True
        '
        'lblPacienteH
        '
        Me.lblPacienteH.BackColor = System.Drawing.Color.White
        Me.lblPacienteH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPacienteH.Location = New System.Drawing.Point(164, 150)
        Me.lblPacienteH.Name = "lblPacienteH"
        Me.lblPacienteH.Size = New System.Drawing.Size(435, 23)
        Me.lblPacienteH.TabIndex = 3
        '
        'lblSexo
        '
        Me.lblSexo.BackColor = System.Drawing.Color.White
        Me.lblSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSexo.Location = New System.Drawing.Point(81, 176)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(80, 23)
        Me.lblSexo.TabIndex = 4
        '
        'lblFechaNac
        '
        Me.lblFechaNac.BackColor = System.Drawing.Color.White
        Me.lblFechaNac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFechaNac.Location = New System.Drawing.Point(164, 176)
        Me.lblFechaNac.Name = "lblFechaNac"
        Me.lblFechaNac.Size = New System.Drawing.Size(134, 23)
        Me.lblFechaNac.TabIndex = 5
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(81, 153)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(80, 20)
        Me.txtHistoria.TabIndex = 2
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.White
        Me.lblEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdad.Location = New System.Drawing.Point(337, 176)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(115, 23)
        Me.lblEdad.TabIndex = 6
        '
        'gbPaciente
        '
        Me.gbPaciente.Controls.Add(Me.Label53)
        Me.gbPaciente.Controls.Add(Me.btnRetornarP)
        Me.gbPaciente.Controls.Add(Me.lvPaciente)
        Me.gbPaciente.Controls.Add(Me.txtPaciente)
        Me.gbPaciente.Controls.Add(Me.Label54)
        Me.gbPaciente.Location = New System.Drawing.Point(-2, 37)
        Me.gbPaciente.Name = "gbPaciente"
        Me.gbPaciente.Size = New System.Drawing.Size(702, 279)
        Me.gbPaciente.TabIndex = 15
        Me.gbPaciente.TabStop = False
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Blue
        Me.Label53.Location = New System.Drawing.Point(19, 260)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(619, 13)
        Me.Label53.TabIndex = 101
        Me.Label53.Text = "En paciente, escriba los apellidos y presione ENTER.  Seleccione al paciente y pr" & _
            "esione ENTER de la lista."
        '
        'btnRetornarP
        '
        Me.btnRetornarP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornarP.Location = New System.Drawing.Point(656, 15)
        Me.btnRetornarP.Name = "btnRetornarP"
        Me.btnRetornarP.Size = New System.Drawing.Size(28, 27)
        Me.btnRetornarP.TabIndex = 100
        Me.btnRetornarP.Text = "&X"
        Me.btnRetornarP.UseVisualStyleBackColor = True
        '
        'lvPaciente
        '
        Me.lvPaciente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader32})
        Me.lvPaciente.FullRowSelect = True
        Me.lvPaciente.GridLines = True
        Me.lvPaciente.Location = New System.Drawing.Point(13, 45)
        Me.lvPaciente.Name = "lvPaciente"
        Me.lvPaciente.Size = New System.Drawing.Size(683, 206)
        Me.lvPaciente.TabIndex = 99
        Me.lvPaciente.UseCompatibleStateImageBehavior = False
        Me.lvPaciente.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Historia"
        Me.ColumnHeader25.Width = 80
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Apaterno"
        Me.ColumnHeader26.Width = 100
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Amaterno"
        Me.ColumnHeader27.Width = 100
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Nombres"
        Me.ColumnHeader28.Width = 100
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "FNacimiento"
        Me.ColumnHeader29.Width = 80
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "Sexo"
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "Papa"
        Me.ColumnHeader31.Width = 100
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "Mama"
        Me.ColumnHeader32.Width = 100
        '
        'txtPaciente
        '
        Me.txtPaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaciente.Location = New System.Drawing.Point(66, 19)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(584, 20)
        Me.txtPaciente.TabIndex = 97
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(10, 19)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(57, 13)
        Me.Label54.TabIndex = 98
        Me.Label54.Text = "Paciente"
        '
        'cboExamen
        '
        Me.cboExamen.FormattingEnabled = True
        Me.cboExamen.Items.AddRange(New Object() {"ELECTROCARDIOGRAMA (ECG)", "ECG DE RITMO (DII)"})
        Me.cboExamen.Location = New System.Drawing.Point(402, 202)
        Me.cboExamen.Name = "cboExamen"
        Me.cboExamen.Size = New System.Drawing.Size(239, 21)
        Me.cboExamen.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(345, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 216
        Me.Label4.Text = "Examen"
        '
        'cboTipoDx
        '
        Me.cboTipoDx.FormattingEnabled = True
        Me.cboTipoDx.Items.AddRange(New Object() {"PRE OPERATORIO", "POST OPERTATORIO", "CONTROL"})
        Me.cboTipoDx.Location = New System.Drawing.Point(80, 229)
        Me.cboTipoDx.Name = "cboTipoDx"
        Me.cboTipoDx.Size = New System.Drawing.Size(258, 21)
        Me.cboTipoDx.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 218
        Me.Label5.Text = "Tipo Dx"
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(20, 291)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(621, 66)
        Me.lvTabla.TabIndex = 12
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "CIE"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripción"
        Me.ColumnHeader2.Width = 660
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(115, 269)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(526, 20)
        Me.txtDescripcion.TabIndex = 11
        '
        'txtCie
        '
        Me.txtCie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie.Location = New System.Drawing.Point(20, 269)
        Me.txtCie.Name = "txtCie"
        Me.txtCie.Size = New System.Drawing.Size(89, 20)
        Me.txtCie.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 223
        Me.Label7.Text = "Diagnósticos"
        '
        'gbConsulta
        '
        Me.gbConsulta.Controls.Add(Me.Label32)
        Me.gbConsulta.Controls.Add(Me.btnRetornar)
        Me.gbConsulta.Controls.Add(Me.lvDet)
        Me.gbConsulta.Controls.Add(Me.txtFiltro)
        Me.gbConsulta.Controls.Add(Me.Label31)
        Me.gbConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConsulta.Location = New System.Drawing.Point(4, 284)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Size = New System.Drawing.Size(702, 199)
        Me.gbConsulta.TabIndex = 16
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta General"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(5, 180)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(265, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Presione Enter para Insertar un Codigo CIE10"
        '
        'btnRetornar
        '
        Me.btnRetornar.Location = New System.Drawing.Point(514, 11)
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
        Me.lvDet.Size = New System.Drawing.Size(687, 119)
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
        Me.ColumnHeader5.Width = 700
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
        Me.Label31.Location = New System.Drawing.Point(5, 29)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(124, 13)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "Ingresar Descripción"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 360)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 225
        Me.Label6.Text = "Conclusiones"
        '
        'txtConclusiones
        '
        Me.txtConclusiones.Location = New System.Drawing.Point(20, 376)
        Me.txtConclusiones.Multiline = True
        Me.txtConclusiones.Name = "txtConclusiones"
        Me.txtConclusiones.Size = New System.Drawing.Size(621, 59)
        Me.txtConclusiones.TabIndex = 13
        '
        'cboSolicitado
        '
        Me.cboSolicitado.FormattingEnabled = True
        Me.cboSolicitado.Items.AddRange(New Object() {"ELECTROCARDIOGRAMA (ECG)", "ECG DE RITMO (DII)"})
        Me.cboSolicitado.Location = New System.Drawing.Point(81, 202)
        Me.cboSolicitado.Name = "cboSolicitado"
        Me.cboSolicitado.Size = New System.Drawing.Size(258, 21)
        Me.cboSolicitado.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 227
        Me.Label8.Text = "Solicitado"
        '
        'cboCardiologo
        '
        Me.cboCardiologo.FormattingEnabled = True
        Me.cboCardiologo.Items.AddRange(New Object() {"ELECTROCARDIOGRAMA (ECG)", "ECG DE RITMO (DII)"})
        Me.cboCardiologo.Location = New System.Drawing.Point(90, 441)
        Me.cboCardiologo.Name = "cboCardiologo"
        Me.cboCardiologo.Size = New System.Drawing.Size(304, 21)
        Me.cboCardiologo.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 444)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 229
        Me.Label9.Text = "Cardiologo"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(142, 466)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 230
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(250, 466)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 231
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(370, 466)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 232
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(478, 466)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 233
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lvH
        '
        Me.lvH.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader12, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader10, Me.ColumnHeader34})
        Me.lvH.FullRowSelect = True
        Me.lvH.GridLines = True
        Me.lvH.Location = New System.Drawing.Point(648, 37)
        Me.lvH.Name = "lvH"
        Me.lvH.Size = New System.Drawing.Size(358, 452)
        Me.lvH.TabIndex = 234
        Me.lvH.UseCompatibleStateImageBehavior = False
        Me.lvH.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Id"
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Fecha"
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Origen"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Historia"
        Me.ColumnHeader8.Width = 80
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Paciente"
        Me.ColumnHeader9.Width = 150
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Sexo"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Edad"
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "TipoDX"
        Me.ColumnHeader15.Width = 80
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Conclusiones"
        Me.ColumnHeader16.Width = 300
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Cardiologo"
        Me.ColumnHeader17.Width = 100
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Solicitado"
        Me.ColumnHeader18.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Examen"
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "TipoPaciente"
        Me.ColumnHeader34.Width = 80
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(719, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(191, 13)
        Me.Label10.TabIndex = 235
        Me.Label10.Text = "Lista de Exámenes de Pacientes"
        '
        'ppdDocumento
        '
        Me.ppdDocumento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdDocumento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdDocumento.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdDocumento.Document = Me.pdDocumento
        Me.ppdDocumento.Enabled = True
        Me.ppdDocumento.Icon = CType(resources.GetObject("ppdDocumento.Icon"), System.Drawing.Icon)
        Me.ppdDocumento.Name = "ppdDocumento"
        Me.ppdDocumento.Visible = False
        '
        'psDocumento
        '
        Me.psDocumento.Document = Me.pdDocumento
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(137, 13)
        Me.Label11.TabIndex = 236
        Me.Label11.Text = "Lista de Requerimiento"
        '
        'txtPac
        '
        Me.txtPac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPac.Location = New System.Drawing.Point(164, 3)
        Me.txtPac.Name = "txtPac"
        Me.txtPac.Size = New System.Drawing.Size(477, 20)
        Me.txtPac.TabIndex = 237
        '
        'lvReq
        '
        Me.lvReq.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.ColumnHeader13, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader33})
        Me.lvReq.FullRowSelect = True
        Me.lvReq.GridLines = True
        Me.lvReq.Location = New System.Drawing.Point(12, 29)
        Me.lvReq.Name = "lvReq"
        Me.lvReq.Size = New System.Drawing.Size(630, 87)
        Me.lvReq.TabIndex = 238
        Me.lvReq.UseCompatibleStateImageBehavior = False
        Me.lvReq.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Id"
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Historia"
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Paciente"
        Me.ColumnHeader19.Width = 300
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Tipo"
        Me.ColumnHeader20.Width = 100
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Examen"
        Me.ColumnHeader21.Width = 200
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Indicacion"
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Solicitado"
        Me.ColumnHeader23.Width = 200
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "TipoPaciente"
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "Origen"
        '
        'cboTipo
        '
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {"SIS", "SOAT", "COMUN", "ESSALUD", "SANIDAD FAP", "SANIDAD NAVAL", "SANIDAD EP", "SANIDAD PNP", "PRIVADOS", "OTROS", "EXONERADO"})
        Me.cboTipo.Location = New System.Drawing.Point(458, 175)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(141, 21)
        Me.cboTipo.TabIndex = 239
        '
        'frmInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 495)
        Me.Controls.Add(Me.gbConsulta)
        Me.Controls.Add(Me.gbPaciente)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.lvReq)
        Me.Controls.Add(Me.txtPac)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.cboCardiologo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboSolicitado)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtConclusiones)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lvTabla)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCie)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboTipoDx)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboExamen)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblEdad)
        Me.Controls.Add(Me.btnBuscarP)
        Me.Controls.Add(Me.lblPacienteH)
        Me.Controls.Add(Me.lblSexo)
        Me.Controls.Add(Me.lblFechaNac)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboOrigen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvH)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInforme"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe EKG"
        Me.gbPaciente.ResumeLayout(False)
        Me.gbPaciente.PerformLayout()
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarP As System.Windows.Forms.Button
    Friend WithEvents lblPacienteH As System.Windows.Forms.Label
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents lblFechaNac As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents gbPaciente As System.Windows.Forms.GroupBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents btnRetornarP As System.Windows.Forms.Button
    Friend WithEvents lvPaciente As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader31 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader32 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtPaciente As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents cboExamen As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDx As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCie As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtConclusiones As System.Windows.Forms.TextBox
    Friend WithEvents cboSolicitado As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCardiologo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lvH As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pdDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppdDocumento As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents psDocumento As System.Windows.Forms.PageSetupDialog
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPac As System.Windows.Forms.TextBox
    Friend WithEvents lvReq As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader33 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader34 As System.Windows.Forms.ColumnHeader
End Class
