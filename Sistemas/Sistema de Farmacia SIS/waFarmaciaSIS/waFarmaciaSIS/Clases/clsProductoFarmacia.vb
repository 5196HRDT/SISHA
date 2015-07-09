Imports System.Data.SqlClient
Public Class clsProductoFarmacia
    Dim CNP As New SqlConnection("Data Source=ServidorSQL;Initial Catalog=NewGesthion;UID=SA;PWD=hrdt2003")

    Public Sub Grabar(ByVal BienServ As String, ByVal Grupo As String, ByVal Clase As String, ByVal Codigo As String, ByVal Descripción As String, ByVal Und As String, ByVal Fecha_Reg As String, ByVal StockInicial As String)
        Do While CNP.State = ConnectionState.Closed
            CNP.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ProductoFarmacia_Grabar", CNP)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@BienServ", SqlDbType.VarChar).Value = BienServ
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.Parameters.Add("@Clase", SqlDbType.VarChar).Value = Clase
        daTabla.SelectCommand.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo
        daTabla.SelectCommand.Parameters.Add("@Descripción", SqlDbType.VarChar).Value = Descripción
        daTabla.SelectCommand.Parameters.Add("@Und", SqlDbType.VarChar).Value = Und
        daTabla.SelectCommand.Parameters.Add("@Fecha_Reg", SqlDbType.SmallDateTime).Value = Fecha_Reg
        daTabla.SelectCommand.Parameters.Add("@StockInicial", SqlDbType.SmallDateTime).Value = StockInicial
        Do While CNP.State = ConnectionState.Closed
            CNP.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Descripcion As String) As Data.DataSet
        Do While CNP.State = ConnectionState.Closed
            CNP.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ProductoFarmacia_Buscar", CNP)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion

        Do While CNP.State = ConnectionState.Closed
            CNP.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarNroFormato() As Data.DataSet
        Do While CNP.State = ConnectionState.Closed
            CNP.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ProductoFarmacia_UltimoCodigo", CNP)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        Do While CNP.State = ConnectionState.Closed
            CNP.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Unidad() As Data.DataSet
        Do While CNP.State = ConnectionState.Closed
            CNP.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ProductoFarmacia_Unidad", CNP)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        Do While CNP.State = ConnectionState.Closed
            CNP.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
