using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class PerfilOpcion
    {
        public PerfilOpcion() { }

        public PerfilOpcion(int intCodigoPerfil, int intCodigoOpcion) 
        {
            this.intCodigoPerfil = intCodigoPerfil;
            this.intCodigoOpcion = intCodigoOpcion;
        }

        private int _intCodigoPerfil;

        public int intCodigoPerfil
        {
            get { return _intCodigoPerfil; }
            set { _intCodigoPerfil = value; }
        }

        private int _intCodigoOpcion;

        public int intCodigoOpcion
        {
            get { return _intCodigoOpcion; }
            set { _intCodigoOpcion = value; }
        }

    }
}
