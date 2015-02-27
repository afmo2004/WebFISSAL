using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class UsuarioNegocio
    {
        public UsuarioNegocio(){}

        public List<Usuario> ListarUsuarios(string pstrBusqueda)
        {
            UsuarioData DatAut = new UsuarioData();
            return DatAut.ListarUsuarios(pstrBusqueda);
        }

        public Usuario ListaUsuarioxLogin(string pstrLogin)
        {
            UsuarioData DatAut = new UsuarioData();
            return DatAut.ListaUsuarioxLogin(pstrLogin);
        }

        public Usuario ListaUsuarioxLoginPassword(string pstrLogin, string pstrPassword)
        {
            UsuarioData DatAut = new UsuarioData();
            return DatAut.ListaUsuarioxLoginPassword(pstrLogin,pstrPassword);
        }

        public int ActualizarUsuario(Usuario usuario)
        {
            UsuarioData DatAut = new UsuarioData();
            return DatAut.ActualizarUsuario(usuario);
        }
    }
}
