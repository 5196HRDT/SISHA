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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtZoom = New System.Windows.Forms.NumericUpDown()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnBrilloMenos = New System.Windows.Forms.Button()
        Me.btnBrilloMas = New System.Windows.Forms.Button()
        CType(Me.txtZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1216, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ZOOM IMAGEN"
        '
        'txtZoom
        '
        Me.txtZoom.DecimalPlaces = 1
        Me.txtZoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZoom.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtZoom.Location = New System.Drawing.Point(1219, 22)
        Me.txtZoom.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtZoom.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtZoom.Name = "txtZoom"
        Me.txtZoom.Size = New System.Drawing.Size(54, 26)
        Me.txtZoom.TabIndex = 2
        Me.txtZoom.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pbImagen)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1209, 662)
        Me.Panel1.TabIndex = 3
        '
        'pbImagen
        '
        Me.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbImagen.Location = New System.Drawing.Point(5, 3)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(1190, 669)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 1
        Me.pbImagen.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1216, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "BRILLO"
        Me.Label2.Visible = False
        '
        'btnBrilloMenos
        '
        Me.btnBrilloMenos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrilloMenos.Location = New System.Drawing.Point(1221, 86)
        Me.btnBrilloMenos.Name = "btnBrilloMenos"
        Me.btnBrilloMenos.Size = New System.Drawing.Size(31, 27)
        Me.btnBrilloMenos.TabIndex = 5
        Me.btnBrilloMenos.Text = "-"
        Me.btnBrilloMenos.UseVisualStyleBackColor = True
        Me.btnBrilloMenos.Visible = False
        '
        'btnBrilloMas
        '
        Me.btnBrilloMas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrilloMas.Location = New System.Drawing.Point(1258, 85)
        Me.btnBrilloMas.Name = "btnBrilloMas"
        Me.btnBrilloMas.Size = New System.Drawing.Size(31, 27)
        Me.btnBrilloMas.TabIndex = 6
        Me.btnBrilloMas.Text = "+"
        Me.btnBrilloMas.UseVisualStyleBackColor = True
        Me.btnBrilloMas.Visible = False
        '
        'frmVisor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 673)
        Me.Controls.Add(Me.btnBrilloMas)
        Me.Controls.Add(Me.btnBrilloMenos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtZoom)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmVisor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visor de Imagen"
        CType(Me.txtZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtZoom As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnBrilloMenos As System.Windows.Forms.Button
    Friend WithEvents btnBrilloMas As System.Windows.Forms.Button
End Class
