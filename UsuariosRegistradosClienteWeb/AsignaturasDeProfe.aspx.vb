Imports System.Data.SqlClient

Public Class AsignaturasDeProfe
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Ad.Conectar()
        Response.Write("<br> Contenido de la TABLA:<br>")
        Dim rdr As SqlDataReader = Ad.ObtenerAsigDeProf("nkolarrus@gmail.com")
        Dim GetInvHeaderValue As String
        If rdr.HasRows Then

            GetInvHeaderValue = Convert.ToString(rdr.Read())

        Else
            GetInvHeaderValue = "No Records Returned"
        End If
        Response.Write("<br>" + GetInvHeaderValue + "<br>")
        Ad.CerrarConexion()
    End Sub

End Class