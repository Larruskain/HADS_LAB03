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

    Public Shared Function InsertarUsuario(ByVal pEmail As String, ByVal pIzena As String, ByVal pAbizena As String, ByVal pNumConf As Integer, ByVal pConfirmado As Boolean, ByVal pTipo As String, ByVal pPass As String, ByVal pCodPass As Integer) As Integer
        Dim cmdErabiltzaileaTxertatu As SqlCommand
        Dim strSQL As String = "INSERT INTO Usuario ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (@pEmail,@pIzena,@pAbizena,@pnumConfir,@pConfirmado,@pTipo,@pPass,@pCodPass)"


        Try
            cmdErabiltzaileaTxertatu = New SqlCommand(strSQL, connection_DB_HADS)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pEmail", pEmail)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pIzena", pIzena)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pAbizena", pAbizena)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pnumConfir", pNumConf)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pConfirmado", pConfirmado)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pTipo", pTipo)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pPass", pPass)
            cmdErabiltzaileaTxertatu.Parameters.AddWithValue("@pCodPass", pCodPass)


            Return cmdErabiltzaileaTxertatu.ExecuteNonQuery() 'saiatu INSERT-a exekutatzen
        Catch
            Throw New InsertarError()
        End Try

    End Function

    Public Shared Function InsertarUsuario2(ByVal pEmail As String, ByVal pIzena As String) As Integer
        Dim cmdErabiltzaileaTxertatu As SqlCommand
        Dim strSQL As String = "INSERT INTO Usuario ([email],[izena]) VALUES (@email,@izena)"
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
        Dim strSQL = "SELECT * FROM Usuario WHERE (email = '" + pEmail + "')"

        Try
            cmdErabiltzaileaLortu = New SqlCommand(strSQL, connection_DB_HADS)
            Return (cmdErabiltzaileaLortu.ExecuteReader())
        Catch ex As Exception
            Throw New ObtenerUsuarioError()
        End Try

    End Function
    'Dim ds As New DataSet
    'Public Shared Function ObtenerAsigDeProf(ByVal pEmail As String) As SqlDataReader
    ' Dim cmdErabiltzaileaLortu As SqlCommand
    'Using cnn As New SqlConnection("Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    '       cnn.Open()
    'Dim adapter As New SqlDataAdapter("SELECT A.nombre FROM (ProfesorGrupo As PG INNER JOIN GrupoClase AS GC ON  PG.codigoGrupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo WHERE (PG.email='" + pEmail + "')")
    '       adapter.Fill(ds)
    '

    'End Using
    'End Function

    Public Shared Function ObtenerAsigDeAlumno(ByVal pEmail As String) As SqlDataReader
        Dim cmdErabiltzaileaLortu As SqlCommand
        Dim strSQL = "SELECT A.codigo FROM (EstudianteGrupo As EG INNER JOIN GrupoClase AS GC ON  EG.grupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo WHERE (EG.email='" + pEmail + "')"

        Try
            cmdErabiltzaileaLortu = New SqlCommand(strSQL, connection_DB_HADS)
            Return (cmdErabiltzaileaLortu.ExecuteReader())
        Catch ex As Exception
            Throw New ObtenerUsuarioError()
        End Try
    End Function

    Public Shared Function ObtenerTareasAsignAlumno(ByVal pEmail As String, ByVal pAsign As String) As SqlDataAdapter
        Dim adap As New SqlDataAdapter
        Dim cmdErabiltzaileaLortu As SqlCommand
        Dim strSQL = "SELECT TG.codigo,TG.descripcion,TG.hEstimadas,TG.tipoTarea FROM ((EstudianteGrupo As EG INNER JOIN GrupoClase AS GC ON  EG.grupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON TG.codAsig = A.codigo WHERE (EG.email='" + pEmail + "') AND (A.Codigo= '" + pAsign + "') AND WHERE (TG.Explotacion= " + 0 + ")"

        Try
            cmdErabiltzaileaLortu = New SqlCommand(strSQL)
            cmdErabiltzaileaLortu.Connection = connection_DB_HADS
            adap.SelectCommand = cmdErabiltzaileaLortu
            Return adap
        Catch ex As Exception
            Throw New ObtenerUsuarioError()
        End Try
    End Function

    Public Shared Function ComprobarUsuario(ByVal pEmail As String) As Integer
        Dim cmdErabiltzaileaAktualizatu As SqlCommand
        Dim strSQL = "UPDATE Usuario SET confirmado = 1 WHERE (email = '" + pEmail + "')"
        Try
            cmdErabiltzaileaAktualizatu = New SqlCommand(strSQL, connection_DB_HADS)
            Return cmdErabiltzaileaAktualizatu.ExecuteNonQuery()
        Catch ex As Exception
            Throw New ObtenerUsuarioError()
        End Try
    End Function

    Public Shared Function ModificarContraseñaUsuario(ByVal pEmail As String, ByVal pNewContraseña As String) As Integer
        Dim cmdErabiltzaileaAktualizatu As SqlCommand
        Dim strSQL = "UPDATE Usuario SET pass = '" + pNewContraseña + "' WHERE (email = '" + pEmail + "')"
        Try
            cmdErabiltzaileaAktualizatu = New SqlCommand(strSQL, connection_DB_HADS)
            Return cmdErabiltzaileaAktualizatu.ExecuteNonQuery()
        Catch ex As Exception
            Throw New ObtenerUsuarioError()
        End Try
    End Function




End Class
