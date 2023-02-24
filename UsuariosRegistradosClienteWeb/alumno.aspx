<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="alumno.aspx.vb" Inherits="UsuariosRegistradosClienteWeb.menua" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .alumno {
            background-color:antiquewhite;
            padding-left : 10px;
            widhth: 200px;
            height: 100%;
            position: fixed;
            top: 0;
            left: 0;

        }
        .content {
            background-color:khaki;
            margin-left: 200px;
            height: 746px;
            align-content: center;
            text-align: center;
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="alumno">
            <br />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TareaGenericasAlumnos.aspx">Tareas Genéricas</asp:HyperLink>
            <br />
            <br />
             <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TareasPropiasAlumnos.aspx">Tareas Propias</asp:HyperLink>
            <br />
            <br />
             <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/GruposAlumnos.aspx">Grupos</asp:HyperLink>
            <br />
            <br />
            <br />
            <br />
        </div>
        <div class="content">
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Gestión Web de Tareas-Dedicación"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Alumnos"></asp:Label>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
