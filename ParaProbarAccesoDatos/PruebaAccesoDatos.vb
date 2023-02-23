Imports System.Data.SqlClient

Module PruebaAccesoDatos

    Sub Main()
        Dim Ad As UsuariosRegistrados.AccesoDatos
        Dim a As String = Console.ReadLine()
        Dim b As String = Console.ReadLine()
        Ad.Conectar()
        Console.WriteLine(Ad.InsertarUsuario2(a, b))
        Ad.CerrarConexion()
        Console.WriteLine("Insertado")

        Ad.Conectar()

        Dim rdr As SqlDataReader = Ad.ObtenerUsuario("nkolarrus@gmail.com")

        Dim GetInvHeaderValue As String
        If rdr.HasRows Then

            GetInvHeaderValue = Convert.ToString(rdr.Read())

        Else
            GetInvHeaderValue = "No Records Returned"
        End If
        Console.WriteLine("Obtener el primer usuario")
        Console.WriteLine(rdr.Item(0))
        Console.WriteLine(rdr.Item(1))
        Console.WriteLine(rdr.Item(2))
        Ad.CerrarConexion()

        Ad.Conectar()
        Console.WriteLine("Pasame el email que quieras comprobar:")
        Dim c As String = Console.ReadLine()
        Console.WriteLine(Ad.ComprobarUsuario(c))
        Ad.CerrarConexion()

        Ad.Conectar()
        Console.WriteLine("Email para cambiar contra:")
        Dim d As String = Console.ReadLine()
        Console.WriteLine("Nueva contra:")
        Dim e As String = Console.ReadLine()
        Console.WriteLine(Ad.ModificarContraseñaUsuario(d, e))
        Ad.CerrarConexion()
        Console.ReadLine()
    End Sub

End Module
