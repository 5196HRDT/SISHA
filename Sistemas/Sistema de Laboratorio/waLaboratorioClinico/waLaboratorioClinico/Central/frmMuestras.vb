Public Class frmMuestras
    Dim objConsulta As New clsConsultaExterna
    Dim objInterconsultaE As New clsInterconsultaE
    Dim objHistoria As New clsHistoria
    Dim objServicio As New Servicio
    Dim objSIS As New clsSIS
    Dim objComprobante As New clsComprobanteVta

    Dim SubTipo As String
    Dim Elisa As Boolean
    Dim Parasitos As Boolean
    Dim GlucosaP As Boolean
    Dim DXP1 As String
    Dim DXP2 As String
    Dim DXP3 As String
    Dim HistoriaP As String
    Dim SubTipoP As String
    Dim ServicioP As String



    'Variables Impresion
    Dim Fuente20N As New Font("Courier New", 20, FontStyle.Bold)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente10 As New Font("Courier New", 10, FontStyle.Bold)
    Dim Fuente8 As New Font("Courier New", 8, FontStyle.Bold)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim TotalFilas As Integer
    Dim NroFila As Integer
    Dim Y As Integer
    Dim NumeroHistoria As String


    Private Sub frmMuestras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Buscar("", 1)
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"

        dtpF1.Value = Date.Now.ToShortDateString
        dtpF2.Value = Date.Now.ToShortDateString
    End Sub

    Private Sub cboServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboServicio.SelectedValue) Then txtPaciente.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServicio.SelectedIndexChanged

    End Sub

    Private Sub dtpF1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Sub dtpF1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF1.ValueChanged

    End Sub

    Private Sub dtpF2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then btnBuscar.Select()
    End Sub

    Private Function Verificar(ByVal IdProcedimiento As String) As Boolean
        Verificar = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(14).Text = IdProcedimiento Then Verificar = True : Exit For
        Next
    End Function

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        If Not IsNumeric(cboServicio.SelectedValue) Then MessageBox.Show("Debe seleccionar un Area de Laboratorio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboServicio.Select() : Exit Sub
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        Dim dsConsulta As New DataSet

        Elisa = False
        Parasitos = False
        GlucosaP = False
        DXP1 = ""
        DXP2 = ""
        DXP3 = ""
        HistoriaP = ""
        SubTipoP = ""
        If chConvenio.Checked = True Then
            dsVer = objConsulta.BuscarProcedimientoConvenio(txtPaciente.Text, dtpF1.Value, dtpF2.Value)
            Dim i As Integer
            Dim fila As ListViewItem
            For i = 0 To dsVer.Tables(0).Rows.Count - 1
                fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(i)("IdProcedimiento"))
                fila.SubItems.Add(dsVer.Tables(0).Rows(i)("TipoConvenio"))
                fila.SubItems.Add(dsVer.Tables(0).Rows(i)("Historia"))
                fila.SubItems.Add(dsVer.Tables(0).Rows(i)("Paciente"))
                fila.SubItems.Add(dsVer.Tables(0).Rows(i)("Tipo"))
                fila.SubItems.Add(dsVer.Tables(0).Rows(i)("Descripcion"))
                If dsVer.Tables(0).Rows(i)("Descripcion") = "HIV POR ELISA" Then Elisa = True
                'Validar Investigacion de Parásitos
                If dsVer.Tables(0).Rows(i)("Descripcion") = "INV.DE PARASITOS INTESTINALES.SEREADO/CADA MUESTRA" And Val(dsVer.Tables(0).Rows(i)("Cantidad")) > 1 Then Parasitos = True
                'Validar Glucosa Post Pandrial
                If dsVer.Tables(0).Rows(i)("Descripcion") = "GLUCOSA POST-PRANDIAL" Then GlucosaP = True

                fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(i)("Cantidad")), "#.00"))
                fila.SubItems.Add(dsVer.Tables(0).Rows(i)("FechaRegistro"))
                fila.SubItems.Add(dsVer.Tables(0).Rows(i)("HoraRegistro"))
            Next
        Else
            dsVer = objConsulta.BuscarExaMuestra(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, cboServicio.Text, txtPaciente.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))

                'Validar Examen Elisa

                If dsVer.Tables(0).Rows(I)("Descripcion") = "HIV POR ELISA" Then Elisa = True

                'Validar Investigacion de Parásitos
                If dsVer.Tables(0).Rows(I)("Descripcion") = "INV.DE PARASITOS INTESTINALES.SEREADO/CADA MUESTRA" And Val(dsVer.Tables(0).Rows(I)("Cantidad")) > 1 Then Parasitos = True

                'Validar Glucosa Post Pandrial
                If dsVer.Tables(0).Rows(I)("Descripcion") = "GLUCOSA POST-PRANDIAL" Then GlucosaP = True

                Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#.00"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegistro"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraRegistro"))
                'Agregar Diagnosticos
                If dsVer.Tables(0).Rows(I)("IdCupo") > 0 Then
                    dsConsulta = objConsulta.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                    If dsConsulta.Tables(0).Rows.Count > 0 Then
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des1"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des2"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des3"))
                    Else
                        dsConsulta = objInterconsultaE.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                        If dsConsulta.Tables(0).Rows.Count > 0 Then
                            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des1"))
                            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des2"))
                            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des3"))
                        Else
                            Fila.SubItems.Add("")
                            Fila.SubItems.Add("")
                            Fila.SubItems.Add("")
                        End If
                    End If
                Else
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
                Fila.SubItems.Add("CE")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdExamen"))
                Application.DoEvents()
            Next

            'Lista de Procedimientos Caja de Emergencia
            dsVer = objComprobante.BuscarLabDocEmergencia(txtPaciente.Text)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                If Not Verificar(dsVer.Tables(0).Rows(I)("IdServicioItem")) Then
                    Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdComprobante"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubServicio").ToString)
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NHistoria"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                    Fila.SubItems.Add("COMUN")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))

                    'Validar Examen Elisa
                    If dsVer.Tables(0).Rows(I)("Descripcion") = "HIV POR ELISA" Then Elisa = True

                    'Validar Investigacion de Parásitos
                    If dsVer.Tables(0).Rows(I)("Descripcion") = "INV.DE PARASITOS INTESTINALES.SEREADO/CADA MUESTRA" And Val(dsVer.Tables(0).Rows(I)("Cantidad")) > 1 Then Parasitos = True

                    'Validar Glucosa Post Pandrial
                    If dsVer.Tables(0).Rows(I)("Descripcion") = "GLUCOSA POST-PRANDIAL" Then GlucosaP = True

                    Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#.00"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Hora"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Fila.SubItems.Add("CAJA EMERGENCIA")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Precio"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(0)
                End If
                Application.DoEvents()
            Next

            'Lista de Procedimientos del SIS
            dsVer = objSIS.BuscarLabAtencionCE(txtPaciente.Text, cboServicio.Text)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                If Not Verificar(dsVer.Tables(0).Rows(I)("IdProcedimiento")) Then
                    Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("Id"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubEspecialidad"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                    Fila.SubItems.Add("SIS")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))

                    'Validar Examen Elisa
                    If dsVer.Tables(0).Rows(I)("Descripcion") = "HIV POR ELISA" Then Elisa = True

                    'Validar Investigacion de Parásitos
                    If dsVer.Tables(0).Rows(I)("Descripcion") = "INV.DE PARASITOS INTESTINALES.SEREADO/CADA MUESTRA" And Val(dsVer.Tables(0).Rows(I)("Cantidad")) > 1 Then Parasitos = True

                    'Validar Glucosa Post Pandrial
                    If dsVer.Tables(0).Rows(I)("Descripcion") = "GLUCOSA POST-PRANDIAL" Then GlucosaP = True

                    Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#.00"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegistro"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraRegistro"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Fila.SubItems.Add("SIS")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdProcedimiento"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Lote"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Numero"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Precio"))
                End If
                Application.DoEvents()
            Next

            'Certificado Médico
            dsVer = objComprobante.BuscarRayCertificado(txtPaciente.Text)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                If Not Verificar("3210") Then
                    Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdComprobante"))
                    Fila.SubItems.Add("TRAMITE DOCUMENTARIO")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NHistoria"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                    Fila.SubItems.Add("COMUN")
                    Fila.SubItems.Add("RPR")
                    Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#.00"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Hora"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("MICROBIOLOGIA")
                    Fila.SubItems.Add("CAJA EMERGENCIA")
                    Fila.SubItems.Add("3210")
                    Fila.SubItems.Add("0.00")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(0)
                End If
                Application.DoEvents()
            Next
        End If
        

        MessageBox.Show("Datos encontrado hasta el momento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF1.Select()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdAtender_Click(sender As System.Object, e As System.EventArgs) Handles cmdAtender.Click
        If MessageBox.Show("Esta seguro de Recepcionar las Muestra?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                If lvTabla.Items(I).SubItems(2).Text <> "" Then
                    If lvTabla.Items(I).SubItems(13).Text = "CE" Then
                        objConsulta.MuestraTomada(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name)
                    ElseIf lvTabla.Items(I).SubItems(13).Text = "SIS" Then
                        objSIS.AtencionProcedimientoSisEq(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name)
                        objConsulta.GrabarExaSISCE(0, lvTabla.Items(I).SubItems(14).Text, lvTabla.Items(I).SubItems(5).Text, lvTabla.Items(I).SubItems(17).Text, lvTabla.Items(I).SubItems(6).Text, 0, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, "LABORATORIO", lvTabla.Items(I).SubItems(12).Text, "SIS", 0, lvTabla.Items(I).SubItems(15).Text, lvTabla.Items(I).SubItems(16).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "")
                    ElseIf lvTabla.Items(I).SubItems(13).Text = "CAJA EMERGENCIA" Then
                        objConsulta.GrabarExaSISCE(0, lvTabla.Items(I).SubItems(14).Text, lvTabla.Items(I).SubItems(5).Text, lvTabla.Items(I).SubItems(15).Text, lvTabla.Items(I).SubItems(6).Text, 0, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, "LABORATORIO", lvTabla.Items(I).SubItems(12).Text, "COMUN", 0, lvTabla.Items(I).SubItems(16).Text, lvTabla.Items(I).SubItems(17).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "")
                        objComprobante.MarcarDocEmerRecibido(lvTabla.Items(I).SubItems(0).Text, "LABORATORIO", lvTabla.Items(I).SubItems(12).Text)
                    End If
                Else
                    objConsulta.MuestraTomada(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name)
                End If
            Next

            btnBuscar_Click(sender, e)
        End If
    End Sub

    Private Sub Cabecera(ByVal Historia As String, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        With e.Graphics
            Dim dsHistoria As New DataSet
            Dim Edad As String
            If Val(Historia) <> 0 Then
                dsHistoria = objHistoria.Buscar(Historia)
                If dsHistoria.Tables(0).Rows.Count > 0 Then
                    .DrawString(Date.Now.ToShortDateString & " - " & Date.Now.ToShortTimeString, Fuente10, Pincel, 20, Y)
                    Y = Y + 15
                    .DrawString("Nro Historia: " & Historia, Fuente10, Pincel, 20, Y)
                    Y = Y + 15
                    .DrawString("Paciente    : ", Fuente10, Pincel, 20, Y)
                    Y = Y + 15
                    .DrawString(dsHistoria.Tables(0).Rows(0)("Apaterno") & " " & dsHistoria.Tables(0).Rows(0)("Amaterno") & " " & dsHistoria.Tables(0).Rows(0)("Nombres"), Fuente10, Pincel, 20, Y)
                    Y = Y + 15
                    'Calcular Edad
                    If dsHistoria.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                        Dim Dias As Integer, Meses As Integer, Años As Integer
                        Dim DiasMes As Integer
                        Dim dfin, dinicio As Date
                        Dim EdadA, EdadM, EdadD As String
                        dfin = Date.Now.ToShortDateString
                        dinicio = dsHistoria.Tables(0).Rows(0)("FNACIMIENTO")
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
                        Edad = EdadA & " A " & EdadM & " M " & EdadD & " D "
                    Else
                        Edad = ""
                    End If
                    .DrawString("Edad : " & Edad & StrDup(1, " ") & "Sexo:" & Microsoft.VisualBasic.Left(dsHistoria.Tables(0).Rows(0)("Sexo").ToString, 2), Fuente10, Pincel, 20, Y)
                    Y = Y + 15
                    .DrawString("Area : " & SubTipo, Fuente10, Pincel, 20, Y)
                    Y = Y + 15
                End If
            Else
                .DrawString(Date.Now.ToShortDateString & " - " & Date.Now.ToShortTimeString, Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString("Nro Historia: PARTICULAR", Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString("Paciente    : ", Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString(lvTabla.Items(0).SubItems(3).Text, Fuente10, Pincel, 20, Y)
                Y = Y + 15
            End If
        End With
    End Sub

    Private Sub pdDocumento_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdDocumento.BeginPrint
        Y = 10
        TotalFilas = lvTabla.Items.Count - 1
        NroFila = 0
        SubTipo = ""
    End Sub

    Private Sub pdDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdDocumento.PrintPage
        Dim K As Integer
        With e.Graphics
            Do While TotalFilas >= 0
                If NroFila = 0 Then
                    NumeroHistoria = lvTabla.Items(NroFila).SubItems(2).Text
                    SubTipo = lvTabla.Items(NroFila).SubItems(12).Text
                    Cabecera(lvTabla.Items(NroFila).SubItems(2).Text, e)
                    .DrawString("Servicio: " & lvTabla.Items(NroFila).SubItems(1).Text, Fuente10, Pincel, 20, Y)
                    If lvTabla.Items(NroFila).SubItems(9).Text <> "" Then Y = Y + 15 : .DrawString("DX1: " & lvTabla.Items(NroFila).SubItems(9).Text, Fuente8, Pincel, 20, Y)
                    If lvTabla.Items(NroFila).SubItems(10).Text <> "" Then Y = Y + 15 : .DrawString("DX2: " & lvTabla.Items(NroFila).SubItems(10).Text, Fuente8, Pincel, 20, Y)
                    If lvTabla.Items(NroFila).SubItems(11).Text <> "" Then Y = Y + 15 : .DrawString("DX3: " & lvTabla.Items(NroFila).SubItems(11).Text, Fuente8, Pincel, 20, Y)
                Else
                    If NumeroHistoria <> lvTabla.Items(NroFila).SubItems(2).Text Then
                        NumeroHistoria = lvTabla.Items(NroFila).SubItems(2).Text
                        'Y = Y + 15
                        '.DrawString(StrDup(20, "="), Fuente12N, Pincel, 20, Y)
                        Y = Y + 25
                        Cabecera(lvTabla.Items(NroFila).SubItems(2).Text, e)
                        .DrawString("Servicio: " & lvTabla.Items(NroFila).SubItems(1).Text, Fuente10, Pincel, 20, Y)
                        If lvTabla.Items(NroFila).SubItems(9).Text <> "" Then Y = Y + 15 : .DrawString("DX1: " & lvTabla.Items(NroFila).SubItems(9).Text, Fuente8, Pincel, 20, Y)
                        If lvTabla.Items(NroFila).SubItems(10).Text <> "" Then Y = Y + 15 : .DrawString("DX2: " & lvTabla.Items(NroFila).SubItems(10).Text, Fuente8, Pincel, 20, Y)
                        If lvTabla.Items(NroFila).SubItems(11).Text <> "" Then Y = Y + 15 : .DrawString("DX3: " & lvTabla.Items(NroFila).SubItems(11).Text, Fuente8, Pincel, 20, Y)
                    Else
                        If SubTipo <> lvTabla.Items(NroFila).SubItems(12).Text Then
                            SubTipo = lvTabla.Items(NroFila).SubItems(12).Text
                            If lvTabla.Items(NroFila).SubItems(5).Text = "ORINA COMPLETA" And lvTabla.Items.Count = 1 Then
                                For K = 1 To 4
                                    Y = Y + 15
                                    .DrawString(StrDup(40, "_"), Fuente8, Pincel, 20, Y)
                                Next
                            Else
                                For K = 1 To 2
                                    Y = Y + 15
                                    .DrawString(StrDup(40, "_"), Fuente8, Pincel, 20, Y)
                                Next
                            End If
                            'Y = Y + 15
                            '.DrawString(StrDup(20, "="), Fuente12N, Pincel, 20, Y)
                            Y = Y + 25
                            Cabecera(lvTabla.Items(NroFila).SubItems(2).Text, e)
                            .DrawString("Servicio: " & lvTabla.Items(NroFila).SubItems(1).Text, Fuente10, Pincel, 20, Y)
                            If lvTabla.Items(NroFila).SubItems(9).Text <> "" Then Y = Y + 15 : .DrawString("DX1: " & lvTabla.Items(NroFila).SubItems(9).Text, Fuente8, Pincel, 20, Y)
                            If lvTabla.Items(NroFila).SubItems(10).Text <> "" Then Y = Y + 15 : .DrawString("DX2: " & lvTabla.Items(NroFila).SubItems(10).Text, Fuente8, Pincel, 20, Y)
                            If lvTabla.Items(NroFila).SubItems(11).Text <> "" Then Y = Y + 15 : .DrawString("DX3: " & lvTabla.Items(NroFila).SubItems(11).Text, Fuente8, Pincel, 20, Y)
                        End If
                    End If
                End If
                If lvTabla.Items(NroFila).SubItems(5).Text <> "GLUCOSA POST-PRANDIAL" Then
                    HistoriaP = lvTabla.Items(NroFila).SubItems(2).Text
                    SubTipoP = lvTabla.Items(NroFila).SubItems(12).Text
                    ServicioP = lvTabla.Items(NroFila).SubItems(1).Text
                    If lvTabla.Items(NroFila).SubItems(9).Text <> "" Then Y = Y + 15 : DXP1 = lvTabla.Items(NroFila).SubItems(9).Text Else DXP1 = ""
                    If lvTabla.Items(NroFila).SubItems(10).Text <> "" Then Y = Y + 15 : DXP2 = lvTabla.Items(NroFila).SubItems(10).Text Else DXP2 = ""
                    If lvTabla.Items(NroFila).SubItems(11).Text <> "" Then Y = Y + 15 : DXP3 = lvTabla.Items(NroFila).SubItems(11).Text Else DXP3 = ""
                    Y = Y + 15
                    .DrawString(Microsoft.VisualBasic.Right(StrDup(2, " ") & Math.Round(Val(lvTabla.Items(NroFila).SubItems(6).Text), 0), 2) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvTabla.Items(NroFila).SubItems(5).Text & StrDup(25, " "), 25), Fuente8, Pincel, 20, Y)
                End If

                'Otras Filas Datos
                If lvTabla.Items(NroFila).SubItems(5).Text = "EXAMEN DIRECTO DE HONGOS" Then
                    Y = Y + 15
                    .DrawString("Piel( ) Orina( ) Esputo( ) Otros( )", Fuente8, Pincel, 20, Y)
                ElseIf lvTabla.Items(NroFila).SubItems(5).Text = "EXAMEN DIRECTO (GRAM)" Then
                    Y = Y + 15
                    .DrawString("Orina( ) Secreción( ) Otros( )", Fuente8, Pincel, 20, Y)
                ElseIf lvTabla.Items(NroFila).SubItems(5).Text = "AGLUTINACIONES, TIFICAS O H Y PARATIFICOS AG. Y B(WIDAL)" Then
                    Y = Y + 15
                    .DrawString("Antecedentes de Tratamiento (SI) (NO)", Fuente8, Pincel, 20, Y)
                    Y = Y + 15
                    .DrawString("Antibioticos:", Fuente8, Pincel, 20, Y)
                    Y = Y + 15
                    .DrawString("Sangre( ) Esputo( ) LB( ) Origna( )", Fuente8, Pincel, 20, Y)
                    Y = Y + 15
                    .DrawString("Aspirado Bronquial( ) Otros:", Fuente8, Pincel, 20, Y)
                ElseIf lvTabla.Items(NroFila).SubItems(5).Text = "RPR" Then
                    Y = Y + 15
                    .DrawString("SUERO(  ) PLASMA(  )", Fuente8, Pincel, 20, Y)
                ElseIf lvTabla.Items(NroFila).SubItems(5).Text = "ESTUDIO DE LÍQUIDO CITOQUIMICO" Then
                    Y = Y + 15
                    .DrawString("Recibio Antibiótico (SI) (NO)", Fuente8, Pincel, 20, Y)
                    Y = Y + 15
                    .DrawString("LCR( ) PLEURAL( ) ASCITICO( ) OTRO( )", Fuente8, Pincel, 20, Y)
                ElseIf lvTabla.Items(NroFila).SubItems(5).Text = "INV.DE PARASITOS INTESTINALES.SEREADO/CADA MUESTRA" Then
                    HistoriaP = lvTabla.Items(NroFila).SubItems(2).Text
                    SubTipoP = lvTabla.Items(NroFila).SubItems(12).Text
                    ServicioP = lvTabla.Items(NroFila).SubItems(1).Text
                    If lvTabla.Items(NroFila).SubItems(9).Text <> "" Then Y = Y + 15 : DXP1 = lvTabla.Items(NroFila).SubItems(9).Text Else DXP1 = ""
                    If lvTabla.Items(NroFila).SubItems(10).Text <> "" Then Y = Y + 15 : DXP2 = lvTabla.Items(NroFila).SubItems(10).Text Else DXP2 = ""
                    If lvTabla.Items(NroFila).SubItems(11).Text <> "" Then Y = Y + 15 : DXP3 = lvTabla.Items(NroFila).SubItems(11).Text Else DXP3 = ""
                    Y = Y + 15
                    .DrawString("1era Muestra( ) 2da Muestra( ) 3era Muestra( )", Fuente8, Pincel, 20, Y)
                ElseIf lvTabla.Items(NroFila).SubItems(5).Text = "BARTONELOSIS" Then
                    Y = Y + 15
                    .DrawString("Diagnóstico( ) Control( )", Fuente8, Pincel, 20, Y)
                ElseIf lvTabla.Items(NroFila).SubItems(5).Text = "LEISHMANIASIS" Then
                    Y = Y + 15
                    .DrawString("Diagnóstico(  ) Control: 1°( )", Fuente8, Pincel, 20, Y)
                ElseIf lvTabla.Items(NroFila).SubItems(5).Text = "GOTA GRUESA" Then
                    Y = Y + 15
                    .DrawString("Diagnóstico(  ) Control: (1°)  (2°)  (3°)  (4°)", Fuente8, Pincel, 20, Y)
                End If

                NroFila += 1
                TotalFilas -= 1
            Loop

            For K = 1 To 2
                Y = Y + 15
                .DrawString(StrDup(40, "_"), Fuente8, Pincel, 20, Y)
            Next

            If Parasitos Then
                Dim P As Integer
                For P = 1 To 2
                    'Y = Y + 15
                    '.DrawString(StrDup(20, "="), Fuente12N, Pincel, 20, Y)
                    Y = Y + 25
                    SubTipo = SubTipoP
                    Cabecera(HistoriaP, e)
                    .DrawString("Servicio: " & ServicioP, Fuente10, Pincel, 20, Y)
                    If DXP1 <> "" Then Y = Y + 15 : .DrawString("DX1: " & DXP1, Fuente8, Pincel, 20, Y)
                    If DXP2 <> "" Then Y = Y + 15 : .DrawString("DX2: " & DXP2, Fuente8, Pincel, 20, Y)
                    If DXP3 <> "" Then Y = Y + 15 : .DrawString("DX3: " & DXP3, Fuente8, Pincel, 20, Y)

                    Y = Y + 15
                    .DrawString(" 1" & StrDup(2, " ") & Microsoft.VisualBasic.Left("INV.DE PARASITOS INTESTINALES.SEREADO/CADA MUESTRA" & StrDup(25, " "), 25), Fuente8, Pincel, 20, Y)
                    For K = 1 To 2
                        Y = Y + 15
                        .DrawString(StrDup(40, "_"), Fuente8, Pincel, 20, Y)
                    Next
                Next
            End If

            If GlucosaP Then
                Dim P As Integer
                For P = 1 To 1
                    'Y = Y + 15
                    '.DrawString(StrDup(20, "="), Fuente12N, Pincel, 20, Y)
                    Y = Y + 25
                    SubTipo = SubTipoP
                    Cabecera(HistoriaP, e)
                    .DrawString("Servicio: " & ServicioP, Fuente10, Pincel, 20, Y)
                    If DXP1 <> "" Then Y = Y + 15 : .DrawString("DX1: " & DXP1, Fuente8, Pincel, 20, Y)
                    If DXP2 <> "" Then Y = Y + 15 : .DrawString("DX2: " & DXP2, Fuente8, Pincel, 20, Y)
                    If DXP3 <> "" Then Y = Y + 15 : .DrawString("DX3: " & DXP3, Fuente8, Pincel, 20, Y)

                    Y = Y + 15
                    .DrawString(" 1" & StrDup(2, " ") & Microsoft.VisualBasic.Left("GLUCOSA POST-PRANDIAL" & StrDup(25, " "), 25), Fuente8, Pincel, 20, Y)
                    For K = 1 To 2
                        Y = Y + 15
                        .DrawString(StrDup(40, "_"), Fuente8, Pincel, 20, Y)
                    Next
                Next
            End If

            e.HasMorePages = False
        End With
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        If Elisa Then
            If MessageBox.Show("EL PACIENTE HA RECIBIDO LA ASESORIA DE CERITS?, Validar Respuesta Para Posterior Auditoria", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                MessageBox.Show("Enviar a paciente a CERITS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        ppdDocumento.ShowDialog()

        cmdAtender_Click(sender, e)
    End Sub

    Private Sub chkArea_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkArea.CheckedChanged
        If chkArea.Checked Then
            cboServicio.Enabled = False
        Else
            cboServicio.Enabled = True
        End If
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
        End If
    End Sub
End Class