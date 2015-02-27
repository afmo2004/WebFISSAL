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
    public partial class ucDifusion : System.Web.UI.UserControl
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

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void CargarDatos()
        {
            ControlDetalleNegocio obj = new ControlDetalleNegocio();
            List<ControlDetalle> lista = obj.ListarxControlID(5);
            litEnlace.Text = "";
            foreach (ControlDetalle detalle in lista)
            {
                if (detalle.chrEstado.Equals("1"))
                {
                    if (detalle.vchImagenHover != String.Empty)
                        litEnlace.Text += "<a href='" + detalle.vchURL.Trim() + "' target='_blank'><img src='banner/" + detalle.vchImagen.Trim() + @"' onmouseover=""this.src='banner/" + detalle.vchImagenHover.Trim() + @"';"" onmouseout=""this.src='banner/" + detalle.vchImagen.Trim() + @"';"" alt='" + detalle.vchTexto.Trim() + "' title='" + detalle.vchTexto.Trim() + "' /></a>";
                    else
                    {
                        if (detalle.vchURL != String.Empty)
                        {
                            litEnlace.Text += "<a href='" + detalle.vchURL.Trim() + "' target='_blank'><img src='banner/" + detalle.vchImagen.Trim() + "' alt='" + detalle.vchTexto.Trim() + "' title='" + detalle.vchTexto.Trim() + "' /></a>";
                        }
                        else
                        {
                            litEnlace.Text += "<img src='banner/" + detalle.vchImagen.Trim() + "' alt='" + detalle.vchTexto.Trim() + "' title='" + detalle.vchTexto.Trim() + "' />";
                        }
                    }
                }
            }
        }
    }
}