Imports System.Data.SqlClient

Public Class TareaGenericasAlumnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("codAsig") = DropDownList1.SelectedValue
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Ad.Conectar()
        Dim alumnoAsignaturas As SqlDataReader = Ad.ObtenerAsigDeAlumno(Session("email"))
        While (alumnoAsignaturas.Read())
            DropDownList1.Items.Add(alumnoAsignaturas.GetValue(0))
        End While
        Ad.CerrarConexion()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim codAsig = DropDownList1.SelectedValue
        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Dim tareas As SqlDataAdapter = Ad.ObtenerTareasAsignAlumno(Session("email"), codAsig)
        Dim tareasDataSet As New DataSet
        tareas.Fill(tareasDataSet)
        Dim tareasDataTable As DataTable = tareasDataSet.Tables(0)
        Dim tareasView = New DataView(tareasDataTable)
        tareasView.RowFilter = "codigo LIKE '%" & codAsig & "`%'"
        GridView1.DataSource = tareasView
        GridView1.DataBind()

    End Sub

End Class