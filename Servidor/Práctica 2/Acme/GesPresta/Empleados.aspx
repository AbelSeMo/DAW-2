<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="GesPresta.Empleados" %>

<%@ Register src="Cabecera.ascx" tagname="Cabecera" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Cabecera ID="Cabecera1" runat="server" />
        </div>
        <div class="DatosEmpleados">
            <h2>Datos de los Empleados</h2>
        </div>
        <div>
            <label>Código Empleado</label>
            <asp:TextBox ID="txtCodEmp" runat="server"></asp:TextBox> <br />
            <label>NIF</label>
            <asp:TextBox ID="txtNifEmp" runat="server"></asp:TextBox> <br />
            <label>Apellidos y Nombre</label>
            <asp:TextBox ID="txtNomEmp" runat="server"></asp:TextBox> <br />
            <label>Dirección</label>
            <asp:TextBox ID="txtDirEmp" runat="server"></asp:TextBox> <br />
            <label>Ciudad</label>
            <asp:TextBox ID="txtCiuEmp" runat="server"></asp:TextBox> <br />
            <label>Teléfonos</label>
            <asp:TextBox ID="txtTelEmp" runat="server"></asp:TextBox> <br />
            <label>Fecha de Nacimiento</label>
            <asp:TextBox ID="txtFnaEmp" runat="server"></asp:TextBox> <br />
            <label>Fecha de Ingreso</label>
            <asp:TextBox ID="txtFinEmp" runat="server"></asp:TextBox> <br />
            <label>Sexo</label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="H">Hombre</asp:ListItem>
                <asp:ListItem Value="M">Mujer</asp:ListItem>
            </asp:RadioButtonList>&nbsp;<br />
            <label>Departamento</label>
            <asp:DropDownList ID="ddlDepEmp" runat="server"></asp:DropDownList> <br />
            <asp:Button ID="cmdEnviar" runat="Server" Text="Enviar"/>
        </div>
    </form>
</body>
</html>
