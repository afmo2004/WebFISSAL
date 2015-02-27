using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class UnidadEjecutoraNegocio
    {
        public List<UnidadEjecutora> ListarUnidadEjecutora(int intDisaId)
        {
            UnidadEjecutoraData control = new UnidadEjecutoraData();
            return control.ListarUnidadEjecutora(intDisaId);
        }
    }
}
