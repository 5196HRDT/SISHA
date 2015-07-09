Imports System.Data.SqlClient
Public Class tempConsultaExterna

    Public Sub Grabar(ByVal Usuario As String, ByVal Fecha As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sexo As String, ByVal Edad As String, ByVal TEdad As String, ByVal DNI As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, Cie1 As String, Des1 As String, Lab1 As String, T1 As String, Cie2 As String, Des2 As String, Lab2 As String, T2 As String, Cie3 As String, Des3 As String, Lab3 As String, T3 As String, Cie4 As String, Des4 As String, Lab4 As String, T4 As String, Cie5 As String, Des5 As String, Lab5 As String, T5 As String, Cie6 As String, Des6 As String, Lab6 As String, T6 As String, CSHistoria As String, Responsable As String, Servicio As String, IngEstablecimiento As String, IngServicio As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("tempConsultaExterna_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.Int).Value = Val(Edad)
        daTabla.SelectCommand.Parameters.Add("@TEdad", SqlDbType.VarChar).Value = TEdad
        daTabla.SelectCommand.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@Lab1", SqlDbType.VarChar).Value = Lab1
        daTabla.SelectCommand.Parameters.Add("@T1", SqlDbType.VarChar).Value = T1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@Lab2", SqlDbType.VarChar).Value = Lab2
        daTabla.SelectCommand.Parameters.Add("@T2", SqlDbType.VarChar).Value = T2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@Lab3", SqlDbType.VarChar).Value = Lab3
        daTabla.SelectCommand.Parameters.Add("@T3", SqlDbType.VarChar).Value = T3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@Des4", SqlDbType.VarChar).Value = Des4
        daTabla.SelectCommand.Parameters.Add("@Lab4", SqlDbType.VarChar).Value = Lab4
        daTabla.SelectCommand.Parameters.Add("@T4", SqlDbType.VarChar).Value = T4
        daTabla.SelectCommand.Parameters.Add("@Cie5", SqlDbType.VarChar).Value = Cie5
        daTabla.SelectCommand.Parameters.Add("@Des5", SqlDbType.VarChar).Value = Des5
        daTabla.SelectCommand.Parameters.Add("@Lab5", SqlDbType.VarChar).Value = Lab5
        daTabla.SelectCommand.Parameters.Add("@T5", SqlDbType.VarChar).Value = T5
        daTabla.SelectCommand.Parameters.Add("@Cie6", SqlDbType.VarChar).Value = Cie6
        daTabla.SelectCommand.Parameters.Add("@Des6", SqlDbType.VarChar).Value = Des6
        daTabla.SelectCommand.Parameters.Add("@Lab6", SqlDbType.VarChar).Value = Lab6
        daTabla.SelectCommand.Parameters.Add("@T6", SqlDbType.VarChar).Value = T6
        daTabla.SelectCommand.Parameters.Add("@CSHistoria", SqlDbType.VarChar).Value = CSHistoria
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@IngEstablecimiento", SqlDbType.VarChar).Value = IngEstablecimiento
        daTabla.SelectCommand.Parameters.Add("@IngServicio", SqlDbType.VarChar).Value = IngServicio

        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal Usuario As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("tempConsultaExterna_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario

        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Usuario As String, Oper As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("tempConsultaExterna_Reporte", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

  
End Class
