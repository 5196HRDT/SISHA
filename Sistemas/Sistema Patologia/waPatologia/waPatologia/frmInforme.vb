Public Class frmInforme
    Dim objInforme As New clsInforme
    Dim objFormato As New clsFormatoInforme
    Dim objServicio As New Servicio
    Dim objMedico As New clsMedico
    Dim objHistoria As New clsHistoria
    Dim objNumeroRegistro As New clsNumeroRegistro
    Dim objCie As New clsCIE10
    Dim objTipoTarifar As New clsTipoTarifa
    Dim objCiePatologico As New clsCiePatologico

    Dim I As Integer
    Dim Fila As ListViewItem

    Dim Oper As Integer
    Dim CodLocal As String
    Dim CodNumeroRegistro As String

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

    Private Sub Buscar(ByVal Filtro As String)
        lvTabla.Items.Clear()
        If txtFiltro.Text.Length < 1 Then Exit Sub
        Dim dsTabla As New DataSet
        dsTabla = objInforme.Buscar(Filtro)
        For Me.I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("IdInforme"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("NroRegistro"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("FIngreso"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Sexo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cama"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TipoPaciente"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Medico"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("FEntrega"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Nombre"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Organo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Muestra"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cuerpo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Diagnostico").ToString)
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmInforme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Formato
        Dim dsFormato As New DataSet
        dsFormato = objFormato.Buscar("")
        cboFormato.DataSource = dsFormato.Tables(0)
        cboFormato.DisplayMember = "Nombre"
        cboFormato.ValueMember = "IdFormato"

        'Medico
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Combo("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"

        'Servicio
        Dim dsServicio As New DataSet
        dsServicio = objServicio.Buscar(1, "")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"

        'Tipo Tarifa
        Dim dsTT As New DataSet
        dsTT = objTipoTarifar.Combo
        cboTipoPaciente.DataSource = dsTT.Tables(0)
        cboTipoPaciente.DisplayMember = "Descripcion"
        cboTipoPaciente.ValueMember = "IdTipoTarifa"
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        txtCuerpo.Rtf = ""
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        txtFiltro.Enabled = True
        Buscar(txtFiltro.Text)
        gbConsulta.Visible = False
        lvDX.Items.Clear()
    End Sub

    Private Sub cboAño_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAño.KeyDown
        If e.KeyCode = Keys.Enter And cboAño.Text <> "" Then dtpFechaI.Select()
    End Sub

    Private Sub cboAño_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAño.SelectedIndexChanged
        Dim dsTabla As New DataSet
        dsTabla = objNumeroRegistro.Buscar(cboAño.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lblNumero.Text = dsTabla.Tables(0).Rows(0)("Numero")
            CodNumeroRegistro = dsTabla.Tables(0).Rows(0)("IdNumero")
            lblLugar.Text = "- HD -"
        Else
            MessageBox.Show("No existe Numeración para este año", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblNumero.Text = ""
        End If
    End Sub

    Private Sub dtpFechaI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaI.KeyDown
        If e.KeyCode = Keys.Enter Then cboTipoPaciente.Select()
    End Sub

    Private Sub dtpFechaI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaI.ValueChanged

    End Sub

    Private Sub cboTipoPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoPaciente.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoPaciente.Text <> "" Then cboProcedencia.Select()
    End Sub

    Private Sub cboTipoPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPaciente.SelectedIndexChanged

    End Sub

    Private Sub cboProcedencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProcedencia.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoPaciente.Text <> "" And cboProcedencia.Text <> "" Then txtNumero.Select()
    End Sub

    Private Sub cboProcedencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProcedencia.SelectedIndexChanged

    End Sub

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtNumero.Select()
    End Sub

    Private Sub txtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If IsNumeric(txtNumero.Text) And e.KeyCode = Keys.Enter Then
            Dim dsHistoria As New DataSet
            dsHistoria = objHistoria.Buscar(txtNumero.Text)
            If dsHistoria.Tables(0).Rows.Count > 0 Then
                lblPaciente.Text = dsHistoria.Tables(0).Rows(0)("Apaterno") & " " & dsHistoria.Tables(0).Rows(0)("AMaterno") & " " & dsHistoria.Tables(0).Rows(0)("Nombres")
                lblSexo.Text = dsHistoria.Tables(0).Rows(0)("Sexo")

                'Edad
                Dim Edad As String
                Dim Año As Integer
                Dim Mes As String
                Dim Dia As String

                If dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now) > 0 Then
                        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now)
                        If Año > 1 Then
                            If Microsoft.VisualBasic.Month(dsHistoria.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Month Then
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M"
                            Else
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M"
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsHistoria.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Day Then
                                Edad = 12 - Month(dsHistoria.Tables(0).Rows(0)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsHistoria.Tables(0).Rows(0)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsHistoria.Tables(0).Rows(0)("FNAcimiento")) > Date.Now.Day Then
                                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now)) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsHistoria.Tables(0).Rows(0)("FNAcimiento")) = Date.Now.Day Then
                                Edad = "1 A y 0 D"
                            End If
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsHistoria.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsHistoria.Tables(0).Rows(0)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsHistoria.Tables(0).Rows(0)("FNAcimiento")) > Date.Now.Day Then
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsHistoria.Tables(0).Rows(0)("FNacimiento")) - Date.Now.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsHistoria.Tables(0).Rows(0)("FNAcimiento")) = Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsHistoria.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If
                lblEdad.Text = Edad

                cboServicio.Select()
            Else
                MessageBox.Show("Número de Historia No Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblPaciente.Text = ""
                lblEdad.Text = ""
                lblSexo.Text = ""
                txtNumero.Text = ""
                txtNumero.Select()
            End If
        End If
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        cboAño.Select()
        cboProcedencia.Text = "CONSULTA EXTERNA"
        cboServicio.Text = ""
        cboTipoPaciente.Text = "COMUN"
        lblLugar.Text = "- HD -"
        Oper = 1
    End Sub

    Private Sub cboFormato_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFormato.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboFormato.SelectedValue) Then txtCuerpo.Select()
    End Sub

    Private Sub cboFormato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFormato.SelectedIndexChanged
        If IsNumeric(cboFormato.SelectedValue) Then
            Dim dsInf As New DataSet
            dsInf = objFormato.BuscarId(cboFormato.SelectedValue)
            If dsInf.Tables(0).Rows.Count > 0 Then
                lblOrgano.Text = dsInf.Tables(0).Rows(0)("Organo")
                lblTipoMuestra.Text = dsInf.Tables(0).Rows(0)("TipoMuestra")
                txtCuerpo.Rtf = dsInf.Tables(0).Rows(0)("Cuerpo")
            Else
                lblOrgano.Text = ""
                lblTipoMuestra.Text = ""
                txtCuerpo.Rtf = ""
            End If
        End If
    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And cboServicio.Text <> "" Then txtCama.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged

    End Sub

    Private Sub txtCama_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCama.KeyDown
        If e.KeyCode = Keys.Enter Then cboMedico.Select()
    End Sub

    Private Sub txtCama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCama.TextChanged

    End Sub

    Private Sub cboMedico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboMedico.SelectedValue) Then txtCie.Select()
    End Sub

    Private Sub cboMedico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMedico.SelectedIndexChanged

    End Sub

    Private Sub dtpFechaEntrega_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaEntrega.KeyDown
        If e.KeyCode = Keys.Enter Then cboFormato.Select()
    End Sub

    Private Sub dtpFechaEntrega_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaEntrega.ValueChanged

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar Informe de Paciente", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Not IsNumeric(cboFormato.SelectedValue) Then MessageBox.Show("Debe seleccionar un formato pre establecido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If lblOrgano.Text = "" Then MessageBox.Show("Debe Seleccionar el Tipo de Procedimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboFormato.Select() : Exit Sub
            If Oper = 1 Then CodLocal = objInforme.Grabar(dtpFechaI.Value.ToShortDateString, txtNumero.Text, lblPaciente.Text, cboProcedencia.Text, cboServicio.Text, lblEdad.Text, txtCama.Text, cboTipoPaciente.Text, dtpFechaEntrega.Value.ToShortDateString, cboFormato.SelectedValue, txtCuerpo.Rtf, lblSexo.Text, cboAño.Text & lblLugar.Text & lblNumero.Text, cboMedico.Text, "", lblOrgano.Text, lblTipoMuestra.Text, txtCuerpo.Text) : objNumeroRegistro.AumentarCorrelativo(lblNumero.Text, cboAño.Text)
            If Oper = 2 Then objInforme.Modificar(CodLocal, dtpFechaI.Value.ToShortDateString, txtNumero.Text, lblPaciente.Text, cboProcedencia.Text, cboServicio.Text, lblEdad.Text, txtCama.Text, cboTipoPaciente.Text, dtpFechaEntrega.Value.ToShortDateString, cboFormato.SelectedValue, txtCuerpo.Rtf, lblSexo.Text, cboMedico.Text, "", lblOrgano.Text, lblTipoMuestra.Text, txtCuerpo.Text)
            objCiePatologico.Eliminar(CodLocal)
            'Grabar Diagnosticos
            Dim I As Integer
            For I = 0 To lvDX.Items.Count - 1
                objCiePatologico.Grabar(CodLocal, lvDX.Items(I).SubItems(0).Text, lvDX.Items(I).SubItems(1).Text)
            Next
            MessageBox.Show("Los datos Fueron Grabados Satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ppdVistaPrevia.ShowDialog()
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            Oper = 2
            CodLocal = lvTabla.SelectedItems(0).SubItems(0).Text
            lblLugar.Text = "- HD -"
            cboAño.Text = Microsoft.VisualBasic.Left(lvTabla.SelectedItems(0).SubItems(1).Text, 4)
            lblNumero.Text = Microsoft.VisualBasic.Right(lvTabla.SelectedItems(0).SubItems(1).Text, lvTabla.SelectedItems(0).SubItems(1).Text.Length - 10)
            dtpFechaI.Value = lvTabla.SelectedItems(0).SubItems(2).Text
            txtNumero.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            lblPaciente.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            lblEdad.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            lblSexo.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            cboProcedencia.Text = lvTabla.SelectedItems(0).SubItems(7).Text
            cboServicio.Text = lvTabla.SelectedItems(0).SubItems(8).Text
            txtCama.Text = lvTabla.SelectedItems(0).SubItems(9).Text
            cboTipoPaciente.Text = lvTabla.SelectedItems(0).SubItems(10).Text
            cboMedico.Text = lvTabla.SelectedItems(0).SubItems(11).Text
            dtpFechaEntrega.Value = lvTabla.SelectedItems(0).SubItems(12).Text
            cboFormato.Text = lvTabla.SelectedItems(0).SubItems(13).Text
            lblOrgano.Text = lvTabla.SelectedItems(0).SubItems(14).Text
            lblTipoMuestra.Text = lvTabla.SelectedItems(0).SubItems(15).Text

            'Cargar Diagnosticos
            lvDX.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim dsDX As New DataSet
            dsDX = objCiePatologico.BuscarDiag(CodLocal)
            For I = 0 To dsDX.Tables(0).Rows.Count - 1
                Fila = lvDX.Items.Add(dsDX.Tables(0).Rows(I)("CodigoEnf"))
                Fila.SubItems.Add(dsDX.Tables(0).Rows(I)("DescripcionEnf"))
            Next

            Dim dsInf As New DataSet
            dsInf = objInforme.BuscarId(CodLocal)
            txtCuerpo.Rtf = dsInf.Tables(0).Rows(0)("Cuerpo")
            ControlesAD(Me, True)
            Botones(False, True, True, False)
        End If
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        objCaja.Rtf = txtCuerpo.Rtf
        m_nFirstCharOnPage = 0
        Y = 0
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Y = Y + 30
        With e.Graphics
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteTitulo, Pincel, 60, Y)
            .DrawString("PATOLOGIA", FuenteEnc, Pincel, 620, Y)

            Y = Y + 30
            .DrawString("INFORME ANATOMO PATOLOGICO", FuenteTitulo, Pincel, 200, Y)
            .DrawString("Fecha: " & dtpFechaI.Value.ToShortDateString, FuenteEnc, Pincel, 600, Y - 15)
            .DrawString("Hora : " & Date.Now.ToShortTimeString, FuenteEnc, Pincel, 600, Y)
            Y = Y + 40
            .DrawString("Nro Registro : ", FuenteTexto, Pincel, 60, Y)
            .DrawString(cboAño.Text & lblLugar.Text & lblNumero.Text, FuenteTextoR, Pincel, 185, Y)
            .DrawString("Historia: ", FuenteTexto, Pincel, 480, Y)
            .DrawString(txtNumero.Text, FuenteTextoR, Pincel, 560, Y)
            Y = Y + 25
            .DrawString("Paciente     : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & lblPaciente.Text, FuenteTextoN, Pincel, 150, Y)
            Y = Y + 25
            .DrawString("Edad         : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & lblEdad.Text, FuenteTextoN, Pincel, 150, Y)
            .DrawString("Sexo    : ", FuenteTexto, Pincel, 480, Y)
            .DrawString("    " & lblSexo.Text, FuenteTextoN, Pincel, 530, Y)
            Y = Y + 25
            .DrawString("Procedencia  : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & cboProcedencia.Text, FuenteTextoN, Pincel, 150, Y)
            .DrawString("Servicio: ", FuenteTexto, Pincel, 480, Y)
            .DrawString("    " & cboServicio.Text, FuenteTextoN, Pincel, 530, Y)
            Y = Y + 25
            .DrawString("Tipo Paciente: ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & cboTipoPaciente.Text, FuenteTextoN, Pincel, 150, Y)
            .DrawString("Cama: ", FuenteTexto, Pincel, 480, Y)
            .DrawString("    " & txtCama.Text, FuenteTextoN, Pincel, 530, Y)
            Y = Y + 25
            .DrawString("Medico       : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & Microsoft.VisualBasic.Left(cboMedico.Text & StrDup(35, " "), 35), FuenteTextoN, Pincel, 150, Y)
            .DrawString("Fec Ent : ", FuenteTexto, Pincel, 480, Y)
            .DrawString(dtpFechaEntrega.Value.ToShortDateString, FuenteTextoN, Pincel, 560, Y)

            'Diagnostico 
            Dim Diagnostico As String = "XXXXXXXXXXX"
            Dim I As Integer
            For I = 0 To lvDX.Items.Count - 1
                If I = 0 Then
                    Diagnostico = lvDX.Items(I).SubItems(0).Text
                Else
                    Diagnostico = Diagnostico & ", " & lvDX.Items(I).SubItems(0).Text
                End If
            Next

            Y = Y + 25
            .DrawString("DX Clínico   : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & Diagnostico, FuenteTextoN, Pincel, 150, Y)
            Y = Y + 25
            .DrawString("Examen       : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & cboFormato.Text, FuenteTextoN, Pincel, 150, Y)
            Y = Y + 25
            .DrawString("Organo       : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & lblOrgano.Text, FuenteTextoN, Pincel, 150, Y)
            Y = Y + 25
            .DrawString("Tipo Muestra : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & lblTipoMuestra.Text, FuenteTextoN, Pincel, 150, Y)
            Y += 25

            m_nFirstCharOnPage = objCaja.FormatRange(False, e, m_nFirstCharOnPage, objCaja.TextLength)
            If (m_nFirstCharOnPage < objCaja.TextLength) Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If
        End With
    End Sub

    Private Sub btnFuente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFuente.Click
        'Todo el texto
        If txtCuerpo.SelectedText.Trim = "" Then
            Fuente.Font = txtCuerpo.Font
            Fuente.ShowDialog()
            txtCuerpo.Font = Fuente.Font
        Else
            Fuente.Font = txtCuerpo.SelectionFont
            Fuente.ShowDialog()
            txtCuerpo.SelectionFont = Fuente.Font
        End If
    End Sub

    Private Function VerificarCodigoCIE() As Boolean
        VerificarCodigoCIE = False
        Dim I As Integer
        For I = 0 To lvDX.Items.Count - 1
            If lvDX.Items(I).SubItems(0).Text = txtCie.Text Then VerificarCodigoCIE = True : Exit For
        Next
    End Function

    Private Sub txtCie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie.KeyDown
        If e.KeyCode = Keys.Enter And txtCie.Text = "" Then txtDes.Select()
        If e.KeyCode = Keys.Enter And txtCie.Text <> "" Then
            If VerificarCodigoCIE() Then MessageBox.Show("Diagnóstico de CIE10 ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            dsCIE = objCIE.BuscarCodigo(txtCie.Text)
            If dsCIE.Tables(0).Rows.Count > 0 Then
                txtDes.Enabled = False
                txtDes.Text = dsCIE.Tables(0).Rows(I)("desc_enf")
                txtDes.Enabled = True
                txtDes.Select()
            Else
                txtDes.Text = ""
                txtCie.Select()
                MessageBox.Show("Codigo de CIE 10 no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie.TextChanged

    End Sub

    Private Sub txtDes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If txtCie.Text <> "" And txtDes.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvDX.Items.Add(txtCie.Text)
            Fila.SubItems.Add(txtDes.Text)
            txtCie.Text = ""
            txtDes.Text = ""
            txtCie.Select()
        End If
    End Sub

    Private Sub txtDes_TextChanged(sender As Object, e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And txtDes.Enabled Then txtF.Text = txtDes.Text : txtF.SelectionStart = txtF.TextLength : gbConsulta.Visible = True : txtF.Select()
    End Sub

    Private Sub lvDX_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvDX.KeyDown
        If e.KeyCode = Keys.Delete And lvDX.SelectedItems.Count > 0 Then lvDX.Items.RemoveAt(lvDX.SelectedItems(0).Index)
    End Sub

    Private Sub lvDX_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvDX.SelectedIndexChanged

    End Sub

    Private Sub txtF_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtF.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvDet.Select()
    End Sub

    Private Sub txtF_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtF.TextChanged
        If txtF.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvDet.Items.Clear()
            dsCIE = objCie.BuscarDes(txtF.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
            Next
        End If
    End Sub

    Private Function VerificarCIE() As Boolean
        VerificarCIE = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(0).Text = lvDet.SelectedItems(0).SubItems(0).Text Then VerificarCIE = True : Exit For
        Next
    End Function

    Private Sub lvDet_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            If VerificarCIE() Then MessageBox.Show("Diagnóstico de CIE10 ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim Fila As ListViewItem
            Fila = lvDX.Items.Add(lvDet.SelectedItems(0).SubItems(0).Text)
            Fila.SubItems.Add(lvDet.SelectedItems(0).SubItems(1).Text)
            btnRetornar_Click(sender, e)
            txtDes.Enabled = False
            txtDes.Text = ""
            txtDes.Enabled = True
            txtCie.Text = ""
            txtDes.Select()
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar_Click(sender As Object, e As System.EventArgs) Handles btnRetornar.Click
        gbConsulta.Visible = False
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter And txtFiltro.Text <> "" Then Buscar(txtFiltro.Text)
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub lblNumero_Click(sender As System.Object, e As System.EventArgs) Handles lblNumero.Click
        Dim Numero As String
        Numero = InputBox("Ingresar Numero Correlativo", "Datos de Informe", "")
        If IsNumeric(Numero) Then
            Dim dsVer As New DataSet
            dsVer = objInforme.VerificarRegistro(cboAño.Text & lblLugar.Text & Numero)
            If dsVer.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("Numero ya fue Registrado Anteriormente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                lblNumero.Text = Numero
            End If
        End If
    End Sub
End Class