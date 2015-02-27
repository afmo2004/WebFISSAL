using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL
{
    public partial class mpAdmin2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litBienvenida.Text = "Bienvenido, " + this.Page.User.Identity.Name + "  ";
            if (!IsPostBack)
                CargarOpciones();
        }

        protected void CargarOpciones()
        {
            string vchLogin = this.Page.User.Identity.Name;
            OpcionNegocio obj = new OpcionNegocio();
            List<Opcion> lista = obj.ListarOpcionAsignado(vchLogin, 1, 0);
            tvwMenu.Nodes.Clear();
            foreach (Opcion opcion in lista)
            {
                TreeNode nodo1 = new TreeNode(opcion.vchNombreOpcion, opcion.intCodigoOpcion.ToString(), "", opcion.vchPagina, "");
                tvwMenu.Nodes.Add(nodo1);
                //Verificar si tiene hijos
                List<Opcion> lista1 = obj.ListarOpcionAsignado(vchLogin, 2, opcion.intCodigoOpcion);
                foreach (Opcion opcion1 in lista1)
                {
                    TreeNode nodo2 = new TreeNode(opcion1.vchNombreOpcion, opcion1.intCodigoOpcion.ToString(), "", opcion1.vchPagina, "");
                    nodo1.ChildNodes.Add(nodo2);
                }
            }
            tvwMenu.ExpandAll();
        }
        protected void imgCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Cookies.Remove("Security");
            Session.RemoveAll();
            Response.Redirect("wfLogin.aspx");
        }
    }
}