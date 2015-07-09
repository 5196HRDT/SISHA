Public Class frmCuentaPaciente
    Dim objIngreso As New clsEmergenciaIngreso
    Dim objConsulta As New clsEmergenciaIngreso_Consulta
    Dim objEstadoCivil As New clsEstadoCivil
    Dim objHistoria As New clsHistoria
    Dim objDetalleSer As New clsEmergenciaSer
    Dim objServicioItem As New clsServicioItem
    Dim objSoat As New clsSOAT
    Dim objSIS As New clsSIS
    Dim objConvenio As New clsConvenio

    Dim CodigoIngreso As String
    Dim Tipo As String

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
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            dtpFechaNcto.Value = dsHistorias.Tables(0).Rows(0)("FNacimiento")
            CalcularEdad(dtpFecha.Value, dtpFechaNcto.Value)

            lblGrado.Text = dsHistorias.Tables(0).Rows(0)("GradoInstruccion").ToString

            'Estado Civil
            dsEC = objEstadoCivil.DameDes(Val(dsHistorias.Tables(0).Rows(0)("EstadoCivil").ToString))
            If dsEC.Tables(0).Rows.Count > 0 Then
                lblEstadoCivil.Text = dsEC.Tables(0).Rows(0)("Descripcion")
            Else
                lblEstadoCivil.Text = "NINGUNO"
            End If

            lblGrado.Text = dsHistorias.Tables(0).Rows(0)("GradoInstruccion").ToString
            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
            lblDomicilio.Text = dsHistorias.Tables(0).Rows(0)("Direccion").ToString
            lblDpto.Text = dsHistorias.Tables(0).Rows(0)("Departamento").ToString
            lblProvincia.Text = dsHistorias.Tables(0).Rows(0)("Provincia").ToString
            lblDistrito.Text = dsHistorias.Tables(0).Rows(0)("Distrito").ToString
            dtpFechaNcto.Select()
            btnGrabar.Enabled = True
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub LlenarProcedimientos()
        Dim dsVer As New DataSet
        'Verificar Procedimientos Solicitados
        lvTabla.Items.Clear()
        lvTablaA.Items.Clear()
        dsVer = objDetalleSer.BuscarTodo(CodigoIngreso)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#,##0.00"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                If dsVer.Tables(0).Rows(I)("PrecioReal").ToString = "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Format(CDbl(dsVer.Tables(0).Rows(I)("Precio")), "#,##0.00")) Else Fila.SubItems.Add(Microsoft.VisualBasic.Format(CDbl(dsVer.Tables(0).Rows(I)("PrecioReal")), "#,##0.00"))
                Dim Importe As String
                If dsVer.Tables(0).Rows(I)("PrecioReal").ToString = "" Then Importe = Val(dsVer.Tables(0).Rows(I)("Cantidad")) * Val(dsVer.Tables(0).Rows(I)("Precio")) Else Importe = Val(dsVer.Tables(0).Rows(I)("Cantidad")) * Val(dsVer.Tables(0).Rows(I)("PrecioReal"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(CDbl(Importe), "#,##0.00"))

                Fila.SubItems.Add("NO")
                If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Else
                Fila = lvTablaA.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#,##0.00"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                If dsVer.Tables(0).Rows(I)("PrecioReal").ToString = "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Format(CDbl(dsVer.Tables(0).Rows(I)("Precio")), "#,##0.00")) Else Fila.SubItems.Add(Microsoft.VisualBasic.Format(CDbl(dsVer.Tables(0).Rows(I)("PrecioReal")), "#,##0.00"))
                Dim Importe As String
                If dsVer.Tables(0).Rows(I)("PrecioReal").ToString = "" Then Importe = Val(dsVer.Tables(0).Rows(I)("Cantidad")) * Val(dsVer.Tables(0).Rows(I)("Precio")) Else Importe = Val(dsVer.Tables(0).Rows(I)("Cantidad")) * Val(dsVer.Tables(0).Rows(I)("PrecioReal"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(CDbl(Importe), "#,##0.00"))
                Fila.SubItems.Add("SI")
                If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            End If
        Next
        Total()
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            lblSerieSIS.Text = ""
            lblNumeroSIS.Text = ""
            lblPreliquidacion.Text = ""
            BuscarHistoria()
            Dim dsVer As New DataSet
            dsVer = objIngreso.VerificarIngreso(txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                CodigoIngreso = dsVer.Tables(0).Rows(0)("IdIngreso")
                lblServicio.Text = dsVer.Tables(0).Rows(0)("Especialidad")
                lblMedico.Text = dsVer.Tables(0).Rows(0)("Medico")
                dtpFecha.Value = dsVer.Tables(0).Rows(0)("FechaIngreso")
                txtHora.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblFechaAdmision.Text = dsVer.Tables(0).Rows(0)("FechaIngreso")
                lblHoraAdmision.Text = dsVer.Tables(0).Rows(0)("HoraIngreso")
                lblInformante.Text = dsVer.Tables(0).Rows(0)("Conyuge")
                lblTipoAtencion.Text = dsVer.Tables(0).Rows(0)("TipoAtencion").ToString
                If dsVer.Tables(0).Rows(0)("TipoAtencion").ToString = "SIS" Then
                    lblSerieSIS.Text = dsVer.Tables(0).Rows(0)("SerieSIS").ToString
                    lblNumeroSIS.Text = dsVer.Tables(0).Rows(0)("NumeroSIS").ToString
                ElseIf dsVer.Tables(0).Rows(0)("TipoAtencion").ToString = "SOAT/AFOCAT" Then
                    lblPreliquidacion.Text = dsVer.Tables(0).Rows(0)("Preliquidacion").ToString
                ElseIf lblTipoAtencion.Text = "CAJA DE PROTECCION" Or lblTipoAtencion.Text = "INPE" Or lblTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or lblTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                    lblPreliquidacion.Text = dsVer.Tables(0).Rows(0)("Preliquidacion").ToString
                Else
                    lblSerieSIS.Text = ""
                    lblNumeroSIS.Text = ""
                    lblPreliquidacion.Text = ""
                End If
                Dim dsConsulta As New DataSet
                dsConsulta = objConsulta.ConsultaBuscar(CodigoIngreso)
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    dtpFecha.Value = dsConsulta.Tables(0).Rows(0)("Fecha")
                    txtHora.Text = dsConsulta.Tables(0).Rows(0)("Hora")
                End If
                LlenarProcedimientos()
                
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        dtpFecha.Value = Date.Now
        Botones(True, False, False, True)
        btnBuscarP.Enabled = False
        ControlesAD(Me, False)
        Limpiar(Me)
        gbAD.Visible = False
        gbSI.Visible = False
    End Sub

    Private Sub frmCuentaPaciente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        dtpFecha.Value = Date.Now
        txtHora.Text = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        btnBuscarP.Enabled = True
        dtpFecha.Select()
    End Sub

    Private Sub LaboratorioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LaboratorioToolStripMenuItem.Click
        lvTablaP.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "LABORATORIO"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False

        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If lblTipoAtencion.Text <> "COMUN" Then
                Fila.SubItems.Add("SI")
            Else
                If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                    Fila.SubItems.Add("NO")
                Else
                    Fila.SubItems.Add("SI")
                End If
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
        LlenarProcedimientos()
    End Sub

    Private Sub RayosXToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RayosXToolStripMenuItem.Click
        lvTablaP.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "RADIOGRAFIA"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False

        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If lblTipoAtencion.Text <> "COMUN" Then
                Fila.SubItems.Add("SI")
            Else
                If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                    Fila.SubItems.Add("NO")
                Else
                    Fila.SubItems.Add("SI")
                End If
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
        LlenarProcedimientos()
    End Sub

    Private Sub EcografíaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EcografíaToolStripMenuItem.Click
        lvTablaP.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "ECOGRAFIA"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False

        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If lblTipoAtencion.Text <> "COMUN" Then
                Fila.SubItems.Add("SI")
            Else
                If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                    Fila.SubItems.Add("NO")
                Else
                    Fila.SubItems.Add("SI")
                End If
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
        LlenarProcedimientos()
    End Sub

    Private Sub PatologíaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PatologíaToolStripMenuItem.Click
        lvTablaP.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "PATOLOGIA"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False

        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If lblTipoAtencion.Text <> "COMUN" Then
                Fila.SubItems.Add("SI")
            Else
                If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                    Fila.SubItems.Add("NO")
                Else
                    Fila.SubItems.Add("SI")
                End If
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
        LlenarProcedimientos()
    End Sub

    Private Sub OtrosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OtrosToolStripMenuItem.Click
        lvTablaP.Items.Clear()
        lvSolicitado.Items.Clear()
        Tipo = "ENFERMERIA"
        gbAD.Visible = True
        lvTabla.Items.Clear()
        txtProcedimiento.Select()
        btnPendiente.Enabled = False

        'Verificar Procedimientos Solicitados
        lvSolicitado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarTipo(CodigoIngreso, Tipo)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSolicitado.Items.Add(dsVer.Tables(0).Rows(I)("IdServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            If dsVer.Tables(0).Rows(I)("FecCan").ToString = "" Then
                Fila.SubItems.Add("NO")
            Else
                Fila.SubItems.Add("SI")
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado").ToString)
            If dsVer.Tables(0).Rows(I)("FechaPendiente").ToString <> "" Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
        LlenarProcedimientos()
    End Sub

    Private Sub btnRetornarSI_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarSI.Click
        txtDescripcion.Text = ""
        gbSI.Visible = False
    End Sub

    Private Sub btnRetornarAD_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarAD.Click
        gbAD.Visible = False
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
                dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "COMUN")
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                Next
            End If

            'Procedimientos de Paciente SIS
            If lblTipoAtencion.Text = "SIS" Then
                If chkPagoContado.Checked Then
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "COMUN")
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                Else
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "SIS")
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                End If
            End If

            'Procedimientos de Paciente SOAT
            If lblTipoAtencion.Text = "SOAT/AFOCAT" Then
                If chkPagoContado.Checked Then
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "COMUN")
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                Else
                    dsVer = objSoat.BuscarDes(txtDescripcion.Text, Tipo)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdTarifario"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
                    Next
                End If

            End If

            'Procedimientos de Paciente Convenio
            If lblTipoAtencion.Text = "CAJA DE PROTECCION" Or lblTipoAtencion.Text = "INPE" Or lblTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or lblTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                If chkPagoContado.Checked Then
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, "COMUN")
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                Else
                    dsVer = objServicioItem.BuscarEmergencia(txtDescripcion.Text, Tipo, lblTipoAtencion.Text)
                    For I = 0 To dsVer.Tables(0).Rows.Count - 1
                        Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
                        Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                        Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Next
                End If

            End If
        End If
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
            lblTipo.Text = lvSI.SelectedItems(0).SubItems(3).Text
            lblTipo.Tag = lvSI.SelectedItems(0).SubItems(4).Text
            txtCantidad.Select()
            btnRetornarSI_Click(sender, e)

        End If
    End Sub

    Private Sub lvSI_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvSI.SelectedIndexChanged

    End Sub

    Private Sub lvTablaP_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTablaP.KeyDown
        If e.KeyCode = Keys.Delete And lvTablaP.SelectedItems.Count > 0 Then
            lvTablaP.Items.RemoveAt(lvTablaP.SelectedItems(0).Index)
            Total()
        End If
    End Sub

    Private Sub lvTablaP_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTablaP.SelectedIndexChanged

    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If txtProcedimiento.Text <> "" And IsNumeric(txtCantidad.Text) And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvTablaP.Items.Add(txtProcedimiento.Tag)
            If lblTipoAtencion.Text = "SIS" And txtProcedimiento.Text = "OXIGENOTERAPIA" Then txtCantidad.Text = Val(txtCantidad.Text) * 300
            Fila.SubItems.Add(txtCantidad.Text)
            Fila.SubItems.Add(txtProcedimiento.Text)
            Fila.SubItems.Add(lblPrecio.Text)
            Fila.SubItems.Add(Val(lblPrecio.Text) * Val(txtCantidad.Text))
            Fila.SubItems.Add(lblTipo.Text)
            Fila.SubItems.Add(lblTipo.Tag)
            txtProcedimiento.Tag = ""
            txtProcedimiento.Text = ""
            txtCantidad.Text = ""
            lblPrecio.Text = ""
            lblTipo.Tag = ""
            lblTipo.Text = ""
            txtProcedimiento.Select()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("Esta seguro de Grabar Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            Dim CodigoSIS As String
            Dim CodigoSoat As String
            Dim CodigoConvenio As String
            Dim Fecha As String
            Dim Hora As String

            'Verificar Tipo de Paciente para obtener Codigos
            If lblTipoAtencion.Text = "SIS" Then
                Dim dsSIS As New DataSet
                dsSIS = objSIS.ConsultarLN(lblSerieSIS.Text, lblNumeroSIS.Text, txtHistoria.Text)
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
                dsSoat = objSoat.BuscarPH(lblPreliquidacion.Text, txtHistoria.Text)
                CodigoSoat = dsSoat.Tables(0).Rows(0)("IdSoat")

                If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If

            'Verificar Tipo de Paciente para obtener Codigos
            If lblTipoAtencion.Text = "CAJA DE PROTECCION" Or lblTipoAtencion.Text = "INPE" Or lblTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or lblTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                Dim dsConvenio As New DataSet
                dsConvenio = objConvenio.BuscarCH(lblPreliquidacion.Text, txtHistoria.Text)
                CodigoConvenio = dsConvenio.Tables(0).Rows(0)("IdConvenio")

                If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then MessageBox.Show("Atencion de Convenio ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If

            'Registrar detalle de Procedimientos
            For I = 0 To lvTablaP.Items.Count - 1
                Fecha = Date.Now.ToShortDateString
                Hora = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
                'Paciente Comun
                If lblTipoAtencion.Text = "COMUN" Then
                    objDetalleSer.GrabarContado(CodigoIngreso, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, lvTablaP.Items(I).SubItems(5).Text, Fecha, Hora, UsuarioSistema, lvTablaP.Items(I).SubItems(6).Text)
                End If

                'Paciente SIS
                If lblTipoAtencion.Text = "SIS" Then
                    If chkPagoContado.Checked Then
                        objDetalleSer.GrabarContado(CodigoIngreso, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, lvTablaP.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTablaP.Items(I).SubItems(6).Text)
                    Else
                        objSIS.GrabarProcedimientosN(CodigoSIS, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, lvTablaP.Items(I).SubItems(4).Text, NomMedico, My.Computer.Name, Fecha, Hora)
                        objDetalleSer.GrabarConvenio(CodigoIngreso, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, vIdMedico, UsuarioSistema, lvTablaP.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTablaP.Items(I).SubItems(6).Text)
                    End If
                End If

                'Paciente Soat
                If lblTipoAtencion.Text = "SOAT/AFOCAT" Then
                    If chkPagoContado.Checked Then
                        objDetalleSer.GrabarContado(CodigoIngreso, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, lvTablaP.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTablaP.Items(I).SubItems(6).Text)
                    Else
                        objSoat.GrabarDetalle(CodigoSoat, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, lvTablaP.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, 3, "  /  /", Fecha, Hora, UsuarioSistema, My.Computer.Name)
                        objDetalleSer.GrabarConvenio(CodigoIngreso, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, vIdMedico, NomMedico, lvTablaP.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTablaP.Items(I).SubItems(6).Text)
                    End If
                End If

                'Pacientes Convenio
                If lblTipoAtencion.Text = "CAJA DE PROTECCION" Or lblTipoAtencion.Text = "INPE" Or lblTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or lblTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                    If chkPagoContado.Checked Then
                        objDetalleSer.GrabarContado(CodigoIngreso, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, lvTablaP.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTablaP.Items(I).SubItems(6).Text)
                    Else
                        objConvenio.GrabarProcedimientos(CodigoConvenio, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, lvTablaP.Items(I).SubItems(4).Text, Fecha, Hora, UsuarioSistema, My.Computer.Name, Date.Now.ToShortDateString, "  /  /")
                        objDetalleSer.GrabarConvenio(CodigoIngreso, lvTablaP.Items(I).SubItems(0).Text, lvTablaP.Items(I).SubItems(2).Text, lvTablaP.Items(I).SubItems(3).Text, lvTablaP.Items(I).SubItems(1).Text, "1", Fecha, Hora, UsuarioSistema, My.Computer.Name, vIdMedico, NomMedico, lvTablaP.Items(I).SubItems(5).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, lvTablaP.Items(I).SubItems(6).Text)
                    End If
                End If
            Next
            btnRetornarAD_Click(sender, e)
            LlenarProcedimientos()
        End If
    End Sub

    Private Sub txtProcedimiento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProcedimiento.TextChanged
        If txtProcedimiento.Text <> "" And txtProcedimiento.Enabled Then txtDescripcion.Text = txtProcedimiento.Text : txtDescripcion.SelectionStart = txtDescripcion.Text.Length : gbSI.Visible = True : txtDescripcion.Select()
    End Sub

    Private Sub lvSolicitado_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvSolicitado.KeyDown
        If e.KeyCode = Keys.Delete And lvSolicitado.SelectedItems.Count > 0 Then
            If lvSolicitado.SelectedItems(0).SubItems(4).Text <> "" Then MessageBox.Show("Procedimiento no puede ser eliminado por tener asignado un resultado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If MessageBox.Show("Esta seguro de Eliminar Procedimiento?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'Verificar Tipo de Paciente para obtener Codigos
                If lblTipoAtencion.Text = "SIS" Then
                    Dim CodigoSIS As String
                    Dim dsSIS As New DataSet
                    dsSIS = objSIS.ConsultarLN(lblSerieSIS.Text, lblNumeroSIS.Text, txtHistoria.Text)
                    CodigoSIS = dsSIS.Tables(0).Rows(0)("IdSis")

                    If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                        If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                    End If
                    If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                        MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                    End If

                    If lvSolicitado.SelectedItems(0).SubItems(6).Text <> "" Then objSIS.EliminarEmergencia(CodigoSIS, lvSolicitado.SelectedItems(0).SubItems(0).Text, lvSolicitado.SelectedItems(0).SubItems(6).Text, lvSolicitado.SelectedItems(0).SubItems(7).Text)
                End If

                'Verificar Tipo de Paciente para obtener Codigos
                Dim CodigoSoat As String
                If lblTipoAtencion.Text = "SOAT/AFOCAT" Then
                    Dim dsSoat As New DataSet
                    dsSoat = objSoat.BuscarPH(lblPreliquidacion.Text, txtHistoria.Text)
                    CodigoSoat = dsSoat.Tables(0).Rows(0)("IdSoat")

                    If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                    objSoat.EliminarEmergencia(CodigoSoat, lvSolicitado.SelectedItems(0).Text, lvSolicitado.SelectedItems(0).SubItems(6).Text, lvSolicitado.SelectedItems(0).SubItems(7).Text)
                End If

                'Verificar Tipo de Paciente para obtener Codigos
                Dim CodigoConvenio As String
                If lblTipoAtencion.Text = "CAJA DE PROTECCION" Or lblTipoAtencion.Text = "INPE" Or lblTipoAtencion.Text = "JUNTA DE ADMINISTRACION REGIONAL-FOSPOLI" Or lblTipoAtencion.Text = "MARINA DE GUERRA DEL PERU" Then
                    Dim dsConvenio As New DataSet
                    dsConvenio = objConvenio.BuscarCH(lblPreliquidacion.Text, txtHistoria.Text)
                    CodigoConvenio = dsConvenio.Tables(0).Rows(0)("IdConvenio")

                    If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then MessageBox.Show("Atencion de Convenio ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                    objConvenio.EliminarEmergencia(CodigoConvenio, lvSolicitado.SelectedItems(0).SubItems(0).Text, lvSolicitado.SelectedItems(0).SubItems(6).Text, lvSolicitado.SelectedItems(0).SubItems(7).Text)
                End If


                objDetalleSer.Eliminar(lvSolicitado.SelectedItems(0).SubItems(5).Text)
                lvSolicitado.Items.RemoveAt(lvSolicitado.SelectedItems(0).Index)
                Total()
            End If
        End If
    End Sub

    Private Sub lvSolicitado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvSolicitado.SelectedIndexChanged

    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            Dim Motivo As String
            Motivo = InputBox("Ingresar Motivo de Anulación", "Datos de Anulación")
            If Motivo = "" Then MessageBox.Show("Debe ingresar un motivo de anulación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            objDetalleSer.AnularProcedimientosDet(lvTabla.SelectedItems(0).SubItems(7).Text, Date.Now.ToShortDateString, Format(Date.Now, "HH:MM"), UsuarioSistema, Motivo)
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub lvTablaA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTablaA.SelectedIndexChanged

    End Sub
End Class