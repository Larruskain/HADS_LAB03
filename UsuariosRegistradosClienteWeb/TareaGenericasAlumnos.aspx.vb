Imports System.Data.SqlClient

Public Class TareaGenericasAlumnos
    Inherits System.Web.UI.Page


    'connection_DB_HADS.Open()





    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dSet As New DataSet
        Dim tblMbrs As New DataTable
        Dim connection_DB_HADS = New SqlConnection("Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        Dim command_DB_HADS As SqlCommand


        If Page.IsPostBack Then
            dSet = Session("datos")

        Else
            connection_DB_HADS.Open()
            Dim strSQL = "SELECT TG.codigo,TG.descripcion,TG.hEstimadas,TG.tipoTarea FROM ((EstudianteGrupo As EG INNER JOIN GrupoClase AS GC ON  EG.grupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON TG.codAsig = A.codigo WHERE (EG.email='" + Session("email") + "')"
            Dim adap = New SqlDataAdapter(strSQL, connection_DB_HADS)
            adap.Fill(dSet)

            Session("datos") = dSet

            tblMbrs = dSet.Tables(0)
            Dim dView = New DataView(tblMbrs)
            dView.RowFilter = "codigo LIKE '%" & DropDownList1.SelectedValue & "%'"
            GridView1.DataSource = dView

            GridView1.DataBind()

            connection_DB_HADS.Close()
        End If


    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim dSet2 = Session("datos")
        Dim tblMbrs2 = dSet2.Tables(0)
        Dim dView = New DataView(tblMbrs2)
        dView.RowFilter = "codigo LIKE '%" & DropDownList1.SelectedValue & "%'"
        GridView1.DataSource = dView
        GridView1.DataBind()
    End Sub
End Class