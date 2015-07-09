<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisor
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
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnBrilloMas = New System.Windows.Forms.Button()
        Me.btnBrilloMenos = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtZoom = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrilloMas
        '
        Me.btnBrilloMas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrilloMas.Location = New System.Drawing.Point(1170, 90)
        Me.btnBrilloMas.Name = "btnBrilloMas"
        Me.btnBrilloMas.Size = New System.Drawing.Size(31, 27)
        Me.btnBrilloMas.TabIndex = 12
        Me.btnBrilloMas.Text = "+"
        Me.btnBrilloMas.UseVisualStyleBackColor = True
        Me.btnBrilloMas.Visible = False
        '
        'btnBrilloMenos
        '
        Me.btnBrilloMenos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrilloMenos.Location = New System.Drawing.Point(1133, 91)
        Me.btnBrilloMenos.Name = "btnBrilloMenos"
        Me.btnBrilloMenos.Size = New System.Drawing.Size(31, 27)
        Me.btnBrilloMenos.TabIndex = 11
        Me.btnBrilloMenos.Text = "-"
        Me.btnBrilloMenos.UseVisualStyleBackColor = True
        Me.btnBrilloMenos.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1128, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "BRILLO"
        Me.Label2.Visible = False
        '
        'pbImagen
        '
        Me.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbImagen.Location = New System.Drawing.Point(98, 0)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(1190, 669)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 1
        Me.pbImagen.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pbImagen)
        Me.Panel1.Location = New System.Drawing.Point(-87, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1209, 662)
        Me.Panel1.TabIndex = 9
        '
        'txtZoom
        '
        Me.txtZoom.DecimalPlaces = 1
        Me.txtZoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZoom.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtZoom.Location = New System.Drawing.Point(1131, 27)
        Me.txtZoom.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtZoom.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtZoom.Name = "txtZoom"
        Me.txtZoom.Size = New System.Drawing.Size(54, 26)
        Me.txtZoom.TabIndex = 8
        Me.txtZoom.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1128, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "ZOOM IMAGEN"
        '
        'frmVisor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1225, 673)
        Me.Controls.Add(Me.btnBrilloMas)
        Me.Controls.Add(Me.btnBrilloMenos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtZoom)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmVisor"
        Me.Text = "Visor de Imagen"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnBrilloMas As System.Windows.Forms.Button
    Friend WithEvents btnBrilloMenos As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtZoom As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
