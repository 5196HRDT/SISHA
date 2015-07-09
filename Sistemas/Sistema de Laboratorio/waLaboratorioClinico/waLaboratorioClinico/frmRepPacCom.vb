Imports System.Data.SqlClient
Public Class frmRepPacCom
    Dim Cn As New SqlConnection
    Dim objLaboratorio As New Laboratorio
    Dim objTemporal As New tempLabPro

    'Variables Impresion
    Dim FuenteTG As New Font("Lucida Console", 14, FontStyle.Bold)
    Dim FuenteG As New Font("TIMES NEW ROMAN", 20, FontStyle.Bold)
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8)
    Dim FuenteET As New Font("Lucida Console", 8, FontStyle.Bold)
    Dim FuenteP As New Font("Lucida Console", 9, FontStyle.Bold)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim NroFilasTotales As Integer
    Dim NroPaginas As Integer
    Dim NroFilasHoja As Integer
    Dim TotalFilasLV As Integer
    Dim X, Y As Integer
    Dim Total As Integer
    Dim TipoImpresion As String

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BancoSangre()
        Dim dsTabla As New Data.DataSet
        dsTabla = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "", "", "BANCO DE SANGRE", "", 2)

        Dim I As Integer
        Dim Examen As String
        Dim Fila As ListViewItem
        lvBS.Items.Clear()
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            If I = 0 Then
                Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                Fila = lvBS.Items.Add(Examen)
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvBS.Items.Add(Examen)
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                End If
            End If
        Next

        Dim J As Integer
        Dim ST As Integer

        'Informacion de Produccion
        Dim dsPro As New Data.DataSet
        dsPro = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "EMERGENCIA", 1, "BANCO DE SANGRE", "", 1)

        objTemporal.Eliminar()
        For I = 0 To dsPro.Tables(0).Rows.Count - 1
            If dsPro.Tables(0).Rows(I)("Especialidad").ToString <> "" Then
                If dsPro.Tables(0).Rows(I)("ClasLaboratorio") = "BANCO DE SANGRE" Then objTemporal.Grabar(dsPro.Tables(0).Rows(I)("ClasLaboratorio"), dsPro.Tables(0).Rows(I)("Area"), dsPro.Tables(0).Rows(I)("Especialidad"), dsPro.Tables(0).Rows(I)("Descripcion"), dsPro.Tables(0).Rows(I)("Total"))
            End If
        Next

        'Emergencia
        For J = 1 To 6
            For I = 0 To lvBS.Items.Count - 1
                dsPro = objTemporal.Buscar("BANCO DE SANGRE", "EMERGENCIA", lvBS.Columns(J).Text, lvBS.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvBS.Items(I).SubItems(J).Text = 0 Else lvBS.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvBS.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvBS.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'STEME
        ST = 0
        For I = 0 To lvBS.Items.Count - 1
            For J = 1 To 6
                ST = ST + Val(lvBS.Items(I).SubItems(J).Text)
            Next
            lvBS.Items(I).SubItems(7).Text = ST.ToString
            ST = 0
        Next

        'Hospitalizacion
        For J = 8 To 12
            For I = 0 To lvBS.Items.Count - 1
                dsPro = objTemporal.Buscar("BANCO DE SANGRE", "HOSPITALIZACION", lvBS.Columns(J).Text, lvBS.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvBS.Items(I).SubItems(J).Text = 0 Else lvBS.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvBS.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvBS.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'STHOSP
        ST = 0
        For I = 0 To lvBS.Items.Count - 1
            For J = 8 To 12
                ST = ST + Val(lvBS.Items(I).SubItems(J).Text)
            Next
            lvBS.Items(I).SubItems(13).Text = ST.ToString
            ST = 0
        Next

        'Consulta Externa
        For J = 14 To 18
            For I = 0 To lvBS.Items.Count - 1
                dsPro = objTemporal.Buscar("BANCO DE SANGRE", "CONSULTA EXTERNA", lvBS.Columns(J).Text, lvBS.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvBS.Items(I).SubItems(J).Text = 0 Else lvBS.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvBS.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvBS.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STCE
        ST = 0
        For I = 0 To lvBS.Items.Count - 1
            For J = 14 To 18
                ST = ST + Val(lvBS.Items(I).SubItems(J).Text)
            Next
            lvBS.Items(I).SubItems(19).Text = ST.ToString
            ST = 0
        Next


        'Pintado Final
        Total = 0
        Fila = lvBS.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvBS.Items(lvBS.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 19
            For I = 0 To lvBS.Items.Count - 2
                Total = Total + Val(lvBS.Items(I).SubItems(J).Text)
            Next
            lvBS.Items(lvBS.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvBS.Items.Count - 1
            lvBS.Items(I).SubItems(20).Text = Val(lvBS.Items(I).SubItems(7).Text) + Val(lvBS.Items(I).SubItems(13).Text) + Val(lvBS.Items(I).SubItems(19).Text)
        Next

        For I = 0 To lvBS.Items.Count - 1
            lvBS.Items(I).SubItems(7).BackColor = Color.Coral
            lvBS.Items(I).SubItems(13).BackColor = Color.Coral
            lvBS.Items(I).SubItems(19).BackColor = Color.Coral
            lvBS.Items(I).SubItems(20).BackColor = Color.Crimson
            lvBS.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvBS.Columns.Count - 2
            lvBS.Items(lvBS.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next
    End Sub

    Private Sub Bioquimica()
        Dim dsTabla As New Data.DataSet
        dsTabla = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "", "", "BIOQUIMICA", "", 2)

        Dim I As Integer
        Dim Examen As String
        Dim Fila As ListViewItem
        lvB.Items.Clear()
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            If I = 0 Then
                Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                Fila = lvB.Items.Add(Examen)
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
                Fila.SubItems.Add("0")
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvB.Items.Add(Examen)
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add("0")
                End If
            End If
        Next
        Dim J As Integer
        Dim ST As Integer

        Dim dsPro As New Data.DataSet
        dsPro = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "EMERGENCIA", 1, "BIOQUIMICA", "", 1)

        objTemporal.Eliminar()
        For I = 0 To dsPro.Tables(0).Rows.Count - 1
            If dsPro.Tables(0).Rows(I)("Especialidad").ToString <> "" Then
                If dsPro.Tables(0).Rows(I)("ClasLaboratorio") = "BIOQUIMICA" Then objTemporal.Grabar(dsPro.Tables(0).Rows(I)("ClasLaboratorio"), dsPro.Tables(0).Rows(I)("Area"), dsPro.Tables(0).Rows(I)("Especialidad"), dsPro.Tables(0).Rows(I)("Descripcion"), dsPro.Tables(0).Rows(I)("Total"))
            End If
        Next

        'Emergencia
        For J = 1 To 6
            For I = 0 To lvB.Items.Count - 1
                dsPro = objTemporal.Buscar("BIOQUIMICA", "EMERGENCIA", lvB.Columns(J).Text, lvB.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvB.Items(I).SubItems(J).Text = 0 Else lvB.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvB.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvB.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STEME
        ST = 0
        For I = 0 To lvB.Items.Count - 1
            For J = 1 To 6
                ST = ST + Val(lvB.Items(I).SubItems(J).Text)
            Next
            lvB.Items(I).SubItems(7).Text = ST.ToString
            ST = 0
        Next
        'Hospitalizacion
        For J = 8 To 12
            For I = 0 To lvB.Items.Count - 1
                dsPro = objTemporal.Buscar("BIOQUIMICA", "HOSPITALIZACION", lvB.Columns(J).Text, lvB.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvB.Items(I).SubItems(J).Text = 0 Else lvB.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvB.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvB.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STHOSP
        ST = 0
        For I = 0 To lvB.Items.Count - 1
            For J = 8 To 12
                ST = ST + Val(lvB.Items(I).SubItems(J).Text)
            Next
            lvB.Items(I).SubItems(13).Text = ST.ToString
            ST = 0
        Next
        'Consulta Externa
        For J = 14 To 18
            For I = 0 To lvB.Items.Count - 1
                dsPro = objTemporal.Buscar("BIOQUIMICA", "CONSULTA EXTERNA", lvB.Columns(J).Text, lvB.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvB.Items(I).SubItems(J).Text = 0 Else lvB.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvB.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvB.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STCE
        ST = 0
        For I = 0 To lvB.Items.Count - 1
            For J = 14 To 18
                ST = ST + Val(lvB.Items(I).SubItems(J).Text)
            Next
            lvB.Items(I).SubItems(19).Text = ST.ToString
            ST = 0
        Next

        Total = 0
        Fila = lvB.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvB.Items(lvBS.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 19
            For I = 0 To lvB.Items.Count - 2
                Total = Total + Val(lvB.Items(I).SubItems(J).Text)
            Next
            lvB.Items(lvB.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvB.Items.Count - 1
            lvB.Items(I).SubItems(20).Text = Val(lvB.Items(I).SubItems(7).Text) + Val(lvB.Items(I).SubItems(13).Text) + Val(lvB.Items(I).SubItems(19).Text)
        Next

        For I = 0 To lvB.Items.Count - 1
            lvB.Items(I).SubItems(7).BackColor = Color.Coral
            lvB.Items(I).SubItems(13).BackColor = Color.Coral
            lvB.Items(I).SubItems(19).BackColor = Color.Coral
            lvB.Items(I).SubItems(20).BackColor = Color.Crimson
            lvB.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvB.Columns.Count - 2
            lvB.Items(lvB.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next
    End Sub

    Private Sub Hematologia()
        Dim dsTabla As New Data.DataSet
        dsTabla = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "", "", "HEMATOLOGIA", "", 2)

        Dim I As Integer
        Dim Examen As String
        Dim Fila As ListViewItem
        lvH.Items.Clear()
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            If I = 0 Then
                Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                Fila = lvH.Items.Add(Examen)
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvH.Items.Add(Examen)
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
            End If
        Next

        Dim J As Integer
        Dim ST As Integer

        Dim dsPro As New Data.DataSet
        dsPro = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "EMERGENCIA", 1, "HEMATOLOGIA", "", 1)

        objTemporal.Eliminar()
        For I = 0 To dsPro.Tables(0).Rows.Count - 1
            If dsPro.Tables(0).Rows(I)("Especialidad").ToString <> "" Then
                If dsPro.Tables(0).Rows(I)("ClasLaboratorio") = "HEMATOLOGIA" Then objTemporal.Grabar(dsPro.Tables(0).Rows(I)("ClasLaboratorio"), dsPro.Tables(0).Rows(I)("Area"), dsPro.Tables(0).Rows(I)("Especialidad"), dsPro.Tables(0).Rows(I)("Descripcion"), dsPro.Tables(0).Rows(I)("Total"))
            End If
        Next

        'Emergencia
        For J = 1 To 6
            For I = 0 To lvH.Items.Count - 1
                dsPro = objTemporal.Buscar("HEMATOLOGIA", "EMERGENCIA", lvH.Columns(J).Text, lvH.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvH.Items(I).SubItems(J).Text = 0 Else lvH.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvH.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvH.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STEME
        ST = 0
        For I = 0 To lvH.Items.Count - 1
            For J = 1 To 6
                ST = ST + Val(lvH.Items(I).SubItems(J).Text)
            Next
            lvH.Items(I).SubItems(7).Text = ST.ToString
            ST = 0
        Next
        'Hospitalizacion
        For J = 8 To 12
            For I = 0 To lvH.Items.Count - 1
                dsPro = objTemporal.Buscar("HEMATOLOGIA", "HOSPITALIZACION", lvH.Columns(J).Text, lvH.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvH.Items(I).SubItems(J).Text = 0 Else lvH.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvH.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvH.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STHOSP
        ST = 0
        For I = 0 To lvH.Items.Count - 1
            For J = 8 To 12
                ST = ST + Val(lvH.Items(I).SubItems(J).Text)
            Next
            lvH.Items(I).SubItems(13).Text = ST.ToString
            ST = 0
        Next
        'Consulta Externa
        For J = 14 To 18
            For I = 0 To lvH.Items.Count - 1
                dsPro = objTemporal.Buscar("HEMATOLOGIA", "CONSULTA EXTERNA", lvH.Columns(J).Text, lvH.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvH.Items(I).SubItems(J).Text = 0 Else lvH.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvH.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvH.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STCE
        ST = 0
        For I = 0 To lvH.Items.Count - 1
            For J = 14 To 18
                ST = ST + Val(lvH.Items(I).SubItems(J).Text)
            Next
            lvH.Items(I).SubItems(19).Text = ST.ToString
            ST = 0
        Next

        Total = 0
        Fila = lvH.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvH.Items(lvH.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 19
            For I = 0 To lvH.Items.Count - 2
                Total = Total + Val(lvH.Items(I).SubItems(J).Text)
            Next
            lvH.Items(lvH.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvH.Items.Count - 1
            lvH.Items(I).SubItems(20).Text = Val(lvH.Items(I).SubItems(7).Text) + Val(lvH.Items(I).SubItems(13).Text) + Val(lvH.Items(I).SubItems(19).Text)
        Next

        For I = 0 To lvH.Items.Count - 1
            lvH.Items(I).SubItems(7).BackColor = Color.Coral
            lvH.Items(I).SubItems(13).BackColor = Color.Coral
            lvH.Items(I).SubItems(19).BackColor = Color.Coral
            lvH.Items(I).SubItems(20).BackColor = Color.Crimson
            lvH.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvH.Columns.Count - 2
            lvH.Items(lvH.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next

    End Sub

    Private Sub Inmunologia()
        Dim dsTabla As New Data.DataSet
        dsTabla = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "", "", "INMUNOLOGIA", "", 2)

        Dim I As Integer
        Dim Examen As String
        Dim Fila As ListViewItem
        lvI.Items.Clear()
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            If I = 0 Then
                Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                Fila = lvI.Items.Add(Examen)
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvI.Items.Add(Examen)
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
            End If
        Next
        Dim J As Integer
        Dim ST As Integer

        Dim dsPro As New Data.DataSet
        dsPro = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "EMERGENCIA", 1, "INMUNOLOGIA", "", 1)

        objTemporal.Eliminar()
        For I = 0 To dsPro.Tables(0).Rows.Count - 1
            If dsPro.Tables(0).Rows(I)("Especialidad").ToString <> "" Then
                If dsPro.Tables(0).Rows(I)("ClasLaboratorio") = "INMUNOLOGIA" Then objTemporal.Grabar(dsPro.Tables(0).Rows(I)("ClasLaboratorio"), dsPro.Tables(0).Rows(I)("Area"), dsPro.Tables(0).Rows(I)("Especialidad"), dsPro.Tables(0).Rows(I)("Descripcion"), dsPro.Tables(0).Rows(I)("Total"))
            End If
        Next

        'Emergencia
        For J = 1 To 6
            For I = 0 To lvI.Items.Count - 1
                dsPro = objTemporal.Buscar("INMUNOLOGIA", "EMERGENCIA", lvI.Columns(J).Text, lvI.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvI.Items(I).SubItems(J).Text = 0 Else lvI.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvI.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvI.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STEME
        ST = 0
        For I = 0 To lvI.Items.Count - 1
            For J = 1 To 6
                ST = ST + Val(lvI.Items(I).SubItems(J).Text)
            Next
            lvI.Items(I).SubItems(7).Text = ST.ToString
            ST = 0
        Next
        'Hospitalizacion
        For J = 8 To 12
            For I = 0 To lvI.Items.Count - 1
                dsPro = objTemporal.Buscar("INMUNOLOGIA", "HOSPITALIZACION", lvI.Columns(J).Text, lvI.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvI.Items(I).SubItems(J).Text = 0 Else lvI.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvI.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvI.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STHOSP
        ST = 0
        For I = 0 To lvI.Items.Count - 1
            For J = 8 To 12
                ST = ST + Val(lvI.Items(I).SubItems(J).Text)
            Next
            lvI.Items(I).SubItems(13).Text = ST.ToString
            ST = 0
        Next
        'Consulta Externa
        For J = 14 To 18
            For I = 0 To lvI.Items.Count - 1
                dsPro = objTemporal.Buscar("INMUNOLOGIA", "CONSULTA EXTERNA", lvI.Columns(J).Text, lvI.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvI.Items(I).SubItems(J).Text = 0 Else lvI.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvI.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvI.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STCE
        ST = 0
        For I = 0 To lvI.Items.Count - 1
            For J = 14 To 18
                ST = ST + Val(lvI.Items(I).SubItems(J).Text)
            Next
            lvI.Items(I).SubItems(19).Text = ST.ToString
            ST = 0
        Next

        Total = 0
        Fila = lvI.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvI.Items(lvI.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 19
            For I = 0 To lvI.Items.Count - 2
                Total = Total + Val(lvI.Items(I).SubItems(J).Text)
            Next
            lvI.Items(lvI.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvI.Items.Count - 1
            lvI.Items(I).SubItems(20).Text = Val(lvI.Items(I).SubItems(7).Text) + Val(lvI.Items(I).SubItems(13).Text) + Val(lvI.Items(I).SubItems(19).Text)
        Next

        For I = 0 To lvI.Items.Count - 1
            lvI.Items(I).SubItems(7).BackColor = Color.Coral
            lvI.Items(I).SubItems(13).BackColor = Color.Coral
            lvI.Items(I).SubItems(19).BackColor = Color.Coral
            lvI.Items(I).SubItems(20).BackColor = Color.Crimson
            lvI.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvI.Columns.Count - 2
            lvI.Items(lvI.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next
    End Sub

    Private Sub Microbiologia()
        Dim dsTabla As New Data.DataSet
        dsTabla = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "", "", "MICROBIOLOGIA", "", 2)


        Dim I As Integer
        Dim Examen As String
        Dim Fila As ListViewItem
        lvM.Items.Clear()
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            If I = 0 Then
                Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                Fila = lvM.Items.Add(Examen)
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvM.Items.Add(Examen)
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
            End If
        Next
        Dim J As Integer
        Dim ST As Integer

        Dim dsPro As New Data.DataSet
        dsPro = objLaboratorio.ProduccionComun(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "EMERGENCIA", 1, "MICROBIOLOGIA", "", 1)

        objTemporal.Eliminar()
        For I = 0 To dsPro.Tables(0).Rows.Count - 1
            If dsPro.Tables(0).Rows(I)("Especialidad").ToString <> "" Then
                If dsPro.Tables(0).Rows(I)("ClasLaboratorio") = "MICROBIOLOGIA" Then objTemporal.Grabar(dsPro.Tables(0).Rows(I)("ClasLaboratorio"), dsPro.Tables(0).Rows(I)("Area"), dsPro.Tables(0).Rows(I)("Especialidad"), dsPro.Tables(0).Rows(I)("Descripcion"), dsPro.Tables(0).Rows(I)("Total"))
            End If
        Next

        'Emergencia
        For J = 1 To 6
            For I = 0 To lvM.Items.Count - 1
                dsPro = objTemporal.Buscar("MICROBIOLOGIA", "EMERGENCIA", lvM.Columns(J).Text, lvM.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvM.Items(I).SubItems(J).Text = 0 Else lvM.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvM.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvM.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STEME
        ST = 0
        For I = 0 To lvM.Items.Count - 1
            For J = 1 To 6
                ST = ST + Val(lvM.Items(I).SubItems(J).Text)
            Next
            lvM.Items(I).SubItems(7).Text = ST.ToString
            ST = 0
        Next
        'Hospitalizacion
        For J = 8 To 12
            For I = 0 To lvM.Items.Count - 1
                dsPro = objTemporal.Buscar("MICROBIOLOGIA", "HOSPITALIZACION", lvM.Columns(J).Text, lvM.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvM.Items(I).SubItems(J).Text = 0 Else lvM.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvM.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvM.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STHOSP
        ST = 0
        For I = 0 To lvM.Items.Count - 1
            For J = 8 To 12
                ST = ST + Val(lvM.Items(I).SubItems(J).Text)
            Next
            lvM.Items(I).SubItems(13).Text = ST.ToString
            ST = 0
        Next
        'Consulta Externa
        For J = 14 To 18
            For I = 0 To lvM.Items.Count - 1
                dsPro = objTemporal.Buscar("MICROBIOLOGIA", "CONSULTA EXTERNA", lvM.Columns(J).Text, lvM.Items(I).SubItems(0).Text)
                If dsPro.Tables.Count > 0 Then
                    If dsPro.Tables(0).Rows.Count > 0 Then
                        If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvM.Items(I).SubItems(J).Text = 0 Else lvM.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                    Else
                        lvM.Items(I).SubItems(J).Text = 0
                    End If
                Else
                    lvM.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
        'STCE
        ST = 0
        For I = 0 To lvM.Items.Count - 1
            For J = 14 To 18
                ST = ST + Val(lvM.Items(I).SubItems(J).Text)
            Next
            lvM.Items(I).SubItems(19).Text = ST.ToString
            ST = 0
        Next

        Total = 0
        Fila = lvM.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvM.Items(lvM.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 19
            For I = 0 To lvM.Items.Count - 2
                Total = Total + Val(lvM.Items(I).SubItems(J).Text)
            Next
            lvM.Items(lvM.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvM.Items.Count - 1
            lvM.Items(I).SubItems(20).Text = Val(lvM.Items(I).SubItems(7).Text) + Val(lvM.Items(I).SubItems(13).Text) + Val(lvM.Items(I).SubItems(19).Text)
        Next

        For I = 0 To lvM.Items.Count - 1
            lvM.Items(I).SubItems(7).BackColor = Color.Coral
            lvM.Items(I).SubItems(13).BackColor = Color.Coral
            lvM.Items(I).SubItems(19).BackColor = Color.Coral
            lvM.Items(I).SubItems(20).BackColor = Color.Crimson
            lvM.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvM.Columns.Count - 2
            lvM.Items(lvM.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BancoSangre()
        Bioquimica()
        Hematologia()
        Inmunologia()
        Microbiologia()

        MessageBox.Show("Resultado de Produccion de Laboratorio", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnImprimirBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirBS.Click
        TipoImpresion = "BS"
        If MessageBox.Show("Esta seguro de Imprimir Reporte Banco de Sangre", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            PageSetupDialog1.Document = pdcDocumento
            pdImpresion.Document = pdcDocumento
            ppdVistaPrevia.Document = pdcDocumento
            pdcDocumento.DefaultPageSettings.Landscape = True
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub ImprimirBS(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        AltoTexto = Imp.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Dim I, J As Integer
        Y = 10
        With Imp.Graphics
            Y = 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia", FuenteTG, Pincel, 60, Y)
            Y = Y + 20

            .DrawString("REPORTE DE PRODUCCION EN BANCO DE SANGRE - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 150, Y)
            Y = Y + 40

            .DrawString("EMERGENCIA" & StrDup(25, " ") & "HOSPITALIZACION" & StrDup(25, " ") & "CONSULTA EXTERNA", FuenteE, Pincel, 300, Y)
        End With
        Filas = 10
        NroFilasHoja = 0
        Y = Y + 10
        X = 240
        With Imp.Graphics
            For J = 1 To lvBS.Columns.Count - 1
                .DrawString(Microsoft.VisualBasic.Left(lvBS.Columns(J).Text, 5), FuenteE, Pincel, X, Y)
                X += 40
            Next
            X = 0
            Y += 10
            .DrawLine(Pens.Black, 20, Y, 1100, Y)
            Y += 10
            For I = 0 To lvBS.Items.Count - 1
                For J = 0 To lvBS.Columns.Count - 1
                    If J = 0 Then
                        .DrawString(Microsoft.VisualBasic.Left(lvBS.Items(I).SubItems(J).Text, 30), FuenteE, Pincel, 20, Y)
                        X += 200
                    Else
                        'Resaltado
                        If J = 7 Or J = 13 Or J = 19 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvBS.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        ElseIf J = 20 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvBS.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        Else
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvBS.Items(I).SubItems(J).Text, 4), FuenteE, Pincel, 40 + X, Y)
                        End If
                        X += 40
                    End If
                Next
                Y += 9
                X = 0
                .DrawLine(Pens.Black, 20, Y, 1100, Y)
                Y += 8
            Next
        End With
    End Sub

    Private Sub ImprimirB(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        AltoTexto = Imp.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Dim I, J As Integer
        Y = 10
        With Imp.Graphics
            Y = 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia", FuenteTG, Pincel, 60, Y)
            Y = Y + 20

            .DrawString("REPORTE DE PRODUCCION EN BIOQUIMICA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 150, Y)
            Y = Y + 40

            .DrawString("EMERGENCIA" & StrDup(25, " ") & "HOSPITALIZACION" & StrDup(25, " ") & "CONSULTA EXTERNA", FuenteE, Pincel, 300, Y)
        End With

        Filas = 10
        NroFilasHoja = 0
        Y = Y + 10
        X = 240
        With Imp.Graphics
            For J = 1 To lvB.Columns.Count - 1
                .DrawString(Microsoft.VisualBasic.Left(lvB.Columns(J).Text, 5), FuenteE, Pincel, X, Y)
                X += 40
            Next
            X = 0
            Y += 20
            .DrawLine(Pens.Black, 20, Y, 1100, Y)
            Y += 10
            For I = 0 To lvB.Items.Count - 1
                For J = 0 To lvB.Columns.Count - 1
                    If J = 0 Then
                        .DrawString(Microsoft.VisualBasic.Left(lvB.Items(I).SubItems(J).Text, 30), FuenteE, Pincel, 20, Y)
                        X += 200
                    Else
                        'Resaltado
                        If J = 7 Or J = 13 Or J = 19 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvB.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        ElseIf J = 20 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvB.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        Else
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvB.Items(I).SubItems(J).Text, 4), FuenteE, Pincel, 40 + X, Y)
                        End If
                        X += 40
                    End If
                Next
                Y += 9
                X = 0
                .DrawLine(Pens.Black, 20, Y, 1100, Y)
                Y += 8
            Next
        End With
    End Sub

    Private Sub ImprimirH(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        AltoTexto = Imp.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Dim I, J As Integer
        Y = 10
        With Imp.Graphics
            Y = 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia", FuenteTG, Pincel, 60, Y)
            Y = Y + 20

            .DrawString("REPORTE DE PRODUCCION EN HEMATOLOGIA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 150, Y)
            Y = Y + 40

            .DrawString("EMERGENCIA" & StrDup(25, " ") & "HOSPITALIZACION" & StrDup(25, " ") & "CONSULTA EXTERNA", FuenteE, Pincel, 300, Y)
        End With

        Filas = 10
        NroFilasHoja = 0
        Y = Y + 10
        X = 240
        With Imp.Graphics
            For J = 1 To lvH.Columns.Count - 1
                .DrawString(Microsoft.VisualBasic.Left(lvH.Columns(J).Text, 5), FuenteE, Pincel, X, Y)
                X += 40
            Next
            X = 0
            Y += 20
            .DrawLine(Pens.Black, 20, Y, 1100, Y)
            Y += 10
            For I = 0 To lvH.Items.Count - 1
                For J = 0 To lvH.Columns.Count - 1
                    If J = 0 Then
                        .DrawString(Microsoft.VisualBasic.Left(lvH.Items(I).SubItems(J).Text, 30), FuenteE, Pincel, 20, Y)
                        X += 200
                    Else
                        'Resaltado
                        If J = 7 Or J = 13 Or J = 19 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvH.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        ElseIf J = 20 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvH.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        Else
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvH.Items(I).SubItems(J).Text, 4), FuenteE, Pincel, 40 + X, Y)
                        End If
                        X += 40
                    End If
                Next
                Y += 9
                X = 0
                .DrawLine(Pens.Black, 20, Y, 1100, Y)
                Y += 9
            Next
        End With
    End Sub

    Private Sub ImprimirI(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        AltoTexto = Imp.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Dim I, J As Integer
        Y = 10
        With Imp.Graphics
            Y = 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia", FuenteTG, Pincel, 60, Y)
            Y = Y + 20

            .DrawString("REPORTE DE PRODUCCION EN INMUNOLOGIA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 150, Y)
            Y = Y + 40

            .DrawString("EMERGENCIA" & StrDup(25, " ") & "HOSPITALIZACION" & StrDup(25, " ") & "CONSULTA EXTERNA", FuenteE, Pincel, 300, Y)
        End With

        Filas = 10
        NroFilasHoja = 0
        Y = Y + 10
        X = 240
        With Imp.Graphics
            For J = 1 To lvI.Columns.Count - 1
                .DrawString(Microsoft.VisualBasic.Left(lvI.Columns(J).Text, 5), FuenteE, Pincel, X, Y)
                X += 40
            Next
            X = 0
            Y += 20
            .DrawLine(Pens.Black, 20, Y, 1100, Y)
            Y += 10
            For I = 0 To lvI.Items.Count - 1
                For J = 0 To lvI.Columns.Count - 1
                    If J = 0 Then
                        .DrawString(Microsoft.VisualBasic.Left(lvI.Items(I).SubItems(J).Text, 30), FuenteE, Pincel, 20, Y)
                        X += 200
                    Else
                        'Resaltado
                        If J = 7 Or J = 13 Or J = 19 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvI.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        ElseIf J = 20 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvI.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        Else
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvI.Items(I).SubItems(J).Text, 4), FuenteE, Pincel, 40 + X, Y)
                        End If
                        X += 40
                    End If
                Next
                Y += 9
                X = 0
                .DrawLine(Pens.Black, 20, Y, 1100, Y)
                Y += 8
            Next
        End With
    End Sub

    Private Sub ImprimirM(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        AltoTexto = Imp.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Dim I, J As Integer
        Y = 10
        With Imp.Graphics
            Y = 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia", FuenteTG, Pincel, 60, Y)
            Y = Y + 20

            .DrawString("REPORTE DE PRODUCCION EN MICROBIOLOGIA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 150, Y)
            Y = Y + 40

            .DrawString("EMERGENCIA" & StrDup(25, " ") & "HOSPITALIZACION" & StrDup(25, " ") & "CONSULTA EXTERNA", FuenteE, Pincel, 300, Y)
        End With

        Filas = 10
        NroFilasHoja = 0
        Y = Y + 10
        X = 240
        With Imp.Graphics
            For J = 1 To lvM.Columns.Count - 1
                .DrawString(Microsoft.VisualBasic.Left(lvM.Columns(J).Text, 5), FuenteE, Pincel, X, Y)
                X += 40
            Next
            X = 0
            Y += 20
            .DrawLine(Pens.Black, 20, Y, 1100, Y)
            Y += 10
            For I = 0 To lvM.Items.Count - 1
                For J = 0 To lvM.Columns.Count - 1
                    If J = 0 Then
                        .DrawString(Microsoft.VisualBasic.Left(lvM.Items(I).SubItems(J).Text, 30), FuenteE, Pincel, 20, Y)
                        X += 200
                    Else
                        'Resaltado
                        If J = 7 Or J = 13 Or J = 19 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvM.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        ElseIf J = 20 Then
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvM.Items(I).SubItems(J).Text, 4), FuenteET, Pincel, 40 + X, Y)
                        Else
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvM.Items(I).SubItems(J).Text, 4), FuenteE, Pincel, 40 + X, Y)
                        End If
                        X += 40
                    End If
                Next
                Y += 9
                X = 0
                .DrawLine(Pens.Black, 20, Y, 1100, Y)
                Y += 8
            Next
        End With
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Select Case TipoImpresion
            Case "BS"
                NroFilasHoja = lvBS.Items.Count - 1
                ImprimirBS(e)
            Case "B"
                NroFilasHoja = lvB.Items.Count - 1
                ImprimirB(e)
            Case "H"
                NroFilasHoja = lvH.Items.Count - 1
                ImprimirH(e)
            Case "I"
                NroFilasHoja = lvI.Items.Count - 1
                ImprimirI(e)
            Case "M"
                NroFilasHoja = lvM.Items.Count - 1
                ImprimirM(e)
        End Select
    End Sub

    Private Sub btnImprimirB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimirB.Click
        TipoImpresion = "B"
        If MessageBox.Show("Esta seguro de Imprimir Reporte Bioquimica", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            PageSetupDialog1.Document = pdcDocumento
            pdImpresion.Document = pdcDocumento
            ppdVistaPrevia.Document = pdcDocumento
            pdcDocumento.DefaultPageSettings.Landscape = True
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub btnImprimirH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimirH.Click
        TipoImpresion = "H"
        If MessageBox.Show("Esta seguro de Imprimir Reporte Hematologia", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            PageSetupDialog1.Document = pdcDocumento
            pdImpresion.Document = pdcDocumento
            ppdVistaPrevia.Document = pdcDocumento
            pdcDocumento.DefaultPageSettings.Landscape = True
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub btnImprimirI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimirI.Click
        TipoImpresion = "I"
        If MessageBox.Show("Esta seguro de Imprimir Reporte Inmunologia", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            PageSetupDialog1.Document = pdcDocumento
            pdImpresion.Document = pdcDocumento
            ppdVistaPrevia.Document = pdcDocumento
            pdcDocumento.DefaultPageSettings.Landscape = True
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub btnMicrobiologia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMicrobiologia.Click
        TipoImpresion = "M"
        If MessageBox.Show("Esta seguro de Imprimir Reporte Microbiologia", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            PageSetupDialog1.Document = pdcDocumento
            pdImpresion.Document = pdcDocumento
            ppdVistaPrevia.Document = pdcDocumento
            pdcDocumento.DefaultPageSettings.Landscape = True
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub frmRepPacCom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class