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
                <asp:TextBox ID="txtCodEmp" runat="server"></asp:TextBox>
             </div>
             <div class="asp-validator">
                <asp:RequiredFieldValidator ID="rqdTxtCodEmp" runat="server" ErrorMessage="El Código Empleado es requerido" ForeColor="Red" ControlToValidate="txtCodEmp" Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regTxtCodEmp" runat="server" ErrorMessage="El formato de los datos introducidos debe ser: una letra y 5 dígitos" ControlToValidate="txtCodEmp" ForeColor="Green" ValidationExpression="\w\d{5}"></asp:RegularExpressionValidator>
             </div>
            <div class="Posicion">
                <label>NIF</label>
                <asp:TextBox ID="txtNifEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="asp-validator">
                <asp:RequiredFieldValidator ID="rqdTxtNifEmp" runat="server" ErrorMessage="El NIF es requerido" ForeColor="Red" ControlToValidate="txtNifEmp" Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regTxtNifEmp" runat="server" ErrorMessage="El formato de los datos introducidos debe ser: 8 dígitos, un guion y una letra" ControlToValidate="txtNifEmp" ForeColor="Green" ValidationExpression="\d{8}-\w"></asp:RegularExpressionValidator>
            </div>
            <div class="Posicion">
                <label>Apellidos y Nombre</label>
                <asp:TextBox ID="txtNomEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="asp-validator">
                <asp:RequiredFieldValidator ID="rqdTxtNomEmp" runat="server" ErrorMessage="Los apellidos y el nombre son requeridos" ForeColor="Red" ControlToValidate="txtNomEmp" Text="*"></asp:RequiredFieldValidator>
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
            <div class="asp-validator">
                <asp:RequiredFieldValidator ID="rqdTxtTelEmp" runat="server" ErrorMessage="El teléfono es requerido" ForeColor="Red" ControlToValidate="txtTelEmp" Text="*"></asp:RequiredFieldValidator>
            </div>
            <div class="Posicion">
                <label>Fecha de Nacimiento</label>
                <asp:TextBox ID="txtFnaEmp" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="asp-validator">
                <asp:RequiredFieldValidator ID="rqdTxtFnaEmp" runat="server" ErrorMessage="La fecha de nacimiento es requerida" ForeColor="Red" ControlToValidate="txtFnaEmp" Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regTxtFnaEmp" runat="server" ErrorMessage="El formato de los datos introducidos debe ser: Formato de fecha dd/mm/aaaa" ControlToValidate="txtFnaEmp" ForeColor="Green" ValidationExpression="\d\d\/\d\d\/\d\d\d\d"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="cmpTxtFnaEmp" runat="server" ErrorMessage="La Fecha de Ingreso del Empleado debe ser mayor que la Fecha de Nacimiento" ControlToValidate="txtFnaEmp" ControlToCompare="txtFinEmp" Type="Date" Operator="LessThan"></asp:CompareValidator>
            </div>
            <div class="Posicion">
                <label>Fecha de Ingreso</label>
                <asp:TextBox ID="txtFinEmp" runat="server"></asp:TextBox> <br />
            </div>
            <div class="asp-validator">
                <asp:RequiredFieldValidator ID="rqdTxtFinEmp" runat="server" ErrorMessage="La fecha de ingreso es requerida" ForeColor="Red" ControlToValidate="txtFinEmp" Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regTxtFinEmp" runat="server" ErrorMessage="El formato de los datos introducidos debe ser: Formato de fecha dd/mm/aaaa" ControlToValidate="txtFinEmp" ForeColor="Green" ValidationExpression="\d\d\/\d\d\/\d\d\d\d"></asp:RegularExpressionValidator>
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
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="Red" CssClass="validationSummary"/>
        </div>
    </form>
</body>
</html>
