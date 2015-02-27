using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FISSAL
{
    public partial class consulta_fua : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        protected void CargarGrilla()
        {
            DataTable dtFUA = new DataTable();
            dtFUA = (DataTable)Session["DatosFUA"];
            gvTransferenciaFUA.DataSource = dtFUA;
            gvTransferenciaFUA.DataBind();
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
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            //gvTransferenciaFUA.AllowPaging = false;
            //CargarGrilla();
            gvTransferenciaFUA.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            //gvTransferenciaFUA.AllowPaging = true;
            //CargarGrilla();
        }


    }
}