Imports Microsoft.Office.Interop
Public Class frmConsolidadoCR
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

    Private Sub frmConsolidadoCR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now

        Tabla()
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Dim STotal As String
        Dim dsAtencion As New Data.DataSet

        Tabla()
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).BackColor <> Color.Peru Then

                STotal = 0

                dsAtencion = objReferencia.CondicionAlta(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 1, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(1).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(1).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(1).Text)


                dsAtencion = objReferencia.CondicionAlta(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 2, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(2).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(2).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(2).Text)

                dsAtencion = objReferencia.CondicionAlta(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 3, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(3).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(3).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(3).Text)

                dsAtencion = objReferencia.CondicionAlta(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 4, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(4).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(4).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(4).Text)

                dsAtencion = objReferencia.CondicionAlta(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 5, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(5).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(5).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(5).Text)

                dsAtencion = objReferencia.CondicionAlta(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 6, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(6).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(6).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(6).Text)
            End If
        Next
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
        oSheet.Range("B2").Value = "Consolidado Contra Referencia " & cboMes.Text & "-" & cboAño.Text

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
        oBook.SaveAs("C:\ConsolidadoContraReferencia" & cboMes.Text & cboAño.Text & ".xls")
    End Sub

    Private Sub btnMostrar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar1.Click
        Dim STotal As String
        Dim dsAtencion As New Data.DataSet

        Tabla()
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).BackColor <> Color.Peru Then

                STotal = 0

                dsAtencion = objReferencia.CondicionAltaMA(cboMes.Text, cboAño.Text, 1, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(1).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(1).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(1).Text)


                dsAtencion = objReferencia.CondicionAltaMA(cboMes.Text, cboAño.Text, 2, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(2).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(2).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(2).Text)

                dsAtencion = objReferencia.CondicionAltaMA(cboMes.Text, cboAño.Text, 3, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(3).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(3).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(3).Text)

                dsAtencion = objReferencia.CondicionAltaMA(cboMes.Text, cboAño.Text, 4, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(4).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(4).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(4).Text)

                dsAtencion = objReferencia.CondicionAltaMA(cboMes.Text, cboAño.Text, 5, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(5).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(5).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(5).Text)

                dsAtencion = objReferencia.CondicionAltaMA(cboMes.Text, cboAño.Text, 6, lvTabla.Items(I).SubItems(0).Text)
                If dsAtencion.Tables(0).Rows.Count > 0 Then lvTabla.Items(I).SubItems(6).Text = dsAtencion.Tables(0).Rows(0)(0) Else lvTabla.Items(I).SubItems(6).Text = 0
                STotal = Val(STotal) + Val(lvTabla.Items(I).SubItems(6).Text)
            End If
        Next

        'Gestantes
        lvGestante.Items.Clear()
        Fila = lvGestante.Items.Add("ADOLECENTES (12-17 AÑOS")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")

        Fila = lvGestante.Items.Add("JOVEN (18-29 AÑOS")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")

        Fila = lvGestante.Items.Add("ADULTA")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")
        Fila.SubItems.Add("0")

        Dim dsGes As New DataSet
        'Adolescente Curado
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 10)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(0).SubItems(1).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Joven Curado
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 11)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(1).SubItems(1).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adulto Curado
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 12)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(2).SubItems(1).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adolescente Mejorado
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 13)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(0).SubItems(2).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Joven Mejorado
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 14)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(1).SubItems(2).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adulto Mejorado
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 15)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(2).SubItems(2).Text = dsGes.Tables(0).Rows(0)("Total")
        End If


        'Adolescente Apoyo DX
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 16)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(0).SubItems(3).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Joven Apoyo DX
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 17)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(1).SubItems(3).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adulto Apoyo DX
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 18)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(2).SubItems(3).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adolescente DESERCION
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 19)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(0).SubItems(4).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Joven DESERCION
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 20)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(1).SubItems(4).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adulto DESERCION
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 21)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(2).SubItems(4).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adolescente RETIRO VOLUNTARIO
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 22)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(0).SubItems(5).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Joven RETIRO VOLUNTARIO
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 23)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(1).SubItems(5).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adulto RETIRO VOLUNTARIO
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 24)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(2).SubItems(5).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adolescente FALLECIDO
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 25)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(0).SubItems(6).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Joven FALLECIDO
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 26)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(1).SubItems(6).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        'Adulto FALLECIDO
        dsGes = objReferencia.Gestantes(cboMes.Text, cboAño.Text, 27)
        If dsGes.Tables(0).Rows.Count > 0 Then
            lvGestante.Items(2).SubItems(6).Text = dsGes.Tables(0).Rows(0)("Total")
        End If

        lvGestante.Items(0).SubItems(7).Text = Val(lvGestante.Items(0).SubItems(1).Text) + Val(lvGestante.Items(0).SubItems(2).Text) + Val(lvGestante.Items(0).SubItems(3).Text) + Val(lvGestante.Items(0).SubItems(4).Text) + Val(lvGestante.Items(0).SubItems(5).Text) + Val(lvGestante.Items(0).SubItems(6).Text)
        lvGestante.Items(1).SubItems(7).Text = Val(lvGestante.Items(1).SubItems(1).Text) + Val(lvGestante.Items(1).SubItems(2).Text) + Val(lvGestante.Items(1).SubItems(3).Text) + Val(lvGestante.Items(1).SubItems(4).Text) + Val(lvGestante.Items(1).SubItems(5).Text) + Val(lvGestante.Items(1).SubItems(6).Text)
        lvGestante.Items(2).SubItems(7).Text = Val(lvGestante.Items(2).SubItems(1).Text) + Val(lvGestante.Items(2).SubItems(2).Text) + Val(lvGestante.Items(2).SubItems(3).Text) + Val(lvGestante.Items(2).SubItems(4).Text) + Val(lvGestante.Items(2).SubItems(5).Text) + Val(lvGestante.Items(2).SubItems(6).Text)

    End Sub
End Class