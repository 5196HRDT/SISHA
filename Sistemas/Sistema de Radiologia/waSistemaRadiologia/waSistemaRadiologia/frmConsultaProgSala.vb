Public Class frmConsultaProgSala
    Dim objCupoImagenes As New clsCupoImagenes
    Dim objInforme As New clsCitaRayosXImg
    Dim objConsulta As New clsConsultaExterna
    Dim objHistoria As New clsHistoria

    Private Sub BuscarCupos()
        'Buscar
        lvCita.Items.Clear()
        Dim dsVer As New DataSet
        Dim Fila As ListViewItem
        Dim I As Integer
        dsVer = objCupoImagenes.BuscarPaciente(txtPaciente.Text, cboTipo.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvCita.Items.Add(dsVer.Tables(0).Rows(I)("IdCupo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraCita"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Origen"))
        Next
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

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If txtPaciente.Text = "" Then MessageBox.Show("Debe ingresar Datos del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtPaciente.Select() : Exit Sub
        If cboTipo.Text = "" Then MessageBox.Show("Debe ingresar Tipo De Examen", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipo.Select() : Exit Sub
        BuscarCupos()
    End Sub

    Private Sub lvCita_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCita.SelectedIndexChanged
        If lvCita.SelectedItems.Count > 0 Then
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

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtPaciente.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If e.KeyCode = Keys.Enter And txtPaciente.Text <> "" Then btnMostrar.Select()
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub frmConsultaProgSala_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTipo.Text = "RADIOGRAFIA"
    End Sub
End Class