using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class VideoNegocio
    {
        public List<Video> ListarVideoUltimos()
        {
            VideoData control = new VideoData();
            return control.ListarVideoUltimos();
        }

        public Video ListaVideoxID(int pintVideoID)
        {
            VideoData control = new VideoData();
            return control.ListaVideoxID(pintVideoID);
        }

        public int ActualizarVideo(Video video)
        {
            VideoData control = new VideoData();
            return control.ActualizarVideo(video);
        }
    }
}
