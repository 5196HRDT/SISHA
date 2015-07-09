<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlta))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.gbCIE = New System.Windows.Forms.GroupBox()
        Me.lvCIE = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gbP = New System.Windows.Forms.GroupBox()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Pagina = New System.Windows.Forms.PageSetupDialog()
        Me.pdDocumento = New System.Drawing.Printing.PrintDocument()
        Me.ppDialogo = New System.Windows.Forms.PrintPreviewDialog()
        Me.Fuente = New System.Windows.Forms.FontDialog()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txtPaciente = New System.Windows.Forms.TextBox()
        Me.lvPaciente = New System.Windows.Forms.ListView()
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRetornarP = New System.Windows.Forms.Button()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.gbPaciente = New System.Windows.Forms.GroupBox()
        Me.tbAlta = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblTEdadD = New System.Windows.Forms.Label()
        Me.btnBuscarP = New System.Windows.Forms.Button()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.lblEdadD = New System.Windows.Forms.Label()
        Me.lblTEdadM = New System.Windows.Forms.Label()
        Me.lblEdadM = New System.Windows.Forms.Label()
        Me.lblTEdad = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.lblDesOrigen = New System.Windows.Forms.Label()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtDesDestino = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboTD6 = New System.Windows.Forms.ComboBox()
        Me.txtLab6 = New System.Windows.Forms.TextBox()
        Me.txtDes6 = New System.Windows.Forms.TextBox()
        Me.txtCie6 = New System.Windows.Forms.TextBox()
        Me.cboTD5 = New System.Windows.Forms.ComboBox()
        Me.txtLab5 = New System.Windows.Forms.TextBox()
        Me.txtDes5 = New System.Windows.Forms.TextBox()
        Me.txtCie5 = New System.Windows.Forms.TextBox()
        Me.cboTD4 = New System.Windows.Forms.ComboBox()
        Me.txtLab4 = New System.Windows.Forms.TextBox()
        Me.txtDes4 = New System.Windows.Forms.TextBox()
        Me.txtCie4 = New System.Windows.Forms.TextBox()
        Me.cboTD3 = New System.Windows.Forms.ComboBox()
        Me.txtLab3 = New System.Windows.Forms.TextBox()
        Me.txtDes3 = New System.Windows.Forms.TextBox()
        Me.txtCie3 = New System.Windows.Forms.TextBox()
        Me.cboTD2 = New System.Windows.Forms.ComboBox()
        Me.txtLab2 = New System.Windows.Forms.TextBox()
        Me.txtDes2 = New System.Windows.Forms.TextBox()
        Me.txtCie2 = New System.Windows.Forms.TextBox()
        Me.cboTD1 = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtLab1 = New System.Windows.Forms.TextBox()
        Me.txtDes1 = New System.Windows.Forms.TextBox()
        Me.txtCie1 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboCondicion = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboMedico = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboTipoAlta = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.lblEstadoCivil = New System.Windows.Forms.Label()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.lblDistrito = New System.Windows.Forms.Label()
        Me.lblDpto = New System.Windows.Forms.Label()
        Me.lblTipoAtencion = New System.Windows.Forms.Label()
        Me.lblInformante = New System.Windows.Forms.Label()
        Me.lblIngSer = New System.Windows.Forms.Label()
        Me.lblIngEsta = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblMedico = New System.Windows.Forms.Label()
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
        Me.lblHora = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtExamenFisico = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtEnfermedadAct = New System.Windows.Forms.TextBox()
        Me.txtMolestia = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTD6 = New System.Windows.Forms.Label()
        Me.lblLab6 = New System.Windows.Forms.Label()
        Me.lblDes6 = New System.Windows.Forms.Label()
        Me.lblCie6 = New System.Windows.Forms.Label()
        Me.lblTD5 = New System.Windows.Forms.Label()
        Me.lblLab5 = New System.Windows.Forms.Label()
        Me.lblDes5 = New System.Windows.Forms.Label()
        Me.lblCie5 = New System.Windows.Forms.Label()
        Me.lblTD4 = New System.Windows.Forms.Label()
        Me.lblLab4 = New System.Windows.Forms.Label()
        Me.lblDes4 = New System.Windows.Forms.Label()
        Me.lblCie4 = New System.Windows.Forms.Label()
        Me.lblTD3 = New System.Windows.Forms.Label()
        Me.lblLab3 = New System.Windows.Forms.Label()
        Me.lblDes3 = New System.Windows.Forms.Label()
        Me.lblCie3 = New System.Windows.Forms.Label()
        Me.lblTD2 = New System.Windows.Forms.Label()
        Me.lblLab2 = New System.Windows.Forms.Label()
        Me.lblDes2 = New System.Windows.Forms.Label()
        Me.lblCie2 = New System.Windows.Forms.Label()
        Me.lblTD1 = New System.Windows.Forms.Label()
        Me.lblLab1 = New System.Windows.Forms.Label()
        Me.lblDes1 = New System.Windows.Forms.Label()
        Me.lblCie1 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.gbCIE.SuspendLayout()
        Me.gbP.SuspendLayout()
        Me.gbPaciente.SuspendLayout()
        Me.tbAlta.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(470, 579)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(93, 33)
        Me.btnCerrar.TabIndex = 36
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(352, 579)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(93, 33)
        Me.btnCancelar.TabIndex = 35
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(235, 579)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(93, 33)
        Me.btnGrabar.TabIndex = 34
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(107, 579)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(93, 33)
        Me.btnNuevo.TabIndex = 33
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'gbCIE
        '
        Me.gbCIE.Controls.Add(Me.lvCIE)
        Me.gbCIE.Controls.Add(Me.btnRetornar)
        Me.gbCIE.Controls.Add(Me.txtFiltro)
        Me.gbCIE.Controls.Add(Me.Label21)
        Me.gbCIE.Location = New System.Drawing.Point(971, 545)
        Me.gbCIE.Name = "gbCIE"
        Me.gbCIE.Size = New System.Drawing.Size(708, 235)
        Me.gbCIE.TabIndex = 278
        Me.gbCIE.TabStop = False
        '
        'lvCIE
        '
        Me.lvCIE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvCIE.FullRowSelect = True
        Me.lvCIE.GridLines = True
        Me.lvCIE.Location = New System.Drawing.Point(13, 39)
        Me.lvCIE.Name = "lvCIE"
        Me.lvCIE.Size = New System.Drawing.Size(684, 174)
        Me.lvCIE.TabIndex = 37
        Me.lvCIE.UseCompatibleStateImageBehavior = False
        Me.lvCIE.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Codigo"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripcion"
        Me.ColumnHeader2.Width = 500
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Definitivo"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Sexo"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "MinEdad"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "MinTipo"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "MaxEdad"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "MaxTipo"
        '
        'btnRetornar
        '
        Me.btnRetornar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornar.Location = New System.Drawing.Point(660, 11)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Size = New System.Drawing.Size(37, 23)
        Me.btnRetornar.TabIndex = 36
        Me.btnRetornar.Text = "&X"
        Me.btnRetornar.UseVisualStyleBackColor = True
        '
        'txtFiltro
        '
        Me.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltro.Location = New System.Drawing.Point(93, 13)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(495, 20)
        Me.txtFiltro.TabIndex = 35
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 13)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "Descripción"
        '
        'gbP
        '
        Me.gbP.Controls.Add(Me.lvTabla)
        Me.gbP.Location = New System.Drawing.Point(739, 135)
        Me.gbP.Name = "gbP"
        Me.gbP.Size = New System.Drawing.Size(603, 214)
        Me.gbP.TabIndex = 283
        Me.gbP.TabStop = False
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(7, 19)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(583, 164)
        Me.lvTabla.TabIndex = 173
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Codigo"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Cant"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Descripcion"
        Me.ColumnHeader11.Width = 300
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Precio"
        Me.ColumnHeader12.Width = 80
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Importe"
        Me.ColumnHeader13.Width = 80
        '
        'pdDocumento
        '
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
        'txtPaciente
        '
        Me.txtPaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaciente.Location = New System.Drawing.Point(92, 19)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(543, 20)
        Me.txtPaciente.TabIndex = 97
        '
        'lvPaciente
        '
        Me.lvPaciente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader32})
        Me.lvPaciente.FullRowSelect = True
        Me.lvPaciente.GridLines = True
        Me.lvPaciente.Location = New System.Drawing.Point(12, 48)
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
        'gbPaciente
        '
        Me.gbPaciente.Controls.Add(Me.Label53)
        Me.gbPaciente.Controls.Add(Me.btnRetornarP)
        Me.gbPaciente.Controls.Add(Me.lvPaciente)
        Me.gbPaciente.Controls.Add(Me.txtPaciente)
        Me.gbPaciente.Controls.Add(Me.Label54)
        Me.gbPaciente.Location = New System.Drawing.Point(12, 607)
        Me.gbPaciente.Name = "gbPaciente"
        Me.gbPaciente.Size = New System.Drawing.Size(702, 279)
        Me.gbPaciente.TabIndex = 292
        Me.gbPaciente.TabStop = False
        '
        'tbAlta
        '
        Me.tbAlta.Controls.Add(Me.TabPage1)
        Me.tbAlta.Controls.Add(Me.TabPage2)
        Me.tbAlta.Location = New System.Drawing.Point(11, 12)
        Me.tbAlta.Name = "tbAlta"
        Me.tbAlta.SelectedIndex = 0
        Me.tbAlta.Size = New System.Drawing.Size(729, 557)
        Me.tbAlta.TabIndex = 293
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblTEdadD)
        Me.TabPage1.Controls.Add(Me.btnBuscarP)
        Me.TabPage1.Controls.Add(Me.lblSexo)
        Me.TabPage1.Controls.Add(Me.lblEdadD)
        Me.TabPage1.Controls.Add(Me.lblTEdadM)
        Me.TabPage1.Controls.Add(Me.lblEdadM)
        Me.TabPage1.Controls.Add(Me.lblTEdad)
        Me.TabPage1.Controls.Add(Me.lblEdad)
        Me.TabPage1.Controls.Add(Me.lblDesOrigen)
        Me.TabPage1.Controls.Add(Me.lblOrigen)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.Label30)
        Me.TabPage1.Controls.Add(Me.txtDesDestino)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.cboDestino)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.cboTD6)
        Me.TabPage1.Controls.Add(Me.txtLab6)
        Me.TabPage1.Controls.Add(Me.txtDes6)
        Me.TabPage1.Controls.Add(Me.txtCie6)
        Me.TabPage1.Controls.Add(Me.cboTD5)
        Me.TabPage1.Controls.Add(Me.txtLab5)
        Me.TabPage1.Controls.Add(Me.txtDes5)
        Me.TabPage1.Controls.Add(Me.txtCie5)
        Me.TabPage1.Controls.Add(Me.cboTD4)
        Me.TabPage1.Controls.Add(Me.txtLab4)
        Me.TabPage1.Controls.Add(Me.txtDes4)
        Me.TabPage1.Controls.Add(Me.txtCie4)
        Me.TabPage1.Controls.Add(Me.cboTD3)
        Me.TabPage1.Controls.Add(Me.txtLab3)
        Me.TabPage1.Controls.Add(Me.txtDes3)
        Me.TabPage1.Controls.Add(Me.txtCie3)
        Me.TabPage1.Controls.Add(Me.cboTD2)
        Me.TabPage1.Controls.Add(Me.txtLab2)
        Me.TabPage1.Controls.Add(Me.txtDes2)
        Me.TabPage1.Controls.Add(Me.txtCie2)
        Me.TabPage1.Controls.Add(Me.cboTD1)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.txtLab1)
        Me.TabPage1.Controls.Add(Me.txtDes1)
        Me.TabPage1.Controls.Add(Me.txtCie1)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.cboCondicion)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.cboMedico)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.cboTipoAlta)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.lblDomicilio)
        Me.TabPage1.Controls.Add(Me.lblPaciente)
        Me.TabPage1.Controls.Add(Me.lblEstadoCivil)
        Me.TabPage1.Controls.Add(Me.lblGrado)
        Me.TabPage1.Controls.Add(Me.lblProvincia)
        Me.TabPage1.Controls.Add(Me.lblDistrito)
        Me.TabPage1.Controls.Add(Me.lblDpto)
        Me.TabPage1.Controls.Add(Me.lblTipoAtencion)
        Me.TabPage1.Controls.Add(Me.lblInformante)
        Me.TabPage1.Controls.Add(Me.lblIngSer)
        Me.TabPage1.Controls.Add(Me.lblIngEsta)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label36)
        Me.TabPage1.Controls.Add(Me.Label35)
        Me.TabPage1.Controls.Add(Me.Label34)
        Me.TabPage1.Controls.Add(Me.lblServicio)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.lblMedico)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.dtpFechaNcto)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtHora)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.dtpFecha)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.lblHora)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.lblFecha)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtHistoria)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(721, 531)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Alta I"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblTEdadD
        '
        Me.lblTEdadD.BackColor = System.Drawing.Color.White
        Me.lblTEdadD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdadD.Location = New System.Drawing.Point(685, 56)
        Me.lblTEdadD.Name = "lblTEdadD"
        Me.lblTEdadD.Size = New System.Drawing.Size(17, 23)
        Me.lblTEdadD.TabIndex = 550
        Me.lblTEdadD.Text = "D"
        Me.lblTEdadD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBuscarP
        '
        Me.btnBuscarP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarP.Location = New System.Drawing.Point(492, 35)
        Me.btnBuscarP.Name = "btnBuscarP"
        Me.btnBuscarP.Size = New System.Drawing.Size(31, 23)
        Me.btnBuscarP.TabIndex = 549
        Me.btnBuscarP.Text = "&B"
        Me.btnBuscarP.UseVisualStyleBackColor = True
        '
        'lblSexo
        '
        Me.lblSexo.BackColor = System.Drawing.Color.White
        Me.lblSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSexo.Location = New System.Drawing.Point(492, 61)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(31, 23)
        Me.lblSexo.TabIndex = 548
        '
        'lblEdadD
        '
        Me.lblEdadD.BackColor = System.Drawing.Color.White
        Me.lblEdadD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdadD.Location = New System.Drawing.Point(655, 56)
        Me.lblEdadD.Name = "lblEdadD"
        Me.lblEdadD.Size = New System.Drawing.Size(30, 23)
        Me.lblEdadD.TabIndex = 547
        Me.lblEdadD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTEdadM
        '
        Me.lblTEdadM.BackColor = System.Drawing.Color.White
        Me.lblTEdadM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdadM.Location = New System.Drawing.Point(637, 56)
        Me.lblTEdadM.Name = "lblTEdadM"
        Me.lblTEdadM.Size = New System.Drawing.Size(19, 23)
        Me.lblTEdadM.TabIndex = 546
        Me.lblTEdadM.Text = "M"
        Me.lblTEdadM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdadM
        '
        Me.lblEdadM.BackColor = System.Drawing.Color.White
        Me.lblEdadM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdadM.Location = New System.Drawing.Point(608, 56)
        Me.lblEdadM.Name = "lblEdadM"
        Me.lblEdadM.Size = New System.Drawing.Size(30, 23)
        Me.lblEdadM.TabIndex = 545
        Me.lblEdadM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTEdad
        '
        Me.lblTEdad.BackColor = System.Drawing.Color.White
        Me.lblTEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdad.Location = New System.Drawing.Point(593, 56)
        Me.lblTEdad.Name = "lblTEdad"
        Me.lblTEdad.Size = New System.Drawing.Size(15, 23)
        Me.lblTEdad.TabIndex = 544
        Me.lblTEdad.Text = "A"
        Me.lblTEdad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.White
        Me.lblEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdad.Location = New System.Drawing.Point(562, 56)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(31, 23)
        Me.lblEdad.TabIndex = 543
        Me.lblEdad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDesOrigen
        '
        Me.lblDesOrigen.BackColor = System.Drawing.Color.White
        Me.lblDesOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDesOrigen.Location = New System.Drawing.Point(423, 227)
        Me.lblDesOrigen.Name = "lblDesOrigen"
        Me.lblDesOrigen.Size = New System.Drawing.Size(211, 23)
        Me.lblDesOrigen.TabIndex = 542
        '
        'lblOrigen
        '
        Me.lblOrigen.BackColor = System.Drawing.Color.White
        Me.lblOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrigen.Location = New System.Drawing.Point(104, 227)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(211, 23)
        Me.lblOrigen.TabIndex = 541
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(329, 227)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(74, 13)
        Me.Label29.TabIndex = 540
        Me.Label29.Text = "Des. Origen"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(10, 227)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(44, 13)
        Me.Label30.TabIndex = 539
        Me.Label30.Text = "Origen"
        '
        'txtDesDestino
        '
        Me.txtDesDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesDestino.Location = New System.Drawing.Point(102, 329)
        Me.txtDesDestino.Name = "txtDesDestino"
        Me.txtDesDestino.Size = New System.Drawing.Size(607, 20)
        Me.txtDesDestino.TabIndex = 472
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(9, 329)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 13)
        Me.Label20.TabIndex = 538
        Me.Label20.Text = "Desc. Destino"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(180, 259)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(312, 13)
        Me.Label19.TabIndex = 537
        Me.Label19.Text = "INFORMACION GENERAL DEL ALTA DE PACIENTES"
        '
        'cboDestino
        '
        Me.cboDestino.FormattingEnabled = True
        Me.cboDestino.Location = New System.Drawing.Point(421, 302)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(288, 21)
        Me.cboDestino.TabIndex = 471
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(328, 302)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 13)
        Me.Label18.TabIndex = 536
        Me.Label18.Text = "Destino"
        '
        'cboTD6
        '
        Me.cboTD6.FormattingEnabled = True
        Me.cboTD6.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD6.Location = New System.Drawing.Point(588, 503)
        Me.cboTD6.Name = "cboTD6"
        Me.cboTD6.Size = New System.Drawing.Size(121, 21)
        Me.cboTD6.TabIndex = 496
        '
        'txtLab6
        '
        Me.txtLab6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab6.Location = New System.Drawing.Point(519, 503)
        Me.txtLab6.Name = "txtLab6"
        Me.txtLab6.Size = New System.Drawing.Size(63, 20)
        Me.txtLab6.TabIndex = 495
        '
        'txtDes6
        '
        Me.txtDes6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes6.Location = New System.Drawing.Point(80, 504)
        Me.txtDes6.Name = "txtDes6"
        Me.txtDes6.Size = New System.Drawing.Size(433, 20)
        Me.txtDes6.TabIndex = 494
        '
        'txtCie6
        '
        Me.txtCie6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie6.Location = New System.Drawing.Point(11, 504)
        Me.txtCie6.Name = "txtCie6"
        Me.txtCie6.Size = New System.Drawing.Size(63, 20)
        Me.txtCie6.TabIndex = 493
        '
        'cboTD5
        '
        Me.cboTD5.FormattingEnabled = True
        Me.cboTD5.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD5.Location = New System.Drawing.Point(588, 477)
        Me.cboTD5.Name = "cboTD5"
        Me.cboTD5.Size = New System.Drawing.Size(121, 21)
        Me.cboTD5.TabIndex = 492
        '
        'txtLab5
        '
        Me.txtLab5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab5.Location = New System.Drawing.Point(519, 477)
        Me.txtLab5.Name = "txtLab5"
        Me.txtLab5.Size = New System.Drawing.Size(63, 20)
        Me.txtLab5.TabIndex = 491
        '
        'txtDes5
        '
        Me.txtDes5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes5.Location = New System.Drawing.Point(80, 478)
        Me.txtDes5.Name = "txtDes5"
        Me.txtDes5.Size = New System.Drawing.Size(433, 20)
        Me.txtDes5.TabIndex = 490
        '
        'txtCie5
        '
        Me.txtCie5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie5.Location = New System.Drawing.Point(11, 478)
        Me.txtCie5.Name = "txtCie5"
        Me.txtCie5.Size = New System.Drawing.Size(63, 20)
        Me.txtCie5.TabIndex = 489
        '
        'cboTD4
        '
        Me.cboTD4.FormattingEnabled = True
        Me.cboTD4.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD4.Location = New System.Drawing.Point(588, 451)
        Me.cboTD4.Name = "cboTD4"
        Me.cboTD4.Size = New System.Drawing.Size(121, 21)
        Me.cboTD4.TabIndex = 488
        '
        'txtLab4
        '
        Me.txtLab4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab4.Location = New System.Drawing.Point(519, 451)
        Me.txtLab4.Name = "txtLab4"
        Me.txtLab4.Size = New System.Drawing.Size(63, 20)
        Me.txtLab4.TabIndex = 487
        '
        'txtDes4
        '
        Me.txtDes4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes4.Location = New System.Drawing.Point(80, 452)
        Me.txtDes4.Name = "txtDes4"
        Me.txtDes4.Size = New System.Drawing.Size(433, 20)
        Me.txtDes4.TabIndex = 486
        '
        'txtCie4
        '
        Me.txtCie4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie4.Location = New System.Drawing.Point(11, 452)
        Me.txtCie4.Name = "txtCie4"
        Me.txtCie4.Size = New System.Drawing.Size(63, 20)
        Me.txtCie4.TabIndex = 485
        '
        'cboTD3
        '
        Me.cboTD3.FormattingEnabled = True
        Me.cboTD3.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD3.Location = New System.Drawing.Point(588, 424)
        Me.cboTD3.Name = "cboTD3"
        Me.cboTD3.Size = New System.Drawing.Size(121, 21)
        Me.cboTD3.TabIndex = 484
        '
        'txtLab3
        '
        Me.txtLab3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab3.Location = New System.Drawing.Point(519, 424)
        Me.txtLab3.Name = "txtLab3"
        Me.txtLab3.Size = New System.Drawing.Size(63, 20)
        Me.txtLab3.TabIndex = 483
        '
        'txtDes3
        '
        Me.txtDes3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes3.Location = New System.Drawing.Point(80, 425)
        Me.txtDes3.Name = "txtDes3"
        Me.txtDes3.Size = New System.Drawing.Size(433, 20)
        Me.txtDes3.TabIndex = 482
        '
        'txtCie3
        '
        Me.txtCie3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie3.Location = New System.Drawing.Point(11, 425)
        Me.txtCie3.Name = "txtCie3"
        Me.txtCie3.Size = New System.Drawing.Size(63, 20)
        Me.txtCie3.TabIndex = 481
        '
        'cboTD2
        '
        Me.cboTD2.FormattingEnabled = True
        Me.cboTD2.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD2.Location = New System.Drawing.Point(588, 398)
        Me.cboTD2.Name = "cboTD2"
        Me.cboTD2.Size = New System.Drawing.Size(121, 21)
        Me.cboTD2.TabIndex = 480
        '
        'txtLab2
        '
        Me.txtLab2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab2.Location = New System.Drawing.Point(519, 398)
        Me.txtLab2.Name = "txtLab2"
        Me.txtLab2.Size = New System.Drawing.Size(63, 20)
        Me.txtLab2.TabIndex = 479
        '
        'txtDes2
        '
        Me.txtDes2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes2.Location = New System.Drawing.Point(80, 399)
        Me.txtDes2.Name = "txtDes2"
        Me.txtDes2.Size = New System.Drawing.Size(433, 20)
        Me.txtDes2.TabIndex = 478
        '
        'txtCie2
        '
        Me.txtCie2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie2.Location = New System.Drawing.Point(11, 399)
        Me.txtCie2.Name = "txtCie2"
        Me.txtCie2.Size = New System.Drawing.Size(63, 20)
        Me.txtCie2.TabIndex = 477
        '
        'cboTD1
        '
        Me.cboTD1.FormattingEnabled = True
        Me.cboTD1.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD1.Location = New System.Drawing.Point(588, 372)
        Me.cboTD1.Name = "cboTD1"
        Me.cboTD1.Size = New System.Drawing.Size(121, 21)
        Me.cboTD1.TabIndex = 476
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(531, 356)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(28, 13)
        Me.Label16.TabIndex = 535
        Me.Label16.Text = "Lab"
        '
        'txtLab1
        '
        Me.txtLab1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab1.Location = New System.Drawing.Point(519, 372)
        Me.txtLab1.Name = "txtLab1"
        Me.txtLab1.Size = New System.Drawing.Size(63, 20)
        Me.txtLab1.TabIndex = 475
        '
        'txtDes1
        '
        Me.txtDes1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes1.Location = New System.Drawing.Point(80, 373)
        Me.txtDes1.Name = "txtDes1"
        Me.txtDes1.Size = New System.Drawing.Size(433, 20)
        Me.txtDes1.TabIndex = 474
        '
        'txtCie1
        '
        Me.txtCie1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie1.Location = New System.Drawing.Point(11, 373)
        Me.txtCie1.Name = "txtCie1"
        Me.txtCie1.Size = New System.Drawing.Size(63, 20)
        Me.txtCie1.TabIndex = 473
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 357)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 13)
        Me.Label17.TabIndex = 534
        Me.Label17.Text = "Diagnosticos de Alta"
        '
        'cboCondicion
        '
        Me.cboCondicion.FormattingEnabled = True
        Me.cboCondicion.Location = New System.Drawing.Point(102, 275)
        Me.cboCondicion.Name = "cboCondicion"
        Me.cboCondicion.Size = New System.Drawing.Size(211, 21)
        Me.cboCondicion.TabIndex = 468
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(9, 275)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 533
        Me.Label15.Text = "Condición Alta"
        '
        'cboMedico
        '
        Me.cboMedico.FormattingEnabled = True
        Me.cboMedico.Location = New System.Drawing.Point(421, 275)
        Me.cboMedico.Name = "cboMedico"
        Me.cboMedico.Size = New System.Drawing.Size(288, 21)
        Me.cboMedico.TabIndex = 469
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(327, 281)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 13)
        Me.Label14.TabIndex = 532
        Me.Label14.Text = "Médico Alta"
        '
        'cboTipoAlta
        '
        Me.cboTipoAlta.FormattingEnabled = True
        Me.cboTipoAlta.Location = New System.Drawing.Point(102, 302)
        Me.cboTipoAlta.Name = "cboTipoAlta"
        Me.cboTipoAlta.Size = New System.Drawing.Size(211, 21)
        Me.cboTipoAlta.TabIndex = 470
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 302)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 531
        Me.Label7.Text = "Tipo Alta"
        '
        'lblDomicilio
        '
        Me.lblDomicilio.BackColor = System.Drawing.Color.White
        Me.lblDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDomicilio.Location = New System.Drawing.Point(104, 86)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(419, 23)
        Me.lblDomicilio.TabIndex = 530
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Location = New System.Drawing.Point(183, 34)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(309, 23)
        Me.lblPaciente.TabIndex = 529
        '
        'lblEstadoCivil
        '
        Me.lblEstadoCivil.BackColor = System.Drawing.Color.White
        Me.lblEstadoCivil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstadoCivil.Location = New System.Drawing.Point(423, 61)
        Me.lblEstadoCivil.Name = "lblEstadoCivil"
        Me.lblEstadoCivil.Size = New System.Drawing.Size(69, 23)
        Me.lblEstadoCivil.TabIndex = 528
        '
        'lblGrado
        '
        Me.lblGrado.BackColor = System.Drawing.Color.White
        Me.lblGrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGrado.Location = New System.Drawing.Point(104, 60)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(211, 23)
        Me.lblGrado.TabIndex = 527
        '
        'lblProvincia
        '
        Me.lblProvincia.BackColor = System.Drawing.Color.White
        Me.lblProvincia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProvincia.Location = New System.Drawing.Point(423, 111)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(288, 23)
        Me.lblProvincia.TabIndex = 526
        '
        'lblDistrito
        '
        Me.lblDistrito.BackColor = System.Drawing.Color.White
        Me.lblDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDistrito.Location = New System.Drawing.Point(104, 139)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(211, 23)
        Me.lblDistrito.TabIndex = 525
        '
        'lblDpto
        '
        Me.lblDpto.BackColor = System.Drawing.Color.White
        Me.lblDpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDpto.Location = New System.Drawing.Point(104, 110)
        Me.lblDpto.Name = "lblDpto"
        Me.lblDpto.Size = New System.Drawing.Size(211, 23)
        Me.lblDpto.TabIndex = 524
        '
        'lblTipoAtencion
        '
        Me.lblTipoAtencion.BackColor = System.Drawing.Color.White
        Me.lblTipoAtencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipoAtencion.Location = New System.Drawing.Point(610, 87)
        Me.lblTipoAtencion.Name = "lblTipoAtencion"
        Me.lblTipoAtencion.Size = New System.Drawing.Size(101, 23)
        Me.lblTipoAtencion.TabIndex = 523
        '
        'lblInformante
        '
        Me.lblInformante.BackColor = System.Drawing.Color.White
        Me.lblInformante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInformante.Location = New System.Drawing.Point(423, 139)
        Me.lblInformante.Name = "lblInformante"
        Me.lblInformante.Size = New System.Drawing.Size(288, 23)
        Me.lblInformante.TabIndex = 522
        '
        'lblIngSer
        '
        Me.lblIngSer.BackColor = System.Drawing.Color.White
        Me.lblIngSer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIngSer.Location = New System.Drawing.Point(423, 201)
        Me.lblIngSer.Name = "lblIngSer"
        Me.lblIngSer.Size = New System.Drawing.Size(211, 23)
        Me.lblIngSer.TabIndex = 521
        '
        'lblIngEsta
        '
        Me.lblIngEsta.BackColor = System.Drawing.Color.White
        Me.lblIngEsta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIngEsta.Location = New System.Drawing.Point(104, 201)
        Me.lblIngEsta.Name = "lblIngEsta"
        Me.lblIngEsta.Size = New System.Drawing.Size(211, 23)
        Me.lblIngEsta.TabIndex = 520
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(525, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 519
        Me.Label8.Text = "Edad"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(525, 90)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(86, 13)
        Me.Label36.TabIndex = 518
        Me.Label36.Text = "Tipo Atención"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(329, 201)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(79, 13)
        Me.Label35.TabIndex = 517
        Me.Label35.Text = "Ing. Servicio"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(10, 201)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(78, 13)
        Me.Label34.TabIndex = 516
        Me.Label34.Text = "Tipo Ingreso"
        '
        'lblServicio
        '
        Me.lblServicio.BackColor = System.Drawing.Color.White
        Me.lblServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblServicio.Location = New System.Drawing.Point(104, 172)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(211, 23)
        Me.lblServicio.TabIndex = 515
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(10, 172)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 13)
        Me.Label28.TabIndex = 514
        Me.Label28.Text = "Servicio"
        '
        'lblMedico
        '
        Me.lblMedico.BackColor = System.Drawing.Color.White
        Me.lblMedico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedico.Location = New System.Drawing.Point(423, 172)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(288, 23)
        Me.lblMedico.TabIndex = 513
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(329, 172)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(48, 13)
        Me.Label27.TabIndex = 512
        Me.Label27.Text = "Médico"
        '
        'dtpFechaNcto
        '
        Me.dtpFechaNcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNcto.Location = New System.Drawing.Point(610, 36)
        Me.dtpFechaNcto.Name = "dtpFechaNcto"
        Me.dtpFechaNcto.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaNcto.TabIndex = 467
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(524, 39)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 13)
        Me.Label26.TabIndex = 511
        Me.Label26.Text = "Fecha Ncto."
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(9, 137)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(47, 13)
        Me.Label25.TabIndex = 510
        Me.Label25.Text = "Distrito"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(329, 116)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 13)
        Me.Label24.TabIndex = 509
        Me.Label24.Text = "Provincia"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 508
        Me.Label12.Text = "Departamento"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(320, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 507
        Me.Label11.Text = "Estado Civil"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 506
        Me.Label10.Text = "Domicilio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 505
        Me.Label9.Text = "Grado Inst."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(329, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 504
        Me.Label6.Text = "Informante"
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(253, 10)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(62, 20)
        Me.txtHora.TabIndex = 465
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(213, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 503
        Me.Label5.Text = "Hora"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(104, 10)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(105, 20)
        Me.dtpFecha.TabIndex = 464
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 502
        Me.Label3.Text = "Fecha Alta"
        '
        'lblHora
        '
        Me.lblHora.BackColor = System.Drawing.Color.White
        Me.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHora.Location = New System.Drawing.Point(611, 9)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(100, 23)
        Me.lblHora.TabIndex = 501
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(529, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 500
        Me.Label4.Text = "Hora Ingreso"
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.White
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.Location = New System.Drawing.Point(423, 9)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(100, 23)
        Me.lblFecha.TabIndex = 499
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(321, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 498
        Me.Label2.Text = "Fecha Ingreso"
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(104, 36)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(73, 20)
        Me.txtHistoria.TabIndex = 466
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 497
        Me.Label1.Text = "Paciente"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtExamenFisico)
        Me.TabPage2.Controls.Add(Me.Label31)
        Me.TabPage2.Controls.Add(Me.txtEnfermedadAct)
        Me.TabPage2.Controls.Add(Me.txtMolestia)
        Me.TabPage2.Controls.Add(Me.Label42)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.lblTD6)
        Me.TabPage2.Controls.Add(Me.lblLab6)
        Me.TabPage2.Controls.Add(Me.lblDes6)
        Me.TabPage2.Controls.Add(Me.lblCie6)
        Me.TabPage2.Controls.Add(Me.lblTD5)
        Me.TabPage2.Controls.Add(Me.lblLab5)
        Me.TabPage2.Controls.Add(Me.lblDes5)
        Me.TabPage2.Controls.Add(Me.lblCie5)
        Me.TabPage2.Controls.Add(Me.lblTD4)
        Me.TabPage2.Controls.Add(Me.lblLab4)
        Me.TabPage2.Controls.Add(Me.lblDes4)
        Me.TabPage2.Controls.Add(Me.lblCie4)
        Me.TabPage2.Controls.Add(Me.lblTD3)
        Me.TabPage2.Controls.Add(Me.lblLab3)
        Me.TabPage2.Controls.Add(Me.lblDes3)
        Me.TabPage2.Controls.Add(Me.lblCie3)
        Me.TabPage2.Controls.Add(Me.lblTD2)
        Me.TabPage2.Controls.Add(Me.lblLab2)
        Me.TabPage2.Controls.Add(Me.lblDes2)
        Me.TabPage2.Controls.Add(Me.lblCie2)
        Me.TabPage2.Controls.Add(Me.lblTD1)
        Me.TabPage2.Controls.Add(Me.lblLab1)
        Me.TabPage2.Controls.Add(Me.lblDes1)
        Me.TabPage2.Controls.Add(Me.lblCie1)
        Me.TabPage2.Controls.Add(Me.Label33)
        Me.TabPage2.Controls.Add(Me.Label32)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(721, 531)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Alta II"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtExamenFisico
        '
        Me.txtExamenFisico.Location = New System.Drawing.Point(40, 420)
        Me.txtExamenFisico.Multiline = True
        Me.txtExamenFisico.Name = "txtExamenFisico"
        Me.txtExamenFisico.Size = New System.Drawing.Size(621, 72)
        Me.txtExamenFisico.TabIndex = 280
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(37, 401)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(90, 13)
        Me.Label31.TabIndex = 309
        Me.Label31.Text = "Examen Físico"
        '
        'txtEnfermedadAct
        '
        Me.txtEnfermedadAct.Location = New System.Drawing.Point(40, 309)
        Me.txtEnfermedadAct.Multiline = True
        Me.txtEnfermedadAct.Name = "txtEnfermedadAct"
        Me.txtEnfermedadAct.Size = New System.Drawing.Size(621, 88)
        Me.txtEnfermedadAct.TabIndex = 279
        '
        'txtMolestia
        '
        Me.txtMolestia.Location = New System.Drawing.Point(40, 218)
        Me.txtMolestia.Multiline = True
        Me.txtMolestia.Name = "txtMolestia"
        Me.txtMolestia.Size = New System.Drawing.Size(621, 72)
        Me.txtMolestia.TabIndex = 278
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(37, 293)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(114, 13)
        Me.Label42.TabIndex = 308
        Me.Label42.Text = "Enfermedad Actual"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(37, 202)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 307
        Me.Label13.Text = "Molestia Principal"
        '
        'lblTD6
        '
        Me.lblTD6.BackColor = System.Drawing.Color.White
        Me.lblTD6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTD6.Location = New System.Drawing.Point(566, 173)
        Me.lblTD6.Name = "lblTD6"
        Me.lblTD6.Size = New System.Drawing.Size(95, 23)
        Me.lblTD6.TabIndex = 306
        '
        'lblLab6
        '
        Me.lblLab6.BackColor = System.Drawing.Color.White
        Me.lblLab6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLab6.Location = New System.Drawing.Point(500, 173)
        Me.lblLab6.Name = "lblLab6"
        Me.lblLab6.Size = New System.Drawing.Size(60, 23)
        Me.lblLab6.TabIndex = 305
        '
        'lblDes6
        '
        Me.lblDes6.BackColor = System.Drawing.Color.White
        Me.lblDes6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDes6.Location = New System.Drawing.Point(106, 173)
        Me.lblDes6.Name = "lblDes6"
        Me.lblDes6.Size = New System.Drawing.Size(388, 23)
        Me.lblDes6.TabIndex = 304
        '
        'lblCie6
        '
        Me.lblCie6.BackColor = System.Drawing.Color.White
        Me.lblCie6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCie6.Location = New System.Drawing.Point(40, 173)
        Me.lblCie6.Name = "lblCie6"
        Me.lblCie6.Size = New System.Drawing.Size(60, 23)
        Me.lblCie6.TabIndex = 303
        '
        'lblTD5
        '
        Me.lblTD5.BackColor = System.Drawing.Color.White
        Me.lblTD5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTD5.Location = New System.Drawing.Point(566, 144)
        Me.lblTD5.Name = "lblTD5"
        Me.lblTD5.Size = New System.Drawing.Size(95, 23)
        Me.lblTD5.TabIndex = 302
        '
        'lblLab5
        '
        Me.lblLab5.BackColor = System.Drawing.Color.White
        Me.lblLab5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLab5.Location = New System.Drawing.Point(500, 144)
        Me.lblLab5.Name = "lblLab5"
        Me.lblLab5.Size = New System.Drawing.Size(60, 23)
        Me.lblLab5.TabIndex = 301
        '
        'lblDes5
        '
        Me.lblDes5.BackColor = System.Drawing.Color.White
        Me.lblDes5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDes5.Location = New System.Drawing.Point(106, 144)
        Me.lblDes5.Name = "lblDes5"
        Me.lblDes5.Size = New System.Drawing.Size(388, 23)
        Me.lblDes5.TabIndex = 300
        '
        'lblCie5
        '
        Me.lblCie5.BackColor = System.Drawing.Color.White
        Me.lblCie5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCie5.Location = New System.Drawing.Point(40, 144)
        Me.lblCie5.Name = "lblCie5"
        Me.lblCie5.Size = New System.Drawing.Size(60, 23)
        Me.lblCie5.TabIndex = 299
        '
        'lblTD4
        '
        Me.lblTD4.BackColor = System.Drawing.Color.White
        Me.lblTD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTD4.Location = New System.Drawing.Point(566, 117)
        Me.lblTD4.Name = "lblTD4"
        Me.lblTD4.Size = New System.Drawing.Size(95, 23)
        Me.lblTD4.TabIndex = 298
        '
        'lblLab4
        '
        Me.lblLab4.BackColor = System.Drawing.Color.White
        Me.lblLab4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLab4.Location = New System.Drawing.Point(500, 117)
        Me.lblLab4.Name = "lblLab4"
        Me.lblLab4.Size = New System.Drawing.Size(60, 23)
        Me.lblLab4.TabIndex = 297
        '
        'lblDes4
        '
        Me.lblDes4.BackColor = System.Drawing.Color.White
        Me.lblDes4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDes4.Location = New System.Drawing.Point(106, 117)
        Me.lblDes4.Name = "lblDes4"
        Me.lblDes4.Size = New System.Drawing.Size(388, 23)
        Me.lblDes4.TabIndex = 296
        '
        'lblCie4
        '
        Me.lblCie4.BackColor = System.Drawing.Color.White
        Me.lblCie4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCie4.Location = New System.Drawing.Point(40, 117)
        Me.lblCie4.Name = "lblCie4"
        Me.lblCie4.Size = New System.Drawing.Size(60, 23)
        Me.lblCie4.TabIndex = 295
        '
        'lblTD3
        '
        Me.lblTD3.BackColor = System.Drawing.Color.White
        Me.lblTD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTD3.Location = New System.Drawing.Point(566, 91)
        Me.lblTD3.Name = "lblTD3"
        Me.lblTD3.Size = New System.Drawing.Size(95, 23)
        Me.lblTD3.TabIndex = 294
        '
        'lblLab3
        '
        Me.lblLab3.BackColor = System.Drawing.Color.White
        Me.lblLab3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLab3.Location = New System.Drawing.Point(500, 91)
        Me.lblLab3.Name = "lblLab3"
        Me.lblLab3.Size = New System.Drawing.Size(60, 23)
        Me.lblLab3.TabIndex = 293
        '
        'lblDes3
        '
        Me.lblDes3.BackColor = System.Drawing.Color.White
        Me.lblDes3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDes3.Location = New System.Drawing.Point(106, 91)
        Me.lblDes3.Name = "lblDes3"
        Me.lblDes3.Size = New System.Drawing.Size(388, 23)
        Me.lblDes3.TabIndex = 292
        '
        'lblCie3
        '
        Me.lblCie3.BackColor = System.Drawing.Color.White
        Me.lblCie3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCie3.Location = New System.Drawing.Point(40, 91)
        Me.lblCie3.Name = "lblCie3"
        Me.lblCie3.Size = New System.Drawing.Size(60, 23)
        Me.lblCie3.TabIndex = 291
        '
        'lblTD2
        '
        Me.lblTD2.BackColor = System.Drawing.Color.White
        Me.lblTD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTD2.Location = New System.Drawing.Point(566, 65)
        Me.lblTD2.Name = "lblTD2"
        Me.lblTD2.Size = New System.Drawing.Size(95, 23)
        Me.lblTD2.TabIndex = 290
        '
        'lblLab2
        '
        Me.lblLab2.BackColor = System.Drawing.Color.White
        Me.lblLab2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLab2.Location = New System.Drawing.Point(500, 65)
        Me.lblLab2.Name = "lblLab2"
        Me.lblLab2.Size = New System.Drawing.Size(60, 23)
        Me.lblLab2.TabIndex = 289
        '
        'lblDes2
        '
        Me.lblDes2.BackColor = System.Drawing.Color.White
        Me.lblDes2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDes2.Location = New System.Drawing.Point(106, 65)
        Me.lblDes2.Name = "lblDes2"
        Me.lblDes2.Size = New System.Drawing.Size(388, 23)
        Me.lblDes2.TabIndex = 288
        '
        'lblCie2
        '
        Me.lblCie2.BackColor = System.Drawing.Color.White
        Me.lblCie2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCie2.Location = New System.Drawing.Point(40, 65)
        Me.lblCie2.Name = "lblCie2"
        Me.lblCie2.Size = New System.Drawing.Size(60, 23)
        Me.lblCie2.TabIndex = 287
        '
        'lblTD1
        '
        Me.lblTD1.BackColor = System.Drawing.Color.White
        Me.lblTD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTD1.Location = New System.Drawing.Point(566, 37)
        Me.lblTD1.Name = "lblTD1"
        Me.lblTD1.Size = New System.Drawing.Size(95, 23)
        Me.lblTD1.TabIndex = 286
        '
        'lblLab1
        '
        Me.lblLab1.BackColor = System.Drawing.Color.White
        Me.lblLab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLab1.Location = New System.Drawing.Point(500, 37)
        Me.lblLab1.Name = "lblLab1"
        Me.lblLab1.Size = New System.Drawing.Size(60, 23)
        Me.lblLab1.TabIndex = 285
        '
        'lblDes1
        '
        Me.lblDes1.BackColor = System.Drawing.Color.White
        Me.lblDes1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDes1.Location = New System.Drawing.Point(106, 37)
        Me.lblDes1.Name = "lblDes1"
        Me.lblDes1.Size = New System.Drawing.Size(388, 23)
        Me.lblDes1.TabIndex = 284
        '
        'lblCie1
        '
        Me.lblCie1.BackColor = System.Drawing.Color.White
        Me.lblCie1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCie1.Location = New System.Drawing.Point(40, 37)
        Me.lblCie1.Name = "lblCie1"
        Me.lblCie1.Size = New System.Drawing.Size(60, 23)
        Me.lblCie1.TabIndex = 283
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(499, 20)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(28, 13)
        Me.Label33.TabIndex = 282
        Me.Label33.Text = "Lab"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(37, 20)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(144, 13)
        Me.Label32.TabIndex = 281
        Me.Label32.Text = "Diagnosticos de Ingreso"
        '
        'frmAlta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 621)
        Me.Controls.Add(Me.tbAlta)
        Me.Controls.Add(Me.gbPaciente)
        Me.Controls.Add(Me.gbCIE)
        Me.Controls.Add(Me.gbP)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "frmAlta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de Paciente de Emergencia"
        Me.gbCIE.ResumeLayout(False)
        Me.gbCIE.PerformLayout()
        Me.gbP.ResumeLayout(False)
        Me.gbPaciente.ResumeLayout(False)
        Me.gbPaciente.PerformLayout()
        Me.tbAlta.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents gbCIE As System.Windows.Forms.GroupBox
    Friend WithEvents lvCIE As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents gbP As System.Windows.Forms.GroupBox
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Pagina As System.Windows.Forms.PageSetupDialog
    Friend WithEvents pdDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppDialogo As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Fuente As System.Windows.Forms.FontDialog
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents txtPaciente As System.Windows.Forms.TextBox
    Friend WithEvents lvPaciente As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader31 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader32 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRetornarP As System.Windows.Forms.Button
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents gbPaciente As System.Windows.Forms.GroupBox
    Friend WithEvents tbAlta As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lblTEdadD As System.Windows.Forms.Label
    Friend WithEvents btnBuscarP As System.Windows.Forms.Button
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents lblEdadD As System.Windows.Forms.Label
    Friend WithEvents lblTEdadM As System.Windows.Forms.Label
    Friend WithEvents lblEdadM As System.Windows.Forms.Label
    Friend WithEvents lblTEdad As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents lblDesOrigen As System.Windows.Forms.Label
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtDesDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboTD6 As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab6 As System.Windows.Forms.TextBox
    Friend WithEvents txtDes6 As System.Windows.Forms.TextBox
    Friend WithEvents txtCie6 As System.Windows.Forms.TextBox
    Friend WithEvents cboTD5 As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab5 As System.Windows.Forms.TextBox
    Friend WithEvents txtDes5 As System.Windows.Forms.TextBox
    Friend WithEvents txtCie5 As System.Windows.Forms.TextBox
    Friend WithEvents cboTD4 As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab4 As System.Windows.Forms.TextBox
    Friend WithEvents txtDes4 As System.Windows.Forms.TextBox
    Friend WithEvents txtCie4 As System.Windows.Forms.TextBox
    Friend WithEvents cboTD3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab3 As System.Windows.Forms.TextBox
    Friend WithEvents txtDes3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCie3 As System.Windows.Forms.TextBox
    Friend WithEvents cboTD2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDes2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCie2 As System.Windows.Forms.TextBox
    Friend WithEvents cboTD1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLab1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDes1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCie1 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboMedico As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAlta As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblDomicilio As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents lblEstadoCivil As System.Windows.Forms.Label
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents lblProvincia As System.Windows.Forms.Label
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents lblDpto As System.Windows.Forms.Label
    Friend WithEvents lblTipoAtencion As System.Windows.Forms.Label
    Friend WithEvents lblInformante As System.Windows.Forms.Label
    Friend WithEvents lblIngSer As System.Windows.Forms.Label
    Friend WithEvents lblIngEsta As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lblServicio As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblMedico As System.Windows.Forms.Label
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
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtExamenFisico As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtEnfermedadAct As System.Windows.Forms.TextBox
    Friend WithEvents txtMolestia As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblTD6 As System.Windows.Forms.Label
    Friend WithEvents lblLab6 As System.Windows.Forms.Label
    Friend WithEvents lblDes6 As System.Windows.Forms.Label
    Friend WithEvents lblCie6 As System.Windows.Forms.Label
    Friend WithEvents lblTD5 As System.Windows.Forms.Label
    Friend WithEvents lblLab5 As System.Windows.Forms.Label
    Friend WithEvents lblDes5 As System.Windows.Forms.Label
    Friend WithEvents lblCie5 As System.Windows.Forms.Label
    Friend WithEvents lblTD4 As System.Windows.Forms.Label
    Friend WithEvents lblLab4 As System.Windows.Forms.Label
    Friend WithEvents lblDes4 As System.Windows.Forms.Label
    Friend WithEvents lblCie4 As System.Windows.Forms.Label
    Friend WithEvents lblTD3 As System.Windows.Forms.Label
    Friend WithEvents lblLab3 As System.Windows.Forms.Label
    Friend WithEvents lblDes3 As System.Windows.Forms.Label
    Friend WithEvents lblCie3 As System.Windows.Forms.Label
    Friend WithEvents lblTD2 As System.Windows.Forms.Label
    Friend WithEvents lblLab2 As System.Windows.Forms.Label
    Friend WithEvents lblDes2 As System.Windows.Forms.Label
    Friend WithEvents lblCie2 As System.Windows.Forms.Label
    Friend WithEvents lblTD1 As System.Windows.Forms.Label
    Friend WithEvents lblLab1 As System.Windows.Forms.Label
    Friend WithEvents lblDes1 As System.Windows.Forms.Label
    Friend WithEvents lblCie1 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
End Class
