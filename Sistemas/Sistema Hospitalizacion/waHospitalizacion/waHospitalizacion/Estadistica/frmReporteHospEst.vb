Imports Microsoft.Office.Interop

Public Class frmReporteHospEst
    Dim objHospAnt As New Hospitalizacion
    Dim objHospitalizacion As New Ingreso
    Dim objEgreso As New Egreso
    Dim objEgresoCie As New EgresoCIE
    Dim objProcedimientos As New Procedimiento
    Dim objTemporal As New tempEstanciaHosp

    Dim objTipoAlta As New TipoAlta
    Dim objCondicionAlta As New CondicionAlta
    Dim objServicio As New Servicio
    Dim objSubServicio As New SubServicio
    Dim objEspecialidad As New Especialidad
    Dim objMedico As New Medico
    Dim objCIE As New CIE10
    Dim objCentro As New CentroSalud

    Private Sub ReporteHospEst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
        gbH.Visible = False
        gbConsulta.Visible = False

        'Tipo Alta
        Dim dsTipoAlta As New Data.DataSet
        dsTipoAlta = objTipoAlta.Buscar("Select * From TipoAlta")
        cboTipoAlta.DataSource = dsTipoAlta.Tables(0)
        cboTipoAlta.DisplayMember = "Descripcion"
        cboTipoAlta.ValueMember = "IdTipoAlta"

        'Condicion Alta
        Dim dsCondicionAlta As New Data.DataSet
        dsCondicionAlta = objCondicionAlta.Buscar("Select * From CondicionAlta")
        cboCondicionAlta.DataSource = dsCondicionAlta.Tables(0)
        cboCondicionAlta.DisplayMember = "Descripcion"
        cboCondicionAlta.ValueMember = "CodCondicion"

        'Servicio
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Combo("%")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdPiso"

        'Responsable
        Dim dsResponsable As New Data.DataSet
        dsResponsable = objMedico.BuscarTipoPersonal(1)
        cboResponsable.DataSource = dsResponsable.Tables(0)
        cboResponsable.DisplayMember = "Personal"
        cboResponsable.ValueMember = "IdMedico"

        'Enfermera
        Dim dsEnfermera As New Data.DataSet
        dsEnfermera = objMedico.BuscarTipoPersonal(2)
        cboEnfermera.DataSource = dsEnfermera.Tables(0)
        cboEnfermera.DisplayMember = "Personal"
        cboEnfermera.ValueMember = "IdMedico"

        'Centro Salud
        Dim dsCentro As New Data.DataSet
        dsCentro = objCentro.Combo
        cboReferido.DataSource = dsCentro.Tables(0)
        cboReferido.DisplayMember = "Descripcion"
        cboReferido.ValueMember = "IdCentro"
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        lvTabla.Items.Clear()
        lvDias.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim dsVer As New DataSet
        Dim SubEspAlta As String = ""
        Dim DiasEstancia As Integer = 0
        Dim Piso As String = ""
        objTemporal.Eliminar(My.Computer.Name)
        dsVer = objHospitalizacion.RepEstadistica(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, txtPaciente.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno") & " " & dsVer.Tables(0).Rows(I)("Amaterno") & " " & dsVer.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsVer.Tables(0).Rows(I)("Sexo"), 1))

            'Edad del Paciente
            Dim EdadA As String = 0
            Dim EdadM As String = 0
            Dim EdadD As String = 0

            If dsVer.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                EdadA = 0
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = dsVer.Tables(0).Rows(I)("Fecha")
                dinicio = dsVer.Tables(0).Rows(I)("FNacimiento")
                Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                Años = DateDiff("yyyy", dinicio, dfin)
                'Verificar Dias
                If Meses = 0 And Años = 0 Then
                    EdadA = 0
                    EdadM = 0
                    Dias = Math.Abs(Dias)
                    EdadD = Dias
                Else
                    If Dias < 0 Then
                        DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
                        Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
                        Meses = Meses - 1
                    End If
                    If Meses < 0 Then
                        Meses = 12 + Meses
                        Años = Años - 1
                    End If
                    EdadA = Años
                    EdadM = Meses
                    EdadD = Dias
                End If
            End If
            If EdadA > 0 Then
                Fila.SubItems.Add(EdadA)
                Fila.SubItems.Add("A")
            ElseIf EdadM > 0 Then
                Fila.SubItems.Add(EdadM)
                Fila.SubItems.Add("M")
            Else
                Fila.SubItems.Add(EdadD)
                Fila.SubItems.Add("D")
            End If
            'Fin de Edad Paciente

            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Departamento"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Provincia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Distrito"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Caserio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsVer.Tables(0).Rows(I)("FechaAlta").ToString & StrDup(10, " "), 10))

            'Datos de Alta
            If dsVer.Tables(0).Rows(I)("FechaAlta").ToString <> "" Then
                'Dias Estancia
                DiasEstancia = DateDiff("d", dsVer.Tables(0).Rows(I)("Fecha"), dsVer.Tables(0).Rows(I)("FechaAlta"))
                If DiasEstancia = 0 Then DiasEstancia = 1
                Fila.SubItems.Add(DiasEstancia)

                'If dsVer.Tables(0).Rows(I)("IdIngreso") = 200 Then
                '    MsgBox("HOLA")
                'End If

                Dim dsAlta As New DataSet
                dsAlta = objEgreso.RepEstadistica(dsVer.Tables(0).Rows(I)("IdIngreso"))
                If dsAlta.Tables(0).Rows.Count > 0 Then
                    Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("CondicionAlta"))
                    SubEspAlta = dsAlta.Tables(0).Rows(0)("SubEspecialidad")
                    Piso = dsAlta.Tables(0).Rows(0)("Piso")
                Else
                    Fila.SubItems.Add("")
                    SubEspAlta = ""
                    Piso = ""
                End If
            Else
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                SubEspAlta = ""
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubEspIng"))
            Fila.SubItems.Add(SubEspAlta)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Numero"))

            'Infecciones Intrahospitalaria
            Fila.SubItems.Add("")


            'Diagnosticos CIE
            Dim dsE As New DataSet
            Dim J As Integer = 0
            dsE = objEgresoCie.Buscar(dsVer.Tables(0).Rows(I)("IdIngreso"))
            For J = 0 To dsE.Tables(0).Rows.Count - 1
                Fila.SubItems.Add(dsE.Tables(0).Rows(J)("CIE"))
                Fila.SubItems.Add(dsE.Tables(0).Rows(J)("Descripcion"))
            Next
            For J = dsE.Tables(0).Rows.Count To 5
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            Next

            Dim dsP As New DataSet
            dsP = objProcedimientos.Buscar(dsVer.Tables(0).Rows(I)("IdIngreso"))
            For J = 0 To dsP.Tables(0).Rows.Count - 1
                Fila.SubItems.Add(dsP.Tables(0).Rows(J)("Codigo"))
                Fila.SubItems.Add(dsP.Tables(0).Rows(J)("Descripcion"))
            Next
            For J = dsP.Tables(0).Rows.Count To 5
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            Next
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdIngreso"))
            'objTemporal.Grabar(My.Computer.Name, Piso, dsVer.Tables(0).Rows(I)("SubEspIng"), DiasEstancia)
            objTemporal.Grabar(My.Computer.Name, Piso, SubEspAlta, DiasEstancia)
            Application.DoEvents()
            lblTotal.Text = "Total de Historia Procesadas: " & I.ToString & " de " & dsVer.Tables(0).Rows.Count - 1
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegistro"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdIngreso"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
        Next
        lblTotal.Text = "Total de Historia Procesadas: " & dsVer.Tables(0).Rows.Count.ToString

        Dim dsDias As New DataSet
        dsDias = objTemporal.Buscar(My.Computer.Name)
        For I = 0 To dsDias.Tables(0).Rows.Count - 1
            Fila = lvDias.Items.Add(dsDias.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsDias.Tables(0).Rows(I)("SubEspecialidad"))
            Fila.SubItems.Add(dsDias.Tables(0).Rows(I)("Total"))
        Next

    End Sub

    Private Sub btnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberar.Click
        If lvTabla.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de Liberar Alta de Paciente?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objEgreso.LiberarAlta(lvTabla.SelectedItems(0).SubItems(41).Text)
                btnMostrar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
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
            .Range("A2:L2").Value = "REPORTE ESTADISTICO HOSPITALIZACION ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
                'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                'If c. Is GetType(Decimal) OrElse c.DataType Is GetType(Double) Then
                ' objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                'End If
                'End If
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
                    If reg.SubItems(c.Index).Text = "1088159" Then
                        MsgBox("Hola")
                    End If
                    '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                    '.Range(strColumna + i, strColumna + i).In()  
                    'End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            'UltimoNumero = i
            ''Dibujar las líneas de las columnas  
            'LetraIzq = ""
            'cod_LetraIzq = Asc("A")
            'cod_letra = Asc(primeraLetra)
            'Letra = primeraLetra
            'For Each c As DataGridViewColumn In DataGridView1.Columns
            '    If c.Visible Then
            '        objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
            '        objCelda.BorderAround()
            '        If Letra = "Z" Then
            '            Letra = primeraLetra
            '            cod_letra = Asc(primeraLetra)
            '            LetraIzq = Chr(cod_LetraIzq)
            '            cod_LetraIzq += 1
            '        Else
            '            cod_letra += 1
            '            Letra = Chr(cod_letra)
            '        End If
            '    End If
            'Next
            'Dibujar el border exterior grueso  
            'Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            'objRango.Select()
            'objRango.Columns.AutoFit()
            'objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault

    End Sub

    Private Sub btnExportarDias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarDias.Click
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
            .Range("A2:L2").Value = "REPORTE ESTADISTICO DIAS DE ESTANCIA HOSPITALARIA ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString
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
            For Each c As ColumnHeader In lvDias.Columns
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
                'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                'If c. Is GetType(Decimal) OrElse c.DataType Is GetType(Double) Then
                ' objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                'End If
                'End If
            Next
            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1
            For Each reg As ListViewItem In lvDias.Items
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As ColumnHeader In lvDias.Columns
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
                    '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                    '.Range(strColumna + i, strColumna + i).In()  
                    'End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            'UltimoNumero = i
            ''Dibujar las líneas de las columnas  
            'LetraIzq = ""
            'cod_LetraIzq = Asc("A")
            'cod_letra = Asc(primeraLetra)
            'Letra = primeraLetra
            'For Each c As DataGridViewColumn In DataGridView1.Columns
            '    If c.Visible Then
            '        objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
            '        objCelda.BorderAround()
            '        If Letra = "Z" Then
            '            Letra = primeraLetra
            '            cod_letra = Asc(primeraLetra)
            '            LetraIzq = Chr(cod_LetraIzq)
            '            cod_LetraIzq += 1
            '        Else
            '            cod_letra += 1
            '            Letra = Chr(cod_letra)
            '        End If
            '    End If
            'Next
            'Dibujar el border exterior grueso  
            'Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            'objRango.Select()
            'objRango.Columns.AutoFit()
            'objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault

    End Sub

    Private Sub lvTabla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTabla.DoubleClick
        gbH.Visible = False
        lvCieAlta.Items.Clear()
        If lvTabla.SelectedItems.Count > 0 Then
            Dim dsAlta As New DataSet

            dsAlta = objEgreso.Buscar(lvTabla.SelectedItems(0).SubItems(43).Text)
            If dsAlta.Tables(0).Rows.Count > 0 Then
                dtpFecha.Value = dsAlta.Tables(0).Rows(0)("Fecha")
                txtHora.Text = dsAlta.Tables(0).Rows(0)("Hora")
                cboTipoAlta.Text = dsAlta.Tables(0).Rows(0)("TipoAlta")
                cboCondicionAlta.Text = dsAlta.Tables(0).Rows(0)("CondicionAlta")
                cboServicio.Text = dsAlta.Tables(0).Rows(0)("Servicio")
                cboServicio_SelectedIndexChanged(sender, e)
                cboSubServicio.Text = dsAlta.Tables(0).Rows(0)("SubServicio")
                cboSubServicio_SelectedIndexChanged(sender, e)
                cboEspecialidad.Text = dsAlta.Tables(0).Rows(0)("Especialidad")
                cboResponsable.Text = dsAlta.Tables(0).Rows(0)("Responsable")
                cboEnfermera.Text = dsAlta.Tables(0).Rows(0)("Enfermera")
                cboReferido.Text = dsAlta.Tables(0).Rows(0)("Referido")
                dtpFecha.Select()

                'Lista de CIE Alta
                Dim dsCIEAlta As New DataSet
                dsCIEAlta = objEgresoCie.Buscar(lvTabla.SelectedItems(0).SubItems(43).Text)
                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsCIEAlta.Tables(0).Rows.Count - 1
                    Fila = lvCieAlta.Items.Add(dsCIEAlta.Tables(0).Rows(I)("Cie"))
                    Fila.SubItems.Add(dsCIEAlta.Tables(0).Rows(I)("Descripcion"))
                Next

                gbH.Visible = True
            Else
                MessageBox.Show("Paciente no Presente Alta Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbH.Visible = False
    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboServicio.SelectedValue) Then cboSubServicio.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSubServicio As New Data.DataSet
            dsSubServicio = objSubServicio.Combo(cboServicio.SelectedValue.ToString)
            cboSubServicio.DataSource = dsSubServicio.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdSerHos"
        End If
    End Sub

    Private Sub cboSubServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubServicio.KeyDown
        If IsNumeric(cboSubServicio.SelectedValue) And e.KeyCode = Keys.Enter Then cboEspecialidad.Select()
    End Sub

    Private Sub cboSubServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubServicio.SelectedIndexChanged
        cboEspecialidad.Text = ""
        If IsNumeric(cboSubServicio.SelectedValue) Then
            Dim dsEspecialidad As New Data.DataSet
            dsEspecialidad = objEspecialidad.Buscar(cboSubServicio.SelectedValue)
            cboEspecialidad.DataSource = dsEspecialidad.Tables(0)
            cboEspecialidad.DisplayMember = "Descripcion"
            cboEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub cboEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEspecialidad.SelectedValue) Then cboResponsable.Select()
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged

    End Sub

    Private Sub cboResponsable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboResponsable.KeyDown
        If e.KeyCode = Keys.Enter And cboReferido.Enabled And IsNumeric(cboResponsable.SelectedValue) Then cboReferido.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And Not cboReferido.Enabled And IsNumeric(cboResponsable.SelectedValue) Then cboEnfermera.Select()
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged

    End Sub

    Private Sub cboReferido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboReferido.KeyDown
        If e.KeyCode = Keys.Enter Then cboEnfermera.Select()
    End Sub

    Private Sub cboReferido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReferido.SelectedIndexChanged

    End Sub

    Private Sub cboEnfermera_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEnfermera.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEnfermera.SelectedValue) Then txtCIE.Select()
    End Sub

    Private Sub cboEnfermera_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEnfermera.SelectedIndexChanged

    End Sub

    Private Sub txtCIE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE.Text = "" Then txtDes.Select()
        If e.KeyCode = Keys.Enter And txtCIE.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            lvDet.Items.Clear()
            dsCIE = objCIE.BuscarCodigo(txtCIE.Text)
            If dsCIE.Tables(0).Rows.Count > 0 Then
                txtDes.Enabled = False
                txtDes.Text = dsCIE.Tables(0).Rows(I)("desc_enf")
                txtDes.Enabled = True
                txtDes.Select()
            Else
                txtDes.Text = ""
                txtCIE.Select()
                MessageBox.Show("Codigo de CIE 10 no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCIE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE.TextChanged

    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If txtCIE.Text <> "" And txtDes.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvCieAlta.Items.Add(txtCIE.Text)
            Fila.SubItems.Add(txtDes.Text)
            txtCIE.Text = ""
            txtDes.Text = ""
            txtCIE.Select()
        End If
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And txtDes.Enabled Then txtFiltro.Text = txtDes.Text : txtFiltro.SelectionStart = txtFiltro.TextLength : gbConsulta.Visible = True : txtFiltro.Select()
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvDet.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvDet.Items.Clear()
            dsCIE = objCIE.BuscarDes(txtFiltro.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
            Next
        End If
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    txtCIE.Text = ""
                    txtDes.Text = ""
                    Dim Fila As ListViewItem
                    Fila = lvCieAlta.Items.Add(lvDet.Items(I).SubItems(0).Text)
                    Fila.SubItems.Add(lvDet.Items(I).SubItems(1).Text)
                End If
            Next
            btnRetornarCIE_Click(sender, e)
            txtCIE.Select()
        End If
    End Sub

    Private Sub dtpF1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Sub dtpF1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpF1.ValueChanged

    End Sub

    Private Sub dtpF2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then txtPaciente.Select()
    End Sub

    Private Sub dtpF2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpF2.ValueChanged

    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If e.KeyCode = Keys.Enter Then btnMostrar.Select()
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub btnRetornarCIE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarCIE.Click
        txtFiltro.Text = ""
        gbConsulta.Visible = False
        lvDet.Items.Clear()
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub lvCieAlta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCieAlta.KeyDown
        If e.KeyCode = Keys.Delete And lvCieAlta.Items.Count > 0 Then
            lvCieAlta.Items.RemoveAt(lvCieAlta.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvCieAlta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCieAlta.SelectedIndexChanged

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("Esta seguro de Modificar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objEgreso.Mantenimiento(lvTabla.SelectedItems(0).SubItems(43).Text, dtpFecha.Value.ToShortDateString, txtHora.Text, cboResponsable.SelectedValue, cboEspecialidad.SelectedValue, cboEnfermera.SelectedValue, cboTipoAlta.SelectedValue, cboCondicionAlta.SelectedValue, cboReferido.Text, 2)

            objEgresoCie.Eliminar(lvTabla.SelectedItems(0).SubItems(43).Text)
            Dim I As Integer
            For I = 0 To lvCieAlta.Items.Count - 1
                objEgresoCie.Grabar(lvTabla.SelectedItems(0).SubItems(43).Text, lvCieAlta.Items(I).SubItems(0).Text, lvCieAlta.Items(I).SubItems(1).Text)
            Next

            objHospitalizacion.AltaPaciente(lvTabla.SelectedItems(0).SubItems(43).Text, dtpFecha.Value.ToShortDateString)
        End If
        btnRetornar_Click(sender, e)
        btnMostrar_Click(sender, e)
    End Sub
End Class