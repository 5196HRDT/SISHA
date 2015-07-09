Public Class frmRepPacAseg
    Dim objFichaSOAT As New FichaSoat
    Dim objAseguradora As New Aseguradora
    Dim objEspecialidad As New Especialidad

    Dim TotalFilas As Integer
    Dim NroPag As Integer
    Dim I As Integer

    'Variables Impresion
    Dim Fuente As New Font("Courier New", 12, FontStyle.Bold)
    Dim FuenteE As New Font("Courier New", 10)
    Dim FuenteF As New Font("Courier New", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodo.CheckedChanged
        If chkTodo.Checked Then cboAseguradora.Text = "" : cboAseguradora.Enabled = False Else cboAseguradora.Enabled = True
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lvDet.Items.Clear()
        Dim Fila As ListViewItem
        Dim Total As Double
        Dim dsTab As New Data.DataSet
        Dim Tipo As String
        If chkTodo.Checked And chkTodoS.Checked Then Tipo = 1
        If Not chkTodo.Checked And chkTodoS.Checked Then Tipo = 0
        If Not chkTodo.Checked And Not chkTodoS.Checked Then Tipo = 2

        lblTotal1.Text = "0.00"
        lblTotal2.Text = "0.00"
        lblTotal3.Text = "0.00"
        dsTab = objFichaSOAT.ReporteAseguradora(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), cboAseguradora.Text, cboEspecialidad.Text, Tipo)

        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            If dsTab.Tables(0).Rows(I)("FechaAnulado").ToString = "" Then
                Fila = lvDet.Items.Add(dsTab.Tables(0).Rows(I)("Aseguradora"))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Fecha"))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Servicio"))
                If dsTab.Tables(0).Rows(I)("FAlta").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FAlta"))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Farmacia"))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("MontoProcedimiento"))
                'If dsTab.Tables(0).Rows(I)("MontoProcedimiento").ToString = "" Then Fila.SubItems.Add("0") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("MontoProcedimiento"))
                'If dsTab.Tables(0).Rows(I)("MontoProcedimiento").ToString = "" Then Total = Val(dsTab.Tables(0).Rows(I)("Farmacia")) Else Total = Val(dsTab.Tables(0).Rows(I)("Farmacia")) + Val(dsTab.Tables(0).Rows(I)("MontoProcedimiento"))
                Fila.SubItems.Add(Total)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdSoat"))

                lblTotal1.Text = Val(lblTotal1.Text) + Val(dsTab.Tables(0).Rows(I)("Farmacia"))
                lblTotal2.Text = Val(lblTotal2.Text) + Val(dsTab.Tables(0).Rows(I)("MontoProcedimiento"))
                lblTotal3.Text = Val(lblTotal3.Text) + Val(Total)
            End If
        Next
    End Sub

    Private Sub frmRepPacAseg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Aseguradora
        Dim dsAseguradora As New Data.DataSet
        dsAseguradora = objAseguradora.Combo
        cboAseguradora.DataSource = dsAseguradora.Tables(0)
        cboAseguradora.DisplayMember = "RazonSocial"
        cboAseguradora.ValueMember = "IdAseguradora"

        'Especialidad
        Dim dsEsp As New Data.DataSet
        dsEsp = objEspecialidad.Combo("%")
        cboEspecialidad.DataSource = dsEsp.Tables(0)
        cboEspecialidad.DisplayMember = "Descripcion"
        cboEspecialidad.ValueMember = "IdDpto"
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        TotalFilas = lvDet.Items.Count - 1
        NroPag = 1
        I = 0
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        pdcDocumento.DefaultPageSettings.Landscape = True
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0


        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Aseguradora As String
        Dim Fecha As String
        Dim Historia As String
        Dim Paciente As String
        Dim Servicio As String
        Dim FAlta As String
        Dim MontoFar As String
        Dim MontoPro As String
        Dim Total As String
        Dim NPre As String
        Dim NroFila As Integer = 0

        Y = 10
        Filas = 10
        With e.Graphics
            .DrawString("HOSPITAL REGIONAL" & StrDup(108, " ") & "UNIDAD DE SOAT", FuenteF, Pincel, 50, Y)
            Y = Y + 15
            .DrawString("DOCENTE - TRUNILLO", FuenteF, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("REPORTE DE PACIENTES POR ASEGURADORA" & StrDup(60, " ") & "Pag. " & NroPag, FuenteF, Pincel, 300, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 240, Y, 600, Y)
            Y = Y + 20
            .DrawString("    Aseguradora           Fecha     Historia   Paciente             Servicio     Liqui    FAlta      MontFar     MontoPro     Total", FuenteF, Pincel, 50, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 20, Y, 1000, Y)
            Y = Y + 15
            Do While TotalFilas >= 0
                Aseguradora = lvDet.Items(I).SubItems(0).Text
                If lvDet.Items(I).SubItems(1).Text.Length > 10 Then Fecha = Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(1).Text, 10) Else Fecha = lvDet.Items(I).SubItems(1).Text
                Historia = lvDet.Items(I).SubItems(2).Text
                Paciente = lvDet.Items(I).SubItems(3).Text
                Servicio = lvDet.Items(I).SubItems(4).Text
                FAlta = lvDet.Items(I).SubItems(5).Text
                MontoFar = Microsoft.VisualBasic.Format(Val(lvDet.Items(I).SubItems(6).Text), "#0.00")
                MontoPro = Microsoft.VisualBasic.Format(Val(lvDet.Items(I).SubItems(7).Text), "#0.00")
                Total = Microsoft.VisualBasic.Format(Val(lvDet.Items(I).SubItems(8).Text), "#0.00")
                NPre = Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(9).Text & StrDup(8, " "), 8)


                I += 1
                .DrawString(Microsoft.VisualBasic.Right(StrDup(5, " ") & I.ToString, 5), FuenteF, Pincel, 1, Y)
                .DrawString(Microsoft.VisualBasic.Left(Aseguradora & StrDup(20, " "), 20), FuenteF, Pincel, 60, Y)
                .DrawString(Fecha, FuenteF, Pincel, 220, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(8, " ") & Historia, 8), FuenteF, Pincel, 300, Y)
                .DrawString(Microsoft.VisualBasic.Left(Paciente & StrDup(20, " "), 20), FuenteF, Pincel, 360, Y)
                .DrawString(Microsoft.VisualBasic.Left(Servicio & StrDup(10, " "), 10), FuenteF, Pincel, 520, Y)
                .DrawString(NPre, FuenteF, Pincel, 620, Y)
                .DrawString(Microsoft.VisualBasic.Left(FAlta & StrDup(10, " "), 10), FuenteF, Pincel, 660, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & MontoFar, 10), FuenteF, Pincel, 720, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & MontoPro, 10), FuenteF, Pincel, 800, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Total, 10), FuenteF, Pincel, 880, Y)
                Y = Y + 15
                NroFila += 1
                TotalFilas -= 1
                If NroFila = 46 Then Exit Do
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

                .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lblTotal1.Text), "#.00"), 10), FuenteF, Pincel, 700, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lblTotal2.Text), "#0.00"), 10), FuenteF, Pincel, 800, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lblTotal3.Text), "#0.00"), 10), FuenteF, Pincel, 880, Y)
            End If
        End With
    End Sub

    Private Sub chkTodoS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodoS.CheckedChanged
        If chkTodoS.Checked Then cboEspecialidad.Enabled = False Else cboEspecialidad.Enabled = True
    End Sub
End Class