Imports System.Data.SqlClient

Public Class TareasPropiasAlumnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connection_DB_HADS = New SqlConnection("Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        TextBox1.Text = Session("email")
        TextBox2.Text = Session("cod")
        TextBox3.Text = Session("hEst")
        Session("hReales") = TextBox4.Text
        'Dim dSet As New DataSet
        ' Dim dTable As New DataTable
        'Dim dAdapter = New SqlDataAdapter("SELECT * FROM EstudianteTarea WHERE (email='" + Session("email") + "')", connection_DB_HADS)
        'Dim bldMbrs As New SqlCommandBuilder(dAdapter)
        'dAdapter.Fill(dSet, "EstudianteTarea")
        'dTable = dSet.Tables("EstudianteTarea")
        'Session("TareasPropiasEstudiante") = dSet
        'Session("DataAdapter") = dAdapter

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

        ' dapMbrs = Session("DataAdapter")
        ' Dim commandBuilder As SqlCommandBuilder = New SqlCommandBuilder(dapMbrs)
        ' dapMbrs.InsertCommand = commandBuilder.GetInsertCommand(True)
        ' dstMbrs = Session("TareasPropiasEstudiante")
        'tblMbrs = dstMbrs.Tables("EstudianteTarea")
        ' Dim row As DataRow = tblMbrs.NewRow()
        ' tblMbrs.Rows.Add(row)
        ' dapMbrs.Update(dstMbrs, "EstudianteTarea")
        ' dstMbrs.AcceptChanges()

        Dim strCommand As String = "insert into EstudianteTarea values('" & TextBox1.Text & "','" & TextBox2.Text & "'," & TextBox3.Text & "," & TextBox4.Text & ")"
        Dim command As SqlCommand = New SqlCommand(strCommand, conClsf)
        command.CommandType = CommandType.Text
        conClsf.Open()
        Dim a As Integer = command.ExecuteNonQuery()

    End Sub
End Class