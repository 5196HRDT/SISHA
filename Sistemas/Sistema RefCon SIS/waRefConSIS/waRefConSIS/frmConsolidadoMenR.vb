Imports Microsoft.Office.Interop
Public Class frmConsolidadoMenR
    Dim objReferencia As New Referencia
    Dim Fila As ListViewItem
    Dim I As Integer

    Private Sub Tabla()
        Fila = lvTabla.Items.Add("NIÑOS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next
        lvTabla.Items(lvTabla.Items.Count - 1).BackColor = Color.Peru


        Fila = lvTabla.Items.Add("0-28 DIAS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("29 DIAS A 11M Y 29 DIAS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("01-04 AÑOS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("05-09 AÑOS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("10-11 AÑOS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("ADOLESCENTES")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next
        lvTabla.Items(lvTabla.Items.Count - 1).BackColor = Color.Peru

        Fila = lvTabla.Items.Add("12-14 AÑOS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("15-17 AÑOS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("JOVEN")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next
        lvTabla.Items(lvTabla.Items.Count - 1).BackColor = Color.Peru

        Fila = lvTabla.Items.Add("18-29 AÑOS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("ADULTOS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next
        lvTabla.Items(lvTabla.Items.Count - 1).BackColor = Color.Peru

        Fila = lvTabla.Items.Add("30-59 AÑOS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("ADULTO MAYOR")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next
        lvTabla.Items(lvTabla.Items.Count - 1).BackColor = Color.Peru

        Fila = lvTabla.Items.Add(">60 A MAS")
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next

        Fila = lvTabla.Items.Add("TOTAL")
        lvTabla.Items(lvTabla.Items.Count - 1).BackColor = Color.Peru
        For I = 1 To 21
            Fila.SubItems.Add("")
        Next
    End Sub

    Private Sub TablaC()
        lvC.Items.Clear()
        Fila = lvC.Items.Add("EMERGENCIA")
        For I = 1 To 17
            Fila.SubItems.Add("")
        Next

        Fila = lvC.Items.Add("CONSULTA EXTERNA")
        For I = 1 To 17
            Fila.SubItems.Add("")
        Next

        Fila = lvC.Items.Add("HOSPITALIZACION")
        For I = 1 To 17
            Fila.SubItems.Add("")
        Next

        Fila = lvC.Items.Add("APOYO DX")
        For I = 1 To 17
            Fila.SubItems.Add("")
        Next

        Fila = lvC.Items.Add("TOTAL")
        For I = 1 To 17
            Fila.SubItems.Add("")
        Next

        Fila = lvC.Items.Add("%")
        For I = 1 To 17
            Fila.SubItems.Add("")
        Next
    End Sub

    Private Sub frmConsolidadoMenR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now

        Tabla()
        TablaC()
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Dim dsAtencion As New Data.DataSet
        Dim STotal As String = 0
        Dim STotal1 As String = 0
        Dim Etapa As String = ""
        Dim PEtapa As Integer = 0
        Dim TEtapa As String = 0
        Dim S1 As Integer = 0
        Dim SC As Integer = 0
        Dim SE As Integer = 0
        Dim SH As Integer = 0
        Dim SA As Integer = 0
        Dim T1 As Integer = 0

        dsAtencion = objReferencia.Atendidos(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        If dsAtencion.Tables(0).Rows.Count > 0 Then lblAtendidos.Text = dsAtencion.Tables(0).Rows(0)(0) Else lblAtendidos.Text = 0

        dsAtencion = objReferencia.Atenciones(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        If dsAtencion.Tables(0).Rows.Count > 0 Then lblAtenciones.Text = dsAtencion.Tables(0).Rows(0)(0) Else lblAtenciones.Text = 0

        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).BackColor <> Color.Peru Then

                STotal = 0
                STotal1 = 0

                dsAtencion = objReferencia.DestinoREF(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "CONSULTA EXTERNA", lvTabla.Items(I).SubItems(0).Text, 1)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(1).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(1).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(1).Text)
                SC = SC + Val(lvTabla.Items(I).SubItems(1).Text)

                dsAtencion = objReferencia.DestinoREF(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "EMERGENCIA", lvTabla.Items(I).SubItems(0).Text, 1)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(2).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(2).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(2).Text)
                SE = SE + Val(lvTabla.Items(I).SubItems(2).Text)

                dsAtencion = objReferencia.DestinoREF(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION", lvTabla.Items(I).SubItems(0).Text, 1)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(3).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(3).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(3).Text)
                SH = SH + Val(lvTabla.Items(I).SubItems(3).Text)

                dsAtencion = objReferencia.DestinoREF(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION", lvTabla.Items(I).SubItems(0).Text, 2)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(4).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(4).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(4).Text)
                SA = SA + Val(lvTabla.Items(I).SubItems(4).Text)

                S1 = S1 + Val(STotal)
                If I = 4 Then
                    lvTabla.Items(0).SubItems(1).Text = SC
                    lvTabla.Items(0).SubItems(2).Text = SE
                    lvTabla.Items(0).SubItems(3).Text = SH
                    lvTabla.Items(0).SubItems(4).Text = SA
                    lvTabla.Items(0).SubItems(5).Text = S1
                    SC = 0
                    SE = 0
                    SH = 0
                    SA = 0
                    S1 = 0
                ElseIf I = 7 Then
                    lvTabla.Items(5).SubItems(1).Text = SC
                    lvTabla.Items(5).SubItems(2).Text = SE
                    lvTabla.Items(5).SubItems(3).Text = SH
                    lvTabla.Items(5).SubItems(4).Text = SA
                    lvTabla.Items(5).SubItems(5).Text = S1
                    SC = 0
                    SE = 0
                    SH = 0
                    SA = 0
                    S1 = 0
                ElseIf I = 9 Then
                    lvTabla.Items(8).SubItems(1).Text = SC
                    lvTabla.Items(8).SubItems(2).Text = SE
                    lvTabla.Items(8).SubItems(3).Text = SH
                    lvTabla.Items(8).SubItems(4).Text = SA
                    lvTabla.Items(8).SubItems(5).Text = S1
                    SC = 0
                    SE = 0
                    SH = 0
                    SA = 0
                    S1 = 0
                ElseIf I = 11 Then
                    lvTabla.Items(10).SubItems(1).Text = SC
                    lvTabla.Items(10).SubItems(2).Text = SE
                    lvTabla.Items(10).SubItems(3).Text = SH
                    lvTabla.Items(10).SubItems(4).Text = SA
                    lvTabla.Items(10).SubItems(5).Text = S1
                    SC = 0
                    SE = 0
                    SH = 0
                    SA = 0
                    S1 = 0


                    lvTabla.Items(12).SubItems(1).Text = Val(lvTabla.Items(0).SubItems(1).Text) + Val(lvTabla.Items(5).SubItems(1).Text) + Val(lvTabla.Items(8).SubItems(1).Text) + Val(lvTabla.Items(10).SubItems(1).Text)
                    lvTabla.Items(12).SubItems(2).Text = Val(lvTabla.Items(0).SubItems(2).Text) + Val(lvTabla.Items(5).SubItems(2).Text) + Val(lvTabla.Items(8).SubItems(2).Text) + Val(lvTabla.Items(10).SubItems(2).Text)
                    lvTabla.Items(12).SubItems(3).Text = Val(lvTabla.Items(0).SubItems(3).Text) + Val(lvTabla.Items(5).SubItems(3).Text) + Val(lvTabla.Items(8).SubItems(3).Text) + Val(lvTabla.Items(10).SubItems(3).Text)
                    lvTabla.Items(12).SubItems(4).Text = Val(lvTabla.Items(0).SubItems(4).Text) + Val(lvTabla.Items(5).SubItems(4).Text) + Val(lvTabla.Items(8).SubItems(4).Text) + Val(lvTabla.Items(10).SubItems(4).Text)

                    lvTabla.Items(12).SubItems(5).Text = Val(lvTabla.Items(0).SubItems(5).Text) + Val(lvTabla.Items(5).SubItems(5).Text) + Val(lvTabla.Items(8).SubItems(5).Text) + Val(lvTabla.Items(10).SubItems(5).Text)
                End If


                lvTabla.Items(I).SubItems(5).Text = STotal
                'S1 = S1 + Val(STotal)

                lvTabla.Items(I).SubItems(7).Text = 0
                lvTabla.Items(I).SubItems(8).Text = 0
                lvTabla.Items(I).SubItems(9).Text = 0
                lvTabla.Items(I).SubItems(10).Text = 0

                'Servicio
                dsAtencion = objReferencia.BuscarEspRef(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "DEPARTAMENTO PEDIATRIA CE", "PEDIATRIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(11).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(11).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(11).Text)

                dsAtencion = objReferencia.BuscarEspRef(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "DEPARTAMENTO GINECO-OBSTETRICIA CE", "GINECOLOGIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(12).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(12).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(12).Text)

                dsAtencion = objReferencia.BuscarEspRef(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "DEPARTAMENTO MEDICINA CE", "MEDICINA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(13).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(13).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(13).Text)

                dsAtencion = objReferencia.BuscarEspRef(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "DEPARTAMENTO CIRUGIA CE", "CIRUGIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(14).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(14).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(14).Text)

                lvTabla.Items(I).SubItems(15).Text = 0
                lvTabla.Items(I).SubItems(16).Text = 0
                lvTabla.Items(I).SubItems(17).Text = 0
                lvTabla.Items(I).SubItems(18).Text = STotal1
                lvTabla.Items(I).SubItems(19).Text = 0

                'Sexo
                dsAtencion = objReferencia.BuscarSexoRef(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "MASCULINO", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(20).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(20).Text = 0

                dsAtencion = objReferencia.BuscarSexoRef(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "FEMENINO", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(21).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(21).Text = 0

            Else
                'Select Case I
                '    Case 5
                '        lvTabla.Items(0).SubItems(1).Text = S1
                '    Case 8
                '        lvTabla.Items(5).SubItems(1).Text = TEtapa
                '    Case 10
                '        lvTabla.Items(8).SubItems(1).Text = TEtapa
                '    Case 12
                '        lvTabla.Items(10).SubItems(1).Text = TEtapa
                'End Select
            End If
        Next

        'Segundo Cuadro
        TablaC()
        For I = 0 To lvC.Items.Count - 1
            STotal = 0

            lvC.Items(I).SubItems(1).Text = 0
            lvC.Items(I).SubItems(2).Text = 0
            lvC.Items(I).SubItems(3).Text = 0
            lvC.Items(I).SubItems(4).Text = 0
            lvC.Items(I).SubItems(5).Text = 0
            lvC.Items(I).SubItems(6).Text = 0
            lvC.Items(I).SubItems(7).Text = 0
            lvC.Items(I).SubItems(8).Text = 0
            lvC.Items(I).SubItems(9).Text = 0
            lvC.Items(I).SubItems(10).Text = 0

            'Generales
            dsAtencion = objReferencia.Cuadro2Ref(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 1, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(11).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(11).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(11).Text)

            dsAtencion = objReferencia.Cuadro2Ref(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 2, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(12).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(12).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(12).Text)

            dsAtencion = objReferencia.Cuadro2Ref(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 3, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(13).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(13).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(13).Text)

            dsAtencion = objReferencia.Cuadro2Ref(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 4, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(14).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(14).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(14).Text)

            dsAtencion = objReferencia.Cuadro2Ref(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 5, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(15).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(15).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(15).Text)

            dsAtencion = objReferencia.Cuadro2Ref(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 6, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(16).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(16).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(16).Text)

            If I = 3 Then
                dsAtencion = objReferencia.Cuadro2Ref(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 7, lvC.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(11).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(11).Text = 0
                STotal = Val(STotal) + Val(lvC.Items(I).SubItems(11).Text)

                dsAtencion = objReferencia.Cuadro2Ref(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 8, lvC.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(12).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(12).Text = 0
                STotal = Val(STotal) + Val(lvC.Items(I).SubItems(12).Text)
            End If


            lvC.Items(I).SubItems(17).Text = Val(STotal)

        Next


    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

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

        For I = 0 To lvTabla.Columns.Count - 1
            objHojaExcel.Range(Columna & "1").Value = lvTabla.Columns(I).Text
            Columna = Chr(Asc(Columna) + 1)
        Next


        For I = 0 To lvTabla.Items.Count - 2
            Columna = "A"
            For J = 0 To lvTabla.Columns.Count - 1
                objHojaExcel.Range(Columna & (I + 2).ToString).Value = lvTabla.Items(I + 1).SubItems(J).Text
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
        Dim dsAtencion As New Data.DataSet
        Dim STotal As String = 0
        Dim STotal1 As String = 0
        Dim Etapa As String = ""
        Dim PEtapa As Integer = 0
        Dim TEtapa As String = 0
        Dim S1 As Integer = 0
        Dim SC As Integer = 0
        Dim SE As Integer = 0
        Dim SH As Integer = 0
        Dim SA As Integer = 0
        Dim T1 As Integer = 0

        dsAtencion = objReferencia.AtendidosMA(cboMes.Text, cboAño.Text)
        If dsAtencion.Tables(0).Rows.Count > 0 Then lblAtendidos.Text = dsAtencion.Tables(0).Rows(0)(0) Else lblAtendidos.Text = 0

        dsAtencion = objReferencia.AtencionesMA(cboMes.Text, cboAño.Text)
        If dsAtencion.Tables(0).Rows.Count > 0 Then lblAtenciones.Text = dsAtencion.Tables(0).Rows(0)(0) Else lblAtenciones.Text = 0

        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).BackColor <> Color.Peru Then

                STotal = 0
                STotal1 = 0

                dsAtencion = objReferencia.DestinoREFMA(cboMes.Text, cboAño.Text, "CONSULTA EXTERNA", lvTabla.Items(I).SubItems(0).Text, 1)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(1).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(1).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(1).Text)
                SC = SC + Val(lvTabla.Items(I).SubItems(1).Text)

                dsAtencion = objReferencia.DestinoREFMA(cboMes.Text, cboAño.Text, "EMERGENCIA", lvTabla.Items(I).SubItems(0).Text, 1)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(2).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(2).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(2).Text)
                SE = SE + Val(lvTabla.Items(I).SubItems(2).Text)

                dsAtencion = objReferencia.DestinoREFMA(cboMes.Text, cboAño.Text, "HOSPITALIZACION", lvTabla.Items(I).SubItems(0).Text, 1)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(3).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(3).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(3).Text)
                SH = SH + Val(lvTabla.Items(I).SubItems(3).Text)

                dsAtencion = objReferencia.DestinoREFMA(cboMes.Text, cboAño.Text, "HOSPITALIZACION", lvTabla.Items(I).SubItems(0).Text, 2)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(4).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(4).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(4).Text)
                SA = SA + Val(lvTabla.Items(I).SubItems(4).Text)

                S1 = S1 + Val(STotal)
                If I = 5 Then
                    lvTabla.Items(0).SubItems(1).Text = SC
                    lvTabla.Items(0).SubItems(2).Text = SE
                    lvTabla.Items(0).SubItems(3).Text = SH
                    lvTabla.Items(0).SubItems(4).Text = SA
                    lvTabla.Items(0).SubItems(5).Text = S1
                    SC = 0
                    SE = 0
                    SH = 0
                    SA = 0
                    S1 = 0
                ElseIf I = 8 Then
                    lvTabla.Items(6).SubItems(1).Text = SC
                    lvTabla.Items(6).SubItems(2).Text = SE
                    lvTabla.Items(6).SubItems(3).Text = SH
                    lvTabla.Items(6).SubItems(4).Text = SA
                    lvTabla.Items(6).SubItems(5).Text = S1
                    SC = 0
                    SE = 0
                    SH = 0
                    SA = 0
                    S1 = 0
                ElseIf I = 10 Then
                    lvTabla.Items(9).SubItems(1).Text = SC
                    lvTabla.Items(9).SubItems(2).Text = SE
                    lvTabla.Items(9).SubItems(3).Text = SH
                    lvTabla.Items(9).SubItems(4).Text = SA
                    lvTabla.Items(9).SubItems(5).Text = S1
                    SC = 0
                    SE = 0
                    SH = 0
                    SA = 0
                    S1 = 0
                ElseIf I = 12 Then
                    lvTabla.Items(11).SubItems(1).Text = SC
                    lvTabla.Items(11).SubItems(2).Text = SE
                    lvTabla.Items(11).SubItems(3).Text = SH
                    lvTabla.Items(11).SubItems(4).Text = SA
                    lvTabla.Items(11).SubItems(5).Text = S1
                    SC = 0
                    SE = 0
                    SH = 0
                    SA = 0
                    S1 = 0
                ElseIf I = 14 Then
                    lvTabla.Items(13).SubItems(1).Text = SC
                    lvTabla.Items(13).SubItems(2).Text = SE
                    lvTabla.Items(13).SubItems(3).Text = SH
                    lvTabla.Items(13).SubItems(4).Text = SA
                    lvTabla.Items(13).SubItems(5).Text = S1
                    SC = 0
                    SE = 0
                    SH = 0
                    SA = 0
                    S1 = 0

                    lvTabla.Items(15).SubItems(1).Text = Val(lvTabla.Items(0).SubItems(1).Text) + Val(lvTabla.Items(6).SubItems(1).Text) + Val(lvTabla.Items(9).SubItems(1).Text) + Val(lvTabla.Items(11).SubItems(1).Text) + Val(lvTabla.Items(13).SubItems(1).Text)
                    lvTabla.Items(15).SubItems(2).Text = Val(lvTabla.Items(0).SubItems(2).Text) + Val(lvTabla.Items(6).SubItems(2).Text) + Val(lvTabla.Items(9).SubItems(2).Text) + Val(lvTabla.Items(11).SubItems(2).Text) + Val(lvTabla.Items(13).SubItems(2).Text)
                    lvTabla.Items(15).SubItems(3).Text = Val(lvTabla.Items(0).SubItems(3).Text) + Val(lvTabla.Items(6).SubItems(3).Text) + Val(lvTabla.Items(9).SubItems(3).Text) + Val(lvTabla.Items(11).SubItems(3).Text) + Val(lvTabla.Items(13).SubItems(3).Text)
                    lvTabla.Items(15).SubItems(4).Text = Val(lvTabla.Items(0).SubItems(4).Text) + Val(lvTabla.Items(6).SubItems(4).Text) + Val(lvTabla.Items(9).SubItems(4).Text) + Val(lvTabla.Items(11).SubItems(4).Text) + Val(lvTabla.Items(13).SubItems(4).Text)
                    lvTabla.Items(15).SubItems(5).Text = Val(lvTabla.Items(0).SubItems(5).Text) + Val(lvTabla.Items(6).SubItems(5).Text) + Val(lvTabla.Items(9).SubItems(5).Text) + Val(lvTabla.Items(11).SubItems(5).Text) + Val(lvTabla.Items(13).SubItems(5).Text)
                End If


                lvTabla.Items(I).SubItems(5).Text = STotal
                'S1 = S1 + Val(STotal)

                lvTabla.Items(I).SubItems(7).Text = 0
                lvTabla.Items(I).SubItems(8).Text = 0
                lvTabla.Items(I).SubItems(9).Text = 0
                lvTabla.Items(I).SubItems(10).Text = 0

                'Servicio
                dsAtencion = objReferencia.BuscarEspRefMA(cboMes.Text, cboAño.Text, "DEPARTAMENTO PEDIATRIA CE", "PEDIATRIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(11).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(11).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(11).Text)

                dsAtencion = objReferencia.BuscarEspRefMA(cboMes.Text, cboAño.Text, "DEPARTAMENTO GINECO-OBSTETRICIA CE", "GINECOLOGIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(12).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(12).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(12).Text)

                dsAtencion = objReferencia.BuscarEspRefMA(cboMes.Text, cboAño.Text, "DEPARTAMENTO MEDICINA CE", "MEDICINA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(13).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(13).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(13).Text)

                dsAtencion = objReferencia.BuscarEspRefMA(cboMes.Text, cboAño.Text, "DEPARTAMENTO CIRUGIA CE", "CIRUGIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(14).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(14).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(14).Text)

                lvTabla.Items(I).SubItems(15).Text = 0
                lvTabla.Items(I).SubItems(16).Text = 0
                lvTabla.Items(I).SubItems(17).Text = 0
                lvTabla.Items(I).SubItems(18).Text = STotal1
                lvTabla.Items(I).SubItems(19).Text = 0

                'Sexo
                dsAtencion = objReferencia.BuscarSexoRefMA(cboMes.Text, cboAño.Text, "MASCULINO", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(20).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(20).Text = 0

                dsAtencion = objReferencia.BuscarSexoRefMA(cboMes.Text, cboAño.Text, "FEMENINO", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(21).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(21).Text = 0

            Else
                'Select Case I
                '    Case 5
                '        lvTabla.Items(0).SubItems(1).Text = S1
                '    Case 8
                '        lvTabla.Items(5).SubItems(1).Text = TEtapa
                '    Case 10
                '        lvTabla.Items(8).SubItems(1).Text = TEtapa
                '    Case 12
                '        lvTabla.Items(10).SubItems(1).Text = TEtapa
                'End Select
            End If
        Next

        'Segundo Cuadro
        TablaC()
        For I = 0 To lvC.Items.Count - 1
            STotal = 0

            lvC.Items(I).SubItems(1).Text = 0
            lvC.Items(I).SubItems(2).Text = 0
            lvC.Items(I).SubItems(3).Text = 0
            lvC.Items(I).SubItems(4).Text = 0
            lvC.Items(I).SubItems(5).Text = 0
            lvC.Items(I).SubItems(6).Text = 0
            lvC.Items(I).SubItems(7).Text = 0
            lvC.Items(I).SubItems(8).Text = 0
            lvC.Items(I).SubItems(9).Text = 0
            lvC.Items(I).SubItems(10).Text = 0


            'Categoria
            dsAtencion = objReferencia.Cuadro2RefCat(cboMes.Text, cboAño.Text, "I-1", lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(1).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(1).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(1).Text)

            dsAtencion = objReferencia.Cuadro2RefCat(cboMes.Text, cboAño.Text, "I-2", lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(2).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(2).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(2).Text)

            dsAtencion = objReferencia.Cuadro2RefCat(cboMes.Text, cboAño.Text, "I-3", lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(3).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(3).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(3).Text)

            dsAtencion = objReferencia.Cuadro2RefCat(cboMes.Text, cboAño.Text, "I-4", lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(4).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(4).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(4).Text)

            dsAtencion = objReferencia.Cuadro2RefCat(cboMes.Text, cboAño.Text, "II-1", lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(5).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(5).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(5).Text)

            dsAtencion = objReferencia.Cuadro2RefCat(cboMes.Text, cboAño.Text, "II-2", lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(6).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(6).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(6).Text)

            dsAtencion = objReferencia.Cuadro2RefCat(cboMes.Text, cboAño.Text, "III-1", lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(7).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(7).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(7).Text)

            dsAtencion = objReferencia.Cuadro2RefCat(cboMes.Text, cboAño.Text, "III-2", lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(8).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(8).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(8).Text)

            'Especialidad
            dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 1, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(11).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(11).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(11).Text)

            dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 2, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(12).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(12).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(12).Text)

            dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 3, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(13).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(13).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(13).Text)

            dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 4, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(14).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(14).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(14).Text)

            dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 5, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(15).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(15).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(15).Text)

            dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 6, lvC.Items(I).SubItems(0).Text)
            If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(16).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(16).Text = 0
            STotal = Val(STotal) + Val(lvC.Items(I).SubItems(16).Text)

            'Ayuda al Diagnostico
            If I = 3 Then
                dsAtencion = objReferencia.Cuadro2RefAD(cboMes.Text, cboAño.Text, "I-1")
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(1).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(2).Text = 0
                'STotal = Val(STotal) + Val(lvC.Items(I).SubItems(1).Text)

                dsAtencion = objReferencia.Cuadro2RefAD(cboMes.Text, cboAño.Text, "I-2")
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(2).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(2).Text = 0

                dsAtencion = objReferencia.Cuadro2RefAD(cboMes.Text, cboAño.Text, "I-3")
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(3).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(3).Text = 0

                dsAtencion = objReferencia.Cuadro2RefAD(cboMes.Text, cboAño.Text, "I-4")
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(4).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(4).Text = 0

                dsAtencion = objReferencia.Cuadro2RefAD(cboMes.Text, cboAño.Text, "II-1")
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(5).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(5).Text = 0

                dsAtencion = objReferencia.Cuadro2RefAD(cboMes.Text, cboAño.Text, "II-2")
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(6).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(6).Text = 0


                'dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 7, lvC.Items(I).SubItems(0).Text)
                'If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(11).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(11).Text = 0
                'STotal = Val(STotal) + Val(lvC.Items(I).SubItems(11).Text)

                'dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 8, lvC.Items(I).SubItems(0).Text)
                'If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(12).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(12).Text = 0
                'STotal = Val(STotal) + Val(lvC.Items(I).SubItems(12).Text)
            End If


            lvC.Items(I).SubItems(17).Text = Val(STotal)

        Next

        'Gestantes
        lvGestante.Items.Clear()
        Fila = lvGestante.Items.Add("ADOLECENTES (12-17 AÑOS")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")

        Fila = lvGestante.Items.Add("JOVEN (18-29 AÑOS")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")

        Fila = lvGestante.Items.Add("ADULTA")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")

        'Adolescentes CE
        Dim dsGes As New DataSet
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 1)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(0).SubItems(1).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Joven CE
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 2)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(1).SubItems(1).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adulta CE
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 3)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(2).SubItems(1).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adolescentes Emergencia
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 4)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(0).SubItems(2).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Joven Emergencia
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 5)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(1).SubItems(2).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adulta Emergencia
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 6)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(2).SubItems(2).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adolescentes DX
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 7)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(0).SubItems(3).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Joven DX
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 8)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(1).SubItems(3).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adulta DX
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 9)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(2).SubItems(3).Text = dsGes.Tables(0).Rows(0)("Total")
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        'Variables locales
        Dim I, J As Integer
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Iniciar un nuevo libro en Excel
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        'Agregar datos a las celdas de la primera hoja en el libro nuevo
        oSheet = oBook.Worksheets(1)

        ' Agregamos Los datos que queremos agregar
        oSheet.Range("B2").Value = "Consolidado Mensual " & cboMes.Text & "-" & cboAño.Text

        ' Esta celda tendra los datos del textbox
        Dim Columna As String = "A"
        For I = 0 To lvC.Columns.Count - 1
            oSheet.Range(Columna & "3").Value = lvC.Columns(I).Text
            If Columna = "Z" Then
                Columna = "AA"
            Else
                If Columna.Length = 1 Then
                    Columna = Chr(Asc(Columna) + 1)
                Else
                    Dim TempC As String = Microsoft.VisualBasic.Right(Columna, 1)
                    Columna = "A" & Chr(Asc(TempC) + 1)
                End If
            End If
        Next

        Columna = "A"
        If lvC.Items.Count > 0 Then
            Dim Col As Integer = 5
            For I = 0 To lvC.Items.Count - 1
                Columna = "A"
                For J = 0 To lvC.Columns.Count - 1
                    oSheet.Range(Columna & (I + 4)).Value = lvC.Items(I).SubItems.Item(J).Text.ToString
                    If Columna = "Z" Then
                        Columna = "AA"
                    Else
                        If Columna.Length = 1 Then
                            Columna = Chr(Asc(Columna) + 1)
                        Else
                            Dim TempC As String = Microsoft.VisualBasic.Right(Columna, 1)
                            Columna = "A" & Chr(Asc(TempC) + 1)
                        End If
                    End If
                Next
            Next
        End If

        oExcel.Visible = True
        oExcel.UserControl = True

        'Guardaremos el documento en el escritorio con el nombre prueba
        Try
            oBook.SaveAs("C:\ConsolidadoMensual" & cboMes.Text & cboAño.Text & ".xls")
        Catch ex As Exception

        End Try

    End Sub
End Class