using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class UnidadEjecutora
    {
        public UnidadEjecutora() { }
        public UnidadEjecutora(int unidadEjecutoraId, string descripcion) 
        {
            this.unidadEjecutoraId = unidadEjecutoraId;
            this.descripcion = descripcion;
        }
        private int _unidadEjecutoraId;

        public int unidadEjecutoraId
        {
            get { return _unidadEjecutoraId; }
            set { _unidadEjecutoraId = value; }
        }
        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private int _disaId;

        public int disaId
        {
            get { return _disaId; }
            set { _disaId = value; }
        }
    }
}
