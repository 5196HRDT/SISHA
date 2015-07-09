Imports System.Data.SqlClient
Public Class SIS
    Dim Cn As New SqlConnection

    Public Function Laboratorio(ByVal Lote As String, ByVal Numero As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISHRDT_Laboratorio", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Numero
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function Produccion(ByVal F1 As String, ByVal F2 As String, ByVal Tipo As String, ByVal ClasLaboratorio As String, ByVal Especialidad As String, ByVal Descripcion As String, ByVal Oper As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISHRDT_Produccion", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = ClasLaboratorio
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function CantBolsaColectora(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SisHRDT_Medicamentos_CantBolsaColectora", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub GrabarArea(ByVal IdSis As String, ByVal Area As String)
        Dim daTabla As New SqlDataAdapter("SISHRDT_GrabarArea", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        daTabla.SelectCommand.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub
End Class
