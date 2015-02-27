using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class ParametroNegocio
    {
        public List<Parametro> ListarParametro()
        {
            ParametroData controlador = new ParametroData();
            return controlador.ListarParametro();
        }

        public Parametro ListarParametroxID(int intCodigo)
        {
            ParametroData controlador = new ParametroData();
            return controlador.ListarParametroxID(intCodigo);
        }

        public int ActualizarParametro(Parametro registro)
        {
            ParametroData controlador = new ParametroData();
            return controlador.ActualizarParametro(registro);
        }
    }
}
