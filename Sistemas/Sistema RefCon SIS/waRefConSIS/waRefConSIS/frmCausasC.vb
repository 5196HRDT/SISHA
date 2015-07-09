Imports Microsoft.Office.Interop
Public Class frmCausasC
    Dim objReferencia As New Referencia
    Dim objTemporal As New TempRefSIS
    Dim Fila As ListViewItem
    Dim I As Integer

    Private Sub Lista1()
        lvLista1.Items.Clear()
        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("EMBARAZO PARTO Y PUERPERIO")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(1)
        Fila.SubItems.Add("Abortos")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(2)
        Fila.SubItems.Add("Edemas y transtornos hipertensivos del emb. Parto y puerperio")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(3)
        Fila.SubItems.Add("Polihidramnios y otros transtornos del LA y membranas")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(4)
        Fila.SubItems.Add("Embarazo Normal y Multiple")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(5)
        Fila.SubItems.Add("RPM")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(6)
        Fila.SubItems.Add("Placenta Previa")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(7)
        Fila.SubItems.Add("Amenaza dfe parto prematuro")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(8)
        Fila.SubItems.Add("Inicio de trabajo de parto prematuro")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(9)
        Fila.SubItems.Add("Atencion Materna por presentacion anormal del feto")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(10)
        Fila.SubItems.Add("Cesarea Anterior")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(11)
        Fila.SubItems.Add("Otras Enf. Maternas Clasificables que Complican Embarazo, Parto y Puerperio")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(12)
        Fila.SubItems.Add("Atencion materna por anormalidad o lesion fetal presunta o conocida")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(13)
        Fila.SubItems.Add("Trabajo de parto y parto complicado por Sufrimiento fetal")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("TRAUMATISMOS")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru


        Fila = lvLista1.Items.Add(14)
        Fila.SubItems.Add("Traumatismo de cabeza")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(15)
        Fila.SubItems.Add("Traumatismos multiples")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(16)
        Fila.SubItems.Add("Quemaduras")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES DEL SISTEMA RESPIRATORIO")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(17)
        Fila.SubItems.Add("Neumonias")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(18)
        Fila.SubItems.Add("Asma y estados asmaticos (SOB)")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(19)
        Fila.SubItems.Add("Insuficiencia respiratoria")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("AFECCIONES PERINATALES")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(20)
        Fila.SubItems.Add("Pretermino y bajo peso")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(21)
        Fila.SubItems.Add("Dificultad respiratoria")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(22)
        Fila.SubItems.Add("Sepsis Neonatal")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(23)
        Fila.SubItems.Add("Ictericia")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES DEL SISTEMA DIGESTIVO")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(24)
        Fila.SubItems.Add("Enfermedades del Sistema Digestivo")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(25)
        Fila.SubItems.Add("Enfermedades del Apendice")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(26)
        Fila.SubItems.Add("HDA")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(27)
        Fila.SubItems.Add("Obstruccion Intestinal")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(28)
        Fila.SubItems.Add("Otros transtornos del peritoneo")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(29)
        Fila.SubItems.Add("Colangitis")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES DEL SISTEMA CIRCULATORIO")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(30)
        Fila.SubItems.Add("Enfermedad Hipertensiva")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(31)
        Fila.SubItems.Add("Enfermedad del Corazon")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(32)
        Fila.SubItems.Add("Insuficiencia Cardiaca")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(33)
        Fila.SubItems.Add("Enfermedad Cerebro Vascular")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES INFECCIOSAS Y PARASITARIAS")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(34)
        Fila.SubItems.Add("Enfermedad Infeccionsas y Parasitarias")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(35)
        Fila.SubItems.Add("Septicemias")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("MALFORMACIONES CONGENITAS, DEFORMIDADES Y ANOMALIAS CROMOSOMICAS")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(36)
        Fila.SubItems.Add("Malformaciones Congenitas, Deformaciones y Anomalias Cromosomicas")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES DEL SISTEMA NERVIOSO")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(37)
        Fila.SubItems.Add("Del Sistema Nervioso")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(38)
        Fila.SubItems.Add("Enfermedades Inflamatorias del Sistema Nervioso (Meningitis, Encefalitis y Otros")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES DE LA SANGRE Y ORGANOS HEMATOPOYETICOS")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(39)
        Fila.SubItems.Add("Purpura")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(40)
        Fila.SubItems.Add("Anemias")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES DEL SISTEMA GENITOURINARIO")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(41)
        Fila.SubItems.Add("Absceso vulvoperineal")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(42)
        Fila.SubItems.Add("Insuficiencia renal")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES ENDOCRINAS, NUTRICIONALES Y METABOLICAS")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(43)
        Fila.SubItems.Add("DM")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(44)
        Fila.SubItems.Add("Trastornos metabólicos")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add(45)
        Fila.SubItems.Add("Hipertiroidismo")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("TUMORES MALIGNOS")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(46)
        Fila.SubItems.Add("Tumores malignos linfáticos y de los organos hematopoyéticos (leucemias)")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("TUMORES DE COMPORTAMIENTO INCIERTO")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(47)
        Fila.SubItems.Add("Tumores de comportamiento incierto")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES DEL SISTEMA OSTEOMUSCULAR Y TEJIDO CONJUNTIVO")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(48)
        Fila.SubItems.Add("Enfermedades del sistema osteomuscular y tejido conjuntivo")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("TRASTORNOS MENTALES Y DE COMPORTAMIENTO")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(49)
        Fila.SubItems.Add("Trastornos mentales y de comportamiento")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("ENFERMEDADES DE PIEL Y TCSC")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(50)
        Fila.SubItems.Add("Enfermedades de piel y TCSC")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")

        Fila = lvLista1.Items.Add("")
        Fila.SubItems.Add("TRASTORNOS DEL OJO Y ANEXOS")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.BackColor = Color.Peru

        Fila = lvLista1.Items.Add(51)
        Fila.SubItems.Add("Trastornos del ojo y anexos")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
    End Sub

    Private Sub frmCausas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Lista1()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        objTemporal.Eliminar()
        Dim dsCIE As New Data.DataSet
        Dim J As Integer

        dsCIE = objReferencia.BuscarCIECon(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        For I = 0 To dsCIE.Tables(0).Rows.Count - 1
            For J = 0 To 3
                If dsCIE.Tables(0).Rows(I)(J) <> "" Then objTemporal.Grabar(dsCIE.Tables(0).Rows(I)(J))
            Next
        Next

        Lista1()

        Dim Fila As Integer = 0
        Dim Res As Integer = 0
        Dim Tipo As Integer = 0
        For I = 1 To lvLista1.Items.Count
            If IsNumeric(lvLista1.Items(I - 1).SubItems(0).Text) Then
                Tipo += 1
                Res = objReferencia.Consulta(Tipo)
                lvLista1.Items(I - 1).SubItems(2).Text = Res
            End If
        Next

        Dim Suma As Integer = 0
        For I = 1 To 13
            Suma = Suma + lvLista1.Items(I).SubItems(2).Text
        Next
        For I = 1 To 13
            lvLista1.Items(I).SubItems(3).Text = Math.Round((Val(lvLista1.Items(I).SubItems(2).Text) * 100) / Suma, 1)
        Next
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim m_Excel
        Dim objLibroExcel
        Dim objHojaExcel
        m_Excel = CreateObject("Excel.Application")

        objLibroExcel = m_Excel.Workbooks.Add()
        objHojaExcel = objLibroExcel.Worksheets(1)
        objHojaExcel.Name = Microsoft.VisualBasic.Left("Consolidado Mensual", 30)
        objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible
        objHojaExcel.Activate()

        Dim NroHoja As Integer = 0
        Dim RHoja As Integer = 1
        Dim Columna As String
        Dim dsTab As New Data.DataSet
        Dim J As Integer

        Columna = "A"

        For I = 0 To lvLista1.Columns.Count - 1
            objHojaExcel.Range(Columna & "1").Value = lvLista1.Columns(I).Text
            Columna = Chr(Asc(Columna) + 1)
        Next


        For I = 0 To lvLista1.Items.Count - 2
            Columna = "A"
            For J = 0 To lvLista1.Columns.Count - 1
                objHojaExcel.Range(Columna & (I + 2).ToString).Value = lvLista1.Items(I + 1).SubItems(J).Text
                Columna = Chr(Asc(Columna) + 1)

                objHojaExcel.Name = Microsoft.VisualBasic.Left("Consolidado Referencias", 30)
                objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible
                objHojaExcel.Activate()
            Next
        Next
        MsgBox("Exportación a Excel completa", MsgBoxStyle.Information + MsgBoxStyle.Information, "Mensaje de Informacion")
        m_Excel.Visible = True
    End Sub

    Private Sub btnMostrar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar1.Click
        objTemporal.Eliminar()
        Dim dsCIE As New Data.DataSet
        Dim J As Integer

        dsCIE = objReferencia.BuscarCIEConMA(cboMes.Text, cboAño.Text)
        For I = 0 To dsCIE.Tables(0).Rows.Count - 1
            For J = 0 To 3
                If dsCIE.Tables(0).Rows(I)(J) <> "" Then objTemporal.Grabar(dsCIE.Tables(0).Rows(I)(J))
            Next
        Next

        Lista1()

        Dim Fila As Integer = 0
        Dim Res As Integer = 0
        Dim Tipo As Integer = 0
        For I = 1 To lvLista1.Items.Count
            If IsNumeric(lvLista1.Items(I - 1).SubItems(0).Text) Then
                Tipo += 1
                Res = objReferencia.Consulta(Tipo)
                lvLista1.Items(I - 1).SubItems(2).Text = Res
            End If
        Next

        Dim Suma As Integer = 0
        For I = 1 To 13
            Suma = Suma + lvLista1.Items(I).SubItems(2).Text
        Next
        For I = 1 To 13
            lvLista1.Items(I).SubItems(3).Text = Math.Round((Val(lvLista1.Items(I).SubItems(2).Text) * 100) / Suma, 1)
        Next
    End Sub
End Class