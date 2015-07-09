Imports System.IO
Public Class frmConsultaExterna
    Dim objHistoria As New clsHistoria
    Dim objRayos As New clsRayos
    Dim objCupo As New clsCupo
    Dim objConsulta As New clsConsulta

    Private Sub frmConsultaExterna_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        gbPaciente.Visible = False

        Me.Text = "CONSULTA EXTERNA - Dr(a) " & NomMedico
    End Sub

    Public Shared Function DameImagen(ByVal bytes() As Byte) As Image
        If bytes Is Nothing Then Return Nothing

        Dim ms As New MemoryStream(bytes)
        Dim bm As Bitmap = Nothing
        Try
            bm = New Bitmap(ms)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
        End Try
        Return bm
    End Function

    Public Sub CalcularEdad(FechaActual As Date, FechaNacimiento As Date)
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
        If Val(EdadA) > 0 Then
            lblEdad.Text = EdadA & " A"
        ElseIf Val(EdadM) > 0 Then
            lblEdad.Text = EdadM & " M"
        Else
            lblEdad.Text = EdadD & " D"
        End If
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            lblFNac.Text = dsHistorias.Tables(0).Rows(0)("FNacimiento")
            CalcularEdad(Date.Now.ToShortDateString, lblFNac.Text)

            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
            lblDpto.Text = dsHistorias.Tables(0).Rows(0)("Departamento").ToString
            lblProvincia.Text = dsHistorias.Tables(0).Rows(0)("Provincia").ToString
            lblDistrito.Text = dsHistorias.Tables(0).Rows(0)("Distrito").ToString
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            If txtHistoria.Text = "" Then Exit Sub


            'Lista de Atencion de Consulta
            lvConsultas.Items.Clear()
            Dim dsConsulta As New Data.DataSet
            Dim FilaC As ListViewItem
            Dim CantEsp As Integer
            Dim UltimoAñoAtendido As Integer
            CantEsp = 0

            dsConsulta = objCupo.ConsultasPacienteAtendidas(txtHistoria.Text, Date.Now)
            dgConsultas.DataSource = dsConsulta.Tables(0)
            UltimoAñoAtendido = 0
            For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
                FilaC = lvConsultas.Items.Add(dsConsulta.Tables(0).Rows(I)("Fecha"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Consultorio"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Medico"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
                FilaC.SubItems.Add("CONSULTA")
            Next

            'Buscar Interconsultas
            dsConsulta = objCupo.ConsultasPacienteAtendidas(txtHistoria.Text, Date.Now)
            dgConsultas.DataSource = dsConsulta.Tables(0)
            UltimoAñoAtendido = 0
            For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
                FilaC = lvConsultas.Items.Add(dsConsulta.Tables(0).Rows(I)("Fecha"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Consultorio"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Medico"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
                FilaC.SubItems.Add("CONSULTA")
            Next
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub lvConsultas_Click(sender As Object, e As System.EventArgs) Handles lvConsultas.Click
        If lvConsultas.Items.Count > 0 Then

            txtSignoH.Text = ""
            txtTallaH.Text = ""
            txtPesoH.Text = ""
            txtPulsoH.Text = ""
            txtTemperaturaH.Text = ""
            txtPresionH.Text = ""
            txtEvaluacionH.Text = ""
            txtCie1H.Text = ""
            txtDes1H.Text = ""
            txtCie2H.Text = ""
            txtDes2H.Text = ""
            txtCie3H.Text = ""
            txtDes3H.Text = ""
            txtCie4H.Text = ""
            txtDes4H.Text = ""
            txtCie5H.Text = ""
            txtDes5H.Text = ""
            txtCie6H.Text = ""
            txtDes6H.Text = ""
            txtTD1.Text = ""
            txtTD2.Text = ""
            txtTD3.Text = ""
            txtTD4.Text = ""
            txtTD5.Text = ""
            txtTD6.Text = ""
            txtLab1H.Text = ""
            txtLab2H.Text = ""
            txtLab3H.Text = ""
            txtLab4H.Text = ""
            txtLab5H.Text = ""
            txtLab6H.Text = ""
            txtTratamientoH.Text = ""
            dgExamenesH.Items.Clear()
            dgMedicamentoH.Items.Clear()
            cboEstablecimientoH.Text = ""
            cboServicioH.Text = ""
            txtEvolucionH.Text = ""

            'Verificar Si fue Grabada Atencion
            Dim I As Integer
            Dim IdCupo As String
            IdCupo = ""
            For I = 0 To lvConsultas.Items.Count - 1
                If lvConsultas.Items(I).Selected Then
                    IdCupo = lvConsultas.Items(I).SubItems(3).Text
                    Exit For
                End If
            Next
            If IdCupo = "" Then Exit Sub

            Dim dsConsultaAnt As New Data.DataSet
            dsConsultaAnt = objConsulta.Buscar(IdCupo)
            If dsConsultaAnt.Tables(0).Rows.Count > 0 Then
                txtSignoH.Text = dsConsultaAnt.Tables(0).Rows(0)("Sintomas")
                txtTallaH.Text = dsConsultaAnt.Tables(0).Rows(0)("Talla")
                txtPesoH.Text = dsConsultaAnt.Tables(0).Rows(0)("Peso")
                txtPulsoH.Text = dsConsultaAnt.Tables(0).Rows(0)("Pulso")
                txtTemperaturaH.Text = dsConsultaAnt.Tables(0).Rows(0)("Temp")
                txtPresionH.Text = dsConsultaAnt.Tables(0).Rows(0)("Presion")
                'txtCIEPH.Text = dsConsultaAnt.Tables(0).Rows(0)("CieP")
                'txtDesPH.Enabled = False
                'txtDesPH.Text = dsConsultaAnt.Tables(0).Rows(0)("DesP")
                'txtDesPH.Enabled = True
                txtEvaluacionH.Text = dsConsultaAnt.Tables(0).Rows(0)("Evaluacion")
                txtCie1H.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie1")
                txtDes1H.Enabled = False
                txtDes1H.Text = dsConsultaAnt.Tables(0).Rows(0)("Des1")
                txtTD1.Text = dsConsultaAnt.Tables(0).Rows(0)("TipoDiagnostico").ToString
                txtDes1H.Enabled = True
                txtCie2H.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie2")
                txtTD2.Text = dsConsultaAnt.Tables(0).Rows(0)("TD1").ToString
                txtDes2H.Enabled = False
                txtDes2H.Text = dsConsultaAnt.Tables(0).Rows(0)("Des2")
                txtDes2H.Enabled = True
                txtCie3H.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie3")
                txtDes3H.Enabled = False
                txtDes3H.Text = dsConsultaAnt.Tables(0).Rows(0)("Des3")
                txtDes3H.Enabled = True
                txtTD3.Text = dsConsultaAnt.Tables(0).Rows(0)("TD2").ToString
                txtCie4H.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie4")
                txtDes4H.Enabled = False
                txtDes4H.Text = dsConsultaAnt.Tables(0).Rows(0)("Des4")
                txtDes4H.Enabled = True
                txtTD4.Text = dsConsultaAnt.Tables(0).Rows(0)("TD3").ToString

                txtCie5H.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie5").ToString
                txtDes5H.Enabled = False
                txtDes5H.Text = dsConsultaAnt.Tables(0).Rows(0)("Des5").ToString
                txtDes5H.Enabled = True
                txtTD5.Text = dsConsultaAnt.Tables(0).Rows(0)("TD4").ToString

                txtCie6H.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie6").ToString
                txtDes6H.Enabled = False
                txtDes6H.Text = dsConsultaAnt.Tables(0).Rows(0)("Des6").ToString
                txtDes6H.Enabled = True
                txtTD6.Text = dsConsultaAnt.Tables(0).Rows(0)("TD5").ToString
                txtTratamientoH.Text = dsConsultaAnt.Tables(0).Rows(0)("Tratamiento")
                cboEstablecimientoH.Text = dsConsultaAnt.Tables(0).Rows(0)("IngEstablecimiento")
                cboServicioH.Text = dsConsultaAnt.Tables(0).Rows(0)("IngServicio")
                txtEvolucionH.Text = dsConsultaAnt.Tables(0).Rows(0)("Evolucion")

                txtLab1H.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab1").ToString
                txtLab2H.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab2").ToString
                txtLab3H.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab3").ToString
                txtLab4H.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab4").ToString
                txtLab5H.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab5").ToString
                txtLab6H.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab6").ToString
            End If
        End If
    End Sub

    Private Sub lvConsultas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvConsultas.SelectedIndexChanged
        lvConsultas_Click(sender, e)
    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtPaciente.Text)
            lvPaciente.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvPaciente.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FNacimiento").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomPadre").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomMadre").ToString)
            Next
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
            gbPaciente.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub
End Class