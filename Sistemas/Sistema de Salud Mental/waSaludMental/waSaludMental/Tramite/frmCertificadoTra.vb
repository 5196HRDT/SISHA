Public Class frmCertificadoTra
    Dim objCertificado As New clsCertificado
    Dim objMedico As New clsMedico
    Dim objHistoria As New clsHistoria

    Dim Edad As String
    Dim Texto1 As String

    'Variables Impresion
    Dim FuenteM As New Font("Lucida Console", 8, FontStyle.Bold)
    Dim FuenteTit As New Font("TIMES NEW ROMAN", 10, FontStyle.Bold)
    Dim Fuente As New Font("Lucida Console", 8)
    'Dim FuenteTex As New Font("Lucida Console", 8)
    Dim FuenteP As New Font("Lucida Console", 6, FontStyle.Bold)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim NroFilasTotales As Integer
    Dim NroPaginas As Integer
    Dim NroFilasHoja As Integer
    Dim TotalFilasLV As Integer
    Dim X, Y As Integer

    Private Sub TextoImpresion(Historia As String)
        Dim dsHistoria As New DataSet
        dsHistoria = objHistoria.Buscar(Historia)
        If dsHistoria.Tables(0).Rows.Count > 0 Then
            CalcularEdad(Date.Now.ToShortDateString, dsHistoria.Tables(0).Rows(0)("FNACIMIENTO"))
            If dsHistoria.Tables(0).Rows(0)("Doc_Identidad").ToString = "" Then MessageBox.Show("Paciente no tiene registrado correctamente el Valor del Campo DNI. Coordinar Problema con Admisión", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Texto1 = "" : Exit Sub
            If dsHistoria.Tables(0).Rows(0)("Sexo").ToString = "MASCULINO" Then
                Texto1 = "Por la presente se Certifica que el Sr. " & dsHistoria.Tables(0).Rows(0)("Apaterno") & " " & dsHistoria.Tables(0).Rows(0)("Amaterno") & " " & dsHistoria.Tables(0).Rows(0)("Nombres")
                Texto1 = Texto1 & " de " & Edad & " años de edad, identificado con DNI/CE N° " & dsHistoria.Tables(0).Rows(0)("Doc_Identidad").ToString
                Texto1 = Texto1 & ", ha sido sometido a un exámen mental, con pruebas toxicológicas, informe psicológico e informe psiquiátrico en el Hospital Regional Docente de Trujillo con Historia Clínica N° " & Microsoft.VisualBasic.Right("000000000" & Historia, 9) & ", habiéndose obtenido el siguiente resultado:"

            ElseIf dsHistoria.Tables(0).Rows(0)("Sexo").ToString = "FEMENINO" Then
                Texto1 = "Por la presente se Certifica que la Sra. " & dsHistoria.Tables(0).Rows(0)("Apaterno") & " " & dsHistoria.Tables(0).Rows(0)("Amaterno") & " " & dsHistoria.Tables(0).Rows(0)("Nombres")
                Texto1 = Texto1 & " de " & Edad & " años de edad, identificada con DNI N° " & dsHistoria.Tables(0).Rows(0)("Doc_Identidad").ToString
                Texto1 = Texto1 & ", ha sido sometida a un examen mental, con pruebas toxicológicas, informe psicológico e informe psiquiátrico en el Hospital Regional Docente de Trujillo con Historia Clínica N° " & Microsoft.VisualBasic.Right("000000000" & Historia, 9) & ", habiéndose obtenido el siguiente resultado:"
            Else
                MessageBox.Show("Paciente no tiene registrado correctamente el Valor del Campo Sexo. Coordinar Problema con Admisión", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Texto1 = ""
                Exit Sub
            End If
        End If

    End Sub

    Public Sub CalcularEdad(FechaActual As Date, FechaNacimiento As Date)
        Dim Dias As Integer, Meses As Integer, Años As Integer
        Dim DiasMes As Integer
        Dim dfin, dinicio As Date
        Dim EdadA, EdadM, EdadD As String
        dfin = FechaActual
        dinicio = FechaNacimiento
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

            EdadD = Microsoft.VisualBasic.Day(FechaNacimiento)
            If Val(EdadD) > FechaActual.Day Then
                EdadD = Val(EdadD) - FechaActual.Day
            ElseIf Val(EdadD) < FechaActual.Day Then
                If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                EdadD = FechaActual.Day - EdadD
                EdadD = DameDiasMes(FechaActual.Month) - EdadD
            Else
                EdadD = 0
            End If
        End If
        Edad = EdadA
    End Sub

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        Dim Condicion As String
        If rbApto.Checked Then Condicion = "APTO" Else Condicion = "INAPTO"
        dsVer = objCertificado.BuscarEntrega(txtFiltro.Text, Condicion)
        Dim I As Integer
        Dim Fila As ListViewItem


        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdCertificado"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Psicologo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Psiquiatra"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("CondicionPS"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("CondicionPQ"))
        Next
    End Sub


    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        If lvTabla.SelectedItems.Count = 0 Then MessageBox.Show("Debe Seleccionar un Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : lvTabla.Select() : Exit Sub
        If Not IsNumeric(txtNumero.Text) Then MessageBox.Show("Debe Ingresar el Nro de Certificado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNumero.Select() : Exit Sub
        Dim dsVer As New DataSet
        dsVer = objCertificado.VerificarNroCertificado(txtNumero.Text)
        If dsVer.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("Nro de Certificado " & txtNumero.Text & " ya fue registrado en el sistema", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNumero.Text = ""
            txtNumero.Select()
            Exit Sub
        End If

        If lvTabla.SelectedItems.Count = 0 Then MessageBox.Show("Debe seleccionar un certificado a Generar", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Not IsNumeric(cboVisiador.SelectedValue) Then MessageBox.Show("Debe seleccionar un visador", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If lvTabla.SelectedItems.Count > 0 Then
            'If lvTabla.SelectedItems(0).SubItems(6).Text = "INAPTO" Then MessageBox.Show("Paciente se encuentra INAPTO para emisión de Certificado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If MessageBox.Show("Esta seguro de Generar Certificado?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objCertificado.Entrega(lvTabla.SelectedItems(0).SubItems(0).Text, cboVisiador.SelectedValue, cboVisiador.Text, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name, txtNumero.Text)
                ppdVistaPrevia.ShowDialog()
                Buscar()
            End If
        End If

    End Sub

    Private Sub frmCertificadoTra_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        rbApto.Checked = True

        'Medicos visadores
        Dim dsMed As New DataSet
        dsMed = objMedico.ComboF()
        cboVisiador.DataSource = dsMed.Tables(0)
        cboVisiador.DisplayMember = "Medico"
        cboVisiador.ValueMember = "IdMedico"
    End Sub

    Private Sub pdcDocumento_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NroPaginas = 1
        NroFilasTotales = 0
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            Y = 80
            .DrawString("CERTIFICADO DE SALUD MENTAL PARA", FuenteTit, Pincel, 270, Y)
            Y = Y + 20
            .DrawString("LICENCIA DE POSESION Y USO CIVIL DE ARMAS DE FUEGO", FuenteTit, Pincel, 200, Y)
            Y = Y + 20
            .DrawString("CERTIFICADO NRO: " & Microsoft.VisualBasic.Right("0000000" & txtNumero.Text, 7), FuenteTit, Pincel, 320, Y)
            Y = 60
        End With
    End Sub

    Private Sub pdcDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Dim NroFila As Integer = 0
        Y = 145
        'Encabezado(e)

        Filas = 10
        NroFilasHoja = 0
        TextoImpresion(lvTabla.SelectedItems(0).SubItems(2).Text)
        Dim TextoAux As String = Texto1
        Dim TextoImp As String = ""
        Dim PosAnt As Integer = 0
        Dim dsCertificado As New DataSet
        dsCertificado = objCertificado.BuscarId(lvTabla.SelectedItems(0).SubItems(0).Text)
        With e.Graphics
            .DrawString(Microsoft.VisualBasic.Right("000000" & txtNumero.Text, 6), FuenteTit, Pincel, 620, Y)
            Y = Y + 60
            '.DrawImage(pbEscudo.Image, 80, 50)
            '.DrawImage(pbHRDT.Image, 630, 70)

            'Texto1
            Do While TextoAux.Length > 95
                Y = Y + 20
                TextoImp = Microsoft.VisualBasic.Left(TextoAux, 95)
                PosAnt = TextoImp.Length
                Do While TextoImp(PosAnt - 1) <> " "
                    PosAnt = PosAnt - 1
                Loop
                TextoImp = Microsoft.VisualBasic.Left(TextoAux, PosAnt)
                .DrawString(TextoImp, Fuente, Pincel, 80, Y)
                TextoAux = Microsoft.VisualBasic.Right(TextoAux, TextoAux.Length - PosAnt)
            Loop
            Y = Y + 20
            .DrawString(TextoAux, Fuente, Pincel, 80, Y)
            Y = Y + 50
            .DrawString("INFORME PSICOLOGICO", FuenteM, Pincel, 100, Y)
            Y = Y + 30
            .DrawString("(A) AREA DE PERSONALIDAD :", Fuente, Pincel, 100, Y)
            .DrawString(dsCertificado.Tables(0).Rows(0)("Personalidad"), Fuente, Pincel, 280, Y)
            Y = Y + 20
            .DrawString("(B) AREA DE INTELIGENCIA :", Fuente, Pincel, 100, Y)
            .DrawString(dsCertificado.Tables(0).Rows(0)("CategoriaInteligencia"), Fuente, Pincel, 280, Y)
            Y = Y + 20
            .DrawString("(C) AREA DE ORGANICIDAD  :", Fuente, Pincel, 100, Y)
            .DrawString(dsCertificado.Tables(0).Rows(0)("Organicidad"), Fuente, Pincel, 280, Y)
            Y = Y + 20
            .DrawString("(D) AREA EMOCIONAL       :", Fuente, Pincel, 100, Y)
            Dim Emocion As String = "Rasgos de"
            If dsCertificado.Tables(0).Rows(0)("Inestabilidad") = "SI" Then Emocion = Emocion & " Inestabilidad (SI) " Else Emocion = Emocion & " Inestabilidad (NO) "
            If dsCertificado.Tables(0).Rows(0)("Agrecividad") = "SI" Then Emocion = Emocion & "Agresividad (SI) " Else Emocion = Emocion & "Agresividad (NO) "
            If dsCertificado.Tables(0).Rows(0)("Impulsividad") = "SI" Then Emocion = Emocion & "Impulsividad (SI) " Else Emocion = Emocion & "Impulsividad (NO) "
            .DrawString(Emocion, Fuente, Pincel, 280, Y)
            Y = Y + 15
            If dsCertificado.Tables(0).Rows(0)("Hostilidad") = "SI" Then Emocion = "Hostilidad (SI) " Else Emocion = "Hostilidad (NO) "
            If dsCertificado.Tables(0).Rows(0)("Retraimiento") = "SI" Then Emocion = Emocion & "Retraimiento (SI) " Else Emocion = Emocion & "Retraimiento (NO) "
            .DrawString(Emocion, Fuente, Pincel, 280, Y)
            Y = Y + 20
            .DrawString("(E) CONDICION PSICOLOGICA:", Fuente, Pincel, 100, Y)
            .DrawString(lvTabla.SelectedItems(0).SubItems(6).Text, Fuente, Pincel, 280, Y)


            Y = Y + 50
            .DrawString("INFORME PSIQUIATRICO", FuenteM, Pincel, 100, Y)
            Y = Y + 30
            .DrawString("(A) DX CLINICO PSIQUIATRICO  :", Fuente, Pincel, 100, Y)
            .DrawString(Microsoft.VisualBasic.Left(dsCertificado.Tables(0).Rows(0)("CieQA") & StrDup(2, " ") & dsCertificado.Tables(0).Rows(0)("DesQA") & StrDup(60, " "), 60), Fuente, Pincel, 310, Y)
            Y = Y + 20
            .DrawString("(B) TEST DE CONSUMO DE DROGAS:", Fuente, Pincel, 100, Y)
            .DrawString(dsCertificado.Tables(0).Rows(0)("Drogas"), Fuente, Pincel, 310, Y)
            Y = Y + 20
            .DrawString("(C) DX MEDICO GENERAL        :", Fuente, Pincel, 100, Y)
            If dsCertificado.Tables(0).Rows(0)("CieQB") <> "" Then
                .DrawString(Microsoft.VisualBasic.Left(dsCertificado.Tables(0).Rows(0)("CieQB") & StrDup(2, " ") & dsCertificado.Tables(0).Rows(0)("DesQB") & StrDup(60, " "), 60), Fuente, Pincel, 310, Y)
                Y = Y + 15
                If dsCertificado.Tables(0).Rows(0)("CieQC") <> "" Then
                    .DrawString(Microsoft.VisualBasic.Left(dsCertificado.Tables(0).Rows(0)("CieQC") & " " & dsCertificado.Tables(0).Rows(0)("DesQC") & StrDup(60, " "), 60), Fuente, Pincel, 310, Y)
                End If
            Else
                .DrawString("SANO", Fuente, Pincel, 310, Y)
            End If
            Y = Y + 20
            .DrawString("(D) CONDICION PSQUIATRICA    :", Fuente, Pincel, 100, Y)
            .DrawString(lvTabla.SelectedItems(0).SubItems(7).Text, Fuente, Pincel, 310, Y)
            Y = Y + 60

            'Texto2
            Dim Texto2 As String
            If rbApto.Checked Then Texto2 = "Resultado que en el momento del examen lo hace APTO, para obtener su licencia de posesión y uso civil de armas de fuego."
            If rbInapto.Checked Then Texto2 = "Resultado que en el momento del examen lo hace INAPTO, para obtener su licencia de posesión y uso civil de armas de fuego."
            TextoAux = Texto2
            Do While TextoAux.Length > 90
                TextoImp = Microsoft.VisualBasic.Left(TextoAux, 90)
                PosAnt = TextoImp.Length
                Do While TextoImp(PosAnt - 1) <> " "
                    PosAnt = PosAnt - 1
                Loop
                TextoImp = Microsoft.VisualBasic.Left(TextoAux, PosAnt)
                .DrawString(TextoImp, FuenteM, Pincel, 100, Y)
                TextoAux = Microsoft.VisualBasic.Right(TextoAux, TextoAux.Length - PosAnt)
                Y = Y + 15
            Loop
            .DrawString(TextoAux, FuenteM, Pincel, 100, Y)
            Y = Y + 50
            .DrawString("Se expide el presente para los fines pertinentes del interesado.", Fuente, Pincel, 100, Y)
            Y = Y + 50
            .DrawString("Trujillo, " & Microsoft.VisualBasic.Right("00" & Date.Now.Day, 2) & " de " & DameMesLetras(Date.Now.Month) & " del " & Date.Now.Year, Fuente, Pincel, 400, Y)
            Y = Y + 50
            '.DrawString(StrDup(20, "_") & StrDup(12, " ") & StrDup(20, "_") & StrDup(12, " ") & StrDup(20, "_"), Fuente, Pincel, 100, Y)
            'Y = Y + 15
            '.DrawString("PSIQUIATRA", FuenteP, Pincel, 140, Y)
            '.DrawString("PSICOLOGO", FuenteP, Pincel, 360, Y)
            '.DrawString("DIRECTOR", FuenteP, Pincel, 570, Y)
            'Y = Y + 20
            .DrawString("REG INDEX: " & lvTabla.SelectedItems(0).SubItems(0).Text, FuenteP, Pincel, 100, Y)
            e.HasMorePages = False
        End With
    End Sub

    Private Sub rbApto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbApto.CheckedChanged
        Buscar()
    End Sub

    Private Sub rbInapto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbInapto.CheckedChanged
        Buscar()
    End Sub

    Private Sub btnVista_Click(sender As System.Object, e As System.EventArgs) Handles btnVista.Click
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If IsNumeric(txtNumero.Text) And e.KeyCode = Keys.Enter Then btnGenerar.Select()
    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Permanentemente el formato de SUCAMEC?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objCertificado.Eliminar(lvTabla.SelectedItems(0).SubItems(0).Text)
                lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
            End If
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        lblHistoria.Tag = ""
        lblPaciente.Text = ""
        lblHistoria.Text = ""
        If lvTabla.SelectedItems.Count > 0 Then
            lblHistoria.Tag = lvTabla.SelectedItems(0).SubItems(0).Text
            lblHistoria.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            lblPaciente.Text = lvTabla.SelectedItems(0).SubItems(3).Text
        End If
    End Sub
End Class