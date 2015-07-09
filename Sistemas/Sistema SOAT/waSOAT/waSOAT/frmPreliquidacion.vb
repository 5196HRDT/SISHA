Public Class frmPreliquidacion
    Dim objFicha As New FichaSoat
    Dim objTarifario As New TarifarioSOAT
    Dim objClas As New Clasificador
    Dim objRecibo As New Recibo
    Dim CodLocal As String
    Dim Preliquidacion As String
    Dim CodRecibo As String
    Dim Finalizar As Boolean
    Dim objConsulta As New clsConsultaExterna


    'Variables Impresion
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8)
    Dim FuenteTitulo As New Font("Lucida Console", 14)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim NroFilasHoja As Integer
    Dim NroFilasTotales As Integer
    Dim TotalFilasLV As Integer
    Dim NroLineas As Integer
    Dim NroPagina As Integer = 0

    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosPre(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
                lblFechaRegistro.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FechaRegistro"), 10)
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaNac")
                If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                    lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                Else
                    lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                End If
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                lblPlaca.Text = dsTabla.Tables(0).Rows(0)("Placa")
                lblPoliza.Text = dsTabla.Tables(0).Rows(0)("Poliza")
                lblContratante.Text = dsTabla.Tables(0).Rows(0)("Contratante")
                lblAseguradora.Text = dsTabla.Tables(0).Rows(0)("Aseguradora")
                lblCIE.Text = dsTabla.Tables(0).Rows(0)("CIE1")
                lblTotal.Text = "0.00"
                cboTarifario.Select()
                btnCuenta.Enabled = True
                If dsTabla.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then
                    MessageBox.Show("Ficha ya fue finalizada", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnGrabar.Enabled = False
                    Finalizar = True
                Else
                    btnGrabar.Enabled = True
                    Finalizar = False
                End If
            Else
                MessageBox.Show("No Existe FICHA DE SOAT Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                lblPoliza.Text = ""
                lblPlaca.Text = ""
                lblEdad.Text = ""
                lblContratante.Text = ""
                lblAseguradora.Text = ""
                lblCIE.Text = ""
                txtHistoria.Text = ""
                txtHistoria.Select()
                btnCuenta.Enabled = False
                btnGrabar.Enabled = False
            End If
        End If
    End Sub

    Private Sub frmPreliquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Aseguradora
        Dim dsTarifario As New Data.DataSet
        dsTarifario = objTarifario.Combo
        cboTarifario.DataSource = dsTarifario.Tables(0)
        cboTarifario.DisplayMember = "Descripcion"
        cboTarifario.ValueMember = "IdTarifario"

        'Clasificador
        Dim dsClas As New Data.DataSet
        dsClas = objClas.Combo
        cboClas.DataSource = dsClas.Tables(0)
        cboClas.DisplayMember = "Descripcion"
        cboClas.ValueMember = "Orden"


        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboTarifario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTarifario.KeyDown
        If e.KeyCode = Keys.Enter Then txtCantidad.Text = 1 : txtfecha.Select()
    End Sub

    Private Sub cboTarifario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTarifario.SelectedIndexChanged
        If IsNumeric(cboTarifario.SelectedValue) Then
            Dim dsTab As New Data.DataSet
            dsTab = objTarifario.BuscarCodigo(cboTarifario.SelectedValue)
            lblPrecio.Text = Microsoft.VisualBasic.Format(dsTab.Tables(0).Rows(0)("Precio"), "#0.00")
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If Finalizar Then Exit Sub
        Dim Clasificador As String
        Clasificador = cboClas.SelectedValue
        If txtCantidad.Text.Length And e.KeyCode = Keys.Enter And IsNumeric(cboTarifario.SelectedValue) Then
            If MessageBox.Show("Desea Aplicar Porcentaje de Descuento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Dim Fila As ListViewItem
                Dim Importe As String
                Fila = lvDet.Items.Add(cboTarifario.SelectedValue)
                Fila.SubItems.Add(cboTarifario.Text)
                Fila.SubItems.Add(lblPrecio.Text)
                Fila.SubItems.Add(txtCantidad.Text)
                Importe = Val(lblPrecio.Text) * Val(txtCantidad.Text)
                Fila.SubItems.Add(Importe)
                Fila.SubItems.Add(txtFecha.Text)
                Fila.SubItems.Add(Clasificador)
                Fila.SubItems.Add(meFecha.Text)
                lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Val(Importe), "#0.00")
                txtCantidad.Text = "1"
                cboTarifario.Select()
                btnGrabar.Enabled = True
            Else
                Dim Fila As ListViewItem
                Dim Importe As String
                Dim Porcentaje As String
                Dim NuevoPrecio As String
                Porcentaje = InputBox("Ingresar Porcentaje de Descuento", "Sistema SOAT")
                NuevoPrecio = Microsoft.VisualBasic.Format(Val(lblPrecio.Text) * (Porcentaje / 100), "#0.00")
                If Not IsNumeric(Porcentaje) Then MessageBox.Show("Debe ingresar un valor numérico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                Fila = lvDet.Items.Add(cboTarifario.SelectedValue)
                Fila.SubItems.Add(cboTarifario.Text)
                Fila.SubItems.Add(NuevoPrecio)
                Fila.SubItems.Add(txtCantidad.Text)
                Importe = Microsoft.VisualBasic.Format(Val(NuevoPrecio) * Val(txtCantidad.Text), "#0.00")
                Fila.SubItems.Add(Importe)
                Fila.SubItems.Add(txtFecha.Text)
                Fila.SubItems.Add(Clasificador)
                Fila.SubItems.Add(meFecha.Text)
                lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Val(Importe), "#0.00")
                txtCantidad.Text = "1"
                cboTarifario.Select()
                btnGrabar.Enabled = True
            End If
        End If

    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items.Item(I).Selected Then
                    lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) - Val(lvDet.Items.Item(I).SubItems(4).Text), "#0.00")
                    lvDet.Items.RemoveAt(I)
                    Exit For
                End If
            Next
            If lvDet.Items.Count = 0 Then btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblAPaterno.Text = ""
        lblAMaterno.Text = ""
        lblNombres.Text = ""
        lblFecha.Text = ""
        lblSexo.Text = ""
        lblPoliza.Text = ""
        lblPlaca.Text = ""
        lblContratante.Text = ""
        lblAseguradora.Text = ""
        lblFecha.Text = ""
        lblCIE.Text = ""
        lvDet.Items.Clear()
        txtHistoria.Text = ""
        btnGrabar.Enabled = False
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar los datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            Dim dsTar As New DataSet

            CodRecibo = objRecibo.Grabar(Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, My.Computer.Name, CodLocal, lblTotal.Text)
            For I = 0 To lvDet.Items.Count - 1
                objFicha.GrabarDetalle(CodLocal, lvDet.Items.Item(I).SubItems(0).Text, lvDet.Items.Item(I).SubItems(1).Text, lvDet.Items.Item(I).SubItems(2).Text, lvDet.Items.Item(I).SubItems(3).Text, lvDet.Items.Item(I).SubItems(4).Text, lvDet.Items.Item(I).SubItems(5).Text, lvDet.Items.Item(I).SubItems(6).Text, lvDet.Items.Item(I).SubItems(7).Text, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name)
                objRecibo.GrabarDetalle(CodRecibo, lvDet.Items.Item(I).SubItems(0).Text, lvDet.Items.Item(I).SubItems(1).Text, lvDet.Items.Item(I).SubItems(2).Text, lvDet.Items.Item(I).SubItems(3).Text, lvDet.Items.Item(I).SubItems(4).Text)
                dsTar = objTarifario.BuscarCodigo(lvDet.Items.Item(I).SubItems(0).Text)
                objConsulta.GrabarExaOrigen(0, lvDet.Items.Item(I).SubItems(0).Text, lvDet.Items.Item(I).SubItems(1).Text, lvDet.Items.Item(I).SubItems(2).Text, lvDet.Items.Item(I).SubItems(3).Text, 0, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, "LABORATORIO", dsTar.Tables(0).Rows(0)("SubTipo"), "SOAT", CodLocal, "", "", txtHistoria.Text, lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, "SOAT", "")
            Next
            MessageBox.Show("Insert papel para Recibo de Autorizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ppdVistaPrevia.ShowDialog()

        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCuenta.Click
        frmCuenta.Show()
    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboClas.Select()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter And txtCodigo.Text.Length = 0 Then cboTarifario.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCodigo.Text.Length > 0 Then
            Dim dsTabCT As New Data.DataSet
            dsTabCT = objTarifario.BuscarCodigoSoat(txtCodigo.Text)
            If dsTabCT.Tables(0).Rows.Count > 0 Then
                cboTarifario.Text = dsTabCT.Tables(0).Rows(0)("Descripcion")
                cboTarifario_SelectedIndexChanged(sender, e)
                txtFecha.Select()
            Else
                MessageBox.Show("Codigo de SOAT no existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCodigo.Select()
            End If

        End If
    End Sub

    Private Sub cboClas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboClas.KeyDown
        If e.KeyCode = Keys.Enter Then txtCantidad.Select()
    End Sub

    Private Sub cboClas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClas.SelectedIndexChanged

    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub txtFecha_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown
        If e.KeyCode = Keys.Enter Then meFecha.Select()
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress

    End Sub

    Private Sub txtFecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.LostFocus
        'If MessageBox.Show("Desea Generar un Rango de Días", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    Dim NumeroDias As Double = InputBox("Ingresar Número de Días", "Rango de Fechas", 1)
        '    If IsNumeric(NumeroDias) Then
        '        meFecha.Text = Microsoft.VisualBasic.DateAdd(DateInterval.Day, NumeroDias, CDate(txtFecha.Text))
        '    End If
        'End If
    End Sub

    Private Sub meFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles meFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboClas.Select()
    End Sub

    Private Sub meFecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles meFecha.LostFocus
        If txtFecha.Text <> "  /  /" And meFecha.Text <> "  /  /" Then txtCantidad.Text = Microsoft.VisualBasic.DateDiff(DateInterval.Day, CDate(txtFecha.Text), CDate(meFecha.Text))
    End Sub

    Private Sub btnPreliquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreliquidacion.Click
        Preliquidacion = InputBox("Ingresar Nro de Preliquidaciòn", "Datos de Preliquidaciòn")
        If Not IsNumeric(Preliquidacion) Then MessageBox.Show("Debe ingresar un valor numèrico", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim dsTabla As New Data.DataSet
        dsTabla = objFicha.BuscarNroPre(Preliquidacion)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
            txtHistoria.Text = dsTabla.Tables(0).Rows(0)("Historia")
            lblFechaRegistro.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FechaRegistro"), 10)
            lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
            lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
            lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
            lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaNac")
            If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
            Else
                lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
            End If
            lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
            lblPlaca.Text = dsTabla.Tables(0).Rows(0)("Placa")
            lblPoliza.Text = dsTabla.Tables(0).Rows(0)("Poliza")
            lblContratante.Text = dsTabla.Tables(0).Rows(0)("Contratante")
            lblAseguradora.Text = dsTabla.Tables(0).Rows(0)("Aseguradora")
            lblCIE.Text = dsTabla.Tables(0).Rows(0)("CIE1")
            lblTotal.Text = "0.00"
            cboTarifario.Select()
            btnCuenta.Enabled = True
        Else
            MessageBox.Show("No Existe FICHA DE SOAT Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblAPaterno.Text = ""
            lblAMaterno.Text = ""
            lblNombres.Text = ""
            lblFecha.Text = ""
            lblSexo.Text = ""
            lblPoliza.Text = ""
            lblPlaca.Text = ""
            lblEdad.Text = ""
            lblContratante.Text = ""
            lblAseguradora.Text = ""
            lblCIE.Text = ""
            txtHistoria.Text = ""
            txtHistoria.Select()
            btnCuenta.Enabled = False
            btnGrabar.Enabled = False
        End If

    End Sub

    Private Sub txtPre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPre.KeyPress
        Finalizar = False
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtPre.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosPreNP(txtPre.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
                txtHistoria.Text = dsTabla.Tables(0).Rows(0)("Historia")
                lblFechaRegistro.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FechaRegistro"), 10)
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaNac")
                If lblFecha.Text <> "" Then
                    If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                        lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                    Else
                        lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                    End If
                End If
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                lblPlaca.Text = dsTabla.Tables(0).Rows(0)("Placa")
                lblPoliza.Text = dsTabla.Tables(0).Rows(0)("Poliza")
                lblContratante.Text = dsTabla.Tables(0).Rows(0)("Contratante")
                lblAseguradora.Text = dsTabla.Tables(0).Rows(0)("Aseguradora")
                lblCIE.Text = dsTabla.Tables(0).Rows(0)("CIE1")
                lblTotal.Text = "0.00"
                cboTarifario.Select()
                btnCuenta.Enabled = True
                If dsTabla.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Ficha ya fue finalizada", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnGrabar.Enabled = False : Finalizar = True Else btnGrabar.Enabled = True
            Else
                MessageBox.Show("No Existe FICHA DE SOAT Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                lblPoliza.Text = ""
                lblPlaca.Text = ""
                lblEdad.Text = ""
                lblContratante.Text = ""
                lblAseguradora.Text = ""
                lblCIE.Text = ""
                txtHistoria.Text = ""
                txtPre.Select()
                btnCuenta.Enabled = False
                btnGrabar.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtPre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPre.TextChanged

    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            .DrawString(Date.Now.ToShortDateString, FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("UNIDAD DE SEGUROS", FuenteE, Pincel, 60, Y)
            .DrawString(Date.Now.ToShortTimeString, FuenteE, Pincel, 680, Y)

            Y = Y + 40

            .DrawString("AUTORIZACION DE ATENCION DE PROCEDIMIENTOS NRO " & Microsoft.VisualBasic.Right("000000" & CodRecibo, 6), Fuente, Pincel, 120, Y)
            Y = Y + 10
            .DrawString("------------------------------------------------------", Fuente, Pincel, 120, Y)
            Y = Y + 20
            .DrawString("Historia   :" & txtHistoria.Text, Fuente, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("Paciente   :" & lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, Fuente, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("Aseguradora: " & lblAseguradora.Text, Fuente, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("CIE        : " & lblCIE.Text, Fuente, Pincel, 40, Y)
            Y = Y + 40
            .DrawLine(Pens.Black, 40, Y, 780, Y)
            Y = Y + 10
            .DrawString("Cant       Descripcion                     Precio  Importe   Fecha" & lblCIE.Text, Fuente, Pincel, 40, Y)
            Y = Y + 20
            .DrawLine(Pens.Black, 40, Y, 780, Y)
        End With
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20
        Encabezado(e)
        Filas = 10

        Y = Y + 10
        NroFilasHoja = 0
        With e.Graphics
            For Filas = 0 To lvDet.Items.Count - 1
                .DrawString(Microsoft.VisualBasic.Right(StrDup(4, " ") & lvDet.Items.Item(Filas).SubItems(3).Text, 4), Fuente, Pincel, 40, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items.Item(Filas).SubItems(1).Text & StrDup(34, " "), 34), Fuente, Pincel, 100, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(8, " ") & Microsoft.VisualBasic.Format(Val(lvDet.Items.Item(Filas).SubItems(2).Text), "#0.00"), 8), Fuente, Pincel, 450, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(8, " ") & Microsoft.VisualBasic.Format(Val(lvDet.Items.Item(Filas).SubItems(4).Text), "#0.00"), 8), Fuente, Pincel, 550, Y)
                .DrawString(lvDet.Items.Item(Filas).SubItems(5).Text, Fuente, Pincel, 650, Y)
                Y = Y + 15
            Next
            .DrawLine(Pens.Black, 40, Y, 780, Y)
            Y = Y + 15
            .DrawString("TOTAL S/. " & Microsoft.VisualBasic.Right(StrDup(8, " ") & Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#0.00"), 8), Fuente, Pincel, 450, Y)
            Y = Y + 50
            .DrawString("(*)PARA SU ATENCION DEBE TENER FIRMA Y SELLO DE QUIEN LO ELABORA", Fuente, Pincel, 20, Y)
            Y = Y + 15
            .DrawString("(*)ESTE DOCUMENTO NO ES UN COMPROBANTE DE PAGO", Fuente, Pincel, 20, Y)
        End With
    End Sub

    Private Sub txtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCodigo.TextChanged

    End Sub
End Class