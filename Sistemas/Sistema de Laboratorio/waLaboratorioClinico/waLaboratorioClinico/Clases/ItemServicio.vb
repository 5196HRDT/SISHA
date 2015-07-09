Imports System.Data.SqlClient
Public Class ItemServicio
    Dim Cn As New SqlConnection

    Public Sub ActualizarParametros(ByVal Id As String, ByVal ClasLaboratorio As String, ByVal Reservado As String, ByVal Emergencia As String, ByVal UnicaVez As String, ByVal Parametros As String, ByVal Preparacion As String, SIS As String, SOAT As String, ByVal Activo As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("ItemServicio_ActualizarParametros", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = ClasLaboratorio
        daTabla.SelectCommand.Parameters.Add("@Reservado", SqlDbType.VarChar).Value = Reservado
        daTabla.SelectCommand.Parameters.Add("@Emergencia", SqlDbType.VarChar).Value = Emergencia
        daTabla.SelectCommand.Parameters.Add("@UnicaVez", SqlDbType.VarChar).Value = UnicaVez
        daTabla.SelectCommand.Parameters.Add("@Parametros", SqlDbType.VarChar).Value = Parametros
        daTabla.SelectCommand.Parameters.Add("@Preparacion", SqlDbType.VarChar).Value = Preparacion
        daTabla.SelectCommand.Parameters.Add("@SIS", SqlDbType.VarChar).Value = SIS
        daTabla.SelectCommand.Parameters.Add("@SOAT", SqlDbType.VarChar).Value = SOAT
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function ProcedimientosClas(ByVal Clasificador As String, ByVal Criterio As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("ItemServicio_ProcedimientosClas", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = Criterio
        daTabla.SelectCommand.Parameters.Add("@Clasificador", SqlDbType.VarChar).Value = Clasificador
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarLaboratorio() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ItemServicio_Buscarlaboratorio", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub GrabarClasificacion(ByVal Id As String, ByVal Clasificacion As String)
        Dim daTabla As New SqlDataAdapter("ItemServicio_GrabarClasificacion", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = Clasificacion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarLabClas(ByVal ClasLaboratorio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ItemServicio_BuscarLabClas", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = ClasLaboratorio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function


    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub
End Class
