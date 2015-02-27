using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Parametro
    {
        public Parametro() { }

        public Parametro(int intCodigo, string vchNombre) 
        {
            this.intCodigo = intCodigo;
            this.vchNombre = vchNombre;
        }

        private int _intCodigo;

        public int intCodigo
        {
            get { return _intCodigo; }
            set { _intCodigo = value; }
        }
        private string _vchNombre;

        public string vchNombre
        {
            get { return _vchNombre; }
            set { _vchNombre = value; }
        }

    }
}
