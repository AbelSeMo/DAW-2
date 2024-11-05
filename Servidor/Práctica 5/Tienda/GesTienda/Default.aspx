<%@ OutputCache Duration="1" VaryByParam="None" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GesTienda.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="~/Estilos/HojaEstilo.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 18px;
        }
    </style>
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
            <div style="margin-top:50px; font-size: x-large; font-weight: bold; text-align: center;">Mantenimiento productos</div> 
                <h3>Iniciar Sesión</h3>
            <div style="display:flex; justify-content:center;">

                <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
                    <LayoutTemplate>
                        <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                            <tr>
                                <td>
                                    <table cellpadding="0">
                                        <tr>
                                            <td align="center" colspan="2" class="auto-style1"></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color:Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="padding-top: 20px">
                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Inicio de sesión" ValidationGroup="Login1" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:Login>
                </div>
            <asp:Label ID="lblMensajes" ForeColor="red" runat="server" style="display:flex; justify-content:center;"></asp:Label> <br />
            <asp:LinkButton runat="server" ID="linkButtonStart" style="margin-top:10px; display:flex; justify-content:center;" PostBackUrl="~/Registrarse.aspx">Registrarse</asp:LinkButton>
            </div>
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
