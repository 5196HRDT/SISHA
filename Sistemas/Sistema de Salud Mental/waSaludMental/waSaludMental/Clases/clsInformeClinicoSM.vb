Imports System.Data.SqlClient
Public Class clsInformeClinicoSM
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

    Public Function Grabar(ByVal Fecha As String, ByVal Hora As String, Usuario As String, Equipo As String, Historia As String, Paciente As String, TipoInforme As String, TituloInforme As String, Informe As Object, Extension As String, IdResponsable As String, Responsable As String, IdCupo As String) As String
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeClinicoSM_Grabar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@TipoInforme", SqlDbType.VarChar).Value = TipoInforme
        daTabla.SelectCommand.Parameters.Add("@TituloInforme", SqlDbType.VarChar).Value = TituloInforme
        daTabla.SelectCommand.Parameters.Add("@Informe", SqlDbType.VarBinary).Value = Informe
        daTabla.SelectCommand.Parameters.Add("@Extension", SqlDbType.VarChar).Value = Extension
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = IdResponsable
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        Grabar = daTabla.SelectCommand.Parameters("@IdInforme").Value
    End Function

    Public Sub Modificar(IdInforme As String, ByVal Fecha As String, ByVal Hora As String, Usuario As String, Equipo As String, Historia As String, Paciente As String, TipoInforme As String, TituloInforme As String, Informe As Object, Extension As String, IdResponsable As String, Responsable As String, IdCupo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeClinicoSM_Modificar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@TipoInforme", SqlDbType.VarChar).Value = TipoInforme
        daTabla.SelectCommand.Parameters.Add("@TituloInforme", SqlDbType.VarChar).Value = TituloInforme
        daTabla.SelectCommand.Parameters.Add("@Informe", SqlDbType.VarBinary).Value = Informe
        daTabla.SelectCommand.Parameters.Add("@Extension", SqlDbType.VarChar).Value = Extension
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = IdResponsable
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdInforme As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeClinicoSM_Eliminar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarHistoria(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeClinicoSM_BuscarHistoria", Cn)
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

    Public Function BuscarId(ByVal IdInforme As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeClinicoSM_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
