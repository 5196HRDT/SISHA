Public Class frmConsultaPacAten
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

    Private Function DameMes() As String
        Select Case cboMes.Text
            Case "ENERO"
                Return 1
            Case "FEBRERO"
                Return 2
            Case "MARZO"
                Return 3
            Case "ABRIL"
                Return 4
            Case "MAYO"
                Return 5
            Case "JUNIO"
                Return 6
            Case "JULIO"
                Return 7
            Case "AGOSTO"
                Return 8
            Case "SEPTIEMBRE"
                Return 9
            Case "OCTUBRE"
                Return 10
            Case "NOVIEMBRE"
                Return 11
            Case "DICIEMBRE"
                Return 12
        End Select
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        Dim Especialidad As String
        Dim SubEspecialidad As String
        lvDet.Items.Clear()
        lblTotal.Text = 0
        dsTabla = objSis.PacientesAtendidos(DameMes, cboAño.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            Dim I As Integer
            Dim Fila As New ListViewItem
            Dim Cant As Integer = 0
            For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                
                If I = 0 Then
                    Especialidad = dsTabla.Tables(0).Rows(I)("Especialidad")
                    SubEspecialidad = dsTabla.Tables(0).Rows(I)("SubEspecialidad")
                    Cant = 1
                    Fila = lvDet.Items.Add(Especialidad)
                    Fila.SubItems.Add(SubEspecialidad)
                    Fila.SubItems.Add(Cant)
                Else
                    If Especialidad <> dsTabla.Tables(0).Rows(I)("Especialidad") Then
                        Especialidad = dsTabla.Tables(0).Rows(I)("Especialidad")
                        SubEspecialidad = dsTabla.Tables(0).Rows(I)("SubEspecialidad")
                        Cant = 1
                        Fila = lvDet.Items.Add(Especialidad)
                        Fila.SubItems.Add(SubEspecialidad)
                        Fila.SubItems.Add(Cant)
                    ElseIf SubEspecialidad <> dsTabla.Tables(0).Rows(I)("SubEspecialidad") Then
                        Especialidad = dsTabla.Tables(0).Rows(I)("Especialidad")
                        SubEspecialidad = dsTabla.Tables(0).Rows(I)("SubEspecialidad")
                        Cant = 1
                        Fila = lvDet.Items.Add("")
                        Fila.SubItems.Add(SubEspecialidad)
                        Fila.SubItems.Add(Cant)
                    Else
                        lvDet.Items(lvDet.Items.Count - 1).SubItems(2).Text = Val(lvDet.Items(lvDet.Items.Count - 1).SubItems(2).Text) + 1
                    End If
                End If
                lblTotal.Text = Val(lblTotal.Text) + 1
            Next
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If MessageBox.Show("Esta seguro de Imprimir Reporte Diario", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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

            .DrawString("REPORTE DE ATENCIONES DEL SIS: AÑO " & cboAño.Text & " MES " & cboMes.Text, Fuente, Pincel, 60, Y)
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
            .DrawString("Servicio", FuenteE, Pincel, 30, Y)
            .DrawString("SubServicio", FuenteE, Pincel, 340, Y)
            .DrawString("Cant", FuenteE, Pincel, 620, Y)
            Y = Y + 10
            .DrawString(StrDup(116, "-"), FuenteE, Pincel, 0, Y)
            Y = Y + 10
            Do While TotalFilas >= 0
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(Linea).SubItems(0).Text & StrDup(40, " "), 40), FuenteE, Pincel, 30, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(Linea).SubItems(1).Text & StrDup(40, " "), 40), FuenteE, Pincel, 340, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(5, " ") & lvDet.Items(Linea).SubItems(2).Text, 5), FuenteE, Pincel, 620, Y)
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
                .DrawString("TOTAL DE ATENCIONES: " & lblTotal.Text, FuenteE, Pincel, 500, Y)
            End If
        End With
    End Sub

    Private Sub frmConsultaPacAten_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboAño.Text = Year(Date.Now)
        cboMes.Text = Microsoft.VisualBasic.Format(Date.Now, "MMMM")
    End Sub
End Class