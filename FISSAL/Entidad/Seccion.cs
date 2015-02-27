using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Seccion
    {
        public Seccion() { }

        public Seccion(int intSeccion, string vchNombreSeccion) 
        {
            this.intSeccion = intSeccion;
            this.vchNombreSeccion = vchNombreSeccion;
        }

        private int _intSeccion;

        public int intSeccion
        {
            get { return _intSeccion; }
            set { _intSeccion = value; }
        }

        private string _vchNombreSeccion;

        public string vchNombreSeccion
        {
            get { return _vchNombreSeccion; }
            set { _vchNombreSeccion = value; }
        }
    }
}
