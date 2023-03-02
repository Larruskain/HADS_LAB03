Imports System.Data.SqlClient

Public Class ProfesorTareas
    Inherits System.Web.UI.Page
    Dim ds As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, DropDownList1.SelectedIndexChanged, DropDownList1.TextChanged, GridView2.DataBinding

    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("InsertarTareaProfe.aspx")
    End Sub
End Class