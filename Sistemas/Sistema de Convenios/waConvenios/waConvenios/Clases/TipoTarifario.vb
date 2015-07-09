Imports System.Data.SqlClient
Public Class TipoTarifario
    Dim Cn As New SqlConnection
    Dim Cm As SqlCommand

    Public Function ComboConvenio() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("TipoTarifario_ComboConvenio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarId(ByVal IdTipoTarifa As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("TipoTarifario_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTipoTarifa", SqlDbType.Int).Value = IdTipoTarifa
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()
    End Sub
End Class
