using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;
using System.Web.Security;

namespace FISSAL
{
    public partial class wfAsignarOpcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarPerfiles();
                    CargarOpciones();
                }
            }
        }

        protected void CargarPerfiles()
        {
            PerfilNegocio obj = new PerfilNegocio();
            List<Perfil> lista = obj.ListarPerfiles("");
            ddlPerfil.DataSource = lista;
            ddlPerfil.DataValueField = "intCodigoPerfil";
            ddlPerfil.DataTextField = "vchNombrePerfil";
            ddlPerfil.DataBind();
        }
        protected void CargarOpciones()
        {
            OpcionNegocio obj = new OpcionNegocio();
            PerfilOpcionNegocio objPerfilOpcion = new PerfilOpcionNegocio();
            List<Opcion> lista = obj.ListarOpcionxNivel(1,0);
            int intCodigoPerfil = Int32.Parse(ddlPerfil.SelectedValue.ToString());
            tvwOpciones.Nodes.Clear();
            foreach (Opcion opcion in lista)
            {
                TreeNode nodo1 = new TreeNode(opcion.vchNombreOpcion, opcion.intCodigoOpcion.ToString(), "", opcion.vchPagina, "");
                PerfilOpcion perfilOpcion = objPerfilOpcion.ListaControlxID(intCodigoPerfil, opcion.intCodigoOpcion);
                if (perfilOpcion.intCodigoOpcion != 0)
                    nodo1.Checked = true;
                tvwOpciones.Nodes.Add(nodo1);
                //Verificar si tiene hijos
                List<Opcion> lista1 = obj.ListarOpcionxNivel(2, opcion.intCodigoOpcion);
                foreach (Opcion opcion1 in lista1)
                {
                    TreeNode nodo2 = new TreeNode(opcion1.vchNombreOpcion, opcion1.intCodigoOpcion.ToString(), "", opcion1.vchPagina, "");
                    PerfilOpcion perfilOpcion2 = objPerfilOpcion.ListaControlxID(intCodigoPerfil, opcion1.intCodigoOpcion);
                    if (perfilOpcion2.intCodigoOpcion != 0)
                        nodo2.Checked = true;
                    nodo1.ChildNodes.Add(nodo2);
                }
            }
            tvwOpciones.ExpandAll();
        }
        protected void ddlPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOpciones();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int intPerfilId = int.Parse(ddlPerfil.SelectedValue.ToString());
            PerfilOpcionNegocio obj = new PerfilOpcionNegocio();
            int intCodigoOpcion = 0;
            for (int i = 0; i < tvwOpciones.Nodes.Count; i++)
            {
                TreeNode nodo1 = tvwOpciones.Nodes[i];
                intCodigoOpcion = Int32.Parse(nodo1.Value.ToString());
                PerfilOpcion data = new PerfilOpcion(intPerfilId, intCodigoOpcion);
                obj.EliminarPerfilOpcion(data);
                if (nodo1.Checked)
                {
                    obj.ActualizarPerfilOpcion(data);
                }
                //NODOS CHILDS NIVEL 2
                for (int j = 0; j < nodo1.ChildNodes.Count; j++)
                {
                    TreeNode nodo2 = nodo1.ChildNodes[j];
                    intCodigoOpcion = Int32.Parse(nodo2.Value.ToString());
                    PerfilOpcion data2 = new PerfilOpcion(intPerfilId, intCodigoOpcion);
                    obj.EliminarPerfilOpcion(data2);
                    if (nodo2.Checked)
                    {
                        obj.ActualizarPerfilOpcion(data2);
                    }
                }
            }
            CargarOpciones();
        }
    }
}