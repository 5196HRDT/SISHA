Imports System.Data.SqlClient
Public Class clsDepositoImagen
    Public Sub Grabar(ByVal Fecha As String, ByVal Titulo As String, ByVal Descripcion As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sexo As String, ByVal Edad As String, ByVal Imagen As Object, ByVal Comentario As String, ByVal Tipo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim Cm As New SqlCommand("DepositoImagen_Grabar", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Cm.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = Titulo
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Cm.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        Cm.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        Cm.Parameters.Add("@Imagen", SqlDbType.Image).Value = Imagen
        Cm.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = Comentario
        Cm.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdImagen As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim Cm As New SqlCommand("DepositoImagen_Eliminar", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdImagen", SqlDbType.Int).Value = IdImagen
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarEspirometria(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DepositoImagen_BuscarEspirometria", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarId(ByVal IdImagen As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DepositoImagen_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdImagen", SqlDbType.Int).Value = IdImagen
        daTabla.SelectCommand.ExecuteNonQuery()
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarImagenReader(ByVal IdImagen As String) As SqlDataReader
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DepositoImagen_BuscarImagen", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdImagen", SqlDbType.Int).Value = IdImagen
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        BuscarImagenReader = daTabla.SelectCommand.ExecuteReader
    End Function
End Class
