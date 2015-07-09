Public Class frmInformeRX
    Dim objInforme As New clsCitaRayosXImg
    Dim objHistoria As New clsHistoria
    Dim objCupoImagenes As New clsCupoImagenes
    Dim objMedico As New clsMedico
    Dim objTecnico As New clsTecnicoRX
    Dim objConsulta As New clsConsultaExterna
    Dim Oper As Integer

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

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Generar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGenerar.Enabled = Generar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Public Sub CalcularEdad(ByVal FechaActual As Date, ByVal FechaNacimiento As Date)
        Dim Dias As Integer, Meses As Integer, Años As Integer
        Dim DiasMes As Integer
        Dim dfin, dinicio As Date
        Dim EdadA, EdadM, EdadD As String
        dfin = FechaActual
        dinicio = FechaNacimiento
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

            EdadD = Microsoft.VisualBasic.Day(FechaNacimiento)
            If Val(EdadD) > FechaActual.Day Then
                EdadD = Val(EdadD) - FechaActual.Day
            ElseIf Val(EdadD) < FechaActual.Day Then
                If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                EdadD = FechaActual.Day - EdadD
                EdadD = DameDiasMes(FechaActual.Month) - EdadD
            Else
                EdadD = 0
            End If
        End If
        lblEdad.Text = EdadA & " A " & EdadM & " M " & EdadD & " D "
    End Sub

    Private Sub BuscarCupos()
        If cboTurno.Text = "" Then Exit Sub
        'Buscar
        lvCita.Items.Clear()
        Dim dsVer As New DataSet
        Dim Fila As ListViewItem
        Dim I As Integer
        dsVer = objCupoImagenes.Buscar(dtpFecha.Value.ToShortDateString, cboTurno.Text, cboTipo.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvCita.Items.Add(dsVer.Tables(0).Rows(I)("IdCupo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraCita"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Origen"))
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        BuscarCupos()
    End Sub

    Private Sub frmInformeRX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        dtpFecha.Value = Date.Now
        cboTipo.Text = "ECOGRAFIA"

        'Medico
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"

        'Tecnico
        Dim dsTecnico As New DataSet
        dsTecnico = objTecnico.BuscarCombo("TECNOLOGO")
        cboTecnico.DataSource = dsTecnico.Tables(0)
        cboTecnico.DisplayMember = "Nombres"
        cboTecnico.ValueMember = "IdTecnico"

        'Radiologo
        Dim dsRadiologo As New DataSet
        dsRadiologo = objTecnico.BuscarCombo("RADIOLOGO")
        cboRadiologo.DataSource = dsRadiologo.Tables(0)
        cboRadiologo.DisplayMember = "Nombres"
        cboRadiologo.ValueMember = "IdTecnico"

        'Secretaria
        Dim dsSecretaria As New DataSet
        dsSecretaria = objTecnico.BuscarCombo("SECRETARIA")
        cboSecretaria.DataSource = dsSecretaria.Tables(0)
        cboSecretaria.DisplayMember = "Nombres"
        cboSecretaria.ValueMember = "IdTecnico"
    End Sub

    Private Sub lvCita_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCita.SelectedIndexChanged
        If lvCita.SelectedItems.Count > 0 Then
            Oper = 1
            Dim dsVer As New DataSet
            dsVer = objCupoImagenes.BuscarId(lvCita.SelectedItems(0).SubItems(0).Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                lblTipo.Text = dsVer.Tables(0).Rows(0)("TipoPaciente")
                lblHistoria.Text = dsVer.Tables(0).Rows(0)("Historia")
                lblPaciente.Text = dsVer.Tables(0).Rows(0)("Paciente")
                lblServicio.Text = dsVer.Tables(0).Rows(0)("Origen")
                lblSubServicio.Text = dsVer.Tables(0).Rows(0)("Servicio")
                cboMedico.Text = dsVer.Tables(0).Rows(0)("Solicitante")
                txtIndicacion.Text = dsVer.Tables(0).Rows(0)("Indicaciones")
                lblCie1.Text = dsVer.Tables(0).Rows(0)("Cie1")
                lblCie2.Text = dsVer.Tables(0).Rows(0)("Cie2")
                lblCie3.Text = dsVer.Tables(0).Rows(0)("Cie3")

                Dim dsHistoria As New DataSet
                dsHistoria = objHistoria.Buscar(lblHistoria.Text)
                'Edad y Sexo del Paciente
                Dim FechaNac As Date
                If dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                    FechaNac = dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString
                Else
                    FechaNac = InputBox("Ingrear Fecha de Nacimiento de Paciente", "Información de Paciente")
                End If
                CalcularEdad(Date.Now, FechaNac)
                lblSexo.Text = dsHistoria.Tables(0).Rows(0)("Sexo")

                'Lista de Examenes
                Dim dsLista As New DataSet
                Dim Examenes As String = ""
                Dim I As Integer
                dsLista = objConsulta.ListaExamenesImagenes(lvCita.SelectedItems(0).SubItems(0).Text)
                If dsLista.Tables(0).Rows.Count > 0 Then
                    For I = 0 To dsLista.Tables(0).Rows.Count - 1
                        If I = 0 Then Examenes = dsLista.Tables(0).Rows(I)("Descripcion") Else Examenes = Examenes & ", " & dsLista.Tables(0).Rows(I)("Descripcion")
                    Next
                End If
                txtExámenes.Text = Replace(Examenes, "RADIOGRAFIA DE ", "")
                txtExámenes.Text = Replace(txtExámenes.Text, "RADIOGRAFIA ", "")

                'Buscar Resultado de Examen
                Dim dsResultado As New DataSet
                dsResultado = objInforme.BuscarIdCupo(lvCita.SelectedItems(0).SubItems(0).Text)
                If dsResultado.Tables(0).Rows.Count > 0 Then
                    Oper = 2
                    txtInforme.Text = dsResultado.Tables(0).Rows(0)("Descripcion")
                    cboTecnico.Text = dsResultado.Tables(0).Rows(0)("Tecnologo")
                    cboRadiologo.Text = dsResultado.Tables(0).Rows(0)("Radiologo")
                    cboSecretaria.Text = dsResultado.Tables(0).Rows(0)("Secretaria")
                    cboMedico.Text = dsResultado.Tables(0).Rows(0)("MedicoSol")
                    dtpFechaInf.Value = dsResultado.Tables(0).Rows(0)("FechaR")
                End If
            Else
                lblHistoria.Text = ""
                lblPaciente.Text = ""
                lblServicio.Text = ""
                lblSubServicio.Text = ""
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        txtInforme.Text = ""
        lvCita.Enabled = False
        btnMostrar.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboTipo.Select()
        lvCita.Enabled = True
        btnMostrar.Enabled = True
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then dtpFecha.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboTurno.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub cboTurno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTurno.KeyDown
        If e.KeyCode = Keys.Enter And cboTurno.Text <> "" Then btnMostrar.Select()
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If lvCita.SelectedItems.Count = 0 Then MessageBox.Show("Debe seleccionar un paciente citado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If txtInforme.Text = "" Then MessageBox.Show("Debe ingresar el informe referente a los examenes solicitados", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub : txtInforme.Select()
        If cboRadiologo.Text = "" Then MessageBox.Show("Debe ingresar el Radiólogo responsable del exámen", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub : cboRadiologo.Select()
        If cboTecnico.Text = "" Then MessageBox.Show("Debe ingresar el Técnico responsable del exámen", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub : cboTecnico.Select()

        If MessageBox.Show("Esta seguro graba la información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim IdInforme As String
            If Oper = 1 Then IdInforme = objInforme.Grabar(lblHistoria.Text, txtExámenes.Text, txtInforme.Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), cboTipo.Text, lblServicio.Text, lblSubServicio.Text, lblEdad.Text, lblSexo.Text, cboTecnico.Text, cboRadiologo.Text, cboMedico.Text, txtIndicacion.Text, cboSecretaria.Text, "", dtpFechaInf.Value.ToShortDateString, lblTipo.Text, "", 0, lvCita.SelectedItems(0).SubItems(0).Text, lblCie1.Text, lblCie2.Text, lblCie3.Text)
            If Oper = 2 Then objInforme.Modificar(lblHistoria.Text, txtExámenes.Text, txtInforme.Text, cboTipo.Text, lblServicio.Text, lblSubServicio.Text, cboTecnico.Text, cboRadiologo.Text, cboMedico.Text, txtIndicacion.Text, cboSecretaria.Text, "", lblTipo.Text, lvCita.SelectedItems(0).SubItems(0).Text)

            'Atencion de Todos los Requerimientos de Imagenes
            Dim dsLista As New DataSet
            Dim I As Integer
            dsLista = objConsulta.ListaExamenesImagenes(lvCita.SelectedItems(0).SubItems(0).Text)
            If dsLista.Tables(0).Rows.Count > 0 Then
                For I = 0 To dsLista.Tables(0).Rows.Count - 1
                    objConsulta.GrabarResultado(dsLista.Tables(0).Rows(I)("IdConsultaExa"), txtInforme.Text, dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), vUsuarioSistema, My.Computer.Name)
                Next
            End If

            ppdVistaPrevia.ShowDialog()
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub btnHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorial.Click
        frmHistorial.Show()
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
            If lblServicio.Text <> "" Then
                .DrawString("    " & lblServicio.Text, FuenteTextoN, Pincel, 150, Y)
            Else
                .DrawString("    " & "------------------------", FuenteTextoN, Pincel, 150, Y)
            End If

            .DrawString("SubSer.: ", FuenteTexto, Pincel, 480, Y)
            If lblSubServicio.Text <> "" Then
                .DrawString(Microsoft.VisualBasic.Left(lblSubServicio.Text & StrDup(26, " "), 26), FuenteTextoN, Pincel, 560, Y)
            Else
                .DrawString("------------------------", FuenteTextoN, Pincel, 560, Y)
            End If

            Y = Y + 25
            .DrawString("Radiólogo  : ", FuenteTexto, Pincel, 60, Y)
            .DrawString("    " & cboRadiologo.Text, FuenteTextoN, Pincel, 150, Y)
            .DrawString("Técnico: ", FuenteTexto, Pincel, 480, Y)
            .DrawString(Microsoft.VisualBasic.Left(cboTecnico.Text & StrDup(26, " "), 26), FuenteTextoN, Pincel, 560, Y)
            Y = Y + 25
            .DrawString("Medico Sol.: ", FuenteTexto, Pincel, 60, Y)
            If cboMedico.Text <> "" Then
                .DrawString("    " & Microsoft.VisualBasic.Left(cboMedico.Text & StrDup(35, " "), 35), FuenteTextoN, Pincel, 150, Y)
            Else
                .DrawString("    " & "------------------------", FuenteTextoN, Pincel, 150, Y)
            End If
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
End Class