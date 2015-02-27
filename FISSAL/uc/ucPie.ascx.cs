using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FISSAL.uc
{
    public partial class ucPie : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strTitulo = this.Parent.Page.AppRelativeVirtualPath;
            if (strTitulo.Equals("~/index.aspx"))
                this.countMe();
            DataSet tmpDs = new DataSet();
            tmpDs.ReadXml(Server.MapPath("~/counter.xml"));
            int intContador = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());
            lblContador.Text = intContador.ToString("000000");
        }


        private void countMe()
        {
            DataSet tmpDs = new DataSet();
            tmpDs.ReadXml(Server.MapPath("~/counter.xml"));
            int hits = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());
            hits += 1;
            tmpDs.Tables[0].Rows[0]["hits"] = hits.ToString();
            tmpDs.WriteXml(Server.MapPath("~/counter.xml"));
        } 

    }
}