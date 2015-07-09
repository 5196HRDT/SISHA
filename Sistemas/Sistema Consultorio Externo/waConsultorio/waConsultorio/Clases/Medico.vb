Imports System.Data.SqlClient
Public Class Medico
   
    Public Sub Medicos_Mantenimiento(ByVal IdMedico As String, ByVal Apellidos As String, ByVal Nombres As String, ByVal NroCMP As String, ByVal IdSubServicios As String, ByVal Usuario As String, ByVal Clave As String, ByVal Activo As String, ByVal CambiarC As String, ByVal DNI As String, ByVal CodigoProfesion As String, ByVal TipoColegiatura As String, ByVal CodigoCondicion As String, ByVal FechaIngreso As String, ByVal Medico As String, ByVal Oper As String, Programas As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medicos_Mantenimiento", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Apellidos
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        daTabla.SelectCommand.Parameters.Add("@NroCMP", SqlDbType.VarChar).Value = NroCMP
        daTabla.SelectCommand.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
        daTabla.SelectCommand.Parameters.Add("@IdSubServicios", SqlDbType.Int).Value = Val(IdSubServicios)
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.Parameters.Add("@CambiarC", SqlDbType.VarChar).Value = CambiarC
        daTabla.SelectCommand.Parameters.Add("@CodigoProfesion", SqlDbType.VarChar).Value = CodigoProfesion
        daTabla.SelectCommand.Parameters.Add("@TipoColegiatura", SqlDbType.VarChar).Value = TipoColegiatura
        daTabla.SelectCommand.Parameters.Add("@CodigoCondicion", SqlDbType.VarChar).Value = CodigoCondicion
        daTabla.SelectCommand.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = FechaIngreso
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@Programas", SqlDbType.VarChar).Value = Programas
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Val(Oper)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Medicos_CambiarClave(ByVal IdMedico As String, ByVal Clave As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medicos_CAmbiarClave", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub

    Public Function Medico_ControlAcceso(ByVal Usuario As String, ByVal Clave As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medico_ControlAcceso", Cn)
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

    Public Function Medico_BuscarId(ByVal IdMedico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medico_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = IdMedico
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Medico_BuscarNombres(ByVal Medico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medico_BuscarNombres", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Combo() As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ObtenerMedicoNom", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = ""
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
