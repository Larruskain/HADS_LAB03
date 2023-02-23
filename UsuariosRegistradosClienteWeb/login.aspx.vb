Imports System.Data.SqlClient
Imports System.Web.Services.Description
Imports UsuariosRegistrados
Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Ad.Conectar()
        Label1.Text = " "
        Dim a As String = TextBox1.Text
        Dim b As String = TextBox2.Text
        Try
            Dim rdr As SqlDataReader = Ad.ObtenerUsuario(a)

            Dim GetInvHeaderValue As String
            If rdr.HasRows Then

                GetInvHeaderValue = Convert.ToString(rdr.Read())

            Else
                GetInvHeaderValue = "No Records Returned"
            End If
            Dim c As String = rdr.Item("pass")
            'TextBox3.Text = c
            If (c = b) Then
                If (rdr.Item("tipo") = "Alumno") Then
                    Response.Redirect("alumno.aspx")
                ElseIf (rdr.Item("tipo") = "Profesor") Then
                    Response.Redirect("Profesor.aspx")
                End If

            Else
                Label1.Text = "La contraseña no es la correcta"
            End If
            Ad.CerrarConexion()
        Catch ex As Exception
            Label1.Text = "El usuario no es el correcto"
        End Try


    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Session("email") = TextBox1.Text
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("Hasiera.aspx")
    End Sub
End Class