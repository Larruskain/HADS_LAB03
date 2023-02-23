Imports UsuariosRegistrados
Public Class Erregistratu
    Inherits System.Web.UI.Page



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Dim Ce As New UsuariosRegistrados.ComprobarEmail()
        Ad.Conectar()

        Dim kont As Integer = 0
        Dim egiaztatzeZenbakia As Integer = CLng(Rnd() * 9000000) + 1000000
        Dim PErabiltzaileMota As String = "normalUser"
        Dim a1 As String = TextBox1.Text
        Dim a2 As String = TextBox2.Text
        Dim a3 As String = TextBox3.Text
        Dim a4 As String = TextBox4.Text
        Dim a5 As String = TextBox5.Text
        Dim a6 As Integer = TextBox6.Text
        Dim a9 As String = TextBox9.Text
        Dim a10 As String = TextBox10.Text
        Dim a11 As String = TextBox11.Text

        Dim emailCorrecto As Boolean = Ce.EsCorrectoForm(a1)

        If a1 = "" Or a2 = "" Or a3 = "" Or a4 = "" Or a5 = "" Or a9 = "" Or a10 = "" Or a11 = "" Then
            kont = kont + 1
            Label5.Text = "Tienes que rellenar todos los datos para poder registrarte"

        End If

        If Not emailCorrecto Then
            kont = kont + 1
            Label1.Text = "El formato del email es incorrecto"

        End If

        If (kont = 0) Then
            Try
                'konprobau email hori dauken usuaxoik eztaola datubasin
                If Not Ad.ObtenerUsuario(a1).HasRows Then
                    Ad.CerrarConexion()
                    Ad.Conectar()
                    Dim InsUser As Integer = Ad.InsertarUsuario(a1, a2, a3, a4, a5, a6, egiaztatzeZenbakia, 0, a9, a10, PErabiltzaileMota, a11)

                    Label1.Text = " "
                    Label3.Text = " "
                    Label4.Text = " "
                    Label5.Text = " "
                    Label2.Text = "Te has registrado correctamente. Haz click en el siguiente enlace para hacer la verificación"
                    'hyperlink-e 


                Else
                    'error, 
                    Label3.Text = " "
                    Label4.Text = " "
                    Label5.Text = " "
                    Label1.Text = "En la base de datos ya se encuentra un usuario con la misma dirección de email"
                    Label2.Text = " "
                End If


            Catch ex As Exception

            End Try
        End If


        Ad.CerrarConexion()
    End Sub
End Class