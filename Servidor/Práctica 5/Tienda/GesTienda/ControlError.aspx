<%@ OutputCache Duration="1" VaryByParam="None" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlError.aspx.cs" Inherits="GesTienda.ControlError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="~/Estilos/HojaEstilo.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <h1 class="h1Error">Aplicación Web GesTienda</h1>
            <h3 class="h3Error">Error en tiempo de ejecución</h3>
        <div class="MostrarError">
            Error ASP.NET: <br />
            <asp:Label ID="lblErrorASP" runat="server" Text="[lblErrorASP]" ForeColor="Red"></asp:Label> <br />
            Error ADO.NET: <br />
            <asp:Label ID="lblErrorADO" runat="server" Text="[lblErrorADO]" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
