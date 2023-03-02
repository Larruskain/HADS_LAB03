Imports System.Data.SqlClient

Public Class TareaGenericasAlumnos
    Inherits System.Web.UI.Page


    'connection_DB_HADS.Open()





    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tblMbrs As New DataTable
        Dim dSet As New DataSet

        Dim connection_DB_HADS As SqlConnection
        Dim command_DB_HADS As SqlCommand
        Dim strconnection_DB_HADS As String = "Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

        If Page.IsPostBack Then
            dSet = Session("datos")

        Else
            Dim adap As New System.Data.SqlClient.SqlDataAdapter
            connection_DB_HADS = New SqlConnection(strconnection_DB_HADS)
            connection_DB_HADS.Open()
            Dim strSQL = "SELECT TG.codigo,TG.descripcion,TG.hEstimadas,TG.tipoTarea FROM ((EstudianteGrupo As EG INNER JOIN GrupoClase AS GC ON  EG.grupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON TG.codAsig = A.codigo WHERE (EG.email='" + Session("email") + "')"
            command_DB_HADS = New SqlCommand(strSQL)
            command_DB_HADS.Connection = connection_DB_HADS
            adap.SelectCommand = command_DB_HADS
            adap.Fill(dSet)
            Session("datos") = dSet
            GridView1.DataSource = dSet


            connection_DB_HADS.Close()
        End If


    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim dSet2 = Session("datos")
        Dim tblMbrs = dSet2.Tables(0)
        Dim dView = New DataView(tblMbrs)
        dView.RowFilter = "codigo LIKE '%" & DropDownList1.SelectedValue & "%'"
        GridView1.DataSource = dView
        GridView1.DataBind()
    End Sub
End Class