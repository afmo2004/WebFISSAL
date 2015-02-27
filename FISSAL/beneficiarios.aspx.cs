using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL
{
    public partial class beneficiarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarInfo();
        }

        protected void CargarInfo()
        {
            PaginaNegocio paginaNegocio = new PaginaNegocio();
            Pagina pagina = paginaNegocio.ListarPaginaxID(4);
            litTitulo.Text = pagina.vchNombrePagina.Trim();
            litLead.Text = pagina.txtLead;
            litContenido.Text = pagina.txtContenido;
            Page.Title = pagina.vchNombrePagina.Trim() + " | FISSAL";
        }
    }
}