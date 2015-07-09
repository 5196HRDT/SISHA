Public Class frmControlEst
    Dim objConsulta As New Consulta
    Dim objInterconsulta As New InterconsultaE
    Dim objTemporal As New tempConsultaExterna
    Dim objHistoria As New Historia

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim dsHistoria As New DataSet
        Dim dsTemp As New DataSet
        Dim dsConsulta As New DataSet

        Dim Edad As String
        Dim TEdad As String
        Dim DNI As String
        Dim Sexo As String
        Dim EdadA, EdadM, EdadD As Integer

        objTemporal.Eliminar(UsuarioSistema)
        'Buscar Consultas de Pacientes
        dsConsulta = objConsulta.BuscarTemp(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        Barra.Minimum = 0
        Barra.Value = 0
        Barra.Maximum = dsConsulta.Tables(0).Rows.Count
        lblResultado.Text = "Procesando Consultas...."
        For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
            Edad = 0 : TEdad = "" : DNI = "" : Sexo = ""
            dsHistoria = objHistoria.BuscarHistoria(dsConsulta.Tables(0).Rows(I)("Historia"))
            If dsHistoria.Tables(0).Rows.Count > 0 Then
                Sexo = Microsoft.VisualBasic.Left(dsHistoria.Tables(0).Rows(0)("Sexo").ToString, 1)
                DNI = dsHistoria.Tables(0).Rows(0)("Doc_Identidad").ToString
                'Calcular Edad del Paciente
                If dsHistoria.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                    EdadA = 0 : Edad = "0"
                    If dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                        Dim Dias As Integer, Meses As Integer, Años As Integer
                        Dim DiasMes As Integer
                        Dim dfin, dinicio As Date
                        dfin = dsConsulta.Tables(0).Rows(I)("FechaRegistro")
                        dinicio = dsHistoria.Tables(0).Rows(0)("FNacimiento")
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

                        If Val(EdadA) > 0 Then
                            Edad = EdadA
                            TEdad = "A"
                        ElseIf Val(EdadM) > 0 Then
                            Edad = EdadM
                            TEdad = "M"
                        ElseIf Val(EdadD) > 0 Then
                            Edad = EdadD
                            TEdad = "D"
                        End If
                    End If
                End If
            End If
            objTemporal.Grabar(UsuarioSistema, dsConsulta.Tables(0).Rows(I)("FechaRegistro"), dsConsulta.Tables(0).Rows(I)("Historia"), dsConsulta.Tables(0).Rows(I)("Paciente"), Sexo, Edad, TEdad, DNI, dsConsulta.Tables(0).Rows(I)("Departamento"), dsConsulta.Tables(0).Rows(I)("Provincia"), dsConsulta.Tables(0).Rows(I)("Distrito"), dsConsulta.Tables(0).Rows(I)("Cie1").ToString, dsConsulta.Tables(0).Rows(I)("Des1").ToString, dsConsulta.Tables(0).Rows(I)("Lab1").ToString, dsConsulta.Tables(0).Rows(I)("TipoDiagnostico").ToString, dsConsulta.Tables(0).Rows(I)("Cie2").ToString, dsConsulta.Tables(0).Rows(I)("Des2").ToString, dsConsulta.Tables(0).Rows(I)("Lab2").ToString, dsConsulta.Tables(0).Rows(I)("TD1").ToString, dsConsulta.Tables(0).Rows(I)("Cie3").ToString, dsConsulta.Tables(0).Rows(I)("Des3").ToString, dsConsulta.Tables(0).Rows(I)("Lab3").ToString, dsConsulta.Tables(0).Rows(I)("TD2").ToString, dsConsulta.Tables(0).Rows(I)("Cie4").ToString, dsConsulta.Tables(0).Rows(I)("Des4").ToString, dsConsulta.Tables(0).Rows(I)("Lab4").ToString, dsConsulta.Tables(0).Rows(I)("TD3").ToString, dsConsulta.Tables(0).Rows(I)("Cie5").ToString, dsConsulta.Tables(0).Rows(I)("Des5").ToString, dsConsulta.Tables(0).Rows(I)("Lab5").ToString, dsConsulta.Tables(0).Rows(I)("TD4").ToString, dsConsulta.Tables(0).Rows(I)("Cie6").ToString, dsConsulta.Tables(0).Rows(I)("Des6").ToString, dsConsulta.Tables(0).Rows(I)("Lab6").ToString, dsConsulta.Tables(0).Rows(I)("TD5").ToString, "SI", dsConsulta.Tables(0).Rows(I)("Responsable"), dsConsulta.Tables(0).Rows(I)("Servicio"), dsConsulta.Tables(0).Rows(I)("IngEstablecimiento"), dsConsulta.Tables(0).Rows(I)("IngServicio"))
            Barra.Value = Barra.Value + 1
            Application.DoEvents()
        Next

        'Buscar InterConsultas de Pacientes
        Dim CSHistoria As String = ""
        dsConsulta = objInterconsulta.BuscarTemp(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        Barra.Minimum = 0
        Barra.Value = 0
        Barra.Maximum = dsConsulta.Tables(0).Rows.Count
        lblResultado.Text = "Procesando InterConsultas...."
        For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
            Edad = 0 : TEdad = "" : DNI = "" : Sexo = "" : CSHistoria = "SI"
            dsHistoria = objHistoria.BuscarHistoria(dsConsulta.Tables(0).Rows(I)("Historia"))
            'If dsConsulta.Tables(0).Rows(I)("Historia") = "0447120" Then
            '    MsgBox("Hola")
            'End If
            If dsHistoria.Tables(0).Rows.Count > 0 Then
                If dsConsulta.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                    Sexo = Microsoft.VisualBasic.Left(dsHistoria.Tables(0).Rows(0)("Sexo").ToString, 1)
                    DNI = dsHistoria.Tables(0).Rows(0)("Doc_Identidad").ToString
                    'Calcular Edad del Paciente
                    If dsHistoria.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                        EdadA = 0 : Edad = "0"
                        If dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                            Dim Dias As Integer, Meses As Integer, Años As Integer
                            Dim DiasMes As Integer
                            Dim dfin, dinicio As Date
                            dfin = dsConsulta.Tables(0).Rows(I)("FechaRegistro")
                            dinicio = dsHistoria.Tables(0).Rows(0)("FNacimiento")
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

                            If Val(EdadA) > 0 Then
                                Edad = EdadA
                                TEdad = "A"
                            ElseIf Val(EdadM) > 0 Then
                                Edad = EdadM
                                TEdad = "M"
                            ElseIf Val(EdadD) > 0 Then
                                Edad = EdadD
                                TEdad = "D"
                            End If
                        End If
                    End If
                End If
            Else
                Sexo = Microsoft.VisualBasic.Left(dsConsulta.Tables(0).Rows(I)("Sexo").ToString, 1)
                DNI = dsConsulta.Tables(0).Rows(I)("DNI").ToString
                Edad = dsConsulta.Tables(0).Rows(I)("Edad").ToString
                TEdad = dsConsulta.Tables(0).Rows(I)("TEdad").ToString
                CSHistoria = "NO"
            End If
            objTemporal.Grabar(UsuarioSistema, dsConsulta.Tables(0).Rows(I)("FechaRegistro"), dsConsulta.Tables(0).Rows(I)("Historia"), dsConsulta.Tables(0).Rows(I)("Paciente"), Sexo, Edad, TEdad, DNI, dsConsulta.Tables(0).Rows(I)("Departamento"), dsConsulta.Tables(0).Rows(I)("Provincia"), dsConsulta.Tables(0).Rows(I)("Distrito"), dsConsulta.Tables(0).Rows(I)("Cie1").ToString, dsConsulta.Tables(0).Rows(I)("Des1").ToString, dsConsulta.Tables(0).Rows(I)("Lab1").ToString, dsConsulta.Tables(0).Rows(I)("TipoDiagnostico").ToString, dsConsulta.Tables(0).Rows(I)("Cie2").ToString, dsConsulta.Tables(0).Rows(I)("Des2").ToString, dsConsulta.Tables(0).Rows(I)("Lab2").ToString, dsConsulta.Tables(0).Rows(I)("TD1").ToString, dsConsulta.Tables(0).Rows(I)("Cie3").ToString, dsConsulta.Tables(0).Rows(I)("Des3").ToString, dsConsulta.Tables(0).Rows(I)("Lab3").ToString, dsConsulta.Tables(0).Rows(I)("TD2").ToString, dsConsulta.Tables(0).Rows(I)("Cie4").ToString, dsConsulta.Tables(0).Rows(I)("Des4").ToString, dsConsulta.Tables(0).Rows(I)("Lab4").ToString, dsConsulta.Tables(0).Rows(I)("TD3").ToString, dsConsulta.Tables(0).Rows(I)("Cie5").ToString, dsConsulta.Tables(0).Rows(I)("Des5").ToString, dsConsulta.Tables(0).Rows(I)("Lab5").ToString, dsConsulta.Tables(0).Rows(I)("TD4").ToString, dsConsulta.Tables(0).Rows(I)("Cie6").ToString, dsConsulta.Tables(0).Rows(I)("Des6").ToString, dsConsulta.Tables(0).Rows(I)("Lab6").ToString, dsConsulta.Tables(0).Rows(I)("TD5").ToString, CSHistoria, dsConsulta.Tables(0).Rows(I)("Responsable").ToString, dsConsulta.Tables(0).Rows(I)("Especialidad").ToString, dsConsulta.Tables(0).Rows(I)("IngEstablecimiento"), dsConsulta.Tables(0).Rows(I)("IngServicio"))
            Barra.Value = Barra.Value + 1
            Application.DoEvents()
        Next
        Select Case cboTipo.Text
            Case "EDADES = 0"
                dsTemp = objTemporal.Buscar(UsuarioSistema, 1)
            Case "TIPOS DE DIAGNOSTICOS EN BLANCO"
                dsTemp = objTemporal.Buscar(UsuarioSistema, 2)
            Case "DIAGNOSTICOS DE MATERNO CON SEXO DE HOMBRES"
                dsTemp = objTemporal.Buscar(UsuarioSistema, 3)
        End Select
        Barra.Minimum = 0
        Barra.Value = 0
        Barra.Maximum = dsTemp.Tables(0).Rows.Count
        lblResultado.Text = "Procesando Resultados...."
        lvTabla.Items.Clear()
        For I = 0 To dsTemp.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsTemp.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Responsable"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Sexo"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("TEdad"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("DNI"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("IngEstablecimiento"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("IngServicio"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Cie1"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Lab1"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("T1"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Des2"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Lab2"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("T2"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Des3"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Lab3"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("T3"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Cie4"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Des4"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Lab4"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("T4"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Cie5"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Des5"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Lab5"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("T5"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Cie6"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Des6"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("Lab6"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("T6"))
            Fila.SubItems.Add(dsTemp.Tables(0).Rows(I)("CSHistoria"))
            Barra.Value = Barra.Value + 1
            Application.DoEvents()
        Next
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

    End Sub
End Class