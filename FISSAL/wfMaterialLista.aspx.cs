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
    public partial class wfMaterialLista : System.Web.UI.Page
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
                    CargarCombo();
                }
            }
        }

        protected void CargarDatosGrilla()
        {
            MaterialNegocio obj = new MaterialNegocio();
            gvMaterialLista.DataSource = obj.ListarMaterial();
            gvMaterialLista.DataBind();
        }

        protected void CargarCombo()
        {
            ParametroDetalleNegocio obj = new ParametroDetalleNegocio();
            ddlTipo.DataSource = obj.ListarParametroDetalle(6, true);
            ddlTipo.DataTextField = "vchDescripcion";
            ddlTipo.DataValueField = "vchValor";
            ddlTipo.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "0";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            rdpFechaPublicacion.SelectedDate = DateTime.Now;
            chkEstado.Checked = true;
            lblArchivo.Text = "";
            lblImagen.Text = "";
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void CargarMaterial(int intCodigo)
        {
            MaterialNegocio materialNegocio = new MaterialNegocio();
            Material material = materialNegocio.ListarMaterialxId(intCodigo);
            lblCodigo.Text = material.intMaterial.ToString();
            rdpFechaPublicacion.SelectedDate = material.dtmFechaPublicacion;
            txtTitulo.Text = material.vchTitulo;
            txtDescripcion.Text = material.vchDescripcion;
            ddlTipo.SelectedValue = material.intTipo.ToString();
            lblImagen.Text = material.vchImagen;
            lblArchivo.Text = material.vchArchivo;
            if (material.chrEstado == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;
        }
        protected void gvMaterialLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCodigo = int.Parse(gvMaterialLista.SelectedRow.Cells[1].Text);
            CargarMaterial(intCodigo);
            mvwPrincipal.SetActiveView(vwEdicion);
        }

        protected void gvMaterialLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMaterialLista.PageIndex = e.NewPageIndex;
            CargarDatosGrilla();
        }

        protected void gvMaterialLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Material material = (Material)e.Row.DataItem;
                Label lblFechaPublicacion = (Label)e.Row.FindControl("lblFechaPublicacion");
                lblFechaPublicacion.Text = material.dtmFechaPublicacion.ToShortDateString();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string strPathUpload = AppConfig.PathStringUpload();
            MaterialNegocio materialNegocio = new MaterialNegocio();
            int intCodigo = Int32.Parse(lblCodigo.Text);
            DateTime dtmFechaPub = (DateTime)rdpFechaPublicacion.SelectedDate;
            string vchTitulo = txtTitulo.Text;
            string vchDescripcion = txtDescripcion.Text;
            string vchArchivo = lblArchivo.Text;
            bool bNuevo = false;
            if (fuArchivo.HasFile)
            {
                vchArchivo = fuArchivo.FileName;
                if (intCodigo > 0)
                {
                    string strExtension = fuArchivo.FileName.Substring(fuArchivo.FileName.Length - 4, 4);
                    vchArchivo = ddlTipo.SelectedItem.Text + intCodigo.ToString() + strExtension;
                    fuArchivo.SaveAs(strPathUpload + @"materiales/" + vchArchivo);
                }
                else
                {
                    bNuevo = true;
                }
            }
            string vchImagen = lblImagen.Text;
            if (fuImagen.HasFile)
            {
                vchImagen = fuImagen.FileName;
                if (intCodigo > 0)
                {
                    string strExtension = fuImagen.FileName.Substring(fuImagen.FileName.Length - 4, 4);
                    vchImagen = ddlTipo.SelectedItem.Text + intCodigo.ToString() + strExtension;
                    fuImagen.SaveAs(strPathUpload + @"images/" + vchImagen);
                }
                else 
                { 
                    bNuevo = true; 
                }
            }
            string chrEstado = "0";
            if (chkEstado.Checked)
                chrEstado = "1";
            int intTipo = Int32.Parse(ddlTipo.SelectedValue);
            string vchUsuarioCreacion = this.Page.User.Identity.Name;
            string vchUsuarioModificacion = this.Page.User.Identity.Name;
            Material material = new Material(intCodigo, vchTitulo, vchDescripcion, intTipo, vchImagen, vchArchivo, chrEstado,dtmFechaPub ,vchUsuarioCreacion, vchUsuarioModificacion);
            intCodigo = materialNegocio.ActualizarMaterial(material);
            material.intMaterial = intCodigo;
            //SUBIR IMAGEN SOLO CUANDO ES REG NUEVO
            if (fuArchivo.HasFile && bNuevo)
            {
                string strExtension = fuArchivo.FileName.Substring(fuArchivo.FileName.Length - 4, 4);
                vchArchivo = ddlTipo.SelectedItem.Text + intCodigo.ToString() + strExtension;
                material.vchArchivo = vchArchivo;
                fuArchivo.SaveAs(strPathUpload + @"materiales/" + vchArchivo);
            }
            if (fuImagen.HasFile && bNuevo)
            {
                string strExtension = fuImagen.FileName.Substring(fuImagen.FileName.Length - 4, 4);
                vchImagen = ddlTipo.SelectedItem.Text + intCodigo.ToString() + strExtension;
                fuImagen.SaveAs(strPathUpload + @"images/" + vchImagen);
                material.vchImagen = vchImagen;
                
            }
            if (bNuevo)
            {
                materialNegocio.ActualizarMaterial(material);
            }
            CargarDatosGrilla();
            mvwPrincipal.SetActiveView(vwGrilla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvwPrincipal.SetActiveView(vwGrilla);
        }
    }
}