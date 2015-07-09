Imports System.Data.SqlClient
Public Class RecetaMedicaSIS
    Public Function SolicitudInd(ByVal UsuarioRegistro As String, ByVal Origen As String, ByVal Servicio As String, ByVal IdMedico As String, ByVal Medico As String, ByVal SerieSIS As String, ByVal NumeroSIS As String, ByVal Historia As String, ByVal Paciente As String, ByVal Indicacion As String) As String
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSIS_SolicitudInd", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdReceta", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = (Microsoft.VisualBasic.Left(UsuarioRegistro & StrDup(50, " "), 50)).Trim
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = IdMedico
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@SerieSIS", SqlDbType.VarChar).Value = SerieSIS
        daTabla.SelectCommand.Parameters.Add("@NumeroSIS", SqlDbType.Int).Value = NumeroSIS
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Indicacion", SqlDbType.VarChar).Value = Indicacion

        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        SolicitudInd = daTabla.SelectCommand.Parameters("@IdReceta").Value
    End Function

    Public Sub GrabarDetalle(ByVal IdReceta As String, ByVal IdMedicamento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal CantSol As String, ByVal Dosis As String, ByVal Unidad As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSISDet_GrabarDetalle", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdReceta", SqlDbType.Int).Value = IdReceta
        daTabla.SelectCommand.Parameters.Add("@IdMedicamento", SqlDbType.VarChar).Value = IdMedicamento
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@CantSol", SqlDbType.Real).Value = CantSol
        daTabla.SelectCommand.Parameters.Add("@Dosis", SqlDbType.VarChar).Value = Dosis
        daTabla.SelectCommand.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = Unidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarCIE(ByVal IdReceta As String, ByVal Cie As String, ByVal Descripcion As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("RecetaMedicaSISCIE_GrabarCIE", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdReceta", SqlDbType.Int).Value = IdReceta
        daTabla.SelectCommand.Parameters.Add("@Cie", SqlDbType.VarChar).Value = Cie
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
