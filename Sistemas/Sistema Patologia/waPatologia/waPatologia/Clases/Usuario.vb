Imports System.Data.SqlClient
Public Class Usuario
    Public Sub Mantenimiento(ByVal IdUsuario As String, ByVal IdPersonal As String, ByVal Nivel As String, ByVal Usuario As String, ByVal Clave As String, ByVal FechaInicio As String, ByVal FechaTermino As String, ByVal FechaRegistro As String, ByVal Equipo As String, ByVal Activo As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("Usuario_Mantenimiento", Cn)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Val(IdUsuario)
        daTabla.SelectCommand.Parameters.Add("@IdPersonal", SqlDbType.VarChar).Value = Val(IdPersonal)
        daTabla.SelectCommand.Parameters.Add("@Nivel", SqlDbType.VarChar).Value = Nivel
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        daTabla.SelectCommand.Parameters.Add("@FechaInicio", SqlDbType.SmallDateTime).Value = FechaInicio
        daTabla.SelectCommand.Parameters.Add("@FechaTermino", SqlDbType.SmallDateTime).Value = FechaTermino
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Oper As String, ByVal Filtro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Usuario_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Acceso(ByVal Usuario As String, ByVal Clave As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Usuario_Acceso", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
