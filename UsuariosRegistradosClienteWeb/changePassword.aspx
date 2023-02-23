<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="changePassword.aspx.vb" Inherits="UsuariosRegistradosClienteWeb.changePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Inserta usuario:<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Isertar vieja contraseña:<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Nueva contraseña:</div>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="#CC0000"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Cambiar" />
    </form>
</body>
</html>
