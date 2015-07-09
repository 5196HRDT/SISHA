Imports System.Data.SqlClient
Public Class clsConsultaExterna
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function Buscar(ByVal IdCupo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarExaAtencion(F1 As String, F2 As String, Tipo As String, Area As String, Paciente As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarExaAtencion", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarExaAtencionRayos(ByVal F1 As String, ByVal F2 As String, ByVal Tipo As String, ByVal Area As String, ByVal Paciente As String, ByVal Oper As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarExaAtencionRayos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function


    Public Sub MuestraTomada(IdConsultaExa As String, FechaTomaMuestra As String, HoraTomaMuestra As String, UsuarioTomaMuestra As String, EquipoTomaMuestra As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_MuestraTomada", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        daTabla.SelectCommand.Parameters.Add("@FechaTomaMuestra", SqlDbType.SmallDateTime).Value = FechaTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@HoraTomaMuestra", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraTomaMuestra, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioTomaMuestra", SqlDbType.VarChar).Value = UsuarioTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@EquipoTomaMuestra", SqlDbType.VarChar).Value = EquipoTomaMuestra
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub FijarCupoRayos(ByVal IdConsultaExa As String, ByVal IdCupo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_FijarCupoRayos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarResultado(ByVal IdConsultaExa As String, ByVal Resultado As String, ByVal FechaResultado As String, ByVal HoraResultado As String, ByVal UsuarioResultado As String, ByVal EquipoResultado As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarResultado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        daTabla.SelectCommand.Parameters.Add("@Resultado", SqlDbType.VarChar).Value = Resultado
        daTabla.SelectCommand.Parameters.Add("@FechaResultado", SqlDbType.SmallDateTime).Value = FechaResultado
        daTabla.SelectCommand.Parameters.Add("@HoraResultado", SqlDbType.VarChar).Value = HoraResultado
        daTabla.SelectCommand.Parameters.Add("@EquipoResultado", SqlDbType.VarChar).Value = EquipoResultado
        daTabla.SelectCommand.Parameters.Add("@UsuarioResultado", SqlDbType.VarChar).Value = UsuarioResultado
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarCupo(ByVal IdCupo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarCupo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ListaExamenesImagenes(ByVal IdCupo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_ListaExamenesImagenes", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarExaSISCEMedRX(ByVal IdCupo As String, ByVal IdExamen As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal EquipoRegistro As String, ByVal Tipo As String, ByVal SubTipo As String, ByVal TipoPaciente As String, ByVal NroPReliquidacion As String, ByVal SerieSis As String, ByVal NumeroSis As String, ByVal Historia As String, ByVal Paciente As String, ByVal ServicioCE As String, ByVal Indicacion As String, ByVal Solicitante As String, ByVal IdCCE As String, ByVal Origen As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarExaSISCEMedRX", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = Val(IdCupo)
        daTabla.SelectCommand.Parameters.Add("@IdExamen", SqlDbType.VarChar).Value = IdExamen
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@NroPReliquidacion", SqlDbType.Int).Value = Val(NroPReliquidacion)
        daTabla.SelectCommand.Parameters.Add("@SerieSis", SqlDbType.VarChar).Value = SerieSis
        daTabla.SelectCommand.Parameters.Add("@NumeroSis", SqlDbType.Int).Value = Val(NumeroSis)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente.Trim
        daTabla.SelectCommand.Parameters.Add("@ServicioCE", SqlDbType.VarChar).Value = ServicioCE
        daTabla.SelectCommand.Parameters.Add("@Indicacion", SqlDbType.VarChar).Value = Indicacion
        daTabla.SelectCommand.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Solicitante
        daTabla.SelectCommand.Parameters.Add("@IdCCE", SqlDbType.Int).Value = Val(IdCCE)
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen

        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
