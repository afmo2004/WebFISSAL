using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public partial class transferencias_fua : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Transferencias FUA | FISSAL";
            if (!IsPostBack)
                CargarDatos();
        }

        protected void CargarDatos()
        {
            CargarDisa();
            CargarAnio();
        }

        protected void CargarDisa()
        {
            DisaNegocio objDisa = new DisaNegocio();
            ddlDisa.DataSource = objDisa.ListarDisa();
            ddlDisa.DataValueField = "disaId";
            ddlDisa.DataTextField  = "descripcion";
            ddlDisa.DataBind();

            int intDisa = Int32.Parse(ddlDisa.SelectedValue.ToString());
            CargarUnidadEjecutora(intDisa);
        }

        protected void CargarUnidadEjecutora(int intDisaId)
        {
            UnidadEjecutoraNegocio obj = new UnidadEjecutoraNegocio();
            ddlUnidadEjecutora.DataSource = obj.ListarUnidadEjecutora(intDisaId);
            ddlUnidadEjecutora.DataValueField = "unidadEjecutoraId";
            ddlUnidadEjecutora.DataTextField = "descripcion";
            ddlUnidadEjecutora.DataBind();
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

        protected void CargarGrilla()
        {
            SqlConnection sqlConexion = new SqlConnection(AppConfig.CadenaConexionFUA());
            try
            {
                sqlConexion.Open();
                string strPeriodo = ddlAnio.SelectedValue.ToString() + ddlMes.SelectedValue.ToString();
                string strSelect = "select * from TranferenciaFUAS " +
                                "where periodotransferencia = '" + strPeriodo + "' and " +
                                "disa = " + ddlDisa.SelectedValue.ToString() + " and " +
                                "CodigoUnidadEjecutora = " + ddlUnidadEjecutora.SelectedValue.ToString() +
                                " order by fechaatencion";
                SqlCommand sqlComando = new SqlCommand(strSelect, sqlConexion);
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlComando);
                DataTable dtFUA = new DataTable();
                sqlDA.Fill(dtFUA);
                if (dtFUA.Rows.Count > 0)
                {
                    Session["DatosFUA"] = dtFUA;
                    Response.Redirect("consulta-fua.aspx");
                    btnExportar.Visible = true;
                }
                //gvTransferenciaFUA.DataSource = dtFUA;
                //gvTransferenciaFUA.DataBind();
            }
            catch (Exception err)
            {
            }
            finally
            {
                sqlConexion.Close();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void gvTransferenciaFUA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drFila = (DataRowView)e.Row.DataItem;
                Label lblFechaAtencion = (Label)e.Row.FindControl("lblFechaAtencion");
                lblFechaAtencion.Text = ((DateTime)drFila["fechaatencion"]).ToShortDateString();
            }
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=transferenciaFUA.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw  = new HtmlTextWriter(sw);
            //gvTransferenciaFUA.AllowPaging = false;
            //CargarGrilla();
            gvTransferenciaFUA.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            //gvTransferenciaFUA.AllowPaging = true;
            //CargarGrilla();
        }

        protected void ddlDisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intDisa = Int32.Parse(ddlDisa.SelectedValue.ToString());
            CargarUnidadEjecutora(intDisa);
        }
    }
}