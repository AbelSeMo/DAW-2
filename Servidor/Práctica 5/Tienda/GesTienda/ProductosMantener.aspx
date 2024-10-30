<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdm.Master" AutoEventWireup="true" CodeBehind="ProductosMantener.aspx.cs" Inherits="GesTienda.ProductosMantener" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InfoContenido" runat="server">
    <div class="contenidotitulo">Mantenimiento productos</div>
    <div class="contenidoPagina">
        <div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [IdProducto], [DesPro], [PrePro] FROM [PRODUCTO]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [UNIDAD]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TIPO]"></asp:SqlDataSource>
    <asp:GridView ID="grdProductos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdProducto" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdProductos_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" ReadOnly="True" SortExpression="IdProducto" />
            <asp:BoundField DataField="DesPro" HeaderText="Descripción" SortExpression="DesPro" />
            <asp:BoundField DataField="PrePro" HeaderText="Precio" SortExpression="PrePro" DataFormatString="{0:n2}">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NextPreviousFirstLast" NextPageText="Siguiente" PreviousPageText="Anterior" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
        </div>
        <div class="mostrarGrid">
            <div class="contenidoMostrarGrid">
    <asp:Label ID="lblIdProducto" Text="Id. Producto" runat="server"></asp:Label>
    <asp:TextBox ID="txtIdProducto" runat="server" Enabled="False" ></asp:TextBox>
            </div>
            <div class="contenidoMostrarGrid">
    <asp:Label ID="lblDesPro" Text="Descripción" runat="server"></asp:Label>
    <asp:TextBox ID="txtDesPro" runat="server" Enabled="False" ></asp:TextBox>
            </div>
            <div class="contenidoMostrarGrid">
    <asp:Label ID="lblPrePro" Text="Precio" runat="server"></asp:Label>
    <asp:TextBox ID="txtPrePro" runat="server" Enabled="False" Text="0"></asp:TextBox>
            </div>
            <div class="contenidoMostrarGrid">
    <asp:Label ID="lblIdUnidad" Text="Unidad" runat="server"></asp:Label>
    <asp:DropDownList ID="ddlIdUnidad" runat="server" Enabled="False" DataSourceID="SqlDataSource2" DataTextField="IdUnidad" DataValueField="IdUnidad">
    </asp:DropDownList>
            </div>
            <div class="contenidoMostrarGrid">
    <asp:Label ID="lblIdTipo" Text="Tipo Producto" runat="server"></asp:Label>
    <asp:DropDownList ID="ddlIdTipo" runat="server" Enabled="False" DataSourceID="SqlDataSource3" DataTextField="DesTip" DataValueField="IdTipo">
    </asp:DropDownList>
            </div>
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Visible="True" OnClick="btnNuevo_Click"/>
    <asp:Button ID="btnEditar" runat="server" Text="Editar" Visible="false" OnClick="btnEditar_Click"/>
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Visible="false" OnClick="btnEliminar_Click"/>
    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" Visible="false" OnClick="btnInsertar_Click"/>
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="false" OnClick="btnModificar_Click"/>
    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Visible="false" OnClick="btnBorrar_Click"/>
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelar_Click"/>
    <br />
      </div>
    </div>
    <div>
        <asp:Label ID="lblResultado" runat="server"></asp:Label>
    </div> 
    <br /> 
    <br /> 
    <asp:Label ID="lblMensajes" ForeColor="red" runat="server"></asp:Label> 
</asp:Content>
