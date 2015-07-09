<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfromeMedicoTH
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
        Me.dtpFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.tbDatos = New System.Windows.Forms.TabControl()
        Me.tbDPaciente = New System.Windows.Forms.TabPage()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbReferencia = New System.Windows.Forms.RadioButton()
        Me.rbConsultExt = New System.Windows.Forms.RadioButton()
        Me.rbEmergencia = New System.Windows.Forms.RadioButton()
        Me.rbAmbulatorio = New System.Windows.Forms.RadioButton()
        Me.rbHospitalizado = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.TbEnfermedad = New System.Windows.Forms.TabPage()
        Me.txtSintomas = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.cboTipoEnfermedad = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbDiagnosticos = New System.Windows.Forms.TabPage()
        Me.gbDiagnosticoActual = New System.Windows.Forms.GroupBox()
        Me.txtDesCieA4 = New System.Windows.Forms.TextBox()
        Me.txtDesCieA3 = New System.Windows.Forms.TextBox()
        Me.txtDesCieA2 = New System.Windows.Forms.TextBox()
        Me.txtDesCieA1 = New System.Windows.Forms.TextBox()
        Me.txtCieA4 = New System.Windows.Forms.TextBox()
        Me.txtCieA3 = New System.Windows.Forms.TextBox()
        Me.txtCieA2 = New System.Windows.Forms.TextBox()
        Me.txtCieA1 = New System.Windows.Forms.TextBox()
        Me.gbDiagnosticoIngreso = New System.Windows.Forms.GroupBox()
        Me.txtDesCieI4 = New System.Windows.Forms.TextBox()
        Me.txtDesCieI3 = New System.Windows.Forms.TextBox()
        Me.txtDesCieI2 = New System.Windows.Forms.TextBox()
        Me.txtDesCieI1 = New System.Windows.Forms.TextBox()
        Me.txtCieI4 = New System.Windows.Forms.TextBox()
        Me.txtCieI3 = New System.Windows.Forms.TextBox()
        Me.txtCieI2 = New System.Windows.Forms.TextBox()
        Me.txtCieI1 = New System.Windows.Forms.TextBox()
        Me.tbDialisis = New System.Windows.Forms.TabPage()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbProcedimientos = New System.Windows.Forms.TabPage()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.txtAnatomia = New System.Windows.Forms.TextBox()
        Me.txtLaboratorio = New System.Windows.Forms.TextBox()
        Me.txtRadiologia = New System.Windows.Forms.TextBox()
        Me.txtProcedimiento = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbFarmInsu = New System.Windows.Forms.TabPage()
        Me.txtSustentacionTP = New System.Windows.Forms.TextBox()
        Me.TextBox33 = New System.Windows.Forms.TextBox()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.txtOtros = New System.Windows.Forms.TextBox()
        Me.txtMedicamentos = New System.Windows.Forms.TextBox()
        Me.txtInsumos = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.tbDatos.SuspendLayout()
        Me.tbDPaciente.SuspendLayout()
        Me.TbEnfermedad.SuspendLayout()
        Me.tbDiagnosticos.SuspendLayout()
        Me.gbDiagnosticoActual.SuspendLayout()
        Me.gbDiagnosticoIngreso.SuspendLayout()
        Me.tbDialisis.SuspendLayout()
        Me.tbProcedimientos.SuspendLayout()
        Me.tbFarmInsu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FECHA INGRESO A EESS"
        '
        'dtpFechaIngreso
        '
        Me.dtpFechaIngreso.Location = New System.Drawing.Point(153, 32)
        Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
        Me.dtpFechaIngreso.Size = New System.Drawing.Size(202, 20)
        Me.dtpFechaIngreso.TabIndex = 1
        Me.dtpFechaIngreso.Value = New Date(2015, 5, 19, 0, 0, 0, 0)
        '
        'lblHistoria
        '
        Me.lblHistoria.AutoSize = True
        Me.lblHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoria.Location = New System.Drawing.Point(451, 32)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(173, 25)
        Me.lblHistoria.TabIndex = 3
        Me.lblHistoria.Text = "NRO HISTORIA"
        '
        'tbDatos
        '
        Me.tbDatos.Controls.Add(Me.tbDPaciente)
        Me.tbDatos.Controls.Add(Me.TbEnfermedad)
        Me.tbDatos.Controls.Add(Me.tbDiagnosticos)
        Me.tbDatos.Controls.Add(Me.tbDialisis)
        Me.tbDatos.Controls.Add(Me.tbProcedimientos)
        Me.tbDatos.Controls.Add(Me.tbFarmInsu)
        Me.tbDatos.Location = New System.Drawing.Point(15, 58)
        Me.tbDatos.Name = "tbDatos"
        Me.tbDatos.SelectedIndex = 0
        Me.tbDatos.Size = New System.Drawing.Size(638, 375)
        Me.tbDatos.TabIndex = 4
        '
        'tbDPaciente
        '
        Me.tbDPaciente.BackColor = System.Drawing.SystemColors.Control
        Me.tbDPaciente.Controls.Add(Me.TextBox2)
        Me.tbDPaciente.Controls.Add(Me.Label6)
        Me.tbDPaciente.Controls.Add(Me.TextBox1)
        Me.tbDPaciente.Controls.Add(Me.txtServicio)
        Me.tbDPaciente.Controls.Add(Me.Label5)
        Me.tbDPaciente.Controls.Add(Me.Label3)
        Me.tbDPaciente.Controls.Add(Me.rbReferencia)
        Me.tbDPaciente.Controls.Add(Me.rbConsultExt)
        Me.tbDPaciente.Controls.Add(Me.rbEmergencia)
        Me.tbDPaciente.Controls.Add(Me.rbAmbulatorio)
        Me.tbDPaciente.Controls.Add(Me.rbHospitalizado)
        Me.tbDPaciente.Controls.Add(Me.Label4)
        Me.tbDPaciente.Controls.Add(Me.Label2)
        Me.tbDPaciente.Controls.Add(Me.lblPaciente)
        Me.tbDPaciente.Location = New System.Drawing.Point(4, 22)
        Me.tbDPaciente.Name = "tbDPaciente"
        Me.tbDPaciente.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDPaciente.Size = New System.Drawing.Size(630, 349)
        Me.tbDPaciente.TabIndex = 0
        Me.tbDPaciente.Text = "PACIENTE"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(117, 245)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(497, 82)
        Me.TextBox2.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 245)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "RESUMEN HC:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(121, 168)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(497, 58)
        Me.TextBox1.TabIndex = 29
        '
        'txtServicio
        '
        Me.txtServicio.Location = New System.Drawing.Point(121, 135)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(232, 20)
        Me.txtServicio.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "MOTIVO SOLICITUD: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "SERVICIO ACTUAL:"
        '
        'rbReferencia
        '
        Me.rbReferencia.AutoSize = True
        Me.rbReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbReferencia.Location = New System.Drawing.Point(515, 97)
        Me.rbReferencia.Name = "rbReferencia"
        Me.rbReferencia.Size = New System.Drawing.Size(103, 17)
        Me.rbReferencia.TabIndex = 25
        Me.rbReferencia.Text = "REFERENCIA"
        Me.rbReferencia.UseVisualStyleBackColor = True
        '
        'rbConsultExt
        '
        Me.rbConsultExt.AutoSize = True
        Me.rbConsultExt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConsultExt.Location = New System.Drawing.Point(268, 97)
        Me.rbConsultExt.Name = "rbConsultExt"
        Me.rbConsultExt.Size = New System.Drawing.Size(177, 17)
        Me.rbConsultExt.TabIndex = 23
        Me.rbConsultExt.Text = "CONSULTORIO EXTERNO"
        Me.rbConsultExt.UseVisualStyleBackColor = True
        '
        'rbEmergencia
        '
        Me.rbEmergencia.AutoSize = True
        Me.rbEmergencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEmergencia.Location = New System.Drawing.Point(121, 97)
        Me.rbEmergencia.Name = "rbEmergencia"
        Me.rbEmergencia.Size = New System.Drawing.Size(106, 17)
        Me.rbEmergencia.TabIndex = 24
        Me.rbEmergencia.Text = "EMERGENCIA"
        Me.rbEmergencia.UseVisualStyleBackColor = True
        '
        'rbAmbulatorio
        '
        Me.rbAmbulatorio.AutoSize = True
        Me.rbAmbulatorio.Checked = True
        Me.rbAmbulatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAmbulatorio.Location = New System.Drawing.Point(268, 60)
        Me.rbAmbulatorio.Name = "rbAmbulatorio"
        Me.rbAmbulatorio.Size = New System.Drawing.Size(114, 17)
        Me.rbAmbulatorio.TabIndex = 21
        Me.rbAmbulatorio.TabStop = True
        Me.rbAmbulatorio.Text = "AMBULATORIO"
        Me.rbAmbulatorio.UseVisualStyleBackColor = True
        '
        'rbHospitalizado
        '
        Me.rbHospitalizado.AutoSize = True
        Me.rbHospitalizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHospitalizado.Location = New System.Drawing.Point(121, 60)
        Me.rbHospitalizado.Name = "rbHospitalizado"
        Me.rbHospitalizado.Size = New System.Drawing.Size(124, 17)
        Me.rbHospitalizado.TabIndex = 22
        Me.rbHospitalizado.Text = "HOSPITALIZADO"
        Me.rbHospitalizado.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "TIPO INGRESO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "TIPO PACIENTE"
        '
        'lblPaciente
        '
        Me.lblPaciente.AutoSize = True
        Me.lblPaciente.Font = New System.Drawing.Font("Segoe Print", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaciente.Location = New System.Drawing.Point(6, 3)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(341, 47)
        Me.lblPaciente.TabIndex = 18
        Me.lblPaciente.Text = "DATOS DEL PACIENTE"
        '
        'TbEnfermedad
        '
        Me.TbEnfermedad.BackColor = System.Drawing.SystemColors.Control
        Me.TbEnfermedad.Controls.Add(Me.txtSintomas)
        Me.TbEnfermedad.Controls.Add(Me.TextBox4)
        Me.TbEnfermedad.Controls.Add(Me.TextBox3)
        Me.TbEnfermedad.Controls.Add(Me.cboTipoEnfermedad)
        Me.TbEnfermedad.Controls.Add(Me.Label9)
        Me.TbEnfermedad.Controls.Add(Me.Label8)
        Me.TbEnfermedad.Controls.Add(Me.Label10)
        Me.TbEnfermedad.Controls.Add(Me.Label7)
        Me.TbEnfermedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbEnfermedad.Location = New System.Drawing.Point(4, 22)
        Me.TbEnfermedad.Name = "TbEnfermedad"
        Me.TbEnfermedad.Padding = New System.Windows.Forms.Padding(3)
        Me.TbEnfermedad.Size = New System.Drawing.Size(630, 349)
        Me.TbEnfermedad.TabIndex = 1
        Me.TbEnfermedad.Text = "ENFERMEDADES"
        '
        'txtSintomas
        '
        Me.txtSintomas.Location = New System.Drawing.Point(14, 110)
        Me.txtSintomas.Multiline = True
        Me.txtSintomas.Name = "txtSintomas"
        Me.txtSintomas.Size = New System.Drawing.Size(591, 133)
        Me.txtSintomas.TabIndex = 38
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(391, 21)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(214, 20)
        Me.TextBox4.TabIndex = 37
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(134, 51)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(236, 20)
        Me.TextBox3.TabIndex = 36
        '
        'cboTipoEnfermedad
        '
        Me.cboTipoEnfermedad.FormattingEnabled = True
        Me.cboTipoEnfermedad.Location = New System.Drawing.Point(139, 21)
        Me.cboTipoEnfermedad.Name = "cboTipoEnfermedad"
        Me.cboTipoEnfermedad.Size = New System.Drawing.Size(124, 21)
        Me.cboTipoEnfermedad.TabIndex = 35
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(331, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "CURSO:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "FORMA INICIO:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "SIGNOS Y SINTOMAS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "TIPO ENFERMEDAD:"
        '
        'tbDiagnosticos
        '
        Me.tbDiagnosticos.BackColor = System.Drawing.SystemColors.Control
        Me.tbDiagnosticos.Controls.Add(Me.gbDiagnosticoActual)
        Me.tbDiagnosticos.Controls.Add(Me.gbDiagnosticoIngreso)
        Me.tbDiagnosticos.Location = New System.Drawing.Point(4, 22)
        Me.tbDiagnosticos.Name = "tbDiagnosticos"
        Me.tbDiagnosticos.Size = New System.Drawing.Size(630, 349)
        Me.tbDiagnosticos.TabIndex = 2
        Me.tbDiagnosticos.Text = "DIAGNOSTICOS"
        '
        'gbDiagnosticoActual
        '
        Me.gbDiagnosticoActual.Controls.Add(Me.txtDesCieA4)
        Me.gbDiagnosticoActual.Controls.Add(Me.txtDesCieA3)
        Me.gbDiagnosticoActual.Controls.Add(Me.txtDesCieA2)
        Me.gbDiagnosticoActual.Controls.Add(Me.txtDesCieA1)
        Me.gbDiagnosticoActual.Controls.Add(Me.txtCieA4)
        Me.gbDiagnosticoActual.Controls.Add(Me.txtCieA3)
        Me.gbDiagnosticoActual.Controls.Add(Me.txtCieA2)
        Me.gbDiagnosticoActual.Controls.Add(Me.txtCieA1)
        Me.gbDiagnosticoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDiagnosticoActual.Location = New System.Drawing.Point(23, 154)
        Me.gbDiagnosticoActual.Name = "gbDiagnosticoActual"
        Me.gbDiagnosticoActual.Size = New System.Drawing.Size(593, 139)
        Me.gbDiagnosticoActual.TabIndex = 8
        Me.gbDiagnosticoActual.TabStop = False
        Me.gbDiagnosticoActual.Text = "DIAGNOSTICO ACTUAL"
        '
        'txtDesCieA4
        '
        Me.txtDesCieA4.Location = New System.Drawing.Point(126, 102)
        Me.txtDesCieA4.Name = "txtDesCieA4"
        Me.txtDesCieA4.Size = New System.Drawing.Size(340, 21)
        Me.txtDesCieA4.TabIndex = 6
        '
        'txtDesCieA3
        '
        Me.txtDesCieA3.Location = New System.Drawing.Point(126, 76)
        Me.txtDesCieA3.Name = "txtDesCieA3"
        Me.txtDesCieA3.Size = New System.Drawing.Size(340, 21)
        Me.txtDesCieA3.TabIndex = 6
        '
        'txtDesCieA2
        '
        Me.txtDesCieA2.Location = New System.Drawing.Point(126, 51)
        Me.txtDesCieA2.Name = "txtDesCieA2"
        Me.txtDesCieA2.Size = New System.Drawing.Size(340, 21)
        Me.txtDesCieA2.TabIndex = 6
        '
        'txtDesCieA1
        '
        Me.txtDesCieA1.Location = New System.Drawing.Point(126, 25)
        Me.txtDesCieA1.Name = "txtDesCieA1"
        Me.txtDesCieA1.Size = New System.Drawing.Size(340, 21)
        Me.txtDesCieA1.TabIndex = 6
        '
        'txtCieA4
        '
        Me.txtCieA4.Location = New System.Drawing.Point(482, 102)
        Me.txtCieA4.Name = "txtCieA4"
        Me.txtCieA4.Size = New System.Drawing.Size(100, 21)
        Me.txtCieA4.TabIndex = 4
        '
        'txtCieA3
        '
        Me.txtCieA3.Location = New System.Drawing.Point(482, 76)
        Me.txtCieA3.Name = "txtCieA3"
        Me.txtCieA3.Size = New System.Drawing.Size(100, 21)
        Me.txtCieA3.TabIndex = 5
        '
        'txtCieA2
        '
        Me.txtCieA2.Location = New System.Drawing.Point(482, 51)
        Me.txtCieA2.Name = "txtCieA2"
        Me.txtCieA2.Size = New System.Drawing.Size(100, 21)
        Me.txtCieA2.TabIndex = 2
        '
        'txtCieA1
        '
        Me.txtCieA1.Location = New System.Drawing.Point(482, 25)
        Me.txtCieA1.Name = "txtCieA1"
        Me.txtCieA1.Size = New System.Drawing.Size(100, 21)
        Me.txtCieA1.TabIndex = 3
        '
        'gbDiagnosticoIngreso
        '
        Me.gbDiagnosticoIngreso.Controls.Add(Me.txtDesCieI4)
        Me.gbDiagnosticoIngreso.Controls.Add(Me.txtDesCieI3)
        Me.gbDiagnosticoIngreso.Controls.Add(Me.txtDesCieI2)
        Me.gbDiagnosticoIngreso.Controls.Add(Me.txtDesCieI1)
        Me.gbDiagnosticoIngreso.Controls.Add(Me.txtCieI4)
        Me.gbDiagnosticoIngreso.Controls.Add(Me.txtCieI3)
        Me.gbDiagnosticoIngreso.Controls.Add(Me.txtCieI2)
        Me.gbDiagnosticoIngreso.Controls.Add(Me.txtCieI1)
        Me.gbDiagnosticoIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDiagnosticoIngreso.Location = New System.Drawing.Point(20, 19)
        Me.gbDiagnosticoIngreso.Name = "gbDiagnosticoIngreso"
        Me.gbDiagnosticoIngreso.Size = New System.Drawing.Size(597, 129)
        Me.gbDiagnosticoIngreso.TabIndex = 7
        Me.gbDiagnosticoIngreso.TabStop = False
        Me.gbDiagnosticoIngreso.Text = "DIAGNOSTICO INGRESO"
        '
        'txtDesCieI4
        '
        Me.txtDesCieI4.Location = New System.Drawing.Point(129, 97)
        Me.txtDesCieI4.Name = "txtDesCieI4"
        Me.txtDesCieI4.Size = New System.Drawing.Size(340, 21)
        Me.txtDesCieI4.TabIndex = 6
        '
        'txtDesCieI3
        '
        Me.txtDesCieI3.Location = New System.Drawing.Point(129, 71)
        Me.txtDesCieI3.Name = "txtDesCieI3"
        Me.txtDesCieI3.Size = New System.Drawing.Size(340, 21)
        Me.txtDesCieI3.TabIndex = 6
        '
        'txtDesCieI2
        '
        Me.txtDesCieI2.Location = New System.Drawing.Point(129, 46)
        Me.txtDesCieI2.Name = "txtDesCieI2"
        Me.txtDesCieI2.Size = New System.Drawing.Size(340, 21)
        Me.txtDesCieI2.TabIndex = 6
        '
        'txtDesCieI1
        '
        Me.txtDesCieI1.Location = New System.Drawing.Point(129, 20)
        Me.txtDesCieI1.Name = "txtDesCieI1"
        Me.txtDesCieI1.Size = New System.Drawing.Size(340, 21)
        Me.txtDesCieI1.TabIndex = 6
        '
        'txtCieI4
        '
        Me.txtCieI4.Location = New System.Drawing.Point(485, 97)
        Me.txtCieI4.Name = "txtCieI4"
        Me.txtCieI4.Size = New System.Drawing.Size(100, 21)
        Me.txtCieI4.TabIndex = 1
        '
        'txtCieI3
        '
        Me.txtCieI3.Location = New System.Drawing.Point(485, 71)
        Me.txtCieI3.Name = "txtCieI3"
        Me.txtCieI3.Size = New System.Drawing.Size(100, 21)
        Me.txtCieI3.TabIndex = 1
        '
        'txtCieI2
        '
        Me.txtCieI2.Location = New System.Drawing.Point(485, 46)
        Me.txtCieI2.Name = "txtCieI2"
        Me.txtCieI2.Size = New System.Drawing.Size(100, 21)
        Me.txtCieI2.TabIndex = 1
        '
        'txtCieI1
        '
        Me.txtCieI1.Location = New System.Drawing.Point(485, 20)
        Me.txtCieI1.Name = "txtCieI1"
        Me.txtCieI1.Size = New System.Drawing.Size(100, 21)
        Me.txtCieI1.TabIndex = 1
        '
        'tbDialisis
        '
        Me.tbDialisis.BackColor = System.Drawing.SystemColors.Control
        Me.tbDialisis.Controls.Add(Me.TextBox23)
        Me.tbDialisis.Controls.Add(Me.Label14)
        Me.tbDialisis.Controls.Add(Me.TextBox22)
        Me.tbDialisis.Controls.Add(Me.Label13)
        Me.tbDialisis.Controls.Add(Me.TextBox21)
        Me.tbDialisis.Controls.Add(Me.Label12)
        Me.tbDialisis.Controls.Add(Me.Label11)
        Me.tbDialisis.Location = New System.Drawing.Point(4, 22)
        Me.tbDialisis.Name = "tbDialisis"
        Me.tbDialisis.Size = New System.Drawing.Size(630, 349)
        Me.tbDialisis.TabIndex = 3
        Me.tbDialisis.Text = "DIALISIS"
        '
        'TextBox23
        '
        Me.TextBox23.Location = New System.Drawing.Point(15, 248)
        Me.TextBox23.Multiline = True
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(590, 62)
        Me.TextBox23.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 222)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(171, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "FÍSTULA ARTERIO-VENOSA"
        '
        'TextBox22
        '
        Me.TextBox22.Location = New System.Drawing.Point(15, 139)
        Me.TextBox22.Multiline = True
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(590, 62)
        Me.TextBox22.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 113)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(153, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "CATETER PERMANENTE"
        '
        'TextBox21
        '
        Me.TextBox21.Location = New System.Drawing.Point(15, 38)
        Me.TextBox21.Multiline = True
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(590, 62)
        Me.TextBox21.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(135, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "CATETER TEMPORAL"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "CATETER TEMPORAL"
        '
        'tbProcedimientos
        '
        Me.tbProcedimientos.Controls.Add(Me.TextBox31)
        Me.tbProcedimientos.Controls.Add(Me.TextBox29)
        Me.tbProcedimientos.Controls.Add(Me.TextBox27)
        Me.tbProcedimientos.Controls.Add(Me.TextBox25)
        Me.tbProcedimientos.Controls.Add(Me.txtAnatomia)
        Me.tbProcedimientos.Controls.Add(Me.txtLaboratorio)
        Me.tbProcedimientos.Controls.Add(Me.txtRadiologia)
        Me.tbProcedimientos.Controls.Add(Me.txtProcedimiento)
        Me.tbProcedimientos.Controls.Add(Me.Label17)
        Me.tbProcedimientos.Controls.Add(Me.Label16)
        Me.tbProcedimientos.Controls.Add(Me.Label20)
        Me.tbProcedimientos.Controls.Add(Me.Label19)
        Me.tbProcedimientos.Controls.Add(Me.Label18)
        Me.tbProcedimientos.Controls.Add(Me.Label15)
        Me.tbProcedimientos.Location = New System.Drawing.Point(4, 22)
        Me.tbProcedimientos.Name = "tbProcedimientos"
        Me.tbProcedimientos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProcedimientos.Size = New System.Drawing.Size(630, 349)
        Me.tbProcedimientos.TabIndex = 4
        Me.tbProcedimientos.Text = "PROCEDIMIENTOS"
        '
        'TextBox31
        '
        Me.TextBox31.Location = New System.Drawing.Point(473, 237)
        Me.TextBox31.Multiline = True
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New System.Drawing.Size(151, 64)
        Me.TextBox31.TabIndex = 1
        '
        'TextBox29
        '
        Me.TextBox29.Location = New System.Drawing.Point(473, 167)
        Me.TextBox29.Multiline = True
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New System.Drawing.Size(151, 64)
        Me.TextBox29.TabIndex = 1
        '
        'TextBox27
        '
        Me.TextBox27.Location = New System.Drawing.Point(473, 97)
        Me.TextBox27.Multiline = True
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New System.Drawing.Size(151, 64)
        Me.TextBox27.TabIndex = 1
        '
        'TextBox25
        '
        Me.TextBox25.Location = New System.Drawing.Point(473, 27)
        Me.TextBox25.Multiline = True
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(151, 64)
        Me.TextBox25.TabIndex = 1
        '
        'txtAnatomia
        '
        Me.txtAnatomia.Location = New System.Drawing.Point(195, 237)
        Me.txtAnatomia.Multiline = True
        Me.txtAnatomia.Name = "txtAnatomia"
        Me.txtAnatomia.Size = New System.Drawing.Size(272, 64)
        Me.txtAnatomia.TabIndex = 1
        '
        'txtLaboratorio
        '
        Me.txtLaboratorio.Location = New System.Drawing.Point(195, 167)
        Me.txtLaboratorio.Multiline = True
        Me.txtLaboratorio.Name = "txtLaboratorio"
        Me.txtLaboratorio.Size = New System.Drawing.Size(272, 64)
        Me.txtLaboratorio.TabIndex = 1
        '
        'txtRadiologia
        '
        Me.txtRadiologia.Location = New System.Drawing.Point(195, 97)
        Me.txtRadiologia.Multiline = True
        Me.txtRadiologia.Name = "txtRadiologia"
        Me.txtRadiologia.Size = New System.Drawing.Size(272, 64)
        Me.txtRadiologia.TabIndex = 1
        '
        'txtProcedimiento
        '
        Me.txtProcedimiento.Location = New System.Drawing.Point(195, 27)
        Me.txtProcedimiento.Multiline = True
        Me.txtProcedimiento.Name = "txtProcedimiento"
        Me.txtProcedimiento.Size = New System.Drawing.Size(272, 64)
        Me.txtProcedimiento.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(470, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(135, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "PLAN PRESUPUESTO"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(248, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(140, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "INSTAURADO ACTUAL"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 263)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(153, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "ANATOMIA PATOLOGICA"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 196)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(130, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "LABOTARIO CLINICO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 127)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(167, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "RADIOLOGIA E IMAGENES "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(183, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "PROCEDIMIENTO MEDICO QX"
        '
        'tbFarmInsu
        '
        Me.tbFarmInsu.BackColor = System.Drawing.SystemColors.Control
        Me.tbFarmInsu.Controls.Add(Me.txtSustentacionTP)
        Me.tbFarmInsu.Controls.Add(Me.TextBox33)
        Me.tbFarmInsu.Controls.Add(Me.TextBox30)
        Me.tbFarmInsu.Controls.Add(Me.TextBox26)
        Me.tbFarmInsu.Controls.Add(Me.txtOtros)
        Me.tbFarmInsu.Controls.Add(Me.txtMedicamentos)
        Me.tbFarmInsu.Controls.Add(Me.txtInsumos)
        Me.tbFarmInsu.Controls.Add(Me.Label24)
        Me.tbFarmInsu.Controls.Add(Me.Label23)
        Me.tbFarmInsu.Controls.Add(Me.Label22)
        Me.tbFarmInsu.Controls.Add(Me.Label26)
        Me.tbFarmInsu.Controls.Add(Me.Label25)
        Me.tbFarmInsu.Controls.Add(Me.Label21)
        Me.tbFarmInsu.Location = New System.Drawing.Point(4, 22)
        Me.tbFarmInsu.Name = "tbFarmInsu"
        Me.tbFarmInsu.Size = New System.Drawing.Size(630, 349)
        Me.tbFarmInsu.TabIndex = 5
        Me.tbFarmInsu.Text = "FARMACOS - INSUMOS"
        '
        'txtSustentacionTP
        '
        Me.txtSustentacionTP.Location = New System.Drawing.Point(17, 281)
        Me.txtSustentacionTP.Multiline = True
        Me.txtSustentacionTP.Name = "txtSustentacionTP"
        Me.txtSustentacionTP.Size = New System.Drawing.Size(584, 48)
        Me.txtSustentacionTP.TabIndex = 2
        '
        'TextBox33
        '
        Me.TextBox33.Location = New System.Drawing.Point(449, 186)
        Me.TextBox33.Multiline = True
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New System.Drawing.Size(156, 67)
        Me.TextBox33.TabIndex = 1
        '
        'TextBox30
        '
        Me.TextBox30.Location = New System.Drawing.Point(449, 113)
        Me.TextBox30.Multiline = True
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New System.Drawing.Size(156, 67)
        Me.TextBox30.TabIndex = 1
        '
        'TextBox26
        '
        Me.TextBox26.Location = New System.Drawing.Point(449, 40)
        Me.TextBox26.Multiline = True
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(156, 67)
        Me.TextBox26.TabIndex = 1
        '
        'txtOtros
        '
        Me.txtOtros.Location = New System.Drawing.Point(197, 186)
        Me.txtOtros.Multiline = True
        Me.txtOtros.Name = "txtOtros"
        Me.txtOtros.Size = New System.Drawing.Size(246, 67)
        Me.txtOtros.TabIndex = 1
        '
        'txtMedicamentos
        '
        Me.txtMedicamentos.Location = New System.Drawing.Point(197, 113)
        Me.txtMedicamentos.Multiline = True
        Me.txtMedicamentos.Name = "txtMedicamentos"
        Me.txtMedicamentos.Size = New System.Drawing.Size(246, 67)
        Me.txtMedicamentos.TabIndex = 1
        '
        'txtInsumos
        '
        Me.txtInsumos.Location = New System.Drawing.Point(197, 40)
        Me.txtInsumos.Multiline = True
        Me.txtInsumos.Name = "txtInsumos"
        Me.txtInsumos.Size = New System.Drawing.Size(246, 67)
        Me.txtInsumos.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(14, 265)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(344, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "SUSTENTACION DEL PLAN DE TRABAJO PRESUPUESTO"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(14, 220)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "OTROS"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 139)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(179, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "FARMACOS/MEDICAMENTOS"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(465, 9)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(135, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "PLAN PRESUPUESTO"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(233, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(140, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "INSTAURADO ACTUAL"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(14, 67)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(157, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "INSUMOS/MATERIAL QX."
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(202, 458)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(291, 33)
        Me.btnGrabar.TabIndex = 5
        Me.btnGrabar.Text = "&GRABAR E IMPRIMIR"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'frmInfromeMedicoTH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 497)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.tbDatos)
        Me.Controls.Add(Me.lblHistoria)
        Me.Controls.Add(Me.dtpFechaIngreso)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmInfromeMedicoTH"
        Me.Text = "INFORME MEDICO"
        Me.tbDatos.ResumeLayout(False)
        Me.tbDPaciente.ResumeLayout(False)
        Me.tbDPaciente.PerformLayout()
        Me.TbEnfermedad.ResumeLayout(False)
        Me.TbEnfermedad.PerformLayout()
        Me.tbDiagnosticos.ResumeLayout(False)
        Me.gbDiagnosticoActual.ResumeLayout(False)
        Me.gbDiagnosticoActual.PerformLayout()
        Me.gbDiagnosticoIngreso.ResumeLayout(False)
        Me.gbDiagnosticoIngreso.PerformLayout()
        Me.tbDialisis.ResumeLayout(False)
        Me.tbDialisis.PerformLayout()
        Me.tbProcedimientos.ResumeLayout(False)
        Me.tbProcedimientos.PerformLayout()
        Me.tbFarmInsu.ResumeLayout(False)
        Me.tbFarmInsu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents tbDatos As System.Windows.Forms.TabControl
    Friend WithEvents tbDPaciente As System.Windows.Forms.TabPage
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtServicio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbReferencia As System.Windows.Forms.RadioButton
    Friend WithEvents rbConsultExt As System.Windows.Forms.RadioButton
    Friend WithEvents rbEmergencia As System.Windows.Forms.RadioButton
    Friend WithEvents rbAmbulatorio As System.Windows.Forms.RadioButton
    Friend WithEvents rbHospitalizado As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents TbEnfermedad As System.Windows.Forms.TabPage
    Friend WithEvents cboTipoEnfermedad As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSintomas As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbDiagnosticos As System.Windows.Forms.TabPage
    Friend WithEvents gbDiagnosticoActual As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesCieA4 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesCieA3 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesCieA2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesCieA1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCieA4 As System.Windows.Forms.TextBox
    Friend WithEvents txtCieA3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCieA2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCieA1 As System.Windows.Forms.TextBox
    Friend WithEvents gbDiagnosticoIngreso As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesCieI4 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesCieI3 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesCieI2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesCieI1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCieI4 As System.Windows.Forms.TextBox
    Friend WithEvents txtCieI3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCieI2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCieI1 As System.Windows.Forms.TextBox
    Friend WithEvents tbDialisis As System.Windows.Forms.TabPage
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbProcedimientos As System.Windows.Forms.TabPage
    Friend WithEvents TextBox31 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox29 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox27 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents txtAnatomia As System.Windows.Forms.TextBox
    Friend WithEvents txtLaboratorio As System.Windows.Forms.TextBox
    Friend WithEvents txtRadiologia As System.Windows.Forms.TextBox
    Friend WithEvents txtProcedimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbFarmInsu As System.Windows.Forms.TabPage
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtSustentacionTP As System.Windows.Forms.TextBox
    Friend WithEvents TextBox33 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox30 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents txtOtros As System.Windows.Forms.TextBox
    Friend WithEvents txtMedicamentos As System.Windows.Forms.TextBox
    Friend WithEvents txtInsumos As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
End Class
