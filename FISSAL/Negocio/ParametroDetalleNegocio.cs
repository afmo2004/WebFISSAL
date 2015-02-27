using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class ParametroDetalleNegocio
    {
        public ParametroDetalle ListarParametroDetallexID(int intCodigo)
        {
            ParametroDetalleData controlador = new ParametroDetalleData();
            return controlador.ListarParametroDetallexID(intCodigo);
        }
        public List<ParametroDetalle> ListarParametroDetalle(int intCodigoParametro, bool bOrdenAscendente)
        {
            ParametroDetalleData controlador = new ParametroDetalleData();
            return controlador.ListarParametroDetalle(intCodigoParametro, bOrdenAscendente);
        }

        public int ActualizarParametroDetalle(ParametroDetalle registro)
        {
            ParametroDetalleData controlador = new ParametroDetalleData();
            return controlador.ActualizarParametroDetalle(registro);
        }
    }
}
