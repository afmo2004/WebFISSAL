using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL
{
    public partial class normas_legales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Normas Legales | FISSAL";
            if (!IsPostBack)
            {
                CargarAnio();
                CargarTipo();
            }
        }

        protected void CargarAnio()
        {
            ParametroDetalleNegocio obj = new ParametroDetalleNegocio();
            ddlAnio.DataSource = obj.ListarParametroDetalle(1,false);
            ddlAnio.DataTextField = "vchDescripcion";
            ddlAnio.DataValueField = "vchValor";
            ddlAnio.DataBind();

            //ddlAnio.SelectedValue = DateTime.Today.Year.ToString();
        }

        protected void CargarTipo()
        {
            ParametroDetalleNegocio obj = new ParametroDetalleNegocio();
            ddlTipo.DataSource = obj.ListarParametroDetalle(2,true);
            ddlTipo.DataTextField = "vchDescripcion";
            ddlTipo.DataValueField = "vchValor";
            ddlTipo.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            litMensaje.Text = "";
            NormasLegalesNegocio obj = new NormasLegalesNegocio();
            int intAnio = Int32.Parse(ddlAnio.SelectedValue);
            string strTipo = ddlTipo.SelectedValue;
            List<NormasLegales> lista = obj.ListarNormasxAnioTipoVigente(intAnio,strTipo);
            gvNormasLegales.DataSource = lista;
            gvNormasLegales.DataBind();
            if (lista.Count == 0)
            {
                litMensaje.Text = "No se encontraron resultados";
            }
        }

        protected void gvNormasLegales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                NormasLegales normasLegales = (NormasLegales)e.Row.DataItem;
                Literal litTitulo = (Literal)e.Row.FindControl("litTitulo");
                Literal litDescarga = (Literal)e.Row.FindControl("litDescarga");
                litDescarga.Text = "<a href='" + AppConfig.VirtualPathString() + @"normaslegales/" + normasLegales.vchArchivo + "' target='_blank'><img src='images/1396604830_document_pdf.png' /></a>";
                switch (normasLegales.chrTipo)
                {
                    case "1":
                        litTitulo.Text = "Resolución Jefatural " + normasLegales.vchTitulo.Trim();
                        break;
                    case "2":
                        litTitulo.Text = "Resolución Ministerial " + normasLegales.vchTitulo.Trim();
                        break;
                    case "3":
                        litTitulo.Text = "Ley N° " + normasLegales.vchTitulo.Trim();
                        break;
                    case "4":
                        litTitulo.Text = "Decreto Supremo N° " + normasLegales.vchTitulo.Trim();
                        break;
                    case "5":
                        litTitulo.Text = "Resolución Jefatural " + normasLegales.vchTitulo.Trim();
                        break;
                }
            }
        }
    }
}