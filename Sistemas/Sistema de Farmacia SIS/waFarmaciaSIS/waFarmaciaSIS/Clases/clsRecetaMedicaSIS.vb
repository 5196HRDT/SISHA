Imports System.Data.SqlClient
Public Class clsRecetaMedicaSIS
    Public Function BuscarAtencion(Origen As String, FechaRegistro As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSIS_BuscarAtencion", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarDuplicado(ByVal Origen As String, ByVal FechaRegistro As String, ByVal Paciente As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSIS_BuscarDuplicado", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarDevolucion(Paciente As String, Origen As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSIS_BuscarDevolucion", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Atendido(IdReceta As String, FechaAtencion As String, HoraAtencion As String, UsuarioAtencion As String, EquipoAtencion As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSIS_Atendido", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdReceta", SqlDbType.Int).Value = IdReceta
        daTabla.SelectCommand.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
        daTabla.SelectCommand.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
        daTabla.SelectCommand.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
        daTabla.SelectCommand.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Devuelto(IdReceta As String, FechaDevolucion As String, HoraDevolucion As String, UsuarioDevolucion As String, EquipoDevolucion As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSIS_Devuelto", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdReceta", SqlDbType.Int).Value = IdReceta
        daTabla.SelectCommand.Parameters.Add("@FechaDevolucion", SqlDbType.SmallDateTime).Value = FechaDevolucion
        daTabla.SelectCommand.Parameters.Add("@HoraDevolucion", SqlDbType.VarChar).Value = HoraDevolucion
        daTabla.SelectCommand.Parameters.Add("@UsuarioDevolucion", SqlDbType.VarChar).Value = UsuarioDevolucion
        daTabla.SelectCommand.Parameters.Add("@EquipoDevolucion", SqlDbType.VarChar).Value = EquipoDevolucion
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
