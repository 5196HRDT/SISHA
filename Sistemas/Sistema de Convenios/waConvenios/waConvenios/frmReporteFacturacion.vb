Public Class frmReporteFacturacion
    Dim objFacturacion As New FacturacionEconomia
    Dim objConvenio As New Convenio
    Dim objTipoTarifa As New TipoTarifario

    Dim Total As Double
    Dim TotalFilas As Integer

    'Variables Impresion
    Dim FuenteTG As New Font("Lucida Console", 14, FontStyle.Bold)
    Dim FuenteG As New Font("TIMES NEW ROMAN", 20, FontStyle.Bold)
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8)
    Dim FuenteET As New Font("Lucida Console", 8, FontStyle.Bold)
    Dim FuenteP As New Font("Lucida Console", 9, FontStyle.Bold)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim TipoReporte As String
    Dim PosicionFila As Integer
    Dim NroFilasTotales As Integer
    Dim NroPaginas As Integer
    Dim NroFilasHoja As Integer
    Dim TotalFilasLV As Integer
    Dim X, Y As Integer
    Dim TipoImpresion As String

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        lvTabla.Items.Clear()
        Dim dsFac As New DataSet
        Dim Tipo As Integer = 0
        Dim I As Integer
        Dim Fila As ListViewItem
        If chkTodo.Checked Then Tipo = 1
        dsFac = objFacturacion.ReporteFacturacion(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, cboConvenio.Text, Tipo)
        For I = 0 To dsFac.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsFac.Tables(0).Rows(I)("IdFactura"))
            Fila.SubItems.Add(dsFac.Tables(0).Rows(I)("FechaRegistro"))
            Fila.SubItems.Add(dsFac.Tables(0).Rows(I)("Ruc"))
            Fila.SubItems.Add(dsFac.Tables(0).Rows(I)("RazonSocial"))
            Fila.SubItems.Add(dsFac.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsFac.Tables(0).Rows(I)("Serie"))
            Fila.SubItems.Add(dsFac.Tables(0).Rows(I)("Numero"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsFac.Tables(0).Rows(I)("SubTotal")), "#0.00"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsFac.Tables(0).Rows(I)("IGV")), "#0.00"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsFac.Tables(0).Rows(I)("Total")), "#0.00"))
            Fila.SubItems.Add(dsFac.Tables(0).Rows(I)("FechaCancelado").ToString)
            Fila.SubItems.Add(dsFac.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsFac.Tables(0).Rows(I)("Tipo"))
        Next
    End Sub

    Private Sub frmReporteFacturacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFechaC.Value = Date.Now
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now

        btnCancelar.Enabled = False

        Dim dsCombo As New Data.DataSet
        dsCombo = objTipoTarifa.ComboConvenio
        cboConvenio.DataSource = dsCombo.Tables(0)
        cboConvenio.DisplayMember = "Descripcion"
        cboConvenio.ValueMember = "IdTipoTarifa"
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        If lvTabla.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de Cancelar Comprobante de Venta", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim NroCheque As String
                NroCheque = InputBox("Ingresar Nro Cheque", "Datos Pago")
                objFacturacion.Cancelar(lvTabla.SelectedItems(0).SubItems(0).Text, dtpFechaC.Value.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, NroCheque)
                objConvenio.Cancelar(Date.Now.ToShortDateString, dtpFechaC.Value.ToShortDateString, UsuarioSistema, My.Computer.Name, lvTabla.SelectedItems(0).SubItems(12).Text, lvTabla.SelectedItems(0).SubItems(5).Text, lvTabla.SelectedItems(0).SubItems(6).Text)
                btnBuscar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub chkTodo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTodo.CheckedChanged
        If chkTodo.Checked Then cboConvenio.Enabled = False : cboConvenio.Text = "" Else cboConvenio.Enabled = True
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            If lvTabla.SelectedItems(0).SubItems(10).Text = "" Then btnCancelar.Enabled = True Else btnCancelar.Enabled = False
        End If
    End Sub

    Private Sub pdcDocumento_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        Total = 0
        TotalFilas = 0
        NroPaginas = 1
        NroFilasTotales = 0
        TotalFilasLV = lvTabla.Items.Count - 1
        ppdVistaPrevia.Document = pdcDocumento
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString("DIRECCION DE SALUD LA LIBERTAD", FuenteE, Pincel, 40, Y)
            .DrawString("TESORERIA", FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            Y = Y + 10
            .DrawString("UNIDAD DE ECONOMIA", FuenteE, Pincel, 80, Y)

            Y = Y + 40
           
            .DrawString("REPORTE DE FACTURACION ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString, Fuente, Pincel, 20, Y)
              
            Y = Y + 10
            .DrawString("------------------------------------------------------------------------------------", Fuente, Pincel, 10, Y)
        End With
    End Sub

    Private Sub pdcDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Dim Filas As Integer = 0
        Y = 20
        Encabezado(e)
        Filas = 10
        NroFilasHoja = 0
        Y = Y + 40
        With e.Graphics
            .DrawString("Fecha", FuenteE, Pincel, 30, Y)
            .DrawString("Documento", FuenteE, Pincel, 120, Y)
            .DrawString("RUC", FuenteE, Pincel, 250, Y)
            .DrawString("Razon Social", FuenteE, Pincel, 360, Y)
            .DrawString("Total", FuenteE, Pincel, 650, Y)
            .DrawString("FecCancelado", FuenteE, Pincel, 720, Y)
            Y = Y + 10
            .DrawString(StrDup(116, "-"), FuenteE, Pincel, 0, Y)
            Y = Y + 10
            Do While NroFilasTotales <= TotalFilasLV
                If TipoImpresion = "PENDIENTES" Then
                    If lvTabla.Items(NroFilasTotales).SubItems(10).Text = "" Then Total = Total + Val(lvTabla.Items(NroFilasTotales).SubItems(9).Text) : TotalFilas += 1
                Else
                    Total = Total + Val(lvTabla.Items(NroFilasTotales).SubItems(9).Text)
                    TotalFilas += 1
                End If
                .DrawString(lvTabla.Items(NroFilasTotales).SubItems(1).Text, FuenteE, Pincel, 20, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvTabla.Items(NroFilasTotales).SubItems(12).Text, 3), FuenteE, Pincel, 100, Y)
                .DrawString(lvTabla.Items(NroFilasTotales).SubItems(5).Text & "-" & lvTabla.Items(NroFilasTotales).SubItems(6).Text, FuenteE, Pincel, 140, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvTabla.Items(NroFilasTotales).SubItems(2).Text & StrDup(11, " "), 11), FuenteE, Pincel, 230, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvTabla.Items(NroFilasTotales).SubItems(3).Text & StrDup(30, " "), 30), FuenteE, Pincel, 320, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & lvTabla.Items(NroFilasTotales).SubItems(9).Text, 10), FuenteE, Pincel, 620, Y)
                .DrawString(lvTabla.Items(NroFilasTotales).SubItems(10).Text, FuenteE, Pincel, 710, Y)

                Y = Y + 10
                NroFilasHoja += 1
                If NroFilasHoja >= 80 Then
                    Exit Do
                End If
                NroFilasTotales += 1
            Loop
            If NroFilasHoja >= 80 Then
                e.HasMorePages = True
                NroFilasHoja = 0
            Else
                e.HasMorePages = False
                .DrawString(StrDup(116, "-"), FuenteE, Pincel, 0, Y)
                Y = Y + 10
                .DrawString("TOTAL ==> " & TotalFilas & StrDup(4, " ") & "S/ " & Microsoft.VisualBasic.Format(Val(Total), "#,#0.#00"), FuenteE, Pincel, 354, Y)
            End If
        End With
    End Sub

    Private Sub btnImprimirP_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirP.Click
        TipoReporte = "PENDIENTES"
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub btnImprimirT_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirT.Click
        TipoReporte = "TODO"
        ppdVistaPrevia.ShowDialog()
    End Sub
End Class