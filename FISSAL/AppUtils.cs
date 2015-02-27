using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FISSAL
{
    public class AppUtils
    {
        private static string FormateaCadena(string pstrCadena)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            pstrCadena = pstrCadena.Trim();
            pstrCadena = pstrCadena.ToLower();
            pstrCadena = pstrCadena.Replace("\"", "");
            pstrCadena = pstrCadena.Replace("us$", "");
            pstrCadena = pstrCadena.Replace("á", "a");
            pstrCadena = pstrCadena.Replace("é", "e");
            pstrCadena = pstrCadena.Replace("í", "i");
            pstrCadena = pstrCadena.Replace("ó", "o");
            pstrCadena = pstrCadena.Replace("ú", "u");
            pstrCadena = pstrCadena.Replace("ñ", "n");
            pstrCadena = pstrCadena.Replace(".", "");

            foreach (char ch in pstrCadena)
            {
                if (char.IsLetterOrDigit(ch) || ch == ' ')
                {
                    sb.Append(ch);
                }
            }

            pstrCadena = sb.ToString();

            pstrCadena = pstrCadena.Replace(" en ", "-");
            pstrCadena = pstrCadena.Replace(" el ", "-");
            pstrCadena = pstrCadena.Replace(" lo ", "-");
            pstrCadena = pstrCadena.Replace(" la ", "-");
            pstrCadena = pstrCadena.Replace(" que ", "-");
            pstrCadena = pstrCadena.Replace(" con ", "-");
            pstrCadena = pstrCadena.Replace(" de ", "-");
            pstrCadena = pstrCadena.Replace(" por ", "-");

            pstrCadena = pstrCadena.Replace(" ", "-");
            pstrCadena = pstrCadena.Replace("--", "-");
            pstrCadena = pstrCadena.Replace("---", "-");
            pstrCadena = pstrCadena.Replace("----", "-");
            pstrCadena = pstrCadena.Replace("-----", "-");
            pstrCadena = pstrCadena.Replace("----", "-");
            pstrCadena = pstrCadena.Replace("---", "-");
            pstrCadena = pstrCadena.Replace("--", "-");

            return pstrCadena;
        }
        public static string URLLimpia(int pintNoticiaId, string pstrTitulo, string pstrTipo)
        {
            string strURL = "";
            string strCadena = "$%#@!*?;:~`+=()[]{}|\\'<>,/^&.";
            char[] chars = strCadena.ToCharArray();

            pstrTitulo = FormateaCadena(pstrTitulo);
            string strNoticiaID = pintNoticiaId.ToString();
            strURL = "~/" + pstrTipo + "-" + pstrTitulo + "-" + strNoticiaID + ".aspx";

            return strURL;
        }
        public static string URLLimpia2(int pintNoticiaId, string pstrTitulo, string pstrTipo)
        {
            string strURL = "";
            string strCadena = "$%#@!*?;:~`+=()[]{}|\\'<>,/^&.";
            char[] chars = strCadena.ToCharArray();

            pstrTitulo = FormateaCadena(pstrTitulo);

            string strNoticiaID = pintNoticiaId.ToString();
            strURL = pstrTipo + "-" + pstrTitulo + "-" + strNoticiaID + ".aspx";

            return strURL;
        }

    }
}