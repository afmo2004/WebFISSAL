using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL
{
    public partial class noticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                string strCodigo = Request.QueryString["id"].ToString();
                int intCodigo = 0;
                try
                {
                    intCodigo = Int32.Parse(strCodigo);
                    CargarNota(intCodigo);
                }
                catch (Exception err)
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        protected void CargarNota(int intNoticiaID)
        {
            NoticiaNegocio noticiaNegocio = new NoticiaNegocio();
            NoticiaFotografiaNegocio noticiaFotoNegocio = new NoticiaFotografiaNegocio();
            FotografiaNegocio fotoNegocio = new FotografiaNegocio();

            Noticia nota = noticiaNegocio.ListarNoticiaxID(intNoticiaID);
            litVolada.Text = nota.vchVolada.Trim();
            litTitulo.Text = "<h1>" + nota.vchTitulo + "</h1>";
            litBajada.Text = nota.vchBajada.Trim();
            string vchURL = nota.vchURL;
            //LISTA DE FOTOS
            List<NoticiaFotografia> listaFoto = noticiaFotoNegocio.ListarxNoticia(intNoticiaID);
            foreach (NoticiaFotografia notafoto in listaFoto)
            {
                int intFotografia = notafoto.intFotografia;
                Fotografia fotografia = fotoNegocio.ListarFotografiaxID(intFotografia);
                if (vchURL == String.Empty)
                    litImagen.Text = "<p><img src='fotos/" + fotografia.vchImagen + "' width='686' /></p>";
                else
                    litImagen.Text = "<p><a href='" + vchURL +"' target='_blank'><img src='fotos/" + fotografia.vchImagen + "' width='686' /></a></p>";
                HtmlLink link = new HtmlLink();
                link.Href = AppConfig.VirtualPathString() + "fotos/" + fotografia.vchImagen;
                link.Attributes.Add("rel", "image_src");
                Page.Header.Controls.Add(link);
            }
            //CONTENIDO
            litContenido.Text = nota.txtLead + nota.txtContenido;
            litFechaPublicacion.Text = "Publicado: " + nota.dtmFechaPublicacion.ToShortDateString();

            //TAGS
            Page.Title = nota.vchTitulo.Trim() + " | FISSAL";

            HtmlMeta htmlClave = new HtmlMeta();
            htmlClave.Name = "keywords";
            htmlClave.Content = nota.vchTitulo.Trim();
            Page.Header.Controls.Add(htmlClave);

            HtmlMeta htmlDescripcion = new HtmlMeta();
            htmlDescripcion.Name = "description";
            htmlDescripcion.Content = nota.txtLead.Trim();
            Page.Header.Controls.Add(htmlDescripcion);

        }
    }
}