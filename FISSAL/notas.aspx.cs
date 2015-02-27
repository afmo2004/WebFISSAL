using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL
{
    public partial class notas : System.Web.UI.Page
    {
        private PagedDataSource pds = new PagedDataSource();
        public int CurrentPage
        {
            get
            {
                if (this.ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
                }
            }

            set { this.ViewState["CurrentPage"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Noticias | FISSAL";
            CargarNotasPortada();
            CargarNotasDetalle();
        }

        protected void CargarNotasPortada()
        {
            NoticiaNegocio noticiaNegocio = new NoticiaNegocio();
            NoticiaFotografiaNegocio noticiaFotoNegocio = new NoticiaFotografiaNegocio();
            FotografiaNegocio fotoNegocio = new FotografiaNegocio();
            List<Noticia> lista = noticiaNegocio.ListarNoticiaPortadaSeccion();
            int intContador = 1;
            foreach (Noticia nota in lista)
            {
                if (intContador == 1)
                {
                    litImagen1.Text = ImagenFoto(nota.intCodigo, 331,nota.vchURL);
                    //litTitulo1.Text = "<h1><a href='" + AppUtils.URLLimpia2(nota.intCodigo, nota.vchTitulo, "noticia") + "'>" + nota.vchTitulo.Trim() + "</a></h1>";
                    litTitulo1.Text = "<h1><a href='noticia.aspx?id=" + nota.intCodigo.ToString() + "'>" + nota.vchTitulo.Trim() + "</a></h1>";
                    litLead1.Text = "<div class='lead'>" + nota.txtLead + "</div>";
                }
                else
                {
                    litImagen2.Text = ImagenFoto(nota.intCodigo, 331, nota.vchURL);
                    //litTitulo2.Text = "<h1><a href='" + AppUtils.URLLimpia2(nota.intCodigo, nota.vchTitulo, "noticia") + "'>" + nota.vchTitulo.Trim() + "</a></h1>";
                    litTitulo2.Text = "<h1><a href='noticia.aspx?id=" + nota.intCodigo.ToString() + "'>" + nota.vchTitulo.Trim() + "</a></h1>";
                    litLead2.Text = "<div class='lead'>" + nota.txtLead + "</div>";
                }
                intContador++;
            }
        }

        protected void CargarNotasDetalle()
        {
            NoticiaNegocio noticiaNegocio = new NoticiaNegocio();
            NoticiaFotografiaNegocio noticiaFotoNegocio = new NoticiaFotografiaNegocio();
            FotografiaNegocio fotoNegocio = new FotografiaNegocio();
            List<Noticia> lista = noticiaNegocio.ListarNoticiaSeccionActivo();

            pds.DataSource = lista;
            pds.AllowPaging = true;
            pds.PageSize = 5;
            pds.CurrentPageIndex = CurrentPage;

            rpNoticia.DataSource = pds;
            rpNoticia.DataBind();

            Paginado();
            
        }

        protected string ImagenFoto(int intNoticia, int intAncho, string vchURL)
        {
            string strFoto = "";
            //LISTA DE FOTOS
            NoticiaFotografiaNegocio noticiaFotoNegocio = new NoticiaFotografiaNegocio();
            FotografiaNegocio fotoNegocio = new FotografiaNegocio();
            List<NoticiaFotografia> listaFoto = noticiaFotoNegocio.ListarxNoticia(intNoticia);
            foreach (NoticiaFotografia notafoto in listaFoto)
            {
                int intFotografia = notafoto.intFotografia;
                Fotografia fotografia = fotoNegocio.ListarFotografiaxID(intFotografia);
                if (vchURL == String.Empty)
                    strFoto = "<img src='fotos/" + fotografia.vchImagen + "' width='" + intAncho.ToString() + "' />";
                else
                    strFoto = "<a href='" + vchURL + "' target='_blank'><img src='fotos/" + fotografia.vchImagen + "' width='" + intAncho.ToString() + "' /></a>";
            }
            return strFoto;
        }

        private void Paginado()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PageIndex");
            dt.Columns.Add("PageText");
            for (int i = 0; i <= pds.PageCount - 1; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i;
                dr[1] = " " + (i + 1).ToString();
                dt.Rows.Add(dr);
            }
            dlPaging.DataSource = dt;
            dlPaging.DataBind();
            dlPaging.SelectedIndex = CurrentPage;

        }

        protected void rpNoticia_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
            {
                Noticia nota = (Noticia)e.Item.DataItem;
                NoticiaFotografiaNegocio noticiaFotoNegocio = new NoticiaFotografiaNegocio();
                FotografiaNegocio fotoNegocio = new FotografiaNegocio();
                Literal litTitulo = (Literal)e.Item.FindControl("litTitulo");
                //litTitulo.Text = "<h6><a href='" + AppUtils.URLLimpia2(nota.intCodigo, nota.vchTitulo, "noticia") + "'>" + nota.vchTitulo.Trim() + "</a></h6>";
                litTitulo.Text = "<h6><a href='noticia.aspx?id=" + nota.intCodigo.ToString() + "'>" + nota.vchTitulo.Trim() + "</a></h6>";
                Literal litLead = (Literal)e.Item.FindControl("litLead");
                litLead.Text = "<div class='lead'>" + nota.txtLead.Trim() + "</div>";
                Literal litImagen = (Literal)e.Item.FindControl("litImagen");
                //LISTA DE FOTOS
                List<NoticiaFotografia> listaFoto = noticiaFotoNegocio.ListarxNoticia(nota.intCodigo);
                foreach (NoticiaFotografia notafoto in listaFoto)
                {
                    int intFotografia = notafoto.intFotografia;
                    Fotografia fotografia = fotoNegocio.ListarFotografiaxID(intFotografia);
                    if (nota.vchURL == String.Empty)
                        litImagen.Text = "<img src='fotos/" + fotografia.vchImagen + "' width='175' />";
                    else
                        litImagen.Text = "<a href='" + nota.vchURL + "' target='_blank'><img src='fotos/" + fotografia.vchImagen + "' width='175' /></a>";
                }
            }
        }

        protected void dlPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("lnkbtnPaging"))
            {
                CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
                CargarNotasDetalle();
            }
        }
    }
}