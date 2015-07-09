Imports System.Data.SqlClient
Public Class clsBancoSangre
    Public Function ControlSangreE(ByVal IdIngreso As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ControlSangre_BuscarE", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ControlSangreH(ByVal IdHospitalizacion As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ControSangre_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = IdHospitalizacion
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
