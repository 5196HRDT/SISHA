<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignacionCargo
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
        Me.lblTrabajador = New System.Windows.Forms.Label()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.cboServiArea = New System.Windows.Forms.ComboBox()
        Me.cboDptoUnidad = New System.Windows.Forms.ComboBox()
        Me.lblServArea = New System.Windows.Forms.Label()
        Me.lblDptoUnidad = New System.Windows.Forms.Label()
        Me.lblFiltro = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboCargo = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lvTrabajador = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtTrabajador = New System.Windows.Forms.TextBox()
        Me.chbxActivo = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lblTrabajador
        '
        Me.lblTrabajador.AutoSize = True
        Me.lblTrabajador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrabajador.Location = New System.Drawing.Point(16, 16)
        Me.lblTrabajador.Name = "lblTrabajador"
        Me.lblTrabajador.Size = New System.Drawing.Size(68, 13)
        Me.lblTrabajador.TabIndex = 0
        Me.lblTrabajador.Text = "Trabajador"
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCargo.Location = New System.Drawing.Point(17, 97)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(40, 13)
        Me.lblCargo.TabIndex = 1
        Me.lblCargo.Text = "Cargo"
        '
        'cboServiArea
        '
        Me.cboServiArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiArea.FormattingEnabled = True
        Me.cboServiArea.Location = New System.Drawing.Point(101, 66)
        Me.cboServiArea.Name = "cboServiArea"
        Me.cboServiArea.Size = New System.Drawing.Size(500, 21)
        Me.cboServiArea.TabIndex = 75
        '
        'cboDptoUnidad
        '
        Me.cboDptoUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDptoUnidad.FormattingEnabled = True
        Me.cboDptoUnidad.Location = New System.Drawing.Point(101, 39)
        Me.cboDptoUnidad.Name = "cboDptoUnidad"
        Me.cboDptoUnidad.Size = New System.Drawing.Size(500, 21)
        Me.cboDptoUnidad.TabIndex = 74
        '
        'lblServArea
        '
        Me.lblServArea.AutoSize = True
        Me.lblServArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServArea.Location = New System.Drawing.Point(16, 70)
        Me.lblServArea.Name = "lblServArea"
        Me.lblServArea.Size = New System.Drawing.Size(65, 13)
        Me.lblServArea.TabIndex = 77
        Me.lblServArea.Text = "Serv/Area"
        '
        'lblDptoUnidad
        '
        Me.lblDptoUnidad.AutoSize = True
        Me.lblDptoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDptoUnidad.Location = New System.Drawing.Point(16, 43)
        Me.lblDptoUnidad.Name = "lblDptoUnidad"
        Me.lblDptoUnidad.Size = New System.Drawing.Size(80, 13)
        Me.lblDptoUnidad.TabIndex = 76
        Me.lblDptoUnidad.Text = "Dpto/Unidad"
        '
        'lblFiltro
        '
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltro.Location = New System.Drawing.Point(15, 173)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(35, 13)
        Me.lblFiltro.TabIndex = 80
        Me.lblFiltro.Text = "Filtro"
        '
        'txtFiltro
        '
        Me.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltro.Location = New System.Drawing.Point(100, 170)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(293, 20)
        Me.txtFiltro.TabIndex = 78
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader8, Me.ColumnHeader2, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader14})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(18, 201)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(583, 246)
        Me.lvTabla.TabIndex = 79
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IdAsignacionCargo"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "IdTrabajador"
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "IdServiArea"
        Me.ColumnHeader12.Width = 0
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "IdCargo"
        Me.ColumnHeader13.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Nombres"
        Me.ColumnHeader8.Width = 250
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Dpto/Unidad"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Serv/Area"
        Me.ColumnHeader9.Width = 200
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Cargo"
        Me.ColumnHeader10.Width = 200
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Activo"
        '
        'cboCargo
        '
        Me.cboCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCargo.FormattingEnabled = True
        Me.cboCargo.Location = New System.Drawing.Point(102, 93)
        Me.cboCargo.Name = "cboCargo"
        Me.cboCargo.Size = New System.Drawing.Size(500, 21)
        Me.cboCargo.TabIndex = 81
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(313, 456)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(65, 23)
        Me.btnCancelar.TabIndex = 85
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(384, 456)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(65, 23)
        Me.btnCerrar.TabIndex = 86
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(242, 456)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(65, 23)
        Me.btnGrabar.TabIndex = 84
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(171, 456)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(65, 23)
        Me.btnNuevo.TabIndex = 83
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.Location = New System.Drawing.Point(537, 129)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(65, 23)
        Me.btnQuitar.TabIndex = 88
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(466, 129)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(65, 23)
        Me.btnAgregar.TabIndex = 87
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lvTrabajador
        '
        Me.lvTrabajador.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvTrabajador.FullRowSelect = True
        Me.lvTrabajador.GridLines = True
        Me.lvTrabajador.Location = New System.Drawing.Point(19, 39)
        Me.lvTrabajador.Name = "lvTrabajador"
        Me.lvTrabajador.Size = New System.Drawing.Size(583, 84)
        Me.lvTrabajador.TabIndex = 89
        Me.lvTrabajador.UseCompatibleStateImageBehavior = False
        Me.lvTrabajador.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "IdTrabajador"
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Nombre"
        Me.ColumnHeader4.Width = 345
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Iniciales"
        Me.ColumnHeader5.Width = 70
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "DNI"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Activo"
        '
        'txtTrabajador
        '
        Me.txtTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTrabajador.Location = New System.Drawing.Point(100, 13)
        Me.txtTrabajador.Name = "txtTrabajador"
        Me.txtTrabajador.Size = New System.Drawing.Size(347, 20)
        Me.txtTrabajador.TabIndex = 90
        '
        'chbxActivo
        '
        Me.chbxActivo.AutoSize = True
        Me.chbxActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxActivo.Location = New System.Drawing.Point(537, 15)
        Me.chbxActivo.Name = "chbxActivo"
        Me.chbxActivo.Size = New System.Drawing.Size(62, 17)
        Me.chbxActivo.TabIndex = 91
        Me.chbxActivo.Text = "Activo"
        Me.chbxActivo.UseVisualStyleBackColor = True
        '
        'frmAsignacionCargo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 488)
        Me.Controls.Add(Me.chbxActivo)
        Me.Controls.Add(Me.lvTrabajador)
        Me.Controls.Add(Me.txtTrabajador)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.cboCargo)
        Me.Controls.Add(Me.lblFiltro)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.lvTabla)
        Me.Controls.Add(Me.cboServiArea)
        Me.Controls.Add(Me.cboDptoUnidad)
        Me.Controls.Add(Me.lblServArea)
        Me.Controls.Add(Me.lblDptoUnidad)
        Me.Controls.Add(Me.lblCargo)
        Me.Controls.Add(Me.lblTrabajador)
        Me.MaximizeBox = False
        Me.Name = "frmAsignacionCargo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Cargo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTrabajador As System.Windows.Forms.Label
    Friend WithEvents lblCargo As System.Windows.Forms.Label
    Friend WithEvents cboServiArea As System.Windows.Forms.ComboBox
    Friend WithEvents cboDptoUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents lblServArea As System.Windows.Forms.Label
    Friend WithEvents lblDptoUnidad As System.Windows.Forms.Label
    Friend WithEvents lblFiltro As System.Windows.Forms.Label
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboCargo As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lvTrabajador As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chbxActivo As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
End Class
