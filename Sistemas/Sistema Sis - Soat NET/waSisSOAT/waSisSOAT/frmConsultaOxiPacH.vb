Public Class frmConsultaOxiPacH
    Dim objHistoria As New Historia
    Dim objHospitalizacion As New Hospitalizacion


    Dim FuenteE As New Font("Lucida Console", 8, FontStyle.Bold)
    Dim FuenteTitulo As New Font("Lucida Console", 14)
    Dim FuenteCab As New Font("Lucida Console", 10)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim Linea As Integer
    Dim NroFila As Integer
    Dim TotalFilas As Integer
    Dim NroPagina As Integer

    Dim I As Integer
    Dim Fila As ListViewItem

    Private Sub frmConsultaOxiPacH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            Dim dsHistoria As New Data.DataSet
            dsHistoria = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsHistoria.Tables(0).Rows.Count > 0 Then
                lblPaciente.Text = dsHistoria.Tables(0).Rows(0)("Apaterno") & " " & dsHistoria.Tables(0).Rows(0)("Amaterno") & " " & dsHistoria.Tables(0).Rows(0)("Nombres")
                lblTotal.Text = "0.00"
                lvTabla.Items.Clear()
                Dim dsHosp As New Data.DataSet
                dsHosp = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
                If dsHosp.Tables(0).Rows.Count > 0 Then
                    Dim dsDet As New Data.DataSet
                    dsDet = objHospitalizacion.BuscarDetAtencionSer(txtHistoria.Text)
                    For I = 0 To dsDet.Tables(0).Rows.Count - 1
                        If chkOxigeno.Checked = False Then
                            Fila = lvTabla.Items.Add(dsDet.Tables(0).Rows(I)("Descripcion"))
                            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Cantidad")), "#.00"))
                            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Precio")), "#.00"))
                            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Importe")), "#.00"))
                            lblTotal.Text = Val(lblTotal.Text) + Val(dsDet.Tables(0).Rows(I)("Importe"))
                        Else
                            If Microsoft.VisualBasic.Left(dsDet.Tables(0).Rows(I)("Descripcion"), 3) = "OXI" Then
                                Fila = lvTabla.Items.Add(dsDet.Tables(0).Rows(I)("Descripcion"))
                                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Cantidad")), "#.00"))
                                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Precio")), "#.00"))
                                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Importe")), "#.00"))
                                lblTotal.Text = Val(lblTotal.Text) + Val(dsDet.Tables(0).Rows(I)("Importe"))
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("Paciente no registra hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblPaciente.Text = ""
                    lvTabla.Items.Clear()
                    txtHistoria.Select()
                End If

            Else
                MessageBox.Show("Historia Clinica No Existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblPaciente.Text = ""
                lvTabla.Items.Clear()
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub pdCostos_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdCostos.BeginPrint
        Linea = 0
        NroPagina = 1
        NroFila = 0
        TotalFilas = lvTabla.Items.Count - 1
    End Sub

    Private Sub pdCostos_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdCostos.PrintPage
        Dim I As Integer
        Dim Y As Integer = 80

        e.Graphics.DrawString("Hospital Regional Docente de Trujillo                                        Unidad de Seguros", FuenteE, Brushes.Black, 20, 30)
        Y = Y + 15
        e.Graphics.DrawString("REPORTE DE PROCEDIMIENTOS - HOSPITALIZACION", FuenteCab, Brushes.Black, 20, 80)
        Y = Y + 1
        e.Graphics.DrawLine(Pens.Black, 20, Y, 450, Y)
        Y = Y + 15

        e.Graphics.DrawString("PACIENTE: " & txtHistoria.Text & " - " & lblPaciente.Text, FuenteCab, Brushes.Black, 20, Y)
        Y = Y + 20
        e.Graphics.DrawString("FECHA   : " & Date.Now, FuenteCab, Brushes.Black, 20, Y)

        Y = Y + 20
        e.Graphics.DrawString("Procedimiento" & StrDup(32, " ") & "Precio" & StrDup(12, " ") & "Cant" & StrDup(8, " ") & "Importe", FuenteE, Brushes.Black, 40, Y)
        Y = Y + 12
        e.Graphics.DrawLine(Pens.Black, 20, Y, 700, Y)
        Y = Y + 8
        Do While Linea <= TotalFilas
            Y = Y + 10
            e.Graphics.DrawString(Microsoft.VisualBasic.Left(lvTabla.Items.Item(Linea).SubItems(0).Text & StrDup(40, " "), 40) & StrDup(3, " ") & Microsoft.VisualBasic.Right(StrDup(9, " ") & Microsoft.VisualBasic.Format(Val(lvTabla.Items.Item(Linea).SubItems(1).Text), "###,###.00"), 9) & StrDup(3, " ") & StrDup(3, " ") & Microsoft.VisualBasic.Right(StrDup(9, " ") & lvTabla.Items.Item(Linea).SubItems(2).Text, 9) & StrDup(3, " ") & StrDup(3, " ") & Microsoft.VisualBasic.Right(StrDup(9, " ") & Microsoft.VisualBasic.Format(Val(lvTabla.Items.Item(Linea).SubItems(3).Text), "###,###.00"), 9), FuenteE, Brushes.Black, 40, Y)
            Linea += 1
            NroFila += 1
            If NroFila = 80 Then
                Exit Do
            End If
        Loop
        If NroFila < 80 Then
            Y = Y + 12
            e.Graphics.DrawLine(Pens.Black, 20, Y, 700, Y)
            Y = Y + 5
            e.Graphics.DrawString(StrDup(63, " ") & "TOTAL S/. " & Microsoft.VisualBasic.Right(StrDup(9, " ") & Microsoft.VisualBasic.Format(Val(lblTotal.Text), "###,###.00"), 9), FuenteE, Brushes.Black, 40, Y)
        End If
        If NroFila >= 80 Then
            e.HasMorePages = True
            NroFila = 0
        Else
            e.HasMorePages = False
        End If


    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If MessageBox.Show("Esta seguro de Imprimir Procedimientos", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ppdVistaPrevia.Document = pdCostos
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class