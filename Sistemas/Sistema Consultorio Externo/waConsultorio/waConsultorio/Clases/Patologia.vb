Imports System.Data.SqlClient
Public Class Patologia
    Public Function Buscar(ByVal Paciente As String) As Data.DataSet
        Do While CnP.State = ConnectionState.Closed
            CnP.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_Consulta", CnP)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While CnP.State = ConnectionState.Closed
            CnP.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarHistoria(ByVal Historia As String) As Data.DataSet
        Do While CnP.State = ConnectionState.Closed
            CnP.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_ConsultaHistoria", CnP)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.Int).Value = Historia
        Do While CnP.State = ConnectionState.Closed
            CnP.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ConsultaId(ByVal IdInforme As String) As Data.DataSet
        Do While CnP.State = ConnectionState.Closed
            CnP.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_ConsultaId", CnP)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme
        Do While CnP.State = ConnectionState.Closed
            CnP.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function VerificarRegistro(ByVal NroRegistro As String) As Data.DataSet
        Do While CnP.State = ConnectionState.Closed
            CnP.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_VerificarRegistro", CnP)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@NroRegistro", SqlDbType.VarChar).Value = NroRegistro
        Do While CnP.State = ConnectionState.Closed
            CnP.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
