Public Class frmConsultaAtencionesSIS
    Dim objSis As New SIS
    Dim objTemporal As New tempSISHRDT

    'Variables Impresion
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim NroFilasTotales As Integer
    Dim NroPaginas As Integer
    Dim NroFilasHoja As Integer
    Dim TotalFilasLV As Integer
    Dim X, Y As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lvDet.Items.Clear()
        Dim CantAtenCE As Integer
        CantAtenCE = 0
        Dim dsTabla As New Data.DataSet
        If Not chkOrden.Checked Then
            dsTabla = objSis.ConsultaAtencionSIS(dtpF1.Value.ToString.Substring(0, 10), dtpF2.Value.ToString.Substring(0, 10), txtPaciente.Text)
        Else
            dsTabla = objSis.ConsultaAtencionSIS1(dtpF1.Value.ToString.Substring(0, 10), dtpF2.Value.ToString.Substring(0, 10), txtPaciente.Text)
        End If
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
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Especialidad"))
                If dsTabla.Tables(0).Rows(I)("Especialidad").ToString <> "EMERGENCIA" And dsTabla.Tables(0).Rows(I)("Especialidad") = "HOSPITALIZACION" Then
                    CantAtenCE += 1
                End If
            Next
        End If
        lblTotalAten.Text = lvDet.Items.Count
        'MsgBox(CantAtenCE)
    End Sub

    Private Sub frmConsultaAtencionesSIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dbCajaDataSet.tempRepAtenSIS' table. You can move, or remove it, as needed.
        Me.tempRepAtenSISTableAdapter.Fill(Me.dbCajaDataSet.tempRepAtenSIS)
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If MessageBox.Show("Esta seguro de Imprimir Reporte Diario", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            NroFilasTotales = 0
            TotalFilasLV = lvDet.Items.Count - 1
            'ppdVistaPrevia.ShowDialog()
            pdcDocumento.Print()
        End If
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString("DIRECCION DE SALUD LA LIBERTAD", FuenteE, Pincel, 40, Y)
            .DrawString("S  I  S", FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            Y = Y + 10
            .DrawString("UNIDAD DE SEGUROS", FuenteE, Pincel, 80, Y)

            Y = Y + 40

            .DrawString("ATENCIONES SIS ENTRE EL: " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString, Fuente, Pincel, 120, Y)
            Y = Y + 10
            .DrawString("----------------------------------------------------------", Fuente, Pincel, 100, Y)
        End With
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NroPaginas = 1
    End Sub

    Private Sub pdcDocumento_PrintPage_1(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20
        Encabezado(e)
        Filas = 10
        NroFilasHoja = 0
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
            Do While NroFilasTotales <= TotalFilasLV
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(0).Text, FuenteE, Pincel, 0, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(1).Text, FuenteE, Pincel, 120, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(2).Text, FuenteE, Pincel, 230, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(3).Text, FuenteE, Pincel, 300, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(4).Text, FuenteE, Pincel, 320, Y)
                If lvDet.Items(NroFilasTotales).SubItems(5).Text.Length > 25 Then
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(5).Text.Remove(25, lvDet.Items(NroFilasTotales).SubItems(5).Text.Length - 25), FuenteE, Pincel, 370, Y)
                Else
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(5).Text, FuenteE, Pincel, 370, Y)
                End If
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(6).Text, FuenteE, Pincel, 550, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(7).Text, FuenteE, Pincel, 630, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(9).Text, FuenteE, Pincel, 710, Y)
                Y = Y + 10
                NroFilasHoja += 1
                If NroFilasHoja = 95 Then
                    Exit Do
                End If
                NroFilasTotales += 1
            Loop
            If NroFilasHoja < 95 Then
                .DrawString(StrDup(116, "-"), FuenteE, Pincel, 0, Y)
                Y = Y + 10
                .DrawString("TOTAL DE ATENCIONES ==> " & lvDet.Items.Count, FuenteE, Pincel, 0, Y)
            End If
            If NroFilasHoja >= 95 Then
                e.HasMorePages = True
                NroFilasHoja = 0
            Else
                e.HasMorePages = False
            End If
        End With
    End Sub

    Private Sub ppdVistaPrevia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ppdVistaPrevia.Load

    End Sub
End Class