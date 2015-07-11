<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInforme
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

        Me.lvTabla = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtPaciente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblHistoria = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPaciente = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.txtInforme = New DevExpress.XtraRichEdit.RichEditControl()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboMedico = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lvHistorial = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ppdVistaPrevia = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdcDocumento = New System.Drawing.Printing.PrintDocument()
        Me.Fuente = New System.Windows.Forms.FontDialog()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCorrelativo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboTipoPaciente = New System.Windows.Forms.ComboBox()

        Me.HomeRibbonPage1 = New DevExpress.XtraRichEdit.UI.HomeRibbonPage()
        Me.EditingRibbonPageGroup1 = New DevExpress.XtraRichEdit.UI.EditingRibbonPageGroup()
        Me.StylesRibbonPageGroup1 = New DevExpress.XtraRichEdit.UI.StylesRibbonPageGroup()
        Me.ParagraphRibbonPageGroup1 = New DevExpress.XtraRichEdit.UI.ParagraphRibbonPageGroup()
        Me.FontRibbonPageGroup1 = New DevExpress.XtraRichEdit.UI.FontRibbonPageGroup()
        Me.ClipboardRibbonPageGroup1 = New DevExpress.XtraRichEdit.UI.ClipboardRibbonPageGroup()
     
        Me.PasteItem1 = New DevExpress.XtraRichEdit.UI.PasteItem()
        Me.CutItem1 = New DevExpress.XtraRichEdit.UI.CutItem()
        Me.CopyItem1 = New DevExpress.XtraRichEdit.UI.CopyItem()
        Me.PasteSpecialItem1 = New DevExpress.XtraRichEdit.UI.PasteSpecialItem()

        Me.ChangeFontNameItem1 = New DevExpress.XtraRichEdit.UI.ChangeFontNameItem()
        Me.ChangeFontSizeItem1 = New DevExpress.XtraRichEdit.UI.ChangeFontSizeItem()
        Me.FontSizeIncreaseItem1 = New DevExpress.XtraRichEdit.UI.FontSizeIncreaseItem()
        Me.FontSizeDecreaseItem1 = New DevExpress.XtraRichEdit.UI.FontSizeDecreaseItem()

        Me.ToggleFontBoldItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontBoldItem()
        Me.ToggleFontItalicItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontItalicItem()
        Me.ToggleFontUnderlineItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontUnderlineItem()
        Me.ToggleFontDoubleUnderlineItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontDoubleUnderlineItem()
        Me.ToggleFontStrikeoutItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontStrikeoutItem()
        Me.ToggleFontDoubleStrikeoutItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontDoubleStrikeoutItem()
        Me.ToggleFontSuperscriptItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontSuperscriptItem()
        Me.ToggleFontSubscriptItem1 = New DevExpress.XtraRichEdit.UI.ToggleFontSubscriptItem()

        Me.ChangeFontColorItem1 = New DevExpress.XtraRichEdit.UI.ChangeFontColorItem()
        Me.ChangeFontBackColorItem1 = New DevExpress.XtraRichEdit.UI.ChangeFontBackColorItem()
        Me.ChangeTextCaseItem1 = New DevExpress.XtraRichEdit.UI.ChangeTextCaseItem()
        Me.MakeTextUpperCaseItem1 = New DevExpress.XtraRichEdit.UI.MakeTextUpperCaseItem()
        Me.MakeTextLowerCaseItem1 = New DevExpress.XtraRichEdit.UI.MakeTextLowerCaseItem()
        Me.ToggleTextCaseItem1 = New DevExpress.XtraRichEdit.UI.ToggleTextCaseItem()
        Me.ClearFormattingItem1 = New DevExpress.XtraRichEdit.UI.ClearFormattingItem()

        Me.ToggleBulletedListItem1 = New DevExpress.XtraRichEdit.UI.ToggleBulletedListItem()
        Me.ToggleNumberingListItem1 = New DevExpress.XtraRichEdit.UI.ToggleNumberingListItem()
        Me.ToggleMultiLevelListItem1 = New DevExpress.XtraRichEdit.UI.ToggleMultiLevelListItem()

        Me.DecreaseIndentItem1 = New DevExpress.XtraRichEdit.UI.DecreaseIndentItem()
        Me.IncreaseIndentItem1 = New DevExpress.XtraRichEdit.UI.IncreaseIndentItem()

        Me.ToggleParagraphAlignmentLeftItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentLeftItem()
        Me.ToggleParagraphAlignmentCenterItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentCenterItem()
        Me.ToggleParagraphAlignmentRightItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentRightItem()
        Me.ToggleParagraphAlignmentJustifyItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentJustifyItem()
        Me.ToggleShowWhitespaceItem1 = New DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem()

        Me.ChangeParagraphLineSpacingItem1 = New DevExpress.XtraRichEdit.UI.ChangeParagraphLineSpacingItem()
        Me.SetSingleParagraphSpacingItem1 = New DevExpress.XtraRichEdit.UI.SetSingleParagraphSpacingItem()
        Me.SetSesquialteralParagraphSpacingItem1 = New DevExpress.XtraRichEdit.UI.SetSesquialteralParagraphSpacingItem()
        Me.SetDoubleParagraphSpacingItem1 = New DevExpress.XtraRichEdit.UI.SetDoubleParagraphSpacingItem()
        Me.ShowLineSpacingFormItem1 = New DevExpress.XtraRichEdit.UI.ShowLineSpacingFormItem()
        Me.AddSpacingBeforeParagraphItem1 = New DevExpress.XtraRichEdit.UI.AddSpacingBeforeParagraphItem()
        Me.RemoveSpacingBeforeParagraphItem1 = New DevExpress.XtraRichEdit.UI.RemoveSpacingBeforeParagraphItem()
        Me.AddSpacingAfterParagraphItem1 = New DevExpress.XtraRichEdit.UI.AddSpacingAfterParagraphItem()
        Me.RemoveSpacingAfterParagraphItem1 = New DevExpress.XtraRichEdit.UI.RemoveSpacingAfterParagraphItem()
        Me.ChangeParagraphBackColorItem1 = New DevExpress.XtraRichEdit.UI.ChangeParagraphBackColorItem()
        Me.GalleryChangeStyleItem1 = New DevExpress.XtraRichEdit.UI.GalleryChangeStyleItem()
        Me.FindItem1 = New DevExpress.XtraRichEdit.UI.FindItem()
        Me.ReplaceItem1 = New DevExpress.XtraRichEdit.UI.ReplaceItem()

        CType(Me.RichEditBarController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvTabla
        '
        Me.lvTabla.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader8})
        Me.lvTabla.FullRowSelect = True
        Me.lvTabla.GridLines = True
        Me.lvTabla.Location = New System.Drawing.Point(8, 170)
        Me.lvTabla.Name = "lvTabla"
        Me.lvTabla.Size = New System.Drawing.Size(504, 94)
        Me.lvTabla.TabIndex = 1
        Me.lvTabla.UseCompatibleStateImageBehavior = False
        Me.lvTabla.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Historia"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Paciente"
        Me.ColumnHeader8.Width = 400
        '
        'txtPaciente
        '
        Me.txtPaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaciente.Location = New System.Drawing.Point(130, 146)
        Me.txtPaciente.Name = "txtPaciente"
        Me.txtPaciente.Size = New System.Drawing.Size(320, 20)
        Me.txtPaciente.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Historia / Paciente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(519, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Historia"
        '
        'lblHistoria
        '
        Me.lblHistoria.BackColor = System.Drawing.Color.White
        Me.lblHistoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHistoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoria.Location = New System.Drawing.Point(587, 205)
        Me.lblHistoria.Name = "lblHistoria"
        Me.lblHistoria.Size = New System.Drawing.Size(77, 24)
        Me.lblHistoria.TabIndex = 6
        Me.lblHistoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(520, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Paciente"
        '
        'lblPaciente
        '
        Me.lblPaciente.BackColor = System.Drawing.Color.White
        Me.lblPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaciente.Location = New System.Drawing.Point(587, 247)
        Me.lblPaciente.Name = "lblPaciente"
        Me.lblPaciente.Size = New System.Drawing.Size(403, 24)
        Me.lblPaciente.TabIndex = 8
        Me.lblPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(780, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fecha Informe"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(888, 143)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(102, 20)
        Me.dtpFecha.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(520, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Sexo"
        '
        'lblSexo
        '
        Me.lblSexo.BackColor = System.Drawing.Color.White
        Me.lblSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSexo.Location = New System.Drawing.Point(587, 287)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(101, 24)
        Me.lblSexo.TabIndex = 9
        Me.lblSexo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.White
        Me.lblEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.Location = New System.Drawing.Point(799, 287)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(101, 24)
        Me.lblEdad.TabIndex = 10
        Me.lblEdad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(695, 287)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Edad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(363, 356)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(242, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "INFORME ELECTROENCEFALOGRAFICO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(519, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Recibo Pago"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(736, 169)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(55, 20)
        Me.txtSerie.TabIndex = 3
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(798, 169)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(70, 20)
        Me.txtNumero.TabIndex = 4
        '
        'cboTipo
        '
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {"BOLETA", "FACTURA"})
        Me.cboTipo.Location = New System.Drawing.Point(609, 169)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(121, 21)
        Me.cboTipo.TabIndex = 2
        '
        'txtInforme
        '
        Me.txtInforme.Location = New System.Drawing.Point(13, 373)
        Me.txtInforme.MenuManager = Me.RibbonControl1
        Me.txtInforme.Name = "txtInforme"
        Me.txtInforme.Options.Fields.UseCurrentCultureDateTimeFormat = False
        Me.txtInforme.Options.MailMerge.KeepLastParagraph = False
        Me.txtInforme.Size = New System.Drawing.Size(966, 259)
        Me.txtInforme.TabIndex = 36
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(655, 637)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 59
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(523, 637)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 58
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Location = New System.Drawing.Point(392, 637)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 57
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(270, 637)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 56
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(519, 321)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Solicitado"
        '
        'cboMedico
        '
        Me.cboMedico.FormattingEnabled = True
        Me.cboMedico.Location = New System.Drawing.Point(587, 321)
        Me.cboMedico.Name = "cboMedico"
        Me.cboMedico.Size = New System.Drawing.Size(403, 21)
        Me.cboMedico.TabIndex = 62
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 267)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 13)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Historial de Informes"
        '
        'lvHistorial
        '
        Me.lvHistorial.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvHistorial.FullRowSelect = True
        Me.lvHistorial.GridLines = True
        Me.lvHistorial.Location = New System.Drawing.Point(13, 287)
        Me.lvHistorial.Name = "lvHistorial"
        Me.lvHistorial.Size = New System.Drawing.Size(504, 70)
        Me.lvHistorial.TabIndex = 65
        Me.lvHistorial.UseCompatibleStateImageBehavior = False
        Me.lvHistorial.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Id"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "FechaExa"
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Solicitado"
        Me.ColumnHeader6.Width = 200
        '
        'ppdVistaPrevia
        '
        Me.ppdVistaPrevia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdVistaPrevia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdVistaPrevia.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdVistaPrevia.Document = Me.pdcDocumento
        Me.ppdVistaPrevia.Enabled = True
        Me.ppdVistaPrevia.Icon = CType(resources.GetObject("ppdVistaPrevia.Icon"), System.Drawing.Icon)
        Me.ppdVistaPrevia.Name = "ppdVistaPrevia"
        Me.ppdVistaPrevia.Visible = False
        '
        'pdcDocumento
        '
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(886, 170)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Nro"
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.Location = New System.Drawing.Point(920, 167)
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Size = New System.Drawing.Size(70, 20)
        Me.txtCorrelativo.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(695, 205)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Tipo"
        '
        'cboTipoPaciente
        '
        Me.cboTipoPaciente.FormattingEnabled = True
        Me.cboTipoPaciente.Location = New System.Drawing.Point(736, 202)
        Me.cboTipoPaciente.Name = "cboTipoPaciente"
        Me.cboTipoPaciente.Size = New System.Drawing.Size(132, 21)
        Me.cboTipoPaciente.TabIndex = 7
        '
        'RichEditBarController1
        '
        Me.RichEditBarController1.Control = Me.txtInforme
        '
        'HomeRibbonPage1
        '
        Me.HomeRibbonPage1.Name = "HomeRibbonPage1"
        '
        'EditingRibbonPageGroup1
        '
        Me.EditingRibbonPageGroup1.Name = "EditingRibbonPageGroup1"
        Me.EditingRibbonPageGroup1.Text = ""
        '
        'StylesRibbonPageGroup1
        '
        Me.StylesRibbonPageGroup1.Name = "StylesRibbonPageGroup1"
        Me.StylesRibbonPageGroup1.Text = ""
        '
        'ParagraphRibbonPageGroup1
        '
        Me.ParagraphRibbonPageGroup1.Name = "ParagraphRibbonPageGroup1"
        Me.ParagraphRibbonPageGroup1.Text = ""
        '
        'FontRibbonPageGroup1
        '
        Me.FontRibbonPageGroup1.Name = "FontRibbonPageGroup1"
        Me.FontRibbonPageGroup1.Text = ""
        '
        'ClipboardRibbonPageGroup1
        '
        Me.ClipboardRibbonPageGroup1.Name = "ClipboardRibbonPageGroup1"
        Me.ClipboardRibbonPageGroup1.Text = ""
        '
        'RepositoryItemFontEdit1
        '
        Me.RepositoryItemFontEdit1.AutoHeight = False
        Me.RepositoryItemFontEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemFontEdit1.Name = "RepositoryItemFontEdit1"
        '
        'RepositoryItemRichEditFontSizeEdit1
        '
        Me.RepositoryItemRichEditFontSizeEdit1.AutoHeight = False
        Me.RepositoryItemRichEditFontSizeEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemRichEditFontSizeEdit1.Control = Me.txtInforme
        Me.RepositoryItemRichEditFontSizeEdit1.Name = "RepositoryItemRichEditFontSizeEdit1"
        '
        'PasteItem1
        '
        Me.PasteItem1.Caption = "Paste"
        Me.PasteItem1.Id = 8
        Me.PasteItem1.Name = "PasteItem1"
        ToolTipTitleItem1.Text = "Paste (Ctrl+V)"
        ToolTipItem1.Text = "Paste the contents of the Clipboard."
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.PasteItem1.SuperTip = SuperToolTip1
        '
        'CutItem1
        '
        Me.CutItem1.Caption = "Cut"
        Me.CutItem1.Id = 9
        Me.CutItem1.Name = "CutItem1"
        ToolTipTitleItem2.Text = "Cut (Ctrl+X)"
        ToolTipItem2.Text = "Cut the selection from the document and put it on the Clipboard."
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.CutItem1.SuperTip = SuperToolTip2
        '
        'CopyItem1
        '
        Me.CopyItem1.Caption = "Copy"
        Me.CopyItem1.Id = 10
        Me.CopyItem1.Name = "CopyItem1"
        ToolTipTitleItem3.Text = "Copy (Ctrl+C)"
        ToolTipItem3.Text = "Copy the selection and put it on the Clipboard."
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.CopyItem1.SuperTip = SuperToolTip3
        '
        'PasteSpecialItem1
        '
        Me.PasteSpecialItem1.Caption = "Paste Special"
        Me.PasteSpecialItem1.Id = 11
        Me.PasteSpecialItem1.Name = "PasteSpecialItem1"
        ToolTipTitleItem4.Text = "Paste Special (Ctrl+Alt+V)"
        ToolTipItem4.Text = "Paste Special"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.PasteSpecialItem1.SuperTip = SuperToolTip4
        '
        'BarButtonGroup1
        '
        Me.BarButtonGroup1.Id = 1
        Me.BarButtonGroup1.Name = "BarButtonGroup1"
        Me.BarButtonGroup1.Tag = "{97BBE334-159B-44d9-A168-0411957565E8}"
        '
        'ChangeFontNameItem1
        '
        Me.ChangeFontNameItem1.Edit = Me.RepositoryItemFontEdit1
        Me.ChangeFontNameItem1.Id = 12
        Me.ChangeFontNameItem1.Name = "ChangeFontNameItem1"
        ToolTipTitleItem5.Text = "Font"
        ToolTipItem5.Text = "Change the font face."
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.ChangeFontNameItem1.SuperTip = SuperToolTip5
        '
        'ChangeFontSizeItem1
        '
        Me.ChangeFontSizeItem1.Edit = Me.RepositoryItemRichEditFontSizeEdit1
        Me.ChangeFontSizeItem1.Id = 13
        Me.ChangeFontSizeItem1.Name = "ChangeFontSizeItem1"
        ToolTipTitleItem6.Text = "Font Size"
        ToolTipItem6.Text = "Change the font size."
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.ChangeFontSizeItem1.SuperTip = SuperToolTip6
        '
        'FontSizeIncreaseItem1
        '
        Me.FontSizeIncreaseItem1.Caption = "Grow Font"
        Me.FontSizeIncreaseItem1.Id = 14
        Me.FontSizeIncreaseItem1.Name = "FontSizeIncreaseItem1"
        ToolTipTitleItem7.Text = "Grow Font (Ctrl+Mayús.+.)"
        ToolTipItem7.Text = "Increase the font size."
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.FontSizeIncreaseItem1.SuperTip = SuperToolTip7
        '
        'FontSizeDecreaseItem1
        '
        Me.FontSizeDecreaseItem1.Caption = "Shrink Font"
        Me.FontSizeDecreaseItem1.Id = 15
        Me.FontSizeDecreaseItem1.Name = "FontSizeDecreaseItem1"
        ToolTipTitleItem8.Text = "Shrink Font (Ctrl+Mayús.+,)"
        ToolTipItem8.Text = "Decrease the font size."
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.FontSizeDecreaseItem1.SuperTip = SuperToolTip8
        '
        'BarButtonGroup2
        '
        Me.BarButtonGroup2.Id = 2
        Me.BarButtonGroup2.Name = "BarButtonGroup2"
        Me.BarButtonGroup2.Tag = "{433DA7F0-03E2-4650-9DB5-66DD92D16E39}"
        '
        'ToggleFontBoldItem1
        '
        Me.ToggleFontBoldItem1.Caption = "Bold"
        Me.ToggleFontBoldItem1.Id = 16
        Me.ToggleFontBoldItem1.Name = "ToggleFontBoldItem1"
        ToolTipTitleItem9.Text = "Bold (Ctrl+B)"
        ToolTipItem9.Text = "Make the selected text bold."
        SuperToolTip9.Items.Add(ToolTipTitleItem9)
        SuperToolTip9.Items.Add(ToolTipItem9)
        Me.ToggleFontBoldItem1.SuperTip = SuperToolTip9
        '
        'ToggleFontItalicItem1
        '
        Me.ToggleFontItalicItem1.Caption = "Italic"
        Me.ToggleFontItalicItem1.Id = 17
        Me.ToggleFontItalicItem1.Name = "ToggleFontItalicItem1"
        ToolTipTitleItem10.Text = "Italic (Ctrl+I)"
        ToolTipItem10.Text = "Italicize the selected text."
        SuperToolTip10.Items.Add(ToolTipTitleItem10)
        SuperToolTip10.Items.Add(ToolTipItem10)
        Me.ToggleFontItalicItem1.SuperTip = SuperToolTip10
        '
        'ToggleFontUnderlineItem1
        '
        Me.ToggleFontUnderlineItem1.Caption = "Underline"
        Me.ToggleFontUnderlineItem1.Id = 18
        Me.ToggleFontUnderlineItem1.Name = "ToggleFontUnderlineItem1"
        ToolTipTitleItem11.Text = "Underline (Ctrl+U)"
        ToolTipItem11.Text = "Underline the selected text."
        SuperToolTip11.Items.Add(ToolTipTitleItem11)
        SuperToolTip11.Items.Add(ToolTipItem11)
        Me.ToggleFontUnderlineItem1.SuperTip = SuperToolTip11
        '
        'ToggleFontDoubleUnderlineItem1
        '
        Me.ToggleFontDoubleUnderlineItem1.Caption = "Double Underline"
        Me.ToggleFontDoubleUnderlineItem1.Id = 19
        Me.ToggleFontDoubleUnderlineItem1.Name = "ToggleFontDoubleUnderlineItem1"
        ToolTipTitleItem12.Text = "Double Underline (Ctrl+Mayús.+D)"
        ToolTipItem12.Text = "Double underline"
        SuperToolTip12.Items.Add(ToolTipTitleItem12)
        SuperToolTip12.Items.Add(ToolTipItem12)
        Me.ToggleFontDoubleUnderlineItem1.SuperTip = SuperToolTip12
        '
        'ToggleFontStrikeoutItem1
        '
        Me.ToggleFontStrikeoutItem1.Caption = "Strikethrough"
        Me.ToggleFontStrikeoutItem1.Id = 20
        Me.ToggleFontStrikeoutItem1.Name = "ToggleFontStrikeoutItem1"
        ToolTipTitleItem13.Text = "Strikethrough"
        ToolTipItem13.Text = "Draw a line through the middle of the selected text."
        SuperToolTip13.Items.Add(ToolTipTitleItem13)
        SuperToolTip13.Items.Add(ToolTipItem13)
        Me.ToggleFontStrikeoutItem1.SuperTip = SuperToolTip13
        '
        'ToggleFontDoubleStrikeoutItem1
        '
        Me.ToggleFontDoubleStrikeoutItem1.Caption = "Double Strikethrough"
        Me.ToggleFontDoubleStrikeoutItem1.Id = 21
        Me.ToggleFontDoubleStrikeoutItem1.Name = "ToggleFontDoubleStrikeoutItem1"
        ToolTipTitleItem14.Text = "Double Strikethrough"
        ToolTipItem14.Text = "Double strikethrough"
        SuperToolTip14.Items.Add(ToolTipTitleItem14)
        SuperToolTip14.Items.Add(ToolTipItem14)
        Me.ToggleFontDoubleStrikeoutItem1.SuperTip = SuperToolTip14
        '
        'ToggleFontSuperscriptItem1
        '
        Me.ToggleFontSuperscriptItem1.Caption = "Superscript"
        Me.ToggleFontSuperscriptItem1.Id = 22
        Me.ToggleFontSuperscriptItem1.Name = "ToggleFontSuperscriptItem1"
        ToolTipTitleItem15.Text = "Superscript (Ctrl+Mayús.++)"
        ToolTipItem15.Text = "Create small letters above the line of text."
        SuperToolTip15.Items.Add(ToolTipTitleItem15)
        SuperToolTip15.Items.Add(ToolTipItem15)
        Me.ToggleFontSuperscriptItem1.SuperTip = SuperToolTip15
        '
        'ToggleFontSubscriptItem1
        '
        Me.ToggleFontSubscriptItem1.Caption = "Subscript"
        Me.ToggleFontSubscriptItem1.Id = 23
        Me.ToggleFontSubscriptItem1.Name = "ToggleFontSubscriptItem1"
        ToolTipTitleItem16.Text = "Subscript (Ctrl++)"
        ToolTipItem16.Text = "Create small letters below the text baseline."
        SuperToolTip16.Items.Add(ToolTipTitleItem16)
        SuperToolTip16.Items.Add(ToolTipItem16)
        Me.ToggleFontSubscriptItem1.SuperTip = SuperToolTip16
        '
        'BarButtonGroup3
        '
        Me.BarButtonGroup3.Id = 3
        Me.BarButtonGroup3.Name = "BarButtonGroup3"
        Me.BarButtonGroup3.Tag = "{DF8C5334-EDE3-47c9-A42C-FE9A9247E180}"
        '
        'ChangeFontColorItem1
        '
        Me.ChangeFontColorItem1.Caption = "Font Color"
        Me.ChangeFontColorItem1.Id = 24
        Me.ChangeFontColorItem1.Name = "ChangeFontColorItem1"
        ToolTipTitleItem17.Text = "Font Color"
        ToolTipItem17.Text = "Change the font color."
        SuperToolTip17.Items.Add(ToolTipTitleItem17)
        SuperToolTip17.Items.Add(ToolTipItem17)
        Me.ChangeFontColorItem1.SuperTip = SuperToolTip17
        '
        'ChangeFontBackColorItem1
        '
        Me.ChangeFontBackColorItem1.Caption = "Text Highlight Color"
        Me.ChangeFontBackColorItem1.Id = 25
        Me.ChangeFontBackColorItem1.Name = "ChangeFontBackColorItem1"
        ToolTipTitleItem18.Text = "Text Highlight Color"
        ToolTipItem18.Text = "Make text look like it was marked with a highlighter pen."
        SuperToolTip18.Items.Add(ToolTipTitleItem18)
        SuperToolTip18.Items.Add(ToolTipItem18)
        Me.ChangeFontBackColorItem1.SuperTip = SuperToolTip18
        '
        'ChangeTextCaseItem1
        '
        Me.ChangeTextCaseItem1.Caption = "Change Case"
        Me.ChangeTextCaseItem1.Id = 26
        Me.ChangeTextCaseItem1.Name = "ChangeTextCaseItem1"
        ToolTipTitleItem19.Text = "Change Case"
        ToolTipItem19.Text = "Change all the selected text to UPPERCASE, lowercase, or other common capitalizat" & _
    "ions."
        SuperToolTip19.Items.Add(ToolTipTitleItem19)
        SuperToolTip19.Items.Add(ToolTipItem19)
        Me.ChangeTextCaseItem1.SuperTip = SuperToolTip19
        '
        'MakeTextUpperCaseItem1
        '
        Me.MakeTextUpperCaseItem1.Caption = "UPPERCASE"
        Me.MakeTextUpperCaseItem1.Id = 27
        Me.MakeTextUpperCaseItem1.Name = "MakeTextUpperCaseItem1"
        ToolTipTitleItem20.Text = "UPPERCASE"
        ToolTipItem20.Text = "Change all the selected text to UPPERCASE."
        SuperToolTip20.Items.Add(ToolTipTitleItem20)
        SuperToolTip20.Items.Add(ToolTipItem20)
        Me.MakeTextUpperCaseItem1.SuperTip = SuperToolTip20
        '
        'MakeTextLowerCaseItem1
        '
        Me.MakeTextLowerCaseItem1.Caption = "lowercase"
        Me.MakeTextLowerCaseItem1.Id = 28
        Me.MakeTextLowerCaseItem1.Name = "MakeTextLowerCaseItem1"
        ToolTipTitleItem21.Text = "lowercase"
        ToolTipItem21.Text = "Change all the selected text to lowercase."
        SuperToolTip21.Items.Add(ToolTipTitleItem21)
        SuperToolTip21.Items.Add(ToolTipItem21)
        Me.MakeTextLowerCaseItem1.SuperTip = SuperToolTip21
        '
        'ToggleTextCaseItem1
        '
        Me.ToggleTextCaseItem1.Caption = "tOGGLE cASE"
        Me.ToggleTextCaseItem1.Id = 29
        Me.ToggleTextCaseItem1.Name = "ToggleTextCaseItem1"
        ToolTipTitleItem22.Text = "tOGGLE cASE"
        ToolTipItem22.Text = "tOGGLE cASE."
        SuperToolTip22.Items.Add(ToolTipTitleItem22)
        SuperToolTip22.Items.Add(ToolTipItem22)
        Me.ToggleTextCaseItem1.SuperTip = SuperToolTip22
        '
        'ClearFormattingItem1
        '
        Me.ClearFormattingItem1.Caption = "Clear Formatting"
        Me.ClearFormattingItem1.Id = 30
        Me.ClearFormattingItem1.Name = "ClearFormattingItem1"
        ToolTipTitleItem23.Text = "Clear Formatting (Ctrl+Space)"
        ToolTipItem23.Text = "Clear all the formatting from the selection, leaving only plain text."
        SuperToolTip23.Items.Add(ToolTipTitleItem23)
        SuperToolTip23.Items.Add(ToolTipItem23)
        Me.ClearFormattingItem1.SuperTip = SuperToolTip23
        '
        'BarButtonGroup4
        '
        Me.BarButtonGroup4.Id = 4
        Me.BarButtonGroup4.Name = "BarButtonGroup4"
        Me.BarButtonGroup4.Tag = "{0B3A7A43-3079-4ce0-83A8-3789F5F6DC9F}"
        '
        'ToggleBulletedListItem1
        '
        Me.ToggleBulletedListItem1.Caption = "Bullets"
        Me.ToggleBulletedListItem1.Id = 31
        Me.ToggleBulletedListItem1.Name = "ToggleBulletedListItem1"
        ToolTipTitleItem24.Text = "Bullets"
        ToolTipItem24.Text = "Start a bulleted list."
        SuperToolTip24.Items.Add(ToolTipTitleItem24)
        SuperToolTip24.Items.Add(ToolTipItem24)
        Me.ToggleBulletedListItem1.SuperTip = SuperToolTip24
        '
        'ToggleNumberingListItem1
        '
        Me.ToggleNumberingListItem1.Caption = "Numbering"
        Me.ToggleNumberingListItem1.Id = 32
        Me.ToggleNumberingListItem1.Name = "ToggleNumberingListItem1"
        ToolTipTitleItem25.Text = "Numbering"
        ToolTipItem25.Text = "Start a numbered list."
        SuperToolTip25.Items.Add(ToolTipTitleItem25)
        SuperToolTip25.Items.Add(ToolTipItem25)
        Me.ToggleNumberingListItem1.SuperTip = SuperToolTip25
        '
        'ToggleMultiLevelListItem1
        '
        Me.ToggleMultiLevelListItem1.Caption = "Multilevel list"
        Me.ToggleMultiLevelListItem1.Id = 33
        Me.ToggleMultiLevelListItem1.Name = "ToggleMultiLevelListItem1"
        ToolTipTitleItem26.Text = "Multilevel list"
        ToolTipItem26.Text = "Start a multilevel list."
        SuperToolTip26.Items.Add(ToolTipTitleItem26)
        SuperToolTip26.Items.Add(ToolTipItem26)
        Me.ToggleMultiLevelListItem1.SuperTip = SuperToolTip26
        '
        'BarButtonGroup5
        '
        Me.BarButtonGroup5.Id = 5
        Me.BarButtonGroup5.Name = "BarButtonGroup5"
        Me.BarButtonGroup5.Tag = "{4747D5AB-2BEB-4ea6-9A1D-8E4FB36F1B40}"
        '
        'DecreaseIndentItem1
        '
        Me.DecreaseIndentItem1.Caption = "Decrease Indent"
        Me.DecreaseIndentItem1.Id = 34
        Me.DecreaseIndentItem1.Name = "DecreaseIndentItem1"
        ToolTipTitleItem27.Text = "Decrease Indent"
        ToolTipItem27.Text = "Decrease the indent level of the paragraph."
        SuperToolTip27.Items.Add(ToolTipTitleItem27)
        SuperToolTip27.Items.Add(ToolTipItem27)
        Me.DecreaseIndentItem1.SuperTip = SuperToolTip27
        '
        'IncreaseIndentItem1
        '
        Me.IncreaseIndentItem1.Caption = "Increase Indent"
        Me.IncreaseIndentItem1.Id = 35
        Me.IncreaseIndentItem1.Name = "IncreaseIndentItem1"
        ToolTipTitleItem28.Text = "Increase Indent"
        ToolTipItem28.Text = "Increase the indent level of the paragraph."
        SuperToolTip28.Items.Add(ToolTipTitleItem28)
        SuperToolTip28.Items.Add(ToolTipItem28)
        Me.IncreaseIndentItem1.SuperTip = SuperToolTip28
        '
        'BarButtonGroup6
        '
        Me.BarButtonGroup6.Id = 6
        Me.BarButtonGroup6.Name = "BarButtonGroup6"
        Me.BarButtonGroup6.Tag = "{8E89E775-996E-49a0-AADA-DE338E34732E}"
        '
        'ToggleParagraphAlignmentLeftItem1
        '
        Me.ToggleParagraphAlignmentLeftItem1.Caption = "Align Text Left"
        Me.ToggleParagraphAlignmentLeftItem1.Id = 37
        Me.ToggleParagraphAlignmentLeftItem1.Name = "ToggleParagraphAlignmentLeftItem1"
        ToolTipTitleItem29.Text = "Align Text Left (Ctrl+L)"
        ToolTipItem29.Text = "Align text to the left."
        SuperToolTip29.Items.Add(ToolTipTitleItem29)
        SuperToolTip29.Items.Add(ToolTipItem29)
        Me.ToggleParagraphAlignmentLeftItem1.SuperTip = SuperToolTip29
        '
        'ToggleParagraphAlignmentCenterItem1
        '
        Me.ToggleParagraphAlignmentCenterItem1.Caption = "Center"
        Me.ToggleParagraphAlignmentCenterItem1.Id = 38
        Me.ToggleParagraphAlignmentCenterItem1.Name = "ToggleParagraphAlignmentCenterItem1"
        ToolTipTitleItem30.Text = "Center (Ctrl+E)"
        ToolTipItem30.Text = "Center text."
        SuperToolTip30.Items.Add(ToolTipTitleItem30)
        SuperToolTip30.Items.Add(ToolTipItem30)
        Me.ToggleParagraphAlignmentCenterItem1.SuperTip = SuperToolTip30
        '
        'ToggleParagraphAlignmentRightItem1
        '
        Me.ToggleParagraphAlignmentRightItem1.Caption = "Align Text Right"
        Me.ToggleParagraphAlignmentRightItem1.Id = 39
        Me.ToggleParagraphAlignmentRightItem1.Name = "ToggleParagraphAlignmentRightItem1"
        ToolTipTitleItem31.Text = "Align Text Right (Ctrl+R)"
        ToolTipItem31.Text = "Align text to the right."
        SuperToolTip31.Items.Add(ToolTipTitleItem31)
        SuperToolTip31.Items.Add(ToolTipItem31)
        Me.ToggleParagraphAlignmentRightItem1.SuperTip = SuperToolTip31
        '
        'ToggleParagraphAlignmentJustifyItem1
        '
        Me.ToggleParagraphAlignmentJustifyItem1.Caption = "Justify"
        Me.ToggleParagraphAlignmentJustifyItem1.Id = 40
        Me.ToggleParagraphAlignmentJustifyItem1.Name = "ToggleParagraphAlignmentJustifyItem1"
        ToolTipTitleItem32.Text = "Justify (Ctrl+J)"
        ToolTipItem32.Text = "Align text to both left and right margins, adding extra space between words as ne" & _
    "cessary." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This creates a clean look along the left and right side of the page." & _
    ""
        SuperToolTip32.Items.Add(ToolTipTitleItem32)
        SuperToolTip32.Items.Add(ToolTipItem32)
        Me.ToggleParagraphAlignmentJustifyItem1.SuperTip = SuperToolTip32
        '
        'ToggleShowWhitespaceItem1
        '
        Me.ToggleShowWhitespaceItem1.Caption = "Show/Hide ¶"
        Me.ToggleShowWhitespaceItem1.Id = 36
        Me.ToggleShowWhitespaceItem1.Name = "ToggleShowWhitespaceItem1"
        ToolTipTitleItem33.Text = "Show/Hide ¶ (Ctrl+Mayús.+8)"
        ToolTipItem33.Text = "Show paragraph marks and other hidden formatting symbols."
        SuperToolTip33.Items.Add(ToolTipTitleItem33)
        SuperToolTip33.Items.Add(ToolTipItem33)
        Me.ToggleShowWhitespaceItem1.SuperTip = SuperToolTip33
        '
        'BarButtonGroup7
        '
        Me.BarButtonGroup7.Id = 7
        Me.BarButtonGroup7.Name = "BarButtonGroup7"
        Me.BarButtonGroup7.Tag = "{9A8DEAD8-3890-4857-A395-EC625FD02217}"
        '
        'ChangeParagraphLineSpacingItem1
        '
        Me.ChangeParagraphLineSpacingItem1.Caption = "Line Spacing"
        Me.ChangeParagraphLineSpacingItem1.Id = 41
        Me.ChangeParagraphLineSpacingItem1.Name = "ChangeParagraphLineSpacingItem1"
        ToolTipTitleItem34.Text = "Line Spacing"
        ToolTipItem34.Text = "Change the spacing between lines of text." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can also customize the amount of" & _
    " space added before and after paragraphs."
        SuperToolTip34.Items.Add(ToolTipTitleItem34)
        SuperToolTip34.Items.Add(ToolTipItem34)
        Me.ChangeParagraphLineSpacingItem1.SuperTip = SuperToolTip34
        '
        'SetSingleParagraphSpacingItem1
        '
        Me.SetSingleParagraphSpacingItem1.Caption = "1.0"
        Me.SetSingleParagraphSpacingItem1.Id = 42
        Me.SetSingleParagraphSpacingItem1.Name = "SetSingleParagraphSpacingItem1"
        ToolTipTitleItem35.Text = "1.0 (Ctrl+1)"
        ToolTipItem35.Text = " "
        SuperToolTip35.Items.Add(ToolTipTitleItem35)
        SuperToolTip35.Items.Add(ToolTipItem35)
        Me.SetSingleParagraphSpacingItem1.SuperTip = SuperToolTip35
        '
        'SetSesquialteralParagraphSpacingItem1
        '
        Me.SetSesquialteralParagraphSpacingItem1.Caption = "1.5"
        Me.SetSesquialteralParagraphSpacingItem1.Id = 43
        Me.SetSesquialteralParagraphSpacingItem1.Name = "SetSesquialteralParagraphSpacingItem1"
        ToolTipTitleItem36.Text = "1.5 (Ctrl+5)"
        ToolTipItem36.Text = " "
        SuperToolTip36.Items.Add(ToolTipTitleItem36)
        SuperToolTip36.Items.Add(ToolTipItem36)
        Me.SetSesquialteralParagraphSpacingItem1.SuperTip = SuperToolTip36
        '
        'SetDoubleParagraphSpacingItem1
        '
        Me.SetDoubleParagraphSpacingItem1.Caption = "2.0"
        Me.SetDoubleParagraphSpacingItem1.Id = 44
        Me.SetDoubleParagraphSpacingItem1.Name = "SetDoubleParagraphSpacingItem1"
        ToolTipTitleItem37.Text = "2.0 (Ctrl+2)"
        ToolTipItem37.Text = " "
        SuperToolTip37.Items.Add(ToolTipTitleItem37)
        SuperToolTip37.Items.Add(ToolTipItem37)
        Me.SetDoubleParagraphSpacingItem1.SuperTip = SuperToolTip37
        '
        'ShowLineSpacingFormItem1
        '
        Me.ShowLineSpacingFormItem1.Caption = "Line Spacing Options..."
        Me.ShowLineSpacingFormItem1.Id = 45
        Me.ShowLineSpacingFormItem1.Name = "ShowLineSpacingFormItem1"
        ToolTipTitleItem38.Text = "Line Spacing Options..."
        ToolTipItem38.Text = " "
        SuperToolTip38.Items.Add(ToolTipTitleItem38)
        SuperToolTip38.Items.Add(ToolTipItem38)
        Me.ShowLineSpacingFormItem1.SuperTip = SuperToolTip38
        '
        'AddSpacingBeforeParagraphItem1
        '
        Me.AddSpacingBeforeParagraphItem1.Caption = "Add Space &Before Paragraph"
        Me.AddSpacingBeforeParagraphItem1.Id = 46
        Me.AddSpacingBeforeParagraphItem1.Name = "AddSpacingBeforeParagraphItem1"
        ToolTipTitleItem39.Text = "Add Space &Before Paragraph"
        ToolTipItem39.Text = " "
        SuperToolTip39.Items.Add(ToolTipTitleItem39)
        SuperToolTip39.Items.Add(ToolTipItem39)
        Me.AddSpacingBeforeParagraphItem1.SuperTip = SuperToolTip39
        '
        'RemoveSpacingBeforeParagraphItem1
        '
        Me.RemoveSpacingBeforeParagraphItem1.Caption = "Remove Space &Before Paragraph"
        Me.RemoveSpacingBeforeParagraphItem1.Id = 47
        Me.RemoveSpacingBeforeParagraphItem1.Name = "RemoveSpacingBeforeParagraphItem1"
        ToolTipTitleItem40.Text = "Remove Space &Before Paragraph"
        ToolTipItem40.Text = " "
        SuperToolTip40.Items.Add(ToolTipTitleItem40)
        SuperToolTip40.Items.Add(ToolTipItem40)
        Me.RemoveSpacingBeforeParagraphItem1.SuperTip = SuperToolTip40
        '
        'AddSpacingAfterParagraphItem1
        '
        Me.AddSpacingAfterParagraphItem1.Caption = "Add Space &After Paragraph"
        Me.AddSpacingAfterParagraphItem1.Id = 48
        Me.AddSpacingAfterParagraphItem1.Name = "AddSpacingAfterParagraphItem1"
        ToolTipTitleItem41.Text = "Add Space &After Paragraph"
        ToolTipItem41.Text = " "
        SuperToolTip41.Items.Add(ToolTipTitleItem41)
        SuperToolTip41.Items.Add(ToolTipItem41)
        Me.AddSpacingAfterParagraphItem1.SuperTip = SuperToolTip41
        '
        'RemoveSpacingAfterParagraphItem1
        '
        Me.RemoveSpacingAfterParagraphItem1.Caption = "Remove Space &After Paragraph"
        Me.RemoveSpacingAfterParagraphItem1.Id = 49
        Me.RemoveSpacingAfterParagraphItem1.Name = "RemoveSpacingAfterParagraphItem1"
        ToolTipTitleItem42.Text = "Remove Space &After Paragraph"
        ToolTipItem42.Text = " "
        SuperToolTip42.Items.Add(ToolTipTitleItem42)
        SuperToolTip42.Items.Add(ToolTipItem42)
        Me.RemoveSpacingAfterParagraphItem1.SuperTip = SuperToolTip42
        '
        'ChangeParagraphBackColorItem1
        '
        Me.ChangeParagraphBackColorItem1.Caption = "Shading"
        Me.ChangeParagraphBackColorItem1.Id = 50
        Me.ChangeParagraphBackColorItem1.Name = "ChangeParagraphBackColorItem1"
        ToolTipTitleItem43.Text = "Shading"
        ToolTipItem43.Text = "Change the background behind the selected paragraph."
        SuperToolTip43.Items.Add(ToolTipTitleItem43)
        SuperToolTip43.Items.Add(ToolTipItem43)
        Me.ChangeParagraphBackColorItem1.SuperTip = SuperToolTip43
        '
        'GalleryChangeStyleItem1
        '
        Me.GalleryChangeStyleItem1.Caption = "Quick Styles"
        '
        '
        '
        Me.GalleryChangeStyleItem1.Gallery.ColumnCount = 10
        Me.GalleryChangeStyleItem1.Gallery.Groups.AddRange(New DevExpress.XtraBars.Ribbon.GalleryItemGroup() {GalleryItemGroup1})
        Me.GalleryChangeStyleItem1.Gallery.ImageSize = New System.Drawing.Size(65, 46)
        Me.GalleryChangeStyleItem1.Id = 51
        Me.GalleryChangeStyleItem1.Name = "GalleryChangeStyleItem1"
        '
        'FindItem1
        '
        Me.FindItem1.Caption = "Find"
        Me.FindItem1.Id = 52
        Me.FindItem1.Name = "FindItem1"
        ToolTipTitleItem44.Text = "Find (Ctrl+F)"
        ToolTipItem44.Text = "Find text in the document."
        SuperToolTip44.Items.Add(ToolTipTitleItem44)
        SuperToolTip44.Items.Add(ToolTipItem44)
        Me.FindItem1.SuperTip = SuperToolTip44
        '
        'ReplaceItem1
        '
        Me.ReplaceItem1.Caption = "Replace"
        Me.ReplaceItem1.Id = 53
        Me.ReplaceItem1.Name = "ReplaceItem1"
        ToolTipTitleItem45.Text = "Replace (Ctrl+H)"
        ToolTipItem45.Text = "Replace text in the document."
        SuperToolTip45.Items.Add(ToolTipTitleItem45)
        SuperToolTip45.Items.Add(ToolTipItem45)
        Me.ReplaceItem1.SuperTip = SuperToolTip45
        '
        'RibbonControl1
        '
        '
        '
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.PasteItem1, Me.CutItem1, Me.CopyItem1, Me.PasteSpecialItem1, Me.BarButtonGroup1, Me.ChangeFontNameItem1, Me.ChangeFontSizeItem1, Me.FontSizeIncreaseItem1, Me.FontSizeDecreaseItem1, Me.BarButtonGroup2, Me.ToggleFontBoldItem1, Me.ToggleFontItalicItem1, Me.ToggleFontUnderlineItem1, Me.ToggleFontDoubleUnderlineItem1, Me.ToggleFontStrikeoutItem1, Me.ToggleFontDoubleStrikeoutItem1, Me.ToggleFontSuperscriptItem1, Me.ToggleFontSubscriptItem1, Me.BarButtonGroup3, Me.ChangeFontColorItem1, Me.ChangeFontBackColorItem1, Me.ChangeTextCaseItem1, Me.MakeTextUpperCaseItem1, Me.MakeTextLowerCaseItem1, Me.ToggleTextCaseItem1, Me.ClearFormattingItem1, Me.BarButtonGroup4, Me.ToggleBulletedListItem1, Me.ToggleNumberingListItem1, Me.ToggleMultiLevelListItem1, Me.BarButtonGroup5, Me.DecreaseIndentItem1, Me.IncreaseIndentItem1, Me.BarButtonGroup6, Me.ToggleParagraphAlignmentLeftItem1, Me.ToggleParagraphAlignmentCenterItem1, Me.ToggleParagraphAlignmentRightItem1, Me.ToggleParagraphAlignmentJustifyItem1, Me.ToggleShowWhitespaceItem1, Me.BarButtonGroup7, Me.ChangeParagraphLineSpacingItem1, Me.SetSingleParagraphSpacingItem1, Me.SetSesquialteralParagraphSpacingItem1, Me.SetDoubleParagraphSpacingItem1, Me.ShowLineSpacingFormItem1, Me.AddSpacingBeforeParagraphItem1, Me.RemoveSpacingBeforeParagraphItem1, Me.AddSpacingAfterParagraphItem1, Me.RemoveSpacingAfterParagraphItem1, Me.ChangeParagraphBackColorItem1, Me.GalleryChangeStyleItem1, Me.FindItem1, Me.ReplaceItem1})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 54
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.HomeRibbonPage1})
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemFontEdit1, Me.RepositoryItemRichEditFontSizeEdit1})
        Me.RibbonControl1.Size = New System.Drawing.Size(995, 142)
        '
        'frmInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 672)
        Me.Controls.Add(Me.cboTipoPaciente)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtCorrelativo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lvHistorial)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboMedico)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtInforme)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblEdad)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblSexo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblPaciente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblHistoria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvTabla)
        Me.Controls.Add(Me.txtPaciente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInforme"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Electroencefalograma"
        CType(Me.RichEditBarController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvTabla As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtPaciente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHistoria As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPaciente As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSexo As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboMedico As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lvHistorial As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ppdVistaPrevia As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pdcDocumento As System.Drawing.Printing.PrintDocument
    Friend WithEvents Fuente As System.Windows.Forms.FontDialog
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCorrelativo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPaciente As System.Windows.Forms.ComboBox
    Private WithEvents txtInforme As DevExpress.XtraRichEdit.RichEditControl
    Private WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Private WithEvents PasteItem1 As DevExpress.XtraRichEdit.UI.PasteItem
    Private WithEvents CutItem1 As DevExpress.XtraRichEdit.UI.CutItem
    Private WithEvents CopyItem1 As DevExpress.XtraRichEdit.UI.CopyItem
    Private WithEvents PasteSpecialItem1 As DevExpress.XtraRichEdit.UI.PasteSpecialItem
    Private WithEvents BarButtonGroup1 As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents ChangeFontNameItem1 As DevExpress.XtraRichEdit.UI.ChangeFontNameItem
    Private WithEvents RepositoryItemFontEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemFontEdit
    Private WithEvents ChangeFontSizeItem1 As DevExpress.XtraRichEdit.UI.ChangeFontSizeItem
    Private WithEvents RepositoryItemRichEditFontSizeEdit1 As DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit
    Private WithEvents FontSizeIncreaseItem1 As DevExpress.XtraRichEdit.UI.FontSizeIncreaseItem
    Private WithEvents FontSizeDecreaseItem1 As DevExpress.XtraRichEdit.UI.FontSizeDecreaseItem
    Private WithEvents BarButtonGroup2 As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents ToggleFontBoldItem1 As DevExpress.XtraRichEdit.UI.ToggleFontBoldItem
    Private WithEvents ToggleFontItalicItem1 As DevExpress.XtraRichEdit.UI.ToggleFontItalicItem
    Private WithEvents ToggleFontUnderlineItem1 As DevExpress.XtraRichEdit.UI.ToggleFontUnderlineItem
    Private WithEvents ToggleFontDoubleUnderlineItem1 As DevExpress.XtraRichEdit.UI.ToggleFontDoubleUnderlineItem
    Private WithEvents ToggleFontStrikeoutItem1 As DevExpress.XtraRichEdit.UI.ToggleFontStrikeoutItem
    Private WithEvents ToggleFontDoubleStrikeoutItem1 As DevExpress.XtraRichEdit.UI.ToggleFontDoubleStrikeoutItem
    Private WithEvents ToggleFontSuperscriptItem1 As DevExpress.XtraRichEdit.UI.ToggleFontSuperscriptItem
    Private WithEvents ToggleFontSubscriptItem1 As DevExpress.XtraRichEdit.UI.ToggleFontSubscriptItem
    Private WithEvents BarButtonGroup3 As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents ChangeFontColorItem1 As DevExpress.XtraRichEdit.UI.ChangeFontColorItem
    Private WithEvents ChangeFontBackColorItem1 As DevExpress.XtraRichEdit.UI.ChangeFontBackColorItem
    Private WithEvents ChangeTextCaseItem1 As DevExpress.XtraRichEdit.UI.ChangeTextCaseItem
    Private WithEvents MakeTextUpperCaseItem1 As DevExpress.XtraRichEdit.UI.MakeTextUpperCaseItem
    Private WithEvents MakeTextLowerCaseItem1 As DevExpress.XtraRichEdit.UI.MakeTextLowerCaseItem
    Private WithEvents ToggleTextCaseItem1 As DevExpress.XtraRichEdit.UI.ToggleTextCaseItem
    Private WithEvents ClearFormattingItem1 As DevExpress.XtraRichEdit.UI.ClearFormattingItem
    Private WithEvents BarButtonGroup4 As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents ToggleBulletedListItem1 As DevExpress.XtraRichEdit.UI.ToggleBulletedListItem
    Private WithEvents ToggleNumberingListItem1 As DevExpress.XtraRichEdit.UI.ToggleNumberingListItem
    Private WithEvents ToggleMultiLevelListItem1 As DevExpress.XtraRichEdit.UI.ToggleMultiLevelListItem
    Private WithEvents BarButtonGroup5 As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents DecreaseIndentItem1 As DevExpress.XtraRichEdit.UI.DecreaseIndentItem
    Private WithEvents IncreaseIndentItem1 As DevExpress.XtraRichEdit.UI.IncreaseIndentItem
    Private WithEvents BarButtonGroup6 As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents ToggleParagraphAlignmentLeftItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentLeftItem
    Private WithEvents ToggleParagraphAlignmentCenterItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentCenterItem
    Private WithEvents ToggleParagraphAlignmentRightItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentRightItem
    Private WithEvents ToggleParagraphAlignmentJustifyItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphAlignmentJustifyItem
    Private WithEvents ToggleShowWhitespaceItem1 As DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem
    Private WithEvents BarButtonGroup7 As DevExpress.XtraBars.BarButtonGroup
    Private WithEvents ChangeParagraphLineSpacingItem1 As DevExpress.XtraRichEdit.UI.ChangeParagraphLineSpacingItem
    Private WithEvents SetSingleParagraphSpacingItem1 As DevExpress.XtraRichEdit.UI.SetSingleParagraphSpacingItem
    Private WithEvents SetSesquialteralParagraphSpacingItem1 As DevExpress.XtraRichEdit.UI.SetSesquialteralParagraphSpacingItem
    Private WithEvents SetDoubleParagraphSpacingItem1 As DevExpress.XtraRichEdit.UI.SetDoubleParagraphSpacingItem
    Private WithEvents ShowLineSpacingFormItem1 As DevExpress.XtraRichEdit.UI.ShowLineSpacingFormItem
    Private WithEvents AddSpacingBeforeParagraphItem1 As DevExpress.XtraRichEdit.UI.AddSpacingBeforeParagraphItem
    Private WithEvents RemoveSpacingBeforeParagraphItem1 As DevExpress.XtraRichEdit.UI.RemoveSpacingBeforeParagraphItem
    Private WithEvents AddSpacingAfterParagraphItem1 As DevExpress.XtraRichEdit.UI.AddSpacingAfterParagraphItem
    Private WithEvents RemoveSpacingAfterParagraphItem1 As DevExpress.XtraRichEdit.UI.RemoveSpacingAfterParagraphItem
    Private WithEvents ChangeParagraphBackColorItem1 As DevExpress.XtraRichEdit.UI.ChangeParagraphBackColorItem
    Private WithEvents GalleryChangeStyleItem1 As DevExpress.XtraRichEdit.UI.GalleryChangeStyleItem
    Private WithEvents FindItem1 As DevExpress.XtraRichEdit.UI.FindItem
    Private WithEvents ReplaceItem1 As DevExpress.XtraRichEdit.UI.ReplaceItem
    Private WithEvents HomeRibbonPage1 As DevExpress.XtraRichEdit.UI.HomeRibbonPage
    Private WithEvents RichEditBarController1 As DevExpress.XtraRichEdit.UI.RichEditBarController
    Private WithEvents EditingRibbonPageGroup1 As DevExpress.XtraRichEdit.UI.EditingRibbonPageGroup
    Private WithEvents StylesRibbonPageGroup1 As DevExpress.XtraRichEdit.UI.StylesRibbonPageGroup
    Private WithEvents ParagraphRibbonPageGroup1 As DevExpress.XtraRichEdit.UI.ParagraphRibbonPageGroup
    Private WithEvents FontRibbonPageGroup1 As DevExpress.XtraRichEdit.UI.FontRibbonPageGroup
    Private WithEvents ClipboardRibbonPageGroup1 As DevExpress.XtraRichEdit.UI.ClipboardRibbonPageGroup
End Class
