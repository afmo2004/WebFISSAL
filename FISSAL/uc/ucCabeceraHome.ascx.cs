using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL.uc
{
    public partial class ucCabeceraHome : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlDetalleNegocio obj = new ControlDetalleNegocio();
            List<ControlDetalle> lista = obj.ListarxControlID(1);
            int intContador = 0;
            foreach (ControlDetalle detalle in lista)
            {
                litImages.Text += "<span><img src='banner/" + detalle.vchImagen + "' id='wows" + intContador.ToString() + "' /></span>";
                intContador++;
            }
        }
    }
}