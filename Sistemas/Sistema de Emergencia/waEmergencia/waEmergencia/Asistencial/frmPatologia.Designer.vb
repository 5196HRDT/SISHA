<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatologia
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
        Me.components = New System.ComponentModel.Container()
        Me.lblOrgano = New System.Windows.Forms.Label()
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
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblDiagnostico = New System.Windows.Forms.Label()
        Me.lblMedico = New System.Windows.Forms.Label()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.Label158 = New System.Windows.Forms.Label()
        Me.lblProcedencia = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.lvListaI = New System.Windows.Forms.ListView()
        Me.ColumnHeader58 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader56 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader57 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtCuerpo = New System.Windows.Forms.RichTextBox()
        Me.lblTipoMuestra = New System.Windows.Forms.Label()
        Me.lblFechaEntrga = New System.Windows.Forms.Label()
        Me.Label156 = New System.Windows.Forms.Label()
        Me.Label155 = New System.Windows.Forms.Label()
        Me.Label154 = New System.Windows.Forms.Label()
        Me.Label153 = New System.Windows.Forms.Label()
        Me.Label152 = New System.Windows.Forms.Label()
        Me.Label151 = New System.Windows.Forms.Label()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.Label148 = New System.Windows.Forms.Label()
        Me.Label149 = New System.Windows.Forms.Label()
        Me.Label150 = New System.Windows.Forms.Label()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Fuente = New System.Windows.Forms.FontDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.Label159 = New System.Windows.Forms.Label()
        Me.lblFNac = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.Label135 = New System.Windows.Forms.Label()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.Label157 = New System.Windows.Forms.Label()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.lblDistrito = New System.Windows.Forms.Label()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.lblDpto = New System.Windows.Forms.Label()
        Me.btnBuscarP = New System.Windows.Forms.Button()
        Me.btnQR = New System.Windows.Forms.Button()
        Me.gbQR = New System.Windows.Forms.GroupBox()
        Me.btnRetornarQR = New System.Windows.Forms.Button()
        Me.imgQR = New System.Windows.Forms.PictureBox()
        Me.gbPaciente.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.gbQR.SuspendLayout()
        CType(Me.imgQR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblOrgano
        '
        Me.lblOrgano.BackColor = System.Drawing.Color.White
        Me.lblOrgano.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrgano.Location = New System.Drawing.Point(111, 140)
        Me.lblOrgano.Name = "lblOrgano"
        Me.lblOrgano.Size = New System.Drawing.Size(308, 23)
        Me.lblOrgano.TabIndex = 57
        '
        'gbPaciente
        '
        Me.gbPaciente.Controls.Add(Me.Label53)
        Me.gbPaciente.Controls.Add(Me.btnRetornarP)
        Me.gbPaciente.Controls.Add(Me.lvPaciente)
        Me.gbPaciente.Controls.Add(Me.txtPaciente)
        Me.gbPaciente.Controls.Add(Me.Label54)
        Me.gbPaciente.Location = New System.Drawing.Point(12, 54)
        Me.gbPaciente.Name = "gbPaciente"
        Me.gbPaciente.Size = New System.Drawing.Size(702, 279)
        Me.gbPaciente.TabIndex = 197
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
        Me.txtPaciente.Location = New System.Drawing.Point(92, 19)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(543, 20)
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
        'lblNombre
        '
        Me.lblNombre.BackColor = System.Drawing.Color.White
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNombre.Location = New System.Drawing.Point(111, 108)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(616, 23)
        Me.lblNombre.TabIndex = 56
        '
        'lblDiagnostico
        '
        Me.lblDiagnostico.BackColor = System.Drawing.Color.White
        Me.lblDiagnostico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiagnostico.Location = New System.Drawing.Point(111, 78)
        Me.lblDiagnostico.Name = "lblDiagnostico"
        Me.lblDiagnostico.Size = New System.Drawing.Size(616, 23)
        Me.lblDiagnostico.TabIndex = 55
        '
        'lblMedico
        '
        Me.lblMedico.BackColor = System.Drawing.Color.White
        Me.lblMedico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedico.Location = New System.Drawing.Point(298, 48)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(429, 23)
        Me.lblMedico.TabIndex = 54
        '
        'lblServicio
        '
        Me.lblServicio.BackColor = System.Drawing.Color.White
        Me.lblServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblServicio.Location = New System.Drawing.Point(111, 47)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(121, 23)
        Me.lblServicio.TabIndex = 53
        '
        'Label158
        '
        Me.Label158.AutoSize = True
        Me.Label158.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label158.Location = New System.Drawing.Point(603, 32)
        Me.Label158.Name = "Label158"
        Me.Label158.Size = New System.Drawing.Size(37, 13)
        Me.Label158.TabIndex = 195
        Me.Label158.Text = "Prov."
        '
        'lblProcedencia
        '
        Me.lblProcedencia.BackColor = System.Drawing.Color.White
        Me.lblProcedencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcedencia.Location = New System.Drawing.Point(533, 22)
        Me.lblProcedencia.Name = "lblProcedencia"
        Me.lblProcedencia.Size = New System.Drawing.Size(194, 23)
        Me.lblProcedencia.TabIndex = 52
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.White
        Me.lblTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipo.Location = New System.Drawing.Point(298, 21)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(121, 23)
        Me.lblTipo.TabIndex = 51
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage9)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(15, 80)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(871, 565)
        Me.TabControl1.TabIndex = 182
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.btnQR)
        Me.TabPage9.Controls.Add(Me.lvListaI)
        Me.TabPage9.Controls.Add(Me.txtCuerpo)
        Me.TabPage9.Controls.Add(Me.lblTipoMuestra)
        Me.TabPage9.Controls.Add(Me.lblOrgano)
        Me.TabPage9.Controls.Add(Me.lblNombre)
        Me.TabPage9.Controls.Add(Me.lblDiagnostico)
        Me.TabPage9.Controls.Add(Me.lblMedico)
        Me.TabPage9.Controls.Add(Me.lblServicio)
        Me.TabPage9.Controls.Add(Me.lblProcedencia)
        Me.TabPage9.Controls.Add(Me.lblTipo)
        Me.TabPage9.Controls.Add(Me.lblFechaEntrga)
        Me.TabPage9.Controls.Add(Me.Label156)
        Me.TabPage9.Controls.Add(Me.Label155)
        Me.TabPage9.Controls.Add(Me.Label154)
        Me.TabPage9.Controls.Add(Me.Label153)
        Me.TabPage9.Controls.Add(Me.Label152)
        Me.TabPage9.Controls.Add(Me.Label151)
        Me.TabPage9.Controls.Add(Me.Label147)
        Me.TabPage9.Controls.Add(Me.Label148)
        Me.TabPage9.Controls.Add(Me.Label149)
        Me.TabPage9.Controls.Add(Me.Label150)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(863, 539)
        Me.TabPage9.TabIndex = 5
        Me.TabPage9.Text = "Inf. Patología"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'lvListaI
        '
        Me.lvListaI.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader58, Me.ColumnHeader56, Me.ColumnHeader57})
        Me.lvListaI.FullRowSelect = True
        Me.lvListaI.GridLines = True
        Me.lvListaI.Location = New System.Drawing.Point(10, 190)
        Me.lvListaI.Name = "lvListaI"
        Me.lvListaI.Size = New System.Drawing.Size(269, 330)
        Me.lvListaI.TabIndex = 60
        Me.lvListaI.UseCompatibleStateImageBehavior = False
        Me.lvListaI.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader58
        '
        Me.ColumnHeader58.Text = "Id"
        Me.ColumnHeader58.Width = 0
        '
        'ColumnHeader56
        '
        Me.ColumnHeader56.Text = "Fecha"
        '
        'ColumnHeader57
        '
        Me.ColumnHeader57.Text = "Nombre"
        Me.ColumnHeader57.Width = 200
        '
        'txtCuerpo
        '
        Me.txtCuerpo.Location = New System.Drawing.Point(291, 170)
        Me.txtCuerpo.Name = "txtCuerpo"
        Me.txtCuerpo.Size = New System.Drawing.Size(566, 351)
        Me.txtCuerpo.TabIndex = 59
        Me.txtCuerpo.Text = ""
        '
        'lblTipoMuestra
        '
        Me.lblTipoMuestra.BackColor = System.Drawing.Color.White
        Me.lblTipoMuestra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipoMuestra.Location = New System.Drawing.Point(533, 140)
        Me.lblTipoMuestra.Name = "lblTipoMuestra"
        Me.lblTipoMuestra.Size = New System.Drawing.Size(324, 23)
        Me.lblTipoMuestra.TabIndex = 58
        '
        'lblFechaEntrga
        '
        Me.lblFechaEntrga.BackColor = System.Drawing.Color.White
        Me.lblFechaEntrga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFechaEntrga.Location = New System.Drawing.Point(111, 21)
        Me.lblFechaEntrga.Name = "lblFechaEntrga"
        Me.lblFechaEntrga.Size = New System.Drawing.Size(121, 23)
        Me.lblFechaEntrga.TabIndex = 50
        '
        'Label156
        '
        Me.Label156.AutoSize = True
        Me.Label156.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label156.Location = New System.Drawing.Point(15, 79)
        Me.Label156.Name = "Label156"
        Me.Label156.Size = New System.Drawing.Size(74, 13)
        Me.Label156.TabIndex = 49
        Me.Label156.Text = "Diagnostico"
        '
        'Label155
        '
        Me.Label155.AutoSize = True
        Me.Label155.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label155.Location = New System.Drawing.Point(248, 48)
        Me.Label155.Name = "Label155"
        Me.Label155.Size = New System.Drawing.Size(48, 13)
        Me.Label155.TabIndex = 48
        Me.Label155.Text = "Médico"
        '
        'Label154
        '
        Me.Label154.AutoSize = True
        Me.Label154.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label154.Location = New System.Drawing.Point(15, 48)
        Me.Label154.Name = "Label154"
        Me.Label154.Size = New System.Drawing.Size(53, 13)
        Me.Label154.TabIndex = 47
        Me.Label154.Text = "Servicio"
        '
        'Label153
        '
        Me.Label153.AutoSize = True
        Me.Label153.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label153.Location = New System.Drawing.Point(449, 22)
        Me.Label153.Name = "Label153"
        Me.Label153.Size = New System.Drawing.Size(78, 13)
        Me.Label153.TabIndex = 46
        Me.Label153.Text = "Procedencia"
        '
        'Label152
        '
        Me.Label152.AutoSize = True
        Me.Label152.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label152.Location = New System.Drawing.Point(248, 22)
        Me.Label152.Name = "Label152"
        Me.Label152.Size = New System.Drawing.Size(32, 13)
        Me.Label152.TabIndex = 45
        Me.Label152.Text = "Tipo"
        '
        'Label151
        '
        Me.Label151.AutoSize = True
        Me.Label151.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label151.Location = New System.Drawing.Point(15, 22)
        Me.Label151.Name = "Label151"
        Me.Label151.Size = New System.Drawing.Size(90, 13)
        Me.Label151.TabIndex = 44
        Me.Label151.Text = "Fecha Entrega"
        '
        'Label147
        '
        Me.Label147.AutoSize = True
        Me.Label147.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label147.Location = New System.Drawing.Point(15, 170)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(104, 13)
        Me.Label147.TabIndex = 13
        Me.Label147.Text = "Lista de Informes"
        '
        'Label148
        '
        Me.Label148.AutoSize = True
        Me.Label148.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label148.Location = New System.Drawing.Point(454, 140)
        Me.Label148.Name = "Label148"
        Me.Label148.Size = New System.Drawing.Size(81, 13)
        Me.Label148.TabIndex = 12
        Me.Label148.Text = "Tipo Muestra"
        '
        'Label149
        '
        Me.Label149.AutoSize = True
        Me.Label149.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label149.Location = New System.Drawing.Point(15, 140)
        Me.Label149.Name = "Label149"
        Me.Label149.Size = New System.Drawing.Size(48, 13)
        Me.Label149.TabIndex = 11
        Me.Label149.Text = "Organo"
        '
        'Label150
        '
        Me.Label150.AutoSize = True
        Me.Label150.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label150.Location = New System.Drawing.Point(15, 108)
        Me.Label150.Name = "Label150"
        Me.Label150.Size = New System.Drawing.Size(50, 13)
        Me.Label150.TabIndex = 10
        Me.Label150.Text = "Nombre"
        '
        'lblSexo
        '
        Me.lblSexo.BackColor = System.Drawing.Color.White
        Me.lblSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSexo.Location = New System.Drawing.Point(551, 29)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(23, 22)
        Me.lblSexo.TabIndex = 184
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(94, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "Paciente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "Historia"
        '
        'Label136
        '
        Me.Label136.AutoSize = True
        Me.Label136.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label136.Location = New System.Drawing.Point(492, 12)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(36, 13)
        Me.Label136.TabIndex = 185
        Me.Label136.Text = "Edad"
        '
        'Label159
        '
        Me.Label159.AutoSize = True
        Me.Label159.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label159.Location = New System.Drawing.Point(603, 55)
        Me.Label159.Name = "Label159"
        Me.Label159.Size = New System.Drawing.Size(33, 13)
        Me.Label159.TabIndex = 196
        Me.Label159.Text = "Dist."
        '
        'lblFNac
        '
        Me.lblFNac.BackColor = System.Drawing.Color.White
        Me.lblFNac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFNac.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFNac.Location = New System.Drawing.Point(392, 29)
        Me.lblFNac.Name = "lblFNac"
        Me.lblFNac.Size = New System.Drawing.Size(82, 22)
        Me.lblFNac.TabIndex = 188
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(15, 29)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(73, 20)
        Me.txtHistoria.TabIndex = 0
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaciente.Location = New System.Drawing.Point(94, 29)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(250, 22)
        Me.lblPaciente.TabIndex = 181
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.White
        Me.lblEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.Location = New System.Drawing.Point(480, 29)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(70, 22)
        Me.lblEdad.TabIndex = 186
        '
        'Label135
        '
        Me.Label135.AutoSize = True
        Me.Label135.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label135.Location = New System.Drawing.Point(539, 12)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(35, 13)
        Me.Label135.TabIndex = 183
        Me.Label135.Text = "Sexo"
        '
        'Label137
        '
        Me.Label137.AutoSize = True
        Me.Label137.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label137.Location = New System.Drawing.Point(389, 12)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(37, 13)
        Me.Label137.TabIndex = 187
        Me.Label137.Text = "FNac"
        '
        'Label157
        '
        Me.Label157.AutoSize = True
        Me.Label157.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label157.Location = New System.Drawing.Point(603, 10)
        Me.Label157.Name = "Label157"
        Me.Label157.Size = New System.Drawing.Size(34, 13)
        Me.Label157.TabIndex = 194
        Me.Label157.Text = "Dpto"
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(128, 128)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblDistrito
        '
        Me.lblDistrito.BackColor = System.Drawing.Color.White
        Me.lblDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDistrito.Location = New System.Drawing.Point(662, 54)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(224, 23)
        Me.lblDistrito.TabIndex = 193
        '
        'lblProvincia
        '
        Me.lblProvincia.BackColor = System.Drawing.Color.White
        Me.lblProvincia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProvincia.Location = New System.Drawing.Point(662, 29)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(224, 23)
        Me.lblProvincia.TabIndex = 192
        '
        'lblDpto
        '
        Me.lblDpto.BackColor = System.Drawing.Color.White
        Me.lblDpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDpto.Location = New System.Drawing.Point(662, 4)
        Me.lblDpto.Name = "lblDpto"
        Me.lblDpto.Size = New System.Drawing.Size(224, 23)
        Me.lblDpto.TabIndex = 191
        '
        'btnBuscarP
        '
        Me.btnBuscarP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarP.Location = New System.Drawing.Point(350, 27)
        Me.btnBuscarP.Name = "btnBuscarP"
        Me.btnBuscarP.Size = New System.Drawing.Size(36, 23)
        Me.btnBuscarP.TabIndex = 190
        Me.btnBuscarP.Text = "&B"
        Me.btnBuscarP.UseVisualStyleBackColor = True
        '
        'btnQR
        '
        Me.btnQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQR.Location = New System.Drawing.Point(757, 108)
        Me.btnQR.Name = "btnQR"
        Me.btnQR.Size = New System.Drawing.Size(54, 23)
        Me.btnQR.TabIndex = 198
        Me.btnQR.Text = "&QR"
        Me.btnQR.UseVisualStyleBackColor = True
        '
        'gbQR
        '
        Me.gbQR.Controls.Add(Me.btnRetornarQR)
        Me.gbQR.Controls.Add(Me.imgQR)
        Me.gbQR.Location = New System.Drawing.Point(56, 4)
        Me.gbQR.Name = "gbQR"
        Me.gbQR.Size = New System.Drawing.Size(786, 535)
        Me.gbQR.TabIndex = 265
        Me.gbQR.TabStop = False
        '
        'btnRetornarQR
        '
        Me.btnRetornarQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornarQR.Location = New System.Drawing.Point(362, 498)
        Me.btnRetornarQR.Name = "btnRetornarQR"
        Me.btnRetornarQR.Size = New System.Drawing.Size(75, 23)
        Me.btnRetornarQR.TabIndex = 207
        Me.btnRetornarQR.Text = "&Retornar"
        Me.btnRetornarQR.UseVisualStyleBackColor = True
        '
        'imgQR
        '
        Me.imgQR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.imgQR.BackColor = System.Drawing.Color.White
        Me.imgQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgQR.Location = New System.Drawing.Point(7, 16)
        Me.imgQR.Name = "imgQR"
        Me.imgQR.Size = New System.Drawing.Size(768, 476)
        Me.imgQR.TabIndex = 206
        Me.imgQR.TabStop = False
        '
        'frmPatologia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 656)
        Me.Controls.Add(Me.gbQR)
        Me.Controls.Add(Me.gbPaciente)
        Me.Controls.Add(Me.Label158)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblSexo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label136)
        Me.Controls.Add(Me.Label159)
        Me.Controls.Add(Me.lblFNac)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.lblEdad)
        Me.Controls.Add(Me.Label135)
        Me.Controls.Add(Me.Label137)
        Me.Controls.Add(Me.Label157)
        Me.Controls.Add(Me.lblDistrito)
        Me.Controls.Add(Me.lblProvincia)
        Me.Controls.Add(Me.lblDpto)
        Me.Controls.Add(Me.btnBuscarP)
        Me.Name = "frmPatologia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Patologia"
        Me.gbPaciente.ResumeLayout(False)
        Me.gbPaciente.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        Me.gbQR.ResumeLayout(False)
        CType(Me.imgQR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOrgano As System.Windows.Forms.Label
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
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblDiagnostico As System.Windows.Forms.Label
    Friend WithEvents lblMedico As System.Windows.Forms.Label
    Friend WithEvents lblServicio As System.Windows.Forms.Label
    Friend WithEvents Label158 As System.Windows.Forms.Label
    Friend WithEvents lblProcedencia As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents lvListaI As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader58 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader56 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader57 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtCuerpo As System.Windows.Forms.RichTextBox
    Friend WithEvents lblTipoMuestra As System.Windows.Forms.Label
    Friend WithEvents lblFechaEntrga As System.Windows.Forms.Label
    Friend WithEvents Label156 As System.Windows.Forms.Label
    Friend WithEvents Label155 As System.Windows.Forms.Label
    Friend WithEvents Label154 As System.Windows.Forms.Label
    Friend WithEvents Label153 As System.Windows.Forms.Label
    Friend WithEvents Label152 As System.Windows.Forms.Label
    Friend WithEvents Label151 As System.Windows.Forms.Label
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents Label149 As System.Windows.Forms.Label
    Friend WithEvents Label150 As System.Windows.Forms.Label
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Fuente As System.Windows.Forms.FontDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents lblFNac As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents lblProvincia As System.Windows.Forms.Label
    Friend WithEvents lblDpto As System.Windows.Forms.Label
    Friend WithEvents btnBuscarP As System.Windows.Forms.Button
    Friend WithEvents btnQR As System.Windows.Forms.Button
    Friend WithEvents gbQR As System.Windows.Forms.GroupBox
    Friend WithEvents btnRetornarQR As System.Windows.Forms.Button
    Friend WithEvents imgQR As System.Windows.Forms.PictureBox
End Class
