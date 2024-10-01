using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class EmpleadosCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodEmp.Focus();
            lblValores1.Visible = false;
        }

        protected void Cabecera1_Load(object sender, EventArgs e)
        {

        }

        protected void cmdEnviar_Click(object sender, EventArgs e)
        {
            lblValores1.Visible = true;
            lblValores1.Text = "VALORES DEL FORMULARIO" +
                "<br/> Código Empleado: " + txtCodEmp.Text +
                "<br/> NIF: " + txtNifEmp.Text +
                "<br/> Apellidos y Nombre: " + txtNomEmp.Text +
                "<br/> Dirección: " + txtDirEmp.Text +
                "<br/> Ciudad: " + txtCiuEmp.Text +
                "<br/> Teléfonos: " + txtTelEmp.Text +
                "<br/> Fecha de Nacimiento: " + txtFnaEmp.Text +
                "<br/> Fecha de Incorporación: " + txtFinEmp.Text +
                "<br/> Sexo: " + RadioButtonList1.SelectedItem.Value +
                "<br/> Departamento: " + ddlDepEmp.Text;
        }

        protected void CalendarNacimiento_SelectionChanged(object sender, EventArgs e)
        {
            gestionErrores();
            txtFecNacEmp.Text = CalendarNacimiento.SelectedDate.ToString();
        }

        protected void CalendarIngreso_SelectionChanged(object sender, EventArgs e)
        {
            gestionErrores();
            antiguedadCalendario();
            txtFecIngEmp.Text = CalendarIngreso.SelectedDate.ToString();
        }
        DateTime dtHoy = System.DateTime.Now;
        void gestionErrores()
        {
            if(CalendarIngreso.SelectedDate < CalendarNacimiento.SelectedDate)
            {
                lblError1.Text = "La fecha de ingreso no puede ser inferior a la fecha de nacimiento";
                CalendarIngreso.SelectedDate = dtHoy;
            }

            if(CalendarIngreso.SelectedDate > dtHoy)
            {
                lblError2.Text = "La fecha de ingreso de la compañia no puede ser mayor a la actual";
                CalendarIngreso.SelectedDate = dtHoy;
            }

            if (CalendarNacimiento.SelectedDate > dtHoy)
            {
                lblError3.Text = "La fecha de nacimiento no puede ser mayor a la actual";
                CalendarNacimiento.SelectedDate = dtHoy;
            }
        }

        void antiguedadCalendario()
        {
            TimeSpan diferencia = dtHoy - CalendarIngreso.SelectedDate;
            DateTime fechamin = new DateTime(1, 1, 1);
            txtAnyos.Text = ((fechamin + diferencia).Year - 1).ToString();
            txtMeses.Text = ((fechamin + diferencia).Month - 1).ToString();
            txtDias.Text = ((fechamin + diferencia).Day).ToString();
        }

    }
}