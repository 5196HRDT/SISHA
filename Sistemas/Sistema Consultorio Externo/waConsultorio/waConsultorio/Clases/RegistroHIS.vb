Imports System.Data.SqlClient
Public Class RegistroHIS
    Public Function Grabar(ByVal FechaMigracion As String, ByVal HoraMigracion As String, ByVal UsuarioMigracion As String, ByVal EquipoMigracion As String, ByVal Fecha As String, ByVal Turno As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RegistroHIS_Grabar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaMigracion", SqlDbType.SmallDateTime).Value = FechaMigracion
        daTabla.SelectCommand.Parameters.Add("@HoraMigracion", SqlDbType.VarChar).Value = HoraMigracion
        daTabla.SelectCommand.Parameters.Add("@UsuarioMigracion", SqlDbType.VarChar).Value = UsuarioMigracion
        daTabla.SelectCommand.Parameters.Add("@EquipoMigracion", SqlDbType.VarChar).Value = EquipoMigracion
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@TurnoMigracion", SqlDbType.VarChar).Value = Turno
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        Return dstabla
    End Function

    Public Function Buscar(ByVal FechaMigracion As String, ByVal Turno As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RegistroHIS_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaMigracion", SqlDbType.SmallDateTime).Value = FechaMigracion
        daTabla.SelectCommand.Parameters.Add("@TurnoMigracion", SqlDbType.VarChar).Value = Turno
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
