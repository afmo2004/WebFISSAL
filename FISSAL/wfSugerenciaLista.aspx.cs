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
    public partial class wfSugerenciaLista : System.Web.UI.Page
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
                    CargarCombos();
                    CargarDatosGrilla();
                }
            }
        }
        protected void CargarCombos()
        {
            ParametroDetalleNegocio obj = new ParametroDetalleNegocio();
            ddlTipo.DataSource = obj.ListarParametroDetalle(3, true);
            ddlTipo.DataTextField = "vchDescripcion";
            ddlTipo.DataValueField = "vchValor";
            ddlTipo.DataBind();

            ddlTipoDocumento.DataSource = obj.ListarParametroDetalle(4, true);
            ddlTipoDocumento.DataTextField = "vchDescripcion";
            ddlTipoDocumento.DataValueField = "vchValor";
            ddlTipoDocumento.DataBind();

            ddlTipoDiagnostico.DataSource = obj.ListarParametroDetalle(5, true);
            ddlTipoDiagnostico.DataTextField = "vchDescripcion";
            ddlTipoDiagnostico.DataValueField = "vchValor";
            ddlTipoDiagnostico.DataBind();
        }
        protected void CargarDatosGrilla()
        {
            SugerenciaNegocio obj = new SugerenciaNegocio();
            gvSugerenciaLista.DataSource = obj.ListarSugerencias();
            gvSugerenciaLista.DataBind();
        }

        protected void CargarSugerencia(Int32 intCodigo)
        {
            SugerenciaNegocio obj = new SugerenciaNegocio();
            Sugerencia data = obj.ListarSugerenciaxID(intCodigo);
            lblCodigo.Text = data.intCodigo.ToString();
            ddlTipo.SelectedValue = data.intTipo.ToString();
            ddlTipoDocumento.SelectedValue = data.chrTipoDocumento;
            txtNumeroDocumento.Text = data.vchNumeroDocumento;
            txtApPaterno.Text = data.vchApellidoPaterno;
            txtApMaterno.Text = data.vchApellidoMaterno;
            txtNombres.Text = data.vchNombres;
            ddlAsegurado.SelectedValue = data.chrAsegurado;
            txtJustificacion.Text = data.txtEspecificacion;
            txtPaciente.Text = data.vchNombreAsegurado;
            ddlTipoDiagnostico.SelectedValue = data.chrTipoDiagnostico;
            txtTelefono.Text = data.vchTelefono;
            txtEmail.Text = data.vchCorreo;
            txtUbigeo.Text = data.vchUbigeo;
            txtDireccion.Text = data.vchDireccion;
            txtMensaje.Text = data.txtDescripcion;
            txtEstablecimiento.Text = data.vchEstablecimiento;
            txtFechaOcurrencia.Text = data.dtmFechaOcurrencia.ToShortDateString();
        }

        protected void gvSugerenciaLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 intCodigo = Int32.Parse(gvSugerenciaLista.SelectedRow.Cells[1].Text);
            CargarSugerencia(intCodigo);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void gvSugerenciaLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSugerenciaLista.PageIndex = e.NewPageIndex;
            CargarDatosGrilla();
        }

        protected void gvSugerenciaLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Sugerencia fila = (Sugerencia)e.Row.DataItem;
                Label lblFecha = (Label)e.Row.FindControl("lblFecha");
                lblFecha.Text = fila.dtmFechaOcurrencia.ToShortDateString();
            }
        }
    }
}