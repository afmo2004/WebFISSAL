using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class PaginaControlNegocio
    {
        public List<PaginaControl> ListarControlesxPagina(int intPagina)
        {
            PaginaControlData control = new PaginaControlData();
            return control.ListarControlesxPagina(intPagina); ;
        }
    }
}
