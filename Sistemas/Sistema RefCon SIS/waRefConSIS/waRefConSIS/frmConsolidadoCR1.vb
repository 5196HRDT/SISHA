Imports Microsoft.Office.Interop
Public Class frmConsolidadoCR1
    Dim objReferencia As New Referencia
    Dim Fila As ListViewItem
    Dim I As Integer

    Private Sub Tabla()
        lvTabla.Items.Clear()
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

                'dsAtencion = objReferencia.DestinoREF(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION", lvTabla.Items(I).SubItems(0).Text, 1)
                'If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(3).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(3).Text = 0
                'STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(3).Text)
                'SH = SH + Val(lvTabla.Items(I).SubItems(3).Text)

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
                dsAtencion = objReferencia.BuscarEspRefContra(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "DEPARTAMENTO PEDIATRIA CE", "PEDIATRIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(11).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(11).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(11).Text)

                dsAtencion = objReferencia.BuscarEspRefContra(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "DEPARTAMENTO GINECO-OBSTETRICIA CE", "GINECOLOGIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(12).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(12).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(12).Text)

                dsAtencion = objReferencia.BuscarEspRefContra(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "DEPARTAMENTO MEDICINA CE", "MEDICINA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(13).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(13).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(13).Text)

                dsAtencion = objReferencia.BuscarEspRefContra(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "DEPARTAMENTO CIRUGIA CE", "CIRUGIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(14).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(14).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(14).Text)

                lvTabla.Items(I).SubItems(15).Text = 0
                lvTabla.Items(I).SubItems(16).Text = 0
                lvTabla.Items(I).SubItems(17).Text = 0
                lvTabla.Items(I).SubItems(18).Text = STotal1
                lvTabla.Items(I).SubItems(19).Text = 0

                ''Sexo
                'dsAtencion = objReferencia.BuscarSexoRef(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "MASCULINO", lvTabla.Items(I).SubItems(0).Text)
                'If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(20).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(20).Text = 0

                'dsAtencion = objReferencia.BuscarSexoRef(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "FEMENINO", lvTabla.Items(I).SubItems(0).Text)
                'If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(21).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(21).Text = 0

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
        oSheet.Range("B2").Value = "Consolidado Contra Referencia B " & cboMes.Text & "-" & cboAño.Text

        ' Esta celda tendra los datos del textbox
        Dim Columna As String = "A"
        For I = 0 To lvTabla.Columns.Count - 1
            oSheet.Range(Columna & "3").Value = lvTabla.Columns(I).Text
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
        If lvTabla.Items.Count > 0 Then
            Dim Col As Integer = 5
            For I = 0 To lvTabla.Items.Count - 1
                Columna = "A"
                For J = 0 To lvTabla.Columns.Count - 1
                    oSheet.Range(Columna & (I + 4)).Value = lvTabla.Items(I).SubItems.Item(J).Text.ToString
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
        oBook.SaveAs("C:\ConsolidadoContraReferenciaB" & cboMes.Text & cboAño.Text & ".xls")
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

                'dsAtencion = objReferencia.DestinoREF(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION", lvTabla.Items(I).SubItems(0).Text, 1)
                'If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(3).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(3).Text = 0
                'STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(3).Text)
                'SH = SH + Val(lvTabla.Items(I).SubItems(3).Text)

                dsAtencion = objReferencia.DestinoREFMA(cboMes.Text, cboAño.Text, "HOSPITALIZACION", lvTabla.Items(I).SubItems(0).Text, 2)
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
                dsAtencion = objReferencia.BuscarEspRefContraMA(cboMes.Text, cboAño.Text, "DEPARTAMENTO PEDIATRIA CE", "PEDIATRIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(11).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(11).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(11).Text)

                dsAtencion = objReferencia.BuscarEspRefContraMA(cboMes.Text, cboAño.Text, "DEPARTAMENTO GINECO-OBSTETRICIA CE", "GINECOLOGIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(12).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(12).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(12).Text)

                dsAtencion = objReferencia.BuscarEspRefContraMA(cboMes.Text, cboAño.Text, "DEPARTAMENTO MEDICINA CE", "MEDICINA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(13).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(13).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(13).Text)

                dsAtencion = objReferencia.BuscarEspRefContraMA(cboMes.Text, cboAño.Text, "DEPARTAMENTO CIRUGIA CE", "CIRUGIA", lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(14).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(14).Text = 0
                STotal1 = Val(STotal1) + Val(lvTabla.Items(I).SubItems(14).Text)

                lvTabla.Items(I).SubItems(15).Text = 0
                lvTabla.Items(I).SubItems(16).Text = 0
                lvTabla.Items(I).SubItems(17).Text = 0
                lvTabla.Items(I).SubItems(18).Text = STotal1
                lvTabla.Items(I).SubItems(19).Text = 0
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

            If I = 3 Then
                dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 7, lvC.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(11).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(11).Text = 0
                STotal = Val(STotal) + Val(lvC.Items(I).SubItems(11).Text)

                dsAtencion = objReferencia.Cuadro2RefMA(cboMes.Text, cboAño.Text, 8, lvC.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvC.Items(I).SubItems(12).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvC.Items(I).SubItems(12).Text = 0
                STotal = Val(STotal) + Val(lvC.Items(I).SubItems(12).Text)
            End If


            lvC.Items(I).SubItems(17).Text = Val(STotal)

        Next
    End Sub
End Class