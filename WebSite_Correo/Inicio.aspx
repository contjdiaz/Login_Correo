<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Mi primera pagina web para envio de formularios</div>
        <p>
            Para:&nbsp;
            <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        </p>
        <p>
            Asunto
            <asp:TextBox ID="txtasunto" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            Mensaje&nbsp; <asp:TextBox ID="txtmensaje" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Enviar" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            Web Login con Autenticacion de base de datos</p>
        <p>
            Correo Electronico
            <asp:TextBox ID="txtcorreo" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        </p>
        <p>
            Contraseña&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcontra" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Olvido su contraseña</asp:LinkButton>
        </p>
        <p>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Registrarse</asp:LinkButton>
        </p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Validar" runat="server" OnClick="Validar_Click" Text="Login" />
    </form>
</body>
</html>
