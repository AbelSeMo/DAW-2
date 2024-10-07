<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cabecera.ascx.cs" Inherits="GesPresta.Cabecera" %>
<div class="Buttons-total">
    <asp:LinkButton ID="LinkButton1" runat="server" class="button" PostBackUrl="~/Default.aspx" CausesValidation="false">Inicio</asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" class="button" PostBackUrl="~/Empleados.aspx" CausesValidation="false">Empleados</asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" class="button" PostBackUrl="~/Prestaciones.aspx" CausesValidation="false">Prestaciones</asp:LinkButton>
</div>
<h1>ACME INNOVACIÓN, S. FIG.</h1>
<asp:Label ID="Label1" runat="server" Text="Label" class="label">Gestión de Prestaciones Sociales</asp:Label> <hr />
