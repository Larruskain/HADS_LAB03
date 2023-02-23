Imports System.Data.SqlClient

Public Class changePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = Session("email")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Dim a As String = TextBox1.Text
        Dim b As String = TextBox2.Text
        Dim d As String = TextBox3.Text
        Label1.Text = " "
        Try
            Ad.Conectar()
            Dim rdr As SqlDataReader = Ad.ObtenerUsuario(a)
            Dim GetInvHeaderValue As String
            If rdr.HasRows Then

                GetInvHeaderValue = Convert.ToString(rdr.Read())

            Else
                GetInvHeaderValue = "No Records Returned"
            End If
            Dim c As String = rdr.Item("pasahitza")
            If c = b Then
                Try
                    Ad.CerrarConexion()
                    Ad.Conectar()
                    Dim f As Integer = Ad.ModificarContraseñaUsuario(a, d)
                    Label1.Text = "Ha sido modificado correctamente --> " + f.ToString
                Catch ex As Exception
                    Label1.Text = "No ha sido modificado correctamente"
                End Try
            Else
                Label1.Text = "La contraseña no es correcta"
            End If

        Catch ex As Exception
            Label1.Text = "El usuario no es correcto"
        End Try
        Ad.CerrarConexion()
    End Sub

End Class