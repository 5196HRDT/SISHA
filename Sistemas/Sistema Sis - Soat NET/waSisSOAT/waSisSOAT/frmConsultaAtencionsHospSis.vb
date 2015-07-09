Public Class frmConsultaAtencionsHospSis
    Dim objSis As New SIS
    Dim TipoImp As String

    Dim NroFila As Integer
    Dim TotalFilas As Integer
    Dim NroPag As Integer
    Dim Linea As Integer


    'Variables Impresion
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objSis.ConsultaAtencionHospSIS(dtpF1.Value.ToString.Substring(0, 10), dtpF2.Value.ToString.Substring(0, 10), txtPaciente.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            Dim I As Integer
            Dim Fila As New ListViewItem
            Dim Fecha As String
            For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("Formato"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Afiliado"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Situacion"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("PlanSIS"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Paciente"))
                Fecha = dsTabla.Tables(0).Rows(I)("FechaAtencion").ToString.Substring(0, 10)
                Fila.SubItems.Add(Fecha)
                If dsTabla.Tables(0).Rows(I)("FechaAlta").ToString <> "" Then
                    Fecha = dsTabla.Tables(0).Rows(I)("FechaAlta").ToString.Substring(0, 10)
                    Fila.SubItems.Add(Fecha)
                Else
                    Fila.SubItems.Add("")
                End If
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("EsReferido"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("SubEspecialidad"))
            Next
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If MessageBox.Show("Esta seguro de Imprimir Reporte Diario", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            TipoImp = 1
            Linea = 0
            NroPag = 1
            NroFila = 0
            TotalFilas = lvDet.Items.Count - 1
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString("DIRECCION DE SALUD LA LIBERTAD", FuenteE, Pincel, 40, Y)
            .DrawString("S  I  S", FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            .DrawString("NRO PAG " & NroPag, FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("UNIDAD DE SEGUROS", FuenteE, Pincel, 80, Y)

            Y = Y + 40

            If TipoImp = 1 Then
                .DrawString("ATENCIONES DE HOSPITALIZACION SIS ENTRE EL: " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString, Fuente, Pincel, 60, Y)
            Else
                .DrawString("PACIENTES MAS 1 MES HOSPITALIZACION SIS ENTRE EL: " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString, Fuente, Pincel, 60, Y)
            End If
            Y = Y + 10
            .DrawString("-----------------------------------------------------------------------------", Fuente, Pincel, 20, Y)
        End With
    End Sub

    Private Sub pdcDocumento_PrintPage_1(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20

        Encabezado(e)
        Filas = 10

        Y = Y + 40
        With e.Graphics
            .DrawString("Formato", FuenteE, Pincel, 30, Y)
            .DrawString("Afiliado", FuenteE, Pincel, 140, Y)
            .DrawString("Situacion", FuenteE, Pincel, 220, Y)
            .DrawString("Plan", FuenteE, Pincel, 290, Y)
            .DrawString("NroHis", FuenteE, Pincel, 320, Y)
            .DrawString("Paciente", FuenteE, Pincel, 450, Y)
            .DrawString("FecAten", FuenteE, Pincel, 560, Y)
            .DrawString("FecAlta", FuenteE, Pincel, 640, Y)
            .DrawString("Servicio", FuenteE, Pincel, 710, Y)
            Y = Y + 10
            .DrawString(StrDup(116, "-"), FuenteE, Pincel, 0, Y)
            Y = Y + 10
            Do While TotalFilas >= 0
                .DrawString(lvDet.Items(Linea).SubItems(0).Text, FuenteE, Pincel, 0, Y)
                .DrawString(lvDet.Items(Linea).SubItems(1).Text, FuenteE, Pincel, 120, Y)
                .DrawString(lvDet.Items(Linea).SubItems(2).Text, FuenteE, Pincel, 230, Y)
                .DrawString(lvDet.Items(Linea).SubItems(3).Text, FuenteE, Pincel, 300, Y)
                .DrawString(lvDet.Items(Linea).SubItems(4).Text, FuenteE, Pincel, 320, Y)
                If lvDet.Items(Linea).SubItems(5).Text.Length > 25 Then
                    .DrawString(lvDet.Items(Linea).SubItems(5).Text.Remove(25, lvDet.Items(Linea).SubItems(5).Text.Length - 25), FuenteE, Pincel, 370, Y)
                Else
                    .DrawString(lvDet.Items(Linea).SubItems(5).Text, FuenteE, Pincel, 370, Y)
                End If
                .DrawString(lvDet.Items(Linea).SubItems(6).Text, FuenteE, Pincel, 550, Y)
                .DrawString(lvDet.Items(Linea).SubItems(7).Text, FuenteE, Pincel, 630, Y)
                .DrawString(lvDet.Items(Linea).SubItems(9).Text, FuenteE, Pincel, 710, Y)
                Y = Y + 10

                NroFila += 1
                Linea += 1
                TotalFilas -= 1
                If NroFila >= 90 Then Exit Do
            Loop


            If TotalFilas > 0 Then
                e.HasMorePages = True
                NroPag += 1
                NroFila = 0
            Else
                e.HasMorePages = False
                Y = Y + 10
                .DrawLine(Pens.Black, 20, Y, 1000, Y)
                Y = Y + 4
                .DrawLine(Pens.Black, 20, Y, 1000, Y)
                Y = Y + 10
                .DrawString("TOTAL DE ATENCIONES: " & lvDet.Items.Count, FuenteE, Pincel, 500, Y)
            End If
        End With
    End Sub

    Private Sub frmConsultaAtencionsHospSis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
    End Sub

    Private Sub btnMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMes.Click
        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objSis.ConsultaAtencionHospSISMES(dtpF1.Value.ToString.Substring(0, 10), dtpF2.Value.ToString.Substring(0, 10), txtPaciente.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            Dim I As Integer
            Dim Fila As New ListViewItem
            Dim Fecha As String
            For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("Formato"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Afiliado"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Situacion"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("PlanSIS"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Paciente"))
                Fecha = dsTabla.Tables(0).Rows(I)("FechaAtencion").ToString.Substring(0, 10)
                Fila.SubItems.Add(Fecha)
                If dsTabla.Tables(0).Rows(I)("FechaAlta").ToString <> "" Then
                    Fecha = dsTabla.Tables(0).Rows(I)("FechaAlta").ToString.Substring(0, 10)
                    Fila.SubItems.Add(Fecha)
                Else
                    Fila.SubItems.Add("")
                End If
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("EsReferido"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("SubEspecialidad"))
            Next
        End If

        If MessageBox.Show("Esta seguro de Imprimir Reporte Diario", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            TipoImp = 2
            Linea = 0
            NroPag = 1
            NroFila = 0
            TotalFilas = lvDet.Items.Count - 1
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub
End Class