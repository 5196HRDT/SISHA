Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Public Class frmNovafis
    Dim objProgramacion As New Programacion
    Dim objCupo As New Cupo
    Dim objConsulta As New Consulta
    Dim objConsultaCPT As New ConsultaCPT
    Dim objInterconsulta As New InterconsultaH
    Dim objInterconsultaE As New InterconsultaE
    Dim objMedico As New Medico
    Dim objUbigeo As New clsUbigeo
    Dim objHistoria As New Historia
    Dim objCIE10 As New CIE10
    Dim objLote As New LoteHIS
    Dim objRegistroHIS As New RegistroHIS
    Dim objNovafis As New Navigate
    Dim objEdades As New Edades
    Dim objEstados As New Estados_Novafis
    Dim objParametro As New Parametros
    Dim DNI As String
    Dim RutaArchivos As String
    Dim Lote, NumeroLote, PaginaLote As String
    Dim Operacion As Integer
    Dim NombrePaciente As String
    Dim Sintomas As String = "LLENADO EN ESTADISTICA"
    Dim TipoSeleccion As String = ""

    Dim nomFiltro As String = ""
    Dim Edad As String = ""
    Dim Años As String = ""
    Dim Meses As String = ""
    Dim Dias As String = ""
    Dim Año As Integer
    Dim EdadA, EdadM, EdadD As Integer
    Dim NroFila As Integer

    'Variables Impresion
    Dim FuenteE3 As New Font("Lucida Console", 14, FontStyle.Bold)
    Dim FuenteE2 As New Font("TIMES NEW ROMAN", 16, FontStyle.Bold)
    Dim FuenteD1 As New Font("Lucida Console", 12)
    Dim FuenteE1 As New Font("Lucida Console", 8)
    Dim FuenteD2 As New Font("Lucida Console", 9, FontStyle.Bold)

    Dim FuenteM As New Font("Lucida Console", 14, FontStyle.Bold)
    Dim FuenteTit As New Font("TIMES NEW ROMAN", 20, FontStyle.Bold)
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteA As New Font("Lucida Console", 12, FontStyle.Bold)
    Dim FuenteTex As New Font("Lucida Console", 8)
    Dim FuenteP As New Font("Lucida Console", 9, FontStyle.Bold)

    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim NroFilasTotales As Integer
    Dim NroPaginas As Integer
    Dim NroFilasHoja As Integer
    Dim TotalFilasLV As Integer
    Dim NroConsultas As Integer
    Dim X, Y As Integer
    Dim vImpresion As Integer

    Private Sub BuscarListaMed()
        btnImprimirHIS.Enabled = False

        lvMedico.Items.Clear()
        lvMedicos1.Items.Clear()
        Dim dsTabla As New Data.DataSet
        Dim I As Integer
        Dim Fila As ListViewItem
        dsTabla = objProgramacion.BuscarListaMedxMed(dtpFecha.Value.ToShortDateString, cboTurno.Text, txtMedico.Text)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvMedicos1.Items.Add(dsTabla.Tables(0).Rows(I)("Id"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Medico"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("IdProgramacion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CodigoHIS").ToString)

            If chkCargar.Checked Then
                Fila = lvMedico.Items.Add(dsTabla.Tables(0).Rows(I)("Id"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Medico"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Especialidad"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("IdProgramacion"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CodigoHIS").ToString)
            End If
        Next
    End Sub

    Private Function DevolverDescripcionCIE(CIE As String, Combo As ComboBox) As String
        Dim dsTabla As New Data.DataSet
        dsTabla = objCIE10.Buscar(CIE, 1)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            DevolverDescripcionCIE = dsTabla.Tables(0).Rows(0)("Descripcion")
            If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then Combo.Text = "DEFINITIVO"
        Else
            MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DevolverDescripcionCIE = ""
        End If
    End Function

    Private Function ReglasValidacionCIEMat() As Boolean
        If chkCorrelativo.Checked Then
            EdadA = Val(txtEdad.Text)
            EdadM = Val(txtEdadM.Text)
            EdadD = Val(txtEdadD.Text)
        End If
        Dim EdadActual As Double = EdadA * 365 + EdadM * 30 + EdadD
        ReglasValidacionCIEMat = False

        'Insumos Por Primera Vez
        If (txtCIE1.Text = "Z3003" Or txtCIE1.Text = "Z30051" Or txtCIE1.Text = "Z30052" Or txtCIE1.Text = "Z3006" Or txtCIE1.Text = "Z3008" Or txtCIE1.Text = "Z3009" Or txtCIE1.Text = "Z30091" Or txtCIE1.Text = "Z30092" Or txtCIE1.Text = "Z30093" Or txtCIE1.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE1.Text = "" : txtDes1.Text = "" : txtLab1.Text = "" : cboTD1.Text = "" : txtCIE1.Select() : Exit Function
        If (txtCIE2.Text = "Z3003" Or txtCIE2.Text = "Z30051" Or txtCIE2.Text = "Z30052" Or txtCIE2.Text = "Z3006" Or txtCIE2.Text = "Z3008" Or txtCIE2.Text = "Z3009" Or txtCIE2.Text = "Z30091" Or txtCIE2.Text = "Z30092" Or txtCIE2.Text = "Z30093" Or txtCIE2.Text = "Z30094") And txtLab2.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab2.Select() : Exit Function
        If (txtCIE3.Text = "Z3003" Or txtCIE3.Text = "Z30051" Or txtCIE3.Text = "Z30052" Or txtCIE3.Text = "Z3006" Or txtCIE3.Text = "Z3008" Or txtCIE3.Text = "Z3009" Or txtCIE3.Text = "Z30091" Or txtCIE3.Text = "Z30092" Or txtCIE3.Text = "Z30093" Or txtCIE3.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE3.Text = "" : txtCIE3.Select() : txtDes3.Text = "" : txtLab3.Text = "" : cboTD3.Text = "" : Exit Function
        If (txtCIE4.Text = "Z3003" Or txtCIE4.Text = "Z30051" Or txtCIE4.Text = "Z30052" Or txtCIE4.Text = "Z3006" Or txtCIE4.Text = "Z3008" Or txtCIE4.Text = "Z3009" Or txtCIE4.Text = "Z30091" Or txtCIE4.Text = "Z30092" Or txtCIE4.Text = "Z30093" Or txtCIE4.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE4.Text = "" : txtCIE4.Select() : txtDes4.Text = "" : txtLab4.Text = "" : cboTD4.Text = "" : Exit Function
        If (txtCIE5.Text = "Z3003" Or txtCIE5.Text = "Z30051" Or txtCIE5.Text = "Z30052" Or txtCIE5.Text = "Z3006" Or txtCIE5.Text = "Z3008" Or txtCIE5.Text = "Z3009" Or txtCIE5.Text = "Z30091" Or txtCIE5.Text = "Z30092" Or txtCIE5.Text = "Z30093" Or txtCIE5.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE5.Text = "" : txtCIE5.Select() : txtDes5.Text = "" : txtLab5.Text = "" : cboTD5.Text = "" : Exit Function
        If (txtCIE6.Text = "Z3003" Or txtCIE6.Text = "Z30051" Or txtCIE6.Text = "Z30052" Or txtCIE6.Text = "Z3006" Or txtCIE6.Text = "Z3008" Or txtCIE6.Text = "Z3009" Or txtCIE6.Text = "Z30091" Or txtCIE6.Text = "Z30092" Or txtCIE6.Text = "Z30093" Or txtCIE6.Text = "Z30094") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE6.Text = "" : txtCIE6.Select() : txtDes6.Text = "" : txtLab6.Text = "" : cboTD6.Text = "" : Exit Function

        'Continuador de Insumos
        If (txtCIE1.Text = "Z3043" Or txtCIE1.Text = "Z30451" Or txtCIE1.Text = "Z30452" Or txtCIE1.Text = "Z3046" Or txtCIE1.Text = "Z3048" Or txtCIE1.Text = "Z3049" Or txtCIE1.Text = "Z30491" Or txtCIE1.Text = "Z30492" Or txtCIE1.Text = "Z30493" Or txtCIE1.Text = "Z30494") And txtLab2.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab1.Select() : Exit Function
        If (txtCIE2.Text = "Z3043" Or txtCIE2.Text = "Z30451" Or txtCIE2.Text = "Z30452" Or txtCIE2.Text = "Z3046" Or txtCIE2.Text = "Z3048" Or txtCIE2.Text = "Z3049" Or txtCIE2.Text = "Z30491" Or txtCIE2.Text = "Z30492" Or txtCIE2.Text = "Z30493" Or txtCIE2.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE2.Text = "" : txtDes2.Text = "" : txtLab2.Text = "" : cboTD2.Text = "" : txtCIE2.Select() : Exit Function
        If (txtCIE3.Text = "Z3043" Or txtCIE3.Text = "Z30451" Or txtCIE3.Text = "Z30452" Or txtCIE3.Text = "Z3046" Or txtCIE3.Text = "Z3048" Or txtCIE3.Text = "Z3049" Or txtCIE3.Text = "Z30491" Or txtCIE3.Text = "Z30492" Or txtCIE3.Text = "Z30493" Or txtCIE3.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE3.Text = "" : txtCIE3.Select() : txtDes3.Text = "" : txtLab3.Text = "" : cboTD3.Text = "" : Exit Function
        If (txtCIE4.Text = "Z3043" Or txtCIE4.Text = "Z30451" Or txtCIE4.Text = "Z30452" Or txtCIE4.Text = "Z3046" Or txtCIE4.Text = "Z3048" Or txtCIE4.Text = "Z3049" Or txtCIE4.Text = "Z30491" Or txtCIE4.Text = "Z30492" Or txtCIE4.Text = "Z30493" Or txtCIE4.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE4.Text = "" : txtCIE4.Select() : txtDes4.Text = "" : txtLab4.Text = "" : cboTD4.Text = "" : Exit Function
        If (txtCIE5.Text = "Z3043" Or txtCIE5.Text = "Z30451" Or txtCIE5.Text = "Z30452" Or txtCIE5.Text = "Z3046" Or txtCIE5.Text = "Z3048" Or txtCIE5.Text = "Z3049" Or txtCIE5.Text = "Z30491" Or txtCIE5.Text = "Z30492" Or txtCIE5.Text = "Z30493" Or txtCIE5.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE5.Text = "" : txtCIE5.Select() : txtDes5.Text = "" : txtLab5.Text = "" : cboTD5.Text = "" : Exit Function
        If (txtCIE6.Text = "Z3043" Or txtCIE6.Text = "Z30451" Or txtCIE6.Text = "Z30452" Or txtCIE6.Text = "Z3046" Or txtCIE5.Text = "Z3048" Or txtCIE6.Text = "Z3049" Or txtCIE6.Text = "Z30491" Or txtCIE6.Text = "Z30492" Or txtCIE6.Text = "Z30493" Or txtCIE6.Text = "Z30494") Then MessageBox.Show("Este Diagnostico no puede ser asignado en esta Posición. Verificar Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtCIE6.Text = "" : txtCIE6.Select() : txtDes6.Text = "" : txtLab6.Text = "" : cboTD6.Text = "" : Exit Function

        'Regla del Z359
        If Microsoft.VisualBasic.Left(txtCIE1.Text, 4) = "Z359" And txtLab1.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab1.Select() : Exit Function
        If Microsoft.VisualBasic.Left(txtCIE2.Text, 4) = "Z359" And txtLab2.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab2.Select() : Exit Function
        If Microsoft.VisualBasic.Left(txtCIE3.Text, 4) = "Z359" And txtLab3.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab3.Select() : Exit Function
        If Microsoft.VisualBasic.Left(txtCIE4.Text, 4) = "Z359" And txtLab4.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab4.Select() : Exit Function
        If Microsoft.VisualBasic.Left(txtCIE5.Text, 4) = "Z359" And txtLab5.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab5.Select() : Exit Function
        If Microsoft.VisualBasic.Left(txtCIE6.Text, 4) = "Z359" And txtLab6.Text = "" Then MessageBox.Show("Debe Ingresar Nro de Control Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : ReglasValidacionCIEMat = True : txtLab6.Select() : Exit Function
    End Function

    Private Function ReglasValidacionCIENut() As Boolean
        If chkCorrelativo.Checked Then
            EdadA = Val(txtEdad.Text)
            EdadM = Val(txtEdadM.Text)
            EdadD = Val(txtEdadD.Text)
        End If
        Dim EdadActual As Double = EdadA * 365 + EdadM * 30 + EdadD
        ReglasValidacionCIENut = False

        'Nutricion D509
        If txtCIE1.Text = "D509" And txtLab1.Text = "" Then MessageBox.Show("En el DX1 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text = "D509" And txtLab2.Text = "" Then MessageBox.Show("En el DX2 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text = "D509" And txtLab3.Text = "" Then MessageBox.Show("En el DX3 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text = "D509" And txtLab4.Text = "" Then MessageBox.Show("En el DX4 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text = "D509" And txtLab5.Text = "" Then MessageBox.Show("En el DX5 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text = "D509" And txtLab6.Text = "" Then MessageBox.Show("En el DX6 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'Z001 Entre 1 Día a 28 Días Lab 1 a 2
        If txtCIE1.Text = "Z001" And txtLab1.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX1 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text = "Z001" And txtLab2.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX2 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text = "Z001" And txtLab3.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX3 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text = "Z001" And txtLab4.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX4 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text = "Z001" And txtLab5.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX5 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text = "Z001" And txtLab6.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX6 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'Z001 Entre 1 Mes a 11 meses Lab 1 a 11
        If txtCIE1.Text = "Z001" And txtLab1.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX1 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text = "Z001" And txtLab2.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX2 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text = "Z001" And txtLab3.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX3 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text = "Z001" And txtLab4.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX4 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text = "Z001" And txtLab5.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX5 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text = "Z001" And txtLab6.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX6 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'Z001 Entre 1 Año a 2 Años Lab 1 a 6
        If txtCIE1.Text = "Z001" And txtLab1.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX1 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text = "Z001" And txtLab2.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX2 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text = "Z001" And txtLab3.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX3 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text = "Z001" And txtLab4.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX4 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text = "Z001" And txtLab5.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX5 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text = "Z001" And txtLab6.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX6 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function


        'E44? Desnutricion Entre 1 dia menores de 5 Años Lab TP,TE,PE
        If txtCIE1.Text Like "E44*" And txtLab1.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX1 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text Like "E44*" And txtLab2.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX2 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text Like "E44*" And txtLab3.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX3 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text Like "E44*" And txtLab4.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX4 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text Like "E44*" And txtLab5.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX5 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text Like "E44*" And txtLab6.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX6 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'E44? Desnutricion Mayor Igual de 5 Años Lab IMC
        If txtCIE1.Text Like "E44*" And txtLab1.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX1 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text Like "E44*" And txtLab2.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX2 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text Like "E44*" And txtLab3.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX3 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text Like "E44*" And txtLab4.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX4 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text Like "E44*" And txtLab5.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX5 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text Like "E44*" And txtLab6.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX6 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'E66? Sobrepeso Entre 1 dia menores de 5 Años Lab TP,TE,PE
        If txtCIE1.Text Like "E66*" And txtLab1.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX1 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text Like "E66*" And txtLab2.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX2 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text Like "E66*" And txtLab3.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX3 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text Like "E66*" And txtLab4.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX4 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text Like "E66*" And txtLab5.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX5 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text Like "E66*" And txtLab6.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX6 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        'E66? Sobrepeso Mayor Igual a 5 Años Lab IMC
        If txtCIE1.Text Like "E66*" And txtLab1.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX1 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text Like "E66*" And txtLab2.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX2 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text Like "E66*" And txtLab3.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX3 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text Like "E66*" And txtLab4.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX4 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text Like "E66*" And txtLab5.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX5 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text Like "E66*" And txtLab6.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX6 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        '99401 Definir # de Consejeria 
        If (txtCIE1.Text = "99401" Or txtCIE1.Text = "99402" Or txtCIE1.Text = "99403" Or txtCIE1.Text = "99404") And txtLab1.Text = "" Then MessageBox.Show("En el DX1 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        If (txtCIE2.Text = "99401" Or txtCIE2.Text = "99402" Or txtCIE2.Text = "99403" Or txtCIE2.Text = "99404") And txtLab2.Text = "" Then MessageBox.Show("En el DX2 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        If (txtCIE3.Text = "99401" Or txtCIE3.Text = "99402" Or txtCIE3.Text = "99403" Or txtCIE3.Text = "99404") And txtLab3.Text = "" Then MessageBox.Show("En el DX3 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        If (txtCIE4.Text = "99401" Or txtCIE4.Text = "99402" Or txtCIE4.Text = "99403" Or txtCIE4.Text = "99404") And txtLab4.Text = "" Then MessageBox.Show("En el DX4 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        If (txtCIE5.Text = "99401" Or txtCIE5.Text = "99402" Or txtCIE5.Text = "99403" Or txtCIE5.Text = "99404") And txtLab5.Text = "" Then MessageBox.Show("En el DX5 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        If (txtCIE6.Text = "99401" Or txtCIE6.Text = "99402" Or txtCIE6.Text = "99403" Or txtCIE6.Text = "99404") And txtLab6.Text = "" Then MessageBox.Show("En el DX6 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function
    End Function

    Private Function ReglasValidacionCIEDental() As Boolean
        Dim EdadActual As Double = EdadA * 365 + EdadM * 30 + EdadD
        ReglasValidacionCIEDental = False

        'D0120 
        If txtCIE1.Text = "D509" And txtLab1.Text = "" Then MessageBox.Show("En el DX1 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIEDental = True : txtLab1.Select() : Exit Function
        If txtCIE2.Text = "D509" And txtLab2.Text = "" Then MessageBox.Show("En el DX2 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIEDental = True : txtLab2.Select() : Exit Function
        If txtCIE3.Text = "D509" And txtLab3.Text = "" Then MessageBox.Show("En el DX3 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIEDental = True : txtLab3.Select() : Exit Function
        If txtCIE4.Text = "D509" And txtLab4.Text = "" Then MessageBox.Show("En el DX4 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIEDental = True : txtLab4.Select() : Exit Function
        If txtCIE5.Text = "D509" And txtLab5.Text = "" Then MessageBox.Show("En el DX5 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIEDental = True : txtLab5.Select() : Exit Function
        If txtCIE6.Text = "D509" And txtLab6.Text = "" Then MessageBox.Show("En el DX6 D509 Debe Ingrear Obligatoriamente (LEV - MOD - SEV)", "Mensaje de Información") : ReglasValidacionCIEDental = True : txtLab6.Select() : Exit Function

        ''Z001 Entre 1 Día a 28 Días Lab 1 a 2
        'If txtCIE1.Text = "Z001" And txtLab1.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX1 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        'If txtCIE2.Text = "Z001" And txtLab2.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX2 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        'If txtCIE3.Text = "Z001" And txtLab3.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX3 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        'If txtCIE4.Text = "Z001" And txtLab4.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX4 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        'If txtCIE5.Text = "Z001" And txtLab5.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX5 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        'If txtCIE6.Text = "Z001" And txtLab6.Text = "" And (EdadActual >= 1 And EdadActual <= 28) Then MessageBox.Show("En el DX6 Z001 Debe Ingrear Obligatoriamente (1 a 2)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        ''Z001 Entre 1 Mes a 11 meses Lab 1 a 11
        'If txtCIE1.Text = "Z001" And txtLab1.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX1 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        'If txtCIE2.Text = "Z001" And txtLab2.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX2 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        'If txtCIE3.Text = "Z001" And txtLab3.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX3 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        'If txtCIE4.Text = "Z001" And txtLab4.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX4 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        'If txtCIE5.Text = "Z001" And txtLab5.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX5 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        'If txtCIE6.Text = "Z001" And txtLab6.Text = "" And (EdadActual >= 29 And EdadActual <= 364) Then MessageBox.Show("En el DX6 Z001 Debe Ingrear Obligatoriamente (1 a 11)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        ''Z001 Entre 1 Año a 2 Años Lab 1 a 6
        'If txtCIE1.Text = "Z001" And txtLab1.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX1 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        'If txtCIE2.Text = "Z001" And txtLab2.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX2 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        'If txtCIE3.Text = "Z001" And txtLab3.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX3 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        'If txtCIE4.Text = "Z001" And txtLab4.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX4 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        'If txtCIE5.Text = "Z001" And txtLab5.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX5 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        'If txtCIE6.Text = "Z001" And txtLab6.Text = "" And (EdadActual >= 365 And EdadActual <= 729) Then MessageBox.Show("En el DX6 Z001 Debe Ingrear Obligatoriamente (1 a 6)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function


        ''E44? Desnutricion Entre 1 dia menores de 5 Años Lab TP,TE,PE
        'If txtCIE1.Text Like "E44*" And txtLab1.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX1 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        'If txtCIE2.Text Like "E44*" And txtLab2.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX2 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        'If txtCIE3.Text Like "E44*" And txtLab3.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX3 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        'If txtCIE4.Text Like "E44*" And txtLab4.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX4 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        'If txtCIE5.Text Like "E44*" And txtLab5.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX5 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        'If txtCIE6.Text Like "E44*" And txtLab6.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX6 Desnutrición Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        ''E44? Desnutricion Mayor Igual de 5 Años Lab IMC
        'If txtCIE1.Text Like "E44*" And txtLab1.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX1 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        'If txtCIE2.Text Like "E44*" And txtLab2.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX2 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        'If txtCIE3.Text Like "E44*" And txtLab3.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX3 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        'If txtCIE4.Text Like "E44*" And txtLab4.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX4 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        'If txtCIE5.Text Like "E44*" And txtLab5.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX5 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        'If txtCIE6.Text Like "E44*" And txtLab6.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX6 Desnutrición Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        ''E66? Sobrepeso Entre 1 dia menores de 5 Años Lab TP,TE,PE
        'If txtCIE1.Text Like "E66*" And txtLab1.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX1 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        'If txtCIE2.Text Like "E66*" And txtLab2.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX2 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        'If txtCIE3.Text Like "E66*" And txtLab3.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX3 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        'If txtCIE4.Text Like "E66*" And txtLab4.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX4 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        'If txtCIE5.Text Like "E66*" And txtLab5.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX5 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        'If txtCIE6.Text Like "E66*" And txtLab6.Text = "" And (EdadActual >= 1 And EdadActual <= 1824) Then MessageBox.Show("En el DX6 Sobrepeso Debe Ingrear Obligatoriamente (TP, TE o PE)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        ''E66? Sobrepeso Mayor Igual a 5 Años Lab IMC
        'If txtCIE1.Text Like "E66*" And txtLab1.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX1 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        'If txtCIE2.Text Like "E66*" And txtLab2.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX2 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        'If txtCIE3.Text Like "E66*" And txtLab3.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX3 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        'If txtCIE4.Text Like "E66*" And txtLab4.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX4 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        'If txtCIE5.Text Like "E66*" And txtLab5.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX5 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        'If txtCIE6.Text Like "E66*" And txtLab6.Text = "" And (EdadActual >= 1825) Then MessageBox.Show("En el DX6 Sobrepeso Debe Ingrear Obligatoriamente (IMC)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function

        ''99401 Definir # de Consejeria 
        'If (txtCIE1.Text = "99401" Or txtCIE1.Text = "99402" Or txtCIE1.Text = "99403" Or txtCIE1.Text = "99404") And txtLab1.Text = "" Then MessageBox.Show("En el DX1 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab1.Select() : Exit Function
        'If (txtCIE2.Text = "99401" Or txtCIE2.Text = "99402" Or txtCIE2.Text = "99403" Or txtCIE2.Text = "99404") And txtLab2.Text = "" Then MessageBox.Show("En el DX2 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab2.Select() : Exit Function
        'If (txtCIE3.Text = "99401" Or txtCIE3.Text = "99402" Or txtCIE3.Text = "99403" Or txtCIE3.Text = "99404") And txtLab3.Text = "" Then MessageBox.Show("En el DX3 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab3.Select() : Exit Function
        'If (txtCIE4.Text = "99401" Or txtCIE4.Text = "99402" Or txtCIE4.Text = "99403" Or txtCIE4.Text = "99404") And txtLab4.Text = "" Then MessageBox.Show("En el DX4 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab4.Select() : Exit Function
        'If (txtCIE5.Text = "99401" Or txtCIE5.Text = "99402" Or txtCIE5.Text = "99403" Or txtCIE5.Text = "99404") And txtLab5.Text = "" Then MessageBox.Show("En el DX5 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab5.Select() : Exit Function
        'If (txtCIE6.Text = "99401" Or txtCIE6.Text = "99402" Or txtCIE6.Text = "99403" Or txtCIE6.Text = "99404") And txtLab6.Text = "" Then MessageBox.Show("En el DX6 La Consejeria Debe Ingrear Obligatoriamente (# Consejeria)", "Mensaje de Información") : ReglasValidacionCIENut = True : txtLab6.Select() : Exit Function
    End Function


    Private Sub frmNovafis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        dtpFecNac.Enabled = False
        txtEdad.Enabled = False
        txtEdadM.Enabled = False
        txtEdadD.Enabled = False
        txtEdad.Enabled = False
        txtEdadM.Enabled = False
        txtEdadD.Enabled = False
        cboTEdad.Enabled = False
        cboTipoEM.Enabled = False
        cboTipoED.Enabled = False
        cboSexo.Enabled = False
        cboDepartamento.Enabled = False
        cboProvincia.Enabled = False
        cboDistrito.Enabled = False
        txtDNI.Enabled = False


        dtpFecha.Value = Date.Now.ToShortDateString
        cboTurno.Text = "MAÑANA"
        cboEst.Text = "HRDT"

        btnCancelar.Enabled = False
        btnGrabar.Enabled = False

        'Departamento
        Dim dsDpto As New Data.DataSet
        dsDpto = objUbigeo.Departamento
        cboDepartamento.DataSource = dsDpto.Tables(0)
        cboDepartamento.DisplayMember = "desc_dpto"
        cboDepartamento.ValueMember = "cod_dpto"
        cboDepartamento.Text = "LA LIBERTAD"
        cboDepartamento_SelectedIndexChanged(sender, e)

        'Lote HIS
        Dim dsLH As New DataSet
        dsLH = objLote.Buscar
        Lote = dsLH.Tables(0).Rows(0)("Lote")
        NumeroLote = dsLH.Tables(0).Rows(0)("Numero")
        PaginaLote = dsLH.Tables(0).Rows(0)("Pagina")

        txtLote.Text = dsLH.Tables(0).Rows(0)("Lote") & Microsoft.VisualBasic.Right("00" & dsLH.Tables(0).Rows(0)("Numero"), 2)
        txtPagina.Text = dsLH.Tables(0).Rows(0)("Pagina")


        btnImprimirHIS.Enabled = False

        If vProgramas = "SI" Then
            txtMedico.Text = NomMedico
            txtMedico.Enabled = False
            chkCargar.Checked = True
            chkCargar.Enabled = False
            btnMigrar.Enabled = False
            cboEst.Enabled = False
        Else
            txtMedico.Text = ""
            txtMedico.Enabled = True
            chkCargar.Checked = False
            chkCargar.Enabled = True
            btnMigrar.Enabled = True
            cboEst.Enabled = True
        End If
    End Sub

    Private Sub lvMedico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvMedico.KeyDown
        If e.KeyCode = Keys.Delete And lvMedico.SelectedItems.Count > 0 Then
            lvMedico.Items.RemoveAt(lvMedico.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvMedico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMedico.SelectedIndexChanged
        btnCancelar_Click(sender, e)
        lvConsulta.Items.Clear()
        lvDet.Items.Clear()
        btnImprimirHIS.Enabled = False
        lblTConsultas.Text = ""
        btnImprimirHIS.Enabled = True : btnImprimirHIS_Click(sender, e)
    End Sub

    Private Sub btnImprimirT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirT.Click
        vImpresion = 1
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs, ByVal Medico As String, ByVal Especialidad As String)
        With Imp.Graphics
            .DrawString(" Hospital Regional", FuenteE1, Pincel, 30, Y)
            .DrawString(Microsoft.VisualBasic.Left("Dr(a) " & Medico & StrDup(32, " "), 32), FuenteE2, Pincel, 350, Y)
            Y = Y + 20
            .DrawString("Docente de Trujillo", FuenteE1, Pincel, 30, Y)
            .DrawString(Microsoft.VisualBasic.Left(Especialidad & StrDup(32, " "), 32), FuenteE2, Pincel, 350, Y)
            Y = Y + 30
            .DrawString("CONSULTA EXTERNA", FuenteE3, Pincel, 200, Y)
            Y = Y + 10
            .DrawString("Fecha: " & dtpFecha.Value.ToShortDateString & " Turno: " & cboTurno.Text, FuenteD2, Pincel, 550, Y)
            Y = Y + 10
            .DrawLine(Pens.Black, 200, Y, 400, Y)
            Y = Y + 15
            .DrawString("Historia" & StrDup(15, " ") & "Paciente" & StrDup(32, " ") & "FechaNac" & StrDup(6, " ") & "Edad" & StrDup(8, " ") & "Sexo", FuenteD2, Pincel, 40, Y)
        End With
    End Sub

    Private Sub EncabezadoHIS(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            Y = 20
            .DrawString("MINISTERIO DE SALUD", FuenteTit, Pincel, 250, Y)
            Y = Y + 20
            .DrawString("OITE GERESA/LL", FuenteTit, Pincel, 300, Y)
            Y = Y + 40
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 5
            .DrawString("Hospital ( X ) , Instituto (   ) , C.S. (   ) , P.S. (   )     TURNO       Nº DNi del Trabajador  Nº LOTE:", FuenteTex, Pincel, 40, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 5
            .DrawString(Microsoft.VisualBasic.Left("HOSPITAL REGIONAL DOCENTE DE TRUJILLO" & StrDup(38, " "), 38) & StrDup(2, " ") & Microsoft.VisualBasic.Left(cboTurno.Text & StrDup(10, " "), 10) & StrDup(2, " ") & Microsoft.VisualBasic.Left(DNI & StrDup(8, " "), 8), FuenteA, Pincel, 40, Y)
            .DrawString("Nº Pagina:", FuenteTex, Pincel, 700, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 15
            .DrawString("Registro Diario de Atencion y Otras Actvidades", Fuente, Pincel, 40, Y)
            .DrawString("NOMBRES DEL RESPONSABLE DE ATENCION", FuenteTex, Pincel, 545, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 5
            .DrawString("F E C H A      Codigo RENAES       Unidad Productora de Servicios (UPS)", FuenteTex, Pincel, 40, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 540, Y)
            Y = Y + 10
            .DrawString(StrDup(2, " ") & Microsoft.VisualBasic.Right("00" & Month(dtpFecha.Value), 2) & "-" & Year(dtpFecha.Value) & StrDup(14, " ") & Microsoft.VisualBasic.Left(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text & StrDup(22, " "), 22) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(1).Text & StrDup(25, " "), 25), FuenteA, Pincel, 10, Y)
            Y = Y + 40
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 10
            .DrawString("  Dia HISTORIA  FINA PETN DIS/CEN EDAD SEX ESTA SERV  DIAGNOSTICO/MOTIVO CONSULTA/ACT SALUD     T.DX  LAB CIE/CPT", FuenteTex, Pincel, 10, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 840, Y)
            Y = Y + 5
        End With
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NroFilasTotales = 0
        TotalFilasLV = lvDet.Items.Count - 1
        NroConsultas = 0
        NroFila = 0
        Y = 20
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", FuenteD1).Height
        Dim Filas As Integer = 0

        Y = 20
        EncabezadoHIS(e)
        Filas = 10
        NroFilasHoja = 0
        Y = Y + 10
        With e.Graphics
            Do While NroFilasTotales <= TotalFilasLV

                If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                    NroFila += 1
                    .DrawString(Microsoft.VisualBasic.Right("00" & NroFila, 2) & ")", FuenteTex, Pincel, 5, Y)
                End If
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(0).Text, FuenteTex, Pincel, 30, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(1).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 60, Y)
                .DrawString(StrDup(1, " ") & lvDet.Items(NroFilasTotales).SubItems(14).Text, FuenteTex, Pincel, 120, Y)
                .DrawString(StrDup(1, " ") & lvDet.Items(NroFilasTotales).SubItems(15).Text, FuenteTex, Pincel, 150, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(2).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 170, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(4).Text & StrDup(4, " "), 4), FuenteTex, Pincel, 240, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(5).Text, FuenteTex, Pincel, 290, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(6).Text, FuenteTex, Pincel, 320, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(7).Text, FuenteTex, Pincel, 350, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(8).Text & StrDup(42, " "), 42), FuenteTex, Pincel, 380, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(9).Text, FuenteTex, Pincel, 680, Y)
                .DrawString(lvDet.Items(NroFilasTotales).SubItems(10).Text, FuenteTex, Pincel, 710, Y)
                .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(11).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 740, Y)
                Y = Y + 12
                If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                    .DrawLine(Pens.Black, 10, Y, 840, Y)
                    Y = Y + 10
                Else
                    .DrawLine(Pens.Black, 380, Y, 840, Y)
                    Y = Y + 10
                End If

                NroFilasHoja += 1
                'If NroFilasHoja >= 70 Then
                '    Exit Do
                'End If
                NroFilasTotales += 1
                If NroFilasHoja >= 36 Then Exit Do
            Loop

            'If NroFilasTotales < 36 Then
            If NroFilasTotales >= TotalFilasLV Then
                e.HasMorePages = False
            Else
                e.HasMorePages = True
                NroFilasHoja = 0
            End If
            'Else
            'e.HasMorePages = False
            'End If
        End With
    End Sub

    Private Sub btnImprimirHIS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirHIS.Click
        lvDet.Items.Clear()
        Dim dsTab As New Data.DataSet
        Dim Fila As ListViewItem
        Dim TConsultas As Integer = 0

        If lvMedico.SelectedItems.Count = 0 Then Exit Sub
        lblTConsultas.Tag = 0
        lblTConsultas.Text = 0 & "Consultas"

        Dim I As Integer
        Dim dsMedico As New Data.DataSet
        Dim Año As Integer

        lblMedico.Tag = lvMedico.SelectedItems(0).SubItems(0).Text
        lblMedico.Text = lvMedico.SelectedItems(0).SubItems(1).Text
        lblEspecialidad.Text = lvMedico.SelectedItems(0).SubItems(2).Text

        'DNI Medico
        DNI = ""
        dsMedico = objMedico.Medico_BuscarId(lvMedico.SelectedItems(0).SubItems(0).Text)
        If dsMedico.Tables(0).Rows.Count > 0 Then DNI = dsMedico.Tables(0).Rows(I)("DNI").ToString

        'Consultas Medicas
        dsTab = objConsulta.GenerarHISTurno(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(1).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = dtpFecha.Value
                dinicio = dsTab.Tables(0).Rows(I)("FNacimiento")
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
                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                    EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))
                    If Val(EdadD) > dtpFecha.Value.Day Then
                        EdadD = Val(EdadD) - dtpFecha.Value.Day
                    ElseIf Val(EdadD) < dtpFecha.Value.Day Then
                        If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                        EdadD = dtpFecha.Value.Day - EdadD
                        EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
                    Else
                        EdadD = 0
                    End If
                End If


                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If

                'EdadA = 0 : Edad = "0"
                'If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                '    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
                '        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                '        If Año > 1 Then
                '            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
                '                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                '            Else
                '                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
                '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                '            End If
                '        Else
                '            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                '                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                '                EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                '                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                '                EdadM = 11
                '                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
                '                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                '                EdadA = 1
                '                EdadM = 0
                '                Edad = "1 A y 0 M"
                '            End If
                '        End If
                '    Else
                '        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                '            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
                '            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
                '            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '            EdadD = 0
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
                '        End If
                '    End If
                'End If
            End If

            Fila.SubItems.Add(Edad)

            If dsTab.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1)) Else Fila.SubItems.Add("")
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "SANIDAD FAP" Then
                TCupo = "5"
            ElseIf TCupo = "SANIDAD NAVAL" Then
                TCupo = "6"
            ElseIf TCupo = "SANIDAD EP" Then
                TCupo = "7"
            ElseIf TCupo = "SANIDAD PNP" Then
                TCupo = "8"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "PRIVADO" Then
                TCupo = "9"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            ElseIf TCupo = "OTROS" Then
                TCupo = "10"
            ElseIf TCupo = "EXONERADO" Then
                TCupo = "11"
            ElseIf TCupo = "ESSALUD" Then
                TCupo = "3"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdConsulta"))
            Fila.SubItems.Add("CONSULTA")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("SI")
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5") <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6") <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab6").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next


        'Interconsultas Hospitalizacion
        dsTab = objInterconsulta.GenerarHISTurno(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                EdadA = 0 : Edad = "0"
                If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    Dim Dias As Integer, Meses As Integer, Años As Integer
                    Dim DiasMes As Integer
                    Dim dfin, dinicio As Date
                    dfin = dtpFecha.Value
                    dinicio = dsTab.Tables(0).Rows(I)("FNacimiento")
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
                        If Val(EdadA) > 0 Then
                            Edad = EdadA & "A " & EdadM & "M"
                        Else
                            Edad = EdadM & "M " & EdadD & "D"
                        End If
                        EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))
                        If Val(EdadD) > dtpFecha.Value.Day Then
                            EdadD = Val(EdadD) - dtpFecha.Value.Day
                        ElseIf Val(EdadD) < dtpFecha.Value.Day Then
                            If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                            EdadD = dtpFecha.Value.Day - EdadD
                            EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
                        Else
                            EdadD = 0
                        End If
                    End If


                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                    'If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
                    '    Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                    '    If Año > 1 Then
                    '        If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
                    '            EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                    '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                    '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                    '        Else
                    '            EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
                    '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                    '            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                    '        End If
                    '    Else
                    '        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                    '            EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                    '            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                    '            Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                    '            EdadM = 11
                    '            EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
                    '            Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
                    '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                    '            EdadA = 1
                    '            EdadM = 0
                    '            Edad = "1 A y 0 M"
                    '        End If
                    '    End If
                    'Else
                    '    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                    '        EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                    '        EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                    '        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    '    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                    '        EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
                    '        EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
                    '        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
                    '    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                    '        EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                    '        EdadD = 0
                    '        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
                    '    End If
                    'End If
                End If
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "SANIDAD FAP" Then
                TCupo = "5"
            ElseIf TCupo = "SANIDAD NAVAL" Then
                TCupo = "6"
            ElseIf TCupo = "SANIDAD EP" Then
                TCupo = "7"
            ElseIf TCupo = "SANIDAD PNP" Then
                TCupo = "8"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "PRIVADO" Then
                TCupo = "9"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            ElseIf TCupo = "OTROS" Then
                TCupo = "10"
            ElseIf TCupo = "EXONERADO" Then
                TCupo = "11"
            ElseIf TCupo = "ESSALUD" Then
                TCupo = "3"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaH"))
            Fila.SubItems.Add("HOSPITALIZACION")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("SI")
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5") <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6") <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        'Interconsultas Emergencia CH
        dsTab = objInterconsultaE.GenerarHISTurno(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            Dim VerAPP As Boolean = False
            If Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("DNISH").ToString, 3) = "APP" Then VerAPP = True
            If Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("DNISH").ToString, 3) = "AAA" Then VerAPP = True

            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            NombrePaciente = dsTab.Tables(0).Rows(I)("Apaterno") & " " & dsTab.Tables(0).Rows(I)("Amaterno") & " " & dsTab.Tables(0).Rows(I)("Nombres")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" And Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                    Dim Dias As Integer, Meses As Integer, Años As Integer
                    Dim DiasMes As Integer
                    Dim dfin, dinicio As Date
                    dfin = dtpFecha.Value
                    dinicio = dsTab.Tables(0).Rows(I)("FNacimiento")
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
                        If Val(EdadA) > 0 Then
                            Edad = EdadA & "A " & EdadM & "M"
                        Else
                            Edad = EdadM & "M " & EdadD & "D"
                        End If
                        EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))
                        If Val(EdadD) > dtpFecha.Value.Day Then
                            EdadD = Val(EdadD) - dtpFecha.Value.Day
                        ElseIf Val(EdadD) < dtpFecha.Value.Day Then
                            If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                            EdadD = dtpFecha.Value.Day - EdadD
                            EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
                        Else
                            EdadD = 0
                        End If
                    End If


                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                    'EdadA = 0 : Edad = "0"
                    'If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    '    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
                    '        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                    '        If Año > 1 Then
                    '            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
                    '                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                    '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                    '                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                    '            Else
                    '                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
                    '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                    '                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                    '            End If
                    '        Else
                    '            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                    '                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                    '                EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                    '                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                    '                EdadM = 11
                    '                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
                    '                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
                    '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                    '                EdadA = 1
                    '                EdadM = 0
                    '                Edad = "1 A y 0 M"
                    '            End If
                    '        End If
                    '    Else
                    '        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                    '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                    '            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                    '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                    '            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
                    '            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
                    '            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
                    '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                    '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                    '            EdadD = 0
                    '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
                    '        End If
                    '    End If
                    'End If
                End If
            Else
                If Not VerAPP Then
                    txtEdad.Text = dsTab.Tables(0).Rows(I)("Edad")
                    Edad = dsTab.Tables(0).Rows(I)("Edad")
                    cboTEdad.Text = dsTab.Tables(0).Rows(I)("TEdad")
                    If dsTab.Tables(0).Rows(I)("TEdad") = "A" Then
                        EdadA = dsTab.Tables(0).Rows(I)("Edad")
                        EdadM = 0
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad") = "M" Then
                        EdadA = 0
                        EdadM = dsTab.Tables(0).Rows(I)("Edad")
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad") = "D" Then
                        EdadA = 0
                        EdadM = 0
                        EdadD = dsTab.Tables(0).Rows(I)("Edad")
                    End If
                End If
            End If

            If Not VerAPP Then Fila.SubItems.Add(Edad) Else Fila.SubItems.Add("")

            If Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo").ToString, 1))
                Else
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("SexoSH").ToString, 1))
                End If
            Else
                Fila.SubItems.Add("")
            End If
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add("")
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String
            If dsTab.Tables(0).Rows(I)("TipoCupo") = "" Then TCupo = "COMUN" Else TCupo = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "SANIDAD FAP" Then
                TCupo = "5"
            ElseIf TCupo = "SANIDAD NAVAL" Then
                TCupo = "6"
            ElseIf TCupo = "SANIDAD EP" Then
                TCupo = "7"
            ElseIf TCupo = "SANIDAD PNP" Then
                TCupo = "8"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "PRIVADO" Then
                TCupo = "9"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            ElseIf TCupo = "OTROS" Then
                TCupo = "10"
            ElseIf TCupo = "EXONERADO" Then
                TCupo = "11"
            ElseIf TCupo = "ESSALUD" Then
                TCupo = "3"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaE"))
            Fila.SubItems.Add("INTERCONSULTAE")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Else
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("SexoSH").ToString)
            End If
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(EdadA)
                Fila.SubItems.Add(EdadM)
                Fila.SubItems.Add(EdadD)
            Else
                If dsTab.Tables(0).Rows(I)("TEdad") = "A" Then
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "M" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "D" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                End If
            End If
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("CSHistoria"))
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad"))
            Else
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)
            End If
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "NO" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            End If
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab6").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        'Interconsultas Emergencia SH
        dsTab = objInterconsultaE.GenerarHISSHTurno(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            Dim VerAPP As Boolean = False
            If Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("DNISH").ToString, 3) = "APP" Then VerAPP = True


            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)

            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            NombrePaciente = "" 'dsTab.Tables(0).Rows(I)("Apaterno") & " " & dsTab.Tables(0).Rows(I)("Amaterno") & " " & dsTab.Tables(0).Rows(I)("Nombres")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" And Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                    EdadA = 0 : Edad = "0"
                    If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                        Dim Dias As Integer, Meses As Integer, Años As Integer
                        Dim DiasMes As Integer
                        Dim dfin, dinicio As Date
                        dfin = dtpFecha.Value
                        dinicio = dsTab.Tables(0).Rows(I)("FNacimiento")
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
                            If Val(EdadA) > 0 Then
                                Edad = EdadA & "A " & EdadM & "M"
                            Else
                                Edad = EdadM & "M " & EdadD & "D"
                            End If
                            EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))
                            If Val(EdadD) > dtpFecha.Value.Day Then
                                EdadD = Val(EdadD) - dtpFecha.Value.Day
                            ElseIf Val(EdadD) < dtpFecha.Value.Day Then
                                If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                                EdadD = dtpFecha.Value.Day - EdadD
                                EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
                            Else
                                EdadD = 0
                            End If
                        End If


                        If Val(EdadA) > 0 Then
                            Edad = EdadA & "A " & EdadM & "M"
                        Else
                            Edad = EdadM & "M " & EdadD & "D"
                        End If
                        'If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
                        '    Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                        '    If Año > 1 Then
                        '        If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
                        '            EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                        '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                        '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                        '        Else
                        '            EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
                        '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                        '            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                        '        End If
                        '    Else
                        '        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                        '            EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                        '            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        '            Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                        '            EdadM = 11
                        '            EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
                        '            Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
                        '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                        '            EdadA = 1
                        '            EdadM = 0
                        '            Edad = "1 A y 0 M"
                        '        End If
                        '    End If
                        'Else
                        '    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                        '        EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                        '        EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        '        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        '    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                        '        EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
                        '        EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
                        '        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
                        '    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                        '        EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                        '        EdadD = 0
                        '        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
                        '    End If
                        'End If
                    End If
                End If
            Else
                If Not VerAPP Then
                    txtEdad.Text = dsTab.Tables(0).Rows(I)("Edad")
                    Edad = dsTab.Tables(0).Rows(I)("Edad")
                    cboTEdad.Text = dsTab.Tables(0).Rows(I)("TEdad")
                    If dsTab.Tables(0).Rows(I)("TEdad") = "A" Then
                        EdadA = dsTab.Tables(0).Rows(I)("Edad")
                        EdadM = 0
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad") = "M" Then
                        EdadA = 0
                        EdadM = dsTab.Tables(0).Rows(I)("Edad")
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad") = "D" Then
                        EdadA = 0
                        EdadM = 0
                        EdadD = dsTab.Tables(0).Rows(I)("Edad")
                    End If
                End If
            End If

            If Not VerAPP Then Fila.SubItems.Add(Edad) Else Fila.SubItems.Add("")

            If Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo").ToString, 1))
                Else
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("SexoSH").ToString, 1))
                End If
            Else
                Fila.SubItems.Add("")
            End If
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Dim TCupo As String
            If dsTab.Tables(0).Rows(I)("TipoCupo") = "" Then TCupo = "COMUN" Else TCupo = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "SANIDAD FAP" Then
                TCupo = "5"
            ElseIf TCupo = "SANIDAD NAVAL" Then
                TCupo = "6"
            ElseIf TCupo = "SANIDAD EP" Then
                TCupo = "7"
            ElseIf TCupo = "SANIDAD PNP" Then
                TCupo = "8"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "PRIVADO" Then
                TCupo = "9"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            ElseIf TCupo = "OTROS" Then
                TCupo = "10"
            ElseIf TCupo = "EXONERADO" Then
                TCupo = "11"
            ElseIf TCupo = "ESSALUD" Then
                TCupo = "3"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaE"))
            Fila.SubItems.Add("INTERCONSULTAE")
            Fila.SubItems.Add("")
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Else
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("SexoSH").ToString)
            End If
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(EdadA)
                Fila.SubItems.Add(EdadM)
                Fila.SubItems.Add(EdadD)
            Else
                If dsTab.Tables(0).Rows(I)("TEdad") = "A" Then
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "M" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "D" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                End If
            End If
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("CSHistoria"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "NO" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            End If
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab6").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        'PROCEDIMIENTOS
        'dsTab = objConsultaCPT.GenerarHISTurno(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        'For I = 0 To dsTab.Tables(0).Rows.Count - 1
        '    Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

        '    'DNI Paciente
        '    If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
        '        If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
        '    Else
        '        Fila.SubItems.Add("")
        '    End If
        '    'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

        '    'Edad Paciente
        '    If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
        '        EdadA = 0 : Edad = "0"
        '        If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
        '            Dim Dias As Integer, Meses As Integer, Años As Integer
        '            Dim DiasMes As Integer
        '            Dim dfin, dinicio As Date
        '            dfin = dtpFecha.Value
        '            dinicio = dsTab.Tables(0).Rows(I)("FNacimiento")
        '            Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
        '            Meses = DatePart("m", dfin) - DatePart("m", dinicio)
        '            Años = DateDiff("yyyy", dinicio, dfin)

        '            If Meses = 0 And Años = 0 Then
        '                EdadA = 0
        '                EdadM = 0
        '                Dias = Math.Abs(Dias)
        '                EdadD = Dias
        '            Else
        '                'Verificar Dias
        '                If Dias < 0 Then
        '                    DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
        '                    Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
        '                    Meses = Meses - 1
        '                End If
        '                If Meses < 0 Then
        '                    Meses = 12 + Meses
        '                    Años = Años - 1
        '                End If
        '                EdadA = Años
        '                EdadM = Meses
        '                EdadD = Dias
        '                If Val(EdadA) > 0 Then
        '                    Edad = EdadA & "A " & EdadM & "M"
        '                Else
        '                    Edad = EdadM & "M " & EdadD & "D"
        '                End If
        '                EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))
        '                If Val(EdadD) > dtpFecha.Value.Day Then
        '                    EdadD = Val(EdadD) - dtpFecha.Value.Day
        '                ElseIf Val(EdadD) < dtpFecha.Value.Day Then
        '                    If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
        '                    EdadD = dtpFecha.Value.Day - EdadD
        '                    EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
        '                Else
        '                    EdadD = 0
        '                End If
        '            End If


        '            If Val(EdadA) > 0 Then
        '                Edad = EdadA & "A " & EdadM & "M"
        '            Else
        '                Edad = EdadM & "M " & EdadD & "D"
        '            End If
        '            'If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
        '            '    Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
        '            '    If Año > 1 Then
        '            '        If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
        '            '            EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
        '            '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
        '            '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
        '            '        Else
        '            '            EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
        '            '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
        '            '            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
        '            '        End If
        '            '    Else
        '            '        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
        '            '            EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
        '            '            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
        '            '            Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
        '            '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
        '            '            EdadM = 11
        '            '            EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
        '            '            Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
        '            '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
        '            '            EdadA = 1
        '            '            EdadM = 0
        '            '            Edad = "1 A y 0 M"
        '            '        End If
        '            '    End If
        '            'Else
        '            '    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
        '            '        EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
        '            '        EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
        '            '        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
        '            '    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
        '            '        EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
        '            '        EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
        '            '        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
        '            '    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
        '            '        EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
        '            '        EdadD = 0
        '            '        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
        '            '    End If
        '            'End If
        '        End If
        '    End If

        '    Fila.SubItems.Add(Edad)

        '    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
        '    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
        '    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
        '    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
        '    If dsTab.Tables(0).Rows(I)("LNacimiento").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento")) Else Fila.SubItems.Add("")
        '    Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
        '    If TCupo = "CONVENIO" Then
        '        TCupo = "10"
        '    ElseIf TCupo = "PROGRAMA" Then
        '        TCupo = "10"
        '    ElseIf TCupo = "SIS" Then
        '        TCupo = "2"
        '    ElseIf TCupo = "CREDITO" Then
        '        TCupo = "10"
        '    ElseIf TCupo = "SOAT" Then
        '        TCupo = "4"
        '    Else
        '        TCupo = "1"
        '    End If
        '    Fila.SubItems.Add(TCupo)

        '    Fila.SubItems.Add("1")
        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdProcedimiento"))
        '    Fila.SubItems.Add("PROCEDIMIENTO")
        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
        '    Fila.SubItems.Add(EdadA)
        '    Fila.SubItems.Add(EdadM)
        '    Fila.SubItems.Add(EdadD)
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("SI")
        '    lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
        '    TConsultas += 1

        '    'Segundo Diagnostico
        '    'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
        '    Fila = lvDet.Items.Add("")
        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
        '    'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento")) Else Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
        '    If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    Fila.SubItems.Add("")
        '    'End If

        '    'Tercer Diagnostico
        '    If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
        '        Fila = lvDet.Items.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
        '        Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '    End If
        '    'Cuarto Diagnostico
        '    If dsTab.Tables(0).Rows(I)("Cie4").ToString <> "" Then
        '        Fila = lvDet.Items.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
        '        If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '    End If

        '    'Quinto Diagnostico
        '    If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Then
        '        Fila = lvDet.Items.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
        '        If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '    End If

        '    'Sexto Diagnostico
        '    If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Then
        '        Fila = lvDet.Items.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
        '        If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '        Fila.SubItems.Add("")
        '    End If
        'Next
        TotalFilasLV = lvDet.Items.Count - 1
        vImpresion = 2

        lblTConsultas.Tag = TConsultas
        lblTConsultas.Text = TConsultas.ToString & " Consultas"
        'ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        BuscarListaMed()
    End Sub

    Private Sub cboTurno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTurno.Click
        BuscarListaMed()
    End Sub

    Private Sub cboTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTurno.SelectedIndexChanged
        BuscarListaMed()
    End Sub

    Private Sub lvConsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConsulta.DoubleClick
        vImpresion = 5
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.SelectedItems(0).SubItems(0).Text <> "" And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar la Atencion de Consulta", "Mensaje de Inrmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If lvDet.SelectedItems(0).SubItems(17).Text = "INTERCONSULTAE" Then
                    objInterconsultaE.EliminarAtencion(lvDet.SelectedItems(0).SubItems(16).Text)
                    btnImprimirHIS_Click(sender, e)
                ElseIf lvDet.SelectedItems(0).SubItems(17).Text = "PROCEDIMIENTO" Then
                    objConsultaCPT.EliminarAtencion(lvDet.SelectedItems(0).SubItems(16).Text)
                ElseIf lvDet.SelectedItems(0).SubItems(17).Text = "CONSULTA" Then
                    objConsulta.EliminarAtencion(lvDet.SelectedItems(0).SubItems(16).Text)
                Else
                    MessageBox.Show("Este tipo de Atenciones no se Pueden Eliminar", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            lvMedico_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        chkCorrelativo.Checked = False
        'btnCancelar_Click(sender, e)
        txtCIE1.Text = "" : txtDes1.Text = "" : txtLab1.Text = "" : cboTD1.Text = ""
        txtCIE2.Text = "" : txtDes2.Text = "" : txtLab2.Text = "" : cboTD2.Text = ""
        txtCIE3.Text = "" : txtDes3.Text = "" : txtLab3.Text = "" : cboTD3.Text = ""
        txtCIE4.Text = "" : txtDes4.Text = "" : txtLab4.Text = "" : cboTD4.Text = ""
        txtCIE5.Text = "" : txtDes5.Text = "" : txtLab5.Text = "" : cboTD5.Text = ""
        txtCIE6.Text = "" : txtDes6.Text = "" : txtLab6.Text = "" : cboTD6.Text = ""
        cboTipoAtencion.Text = ""
        cboEstablecimiento.Text = ""
        cboServicio.Text = ""

        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnNuevo.Enabled = True
        dtpFecNac.Enabled = True
        txtEdad.Enabled = True
        txtEdadM.Enabled = True
        txtEdadD.Enabled = True
        cboTEdad.Enabled = True
        cboTipoEM.Enabled = True
        cboTipoED.Enabled = True
        cboSexo.Enabled = True
        cboDepartamento.Enabled = True
        cboProvincia.Enabled = True
        cboDistrito.Enabled = True
        txtDNI.Enabled = True
        cboTipoEM.Text = "M"
        cboTipoED.Text = "D"

        Dim Fin As Boolean = False
        Dim dsUbigeo As New DataSet
        If lvDet.SelectedItems.Count > 0 Then
            If lvDet.SelectedItems(0).SubItems(16).Text <> "" Then
                If lvDet.SelectedItems(0).SubItems(25).Text = "SI" Then dtpFecNac.Value = lvDet.SelectedItems(0).SubItems(18).Text
                TipoSeleccion = lvDet.SelectedItems(0).SubItems(17).Text
                If TipoSeleccion <> "CONSULTA" Then
                    If lvDet.SelectedItems(0).SubItems(25).Text = "NO" Then chkCorrelativo.Checked = True
                Else
                    chkCorrelativo.Checked = False
                End If
                Operacion = 2
                btnGrabar.Enabled = True
                btnCancelar.Enabled = True
                btnNuevo.Enabled = False

                Select Case lvDet.SelectedItems(0).SubItems(6).Text
                    Case "N"
                        cboEstablecimiento.Text = "NUEVO"
                    Case "C"
                        cboEstablecimiento.Text = "CONTINUADOR"
                    Case "R"
                        cboEstablecimiento.Text = "REINGRESANTE"
                End Select

                Select Case lvDet.SelectedItems(0).SubItems(7).Text
                    Case "N"
                        cboServicio.Text = "NUEVO"
                    Case "C"
                        cboServicio.Text = "CONTINUADOR"
                    Case "R"
                        cboServicio.Text = "REINGRESANTE"
                End Select

                If lvDet.SelectedItems(0).SubItems(14).Text = "10" Then
                    cboTipoAtencion.Text = "PROGRAMA"
                ElseIf lvDet.SelectedItems(0).SubItems(14).Text = "10" Then
                    cboTipoAtencion.Text = "CONVENIO"
                ElseIf lvDet.SelectedItems(0).SubItems(14).Text = "2" Then
                    cboTipoAtencion.Text = "SIS"
                ElseIf lvDet.SelectedItems(0).SubItems(14).Text = "10" Then
                    cboTipoAtencion.Text = "CREDITO"
                ElseIf lvDet.SelectedItems(0).SubItems(14).Text = "4" Then
                    cboTipoAtencion.Text = "SOAT"
                Else
                    cboTipoAtencion.Text = "COMUN"
                End If

                lblHistoria.Tag = lvDet.SelectedItems(0).SubItems(16).Text
                lblHistoria.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(1).Text

                txtDNI.Text = lvDet.SelectedItems(0).SubItems(1).Text
                'txtEdad.Text = lvDet.SelectedItems(0).SubItems(4).Text
                If TipoSeleccion <> "CONSULTA" Then
                    If lvDet.SelectedItems(0).SubItems(25).Text = "SI" Then
                        If lvDet.SelectedItems(0).SubItems(18).Text <> "" Then dtpFecNac.Value = lvDet.SelectedItems(0).SubItems(18).Text Else MessageBox.Show("Debe Definir Fecha de Nacimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
                cboSexo.Text = lvDet.SelectedItems(0).SubItems(19).Text

                EdadA = Val(lvDet.SelectedItems(0).SubItems(20).Text)
                EdadM = Val(lvDet.SelectedItems(0).SubItems(21).Text)
                EdadD = Val(lvDet.SelectedItems(0).SubItems(22).Text)
                If lvDet.SelectedItems(0).SubItems(25).Text = "NO" Then
                    If Val(EdadA) > 0 Then cboTEdad.Text = "A"
                    If Val(EdadM) > 0 Then cboTEdad.Text = "M"
                    If Val(EdadD) > 0 Then cboTEdad.Text = "D"
                End If

                txtEdad.Text = EdadA
                txtEdadM.Text = EdadM
                txtEdadD.Text = EdadD

                'Diagnostico 1
                txtCIE1.Text = lvDet.SelectedItems(0).SubItems(11).Text
                txtDes1.Enabled = False
                txtDes1.Text = lvDet.SelectedItems(0).SubItems(8).Text
                txtDes1.Enabled = True
                txtLab1.Text = lvDet.SelectedItems(0).SubItems(10).Text
                Select Case lvDet.SelectedItems(0).SubItems(9).Text
                    Case "P"
                        cboTD1.Text = "PRESUNTIVO"
                    Case "D"
                        cboTD1.Text = "DEFINITIVO"
                    Case "R"
                        cboTD1.Text = "REPETITIVO"
                End Select

                'Diagnostico 2
                txtCIE2.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(11).Text
                txtDes2.Enabled = False
                txtDes2.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(8).Text
                txtDes2.Enabled = True
                txtLab2.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(10).Text
                Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 1).SubItems(9).Text
                    Case "P"
                        cboTD2.Text = "PRESUNTIVO"
                    Case "D"
                        cboTD2.Text = "DEFINITIVO"
                    Case "R"
                        cboTD2.Text = "REPETITIVO"
                End Select

                'Diagnostico 3
                If Not Fin Then
                    If Not lvDet.SelectedItems(0).Index + 2 > lvDet.Items.Count - 1 Then
                        If lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(16).Text = "" Then
                            txtCIE3.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(11).Text
                            txtDes3.Enabled = False
                            txtDes3.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(8).Text
                            txtDes3.Enabled = True
                            txtLab3.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(10).Text
                            Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 2).SubItems(9).Text
                                Case "P"
                                    cboTD3.Text = "PRESUNTIVO"
                                Case "D"
                                    cboTD3.Text = "DEFINITIVO"
                                Case "R"
                                    cboTD3.Text = "REPETITIVO"
                            End Select
                        Else
                            Fin = True
                        End If
                    End If
                End If

                'Diagnostico 4
                If Not Fin Then
                    If Not lvDet.SelectedItems(0).Index + 3 > lvDet.Items.Count - 1 Then
                        If Not lvDet.SelectedItems(0).Index + 2 > lvDet.Items.Count - 1 Then
                            If lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(16).Text = "" Then
                                txtCIE4.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(11).Text
                                txtDes4.Enabled = False
                                txtDes4.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(8).Text
                                txtDes4.Enabled = True
                                txtLab4.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(10).Text
                                Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 3).SubItems(9).Text
                                    Case "P"
                                        cboTD4.Text = "PRESUNTIVO"
                                    Case "D"
                                        cboTD4.Text = "DEFINITIVO"
                                    Case "R"
                                        cboTD4.Text = "REPETITIVO"
                                End Select
                            Else
                                Fin = True
                            End If
                        End If
                    End If
                End If

                'Diagnostico 5
                If Not Fin Then
                    If Not lvDet.SelectedItems(0).Index + 4 > lvDet.Items.Count - 1 Then
                        If lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(16).Text = "" Then
                            txtCIE5.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(11).Text
                            txtDes5.Enabled = False
                            txtDes5.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(8).Text
                            txtDes5.Enabled = True
                            txtLab5.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(10).Text
                            Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 4).SubItems(9).Text
                                Case "P"
                                    cboTD5.Text = "PRESUNTIVO"
                                Case "D"
                                    cboTD5.Text = "DEFINITIVO"
                                Case "R"
                                    cboTD5.Text = "REPETITIVO"
                            End Select
                        Else
                            Fin = True
                        End If
                    End If
                End If

                'Diagnostico 6
                If Not Fin Then
                    If Not lvDet.SelectedItems(0).Index + 5 > lvDet.Items.Count - 1 Then
                        If lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(16).Text = "" Then
                            txtCIE6.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(11).Text
                            txtDes6.Enabled = False
                            txtDes6.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(8).Text
                            txtDes6.Enabled = True
                            txtLab6.Text = lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(10).Text
                            Select Case lvDet.Items(lvDet.SelectedItems(0).Index + 5).SubItems(9).Text
                                Case "P"
                                    cboTD6.Text = "PRESUNTIVO"
                                Case "D"
                                    cboTD6.Text = "DEFINITIVO"
                                Case "R"
                                    cboTD6.Text = "REPETITIVO"
                            End Select
                        Else
                            Fin = True
                        End If
                    End If
                End If

                dsUbigeo = objUbigeo.BuscarCodigoT(lvDet.SelectedItems(0).SubItems(3).Text)
                If dsUbigeo.Tables(0).Rows.Count > 0 Then
                    cboDepartamento.Text = dsUbigeo.Tables(0).Rows(0)("Departamento")
                    cboDepartamento_SelectedIndexChanged(sender, e)
                    cboProvincia.Text = dsUbigeo.Tables(0).Rows(0)("Provincia")
                    cboProvincia_SelectedIndexChanged(sender, e)
                    cboDistrito.Text = dsUbigeo.Tables(0).Rows(0)("Distrito")
                End If
            End If
        End If
    End Sub

    Private Sub cboDepartamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDepartamento.KeyDown
        If IsNumeric(cboDepartamento.SelectedValue) And e.KeyCode = Keys.Enter Then cboProvincia.Select()
    End Sub

    Private Sub cboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.SelectedIndexChanged
        If IsNumeric(cboDepartamento.SelectedValue) Then
            Dim dsProv As New Data.DataSet
            dsProv = objUbigeo.Provincia(cboDepartamento.SelectedValue)
            cboProvincia.DataSource = dsProv.Tables(0)
            cboProvincia.DisplayMember = "desc_prov"
            cboProvincia.ValueMember = "cod_prov"
            If cboDepartamento.Text = "LA LIBERTAD" Then cboProvincia.Text = "TRUJILLO" Else cboProvincia.Text = ""
        End If
    End Sub

    Private Sub cboProvincia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProvincia.KeyDown
        If IsNumeric(cboProvincia.SelectedValue) And e.KeyCode = Keys.Enter Then cboDistrito.Select()
    End Sub

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        If IsNumeric(cboProvincia.SelectedValue) Then
            Dim dsDist As New Data.DataSet
            dsDist = objUbigeo.Distrito(cboDepartamento.SelectedValue, cboProvincia.SelectedValue)
            cboDistrito.DataSource = dsDist.Tables(0)
            cboDistrito.DisplayMember = "desc_dist"
            cboDistrito.ValueMember = "cod_dist"
            If cboProvincia.Text = "TRUJILLO" Then cboDistrito.Text = "TRUJILLO" Else cboDistrito.Text = ""
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim Edad As String = ""
        Dim TipoEdad As String = ""
        If MessageBox.Show("Esta seguro de Guardar los Cambios", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Validar CIE10
            Dim dsValCie As New DataSet
            If txtCIE1.Text <> "" Then
                dsValCie = objCIE10.Buscar(txtCIE1.Text, 1)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE1.Text = "" : txtDes1.Text = "" : txtCIE1.Select() : Exit Sub
                Else
                    txtDes1.Enabled = False
                    txtDes1.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                    txtDes1.Enabled = True
                End If

            End If

            If txtCIE2.Text <> "" Then
                dsValCie = objCIE10.Buscar(txtCIE2.Text, 1)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE2.Text = "" : txtDes2.Text = "" : txtCIE2.Select() : Exit Sub
                Else
                    txtDes2.Enabled = False
                    txtDes2.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                    txtDes2.Enabled = True
                End If
            End If

            If txtCIE3.Text <> "" Then
                dsValCie = objCIE10.Buscar(txtCIE3.Text, 1)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE3.Text = "" : txtDes3.Text = "" : txtCIE3.Select() : Exit Sub
                Else
                    txtDes3.Enabled = False
                    txtDes3.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                    txtDes3.Enabled = True
                End If
            End If

            If txtCIE4.Text <> "" Then
                dsValCie = objCIE10.Buscar(txtCIE4.Text, 1)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE4.Text = "" : txtDes4.Text = "" : txtCIE4.Select() : Exit Sub
                Else
                    txtDes4.Enabled = False
                    txtDes4.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                    txtDes4.Enabled = True
                End If
            End If

            If txtCIE5.Text <> "" Then
                dsValCie = objCIE10.Buscar(txtCIE5.Text, 1)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Text = "" : txtDes5.Text = "" : txtCIE5.Select() : Exit Sub
                Else
                    txtDes5.Enabled = False
                    txtDes5.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                    txtDes5.Enabled = True
                End If
            End If

            If txtCIE6.Text <> "" Then
                dsValCie = objCIE10.Buscar(txtCIE6.Text, 1)
                If dsValCie.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El codigo CIE 10 no es válido. Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE6.Text = "" : txtDes6.Text = "" : txtCIE6.Select() : Exit Sub
                Else
                    txtDes6.Enabled = False
                    txtDes6.Text = dsValCie.Tables(0).Rows(0)("Descripcion")
                    txtDes6.Enabled = True
                End If
            End If



            'If IsNumeric(lblHistoria.Text) Then MessageBox.Show("El numero de historia no es un valor numerico", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If lblHistoria.Text = "" Then MessageBox.Show("Debe ingresar la Informacion de paciente atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : lblHistoria.Select() : Exit Sub

            'Reglas de Validacion
            If ReglasValidacionCIENut() Then Exit Sub
            If ReglasValidacionCIEMat() Then Exit Sub

            If chkCorrelativo.Checked = False Then
                objHistoria.GrabarDNI(lblHistoria.Text, txtDNI.Text)
                objHistoria.GrabarUbigeo(lblHistoria.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text)
                objHistoria.GrabarFN(lblHistoria.Text, dtpFecNac.Value.ToShortDateString)
            End If

            If cboDepartamento.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Departamento del Paciente Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDepartamento.Select() : Exit Sub
            If cboProvincia.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Provincia del Paciente Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboProvincia.Select() : Exit Sub
            If cboDistrito.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Distrito del Paciente Atendido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDistrito.Select() : Exit Sub

            Dim vUbigeo As String
            vUbigeo = cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue

            If Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "APP" And Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "AAA" Then
                If cboTipoAtencion.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Tipo de Atencion", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoAtencion.Select() : Exit Sub
                If cboEstablecimiento.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Ingreso por Establecimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboEstablecimiento.Select() : Exit Sub
                If cboServicio.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Ingreso al Servicio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboServicio.Select() : Exit Sub
                If cboSexo.Text = "" Then MessageBox.Show("Debe ingresar la Informacion del Sexo", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboSexo.Select() : Exit Sub
                If txtEdad.Text = "" Then MessageBox.Show("Debe ingresar la Informacion de la Edad del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtEdad.Select() : Exit Sub
            End If

            If txtCIE1.Text = "" Then MessageBox.Show("Debe ingresar por lo menos UN Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE1.Select() : Exit Sub
            If txtCIE1.Text <> "" And cboTD1.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD1.Select() : Exit Sub
            If txtCIE2.Text <> "" And cboTD2.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD2.Select() : Exit Sub
            If txtCIE3.Text <> "" And cboTD3.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD3.Select() : Exit Sub
            If txtCIE4.Text <> "" And cboTD4.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD4.Select() : Exit Sub
            If txtCIE5.Text <> "" And cboTD5.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD5.Select() : Exit Sub
            If txtCIE6.Text <> "" And cboTD6.Text = "" Then MessageBox.Show("Debe ingresar el Tipo de Diagnostico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTD6.Select() : Exit Sub

            If Not IsNumeric(cboDepartamento.SelectedValue) Then MessageBox.Show("Debe Seleccionar el Departamento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDepartamento.Select() : Exit Sub
            If Not IsNumeric(cboProvincia.SelectedValue) Then MessageBox.Show("Debe Seleccionar la Provincia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboProvincia.Select() : Exit Sub
            If Not IsNumeric(cboDistrito.SelectedValue) Then MessageBox.Show("Debe Seleccionar la Distrito", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboDistrito.Select() : Exit Sub

            'Dim TAten As String
            'If cboTipoAtencion.Text = "CONVENIO" Then
            '    TAten = "10"
            'ElseIf cboTipoAtencion.Text = "PROGRAMA" Then
            '    TAten = "10"
            'ElseIf cboTipoAtencion.Text = "SIS" Then
            '    TAten = "2"
            'ElseIf cboTipoAtencion.Text = "CREDITO" Then
            '    TAten = "10"
            'ElseIf cboTipoAtencion.Text = "SOAT" Then
            '    TAten = "4"
            'Else
            '    TAten = "1"
            'End If

            EdadA = Val(txtEdad.Text)
            EdadM = Val(txtEdadM.Text)
            EdadD = Val(txtEdadD.Text)
            If Val(EdadA) > 0 Then
                Edad = EdadA : TipoEdad = "A"
            ElseIf Val(EdadM) > 0 Then
                Edad = EdadM : TipoEdad = "M"
            ElseIf Val(EdadD) > 0 Then
                Edad = EdadD : TipoEdad = "D"
            End If

            If Operacion = 1 Then
                If chkCorrelativo.Checked Then
                    NombrePaciente = ""
                    If Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "APP" And Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "AAA" Then
                        objInterconsultaE.GrabarSH(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), lblHistoria.Text, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboTipoAtencion.Text, cboSexo.Text, Edad, TipoEdad, cboTipoAtencion.Text, txtDNI.Text)
                    Else
                        'Grabar APP
                        objInterconsultaE.GrabarSH(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), 0, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboTipoAtencion.Text, cboSexo.Text, Edad, TipoEdad, cboTipoAtencion.Text, lblHistoria.Text)
                    End If
                Else
                    CodCupo = objInterconsultaE.GrabarCodigo(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), lblHistoria.Text, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboTipoAtencion.Text)
                End If
            End If
            If Operacion = 2 Then
                If TipoSeleccion = "CONSULTA" Then
                    objConsulta.ModificarHIS(lblHistoria.Tag, vUbigeo, txtCIE1.Text, txtDes1.Text, cboTD1.Text, txtLab1.Text, txtCIE2.Text, txtDes2.Text, cboTD2.Text, txtLab2.Text, txtCIE3.Text, txtDes3.Text, cboTD3.Text, txtLab3.Text, txtCIE4.Text, txtDes4.Text, cboTD4.Text, txtLab4.Text, txtCIE5.Text, txtDes5.Text, cboTD5.Text, txtLab5.Text, txtCIE6.Text, txtDes6.Text, cboTD6.Text, txtLab6.Text)
                ElseIf TipoSeleccion = "INTERCONSULTAE" Then
                    If chkCorrelativo.Checked Then
                        If Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "APP" And Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "AAA" Then
                            objInterconsultaE.ModificarLabSH(lblHistoria.Tag, dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), lblHistoria.Text, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboSexo.Text, Edad, TipoEdad, cboTipoAtencion.Text, txtDNI.Text)
                        Else
                            'Modificar APP
                            objInterconsultaE.ModificarLabSH(lblHistoria.Tag, dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), 0, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text, cboSexo.Text, Edad, TipoEdad, cboTipoAtencion.Text, lblHistoria.Text)
                        End If
                    Else
                        objInterconsultaE.ModificarLab(lblHistoria.Tag, dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), lblHistoria.Text, NombrePaciente, "", "", "", "", "", "", "", "", "", txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, cboEstablecimiento.Text, cboServicio.Text, lblEspecialidad.Text, lblMedico.Text, cboTD1.Text, "", cboTD2.Text, cboTD3.Text, cboTD4.Text, lblMedico.Tag, cboTurno.Text, lblEspecialidad.Text, txtCIE5.Text, txtDes5.Text, txtCIE6.Text, txtDes6.Text, cboTD5.Text, cboTD6.Text, txtLab1.Text, txtLab2.Text, txtLab3.Text, txtLab4.Text, txtLab5.Text, txtLab6.Text)
                    End If
                End If
            End If
            MessageBox.Show("Datos Guardados Correctamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnCancelar_Click(sender, e)
            lvMedico_SelectedIndexChanged(sender, e)
            btnNuevo.Select()
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnExportarE.Enabled = False
        lblHistoria.Text = ""
        txtEdad.Text = ""
        txtDNI.Text = ""
        cboSexo.Text = ""
        dtpFecNac.Value = Date.Now
        gbConsulta.Visible = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        cboTipoAtencion.Text = ""
        cboEstablecimiento.Text = ""
        cboServicio.Text = ""
        txtEdadM.Text = ""
        txtEdadD.Text = ""
        lblPaciente.Text = ""


        dtpFecNac.Enabled = False
        txtEdad.Enabled = False
        txtEdadM.Enabled = False
        txtEdadD.Enabled = False
        txtEdad.Enabled = False
        txtEdadM.Enabled = False
        txtEdadD.Enabled = False
        cboTEdad.Enabled = False
        cboTipoEM.Enabled = False
        cboTipoED.Enabled = False
        cboSexo.Enabled = False
        cboDepartamento.Enabled = False
        cboProvincia.Enabled = False
        cboDistrito.Enabled = False
        txtDNI.Enabled = False

        cboDepartamento.Text = "LA LIBERTAD"
        cboDepartamento_SelectedIndexChanged(sender, e)
        cboProvincia.Text = "TRUJILLO"
        cboProvincia_SelectedIndexChanged(sender, e)

        If chkNB.Checked = False Then
            txtCIE1.Text = "" : txtDes1.Text = "" : txtLab1.Text = "" : cboTD1.Text = ""
            txtCIE2.Text = "" : txtDes2.Text = "" : txtLab2.Text = "" : cboTD2.Text = ""
            txtCIE3.Text = "" : txtDes3.Text = "" : txtLab3.Text = "" : cboTD3.Text = ""
            txtCIE4.Text = "" : txtDes4.Text = "" : txtLab4.Text = "" : cboTD4.Text = ""
            txtCIE5.Text = "" : txtDes5.Text = "" : txtLab5.Text = "" : cboTD5.Text = ""
            txtCIE6.Text = "" : txtDes6.Text = "" : txtLab6.Text = "" : cboTD6.Text = ""
        End If
    End Sub

    Private Sub txtEdad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdad.KeyDown
        If e.KeyCode = Keys.Enter And txtEdad.Text <> "" Then txtEdadM.Select()
    End Sub

    Private Sub txtDNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyDown
        If e.KeyCode = Keys.Enter Then cboDepartamento.Select()
    End Sub

    Private Sub cboDistrito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDistrito.KeyDown
        If IsNumeric(cboDistrito.SelectedValue) And e.KeyCode = Keys.Enter Then txtCIE1.Select()
    End Sub

    Private Sub txtCIE1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE1.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE1.Text.Length > 0 Then
            'Verificar Entrega de Insumos por Primera vez
            Dim VarAux1 As String
            'Insumos Por Primera Vez
            If (txtCIE1.Text = "Z3003" Or txtCIE1.Text = "Z30051" Or txtCIE1.Text = "Z30052" Or txtCIE1.Text = "Z3006" Or txtCIE1.Text = "Z3008" Or txtCIE1.Text = "Z3009" Or txtCIE1.Text = "Z30091" Or txtCIE1.Text = "Z30092" Or txtCIE1.Text = "Z30093" Or txtCIE1.Text = "Z30094") Then
                If MessageBox.Show("Ud. no puede ingrear la Asignación de Insumos por Primera Vez en esta Posición, Desea Modificación segun el Manual?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    VarAux1 = txtCIE1.Text
                    txtCIE1.Text = "99402"
                    txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                    txtCIE2.Text = VarAux1
                    txtDes2.Enabled = False : txtDes2.Text = DevolverDescripcionCIE(txtCIE2.Text, cboTD2) : txtDes2.Enabled = True
                    VarAux1 = InputBox("Ingrear Nro de Insumos Entregados", "Información de Insumos", 1)
                    txtLab3.Text = VarAux1
                End If
                txtLab1.Select()
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE1.Text = "86592" Then
                txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab1.Text = "RN"
                Else
                    txtLab1.Text = "RP"
                End If
                txtCIE2.Select()
                Exit Sub
            End If


            'Verificar Control Puerperio 59430
            If txtCIE1.Text = "59430" Then
                txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab1.Text = "1"
                Else
                    txtLab1.Text = "2"
                End If
                txtCIE2.Select()
                Exit Sub
            End If

            'Verificar Entrega de Continuador de Insumos
            If (txtCIE1.Text = "Z3043" Or txtCIE1.Text = "Z30451" Or txtCIE1.Text = "Z30452" Or txtCIE1.Text = "Z3046" Or txtCIE1.Text = "Z3048" Or txtCIE1.Text = "Z3049" Or txtCIE1.Text = "Z30491" Or txtCIE1.Text = "Z30492" Or txtCIE1.Text = "Z30493" Or txtCIE1.Text = "Z30494") Then
                txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                If Not txtCIE1.Text = "Z3046" Then
                    VarAux1 = InputBox("Ingrear Nro de Insumos Entregados", "Información de Insumos", 1)
                    txtLab2.Text = VarAux1
                End If
                txtLab1.Select()
                Exit Sub
            End If

            'Verificar Cancer de Mama y Cuello Uterino
            If (txtCIE1.Text = "88141" Or txtCIE1.Text = "Z0143" Or txtCIE1.Text = "Z0142" Or txtCIE1.Text = "87621") Then
                txtDes1.Enabled = False : txtDes1.Text = DevolverDescripcionCIE(txtCIE1.Text, cboTD1) : txtDes1.Enabled = True
                txtCIE2.Text = "99401"
                txtDes2.Enabled = False : txtDes2.Text = DevolverDescripcionCIE("99401", cboTD2) : txtDes2.Enabled = True
                If txtCIE1.Text = "Z0143" Then
                    txtLab3.Text = "MA"
                    If MessageBox.Show("El Resultado Fue NORMAL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab1.Text = "N"
                    Else
                        txtLab1.Text = "A"
                    End If
                    txtLab2.Select()
                Else
                    txtLab3.Text = "CU"
                    If MessageBox.Show("La Atencion es por Primera Vez?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab1.Text = "PV"
                        txtLab2.Text = "1"
                        txtLab3.Select()
                    Else
                        txtLab1.Text = "PC"
                        txtLab2.Select()
                    End If
                End If
                Exit Sub
            End If


            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE1.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE1.Text = txtCIE2.Text Or txtCIE1.Text = txtCIE3.Text Or txtCIE1.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE1.Select() : Exit Sub
                If Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "APP" And Microsoft.VisualBasic.Left(lblHistoria.Text, 3) <> "AAA" Then
                    If chkCorrelativo.Checked Then
                        EdadA = Val(txtEdad.Text)
                        EdadM = Val(txtEdadM.Text)
                        EdadD = Val(txtEdadD.Text)
                    End If
                    'Verificar Edad
                    Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                    If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                        Dim RMin, RMax As Double
                        If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                        If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                        If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                        If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                        If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                        If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                        If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                    End If

                End If
                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes1.Enabled = False
                txtDes1.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes1.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD1.Text = "DEFINITIVO" : txtCIE2.Select()
                txtLab1.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub dtpFecNac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecNac.KeyDown
        If e.KeyCode = Keys.Enter Then cboSexo.Select()
    End Sub

    Private Sub cboSexo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSexo.KeyDown
        If e.KeyCode = Keys.Enter And cboSexo.Text <> "" Then txtEdad.Select()
    End Sub

    Private Sub txtMedico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMedico.TextChanged
        BuscarListaMed()
    End Sub

    Private Sub txtCIE2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE2.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE2.Text.Length > 0 Then

            'Verificar Entrega de Insumos por Primera vez
            Dim VarAux1 As String
            If (txtCIE2.Text = "Z3003" Or txtCIE2.Text = "Z30051" Or txtCIE2.Text = "Z30052" Or txtCIE2.Text = "Z3006" Or txtCIE2.Text = "Z3008" Or txtCIE2.Text = "Z3009" Or txtCIE2.Text = "Z30091" Or txtCIE2.Text = "Z30092" Or txtCIE2.Text = "Z30093" Or txtCIE2.Text = "Z30094") And txtLab3.Text = "" Then
                txtDes2.Enabled = False : txtDes2.Text = DevolverDescripcionCIE(txtCIE2.Text, cboTD2) : txtDes2.Enabled = True
                VarAux1 = InputBox("Ingrear Nro de Insumos Entregados", "Información de Insumos", 1)
                txtLab3.Text = VarAux1
                txtLab2.Select()
                Exit Sub
            End If

            'Verificar Cancer de Mama y Cuello Uterino
            If (txtCIE2.Text = "88141" Or txtCIE2.Text = "Z0143" Or txtCIE2.Text = "Z0142" Or txtCIE2.Text = "87621") Then
                txtDes2.Enabled = False : txtDes2.Text = DevolverDescripcionCIE(txtCIE2.Text, cboTD2) : txtDes2.Enabled = True
                txtCIE3.Text = "99401"
                txtDes3.Enabled = False : txtDes3.Text = DevolverDescripcionCIE("99401", cboTD3) : txtDes3.Enabled = True
                If txtCIE2.Text = "Z0143" Then
                    txtLab4.Text = "MA"
                    If MessageBox.Show("El Resultado Fue NORMAL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab2.Text = "N"
                    Else
                        txtLab2.Text = "A"
                    End If
                    txtLab2.Select()
                Else
                    txtLab4.Text = "CU"
                    If MessageBox.Show("La Atencion es por Primera Vez?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab2.Text = "PV"
                        txtLab3.Text = "1"
                        txtLab4.Select()
                    Else
                        txtLab2.Text = "PC"
                        txtLab3.Select()
                    End If
                End If
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE2.Text = "86592" Then
                txtDes2.Enabled = False : txtDes2.Text = DevolverDescripcionCIE(txtCIE2.Text, cboTD2) : txtDes2.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab2.Text = "RN"
                Else
                    txtLab2.Text = "RP"
                End If
                txtCIE3.Select()
                Exit Sub
            End If

            'Verificar Control Puerperio 59430
            If txtCIE2.Text = "59430" Then
                txtDes2.Enabled = False : txtDes2.Text = DevolverDescripcionCIE(txtCIE2.Text, cboTD2) : txtDes2.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab2.Text = "1"
                Else
                    txtLab2.Text = "2"
                End If
                txtCIE3.Select()
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE2.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE2.Text = txtCIE1.Text Or txtCIE2.Text = txtCIE3.Text Or txtCIE2.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE2.Select() : Exit Sub

                If chkCorrelativo.Checked Then
                    EdadA = Val(txtEdad.Text)
                    EdadM = Val(txtEdadM.Text)
                    EdadD = Val(txtEdadD.Text)
                End If

                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes2.Enabled = False
                txtDes2.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes2.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD2.Text = "DEFINITIVO" : txtCIE3.Select()
                txtLab2.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.Enter And txtCIE2.Text = "" Then txtDes2.Select()
    End Sub

    Private Sub txtCIE3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE3.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE3.Text.Length > 0 Then
            If txtCIE2.Text = "" And txtLab2.Text <> "" Then
                MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCIE3.Text = ""
                txtDes3.Text = ""
                txtLab3.Text = ""
                cboTD3.Text = ""
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE3.Text = "86592" Then
                txtDes3.Enabled = False : txtDes3.Text = DevolverDescripcionCIE(txtCIE3.Text, cboTD3) : txtDes3.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab3.Text = "RN"
                Else
                    txtLab3.Text = "RP"
                End If
                txtCIE4.Select()
                Exit Sub
            End If

            'Verificar Control Puerperio 59430
            If txtCIE3.Text = "59430" Then
                txtDes3.Enabled = False : txtDes3.Text = DevolverDescripcionCIE(txtCIE3.Text, cboTD3) : txtDes3.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab3.Text = "1"
                Else
                    txtLab3.Text = "2"
                End If
                txtCIE2.Select()
                Exit Sub
            End If

            'Verificar Cancer de Mama y Cuello Uterino
            If (txtCIE3.Text = "88141" Or txtCIE3.Text = "Z0143" Or txtCIE3.Text = "Z0142" Or txtCIE3.Text = "87621") Then
                txtDes3.Enabled = False : txtDes3.Text = DevolverDescripcionCIE(txtCIE3.Text, cboTD3) : txtDes3.Enabled = True
                txtCIE4.Text = "99401"
                txtDes4.Enabled = False : txtDes4.Text = DevolverDescripcionCIE("99401", cboTD4) : txtDes4.Enabled = True
                If txtCIE3.Text = "Z0143" Then
                    txtLab5.Text = "MA"
                    If MessageBox.Show("El Resultado Fue NORMAL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab3.Text = "N"
                    Else
                        txtLab3.Text = "A"
                    End If
                    txtLab3.Select()
                Else
                    txtLab5.Text = "CU"
                    If MessageBox.Show("La Atencion es por Primera Vez?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab3.Text = "PV"
                        txtLab4.Text = "1"
                        txtLab5.Select()
                    Else
                        txtLab3.Text = "PC"
                        txtLab4.Select()
                    End If
                End If
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE3.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE3.Text = txtCIE1.Text Or txtCIE3.Text = txtCIE2.Text Or txtCIE3.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE3.Select() : Exit Sub
                If chkCorrelativo.Checked Then
                    EdadA = Val(txtEdad.Text)
                    EdadM = Val(txtEdadM.Text)
                    EdadD = Val(txtEdadD.Text)
                End If
                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes3.Enabled = False
                txtDes3.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes3.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD3.Text = "DEFINITIVO" : txtDes4.Select()
                txtLab3.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.Enter And txtCIE3.Text = "" Then txtDes3.Select()
    End Sub

    Private Sub txtCIE4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE4.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE4.Text.Length > 0 Then
            If txtCIE3.Text = "" And txtLab3.Text <> "" Then
                MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCIE4.Text = ""
                txtDes4.Text = ""
                txtLab4.Text = ""
                cboTD4.Text = ""
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE4.Text = "86592" Then
                txtDes4.Enabled = False : txtDes4.Text = DevolverDescripcionCIE(txtCIE4.Text, cboTD4) : txtDes4.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab4.Text = "RN"
                Else
                    txtLab4.Text = "RP"
                End If
                txtCIE5.Select()
                Exit Sub
            End If

            'Verificar Control Puerperio 59430
            If txtCIE4.Text = "59430" Then
                txtDes4.Enabled = False : txtDes4.Text = DevolverDescripcionCIE(txtCIE4.Text, cboTD4) : txtDes4.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab4.Text = "1"
                Else
                    txtLab4.Text = "2"
                End If
                txtCIE5.Select()
                Exit Sub
            End If

            'Verificar Cancer de Mama y Cuello Uterino
            If (txtCIE4.Text = "88141" Or txtCIE4.Text = "Z0143" Or txtCIE4.Text = "Z0142" Or txtCIE4.Text = "87621") Then
                txtDes4.Enabled = False : txtDes4.Text = DevolverDescripcionCIE(txtCIE4.Text, cboTD4) : txtDes4.Enabled = True
                txtCIE5.Text = "99401"
                txtDes5.Enabled = False : txtDes5.Text = DevolverDescripcionCIE("99401", cboTD5) : txtDes5.Enabled = True
                If txtCIE4.Text = "Z0143" Then
                    txtLab6.Text = "MA"
                    txtLab4.Select()
                Else
                    txtLab6.Text = "CU"
                    If MessageBox.Show("La Atencion es por Primera Vez?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtLab4.Text = "PV"
                        txtLab5.Text = "1"
                        txtLab6.Select()
                    Else
                        txtLab4.Text = "PC"
                        txtLab5.Select()
                    End If
                End If
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE4.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE4.Text = txtCIE1.Text Or txtCIE4.Text = txtCIE2.Text Or txtCIE4.Text = txtCIE3.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE4.Select() : Exit Sub
                If chkCorrelativo.Checked Then
                    EdadA = Val(txtEdad.Text)
                    EdadM = Val(txtEdadM.Text)
                    EdadD = Val(txtEdadD.Text)
                End If
                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCUNINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes4.Enabled = False
                txtDes4.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes4.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD4.Text = "DEFINITIVO"
                txtLab4.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCIE5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE5.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE5.Text.Length > 0 Then
            If txtCIE4.Text = "" And txtLab4.Text <> "" Then
                MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCIE5.Text = ""
                txtDes5.Text = ""
                txtLab5.Text = ""
                cboTD5.Text = ""
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE5.Text = "86592" Then
                txtDes5.Enabled = False : txtDes5.Text = DevolverDescripcionCIE(txtCIE5.Text, cboTD5) : txtDes5.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab5.Text = "RN"
                Else
                    txtLab5.Text = "RP"
                End If
                txtCIE6.Select()
                Exit Sub
            End If

            'Verificar Control Puerperio 59430
            If txtCIE5.Text = "59430" Then
                txtDes5.Enabled = False : txtDes5.Text = DevolverDescripcionCIE(txtCIE5.Text, cboTD5) : txtDes5.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab5.Text = "1"
                Else
                    txtLab5.Text = "2"
                End If
                txtCIE6.Select()
                Exit Sub
            End If

            'Verificar Cancer de Mama y Cuello Uterino
            If (txtCIE5.Text = "88141" Or txtCIE5.Text = "Z0143" Or txtCIE5.Text = "Z0142" Or txtCIE5.Text = "87621") Then
                MessageBox.Show("No puede ser asignado diagnostico en esta posición segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE5.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE5.Text = txtCIE1.Text Or txtCIE5.Text = txtCIE2.Text Or txtCIE5.Text = txtCIE3.Text Or txtCIE5.Text = txtCIE4.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Select() : Exit Sub
                If chkCorrelativo.Checked Then
                    EdadA = Val(txtEdad.Text)
                    EdadM = Val(txtEdadM.Text)
                    EdadD = Val(txtEdadD.Text)
                End If
                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes5.Enabled = False
                txtDes5.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes5.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD5.Text = "DEFINITIVO" : txtCIE6.Select()
                txtLab5.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.Enter And txtCIE5.Text = "" Then txtDes5.Select()
    End Sub

    Private Sub txtCIE5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE5.TextChanged

    End Sub

    Private Sub txtCIE6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE6.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE6.Text.Length > 0 Then
            If txtCIE5.Text = "" And txtLab5.Text <> "" Then
                MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCIE6.Text = ""
                txtDes6.Text = ""
                txtLab6.Text = ""
                cboTD6.Text = ""
                Exit Sub
            End If

            'Verificar Sifilis 86592
            If txtCIE6.Text = "86592" Then
                txtDes6.Enabled = False : txtDes6.Text = DevolverDescripcionCIE(txtCIE6.Text, cboTD6) : txtDes6.Enabled = True
                If MessageBox.Show("El resultado es NEGATIVO", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab6.Text = "RN"
                Else
                    txtLab6.Text = "RP"
                End If
                cboTipoAtencion.Select()
                Exit Sub
            End If

            'Verificar Control Puerperio 59430
            If txtCIE6.Text = "59430" Then
                txtDes6.Enabled = False : txtDes6.Text = DevolverDescripcionCIE(txtCIE6.Text, cboTD6) : txtDes6.Enabled = True
                If MessageBox.Show("La Atencion Corresponde al PRIMER CONTROL?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtLab6.Text = "1"
                Else
                    txtLab6.Text = "2"
                End If
                cboTipoAtencion.Select()
                Exit Sub
            End If

            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE10.Buscar(txtCIE6.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If txtCIE6.Text = txtCIE1.Text Or txtCIE6.Text = txtCIE2.Text Or txtCIE6.Text = txtCIE3.Text Or txtCIE6.Text = txtCIE4.Text Or txtCIE6.Text = txtCIE5.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Select() : Exit Sub
                If chkCorrelativo.Checked Then
                    EdadA = Val(txtEdad.Text)
                    EdadM = Val(txtEdadM.Text)
                    EdadD = Val(txtEdadD.Text)
                End If
                'Verificar Edad
                Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
                If dsTabla.Tables(0).Rows(0)("MinTipo") <> "" Then
                    Dim RMin, RMax As Double
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsTabla.Tables(0).Rows(0)("MinEdad"))

                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 360
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad")) * 30
                    If dsTabla.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsTabla.Tables(0).Rows(0)("MaxEdad"))

                    If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsTabla.Tables(0).Rows(0)("MinEdad") & " " & dsTabla.Tables(0).Rows(0)("MinTipo") & " y " & dsTabla.Tables(0).Rows(0)("MaxEdad") & " " & dsTabla.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                End If


                'Verificar Sexo
                If dsTabla.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "MASCULINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "FEMENINO" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


                txtDes6.Enabled = False
                txtDes6.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDes6.Enabled = True
                If dsTabla.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD6.Text = "DEFINITIVO" : btnGrabar.Select()
                txtLab6.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.Enter And txtCIE6.Text = "" Then txtDes6.Select()
    End Sub

    Private Sub txtCIE6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE6.TextChanged

    End Sub

    Private Sub cboTD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD1.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE2.Select()
    End Sub

    Private Sub cboTD1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD1.SelectedIndexChanged

    End Sub

    Private Sub cboTD2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD2.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE3.Select()
    End Sub

    Private Sub cboTD2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD2.SelectedIndexChanged

    End Sub

    Private Sub cboTD3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD3.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE4.Select()
    End Sub

    Private Sub cboTD3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD3.SelectedIndexChanged

    End Sub

    Private Sub cboTD4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD4.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE5.Select()
    End Sub

    Private Sub cboTD4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD4.SelectedIndexChanged

    End Sub

    Private Sub cboTD5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD5.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then txtCIE6.Select()
    End Sub

    Private Sub cboTD5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD5.SelectedIndexChanged

    End Sub

    Private Sub cboTD6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTD6.KeyDown
        If sender.text <> "" And e.KeyCode = Keys.Enter Then cboTipoAtencion.Select()
    End Sub

    Private Sub cboTD6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTD6.SelectedIndexChanged

    End Sub

    Private Sub txtDes1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes1.KeyDown

    End Sub

    Private Sub txtDes1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes1.TextChanged
        If txtDes1.Text.Length > 1 And txtDes1.Enabled Then nomFiltro = "DESCIE1" : txtDes.Text = txtDes1.Text : gbConsulta.Visible = True : txtDes.Text = txtDes1.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes1.Text.Length = 0 Then txtCIE1.Text = "" : cboTD1.Text = "" : txtLab1.Text = ""
    End Sub

    Private Sub FiltroCIE()
        Select Case Microsoft.VisualBasic.Left(nomFiltro, nomFiltro.Length - 1)
            Case "DESCIE"
                If txtDes.Text.Length = 0 Then Exit Sub
                lvDX.Items.Clear()
                Dim dsTabla As New DataSet
                Dim I As Integer
                Dim Fila As ListViewItem
                dsTabla = objCIE10.Buscar(txtDes.Text, 2)
                For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                    Fila = lvDX.Items.Add(dsTabla.Tables(0).Rows(I)("Codigo"))
                    Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
                Next
        End Select
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If e.KeyCode = Keys.Enter And lvDX.Items.Count > 0 Then lvDX.Select()
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        FiltroCIE()
    End Sub

    Private Sub lvDX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDX.KeyDown
        If e.KeyCode = Keys.Enter And lvDX.SelectedItems.Count > 0 Then
            Dim I As Integer
            Dim dsVer As New DataSet
            dsVer = objCIE10.Buscar(lvDX.SelectedItems(0).SubItems(0).Text, 1)

            If chkCorrelativo.Checked Then
                EdadA = Val(txtEdad.Text)
                EdadM = Val(txtEdadM.Text)
                EdadD = Val(txtEdadD.Text)
            End If

            'Verificar Edad
            Dim EdadActual As Double = EdadA * 360 + EdadM * 30 + EdadD
            If dsVer.Tables(0).Rows(0)("MinTipo") <> "" Then
                Dim RMin, RMax As Double
                If dsVer.Tables(0).Rows(0)("MinTipo") = "A" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad")) * 360
                If dsVer.Tables(0).Rows(0)("MinTipo") = "M" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad")) * 30
                If dsVer.Tables(0).Rows(0)("MinTipo") = "D" Then RMin = Val(dsVer.Tables(0).Rows(0)("MinEdad"))

                If dsVer.Tables(0).Rows(0)("MaxTipo") = "A" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad")) * 360
                If dsVer.Tables(0).Rows(0)("MaxTipo") = "M" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad")) * 30
                If dsVer.Tables(0).Rows(0)("MaxTipo") = "D" Then RMax = Val(dsVer.Tables(0).Rows(0)("MaxEdad"))

                If Not (EdadActual >= RMin And EdadActual <= RMax) Then MessageBox.Show("El diagnostico esta fuera del Rango de Edades que es entre " & dsVer.Tables(0).Rows(0)("MinEdad") & " " & dsVer.Tables(0).Rows(0)("MinTipo") & " y " & dsVer.Tables(0).Rows(0)("MaxEdad") & " " & dsVer.Tables(0).Rows(0)("MaxTipo"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            End If

            'Verificar Sexo
            If dsVer.Tables(0).Rows(0)("Sexo") = "F" And cboSexo.Text = "M" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Femenino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If dsVer.Tables(0).Rows(0)("Sexo") = "M" And cboSexo.Text = "F" Then MessageBox.Show("El diagnostico Corresponde solo al sexo Masculino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub


            Select Case nomFiltro
                Case "DESCIE1"
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE1.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes1.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD1.Text = "DEFINITIVO" : txtCIE2.Select() Else cboTD1.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab1.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE2"
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE2.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes2.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD2.Text = "DEFINITIVO" : txtCIE3.Select() Else cboTD2.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab2.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE3"
                    For I = 0 To lvDX.Items.Count - 1
                        If txtCIE2.Text = "" And txtLab2.Text <> "" Then
                            MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtCIE3.Text = ""
                            txtDes3.Text = ""
                            txtLab3.Text = ""
                            cboTD3.Text = ""
                            Exit Sub
                        End If

                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE3.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes3.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD3.Text = "DEFINITIVO" : txtCIE4.Select() Else cboTD3.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab3.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE4"
                    For I = 0 To lvDX.Items.Count - 1
                        If txtCIE3.Text And txtLab3.Text <> "" Then
                            MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtCIE4.Text = ""
                            txtDes4.Text = ""
                            txtLab4.Text = ""
                            cboTD4.Text = ""
                            Exit Sub
                        End If

                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE4.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes4.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD4.Text = "DEFINITIVO" : txtCIE5.Select() Else cboTD4.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab4.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE5"
                    If txtCIE4.Text = "" And txtLab4.Text <> "" Then
                        MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCIE5.Text = ""
                        txtDes5.Text = ""
                        txtLab5.Text = ""
                        cboTD5.Text = ""
                        Exit Sub
                    End If
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE6.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE5.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes5.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD5.Text = "DEFINITIVO" : txtCIE6.Select() Else cboTD5.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab5.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIE6"
                    If txtCIE5.Text = "" And txtLab5.Text <> "" Then
                        MessageBox.Show("Ud no puede Ingrear Mas Diagnosticos Segun Manual", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtCIE6.Text = ""
                        txtDes6.Text = ""
                        txtLab6.Text = ""
                        cboTD6.Text = ""
                        Exit Sub
                    End If
                    For I = 0 To lvDX.Items.Count - 1
                        If lvDX.Items(I).Selected Then
                            If lvDX.Items(I).SubItems(0).Text = txtCIE1.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE2.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE3.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE4.Text Or lvDX.Items(I).SubItems(0).Text = txtCIE5.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCIE6.Text = lvDX.Items(I).SubItems(0).Text
                            txtDes6.Text = lvDX.Items(I).SubItems(1).Text
                            If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD6.Text = "DEFINITIVO" : btnGrabar.Select() Else cboTD6.Select()
                            lvDX.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtLab6.Select()
                            Exit For
                        End If
                    Next
            End Select
        End If
    End Sub

    Private Sub lvDX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDX.SelectedIndexChanged

    End Sub

    Private Sub txtDes2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes2.KeyDown
        If txtCIE2.Text = "" And txtDes2.Text = "" And e.KeyCode = Keys.Enter Then cboTipoAtencion.Select()
    End Sub

    Private Sub txtDes2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes2.TextChanged
        If txtDes2.Text.Length > 1 And txtDes2.Enabled Then nomFiltro = "DESCIE2" : txtDes.Text = txtDes2.Text : gbConsulta.Visible = True : txtDes.Text = txtDes2.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes2.Text.Length = 0 Then txtCIE2.Text = "" : cboTD2.Text = "" : txtLab2.Text = ""
    End Sub

    Private Sub txtDes3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes3.KeyDown
        If txtCIE3.Text = "" And txtDes3.Text = "" And e.KeyCode = Keys.Enter Then cboTipoAtencion.Select()
    End Sub

    Private Sub txtDes3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes3.TextChanged
        If txtDes3.Text.Length > 1 And txtDes3.Enabled Then nomFiltro = "DESCIE3" : txtDes.Text = txtDes3.Text : gbConsulta.Visible = True : txtDes.Text = txtDes3.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes3.Text.Length = 0 Then txtCIE3.Text = "" : cboTD3.Text = "" : txtLab3.Text = ""
    End Sub

    Private Sub txtDes4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes4.KeyDown
        If txtCIE4.Text = "" And txtDes4.Text = "" And e.KeyCode = Keys.Enter Then cboTipoAtencion.Select()
    End Sub

    Private Sub txtDes4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes4.TextChanged
        If txtDes4.Text.Length > 1 And txtDes4.Enabled Then nomFiltro = "DESCIE4" : txtDes.Text = txtDes4.Text : gbConsulta.Visible = True : txtDes.Text = txtDes4.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes4.Text.Length = 0 Then txtCIE4.Text = "" : cboTD4.Text = "" : txtLab4.Text = ""
    End Sub

    Private Sub txtDes5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes5.KeyDown
        If txtCIE5.Text = "" And txtDes5.Text = "" And e.KeyCode = Keys.Enter Then cboTipoAtencion.Select()
    End Sub

    Private Sub txtDes5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes5.TextChanged
        If txtDes5.Text.Length > 1 And txtDes5.Enabled Then nomFiltro = "DESCIE5" : txtDes.Text = txtDes5.Text : gbConsulta.Visible = True : txtDes.Text = txtDes5.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes5.Text.Length = 0 Then txtCIE5.Text = "" : cboTD5.Text = "" : txtLab5.Text = ""
    End Sub

    Private Sub txtDes6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes6.KeyDown
        If txtCIE6.Text = "" And txtDes6.Text = "" And e.KeyCode = Keys.Enter Then cboTipoAtencion.Select()
    End Sub

    Private Sub txtDes6_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles txtDes6.Layout

    End Sub

    Private Sub txtDes6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes6.TextChanged
        If txtDes6.Text.Length > 1 And txtDes6.Enabled Then nomFiltro = "DESCIE6" : txtDes.Text = txtDes6.Text : gbConsulta.Visible = True : txtDes.Text = txtDes6.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
        If txtDes6.Text.Length = 0 Then txtCIE6.Text = "" : cboTD6.Text = "" : txtLab6.Text = ""
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbConsulta.Visible = False
    End Sub

    Private Sub lblEspecialidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEspecialidad.Click

    End Sub

    Private Sub ProcesarMigracion(ByVal IdMedico As String, ByVal Medico As String, ByVal Especialidad As String)
        lvDet.Items.Clear()
        Dim dsTab As New Data.DataSet
        Dim Fila As ListViewItem
        Dim TConsultas As Integer = 0

        lblTConsultas.Tag = 0
        lblTConsultas.Text = 0 & "Consultas"

        Dim I As Integer
        Dim dsMedico As New Data.DataSet
        Dim Año As Integer


        'DNI Medico
        DNI = ""
        dsMedico = objMedico.Medico_BuscarId(IdMedico)
        If dsMedico.Tables(0).Rows.Count > 0 Then DNI = dsMedico.Tables(0).Rows(0)("DNI").ToString

        'Consultas Medicas
        dsTab = objConsulta.GenerarHISTurno(Medico, Especialidad, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = dtpFecha.Value
                dinicio = dsTab.Tables(0).Rows(I)("FNacimiento")
                Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                Años = DateDiff("yyyy", dinicio, dfin)
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
                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If

                'Verificar Dias
                EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento"))
                If Val(EdadD) > dtpFecha.Value.Day Then
                    EdadD = Val(EdadD) - dtpFecha.Value.Day
                ElseIf Val(EdadD) < dtpFecha.Value.Day Then
                    If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                    EdadD = dtpFecha.Value.Day - EdadD
                    EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
                Else
                    EdadD = 0
                End If

                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If
                'EdadA = 0 : Edad = "0"
                'If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                '    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
                '        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                '        If Año > 1 Then
                '            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
                '                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                '            Else
                '                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
                '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                '            End If
                '        Else
                '            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                '                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                '                EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                '                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                '                EdadM = 11
                '                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
                '                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                '                EdadA = 1
                '                EdadM = 0
                '                Edad = "1 A y 0 M"
                '            End If
                '        End If
                '    Else
                '        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                '            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
                '            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
                '            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '            EdadD = 0
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
                '        End If
                '    End If
                'End If
            End If

            Fila.SubItems.Add(Edad)

            If dsTab.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1)) Else Fila.SubItems.Add("")
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdConsulta"))
            Fila.SubItems.Add("CONSULTA")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab6").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next


        'Interconsultas Hospitalizacion
        dsTab = objInterconsulta.GenerarHISTurno(IdMedico, Especialidad, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                EdadA = 0 : Edad = "0"
                If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
                        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                        If Año > 1 Then
                            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
                                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                            Else
                                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                                EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                                EdadM = 11
                                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
                                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                                EdadA = 1
                                EdadM = 0
                                Edad = "1 A y 0 M"
                            End If
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
                            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                            EdadD = 0
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaH"))
            Fila.SubItems.Add("HOSPITALIZACION")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        'Interconsultas Emergencia
        dsTab = objInterconsultaE.GenerarHISTurno(IdMedico, Especialidad, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                EdadA = 0 : Edad = "0"
                If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
                        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                        If Año > 1 Then
                            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
                                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                            Else
                                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                                EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                                EdadM = 11
                                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
                                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                                EdadA = 1
                                EdadM = 0
                                Edad = "1 A y 0 M"
                            End If
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
                            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                            EdadD = 0
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaE"))
            Fila.SubItems.Add("EMERGENCIA")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next


        'PROCEDIMIENTOS
        dsTab = objConsultaCPT.GenerarHISTurno(IdMedico, Especialidad, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                EdadA = 0 : Edad = "0"
                If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
                        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                        If Año > 1 Then
                            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
                                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                            Else
                                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                                EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                                EdadM = 11
                                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
                                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                                EdadA = 1
                                EdadM = 0
                                Edad = "1 A y 0 M"
                            End If
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
                            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                            EdadD = 0
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento")) Else Fila.SubItems.Add("")
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdProcedimiento"))
            Fila.SubItems.Add("PROCEDIMIENTO")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento")) Else Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next
        TotalFilasLV = lvDet.Items.Count - 1
        vImpresion = 2

        lblTConsultas.Tag = TConsultas
        lblTConsultas.Text = TConsultas.ToString & " Consultas"
    End Sub

    Private Sub btnMigrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMigrar.Click
        If NivelSistema <> "ESTADISTICAADM" Then MessageBox.Show("Usuario no tiene Acceso a esta Opción", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim dsRegistro As New DataSet
        dsRegistro = objRegistroHIS.Buscar(dtpFecha.Value.ToShortDateString, cboTurno.Text)
        If dsRegistro.Tables(0).Rows.Count > 0 Then MessageBox.Show("Esta fecha ya fue migrada al sistema, Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If cboEst.Text = "" Then MessageBox.Show("Debe seleccionar un establecimiento", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboEst.Select() : Exit Sub
        Dim CodEstab As String
        Dim CondicionEstablecimiento As Boolean
        If cboEst.Text = "HRDT" Then CodEstab = "000005196"
        If cboEst.Text = "ALBRECHT" Then CodEstab = "000008685"

        If MessageBox.Show("Esta seguro de Migrar la Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            Dim J As Integer

            Dim dsM As New DataSet
            Dim dsLote As New DataSet
            Dim dsParametro As New DataSet
            Dim IdLote As String
            Dim FechaIng As String
            Dim TotalRegistro As String = 0
            Dim TotalPaginas As String = 0
            Dim NivelDigitador As String = 1
            Dim AñoHIS As String = dtpFecha.Value.Year
            Dim MesHIS As String = dtpFecha.Value.Month
            Dim DiaHIS As String = dtpFecha.Value.Day
            Dim CodigoHISA As String
            Dim dsVerRegistros As New DataSet
            Dim LoteInicial, PaginaInicial As String
            Dim NroDNI As String = ""
            Dim UltimoDiagnostico As Boolean
            Dim DiaInicio As Integer = dtpFecha.Value.Day
            Dim TD1, LC1, DX1, TD2, LC2, DX2, TD3, LC3, DX3, TD4, LC4, DX4, TD5, LC5, DX5, TD6, LC6, DX6 As String
            Dim Vacunas As Boolean

            Dim NRegistro As String
            Dim Grupos As Integer = 0
            Dim NroDia As Integer
            BuscarListaMed()
            For NroDia = DiaInicio To dtpF2.Value.Day
                LoteInicial = txtLote.Text
                PaginaInicial = txtPagina.Text
                For I = 0 To lvMedico.Items.Count - 1
                    If cboEst.Text = "HRDT" Then CondicionEstablecimiento = lvMedico.Items(I).SubItems(2).Text <> "ALBRECHT"
                    If cboEst.Text = "ALBRECHT" Then CondicionEstablecimiento = lvMedico.Items(I).SubItems(2).Text = "ALBRECHT"
                    Vacunas = True
                    If chkVacunas.Checked And lvMedico.Items(I).SubItems(2).Text = "VACUNAS" Then Vacunas = False

                    'If lvMedico.Items(I).SubItems(2).Text = "ALBRECHT" Then
                    If CondicionEstablecimiento Then
                        If Vacunas Then
                            dsM = objMedico.Medico_BuscarId(lvMedico.Items(I).SubItems(0).Text)
                            'ProcesarMigracion(lvMedico.Items(I).SubItems(0).Text, lvMedico.Items(I).SubItems(1).Text, lvMedico.Items(I).SubItems(2).Text)
                            MostrarHIS(lvMedico.Items(I).SubItems(0).Text, lvMedico.Items(I).SubItems(1).Text, lvMedico.Items(I).SubItems(2).Text)
                            If lblTConsultas.Tag > 0 Then
                                'Grabar MSTRPERS
                                dsVerRegistros = objNovafis.Buscar("Select * From mstrpers Where CODPSAL='" + dsM.Tables(0).Rows(0)("DNI") + "'")
                                If dsVerRegistros.Tables(0).Rows.Count = 0 Then
                                    FechaIng = Microsoft.VisualBasic.Format(dsM.Tables(0).Rows(0)("FechaIngreso"), "yyyy-MM-dd")
                                    objNovafis.ejecutar("Insert Into mstrpers (CODPSAL, NOMBRE, COD_ESTAB, COD_PROF, COD_COND, COD_COL, COD_DOC, FECHA_ING, ESTADO) VALUES ('" + dsM.Tables(0).Rows(0)("DNI").ToString + "', '" + dsM.Tables(0).Rows(0)("Medico") + "', '" + cboEst.Text + "','" + dsM.Tables(0).Rows(0)("CodigoProfesion") + "','" + dsM.Tables(0).Rows(0)("CodigoCondicion") + "','" + dsM.Tables(0).Rows(0)("TipoColegiatura") + "', '1','" + FechaIng + "','1')", "", "")
                                End If

                                'Grabar Digitador
                                dsVerRegistros = objNovafis.Buscar("Select * From digitad Where DIGITA='" + dsM.Tables(0).Rows(0)("DNI") + "'")
                                If dsVerRegistros.Tables(0).Rows.Count = 0 Then
                                    objNovafis.ejecutar("Insert Into digitad (DIGITA, NOMBRE, CLAVE, NIVEL) VALUES('" + dsM.Tables(0).Rows(0)("DNI").ToString + "', '" + dsM.Tables(0).Rows(0)("Medico") + "', '" + Microsoft.VisualBasic.Left(dsM.Tables(0).Rows(0)("Medico"), 9) + "'," + NivelDigitador + ")", "", "")
                                End If

                                'Generar HISA
                                NRegistro = 0
                                For J = 0 To lvDet.Items.Count - 1
                                    UltimoDiagnostico = False
                                    If lvDet.Items(J).BackColor = Color.Beige Then
                                        'Diagnosticos 01
                                        TD1 = lvDet.Items(J).SubItems(9).Text
                                        LC1 = lvDet.Items(J).SubItems(10).Text
                                        DX1 = lvDet.Items(J).SubItems(11).Text
                                        'Diagnosticos 02
                                        TD2 = lvDet.Items(J + 1).SubItems(9).Text
                                        LC2 = lvDet.Items(J + 1).SubItems(10).Text
                                        DX2 = lvDet.Items(J + 1).SubItems(11).Text
                                        UltimoDiagnostico = False

                                        'Diagnosticos 03
                                        If lvDet.Items.Count > Val(J + 2) Then
                                            If lvDet.Items(J + 2).BackColor <> Color.Beige Then
                                                TD3 = lvDet.Items(J + 2).SubItems(9).Text
                                                LC3 = lvDet.Items(J + 2).SubItems(10).Text
                                                DX3 = lvDet.Items(J + 2).SubItems(11).Text
                                            Else
                                                TD3 = ""
                                                LC3 = ""
                                                DX3 = ""
                                                UltimoDiagnostico = True
                                            End If
                                        Else
                                            'Diagnostico 03
                                            TD3 = ""
                                            LC3 = ""
                                            DX3 = ""
                                            UltimoDiagnostico = True
                                        End If

                                        'Diagnosticos 04
                                        If lvDet.Items.Count > Val(J + 3) And Not UltimoDiagnostico Then
                                            If lvDet.Items(J + 3).BackColor <> Color.Beige Then
                                                TD4 = lvDet.Items(J + 3).SubItems(9).Text
                                                LC4 = lvDet.Items(J + 3).SubItems(10).Text
                                                DX4 = lvDet.Items(J + 3).SubItems(11).Text
                                            Else
                                                TD4 = ""
                                                LC4 = ""
                                                DX4 = ""
                                                UltimoDiagnostico = True
                                            End If
                                        Else
                                            'Diagnostico 04
                                            TD4 = ""
                                            LC4 = ""
                                            DX4 = ""
                                            UltimoDiagnostico = True
                                        End If

                                        'Diagnosticos 05
                                        If lvDet.Items.Count > Val(J + 4) And Not UltimoDiagnostico Then
                                            If lvDet.Items(J + 4).BackColor <> Color.Beige Then
                                                TD5 = lvDet.Items(J + 4).SubItems(9).Text
                                                LC5 = lvDet.Items(J + 4).SubItems(10).Text
                                                DX5 = lvDet.Items(J + 4).SubItems(11).Text
                                            Else
                                                TD5 = ""
                                                LC5 = ""
                                                DX5 = ""
                                                UltimoDiagnostico = True
                                            End If
                                        Else
                                            'Diagnostico 05
                                            TD5 = ""
                                            LC5 = ""
                                            DX5 = ""
                                            UltimoDiagnostico = True
                                        End If

                                        'Diagnosticos 06
                                        If lvDet.Items.Count > Val(J + 5) And Not UltimoDiagnostico Then
                                            If lvDet.Items(J + 5).BackColor <> Color.Beige Then
                                                TD6 = lvDet.Items(J + 5).SubItems(9).Text
                                                LC6 = lvDet.Items(J + 5).SubItems(10).Text
                                                DX6 = lvDet.Items(J + 5).SubItems(11).Text
                                            Else
                                                TD6 = ""
                                                LC6 = ""
                                                DX6 = ""
                                                UltimoDiagnostico = True
                                            End If
                                        Else
                                            'Diagnostico 06
                                            TD6 = ""
                                            LC6 = ""
                                            DX6 = ""
                                            UltimoDiagnostico = True
                                        End If

                                        'Edad
                                        Dim Edad, TEdad As String
                                        If Val(lvDet.Items(J).SubItems(20).Text) > 0 Then
                                            Edad = lvDet.Items(J).SubItems(20).Text
                                            TEdad = "A"
                                        ElseIf Val(lvDet.Items(J).SubItems(21).Text) > 0 Then
                                            Edad = lvDet.Items(J).SubItems(21).Text
                                            TEdad = "M"
                                        ElseIf Val(lvDet.Items(J).SubItems(22).Text) > 0 Then
                                            Edad = lvDet.Items(J).SubItems(22).Text
                                            TEdad = "D"
                                        Else
                                            Edad = 0
                                            TEdad = "D"
                                        End If
                                        Dim dsEdades As New DataSet
                                        Dim ED As String
                                        dsEdades = objEdades.BuscarCodigo(Edad, TEdad)
                                        If dsEdades.Tables(0).Rows.Count > 0 Then ED = dsEdades.Tables(0).Rows(0)("IdEdad") Else ED = 0

                                        'Estado
                                        Dim dsEstado As New DataSet
                                        Dim EST As String = "0"
                                        If DX1 <> "" Then
                                            dsEstado = objEstados.Buscar(DX1)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX2 <> "" Then
                                            dsEstado = objEstados.Buscar(DX2)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX3 <> "" Then
                                            dsEstado = objEstados.Buscar(DX3)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX4 <> "" Then
                                            dsEstado = objEstados.Buscar(DX4)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX5 <> "" Then
                                            dsEstado = objEstados.Buscar(DX5)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX6 <> "" Then
                                            dsEstado = objEstados.Buscar(DX6)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If TD1 = "G" Then EST = "G"
                                        If TD2 = "G" Then EST = "G"
                                        If TD3 = "G" Then EST = "G"
                                        If TD4 = "G" Then EST = "G"
                                        If TD5 = "G" Then EST = "G"
                                        If TD6 = "G" Then EST = "G"

                                        NRegistro = Val(NRegistro) + 1
                                        TotalRegistro = Val(TotalRegistro) + 1

                                        If Val(NRegistro) = 25 Then
                                            txtPagina.Text = Val(txtPagina.Text) + 1
                                            TotalPaginas = Val(TotalPaginas) + 1
                                            If Val(txtPagina.Text) = 21 Then
                                                'LOTES
                                                txtPagina.Text = Val(txtPagina.Text) + 1
                                                objNovafis.ejecutar("Insert Into Lotes(COD_ESTAB,ANO, MES, NOM_LOTE, TOT_PAG, ESTADO, PAGINA) VALUES('" + CodEstab + "', " + AñoHIS + ", " + MesHIS + ", '" + txtLote.Text + "', '20', 'C', " + TotalRegistro + ")", "", ",")
                                                txtPagina.Text = 1
                                                TotalPaginas = 1
                                                NumeroLote = Val(NumeroLote) + 1
                                                If NumeroLote = 100 Then
                                                    NumeroLote = 1
                                                    Lote = Chr(Asc(Lote) + 1)
                                                    txtPagina.Text = 1
                                                End If

                                                TotalRegistro = 0
                                            End If
                                            txtLote.Text = Lote & Microsoft.VisualBasic.Right("00" & NumeroLote, 2)
                                            NRegistro = 0
                                        End If
                                    End If
                                Next
                                If Not Val(NRegistro) = 0 Then
                                    txtPagina.Text = Val(txtPagina.Text) + 1
                                    TotalPaginas = Val(TotalPaginas) + 1
                                End If
                                If Val(txtPagina.Text) = 21 Then
                                    'LOTES  
                                    objNovafis.ejecutar("Insert Into Lotes(COD_ESTAB,ANO, MES, NOM_LOTE, TOT_PAG, ESTADO, PAGINA) VALUES('" + CodEstab + "', " + AñoHIS + ", " + MesHIS + ", '" + txtLote.Text + "', '20', 'C', " + TotalRegistro + ")", "", ",")
                                    txtPagina.Text = 1
                                    NumeroLote = Val(NumeroLote) + 1
                                    TotalPaginas = 1
                                    If NumeroLote = 100 Then
                                        NumeroLote = 1
                                        Lote = Chr(Asc(Lote) + 1)
                                        txtPagina.Text = 1
                                    End If
                                    txtLote.Text = Lote & Microsoft.VisualBasic.Right("00" & NumeroLote, 2)
                                    NRegistro = 0
                                    TotalRegistro = 0
                                End If
                            End If
                        End If
                    End If
                    Application.DoEvents()
                Next
                'LOTES      
                txtPagina.Text = Val(txtPagina.Text) - 1
                If Not Val(NRegistro) = 0 Then objNovafis.ejecutar("Insert Into Lotes(COD_ESTAB,ANO, MES, NOM_LOTE, TOT_PAG, ESTADO, PAGINA) VALUES('" + CodEstab + "', " + AñoHIS + ", " + MesHIS + ", '" + txtLote.Text + "', " + txtPagina.Text + ", 'C', " + TotalRegistro + ")", "", ",")


                '++++++++++++++++++++++++++++++++++++INICIO HISA+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Dim dsLoteG As New DataSet
                Dim TotalPaginasG As String = 0
                TotalRegistro = 0
                TotalPaginas = 0
                txtLote.Text = LoteInicial
                txtPagina.Text = PaginaInicial
                NumeroLote = Val(Microsoft.VisualBasic.Right(txtLote.Text, 2))
                NRegistro = 0
                For I = 0 To lvMedico.Items.Count - 1
                    If cboEst.Text = "HRDT" Then CondicionEstablecimiento = lvMedico.Items(I).SubItems(2).Text <> "ALBRECHT"
                    If cboEst.Text = "ALBRECHT" Then CondicionEstablecimiento = lvMedico.Items(I).SubItems(2).Text = "ALBRECHT"

                    Vacunas = True
                    If chkVacunas.Checked And lvMedico.Items(I).SubItems(2).Text = "VACUNAS" Then Vacunas = False

                    If CondicionEstablecimiento Then
                        If Vacunas Then
                            dsM = objMedico.Medico_BuscarId(lvMedico.Items(I).SubItems(0).Text)
                            'ProcesarMigracion(lvMedico.Items(I).SubItems(0).Text, lvMedico.Items(I).SubItems(1).Text, lvMedico.Items(I).SubItems(2).Text)
                            MostrarHIS(lvMedico.Items(I).SubItems(0).Text, lvMedico.Items(I).SubItems(1).Text, lvMedico.Items(I).SubItems(2).Text)
                            If lblTConsultas.Tag > 0 Then
                                'Generar HISA
                                NRegistro = 0
                                For J = 0 To lvDet.Items.Count - 1
                                    UltimoDiagnostico = False
                                    If lvDet.Items(J).BackColor = Color.Beige Then
                                        'Diagnosticos 01
                                        TD1 = lvDet.Items(J).SubItems(9).Text
                                        LC1 = lvDet.Items(J).SubItems(10).Text
                                        DX1 = lvDet.Items(J).SubItems(11).Text
                                        'Diagnosticos 02
                                        TD2 = lvDet.Items(J + 1).SubItems(9).Text
                                        LC2 = lvDet.Items(J + 1).SubItems(10).Text
                                        DX2 = lvDet.Items(J + 1).SubItems(11).Text
                                        UltimoDiagnostico = False

                                        'Diagnosticos 03
                                        If lvDet.Items.Count > Val(J + 2) Then
                                            If lvDet.Items(J + 2).BackColor <> Color.Beige Then
                                                TD3 = lvDet.Items(J + 2).SubItems(9).Text
                                                LC3 = lvDet.Items(J + 2).SubItems(10).Text
                                                DX3 = lvDet.Items(J + 2).SubItems(11).Text
                                            Else
                                                TD3 = ""
                                                LC3 = ""
                                                DX3 = ""
                                                UltimoDiagnostico = True
                                            End If
                                        Else
                                            'Diagnostico 03
                                            TD3 = ""
                                            LC3 = ""
                                            DX3 = ""
                                            UltimoDiagnostico = True
                                        End If

                                        'Diagnosticos 04
                                        If lvDet.Items.Count > Val(J + 3) And Not UltimoDiagnostico Then
                                            If lvDet.Items(J + 3).BackColor <> Color.Beige Then
                                                TD4 = lvDet.Items(J + 3).SubItems(9).Text
                                                LC4 = lvDet.Items(J + 3).SubItems(10).Text
                                                DX4 = lvDet.Items(J + 3).SubItems(11).Text
                                            Else
                                                TD4 = ""
                                                LC4 = ""
                                                DX4 = ""
                                                UltimoDiagnostico = True
                                            End If
                                        Else
                                            'Diagnostico 04
                                            TD4 = ""
                                            LC4 = ""
                                            DX4 = ""
                                            UltimoDiagnostico = True
                                        End If

                                        'Diagnosticos 05
                                        If lvDet.Items.Count > Val(J + 4) And Not UltimoDiagnostico Then
                                            If lvDet.Items(J + 4).BackColor <> Color.Beige Then
                                                TD5 = lvDet.Items(J + 4).SubItems(9).Text
                                                LC5 = lvDet.Items(J + 4).SubItems(10).Text
                                                DX5 = lvDet.Items(J + 4).SubItems(11).Text
                                            Else
                                                TD5 = ""
                                                LC5 = ""
                                                DX5 = ""
                                                UltimoDiagnostico = True
                                            End If
                                        Else
                                            'Diagnostico 05
                                            TD5 = ""
                                            LC5 = ""
                                            DX5 = ""
                                            UltimoDiagnostico = True
                                        End If

                                        'Diagnosticos 06
                                        If lvDet.Items.Count > Val(J + 5) And Not UltimoDiagnostico Then
                                            If lvDet.Items(J + 5).BackColor <> Color.Beige Then
                                                TD6 = lvDet.Items(J + 5).SubItems(9).Text
                                                LC6 = lvDet.Items(J + 5).SubItems(10).Text
                                                DX6 = lvDet.Items(J + 5).SubItems(11).Text
                                            Else
                                                TD6 = ""
                                                LC6 = ""
                                                DX6 = ""
                                                UltimoDiagnostico = True
                                            End If
                                        Else
                                            'Diagnostico 06
                                            TD6 = ""
                                            LC6 = ""
                                            DX6 = ""
                                            UltimoDiagnostico = True
                                        End If

                                        'Edad
                                        Dim Edad, TEdad As String
                                        If Val(lvDet.Items(J).SubItems(20).Text) > 0 Then
                                            Edad = lvDet.Items(J).SubItems(20).Text
                                            TEdad = "A"
                                        ElseIf Val(lvDet.Items(J).SubItems(21).Text) > 0 Then
                                            Edad = lvDet.Items(J).SubItems(21).Text
                                            TEdad = "M"
                                        ElseIf Val(lvDet.Items(J).SubItems(22).Text) > 0 Then
                                            Edad = lvDet.Items(J).SubItems(22).Text
                                            TEdad = "D"
                                        Else
                                            Edad = 0
                                            TEdad = "D"
                                        End If
                                        Dim dsEdades As New DataSet
                                        Dim ED As String
                                        dsEdades = objEdades.BuscarCodigo(Edad, TEdad)
                                        If dsEdades.Tables(0).Rows.Count > 0 Then ED = dsEdades.Tables(0).Rows(0)("IdEdad") Else ED = 0

                                        'Estado
                                        Dim dsEstado As New DataSet
                                        Dim EST As String = "0"
                                        If DX1 <> "" Then
                                            dsEstado = objEstados.Buscar(DX1)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX2 <> "" Then
                                            dsEstado = objEstados.Buscar(DX2)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX3 <> "" Then
                                            dsEstado = objEstados.Buscar(DX3)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX4 <> "" Then
                                            dsEstado = objEstados.Buscar(DX4)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX5 <> "" Then
                                            dsEstado = objEstados.Buscar(DX5)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If DX6 <> "" Then
                                            dsEstado = objEstados.Buscar(DX6)
                                            If dsEstado.Tables(0).Rows.Count > 0 Then EST = "G"
                                        End If
                                        If TD1 = "G" Then EST = "G"
                                        If TD2 = "G" Then EST = "G"
                                        If TD3 = "G" Then EST = "G"
                                        If TD4 = "G" Then EST = "G"
                                        If TD5 = "G" Then EST = "G"
                                        If TD6 = "G" Then EST = "G"

                                        NRegistro = Val(NRegistro) + 1
                                        TotalRegistro = Val(TotalRegistro) + 1
                                        If Val(Edad) = 0 Then Edad = 1
                                        'If DX1 = "APP98" Then
                                        '    MsgBox("HOLA")
                                        'End If
                                        'If Microsoft.VisualBasic.Left(DX1, 3) = "APP" Then
                                        '    Edad = 0 : TEdad = ""
                                        'End If
                                        'If lvDet.Items(J + 1).SubItems(1).Text = "1126508" Then
                                        '    MsgBox("HOLA")
                                        'End If

                                        'HISA
                                        dsLoteG = objNovafis.Buscar("Select * From lotes Where NOM_LOTE='" + txtLote.Text + "'")
                                        TotalPaginasG = 0
                                        If dsLoteG.Tables(0).Rows.Count > 0 Then TotalPaginasG = dsLoteG.Tables(0).Rows(0)("TOT_PAG")
                                        CodigoHISA = CodEstab & AñoHIS & MesHIS & txtLote.Text & Microsoft.VisualBasic.Right("000" & TotalPaginas, 3) & Microsoft.VisualBasic.Right("00" & txtPagina.Text, 2) & Microsoft.VisualBasic.Right("00" & NRegistro, 2)
                                        objNovafis.ejecutar("Insert Into HISA(ID, COD_ESTAB, ANO, MES, NOM_LOTE, NUM_PAG, NUM_REG, DIA, FICHAFAM, UBIGEO, EDAD, TIP_EDAD, SEXO, ESTABLEC, SERVICIO, TD1, LC1, DX1, TD2, LC2, DX2, TD3, LC3, DX3, TD4, LC4, DX4, TD5, LC5, DX5, TD6, LC6, DX6, CODPSAL, DIGITA, COD_SERVSA, MT, CF, ET, PAIS, COD_DOC, FAMILIA, DNI, EST, ED) " & _
                                                            "VALUES('" + CodigoHISA + "', '" + CodEstab + "', " + AñoHIS + ", " + MesHIS + ", '" + txtLote.Text + "', " + txtPagina.Text + ", " + NRegistro + ", " + DiaHIS + ", '" + lvDet.Items(J + 1).SubItems(1).Text + "', " & _
                                                            "'" + lvDet.Items(J).SubItems(3).Text + "', " + Edad + ", '" + TEdad + "', '" + Microsoft.VisualBasic.Left(lvDet.Items(J).SubItems(19).Text, 1) + "', '" + lvDet.Items(J).SubItems(6).Text + "', '" + lvDet.Items(J).SubItems(7).Text + "', " & _
                                                            "'" + TD1 + "', '" + LC1 + "', '" + DX1 + "', '" + TD2 + "', '" + LC2 + "', '" + DX2 + "', '" + TD3 + "', '" + LC3 + "', '" + DX3 + "', '" + TD4 + "', '" + LC4 + "', '" + DX4 + "', '" + TD5 + "', '" + LC5 + "', '" + DX5 + "', '" + TD6 + "', '" + LC6 + "', '" + DX6 + "', " & _
                                                            "'" + dsM.Tables(0).Rows(0)("DNI").ToString + "', '" + dsM.Tables(0).Rows(0)("DNI") + "', '" + lvMedico.Items(I).SubItems(4).Text + "', '" + Microsoft.VisualBasic.Left(cboTurno.Text, 1) + "', '" + lvDet.Items(J).SubItems(14).Text + "', '80', 'PER','1','00', '" + Microsoft.VisualBasic.Right("00000000" & lvDet.Items(J).SubItems(1).Text, 8) + "', '" + EST + "', '" + ED + "')", "", "")

                                        If Val(NRegistro) = 25 Then
                                            txtPagina.Text = Val(txtPagina.Text) + 1
                                            TotalPaginas = Val(TotalPaginas) + 1

                                            If Val(txtPagina.Text) = 21 Then
                                                txtPagina.Text = 1
                                                TotalPaginas = 1
                                                NumeroLote = Val(NumeroLote) + 1
                                                If NumeroLote = 100 Then
                                                    NumeroLote = 1
                                                    Lote = Chr(Asc(Lote) + 1)
                                                    txtPagina.Text = 1
                                                End If
                                                TotalRegistro = 0
                                            End If
                                            txtLote.Text = Lote & Microsoft.VisualBasic.Right("00" & NumeroLote, 2)
                                            NRegistro = 0
                                        End If
                                    End If
                                Next
                                If Not Val(NRegistro) = 0 Then
                                    txtPagina.Text = Val(txtPagina.Text) + 1
                                    TotalPaginas = Val(TotalPaginas) + 1
                                End If
                                If Val(txtPagina.Text) = 21 Then
                                    txtPagina.Text = 1
                                    NumeroLote = Val(NumeroLote) + 1
                                    TotalPaginas = 1
                                    If NumeroLote = 100 Then
                                        NumeroLote = 1
                                        Lote = Chr(Asc(Lote) + 1)
                                        txtPagina.Text = 1
                                    End If
                                    txtLote.Text = Lote & Microsoft.VisualBasic.Right("00" & NumeroLote, 2)
                                    TotalRegistro = 0
                                End If
                            End If
                        End If
                    End If
                    Application.DoEvents()
                Next
                '+++++++++++++++++++++++++++++++++++++FIN HISA+++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                NumeroLote = Val(NumeroLote) + 1
                txtPagina.Text = 1
                If NumeroLote = 100 Then
                    NumeroLote = 1
                    Lote = Chr(Asc(Lote) + 1)
                End If
                txtLote.Text = Lote & Microsoft.VisualBasic.Right("00" & NumeroLote, 2)


                objLote.Actualizar(Lote, NumeroLote, txtPagina.Text)

                Dim dsLH As New DataSet
                dsLH = objLote.Buscar
                Lote = dsLH.Tables(0).Rows(0)("Lote")
                NumeroLote = dsLH.Tables(0).Rows(0)("Numero")
                PaginaLote = dsLH.Tables(0).Rows(0)("Pagina")

                txtLote.Text = dsLH.Tables(0).Rows(0)("Lote") & Microsoft.VisualBasic.Right("00" & dsLH.Tables(0).Rows(0)("Numero"), 2)
                txtPagina.Text = dsLH.Tables(0).Rows(0)("Pagina")

                'objRegistroHIS.Grabar(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, Date.Now.ToShortTimeString, cboTurno.Text)
                dtpFecha.Value = DateAdd(DateInterval.Day, 1, dtpFecha.Value)
                AñoHIS = dtpFecha.Value.Year
                MesHIS = dtpFecha.Value.Month
                DiaHIS = dtpFecha.Value.Day

                Application.DoEvents()
            Next
            MessageBox.Show("Migración Realizada Satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub lblHistoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHistoria.Click

    End Sub

    Private Sub lblHistoria_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHistoria.DoubleClick

    End Sub

    Private Function VerificarMedico(ByVal cMedico As String) As Boolean
        VerificarMedico = False
        Dim I As Integer
        For I = 0 To lvMedico.Items.Count - 1
            If Val(cMedico) = lvMedico.Items(I).SubItems(0).Text Then VerificarMedico = True : Exit For
        Next
    End Function

    Private Sub lvMedicos1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMedicos1.DoubleClick
        If lvMedicos1.SelectedItems.Count > 0 Then
            If VerificarMedico(lvMedicos1.SelectedItems(0).SubItems(0).Text) Then MessageBox.Show("Medico ya fue asignado en lista", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim Fila As ListViewItem
            Fila = lvMedico.Items.Add(lvMedicos1.SelectedItems(0).SubItems(0).Text)
            Fila.SubItems.Add(lvMedicos1.SelectedItems(0).SubItems(1).Text)
            Fila.SubItems.Add(lvMedicos1.SelectedItems(0).SubItems(2).Text)
            Fila.SubItems.Add(lvMedicos1.SelectedItems(0).SubItems(3).Text)
            Fila.SubItems.Add(lvMedicos1.SelectedItems(0).SubItems(4).Text)
        End If
    End Sub

  

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        If txtDNI.Text <> "" And txtDNI.Text.Length <> 8 Then MessageBox.Show("Debe ingresar un Nro de DNI igual a 8 Dígitos", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDNI.Select() : Exit Sub
        If lblMedico.Text = "" Then MessageBox.Show("Debe seleccionar un profesional para asigarle la atención", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : lvMedico.Select() : Exit Sub
        cboTEdad.Enabled = False
        cboTEdad.Text = "A"
        cboTipoEM.Enabled = False
        cboTipoEM.Text = "M"
        cboTipoED.Enabled = False
        cboTipoED.Text = "D"

        dtpFecNac.Enabled = True
        txtEdad.Enabled = True
        txtEdadM.Enabled = True
        txtEdadD.Enabled = True
        cboTEdad.Enabled = True
        cboTipoEM.Enabled = True
        cboTipoED.Enabled = True
        cboSexo.Enabled = True
        cboDepartamento.Enabled = True
        cboProvincia.Enabled = True
        cboDistrito.Enabled = True
        txtDNI.Enabled = True

        If chkCorrelativo.Checked = False Then
            Dim Historia As String
            Historia = InputBox("Ingresar Nro de Historia")

            If Not IsNumeric(Historia) Then MessageBox.Show("Debe ingresar Nro de Historia Clínica", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            Dim dsTab As New DataSet
            dsTab = objHistoria.BuscarHistoria(Historia)
            If dsTab.Tables(0).Rows.Count = 0 Then MessageBox.Show("No existe Historia Clínica Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            lblHistoria.Text = Historia
            NombrePaciente = dsTab.Tables(0).Rows(0)("Apaterno") & " " & dsTab.Tables(0).Rows(0)("Amaterno") & " " & dsTab.Tables(0).Rows(0)("Nombres")
            If dsTab.Tables(0).Rows(0)("FNACIMIENTO").ToString = "" Then
                Dim NFecha As String
                NFecha = InputBox("Ingrese Fecha de Nacimiento de Paciente (DD/MM/YYYY)", "Datos de Paciente")
                If Not IsDate(NFecha) Then MessageBox.Show("Formato de Fecha no es Valida, debe ingresar en formato DD/MM/YYYY" & Chr(13) & "Ingrese Nuevamente la Información del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
                objHistoria.GrabarFN(lblHistoria.Text, NFecha)
                dsTab = objHistoria.BuscarHistoria(Historia)
            End If

            dtpFecNac.Value = dsTab.Tables(0).Rows(0)("FNACIMIENTO").ToString
            cboSexo.Text = dsTab.Tables(0).Rows(0)("SEXO").ToString
            'Edad Paciente
            If dsTab.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                lblPaciente.Text = dsTab.Tables(0).Rows(0)("Apaterno") & " " & dsTab.Tables(0).Rows(0)("Amaterno") & " " & dsTab.Tables(0).Rows(0)("Nombres")
                EdadA = 0 : Edad = "0"
                If dsTab.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                    Dim Dias As Integer, Meses As Integer, Años As Integer
                    Dim DiasMes As Integer
                    Dim dfin, dinicio As Date
                    dfin = dtpFecha.Value
                    dinicio = dsTab.Tables(0).Rows(0)("FNacimiento")
                    Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                    Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                    Años = DateDiff("yyyy", dinicio, dfin)
                    'Verificar Dias
                    If Meses = 0 And Años = 0 Then
                        EdadA = 0
                        EdadM = 0
                        Dias = Math.Abs(Dias)
                        EdadD = Dias
                    Else
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
                        If Val(EdadA) > 0 Then
                            Edad = EdadA & "A " & EdadM & "M"
                        Else
                            Edad = EdadM & "M " & EdadD & "D"
                        End If
                        'EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento"))
                        'If Val(EdadD) > dtpFecha.Value.Day Then
                        '    EdadD = Val(EdadD) - dtpFecha.Value.Day
                        'ElseIf Val(EdadD) < dtpFecha.Value.Day Then
                        '    If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                        '    EdadD = dtpFecha.Value.Day - EdadD
                        '    EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
                        'Else
                        '    EdadD = 0
                        'End If
                    End If

                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                End If

                '    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) > 0 Then
                '        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)
                '        If Año > 0 Then
                '            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Month Then
                '                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)
                '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12
                '                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M"
                '            Else
                '                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)) - 1
                '                If Val(EdadA) > 0 Then
                '                    EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12
                '                    Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M"
                '                Else
                '                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Day Then
                '                        EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12
                '                        EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")))
                '                        If Date.Now.Day >= Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")) Then
                '                            EdadD = Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento"))
                '                        End If
                '                        Edad = EdadM & " M y " & EdadD & " D"
                '                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) > Date.Now.Day Then
                '                        EdadM = 11
                '                        EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now))
                '                        Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)) & " D"
                '                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) = Date.Now.Day Then
                '                        EdadA = 1
                '                        EdadM = 0
                '                        Edad = "1 A y 0 M"
                '                    End If
                '                End If
                '            End If
                '        Else
                '            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Day Then
                '                EdadM = 12 - Month(dsTab.Tables(0).Rows(0)("FNAcimiento"))
                '                EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")))
                '                Edad = 12 - Month(dsTab.Tables(0).Rows(0)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento"))) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) > Date.Now.Day Then
                '                EdadM = 11
                '                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now))
                '                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now)) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) = Date.Now.Day Then
                '                EdadA = 1
                '                EdadM = 0
                '                Edad = "1 A y 0 M"
                '            End If
                '        End If
                '    Else
                '        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12
                '            EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")))
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento"))) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) > Date.Now.Day Then
                '            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12) - 1
                '            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")) - Date.Now.Day)
                '            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNacimiento")) - Date.Now.Day) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(0)("FNAcimiento")) = Date.Now.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12
                '            EdadD = 0
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                '        End If
                '    End If
                'End If
                Operacion = 1
                btnGrabar.Enabled = True
                btnCancelar.Enabled = True
                btnNuevo.Enabled = False
            End If
            txtEdad.Text = EdadA
            cboTEdad.Text = "A"
            txtEdadM.Text = EdadM
            cboTipoEM.Text = "M"
            txtEdadD.Text = EdadD
            cboTipoED.Text = "D"
            txtDNI.Text = dsTab.Tables(0).Rows(0)("Doc_Identidad").ToString
            If dsTab.Tables(0).Rows(0)("Departamento").ToString <> "" Then
                cboDepartamento.Text = dsTab.Tables(0).Rows(0)("Departamento")
                cboProvincia.Text = dsTab.Tables(0).Rows(0)("Provincia")
                cboDistrito.Text = dsTab.Tables(0).Rows(0)("Distrito")
            Else
                MessageBox.Show("Defina el Departamento correctamente del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboDepartamento.Select()
            End If
            cboTipoAtencion.Text = "COMUN"

            cboEstablecimiento.Text = "NUEVO"
            cboServicio.Text = "NUEVO"

            'Lista de Atencion de Consulta
            lvConsultas.Items.Clear()
            Dim dsConsulta As New Data.DataSet
            Dim FilaC As ListViewItem
            Dim CantEsp As Integer
            Dim UltimoAñoAtendido As Integer
            Dim I As Integer
            CantEsp = 0
            dsConsulta = objCupo.ConsultasPacienteAtendidas(lblHistoria.Text, dtpFecha.Value)
            UltimoAñoAtendido = 0
            For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
                If I > 0 And EspecialidadMedica = dsConsulta.Tables(0).Rows(I)("Consultorio") And UltimoAñoAtendido = 0 Then UltimoAñoAtendido = Microsoft.VisualBasic.Right(dsConsulta.Tables(0).Rows(I)("Fecha"), 4)
                FilaC = lvConsultas.Items.Add(dsConsulta.Tables(0).Rows(I)("Fecha"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Consultorio"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Medico"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
                FilaC.SubItems.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
                If EspMedico = dsConsulta.Tables(0).Rows(I)("Consultorio") Then
                    CantEsp += 1
                End If
            Next

            'Ingreso Centro y Servicio
            If lvConsultas.Items.Count > 1 Then
                If UltimoAñoAtendido = dtpFecha.Value.Year Then
                    cboEstablecimiento.Text = "CONTINUADOR"
                Else
                    cboEstablecimiento.Text = "REINGRESANTE"
                End If
            End If

            If CantEsp > 1 Then
                If UltimoAñoAtendido = dtpFecha.Value.Year Then
                    cboServicio.Text = "CONTINUADOR"
                Else
                    cboServicio.Text = "REINGRESANTE"
                End If
            End If
            txtDNI.Select()
        Else
            Dim Correlativo As String
            Operacion = 1
            Correlativo = InputBox("Ingresar Correlativo de Atención")
            If Microsoft.VisualBasic.Left(Correlativo, 3).ToUpper <> "APP" And Microsoft.VisualBasic.Left(Correlativo, 3).ToUpper <> "AAA" Then
                If Not IsNumeric(Correlativo) Then MessageBox.Show("Debe ingresar Nro Correlativo Válido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Else
                Correlativo = Correlativo.ToUpper
            End If

            lblHistoria.Text = Correlativo
            cboSexo.Text = "FEMENINO"
            cboTipoAtencion.Text = "PROGRAMA"
            cboTEdad.Text = "A"
            If Microsoft.VisualBasic.Left(Correlativo, 3) <> "APP" And Microsoft.VisualBasic.Left(Correlativo, 3) <> "AAA" Then
                cboSexo.Select()
            Else
                txtCIE1.Select()
            End If
            btnGrabar.Enabled = True
            btnCancelar.Enabled = True
            btnNuevo.Enabled = False
        End If
    End Sub

    Private Sub cboTEdad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTEdad.KeyDown
        If e.KeyCode = Keys.Enter And cboTEdad.Text <> "" Then txtEdadM.Select()
    End Sub

    Private Sub cboTEdad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTEdad.SelectedIndexChanged

    End Sub

    Private Sub cboTipoAtencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoAtencion.KeyDown
        If cboTipoAtencion.Text <> "" And e.KeyCode = Keys.Enter Then cboEstablecimiento.Select()
    End Sub

    Private Sub cboTipoAtencion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAtencion.SelectedIndexChanged

    End Sub

    Private Sub cboEstablecimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEstablecimiento.KeyDown
        If e.KeyCode = Keys.Enter And cboEstablecimiento.Text <> "" Then cboServicio.Select()
    End Sub

    Private Sub cboEstablecimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstablecimiento.SelectedIndexChanged

    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And cboServicio.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged

    End Sub

    Private Sub txtLab1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab1.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD1.Select()
    End Sub

    Private Sub txtLab1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab1.TextChanged

    End Sub

    Private Sub txtLab2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab2.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD2.Select()
    End Sub

    Private Sub txtLab2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab2.TextChanged

    End Sub

    Private Sub txtLab3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab3.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD3.Select()
    End Sub

    Private Sub txtLab3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLab3.LostFocus
        If (txtLab2.Text = "MA" Or txtLab2.Text = "CU") And (txtLab3.Text = "G") Then
            MessageBox.Show("Debe registrar en el Primer DX Z359 definitivo y en el Segundo DX la Consejeria", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLab2.Text = ""
            txtLab3.Text = ""
            txtCIE1.Text = "Z359"
            txtDes1.Text = ""
            txtLab1.Text = ""
            cboTD1.Text = ""
            txtCIE1.Select()
        End If
    End Sub

    Private Sub txtLab3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab3.TextChanged

    End Sub

    Private Sub txtLab4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab4.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD4.Select()
    End Sub

    Private Sub txtLab4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab4.TextChanged

    End Sub

    Private Sub txtLab5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab5.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD5.Select()
    End Sub

    Private Sub txtLab5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab5.TextChanged

    End Sub

    Private Sub txtLab6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLab6.KeyDown
        If e.KeyCode = Keys.Enter Then cboTD6.Select()
    End Sub

    Private Sub txtLab6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab6.TextChanged

    End Sub

    Private Sub chkCorrelativo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCorrelativo.CheckedChanged

    End Sub

    Private Sub MostrarHIS(ByVal IdMedico As String, ByVal Medico As String, ByVal Especialidad As String)
        lvDet.Items.Clear()
        Dim dsTab As New Data.DataSet
        Dim Fila As ListViewItem
        Dim TConsultas As Integer = 0

        'If lvMedico.SelectedItems.Count = 0 Then Exit Sub
        lblTConsultas.Tag = 0
        lblTConsultas.Text = 0 & "Consultas"

        Dim I As Integer
        Dim dsMedico As New Data.DataSet
        Dim Año As Integer

        lblMedico.Tag = IdMedico
        lblMedico.Text = Medico
        lblEspecialidad.Text = Especialidad

        'DNI Medico
        DNI = ""
        dsMedico = objMedico.Medico_BuscarId(IdMedico)
        If dsMedico.Tables(0).Rows.Count > 0 Then DNI = dsMedico.Tables(0).Rows(I)("DNI").ToString

        'Consultas Medicas
        dsTab = objConsulta.GenerarHISTurno(Medico, Especialidad, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = dtpFecha.Value
                dinicio = dsTab.Tables(0).Rows(I)("FNacimiento")
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
                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                    EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))
                    If Val(EdadD) > dtpFecha.Value.Day Then
                        EdadD = Val(EdadD) - dtpFecha.Value.Day
                    ElseIf Val(EdadD) < dtpFecha.Value.Day Then
                        If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                        EdadD = dtpFecha.Value.Day - EdadD
                        EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
                    Else
                        EdadD = 0
                    End If
                End If


                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If
            End If

            Fila.SubItems.Add(Edad)

            If dsTab.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1)) Else Fila.SubItems.Add("")
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdConsulta"))
            Fila.SubItems.Add("CONSULTA")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("SI")
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5") <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6") <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab6").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next


        'Interconsultas Hospitalizacion
        dsTab = objInterconsulta.GenerarHISTurno(IdMedico, Especialidad, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = dtpFecha.Value
                dinicio = dsTab.Tables(0).Rows(I)("FNacimiento")
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
                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                    EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))
                    If Val(EdadD) > dtpFecha.Value.Day Then
                        EdadD = Val(EdadD) - dtpFecha.Value.Day
                    ElseIf Val(EdadD) < dtpFecha.Value.Day Then
                        If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                        EdadD = dtpFecha.Value.Day - EdadD
                        EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
                    Else
                        EdadD = 0
                    End If
                End If


                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If

                'EdadA = 0 : Edad = "0"
                'If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                '    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) > 0 Then
                '        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                '        If Año > 1 Then
                '            If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Month Then
                '                EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)
                '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                '            Else
                '                EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1
                '                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M"
                '            End If
                '        Else
                '            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                '                EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                '                EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                '                Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                '                EdadM = 11
                '                EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value))
                '                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value)) & " D"
                '            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                '                EdadA = 1
                '                EdadM = 0
                '                Edad = "1 A y 0 M"
                '            End If
                '        End If
                '    Else
                '        If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < dtpFecha.Value.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '            EdadD = 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y " & 30 - (dtpFecha.Value.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > dtpFecha.Value.Day Then
                '            EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1
                '            EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day)
                '            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - dtpFecha.Value.Day) & " D"
                '        ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = dtpFecha.Value.Day Then
                '            EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12
                '            EdadD = 0
                '            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), dtpFecha.Value) Mod 12 & " M y 0 D"
                '        End If
                '    End If
                'End If
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaH"))
            Fila.SubItems.Add("HOSPITALIZACION")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Fila.SubItems.Add(EdadA)
            Fila.SubItems.Add(EdadM)
            Fila.SubItems.Add(EdadD)
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("SI")
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5") <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6") <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        'Interconsultas Emergencia CH
        dsTab = objInterconsultaE.GenerarHISTurno(IdMedico, Especialidad, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            Dim VerAPP As Boolean = False
            If Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("DNISH").ToString, 3) = "APP" Then VerAPP = True

            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            NombrePaciente = dsTab.Tables(0).Rows(I)("Apaterno") & " " & dsTab.Tables(0).Rows(I)("Amaterno") & " " & dsTab.Tables(0).Rows(I)("Nombres")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = dtpFecha.Value
                dinicio = dsTab.Tables(0).Rows(I)("FNacimiento")
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
                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                    EdadD = Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))
                    If Val(EdadD) > dtpFecha.Value.Day Then
                        EdadD = Val(EdadD) - dtpFecha.Value.Day
                    ElseIf Val(EdadD) < dtpFecha.Value.Day Then
                        If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                        EdadD = dtpFecha.Value.Day - EdadD
                        EdadD = DameDiasMes(dtpFecha.Value.Month) - EdadD
                    Else
                        EdadD = 0
                    End If
                End If


                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If
            End If
            Fila.SubItems.Add(Edad)

            If Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo").ToString, 1))
                Else
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("SexoSH").ToString, 1))
                End If
            Else
                Fila.SubItems.Add("")
            End If
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add("")
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String
            If dsTab.Tables(0).Rows(I)("TipoCupo") = "" Then TCupo = "COMUN" Else TCupo = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaE"))
            Fila.SubItems.Add("INTERCONSULTAE")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString)
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Else
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("SexoSH").ToString)
            End If
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(EdadA)
                Fila.SubItems.Add(EdadM)
                Fila.SubItems.Add(EdadD)
            Else
                If dsTab.Tables(0).Rows(I)("TEdad") = "A" Then
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "M" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad") = "D" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                End If
            End If
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("CSHistoria"))
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad"))
            Else
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)
            End If
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "NO" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            End If
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab6").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        'Interconsultas Emergencia SH
        dsTab = objInterconsultaE.GenerarHISSHTurno(IdMedico, Especialidad, dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            Dim VerAPP As Boolean = False
            If Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("DNISH").ToString, 3) = "APP" Then VerAPP = True


            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)

            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            NombrePaciente = "" 'dsTab.Tables(0).Rows(I)("Apaterno") & " " & dsTab.Tables(0).Rows(I)("Amaterno") & " " & dsTab.Tables(0).Rows(I)("Nombres")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" And Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("FNACIMIENTO").ToString <> "" Then
                    EdadA = 0 : Edad = "0"

                    'F NACIMIENTO '
                    If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                        If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                            Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                            If Año > 1 Then
                                If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                                    EdadA = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                                    EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                    Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                                Else
                                    EdadA = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                                    EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                    Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                                End If
                            Else
                                If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                    EdadM = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento"))
                                    EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                    Edad = 12 - Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                                ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                    EdadM = 11
                                    EdadD = 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now))
                                    Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) & " D"
                                ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                    EdadA = 1
                                    EdadM = 0
                                    Edad = "1 A y 0 M"
                                End If
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                EdadD = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                EdadM = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                                EdadD = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                EdadM = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                                EdadD = 0
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                            End If
                        End If
                    End If
                End If
            Else
                If Not VerAPP Then
                    txtEdad.Text = dsTab.Tables(0).Rows(I)("Edad").ToString
                    Edad = dsTab.Tables(0).Rows(I)("Edad").ToString
                    cboTEdad.Text = dsTab.Tables(0).Rows(I)("TEdad").ToString
                    If dsTab.Tables(0).Rows(I)("TEdad").ToString = "A" Then
                        EdadA = dsTab.Tables(0).Rows(I)("Edad").ToString
                        EdadM = 0
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad").ToString = "M" Then
                        EdadA = 0
                        EdadM = dsTab.Tables(0).Rows(I)("Edad").ToString
                        EdadD = 0
                    End If

                    If dsTab.Tables(0).Rows(I)("TEdad").ToString = "D" Then
                        EdadA = 0
                        EdadM = 0
                        EdadD = dsTab.Tables(0).Rows(I)("Edad")
                    End If
                End If
            End If

            If Not VerAPP Then Fila.SubItems.Add(Edad) Else Fila.SubItems.Add("")

            If Not VerAPP Then
                If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo").ToString, 1))
                Else
                    Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("SexoSH").ToString, 1))
                End If
            Else
                Fila.SubItems.Add("")
            End If
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Dim TCupo As String
            If dsTab.Tables(0).Rows(I)("TipoCupo") = "" Then TCupo = "COMUN" Else TCupo = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "2"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "4"
            Else
                TCupo = "1"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("IdInterconsultaE"))
            Fila.SubItems.Add("INTERCONSULTAE")
            Fila.SubItems.Add("")
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Sexo").ToString)
            Else
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("SexoSH").ToString)
            End If
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "SI" Then
                Fila.SubItems.Add(EdadA)
                Fila.SubItems.Add(EdadM)
                Fila.SubItems.Add(EdadD)
            Else
                If dsTab.Tables(0).Rows(I)("TEdad").ToString = "A" Then
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad").ToString = "M" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                    Fila.SubItems.Add("")
                End If
                If dsTab.Tables(0).Rows(I)("TEdad").ToString = "D" Then
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Edad"))
                End If
            End If
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("CSHistoria"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            If dsTab.Tables(0).Rows(I)("CSHistoria") = "NO" Then
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("TipoAtencion").ToString)
            End If
            lvDet.Items(lvDet.Items.Count - 1).BackColor = Color.Beige
            TConsultas += 1

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            If Not VerAPP Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia")) Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("DNISH"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie3") <> "" Or dsTab.Tables(0).Rows(I)("Lab3").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Cuarto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie4") <> "" Or dsTab.Tables(0).Rows(I)("Lab4").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des4"))
                If dsTab.Tables(0).Rows(I)("Des4") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD3"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab4").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie4"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Quinto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie5").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab5").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des5"))
                If dsTab.Tables(0).Rows(I)("Des5") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD4"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab5").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie5"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If

            'Sexto Diagnostico
            If dsTab.Tables(0).Rows(I)("Cie6").ToString <> "" Or dsTab.Tables(0).Rows(I)("Lab6").ToString <> "" Then
                Fila = lvDet.Items.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des6"))
                If dsTab.Tables(0).Rows(I)("Des6") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD5"), 1))
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab6").ToString)
                Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie6"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
        Next

        TotalFilasLV = lvDet.Items.Count - 1
        vImpresion = 2

        lblTConsultas.Tag = TConsultas
        lblTConsultas.Text = TConsultas.ToString & " Consultas"
        'ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub chkCargar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCargar.CheckedChanged
        BuscarListaMed()
    End Sub

    Private Sub txtEdadM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdadM.KeyDown
        If e.KeyCode = Keys.Enter Then txtEdadD.Select()
    End Sub

    Private Sub txtEdadM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdadM.TextChanged

    End Sub

    Private Sub txtEdadD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdadD.KeyDown
        If e.KeyCode = Keys.Enter Then txtDNI.Select()
    End Sub

    Private Sub txtEdadD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdadD.TextChanged

    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        vImpresion = 1
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub cboEst_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEst.SelectedIndexChanged

    End Sub

    Private Sub txtLote_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLote.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Lote HIS
            Dim dsLH As New DataSet
            dsLH = objLote.Buscar
            Lote = dsLH.Tables(0).Rows(0)("Lote")
            NumeroLote = dsLH.Tables(0).Rows(0)("Numero")
            PaginaLote = dsLH.Tables(0).Rows(0)("Pagina")

            txtLote.Text = dsLH.Tables(0).Rows(0)("Lote") & Microsoft.VisualBasic.Right("00" & dsLH.Tables(0).Rows(0)("Numero"), 2)
            txtPagina.Text = dsLH.Tables(0).Rows(0)("Pagina")
        End If
    End Sub

    Private Sub txtLote_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLote.TextChanged

    End Sub

    Private Sub dtpF2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF2.ValueChanged

    End Sub

    Private Sub gbHIS_Enter(sender As System.Object, e As System.EventArgs) Handles gbHIS.Enter

    End Sub

    Private Sub btnExportarE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarE.Click
        Dim dsVer As New DataSet
        Dim fechaInicio, fechaFin As DateTime
        fechaInicio = dtpFecha.Value
        fechaFin = dtpF2.Value
        If fechaInicio > fechaFin Then
            MessageBox.Show("Verifique el intevalo de FECHAS", "REPORTE EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            dsVer = objConsulta.Reporte_ConsultorioEx(fechaInicio, fechaFin)
            Dim DT As New DataTable
            DT = dsVer.Tables(0)

            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
            Try

                exLibro = exApp.Workbooks.Add
                exHoja = exLibro.Worksheets.Add()
                exHoja.Name = "REPORTE"
                With exHoja
                    .Visible = Excel.XlSheetVisibility.xlSheetVisible
                    .Activate()
                    .Range("A1:L1").Merge()
                    .Range("A1:L1").Value = "HOSPITAL REGIONAL DOCENTE DE TRUJILLO"
                    .Range("A1:L1").Font.Bold = True
                    .Range("A1:L1").Font.Size = 16
                    .Range("A2:L2").Merge()
                    .Range("A2:L2").Value = "REPORTE ESTADISTICO CONSULTA EXTERNA ENTRE EL " & fechaInicio.ToString() & " Y EL " & fechaFin.ToString()
                    .Range("A2:L2").Font.Bold = True
                    .Range("A2:L2").Font.Size = 12
                End With

                ' ¿Cuantas columnas y cuantas filas?
                Dim NCol As Integer = DT.Columns.Count
                Dim NRow As Integer = DT.Rows.Count
                'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
                exHoja.Range("J3:L3").Merge()
                exHoja.Range("J3:L3").Value = "EDAD PACIENTE"
                For i As Integer = 1 To NCol
                    exHoja.Cells.Item(4, i) = DT.Columns(i - 1).ColumnName.ToString
                    'exHoja.Cells.AutoFormat(vFormato)
                Next
                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exHoja.Cells.Item(Fila + 5, Col + 1) = DT.Rows(Fila).Item(Col).ToString()

                    Next
                Next
                'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
                exHoja.Rows.Item(1).Font.Bold = 1
                exHoja.Rows.Item(1).HorizontalAlignment = 3
                exHoja.Columns.AutoFit()
                'Aplicación visible
                exApp.Application.Visible = True
                exHoja = Nothing
                exLibro = Nothing
                exApp = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message, "REPORTE", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If




    End Sub

    Private Sub chkExcel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExcel.CheckedChanged
        If (chkExcel.Checked = True) Then
            btnExportarE.Enabled = True
        Else
            btnExportarE.Enabled = False
        End If
    End Sub
End Class


'Informacion de Migracion por DBF
'Dim dsRegistro As New DataSet
'        dsRegistro = objRegistroHIS.Buscar(dtpFecha.Value.ToShortDateString)
'        If dsRegistro.Tables(0).Rows.Count > 0 Then MessageBox.Show("Esta fecha ya fue migrada al sistema, Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

'        If lblRuta.Text = "" Then MessageBox.Show("Debe seleccionar Ruta de Archivos a Generar", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnAbrir.Select() : Exit Sub

'        If MessageBox.Show("Esta seguro de Migrar la Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
'Dim I As Integer
'Dim J As Integer
'Dim ArchivoHIS1 As String = "HIS1" & Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Month, 2) & Microsoft.VisualBasic.Right(dtpFecha.Value.Year, 2)
'Dim ArchivoHISA As String = "HISA" & Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Month, 2) & Microsoft.VisualBasic.Right(dtpFecha.Value.Year, 2)
'Dim oConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0.1;Data Source=" & lblRuta.Text & ";Extended Properties=""DBASE 5.0;"";")
'            oConn.Open()


''Generar Archivo HIS1
'Dim HIS1 As New OleDbCommand("Create Table " & ArchivoHIS1 & " (COD_2000 char(9), ANO Numeric, MES Numeric, NOM_LOTE char(3), NUM_PAG Numeric, CODIF char(11), COD_SERVSA char(6), PLAZA char(11), ESTA_PAG char(1), TOT_REG Numeric, FLAGENVIO char(1), MT char(1), ST char(1))", oConn)
'            HIS1.ExecuteNonQuery()

''Generar Archivo HISA
'Dim HISA As New OleDbCommand("Create Table " & ArchivoHISA & " (COD_2000 char(9), ANO Numeric, MES Numeric, NOM_LOTE char(3), NUM_PAG Numeric, NUM_REG Numeric, DIA Numeric, FICHAFAM char(10), COD_DPTO char(2), COD_PROV char(2), COD_DIST char(2), EDAD Numeric, TIP_EDAD char(1), SEXO char(1), ESTABLEC char(1), SERVICIO char(1), DIAGNOST1 char(1), LABCONF1 char(1), CODIGO1 char(10), DIAGNOST2 char(1), LABCONF2 char(1), CODIGO2 char(10), DIAGNOST3 char(1), LABCONF3 char(1), CODIGO3 char(10), DIAGNOST4 char(1), LABCONF4 char(1), CODIGO4 char(10), DIAGNOST5 char(1), LABCONF5 char(1), CODIGO5 char(10), DIAGNOST6 char(1), LABCONF6 char(1), CODIGO6 char(10), ESTA_REG char(1), MT char(1), DNI char(18), FI char(2), ET char(2), ST char(1)) ", oConn)
'            HISA.ExecuteNonQuery()


'Dim dsM As New DataSet
'Dim dsLote As New DataSet

'Dim CadenaSQL As String
'Dim NRegistro As Integer = 0
'Dim Grupos As Integer = 0
'            For I = 0 To lvMedico.Items.Count - 1
'                dsM = objMedico.Medico_BuscarId(lvMedico.Items(I).SubItems(0).Text)
'                ProcesarMigracion(lvMedico.Items(I).SubItems(0).Text, lvMedico.Items(I).SubItems(1).Text, lvMedico.Items(I).SubItems(2).Text)
'Dim oCAgregar As New OleDbCommand
'                If lblTConsultas.Tag > 0 Then
''Generar HIS1
'                    oCAgregar.Connection = oConn
'                    oCAgregar.CommandType = CommandType.Text
'                    CadenaSQL = "Insert Into " & ArchivoHIS1 & " (COD_2000, ANO, MES, NOM_LOTE, NUM_PAG, CODIF, COD_SERVSA, PLAZA, ESTA_PAG, TOT_REG, FLAGENVIO, MT, ST) Values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
'                    oCAgregar.CommandText = CadenaSQL
'                    oCAgregar.Parameters.AddWithValue("@COD_2000", "000005196")
'                    oCAgregar.Parameters.AddWithValue("@ANO", dtpFecha.Value.Year.ToString)
'                    oCAgregar.Parameters.AddWithValue("@MES", dtpFecha.Value.Month.ToString)

''Lote
'                    oCAgregar.Parameters.AddWithValue("@NOM_LOTE", txtLote.Text)
'                    oCAgregar.Parameters.AddWithValue("@NUM_PAG", txtPagina.Text)


'                    oCAgregar.Parameters.AddWithValue("@CODIF", "1" & dsM.Tables(0).Rows(0)("DNI") & dsM.Tables(0).Rows(0)("TipoColegiatura"))
'                    oCAgregar.Parameters.AddWithValue("@COD_SERVSA", lvMedico.Items(I).SubItems(4).Text)
'                    oCAgregar.Parameters.AddWithValue("@PLAZA", "1" & dsM.Tables(0).Rows(0)("DNI") & dsM.Tables(0).Rows(0)("TipoColegiatura"))
'                    oCAgregar.Parameters.AddWithValue("@ESTA_PAG", "2")

'                    If lblTConsultas.Tag > 25 Then
'                        Grupos = 25
'                    Else
'                        Grupos = lblTConsultas.Tag
'                    End If

'                    oCAgregar.Parameters.AddWithValue("@TOT_REG", Grupos)
'                    oCAgregar.Parameters.AddWithValue("@FLAGENVIO", "")
'                    oCAgregar.Parameters.AddWithValue("@MT", Microsoft.VisualBasic.Left(cboTurno.Text, 1))
'                    oCAgregar.Parameters.AddWithValue("@ST", "1")
'                    oCAgregar.ExecuteNonQuery()

''Generar HISA
'Dim NroDNI As String = ""
'Dim UltimoDiagnostico As Boolean
'                    For J = 0 To lvDet.Items.Count - 1
'                        UltimoDiagnostico = False
'                        If lvDet.Items(J).BackColor = Color.Beige Then
'Dim oCAgregarH As New OleDbCommand
'                            oCAgregarH.Connection = oConn
'                            oCAgregarH.CommandType = CommandType.Text
'                            CadenaSQL = "Insert Into " & ArchivoHISA & " (COD_2000, ANO, MES, NOM_LOTE, NUM_PAG, NUM_REG, DIA, FICHAFAM, COD_DPTO, COD_PROV, COD_DIST, EDAD, TIP_EDAD, SEXO, ESTABLEC, SERVICIO, DIAGNOST1, LABCONF1, CODIGO1, DIAGNOST2, LABCONF2, CODIGO2, DIAGNOST3, LABCONF3, CODIGO3, DIAGNOST4, LABCONF4, CODIGO4, DIAGNOST5, LABCONF5, CODIGO5, DIAGNOST6, LABCONF6, CODIGO6, ESTA_REG, MT, DNI, FI, ET, ST) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
'                            oCAgregarH.CommandText = CadenaSQL
'                            oCAgregarH.Parameters.AddWithValue("@COD_2000", "000005196")
'                            oCAgregarH.Parameters.AddWithValue("@ANO", dtpFecha.Value.Year.ToString)
'                            oCAgregarH.Parameters.AddWithValue("@MES", dtpFecha.Value.Month.ToString)
'                            oCAgregarH.Parameters.AddWithValue("@NOM_LOTE", txtLote.Text)
'                            oCAgregarH.Parameters.AddWithValue("@NUM_PAG", txtPagina.Text)
'                            NRegistro += 1

'                            oCAgregarH.Parameters.AddWithValue("@NUM_REG", NRegistro)
'                            oCAgregarH.Parameters.AddWithValue("@DIA", dtpFecha.Value.Day.ToString)
'                            oCAgregarH.Parameters.AddWithValue("@FICHAFAM", lvDet.Items(J + 1).SubItems(1).Text)
'                            oCAgregarH.Parameters.AddWithValue("@COD_DPTO", Microsoft.VisualBasic.Left(lvDet.Items(J).SubItems(3).Text, 2))
'                            oCAgregarH.Parameters.AddWithValue("@COD_PROV", Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(lvDet.Items(J).SubItems(3).Text, 4), 2))
'                            oCAgregarH.Parameters.AddWithValue("@COD_DIST", Microsoft.VisualBasic.Right(lvDet.Items(J).SubItems(3).Text, 2))
'                            If Val(lvDet.Items(J).SubItems(20).Text) > 0 Then
'                                oCAgregarH.Parameters.AddWithValue("@EDAD", lvDet.Items(J).SubItems(20).Text)
'                                oCAgregarH.Parameters.AddWithValue("@TIP_EDAD", "A")
'                            ElseIf Val(lvDet.Items(J).SubItems(21).Text) > 0 Then
'                                oCAgregarH.Parameters.AddWithValue("@EDAD", lvDet.Items(J).SubItems(21).Text)
'                                oCAgregarH.Parameters.AddWithValue("@TIP_EDAD", "M")
'                            ElseIf Val(lvDet.Items(J).SubItems(22).Text) > 0 Then
'                                oCAgregarH.Parameters.AddWithValue("@EDAD", lvDet.Items(J).SubItems(22).Text)
'                                oCAgregarH.Parameters.AddWithValue("@TIP_EDAD", "A")
'                            End If
'                            oCAgregarH.Parameters.AddWithValue("@SEXO", Microsoft.VisualBasic.Left(lvDet.Items(J).SubItems(19).Text, 1))
'                            oCAgregarH.Parameters.AddWithValue("@ESTABLEC", lvDet.Items(J).SubItems(6).Text)
'                            oCAgregarH.Parameters.AddWithValue("@SERVICIO", lvDet.Items(J).SubItems(7).Text)
''Diagnosticos 01
'                            oCAgregarH.Parameters.AddWithValue("@DIAGNOST1", lvDet.Items(J).SubItems(9).Text)
'                            oCAgregarH.Parameters.AddWithValue("@LABCONF1", lvDet.Items(J).SubItems(10).Text)
'                            oCAgregarH.Parameters.AddWithValue("@CODIGO1", lvDet.Items(J).SubItems(11).Text)
''Diagnosticos 02
'                            oCAgregarH.Parameters.AddWithValue("@DIAGNOST2", lvDet.Items(J + 1).SubItems(9).Text)
'                            oCAgregarH.Parameters.AddWithValue("@LABCONF2", lvDet.Items(J + 1).SubItems(10).Text)
'                            oCAgregarH.Parameters.AddWithValue("@CODIGO2", lvDet.Items(J + 1).SubItems(11).Text)
'                            UltimoDiagnostico = False
''If lvDet.Items(J + 1).SubItems(1).Text = "703670" Then
''    MsgBox("Hola")
''End If
''Diagnosticos 03
'                            If lvDet.Items.Count > Val(J + 2) Then
'                                If lvDet.Items(J + 2).BackColor <> Color.Beige Then
'                                    oCAgregarH.Parameters.AddWithValue("@DIAGNOST3", lvDet.Items(J + 2).SubItems(9).Text)
'                                    oCAgregarH.Parameters.AddWithValue("@LABCONF3", lvDet.Items(J + 2).SubItems(10).Text)
'                                    oCAgregarH.Parameters.AddWithValue("@CODIGO3", lvDet.Items(J + 2).SubItems(11).Text)
'                                Else
'                                    oCAgregarH.Parameters.AddWithValue("@DIAGNOST3", "")
'                                    oCAgregarH.Parameters.AddWithValue("@LABCONF3", "")
'                                    oCAgregarH.Parameters.AddWithValue("@CODIGO3", "")
'                                    UltimoDiagnostico = True
'                                End If
'                            Else
''Diagnostico 03
'                                oCAgregarH.Parameters.AddWithValue("@DIAGNOST3", "")
'                                oCAgregarH.Parameters.AddWithValue("@LABCONF3", "")
'                                oCAgregarH.Parameters.AddWithValue("@CODIGO3", "")
'                                UltimoDiagnostico = True
'                            End If

''Diagnosticos 04
'                            If lvDet.Items.Count > Val(J + 3) And Not UltimoDiagnostico Then
'                                If lvDet.Items(J + 3).BackColor <> Color.Beige Then
'                                    oCAgregarH.Parameters.AddWithValue("@DIAGNOST4", lvDet.Items(J + 3).SubItems(9).Text)
'                                    oCAgregarH.Parameters.AddWithValue("@LABCONF4", lvDet.Items(J + 3).SubItems(10).Text)
'                                    oCAgregarH.Parameters.AddWithValue("@CODIGO4", lvDet.Items(J + 3).SubItems(11).Text)
'                                Else
'                                    oCAgregarH.Parameters.AddWithValue("@DIAGNOST4", "")
'                                    oCAgregarH.Parameters.AddWithValue("@LABCONF4", "")
'                                    oCAgregarH.Parameters.AddWithValue("@CODIGO4", "")
'                                    UltimoDiagnostico = True
'                                End If
'                            Else
''Diagnostico 04
'                                oCAgregarH.Parameters.AddWithValue("@DIAGNOST4", "")
'                                oCAgregarH.Parameters.AddWithValue("@LABCONF4", "")
'                                oCAgregarH.Parameters.AddWithValue("@CODIGO4", "")
'                                UltimoDiagnostico = True
'                            End If

''Diagnosticos 05
'                            If lvDet.Items.Count > Val(J + 4) And Not UltimoDiagnostico Then
'                                If lvDet.Items(J + 4).BackColor <> Color.Beige Then
'                                    oCAgregarH.Parameters.AddWithValue("@DIAGNOST5", lvDet.Items(J + 4).SubItems(9).Text)
'                                    oCAgregarH.Parameters.AddWithValue("@LABCONF5", lvDet.Items(J + 4).SubItems(10).Text)
'                                    oCAgregarH.Parameters.AddWithValue("@CODIGO5", lvDet.Items(J + 4).SubItems(11).Text)
'                                Else
'                                    oCAgregarH.Parameters.AddWithValue("@DIAGNOST5", "")
'                                    oCAgregarH.Parameters.AddWithValue("@LABCONF5", "")
'                                    oCAgregarH.Parameters.AddWithValue("@CODIGO5", "")
'                                    UltimoDiagnostico = True
'                                End If
'                            Else
''Diagnostico 05
'                                oCAgregarH.Parameters.AddWithValue("@DIAGNOST5", "")
'                                oCAgregarH.Parameters.AddWithValue("@LABCONF5", "")
'                                oCAgregarH.Parameters.AddWithValue("@CODIGO5", "")
'                                UltimoDiagnostico = True
'                            End If

''Diagnosticos 06
'                            If lvDet.Items.Count > Val(J + 5) And Not UltimoDiagnostico Then
'                                If lvDet.Items(J + 5).BackColor <> Color.Beige Then
'                                    oCAgregarH.Parameters.AddWithValue("@DIAGNOST6", lvDet.Items(J + 5).SubItems(9).Text)
'                                    oCAgregarH.Parameters.AddWithValue("@LABCONF6", lvDet.Items(J + 5).SubItems(10).Text)
'                                    oCAgregarH.Parameters.AddWithValue("@CODIGO6", lvDet.Items(J + 5).SubItems(11).Text)
'                                Else
'                                    oCAgregarH.Parameters.AddWithValue("@DIAGNOST6", "")
'                                    oCAgregarH.Parameters.AddWithValue("@LABCONF6", "")
'                                    oCAgregarH.Parameters.AddWithValue("@CODIGO6", "")
'                                    UltimoDiagnostico = True
'                                End If
'                            Else
''Diagnostico 06
'                                oCAgregarH.Parameters.AddWithValue("@DIAGNOST6", "")
'                                oCAgregarH.Parameters.AddWithValue("@LABCONF6", "")
'                                oCAgregarH.Parameters.AddWithValue("@CODIGO6", "")
'                                UltimoDiagnostico = True
'                            End If
'                            oCAgregarH.Parameters.AddWithValue("@ESTA_REG", "2")
'                            oCAgregarH.Parameters.AddWithValue("@MT", Microsoft.VisualBasic.Left(cboTurno.Text, 1))
'                            oCAgregarH.Parameters.AddWithValue("@DNI", "PER1" & Microsoft.VisualBasic.Right("00000000" & lvDet.Items(J).SubItems(1).Text, 8) & "    00")
'                            oCAgregarH.Parameters.AddWithValue("@FI", Val(lvDet.Items(J).SubItems(14).Text))
'                            oCAgregarH.Parameters.AddWithValue("@ET", "80")
'                            oCAgregarH.Parameters.AddWithValue("@ST", "1")

'                            oCAgregarH.ExecuteNonQuery()
'                        End If
'                        If NRegistro = 25 Then
'                            NRegistro = 0
'                            txtPagina.Text = Val(txtPagina.Text) + 1
'                            If Val(txtPagina.Text) > 20 Then
'                                NumeroLote = Val(NumeroLote) + 1
'                                txtPagina.Text = 1
'                                If NumeroLote = 100 Then
'                                    NumeroLote = 1
'                                    Lote = Chr(Asc(Lote) + 1)
'                                End If
'                            End If
'                            txtLote.Text = Lote & Microsoft.VisualBasic.Right("00" & NumeroLote, 2)


''Generar HIS1
'Dim oCAgregarA As New OleDbCommand
'                            oCAgregarA.Connection = oConn
'                            oCAgregarA.CommandType = CommandType.Text
'                            CadenaSQL = "Insert Into " & ArchivoHIS1 & " (COD_2000, ANO, MES, NOM_LOTE, NUM_PAG, CODIF, COD_SERVSA, PLAZA, ESTA_PAG, TOT_REG, FLAGENVIO, MT, ST) Values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
'                            oCAgregarA.CommandText = CadenaSQL
'                            oCAgregarA.Parameters.AddWithValue("@COD_2000", "000005196")
'                            oCAgregarA.Parameters.AddWithValue("@ANO", dtpFecha.Value.Year.ToString)
'                            oCAgregarA.Parameters.AddWithValue("@MES", dtpFecha.Value.Month.ToString)

''Lote
'                            oCAgregarA.Parameters.AddWithValue("@NOM_LOTE", txtLote.Text)
'                            oCAgregarA.Parameters.AddWithValue("@NUM_PAG", txtPagina.Text)


'                            oCAgregarA.Parameters.AddWithValue("@CODIF", "1" & dsM.Tables(0).Rows(0)("DNI") & dsM.Tables(0).Rows(0)("TipoColegiatura"))
'                            oCAgregarA.Parameters.AddWithValue("@COD_SERVSA", lvMedico.Items(I).SubItems(4).Text)
'                            oCAgregarA.Parameters.AddWithValue("@PLAZA", "1" & dsM.Tables(0).Rows(0)("DNI") & dsM.Tables(0).Rows(0)("TipoColegiatura"))
'                            oCAgregarA.Parameters.AddWithValue("@ESTA_PAG", "2")

'                            If Val(lblTConsultas.Tag) > 25 Then
'                                Grupos = Val(lblTConsultas.Tag) - 25
'                            Else
'                                Grupos = lblTConsultas.Tag
'                            End If
'                            lblTConsultas.Tag = Val(lblTConsultas.Tag) - 25
'                            oCAgregarA.Parameters.AddWithValue("@TOT_REG", Grupos)

'                            oCAgregarA.Parameters.AddWithValue("@FLAGENVIO", "")
'                            oCAgregarA.Parameters.AddWithValue("@MT", Microsoft.VisualBasic.Left(cboTurno.Text, 1))
'                            oCAgregarA.Parameters.AddWithValue("@ST", "1")
'                            oCAgregarA.ExecuteNonQuery()

'                        End If
'                    Next
'                End If
'                If Val(lblTConsultas.Tag) > 0 Then
'                    NRegistro = 0
'                    txtPagina.Text = Val(txtPagina.Text) + 1
'                    If Val(txtPagina.Text) > 20 Then
'                        NumeroLote = Val(NumeroLote) + 1
'                        txtPagina.Text = 1
'                        If NumeroLote = 100 Then
'                            NumeroLote = 1
'                            Lote = Chr(Asc(Lote) + 1)
'                        End If
'                    End If
'                    txtLote.Text = Lote & Microsoft.VisualBasic.Right("00" & NumeroLote, 2)
'                End If
'            Next
'            objLote.Actualizar(Lote, NumeroLote, txtPagina.Text)

'Dim dsLH As New DataSet
'            dsLH = objLote.Buscar
'            Lote = dsLH.Tables(0).Rows(0)("Lote")
'            NumeroLote = dsLH.Tables(0).Rows(0)("Numero")
'            PaginaLote = dsLH.Tables(0).Rows(0)("Pagina")

'            txtLote.Text = dsLH.Tables(0).Rows(0)("Lote") & Microsoft.VisualBasic.Right("00" & dsLH.Tables(0).Rows(0)("Numero"), 2)
'            txtPagina.Text = dsLH.Tables(0).Rows(0)("Pagina")

'            objRegistroHIS.Grabar(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, Date.Now.ToShortTimeString)

'            MessageBox.Show("Migración Realizada Satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        End If
