Imports System.Data.SqlClient
Module Conexion
    Public CN As New SqlConnection("Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003")

    Public Sub AbrirBD()
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
    End Sub
End Module
