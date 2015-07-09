Imports Microsoft.Office.Interop
Public Class frmEpidemiologia
    Private Sub frmEpidemiologia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Dim objInforme As New clsInforme
        Dim dsTabla As New DataSet
        dsTabla = objInforme.ConsultaEpi(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        Dim I As Integer
        Dim Fila As ListViewItem
        lvTabla.Items.Clear()
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTabla.Tables(0).Rows(I)("NroRegistro"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("FIngreso"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cama"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TipoPaciente"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("FEntrega"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Formato"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Organo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TipoMuestra"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cuerpo1").ToString.Replace(vbLf, " "))
        Next
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            .Range("A1:L1").Merge()
            .Range("A1:L1").Value = "HOSPITAL REGIONAL DOCENTE DE TRUJILLO"
            .Range("A1:L1").Font.Bold = True
            .Range("A1:L1").Font.Size = 15
            'Copete  
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = "REPORTE DE ATENCIONES PATOLOGIA ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As ColumnHeader In lvTabla.Columns
                'If c.Visible Then
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                strColumna = LetraIzq + Letra + Numero.ToString
                objCelda = .Range(strColumna, Type.Missing)
                objCelda.Value = c.Text
                objCelda.EntireColumn.Font.Size = 8
            Next
            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1
            For Each reg As ListViewItem In lvTabla.Items
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As ColumnHeader In lvTabla.Columns
                    'If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra
                    .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.SubItems(c.Index).Text)
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
        End With
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub
End Class