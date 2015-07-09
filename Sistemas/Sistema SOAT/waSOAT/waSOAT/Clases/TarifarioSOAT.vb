Imports System.Data.SqlClient
Public Class TarifarioSOAT
    Public Function BuscarFiltro(ByVal Des As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("TarifarioSOAT_Filtrar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des & "%"
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Combo() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("TarifarioSOAT_Combo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Grabar(ByVal Codigo As String, ByVal Descripcion As String, ByVal Precio As String, Tipo As String, SubTipo As String, IdHRDT As String)
        Dim daTabla As New SqlDataAdapter("TarifarioSOAT_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.Parameters.Add("@IdHRDT", SqlDbType.VarChar).Value = Val(IdHRDT)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdTarifario As String, ByVal Codigo As String, ByVal Descripcion As String, ByVal Precio As String, Tipo As String, SubTipo As String, IdHRDT As String)
        Dim daTabla As New SqlDataAdapter("TarifarioSOAT_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTarifario", SqlDbType.Int).Value = Val(IdTarifario)
        daTabla.SelectCommand.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.Parameters.Add("@IdHRDT", SqlDbType.VarChar).Value = Val(IdHRDT)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdTarifario As String)
        Dim daTabla As New SqlDataAdapter("TarifarioSOAT_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTarifario", SqlDbType.Int).Value = Val(IdTarifario)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarCodigo(ByVal IdTarifario As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("TarifarioSOAT_BuscarCodigo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTarifario", SqlDbType.VarChar).Value = IdTarifario
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarCodigoSoat(ByVal Codigo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("TarifarioSOAT_BuscarCodigoSoat", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = codigo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
