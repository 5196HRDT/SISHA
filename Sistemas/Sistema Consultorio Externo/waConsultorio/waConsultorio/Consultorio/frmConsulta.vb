Imports System.IO
Imports System.Drawing.Graphics
Public Class frmConsulta
    Dim objConsulta As New Consulta
    Dim objInterconsultaH As New InterconsultaH
    Dim objInterconsultaE As New InterconsultaE
    Dim objMedicamento As New Medicamentos
    Dim objExamen As New Procedimientos
    Dim objCupo As New Cupo
    Dim objEspecialidad As New Especialidad
    Dim objSubEspecialidad As New SubEspecialidad
    Dim objProgramacion As New Programacion
    Dim objHosp As New Hospitalizacion
    Dim objEmergencia As New Emergencia
    Dim objHistoria As New Historia
    Dim objCIE As New CIE
    Dim objRayos As New Rayos
    Dim objDeposito As New DepositoImagen
    Dim objUbigeo As New clsUbigeo
    Dim objCIE10 As New CIE10
    Dim objCIELAB As New CIELAB
    Dim objSis As New Sis
    Dim objConvenio As New Convenio
    Dim objSoat As New SOAT
    Dim objLaboratorio As New Laboratorio
    Dim objReceta As New RecetaMedicaSIS
    Dim objDosis As New DosisRecetaMedica
    Dim objtempHClinica As New tempHConsulta
    Dim objMedico As New Medico
    Dim objCandidato As New CandidatoIncorp
    Dim objPatologia As New Patologia
    Dim objInformeEKG As New EKG
    Dim objEKGCie As New clsEKGCie
    Dim objEmergenciaIngreso As New EmergenciaIngreso
    Dim objAltaEmergencia As New AltaEmergencia
    Dim objServicioItem As New ServicioItem
    Dim objItemServicio As New ItemServicio
    Dim objElectroencefalograma As New clsElectroencefalograma

    Dim nomFiltro As String
    Dim Filtro As String
    Dim StockMed As String
    Dim ValorRealCN As String
    Dim ValorRealCC As String
    Dim ValorRealCP As String
    Dim CodPro As String
    Dim Fecha As String
    Dim Informe As String
    Dim Procedimiento As String
    Dim TBusqueda As Boolean
    Dim EdadA, EdadM, EdadD As Integer

    'Dibujo a mano alzada
    Public X1, X2, Y1, Y2, C As Integer
    Dim y As Integer
    Dim inicio As Integer = 0
    Dim W As System.Drawing.Color = Color.Aqua
    Dim H As System.Drawing.Pen
    Dim bandera As Integer


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

    Private Function DevolverDescripcionCIE(ByVal CIE As String, ByVal Combo As ComboBox) As String
        Dim dsTabla As New Data.DataSet
        dsTabla = objCIE10.Buscar(CIE, 1)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            DevolverDescripcionCIE = dsTabla.Tables(0).Rows(0)("Descripcion")
            If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then Combo.Text = "DEFINITIVO"
        Else
            MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DevolverDescripcionCIE = ""
        End If
    End Function

    Private Sub frmConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnHemodialisis.Visible = True
        btnTomografia.Visible = True
        gbFiltro.Left = 306
        gbFiltro.Top = 58
        gbConsulta.Left = 23
        gbConsulta.Top = 359
        Dim Fila As ListViewItem

        'Borrar Archivo Espirometría
        Dim Archivo As String = Application.StartupPath() & "\mydocumento.pdf"
        If My.Computer.FileSystem.FileExists(Archivo) Then My.Computer.FileSystem.DeleteFile(Archivo)

        gbLabCE.Visible = False
        gbLabE.Visible = False
        gbLabH.Visible = False

        'Mano Alzada
        W = Color.Black
        H = New Pen(W, 1)
        inicio = 1
        cboTamaño.Text = 1
        cboColor.Text = "Negro"

        Limpiar(Me)
        Dim Edad As String
        lblHistoria.Text = NHistoria
        lblPaciente.Text = Microsoft.VisualBasic.Left(NomPaciente & StrDup(28, " "), 28)
        lblNCupo_TextChanged(sender, e)

        'Dosis
        Dim dsDosis As New DataSet
        dsDosis = objDosis.Combo
        cboDosis.DataSource = dsDosis.Tables(0)
        cboDosis.DisplayMember = "Descripcion"
        cboDosis.ValueMember = "IdDosis"

        'Departamento
        Dim dsDpto As New Data.DataSet
        dsDpto = objUbigeo.Departamento
        cboDepartamento.DataSource = dsDpto.Tables(0)
        cboDepartamento.DisplayMember = "desc_dpto"
        cboDepartamento.ValueMember = "cod_dpto"
        cboDepartamento.Text = "LA LIBERTAD"
        cboDepartamento_SelectedIndexChanged(sender, e)
        txtNroPre.Text = vNroPreliquidacion
        txtSerieSis.Text = vSerieSis
        txtNumeroSis.Text = vNumeroSis

        'Datos de Historia Clinica
        Dim Año As Integer
        Dim dsHistoria As Data.DataSet
        dsHistoria = objHistoria.BuscarHistoria(NHistoria)
        If dsHistoria.Tables(0).Rows.Count > 0 Then
            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistoria.Tables(0).Rows(0)("Sexo"), 1)
            EdadA = 0 : Edad = "0" : EdadM = 0 : EdadD = 0

            If dsHistoria.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                'Edad Paciente
                If dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                    EdadA = 0 : Edad = "0"
                    If dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                        Dim Dias As Integer, Meses As Integer, Años As Integer
                        Dim DiasMes As Integer
                        Dim dfin, dinicio As Date
                        dfin = Date.Now
                        dinicio = dsHistoria.Tables(0).Rows(0)("FNacimiento")
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

                lbledad.Text = Edad
                lblFNac.Text = dsHistoria.Tables(0).Rows(0)("FNACIMIENTO")
            Else
                MessageBox.Show("Estadistica no ha Registrado Correctamente la Fecha de Nacimiento!!!!  Se procedera a Registrar", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim NFECHA As Date
                Try
                    NFECHA = InputBox("Ingresar Fecha de Nacimiento Formato dd/MM/yyyy", "Datos de Paciente")
                Catch ex As Exception
                    MessageBox.Show("Dede ingresar correctamente la fecha de nacimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                End Try
                If Not IsDate(NFECHA) Then btnGrabar.Enabled = False : MessageBox.Show("Dede ingresar correctamente la fecha de nacimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                EdadA = 0 : Edad = "0" : EdadM = 0 : EdadD = 0
                If NFECHA.ToString <> "" Then
                    If NFECHA.ToString <> "" Then
                        Dim Dias As Integer, Meses As Integer, Años As Integer
                        Dim DiasMes As Integer
                        Dim dfin, dinicio As Date
                        dfin = Date.Now
                        dinicio = NFECHA
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
                lbledad.Text = Edad
                lblFNac.Text = NFECHA
                objHistoria.GrabarFN(lblHistoria.Text, NFECHA.ToShortDateString)
            End If
        End If

        'Historial Hospitalizacion
        Dim dsHosp As New Data.DataSet
        Dim I As Integer
        Dim FilaH As ListViewItem
        Dim FechaSalida As String
        dsHosp = objHosp.BuscarHospitalizacion(NHistoria)
        For I = 0 To dsHosp.Tables(0).Rows.Count - 1
            FilaH = lvHosp.Items.Add(dsHosp.Tables(0).Rows(I)("ServicioHosp"))
            FilaH.SubItems.Add(dsHosp.Tables(0).Rows(I)("FecIngreso"))
            FechaSalida = dsHosp.Tables(0).Rows(I)("FecSalida").ToString
            If FechaSalida.Length > 0 Then FilaH.SubItems.Add(dsHosp.Tables(0).Rows(I)("FecSalida")) Else FilaH.SubItems.Add("")
            FilaH.SubItems.Add(dsHosp.Tables(0).Rows(I)("TipoSalida"))
            FilaH.SubItems.Add(dsHosp.Tables(0).Rows(I)("Alta"))
            FilaH.SubItems.Add(dsHosp.Tables(0).Rows(I)("Tipo"))
            FilaH.SubItems.Add(dsHosp.Tables(0).Rows(I)("NroCama"))
            FilaH.SubItems.Add(dsHosp.Tables(0).Rows(I)("IdHospitalizacion"))
        Next

        'Historial Emergencia
        'Dim dsEmer As New Data.DataSet
        'Dim FilaE As ListViewItem
        'Dim FechaAlta As String
        'Dim CondicionAlta As String
        'Dim TipoAlta As String
        'dsEmer = objEmergencia.EmergenciaIngreso_Listas(NHistoria)
        'For I = 0 To dsEmer.Tables(0).Rows.Count - 1
        '    FilaE = lvHosp.Items.Add(dsEmer.Tables(0).Rows(I)("Especialidad"))
        '    FilaE.SubItems.Add(dsEmer.Tables(0).Rows(I)("FechaIngreso"))
        '    FechaAlta = dsEmer.Tables(0).Rows(I)("FechaAlta").ToString
        '    If FechaAlta = "" Then FilaE.SubItems.Add("") Else FilaE.SubItems.Add(dsEmer.Tables(0).Rows(I)("FechaAlta"))
        '    CondicionAlta = dsEmer.Tables(0).Rows(I)("CondicionAlta").ToString
        '    If CondicionAlta = "" Then FilaE.SubItems.Add("") Else FilaE.SubItems.Add(dsEmer.Tables(0).Rows(I)("CondicionAlta"))
        '    TipoAlta = dsEmer.Tables(0).Rows(I)("TipoAlta").ToString
        '    If TipoAlta = "" Then FilaE.SubItems.Add("") Else FilaE.SubItems.Add(dsEmer.Tables(0).Rows(I)("TipoAlta"))

        '    FilaE.SubItems.Add(dsEmer.Tables(0).Rows(I)("TipoPaciente"))
        '    FilaE.SubItems.Add("")
        '    FilaE.SubItems.Add(dsEmer.Tables(0).Rows(I)("IdIngreso"))
        'Next

        lvEmergencia.Items.Clear()
        lvEmergencia.Enabled = True
        Dim dsLista As New DataSet
        dsLista = objEmergenciaIngreso.BuscarHistoria(lblHistoria.Text)

        For I = 0 To dsLista.Tables(0).Rows.Count - 1
            Fila = lvEmergencia.Items.Add(dsLista.Tables(0).Rows(I)("IdIngreso"))
            Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("FechaIngreso"))
            Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("HoraIngreso"))
            Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("TipoAtencion").ToString)
            Fila.SubItems.Add(dsLista.Tables(0).Rows(I)("FechaAlta").ToString)
        Next

        'Imagenes
        lvImg.Clear()
        Dim dsImg As New Data.DataSet
        dsImg = objRayos.BuscarCodigo(lblHistoria.Text)
        Dim K As Integer
        For K = 0 To dsImg.Tables(0).Rows.Count - 1
            If dsImg.Tables(0).Rows(K)("Imagen").ToString <> "" Then imgLista.Images.Add(K.ToString, DameImagen(dsImg.Tables(0).Rows(K)("Imagen")))
        Next
        lvImg.LargeImageList = imgLista

        For K = 0 To dsImg.Tables(0).Rows.Count - 1
            lvImg.Items.Add(Microsoft.VisualBasic.Left(dsImg.Tables(0).Rows(K)("Fecha"), 10) & "-" & dsImg.Tables(0).Rows(K)("Titulo"), K)
        Next

        gbConsulta.Visible = False

        lblTotalM.Text = "0.00"
        lblTotalE.Text = "0.00"

        'Lista de Atencion de Consulta
        lvConsultas.Items.Clear()
        Dim dsConsulta As New Data.DataSet
        Dim FilaC As ListViewItem
        Dim CantEsp As Integer
        Dim UltimoAñoAtendido As Integer
        Dim UltimoAñoEstablecimiento As Integer
        CantEsp = 0

        objtempHClinica.Eliminar(My.Computer.Name)
        'Historial de Consultas
        dsConsulta = objCupo.ConsultasPacienteAtendidas(lblHistoria.Text, Date.Now)
        dgConsultas.DataSource = dsConsulta.Tables(0)
        UltimoAñoAtendido = 0
        UltimoAñoEstablecimiento = 0
        For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
            If I = 0 Then UltimoAñoEstablecimiento = Year(dsConsulta.Tables(0).Rows(I)("Fecha"))
            If I > 0 And EspecialidadMedica = dsConsulta.Tables(0).Rows(I)("Consultorio") And UltimoAñoAtendido = 0 Then UltimoAñoAtendido = Microsoft.VisualBasic.Right(dsConsulta.Tables(0).Rows(I)("Fecha"), 4)
            objtempHClinica.Grabar(My.Computer.Name, dsConsulta.Tables(0).Rows(I)("Fecha"), dsConsulta.Tables(0).Rows(I)("Consultorio"), dsConsulta.Tables(0).Rows(I)("Medico"), dsConsulta.Tables(0).Rows(I)("IdCupo"), dsConsulta.Tables(0).Rows(I)("NHistoria"), "CONSULTA")
            'FilaC = lvConsultas.Items.Add(dsConsulta.Tables(0).Rows(I)("Fecha"))
            'FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Consultorio"))
            'FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Medico"))
            'FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
            'FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
            'FilaC.SubItems.Add("CONSULTA")
            If EspMedico = dsConsulta.Tables(0).Rows(I)("Consultorio") Then
                CantEsp += 1
            End If
            If Year(dsConsulta.Tables(0).Rows(I)("Fecha")) > UltimoAñoEstablecimiento Then UltimoAñoEstablecimiento = Year(dsConsulta.Tables(0).Rows(I)("Fecha"))
        Next
        'Hsitorial Interconsultas
        dsConsulta = objInterconsultaE.HConsultas(lblHistoria.Text)
        For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
            If I = 0 Then UltimoAñoEstablecimiento = Year(dsConsulta.Tables(0).Rows(I)("Fecha"))
            If I > 0 And EspecialidadMedica = dsConsulta.Tables(0).Rows(I)("Consultorio") And UltimoAñoAtendido = 0 Then UltimoAñoAtendido = Microsoft.VisualBasic.Right(dsConsulta.Tables(0).Rows(I)("Fecha"), 4)
            'If I > 0 And EspecialidadMedica = dsConsulta.Tables(0).Rows(I)("Consultorio") And UltimoAñoAtendido = 0 Then UltimoAñoAtendido = Microsoft.VisualBasic.Right(dsConsulta.Tables(0).Rows(I)("Fecha"), 4)
            objtempHClinica.Grabar(My.Computer.Name, dsConsulta.Tables(0).Rows(I)("Fecha"), dsConsulta.Tables(0).Rows(I)("Consultorio"), dsConsulta.Tables(0).Rows(I)("Medico"), dsConsulta.Tables(0).Rows(I)("IdInterconsultaE"), dsConsulta.Tables(0).Rows(I)("NHistoria"), "INTERCONSULTA")
            'FilaC = lvConsultas.Items.Add(dsConsulta.Tables(0).Rows(I)("Fecha"))
            'FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Consultorio"))
            'FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Medico"))
            'FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
            'FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
            'FilaC.SubItems.Add("CONSULTA")
            If EspMedico = dsConsulta.Tables(0).Rows(I)("Consultorio") Then
                CantEsp += 1
            End If
            If Year(dsConsulta.Tables(0).Rows(I)("Fecha")) > UltimoAñoEstablecimiento Then UltimoAñoEstablecimiento = Year(dsConsulta.Tables(0).Rows(I)("Fecha"))
        Next

        'Total Historial Consultas e Interconsultas
        dsConsulta = objtempHClinica.Buscar(My.Computer.Name)
        For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
            'If I > 0 And EspecialidadMedica = dsConsulta.Tables(0).Rows(I)("Consultorio") And UltimoAñoAtendido = 0 Then UltimoAñoAtendido = Microsoft.VisualBasic.Right(dsConsulta.Tables(0).Rows(I)("Fecha"), 4)
            'objtempHClinica.Grabar(My.Computer.Name, dsConsulta.Tables(0).Rows(I)("Fecha"), dsConsulta.Tables(0).Rows(I)("Consultorio"), dsConsulta.Tables(0).Rows(I)("Medico"), dsConsulta.Tables(0).Rows(I)("IdCupo"), dsConsulta.Tables(0).Rows(I)("NHistoria"), "INTERCONSULTA")
            FilaC = lvConsultas.Items.Add(dsConsulta.Tables(0).Rows(I)("Fecha"))
            FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Consultorio"))
            FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Medico"))
            FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
            FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
            FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Tipo"))
        Next

        ''Buscar Interconsultas
        'dsConsulta = objCupo.ConsultasPacienteAtendidas(lblHistoria.Text, Date.Now)
        'dgConsultas.DataSource = dsConsulta.Tables(0)
        'UltimoAñoAtendido = 0
        'For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
        '    If I > 0 And EspecialidadMedica = dsConsulta.Tables(0).Rows(I)("Consultorio") And UltimoAñoAtendido = 0 Then UltimoAñoAtendido = Microsoft.VisualBasic.Right(dsConsulta.Tables(0).Rows(I)("Fecha"), 4)
        '    FilaC = lvConsultas.Items.Add(dsConsulta.Tables(0).Rows(I)("Fecha"))
        '    FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Consultorio"))
        '    FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Medico"))
        '    FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
        '    FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
        '    FilaC.SubItems.Add("CONSULTA")
        '    If EspMedico = dsConsulta.Tables(0).Rows(I)("Consultorio") Then
        '        CantEsp += 1
        '    End If
        'Next


        'Buscar Ubigeo
        Dim dsUbigeo As New Data.DataSet
        dsUbigeo = objConsulta.BuscarUbigeo(lblHistoria.Text)
        If dsUbigeo.Tables(0).Rows.Count > 0 Then
            cboDepartamento.Text = dsUbigeo.Tables(0).Rows(0)("Departamento")
            cboDepartamento_SelectedIndexChanged(sender, e)
            cboProvincia.Text = dsUbigeo.Tables(0).Rows(0)("Provincia")
            cboProvincia_SelectedIndexChanged(sender, e)
            cboDistrito.Text = dsUbigeo.Tables(0).Rows(0)("Distrito")
        End If


        'Especialidad
        Dim dsEsp As New Data.DataSet
        dsEsp = objEspecialidad.Combo("%")
        cboEspecialidad.DataSource = dsEsp.Tables(0)
        cboEspecialidad.DisplayMember = "Descripcion"
        cboEspecialidad.ValueMember = "IdDpto"

        gbFiltro.Visible = False

        'Verificar Si fue Grabada Atencion
        Dim dsConsultaAnt As New Data.DataSet
        If vTipoAtencion <> "INTERCONSULTA" And vTipoAtencion <> "INTERCONSULTAE" Then
            dsConsultaAnt = objConsulta.Buscar(CodCupo)
        ElseIf vTipoAtencion = "INTERCONSULTA" Then
            dsConsultaAnt = objInterconsultaH.Buscar(CodCupo)
        ElseIf vTipoAtencion = "INTERCONSULTAE" Then
            dsConsultaAnt = objInterconsultaE.Buscar(CodCupo)
        End If
        If dsConsultaAnt.Tables(0).Rows.Count > 0 Then
            txtSintomas.Text = dsConsultaAnt.Tables(0).Rows(0)("Sintomas")
            txtTalla.Text = dsConsultaAnt.Tables(0).Rows(0)("Talla")
            txtPeso.Text = dsConsultaAnt.Tables(0).Rows(0)("Peso")
            txtPulso.Text = dsConsultaAnt.Tables(0).Rows(0)("Pulso")
            txtTemperatura.Text = dsConsultaAnt.Tables(0).Rows(0)("Temp")
            txtPresion.Text = dsConsultaAnt.Tables(0).Rows(0)("Presion")
            txtEvaluacion.Text = dsConsultaAnt.Tables(0).Rows(0)("Evaluacion")
            txtCIE1.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie1").ToString
            txtDes1.Enabled = False
            txtDes1.Text = dsConsultaAnt.Tables(0).Rows(0)("Des1").ToString
            txtDes1.Enabled = True
            txtCIE2.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie2").ToString
            txtDes2.Enabled = False
            txtDes2.Text = dsConsultaAnt.Tables(0).Rows(0)("Des2").ToString
            txtDes2.Enabled = True
            txtCIE3.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie3").ToString
            txtDes3.Enabled = False
            txtDes3.Text = dsConsultaAnt.Tables(0).Rows(0)("Des3").ToString
            txtDes3.Enabled = True
            txtCIE4.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie4").ToString
            txtDes4.Enabled = False
            txtDes4.Text = dsConsultaAnt.Tables(0).Rows(0)("Des4").ToString
            txtDes4.Enabled = True
            txtCIE5.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie5").ToString
            txtDes5.Enabled = False
            txtDes5.Text = dsConsultaAnt.Tables(0).Rows(0)("Des5").ToString
            txtDes5.Enabled = True
            txtCIE6.Text = dsConsultaAnt.Tables(0).Rows(0)("Cie6").ToString
            txtDes6.Enabled = False
            txtDes6.Text = dsConsultaAnt.Tables(0).Rows(0)("Des6").ToString
            txtDes6.Enabled = True
            txtTratamiento.Text = dsConsultaAnt.Tables(0).Rows(0)("Tratamiento")
            cboDepartamento.Text = dsConsultaAnt.Tables(0).Rows(0)("Departamento")
            cboDepartamento_SelectedIndexChanged(sender, e)
            cboProvincia.Text = dsConsultaAnt.Tables(0).Rows(0)("Provincia")
            cboProvincia_SelectedIndexChanged(sender, e)
            cboDistrito.Text = dsConsultaAnt.Tables(0).Rows(0)("Distrito")
            cboEstablecimiento.Text = dsConsultaAnt.Tables(0).Rows(0)("IngEstablecimiento")
            cboServicio.Text = dsConsultaAnt.Tables(0).Rows(0)("IngServicio")
            cboTipoDiagnostico.Text = dsConsultaAnt.Tables(0).Rows(0)("TipoDiagnostico")
            txtEvolucion.Text = dsConsultaAnt.Tables(0).Rows(0)("Evolucion")
            cboTD1.Text = dsConsultaAnt.Tables(0).Rows(0)("TD1").ToString
            cboTD2.Text = dsConsultaAnt.Tables(0).Rows(0)("TD2").ToString
            cboTD3.Text = dsConsultaAnt.Tables(0).Rows(0)("TD3").ToString
            cboTD4.Text = dsConsultaAnt.Tables(0).Rows(0)("TD4").ToString
            cboTD5.Text = dsConsultaAnt.Tables(0).Rows(0)("TD5").ToString
            txtLab1.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab1").ToString
            txtLab2.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab2").ToString
            txtLab3.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab3").ToString
            txtLab4.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab4").ToString
            txtLab5.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab5").ToString
            txtLab6.Text = dsConsultaAnt.Tables(0).Rows(0)("Lab6").ToString
            If vTipoAtencion = "INTERCONSULTAE" Then cboTipoAtencion.Text = dsConsultaAnt.Tables(0).Rows(0)("TipoCupo").ToString
            If vTipoAtencion = "CONSULTA" Then cboTipoAtencion.Text = vTipoCupo


            Dim dsDetalle As New Data.DataSet
            cboEstablecimiento.Text = dsConsultaAnt.Tables(0).Rows(0)("IngEstablecimiento")
            cboServicio.Text = dsConsultaAnt.Tables(0).Rows(0)("IngServicio")

        Else
            cboTipoDiagnostico.Text = ""
            cboEstablecimiento.Text = "NUEVO"
            cboServicio.Text = "NUEVO"

            If lvConsultas.Items.Count >= 1 Then
                If UltimoAñoEstablecimiento > 0 Then
                    If UltimoAñoEstablecimiento = dtpFechaCita.Value.Year Then
                        cboEstablecimiento.Text = "CONTINUADOR"
                    Else
                        cboEstablecimiento.Text = "REINGRESANTE"
                    End If
                End If
            End If
            If CantEsp >= 1 Then
                If UltimoAñoAtendido = dtpFechaCita.Value.Year Then
                    cboServicio.Text = "CONTINUADOR"
                Else
                    cboServicio.Text = "REINGRESANTE"
                End If
            End If
            cboTipoAtencion.Text = vTipoCupo
        End If
        lvHistorialCE.Items.Clear()
        lvHistorialE.Items.Clear()
        lvHistorialH.Items.Clear()
        Dim dsVer As New DataSet

        'Historial de Laboratorio Consulta Externa
        dsVer = objLaboratorio.BuscarListaResultadosCE(lblHistoria.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvHistorialCE.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If dsVer.Tables(0).Rows(I)("Descripcion") = "HIV POR ELISA" Then Fila.SubItems.Add("RECOGER RESULTADO EN CERITS") Else Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdExamen"))
        Next

        'Historial de Laboratorio Emergencia
        dsVer = objLaboratorio.BuscarListaResultadosEmergencia(lblHistoria.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvHistorialE.Items.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If dsVer.Tables(0).Rows(I)("Descripcion") = "HIV POR ELISA" Then Fila.SubItems.Add("RECOGER RESULTADO EN CERITS") Else Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
        Next

        'Historial de Laboratorio Hospitalizacion

        'Historia de Patologia
        Dim dsPatologia As New DataSet
        dsPatologia = objPatologia.BuscarHistoria(lblHistoria.Text)
        lvListaI.Items.Clear()
        For I = 0 To dsPatologia.Tables(0).Rows.Count - 1
            Fila = lvListaI.Items.Add(dsPatologia.Tables(0).Rows(I)("IdInforme"))
            Fila.SubItems.Add(dsPatologia.Tables(0).Rows(I)("FEntrega"))
            Fila.SubItems.Add(dsPatologia.Tables(0).Rows(I)("Nombre"))
        Next

        'Historial de EKG
        dsVer = objInformeEKG.Buscar(lblHistoria.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            FIla = lvH.Items.Add(dsVer.Tables(0).Rows(I)("IdInforme"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaToma"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Origen"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Edad"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoDiagnostico"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Conclusiones"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Medico"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("MedicoTratante"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Examen"))
        Next

        'Espirometrias
        BuscarEspirometrias()

        'Electroencefalogramas
        BuscarElectroencefalogramas()
    End Sub

    Private Sub BuscarEspirometrias()
        lvEsp.Items.Clear()
        Dim dsEsp As New DataSet
        dsEsp = objDeposito.BuscarEspirometria(lblHistoria.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsEsp.Tables(0).Rows.Count - 1
            Fila = lvEsp.Items.Add(dsEsp.Tables(0).Rows(I)("IdImagen"))
            Fila.SubItems.Add(dsEsp.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsEsp.Tables(0).Rows(I)("Titulo"))
        Next
    End Sub

    Private Sub BuscarElectroencefalogramas()
        lvElectroence.Items.Clear()
        'Buscar Historial de Electroencefalogramas
        Dim dsVer As New DataSet
        dsVer = objElectroencefalograma.BuscarHistoria(lblHistoria.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvElectroence.Items.Add(dsVer.Tables(0).Rows(I)("IdElectro"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaInforme"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Solicitado"))
        Next
    End Sub

    Private Sub btnRetornarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gbFiltro.Visible = False
    End Sub

    Private Sub txtMedicamento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMedicamento.TextChanged
        If txtMedicamento.Text <> "" And txtMedicamento.Enabled Then Filtro = "MEDICAMENTO" : gbFiltro.Visible = True : txtFiltro.Text = txtMedicamento.Text : txtFiltro.SelectionStart = Len(txtFiltro.Text) : txtFiltro.Select()
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtFiltro.Text <> "" And dgFiltro.Rows.Count > 0 Then dgFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case Filtro
            Case "MEDICAMENTO"
                Dim rsMed As New Data.DataSet
                rsMed = objMedicamento.ObtenerMedicamentos(txtFiltro.Text, 1)
                dgFiltro.DataSource = rsMed.Tables(0)
            Case "EXAMENES"
                Dim rsExa As New Data.DataSet
                rsExa = objExamen.BuscarServicio(txtFiltro.Text & "%", 1, "D")
                dgFiltro.DataSource = rsExa.Tables(0)
        End Select
    End Sub

    Private Sub txtCantidadM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidadM.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtCantidadM.Text) Then cboDosis.Select()
    End Sub

    Private Sub dgMedicamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim I As Integer
        If dgMedicamento.Items.Count > 0 Then
            If e.KeyChar = Convert.ToChar(Keys.Delete) Then
                For I = 0 To dgMedicamento.Items.Count
                    If dgMedicamento.Items(I).Selected Then
                        lblTotalM.Text = Val(lblTotalM.Text) - Val(dgMedicamento.Items(I).SubItems(4).Text)
                        dgMedicamento.Items.RemoveAt(I)
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtExamenes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtExamenes.Text <> "" And txtExamenes.Enabled Then Filtro = "EXAMENES" : gbFiltro.Visible = True : txtFiltro.Text = txtExamenes.Text : txtFiltro.SelectionStart = Len(txtExamenes.Text) : txtFiltro.Select()
    End Sub

    Private Sub txtCantidadE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(txtCantidadE.Text) And e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Dim Importe As String
            Dim Fila As ListViewItem
            Fila = dgExamenes.Items.Add(txtExamenes.Tag)
            Fila.SubItems.Add(txtExamenes.Text)
            Fila.SubItems.Add(lblPrecioE.Text)
            Fila.SubItems.Add(txtCantidadE.Text)
            Importe = Val(lblPrecioE.Text) * Val(txtCantidadE.Text)
            Fila.SubItems.Add(Importe)
            lblTotalM.Text = Val(lblTotalM.Text) + Val(Importe)
            txtExamenes.Text = ""
            lblPrecioE.Text = ""
            txtCantidadE.Text = ""
            txtExamenes.Select()
        End If
    End Sub

    Private Sub cboEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEspecialidad.SelectedValue) Then cboSubEspecialidad.Select()
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged
        If IsNumeric(cboEspecialidad.SelectedValue) Then
            Dim dsSEsp As New Data.DataSet
            dsSEsp = objSubEspecialidad.Combo(cboEspecialidad.SelectedValue)
            cboSubEspecialidad.DataSource = dsSEsp.Tables(0)
            cboSubEspecialidad.DisplayMember = "Descripcion"
            cboSubEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub LimpiarTP()
        Dim X As Object
        For Each X In Me.Controls
            If TypeOf X Is TextBox Then
                If X.TabIndex >= 200 And X.tabindex <= 255 Then X.Text = ""
            End If
        Next
        For Each X In pCupos.Controls
            If TypeOf X Is Button Then
                If IsNumeric(X.tag) Then X.text = ""
            End If
        Next
    End Sub

    Private Sub ActivarCupos(ByVal Valor As Boolean)
        Dim X As Object
        For Each X In Me.Controls
            If TypeOf X Is Button Then X.Enabled = Valor
        Next
    End Sub

    Private Sub LlenarCupos()
        If IsNumeric(cboSubEspecialidad.SelectedValue) Then
            Dim dsPro As New Data.DataSet
            Dim dsHor As New Data.DataSet
            Dim rsMedCon As New Data.DataSet
            Dim X As Object
            Dim NC As Integer
            Dim I As Integer
            Dim M As Integer
            Dim NCupo As String
            Dim CodProgramacion As String
            LimpiarTP()
            If TBusqueda Then
                dsPro = objProgramacion.BuscarCabProgramacion(dtpFechaCita.Value.ToShortDateString, cboTurno.Text, cboEspecialidad.Text, cboSubEspecialidad.Text)
            Else
                dsPro = objProgramacion.BuscarCabProgramacionVN(dtpFechaCita.Value.ToShortDateString, cboTurno.Text, cboEspecialidad.Text, cboSubEspecialidad.Text, cboMedico.Text)
            End If
            If dsPro.Tables(0).Rows.Count > 0 Then
                For M = 0 To dsPro.Tables(0).Rows.Count - 1
                    CodProgramacion = dsPro.Tables(0).Rows(I)("IdProgramacion")
                    CodPro = dsPro.Tables(0).Rows(I)("IdProgramacion")
                    ValorRealCN = dsPro.Tables(0).Rows(I)("CuposNuevos")
                    ValorRealCC = dsPro.Tables(0).Rows(I)("CuposContinuadores")
                    ValorRealCP = dsPro.Tables(0).Rows(I)("CuposPro")
                    NC = Val(dsPro.Tables(0).Rows(I)("CuposNuevos")) + Val(dsPro.Tables(0).Rows(I)("CuposContinuadores")) + Val(dsPro.Tables(0).Rows(I)("CuposPro"))
                    cboMedico.Enabled = False
                    cboMedico.DataSource = dsPro.Tables(0)
                    cboMedico.DisplayMember = "NomMedico1"
                    cboMedico.DisplayMember = "IdMedico1"
                    cboMedico.Enabled = True

                    dsHor = objProgramacion.HorarioProgramacion_Buscar(CodProgramacion, dsPro.Tables(0).Rows(I)("NomMedico1"))

                    NCupo = 0

                    ActivarCupos(False)

                    For Each X In pCupos.Controls
                        If TypeOf X Is Button Then
                            If IsNumeric(X.Tag) Then
                                NCupo = Val(NCupo) + 1
                                If NC = 0 Then Exit For
                                X.Text = NCupo
                                X.Enabled = True
                                NC = NC - 1
                            End If
                        End If
                        If TypeOf X Is Label Then
                            Dim NumeroHora As Integer
                            Dim Dia As String
                            If X.BorderStyle = 0 And (Microsoft.VisualBasic.Left(X.tag, 1) = "H") Then
                                NumeroHora = Microsoft.VisualBasic.Right(X.tag, X.tag.ToString.Length - 1)
                                If cboTurno.Text = "MAÑANA" Then
                                    Select Case NumeroHora
                                        Case 1 To 5
                                            X.Text = "07:50"
                                        Case 6 To 10
                                            X.Text = "08:50"
                                        Case 11 To 15
                                            X.Text = "09:50"
                                        Case Is >= 16
                                            Dia = UCase(Format(dtpFechaCita.Value, "dddd"))
                                            If Dia <> "SÁBADO" Then
                                                X.Text = "10:50"
                                            Else
                                                X.Text = "09:50"
                                            End If
                                    End Select
                                ElseIf cboTurno.Text = "TARDE" Then
                                    Select Case NumeroHora
                                        Case 1 To 5
                                            X.Text = "12:45"
                                        Case 6 To 10
                                            X.Text = "13:45"
                                        Case 11 To 15
                                            X.Text = "14:45"
                                        Case Is >= 16
                                            X.Text = "15:45"
                                    End Select
                                End If
                            End If
                        End If
                    Next
                Next
            Else
                MsgBox("No existe programación registrada")

                Dim Y As Object
                For Each Y In pCupos.Controls
                    If TypeOf Y Is Button Then
                        If Y.tag = "B" Then Y.BackColor = Color.White : Y.Text = ""
                    End If
                Next

                CodPro = ""
                ActivarCupos(False)
                LimpiarTP()
            End If
        End If
    End Sub

    Private Sub PintarCupos()
        Dim X As Object
        Dim Y As Object
        Dim I As Integer
        Dim Etiqueta As String
        Dim NroCupo As String
        Dim dsPintar As New Data.DataSet
        dsPintar = objCupo.BuscarCupoPintar(CodPro)

        For Each X In pCupos.Controls
            If TypeOf X Is Button Then
                If IsNumeric(X.tag) Then
                    X.BackColor = Color.White
                End If
            End If
        Next

        Dim CCuposN As String
        CCuposN = 0

        'For Each X In pCupos.Controls
        '    If (TypeOf X Is Button) Then
        '        If IsNumeric(X.Tag) And Val(X.Text) <= Val(ValorRealCN) Then
        '            If X.text <> "" Then X.BackColor = Color.IndianRed
        '        End If
        '    End If
        'Next

        'For Each X In pCupos.Controls
        '    If (TypeOf X Is Button) Then
        '        If IsNumeric(X.Tag) And Val(X.Text) > (Val(ValorRealCN) + Val(ValorRealCC)) Then
        '            If X.text <> "" Then X.BackColor = Color.Teal
        '        End If
        '    End If
        'Next

        If dsPintar.Tables(0).Rows.Count > 0 Then
            Dim PTexto As Integer
            Dim PBoton As Integer
            For I = 0 To dsPintar.Tables(0).Rows.Count - 1
                NroCupo = dsPintar.Tables(0).Rows(I)("Cupo")
                For Each X In pCupos.Controls
                    If TypeOf X Is Button Then
                        If X.TabIndex <= 46 Then
                            Etiqueta = X.text
                            If NroCupo = Etiqueta Then
                                If dsPintar.Tables(0).Rows(I)("TipoCupo") <> "CREDITO" Then
                                    If dsPintar.Tables(0).Rows(I)("Cancelado") = "0" Then X.BackColor = Color.Red
                                    If dsPintar.Tables(0).Rows(I)("Cancelado") = "1" Then X.BackColor = Color.LimeGreen
                                ElseIf dsPintar.Tables(0).Rows(I)("TipoCupo") = "CREDITO" Then
                                    X.BackColor = Color.Yellow
                                End If
                                PBoton = X.TabIndex
                                For Each Y In pCupos.Controls
                                    If TypeOf Y Is TextBox Then
                                        PTexto = Y.TabIndex
                                        If PTexto >= 118 Then
                                            If PBoton + 113 = PTexto Then
                                                Y.Text = dsPintar.Tables(0).Rows(I)("TipoCupo")
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub cboSubEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboSubEspecialidad.SelectedValue) Then cboMedico.Select()
    End Sub


    Private Sub cboSubEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubEspecialidad.SelectedIndexChanged
        If IsNumeric(cboEspecialidad.SelectedValue) And cboTurno.Text <> "" And cboTipoCupo.Text <> "" Then TBusqueda = True : LlenarCupos() : PintarCupos()
    End Sub

    Private Sub btnRetornarF_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarF.Click
        gbFiltro.Visible = False
    End Sub

    Private Sub txtCIE1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE1.KeyDown
        If txtCIE1.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE1.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE1.Text = txtCIE2.Text Or txtCIE1.Text = txtCIE3.Text Or txtCIE1.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE1.Select() : Exit Sub

                'Verificar Entrega de Insumos por Primera vez
                Dim VarAux1 As String
                'Insumos Por Primera Vez
                If (txtCIE1.Text = "Z3003" Or txtCIE1.Text = "Z30051" Or txtCIE1.Text = "Z30052" Or txtCIE1.Text = "Z3006" Or txtCIE1.Text = "Z3008" Or txtCIE1.Text = "Z3009" Or txtCIE1.Text = "Z30091" Or txtCIE1.Text = "Z30092" Or txtCIE1.Text = "Z30093" Or txtCIE1.Text = "Z30094") Then
                    If MessageBox.Show("Ud. no puede ingrear la Asignación de Insumos por Primera Vez en esta Posición, Desea Modificación segun el Manual?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        VarAux1 = txtCIE1.Text
                        txtCIE1.Text = "99402"
                        txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                        txtCIE2.Text = VarAux1
                        txtDes2.Enabled = False : txtDes2.Text = DevolverDescripcionCIE(txtCIE2.Text, cboTD2) : txtDes2.Enabled = True
                        VarAux1 = InputBox("Ingrear Nro de Insumos Entregados", "Información de Insumos", 1)
                        txtLab3.Text = VarAux1
                    End If
                    txtLab1.Select()
                    Exit Sub
                End If

                'Verificar Sifilis 86592
                If txtCIE1.Text = "86592" Then
                    txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                    If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab1.Text = "RN"
                    Else
                        txtLab1.Text = "RP"
                    End If
                    txtCIE2.Select()
                    Exit Sub
                End If


                'Verificar Control Puerperio 59430
                If txtCIE1.Text = "59430" Then
                    txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                    If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab1.Text = "1"
                    Else
                        txtLab1.Text = "2"
                    End If
                    txtCIE2.Select()
                    Exit Sub
                End If

                'Verificar Entrega de Continuador de Insumos
                If (txtCIE1.Text = "Z3043" Or txtCIE1.Text = "Z30451" Or txtCIE1.Text = "Z30452" Or txtCIE1.Text = "Z3046" Or txtCIE1.Text = "Z3048" Or txtCIE1.Text = "Z3049" Or txtCIE1.Text = "Z30491" Or txtCIE1.Text = "Z30492" Or txtCIE1.Text = "Z30493" Or txtCIE1.Text = "Z30494") Then
                    txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                    If Not txtCIE1.Text = "Z3046" Then
                        VarAux1 = InputBox("Ingrear Nro de Insumos Entregados", "Información de Insumos", 1)
                        txtLab2.Text = VarAux1
                    End If
                    txtLab1.Select()
                    Exit Sub
                End If

                'Verificar Cancer de Mama y Cuello Uterino
                If (txtCIE1.Text = "88141" Or txtCIE1.Text = "Z0143" Or txtCIE1.Text = "Z0142" Or txtCIE1.Text = "87621") Then
                    txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                    txtCIE2.Text = "99401"
                    txtDes2.Enabled = False : txtDes2.Text = DevolverDescripcionCIE("99401", cboTD2) : txtDes2.Enabled = True
                    If txtCIE1.Text = "Z0143" Then
                        txtLab3.Text = "MA"
                        If MessageBox.Show("El Resultado Fue NORMAL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            txtLab1.Text = "N"
                        Else
                            txtLab1.Text = "A"
                        End If
                        txtLab2.Select()
                    Else
                        txtLab3.Text = "CU"
                        If MessageBox.Show("La Atencion es por Primera Vez?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            txtLab1.Text = "PV"
                            txtLab2.Text = "1"
                            txtLab3.Select()
                        Else
                            txtLab1.Text = "PC"
                            txtLab2.Select()
                        End If
                    End If
                    Exit Sub
                End If

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And lblSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And lblSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                txtDes1.Enabled = False
                txtDes1.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes1.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTipoDiagnostico.Text = "DEFINITIVO" : txtDes2.Select() Else cboTipoDiagnostico.Select()

                'Validar Morbilidad Definitiva
                If dsTabla.Tables(0).Rows(0)("MorbilidadDefinitiva") = "X" Then
                    Dim I As Integer
                    Dim dsVerMD As New DataSet
                    Dim Existe As Boolean = False
                    For I = 1 To 6
                        dsVerMD = objConsulta.VerDiagnosticoMorDef(lblHistoria.Text, txtCIE1.Text, I)
                        If dsVerMD.Tables(0).Rows.Count > 0 Then
                            Select Case I
                                Case 1
                                    If dsVerMD.Tables(0).Rows(0)("TipoDiagnostico") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO" : Exit Sub
                                Case 2
                                    If dsVerMD.Tables(0).Rows(0)("TD1") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO" : Exit Sub
                                Case 3
                                    If dsVerMD.Tables(0).Rows(0)("TD2") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO" : Exit Sub
                                Case 4
                                    If dsVerMD.Tables(0).Rows(0)("TD3") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO" : Exit Sub
                                Case 5
                                    If dsVerMD.Tables(0).Rows(0)("TD4") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO" : Exit Sub
                                Case 6
                                    If dsVerMD.Tables(0).Rows(0)("TD5") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO" : Exit Sub
                            End Select
                        End If
                    Next
                End If
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCIE2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE2.Text.Length > 0 Then

            'Verificar Cancer de Mama y Cuello Uterino
            If (txtCIE2.Text = "88141" Or txtCIE2.Text = "Z0143" Or txtCIE2.Text = "Z0142" Or txtCIE2.Text = "87621") Then
                txtDes2.Enabled = False : txtDes2.Text = DevolverDescripcionCIE(txtCIE2.Text, cboTD1) : txtDes2.Enabled = True
                txtCIE3.Text = "99401"
                txtDes3.Enabled = False : txtDes3.Text = DevolverDescripcionCIE("99401", cboTD2) : txtDes3.Enabled = True
                If txtCIE2.Text = "Z0143" Then
                    txtLab4.Text = "MA"
                    If MessageBox.Show("El Resultado Fue NORMAL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab2.Text = "N"
                    Else
                        txtLab2.Text = "A"
                    End If
                    txtLab3.Select()
                Else
                    txtLab4.Text = "CU"
                    If MessageBox.Show("La Atencion es por Primera Vez?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab2.Text = "PV"
                        txtLab3.Text = "1"
                        txtLab4.Select()
                    Else
                        txtLab2.Text = "PC"
                        txtLab3.Select()
                    End If
                End If
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE2.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE2.Text = txtCIE1.Text Or txtCIE2.Text = txtCIE3.Text Or txtCIE2.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE2.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And lblSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And lblSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes2.Enabled = False
                txtDes2.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes2.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD1.Text = "DEFINITIVO" : txtDes3.Select() Else cboTD1.Select()

                'Validar Morbilidad Definitiva
                If dsTabla.Tables(0).Rows(0)("MorbilidadDefinitiva") = "X" Then
                    Dim I As Integer
                    Dim dsVerMD As New DataSet
                    Dim Existe As Boolean = False
                    For I = 1 To 6
                        dsVerMD = objConsulta.VerDiagnosticoMorDef(lblHistoria.Text, txtCIE2.Text, I)
                        If dsVerMD.Tables(0).Rows.Count > 0 Then
                            Select Case I
                                Case 1
                                    If dsVerMD.Tables(0).Rows(0)("TipoDiagnostico") = "DEFINITIVO" Then cboTD1.Text = "REPETITIVO" : Exit Sub
                                Case 2
                                    If dsVerMD.Tables(0).Rows(0)("TD1") = "DEFINITIVO" Then cboTD1.Text = "REPETITIVO" : Exit Sub
                                Case 3
                                    If dsVerMD.Tables(0).Rows(0)("TD2") = "DEFINITIVO" Then cboTD1.Text = "REPETITIVO" : Exit Sub
                                Case 4
                                    If dsVerMD.Tables(0).Rows(0)("TD3") = "DEFINITIVO" Then cboTD1.Text = "REPETITIVO" : Exit Sub
                                Case 5
                                    If dsVerMD.Tables(0).Rows(0)("TD4") = "DEFINITIVO" Then cboTD1.Text = "REPETITIVO" : Exit Sub
                                Case 6
                                    If dsVerMD.Tables(0).Rows(0)("TD5") = "DEFINITIVO" Then cboTD1.Text = "REPETITIVO" : Exit Sub
                            End Select
                        End If
                    Next
                End If
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCIE3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE3.Text.Length > 0 Then
            If txtCIE2.Text = "" And txtLab2.Text <> "" Then
                MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCIE3.Text = ""
                txtDes3.Text = ""
                txtLab3.Text = ""
                cboTD2.Text = ""
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE3.Text = "86592" Then
                txtDes3.Enabled = False : txtDes3.Text = DevolverDescripcionCIE(txtCIE3.Text, cboTD2) : txtDes3.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab3.Text = "RN"
                Else
                    txtLab3.Text = "RP"
                End If
                txtCIE4.Select()
                Exit Sub
            End If

            'Verificar Control Puerperio 59430
            If txtCIE3.Text = "59430" Then
                txtDes3.Enabled = False : txtDes3.Text = DevolverDescripcionCIE(txtCIE3.Text, cboTD2) : txtDes3.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab3.Text = "1"
                Else
                    txtLab3.Text = "2"
                End If
                txtCIE2.Select()
                Exit Sub
            End If

            'Verificar Cancer de Mama y Cuello Uterino
            If (txtCIE3.Text = "88141" Or txtCIE3.Text = "Z0143" Or txtCIE3.Text = "Z0142" Or txtCIE3.Text = "87621") Then
                txtDes3.Enabled = False : txtDes3.Text = DevolverDescripcionCIE(txtCIE3.Text, cboTD2) : txtDes3.Enabled = True
                txtCIE4.Text = "99401"
                txtDes4.Enabled = False : txtDes4.Text = DevolverDescripcionCIE("99401", cboTD4) : txtDes4.Enabled = True
                If txtCIE3.Text = "Z0143" Then
                    txtLab5.Text = "MA"
                    If MessageBox.Show("El Resultado Fue NORMAL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab3.Text = "N"
                    Else
                        txtLab3.Text = "A"
                    End If
                    txtLab3.Select()
                Else
                    txtLab5.Text = "CU"
                    If MessageBox.Show("La Atencion es por Primera Vez?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab3.Text = "PV"
                        txtLab4.Text = "1"
                        txtLab5.Select()
                    Else
                        txtLab3.Text = "PC"
                        txtLab4.Select()
                    End If
                End If
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE3.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE3.Text = txtCIE1.Text Or txtCIE3.Text = txtCIE2.Text Or txtCIE3.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE3.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And lblSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And lblSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes3.Enabled = False
                txtDes3.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes3.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD2.Text = "DEFINITIVO" : txtDes3.Select() Else cboTD2.Select()

                'Validar Morbilidad Definitiva
                If dsTabla.Tables(0).Rows(0)("MorbilidadDefinitiva") = "X" Then
                    Dim I As Integer
                    Dim dsVerMD As New DataSet
                    Dim Existe As Boolean = False
                    For I = 1 To 6
                        dsVerMD = objConsulta.VerDiagnosticoMorDef(lblHistoria.Text, txtCIE3.Text, I)
                        If dsVerMD.Tables(0).Rows.Count > 0 Then
                            Select Case I
                                Case 1
                                    If dsVerMD.Tables(0).Rows(0)("TipoDiagnostico") = "DEFINITIVO" Then cboTD2.Text = "REPETITIVO" : Exit Sub
                                Case 2
                                    If dsVerMD.Tables(0).Rows(0)("TD1") = "DEFINITIVO" Then cboTD2.Text = "REPETITIVO" : Exit Sub
                                Case 3
                                    If dsVerMD.Tables(0).Rows(0)("TD2") = "DEFINITIVO" Then cboTD2.Text = "REPETITIVO" : Exit Sub
                                Case 4
                                    If dsVerMD.Tables(0).Rows(0)("TD3") = "DEFINITIVO" Then cboTD2.Text = "REPETITIVO" : Exit Sub
                                Case 5
                                    If dsVerMD.Tables(0).Rows(0)("TD4") = "DEFINITIVO" Then cboTD2.Text = "REPETITIVO" : Exit Sub
                                Case 6
                                    If dsVerMD.Tables(0).Rows(0)("TD5") = "DEFINITIVO" Then cboTD2.Text = "REPETITIVO" : Exit Sub
                            End Select
                        End If
                    Next
                End If
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCIE4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE4.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE4.Text.Length > 0 Then
            If txtCIE3.Text = "" And txtLab3.Text <> "" Then
                MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCIE4.Text = ""
                txtDes4.Text = ""
                txtLab4.Text = ""
                cboTD3.Text = ""
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE4.Text = "86592" Then
                txtDes4.Enabled = False : txtDes4.Text = DevolverDescripcionCIE(txtCIE4.Text, cboTD3) : txtDes4.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab4.Text = "RN"
                Else
                    txtLab4.Text = "RP"
                End If
                txtCIE5.Select()
                Exit Sub
            End If

            'Verificar Control Puerperio 59430
            If txtCIE4.Text = "59430" Then
                txtDes4.Enabled = False : txtDes4.Text = DevolverDescripcionCIE(txtCIE4.Text, cboTD3) : txtDes4.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab4.Text = "1"
                Else
                    txtLab4.Text = "2"
                End If
                txtCIE5.Select()
                Exit Sub
            End If

            'Verificar Cancer de Mama y Cuello Uterino
            If (txtCIE4.Text = "88141" Or txtCIE4.Text = "Z0143" Or txtCIE4.Text = "Z0142" Or txtCIE4.Text = "87621") Then
                txtDes4.Enabled = False : txtDes4.Text = DevolverDescripcionCIE(txtCIE4.Text, cboTD3) : txtDes4.Enabled = True
                txtCIE5.Text = "99401"
                txtDes5.Enabled = False : txtDes5.Text = DevolverDescripcionCIE("99401", cboTD5) : txtDes5.Enabled = True
                If txtCIE4.Text = "Z0143" Then
                    txtLab6.Text = "MA"
                    txtLab4.Select()
                Else
                    txtLab6.Text = "CU"
                    If MessageBox.Show("La Atencion es por Primera Vez?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab4.Text = "PV"
                        txtLab5.Text = "1"
                        txtLab6.Select()
                    Else
                        txtLab4.Text = "PC"
                        txtLab5.Select()
                    End If
                End If
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE4.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE4.Text = txtCIE1.Text Or txtCIE4.Text = txtCIE2.Text Or txtCIE4.Text = txtCIE3.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE4.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And lblSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And lblSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes4.Enabled = False
                txtDes4.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes4.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD3.Text = "DEFINITIVO" : cboTD4.Select() Else cboTD3.Select()

                'Validar Morbilidad Definitiva
                If dsTabla.Tables(0).Rows(0)("MorbilidadDefinitiva") = "X" Then
                    Dim I As Integer
                    Dim dsVerMD As New DataSet
                    Dim Existe As Boolean = False
                    For I = 1 To 6
                        dsVerMD = objConsulta.VerDiagnosticoMorDef(lblHistoria.Text, txtCIE4.Text, I)
                        If dsVerMD.Tables(0).Rows.Count > 0 Then
                            Select Case I
                                Case 1
                                    If dsVerMD.Tables(0).Rows(0)("TipoDiagnostico") = "DEFINITIVO" Then cboTD3.Text = "REPETITIVO" : Exit Sub
                                Case 2
                                    If dsVerMD.Tables(0).Rows(0)("TD1") = "DEFINITIVO" Then cboTD3.Text = "REPETITIVO" : Exit Sub
                                Case 3
                                    If dsVerMD.Tables(0).Rows(0)("TD2") = "DEFINITIVO" Then cboTD3.Text = "REPETITIVO" : Exit Sub
                                Case 4
                                    If dsVerMD.Tables(0).Rows(0)("TD3") = "DEFINITIVO" Then cboTD3.Text = "REPETITIVO" : Exit Sub
                                Case 5
                                    If dsVerMD.Tables(0).Rows(0)("TD4") = "DEFINITIVO" Then cboTD3.Text = "REPETITIVO" : Exit Sub
                                Case 6
                                    If dsVerMD.Tables(0).Rows(0)("TD5") = "DEFINITIVO" Then cboTD3.Text = "REPETITIVO" : Exit Sub
                            End Select
                        End If
                    Next
                End If
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCIE4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE4.KeyPress

    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Function ReglasValidacionCIEMat() As Boolean
        Dim EdadActual As Double = EdadA * 365 + EdadM * 30 + EdadD
        ReglasValidacionCIEMat = False

        'Insumos Por Primera Vez
        If (txtCIE1.Text = "Z3003" Or txtCIE1.Text = "Z30051" Or txtCIE1.Text = "Z30052" Or txtCIE1.Text = "Z3006" Or txtCIE1.Text = "Z3008" Or txtCIE1.Text = "Z3009" Or txtCIE1.Text = "Z30091" Or txtCIE1.Text = "Z30092" Or txtCIE1.Text = "Z30093" Or txtCIE1.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE1.Text = "" : txtDes1.Text = "" : txtLab1.Text = "" : cboTipoDiagnostico.Text = "" : txtCIE1.Select() : Exit Function
        If (txtCIE2.Text = "Z3003" Or txtCIE2.Text = "Z30051" Or txtCIE2.Text = "Z30052" Or txtCIE2.Text = "Z3006" Or txtCIE2.Text = "Z3008" Or txtCIE2.Text = "Z3009" Or txtCIE2.Text = "Z30091" Or txtCIE2.Text = "Z30092" Or txtCIE2.Text = "Z30093" Or txtCIE2.Text = "Z30094") And txtLab2.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab2.Select() : Exit Function
        If (txtCIE3.Text = "Z3003" Or txtCIE3.Text = "Z30051" Or txtCIE3.Text = "Z30052" Or txtCIE3.Text = "Z3006" Or txtCIE3.Text = "Z3008" Or txtCIE3.Text = "Z3009" Or txtCIE3.Text = "Z30091" Or txtCIE3.Text = "Z30092" Or txtCIE3.Text = "Z30093" Or txtCIE3.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE3.Text = "" : txtCIE3.Select() : txtDes3.Text = "" : txtLab3.Text = "" : cboTD2.Text = "" : Exit Function
        If (txtCIE4.Text = "Z3003" Or txtCIE4.Text = "Z30051" Or txtCIE4.Text = "Z30052" Or txtCIE4.Text = "Z3006" Or txtCIE4.Text = "Z3008" Or txtCIE4.Text = "Z3009" Or txtCIE4.Text = "Z30091" Or txtCIE4.Text = "Z30092" Or txtCIE4.Text = "Z30093" Or txtCIE4.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE4.Text = "" : txtCIE4.Select() : txtDes4.Text = "" : txtLab4.Text = "" : cboTD3.Text = "" : Exit Function
        If (txtCIE5.Text = "Z3003" Or txtCIE5.Text = "Z30051" Or txtCIE5.Text = "Z30052" Or txtCIE5.Text = "Z3006" Or txtCIE5.Text = "Z3008" Or txtCIE5.Text = "Z3009" Or txtCIE5.Text = "Z30091" Or txtCIE5.Text = "Z30092" Or txtCIE5.Text = "Z30093" Or txtCIE5.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE5.Text = "" : txtCIE5.Select() : txtDes5.Text = "" : txtLab5.Text = "" : cboTD4.Text = "" : Exit Function
        If (txtCIE6.Text = "Z3003" Or txtCIE6.Text = "Z30051" Or txtCIE6.Text = "Z30052" Or txtCIE6.Text = "Z3006" Or txtCIE6.Text = "Z3008" Or txtCIE6.Text = "Z3009" Or txtCIE6.Text = "Z30091" Or txtCIE6.Text = "Z30092" Or txtCIE6.Text = "Z30093" Or txtCIE6.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE6.Text = "" : txtCIE6.Select() : txtDes6.Text = "" : txtLab6.Text = "" : cboTD5.Text = "" : Exit Function

        'Continuador de Insumos
        If (txtCIE1.Text = "Z3043" Or txtCIE1.Text = "Z30451" Or txtCIE1.Text = "Z30452" Or txtCIE1.Text = "Z3046" Or txtCIE1.Text = "Z3048" Or txtCIE1.Text = "Z3049" Or txtCIE1.Text = "Z30491" Or txtCIE1.Text = "Z30492" Or txtCIE1.Text = "Z30493" Or txtCIE1.Text = "Z30494") And txtLab2.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab1.Select() : Exit Function
        If (txtCIE2.Text = "Z3043" Or txtCIE2.Text = "Z30451" Or txtCIE2.Text = "Z30452" Or txtCIE2.Text = "Z3046" Or txtCIE2.Text = "Z3048" Or txtCIE2.Text = "Z3049" Or txtCIE2.Text = "Z30491" Or txtCIE2.Text = "Z30492" Or txtCIE2.Text = "Z30493" Or txtCIE2.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE2.Text = "" : txtDes2.Text = "" : txtLab2.Text = "" : cboTD1.Text = "" : txtCIE2.Select() : Exit Function
        If (txtCIE3.Text = "Z3043" Or txtCIE3.Text = "Z30451" Or txtCIE3.Text = "Z30452" Or txtCIE3.Text = "Z3046" Or txtCIE3.Text = "Z3048" Or txtCIE3.Text = "Z3049" Or txtCIE3.Text = "Z30491" Or txtCIE3.Text = "Z30492" Or txtCIE3.Text = "Z30493" Or txtCIE3.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE3.Text = "" : txtCIE3.Select() : txtDes3.Text = "" : txtLab3.Text = "" : cboTD2.Text = "" : Exit Function
        If (txtCIE4.Text = "Z3043" Or txtCIE4.Text = "Z30451" Or txtCIE4.Text = "Z30452" Or txtCIE4.Text = "Z3046" Or txtCIE4.Text = "Z3048" Or txtCIE4.Text = "Z3049" Or txtCIE4.Text = "Z30491" Or txtCIE4.Text = "Z30492" Or txtCIE4.Text = "Z30493" Or txtCIE4.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE4.Text = "" : txtCIE4.Select() : txtDes4.Text = "" : txtLab4.Text = "" : cboTD3.Text = "" : Exit Function
        If (txtCIE5.Text = "Z3043" Or txtCIE5.Text = "Z30451" Or txtCIE5.Text = "Z30452" Or txtCIE5.Text = "Z3046" Or txtCIE5.Text = "Z3048" Or txtCIE5.Text = "Z3049" Or txtCIE5.Text = "Z30491" Or txtCIE5.Text = "Z30492" Or txtCIE5.Text = "Z30493" Or txtCIE5.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE5.Text = "" : txtCIE5.Select() : txtDes5.Text = "" : txtLab5.Text = "" : cboTD4.Text = "" : Exit Function
        If (txtCIE6.Text = "Z3043" Or txtCIE6.Text = "Z30451" Or txtCIE6.Text = "Z30452" Or txtCIE6.Text = "Z3046" Or txtCIE5.Text = "Z3048" Or txtCIE6.Text = "Z3049" Or txtCIE6.Text = "Z30491" Or txtCIE6.Text = "Z30492" Or txtCIE6.Text = "Z30493" Or txtCIE6.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE6.Text = "" : txtCIE6.Select() : txtDes6.Text = "" : txtLab6.Text = "" : cboTD5.Text = "" : Exit Function

        'PAP
        If (txtCIE1.Text = "88141" Or txtCIE1.Text = "Z30451" Or txtCIE1.Text = "Z30452" Or txtCIE1.Text = "Z3046" Or txtCIE1.Text = "Z3048" Or txtCIE1.Text = "Z3049" Or txtCIE1.Text = "Z30491" Or txtCIE1.Text = "Z30492" Or txtCIE1.Text = "Z30493" Or txtCIE1.Text = "Z30494") And txtLab2.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab1.Select() : Exit Function
        If (txtCIE2.Text = "Z3043" Or txtCIE2.Text = "Z30451" Or txtCIE2.Text = "Z30452" Or txtCIE2.Text = "Z3046" Or txtCIE2.Text = "Z3048" Or txtCIE2.Text = "Z3049" Or txtCIE2.Text = "Z30491" Or txtCIE2.Text = "Z30492" Or txtCIE2.Text = "Z30493" Or txtCIE2.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE2.Text = "" : txtDes2.Text = "" : txtLab2.Text = "" : cboTD1.Text = "" : txtCIE2.Select() : Exit Function
        If (txtCIE3.Text = "Z3043" Or txtCIE3.Text = "Z30451" Or txtCIE3.Text = "Z30452" Or txtCIE3.Text = "Z3046" Or txtCIE3.Text = "Z3048" Or txtCIE3.Text = "Z3049" Or txtCIE3.Text = "Z30491" Or txtCIE3.Text = "Z30492" Or txtCIE3.Text = "Z30493" Or txtCIE3.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE3.Text = "" : txtCIE3.Select() : txtDes3.Text = "" : txtLab3.Text = "" : cboTD2.Text = "" : Exit Function
        If (txtCIE4.Text = "Z3043" Or txtCIE4.Text = "Z30451" Or txtCIE4.Text = "Z30452" Or txtCIE4.Text = "Z3046" Or txtCIE4.Text = "Z3048" Or txtCIE4.Text = "Z3049" Or txtCIE4.Text = "Z30491" Or txtCIE4.Text = "Z30492" Or txtCIE4.Text = "Z30493" Or txtCIE4.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE4.Text = "" : txtCIE4.Select() : txtDes4.Text = "" : txtLab4.Text = "" : cboTD3.Text = "" : Exit Function
        If (txtCIE5.Text = "Z3043" Or txtCIE5.Text = "Z30451" Or txtCIE5.Text = "Z30452" Or txtCIE5.Text = "Z3046" Or txtCIE5.Text = "Z3048" Or txtCIE5.Text = "Z3049" Or txtCIE5.Text = "Z30491" Or txtCIE5.Text = "Z30492" Or txtCIE5.Text = "Z30493" Or txtCIE5.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE5.Text = "" : txtCIE5.Select() : txtDes5.Text = "" : txtLab5.Text = "" : cboTD4.Text = "" : Exit Function
        If (txtCIE6.Text = "Z3043" Or txtCIE6.Text = "Z30451" Or txtCIE6.Text = "Z30452" Or txtCIE6.Text = "Z3046" Or txtCIE5.Text = "Z3048" Or txtCIE6.Text = "Z3049" Or txtCIE6.Text = "Z30491" Or txtCIE6.Text = "Z30492" Or txtCIE6.Text = "Z30493" Or txtCIE6.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE6.Text = "" : txtCIE6.Select() : txtDes6.Text = "" : txtLab6.Text = "" : cboTD5.Text = "" : Exit Function

    End Function

    Private Function ReglasValidacionCIENut() As Boolean
        Dim EdadActual As Double = EdadA * 365 + EdadM * 30 + EdadD
        ReglasValidacionCIENut = False

        'Nutricion D509
        If txtCIE1.Text = "D509" And txtLab1.Text = "" Then MessageBox.Show("En el DX1 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text = "D509" And txtLab2.Text = "" Then MessageBox.Show("En el DX2 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text = "D509" And txtLab3.Text = "" Then MessageBox.Show("En el DX3 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text = "D509" And txtLab4.Text = "" Then MessageBox.Show("En el DX4 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text = "D509" And txtLab5.Text = "" Then MessageBox.Show("En el DX5 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text = "D509" And txtLab6.Text = "" Then MessageBox.Show("En el DX6 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'Z001 Entre 1 Día a 28 Días Lab 1 a 2
        If txtCIE1.Text = "Z001" And txtLab1.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX1 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text = "Z001" And txtLab2.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX2 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text = "Z001" And txtLab3.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX3 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text = "Z001" And txtLab4.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX4 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text = "Z001" And txtLab5.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX5 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text = "Z001" And txtLab6.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX6 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'Z001 Entre 1 Mes a 11 meses Lab 1 a 11
        If txtCIE1.Text = "Z001" And txtLab1.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX1 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text = "Z001" And txtLab2.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX2 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text = "Z001" And txtLab3.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX3 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text = "Z001" And txtLab4.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX4 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text = "Z001" And txtLab5.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX5 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text = "Z001" And txtLab6.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX6 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'Z001 Entre 1 Año a 2 Años Lab 1 a 6
        If txtCIE1.Text = "Z001" And txtLab1.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX1 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text = "Z001" And txtLab2.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX2 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text = "Z001" And txtLab3.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX3 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text = "Z001" And txtLab4.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX4 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text = "Z001" And txtLab5.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX5 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text = "Z001" And txtLab6.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX6 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function


        'E44? Desnutricion Entre 1 dia menores de 5 Años Lab TP,TE,PE
        If txtCIE1.Text Like "E44*" And txtLab1.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX1 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text Like "E44*" And txtLab2.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX2 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text Like "E44*" And txtLab3.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX3 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text Like "E44*" And txtLab4.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX4 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text Like "E44*" And txtLab5.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX5 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text Like "E44*" And txtLab6.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX6 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'E44? Desnutricion Mayor Igual de 5 Años Lab IMC
        If txtCIE1.Text Like "E44*" And txtLab1.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX1 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text Like "E44*" And txtLab2.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX2 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text Like "E44*" And txtLab3.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX3 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text Like "E44*" And txtLab4.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX4 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text Like "E44*" And txtLab5.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX5 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text Like "E44*" And txtLab6.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX6 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'E66? Sobrepeso Entre 1 dia menores de 5 Años Lab TP,TE,PE
        If txtCIE1.Text Like "E66*" And txtLab1.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX1 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text Like "E66*" And txtLab2.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX2 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text Like "E66*" And txtLab3.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX3 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text Like "E66*" And txtLab4.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX4 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text Like "E66*" And txtLab5.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX5 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text Like "E66*" And txtLab6.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX6 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'E66? Sobrepeso Mayor Igual a 5 Años Lab IMC
        If txtCIE1.Text Like "E66*" And txtLab1.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX1 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text Like "E66*" And txtLab2.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX2 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text Like "E66*" And txtLab3.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX3 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text Like "E66*" And txtLab4.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX4 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text Like "E66*" And txtLab5.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX5 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text Like "E66*" And txtLab6.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX6 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        '99401 Definir # de Consejeria 
        If (txtCIE1.Text = "99401" Or txtCIE1.Text = "99402" Or txtCIE1.Text = "99403" Or txtCIE1.Text = "99404") And txtLab1.Text = "" Then MessageBox.Show("En el DX1 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If (txtCIE2.Text = "99401" Or txtCIE2.Text = "99402" Or txtCIE2.Text = "99403" Or txtCIE2.Text = "99404") And txtLab2.Text = "" Then MessageBox.Show("En el DX2 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If (txtCIE3.Text = "99401" Or txtCIE3.Text = "99402" Or txtCIE3.Text = "99403" Or txtCIE3.Text = "99404") And txtLab3.Text = "" Then MessageBox.Show("En el DX3 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If (txtCIE4.Text = "99401" Or txtCIE4.Text = "99402" Or txtCIE4.Text = "99403" Or txtCIE4.Text = "99404") And txtLab4.Text = "" Then MessageBox.Show("En el DX4 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If (txtCIE5.Text = "99401" Or txtCIE5.Text = "99402" Or txtCIE5.Text = "99403" Or txtCIE5.Text = "99404") And txtLab5.Text = "" Then MessageBox.Show("En el DX5 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If (txtCIE6.Text = "99401" Or txtCIE6.Text = "99402" Or txtCIE6.Text = "99403" Or txtCIE6.Text = "99404") And txtLab6.Text = "" Then MessageBox.Show("En el DX6 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function
    End Function

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim I As Integer
        Dim IdRecetaSIS As String
        Dim NroDias As Integer = DateDiff("d", vFecha, Date.Now.ToShortDateString)
        If NroDias > 2 Then
            MessageBox.Show("Sólo puede Grabar o Modificar la consulta en los dos ultimos días de Atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim dsConsulta As New Data.DataSet

        If txtCIE1.Text = "" Then MessageBox.Show("Debe ingreasr al menos un diagnotico para grabar los datos", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If txtDes1.Text = "" Then MessageBox.Show("Debe ingreasr al menos un diagnotico para grabar los datos", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If cboTipoDiagnostico.Text = "" Then MessageBox.Show("Debe ingreasr el TIPO DE DIAGNOSTICO", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoDiagnostico.Select() : Exit Sub
        If txtSintomas.Text = "" Then MessageBox.Show("Ingrese algun motivo de consulta en SINTOMAS Y SIGNOS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSintomas.Select() : Exit Sub


        'Validar CIE10
        Dim dsValCie As New DataSet
        If txtCIE1.Text <> "" Then
            dsValCie = objCIE10.Buscar(txtCIE1.Text, 1)
            If dsValCie.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE1.Text = "" : txtDes1.Text = "" : txtCIE1.Select() : Exit Sub
            Else
                txtDes1.Enabled = False
                txtDes1.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                txtDes1.Enabled = True
            End If

        End If

        If txtCIE2.Text <> "" Then
            dsValCie = objCIE10.Buscar(txtCIE2.Text, 1)
            If dsValCie.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE2.Text = "" : txtDes2.Text = "" : txtCIE2.Select() : Exit Sub
            Else
                txtDes2.Enabled = False
                txtDes2.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                txtDes2.Enabled = True
            End If
        End If

        If txtCIE3.Text <> "" Then
            dsValCie = objCIE10.Buscar(txtCIE3.Text, 1)
            If dsValCie.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE3.Text = "" : txtDes3.Text = "" : txtCIE3.Select() : Exit Sub
            Else
                txtDes3.Enabled = False
                txtDes3.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                txtDes3.Enabled = True
            End If
        End If

        If txtCIE4.Text <> "" Then
            dsValCie = objCIE10.Buscar(txtCIE4.Text, 1)
            If dsValCie.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE4.Text = "" : txtDes4.Text = "" : txtCIE4.Select() : Exit Sub
            Else
                txtDes4.Enabled = False
                txtDes4.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                txtDes4.Enabled = True
            End If
        End If

        If txtCIE5.Text <> "" Then
            dsValCie = objCIE10.Buscar(txtCIE5.Text, 1)
            If dsValCie.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Text = "" : txtDes5.Text = "" : txtCIE5.Select() : Exit Sub
            Else
                txtDes5.Enabled = False
                txtDes5.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                txtDes5.Enabled = True
            End If
        End If

        If txtCIE6.Text <> "" Then
            dsValCie = objCIE10.Buscar(txtCIE6.Text, 1)
            If dsValCie.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE6.Text = "" : txtDes6.Text = "" : txtCIE6.Select() : Exit Sub
            Else
                txtDes6.Enabled = False
                txtDes6.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                txtDes6.Enabled = True
            End If
        End If

        If txtCIE2.Text <> "" And cboTD1.Text = "" Then MessageBox.Show("Debe ingreasr el TIPO DE DIAGNOSTICO 2", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD1.Select() : Exit Sub
        If txtCIE3.Text <> "" And cboTD2.Text = "" Then MessageBox.Show("Debe ingreasr el TIPO DE DIAGNOSTICO 3", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD2.Select() : Exit Sub
        If txtCIE4.Text <> "" And cboTD3.Text = "" Then MessageBox.Show("Debe ingreasr el TIPO DE DIAGNOSTICO 4", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD3.Select() : Exit Sub
        If txtCIE5.Text <> "" And cboTD4.Text = "" Then MessageBox.Show("Debe ingreasr el TIPO DE DIAGNOSTICO 5", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD4.Select() : Exit Sub
        If txtCIE6.Text <> "" And cboTD5.Text = "" Then MessageBox.Show("Debe ingreasr el TIPO DE DIAGNOSTICO 6", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD5.Select() : Exit Sub

        If ReglasValidacionCIENut() Then Exit Sub

        objHistoria.GrabarUbigeo(lblHistoria.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text)

        'Validar Codigo SIS
        Dim CodigoSIS As String
        If cboTipoAtencion.Text = "SIS" And dgExamenes.Items.Count > 0 And Val(txtNumeroSis.Text) = 0 Then
            MessageBox.Show("Para asignar Procedimientos o Medicamentos a un Paciente SIS debe ingresar el Numero del Formato de Atención. Caso contrario elimine los procedimientos y procesa solo a grabar la CONSULTA", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSis.Select() : Exit Sub
        End If
        If cboTipoAtencion.Text = "SIS" And Val(txtNumeroSis.Text) <> 0 Then

            'Validar Codigo SIS
            Dim dsSIS As New DataSet
            dsSIS = objSis.ConsultarLN(txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text)
            If dsSIS.Tables(0).Rows.Count = 0 Then MessageBox.Show("Los datos del Formato no son correctos, Verificar Numeros del Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            CodigoSIS = dsSIS.Tables(0).Rows(0)("IdSis")

            If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
            If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        End If

        'Verificar Tipo de Paciente Convenios para obtener Codigos
        Dim CodigoConvenio As String
        If cboTipoAtencion.Text <> "SOAT" And Val(txtNroPre.Text) <> 0 Then
            Dim dsConvenio As New DataSet
            dsConvenio = objConvenio.BuscarCH(txtNroPre.Text, lblHistoria.Text)
            CodigoConvenio = dsConvenio.Tables(0).Rows(0)("IdConvenio")

            If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then
                If dsConvenio.Tables(0).Rows(0)("FechaFinal") < Date.Now.ToShortDateString Then
                    MessageBox.Show("Atencion de Convenio ya fue finalizada con fecha " & dsConvenio.Tables(0).Rows(0)("FechaFinal") & ". Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                End If
            End If
        End If

        'Verificar Tipo de Paciente SOAT AFOCAT
        Dim CodigoSoat As String
        If cboTipoAtencion.Text = "SOAT" And dgExamenes.Items.Count > 0 And Val(txtNroPre.Text) = 0 Then
            MessageBox.Show("Para asignar Procedimientos a un Paciente SOAT debe ingresar el Numero de Preliquidación. Caso contrario elimine los procedimientos y procesa solo a grabar la CONSULTA", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub
        End If
        If cboTipoAtencion.Text = "SOAT" Then
            Dim dsSoat As New DataSet
            dsSoat = objSoat.BuscarPH(txtNroPre.Text, lblHistoria.Text)
            If dsSoat.Tables(0).Rows.Count > 0 Then
                CodigoSoat = dsSoat.Tables(0).Rows(0)("IdSoat")

                If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Else
                'CodigoSoat = txtNroPre.Text
                MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        End If

        If vTipoAtencion = "CONSULTA" Then

            dsConsulta = objConsulta.Buscar(CodCupo)
            If dsConsulta.Tables(0).Rows.Count = 0 Then
                objConsulta.Grabar(Date.Now.ToShortDateString, Date.Now.ToShortTimeString, CodCupo, lblHistoria.Text, lblPaciente.Text, txtSintomas.Text, txtTalla.Text, txtPeso.Text, txtPulso.Text, txtTemperatura.Text, txtPresion.Text, "", "", txtEvaluacion.Text, txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, txtTratamiento.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue.ToString & cboProvincia.SelectedValue.ToString & cboDistrito.SelectedValue.ToString, cboEstablecimiento.Text, cboServicio.Text, EspMedico, NomMedico, cboTipoDiagnostico.Text, txtEvolucion.Text, cboTD1.Text, cboTD2.Text, cboTD3.Text, cboTD4.Text, cboTD5.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, vMedico)
            Else
                objConsulta.Modificar(Date.Now.ToShortDateString, Date.Now.ToShortTimeString, CodCupo, lblHistoria.Text, lblPaciente.Text, txtSintomas.Text, txtTalla.Text, txtPeso.Text, txtPulso.Text, txtTemperatura.Text, txtPresion.Text, "", "", txtEvaluacion.Text, txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, txtTratamiento.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue.ToString & cboProvincia.SelectedValue.ToString & cboDistrito.SelectedValue.ToString, cboEstablecimiento.Text, cboServicio.Text, EspMedico, NomMedico, cboTipoDiagnostico.Text, txtEvolucion.Text, cboTD1.Text, cboTD2.Text, cboTD3.Text, cboTD4.Text, cboTD5.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, vMedico)
            End If

            objCupo.Atender(CodCupo)

            objCupo.Atencion(CodCupo, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), My.Computer.Name, "FIN")



            'Grabar Examenes
            For I = 0 To dgExamenes.Items.Count - 1
                If Val(txtNroPre.Text) > 0 And cboTipoAtencion.Text <> "SOAT" Then
                    'Convenios
                    objConvenio.GrabarProcedimientos(CodigoConvenio, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, Date.Now.ToShortDateString, "  /  /")
                    objConsulta.Consulta_GrabarExamenesCanInd(CodCupo, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, EspecialidadMedica, dgExamenes.Items(I).SubItems(7).Text)
                ElseIf cboTipoAtencion.Text = "SIS" Then
                    'Registro procedimientos para atencion
                    objConsulta.Consulta_GrabarExamenesCanInd(CodCupo, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, EspecialidadMedica, dgExamenes.Items(I).SubItems(7).Text)
                    'Registro de procedimientos para la cuenta SIS
                    objSis.GrabarProcedimientosN(CodigoSIS, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, NomMedico, My.Computer.Name, Date.Now.ToShortTimeString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5))
                ElseIf cboTipoAtencion.Text = "SOAT" And Val(txtNroPre.Text) > 0 Then
                    objConsulta.Consulta_GrabarExamenesCanInd(CodCupo, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, EspecialidadMedica, dgExamenes.Items(I).SubItems(7).Text)
                    Dim Clasificador As String = 7
                    If dgExamenes.Items(I).SubItems(5).Text = "LABORATORIO" Then Clasificador = 3
                    If dgExamenes.Items(I).SubItems(5).Text = "RAYOS" Then Clasificador = 2
                    objSoat.GrabarDetalle(CodigoSoat, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Clasificador, "  /  /", Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name)
                Else
                    'Grabar Procedimeintos pacientes pago directo
                    objConsulta.Consulta_GrabarExamenesInd(CodCupo, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, EspecialidadMedica, dgExamenes.Items(I).SubItems(7).Text)
                End If

                'Cancelar Examenes Costo 0
                If Val(dgExamenes.Items(I).SubItems(2).Text) = 0 Then
                    objConsulta.CancelarCostoCero(CodCupo, dgExamenes.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name)
                End If
            Next

            'Grabar Medicamentos
            If cboTipoAtencion.Text = "SIS" Then
                If dgMedicamento.Items.Count > 0 Then
                    IdRecetaSIS = objReceta.SolicitudInd(NomMedico, "CONSULTA EXTERNA", EspecialidadMedica, vIdMedico, NomMedico, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, txtIndicacionMed.Text)
                    For I = 0 To dgMedicamento.Items.Count - 1
                        objConsulta.Consulta_GrabarMedicamentos(CodCupo, dgMedicamento.Items(I).SubItems(0).Text, dgMedicamento.Items(I).SubItems(1).Text, dgMedicamento.Items(I).SubItems(2).Text, dgMedicamento.Items(I).SubItems(3).Text, dgMedicamento.Items(I).SubItems(4).Text)
                        objReceta.GrabarDetalle(IdRecetaSIS, dgMedicamento.Items(I).SubItems(0).Text, dgMedicamento.Items(I).SubItems(1).Text, dgMedicamento.Items(I).SubItems(2).Text, dgMedicamento.Items(I).SubItems(3).Text, dgMedicamento.Items(I).SubItems(5).Text, dgMedicamento.Items(I).SubItems(6).Text)
                    Next

                    'Grabar Detalle CIE
                    If txtCIE1.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE1.Text, txtDes1.Text)
                    If txtCIE2.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE2.Text, txtDes2.Text)
                    If txtCIE3.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE3.Text, txtDes3.Text)
                    If txtCIE4.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE4.Text, txtDes4.Text)
                    If txtCIE5.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE5.Text, txtDes5.Text)
                    If txtCIE6.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE6.Text, txtDes6.Text)
                End If
            End If

            MessageBox.Show("Datos Guardados Correctamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        ElseIf vTipoAtencion = "INTERCONSULTA" Then
            dsConsulta = objInterconsultaH.Buscar(CodCupo)
            If dsConsulta.Tables(0).Rows.Count = 0 Then
                objInterconsultaH.GrabarLab(vFecha, Date.Now.ToShortTimeString, lblHistoria.Text, lblPaciente.Text, txtSintomas.Text, txtTalla.Text, txtPeso.Text, txtPulso.Text, txtTemperatura.Text, txtPresion.Text, "", "", txtEvaluacion.Text, txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, txtTratamiento.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue.ToString & cboProvincia.SelectedValue.ToString & cboDistrito.SelectedValue.ToString, cboEstablecimiento.Text, cboServicio.Text, vEspecialidad, NomMedico, cboTipoDiagnostico.Text, txtEvolucion.Text, cboTD1.Text, cboTD2.Text, cboTD3.Text, vIdMedico, vTurno, vEspecialidad, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD4.Text, cboTD5.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text)
            Else
                objInterconsultaH.ModificarLab(CodCupo, frmListaAtencion.dtpFecha.Value.ToShortDateString, Date.Now.ToShortTimeString, lblHistoria.Text, lblPaciente.Text, txtSintomas.Text, txtTalla.Text, txtPeso.Text, txtPulso.Text, txtTemperatura.Text, txtPresion.Text, "", "", txtEvaluacion.Text, txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, txtTratamiento.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue.ToString & cboProvincia.SelectedValue.ToString & cboDistrito.SelectedValue.ToString, cboEstablecimiento.Text, cboServicio.Text, vEspecialidad, NomMedico, cboTipoDiagnostico.Text, txtEvolucion.Text, cboTD1.Text, cboTD2.Text, cboTD3.Text, vIdMedico, vTurno, vEspecialidad, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD4.Text, cboTD5.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text)
            End If

            MessageBox.Show("Datos Guardados Correctamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        ElseIf vTipoAtencion = "INTERCONSULTAE" Or vTipoAtencion = "PROGRAMA" Then
            dsConsulta = objInterconsultaE.Buscar(CodCupo)
            If dsConsulta.Tables(0).Rows.Count = 0 Then
                CodCupo = objInterconsultaE.GrabarCodigo(frmListaAtencion.dtpFecha.Value.ToShortDateString, Date.Now.ToShortTimeString, lblHistoria.Text, lblPaciente.Text, txtSintomas.Text, txtTalla.Text, txtPeso.Text, txtPulso.Text, txtTemperatura.Text, txtPresion.Text, "", "", txtEvaluacion.Text, txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, txtTratamiento.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue.ToString & cboProvincia.SelectedValue.ToString & cboDistrito.SelectedValue.ToString, cboEstablecimiento.Text, cboServicio.Text, EspecialidadMedica, NomMedico, cboTipoDiagnostico.Text, txtEvolucion.Text, cboTD1.Text, cboTD2.Text, cboTD3.Text, vIdMedico, vTurno, EspecialidadMedica, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD4.Text, cboTD5.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboTipoAtencion.Text)
            Else
                objInterconsultaE.ModificarLab(CodCupo, frmListaAtencion.dtpFecha.Value.ToShortDateString, Date.Now.ToShortTimeString, lblHistoria.Text, lblPaciente.Text, txtSintomas.Text, txtTalla.Text, txtPeso.Text, txtPulso.Text, txtTemperatura.Text, txtPresion.Text, "", "", txtEvaluacion.Text, txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, txtTratamiento.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue.ToString & cboProvincia.SelectedValue.ToString & cboDistrito.SelectedValue.ToString, cboEstablecimiento.Text, cboServicio.Text, EspecialidadMedica, NomMedico, cboTipoDiagnostico.Text, txtEvolucion.Text, cboTD1.Text, cboTD2.Text, cboTD3.Text, vIdMedico, vTurno, EspecialidadMedica, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD4.Text, cboTD5.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text)
            End If

            If cboTipoAtencion.Text = "SIS" And Val(txtNumeroSis.Text) <> 0 Then

                'Validar Codigo SIS
                Dim dsSIS As New DataSet
                dsSIS = objSis.ConsultarLN(txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text)
                If dsSIS.Tables(0).Rows.Count = 0 Then MessageBox.Show("Los datos del Formato no son correctos, Verificar Numeros del Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                CodigoSIS = dsSIS.Tables(0).Rows(0)("IdSis")

                If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                    If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                End If
                If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                    MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                End If
            End If


            'Grabar Examenes
            For I = 0 To dgExamenes.Items.Count - 1
                If Val(txtNroPre.Text) > 0 And cboTipoAtencion.Text <> "SOAT" Then
                    'Convenios
                    objConvenio.GrabarProcedimientos(CodigoConvenio, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, Date.Now.ToShortDateString, "  /  /")
                    objConsulta.Consulta_GrabarExamenesCanInd(CodCupo, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, EspecialidadMedica, dgExamenes.Items(I).SubItems(7).Text)
                ElseIf cboTipoAtencion.Text = "SIS" And Val(txtNumeroSis.Text) <> 0 Then
                    'Registro procedimientos para atencion
                    objConsulta.Consulta_GrabarExamenesCanInd(CodCupo, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, EspecialidadMedica, dgExamenes.Items(I).SubItems(7).Text)
                    'Registro de procedimientos para la cuenta SIS
                    objSis.GrabarProcedimientosN(CodigoSIS, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, NomMedico, My.Computer.Name, Date.Now.ToShortTimeString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5))
                ElseIf cboTipoAtencion.Text = "SOAT" And Val(txtNroPre.Text) > 0 Then
                    objConsulta.Consulta_GrabarExamenesCanInd(CodCupo, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, EspecialidadMedica, dgExamenes.Items(I).SubItems(7).Text)
                    Dim Clasificador As String = 7
                    If dgExamenes.Items(I).SubItems(5).Text = "LABORATORIO" Then Clasificador = 3
                    If dgExamenes.Items(I).SubItems(5).Text = "RAYOS" Then Clasificador = 2
                    objSoat.GrabarDetalle(CodigoSoat, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Clasificador, "  /  /", Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name)
                Else
                    'Grabar Procedimeintos pacientes pago directo
                    objConsulta.Consulta_GrabarExamenesInd(CodCupo, dgExamenes.Items(I).SubItems(0).Text, dgExamenes.Items(I).SubItems(1).Text, dgExamenes.Items(I).SubItems(2).Text, dgExamenes.Items(I).SubItems(3).Text, dgExamenes.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name, dgExamenes.Items(I).SubItems(5).Text, dgExamenes.Items(I).SubItems(6).Text, cboTipoAtencion.Text, txtNroPre.Text, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, EspecialidadMedica, dgExamenes.Items(I).SubItems(7).Text)
                End If

                'Cancelar Examenes Costo 0
                If Val(dgExamenes.Items(I).SubItems(2).Text) = 0 Then
                    objConsulta.CancelarCostoCero(CodCupo, dgExamenes.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), NomMedico, My.Computer.Name)
                End If
            Next

            'Grabar Medicamentos
            If cboTipoAtencion.Text = "SIS" And Val(txtNumeroSis.Text) <> 0 Then
                IdRecetaSIS = objReceta.SolicitudInd(UsuarioSistema, "CONSULTA EXTERNA", EspecialidadMedica, vIdMedico, NomMedico, txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text, lblPaciente.Text, txtIndicacionMed.Text)
                For I = 0 To dgMedicamento.Items.Count - 1
                    objConsulta.Consulta_GrabarMedicamentos(CodCupo, dgMedicamento.Items(I).SubItems(0).Text, dgMedicamento.Items(I).SubItems(1).Text, dgMedicamento.Items(I).SubItems(2).Text, dgMedicamento.Items(I).SubItems(3).Text, dgMedicamento.Items(I).SubItems(4).Text)
                    objReceta.GrabarDetalle(IdRecetaSIS, dgMedicamento.Items(I).SubItems(0).Text, dgMedicamento.Items(I).SubItems(1).Text, dgMedicamento.Items(I).SubItems(2).Text, dgMedicamento.Items(I).SubItems(3).Text, dgMedicamento.Items(I).SubItems(5).Text, dgMedicamento.Items(I).SubItems(6).Text)
                Next

                'Grabar Detalle CIE
                If txtCIE1.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE1.Text, txtDes1.Text)
                If txtCIE2.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE2.Text, txtDes2.Text)
                If txtCIE3.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE3.Text, txtDes3.Text)
                If txtCIE4.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE4.Text, txtDes4.Text)
                If txtCIE5.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE5.Text, txtDes5.Text)
                If txtCIE6.Text <> "" Then objReceta.GrabarCIE(IdRecetaSIS, txtCIE6.Text, txtDes6.Text)
            End If

            MessageBox.Show("Datos Guardados Correctamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub txtExamenes_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExamenes.TextChanged
        If txtExamenes.Text <> "" And txtExamenes.Enabled Then
            If txtCIE1.Text = "" Then MessageBox.Show("Debe ingresar un Diagnóstico como mínimo para Solicitar los Procedimientos", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE1.Select() : Exit Sub
            'Validar Diagnostico

            If cboTipoAtencion.Text = "SIS" And txtSerieSis.Text = "" Then MessageBox.Show("Debe Ingresar La Serie de SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSis.Select() : Exit Sub
            If cboTipoAtencion.Text = "SIS" And IsNumeric(txtNumeroSis.Text) = 0 Then MessageBox.Show("Debe Ingresar El Numero de SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNumeroSis.Select() : Exit Sub

            Filtro = "EXAMENES" : gbFiltro.Visible = True : txtFiltro.Text = txtExamenes.Text : txtFiltro.SelectionStart = Len(txtFiltro.Text) : txtFiltro.Select()
        End If
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter And lvFiltro.Items.Count > 0 Then lvFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text.Length <= 1 Then Exit Sub
        'Validar si es SOAT o AFOCAT
        'Dim TipoPrecioSA As String = "SOAT"
        'If cboTipoAtencion.Text = "SOAT" Then
        '    Dim dsSOAT As New DataSet
        '    dsSOAT = objSoat.BuscarPH(txtNroPre.Text, lblHistoria.Text)
        '    If dsSOAT.Tables(0).Rows.Count = 0 Then
        '        If dsSOAT.Tables(0).Rows(0)("Aseguradora") = "AFOCAT" Then TipoPrecioSA = "AFOCAT"
        '    End If
        'End If

        Select Case Filtro
            Case "MEDICAMENTO"
                Dim Fila As ListViewItem
                Dim I As Integer
                Dim dsMed As New Data.DataSet
                dsMed = objMedicamento.ObtenerMedicamentos(txtFiltro.Text & "%", 1)
                dgFiltro.DataSource = objMedicamento.ObtenerMedicamentos(txtFiltro.Text & "%", 1).Tables(0)
                lvFiltro.Clear()
                lvFiltro.Columns.Add("Id", 0)
                lvFiltro.Columns.Add("Descripcion", 300)
                lvFiltro.Columns.Add("Precio", 60)
                lvFiltro.Columns.Add("IdTipoTarifa", 0)
                lvFiltro.Columns.Add("UND", 50)
                lvFiltro.Columns.Add("PrecioSIGV", 0)
                lvFiltro.Columns.Add("Stock", 60)
                For I = 0 To dsMed.Tables(0).Rows.Count - 1
                    Fila = lvFiltro.Items.Add(dsMed.Tables(0).Rows(I)("BienServ"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Precio"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("IdTipoTarifa"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Unidad"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("PrecioSIGV"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Stock"))
                Next
            Case "EXAMENES"
                Dim Fila As ListViewItem
                Dim I As Integer
                Dim dsExa As New Data.DataSet
                Dim TipoTarifa As String
                If cboTipoAtencion.Text <> "" Then
                    If Val(txtNroPre.Text) = 0 Then
                        If cboTipoAtencion.Text = "COMUN" Or cboTipoAtencion.Text = "EXONERADO" Or cboTipoAtencion.Text = "PROGRAMA" Or cboTipoAtencion.Text = "OTROS" Then
                            TipoTarifa = 1
                        ElseIf cboTipoAtencion.Text = "SIS" Then
                            TipoTarifa = 12
                        End If
                        dsExa = objExamen.BuscarServicio(txtFiltro.Text & "%", TipoTarifa, "D")
                    Else
                        If cboTipoAtencion.Text = "SOAT" Then
                            dsExa = objSoat.BuscarDes(txtFiltro.Text, "TODO")
                        Else
                            Dim dsVerC As New DataSet
                            dsVerC = objConvenio.VerificarTipoAtencionCE(txtNroPre.Text)
                            If dsVerC.Tables(0).Rows.Count > 0 Then TipoTarifa = dsVerC.Tables(0).Rows(0)("IdTipoConvenio") Else TipoTarifa = 1
                            dsExa = objExamen.BuscarServicio(txtFiltro.Text & "%", TipoTarifa, "D")
                        End If
                    End If

                    dgFiltro.DataSource = dsExa.Tables(0)
                Else

                End If

                lvFiltro.Clear()
                lvFiltro.Columns.Add("Id", 0)
                lvFiltro.Columns.Add("Descripcion", 400)
                lvFiltro.Columns.Add("Precio", 100, HorizontalAlignment.Right)
                lvFiltro.Columns.Add("IdTipoTarifa", 0)
                lvFiltro.Columns.Add("IdItem", 0)
                lvFiltro.Columns.Add("Tipo", 0)
                lvFiltro.Columns.Add("Clase", 0)
                For I = 0 To dsExa.Tables(0).Rows.Count - 1
                    If cboTipoAtencion.Text <> "SOAT" Then
                        Fila = lvFiltro.Items.Add(dsExa.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsExa.Tables(0).Rows(I)("Precio")), "#,##0.00"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("IdTipoTarifa"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("IdItem"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("ClasLaboratorio"))
                    Else
                        Fila = lvFiltro.Items.Add(dsExa.Tables(0).Rows(I)("IdTarifario"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsExa.Tables(0).Rows(I)("Precio")), "#,##0.00"))
                        Fila.SubItems.Add("")
                        Fila.SubItems.Add("")
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsExa.Tables(0).Rows(I)("SubTipo"))
                    End If
                Next
        End Select
    End Sub

    Private Sub dgFiltro_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles dgFiltro.Invalidated

    End Sub

    Private Sub dgFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgFiltro.KeyDown
        If dgFiltro.Rows.Count > 0 And e.KeyCode = Keys.I Then
            Select Case Filtro
                Case "MEDICAMENTO"
                    txtMedicamento.Enabled = False
                    txtMedicamento.Tag = dgFiltro.Item(0, dgFiltro.CurrentRow.Index).Value
                    txtMedicamento.Text = dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value
                    txtMedicamento.Enabled = True
                    lblUnidad.Text = dgFiltro.Item(2, dgFiltro.CurrentRow.Index).Value
                    lblPrecioM.Text = Microsoft.VisualBasic.Format(dgFiltro.Item(3, dgFiltro.CurrentRow.Index).Value, "#0.00")
                    StockMed = dgFiltro.Item(6, dgFiltro.CurrentRow.Index).Value
                    gbFiltro.Visible = False
                    txtCantidadM.Text = 1
                    txtCantidadM.Select()
                Case "EXAMENES"
                    txtExamenes.Enabled = False
                    txtExamenes.Tag = dgFiltro.Item(0, dgFiltro.CurrentRow.Index).Value
                    txtExamenes.Text = dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value
                    txtExamenes.Enabled = True
                    lblPrecioE.Text = Microsoft.VisualBasic.Format(dgFiltro.Item(2, dgFiltro.CurrentRow.Index).Value, "#0.00")
                    gbFiltro.Visible = False
                    txtCantidadE.Text = 1
                    txtCantidadE.Select()
            End Select
        End If
    End Sub

    Private Sub txtCantidadE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidadE.KeyDown
        If e.KeyCode = Keys.Enter Then txtIndicacion.Select()
    End Sub

    Private Sub FiltroCIE()
        Select Case Microsoft.VisualBasic.Left(nomFiltro, nomFiltro.Length - 1)
            Case "DESCIE"
                If txtDes.Text.Length = 0 Then Exit Sub
                lvDet.Items.Clear()
                Dim dsTabla As New DataSet
                Dim I As Integer
                Dim Fila As ListViewItem
                dsTabla = objCIE10.Buscar(txtDes.Text, 2)
                For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                    Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("Codigo"))
                    Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
                Next
        End Select
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If e.KeyCode = Keys.Enter And lvDet.Items.Count > 0 Then lvDet.Select()
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        FiltroCIE()
    End Sub

    Private Sub lvDet_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDet.DoubleClick
        If lvDet.SelectedItems.Count > 0 Then
            Dim I As Integer
            Dim dsVer As New DataSet
            dsVer = objCIE10.Buscar(lvDet.SelectedItems(0).SubItems(0).Text, 1)

            'Verificar Edad
            Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
            If dsVer.Tables(0).Rows(0)("MinTipo") <> "" Then
                Dim RMin, RMax As Double
                If dsVer.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad")) * 360
                If dsVer.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad")) * 30
                If dsVer.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad"))

                If dsVer.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad")) * 360
                If dsVer.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad")) * 30
                If dsVer.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad"))

                If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsVer.Tables(0).Rows(0)("MinEdad") & " " & dsVer.Tables(0).Rows(0)("MinTipo") & " y " & dsVer.Tables(0).Rows(0)("MaxEdad") & " " & dsVer.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            End If


            'Verificar Sexo
            If dsVer.Tables(0).Rows(0)("Sexo") = "F" And lblSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If dsVer.Tables(0).Rows(0)("Sexo") = "M" And lblSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


            Select Case nomFiltro
                Case "DESCIE1"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE1.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes1.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTipoDiagnostico.Text = "DEFINITIVO" : txtCIE2.Select() Else cboTipoDiagnostico.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE2"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE2.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes2.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD1.Text = "DEFINITIVO" : txtCIE3.Select() Else cboTD1.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE3"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE3.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes3.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD2.Text = "DEFINITIVO" : txtCIE4.Select() Else cboTD2.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE4"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE4.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes4.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD3.Text = "DEFINITIVO" : txtCIE5.Select() Else cboTD3.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE5"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE5.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes5.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD4.Text = "DEFINITIVO" : txtCIE6.Select() Else cboTD4.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE6"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE6.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes6.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD5.Text = "DEFINITIVO" : txtTratamiento.Select() Else cboTD5.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIEP"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            'txtCIEP.Text = lvDet.Items(I).SubItems(0).Text
                            'txtDesP.Text = lvDet.Items(I).SubItems(1).Text
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtEvaluacion.Select()
                            Exit For
                        End If
                    Next
            End Select
        End If
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Enter And lvDet.SelectedItems.Count > 0 Then
            Dim I As Integer
            Dim dsVer As New DataSet
            dsVer = objCIE10.Buscar(lvDet.SelectedItems(0).SubItems(0).Text, 1)


            'Verificar Edad
            Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
            If dsVer.Tables(0).Rows(0)("MinTipo") <> "" Then
                Dim RMin, RMax As Double
                If dsVer.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad")) * 360
                If dsVer.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad")) * 30
                If dsVer.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad"))

                If dsVer.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad")) * 360
                If dsVer.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad")) * 30
                If dsVer.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad"))

                If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsVer.Tables(0).Rows(0)("MinEdad") & " " & dsVer.Tables(0).Rows(0)("MinTipo") & " y " & dsVer.Tables(0).Rows(0)("MaxEdad") & " " & dsVer.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            End If


            'Verificar Sexo
            If dsVer.Tables(0).Rows(0)("Sexo") = "F" And lblSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If dsVer.Tables(0).Rows(0)("Sexo") = "M" And lblSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


            Select Case nomFiltro
                Case "DESCIE1"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE1.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes1.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTipoDiagnostico.Text = "DEFINITIVO" : txtCIE2.Select() Else cboTipoDiagnostico.Select()

                            'Validar Morbilidad Definitiva
                            If dsVer.Tables(0).Rows(0)("MorbilidadDefinitiva") = "X" Then
                                Dim J As Integer
                                Dim dsVerMD As New DataSet
                                Dim Existe As Boolean = False
                                For J = 1 To 6
                                    dsVerMD = objConsulta.VerDiagnosticoMorDef(lblHistoria.Text, txtCIE1.Text, J)
                                    If dsVerMD.Tables(0).Rows.Count > 0 Then
                                        Select Case J
                                            Case 1
                                                If dsVerMD.Tables(0).Rows(0)("TipoDiagnostico") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO"
                                            Case 2
                                                If dsVerMD.Tables(0).Rows(0)("TD1") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO"
                                            Case 3
                                                If dsVerMD.Tables(0).Rows(0)("TD2") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO"
                                            Case 4
                                                If dsVerMD.Tables(0).Rows(0)("TD3") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO"
                                            Case 5
                                                If dsVerMD.Tables(0).Rows(0)("TD4") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO"
                                            Case 6
                                                If dsVerMD.Tables(0).Rows(0)("TD5") = "DEFINITIVO" Then cboTipoDiagnostico.Text = "REPETITIVO"
                                        End Select
                                    End If
                                Next
                            End If

                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE2"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE2.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes2.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD1.Text = "DEFINITIVO" : txtCIE3.Select() Else cboTD1.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE3"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE3.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes3.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD2.Text = "DEFINITIVO" : txtCIE4.Select() Else cboTD2.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE4"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE4.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes4.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD3.Text = "DEFINITIVO" : txtCIE5.Select() Else cboTD3.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE5"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE5.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes5.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD4.Text = "DEFINITIVO" : txtCIE6.Select() Else cboTD4.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIE6"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDet.Items(I).SubItems(0).Text = txtCIE5.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE6.Text = lvDet.Items(I).SubItems(0).Text
                            txtDes6.Text = lvDet.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD5.Text = "DEFINITIVO" : txtTratamiento.Select() Else cboTD5.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            Exit For
                        End If
                    Next
                Case "DESCIEP"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            'txtCIEP.Text = lvDet.Items(I).SubItems(0).Text
                            'txtDesP.Text = lvDet.Items(I).SubItems(1).Text
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtEvaluacion.Select()
                            Exit For
                        End If
                    Next
            End Select
        End If
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbConsulta.Visible = False
    End Sub

    Private Sub lvHosp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvHosp.Click
        lvDetH.Items.Clear()
        lblTHosp.Text = "0.00"
        If lvHosp.Items.Count > 0 Then
            Dim dsDet As New Data.DataSet
            Dim I As Integer
            Dim J As Integer
            Dim Fila As ListViewItem
            For I = 0 To lvHosp.Items.Count - 1
                If lvHosp.Items(I).Selected Then
                    dsDet = objHosp.BuscarDetHospitalizacion(lvHosp.Items(I).SubItems(7).Text)
                    For J = 0 To dsDet.Tables(0).Rows.Count - 1
                        Fila = lvDetH.Items.Add(dsDet.Tables(0).Rows(J)("IdServicioItem"))
                        Fila.SubItems.Add(dsDet.Tables(0).Rows(J)("Descripcion"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(dsDet.Tables(0).Rows(J)("Precio"), "#0.00"))
                        Fila.SubItems.Add(dsDet.Tables(0).Rows(J)("Cantidad"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(J)("Importe")), "#0.00"))
                        lblTHosp.Text = Microsoft.VisualBasic.Format(Val(lblTHosp.Text) + Val(dsDet.Tables(0).Rows(J)("Importe")), "#0.00")
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub lvImg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvImg.SelectedIndexChanged
        pbImg.Image = Nothing
        Dim Pos As Integer
        If lvImg.Items.Count > 0 Then
            Dim I As Integer
            For I = 0 To lvImg.Items.Count - 1
                If lvImg.Items(I).Selected Then
                    'pbImg.Image = lvImg.FocusedItem.ImageList.Images.Item(I)
                    Pos = I
                    Exit For
                End If
            Next
        End If
        Dim dsImg As New Data.DataSet
        dsImg = objRayos.BuscarCodigo(lblHistoria.Text)
        If dsImg.Tables(0).Rows(Pos)("Imagen").ToString <> "" Then pbImg.Image = DameImagen(dsImg.Tables(0).Rows(Pos)("Imagen"))
        Fecha = Microsoft.VisualBasic.Left(dsImg.Tables(0).Rows(Pos)("Fecha"), 10)
        Informe = dsImg.Tables(0).Rows(Pos)("Descripcion")
        txtInforme.Text = dsImg.Tables(0).Rows(Pos)("Descripcion")
    End Sub

    Private Sub pbImg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbImg.DoubleClick
        MessageBox.Show(Informe, "Informe de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnC10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC10.Click
        If IsNumeric(btnC10.Text) Then If btnC10.BackColor = Color.IndianRed Or btnC10.BackColor = Color.Teal Or btnC10.BackColor = Color.White Then lblNCupo.Text = btnC10.Tag Else lblNCupo.Text = ""
    End Sub

    Private Sub cboTurno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTurno.KeyDown
        If e.KeyCode = Keys.Enter And cboTurno.Text <> "" Then cboEspecialidad.Select()
    End Sub

    Private Sub cboTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTurno.SelectedIndexChanged
        If cboEspecialidad.Text <> "" And cboSubEspecialidad.Text <> "" And cboMedico.Text <> "" And cboTipoCupo.Text <> "" Then LlenarCupos() : PintarCupos()
    End Sub

    Private Sub dtpFechaCita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaCita.KeyDown
        If e.KeyCode = Keys.Enter Then cboTurno.Select()
    End Sub

    Private Sub dtpFechaCita_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaCita.ValueChanged
        'If cboEspecialidad.Text <> "" And cboSubEspecialidad.Text <> "" And cboMedico.Text <> "" And cboTipoCupo.Text <> "" Then LlenarCupos() : PintarCupos()
    End Sub

    Private Function DameHoraCita() As String
        Dim X As Object
        For Each X In pCupos.Controls
            If TypeOf X Is Label Then
                If X.Tag = "H" & lblNCupo.Text Then DameHoraCita = X.text : Exit For
            End If
        Next
    End Function

    Private Sub btnAsignarCupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarCupo.Click
        If cboSubEspecialidad.Text <> EspecialidadMedica Then MessageBox.Show("Usted no puede asignar una cita que no sea de su especialidad!!!", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

        If cboTipoCupo.Text <> "CONTINUADOR" Then MessageBox.Show("Sólo puede asignar cupos CONTINUADORES", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoCupo.Text = "CONTINUADOR" : Exit Sub
        Dim NCorrelativo As String
        If MessageBox.Show("Esta Seguro de Asignar Cupo", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCupo.VerificarAsignacion(lblHistoria.Text, dtpFechaCita.Value.ToShortDateString, cboSubEspecialidad.SelectedValue.ToString)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("Paciente ya tiene registrado una atencion para este día y especialidad", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else

                'Verificar Cupo
                Dim I As Integer
                Dim dsVer As New DataSet
                For I = 1 To 15
                    dsVer = objCupo.VerificarCupo(lblNCupo.Text, Format(dtpFechaCita.Value, "dd/MM/yyyy"), cboSubEspecialidad.SelectedValue, CodPro)
                    If dsVer.Tables(0).Rows.Count > 0 Then
                        MessageBox.Show("Cupo ya fue asignado por otro Usuario... Se Actualizara su Pantalla", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LlenarCupos()
                        PintarCupos()
                        Exit Sub
                    End If
                Next


                Dim dsHistoria As New Data.DataSet
                Dim Edad As String
                Dim HoraCita As String
                dsHistoria = objHistoria.BuscarHistoria(lblHistoria.Text)
                If dsHistoria.Tables(0).Rows.Count > 0 Then
                    Edad = lbledad.Text

                    HoraCita = DameHoraCita()
                    Dim AÑos As Integer
                    If dsHistoria.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                        AÑos = Date.Now.Year - CDate(dsHistoria.Tables(0).Rows(0)("FNACIMIENTO")).Year
                        Edad = AÑos
                    Else
                        Edad = 0
                    End If
                    Dim dsMed As New DataSet
                    Dim CodigoMedico As String
                    dsMed = objMedico.Medico_BuscarNombres(cboMedico.Text)
                    If dsMed.Tables(0).Rows.Count > 0 Then CodigoMedico = dsMed.Tables(0).Rows(0)("IdMedico") Else CodigoMedico = "0"
                    NCorrelativo = objCupo.GuardarCupoMed(lblHistoria.Text, Trim(dsHistoria.Tables(0).Rows(0)("APaterno")), Trim(dsHistoria.Tables(0).Rows(0)("AMaterno")), Trim(dsHistoria.Tables(0).Rows(0)("Nombres")), Edad, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, dtpFechaCita.Value.ToShortDateString, HoraCita, cboTurno.Text, cboEspecialidad.Text, cboSubEspecialidad.Text, cboSubEspecialidad.SelectedValue, lblNCupo.Text, cboTipoCupo.Text, CodPro, "CONSULTORIO", Microsoft.VisualBasic.Left(NomMedico, 15), "CONSULTA", cboSubEspecialidad.SelectedValue, cboSubEspecialidad.Text, 0, 0, CodigoMedico, cboMedico.Text, cboTipoCupo.Text, "NO", "NO", 0, "", 0)
                    objCupo.ActNroCupos(CodPro, cboTipoCupo.Text)
                End If
            End If
        End If
        If cboEspecialidad.Text <> "" And cboSubEspecialidad.Text <> "" And cboMedico.Text <> "" And cboTipoCupo.Text <> "" Then LlenarCupos() : PintarCupos()
    End Sub

    Private Sub cboTipoCupo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoCupo.KeyDown

    End Sub

    Private Sub cboTipoCupo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCupo.SelectedIndexChanged
        If cboEspecialidad.Text <> "" And cboSubEspecialidad.Text <> "" And cboMedico.Text <> "" And cboTipoCupo.Text <> "" Then LlenarCupos() : PintarCupos()
    End Sub

    Private Sub cboMedico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMedico.SelectedIndexChanged
        If cboEspecialidad.Text <> "" And cboSubEspecialidad.Text <> "" And cboMedico.Text <> "" And cboTipoCupo.Text <> "" And cboMedico.Enabled Then TBusqueda = False : LlenarCupos() : PintarCupos()
    End Sub

    Private Sub btnC28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC28.Click
        If IsNumeric(btnC28.Text) Then
            If btnC28.BackColor = Color.IndianRed Or btnC28.BackColor = Color.White Then
                lblNCupo.Text = btnC28.Tag
            Else
                lblNCupo.Text = ""
            End If
        End If
    End Sub

    Private Sub btnC27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC27.Click
        If IsNumeric(btnC27.Text) Then If btnC27.BackColor = Color.IndianRed Or btnC27.BackColor = Color.Teal Or btnC27.BackColor = Color.White Then lblNCupo.Text = btnC27.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC23.Click
        If IsNumeric(btnC23.Text) Then If btnC23.BackColor = Color.IndianRed Or btnC23.BackColor = Color.Teal Or btnC23.BackColor = Color.White Then lblNCupo.Text = btnC23.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC26.Click
        If IsNumeric(btnC26.Text) Then If btnC26.BackColor = Color.IndianRed Or btnC26.BackColor = Color.Teal Or btnC26.BackColor = Color.White Then lblNCupo.Text = btnC26.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC25.Click
        If IsNumeric(btnC25.Text) Then If btnC25.BackColor = Color.IndianRed Or btnC25.BackColor = Color.Teal Or btnC25.BackColor = Color.White Then lblNCupo.Text = btnC25.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC24.Click
        If IsNumeric(btnC24.Text) Then If btnC24.BackColor = Color.IndianRed Or btnC24.BackColor = Color.Teal Or btnC24.BackColor = Color.White Then lblNCupo.Text = btnC24.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC22.Click
        If IsNumeric(btnC22.Text) Then If btnC22.BackColor = Color.IndianRed Or btnC22.BackColor = Color.Teal Or btnC22.BackColor = Color.White Then lblNCupo.Text = btnC22.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC21.Click
        If IsNumeric(btnC21.Text) Then If btnC21.BackColor = Color.IndianRed Or btnC21.BackColor = Color.Teal Or btnC21.BackColor = Color.White Then lblNCupo.Text = btnC21.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC20.Click
        If IsNumeric(btnC20.Text) Then If btnC20.BackColor = Color.IndianRed Or btnC20.BackColor = Color.Teal Or btnC20.BackColor = Color.White Then lblNCupo.Text = btnC20.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC19.Click
        If IsNumeric(btnC19.Text) Then If btnC19.BackColor = Color.IndianRed Or btnC19.BackColor = Color.Teal Or btnC19.BackColor = Color.White Then lblNCupo.Text = btnC19.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC18.Click
        If IsNumeric(btnC18.Text) Then If btnC18.BackColor = Color.IndianRed Or btnC18.BackColor = Color.Teal Or btnC18.BackColor = Color.White Then lblNCupo.Text = btnC18.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC17.Click
        If IsNumeric(btnC17.Text) Then If btnC17.BackColor = Color.IndianRed Or btnC17.BackColor = Color.Teal Or btnC17.BackColor = Color.White Then lblNCupo.Text = btnC17.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC16.Click
        If IsNumeric(btnC16.Text) Then If btnC16.BackColor = Color.IndianRed Or btnC16.BackColor = Color.Teal Or btnC16.BackColor = Color.White Then lblNCupo.Text = btnC16.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC15.Click
        If IsNumeric(btnC15.Text) Then If btnC15.BackColor = Color.IndianRed Or btnC15.BackColor = Color.Teal Or btnC15.BackColor = Color.White Then lblNCupo.Text = btnC15.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC14.Click
        If IsNumeric(btnC14.Text) Then If btnC14.BackColor = Color.IndianRed Or btnC14.BackColor = Color.Teal Or btnC14.BackColor = Color.White Then lblNCupo.Text = btnC14.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC13.Click
        If IsNumeric(btnC13.Text) Then If btnC13.BackColor = Color.IndianRed Or btnC13.BackColor = Color.Teal Or btnC13.BackColor = Color.White Then lblNCupo.Text = btnC13.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC12.Click
        If IsNumeric(btnC12.Text) Then If btnC12.BackColor = Color.IndianRed Or btnC12.BackColor = Color.Teal Or btnC12.BackColor = Color.White Then lblNCupo.Text = btnC12.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC11.Click
        If IsNumeric(btnC11.Text) Then If btnC11.BackColor = Color.IndianRed Or btnC11.BackColor = Color.Teal Or btnC11.BackColor = Color.White Then lblNCupo.Text = btnC11.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC9.Click
        If IsNumeric(btnC9.Text) Then If btnC9.BackColor = Color.IndianRed Or btnC9.BackColor = Color.Teal Or btnC9.BackColor = Color.White Then lblNCupo.Text = btnC9.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC8.Click
        If IsNumeric(btnC8.Text) Then If btnC8.BackColor = Color.IndianRed Or btnC8.BackColor = Color.Teal Or btnC8.BackColor = Color.White Then lblNCupo.Text = btnC8.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC7.Click
        If IsNumeric(btnC7.Text) Then If btnC7.BackColor = Color.IndianRed Or btnC7.BackColor = Color.Teal Or btnC7.BackColor = Color.White Then lblNCupo.Text = btnC7.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC6.Click
        If IsNumeric(btnC6.Text) Then If btnC6.BackColor = Color.IndianRed Or btnC6.BackColor = Color.Teal Or btnC6.BackColor = Color.White Then lblNCupo.Text = btnC6.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC5.Click
        If IsNumeric(btnC5.Text) Then If btnC5.BackColor = Color.IndianRed Or btnC5.BackColor = Color.Teal Or btnC5.BackColor = Color.White Then lblNCupo.Text = btnC5.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC4.Click
        If IsNumeric(btnC4.Text) Then If btnC4.BackColor = Color.IndianRed Or btnC4.BackColor = Color.Teal Or btnC4.BackColor = Color.White Then lblNCupo.Text = btnC4.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC3.Click
        If IsNumeric(btnC3.Text) Then If btnC3.BackColor = Color.IndianRed Or btnC3.BackColor = Color.Teal Or btnC3.BackColor = Color.White Then lblNCupo.Text = btnC3.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC2.Click
        If IsNumeric(btnC2.Text) Then If btnC2.BackColor = Color.IndianRed Or btnC2.BackColor = Color.Teal Or btnC2.BackColor = Color.White Then lblNCupo.Text = btnC2.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub btnC1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC1.Click
        If IsNumeric(btnC1.Text) Then If btnC1.BackColor = Color.IndianRed Or btnC1.BackColor = Color.Teal Or btnC1.BackColor = Color.White Then lblNCupo.Text = btnC1.Tag Else lblNCupo.Text = "" Else lblNCupo.Text = ""
    End Sub

    Private Sub lblNCupo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblNCupo.TextChanged
        If lblNCupo.Text.Length > 0 Then btnAsignarCupo.Enabled = True Else btnAsignarCupo.Enabled = False : lblNCupo.Text = ""
    End Sub

    Private Sub dgFiltro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFiltro.CellContentClick

    End Sub

    Private Function VerExa() As Boolean
        VerExa = False
        Dim I As Integer
        For I = 0 To dgExamenes.Items.Count - 1
            If dgExamenes.Items(I).SubItems(0).Text = lvFiltro.SelectedItems(0).SubItems(0).Text Then VerExa = True : Exit For
        Next
    End Function

    Private Sub lvFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvFiltro.KeyDown
        If lvFiltro.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            Select Case Filtro
                Case "MEDICAMENTO"
                    If cboTipoAtencion.Text <> "SIS" Then MessageBox.Show("Solo puede digitar Medicamentos a Pacientes SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                    txtMedicamento.Enabled = False
                    txtMedicamento.Tag = lvFiltro.SelectedItems(0).SubItems(0).Text
                    txtMedicamento.Text = lvFiltro.SelectedItems(0).SubItems(1).Text
                    txtMedicamento.Enabled = True
                    lblUnidad.Text = lvFiltro.SelectedItems(0).SubItems(4).Text
                    lblPrecioM.Text = Microsoft.VisualBasic.Format(CDbl(lvFiltro.SelectedItems(0).SubItems(2).Text), "#,##0.00")
                    StockMed = lvFiltro.SelectedItems(0).SubItems(6).Text
                    gbFiltro.Visible = False
                    txtCantidadM.Text = 1
                    txtCantidadM.Select()
                Case "EXAMENES"
                    If VerExa() Then
                        MessageBox.Show("Procedimiento ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    txtExamenes.Enabled = False
                    txtExamenes.Tag = lvFiltro.SelectedItems(0).SubItems(0).Text
                    txtExamenes.Text = lvFiltro.SelectedItems(0).SubItems(1).Text
                    txtExamenes.Enabled = True
                    lblPrecioE.Text = Microsoft.VisualBasic.Format(Val(lvFiltro.SelectedItems(0).SubItems(2).Text), "#0.00")
                    lblTipoP.Text = lvFiltro.SelectedItems(0).SubItems(5).Text
                    lblSTP.Text = lvFiltro.SelectedItems(0).SubItems(6).Text

                    gbFiltro.Visible = False
                    txtCantidadE.Text = 1
                    txtCantidadE.Select()
            End Select
        End If
    End Sub

    Private Sub lvFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvFiltro.SelectedIndexChanged

    End Sub

    Private Sub lvConsultas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConsultas.Click
        If lvConsultas.Items.Count > 0 Then

            txtSignoH.Text = ""
            txtTallaH.Text = ""
            txtPesoH.Text = ""
            txtPulsoH.Text = ""
            txtTemperaturaH.Text = ""
            txtPresionH.Text = ""
            'txtCIEPH.Text = ""
            'txtDesPH.Text = ""
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

            Dim Fila As ListViewItem
            Dim dsDetalle As New Data.DataSet

            If lvConsultas.SelectedItems(0).SubItems(5).Text = "CONSULTA" Then
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


                    'Procedimientos

                    dsDetalle = objConsulta.BuscarExamenes(IdCupo)
                    For I = 0 To dsDetalle.Tables(0).Rows.Count - 1
                        Fila = dgExamenesH.Items.Add(dsDetalle.Tables(0).Rows(I)("IdExamen"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Precio"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Cantidad"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Importe"))
                        lblTotalE.Text = Val(lblTotalE.Text) + Val(dsDetalle.Tables(0).Rows(I)("Importe"))
                    Next

                    'Medicamentos
                    dsDetalle = objConsulta.BuscarMedicamentos(IdCupo)
                    For I = 0 To dsDetalle.Tables(0).Rows.Count - 1
                        Fila = dgMedicamentoH.Items.Add(dsDetalle.Tables(0).Rows(I)("IdMedicamento"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Precio"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Cantidad"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Importe"))
                        lblTotalM.Text = Val(lblTotalM.Text) + Val(dsDetalle.Tables(0).Rows(I)("Importe"))
                    Next
                End If
            ElseIf lvConsultas.SelectedItems(0).SubItems(5).Text = "INTERCONSULTA" Then
                dsConsultaAnt = objInterconsultaE.Buscar(lvConsultas.SelectedItems(0).SubItems(3).Text)
                If dsConsultaAnt.Tables(0).Rows.Count > 0 Then
                    txtSignoH.Text = dsConsultaAnt.Tables(0).Rows(0)("Sintomas")
                    txtTallaH.Text = dsConsultaAnt.Tables(0).Rows(0)("Talla")
                    txtPesoH.Text = dsConsultaAnt.Tables(0).Rows(0)("Peso")
                    txtPulsoH.Text = dsConsultaAnt.Tables(0).Rows(0)("Pulso")
                    txtTemperaturaH.Text = dsConsultaAnt.Tables(0).Rows(0)("Temp")
                    txtPresionH.Text = dsConsultaAnt.Tables(0).Rows(0)("Presion")
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


                    'Procedimientos

                    dsDetalle = objConsulta.BuscarExamenes(IdCupo)
                    For I = 0 To dsDetalle.Tables(0).Rows.Count - 1
                        Fila = dgExamenesH.Items.Add(dsDetalle.Tables(0).Rows(I)("IdExamen"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Precio"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Cantidad"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Importe"))
                        lblTotalE.Text = Val(lblTotalE.Text) + Val(dsDetalle.Tables(0).Rows(I)("Importe"))
                    Next

                    'Medicamentos
                    dsDetalle = objConsulta.BuscarMedicamentos(IdCupo)
                    For I = 0 To dsDetalle.Tables(0).Rows.Count - 1
                        Fila = dgMedicamentoH.Items.Add(dsDetalle.Tables(0).Rows(I)("IdMedicamento"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Precio"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Cantidad"))
                        Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Importe"))
                        lblTotalM.Text = Val(lblTotalM.Text) + Val(dsDetalle.Tables(0).Rows(I)("Importe"))
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub lvConsultas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvConsultas.SelectedIndexChanged

    End Sub

    Private Sub dgExamenes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgExamenes.KeyDown
        If e.KeyCode = Keys.Delete And dgExamenes.Items.Count >= 1 Then
            Dim IdProcedimiento As String
            Dim Importe As String
            IdProcedimiento = dgExamenes.SelectedItems(0).SubItems(0).Text
            Importe = dgExamenes.SelectedItems(0).SubItems(4).Text
            lblTotalE.Text = Microsoft.VisualBasic.Format(Val(lblTotalE.Text) - Val(Importe), "#0.00")
            dgExamenes.Items.RemoveAt(dgExamenes.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub cboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.SelectedIndexChanged
        If IsNumeric(cboDepartamento.SelectedValue) Then
            Dim dsProv As New Data.DataSet
            dsProv = objUbigeo.Provincia(cboDepartamento.SelectedValue)
            cboProvincia.DataSource = dsProv.Tables(0)
            cboProvincia.DisplayMember = "desc_prov"
            cboProvincia.ValueMember = "cod_prov"
            If cboDepartamento.Text = "LA LIBERTAD" Then cboProvincia.Text = "TRUJILLO" Else cboProvincia.Text = ""
        End If
    End Sub

    Private Sub cboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.SelectedIndexChanged

    End Sub

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        If IsNumeric(cboProvincia.SelectedValue) Then
            Dim dsDist As New Data.DataSet
            dsDist = objUbigeo.Distrito(cboDepartamento.SelectedValue, cboProvincia.SelectedValue)
            cboDistrito.DataSource = dsDist.Tables(0)
            cboDistrito.DisplayMember = "desc_dist"
            cboDistrito.ValueMember = "cod_dist"
            If cboProvincia.Text = "TRUJILLO" Then cboDistrito.Text = "TRUJILLO" Else cboDistrito.Text = ""
        End If
    End Sub

    Private Sub dgMedicamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgMedicamento.KeyDown
        If e.KeyCode = Keys.Delete And dgMedicamento.Items.Count >= 1 Then
            Dim IdMedicamento As String
            Dim Importe As String
            IdMedicamento = dgMedicamento.SelectedItems(0).SubItems(0).Text
            Importe = dgMedicamento.SelectedItems(0).SubItems(4).Text
            lblTotalM.Text = Microsoft.VisualBasic.Format(Val(lblTotalM.Text) - Val(Importe), "#0.00")
            dgMedicamento.Items.RemoveAt(dgMedicamento.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub cboServicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.LostFocus
        If cboEstablecimiento.Text = "NUEVO" And cboServicio.Text = "CONTINUADOR" Then MessageBox.Show("Opcion seleccionada no es correcta: NUEVO - CONTINUADO", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboEstablecimiento.Select()
        If cboEstablecimiento.Text = "NUEVO" And cboServicio.Text = "REINGRESANTE" Then MessageBox.Show("Opcion seleccionada no es correcta: NUEVO - REINGRESANTE", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboEstablecimiento.Select()
        If cboEstablecimiento.Text = "REINGRESANTE" And cboServicio.Text = "REINGRESANTE" Then MessageBox.Show("Opcion seleccionada no es correcta: REINGRESANTE - REINGRESANTE", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboEstablecimiento.Select()
    End Sub

    Private Sub txtDes1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDes1.TextChanged
        'If txtDes1.Text.Length > 0 And txtDes1.Enabled And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.End And e.KeyCode <> Keys.Home Then nomFiltro = "DESCIE1" : txtDes.Text = txtDes1.Text : gbConsulta.Visible = True : txtDes.Text = txtDes1.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes1.Text.Length > 1 And txtDes1.Enabled Then nomFiltro = "DESCIE1" : txtDes.Text = txtDes1.Text : gbConsulta.Visible = True : txtDes.Text = txtDes1.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes1.Text.Length = 0 Then txtCIE1.Text = "" : cboTipoDiagnostico.Text = ""
    End Sub

    Private Sub lvDet_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles lvDet.Layout

    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub txtPresion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPresion.TextChanged

    End Sub

    Private Sub txtDes2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes2.TextChanged
        If txtDes2.Text.Length > 1 And txtDes2.Enabled Then nomFiltro = "DESCIE2" : txtDes.Text = txtDes2.Text : gbConsulta.Visible = True : txtDes.Text = txtDes2.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes2.Text.Length = 0 Then txtCIE2.Text = "" : cboTD1.Text = ""
    End Sub

    Private Sub txtDes3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDes3.TextChanged
        If txtDes3.Text.Length > 1 And txtDes3.Enabled Then nomFiltro = "DESCIE3" : txtDes.Text = txtDes3.Text : gbConsulta.Visible = True : txtDes.Text = txtDes3.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes3.Text.Length = 0 Then txtCIE3.Text = "" : cboTD2.Text = ""
    End Sub

    Private Sub txtDes4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDes4.TextChanged
        If txtDes4.Text.Length > 1 And txtDes4.Enabled Then nomFiltro = "DESCIE4" : txtDes.Text = txtDes4.Text : gbConsulta.Visible = True : txtDes.Text = txtDes4.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes4.Text.Length = 0 Then txtCIE4.Text = "" : cboTD3.Text = ""
    End Sub

    Private Sub cboTipoDiagnostico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoDiagnostico.KeyDown
        If cboTipoDiagnostico.Text <> "" And e.KeyCode = Keys.Enter Then txtCIE2.Select()
    End Sub

    Private Sub cboTD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD1.KeyDown
        If cboTD1.Text <> "" And e.KeyCode = Keys.Enter Then txtCIE3.Select()
    End Sub

    Private Sub cboTD1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTD1.KeyPress

    End Sub

    Private Sub cboTD2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD2.KeyDown
        If cboTD2.Text <> "" And e.KeyCode = Keys.Enter Then txtCIE4.Select()
    End Sub

    Private Sub cboTD3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD3.KeyDown
        If cboTD3.Text <> "" And e.KeyCode = Keys.Enter Then txtCIE5.Select()
    End Sub

    Private Sub cboTipoDiagnostico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoDiagnostico.LostFocus
        If txtCIE1.Text <> "" And txtDes1.Text <> "" And cboTipoDiagnostico.Text <> "" Then
            Dim dsDefinitivo As New DataSet
            dsDefinitivo = objConsulta.VerDiagnosticoDef(lblHistoria.Text, txtCIE1.Text)
            If dsDefinitivo.Tables.Count > 0 Then
                If dsDefinitivo.Tables(0).Rows.Count > 0 And CodCupo <> dsDefinitivo.Tables(0).Rows(0)("IdCupo") Then MessageBox.Show("Diagnostico ya fue definido anteriormente como DEFINITIVO, Se definira como REPETITIVO", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoDiagnostico.Text = "REPETITIVO"
            End If
        End If
    End Sub

    Private Sub cboTD1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTD1.LostFocus
        If txtCIE2.Text <> "" And txtDes2.Text <> "" And cboTD1.Text <> "" Then
            Dim dsDefinitivo As New DataSet
            dsDefinitivo = objConsulta.VerDiagnosticoDef(lblHistoria.Text, txtCIE2.Text)
            If dsDefinitivo.Tables.Count > 0 Then
                If dsDefinitivo.Tables(0).Rows.Count > 0 And CodCupo <> dsDefinitivo.Tables(0).Rows(0)("IdCupo") Then MessageBox.Show("Diagnostico ya fue definido anteriormente como DEFINITIVO, Se definira como REPETITIVO", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD1.Text = "REPETITIVO"
            End If
        End If
    End Sub

    Private Sub cboTD2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTD2.LostFocus
        If txtCIE3.Text <> "" And txtDes3.Text <> "" And cboTD2.Text <> "" Then
            Dim dsDefinitivo As New DataSet
            dsDefinitivo = objConsulta.VerDiagnosticoDef(lblHistoria.Text, txtCIE3.Text)
            If dsDefinitivo.Tables.Count > 0 Then
                If dsDefinitivo.Tables(0).Rows.Count > 0 And CodCupo <> dsDefinitivo.Tables(0).Rows(0)("IdCupo") Then MessageBox.Show("Diagnostico ya fue definido anteriormente como DEFINITIVO, Se definira como REPETITIVO", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD2.Text = "REPETITIVO"
            End If
        End If
    End Sub

    Private Sub cboTD3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTD3.LostFocus
        If txtCIE4.Text <> "" And txtDes4.Text <> "" And cboTD3.Text <> "" Then
            Dim dsDefinitivo As New DataSet
            dsDefinitivo = objConsulta.VerDiagnosticoDef(lblHistoria.Text, txtCIE4.Text)
            If dsDefinitivo.Tables.Count > 0 Then
                If dsDefinitivo.Tables(0).Rows.Count > 0 And CodCupo <> dsDefinitivo.Tables(0).Rows(0)("IdCupo") Then MessageBox.Show("Diagnostico ya fue definido anteriormente como DEFINITIVO, Se definira como REPETITIVO", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD3.Text = "REPETITIVO"
            End If
        End If
    End Sub

    Private Sub cboTD5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD5.KeyDown
        If cboTD5.Text <> "" And e.KeyCode = Keys.Enter Then txtEvolucion.Select()
    End Sub

    Private Sub cboTD5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTD5.LostFocus
        If txtCIE6.Text <> "" And txtDes6.Text <> "" Then
            Dim dsDefinitivo As New DataSet
            dsDefinitivo = objConsulta.VerDiagnosticoDef(lblHistoria.Text, txtCIE6.Text)
            If dsDefinitivo.Tables.Count > 0 Then
                If dsDefinitivo.Tables(0).Rows.Count > 0 And CodCupo <> dsDefinitivo.Tables(0).Rows(0)("IdCupo") Then MessageBox.Show("Diagnostico ya fue definido anteriormente como DEFINITIVO, Se definira como REPETITIVO", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD5.Text = "REPETITIVO"
            End If
        End If
    End Sub

    Private Sub cboTD5_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboTD5.MouseWheel

    End Sub

    Private Sub cboTD5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD5.SelectedIndexChanged

    End Sub

    Private Sub cboTD4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD4.KeyDown
        If cboTD4.Text <> "" And e.KeyCode = Keys.Enter Then txtCIE6.Select()
    End Sub

    Private Sub cboTD4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTD4.LostFocus
        If txtCIE5.Text <> "" And txtDes5.Text <> "" Then
            Dim dsDefinitivo As New DataSet
            dsDefinitivo = objConsulta.VerDiagnosticoDef(lblHistoria.Text, txtCIE5.Text)
            If dsDefinitivo.Tables.Count > 0 Then
                If dsDefinitivo.Tables(0).Rows.Count > 0 And CodCupo <> dsDefinitivo.Tables(0).Rows(0)("IdCupo") Then MessageBox.Show("Diagnostico ya fue definido anteriormente como DEFINITIVO, Se definira como REPETITIVO", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD4.Text = "REPETITIVO"
            End If
        End If
    End Sub

    Private Sub txtCIE5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE5.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE5.Text.Length > 0 Then
            If txtCIE4.Text = "" And txtLab4.Text <> "" Then
                MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCIE5.Text = ""
                txtDes5.Text = ""
                txtLab5.Text = ""
                cboTD4.Text = ""
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE5.Text = "86592" Then
                txtDes5.Enabled = False : txtDes5.Text = DevolverDescripcionCIE(txtCIE5.Text, cboTD4) : txtDes5.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab5.Text = "RN"
                Else
                    txtLab5.Text = "RP"
                End If
                txtCIE6.Select()
                Exit Sub
            End If

            'Verificar Control Puerperio 59430
            If txtCIE5.Text = "59430" Then
                txtDes5.Enabled = False : txtDes5.Text = DevolverDescripcionCIE(txtCIE5.Text, cboTD4) : txtDes5.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab5.Text = "1"
                Else
                    txtLab5.Text = "2"
                End If
                txtCIE6.Select()
                Exit Sub
            End If

            'Verificar Cancer de Mama y Cuello Uterino
            If (txtCIE5.Text = "88141" Or txtCIE5.Text = "Z0143" Or txtCIE5.Text = "Z0142" Or txtCIE5.Text = "87621") Then
                MessageBox.Show("No puede ser asignado diagnostico en esta posición segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE5.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE5.Text = txtCIE1.Text Or txtCIE5.Text = txtCIE2.Text Or txtCIE5.Text = txtCIE3.Text Or txtCIE5.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And lblSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And lblSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes5.Enabled = False
                txtDes5.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes5.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD4.Text = "DEFINITIVO" : txtCIE6.Select() Else cboTD4.Select()

                'Validar Morbilidad Definitiva
                If dsTabla.Tables(0).Rows(0)("MorbilidadDefinitiva") = "X" Then
                    Dim I As Integer
                    Dim dsVerMD As New DataSet
                    Dim Existe As Boolean = False
                    For I = 1 To 6
                        dsVerMD = objConsulta.VerDiagnosticoMorDef(lblHistoria.Text, txtCIE5.Text, I)
                        If dsVerMD.Tables(0).Rows.Count > 0 Then
                            Select Case I
                                Case 1
                                    If dsVerMD.Tables(0).Rows(0)("TipoDiagnostico") = "DEFINITIVO" Then cboTD4.Text = "REPETITIVO" : Exit Sub
                                Case 2
                                    If dsVerMD.Tables(0).Rows(0)("TD1") = "DEFINITIVO" Then cboTD4.Text = "REPETITIVO" : Exit Sub
                                Case 3
                                    If dsVerMD.Tables(0).Rows(0)("TD2") = "DEFINITIVO" Then cboTD4.Text = "REPETITIVO" : Exit Sub
                                Case 4
                                    If dsVerMD.Tables(0).Rows(0)("TD3") = "DEFINITIVO" Then cboTD4.Text = "REPETITIVO" : Exit Sub
                                Case 5
                                    If dsVerMD.Tables(0).Rows(0)("TD4") = "DEFINITIVO" Then cboTD4.Text = "REPETITIVO" : Exit Sub
                                Case 6
                                    If dsVerMD.Tables(0).Rows(0)("TD5") = "DEFINITIVO" Then cboTD4.Text = "REPETITIVO" : Exit Sub
                            End Select
                        End If
                    Next
                End If
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCIE6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE6.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE6.Text.Length > 0 Then
            If txtCIE5.Text = "" And txtLab5.Text <> "" Then
                MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCIE6.Text = ""
                txtDes6.Text = ""
                txtLab6.Text = ""
                cboTD5.Text = ""
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE6.Text = "86592" Then
                txtDes6.Enabled = False : txtDes6.Text = DevolverDescripcionCIE(txtCIE6.Text, cboTD5) : txtDes6.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab6.Text = "RN"
                Else
                    txtLab6.Text = "RP"
                End If
                cboTipoAtencion.Select()
                Exit Sub
            End If

            'Verificar Control Puerperio 59430
            If txtCIE6.Text = "59430" Then
                txtDes6.Enabled = False : txtDes6.Text = DevolverDescripcionCIE(txtCIE6.Text, cboTD5) : txtDes6.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab6.Text = "1"
                Else
                    txtLab6.Text = "2"
                End If
                cboTipoAtencion.Select()
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE6.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE6.Text = txtCIE1.Text Or txtCIE6.Text = txtCIE2.Text Or txtCIE6.Text = txtCIE3.Text Or txtCIE6.Text = txtCIE4.Text Or txtCIE6.Text = txtCIE5.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And lblSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And lblSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes6.Enabled = False
                txtDes6.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes6.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD4.Text = "DEFINITIVO" : txtEvolucion.Select() Else cboTD5.Select()

                'Validar Morbilidad Definitiva
                If dsTabla.Tables(0).Rows(0)("MorbilidadDefinitiva") = "X" Then
                    Dim I As Integer
                    Dim dsVerMD As New DataSet
                    Dim Existe As Boolean = False
                    For I = 1 To 6
                        dsVerMD = objConsulta.VerDiagnosticoMorDef(lblHistoria.Text, txtCIE6.Text, I)
                        If dsVerMD.Tables(0).Rows.Count > 0 Then
                            Select Case I
                                Case 1
                                    If dsVerMD.Tables(0).Rows(0)("TipoDiagnostico") = "DEFINITIVO" Then cboTD5.Text = "REPETITIVO" : Exit Sub
                                Case 2
                                    If dsVerMD.Tables(0).Rows(0)("TD1") = "DEFINITIVO" Then cboTD5.Text = "REPETITIVO" : Exit Sub
                                Case 3
                                    If dsVerMD.Tables(0).Rows(0)("TD2") = "DEFINITIVO" Then cboTD5.Text = "REPETITIVO" : Exit Sub
                                Case 4
                                    If dsVerMD.Tables(0).Rows(0)("TD3") = "DEFINITIVO" Then cboTD5.Text = "REPETITIVO" : Exit Sub
                                Case 5
                                    If dsVerMD.Tables(0).Rows(0)("TD4") = "DEFINITIVO" Then cboTD5.Text = "REPETITIVO" : Exit Sub
                                Case 6
                                    If dsVerMD.Tables(0).Rows(0)("TD5") = "DEFINITIVO" Then cboTD5.Text = "REPETITIVO" : Exit Sub
                            End Select
                        End If
                    Next
                End If
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCIE6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE6.TextChanged

    End Sub

    Private Sub txtDes5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes5.TextChanged
        If txtDes5.Text.Length > 1 And txtDes5.Enabled Then nomFiltro = "DESCIE5" : txtDes.Text = txtDes5.Text : gbConsulta.Visible = True : txtDes.Text = txtDes5.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes5.Text.Length = 0 Then txtCIE5.Text = "" : cboTD4.Text = ""
    End Sub

    Private Sub txtDes6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes6.TextChanged
        If txtDes6.Text.Length > 1 And txtDes6.Enabled Then nomFiltro = "DESCIE6" : txtDes.Text = txtDes6.Text : gbConsulta.Visible = True : txtDes.Text = txtDes6.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes6.Text.Length = 0 Then txtCIE6.Text = "" : cboTD5.Text = ""
    End Sub

    Private Sub txtCantidadE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadE.TextChanged

    End Sub

    Private Sub Panel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel.MouseDown
        bandera = 1
        X1 = 0
        X2 = 0
        Y1 = 0
        Y2 = 0
        C = 0
    End Sub

    Private Sub Panel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel.MouseMove
        If inicio = 1 Then
            X1 = e.X
            Y1 = e.Y
            If bandera = 1 Then
                y = y + 1
                If y = 1 Then
                    If C = 1 Then
                        Dim J = Panel.CreateGraphics
                        J.DrawLine(H, X1, Y1, X2, Y2)
                    End If
                End If
                If y = 1 Then
                    X2 = X1
                    Y2 = Y1
                    C = 1
                    y = 0
                End If
            End If
        End If
    End Sub

    Private Sub Panel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel.MouseUp
        bandera = 0
    End Sub

    Private Sub Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel.Paint

    End Sub

    Private Sub cboColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColor.SelectedIndexChanged
        Select Case cboColor.Text
            Case "Negro"
                W = Color.Black
                H = New Pen(W, CInt(cboTamaño.Text))
            Case "Morado"
                W = Color.Violet
                H = New Pen(W, CInt(Me.cboTamaño.Text))
            Case "Azul"
                W = Color.Blue
                H = New Pen(W, CInt(Me.cboTamaño.Text))
            Case "Verde"
                W = Color.Green
                H = New Pen(W, CInt(Me.cboTamaño.Text))
            Case "Rojo"
                W = Color.Red
                H = New Pen(W, CInt(Me.cboTamaño.Text))
            Case "Naranja"
                W = Color.Orange
                H = New Pen(W, CInt(Me.cboTamaño.Text))
            Case "Amarillo"
                W = Color.Yellow
                H = New Pen(W, CInt(Me.cboTamaño.Text))
            Case "Marron"
                W = Color.Maroon
                H = New Pen(W, CInt(Me.cboTamaño.Text))
        End Select
    End Sub

    Private Sub cboTamaño_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTamaño.SelectedIndexChanged
        H = New Pen(W, CInt(Me.cboTamaño.Text))
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Panel.Refresh()
    End Sub

    Private Sub txtNumeroSis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroSis.LostFocus
        If Val(txtNumeroSis.Text) > 0 Then
            Dim dsVer As New DataSet
            dsVer = objSIS.ConsultarLN(txtSerieSis.Text, txtNumeroSis.Text, lblHistoria.Text)
            If dsVer.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Debe verificar que este bien escrito la SERIE y NUMERO de lote SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSis.Text = "" : txtNumeroSis.Text = 0 : Exit Sub
            End If

            If dsVer.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                If dsVer.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
            If dsVer.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        End If
    End Sub

    Private Sub txtNumeroSis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroSis.TextChanged

    End Sub

    Private Sub txtNroPre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroPre.KeyDown
        If e.KeyCode = Keys.Enter Then txtSerieSis.Select()
    End Sub

    Private Sub txtNroPre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroPre.TextChanged

    End Sub

    Private Sub txtSerieSis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerieSis.KeyDown
        If e.KeyCode = Keys.Enter Then txtNumeroSis.Select()
    End Sub

    Private Sub txtSerieSis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerieSis.TextChanged

    End Sub

    Private Sub txtCantidadM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadM.TextChanged

    End Sub

    Private Sub cboDosis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDosis.KeyDown
        If txtCantidadM.Text.Length > 0 And txtMedicamento.Text.Length > 0 And e.KeyCode = Keys.Enter And IsNumeric(cboDosis.SelectedValue) Then
            If cboTipoAtencion.Text = "SIS" And Val(txtNumeroSis.Text) = 0 Then MessageBox.Show("Paciente es SIS y no se ha ingresado el Numero de Formato, verifique esta información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSis.Select() : Exit Sub
            Dim Fila As New ListViewItem
            Dim Importe As String
            Fila = dgMedicamento.Items.Add(txtMedicamento.Tag)
            Fila.SubItems.Add(txtMedicamento.Text)
            Fila.SubItems.Add(lblPrecioM.Text)
            Fila.SubItems.Add(txtCantidadM.Text)
            Importe = Microsoft.VisualBasic.Format(CDbl(lblPrecioM.Text) * CDbl(txtCantidadM.Text), "#,##0.00")
            lblTotalM.Text = Microsoft.VisualBasic.Format(Val(lblTotalM.Text) + Val(Importe), "#,##0.00")
            Fila.SubItems.Add(Importe)
            Fila.SubItems.Add(cboDosis.Text)
            Fila.SubItems.Add(lblUnidad.Text)
            txtCantidadM.Text = ""
            lblPrecioM.Text = ""
            txtMedicamento.Text = ""
            lblUnidad.Text = ""
            txtMedicamento.Select()
        End If
    End Sub

    Private Sub txtNota_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIndicacion.KeyDown
        If txtCantidadE.Text.Length > 0 And txtExamenes.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            If cboTipoAtencion.Text = "SIS" And Val(txtNumeroSis.Text) = 0 Then MessageBox.Show("Paciente es SIS y no se ha ingresado el Numero de Formato, verifique esta información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSis.Select() : Exit Sub
            If cboTipoAtencion.Text = "SOAT" And Val(txtNroPre.Text) = 0 Then MessageBox.Show("Paciente es SOAT y no se ha ingresado el Numero de Preliquidación, verifique esta información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub
            If Microsoft.VisualBasic.Left(cboTipoAtencion.Text, 7) = "SANIDAD" And Val(txtNroPre.Text) = 0 Then MessageBox.Show("Paciente es Convenio y no se ha ingresado el Numero de Preliquidación, verifique esta información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub

            If txtIndicacion.Text.Length = 0 And lblTipoP.Text = "RAYOS" Then MessageBox.Show("Para este tipo de exámen, debe ingresar una indicación que oriente al especialista.", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtIndicacion.Select() : Exit Sub
            If txtIndicacion.Text.Length = 0 And lblSTP.Text = "ECOGRAFIA" Then MessageBox.Show("Para este tipo de exámen, debe ingresar una indicación que oriente al especialista.", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtIndicacion.Select() : Exit Sub

            Dim Fila As New ListViewItem
            Dim Importe As String
            Fila = dgExamenes.Items.Add(txtExamenes.Tag)
            Fila.SubItems.Add(txtExamenes.Text)
            Fila.SubItems.Add(lblPrecioE.Text)
            Fila.SubItems.Add(txtCantidadE.Text)
            Importe = Microsoft.VisualBasic.Format(Val(lblPrecioE.Text) * Val(txtCantidadE.Text), "#0.00")
            lblTotalE.Text = Microsoft.VisualBasic.Format(Val(lblTotalE.Text) + Val(Importe), "#0.00")
            Fila.SubItems.Add(Importe)
            Fila.SubItems.Add(lblTipoP.Text)
            Fila.SubItems.Add(lblSTP.Text)
            Fila.SubItems.Add(txtIndicacion.Text)

            'Informar de Examenes de CERIT
            If txtExamenes.Text = "ANTICORE TOTAL" Or txtExamenes.Text = "HEPATITIS C (ANTICUERPO)" Or txtExamenes.Text = "HTVL1" Or txtExamenes.Text = "RPR" Or txtExamenes.Text = "ANTICORE TOTAL" Or txtExamenes.Text = "HIV POR ELISA" Then
                MessageBox.Show("Exámen requiere Consejería de CERITS. Por favor Informe al Paciente", "MENSAJE IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            txtCantidadE.Text = ""
            lblPrecioE.Text = ""
            txtExamenes.Text = ""
            lblTipoP.Text = ""
            lblSTP.Text = ""
            txtIndicacion.Text = ""


            txtExamenes.Select()
        End If
    End Sub

    Private Sub bntIncor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntIncor.Click
        If MessageBox.Show("Esta seguro de Registrar a Paciente como Candidato de Incor", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objCandidato.Grabar(Date.Now.ToShortDateString, Date.Now.ToShortTimeString, vMedico, My.Computer.Name, lblHistoria.Text, lblPaciente.Text)
            MessageBox.Show("Paciente Registrado Satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub lvListaI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvListaI.SelectedIndexChanged
        If lvListaI.SelectedItems.Count > 0 Then
            Dim dsP As New DataSet
            dsP = objPatologia.ConsultaId(lvListaI.SelectedItems(0).SubItems(0).Text)
            lblFechaEntrga.Text = dsP.Tables(0).Rows(0)("FEntrega")
            lblTipo.Text = dsP.Tables(0).Rows(0)("TipoPaciente")
            lblProcedencia.Text = dsP.Tables(0).Rows(0)("Procedencia")
            lblServicio.Text = dsP.Tables(0).Rows(0)("Servicio")
            lblMedico.Text = dsP.Tables(0).Rows(0)("Medico")
            lblDiagnostico.Text = dsP.Tables(0).Rows(0)("Diagnostico")
            lblNombre.Text = dsP.Tables(0).Rows(0)("Nombre")
            lblOrgano.Text = dsP.Tables(0).Rows(0)("Organo")
            lblTipoMuestra.Text = dsP.Tables(0).Rows(0)("Muestra")
            txtCuerpo.Rtf = dsP.Tables(0).Rows(0)("Cuerpo")
            txtCuerpo.Tag = dsP.Tables(0).Rows(0)("Cuerpo1")
        Else
            lblFechaEntrga.Text = ""
            lblTipo.Text = ""
            lblProcedencia.Text = ""
            lblServicio.Text = ""
            lblMedico.Text = ""
            lblDiagnostico.Text = ""
            lblNombre.Text = ""
            lblOrgano.Text = ""
            lblTipoMuestra.Text = ""
            txtCuerpo.Rtf = ""
            txtCuerpo.Text = ""
        End If
    End Sub

    Private Sub lvH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvH.SelectedIndexChanged
        If lvH.SelectedItems.Count > 0 Then
            ControlesAD(Me, True)
            lblFechaEKG.Text = lvH.SelectedItems(0).SubItems(1).Text
            lblOrigen.Text = lvH.SelectedItems(0).SubItems(2).Text
            lblSexo.Text = lvH.SelectedItems(0).SubItems(5).Text
            lbledad.Text = lvH.SelectedItems(0).SubItems(6).Text
            lblTipoDx.Text = lvH.SelectedItems(0).SubItems(7).Text
            txtConclusiones.Text = lvH.SelectedItems(0).SubItems(8).Text
            lblCardiologo.Text = lvH.SelectedItems(0).SubItems(9).Text
            lblSolicitado.Text = lvH.SelectedItems(0).SubItems(10).Text
            lblExamen.Text = lvH.SelectedItems(0).SubItems(11).Text

            lvTabla.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim dsCie As New DataSet
            dsCie = objEKGCie.Buscar(lvH.SelectedItems(0).SubItems(0).Text)
            For I = 0 To dsCie.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsCie.Tables(0).Rows(I)("Cie"))
                Fila.SubItems.Add(dsCie.Tables(0).Rows(I)("Descripcion"))
            Next
        Else
            lblFechaEKG.Text = ""
            lblOrigen.Text = ""
            lblSexo.Text = ""
            lbledad.Text = ""
            lblTipoDx.Text = ""
            txtConclusiones.Text = ""
            lblCardiologo.Text = ""
            lblSolicitado.Text = ""
            lblExamen.Text = ""
            lvTabla.Items.Clear()
        End If
    End Sub

    Private Sub lvEmergencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvEmergencia.SelectedIndexChanged
        If lvEmergencia.SelectedItems.Count > 0 Then
            Dim dsVer As New DataSet
            dsVer = objEmergenciaIngreso.BuscarCodigo(lvEmergencia.SelectedItems(0).SubItems(0).Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                lblServicioEmer.Text = dsVer.Tables(0).Rows(0)("Especialidad")
                lblMedicoIng.Text = dsVer.Tables(0).Rows(0)("Medico")
                lblTipoAtencionEmer.Text = dsVer.Tables(0).Rows(0)("TipoAtencion").ToString

                Dim dsConsulta As New DataSet
                dsConsulta = objEmergenciaIngreso.ConsultaBuscar(lvEmergencia.SelectedItems(0).SubItems(0).Text)
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    lblFechaIngE.Text = dsConsulta.Tables(0).Rows(0)("Fecha")
                    lblHoraIngE.Text = dsConsulta.Tables(0).Rows(0)("Hora")
                    txtEnfermedadAct.Text = dsConsulta.Tables(0).Rows(0)("EnfermedadActual")
                    txtMolestia.Text = dsConsulta.Tables(0).Rows(0)("MolestiaPrincipal")
                    txtCie1IE.Text = dsConsulta.Tables(0).Rows(0)("Cie1")
                    txtDes1IE.Text = dsConsulta.Tables(0).Rows(0)("DesCie1")
                    txtTD1IE.Text = dsConsulta.Tables(0).Rows(0)("TD1")
                    txtCie2IE.Text = dsConsulta.Tables(0).Rows(0)("Cie2")
                    txtDes2IE.Text = dsConsulta.Tables(0).Rows(0)("DesCie2")
                    txtTD2IE.Text = dsConsulta.Tables(0).Rows(0)("TD2")
                    txtCie3IE.Text = dsConsulta.Tables(0).Rows(0)("Cie3")
                    txtDes3IE.Text = dsConsulta.Tables(0).Rows(0)("DesCie3")
                    txtTD3IE.Text = dsConsulta.Tables(0).Rows(0)("TD3")
                    txtCie4IE.Text = dsConsulta.Tables(0).Rows(0)("Cie4")
                    txtDes4IE.Text = dsConsulta.Tables(0).Rows(0)("DesCie4")
                    txtTD4IE.Text = dsConsulta.Tables(0).Rows(0)("TD4")
                    txtCie5IE.Text = dsConsulta.Tables(0).Rows(0)("Cie5")
                    txtDes5IE.Text = dsConsulta.Tables(0).Rows(0)("DesCie5")
                    txtTD5IE.Text = dsConsulta.Tables(0).Rows(0)("TD5")
                    txtCie6IE.Text = dsConsulta.Tables(0).Rows(0)("Cie6")
                    txtDes6IE.Text = dsConsulta.Tables(0).Rows(0)("DesCie6")
                    txtTD6IE.Text = dsConsulta.Tables(0).Rows(0)("TD6")
                End If

                'Alta de Paciente
                Dim dsAlta As New DataSet
                dsAlta = objAltaEmergencia.BuscarAlta(lvEmergencia.SelectedItems(0).SubItems(0).Text)
                If dsAlta.Tables(0).Rows.Count > 0 Then
                    lblFechaAltaEme.Text = dsAlta.Tables(0).Rows(0)("Fecha")
                    lblHoraAltaEme.Text = dsAlta.Tables(0).Rows(0)("Hora")
                    lblCondicionAltaEme.Text = dsAlta.Tables(0).Rows(0)("CondicionAlta")
                    lblMedicoAltaEme.Text = dsAlta.Tables(0).Rows(0)("Medico")
                    lblTipoAltaEme.Text = dsAlta.Tables(0).Rows(0)("TipoAlta")
                    lblDestinoAltaEme.Text = dsAlta.Tables(0).Rows(0)("Destino")
                    lblDescDestinoEme.Text = dsAlta.Tables(0).Rows(0)("DesDestino")

                    txtCie1AE.Text = dsAlta.Tables(0).Rows(0)("Cie1")
                    txtDes1AE.Text = dsAlta.Tables(0).Rows(0)("DesCie1")
                    txtTD1AE.Text = dsAlta.Tables(0).Rows(0)("TD1")
                    txtCie2AE.Text = dsAlta.Tables(0).Rows(0)("Cie2")
                    txtDes2AE.Text = dsAlta.Tables(0).Rows(0)("DesCie2")
                    txtTD2AE.Text = dsAlta.Tables(0).Rows(0)("TD2")
                    txtCie3AE.Text = dsAlta.Tables(0).Rows(0)("Cie3")
                    txtDes3AE.Text = dsAlta.Tables(0).Rows(0)("DesCie3")
                    txtTD3AE.Text = dsAlta.Tables(0).Rows(0)("TD3")
                    txtCie4AE.Text = dsAlta.Tables(0).Rows(0)("Cie4")
                    txtDes4AE.Text = dsAlta.Tables(0).Rows(0)("DesCie4")
                    txtTD4AE.Text = dsAlta.Tables(0).Rows(0)("TD4")
                    txtCie5AE.Text = dsAlta.Tables(0).Rows(0)("Cie5")
                    txtDes5AE.Text = dsAlta.Tables(0).Rows(0)("DesCie5")
                    txtTD5AE.Text = dsAlta.Tables(0).Rows(0)("TD5")
                    txtCie6AE.Text = dsAlta.Tables(0).Rows(0)("Cie6")
                    txtDes6AE.Text = dsAlta.Tables(0).Rows(0)("DesCie6")
                    txtTD6AE.Text = dsAlta.Tables(0).Rows(0)("TD6")
                End If
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnRetornar01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar01.Click
        txtRes1.Text = ""
        gbLabCE.Visible = False
    End Sub

    Private Sub lvHistorialCE_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvHistorialCE.DoubleClick
        If lvHistorialCE.SelectedItems.Count > 0 Then
            lblPro1.Text = lvHistorialCE.SelectedItems(0).SubItems(5).Text
            txtRes1.Text = lvHistorialCE.SelectedItems(0).SubItems(6).Text

            'Buscar Valor Referencia
            If lvHistorialCE.SelectedItems(0).SubItems(4).Text <> "SOAT" Then
                Dim dsVer As New DataSet
                dsVer = objServicioItem.BuscarId(lvHistorialCE.SelectedItems(0).SubItems(10).Text)
                If dsVer.Tables(0).Rows.Count > 0 Then
                    Dim IdItem As String = dsVer.Tables(0).Rows(0)("IdItem")
                    dsVer = objItemServicio.BuscarIdItem(IdItem)
                    If dsVer.Tables(0).Rows.Count > 0 Then
                        txtVR1.Text = dsVer.Tables(0).Rows(0)("Parametros").ToString
                    Else
                        txtVR1.Text = ""
                    End If
                Else
                    txtVR1.Text = ""
                End If
            Else
                txtVR1.Text = ""
            End If

            gbLabCE.Visible = True
        End If
    End Sub

    Private Sub lvHistorialCE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvHistorialCE.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar02.Click
        txtRes2.Text = ""
        gbLabE.Visible = False
    End Sub

    Private Sub lvHistorialE_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvHistorialE.DoubleClick
        If lvHistorialE.SelectedItems.Count > 0 Then
            lblPro2.Text = lvHistorialE.SelectedItems(0).SubItems(5).Text
            txtRes2.Text = lvHistorialE.SelectedItems(0).SubItems(6).Text

            'Buscar Valor Referencia
            If lvHistorialE.SelectedItems(0).SubItems(4).Text <> "SOAT" Then
                Dim dsVer As New DataSet
                dsVer = objServicioItem.BuscarId(lvHistorialE.SelectedItems(0).SubItems(10).Text)
                If dsVer.Tables(0).Rows.Count > 0 Then
                    Dim IdItem As String = dsVer.Tables(0).Rows(0)("IdItem")
                    dsVer = objItemServicio.BuscarIdItem(IdItem)
                    If dsVer.Tables(0).Rows.Count > 0 Then
                        txtVR2.Text = dsVer.Tables(0).Rows(0)("Parametros").ToString
                    Else
                        txtVR2.Text = ""
                    End If
                Else
                    txtVR2.Text = ""
                End If
            Else
                txtVR2.Text = ""
            End If

            gbLabE.Visible = True
        End If
    End Sub

    Private Sub lvHistorialE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvHistorialE.KeyDown

    End Sub

    Private Sub btnRetornar03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar03.Click
        txtRes3.Text = ""
        gbLabH.Visible = False
    End Sub

    Private Sub lvHistorialE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvHistorialE.SelectedIndexChanged

    End Sub

    Private Sub lvHistorialH_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvHistorialH.DoubleClick
        If lvHistorialH.SelectedItems.Count > 0 Then
            lblPro3.Text = lvHistorialH.SelectedItems(0).SubItems(5).Text
            txtRes3.Text = lvHistorialH.SelectedItems(0).SubItems(6).Text
            gbLabH.Visible = True
        End If
    End Sub

    Private Sub lvEsp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEsp.DoubleClick
        If lvEsp.SelectedItems.Count > 0 Then
            Dim dsVer As New DataSet
            dsVer = objDeposito.BuscarId(lvEsp.SelectedItems(0).SubItems(0).Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                Dim bw As System.IO.BinaryWriter
                Dim myread As SqlClient.SqlDataReader
                Try
                    myread = objDeposito.BuscarImagenReader(lvEsp.SelectedItems(0).SubItems(0).Text)
                    myread.Read()

                    If myread.HasRows Then
                        Dim filedata(myread.GetBytes(0, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                        myread.GetBytes(0, 0, filedata, 0, filedata.Length)
                        Dim myext As String = "pdf"
                        'Select Case myread(4)
                        '    Case "PDF"
                        '        myext = "pdf"
                        '    Case "WORD 2000-2003"
                        '        myext = "doc"
                        '    Case "WORD 2007-"
                        '        myext = "docx"
                        '    Case "JPG"
                        '        myext = "jpg"
                        '    Case "AVI"
                        '        myext = "avi"
                        '    Case Else
                        '        myext = "PDF"
                        'End Select
                        Dim ExtensionNombre As String = Application.StartupPath() & "\mydocumento." & myext
                        Dim fs As System.IO.FileStream = New System.IO.FileStream(ExtensionNombre, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                        bw = New System.IO.BinaryWriter(fs)
                        bw.Write(filedata)
                        bw.Flush()
                        bw.Close()
                        fs.Close()
                        myread.Close()

                        'Abrir Documento
                        Dim Command As New Process
                        Command.StartInfo.FileName = ExtensionNombre
                        Command.StartInfo.UseShellExecute = True '''importantisimo esta propiedad permite buscar en el path del windows el programa asociado para ejecutar el archivo segun su tipo
                        'Para redirigir la salida de este proceso esta propiedad debe ser false
                        Command.StartInfo.CreateNoWindow = True
                        Command.Start()
                    End If
                Catch Exp As Exception
                    MessageBox.Show(Exp.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    myread.Close()
                End Try
            End If
        End If
    End Sub


    Private Sub lvElectroence_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvElectroence.SelectedIndexChanged
        txtInfElect.Text = ""
        If lvElectroence.SelectedItems.Count > 0 Then
            Dim dsVer As New DataSet
            dsVer = objElectroencefalograma.BuscarId(lvElectroence.SelectedItems(0).SubItems(0).Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                txtInfElect.Rtf = dsVer.Tables(0).Rows(0)("Informe")
            End If
        End If
    End Sub

    Private Sub txtIndicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIndicacion.TextChanged

    End Sub

    Private Sub txtLab3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLab3.LostFocus
        If (txtLab2.Text = "MA" Or txtLab2.Text = "CU") And (txtLab3.Text = "G") Then
            MessageBox.Show("Debe registrar en el Primer DX Z359 definitivo y en el Segundo DX la Consejeria", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLab2.Text = ""
            txtLab3.Text = ""
            txtCIE1.Text = "Z359"
            txtDes1.Text = ""
            txtLab1.Text = ""
            cboTD1.Text = ""
            txtCIE1.Select()
        End If
        If txtCIE2.Text = "" And txtLab2.Text <> "" Then
            MessageBox.Show("No se puede llenar un Segundo LAB sin Diagnostico", "Mensaje Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLab3.Text = ""
        End If
    End Sub

    Private Sub txtLab3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab3.TextChanged

    End Sub

    Private Sub txtCIE1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE1.TextChanged

    End Sub


    Private Sub dgExamenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgExamenes.SelectedIndexChanged

    End Sub

    Private Sub txtLab1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab1.TextChanged

    End Sub

    Private Sub txtLab4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab4.KeyDown

    End Sub

    Private Sub txtLab4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLab4.LostFocus
        If txtCIE3.Text = "" And txtLab3.Text <> "" Then
            MessageBox.Show("No se puede llenar un Segundo LAB sin Diagnostico", "Mensaje Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLab4.Text = ""
        End If

    End Sub

    Private Sub txtLab4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab4.TextChanged

    End Sub

    Private Sub txtLab5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab5.KeyDown

    End Sub

    Private Sub txtLab5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLab5.LostFocus
        If txtCIE4.Text = "" And txtLab4.Text <> "" Then
            MessageBox.Show("No se puede llenar un Segundo LAB sin Diagnostico", "Mensaje Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLab5.Text = ""
        End If
    End Sub

    Private Sub txtLab5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab5.TextChanged

    End Sub

    Private Sub txtLab6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab6.KeyDown

    End Sub

    Private Sub txtLab6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLab6.LostFocus
        If txtCIE5.Text = "" And txtLab5.Text <> "" Then
            MessageBox.Show("No se puede llenar un Segundo LAB sin Diagnostico", "Mensaje Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLab6.Text = ""
        End If
    End Sub

    Private Sub txtLab6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab6.TextChanged

    End Sub

    Private Sub txtLab2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab2.TextChanged

    End Sub

    Private Sub cboDosis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDosis.SelectedIndexChanged

    End Sub

    Private Sub dgMedicamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgMedicamento.SelectedIndexChanged

    End Sub

    Private Sub lblHistoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHistoria.Click

    End Sub
    Private flagHemodialisis As Boolean
    Private Sub btnHemodialisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHemodialisis.Click
        flagHemodialisis = True
        Me.FORMU()

    End Sub

    Private Sub btnTomografia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTomografia.Click
        flagHemodialisis = False
        Me.FORMU()
    End Sub
    Private i As Integer
    Private Sub FORMU()

        frmInfromeMedicoTH.lblHistoria.Text = Me.lblHistoria.Text
        frmInfromeMedicoTH.lblPaciente.Text = Me.lblPaciente.Text
        frmInfromeMedicoTH.txtSintomas.Text = Me.txtSintomas.Text
        frmInfromeMedicoTH.txtCieI1.Text = Me.txtCIE1.Text
        frmInfromeMedicoTH.txtCieI2.Text = Me.txtCIE2.Text
        frmInfromeMedicoTH.txtCieI3.Text = Me.txtCIE3.Text
        frmInfromeMedicoTH.txtCieI4.Text = Me.txtCIE4.Text

        frmInfromeMedicoTH.txtCieA1.Text = Me.txtCIE1.Text
        frmInfromeMedicoTH.txtCieA2.Text = Me.txtCIE2.Text
        frmInfromeMedicoTH.txtCieA3.Text = Me.txtCIE3.Text
        frmInfromeMedicoTH.txtCieA4.Text = Me.txtCIE4.Text

        If (Me.lvHistorialCE.Items.Count > 0) Then
            frmInfromeMedicoTH.txtProcedimiento.Text += Me.Label162.Text & vbCrLf
            frmInfromeMedicoTH.txtProcedimiento.Text += "---------------------------" & vbCrLf

            For i = 0 To lvHistorialCE.Items.Count - 1
                frmInfromeMedicoTH.txtProcedimiento.Text += lvHistorialCE.Items(i).SubItems(5).Text
                frmInfromeMedicoTH.txtProcedimiento.Text += lvHistorialCE.Items(i).SubItems(6).Text
                frmInfromeMedicoTH.txtProcedimiento.Text += vbCrLf
            Next
        End If
        If (Me.lvHistorialE.Items.Count > 0) Then
            frmInfromeMedicoTH.txtProcedimiento.Text += Me.Label163.Text & vbCrLf
            frmInfromeMedicoTH.txtProcedimiento.Text += "---------------------------" & vbCrLf

            For i = 0 To lvHistorialE.Items.Count - 1
                frmInfromeMedicoTH.txtProcedimiento.Text += lvHistorialE.Items(i).SubItems(5).Text
                frmInfromeMedicoTH.txtProcedimiento.Text += lvHistorialE.Items(i).SubItems(6).Text
                frmInfromeMedicoTH.txtProcedimiento.Text += vbCrLf
            Next
        End If

        If (Me.lvHistorialH.Items.Count > 0) Then
            frmInfromeMedicoTH.txtProcedimiento.Text += Me.Label164.Text & vbCrLf
            frmInfromeMedicoTH.txtProcedimiento.Text += "---------------------------" & vbCrLf

            For i = 0 To lvHistorialH.Items.Count - 1
                frmInfromeMedicoTH.txtProcedimiento.Text += lvHistorialH.Items(i).SubItems(5).Text
                frmInfromeMedicoTH.txtProcedimiento.Text += lvHistorialH.Items(i).SubItems(6).Text
                frmInfromeMedicoTH.txtProcedimiento.Text += vbCrLf
            Next
        End If

        Dim ds As New DataSet
        For i = 1 To lvListaI.Items.Count - 1
            ds = objPatologia.ConsultaId(lvListaI.Items(i).SubItems(0).Text)
            frmInfromeMedicoTH.txtAnatomia.Text += ds.Tables(0).Rows(0)("Muestra") + " - " + ds.Tables(0).Rows(0)("Organo")
            frmInfromeMedicoTH.txtAnatomia.Text += vbCrLf
        Next



        If Me.flagHemodialisis = False Then
            frmInfromeMedicoTH.tbDatos.TabPages(3).Enabled = False
        Else
            frmInfromeMedicoTH.tbDatos.TabPages(3).Enabled = True
        End If


        ds.Dispose()
        frmInfromeMedicoTH.Show()

    End Sub

End Class