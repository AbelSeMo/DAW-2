<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones1Respuesta.aspx.cs" Inherits="GesPresta.Prestaciones1Respuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align: center">Valores recibidos desde el formulario Prestaciones1.aspx</h1>
        </div>
        <div style="display: flex; flex-direction: column; justify-content: center; align-items: center">
            <asp:Label ID="lblValores" style="background-color: #C0FFFF; width: 70%; text-align: center" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
