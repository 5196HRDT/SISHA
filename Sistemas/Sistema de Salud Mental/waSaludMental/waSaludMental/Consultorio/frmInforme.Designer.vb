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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpF1 = New System.Windows.Forms.DateTimePicker()
        Me.lvCupos = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblCupos = New System.Windows.Forms.Label()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPaciente = New System.Windows.Forms.Label()
        Me.txtRuta = New System.Windows.Forms.Label()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSubir = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lvHistorial = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.oAbrir = New System.Windows.Forms.OpenFileDialog()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gbPS = New System.Windows.Forms.GroupBox()
        Me.cboPsicologo = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboCondicionPS = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkRetraimiento = New System.Windows.Forms.CheckBox()
        Me.chkHostilidad = New System.Windows.Forms.CheckBox()
        Me.chkImpulsividad = New System.Windows.Forms.CheckBox()
        Me.chkAgresividad = New System.Windows.Forms.CheckBox()
        Me.chkInestabilidad = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboOrganicidad = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.txtPuntaje = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboPersonalidad = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gbPQ = New System.Windows.Forms.GroupBox()
        Me.cboPsiquiatra = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboCondicionPQ = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboDrogas = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDesQC = New System.Windows.Forms.TextBox()
        Me.txtCieQC = New System.Windows.Forms.TextBox()
        Me.txtDesQB = New System.Windows.Forms.TextBox()
        Me.txtCieQB = New System.Windows.Forms.TextBox()
        Me.txtDesQA = New System.Windows.Forms.TextBox()
        Me.txtCieQA = New System.Windows.Forms.TextBox()
        Me.gbConsulta = New System.Windows.Forms.GroupBox()
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnRetornarC = New System.Windows.Forms.Button()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.gbPS.SuspendLayout()
        Me.gbPQ.SuspendLayout()
        Me.gbConsulta.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Citas"
        '
        'dtpF1
        '
        Me.dtpF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpF1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF1.Location = New System.Drawing.Point(15, 25)
        Me.dtpF1.Name = "dtpF1"
        Me.dtpF1.Size = New System.Drawing.Size(109, 20)
        Me.dtpF1.TabIndex = 103
        '
        'lvCupos
        '
        Me.lvCupos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lvCupos.FullRowSelect = True
        Me.lvCupos.GridLines = True
        Me.lvCupos.Location = New System.Drawing.Point(12, 51)
        Me.lvCupos.Name = "lvCupos"
        Me.lvCupos.Size = New System.Drawing.Size(549, 212)
        Me.lvCupos.TabIndex = 154
        Me.lvCupos.UseCompatibleStateImageBehavior = False
        Me.lvCupos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Historia"
        Me.ColumnHeader9.Width = 80
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Paciente"
        Me.ColumnHeader10.Width = 450
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "IdCupo"
        Me.ColumnHeader11.Width = 0
        '
        'lblCupos
        '
        Me.lblCupos.BackColor = System.Drawing.Color.White
        Me.lblCupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCupos.Location = New System.Drawing.Point(449, 28)
        Me.lblCupos.Name = "lblCupos"
        Me.lblCupos.Size = New System.Drawing.Size(112, 17)
        Me.lblCupos.TabIndex = 157
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(91, 419)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(470, 119)
        Me.lvTabla.TabIndex = 158
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
        Me.ColumnHeader2.Text = "Tipo"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Titulo"
        Me.ColumnHeader3.Width = 320
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Extension"
        Me.ColumnHeader4.Width = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(146, 403)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 13)
        Me.Label4.TabIndex = 159
        Me.Label4.Text = "LISTA DE INFORMES DE SALUD MENTAL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(118, 546)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(418, 13)
        Me.Label6.TabIndex = 160
        Me.Label6.Text = "(*) Selecione un Informe y Presione la tecla ENTER para Abrir el Informe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 277)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "Historia"
        '
        'lblHistoria
        '
        Me.lblHistoria.BackColor = System.Drawing.Color.White
        Me.lblHistoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoria.Location = New System.Drawing.Point(90, 277)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(93, 23)
        Me.lblHistoria.TabIndex = 162
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 306)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 166
        Me.Label7.Text = "Paciente"
        '
        'txtPaciente
        '
        Me.txtPaciente.BackColor = System.Drawing.Color.White
        Me.txtPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaciente.Location = New System.Drawing.Point(90, 306)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(471, 23)
        Me.txtPaciente.TabIndex = 167
        '
        'txtRuta
        '
        Me.txtRuta.BackColor = System.Drawing.Color.White
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Location = New System.Drawing.Point(90, 369)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(403, 23)
        Me.txtRuta.TabIndex = 170
        '
        'btnAbrir
        '
        Me.btnAbrir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbrir.Location = New System.Drawing.Point(499, 369)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(62, 23)
        Me.btnAbrir.TabIndex = 168
        Me.btnAbrir.Text = "&Abrir"
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 369)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Ruta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 341)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 171
        Me.Label5.Text = "Tipo"
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.White
        Me.lblTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(90, 340)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(93, 23)
        Me.lblTipo.TabIndex = 172
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.White
        Me.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(229, 340)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(332, 23)
        Me.lblTitulo.TabIndex = 174
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(191, 342)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 173
        Me.Label9.Text = "Tipo"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(453, 574)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 178
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(341, 574)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 177
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnSubir
        '
        Me.btnSubir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubir.Location = New System.Drawing.Point(224, 574)
        Me.btnSubir.Name = "btnSubir"
        Me.btnSubir.Size = New System.Drawing.Size(75, 23)
        Me.btnSubir.TabIndex = 176
        Me.btnSubir.Text = "&Subir"
        Me.btnSubir.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(108, 574)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 175
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(691, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(285, 13)
        Me.Label8.TabIndex = 179
        Me.Label8.Text = "LISTA DE INFORMES CLINICOS DEL PACIENTE"
        '
        'lvHistorial
        '
        Me.lvHistorial.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.lvHistorial.FullRowSelect = True
        Me.lvHistorial.GridLines = True
        Me.lvHistorial.Location = New System.Drawing.Point(578, 51)
        Me.lvHistorial.Name = "lvHistorial"
        Me.lvHistorial.Size = New System.Drawing.Size(576, 212)
        Me.lvHistorial.TabIndex = 180
        Me.lvHistorial.UseCompatibleStateImageBehavior = False
        Me.lvHistorial.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Id"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Fecha"
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Responsable"
        Me.ColumnHeader7.Width = 200
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Tipo"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Titulo"
        Me.ColumnHeader12.Width = 200
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Extension"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "IdCupo"
        '
        'oAbrir
        '
        Me.oAbrir.FileName = "OpenFileDialog1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(610, 267)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(423, 13)
        Me.Label10.TabIndex = 181
        Me.Label10.Text = "(*) Seleccione un Informe y Presione la tecla SUPR o DEL para eliminarlo"
        '
        'gbPS
        '
        Me.gbPS.Controls.Add(Me.cboPsicologo)
        Me.gbPS.Controls.Add(Me.Label21)
        Me.gbPS.Controls.Add(Me.cboCondicionPS)
        Me.gbPS.Controls.Add(Me.Label15)
        Me.gbPS.Controls.Add(Me.chkRetraimiento)
        Me.gbPS.Controls.Add(Me.chkHostilidad)
        Me.gbPS.Controls.Add(Me.chkImpulsividad)
        Me.gbPS.Controls.Add(Me.chkAgresividad)
        Me.gbPS.Controls.Add(Me.chkInestabilidad)
        Me.gbPS.Controls.Add(Me.Label14)
        Me.gbPS.Controls.Add(Me.cboOrganicidad)
        Me.gbPS.Controls.Add(Me.Label13)
        Me.gbPS.Controls.Add(Me.cboCategoria)
        Me.gbPS.Controls.Add(Me.txtPuntaje)
        Me.gbPS.Controls.Add(Me.Label12)
        Me.gbPS.Controls.Add(Me.cboPersonalidad)
        Me.gbPS.Controls.Add(Me.Label11)
        Me.gbPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPS.Location = New System.Drawing.Point(578, 287)
        Me.gbPS.Name = "gbPS"
        Me.gbPS.Size = New System.Drawing.Size(576, 129)
        Me.gbPS.TabIndex = 182
        Me.gbPS.TabStop = False
        Me.gbPS.Text = "Resumen del Informe Psicológico"
        '
        'cboPsicologo
        '
        Me.cboPsicologo.FormattingEnabled = True
        Me.cboPsicologo.Location = New System.Drawing.Point(364, 95)
        Me.cboPsicologo.Name = "cboPsicologo"
        Me.cboPsicologo.Size = New System.Drawing.Size(206, 21)
        Me.cboPsicologo.TabIndex = 211
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(275, 98)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 189
        Me.Label21.Text = "Psicologo"
        '
        'cboCondicionPS
        '
        Me.cboCondicionPS.FormattingEnabled = True
        Me.cboCondicionPS.Items.AddRange(New Object() {"APTO", "INAPTO"})
        Me.cboCondicionPS.Location = New System.Drawing.Point(106, 98)
        Me.cboCondicionPS.Name = "cboCondicionPS"
        Me.cboCondicionPS.Size = New System.Drawing.Size(163, 21)
        Me.cboCondicionPS.TabIndex = 188
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 187
        Me.Label15.Text = "Condición"
        '
        'chkRetraimiento
        '
        Me.chkRetraimiento.AutoSize = True
        Me.chkRetraimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRetraimiento.Location = New System.Drawing.Point(480, 40)
        Me.chkRetraimiento.Name = "chkRetraimiento"
        Me.chkRetraimiento.Size = New System.Drawing.Size(97, 17)
        Me.chkRetraimiento.TabIndex = 186
        Me.chkRetraimiento.Text = "Retraimiento"
        Me.chkRetraimiento.UseVisualStyleBackColor = True
        '
        'chkHostilidad
        '
        Me.chkHostilidad.AutoSize = True
        Me.chkHostilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHostilidad.Location = New System.Drawing.Point(480, 18)
        Me.chkHostilidad.Name = "chkHostilidad"
        Me.chkHostilidad.Size = New System.Drawing.Size(82, 17)
        Me.chkHostilidad.TabIndex = 185
        Me.chkHostilidad.Text = "Hostilidad"
        Me.chkHostilidad.UseVisualStyleBackColor = True
        '
        'chkImpulsividad
        '
        Me.chkImpulsividad.AutoSize = True
        Me.chkImpulsividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImpulsividad.Location = New System.Drawing.Point(377, 59)
        Me.chkImpulsividad.Name = "chkImpulsividad"
        Me.chkImpulsividad.Size = New System.Drawing.Size(96, 17)
        Me.chkImpulsividad.TabIndex = 184
        Me.chkImpulsividad.Text = "Impulsividad"
        Me.chkImpulsividad.UseVisualStyleBackColor = True
        '
        'chkAgresividad
        '
        Me.chkAgresividad.AutoSize = True
        Me.chkAgresividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAgresividad.Location = New System.Drawing.Point(376, 40)
        Me.chkAgresividad.Name = "chkAgresividad"
        Me.chkAgresividad.Size = New System.Drawing.Size(92, 17)
        Me.chkAgresividad.TabIndex = 183
        Me.chkAgresividad.Text = "Agresividad"
        Me.chkAgresividad.UseVisualStyleBackColor = True
        '
        'chkInestabilidad
        '
        Me.chkInestabilidad.AutoSize = True
        Me.chkInestabilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInestabilidad.Location = New System.Drawing.Point(376, 18)
        Me.chkInestabilidad.Name = "chkInestabilidad"
        Me.chkInestabilidad.Size = New System.Drawing.Size(98, 17)
        Me.chkInestabilidad.TabIndex = 182
        Me.chkInestabilidad.Text = "Inestabilidad"
        Me.chkInestabilidad.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(275, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(95, 13)
        Me.Label14.TabIndex = 181
        Me.Label14.Text = "Area Emocional"
        '
        'cboOrganicidad
        '
        Me.cboOrganicidad.FormattingEnabled = True
        Me.cboOrganicidad.Items.AddRange(New Object() {"SI EVIDENCIA COMPROMISO", "NO EVIDENCIA COMPROMISO"})
        Me.cboOrganicidad.Location = New System.Drawing.Point(106, 71)
        Me.cboOrganicidad.Name = "cboOrganicidad"
        Me.cboOrganicidad.Size = New System.Drawing.Size(163, 21)
        Me.cboOrganicidad.TabIndex = 180
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 179
        Me.Label13.Text = "Organicidad"
        '
        'cboCategoria
        '
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Items.AddRange(New Object() {"MUY INFERIOR", "INFERIOR", "NORMAL PROMEDIO", "SUPERIOR AL TERMINO MEDIO", "SUPERIOR"})
        Me.cboCategoria.Location = New System.Drawing.Point(170, 44)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(99, 21)
        Me.cboCategoria.TabIndex = 178
        '
        'txtPuntaje
        '
        Me.txtPuntaje.Location = New System.Drawing.Point(106, 44)
        Me.txtPuntaje.Name = "txtPuntaje"
        Me.txtPuntaje.Size = New System.Drawing.Size(58, 20)
        Me.txtPuntaje.TabIndex = 177
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(5, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 176
        Me.Label12.Text = "Inteligencia"
        '
        'cboPersonalidad
        '
        Me.cboPersonalidad.FormattingEnabled = True
        Me.cboPersonalidad.Items.AddRange(New Object() {"SI PATOLOGICO", "NO PATOLOGICO"})
        Me.cboPersonalidad.Location = New System.Drawing.Point(106, 16)
        Me.cboPersonalidad.Name = "cboPersonalidad"
        Me.cboPersonalidad.Size = New System.Drawing.Size(163, 21)
        Me.cboPersonalidad.TabIndex = 175
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(5, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 174
        Me.Label11.Text = "Personalidad"
        '
        'gbPQ
        '
        Me.gbPQ.Controls.Add(Me.cboPsiquiatra)
        Me.gbPQ.Controls.Add(Me.Label22)
        Me.gbPQ.Controls.Add(Me.cboCondicionPQ)
        Me.gbPQ.Controls.Add(Me.Label20)
        Me.gbPQ.Controls.Add(Me.cboDrogas)
        Me.gbPQ.Controls.Add(Me.Label19)
        Me.gbPQ.Controls.Add(Me.Label18)
        Me.gbPQ.Controls.Add(Me.Label17)
        Me.gbPQ.Controls.Add(Me.Label16)
        Me.gbPQ.Controls.Add(Me.txtDesQC)
        Me.gbPQ.Controls.Add(Me.txtCieQC)
        Me.gbPQ.Controls.Add(Me.txtDesQB)
        Me.gbPQ.Controls.Add(Me.txtCieQB)
        Me.gbPQ.Controls.Add(Me.txtDesQA)
        Me.gbPQ.Controls.Add(Me.txtCieQA)
        Me.gbPQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPQ.Location = New System.Drawing.Point(578, 425)
        Me.gbPQ.Name = "gbPQ"
        Me.gbPQ.Size = New System.Drawing.Size(576, 162)
        Me.gbPQ.TabIndex = 183
        Me.gbPQ.TabStop = False
        Me.gbPQ.Text = "Resumen Informe Psiquiátrico"
        '
        'cboPsiquiatra
        '
        Me.cboPsiquiatra.FormattingEnabled = True
        Me.cboPsiquiatra.Location = New System.Drawing.Point(368, 131)
        Me.cboPsiquiatra.Name = "cboPsiquiatra"
        Me.cboPsiquiatra.Size = New System.Drawing.Size(202, 21)
        Me.cboPsiquiatra.TabIndex = 221
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(275, 131)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 13)
        Me.Label22.TabIndex = 220
        Me.Label22.Text = "Psiquiatra"
        '
        'cboCondicionPQ
        '
        Me.cboCondicionPQ.FormattingEnabled = True
        Me.cboCondicionPQ.Items.AddRange(New Object() {"APTO", "INAPTO"})
        Me.cboCondicionPQ.Location = New System.Drawing.Point(69, 128)
        Me.cboCondicionPQ.Name = "cboCondicionPQ"
        Me.cboCondicionPQ.Size = New System.Drawing.Size(163, 21)
        Me.cboCondicionPQ.TabIndex = 219
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 131)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 218
        Me.Label20.Text = "Condición"
        '
        'cboDrogas
        '
        Me.cboDrogas.FormattingEnabled = True
        Me.cboDrogas.Items.AddRange(New Object() {"POSITIVO", "NEGATIVO"})
        Me.cboDrogas.Location = New System.Drawing.Point(69, 49)
        Me.cboDrogas.Name = "cboDrogas"
        Me.cboDrogas.Size = New System.Drawing.Size(163, 21)
        Me.cboDrogas.TabIndex = 217
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 216
        Me.Label19.Text = "Drogas"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 102)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 215
        Me.Label18.Text = "Dx Clínico"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 13)
        Me.Label17.TabIndex = 214
        Me.Label17.Text = "Dx Clínico"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 213
        Me.Label16.Text = "Dx PSQ"
        '
        'txtDesQC
        '
        Me.txtDesQC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesQC.Location = New System.Drawing.Point(129, 102)
        Me.txtDesQC.Name = "txtDesQC"
        Me.txtDesQC.Size = New System.Drawing.Size(441, 20)
        Me.txtDesQC.TabIndex = 212
        '
        'txtCieQC
        '
        Me.txtCieQC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCieQC.Location = New System.Drawing.Point(69, 102)
        Me.txtCieQC.Name = "txtCieQC"
        Me.txtCieQC.Size = New System.Drawing.Size(54, 20)
        Me.txtCieQC.TabIndex = 211
        '
        'txtDesQB
        '
        Me.txtDesQB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesQB.Location = New System.Drawing.Point(129, 76)
        Me.txtDesQB.Name = "txtDesQB"
        Me.txtDesQB.Size = New System.Drawing.Size(441, 20)
        Me.txtDesQB.TabIndex = 210
        '
        'txtCieQB
        '
        Me.txtCieQB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCieQB.Location = New System.Drawing.Point(69, 76)
        Me.txtCieQB.Name = "txtCieQB"
        Me.txtCieQB.Size = New System.Drawing.Size(54, 20)
        Me.txtCieQB.TabIndex = 209
        '
        'txtDesQA
        '
        Me.txtDesQA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesQA.Location = New System.Drawing.Point(129, 24)
        Me.txtDesQA.Name = "txtDesQA"
        Me.txtDesQA.Size = New System.Drawing.Size(441, 20)
        Me.txtDesQA.TabIndex = 208
        '
        'txtCieQA
        '
        Me.txtCieQA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCieQA.Location = New System.Drawing.Point(69, 24)
        Me.txtCieQA.Name = "txtCieQA"
        Me.txtCieQA.Size = New System.Drawing.Size(54, 20)
        Me.txtCieQA.TabIndex = 207
        '
        'gbConsulta
        '
        Me.gbConsulta.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.gbConsulta.Controls.Add(Me.lvDet)
        Me.gbConsulta.Controls.Add(Me.Label27)
        Me.gbConsulta.Controls.Add(Me.btnRetornarC)
        Me.gbConsulta.Controls.Add(Me.txtDes)
        Me.gbConsulta.Controls.Add(Me.Label100)
        Me.gbConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConsulta.Location = New System.Drawing.Point(224, 238)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Size = New System.Drawing.Size(703, 277)
        Me.gbConsulta.TabIndex = 215
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta General"
        '
        'lvDet
        '
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader15, Me.ColumnHeader16})
        Me.lvDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(9, 52)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(668, 177)
        Me.lvDet.TabIndex = 2
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "CIE10"
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Descripción"
        Me.ColumnHeader16.Width = 700
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(6, 246)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(265, 13)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Presione Enter para Insertar un Codigo CIE10"
        '
        'btnRetornarC
        '
        Me.btnRetornarC.Location = New System.Drawing.Point(332, 238)
        Me.btnRetornarC.Name = "btnRetornarC"
        Me.btnRetornarC.Size = New System.Drawing.Size(78, 29)
        Me.btnRetornarC.TabIndex = 3
        Me.btnRetornarC.Text = "&Retornar"
        Me.btnRetornarC.UseVisualStyleBackColor = True
        '
        'txtDes
        '
        Me.txtDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes.Location = New System.Drawing.Point(135, 22)
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(409, 20)
        Me.txtDes.TabIndex = 1
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.Location = New System.Drawing.Point(6, 22)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(124, 13)
        Me.Label100.TabIndex = 0
        Me.Label100.Text = "Ingresar Descripción"
        '
        'frmInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 610)
        Me.Controls.Add(Me.gbConsulta)
        Me.Controls.Add(Me.gbPQ)
        Me.Controls.Add(Me.gbPS)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lvHistorial)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSubir)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Me.btnAbrir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPaciente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblHistoria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lvTabla)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblCupos)
        Me.Controls.Add(Me.lvCupos)
        Me.Controls.Add(Me.dtpF1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmInforme"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Psicología"
        Me.gbPS.ResumeLayout(False)
        Me.gbPS.PerformLayout()
        Me.gbPQ.ResumeLayout(False)
        Me.gbPQ.PerformLayout()
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpF1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lvCupos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblCupos As System.Windows.Forms.Label
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPaciente As System.Windows.Forms.Label
    Friend WithEvents txtRuta As System.Windows.Forms.Label
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnSubir As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lvHistorial As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents oAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents gbPS As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents txtPuntaje As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboPersonalidad As System.Windows.Forms.ComboBox
    Friend WithEvents chkHostilidad As System.Windows.Forms.CheckBox
    Friend WithEvents chkImpulsividad As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgresividad As System.Windows.Forms.CheckBox
    Friend WithEvents chkInestabilidad As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboOrganicidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboCondicionPS As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkRetraimiento As System.Windows.Forms.CheckBox
    Friend WithEvents gbPQ As System.Windows.Forms.GroupBox
    Friend WithEvents cboDrogas As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDesQC As System.Windows.Forms.TextBox
    Friend WithEvents txtCieQC As System.Windows.Forms.TextBox
    Friend WithEvents txtDesQB As System.Windows.Forms.TextBox
    Friend WithEvents txtCieQB As System.Windows.Forms.TextBox
    Friend WithEvents txtDesQA As System.Windows.Forms.TextBox
    Friend WithEvents txtCieQA As System.Windows.Forms.TextBox
    Friend WithEvents cboCondicionPQ As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnRetornarC As System.Windows.Forms.Button
    Friend WithEvents txtDes As System.Windows.Forms.TextBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboPsicologo As System.Windows.Forms.ComboBox
    Friend WithEvents cboPsiquiatra As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
