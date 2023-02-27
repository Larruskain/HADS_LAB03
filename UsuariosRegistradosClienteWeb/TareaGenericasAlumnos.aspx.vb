Imports System.Data.SqlClient

Public Class TareaGenericasAlumnos
    Inherits System.Web.UI.Page

    Dim tareasDataSet As New DataSet


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Ad As New UsuariosRegistrados.AccesoDatos()
        Ad.Conectar()
        Dim alumnoAsignaturas As SqlDataReader = Ad.ObtenerAsigDeAlumno(Session("email"))
        While (alumnoAsignaturas.Read())
            DropDownList1.Items.Add(alumnoAsignaturas.GetValue(0))
        End While
        Ad.CerrarConexion()


        Ad.Conectar()
        Dim tareas As SqlDataAdapter = Ad.ObtenerTareasAsignAlumno(Session("email"))
        tareas.Fill(tareasDataSet)
        Ad.CerrarConexion()

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim codAsig = DropDownList1.SelectedValue
        Dim tareasDataTable As DataTable = tareasDataSet.Tables(0)
        Dim tareasView = New DataView(tareasDataTable)
        tareasView.RowFilter = "codigo LIKE '%" & codAsig & "`%'"
        GridView1.DataSource = tareasView
        GridView1.DataBind()

    End Sub

End Class