using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class OpcionNegocio
    {
        public List<Opcion> ListarOpcion()
        {
            OpcionData controlador = new OpcionData();
            return controlador.ListarOpcion();
        }
        public List<Opcion> ListarOpcionAsignado(string vchLogin, int intNivel, int intCodigoOpcionPadre)
        {
            OpcionData controlador = new OpcionData();
            return controlador.ListarOpcionAsignado(vchLogin, intNivel, intCodigoOpcionPadre);
        }

        public List<Opcion> ListarOpcionxNivel(int intNivel, int intCodigoOpcionPadre)
        {
            OpcionData controlador = new OpcionData();
            return controlador.ListarOpcionxNivel(intNivel, intCodigoOpcionPadre);
        }
    }
}
