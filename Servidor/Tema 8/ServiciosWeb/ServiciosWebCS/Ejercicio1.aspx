<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="ServiciosWebCS.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="./css/consumirWeb.css" rel="stylesheet" type="text/css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
        <div class="titulo">
            <h2>CONSUMIR UN SERVICIO WEB YA EXISTENTE</h2>
            <h1>Titulaciones Oficiales en la Universidad de Alicante</h1>
        </div>
        <div class="formulario">
        <div class="curso">
            <asp:Label ID="Label1" runat="server" Text="Label">Curso académico (formato aaaa-aa)</asp:Label>
            <asp:TextBox ID="txtCurso" runat="server"></asp:TextBox>
            <asp:Button ID="btnObtenerInformacion" runat="server" Text="Obtener Información" OnClick="btnObtenerInformacion_Click" />
        </div>
            <asp:Label ID="lblResultado" runat="server"></asp:Label>

            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>

        </div>
        </div>
    </form>
</body>
</html>
