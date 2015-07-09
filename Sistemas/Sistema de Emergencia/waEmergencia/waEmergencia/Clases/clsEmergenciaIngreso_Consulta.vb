Imports System.Data.SqlClient
Public Class clsEmergenciaIngreso_Consulta
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
    Public Sub PriorizarDx(ByVal D1 As Boolean, ByVal D2 As Boolean, ByVal D3 As Boolean, _
                            ByVal D4 As Boolean, ByVal D5 As Boolean, ByVal D6 As Boolean)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter("EmergenciaIngreso_DxPrimario", Cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@dx1", SqlDbType.Bit).Value = D1
        da.SelectCommand.Parameters.Add("@dx2", SqlDbType.Bit).Value = D2
        da.SelectCommand.Parameters.Add("@dx3", SqlDbType.Bit).Value = D3
        da.SelectCommand.Parameters.Add("@dx4", SqlDbType.Bit).Value = D4
        da.SelectCommand.Parameters.Add("@dx5", SqlDbType.Bit).Value = D5
        da.SelectCommand.Parameters.Add("@dx6", SqlDbType.Bit).Value = D6
        da.SelectCommand.ExecuteNonQuery()
    End Sub
    Public Sub ModificarPrioridadDx(ByVal idIngreso As Integer, ByVal D1 As Boolean, ByVal D2 As Boolean, ByVal D3 As Boolean, _
                                ByVal D4 As Boolean, ByVal D5 As Boolean, ByVal D6 As Boolean)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter("EmergenciaIngreso_DxPrimarioModificar", Cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@idIngreso", SqlDbType.Int).Value = Val(idIngreso)
        da.SelectCommand.Parameters.Add("@dx1", SqlDbType.Bit).Value = D1
        da.SelectCommand.Parameters.Add("@dx2", SqlDbType.Bit).Value = D2
        da.SelectCommand.Parameters.Add("@dx3", SqlDbType.Bit).Value = D3
        da.SelectCommand.Parameters.Add("@dx4", SqlDbType.Bit).Value = D4
        da.SelectCommand.Parameters.Add("@dx5", SqlDbType.Bit).Value = D5
        da.SelectCommand.Parameters.Add("@dx6", SqlDbType.Bit).Value = D6
        da.SelectCommand.ExecuteNonQuery()
    End Sub


    Public Sub GrabarSala(ByVal IdIngreso As String, ByVal Fecha As String, ByVal Hora As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Presion As String, ByVal Temperatura As String, ByVal MolestiaPrincipal As String, ByVal TiempoEnfermedad As String, ByVal FormaInicio As String, ByVal C As String, ByVal EnfermedadActual As String, ByVal Apetito As String, ByVal Sed As String, ByVal Orina As String, ByVal Deposiciones As String, ByVal Sueño As String, ByVal PesoFB As String, ByVal ExamenFisico As String, ByVal Cie1 As String, ByVal DesCie1 As String, ByVal Lab1 As String, ByVal TD1 As String, ByVal Cie2 As String, ByVal DesCie2 As String, ByVal Lab2 As String, ByVal TD2 As String, ByVal Cie3 As String, ByVal DesCie3 As String, ByVal Lab3 As String, ByVal TD3 As String, ByVal Cie4 As String, ByVal DesCie4 As String, ByVal Lab4 As String, ByVal TD4 As String, ByVal Cie5 As String, ByVal DesCie5 As String, ByVal Lab5 As String, ByVal TD5 As String, ByVal Cie6 As String, ByVal DesCie6 As String, ByVal Lab6 As String, ByVal TD6 As String, ByVal AntecedentesPat As String, ByVal AntecedentesFam As String, ByVal Origen As String, ByVal DesOrigen As String, ByVal Cama As String, ByVal Sala As String, ByVal RCP As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaIngreso_ConsultaGrabarSala", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
        daTabla.SelectCommand.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
        daTabla.SelectCommand.Parameters.Add("@Pulso", SqlDbType.VarChar).Value = Pulso
        daTabla.SelectCommand.Parameters.Add("@Presion", SqlDbType.VarChar).Value = Presion
        daTabla.SelectCommand.Parameters.Add("@Temperatura", SqlDbType.VarChar).Value = Temperatura
        daTabla.SelectCommand.Parameters.Add("@MolestiaPrincipal", SqlDbType.VarChar).Value = MolestiaPrincipal
        daTabla.SelectCommand.Parameters.Add("@TiempoEnfermedad", SqlDbType.VarChar).Value = TiempoEnfermedad
        daTabla.SelectCommand.Parameters.Add("@FormaInicio", SqlDbType.VarChar).Value = FormaInicio
        daTabla.SelectCommand.Parameters.Add("@C", SqlDbType.VarChar).Value = C
        daTabla.SelectCommand.Parameters.Add("@EnfermedadActual", SqlDbType.VarChar).Value = EnfermedadActual
        daTabla.SelectCommand.Parameters.Add("@Apetito", SqlDbType.VarChar).Value = Apetito
        daTabla.SelectCommand.Parameters.Add("@Sed", SqlDbType.VarChar).Value = Sed
        daTabla.SelectCommand.Parameters.Add("@Orina", SqlDbType.VarChar).Value = Orina
        daTabla.SelectCommand.Parameters.Add("@Deposiciones", SqlDbType.VarChar).Value = Deposiciones
        daTabla.SelectCommand.Parameters.Add("@Sueño", SqlDbType.VarChar).Value = Sueño
        daTabla.SelectCommand.Parameters.Add("@PesoFB", SqlDbType.VarChar).Value = PesoFB
        daTabla.SelectCommand.Parameters.Add("@ExamenFisico", SqlDbType.VarChar).Value = ExamenFisico
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
        daTabla.SelectCommand.Parameters.Add("@AntecedentesPat", SqlDbType.VarChar).Value = AntecedentesPat
        daTabla.SelectCommand.Parameters.Add("@AntecedentesFam", SqlDbType.VarChar).Value = AntecedentesFam
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@DesOrigen", SqlDbType.VarChar).Value = DesOrigen
        daTabla.SelectCommand.Parameters.Add("@Cama", SqlDbType.VarChar).Value = Cama
        daTabla.SelectCommand.Parameters.Add("@Sala", SqlDbType.VarChar).Value = Sala
        daTabla.SelectCommand.Parameters.Add("@RCP", SqlDbType.VarChar).Value = RCP
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub ModificarSala(ByVal IdIngreso As String, ByVal Fecha As String, ByVal Hora As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Presion As String, ByVal Temperatura As String, ByVal MolestiaPrincipal As String, ByVal TiempoEnfermedad As String, ByVal FormaInicio As String, ByVal C As String, ByVal EnfermedadActual As String, ByVal Apetito As String, ByVal Sed As String, ByVal Orina As String, ByVal Deposiciones As String, ByVal Sueño As String, ByVal PesoFB As String, ByVal ExamenFisico As String, ByVal Cie1 As String, ByVal DesCie1 As String, ByVal Lab1 As String, ByVal TD1 As String, ByVal Cie2 As String, ByVal DesCie2 As String, ByVal Lab2 As String, ByVal TD2 As String, ByVal Cie3 As String, ByVal DesCie3 As String, ByVal Lab3 As String, ByVal TD3 As String, ByVal Cie4 As String, ByVal DesCie4 As String, ByVal Lab4 As String, ByVal TD4 As String, ByVal Cie5 As String, ByVal DesCie5 As String, ByVal Lab5 As String, ByVal TD5 As String, ByVal Cie6 As String, ByVal DesCie6 As String, ByVal Lab6 As String, ByVal TD6 As String, ByVal AntecedentesPat As String, ByVal AntecedentesFam As String, ByVal Origen As String, ByVal DesOrigen As String, ByVal Cama As String, ByVal Sala As String, ByVal RCP As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaIngreso_ConsultaModificarSala", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
        daTabla.SelectCommand.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
        daTabla.SelectCommand.Parameters.Add("@Pulso", SqlDbType.VarChar).Value = Pulso
        daTabla.SelectCommand.Parameters.Add("@Presion", SqlDbType.VarChar).Value = Presion
        daTabla.SelectCommand.Parameters.Add("@Temperatura", SqlDbType.VarChar).Value = Temperatura
        daTabla.SelectCommand.Parameters.Add("@MolestiaPrincipal", SqlDbType.VarChar).Value = MolestiaPrincipal
        daTabla.SelectCommand.Parameters.Add("@TiempoEnfermedad", SqlDbType.VarChar).Value = TiempoEnfermedad
        daTabla.SelectCommand.Parameters.Add("@FormaInicio", SqlDbType.VarChar).Value = FormaInicio
        daTabla.SelectCommand.Parameters.Add("@C", SqlDbType.VarChar).Value = C
        daTabla.SelectCommand.Parameters.Add("@EnfermedadActual", SqlDbType.VarChar).Value = EnfermedadActual
        daTabla.SelectCommand.Parameters.Add("@Apetito", SqlDbType.VarChar).Value = Apetito
        daTabla.SelectCommand.Parameters.Add("@Sed", SqlDbType.VarChar).Value = Sed
        daTabla.SelectCommand.Parameters.Add("@Orina", SqlDbType.VarChar).Value = Orina
        daTabla.SelectCommand.Parameters.Add("@Deposiciones", SqlDbType.VarChar).Value = Deposiciones
        daTabla.SelectCommand.Parameters.Add("@Sueño", SqlDbType.VarChar).Value = Sueño
        daTabla.SelectCommand.Parameters.Add("@PesoFB", SqlDbType.VarChar).Value = PesoFB
        daTabla.SelectCommand.Parameters.Add("@ExamenFisico", SqlDbType.VarChar).Value = ExamenFisico
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
        daTabla.SelectCommand.Parameters.Add("@AntecedentesPat", SqlDbType.VarChar).Value = AntecedentesPat
        daTabla.SelectCommand.Parameters.Add("@AntecedentesFam", SqlDbType.VarChar).Value = AntecedentesFam
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@DesOrigen", SqlDbType.VarChar).Value = DesOrigen
        daTabla.SelectCommand.Parameters.Add("@Cama", SqlDbType.VarChar).Value = Cama
        daTabla.SelectCommand.Parameters.Add("@Sala", SqlDbType.VarChar).Value = Sala
        daTabla.SelectCommand.Parameters.Add("@RCP", SqlDbType.VarChar).Value = RCP
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub ModificarProSala(ByVal IdIngreso As String, ByVal Fecha As String, ByVal Hora As String, ByVal Cie1 As String, ByVal DesCie1 As String, ByVal Lab1 As String, ByVal TD1 As String, ByVal Cie2 As String, ByVal DesCie2 As String, ByVal Lab2 As String, ByVal TD2 As String, ByVal Cie3 As String, ByVal DesCie3 As String, ByVal Lab3 As String, ByVal TD3 As String, ByVal Cie4 As String, ByVal DesCie4 As String, ByVal Lab4 As String, ByVal TD4 As String, ByVal Cie5 As String, ByVal DesCie5 As String, ByVal Lab5 As String, ByVal TD5 As String, ByVal Cie6 As String, ByVal DesCie6 As String, ByVal Lab6 As String, ByVal TD6 As String, ByVal Origen As String, ByVal DesOrigen As String, ByVal Sala As String, ByVal RCP As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaIngreso_ConsultaModificarProSala", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
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
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@DesOrigen", SqlDbType.VarChar).Value = DesOrigen
        daTabla.SelectCommand.Parameters.Add("@Sala", SqlDbType.VarChar).Value = Sala
        daTabla.SelectCommand.Parameters.Add("@RCP", SqlDbType.VarChar).Value = RCP
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function ConsultaBuscar(ByVal IdIngreso As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaIngreso_ConsultaBuscar", Cn)
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
