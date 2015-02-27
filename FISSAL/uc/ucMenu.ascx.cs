using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FISSAL.uc
{
    public partial class ucMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarMenu();
        }

        protected void CargarMenu()
        {
            string strNombre = Page.AppRelativeVirtualPath.Substring(2);
            switch (strNombre)
            {
                case "index.aspx":
                    litMenu.Text = "" +
                                "<li class='active'><a href='index.aspx'><span>Inicio</span></a></li>" +
                                "<li><a href='quienes-somos.aspx'><span>Nosotros</span></a></li>" +
                                "<li class='has-sub'><a href='#'><span>Transferencias</span></a>" +
                                "    <ul>" +
                                "        <li class='has-sub'><a href='transferencias-calendario.aspx'>Por Calendario de Pago</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-carta.aspx'>Por Carta Orden</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-fua.aspx'>Por Formato Único de Atención (FUA)</a></li>" +
                                "    </ul>" +
                                "</li>" +
                                "<li><a href='convenios-contratos.aspx'><span>Convenios y contratos</span></a></li>" +
                                "<li><a href='normas-legales.aspx'><span>Normas legales</span></a> </li>" +
                                "<li><a href='consultas-reclamos.aspx'><span>Consultas y reclamos</span></a></li>";
                    break;
                case "quienes-somos.aspx":
                    litMenu.Text = "" +
                                "<li><a href='index.aspx'><span>Inicio</span></a></li>" +
                                "<li class='active'><a href='quienes-somos.aspx'><span>Nosotros</span></a></li>" +
                                "<li class='has-sub'><a href='#'><span>Transferencias</span></a>" +
                                "    <ul>" +
                                "        <li class='has-sub'><a href='transferencias-calendario.aspx'>Por Calendario de Pago</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-carta.aspx'>Por Carta Orden</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-fua.aspx'>Por Formato Único de Atención (FUA)</a></li>" +
                                "    </ul>" +
                                "</li>" +
                                "<li><a href='convenios-contratos.aspx'><span>Convenios y contratos</span></a></li>" +
                                "<li><a href='normas-legales.aspx'><span>Normas legales</span></a> </li>" +
                                "<li><a href='consultas-reclamos.aspx'><span>Consultas y reclamos</span></a></li>";
                    break;
                case "convenios-contratos.aspx":
                    litMenu.Text = "" +
                                "<li><a href='index.aspx'><span>Inicio</span></a></li>" +
                                "<li><a href='quienes-somos.aspx'><span>Nosotros</span></a></li>" +
                                "<li class='has-sub'><a href='#'><span>Transferencias</span></a>" +
                                "    <ul>" +
                                "        <li class='has-sub'><a href='transferencias-calendario.aspx'>Por Calendario de Pago</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-carta.aspx'>Por Carta Orden</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-fua.aspx'>Por Formato Único de Atención (FUA)</a></li>" +
                                "    </ul>" +
                                "</li>" +
                                "<li class='active'><a href='convenios-contratos.aspx'><span>Convenios y contratos</span></a></li>" +
                                "<li><a href='normas-legales.aspx'><span>Normas legales</span></a> </li>" +
                                "<li><a href='consultas-reclamos.aspx'><span>Consultas y reclamos</span></a></li>";
                    break;
                case "normas-legales.aspx":
                    litMenu.Text = "" +
                                "<li><a href='index.aspx'><span>Inicio</span></a></li>" +
                                "<li><a href='quienes-somos.aspx'><span>Nosotros</span></a></li>" +
                                "<li class='has-sub'><a href='#'><span>Transferencias</span></a>" +
                                "    <ul>" +
                                "        <li class='has-sub'><a href='transferencias-calendario.aspx'>Por Calendario de Pago</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-carta.aspx'>Por Carta Orden</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-fua.aspx'>Por Formato Único de Atención (FUA)</a></li>" +
                                "    </ul>" +
                                "</li>" +
                                "<li><a href='convenios-contratos.aspx'><span>Convenios y contratos</span></a></li>" +
                                "<li class='active'><a href='normas-legales.aspx'><span>Normas legales</span></a> </li>" +
                                "<li><a href='consultas-reclamos.aspx'><span>Consultas y reclamos</span></a></li>";
                    break;
                case "consultas-reclamos.aspx":
                    litMenu.Text = "" +
                                "<li><a href='index.aspx'><span>Inicio</span></a></li>" +
                                "<li><a href='quienes-somos.aspx'><span>Nosotros</span></a></li>" +
                                "<li class='has-sub'><a href='#'><span>Transferencias</span></a>" +
                                "    <ul>" +
                                "        <li class='has-sub'><a href='transferencias-calendario.aspx'>Por Calendario de Pago</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-carta.aspx'>Por Carta Orden</a></li>" +
                                "        <li class='has-sub'><a href='transferencias-fua.aspx'>Por Formato Único de Atención (FUA)</a></li>" +
                                "    </ul>" +
                                "</li>" +
                                "<li><a href='convenios-contratos.aspx'><span>Convenios y contratos</span></a></li>" +
                                "<li><a href='normas-legales.aspx'><span>Normas legales</span></a> </li>" +
                                "<li class='active'><a href='consultas-reclamos.aspx'><span>Consultas y reclamos</span></a></li>";
                    break;
                default:
                    litMenu.Text = "" +
                    "<li><a href='index.aspx'><span>Inicio</span></a></li>" +
                    "<li><a href='quienes-somos.aspx'><span>Nosotros</span></a></li>" +
                    "<li class='has-sub'><a href='#'><span>Transferencias</span></a>" +
                    "    <ul>" +
                    "        <li class='has-sub'><a href='transferencias-calendario.aspx'>Por Calendario de Pago</a></li>" +
                    "        <li class='has-sub'><a href='transferencias-carta.aspx'>Por Carta Orden</a></li>" +
                    "        <li class='has-sub'><a href='transferencias-fua.aspx'>Por Formato Único de Atención (FUA)</a></li>" +
                    "    </ul>" +
                    "</li>" +
                    "<li><a href='convenios-contratos.aspx'><span>Convenios y contratos</span></a></li>" +
                    "<li><a href='normas-legales.aspx'><span>Normas legales</span></a> </li>" +
                    "<li><a href='consultas-reclamos.aspx'><span>Consultas y reclamos</span></a></li>";
                    break;
            }
        }
    }
}