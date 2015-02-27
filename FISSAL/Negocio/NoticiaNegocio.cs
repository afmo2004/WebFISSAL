using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class NoticiaNegocio
    {
        public Noticia ListarNoticiaxID(int intCodigo)
        {
            NoticiaData control = new NoticiaData();
            return control.ListarNoticiaxID(intCodigo);
        }

        public List<Noticia> ListarNoticias()
        {
            NoticiaData control = new NoticiaData();
            return control.ListarNoticias();
        }

        public List<Noticia> ListarNoticiaHome()
        {
            NoticiaData control = new NoticiaData();
            return control.ListarNoticiaHome();
        }

        public List<Noticia> ListarNoticiaUltimos(int intCantidad)
        {
            NoticiaData control = new NoticiaData();
            return control.ListarNoticiaUltimos(intCantidad);
        }

        public List<Noticia> ListarNoticiaPortadaSeccion()
        {
            NoticiaData control = new NoticiaData();
            return control.ListarNoticiaPortadaSeccion();
        }

        public List<Noticia> ListarNoticiaSeccion()
        {
            NoticiaData control = new NoticiaData();
            return control.ListarNoticiaSeccion();
        }

        public List<Noticia> ListarNoticiaSeccionActivo()
        {
            NoticiaData control = new NoticiaData();
            return control.ListarNoticiaSeccionActivo();
        }

        public int ActualizarNoticia(Noticia noticia)
        {
            NoticiaData control = new NoticiaData();
            return control.ActualizarNoticia(noticia);
        }

        public int InsertarNoticia(Noticia noticia)
        {
            NoticiaData control = new NoticiaData();
            return control.InsertarNoticia(noticia);
        }
    }
}
