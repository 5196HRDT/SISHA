Public Class frmConsultorioExterno
    Dim objCategorizacion As New clsCategorizacion
    Dim objHistoria As New clsHistoria
    Dim objConsulta As New clsConsulta
    Dim objTarifario As New clsTarifario
    Dim objServicio As New clsServicio
    Dim objSubServicio As New clsSubServicio

    Private Sub Botones(Nuevo As Boolean, Grabar As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Total()
        Dim I As Integer
        lblTotal.Text = "0.00"
        For I = 0 To lvTabla.Items.Count - 1
            lblTotal.Text = Val(lblTotal.Text) + Val(lvTabla.Items(I).SubItems(4).Text)
        Next
        lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#,##0.00")
    End Sub

    Private Sub CalcularPago(Tipo As String)
        Dim I As Integer
        Dim PDescuento As Integer
        If Tipo = "MONTO" Then
            'Calcular Porcentaje
            txtPorcentaje.Text = 100 - Math.Round((Val(txtMonto.Text) * 100) / Val(lblTotal.Text), 0)
        End If
        txtMonto.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) - Math.Round(Val(txtPorcentaje.Text) * Val(lblTotal.Text) / 100, 1), "#,##0.00")
        PDescuento = 100 - Val(txtPorcentaje.Text)
        Dim Redondeo As Double = 0
        Dim TotalNP As Double = 0
        For I = 0 To lvTabla.Items.Count - 1
            lvTabla.Items(I).SubItems(6).Text = Microsoft.VisualBasic.Format(Math.Round(Val(lvTabla.Items(I).SubItems(3).Text) * Val(PDescuento) / 100, 1), "#,##0.00")
            TotalNP = TotalNP + Val(lvTabla.Items(I).SubItems(6).Text)
        Next
        'Redondeo
        Redondeo = Val(txtMonto.Text) - TotalNP
        If Redondeo <> 0 Then lvTabla.Items(lvTabla.Items.Count - 1).SubItems(6).Text = Microsoft.VisualBasic.Format(Val(lvTabla.Items(lvTabla.Items.Count - 1).SubItems(6).Text) + Redondeo, "#,##0.00")
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
        If Val(EdadA) > 0 Then
            lblEdad.Text = EdadA & " A"
        ElseIf Val(EdadM) > 0 Then
            lblEdad.Text = EdadM & " M"
        Else
            lblEdad.Text = EdadD & " D"
        End If
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            lblFNac.Text = dsHistorias.Tables(0).Rows(0)("FNacimiento")
            CalcularEdad(Date.Now.ToShortDateString, lblFNac.Text)

            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            If txtHistoria.Text = "" Then Exit Sub
        End If

        'Buscar Examenes Pendientes de pago
        Dim dsVer As New DataSet
        dsVer = objConsulta.ExamenesPendientesPago(txtHistoria.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim Importe As String = ""
        lvTabla.Items.Clear()
        If dsVer.Tables(0).Rows.Count > 0 Then
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("PrecioReal")), "#,##0.00"))
                Importe = Val(dsVer.Tables(0).Rows(I)("Cantidad")) * Val(dsVer.Tables(0).Rows(I)("PrecioReal"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(Importe), "#,##0.00"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdExamen"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("PrecioReal")), "#,##0.00"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("PrecioReal")), "#,##0.00"))
            Next
            'Definir Servicio
            Dim dsS As New DataSet
            Dim dsSS As New DataSet
            dsSS = objSubServicio.BuscarDptoEspecialidadEsp(dsVer.Tables(0).Rows(0)("ServicioCE"))
            If dsSS.Tables(0).Rows.Count > 0 Then
                dsS = objServicio.BuscarDptoEspecialidadId(dsSS.Tables(0).Rows(0)(3))
                If dsS.Tables(0).Rows.Count > 0 Then
                    cboServicio.Text = dsS.Tables(0).Rows(0)("Descripcion")
                    cboServicio_SelectedIndexChanged(sender, e)
                    cboSubServicio.Text = dsVer.Tables(0).Rows(0)("ServicioCE")
                End If
            End If
        End If
        Total()
        If txtHistoria.Text <> "" And e.KeyCode = Keys.Enter Then
            txtCantidad.Text = "1"
            txtCantidad.Select()
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub frmConsultorioExterno_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        gbPaciente.Visible = False
        gbSI.Visible = False
        btnCancelar_Click(sender, e)

        'Servicio
        Dim dsServicio As New DataSet
        dsServicio = objServicio.BuscarDptoEspecialidadDes("%")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdDpto"
    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = False
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

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
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
        If e.KeyCode = Keys.Enter And IsNumeric(txtCantidad.Text) Then txtProcedimiento.Select()
    End Sub

    Private Sub txtCantidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If lvSI.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvSI.Select()
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        Dim dsVer As New DataSet
        Dim I As Integer
        Dim Fila As ListViewItem
        gbSI.Visible = True
        lvSI.Items.Clear()
        dsVer = objTarifario.BuscarTarifarioComun(txtDescripcion.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvSI.Items.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Procedimiento"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Precio")), "#, ##0.00"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
        Next
    End Sub

    Private Sub txtProcedimiento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProcedimiento.TextChanged
        If txtProcedimiento.Text <> "" And txtProcedimiento.Enabled Then txtDescripcion.Text = txtProcedimiento.Text : txtDescripcion.SelectionStart = txtDescripcion.Text.Length : gbSI.Visible = True : txtDescripcion.Select()
    End Sub

    Private Sub btnRetornarSI_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarSI.Click
        gbSI.Visible = False
    End Sub

    Private Function Verificar() As Boolean
        Verificar = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(5).Text = lvSI.SelectedItems(0).SubItems(0).Text Then Verificar = True : Exit For
        Next
    End Function

    Private Sub lvSI_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvSI.KeyDown
        If e.KeyCode = Keys.Enter And lvSI.SelectedItems.Count > 0 Then
            If Verificar() Then MessageBox.Show("Procedimiento ya fue asigando a la lista", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            txtCantidad.Text = "1"
            txtCantidad.Select()
            btnRetornarSI_Click(sender, e)

            Dim Fila As ListViewItem
            Dim Importe As String = ""
            Fila = lvTabla.Items.Add("0")
            Fila.SubItems.Add(txtCantidad.Text)
            Fila.SubItems.Add(lvSI.SelectedItems(0).SubItems(1).Text)
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(lvSI.SelectedItems(0).SubItems(2).Text), "#,##0.00"))
            Importe = Val(txtCantidad.Text) * Val(lvSI.SelectedItems(0).SubItems(2).Text)
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(Importe), "#,##0.00"))
            Fila.SubItems.Add(lvSI.SelectedItems(0).SubItems(0).Text)
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(lvSI.SelectedItems(0).SubItems(2).Text), "#,##0.00"))
            Fila.SubItems.Add(lvSI.SelectedItems(0).SubItems(3).Text)
            Fila.SubItems.Add(lvSI.SelectedItems(0).SubItems(4).Text)
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(lvSI.SelectedItems(0).SubItems(2).Text), "#,##0.00"))
            txtProcedimiento.Enabled = False
            txtProcedimiento.Text = ""
            txtProcedimiento.Enabled = True
            Total()
        End If
    End Sub

    Private Sub lvSI_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvSI.SelectedIndexChanged

    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
            Total()
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub txtMonto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
        If Val(txtMonto.Text) > 0 And e.KeyCode = Keys.Enter Then CalcularPago("MONTO")
    End Sub

    Private Sub txtMonto_Layout(sender As Object, e As System.Windows.Forms.LayoutEventArgs) Handles txtMonto.Layout
        If Val(txtMonto.Text) > 0 Then CalcularPago("MONTO")
    End Sub

    Private Sub txtMonto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMonto.TextChanged

    End Sub

    Private Sub txtPorcentaje_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPorcentaje.KeyDown
        If Val(txtPorcentaje.Text) > 0 And e.KeyCode = Keys.Enter Then CalcularPago("PORCENTAJE")
    End Sub

    Private Sub txtPorcentaje_LostFocus(sender As Object, e As System.EventArgs) Handles txtPorcentaje.LostFocus
        If Val(txtPorcentaje.Text) > 0 Then CalcularPago("PORCENTAJE")
    End Sub

    Private Sub txtPorcentaje_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPorcentaje.TextChanged

    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        lvTabla.Items.Clear()
        btnEliminar.Enabled = False
        btnBuscarP.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        txtHistoria.Select()
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de grabar categorización de Paciente?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim IdCCE As String
            IdCCE = objCategorizacion.Grabar(txtHistoria.Text, Date.Now.ToShortDateString, UsuarioSistema, lblTotal.Text, txtMonto.Text, Val(lblTotal.Text) - Val(txtMonto.Text), -1, "A", "CONSULTA EXTERNA", My.Computer.Name)

            Dim I As Integer
            Dim Importe As Double
            For I = 0 To lvTabla.Items.Count - 1
                objCategorizacion.GrabarDetalle(IdCCE, lvTabla.Items(I).SubItems(5).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(3).Text, "1", "1", lvTabla.Items(I).SubItems(5).Text)

                'Grabar Precio Categorizado
                If lvTabla.Items(I).SubItems(0).Text <> 0 Then
                    Importe = CDbl(lvTabla.Items(I).SubItems(1).Text) * CDbl(lvTabla.Items(I).SubItems(6).Text)
                    objConsulta.CategorizarPrecio(lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(6).Text, Importe)
                Else
                    objConsulta.GrabarExamenesPR(0, lvTabla.Items(I).SubItems(5).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(6).Text, lvTabla.Items(I).SubItems(1).Text, Val(lvTabla.Items(I).SubItems(1).Text) * Val(lvTabla.Items(I).SubItems(6).Text), Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, lvTabla.Items(I).SubItems(7).Text, lvTabla.Items(I).SubItems(8).Text, "COMUN", 0, "", 0, txtHistoria.Text, lblPaciente.Text, cboSubServicio.Text, lvTabla.Items(I).SubItems(9).Text)
                End If
            Next
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSServicio As New DataSet
            dsSServicio = objSubServicio.BuscarDptoEspecialidadDpto(cboServicio.SelectedValue)
            cboSubServicio.DataSource = dsSServicio.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdEspecialidad"
        End If
    End Sub
End Class