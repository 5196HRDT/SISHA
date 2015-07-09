<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentoExt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentoExt))
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New System.Windows.Forms.ComboBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Imagen = New System.Windows.Forms.PictureBox()
        Me.lblAño = New System.Windows.Forms.Label()
        Me.txtD1 = New System.Windows.Forms.TextBox()
        Me.txtD2 = New System.Windows.Forms.TextBox()
        Me.lblA = New System.Windows.Forms.Label()
        Me.cboTrabajador = New System.Windows.Forms.ComboBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lvMotivo = New System.Windows.Forms.ListView()
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboMotivoPase = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCC = New System.Windows.Forms.TextBox()
        Me.lvCC = New System.Windows.Forms.ListView()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtReferencia
        '
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Location = New System.Drawing.Point(186, 258)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(484, 20)
        Me.txtReferencia.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 258)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Referencia"
        '
        'txtAsunto
        '
        Me.txtAsunto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAsunto.Location = New System.Drawing.Point(186, 232)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(484, 20)
        Me.txtAsunto.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Asunto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "A"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "DE"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.FormattingEnabled = True
        Me.cboTipoDoc.Location = New System.Drawing.Point(10, 109)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(170, 21)
        Me.cboTipoDoc.TabIndex = 1
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(563, 80)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(218, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Gerencia de Salud"
        '
        'Imagen
        '
        Me.Imagen.ErrorImage = CType(resources.GetObject("Imagen.ErrorImage"), System.Drawing.Image)
        Me.Imagen.Image = CType(resources.GetObject("Imagen.Image"), System.Drawing.Image)
        Me.Imagen.InitialImage = CType(resources.GetObject("Imagen.InitialImage"), System.Drawing.Image)
        Me.Imagen.Location = New System.Drawing.Point(18, 12)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(75, 78)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen.TabIndex = 39
        Me.Imagen.TabStop = False
        '
        'lblAño
        '
        Me.lblAño.BackColor = System.Drawing.Color.Transparent
        Me.lblAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAño.Location = New System.Drawing.Point(99, 9)
        Me.lblAño.Name = "lblAño"
        Me.lblAño.Size = New System.Drawing.Size(682, 68)
        Me.lblAño.TabIndex = 36
        Me.lblAño.Text = """ AÑO DE LA UNION NACIONAL FRENTE A LA CRISIS EXTERNA"""
        Me.lblAño.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtD1
        '
        Me.txtD1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtD1.Location = New System.Drawing.Point(186, 135)
        Me.txtD1.Name = "txtD1"
        Me.txtD1.Size = New System.Drawing.Size(484, 20)
        Me.txtD1.TabIndex = 3
        '
        'txtD2
        '
        Me.txtD2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtD2.Location = New System.Drawing.Point(186, 161)
        Me.txtD2.Name = "txtD2"
        Me.txtD2.Size = New System.Drawing.Size(484, 20)
        Me.txtD2.TabIndex = 4
        '
        'lblA
        '
        Me.lblA.BackColor = System.Drawing.Color.AliceBlue
        Me.lblA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblA.Location = New System.Drawing.Point(186, 208)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(484, 18)
        Me.lblA.TabIndex = 6
        Me.lblA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTrabajador
        '
        Me.cboTrabajador.BackColor = System.Drawing.Color.AliceBlue
        Me.cboTrabajador.FormattingEnabled = True
        Me.cboTrabajador.Location = New System.Drawing.Point(186, 184)
        Me.cboTrabajador.Name = "cboTrabajador"
        Me.cboTrabajador.Size = New System.Drawing.Size(484, 21)
        Me.cboTrabajador.TabIndex = 5
        '
        'txtNumero
        '
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Location = New System.Drawing.Point(186, 110)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(484, 20)
        Me.txtNumero.TabIndex = 2
        '
        'lvMotivo
        '
        Me.lvMotivo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader13})
        Me.lvMotivo.FullRowSelect = True
        Me.lvMotivo.GridLines = True
        Me.lvMotivo.Location = New System.Drawing.Point(186, 415)
        Me.lvMotivo.Name = "lvMotivo"
        Me.lvMotivo.Size = New System.Drawing.Size(484, 73)
        Me.lvMotivo.TabIndex = 12
        Me.lvMotivo.UseCompatibleStateImageBehavior = False
        Me.lvMotivo.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Motivo Pase"
        Me.ColumnHeader12.Width = 472
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "IdMotivo"
        '
        'cboMotivoPase
        '
        Me.cboMotivoPase.FormattingEnabled = True
        Me.cboMotivoPase.Location = New System.Drawing.Point(186, 388)
        Me.cboMotivoPase.Name = "cboMotivoPase"
        Me.cboMotivoPase.Size = New System.Drawing.Size(484, 21)
        Me.cboMotivoPase.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 388)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Motivo de Pase"
        '
        'txtCC
        '
        Me.txtCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCC.Location = New System.Drawing.Point(186, 284)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(484, 20)
        Me.txtCC.TabIndex = 9
        '
        'lvCC
        '
        Me.lvCC.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11})
        Me.lvCC.FullRowSelect = True
        Me.lvCC.GridLines = True
        Me.lvCC.Location = New System.Drawing.Point(186, 310)
        Me.lvCC.Name = "lvCC"
        Me.lvCC.Size = New System.Drawing.Size(484, 72)
        Me.lvCC.TabIndex = 10
        Me.lvCC.UseCompatibleStateImageBehavior = False
        Me.lvCC.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Con Copia"
        Me.ColumnHeader11.Width = 472
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 291)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Con Copia"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(186, 507)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 13
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(325, 507)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 14
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(464, 507)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(595, 507)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 16
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'frmDocumentoExt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 542)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.lvMotivo)
        Me.Controls.Add(Me.cboMotivoPase)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCC)
        Me.Controls.Add(Me.lvCC)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.lblA)
        Me.Controls.Add(Me.cboTrabajador)
        Me.Controls.Add(Me.txtD2)
        Me.Controls.Add(Me.txtD1)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAsunto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Imagen)
        Me.Controls.Add(Me.lblAño)
        Me.Name = "frmDocumentoExt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recepcion de Documento Externo"
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents lblAño As System.Windows.Forms.Label
    Friend WithEvents txtD1 As System.Windows.Forms.TextBox
    Friend WithEvents txtD2 As System.Windows.Forms.TextBox
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents cboTrabajador As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents lvMotivo As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboMotivoPase As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCC As System.Windows.Forms.TextBox
    Friend WithEvents lvCC As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
End Class
