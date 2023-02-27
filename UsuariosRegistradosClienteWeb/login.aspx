<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="UsuariosRegistradosClienteWeb.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 880px" class="auto-style1">
            <asp:Button ID="Button2" runat="server" style="margin-left: 0px" Text="Atrás" />
        </div>
        LOGIN. Introduce los siguientos datos para logearte<br />
        <br />
        Introduzca su usuario:<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Introduzca la contraseña:<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Entrar" style="height: 35px" />
        <asp:Label ID="Label1" runat="server" ForeColor="#CC0000"></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Erregistratu.aspx">Registrarse</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/recoverPassword.aspx">Recuperar contraseña</asp:HyperLink>
        <br />
    </form>
</body>
</html>
