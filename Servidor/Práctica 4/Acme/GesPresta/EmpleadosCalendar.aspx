<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpleadosCalendar.aspx.cs" Inherits="GesPresta.EmpleadosCalendar" %>

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
                <asp:RequiredFieldValidator ID="rqdTxtCodEmp" runat="server" ErrorMessage="El código de empleado es requerido" ForeColor="Red" ControlToValidate="txtCodEmp"></asp:RequiredFieldValidator>
             </div>
            <div class="Posicion">
                <label>NIF</label>
                <asp:TextBox ID="txtNifEmp" runat="server"></asp:TextBox> <br />
                <asp:RequiredFieldValidator ID="rqdTxtNifEmp" runat="server" ErrorMessage="El NIF es requerido" ForeColor="Red" ControlToValidate="txtNifEmp"></asp:RequiredFieldValidator>
            </div>
            <div class="Posicion">
                <label>Apellidos y Nombre</label>
                <asp:TextBox ID="txtNomEmp" runat="server"></asp:TextBox> <br />
                <asp:RequiredFieldValidator ID="rqdTxtNomEmp" runat="server" ErrorMessage="Los apellidos y el nombre son requeridos" ForeColor="Red" ControlToValidate="txtNomEmp"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="rqdTxtTelEmp" runat="server" ErrorMessage="El teléfono es requerido" ForeColor="Red" ControlToValidate="txtTelEmp"></asp:RequiredFieldValidator>
            </div>
            <div class="Posicion">
                <label>Fecha de Nacimiento</label>
                <asp:TextBox ID="txtFnaEmp" runat="server"></asp:TextBox> <br />
                <asp:RequiredFieldValidator ID="rqdTxtFnaEmp" runat="server" ErrorMessage="La fecha de nacimiento es requerida" ForeColor="Red" ControlToValidate="txtFnaEmp"></asp:RequiredFieldValidator>
            </div>
            <div class="Posicion">
                <label>Fecha de Ingreso</label>
                <asp:TextBox ID="txtFinEmp" runat="server"></asp:TextBox> <br />
                <asp:RequiredFieldValidator ID="rqdTxtFinEmp" runat="server" ErrorMessage="La fecha de ingreso es requerida" ForeColor="Red" ControlToValidate="txtFinEmp"></asp:RequiredFieldValidator>
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
        </div>
            <div class="todoCalendario">
                <div class="calendario">
                <label>Fecha de nacimiento</label> 
                <asp:TextBox ID="txtFecNacEmp" runat="server" AutoPostBack="True" OnTextChanged="txtFecNacEmp_TextChanged"></asp:TextBox> <br />
                <asp:Calendar ID="CalendarNacimiento" runat="server" CssClass="asp-calendario" OnSelectionChanged="CalendarNacimiento_SelectionChanged">
                    <DayHeaderStyle BackColor="#CCCCCC" />
                    <OtherMonthDayStyle BackColor="#999999" />
                    <SelectedDayStyle BackColor="#99CC00" />
                    <TitleStyle BackColor="Gray" />
                    <TodayDayStyle BackColor="#FF9933" />
                    <WeekendDayStyle BackColor="#FFFF99" />
                    </asp:Calendar>
                <br />
                </div>
                <div class="calendario">
                <label>Fecha de Ingreso</label>
                <asp:TextBox ID="txtFecIngEmp" runat="server" AutoPostBack="True" OnTextChanged="txtFecIngEmp_TextChanged"></asp:TextBox> <br />
                <asp:Calendar ID="CalendarIngreso" runat="server" CssClass="asp-calendario" OnSelectionChanged="CalendarIngreso_SelectionChanged">
                    <DayHeaderStyle BackColor="#CCCCCC" />
                    <OtherMonthDayStyle BackColor="#999999" />
                    <SelectedDayStyle BackColor="#99CC00" />
                    <TitleStyle BackColor="Gray" />
                    <TodayDayStyle BackColor="#FF9933" />
                    <WeekendDayStyle BackColor="#FFFF99" />
                    </asp:Calendar>
                </div>
            </div>
            <div class="Antiguedad">
                <div>
                    <label>Años de antiguedad:</label>
                    <asp:TextBox ID="txtAnyos" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Meses de antiguedad:</label>
                    <asp:TextBox ID="txtMeses" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Días de antiguedad:</label>
                    <asp:TextBox ID="txtDias" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="Datos">
                <asp:Label ID="lblError1" runat="server" cssClass="Error"></asp:Label>
                <asp:Label ID="lblError2" runat="server" cssClass="Error"></asp:Label>
                <asp:Label ID="lblError3" runat="server" cssClass="Error"></asp:Label>
            </div>
            <asp:Label ID="lblValores1" cssClass="Datos" style="background-color: #66FFFF; width: 60%; text-align: center; margin-top:20px" runat="server"></asp:Label>
            <asp:Button ID="cmdEnviar" runat="Server" Text="Enviar" cssClass="Datos" OnClick="cmdEnviar_Click"/> <br />
    </form>
</body>
</html>
