using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class NoticiaFotografiaNegocio
    {
        public List<NoticiaFotografia> ListarxNoticia(int intNoticiaID)
        {
            NoticiaFotografiaData control = new NoticiaFotografiaData();
            return control.ListarxNoticia(intNoticiaID);
        }

        public List<NoticiaFotografia> ListarxFoto(int intFotoID)
        {
            NoticiaFotografiaData control = new NoticiaFotografiaData();
            return control.ListarxFoto(intFotoID);
        }

        public int InsertarNoticiaFotografia(NoticiaFotografia notaFoto)
        {
            NoticiaFotografiaData control = new NoticiaFotografiaData();
            return control.InsertarNoticiaFotografia(notaFoto);
        }

        public int EliminarNoticiaFotografia(int intNoticiaId, int intFotografiaId)
        {
            NoticiaFotografiaData control = new NoticiaFotografiaData();
            return control.EliminarNoticiaFotografia(intNoticiaId, intFotografiaId);
        }
    }
}
