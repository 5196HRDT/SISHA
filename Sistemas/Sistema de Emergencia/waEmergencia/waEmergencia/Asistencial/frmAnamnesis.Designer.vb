<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnamnesis
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
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.gbCIE = New System.Windows.Forms.GroupBox()
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lvCIE = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader45 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AyudaDiagnósticaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaboratorioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RayosXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EcografíaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatologíaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActoMédicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotaDeEvoluciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterconsultaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbAlta = New System.Windows.Forms.GroupBox()
        Me.btnRetornarAlta = New System.Windows.Forms.Button()
        Me.btnAceptarAlta = New System.Windows.Forms.Button()
        Me.txtDesDestino = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.cboTD6A = New System.Windows.Forms.ComboBox()
        Me.txtLab6A = New System.Windows.Forms.TextBox()
        Me.txtDes6A = New System.Windows.Forms.TextBox()
        Me.txtCie6A = New System.Windows.Forms.TextBox()
        Me.cboTD5A = New System.Windows.Forms.ComboBox()
        Me.txtLab5A = New System.Windows.Forms.TextBox()
        Me.txtDes5A = New System.Windows.Forms.TextBox()
        Me.txtCie5A = New System.Windows.Forms.TextBox()
        Me.cboTD4A = New System.Windows.Forms.ComboBox()
        Me.txtLab4A = New System.Windows.Forms.TextBox()
        Me.txtDes4A = New System.Windows.Forms.TextBox()
        Me.txtCie4A = New System.Windows.Forms.TextBox()
        Me.cboTD3A = New System.Windows.Forms.ComboBox()
        Me.txtLab3A = New System.Windows.Forms.TextBox()
        Me.txtDes3A = New System.Windows.Forms.TextBox()
        Me.txtCie3A = New System.Windows.Forms.TextBox()
        Me.cboTD2A = New System.Windows.Forms.ComboBox()
        Me.txtLab2A = New System.Windows.Forms.TextBox()
        Me.txtDes2A = New System.Windows.Forms.TextBox()
        Me.txtCie2A = New System.Windows.Forms.TextBox()
        Me.cboTD1A = New System.Windows.Forms.ComboBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.txtLab1A = New System.Windows.Forms.TextBox()
        Me.txtDes1A = New System.Windows.Forms.TextBox()
        Me.txtCie1A = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.cboCondicion = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.cboMedico = New System.Windows.Forms.ComboBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.cboTipoAlta = New System.Windows.Forms.ComboBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.gbCIEA = New System.Windows.Forms.GroupBox()
        Me.lvCIEA = New System.Windows.Forms.ListView()
        Me.ColumnHeader37 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader38 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader39 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader40 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader41 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader42 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader43 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader44 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRetornarA = New System.Windows.Forms.Button()
        Me.txtFiltroA = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.gbLabCE = New System.Windows.Forms.GroupBox()
        Me.lblPro1 = New System.Windows.Forms.Label()
        Me.btnRetornar01 = New System.Windows.Forms.Button()
        Me.txtRes1 = New System.Windows.Forms.TextBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.btnPendiente = New System.Windows.Forms.Button()
        Me.lvSolicitado = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader36 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtProcedimiento = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader48 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader49 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnRetornarAD = New System.Windows.Forms.Button()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.chkPagoContado = New System.Windows.Forms.CheckBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.gbAD = New System.Windows.Forms.GroupBox()
        Me.gbSI = New System.Windows.Forms.GroupBox()
        Me.btnRetornarSI = New System.Windows.Forms.Button()
        Me.lvSI = New System.Windows.Forms.ListView()
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader46 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader47 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.rbDx6 = New System.Windows.Forms.RadioButton()
        Me.rbDx5 = New System.Windows.Forms.RadioButton()
        Me.rbDx4 = New System.Windows.Forms.RadioButton()
        Me.rbDx3 = New System.Windows.Forms.RadioButton()
        Me.rbDx2 = New System.Windows.Forms.RadioButton()
        Me.rbDx1 = New System.Windows.Forms.RadioButton()
        Me.txtCama = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtAntFam = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtAntPat = New System.Windows.Forms.TextBox()
        Me.gbTipoAtencion = New System.Windows.Forms.GroupBox()
        Me.btnAceptarTA = New System.Windows.Forms.Button()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.cboTipoAtencion = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
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
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtLab1 = New System.Windows.Forms.TextBox()
        Me.txtDes1 = New System.Windows.Forms.TextBox()
        Me.txtCie1 = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtExamenFisico = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtPesoFB = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtSueño = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtDeposiciones = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtOrina = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtSed = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtApetito = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.txtEnfermedadAct = New System.Windows.Forms.TextBox()
        Me.txtC = New System.Windows.Forms.TextBox()
        Me.txtFormaInicio = New System.Windows.Forms.TextBox()
        Me.txtTiempoEnf = New System.Windows.Forms.TextBox()
        Me.txtTemperatura = New System.Windows.Forms.TextBox()
        Me.txtPresion = New System.Windows.Forms.TextBox()
        Me.txtPulso = New System.Windows.Forms.TextBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.txtTalla = New System.Windows.Forms.TextBox()
        Me.txtMolestia = New System.Windows.Forms.TextBox()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.lblPreliquidacion = New System.Windows.Forms.TextBox()
        Me.lblNumeroSIS = New System.Windows.Forms.TextBox()
        Me.lblSerieSIS = New System.Windows.Forms.TextBox()
        Me.cboPrioridad = New System.Windows.Forms.ComboBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.cboArea = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.lblEstadoCivil = New System.Windows.Forms.Label()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.lblDistrito = New System.Windows.Forms.Label()
        Me.lblDpto = New System.Windows.Forms.Label()
        Me.lblInformante = New System.Windows.Forms.Label()
        Me.lblIngSer = New System.Windows.Forms.Label()
        Me.lblIngEsta = New System.Windows.Forms.Label()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dtpFechaNcto = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblHoraAdmision = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFechaAdmision = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDesOrigen = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.lblTEdadD = New System.Windows.Forms.Label()
        Me.lblEdadD = New System.Windows.Forms.Label()
        Me.lblTEdadM = New System.Windows.Forms.Label()
        Me.lblEdadM = New System.Windows.Forms.Label()
        Me.lblTEdad = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.btnBuscarP = New System.Windows.Forms.Button()
        Me.cboMedIng = New System.Windows.Forms.ComboBox()
        Me.cboTipoAten = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cboTipoAtenEmer = New System.Windows.Forms.ComboBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.cboTipoIngreso = New System.Windows.Forms.ComboBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.cboRCP = New System.Windows.Forms.ComboBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.cboSala = New System.Windows.Forms.ComboBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.lblServicio = New System.Windows.Forms.ComboBox()
        Me.tbAnamnesis = New System.Windows.Forms.TabControl()
        Me.gbCIE.SuspendLayout()
        Me.gbPaciente.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.gbAlta.SuspendLayout()
        Me.gbCIEA.SuspendLayout()
        Me.gbLabCE.SuspendLayout()
        Me.gbAD.SuspendLayout()
        Me.gbSI.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbTipoAtencion.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tbAnamnesis.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(99, 573)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(93, 33)
        Me.btnNuevo.TabIndex = 46
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(227, 573)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(93, 33)
        Me.btnGrabar.TabIndex = 47
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(344, 573)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(93, 33)
        Me.btnCancelar.TabIndex = 48
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(476, 573)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(93, 33)
        Me.btnCerrar.TabIndex = 49
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'gbCIE
        '
        Me.gbCIE.Controls.Add(Me.btnRetornar)
        Me.gbCIE.Controls.Add(Me.txtFiltro)
        Me.gbCIE.Controls.Add(Me.Label7)
        Me.gbCIE.Controls.Add(Me.lvCIE)
        Me.gbCIE.Location = New System.Drawing.Point(663, 591)
        Me.gbCIE.Name = "gbCIE"
        Me.gbCIE.Size = New System.Drawing.Size(606, 235)
        Me.gbCIE.TabIndex = 164
        Me.gbCIE.TabStop = False
        '
        'btnRetornar
        '
        Me.btnRetornar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornar.Location = New System.Drawing.Point(558, 11)
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
        Me.txtFiltro.Size = New System.Drawing.Size(442, 20)
        Me.txtFiltro.TabIndex = 35
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Descripción"
        '
        'lvCIE
        '
        Me.lvCIE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader45})
        Me.lvCIE.FullRowSelect = True
        Me.lvCIE.GridLines = True
        Me.lvCIE.Location = New System.Drawing.Point(16, 44)
        Me.lvCIE.Name = "lvCIE"
        Me.lvCIE.Size = New System.Drawing.Size(579, 174)
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
        'ColumnHeader45
        '
        Me.ColumnHeader45.Text = "Emergencia"
        '
        'gbPaciente
        '
        Me.gbPaciente.Controls.Add(Me.Label53)
        Me.gbPaciente.Controls.Add(Me.btnRetornarP)
        Me.gbPaciente.Controls.Add(Me.lvPaciente)
        Me.gbPaciente.Controls.Add(Me.txtPaciente)
        Me.gbPaciente.Controls.Add(Me.Label54)
        Me.gbPaciente.Location = New System.Drawing.Point(826, 27)
        Me.gbPaciente.Name = "gbPaciente"
        Me.gbPaciente.Size = New System.Drawing.Size(702, 279)
        Me.gbPaciente.TabIndex = 176
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaDiagnósticaToolStripMenuItem, Me.ActoMédicoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(737, 24)
        Me.MenuStrip1.TabIndex = 169
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AyudaDiagnósticaToolStripMenuItem
        '
        Me.AyudaDiagnósticaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LaboratorioToolStripMenuItem, Me.RayosXToolStripMenuItem, Me.EcografíaToolStripMenuItem, Me.PatologíaToolStripMenuItem, Me.ToolStripMenuItem1, Me.OtrosToolStripMenuItem})
        Me.AyudaDiagnósticaToolStripMenuItem.Name = "AyudaDiagnósticaToolStripMenuItem"
        Me.AyudaDiagnósticaToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.AyudaDiagnósticaToolStripMenuItem.Text = "Ayuda Diagnóstica"
        '
        'LaboratorioToolStripMenuItem
        '
        Me.LaboratorioToolStripMenuItem.Name = "LaboratorioToolStripMenuItem"
        Me.LaboratorioToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.LaboratorioToolStripMenuItem.Text = "Laboratorio"
        '
        'RayosXToolStripMenuItem
        '
        Me.RayosXToolStripMenuItem.Name = "RayosXToolStripMenuItem"
        Me.RayosXToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.RayosXToolStripMenuItem.Text = "Rayos X"
        '
        'EcografíaToolStripMenuItem
        '
        Me.EcografíaToolStripMenuItem.Name = "EcografíaToolStripMenuItem"
        Me.EcografíaToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.EcografíaToolStripMenuItem.Text = "Ecografía"
        '
        'PatologíaToolStripMenuItem
        '
        Me.PatologíaToolStripMenuItem.Name = "PatologíaToolStripMenuItem"
        Me.PatologíaToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PatologíaToolStripMenuItem.Text = "Patología"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(132, 6)
        '
        'OtrosToolStripMenuItem
        '
        Me.OtrosToolStripMenuItem.Name = "OtrosToolStripMenuItem"
        Me.OtrosToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.OtrosToolStripMenuItem.Text = "Enfermeria"
        '
        'ActoMédicoToolStripMenuItem
        '
        Me.ActoMédicoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotaDeEvoluciónToolStripMenuItem, Me.InterconsultaToolStripMenuItem})
        Me.ActoMédicoToolStripMenuItem.Name = "ActoMédicoToolStripMenuItem"
        Me.ActoMédicoToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.ActoMédicoToolStripMenuItem.Text = "Acto Médico"
        '
        'NotaDeEvoluciónToolStripMenuItem
        '
        Me.NotaDeEvoluciónToolStripMenuItem.Name = "NotaDeEvoluciónToolStripMenuItem"
        Me.NotaDeEvoluciónToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.NotaDeEvoluciónToolStripMenuItem.Text = "Nota de Evolución"
        '
        'InterconsultaToolStripMenuItem
        '
        Me.InterconsultaToolStripMenuItem.Name = "InterconsultaToolStripMenuItem"
        Me.InterconsultaToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.InterconsultaToolStripMenuItem.Text = "Interconsulta"
        '
        'gbAlta
        '
        Me.gbAlta.Controls.Add(Me.btnRetornarAlta)
        Me.gbAlta.Controls.Add(Me.btnAceptarAlta)
        Me.gbAlta.Controls.Add(Me.txtDesDestino)
        Me.gbAlta.Controls.Add(Me.Label55)
        Me.gbAlta.Controls.Add(Me.Label56)
        Me.gbAlta.Controls.Add(Me.cboDestino)
        Me.gbAlta.Controls.Add(Me.Label57)
        Me.gbAlta.Controls.Add(Me.cboTD6A)
        Me.gbAlta.Controls.Add(Me.txtLab6A)
        Me.gbAlta.Controls.Add(Me.txtDes6A)
        Me.gbAlta.Controls.Add(Me.txtCie6A)
        Me.gbAlta.Controls.Add(Me.cboTD5A)
        Me.gbAlta.Controls.Add(Me.txtLab5A)
        Me.gbAlta.Controls.Add(Me.txtDes5A)
        Me.gbAlta.Controls.Add(Me.txtCie5A)
        Me.gbAlta.Controls.Add(Me.cboTD4A)
        Me.gbAlta.Controls.Add(Me.txtLab4A)
        Me.gbAlta.Controls.Add(Me.txtDes4A)
        Me.gbAlta.Controls.Add(Me.txtCie4A)
        Me.gbAlta.Controls.Add(Me.cboTD3A)
        Me.gbAlta.Controls.Add(Me.txtLab3A)
        Me.gbAlta.Controls.Add(Me.txtDes3A)
        Me.gbAlta.Controls.Add(Me.txtCie3A)
        Me.gbAlta.Controls.Add(Me.cboTD2A)
        Me.gbAlta.Controls.Add(Me.txtLab2A)
        Me.gbAlta.Controls.Add(Me.txtDes2A)
        Me.gbAlta.Controls.Add(Me.txtCie2A)
        Me.gbAlta.Controls.Add(Me.cboTD1A)
        Me.gbAlta.Controls.Add(Me.Label58)
        Me.gbAlta.Controls.Add(Me.txtLab1A)
        Me.gbAlta.Controls.Add(Me.txtDes1A)
        Me.gbAlta.Controls.Add(Me.txtCie1A)
        Me.gbAlta.Controls.Add(Me.Label59)
        Me.gbAlta.Controls.Add(Me.cboCondicion)
        Me.gbAlta.Controls.Add(Me.Label60)
        Me.gbAlta.Controls.Add(Me.cboMedico)
        Me.gbAlta.Controls.Add(Me.Label61)
        Me.gbAlta.Controls.Add(Me.cboTipoAlta)
        Me.gbAlta.Controls.Add(Me.Label62)
        Me.gbAlta.Location = New System.Drawing.Point(866, 492)
        Me.gbAlta.Name = "gbAlta"
        Me.gbAlta.Size = New System.Drawing.Size(735, 337)
        Me.gbAlta.TabIndex = 177
        Me.gbAlta.TabStop = False
        '
        'btnRetornarAlta
        '
        Me.btnRetornarAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornarAlta.Location = New System.Drawing.Point(455, 295)
        Me.btnRetornarAlta.Name = "btnRetornarAlta"
        Me.btnRetornarAlta.Size = New System.Drawing.Size(93, 33)
        Me.btnRetornarAlta.TabIndex = 313
        Me.btnRetornarAlta.Text = "&Retornar"
        Me.btnRetornarAlta.UseVisualStyleBackColor = True
        '
        'btnAceptarAlta
        '
        Me.btnAceptarAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarAlta.Location = New System.Drawing.Point(135, 298)
        Me.btnAceptarAlta.Name = "btnAceptarAlta"
        Me.btnAceptarAlta.Size = New System.Drawing.Size(93, 33)
        Me.btnAceptarAlta.TabIndex = 312
        Me.btnAceptarAlta.Text = "&Aceptar"
        Me.btnAceptarAlta.UseVisualStyleBackColor = True
        '
        'txtDesDestino
        '
        Me.txtDesDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesDestino.Location = New System.Drawing.Point(105, 91)
        Me.txtDesDestino.Name = "txtDesDestino"
        Me.txtDesDestino.Size = New System.Drawing.Size(607, 20)
        Me.txtDesDestino.TabIndex = 279
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(12, 91)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(87, 13)
        Me.Label55.TabIndex = 311
        Me.Label55.Text = "Desc. Destino"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(183, 21)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(312, 13)
        Me.Label56.TabIndex = 310
        Me.Label56.Text = "INFORMACION GENERAL DEL ALTA DE PACIENTES"
        '
        'cboDestino
        '
        Me.cboDestino.FormattingEnabled = True
        Me.cboDestino.Location = New System.Drawing.Point(424, 64)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(288, 21)
        Me.cboDestino.TabIndex = 278
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(331, 64)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(50, 13)
        Me.Label57.TabIndex = 309
        Me.Label57.Text = "Destino"
        '
        'cboTD6A
        '
        Me.cboTD6A.FormattingEnabled = True
        Me.cboTD6A.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD6A.Location = New System.Drawing.Point(591, 265)
        Me.cboTD6A.Name = "cboTD6A"
        Me.cboTD6A.Size = New System.Drawing.Size(121, 21)
        Me.cboTD6A.TabIndex = 303
        '
        'txtLab6A
        '
        Me.txtLab6A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab6A.Location = New System.Drawing.Point(522, 265)
        Me.txtLab6A.Name = "txtLab6A"
        Me.txtLab6A.Size = New System.Drawing.Size(63, 20)
        Me.txtLab6A.TabIndex = 302
        '
        'txtDes6A
        '
        Me.txtDes6A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes6A.Location = New System.Drawing.Point(83, 266)
        Me.txtDes6A.Name = "txtDes6A"
        Me.txtDes6A.Size = New System.Drawing.Size(433, 20)
        Me.txtDes6A.TabIndex = 301
        '
        'txtCie6A
        '
        Me.txtCie6A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie6A.Location = New System.Drawing.Point(14, 266)
        Me.txtCie6A.Name = "txtCie6A"
        Me.txtCie6A.Size = New System.Drawing.Size(63, 20)
        Me.txtCie6A.TabIndex = 300
        '
        'cboTD5A
        '
        Me.cboTD5A.FormattingEnabled = True
        Me.cboTD5A.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD5A.Location = New System.Drawing.Point(591, 239)
        Me.cboTD5A.Name = "cboTD5A"
        Me.cboTD5A.Size = New System.Drawing.Size(121, 21)
        Me.cboTD5A.TabIndex = 299
        '
        'txtLab5A
        '
        Me.txtLab5A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab5A.Location = New System.Drawing.Point(522, 239)
        Me.txtLab5A.Name = "txtLab5A"
        Me.txtLab5A.Size = New System.Drawing.Size(63, 20)
        Me.txtLab5A.TabIndex = 298
        '
        'txtDes5A
        '
        Me.txtDes5A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes5A.Location = New System.Drawing.Point(83, 240)
        Me.txtDes5A.Name = "txtDes5A"
        Me.txtDes5A.Size = New System.Drawing.Size(433, 20)
        Me.txtDes5A.TabIndex = 297
        '
        'txtCie5A
        '
        Me.txtCie5A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie5A.Location = New System.Drawing.Point(14, 240)
        Me.txtCie5A.Name = "txtCie5A"
        Me.txtCie5A.Size = New System.Drawing.Size(63, 20)
        Me.txtCie5A.TabIndex = 296
        '
        'cboTD4A
        '
        Me.cboTD4A.FormattingEnabled = True
        Me.cboTD4A.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD4A.Location = New System.Drawing.Point(591, 213)
        Me.cboTD4A.Name = "cboTD4A"
        Me.cboTD4A.Size = New System.Drawing.Size(121, 21)
        Me.cboTD4A.TabIndex = 295
        '
        'txtLab4A
        '
        Me.txtLab4A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab4A.Location = New System.Drawing.Point(522, 213)
        Me.txtLab4A.Name = "txtLab4A"
        Me.txtLab4A.Size = New System.Drawing.Size(63, 20)
        Me.txtLab4A.TabIndex = 294
        '
        'txtDes4A
        '
        Me.txtDes4A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes4A.Location = New System.Drawing.Point(83, 214)
        Me.txtDes4A.Name = "txtDes4A"
        Me.txtDes4A.Size = New System.Drawing.Size(433, 20)
        Me.txtDes4A.TabIndex = 293
        '
        'txtCie4A
        '
        Me.txtCie4A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie4A.Location = New System.Drawing.Point(14, 214)
        Me.txtCie4A.Name = "txtCie4A"
        Me.txtCie4A.Size = New System.Drawing.Size(63, 20)
        Me.txtCie4A.TabIndex = 292
        '
        'cboTD3A
        '
        Me.cboTD3A.FormattingEnabled = True
        Me.cboTD3A.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD3A.Location = New System.Drawing.Point(591, 186)
        Me.cboTD3A.Name = "cboTD3A"
        Me.cboTD3A.Size = New System.Drawing.Size(121, 21)
        Me.cboTD3A.TabIndex = 291
        '
        'txtLab3A
        '
        Me.txtLab3A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab3A.Location = New System.Drawing.Point(522, 186)
        Me.txtLab3A.Name = "txtLab3A"
        Me.txtLab3A.Size = New System.Drawing.Size(63, 20)
        Me.txtLab3A.TabIndex = 290
        '
        'txtDes3A
        '
        Me.txtDes3A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes3A.Location = New System.Drawing.Point(83, 187)
        Me.txtDes3A.Name = "txtDes3A"
        Me.txtDes3A.Size = New System.Drawing.Size(433, 20)
        Me.txtDes3A.TabIndex = 289
        '
        'txtCie3A
        '
        Me.txtCie3A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie3A.Location = New System.Drawing.Point(14, 187)
        Me.txtCie3A.Name = "txtCie3A"
        Me.txtCie3A.Size = New System.Drawing.Size(63, 20)
        Me.txtCie3A.TabIndex = 288
        '
        'cboTD2A
        '
        Me.cboTD2A.FormattingEnabled = True
        Me.cboTD2A.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD2A.Location = New System.Drawing.Point(591, 160)
        Me.cboTD2A.Name = "cboTD2A"
        Me.cboTD2A.Size = New System.Drawing.Size(121, 21)
        Me.cboTD2A.TabIndex = 287
        '
        'txtLab2A
        '
        Me.txtLab2A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab2A.Location = New System.Drawing.Point(522, 160)
        Me.txtLab2A.Name = "txtLab2A"
        Me.txtLab2A.Size = New System.Drawing.Size(63, 20)
        Me.txtLab2A.TabIndex = 286
        '
        'txtDes2A
        '
        Me.txtDes2A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes2A.Location = New System.Drawing.Point(83, 161)
        Me.txtDes2A.Name = "txtDes2A"
        Me.txtDes2A.Size = New System.Drawing.Size(433, 20)
        Me.txtDes2A.TabIndex = 285
        '
        'txtCie2A
        '
        Me.txtCie2A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie2A.Location = New System.Drawing.Point(14, 161)
        Me.txtCie2A.Name = "txtCie2A"
        Me.txtCie2A.Size = New System.Drawing.Size(63, 20)
        Me.txtCie2A.TabIndex = 284
        '
        'cboTD1A
        '
        Me.cboTD1A.FormattingEnabled = True
        Me.cboTD1A.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD1A.Location = New System.Drawing.Point(591, 134)
        Me.cboTD1A.Name = "cboTD1A"
        Me.cboTD1A.Size = New System.Drawing.Size(121, 21)
        Me.cboTD1A.TabIndex = 283
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(534, 118)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(28, 13)
        Me.Label58.TabIndex = 308
        Me.Label58.Text = "Lab"
        '
        'txtLab1A
        '
        Me.txtLab1A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab1A.Location = New System.Drawing.Point(522, 134)
        Me.txtLab1A.Name = "txtLab1A"
        Me.txtLab1A.Size = New System.Drawing.Size(63, 20)
        Me.txtLab1A.TabIndex = 282
        '
        'txtDes1A
        '
        Me.txtDes1A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes1A.Location = New System.Drawing.Point(83, 135)
        Me.txtDes1A.Name = "txtDes1A"
        Me.txtDes1A.Size = New System.Drawing.Size(433, 20)
        Me.txtDes1A.TabIndex = 281
        '
        'txtCie1A
        '
        Me.txtCie1A.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie1A.Location = New System.Drawing.Point(14, 135)
        Me.txtCie1A.Name = "txtCie1A"
        Me.txtCie1A.Size = New System.Drawing.Size(63, 20)
        Me.txtCie1A.TabIndex = 280
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(11, 119)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(124, 13)
        Me.Label59.TabIndex = 307
        Me.Label59.Text = "Diagnosticos de Alta"
        '
        'cboCondicion
        '
        Me.cboCondicion.FormattingEnabled = True
        Me.cboCondicion.Location = New System.Drawing.Point(105, 37)
        Me.cboCondicion.Name = "cboCondicion"
        Me.cboCondicion.Size = New System.Drawing.Size(211, 21)
        Me.cboCondicion.TabIndex = 275
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(12, 37)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(89, 13)
        Me.Label60.TabIndex = 306
        Me.Label60.Text = "Condición Alta"
        '
        'cboMedico
        '
        Me.cboMedico.FormattingEnabled = True
        Me.cboMedico.Location = New System.Drawing.Point(424, 37)
        Me.cboMedico.Name = "cboMedico"
        Me.cboMedico.Size = New System.Drawing.Size(288, 21)
        Me.cboMedico.TabIndex = 276
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(330, 43)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(74, 13)
        Me.Label61.TabIndex = 305
        Me.Label61.Text = "Médico Alta"
        '
        'cboTipoAlta
        '
        Me.cboTipoAlta.FormattingEnabled = True
        Me.cboTipoAlta.Location = New System.Drawing.Point(105, 64)
        Me.cboTipoAlta.Name = "cboTipoAlta"
        Me.cboTipoAlta.Size = New System.Drawing.Size(211, 21)
        Me.cboTipoAlta.TabIndex = 277
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(12, 64)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(58, 13)
        Me.Label62.TabIndex = 304
        Me.Label62.Text = "Tipo Alta"
        '
        'gbCIEA
        '
        Me.gbCIEA.Controls.Add(Me.lvCIEA)
        Me.gbCIEA.Controls.Add(Me.btnRetornarA)
        Me.gbCIEA.Controls.Add(Me.txtFiltroA)
        Me.gbCIEA.Controls.Add(Me.Label63)
        Me.gbCIEA.Location = New System.Drawing.Point(758, 155)
        Me.gbCIEA.Name = "gbCIEA"
        Me.gbCIEA.Size = New System.Drawing.Size(708, 235)
        Me.gbCIEA.TabIndex = 314
        Me.gbCIEA.TabStop = False
        '
        'lvCIEA
        '
        Me.lvCIEA.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader37, Me.ColumnHeader38, Me.ColumnHeader39, Me.ColumnHeader40, Me.ColumnHeader41, Me.ColumnHeader42, Me.ColumnHeader43, Me.ColumnHeader44})
        Me.lvCIEA.FullRowSelect = True
        Me.lvCIEA.GridLines = True
        Me.lvCIEA.Location = New System.Drawing.Point(13, 39)
        Me.lvCIEA.Name = "lvCIEA"
        Me.lvCIEA.Size = New System.Drawing.Size(684, 174)
        Me.lvCIEA.TabIndex = 37
        Me.lvCIEA.UseCompatibleStateImageBehavior = False
        Me.lvCIEA.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader37
        '
        Me.ColumnHeader37.Text = "Codigo"
        Me.ColumnHeader37.Width = 80
        '
        'ColumnHeader38
        '
        Me.ColumnHeader38.Text = "Descripcion"
        Me.ColumnHeader38.Width = 500
        '
        'ColumnHeader39
        '
        Me.ColumnHeader39.Text = "Definitivo"
        '
        'ColumnHeader40
        '
        Me.ColumnHeader40.Text = "Sexo"
        '
        'ColumnHeader41
        '
        Me.ColumnHeader41.Text = "MinEdad"
        '
        'ColumnHeader42
        '
        Me.ColumnHeader42.Text = "MinTipo"
        '
        'ColumnHeader43
        '
        Me.ColumnHeader43.Text = "MaxEdad"
        '
        'ColumnHeader44
        '
        Me.ColumnHeader44.Text = "MaxTipo"
        '
        'btnRetornarA
        '
        Me.btnRetornarA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornarA.Location = New System.Drawing.Point(660, 11)
        Me.btnRetornarA.Name = "btnRetornarA"
        Me.btnRetornarA.Size = New System.Drawing.Size(37, 23)
        Me.btnRetornarA.TabIndex = 36
        Me.btnRetornarA.Text = "&X"
        Me.btnRetornarA.UseVisualStyleBackColor = True
        '
        'txtFiltroA
        '
        Me.txtFiltroA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltroA.Location = New System.Drawing.Point(93, 13)
        Me.txtFiltroA.Name = "txtFiltroA"
        Me.txtFiltroA.Size = New System.Drawing.Size(495, 20)
        Me.txtFiltroA.TabIndex = 35
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(13, 16)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(74, 13)
        Me.Label63.TabIndex = 34
        Me.Label63.Text = "Descripción"
        '
        'gbLabCE
        '
        Me.gbLabCE.Controls.Add(Me.lblPro1)
        Me.gbLabCE.Controls.Add(Me.btnRetornar01)
        Me.gbLabCE.Controls.Add(Me.txtRes1)
        Me.gbLabCE.Location = New System.Drawing.Point(105, 205)
        Me.gbLabCE.Name = "gbLabCE"
        Me.gbLabCE.Size = New System.Drawing.Size(441, 174)
        Me.gbLabCE.TabIndex = 207
        Me.gbLabCE.TabStop = False
        '
        'lblPro1
        '
        Me.lblPro1.BackColor = System.Drawing.Color.White
        Me.lblPro1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPro1.Location = New System.Drawing.Point(6, 16)
        Me.lblPro1.Name = "lblPro1"
        Me.lblPro1.Size = New System.Drawing.Size(429, 25)
        Me.lblPro1.TabIndex = 19
        '
        'btnRetornar01
        '
        Me.btnRetornar01.Location = New System.Drawing.Point(185, 145)
        Me.btnRetornar01.Name = "btnRetornar01"
        Me.btnRetornar01.Size = New System.Drawing.Size(75, 23)
        Me.btnRetornar01.TabIndex = 1
        Me.btnRetornar01.Text = "&Retornar"
        Me.btnRetornar01.UseVisualStyleBackColor = True
        '
        'txtRes1
        '
        Me.txtRes1.Location = New System.Drawing.Point(6, 44)
        Me.txtRes1.Multiline = True
        Me.txtRes1.Name = "txtRes1"
        Me.txtRes1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRes1.Size = New System.Drawing.Size(429, 95)
        Me.txtRes1.TabIndex = 0
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.White
        Me.lblTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTipo.Location = New System.Drawing.Point(380, 59)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(95, 23)
        Me.lblTipo.TabIndex = 183
        '
        'btnPendiente
        '
        Me.btnPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPendiente.Location = New System.Drawing.Point(506, 347)
        Me.btnPendiente.Name = "btnPendiente"
        Me.btnPendiente.Size = New System.Drawing.Size(169, 33)
        Me.btnPendiente.TabIndex = 180
        Me.btnPendiente.Text = "&Pendiente de Pago"
        Me.btnPendiente.UseVisualStyleBackColor = True
        '
        'lvSolicitado
        '
        Me.lvSolicitado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader21, Me.ColumnHeader24, Me.ColumnHeader33, Me.ColumnHeader35, Me.ColumnHeader36, Me.ColumnHeader34})
        Me.lvSolicitado.FullRowSelect = True
        Me.lvSolicitado.GridLines = True
        Me.lvSolicitado.Location = New System.Drawing.Point(15, 208)
        Me.lvSolicitado.Name = "lvSolicitado"
        Me.lvSolicitado.Size = New System.Drawing.Size(685, 137)
        Me.lvSolicitado.TabIndex = 178
        Me.lvSolicitado.UseCompatibleStateImageBehavior = False
        Me.lvSolicitado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Codigo"
        Me.ColumnHeader17.Width = 0
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Cant"
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Descripcion"
        Me.ColumnHeader19.Width = 300
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Pagado"
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Resultado"
        Me.ColumnHeader22.Width = 300
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "IdDetalle"
        Me.ColumnHeader23.Width = 0
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "FechaCan"
        Me.ColumnHeader21.Width = 0
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "HoraCan"
        Me.ColumnHeader24.Width = 0
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "FechaMuestra"
        Me.ColumnHeader33.Width = 80
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Text = "FechaRes"
        Me.ColumnHeader35.Width = 80
        '
        'ColumnHeader36
        '
        Me.ColumnHeader36.Text = "HoraRes"
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "Pendiente"
        Me.ColumnHeader34.Width = 80
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(225, 62)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(43, 13)
        Me.Label47.TabIndex = 12
        Me.Label47.Text = "Precio"
        '
        'lblPrecio
        '
        Me.lblPrecio.BackColor = System.Drawing.Color.White
        Me.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecio.Location = New System.Drawing.Point(274, 59)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(100, 23)
        Me.lblPrecio.TabIndex = 171
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(582, 76)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(93, 33)
        Me.btnAceptar.TabIndex = 177
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(21, 39)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(87, 13)
        Me.Label45.TabIndex = 8
        Me.Label45.Text = "Procedimiento"
        '
        'txtProcedimiento
        '
        Me.txtProcedimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProcedimiento.Location = New System.Drawing.Point(114, 36)
        Me.txtProcedimiento.Name = "txtProcedimiento"
        Me.txtProcedimiento.Size = New System.Drawing.Size(361, 20)
        Me.txtProcedimiento.TabIndex = 9
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(21, 64)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(57, 13)
        Me.Label46.TabIndex = 10
        Me.Label46.Text = "Cantidad"
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader48, Me.ColumnHeader49})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(15, 87)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(543, 115)
        Me.lvTabla.TabIndex = 172
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
        'ColumnHeader48
        '
        Me.ColumnHeader48.Text = "Tipo"
        Me.ColumnHeader48.Width = 100
        '
        'ColumnHeader49
        '
        Me.ColumnHeader49.Text = "SubTipo"
        Me.ColumnHeader49.Width = 100
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(610, 154)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(36, 13)
        Me.Label49.TabIndex = 173
        Me.Label49.Text = "Total"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Location = New System.Drawing.Point(582, 172)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(100, 23)
        Me.lblTotal.TabIndex = 174
        '
        'btnRetornarAD
        '
        Me.btnRetornarAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornarAD.Location = New System.Drawing.Point(672, 11)
        Me.btnRetornarAD.Name = "btnRetornarAD"
        Me.btnRetornarAD.Size = New System.Drawing.Size(28, 23)
        Me.btnRetornarAD.TabIndex = 175
        Me.btnRetornarAD.Text = "&X"
        Me.btnRetornarAD.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(114, 62)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(73, 20)
        Me.txtCantidad.TabIndex = 11
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Red
        Me.Label52.Location = New System.Drawing.Point(15, 360)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(435, 13)
        Me.Label52.TabIndex = 179
        Me.Label52.Text = "(*) Presione la Tecla SUPR o DEL para Eliminar un Procedimiento Asignado"
        '
        'chkPagoContado
        '
        Me.chkPagoContado.AutoSize = True
        Me.chkPagoContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPagoContado.Location = New System.Drawing.Point(24, 16)
        Me.chkPagoContado.Name = "chkPagoContado"
        Me.chkPagoContado.Size = New System.Drawing.Size(106, 17)
        Me.chkPagoContado.TabIndex = 181
        Me.chkPagoContado.Text = "Pago Contado"
        Me.chkPagoContado.UseVisualStyleBackColor = True
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.ForeColor = System.Drawing.Color.Red
        Me.Label67.Location = New System.Drawing.Point(137, 17)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(460, 13)
        Me.Label67.TabIndex = 182
        Me.Label67.Text = "Activar esta Opcion SOLO cuando es Paciente SIS/SOAT y debe pagar en caja"
        '
        'gbAD
        '
        Me.gbAD.BackColor = System.Drawing.Color.NavajoWhite
        Me.gbAD.Controls.Add(Me.Label67)
        Me.gbAD.Controls.Add(Me.chkPagoContado)
        Me.gbAD.Controls.Add(Me.Label52)
        Me.gbAD.Controls.Add(Me.gbSI)
        Me.gbAD.Controls.Add(Me.txtCantidad)
        Me.gbAD.Controls.Add(Me.btnRetornarAD)
        Me.gbAD.Controls.Add(Me.lblTotal)
        Me.gbAD.Controls.Add(Me.Label49)
        Me.gbAD.Controls.Add(Me.lvTabla)
        Me.gbAD.Controls.Add(Me.Label46)
        Me.gbAD.Controls.Add(Me.txtProcedimiento)
        Me.gbAD.Controls.Add(Me.Label45)
        Me.gbAD.Controls.Add(Me.btnAceptar)
        Me.gbAD.Controls.Add(Me.lblPrecio)
        Me.gbAD.Controls.Add(Me.Label47)
        Me.gbAD.Controls.Add(Me.lvSolicitado)
        Me.gbAD.Controls.Add(Me.btnPendiente)
        Me.gbAD.Controls.Add(Me.lblTipo)
        Me.gbAD.Controls.Add(Me.gbLabCE)
        Me.gbAD.Location = New System.Drawing.Point(783, 106)
        Me.gbAD.Name = "gbAD"
        Me.gbAD.Size = New System.Drawing.Size(706, 387)
        Me.gbAD.TabIndex = 170
        Me.gbAD.TabStop = False
        Me.gbAD.Text = "Ayuda Diagnóstica"
        '
        'gbSI
        '
        Me.gbSI.Controls.Add(Me.btnRetornarSI)
        Me.gbSI.Controls.Add(Me.lvSI)
        Me.gbSI.Controls.Add(Me.txtDescripcion)
        Me.gbSI.Controls.Add(Me.Label48)
        Me.gbSI.Location = New System.Drawing.Point(46, 45)
        Me.gbSI.Name = "gbSI"
        Me.gbSI.Size = New System.Drawing.Size(551, 184)
        Me.gbSI.TabIndex = 176
        Me.gbSI.TabStop = False
        '
        'btnRetornarSI
        '
        Me.btnRetornarSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornarSI.Location = New System.Drawing.Point(506, 17)
        Me.btnRetornarSI.Name = "btnRetornarSI"
        Me.btnRetornarSI.Size = New System.Drawing.Size(28, 23)
        Me.btnRetornarSI.TabIndex = 176
        Me.btnRetornarSI.Text = "&X"
        Me.btnRetornarSI.UseVisualStyleBackColor = True
        '
        'lvSI
        '
        Me.lvSI.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader46, Me.ColumnHeader47})
        Me.lvSI.FullRowSelect = True
        Me.lvSI.GridLines = True
        Me.lvSI.Location = New System.Drawing.Point(12, 46)
        Me.lvSI.Name = "lvSI"
        Me.lvSI.Size = New System.Drawing.Size(522, 132)
        Me.lvSI.TabIndex = 12
        Me.lvSI.UseCompatibleStateImageBehavior = False
        Me.lvSI.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Codigo"
        Me.ColumnHeader14.Width = 0
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Descripcion"
        Me.ColumnHeader15.Width = 420
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Precio"
        Me.ColumnHeader16.Width = 80
        '
        'ColumnHeader46
        '
        Me.ColumnHeader46.Text = "Tipo"
        Me.ColumnHeader46.Width = 100
        '
        'ColumnHeader47
        '
        Me.ColumnHeader47.Text = "SubTipo"
        Me.ColumnHeader47.Width = 100
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(106, 20)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(379, 20)
        Me.txtDescripcion.TabIndex = 11
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(13, 23)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(74, 13)
        Me.Label48.TabIndex = 10
        Me.Label48.Text = "Descripción"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.rbDx6)
        Me.TabPage2.Controls.Add(Me.rbDx5)
        Me.TabPage2.Controls.Add(Me.rbDx4)
        Me.TabPage2.Controls.Add(Me.rbDx3)
        Me.TabPage2.Controls.Add(Me.rbDx2)
        Me.TabPage2.Controls.Add(Me.rbDx1)
        Me.TabPage2.Controls.Add(Me.txtCama)
        Me.TabPage2.Controls.Add(Me.Label64)
        Me.TabPage2.Controls.Add(Me.txtAntFam)
        Me.TabPage2.Controls.Add(Me.Label38)
        Me.TabPage2.Controls.Add(Me.txtAntPat)
        Me.TabPage2.Controls.Add(Me.gbTipoAtencion)
        Me.TabPage2.Controls.Add(Me.Label37)
        Me.TabPage2.Controls.Add(Me.cboTD6)
        Me.TabPage2.Controls.Add(Me.txtLab6)
        Me.TabPage2.Controls.Add(Me.txtDes6)
        Me.TabPage2.Controls.Add(Me.txtCie6)
        Me.TabPage2.Controls.Add(Me.cboTD5)
        Me.TabPage2.Controls.Add(Me.txtLab5)
        Me.TabPage2.Controls.Add(Me.txtDes5)
        Me.TabPage2.Controls.Add(Me.txtCie5)
        Me.TabPage2.Controls.Add(Me.cboTD4)
        Me.TabPage2.Controls.Add(Me.txtLab4)
        Me.TabPage2.Controls.Add(Me.txtDes4)
        Me.TabPage2.Controls.Add(Me.txtCie4)
        Me.TabPage2.Controls.Add(Me.cboTD3)
        Me.TabPage2.Controls.Add(Me.txtLab3)
        Me.TabPage2.Controls.Add(Me.txtDes3)
        Me.TabPage2.Controls.Add(Me.txtCie3)
        Me.TabPage2.Controls.Add(Me.cboTD2)
        Me.TabPage2.Controls.Add(Me.txtLab2)
        Me.TabPage2.Controls.Add(Me.txtDes2)
        Me.TabPage2.Controls.Add(Me.txtCie2)
        Me.TabPage2.Controls.Add(Me.cboTD1)
        Me.TabPage2.Controls.Add(Me.Label74)
        Me.TabPage2.Controls.Add(Me.Label33)
        Me.TabPage2.Controls.Add(Me.txtLab1)
        Me.TabPage2.Controls.Add(Me.txtDes1)
        Me.TabPage2.Controls.Add(Me.txtCie1)
        Me.TabPage2.Controls.Add(Me.Label32)
        Me.TabPage2.Controls.Add(Me.txtExamenFisico)
        Me.TabPage2.Controls.Add(Me.Label31)
        Me.TabPage2.Controls.Add(Me.txtPesoFB)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.txtSueño)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.txtDeposiciones)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.txtOrina)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.txtSed)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.txtApetito)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(717, 521)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pestaña II"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'rbDx6
        '
        Me.rbDx6.AutoSize = True
        Me.rbDx6.Enabled = False
        Me.rbDx6.Location = New System.Drawing.Point(677, 356)
        Me.rbDx6.Name = "rbDx6"
        Me.rbDx6.Size = New System.Drawing.Size(14, 13)
        Me.rbDx6.TabIndex = 220
        Me.rbDx6.TabStop = True
        Me.rbDx6.UseVisualStyleBackColor = True
        '
        'rbDx5
        '
        Me.rbDx5.AutoSize = True
        Me.rbDx5.Enabled = False
        Me.rbDx5.Location = New System.Drawing.Point(677, 330)
        Me.rbDx5.Name = "rbDx5"
        Me.rbDx5.Size = New System.Drawing.Size(14, 13)
        Me.rbDx5.TabIndex = 220
        Me.rbDx5.TabStop = True
        Me.rbDx5.UseVisualStyleBackColor = True
        '
        'rbDx4
        '
        Me.rbDx4.AutoSize = True
        Me.rbDx4.Enabled = False
        Me.rbDx4.Location = New System.Drawing.Point(677, 304)
        Me.rbDx4.Name = "rbDx4"
        Me.rbDx4.Size = New System.Drawing.Size(14, 13)
        Me.rbDx4.TabIndex = 220
        Me.rbDx4.TabStop = True
        Me.rbDx4.UseVisualStyleBackColor = True
        '
        'rbDx3
        '
        Me.rbDx3.AutoSize = True
        Me.rbDx3.Enabled = False
        Me.rbDx3.Location = New System.Drawing.Point(677, 277)
        Me.rbDx3.Name = "rbDx3"
        Me.rbDx3.Size = New System.Drawing.Size(14, 13)
        Me.rbDx3.TabIndex = 220
        Me.rbDx3.TabStop = True
        Me.rbDx3.UseVisualStyleBackColor = True
        '
        'rbDx2
        '
        Me.rbDx2.AutoSize = True
        Me.rbDx2.Enabled = False
        Me.rbDx2.Location = New System.Drawing.Point(677, 251)
        Me.rbDx2.Name = "rbDx2"
        Me.rbDx2.Size = New System.Drawing.Size(14, 13)
        Me.rbDx2.TabIndex = 220
        Me.rbDx2.TabStop = True
        Me.rbDx2.UseVisualStyleBackColor = True
        '
        'rbDx1
        '
        Me.rbDx1.AutoSize = True
        Me.rbDx1.Location = New System.Drawing.Point(677, 225)
        Me.rbDx1.Name = "rbDx1"
        Me.rbDx1.Size = New System.Drawing.Size(14, 13)
        Me.rbDx1.TabIndex = 220
        Me.rbDx1.TabStop = True
        Me.rbDx1.UseVisualStyleBackColor = True
        '
        'txtCama
        '
        Me.txtCama.Location = New System.Drawing.Point(532, 454)
        Me.txtCama.Name = "txtCama"
        Me.txtCama.Size = New System.Drawing.Size(117, 20)
        Me.txtCama.TabIndex = 219
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(529, 437)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(62, 13)
        Me.Label64.TabIndex = 218
        Me.Label64.Text = "Nro Cama"
        '
        'txtAntFam
        '
        Me.txtAntFam.Location = New System.Drawing.Point(13, 456)
        Me.txtAntFam.Multiline = True
        Me.txtAntFam.Name = "txtAntFam"
        Me.txtAntFam.Size = New System.Drawing.Size(510, 38)
        Me.txtAntFam.TabIndex = 216
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(10, 437)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(145, 13)
        Me.Label38.TabIndex = 217
        Me.Label38.Text = "Antecedentes Familiares"
        '
        'txtAntPat
        '
        Me.txtAntPat.Location = New System.Drawing.Point(13, 392)
        Me.txtAntPat.Multiline = True
        Me.txtAntPat.Name = "txtAntPat"
        Me.txtAntPat.Size = New System.Drawing.Size(636, 42)
        Me.txtAntPat.TabIndex = 215
        '
        'gbTipoAtencion
        '
        Me.gbTipoAtencion.Controls.Add(Me.btnAceptarTA)
        Me.gbTipoAtencion.Controls.Add(Me.Label66)
        Me.gbTipoAtencion.Controls.Add(Me.cboTipoAtencion)
        Me.gbTipoAtencion.Location = New System.Drawing.Point(27, 78)
        Me.gbTipoAtencion.Name = "gbTipoAtencion"
        Me.gbTipoAtencion.Size = New System.Drawing.Size(277, 104)
        Me.gbTipoAtencion.TabIndex = 214
        Me.gbTipoAtencion.TabStop = False
        '
        'btnAceptarTA
        '
        Me.btnAceptarTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarTA.Location = New System.Drawing.Point(88, 66)
        Me.btnAceptarTA.Name = "btnAceptarTA"
        Me.btnAceptarTA.Size = New System.Drawing.Size(93, 33)
        Me.btnAceptarTA.TabIndex = 308
        Me.btnAceptarTA.Text = "&Aceptar"
        Me.btnAceptarTA.UseVisualStyleBackColor = True
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(6, 15)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(104, 13)
        Me.Label66.TabIndex = 306
        Me.Label66.Text = "Tipo de Atención"
        '
        'cboTipoAtencion
        '
        Me.cboTipoAtencion.FormattingEnabled = True
        Me.cboTipoAtencion.Location = New System.Drawing.Point(9, 35)
        Me.cboTipoAtencion.Name = "cboTipoAtencion"
        Me.cboTipoAtencion.Size = New System.Drawing.Size(262, 21)
        Me.cboTipoAtencion.TabIndex = 0
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(10, 376)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(155, 13)
        Me.Label37.TabIndex = 213
        Me.Label37.Text = "Antecedentes Patológicos"
        '
        'cboTD6
        '
        Me.cboTD6.FormattingEnabled = True
        Me.cboTD6.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD6.Location = New System.Drawing.Point(528, 353)
        Me.cboTD6.Name = "cboTD6"
        Me.cboTD6.Size = New System.Drawing.Size(121, 21)
        Me.cboTD6.TabIndex = 210
        '
        'txtLab6
        '
        Me.txtLab6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab6.Location = New System.Drawing.Point(460, 353)
        Me.txtLab6.Name = "txtLab6"
        Me.txtLab6.Size = New System.Drawing.Size(63, 20)
        Me.txtLab6.TabIndex = 209
        '
        'txtDes6
        '
        Me.txtDes6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes6.Location = New System.Drawing.Point(82, 353)
        Me.txtDes6.Name = "txtDes6"
        Me.txtDes6.Size = New System.Drawing.Size(372, 20)
        Me.txtDes6.TabIndex = 208
        '
        'txtCie6
        '
        Me.txtCie6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie6.Location = New System.Drawing.Point(13, 353)
        Me.txtCie6.Name = "txtCie6"
        Me.txtCie6.Size = New System.Drawing.Size(63, 20)
        Me.txtCie6.TabIndex = 207
        '
        'cboTD5
        '
        Me.cboTD5.FormattingEnabled = True
        Me.cboTD5.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD5.Location = New System.Drawing.Point(528, 327)
        Me.cboTD5.Name = "cboTD5"
        Me.cboTD5.Size = New System.Drawing.Size(121, 21)
        Me.cboTD5.TabIndex = 206
        '
        'txtLab5
        '
        Me.txtLab5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab5.Location = New System.Drawing.Point(460, 327)
        Me.txtLab5.Name = "txtLab5"
        Me.txtLab5.Size = New System.Drawing.Size(63, 20)
        Me.txtLab5.TabIndex = 205
        '
        'txtDes5
        '
        Me.txtDes5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes5.Location = New System.Drawing.Point(82, 327)
        Me.txtDes5.Name = "txtDes5"
        Me.txtDes5.Size = New System.Drawing.Size(372, 20)
        Me.txtDes5.TabIndex = 204
        '
        'txtCie5
        '
        Me.txtCie5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie5.Location = New System.Drawing.Point(13, 327)
        Me.txtCie5.Name = "txtCie5"
        Me.txtCie5.Size = New System.Drawing.Size(63, 20)
        Me.txtCie5.TabIndex = 203
        '
        'cboTD4
        '
        Me.cboTD4.FormattingEnabled = True
        Me.cboTD4.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD4.Location = New System.Drawing.Point(528, 301)
        Me.cboTD4.Name = "cboTD4"
        Me.cboTD4.Size = New System.Drawing.Size(121, 21)
        Me.cboTD4.TabIndex = 202
        '
        'txtLab4
        '
        Me.txtLab4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab4.Location = New System.Drawing.Point(460, 301)
        Me.txtLab4.Name = "txtLab4"
        Me.txtLab4.Size = New System.Drawing.Size(63, 20)
        Me.txtLab4.TabIndex = 201
        '
        'txtDes4
        '
        Me.txtDes4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes4.Location = New System.Drawing.Point(82, 301)
        Me.txtDes4.Name = "txtDes4"
        Me.txtDes4.Size = New System.Drawing.Size(372, 20)
        Me.txtDes4.TabIndex = 200
        '
        'txtCie4
        '
        Me.txtCie4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie4.Location = New System.Drawing.Point(13, 301)
        Me.txtCie4.Name = "txtCie4"
        Me.txtCie4.Size = New System.Drawing.Size(63, 20)
        Me.txtCie4.TabIndex = 199
        '
        'cboTD3
        '
        Me.cboTD3.FormattingEnabled = True
        Me.cboTD3.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD3.Location = New System.Drawing.Point(528, 274)
        Me.cboTD3.Name = "cboTD3"
        Me.cboTD3.Size = New System.Drawing.Size(121, 21)
        Me.cboTD3.TabIndex = 198
        '
        'txtLab3
        '
        Me.txtLab3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab3.Location = New System.Drawing.Point(460, 274)
        Me.txtLab3.Name = "txtLab3"
        Me.txtLab3.Size = New System.Drawing.Size(63, 20)
        Me.txtLab3.TabIndex = 197
        '
        'txtDes3
        '
        Me.txtDes3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes3.Location = New System.Drawing.Point(82, 274)
        Me.txtDes3.Name = "txtDes3"
        Me.txtDes3.Size = New System.Drawing.Size(372, 20)
        Me.txtDes3.TabIndex = 196
        '
        'txtCie3
        '
        Me.txtCie3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie3.Location = New System.Drawing.Point(13, 274)
        Me.txtCie3.Name = "txtCie3"
        Me.txtCie3.Size = New System.Drawing.Size(63, 20)
        Me.txtCie3.TabIndex = 195
        '
        'cboTD2
        '
        Me.cboTD2.FormattingEnabled = True
        Me.cboTD2.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD2.Location = New System.Drawing.Point(528, 248)
        Me.cboTD2.Name = "cboTD2"
        Me.cboTD2.Size = New System.Drawing.Size(121, 21)
        Me.cboTD2.TabIndex = 194
        '
        'txtLab2
        '
        Me.txtLab2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab2.Location = New System.Drawing.Point(460, 248)
        Me.txtLab2.Name = "txtLab2"
        Me.txtLab2.Size = New System.Drawing.Size(63, 20)
        Me.txtLab2.TabIndex = 193
        '
        'txtDes2
        '
        Me.txtDes2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes2.Location = New System.Drawing.Point(82, 248)
        Me.txtDes2.Name = "txtDes2"
        Me.txtDes2.Size = New System.Drawing.Size(372, 20)
        Me.txtDes2.TabIndex = 192
        '
        'txtCie2
        '
        Me.txtCie2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie2.Location = New System.Drawing.Point(13, 248)
        Me.txtCie2.Name = "txtCie2"
        Me.txtCie2.Size = New System.Drawing.Size(63, 20)
        Me.txtCie2.TabIndex = 191
        '
        'cboTD1
        '
        Me.cboTD1.FormattingEnabled = True
        Me.cboTD1.Items.AddRange(New Object() {"DEFINITIVO", "PRESUNTIVO", "REPETITIVO"})
        Me.cboTD1.Location = New System.Drawing.Point(528, 222)
        Me.cboTD1.Name = "cboTD1"
        Me.cboTD1.Size = New System.Drawing.Size(121, 21)
        Me.cboTD1.TabIndex = 190
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(653, 206)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(56, 13)
        Me.Label74.TabIndex = 212
        Me.Label74.Text = "Principal"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(472, 206)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(28, 13)
        Me.Label33.TabIndex = 212
        Me.Label33.Text = "Lab"
        '
        'txtLab1
        '
        Me.txtLab1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLab1.Location = New System.Drawing.Point(460, 222)
        Me.txtLab1.Name = "txtLab1"
        Me.txtLab1.Size = New System.Drawing.Size(63, 20)
        Me.txtLab1.TabIndex = 189
        '
        'txtDes1
        '
        Me.txtDes1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes1.Location = New System.Drawing.Point(82, 222)
        Me.txtDes1.Name = "txtDes1"
        Me.txtDes1.Size = New System.Drawing.Size(372, 20)
        Me.txtDes1.TabIndex = 188
        '
        'txtCie1
        '
        Me.txtCie1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCie1.Location = New System.Drawing.Point(13, 222)
        Me.txtCie1.Name = "txtCie1"
        Me.txtCie1.Size = New System.Drawing.Size(63, 20)
        Me.txtCie1.TabIndex = 187
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(10, 206)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(144, 13)
        Me.Label32.TabIndex = 211
        Me.Label32.Text = "Diagnosticos de Ingreso"
        '
        'txtExamenFisico
        '
        Me.txtExamenFisico.Location = New System.Drawing.Point(13, 131)
        Me.txtExamenFisico.Multiline = True
        Me.txtExamenFisico.Name = "txtExamenFisico"
        Me.txtExamenFisico.Size = New System.Drawing.Size(636, 72)
        Me.txtExamenFisico.TabIndex = 186
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(6, 108)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(90, 13)
        Me.Label31.TabIndex = 75
        Me.Label31.Text = "Examen Físico"
        '
        'txtPesoFB
        '
        Me.txtPesoFB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPesoFB.Location = New System.Drawing.Point(424, 88)
        Me.txtPesoFB.Name = "txtPesoFB"
        Me.txtPesoFB.Size = New System.Drawing.Size(211, 20)
        Me.txtPesoFB.TabIndex = 67
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(325, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(35, 13)
        Me.Label22.TabIndex = 74
        Me.Label22.Text = "Peso"
        '
        'txtSueño
        '
        Me.txtSueño.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSueño.Location = New System.Drawing.Point(79, 88)
        Me.txtSueño.Name = "txtSueño"
        Me.txtSueño.Size = New System.Drawing.Size(211, 20)
        Me.txtSueño.TabIndex = 66
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 88)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 13)
        Me.Label23.TabIndex = 73
        Me.Label23.Text = "Sueño"
        '
        'txtDeposiciones
        '
        Me.txtDeposiciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeposiciones.Location = New System.Drawing.Point(424, 62)
        Me.txtDeposiciones.Name = "txtDeposiciones"
        Me.txtDeposiciones.Size = New System.Drawing.Size(211, 20)
        Me.txtDeposiciones.TabIndex = 65
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(325, 62)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 13)
        Me.Label20.TabIndex = 72
        Me.Label20.Text = "Deposiciones"
        '
        'txtOrina
        '
        Me.txtOrina.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrina.Location = New System.Drawing.Point(79, 62)
        Me.txtOrina.Name = "txtOrina"
        Me.txtOrina.Size = New System.Drawing.Size(211, 20)
        Me.txtOrina.TabIndex = 64
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 62)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 13)
        Me.Label21.TabIndex = 71
        Me.Label21.Text = "Orina"
        '
        'txtSed
        '
        Me.txtSed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSed.Location = New System.Drawing.Point(424, 33)
        Me.txtSed.Name = "txtSed"
        Me.txtSed.Size = New System.Drawing.Size(211, 20)
        Me.txtSed.TabIndex = 63
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(325, 36)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 70
        Me.Label19.Text = "Sed"
        '
        'txtApetito
        '
        Me.txtApetito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApetito.Location = New System.Drawing.Point(79, 36)
        Me.txtApetito.Name = "txtApetito"
        Me.txtApetito.Size = New System.Drawing.Size(211, 20)
        Me.txtApetito.TabIndex = 62
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 69
        Me.Label18.Text = "Apetito"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 13)
        Me.Label17.TabIndex = 68
        Me.Label17.Text = "Funciones Biológicas"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtHistoria)
        Me.TabPage1.Controls.Add(Me.txtEnfermedadAct)
        Me.TabPage1.Controls.Add(Me.txtC)
        Me.TabPage1.Controls.Add(Me.txtFormaInicio)
        Me.TabPage1.Controls.Add(Me.txtTiempoEnf)
        Me.TabPage1.Controls.Add(Me.txtTemperatura)
        Me.TabPage1.Controls.Add(Me.txtPresion)
        Me.TabPage1.Controls.Add(Me.txtPulso)
        Me.TabPage1.Controls.Add(Me.txtPeso)
        Me.TabPage1.Controls.Add(Me.txtTalla)
        Me.TabPage1.Controls.Add(Me.txtMolestia)
        Me.TabPage1.Controls.Add(Me.txtHora)
        Me.TabPage1.Controls.Add(Me.lblPreliquidacion)
        Me.TabPage1.Controls.Add(Me.lblNumeroSIS)
        Me.TabPage1.Controls.Add(Me.lblSerieSIS)
        Me.TabPage1.Controls.Add(Me.cboPrioridad)
        Me.TabPage1.Controls.Add(Me.Label73)
        Me.TabPage1.Controls.Add(Me.cboArea)
        Me.TabPage1.Controls.Add(Me.Label50)
        Me.TabPage1.Controls.Add(Me.Label44)
        Me.TabPage1.Controls.Add(Me.cboOrigen)
        Me.TabPage1.Controls.Add(Me.Label43)
        Me.TabPage1.Controls.Add(Me.lblDomicilio)
        Me.TabPage1.Controls.Add(Me.lblPaciente)
        Me.TabPage1.Controls.Add(Me.lblEstadoCivil)
        Me.TabPage1.Controls.Add(Me.lblGrado)
        Me.TabPage1.Controls.Add(Me.lblProvincia)
        Me.TabPage1.Controls.Add(Me.lblDistrito)
        Me.TabPage1.Controls.Add(Me.lblDpto)
        Me.TabPage1.Controls.Add(Me.lblInformante)
        Me.TabPage1.Controls.Add(Me.lblIngSer)
        Me.TabPage1.Controls.Add(Me.lblIngEsta)
        Me.TabPage1.Controls.Add(Me.lblSexo)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label42)
        Me.TabPage1.Controls.Add(Me.Label39)
        Me.TabPage1.Controls.Add(Me.Label40)
        Me.TabPage1.Controls.Add(Me.Label41)
        Me.TabPage1.Controls.Add(Me.Label35)
        Me.TabPage1.Controls.Add(Me.Label34)
        Me.TabPage1.Controls.Add(Me.Label30)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.dtpFechaNcto)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.dtpFecha)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.lblHoraAdmision)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.lblFechaAdmision)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cboDesOrigen)
        Me.TabPage1.Controls.Add(Me.Label51)
        Me.TabPage1.Controls.Add(Me.lblTEdadD)
        Me.TabPage1.Controls.Add(Me.lblEdadD)
        Me.TabPage1.Controls.Add(Me.lblTEdadM)
        Me.TabPage1.Controls.Add(Me.lblEdadM)
        Me.TabPage1.Controls.Add(Me.lblTEdad)
        Me.TabPage1.Controls.Add(Me.lblEdad)
        Me.TabPage1.Controls.Add(Me.Label65)
        Me.TabPage1.Controls.Add(Me.btnBuscarP)
        Me.TabPage1.Controls.Add(Me.cboMedIng)
        Me.TabPage1.Controls.Add(Me.cboTipoAten)
        Me.TabPage1.Controls.Add(Me.Label36)
        Me.TabPage1.Controls.Add(Me.cboTipoAtenEmer)
        Me.TabPage1.Controls.Add(Me.Label69)
        Me.TabPage1.Controls.Add(Me.cboTipoIngreso)
        Me.TabPage1.Controls.Add(Me.Label68)
        Me.TabPage1.Controls.Add(Me.cboRCP)
        Me.TabPage1.Controls.Add(Me.Label72)
        Me.TabPage1.Controls.Add(Me.Label71)
        Me.TabPage1.Controls.Add(Me.cboSala)
        Me.TabPage1.Controls.Add(Me.Label70)
        Me.TabPage1.Controls.Add(Me.lblServicio)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(717, 521)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pestaña I"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(93, 41)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(75, 20)
        Me.txtHistoria.TabIndex = 591
        Me.txtHistoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEnfermedadAct
        '
        Me.txtEnfermedadAct.Location = New System.Drawing.Point(15, 452)
        Me.txtEnfermedadAct.Multiline = True
        Me.txtEnfermedadAct.Name = "txtEnfermedadAct"
        Me.txtEnfermedadAct.Size = New System.Drawing.Size(700, 53)
        Me.txtEnfermedadAct.TabIndex = 524
        '
        'txtC
        '
        Me.txtC.Location = New System.Drawing.Point(646, 429)
        Me.txtC.Name = "txtC"
        Me.txtC.Size = New System.Drawing.Size(67, 20)
        Me.txtC.TabIndex = 523
        '
        'txtFormaInicio
        '
        Me.txtFormaInicio.Location = New System.Drawing.Point(504, 429)
        Me.txtFormaInicio.Name = "txtFormaInicio"
        Me.txtFormaInicio.Size = New System.Drawing.Size(46, 20)
        Me.txtFormaInicio.TabIndex = 521
        '
        'txtTiempoEnf
        '
        Me.txtTiempoEnf.Location = New System.Drawing.Point(352, 429)
        Me.txtTiempoEnf.Name = "txtTiempoEnf"
        Me.txtTiempoEnf.Size = New System.Drawing.Size(44, 20)
        Me.txtTiempoEnf.TabIndex = 519
        '
        'txtTemperatura
        '
        Me.txtTemperatura.Location = New System.Drawing.Point(676, 357)
        Me.txtTemperatura.Name = "txtTemperatura"
        Me.txtTemperatura.Size = New System.Drawing.Size(36, 20)
        Me.txtTemperatura.TabIndex = 517
        '
        'txtPresion
        '
        Me.txtPresion.Location = New System.Drawing.Point(543, 357)
        Me.txtPresion.Name = "txtPresion"
        Me.txtPresion.Size = New System.Drawing.Size(63, 20)
        Me.txtPresion.TabIndex = 514
        '
        'txtPulso
        '
        Me.txtPulso.Location = New System.Drawing.Point(415, 357)
        Me.txtPulso.Name = "txtPulso"
        Me.txtPulso.Size = New System.Drawing.Size(67, 20)
        Me.txtPulso.TabIndex = 513
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(319, 358)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(46, 20)
        Me.txtPeso.TabIndex = 509
        '
        'txtTalla
        '
        Me.txtTalla.Location = New System.Drawing.Point(199, 358)
        Me.txtTalla.Name = "txtTalla"
        Me.txtTalla.Size = New System.Drawing.Size(44, 20)
        Me.txtTalla.TabIndex = 508
        '
        'txtMolestia
        '
        Me.txtMolestia.Location = New System.Drawing.Point(13, 381)
        Me.txtMolestia.Multiline = True
        Me.txtMolestia.Name = "txtMolestia"
        Me.txtMolestia.Size = New System.Drawing.Size(700, 45)
        Me.txtMolestia.TabIndex = 518
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(244, 17)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(62, 20)
        Me.txtHora.TabIndex = 506
        '
        'lblPreliquidacion
        '
        Me.lblPreliquidacion.Location = New System.Drawing.Point(401, 297)
        Me.lblPreliquidacion.Name = "lblPreliquidacion"
        Me.lblPreliquidacion.Size = New System.Drawing.Size(138, 20)
        Me.lblPreliquidacion.TabIndex = 577
        '
        'lblNumeroSIS
        '
        Me.lblNumeroSIS.Location = New System.Drawing.Point(174, 297)
        Me.lblNumeroSIS.Name = "lblNumeroSIS"
        Me.lblNumeroSIS.Size = New System.Drawing.Size(130, 20)
        Me.lblNumeroSIS.TabIndex = 576
        '
        'lblSerieSIS
        '
        Me.lblSerieSIS.Location = New System.Drawing.Point(95, 297)
        Me.lblSerieSIS.Name = "lblSerieSIS"
        Me.lblSerieSIS.Size = New System.Drawing.Size(73, 20)
        Me.lblSerieSIS.TabIndex = 575
        '
        'cboPrioridad
        '
        Me.cboPrioridad.FormattingEnabled = True
        Me.cboPrioridad.Items.AddRange(New Object() {"NINGÚN", "I", "II", "III", "IV"})
        Me.cboPrioridad.Location = New System.Drawing.Point(605, 266)
        Me.cboPrioridad.Name = "cboPrioridad"
        Me.cboPrioridad.Size = New System.Drawing.Size(94, 21)
        Me.cboPrioridad.TabIndex = 590
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(540, 271)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(57, 13)
        Me.Label73.TabIndex = 589
        Me.Label73.Text = "Prioridad"
        '
        'cboArea
        '
        Me.cboArea.FormattingEnabled = True
        Me.cboArea.Items.AddRange(New Object() {"SELECCIONAR", "TOPICO", "OBSERVACION ", "UNIDAD SHOCK TRAUMA"})
        Me.cboArea.Location = New System.Drawing.Point(575, 239)
        Me.cboArea.Name = "cboArea"
        Me.cboArea.Size = New System.Drawing.Size(124, 21)
        Me.cboArea.TabIndex = 588
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(10, 297)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(76, 13)
        Me.Label50.TabIndex = 566
        Me.Label50.Text = "Formato SIS"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(320, 271)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(45, 13)
        Me.Label44.TabIndex = 564
        Me.Label44.Text = "Motivo"
        '
        'cboOrigen
        '
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Items.AddRange(New Object() {"CASA", "REFERENCIA"})
        Me.cboOrigen.Location = New System.Drawing.Point(93, 273)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(211, 21)
        Me.cboOrigen.TabIndex = 563
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(10, 271)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(44, 13)
        Me.Label43.TabIndex = 562
        Me.Label43.Text = "Origen"
        '
        'lblDomicilio
        '
        Me.lblDomicilio.BackColor = System.Drawing.Color.White
        Me.lblDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDomicilio.Location = New System.Drawing.Point(95, 93)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(604, 23)
        Me.lblDomicilio.TabIndex = 561
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Location = New System.Drawing.Point(174, 41)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(298, 23)
        Me.lblPaciente.TabIndex = 560
        '
        'lblEstadoCivil
        '
        Me.lblEstadoCivil.BackColor = System.Drawing.Color.White
        Me.lblEstadoCivil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstadoCivil.Location = New System.Drawing.Point(414, 68)
        Me.lblEstadoCivil.Name = "lblEstadoCivil"
        Me.lblEstadoCivil.Size = New System.Drawing.Size(100, 23)
        Me.lblEstadoCivil.TabIndex = 559
        '
        'lblGrado
        '
        Me.lblGrado.BackColor = System.Drawing.Color.White
        Me.lblGrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGrado.Location = New System.Drawing.Point(95, 67)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(211, 23)
        Me.lblGrado.TabIndex = 558
        '
        'lblProvincia
        '
        Me.lblProvincia.BackColor = System.Drawing.Color.White
        Me.lblProvincia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProvincia.Location = New System.Drawing.Point(403, 151)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(296, 23)
        Me.lblProvincia.TabIndex = 557
        '
        'lblDistrito
        '
        Me.lblDistrito.BackColor = System.Drawing.Color.White
        Me.lblDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDistrito.Location = New System.Drawing.Point(95, 183)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(211, 23)
        Me.lblDistrito.TabIndex = 556
        '
        'lblDpto
        '
        Me.lblDpto.BackColor = System.Drawing.Color.White
        Me.lblDpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDpto.Location = New System.Drawing.Point(95, 154)
        Me.lblDpto.Name = "lblDpto"
        Me.lblDpto.Size = New System.Drawing.Size(211, 23)
        Me.lblDpto.TabIndex = 555
        '
        'lblInformante
        '
        Me.lblInformante.BackColor = System.Drawing.Color.White
        Me.lblInformante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInformante.Location = New System.Drawing.Point(403, 179)
        Me.lblInformante.Name = "lblInformante"
        Me.lblInformante.Size = New System.Drawing.Size(296, 23)
        Me.lblInformante.TabIndex = 554
        '
        'lblIngSer
        '
        Me.lblIngSer.BackColor = System.Drawing.Color.White
        Me.lblIngSer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIngSer.Location = New System.Drawing.Point(403, 235)
        Me.lblIngSer.Name = "lblIngSer"
        Me.lblIngSer.Size = New System.Drawing.Size(130, 23)
        Me.lblIngSer.TabIndex = 553
        '
        'lblIngEsta
        '
        Me.lblIngEsta.BackColor = System.Drawing.Color.White
        Me.lblIngEsta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIngEsta.Location = New System.Drawing.Point(95, 245)
        Me.lblIngEsta.Name = "lblIngEsta"
        Me.lblIngEsta.Size = New System.Drawing.Size(211, 23)
        Me.lblIngEsta.TabIndex = 552
        '
        'lblSexo
        '
        Me.lblSexo.BackColor = System.Drawing.Color.White
        Me.lblSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSexo.Location = New System.Drawing.Point(602, 67)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(97, 23)
        Me.lblSexo.TabIndex = 551
        Me.lblSexo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 548
        Me.Label8.Text = "Edad"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(17, 436)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(114, 13)
        Me.Label42.TabIndex = 547
        Me.Label42.Text = "Enfermedad Actual"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(616, 435)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(15, 13)
        Me.Label39.TabIndex = 546
        Me.Label39.Text = "C"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(413, 432)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(76, 13)
        Me.Label40.TabIndex = 544
        Me.Label40.Text = "Forma Inicio"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(227, 432)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(119, 13)
        Me.Label41.TabIndex = 543
        Me.Label41.Text = "Tiempo Enfermedad"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(319, 242)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(79, 13)
        Me.Label35.TabIndex = 541
        Me.Label35.Text = "Ing. Servicio"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(10, 245)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(78, 13)
        Me.Label34.TabIndex = 540
        Me.Label34.Text = "Tipo Ingreso"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(611, 360)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(63, 13)
        Me.Label30.TabIndex = 539
        Me.Label30.Text = "Temp (°C)"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(492, 360)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 13)
        Me.Label29.TabIndex = 538
        Me.Label29.Text = "Presion"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(10, 216)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 13)
        Me.Label28.TabIndex = 537
        Me.Label28.Text = "Servicio"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(319, 213)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(48, 13)
        Me.Label27.TabIndex = 536
        Me.Label27.Text = "Médico"
        '
        'dtpFechaNcto
        '
        Me.dtpFechaNcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNcto.Location = New System.Drawing.Point(601, 43)
        Me.dtpFechaNcto.Name = "dtpFechaNcto"
        Me.dtpFechaNcto.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaNcto.TabIndex = 511
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(515, 46)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 13)
        Me.Label26.TabIndex = 535
        Me.Label26.Text = "Fecha Ncto."
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 181)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(47, 13)
        Me.Label25.TabIndex = 534
        Me.Label25.Text = "Distrito"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(319, 157)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 13)
        Me.Label24.TabIndex = 533
        Me.Label24.Text = "Provincia"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 532
        Me.Label12.Text = "Departamento"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(375, 361)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 531
        Me.Label16.Text = "Pulso"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(259, 361)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 526
        Me.Label15.Text = "Peso (Kg)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(134, 361)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 530
        Me.Label14.Text = "Talla (cm)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 365)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 529
        Me.Label13.Text = "Molestia Principal"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(311, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 528
        Me.Label11.Text = "Estado Civil"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 527
        Me.Label10.Text = "Domicilio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 525
        Me.Label9.Text = "Grado Inst."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(319, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 522
        Me.Label6.Text = "Informante"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(204, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 520
        Me.Label5.Text = "Hora"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(95, 17)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(105, 20)
        Me.dtpFecha.TabIndex = 505
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 516
        Me.Label3.Text = "Fecha"
        '
        'lblHoraAdmision
        '
        Me.lblHoraAdmision.BackColor = System.Drawing.Color.White
        Me.lblHoraAdmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHoraAdmision.Location = New System.Drawing.Point(602, 16)
        Me.lblHoraAdmision.Name = "lblHoraAdmision"
        Me.lblHoraAdmision.Size = New System.Drawing.Size(100, 23)
        Me.lblHoraAdmision.TabIndex = 515
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(516, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 512
        Me.Label4.Text = "Hora Admisión"
        '
        'lblFechaAdmision
        '
        Me.lblFechaAdmision.BackColor = System.Drawing.Color.White
        Me.lblFechaAdmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFechaAdmision.Location = New System.Drawing.Point(414, 16)
        Me.lblFechaAdmision.Name = "lblFechaAdmision"
        Me.lblFechaAdmision.Size = New System.Drawing.Size(100, 23)
        Me.lblFechaAdmision.TabIndex = 510
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(312, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 507
        Me.Label2.Text = "Fecha Admisión"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 504
        Me.Label1.Text = "Paciente"
        '
        'cboDesOrigen
        '
        Me.cboDesOrigen.FormattingEnabled = True
        Me.cboDesOrigen.Items.AddRange(New Object() {"SELECCIONE", "AGRESION ", "ACCIDENTE DE TRABAJO", "ACCIDENTE DE TRANSITO", "ENVENENAMIENTO", "ENFERMEDAD SÚBITA", "ENFERMEDAD COMÚN", "IGNORADO"})
        Me.cboDesOrigen.Location = New System.Drawing.Point(401, 271)
        Me.cboDesOrigen.Name = "cboDesOrigen"
        Me.cboDesOrigen.Size = New System.Drawing.Size(138, 21)
        Me.cboDesOrigen.TabIndex = 565
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(314, 297)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(87, 13)
        Me.Label51.TabIndex = 567
        Me.Label51.Text = "Preliquidación"
        '
        'lblTEdadD
        '
        Me.lblTEdadD.BackColor = System.Drawing.Color.White
        Me.lblTEdadD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdadD.Location = New System.Drawing.Point(278, 121)
        Me.lblTEdadD.Name = "lblTEdadD"
        Me.lblTEdadD.Size = New System.Drawing.Size(30, 23)
        Me.lblTEdadD.TabIndex = 571
        Me.lblTEdadD.Text = "A"
        Me.lblTEdadD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdadD
        '
        Me.lblEdadD.BackColor = System.Drawing.Color.White
        Me.lblEdadD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdadD.Location = New System.Drawing.Point(241, 121)
        Me.lblEdadD.Name = "lblEdadD"
        Me.lblEdadD.Size = New System.Drawing.Size(30, 23)
        Me.lblEdadD.TabIndex = 570
        Me.lblEdadD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTEdadM
        '
        Me.lblTEdadM.BackColor = System.Drawing.Color.White
        Me.lblTEdadM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdadM.Location = New System.Drawing.Point(205, 121)
        Me.lblTEdadM.Name = "lblTEdadM"
        Me.lblTEdadM.Size = New System.Drawing.Size(30, 23)
        Me.lblTEdadM.TabIndex = 569
        Me.lblTEdadM.Text = "M"
        Me.lblTEdadM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdadM
        '
        Me.lblEdadM.BackColor = System.Drawing.Color.White
        Me.lblEdadM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdadM.Location = New System.Drawing.Point(169, 121)
        Me.lblEdadM.Name = "lblEdadM"
        Me.lblEdadM.Size = New System.Drawing.Size(30, 23)
        Me.lblEdadM.TabIndex = 568
        Me.lblEdadM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTEdad
        '
        Me.lblTEdad.BackColor = System.Drawing.Color.White
        Me.lblTEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTEdad.Location = New System.Drawing.Point(132, 120)
        Me.lblTEdad.Name = "lblTEdad"
        Me.lblTEdad.Size = New System.Drawing.Size(31, 23)
        Me.lblTEdad.TabIndex = 550
        Me.lblTEdad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.White
        Me.lblEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdad.Location = New System.Drawing.Point(95, 120)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(31, 23)
        Me.lblEdad.TabIndex = 549
        Me.lblEdad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(520, 72)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(35, 13)
        Me.Label65.TabIndex = 572
        Me.Label65.Text = "Sexo"
        '
        'btnBuscarP
        '
        Me.btnBuscarP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarP.Location = New System.Drawing.Point(478, 42)
        Me.btnBuscarP.Name = "btnBuscarP"
        Me.btnBuscarP.Size = New System.Drawing.Size(36, 23)
        Me.btnBuscarP.TabIndex = 545
        Me.btnBuscarP.Text = "&B"
        Me.btnBuscarP.UseVisualStyleBackColor = True
        '
        'cboMedIng
        '
        Me.cboMedIng.FormattingEnabled = True
        Me.cboMedIng.Location = New System.Drawing.Point(403, 212)
        Me.cboMedIng.Name = "cboMedIng"
        Me.cboMedIng.Size = New System.Drawing.Size(296, 21)
        Me.cboMedIng.TabIndex = 573
        '
        'cboTipoAten
        '
        Me.cboTipoAten.FormattingEnabled = True
        Me.cboTipoAten.Location = New System.Drawing.Point(401, 123)
        Me.cboTipoAten.Name = "cboTipoAten"
        Me.cboTipoAten.Size = New System.Drawing.Size(298, 21)
        Me.cboTipoAten.TabIndex = 574
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(314, 127)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(86, 13)
        Me.Label36.TabIndex = 542
        Me.Label36.Text = "Tipo Atención"
        '
        'cboTipoAtenEmer
        '
        Me.cboTipoAtenEmer.FormattingEnabled = True
        Me.cboTipoAtenEmer.Items.AddRange(New Object() {"EMERGENCIA", "URGENCIA"})
        Me.cboTipoAtenEmer.Location = New System.Drawing.Point(401, 322)
        Me.cboTipoAtenEmer.Name = "cboTipoAtenEmer"
        Me.cboTipoAtenEmer.Size = New System.Drawing.Size(138, 21)
        Me.cboTipoAtenEmer.TabIndex = 581
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(315, 322)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(86, 13)
        Me.Label69.TabIndex = 580
        Me.Label69.Text = "Tipo Atención"
        '
        'cboTipoIngreso
        '
        Me.cboTipoIngreso.FormattingEnabled = True
        Me.cboTipoIngreso.Items.AddRange(New Object() {"NUEVO", "CONTINUADOR", "REINGRESANTE"})
        Me.cboTipoIngreso.Location = New System.Drawing.Point(94, 322)
        Me.cboTipoIngreso.Name = "cboTipoIngreso"
        Me.cboTipoIngreso.Size = New System.Drawing.Size(139, 21)
        Me.cboTipoIngreso.TabIndex = 579
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(10, 322)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(78, 13)
        Me.Label68.TabIndex = 578
        Me.Label68.Text = "Tipo Ingreso"
        '
        'cboRCP
        '
        Me.cboRCP.FormattingEnabled = True
        Me.cboRCP.Items.AddRange(New Object() {"SI", "NO"})
        Me.cboRCP.Location = New System.Drawing.Point(646, 320)
        Me.cboRCP.Name = "cboRCP"
        Me.cboRCP.Size = New System.Drawing.Size(53, 21)
        Me.cboRCP.TabIndex = 586
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(540, 242)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(33, 13)
        Me.Label72.TabIndex = 585
        Me.Label72.Text = "Area"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(538, 325)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(61, 13)
        Me.Label71.TabIndex = 584
        Me.Label71.Text = "Sala RCP"
        '
        'cboSala
        '
        Me.cboSala.FormattingEnabled = True
        Me.cboSala.Items.AddRange(New Object() {"SI", "NO"})
        Me.cboSala.Location = New System.Drawing.Point(646, 296)
        Me.cboSala.Name = "cboSala"
        Me.cboSala.Size = New System.Drawing.Size(53, 21)
        Me.cboSala.TabIndex = 583
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(538, 300)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(107, 13)
        Me.Label70.TabIndex = 582
        Me.Label70.Text = "Sala Observación"
        '
        'lblServicio
        '
        Me.lblServicio.FormattingEnabled = True
        Me.lblServicio.Location = New System.Drawing.Point(95, 213)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(211, 21)
        Me.lblServicio.TabIndex = 587
        '
        'tbAnamnesis
        '
        Me.tbAnamnesis.Controls.Add(Me.TabPage1)
        Me.tbAnamnesis.Controls.Add(Me.TabPage2)
        Me.tbAnamnesis.Location = New System.Drawing.Point(12, 22)
        Me.tbAnamnesis.Name = "tbAnamnesis"
        Me.tbAnamnesis.SelectedIndex = 0
        Me.tbAnamnesis.Size = New System.Drawing.Size(725, 547)
        Me.tbAnamnesis.TabIndex = 315
        '
        'frmAnamnesis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 610)
        Me.Controls.Add(Me.tbAnamnesis)
        Me.Controls.Add(Me.gbCIE)
        Me.Controls.Add(Me.gbPaciente)
        Me.Controls.Add(Me.gbAD)
        Me.Controls.Add(Me.gbAlta)
        Me.Controls.Add(Me.gbCIEA)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmAnamnesis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anamnesis"
        Me.gbCIE.ResumeLayout(False)
        Me.gbCIE.PerformLayout()
        Me.gbPaciente.ResumeLayout(False)
        Me.gbPaciente.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gbAlta.ResumeLayout(False)
        Me.gbAlta.PerformLayout()
        Me.gbCIEA.ResumeLayout(False)
        Me.gbCIEA.PerformLayout()
        Me.gbLabCE.ResumeLayout(False)
        Me.gbLabCE.PerformLayout()
        Me.gbAD.ResumeLayout(False)
        Me.gbAD.PerformLayout()
        Me.gbSI.ResumeLayout(False)
        Me.gbSI.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.gbTipoAtencion.ResumeLayout(False)
        Me.gbTipoAtencion.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.tbAnamnesis.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents gbCIE As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
    Friend WithEvents lvCIE As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AyudaDiagnósticaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaboratorioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RayosXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EcografíaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatologíaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbAlta As System.Windows.Forms.GroupBox
    Friend WithEvents btnRetornarAlta As System.Windows.Forms.Button
    Friend WithEvents btnAceptarAlta As System.Windows.Forms.Button
    Friend WithEvents txtDesDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents cboTD6A As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab6A As System.Windows.Forms.TextBox
    Friend WithEvents txtDes6A As System.Windows.Forms.TextBox
    Friend WithEvents txtCie6A As System.Windows.Forms.TextBox
    Friend WithEvents cboTD5A As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab5A As System.Windows.Forms.TextBox
    Friend WithEvents txtDes5A As System.Windows.Forms.TextBox
    Friend WithEvents txtCie5A As System.Windows.Forms.TextBox
    Friend WithEvents cboTD4A As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab4A As System.Windows.Forms.TextBox
    Friend WithEvents txtDes4A As System.Windows.Forms.TextBox
    Friend WithEvents txtCie4A As System.Windows.Forms.TextBox
    Friend WithEvents cboTD3A As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab3A As System.Windows.Forms.TextBox
    Friend WithEvents txtDes3A As System.Windows.Forms.TextBox
    Friend WithEvents txtCie3A As System.Windows.Forms.TextBox
    Friend WithEvents cboTD2A As System.Windows.Forms.ComboBox
    Friend WithEvents txtLab2A As System.Windows.Forms.TextBox
    Friend WithEvents txtDes2A As System.Windows.Forms.TextBox
    Friend WithEvents txtCie2A As System.Windows.Forms.TextBox
    Friend WithEvents cboTD1A As System.Windows.Forms.ComboBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents txtLab1A As System.Windows.Forms.TextBox
    Friend WithEvents txtDes1A As System.Windows.Forms.TextBox
    Friend WithEvents txtCie1A As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents cboCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents cboMedico As System.Windows.Forms.ComboBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAlta As System.Windows.Forms.ComboBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents gbCIEA As System.Windows.Forms.GroupBox
    Friend WithEvents lvCIEA As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader37 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader38 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader39 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader40 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader41 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader42 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader43 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader44 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRetornarA As System.Windows.Forms.Button
    Friend WithEvents txtFiltroA As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActoMédicoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotaDeEvoluciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InterconsultaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader45 As System.Windows.Forms.ColumnHeader
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
    Friend WithEvents gbLabCE As System.Windows.Forms.GroupBox
    Friend WithEvents lblPro1 As System.Windows.Forms.Label
    Friend WithEvents btnRetornar01 As System.Windows.Forms.Button
    Friend WithEvents txtRes1 As System.Windows.Forms.TextBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents btnPendiente As System.Windows.Forms.Button
    Friend WithEvents lvSolicitado As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader33 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader35 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader36 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader34 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtProcedimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader48 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader49 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents btnRetornarAD As System.Windows.Forms.Button
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents chkPagoContado As System.Windows.Forms.CheckBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents gbAD As System.Windows.Forms.GroupBox
    Friend WithEvents gbSI As System.Windows.Forms.GroupBox
    Friend WithEvents btnRetornarSI As System.Windows.Forms.Button
    Friend WithEvents lvSI As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader46 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader47 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtCama As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtAntFam As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtAntPat As System.Windows.Forms.TextBox
    Friend WithEvents gbTipoAtencion As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptarTA As System.Windows.Forms.Button
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAtencion As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
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
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtLab1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDes1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCie1 As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtExamenFisico As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtPesoFB As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtSueño As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDeposiciones As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtOrina As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtSed As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtApetito As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents txtEnfermedadAct As System.Windows.Forms.TextBox
    Friend WithEvents txtC As System.Windows.Forms.TextBox
    Friend WithEvents txtFormaInicio As System.Windows.Forms.TextBox
    Friend WithEvents txtTiempoEnf As System.Windows.Forms.TextBox
    Friend WithEvents txtTemperatura As System.Windows.Forms.TextBox
    Friend WithEvents txtPresion As System.Windows.Forms.TextBox
    Friend WithEvents txtPulso As System.Windows.Forms.TextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtTalla As System.Windows.Forms.TextBox
    Friend WithEvents txtMolestia As System.Windows.Forms.TextBox
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents lblPreliquidacion As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroSIS As System.Windows.Forms.TextBox
    Friend WithEvents lblSerieSIS As System.Windows.Forms.TextBox
    Friend WithEvents cboPrioridad As System.Windows.Forms.ComboBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents cboArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents lblDomicilio As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents lblEstadoCivil As System.Windows.Forms.Label
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents lblProvincia As System.Windows.Forms.Label
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents lblDpto As System.Windows.Forms.Label
    Friend WithEvents lblInformante As System.Windows.Forms.Label
    Friend WithEvents lblIngSer As System.Windows.Forms.Label
    Friend WithEvents lblIngEsta As System.Windows.Forms.Label
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaNcto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblHoraAdmision As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFechaAdmision As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDesOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents lblTEdadD As System.Windows.Forms.Label
    Friend WithEvents lblEdadD As System.Windows.Forms.Label
    Friend WithEvents lblTEdadM As System.Windows.Forms.Label
    Friend WithEvents lblEdadM As System.Windows.Forms.Label
    Friend WithEvents lblTEdad As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarP As System.Windows.Forms.Button
    Friend WithEvents cboMedIng As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoAten As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAtenEmer As System.Windows.Forms.ComboBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents cboTipoIngreso As System.Windows.Forms.ComboBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents cboRCP As System.Windows.Forms.ComboBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents cboSala As System.Windows.Forms.ComboBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents lblServicio As System.Windows.Forms.ComboBox
    Friend WithEvents tbAnamnesis As System.Windows.Forms.TabControl
    Friend WithEvents rbDx6 As System.Windows.Forms.RadioButton
    Friend WithEvents rbDx5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbDx4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbDx3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbDx2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbDx1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label74 As System.Windows.Forms.Label
End Class
