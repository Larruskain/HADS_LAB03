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
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="itemSelected">
            </asp:DropDownList>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            </span></div>
        <p style="margin-left: 1200px">
            CerrarSesion</p>
        <p style="margin-left: 1200px; text-align: left;">
            &nbsp;</p>
    </form>
</body>
</html>
