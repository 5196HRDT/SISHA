Imports System.Data.SqlClient
Public Class Procedimientos
    Dim Cn As New SqlConnection
    Dim Cm As SqlCommand

    Public Sub Mantenimiento(ByVal IdTarifario As String, ByVal Ap_CodApo As String, ByVal Apo_Nombre As String, ByVal Apo_CodSGrupo As String, ByVal Apo_Costo As String, ByVal Oper As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "TarifarioProcSis_Mantenimiento"
        Cm.Parameters.Add("@IdTarifario", SqlDbType.Int).Value = Val(IdTarifario)
        Cm.Parameters.Add("@Ap_CodApo", SqlDbType.Int).Value = Val(Ap_CodApo)
        Cm.Parameters.Add("@Apo_Nombre", SqlDbType.VarChar).Value = Apo_Nombre
        Cm.Parameters.Add("@Apo_CodSGrupo", SqlDbType.Int).Value = Val(Apo_CodSGrupo)
        Cm.Parameters.Add("@Apo_Costo", SqlDbType.Money).Value = Val(Apo_Costo)
        Cm.Parameters.Add("@Oper", SqlDbType.Char).Value = Oper
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub EliminarDetalle(ByVal Id As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Procedimientos_Eliminar"
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarServicio(ByVal Des As String, ByVal TipoTarifa As String, ByVal Tipo As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("BuscarServicio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.Parameters.Add("@TipoTarifa", SqlDbType.VarChar).Value = TipoTarifa
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarFiltro(ByVal Des As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("TarifarioProcSis_BuscarFiltro", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=sa;password=hrdt2003"
        Cn.Open()
    End Sub

    Public Sub ItemServicio_Grabar(ByVal Id As String, ByVal Descripcion As String, ByVal Factor As String, ByVal Activo As String, ByVal Bandera As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "ItemServicio_Grabar"
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.Parameters.Add("@Actividad", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Factor", SqlDbType.Int).Value = Factor
        Cm.Parameters.Add("@Activo", SqlDbType.Char).Value = Activo
        Cm.Parameters.Add("@Bandera", SqlDbType.Char).Value = Bandera
        Cm.ExecuteNonQuery()
    End Sub

    Public Function ItemServicio_Buscar(ByVal Des As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ItemServicio_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Actividad", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function TotalProc(ByVal IdSis As String) As String
        Dim daTabla As New SqlDataAdapter("SISHRDT_TotalProc", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        daTabla.SelectCommand.Parameters.Add("@Total", SqlDbType.Money).Direction = ParameterDirection.Output
        daTabla.SelectCommand.ExecuteNonQuery()
        Return daTabla.SelectCommand.Parameters("@Total").Value
    End Function
End Class
