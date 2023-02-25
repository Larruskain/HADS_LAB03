Imports System.Data.SqlClient

Public Class ProfesorTareas
    Inherits System.Web.UI.Page
    Dim ds As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Using cnn As New SqlConnection("Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            cnn.Open()
            Dim adapter As New SqlDataAdapter("SELECT * FROM ((ProfesorGrupo As PG INNER JOIN GrupoClase AS GC ON  PG.codigoGrupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON A.codigo=TG.codAsig WHERE (PG.email='" + Session("email") + "')", cnn)
            adapter.Fill(ds, "TareasYAsigs")
            Dim tblMbr As DataTable
            tblMbr = ds.Tables("TareasYAsigs")
            Dim dv As DataView
            dv = New DataView(tblMbr)
            dv.Sort = "nombre"
            DropDownList1.DataSource = dv.ToTable(True, "nombre")
            DropDownList1.DataTextField = "nombre"
            DropDownList1.DataValueField = "nombre"
            DropDownList1.DataBind()

            If Not IsPostBack Then
                Dim escogido As String = DropDownList1.SelectedItem.Text
                Dim dv2 As DataView
                dv2 = New DataView(tblMbr)
                dv2.RowFilter = "nombre='" + escogido + "'"
                GridView1.DataSource = dv2.ToTable(False, "codigo", "descripcion", "codigoasig", "hEstimadas", "explotacion", "tipoTarea")
                GridView1.DataBind()
            End If

        End Using
    End Sub

    Protected Sub itemSelected(sender As Object, e As EventArgs)
        Dim tblMbr As DataTable
        tblMbr = ds.Tables("TareasYAsigs")
        Dim escogido As String = DropDownList1.SelectedItem.Text
        Dim dv2 As DataView
        dv2 = New DataView(tblMbr)
        dv2.RowFilter = "nombre='" + escogido + "'"
        GridView1.DataSource = dv2.ToTable(False, "codigo", "descripcion", "codigoasig", "hEstimadas", "explotacion", "tipoTarea")
        GridView1.DataBind()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim tblMbr As DataTable
        tblMbr = ds.Tables("TareasYAsigs")
        Dim escogido As String = DropDownList1.SelectedItem.Text
        Dim dv2 As DataView
        dv2 = New DataView(tblMbr)
        dv2.RowFilter = "nombre='" + escogido + "'"
        GridView1.DataSource = dv2.ToTable(False, "codigo", "descripcion", "codigoasig", "hEstimadas", "explotacion", "tipoTarea")
        GridView1.DataBind()
    End Sub
End Class