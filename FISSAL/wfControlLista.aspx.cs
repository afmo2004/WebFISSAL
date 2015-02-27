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
    public partial class wfControlLista : System.Web.UI.Page
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
            string strTipoControl = ddlTipoControl.SelectedValue;
            ControlNegocio obj = new ControlNegocio();
            gvControlLista.DataSource = obj.ListarControlxTipo(strTipoControl);
            gvControlLista.DataBind();
        }

        protected void CargarDatosGrillaDetalle(int pintControl)
        {
            ControlDetalleNegocio obj = new ControlDetalleNegocio();
            gvControlDetalleLista.DataSource = obj.ListarxControlID(pintControl);
            gvControlDetalleLista.DataBind();
        }

        protected void CargarControl(int pintCodigoControl)
        {
            ControlNegocio obj = new ControlNegocio();
            FISSAL.Entidad.Control control = obj.ListaControlxID(pintCodigoControl);
            lblCodigo.Text = control.intCodigoControl.ToString();
            txtNombre.Text = control.vchNombreControl;
            ddlTipo.SelectedValue = control.chrTipoControl;
            if (control.chrEstado == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;
        }

        protected void CargarControlDetalle(int pintCodigoDetalle)
        {
            ControlDetalleNegocio obj = new ControlDetalleNegocio();
            ControlDetalle detalle = obj.ListaControlDetallexID(pintCodigoDetalle);
            lblCodigoDetalle.Text = detalle.intControlDetalle.ToString();
            txtOrdenDetalle.Text = detalle.intOrden.ToString();
            txtNombreDetalle.Text = detalle.vchNombre;
            txtTextoDetalle.Text = detalle.vchTexto;
            lblImagenDetalle.Text = detalle.vchImagen;
            lblImagenDetalleHover.Text = detalle.vchImagenHover;
            txtURLDetalle.Text = detalle.vchURL;
            txtScriptDetalle.Text = detalle.txtScript;
            ddlTipoDetalle.SelectedValue = detalle.chrTipo;
            if (detalle.chrEstado == "1")
                chkEstadoDetalle.Checked = true;
            else
                chkEstadoDetalle.Checked = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            txtNombre.Text = "";
            chkEstado.Checked = true;
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ControlNegocio obj = new ControlNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            string vchNombreControl = txtNombre.Text;
            string vchControl = "";
            string chrEstado = "0";
            string chrTipoControl = ddlTipo.SelectedValue;
            switch (chrTipoControl)
            {
                case "1": vchControl = "ucCabeceraHome.ascx"; break;
                case "2": vchControl = "ucBanner.ascx"; break;
            }
            if (chkEstado.Checked)
                chrEstado = "1";
            string vchUsuarioCreacion = this.Page.User.Identity.Name;
            string vchUsuarioModificacion = this.Page.User.Identity.Name;
            FISSAL.Entidad.Control control = new FISSAL.Entidad.Control(intCodigo, vchNombreControl, vchControl, chrTipoControl, chrEstado, vchUsuarioCreacion, vchUsuarioModificacion);
            obj.ActualizarControl(control);

            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void gvControlLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCodigoControl = int.Parse(gvControlLista.SelectedRow.Cells[1].Text);
            CargarControl(intCodigoControl);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void gvControlLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void ddlTipoControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosGrilla();
        }

        protected void gvControlLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalle")
            {
                int intCodigoControl = Int32.Parse(e.CommandArgument.ToString());
                CargarDatosGrillaDetalle(intCodigoControl);
                txtControlID.Text = intCodigoControl.ToString();
                mvwPrincipal.SetActiveView(vwGrillaDetalle);
            }
        }

        protected void btnNuevoDetalle_Click(object sender, EventArgs e)
        {
            lblCodigoDetalle.Text = "0";
            txtOrdenDetalle.Text = "1";
            txtNombreDetalle.Text = "";
            txtTextoDetalle.Text = "";
            lblImagenDetalle.Text = "";
            txtURLDetalle.Text = "";
            txtScriptDetalle.Text = "";
            chkEstadoDetalle.Checked = true;
            mvwPrincipal.SetActiveView(vwEdicionDetalle);
        }

        protected void btnCancelar1_Click(object sender, EventArgs e)
        {
            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void gvControlDetalleLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intControlDetalle = int.Parse(gvControlDetalleLista.SelectedRow.Cells[1].Text);
            CargarControlDetalle(intControlDetalle);
            mvwPrincipal.SetActiveView(vwEdicionDetalle);
        }

        protected void btnActualizarDetalle_Click(object sender, EventArgs e)
        {
            string strPathUpload = AppConfig.PathStringUpload();
            ControlDetalleNegocio obj = new ControlDetalleNegocio();
            int intCodigo = Int32.Parse(txtControlID.Text);
            int intCodigoDetalle = Int32.Parse(lblCodigoDetalle.Text);
            int intOrden = Int32.Parse(txtOrdenDetalle.Text);

            string vchNombreDetalle = txtNombreDetalle.Text;
            string vchTextoDetalle = txtTextoDetalle.Text;
            string chrEstadoDetalle = "0";
            string vchImagenDetalle = lblImagenDetalle.Text;
            if (fuImagenDetalle.HasFile)
            {
                vchImagenDetalle = fuImagenDetalle.FileName;
                fuImagenDetalle.SaveAs(strPathUpload + @"banner/" + vchImagenDetalle);
            }
            string vchImagenDetalleHover = lblImagenDetalleHover.Text;
            if (fuImagenDetalleHover.HasFile)
            {
                vchImagenDetalleHover = fuImagenDetalleHover.FileName;
                fuImagenDetalleHover.SaveAs(strPathUpload + @"banner/" + vchImagenDetalleHover);
            }
            string vchURLDetalle = txtURLDetalle.Text;
            string vchScriptDetalle = txtScriptDetalle.Text;
            string chrTipoDetalle = ddlTipoDetalle.SelectedValue;
            if (chkEstadoDetalle.Checked)
                chrEstadoDetalle = "1";
            string vchUsuarioCreacion = this.Page.User.Identity.Name;
            string vchUsuarioModificacion = this.Page.User.Identity.Name;
            ControlDetalle detalle =
                new ControlDetalle(intCodigoDetalle, intCodigo, intOrden, 
                                vchNombreDetalle, vchTextoDetalle, vchImagenDetalle,
                                vchURLDetalle, vchScriptDetalle, chrTipoDetalle,
                                chrEstadoDetalle, vchUsuarioCreacion, vchUsuarioModificacion,
                                vchImagenDetalleHover);
            obj.ActualizarControlDetalle(detalle);

            int intControlID = Int32.Parse(txtControlID.Text);
            CargarDatosGrillaDetalle(intControlID);
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            int intControlID = Int32.Parse(txtControlID.Text);
            CargarDatosGrillaDetalle(intControlID);
            mvwPrincipal.SetActiveView(vwGrillaDetalle);
        }

        protected void gvControlDetalleLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GrabarOrden")
            {
                int intIndex = Int32.Parse(e.CommandArgument.ToString());
                int intControlDetalle = Int32.Parse(gvControlDetalleLista.Rows[intIndex].Cells[1].Text);
                TextBox txtOrden = (TextBox)gvControlDetalleLista.Rows[intIndex].FindControl("txtOrden");
                int intOrden = int.Parse(txtOrden.Text);
                string vchUsuarioModificacion = this.Page.User.Identity.Name;
                ControlDetalleNegocio obj = new ControlDetalleNegocio();
                obj.ActualizarControlDetalle(intControlDetalle, intOrden, vchUsuarioModificacion);
            }
        }
    }
}