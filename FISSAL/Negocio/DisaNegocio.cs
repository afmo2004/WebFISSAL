using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class DisaNegocio
    {
        public List<Disa> ListarDisa()
        {
            DisaData control = new DisaData();
            return control.ListarDisa();
        }
    }
}
