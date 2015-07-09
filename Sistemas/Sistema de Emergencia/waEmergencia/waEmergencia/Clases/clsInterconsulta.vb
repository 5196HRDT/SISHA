Imports System.Data.SqlClient
Public Class clsInterconsulta
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

    Public Sub Grabar(ByVal IdIngreso As String, FechaRegistro As String, HoraRegistro As String, UsuarioRegistro As String, EquipoRegistro As String, Fecha As String, Hora As String, Resultado As String, Cie1 As String, Des1 As String, Lab1 As String, TD1 As String, Cie2 As String, Des2 As String, Lab2 As String, TD2 As String, Cie3 As String, Des3 As String, Lab3 As String, TD3 As String, Tratamiento As String, Pronostico As String, IdResponsable As String, Responsable As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaInterconsulta_Grabar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Resultado", SqlDbType.VarChar).Value = Resultado
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@Lab1", SqlDbType.VarChar).Value = Lab1
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@Lab2", SqlDbType.VarChar).Value = Lab2
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@Lab3", SqlDbType.VarChar).Value = Lab3
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@Tratamiento", SqlDbType.VarChar).Value = Tratamiento
        daTabla.SelectCommand.Parameters.Add("@Pronostico", SqlDbType.VarChar).Value = Pronostico
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = IdResponsable
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub


    Public Function Buscar(ByVal IdIngreso As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaInterconsulta_Buscar", Cn)
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
End Class
