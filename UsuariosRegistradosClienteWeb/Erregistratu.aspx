<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Erregistratu.aspx.vb" Inherits="UsuariosRegistradosClienteWeb.Erregistratu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .nuevoEstilo1 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo2 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo3 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo4 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo5 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo6 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo7 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo8 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo9 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo10 {
            background-color: #C0C0C0;
        }
        .nuevoEstilo11 {
            background-color: #C0C0C0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="margin-left: 40px">
&nbsp;&nbsp; INTRODUCE LOS SIGUIENTES DATOS PARA REGISTRARSE<br />
                <br />
                Email:<br />
                <asp:TextBox ID="TextBox1" runat="server" CssClass="nuevoEstilo1" Width="294px"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" ForeColor="#CC0000"></asp:Label>
                <br />
                Nombre:<br />
                <asp:TextBox ID="TextBox2" runat="server" CssClass="nuevoEstilo1" Width="294px"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" ForeColor="#CC0000"></asp:Label>
                <br />
                Apellido:<br />
                <asp:TextBox ID="TextBox3" runat="server" CssClass="nuevoEstilo1" Width="294px"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" ForeColor="#CC0000"></asp:Label>
                <br />
                Tipo:<br />
                <asp:TextBox ID="TextBox4" runat="server" CssClass="nuevoEstilo4" Width="294px"></asp:TextBox>
                <br />
                Contraseña:<br />
                <asp:TextBox ID="TextBox5" runat="server" CssClass="nuevoEstilo1" Width="294px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="REGISTRARSE" Width="187px" />
                <asp:Label ID="Label5" runat="server" ForeColor="#CC0000"></asp:Label>
                <br />
            </p>
        </div>
        <p style="margin-left: 40px">
            <asp:Label ID="Label2" runat="server" ForeColor="Blue"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            <asp:HyperLink ID="HyperLink1" runat="server" Visible="False">[HyperLink1]</asp:HyperLink>
        </p>
    </form>
</body>
</html>

