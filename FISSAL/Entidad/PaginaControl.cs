using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class PaginaControl
    {
        public PaginaControl() { }

        public PaginaControl(int intPagina, int intCodigoControl, int intOrden) {
            this.intPagina = intPagina;
            this.intCodigoControl = intCodigoControl;
            this.intOrden = intOrden;
        }

        private int _intPagina;

        public int intPagina
        {
            get { return _intPagina; }
            set { _intPagina = value; }
        }
        private int _intCodigoControl;

        public int intCodigoControl
        {
            get { return _intCodigoControl; }
            set { _intCodigoControl = value; }
        }
        private int _intOrden;

        public int intOrden
        {
            get { return _intOrden; }
            set { _intOrden = value; }
        }

    }
}
