<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcceso
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
        Me.gbTramite = New System.Windows.Forms.GroupBox()
        Me.gbServicioArea = New System.Windows.Forms.GroupBox()
        Me.btnCancelar1 = New System.Windows.Forms.Button()
        Me.btnAceptar1 = New System.Windows.Forms.Button()
        Me.txtFirma = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboTrabajador = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboServiArea = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboDpto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbServicioArea = New System.Windows.Forms.RadioButton()
        Me.rbTramite = New System.Windows.Forms.RadioButton()
        Me.gbTramite.SuspendLayout()
        Me.gbServicioArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTramite
        '
        Me.gbTramite.Controls.Add(Me.btnCancelar)
        Me.gbTramite.Controls.Add(Me.btnAceptar)
        Me.gbTramite.Controls.Add(Me.txtClave)
        Me.gbTramite.Controls.Add(Me.Label1)
        Me.gbTramite.Controls.Add(Me.txtUsuario)
        Me.gbTramite.Controls.Add(Me.Label4)
        Me.gbTramite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTramite.Location = New System.Drawing.Point(12, 46)
        Me.gbTramite.Name = "gbTramite"
        Me.gbTramite.Size = New System.Drawing.Size(405, 197)
        Me.gbTramite.TabIndex = 58
        Me.gbTramite.TabStop = False
        Me.gbTramite.Text = "Ingreso de Tramite Documentario"
        '
        'gbServicioArea
        '
        Me.gbServicioArea.Controls.Add(Me.btnCancelar1)
        Me.gbServicioArea.Controls.Add(Me.btnAceptar1)
        Me.gbServicioArea.Controls.Add(Me.txtFirma)
        Me.gbServicioArea.Controls.Add(Me.Label6)
        Me.gbServicioArea.Controls.Add(Me.cboTrabajador)
        Me.gbServicioArea.Controls.Add(Me.Label5)
        Me.gbServicioArea.Controls.Add(Me.cboServiArea)
        Me.gbServicioArea.Controls.Add(Me.Label3)
        Me.gbServicioArea.Controls.Add(Me.cboDpto)
        Me.gbServicioArea.Controls.Add(Me.Label2)
        Me.gbServicioArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbServicioArea.Location = New System.Drawing.Point(12, 46)
        Me.gbServicioArea.Name = "gbServicioArea"
        Me.gbServicioArea.Size = New System.Drawing.Size(405, 197)
        Me.gbServicioArea.TabIndex = 61
        Me.gbServicioArea.TabStop = False
        Me.gbServicioArea.Text = "Ingreso de Servicios / Áreas"
        '
        'btnCancelar1
        '
        Me.btnCancelar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar1.Location = New System.Drawing.Point(301, 157)
        Me.btnCancelar1.Name = "btnCancelar1"
        Me.btnCancelar1.Size = New System.Drawing.Size(92, 29)
        Me.btnCancelar1.TabIndex = 72
        Me.btnCancelar1.Text = "&CANCELAR"
        Me.btnCancelar1.UseVisualStyleBackColor = True
        '
        'btnAceptar1
        '
        Me.btnAceptar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar1.Location = New System.Drawing.Point(203, 157)
        Me.btnAceptar1.Name = "btnAceptar1"
        Me.btnAceptar1.Size = New System.Drawing.Size(92, 29)
        Me.btnAceptar1.TabIndex = 71
        Me.btnAceptar1.Text = "&ACEPTAR"
        Me.btnAceptar1.UseVisualStyleBackColor = True
        '
        'txtFirma
        '
        Me.txtFirma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirma.Location = New System.Drawing.Point(12, 166)
        Me.txtFirma.Name = "txtFirma"
        Me.txtFirma.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFirma.Size = New System.Drawing.Size(113, 20)
        Me.txtFirma.TabIndex = 70
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Clave"
        '
        'cboTrabajador
        '
        Me.cboTrabajador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrabajador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTrabajador.FormattingEnabled = True
        Me.cboTrabajador.Location = New System.Drawing.Point(11, 126)
        Me.cboTrabajador.Name = "cboTrabajador"
        Me.cboTrabajador.Size = New System.Drawing.Size(382, 21)
        Me.cboTrabajador.TabIndex = 68
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Trabajador"
        '
        'cboServiArea
        '
        Me.cboServiArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboServiArea.FormattingEnabled = True
        Me.cboServiArea.Location = New System.Drawing.Point(11, 84)
        Me.cboServiArea.Name = "cboServiArea"
        Me.cboServiArea.Size = New System.Drawing.Size(382, 21)
        Me.cboServiArea.TabIndex = 66
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Serv/Area"
        '
        'cboDpto
        '
        Me.cboDpto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDpto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDpto.FormattingEnabled = True
        Me.cboDpto.Location = New System.Drawing.Point(11, 42)
        Me.cboDpto.Name = "cboDpto"
        Me.cboDpto.Size = New System.Drawing.Size(382, 21)
        Me.cboDpto.TabIndex = 64
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Dpto/Und"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(224, 131)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(92, 29)
        Me.btnCancelar.TabIndex = 61
        Me.btnCancelar.Text = "&CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(126, 131)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(92, 29)
        Me.btnAceptar.TabIndex = 60
        Me.btnAceptar.Text = "&ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtClave
        '
        Me.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(100, 93)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(230, 20)
        Me.txtClave.TabIndex = 59
        Me.txtClave.Text = "123"
        Me.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(97, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "CLAVE"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(100, 49)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(230, 20)
        Me.txtUsuario.TabIndex = 58
        Me.txtUsuario.Text = "TRAMITE"
        Me.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(97, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "USUARIO"
        '
        'rbServicioArea
        '
        Me.rbServicioArea.AutoSize = True
        Me.rbServicioArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbServicioArea.Location = New System.Drawing.Point(188, 12)
        Me.rbServicioArea.Name = "rbServicioArea"
        Me.rbServicioArea.Size = New System.Drawing.Size(111, 17)
        Me.rbServicioArea.TabIndex = 60
        Me.rbServicioArea.TabStop = True
        Me.rbServicioArea.Text = "Servicio / Area"
        Me.rbServicioArea.UseVisualStyleBackColor = True
        '
        'rbTramite
        '
        Me.rbTramite.AutoSize = True
        Me.rbTramite.Checked = True
        Me.rbTramite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTramite.Location = New System.Drawing.Point(12, 12)
        Me.rbTramite.Name = "rbTramite"
        Me.rbTramite.Size = New System.Drawing.Size(149, 17)
        Me.rbTramite.TabIndex = 59
        Me.rbTramite.TabStop = True
        Me.rbTramite.Text = "Tramite Documentario"
        Me.rbTramite.UseVisualStyleBackColor = True
        '
        'frmAcceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 249)
        Me.Controls.Add(Me.rbServicioArea)
        Me.Controls.Add(Me.rbTramite)
        Me.Controls.Add(Me.gbServicioArea)
        Me.Controls.Add(Me.gbTramite)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAcceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad "
        Me.gbTramite.ResumeLayout(False)
        Me.gbTramite.PerformLayout()
        Me.gbServicioArea.ResumeLayout(False)
        Me.gbServicioArea.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbTramite As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rbServicioArea As System.Windows.Forms.RadioButton
    Friend WithEvents gbServicioArea As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar1 As System.Windows.Forms.Button
    Friend WithEvents btnAceptar1 As System.Windows.Forms.Button
    Friend WithEvents txtFirma As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboTrabajador As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboServiArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDpto As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbTramite As System.Windows.Forms.RadioButton

End Class
