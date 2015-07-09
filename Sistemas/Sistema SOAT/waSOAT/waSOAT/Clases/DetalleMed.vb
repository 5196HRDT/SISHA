Imports System.Data.SqlClient
Public Class DetalleMed
    
    Public Sub Grabar_Med(ByVal IdSoat As String, ByVal IdMedicamento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_Grabar_Med"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = IdMedicamento
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        Cm.ExecuteNonQuery()
    End Sub

    Public Function MedAten(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_MedAten", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.Int).Value = Val(IdSoat)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub MedAnular(ByVal IdDet As String, ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String, ByVal Equipo As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_MedAnular"
        Cm.Parameters.Add("@IdDet", SqlDbType.Int).Value = IdDet
        Cm.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Cm.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        Cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        Cm.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        Cm.ExecuteNonQuery()
    End Sub
End Class
