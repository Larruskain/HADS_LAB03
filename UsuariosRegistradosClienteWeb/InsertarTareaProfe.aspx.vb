Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting

Public Class InsertarTareaProfe
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Label1.Text = ""
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cnn As New SqlConnection("Server=tcp:hads1.database.windows.net,1433;Initial Catalog=SGTA2023;Persist Security Info=False;User ID=elarruscain003@ikasle.ehu.eus@hads1;Password=enekojoanes_HADS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        Dim strCommand As String = "insert into TareaGenerica values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & DropDownList3.SelectedValue & "'," & TextBox3.Text & ",1,'" & DropDownList2.SelectedValue & "')"
        Dim command As SqlCommand = New SqlCommand(strCommand, cnn)
        command.CommandType = CommandType.Text
        cnn.Open()
        Dim a As Integer = command.ExecuteNonQuery()

        Label1.Text = a
    End Sub

End Class