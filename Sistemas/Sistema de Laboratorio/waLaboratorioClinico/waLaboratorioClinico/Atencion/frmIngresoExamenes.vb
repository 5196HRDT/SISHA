Public Class frmIngresoExamenes
    Dim objIngreso As New clsEmergenciaIngreso
    Dim objHistoria As New clsHistoria
    Dim objEstadoCivil As New clsEstadoCivil
    Dim objConsulta As New clsEmergenciaIngreso_Consulta
    Dim objServicioItem As New clsServicioItem
    Dim objDetalleSer As New clsEmergenciaSer
    Dim objSoat As New clsSOAT
    Dim objSIS As New clsSIS
    Dim objConvenio As New clsConvenio
    Dim objComprobante As New clsComprobanteVta

    Dim CodigoIngreso As String

    Private Sub Total()
        Dim I As Integer
        lblTotal.Text = "0.00"
        For I = 0 To lvTabla.Items.Count - 1
            lblTotal.Text = Val(lblTotal.Text) + Val(lvTabla.Items(I).SubItems(4).Text)
        Next
        lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#,##0.00")
    End Sub

    Private Sub Botones(Nuevo As Boolean, Grabar As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
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
        lblEdad.Text = EdadA
        lblTEdad.Text = "A"
        lblEdadM.Text = EdadM
        lblTEdadM.Text = "M"
        lblEdadD.Text = EdadD
        lblTEdadD.Text = "D"

        'If Val(EdadA) > 0 Then
        '    lblEdad.Text = EdadA
        '    lblTEdad.Text = "A"
        'ElseIf Val(EdadM) > 0 Then
        '    lblEdad.Text = EdadM
        '    lblTEdad.Text = "M"
        'Else
        '    lblEdad.Text = EdadD
        '    lblTEdad.Text = "D"
        'End If
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            CalcularEdad(Date.Now.ToShortDateString, dsHistorias.Tables(0).Rows(0)("FNacimiento"))


            'Estado Civil
            dsEC = objEstadoCivil.DameDes(Val(dsHistorias.Tables(0).Rows(0)("EstadoCivil").ToString))
            If dsEC.Tables(0).Rows.Count > 0 Then
                lblEstadoCivil.Text = dsEC.Tables(0).Rows(0)("Descripcion")
            Else
                lblEstadoCivil.Text = "NINGUNO"
            End If

            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
            btnGrabar.Enabled = True
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            Dim dsVer As New DataSet
            dsVer = objIngreso.VerificarIngreso(txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                CodigoIngreso = dsVer.Tables(0).Rows(0)("IdIngreso")
                lblServicio.Text = dsVer.Tables(0).Rows(0)("Especialidad")
                lblTipoAtencion.Text = dsVer.Tables(0).Rows(0)("TipoAtencion").ToString
                If dsVer.Tables(0).Rows(0)("TipoAtencion").ToString = "SIS" Then
                    txtSerieSIS.Text = dsVer.Tables(0).Rows(0)("SerieSIS").ToString
                    txtNumeroSIS.Text = dsVer.Tables(0).Rows(0)("NumeroSIS").ToString

                    If IsNumeric(txtNumeroSIS.Text) Then
                        BuscarProcedimientosSIS()
                    End If
                ElseIf dsVer.Tables(0).Rows(0)("TipoAtencion").ToString = "SOAT/AFOCAT" Then
                    txtPreliquidacion.Text = dsVer.Tables(0).Rows(0)("Preliquidacion").ToString
                    If IsNumeric(txtPreliquidacion.Text) Then BuscarProcedimientosSOAT()
                ElseIf lblTipoAtencion.Text = "CAJA DE PROTECCION" Or lblTipoAtencion.Text = "INPE" Or lblTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or lblTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                    txtPreliquidacion.Text = dsVer.Tables(0).Rows(0)("Preliquidacion").ToString
                Else
                    txtSerieSIS.Text = ""
                    txtNumeroSIS.Text = ""
                    txtPreliquidacion.Text = ""
                End If

                Dim dsConsulta As New DataSet
                dsConsulta = objConsulta.ConsultaBuscar(CodigoIngreso)
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    lblCie1.Text = dsConsulta.Tables(0).Rows(0)("Cie1")
                    lblDes1.Text = dsConsulta.Tables(0).Rows(0)("DesCie1")
                    lblCie2.Text = dsConsulta.Tables(0).Rows(0)("Cie2")
                    lblDes2.Text = dsConsulta.Tables(0).Rows(0)("DesCie2")
                    lblCie3.Text = dsConsulta.Tables(0).Rows(0)("Cie3")
                    lblDes3.Text = dsConsulta.Tables(0).Rows(0)("DesCie3")
                End If

                txtProcedimiento.Select()
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub frmIngresoExamenes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        Limpiar(Me)
        gbPaciente.Visible = False
        gbSI.Visible = False
        lvTabla.Items.Clear()
    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        btnBuscarP.Enabled = True
        cboTipoDoc.Text = "BOLETA"
        txtHistoria.Select()
    End Sub

    Private Sub txtProcedimiento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProcedimiento.TextChanged
        If txtProcedimiento.Text <> "" And txtProcedimiento.Enabled Then txtDescripcion.Text = txtProcedimiento.Text : txtDescripcion.SelectionStart = txtDescripcion.Text.Length : gbSI.Visible = True : txtDescripcion.Select()
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If lvSI.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvSI.Select()
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        If txtDescripcion.Text <> "" And txtDescripcion.Enabled Then
            Dim dsVer As New DataSet
            Dim I As Integer
            Dim Fila As ListViewItem

            lvSI.Items.Clear()

            'Procedimientos de Paciente Comun
            If lblTipoAtencion.Text = "COMUN" Then
                dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, "LABORATORIO", "COMUN")
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                Next
            End If

            'Procedimientos de Paciente SIS
            If lblTipoAtencion.Text = "SIS" Then
                dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, "LABORATORIO", "SIS")
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                Next
            End If

            'Procedimientos de Paciente SOAT
            If lblTipoAtencion.Text = "SOAT/AFOCAT" Then
                dsVer = objSoat.BuscarDes(txtDescripcion.Text, "LABORATORIO")
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdTarifario"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                Next
            End If

            'Procedimientos de Paciente Convenio
            If lblTipoAtencion.Text = "CAJA DE PROTECCION" Or lblTipoAtencion.Text = "INPE" Or lblTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or lblTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, "LABORATORIO", lblTipoAtencion.Text)
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                Next
            End If
        End If
    End Sub

    Private Sub btnRetornarSI_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarSI.Click
        gbSI.Visible = False
    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub lvSI_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvSI.KeyDown
        If e.KeyCode = Keys.Enter And lvSI.SelectedItems.Count > 0 Then
            If Val(lvSI.SelectedItems(0).SubItems(2).Text) = 0 Then MessageBox.Show("No tiene Precio definido informar a Farmacia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            txtProcedimiento.Enabled = False
            txtProcedimiento.Tag = lvSI.SelectedItems(0).SubItems(0).Text
            txtProcedimiento.Text = lvSI.SelectedItems(0).SubItems(1).Text
            txtProcedimiento.Enabled = True
            txtCantidad.Text = "1"
            lblPrecio.Text = lvSI.SelectedItems(0).SubItems(2).Text
            txtCantidad.Select()
            btnRetornarSI_Click(sender, e)
        End If
    End Sub

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtPaciente.Text)
            lvPaciente.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvPaciente.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FNacimiento").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomPadre").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomMadre").ToString)
            Next
        End If
    End Sub

    Private Sub lvPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
            gbPaciente.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If lblTipoAtencion.Text = "COMUN" Then MessageBox.Show("Debe ingresar procedimientos por medio del comprobante de pago o por emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If lblTipoAtencion.Text = "SIS" Then MessageBox.Show("Debe ingresar procedimientos en la Unidad de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If txtProcedimiento.Text <> "" And IsNumeric(txtCantidad.Text) And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(txtProcedimiento.Tag)
            Fila.SubItems.Add(txtCantidad.Text)
            Fila.SubItems.Add(txtProcedimiento.Text)
            Fila.SubItems.Add(lblPrecio.Text)
            Fila.SubItems.Add(Val(lblPrecio.Text) * Val(txtCantidad.Text))
            Total()
            txtProcedimiento.Tag = ""
            txtProcedimiento.Text = ""
            txtCantidad.Text = ""
            lblPrecio.Text = ""
            txtProcedimiento.Select()
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
            Total()
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            Dim CodigoSIS As String = ""
            Dim CodigoSoat As String = ""
            Dim CodigoConvenio As String = ""
            Dim Fecha As String
            Dim Hora As String

            'Verificar Tipo de Paciente para obtener Codigos
            If lblTipoAtencion.Text = "SIS" Then
                Dim dsSIS As New DataSet
                dsSIS = objSIS.ConsultarLN(txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text)
                CodigoSIS = dsSIS.Tables(0).Rows(0)("IdSis")

                If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                    If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                End If
                If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                    MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                End If
            End If

            'Verificar Tipo de Paciente para obtener Codigos
            If lblTipoAtencion.Text = "SOAT/AFOCAT" Then
                Dim dsSoat As New DataSet
                dsSoat = objSoat.BuscarPH(txtPreliquidacion.Text, txtHistoria.Text)
                CodigoSoat = dsSoat.Tables(0).Rows(0)("IdSoat")

                If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If

            'Verificar Tipo de Paciente para obtener Codigos
            If lblTipoAtencion.Text = "CAJA DE PROTECCION" Or lblTipoAtencion.Text = "INPE" Or lblTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or lblTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                Dim dsConvenio As New DataSet
                dsConvenio = objConvenio.BuscarCH(txtPreliquidacion.Text, txtHistoria.Text)
                CodigoConvenio = dsConvenio.Tables(0).Rows(0)("IdConvenio")

                If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then MessageBox.Show("Atencion de Convenio ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If

            'Registrar detalle de Procedimientos
            For I = 0 To lvTabla.Items.Count - 1
                Fecha = Date.Now.ToShortDateString
                Hora = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
                'Paciente Comun
                If lblTipoAtencion.Text = "COMUN" Then
                    objDetalleSer.GrabarConvenio(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, IdUsuario, UsuarioSistema, "LABORATORIO")
                End If


                'Paciente SIS
                If lblTipoAtencion.Text = "SIS" Then
                    'If CodigoSIS <> "" Then objSIS.GrabarProcedimientosN(CodigoSIS, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(4).Text, UsuarioSistema, My.Computer.Name, Fecha, Hora)
                    If CodigoSIS <> "" Then objSIS.AtencionProcedimientoSis(lvTabla.Items(I).SubItems(5).Text, Fecha, Hora, UsuarioSistema)
                    objDetalleSer.GrabarConvenio(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, IdUsuario, UsuarioSistema, "LABORATORIO")
                End If

                'Paciente Soat
                If lblTipoAtencion.Text = "SOAT/AFOCAT" Then
                    'If CodigoSoat <> "" Then objSoat.GrabarDetalle(CodigoSoat, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, 3, "  /  /", Fecha, Hora, UsuarioSistema, My.Computer.Name)
                    objDetalleSer.GrabarConvenio(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, IdUsuario, UsuarioSistema, "LABORATORIO")
                    objSoat.AtencionProc(lvTabla.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Right(Date.Now.ToShortTimeString, 5), My.Computer.Name, UsuarioSistema)
                End If

                'Pacientes Convenio
                If lblTipoAtencion.Text = "CAJA DE PROTECCION" Or lblTipoAtencion.Text = "INPE" Or lblTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or lblTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                    If CodigoConvenio <> "" Then objConvenio.GrabarProcedimientos(CodigoConvenio, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(4).Text, Fecha, Hora, UsuarioSistema, My.Computer.Name, Date.Now.ToShortDateString, "  /  /")
                    objDetalleSer.GrabarConvenio(CodigoIngreso, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, IdUsuario, UsuarioSistema, "LABORATORIO")
                End If
            Next
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub cboTipoDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipoDoc.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoDoc.Text <> "" Then txtSerie.Select()
    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoDoc.SelectedIndexChanged

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter And txtSerie.Text <> "" Then txtNumero.Select()
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        txtSerie.Text = Microsoft.VisualBasic.Right("000" & txtSerie.Text, 3)
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub BuscarProcedimientosSIS()
        Dim dsSis As New DataSet
        Dim dsDet As New DataSet
        lvTabla.Items.Clear()
        dsSis = objSIS.ConsultarLN(txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text)
        If dsSis.Tables(0).Rows.Count > 0 Then
            If lblTipoAtencion.Text = "" Then
                lblTipoAtencion.Text = "SIS"
                objIngreso.ActualizarTipoAtencion(CodigoIngreso, lblTipoAtencion.Text, lblPaciente.Text, lblSexo.Text)
                objIngreso.ActualizarFormatoSIS(CodigoIngreso, txtSerieSIS.Text, txtNumeroSIS.Text)
            End If

            Dim IdSis As String
            IdSis = dsSis.Tables(0).Rows(0)("IdSis")
            dsDet = objSIS.ListaServiciosSIS(IdSis)
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim Importe As String
            For I = 0 To dsDet.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsDet.Tables(0).Rows(I)("IdProcedimiento"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Cantidad")), "0.00"))
                Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Precio")), "0.00"))
                Importe = Val(dsDet.Tables(0).Rows(I)("Cantidad")) * Val(dsDet.Tables(0).Rows(I)("Precio"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(Importe), "0.00"))
                Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Id"))
            Next
            Total()
        Else
            MessageBox.Show("Nro de Formato no Corresponde a Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BuscarProcedimientosSOAT()
        Dim dsSis As New DataSet
        Dim dsDet As New DataSet
        lvTabla.Items.Clear()
        dsDet = objSoat.ListaServiciosSOAT(txtPreliquidacion.Text, txtHistoria.Text)
        If dsDet.Tables(0).Rows.Count > 0 Then
            'If lblTipoAtencion.Text = "" Then
            '    lblTipoAtencion.Text = "SIS"
            '    objIngreso.ActualizarTipoAtencion(CodigoIngreso, lblTipoAtencion.Text, lblPaciente.Text, lblSexo.Text)
            '    objIngreso.ActualizarFormatoSIS(CodigoIngreso, txtSerieSIS.Text, txtNumeroSIS.Text)
            'End If

            'Dim IdSis As String
            'IdSis = dsSis.Tables(0).Rows(0)("IdSis")
            'dsDet = objSIS.ListaServiciosSIS(IdSis)
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim Importe As String
            For I = 0 To dsDet.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsDet.Tables(0).Rows(I)("IdTarifario"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Cantidad")), "0.00"))
                Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDet.Tables(0).Rows(I)("Precio")), "0.00"))
                Importe = Val(dsDet.Tables(0).Rows(I)("Importe"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(Importe), "0.00"))
                Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("IdDet"))
            Next
            Total()
        Else
            MessageBox.Show("Nro de Formato no Corresponde a Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If cboTipoDoc.Text <> "" And txtSerie.Text <> "" And IsNumeric(txtNumero.Text) Then
            Dim I As Integer
            Dim Importe As String
            Dim Fila As ListViewItem
            lvTabla.Items.Clear()
            If cboTipoDoc.Text = "BOLETA" Then
                Dim dsDoc As New DataSet
                dsDoc = objComprobante.BuscarLaboratorio(txtSerie.Text, txtNumero.Text)
                If dsDoc.Tables(0).Rows.Count > 0 Then
                    For I = 0 To dsDoc.Tables(0).Rows.Count - 1
                        Fila = lvTabla.Items.Add(dsDoc.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDoc.Tables(0).Rows(I)("Precio")), "0.00"))
                        Fila.SubItems.Add(dsDoc.Tables(0).Rows(I)("Servicio"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDoc.Tables(0).Rows(I)("Cantidad")), "0.00"))
                        Importe = Val(dsDoc.Tables(0).Rows(I)("Cantidad")) * Val(dsDoc.Tables(0).Rows(I)("Precio"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(Importe), "0.00"))
                    Next
                    Total()
                End If
            End If
        End If
    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub txtSerieSIS_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieSIS.KeyDown
        If e.KeyCode = Keys.Enter And txtSerieSIS.Text <> "" Then txtNumeroSIS.Select()
    End Sub

    Private Sub txtSerieSIS_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerieSIS.TextChanged

    End Sub

    Private Sub txtNumeroSIS_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroSIS.KeyDown
        If IsNumeric(txtSerieSIS.Text) And IsNumeric(txtNumeroSIS.Text) And e.KeyCode = Keys.Enter Then
            BuscarProcedimientosSIS()
        End If
    End Sub

    Private Sub txtNumeroSIS_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroSIS.TextChanged

    End Sub
End Class