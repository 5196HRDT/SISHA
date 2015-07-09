Public Class frmResultadoCentral
    Dim objConsulta As New clsConsultaExterna
    Dim objControlAnulacion As New clsControlAnulacionResLab
    Dim objHistoria As New clsHistoria
    Dim objServicio As New Servicio
    Dim objServicioItem As New clsServicioItem
    Dim objItemServicio As New clsItemServicio

    'Variables Impresion
    Dim Fuente20N As New Font("Courier New", 20, FontStyle.Bold)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente10 As New Font("Courier New", 10)
    Dim Fuente8 As New Font("Courier New", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim TotalFilas As Integer
    Dim NroFila As Integer
    Dim Y As Integer
    Dim NumeroHistoria As String
    Dim Impresion As Integer

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPacienteH.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")
            lblFechaNac.Text = dsHistorias.Tables(0).Rows(0)("FNacimiento").ToString
            lblSexo.Text = dsHistorias.Tables(0).Rows(0)("Sexo")
        Else
            MessageBox.Show("Paciente no se encuentra registrado en el Sistema", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmResultadoCentral_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
        gbPaciente.Visible = False
        gbModificar.Visible = False

        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Buscar("", 1)
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"
    End Sub

    Private Sub cboServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboServicio.SelectedValue) Then txtPaciente.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServicio.SelectedIndexChanged

    End Sub

    Private Sub txtPacienteAten_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPacienteAten.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF1.Select()
    End Sub

    Private Sub txtPacienteAten_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPacienteAten.TextChanged

    End Sub

    Private Sub dtpF1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Sub dtpF1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF1.ValueChanged

    End Sub

    Private Sub dtpF2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then btnBuscar.Select()
    End Sub

    Private Sub dtpF2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF2.ValueChanged

    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        lvTabla.Items.Clear()
        Dim dsConsulta As New DataSet
        Dim dsVer As New DataSet
        If chkConvenio.Checked = True Then

        Else
            dsVer = objConsulta.BuscarExaResultados(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, cboServicio.Text, txtPacienteAten.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
                'Agregar Diagnosticos
                If dsVer.Tables(0).Rows(I)("IdCupo") > 0 Then
                    dsConsulta = objConsulta.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                    If dsConsulta.Tables(0).Rows.Count > 0 Then
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des1"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des2"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des3"))
                    End If
                Else
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
            Next
        End If
        
        MessageBox.Show("Datos encontrados hasta el momento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            txtResultado.Select()
        End If
    End Sub

    Private Sub ValorPrevio()
        'BIOQUIMICA
        txtResultado.Text = ""
        Select Case lblProcedimiento.Text
            Case "COLESTEROL ENCIMáTICO"
                txtResultado.Text = "  mg/dl"
            Case "BILIRRUBINA TOTAL Y FRACCIONADA"
                txtResultado.Text = "BT    mg/dl  BD    mg/dl  BI    mg/dl"
            Case "TOLERANCIA DE GLUCOSA (3 MUESTRAS)"
                txtResultado.Text = "60'   mg/dl  120'    mg/dl  180'    mg/dl"
            Case "BILIRRUBINA POR MICROMETODO", "GLUCOSA BASAL (GLICEMIA)", "GLUCOSA POST-PRANDIAL", "UREA", "CREATININA", "ACIDO URICO", "HDL COLESTEROL", "TRIGLICERIDOS", "VLDL"
                txtResultado.Text = "    mg/dl"
            Case "TRANSAMINASA (G O T)", "TRANSAMINASA (G P T)", "FOSFATASA ALCALINA", "GLUTAMIL TRANSFERASA", "AMILASA SéRICA O EN ORINA", "LDH", "IZO ENZIMA MB PARA MIOCARDIO (CKMB)"
                txtResultado.Text = "    U/L"
            Case "PROTEINAS TOTAL Y FRACCIONADA", "PROTEINAS EN ORINA  24 HORAS", "ALBUMINA SERICA - ALBUMINA LIQUIDA"
                txtResultado.Text = "    gr/dl"
            Case "ANALISIS DE GASES - ELECTROLITOS (UCI) SERICOS", "ELECTROLITOS-GASES-METABOLITOS-OSMOLARIDAD"
                txtResultado.Text = "    mmol"
            Case "DOSAJE DE LIPASSA"
                txtResultado.Text = "    UI/L"
            Case "PERFIL LIPIDICO", "PERFIL LIPíDICO", "PERFIL LIPÍDICO"
                txtResultado.Text = "COLEST:     LIP.T:     TRIGL:     HDL.COL:     LDL.COL:     VLDL:   mg/dl"
            Case "ORINA COMPLETA"
                txtResultado.Text = "DENSIDAD:     P.H:     CARB:     PROTEINAS:    SALES B:     SEDIMENTACION:     C.EPITELIALES:     LEUCOCITOS:      HEMATIES:     CRISTALES:"
            Case "EXAMEN DIRECTO DE HONGOS"
                txtResultado.Text = "EXAMEN DIRECTO: KOH(  ) AZUL DE LACTOFENOL(  )  GRAM(  ) Resultado:    Cultivo:(  )  Resultado:"
            Case "EXAMEN DIRECTO (GRAM)"
                txtResultado.Text = "(A)NO SE OBS. GERMENES(  )" & vbLf & "(B)BACILOS GRAM NEGATIVOS(  )" & vbLf & "(C)COCOS GRAM POSITIVOS(  )" & vbLf & "(D)OTROS:"
            Case "AGLUTINACIONES, TIFICAS O H Y PARATIFICOS AG. Y B(WIDAL)"
                txtResultado.Text = "TIFICO O: " & vbLf & " TIFICO H: " & vbLf & "PARAFITICO A: " & vbLf & "  PARAFITICO B: " & vbLf & " BRUCELLA:"
            Case "RPR"
                txtResultado.Text = "POSITIVO(  ) NEGATIVO(  )"
            Case "THEVENON"
                txtResultado.Text = "POSITIVO(  ) NEGATIVO(  )"
            Case "PROTEINAS EN ORINA  24 HORAS"
                txtResultado.Text = "VOLUMEN:  ml " & vbLf & " PROTEINAS CUALITATIVAS:  POSITIVO(  ) NEGATIVO(  ) " & vbLf & " PROTEINAS CUANTITATIVAS:   mg/24h"
            Case "ESTUDIO DE LÍQUIDO CITOQUIMICO"
                txtResultado.Text = "COLOR:  ASPECTO:  PH:  RCTO LEUCOCITOS:  PMN:  MN: RECUENTO HEMATIES:  RIVALTA:  PANDY:  GLUCOSA:  PROTEINAS:  BK:  GRAM:"
            Case "ORINA COMPLETA"
                txtResultado.Text = "DENSIDAD: PH:  CARB: PROTEINAS: SEDIMENTACION:  C.EPITELIALES:  LEUCOCITOS:  HEMATIES:  CRISTALES: HEMOGLOBINA:  CUERPOS CETONICOS: UROBILINA: PIGMENTOS BILIARES:"
            Case "MICROALBUMINURIA"
                txtResultado.Text = "POSITIVO(  )  mg/l NEGATIVO(  )"
            Case "CLEARENCE DE CREATININA (SUERO Y ORINA)"
                txtResultado.Text = "CREATININA EN ORIGNA:   mg/dl  VOLUMEN:  ml " & vbLf & " CLEARENCE CREATININA EN SANGRE:   mg/24h  VOLUMEN:   ml"
            Case "INV.DE PARASITOS INTESTINALES.SEREADO/CADA MUESTRA"
                txtResultado.Text = "(PRIMERA MUESTRA)" & vbLf & "COLOR:  CONSISTENCIA:  MOCO:  SANGRE:  RESTOS VEGETALES:" & vbLf & "EXAMEN DIRECTO:  SEDIMENTO DE BAERMAN:   COLORACION DE KINYOUN" & vbLf & "(SEGUNDA MUESTRA)" & vbLf & "COLOR:  CONSISTENCIA:  MOCO:  SANGRE:  RESTOS VEGETALES:" & vbLf & "EXAMEN DIRECTO: " & vbLf & "SEDIMENTO DE BAERMAN: " & vbLf & "(TERCERA MUESTRA)" & vbLf & "COLOR:  CONSISTENCIA:  MOCO:  SANGRE:  RESTOS VEGETALES:" & vbLf & "EXAMEN DIRECTO:  SEDIMENTO DE BAERMAN:   COLORACION DE KINYOUN" & vbLf & " Test de Graham (Prueba Parche).- Positivo(  )  Negativo(  )"
            Case "BARTONELOSIS"
                txtResultado.Text = "EXTENDIDO LAMINA: POSITIVO  NEGATIVO"
            Case "LEISHMANIASIS"
                txtResultado.Text = "FROTIS: POSITIVO  NEGATIVO"
            Case "GOTA GRUESA"
                txtResultado.Text = "POSITIVO  NEGATIVO   ESPECIE:"
            Case "HEMOGRAMA"
                txtResultado.Text = "LEUC.:  xmm3 AB:    SG:    EO:    B:    M:    L:    PLAQ:  xmm3 " & vbLf & " ESTUDIO DE LAMINA: " & vbLf & "(*)SERIE ROJA: " & vbLf & "HIPOCROMIA( ); POIQUILOCITOSIS(  ); ANISOCITOSIS(  ); MACROCITOSIS(  ); MICROCITOSIS(  ) " & vbLf & "(*)SERIE BLANCA: " & vbLf & " BLASTOS:   %  MIELOCITOS:   %  METAMIELOCITOS:    % " & vbLf & "(*)SERIE MEGARIOCITICA: " & vbLf & " MACROPLAQUETA:   MICROPLAQUETA:  "
            Case "PERFIL PERIFERICO HEMATOLOGICO"
                txtResultado.Text = "LEUC:  AB:  SEG:  EO:  BA:  MO:  LI:  HTO:  %  HB:  gr%  RCTO PLAQ:  xmm3 CONST CORPUS:   VGM:  HCM:   CCMH:   RDW: " & vbLf & "ESTUDIO DE LAMINA: " & vbLf & "(*)SERIE ROJA: " & vbLf & " HIPOCROMIA( ); POIQUILOCITOSIS(  ); ANISOCITOSIS(  ); MACROCITOSIS(  ); MICROCITOSIS(  ) " & vbLf & "(*)SERIE BLANCA: " & vbLf & " BLASTOS:   %  MIELOCITOS:   %  METAMIELOCITOS:    %  " & vbLf & "(*)SERIE MEGARIOCITICA: " & vbLf & " MACROPLAQUETA:    MICROPLAQUETA:  "
            Case "VELOCIDAD SEDIMENTACION"
                txtResultado.Text = "  mm/h"
            Case "GRUPO SANGUINEO Y FACTOR RH"
                txtResultado.Text = "GS:    RH:"
            Case "HEMOGLOBINA"
                txtResultado.Text = "  gr/%"
            Case "HEMATOCRITO (INCLUYE AGUJA)"
                txtResultado.Text = "   %"
            Case "CONSTANTES CORPUSCULARES"
                txtResultado.Text = "CONST CORPUS:   VGM:  HCM:   CCMH:   RDW:"
            Case "RECUENTO DE PLAQUETAS"
                txtResultado.Text = "   mm3"
            Case "TIEMPO DE COAGULACION"
                txtResultado.Text = "   min"
            Case "TIEMPO DE SANGRÍA"
                txtResultado.Text = "   min"
            Case "HIV POR ELISA"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "ANTIGENO DE SUPERFICIE PARA HEPATITIS B"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "PERFIL HEPáTICO"
                txtResultado.Text = "BT  mg/dl   BD   mg/dl   BI  mg/dl  GOT  U/l  GPT  U/l  F.Alcalina   U/l"
            Case "HEPATITIS C (ANTICUERPO)"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "HTVL1"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "ANTICORE TOTAL"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "FENOMENO L.E."
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "ANTI DNAN"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "PREGNOSTICóN"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "FACTOR REUMATOIDEO LATEX Y TEST"
                txtResultado.Text = "  UI/ml"
            Case "PROTEINA C REACTIVA CUANTITATIVA"
                txtResultado.Text = "  ng/ml"
            Case "ANTIESTREPTOLISINAS"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "T3"
                txtResultado.Text = "   pmol/l"
            Case "T4"
                txtResultado.Text = "   pmol/l"
            Case "TSH"
                txtResultado.Text = "   uUI/ml"
            Case "ANTIGENO PROSTATICO 3ra GENERACION"
                txtResultado.Text = "   mg/ml"
            Case "ANTIGENO PROSTATICO LIBRE"
                txtResultado.Text = "   mg/ml"
            Case "TROPONIMA I"
                txtResultado.Text = "   ng/ml"
            Case "FERRITINA SéRICA (ELISA)"
                txtResultado.Text = "   ng/ml"
            Case "GONODOTROFINA SUB BETA"
                txtResultado.Text = "   mUI/ml"
            Case "CHAGAS"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "INMUNOGLOBULINA M(ELISA) PARA CITOMEGALOVIRUS"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "INMUNOGLOBULINA M(ELISA) PARA TOXOPLASMA"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "ALFAFETO PROTEINA (AFP)"
                txtResultado.Text = "   UI/ml"
            Case "HEPATITIS A INMUNOGLOBULINA M"
                txtResultado.Text = "NEGATIVO(  )  POSITIVO(  )"
            Case "OM - MA (CA - 125)"
                txtResultado.Text = "   U/ml"
            Case "ANTIGENO EMBRIONARIO DE COLON (CEA)"
                txtResultado.Text = "   mg/ml"
            Case "PROLACTINA"
                txtResultado.Text = "   ng/ml"
            Case "LH"
                txtResultado.Text = "   mUI/ml"
            Case "FSH"
                txtResultado.Text = "   mUI/ml"
            Case "ESTRADIOL"
                txtResultado.Text = "   pg/ml"
            Case "TESTOSTERONA"
                txtResultado.Text = "   mg/ml"
            Case "PROGESTERONA"
                txtResultado.Text = "   mg/ml"
            Case "UROCULTIVO AUTOMATIZADO"
                txtResultado.Text = "NEGATIVO (  )  Recuento de Colonias: 0 UFC/ml"
            Case "TIEMPO DE TROMBINA"
                txtResultado.Text = "   seg"
            Case "TIEMPO DE PROTOMBINA"
                txtResultado.Text = "   seg   INR: "
            Case "TIEMPO PARCIAL DE TROMBOPLASTINA (PTT)"
                txtResultado.Text = "   seg"
            Case "DOSAJE DE FIBRINóGENO"
                txtResultado.Text = "   gr/L"
        End Select
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        Dim dsHistoria As New DataSet
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        lblTipo.Text = ""
        lblSexoP.Text = ""
        lblEdadP.Text = ""
        lblServicio.Text = ""
        lblProcedimiento.Text = ""
        Dim Edad As String
        If lvTabla.SelectedItems.Count > 0 Then
            lblHistoria.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            lblPaciente.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            lblTipo.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            'Calcular Edad
            dsHistoria = objHistoria.Buscar(lblHistoria.Text)
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
            lblSexoP.Text = dsHistoria.Tables(0).Rows(0)("Sexo").ToString
            lblEdadP.Text = Edad
            lblServicio.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            lblProcedimiento.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            ValorPrevio()
        End If
    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtHistoria.Text) Then
            BuscarHistoria()
            lvHistorial.Items.Clear()
            Dim dsVer As New DataSet

            dsVer = objConsulta.BuscarListaResultados(txtHistoria.Text)
            Dim I As Integer
            Dim FIla As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                FIla = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado"))

                'Buscar Valor Referencia
                If dsVer.Tables(0).Rows(I)("TipoPaciente") <> "SOAT" Then
                    Dim dsPar As New DataSet
                    dsPar = objServicioItem.BuscarId(dsVer.Tables(0).Rows(I)("IdExamen"))
                    If dsVer.Tables(0).Rows.Count > 0 Then
                        dsPar = objItemServicio.BuscarIdItem(dsPar.Tables(0).Rows(0)("IdItem"))
                        If dsPar.Tables(0).Rows.Count > 0 Then
                            If dsPar.Tables(0).Rows(0)("Parametros").ToString <> "" Then
                                FIla.SubItems.Add(dsPar.Tables(0).Rows(0)("Parametros").ToString)
                            Else
                                FIla.SubItems.Add("NINGUNO")
                            End If
                        Else
                            FIla.SubItems.Add("NINGUNO")
                        End If
                    Else
                        FIla.SubItems.Add("NINGUNO")
                    End If
                Else
                    FIla.SubItems.Add("NINGUNO")
                End If
            Next
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        lblServicio.Text = ""
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        lblTipo.Text = ""
        lblSexoP.Text = ""
        lblEdadP.Text = ""
        txtResultado.Text = ""
        lblProcedimiento.Text = ""
        btnGrabar.Enabled = False
        lvTabla.Select()
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If txtResultado.Text = "" Then MessageBox.Show("Dede Ingresar un Resultado Válido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtResultado.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar Resultado", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objConsulta.GrabarResultados(lvTabla.SelectedItems(0).SubItems(0).Text, txtResultado.Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name)
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)

            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub txtResultado_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtResultado.TextChanged
        If txtResultado.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If Not chkParticular.Checked Then
            If e.KeyCode = Keys.Enter And txtPaciente.Text.Length > 0 Then
                Dim dsHC As New DataSet
                dsHC = objHistoria.BuscarNombres(txtPaciente.Text)
                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsHC.Tables(0).Rows.Count - 1
                    Fila = lvPaciente.Items.Add(dsHC.Tables(0).Rows(I)("HClinica"))
                    Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Apaterno"))
                    Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Amaterno"))
                    Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Nombres"))
                    Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Fnacimiento").ToString)
                    Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Sexo"))
                    Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("NomPadre").ToString)
                    Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("NomMadre").ToString)
                Next
            End If
        Else
            If txtPaciente.Text.Length > 0 And e.KeyCode = Keys.Enter Then
                Dim dsVer As New DataSet
                dsVer = objConsulta.BuscarPacientePar(txtPaciente.Text)
                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvPaciente.Items.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
                Next
            End If
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        lvHistorial.Items.Clear()
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            If Not chkParticular.Checked Then
                txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
                txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
                lblPacienteH.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
                gbPaciente.Visible = False
                txtHistoria_KeyDown(sender, e)
            Else
                txtHistoria.Text = Microsoft.VisualBasic.Left(lvPaciente.SelectedItems(0).SubItems(0).Text, 10)
                lblPacienteH.Text = lvPaciente.SelectedItems(0).SubItems(1).Text
                lvHistorial.Items.Clear()
                Dim dsVer As New DataSet

                dsVer = objConsulta.BuscarResLabPart(lblPacienteH.Text, txtHistoria.Text)
                Dim I As Integer
                Dim FIla As ListViewItem
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    FIla = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                    FIla.SubItems.Add("PARTICULAR")
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado"))
                Next
                gbPaciente.Visible = False
            End If
        End If
    End Sub

    Private Sub lvHistorial_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvHistorial.DoubleClick
        If lvHistorial.SelectedItems.Count > 0 Then
            txtResultadoM.Tag = lvHistorial.SelectedItems(0).SubItems(0).Text
            txtResultadoM.Text = lvHistorial.SelectedItems(0).SubItems(6).Text
            gbModificar.Visible = True
            txtResultadoM.Select()
        End If
    End Sub

    Private Sub lvHistorial_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvHistorial.KeyDown
        If lvHistorial.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Anular Resultado de Laboratorio?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim Motivo As String = InputBox("Ingresar Motivo Justificado para Posterior Auditoria", "Anulación de Resultado")
                If Motivo.Length < 5 Then MessageBox.Show("El motivo debe estar plenamente Justificado, Intente Nuevamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                objControlAnulacion.Grabar(Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, lvHistorial.SelectedItems(0).SubItems(0).Text, "CONSULTA EXTERNA", Motivo)
                objConsulta.AnularResultado(lvHistorial.SelectedItems(0).SubItems(0).Text)
                lvHistorial.Items.RemoveAt(lvHistorial.SelectedItems(0).Index)
                btnBuscar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Cabecera(Historia As String, e As System.Drawing.Printing.PrintPageEventArgs)
        With e.Graphics
            Dim dsHistoria As New DataSet
            Dim Edad As String
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
                .DrawString("Edad : " & Edad & StrDup(4, " ") & "Sexo: " & dsHistoria.Tables(0).Rows(0)("Sexo").ToString, Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString("Sexo: " & dsHistoria.Tables(0).Rows(0)("Sexo").ToString, Fuente10, Pincel, 20, Y)
                Y = Y + 15
            End If
        End With
    End Sub

    Private Sub pdDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdDocumento.BeginPrint
        If Impresion = 1 Then
            Y = 10
            TotalFilas = lvTabla.Items.Count - 1
            NroFila = 0
        ElseIf Impresion = 2 Then
            TotalFilas = lvHistorial.SelectedItems.Count - 1
            NroFila = 0
        End If
    End Sub

    Private Sub pdDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdDocumento.PrintPage
        If Impresion = 1 Then
            With e.Graphics
                Do While TotalFilas >= 0
                    If NroFila = 0 Then
                        NumeroHistoria = lvTabla.Items(NroFila).SubItems(1).Text
                        Cabecera(lvTabla.Items(NroFila).SubItems(1).Text, e)
                        Y = Y + 15
                        .DrawString("Servicio: " & lvTabla.Items(NroFila).SubItems(6).Text, Fuente10, Pincel, 20, Y)
                        If lvTabla.Items(NroFila).SubItems(8).Text <> "" Then Y = Y + 15 : .DrawString("DX1: " & lvTabla.Items(NroFila).SubItems(8).Text, Fuente8, Pincel, 20, Y)
                        If lvTabla.Items(NroFila).SubItems(9).Text <> "" Then Y = Y + 15 : .DrawString("DX2: " & lvTabla.Items(NroFila).SubItems(9).Text, Fuente8, Pincel, 20, Y)
                        If lvTabla.Items(NroFila).SubItems(10).Text <> "" Then Y = Y + 15 : .DrawString("DX3: " & lvTabla.Items(NroFila).SubItems(10).Text, Fuente8, Pincel, 20, Y)
                    Else
                        If NumeroHistoria <> lvTabla.Items(NroFila).SubItems(1).Text Then
                            NumeroHistoria = lvTabla.Items(NroFila).SubItems(1).Text
                            Y = Y + 15
                            .DrawString(StrDup(20, "="), Fuente12N, Pincel, 20, Y)
                            Y = Y + 25
                            Cabecera(lvTabla.Items(NroFila).SubItems(1).Text, e)
                            .DrawString("Servicio: " & lvTabla.Items(NroFila).SubItems(6).Text, Fuente10, Pincel, 20, Y)
                            If lvTabla.Items(NroFila).SubItems(8).Text <> "" Then Y = Y + 15 : .DrawString("DX1: " & lvTabla.Items(NroFila).SubItems(8).Text, Fuente8, Pincel, 20, Y)
                            If lvTabla.Items(NroFila).SubItems(9).Text <> "" Then Y = Y + 15 : .DrawString("DX2: " & lvTabla.Items(NroFila).SubItems(9).Text, Fuente8, Pincel, 20, Y)
                            If lvTabla.Items(NroFila).SubItems(10).Text <> "" Then Y = Y + 15 : .DrawString("DX3: " & lvTabla.Items(NroFila).SubItems(10).Text, Fuente8, Pincel, 20, Y)
                        End If
                    End If
                    Y = Y + 15
                    .DrawString(Microsoft.VisualBasic.Right(StrDup(2, " ") & lvTabla.Items(NroFila).SubItems(4).Text, 2) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvTabla.Items(NroFila).SubItems(5).Text & StrDup(25, " "), 25), Fuente8, Pincel, 20, Y)
                    NroFila += 1
                    TotalFilas -= 1
                Loop
                e.HasMorePages = False
            End With
        ElseIf Impresion = 2 Then
            Dim Filas As Integer = 0
            Dim Aux As String

            Y = 20
            Filas = 10
            With e.Graphics
                .DrawString("HOSPITAL REGIONAL" & StrDup(40, " ") & "DEPARTAMENTO DE LABORATORIO", Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString("DOCENTE - TRUJILLO", Fuente10, Pincel, 20, Y)
                '.DrawString("Pag. " & NroPag & " " & UsuarioSistema, Fuente8, Pincel, 700, Y)
                Y = Y + 20
                .DrawString("Fec: " & Date.Now.ToShortDateString, Fuente8, Pincel, 700, Y)
                Y = Y + 20
                .DrawString("RESULTADOS DE LABORATORIO CLINICO", Fuente12N, Pincel, 220, Y)
                .DrawString("Hor: " & Date.Now.ToShortTimeString, Fuente8, Pincel, 700, Y)
                Y = Y + 15
                .DrawLine(Pens.Black, 200, Y, 570, Y)
                Y = Y + 10
                .DrawString("Historia : " & Microsoft.VisualBasic.Left(txtHistoria.Text & StrDup(12, " "), 12), Fuente12N, Pincel, 20, Y)
                .DrawString("Servicio : " & Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(0).SubItems(1).Text & StrDup(12, " "), 12), Fuente12N, Pincel, 260, Y)
                .DrawString("Tipo : " & Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(0).SubItems(4).Text & StrDup(20, " "), 20), Fuente12N, Pincel, 520, Y)
                Y = Y + 15
                .DrawString("Paciente : " & lblPacienteH.Text, Fuente12N, Pincel, 20, Y)
                Y = Y + 30

                .DrawString("Fecha Muestra" & StrDup(4, " ") & "Procedimiento" & StrDup(38, " ") & "Resultado" & StrDup(70, " ") & "Fec/Hor Res", Fuente8, Pincel, 20, Y)
                Y = Y + 15
                .DrawLine(Pens.Black, 20, Y, 1120, Y)
                Y = Y + 15
                Do While TotalFilas >= 0
                    If lvHistorial.SelectedItems(NroFila).Selected Then
                        .DrawString(Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(NroFila).SubItems(7).Text & StrDup(10, " "), 10), Fuente8, Pincel, 20, Y)
                        .DrawString(Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(NroFila).SubItems(5).Text & StrDup(30, "-"), 30), Fuente8, Pincel, 120, Y)
                        .DrawString(lvHistorial.SelectedItems(NroFila).SubItems(8).Text & " " & lvHistorial.SelectedItems(NroFila).SubItems(9).Text, Fuente8, Pincel, 1000, Y)


                        'Resultados
                        Aux = Replace(lvHistorial.SelectedItems(NroFila).SubItems(6).Text, vbLf, " ") & ". VALORES NORMALES: " & Replace(lvHistorial.SelectedItems(NroFila).SubItems(10).Text.Trim, vbLf, " ")
                        If Aux.Length <= 75 Then
                            .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(75, "-"), 75), Fuente10, Pincel, 350, Y)
                            Y = Y + 15
                        Else
                            .DrawString(Microsoft.VisualBasic.Left(Aux, 75), Fuente8, Pincel, 340, Y)
                            Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 75)
                            Y = Y + 15
                            Do While Aux.Length > 75
                                .DrawString(Microsoft.VisualBasic.Left(Aux, 75), Fuente8, Pincel, 340, Y)
                                Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 75)
                                Y = Y + 15
                            Loop
                            .DrawString(Aux, Fuente8, Pincel, 340, Y)
                            Y = Y + 15
                        End If
                        NroFila += 1
                        If NroFila = 66 Then Exit Do
                    End If
                    TotalFilas -= 1
                Loop
                If TotalFilas > 0 Then
                    e.HasMorePages = True
                    NroFila = 0
                Else
                    e.HasMorePages = False
                    Y = Y + 10
                    .DrawLine(Pens.Black, 20, Y, 1120, Y)
                    Y = Y + 4
                    .DrawLine(Pens.Black, 20, Y, 1120, Y)
                    Y = Y + 4
                    .DrawString("Fuente: Sistema Informático del HRDT", Fuente8, Pincel, 40, Y)
                End If
            End With
        End If
    End Sub

    Private Sub btnImpLista_Click(sender As System.Object, e As System.EventArgs) Handles btnImpLista.Click
        Impresion = 1
        ppdDocumento.ShowDialog()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If lvHistorial.SelectedItems.Count = 0 Then MessageBox.Show("Debe seleccionar el o los examenes a imprimir", "Mensaje de Información", MessageBoxButtons.OK)
        Impresion = 2
        pdDocumento.DefaultPageSettings.Landscape = True
        ppdDocumento.ShowDialog()
        pdDocumento.DefaultPageSettings.Landscape = False
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbModificar.Visible = False
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("Esta seguro de Modificar Examen de Laboratorio?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objConsulta.ModificarResultado(txtResultadoM.Tag, txtResultadoM.Text)
            lvHistorial.SelectedItems(0).SubItems(6).Text = txtResultadoM.Text
            btnRetornar_Click(sender, e)
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub lvHistorial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvHistorial.SelectedIndexChanged

    End Sub
End Class