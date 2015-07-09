Public Class frmInforme
    Dim objElectro As New clsEncefalograma
    Dim objMedico As New clsMedico
    Dim objHistoria As New clsHistoria
    Dim objFormato As New clsElectroencefaFor
    Dim objTipoPaciente As New clsTipoPacienteHIS

    Dim Oper As Integer
    Dim CodLocal As String

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

    Private Sub BuscarHistoria(ByVal Historia As String)
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(Historia)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblHistoria.Text = dsHistorias.Tables(0).Rows(0)("HClinica")
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")
            lblSexo.Text = dsHistorias.Tables(0).Rows(0)("Sexo")
            If dsHistorias.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                Dim EdadA, EdadM, EdadD As String
                dfin = Date.Now.ToShortDateString
                dinicio = dsHistorias.Tables(0).Rows(0)("FNACIMIENTO")
                Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                Años = DateDiff("yyyy", dinicio, dfin)

                If Meses = 0 And Años = 0 Then
                    EdadA = 0
                    EdadM = 0
                    Dias = Math.Abs(Dias)
                    EdadD = Dias
                Else
                    'Verificar Dias
                    If Dias < 0 Then
                        DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
                        Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
                        Meses = Meses - 1
                    End If
                    If Meses < 0 Then
                        Meses = 12 + Meses
                        Años = Años - 1
                    End If
                    EdadA = Años
                    EdadM = Meses
                    EdadD = Dias

                    EdadD = Microsoft.VisualBasic.Day(dinicio)
                    If Val(EdadD) > Date.Now.Day Then
                        EdadD = Val(EdadD) - Date.Now.Day
                    ElseIf Val(EdadD) < Date.Now.Day Then
                        If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                        EdadD = Date.Now.Day - EdadD
                        EdadD = DameDiasMes(Date.Now.Month) - EdadD
                    Else
                        EdadD = 0
                    End If
                End If
                lblEdad.Text = EdadA & " A " & EdadM & " M " & EdadD & " D "
            Else
                lblEdad.Text = ""
            End If
        Else
            MessageBox.Show("Paciente no se encuentra registrado en el Sistema", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmInforme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
        btnCancelar_Click(sender, e)

        'Medico Tratante
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"

        'Tipo Paciente
        Dim dsTipo As New DataSet
        dsTipo = objTipoPaciente.Combo
        cboTipoPaciente.DataSource = dsTipo.Tables(0)
        cboTipoPaciente.DisplayMember = "Descripcion"
        cboTipoPaciente.ValueMember = "IdTipo"
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        txtInforme.Enabled = False
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        Limpiar(Me)
        lvTabla.Items.Clear()
        lvHistorial.Items.Clear()
        txtPaciente.Text = ""
        txtInforme.Text = ""
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        txtInforme.Enabled = True
        txtPaciente.Select()
        Oper = 1

        Dim dsver As New DataSet
        dsver = objFormato.Buscar
        txtInforme.RtfText = dsver.Tables(0).Rows(0)("Formato")
        txtCorrelativo.Text = dsver.Tables(0).Rows(0)("Correlativo")
    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        lvTabla.Items.Clear()
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsHistoria As New DataSet
            If IsNumeric(txtPaciente.Text) Then
                dsHistoria = objHistoria.Buscar(txtPaciente.Text)
            Else
                dsHistoria = objHistoria.BuscarPaciente(txtPaciente.Text)
            End If
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsHistoria.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsHistoria.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("Apaterno") & " " & dsHistoria.Tables(0).Rows(I)("Amaterno") & " " & dsHistoria.Tables(0).Rows(I)("Nombres"))
            Next
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If lblHistoria.Text = "" Then MessageBox.Show("Debe Seleccionar a un Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtPaciente.Select() : Exit Sub
        If Not IsNumeric(cboMedico.SelectedValue) Then MessageBox.Show("Debe Seleccionar un Médico solicitante", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboMedico.Select() : Exit Sub
        If txtInforme.Text = "" Then MessageBox.Show("Debe ingresar Resultado del Informe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtInforme.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar Informe?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Oper = 1 Then objElectro.Grabar(Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name, dtpFecha.Value.ToShortDateString, lblHistoria.Text, lblPaciente.Text, lblSexo.Text, lblEdad.Text, cboMedico.Text, txtInforme.RtfText, txtInforme.Text, cboTipo.Text, txtSerie.Text, txtNumero.Text, cboTipoPaciente.Text)
            If Oper = 2 Then objElectro.Modificar(CodLocal, cboMedico.Text, txtInforme.RtfText, txtInforme.Text, cboTipo.Text, txtSerie.Text, txtNumero.Text)

            objFormato.Correlativo(txtCorrelativo.Text)
            ppdVistaPrevia.ShowDialog()

            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        lvHistorial.Items.Clear()
        If lvTabla.SelectedItems.Count > 0 Then
            lblHistoria.Text = lvTabla.SelectedItems(0).SubItems(0).Text
            BuscarHistoria(lvTabla.SelectedItems(0).SubItems(0).Text)

            'Buscar Historial de Electroencefalogramas
            Dim dsVer As New DataSet
            dsVer = objElectro.BuscarHistoria(lvTabla.SelectedItems(0).SubItems(0).Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdElectro"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaInforme"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Solicitado"))
            Next
        End If
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If cboTipo.Text <> "" Then txtSerie.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then txtNumero.Select()
    End Sub

    Private Sub txtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        If cboTipo.Text <> "" And txtSerie.Text <> "" And IsNumeric(txtNumero.Text) Then
            'lblHistoria.Text = ""
            'lblPaciente.Text = ""
            'lblEdad.Text = ""
            'lblSexo.Text = ""

        End If
    End Sub

    Private Sub lvHistorial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvHistorial.SelectedIndexChanged
        If lvHistorial.SelectedItems.Count > 0 Then
            Oper = 2
            Dim dsVer As New DataSet
            dsVer = objElectro.BuscarId(lvHistorial.SelectedItems(0).SubItems(0).Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                lblHistoria.Text = dsVer.Tables(0).Rows(0)("Historia")
                lblPaciente.Text = dsVer.Tables(0).Rows(0)("Paciente")
                lblEdad.Text = dsVer.Tables(0).Rows(0)("Edad")
                lblSexo.Text = dsVer.Tables(0).Rows(0)("Sexo")
                cboMedico.Text = dsVer.Tables(0).Rows(0)("Solicitado")
                cboTipo.Text = dsVer.Tables(0).Rows(0)("TipoDoc")
                txtSerie.Text = dsVer.Tables(0).Rows(0)("Serie")
                txtNumero.Text = dsVer.Tables(0).Rows(0)("Numero")
                txtInforme.RtfText = dsVer.Tables(0).Rows(0)("Informe")
                cboTipoPaciente.Text = dsVer.Tables(0).Rows(0)("TipoPaciente")
                CodLocal = lvHistorial.SelectedItems(0).SubItems(0).Text
            End If
        End If
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        objCaja.Rtf = txtInforme.RtfText
        m_nFirstCharOnPage = 0
        Y = 0
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Y = Y + 30
        With e.Graphics
            .DrawString("Hospital Regional Docente de Trujillo" & StrDup(50, " ") & "Dpto. Medicina", FuenteEnc, Pincel, 60, Y)
            Y = Y + 30
            .DrawString("Fecha: " & dtpFecha.Value.ToShortDateString, FuenteEnc, Pincel, 650, Y - 15)
            .DrawString("Hora : " & Date.Now.ToShortTimeString, FuenteEnc, Pincel, 650, Y)
            Y = Y + 25
            .DrawString("GABINETE DE ELECTROENCEFALOGRAFIA COMPUTARIZADA", FuenteTitulo, Pincel, 140, Y)
            Y = Y + 25
            .DrawString("VIDEO Y MAPEO CEREBRAL", FuenteTitulo, Pincel, 260, Y)
           
            Y = Y + 40
            .DrawString("EEG : ", FuenteTexto, Pincel, 60, Y)
            .DrawString(txtCorrelativo.Text, FuenteTextoR, Pincel, 120, Y)
            .DrawString("", FuenteTextoR, Pincel, 185, Y)
            .DrawString("Historia: ", FuenteTexto, Pincel, 250, Y)
            .DrawString(lblHistoria.Text, FuenteTextoR, Pincel, 350, Y)
            .DrawString("Tipo    : ", FuenteTexto, Pincel, 480, Y)
            .DrawString("    " & cboTipoPaciente.Text, FuenteTextoN, Pincel, 530, Y)
            Y = Y + 25
            .DrawString("Paciente     : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & lblPaciente.Text, FuenteTextoN, Pincel, 150, Y)
            Y = Y + 25
            .DrawString("Edad         : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & lblEdad.Text, FuenteTextoN, Pincel, 150, Y)
            .DrawString("Sexo    : ", FuenteTexto, Pincel, 480, Y)
            .DrawString("    " & lblSexo.Text, FuenteTextoN, Pincel, 530, Y)
            Y = Y + 25
            .DrawString("Medico Solicitante: ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & cboMedico.Text, FuenteTextoN, Pincel, 200, Y)
          

            m_nFirstCharOnPage = objCaja.FormatRange(False, e, m_nFirstCharOnPage, objCaja.TextLength)
            If (m_nFirstCharOnPage < objCaja.TextLength) Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If
        End With
    End Sub
End Class