Public Class frmCuposAsignados
    Dim objCupo As New Cupo
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
    Dim hora As String
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Dim dsCupo As New DataSet
        Dim I As Integer
        Dim Fila As ListViewItem
        Try
            dsCupo = objCupo.ReporteCuposSISFecha(dtpFecha.Value.ToShortDateString)
            hora = dsCupo.Tables(0).Rows(0)("hora")
            lvTabla.Items.Clear()
            Dim Servicio As String
            For I = 0 To dsCupo.Tables(0).Rows.Count - 1
                If I = 0 Then
                    Servicio = dsCupo.Tables(0).Rows(I)("SubEspecialidad")
                Else
                    If Servicio <> dsCupo.Tables(0).Rows(I)("SubEspecialidad") Then
                        Servicio = dsCupo.Tables(0).Rows(I)("SubEspecialidad")
                        Fila = lvTabla.Items.Add("")
                        Fila.SubItems.Add("------------------------------")
                        Fila.SubItems.Add("------------------------------")
                        Fila.SubItems.Add("")
                        Fila.SubItems.Add("")
                        Fila.SubItems.Add("------------------------------")
                    End If
                End If
                Fila = lvTabla.Items.Add(dsCupo.Tables(0).Rows(I)("IdCupo"))
                Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("SubEspecialidad"))
                Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("NomMedico").ToString)
                Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("Turno"))
                Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("NHistoria"))
                Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("Paterno") & " " & dsCupo.Tables(0).Rows(I)("Materno") & " " & dsCupo.Tables(0).Rows(I)("Nombres"))
            Next
        Catch ex As Exception
            Return
        End Try
        
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Val(hora) >= 12 Then
            ppdVistaPrevia.ShowDialog()
            If MessageBox.Show("Esta seguro de Haber Impreso Correctamente la Lista de Pacientes?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim I As Integer
                For I = 0 To lvTabla.Items.Count - 1
                    objCupo.ImpresionSIS(lvTabla.Items(I).SubItems(0).Text, dtpFecha.Value.ToShortDateString)
                Next
                lvTabla.Items.Clear()
            End If
        Else : MessageBox.Show("AHORA NO JOVEN, AUN NO ES HORA!!.. " + vbCrLf + "SR. " + NombreUsuario + " - SEA PACIENTE", "Mensaje Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        Linea = 0
        NroPag = 1
        NroFila = 0
        TotalFilas = lvTabla.Items.Count - 1
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
            .DrawString("CUPOS PROGRAMADOS PARA PACIENTES SIS EL " & dtpFecha.Value.ToShortDateString, Fuente, Pincel, 60, Y)
            Y = Y + 20
            .DrawLine(Pens.Black, 60, Y, 580, Y)
        End With
    End Sub
    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20
        Encabezado(e)
        Filas = 10
        Y = Y + 40
        With e.Graphics
            .DrawString("Servicio", FuenteE, Pincel, 30, Y)
            .DrawString("Medico", FuenteE, Pincel, 220, Y)
            .DrawString("Turno", FuenteE, Pincel, 420, Y)
            .DrawString("Historia", FuenteE, Pincel, 480, Y)
            .DrawString("Paciente", FuenteE, Pincel, 560, Y)
            Y = Y + 10
            .DrawLine(Pens.Black, 20, Y, 800, Y)
            Y = Y + 10
            Do While TotalFilas >= 0
                .DrawString(Microsoft.VisualBasic.Left(lvTabla.Items(Linea).SubItems(1).Text & StrDup(25, " "), 25), FuenteE, Pincel, 30, Y)
                .DrawString(lvTabla.Items(Linea).SubItems(2).Text, FuenteE, Pincel, 220, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvTabla.Items(Linea).SubItems(3).Text, 3), FuenteE, Pincel, 430, Y)
                .DrawString(lvTabla.Items(Linea).SubItems(4).Text, FuenteE, Pincel, 480, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvTabla.Items(Linea).SubItems(5).Text & StrDup(36, " "), 36), FuenteE, Pincel, 560, Y)
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
                .DrawLine(Pens.Black, 20, Y, 800, Y)
                Y = Y + 4
                .DrawLine(Pens.Black, 20, Y, 800, Y)
            End If
        End With
    End Sub
    Private Sub dtpFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then btnMostrar_Click(sender, e)
    End Sub
End Class