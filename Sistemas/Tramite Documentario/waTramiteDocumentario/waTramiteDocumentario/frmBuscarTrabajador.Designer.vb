<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarTrabajador
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
        Me.gbBuscarConCopiaA = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.lvConCopiaAFiltro = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtConCopiaFiltro = New System.Windows.Forms.TextBox()
        Me.gbBuscarConCopiaA.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbBuscarConCopiaA
        '
        Me.gbBuscarConCopiaA.Controls.Add(Me.Button4)
        Me.gbBuscarConCopiaA.Controls.Add(Me.lvConCopiaAFiltro)
        Me.gbBuscarConCopiaA.Controls.Add(Me.Button1)
        Me.gbBuscarConCopiaA.Controls.Add(Me.txtConCopiaFiltro)
        Me.gbBuscarConCopiaA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBuscarConCopiaA.Location = New System.Drawing.Point(12, 12)
        Me.gbBuscarConCopiaA.Name = "gbBuscarConCopiaA"
        Me.gbBuscarConCopiaA.Size = New System.Drawing.Size(788, 187)
        Me.gbBuscarConCopiaA.TabIndex = 49
        Me.gbBuscarConCopiaA.TabStop = False
        Me.gbBuscarConCopiaA.Text = "Buscar"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(626, 19)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 52
        Me.Button4.Text = "Agregar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'lvConCopiaAFiltro
        '
        Me.lvConCopiaAFiltro.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lvConCopiaAFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConCopiaAFiltro.FullRowSelect = True
        Me.lvConCopiaAFiltro.GridLines = True
        Me.lvConCopiaAFiltro.Location = New System.Drawing.Point(11, 46)
        Me.lvConCopiaAFiltro.Name = "lvConCopiaAFiltro"
        Me.lvConCopiaAFiltro.Size = New System.Drawing.Size(771, 135)
        Me.lvConCopiaAFiltro.TabIndex = 51
        Me.lvConCopiaAFiltro.UseCompatibleStateImageBehavior = False
        Me.lvConCopiaAFiltro.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "IdAsignacionCargo"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "IdTrabajador"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Trabajador"
        Me.ColumnHeader8.Width = 300
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Cargo"
        Me.ColumnHeader9.Width = 460
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(707, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "Regresar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtConCopiaFiltro
        '
        Me.txtConCopiaFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConCopiaFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConCopiaFiltro.Location = New System.Drawing.Point(11, 20)
        Me.txtConCopiaFiltro.Name = "txtConCopiaFiltro"
        Me.txtConCopiaFiltro.Size = New System.Drawing.Size(416, 20)
        Me.txtConCopiaFiltro.TabIndex = 46
        '
        'frmBuscarTrabajador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 203)
        Me.Controls.Add(Me.gbBuscarConCopiaA)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarTrabajador"
        Me.Text = "frmBuscarTrabajador"
        Me.gbBuscarConCopiaA.ResumeLayout(False)
        Me.gbBuscarConCopiaA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbBuscarConCopiaA As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents lvConCopiaAFiltro As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtConCopiaFiltro As System.Windows.Forms.TextBox
End Class
