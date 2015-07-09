Imports System.Data.SqlClient
Public Class clsDetInformeArmasSM
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

    Public Sub Grabar(ByVal IdInforme As String, ByVal Personalidad As String, PuntajeTotal As String, CategoriaInteligencia As String, Organicidad As String, Inestabilidad As String, Agrecividad As String, Impulsividad As String, Hostilidad As String, Retraimiento As String, CondicionPS As String, Cie1 As String, DesCie1 As String, Multidrogas As String, Cie2 As String, DesCie2 As String, Cie3 As String, DesCie3 As String, CondicionPQ As String, Psicologo As String, Psiquiatra As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetInformeArmasSM_Grabar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = Val(IdInforme)
        daTabla.SelectCommand.Parameters.Add("@Personalidad", SqlDbType.VarChar).Value = Personalidad
        daTabla.SelectCommand.Parameters.Add("@PuntajeTotal", SqlDbType.Int).Value = Val(PuntajeTotal)
        daTabla.SelectCommand.Parameters.Add("@CategoriaInteligencia", SqlDbType.VarChar).Value = CategoriaInteligencia
        daTabla.SelectCommand.Parameters.Add("@Organicidad", SqlDbType.VarChar).Value = Organicidad
        daTabla.SelectCommand.Parameters.Add("@Inestabilidad", SqlDbType.VarChar).Value = Inestabilidad
        daTabla.SelectCommand.Parameters.Add("@Agrecividad", SqlDbType.VarChar).Value = Agrecividad
        daTabla.SelectCommand.Parameters.Add("@Impulsividad", SqlDbType.VarChar).Value = Impulsividad
        daTabla.SelectCommand.Parameters.Add("@Hostilidad", SqlDbType.VarChar).Value = Hostilidad
        daTabla.SelectCommand.Parameters.Add("@Retraimiento", SqlDbType.VarChar).Value = Retraimiento
        daTabla.SelectCommand.Parameters.Add("@CondicionPS", SqlDbType.VarChar).Value = CondicionPS
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@DesCie1", SqlDbType.VarChar).Value = DesCie1
        daTabla.SelectCommand.Parameters.Add("@Multidrogas", SqlDbType.VarChar).Value = Multidrogas
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@DesCie2", SqlDbType.VarChar).Value = DesCie2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@DesCie3", SqlDbType.VarChar).Value = DesCie3
        daTabla.SelectCommand.Parameters.Add("@CondicionPQ", SqlDbType.VarChar).Value = CondicionPQ
        daTabla.SelectCommand.Parameters.Add("@Psicologo", SqlDbType.VarChar).Value = Psicologo
        daTabla.SelectCommand.Parameters.Add("@Psiquiatra", SqlDbType.VarChar).Value = Psiquiatra
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(IdInforme As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetInformeArmasSM_Buscar", Cn)
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
