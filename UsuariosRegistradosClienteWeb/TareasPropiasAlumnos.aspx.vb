Imports System.Data.SqlClient

Public Class TareasPropiasAlumnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = Session("email")
        TextBox2.Text = Session("cod")
        TextBox3.Text = Session("hEst")
        Session("hReales") = TextBox4.Text
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("TareasGenericasAlumnos.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conClsf As SqlConnection
        conClsf = New SqlConnection("Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        Dim dapMbrs As New SqlDataAdapter()
        Dim dstMbrs As New DataSet
        Dim tblMbrs As New DataTable

        Dim tblMbrs = dstMbrs.Tables("EstudianteTareas")
        Dim row As DataRow = tblMbrs.NewRow()
        row("email") = Session("email")
        row("codTarea") = Session("cod")
        row("hEstimadas") = Session("hEst")
        row("hReales") = Session("hReales")
        tblMbrs.Rows.Add(row)
        GridView1.DataSource = tblMbrs
        GridView1.DataBind()


    End Sub
End Class