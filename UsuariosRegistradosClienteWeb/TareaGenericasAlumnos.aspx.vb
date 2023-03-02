Imports System.Data.SqlClient

Public Class TareaGenericasAlumnos
    Inherits System.Web.UI.Page

    Dim connection_DB_HADS As SqlConnection
    Dim command_DB_HADS As SqlCommand
    Dim strconnection_DB_HADS As String = "Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

    'connection_DB_HADS.Open()
    Dim dAdap As New SqlDataAdapter
    Dim strSQL As String
    Dim dSet As New DataSet
    Dim tblMbrs As New DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Page.IsPostBack Then
            dSet = Session("datos")

        Else
            connection_DB_HADS = New SqlConnection(strconnection_DB_HADS)
            strSQL = "SELECT TG.codigo,TG.descripcion,TG.hEstimadas,TG.tipoTarea FROM ((EstudianteGrupo As EG INNER JOIN GrupoClase AS GC ON  EG.grupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON TG.codAsig = A.codigo WHERE (EG.email= +'" + Session("email") + "')AND (TG.explotacion =" + 1 + ")"
            command_DB_HADS = New SqlCommand(strSQL)
            command_DB_HADS.Connection = connection_DB_HADS
            dAdap.SelectCommand = command_DB_HADS
            dAdap.Fill(dSet, "Tareas")
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