<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MPPrestaciones.aspx.cs" Inherits="GesPresta.MPPrestaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <asp:Button ID="cmdEnviar" runat="Server" Text="Enviar"/>
</div>
</asp:Content>
