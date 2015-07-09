Imports Microsoft.Office.Interop

Public Class frmReporte
    Dim objIngreso As New clsEmergenciaIngreso

    Private Sub btnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrar.Click
        Dim dsVer As New DataSet
        dsVer = objIngreso.ReporteGeresa(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        Dim I As Integer
        Dim Fila As ListViewItem
        lvTabla.Items.Clear()
        lvFaltante.Items.Clear()
        lvTabla.BeginUpdate()
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            'If dsVer.Tables(0).Rows(I)("Historia") = "1159698" Then
            '    MsgBox("H")
            'End If
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaIngreso"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraIngreso"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
            If Val(dsVer.Tables(0).Rows(I)("Edad")) > 0 Then
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Edad"))
                Fila.SubItems.Add("A")
            ElseIf Val(dsVer.Tables(0).Rows(I)("EdadM")) > 0 Then
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("EdadM"))
                Fila.SubItems.Add("M")
            ElseIf Val(dsVer.Tables(0).Rows(I)("EdadD")) > 0 Then
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("EdadD"))
                Fila.SubItems.Add("D")
            ElseIf Val(dsVer.Tables(0).Rows(I)("EdadD")) = 0 Then
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("EdadD"))
                Fila.SubItems.Add("D")
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("EstadoCivil"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Doc_Identidad").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cama"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Direccion").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DptoRes").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ProvRes").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DisRes").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DptoPro").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ProvPro").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DistPro").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Conyuge").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Motivo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Medico"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cie1"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DesCie1"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DesCie2"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Observacion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SalaObservacion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaAlta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraAlta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cie1Alta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Des1Alta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cie2Alta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Des2Alta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cie3Alta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Des3Alta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAlta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("CondicionAlta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Destino"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("MedicoAlta"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoEmergencia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DesDestino"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("MotivoCr"))

        Next
        lvTabla.EndUpdate()
        lblTotalE.Text = "Total de Historia Clínicas Trabajadas: " & lvTabla.Items.Count

        'En Blanco
        dsVer = objIngreso.ReporteGeneralBlanco(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        lvFaltante.BeginUpdate()
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvFaltante.Items.Add(dsVer.Tables(0).Rows(I)("Historia").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaIngreso").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraIngreso").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Edad").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("EdadM").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("EdadD").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Doc_Identidad").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Direccion").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DptoRes").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ProvRes").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DisRes").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DptoPro").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ProvPro").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DistPro").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Medico").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SalaObservacion").ToString)
        Next

        lvFaltante.EndUpdate()
        lblTotalF.Text = "Total de Historia Clínicas Trabajadas: " & lvFaltante.Items.Count
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
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
            .Range("A2:L2").Value = "REPORTE ESTADISTICO EMERGENCIA ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
                    ' acá debería realizarse la carga  '
                    'If (c.Index <> 44) Then
                    .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.SubItems(c.Index).Text) '
                    '          MessageBox.Show(c.Index)
                    '                  End If

                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
        End With
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            lblEtiqueta.Text = lvTabla.SelectedItems(0).Index & " de " & lvTabla.Items.Count - 1
        End If
    End Sub

    Private Sub frmReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTotalE.Text = "Total de Historia Clínicas Trabajadas: 0"
        lblTotalF.Text = "Total de Historia Clínicas Trabajadas: 0"
    End Sub

    Private Sub btnExcel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel1.Click
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
            .Range("A2:L2").Value = "REPORTE EMERGENCIAS EN BLANCO ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
            For Each c As ColumnHeader In lvFaltante.Columns
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
            For Each reg As ListViewItem In lvFaltante.Items
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As ColumnHeader In lvFaltante.Columns
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