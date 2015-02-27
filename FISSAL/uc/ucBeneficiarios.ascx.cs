using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL.uc
{
    public partial class ucBeneficiarios : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarInfo();
        }

        protected void CargarInfo()
        {
            PaginaNegocio paginaNegocio = new PaginaNegocio();
            Pagina pagina = paginaNegocio.ListarPaginaxID(4);
            litLead.Text = pagina.txtLead;
        }
    }
}