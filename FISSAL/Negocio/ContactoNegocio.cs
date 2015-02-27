using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class ContactoNegocio
    {
        public List<Contacto> ListarContactenos()
        {
            ContactoData datos = new ContactoData();
            return datos.ListarContactenos();
        }

        public Contacto ListarContactenosxID(Int32 intCodigo)
        {
            ContactoData datos = new ContactoData();
            return datos.ListarContactenosxID(intCodigo);
        }

        public int InsertarContactenos(Contacto tabla)
        {
            ContactoData datos = new ContactoData();
            return datos.InsertarContactenos(tabla);
        }
    }
}
