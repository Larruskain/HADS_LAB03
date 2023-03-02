Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Collections.Generic
Public Class AsignaturasDeProfe
    Inherits System.Web.UI.Page
    Public Class Customer
        Public Property CustomerId As Integer
        Public Property Asignaturas As String
        Public Property Country As String
    End Class
    Dim ds As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Using cnn As New SqlConnection("Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            cnn.Open()
            Dim adapter As New SqlDataAdapter("SELECT A.nombre FROM (ProfesorGrupo As PG INNER JOIN GrupoClase AS GC ON  PG.codigoGrupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo WHERE (PG.email='" + Session("email") + "')", cnn)
            adapter.Fill(ds)
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        End Using

    End Sub


End Class