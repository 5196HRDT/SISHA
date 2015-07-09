Imports System.Data.SqlClient
Public Class clsDetalleMedHospitalizacion
    Public Sub Grabar(ByVal IdIngreso As String, ByVal IdMedicamento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal Dosis As String)
        Dim daTabla As New SqlDataAdapter("DetalleMedHospitalizacion_Grabar]", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@IdMedicamento", SqlDbType.VarChar).Value = IdMedicamento
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Real).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        daTabla.SelectCommand.Parameters.Add("@Dosis", SqlDbType.VarChar).Value = Dosis
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
