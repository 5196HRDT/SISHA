Imports System.Data.SqlClient
Public Class Medicamento
    Public Sub Grabar(ByVal IdMedicamento As String, ByVal TipoBien As String, ByVal Descripcion As String, ByVal Unidad As String, ByVal PrecioCosto As String, ByVal StockActual As String, ByVal StockMinFar As String, ByVal StockMinAlm As String, ByVal StockActualA As String, ByVal Activo As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("Medicamento_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = Val(IdMedicamento)
        daTabla.SelectCommand.Parameters.Add("@TipoBien", SqlDbType.VarChar).Value = TipoBien
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = Unidad
        daTabla.SelectCommand.Parameters.Add("@PrecioCosto", SqlDbType.Money).Value = PrecioCosto
        daTabla.SelectCommand.Parameters.Add("@StockActual", SqlDbType.Int).Value = StockActual
        daTabla.SelectCommand.Parameters.Add("@StockActualA", SqlDbType.Int).Value = StockActualA
        daTabla.SelectCommand.Parameters.Add("@StockMinFar", SqlDbType.Int).Value = StockMinFar
        daTabla.SelectCommand.Parameters.Add("@StockMinAlm", SqlDbType.Int).Value = StockMinAlm
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarPecosa() As Data.DataSet
        BuscarPecosa = New Data.DataSet
        Dim daTabla As New SqlDataAdapter("Medicamento_BuscarPecosa", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function ListaInventario() As Data.DataSet
        ListaInventario = New Data.DataSet
        Dim daTabla As New SqlDataAdapter("ListaPrecio_ListadoInventario", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarMedPec(ByVal BienServ As String) As Data.DataSet
        BuscarMedPec = New Data.DataSet
        Dim daTabla As New SqlDataAdapter("Medicamento_BuscarMedPec", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@BienServ", SqlDbType.VarChar).Value = BienServ
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function Buscar(ByVal Descripcion As String) As Data.DataSet
        Buscar = New Data.DataSet
        Dim daTabla As New SqlDataAdapter("Medicamento_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
