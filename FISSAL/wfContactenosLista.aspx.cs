using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;
using System.Web.Security;

namespace FISSAL
{
    public partial class wfContactenosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarDatosGrilla();
                }
            }
        }
        protected void CargarDatosGrilla()
        {
            ContactoNegocio obj = new ContactoNegocio();
            gvContactoLista.DataSource = obj.ListarContactenos();
            gvContactoLista.DataBind();
        }

        protected void gvContactoLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContactoLista.PageIndex = e.NewPageIndex;
            CargarDatosGrilla();
        }

        protected void gvContactoLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvContactoLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Contacto fila = (Contacto)e.Row.DataItem;
                Label lblFecha = (Label)e.Row.FindControl("lblFecha");
                lblFecha.Text = fila.dtmFechaCreacion.ToShortDateString();
            }
        }
    }
}