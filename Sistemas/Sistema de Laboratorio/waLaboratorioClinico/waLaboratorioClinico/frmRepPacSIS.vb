Imports System.Data.SqlClient
Public Class frmRepPacSIS
    Dim Cn As New SqlConnection
    Dim objLaboratorio As New Laboratorio
    Dim objProduccion As New SIS

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
    Dim TipoImpresion As String

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BancoSangre()
        'Banco de Sangre
        Dim dsTabla As New Data.DataSet
        dsTabla = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "BANCO DE SANGRE", "", "", 3)

        Dim I As Integer
        Dim Examen As String
        Dim Fila As ListViewItem
        lvBS.Items.Clear()
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            If I = 0 Then
                Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                Fila = lvBS.Items.Add(Examen)
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvBS.Items.Add(Examen)
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
            End If
        Next
        Dim J As Integer

        'Emergencia
        For J = 1 To 1
            For I = 0 To lvBS.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "BANCO DE SANGRE", "EMERGENCIA", lvBS.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvBS.Items(I).SubItems(J).Text = 0 Else lvBS.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvBS.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'Hospitalizacion
        For J = 2 To 2
            For I = 0 To lvBS.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "BANCO DE SANGRE", "HOSPITALIZACION", lvBS.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvBS.Items(I).SubItems(J).Text = 0 Else lvBS.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvBS.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
       
        'Consulta Externa
        For J = 3 To 3
            For I = 0 To lvBS.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "BANCO DE SANGRE", "", lvBS.Items(I).SubItems(0).Text, 7)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvBS.Items(I).SubItems(J).Text = 0 Else lvBS.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvBS.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
    End Sub

    Private Sub Bioquimica()
        Dim dsTabla As New Data.DataSet
        dsTabla = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "BIOQUIMICA", "", "", 3)

        Dim I As Integer
        Dim Examen As String
        Dim Fila As ListViewItem
        lvB.Items.Clear()
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            If I = 0 Then
                Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                Fila = lvB.Items.Add(Examen)
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvB.Items.Add(Examen)
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
            End If
        Next
        Dim J As Integer

        'Emergencia
        For J = 1 To 1
            For I = 0 To lvB.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "BIOQUIMICA", "EMERGENCIA", lvB.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvB.Items(I).SubItems(J).Text = 0 Else lvB.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvB.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'Hospitalizacion
        For J = 2 To 2
            For I = 0 To lvB.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "BIOQUIMICA", "HOSPITALIZACION", lvB.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvB.Items(I).SubItems(J).Text = 0 Else lvB.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvB.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'Consulta Externa
        For J = 3 To 3
            For I = 0 To lvB.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "BIOQUIMICA", "", lvB.Items(I).SubItems(0).Text, 7)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvB.Items(I).SubItems(J).Text = 0 Else lvB.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvB.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
    End Sub

    Private Sub Hematologia()
        Dim dsTabla As New Data.DataSet
        dsTabla = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "HEMATOLOGIA", "", "", 3)

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
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvH.Items.Add(Examen)
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
            End If
        Next
        Dim J As Integer

        'Emergencia
        For J = 1 To 1
            For I = 0 To lvH.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "HEMATOLOGIA", "EMERGENCIA", lvH.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvH.Items(I).SubItems(J).Text = 0 Else lvH.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvH.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'Hospitalizacion
        For J = 2 To 2
            For I = 0 To lvH.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "HEMATOLOGIA", "HOSPITALIZACION", lvH.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvH.Items(I).SubItems(J).Text = 0 Else lvH.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvH.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'Consulta Externa
        For J = 3 To 3
            For I = 0 To lvH.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "HEMATOLOGIA", "", lvH.Items(I).SubItems(0).Text, 7)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvH.Items(I).SubItems(J).Text = 0 Else lvH.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvH.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
    End Sub

    Private Sub Inmunologia()
        Dim dsTabla As New Data.DataSet
        dsTabla = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "INMUNOLOGIA", "", "", 3)

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
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvI.Items.Add(Examen)
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
            End If
        Next
        Dim J As Integer

        'Emergencia
        For J = 1 To 1
            For I = 0 To lvI.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "INMUNOLOGIA", "EMERGENCIA", lvI.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvI.Items(I).SubItems(J).Text = 0 Else lvI.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvI.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'Hospitalizacion
        For J = 2 To 2
            For I = 0 To lvI.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "INMUNOLOGIA", "HOSPITALIZACION", lvI.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvI.Items(I).SubItems(J).Text = 0 Else lvI.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvI.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'Consulta Externa
        For J = 3 To 3
            For I = 0 To lvI.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "INMUNOLOGIA", "", lvI.Items(I).SubItems(0).Text, 7)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvI.Items(I).SubItems(J).Text = 0 Else lvI.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvI.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
    End Sub

    Private Sub Microbiologia()
        Dim dsTabla As New Data.DataSet
        dsTabla = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "MICROBIOLOGIA", "", "", 3)

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
            Else
                If Examen <> dsTabla.Tables(0).Rows(I)("Descripcion") Then
                    Examen = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Fila = lvM.Items.Add(Examen)
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
            End If
        Next
        Dim J As Integer

        'Emergencia
        For J = 1 To 1
            For I = 0 To lvM.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "MICROBIOLOGIA", "EMERGENCIA", lvM.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvM.Items(I).SubItems(J).Text = 0 Else lvM.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvM.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'Hospitalizacion
        For J = 2 To 2
            For I = 0 To lvM.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "MICROBIOLOGIA", "HOSPITALIZACION", lvM.Items(I).SubItems(0).Text, 6)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvM.Items(I).SubItems(J).Text = 0 Else lvM.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvM.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next

        'Consulta Externa
        For J = 3 To 3
            For I = 0 To lvM.Items.Count - 1
                Dim dsPro As New Data.DataSet
                dsPro = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "LABORATORIO", "MICROBIOLOGIA", "", lvM.Items(I).SubItems(0).Text, 7)
                If dsPro.Tables(0).Rows.Count > 0 Then
                    If dsPro.Tables(0).Rows(0)("Total").ToString = "" Then lvM.Items(I).SubItems(J).Text = 0 Else lvM.Items(I).SubItems(J).Text = dsPro.Tables(0).Rows(0)("Total")
                Else
                    lvM.Items(I).SubItems(J).Text = 0
                End If
            Next
        Next
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        pBarra.Value = 0

        BancoSangre()
        pBarra.Value = pBarra.Value + 20

        Bioquimica()
        pBarra.Value = pBarra.Value + 20

        Hematologia()
        pBarra.Value = pBarra.Value + 20

        Inmunologia()
        pBarra.Value = pBarra.Value + 20

        Microbiologia()
        pBarra.Value = pBarra.Value + 20

        'Calcular Totales
        Dim I, J As Integer
        Dim Total As Integer
        Dim Fila As ListViewItem

        'Banco Sangre
        Total = 0
        Fila = lvBS.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvBS.Items(lvBS.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 3
            For I = 0 To lvBS.Items.Count - 2
                Total = Total + Val(lvBS.Items(I).SubItems(J).Text)
            Next
            lvBS.Items(lvBS.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvBS.Items.Count - 1
            lvBS.Items(I).SubItems(4).Text = Val(lvBS.Items(I).SubItems(1).Text) + Val(lvBS.Items(I).SubItems(2).Text) + Val(lvBS.Items(I).SubItems(3).Text)
        Next

        'Bioquimica
        Total = 0
        Fila = lvB.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvB.Items(lvBS.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 3
            For I = 0 To lvB.Items.Count - 2
                Total = Total + Val(lvB.Items(I).SubItems(J).Text)
            Next
            lvB.Items(lvB.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvB.Items.Count - 1
            lvB.Items(I).SubItems(4).Text = Val(lvB.Items(I).SubItems(1).Text) + Val(lvB.Items(I).SubItems(2).Text) + Val(lvB.Items(I).SubItems(3).Text)
        Next
        'Hematologia
        Total = 0
        Fila = lvH.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvH.Items(lvH.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 3
            For I = 0 To lvH.Items.Count - 2
                Total = Total + Val(lvH.Items(I).SubItems(J).Text)
            Next
            lvH.Items(lvH.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvH.Items.Count - 1
            lvH.Items(I).SubItems(4).Text = Val(lvH.Items(I).SubItems(1).Text) + Val(lvH.Items(I).SubItems(2).Text) + Val(lvH.Items(I).SubItems(3).Text)
        Next

        'Inmunologia
        Total = 0
        Fila = lvI.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvI.Items(lvI.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 3
            For I = 0 To lvI.Items.Count - 2
                Total = Total + Val(lvI.Items(I).SubItems(J).Text)
            Next
            lvI.Items(lvI.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvI.Items.Count - 1
            lvI.Items(I).SubItems(4).Text = Val(lvI.Items(I).SubItems(1).Text) + Val(lvI.Items(I).SubItems(2).Text) + Val(lvI.Items(I).SubItems(3).Text)
        Next
        'Microbiologia
        Total = 0
        Fila = lvM.Items.Add("PRODUCCION TOTAL")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        Fila.SubItems.Add("")
        lvM.Items(lvM.Items.Count - 1).BackColor = Color.Coral

        For J = 1 To 3
            For I = 0 To lvM.Items.Count - 2
                Total = Total + Val(lvM.Items(I).SubItems(J).Text)
            Next
            lvM.Items(lvM.Items.Count - 1).SubItems(J).Text = Total.ToString
            Total = 0
        Next
        For I = 0 To lvM.Items.Count - 1
            lvM.Items(I).SubItems(4).Text = Val(lvM.Items(I).SubItems(1).Text) + Val(lvM.Items(I).SubItems(2).Text) + Val(lvM.Items(I).SubItems(3).Text)
        Next

        'Pintar Filas y Columnas
        For I = 0 To lvBS.Items.Count - 1
            lvBS.Items(I).SubItems(4).BackColor = Color.Crimson
            lvBS.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvBS.Columns.Count - 2
            lvBS.Items(lvBS.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next

        For I = 0 To lvB.Items.Count - 1
            lvB.Items(I).SubItems(4).BackColor = Color.Crimson
            lvB.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvB.Columns.Count - 2
            lvB.Items(lvB.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next

        For I = 0 To lvH.Items.Count - 1
            lvH.Items(I).SubItems(4).BackColor = Color.Crimson
            lvH.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvH.Columns.Count - 2
            lvH.Items(lvH.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next

        For I = 0 To lvI.Items.Count - 1
            lvI.Items(I).SubItems(4).BackColor = Color.Crimson
            lvI.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvI.Columns.Count - 2
            lvI.Items(lvI.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next

        For I = 0 To lvM.Items.Count - 1
            lvM.Items(I).SubItems(4).BackColor = Color.Crimson
            lvM.Items(I).UseItemStyleForSubItems = False
        Next
        For I = 0 To lvM.Columns.Count - 2
            lvM.Items(lvM.Items.Count - 1).SubItems(I).BackColor = Color.Coral
        Next
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

            .DrawString("REPORTE DE PRODUCCION SIS EN BANCO DE SANGRE - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 140, Y)
            Y = Y + 40

            .DrawString("Fecha de Impresion " & Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), FuenteE, Pincel, 16, Y)
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
            .DrawLine(Pens.Black, 20, Y, 500, Y)
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
                .DrawLine(Pens.Black, 20, Y, 500, Y)
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

            .DrawString("REPORTE DE PRODUCCION SIS EN BIOQUIMICA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 140, Y)
            Y = Y + 40

            .DrawString("Fecha de Impresion " & Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), FuenteE, Pincel, 16, Y)
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
            .DrawLine(Pens.Black, 20, Y, 500, Y)
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
                .DrawLine(Pens.Black, 20, Y, 500, Y)
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

            .DrawString("REPORTE DE PRODUCCION SIS EN HEMATOLOGIA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 140, Y)
            Y = Y + 40

            .DrawString("Fecha de Impresion " & Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), FuenteE, Pincel, 16, Y)
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
            .DrawLine(Pens.Black, 20, Y, 500, Y)
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
                .DrawLine(Pens.Black, 20, Y, 500, Y)
                Y += 8
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

            .DrawString("REPORTE DE PRODUCCION SIS EN INMUNOLOGIA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 140, Y)
            Y = Y + 40

            .DrawString("Fecha de Impresion " & Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), FuenteE, Pincel, 16, Y)
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
            .DrawLine(Pens.Black, 20, Y, 500, Y)
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
                .DrawLine(Pens.Black, 20, Y, 500, Y)
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

            .DrawString("REPORTE DE PRODUCCION SIS EN MICROBIOLOGIA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), FuenteG, Pincel, 140, Y)
            Y = Y + 40

            .DrawString("Fecha de Impresion " & Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), FuenteE, Pincel, 16, Y)
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
            .DrawLine(Pens.Black, 20, Y, 500, Y)
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
                .DrawLine(Pens.Black, 20, Y, 500, Y)
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

    Private Sub btnExcelBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelBS.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim Rango As String
        Dim Fila As String

        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        oSheet = oBook.Worksheets(1)

        oSheet.Range("B1").Value = "HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia"
        oSheet.Range("B2").Value = "REPORTE DE PRODUCCION SIS EN BANCO DE SANGRE - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2)

        oSheet.Range("B4").Value = "DESCRIPCION"
        oSheet.Range("C4").Value = "EMERGEN"
        oSheet.Range("D4").Value = "HOSPITA"
        oSheet.Range("E4").Value = "CONEXTE"
        oSheet.Range("F4").Value = "TOTAL"

        oSheet.Range("B4:F4").Font.Bold = True

        Dim I As Integer
        Fila = "4"
        For I = 0 To lvBS.Items.Count - 1
            Fila = Val(Fila) + 1
            Rango = "B" + Fila
            oSheet.Range(Rango).Value = lvBS.Items(I).SubItems(0).Text
            Rango = "C" + Fila
            oSheet.Range(Rango).Value = lvBS.Items(I).SubItems(1).Text
            Rango = "D" + Fila
            oSheet.Range(Rango).Value = lvBS.Items(I).SubItems(2).Text
            Rango = "E" + Fila
            oSheet.Range(Rango).Value = lvBS.Items(I).SubItems(3).Text
            Rango = "F" + Fila
            oSheet.Range(Rango).Value = lvBS.Items(I).SubItems(4).Text
        Next

        Try
            oBook.SaveAs("c:\BancoSangre" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2) & ".xls")
            MessageBox.Show("Archivo Excel Generado en Ruta: c:\BancoSangre" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        End Try


        oSheet = Nothing
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
        GC.Collect()

    End Sub

    Private Sub btnExcelB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelB.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim Rango As String
        Dim Fila As String

        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        oSheet = oBook.Worksheets(1)

        oSheet.Range("B1").Value = "HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia"
        oSheet.Range("B2").Value = "REPORTE DE PRODUCCION SIS EN BIOQUIMICA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2)

        oSheet.Range("B4").Value = "DESCRIPCION"
        oSheet.Range("C4").Value = "EMERGEN"
        oSheet.Range("D4").Value = "HOSPITA"
        oSheet.Range("E4").Value = "CONEXTE"
        oSheet.Range("F4").Value = "TOTAL"

        oSheet.Range("B4:F4").Font.Bold = True

        Dim I As Integer
        Fila = "4"
        For I = 0 To lvB.Items.Count - 1
            Fila = Val(Fila) + 1
            Rango = "B" + Fila
            oSheet.Range(Rango).Value = lvB.Items(I).SubItems(0).Text
            Rango = "C" + Fila
            oSheet.Range(Rango).Value = lvB.Items(I).SubItems(1).Text
            Rango = "D" + Fila
            oSheet.Range(Rango).Value = lvB.Items(I).SubItems(2).Text
            Rango = "E" + Fila
            oSheet.Range(Rango).Value = lvB.Items(I).SubItems(3).Text
            Rango = "F" + Fila
            oSheet.Range(Rango).Value = lvB.Items(I).SubItems(4).Text
        Next

        oBook.SaveAs("c:\Bioquimica" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2) & ".xls")

        MessageBox.Show("Archivo Excel Generado en Ruta: c:\Bioquimica" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        oSheet = Nothing
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
        GC.Collect()

    End Sub

    Private Sub btnExcelH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelH.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim Rango As String
        Dim Fila As String

        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        oSheet = oBook.Worksheets(1)

        oSheet.Range("B1").Value = "HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia"
        oSheet.Range("B2").Value = "REPORTE DE PRODUCCION SIS EN HEMATOLOGIA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2)

        oSheet.Range("B4").Value = "DESCRIPCION"
        oSheet.Range("C4").Value = "EMERGEN"
        oSheet.Range("D4").Value = "HOSPITA"
        oSheet.Range("E4").Value = "CONEXTE"
        oSheet.Range("F4").Value = "TOTAL"

        oSheet.Range("B4:F4").Font.Bold = True

        Dim I As Integer
        Fila = "4"
        For I = 0 To lvH.Items.Count - 1
            Fila = Val(Fila) + 1
            Rango = "B" + Fila
            oSheet.Range(Rango).Value = lvH.Items(I).SubItems(0).Text
            Rango = "C" + Fila
            oSheet.Range(Rango).Value = lvH.Items(I).SubItems(1).Text
            Rango = "D" + Fila
            oSheet.Range(Rango).Value = lvH.Items(I).SubItems(2).Text
            Rango = "E" + Fila
            oSheet.Range(Rango).Value = lvH.Items(I).SubItems(3).Text
            Rango = "F" + Fila
            oSheet.Range(Rango).Value = lvH.Items(I).SubItems(4).Text
        Next

        oBook.SaveAs("c:\Hematologia" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2) & ".xls")

        MessageBox.Show("Archivo Excel Generado en Ruta: c:\Hematologia" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        oSheet = Nothing
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
        GC.Collect()

    End Sub

    Private Sub btnExcelI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelI.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim Rango As String
        Dim Fila As String

        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        oSheet = oBook.Worksheets(1)

        oSheet.Range("B1").Value = "HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia"
        oSheet.Range("B2").Value = "REPORTE DE PRODUCCION SIS EN INMULOGIA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2)

        oSheet.Range("B4").Value = "DESCRIPCION"
        oSheet.Range("C4").Value = "EMERGEN"
        oSheet.Range("D4").Value = "HOSPITA"
        oSheet.Range("E4").Value = "CONEXTE"
        oSheet.Range("F4").Value = "TOTAL"

        oSheet.Range("B4:F4").Font.Bold = True

        Dim I As Integer
        Fila = "4"
        For I = 0 To lvI.Items.Count - 1
            Fila = Val(Fila) + 1
            Rango = "B" + Fila
            oSheet.Range(Rango).Value = lvI.Items(I).SubItems(0).Text
            Rango = "C" + Fila
            oSheet.Range(Rango).Value = lvI.Items(I).SubItems(1).Text
            Rango = "D" + Fila
            oSheet.Range(Rango).Value = lvI.Items(I).SubItems(2).Text
            Rango = "E" + Fila
            oSheet.Range(Rango).Value = lvI.Items(I).SubItems(3).Text
            Rango = "F" + Fila
            oSheet.Range(Rango).Value = lvI.Items(I).SubItems(4).Text
        Next

        oBook.SaveAs("c:\Inmunologia" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2) & ".xls")

        MessageBox.Show("Archivo Excel Generado en Ruta: c:\Inmunologia" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        oSheet = Nothing
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
        GC.Collect()

    End Sub

    Private Sub btnExcelM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelM.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim Rango As String
        Dim Fila As String

        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        oSheet = oBook.Worksheets(1)

        oSheet.Range("B1").Value = "HOSPITAL REGIONAL DOCENTE DE TRUJILLO - Departamento de Laboratorio y Pagologia"
        oSheet.Range("B2").Value = "REPORTE DE PRODUCCION SIS EN MICROBIOLOGIA - " & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & "/" & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2)

        oSheet.Range("B4").Value = "DESCRIPCION"
        oSheet.Range("C4").Value = "EMERGEN"
        oSheet.Range("D4").Value = "HOSPITA"
        oSheet.Range("E4").Value = "CONEXTE"
        oSheet.Range("F4").Value = "TOTAL"

        oSheet.Range("B4:F4").Font.Bold = True

        Dim I As Integer
        Fila = "4"
        For I = 0 To lvM.Items.Count - 1
            Fila = Val(Fila) + 1
            Rango = "B" + Fila
            oSheet.Range(Rango).Value = lvM.Items(I).SubItems(0).Text
            Rango = "C" + Fila
            oSheet.Range(Rango).Value = lvM.Items(I).SubItems(1).Text
            Rango = "D" + Fila
            oSheet.Range(Rango).Value = lvM.Items(I).SubItems(2).Text
            Rango = "E" + Fila
            oSheet.Range(Rango).Value = lvM.Items(I).SubItems(3).Text
            Rango = "F" + Fila
            oSheet.Range(Rango).Value = lvM.Items(I).SubItems(4).Text
        Next

        oBook.SaveAs("c:\Microbiologia" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2) & ".xls")

        MessageBox.Show("Archivo Excel Generado en Ruta: c:\Microbiologia" & Microsoft.VisualBasic.Right("00" & Month(dtpF1.Value), 2) & Microsoft.VisualBasic.Right("00" & Year(dtpF1.Value), 2), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        oSheet = Nothing
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
        GC.Collect()

    End Sub
End Class