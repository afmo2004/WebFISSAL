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
    public partial class wfNoticiaLista : System.Web.UI.Page
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
            NoticiaNegocio obj = new NoticiaNegocio();
            gvNoticiaLista.DataSource = obj.ListarNoticias();
            gvNoticiaLista.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            rdpFechaPublicacion.SelectedDate = DateTime.Now;
            txtVolada.Text = "";
            txtTitulo.Text = "";
            txtBajada.Text = "";
            txtLead.Content = "";
            txtContenido.Content = "";
            chkEstado.Checked = true;
            btnEliminarFoto.Visible = false;
            hdfFotoCodigo.Value = "0";
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void CargarNota(int pintCodigo)
        {
            NoticiaNegocio obj = new NoticiaNegocio();
            NoticiaFotografiaNegocio notaFotoNegocio = new NoticiaFotografiaNegocio();
            FotografiaNegocio objFoto = new FotografiaNegocio();
            Noticia noticia = obj.ListarNoticiaxID(pintCodigo);
            lblCodigo.Text = noticia.intCodigo.ToString();
            rdpFechaPublicacion.SelectedDate = noticia.dtmFechaPublicacion;
            txtVolada.Text = noticia.vchVolada;
            txtTitulo.Text = noticia.vchTitulo;
            txtBajada.Text = noticia.vchBajada;
            txtLead.Content = noticia.txtLead;
            txtContenido.Content = noticia.txtContenido;
            if (noticia.chrEstado == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;
            List<NoticiaFotografia> notaFotoLista = notaFotoNegocio.ListarxNoticia(noticia.intCodigo);
            if (notaFotoLista.Count == 0)
                btnEliminarFoto.Visible = false;
            else
                btnEliminarFoto.Visible = true;
            litImagen.Text = "";
            foreach (NoticiaFotografia notaFoto in notaFotoLista)
            {
                Fotografia foto = objFoto.ListarFotografiaxID(notaFoto.intFotografia);
                litImagen.Text = "<img src='fotos/" + foto.vchImagen + "' height='100' />";
            }
            txtURL.Text = noticia.vchURL;
        }

        protected void gvNoticiaLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCodigo = int.Parse(gvNoticiaLista.SelectedRow.Cells[1].Text);
            CargarNota(intCodigo);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void gvNoticiaLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNoticiaLista.PageIndex = e.NewPageIndex;
            CargarDatosGrilla();
        }

        protected void gvNoticiaLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                NoticiaFotografiaNegocio notaFotoNegocio = new NoticiaFotografiaNegocio();
                FotografiaNegocio objFoto = new FotografiaNegocio();
                Noticia nota = (Noticia)e.Row.DataItem;
                Label lblFechaPublicacion = (Label)e.Row.FindControl("lblFechaPublicacion");
                lblFechaPublicacion.Text = nota.dtmFechaPublicacion.ToShortDateString();
                Literal litImagen = (Literal)e.Row.FindControl("litImagen");
                List<NoticiaFotografia> notaFotoLista = notaFotoNegocio.ListarxNoticia(nota.intCodigo);
                foreach (NoticiaFotografia notaFoto in notaFotoLista)
                {
                    Fotografia foto = objFoto.ListarFotografiaxID(notaFoto.intFotografia);
                    litImagen.Text = "<img src='fotos/" + foto.vchImagen + "' height='50' />";
                    litFotografiaId.Text = notaFoto.intFotografia.ToString();
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            NoticiaNegocio negocioNoticia = new NoticiaNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            DateTime dtmFechaPub = (DateTime)rdpFechaPublicacion.SelectedDate;
            string vchVolada = txtVolada.Text;
            string vchTitulo = txtTitulo.Text;
            string vchBajada = txtBajada.Text;
            string vchLead = txtLead.Content;
            string vchContenido = txtContenido.Content;
            string chrEstado = "0";
            if (chkEstado.Checked)
                chrEstado = "1";
            string vchUsuarioCreacion = this.Page.User.Identity.Name;
            string vchUsuarioModificacion = this.Page.User.Identity.Name;
            string vchURL = txtURL.Text;
            Noticia noticia = new Noticia(intCodigo, dtmFechaPub, vchVolada, vchTitulo, vchBajada, "", "", vchLead, vchContenido, chrEstado, vchUsuarioCreacion, vchUsuarioModificacion, vchURL);
            if (intCodigo == 0)
            {
                intCodigo = negocioNoticia.InsertarNoticia(noticia);
            }
            else
            {
                negocioNoticia.ActualizarNoticia(noticia);
            }
            //ENLAZAR FOTO CON NOTO
            if (!hdfFotoCodigo.Value.Equals("0"))
            {
                int intFotoId = int.Parse(hdfFotoCodigo.Value);
                NoticiaFotografiaNegocio objNegocio = new NoticiaFotografiaNegocio();
                NoticiaFotografia notaFoto = new NoticiaFotografia(intCodigo, intFotoId, vchUsuarioCreacion);
                objNegocio.InsertarNoticiaFotografia(notaFoto);
            }
            //CargarNota(intNoticiaId);
            CargarNota(intCodigo);
            //mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void CargarDatosFoto()
        {
            FotografiaNegocio obj = new FotografiaNegocio();
            List<Fotografia> lista = obj.ListarFotografias();
            dlFoto.DataSource = lista;
            dlFoto.DataBind();
        }

        protected void dlFoto_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Fotografia foto = (Fotografia)e.Item.DataItem;
                ImageButton imgEditar = (ImageButton)e.Item.FindControl("imgEditar");
                imgEditar.ImageUrl = "~/fotos/" + foto.vchImagen.Trim();
                imgEditar.CommandArgument = foto.intCodigo.ToString();
            }
        }

        protected void dlFoto_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "enlazar")
            {
                FotografiaNegocio objFoto = new FotografiaNegocio();
                NoticiaFotografiaNegocio objNegocio = new NoticiaFotografiaNegocio();
                int intFotoId = int.Parse(e.CommandArgument.ToString());
                int intNoticiaId = int.Parse(lblCodigo.Text);
                hdfFotoCodigo.Value = intFotoId.ToString();

                Fotografia foto = objFoto.ListarFotografiaxID(intFotoId);
                litImagen.Text = "<img src='fotos/" + foto.vchImagen + "' height='100' />";

                //string vchUsuarioCreacion = this.Page.User.Identity.Name;
                //NoticiaFotografia notaFoto = new NoticiaFotografia(intNoticiaId, intFotoId, vchUsuarioCreacion);
                //objNegocio.InsertarNoticiaFotografia(notaFoto);
                //CargarNota(intNoticiaId);
            }
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void btnFoto_Click(object sender, EventArgs e)
        {
            CargarDatosFoto();
            mvwPrincipal.SetActiveView(vwFoto);
        }

        protected void btnCancelar2_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void btnEliminarFoto_Click(object sender, EventArgs e)
        {
            int intNoticiaId = int.Parse(lblCodigo.Text);
            int intFotografiaId = int.Parse(litFotografiaId.Text);
            NoticiaFotografiaNegocio objNegocio = new NoticiaFotografiaNegocio();
            objNegocio.EliminarNoticiaFotografia(intNoticiaId, intFotografiaId);
            CargarNota(intNoticiaId);
        }

        protected void btnNuevoDetalle_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            rdpFechaPublicacion.SelectedDate = DateTime.Now;
            txtVolada.Text = "";
            txtTitulo.Text = "";
            txtBajada.Text = "";
            txtLead.Content = "";
            txtContenido.Content = "";
            chkEstado.Checked = true;
            litImagen.Text = "";
            hdfFotoCodigo.Value = "0";
            btnEliminarFoto.Visible = false;
        }
    }
}