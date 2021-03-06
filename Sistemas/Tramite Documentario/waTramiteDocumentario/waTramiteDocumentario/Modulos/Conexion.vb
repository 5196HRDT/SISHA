﻿Imports System.Data.SqlClient
Module Conexion
    Public Cn As New SqlConnection
    Public Sub AbrirConexion()
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
        Catch ex As SqlException
            MessageBox.Show("Se ha perdido la conexión de red, intente de nuevo", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.Exit()
        End Try
    End Sub
End Module
