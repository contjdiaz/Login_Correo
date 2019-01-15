<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recuperar.aspx.cs" Inherits="Recuperar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Se enviara nuevamernte contraseña al correo</p>
        <p>
            correo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcorreo" runat="server"></asp:TextBox>
        </p>
        <p>
            contraseña&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtclave" runat="server"></asp:TextBox>
        </p>
        <p>
            confirmar contraseña&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtvalidaclave" runat="server"></asp:TextBox>
            <asp:Button ID="Enviar" runat="server" OnClick="Enviar_Click" Text="Enviar" />
        </p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
