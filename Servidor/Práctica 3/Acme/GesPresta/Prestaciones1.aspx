<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones1.aspx.cs" Inherits="GesPresta.Prestaciones1" %>

<%@ Register Src="~/Cabecera.ascx" TagPrefix="uc1" TagName="Cabecera" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="EstilosCabecera.css" rel="stylesheet" type="text/css" />
<link href="Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <uc1:Cabecera runat="server" ID="Cabecera" />
            </div>
            <div>
                <div>
                    <h2>Datos de las prestaciones</h2>
                </div>
                <div class="Datos">
                    <div class="Posicion">
                        <label>Código Prestación</label>
                        <asp:TextBox ID="txtCodPre" runat="server"></asp:TextBox> <br />
                    </div>
                    <div class="Posicion">
                        <label>Descripción</label>
                        <asp:TextBox ID="txtDesPre" runat="server"></asp:TextBox> <br />
                    </div>
                    <div class="Posicion">
                        <label>Importe Fijo</label>
                        <asp:TextBox ID="txtImpPre" runat="server"></asp:TextBox> <br />
                    </div>
                    <div class="Posicion">
                        <label>Porcentaje del Importe</label>
                        <asp:TextBox ID="txtPorPre" runat="server"></asp:TextBox> <br />
                    </div>
                    <div class="Posicion">
                        <label>Tipo de Prestación</label>
                        <asp:DropDownList ID="ddlTipPre" runat="server">
                        <asp:ListItem>Dentaria</asp:ListItem>
                        <asp:ListItem>Familiar</asp:ListItem>
                        <asp:ListItem Selected="True">Ocular</asp:ListItem>
                        <asp:ListItem>Otras</asp:ListItem>
                        </asp:DropDownList> <br />
                    </div>
                    <asp:Button ID="cmdEnviar" runat="Server" Text="Enviar" PostBackUrl="~/Prestaciones1Respuesta.aspx"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
