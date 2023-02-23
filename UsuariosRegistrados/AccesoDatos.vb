Imports System.Data.SqlClient

Public Class AccesoDatos

    Private Shared connection_DB_HADS As SqlConnection
    Private Shared command_DB_HADS As SqlCommand

    Public Sub New()
        Conectar()

    End Sub

    Public Shared Sub Conectar()
        Dim strconnection_DB_HADS As String = "Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

        Try
            connection_DB_HADS = New SqlConnection(strconnection_DB_HADS)
            connection_DB_HADS.Open()
        Catch ex As Exception
            Throw New ConnectionError()
        End Try
    End Sub

    Public Shared Sub CerrarConexion()
        Try
            connection_DB_HADS.Close()
        Catch ex As Exception
            Throw New CloseConnectionError()
        End Try
    End Sub

    Public Shared Function InsertarUsuario(ByVal pEmail As String, ByVal pIzena As String, ByVal pAbizena As String, ByVal pGalderaEzk As String, ByVal pErantzuna As String, ByVal pDni As Integer, ByVal pEgiaztatzeZbk As Integer, ByVal pEgiaztatua As Boolean, ByVal pLantaldeKodea As String, ByVal pAzpitaldeKodea As String, ByVal pErabiltzaileMota As String, ByVal pPass As String) As Integer
        Dim cmdErabiltzaileaTxertatu As SqlCommand
        Dim strSQL As String = "INSERT INTO Erabiltzaileak ([email], [izena], [abizena], [galderaEzkutua], [erantzuna], [na], [egiaztatzeZenbakia], [egiaztatua], [lantaldeKodea], [azpitaldeKodea], [erabiltzaileMota], [pasahitza]) VALUES (@pEmail,@pIzena,@pAbizena,@pGalderaEzk,@pErantzuna,@pDni,@pEgiaztatzeZbk,@pEgiaztatua,@pLantaldeKodea,@pAzpitaldeKodea,@pErabiltzaileMota,@pPass)"


        Try
            cmdErabiltzaileaTxertatu = New SqlCommand(strSQL, connection_DB_HADS)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pEmail", pEmail)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pIzena", pIzena)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pAbizena", pAbizena)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pGalderaEzk", pGalderaEzk)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pErantzuna", pErantzuna)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pDni", pDni)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pEgiaztatzeZbk", pEgiaztatzeZbk)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pEgiaztatua", pEgiaztatua)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pLantaldeKodea", pLantaldeKodea)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pAzpitaldeKodea", pAzpitaldeKodea)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pErabiltzaileMota", pErabiltzaileMota)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pPass", pPass)

            Return cmdErabiltzaileaTxertatu.ExecuteNonQuery() 'saiatu INSERT-a exekutatzen
        Catch
            Throw New InsertarError()
        End Try

    End Function

    Public Shared Function InsertarUsuario2(ByVal pEmail As String, ByVal pIzena As String) As Integer
        Dim cmdErabiltzaileaTxertatu As SqlCommand
        Dim strSQL As String = "INSERT INTO Erabiltzaileak ([email],[izena]) VALUES (@email,@izena)"
        cmdErabiltzaileaTxertatu = New SqlCommand(strSQL, connection_DB_HADS)
        cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@email", pEmail)
        cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@izena", pIzena)
        Try

            Return cmdErabiltzaileaTxertatu.ExecuteNonQuery()
        Catch
            Throw New InsertarError()
        End Try

    End Function

    Public Shared Function ObtenerUsuario(ByVal pEmail As String) As SqlDataReader
        Dim cmdErabiltzaileaLortu As SqlCommand
        Dim strSQL = "SELECT * FROM Erabiltzaileak WHERE (email = '" + pEmail + "')"

        Try
            cmdErabiltzaileaLortu = New SqlCommand(strSQL, connection_DB_HADS)
            Return (cmdErabiltzaileaLortu.ExecuteReader())
        Catch ex As Exception
            Throw New ObtenerUsuarioError()
        End Try

    End Function

    Public Shared Function ComprobarUsuario(ByVal pEmail As String) As Integer
        Dim cmdErabiltzaileaAktualizatu As SqlCommand
        Dim strSQL = "UPDATE Erabiltzaileak SET confirmado = 1 WHERE (email = '" + pEmail + "')"
        Try
            cmdErabiltzaileaAktualizatu = New SqlCommand(strSQL, connection_DB_HADS)
            Return cmdErabiltzaileaAktualizatu.ExecuteNonQuery()
        Catch ex As Exception
            Throw New ObtenerUsuarioError()
        End Try
    End Function

    Public Shared Function ModificarContraseñaUsuario(ByVal pEmail As String, ByVal pNewContraseña As String) As Integer
        Dim cmdErabiltzaileaAktualizatu As SqlCommand
        Dim strSQL = "UPDATE Erabiltzaileak SET pass = '" + pNewContraseña + "' WHERE (email = '" + pEmail + "')"
        Try
            cmdErabiltzaileaAktualizatu = New SqlCommand(strSQL, connection_DB_HADS)
            Return cmdErabiltzaileaAktualizatu.ExecuteNonQuery()
        Catch ex As Exception
            Throw New ObtenerUsuarioError()
        End Try
    End Function



End Class
