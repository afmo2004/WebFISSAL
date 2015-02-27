using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Perfil
    {
        public Perfil() { }

        public Perfil(int intCodigoPerfil, string vchNombrePerfil, string chrEstado) {
            this.intCodigoPerfil = intCodigoPerfil;
            this.vchNombrePerfil = vchNombrePerfil;
            this.chrEstado = chrEstado;
        }

        private int _intCodigoPerfil;

        public int intCodigoPerfil
        {
            get { return _intCodigoPerfil; }
            set { _intCodigoPerfil = value; }
        }
        private string _vchNombrePerfil;

        public string vchNombrePerfil
        {
            get { return _vchNombrePerfil; }
            set { _vchNombrePerfil = value; }
        }
        private string _chrEstado;

        public string chrEstado
        {
            get { return _chrEstado; }
            set { _chrEstado = value; }
        }
 
    }
}
