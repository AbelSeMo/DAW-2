﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestaciones2.aspx.cs" Inherits="GesPresta.Prestaciones2" %>

<%@ Register Src="~/Cabecera.ascx" TagPrefix="uc1" TagName="Cabecera" %>


<%@ Register src="prestacionesBuscar.ascx" tagname="prestacionesBuscar" tagprefix="uc2" %>


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
                    <h2>Datos de las prestaciones</h2>
                </div>
                <div class="Datos"> 
                    <div class="Posicion">
                        <label>Código Prestación</label>
                        <asp:TextBox ID="txtCodPre" runat="server"></asp:TextBox> <br />
                    </div>
                    <div class="asp-validator">
                        <asp:RegularExpressionValidator ID="regTxtCodPre" runat="server" ErrorMessage="El formato de los datos introducidos debe ser:  3 dígitos, un guión, 3 dígitos, un guion y, 3 dígitos" ControlToValidate="txtCodPre" ForeColor="Green" ValidationExpression="\d{3}-\d{3}-\d{3}"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rqdTxtCodPre" runat="server" ErrorMessage="El código de prestación es requerido" ForeColor="Red" ControlToValidate="txtCodPre"></asp:RequiredFieldValidator>
                    </div>
                    <div class="Posicion">
                        <label>Descripción</label>
                        <asp:TextBox ID="txtDesPre" runat="server"></asp:TextBox> <br />
                    </div>
                    <div class="Posicion">
                        <label>Importe Fijo</label>
                        <asp:TextBox ID="txtImpPre" runat="server"></asp:TextBox> 
                    </div>
                    <div class="asp-validator">
                        <asp:RangeValidator ID="rngTxtImpPre" runat="server" ErrorMessage="El valor introducido debe situarse entre 0,00 y 500" ControlToValidate="txtImpPre" MinimumValue="0,00" MaximumValue="500,00" ForeColor="Red" Type="Double" CssClass="asp-validator"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="rqdTxtImpPre" runat="server" ErrorMessage="El importe fijo es requerido" ForeColor="Red" ControlToValidate="txtImpPre" CssClass="asp-validator"></asp:RequiredFieldValidator>
                    </div>
                    <div class="Posicion">
                        <label>Porcentaje del Importe</label>
                        <asp:TextBox ID="txtPorPre" runat="server"></asp:TextBox> 
                    </div>
                    <div class="asp-validator">
                        <asp:RangeValidator ID="rngTxtPorPre" runat="server" ErrorMessage="El valor introducido debe estar comprendido entre el 0,00% y 15%" ControlToValidate="txtPorPre" MinimumValue="0,00" MaximumValue="15,00" ForeColor="Red" Type="Double" CssClass="asp-validator"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="rqdTxtPorPre" runat="server" ErrorMessage="El porcentaje del importe es requerido" ForeColor="Red" ControlToValidate="txtPorPre" CssClass="asp-validator"></asp:RequiredFieldValidator>
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
                    <asp:Button ID="cmdEnviar" runat="Server" Text="Enviar"/>
                    <div class="prestacionesBuscar">
                        <uc2:prestacionesBuscar ID="prestacionesBuscar1" runat="server" Visible="false"/>
                    <div class="validationSummary">
                        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CausesValidation="false" Visible="false" OnClick="btnSeleccionar_Click"/>
                        <asp:Button ID="btnVerPrestaciones" runat="server" Text="Ver prestaciones" CausesValidation="false" OnClick="btnVerPrestaciones_Click"/>
                     </div>
                    </div>
                </div>
         </div>
    </form>
</body>
</html>
