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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarControles();
        }
        protected void CargarControles()
        {
            SeccionControlNegocio obj = new SeccionControlNegocio();
            ControlNegocio objControl = new ControlNegocio();
            //CARGAR CONTROL DEL LADO IZQUIERDO
            List<SeccionControl> listaIzquierda = obj.ListarControlesxSeccion(1, "I");
            phDerecha.Controls.Clear();
            foreach (SeccionControl seccionControl in listaIzquierda)
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
                                item.SetValue(ucControl, "header-notvid");
                                break;
                            case "estiloFooterControl":
                                item.SetValue(ucControl, "footer-bloque");
                                break;
                        }
                    }
                }
                phIzquierda.Controls.Add(ucControl);
            }
            //CARGAR CONTROL DEL LADO DERECHO
            List<SeccionControl> listaDerecha = obj.ListarControlesxSeccion(1,"D");
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