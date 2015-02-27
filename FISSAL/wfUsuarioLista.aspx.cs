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
    public partial class wfUsuarioLista : System.Web.UI.Page
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
                    CargarPerfiles();
                }
            }
        }

        protected void CargarDatosGrilla()
        {
            UsuarioNegocio obj = new UsuarioNegocio();
            gvUsuarioLista.DataSource = obj.ListarUsuarios("");
            gvUsuarioLista.DataBind();
        }

        protected void CargarUsuario(string pstrLogin)
        {
            UsuarioNegocio obj = new UsuarioNegocio();
            Usuario usuario = obj.ListaUsuarioxLogin(pstrLogin);
            lblCodigo.Text = usuario.intCodigoUsuario.ToString();
            txtUsuario.Text = usuario.vchLogin;
            txtPassword.Text = usuario.vchPassword;
            txtNombre.Text = usuario.vchNombreUsuario;
            if (usuario.chrEstado == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;
        }

        protected void CargarPerfiles()
        {
            PerfilNegocio obj = new PerfilNegocio();
            ddlPerfil.DataSource = obj.ListarPerfiles("");
            ddlPerfil.DataValueField = "intCodigoPerfil";
            ddlPerfil.DataTextField = "vchNombrePerfil";
            ddlPerfil.DataBind();
        }

        protected void gvUsuarioLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUsuario(gvUsuarioLista.SelectedRow.Cells[1].Text);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void gvUsuarioLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtNombre.Text = "";
            chkEstado.Checked = true;
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio obj = new UsuarioNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            string vchLogin = txtUsuario.Text;
            string vchPassword = txtPassword.Text;
            string vchNombreUsuario = txtNombre.Text;
            int intPerfil = int.Parse(ddlPerfil.SelectedValue);
            string chrEstado = "0";
            if (chkEstado.Checked)
                chrEstado = "1";
            Usuario usuario = new Usuario(intCodigo,vchLogin,vchPassword,vchNombreUsuario,intPerfil,chrEstado);
            obj.ActualizarUsuario(usuario);

            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }
    }
}