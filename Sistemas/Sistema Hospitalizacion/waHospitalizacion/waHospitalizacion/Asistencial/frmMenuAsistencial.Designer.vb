<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuAsistencial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuAsistencial))
        Me.btnProcEnf = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnIngreso = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnProcEnf
        '
        Me.btnProcEnf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcEnf.ForeColor = System.Drawing.Color.Black
        Me.btnProcEnf.Image = CType(resources.GetObject("btnProcEnf.Image"), System.Drawing.Image)
        Me.btnProcEnf.Location = New System.Drawing.Point(317, 12)
        Me.btnProcEnf.Name = "btnProcEnf"
        Me.btnProcEnf.Size = New System.Drawing.Size(132, 140)
        Me.btnProcEnf.TabIndex = 8
        Me.btnProcEnf.Text = "Procedimientos Enfermería"
        Me.btnProcEnf.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcEnf.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(164, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 140)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Transferencia de Servicio"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnIngreso
        '
        Me.btnIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngreso.ForeColor = System.Drawing.Color.Black
        Me.btnIngreso.Image = CType(resources.GetObject("btnIngreso.Image"), System.Drawing.Image)
        Me.btnIngreso.Location = New System.Drawing.Point(12, 12)
        Me.btnIngreso.Name = "btnIngreso"
        Me.btnIngreso.Size = New System.Drawing.Size(132, 140)
        Me.btnIngreso.TabIndex = 0
        Me.btnIngreso.Text = "Ingreso de Paciente a mi Servicio"
        Me.btnIngreso.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIngreso.UseVisualStyleBackColor = True
        '
        'frmMenuAsistencial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 159)
        Me.Controls.Add(Me.btnProcEnf)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnIngreso)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuAsistencial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Principal - Hospitalización"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnIngreso As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnProcEnf As System.Windows.Forms.Button
End Class
