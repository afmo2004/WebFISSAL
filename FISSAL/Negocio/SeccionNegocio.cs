using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class SeccionNegocio
    {
        public List<Seccion> ListarSeccion()
        {
            SeccionData data = new SeccionData();
            return data.ListarSeccion();
        }
    }
}
