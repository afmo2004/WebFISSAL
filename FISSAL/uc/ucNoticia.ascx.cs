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

namespace FISSAL.uc
{
    public partial class ucNoticia : System.Web.UI.UserControl
    {
        private string _estiloCabeceraControl;

        public string estiloCabeceraControl
        {
            get { return _estiloCabeceraControl; }
            set { _estiloCabeceraControl = value; }
        }

        private string _estiloFooterControl;

        public string estiloFooterControl
        {
            get { return _estiloFooterControl; }
            set { _estiloFooterControl = value; }
        }


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
            CargarNoticia();
        }

        protected void CargarNoticia()
        {
            NoticiaNegocio noticiaNegocio = new NoticiaNegocio();
            NoticiaFotografiaNegocio noticiaFotoNegocio = new NoticiaFotografiaNegocio();
            FotografiaNegocio fotoNegocio = new FotografiaNegocio();
            List<Noticia> lista = noticiaNegocio.ListarNoticiaHome();

            pds.DataSource = lista;
            pds.AllowPaging = true;
            pds.PageSize = 1;
            pds.CurrentPageIndex = CurrentPage;

            rpNoticia.DataSource = pds;
            rpNoticia.DataBind();

            Paginado();
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
                Literal litLead = (Literal)e.Item.FindControl("litLead");
                Literal litImagen = (Literal)e.Item.FindControl("litImagen");
                litTitulo.Text = "<h1><a href='noticia.aspx?id=" + nota.intCodigo.ToString() + "'>" + nota.vchTitulo.Trim() + "</a></h1>";
                litLead.Text = "<div class='body-bloque-lead'>" + nota.txtLead + "</div>";
                List<NoticiaFotografia> listaFoto = noticiaFotoNegocio.ListarxNoticia(nota.intCodigo);
                foreach (NoticiaFotografia notafoto in listaFoto)
                {
                    int intFotografia = notafoto.intFotografia;
                    Fotografia fotografia = fotoNegocio.ListarFotografiaxID(intFotografia);
                    if (nota.vchURL == String.Empty)
                        litImagen.Text = "<img src='fotos/" + fotografia.vchImagen + "' width='296' />";
                    else
                        litImagen.Text = "<a href='" + nota.vchURL +"' target='_blank'><img src='fotos/" + fotografia.vchImagen + "' width='296' /></a>";
                }
            }
        }

        protected void dlPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("lnkbtnPaging"))
            {
                CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
                CargarNoticia();
            }
        }
    }
}