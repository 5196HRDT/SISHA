Public Class frmListaAtencion
    Dim objCupo As New Cupo
    Dim objConsulta As New Consulta
    Dim objConsultaCPT As New ConsultaCPT
    Dim objInterconsultaH As New InterconsultaH
    Dim objInterconsultaE As New InterconsultaE
    Dim objProgramacion As New Programacion
    Dim objConvenio As New Convenio
    Dim objMedico As New Medico

    'Variables Impresion
    Dim FuenteM As New Font("Lucida Console", 14, FontStyle.Bold)
    Dim FuenteTit As New Font("TIMES NEW ROMAN", 20, FontStyle.Bold)
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteTex As New Font("Lucida Console", 8)
    Dim FuenteP As New Font("Lucida Console", 9, FontStyle.Bold)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim NroFilasTotales As Integer
    Dim NroPaginas As Integer
    Dim NroFilasHoja As Integer
    Dim TotalFilasLV As Integer
    Dim X, Y As Integer
    Dim BuenaPro As Boolean = False
    Dim MontoAdjudicado As String = ""

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub DefinirEspecialidad()
        'Verificar Programaciones
        Dim dsProgramacion As New DataSet
        dsProgramacion = objProgramacion.CantidadProgramada(vIdMedico, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        If dsProgramacion.Tables(0).Rows.Count > 1 Then
            If MessageBox.Show("Usted. Tiene 02 Especialidades programadas en este Dia y Turno. Cual Especialidad desea Atender" & Chr(13) & dsProgramacion.Tables(0).Rows(0)("Especialidad") & "(SI)" & Chr(13) & dsProgramacion.Tables(0).Rows(1)("Especialidad") & "(NO)", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                lblEspecialidad.Text = dsProgramacion.Tables(0).Rows(0)("Especialidad")
            Else
                lblEspecialidad.Text = dsProgramacion.Tables(0).Rows(1)("Especialidad")
            End If
        ElseIf dsProgramacion.Tables(0).Rows.Count = 1 Then
            lblEspecialidad.Text = dsProgramacion.Tables(0).Rows(0)("Especialidad")
        Else
            If NomMedico <> "" Then
                Dim dsM As New Data.DataSet
                dsM = objMedico.Medico_BuscarId(vIdMedico)
                lblEspecialidad.Text = dsM.Tables(0).Rows(0)("SubServicio")
            End If
        End If
    End Sub

    Private Sub frmListaAtencion_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmListaAtencion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTurno.Text = "MAÑANA"
        dtpFecha.Value = Date.Now
        lblMedico.Text = NomMedico

        If NomMedico <> "" Then
            Dim dsM As New Data.DataSet
            dsM = objMedico.Medico_BuscarId(vIdMedico)
            'lblEspecialidad.Text = dsM.Tables(0).Rows(0)("SubServicio")
            'DefinirEspecialidad()
        End If

        btnMostrar_Click(sender, e)
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If lblMedico.Text <> "" Then DefinirEspecialidad()
        Dim Fila As ListViewItem
        Dim I As Integer
        Dim EdadA, EdadM, EdadD As String

        If cboTurno.Text <> "" Then
            Dim dsAtencion As New Data.DataSet

            'Atenciones de Consulta
            If Not chkAtendidos.Checked Then
                dsAtencion = objCupo.Cupos_BuscarAtencionSubEspecialidad(dtpFecha.Value.ToShortDateString, cboTurno.Text, CodMedico, lblEspecialidad.Text)
            Else
                dsAtencion = objCupo.Cupos_BuscarAtencionAtendidaSubEspecialidad(dtpFecha.Value.ToShortDateString, cboTurno.Text, CodMedico, lblEspecialidad.Text)
            End If
            dgTabla.DataSource = dsAtencion.Tables(0)
            lvTabla.Items.Clear()

            Dim Edad As String
            For I = 0 To dsAtencion.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsAtencion.Tables(0).Rows(I)("Cupo"))
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("NHistoria"))
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("Paterno"))
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("Materno"))
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("Nombres"))
                Edad = "0"
                'Edad Paciente
                If dsAtencion.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    EdadA = 0 : Edad = "0"
                    If dsAtencion.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                        Dim Dias As Integer, Meses As Integer, Años As Integer
                        Dim DiasMes As Integer
                        Dim dfin, dinicio As Date
                        dfin = dtpFecha.Value
                        dinicio = dsAtencion.Tables(0).Rows(I)("FNacimiento")
                        Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                        Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                        Años = DateDiff("yyyy", dinicio, dfin)
                        'Verificar Dias
                        If Meses = 0 And Años = 0 Then
                            EdadA = 0
                            EdadM = 0
                            Dias = Math.Abs(Dias)
                            EdadD = Dias
                        Else
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
                            If Val(EdadA) > 0 Then
                                Edad = EdadA & "A " & EdadM & "M"
                            Else
                                Edad = EdadM & "M " & EdadD & "D"
                            End If
                        End If

                        If Val(EdadA) > 0 Then
                            Edad = EdadA & "A " & EdadM & "M"
                        Else
                            Edad = EdadM & "M " & EdadD & "D"
                        End If
                    End If
                End If
                
                Fila.SubItems.Add(Edad)
                If dsAtencion.Tables(0).Rows(I)("Exonerado").ToString = "" Or dsAtencion.Tables(0).Rows(I)("Exonerado").ToString = "NO" Then
                    If dsAtencion.Tables(0).Rows(I)("TipoCupo") = "CONVENIO" Then
                        Dim dsConvenio As New DataSet
                        dsConvenio = objConvenio.VerificarTipoAtencionCE(dsAtencion.Tables(0).Rows(I)("NroPreliquidacion"))
                        If dsConvenio.Tables(0).Rows.Count > 0 Then Fila.SubItems.Add(dsConvenio.Tables(0).Rows(0)("TipoAtencionCE")) Else Fila.SubItems.Add("CONVENIO")
                    Else
                        Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("TipoCupo"))
                    End If
                Else
                    Fila.SubItems.Add("EXONERADO")
                End If
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("TipoAtencion"))
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("IdCupo"))
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("NroPreliquidacion").ToString)
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("SerieSis").ToString)
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("NumeroSis").ToString)
                Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("HoraCita"))
            Next

            If dsAtencion.Tables(0).Rows.Count > 0 Then lblEspecialidad.Text = dsAtencion.Tables(0).Rows(0)("Especialidad") : EspMedico = lblEspecialidad.Text : CodProgramacion = dsAtencion.Tables(0).Rows(0)("IdProgramacion")

            'Atencion de Interconsultas
            If chkAtendidos.Checked Then
                dsAtencion = objInterconsultaH.BuscarAtencionSubEspecialidad(dtpFecha.Value.ToShortDateString, cboTurno.Text, CodMedico, lblEspecialidad.Text)
                For I = 0 To dsAtencion.Tables(0).Rows.Count - 1
                    Fila = lvTabla.Items.Add(lvTabla.Items.Count + 1)
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("Historia"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("APaterno"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("AMaterno"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("Nombres"))
                    Edad = "0"
                    'Edad Paciente
                    If dsAtencion.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                        EdadA = 0 : Edad = "0"
                        If dsAtencion.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                            Dim Dias As Integer, Meses As Integer, Años As Integer
                            Dim DiasMes As Integer
                            Dim dfin, dinicio As Date
                            dfin = dtpFecha.Value
                            dinicio = dsAtencion.Tables(0).Rows(I)("FNacimiento")
                            Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                            Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                            Años = DateDiff("yyyy", dinicio, dfin)
                            'Verificar Dias
                            If Meses = 0 And Años = 0 Then
                                EdadA = 0
                                EdadM = 0
                                Dias = Math.Abs(Dias)
                                EdadD = Dias
                            Else
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
                                If Val(EdadA) > 0 Then
                                    Edad = EdadA & "A " & EdadM & "M"
                                Else
                                    Edad = EdadM & "M " & EdadD & "D"
                                End If
                            End If

                            If Val(EdadA) > 0 Then
                                Edad = EdadA & "A " & EdadM & "M"
                            Else
                                Edad = EdadM & "M " & EdadD & "D"
                            End If
                        End If
                    End If

                    Fila.SubItems.Add(Edad)
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("TipoCupo"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("TipoAtencion"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("IdInterconsultaH"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                Next
            End If

            'Atencion de Interconsultas Emergencia
            If chkAtendidos.Checked Then
                dsAtencion = objInterconsultaE.BuscarAtencionSubEspecialidad(dtpFecha.Value.ToShortDateString, cboTurno.Text, CodMedico, lblEspecialidad.Text)
                For I = 0 To dsAtencion.Tables(0).Rows.Count - 1
                    Fila = lvTabla.Items.Add(lvTabla.Items.Count + 1)
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("Historia"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("APaterno"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("AMaterno"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("Nombres"))
                    Edad = "0"
                    'Edad Paciente
                    If dsAtencion.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                        EdadA = 0 : Edad = "0"
                        If dsAtencion.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                            Dim Dias As Integer, Meses As Integer, Años As Integer
                            Dim DiasMes As Integer
                            Dim dfin, dinicio As Date
                            dfin = dtpFecha.Value
                            dinicio = dsAtencion.Tables(0).Rows(I)("FNacimiento")
                            Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                            Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                            Años = DateDiff("yyyy", dinicio, dfin)
                            'Verificar Dias
                            If Meses = 0 And Años = 0 Then
                                EdadA = 0
                                EdadM = 0
                                Dias = Math.Abs(Dias)
                                EdadD = Dias
                            Else
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
                                If Val(EdadA) > 0 Then
                                    Edad = EdadA & "A " & EdadM & "M"
                                Else
                                    Edad = EdadM & "M " & EdadD & "D"
                                End If
                            End If

                            If Val(EdadA) > 0 Then
                                Edad = EdadA & "A " & EdadM & "M"
                            Else
                                Edad = EdadM & "M " & EdadD & "D"
                            End If
                        End If
                    End If
                    Fila.SubItems.Add(Edad)
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("TipoCupo"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("TipoAtencion"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("IdInterconsultaE"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                Next
            End If

            'Atencion de CPT
            If chkAtendidos.Checked Then
                dsAtencion = objConsultaCPT.BuscarAtencion(dtpFecha.Value.ToShortDateString, cboTurno.Text, CodMedico)
                For I = 0 To dsAtencion.Tables(0).Rows.Count - 1
                    Fila = lvTabla.Items.Add(lvTabla.Items.Count + 1)
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("Historia"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("APaterno"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("AMaterno"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("Nombres"))
                    Edad = "0"
                    'Edad Paciente
                    If dsAtencion.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                        EdadA = 0 : Edad = "0"
                        If dsAtencion.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                            Dim Dias As Integer, Meses As Integer, Años As Integer
                            Dim DiasMes As Integer
                            Dim dfin, dinicio As Date
                            dfin = dtpFecha.Value
                            dinicio = dsAtencion.Tables(0).Rows(I)("FNacimiento")
                            Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                            Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                            Años = DateDiff("yyyy", dinicio, dfin)
                            'Verificar Dias
                            If Meses = 0 And Años = 0 Then
                                EdadA = 0
                                EdadM = 0
                                Dias = Math.Abs(Dias)
                                EdadD = Dias
                            Else
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
                                If Val(EdadA) > 0 Then
                                    Edad = EdadA & "A " & EdadM & "M"
                                Else
                                    Edad = EdadM & "M " & EdadD & "D"
                                End If
                            End If

                            If Val(EdadA) > 0 Then
                                Edad = EdadA & "A " & EdadM & "M"
                            Else
                                Edad = EdadM & "M " & EdadD & "D"
                            End If
                        End If
                    End If
                    Fila.SubItems.Add(Edad)
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("TipoCupo"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("TipoAtencion"))
                    Fila.SubItems.Add(dsAtencion.Tables(0).Rows(I)("IdProcedimiento"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                Next
            End If

            lblTotal.Text = lvTabla.Items.Count
        Else
            MessageBox.Show("Debe completar todos los datos", "Mensaje de Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgTabla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgTabla.KeyPress
        If UCase(e.KeyChar) = Convert.ToChar(Keys.V) Then
            If dgTabla.RowCount > 0 Then
                NHistoria = dgTabla.Item(1, dgTabla.CurrentRow.Index).Value
                NomPaciente = dgTabla.Item(2, dgTabla.CurrentRow.Index).Value & " " & dgTabla.Item(3, dgTabla.CurrentRow.Index).Value & " " & dgTabla.Item(4, dgTabla.CurrentRow.Index).Value
                CodCupo = dgTabla.Item(8, dgTabla.CurrentRow.Index).Value
                EspecialidadMedica = lblEspecialidad.Text
                objCupo.Atencion(CodCupo, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), My.Computer.Name, "INICIO")
                frmConsulta.Show()
            End If
        End If
    End Sub

    Private Sub chkAtendidos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAtendidos.CheckedChanged
        btnMostrar_Click(sender, e)
    End Sub

    Private Sub dtpFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress

    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        'If dtpFecha.Value < Date.Now Then MessageBox.Show("La fecha no puede ser menor a la actual", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : dtpFecha.Value = Date.Now : Exit Sub

        btnMostrar_Click(sender, e)
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            Y = 40
            .DrawString("MINISTERIO DE SALUD", FuenteTit, Pincel, 280, Y)
            Y = Y + 20
            .DrawString("Numero Formato", FuenteTex, Pincel, 40, Y)
            .DrawString("Cod. Codificador", FuenteTex, Pincel, 700, Y)
            Y = Y + 20
            .DrawString("Registro Diario de Atencion y Otras Actividades", FuenteTit, Pincel, 160, Y)
            Y = Y + 40

            .DrawString("Fecha   DPTO  PRO  DIST  EST         SERVICIO          NOMBRE DEL RESP. ATEN", Fuente, Pincel, 20, Y)
            Y = Y + 20
            .DrawLine(Pens.Black, 10, Y, 840, Y)
            Y = Y + 5
            .DrawString(Microsoft.VisualBasic.Right("00" & Month(dtpFecha.Value), 2) & "-" & Year(dtpFecha.Value) & StrDup(1, " ") & "13" & StrDup(3, " ") & "01" & StrDup(2, " ") & "01" & StrDup(3, " ") & "102" & StrDup(2, " ") & Microsoft.VisualBasic.Left(lblEspecialidad.Text & StrDup(16, " "), 16) & StrDup(2, " ") & Microsoft.VisualBasic.Left(NomMedico & StrDup(16, " "), 16), FuenteM, Pincel, 5, Y)
            Y = Y + 40
            .DrawString("  Dia HISTORIA  PROCED  EDAD SEXO ESTA SERV  DIAGNOSTICO/MOTIVO CONSULTA/ACT SALUD     TIP.DX   LAB  CIE10", FuenteTex, Pincel, 10, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 840, Y)
            Y = Y + 5
        End With
    End Sub

    Private Sub btnHIS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHIS.Click
        lvDet.Items.Clear()
        Dim dsTab As New Data.DataSet
        Dim Fila As ListViewItem
        dsTab = objConsulta.GenerarHIS(NomMedico, EspMedico, dtpFecha.Value.ToShortDateString)
        Dim I As Integer
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            'Segundo Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            End If
        Next
        TotalFilasLV = lvDet.Items.Count - 1
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NroPaginas = 1
        NroFilasTotales = 0
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Dim NroFila As Integer = 0
        Y = 20
        Encabezado(e)
        Filas = 10
        NroFilasHoja = 0
        Y = Y + 10
        With e.Graphics
            Do While NroFilasTotales <= TotalFilasLV
                If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                    NroFila += 1
                    .DrawString(Microsoft.VisualBasic.Right("00" & NroFila, 2) & ")", FuenteTex, Pincel, 5, Y)
                End If
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(0).Text, FuenteTex, Pincel, 30, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(1).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 60, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(3).Text, FuenteTex, Pincel, 120, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(4).Text & StrDup(3, " "), 3), FuenteTex, Pincel, 180, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(5).Text, FuenteTex, Pincel, 220, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(6).Text, FuenteTex, Pincel, 250, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(7).Text, FuenteTex, Pincel, 290, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(8).Text & StrDup(42, " "), 42), FuenteTex, Pincel, 310, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(9).Text, FuenteTex, Pincel, 630, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(11).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 710, Y)
                Y = Y + 12
                If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                    .DrawLine(Pens.Black, 10, Y, 840, Y)
                    Y = Y + 10
                Else
                    .DrawLine(Pens.Black, 300, Y, 840, Y)
                    Y = Y + 10
                End If

                NroFilasHoja += 1
                If NroFilasHoja = 50 Then
                    Exit Do
                End If
                NroFilasTotales += 1
            Loop
            'If NroFilasHoja < 5 Then
            '.DrawString("Trujillo, " & Date.Now.ToShortDateString, FuenteE, Pincel, 900, 700)
            '.DrawString(StrDup(10, " ") & StrDup(30, "-") & StrDup(10, " ") & StrDup(30, "-") & StrDup(10, " ") & StrDup(30, "-"), FuenteE, Pincel, 0, 720)
            '.DrawString(StrDup(15, " ") & Microsoft.VisualBasic.Left(txtA1.Text & StrDup(30, " "), 30) & StrDup(10, " ") & Microsoft.VisualBasic.Left(txtB1.Text & StrDup(30, " "), 30) & StrDup(10, " ") & Microsoft.VisualBasic.Left(txtC1.Text & StrDup(30, " "), 30), FuenteE, Pincel, 0, 735)
            '.DrawString(StrDup(10, " ") & Microsoft.VisualBasic.Left(txtA2.Text & StrDup(30, " "), 30) & StrDup(10, " ") & Microsoft.VisualBasic.Left(txtB2.Text & StrDup(30, " "), 30) & StrDup(12, " ") & Microsoft.VisualBasic.Left(txtC2.Text & StrDup(30, " "), 30), FuenteE, Pincel, 0, 750)

            'End If
            'If NroFilasHoja >= 50 Then
            '    e.HasMorePages = True
            '    NroFilasHoja = 0
            'Else
            '    e.HasMorePages = False
            'End If
        End With
    End Sub

    Private Sub btnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
        frmCambiarPac.Show()
    End Sub

    Private Sub lvTabla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTabla.DoubleClick
        If lvTabla.SelectedItems.Count > 0 Then
            vTurno = cboTurno.Text
            vMedico = lblMedico.Text
            If lvTabla.Items.Count > 0 Then
                vTipoAtencion = ""
                NHistoria = lvTabla.SelectedItems(0).SubItems(1).Text
                NomPaciente = lvTabla.SelectedItems(0).SubItems(2).Text & " " & lvTabla.SelectedItems(0).SubItems(3).Text & " " & lvTabla.SelectedItems(0).SubItems(4).Text
                CodCupo = lvTabla.SelectedItems(0).SubItems(8).Text
                EspecialidadMedica = lblEspecialidad.Text
                vFecha = dtpFecha.Value.ToShortDateString
                If lvTabla.SelectedItems(0).SubItems(7).Text = "INTERCONSULTA" Then
                    vTipoAtencion = "INTERCONSULTA"
                ElseIf lvTabla.SelectedItems(0).SubItems(7).Text = "INTERCONSULTAE" Then
                    vTipoAtencion = "INTERCONSULTAE"
                ElseIf lvTabla.SelectedItems(0).SubItems(7).Text = "PROCEDIMIENTO" Then
                    CodCupo = lvTabla.SelectedItems(0).SubItems(8).Text
                    frmProcedimientos.Show()
                    Exit Sub
                Else
                    objCupo.Atencion(CodCupo, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), My.Computer.Name, "INICIO")
                    vTipoAtencion = "CONSULTA"
                    If lvTabla.SelectedItems(0).SubItems(6).Text = "NUEVO" Or lvTabla.SelectedItems(0).SubItems(6).Text = "CONTINUADOR" Or lvTabla.SelectedItems(0).SubItems(6).Text = "REDIGITADO" Then
                        vTipoCupo = "COMUN"
                    ElseIf lvTabla.SelectedItems(0).SubItems(6).Text = "PROGRAMA" Then
                        vTipoCupo = "OTROS"
                    Else
                        vTipoCupo = lvTabla.SelectedItems(0).SubItems(6).Text
                    End If
                End If
                vNroPreliquidacion = lvTabla.SelectedItems(0).SubItems(9).Text
                vSerieSis = lvTabla.SelectedItems(0).SubItems(10).Text.ToString
                vNumeroSis = lvTabla.SelectedItems(0).SubItems(11).Text.ToString
                frmConsulta.Show()
            End If
        End If
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then lvTabla_DoubleClick(sender, e)
    End Sub

    Private Sub lvTabla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvTabla.KeyPress
        If UCase(e.KeyChar) = Convert.ToChar(Keys.V) Then lvTabla_DoubleClick(sender, e)
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub btnInterconsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInterconsultas.Click
        If lblEspecialidad.Text = "" Then MessageBox.Show("No presenta programacion para esta fecha", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        vEspecialidad = lblEspecialidad.Text
        vTurno = cboTurno.Text
        vFecha = dtpFecha.Value.ToShortDateString
        vTipoAtencion = "INTERCONSULTA"
        frmInterconsultaH.Show()
    End Sub

    Private Sub btnDeposito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeposito.Click
        frmDepositoImg.Show()
    End Sub

    Private Sub btnImprimirC_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirC.Click
        vFechaCita = dtpFecha.Value.ToShortDateString
        vTurnoCita = cboTurno.Text
        vFecha = dtpFecha.Value.ToShortDateString
        EspecialidadMedica = lblEspecialidad.Text
        frmImprimirConsultas.Show()
    End Sub

    Private Sub btnInterconsultaE_Click(sender As System.Object, e As System.EventArgs) Handles btnInterconsultaE.Click
        If lblEspecialidad.Text = "" Then MessageBox.Show("No presenta programacion para esta fecha", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        EspecialidadMedica = lblEspecialidad.Text
        EspMedico = lblEspecialidad.Text
        vTurno = cboTurno.Text
        vFecha = dtpFecha.Value.ToShortDateString
        vMedico = lblMedico.Text
        vTipoAtencion = "INTERCONSULTAE"
        frmInterconsultaE.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        vEspecialidad = lblEspecialidad.Text
        frmPapeletaHospitalizacion.Show()
    End Sub
End Class
