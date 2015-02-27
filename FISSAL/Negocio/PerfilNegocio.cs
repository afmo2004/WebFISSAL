using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class PerfilNegocio
    {
        public List<Perfil> ListarPerfiles(string pstrBusqueda)
        {
            PerfilData DatAut = new PerfilData();
            return DatAut.ListarPerfiles(pstrBusqueda);
        }

        public Perfil ListaPerfilxID(int pintPerfil)
        {
            PerfilData DatAut = new PerfilData();
            return DatAut.ListaPerfilxID(pintPerfil);
        }

        public int ActualizarPerfil(Perfil perfil)
        {
            PerfilData DatAut = new PerfilData();
            return DatAut.ActualizarPerfil(perfil);
        }
    }
}
