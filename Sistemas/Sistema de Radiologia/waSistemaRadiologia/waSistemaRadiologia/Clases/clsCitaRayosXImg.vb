Imports System.Data.SqlClient
Public Class clsCitaRayosXImg
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function Grabar(ByVal Historia As String, ByVal Titulo As String, ByVal Descripcion As String, ByVal Fecha As String, ByVal Hora As String, ByVal Tipo As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal Edad As String, ByVal Sexo As String, ByVal Tecnologo As String, ByVal Radiologo As String, ByVal MedicoSol As String, ByVal Antecedentes As String, ByVal Secretaria As String, ByVal Iniciales As String, ByVal FechaR As String, ByVal TipoPac As String, ByVal Serie As String, ByVal Numero As String, ByVal IdCupo As String, ByVal Cie1 As String, ByVal Cie2 As String, ByVal Cie3 As String) As String
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CitaRAyosXImg_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdImagenes", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.Real).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = Titulo
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@Tecnologo", SqlDbType.VarChar).Value = Tecnologo
        daTabla.SelectCommand.Parameters.Add("@Radiologo", SqlDbType.VarChar).Value = Radiologo
        daTabla.SelectCommand.Parameters.Add("@MedicoSol", SqlDbType.VarChar).Value = MedicoSol
        daTabla.SelectCommand.Parameters.Add("@Antecedentes", SqlDbType.VarChar).Value = Antecedentes
        daTabla.SelectCommand.Parameters.Add("@Secretaria", SqlDbType.VarChar).Value = Secretaria
        daTabla.SelectCommand.Parameters.Add("@Iniciales", SqlDbType.VarChar).Value = Iniciales
        daTabla.SelectCommand.Parameters.Add("@FechaR", SqlDbType.VarChar).Value = FechaR
        daTabla.SelectCommand.Parameters.Add("@TipoPac", SqlDbType.VarChar).Value = TipoPac
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Real).Value = Val(Numero)
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = Val(IdCupo)
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        Return daTabla.SelectCommand.Parameters("@IdImagenes").Value
    End Function

    Public Sub Modificar(ByVal Historia As String, ByVal Titulo As String, ByVal Descripcion As String, ByVal Tipo As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal Tecnologo As String, ByVal Radiologo As String, ByVal MedicoSol As String, ByVal Antecedentes As String, ByVal Secretaria As String, ByVal Iniciales As String, ByVal TipoPac As String, ByVal IdCupo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CitaRAyosXImg_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.Real).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = Titulo
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@Tecnologo", SqlDbType.VarChar).Value = Tecnologo
        daTabla.SelectCommand.Parameters.Add("@Radiologo", SqlDbType.VarChar).Value = Radiologo
        daTabla.SelectCommand.Parameters.Add("@MedicoSol", SqlDbType.VarChar).Value = MedicoSol
        daTabla.SelectCommand.Parameters.Add("@Antecedentes", SqlDbType.VarChar).Value = Antecedentes
        daTabla.SelectCommand.Parameters.Add("@Secretaria", SqlDbType.VarChar).Value = Secretaria
        daTabla.SelectCommand.Parameters.Add("@Iniciales", SqlDbType.VarChar).Value = Iniciales
        daTabla.SelectCommand.Parameters.Add("@TipoPac", SqlDbType.VarChar).Value = TipoPac
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function InformeWeb(ByVal Historia As String, ByVal Tipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CitaRayosXImg_InformeWeb", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarIdCupo(ByVal IdCupo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CitaRayosXImg_BuscarIdCupo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarId(ByVal IdImagenes As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CitaRayosXImg_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdImagenes", SqlDbType.Int).Value = IdImagenes
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
