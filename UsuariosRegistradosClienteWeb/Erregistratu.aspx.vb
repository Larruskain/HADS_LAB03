Imports UsuariosRegistrados
Public Class Erregistratu
    Inherits System.Web.UI.Page



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Dim Ce As New UsuariosRegistrados.ComprobarEmail()
        Ad.Conectar()

        Dim kont As Integer = 0
        Dim egiaztatzeZenbakia As Integer = CLng(Rnd() * 9000000) + 1000000

        Dim email As String = TextBox1.Text
        Dim izena As String = TextBox2.Text
        Dim abizena As String = TextBox3.Text
        Dim tipo As String = TextBox4.Text
        Dim pass As String = TextBox5.Text


        Dim emailCorrecto As Boolean = Ce.EsCorrectoForm(email)

        If email = "" Or izena = "" Or abizena = "" Or tipo = "" Or pass = "" Then
            kont = kont + 1
            Label5.Text = "Tienes que rellenar todos los datos para poder registrarte"

        End If
        'If Not IsNumeric(a6) Then
        'kont = kont + 1
        'Label6.Text = "El DNI hay introducirlo sin la letra"
        'End If

        If Not emailCorrecto Then
            kont = kont + 1
            Label1.Text = "El formato del email es incorrecto"

        End If

        If (kont = 0) Then
            Try
                'konprobau email hori dauken usuaxoik eztaola datubasin

                If Not Ad.ObtenerUsuario(email).HasRows Then
                    Ad.CerrarConexion()
                    Ad.Conectar()
                    Dim InsUser As Integer = Ad.InsertarUsuario(email, izena, abizena, egiaztatzeZenbakia, 0, tipo, pass, 1234)
                    Session("email") = email
                    'Dim InsUser2 As Integer = Ad.InsertarUsuario2(a1, a2)
                    Label1.Text = " "
                    Label3.Text = " "
                    Label4.Text = " "
                    Label5.Text = " "

                    Label2.Text = "Te has registrado correctamente. Haz click en el siguiente enlace para completar la verificación"
                    'hyperlink-e 
                    Dim pageid As String = "Egiaztatu.aspx"
                    Dim port As Integer = Request.ServerVariables("server_port")
                    HyperLink1.Visible = True
                    HyperLink1.NavigateUrl = String.Format("https://localhost:" & port & "/Egiaztatu.aspx?erab=" & email & "&egZenb=" & egiaztatzeZenbakia, pageid)
                    HyperLink1.Text = String.Format("http://localhost:" & port & "/Egiaztatu.aspx?erab=" & email & "&egZenb=" & egiaztatzeZenbakia)
                    Ad.CerrarConexion()
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




    End Sub
End Class