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
    public partial class wfNormasLegalesLista : System.Web.UI.Page
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
                    CargarAnio();
                    CargarDatosGrilla();
                }
            }
        }

        protected void CargarDatosGrilla()
        {
            NormasLegalesNegocio obj = new NormasLegalesNegocio();
            gvNormasLegalesLista.DataSource = obj.ListarNormas();
            gvNormasLegalesLista.DataBind();
        }
        protected void CargarAnio()
        {
            ParametroDetalleNegocio obj = new ParametroDetalleNegocio();
            ddlAnio.DataSource = obj.ListarParametroDetalle(1, false);
            ddlAnio.DataTextField = "vchDescripcion";
            ddlAnio.DataValueField = "vchValor";
            ddlAnio.DataBind();
            //ddlAnio.SelectedValue = DateTime.Today.Year.ToString();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            lblArchivo.Text = "";
            chkEstado.Checked = true;
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void CargarNormaLegal(int intNormaID)
        {
            NormasLegalesNegocio obj = new NormasLegalesNegocio();
            NormasLegales normaLegal = obj.ListarNormasxID(intNormaID);
            lblCodigo.Text = normaLegal.intCodigo.ToString();
            ddlAnio.SelectedValue = normaLegal.intAnio.ToString();
            txtTitulo.Text = normaLegal.vchTitulo;
            txtDescripcion.Text = normaLegal.vchDescripcion;
            ddlTipo.SelectedValue = normaLegal.chrTipo;
            lblArchivo.Text = normaLegal.vchArchivo;
            if (normaLegal.chrEstado == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;
        }

        protected void gvNormasLegalesLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intNormaID = int.Parse(gvNormasLegalesLista.SelectedRow.Cells[1].Text);
            CargarNormaLegal(intNormaID);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void gvNormasLegalesLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNormasLegalesLista.PageIndex = e.NewPageIndex;
            CargarDatosGrilla();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string strPathUpload = AppConfig.PathStringUpload();
            NormasLegalesNegocio obj = new NormasLegalesNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            int intAnio = Int32.Parse(ddlAnio.SelectedValue);
            string vchTitulo = txtTitulo.Text;
            string vchDescripcion = txtDescripcion.Text;
            string vchArchivo = lblArchivo.Text;
            if (fuArchivo.HasFile)
            {
                if (lblArchivo.Text == String.Empty)
                    vchArchivo = fuArchivo.FileName;
                fuArchivo.SaveAs(strPathUpload + @"normaslegales/" + vchArchivo);
            }
            string chrEstado = "0";
            if (chkEstado.Checked)
                chrEstado = "1";
            string chrTipo = ddlTipo.SelectedValue.ToString();
            string vchUsuarioCreacion = this.Page.User.Identity.Name;
            string vchUsuarioModificacion = this.Page.User.Identity.Name;
            NormasLegales normaLegal = new NormasLegales(intCodigo, intAnio, vchTitulo, vchDescripcion, vchArchivo, chrEstado, chrTipo, vchUsuarioCreacion, vchUsuarioModificacion);
            obj.ActualizarNormaLegal(normaLegal);

            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }
    }
}