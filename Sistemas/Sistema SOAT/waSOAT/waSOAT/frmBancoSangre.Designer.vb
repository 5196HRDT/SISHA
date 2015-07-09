<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancoSangre
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
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblServicio = New System.Windows.Forms.Label()
        Me.lblMedico = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblPrestamoS = New System.Windows.Forms.Label()
        Me.lblDevolucionS = New System.Windows.Forms.Label()
        Me.lblSaldoS = New System.Windows.Forms.Label()
        Me.lblSaldoP = New System.Windows.Forms.Label()
        Me.lblDevolucionP = New System.Windows.Forms.Label()
        Me.lblPrestamoP = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblSaldoQ = New System.Windows.Forms.Label()
        Me.lblDevolucionQ = New System.Windows.Forms.Label()
        Me.lblPrestamoQ = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Origen"
        '
        'cboOrigen
        '
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Items.AddRange(New Object() {"HOSPITALIZACION", "EMERGENCIA"})
        Me.cboOrigen.Location = New System.Drawing.Point(100, 6)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(220, 21)
        Me.cboOrigen.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nro Historia"
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(100, 42)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(100, 20)
        Me.txtHistoria.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Paciente"
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Location = New System.Drawing.Point(100, 69)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(412, 23)
        Me.lblPaciente.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Departamento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Servicio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Medico"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.BackColor = System.Drawing.Color.White
        Me.lblDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDepartamento.Location = New System.Drawing.Point(100, 105)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(412, 23)
        Me.lblDepartamento.TabIndex = 9
        '
        'lblServicio
        '
        Me.lblServicio.BackColor = System.Drawing.Color.White
        Me.lblServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblServicio.Location = New System.Drawing.Point(100, 136)
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Size = New System.Drawing.Size(412, 23)
        Me.lblServicio.TabIndex = 10
        '
        'lblMedico
        '
        Me.lblMedico.BackColor = System.Drawing.Color.White
        Me.lblMedico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedico.Location = New System.Drawing.Point(100, 165)
        Me.lblMedico.Name = "lblMedico"
        Me.lblMedico.Size = New System.Drawing.Size(412, 23)
        Me.lblMedico.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Unidad de Sangre"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 278)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Unidad de Plásma"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(159, 209)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Préstamo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(255, 209)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Devolución"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(393, 209)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Saldo"
        '
        'lblPrestamoS
        '
        Me.lblPrestamoS.BackColor = System.Drawing.Color.White
        Me.lblPrestamoS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrestamoS.Location = New System.Drawing.Point(162, 233)
        Me.lblPrestamoS.Name = "lblPrestamoS"
        Me.lblPrestamoS.Size = New System.Drawing.Size(66, 23)
        Me.lblPrestamoS.TabIndex = 17
        '
        'lblDevolucionS
        '
        Me.lblDevolucionS.BackColor = System.Drawing.Color.White
        Me.lblDevolucionS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDevolucionS.Location = New System.Drawing.Point(254, 233)
        Me.lblDevolucionS.Name = "lblDevolucionS"
        Me.lblDevolucionS.Size = New System.Drawing.Size(66, 23)
        Me.lblDevolucionS.TabIndex = 18
        '
        'lblSaldoS
        '
        Me.lblSaldoS.BackColor = System.Drawing.Color.White
        Me.lblSaldoS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSaldoS.Location = New System.Drawing.Point(379, 232)
        Me.lblSaldoS.Name = "lblSaldoS"
        Me.lblSaldoS.Size = New System.Drawing.Size(66, 23)
        Me.lblSaldoS.TabIndex = 19
        '
        'lblSaldoP
        '
        Me.lblSaldoP.BackColor = System.Drawing.Color.White
        Me.lblSaldoP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSaldoP.Location = New System.Drawing.Point(379, 267)
        Me.lblSaldoP.Name = "lblSaldoP"
        Me.lblSaldoP.Size = New System.Drawing.Size(66, 23)
        Me.lblSaldoP.TabIndex = 22
        '
        'lblDevolucionP
        '
        Me.lblDevolucionP.BackColor = System.Drawing.Color.White
        Me.lblDevolucionP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDevolucionP.Location = New System.Drawing.Point(254, 268)
        Me.lblDevolucionP.Name = "lblDevolucionP"
        Me.lblDevolucionP.Size = New System.Drawing.Size(66, 23)
        Me.lblDevolucionP.TabIndex = 21
        '
        'lblPrestamoP
        '
        Me.lblPrestamoP.BackColor = System.Drawing.Color.White
        Me.lblPrestamoP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrestamoP.Location = New System.Drawing.Point(162, 268)
        Me.lblPrestamoP.Name = "lblPrestamoP"
        Me.lblPrestamoP.Size = New System.Drawing.Size(66, 23)
        Me.lblPrestamoP.TabIndex = 20
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 371)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Observaciones"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.BackColor = System.Drawing.Color.White
        Me.lblObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblObservaciones.Location = New System.Drawing.Point(114, 370)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(398, 23)
        Me.lblObservaciones.TabIndex = 24
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(62, 420)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 25
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(336, 420)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 26
        Me.btnCerrar.Text = "C&errar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblSaldoQ
        '
        Me.lblSaldoQ.BackColor = System.Drawing.Color.White
        Me.lblSaldoQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSaldoQ.Location = New System.Drawing.Point(379, 303)
        Me.lblSaldoQ.Name = "lblSaldoQ"
        Me.lblSaldoQ.Size = New System.Drawing.Size(66, 23)
        Me.lblSaldoQ.TabIndex = 30
        '
        'lblDevolucionQ
        '
        Me.lblDevolucionQ.BackColor = System.Drawing.Color.White
        Me.lblDevolucionQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDevolucionQ.Location = New System.Drawing.Point(254, 304)
        Me.lblDevolucionQ.Name = "lblDevolucionQ"
        Me.lblDevolucionQ.Size = New System.Drawing.Size(66, 23)
        Me.lblDevolucionQ.TabIndex = 29
        '
        'lblPrestamoQ
        '
        Me.lblPrestamoQ.BackColor = System.Drawing.Color.White
        Me.lblPrestamoQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrestamoQ.Location = New System.Drawing.Point(162, 304)
        Me.lblPrestamoQ.Name = "lblPrestamoQ"
        Me.lblPrestamoQ.Size = New System.Drawing.Size(66, 23)
        Me.lblPrestamoQ.TabIndex = 28
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(17, 314)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(125, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Unidad de Plaquetas"
        '
        'frmBancoSangre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 466)
        Me.Controls.Add(Me.lblSaldoQ)
        Me.Controls.Add(Me.lblDevolucionQ)
        Me.Controls.Add(Me.lblPrestamoQ)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblSaldoP)
        Me.Controls.Add(Me.lblDevolucionP)
        Me.Controls.Add(Me.lblPrestamoP)
        Me.Controls.Add(Me.lblSaldoS)
        Me.Controls.Add(Me.lblDevolucionS)
        Me.Controls.Add(Me.lblPrestamoS)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblMedico)
        Me.Controls.Add(Me.lblServicio)
        Me.Controls.Add(Me.lblDepartamento)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboOrigen)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmBancoSangre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Banco de Sangre"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblServicio As System.Windows.Forms.Label
    Friend WithEvents lblMedico As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblPrestamoS As System.Windows.Forms.Label
    Friend WithEvents lblDevolucionS As System.Windows.Forms.Label
    Friend WithEvents lblSaldoS As System.Windows.Forms.Label
    Friend WithEvents lblSaldoP As System.Windows.Forms.Label
    Friend WithEvents lblDevolucionP As System.Windows.Forms.Label
    Friend WithEvents lblPrestamoP As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblSaldoQ As System.Windows.Forms.Label
    Friend WithEvents lblDevolucionQ As System.Windows.Forms.Label
    Friend WithEvents lblPrestamoQ As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
