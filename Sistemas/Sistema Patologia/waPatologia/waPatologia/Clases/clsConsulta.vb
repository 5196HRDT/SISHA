Imports System.Data.SqlClient
Public Class clsConsulta
    Public Function Buscar(ByVal IdCupo As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_Buscar", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function AtencionPatologia(ByVal Paciente As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_AtencionPatologia", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarExaMuestraPato(ByVal F1 As String, ByVal F2 As String, ByVal Paciente As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarExaMuestraPato", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub MuestraTomada(ByVal IdConsultaExa As String, ByVal FechaTomaMuestra As String, ByVal HoraTomaMuestra As String, ByVal UsuarioTomaMuestra As String, ByVal EquipoTomaMuestra As String)
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_MuestraTomada", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        daTabla.SelectCommand.Parameters.Add("@FechaTomaMuestra", SqlDbType.SmallDateTime).Value = FechaTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@HoraTomaMuestra", SqlDbType.VarChar).Value = HoraTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@UsuarioTomaMuestra", SqlDbType.VarChar).Value = UsuarioTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@EquipoTomaMuestra", SqlDbType.VarChar).Value = EquipoTomaMuestra
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub ActualizarIndicacion(ByVal IdConsultaExa As String, ByVal Indicacion As String, ByVal Solicitante As String)
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_ActualizarIndicacion", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        daTabla.SelectCommand.Parameters.Add("@Indicacion", SqlDbType.VarChar).Value = Indicacion
        daTabla.SelectCommand.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Solicitante
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarExaSISCEMed(ByVal IdCupo As String, ByVal IdExamen As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal EquipoRegistro As String, ByVal Tipo As String, ByVal SubTipo As String, ByVal TipoPaciente As String, ByVal NroPReliquidacion As String, ByVal SerieSis As String, ByVal NumeroSis As String, ByVal Historia As String, ByVal Paciente As String, ByVal ServicioCE As String, ByVal Indicacion As String, ByVal Solicitante As String)
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarExaSISCEMed", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = Val(IdCupo)
        daTabla.SelectCommand.Parameters.Add("@IdExamen", SqlDbType.VarChar).Value = IdExamen
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Precio * Val(Cantidad)
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

        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function ListaProcPatologia(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_ListaProcPatologia", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
