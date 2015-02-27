using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class ControlDetalleNegocio
    {
        public ControlDetalleNegocio() { }

        public List<ControlDetalle> ListarxControlID(int intCodigoControl)
        {
            ControlDetalleData controlDetalle = new ControlDetalleData();
            return controlDetalle.ListarxControlID(intCodigoControl); ;
        }
        public ControlDetalle ListaControlDetallexID(int pintControlDetalle)
        {
            ControlDetalleData controlDetalle = new ControlDetalleData();
            return controlDetalle.ListaControlDetallexID(pintControlDetalle);
        }

        public int ActualizarControlDetalle(int pintControlDetalle, int pintOrden, string pvchUsuarioModificacion)
        {
            ControlDetalleData controlDetalle = new ControlDetalleData();
            return controlDetalle.ActualizarControlDetalle(pintControlDetalle, pintOrden, pvchUsuarioModificacion);
        }

        public int ActualizarControlDetalle(ControlDetalle controlDetalle)
        {
            ControlDetalleData controlData = new ControlDetalleData();
            return controlData.ActualizarControlDetalle(controlDetalle);
        }
    }
}
