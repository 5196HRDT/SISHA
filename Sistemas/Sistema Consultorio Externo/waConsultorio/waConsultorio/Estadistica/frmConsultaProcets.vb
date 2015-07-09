Imports Microsoft.Office.Interop

Public Class frmConsultaProcets

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmConsultaProcets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Dim objProcets As New clsProcets
        Dim dsProcets As New DataSet
        Dim I As Integer
        Dim Fila As ListViewItem
        lvTabla1.Items.Clear()
        lvTabla2.Items.Clear()
        lvTabla3.Items.Clear()
        lvTabla4.Items.Clear()
        lvTabla5.Items.Clear()
        lvTabla6.Items.Clear()

        dsProcets = objProcets.Mostrar(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 1)
        For I = 0 To dsProcets.Tables(0).Rows.Count - 1
            Fila = lvTabla1.Items.Add(dsProcets.Tables(0).Rows(I)("FechaTomaMuestra"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Descripcion"))
        Next

        dsProcets = objProcets.Mostrar(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 2)
        For I = 0 To dsProcets.Tables(0).Rows.Count - 1
            Fila = lvTabla2.Items.Add(dsProcets.Tables(0).Rows(I)("FechaTomaMuestra"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Descripcion"))
        Next

        dsProcets = objProcets.Mostrar(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 3)
        For I = 0 To dsProcets.Tables(0).Rows.Count - 1
            Fila = lvTabla3.Items.Add(dsProcets.Tables(0).Rows(I)("FechaTomaMuestra"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Descripcion"))
        Next

        dsProcets = objProcets.Mostrar(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 4)
        For I = 0 To dsProcets.Tables(0).Rows.Count - 1
            Fila = lvTabla4.Items.Add(dsProcets.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Sexo"))
        Next

        dsProcets = objProcets.Mostrar(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 5)
        For I = 0 To dsProcets.Tables(0).Rows.Count - 1
            Fila = lvTabla5.Items.Add(dsProcets.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Sexo"))
        Next

        dsProcets = objProcets.Mostrar(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, 6)
        For I = 0 To dsProcets.Tables(0).Rows.Count - 1
            Fila = lvTabla6.Items.Add(dsProcets.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsProcets.Tables(0).Rows(I)("Sexo"))
        Next
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
            .Range("A2:L2").Value = "REPORTE PROCETS TABLA 01 ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
            .Range("A2:L2").Value = "REPORTE PROCETS TABLA 02 ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
            For Each c As ColumnHeader In lvTabla2.Columns
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
            For Each reg As ListViewItem In lvTabla2.Items
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As ColumnHeader In lvTabla2.Columns
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

    Private Sub btnExportar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar3.Click
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
            .Range("A2:L2").Value = "REPORTE PROCETS TABLA 03 ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
            For Each c As ColumnHeader In lvTabla3.Columns
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
            For Each reg As ListViewItem In lvTabla3.Items
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As ColumnHeader In lvTabla3.Columns
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

    Private Sub btnExportar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar4.Click
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
            .Range("A2:L2").Value = "REPORTE PROCETS TABLA 04 ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
            For Each c As ColumnHeader In lvTabla4.Columns
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
            For Each reg As ListViewItem In lvTabla4.Items
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As ColumnHeader In lvTabla4.Columns
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

    Private Sub btnExportar5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar5.Click
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
            .Range("A2:L2").Value = "REPORTE PROCETS TABLA 05 ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
            For Each c As ColumnHeader In lvTabla5.Columns
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
            For Each reg As ListViewItem In lvTabla5.Items
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As ColumnHeader In lvTabla5.Columns
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

    Private Sub btnExportar6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar6.Click
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
            .Range("A2:L2").Value = "REPORTE PROCETS TABLA 06 ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
            For Each c As ColumnHeader In lvTabla6.Columns
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
            For Each reg As ListViewItem In lvTabla6.Items
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As ColumnHeader In lvTabla6.Columns
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
End Class