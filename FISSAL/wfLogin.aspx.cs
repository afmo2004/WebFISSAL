using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;

namespace FISSAL
{
    public partial class wfLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidarUsuario(object sender, AuthenticateEventArgs e)
        {
            UsuarioNegocio obj = new UsuarioNegocio();
            Usuario usuario = obj.ListaUsuarioxLogin(loginSistema.UserName);
            if (usuario.intCodigoUsuario == 0)
            {
                loginSistema.FailureText = "Usuario no existe";
                return;
            }
            usuario = obj.ListaUsuarioxLoginPassword(loginSistema.UserName, loginSistema.Password);
            if (usuario.intCodigoUsuario == 0)
            {
                loginSistema.FailureText = "Password incorrecto";
                return;
            }
            FormsAuthentication.RedirectFromLoginPage(loginSistema.UserName, loginSistema.RememberMeSet);
        }
    }
}