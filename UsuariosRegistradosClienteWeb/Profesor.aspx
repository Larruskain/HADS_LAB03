<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="UsuariosRegistradosClienteWeb.Profesor" %>

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
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AsignaturasDeProfe.aspx">Asignaturas</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server">Tareas</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server">Grupos</asp:HyperLink>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
         <div class="content">

        </div>
        <p>
    </form>
</body>
</html>
