using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL
{
    public partial class mpHome2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarControles();
        }

        protected void CargarControles()
        {
            SeccionControlNegocio obj = new SeccionControlNegocio();
            ControlNegocio objControl = new ControlNegocio();
            List<SeccionControl> listaDerecha = obj.ListarControlesxSeccion(2,"D");
            phDerecha.Controls.Clear();
            foreach (SeccionControl seccionControl in listaDerecha)
            {
                int intControl = seccionControl.intCodigoControl;
                FISSAL.Entidad.Control control = objControl.ListaControlxID(intControl);
                UserControl ucControl = (UserControl)Page.LoadControl("uc/" + control.vchControl);
                PropertyInfo[] info = ucControl.GetType().GetProperties();
                foreach (PropertyInfo item in info)
                {
                    if (item.CanWrite)
                    {
                        switch (item.Name)
                        {
                            case "estiloCabeceraControl":
                                item.SetValue(ucControl, "header-enlaces");
                                break;
                            case "estiloFooterControl":
                                item.SetValue(ucControl, "footer-enlaces");
                                break;
                        }
                    }
                }
                phDerecha.Controls.Add(ucControl);
            }
        }
    }
}