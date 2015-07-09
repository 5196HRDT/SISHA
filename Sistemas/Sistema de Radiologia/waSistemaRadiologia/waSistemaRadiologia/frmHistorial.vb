Public Class frmHistorial
    Dim objHistoria As New clsHistoria
    Dim objInforme As New clsCitaRayosXImg

    'Variables Impresion
    Dim FuenteTitulo As New Font("Courier New", 14, FontStyle.Bold)
    Dim FuenteTexto As New Font("Courier New", 10)
    Dim FuenteTextoR As New Font("Courier New", 12, FontStyle.Bold)
    Dim FuenteTextoN As New Font("Courier New", 10, FontStyle.Bold)
    Dim FuenteEnc As New Font("Courier New", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim X, Y As Integer

    Dim objCaja As New RichTextBoxEx
    Dim StringToPrint As String
    Private m_nFirstCharOnPage As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmHistorial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbPaciente.Visible = False
        cboTipo.Text = "RADIOGRAFIA"
        txtInforme.Enabled = False
    End Sub

    Private Sub btnPaciente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaciente.Click
        txtPaciente.Text = ""
        gbPaciente.Visible = True
        txtPaciente.Select()
    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            lvPaciente.Items.Clear()
            Dim dsHistoria As New DataSet
            dsHistoria = objHistoria.BuscarPaciente(txtPaciente.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            If dsHistoria.Tables(0).Rows.Count > 15000 Then MessageBox.Show("Se mas específico en su búsqueda", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtPaciente.Select() : Exit Sub
            lvPaciente.BeginUpdate()
            For I = 0 To dsHistoria.Tables(0).Rows.Count - 1
                Fila = lvPaciente.Items.Add(dsHistoria.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("Apaterno") & " " & dsHistoria.Tables(0).Rows(I)("Amaterno") & dsHistoria.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("Sexo"))
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("NomPadre").ToString)
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("NomMadre").ToString)
            Next
            lvPaciente.EndUpdate()
        End If
    End Sub

    Private Sub lvPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If lvPaciente.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            lblHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            lblPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text
            gbPaciente.Visible = False
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged
        lvInforme.Items.Clear()
        If lvPaciente.SelectedItems.Count = 0 Then Exit Sub
        If cboTipo.Text = "" Then MessageBox.Show("Debe seleccionar tipo de Diagnóstico de Imagen", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim dsLista As New DataSet
        dsLista = objInforme.InformeWeb(lvPaciente.SelectedItems(0).SubItems(0).Text, cboTipo.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsLista.Tables(0).Rows.Count - 1
            Fila = lvInforme.Items.Add(dsLista.Tables(0).Rows(I)("IdImagenes"))
            Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("FechaExamen"))
            Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("Titulo"))
            Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("TipoPac").ToString)
        Next
    End Sub

    Private Sub lvInforme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvInforme.SelectedIndexChanged
        If lvInforme.SelectedItems.Count > 0 Then
            Dim dsVer As New DataSet
            dsVer = objInforme.BuscarId(lvInforme.SelectedItems(0).SubItems(0).Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                lblTipo.Text = dsVer.Tables(0).Rows(0)("TipoPac").ToString
                lblEdad.Text = dsVer.Tables(0).Rows(0)("Edad").ToString
                lblSexo.Text = dsVer.Tables(0).Rows(0)("Sexo").ToString
                lblServicio.Text = dsVer.Tables(0).Rows(0)("Especialidad").ToString
                lblSubServicio.Text = dsVer.Tables(0).Rows(0)("SubEspecialidad").ToString
                txtExámenes.Text = dsVer.Tables(0).Rows(0)("Titulo").ToString
                txtInforme.Text = dsVer.Tables(0).Rows(0)("Descripcion").ToString
                cboTecnico.Text = dsVer.Tables(0).Rows(0)("Tecnologo").ToString
                cboRadiologo.Text = dsVer.Tables(0).Rows(0)("Radiologo").ToString
                cboSecretaria.Text = dsVer.Tables(0).Rows(0)("Secretaria").ToString
                cboMedico.Text = dsVer.Tables(0).Rows(0)("MedicoSol").ToString
                txtIndicacion.Text = dsVer.Tables(0).Rows(0)("Antecedentes").ToString
                lblCie1.Text = dsVer.Tables(0).Rows(0)("Cie1").ToString
                lblCie2.Text = dsVer.Tables(0).Rows(0)("Cie2").ToString
                lblCie3.Text = dsVer.Tables(0).Rows(0)("Cie3").ToString
            End If
        End If
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then btnPaciente.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        objCaja.Rtf = txtInforme.Rtf
        m_nFirstCharOnPage = 0
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Y = 30
        With e.Graphics
            .DrawString("Hospital Regional Docente de Trujillo" & StrDup(30, " ") & "DEPARTAMENTO DE DIAGNOSTICO POR IMAGENES", FuenteEnc, Pincel, 60, Y)
            Y = Y + 30
            .DrawString("INFORME DE " & cboTipo.Text, FuenteTitulo, Pincel, 200, Y)
            .DrawString("Fecha: " & Date.Now.ToShortDateString, FuenteEnc, Pincel, 600, Y - 15)
            .DrawString("Hora : " & Date.Now.ToShortTimeString, FuenteEnc, Pincel, 600, Y)
            Y = Y + 40
            .DrawString("Historia   : ", FuenteTexto, Pincel, 60, Y)
            .DrawString(lblHistoria.Text, FuenteTextoR, Pincel, 185, Y)
            Y = Y + 25
            .DrawString("Paciente   : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & lblPaciente.Text, FuenteTextoN, Pincel, 150, Y)
            Y = Y + 25
            .DrawString("Edad       : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & lblEdad.Text, FuenteTextoN, Pincel, 150, Y)
            .DrawString("Sexo   : ", FuenteTexto, Pincel, 480, Y)
            .DrawString(lblSexo.Text, FuenteTextoN, Pincel, 560, Y)
            Y = Y + 25
            .DrawString("Servicio   : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & lblServicio.Text, FuenteTextoN, Pincel, 150, Y)
            .DrawString("SubSer.: ", FuenteTexto, Pincel, 480, Y)
            .DrawString(Microsoft.VisualBasic.Left(lblSubServicio.Text & StrDup(26, " "), 26), FuenteTextoN, Pincel, 560, Y)
            Y = Y + 25
            .DrawString("Radiólogo  : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & cboRadiologo.Text, FuenteTextoN, Pincel, 150, Y)
            .DrawString("Técnico: ", FuenteTexto, Pincel, 480, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboTecnico.Text & StrDup(26, " "), 26), FuenteTextoN, Pincel, 560, Y)
            Y = Y + 25
            .DrawString("Medico Sol.: ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & Microsoft.VisualBasic.Left(cboMedico.Text & StrDup(35, " "), 35), FuenteTextoN, Pincel, 150, Y)
            .DrawString("Secret.: ", FuenteTexto, Pincel, 480, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboSecretaria.Text & StrDup(26, " "), 26), FuenteTextoN, Pincel, 560, Y)

            Dim Aux As String = ""

            'Indicación
            Y = Y + 25
            Aux = "Indicación : " & txtIndicacion.Text
            If Aux.Length <= 80 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(80, "-"), 80), FuenteTextoN, Pincel, 60, Y)
                Y = Y + 25
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 80), FuenteTextoN, Pincel, 60, Y)
                Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 80)
                Y = Y + 25
                Do While Aux.Length > 50
                    .DrawString(Microsoft.VisualBasic.Left(Aux, 80), FuenteTextoN, Pincel, 60, Y)
                    Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 80)
                    Y = Y + 25
                Loop
                .DrawString(Aux, FuenteTextoN, Pincel, 60, Y)
                Y = Y + 25
            End If

            'Titulo
            Aux = "Exámen(es) : " & txtExámenes.Text
            If Aux.Length <= 80 Then
                .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(80, "-"), 80), FuenteTextoN, Pincel, 60, Y)
                Y = Y + 25
            Else
                .DrawString(Microsoft.VisualBasic.Left(Aux, 80), FuenteTextoN, Pincel, 60, Y)
                Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 80)
                Y = Y + 25
                Do While Aux.Length > 80
                    .DrawString(Microsoft.VisualBasic.Left(Aux, 80), FuenteTextoN, Pincel, 60, Y)
                    Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 80)
                    Y = Y + 25
                Loop
                .DrawString(Aux, FuenteTextoN, Pincel, 60, Y)
                Y = Y + 25
            End If

            .DrawString("INFORME", FuenteTextoR, Pincel, 350, Y)

            'Informe
            'Y = Y + 25
            'Aux = Replace(txtInforme.Text, vbLf, "")

            'If Aux.Length <= 80 Then
            '    .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(80, "-"), 80), FuenteTextoN, Pincel, 60, Y)
            '    Y = Y + 20
            'Else
            '    .DrawString(Microsoft.VisualBasic.Left(Aux, 80), FuenteTextoN, Pincel, 60, Y)
            '    Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 80)
            '    Y = Y + 20
            '    Do While Aux.Length > 80
            '        .DrawString(Microsoft.VisualBasic.Left(Aux, 80), FuenteTextoN, Pincel, 60, Y)
            '        Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 80)
            '        Y = Y + 20
            '    Loop
            '    .DrawString(Aux, FuenteTextoN, Pincel, 60, Y)
            '    Y = Y + 20
            'End If

            m_nFirstCharOnPage = objCaja.FormatRange(False, e, m_nFirstCharOnPage, objCaja.TextLength)
            If (m_nFirstCharOnPage < objCaja.TextLength) Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If

        End With
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        txtPaciente.Text = ""
        lvPaciente.Items.Clear()
        gbPaciente.Visible = False
    End Sub
End Class