Public Class frmProgramas
    Dim objMedico As New Medico
    Dim objUbigeo As New clsUbigeo
    Dim objProgramacion As New Programacion
    Dim objHistoria As New Historia
    Dim objCupo As New Cupo
    Dim objCIE10 As New CIE10
    Dim objConsulta As New Consulta
    Dim objInterconsultaE As New InterconsultaE
    Dim objInterconsulta As New InterconsultaH
    Dim objConsultaCPT As New ConsultaCPT

    Dim Operacion As Integer
    Dim NombrePaciente As String
    Dim nomFiltro As String

    Dim Edad As String = ""
    Dim Años As String = ""
    Dim Meses As String = ""
    Dim Dias As String = ""
    Dim Año As Integer
    Dim EdadA, EdadM, EdadD As Integer
    Dim DNI As String

    Private Sub FiltroCIE()
        Select Case Microsoft.VisualBasic.Left(nomFiltro, nomFiltro.Length - 1)
            Case "DESCIE"
                If txtDes.Text.Length = 0 Then Exit Sub
                lvDX.Items.Clear()
                Dim dsTabla As New DataSet
                Dim I As Integer
                Dim Fila As ListViewItem
                dsTabla = objCIE10.Buscar(txtDes.Text, 2)
                For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                    Fila = lvDX.Items.Add(dsTabla.Tables(0).Rows(I)("Codigo"))
                    Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
                Next
        End Select
    End Sub

    Private Sub BuscarAtenciones()
        lvDet.Items.Clear()
        Dim dsTab As New Data.DataSet
        Dim Fila As ListViewItem
        Dim TConsultas As Integer = 0

        lblTConsultas.Tag = 0
        lblTConsultas.Text = 0 & "Consultas"

        Dim I As Integer
        Dim dsMedico As New Data.DataSet
        Dim Año As Integer

        lblMedico.Tag = CodMedico
        lblMedico.Text = NomMedico
        lblEspecialidad.Text = lblEspecialidad.Text

        'DNI Medico
        DNI = ""
        dsMedico = objMedico.Medico_BuscarId(CodMedico)
        If dsMedico.Tables(0).Rows.Count > 0 Then DNI = dsMedico.Tables(0).Rows(I)("DNI").ToString

        'Consultas Medicas
        dsTab = objConsulta.GenerarHIS(CodMedico, lblEspecialidad.Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                EdadA = 0 : Edad = "0"
                If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        If Año > 1 Then
                            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                            Else
                                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                                EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                EdadM = 11
                                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now))
                                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                EdadA = 1
                                EdadM = 0
                                Edad = "1 A y 0 M"
                            End If
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                            EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                            EdadD = 0
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If
            End If

            Fila.SubItems.Add(Edad)

            If dsTab.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1)) Else Fila.SubItems.Add("")
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdConsulta"))
            Fila.SubItems.Add("CONSULTA")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("SI")
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5") <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6") <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab6").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next


        'Interconsultas Hospitalizacion
        dsTab = objInterconsulta.GenerarHIS(CodMedico, lblEspecialidad.Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                EdadA = 0 : Edad = "0"
                If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        If Año > 1 Then
                            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                            Else
                                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                                EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                EdadM = 11
                                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now))
                                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                EdadA = 1
                                EdadM = 0
                                Edad = "1 A y 0 M"
                            End If
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                            EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                            EdadD = 0
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaH"))
            Fila.SubItems.Add("HOSPITALIZACION")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("SI")
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5") <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6") <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        'Interconsultas Emergencia CH
        dsTab = objInterconsultaE.GenerarHIS(CodMedico, lblEspecialidad.Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            Dim VerAPP As Boolean = False
            If Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("DNISH").ToString, 3) = "APP" Then VerAPP = True

            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            NombrePaciente = dsTab.Tables(0).Rows(I)("Apaterno") & " " & dsTab.Tables(0).Rows(I)("Amaterno") & " " & dsTab.Tables(0).Rows(I)("Nombres")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" And Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                    EdadA = 0 : Edad = "0"
                    If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                        If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                            Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                            If Año > 1 Then
                                If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                                    EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                                    EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                    Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                                Else
                                    EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                                    EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                    Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                                End If
                            Else
                                If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                    EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                                    EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                    Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                                ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                    EdadM = 11
                                    EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now))
                                    Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) & " D"
                                ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                    EdadA = 1
                                    EdadM = 0
                                    Edad = "1 A y 0 M"
                                End If
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                                EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                EdadD = 0
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                            End If
                        End If
                    End If
                End If
            Else
                If Not VerAPP Then
                    txtEdad.Text = dsTab.Tables(0).Rows(I)("Edad")
                    Edad = dsTab.Tables(0).Rows(I)("Edad")
                    cboTEdad.Text = dsTab.Tables(0).Rows(I)("TEdad")
                    If dsTab.Tables(0).Rows(I)("TEdad") = "A" Then
                        EdadA = dsTab.Tables(0).Rows(I)("Edad")
                        EdadM = 0
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad") = "M" Then
                        EdadA = 0
                        EdadM = dsTab.Tables(0).Rows(I)("Edad")
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad") = "D" Then
                        EdadA = 0
                        EdadM = 0
                        EdadD = dsTab.Tables(0).Rows(I)("Edad")
                    End If
                End If
            End If

            If Not VerAPP Then Fila.SubItems.Add(Edad) Else Fila.SubItems.Add("")

            If Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo").ToString, 1))
                Else
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("SexoSH").ToString, 1))
                End If
            Else
                Fila.SubItems.Add("")
            End If
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add("")
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String
            If dsTab.Tables(0).Rows(I)("TipoCupo") = "" Then TCupo = "COMUN" Else TCupo = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaE"))
            Fila.SubItems.Add("INTERCONSULTAE")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Else
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("SexoSH").ToString)
            End If
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(EdadA)
                Fila.SubItems.Add(EdadM)
                Fila.SubItems.Add(EdadD)
            Else
                If dsTab.Tables(0).Rows(I)("TEdad") = "A" Then
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "M" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "D" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                End If
            End If
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("CSHistoria"))
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad"))
            Else
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)
            End If
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "NO" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            End If
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        'Interconsultas Emergencia SH
        dsTab = objInterconsultaE.GenerarHISSH(CodMedico, lblEspecialidad.Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            Dim VerAPP As Boolean = False
            If Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("DNISH").ToString, 3) = "APP" Then VerAPP = True


            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)

            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            NombrePaciente = "" 'dsTab.Tables(0).Rows(I)("Apaterno") & " " & dsTab.Tables(0).Rows(I)("Amaterno") & " " & dsTab.Tables(0).Rows(I)("Nombres")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" And Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                    EdadA = 0 : Edad = "0"
                    If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                        If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                            Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                            If Año > 1 Then
                                If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                                    EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                                    EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                    Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                                Else
                                    EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                                    EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                    Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                                End If
                            Else
                                If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                    EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                                    EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                    Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                                ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                    EdadM = 11
                                    EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now))
                                    Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) & " D"
                                ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                    EdadA = 1
                                    EdadM = 0
                                    Edad = "1 A y 0 M"
                                End If
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                                EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                EdadD = 0
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                            End If
                        End If
                    End If
                End If
            Else
                If Not VerAPP Then
                    txtEdad.Text = dsTab.Tables(0).Rows(I)("Edad")
                    Edad = dsTab.Tables(0).Rows(I)("Edad")
                    cboTEdad.Text = dsTab.Tables(0).Rows(I)("TEdad")
                    If dsTab.Tables(0).Rows(I)("TEdad") = "A" Then
                        EdadA = dsTab.Tables(0).Rows(I)("Edad")
                        EdadM = 0
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad") = "M" Then
                        EdadA = 0
                        EdadM = dsTab.Tables(0).Rows(I)("Edad")
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad") = "D" Then
                        EdadA = 0
                        EdadM = 0
                        EdadD = dsTab.Tables(0).Rows(I)("Edad")
                    End If
                End If
            End If

            If Not VerAPP Then Fila.SubItems.Add(Edad) Else Fila.SubItems.Add("")

            If Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo").ToString, 1))
                Else
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("SexoSH").ToString, 1))
                End If
            Else
                Fila.SubItems.Add("")
            End If
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Dim TCupo As String
            If dsTab.Tables(0).Rows(I)("TipoCupo") = "" Then TCupo = "COMUN" Else TCupo = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaE"))
            Fila.SubItems.Add("INTERCONSULTAE")
            Fila.SubItems.Add("")
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Else
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("SexoSH").ToString)
            End If
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(EdadA)
                Fila.SubItems.Add(EdadM)
                Fila.SubItems.Add(EdadD)
            Else
                If dsTab.Tables(0).Rows(I)("TEdad") = "A" Then
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "M" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "D" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                End If
            End If
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("CSHistoria"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "NO" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            End If
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        'PROCEDIMIENTOS
        dsTab = objConsultaCPT.GenerarHIS(CodMedico, lblEspecialidad.Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                EdadA = 0 : Edad = "0"
                If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        If Año > 1 Then
                            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                            Else
                                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                                EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                EdadM = 11
                                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now))
                                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                EdadA = 1
                                EdadM = 0
                                Edad = "1 A y 0 M"
                            End If
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                            EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                            EdadD = 0
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento")) Else Fila.SubItems.Add("")
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdProcedimiento"))
            Fila.SubItems.Add("PROCEDIMIENTO")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("SI")
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento")) Else Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        lblTConsultas.Tag = TConsultas
        lblTConsultas.Text = TConsultas.ToString & " Consultas"
        'ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub DefinirEspecialidad()
        'Verificar Programaciones
        Dim dsProgramacion As New DataSet
        dsProgramacion = objProgramacion.CantidadProgramada(vIdMedico, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        If dsProgramacion.Tables(0).Rows.Count > 1 Then
            If MessageBox.Show("Usted. Tiene 02 Especialidades programadas en este Dia y Turno. Cual Especialidad desea Atender" & Chr(13) & dsProgramacion.Tables(0).Rows(0)("Especialidad") & "(SI)" & Chr(13) & dsProgramacion.Tables(0).Rows(1)("Especialidad") & "(NO)", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                lblEspecialidad.Text = dsProgramacion.Tables(0).Rows(0)("Especialidad")
            Else
                lblEspecialidad.Text = dsProgramacion.Tables(0).Rows(1)("Especialidad")
            End If
        ElseIf dsProgramacion.Tables(0).Rows.Count = 1 Then
            lblEspecialidad.Text = dsProgramacion.Tables(0).Rows(0)("Especialidad")
        Else
            If NomMedico <> "" Then
                Dim dsM As New Data.DataSet
                dsM = objMedico.Medico_BuscarId(vIdMedico)
                lblEspecialidad.Text = dsM.Tables(0).Rows(0)("SubServicio")
            End If
        End If
    End Sub


    Private Sub frmProgramas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTurno.Text = "MAÑANA"
        dtpFecha.Value = Date.Now
        lblMedico.Text = NomMedico

        'Departamento
        Dim dsDpto As New Data.DataSet
        dsDpto = objUbigeo.Departamento
        cboDepartamento.DataSource = dsDpto.Tables(0)
        cboDepartamento.DisplayMember = "desc_dpto"
        cboDepartamento.ValueMember = "cod_dpto"
        cboDepartamento.Text = "LA LIBERTAD"
        cboDepartamento_SelectedIndexChanged(sender, e)

        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboDepartamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDepartamento.KeyDown
        If IsNumeric(cboDepartamento.SelectedValue) And e.KeyCode = Keys.Enter Then cboProvincia.Select()
    End Sub

    Private Sub cboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.SelectedIndexChanged
        If IsNumeric(cboDepartamento.SelectedValue) Then
            Dim dsProv As New Data.DataSet
            dsProv = objUbigeo.Provincia(cboDepartamento.SelectedValue)
            cboProvincia.DataSource = dsProv.Tables(0)
            cboProvincia.DisplayMember = "desc_prov"
            cboProvincia.ValueMember = "cod_prov"
            If cboDepartamento.Text = "LA LIBERTAD" Then cboProvincia.Text = "TRUJILLO" Else cboProvincia.Text = ""
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblHistoria.Text = ""
        txtEdad.Text = ""
        txtDNI.Text = ""
        cboSexo.Text = ""
        dtpFecNac.Value = Date.Now
        gbConsulta.Visible = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        cboTipoAtencion.Text = ""
        cboEstablecimiento.Text = ""
        cboServicio.Text = ""
        gbHIS.Enabled = False

        ControlesAD(Me, False)


        cboDepartamento.Text = "LA LIBERTAD"
        cboDepartamento_SelectedIndexChanged(sender, e)
        cboProvincia.Text = "TRUJILLO"
        cboProvincia_SelectedIndexChanged(sender, e)
        dtpFecha.Enabled = True
        cboTurno.Enabled = True

        txtCIE1.Text = "" : txtDes1.Text = "" : txtLab1.Text = "" : cboTD1.Text = ""
        txtCIE2.Text = "" : txtDes2.Text = "" : txtLab2.Text = "" : cboTD2.Text = ""
        txtCIE3.Text = "" : txtDes3.Text = "" : txtLab3.Text = "" : cboTD3.Text = ""
        txtCIE4.Text = "" : txtDes4.Text = "" : txtLab4.Text = "" : cboTD4.Text = ""
        txtCIE5.Text = "" : txtDes5.Text = "" : txtLab5.Text = "" : cboTD5.Text = ""
        txtCIE6.Text = "" : txtDes6.Text = "" : txtLab6.Text = "" : cboTD6.Text = ""
        BuscarAtenciones()
    End Sub

    Private Sub cboProvincia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProvincia.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboProvincia.SelectedValue) Then cboDistrito.Select()
    End Sub

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        If IsNumeric(cboProvincia.SelectedValue) Then
            Dim dsDist As New Data.DataSet
            dsDist = objUbigeo.Distrito(cboDepartamento.SelectedValue, cboProvincia.SelectedValue)
            cboDistrito.DataSource = dsDist.Tables(0)
            cboDistrito.DisplayMember = "desc_dist"
            cboDistrito.ValueMember = "cod_dist"
            If cboProvincia.Text = "TRUJILLO" Then cboDistrito.Text = "TRUJILLO" Else cboDistrito.Text = ""
        End If
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        DefinirEspecialidad()
        BuscarAtenciones()
    End Sub

    Private Sub cboTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTurno.SelectedIndexChanged
        DefinirEspecialidad()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        dtpFecha.Select()
        gbHIS.Enabled = True

        If chkCorrelativo.Checked = False Then
            Dim Historia As String
            Historia = InputBox("Ingresar Nro de Historia")

            If Not IsNumeric(Historia) Then MessageBox.Show("Debe ingresar Nro de Historia Clínica", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub

            Dim dsTab As New DataSet
            dsTab = objHistoria.BuscarHistoria(Historia)
            If dsTab.Tables(0).Rows.Count = 0 Then MessageBox.Show("No existe Historia Clínica Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub

            lblHistoria.Text = Historia
            NombrePaciente = dsTab.Tables(0).Rows(0)("Apaterno") & " " & dsTab.Tables(0).Rows(0)("Amaterno") & " " & dsTab.Tables(0).Rows(0)("Nombres")
            If dsTab.Tables(0).Rows(0)("FNACIMIENTO").ToString = "" Then
                Dim NFecha As String
                NFecha = InputBox("Ingrese Fecha de Nacimiento de Paciente (DD/MM/YYYY)", "Datos de Paciente")
                If Not IsDate(NFecha) Then MessageBox.Show("Formato de Fecha no es Valida, debe ingresar en formato DD/MM/YYYY" & Chr(13) & "Ingrese Nuevamente la Información del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                objHistoria.GrabarFN(lblHistoria.Text, NFecha)
                dsTab = objHistoria.BuscarHistoria(Historia)
            End If

            dtpFecNac.Value = dsTab.Tables(0).Rows(0)("FNACIMIENTO").ToString
            cboSexo.Text = dsTab.Tables(0).Rows(0)("SEXO").ToString
            'Edad Paciente
            If dsTab.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                lblPaciente.Text = dsTab.Tables(0).Rows(0)("Apaterno") & " " & dsTab.Tables(0).Rows(0)("Amaterno") & " " & dsTab.Tables(0).Rows(0)("Nombres")
                EdadA = 0 : Edad = "0"

                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = Date.Now  'dsTab.Tables(0).Rows(0)("FNacimiento")
                dinicio = dsTab.Tables(0).Rows(0)("FNacimiento") 'Date.Now
                Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                Años = DateDiff("yyyy", dinicio, dfin)

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

                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If

                'Verificar Dias
                EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento"))
                If Val(EdadD) > Date.Now.Day Then
                    EdadD = Val(EdadD) - Date.Now.Day
                ElseIf Val(EdadD) < Date.Now.Day Then
                    EdadM = Val(EdadM) - 1
                    EdadD = Date.Now.Day - EdadD
                    EdadD = DameDiasMes(Date.Now.Month) - EdadD
                Else
                    EdadD = 0
                End If

                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If

                'If dsTab.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                '    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) > 0 Then
                '        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)
                '        If Año > 1 Then
                '            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Month Then
                '                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)
                '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12
                '                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M"
                '            Else
                '                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)) - 1
                '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12
                '                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M"
                '            End If
                '        Else
                '            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Day Then
                '                EdadM = 12 - Month(dsTab.Tables(0).Rows(0)("FNAcimiento"))
                '                EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")))
                '                Edad = 12 - Month(dsTab.Tables(0).Rows(0)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento"))) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) > Date.Now.Day Then
                '                EdadM = 11
                '                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now))
                '                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) = Date.Now.Day Then
                '                EdadA = 1
                '                EdadM = 0
                '                Edad = "1 A y 0 M"
                '            End If
                '        End If
                '    Else
                '        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12
                '            EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")))
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento"))) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) > Date.Now.Day Then
                '            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12) - 1
                '            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")) - Date.Now.Day)
                '            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")) - Date.Now.Day) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) = Date.Now.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12
                '            EdadD = 0
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                '        End If
                '    End If
                'End If
                Operacion = 1
                btnGrabar.Enabled = True
                btnCancelar.Enabled = True
                btnNuevo.Enabled = False
            End If
            txtEdad.Text = Edad
            txtDNI.Text = dsTab.Tables(0).Rows(0)("Doc_Identidad").ToString
            If dsTab.Tables(0).Rows(0)("Departamento").ToString <> "" Then
                cboDepartamento.Text = dsTab.Tables(0).Rows(0)("Departamento")
                cboProvincia.Text = dsTab.Tables(0).Rows(0)("Provincia")
                cboDistrito.Text = dsTab.Tables(0).Rows(0)("Distrito")
            Else
                MessageBox.Show("Defina el Departamento correctamente del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboDepartamento.Select()
            End If
            cboTipoAtencion.Text = "COMUN"

            cboEstablecimiento.Text = "NUEVO"
            cboServicio.Text = "NUEVO"

            'Lista de Atencion de Consulta
            lvConsultas.Items.Clear()
            Dim dsConsulta As New Data.DataSet
            Dim FilaC As ListViewItem
            Dim CantEsp As Integer
            Dim UltimoAñoAtendido As Integer
            Dim I As Integer
            CantEsp = 0
            dsConsulta = objCupo.ConsultasPacienteAtendidas(lblHistoria.Text, dtpFecha.Value)
            UltimoAñoAtendido = 0
            For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
                If I > 0 And EspecialidadMedica = dsConsulta.Tables(0).Rows(I)("Consultorio") And UltimoAñoAtendido = 0 Then UltimoAñoAtendido = Microsoft.VisualBasic.Right(dsConsulta.Tables(0).Rows(I)("Fecha"), 4)
                FilaC = lvConsultas.Items.Add(dsConsulta.Tables(0).Rows(I)("Fecha"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Consultorio"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Medico"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
                If EspMedico = dsConsulta.Tables(0).Rows(I)("Consultorio") Then
                    CantEsp += 1
                End If
            Next

            'Ingreso Centro y Servicio
            If lvConsultas.Items.Count > 1 Then
                If UltimoAñoAtendido = dtpFecha.Value.Year Then
                    cboEstablecimiento.Text = "CONTINUADOR"
                Else
                    cboEstablecimiento.Text = "REINGRESANTE"
                End If
            End If

            If CantEsp > 1 Then
                If UltimoAñoAtendido = dtpFecha.Value.Year Then
                    cboServicio.Text = "CONTINUADOR"
                Else
                    cboServicio.Text = "REINGRESANTE"
                End If
            End If
            txtDNI.Select()
        Else
            Dim Correlativo As String
            Operacion = 1
            Correlativo = InputBox("Ingresar Correlativo de Atención")
            If Microsoft.VisualBasic.Left(Correlativo, 3).ToUpper <> "APP" Then
                If Not IsNumeric(Correlativo) Then MessageBox.Show("Debe ingresar Nro Correlativo Válido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Else
                Correlativo = Correlativo.ToUpper
            End If

            lblHistoria.Text = Correlativo
            cboSexo.Text = "FEMENINO"
            cboTipoAtencion.Text = "PROGRAMA"
            cboTEdad.Text = "A"
            If Microsoft.VisualBasic.Left(Correlativo, 3) <> "APP" Then
                cboSexo.Select()
            Else
                txtCIE1.Select()
            End If
            btnGrabar.Enabled = True
            btnCancelar.Enabled = True
            btnNuevo.Enabled = False
        End If
    End Sub

    Private Sub dtpFecNac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecNac.KeyDown
        If e.KeyCode = Keys.Enter Then cboSexo.Select()
    End Sub

    Private Sub dtpFecNac_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecNac.ValueChanged

    End Sub

    Private Sub cboSexo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSexo.KeyDown
        If e.KeyCode = Keys.Enter And cboSexo.Text <> "" Then txtEdad.Select()
    End Sub

    Private Sub cboSexo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSexo.SelectedIndexChanged

    End Sub

    Private Sub txtEdad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdad.KeyDown
        If e.KeyCode = Keys.Enter Then cboTEdad.Select()
    End Sub

    Private Sub txtEdad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdad.TextChanged

    End Sub

    Private Sub cboTEdad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTEdad.KeyDown
        If e.KeyCode = Keys.Enter Then txtDNI.Select()
    End Sub

    Private Sub cboTEdad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTEdad.SelectedIndexChanged

    End Sub

    Private Sub txtDNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyDown
        If e.KeyCode = Keys.Enter Then cboDepartamento.Select()
    End Sub

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub cboDistrito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDistrito.KeyDown
        If IsNumeric(cboDistrito.SelectedValue) And e.KeyCode = Keys.Enter Then txtCIE1.Select()
    End Sub

    Private Sub cboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.SelectedIndexChanged

    End Sub

    Private Sub txtCIE1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE1.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE1.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE1.Text = txtCIE2.Text Or txtCIE1.Text = txtCIE3.Text Or txtCIE1.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE1.Select() : Exit Sub
                If Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "APP" Then
                    If chkCorrelativo.Checked Then
                        If cboTEdad.Text = "A" Then EdadA = txtEdad.Text : EdadM = 0 : EdadD = 0
                        If cboTEdad.Text = "M" Then EdadA = 0 : EdadM = txtEdad.Text : EdadD = 0
                        If cboTEdad.Text = "D" Then EdadA = 0 : EdadM = 0 : EdadD = txtEdad.Text
                    End If
                    'Verificar Edad
                    Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                    If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                        Dim RMin, RMax As Double
                        If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                        If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                        If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                        If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                        If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                        If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                        If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                    End If

                End If
                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes1.Enabled = False
                txtDes1.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes1.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD1.Text = "DEFINITIVO" : txtCIE2.Select()
                txtLab1.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCIE1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE1.TextChanged

    End Sub

    Private Sub txtCIE2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE2.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE2.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE2.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE2.Text = txtCIE1.Text Or txtCIE2.Text = txtCIE3.Text Or txtCIE2.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE2.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes2.Enabled = False
                txtDes2.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes2.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD2.Text = "DEFINITIVO" : txtCIE3.Select()
                txtLab2.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.Enter And txtCIE2.Text = "" Then txtDes2.Select()
    End Sub

    Private Sub txtCIE2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE2.TextChanged

    End Sub

    Private Sub txtCIE3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE3.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE3.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE3.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE3.Text = txtCIE1.Text Or txtCIE3.Text = txtCIE2.Text Or txtCIE3.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE3.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes3.Enabled = False
                txtDes3.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes3.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD3.Text = "DEFINITIVO" : txtDes4.Select()
                txtLab3.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.Enter And txtCIE3.Text = "" Then txtDes3.Select()
    End Sub

    Private Sub txtCIE3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE3.TextChanged

    End Sub

    Private Sub txtCIE4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE4.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE4.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE4.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE4.Text = txtCIE1.Text Or txtCIE4.Text = txtCIE2.Text Or txtCIE4.Text = txtCIE3.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE4.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCUNINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes4.Enabled = False
                txtDes4.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes4.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD4.Text = "DEFINITIVO" : txtCIE5.Select()
                txtLab4.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.Enter And txtCIE2.Text = "" Then txtDes2.Select()
    End Sub

    Private Sub txtCIE4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE4.TextChanged

    End Sub

    Private Sub txtCIE5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE5.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE5.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE5.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE5.Text = txtCIE1.Text Or txtCIE5.Text = txtCIE2.Text Or txtCIE5.Text = txtCIE3.Text Or txtCIE5.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes5.Enabled = False
                txtDes5.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes5.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD5.Text = "DEFINITIVO" : txtCIE6.Select()
                txtLab5.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.Enter And txtCIE5.Text = "" Then txtDes5.Select()
    End Sub

    Private Sub txtCIE5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE5.TextChanged

    End Sub

    Private Sub txtCIE6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE6.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE6.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE6.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE6.Text = txtCIE1.Text Or txtCIE6.Text = txtCIE2.Text Or txtCIE6.Text = txtCIE3.Text Or txtCIE6.Text = txtCIE4.Text Or txtCIE6.Text = txtCIE5.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Select() : Exit Sub

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes6.Enabled = False
                txtDes6.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes6.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD6.Text = "DEFINITIVO" : btnGrabar.Select()
                txtLab6.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.Enter And txtCIE6.Text = "" Then txtDes6.Select()
    End Sub

    Private Sub txtCIE6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE6.TextChanged

    End Sub

    Private Sub txtDes1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes1.TextChanged
        If txtDes1.Text.Length > 1 And txtDes1.Enabled Then nomFiltro = "DESCIE1" : txtDes.Text = txtDes1.Text : gbConsulta.Visible = True : txtDes.Text = txtDes1.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes1.Text.Length = 0 Then txtCIE1.Text = "" : cboTD1.Text = "" : txtLab1.Text = ""
    End Sub

    Private Sub txtDes2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes2.TextChanged
        If txtDes2.Text.Length > 1 And txtDes2.Enabled Then nomFiltro = "DESCIE2" : txtDes.Text = txtDes2.Text : gbConsulta.Visible = True : txtDes.Text = txtDes2.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes2.Text.Length = 0 Then txtCIE2.Text = "" : cboTD2.Text = "" : txtLab2.Text = ""
    End Sub

    Private Sub txtDes3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes3.TextChanged
        If txtDes3.Text.Length > 1 And txtDes3.Enabled Then nomFiltro = "DESCIE3" : txtDes.Text = txtDes3.Text : gbConsulta.Visible = True : txtDes.Text = txtDes3.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes3.Text.Length = 0 Then txtCIE3.Text = "" : cboTD3.Text = "" : txtLab3.Text = ""
    End Sub

    Private Sub txtDes4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes4.TextChanged
        If txtDes4.Text.Length > 1 And txtDes4.Enabled Then nomFiltro = "DESCIE4" : txtDes.Text = txtDes4.Text : gbConsulta.Visible = True : txtDes.Text = txtDes4.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes4.Text.Length = 0 Then txtCIE4.Text = "" : cboTD4.Text = "" : txtLab4.Text = ""
    End Sub

    Private Sub txtDes5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes5.TextChanged
        If txtDes5.Text.Length > 1 And txtDes5.Enabled Then nomFiltro = "DESCIE5" : txtDes.Text = txtDes5.Text : gbConsulta.Visible = True : txtDes.Text = txtDes5.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes5.Text.Length = 0 Then txtCIE5.Text = "" : cboTD5.Text = "" : txtLab5.Text = ""
    End Sub

    Private Sub txtDes6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes6.TextChanged
        If txtDes6.Text.Length > 1 And txtDes6.Enabled Then nomFiltro = "DESCIE6" : txtDes.Text = txtDes6.Text : gbConsulta.Visible = True : txtDes.Text = txtDes6.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes6.Text.Length = 0 Then txtCIE6.Text = "" : cboTD6.Text = "" : txtLab6.Text = ""
    End Sub

    Private Sub txtLab1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab1.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD1.Select()
    End Sub

    Private Sub txtLab2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab2.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD2.Select()
    End Sub

    Private Sub txtLab3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab3.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD3.Select()
    End Sub

    Private Sub txtLab3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab3.TextChanged

    End Sub

    Private Sub txtLab4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab4.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD4.Select()
    End Sub

    Private Sub txtLab4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab4.TextChanged

    End Sub

    Private Sub txtLab5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab5.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD5.Select()
    End Sub

    Private Sub txtLab5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab5.TextChanged

    End Sub

    Private Sub txtLab6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab6.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD6.Select()
    End Sub

    Private Sub txtLab6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab6.TextChanged

    End Sub

    Private Sub cboTD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD1.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE2.Select()
    End Sub

    Private Sub cboTD1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD1.SelectedIndexChanged

    End Sub

    Private Sub cboTD2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD2.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE3.Select()
    End Sub

    Private Sub cboTD2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD2.SelectedIndexChanged

    End Sub

    Private Sub cboTD3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD3.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE4.Select()
    End Sub

    Private Sub cboTD3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD3.SelectedIndexChanged

    End Sub

    Private Sub cboTD4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD4.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE5.Select()
    End Sub

    Private Sub cboTD4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD4.SelectedIndexChanged

    End Sub

    Private Sub cboTD5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD5.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE6.Select()
    End Sub

    Private Sub cboTD5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD5.SelectedIndexChanged

    End Sub

    Private Sub cboTD6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD6.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then cboTipoAtencion.Select()
    End Sub

    Private Sub cboTD6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD6.SelectedIndexChanged

    End Sub

    Private Sub cboTipoAtencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAtencion.KeyDown
        If cboTipoAtencion.Text <> "" And e.KeyCode = Keys.Enter Then cboEstablecimiento.Select()
    End Sub

    Private Sub cboTipoAtencion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAtencion.SelectedIndexChanged

    End Sub

    Private Sub cboEstablecimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEstablecimiento.KeyDown
        If e.KeyCode = Keys.Enter And cboEstablecimiento.Text <> "" Then cboServicio.Select()
    End Sub

    Private Sub cboEstablecimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstablecimiento.SelectedIndexChanged

    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And cboServicio.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Guardar los Cambios", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If lblHistoria.Text = "" Then MessageBox.Show("Debe ingresar la Informacion de paciente atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : lblHistoria.Select() : Exit Sub
            If chkCorrelativo.Checked = False Then
                objHistoria.GrabarDNI(lblHistoria.Text, txtDNI.Text)
                objHistoria.GrabarUbigeo(lblHistoria.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text)
                objHistoria.GrabarFN(lblHistoria.Text, dtpFecNac.Value.ToShortDateString)
            End If

            If cboDepartamento.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Departamento del Paciente Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDepartamento.Select() : Exit Sub
            If cboProvincia.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Provincia del Paciente Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboProvincia.Select() : Exit Sub
            If cboDistrito.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Distrito del Paciente Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDistrito.Select() : Exit Sub

            Dim vUbigeo As String
            vUbigeo = cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue

            If Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "APP" Then
                If cboTipoAtencion.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Tipo de Atencion", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Select() : Exit Sub
                If cboEstablecimiento.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Ingreso por Establecimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboEstablecimiento.Select() : Exit Sub
                If cboServicio.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Ingreso al Servicio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboServicio.Select() : Exit Sub
                If cboSexo.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Sexo", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboSexo.Select() : Exit Sub
                If txtEdad.Text = "" Then MessageBox.Show("Debe ingresar la Informacion de la Edad del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtEdad.Select() : Exit Sub
            End If

            If txtCIE1.Text = "" Then MessageBox.Show("Debe ingresar por lo menos UN Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE1.Select() : Exit Sub
            If txtCIE1.Text <> "" And cboTD1.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD1.Select() : Exit Sub
            If txtCIE2.Text <> "" And cboTD2.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD2.Select() : Exit Sub
            If txtCIE3.Text <> "" And cboTD3.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD3.Select() : Exit Sub
            If txtCIE4.Text <> "" And cboTD4.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD4.Select() : Exit Sub
            If txtCIE5.Text <> "" And cboTD5.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD5.Select() : Exit Sub
            If txtCIE6.Text <> "" And cboTD6.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD6.Select() : Exit Sub

            If Not IsNumeric(cboDepartamento.SelectedValue) Then MessageBox.Show("Debe Seleccionar el Departamento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDepartamento.Select() : Exit Sub
            If Not IsNumeric(cboProvincia.SelectedValue) Then MessageBox.Show("Debe Seleccionar la Provincia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboProvincia.Select() : Exit Sub
            If Not IsNumeric(cboDistrito.SelectedValue) Then MessageBox.Show("Debe Seleccionar la Distrito", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDistrito.Select() : Exit Sub

            'Dim TAten As String
            'If cboTipoAtencion.Text = "CONVENIO" Then
            '    TAten = "10"
            'ElseIf cboTipoAtencion.Text = "PROGRAMA" Then
            '    TAten = "10"
            'ElseIf cboTipoAtencion.Text = "SIS" Then
            '    TAten = "2"
            'ElseIf cboTipoAtencion.Text = "CREDITO" Then
            '    TAten = "10"
            'ElseIf cboTipoAtencion.Text = "SOAT" Then
            '    TAten = "4"
            'Else
            '    TAten = "1"
            'End If

            If Operacion = 1 Then
                If chkCorrelativo.Checked Then
                    NombrePaciente = ""
                    If Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "APP" Then
                        objInterconsultaE.GrabarSH(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), lblHistoria.Text, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboTipoAtencion.Text, cboSexo.Text, txtEdad.Text, cboTEdad.Text, cboTipoAtencion.Text, txtDNI.Text)
                    Else
                        'Grabar APP
                        objInterconsultaE.GrabarSH(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), 0, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboTipoAtencion.Text, cboSexo.Text, txtEdad.Text, cboTEdad.Text, cboTipoAtencion.Text, lblHistoria.Text)
                    End If
                Else
                    CodCupo = objInterconsultaE.GrabarCodigo(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), lblHistoria.Text, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboTipoAtencion.Text)
                End If
            End If
            If Operacion = 2 Then
                If chkCorrelativo.Checked Then
                    If Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "APP" Then
                        objInterconsultaE.ModificarLabSH(lblHistoria.Tag, dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), lblHistoria.Text, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboSexo.Text, txtEdad.Text, cboTEdad.Text, cboTipoAtencion.Text, txtDNI.Text)
                    Else
                        'Modificar APP
                        objInterconsultaE.ModificarLabSH(lblHistoria.Tag, dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), 0, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboSexo.Text, txtEdad.Text, cboTEdad.Text, cboTipoAtencion.Text, lblHistoria.Text)
                    End If
                Else
                    objInterconsultaE.ModificarLab(lblHistoria.Tag, dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), lblHistoria.Text, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text)
                End If
            End If
            MessageBox.Show("Datos Guardados Correctamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnCancelar_Click(sender, e)
            BuscarAtenciones()
            btnNuevo.Select()
        End If
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If e.KeyCode = Keys.Enter And lvDX.Items.Count > 0 Then lvDX.Select()
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        FiltroCIE()
    End Sub

    Private Sub lvDX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDX.KeyDown
        If e.KeyCode = Keys.Enter And lvDX.SelectedItems.Count > 0 Then
            Dim I As Integer
            Dim dsVer As New DataSet
            dsVer = objCIE10.Buscar(lvDX.SelectedItems(0).SubItems(0).Text, 1)

            If chkCorrelativo.Checked Then
                If cboTEdad.Text = "A" Then EdadA = txtEdad.Text : EdadM = 0 : EdadD = 0
                If cboTEdad.Text = "M" Then EdadA = 0 : EdadM = txtEdad.Text : EdadD = 0
                If cboTEdad.Text = "D" Then EdadA = 0 : EdadM = 0 : EdadD = txtEdad.Text
            End If

            'Verificar Edad
            Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
            If dsVer.Tables(0).Rows(0)("MinTipo") <> "" Then
                Dim RMin, RMax As Double
                If dsVer.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad")) * 360
                If dsVer.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad")) * 30
                If dsVer.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad"))

                If dsVer.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad")) * 360
                If dsVer.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad")) * 30
                If dsVer.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad"))

                If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsVer.Tables(0).Rows(0)("MinEdad") & " " & dsVer.Tables(0).Rows(0)("MinTipo") & " y " & dsVer.Tables(0).Rows(0)("MaxEdad") & " " & dsVer.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            End If

            'Verificar Sexo
            If dsVer.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If dsVer.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


            Select Case nomFiltro
                Case "DESCIE1"
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE1.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes1.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD1.Text = "DEFINITIVO" : txtCIE2.Select() Else cboTD1.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab1.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE2"
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE2.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes2.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD2.Text = "DEFINITIVO" : txtCIE3.Select() Else cboTD2.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab2.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE3"
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE3.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes3.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD3.Text = "DEFINITIVO" : txtCIE4.Select() Else cboTD3.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab3.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE4"
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE4.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes4.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD4.Text = "DEFINITIVO" : txtCIE5.Select() Else cboTD4.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab4.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE5"
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE5.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes5.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD5.Text = "DEFINITIVO" : txtCIE6.Select() Else cboTD5.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab5.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE6"
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE6.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes6.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD6.Text = "DEFINITIVO" : btnGrabar.Select() Else cboTD6.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab6.Select()
                            Exit For
                        End If
                    Next
            End Select
        End If
    End Sub

    Private Sub lvDX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDX.SelectedIndexChanged

    End Sub

    Private Sub lvDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDet.Click
        lvDet_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.SelectedItems(0).SubItems(0).Text <> "" And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar la Atencion de Consulta", "Mensaje de Inrmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If lvDet.SelectedItems(0).SubItems(17).Text = "INTERCONSULTAE" Then
                    objInterconsultaE.EliminarAtencion(lvDet.SelectedItems(0).SubItems(16).Text)
                    BuscarAtenciones()
                Else
                    MessageBox.Show("Este tipo de Atenciones no se Pueden Eliminar", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        chkCorrelativo.Checked = False
        'btnCancelar_Click(sender, e)
        txtCIE1.Text = "" : txtDes1.Text = "" : txtLab1.Text = "" : cboTD1.Text = ""
        txtCIE2.Text = "" : txtDes2.Text = "" : txtLab2.Text = "" : cboTD2.Text = ""
        txtCIE3.Text = "" : txtDes3.Text = "" : txtLab3.Text = "" : cboTD3.Text = ""
        txtCIE4.Text = "" : txtDes4.Text = "" : txtLab4.Text = "" : cboTD4.Text = ""
        txtCIE5.Text = "" : txtDes5.Text = "" : txtLab5.Text = "" : cboTD5.Text = ""
        txtCIE6.Text = "" : txtDes6.Text = "" : txtLab6.Text = "" : cboTD6.Text = ""
        cboTipoAtencion.Text = ""
        cboEstablecimiento.Text = ""
        cboServicio.Text = ""

        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnNuevo.Enabled = True

        Dim Fin As Boolean = False
        Dim dsUbigeo As New DataSet
        If lvDet.SelectedItems.Count > 0 Then
            If lvDet.SelectedItems(0).SubItems(16).Text <> "" Then
                gbHIS.Enabled = True
                If lvDet.SelectedItems(0).SubItems(25).Text = "NO" Then chkCorrelativo.Checked = True
                Operacion = 2
                btnGrabar.Enabled = True
                btnCancelar.Enabled = True
                btnNuevo.Enabled = False

                Select Case lvDet.SelectedItems(0).SubItems(6).Text
                    Case "N"
                        cboEstablecimiento.Text = "NUEVO"
                    Case "C"
                        cboEstablecimiento.Text = "CONTINUADOR"
                    Case "R"
                        cboEstablecimiento.Text = "REINGRESANTE"
                End Select

                Select Case lvDet.SelectedItems(0).SubItems(7).Text
                    Case "N"
                        cboServicio.Text = "NUEVO"
                    Case "C"
                        cboServicio.Text = "CONTINUADOR"
                    Case "R"
                        cboServicio.Text = "REINGRESANTE"
                End Select

                If lvDet.SelectedItems(0).SubItems(14).Text = "10" Then
                    cboTipoAtencion.Text = "PROGRAMA"
                ElseIf lvDet.SelectedItems(0).SubItems(14).Text = "10" Then
                    cboTipoAtencion.Text = "CONVENIO"
                ElseIf lvDet.SelectedItems(0).SubItems(14).Text = "2" Then
                    cboTipoAtencion.Text = "SIS"
                ElseIf lvDet.SelectedItems(0).SubItems(14).Text = "10" Then
                    cboTipoAtencion.Text = "CREDITO"
                ElseIf lvDet.SelectedItems(0).SubItems(14).Text = "4" Then
                    cboTipoAtencion.Text = "SOAT"
                Else
                    cboTipoAtencion.Text = "COMUN"
                End If

                lblHistoria.Tag = lvDet.SelectedItems(0).SubItems(16).Text
                lblHistoria.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(1).Text

                txtDNI.Text = lvDet.SelectedItems(0).SubItems(1).Text
                txtEdad.Text = lvDet.SelectedItems(0).SubItems(4).Text
                If lvDet.SelectedItems(0).SubItems(25).Text = "SI" Then
                    If lvDet.SelectedItems(0).SubItems(18).Text <> "" Then dtpFecNac.Value = lvDet.SelectedItems(0).SubItems(18).Text Else MessageBox.Show("Debe Definir Fecha de Nacimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                cboSexo.Text = lvDet.SelectedItems(0).SubItems(19).Text

                EdadA = Val(lvDet.SelectedItems(0).SubItems(20).Text)
                EdadM = Val(lvDet.SelectedItems(0).SubItems(21).Text)
                EdadD = Val(lvDet.SelectedItems(0).SubItems(22).Text)


                'Diagnostico 1
                txtCIE1.Text = lvDet.SelectedItems(0).SubItems(11).Text
                txtDes1.Enabled = False
                txtDes1.Text = lvDet.SelectedItems(0).SubItems(8).Text
                txtDes1.Enabled = True
                txtLab1.Text = lvDet.SelectedItems(0).SubItems(10).Text
                Select Case lvDet.SelectedItems(0).SubItems(9).Text
                    Case "P"
                        cboTD1.Text = "PRESUNTIVO"
                    Case "D"
                        cboTD1.Text = "DEFINITIVO"
                    Case "R"
                        cboTD1.Text = "REPETITIVO"
                End Select

                'Diagnostico 2
                txtCIE2.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(11).Text
                txtDes2.Enabled = False
                txtDes2.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(8).Text
                txtDes2.Enabled = True
                txtLab2.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(10).Text
                Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(9).Text
                    Case "P"
                        cboTD2.Text = "PRESUNTIVO"
                    Case "D"
                        cboTD2.Text = "DEFINITIVO"
                    Case "R"
                        cboTD2.Text = "REPETITIVO"
                End Select

                'Diagnostico 3
                If Not Fin Then
                    If Not lvDet.SelectedItems(0).Index + 2 > lvDet.Items.Count - 1 Then
                        If lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(16).Text = "" Then
                            txtCIE3.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(11).Text
                            txtDes3.Enabled = False
                            txtDes3.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(8).Text
                            txtDes3.Enabled = True
                            txtLab3.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(10).Text
                            Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(9).Text
                                Case "P"
                                    cboTD3.Text = "PRESUNTIVO"
                                Case "D"
                                    cboTD3.Text = "DEFINITIVO"
                                Case "R"
                                    cboTD3.Text = "REPETITIVO"
                            End Select
                        Else
                            Fin = True
                        End If
                    End If
                End If

                'Diagnostico 4
                If Not Fin Then
                    If Not lvDet.SelectedItems(0).Index + 3 > lvDet.Items.Count - 1 Then
                        If Not lvDet.SelectedItems(0).Index + 2 > lvDet.Items.Count - 1 Then
                            If lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(16).Text = "" Then
                                txtCIE4.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(11).Text
                                txtDes4.Enabled = False
                                txtDes4.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(8).Text
                                txtDes4.Enabled = True
                                txtLab4.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(10).Text
                                Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(9).Text
                                    Case "P"
                                        cboTD4.Text = "PRESUNTIVO"
                                    Case "D"
                                        cboTD4.Text = "DEFINITIVO"
                                    Case "R"
                                        cboTD4.Text = "REPETITIVO"
                                End Select
                            Else
                                Fin = True
                            End If
                        End If
                    End If
                End If

                'Diagnostico 5
                If Not Fin Then
                    If Not lvDet.SelectedItems(0).Index + 4 > lvDet.Items.Count - 1 Then
                        If lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(16).Text = "" Then
                            txtCIE5.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(11).Text
                            txtDes5.Enabled = False
                            txtDes5.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(8).Text
                            txtDes5.Enabled = True
                            txtLab5.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(10).Text
                            Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(9).Text
                                Case "P"
                                    cboTD5.Text = "PRESUNTIVO"
                                Case "D"
                                    cboTD5.Text = "DEFINITIVO"
                                Case "R"
                                    cboTD5.Text = "REPETITIVO"
                            End Select
                        Else
                            Fin = True
                        End If
                    End If
                End If

                'Diagnostico 6
                If Not Fin Then
                    If Not lvDet.SelectedItems(0).Index + 5 > lvDet.Items.Count - 1 Then
                        If lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(16).Text = "" Then
                            txtCIE6.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(11).Text
                            txtDes6.Enabled = False
                            txtDes6.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(8).Text
                            txtDes6.Enabled = True
                            txtLab6.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(10).Text
                            Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(9).Text
                                Case "P"
                                    cboTD6.Text = "PRESUNTIVO"
                                Case "D"
                                    cboTD6.Text = "DEFINITIVO"
                                Case "R"
                                    cboTD6.Text = "REPETITIVO"
                            End Select
                        Else
                            Fin = True
                        End If
                    End If
                End If

                dsUbigeo = objUbigeo.BuscarCodigoT(lvDet.SelectedItems(0).SubItems(3).Text)
                If dsUbigeo.Tables(0).Rows.Count > 0 Then
                    cboDepartamento.Text = dsUbigeo.Tables(0).Rows(0)("Departamento")
                    cboDepartamento_SelectedIndexChanged(sender, e)
                    cboProvincia.Text = dsUbigeo.Tables(0).Rows(0)("Provincia")
                    cboProvincia_SelectedIndexChanged(sender, e)
                    cboDistrito.Text = dsUbigeo.Tables(0).Rows(0)("Distrito")
                End If
            End If
        End If
    End Sub
End Class