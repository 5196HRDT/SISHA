<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNovafis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNovafis))
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvDet = New System.Windows.Forms.ListView()
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader36 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader37 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader38 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader40 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader41 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader47 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader48 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader49 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnImprimirHIS = New System.Windows.Forms.Button()
        Me.btnImprimirT = New System.Windows.Forms.Button()
        Me.pdImpresion = New System.Windows.Forms.PrintDialog()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.lvConsulta = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMedico = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader39 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.gbHIS = New System.Windows.Forms.GroupBox()
        Me.cboTipoED = New System.Windows.Forms.ComboBox()
        Me.txtEdadD = New System.Windows.Forms.TextBox()
        Me.cboTipoEM = New System.Windows.Forms.ComboBox()
        Me.txtEdadM = New System.Windows.Forms.TextBox()
        Me.chkNB = New System.Windows.Forms.CheckBox()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.cboTEdad = New System.Windows.Forms.ComboBox()
        Me.chkCorrelativo = New System.Windows.Forms.CheckBox()
        Me.cboServicio = New System.Windows.Forms.ComboBox()
        Me.cboEstablecimiento = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.cboTipoAtencion = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpFecNac = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboSexo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnExportarE = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtEdad = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLab6 = New System.Windows.Forms.TextBox()
        Me.txtLab5 = New System.Windows.Forms.TextBox()
        Me.txtLab4 = New System.Windows.Forms.TextBox()
        Me.txtLab3 = New System.Windows.Forms.TextBox()
        Me.txtLab2 = New System.Windows.Forms.TextBox()
        Me.txtLab1 = New System.Windows.Forms.TextBox()
        Me.cboTD6 = New System.Windows.Forms.ComboBox()
        Me.txtDes6 = New System.Windows.Forms.TextBox()
        Me.txtCIE6 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboTD5 = New System.Windows.Forms.ComboBox()
        Me.txtDes5 = New System.Windows.Forms.TextBox()
        Me.txtCIE5 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboTD4 = New System.Windows.Forms.ComboBox()
        Me.txtDes4 = New System.Windows.Forms.TextBox()
        Me.txtCIE4 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboTD3 = New System.Windows.Forms.ComboBox()
        Me.txtDes3 = New System.Windows.Forms.TextBox()
        Me.txtCIE3 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboTD2 = New System.Windows.Forms.ComboBox()
        Me.txtDes2 = New System.Windows.Forms.TextBox()
        Me.txtCIE2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTD1 = New System.Windows.Forms.ComboBox()
        Me.txtDes1 = New System.Windows.Forms.TextBox()
        Me.txtCIE1 = New System.Windows.Forms.TextBox()
        Me.cboDistrito = New System.Windows.Forms.ComboBox()
        Me.cboProvincia = New System.Windows.Forms.ComboBox()
        Me.cboDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblMedico = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblEspecialidad = New System.Windows.Forms.Label()
        Me.gbConsulta = New System.Windows.Forms.GroupBox()
        Me.lvDX = New System.Windows.Forms.ListView()
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMedico = New System.Windows.Forms.TextBox()
        Me.lblTConsultas = New System.Windows.Forms.Label()
        Me.btnMigrar = New System.Windows.Forms.Button()
        Me.Folder = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtPagina = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lvMedicos1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader42 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader43 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader44 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader45 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader46 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsultas = New System.Windows.Forms.ListView()
        Me.ColumnHeader51 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader52 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader53 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader54 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader55 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboEst = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkCargar = New System.Windows.Forms.CheckBox()
        Me.dtpF2 = New System.Windows.Forms.DateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.chkVacunas = New System.Windows.Forms.CheckBox()
        Me.chkExcel = New System.Windows.Forms.CheckBox()
        Me.gbHIS.SuspendLayout()
        Me.gbConsulta.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboTurno
        '
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Items.AddRange(New Object() {"MAÑANA", "TARDE"})
        Me.cboTurno.Location = New System.Drawing.Point(382, 9)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(98, 21)
        Me.cboTurno.TabIndex = 1
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Ubigeo"
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Edad"
        Me.ColumnHeader17.Width = 40
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Sexo"
        Me.ColumnHeader18.Width = 40
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Estable"
        Me.ColumnHeader19.Width = 50
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Procedencia"
        Me.ColumnHeader15.Width = 80
        '
        'lvDet
        '
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader34, Me.ColumnHeader35, Me.ColumnHeader36, Me.ColumnHeader37, Me.ColumnHeader38, Me.ColumnHeader40, Me.ColumnHeader41, Me.ColumnHeader47, Me.ColumnHeader48, Me.ColumnHeader49})
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(12, 291)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(1241, 321)
        Me.lvDet.TabIndex = 5
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Dia"
        Me.ColumnHeader13.Width = 40
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Historia"
        Me.ColumnHeader14.Width = 80
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Serv"
        Me.ColumnHeader20.Width = 50
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Diagnostico"
        Me.ColumnHeader21.Width = 300
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "TipoDX"
        Me.ColumnHeader22.Width = 50
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Lab"
        Me.ColumnHeader23.Width = 50
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "CIE10"
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "DNI"
        Me.ColumnHeader25.Width = 0
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "CentroP"
        Me.ColumnHeader26.Width = 0
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "TipoCupo"
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Etnica"
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "Id"
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "TipoA"
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "FechaNac"
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Text = "Sexo"
        '
        'ColumnHeader36
        '
        Me.ColumnHeader36.Text = "EdadA"
        '
        'ColumnHeader37
        '
        Me.ColumnHeader37.Text = "EdadM"
        '
        'ColumnHeader38
        '
        Me.ColumnHeader38.Text = "EdadD"
        '
        'ColumnHeader40
        '
        Me.ColumnHeader40.Text = "Digita"
        Me.ColumnHeader40.Width = 80
        '
        'ColumnHeader41
        '
        Me.ColumnHeader41.Text = "CodServ"
        Me.ColumnHeader41.Width = 80
        '
        'ColumnHeader47
        '
        Me.ColumnHeader47.Text = "CSHistoria"
        '
        'ColumnHeader48
        '
        Me.ColumnHeader48.Text = "DNI"
        '
        'ColumnHeader49
        '
        Me.ColumnHeader49.Text = "TipoAtencion"
        '
        'btnImprimirHIS
        '
        Me.btnImprimirHIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirHIS.Location = New System.Drawing.Point(31, 579)
        Me.btnImprimirHIS.Name = "btnImprimirHIS"
        Me.btnImprimirHIS.Size = New System.Drawing.Size(127, 25)
        Me.btnImprimirHIS.TabIndex = 6
        Me.btnImprimirHIS.Text = "&Mostrar HIS"
        Me.btnImprimirHIS.UseVisualStyleBackColor = True
        '
        'btnImprimirT
        '
        Me.btnImprimirT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirT.Location = New System.Drawing.Point(31, 579)
        Me.btnImprimirT.Name = "btnImprimirT"
        Me.btnImprimirT.Size = New System.Drawing.Size(111, 25)
        Me.btnImprimirT.TabIndex = 42
        Me.btnImprimirT.Text = "&Imprimir Todo"
        Me.btnImprimirT.UseVisualStyleBackColor = True
        Me.btnImprimirT.Visible = False
        '
        'pdImpresion
        '
        Me.pdImpresion.AllowCurrentPage = True
        Me.pdImpresion.AllowSelection = True
        Me.pdImpresion.AllowSomePages = True
        Me.pdImpresion.Document = Me.pdcDocumento
        Me.pdImpresion.PrintToFile = True
        Me.pdImpresion.ShowHelp = True
        Me.pdImpresion.UseEXDialog = True
        '
        'pdcDocumento
        '
        Me.pdcDocumento.DocumentName = "HojaHIS"
        '
        'lvConsulta
        '
        Me.lvConsulta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader29})
        Me.lvConsulta.FullRowSelect = True
        Me.lvConsulta.GridLines = True
        Me.lvConsulta.Location = New System.Drawing.Point(12, 327)
        Me.lvConsulta.Name = "lvConsulta"
        Me.lvConsulta.Size = New System.Drawing.Size(742, 135)
        Me.lvConsulta.TabIndex = 41
        Me.lvConsulta.UseCompatibleStateImageBehavior = False
        Me.lvConsulta.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Historia"
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Apaterno"
        Me.ColumnHeader6.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "AMaterno"
        Me.ColumnHeader7.Width = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Nombres"
        Me.ColumnHeader8.Width = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Edad"
        Me.ColumnHeader9.Width = 80
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Sexo"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "FecNac"
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "IdCupo"
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Origen"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Medico"
        Me.ColumnHeader2.Width = 300
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Especialidad"
        Me.ColumnHeader3.Width = 300
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "IdProg"
        Me.ColumnHeader4.Width = 0
        '
        'lvMedico
        '
        Me.lvMedico.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader39})
        Me.lvMedico.FullRowSelect = True
        Me.lvMedico.GridLines = True
        Me.lvMedico.Location = New System.Drawing.Point(12, 155)
        Me.lvMedico.Name = "lvMedico"
        Me.lvMedico.Size = New System.Drawing.Size(544, 101)
        Me.lvMedico.TabIndex = 4
        Me.lvMedico.UseCompatibleStateImageBehavior = False
        Me.lvMedico.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader39
        '
        Me.ColumnHeader39.Text = "CodigoHIS"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(1292, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(28, 25)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "&X"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(334, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Turno"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(66, 10)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(98, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Desde"
        '
        'ppdVistaPrevia
        '
        Me.ppdVistaPrevia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdVistaPrevia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdVistaPrevia.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdVistaPrevia.Document = Me.pdcDocumento
        Me.ppdVistaPrevia.Enabled = True
        Me.ppdVistaPrevia.Icon = CType(resources.GetObject("ppdVistaPrevia.Icon"), System.Drawing.Icon)
        Me.ppdVistaPrevia.Name = "ppdVistaPrevia"
        Me.ppdVistaPrevia.Visible = False
        '
        'gbHIS
        '
        Me.gbHIS.Controls.Add(Me.cboTipoED)
        Me.gbHIS.Controls.Add(Me.txtEdadD)
        Me.gbHIS.Controls.Add(Me.cboTipoEM)
        Me.gbHIS.Controls.Add(Me.txtEdadM)
        Me.gbHIS.Controls.Add(Me.chkNB)
        Me.gbHIS.Controls.Add(Me.lblPaciente)
        Me.gbHIS.Controls.Add(Me.cboTEdad)
        Me.gbHIS.Controls.Add(Me.chkCorrelativo)
        Me.gbHIS.Controls.Add(Me.cboServicio)
        Me.gbHIS.Controls.Add(Me.cboEstablecimiento)
        Me.gbHIS.Controls.Add(Me.Label20)
        Me.gbHIS.Controls.Add(Me.btnNuevo)
        Me.gbHIS.Controls.Add(Me.cboTipoAtencion)
        Me.gbHIS.Controls.Add(Me.Label21)
        Me.gbHIS.Controls.Add(Me.dtpFecNac)
        Me.gbHIS.Controls.Add(Me.Label16)
        Me.gbHIS.Controls.Add(Me.cboSexo)
        Me.gbHIS.Controls.Add(Me.Label1)
        Me.gbHIS.Controls.Add(Me.txtDNI)
        Me.gbHIS.Controls.Add(Me.Label13)
        Me.gbHIS.Controls.Add(Me.btnExportarE)
        Me.gbHIS.Controls.Add(Me.btnCancelar)
        Me.gbHIS.Controls.Add(Me.btnGrabar)
        Me.gbHIS.Controls.Add(Me.txtEdad)
        Me.gbHIS.Controls.Add(Me.Label12)
        Me.gbHIS.Controls.Add(Me.txtLab6)
        Me.gbHIS.Controls.Add(Me.txtLab5)
        Me.gbHIS.Controls.Add(Me.txtLab4)
        Me.gbHIS.Controls.Add(Me.txtLab3)
        Me.gbHIS.Controls.Add(Me.txtLab2)
        Me.gbHIS.Controls.Add(Me.txtLab1)
        Me.gbHIS.Controls.Add(Me.cboTD6)
        Me.gbHIS.Controls.Add(Me.txtDes6)
        Me.gbHIS.Controls.Add(Me.txtCIE6)
        Me.gbHIS.Controls.Add(Me.Label11)
        Me.gbHIS.Controls.Add(Me.cboTD5)
        Me.gbHIS.Controls.Add(Me.txtDes5)
        Me.gbHIS.Controls.Add(Me.txtCIE5)
        Me.gbHIS.Controls.Add(Me.Label10)
        Me.gbHIS.Controls.Add(Me.cboTD4)
        Me.gbHIS.Controls.Add(Me.txtDes4)
        Me.gbHIS.Controls.Add(Me.txtCIE4)
        Me.gbHIS.Controls.Add(Me.Label9)
        Me.gbHIS.Controls.Add(Me.cboTD3)
        Me.gbHIS.Controls.Add(Me.txtDes3)
        Me.gbHIS.Controls.Add(Me.txtCIE3)
        Me.gbHIS.Controls.Add(Me.Label8)
        Me.gbHIS.Controls.Add(Me.cboTD2)
        Me.gbHIS.Controls.Add(Me.txtDes2)
        Me.gbHIS.Controls.Add(Me.txtCIE2)
        Me.gbHIS.Controls.Add(Me.Label7)
        Me.gbHIS.Controls.Add(Me.cboTD1)
        Me.gbHIS.Controls.Add(Me.txtDes1)
        Me.gbHIS.Controls.Add(Me.txtCIE1)
        Me.gbHIS.Controls.Add(Me.cboDistrito)
        Me.gbHIS.Controls.Add(Me.cboProvincia)
        Me.gbHIS.Controls.Add(Me.cboDepartamento)
        Me.gbHIS.Controls.Add(Me.Label4)
        Me.gbHIS.Controls.Add(Me.lblHistoria)
        Me.gbHIS.Controls.Add(Me.Label3)
        Me.gbHIS.Controls.Add(Me.Label2)
        Me.gbHIS.Location = New System.Drawing.Point(562, 4)
        Me.gbHIS.Name = "gbHIS"
        Me.gbHIS.Size = New System.Drawing.Size(691, 251)
        Me.gbHIS.TabIndex = 49
        Me.gbHIS.TabStop = False
        Me.gbHIS.Text = "Modificar Datos de HIS"
        '
        'cboTipoED
        '
        Me.cboTipoED.FormattingEnabled = True
        Me.cboTipoED.Items.AddRange(New Object() {"A", "M", "D"})
        Me.cboTipoED.Location = New System.Drawing.Point(160, 99)
        Me.cboTipoED.Name = "cboTipoED"
        Me.cboTipoED.Size = New System.Drawing.Size(31, 21)
        Me.cboTipoED.TabIndex = 61
        '
        'txtEdadD
        '
        Me.txtEdadD.Location = New System.Drawing.Point(130, 99)
        Me.txtEdadD.Name = "txtEdadD"
        Me.txtEdadD.Size = New System.Drawing.Size(32, 20)
        Me.txtEdadD.TabIndex = 60
        '
        'cboTipoEM
        '
        Me.cboTipoEM.FormattingEnabled = True
        Me.cboTipoEM.Items.AddRange(New Object() {"A", "M", "D"})
        Me.cboTipoEM.Location = New System.Drawing.Point(100, 99)
        Me.cboTipoEM.Name = "cboTipoEM"
        Me.cboTipoEM.Size = New System.Drawing.Size(31, 21)
        Me.cboTipoEM.TabIndex = 59
        '
        'txtEdadM
        '
        Me.txtEdadM.Location = New System.Drawing.Point(72, 99)
        Me.txtEdadM.Name = "txtEdadM"
        Me.txtEdadM.Size = New System.Drawing.Size(32, 20)
        Me.txtEdadM.TabIndex = 58
        '
        'chkNB
        '
        Me.chkNB.AutoSize = True
        Me.chkNB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNB.Location = New System.Drawing.Point(191, 207)
        Me.chkNB.Name = "chkNB"
        Me.chkNB.Size = New System.Drawing.Size(104, 17)
        Me.chkNB.TabIndex = 57
        Me.chkNB.Text = "No Borrar CIE"
        Me.chkNB.UseVisualStyleBackColor = True
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Location = New System.Drawing.Point(233, 10)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(451, 21)
        Me.lblPaciente.TabIndex = 56
        '
        'cboTEdad
        '
        Me.cboTEdad.FormattingEnabled = True
        Me.cboTEdad.Items.AddRange(New Object() {"A", "M", "D"})
        Me.cboTEdad.Location = New System.Drawing.Point(40, 99)
        Me.cboTEdad.Name = "cboTEdad"
        Me.cboTEdad.Size = New System.Drawing.Size(31, 21)
        Me.cboTEdad.TabIndex = 55
        '
        'chkCorrelativo
        '
        Me.chkCorrelativo.AutoSize = True
        Me.chkCorrelativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCorrelativo.Location = New System.Drawing.Point(191, 228)
        Me.chkCorrelativo.Name = "chkCorrelativo"
        Me.chkCorrelativo.Size = New System.Drawing.Size(87, 17)
        Me.chkCorrelativo.TabIndex = 54
        Me.chkCorrelativo.Text = "Correlativo"
        Me.chkCorrelativo.UseVisualStyleBackColor = True
        '
        'cboServicio
        '
        Me.cboServicio.FormattingEnabled = True
        Me.cboServicio.Items.AddRange(New Object() {"NUEVO", "CONTINUADOR", "REINGRESANTE"})
        Me.cboServicio.Location = New System.Drawing.Point(600, 191)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(89, 21)
        Me.cboServicio.TabIndex = 53
        '
        'cboEstablecimiento
        '
        Me.cboEstablecimiento.FormattingEnabled = True
        Me.cboEstablecimiento.Items.AddRange(New Object() {"NUEVO", "CONTINUADOR", "REINGRESANTE"})
        Me.cboEstablecimiento.Location = New System.Drawing.Point(501, 193)
        Me.cboEstablecimiento.Name = "cboEstablecimiento"
        Me.cboEstablecimiento.Size = New System.Drawing.Size(93, 21)
        Me.cboEstablecimiento.TabIndex = 52
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(437, 191)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 13)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "Tipo Ing."
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(307, 220)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(76, 25)
        Me.btnNuevo.TabIndex = 50
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cboTipoAtencion
        '
        Me.cboTipoAtencion.FormattingEnabled = True
        Me.cboTipoAtencion.Items.AddRange(New Object() {"SIS", "SOAT", "COMUN", "ESSALUD", "SANIDAD FAP", "SANIDAD NAVAL", "SANIDAD EP", "SANIDAD PNP", "PRIVADOS", "OTROS", "EXONERADO"})
        Me.cboTipoAtencion.Location = New System.Drawing.Point(307, 191)
        Me.cboTipoAtencion.Name = "cboTipoAtencion"
        Me.cboTipoAtencion.Size = New System.Drawing.Size(124, 21)
        Me.cboTipoAtencion.TabIndex = 49
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(188, 191)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(86, 13)
        Me.Label21.TabIndex = 48
        Me.Label21.Text = "Tipo Atención"
        '
        'dtpFecNac
        '
        Me.dtpFecNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecNac.Location = New System.Drawing.Point(87, 38)
        Me.dtpFecNac.Name = "dtpFecNac"
        Me.dtpFecNac.Size = New System.Drawing.Size(87, 20)
        Me.dtpFecNac.TabIndex = 46
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Fecha Ncto"
        '
        'cboSexo
        '
        Me.cboSexo.FormattingEnabled = True
        Me.cboSexo.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cboSexo.Location = New System.Drawing.Point(87, 64)
        Me.cboSexo.Name = "cboSexo"
        Me.cboSexo.Size = New System.Drawing.Size(84, 21)
        Me.cboSexo.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Sexo"
        '
        'txtDNI
        '
        Me.txtDNI.Location = New System.Drawing.Point(87, 126)
        Me.txtDNI.MaxLength = 8
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(87, 20)
        Me.txtDNI.TabIndex = 42
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 126)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "DNI"
        '
        'btnExportarE
        '
        Me.btnExportarE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarE.Location = New System.Drawing.Point(549, 220)
        Me.btnExportarE.Name = "btnExportarE"
        Me.btnExportarE.Size = New System.Drawing.Size(121, 25)
        Me.btnExportarE.TabIndex = 40
        Me.btnExportarE.Text = "&Exportar Excel"
        Me.btnExportarE.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(464, 220)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 25)
        Me.btnCancelar.TabIndex = 40
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(389, 220)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(69, 25)
        Me.btnGrabar.TabIndex = 39
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtEdad
        '
        Me.txtEdad.Location = New System.Drawing.Point(8, 99)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.Size = New System.Drawing.Size(33, 20)
        Me.txtEdad.TabIndex = 38
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(5, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Edad"
        '
        'txtLab6
        '
        Me.txtLab6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab6.Location = New System.Drawing.Point(549, 164)
        Me.txtLab6.MaxLength = 4
        Me.txtLab6.Name = "txtLab6"
        Me.txtLab6.Size = New System.Drawing.Size(45, 20)
        Me.txtLab6.TabIndex = 36
        '
        'txtLab5
        '
        Me.txtLab5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab5.Location = New System.Drawing.Point(549, 138)
        Me.txtLab5.MaxLength = 4
        Me.txtLab5.Name = "txtLab5"
        Me.txtLab5.Size = New System.Drawing.Size(45, 20)
        Me.txtLab5.TabIndex = 35
        '
        'txtLab4
        '
        Me.txtLab4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab4.Location = New System.Drawing.Point(549, 112)
        Me.txtLab4.MaxLength = 4
        Me.txtLab4.Name = "txtLab4"
        Me.txtLab4.Size = New System.Drawing.Size(45, 20)
        Me.txtLab4.TabIndex = 34
        '
        'txtLab3
        '
        Me.txtLab3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab3.Location = New System.Drawing.Point(549, 86)
        Me.txtLab3.MaxLength = 4
        Me.txtLab3.Name = "txtLab3"
        Me.txtLab3.Size = New System.Drawing.Size(45, 20)
        Me.txtLab3.TabIndex = 33
        '
        'txtLab2
        '
        Me.txtLab2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab2.Location = New System.Drawing.Point(549, 60)
        Me.txtLab2.MaxLength = 4
        Me.txtLab2.Name = "txtLab2"
        Me.txtLab2.Size = New System.Drawing.Size(45, 20)
        Me.txtLab2.TabIndex = 32
        '
        'txtLab1
        '
        Me.txtLab1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab1.Location = New System.Drawing.Point(549, 34)
        Me.txtLab1.MaxLength = 4
        Me.txtLab1.Name = "txtLab1"
        Me.txtLab1.Size = New System.Drawing.Size(45, 20)
        Me.txtLab1.TabIndex = 31
        '
        'cboTD6
        '
        Me.cboTD6.FormattingEnabled = True
        Me.cboTD6.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD6.Location = New System.Drawing.Point(600, 161)
        Me.cboTD6.Name = "cboTD6"
        Me.cboTD6.Size = New System.Drawing.Size(84, 21)
        Me.cboTD6.TabIndex = 30
        '
        'txtDes6
        '
        Me.txtDes6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes6.Location = New System.Drawing.Point(307, 164)
        Me.txtDes6.Name = "txtDes6"
        Me.txtDes6.Size = New System.Drawing.Size(236, 20)
        Me.txtDes6.TabIndex = 29
        '
        'txtCIE6
        '
        Me.txtCIE6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCIE6.Location = New System.Drawing.Point(233, 164)
        Me.txtCIE6.Name = "txtCIE6"
        Me.txtCIE6.Size = New System.Drawing.Size(68, 20)
        Me.txtCIE6.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(188, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "CIE 6"
        '
        'cboTD5
        '
        Me.cboTD5.FormattingEnabled = True
        Me.cboTD5.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD5.Location = New System.Drawing.Point(600, 135)
        Me.cboTD5.Name = "cboTD5"
        Me.cboTD5.Size = New System.Drawing.Size(84, 21)
        Me.cboTD5.TabIndex = 26
        '
        'txtDes5
        '
        Me.txtDes5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes5.Location = New System.Drawing.Point(307, 138)
        Me.txtDes5.Name = "txtDes5"
        Me.txtDes5.Size = New System.Drawing.Size(236, 20)
        Me.txtDes5.TabIndex = 25
        '
        'txtCIE5
        '
        Me.txtCIE5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCIE5.Location = New System.Drawing.Point(233, 138)
        Me.txtCIE5.Name = "txtCIE5"
        Me.txtCIE5.Size = New System.Drawing.Size(68, 20)
        Me.txtCIE5.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(188, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "CIE 5"
        '
        'cboTD4
        '
        Me.cboTD4.FormattingEnabled = True
        Me.cboTD4.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD4.Location = New System.Drawing.Point(600, 109)
        Me.cboTD4.Name = "cboTD4"
        Me.cboTD4.Size = New System.Drawing.Size(84, 21)
        Me.cboTD4.TabIndex = 22
        '
        'txtDes4
        '
        Me.txtDes4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes4.Location = New System.Drawing.Point(307, 112)
        Me.txtDes4.Name = "txtDes4"
        Me.txtDes4.Size = New System.Drawing.Size(236, 20)
        Me.txtDes4.TabIndex = 21
        '
        'txtCIE4
        '
        Me.txtCIE4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCIE4.Location = New System.Drawing.Point(233, 112)
        Me.txtCIE4.Name = "txtCIE4"
        Me.txtCIE4.Size = New System.Drawing.Size(68, 20)
        Me.txtCIE4.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(188, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "CIE 4"
        '
        'cboTD3
        '
        Me.cboTD3.FormattingEnabled = True
        Me.cboTD3.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD3.Location = New System.Drawing.Point(600, 83)
        Me.cboTD3.Name = "cboTD3"
        Me.cboTD3.Size = New System.Drawing.Size(84, 21)
        Me.cboTD3.TabIndex = 18
        '
        'txtDes3
        '
        Me.txtDes3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes3.Location = New System.Drawing.Point(307, 86)
        Me.txtDes3.Name = "txtDes3"
        Me.txtDes3.Size = New System.Drawing.Size(236, 20)
        Me.txtDes3.TabIndex = 17
        '
        'txtCIE3
        '
        Me.txtCIE3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCIE3.Location = New System.Drawing.Point(233, 86)
        Me.txtCIE3.Name = "txtCIE3"
        Me.txtCIE3.Size = New System.Drawing.Size(68, 20)
        Me.txtCIE3.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(188, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "CIE 3"
        '
        'cboTD2
        '
        Me.cboTD2.FormattingEnabled = True
        Me.cboTD2.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD2.Location = New System.Drawing.Point(600, 57)
        Me.cboTD2.Name = "cboTD2"
        Me.cboTD2.Size = New System.Drawing.Size(84, 21)
        Me.cboTD2.TabIndex = 14
        '
        'txtDes2
        '
        Me.txtDes2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes2.Location = New System.Drawing.Point(307, 60)
        Me.txtDes2.Name = "txtDes2"
        Me.txtDes2.Size = New System.Drawing.Size(236, 20)
        Me.txtDes2.TabIndex = 13
        '
        'txtCIE2
        '
        Me.txtCIE2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCIE2.Location = New System.Drawing.Point(233, 60)
        Me.txtCIE2.Name = "txtCIE2"
        Me.txtCIE2.Size = New System.Drawing.Size(68, 20)
        Me.txtCIE2.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(188, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "CIE 2"
        '
        'cboTD1
        '
        Me.cboTD1.FormattingEnabled = True
        Me.cboTD1.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD1.Location = New System.Drawing.Point(600, 31)
        Me.cboTD1.Name = "cboTD1"
        Me.cboTD1.Size = New System.Drawing.Size(84, 21)
        Me.cboTD1.TabIndex = 10
        '
        'txtDes1
        '
        Me.txtDes1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes1.Location = New System.Drawing.Point(307, 34)
        Me.txtDes1.Name = "txtDes1"
        Me.txtDes1.Size = New System.Drawing.Size(236, 20)
        Me.txtDes1.TabIndex = 8
        '
        'txtCIE1
        '
        Me.txtCIE1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCIE1.Location = New System.Drawing.Point(233, 34)
        Me.txtCIE1.Name = "txtCIE1"
        Me.txtCIE1.Size = New System.Drawing.Size(68, 20)
        Me.txtCIE1.TabIndex = 7
        '
        'cboDistrito
        '
        Me.cboDistrito.FormattingEnabled = True
        Me.cboDistrito.Location = New System.Drawing.Point(6, 220)
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.Size = New System.Drawing.Size(174, 21)
        Me.cboDistrito.TabIndex = 6
        '
        'cboProvincia
        '
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(6, 194)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(174, 21)
        Me.cboProvincia.TabIndex = 5
        '
        'cboDepartamento
        '
        Me.cboDepartamento.FormattingEnabled = True
        Me.cboDepartamento.Location = New System.Drawing.Point(6, 167)
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.Size = New System.Drawing.Size(174, 21)
        Me.cboDepartamento.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(188, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "CIE 1"
        '
        'lblHistoria
        '
        Me.lblHistoria.BackColor = System.Drawing.Color.White
        Me.lblHistoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHistoria.Location = New System.Drawing.Point(87, 15)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(71, 22)
        Me.lblHistoria.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Procedencia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Historia"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 259)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "MËDICO :"
        '
        'lblMedico
        '
        Me.lblMedico.BackColor = System.Drawing.Color.White
        Me.lblMedico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedico.Location = New System.Drawing.Point(86, 259)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(532, 21)
        Me.lblMedico.TabIndex = 51
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(619, 260)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "ESPECIALIDAD :"
        '
        'lblEspecialidad
        '
        Me.lblEspecialidad.BackColor = System.Drawing.Color.White
        Me.lblEspecialidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEspecialidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEspecialidad.Location = New System.Drawing.Point(729, 258)
        Me.lblEspecialidad.Name = "lblEspecialidad"
        Me.lblEspecialidad.Size = New System.Drawing.Size(391, 21)
        Me.lblEspecialidad.TabIndex = 53
        '
        'gbConsulta
        '
        Me.gbConsulta.Controls.Add(Me.lvDX)
        Me.gbConsulta.Controls.Add(Me.Label27)
        Me.gbConsulta.Controls.Add(Me.btnRetornar)
        Me.gbConsulta.Controls.Add(Me.txtDes)
        Me.gbConsulta.Controls.Add(Me.Label100)
        Me.gbConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConsulta.Location = New System.Drawing.Point(347, 4)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Size = New System.Drawing.Size(909, 434)
        Me.gbConsulta.TabIndex = 118
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta General"
        Me.gbConsulta.Visible = False
        '
        'lvDX
        '
        Me.lvDX.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader32, Me.ColumnHeader33})
        Me.lvDX.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDX.FullRowSelect = True
        Me.lvDX.GridLines = True
        Me.lvDX.Location = New System.Drawing.Point(9, 52)
        Me.lvDX.Name = "lvDX"
        Me.lvDX.Size = New System.Drawing.Size(894, 341)
        Me.lvDX.TabIndex = 2
        Me.lvDX.UseCompatibleStateImageBehavior = False
        Me.lvDX.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "CIE10"
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "Descripción"
        Me.ColumnHeader33.Width = 850
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(6, 407)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(265, 13)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Presione Enter para Insertar un Codigo CIE10"
        '
        'btnRetornar
        '
        Me.btnRetornar.Location = New System.Drawing.Point(373, 399)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Size = New System.Drawing.Size(78, 29)
        Me.btnRetornar.TabIndex = 3
        Me.btnRetornar.Text = "&Retornar"
        Me.btnRetornar.UseVisualStyleBackColor = True
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
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 119
        Me.Label17.Text = "Médico"
        '
        'txtMedico
        '
        Me.txtMedico.Location = New System.Drawing.Point(66, 31)
        Me.txtMedico.Name = "txtMedico"
        Me.txtMedico.Size = New System.Drawing.Size(262, 20)
        Me.txtMedico.TabIndex = 120
        '
        'lblTConsultas
        '
        Me.lblTConsultas.BackColor = System.Drawing.Color.White
        Me.lblTConsultas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTConsultas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTConsultas.Location = New System.Drawing.Point(1144, 258)
        Me.lblTConsultas.Name = "lblTConsultas"
        Me.lblTConsultas.Size = New System.Drawing.Size(112, 21)
        Me.lblTConsultas.TabIndex = 121
        '
        'btnMigrar
        '
        Me.btnMigrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMigrar.Location = New System.Drawing.Point(822, 613)
        Me.btnMigrar.Name = "btnMigrar"
        Me.btnMigrar.Size = New System.Drawing.Size(96, 25)
        Me.btnMigrar.TabIndex = 51
        Me.btnMigrar.Text = "&Migrar"
        Me.btnMigrar.UseVisualStyleBackColor = True
        '
        'txtPagina
        '
        Me.txtPagina.Location = New System.Drawing.Point(760, 614)
        Me.txtPagina.Name = "txtPagina"
        Me.txtPagina.Size = New System.Drawing.Size(56, 20)
        Me.txtPagina.TabIndex = 128
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(684, 616)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 127
        Me.Label19.Text = "Nro Página"
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(622, 614)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(56, 20)
        Me.txtLote.TabIndex = 126
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(555, 616)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 125
        Me.Label18.Text = "Nro Lote"
        '
        'lvMedicos1
        '
        Me.lvMedicos1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader42, Me.ColumnHeader43, Me.ColumnHeader44, Me.ColumnHeader45, Me.ColumnHeader46})
        Me.lvMedicos1.FullRowSelect = True
        Me.lvMedicos1.GridLines = True
        Me.lvMedicos1.Location = New System.Drawing.Point(12, 57)
        Me.lvMedicos1.Name = "lvMedicos1"
        Me.lvMedicos1.Size = New System.Drawing.Size(544, 94)
        Me.lvMedicos1.TabIndex = 129
        Me.lvMedicos1.UseCompatibleStateImageBehavior = False
        Me.lvMedicos1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader42
        '
        Me.ColumnHeader42.Text = "Id"
        Me.ColumnHeader42.Width = 0
        '
        'ColumnHeader43
        '
        Me.ColumnHeader43.Text = "Medico"
        Me.ColumnHeader43.Width = 300
        '
        'ColumnHeader44
        '
        Me.ColumnHeader44.Text = "Especialidad"
        Me.ColumnHeader44.Width = 300
        '
        'ColumnHeader45
        '
        Me.ColumnHeader45.Text = "IdProg"
        Me.ColumnHeader45.Width = 0
        '
        'ColumnHeader46
        '
        Me.ColumnHeader46.Text = "CodigoHIS"
        '
        'lvConsultas
        '
        Me.lvConsultas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader51, Me.ColumnHeader52, Me.ColumnHeader53, Me.ColumnHeader54, Me.ColumnHeader55})
        Me.lvConsultas.FullRowSelect = True
        Me.lvConsultas.GridLines = True
        Me.lvConsultas.Location = New System.Drawing.Point(1296, 256)
        Me.lvConsultas.Name = "lvConsultas"
        Me.lvConsultas.Size = New System.Drawing.Size(844, 115)
        Me.lvConsultas.TabIndex = 153
        Me.lvConsultas.UseCompatibleStateImageBehavior = False
        Me.lvConsultas.View = System.Windows.Forms.View.Details
        Me.lvConsultas.Visible = False
        '
        'ColumnHeader51
        '
        Me.ColumnHeader51.Text = "Fecha"
        Me.ColumnHeader51.Width = 80
        '
        'ColumnHeader52
        '
        Me.ColumnHeader52.Text = "Consultorio"
        Me.ColumnHeader52.Width = 300
        '
        'ColumnHeader53
        '
        Me.ColumnHeader53.Text = "Medico"
        Me.ColumnHeader53.Width = 300
        '
        'ColumnHeader54
        '
        Me.ColumnHeader54.Text = "IdCupo"
        '
        'ColumnHeader55
        '
        Me.ColumnHeader55.Text = "NHistoria"
        Me.ColumnHeader55.Width = 0
        '
        'Label22
        '
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(17, 610)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(336, 35)
        Me.Label22.TabIndex = 154
        Me.Label22.Text = "Para eliminar una Atención Seleccione la Fila Principal (De Color), presioene la " & _
            "Tecla SUPR y Confirme la Eliminación."
        '
        'cboEst
        '
        Me.cboEst.FormattingEnabled = True
        Me.cboEst.Items.AddRange(New Object() {"HRDT", "ALBRECHT"})
        Me.cboEst.Location = New System.Drawing.Point(427, 617)
        Me.cboEst.Name = "cboEst"
        Me.cboEst.Size = New System.Drawing.Size(121, 21)
        Me.cboEst.TabIndex = 155
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(330, 617)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(96, 13)
        Me.Label23.TabIndex = 156
        Me.Label23.Text = "Establecimiento"
        '
        'chkCargar
        '
        Me.chkCargar.AutoSize = True
        Me.chkCargar.Location = New System.Drawing.Point(347, 35)
        Me.chkCargar.Name = "chkCargar"
        Me.chkCargar.Size = New System.Drawing.Size(149, 17)
        Me.chkCargar.TabIndex = 157
        Me.chkCargar.Text = "&Cargar Todos los Medicos"
        Me.chkCargar.UseVisualStyleBackColor = True
        '
        'dtpF2
        '
        Me.dtpF2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpF2.Location = New System.Drawing.Point(230, 9)
        Me.dtpF2.Name = "dtpF2"
        Me.dtpF2.Size = New System.Drawing.Size(98, 20)
        Me.dtpF2.TabIndex = 158
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(181, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 13)
        Me.Label24.TabIndex = 159
        Me.Label24.Text = "Hasta"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(924, 613)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(96, 25)
        Me.btnImprimir.TabIndex = 160
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'chkVacunas
        '
        Me.chkVacunas.AutoSize = True
        Me.chkVacunas.Location = New System.Drawing.Point(502, 35)
        Me.chkVacunas.Name = "chkVacunas"
        Me.chkVacunas.Size = New System.Drawing.Size(64, 17)
        Me.chkVacunas.TabIndex = 161
        Me.chkVacunas.Text = "&No VAC"
        Me.chkVacunas.UseVisualStyleBackColor = True
        '
        'chkExcel
        '
        Me.chkExcel.AutoSize = True
        Me.chkExcel.Location = New System.Drawing.Point(486, 11)
        Me.chkExcel.Name = "chkExcel"
        Me.chkExcel.Size = New System.Drawing.Size(78, 17)
        Me.chkExcel.TabIndex = 162
        Me.chkExcel.Text = "Rep. Excel"
        Me.chkExcel.UseVisualStyleBackColor = True
        '
        'frmNovafis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1259, 642)
        Me.Controls.Add(Me.chkExcel)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dtpF2)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cboEst)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.gbConsulta)
        Me.Controls.Add(Me.lvMedico)
        Me.Controls.Add(Me.lvConsultas)
        Me.Controls.Add(Me.lvMedicos1)
        Me.Controls.Add(Me.txtPagina)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtLote)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.btnMigrar)
        Me.Controls.Add(Me.lblTConsultas)
        Me.Controls.Add(Me.txtMedico)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblEspecialidad)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblMedico)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.gbHIS)
        Me.Controls.Add(Me.cboTurno)
        Me.Controls.Add(Me.lvDet)
        Me.Controls.Add(Me.btnImprimirHIS)
        Me.Controls.Add(Me.btnImprimirT)
        Me.Controls.Add(Me.lvConsulta)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkCargar)
        Me.Controls.Add(Me.chkVacunas)
        Me.Name = "frmNovafis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HIS - HRDT"
        Me.gbHIS.ResumeLayout(False)
        Me.gbHIS.PerformLayout()
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTurno As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnImprimirHIS As System.Windows.Forms.Button
    Friend WithEvents btnImprimirT As System.Windows.Forms.Button
    Friend WithEvents pdImpresion As System.Windows.Forms.PrintDialog
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents lvConsulta As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMedico As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbHIS As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDes1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCIE1 As System.Windows.Forms.TextBox
    Friend WithEvents cboDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents cboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents txtEdad As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLab6 As System.Windows.Forms.TextBox
    Friend WithEvents txtLab5 As System.Windows.Forms.TextBox
    Friend WithEvents txtLab4 As System.Windows.Forms.TextBox
    Friend WithEvents txtLab3 As System.Windows.Forms.TextBox
    Friend WithEvents txtLab2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLab1 As System.Windows.Forms.TextBox
    Friend WithEvents cboTD6 As System.Windows.Forms.ComboBox
    Friend WithEvents txtDes6 As System.Windows.Forms.TextBox
    Friend WithEvents txtCIE6 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboTD5 As System.Windows.Forms.ComboBox
    Friend WithEvents txtDes5 As System.Windows.Forms.TextBox
    Friend WithEvents txtCIE5 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboTD4 As System.Windows.Forms.ComboBox
    Friend WithEvents txtDes4 As System.Windows.Forms.TextBox
    Friend WithEvents txtCIE4 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboTD3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtDes3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCIE3 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTD2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtDes2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCIE2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTD1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents txtDNI As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader31 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblMedico As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblEspecialidad As System.Windows.Forms.Label
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents lvDX As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader32 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader33 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
    Friend WithEvents txtDes As System.Windows.Forms.TextBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents dtpFecNac As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboSexo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader34 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader35 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtMedico As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader36 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader37 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader38 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTConsultas As System.Windows.Forms.Label
    Friend WithEvents btnMigrar As System.Windows.Forms.Button
    Friend WithEvents Folder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ColumnHeader39 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtPagina As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader40 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader41 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMedicos1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader42 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader43 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader44 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader45 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader46 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboTipoAtencion As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboServicio As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstablecimiento As System.Windows.Forms.ComboBox
    Friend WithEvents lvConsultas As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader51 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader52 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader53 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader54 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader55 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkCorrelativo As System.Windows.Forms.CheckBox
    Friend WithEvents cboTEdad As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader47 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader48 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader49 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents cboEst As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents chkNB As System.Windows.Forms.CheckBox
    Friend WithEvents chkCargar As System.Windows.Forms.CheckBox
    Friend WithEvents dtpF2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboTipoED As System.Windows.Forms.ComboBox
    Friend WithEvents txtEdadD As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoEM As System.Windows.Forms.ComboBox
    Friend WithEvents txtEdadM As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents chkVacunas As System.Windows.Forms.CheckBox
    Friend WithEvents btnExportarE As System.Windows.Forms.Button
    Friend WithEvents chkExcel As System.Windows.Forms.CheckBox
End Class
