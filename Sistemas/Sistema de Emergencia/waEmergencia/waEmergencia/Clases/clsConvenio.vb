﻿Imports System.Data.SqlClient
Public Class clsConvenio
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

        Servidor = "ServidorSQL"
        Base = "dbCaja"
        Usuario = "SA"
        Password = "hrdt2003"


        Cn.ConnectionString = "Database='" + Base + "';Data Source='" + Servidor + "';User Id='" + Usuario + "';Password='" + Password + "'"
        Try
            Cn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.Exit()
        End Try
    End Sub

    Public Function BuscarCH(IdConvenio As String, Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Convenio_BuscarCH", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarxHistoria(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Convenio_BuscarxHistoria", Cn)
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

    Public Sub GrabarProcedimientos(ByVal IdConvenio As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuRegistro As String, ByVal EquipoRegistro As String, ByVal F1 As String, ByVal F2 As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "Convenio_Procedimientos_Grabar"
        Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.Parameters.Add("@UsuRegistro", SqlDbType.VarChar).Value = UsuRegistro
        Cm.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        If F1 = "  /  /" Then Cm.Parameters.Add("@F1", SqlDbType.VarChar).Value = "" Else Cm.Parameters.Add("@F1", SqlDbType.VarChar).Value = F1
        If F2 = "  /  /" Then Cm.Parameters.Add("@F2", SqlDbType.VarChar).Value = "" Else Cm.Parameters.Add("@F2", SqlDbType.VarChar).Value = F2
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub EliminarEmergencia(ByVal IdConvenio As String, ByVal IdProcedimiento As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "Convenio_Procedimientos_EliminarEmergencia"
        Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.ExecuteNonQuery()
    End Sub
End Class
