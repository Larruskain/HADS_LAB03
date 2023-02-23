Imports System.Data.SqlClient
Imports System.Reflection.Emit

Public Class recoverPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = Session("email")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Ad.Conectar()
        Label1.Text = " "
        Dim a As String = TextBox1.Text

        Try
            Dim rdr As SqlDataReader = Ad.ObtenerUsuario(a)
            Dim GetInvHeaderValue As String
            If rdr.HasRows Then

                GetInvHeaderValue = Convert.ToString(rdr.Read())

            Else
                GetInvHeaderValue = "No Records Returned"
            End If
            Dim c As String = rdr.Item("galderaEzkutua")
            TextBox2.Text = c

        Catch ex As Exception
            Label1.Text = "El usuario no es el correcto"
        End Try
        Ad.CerrarConexion()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Dim a As String = TextBox1.Text
        Dim b As String = TextBox3.Text
        Label1.Text = " "
        Try
            Dim rdr As SqlDataReader = Ad.ObtenerUsuario(a)
            Dim GetInvHeaderValue As String
            If rdr.HasRows Then

                GetInvHeaderValue = Convert.ToString(rdr.Read())

            Else
                GetInvHeaderValue = "No Records Returned"
            End If
            Dim c As String = rdr.Item("erantzuna")
            If c = b Then
                TextBox4.Text = rdr.Item("pasahitza")
            Else
                Label1.Text = "La respuesta no es correcta"
            End If

        Catch ex As Exception
            Label1.Text = "El usuario no es correcto"
        End Try
        Ad.CerrarConexion()
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class