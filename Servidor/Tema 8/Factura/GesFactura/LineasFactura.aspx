<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineasFactura.aspx.cs" Inherits="GesFactura.LineasFactura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center;">Uso de Servicio Web - Cálculos factura de un artículo</h1>
            <div style="display:flex; flex-direction:column; text-align:center;">
                <div style="width:400px">
                    <span style="display:flex; justify-content:flex-start">Cantidad</span>
                    <asp:TextBox runat="server" ID="txtCantidad" style="display:flex; justify-content:flex-end"></asp:TextBox>
                </div>
                <div style="width:400px">
                    <span style="display:flex; justify-content:flex-start">Precio</span>
                    <asp:TextBox runat="server"  ID="txtPrecio" style="display:flex; justify-content:flex-end"></asp:TextBox>
                </div>
                <div style="width:400px">
                    <span style="display:flex; justify-content:flex-start">Descuento (%)</span>
                    <asp:TextBox runat="server" ID="txtDescuento" style="display:flex; justify-content:flex-end"></asp:TextBox>
                </div>
                <div style="width:400px">
                    <span style="display:flex; justify-content:flex-start">Tipo de IVA (%)</span>
                    <asp:TextBox runat="server" ID="txtTipoIVA" style="display:flex; justify-content:flex-end"></asp:TextBox>
                </div>
            </div>
                <div style="display:flex; justify-content:center;">
                <asp:Button runat="server" ID="btnEnviar" Text="Enviar" OnClick="btnEnviar_Click"/>
                </div>
                <span style="display: flex;justify-content: center;">Resultados de los cálculos:</span>
            <div style="display:flex; justify-content:center; margin:10px;">
                <div style="display: flex; flex-direction:column;">
                    <span>Bruto</span>
                    <asp:Label runat="server" ID="lblBruto"></asp:Label>
                </div>
                <div style="display: flex; flex-direction:column;">
                    <span>Descuento</span>
                    <asp:Label runat="server" ID="lblDescuento"></asp:Label>
                </div>
                <div style="display: flex; flex-direction:column;">
                    <span>Base Imponible</span>
                    <asp:Label runat="server" ID="lblBaseImponible"></asp:Label>
                </div>
                <div style="display: flex; flex-direction:column;">
                    <span>IVA</span>
                    <asp:Label runat="server" ID="lblIva"></asp:Label>
                </div>
                <div style="display: flex; flex-direction:column;">
                    <span>Total</span>
                    <asp:Label runat="server" ID="lblTotal"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
