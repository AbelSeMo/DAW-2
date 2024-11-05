<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="GesTienda.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="~/Estilos/HojaEstilo.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
<br />
<div id="cabecera">
   <div id="cabecera1">
      <br />
      comerciodaw.com &nbsp;
   </div>
   <div id="cabecera2">
       <br />
       &nbsp;&nbsp;TIENDA ONLINE - SHOPPING DAW<br />
       <br />
   </div>
        </div>
            <div style="margin-top:50px; font-size: x-large; font-weight: bold; text-align: center;">GesTienda</div>
            <h3>Registro de usuario</h3>
        </div>
        <div class="baseRegistro">
            <div class="posicionRegistro">
                <label>Correo Electrónico</label>
                <asp:TextBox ID="txtCorCli" runat="server"></asp:TextBox>
            </div>
            <div class="posicionRegistro">
                <label>Contraseña</label>
                <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="posicionRegistro">
                <label>Introduzca nuevamente la contraseña</label>
                <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="posicionRegistro">
                <label>NIF/NIE/CIF</label>
                <asp:TextBox ID="txtIdCliente" runat="server"></asp:TextBox>
            </div>
            <div class="posicionRegistro">
                <label>Nombre/Razón Social</label>
                <asp:TextBox ID="txtNomCli" runat="server"></asp:TextBox>
            </div>
            <div class="posicionRegistro">
                <label>Dirección</label>
                <asp:TextBox ID="txtDirCli" runat="server"></asp:TextBox>
            </div>
            <div class="posicionRegistro">
                <label>Población</label>
                <asp:TextBox ID="txtPobCli" runat="server"></asp:TextBox>
            </div>
            <div class="posicionRegistro">
                <label>Código Postal</label>
                <asp:TextBox ID="txtCpoCli" runat="server"></asp:TextBox>
            </div>
            <div class="posicionRegistro">
                <label>Teléfono</label>
                <asp:TextBox ID="txtTelCli" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" style="width:100px;" OnClick="btnInsertar_Click"/>
            <asp:LinkButton runat="server" ID="linkButtonStart" style="margin-top:10px;" PostBackUrl="~/Default.aspx">Ir a inicio</asp:LinkButton>
        </div>
        <asp:Label ID="lblMensajes" ForeColor="red" runat="server" style="display:flex; justify-content:center;"></asp:Label>
    <div id="pie">
    <br />
    <br />
    © Desarrollo de Aplicaciones Web interactivas con Acceso a Datos
    <br />
    IES Mare Nostrum (Alicante)
</div>
    </form>
</body>
</html>
