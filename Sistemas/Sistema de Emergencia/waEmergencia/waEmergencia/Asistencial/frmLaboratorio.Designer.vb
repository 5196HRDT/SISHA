<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaboratorio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLaboratorio))
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
        Me.Label158 = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.Label135 = New System.Windows.Forms.Label()
        Me.Label157 = New System.Windows.Forms.Label()
        Me.lblDistrito = New System.Windows.Forms.Label()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.lblDpto = New System.Windows.Forms.Label()
        Me.btnBuscarP = New System.Windows.Forms.Button()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.lblFNac = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.Label159 = New System.Windows.Forms.Label()
        Me.lvHistorial = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lvCE = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnImprimirCE = New System.Windows.Forms.Button()
        Me.btnQR1 = New System.Windows.Forms.Button()
        Me.btnQR2 = New System.Windows.Forms.Button()
        Me.gbQR = New System.Windows.Forms.GroupBox()
        Me.imgQR = New System.Windows.Forms.PictureBox()
        Me.btnRetornarQR = New System.Windows.Forms.Button()
        Me.Label195 = New System.Windows.Forms.Label()
        Me.gbLabCE = New System.Windows.Forms.GroupBox()
        Me.lblPro1 = New System.Windows.Forms.Label()
        Me.btnRetornar01 = New System.Windows.Forms.Button()
        Me.txtRes1 = New System.Windows.Forms.TextBox()
        Me.gbLabConsulta = New System.Windows.Forms.GroupBox()
        Me.lblPro2 = New System.Windows.Forms.Label()
        Me.btnRetornar02 = New System.Windows.Forms.Button()
        Me.txtRes2 = New System.Windows.Forms.TextBox()
        Me.gbPaciente.SuspendLayout()
        Me.gbQR.SuspendLayout()
        CType(Me.imgQR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLabCE.SuspendLayout()
        Me.gbLabConsulta.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPaciente
        '
        Me.gbPaciente.Controls.Add(Me.Label53)
        Me.gbPaciente.Controls.Add(Me.btnRetornarP)
        Me.gbPaciente.Controls.Add(Me.lvPaciente)
        Me.gbPaciente.Controls.Add(Me.txtPaciente)
        Me.gbPaciente.Controls.Add(Me.Label54)
        Me.gbPaciente.Location = New System.Drawing.Point(12, 92)
        Me.gbPaciente.Name = "gbPaciente"
        Me.gbPaciente.Size = New System.Drawing.Size(702, 279)
        Me.gbPaciente.TabIndex = 196
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
        'Label158
        '
        Me.Label158.AutoSize = True
        Me.Label158.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label158.Location = New System.Drawing.Point(607, 29)
        Me.Label158.Name = "Label158"
        Me.Label158.Size = New System.Drawing.Size(37, 13)
        Me.Label158.TabIndex = 194
        Me.Label158.Text = "Prov."
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.White
        Me.lblEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.Location = New System.Drawing.Point(484, 26)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(70, 22)
        Me.lblEdad.TabIndex = 185
        '
        'Label137
        '
        Me.Label137.AutoSize = True
        Me.Label137.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label137.Location = New System.Drawing.Point(393, 9)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(37, 13)
        Me.Label137.TabIndex = 186
        Me.Label137.Text = "FNac"
        '
        'Label135
        '
        Me.Label135.AutoSize = True
        Me.Label135.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label135.Location = New System.Drawing.Point(543, 9)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(35, 13)
        Me.Label135.TabIndex = 182
        Me.Label135.Text = "Sexo"
        '
        'Label157
        '
        Me.Label157.AutoSize = True
        Me.Label157.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label157.Location = New System.Drawing.Point(607, 7)
        Me.Label157.Name = "Label157"
        Me.Label157.Size = New System.Drawing.Size(34, 13)
        Me.Label157.TabIndex = 193
        Me.Label157.Text = "Dpto"
        '
        'lblDistrito
        '
        Me.lblDistrito.BackColor = System.Drawing.Color.White
        Me.lblDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDistrito.Location = New System.Drawing.Point(666, 51)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(224, 23)
        Me.lblDistrito.TabIndex = 192
        '
        'lblProvincia
        '
        Me.lblProvincia.BackColor = System.Drawing.Color.White
        Me.lblProvincia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProvincia.Location = New System.Drawing.Point(666, 26)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(224, 23)
        Me.lblProvincia.TabIndex = 191
        '
        'lblDpto
        '
        Me.lblDpto.BackColor = System.Drawing.Color.White
        Me.lblDpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDpto.Location = New System.Drawing.Point(666, 1)
        Me.lblDpto.Name = "lblDpto"
        Me.lblDpto.Size = New System.Drawing.Size(224, 23)
        Me.lblDpto.TabIndex = 190
        '
        'btnBuscarP
        '
        Me.btnBuscarP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarP.Location = New System.Drawing.Point(354, 24)
        Me.btnBuscarP.Name = "btnBuscarP"
        Me.btnBuscarP.Size = New System.Drawing.Size(36, 23)
        Me.btnBuscarP.TabIndex = 189
        Me.btnBuscarP.Text = "&B"
        Me.btnBuscarP.UseVisualStyleBackColor = True
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaciente.Location = New System.Drawing.Point(98, 26)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(250, 22)
        Me.lblPaciente.TabIndex = 181
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(19, 26)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(73, 20)
        Me.txtHistoria.TabIndex = 0
        '
        'lblFNac
        '
        Me.lblFNac.BackColor = System.Drawing.Color.White
        Me.lblFNac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFNac.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFNac.Location = New System.Drawing.Point(396, 26)
        Me.lblFNac.Name = "lblFNac"
        Me.lblFNac.Size = New System.Drawing.Size(82, 22)
        Me.lblFNac.TabIndex = 187
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(98, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "Paciente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "Historia"
        '
        'Label136
        '
        Me.Label136.AutoSize = True
        Me.Label136.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label136.Location = New System.Drawing.Point(496, 9)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(36, 13)
        Me.Label136.TabIndex = 184
        Me.Label136.Text = "Edad"
        '
        'lblSexo
        '
        Me.lblSexo.BackColor = System.Drawing.Color.White
        Me.lblSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSexo.Location = New System.Drawing.Point(555, 26)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(23, 22)
        Me.lblSexo.TabIndex = 183
        '
        'Label159
        '
        Me.Label159.AutoSize = True
        Me.Label159.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label159.Location = New System.Drawing.Point(607, 52)
        Me.Label159.Name = "Label159"
        Me.Label159.Size = New System.Drawing.Size(33, 13)
        Me.Label159.TabIndex = 195
        Me.Label159.Text = "Dist."
        '
        'lvHistorial
        '
        Me.lvHistorial.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader1})
        Me.lvHistorial.FullRowSelect = True
        Me.lvHistorial.GridLines = True
        Me.lvHistorial.Location = New System.Drawing.Point(19, 96)
        Me.lvHistorial.Name = "lvHistorial"
        Me.lvHistorial.Size = New System.Drawing.Size(882, 293)
        Me.lvHistorial.TabIndex = 197
        Me.lvHistorial.UseCompatibleStateImageBehavior = False
        Me.lvHistorial.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Id"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Servicio"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Historia"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Paciente"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Tipo"
        Me.ColumnHeader11.Width = 80
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Procedimiento"
        Me.ColumnHeader12.Width = 300
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Resultado"
        Me.ColumnHeader13.Width = 300
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "FechaMuestra"
        Me.ColumnHeader14.Width = 80
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "FechaRes"
        Me.ColumnHeader15.Width = 80
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "HoraRes"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Parametros"
        Me.ColumnHeader1.Width = 200
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
        'pdcDocumento
        '
        Me.pdcDocumento.DocumentName = "Preliquidacion"
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.pdcDocumento
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(19, 47)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 198
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(100, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(309, 13)
        Me.Label3.TabIndex = 199
        Me.Label3.Text = "RESULTADOS DE LABORATORIO DE EMERGENCIA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(108, 411)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(356, 13)
        Me.Label4.TabIndex = 200
        Me.Label4.Text = "RESULTADOS DE LABORATORIO DE CONSULTA EXTERNA"
        '
        'lvCE
        '
        Me.lvCE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22})
        Me.lvCE.FullRowSelect = True
        Me.lvCE.GridLines = True
        Me.lvCE.Location = New System.Drawing.Point(13, 443)
        Me.lvCE.Name = "lvCE"
        Me.lvCE.Size = New System.Drawing.Size(882, 239)
        Me.lvCE.TabIndex = 201
        Me.lvCE.UseCompatibleStateImageBehavior = False
        Me.lvCE.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Id"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Servicio"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Historia"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Paciente"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Tipo"
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Procedimiento"
        Me.ColumnHeader17.Width = 300
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Resultado"
        Me.ColumnHeader18.Width = 300
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "FechaMuestra"
        Me.ColumnHeader19.Width = 80
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "FechaRes"
        Me.ColumnHeader20.Width = 80
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "HoraRes"
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Parametros"
        Me.ColumnHeader22.Width = 200
        '
        'btnImprimirCE
        '
        Me.btnImprimirCE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirCE.Location = New System.Drawing.Point(19, 411)
        Me.btnImprimirCE.Name = "btnImprimirCE"
        Me.btnImprimirCE.Size = New System.Drawing.Size(75, 26)
        Me.btnImprimirCE.TabIndex = 202
        Me.btnImprimirCE.Text = "&Imprimir"
        Me.btnImprimirCE.UseVisualStyleBackColor = True
        '
        'btnQR1
        '
        Me.btnQR1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQR1.Location = New System.Drawing.Point(470, 52)
        Me.btnQR1.Name = "btnQR1"
        Me.btnQR1.Size = New System.Drawing.Size(42, 23)
        Me.btnQR1.TabIndex = 203
        Me.btnQR1.Text = "QR"
        Me.btnQR1.UseVisualStyleBackColor = True
        '
        'btnQR2
        '
        Me.btnQR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQR2.Location = New System.Drawing.Point(470, 413)
        Me.btnQR2.Name = "btnQR2"
        Me.btnQR2.Size = New System.Drawing.Size(42, 23)
        Me.btnQR2.TabIndex = 204
        Me.btnQR2.Text = "QR"
        Me.btnQR2.UseVisualStyleBackColor = True
        '
        'gbQR
        '
        Me.gbQR.Controls.Add(Me.imgQR)
        Me.gbQR.Controls.Add(Me.btnRetornarQR)
        Me.gbQR.Location = New System.Drawing.Point(895, 57)
        Me.gbQR.Name = "gbQR"
        Me.gbQR.Size = New System.Drawing.Size(898, 681)
        Me.gbQR.TabIndex = 102
        Me.gbQR.TabStop = False
        '
        'imgQR
        '
        Me.imgQR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.imgQR.BackColor = System.Drawing.Color.White
        Me.imgQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgQR.Location = New System.Drawing.Point(3, 11)
        Me.imgQR.Name = "imgQR"
        Me.imgQR.Size = New System.Drawing.Size(889, 641)
        Me.imgQR.TabIndex = 206
        Me.imgQR.TabStop = False
        '
        'btnRetornarQR
        '
        Me.btnRetornarQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetornarQR.Location = New System.Drawing.Point(411, 658)
        Me.btnRetornarQR.Name = "btnRetornarQR"
        Me.btnRetornarQR.Size = New System.Drawing.Size(75, 23)
        Me.btnRetornarQR.TabIndex = 207
        Me.btnRetornarQR.Text = "&Retornar"
        Me.btnRetornarQR.UseVisualStyleBackColor = True
        '
        'Label195
        '
        Me.Label195.AutoSize = True
        Me.Label195.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label195.ForeColor = System.Drawing.Color.Red
        Me.Label195.Location = New System.Drawing.Point(607, 80)
        Me.Label195.Name = "Label195"
        Me.Label195.Size = New System.Drawing.Size(282, 13)
        Me.Label195.TabIndex = 205
        Me.Label195.Text = "Doble Clic para visualizar el Resultado Completo"
        '
        'gbLabCE
        '
        Me.gbLabCE.Controls.Add(Me.lblPro1)
        Me.gbLabCE.Controls.Add(Me.btnRetornar01)
        Me.gbLabCE.Controls.Add(Me.txtRes1)
        Me.gbLabCE.Location = New System.Drawing.Point(228, 73)
        Me.gbLabCE.Name = "gbLabCE"
        Me.gbLabCE.Size = New System.Drawing.Size(441, 174)
        Me.gbLabCE.TabIndex = 206
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
        'gbLabConsulta
        '
        Me.gbLabConsulta.Controls.Add(Me.lblPro2)
        Me.gbLabConsulta.Controls.Add(Me.btnRetornar02)
        Me.gbLabConsulta.Controls.Add(Me.txtRes2)
        Me.gbLabConsulta.Location = New System.Drawing.Point(234, 443)
        Me.gbLabConsulta.Name = "gbLabConsulta"
        Me.gbLabConsulta.Size = New System.Drawing.Size(441, 174)
        Me.gbLabConsulta.TabIndex = 207
        Me.gbLabConsulta.TabStop = False
        '
        'lblPro2
        '
        Me.lblPro2.BackColor = System.Drawing.Color.White
        Me.lblPro2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPro2.Location = New System.Drawing.Point(6, 16)
        Me.lblPro2.Name = "lblPro2"
        Me.lblPro2.Size = New System.Drawing.Size(429, 25)
        Me.lblPro2.TabIndex = 19
        '
        'btnRetornar02
        '
        Me.btnRetornar02.Location = New System.Drawing.Point(185, 145)
        Me.btnRetornar02.Name = "btnRetornar02"
        Me.btnRetornar02.Size = New System.Drawing.Size(75, 23)
        Me.btnRetornar02.TabIndex = 1
        Me.btnRetornar02.Text = "&Retornar"
        Me.btnRetornar02.UseVisualStyleBackColor = True
        '
        'txtRes2
        '
        Me.txtRes2.Location = New System.Drawing.Point(6, 44)
        Me.txtRes2.Multiline = True
        Me.txtRes2.Name = "txtRes2"
        Me.txtRes2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRes2.Size = New System.Drawing.Size(429, 95)
        Me.txtRes2.TabIndex = 0
        '
        'frmLaboratorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 691)
        Me.Controls.Add(Me.gbQR)
        Me.Controls.Add(Me.gbLabConsulta)
        Me.Controls.Add(Me.gbLabCE)
        Me.Controls.Add(Me.btnQR2)
        Me.Controls.Add(Me.btnQR1)
        Me.Controls.Add(Me.lvCE)
        Me.Controls.Add(Me.gbPaciente)
        Me.Controls.Add(Me.Label158)
        Me.Controls.Add(Me.lblEdad)
        Me.Controls.Add(Me.Label137)
        Me.Controls.Add(Me.Label135)
        Me.Controls.Add(Me.Label157)
        Me.Controls.Add(Me.lblDistrito)
        Me.Controls.Add(Me.lblProvincia)
        Me.Controls.Add(Me.lblDpto)
        Me.Controls.Add(Me.btnBuscarP)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.lblFNac)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label136)
        Me.Controls.Add(Me.lblSexo)
        Me.Controls.Add(Me.Label159)
        Me.Controls.Add(Me.lvHistorial)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnImprimirCE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label195)
        Me.Name = "frmLaboratorio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resultados de Laboratorio Clínico"
        Me.gbPaciente.ResumeLayout(False)
        Me.gbPaciente.PerformLayout()
        Me.gbQR.ResumeLayout(False)
        CType(Me.imgQR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLabCE.ResumeLayout(False)
        Me.gbLabCE.PerformLayout()
        Me.gbLabConsulta.ResumeLayout(False)
        Me.gbLabConsulta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Label158 As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents lblProvincia As System.Windows.Forms.Label
    Friend WithEvents lblDpto As System.Windows.Forms.Label
    Friend WithEvents btnBuscarP As System.Windows.Forms.Button
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents lblFNac As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents lvHistorial As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lvCE As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnImprimirCE As System.Windows.Forms.Button
    Friend WithEvents btnQR1 As System.Windows.Forms.Button
    Friend WithEvents btnQR2 As System.Windows.Forms.Button
    Friend WithEvents gbQR As System.Windows.Forms.GroupBox
    Friend WithEvents imgQR As System.Windows.Forms.PictureBox
    Friend WithEvents btnRetornarQR As System.Windows.Forms.Button
    Friend WithEvents Label195 As System.Windows.Forms.Label
    Friend WithEvents gbLabCE As System.Windows.Forms.GroupBox
    Friend WithEvents lblPro1 As System.Windows.Forms.Label
    Friend WithEvents btnRetornar01 As System.Windows.Forms.Button
    Friend WithEvents txtRes1 As System.Windows.Forms.TextBox
    Friend WithEvents gbLabConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents lblPro2 As System.Windows.Forms.Label
    Friend WithEvents btnRetornar02 As System.Windows.Forms.Button
    Friend WithEvents txtRes2 As System.Windows.Forms.TextBox
End Class
