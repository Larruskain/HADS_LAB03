<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProfesorTareas.aspx.vb" Inherits="UsuariosRegistradosClienteWeb.ProfesorTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: x-large;
        }
        
        #Select1 {
            text-align: left;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <span class="auto-style2">Profesor</span><br class="auto-style2" />
            <span class="auto-style2">Gestion de Tareas Genericas<br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SGTA2023ConnectionString %>" SelectCommand="SELECT DISTINCT codigoAsig FROM ((ProfesorGrupo As PG INNER JOIN GrupoClase AS GC ON  PG.codigoGrupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON A.codigo=TG.codAsig WHERE (PG.email=@email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" Text="INSERTAR" />
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="SqlDataSource2" AllowSorting="True" AutoGenerateEditButton="True">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="codAsig" HeaderText="codAsig" SortExpression="codAsig" />
                    <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                    <asp:CheckBoxField DataField="explotacion" HeaderText="explotacion" SortExpression="explotacion" />
                    <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SGTA2023ConnectionString %>" SelectCommand="SELECT * FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)" DeleteCommand="DELETE FROM [TareaGenerica] WHERE [codigo] = @codigo" InsertCommand="INSERT INTO [TareaGenerica] ([codigo], [descripcion], [codAsig], [hEstimadas], [explotacion], [tipoTarea]) VALUES (@codigo, @descripcion, @codAsig, @hEstimadas, @explotacion, @tipoTarea)" UpdateCommand="UPDATE [TareaGenerica] SET [descripcion] = @descripcion, [codAsig] = @codAsig, [hEstimadas] = @hEstimadas, [explotacion] = @explotacion, [tipoTarea] = @tipoTarea WHERE [codigo] = @codigo">
                <DeleteParameters>
                    <asp:Parameter Name="codigo" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="codigo" Type="String" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="codAsig" Type="String" />
                    <asp:Parameter Name="hEstimadas" Type="Int32" />
                    <asp:Parameter Name="explotacion" Type="Boolean" />
                    <asp:Parameter Name="tipoTarea" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="codAsig" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="codAsig" Type="String" />
                    <asp:Parameter Name="hEstimadas" Type="Int32" />
                    <asp:Parameter Name="explotacion" Type="Boolean" />
                    <asp:Parameter Name="tipoTarea" Type="String" />
                    <asp:Parameter Name="codigo" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor.aspx">Atras</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/login.aspx">CerrarSesion</asp:HyperLink>
            <br />
            </span></div>
        <p style="margin-left: 1200px; text-align: left;">
            &nbsp;</p>
    </form>
</body>
</html>
