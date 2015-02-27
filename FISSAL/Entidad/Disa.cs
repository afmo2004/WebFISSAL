using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Disa
    {
        public Disa() { }

        public Disa(int disaId, string descripcion) 
        {
            this.disaId = disaId;
            this.descripcion = descripcion;
        }

        private int _disaId;

        public int disaId
        {
            get { return _disaId; }
            set { _disaId = value; }
        }
        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

    }
}
