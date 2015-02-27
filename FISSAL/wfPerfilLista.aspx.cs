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
    public partial class wfPerfilLista : System.Web.UI.Page
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
            PerfilNegocio obj = new PerfilNegocio();
            gvPerfilLista.DataSource = obj.ListarPerfiles("");
            gvPerfilLista.DataBind();
        }

        protected void CargarPerfil(int pintPerfil)
        {
            PerfilNegocio obj = new PerfilNegocio();
            Perfil perfil = obj.ListaPerfilxID(pintPerfil);
            lblCodigo.Text = perfil.intCodigoPerfil.ToString();
            txtPerfil.Text = perfil.vchNombrePerfil;
            if (perfil.chrEstado == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;
        }

        protected void gvPerfilLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intPerfilID = int.Parse(gvPerfilLista.SelectedRow.Cells[1].Text);
            CargarPerfil(intPerfilID);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void gvPerfilLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            txtPerfil.Text = "";
            chkEstado.Checked = true;
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            PerfilNegocio obj = new PerfilNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            string vchNombrePerfil = txtPerfil.Text;
            string chrEstado = "0";
            if (chkEstado.Checked)
                chrEstado = "1";
            Perfil perfil = new Perfil(intCodigo, vchNombrePerfil, chrEstado);
            obj.ActualizarPerfil(perfil);

            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }
    }
}