<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcedimientos
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
        Me.lblPaciente = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtHistoria = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.lvTabla = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.txtDes = New System.Windows.Forms.TextBox
        Me.txtCIE = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.gbConsulta = New System.Windows.Forms.GroupBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.btnRetornar = New System.Windows.Forms.Button
        Me.lvDet = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.txtFiltro = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.gbConsulta.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaciente.Location = New System.Drawing.Point(118, 49)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(363, 22)
        Me.lblPaciente.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Paciente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtHistoria
        '
        Me.txtHistoria.Location = New System.Drawing.Point(118, 21)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(100, 20)
        Me.txtHistoria.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nro de Historia"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(337, 285)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(70, 285)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 5
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(5, 159)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(488, 101)
        Me.lvTabla.TabIndex = 4
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "CPT"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripcion"
        Me.ColumnHeader2.Width = 421
        '
        'txtDes
        '
        Me.txtDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDes.Location = New System.Drawing.Point(116, 120)
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(380, 20)
        Me.txtDes.TabIndex = 3
        '
        'txtCIE
        '
        Me.txtCIE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCIE.Location = New System.Drawing.Point(8, 120)
        Me.txtCIE.Name = "txtCIE"
        Me.txtCIE.Size = New System.Drawing.Size(91, 20)
        Me.txtCIE.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(6, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(178, 13)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "LISTA DE PROCEDIMIENTOS"
        '
        'gbConsulta
        '
        Me.gbConsulta.Controls.Add(Me.Label32)
        Me.gbConsulta.Controls.Add(Me.btnRetornar)
        Me.gbConsulta.Controls.Add(Me.lvDet)
        Me.gbConsulta.Controls.Add(Me.txtFiltro)
        Me.gbConsulta.Controls.Add(Me.Label31)
        Me.gbConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConsulta.Location = New System.Drawing.Point(6, 30)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Size = New System.Drawing.Size(487, 277)
        Me.gbConsulta.TabIndex = 120
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta General"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(6, 246)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(255, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Presione Enter para Insertar un Codigo CPT"
        '
        'btnRetornar
        '
        Me.btnRetornar.Location = New System.Drawing.Point(373, 238)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Size = New System.Drawing.Size(78, 29)
        Me.btnRetornar.TabIndex = 3
        Me.btnRetornar.Text = "&Retornar"
        Me.btnRetornar.UseVisualStyleBackColor = True
        '
        'lvDet
        '
        Me.lvDet.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvDet.FullRowSelect = True
        Me.lvDet.GridLines = True
        Me.lvDet.Location = New System.Drawing.Point(9, 52)
        Me.lvDet.Name = "lvDet"
        Me.lvDet.Size = New System.Drawing.Size(468, 177)
        Me.lvDet.TabIndex = 2
        Me.lvDet.UseCompatibleStateImageBehavior = False
        Me.lvDet.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "CPT"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Descripción"
        Me.ColumnHeader5.Width = 404
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
        'frmProcedimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 319)
        Me.Controls.Add(Me.gbConsulta)
        Me.Controls.Add(Me.lvTabla)
        Me.Controls.Add(Me.txtDes)
        Me.Controls.Add(Me.txtCIE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmProcedimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Procedimientos"
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDes As System.Windows.Forms.TextBox
    Friend WithEvents txtCIE As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnRetornar As System.Windows.Forms.Button
    Friend WithEvents lvDet As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
End Class
