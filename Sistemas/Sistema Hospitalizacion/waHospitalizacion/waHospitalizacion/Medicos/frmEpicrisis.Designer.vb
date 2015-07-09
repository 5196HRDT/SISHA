<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEpicrisis
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
        Me.tcGrupo = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gbConsulta = New System.Windows.Forms.GroupBox()
        Me.btnRetornarCie = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lvCIE = New System.Windows.Forms.ListView()
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.txtCie = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtEvolucion = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtExamenesAuxiliares = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtExamenClinico = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtAnamnesis = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lvTratamiento = New System.Windows.Forms.ListView()
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDiasTratamiento = New System.Windows.Forms.TextBox()
        Me.txtFrecuencia = New System.Windows.Forms.TextBox()
        Me.txtVia = New System.Windows.Forms.TextBox()
        Me.txtDosis = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtNombreGenerico = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.gbCPT = New System.Windows.Forms.GroupBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.btnRetornarCPT = New System.Windows.Forms.Button()
        Me.lvFiltroCPT = New System.Windows.Forms.ListView()
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFiltroCPT = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lvCPT = New System.Windows.Forms.ListView()
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDesCPT = New System.Windows.Forms.TextBox()
        Me.txtCPT = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.lvRN = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboOrden = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtSemanas = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTalla = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboSexo = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboCondicion = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpFechaNac = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.gbCIEN = New System.Windows.Forms.GroupBox()
        Me.btnRetornarCIEN = New System.Windows.Forms.Button()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lvCIEN = New System.Windows.Forms.ListView()
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFiltroCieN = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cboNecropsia = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaM = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboCausa = New System.Windows.Forms.ComboBox()
        Me.txtDescripcionM = New System.Windows.Forms.TextBox()
        Me.txtCieM = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboServicio = New System.Windows.Forms.ComboBox()
        Me.cboSubServicio = New System.Windows.Forms.ComboBox()
        Me.cboEspecialidad = New System.Windows.Forms.ComboBox()
        Me.cboCama = New System.Windows.Forms.ComboBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
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
        Me.tcGrupo.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbConsulta.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.gbCPT.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.gbCIEN.SuspendLayout()
        Me.gbBPac.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(546, 10)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 13)
        Me.Label23.TabIndex = 165
        Me.Label23.Text = "Hora"
        '
        'lblHora
        '
        Me.lblHora.BackColor = System.Drawing.Color.White
        Me.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHora.Location = New System.Drawing.Point(581, 9)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(86, 23)
        Me.lblHora.TabIndex = 164
        '
        'lblEnfermeraIng
        '
        Me.lblEnfermeraIng.BackColor = System.Drawing.Color.White
        Me.lblEnfermeraIng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEnfermeraIng.Location = New System.Drawing.Point(454, 112)
        Me.lblEnfermeraIng.Name = "lblEnfermeraIng"
        Me.lblEnfermeraIng.Size = New System.Drawing.Size(274, 23)
        Me.lblEnfermeraIng.TabIndex = 163
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(346, 114)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(110, 13)
        Me.Label22.TabIndex = 162
        Me.Label22.Text = "Enfermera Ingreso"
        '
        'lblMedicoIng
        '
        Me.lblMedicoIng.BackColor = System.Drawing.Color.White
        Me.lblMedicoIng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedicoIng.Location = New System.Drawing.Point(118, 112)
        Me.lblMedicoIng.Name = "lblMedicoIng"
        Me.lblMedicoIng.Size = New System.Drawing.Size(213, 23)
        Me.lblMedicoIng.TabIndex = 161
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 114)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(98, 13)
        Me.Label21.TabIndex = 160
        Me.Label21.Text = "Medico Ingreso "
        '
        'cboEnfermeraO
        '
        Me.cboEnfermeraO.FormattingEnabled = True
        Me.cboEnfermeraO.Location = New System.Drawing.Point(454, 138)
        Me.cboEnfermeraO.Name = "cboEnfermeraO"
        Me.cboEnfermeraO.Size = New System.Drawing.Size(274, 21)
        Me.cboEnfermeraO.TabIndex = 158
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(345, 138)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 13)
        Me.Label20.TabIndex = 159
        Me.Label20.Text = "Enfermera"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(346, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 156
        Me.Label14.Text = "Cama"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 154
        Me.Label13.Text = "Especialidad"
        '
        'cboResponsable
        '
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(118, 138)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(213, 21)
        Me.cboResponsable.TabIndex = 143
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 153
        Me.Label8.Text = "Medico "
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.White
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.Location = New System.Drawing.Point(454, 10)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(86, 23)
        Me.lblFecha.TabIndex = 152
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(345, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 151
        Me.Label5.Text = "Fecha Ingreso"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(345, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Sub Servicio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "Servicio"
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Location = New System.Drawing.Point(118, 34)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(421, 23)
        Me.lblPaciente.TabIndex = 146
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "Paciente"
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(118, 10)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(91, 20)
        Me.txtHistoria.TabIndex = 142
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "Historia Clinica"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(482, 500)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 169
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(366, 500)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 168
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(255, 500)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 167
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(150, 500)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 166
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'tcGrupo
        '
        Me.tcGrupo.Controls.Add(Me.TabPage1)
        Me.tcGrupo.Controls.Add(Me.TabPage2)
        Me.tcGrupo.Controls.Add(Me.TabPage6)
        Me.tcGrupo.Controls.Add(Me.TabPage3)
        Me.tcGrupo.Controls.Add(Me.TabPage5)
        Me.tcGrupo.Controls.Add(Me.TabPage4)
        Me.tcGrupo.Location = New System.Drawing.Point(16, 189)
        Me.tcGrupo.Name = "tcGrupo"
        Me.tcGrupo.SelectedIndex = 0
        Me.tcGrupo.Size = New System.Drawing.Size(712, 305)
        Me.tcGrupo.TabIndex = 170
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gbConsulta)
        Me.TabPage1.Controls.Add(Me.lvCIE)
        Me.TabPage1.Controls.Add(Me.txtDes)
        Me.TabPage1.Controls.Add(Me.txtCie)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(704, 279)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Diagnóstico Ingreso"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gbConsulta
        '
        Me.gbConsulta.BackColor = System.Drawing.Color.Silver
        Me.gbConsulta.Controls.Add(Me.btnRetornarCie)
        Me.gbConsulta.Controls.Add(Me.Label32)
        Me.gbConsulta.Controls.Add(Me.btnRetornar)
        Me.gbConsulta.Controls.Add(Me.lvDet)
        Me.gbConsulta.Controls.Add(Me.txtFiltro)
        Me.gbConsulta.Controls.Add(Me.Label31)
        Me.gbConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConsulta.Location = New System.Drawing.Point(6, 17)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Size = New System.Drawing.Size(692, 244)
        Me.gbConsulta.TabIndex = 118
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta General"
        '
        'btnRetornarCie
        '
        Me.btnRetornarCie.Location = New System.Drawing.Point(558, 206)
        Me.btnRetornarCie.Name = "btnRetornarCie"
        Me.btnRetornarCie.Size = New System.Drawing.Size(78, 29)
        Me.btnRetornarCie.TabIndex = 5
        Me.btnRetornarCie.Text = "&Retornar"
        Me.btnRetornarCie.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(6, 206)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(431, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Seleccione un Diagnóstico y Presione Enter para Insertar un Codigo CIE10"
        '
        'btnRetornar
        '
        Me.btnRetornar.Location = New System.Drawing.Point(742, 235)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Size = New System.Drawing.Size(78, 29)
        Me.btnRetornar.TabIndex = 3
        Me.btnRetornar.Text = "&Retornar"
        Me.btnRetornar.UseVisualStyleBackColor = True
        '
        'lvDet
        '
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader24, Me.ColumnHeader25})
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(9, 52)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(677, 151)
        Me.lvDet.TabIndex = 2
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "CIE10"
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Descripción"
        Me.ColumnHeader25.Width = 700
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
        'lvCIE
        '
        Me.lvCIE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader22, Me.ColumnHeader23})
        Me.lvCIE.FullRowSelect = True
        Me.lvCIE.GridLines = True
        Me.lvCIE.Location = New System.Drawing.Point(15, 59)
        Me.lvCIE.Name = "lvCIE"
        Me.lvCIE.Size = New System.Drawing.Size(674, 161)
        Me.lvCIE.TabIndex = 70
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
        'txtDes
        '
        Me.txtDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes.Location = New System.Drawing.Point(112, 33)
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(380, 20)
        Me.txtDes.TabIndex = 69
        '
        'txtCie
        '
        Me.txtCie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie.Location = New System.Drawing.Point(15, 33)
        Me.txtCie.Name = "txtCie"
        Me.txtCie.Size = New System.Drawing.Size(91, 20)
        Me.txtCie.TabIndex = 68
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(12, 17)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(144, 13)
        Me.Label28.TabIndex = 71
        Me.Label28.Text = "Diagnosticos de Ingreso"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtEvolucion)
        Me.TabPage2.Controls.Add(Me.Label35)
        Me.TabPage2.Controls.Add(Me.txtExamenesAuxiliares)
        Me.TabPage2.Controls.Add(Me.Label34)
        Me.TabPage2.Controls.Add(Me.txtExamenClinico)
        Me.TabPage2.Controls.Add(Me.Label33)
        Me.TabPage2.Controls.Add(Me.txtAnamnesis)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(704, 279)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Resumen"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtEvolucion
        '
        Me.txtEvolucion.Location = New System.Drawing.Point(9, 213)
        Me.txtEvolucion.Multiline = True
        Me.txtEvolucion.Name = "txtEvolucion"
        Me.txtEvolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEvolucion.Size = New System.Drawing.Size(689, 41)
        Me.txtEvolucion.TabIndex = 162
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(6, 197)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(63, 13)
        Me.Label35.TabIndex = 161
        Me.Label35.Text = "Evolución"
        '
        'txtExamenesAuxiliares
        '
        Me.txtExamenesAuxiliares.Location = New System.Drawing.Point(9, 152)
        Me.txtExamenesAuxiliares.Multiline = True
        Me.txtExamenesAuxiliares.Name = "txtExamenesAuxiliares"
        Me.txtExamenesAuxiliares.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExamenesAuxiliares.Size = New System.Drawing.Size(689, 41)
        Me.txtExamenesAuxiliares.TabIndex = 160
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(6, 136)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(122, 13)
        Me.Label34.TabIndex = 159
        Me.Label34.Text = "Exámenes Auxiliares"
        '
        'txtExamenClinico
        '
        Me.txtExamenClinico.Location = New System.Drawing.Point(9, 95)
        Me.txtExamenClinico.Multiline = True
        Me.txtExamenClinico.Name = "txtExamenClinico"
        Me.txtExamenClinico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExamenClinico.Size = New System.Drawing.Size(689, 41)
        Me.txtExamenClinico.TabIndex = 158
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(6, 79)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(95, 13)
        Me.Label33.TabIndex = 157
        Me.Label33.Text = "Exámen Clínico"
        '
        'txtAnamnesis
        '
        Me.txtAnamnesis.Location = New System.Drawing.Point(9, 19)
        Me.txtAnamnesis.Multiline = True
        Me.txtAnamnesis.Name = "txtAnamnesis"
        Me.txtAnamnesis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAnamnesis.Size = New System.Drawing.Size(689, 57)
        Me.txtAnamnesis.TabIndex = 156
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(6, 3)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(67, 13)
        Me.Label30.TabIndex = 155
        Me.Label30.Text = "Anamnesis"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.Label29)
        Me.TabPage6.Controls.Add(Me.btnAgregar)
        Me.TabPage6.Controls.Add(Me.lvTratamiento)
        Me.TabPage6.Controls.Add(Me.txtDiasTratamiento)
        Me.TabPage6.Controls.Add(Me.txtFrecuencia)
        Me.TabPage6.Controls.Add(Me.txtVia)
        Me.TabPage6.Controls.Add(Me.txtDosis)
        Me.TabPage6.Controls.Add(Me.Label40)
        Me.TabPage6.Controls.Add(Me.Label39)
        Me.TabPage6.Controls.Add(Me.Label38)
        Me.TabPage6.Controls.Add(Me.Label37)
        Me.TabPage6.Controls.Add(Me.txtNombreGenerico)
        Me.TabPage6.Controls.Add(Me.Label36)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(704, 279)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Tratamiento"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(398, 266)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(291, 13)
        Me.Label29.TabIndex = 166
        Me.Label29.Text = "Presione la Tecla DEL o SUPR para eliminar un Tratamiento"
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(462, 108)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 165
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lvTratamiento
        '
        Me.lvTratamiento.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader32})
        Me.lvTratamiento.FullRowSelect = True
        Me.lvTratamiento.GridLines = True
        Me.lvTratamiento.Location = New System.Drawing.Point(6, 135)
        Me.lvTratamiento.Name = "lvTratamiento"
        Me.lvTratamiento.Size = New System.Drawing.Size(695, 128)
        Me.lvTratamiento.TabIndex = 164
        Me.lvTratamiento.UseCompatibleStateImageBehavior = False
        Me.lvTratamiento.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Nombre Genérico"
        Me.ColumnHeader28.Width = 200
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Dosis"
        Me.ColumnHeader29.Width = 100
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "Via de Administración"
        Me.ColumnHeader30.Width = 160
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "Fecuencia"
        Me.ColumnHeader31.Width = 80
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "Dias de Tto."
        Me.ColumnHeader32.Width = 100
        '
        'txtDiasTratamiento
        '
        Me.txtDiasTratamiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiasTratamiento.Location = New System.Drawing.Point(145, 112)
        Me.txtDiasTratamiento.Name = "txtDiasTratamiento"
        Me.txtDiasTratamiento.Size = New System.Drawing.Size(230, 20)
        Me.txtDiasTratamiento.TabIndex = 163
        '
        'txtFrecuencia
        '
        Me.txtFrecuencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFrecuencia.Location = New System.Drawing.Point(145, 86)
        Me.txtFrecuencia.Name = "txtFrecuencia"
        Me.txtFrecuencia.Size = New System.Drawing.Size(230, 20)
        Me.txtFrecuencia.TabIndex = 162
        '
        'txtVia
        '
        Me.txtVia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVia.Location = New System.Drawing.Point(145, 60)
        Me.txtVia.Name = "txtVia"
        Me.txtVia.Size = New System.Drawing.Size(392, 20)
        Me.txtVia.TabIndex = 161
        '
        'txtDosis
        '
        Me.txtDosis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDosis.Location = New System.Drawing.Point(145, 34)
        Me.txtDosis.Name = "txtDosis"
        Me.txtDosis.Size = New System.Drawing.Size(230, 20)
        Me.txtDosis.TabIndex = 160
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(3, 108)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(79, 13)
        Me.Label40.TabIndex = 159
        Me.Label40.Text = "Días de Tto."
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(3, 82)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(70, 13)
        Me.Label39.TabIndex = 158
        Me.Label39.Text = "Frecuencia"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(3, 57)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(131, 13)
        Me.Label38.TabIndex = 157
        Me.Label38.Text = "Vía de Administración"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(3, 34)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(38, 13)
        Me.Label37.TabIndex = 156
        Me.Label37.Text = "Dosis"
        '
        'txtNombreGenerico
        '
        Me.txtNombreGenerico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreGenerico.Location = New System.Drawing.Point(145, 7)
        Me.txtNombreGenerico.Name = "txtNombreGenerico"
        Me.txtNombreGenerico.Size = New System.Drawing.Size(392, 20)
        Me.txtNombreGenerico.TabIndex = 155
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(3, 10)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(105, 13)
        Me.Label36.TabIndex = 154
        Me.Label36.Text = "Nombre Genérico"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.gbCPT)
        Me.TabPage3.Controls.Add(Me.lvCPT)
        Me.TabPage3.Controls.Add(Me.txtDesCPT)
        Me.TabPage3.Controls.Add(Me.txtCPT)
        Me.TabPage3.Controls.Add(Me.Label43)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(704, 279)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Procedimientos Terapeúticos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'gbCPT
        '
        Me.gbCPT.BackColor = System.Drawing.Color.Silver
        Me.gbCPT.Controls.Add(Me.Label41)
        Me.gbCPT.Controls.Add(Me.btnRetornarCPT)
        Me.gbCPT.Controls.Add(Me.lvFiltroCPT)
        Me.gbCPT.Controls.Add(Me.txtFiltroCPT)
        Me.gbCPT.Controls.Add(Me.Label42)
        Me.gbCPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCPT.Location = New System.Drawing.Point(13, 3)
        Me.gbCPT.Name = "gbCPT"
        Me.gbCPT.Size = New System.Drawing.Size(687, 264)
        Me.gbCPT.TabIndex = 13
        Me.gbCPT.TabStop = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.ForeColor = System.Drawing.Color.Red
        Me.Label41.Location = New System.Drawing.Point(8, 227)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(255, 13)
        Me.Label41.TabIndex = 4
        Me.Label41.Text = "Presione Enter para Insertar un Codigo CPT"
        '
        'btnRetornarCPT
        '
        Me.btnRetornarCPT.Location = New System.Drawing.Point(372, 227)
        Me.btnRetornarCPT.Name = "btnRetornarCPT"
        Me.btnRetornarCPT.Size = New System.Drawing.Size(78, 29)
        Me.btnRetornarCPT.TabIndex = 3
        Me.btnRetornarCPT.Text = "&Retornar"
        Me.btnRetornarCPT.UseVisualStyleBackColor = True
        '
        'lvFiltroCPT
        '
        Me.lvFiltroCPT.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader33, Me.ColumnHeader34})
        Me.lvFiltroCPT.FullRowSelect = True
        Me.lvFiltroCPT.GridLines = True
        Me.lvFiltroCPT.Location = New System.Drawing.Point(9, 52)
        Me.lvFiltroCPT.Name = "lvFiltroCPT"
        Me.lvFiltroCPT.Size = New System.Drawing.Size(668, 166)
        Me.lvFiltroCPT.TabIndex = 2
        Me.lvFiltroCPT.UseCompatibleStateImageBehavior = False
        Me.lvFiltroCPT.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "CPT"
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "Descripción"
        Me.ColumnHeader34.Width = 700
        '
        'txtFiltroCPT
        '
        Me.txtFiltroCPT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltroCPT.Location = New System.Drawing.Point(135, 22)
        Me.txtFiltroCPT.Name = "txtFiltroCPT"
        Me.txtFiltroCPT.Size = New System.Drawing.Size(342, 20)
        Me.txtFiltroCPT.TabIndex = 1
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(6, 22)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(124, 13)
        Me.Label42.TabIndex = 0
        Me.Label42.Text = "Ingresar Descripción"
        '
        'lvCPT
        '
        Me.lvCPT.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader26, Me.ColumnHeader27})
        Me.lvCPT.FullRowSelect = True
        Me.lvCPT.GridLines = True
        Me.lvCPT.Location = New System.Drawing.Point(13, 49)
        Me.lvCPT.Name = "lvCPT"
        Me.lvCPT.Size = New System.Drawing.Size(688, 208)
        Me.lvCPT.TabIndex = 10
        Me.lvCPT.UseCompatibleStateImageBehavior = False
        Me.lvCPT.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Codigo"
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Descripcion"
        Me.ColumnHeader27.Width = 600
        '
        'txtDesCPT
        '
        Me.txtDesCPT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesCPT.Location = New System.Drawing.Point(124, 19)
        Me.txtDesCPT.Name = "txtDesCPT"
        Me.txtDesCPT.Size = New System.Drawing.Size(550, 20)
        Me.txtDesCPT.TabIndex = 9
        '
        'txtCPT
        '
        Me.txtCPT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCPT.Location = New System.Drawing.Point(16, 19)
        Me.txtCPT.Name = "txtCPT"
        Me.txtCPT.Size = New System.Drawing.Size(91, 20)
        Me.txtCPT.TabIndex = 8
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(13, 3)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(167, 13)
        Me.Label43.TabIndex = 72
        Me.Label43.Text = "Procedimientos CPT Ingreso"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.lvRN)
        Me.TabPage5.Controls.Add(Me.cboOrden)
        Me.TabPage5.Controls.Add(Me.Label27)
        Me.TabPage5.Controls.Add(Me.txtSemanas)
        Me.TabPage5.Controls.Add(Me.Label12)
        Me.TabPage5.Controls.Add(Me.txtHora)
        Me.TabPage5.Controls.Add(Me.Label15)
        Me.TabPage5.Controls.Add(Me.Label24)
        Me.TabPage5.Controls.Add(Me.txtTalla)
        Me.TabPage5.Controls.Add(Me.Label25)
        Me.TabPage5.Controls.Add(Me.Label16)
        Me.TabPage5.Controls.Add(Me.txtPeso)
        Me.TabPage5.Controls.Add(Me.Label17)
        Me.TabPage5.Controls.Add(Me.cboSexo)
        Me.TabPage5.Controls.Add(Me.Label18)
        Me.TabPage5.Controls.Add(Me.cboCondicion)
        Me.TabPage5.Controls.Add(Me.Label19)
        Me.TabPage5.Controls.Add(Me.dtpFechaNac)
        Me.TabPage5.Controls.Add(Me.Label26)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(704, 279)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Nacimiento"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lvRN
        '
        Me.lvRN.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader20, Me.ColumnHeader9, Me.ColumnHeader12, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19})
        Me.lvRN.FullRowSelect = True
        Me.lvRN.GridLines = True
        Me.lvRN.Location = New System.Drawing.Point(13, 116)
        Me.lvRN.Name = "lvRN"
        Me.lvRN.Size = New System.Drawing.Size(651, 146)
        Me.lvRN.TabIndex = 166
        Me.lvRN.UseCompatibleStateImageBehavior = False
        Me.lvRN.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "FechaNcto"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "HoraNcto"
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Orden"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Condición"
        Me.ColumnHeader9.Width = 100
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Sexo"
        Me.ColumnHeader12.Width = 80
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Peso"
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Talla"
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Semanas"
        '
        'cboOrden
        '
        Me.cboOrden.FormattingEnabled = True
        Me.cboOrden.Items.AddRange(New Object() {"UNICO", "PRIMERO", "SEGUNDO", "TERCERO", "CUARTO", "QUINTO", "SEXTO", "SEPTIMO", "OCTAVO", "NOVENO", "DECIMO"})
        Me.cboOrden.Location = New System.Drawing.Point(543, 11)
        Me.cboOrden.Name = "cboOrden"
        Me.cboOrden.Size = New System.Drawing.Size(121, 21)
        Me.cboOrden.TabIndex = 165
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(471, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 13)
        Me.Label27.TabIndex = 164
        Me.Label27.Text = "Orden"
        '
        'txtSemanas
        '
        Me.txtSemanas.Location = New System.Drawing.Point(543, 67)
        Me.txtSemanas.Name = "txtSemanas"
        Me.txtSemanas.Size = New System.Drawing.Size(42, 20)
        Me.txtSemanas.TabIndex = 163
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(471, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 162
        Me.Label12.Text = "#Semanas"
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(387, 12)
        Me.txtHora.Mask = "00:00"
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(49, 20)
        Me.txtHora.TabIndex = 149
        Me.txtHora.ValidatingType = GetType(Date)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(263, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 161
        Me.Label15.Text = "Hora Nacimiento"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(431, 74)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(23, 13)
        Me.Label24.TabIndex = 160
        Me.Label24.Text = "cm"
        '
        'txtTalla
        '
        Me.txtTalla.Location = New System.Drawing.Point(387, 71)
        Me.txtTalla.Name = "txtTalla"
        Me.txtTalla.Size = New System.Drawing.Size(37, 20)
        Me.txtTalla.TabIndex = 153
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(263, 74)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(35, 13)
        Me.Label25.TabIndex = 159
        Me.Label25.Text = "Talla"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(173, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(22, 13)
        Me.Label16.TabIndex = 158
        Me.Label16.Text = "gr."
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(125, 74)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(42, 20)
        Me.txtPeso.TabIndex = 152
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 74)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 157
        Me.Label17.Text = "Peso"
        '
        'cboSexo
        '
        Me.cboSexo.FormattingEnabled = True
        Me.cboSexo.Items.AddRange(New Object() {"FEMENINO", "MASCULINO"})
        Me.cboSexo.Location = New System.Drawing.Point(387, 40)
        Me.cboSexo.Name = "cboSexo"
        Me.cboSexo.Size = New System.Drawing.Size(117, 21)
        Me.cboSexo.TabIndex = 151
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(263, 43)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 13)
        Me.Label18.TabIndex = 156
        Me.Label18.Text = "Sexo"
        '
        'cboCondicion
        '
        Me.cboCondicion.FormattingEnabled = True
        Me.cboCondicion.Items.AddRange(New Object() {"VIVO", "FALLECIDO"})
        Me.cboCondicion.Location = New System.Drawing.Point(125, 43)
        Me.cboCondicion.Name = "cboCondicion"
        Me.cboCondicion.Size = New System.Drawing.Size(121, 21)
        Me.cboCondicion.TabIndex = 150
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(10, 43)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 13)
        Me.Label19.TabIndex = 155
        Me.Label19.Text = "Condicion"
        '
        'dtpFechaNac
        '
        Me.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNac.Location = New System.Drawing.Point(125, 15)
        Me.dtpFechaNac.Name = "dtpFechaNac"
        Me.dtpFechaNac.Size = New System.Drawing.Size(90, 20)
        Me.dtpFechaNac.TabIndex = 148
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(10, 15)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(109, 13)
        Me.Label26.TabIndex = 154
        Me.Label26.Text = "Fecha Nacimiento"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.gbCIEN)
        Me.TabPage4.Controls.Add(Me.cboNecropsia)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.Controls.Add(Me.dtpFechaM)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.lvTabla)
        Me.TabPage4.Controls.Add(Me.cboCausa)
        Me.TabPage4.Controls.Add(Me.txtDescripcionM)
        Me.TabPage4.Controls.Add(Me.txtCieM)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(704, 279)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Mortalidad"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'gbCIEN
        '
        Me.gbCIEN.BackColor = System.Drawing.Color.Silver
        Me.gbCIEN.Controls.Add(Me.btnRetornarCIEN)
        Me.gbCIEN.Controls.Add(Me.Label44)
        Me.gbCIEN.Controls.Add(Me.Button2)
        Me.gbCIEN.Controls.Add(Me.lvCIEN)
        Me.gbCIEN.Controls.Add(Me.txtFiltroCieN)
        Me.gbCIEN.Controls.Add(Me.Label45)
        Me.gbCIEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCIEN.Location = New System.Drawing.Point(7, 17)
        Me.gbCIEN.Name = "gbCIEN"
        Me.gbCIEN.Size = New System.Drawing.Size(692, 244)
        Me.gbCIEN.TabIndex = 155
        Me.gbCIEN.TabStop = False
        Me.gbCIEN.Text = "Consulta General"
        '
        'btnRetornarCIEN
        '
        Me.btnRetornarCIEN.Location = New System.Drawing.Point(558, 206)
        Me.btnRetornarCIEN.Name = "btnRetornarCIEN"
        Me.btnRetornarCIEN.Size = New System.Drawing.Size(78, 29)
        Me.btnRetornarCIEN.TabIndex = 5
        Me.btnRetornarCIEN.Text = "&Retornar"
        Me.btnRetornarCIEN.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.ForeColor = System.Drawing.Color.Red
        Me.Label44.Location = New System.Drawing.Point(6, 206)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(431, 13)
        Me.Label44.TabIndex = 4
        Me.Label44.Text = "Seleccione un Diagnóstico y Presione Enter para Insertar un Codigo CIE10"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(742, 235)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 29)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "&Retornar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lvCIEN
        '
        Me.lvCIEN.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader21, Me.ColumnHeader35})
        Me.lvCIEN.FullRowSelect = True
        Me.lvCIEN.GridLines = True
        Me.lvCIEN.Location = New System.Drawing.Point(9, 52)
        Me.lvCIEN.Name = "lvCIEN"
        Me.lvCIEN.Size = New System.Drawing.Size(677, 151)
        Me.lvCIEN.TabIndex = 2
        Me.lvCIEN.UseCompatibleStateImageBehavior = False
        Me.lvCIEN.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "CIE10"
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Text = "Descripción"
        Me.ColumnHeader35.Width = 700
        '
        'txtFiltroCieN
        '
        Me.txtFiltroCieN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltroCieN.Location = New System.Drawing.Point(135, 22)
        Me.txtFiltroCieN.Name = "txtFiltroCieN"
        Me.txtFiltroCieN.Size = New System.Drawing.Size(342, 20)
        Me.txtFiltroCieN.TabIndex = 1
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(6, 22)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(124, 13)
        Me.Label45.TabIndex = 0
        Me.Label45.Text = "Ingresar Descripción"
        '
        'cboNecropsia
        '
        Me.cboNecropsia.FormattingEnabled = True
        Me.cboNecropsia.Items.AddRange(New Object() {"SI", "NO"})
        Me.cboNecropsia.Location = New System.Drawing.Point(580, 13)
        Me.cboNecropsia.Name = "cboNecropsia"
        Me.cboNecropsia.Size = New System.Drawing.Size(85, 21)
        Me.cboNecropsia.TabIndex = 154
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(492, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 153
        Me.Label11.Text = "Necropsia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(341, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Descrcipción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(252, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "CIE"
        '
        'dtpFechaM
        '
        Me.dtpFechaM.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaM.Location = New System.Drawing.Point(12, 50)
        Me.dtpFechaM.Name = "dtpFechaM"
        Me.dtpFechaM.Size = New System.Drawing.Size(102, 20)
        Me.dtpFechaM.TabIndex = 144
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "Fecha"
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader10, Me.ColumnHeader1, Me.ColumnHeader11, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader2})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(7, 84)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(694, 177)
        Me.lvTabla.TabIndex = 148
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Servicio"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "SubServicio"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Especialidad"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Responsable"
        Me.ColumnHeader10.Width = 120
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Fecha"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Causa"
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "CIE"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Descripcion"
        Me.ColumnHeader14.Width = 400
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "IdEspecialidad"
        Me.ColumnHeader15.Width = 0
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "IdResponsable"
        Me.ColumnHeader16.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Necropsia"
        '
        'cboCausa
        '
        Me.cboCausa.FormattingEnabled = True
        Me.cboCausa.Items.AddRange(New Object() {"FINAL", "INTERMEDIA", "BASICA"})
        Me.cboCausa.Location = New System.Drawing.Point(120, 50)
        Me.cboCausa.Name = "cboCausa"
        Me.cboCausa.Size = New System.Drawing.Size(121, 21)
        Me.cboCausa.TabIndex = 145
        '
        'txtDescripcionM
        '
        Me.txtDescripcionM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionM.Location = New System.Drawing.Point(344, 49)
        Me.txtDescripcionM.Name = "txtDescripcionM"
        Me.txtDescripcionM.Size = New System.Drawing.Size(357, 20)
        Me.txtDescripcionM.TabIndex = 147
        '
        'txtCieM
        '
        Me.txtCieM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCieM.Location = New System.Drawing.Point(247, 51)
        Me.txtCieM.Name = "txtCieM"
        Me.txtCieM.Size = New System.Drawing.Size(91, 20)
        Me.txtCieM.TabIndex = 146
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(119, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 149
        Me.Label10.Text = "Causa"
        '
        'cboServicio
        '
        Me.cboServicio.FormattingEnabled = True
        Me.cboServicio.Location = New System.Drawing.Point(118, 60)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(213, 21)
        Me.cboServicio.TabIndex = 171
        '
        'cboSubServicio
        '
        Me.cboSubServicio.FormattingEnabled = True
        Me.cboSubServicio.Location = New System.Drawing.Point(454, 62)
        Me.cboSubServicio.Name = "cboSubServicio"
        Me.cboSubServicio.Size = New System.Drawing.Size(274, 21)
        Me.cboSubServicio.TabIndex = 172
        '
        'cboEspecialidad
        '
        Me.cboEspecialidad.FormattingEnabled = True
        Me.cboEspecialidad.Location = New System.Drawing.Point(118, 86)
        Me.cboEspecialidad.Name = "cboEspecialidad"
        Me.cboEspecialidad.Size = New System.Drawing.Size(213, 21)
        Me.cboEspecialidad.TabIndex = 173
        '
        'cboCama
        '
        Me.cboCama.FormattingEnabled = True
        Me.cboCama.Location = New System.Drawing.Point(454, 87)
        Me.cboCama.Name = "cboCama"
        Me.cboCama.Size = New System.Drawing.Size(210, 21)
        Me.cboCama.TabIndex = 174
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(345, 163)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(93, 13)
        Me.Label46.TabIndex = 175
        Me.Label46.Text = "Fecha Epicrisis"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Location = New System.Drawing.Point(454, 163)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(234, 20)
        Me.dtpFecha.TabIndex = 176
        '
        'btnBPac
        '
        Me.btnBPac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBPac.Location = New System.Drawing.Point(215, 6)
        Me.btnBPac.Name = "btnBPac"
        Me.btnBPac.Size = New System.Drawing.Size(42, 23)
        Me.btnBPac.TabIndex = 177
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
        Me.gbBPac.Location = New System.Drawing.Point(10, 9)
        Me.gbBPac.Name = "gbBPac"
        Me.gbBPac.Size = New System.Drawing.Size(702, 279)
        Me.gbBPac.TabIndex = 339
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
        'frmEpicrisis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 533)
        Me.Controls.Add(Me.gbBPac)
        Me.Controls.Add(Me.btnBPac)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.cboCama)
        Me.Controls.Add(Me.cboEspecialidad)
        Me.Controls.Add(Me.cboSubServicio)
        Me.Controls.Add(Me.cboServicio)
        Me.Controls.Add(Me.tcGrupo)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
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
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEpicrisis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Epicrisis"
        Me.tcGrupo.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.gbCPT.ResumeLayout(False)
        Me.gbCPT.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.gbCIEN.ResumeLayout(False)
        Me.gbCIEN.PerformLayout()
        Me.gbBPac.ResumeLayout(False)
        Me.gbBPac.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents tcGrupo As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaM As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboCausa As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescripcionM As System.Windows.Forms.TextBox
    Friend WithEvents txtCieM As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboNecropsia As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboOrden As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtSemanas As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtTalla As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboSexo As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaNac As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lvRN As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCPT As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDesCPT As System.Windows.Forms.TextBox
    Friend WithEvents txtCPT As System.Windows.Forms.TextBox
    Friend WithEvents lvCIE As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDes As System.Windows.Forms.TextBox
    Friend WithEvents txtCie As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtEvolucion As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtExamenesAuxiliares As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtExamenClinico As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtAnamnesis As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtDiasTratamiento As System.Windows.Forms.TextBox
    Friend WithEvents txtFrecuencia As System.Windows.Forms.TextBox
    Friend WithEvents txtVia As System.Windows.Forms.TextBox
    Friend WithEvents txtDosis As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtNombreGenerico As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lvTratamiento As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader31 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader32 As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbCPT As System.Windows.Forms.GroupBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents btnRetornarCPT As System.Windows.Forms.Button
    Friend WithEvents lvFiltroCPT As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader33 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader34 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFiltroCPT As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents btnRetornarCie As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents gbCIEN As System.Windows.Forms.GroupBox
    Friend WithEvents btnRetornarCIEN As System.Windows.Forms.Button
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lvCIEN As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader35 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFiltroCieN As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cboServicio As System.Windows.Forms.ComboBox
    Friend WithEvents cboSubServicio As System.Windows.Forms.ComboBox
    Friend WithEvents cboEspecialidad As System.Windows.Forms.ComboBox
    Friend WithEvents cboCama As System.Windows.Forms.ComboBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
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
