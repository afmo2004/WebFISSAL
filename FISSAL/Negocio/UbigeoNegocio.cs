using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class UbigeoNegocio
    {
        public List<Ubigeo> ListarDepartamentos()
        {
            UbigeoData control = new UbigeoData();
            return control.ListarDepartamentos();
        }

        public List<Ubigeo> ListarProvincias(string departamentoId)
        {
            UbigeoData control = new UbigeoData();
            return control.ListarProvincias(departamentoId);
        }

        public List<Ubigeo> ListarDistritos(string departamentoId,string provinciaId)
        {
            UbigeoData control = new UbigeoData();
            return control.ListarDistritos(departamentoId,provinciaId);
        }
    }
}
