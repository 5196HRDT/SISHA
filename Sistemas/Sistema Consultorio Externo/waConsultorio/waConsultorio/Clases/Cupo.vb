Imports System.Data.SqlClient
Public Class Cupo

    Public Function Cupos_BuscarAtencion(ByVal FechaCita As String, ByVal Turno As String, ByVal CodMedico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupos_BuscarAtencion", Cn)
        Dim dstabla As New Data.DataSet
        Dim Fecha As String
        Fecha = Left(Format("dd/MM/yyyy", FechaCita), 10)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaCita", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@IdMedico1", SqlDbType.Int).Value = Val(CodMedico)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Cupos_BuscarAtencionSubEspecialidad(ByVal FechaCita As String, ByVal Turno As String, ByVal CodMedico As String, ByVal SubEspecialidad As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupos_BuscarAtencionSubEspecialidad", Cn)
        Dim dstabla As New Data.DataSet
        Dim Fecha As String
        Fecha = Left(Format("dd/MM/yyyy", FechaCita), 10)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaCita", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@IdMedico1", SqlDbType.Int).Value = Val(CodMedico)
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Cupos_BuscarAtencionAtendida(ByVal FechaCita As String, ByVal Turno As String, ByVal CodMedico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupos_BuscarAtencionAtendida", Cn)
        Dim dstabla As New Data.DataSet
        Dim Fecha As String
        Fecha = Left(Format("dd/MM/yyyy", FechaCita), 10)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaCita", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@IdMedico1", SqlDbType.Int).Value = Val(CodMedico)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Cupos_BuscarAtencionAtendidaSubEspecialidad(ByVal FechaCita As String, ByVal Turno As String, ByVal CodMedico As String, ByVal SubEspecialidad As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupos_BuscarAtencionAtendidaSubEspecialidad", Cn)
        Dim dstabla As New Data.DataSet
        Dim Fecha As String
        Fecha = Left(Format("dd/MM/yyyy", FechaCita), 10)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaCita", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@IdMedico1", SqlDbType.Int).Value = Val(CodMedico)
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ConsultasPacienteAtendidas(ByVal NHistoria As String, ByVal FechaCita As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ConsultasPacienteAtendidas", Cn)
        Dim dstabla As New Data.DataSet
        Dim Fecha As String
        Fecha = Left(Format("dd/MM/yyyy", FechaCita), 10)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.VarChar).Value = NHistoria
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarCupoPintar(ByVal IdProgramacion As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("BuscarCupoPintar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = Val(IdProgramacion)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Atender(ByVal IdCupo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupo_Atender", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = Val(IdCupo)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function VerificarAsignacion(ByVal NHistoria As String, ByVal FechaCita As String, ByVal IdSubEspecialidad As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupo_VerificarAsignacion", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@NHistoria", SqlDbType.Int).Value = NHistoria
        daTabla.SelectCommand.Parameters.Add("@FechaCita", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@IdSubEspecialidad", SqlDbType.Int).Value = IdSubEspecialidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function VerificarCupo(ByVal Cupo As String, ByVal FechaCita As String, ByVal IdSubEspecialidad As String, ByVal IdProgramacion As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupo_VerificarCupo", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Cupo", SqlDbType.Int).Value = Cupo
        daTabla.SelectCommand.Parameters.Add("@FechaCita", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@IdSubEspecialidad", SqlDbType.Int).Value = IdSubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = IdProgramacion
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarProgramacionDiaria(ByVal Fecha As String, ByVal Turno As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupo_BuscarProgramacionDiaria", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarListaPacientes(ByVal IdProgramacion As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupo_BuscarListaPacientes", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = IdProgramacion
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function GuardarCupoMed(ByVal NHistoria As String, ByVal Paterno As String, ByVal Materno As String, ByVal Nombres As String, ByVal Edad As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal FechaCita As String, ByVal HoraCita As String, ByVal Turno As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal IdSubEspecialidad As String, ByVal Cupo As String, ByVal TipoCupo As String, ByVal IdProgramacion As String, ByVal Equipo As String, ByVal UsuarioRegistro As String, ByVal TipoAtencion As String, ByVal IdServicio As String, ByVal Descripcion As String, ByVal Cantidad As String, ByVal Precio As String, ByVal CodMedico As String, ByVal NomMedico As String, ByVal TipoCupoO As String, ByVal Redigitado As String, ByVal Exonerado As String, ByVal NroPreliquidacion As String, ByVal SerieSis As String, ByVal NumeroSIS As String) As String
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("GuardarCupoMed", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@NHistoria", SqlDbType.Int).Value = NHistoria
        daTabla.SelectCommand.Parameters.Add("@Paterno", SqlDbType.VarChar).Value = Paterno
        daTabla.SelectCommand.Parameters.Add("@Materno", SqlDbType.VarChar).Value = Materno
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.Int).Value = Val(Edad)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@FechaCita", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@HoraCita", SqlDbType.VarChar).Value = HoraCita
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@IdSubEspecialidad", SqlDbType.Int).Value = IdSubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@Cupo", SqlDbType.Int).Value = Cupo
        daTabla.SelectCommand.Parameters.Add("@TipoCupo", SqlDbType.VarChar).Value = TipoCupo
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = IdProgramacion
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.Parameters.Add("@TipoAtencion", SqlDbType.VarChar).Value = TipoAtencion
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = IdServicio
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@CodMedico", SqlDbType.Int).Value = CodMedico
        daTabla.SelectCommand.Parameters.Add("@NomMedico", SqlDbType.VarChar).Value = NomMedico
        daTabla.SelectCommand.Parameters.Add("@TipoCupoO", SqlDbType.VarChar).Value = TipoCupoO
        daTabla.SelectCommand.Parameters.Add("@Redigitado", SqlDbType.VarChar).Value = Redigitado
        daTabla.SelectCommand.Parameters.Add("@Exonerado", SqlDbType.VarChar).Value = Exonerado
        daTabla.SelectCommand.Parameters.Add("@NroPreliquidacion", SqlDbType.Int).Value = NroPreliquidacion
        daTabla.SelectCommand.Parameters.Add("@SerieSis", SqlDbType.VarChar).Value = SerieSis
        daTabla.SelectCommand.Parameters.Add("@NumeroSIS", SqlDbType.Int).Value = NumeroSIS
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        Return daTabla.SelectCommand.Parameters("@IdCupo").Value
    End Function

    Public Sub ActNroCupos(ByVal IdProgramacion As String, ByVal TipoCupo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ActNroCupos", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = Val(IdProgramacion)
        daTabla.SelectCommand.Parameters.Add("@TipoCupo", SqlDbType.VarChar).Value = TipoCupo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Atencion(ByVal IdCupo As String, ByVal Fecha As String, ByVal Hora As String, ByVal Equipo As String, ByVal Tipo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Cupo_Atencion", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = Val(IdCupo)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
