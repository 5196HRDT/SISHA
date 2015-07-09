Imports System.Data.SqlClient
Public Class clsRecetaMedicaSISDet
    Public Sub AtencionFarmacia(IdReceta As String, CantAten As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSISDet_AtencionFarmacia", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = IdReceta
        daTabla.SelectCommand.Parameters.Add("@CantAten", SqlDbType.Real).Value = CantAten
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarId(IdReceta As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSISDet_BuscarId", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdReceta", SqlDbType.Int).Value = IdReceta
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
