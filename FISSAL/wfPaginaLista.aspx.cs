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
    public partial class wfPaginaLista : System.Web.UI.Page
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
            PaginaNegocio obj = new PaginaNegocio();
            gvPaginaLista.DataSource = obj.ListarPaginas();
            gvPaginaLista.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            txtNombrePagina.Text = "";
            txtPagina.Text = "";
            txtLead.Content = "";
            txtContenido.Content = "";
            chkEstado.Checked = true;
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void gvPaginaLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCodigo = int.Parse(gvPaginaLista.SelectedRow.Cells[1].Text);
            CargarPagina(intCodigo);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void CargarPagina(int pintCodigo)
        {
            PaginaNegocio obj = new PaginaNegocio();
            Pagina pagina = obj.ListarPaginaxID(pintCodigo);
            lblCodigo.Text = pagina.intPagina.ToString();
            txtNombrePagina.Text = pagina.vchNombrePagina;
            txtPagina.Text = pagina.vchPagina;
            txtLead.Content = pagina.txtLead;
            txtContenido.Content = pagina.txtContenido;
            if (pagina.chrEstado == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;
        }

        protected void gvPaginaLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaginaLista.PageIndex = e.NewPageIndex;
            CargarDatosGrilla();
        }

        protected void gvPaginaLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            PaginaNegocio paginaNegocio = new PaginaNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            string vchNombrePagina = txtNombrePagina.Text;
            string vchPagina = txtPagina.Text;
            string vchLead = txtLead.Content;
            string vchContenido = txtContenido.Content;
            string chrEstado = "0";
            if (chkEstado.Checked)
                chrEstado = "1";
            string vchUsuarioCreacion = this.Page.User.Identity.Name;
            string vchUsuarioModificacion = this.Page.User.Identity.Name;
            Pagina pagina = new Pagina(intCodigo, vchNombrePagina, vchPagina, vchLead, vchContenido, chrEstado, vchUsuarioCreacion, vchUsuarioModificacion);
            paginaNegocio.ActualizarPagina(pagina);
            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }
    }
}