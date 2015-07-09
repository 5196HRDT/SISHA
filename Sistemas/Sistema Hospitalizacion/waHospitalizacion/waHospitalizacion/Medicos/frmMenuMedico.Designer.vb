<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuMedico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuMedico))
        Me.btnMedSIS = New System.Windows.Forms.Button()
        Me.btnProcedimientos = New System.Windows.Forms.Button()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.btnEpicrisis = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnMedSIS
        '
        Me.btnMedSIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMedSIS.ForeColor = System.Drawing.Color.Black
        Me.btnMedSIS.Image = CType(resources.GetObject("btnMedSIS.Image"), System.Drawing.Image)
        Me.btnMedSIS.Location = New System.Drawing.Point(172, 8)
        Me.btnMedSIS.Name = "btnMedSIS"
        Me.btnMedSIS.Size = New System.Drawing.Size(132, 140)
        Me.btnMedSIS.TabIndex = 1
        Me.btnMedSIS.Text = "Receta SIS"
        Me.btnMedSIS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMedSIS.UseVisualStyleBackColor = True
        '
        'btnProcedimientos
        '
        Me.btnProcedimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcedimientos.ForeColor = System.Drawing.Color.Black
        Me.btnProcedimientos.Image = CType(resources.GetObject("btnProcedimientos.Image"), System.Drawing.Image)
        Me.btnProcedimientos.Location = New System.Drawing.Point(23, 8)
        Me.btnProcedimientos.Name = "btnProcedimientos"
        Me.btnProcedimientos.Size = New System.Drawing.Size(132, 140)
        Me.btnProcedimientos.TabIndex = 0
        Me.btnProcedimientos.Text = "Procedimientos Médicos"
        Me.btnProcedimientos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcedimientos.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlta.ForeColor = System.Drawing.Color.Black
        Me.btnAlta.Image = CType(resources.GetObject("btnAlta.Image"), System.Drawing.Image)
        Me.btnAlta.Location = New System.Drawing.Point(476, 8)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(132, 140)
        Me.btnAlta.TabIndex = 3
        Me.btnAlta.Text = "Alta Paciente"
        Me.btnAlta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'btnEpicrisis
        '
        Me.btnEpicrisis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEpicrisis.ForeColor = System.Drawing.Color.Black
        Me.btnEpicrisis.Image = CType(resources.GetObject("btnEpicrisis.Image"), System.Drawing.Image)
        Me.btnEpicrisis.Location = New System.Drawing.Point(326, 8)
        Me.btnEpicrisis.Name = "btnEpicrisis"
        Me.btnEpicrisis.Size = New System.Drawing.Size(132, 140)
        Me.btnEpicrisis.TabIndex = 2
        Me.btnEpicrisis.Text = "EPICRISIS"
        Me.btnEpicrisis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEpicrisis.UseVisualStyleBackColor = True
        '
        'frmMenuMedico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 160)
        Me.Controls.Add(Me.btnMedSIS)
        Me.Controls.Add(Me.btnProcedimientos)
        Me.Controls.Add(Me.btnAlta)
        Me.Controls.Add(Me.btnEpicrisis)
        Me.Name = "frmMenuMedico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Principal - Médicos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEpicrisis As System.Windows.Forms.Button
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents btnProcedimientos As System.Windows.Forms.Button
    Friend WithEvents btnMedSIS As System.Windows.Forms.Button
End Class
