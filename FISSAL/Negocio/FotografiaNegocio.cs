using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class FotografiaNegocio
    {
        public Fotografia ListarFotografiaxID(int pintCodigo)
        {
            FotografiaData control = new FotografiaData();
            return control.ListarFotografiaxID(pintCodigo);
        }

        public List<Fotografia> ListarFotografias()
        {
            FotografiaData control = new FotografiaData();
            return control.ListarFotografias();
        }

        public int ActualizarFoto(int intCodigo, string vchLeyenda, string vchImagen, string chrEstado, string vchUsuarioCreacion, string vchUsuarioModificacion)
        {
            FotografiaData control = new FotografiaData();
            return control.ActualizarFoto(intCodigo, vchLeyenda, vchImagen, chrEstado, vchUsuarioCreacion, vchUsuarioModificacion);
        }

        public int InsertarFoto(int intCodigo, string vchLeyenda, string vchImagen, string chrEstado, string vchUsuarioCreacion, string vchUsuarioModificacion)
        {
            FotografiaData control = new FotografiaData();
            return control.InsertarFoto(intCodigo, vchLeyenda, vchImagen, chrEstado, vchUsuarioCreacion, vchUsuarioModificacion);
        }

        public void EliminarFoto(int intCodigo)
        {
            FotografiaData control = new FotografiaData();
            control.EliminarFoto(intCodigo);
        }
    }
}
