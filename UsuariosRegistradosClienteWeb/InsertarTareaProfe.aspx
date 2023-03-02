<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTareaProfe.aspx.vb" Inherits="UsuariosRegistradosClienteWeb.InsertarTareaProfe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style2 {
            font-size: x-large;
        }
        
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Insertar TAREA:<br />
            Codigo:<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Descripcion:<br />
            <asp:TextBox ID="TextBox2" runat="server" Width="1013px"></asp:TextBox>
            <br />
            Asignatura:<br />
            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource4" DataTextField="codigoAsig" DataValueField="codigoAsig">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SGTA2023ConnectionString %>" SelectCommand="SELECT DISTINCT codigoAsig FROM ((ProfesorGrupo As PG INNER JOIN GrupoClase AS GC ON  PG.codigoGrupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON A.codigo=TG.codAsig WHERE (PG.email=@email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <span class="auto-style2">
            <br />
            Horas estimadas:<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            TipoTarea:<br />
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="tipoTarea" DataValueField="tipoTarea">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SGTA2023ConnectionString %>" SelectCommand="SELECT DISTINCT TG.tipoTarea FROM ((ProfesorGrupo As PG INNER JOIN GrupoClase AS GC ON  PG.codigoGrupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON A.codigo=TG.codAsig WHERE (PG.email=@email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            </span>
            <asp:Button ID="Button1" runat="server" Text="Insertar" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <span class="auto-style2">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor.aspx">Atras</asp:HyperLink>
            </span>
        </div>
    </form>
</body>
</html>
