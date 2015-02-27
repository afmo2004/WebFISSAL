using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FISSAL.uc
{
    public partial class ucSubmenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litNombreAnio.Text = AppConfig.nombreAnio();
        }
    }
}