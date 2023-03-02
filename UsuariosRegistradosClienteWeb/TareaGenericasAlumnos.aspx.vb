Imports System.Data.SqlClient

Public Class TareaGenericasAlumnos
    Inherits System.Web.UI.Page

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim indizea As Integer
        indizea = GridView1.SelectedIndex
        Session("cod") = GridView1.Rows(indizea).Cells(1).Text
        Session("descr") = GridView1.Rows(indizea).Cells(2).Text
        Session("hEst") = GridView1.Rows(indizea).Cells(3).Text
        Session("tipoTarea") = GridView1.Rows(indizea).Cells(4).Text
        Response.Redirect("TareasPropiasAlumnos.aspx")
    End Sub
End Class