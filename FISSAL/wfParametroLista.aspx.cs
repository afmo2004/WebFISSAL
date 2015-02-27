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
    public partial class wfParametroLista : System.Web.UI.Page
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
            ParametroNegocio obj = new ParametroNegocio();
            gvParametroLista.DataSource = obj.ListarParametro();
            gvParametroLista.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            txtNombre.Text = "";
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void CargarParametro(int pintCodigo)
        {
            ParametroNegocio obj = new ParametroNegocio();
            Parametro parametro = obj.ListarParametroxID(pintCodigo);
            lblCodigo.Text = parametro.intCodigo.ToString();
            txtNombre.Text = parametro.vchNombre;
        }

        protected void gvParametroLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCodigo = int.Parse(gvParametroLista.SelectedRow.Cells[1].Text);
            CargarParametro(intCodigo);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ParametroNegocio obj = new ParametroNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            string vchNombre = txtNombre.Text;
            Parametro parametro = new Parametro(intCodigo, vchNombre);
            obj.ActualizarParametro(parametro);
            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void CargarDatosGrillaDetalle(int intParametroID)
        {
            ParametroDetalleNegocio obj = new ParametroDetalleNegocio();
            gvParametroDetalleLista.DataSource = obj.ListarParametroDetalle(intParametroID,true);
            gvParametroDetalleLista.DataBind();
        }

        protected void CargarParametroDetalle(int intCodigo)
        {
            ParametroDetalleNegocio obj = new ParametroDetalleNegocio();
            ParametroDetalle detalle = obj.ListarParametroDetallexID(intCodigo);
            lblCodigoDetalle.Text = detalle.intCodigo.ToString();
            txtDescripcionDetalle.Text = detalle.vchDescripcion;
            txtValorDetalle.Text = detalle.vchValor;
            if (detalle.chrEstado == "1")
                chkEstadoDetalle.Checked = true;
            else
                chkEstadoDetalle.Checked = false;
        }

        protected void btnNuevoDetalle_Click(object sender, EventArgs e)
        {
            lblCodigoDetalle.Text = "0";
            txtDescripcionDetalle.Text = "";
            txtValorDetalle.Text = "";
            chkEstadoDetalle.Checked = true;
            mvwPrincipal.SetActiveView(vwEdicionDetalle);
        }

        protected void btnCancelar1_Click(object sender, EventArgs e)
        {
            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void gvParametroDetalleLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intParametroDetalle = int.Parse(gvParametroDetalleLista.SelectedRow.Cells[1].Text);
            CargarParametroDetalle(intParametroDetalle);
            mvwPrincipal.SetActiveView(vwEdicionDetalle);
        }

        protected void gvParametroDetalleLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnActualizarDetalle_Click(object sender, EventArgs e)
        {
            ParametroDetalleNegocio obj = new ParametroDetalleNegocio();
            int intCodigo = Int32.Parse(lblCodigoDetalle.Text);
            int intCodigoParametro = Int32.Parse(txtParametroID.Text);
            string vchDescripcion = txtDescripcionDetalle.Text;
            string vchValor = txtValorDetalle.Text;
            string chrEstadoDetalle = "0";
            if (chkEstadoDetalle.Checked)
                chrEstadoDetalle = "1";
            ParametroDetalle detalle = new ParametroDetalle(intCodigo, intCodigoParametro, vchDescripcion, vchValor, chrEstadoDetalle);
            obj.ActualizarParametroDetalle(detalle);
            CargarDatosGrillaDetalle(intCodigoParametro);
            mvwPrincipal.SetActiveView(vwGrillaDetalle);
        }

        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            int intParametroID = Int32.Parse(txtParametroID.Text);
            CargarDatosGrillaDetalle(intParametroID);
            mvwPrincipal.SetActiveView(vwGrillaDetalle);
        }

        protected void gvParametroLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalle")
            {
                int intCodigoParametro = Int32.Parse(e.CommandArgument.ToString());
                CargarDatosGrillaDetalle(intCodigoParametro);
                txtParametroID.Text = intCodigoParametro.ToString();
                mvwPrincipal.SetActiveView(vwGrillaDetalle);
            }
        }
    }
}