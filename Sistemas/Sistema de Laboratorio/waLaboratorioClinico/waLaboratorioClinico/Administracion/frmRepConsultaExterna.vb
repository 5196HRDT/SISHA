Imports Microsoft.Office.Interop
Public Class frmRepConsultaExterna
    Dim objConsulta As New clsConsultaExterna

    Private Sub frmRepConsultaExterna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAño.Value = Date.Now.Year
        cboMes.Text = DameMes(Date.Now.Month)
        cboTipo.Text = "COMUN"
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        lvTabla.Items.Clear()
        lvTabla1.Items.Clear()
        Dim dsVer As New DataSet
        'Detallado
        dsVer = objConsulta.ReporteLab1(DameNumeroMes(cboMes.Text), txtAño.Value, cboTipo.Text)
        If dsVer.Tables(0).Rows.Count > 0 Then
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Total"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Next
        End If
        'Total
        dsVer = objConsulta.ReporteLab2(DameNumeroMes(cboMes.Text), txtAño.Value)
        If dsVer.Tables(0).Rows.Count > 0 Then
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla1.Items.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Total"))
            Next
        End If
    End Sub

    Private Sub cboMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMes.SelectedIndexChanged
        If cboMes.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objConsulta.ReporteLabTipoPac(DameNumeroMes(cboMes.Text), txtAño.Value)
            If dsVer.Tables(0).Rows.Count > 0 Then
                cboTipo.DataSource = dsVer.Tables(0)
                cboTipo.DisplayMember = "TipoPaciente"
                cboTipo.ValueMember = "TipoPaciente"
            End If
        End If
    End Sub

    Private Sub btnExportar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar1.Click
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
            .Range("A2:L2").Value = "REPORTE PRODUCCION DE LABORATORIO DE EMERGENCIA TIPO DE PACIENTE " & cboTipo.Text & " " & cboMes.Text & " - " & txtAño.Value
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
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
                    ' acá debería realizarse la carga  
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

    Private Sub btnExportar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar2.Click
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
            .Range("A2:L2").Value = "REPORTE CONSOLIDADO DE LABORATORIO DE EMERGENCIA " & cboMes.Text & " - " & txtAño.Value
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
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
            For Each c As ColumnHeader In lvTabla1.Columns
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
            For Each reg As ListViewItem In lvTabla1.Items
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As ColumnHeader In lvTabla1.Columns
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
                    ' acá debería realizarse la carga  
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

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class