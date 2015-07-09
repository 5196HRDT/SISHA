Imports System.Data.SqlClient
Public Class clsSIS
    Public Function BuscarNroFormato(Lote As String, Numero As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SISHRDT_BuscarNroFormato", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarMedFechaHora(IdSis As String, IdMedicamento As String, Descripcion As String, Precio As String, Cantidad As String, Importe As String, Fecha As String, Hora As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SisHRDT_Medicamentos_GrabarFechaHora", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSis", SqlDbType.Int).Value = IdSis
        daTabla.SelectCommand.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = Val(IdMedicamento)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = CDbl(Precio)
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = CDbl(Importe)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
