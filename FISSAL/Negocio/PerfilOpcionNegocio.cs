using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class PerfilOpcionNegocio
    {
        public PerfilOpcion ListaControlxID(int pintCodigoPerfil, int pintCodigoOpcion)
        {
            PerfilOpcionData controlador = new PerfilOpcionData();
            return controlador.ListaControlxID(pintCodigoPerfil, pintCodigoOpcion);
        }

        public int ActualizarPerfilOpcion(PerfilOpcion perfilOpcion)
        {
            PerfilOpcionData controlador = new PerfilOpcionData();
            return controlador.ActualizarPerfilOpcion(perfilOpcion);
        }

        public int EliminarPerfilOpcion(PerfilOpcion perfilOpcion)
        {
            PerfilOpcionData controlador = new PerfilOpcionData();
            return controlador.EliminarPerfilOpcion(perfilOpcion);
        }
    }
}
