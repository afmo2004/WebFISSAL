using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(int intCodigoUsuario, string vchLogin, string vchPassword, string vchNombreUsuario, int intPerfil, string chrEstado)
        {
            this.intCodigoUsuario = intCodigoUsuario;
            this.vchLogin = vchLogin;
            this.vchPassword = vchPassword;
            this.vchNombreUsuario = vchNombreUsuario;
            this.intPerfil = intPerfil;
            this.chrEstado=chrEstado;
        }

        private int _intCodigoUsuario;
        private string _vchLogin;
        private string _vchPassword;
        private string _vchNombreUsuario;
        private int _intPerfil;
        private string _chrEstado;

        public int intCodigoUsuario { 
            get {return _intCodigoUsuario;}
            set {_intCodigoUsuario = value; }
        }

        public string vchLogin {
            get {return _vchLogin;}
            set {_vchLogin = value; }
        }

        public string vchPassword { 
            get {return _vchPassword;} 
            set {_vchPassword = value;} 
        }
        
        public string vchNombreUsuario {
            get {return _vchNombreUsuario;}
            set {_vchNombreUsuario=value;} 
        }
        public int intPerfil {
            get {return _intPerfil ;}
            set { _intPerfil =value; }
        }
        public string chrEstado {
            get {return _chrEstado ;}
            set {_chrEstado=value ;} 
        }
    }
}
