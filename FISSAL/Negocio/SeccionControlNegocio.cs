using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class SeccionControlNegocio
    {
        public List<SeccionControl> ListarControlesxSeccion(int intSeccion, string chrUbicacion)
        {
            SeccionControlData control = new SeccionControlData();
            return control.ListarControlesxSeccion(intSeccion, chrUbicacion);
        }

        public int ActualizarControlSeccion(SeccionControl seccionControl)
        {
            SeccionControlData control = new SeccionControlData();
            return control.ActualizarControlSeccion(seccionControl);
        }
        public int ActualizarControlSeccionOrden(SeccionControl seccionControl)
        {
            SeccionControlData control = new SeccionControlData();
            return control.ActualizarControlSeccionOrden(seccionControl);
        }
        public int EliminarControlSeccion(SeccionControl seccionControl)
        {
            SeccionControlData control = new SeccionControlData();
            return control.EliminarControlSeccion(seccionControl);
        }
    }
}
