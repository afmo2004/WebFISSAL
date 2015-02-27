using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class SugerenciaNegocio
    {
        public List<Sugerencia> ListarSugerencias()
        {
            SugerenciaData datos = new SugerenciaData();
            return datos.ListarSugerencias();
        }
        public Sugerencia ListarSugerenciaxID(Int32 intCodigo)
        {
            SugerenciaData datos = new SugerenciaData();
            return datos.ListarSugerenciaxID(intCodigo);
        }
        public int InsertarSugerencia(Sugerencia tabla)
        {
            SugerenciaData datos = new SugerenciaData();
            return datos.InsertarSugerencia(tabla);
        }
    }
}
