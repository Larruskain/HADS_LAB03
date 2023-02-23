<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="recoverPassword.aspx.vb" Inherits="UsuariosRegistradosClienteWeb.recoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Inserta tu email:<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Buscar" />
            <br />
            Pregunta:<br />
            <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            Inserta la respuesta:<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" style="margin-bottom: 0px" Text="¿?" />
            <br />
            La contraseña es:<br />
            <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/login.aspx">Login</asp:HyperLink>
        </div>
    </form>
</body>
</html>
