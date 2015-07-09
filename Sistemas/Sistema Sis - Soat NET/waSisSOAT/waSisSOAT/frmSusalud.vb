Imports Microsoft.Office.Interop
Public Class frmSusalud
    Private DT As New DataTable
    Private dsRep As New DataSet
    Private objSis As New SIS
    Private Sub frmSusalud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        cboMes.SelectedIndex = 0
        cboanio.SelectedIndex = 1
    End Sub
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Me.Enabled = False
        Dim mes, anio As String
        mes = cboMes.SelectedItem
        anio = Convert.ToInt16(cboanio.SelectedItem)
        dsRep = objSis.ConsultarSusalud(mes, anio)
        DT = dsRep.Tables(0)
        If DT Is Nothing Then MessageBox.Show("NO DATA!!!", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            exHoja.Name = "REPORTE"
            With exHoja
                .Visible = Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A1:I1").Merge()
                .Range("A1:I1").Value = "HOSPITAL REGIONAL DOCENTE DE TRUJILLO"
                .Range("A1:I1").Font.Bold = True
                .Range("A1:I1").Font.Size = 16
                .Range("A2:I2").Merge()
                .Range("A2:I2").Value = "REPORTE SUSALUD  DE " & cboMes.SelectedItem & " " & cboanio.SelectedItem
                .Range("A2:I2").Font.Bold = True
                .Range("A2:I2").Font.Size = 12
            End With
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = DT.Columns.Count
            Dim NRow As Integer = DT.Rows.Count
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(4, i) = DT.Columns(i - 1).ColumnName.ToString
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 5, Col + 1) = DT.Rows(Fila).Item(Col).ToString()
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
            MessageBox.Show("Proceso Completo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "REPORTE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Enabled = True
    End Sub
End Class