<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="GesPresta.Empleados" %>

<%@ Register src="Cabecera.ascx" tagname="Cabecera" tagprefix="uc1" %>

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
            <uc1:Cabecera ID="Cabecera1" runat="server" OnLoad="Cabecera1_Load" />
        </div>
        <div>
            <h2>Datos de los Empleados</h2>
        </div>
        <div class="Datos">
            <div class="Posicion">
                <label>Código Empleado</label>
                <asp:TextBox ID="txtCodEmp" runat="server"></asp:TextBox> <br />
             </div>
            <div class="Posicion">
                <label>NIF</label>
                <asp:TextBox ID="txtNifEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="Posicion">
                <label>Apellidos y Nombre</label>
                <asp:TextBox ID="txtNomEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="Posicion">
                <label>Dirección</label>
                <asp:TextBox ID="txtDirEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="Posicion">
                <label>Ciudad</label>
                <asp:TextBox ID="txtCiuEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="Posicion">
                <label>Teléfonos</label>
                <asp:TextBox ID="txtTelEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="Posicion">
                <label>Fecha de Nacimiento</label>
                <asp:TextBox ID="txtFnaEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="Posicion">
                <label>Fecha de Ingreso</label>
                <asp:TextBox ID="txtFinEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="Posicion">
                <label>Sexo</label>
                     <div class="radio-opciones">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="H">Hombre</asp:ListItem>
                        <asp:ListItem Value="M">Mujer</asp:ListItem>
                    </asp:RadioButtonList>&nbsp;&nbsp;<br />
                     </div>
            </div>
            <div class="Posicion">
                <label>Departamento</label>
                <asp:DropDownList ID="ddlDepEmp" runat="server">
                    <asp:ListItem Selected="True">Investigación</asp:ListItem>
                    <asp:ListItem>Desarrollo</asp:ListItem>
                    <asp:ListItem>Innovación</asp:ListItem>
                    <asp:ListItem>Administración</asp:ListItem>
                </asp:DropDownList> <br />
            </div>
            <asp:Button ID="cmdEnviar" runat="Server" Text="Enviar"/>
        </div>
    </form>
</body>
</html>
