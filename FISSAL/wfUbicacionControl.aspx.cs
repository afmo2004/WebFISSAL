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
    public partial class wfUbicacionControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSeccion();
                FiltrarDatos();
                CargarControles();
            }
        }
        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
        protected void rblUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        protected void CargarSeccion()
        {
            SeccionNegocio obj = new SeccionNegocio();
            ddlSeccion.DataSource = obj.ListarSeccion();
            ddlSeccion.DataValueField = "intSeccion";
            ddlSeccion.DataTextField = "vchNombreSeccion";
            ddlSeccion.DataBind();
        }

        protected void CargarControles()
        {
            ControlNegocio obj = new ControlNegocio();
            ddlControl.Items.Clear();
            foreach (FISSAL.Entidad.Control control in obj.ListarControlxTipo("2"))
            {
                ddlControl.Items.Add(new ListItem(control.vchNombreControl, control.intCodigoControl.ToString())); 
            }
            foreach (FISSAL.Entidad.Control control in obj.ListarControlxTipo("3"))
            {
                ddlControl.Items.Add(new ListItem(control.vchNombreControl, control.intCodigoControl.ToString()));
            }
            foreach (FISSAL.Entidad.Control control in obj.ListarControlxTipo("5"))
            {
                ddlControl.Items.Add(new ListItem(control.vchNombreControl, control.intCodigoControl.ToString()));
            }
            foreach (FISSAL.Entidad.Control control in obj.ListarControlxTipo("6"))
            {
                ddlControl.Items.Add(new ListItem(control.vchNombreControl, control.intCodigoControl.ToString()));
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        protected void FiltrarDatos()
        {
            SeccionControlNegocio obj = new SeccionControlNegocio();
            int intSeccionId = int.Parse(ddlSeccion.SelectedValue.ToString());
            string strUbicacion = rblUbicacion.SelectedValue.ToString();

            gvControlSeccion.DataSource = obj.ListarControlesxSeccion(intSeccionId, strUbicacion);
            gvControlSeccion.DataBind();
        }
        protected void gvControlSeccion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SeccionControl data = (SeccionControl)e.Row.DataItem;
                ControlNegocio obj = new ControlNegocio();
                FISSAL.Entidad.Control control = obj.ListaControlxID(data.intCodigoControl);
                Label lblNombre = (Label)e.Row.FindControl("lblNombre");
                lblNombre.Text = control.vchNombreControl;

            }
        }

        protected void gvControlSeccion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GrabarOrden")
            {
                SeccionControlNegocio obj = new SeccionControlNegocio();
                SeccionControl seccionControl = new SeccionControl();
                seccionControl.intSeccion = int.Parse(ddlSeccion.SelectedValue.ToString());
                seccionControl.chrUbicacion = rblUbicacion.SelectedValue.ToString();
                int intFila = int.Parse(e.CommandArgument.ToString());
                TextBox txtOrden = (TextBox)gvControlSeccion.Rows[intFila].FindControl("txtOrden");
                int intCodigoControl = int.Parse(gvControlSeccion.DataKeys[intFila]["intCodigoControl"].ToString());
                seccionControl.intCodigoControl = intCodigoControl;
                seccionControl.intOrden = int.Parse(txtOrden.Text);
                obj.ActualizarControlSeccionOrden(seccionControl);
            }
            if (e.CommandName == "Eliminar")
            {
                SeccionControlNegocio obj = new SeccionControlNegocio();
                SeccionControl seccionControl = new SeccionControl();
                seccionControl.intSeccion = int.Parse(ddlSeccion.SelectedValue.ToString());
                int intFila = int.Parse(e.CommandArgument.ToString());
                int intCodigoControl = int.Parse(gvControlSeccion.DataKeys[intFila]["intCodigoControl"].ToString());
                seccionControl.intCodigoControl = intCodigoControl;
                obj.EliminarControlSeccion(seccionControl);
                //FILTRAR DATOS
                FiltrarDatos();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            SeccionControlNegocio obj = new SeccionControlNegocio();
            SeccionControl seccionControl = new SeccionControl();
            seccionControl.intSeccion = int.Parse(ddlSeccion.SelectedValue.ToString());
            lblError.Text = "";
            if (txtOrden.Text == String.Empty)
            {
                lblError.Text = "Ingrese orden";
            }
            else
            {
                seccionControl.intCodigoControl = int.Parse(ddlControl.SelectedValue.ToString());
                seccionControl.intOrden = int.Parse(txtOrden.Text);
                seccionControl.chrUbicacion = rblUbicacion.SelectedValue.ToString();
                obj.ActualizarControlSeccion(seccionControl);
                //FILTRAR DATOS
                FiltrarDatos();
            }
        }

        
        
    }
}