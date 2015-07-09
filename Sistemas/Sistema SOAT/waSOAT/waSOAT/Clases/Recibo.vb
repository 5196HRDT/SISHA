Imports System.Data.SqlClient
Public Class Recibo
    Public Function Grabar(ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String, ByVal Equipo As String, ByVal IdSoat As String, ByVal Total As String) As String
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_ReciboGrabar"
        Cm.Parameters.Add("@IdRecibo", SqlDbType.Int).Direction = ParameterDirection.Output
        Cm.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Cm.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        Cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        Cm.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = Val(IdSoat)
        Cm.Parameters.Add("@Total", SqlDbType.Money).Value = Val(Total)
        Cm.ExecuteNonQuery()
        Grabar = Cm.Parameters.Item("@IdRecibo").Value
    End Function

    Public Sub GrabarDetalle(ByVal IdRecibo As String, ByVal IdTarifario As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_ReciboGrabarDet"
        Cm.Parameters.Add("@IdRecibo", SqlDbType.Int).Value = Val(IdRecibo)
        Cm.Parameters.Add("@IdTarifario", SqlDbType.Int).Value = IdTarifario
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        Cm.Parameters.Add("@Cantidad", SqlDbType.Real).Value = Cantidad
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
        Cm.ExecuteNonQuery()
    End Sub
End Class
