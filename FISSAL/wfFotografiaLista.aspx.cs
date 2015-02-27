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
    public partial class wfFotografiaLista : System.Web.UI.Page
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
                    CargarDatosGrilla();
                }
            }
        }

        protected void CargarDatosGrilla()
        {
            FotografiaNegocio obj = new FotografiaNegocio();
            List<Fotografia> lista = obj.ListarFotografias();
            dlFoto.DataSource = lista;
            dlFoto.DataBind();
        }

        protected void dlFoto_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || 
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Fotografia foto = (Fotografia)e.Item.DataItem;
                ImageButton imgEditar = (ImageButton)e.Item.FindControl("imgEditar");
                imgEditar.ImageUrl = "~/fotos/" + foto.vchImagen.Trim();
                imgEditar.CommandArgument = foto.intCodigo.ToString();

                ImageButton imgEliminar = (ImageButton)e.Item.FindControl("imgEliminar");
                imgEliminar.CommandArgument = foto.intCodigo.ToString();

                //Literal litImagen = (Literal)e.Item.FindControl("litImagen");
                //litImagen.Text = "<img src='fotos/" + foto.vchImagen.Trim() + "' width='200' />";
                //CheckBox chkEstado = (CheckBox)e.Item.FindControl("chkEstado");
                //if (foto.chrEstado == "1")
                //    chkEstado.Checked = true;
                //else
                //    chkEstado.Checked = false;
            }
        }
        protected void dlFoto_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int intFoto = 0;
            FotografiaNegocio obj = null;
            
            switch (e.CommandName)
            {
                case "editar":
                    intFoto = Int32.Parse(e.CommandArgument.ToString());
                    obj = new FotografiaNegocio();
                    Fotografia foto = obj.ListarFotografiaxID(intFoto);
                    lblCodigo.Text = foto.intCodigo.ToString();
                    txtLeyenda.Text = foto.vchLeyenda;
                    lblImagen.Text = foto.vchImagen;
                    litImagen.Text = "<img src='fotos/" + foto.vchImagen.Trim() + "' width='200' />";
                    if (foto.chrEstado == "1")
                        chkEstado.Checked = true;
                    else
                        chkEstado.Checked = false;

                    mvwPrincipal.SetActiveView(vwEdicion);
                    break;
                case "eliminar":
                    intFoto = Int32.Parse(e.CommandArgument.ToString());
                    obj = new FotografiaNegocio();
                    NoticiaFotografiaNegocio objNoticiaFoto = new NoticiaFotografiaNegocio();
                    List<NoticiaFotografia> listaNotaFoto = objNoticiaFoto.ListarxFoto(intFoto);
                    if (listaNotaFoto.Count > 0)
                    {
                        lblErrores.Text = "Foto tiene notas enlazadas";
                    }
                    else
                    {
                        obj.EliminarFoto(intFoto);
                        CargarDatosGrilla();
                        lblErrores.Text = "Foto eliminada";
                    }
                    break;
            }
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            txtLeyenda.Text = "";
            lblImagen.Text = "";
            chkEstado.Checked = true;
            lblErrores.Text = "";
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string strPathUpload = AppConfig.PathStringUpload();
            FotografiaNegocio obj = new FotografiaNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            string vchLeyenda = txtLeyenda.Text;
            string vchImagen = lblImagen.Text;
            
            string chrEstado = "0";
            if (chkEstado.Checked)
                chrEstado = "1";
            string vchUsuarioCreacion = this.Page.User.Identity.Name;
            string vchUsuarioModificacion = this.Page.User.Identity.Name;
            string strExtension = "";
            if (intCodigo == 0)
            {
                intCodigo = obj.InsertarFoto(intCodigo, vchLeyenda, vchImagen, chrEstado, vchUsuarioCreacion, vchUsuarioModificacion);
                if (fuImagen.HasFile)
                {
                    strExtension = fuImagen.FileName.Substring(fuImagen.FileName.Length - 4, 4);
                    vchImagen = intCodigo.ToString() + strExtension;
                    obj.ActualizarFoto(intCodigo, vchLeyenda, vchImagen, chrEstado, vchUsuarioCreacion, vchUsuarioModificacion);
                }
            }
            else
            {
                if (fuImagen.HasFile)
                {
                    strExtension = fuImagen.FileName.Substring(fuImagen.FileName.Length - 4, 4);
                    vchImagen = intCodigo.ToString() + strExtension;
                }
                obj.ActualizarFoto(intCodigo, vchLeyenda, vchImagen, chrEstado, vchUsuarioCreacion, vchUsuarioModificacion);
            }
            //CARGAR IMAGEN
            if (fuImagen.HasFile)
            {
                fuImagen.SaveAs(strPathUpload + @"fotos/" + vchImagen);
            }
            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblErrores.Text = "";
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        
    }
}