Imports System.Data.SqlClient

Public Class TareaGenericasAlumnos
    Inherits System.Web.UI.Page

    Dim connection_DB_HADS As SqlConnection
    Dim command_DB_HADS As SqlCommand
    Dim strconnection_DB_HADS As String = "Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

    'connection_DB_HADS.Open()


    Dim dSet As New DataSet
    Dim tblMbrs As New DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Page.IsPostBack Then
            dSet = Session("datos")

        Else

            Dim dAdap As New System.Data.SqlClient.SqlDataAdapter
            dAdap = UsuariosRegistrados.AccesoDatos.ObtenerTareasAsignAlumno(Session("email"))
            dAdap.Fill(dSet)
            tblMbrs = dSet.Tables("Tareas")
            GridView1.DataSource = tblMbrs
            GridView1.DataBind()
            Session("datos") = dSet
            Session("adaptador") = dAdap
        End If


    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim dSet = Session("datos")
        Dim tblMbrs = dSet.Tables(0)
        Dim dView = New DataView(tblMbrs)
        dView.RowFilter = "codigo LIKE '%" & DropDownList1.SelectedValue & "%'"
        GridView1.DataSource = dView
        GridView1.DataBind()
    End Sub
End Class