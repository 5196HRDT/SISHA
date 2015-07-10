Public Class frmIngresoSis
    Dim objSIS As New SIS
    Dim objHistoria As New Historia
    Dim objEspecialidad As New Especialidad
    Dim objSubEspecialidad As New SubEspecialidad
    Dim objCentro As New CentroSalud
    Dim objIngreso As New Emergencia_Ingreso
    Dim Equipo As String
    Dim EESS As String
    Dim CodSis As String
    Dim Oper As String
    Dim valNeoNato As Boolean
    Dim Bandera, Prof, VitK, VacHVB, VacBCG, TipoParto, TipoRn As String
    Dim delimitador As Char() = {"-", " "}
    Dim idPaciente As Integer
    Dim idNeoNato As Integer
    Dim idGestante As Integer
    'Anulados
    Dim objAnulado As New AfiliadoNulo
    'carga de datos'
    Dim dsGeneral As New DataSet
    Dim dsPaciente As New DataSet
    'Variables Impresion
    Dim Fuente As New Font("Courier New", 14, FontStyle.Bold)
    Dim FuenteE As New Font("Courier New", 12)
    Dim FuenteG As New Font("Courier New", 30, FontStyle.Bold)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub cboLote_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLote.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboLote.Text.Length > 0 Then txtNumero.Select()
    End Sub
    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumero.Text.Length > 0 Then lblDISAHEI.Select()
    End Sub
    Private Sub txtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.LostFocus
        Dim I As Integer
        For I = 1 To 8 - txtNumero.Text.Length
            txtNumero.Text = "0" & txtNumero.Text
        Next
        txtNumero.Text.Remove(txtNumero.Text.Length - 8, 8)
        Oper = 1
        'Verificar registro
        Dim dsTabla As New Data.DataSet
        dsTabla = objSIS.ConsultarHEI(lblHEI.Text, cboLote.Text, txtNumero.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            If MessageBox.Show("Formato de Atención ya fue Registrado, Desea Modificar la Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                CodSis = dsTabla.Tables(0).Rows(0)("IdSIS")
                lblDISAHEI.Text = dsTabla.Tables(0).Rows(0)("DISAHEI")
                cboLoteA.Text = dsTabla.Tables(0).Rows(0)("LOTEDISA")
                txtNumeroA.Text = dsTabla.Tables(0).Rows(0)("NumeroDISA")
                txtNumeroA_LostFocus(sender, e)
                txtCorrelativo.Text = dsTabla.Tables(0).Rows(0)("Correlativo")
                txtCorrelativo_LostFocus(sender, e)
                txtHistoria.Text = dsTabla.Tables(0).Rows(0)("Historia")
                dtpFecha.Value = dsTabla.Tables(0).Rows(0)("FechaAtencion").ToString
                txtHora.Text = dsTabla.Tables(0).Rows(0)("HoraAtencion")
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("APaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("AMaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                cboAseguramiento.Text = dsTabla.Tables(0).Rows(0)("Aseguramiento")
                cboSituacion.Text = dsTabla.Tables(0).Rows(0)("Situacion")
                txtNroRef.Text = dsTabla.Tables(0).Rows(0)("NroReferencia")
                cboReferencia.Text = dsTabla.Tables(0).Rows(0)("EsReferido")
                cboGesPuer.SelectedItem = dsTabla.Tables(0).Rows(0)("GesPuer")
                txtEESS.Text = dsTabla.Tables(0).Rows(0)("EsReferido")
                EESS = dsTabla.Tables(0).Rows(0)("EsReferido")
                cboEspecialidad.Text = dsTabla.Tables(0).Rows(0)("Especialidad")
                cboSubEspecialidad.Text = dsTabla.Tables(0).Rows(0)("Subespecialidad")
                cboVitaminaK.Text = dsTabla.Tables(0).Rows(0)("VitaminaK")
                cboProfilaxis.Text = dsTabla.Tables(0).Rows(0)("ProfilaxisOcular")
                Bandera = dsTabla.Tables(0).Rows(0)("Tipo")
                dsPaciente = objHistoria.BuscarNumero(dsTabla.Tables(0).Rows(0)("Historia").ToString())
                Dim s As String
                If dsPaciente.Tables(0).Rows.Count > 0 Then
                    s = dsPaciente.Tables(0).Rows(0)("idHistoria")
                    idPaciente = Val(s)
                    lblAPaterno.Text = dsPaciente.Tables(0).Rows(0)("Apaterno").ToString
                    lblAMaterno.Text = dsPaciente.Tables(0).Rows(0)("Amaterno").ToString
                    lblNombres.Text = dsPaciente.Tables(0).Rows(0)("Nombres").ToString
                    lblFecha.Text = Microsoft.VisualBasic.Left(dsPaciente.Tables(0).Rows(0)("FNacimiento").ToString, 10)
                    lblSexo.Text = dsPaciente.Tables(0).Rows(0)("Sexo").ToString
                    txtDNI.Text = dsPaciente.Tables(0).Rows(0)("Doc_Identidad").ToString
                    Dim xi As String
                    If Bandera = "G" Then
                        Dim dsTriaje As New DataSet
                        dsTriaje = objSIS.GestanteBuscar(idPaciente)
                        If dsTriaje.Tables(0).Rows.Count > 0 Then
                            xi = dsTriaje.Tables(0).Rows(0)("IdGestante")
                            idGestante = Val(xi)
                            txtPeso.Text = dsTriaje.Tables(0).Rows(0)("Peso")
                            txtTalla.Text = dsTriaje.Tables(0).Rows(0)("Talla")
                            txtGestacion.Text = dsTriaje.Tables(0).Rows(0)("EdadGestacional")
                            spSemanaG.Value = Val(txtGestacion.Text)
                            txtPresionA.Text = dsTriaje.Tables(0).Rows(0)("PresionArterial")
                            dtpFechaParto.Value = dsTriaje.Tables(0).Rows(0)("FechaParto")
                            If dtpFechaParto.Value > Now.Date Then objSIS.EliminarGestante(idGestante)
                            txtIMC.Text = (Math.Round((Convert.ToDouble(txtPeso.Text) / 1000) / Math.Pow((Convert.ToDouble(txtTalla.Text) / 100), 2))).ToString
                            gbTriaje.Enabled = True
                        End If
                    ElseIf Bandera = "RN" Then
                        Dim dsTriaje As New DataSet
                        dsTriaje = objSIS.NeoNatoBuscar(idPaciente)
                        If dsTriaje.Tables(0).Rows.Count > 0 Then
                            xi = dsTriaje.Tables(0).Rows(0)("IdNeoNato")
                            idNeoNato = Val(xi)
                            txtPeso.Text = dsTriaje.Tables(0).Rows(0)("Peso")
                            txtTalla.Text = dsTriaje.Tables(0).Rows(0)("Talla")
                            txtGestacion.Text = dsTriaje.Tables(0).Rows(0)("EdadGestacional")
                            txtApgar1.Text = dsTriaje.Tables(0).Rows(0)("Apgar1")
                            txtApgar5.Text = dsTriaje.Tables(0).Rows(0)("Apgar5")
                            chkVacBCG.Checked = dsTriaje.Tables(0).Rows(0)("VacunaBCG")
                            chkVacHVB.Checked = dsTriaje.Tables(0).Rows(0)("VacunaBCG")
                            chkProfOc.Checked = dsTriaje.Tables(0).Rows(0)("VacunaBCG")
                            gbTriaje.Enabled = True
                        End If
                    End If
                Else
                    Bandera = "CMN"
                End If
                Oper = 2
            End If
        End If
    End Sub
    Private Sub cboLoteA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLoteA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboLoteA.Text.Length > 0 Then txtNumeroA.Select()
    End Sub
    Private Sub txtNumeroA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumeroA.Text.Length > 0 Then txtCorrelativo.Select()
    End Sub
    Private Sub txtNumeroA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroA.LostFocus
        Dim I As Integer
        For I = 1 To 8 - txtNumeroA.Text.Length
            txtNumeroA.Text = "0" & txtNumeroA.Text
        Next
        txtNumeroA.Text.Remove(txtNumeroA.Text.Length - 8, 8)
        Dim dsTAnulado As New Data.DataSet
        dsTAnulado = objAnulado.BuscarAnulado("LIB-" & cboLoteA.Text & "-" & txtNumeroA.Text)
        Try
            If dsTAnulado.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("Paciente esta Registrado en ESSALUD" & Chr(13) & "Paciente " & dsTAnulado.Tables(0).Rows(0)("Afiliado") & Chr(13) & "Establecimiento " & dsTAnulado.Tables(0).Rows(0)("NomEst") & Chr(13) & "FechaNac " & dsTAnulado.Tables(0).Rows(0)("FechaNac") & Chr(13) & "Sexo " & dsTAnulado.Tables(0).Rows(0)("Sexo") & Chr(13) & "NroDoc " & dsTAnulado.Tables(0).Rows(0)("NroDoc") & Chr(13) & "VERIFICAR HOMONIMIA", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtCorrelativo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorrelativo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then cboAseguramiento.Select()
    End Sub
    Private Sub txtCorrelativo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCorrelativo.LostFocus
        Dim I As Integer
        For I = 1 To 3 - txtCorrelativo.Text.Length
            txtCorrelativo.Text = "0" & txtCorrelativo.Text
        Next
        txtCorrelativo.Text.Remove(txtCorrelativo.Text.Length - 3, 3)
    End Sub
    Private Sub cboLote_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLote.LostFocus
        If cboLote.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Lote", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub cboSituacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSituacion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboSituacion.Text.Length > 0 Then txtHistoria.Select()
    End Sub

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        Dim xy As String
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objSIS.ConsultarHEIHistoria(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If MessageBox.Show("Paciente tiene formato Activo Nro " & dsTabla.Tables(0).Rows(0)("HEI") & " " & dsTabla.Tables(0).Rows(0)("LOTE") & "-" & dsTabla.Tables(0).Rows(0)("Numero") & Chr(13) & "Aperturado el Dia " & dsTabla.Tables(0).Rows(0)("FechaAtencion") & " a Horas " & dsTabla.Tables(0).Rows(0)("HoraAtencion") & Chr(13) & "Desea Continuar Atención.....?", "Mensaje de Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then btnCancelar_Click(sender, e) : Exit Sub
            End If
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                xy = dsTabla.Tables(0).Rows(0)("idHistoria")
                idPaciente = Val(xy)
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno").ToString
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno").ToString
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres").ToString
                lblFecha.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FNacimiento").ToString, 10)
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo").ToString
                txtDNI.Text = dsTabla.Tables(0).Rows(0)("Doc_Identidad").ToString
                dsPaciente = objHistoria.BuscarNumero(txtHistoria.Text)
                Dim tpid As String
                If dsPaciente.Tables(0).Rows.Count > 0 Then
                    If Bandera = "G" Then
                        Dim dsTriaje As New DataSet
                        dsTriaje = objSIS.GestanteBuscar(idPaciente)
                        If dsTriaje.Tables(0).Rows.Count > 0 Then
                            tpid = dsTriaje.Tables(0).Rows(0)("IdGestante")
                            idGestante = Val(tpid)
                            txtPeso.Text = dsTriaje.Tables(0).Rows(0)("Peso")
                            txtTalla.Text = dsTriaje.Tables(0).Rows(0)("Talla")
                            txtGestacion.Text = dsTriaje.Tables(0).Rows(0)("EdadGestacional")
                            spSemanaG.Value = Val(txtGestacion.Text)
                            txtPresionA.Text = dsTriaje.Tables(0).Rows(0)("PresionArterial")
                            dtpFechaParto.Value = dsTriaje.Tables(0).Rows(0)("FechaParto")
                            txtIMC.Text = ((Convert.ToDouble(txtPeso.Text) / 1000) / Math.Pow((Convert.ToDouble(txtTalla.Text) / 100), 2)).ToString
                            gbTriaje.Enabled = True
                        End If
                    ElseIf Bandera = "RN" Then
                        Dim dsTriaje As New DataSet
                        dsTriaje = objSIS.NeoNatoBuscar(idPaciente)
                        If dsTriaje.Tables(0).Rows.Count > 0 Then
                            tpid = dsTriaje.Tables(0).Rows(0)("IdNeoNato")
                            idNeoNato = Val(tpid)
                            txtPeso.Text = dsTriaje.Tables(0).Rows(0)("Peso")
                            txtTalla.Text = dsTriaje.Tables(0).Rows(0)("Talla")
                            txtGestacion.Text = dsTriaje.Tables(0).Rows(0)("EdadGestacional")
                            txtApgar1.Text = dsTriaje.Tables(0).Rows(0)("Apgar1")
                            txtApgar5.Text = dsTriaje.Tables(0).Rows(0)("Apgar5")
                            chkVacBCG.Checked = dsTriaje.Tables(0).Rows(0)("VacunaBCG")
                            chkVacHVB.Checked = dsTriaje.Tables(0).Rows(0)("VacunaBCG")
                            chkProfOc.Checked = dsTriaje.Tables(0).Rows(0)("VacunaBCG")
                            gbTriaje.Enabled = True
                        End If
                    ElseIf Bandera = "PRP" Then
                        Dim dsTriaje As New DataSet
                        dsTriaje = objSIS.GestanteBuscar(idPaciente)
                        If dsTriaje.Tables(0).Rows.Count > 0 Then
                            tpid = dsTriaje.Tables(0).Rows(0)("IdGestante")
                            idGestante = Val(tpid)
                            txtPeso.Text = dsTriaje.Tables(0).Rows(0)("Peso")
                            txtTalla.Text = dsTriaje.Tables(0).Rows(0)("Talla")
                            txtPresionA.Text = dsTriaje.Tables(0).Rows(0)("PresionArterial")
                            dtpFechaParto.Value = dsTriaje.Tables(0).Rows(0)("FechaParto")
                            txtIMC.Text = ((Convert.ToDouble(txtPeso.Text) / 1000) / Math.Pow((Convert.ToDouble(txtTalla.Text) / 100), 2)).ToString("#0.00")
                            gbTriaje.Enabled = True
                        End If

                    End If
                Else : Bandera = "CMN"
                End If
                txtDNI.Text = txtNumeroA.Text
                txtDNI.Select()
                If lblFecha.Text = "" Then MessageBox.Show("Atención Formato de Fecha no es Válido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : lblFecha.Select()
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub
    Private Sub cboAtencion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAtencion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboAtencion.Text.Length > 0 Then txtNroRef.Select()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        dtpFecha.Value = Date.Now
        Botones(True, False, False, True)
        Limpiar(Me)
        LimpiarTab(Me.TabPage1)
        LimpiarTab(Me.TabPage2)
        LimpiarGroup(Me.gbTriaje)
        gbTriaje.Enabled = False

        cboVitaminaK.Text = "NO"
        txtApgar1.Text = ""
        txtApgar5.Text = ""
        cboBCG.Text = "NO"
        cboHVB.Text = "NO"
        cboProfilaxis.Text = "NO"
        cboGesPuer.SelectedIndex = 0
        cboAseguramiento.SelectedIndex = 0
        cboSituacion.SelectedIndex = 1
        tbDetalle.TabPages(0).Enabled = False
        tbDetalle.TabPages(1).Enabled = False

        cboOxitocina.Text = "NO"
        lblAPaterno.Text = ""
        lblAMaterno.Text = ""
        lblNombres.Text = ""
        lblFecha.Text = ""
        lblSexo.Text = ""
        NumeroHistoria = ""
        btnBuscarH.Enabled = False
        ControlesAD(Me, False)
        lblHEI.Text = "LIB"
        btnGrabar.Select()

    End Sub
    Private Sub frmIngresoSis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        Bandera = "CMN"
        dgvFiltro.AutoGenerateColumns = True
        gbBusqueda.Left = 18
        gbBusqueda.Top = 2
        gbBusqueda.BringToFront()
        gbTriaje.Enabled = False

        rbAteParV.Checked = True
        rbSano.Checked = True
        Equipo = My.Computer.Name
        cboAseguramiento.SelectedIndex = 0
        cboSituacion.SelectedIndex = 1

        'Tipo Afiliacion'
        Dim dsSis As New DataSet
        dsSis = objSIS.LoteListar(0)
        cboLoteA.DataSource = dsSis.Tables(0)
        cboLoteA.DisplayMember = "codigo"
        cboLoteA.ValueMember = "IdTipoAfiliacion"

        'Especialidad
        Dim dsEsp As New Data.DataSet
        dsEsp = objEspecialidad.Combo("%")
        cboEspecialidad.DataSource = dsEsp.Tables(0)
        cboEspecialidad.DisplayMember = "Descripcion"
        cboEspecialidad.ValueMember = "IdDpto"
        cboEspecialidad.SelectedIndex = 0

        If IsNumeric(cboEspecialidad.SelectedValue) Then
            Dim dsSEsp As New Data.DataSet
            dsSEsp = objSubEspecialidad.Combo(cboEspecialidad.SelectedValue)
            cboSubEspecialidad.DataSource = dsSEsp.Tables(0)
            cboSubEspecialidad.DisplayMember = "Descripcion"
            cboSubEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboAtencion.Text = "REFERENCIA"
        cboVitaminaK.Text = "NO"
        txtApgar1.Text = ""
        txtApgar5.Text = ""
        cboBCG.Text = "NO"
        cboHVB.Text = "NO"
        cboProfilaxis.Text = "NO"
        cboGesPuer.Text = "NINGUNA"
        cboOxitocina.Text = "NO"
        Dim Hora As String
        If Date.Now.Hour < 10 Then Hora = "0" & Date.Now.Hour Else Hora = Date.Now.Hour
        If Date.Now.Minute < 10 Then Hora = Hora & ":" & "0" & Date.Now.Hour Else Hora = Hora & ":" & Date.Now.Minute
        txtHora.Text = Hora
        btnBuscarH.Enabled = True
        cboLote.Select()
    End Sub

    Private Sub txtHora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHora.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHora.Text.Length > 0 Then dtpFV.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        cboReferencia.Text = EESS
        If Bandera = "RN" And (txtPeso.Text.Equals("") Or txtTalla.Text.Equals("") Or txtGestacion.Text.Equals("")) Then
            MessageBox.Show("Complete Los Datos!", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If cboGesPuer.SelectedIndex = 1 And (txtPeso.Text.Equals("") Or txtTalla.Text.Equals("") Or txtGestacion.Text.Equals("") _
            Or txtPresionA.Text.Equals("")) Then
            MessageBox.Show("Complete Los Datos!", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If cboGesPuer.SelectedIndex = 2 And (txtPeso.Text.Equals("") Or txtTalla.Text.Equals("") Or _
            txtPresionA.Text.Equals("")) Then
            MessageBox.Show("Complete Los Datos!", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If cboGesPuer.SelectedIndex > 0 And cboEspecialidad.Text = "RECIEN NACIDO" Then
            MessageBox.Show("Gestante o Recien Nacido!", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If valNeoNato = True Then
            If txtApgar1.Text.Equals("") Then txtApgar1.Text = "0"
            If txtApgar5.Text.Equals("") Then txtApgar5.Text = "0"
        End If
        Dim MontoUCI As String
        If lblFecha.Text = "" Then MessageBox.Show("Verificar Información de Fecha de Nacimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : lblFecha.Select() : Exit Sub
        If Val(cboLote.Text) = 0 Or Val(txtNumero.Text) = 0 Or Val(txtNumeroA.Text) = 0 Then MessageBox.Show("Verifique que todos los codigos sean correctos", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If cboLoteA.SelectedIndex = -1 Then MessageBox.Show("Verifique que todos los codigos sean correctos", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboLoteA.Select() : Exit Sub
        If cboLoteA.SelectedIndex = -1 Then MessageBox.Show("Debe ingresar Nro de Lote", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If dtpFV.Value <= dtpFecha.Value Then MessageBox.Show("Debe Ingresar Una Fecha Mayor a la Fecha de Contrato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : dtpFV.Select() : Exit Sub

        If MessageBox.Show("Esta seguro de guardar los datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            If Oper = 1 Then
                'Verificar por segunda vez registro de numero sis
                Dim dsTabla As New Data.DataSet
                dsTabla = objSIS.ConsultarHEI(lblHEI.Text, cboLote.Text, txtNumero.Text)
                If dsTabla.Tables(0).Rows.Count > 0 Then
                    MessageBox.Show("Ud. Esta Intentando Registrar un Numero de Formato SIS ya registrado. Se guardara la accion para su auditoria", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                objSIS.GrabarIngresoAP(lblHEI.Text, cboLote.Text, txtNumero.Text, lblDISAHEI.Text, cboLoteA.Text, txtNumeroA.Text, txtCorrelativo.Text, cboAseguramiento.Text, cboSituacion.Text, "", txtHistoria.Text, lblAPaterno.Text, lblAMaterno.Text, lblNombres.Text, lblSexo.Text, cboAtencion.Text, cboReferencia.Text, dtpFecha.Value.ToString.Substring(0, 10), txtHora.Text, Equipo, cboEspecialidad.Text, cboSubEspecialidad.Text, txtNroRef.Text, txtPeso.Text, txtTalla.Text, txtGestacion.Text, dtpFV.Value.ToString.Substring(0, 10), txtDNI.Text, cboGesPuer.Text, cboOxitocina.Text, cboVitaminaK.Text, cboProfilaxis.Text, UsuarioSistema, txtApgar1.Text, txtApgar5.Text, cboBCG.Text, cboHVB.Text, Bandera)
                If cboSubEspecialidad.Text = "UCI" Then
                    MontoUCI = InputBox("Ingresar Monto UCI", "Datos de SIS", 12000)
                    CodSis = objSIS.Autogenerado
                    objSIS.MontoUCI(CodSis, MontoUCI)
                End If
            Else
                objSIS.ModificarIngresoAP(CodSis, lblHEI.Text, cboLote.Text, txtNumero.Text, lblDISAHEI.Text, cboLoteA.Text, txtNumeroA.Text, txtCorrelativo.Text, cboAseguramiento.Text, cboSituacion.Text, "", txtHistoria.Text, lblAPaterno.Text, lblAMaterno.Text, lblNombres.Text, lblSexo.Text, cboAtencion.Text, cboReferencia.Text, dtpFecha.Value.ToString.Substring(0, 10), txtHora.Text, Equipo, cboEspecialidad.Text, cboSubEspecialidad.Text, txtNroRef.Text, txtPeso.Text, txtTalla.Text, txtGestacion.Text, dtpFV.Value.ToString.Substring(0, 10), txtDNI.Text, cboGesPuer.Text, cboOxitocina.Text, cboVitaminaK.Text, cboProfilaxis.Text, txtApgar1.Text, txtApgar5.Text, cboBCG.Text, cboHVB.Text, Bandera)
                If cboSubEspecialidad.Text = "UCI" Then
                    MontoUCI = InputBox("Ingresar Monto UCI", "Datos de SIS", 12000)
                    CodSis = objSIS.Autogenerado
                    objSIS.MontoUCI(CodSis, MontoUCI)
                End If
                If cboSubEspecialidad.Text = "UCI" Then
                    If MessageBox.Show("Desea Modificar Monto de UCI-SIS", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        MontoUCI = InputBox("Ingresar Monto UCI", "Datos de SIS", 12000)
                        objSIS.MontoUCI(CodSis, MontoUCI)
                    End If
                End If
            End If

            If Bandera = "G" Then
                txtIMC.Text = (Math.Round((Convert.ToDouble(txtPeso.Text) / 1000) / Math.Pow((Convert.ToDouble(txtTalla.Text) / 100), 2))).ToString("#0.00")
                If rbAteParV.Checked = True Then TipoParto = "PARTO VAGINAL"
                If rbCesarea.Checked = True Then TipoParto = "CESAREA"
                If idNeoNato > 0 Then
                    MessageBox.Show("Paciente Existe Como Recien Nacido, Desea Eliminar?", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    objSIS.EliminarNeoNato(idNeoNato)
                End If
                If idGestante > 0 Then
                    objSIS.ModificarGestante(idGestante, idPaciente, txtPeso.Text, txtTalla.Text, spSemanaG.Text, txtPresionA.Text, dtpFechaParto.Text, TipoParto)
                ElseIf idGestante = 0 Then
                    objSIS.GrabarGestante(idPaciente, txtPeso.Text, txtTalla.Text, spSemanaG.Text, txtPresionA.Text, dtpFechaParto.Text, TipoParto)

                End If
            ElseIf Bandera = "RN" Then
                If rbSano.Checked = True Then TipoRn = "SANO"
                If rbRNPro.Checked = True Then TipoRn = "INTERN. R.N"
                If idGestante > 0 Then
                    MessageBox.Show("Paciente Existe Como Gestante, Desea Eliminar?", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    objSIS.EliminarGestante(idGestante)

                End If
                If idNeoNato > 0 Then
                    objSIS.ModificarNeoNato(idNeoNato, idPaciente, Convert.ToInt32(txtPeso.Text), txtTalla.Text, Convert.ToInt32(txtGestacion.Text), txtApgar1.Text, txtApgar5.Text, chkVacBCG.Checked, chkVacHVB.Checked, chkProfOc.Checked, TipoRn)

                ElseIf idNeoNato = 0 Then
                    objSIS.GrabarNeoNato(idPaciente, Convert.ToInt32(txtPeso.Text), txtTalla.Text, Convert.ToInt32(txtGestacion.Text), txtApgar1.Text, txtApgar5.Text, chkVacBCG.Checked, chkVacHVB.Checked, chkProfOc.Checked, TipoRn)

                End If

            End If
            'Verificar Registro de Ficha
            Dim dsVer As New Data.DataSet
            dsVer = objSIS.Verificar(lblHEI.Text, cboLote.Text, txtNumero.Text)
            If dsVer.Tables(0).Rows.Count = 0 Then MessageBox.Show("Formato Unico de Atencion no se ha Registrado CORRECTAMENTE, Redigitelo Nuevamente!!!!", "Mensaje Critico", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

            'Registro de Pacientes en Emergencia
            If cboEspecialidad.Text = "EMERGENCIA" Then
                Dim dsVerIng As New DataSet
                dsVerIng = objIngreso.VerificarIngreso(txtHistoria.Text)
                If dsVerIng.Tables(0).Rows.Count > 0 Then
                    objIngreso.ActualizarFormatoSIS(dsVerIng.Tables(0).Rows(0)("IdIngreso"), cboLote.Text, txtNumero.Text)
                End If
            End If
            'Modificar datos del paciente
            objHistoria.CambiosSIS(txtHistoria.Text, lblAPaterno.Text, lblAMaterno.Text, lblNombres.Text, lblFecha.Text, txtDNI.Text)
            If MessageBox.Show("Desea Imprimir Formato de SIS", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.pdcDocumento.Print()
            End If
        End If
        btnCancelar_Click(sender, e)
    End Sub
    Private Sub btnBuscarH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarH.Click
        NumeroHistoria = ""
        frmBuscarHistoria.Show()
    End Sub
    Private Sub btnBuscarH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarH.GotFocus
        If NumeroHistoria.Length > 0 Then
            txtHistoria.Text = NumeroHistoria
            Dim temp As String
            Dim dsTabla As New Data.DataSet
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                temp = dsTabla.Tables(0).Rows(0)("idHistoria")
                idPaciente = Val(temp)
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                If (dsTabla.Tables(0).Rows(0)("FNacimiento")).ToString = "" Then lblFecha.Text = "" Else lblFecha.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FNacimiento"), 10)
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                cboAtencion.Select()
                Dim tp As String
                If Bandera = "G" Then
                    Dim dsTriaje As New DataSet
                    dsTriaje = objSIS.GestanteBuscar(idPaciente)
                    If dsTriaje.Tables(0).Rows.Count > 0 Then
                        tp = dsTriaje.Tables(0).Rows(0)("IdGestante")
                        idGestante = Val(tp)
                        txtPeso.Text = dsTriaje.Tables(0).Rows(0)("Peso")
                        txtTalla.Text = dsTriaje.Tables(0).Rows(0)("Talla")
                        txtGestacion.Text = dsTriaje.Tables(0).Rows(0)("EdadGestacional")
                        spSemanaG.Value = Val(txtGestacion.Text)
                        txtPresionA.Text = dsTriaje.Tables(0).Rows(0)("PresionArterial")
                        dtpFechaParto.Value = dsTriaje.Tables(0).Rows(0)("FechaParto")
                        If dtpFechaParto.Value > Now.Date Then
                            objSIS.EliminarGestante(idGestante)
                        End If
                    End If
                ElseIf Bandera = "RN" Then
                    Dim dsTriaje As New DataSet
                    dsTriaje = objSIS.NeoNatoBuscar(idPaciente)
                    If dsTriaje.Tables(0).Rows.Count > 0 Then
                        tp = dsTriaje.Tables(0).Rows(0)("IdNeoNato")
                        idNeoNato = Val(tp)
                        txtPeso.Text = dsTriaje.Tables(0).Rows(0)("Peso")
                        txtTalla.Text = dsTriaje.Tables(0).Rows(0)("Talla")
                        txtGestacion.Text = dsTriaje.Tables(0).Rows(0)("EdadGestacional")
                        txtApgar1.Text = dsTriaje.Tables(0).Rows(0)("Apgar1")
                        txtApgar5.Text = dsTriaje.Tables(0).Rows(0)("Apgar5")
                        chkVacBCG.Checked = dsTriaje.Tables(0).Rows(0)("VacunaBCG")
                        chkVacHVB.Checked = dsTriaje.Tables(0).Rows(0)("VacunaBCG")
                        chkProfOc.Checked = dsTriaje.Tables(0).Rows(0)("VacunaBCG")
                    End If
                ElseIf Bandera = "CMN" And (idNeoNato > 0 Or idGestante > 0) Then
                    objSIS.EliminarGestante(idGestante)
                    objSIS.EliminarNeoNato(idNeoNato)
                End If
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                txtHistoria.Select()
            End If
            NumeroHistoria = ""
        End If
    End Sub
    Private Sub cboEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter Then cboSubEspecialidad.Select()
    End Sub
    Private Sub cboEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged
        If IsNumeric(cboEspecialidad.SelectedValue) Then
            Dim dsSEsp As New Data.DataSet
            dsSEsp = objSubEspecialidad.Combo(cboEspecialidad.SelectedValue)
            cboSubEspecialidad.DataSource = dsSEsp.Tables(0)
            cboSubEspecialidad.DisplayMember = "Descripcion"
            cboSubEspecialidad.ValueMember = "IdEspecialidad"
            If cboGesPuer.SelectedIndex > 0 Then
                tbDetalle.TabPages(0).Enabled = True
                gbTriaje.Enabled = True
            End If
        End If
    End Sub
    Private Sub cboAseguramiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAseguramiento.KeyDown
        If e.KeyCode = Keys.Enter Then cboSituacion.Select()
    End Sub
    Private Sub cboSubEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And (Bandera = "RN" Or Bandera = "G") Then
            txtGestacion.Select()
        ElseIf e.KeyCode = Keys.Enter Then : dtpFecha.Select()
        End If
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.dtpFV.Value = Me.dtpFecha.Value.Date.AddMonths(2)
            txtHora.Select()
        End If
    End Sub

    Private Sub txtNroRef_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroRef.KeyDown
        If e.KeyCode = Keys.Enter Then txtContra.Select()
    End Sub

    Private Sub txtPeso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPeso.KeyDown
        If e.KeyCode = Keys.Enter Then txtTalla.Select()
    End Sub

    Private Sub txtTalla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTalla.KeyDown

        If Bandera = "G" And e.KeyCode = Keys.Enter Then
            txtPresionA.Select()
        ElseIf Bandera = "RN" And e.KeyCode = Keys.Enter Then
            txtApgar5.Select()
        End If
    End Sub
    Private Sub txtGestacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGestacion.KeyDown
        If e.KeyCode = Keys.Enter And (Bandera = "G" Or Bandera = "RN") Then
            spSemanaG.Value = Val(txtGestacion.Text)
            txtPeso.Select()
        End If
    End Sub
    Dim especialidad As String
    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas, index, x As Integer
        Filas = 0
        x = 50
        Y = 20
        Filas = 10
        Y = Y + 165
        With e.Graphics
            If cboEspecialidad.Text.Equals("HOSPITALIZACION") Then
                .DrawString("HOSPITALIZACION", Fuente, Pincel, 550, x)
                x += 20
            End If
            If cboEspecialidad.Text.Equals("EMERGENCIA") Then
                .DrawString("EMERGENCIA", Fuente, Pincel, 550, x)
                x += 20
            End If
            If cboSubEspecialidad.Text.Length > 20 Then
                Dim p As String()
                p = cboSubEspecialidad.Text.Split(delimitador)
                For index = 0 To p.Length - 1
                    If (p(index) <> "") Then
                        .DrawString(p(index), Fuente, Pincel, 550, x)
                        x += 20
                    End If
                Next
            Else
                .DrawString(cboSubEspecialidad.Text, Fuente, Pincel, 550, x)
            End If
            .DrawString("CODIGO EE.SS.", FuenteE, Pincel, 50, Y)
            .DrawString("ESTABLECIMIENTO" & StrDup(10, " ") & cboLote.Text & txtNumero.Text, FuenteE, Pincel, 400, Y)
            Y = Y + 20
            .DrawString("130101A102", Fuente, Pincel, 50, Y)
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", Fuente, Pincel, 240, Y)

            Y = Y + 40
            .DrawString("COD. INSCRIP/AFILIA:", FuenteE, Pincel, 40, Y)
            .DrawString(lblDISAHEI.Text & " " & cboLoteA.Text & "-" & txtNumeroA.Text, Fuente, Pincel, 260, Y)
            .DrawString("CORRELATIVO: ", FuenteE, Pincel, 440, Y)
            .DrawString(txtCorrelativo.Text, Fuente, Pincel, 570, Y)
            Y = Y + 20
            .DrawString("ASEGURAMIENTO:", FuenteE, Pincel, 40, Y)
            .DrawString(cboAseguramiento.Text, Fuente, Pincel, 260, Y)
            .DrawString("SITUACION: ", FuenteE, Pincel, 440, Y)
            .DrawString(cboSituacion.Text, Fuente, Pincel, 570, Y)
            Y = Y + 20
            .DrawString("APE PATERNO:", FuenteE, Pincel, 40, Y)
            .DrawString(lblAPaterno.Text, Fuente, Pincel, 260, Y)
            .DrawString("APE MATERNO: ", FuenteE, Pincel, 440, Y)
            .DrawString(lblAMaterno.Text, Fuente, Pincel, 570, Y)
            Y = Y + 20
            .DrawString("NOMBRES:", FuenteE, Pincel, 40, Y)
            If lblNombres.Text.Length > 14 Then
                .DrawString(lblNombres.Text.Remove(14, lblNombres.Text.Length - 14), Fuente, Pincel, 260, Y)
            Else
                .DrawString(lblNombres.Text, Fuente, Pincel, 260, Y)
            End If
            .DrawString("FEC NACTO: ", FuenteE, Pincel, 440, Y)
            If lblFecha.Text.Length > 10 Then
                .DrawString(lblFecha.Text.Remove(10, lblFecha.Text.Length - 10), Fuente, Pincel, 570, Y)
            Else
                .DrawString(lblFecha.Text, Fuente, Pincel, 570, Y)
            End If
            Y = Y + 20
            .DrawString("SEXO:", FuenteE, Pincel, 40, Y)
            .DrawString(lblSexo.Text, Fuente, Pincel, 260, Y)
            .DrawString("DNI: ", FuenteE, Pincel, 440, Y)
            .DrawString(txtDNI.Text, Fuente, Pincel, 570, Y)
            Y = Y + 20
            .DrawString("ATENCION:", FuenteE, Pincel, 40, Y)
            .DrawString(cboAtencion.Text, Fuente, Pincel, 260, Y)
            Y = Y + 20
            .DrawString("CENTRO DE SALUD:", FuenteE, Pincel, 40, Y)
            .DrawString(cboReferencia.Text, Fuente, Pincel, 260, Y)
            Y = Y + 20
            .DrawString("Nro HOJA REF:", FuenteE, Pincel, 40, Y)
            .DrawString(txtNroRef.Text, Fuente, Pincel, 260, Y)
            .DrawString("Nro HISTORIA: ", FuenteE, Pincel, 440, Y)
            .DrawString(txtHistoria.Text, Fuente, Pincel, 570, Y)
            Y = Y + 20
            .DrawString("FEC INGRES:", FuenteE, Pincel, 40, Y)
            .DrawString(dtpFecha.Value.ToShortDateString, Fuente, Pincel, 260, Y)
            .DrawString("HORA ATEN: ", FuenteE, Pincel, 440, Y)
            .DrawString(txtHora.Text, Fuente, Pincel, 590, Y)
            Y = Y + 20
            If Bandera = "RN" Then
                .DrawString("Peso R.N:", FuenteE, Pincel, 40, Y)
                If txtPeso.Text.Length > 0 Then
                    .DrawString(txtPeso.Text & " gr.", Fuente, Pincel, 260, Y)
                Else
                    .DrawString("", Fuente, Pincel, 260, Y)
                End If
                .DrawString("FecVtoContra: ", FuenteE, Pincel, 440, Y)
                .DrawString(dtpFV.Value.ToShortDateString, Fuente, Pincel, 570, Y)
                Y = Y + 20
                .DrawString("Talla R.N:", FuenteE, Pincel, 40, Y)
                If txtTalla.Text.Length > 0 Then
                    .DrawString(txtTalla.Text & " cm.", Fuente, Pincel, 260, Y)
                Else
                    .DrawString("", Fuente, Pincel, 260, Y)
                End If
                Y = Y + 20
                .DrawString("Adm Oxitoc: ", FuenteE, Pincel, 440, Y)
                .DrawString(cboOxitocina.Text, Fuente, Pincel, 570, Y)
                Y = Y + 20
                .DrawString("Apgar 1:", FuenteE, Pincel, 40, Y)
                .DrawString(txtApgar1.Text, Fuente, Pincel, 130, Y)
                .DrawString("Apgar 5: ", FuenteE, Pincel, 170, Y)
                .DrawString(txtApgar5.Text, Fuente, Pincel, 260, Y)
                .DrawString("Vitam. K: ", FuenteE, Pincel, 290, Y)
                .DrawString(VitK, Fuente, Pincel, 380, Y)
                .DrawString("Profi.Ocular: ", FuenteE, Pincel, 420, Y)
                .DrawString(Prof, Fuente, Pincel, 560, Y)
                .DrawString("BCG: ", FuenteE, Pincel, 660, Y)
                .DrawString(VacBCG, Fuente, Pincel, 700, Y)
                .DrawString("HVB: ", FuenteE, Pincel, 730, Y)
                .DrawString(VacHVB, Fuente, Pincel, 770, Y)
                Y = Y + 20
                .DrawString("Tipo AT", FuenteE, Pincel, 40, Y)
                .DrawString(TipoRn, Fuente, Pincel, 160, Y)

            ElseIf Bandera = "G" Then
                .DrawString("Peso Gestante:", FuenteE, Pincel, 40, Y)
                If txtPeso.Text.Length > 0 Then
                    .DrawString(txtPeso.Text & " gr.", Fuente, Pincel, 260, Y)
                Else
                    .DrawString("", Fuente, Pincel, 260, Y)
                End If
                .DrawString("FecVtoContra: ", FuenteE, Pincel, 440, Y)
                .DrawString(dtpFV.Value.ToShortDateString, Fuente, Pincel, 570, Y)
                Y = Y + 20
                .DrawString("Talla Gestante:", FuenteE, Pincel, 40, Y)
                If txtTalla.Text.Length > 0 Then
                    .DrawString(txtTalla.Text & " cm.", Fuente, Pincel, 260, Y)
                Else
                    .DrawString("", Fuente, Pincel, 260, Y)
                End If
                Y += 20
                .DrawString("PRESION ARTERIAL", FuenteE, Pincel, 40, Y)
                .DrawString(txtPresionA.Text, Fuente, Pincel, 260, Y)
                .DrawString("IMC", FuenteE, Pincel, 440, Y)
                .DrawString(txtIMC.Text, FuenteE, Pincel, 590, Y)
                Y += 20
                .DrawString("TIPO AT", FuenteE, Pincel, 40, Y)
                .DrawString(TipoParto, FuenteE, Pincel, 260, Y)
            Else
                .DrawString("FecVtoContra: ", FuenteE, Pincel, 440, Y)
                .DrawString(dtpFV.Value.ToShortDateString, Fuente, Pincel, 570, Y)
            End If
            Y = Y + 20
            .DrawString("Contra Ref:", FuenteE, Pincel, 40, Y)
            .DrawString(txtContra.Text, Fuente, Pincel, 260, Y)

            If cboAseguramiento.Text = "SEMISUBSIDIADO" Then
                Y = Y + 30
                .DrawString("SEMISUBSIDIADO", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "TRANSFUSION SANGUINEA" Then
                Y = Y + 30
                .DrawString("TRANSFUSION SANGUINEA", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "TOMOGRAFIA" Then
                Y = Y + 30
                .DrawString("TOMOGRAFIA", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "RESONANCIA MAGNETICA" Then
                Y = Y + 30
                .DrawString("RESONANCIA MAGNETICA", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "HEMODIALISIS" Then
                Y = Y + 30
                .DrawString("HEMODIALISIS", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "SEPELIO" Then
                Y = Y + 30
                .DrawString("SEPELIO", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "SURFACTANTE" Then
                Y = Y + 30
                .DrawString("SURFACTANTE", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "TRASLADO" Then
                Y = Y + 30
                .DrawString("TRASLADO", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "LECHE MATERNIZADA" Then
                Y = Y + 30
                .DrawString("LECHE MATERNIZADA", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "VALVULA DVP" Then
                Y = Y + 30
                .DrawString("VALVULA DVP", FuenteG, Pincel, 40, Y)
            ElseIf cboSubEspecialidad.Text = "RESONANCIA MAGNETICA" Then
                Y = Y + 30
                .DrawString("TRANSFUSION SANGUINEA", FuenteG, Pincel, 40, Y)
            ElseIf Bandera = "RN" Then
                Y = Y + 30
                .DrawString("RECIEN NACIDO", FuenteG, Pincel, 40, Y)
            End If
            Y = Y + 40
            .DrawString("Usuario: " & UsuarioSistema & StrDup(4, " ") & "Fecha Imp: " & Date.Now.ToShortTimeString, Fuente, Pincel, 40, Y)
        End With
    End Sub
    Private Sub txtDNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyDown
        If txtDNI.Text.Length > 0 And e.KeyCode = Keys.Enter Then cboGesPuer.Select()
    End Sub
    Private Sub cboGesPuer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboGesPuer.KeyDown
        If e.KeyCode = Keys.Enter Then cboAtencion.Select()
    End Sub

    Private Sub cboOxitocina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboProfilaxis.Select()
    End Sub

    Private Sub txtContra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContra.KeyDown
        If e.KeyCode = Keys.Enter Then txtEESS.Select()
    End Sub
    Private Sub dtpFV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFV.KeyDown
        If e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub lblDISAHEI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lblDISAHEI.KeyDown
        If e.KeyCode = Keys.Enter And lblDISAHEI.Text.Length > 0 Then cboLoteA.Select()
    End Sub
    Private Sub cboVitaminaK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboOxitocina.Select()
    End Sub
    Private Sub cboProfilaxis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboBCG.Select()
    End Sub
    Private Sub cboBCG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then cboHVB.Select()
    End Sub
    Private Sub cboHVB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtApgar1.Select()
    End Sub
    Private Sub txtApgar1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApgar1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpFecha.Select()
    End Sub
    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Me.dtpFV.Value = Me.dtpFecha.Value.Date.AddMonths(2)
    End Sub
    Private Sub cboGesPuer_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboGesPuer.SelectedIndexChanged
       


        If (cboGesPuer.SelectedIndex = 1) Then
            gbTriaje.Enabled = True
            Bandera = "G"
            tbDetalle.TabPages(1).Enabled = False
            tbDetalle.TabPages(0).Enabled = True
        ElseIf CStr(cboSubEspecialidad.Text.Contains("RECIEN NACIDO")) = True Or _
            CStr(cboEspecialidad.Text.Contains("RECIEN NACIDO")) = True Then
            gbTriaje.Enabled = True
            Bandera = "RN"
            tbDetalle.TabPages(1).Enabled = True
            tbDetalle.TabPages(0).Enabled = False

        ElseIf cboGesPuer.SelectedIndex = 2 Then
            gbTriaje.Enabled = True
            Bandera = "PRP"
            tbDetalle.TabPages(1).Enabled = False
            tbDetalle.TabPages(0).Enabled = True
        Else
            Bandera = "CMN"
            gbTriaje.Enabled = False
            tbDetalle.TabPages(0).Enabled = False
            tbDetalle.TabPages(1).Enabled = False
        End If


    End Sub
    Private Sub cboSubEspecialidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubEspecialidad.SelectedIndexChanged

        If CStr(cboSubEspecialidad.Text.Contains("RECIEN NACIDO")) = True Or _
            CStr(cboEspecialidad.Text.Contains("RECIEN NACIDO")) = True Then
            gbTriaje.Enabled = True
            cboGesPuer.SelectedIndex = 0
            Bandera = "RN"
            tbDetalle.TabPages(0).Enabled = False
            tbDetalle.TabPages(1).Enabled = True
            valNeoNato = True
        ElseIf cboGesPuer.SelectedIndex > 0 Then
            gbTriaje.Enabled = True
            tbDetalle.TabPages(0).Enabled = True
            tbDetalle.TabPages(1).Enabled = False
        Else
            Bandera = "CMN"
            gbTriaje.Enabled = False
            valNeoNato = False
            tbDetalle.TabPages(0).Enabled = False
            tbDetalle.TabPages(1).Enabled = False
        End If

    End Sub
    Private Sub txtParametro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParametro.KeyDown
        If e.KeyCode = Keys.Enter Then
            dsGeneral = objSIS.CentroSaludListar(txtParametro.Text.Trim())
            dgvFiltro.DataSource = dsGeneral.Tables(0)
            dgvFiltro.Columns(0).Visible = False
            dgvFiltro.Columns(1).Width = 400
        End If
        If e.KeyCode = Keys.Enter And dgvFiltro.RowCount > 0 Then
            dgvFiltro.Select()
        End If
        If e.KeyCode = Keys.Escape Then
            gbBusqueda.Visible = False
        End If
    End Sub
    Private Sub dgvFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            EESS = dgvFiltro.CurrentRow.Cells(1).Value.ToString()
            txtEESS.Text = EESS
            gbBusqueda.Visible = False
            txtEESS.Select()
        End If
        If e.KeyCode = Keys.Escape Then
            gbBusqueda.Visible = False
        End If
    End Sub
    Private Sub txtEESS_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEESS.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboEspecialidad.Select()
        Else
            txtParametro.Text = Chr(e.KeyValue)
            gbBusqueda.Visible = True
            txtParametro.Focus()
            txtParametro.SelectionStart = txtParametro.TextLength
        End If
    End Sub
    Private Sub spSemanaG_ValueChanged(sender As Object, e As EventArgs) Handles spSemanaG.ValueChanged
        dtpFechaParto.Value = DateAdd(DateInterval.WeekOfYear, (40 - spSemanaG.Value), Now.Date)
        txtGestacion.Text = spSemanaG.Value.ToString
    End Sub
    Private Sub chkProfOc_CheckedChanged(sender As Object, e As EventArgs) Handles chkProfOc.CheckedChanged
        If chkProfOc.Checked = True Then
            Prof = "SI"
        Else
            Prof = "NO"
        End If
    End Sub
    Private Sub chkVitK_CheckedChanged(sender As Object, e As EventArgs) Handles chkVitK.CheckedChanged
        If chkVitK.Checked = True Then
            VitK = "SI"
        Else
            VitK = "NO"
        End If
    End Sub
    Private Sub chkVacHVB_CheckedChanged(sender As Object, e As EventArgs) Handles chkVacHVB.CheckedChanged
        If chkVacHVB.Checked = True Then
            VacHVB = "SI"
        Else
            VacHVB = "NO"
        End If
    End Sub
    Private Sub chkVacBCG_CheckedChanged(sender As Object, e As EventArgs) Handles chkVacBCG.CheckedChanged
        If chkVacBCG.Checked = True Then
            VacBCG = "SI"
        Else
            VacBCG = "NO"
        End If
    End Sub
    Private Sub txtPresionA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPresionA.KeyDown
        If e.KeyCode = Keys.Enter Then dtpFecha.Select()

    End Sub

    Private Sub txtApgar5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApgar5.KeyDown
        If e.KeyCode = Keys.Enter Then txtApgar1.Select()

    End Sub
    Private Sub cboOxitocina_KeyDown(sender As Object, e As EventArgs) Handles cboOxitocina.DropDown
        txtApgar5.Select()
    End Sub

    Private Sub txtNumeroA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroA.KeyDown
        If e.KeyCode = Keys.F7 Then
            frmBuscarSIS.Show()
        End If

    End Sub


    Private Sub txtPeso_LostFocus(sender As Object, e As EventArgs) Handles txtPeso.LostFocus
        txtPeso.Text = txtPeso.Text.Trim
    End Sub
End Class
