Imports System.Data.SqlClient
Public Class clsEmergenciaIngreso_Alta
    Dim Cn As New SqlConnection

    Public Sub New()
        Dim Ruta, Servidor, Base, Usuario, Password As String
        Dim Encontro As Boolean = False

        Ruta = System.IO.Directory.GetCurrentDirectory() & "\Servidor.ini"

        Dim objReader As New IO.StreamReader(Ruta)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        Servidor = Microsoft.VisualBasic.Right(arrText(1), arrText(1).ToString.Length - 9)
        Base = Microsoft.VisualBasic.Right(arrText(2), arrText(2).ToString.Length - 5)
        Usuario = Microsoft.VisualBasic.Right(arrText(3), arrText(3).ToString.Length - 8)
        Password = Microsoft.VisualBasic.Right(arrText(4), arrText(4).ToString.Length - 9)


        Cn.ConnectionString = "Database='" + Base + "';Data Source='" + Servidor + "';User Id='" + Usuario + "';Password='" + Password + "'"
        Try
            Cn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.Exit()
        End Try
    End Sub

    Public Sub Grabar(ByVal IdIngreso As String, ByVal Fecha As String, Hora As String, CondicionAlta As String, Medico As String, TipoAlta As String, Destino As String, DesDestino As String, Cie1 As String, DesCie1 As String, Lab1 As String, TD1 As String, Cie2 As String, DesCie2 As String, Lab2 As String, TD2 As String, Cie3 As String, DesCie3 As String, Lab3 As String, TD3 As String, Cie4 As String, DesCie4 As String, Lab4 As String, TD4 As String, Cie5 As String, DesCie5 As String, Lab5 As String, TD5 As String, Cie6 As String, DesCie6 As String, Lab6 As String, TD6 As String, IdMedico As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaIngreso_AltaGrabar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@CondicionAlta", SqlDbType.VarChar).Value = CondicionAlta
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@TipoAlta", SqlDbType.VarChar).Value = TipoAlta
        daTabla.SelectCommand.Parameters.Add("@Destino", SqlDbType.VarChar).Value = Destino
        daTabla.SelectCommand.Parameters.Add("@DesDestino", SqlDbType.VarChar).Value = DesDestino
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@DesCie1", SqlDbType.VarChar).Value = DesCie1
        daTabla.SelectCommand.Parameters.Add("@Lab1", SqlDbType.VarChar).Value = Lab1
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@DesCie2", SqlDbType.VarChar).Value = DesCie2
        daTabla.SelectCommand.Parameters.Add("@Lab2", SqlDbType.VarChar).Value = Lab2
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@DesCie3", SqlDbType.VarChar).Value = DesCie3
        daTabla.SelectCommand.Parameters.Add("@Lab3", SqlDbType.VarChar).Value = Lab3
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@DesCie4", SqlDbType.VarChar).Value = DesCie4
        daTabla.SelectCommand.Parameters.Add("@Lab4", SqlDbType.VarChar).Value = Lab4
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@Cie5", SqlDbType.VarChar).Value = Cie5
        daTabla.SelectCommand.Parameters.Add("@DesCie5", SqlDbType.VarChar).Value = DesCie5
        daTabla.SelectCommand.Parameters.Add("@Lab5", SqlDbType.VarChar).Value = Lab5
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
        daTabla.SelectCommand.Parameters.Add("@Cie6", SqlDbType.VarChar).Value = Cie6
        daTabla.SelectCommand.Parameters.Add("@DesCie6", SqlDbType.VarChar).Value = DesCie6
        daTabla.SelectCommand.Parameters.Add("@Lab6", SqlDbType.VarChar).Value = Lab6
        daTabla.SelectCommand.Parameters.Add("@TD6", SqlDbType.VarChar).Value = TD6
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.VarChar).Value = Val(IdMedico)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdIngreso As String, ByVal Fecha As String, Hora As String, CondicionAlta As String, Medico As String, TipoAlta As String, Destino As String, DesDestino As String, Cie1 As String, DesCie1 As String, Lab1 As String, TD1 As String, Cie2 As String, DesCie2 As String, Lab2 As String, TD2 As String, Cie3 As String, DesCie3 As String, Lab3 As String, TD3 As String, Cie4 As String, DesCie4 As String, Lab4 As String, TD4 As String, Cie5 As String, DesCie5 As String, Lab5 As String, TD5 As String, Cie6 As String, DesCie6 As String, Lab6 As String, TD6 As String, IdMedico As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaIngreso_AltaModificar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@CondicionAlta", SqlDbType.VarChar).Value = CondicionAlta
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@TipoAlta", SqlDbType.VarChar).Value = TipoAlta
        daTabla.SelectCommand.Parameters.Add("@Destino", SqlDbType.VarChar).Value = Destino
        daTabla.SelectCommand.Parameters.Add("@DesDestino", SqlDbType.VarChar).Value = DesDestino
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@DesCie1", SqlDbType.VarChar).Value = DesCie1
        daTabla.SelectCommand.Parameters.Add("@Lab1", SqlDbType.VarChar).Value = Lab1
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@DesCie2", SqlDbType.VarChar).Value = DesCie2
        daTabla.SelectCommand.Parameters.Add("@Lab2", SqlDbType.VarChar).Value = Lab2
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@DesCie3", SqlDbType.VarChar).Value = DesCie3
        daTabla.SelectCommand.Parameters.Add("@Lab3", SqlDbType.VarChar).Value = Lab3
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@DesCie4", SqlDbType.VarChar).Value = DesCie4
        daTabla.SelectCommand.Parameters.Add("@Lab4", SqlDbType.VarChar).Value = Lab4
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@Cie5", SqlDbType.VarChar).Value = Cie5
        daTabla.SelectCommand.Parameters.Add("@DesCie5", SqlDbType.VarChar).Value = DesCie5
        daTabla.SelectCommand.Parameters.Add("@Lab5", SqlDbType.VarChar).Value = Lab5
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
        daTabla.SelectCommand.Parameters.Add("@Cie6", SqlDbType.VarChar).Value = Cie6
        daTabla.SelectCommand.Parameters.Add("@DesCie6", SqlDbType.VarChar).Value = DesCie6
        daTabla.SelectCommand.Parameters.Add("@Lab6", SqlDbType.VarChar).Value = Lab6
        daTabla.SelectCommand.Parameters.Add("@TD6", SqlDbType.VarChar).Value = TD6
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.VarChar).Value = Val(IdMedico)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarAlta(ByVal IdIngreso As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaIngreso_BuscarAlta", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub AltaEliminar(ByVal IdIngreso As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaIngreso_AltaEliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
