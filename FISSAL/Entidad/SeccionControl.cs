using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class SeccionControl
    {
        public SeccionControl() { }

        public SeccionControl(int intSeccion, int intCodigoControl, int intOrden, string chrUbicacion)
        {
            this.intSeccion = intSeccion;
            this.intCodigoControl = intCodigoControl;
            this.intOrden = intOrden;
            this.chrUbicacion = chrUbicacion;
        }

        private int _intSeccion;

        public int intSeccion
        {
            get { return _intSeccion; }
            set { _intSeccion = value; }
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

        private string _chrUbicacion;

        public string chrUbicacion
        {
            get { return _chrUbicacion; }
            set { _chrUbicacion = value; }
        }

    }
}
