Public Class frmCancelarDoc
    Dim objFicha As New FichaSoat
    Dim objFacturacion As New FacturacionEconomia
    Dim CodLocal As String

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosDev(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
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
                If Not (dsTabla.Tables(0).Rows(0)("SerieDoc").ToString = "") Then
                    lbTipo.Text = dsTabla.Tables(0).Rows(0)("TipoDoc")
                    lblSerie.Text = dsTabla.Tables(0).Rows(0)("SerieDoc")
                    lblNumero.Text = Microsoft.VisualBasic.Right("0000000" & dsTabla.Tables(0).Rows(0)("NumeroDoc"), 7)
                    lblFechaDoc.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FechaFacturado").ToString, 10)
                    btnCancelarP.Enabled = True
                Else
                    lbTipo.Text = ""
                    lblSerie.Text = ""
                    lblNumero.Text = ""
                    lblFecha.Text = ""
                    btnCancelarP.Enabled = False
                End If

                If Not (dsTabla.Tables(0).Rows(0)("SerieDocF").ToString = "") Then
                    lblTipoF.Text = dsTabla.Tables(0).Rows(0)("TipoDocF")
                    lblSerieF.Text = dsTabla.Tables(0).Rows(0)("SerieDocF")
                    lblNumeroF.Text = Microsoft.VisualBasic.Right("0000000" & dsTabla.Tables(0).Rows(0)("NumeroDocF"), 7)
                    lblFechaDocF.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FechaFacturadoF").ToString, 10)
                    btnCancelarM.Enabled = True
                Else
                    lblTipoF.Text = ""
                    lblSerieF.Text = ""
                    lblNumeroF.Text = ""
                    lblFechaDocF.Text = ""
                    btnCancelarM.Enabled = False
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
                txtHistoria.Text = ""
                lbTipo.Text = ""
                lblSerie.Text = ""
                lblNumero.Text = ""
                lblFechaDoc.Text = ""
                lblTipoF.Text = ""
                lblSerieF.Text = ""
                lblNumeroF.Text = ""
                lblFechaDocF.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        lbTipo.Text = ""
        lblSerie.Text = ""
        lblNumero.Text = ""
        lblAPaterno.Text = ""
        lblAMaterno.Text = ""
        lblNombres.Text = ""
        lblFecha.Text = ""
        lblSexo.Text = ""
        lblEdad.Text = ""
        lblPlaca.Text = ""
        lblPoliza.Text = ""
        lblContratante.Text = ""
        lblAseguradora.Text = ""
        lblTipoF.Text = ""
        lblSerieF.Text = ""
        lblNumeroF.Text = ""
        lblFechaDoc.Text = ""
        lblFechaDocF.Text = ""
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
        btnCancelarP.Enabled = False
        btnCancelarM.Enabled = False
    End Sub

    Private Sub btnCancelarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarP.Click
        'Verificar si ya fue cancelado
        Dim dsValidar As New DataSet
        dsValidar = objFacturacion.Verificar(lbTipo.Text, lblNumero.Text, lblSerie.Text)
        If dsValidar.Tables(0).Rows.Count > 0 Then
            If dsValidar.Tables(0).Rows(0)("FechaCancelado").ToString <> "" Then
                MessageBox.Show("Documento ya fue Cancelado, Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If MessageBox.Show("Esta seguro de Cancelar Comprobante de Venta", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objFicha.CancelarDocumento(CodLocal, dtpF1.Value.ToShortDateString, UsuarioSistema)
            Dim NroCheque As String
            NroCheque = InputBox("Ingresar Nro Cheque", "Datos de Facturación")
            objFacturacion.CancelarNDoc(lbTipo.Text, lblNumero.Text, lblSerie.Text, dtpF1.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpF1.Value.ToShortTimeString, 5), UsuarioSistema, NroCheque)
            MessageBox.Show("Comprobante de Servicios Cancelado Satisfactoriamente", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

 
    Private Sub btnCancelarM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarM.Click
        If MessageBox.Show("Esta seguro de Cancelar Comprobante de Venta", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Verificar si ya fue cancelado
            Dim dsValidar As New DataSet
            dsValidar = objFacturacion.Verificar(lblTipoF.Text, lblNumeroF.Text, lblSerieF.Text)
            If dsValidar.Tables(0).Rows.Count > 0 Then
                If dsValidar.Tables(0).Rows(0)("FechaCancelado").ToString <> "" Then
                    MessageBox.Show("Documento ya fue Cancelado, Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            objFicha.CancelarDocumentoF(CodLocal, dtpF2.Value.ToShortDateString, UsuarioSistema)
            Dim NroCheque As String
            NroCheque = InputBox("Ingresar Nro Cheque", "Datos de Facturación")
            objFacturacion.CancelarNDoc(lblTipoF.Text, lblNumeroF.Text, lblSerieF.Text, dtpF1.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpF1.Value.ToShortTimeString, 5), UsuarioSistema, NroCheque)
            MessageBox.Show("Comprobante de Medicamentos Cancelado Satisfactoriamente", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmCancelarDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub
End Class