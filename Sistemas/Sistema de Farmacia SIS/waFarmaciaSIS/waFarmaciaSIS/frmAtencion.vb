Public Class frmAtencion
    Dim objReceta As New clsRecetaMedicaSIS
    Dim objDetalle As New clsRecetaMedicaSISDet
    Dim objRecetaCIE As New clsRecetaMedicaSISCIE
    Dim objBienServicio As New clsBienServicio
    Dim objMedicamento As New clsMedicamento
    Dim objSIS As New clsSIS
    Dim objHistoria As New clsHistoria

    'Variables Impresion
    Dim Fuente20N As New Font("Courier New", 20, FontStyle.Bold)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente10 As New Font("Courier New", 10)
    Dim Fuente8 As New Font("Courier New", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim TotalFilas As Integer
    Dim NroFila As Integer
    Dim Y As Integer

    Private Sub frmAtencion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
        cboOrigen.Text = "CONSULTA EXTERNA"
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboOrigen.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub cboOrigen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboOrigen.KeyDown
        If e.KeyCode = Keys.Enter And cboOrigen.Text <> "" Then btnMostrar.Select()
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged

    End Sub

    Private Sub btnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrar.Click
        lvTabla.Items.Clear()
        lvCIE.Items.Clear()
        lvDet.Items.Clear()
        Dim dsVer As New DataSet
        Dim dsSIS As New DataSet
        Dim IdSIS As String
        dsVer = objReceta.BuscarAtencion(cboOrigen.Text, dtpFecha.Value.ToShortDateString)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdReceta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Medico"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SerieSIS"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NumeroSIS"))
            'Buscar SIS
            dsSIS = objSIS.BuscarNroFormato(dsVer.Tables(0).Rows(I)("SerieSIS"), dsVer.Tables(0).Rows(I)("NumeroSIS"))
            If dsSIS.Tables(0).Rows.Count > 0 Then
                IdSIS = dsSIS.Tables(0).Rows(0)("IdSiS")
                Fila.SubItems.Add(dsSIS.Tables(0).Rows(0)("Historia"))
                Fila.SubItems.Add(dsSIS.Tables(0).Rows(0)("Apaterno") & " " & dsSIS.Tables(0).Rows(0)("Amaterno") & " " & dsSIS.Tables(0).Rows(0)("Nombres"))
            Else
                IdSIS = 0
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraRegistro"))
            Fila.SubItems.Add(IdSIS)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(0)("Indicacion"))
        Next
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        lvDet.Items.Clear()
        lvCIE.Items.Clear()
        If lvTabla.SelectedItems.Count > 0 Then
            Dim dsDet As New DataSet
            Dim Importe As String
            dsDet = objDetalle.BuscarId(lvTabla.SelectedItems(0).SubItems(0).Text)
            If dsDet.Tables(0).Rows.Count > 0 Then
                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsDet.Tables(0).Rows.Count - 1
                    Fila = lvDet.Items.Add(dsDet.Tables(0).Rows(I)("IdDetalle"))
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("CantSol"))
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Unidad"))
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Precio"))
                    Importe = Val(dsDet.Tables(0).Rows(I)("CantSol")) * Val(dsDet.Tables(0).Rows(I)("Precio"))
                    Fila.SubItems.Add(Importe)
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("CantSol"))
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("IdMedicamento"))
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Dosis"))
                Next

                'Busar CIE
                Dim dsCIE As New DataSet
                dsCIE = objRecetaCIE.BuscarId(lvTabla.SelectedItems(0).SubItems(0).Text)
                If dsDet.Tables(0).Rows.Count > 0 Then
                    For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                        Fila = lvCIE.Items.Add(dsCIE.Tables(0).Rows(I)("Cie"))
                        Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Descripcion"))
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub lvDet_DoubleClick(sender As Object, e As System.EventArgs) Handles lvDet.DoubleClick

    End Sub

    Private Sub lvDet_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            Dim Cantidad As String
            Cantidad = InputBox("Ingresar Cantidad Atendida", "Datos de Atencion")
            If IsNumeric(Cantidad) Then
                lvDet.SelectedItems(0).SubItems(6).Text = Cantidad
            Else
                MessageBox.Show("Cantidad no es un valor numérico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

   
    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        lvCIE.Items.Clear()
        lvDet.Items.Clear()
    End Sub

    Private Sub btnAtencion_Click(sender As System.Object, e As System.EventArgs) Handles btnAtencion.Click
        Dim Importe As String
        If lvDet.Items.Count = 0 Then MessageBox.Show("No existen Medicamentos para realizar atención de Farmacia, Seleccione un Paciente", "Mensaje de Información", MessageBoxButtons.OK) : Exit Sub
        If MessageBox.Show("Esta seguro de realizar atención de Farmacia?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                objDetalle.AtencionFarmacia(lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(6).Text)
                Importe = Val(lvDet.Items(I).SubItems(4).Text) * Val(lvDet.Items(I).SubItems(6).Text)
                objSIS.GrabarMedFechaHora(lvTabla.SelectedItems(0).SubItems(8).Text, lvDet.Items(I).SubItems(7).Text, lvDet.Items(I).SubItems(3).Text, lvDet.Items(I).SubItems(4).Text, lvDet.Items(I).SubItems(6).Text, Importe, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5))
                objBienServicio.ActStockBienServ(lvDet.Items(I).SubItems(7).Text, lvDet.Items(I).SubItems(6).Text)
                objMedicamento.ActStockBienServ(lvDet.Items(I).SubItems(7).Text, lvDet.Items(I).SubItems(6).Text)
            Next
            objReceta.Atendido(lvTabla.SelectedItems(0).SubItems(0).Text, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name)

            ppdDocumento.ShowDialog()

            btnCancelar_Click(sender, e)
            btnMostrar_Click(sender, e)
        End If
    End Sub

    Private Sub Cabecera(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim CadenaCIE As String = ""
        Y = 40
        With e.Graphics
            Dim dsHistoria As New DataSet
            Dim Edad As String
            dsHistoria = objHistoria.Buscar(lvTabla.SelectedItems(0).SubItems(5).Text)
            If dsHistoria.Tables(0).Rows.Count > 0 Then
                .DrawString("RECETA DE PACIENTE - SIS", Fuente12N, Pincel, 60, Y)
                .DrawString("RECETA DE PACIENTE - SIS", Fuente12N, Pincel, 460, Y)
                Y = Y + 20
                .DrawString("H.C.    : " & lvTabla.SelectedItems(0).SubItems(5).Text, Fuente10, Pincel, 20, Y)
                .DrawString("Formato : " & lvTabla.SelectedItems(0).SubItems(3).Text & "-" & lvTabla.SelectedItems(0).SubItems(4).Text, Fuente10, Pincel, 200, Y)
                .DrawString("H.C.    : " & lvTabla.SelectedItems(0).SubItems(5).Text, Fuente10, Pincel, 420, Y)
                .DrawString("Formato : " & lvTabla.SelectedItems(0).SubItems(3).Text & "-" & lvTabla.SelectedItems(0).SubItems(4).Text, Fuente10, Pincel, 600, Y)
                Y = Y + 15
                .DrawString("Paciente: " & Microsoft.VisualBasic.Left(lvTabla.SelectedItems(0).SubItems(6).Text & StrDup(30, " "), 30), Fuente10, Pincel, 20, Y)
                .DrawString("Paciente: " & Microsoft.VisualBasic.Left(lvTabla.SelectedItems(0).SubItems(6).Text & StrDup(30, " "), 30), Fuente10, Pincel, 420, Y)
                Y = Y + 15
                'Calcular Edad
                If dsHistoria.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                    Dim Dias As Integer, Meses As Integer, Años As Integer
                    Dim DiasMes As Integer
                    Dim dfin, dinicio As Date
                    Dim EdadA, EdadM, EdadD As String
                    dfin = Date.Now.ToShortDateString
                    dinicio = dsHistoria.Tables(0).Rows(0)("FNACIMIENTO")
                    Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                    Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                    Años = DateDiff("yyyy", dinicio, dfin)

                    If Meses = 0 And Años = 0 Then
                        EdadA = 0
                        EdadM = 0
                        Dias = Math.Abs(Dias)
                        EdadD = Dias
                    Else
                        'Verificar Dias
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

                        EdadD = Microsoft.VisualBasic.Day(dinicio)
                        If Val(EdadD) > Date.Now.Day Then
                            EdadD = Val(EdadD) - Date.Now.Day
                        ElseIf Val(EdadD) < Date.Now.Day Then
                            If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                            EdadD = Date.Now.Day - EdadD
                            EdadD = DameDiasMes(Date.Now.Month) - EdadD
                        Else
                            EdadD = 0
                        End If
                    End If
                    Edad = EdadA & " A " & EdadM & " M " & EdadD & " D "
                Else
                    Edad = ""
                End If
                .DrawString("Edad    : " & Edad & StrDup(2, " ") & "Sexo: " & Microsoft.VisualBasic.Left(dsHistoria.Tables(0).Rows(0)("Sexo").ToString, 3), Fuente10, Pincel, 20, Y)
                .DrawString("Edad    : " & Edad & StrDup(2, " ") & "Sexo: " & Microsoft.VisualBasic.Left(dsHistoria.Tables(0).Rows(0)("Sexo").ToString, 3), Fuente10, Pincel, 420, Y)
                Y = Y + 15
                .DrawString("Servicio: " & cboOrigen.Text & " - " & lvTabla.SelectedItems(0).SubItems(1).Text, Fuente10, Pincel, 20, Y)
                .DrawString("Servicio: " & cboOrigen.Text & " - " & lvTabla.SelectedItems(0).SubItems(1).Text, Fuente10, Pincel, 420, Y)
                Y = Y + 15
                .DrawString("Médico  : " & lvTabla.SelectedItems(0).SubItems(2).Text, Fuente10, Pincel, 20, Y)
                .DrawString("Médico  : " & lvTabla.SelectedItems(0).SubItems(2).Text, Fuente10, Pincel, 420, Y)
                Y = Y + 15
                .DrawString("Fecha   : " & Date.Now.ToShortDateString & " - " & Date.Now.ToShortTimeString, Fuente10, Pincel, 20, Y)
                .DrawString("Fecha   : " & Date.Now.ToShortDateString & " - " & Date.Now.ToShortTimeString, Fuente10, Pincel, 420, Y)
                'CIE 10
                Dim K As Integer
                CadenaCIE = ""
                For K = 0 To lvCIE.Items.Count - 1
                    If K = 0 Then
                        CadenaCIE = lvCIE.Items(K).SubItems(0).Text
                    Else
                        CadenaCIE = CadenaCIE & ", " & lvCIE.Items(K).SubItems(0).Text
                    End If
                Next
                Y = Y + 15
                .DrawString("CIE10   : " & CadenaCIE, Fuente10, Pincel, 20, Y)
                .DrawString("CIE10   : " & CadenaCIE, Fuente10, Pincel, 420, Y)
                Y = Y + 20
                .DrawString("CANT", Fuente8, Pincel, 25, Y)
                .DrawString("CANT", Fuente8, Pincel, 425, Y)
                .DrawString("UND", Fuente8, Pincel, 60, Y)
                .DrawString("UND", Fuente8, Pincel, 460, Y)
                .DrawString("DESCRIPCION", Fuente8, Pincel, 120, Y)
                .DrawString("DESCRIPCION", Fuente8, Pincel, 520, Y)
                .DrawString("DOSIS", Fuente8, Pincel, 310, Y)
                .DrawString("DOSIS", Fuente8, Pincel, 710, Y)
                Y = Y + 10
                .DrawLine(Pens.Black, 20, Y + 5, 380, Y + 5)
                .DrawLine(Pens.Black, 420, Y + 5, 780, Y + 5)
            End If
        End With
    End Sub

    Private Sub pdDocumento_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdDocumento.BeginPrint
        Y = 10
        TotalFilas = lvDet.Items.Count - 1
        NroFila = 0
    End Sub

    Private Sub pdDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdDocumento.PrintPage
        Cabecera(e)
        Dim Indicaciones As String = ""
        With e.Graphics
            Do While TotalFilas >= 0
                If NroFila <> 0 Then Y = Y + 15 Else Y = Y + 5
                .DrawString(Microsoft.VisualBasic.Right(StrDup(5, " ") & lvDet.Items(NroFila).SubItems(6).Text, 5), Fuente8, Pincel, 20, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(5, " ") & lvDet.Items(NroFila).SubItems(6).Text, 5), Fuente8, Pincel, 420, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFila).SubItems(2).Text & StrDup(4, " "), 4), Fuente8, Pincel, 60, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFila).SubItems(2).Text & StrDup(4, " "), 4), Fuente8, Pincel, 460, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFila).SubItems(3).Text & StrDup(24, " "), 24), Fuente8, Pincel, 90, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFila).SubItems(3).Text & StrDup(24, " "), 24), Fuente8, Pincel, 490, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFila).SubItems(8).Text & StrDup(12, " "), 12), Fuente8, Pincel, 300, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFila).SubItems(8).Text & StrDup(12, " "), 12), Fuente8, Pincel, 700, Y)
                NroFila += 1
                TotalFilas -= 1
            Loop
            Y = Y + 10
            .DrawLine(Pens.Black, 20, Y + 5, 380, Y + 5)
            .DrawLine(Pens.Black, 420, Y + 5, 780, Y + 5)
            Y = Y + 5
            If lvTabla.SelectedItems(0).SubItems(9).Text = "" Then Indicaciones = "INDICACIONES: NINGUNA" Else Indicaciones = "INDICACIONES: " & lvTabla.SelectedItems(0).SubItems(9).Text
            Do While Indicaciones.Length > 0
                If Indicaciones.Length <= 45 Then
                    .DrawString(Indicaciones, Fuente8, Pincel, 20, Y)
                    .DrawString(Indicaciones, Fuente8, Pincel, 420, Y)
                    Indicaciones = ""
                Else
                    .DrawString(Microsoft.VisualBasic.Left(Indicaciones, 45), Fuente8, Pincel, 20, Y)
                    .DrawString(Microsoft.VisualBasic.Left(Indicaciones, 45), Fuente8, Pincel, 420, Y)
                    Indicaciones = Microsoft.VisualBasic.Right(Indicaciones, Indicaciones.Length - 45)
                End If
                Y = Y + 15
            Loop


            Y = Y + 50
            .DrawLine(Pens.Black, 20, Y, 160, Y)
            .DrawLine(Pens.Black, 420, Y, 560, Y)
            .DrawLine(Pens.Black, 180, Y, 380, Y)
            .DrawLine(Pens.Black, 480, Y, 780, Y)
            Y = Y + 5
            .DrawString("Firma Entrega", Fuente8, Pincel, 40, Y)
            .DrawString("Firma Entrega", Fuente8, Pincel, 440, Y)
            .DrawString("Firma Recepcion", Fuente8, Pincel, 200, Y)
            .DrawString("Firma Recepcion", Fuente8, Pincel, 600, Y)
            Y = Y + 15
            .DrawString("Nombres:", Fuente8, Pincel, 180, Y)
            .DrawString("Nombres:", Fuente8, Pincel, 580, Y)
            Y = Y + 15
            .DrawString("DNI:_______________", Fuente8, Pincel, 180, Y)
            .DrawString("DNI:_______________", Fuente8, Pincel, 580, Y)
            
            e.HasMorePages = False
        End With
    End Sub
End Class