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
    public partial class wfVideoLista : System.Web.UI.Page
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
            VideoNegocio obj = new VideoNegocio();
            gvVideoLista.DataSource = obj.ListarVideoUltimos();
            gvVideoLista.DataBind();
        }

        protected void CargarVideo(int pintVideo)
        {
            VideoNegocio obj = new VideoNegocio();
            Video video = obj.ListaVideoxID(pintVideo);
            lblCodigo.Text = video.intVideo.ToString();
            txtTitulo.Text = video.vchTitulo;
            txtLead.Text = video.txtLead;
            txtScript.Text = video.txtScript;
            txtURL.Text = video.vchURL;
            txtFechaPublicacion.Text = video.dtmFechaPublicacion.ToShortDateString();
            if (video.chrEstado == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            txtTitulo.Text = "";
            txtLead.Text = "";
            txtScript.Text = "";
            txtURL.Text = "";
            chkEstado.Checked = true;
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void gvVideoLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intVideoID = int.Parse(gvVideoLista.SelectedRow.Cells[1].Text);
            CargarVideo(intVideoID);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void gvVideoLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVideoLista.PageIndex = e.NewPageIndex;
            CargarDatosGrilla();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            VideoNegocio obj = new VideoNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            string vchTitulo = txtTitulo.Text;
            string vchLead = txtLead.Text;
            string vchScript = txtScript.Text;
            string vchURL = txtURL.Text;
            string chrEstado = "0";
            DateTime dtmFechaPub = DateTime.Parse(txtFechaPublicacion.Text);
            if (chkEstado.Checked)
                chrEstado = "1";
            string vchUsuarioCreacion = this.Page.User.Identity.Name;
            string vchUsuarioModificacion = this.Page.User.Identity.Name;
            Video video = new Video(intCodigo, vchTitulo, vchLead, vchScript, vchURL, dtmFechaPub, chrEstado, vchUsuarioCreacion, vchUsuarioModificacion);
            obj.ActualizarVideo(video);

            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }
    }
}