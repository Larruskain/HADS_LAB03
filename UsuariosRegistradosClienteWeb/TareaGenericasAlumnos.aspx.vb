Imports System.Data.SqlClient

Public Class TareaGenericasAlumnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Ad.Conectar()
        Dim alumnoAsignaturas As SqlDataReader = Ad.ObtenerAsigDeAlumno(Session("email"))
        While (alumnoAsignaturas.Read())
            DropDownList1.Items.Add(alumnoAsignaturas.GetValue(0))
        End While
        Ad.CerrarConexion()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

    End Sub
End Class