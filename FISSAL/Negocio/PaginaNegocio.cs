using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class PaginaNegocio
    {
        public Pagina ListarPaginaxID(int intPagina)
        {
            PaginaData control = new PaginaData();
            return control.ListarPaginaxID(intPagina);
        }

        public List<Pagina> ListarPaginas()
        {
            PaginaData control = new PaginaData();
            return control.ListarPaginas();
        }

        public int ActualizarPagina(Pagina pagina)
        {
            PaginaData control = new PaginaData();
            return control.ActualizarPagina(pagina);
        }
    }
}
