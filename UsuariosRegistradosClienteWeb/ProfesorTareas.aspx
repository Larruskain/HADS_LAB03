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
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nombre">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SGTA2023ConnectionString %>" SelectCommand="SELECT DISTINCT nombre FROM ((ProfesorGrupo As PG INNER JOIN GrupoClase AS GC ON  PG.codigoGrupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON A.codigo=TG.codAsig WHERE (PG.email=@email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp
                    <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                    <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                    <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SGTA2023ConnectionString %>" SelectCommand="SELECT A.codigo,GC.descripcion,TG.hEstimadas,TG.Explotacion,TG.tipoTarea  FROM ((ProfesorGrupo As PG INNER JOIN GrupoClase AS GC ON  PG.codigoGrupo = GC.codigo) INNER JOIN Asignatura AS A ON GC.codigoAsig=A.codigo) INNER JOIN TareaGenerica AS TG ON A.codigo=TG.codAsig WHERE (PG.email=@email AND A.nombre=@nombre)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                    <asp:ControlParameter ControlID="DropDownList1" Name="nombre" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            </span></div>
        <p style="margin-left: 1200px">
            CerrarSesion</p>
        <p style="margin-left: 1200px; text-align: left;">
            &nbsp;</p>
    </form>
</body>
</html>
