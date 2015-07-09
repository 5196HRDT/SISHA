<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodigo
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
        Me.btnConvenio = New System.Windows.Forms.Button()
        Me.btnSOAT = New System.Windows.Forms.Button()
        Me.btnSIS = New System.Windows.Forms.Button()
        Me.txtHistoria = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnConvenio
        '
        Me.btnConvenio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConvenio.Location = New System.Drawing.Point(94, 90)
        Me.btnConvenio.Name = "btnConvenio"
        Me.btnConvenio.Size = New System.Drawing.Size(152, 43)
        Me.btnConvenio.TabIndex = 3
        Me.btnConvenio.Text = "Consultar Codigo de Convenios"
        Me.btnConvenio.UseVisualStyleBackColor = True
        '
        'btnSOAT
        '
        Me.btnSOAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSOAT.Location = New System.Drawing.Point(170, 41)
        Me.btnSOAT.Name = "btnSOAT"
        Me.btnSOAT.Size = New System.Drawing.Size(152, 43)
        Me.btnSOAT.TabIndex = 2
        Me.btnSOAT.Text = "Consultar Codigo SOAT-AFOCAT"
        Me.btnSOAT.UseVisualStyleBackColor = True
        '
        'btnSIS
        '
        Me.btnSIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSIS.Location = New System.Drawing.Point(12, 41)
        Me.btnSIS.Name = "btnSIS"
        Me.btnSIS.Size = New System.Drawing.Size(152, 43)
        Me.btnSIS.TabIndex = 1
        Me.btnSIS.Text = "Consultar Codigo SIS"
        Me.btnSIS.UseVisualStyleBackColor = True
        '
        'txtHistoria
        '
        Me.txtHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistoria.Location = New System.Drawing.Point(115, 2)
        Me.txtHistoria.Name = "txtHistoria"
        Me.txtHistoria.Size = New System.Drawing.Size(100, 23)
        Me.txtHistoria.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(27, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "HISTORIA"
        '
        'frmCodigo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 142)
        Me.Controls.Add(Me.btnConvenio)
        Me.Controls.Add(Me.btnSOAT)
        Me.Controls.Add(Me.btnSIS)
        Me.Controls.Add(Me.txtHistoria)
        Me.Controls.Add(Me.Label14)
        Me.Name = "frmCodigo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Código SIS/SOAT/AFOCAT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConvenio As System.Windows.Forms.Button
    Friend WithEvents btnSOAT As System.Windows.Forms.Button
    Friend WithEvents btnSIS As System.Windows.Forms.Button
    Friend WithEvents txtHistoria As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
