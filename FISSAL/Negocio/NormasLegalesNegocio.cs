using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class NormasLegalesNegocio
    {
        public NormasLegales ListarNormasxID(int pintNormaID)
        {
            NormasLegalesData control = new NormasLegalesData();
            return control.ListarNormasxID(pintNormaID);
        }
        public List<NormasLegales> ListarNormas()
        {
            NormasLegalesData control = new NormasLegalesData();
            return control.ListarNormas();
        }
        public List<NormasLegales> ListarNormasxAnioTipo(int intAnio, string pstrTipo)
        {
            NormasLegalesData control = new NormasLegalesData();
            return control.ListarNormasxAnioTipo(intAnio, pstrTipo);
        }
        public List<NormasLegales> ListarNormasxAnioTipoVigente(int intAnio, string pstrTipo)
        {
            NormasLegalesData control = new NormasLegalesData();
            return control.ListarNormasxAnioTipoVigente(intAnio, pstrTipo);
        }
        public int ActualizarNormaLegal(NormasLegales entidad)
        {
            NormasLegalesData control = new NormasLegalesData();
            return control.ActualizarNormaLegal(entidad);
        }
    }
}
