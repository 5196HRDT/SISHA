Imports System.Data.SqlClient
Public Class PapeletaHospitalizacionCIE
  

    Public Sub Grabar(IdPapeleta As String, ByVal Cie As String, ByVal DesCie As String, Tipo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("PapeletaHospitalizacionCie_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdPapeleta", SqlDbType.Int).Value = Val(IdPapeleta)
        daTabla.SelectCommand.Parameters.Add("@Cie", SqlDbType.VarChar).Value = Cie
        daTabla.SelectCommand.Parameters.Add("@DesCie", SqlDbType.VarChar).Value = DesCie
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo

        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
