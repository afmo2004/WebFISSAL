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
    public partial class ucVideo : System.Web.UI.UserControl
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
            CargarVideo();
        }

        protected void CargarVideo()
        {
            VideoNegocio videoNegocio = new VideoNegocio();
            List<Video> lista = videoNegocio.ListarVideoUltimos();
            if (lista.Count > 0)
            {
                litTitulo.Text = "<h2><a href='" + lista[0].vchURL + "' target='_blank'>" + lista[0].vchTitulo.Trim() + "</a></h2>";
                litScript.Text = lista[0].txtScript;
            }
        }
    }
}